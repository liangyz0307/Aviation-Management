using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class ZD_Edit : System.Web.UI.Page
    {

        private UserState _usState;
        private string ygbh;
        private ZD zd;
        private ZD.Struct_ZD_Pro struct_zd;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zd = new ZD(_usState);
            if (!IsPostBack)
            {
                struct_zd.p_zdm = Request.QueryString["bj_zdm"];
                struct_zd.p_bm = Request.QueryString["bj_bm"];
                struct_zd.p_mc = Request.QueryString["bj_mc"];
                string zdm_mc = Request.QueryString["bj_zdmmc"];
                lbl_zdm.Text =zdm_mc;
                lbl_bm.Text = struct_zd.p_bm;
                tbx_mc.Text = struct_zd.p_mc;

            }
        }

        protected void bind()

        {
            bool check = false;
            struct_zd.p_zdm = Request.QueryString["bj_zdm"];
            struct_zd.p_bm = lbl_bm.Text.ToString();
            struct_zd.p_mc = tbx_mc.Text.ToString().Trim();
            struct_zd.p_czfs = "02";
            struct_zd.p_czxx = "位置：系统管理->字典管理->编辑    [字典码：" + SysData.ZDMByKey(struct_zd.p_zdm) + " 编码：" + struct_zd.p_bm + "]         描述：";
            if (Request.QueryString["bj_mc"] != struct_zd.p_mc)
            {
                struct_zd.p_czxx += "名称：【" + Request.QueryString["bj_mc"] + "】->【" + struct_zd.p_mc + "】";
                check = true;
            }
            if (check == false)
            {
                struct_zd.p_czxx += "未修改";
            }

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {

            bind();
            zd.Update_ZD(struct_zd);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
            btn_bj.Visible = true;
            btn_save.Visible = false;
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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/ZDGL.aspx");
        }

        protected void btn_bj_Command(object sender, CommandEventArgs e)
        {
            btn_bj.Visible = false;
            btn_save.Visible = true;
        }
    }
}