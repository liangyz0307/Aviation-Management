using CUST.MKG;
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
    public partial class BMJXZF_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private GRJX grjx;
        public string bmdm, zfabh;
        private Struct_GRJX struct_grjx;
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
            grjx = new GRJX(_usState);
            struct_grjx = new Struct_GRJX();
            bmdm = Request.QueryString.Get("bmdm").ToString();
            zfabh = Request.QueryString.Get("zfabh").ToString();
            if (!IsPostBack)
            {
                Select_Detail();
            }
        }
        private void Select_Detail()
        {
            bmdm = Request.QueryString.Get("bmdm").ToString();
            zfabh = Request.QueryString.Get("zfabh").ToString();
            DataTable dt_detail = grjx.Select_BMJX_JBXX(bmdm, zfabh);
            lbl_bmbh.Text = bmdm;
            lbl_bmmc.Text = dt_detail.Rows[0]["bmmc"].ToString();
            lbl_zfabh.Text = zfabh;
            lbl_zfamc.Text = dt_detail.Rows[0]["zfamc"].ToString();

            int count = grjx.Select_BMJX_Detail_MX_COUNT(bmdm, zfabh);
            pg_fy.TotalRecord = count;
            struct_grjx.p_bmdm = bmdm;
            struct_grjx.p_zfabh = zfabh;
            struct_grjx.p_currentpage = pg_fy.CurrentPage;
            struct_grjx.p_pagesize = pg_fy.NumPerPage;
            //查询该员工名下的该总方案下的评测方案的详细信息
            DataTable dt = grjx.Select_BMJX_Detail_MX(struct_grjx);
            this.dlt_zfa.DataSource = dt.DefaultView;
            this.dlt_zfa.DataBind();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMJXZF.aspx", true);
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            Select_Detail();
        }
    }
}