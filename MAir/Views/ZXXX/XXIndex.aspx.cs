using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class XXIndex : System.Web.UI.Page
    {
        private UserState _usState;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            lbl_yhm.Text = _usState.userXM;
        }

        protected void btn_tc_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../loginAdmin.aspx", true);
            Session.Clear();
            Session["YGState"] = null;
        }
    }
}