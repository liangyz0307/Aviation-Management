using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class GW_Edit : System.Web.UI.Page
    {

        private UserState _usState;
        private string gwdm;
        private BMGW bmgw;
        private MKG.Struct_GW struct_gw;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            bmgw = new BMGW(_usState);
            if (!IsPostBack)
            {
                dataBind();
                gwdm = Request.QueryString["gwdm"];
                show(gwdm);
            }
        }
        public void show(string gwdm)
        {
            DataTable dt = new DataTable();
            dt = bmgw.Select_GWbyGWDM(gwdm).Tables[0];
            lbl_bm.Text = SysData.BMByKey(dt.Rows[0]["bmdm"].ToString().Trim()).mc;
            lbl_gwdm.Text = dt.Rows[0]["gwdm"].ToString().Trim();
            tbx_gwmc.Text = dt.Rows[0]["gwmc"].ToString().Trim();
            ddlt_lb.SelectedValue = dt.Rows[0]["lb"].ToString().Trim();

            ddlt_zt.SelectedValue = dt.Rows[0]["zt"].ToString().Trim();
        }
        public void dataBind()
        {
            //类别
            ddlt_lb.DataSource = SysData.BMLB().Copy(); ;
            ddlt_lb.DataTextField = "mc";
            ddlt_lb.DataValueField = "bm";
            ddlt_lb.DataBind();
            ddlt_lb.Items.Insert(0, new ListItem("请选择", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZT().Copy(); ;
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("请选择", "-1"));


        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;      
            //岗位名称
            string gwmc = tbx_gwmc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gwmc))
            {
                lbl_gwmc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gwmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //类别
            if (ddlt_lb.SelectedValue.Trim() == "-1")
            {

                lbl_lb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_lb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //状态
            if (ddlt_zt.SelectedValue.Trim() == "-1")
            {

                lbl_zt.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            if (flag == 1)
            {
                return;
            }
            #endregion

            bool check = false;
            string gwdm = Request.QueryString["gwdm"];
            DataTable dt_detail = new DataTable();
            dt_detail = bmgw.Select_GWbyGWDM(gwdm).Tables[0];

            struct_gw.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            struct_gw.p_gwdm = gwdm;
            struct_gw.p_gwmc = tbx_gwmc.Text.ToString().Trim();
            struct_gw.p_lb = ddlt_lb.SelectedValue.ToString().Trim();

            struct_gw.p_zt = ddlt_zt.SelectedValue.ToString().Trim();

            struct_gw.p_czfs = "02";
            struct_gw.p_czxx = "位置：系统管理->岗位管理->编辑    [" +"岗位代码："+ struct_gw.p_gwdm+ "]         描述：";

            if (struct_gw.p_gwmc!=dt_detail.Rows[0]["gwmc"].ToString())
            {
                struct_gw.p_czxx += "岗位名称：【" + dt_detail.Rows[0]["gwmc"].ToString() + "】->【" + struct_gw.p_gwmc + "】";
                check = true;
            }

            if (struct_gw.p_lb != dt_detail.Rows[0]["lb"].ToString())
            {
                struct_gw.p_czxx += "类别：【" + dt_detail.Rows[0]["lb"].ToString() + "】->【" + struct_gw.p_lb + "】";
                check = true;
            }

            if (struct_gw.p_zt != dt_detail.Rows[0]["zt"].ToString())
            {
                struct_gw.p_czxx += "状态：【" + dt_detail.Rows[0]["zt"].ToString() + "】->【" + struct_gw.p_zt + "】";
                check = true;
            }

            if (check == false)
            {
                struct_gw.p_czxx += "未修改";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
            }
            else {
        
                 bmgw.Update_GW(struct_gw);
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                 Response.Redirect("GWGL.aspx");
            }

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
            Response.Redirect("../HouTai/GWGL.aspx");
        }
    }
}