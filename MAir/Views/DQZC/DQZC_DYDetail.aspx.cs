using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;

namespace CUST.WKG.MenHu.main
{
    public partial class DQZC_DYDetail : System.Web.UI.Page
    {
        public DQZC dqzc;
        public ODQZC.Struct_DY struct_dy;
        private UserState _usState;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dqzc = new DQZC(_usState);
            if (!IsPostBack)
            {
                select();
            }
        }
        private void select()
        {
            DataTable dt = new DataTable();
            struct_dy.p_bh = Request.QueryString["bh"];
            dt = dqzc.Detail_DY(struct_dy); 
            lbl_xm.Text = dt.Rows[0]["xm"].ToString();
            lbl_zzmm.Text = SysData.ZZMMByKey(dt.Rows[0]["zzmmdm"].ToString()).mc;
            lbl_dzzmc.Text = SysData.DZZMCByKey(dt.Rows[0]["dzzmc"].ToString()).mc;
            lbl_jcdzbmc.Text =SysData.JCDZBMCByKey( dt.Rows[0]["jcdzbmc"].ToString()).mc;
            lbl_dxzmc.Text = SysData.DXZMCByKey(dt.Rows[0]["dxzmc"].ToString()).mc;
            DateTime dt_rdsj = new DateTime();
            if (dt.Rows[0]["rdsj"].ToString().Trim() == "")
            {

            }
            else
            {
                dt_rdsj = Convert.ToDateTime(dt.Rows[0]["rdsj"].ToString().Trim());
            }
            lbl_rdsj.Text = string.Format("{0:yyyy-MM-dd }", dt_rdsj);  
            lbl_dnzw.Text = dt.Rows[0]["dnzw"].ToString();
            lbl_bz.Text = dt.Rows[0]["bz"].ToString();
            lbl_ygxs.Text = SysData.YGXSByKey(dt.Rows[0]["ygxs"].ToString()).mc;
            lbl_bh.Text = dt.Rows[0]["bh"].ToString();
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DQZC_DYGL.aspx");
        }
    }
}