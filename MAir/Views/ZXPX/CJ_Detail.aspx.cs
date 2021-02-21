using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
namespace CUST.WKG
{
    public partial class CJ_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private DJK djk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            djk = new DJK(_usState);
            if (!IsPostBack)
            {
                Data_Bind();
            }
        }
        protected void Data_Bind()
        {
            long dj_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
            DataTable dt_djk = djk.Select_DJK_Detail(dj_id);
            lbl_mc.Text = dt_djk.Rows[0]["mc"].ToString();
            lbl_zf.Text = dt_djk.Rows[0]["zf"].ToString();
            lbl_xz_zq_sl.Text = dt_djk.Rows[0]["xz_zq_sl"].ToString();
            lbl_xz_sl.Text = dt_djk.Rows[0]["xz_sl"].ToString();
            lbl_xz_fz.Text = dt_djk.Rows[0]["xz_fz"].ToString();
            lbl_pd_zq_sl.Text = dt_djk.Rows[0]["pd_zq_sl"].ToString();
            lbl_pd_sl.Text = dt_djk.Rows[0]["pd_sl"].ToString();
            lbl_pd_fz.Text = dt_djk.Rows[0]["pd_fz"].ToString();
            lbl_tk_zq_sl.Text = dt_djk.Rows[0]["tk_zq_sl"].ToString();
            lbl_tk_sl.Text = dt_djk.Rows[0]["tk_sl"].ToString();
            lbl_tk_fz.Text = dt_djk.Rows[0]["tk_fz"].ToString();
            lbl_sc.Text = dt_djk.Rows[0]["sc"].ToString();
            lbl_nd.Text = SysData.STNDByKey(dt_djk.Rows[0]["nd"].ToString()).mc;
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.opener=null;window.open('','_self');window.close();</script>");
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