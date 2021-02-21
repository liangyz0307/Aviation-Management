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
    public partial class BS_YJGLB_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private YJGL yjgl;
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
            yjgl = new YJGL(_usState);
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
            dt_detail = yjgl.Select_YJGL_Detail(id);
            lbl_rq.Text = dt_detail.Rows[0]["rq"].ToString();//日期
            lbl_ttzbdh.Text = dt_detail.Rows[0]["ttzbdh"].ToString();
            lbl_btdh.Text = dt_detail.Rows[0]["btdh"].ToString();
            lbl_qxgczbdh.Text = dt_detail.Rows[0]["qxgczbdh"].ToString();
            lbl_qxybzbdh.Text = dt_detail.Rows[0]["qxybzbdh"].ToString();
            lbl_dhddh.Text = dt_detail.Rows[0]["dhddh"].ToString();
            lbl_zdzbdh.Text = dt_detail.Rows[0]["zdzbdh"].ToString();
            lbl_xlsdh.Text = dt_detail.Rows[0]["xlsdh"].ToString();
            lbl_tdzbdh.Text = dt_detail.Rows[0]["tdzbdh"].ToString();
            string zbld = dt_detail.Rows[0]["zbld"].ToString();
            string[] zblds = zbld.Split(',');
            for (int n = 0; n < zblds.Length - 1; n++)
            {
                lbl_zbld.Text += yjgl.Select_YGXMbyBH(zblds[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string xzb = dt_detail.Rows[0]["xzb"].ToString();
            string[] xzbs = xzb.Split(',');
            for (int n = 0; n < xzbs.Length - 1; n++)
            {
                lbl_xzb.Text += yjgl.Select_YGXMbyBH(xzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string gzdbzr = dt_detail.Rows[0]["gzdbzr"].ToString();
            string[] gzdbzrs = gzdbzr.Split(',');
            for (int n = 0; n < gzdbzrs.Length - 1; n++)
            {
                lbl_gzdbzr.Text += yjgl.Select_YGXMbyBH(gzdbzrs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string ttzb = dt_detail.Rows[0]["ttzb"].ToString();
            string[] ttzbs = ttzb.Split(',');
            for (int n = 0; n < ttzbs.Length - 1; n++)
            {
                lbl_ttzb.Text += yjgl.Select_YGXMbyBH(ttzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string zdzb = dt_detail.Rows[0]["zdzb"].ToString();
            string[] zdzbs = zdzb.Split(',');
            for (int n = 0; n < zdzbs.Length - 1; n++)
            {
                lbl_zdzb.Text += yjgl.Select_YGXMbyBH(zdzbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string qb = dt_detail.Rows[0]["qb"].ToString();
            string[] qbs = qb.Split(',');
            for (int n = 0; n < qbs.Length - 1; n++)
            {
                lbl_qb.Text += yjgl.Select_YGXMbyBH(qbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string tddb = dt_detail.Rows[0]["tddb"].ToString();
            string[] tddbs = tddb.Split(',');
            for (int n = 0; n < tddbs.Length - 1; n++)
            {
                lbl_tddb.Text += yjgl.Select_YGXMbyBH(tddbs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string tx = dt_detail.Rows[0]["tx"].ToString();
            string[] txs = tx.Split(',');
            for (int n = 0; n < txs.Length - 1; n++)
            {
                lbl_tx.Text += yjgl.Select_YGXMbyBH(txs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string dh = dt_detail.Rows[0]["dh"].ToString();
            string[] dhs = dh.Split(',');
            for (int n = 0; n < dhs.Length - 1; n++)
            {
                lbl_dh.Text += yjgl.Select_YGXMbyBH(dhs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string bt = dt_detail.Rows[0]["bt"].ToString();
            string[] bts = bt.Split(',');
            for (int n = 0; n < bts.Length - 1; n++)
            {
                lbl_bt.Text += yjgl.Select_YGXMbyBH(bts[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string qxjw = dt_detail.Rows[0]["qxjw"].ToString();
            string[] qxjws = qxjw.Split(',');
            for (int n = 0; n < qxjws.Length - 1; n++)
            {
                lbl_qxjw.Text += yjgl.Select_YGXMbyBH(qxjws[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string qxgc = dt_detail.Rows[0]["qxgc"].ToString();
            string[] qxgcs = qxgc.Split(',');
            for (int n = 0; n < qxgcs.Length - 1; n++)
            {
                lbl_qxgc.Text += yjgl.Select_YGXMbyBH(qxgcs[n]).Rows[0]["xm"].ToString() + ' ';
            }
            string qxyb = dt_detail.Rows[0]["qxyb"].ToString();
            string[] qxybs = qxyb.Split(',');
            for (int n = 0; n < qxybs.Length - 1; n++)
            {
                lbl_qxyb.Text += yjgl.Select_YGXMbyBH(qxybs[n]).Rows[0]["xm"].ToString() + ' ';
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_YJGLB.aspx", true);
        }
    }
}