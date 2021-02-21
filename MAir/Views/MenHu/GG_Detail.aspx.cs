
using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;


namespace CUST.Web.MengHu.main
{
    public partial class GG_Detail : System.Web.UI.Page
    {
        private UserState userstate;
        private YH yh;
        private JS js;
      public string bt = "";
        public int id=0 ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yh = new YH(userstate);
            js = new JS(userstate);
            if (!IsPostBack)
            {
                Show_Detail();
            }
        }
        private void Show_Detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            bt = Request.Params["bt"].ToString().Trim();  //接收传值
           
            DataTable dt_gg = new DataTable();
            dt_gg = js.Select_JS_GGDetail(id).Tables[0];
            DateTime fbsj = new DateTime();
            fbsj = DateTime.Parse(dt_gg.Rows[0]["fbsj"].ToString());
           
            lbl_sj.Text = fbsj.ToString("yyyy-MM-dd");
            lbl_fbr.Text = dt_gg.Rows[0]["xm"].ToString();
            lbl_fbbm.Text = SysData.BMByKey(dt_gg.Rows[0]["bmdm"].ToString()).mc;
            lbl_title.Text = dt_gg.Rows[0]["bt"].ToString();
            lbl_detail.Text = dt_gg.Rows[0]["lr"].ToString();
        }
    }
}