using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
namespace CUST.WKG
{
    public partial class ST_PDT_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private PDT pdt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            pdt = new PDT(_usState);
            if (!IsPostBack)
            {
                DateBind();
            }
        }
        protected void DateBind()
        {
            long st_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
            DataTable st = pdt.Select_PDT_Detail(st_id);
            lbl_tg.Text = st.Rows[0]["tg"].ToString();
            string da = st.Rows[0]["da"].ToString();
            if (da == "1")
            {
                lbl_da.Text = "正确";
            }
            else if (da == "0")
            {
                lbl_da.Text = "错误";
            }
            lbl_nd.Text = SysData.STNDByKey(st.Rows[0]["nd"].ToString()).mc;
            lbl_km.Text = SysData.KMByKey(st.Rows[0]["km"].ToString()).mc;
            lbl_stlb.Text = SysData.STLBByKey(st.Rows[0]["lb"].ToString()).mc;

            //lbl_gw.Text = SysData.GWByKey(st.Rows[0]["gw"].ToString()).mc;
            string str_gw = st.Rows[0]["gw"].ToString();
            string[] arr_gw = str_gw.Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
            string str_sygw = "";
            for (int i = 0; i < arr_gw.Length; i++)
            {
                str_sygw += SysData.GWByKey(arr_gw[i]).mc + " ; ";
            }
            lbl_gw.Text= str_sygw;

            lbl_kczsd.Text = st.Rows[0]["kczsd"].ToString();
            lbl_lrr.Text = st.Rows[0]["lrr_xm"].ToString();
            lbl_lrsj.Text = st.Rows[0]["lrsj"].ToString();
            lbl_shr.Text = st.Rows[0]["shr_xm"].ToString();
            lbl_zt.Text = SysData.STZTByKey(st.Rows[0]["zt"].ToString()).mc;
            lbl_yysm.Text = st.Rows[0]["yysm"].ToString();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZXPX/STGL.aspx", true);
        }
    }
}