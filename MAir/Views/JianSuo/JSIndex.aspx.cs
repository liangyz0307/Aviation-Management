using System;
using CUST.Sys;
using Sys;

namespace CUST.WKG
{
    public partial class JSIndex : System.Web.UI.Page
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
            Response.Redirect("../../Login.aspx", true);
            Session.Clear();
            Session["UserState"] = null;
        }
    }
     
    }
