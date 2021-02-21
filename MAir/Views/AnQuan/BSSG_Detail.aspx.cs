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
    public partial class BSSG_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private SG sg;
        private static string bsbh;
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dt = new DataTable();
            sg = new SG(_usState);
            if (!IsPostBack)
            {
               
                select_detail();
            }
        }
        private void select_detail()
        {
            bsbh = Request.QueryString["bsbh"];
            dt=sg.Select_SG_Detail(bsbh);
            lbl_bsyg.Text = dt.Rows[0]["bsrxm"].ToString();
            lbl_bsgw.Text=SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
            lbl_bssj.Text = Convert.ToDateTime(dt.Rows[0]["bssj"].ToString()).ToString("yyyy-MM-dd");
            lbl_sfsj.Text = Convert.ToDateTime(dt.Rows[0]["sfsj"].ToString()).ToString("yyyy-MM-dd");
            lbl_sgfzr.Text = dt.Rows[0]["fzrxm"].ToString();
            lbl_sgxq.Text=dt.Rows[0]["sgxq"].ToString();
            lbl_bz.Text = dt.Rows[0]["bz"].ToString();
            lbl_zt.Text =SysData.ZTDMByKey( dt.Rows[0]["zt"].ToString()).mc;
            lbl_bhyy.Text =dt.Rows[0]["bhyy"].ToString();
           
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AnQuan/BS_SG.aspx", true);
        }
    }
}