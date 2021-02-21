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
    public partial class SBTZ : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private Struct_SELECT_COUNT struct_select_count;
        public bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_LL;
            psize = _usState.C_YG_LL;
            tzsb = new TZSB(_usState);
            struct_tzsb = new Struct_TZSB();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
                show();
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "140402") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void ddltBind()
        {
            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            // 设备位置
            ddlt_wz.DataSource = SysData.SBWZ().Copy();
            ddlt_wz.DataTextField = "mc";
            ddlt_wz.DataValueField = "bm";
            ddlt_wz.DataBind();
            ddlt_wz.Items.Insert(0, new ListItem("全部", "-1"));

            //设备类型
            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX().Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

        }
        private void bind_Main() {
            struct_tzsb.p_jc = ddlt_jc.SelectedValue.ToString();
            struct_tzsb.p_wz = ddlt_wz.SelectedValue.ToString();
            struct_tzsb.p_sblx = ddlt_sblx.SelectedValue.ToString();
            struct_tzsb.p_zt = ddlt_zt.SelectedValue.ToString();
            struct_tzsb.p_fwxx = tbx_fwxx.Text.ToString();
            struct_tzsb.p_userid = _usState.userID;
            int count = tzsb.Select_TZ_Count(struct_tzsb);
            pg_fy.TotalRecord = count;
            struct_tzsb.p_currentpage = pg_fy.CurrentPage;
            struct_tzsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = tzsb.Select_TZ_Pro(struct_tzsb).Tables[0];
            dt.Columns.Add("jcmc");
          //  dt.Columns.Add("wzmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("bm");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("tzwdsfdbmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["jcmc"] = SysData.ZXDMByKey(dr["jc"].ToString()).mc;
                dr["jgsj"] = Convert.ToDateTime(dr["jgsj"].ToString()).ToString("yyyy-MM-dd");
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;

                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["tzwdsfdbmc"] = SysData.SFJBByKey(dr["tzwdsfdb"].ToString()).mc;
            }


            ///绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[9];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
            string zt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识
            string tzbh = content[8];

            if (e.CommandName == "Edit")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140403"))
                    {
                        Server.Transfer("SBTZ_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("SBTZ_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_tzsb = new Struct_TZSB();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (Select_Count(id) != 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站下拥有设备，不能删除！\")</script>");
                        return;
                    }
                    else if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：台站->台站管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        tzsb.Delete_TZ(tzbh, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                        return;
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (Select_Count(id) != 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站下拥有设备，不能删除！\")</script>");
                        return;
                    }
                    else if (SysData.HasThisBMQX(_usState.userID, bmdm, "140404"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：台站->台站管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        tzsb.Delete_TZ(tzbh, p_czfs, p_czxx);
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
                struct_tzsb = new Struct_TZSB();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_tzsb.p_id = id;
                        struct_tzsb.p_zt = "1";
                        struct_tzsb.p_bhyy = HF_yc.Value;
                        struct_tzsb.p_czfs = "05";
                        struct_tzsb.p_czxx = "位置：台站->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        tzsb.Update_TZZT(struct_tzsb);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "14", "1404", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_tzsb.p_id = id;
                        struct_tzsb.p_zt = "2";
                        struct_tzsb.p_bhyy = HF_yc.Value;
                        struct_tzsb.p_czfs = "06";
                        struct_tzsb.p_czxx = "位置：台站->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        tzsb.Update_TZZT(struct_tzsb);
                        SysData.Delete_TSR(csr, "14", "1404", id);
                        SysData.Insert_TSR(zsr, "14", "1404", id);
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
                        struct_tzsb.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_tzsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_tzsb.p_bhyy = HF_yc.Value;
                            struct_tzsb.p_czfs = "06";
                            struct_tzsb.p_czxx = "位置：台站->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            tzsb.Update_TZ_SJBS_ZT(struct_tzsb);
                            SysData.Delete_TSR(zsr, "14", "1404", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_tzsb.p_sjc = sjc;
                            struct_tzsb.p_bhyy = HF_yc.Value;
                            struct_tzsb.p_czfs = "06";
                            struct_tzsb.p_czxx = "位置：台站->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            tzsb.Update_TZ_SJBS_LSSJ_ZT(struct_tzsb);

                            //将副本数据变为最终数据
                            struct_tzsb.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_tzsb.p_bhyy = HF_yc.Value;
                            struct_tzsb.p_czfs = "06";
                            struct_tzsb.p_czxx = "位置：台站->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            tzsb.Update_TZ_SJBS_FBSJ_ZT(struct_tzsb);
                            SysData.Delete_TSR(zsr, "14", "1404", id);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该台站信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_tzsb.p_id = id;
                        struct_tzsb.p_zt = "4";
                        struct_tzsb.p_bhyy = HF_yc.Value;
                        struct_tzsb.p_czfs = "07";
                        struct_tzsb.p_czxx = "位置：台站->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        tzsb.Update_TZZT(struct_tzsb);
                        SysData.Delete_TSR(csr, "14", "1404", id);
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
                        struct_tzsb.p_id = id;
                        struct_tzsb.p_zt = "4";
                        struct_tzsb.p_bhyy = HF_yc.Value;
                        struct_tzsb.p_czfs = "07";
                        struct_tzsb.p_czxx = "位置：台站->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        tzsb.Update_TZZT(struct_tzsb);
                        SysData.Delete_TSR(zsr, "14", "1404", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该台站信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "CZGL")
            {
                if (SysData.HasThisBMQX(_usState.userID, bmdm, "140403"))
                {
                    //点击操作管理跳转到操作页面
                    Response.Redirect("SBTZ_CZ.aspx?tzbh=" + tzbh + "&bmdm=" + bmdm);
                    // Server.Transfer("SBTZ_CZ.aspx?tzbh=" + e.CommandArgument.ToString() + "&bmdm=" + bmdm);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有管理权限！\")</script>");
                    return;
                }

            }
            
            bind_Main();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_byyx");
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBTZ_Add.aspx", false);
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        private int Select_Count(int id)//其它表是否有该台站数据
        {
            DataTable dt = tzsb.Select_TZ_Detail(id);
            struct_select_count.p_wz= dt.Rows[0]["wz"].ToString();
            struct_select_count.p_jc = dt.Rows[0]["jc"].ToString();
            struct_select_count.p_sblx = dt.Rows[0]["sblx"].ToString();
            int count = tzsb.Select_Table_Count_HD(struct_select_count) + tzsb.Select_Table_Count_TX(struct_select_count) +tzsb.Select_Table_Count_JS(struct_select_count) + tzsb.Select_Table_Count_QX(struct_select_count);
            return count;

        }
        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = tzsb.Select_TZ_DC(_usState.userID);
            dt_dc.Columns.Add("jgsj_new");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["tzbh"] = SysData.BMByKey(dr["tzbh"].ToString()).mc;
                dr["jc"] = SysData.BMByKey(dr["jc"].ToString()).mc;
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

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["jgsj"].ToString());
                //dr["rq"] = dt_csrq.ToShortDateString().ToString();
                dr["jgsj_new"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
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
            dt_dc.Columns.Remove("jgsj");
            //dt_dc.Columns.Remove("ZPLJ");
            //dt_dc.Columns.Remove("CSRQ");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "台站编号";
            dr_Insert[1] = "机场";
            dr_Insert[2] = "位置";
            dr_Insert[3] = "设备类型";
            dr_Insert[4] = "房屋信息";
            dr_Insert[5] = "楼层";
            dr_Insert[6] = "房间号";
            dr_Insert[7] = "结构";  
            dr_Insert[8] = "台站位置信息";
            dr_Insert[9] = "机房输入线路情况";
            dr_Insert[10] = "机房总输出";
            dr_Insert[11] = "机房总输出大小";
            dr_Insert[12] = "机房总输出数量";
            dr_Insert[13] = "上传";
            dr_Insert[14] = "台站温度是否达标";
            dr_Insert[15] = "不达标原因";
            dr_Insert[16] = "驳回原因";
            dr_Insert[17] = "操作方式";
            dr_Insert[18] = "部门代码";
            dr_Insert[19] = "台站名称";
            //dr_Insert[20] = "竣工时间";

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "台站管理_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../SheBei/SBTZ.xls");
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