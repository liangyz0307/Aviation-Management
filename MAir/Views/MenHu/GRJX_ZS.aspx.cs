using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using CUST.MKG;
using CUST.Sys;
using System.Data;
using Sys;
using CUST.Tools;
using System.Web.UI.WebControls;
using System.Globalization;

namespace CUST.WKG
{
    public partial class GRJX_ZS : System.Web.UI.Page
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
            int count = grjx.Select_GRJX_ZS_Count(_usState.userLoginName);
            pg_fy.TotalRecord = count;
            struct_grjx.p_currentpage = pg_fy.CurrentPage;
            struct_grjx.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = grjx.Select_GRJX_ZS(_usState.userLoginName, struct_grjx.p_pagesize, struct_grjx.p_currentpage);
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        #region 错误信息
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
        #endregion
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Views/MenHu/Sys_Index.aspx", true);
        }

    }
}