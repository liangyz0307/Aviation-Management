using CUST.MKG;
using CUST.Sys;
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
    public partial class GRJXZF_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private GRJX grjx;
        public string ygbh, xm, bmmc, gwmc, zfabh, zfamc;
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
            ygbh = Request.QueryString.Get("ygbh").ToString();
            zfabh = Request.QueryString.Get("zfabh").ToString();
            if (!IsPostBack)
            {
                Select_Detail();
            }
        }
        private void Select_Detail()
        {

            ygbh = Request.QueryString.Get("ygbh").ToString();
            zfabh = Request.QueryString.Get("zfabh").ToString();
            DataTable dt_detail = grjx.Select_GRJX_JBXX(ygbh, zfabh);
            lbl_ygbh.Text = dt_detail.Rows[0]["ygbh"].ToString();
            lbl_xm.Text = dt_detail.Rows[0]["ygxm"].ToString(); 
            lbl_bmmc.Text = dt_detail.Rows[0]["bmmc"].ToString(); 
            lbl_gwmc.Text = dt_detail.Rows[0]["gwmc"].ToString(); 
            lbl_zfabh.Text = dt_detail.Rows[0]["zfabh"].ToString(); 
            lbl_zfamc.Text = dt_detail.Rows[0]["zfamc"].ToString();

            int count = grjx.Select_GRJX_Detail_MX_COUNT(ygbh, zfabh);
            pg_fy.TotalRecord = count;
            struct_grjx.p_ygbh = ygbh;
            struct_grjx.p_zfabh = zfabh;
            struct_grjx.p_currentpage = pg_fy.CurrentPage;
            struct_grjx.p_pagesize = pg_fy.NumPerPage;
            //查询该员工名下的该总方案下的评测方案的详细信息
            DataTable dt = grjx.Select_GRJX_Detail_MX(struct_grjx);
            this.dlt_zfa.DataSource = dt.DefaultView;
            this.dlt_zfa.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            Select_Detail();
        }
        //返回
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/GRJXZF.aspx", true);
        }
    }
}