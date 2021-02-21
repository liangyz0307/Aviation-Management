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
    public partial class ZZ_Add_QZ : System.Web.UI.Page
    {
        private UserState _usState;
        //private string ygbh;
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
                bind_dropdownlist();
                tbx_zclbyxq.Attributes.Add("readonly", "readonly");
                tbx_ydqzyxq.Attributes.Add("readonly", "readonly");
                tbx_tjyxq.Attributes.Add("readonly", "readonly");
                show();
                ddltBind();
            }
        }
        public void show()
        {
            qzlb.Visible = false;
            zzqzd.Visible = false;
            ydqz.Visible = false;
            ydqzx.Visible = false;
            ydqzd.Visible = false;
            ydqzyxq.Visible = false;
            tjdj.Visible = false;
            tjyxq.Visible = false;
        }
        private void ddltBind()
        {
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID,"110202");

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
        protected void bind_dropdownlist()
        {
           


            //签注专业
            ddlt_qzzy.DataTextField = "mc";
            ddlt_qzzy.DataValueField = "bm";
            ddlt_qzzy.DataSource = SysData.QZZY().Copy();
            ddlt_qzzy.DataBind();
            ddlt_qzzy.Items.Insert(0, new ListItem("请选择", "-1"));


            //执照签注类别
            DataTable dt_zzqzlb = new DataTable();
            ddlt_zzqzlb.DataSource = dt_zzqzlb;
            ddlt_zzqzlb.DataBind();
            ddlt_zzqzlb.Items.Insert(0, new ListItem("请选择", "-1"));

            //异地签注
            ddlt_ydqz.DataTextField = "mc";
            ddlt_ydqz.DataValueField = "bm";
            ddlt_ydqz.DataSource = SysData.YDQZ().Copy();
            ddlt_ydqz.DataBind();
            ddlt_ydqz.Items.Insert(0, new ListItem("请选择", "-1"));

           

            

            //体检等级
            ddlt_tjdj.DataTextField = "mc";
            ddlt_tjdj.DataValueField = "bm";
            ddlt_tjdj.DataSource = SysData.TJDJ().Copy();
            ddlt_tjdj.DataBind();
            ddlt_tjdj.Items.Insert(0, new ListItem("请选择", "-1"));

            //执照签注项
          
            DataTable dt_zzqzx = new DataTable();
            ddlt_zzqzx.DataSource = dt_zzqzx;
            ddlt_zzqzx.DataBind();
            ddlt_zzqzx.Items.Insert(0, new ListItem("请选择", "-1"));
            //异地签注项
            DataTable dt_ydqzx = new DataTable();
            ddlt_ydqzx.DataSource = dt_ydqzx;
            ddlt_ydqzx.DataBind();
            ddlt_ydqzx.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        public void ZZQZLB(string qzzy) 
        {
            if (qzzy == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_zzqzlb.DataSource = dt;
                ddlt_zzqzlb.DataBind();
                ddlt_zzqzlb.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                //执照签注类别
                DataTable dt_zzqzlb = new DataTable();
                ddlt_zzqzlb.DataTextField = "mc";
                ddlt_zzqzlb.DataValueField = "bm";
                ddlt_zzqzlb.DataSource = SysData.ZZQZLB(qzzy).Copy();
                ddlt_zzqzlb.DataBind();
                ddlt_zzqzlb.Items.Insert(0, new ListItem("请选择", "-1"));
                if (qzzy == "1")
                {
                    // qzlb.Attributes.Add("style","display:none");
                    qzlb.Visible = false;//不显示

                    //执照签注项
                    ddlt_zzqzx.DataTextField = "mc";
                    ddlt_zzqzx.DataValueField = "bm";
                    ddlt_zzqzx.DataSource = SysData.ZZQZX("10").Copy();
                    ddlt_zzqzx.DataBind();
                    ddlt_zzqzx.Items.Insert(0, new ListItem("请选择", "-1"));
                    //异地签注项
                    ddlt_ydqzx.DataTextField = "mc";
                    ddlt_ydqzx.DataValueField = "bm";
                    ddlt_ydqzx.DataSource = SysData.ZZQZX("10").Copy();
                    ddlt_ydqzx.DataBind();
                    ddlt_ydqzx.Items.Insert(0, new ListItem("请选择", "-1"));

                    //zzqzd.Attributes.Add("style", "display:inline");
                    zzqzd.Visible = true;//显示执照签注地
                    ydqz.Visible = true;
                   
                    tjdj.Visible = true;
                    tjyxq.Visible = true;
                }
                else 
                {
                    qzlb.Visible = true;
                    zzqzd.Visible = false;
                    ydqz.Visible = false;
                    ydqzx.Visible = false;
                    ydqzd.Visible = false;
                    ydqzyxq.Visible = false;
                    tjdj.Visible = false;
                    tjyxq.Visible = false;
                }
             

            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;
           
            //签注专业

           
            if (ddlt_qzzy.SelectedValue.Trim() == "-1")
            {

                lbl_qzzy.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else if (ddlt_qzzy.SelectedValue.Trim() == "1")
            {
                lbl_qzzy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                //执照签注地
                string zzqzd = tbx_zzqzd.Text.ToString().Trim();
                if (string.IsNullOrEmpty(zzqzd))
                {

                    lbl_zzqzd.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zzqzd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //异地签注
                if (ddlt_ydqz.SelectedValue.Trim() == "-1")
                {

                    lbl_ydqz.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else if (ddlt_ydqz.SelectedValue.Trim() == "0")
                {

                    lbl_ydqz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                   
                }
                else if (ddlt_ydqz.SelectedValue.Trim() == "1")
                {
                    lbl_ydqz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                    //异地签注项
                    if (ddlt_ydqzx.SelectedValue.Trim() == "-1")
                    {

                        lbl_ydqzx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_ydqzx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                    }
                    //异地签注地
                    string ydqzd = tbx_ydqzd.Text.ToString().Trim();
                    if (string.IsNullOrEmpty(ydqzd))
                    {

                        lbl_ydqzd.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_ydqzd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    }
                    //异地签注有效期
                    string ydqzyxq = tbx_ydqzyxq.Text.ToString().Trim();
                    if (string.IsNullOrEmpty(ydqzyxq))
                    {

                        lbl_ydqzyxq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_ydqzyxq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    }
                }
                //体检等级
                if (ddlt_tjdj.SelectedValue.Trim() == "-1")
                {

                    lbl_tjdj.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tjdj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
                //体检等级有效期
                string tjyxq = tbx_tjyxq.Text.ToString().Trim();
                if (string.IsNullOrEmpty(tjyxq))
                {

                    lbl_tjyxq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tjyxq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

            }
            else if (ddlt_qzzy.SelectedValue.Trim() == "2"||ddlt_qzzy.SelectedValue.Trim() == "0")
            {
                lbl_qzzy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                //签注类别
                if (ddlt_zzqzlb.SelectedValue.Trim() == "-1")
                {

                    lbl_zzqzlb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zzqzlb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
            }
            //签注项
            if (ddlt_zzqzx.SelectedValue.Trim() == "-1")
            {

                lbl_zzqzx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zzqzx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            string zclbyxq = tbx_zclbyxq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zclbyxq))
            {

                lbl_zclbyxq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zclbyxq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
          
            struct_ygzz.p_qzzy = ddlt_qzzy.SelectedValue.ToString();//签注专业

            if (ddlt_zzqzlb.SelectedValue == "-1")
            {
                struct_ygzz.p_zzqzlb = "";//执照签注类别
            }
            else
            {
                struct_ygzz.p_zzqzlb = ddlt_zzqzlb.SelectedValue;//执照签注类别
            }
            if (tbx_zclbyxq.Text != "")
            {
                struct_ygzz.p_zclbyxq = DateTime.Parse(tbx_zclbyxq.Text);//注册类别有效期
            }
            else
            {
                DateTime dt = new DateTime();
                struct_ygzz.p_zclbyxq = dt;
            }
            if (ddlt_ydqz.SelectedValue == "-1")
            {
                struct_ygzz.p_ydqz = "";//异地签注
                struct_ygzz.p_ydqzx = "";
            }
            else
            {
                struct_ygzz.p_ydqz = ddlt_ydqz.SelectedValue;//异地签注
                struct_ygzz.p_ydqzx = ddlt_ydqzx.SelectedValue;
            }
           
            if (tbx_ydqzyxq.Text != "")
            {
                struct_ygzz.p_ydqzyxq = DateTime.Parse(tbx_ydqzyxq.Text);//异地签注有效期
            }
            else
            {
                DateTime dt = new DateTime();
                struct_ygzz.p_ydqzyxq = dt;
            }
            if (ddlt_tjdj.SelectedValue.ToString() == "-1")
            {
                struct_ygzz.p_tjdj = "";//体检等级
            }
            else { 
            struct_ygzz.p_tjdj = ddlt_tjdj.SelectedValue.ToString();//体检等级
            }
            if (tbx_tjyxq.Text.ToString().Trim() != "")
            {
                struct_ygzz.p_tjyxq = DateTime.Parse(tbx_tjyxq.Text.ToString().Trim());//体检有效期
            }
            else
            {
                DateTime dt = new DateTime();
                struct_ygzz.p_tjyxq = dt;
            }
            struct_ygzz.p_bz = tbx_bz.Text;//备注
            struct_ygzz.p_czfs = "01";
            struct_ygzz.lx = "2";
            if (ddlt_zzqzx.SelectedValue == "-1")
            {
                struct_ygzz.p_zzqzx = "";//执照签注项
            }
            else
            {
                struct_ygzz.p_zzqzx = ddlt_zzqzx.SelectedValue;//执照签注项
            }
           // struct_ygzz.p_zzqzx = ddlt_zzqzx.SelectedValue.ToString().Trim();
            struct_ygzz.p_zzqzd = tbx_zzqzd.Text.ToString().Trim();
            //struct_ygzz.p_ydqzx = ddlt_ydqzx.SelectedValue.ToString().Trim();
            struct_ygzz.p_ydqzd = tbx_ydqzd.Text.ToString().Trim();
            struct_ygzz.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_ygzz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ygzz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
           // struct_ygzz.p_sjbs = "0";
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
            struct_ygzz.p_czxx = "位置：员工管理->资质管理->添加    描述：员工编号："+ struct_ygzz.p_ygbh+"签注专业："+ struct_ygzz.p_qzzy
                +"执照签注类别:"+ struct_ygzz.p_zzqzlb+ "注册类别有效期："+ struct_ygzz.p_zclbyxq+ "异地签注:"+ struct_ygzz.p_ydqz
                + "异地签注项:"+ struct_ygzz.p_ydqzx+ "异地签注有效期:"+ struct_ygzz.p_ydqzyxq+ "体检等级:"+ struct_ygzz.p_tjdj
                + "体检有效期" + struct_ygzz.p_tjyxq + "备注："+ struct_ygzz.p_bz;
            
            ygzz.Insert_YGZZ_QZ(struct_ygzz);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Response.Redirect("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);

            tbx_bz.Text = "";
            tbx_tjyxq.Text = "";
            tbx_ydqzyxq.Text = "";
            tbx_zclbyxq.Text = "";
            ddlt_qzzy.SelectedValue = "-1";
            ddlt_tjdj.SelectedValue = "-1";
            ddlt_ydqz.SelectedValue = "-1";
            ddlt_ydqzx.SelectedValue = "-1";
            ddlt_zzqzlb.SelectedValue = "-1";

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

        protected void ddlt_qzzy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qzzy = ddlt_qzzy.SelectedValue.ToString().Trim();
            ZZQZLB(qzzy);
        }

        protected void ddlt_ydqz_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ydqz = ddlt_ydqz.SelectedValue.ToString().Trim();
            //0否1是
            if (ydqz == "1")
            {
                ydqzx.Visible = true;
                ydqzd.Visible = true;
                ydqzyxq.Visible = true;
            }
            else
            {
                ydqzx.Visible = false;
                ydqzd.Visible = false;
                ydqzyxq.Visible = false;
            }
        }
        protected void ddlt_zzqzlb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zzqzlb = ddlt_zzqzlb.SelectedValue.ToString().Trim();

            //签注项
            ddlt_zzqzx.DataTextField = "mc";
            ddlt_zzqzx.DataValueField = "bm";
            ddlt_zzqzx.DataSource = SysData.ZZQZX(zzqzlb).Copy();
            ddlt_zzqzx.DataBind();
            ddlt_zzqzx.Items.Insert(0, new ListItem("请选择", "-1"));

            //异地签注项
            ddlt_ydqzx.DataTextField = "mc";
                ddlt_ydqzx.DataValueField = "bm";
                ddlt_ydqzx.DataSource = SysData.ZZQZX(zzqzlb).Copy();
                ddlt_ydqzx.DataBind();
                ddlt_ydqzx.Items.Insert(0, new ListItem("请选择", "-1"));
          
        }
    }
}