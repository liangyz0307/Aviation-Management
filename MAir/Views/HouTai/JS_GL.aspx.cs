using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class JS_GL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState userstate;
        private YHJS js;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new YHJS(userstate);

            cpage = pg_fy.CurrentPage;
            //pg_fy.NumPerPage = _usState.C_SB_DH;
            //psize = _usState.C_SB_TX;
            if (!IsPostBack)
            {
                bind_select();
            }

        }
        private void bind_select()
        {
            string bz = tbx_ms.Text.ToString();
            string jsmc = tbx_jsmc.Text.ToString();

            int count = Convert.ToInt32(js.Select_YHJS_Count(jsmc, bz).Rows[0][0].ToString());
            pg_fy.TotalRecord = count;
            string p_currentpage = Convert.ToString(pg_fy.CurrentPage);
            string p_pagesize = Convert.ToString(pg_fy.NumPerPage);
            DataTable dt = js.Select_YHJS_Pro(jsmc, bz, p_currentpage, p_pagesize);
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_select();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/JS_Add.aspx");

        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_select();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Server.Transfer("JS_Edit.aspx?jsdm=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Delete")
            {
                string jsdm = e.CommandArgument.ToString();
                string czxx = "位置：后台管理->角色管理->删除 角色代码：" + jsdm;
                string czfs = "03";
                js.Delete_JS(jsdm,czfs,czxx);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
            }
            if (e.CommandName == "Fenpei")
            {
                Response.Redirect("JSQX_PZ.aspx?jsdm=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Shouquan")
            {
                Response.Redirect("BMQX_PZ.aspx?jsdm=" + e.CommandArgument.ToString());
            }

            bind_select();
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
    }
}