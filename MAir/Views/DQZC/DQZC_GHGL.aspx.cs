using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class DQZC_GHGL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        public string filepath;
        public string fpath;
        private UserState _usState;
        private GHGL ghgl;
        private Struct_ghgl struct_ghgl;
        public bool flag = true;
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ghgl = new GHGL(_usState);
            struct_ghgl = new Struct_ghgl();

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_XX;
            psize = _usState.C_YG_XX;
            if (!IsPostBack)
            {
                string lx = Request.Params["lx"];
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
            if (SysData.HasThisBMQX(_usState.userID, "220402") == true)
            {
                flag_add = true;
            }

            if (flag_add) { btn_add.Visible = true; }
        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;
            }
        }
        private void ddltBind()
        {
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_zt.Items.RemoveAt(2);

        }
        private void bind_Main()
        {

            if (tbx_kssj.Text == "")
            {
                struct_ghgl.kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_ghgl.kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始日期               
            }
            if (tbx_jssj.Text == "")
            {
                struct_ghgl.jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_ghgl.jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//结束日期               
            }
            struct_ghgl.zt = ddlt_zt.SelectedValue.ToString();
            struct_ghgl.lx = Request.Params["lx"];//文档类型
            int count = ghgl.Select_DQZC_GHGL_Count(struct_ghgl);
            pg_fy.TotalRecord = count;
            struct_ghgl.p_currentpage = pg_fy.CurrentPage;
            struct_ghgl.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = ghgl.Select_DQZC_GHGL(struct_ghgl).Tables[0];
            dt.Columns.Add("ztmc");
            dt.Columns.Add("scsjmc");
            foreach (DataRow dr in dt.Rows)
            {
                //登记日期    
                dr["scsjmc"] = DateTime.Parse(dr["scsj"].ToString()).ToString("yyyy-MM-dd");
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态                
            }

            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
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
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            string id = content[0];
            string zt = content[1];
            filepath = "UpLoads/" + struct_ghgl.id + "/";
            string path = System.Web.HttpContext.Current.Request.MapPath(filepath);
            if (e.CommandName == "down")
            {
                try
                {
                    content = e.CommandArgument.ToString().Split('&');
                    string wjm = content[0];
                    string sclj = content[1];
                    string filename = e.CommandArgument.ToString();//文件名
                    string name = filename.Substring(filename.LastIndexOf("\\") + 1);
                    if (File.Exists(sclj))
                    {
                        FileInfo fileInfo = new FileInfo(sclj);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + wjm);
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
                        Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                        return;
                        //Response.End();
                    }
                }
                catch { }
            }
            if (e.CommandName == "Delete")
            {
                struct_ghgl = new Struct_ghgl();
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已提交，不能删除！\")</script>");
                    return;
                }

                else
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：文件管理->文件提交管理->删除  描述：文件管理：[" + id + "]";
                    ghgl.Delete_DQZC_GHGL(id);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }
            }
            else if (e.CommandName == "KJRK")
            {
                Server.Transfer("JCJL_KJRK.aspx?ID=" + id);
            }
            else if (e.CommandName == "Update_TJ")
            {
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已通过审核，不可提交！\")</script>");
                    return;
                }
                else
                        if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已驳回，不可提交！\")</script>");
                    return;
                }
                else
                {
                    //执行update改变状态(提交)
                    ghgl.Update_DQZC_GHGLZT(id, "2", "");
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件未提交，不能审核！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已通过审核，不可重复审核！\")</script>");
                    return;
                }
                else
                        if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已驳回，不可审核！\")</script>");

                    return;
                }
                else
                {
                    //执行update改变状态（审核）
                    ghgl.Update_DQZC_GHGLZT(id, "3", "");
                }

            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件未提交，不能驳回！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已通过，不可重复驳回！\")</script>");

                    return;
                }
                else
                        if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件已驳回，不可重复驳回！\")</script>");

                    return;
                }
                else
                {
                    //执行update改变状态（驳回）
                    string bhyy = HF_yc.Value;
                    ghgl.Update_DQZC_GHGLZT(id, "4", bhyy);
                }
            }
            bind_Main();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt");
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                #region 删除的权限
                //删除隐藏
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220404") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }

                #endregion
                #region 提交的权限
                //提交隐藏
                ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220405") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }

                #endregion

                #region 审核的权限
                //审核隐藏
                ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = false;

                if (SysData.HasThisBMQX(_usState.userID, "220406") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }

                #endregion
                #region 驳回的权限
                //驳回隐藏
                ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220407") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }

                #endregion

            }
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/DQZC/GHGL_Add.aspx?lx=" + Request.Params["lx"], false);
        }

        protected void Repeater1_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}