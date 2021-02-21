using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class JS_Add : System.Web.UI.Page
    {
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
            //cpage = pg_fy.CurrentPage;
            //pg_fy.NumPerPage = _usState.C_SB_DH;
            //psize = _usState.C_SB_TX;
            if (!IsPostBack)
            {
               
            }

        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
           string jsmc = tbx_jsmc.Text.ToString();
            string bz = tbx_bz.Text.ToString();
            string czxx = "位置：后台管理->角色管理->添加  角色名称：" + jsmc + "备注" + bz;
            string czfs = "01";
            js.Insert_JS(jsmc,bz,czfs,czxx);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("JS_GL.aspx");
        }
    }
}