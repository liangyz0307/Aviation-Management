using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.Web.MengHu.main
{
    public partial class Sys : System.Web.UI.MasterPage
    {
        private UserState userstate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            lbl_mz.Text = userstate.userXM;
        }
    }
}