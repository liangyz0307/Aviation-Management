using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.MenHu
{
    public partial class YXQ_Detail : System.Web.UI.Page
    {
        private JS js;
        private UserState userState;
        string id;
        string lx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new JS(userState);
            if (!IsPostBack)
            {
                select_detail();
               
            }
        }
        protected void select_detail()
        {
            id = Request.Params["id"].ToString();
            lx = Request.Params["lx"].ToString();
            DataTable dt_yy = new DataTable();
            DataTable dt_tj = new DataTable();
            DataTable dt_zz = new DataTable();
            dt_yy=js.Select_YXQ(id).Tables[0];
            if (dt_yy.Rows.Count>0)
            {
                dt_yy.Columns.Add("lxmc");
                foreach (DataRow dr in dt_yy.Rows)
                {
                    dr["lxmc"] = SysData.YYDJLBByKey(dr["s1"].ToString()).mc;
                }
                rp_yy.DataSource = dt_yy;
                rp_yy.DataBind();
                rp_yy.Visible = true;
            }
            dt_tj = js.Select_YXQ(id).Tables[1];
            if (dt_tj.Rows.Count > 0)
            {
                dt_tj.Columns.Add("lxmc");
               
                dt_tj.Columns.Add("tjdj");
                foreach (DataRow dr in dt_tj.Rows)
                {
                    dr["lxmc"] = "体检";
                    dr["tjdj"] = SysData.TJDJBByKey(dr["s8"].ToString()).mc;
                }
                rp_tj.DataSource = dt_tj;
                rp_tj.DataBind();
                rp_tj.Visible = true;
            }
            dt_zz = js.Select_YXQ(id).Tables[2];
            if (dt_zz.Rows.Count > 0)
            {
                dt_zz.Columns.Add("zzqz");
                dt_zz.Columns.Add("qzx");
                foreach (DataRow dr in dt_zz.Rows)
                {
                    dr["zzqz"] = SysData.ZZQZXDMByKey(dr["s3"].ToString()).mc;
                    dr["qzx"] = SysData.ZZQZXDMByKey(dr["s6"].ToString()).mc;
                }
                rp_zz.DataSource = dt_zz;
                rp_zz.DataBind();
                rp_zz.Visible = true;
            }
        }
    }
}