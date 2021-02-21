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
    public partial class AQXX_Detail : System.Web.UI.Page
    {
        private FXY fxy;
        private UserState _usState;
        string bsbh = "";
        private DataTable dt_dateail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            fxy = new FXY(_usState);
            if (!IsPostBack)
            {
                select_detail();
            }
           
         
        }
        private void select_detail()
        {

            bsbh = Request.Params["bsbh"].ToString();
            dt_dateail= fxy.Select_FXY_Detail(bsbh);
            lbl_bsyg.Text=dt_dateail.Rows[0]["xm"].ToString();
            lbl_bsgw.Text=SysData.GWByKey( dt_dateail.Rows[0]["bsgw"].ToString()).mc;
            lbl_bssj.Text = Convert.ToDateTime(dt_dateail.Rows[0]["bssj"].ToString()).ToString("yyyy-MM-dd");
            lbl_zrbm.Text = SysData.GWByKey(dt_dateail.Rows[0]["zrbm"].ToString()).mc;
            lbl_bz.Text = dt_dateail.Rows[0]["bz"].ToString();
            lbl_tqcz.Text = dt_dateail.Rows[0]["tqcz"].ToString();
            lbl_gzqk.Text = dt_dateail.Rows[0]["gzqk"].ToString();
            lbl_sjqk.Text = dt_dateail.Rows[0]["sjqk"].ToString();
            lbl_sbyxqk.Text = dt_dateail.Rows[0]["sbyxqk"].ToString();
            lbl_sfsj.Text = Convert.ToDateTime(dt_dateail.Rows[0]["sfsj"]).ToString("yyyy-MM-dd");
            lbl_zrdw.Text=dt_dateail.Rows[0]["zrdw"].ToString();
            lbl_fzr.Text= dt_dateail.Rows[0]["fzr"].ToString();//负责人
            lbl_bgsj.Text = Convert.ToDateTime(dt_dateail.Rows[0]["bgsj"]).ToString("yyyy-MM-dd");
            //lbl_yjcs.Text=dt_dateail.Rows[0]["yjcs"].ToString();
            //lbl_zrbm.Text=SysData.BMByKey( dt_dateail.Rows[0]["zrbm"].ToString()).mc;
            //lbl_zrr.Text = dt_dateail.Rows[0]["zrrxm"].ToString();
            //lbl_zt.Text=SysData.ZTDMByKey( dt_dateail.Rows[0]["zt"].ToString()).mc;
            lbl_bhyy.Text=dt_dateail.Rows[0]["bhyy"].ToString();
            //lbl_bz.Text = dt_dateail.Rows[0]["bz"].ToString();
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AnQuan/AQXX.aspx", true);
        }
    }
}