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
    public partial class FAGL_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private PCFA pcfa;
        private Struct_PCFA struct_pcfa;
        public string pcfabh;
        private DataTable dt_detail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            struct_pcfa = new Struct_PCFA();
            pcfa = new PCFA(_usState);
            if (!IsPostBack)
            {
                pcfabh = Request.Params["pcfabh"].ToString();
                select_detail();
            }
        }

        protected void select_detail()
        {
            pcfabh = Request.Params["pcfabh"].ToString();
            dt_detail = pcfa.SELECT_PCFA_BYPCFABH(pcfabh).Tables[0];

            lbl_pcfabh.Text= dt_detail.Rows[0]["pcfabh"].ToString();
            lbl_pcfamc.Text = dt_detail.Rows[0]["pcfamc"].ToString();
            //绑定分页数据源  
            this.Repeater1.DataSource = dt_detail.DefaultView;
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
            Server.Transfer("FAGL.aspx");
        }
    }
}










