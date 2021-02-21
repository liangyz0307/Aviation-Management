using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

namespace CUST.WKG
{
    public partial class SBTZ_Detail : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private Struct_SELECT_COUNT struct_select_count;
        private DataTable dt;

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
            tzsb = new TZSB(_usState);
            struct_tzsb = new Struct_TZSB();

            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {
                bind_select();
            }


        }
        private void bind_select()
        {
            string id = Request.Params["id"].ToString();
            dt = tzsb.Select_TZ_Detail(Convert.ToInt32(id));

            lbl_tzmc.Text = dt.Rows[0]["tzmc"].ToString();
            lbl_sjssbm.Text = SysData.BMByKey(dt.Rows[0]["bmdm"].ToString()).mc;
            lbl_bz.Text = dt.Rows[0]["bdbyy"].ToString();
            lbl_fwxx.Text = dt.Rows[0]["fwxx"].ToString();
            DateTime dt_jgsj = new DateTime();
            dt_jgsj = Convert.ToDateTime(dt.Rows[0]["jgsj"].ToString());
            lbl_jgsj.Text = string.Format("{0:yyyy-MM-dd}", dt_jgsj);

            lbl_lc.Text = dt.Rows[0]["lc"].ToString();
            lbl_jg.Text = dt.Rows[0]["jg"].ToString();

            lbl_fjh.Text = dt.Rows[0]["fjh"].ToString();
            lbl_tzwzxx.Text = dt.Rows[0]["tzwzxx"].ToString();
            lbl_jfsrxlqk.Text = dt.Rows[0]["jfsrxlqk"].ToString();
            lbl_jfzsc.Text = dt.Rows[0]["jfzsc"].ToString();
            lbl_tzwdsfdb.Text = SysData.SFJBByKey( dt.Rows[0]["tzwdsfdb"].ToString()).mc;

            lbl_bhyy.Text = dt.Rows[0]["bhyy"].ToString();//驳回原因

            lbl_lrr.Text = dt.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt.Rows[0]["zsrxm"].ToString();//终审人

            bind_select_crkqd(dt.Rows[0]["jc"].ToString(), dt.Rows[0]["wz"].ToString(), dt.Rows[0]["sblx"].ToString());
        }


        private void bind_select_crkqd(string jc,string wz,string sblx)
        {
            if (sblx.Substring(0, 2) == "01")
            {
                struct_tzsb.p_wz = wz;
                struct_tzsb.p_jc = jc;
                struct_tzsb.p_sblx=sblx;
                int count = tzsb.Select_TXSBQD_Count(struct_tzsb);
                pg_fy.TotalRecord = count;
                struct_tzsb.p_currentpage = pg_fy.CurrentPage;
                struct_tzsb.p_pagesize = pg_fy.NumPerPage;
                DataTable dt_qd = tzsb.Select_TXSBQD(struct_tzsb).Tables[0];

                dt_qd.Columns.Add("sbzl");
                foreach (DataRow dr in dt_qd.Rows)
                {
                    dr["sbzl"] = "通信设备";
                }

                ////绑定分页数据源  
                this.Repeater1.DataSource = dt_qd.DefaultView;
                this.Repeater1.DataBind();
            }
            if (sblx.Substring(0, 2) == "02")
            {
                struct_tzsb.p_wz = wz;
                struct_tzsb.p_jc = jc;
                struct_tzsb.p_sblx = sblx;
                int count = tzsb.Select_DHSBQD_Count(struct_tzsb);
                pg_fy.TotalRecord = count;
                struct_tzsb.p_currentpage = pg_fy.CurrentPage;
                struct_tzsb.p_pagesize = pg_fy.NumPerPage;
                DataTable dt_qd = tzsb.Select_DHSBQD(struct_tzsb).Tables[0];

                dt_qd.Columns.Add("sbzl");
                foreach (DataRow dr in dt_qd.Rows)
                {
                    dr["sbzl"] = "通信设备";
                }

                ////绑定分页数据源  
                this.Repeater1.DataSource = dt_qd.DefaultView;
                this.Repeater1.DataBind();
            }
            if (sblx.Substring(0, 2) == "03")
            {
                struct_tzsb.p_wz = wz;
                struct_tzsb.p_jc = jc;
                struct_tzsb.p_sblx = sblx;
                int count = tzsb.Select_QXSBQD_Count(struct_tzsb);
                pg_fy.TotalRecord = count;
                struct_tzsb.p_currentpage = pg_fy.CurrentPage;
                struct_tzsb.p_pagesize = pg_fy.NumPerPage;
                DataTable dt_qd = tzsb.Select_QXSBQD(struct_tzsb).Tables[0];

                dt_qd.Columns.Add("sbzl");
                foreach (DataRow dr in dt_qd.Rows)
                {
                    dr["sbzl"] = "通信设备";
                }

                ////绑定分页数据源  
                this.Repeater1.DataSource = dt_qd.DefaultView;
                this.Repeater1.DataBind();
            }
            if (sblx.Substring(0, 2) == "04")
            {
                struct_tzsb.p_wz = wz;
                struct_tzsb.p_jc = jc;
                struct_tzsb.p_sblx = sblx;
                int count = tzsb.Select_JSSBQD_Count(struct_tzsb);
                pg_fy.TotalRecord = count;
                struct_tzsb.p_currentpage = pg_fy.CurrentPage;
                struct_tzsb.p_pagesize = pg_fy.NumPerPage;
                DataTable dt_qd = tzsb.Select_JSSBQD(struct_tzsb).Tables[0];

                dt_qd.Columns.Add("sbzl");
                foreach (DataRow dr in dt_qd.Rows)
                {
                    dr["sbzl"] = "通信设备";
                }

                ////绑定分页数据源  
                this.Repeater1.DataSource = dt_qd.DefaultView;
                this.Repeater1.DataBind();
            }


        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            string id = Request.Params["id"].ToString();
            dt = tzsb.Select_TZ_Detail(Convert.ToInt32(id));
            bind_select_crkqd(dt.Rows[0]["jc"].ToString(), dt.Rows[0]["wz"].ToString(), dt.Rows[0]["sblx"].ToString());
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBTZ.aspx");
        }
    }
}