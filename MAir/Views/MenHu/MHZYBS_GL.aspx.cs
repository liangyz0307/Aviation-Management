using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;

namespace CUST.WKG.main
{
    public partial class MHZYBS_GL : System.Web.UI.Page
    {
        private UserState userstate;
        public JS js;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new JS(userstate);
            if (!IsPostBack)
            {
                select();
            }
        }
        protected void select()
        {
            string bsyg = userstate.userLoginName;
            DataTable dt = new DataTable();
            dt = js.Select_JS_ZYBS(bsyg).Tables[0];
            dt.Columns.Add("bslxmc");
            dt.Columns.Add("bssjgs");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bssjgs"] = Convert.ToDateTime(dr["bssj"]).ToString("yyyy-MM-dd");
                dr["bslxmc"] = SysData.BSLXByKey(dr["bslx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;
            }
            this.rpt_zybs.DataSource = dt;
            this.rpt_zybs.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/ZYBSXXGL_Add.aspx");
        }
    }
}