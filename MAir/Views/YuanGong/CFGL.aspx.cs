using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Globalization;
using System.IO;

namespace CUST.WKG
{
    public partial class CFGL : System.Web.UI.Page
    {
        private UserState _usState;
        protected int cpage;
        protected int psize;
        private YGCF ygcf;
        private Struct_YGCF struct_ygcf;
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
            ygcf = new YGCF(_usState);
            struct_ygcf = new Struct_YGCF();
            if (!IsPostBack)
            {
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
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
            if (SysData.HasThisBMQX(_usState.userID,"110402") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }
        }
        private void ddltBind()
        {
            //事件种类
            ddlt_sjzl.DataTextField = "mc";
            ddlt_sjzl.DataValueField = "bm";
            ddlt_sjzl.DataSource = SysData.SJZL().Copy();
            ddlt_sjzl.DataBind();
            ddlt_sjzl.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
    
        }
        private void bind_Main()
        {
            struct_ygcf.p_sfr = "";//受罚人
            struct_ygcf.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门
            struct_ygcf.p_sjzl = ddlt_sjzl.SelectedValue.ToString().Trim();//事件种类
            struct_ygcf.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            if (tbx_kssj.Text.Trim().ToString() == "")
            {
                struct_ygcf.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_ygcf.p_kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {
                struct_ygcf.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_ygcf.p_jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//结束时间
            }
            //获取登陆人的ID
            struct_ygcf.p_userid = _usState.userID;
            DataTable dt = new DataTable();

            int count = ygcf.Select_YGCF_Count(struct_ygcf);
            pg_fy.TotalRecord = count;
            struct_ygcf.p_currentpage = pg_fy.CurrentPage;
            struct_ygcf.p_pagesize = pg_fy.NumPerPage;
            dt = ygcf.Select_YGCF_Pro(struct_ygcf);

            dt.Columns.Add("bm");
            dt.Columns.Add("sjzlmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("cfsjmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["sjzlmc"] = SysData.SJZLByKey(dr["sjzl"].ToString()).mc;

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["cfsjmc"] = DateTime.Parse(dr["cfsj"].ToString()).ToString("yyyy-MM-dd");
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            if (ddlt_sjzl.SelectedValue == "-2")
            {
                Response.Write("<script>alert('请选择事件种类！')</script>");
                return;
            }
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110403"))
                    {
                        Server.Transfer("YGCF_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("YGCF_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_ygcf = new Struct_YGCF(); 
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工惩罚->员工惩罚管理->惩罚    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygcf.Delete_YGCF(id, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110404"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工惩罚->员工惩罚管理->惩罚    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygcf.Delete_YGCF(id, p_czfs, p_czxx);
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
                struct_ygcf = new Struct_YGCF(); 
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_ygcf.p_id = id;
                        struct_ygcf.p_zt = "1";
                        struct_ygcf.p_bhyy = HF_yc.Value;
                        struct_ygcf.p_czfs = "05";
                        struct_ygcf.p_czxx = "位置：员工惩罚->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygcf.Update_YGCFZT(struct_ygcf);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1104", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_ygcf.p_id = id;
                        struct_ygcf.p_zt = "2";
                        struct_ygcf.p_bhyy = HF_yc.Value;
                        struct_ygcf.p_czfs = "06";
                        struct_ygcf.p_czxx = "位置：员工惩罚->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygcf.Update_YGCFZT(struct_ygcf);
                        SysData.Delete_TSR(csr, "11", "1104", id);
                        SysData.Insert_TSR(zsr, "11", "1104", id);
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
                        struct_ygcf.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_ygcf.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygcf.p_bhyy = HF_yc.Value;
                            struct_ygcf.p_czfs = "06";
                            struct_ygcf.p_czxx = "位置：员工惩罚->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygcf.Update_YGCF_SJBS_ZT(struct_ygcf);
                            SysData.Delete_TSR(zsr, "11", "1104", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_ygcf.p_sjc = sjc;
                            struct_ygcf.p_bhyy = HF_yc.Value;
                            struct_ygcf.p_czfs = "06";
                            struct_ygcf.p_czxx = "位置：员工惩罚->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ygcf.Update_YGCF_SJBS_LSSJ_ZT(struct_ygcf);

                            //将副本数据变为最终数据
                            struct_ygcf.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ygcf.p_bhyy = HF_yc.Value;
                            struct_ygcf.p_czfs = "06";
                            struct_ygcf.p_czxx = "位置：员工惩罚->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygcf.Update_YGCF_SJBS_FBSJ_ZT(struct_ygcf);
                            SysData.Delete_TSR(zsr, "11", "1104", id);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工惩罚信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_ygcf.p_id = id;
                        struct_ygcf.p_zt = "4";
                        struct_ygcf.p_bhyy = HF_yc.Value;
                        struct_ygcf.p_czfs = "07";
                        struct_ygcf.p_czxx = "位置：员工惩罚->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygcf.Update_YGCFZT(struct_ygcf);
                        SysData.Delete_TSR(csr, "11", "1104", id);
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
                        struct_ygcf.p_id = id;
                        struct_ygcf.p_zt = "4";
                        struct_ygcf.p_bhyy = HF_yc.Value;
                        struct_ygcf.p_czfs = "07";
                        struct_ygcf.p_czxx = "位置：员工惩罚->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygcf.Update_YGCFZT(struct_ygcf);
                        SysData.Delete_TSR(zsr, "11", "1104", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工惩罚信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../YuanGong/YGCF_Add.aspx", false);
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

        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = ygcf.Select_YGCF_DC(_usState.userID);
            dt_dc.Columns.Add("cfsj_str");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["sjzl"] = SysData.SJZLByKey(dr["sjzl"].ToString()).mc; ;//事件种类
                dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["cfsj"].ToString());
                //dr["cfsj"] = dt_csrq.ToShortDateString().ToString();
                dr["cfsj_str"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
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
            dt_dc.Columns.Remove("ZT");
            dt_dc.Columns.Remove("bmdm");
            dt_dc.Columns.Remove("cfsj");
            dt_dc.Columns.Remove("sfr");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "受罚人";   
            dr_Insert[1] = "事件种类";
            dr_Insert[2] = "简要经历和原因";
            dr_Insert[3] = "承担责任";
            dr_Insert[4] = "处理意见";
            dr_Insert[5] = "负责人";
            dr_Insert[6] = "处罚时间";


            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "员工惩罚_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../YuanGong/YGCF.xls");
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










