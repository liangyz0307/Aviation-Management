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

namespace CUST.WKG
{
    public partial class BMJX_ZS : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private GRJX grjx;
        private Struct_GRJX struct_grjx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_JL;
            psize = _usState.C_YG_JL;
            grjx = new GRJX(_usState);
            struct_grjx = new Struct_GRJX();
            if (!IsPostBack)
            {
                bind_Main();
            }
        }
        private void bind_Main()
        {
            //查询员工的绩效个数
            int count = grjx.Select_BMJX_ZS_Count(_usState.userBMDM);
            pg_fy.TotalRecord = count;
            struct_grjx.p_currentpage = pg_fy.CurrentPage;
            struct_grjx.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = grjx.Select_BMJX_ZS(_usState.userBMDM, struct_grjx.p_pagesize, struct_grjx.p_currentpage);
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
    }
}