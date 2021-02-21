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
    public partial class BMZFA_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private GRJX grjx;
        private PCFA pcfa;
        public string zfabh, zfamc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            grjx = new GRJX(_usState);
            pcfa = new PCFA(_usState);
            zfabh = Request.Params["zfabh"].ToString();
            zfamc = Request.Params["zfamc"].ToString();
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Bind()
        {
            lbl_zfabh.Text = zfabh;
            lbl_zfamc.Text = zfamc;
            //绑定分页数据源  
            DataTable dt = pcfa.Select_BMZFA_PCFA(zfabh).Tables[0];
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Server.Transfer("BMZFA.aspx");
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
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            string pcfabh = content[0];
            string pcfamc = content[1];

            if (e.CommandName == "Delete")
            {
                //删除一条评测方案，由于权重关联，将删除该评测方案所在的总方案里的其他评测方案，即删除该条总方案
                pcfa.Delete_BMZFA_ByZFABH(zfabh);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
            }
            Bind();
        }
    }
}