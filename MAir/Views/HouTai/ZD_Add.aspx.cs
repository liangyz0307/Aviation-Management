using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using Sys;

namespace CUST.WKG
{
    public partial class ZD_Add : System.Web.UI.Page

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
                bind_dropdownlist();
            }
        }
        protected void bind_dropdownlist()
        {

            //字典码
            ddlt_zdm.DataSource = SysData.ZDM().Copy(); ;
            ddlt_zdm.DataTextField = "mc";
            ddlt_zdm.DataValueField = "bm";
            ddlt_zdm.DataBind();
            ddlt_zdm.Items.Insert(0, new ListItem("请选择", "-1"));

        
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_zd.p_zdm = ddlt_zdm.SelectedValue;//字典码
            struct_zd.p_bm = tbx_bm.Text.ToString().Trim();//编码
            struct_zd.p_mc = tbx_mc.Text.ToString().Trim();//名称
            struct_zd.p_czfs = "01";
            struct_zd.p_czxx = "位置：后台管理->字典管理->添加 描述：字典码：【" + SysData.ZDMByKey(struct_zd.p_zdm) + "】      " + " 编码：【" + struct_zd.p_bm + "】      " + " 名称：【" + struct_zd.p_mc + "】";
            zd.Insert_ZD(struct_zd);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            ddlt_zdm.SelectedValue = "-1";
        

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
    }
}