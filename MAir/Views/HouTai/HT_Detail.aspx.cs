using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;

namespace CUST.WKG
{
    public partial class HT_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        public HT ht;
        public Struct_HT struct_ht;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ht = new HT(_usState);
            if (!IsPostBack)
            {
                select();
            }
        }
        private void select()
        {
            DataTable dt = new DataTable();
            struct_ht.p_id = Request.QueryString["id"];
            dt = ht.Select_HTDetail(struct_ht);
            DateTime dt_qdrq = new DateTime();
            dt_qdrq = Convert.ToDateTime(dt.Rows[0]["qdrq"].ToString().Trim());
            DateTime dt_kssj = new DateTime();

            //dt_kssj = Convert.ToDateTime(dt.Rows[0]["qxkssj"].ToString().Trim());
            DateTime dt_jssj = new DateTime();
            //dt_jssj = Convert.ToDateTime(dt.Rows[0]["qxjssj"].ToString().Trim());

            DateTime dt_ks = new DateTime();
            if (dt.Rows[0]["qdrq"].ToString().Trim() == "")
            {
                dt_kssj = dt_ks;
            }
            else
            {
                dt_kssj = Convert.ToDateTime(dt.Rows[0]["qxkssj"].ToString().Trim());
            }
            if (dt.Rows[0]["qxjssj"].ToString().Trim() == "")
            {
                dt_jssj = dt_ks;
            }
            else
            {
                struct_ht.p_qxjssj = Convert.ToDateTime(dt.Rows[0]["qxjssj"].ToString().Trim());
            }


            lbl_htmc.Text = dt.Rows[0]["htmc"].ToString().Trim();
            lbl_qdf.Text = dt.Rows[0]["qdf"].ToString().Trim();
            lbl_ze.Text = dt.Rows[0]["ze"].ToString().Trim();
            lbl_qdrq.Text = string.Format("{0:yyyy-MM-dd }", dt_qdrq);
            lbl_kssj.Text = string.Format("{0:yyyy-MM-dd }", dt_kssj);
            lbl_jssj.Text = string.Format("{0:yyyy-MM-dd }", dt_jssj);
            lbl_zt.Text = SysData.HTZTByKey(dt.Rows[0]["zt"].ToString().Trim()).mc+ dt.Rows[0]["ztbz"].ToString().Trim();
          
            lbl_fzr.Text = dt.Rows[0]["fzr"].ToString().Trim();
            lbl_bz.Text = dt.Rows[0]["bz"].ToString().Trim();

        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("HTGL.aspx");
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
    }
}