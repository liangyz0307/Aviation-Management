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

namespace MAir.Views.AnQuan
{
    public partial class ZYBS_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private ZYBS zybs;
        private string bsbh = "";
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dt_detail = new DataTable();
            zybs = new ZYBS(_usState);
            if (!IsPostBack)
            {
                select_zybs();
            }
        }
        protected void select_zybs()
        { 
            bsbh=Request.Params["bsbh"].ToString();
            dt_detail = zybs.SelectBS_ZYBS_Detail(bsbh);
            lbl_bsyg.Text = dt_detail.Rows[0]["xm"].ToString();
            lbl_bsgw.Text =SysData.GWByKey( dt_detail.Rows[0]["bsgw"].ToString()).mc;
            lbl_bssj.Text =Convert .ToDateTime( dt_detail.Rows[0]["bssj"].ToString()).ToString("yyyy-MM-dd");
            lbl_bslx.Text =SysData.BSLXByKey( dt_detail.Rows[0]["bslx"].ToString()).mc;
            lbl_bsms.Text = dt_detail.Rows[0]["bsms"].ToString();
            lbl_jjfa.Text = dt_detail.Rows[0]["jjfa"].ToString();
            lbl_zt.Text =SysData.ZTDMByKey( dt_detail.Rows[0]["zt"].ToString()).mc;
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZYBSGL.aspx", true);
        }
    }
}