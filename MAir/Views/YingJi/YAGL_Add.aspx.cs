using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using Sys;
using CUST.WKG;

namespace CUST.WKG
{
    public partial class YAGL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        public YAGL yagl;
        private Struct_YAGL struct_yagl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yagl = new YAGL(_usState);
            if (!IsPostBack)
            {
                ddltBind();
            }
        }
        private void ddltBind()
        {

            //绑定地区
            DataTable dt_dq = SysData.ZXDM().Copy();
            ddlt_dq.DataTextField = "mc";
            ddlt_dq.DataValueField = "bm";
            ddlt_dq.DataSource = dt_dq;
            ddlt_dq.DataBind();
            ddlt_dq.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定专业
            DataTable dt_zy = SysData.ZYLX().Copy();
            ddlt_zy.DataTextField = "mc";
            ddlt_zy.DataValueField = "bm";
            ddlt_zy.DataSource = dt_zy;
            ddlt_zy.DataBind();
            ddlt_zy.Items.Insert(0, new ListItem("全部", "-1"));
            ////初始化审批人
            //DataTable dt_spr = SysData.HasThisZXT_SPR("11");

            ////初审人
            //ddlt_csr.DataSource = dt_spr;
            //ddlt_csr.DataTextField = "mc";
            //ddlt_csr.DataValueField = "bm";
            //ddlt_csr.DataBind();
            //ddlt_csr.Items.Insert(0, new ListItem("全部", "-1"));

            ////终审人
            //ddlt_zsr.DataSource = dt_spr;
            //ddlt_zsr.DataTextField = "mc";
            //ddlt_zsr.DataValueField = "bm";
            //ddlt_zsr.DataBind();
            //ddlt_zsr.Items.Insert(0, new ListItem("全部", "-1"));
            ////数据所在部门
            //ddlt_sjszbm.DataSource = SysData.BM().Copy();
            //ddlt_sjszbm.DataTextField = "mc";
            //ddlt_sjszbm.DataValueField = "bm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("18", _usState.userID, "110102");

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


            //数据所在部门
            DataTable dt_bmdm = SysData.BM("180102", _usState.userID).Copy();
            ddlt_sjszbm.DataSource = dt_bmdm;
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        #region 错误信息

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
        #endregion

        protected void btn_bc_Click(object sender, EventArgs e)
        {

            int flag = 0;
            string mc = tbx_mc.Text.Trim().ToString();
            string dq = ddlt_dq.SelectedValue.Trim().ToString();
            string zy = ddlt_zy.SelectedValue.Trim().ToString();
            string yanr = txtEditorContents.Text.ToString().Trim();
            #region lable判断
            if (mc == "")
            {
                lbl_mc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (dq == "-1")
            {
                lbl_dq.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (zy == "-1")
            {
                lbl_zy.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (yanr == "")
            {
                Response.Write("<script>alert('预案内容不能为空')</script>");
                flag = 1;
            }
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1)
            {
                return;
            }
            #endregion
            struct_yagl.p_mc = mc;
            struct_yagl.p_dq = dq;
            struct_yagl.p_zy = zy;
            struct_yagl.p_yanr = yanr;
            struct_yagl.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_yagl.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_yagl.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_yagl.p_sjssbm = ddlt_sjszbm.SelectedValue.ToString().Trim();//终审人
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_yagl.p_lrr.Equals(struct_yagl.p_csr))
            {
                struct_yagl.p_sjbs = "0";
                struct_yagl.p_zt = "2";
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
            {
                struct_yagl.p_sjbs = "1";
                struct_yagl.p_zt = "3";
            }
            if (!struct_yagl.p_lrr.Equals(struct_yagl.p_csr) && !struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
            {
                struct_yagl.p_sjbs = "0";
                struct_yagl.p_zt = "0";
            }
            struct_yagl.p_bhyy = "";
            struct_yagl.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_yagl.p_czfs = "01";
           struct_yagl.p_czxx = "位置：应急管理->预案管理->添加 描述： 录入人：" + _usState.userLoginName.ToString() + "名称：【" + struct_yagl.p_mc + "】    " + "地区：【" + struct_yagl.p_dq + "】  "
                + " 专业：【" + struct_yagl.p_zy + "】" + " 预案内容：【" + struct_yagl.p_yanr + "】";
            yagl.Insert_YJ_YAGL_Proc(struct_yagl);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
           // Server.Transfer("YAGL.aspx?ygbh=" + lbl_bh.Text);
            //struct_yagl.p_czfs = "01";
            //struct_yagl.p_czxx = "位置：应急管理->预案管理->添加 描述：名称：【" + struct_yagl.p_mc + "】    " + "地区：【" + struct_yagl.p_dq + "】  "
            //     + " 专业：【" + struct_yagl.p_zy + "】" + " 预案内容：【" + struct_yagl.p_yanr + "】";
            //yagl.Insert_YJ_YAGL_Proc(struct_yagl);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            #region 清除数据
            tbx_mc.Text = "";
            ddlt_dq.SelectedValue = "-1";
            ddlt_zy.SelectedValue = "-1";
            ddlt_csr.SelectedValue = "-1";
            ddlt_zsr.SelectedValue = "-1";
            ddlt_sjszbm.SelectedValue = "-1";
            txtEditorContents.Text = "";
            lbl_mc.Text = "";
            lbl_dq.Text = "";
            lbl_zy.Text = "";
            lbl_csr.Text = "";
            lbl_sjszbm.Text = "";
            lbl_zsr.Text = "";
            
            #endregion
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Yingji/YJ_YAGL.aspx");
        }

    }
}