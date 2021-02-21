using CUST;
using CUST.MKG;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.JXGL
{
    public partial class ZFA_PCFA_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private PCFA pcfa;
        private Struct_PCFA struct_pcfa;
        public string pcfabh,pcfamc;
        private DataTable dt;
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
            pcfabh = Request.Params["pcfabh"].ToString();
            pcfamc = Request.Params["pcfamc"].ToString();
            if (!IsPostBack)
            {
                pcfabh = Request.Params["pcfabh"].ToString();
                Bind();
            }
        }
        protected void Bind()
        {
            lbl_pcfabh.Text = pcfabh;
            lbl_pcfamc.Text = pcfamc;
            //绑定分页数据源 
            dt = pcfa.SELECT_PCFA_BYPCFABH(pcfabh).Tables[0];
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Server.Transfer("ZFA_Detail.aspx");
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

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[1];
            content = e.CommandArgument.ToString().Split('&');
            string pcfabh = content[0];
            if (e.CommandName == "Delete")
            {
                //删除一条评测项，由于权重关联，将删除该评测项所在的评测方案里的其他评测项，即删除该条评测方案
                pcfa.Delete_PCFA_ByPCFABH(pcfabh);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
            }
            Bind();
        }
    }
}