using CUST;
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
    public partial class LL_Detail : System.Web.UI.Page

    {

        private UserState _usState;
        public int cpage;
        public int psize;
        private string ygbh;
        private YGLL ygll;
        //private Struct_YGLL struct_ygll;
        //private DataTable dt_detail;
       public string  filepath;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygll = new YGLL(_usState);
            if (!IsPostBack)
            {
                ygbh = Request.Params["ygbh"].ToString();
                bind_Main();

            }
        }
        private void bind_Main()
        {


            DataTable dt = ygll.Select_YGLL_BYBH(ygbh,_usState.userID);
          
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("LLGL.aspx");
        }

       
    }
}