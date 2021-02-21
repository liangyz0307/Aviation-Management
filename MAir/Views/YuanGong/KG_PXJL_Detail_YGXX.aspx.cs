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
    public partial class KG_PXJL_Detail_YGXX : System.Web.UI.Page
    {
        private UserState _us;
        private PXJL pxjl;
        //private string pxs;
        //private string sjyz;
        //private string fzr;
        public bool flag = true;
        public int i = 0;
        private Struct_PXJL struct_pxjl;
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
            pxjl = new PXJL(_us);
            struct_pxjl = new Struct_PXJL();
            id = Convert.ToInt32(Request.Params["id"].ToString());

            if (!IsPostBack)
            {
                bind_Main();
            }
        }
        private void bind_Main()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_Detail = pxjl.Select_PXJL_Detail(id);
            dt_Detail.Columns.Add("pxsmc");
            dt_Detail.Columns.Add("sjyzmc");
            dt_Detail.Columns.Add("fzrmc");
            dt_Detail.Columns.Add("ztmc");
            dt_Detail.Columns.Add("typemc");
            dt_Detail.Columns.Add("jbmc");
            dt_Detail.Columns.Add("khjgmc");
            dt_Detail.Columns.Add("jxnrmc");

            dt_Detail.Columns.Add("sjssbmmc");
            foreach (DataRow dr in dt_Detail.Rows)
            {
                string[] Array_pxs = dr["pxs"].ToString().Split(',');
                string[] Array_sjyz = dr["sjyz"].ToString().Split(',');
                string[] Array_fzr = dr["fzr"].ToString().Split(',');
                foreach (string pxs_bh in Array_pxs)
                {
                    dr["pxsmc"] = pxjl.Select_YGXMbyBH(pxs_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string sjyz_bh in Array_sjyz)
                {
                    dr["sjyzmc"] = pxjl.Select_YGXMbyBH(sjyz_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string fzr_bh in Array_fzr)
                {
                    dr["fzrmc"] = pxjl.Select_YGXMbyBH(fzr_bh.ToString()).Rows[0][0].ToString();
                }
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["typemc"] = SysData.typeByKey(dr["type"].ToString()).mc;
                dr["jbmc"] = SysData.JBByKey(dr["jb"].ToString()).mc;
                dr["khjgmc"] = SysData.khjgByKey(dr["khjg"].ToString()).mc;
                dr["sjssbmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["shsj"] = DateTime.Parse(dr["shsj"].ToString()).ToString("yyyy-MM-dd");


                lbl_type.Text = dt_Detail.Rows[0]["typemc"].ToString();
                lbl_rqsj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["rqsj"]).ToString("yyyy-MM-dd");
                lbl_xs.Text = dt_Detail.Rows[0]["xs"].ToString();
                lbl_ks.Text = dt_Detail.Rows[0]["ks"].ToString();
                lbl_jb.Text = dt_Detail.Rows[0]["jbmc"].ToString();
                lbl_pxs.Text = dt_Detail.Rows[0]["pxsmc"].ToString();
                lbl_khfs.Text = dt_Detail.Rows[0]["khfs"].ToString();
                lbl_khjg.Text = dt_Detail.Rows[0]["khjgmc"].ToString();
                lbl_sjyz.Text = dt_Detail.Rows[0]["sjyzmc"].ToString();
                lbl_fzr.Text = dt_Detail.Rows[0]["fzrmc"].ToString();
                lbl_jxnr.Text = dt_Detail.Rows[0]["jxnr"].ToString();

                lbl_lrr.Text = dt_Detail.Rows[0]["lrrxm"].ToString();//录入人
                lbl_csr.Text = dt_Detail.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt_Detail.Rows[0]["zsrxm"].ToString();//终审人
                lbl_sjssbmmc.Text = dt_Detail.Rows[0]["sjssbmmc"].ToString();//数据所属部门
            }
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("YGGL.aspx", true);
        }
    }
}
