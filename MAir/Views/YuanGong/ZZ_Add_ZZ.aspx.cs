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
using System.Globalization;
using Sys;

namespace CUST.WKG
{
    public partial class ZZ_Add_ZZ : System.Web.UI.Page
    {
        private UserState _usState;
        private string ygbh;
        private YGZZ ygzz;
        private Struct_YGZZ struct_ygzz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../loginAdmin.aspx';</script>");
                Response.End();
                return;
            }
            ygzz = new YGZZ(_usState);
            if (!IsPostBack)
            {
                lbl_bh.Text = Request.Params["ygbh"].ToString();
                tbx_bfrq.Attributes.Add("readonly", "readonly");
                ddltBind();
            }
        }

        private void ddltBind()
        {
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110202");

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

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;
            //执照文件编号
            string zzwjhm = tbx_zzwjhm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zzwjhm))
            {

                lbl_zzwjhm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zzwjhm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //执照编号
            string zzbh = tbx_zzbh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zzbh))
            {

                lbl_zzbh.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zzbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //颁发日期
            string bfrq = tbx_bfrq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bfrq))
            {

                lbl_bfrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bfrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1" || ddlt_csr.SelectedItem.Text.Trim() == "")
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
            struct_ygzz.p_ygbh = lbl_bh.Text;//员工编号
            struct_ygzz.p_zzwjhm = tbx_zzwjhm.Text;//执照文件号码
            struct_ygzz.p_zzbh = tbx_zzbh.Text;//执照编号

            if (tbx_bfrq.Text != "")
            {
                struct_ygzz.p_bfrq = DateTime.Parse(tbx_bfrq.Text);//执照颁发日期
            }
            else
            {
                DateTime dt = new DateTime();
                struct_ygzz.p_bfrq = dt;
            }

          //  struct_ygzz.p_bfrq = tbx_bfrq.Text;//执照颁发日期
            struct_ygzz.lx = "1";
            struct_ygzz.p_bz = tbx_bz.Text;//备注
            struct_ygzz.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_ygzz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ygzz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            //struct_ygzz.p_sjbs = "0";
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr))
            {
                struct_ygzz.p_sjbs = "0";
                struct_ygzz.p_zt = "2";
                //给终审人添加提示
                SysData.Insert_TSR(struct_ygzz.p_zsr, "11", "1102", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
            {
                struct_ygzz.p_sjbs = "1";
                struct_ygzz.p_zt = "3";
            }
            if (!struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr) && !struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
            {
                struct_ygzz.p_sjbs = "0";
                struct_ygzz.p_zt = "0";
            }
            struct_ygzz.p_bhyy = "";
            struct_ygzz.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_ygzz.p_bz = tbx_bz.Text;//备注
            //struct_ygzz.p_zzzt = ddlt_zzzt.SelectedValue.ToString().Trim();//资质状态
            struct_ygzz.p_czfs = "01";
            struct_ygzz.p_czxx = "位置：员工管理->资质管理->添加    描述：员工编号："+ struct_ygzz.p_ygbh+"执照文件号码："+ struct_ygzz.p_zzwjhm
                + "执照编号："+ struct_ygzz.p_zzbh+"执照颁发日期："+struct_ygzz.p_bfrq+ "备注："+ struct_ygzz.p_bz;
            
            ygzz.Insert_YGZZ_ZZ(struct_ygzz);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Response.Redirect("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);
            tbx_bfrq.Text = "";
            tbx_bz.Text = "";
           
            tbx_zzbh.Text = "";
            tbx_zzwjhm.Text = "";
           

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
            Response.Redirect("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);
        }




    }
}