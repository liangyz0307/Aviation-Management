using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class DQZC_ZZJGEdit : System.Web.UI.Page
    {
        private UserState _usState;
        private ZZJG zzjg;
        private Struct_ZZJG strcut_zzjgxx;
        private int id;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            zzjg = new ZZJG(_usState);
            strcut_zzjgxx = new Struct_ZZJG();
            if (!IsPostBack)
            {

                id = Convert.ToInt32(Request.Params["id"].ToString());
                ddltBind();
                select_detail();

            }
        }
                private void select_detail()
        {
            dt_detail = zzjg.Select_ZZJG_Detail(id);
            
            tbx_dzzmc.Text = dt_detail.Rows[0]["dzzmc"].ToString();
            tbx_jcdzbmc.Text = dt_detail.Rows[0]["jcdzbmc"].ToString();
            tbx_dxzmc.Text = dt_detail.Rows[0]["dxzmc"].ToString();
             
        }
         protected void btn_save_Click(object sender, EventArgs e)
        {
            int flag = 0;
            //党组织名称
            string dzzmc = tbx_dzzmc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(dzzmc))
            {

                lbl_dzzmc.Text = "<span style=\"color:#ff0000\">" + "错误！请输入党组织名称！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dzzmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //基层党支部名称
            string jcdzbmc = tbx_jcdzbmc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jcdzbmc))
            {

                lbl_jcdzbmc.Text = "<span style=\"color:#ff0000\">" + "错误！请输入基层党支部名称！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jcdzbmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //党小组名称
            string dxzmc = tbx_dxzmc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(dxzmc))
            {

                lbl_dxzmc.Text = "<span style=\"color:#ff0000\">" + "错误！请输入基层党支部名称！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dxzmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (flag == 1) { return; }
            strcut_zzjgxx.p_id = Convert.ToInt32(Request.Params["id"].ToString());//id
            strcut_zzjgxx.p_dzzmc = tbx_dzzmc.Text.ToString();
            strcut_zzjgxx.p_jcdzbmc = tbx_jcdzbmc.Text.ToString();
            strcut_zzjgxx.p_dxzmc = tbx_dxzmc.Text.ToString();
            strcut_zzjgxx.p_ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
            strcut_zzjgxx.p_czsj = DateTime.Parse(DateTime.Now.ToString());
            zzjg.ZZJG_Edit(strcut_zzjgxx);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
        }
            private void ddltBind()
        {

            ////标识符
            //ddlt_dzb_bs.DataSource = SysData.DZB_BS().Copy();
            //ddlt_dzb_bs.DataTextField = "mc";
            //ddlt_dzb_bs.DataValueField = "bm";
            //ddlt_dzb_bs.DataBind();
            //党组织名称
            //ddlt_dzzmc.DataTextField = "mc";
            //ddlt_dzzmc.DataValueField = "bm";
            //ddlt_dzzmc.DataSource = SysData.DZZMC().Copy();
            //ddlt_dzzmc.DataBind();
            //ddlt_dzzmc.Items.Insert(0, new ListItem("请选择", "-1"));
          
            ////党小组名称
            //ddlt_dxzmc.DataTextField = "mc";
            //ddlt_dxzmc.DataValueField = "bm";
            //ddlt_dxzmc.DataSource = SysData.DXZMC().Copy();
            //ddlt_dxzmc.DataBind();
            //ddlt_dxzmc.Items.Insert(0, new ListItem("请选择", "-1"));
            ////基层党支部名称
            //ddlt_jcdzbmc.DataTextField = "mc";
            //ddlt_jcdzbmc.DataValueField = "bm";
            //ddlt_jcdzbmc.DataSource = SysData.JCDZBMC().Copy();
            //ddlt_jcdzbmc.DataBind();
            //ddlt_jcdzbmc.Items.Insert(0, new ListItem("请选择", "-1"));



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
            Response.Redirect("../DQZC/DQZC_ZZJGCX.aspx", false);
        }
    }
}
    