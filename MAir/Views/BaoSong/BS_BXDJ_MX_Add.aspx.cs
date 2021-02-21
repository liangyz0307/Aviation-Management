﻿using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Tools;
using System.Text.RegularExpressions;
using System.IO;

namespace CUST.WKG
{
    public partial class BS_BXDJ_MX_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private Struct_Bs_Wxfy_Bxdj_Mx struct_bxdj_mx;
        public WXFY wxfy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            wxfy = new WXFY(_usState);
            if (!IsPostBack)
            { }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string number = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            //string number_int= @"^\d{n,}$ ";//只能输入整数或小数
            #region lable判断
            int flag = 0;
            //人工费明细
            if (tbx_rgfmx.Text == "")
            {
                lbl_rgfmx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_rgfmx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";            
            }
            //人工费数量
            if (tbx_rgfsl.Text == "")
            {
                lbl_rgfsl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_rgfsl.Text.ToString(), number))
                {
                    lbl_rgfsl.Text = "<span style=\"color:#ff0000\">" + "请输入整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_rgfsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //人工费不含税
            if (tbx_rgfbhs.Text == "")
            {
                lbl_rgfbhs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_rgfbhs.Text.ToString(), number))
                {
                    lbl_rgfbhs.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_rgfbhs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //人工费含税
            if (tbx_rgfhs.Text == "")
            {
                lbl_rgfhs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_rgfhs.Text.ToString(), number))
                {
                    lbl_rgfhs.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_rgfhs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //配件名称
            if (tbx_pjmc.Text == "")
            {
                lbl_pjmc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_pjmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //配件数量
            if (tbx_pjsl.Text == "")
            {
                lbl_pjsl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_pjsl.Text.ToString(), number))
                {
                    lbl_pjsl.Text = "<span style=\"color:#ff0000\">" + "请输入整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_pjsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //配件费用不含税
            if (tbx_pjfybhs.Text == "")
            {
                lbl_pjfybhs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_pjfybhs.Text.ToString(), number))
                {
                    lbl_pjfybhs.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_pjfybhs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //配件费用含税
            if (tbx_pjfyhs.Text == "")
            {
                lbl_pjfyhs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_pjfyhs.Text.ToString(), number))
                {
                    lbl_pjfyhs.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_pjfyhs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            if (flag == 1)
            { return; }
            #endregion
            struct_bxdj_mx.p_xmmc = Request.Params["xmmc"].ToString();//项目名称
            struct_bxdj_mx.p_rgfmx = tbx_rgfmx.Text.Trim().ToString();//人工费明细
            struct_bxdj_mx.p_rgfsl = Convert.ToInt32(tbx_rgfsl.Text.Trim().ToString());//人工费数量
            struct_bxdj_mx.p_rgfbhs = Convert.ToDouble(tbx_rgfbhs.Text.Trim().ToString());//人工费不含税
            struct_bxdj_mx.p_rgfhs = Convert.ToDouble(tbx_rgfhs.Text.Trim().ToString());//人工费含税
            struct_bxdj_mx.p_pjmc = tbx_pjmc.Text.Trim().ToString();//配件名称
            struct_bxdj_mx.p_pjsl = Convert.ToInt32(tbx_pjsl.Text.Trim().ToString());//配件数量
            struct_bxdj_mx.p_pjfybhs = Convert.ToDouble(tbx_pjfybhs.Text.Trim().ToString());//配件费用不含税
            struct_bxdj_mx.p_pjfyhs = Convert.ToDouble(tbx_pjfyhs.Text.Trim().ToString());//配件费用含税
            struct_bxdj_mx.p_czfs = "01";//操作方式
            struct_bxdj_mx.p_czxx = "位置：航务综合信息报送系统->维修费用->报销登记（明细）->添加      描述：员工：" + _usState.userLoginName;
            wxfy.Insert_Bs_Bxdj_Mx(struct_bxdj_mx);
           // DataTable dt_mx=wxfy.Select_Bxdj_Mx_ByXmmc(struct_bxdj_mx);
            //int a=0;
            //foreach (DataRow dr in dt_mx.Rows)
            //{
              // a+= Convert.ToInt32(dt_mx.Rows[0]["xmmc"].ToString());
            //}

            Response.Redirect("../BaoSong/BS_WXFY_Bxdj.aspx?xmmc=" + Request.Params["xmmc"].ToString(), true);
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
            Response.Redirect("../BaoSong/BS_WXFY_Bxdj.aspx?xmmc=" + Request.Params["xmmc"].ToString(), true);
        }
    }
}