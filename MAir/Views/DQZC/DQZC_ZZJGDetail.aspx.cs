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
    public partial class DQZC_ZZJGDetail : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private ZZJG zzjg;
        private Struct_ZZJG_CX strcut_zzjg;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string lx = Request.Params["lx"];
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_LL;
            psize = _usState.C_YG_LL;
            zzjg = new ZZJG(_usState);
            strcut_zzjg = new Struct_ZZJG_CX();
            if (!IsPostBack)
            {
                bind_Main();
            }
        }
    
        private void bind_Main()
        {
            strcut_zzjg.lx = Request.Params["lx"];
            int count = zzjg.Select_ZZJG_TPCount(strcut_zzjg);
            pg_fy.TotalRecord = count;
            strcut_zzjg.p_currentpage = pg_fy.CurrentPage;
            strcut_zzjg.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = zzjg.Select_ZZJG_TP(strcut_zzjg).Tables[0];
            dt.Columns.Add("rs");
            foreach (DataRow dr in dt.Rows)
            {
                int i = 0;
                strcut_zzjg.p_jcdzbmc = dt.Rows[i]["jcdzbmc"].ToString();
                dr["rs"] = zzjg.Select_ZZJG_TPRS(strcut_zzjg);
            }
            

                //绑定分页数据源  
                this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        //分页
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        //错误信息
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
           
            bind_Main();
        }
      
    
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }
    }
}