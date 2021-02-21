using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using CUST.Tools;
using CUST;
using CUST.Sys;
using CUST.MKG;
using Sys;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace CUST.WKG
{
    public partial class TXSB_GL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private TXSB txsb;
        private Struct_TXSB struct_txsb;
        private string sbbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_SB_TX;
            psize = _usState.C_SB_TX;
            txsb = new TXSB(_usState);
            struct_txsb = new Struct_TXSB();
            if (!IsPostBack)
            {
                ddltBind();
                show();
                bind_Main();
            }
        }

        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "140202") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void ddltBind()
        {
            //绑定设备类型 ddlt_sblx           
            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX("01").Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));

            ////绑定台站名称 ddlt_tzmc
            //ddlt_tzmc.DataTextField = "mc";
            //ddlt_tzmc.DataValueField = "bm";
            //ddlt_tzmc.DataSource = SysData.TZLX().Copy();
            //ddlt_tzmc.DataBind();
            //ddlt_tzmc.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            //位置
            ddlt_wz.DataTextField = "mc";
            ddlt_wz.DataValueField = "bm";
            ddlt_wz.DataSource = SysData.SBWZ().Copy();
            ddlt_wz.DataBind();
            ddlt_wz.Items.Insert(0, new ListItem("全部", "-1"));

            //绑定所属机场 ddlt_ssjc(支线)
            ddlt_ssjc.DataTextField = "mc";
            ddlt_ssjc.DataValueField = "bm";
            ddlt_ssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_ssjc.DataBind();
            ddlt_ssjc.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_txsb.p_sblx = ddlt_sblx.SelectedValue.ToString();
            struct_txsb.p_ssjc = ddlt_ssjc.SelectedValue.ToString();
            struct_txsb.p_wz = ddlt_wz.SelectedValue.ToString();
            //struct_txsb.p_tzmc = ddlt_wz.SelectedValue.ToString()+ddlt_sblx.SelectedValue.ToString();
            struct_txsb.p_zt = ddlt_zt.SelectedValue.ToString();
            struct_txsb.p_userid = _usState.userID;

            int count = txsb.Select_TXSB_Count(struct_txsb);
            pg_fy.TotalRecord = count;
            struct_txsb.p_currentpage = pg_fy.CurrentPage;
            struct_txsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = txsb.Select_TXSB_Pro(struct_txsb).Tables[0];
            dt.Columns.Add("ssjcmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("tzmcmc");
            dt.Columns.Add("wzmc");
            dt.Columns.Add("sbztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ssjcmc"] = SysData.ZXDMByKey(dr["ssjc"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;//设备类型
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["wzmc"] = SysData.SBWZByKey(dr["wz"].ToString()).mc;
                dr["sbztmc"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["tzmcmc"] = Convert.ToString(SysData.ZXDMByKey(dr["ssjc"].ToString()).mc + " " + SysData.SBWZByKey(dr["wz"].ToString()).mc + " " + SysData.SBLXByKey(dr["sblx"].ToString()).mc);
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        #region 错误信息

        protected void Page_Error(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Write(EMException.ShowErrorScript(Server.GetLastError()));
                Response.Write(StrConvert.ShowScript("history.back();"));
                Response.End();
            }
            finally
            {
                Server.ClearError();
            }
        }
        #endregion

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/TXSB_Add.aspx");
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
            string zt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识

            if (e.CommandName == "Edit")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140203"))
                    {
                        Server.Transfer("TXSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该部门的编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
                else if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        Server.Transfer("TXSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_txsb = new Struct_TXSB();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->通信设备->   描述：员工编号：[" + _usState.userLoginName + "]";
                        txsb.Delete_TXSB(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->通信设备    描述：员工编号：[" + _usState.userLoginName + "]";
                        txsb.Delete_TXSB(id, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该部门删除权限，不可删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_TJ")
            {
                struct_txsb = new Struct_TXSB();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_txsb.p_id = id;
                        struct_txsb.p_zt = "1";
                        struct_txsb.p_bhyy = HF_yc.Value;
                        struct_txsb.p_czfs = "05";
                        struct_txsb.p_czxx = "位置：设备管理->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        txsb.Update_TXSBZT(struct_txsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息已驳回，请先编辑再提交！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        struct_txsb.p_id = id;
                        struct_txsb.p_zt = "2";
                        struct_txsb.p_bhyy = HF_yc.Value;
                        struct_txsb.p_czfs = "06";
                        struct_txsb.p_czxx = "位置：设备管理->通信设备->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        txsb.Update_TXSBZT(struct_txsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (zt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        struct_txsb.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_txsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_txsb.p_bhyy = HF_yc.Value;
                            struct_txsb.p_czfs = "06";
                            struct_txsb.p_czxx = "位置：设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            txsb.Update_TXSB_SJBS_ZT(struct_txsb);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_txsb.p_sjc = sjc;
                            struct_txsb.p_bhyy = HF_yc.Value;
                            struct_txsb.p_czfs = "06";
                            struct_txsb.p_czxx = "位置：设备管理->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            txsb.Update_TXSB_SJBS_LSSJ_ZT(struct_txsb);

                            //将副本数据变为最终数据
                            struct_txsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_txsb.p_bhyy = HF_yc.Value;
                            struct_txsb.p_czfs = "06";
                            struct_txsb.p_czxx = "位置：设备管理->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            txsb.Update_TXSB_SJBS_FBSJ_ZT(struct_txsb);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该设备信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_txsb.p_id = id;
                        struct_txsb.p_zt = "4";
                        struct_txsb.p_bhyy = HF_yc.Value;
                        struct_txsb.p_czfs = "07";
                        struct_txsb.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        txsb.Update_TXSBZT(struct_txsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能驳回！\")</script>");
                        return;
                    }
                }
                else if (zt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_txsb.p_id = id;
                        struct_txsb.p_zt = "4";
                        struct_txsb.p_bhyy = HF_yc.Value;
                        struct_txsb.p_czfs = "07";
                        struct_txsb.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        txsb.Update_TXSBZT(struct_txsb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_ztmc");
                if (lbl_zt.Text == "待提交")//0
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Blue;
                }
                if (lbl_zt.Text == "待初审")//1
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "待终审")//2
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "审核通过")//3
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_zt.Text == "审核未通过")//4
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = txsb.Select_TXSB_DC(_usState.userID);
           // dt_dc.Columns.Add("rq");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                //  dr["sblx"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
                dr["sbbh"] = SysData.SBLXByKey(dr["sbbh"].ToString()).mc;
                dr["sblx"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;


                // DateTime dt_csrq = new DateTime();
                //dt_csrq = Convert.ToDateTime(dr["csrq"].ToString());
                //// dr["rq"]= dt_csrq.ToShortDateString().ToString();
                //dr["rq"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
            }

            //删除不用的列
            DataRow dr_Insert = dt_dc.NewRow();
            dt_dc.Columns.Remove("ID");
            dt_dc.Columns.Remove("BHYY");
            dt_dc.Columns.Remove("CSR");
            dt_dc.Columns.Remove("ZSR");
            dt_dc.Columns.Remove("LRR");
            dt_dc.Columns.Remove("SHSJ");
            dt_dc.Columns.Remove("SJC");
            dt_dc.Columns.Remove("SJBS");
            dt_dc.Columns.Remove("SJSSBM");
            //dt_dc.Columns.Remove("ZPLJ");
            // dt_dc.Columns.Remove("CSRQ");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "设备编号";
            dr_Insert[1] = "设备类型";
            dr_Insert[2] = "台站名称";
            dr_Insert[3] = "所属机场";
            dr_Insert[4] = "投产开放时间";
            dr_Insert[5] = "数量";
            dr_Insert[6] = "设备状态";
            dr_Insert[7] = "设备生产厂家";
            dr_Insert[8] = "设备出厂编号";
            dr_Insert[9] = "设备许可证上传";
            dr_Insert[10] = "用途";
            dr_Insert[11] = "交流供电";
            dr_Insert[12] = "交流供电大小";
            dr_Insert[13] = "交流供电数量";
            dr_Insert[14] = "直流供电";
            dr_Insert[15] = "直流供电大小";
            dr_Insert[16] = "直流供电数量";
            dr_Insert[17] = "保护区范围";
            dr_Insert[18] = "设备传输情况";
            dr_Insert[19] = "设备防雷配置";
            dr_Insert[20] = "驳回原因";
            dr_Insert[21] = "现所属机场";
            dr_Insert[22] = "调拨时间";
            dr_Insert[23] = "设备保管人";
            dr_Insert[24] = "语音记录仪_现有用户数";
            dr_Insert[25] = "语音记录仪_语音信道数";
            dr_Insert[26] = "语音记录仪_数据信道数";
            dr_Insert[27] = "卫星地面站系统_站点类型";
            dr_Insert[28] = "卫星地面站系统_天线口径";
            dr_Insert[29] = "卫星地面站系统_室外单元功率";
            dr_Insert[30] = "卫星地面站系统_发射频率";
            dr_Insert[31] = "卫星地面站系统_接收频率";
            dr_Insert[32] = "卫星地面站系统_信道数";
            dr_Insert[33] = "卫星地面站系统_台站坐标_北京54_经度";
            dr_Insert[34] = "卫星地面站系统_台站坐标_北京54_纬度";
            dr_Insert[35] = "卫星地面站系统_台站坐标_wgs84_经度";
            dr_Insert[36] = "卫星地面站系统_台站坐标_wgs84_纬度";
            dr_Insert[37] = "卫星地面站系统_天线设置地点";
            dr_Insert[38] = "卫星地面站系统_天线基础高程";
            dr_Insert[39] = "卫星地面站系统_无线电台执照有效期";
            dr_Insert[40] = "卫星地面站系统_上传";
            dr_Insert[40] = "甚高频地空通信系统_设备配置";
            dr_Insert[41] = "甚高频地空通信系统_设备信道数";
            dr_Insert[42] = "甚高频地空通信系统_天线类型";
            dr_Insert[43] = "甚高频地空通信系统_投产校飞日期";
            dr_Insert[44] = "甚高频地空通信系统_发射频率";
            dr_Insert[45] = "甚高频地空通信系统_输出功率";
            dr_Insert[46] = "甚高频地空通信系统_传输方式";
            dr_Insert[47] = "甚高频地空通信系统_上传";
            dr_Insert[48] = "甚高频地空通信系统_台站坐标_北京54_经度";
            dr_Insert[49] = "甚高频地空通信系统_台站坐标_北京54_纬度";
            dr_Insert[50] = "甚高频地空通信系统_台站坐标_wgs84_经度";
            dr_Insert[51] = "甚高频地空通信系统_台站坐标_wgs84_纬度";
            dr_Insert[52] = "甚高频地空通信系统_天线基础高程";
            dr_Insert[53] = "甚高频地空通信系统_天线高度";
            dr_Insert[54] = "甚高频地空通信系统_天线设置地点";
            dr_Insert[55] = "甚高频地空通信系统_无线电台执照有效期";
            dr_Insert[56] = "甚高频地空通信系统_天线生产厂家";
            dr_Insert[57] = "甚高频地空通信系统_天线型号_类型";
            dr_Insert[58] = "语音交换系统（内话）_系统配置";
            dr_Insert[59] = "语音交换系统（内话）_席位具体配置";
            dr_Insert[60] = "语音交换系统（内话）_系统软件版本";
            dr_Insert[61] = "语音交换系统（内话）_接口数量_有线";
            dr_Insert[62] = "语音交换系统（内话）_mfc协议";
            dr_Insert[63] = "语音交换系统（内话）_Qsig协议";
            dr_Insert[64] = "语音交换系统（内话）_ip协议";
            dr_Insert[65] = "语音交换系统（内话）_接口数量_无线";
            dr_Insert[66] = " 自动转报系统_系统配置";
            dr_Insert[67] = " 自动转报系统_系统软件版本";
            dr_Insert[68] = " 自动转报系统_在用系统";
            dr_Insert[69] = " 自动转报系统_终端用户列表";
            dr_Insert[70] = "高频地空通信系统_设备配置";
            dr_Insert[71] = "高频地空通信系统_设备信道数";
            dr_Insert[72] = "高频地空通信系统_天线类型";
            dr_Insert[73] = "高频地空通信系统_投产校飞日期";
            dr_Insert[74] = "高频地空通信系统_发射频率";
            dr_Insert[75] = "高频地空通信系统_输出功率";
            dr_Insert[76] = "高频地空通信系统_传输方式";
            dr_Insert[77] = "高频地空通信系统_上传";
            dr_Insert[78] = "高频地空通信系统_台站坐标_北京54_经度";
            dr_Insert[79] = "高频地空通信系统_台站坐标_北京54_经度";
            dr_Insert[80] = "高频地空通信系统_台站坐标_北京54_纬度";
            dr_Insert[81] = "高频地空通信系统_台站坐标_wgs84_经度";
            dr_Insert[82] = "高频地空通信系统_台站坐标_wgs84_纬度";
            dr_Insert[83] = "频地空通信系统_天线基础高程";    
            dr_Insert[84] = "高频地空通信系统_天线高度";
            dr_Insert[85] = "高频地空通信系统_天线设置地点";
            dr_Insert[86] = "高频地空通信系统_无线电台执照有效期";
            dr_Insert[87] = "高频地空通信系统_天线生产厂家";
            dr_Insert[88] = "高频地空通信系统_天线生产厂家";
            dr_Insert[89] = "设备型号";
            //dr_Insert[90] = "录入人";
            //dr_Insert[91] = "初审人";
            //dr_Insert[92] = "终身人";
            //dr_Insert[93] = "时间戳";
            //dr_Insert[94] = "数据标识";
            //dr_Insert[95] = "审核时间";
            //dr_Insert[96] = "数据所属部门";
            //dr_Insert[97] = "位置";

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "通讯信息" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../SheBei/TXSB.xls");
            // 1、首先判断文件或者文件路径是否存在
            if (File.Exists(path))
            {
                // 3.2、删除文件
                File.Delete(path);
            }

            ex.OutputFilePath = path;
            ex.OutputExcelFile();

            string fileName = hz;//客户端保存的文件名 
            string filePath = path;//目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }
        }





    }
}