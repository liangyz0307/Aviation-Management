using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class AQJG_JCRW : System.Web.UI.Page
    {
        
        public int cpage;
        public int psize;
        public int zcount;
        private UserState _usState;
        private JCRW jcrw;
        private Struct_JCRW struct_jcrw;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            struct_jcrw = new Struct_JCRW();
            jcrw = new JCRW(_usState);
            if (!IsPostBack)
            {
                tbx_jcsjks.Attributes.Add("readonly", "readonly");
                tbx_jcsjjs.Attributes.Add("readonly", "readonly");
               // jcrw=new JCRW(_usState);
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
            //有检查任务添加权限
            if (SysData.HasThisBMQX(_usState.userID, "170202") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }  
        private void ddltBind()
        {
            //检查单
            ddlt_jcd.DataTextField = "mc";
            ddlt_jcd.DataValueField = "bm";
            ddlt_jcd.DataSource = SysData.TBDW().Copy();
            ddlt_jcd.DataBind();
            ddlt_jcd.Items.Insert(0, new ListItem("全部", "-1"));

            //检查任务状态
            ddlt_jcrwzt.DataTextField = "mc";
            ddlt_jcrwzt.DataValueField = "bm";
            ddlt_jcrwzt.DataSource = SysData.JCRWZT().Copy();
            ddlt_jcrwzt.DataBind();
            ddlt_jcrwzt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_jcrw.jcr = "";
            struct_jcrw.bjcr = "";//被检查人人            
            struct_jcrw.jcd = ddlt_jcd.SelectedValue.ToString().Trim();         //检查单
            struct_jcrw.jcrwzt = ddlt_jcrwzt.SelectedValue.ToString().Trim();         //检查单
            struct_jcrw.jcxm = tbx_jcnr.Text.ToString().Trim();//检查项目
            struct_jcrw.p_userid = _usState.userID;            //用户id
            if (tbx_jcsjks.Text.Trim().ToString() == "")
            {
                
                struct_jcrw.jcsjks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_jcrw.jcsjks = DateTime.Parse(tbx_jcsjks.Text.Trim().ToString());//开始时间
            }
            if (tbx_jcsjjs.Text.Trim().ToString() == "")
            {
                
                struct_jcrw.jcsjjs = Convert.ToDateTime("9999-12-30 23:59:59");

            }
            else
            {
                struct_jcrw.jcsjjs = DateTime.Parse(tbx_jcsjjs.Text.Trim().ToString());//开始时间
            }
            int count = jcrw.Select_JCRW_Count(struct_jcrw);
            pg_fy.TotalRecord = count;
            struct_jcrw.currentpage = pg_fy.CurrentPage;
            struct_jcrw.pagesize = pg_fy.NumPerPage;
            DataTable dt = jcrw.Select_JCRW_Pro(struct_jcrw).Tables[0];
            dt.Columns.Add("jcrmc");
            dt.Columns.Add("bjcrmc");
            
            dt.Columns.Add("jcxmmc");
            dt.Columns.Add("jcsjmc");
            dt.Columns.Add("jcrwztmc");
            foreach (DataRow dr in dt.Rows)
            {
                
                dr["jcxmmc"] = SysData.TBDWByKey(dr["jcd1"].ToString()).mc;//检查项目
                dr["jcsjmc"] = DateTime.Parse(dr["jcsj"].ToString()).ToString("yyyy-MM-dd");
                dr["jcrwztmc"] = SysData.JCRWZTByKey(dr["jcrwzt"].ToString()).mc;//检查任务状态
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
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
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AQJG/AQJG_JCRW_Add.aspx", true);
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            long id = long.Parse (content[0]);
            //string zt = content[1];
            if (e.CommandName == "Edit")
            {
                if (SysData.HasThisBMQX(_usState.userID, "170203"))
                {
                    Server.Transfer("../AQJG/AQJG_JCRW_Edit.aspx?id=" + e.CommandArgument.ToString());
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限，不能编辑！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_jcrw.id = id;
                //个人删除权限
                if (SysData.HasThisBMQX(_usState.userID, "170204"))
                {
                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    struct_jcrw.czfs = "03";
                    struct_jcrw.czxx = "位置：安全监管->检查任务->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                    jcrw.Delete_JCRW_byID(struct_jcrw);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限，不能删除！\")</script>");
                    return;
                }
            }
          bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历查询出的检查任务状态，已完成为绿，未完成为红
            {
                Label lbl_jcrwzt = (Label)li.FindControl("lbl_jcrwzt");
                if (lbl_jcrwzt.Text == "已完成")//3
                {
                    lbl_jcrwzt.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_jcrwzt.Text == "未完成")//4
                {
                    lbl_jcrwzt.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                #region 删除按钮
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisQX("170204", _usState.userID, "01"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170204", _usState.userID, "02"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170204", _usState.userID, "03"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170204", _usState.userID, "04"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170204", _usState.userID, "05"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                #endregion
                #region 修改按钮
                ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = false;
                if (SysData.HasThisQX("170203", _usState.userID, "01"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                }
                if (SysData.HasThisQX("170203", _usState.userID, "02"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                }
                if (SysData.HasThisQX("170203", _usState.userID, "03"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                }
                if (SysData.HasThisQX("170203", _usState.userID, "04"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                }
                if (SysData.HasThisQX("170203", _usState.userID, "05"))
                {
                    //删除
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;

                }
                #endregion
            }
        }

    }
}