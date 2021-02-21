using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using Sys;

namespace CUST.WKG
{
    public partial class BS_THGLB_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private THGL thgl;
        private Struct_THGL struct_thgl;
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
            thgl = new THGL(_usState);
            struct_thgl = new Struct_THGL();
            id = Convert.ToInt32(Request.Params["id"].ToString());
            if (!IsPostBack)
            {
                select_detail();
            }
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

        protected void select_detail()
        {
            dt_detail = thgl.Select_THGL_Detail(id);
            lbl_rq.Text = dt_detail.Rows[0]["rq"].ToString();//日期
            lbl_ttzbdh.Text = dt_detail.Rows[0]["ttzbdh"].ToString();
            lbl_zblddh.Text = dt_detail.Rows[0]["zblddh"].ToString();
            lbl_zdzbdh.Text = dt_detail.Rows[0]["zdzbdh"].ToString();
            lbl_tdzbdh.Text = dt_detail.Rows[0]["tdzbdh"].ToString();
            lbl_qxzbdh.Text = dt_detail.Rows[0]["qxzbdh"].ToString();
            string zbld = dt_detail.Rows[0]["zbld"].ToString();
            string[] zblds = zbld.Split(',');
            for (int n = 0; n < zblds.Length - 1; n++)
            {
                lbl_zbld.Text += thgl.Select_YGXMbyBH(zblds[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string ttzb = dt_detail.Rows[0]["ttzb"].ToString();
            string[] ttzbs = ttzb.Split(',');
            for (int n = 0; n < ttzbs.Length - 1; n++)
            {
                lbl_ttzb.Text += thgl.Select_YGXMbyBH(ttzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string zdzb = dt_detail.Rows[0]["zdzb"].ToString();
            string[] zdzbs = zdzb.Split(',');
            for (int n = 0; n < zdzbs.Length - 1; n++)
            {
                lbl_zdzb.Text += thgl.Select_YGXMbyBH(zdzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string tdzb = dt_detail.Rows[0]["tdzb"].ToString();
            string[] tdzbs = tdzb.Split(',');
            for (int n = 0; n < tdzbs.Length - 1; n++)
            {
                lbl_tdzb.Text += thgl.Select_YGXMbyBH(tdzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string gczb = dt_detail.Rows[0]["gczb"].ToString();
            string[] gczbs = gczb.Split(',');
            for (int n = 0; n < gczbs.Length - 1; n++)
            {
                lbl_gczb.Text += thgl.Select_YGXMbyBH(gczbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string ybzb = dt_detail.Rows[0]["ybzb"].ToString();
            string[] ybzbs = ybzb.Split(',');
            for (int n = 0; n < ybzbs.Length - 1; n++)
            {
                lbl_ybzb.Text += thgl.Select_YGXMbyBH(ybzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_THGLB.aspx", true);
        }
    }
}