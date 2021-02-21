using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using CUST.MKG;
using CUST.Sys;
using System.Data;
using Sys;
using CUST.Tools;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;

namespace CUST.WKG
{
    public partial class JLGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YGJL ygjl;
        private Struct_YGJL_Pro struct_YGJL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = _usState.C_ZL_ZJ;
            ygjl = new YGJL(_usState);
            struct_YGJL = new Struct_YGJL_Pro();
            if (!IsPostBack)
            {
                tbx_rqks.Attributes.Add("readonly", "readonly");
                tbx_rqjs.Attributes.Add("readonly", "readonly");
                ddltBind();
                show();
                bind_Main();
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "110502") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void ddltBind()
        {
            ////奖励种类
            //ddlt_jlzl.DataSource = SysData.JLZL().Copy();
            //ddlt_jlzl.DataTextField = "mc";
            //ddlt_jlzl.DataValueField = "bm";
            //ddlt_jlzl.DataBind();
            //ddlt_jlzl.Items.Insert(0, new ListItem("全部", "-1"));

            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //奖励等级
            ddlt_jldj.DataSource = SysData.JLDJ().Copy();
            ddlt_jldj.DataTextField = "mc";
            ddlt_jldj.DataValueField = "bm";
            ddlt_jldj.DataBind();
            ddlt_jldj.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_YGJL.p_sjr = "";//受奖人
            struct_YGJL.p_bmdm = ddlt_bmdm.SelectedValue.Trim().ToString();//部门代码
            struct_YGJL.p_jlzl = "-1";//奖励种类
            struct_YGJL.p_jldj = ddlt_jldj.SelectedValue.Trim().ToString();//奖励等级
            struct_YGJL.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态

            if (tbx_rqks.Text == "")
            {

                struct_YGJL.p_rqks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_YGJL.p_rqks = DateTime.Parse(tbx_rqks.Text.Trim().ToString());//开始时间
            }
            if (tbx_rqjs.Text == "")
            {
                // DateTime dt_jssj = new DateTime();
                struct_YGJL.p_rqjs = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_YGJL.p_rqjs = DateTime.Parse(tbx_rqjs.Text.Trim().ToString());//结束时间
            }
            struct_YGJL.p_userid = _usState.userID;
            DataTable dt = new DataTable();

            int count = ygjl.Select_YGJL_Count(struct_YGJL);
            pg_fy.TotalRecord = count;
            struct_YGJL.p_currentpage = pg_fy.CurrentPage;
            struct_YGJL.p_pagesize = pg_fy.NumPerPage;
            dt = ygjl.Select_YGJL_Pro(struct_YGJL);

            dt.Columns.Add("bm");
            dt.Columns.Add("jlzlmc");
            dt.Columns.Add("jldjmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("rqmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["jlzlmc"] = SysData.JLZLByKey(dr["jlzl"].ToString()).mc;
                dr["jldjmc"] = SysData.JLDJByKey(dr["jldj"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["rqmc"] = DateTime.Parse(dr["rq"].ToString()).ToString("yyyy-MM-dd");
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110503"))
                    {
                        Server.Transfer("JLJL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("JLJL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_YGJL = new Struct_YGJL_Pro();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工奖励->员工奖励管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygjl.Delete_YGJL(id, p_czfs, p_czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110504"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工奖励->员工奖励管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygjl.Delete_YGJL(id, p_czfs, p_czxx);
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
                struct_YGJL = new Struct_YGJL_Pro();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_YGJL.p_id = id;
                        struct_YGJL.p_zt = "1";
                        struct_YGJL.p_bhyy = HF_yc.Value;
                        struct_YGJL.p_czfs = "05";
                        struct_YGJL.p_czxx = "位置：员工奖励->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygjl.Update_YGJLZT(struct_YGJL);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1105", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_YGJL.p_id = id;
                        struct_YGJL.p_zt = "2";
                        struct_YGJL.p_bhyy = HF_yc.Value;
                        struct_YGJL.p_czfs = "06";
                        struct_YGJL.p_czxx = "位置：员工奖励->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygjl.Update_YGJLZT(struct_YGJL);
                        SysData.Delete_TSR(csr, "11", "1105", id);
                        SysData.Insert_TSR(zsr, "11", "1105", id);
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
                        struct_YGJL.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_YGJL.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_YGJL.p_bhyy = HF_yc.Value;
                            struct_YGJL.p_czfs = "06";
                            struct_YGJL.p_czxx = "位置：员工奖励->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygjl.Update_YGJL_SJBS_ZT(struct_YGJL);
                            SysData.Delete_TSR(zsr, "11", "1105", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_YGJL.p_sjc = sjc;
                            struct_YGJL.p_bhyy = HF_yc.Value;
                            struct_YGJL.p_czfs = "06";
                            struct_YGJL.p_czxx = "位置：员工奖励->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ygjl.Update_YGJL_SJBS_LSSJ_ZT(struct_YGJL);

                            //将副本数据变为最终数据
                            struct_YGJL.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_YGJL.p_bhyy = HF_yc.Value;
                            struct_YGJL.p_czfs = "06";
                            struct_YGJL.p_czxx = "位置：员工奖励->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ygjl.Update_YGJL_SJBS_FBSJ_ZT(struct_YGJL);
                            SysData.Delete_TSR(zsr, "11", "1105", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工奖励信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已通过审核，不能重复审核！\")</script>");
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
                        struct_YGJL.p_id = id;
                        struct_YGJL.p_zt = "4";
                        struct_YGJL.p_bhyy = HF_yc.Value;
                        struct_YGJL.p_czfs = "07";
                        struct_YGJL.p_czxx = "位置：员工奖励->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygjl.Update_YGJLZT(struct_YGJL);
                        SysData.Delete_TSR(csr, "11", "1105", id);
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
                        struct_YGJL.p_id = id;
                        struct_YGJL.p_zt = "4";
                        struct_YGJL.p_bhyy = HF_yc.Value;
                        struct_YGJL.p_czfs = "07";
                        struct_YGJL.p_czxx = "位置：员工奖励->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ygjl.Update_YGJLZT(struct_YGJL);
                        SysData.Delete_TSR(zsr, "11", "1105", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
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
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../YuanGong/JLJL_Add.aspx", false);
        }

        protected void btn_dc_Click(object sender, EventArgs e)
        {
            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = ygjl.Select_YGJL_DC(_usState.userID);
            if (dt_dc.Rows.Count==0) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"暂无数据，请先录入数据再导出！\")</script>");
                return;
            }

            //dt_dc.Columns.Add("rq");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["jlzl"] = SysData.JLZLByKey(dr["jlzl"].ToString()).mc;//奖励种类
                dr["jldj"] = SysData.JLDJByKey(dr["jldj"].ToString()).mc;//奖励等级
                dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门

                DateTime dt_rq = new DateTime();
                dt_rq = Convert.ToDateTime(dr["RQ"].ToString());
                dr["RQ"] = string.Format("{0:yyyy-MM-dd}", dt_rq);
            }

            //删除不用的列
            DataRow dr_Insert = dt_dc.NewRow();
            dt_dc.Columns.Remove("ID");//id
            dt_dc.Columns.Remove("ZT");//状态
            dt_dc.Columns.Remove("BHYY");//驳回原因
            dt_dc.Columns.Remove("bm");//状态
            dt_dc.Columns.Remove("CSR");//初审人
            dt_dc.Columns.Remove("ZSR");//终审人
            dt_dc.Columns.Remove("LRR");//录入人
            dt_dc.Columns.Remove("SJBS");//数据标识
            dt_dc.Columns.Remove("SJC");//时间戳
            dt_dc.Columns.Remove("SHSJ");//审核时间
            
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "日期";
            dr_Insert[1] = "受奖人";
            dr_Insert[2] = "奖励原因";
            dr_Insert[3] = "奖励种类";
            dr_Insert[4] = "奖励等级";
            dr_Insert[5] = "奖励内容";
            dr_Insert[6] = "负责人";

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "员工奖励_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../YuanGong/YGJL.xls");
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