using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
namespace CUST.WKG
{
    public partial class CL_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private ZJ_CL zj_cl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zj_cl = new ZJ_CL(_usState);
            if (!IsPostBack)
            {
                Data_Bind();
            }
        }
        protected void Data_Bind()
        {
            long zj_cl_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
            DataTable dt_zj_cl = zj_cl.Select_ZJ_CL_Detail(zj_cl_id);
            lbl_mc.Text = dt_zj_cl.Rows[0]["mc"].ToString();
            lbl_zf.Text = dt_zj_cl.Rows[0]["zf"].ToString();
            lbl_xz_sl.Text = dt_zj_cl.Rows[0]["xz_sl"].ToString();
            lbl_xz_fz.Text = dt_zj_cl.Rows[0]["xz_fz"].ToString();
            lbl_dx_sl.Text = dt_zj_cl.Rows[0]["dx_sl"].ToString();
            lbl_dx_fz.Text = dt_zj_cl.Rows[0]["dx_fz"].ToString();
            lbl_pd_sl.Text = dt_zj_cl.Rows[0]["pd_sl"].ToString();
            lbl_pd_fz.Text = dt_zj_cl.Rows[0]["pd_fz"].ToString();
            lbl_tk_sl.Text = dt_zj_cl.Rows[0]["tk_sl"].ToString();
            lbl_tk_fz.Text = dt_zj_cl.Rows[0]["tk_fz"].ToString();
            lbl_sc.Text = dt_zj_cl.Rows[0]["sc"].ToString();
            lbl_nd.Text = SysData.STNDByKey(dt_zj_cl.Rows[0]["nd"].ToString()).mc;
            lbl_km.Text = SysData.KMByKey(dt_zj_cl.Rows[0]["km"].ToString()).mc;
            string str_stlb = dt_zj_cl.Rows[0]["lb"].ToString();
            string[] arr_stlb = str_stlb.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string lb = "";
            for (int i = 0; i < arr_stlb.Length; i++)
            {
                lb += SysData.STLBByKey(arr_stlb[i].ToString()).mc + ";";
            }
            lbl_lb.Text = lb;
            lbl_gw.Text = SysData.GWByKey(dt_zj_cl.Rows[0]["gw"].ToString()).mc;
            lbl_ctr.Text = dt_zj_cl.Rows[0]["ctr_xm"].ToString();
            lbl_ctsj.Text = dt_zj_cl.Rows[0]["ctsj"].ToString();
            lbl_shr.Text = dt_zj_cl.Rows[0]["shr_xm"].ToString();
            lbl_zt.Text = SysData.STZTByKey(dt_zj_cl.Rows[0]["zt"].ToString()).mc;
            lbl_yysm.Text = dt_zj_cl.Rows[0]["yysm"].ToString();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZXPX/CLGL.aspx", true);
        }
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
    }
}