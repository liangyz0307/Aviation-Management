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
    public partial class BMZFA : System.Web.UI.Page
    {
        private UserState _usState;
        private PCFA pcfa;
        private Struct_PCFA struct_pcfa;
        public string zfabh;
        public int cpage;
        public int psize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_LL;
            psize = _usState.C_YG_LL;
            pcfa = new PCFA(_usState);
            struct_pcfa = new Struct_PCFA();
            if (!IsPostBack)
            {
                bind_Main();
                show();
            }
        }
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;
            //有个人绩效添加权限
            if (SysData.HasThisBMQX(_usState.userID, "120102"))
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void bind_Main()
        {
            int count = pcfa.Select_BMZFA_Count(struct_pcfa);
            pg_fy.TotalRecord = count;
            struct_pcfa.p_currentpage = pg_fy.CurrentPage;
            struct_pcfa.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = pcfa.Select_BMZFA(struct_pcfa).Tables[0];

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
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
            zfabh = content[0];

            if (e.CommandName == "Delete")
            {
                if (!SysData.HasThisBMQX(_usState.userID, "120104"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限，不能删除！\")</script>");
                    return;
                }
                else
                {
                    pcfa.Delete_BMZFA_ByZFABH(zfabh);
                    //删除总方案，还要删除属于该总方案的评测方案的记录
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }
            }
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMZFA_Add.aspx", true);
        }
    }
}