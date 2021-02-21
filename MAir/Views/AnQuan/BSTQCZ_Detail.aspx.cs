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
    public partial class BSTQCZ_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private TQCZ tqcz;
        string bsbh = "";
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tqcz = new TQCZ(_usState);
            dt_detail = new DataTable();
            if (!IsPostBack)
            {
                select_detail();
                
            }

        }
        protected void select_detail()
        {
            bsbh = Request.Params["bsbh"].ToString();
            dt_detail = tqcz.Select_TQCZ_Detail(bsbh);
            lbl_bsyg.Text = dt_detail.Rows[0]["bsrxm"].ToString();
            lbl_bsgw.Text =SysData.GWByKey( dt_detail.Rows[0]["bsgw"].ToString()).mc;
            lbl_bssj.Text =Convert.ToDateTime( dt_detail.Rows[0]["bssj"].ToString()).ToString("yyyy-MM-dd");
            lbl_gzqk.Text = dt_detail.Rows[0]["gzqk"].ToString();
            lbl_ygqk.Text = dt_detail.Rows[0]["sjqk"].ToString();
            lbl_yxqk.Text = dt_detail.Rows[0]["sbyxqk"].ToString();
            lbl_sfsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["sfsj"].ToString()).ToString("yyyy-MM-dd");
            lbl_zrdw.Text =SysData.GWByKey( dt_detail.Rows[0]["zrdw"].ToString()).mc;
            lbl_zrr.Text = dt_detail.Rows[0]["fzrxm"].ToString();
            lbl_bgsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bgsj"].ToString()).ToString("yyyy-MM-dd");
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            lbl_zt.Text = SysData.ZTDMByKey( dt_detail.Rows[0]["zt"].ToString()).mc;
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();
            lbl_zrdw.Text = SysData.BMByKey(dt_detail.Rows[0]["zrdw"].ToString()).mc;
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AnQuan/BS_TQCZ.aspx", true);
        }
    }
}