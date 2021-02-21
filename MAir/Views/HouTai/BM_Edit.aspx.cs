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
    public partial class BM_Edit : System.Web.UI.Page
    {

        private UserState _usState;
        private string bmdm;
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
               
                 bmdm = Request.QueryString["bmdm"];
                show(bmdm);
                dataBind();

            }
        }
        public void show(string bmdm)
        {
            DataTable dt = new DataTable();
            dt = bmgw.Select_BMbyBMDM(bmdm).Tables[0];
           lbl_bmdm.Text= dt.Rows[0]["bmdm"].ToString().Trim();
            tbx_bmmc.Text = dt.Rows[0]["bmmc"].ToString().Trim();
            ddlt_sjbm.SelectedValue= dt.Rows[0]["sjbmdm"].ToString().Trim();
            ddlt_bmlb.SelectedValue = dt.Rows[0]["bmlb"].ToString().Trim();
            tbx_fzr.Text = dt.Rows[0]["fzr"].ToString().Trim();
            tbx_lxdh.Text = dt.Rows[0]["lxdh"].ToString().Trim();
            ddlt_zt.SelectedValue = dt.Rows[0]["zt"].ToString().Trim();
        }
        public void dataBind()
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

            bool check = false;
            struct_bm.p_bmdm = Request.QueryString["bmdm"];
            DataTable dt_detail = new DataTable();
            dt_detail = bmgw.Select_BMbyBMDM(struct_bm.p_bmdm).Tables[0];
            struct_bm.p_bmmc = tbx_bmmc.Text.ToString().Trim();
            struct_bm.p_fzr= tbx_fzr.Text.ToString().Trim();
            struct_bm.p_lxdh = tbx_lxdh.Text.ToString().Trim();
            struct_bm.p_sjbmdm = ddlt_sjbm.SelectedValue.ToString().Trim();
            struct_bm.p_bmlb = ddlt_bmlb.SelectedValue.ToString().Trim();
            struct_bm.p_zt = ddlt_zt.SelectedValue.ToString().Trim();
            struct_bm.p_czfs = "02";
            struct_bm.p_czxx = "位置：系统管理->部门管理->编辑    [部门代码：" + struct_bm.p_bmdm  + "]         描述：";

            if (struct_bm.p_bmmc!=dt_detail.Rows[0]["bmmc"].ToString())
            {
                struct_bm.p_czxx += "部门名称：【" + dt_detail.Rows[0]["bmmc"].ToString() + "】->【" + struct_bm.p_bmmc + "】";
                check = true;
            }
            if (struct_bm.p_sjbmdm != dt_detail.Rows[0]["sjbmdm"].ToString())
            {
                struct_bm.p_czxx += "上级部门：【" + dt_detail.Rows[0]["sjbmdm"].ToString() + "】->【" + struct_bm.p_sjbmdm + "】";
                check = true;
            }
            if (struct_bm.p_bmlb != dt_detail.Rows[0]["bmlb"].ToString())
            {
                struct_bm.p_czxx += "部门类别：【" + dt_detail.Rows[0]["bmlb"].ToString() + "】->【" + struct_bm.p_bmlb + "】";
                check = true;
            }
            if (struct_bm.p_fzr != dt_detail.Rows[0]["fzr"].ToString())
            {
                struct_bm.p_czxx += "负责人：【" + dt_detail.Rows[0]["fzr"].ToString() + "】->【" + struct_bm.p_fzr + "】";
                check = true;
            }
            if (struct_bm.p_lxdh != dt_detail.Rows[0]["lxdh"].ToString())
            {
                struct_bm.p_czxx += "联系电话：【" + dt_detail.Rows[0]["lxdh"].ToString() + "】->【" + struct_bm.p_lxdh + "】";
                check = true;
            }
            if (struct_bm.p_zt != dt_detail.Rows[0]["zt"].ToString())
            {
                struct_bm.p_czxx += "状态：【" + dt_detail.Rows[0]["zt"].ToString() + "】->【" + struct_bm.p_zt + "】";
                check = true;
            }
            if (check == false)
            {
                struct_bm.p_czxx += "未修改";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                btn_bj.Visible = true;
                btn_save.Visible = false;

            }
            else {
        
            bmgw.Update_BM(struct_bm);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                btn_bj.Visible = true;
                btn_save.Visible = false;
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
            Response.Redirect("../HouTai/BMGL.aspx");
        }

        protected void btn_bj_Command(object sender, CommandEventArgs e)
        {
            btn_bj.Visible = false;
            btn_save.Visible = true;
        }
    }
}