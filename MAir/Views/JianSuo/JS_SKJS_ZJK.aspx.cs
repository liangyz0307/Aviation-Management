using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.JianSuo
{
    public partial class JS_SKJS_ZJK : System.Web.UI.Page
    {
        private UserState _us;
        private DataTable dt_detail;
        private int id;
        private Struct_ZJK_Pro struct_zjk;
        private ZJK zjk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = Session["UserState"] as UserState) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zjk = new ZJK(_us);
            if (!IsPostBack)
            {
                select_detail();
            }
        }
        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"]);
            dt_detail = zjk.Select_ZJK_Detail(id);
            lbl_xm.Text = dt_detail.Rows[0]["xm"].ToString();
            lbl_zjlx.Text = SysData.ZJLXByKey(dt_detail.Rows[0]["zjlx"].ToString()).mc;
            lbl_zd.Text = dt_detail.Rows[0]["zd"].ToString();
            lbl_csgz.Text = dt_detail.Rows[0]["csgz"].ToString();
            lbl_zy.Text = dt_detail.Rows[0]["zy"].ToString();
            lbl_zc.Text = dt_detail.Rows[0]["zc"].ToString();
            lbl_lxfs.Text = dt_detail.Rows[0]["lxfs"].ToString();
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();
            lbl_bmdm.Text = SysData.BMByKey(dt_detail.Rows[0]["bmdm"].ToString()).mc;
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SKJS.aspx", true);
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