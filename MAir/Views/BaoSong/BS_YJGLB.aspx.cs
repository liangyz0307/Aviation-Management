using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sys;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using System.Data;
using System.Globalization;

namespace CUST.WKG
{
    public partial class BS_YJGLB : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YJGL yjgl;
        private Struct_YJGL struct_yjgl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = _usState.C_ZL_ZJ;
            yjgl = new YJGL(_usState);
            struct_yjgl = new Struct_YJGL();
            if (!IsPostBack)
            {
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
                ddltBind();
                bind_Main();
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

        #region  绑定下拉菜单
        protected void ddltBind()
        {
            //值班领导
            DataTable dt = new DataTable();
            dt = yjgl.Select_YGByBMDQ("-1", "-1");
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
            ddlt_zbld.Items.Insert(0, new ListItem("全部", "-1"));
        }
        #endregion

        protected void bind_Main()
        {
            if (!IsPostBack)
            {
                struct_yjgl.p_zbld = ddlt_zbld.SelectedValue.ToString();
            }
            else
            {
                if (ddlt_zbld.SelectedValue.ToString() == "-1")
                {
                    struct_yjgl.p_zbld = "-1";
                }
                else
                {
                    struct_yjgl.p_zbld = ddlt_zbld.SelectedValue.ToString() + ",";
                }
            }
            struct_yjgl.p_userid = _usState.userID;
            if (tbx_kssj.Text.Trim().ToString() == "")
            {
                struct_yjgl.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_yjgl.p_kssj = Convert.ToDateTime(tbx_kssj.Text.Trim().ToString().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {
                struct_yjgl.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_yjgl.p_jssj = Convert.ToDateTime(tbx_jssj.Text.Trim().ToString().ToString());//结束时间
            }

            DataTable dt = new DataTable();
            int count = yjgl.Select_YJGL_Count(struct_yjgl);
            struct_yjgl.p_currentpage = pg_fy.CurrentPage;
            struct_yjgl.p_pagesize = pg_fy.NumPerPage;
            dt = yjgl.Select_YJGL_Pro(struct_yjgl);

            dt.Columns.Add("rqmc");
            DateTime dt_rq = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {
                string zbld = dr["zbld"].ToString();
                string[] zblds = zbld.Split(',');
                dr["zbld"] = "";
                for (int n = 0; n < zblds.Length - 1; n++)
                {
                    dr["zbld"] += yjgl.Select_YGXMbyBH(zblds[n]).Rows[0]["xm"].ToString() + ' ';
                }

                //-----------------------------------------------------------
               /* string xzb = dr["xzb"].ToString();
                string[] xzbs = xzb.Split(',');
                dr["xzb"] = "";
                for (int n = 0; n < xzbs.Length - 1; n++)
                {
                    dr["xzb"] += yjgl.Select_YGXMbyBH(xzbs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/
                string[] Array_xzb = dr["xzb"].ToString().Split(',');
                dr["xzb"] = "";
                foreach (string xzb_bh in Array_xzb)
                {
                    dr["xzb"] += yjgl.Select_YGXMbyBH(xzb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }



                /*  string gzdbzr = dr["gzdbzr"].ToString();
                  string[] gzdbzrs = gzdbzr.Split(',');
                  dr["gzdbzr"] = "";
                  for (int n = 0; n < gzdbzrs.Length - 1; n++)
                  {
                      dr["gzdbzr"] += yjgl.Select_YGXMbyBH(gzdbzrs[n]).Rows[0]["xm"].ToString() + ' ';
                  }*/

                string[] Array_gzdbzr = dr["gzdbzr"].ToString().Split(',');
                dr["gzdbzr"] = "";
                foreach (string gzdbzr_bh in Array_gzdbzr)
                {
                    dr["gzdbzr"] += yjgl.Select_YGXMbyBH(gzdbzr_bh.ToString()).Rows[0][0].ToString() + ' ';

                }

             /*   string ttzb = dr["ttzb"].ToString();
                string[] ttzbs = ttzb.Split(',');
                dr["ttzb"] = "";
                for (int n = 0; n < ttzbs.Length - 1; n++)
                {
                    dr["ttzb"] += yjgl.Select_YGXMbyBH(ttzbs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_ttzb = dr["ttzb"].ToString().Split(',');
                dr["ttzb"] = "";
                foreach (string ttzb_bh in Array_ttzb)
                {
                    dr["ttzb"] += yjgl.Select_YGXMbyBH(ttzb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }

            /*    string zdzb = dr["zdzb"].ToString();
                string[] zdzbs = zdzb.Split(',');
                dr["zdzb"] = "";
                for (int n = 0; n < zdzbs.Length - 1; n++)
                {
                    dr["zdzb"] += yjgl.Select_YGXMbyBH(zdzbs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_zdzb = dr["zdzb"].ToString().Split(',');
                dr["zdzb"] = "";
                foreach (string zdzb_bh in Array_zdzb)
                {
                    dr["zdzb"] += yjgl.Select_YGXMbyBH(zdzb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }


              /*  string qb = dr["qb"].ToString();
                string[] qbs = qb.Split(',');
                dr["qb"] = "";
                for (int n = 0; n < qbs.Length - 1; n++)
                {
                    dr["qb"] += yjgl.Select_YGXMbyBH(qbs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_qb = dr["qb"].ToString().Split(',');
                dr["qb"] = "";
                foreach (string qb_bh in Array_qb)
                {
                    dr["qb"] += yjgl.Select_YGXMbyBH(qb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }

                /*     string tddb = dr["tddb"].ToString();
                     string[] tddbs = tddb.Split(',');
                     dr["tddb"] = "";
                     for (int n = 0; n < tddbs.Length - 1; n++)
                     {
                         dr["tddb"] += yjgl.Select_YGXMbyBH(tddbs[n]).Rows[0]["xm"].ToString() + ' ';
                     }*/

                string[] Array_tddb = dr["tddb"].ToString().Split(',');
                dr["tddb"] = "";
                foreach (string tddb_bh in Array_tddb)
                {
                    dr["tddb"] += yjgl.Select_YGXMbyBH(tddb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }

             /*   string tx = dr["tx"].ToString();
                string[] txs = tx.Split(',');
                dr["tx"] = "";
                for (int n = 0; n < txs.Length - 1; n++)
                {
                    dr["tx"] += yjgl.Select_YGXMbyBH(txs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_tx = dr["tx"].ToString().Split(',');
                dr["tx"] = "";
                foreach (string tx_bh in Array_tx)
                {
                    dr["tx"] += yjgl.Select_YGXMbyBH(tx_bh.ToString()).Rows[0][0].ToString() + ' ';

                }



             /*   string dh = dr["dh"].ToString();
                string[] dhs = dh.Split(',');
                dr["dh"] = "";
                for (int n = 0; n < dhs.Length - 1; n++)
                {
                    dr["dh"] += yjgl.Select_YGXMbyBH(dhs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_dh = dr["dh"].ToString().Split(',');
                dr["dh"] = "";
                foreach (string dh_bh in Array_dh)
                {
                    dr["dh"] += yjgl.Select_YGXMbyBH(dh_bh.ToString()).Rows[0][0].ToString() + ' ';

                }

           /*     string bt = dr["bt"].ToString();
                string[] bts = bt.Split(',');
                dr["bt"] = "";
                for (int n = 0; n < bts.Length - 1; n++)
                {
                    dr["bt"] += yjgl.Select_YGXMbyBH(bts[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_bt = dr["bt"].ToString().Split(',');
                dr["bt"] = "";
                foreach (string bt_bh in Array_bt)
                {
                    dr["bt"] += yjgl.Select_YGXMbyBH(bt_bh.ToString()).Rows[0][0].ToString() + ' ';

                }

             /*   string qxjw = dr["qxjw"].ToString();
                string[] qxjws = qxjw.Split(',');
                dr["qxjw"] = "";
                for (int n = 0; n < qxjws.Length - 1; n++)
                {
                    dr["qxjw"] += yjgl.Select_YGXMbyBH(qxjws[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_qxjw = dr["qxjw"].ToString().Split(',');
                dr["qxjw"] = "";
                foreach (string qxjw_bh in Array_qxjw)
                {
                    dr["qxjw"] += yjgl.Select_YGXMbyBH(qxjw_bh.ToString()).Rows[0][0].ToString() + ' ';

                }


            /*    string qxgc = dr["qxgc"].ToString();
                string[] qxgcs = qxgc.Split(',');
                dr["qxgc"] = "";
                for (int n = 0; n < qxgcs.Length - 1; n++)
                {
                    dr["qxgc"] += yjgl.Select_YGXMbyBH(qxgcs[n]).Rows[0]["xm"].ToString() + ' ';
                }
*/
                string[] Array_qxgc = dr["qxgc"].ToString().Split(',');
                dr["qxgc"] = "";
                foreach (string qxgc_bh in Array_qxgc)
                {
                    dr["qxgc"] += yjgl.Select_YGXMbyBH(qxgc_bh.ToString()).Rows[0][0].ToString() + ' ';

                }


             /*   string qxyb = dr["qxyb"].ToString();
                string[] qxybs = qxyb.Split(',');
                dr["qxyb"] = "";
                for (int n = 0; n < qxybs.Length - 1; n++)
                {
                    dr["qxyb"] += yjgl.Select_YGXMbyBH(qxybs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/

                string[] Array_qxyb = dr["qxyb"].ToString().Split(',');
                dr["qxyb"] = "";
                foreach (string qxyb_bh in Array_qxyb)
                {
                    dr["qxyb"] += yjgl.Select_YGXMbyBH(qxyb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }

                dt_rq = Convert.ToDateTime(dr["rq"].ToString());
                dr["rqmc"] = string.Format("{0:yyyy-MM-dd}", dt_rq);
            }

            ///绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_YJGLB_Add.aspx", true);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                Server.Transfer("../BaoSong/BS_YJGLB_Edit.aspx?id=" + id);
            }
            if (e.CommandName == "Delete")
            {
                string p_czfs = "04";
                string p_czxx = "位置：值班表->值班表管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                try
                {
                    yjgl.Delete_YJGL(id, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('删除成功');location.href='BS_YJGLB.aspx';</script>");
                    bind_Main();
                }
                catch (EMException ex)
                {
                    Response.Write(EMException.ShowErrorScript(ex));
                    return;
                }
            }
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}