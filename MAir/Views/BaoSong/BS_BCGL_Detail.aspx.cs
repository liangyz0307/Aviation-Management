using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BS_BCGL_Detail : System.Web.UI.Page
    {
        private UserState _usState;

        private BCGL bcgl;
        private Struct_BCGL struct_bcgl;
        //  private string p_id;
        private int id;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            bcgl = new BCGL(_usState);
            struct_bcgl = new Struct_BCGL();
            id = Convert.ToInt32(Request.QueryString["zbld"]);
            if (!IsPostBack)
            {
                select_detail();
            }
        }
        protected void select_detail()
        {
            dt_detail = bcgl.Select_BCGL_Detail(id);
            lbl_rq.Text = dt_detail.Rows[0]["rq"].ToString();//日期
            lbl_zblddh.Text = dt_detail.Rows[0]["ldzbdh"].ToString();
            lbl_ttzbdh.Text = dt_detail.Rows[0]["ttzbdh"].ToString();
            lbl_ffzbdh.Text = dt_detail.Rows[0]["ffzbdh"].ToString();
            lbl_tdzbdh.Text = dt_detail.Rows[0]["tdzbdh"].ToString();
            lbl_gczbdh.Text =  dt_detail.Rows[0]["gczbdh"] .ToString( );
            lbl_ybzbdh.Text = dt_detail.Rows[0]["ybzbdh"].ToString();
            string zbld = dt_detail.Rows[0]["zbld"].ToString();
            string[] zblds = zbld.Split(',');
            for (int n = 0; n < zblds.Length - 1; n++)
            {
                lbl_zbld.Text += bcgl.Select_YGXMbyBH(zblds[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string ttzb = dt_detail.Rows[0]["ttzb"].ToString();
            string[] ttzbs = ttzb.Split(',');
            for (int n = 0; n < ttzbs.Length - 1; n++)
            {
                lbl_ttzb.Text += bcgl.Select_YGXMbyBH(ttzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string ffzb = dt_detail.Rows[0]["ffzb"].ToString();
            string[] ffzbs = ffzb.Split(',');
            for (int n = 0; n < ffzbs.Length - 1; n++)
            {
                lbl_ffzb.Text += bcgl.Select_YGXMbyBH(ffzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string tdzb = dt_detail.Rows[0]["tdzb"].ToString();
            string[] tdzbs = tdzb.Split(',');
            for (int n = 0; n < tdzbs.Length - 1; n++)
            {
                lbl_tdzb.Text += bcgl.Select_YGXMbyBH(tdzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string gczb = dt_detail.Rows[0]["gczb"].ToString();
            string[] gczbs = gczb.Split(',');
            for (int n = 0; n < gczbs.Length - 1; n++)
            {
                lbl_gczb.Text += bcgl.Select_YGXMbyBH(gczbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string ybzb = dt_detail.Rows[0]["ybzb"].ToString();
            string[] ybzbs = ybzb.Split(',');
            for (int n = 0; n < ybzbs.Length - 1; n++)
            {
                lbl_ybzb.Text += bcgl.Select_YGXMbyBH(ybzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_BCGL.aspx", true);
        }
    }
}