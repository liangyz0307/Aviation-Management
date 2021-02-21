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
    public partial class BM_Add : System.Web.UI.Page

    {
        private UserState _usState;
        private string ygbh;
        private BMGW bmgw;
        private MKG.Struct_BM struct_bm;
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

            //上级部门
            ddlt_sjbm.DataSource = SysData.BM().Copy(); ;
            ddlt_sjbm.DataTextField = "mc";
            ddlt_sjbm.DataValueField = "bm";
            ddlt_sjbm.DataBind();
            ddlt_sjbm.Items.Insert(0, new ListItem("请选择", "-1"));
            //部门类别(暂用用户类别)
            ddlt_bmlb.DataSource = SysData.YHLB().Copy(); ;
            ddlt_bmlb.DataTextField = "mc";
            ddlt_bmlb.DataValueField = "bm";
            ddlt_bmlb.DataBind();
            ddlt_bmlb.Items.Insert(0, new ListItem("请选择", "-1"));
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
            //部门编号
            string bmdm = tbx_bmdm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bmdm))
            {

                lbl_bmdm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            if (bmdm.Length > 3)
            {

                lbl_bmdm.Text = "<span style=\"color:#ff0000\">" + "错误：部门代码不能超过3位！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bmdm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //部门名称
            string bmmc = tbx_bmmc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bmmc))
            {
                lbl_bmmc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bmmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //负责人

            string fzr = tbx_fzr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(fzr))
            {
                lbl_fzr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            //上级部门
            if (ddlt_sjbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //部门类别
            if (ddlt_bmlb.SelectedValue.Trim() == "-1")
            {

                lbl_bmlb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bmlb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            //联系电话
            string lxdh = tbx_lxdh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(lxdh))
            {
                lbl_lxdh.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(lxdh, @"^[1][3578]\d{9}$"))
                {
                    lbl_lxdh.Text = "<span style=\"color:#ff0000\">" + "错误：格式错误！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_lxdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
           
            if (flag == 1)
            {
                return;
            }
            #endregion
            struct_bm.p_bmdm = tbx_bmdm.Text.ToString().Trim();//部门代码
            struct_bm.p_bmmc = tbx_bmmc.Text.ToString().Trim();//部门名称
            struct_bm.p_sjbmdm=ddlt_sjbm.SelectedValue.ToString().Trim();//上级部门代码
            struct_bm.p_bmlb= ddlt_bmlb.SelectedValue.ToString().Trim();//部门类别
            struct_bm.p_fzr= tbx_fzr.Text.ToString().Trim();//负责人
            struct_bm.p_lxdh = tbx_lxdh.Text.ToString().Trim();//联系电话
            struct_bm.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            struct_bm.p_czfs = "01";
            struct_bm.p_czxx = "位置：后台管理->部门管理->添加 描述：部门代码：【" + struct_bm.p_bmdm + "】      " + " 部门名称：【" + struct_bm.p_bmmc + "】      "
                + " 上级部门代码：【" + struct_bm.p_sjbmdm + "】" + " 部门类别：【" + struct_bm.p_bmlb + "】" + " 负责人：【" + struct_bm.p_fzr + "】"
                 + " 联系电话：【" + struct_bm.p_lxdh + "】" + " 状态：【" + struct_bm.p_zt + "】";
            bmgw.Insert_BM(struct_bm);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
         

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
            Response.Redirect("../HouTai/BMGL.aspx");
        }
    }
}