﻿using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CUST.WKG
{
    public partial class JLJL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        static string fzrbh;
        static string sjrbh;
        static string csrbh;
        static string zsrbh;
        public int cpage;
        public int psize;
        public bool flag = true;
        public int i = 0;
        private YGJL ygjl;
        private static DataTable dt = new DataTable();
        private Struct_YGJL_Pro struct_YGJL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            ygjl = new YGJL(_usState);
            
            struct_YGJL = new Struct_YGJL_Pro();
            if (!IsPostBack)
            {
                tbx_jlnr.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
                tbx_jlsj.Attributes.Add("readonly", "readonly");
            }
        }
     
        private void ddltBind()
        {
            //奖励种类
            ddlt_jlzl.DataSource = SysData.JLZL().Copy();
            ddlt_jlzl.DataTextField = "mc";
            ddlt_jlzl.DataValueField = "bm";
            ddlt_jlzl.DataBind();
            ddlt_jlzl.Items.Insert(0, new ListItem("请选择", "-1"));

            //奖励等级
            ddlt_jldj.DataSource = SysData.JLDJ().Copy();
            ddlt_jldj.DataTextField = "mc";
            ddlt_jldj.DataValueField = "bm";
            ddlt_jldj.DataBind();
            ddlt_jldj.Items.Insert(0, new ListItem("请选择", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11",_usState.userID,"110502");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();
            ddlt_csr.Items.Insert(0, new ListItem("请选择", "-1"));


            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();
            ddlt_zsr.Items.Insert(0, new ListItem("请选择", "-1"));


            ////数据所在部门
            //DataTable dt_bmdm = SysData.BM("110502", _usState.userID).Copy();
            //ddlt_sjszbm.DataSource = dt_bmdm;
            //ddlt_sjszbm.DataTextField = "bmmc";
            //ddlt_sjszbm.DataValueField = "bmdm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        private void yg_bind()
        {
            DataTable dt_bmdm = SysData.BM("110502", _usState.userID).Copy();
            //DataTable dt_bmdm = SysData.BM().Copy();
            //负责人
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
            //ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();


            //受奖人
            ddlt_bmdm1.DataSource = dt_bmdm;
            ddlt_bmdm1.DataTextField = "bmmc";
            ddlt_bmdm1.DataValueField = "bmdm";
            ddlt_bmdm1.DataBind();
            //ddlt_bmdm1.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm1.DataSource = SysData.GW().Copy();
            ddlt_gwdm1.DataTextField = "mc";
            ddlt_gwdm1.DataValueField = "bm";
            ddlt_gwdm1.DataBind();
            ddlt_gwdm1.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm1 = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm1 = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt1 = new DataTable();
            dt1 = ygjl.Select_YGbyBMGW(bmdm1, gwdm1);
            ddlt_sjr.DataSource = dt1;
            ddlt_sjr.DataTextField = "xm";
            ddlt_sjr.DataValueField = "bh";
            ddlt_sjr.DataBind();
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_fzr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_fzr.Items.Count > 0)
            {
                tbx_fzr.Text = ddlt_fzr.SelectedItem.Text;
                fzrbh = ddlt_fzr.SelectedValue.ToString();
            }
        }


        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sjr.DataSource = dt;
            ddlt_sjr.DataTextField = "xm";
            ddlt_sjr.DataValueField = "bh";
            ddlt_sjr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sjr.DataSource = dt;
            ddlt_sjr.DataTextField = "xm";
            ddlt_sjr.DataValueField = "bh";
            ddlt_sjr.DataBind();
        }

        protected void btn_bc_Click1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            string yg = ddlt_sjr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_sjr.Items.Count > 0)
            {
                tbx_sjr.Text = ddlt_sjr.SelectedItem.Text;
                sjrbh = ddlt_sjr.SelectedValue.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string jlsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            #region MyRegion
            int flag = 0;

            //奖励时间
            if (tbx_jlsj.Text == "")
            {
                lbl_jlsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jlsj.Text.ToString(), jlsj))
                {
                    lbl_jlsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_jlsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //负责人
            if (fzrbh == null)
            {

                lbl_fzr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //授奖人
            if (sjrbh == null)
            {

                lbl_sjr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //奖励种类
            if (ddlt_jlzl.SelectedValue.Trim() == "-1")
            {

                lbl_jlzl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jlzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //奖励等级
            if (ddlt_jldj.SelectedValue.Trim() == "-1")
            {

                lbl_jldj.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jldj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            ////数据所属部门
            //if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            //{

            //    lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //奖励原因
            string jyjlhyy = tbx_jlyy.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jyjlhyy))
            {

                lbl_jlyy.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jlyy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //奖励内容
            string jlnr = tbx_jlnr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jlnr))
            {

                lbl_jlnr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jlnr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1"  || ddlt_csr.SelectedItem.Text.Trim() == "")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1" || ddlt_zsr.SelectedItem.Text.Trim() == "")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            #endregion

            if (tbx_jlsj.Text.Trim().ToString().Equals(""))
            {
                struct_YGJL.p_rqks = new DateTime();
                struct_YGJL.p_rqjs = new DateTime();
            }
            else
            {
                struct_YGJL.p_rqks = DateTime.Parse(tbx_jlsj.Text.Trim().ToString());//开始日期
                struct_YGJL.p_rqjs = DateTime.Parse(tbx_jlsj.Text.Trim().ToString());//结束日期
            }
            struct_YGJL.p_sjr = ddlt_sjr.SelectedValue.ToString().Trim();//受奖人
            struct_YGJL.p_fzr = ddlt_fzr.SelectedValue.ToString().Trim();//负责人
            struct_YGJL.p_jlzl = ddlt_jlzl.SelectedValue.ToString().Trim();//奖励种类
            struct_YGJL.p_jldj = ddlt_jldj.SelectedValue.ToString().Trim();//奖励等级
            struct_YGJL.p_jlyy = tbx_jlyy.Text.ToString().Trim();//奖励原因
            struct_YGJL.p_jlnr = tbx_jlnr.Text.ToString().Trim();//奖励内容
            struct_YGJL.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_YGJL.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_YGJL.p_bmdm = "";//数据所在部门
            struct_YGJL.p_lrr = _usState.userLoginName.ToString();//录入人
            //struct_YGJL.p_sjbs = "0";
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_YGJL.p_lrr.Equals(struct_YGJL.p_csr))
            {
                struct_YGJL.p_sjbs ="0";
                struct_YGJL.p_zt = "2";
                //给终审人添加提示
                SysData.Insert_TSR(struct_YGJL.p_zsr, "11", "1105", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_YGJL.p_lrr.Equals(struct_YGJL.p_zsr))
            {
                struct_YGJL.p_sjbs = "1";
                struct_YGJL.p_zt = "3";
            }
            if (!struct_YGJL.p_lrr.Equals(struct_YGJL.p_csr)&& !struct_YGJL.p_lrr.Equals(struct_YGJL.p_zsr))
            {
                struct_YGJL.p_sjbs = "0";
                struct_YGJL.p_zt = "0";
            }
            struct_YGJL.p_sjc= DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_YGJL.p_czfs = "02";
            struct_YGJL.p_czxx = "位置：员工管理->员工奖励->添加   描述：员工编号：" + _usState.userLoginName
                 + "起始日期：" + struct_YGJL.p_rqks + "截止日期：" + struct_YGJL.p_rqjs
                + "备注：";
            ygjl.Insert_YGJL(struct_YGJL);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("JLGL.aspx?ygbh=" + _usState.userLoginName);
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
            Server.Transfer("JLGL.aspx?ygbh=" + _usState.userLoginName);

        }
    }
}