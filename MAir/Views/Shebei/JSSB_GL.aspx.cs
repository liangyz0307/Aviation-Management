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
    public partial class JSSB_GL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private Struct_JSSB struct_jssb;
        private JSSB jssb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //cpage = pg_fy.CurrentPage;
            //pg_fy.NumPerPage = _usState.C_SB_JS;
            //psize = _usState.C_SB_JS;
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = _usState.C_ZL_ZJ;
            jssb = new JSSB(_usState);
            struct_jssb = new Struct_JSSB();
            if (!IsPostBack)
            {
                ddltBind();
                //show();
                bind_Main();
            }
        }
        //#region show方法 显示 隐藏 添加按钮
        //public void show() {
        //    //添加和删除的判断标识符
        //    Boolean flag_add = false;
        //    //默认隐藏添加按钮
        //    btn_add.Visible = false;

        //    if (SysData.HasThisBMQX(_usState.userID, "140602") == true)
        //    {
        //        flag_add = true;
        //    }
        //    if (flag_add) { btn_add.Visible = true; }

        //}
        //#endregion

        #region 绑定下拉框
        public void ddltBind() {
            //绑定设备类型 ddlt_sblx           
            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX("04").Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));
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
            //设备状态
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        #endregion

        #region 绑查询条件 查总数 加列转汉字 绑定数据源
        private void bind_Main()
        {
            struct_jssb.p_ssjc = ddlt_ssjc.SelectedValue.ToString();
            struct_jssb.p_wz = ddlt_wz.SelectedValue.ToString();
            struct_jssb.p_sblx = ddlt_sblx.SelectedValue.ToString();
            struct_jssb.p_sbzt = ddlt_sbzt.SelectedValue.ToString();
            struct_jssb.p_userid = _usState.userID;

            DataTable dt = new DataTable();
            int count = jssb.Select_JSSB_Count(struct_jssb);
            pg_fy.TotalRecord = count;
            struct_jssb.p_currentpage = pg_fy.CurrentPage;
            struct_jssb.p_pagesize = pg_fy.NumPerPage;
            dt = jssb.Select_JSSB_Pro(struct_jssb);


            dt.Columns.Add("ssjcmc");
            dt.Columns.Add("wzmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("sbztmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("tzmczlmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ssjcmc"] = SysData.ZXDMByKey(dr["ssjc"].ToString()).mc;
                dr["wzmc"] = SysData.SBWZByKey(dr["wz"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;//设备类型
                dr["sbztmc"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["tzmczlmc"] = Convert.ToString(SysData.ZXDMByKey(dr["ssjc"].ToString()).mc + " " + SysData.SBWZByKey(dr["wz"].ToString()).mc + " " + SysData.SBLXByKey(dr["sblx"].ToString()).mc);


            }
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        #endregion

        #region pg_fy_PageChanged
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        #endregion

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

        #region 添加按钮
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/JSSB_Add.aspx");
        }
        #endregion

        #region 查询按钮
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        #endregion

        #region Repeater1_ItemCommand
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
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "141003"))
                    {
                        Server.Transfer("JSSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("JSSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_jssb = new Struct_JSSB();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->监视设备->   描述：员工编号：[" + _usState.userLoginName + "]";
                        jssb.Delete_JSSB(id, p_czfs, p_czxx);
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
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "141004"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：设备管理->监视设备    描述：员工编号：[" + _usState.userLoginName + "]";
                        jssb.Delete_JSSB(id, p_czfs, p_czxx);
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
                struct_jssb = new Struct_JSSB();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_jssb.p_id = id;
                        struct_jssb.p_zt = "1";
                        struct_jssb.p_bhyy = HF_yc.Value;
                        struct_jssb.p_czfs = "05";
                        struct_jssb.p_czxx = "位置：设备管理->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        jssb.Update_JSSB_ZT(struct_jssb);
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
                        struct_jssb.p_id = id;
                        struct_jssb.p_zt = "2";
                        struct_jssb.p_bhyy = HF_yc.Value;
                        struct_jssb.p_czfs = "06";
                        struct_jssb.p_czxx = "位置：设备管理->监视设备->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        jssb.Update_JSSB_ZT(struct_jssb);
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
                        struct_jssb.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_jssb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_jssb.p_bhyy = HF_yc.Value;
                            struct_jssb.p_czfs = "06";
                            struct_jssb.p_czxx = "位置：设备管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            jssb.Update_JSSB_SJBS_ZT(struct_jssb);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_jssb.p_sjc = sjc;
                            struct_jssb.p_bhyy = HF_yc.Value;
                            struct_jssb.p_czfs = "06";
                            struct_jssb.p_czxx = "位置：设备管理->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            jssb.Update_JSSB_SJBS_LSSJ_ZT(struct_jssb);

                            //将副本数据变为最终数据
                            struct_jssb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_jssb.p_bhyy = HF_yc.Value;
                            struct_jssb.p_czfs = "06";
                            struct_jssb.p_czxx = "位置：设备管理->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            jssb.Update_JSSB_SJBS_FBSJ_ZT(struct_jssb);
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
                        struct_jssb.p_id = id;
                        struct_jssb.p_zt = "4";
                        struct_jssb.p_bhyy = HF_yc.Value;
                        struct_jssb.p_czfs = "07";
                        struct_jssb.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        jssb.Update_JSSB_ZT(struct_jssb);
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
                        struct_jssb.p_id = id;
                        struct_jssb.p_zt = "4";
                        struct_jssb.p_bhyy = HF_yc.Value;
                        struct_jssb.p_czfs = "07";
                        struct_jssb.p_czxx = "位置：设备管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        jssb.Update_JSSB_ZT(struct_jssb);
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
        #endregion

        #region Repeater1_ItemDataBound  审核状态颜色变化
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
        #endregion
        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = jssb.Select_JSSB_DC(_usState.userID);
            //dt_dc.Columns.Add("rq");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                //dr["bmdm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                //dr["gwdm"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                //dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                //dr["xldm"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历
                //dr["gzddm"] = SysData.ZXDMByKey(dr["gzddm"].ToString()).mc;//工作地
                //dr["htgx"] = SysData.HTGXByKey(dr["htgx"].ToString()).mc;//合同关系
                //dr["htlxdm"] = SysData.HTLXByKey(dr["htlxdm"].ToString()).mc;//合同类型
                //dr["mzdm"] = SysData.MZByKey(dr["mzdm"].ToString()).mc;//名族
                //dr["xbdm"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;//性别
                //dr["zzmmdm"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//政治面貌代码

                //DateTime dt_csrq = new DateTime();
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
            //dt_dc.Columns.Remove("CSRQ");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "位置";
            dr_Insert[1] = "状态";
            dr_Insert[2] = "设备编号";
            dr_Insert[3] = "所属支线";
            dr_Insert[4] = "所属台站";
            dr_Insert[5] = "电台执照到期时间";
            dr_Insert[6] = "设备类型";
            dr_Insert[7] = "设备型号";
            dr_Insert[8] = "台站名称种类";
            dr_Insert[9] = "所属机场";
            dr_Insert[10] = "竣工日期";
            dr_Insert[11] = "投产校验日期";
            dr_Insert[12] = "投产开放或备案日期";
            dr_Insert[13] = "设备出厂编号";
            dr_Insert[14] = "主要技术参数填写";
            dr_Insert[15] = "设备状态";
            dr_Insert[16] = "供电方式";
            dr_Insert[17] = "传输方式";
            dr_Insert[18] = "设备生产厂家";
            dr_Insert[19] = "上传";
            dr_Insert[20] = "大地坐标(北京54)经度";
            dr_Insert[21] = "大地坐标(北京54)纬度";
            dr_Insert[22] = "大地坐标(北京54)经度";
            dr_Insert[23] = "大地坐标(北京54)纬度";
            dr_Insert[24] = "工作频率1";
            dr_Insert[25] = "测试信标型号2";
            dr_Insert[26] = "峰值功率3";
            dr_Insert[27] = "天线设置地点4";
            dr_Insert[28] = "雷达——天线基础高程";
            dr_Insert[29] = "雷达——天线高度";
            dr_Insert[30] = "雷达——天线生产厂家";
            dr_Insert[31] = "雷达——天线型号_类型";
            dr_Insert[32] = "雷达——覆盖情况5";
            dr_Insert[33] = "雷达——无线电台执照有效期6";
            dr_Insert[34] = "上传7";
            dr_Insert[35] = "自动相关监视系统设备_工作频率";
            dr_Insert[36] = "自动相关监视系统设备_是否配测试信标";
            dr_Insert[37] = "自动相关监视系统设备_测试信标型号";
            dr_Insert[38] = "自动相关监视系统设备_测试信标S模式地址代码";
            dr_Insert[39] = "自动相关监视系统设备_持有执照人数";
            dr_Insert[40] = "自动相关监视系统设备_峰值功率";
            dr_Insert[41] = "自动相关监视系统设备_传输方式";
            dr_Insert[42] = "自动相关监视系统设备_天线设置地点";
            dr_Insert[43] = "自动相关监视系统设备_天线基础高程";
            dr_Insert[44] = "自动相关监视系统设备_天线生产厂家";
            dr_Insert[45] = "自动相关监视系统设备_天线型号_类型";
            dr_Insert[46] = "自动相关监视系统设备_无线电台执照有效期";
            dr_Insert[47] = "自动相关监视系统设备_上传";
            dr_Insert[48] = "多点定位系统_工作频率";
            dr_Insert[49] = "多点定位系统_发射台峰值功率";
            dr_Insert[50] = "多点定位系统_天线设置地点";
            dr_Insert[51] = "多点定位系统_天线基础高程";
            dr_Insert[52] = "多点定位系统_天线生产厂家";
            dr_Insert[53] = "/多点定位系统_天线型号_类型";
            dr_Insert[54] = "多点定位系统_无线电台执照有效期";
            dr_Insert[55] = "多点定位系统_上传";
            dr_Insert[56] = "自动化系统_监视源引接线路";
            dr_Insert[57] = "自动化系统_系统软件版本";
            dr_Insert[58] = "自动化系统_系统规模";
            dr_Insert[59] = "自动化系统_ATC管制扇区数";
            dr_Insert[60] = "自动化系统_A—SMGCS系统分级";
            dr_Insert[61] = "自动化系统_持有执照人数";
            dr_Insert[62] = "驳回原因";
            dr_Insert[63] = "初审人";
            dr_Insert[64] = "终审人";
            dr_Insert[65] = "录入人";
            dr_Insert[66] = "时间戳";
            dr_Insert[67] = "数据标识";
            dr_Insert[68] = "审核时间";
            dr_Insert[69] = "数据所属部门";
            dr_Insert[70] = "id";



            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "监视设备_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../SheBei/JSSB.xls");
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
