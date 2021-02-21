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
using System.IO;
using Sys;
using System.Globalization;

namespace CUST.WKG
{
    public partial class YGCF_Add : System.Web.UI.Page
    {
        private UserState _usState;
        static string fzrbh;
        static string sfrbh;
        static string csrbh;
        static string zsrbh;
        private YGCF ygcf;
        public bool flag = true;
        public int i = 0;
        private static DataTable dt = new DataTable();
        private Struct_YGCF struct_ygcf;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygcf = new YGCF(_usState);
            if (!IsPostBack)
            {
                tbx_cfsj.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
            }
        }
        private void ddltBind()
        {
            //事件种类
            ddlt_sjzl.DataTextField = "mc";
            ddlt_sjzl.DataValueField = "bm";
            ddlt_sjzl.DataSource = SysData.SJZL().Copy();
            ddlt_sjzl.DataBind();
            ddlt_sjzl.Items.Insert(0, new ListItem("请选择", "-1"));
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110402");

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
            //ddlt_sjszbm.DataSource = SysData.BM().Copy();
            //ddlt_sjszbm.DataTextField = "mc";
            //ddlt_sjszbm.DataValueField = "bm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void yg_bind()
        {

            DataTable dt_bmdm = SysData.BM("110402", _usState.userID).Copy();
            //负责人
            //部门
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
          //  ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();

            //受罚人
            //部门
            
            ddlt_bmdm1.DataSource = dt_bmdm;
            ddlt_bmdm1.DataTextField = "bmmc";
            ddlt_bmdm1.DataValueField = "bmdm";
            ddlt_bmdm1.DataBind();
            //岗位代码
            ddlt_gwdm1.DataSource = SysData.GW().Copy();
            ddlt_gwdm1.DataTextField = "mc";
            ddlt_gwdm1.DataValueField = "bm";
            ddlt_gwdm1.DataBind();
            ddlt_gwdm1.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm1 = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm1 = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt1 = new DataTable();
            dt1 = ygcf.Select_YGbyBMGW(bmdm1, gwdm1);
            ddlt_sfr.DataSource = dt1;
            ddlt_sfr.DataTextField = "xm";
            ddlt_sfr.DataValueField = "bh";
            ddlt_sfr.DataBind();
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
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
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
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
                tbx_fzr.Text =ddlt_fzr.SelectedItem.Text ;
                fzrbh = ddlt_fzr.SelectedValue.ToString();
            }
        }

        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sfr.DataSource = dt;
            ddlt_sfr.DataTextField = "xm";
            ddlt_sfr.DataValueField = "bh";
            ddlt_sfr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sfr.DataSource = dt;
            ddlt_sfr.DataTextField = "xm";
            ddlt_sfr.DataValueField = "bh";
            ddlt_sfr.DataBind();
        }
        protected void btn_bc_Click1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            string yg = ddlt_sfr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_sfr.Items.Count > 0)
            {
                tbx_sfr.Text = ddlt_sfr.SelectedItem.Text;
                sfrbh = ddlt_sfr.SelectedValue.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region MyRegion
            int flag = 0;
            //简要经历和原因
            string jyjlhyy = tbx_jyjlhyy.Text.ToString().Trim();
            if (ddlt_sjzl.SelectedValue=="-1")
            {

                lbl_sjzl.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(jyjlhyy))
            {

                lbl_jyjlhyy.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jyjlhyy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //日期
            string cfsj = tbx_cfsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(cfsj))
            {

                lbl_cfsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_cfsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //承担责任
            string cdzr = tbx_cdzr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(cdzr))
            {

                lbl_cdzr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_cdzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //处理意见
            string alms = tbx_clyj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(alms))
            {

                lbl_clyj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_clyj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //事件种类
            if (ddlt_sjzl.SelectedValue.Trim() == "-1")
            {

                lbl_sjzl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            
            //负责人
            string fzr = fzrbh;
            if (string.IsNullOrEmpty(fzr))
            {
                lbl_fzr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //受罚人
            string sfr = sfrbh;
            if (string.IsNullOrEmpty(sfr))
            {
                lbl_sfr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            ////数据所在部门
            //if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            //{

            //    lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //初审人
            if (ddlt_csr.SelectedItem.Text.Trim() == "" || ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedItem.Text.Trim() == "" || ddlt_zsr.SelectedValue.Trim() == "-1")
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
            if (tbx_cfsj.Text.Trim().ToString().Equals(""))
            {
                struct_ygcf.p_kssj = new DateTime();
                struct_ygcf.p_jssj = new DateTime();
            }
            else
            {
                struct_ygcf.p_kssj = DateTime.Parse(tbx_cfsj.Text.Trim().ToString());//开始日期
                struct_ygcf.p_jssj = DateTime.Parse(tbx_cfsj.Text.Trim().ToString());//结束日期
            }
            struct_ygcf.p_sjzl = ddlt_sjzl.SelectedValue.ToString().Trim();//事件种类
            struct_ygcf.p_fzr = ddlt_fzr.SelectedValue.ToString().Trim(); ;//负责人
            struct_ygcf.p_sfr = ddlt_sfr.SelectedValue.ToString().Trim(); ;//受罚人
            struct_ygcf.p_bmdm = ddlt_bmdm1.SelectedValue.ToString().Trim();
            struct_ygcf.p_jyjlhyy = tbx_jyjlhyy.Text.ToString().Trim();//简要经历和原因
            struct_ygcf.p_cdzr = tbx_cdzr.Text.ToString().Trim();//承担责任
            struct_ygcf.p_clyj = tbx_clyj.Text.ToString().Trim();//处理意见
            struct_ygcf.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ygcf.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_ygcf.p_bmdm = "";//数据所在部门
            struct_ygcf.p_lrr = _usState.userLoginName.ToString();//录入人
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr))
            {
                struct_ygcf.p_sjbs = "0";
                struct_ygcf.p_zt = "2";
                SysData.Insert_TSR(struct_ygcf.p_zsr, "11", "1104", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
            {
                struct_ygcf.p_sjbs = "1";
                struct_ygcf.p_zt = "3";
            }
            if (!struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr) && !struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
            {
                struct_ygcf.p_sjbs = "0";
                struct_ygcf.p_zt = "0";
            }
            struct_ygcf.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_ygcf.p_czfs = "02";
            struct_ygcf.p_czxx = "位置：员工管理->员工惩罚->添加   描述：员工编号：" + _usState.userLoginName
                 + "起止日期：" + struct_ygcf.p_kssj + "截止日期：" + struct_ygcf.p_jssj
                + "备注：";
            ygcf.Insert_YGCF(struct_ygcf);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("CFGL.aspx?ygbh=" + _usState.userLoginName);
            tbx_cfsj.Text = "";
            ddlt_sjzl.SelectedValue = "";
            ddlt_fzr.SelectedValue = "";
            tbx_sfr.Text = "";
            tbx_jyjlhyy.Text = "";
            tbx_cdzr.Text = "";
            tbx_clyj.Text = "";
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
            Server.Transfer("CFGL.aspx?ygbh=" + _usState.userLoginName);

        }
    }
}