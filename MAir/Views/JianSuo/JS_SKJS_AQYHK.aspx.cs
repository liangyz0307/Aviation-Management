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
    public partial class JS_SKJS_AQYHK : System.Web.UI.Page
    {
        private UserState _us;
        private AQYHK aqyhk;
        private string zgzrr;
        private string zgdbzrr;
        private string zgyzr;
        public bool flag = true;
        public int i = 0;
        private Struct_AQYHK struct_aqyhk;
        private static int id;
        private DataTable dt_Detail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            aqyhk = new AQYHK(_us);
            struct_aqyhk = new Struct_AQYHK();
            id = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                bind_Main();
            }
        }


        private void bind_Main()
        {
            dt_Detail = aqyhk.Select_AQYHK_Detail(id);
            dt_Detail.Columns.Add("zgzrrxm");
            dt_Detail.Columns.Add("zgdbzrrxm");
            dt_Detail.Columns.Add("zgyzrxm");
            dt_Detail.Columns.Add("yhdjmc");
            dt_Detail.Columns.Add("lymc");
            dt_Detail.Columns.Add("zggbpzmc");
            dt_Detail.Columns.Add("zgzrdwmc");
            dt_Detail.Columns.Add("tbdwmc");
            dt_Detail.Columns.Add("ztmc");
            dt_Detail.Columns.Add("sjsubmmc");

            dt_Detail.Columns.Add("yhfxsjz");
            dt_Detail.Columns.Add("zgwcsxz");
            dt_Detail.Columns.Add("zggbsjz");
            dt_Detail.Columns.Add("shsjz");




            foreach (DataRow dr in dt_Detail.Rows)
            {
                string[] Array_zgzzr = dr["zgzrr"].ToString().Split(',');
                string[] Array_zgdbzrr = dr["zgdbzrr"].ToString().Split(',');
                string[] Array_zgyzr = dr["zgyzr"].ToString().Split(',');
                foreach (string zgzzrxm_bh in Array_zgzzr)
                {
                    dr["zgzrrxm"] = aqyhk.Select_YGXMbyBH(zgzzrxm_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string zgdbzrrxm_bh in Array_zgdbzrr)
                {
                    dr["zgdbzrrxm"] = aqyhk.Select_YGXMbyBH(zgdbzrrxm_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string zgyzrxm_bh in Array_zgyzr)
                {
                    dr["zgyzrxm"] = aqyhk.Select_YGXMbyBH(zgyzrxm_bh.ToString()).Rows[0][0].ToString();
                }
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["tbdwmc"] = SysData.BMByKey(dr["tbdw"].ToString()).mc;
                dr["zgzrdwmc"] = SysData.BMByKey(dr["zgzrdw"].ToString()).mc;
                dr["zggbpzmc"] = SysData.ZGGBPZByKey(dr["zggbpz"].ToString()).mc;
                dr["lymc"] = SysData.LYByKey(dr["ly"].ToString()).mc;
                dr["yhdjmc"] = SysData.YHDJByKey(dr["yhdj"].ToString()).mc;
                dr["sjsubmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;


                lbl_tbdw.Text = dt_Detail.Rows[0]["tbdwmc"].ToString();
                lbl_yhfxsj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["yhfxsj"]).ToString("yyyy-MM-dd");
                lbl_ly.Text = dt_Detail.Rows[0]["lymc"].ToString();
                lbl_yhms.Text = dt_Detail.Rows[0]["yhms"].ToString();
                lbl_knzcwh.Text = dt_Detail.Rows[0]["knzcwh"].ToString();
                lbl_yhdj.Text = dt_Detail.Rows[0]["yhdjmc"].ToString();
                lbl_pgfjpz.Text = dt_Detail.Rows[0]["pgfjpz"].ToString();
                lbl_zgcs.Text = dt_Detail.Rows[0]["zgcs"].ToString();
                lbl_yjtrfy.Text = dt_Detail.Rows[0]["yjtrfy"].ToString();
                lbl_zgwcsx.Text = Convert.ToDateTime(dt_Detail.Rows[0]["zgwcsx"]).ToString("yyyy-MM-dd");
                lbl_wcjdms.Text = dt_Detail.Rows[0]["wcjdms"].ToString();
                lbl_zgzrdw.Text = dt_Detail.Rows[0]["zgzrdwmc"].ToString();
                lbl_zgzrrxm.Text = dt_Detail.Rows[0]["zgzrrxm"].ToString();
                lbl_zgdbzrrxm.Text = dt_Detail.Rows[0]["zgdbzrrxm"].ToString();
                lbl_zgfapz.Text = dt_Detail.Rows[0]["zgfapz"].ToString();
                lbl_zgyzjg.Text = dt_Detail.Rows[0]["zgyzjg"].ToString();
                lbl_zgyzrxm.Text = dt_Detail.Rows[0]["zgyzrxm"].ToString();
                lbl_zggbsj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["zggbsj"]).ToString("yyyy-MM-dd");
                lbl_zggbbz.Text = dt_Detail.Rows[0]["zggbbz"].ToString();
                lbl_zggbpz.Text = dt_Detail.Rows[0]["zggbpzmc"].ToString();
                lbl_xgtzbcqk.Text = dt_Detail.Rows[0]["xgtzbcqk"].ToString();
                lbl_zt.Text = dt_Detail.Rows[0]["ztmc"].ToString();
                lbl_bhyy.Text = dt_Detail.Rows[0]["bhyy"].ToString();

                lbl_lrr.Text = dt_Detail.Rows[0]["lrrxm"].ToString();//录入人
                lbl_csr.Text = dt_Detail.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt_Detail.Rows[0]["zsrxm"].ToString();//终审人
                lbl_shjsbmmc.Text = dt_Detail.Rows[0]["sjsubmmc"].ToString();


            }
        }



        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SKJS.aspx", true);
        }
    }
}