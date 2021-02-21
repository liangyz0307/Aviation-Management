using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG
{
    public partial class JS_SKJS_SBBLK : System.Web.UI.Page
    {
        private UserState _us;
        private SBBLK sbblk;
        private Struct_SBBLK struct_sbblk;
        private static string p_id;
        private static DataTable dt_detail;
        static string wxrybh;
        static string syrbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            sbblk = new SBBLK(_us);
            struct_sbblk = new Struct_SBBLK();
            if (!IsPostBack)
            {
                p_id = Request.QueryString["id"];
                select_detail();
            }
        }
        protected void select_detail()
        {
            dt_detail = sbblk.Select_SBBLK_Detail(Convert.ToInt32(p_id));
            dt_detail.Columns.Add("syrxm");
            dt_detail.Columns.Add("wxryxm");
            dt_detail.Columns.Add("bm");
            dt_detail.Columns.Add("bypcmc");
            foreach (DataRow dr in dt_detail.Rows)
            {

                string[] Array_syr = dr["syr"].ToString().Split(',');
                string[] Array_wxry = dr["wxry"].ToString().Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += sbblk.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                foreach (string wxryxm_dm in Array_wxry)
                {
                    dr["wxryxm"] += sbblk.Select_YGXMbyBH(wxryxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["bypcmc"] = SysData.BYPCByKey(dr["bypc"].ToString()).mc;
            }

            lbl_sbmc.Text = dt_detail.Rows[0]["sbmc"].ToString();
            lbl_dd.Text = dt_detail.Rows[0]["dd"].ToString();
            lbl_bypc.Text = dt_detail.Rows[0]["bypcmc"].ToString();
            lbl_sygw.Text = dt_detail.Rows[0]["sygw"].ToString();
            lbl_syr.Text = dt_detail.Rows[0]["syrxm"].ToString();
            lbl_gzsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["gzsj"]).ToString("yyyy-MM-dd");
            lbl_synx.Text = dt_detail.Rows[0]["synx"].ToString();
            lbl_xx.Text = dt_detail.Rows[0]["xx"].ToString();
            lbl_yy.Text = dt_detail.Rows[0]["yy"].ToString();
            lbl_pgfs.Text = dt_detail.Rows[0]["pgfs"].ToString();
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            lbl_wxry.Text = dt_detail.Rows[0]["wxryxm"].ToString();
            lbl_pgsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["pgsj"]).ToString("yyyy-MM-dd");
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();//驳回原因
            lbl_sjszbm.Text = dt_detail.Rows[0]["bm"].ToString();
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
            lbl_shsj.Text = dt_detail.Rows[0]["shsj"].ToString();//审核时间

        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SKJS.aspx", true);
        }

    }

}