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
using System.Text.RegularExpressions;


namespace CUST.WKG
{
    public partial class JS_SKJS_WXY : System.Web.UI.Page
    {
        private UserState _usState;
        private WXY wxy;
        private Struct_WXY struct_wxy;
        static string syrbh;
        private static DataTable dt_detail = new DataTable();
        private static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            wxy = new WXY(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                bind_Main();
            }
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SKJS.aspx", true);
        }


        private void bind_Main()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = wxy.Select_WXY_Detail(id);
            dt_detail.Columns.Add("syrxm");
            dt_detail.Columns.Add("sjsubmmc");
            dt_detail.Columns.Add("ztmc");

            dt_detail.Columns.Add("fcmc");
            dt_detail.Columns.Add("stmc");
            dt_detail.Columns.Add("knxmc");
            dt_detail.Columns.Add("yzxmc");
            dt_detail.Columns.Add("fxcdmc");
            dt_detail.Columns.Add("kzztmc");
            dt_detail.Columns.Add("bzhqkmc");
            dt_detail.Columns.Add("zrejmc");
            dt_detail.Columns.Add("zrsjmc");
            dt_detail.Columns.Add("phbmmc");
            foreach (DataRow dr in dt_detail.Rows)
            {
                string[] Array_syr = dr["zrr"].ToString().Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += wxy.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["sjsubmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;

                dr["fcmc"] = SysData.WXYFCByKey(dr["fc"].ToString()).mc;//状态
                dr["stmc"] = SysData.STDMByKey(dr["st"].ToString()).mc;//状态
                dr["knxmc"] = SysData.FXFSKNByKey(dr["knx"].ToString()).mc;
                dr["yzxmc"] = SysData.YZCDByKey(dr["yzx"].ToString()).mc;//状态
                dr["fxcdmc"] = SysData.FXCDByKey(dr["fxcd"].ToString()).mc;
                dr["kzztmc"] = SysData.FXKZZTByKey(dr["kzzt"].ToString()).mc;//状态
                dr["bzhqkmc"] = SysData.ZGCSBZHQKByKey(dr["bzhqk"].ToString()).mc;
                dr["zrejmc"] = SysData.BMByKey(dr["zrej"].ToString()).mc;//状态
                dr["zrsjmc"] = SysData.BMByKey(dr["zrsj"].ToString()).mc;
                dr["phbmmc"] = SysData.BMByKey(dr["phbm"].ToString()).mc;//状态
            }


            lbl_syr.Text = dt_detail.Rows[0]["syrxm"].ToString();
            lbl_mc.Text = dt_detail.Rows[0]["mc"].ToString();
            lbl_gw.Text = dt_detail.Rows[0]["gw"].ToString();
            lbl_fc.Text = dt_detail.Rows[0]["fcmc"].ToString();
            lbl_yy.Text = dt_detail.Rows[0]["yy"].ToString();
            lbl_hg.Text = dt_detail.Rows[0]["zchg"].ToString();
            lbl_xgal.Text = dt_detail.Rows[0]["xgal"].ToString();
            lbl_yf.Text = dt_detail.Rows[0]["yf"].ToString();
            lbl_st.Text = dt_detail.Rows[0]["stmc"].ToString();
            lbl_knx.Text = dt_detail.Rows[0]["knxmc"].ToString();
            lbl_yzx.Text = dt_detail.Rows[0]["yzxmc"].ToString();
            lbl_fxcd.Text = dt_detail.Rows[0]["fxcdmc"].ToString();
            lbl_zt.Text = dt_detail.Rows[0]["ztmc"].ToString();
            lbl_yj.Text = dt_detail.Rows[0]["yjcs"].ToString();
            lbl_kzzt.Text = dt_detail.Rows[0]["kzztmc"].ToString();
            lbl_bzh.Text = dt_detail.Rows[0]["bzhqkmc"].ToString();
            lbl_ya.Text = dt_detail.Rows[0]["ya"].ToString();
            lbl_bmej.Text = dt_detail.Rows[0]["zrejmc"].ToString();
            lbl_bmsj.Text = dt_detail.Rows[0]["zrsjmc"].ToString();
            lbl_phbm.Text = dt_detail.Rows[0]["phbmmc"].ToString();

            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
            lbl_shjsbmmc.Text = dt_detail.Rows[0]["sjsubmmc"].ToString();


        }
    }
}