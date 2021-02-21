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
using System.Text.RegularExpressions;
using Sys;

namespace CUST.WKG
{
    public partial class GW_Add : System.Web.UI.Page

    {
        private UserState _usState;
        private string ygbh;
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
                bind_dropdownlist();
            }
        }
        protected void bind_dropdownlist()
        {

            //部门
            ddlt_bm.DataSource = SysData.BM().Copy(); ;
            ddlt_bm.DataTextField = "mc";
            ddlt_bm.DataValueField = "bm";
            ddlt_bm.DataBind();
            ddlt_bm.Items.Insert(0, new ListItem("请选择", "-1"));
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
            //岗位编号
            string gwdm = tbx_gwdm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gwdm))
            {

                lbl_gwdm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            if (gwdm.Length > 6)
            {

                lbl_gwdm.Text = "<span style=\"color:#ff0000\">" + "错误：部门代码不能超过6位！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gwdm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
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
            //部门
            if (ddlt_bm.SelectedValue.Trim() == "-1")
            {

                lbl_bmdm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bmdm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            struct_gw.p_bmdm = ddlt_bm.SelectedValue.ToString().Trim();//部门
            struct_gw.p_gwdm = struct_gw.p_bmdm+tbx_gwdm.Text.ToString().Trim();//岗位代码
            struct_gw.p_gwmc= tbx_gwmc.Text.ToString().Trim();//岗位名称
            struct_gw.p_lb = ddlt_lb.SelectedValue.ToString().Trim();//类别

            struct_gw.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态

            //struct_gw.p_zt = "0";
            struct_gw.p_czfs = "01";
            struct_gw.p_czxx = "位置：后台管理->岗位管理->添加 描述： " 
                + " 岗位代码：【" + struct_gw.p_gwdm + "】" + " 岗位名称：【" + struct_gw.p_gwmc + "】" + " 状态：【" + struct_gw.p_zt + "】";
            bmgw.Insert_GW(struct_gw);          
            Response.Redirect("GWGL.aspx");
      
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