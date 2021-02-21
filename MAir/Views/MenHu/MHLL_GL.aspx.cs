using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;

namespace CUST.WKG.main
{
    public partial class MHLL_GL : System.Web.UI.Page
    {
        private UserState userState;
        public JS js;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new JS(userState);
            if (!IsPostBack)
            {
                select();
            }
        }
        protected void select()
        {
            string ygbh = userState.userLoginName;
            DataTable dt = new DataTable();
            dt = js.Select_JS_YGLL(ygbh).Tables[0];
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
        }
    }
}