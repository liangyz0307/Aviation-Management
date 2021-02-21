using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MAir.Views.YuanGong
{
    public partial class ZZ_Edit_QZ : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private YGZZ ygzz;
        private Struct_YGZZ struct_ygzz;
        private DataTable dt_detail;
        private string sjc;
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
                id = Request.Params["id"].ToString();
                tbx_zclbyxq.Attributes.Add("readonly", "readonly");
                tbx_ydqzyxq.Attributes.Add("readonly", "readonly");
                tbx_tjyxq.Attributes.Add("readonly", "readonly");
                show();
                bind_dropdownlist();
                select_detail();
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
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110203");

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
            if (ddlt_qzzy.SelectedValue == "-1")
            {
                DataTable dt_zzqzlb = new DataTable();
                ddlt_zzqzlb.DataSource = dt_zzqzlb;
                ddlt_zzqzlb.DataBind();
                ddlt_zzqzlb.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                //执照签注类别

                ddlt_zzqzlb.DataTextField = "mc";
                ddlt_zzqzlb.DataValueField = "bm";
                ddlt_zzqzlb.DataSource = SysData.ZZQZLB(ddlt_qzzy.SelectedValue).Copy();
                ddlt_zzqzlb.DataBind();
                ddlt_zzqzlb.Items.Insert(0, new ListItem("请选择", "-1"));
            }
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
            if (ddlt_zzqzlb.SelectedValue == "-1")
            {
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
            else
            {
                //执照签注项
                ddlt_zzqzx.DataTextField = "mc";
                ddlt_zzqzx.DataValueField = "bm";
                ddlt_zzqzx.DataSource = SysData.ZZQZX(ddlt_zzqzlb.SelectedValue).Copy();
                ddlt_zzqzx.DataBind();
                ddlt_zzqzx.Items.Insert(0, new ListItem("请选择", "-1"));

                //异地签注项
                ddlt_ydqzx.DataTextField = "mc";
                ddlt_ydqzx.DataValueField = "bm";
                ddlt_ydqzx.DataSource = SysData.ZZQZX(ddlt_zzqzlb.SelectedValue).Copy();
                ddlt_ydqzx.DataBind();
                ddlt_ydqzx.Items.Insert(0, new ListItem("请选择", "-1"));
            }
          

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
        protected void select_detail()
        {
            dt_detail = ygzz.Select_YGZZByZZID(Convert.ToInt32(id));
            lbl_bh.Text = dt_detail.Rows[0]["ygbh"].ToString();//员工编号
            DateTime dt = new DateTime();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_qzzy.SelectedValue = dt_detail.Rows[0]["s1"].ToString();//签注专业


            if (dt_detail.Rows[0]["s2"].ToString() != "")
            {

                //执照签注类别

                ddlt_zzqzlb.DataTextField = "mc";
                ddlt_zzqzlb.DataValueField = "bm";
                ddlt_zzqzlb.DataSource = SysData.ZZQZLB(ddlt_qzzy.SelectedValue).Copy();
                ddlt_zzqzlb.DataBind();
                ddlt_zzqzlb.Items.Insert(0, new ListItem("请选择", "-1"));

                ddlt_zzqzlb.SelectedValue = dt_detail.Rows[0]["s2"].ToString();//执照签注类别;
                qzlb.Visible = true;//显示
                //执照签注项
                ddlt_zzqzx.DataTextField = "mc";
                ddlt_zzqzx.DataValueField = "bm";
                ddlt_zzqzx.DataSource = SysData.ZZQZX(ddlt_zzqzlb.SelectedValue).Copy();
                ddlt_zzqzx.DataBind();
                ddlt_zzqzx.Items.Insert(0, new ListItem("请选择", "-1"));

                ddlt_zzqzx.SelectedValue = dt_detail.Rows[0]["s3"].ToString();//签注项
            }
            else
            {
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
               // ydqzx.Visible = true;
                ddlt_zzqzx.SelectedValue = dt_detail.Rows[0]["s3"].ToString();//签注项
                ddlt_ydqz.SelectedValue = dt_detail.Rows[0]["s5"].ToString();//异地签注
                if (dt_detail.Rows[0]["s5"].ToString() == "1")
                {
                    ddlt_ydqzx.SelectedValue = dt_detail.Rows[0]["s6"].ToString();//异地签注项
                    ydqzx.Visible = true;
                    tbx_ydqzd.Text = dt_detail.Rows[0]["s7"].ToString();//异地签注地
                    ydqzd.Visible = true;//显示
                }
                //ydqz.Visible = true;
                
            }
           

            if (dt_detail.Rows[0]["d1"].ToString() != dt.ToString())
            {
                DateTime zclbyxq = DateTime.Parse(dt_detail.Rows[0]["d1"].ToString());
                tbx_zclbyxq.Text = zclbyxq.ToString("yyyy-MM-dd");//注册类别有效期
            }
            else
            {
                tbx_zclbyxq.Text = "";
            }
            if (dt_detail.Rows[0]["s4"].ToString() != "")
            {
                tbx_zzqzd.Text = dt_detail.Rows[0]["s4"].ToString();//执照签注地
                zzqzd.Visible = true;//显示
            }
            //if (dt_detail.Rows[0]["s5"].ToString()!="") { 
            //ddlt_ydqz.SelectedValue = dt_detail.Rows[0]["s5"].ToString();//异地签注
            //    ydqz.Visible = true;
            //}
            //if (dt_detail.Rows[0]["s6"].ToString() != "")
            //{
            //    //异地签注项
            //    ddlt_ydqzx.DataTextField = "mc";
            //    ddlt_ydqzx.DataValueField = "bm";
            //    ddlt_ydqzx.DataSource = SysData.ZZQZX(ddlt_zzqzlb.SelectedValue).Copy();
            //    ddlt_ydqzx.DataBind();
            //    ddlt_ydqzx.Items.Insert(0, new ListItem("请选择", "-1"));

            //    ddlt_ydqzx.SelectedValue = dt_detail.Rows[0]["s6"].ToString();//异地签注项
            //    ydqzx.Visible = true;
            //}
            //if (dt_detail.Rows[0]["s7"].ToString() != "")
            //{
            //    tbx_ydqzd.Text = dt_detail.Rows[0]["s7"].ToString();//异地签注地
            //    zzqzd.Visible = true;//显示
            //}
            if (dt_detail.Rows[0]["d2"].ToString() != dt.ToString())
            {
                DateTime ydqzyxq1 = DateTime.Parse(dt_detail.Rows[0]["d2"].ToString());
                tbx_ydqzyxq.Text = ydqzyxq1.ToString("yyyy-MM-dd");//异地签注有效期
                ydqzyxq.Visible = true;
            }
            else
            {
                tbx_ydqzyxq.Text = "";
            }
            if (dt_detail.Rows[0]["s8"].ToString()!="")
            { 
            ddlt_tjdj.SelectedValue = dt_detail.Rows[0]["s8"].ToString();//体检等级
                tjdj.Visible = true;
            }
            if (dt_detail.Rows[0]["d3"].ToString() != dt.ToString())
            {
                DateTime tjdjyxq = DateTime.Parse(dt_detail.Rows[0]["d3"].ToString());
                tbx_tjyxq.Text = tjdjyxq.ToString("yyyy-MM-dd");//体检等级有效期
                tjyxq.Visible = true;
            }
            else
            {
                tbx_tjyxq.Text = "";
            }

            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();//备注
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
            else if (ddlt_qzzy.SelectedValue.Trim() == "2" || ddlt_qzzy.SelectedValue.Trim() == "0")
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
            int check_rz = 0;

            string id = Request.Params["id"].ToString();
            struct_ygzz.p_id = Convert.ToInt32(id);
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
            if (ddlt_zzqzx.SelectedValue == "-1")
            {
                struct_ygzz.p_zzqzx = "";//执照签注项
            }
            else
            {
                struct_ygzz.p_zzqzx = ddlt_zzqzx.SelectedValue;//执照签注项
            }
            if (tbx_zzqzd.Text == "")
            {
                struct_ygzz.p_zzqzd = "";//执照签注地
            }
            else
            {
                struct_ygzz.p_zzqzd = tbx_zzqzd.Text;//执照签注地
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
            }
            else
            {
                struct_ygzz.p_ydqz = ddlt_ydqz.SelectedValue;//异地签注
            }
            if (ddlt_ydqzx.SelectedValue == "-1")
            {
                struct_ygzz.p_ydqzx = "";//异地签注项
            }
            else
            {
                struct_ygzz.p_ydqzx = ddlt_ydqzx.SelectedValue;//异地签注项
            }
            if (tbx_ydqzd.Text== "")
            {
                struct_ygzz.p_ydqzd = "";//异地签注地
            }
            else
            {
                struct_ygzz.p_ydqzd = tbx_ydqzd.Text;//异地签注地
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
            else
            {
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
            struct_ygzz.p_lrr = _usState.userLoginName;//录入人
            struct_ygzz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ygzz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_ygzz.p_bz = tbx_bz.Text;//备注
            struct_ygzz.p_czfs = "02";
            struct_ygzz.p_czxx = "位置：员工管理->资质管理->编辑    员工编号：[" + struct_ygzz.p_ygbh + "]  描述：";
            dt_detail = ygzz.Select_YGZZByZZID(Convert.ToInt32(id));
            //签注专业
            if (struct_ygzz.p_qzzy != dt_detail.Rows[0]["s1"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "签注专业：【" + dt_detail.Rows[0]["s1"].ToString() + "】->【" + struct_ygzz.p_qzzy + "】";
                check_rz = 1;
            }
            //执照签注类别
            if (struct_ygzz.p_zzqzlb != dt_detail.Rows[0]["s2"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "执照签注类别：【" + dt_detail.Rows[0]["s2"].ToString() + "】->【" + struct_ygzz.p_zzqzlb + "】";
                check_rz = 1;
            }
            //执照签注项
            if (struct_ygzz.p_zzqzx != dt_detail.Rows[0]["s3"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "执照签注类别：【" + dt_detail.Rows[0]["s3"].ToString() + "】->【" + struct_ygzz.p_zzqzx + "】";
                check_rz = 1;
            }
            if (dt_detail.Rows[0]["d1"].ToString() != "")
            {
                //注册类别有效期
                if (struct_ygzz.p_zclbyxq != DateTime.Parse(dt_detail.Rows[0]["d1"].ToString()))
                {
                    //已修改
                    struct_ygzz.p_czxx += "注册类别有效期：【" + dt_detail.Rows[0]["d1"].ToString() + "】->【" + struct_ygzz.p_zclbyxq + "】";
                    check_rz = 1;
                }
            }
            //执照签注地
            if (struct_ygzz.p_zzqzd != dt_detail.Rows[0]["s4"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "执照签注地：【" + dt_detail.Rows[0]["s4"].ToString() + "】->【" + struct_ygzz.p_zzqzd + "】";
                check_rz = 1;
            }
            //异地签注
            if (struct_ygzz.p_ydqz != dt_detail.Rows[0]["s5"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "异地签注：【" + dt_detail.Rows[0]["s5"].ToString() + "】->【" + struct_ygzz.p_ydqz + "】";
                check_rz = 1;
            }
            //异地签注项
            if (struct_ygzz.p_ydqzx != dt_detail.Rows[0]["s6"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "异地签注项：【" + dt_detail.Rows[0]["s6"].ToString() + "】->【" + struct_ygzz.p_ydqzx + "】";
                check_rz = 1;
            }
            //异地签注地
            if (struct_ygzz.p_ydqzd != dt_detail.Rows[0]["s7"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "异地签注地：【" + dt_detail.Rows[0]["s7"].ToString() + "】->【" + struct_ygzz.p_ydqzd + "】";
                check_rz = 1;
            }
            if (dt_detail.Rows[0]["d2"].ToString() != "")
            {
                //异地签注有效期
                if (struct_ygzz.p_ydqzyxq != DateTime.Parse(dt_detail.Rows[0]["d2"].ToString()))
                {
                    //已修改
                    struct_ygzz.p_czxx += "异地签注有效期：【" + dt_detail.Rows[0]["d2"].ToString() + "】->【" + struct_ygzz.p_ydqzyxq + "】";
                    check_rz = 1;
                }
            }
            //体检等级
            if (struct_ygzz.p_tjdj != dt_detail.Rows[0]["s8"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "体检等级：【" + dt_detail.Rows[0]["s8"].ToString() + "】->【" + struct_ygzz.p_tjdj + "】";
                check_rz = 1;
            }
            //体检等级有效期
            if (dt_detail.Rows[0]["d3"].ToString() != "")
            {
                if (struct_ygzz.p_tjyxq != DateTime.Parse(dt_detail.Rows[0]["d3"].ToString()))
                {
                    //已修改
                    struct_ygzz.p_czxx += "体检等级有效期：【" + dt_detail.Rows[0]["d3"].ToString() + "】->【" + struct_ygzz.p_tjyxq + "】";
                    check_rz = 1;
                }
            }
           
            //备注
            if (struct_ygzz.p_bz != dt_detail.Rows[0]["bz"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_ygzz.p_bz + "】";
                check_rz = 1;
            }
            
            if (check_rz == 0)
            {
                struct_ygzz.p_czxx += "未修改";
                
            }
            string sjbs = Request.Params["sjbs"].ToString();

           

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr))
                {
                    struct_ygzz.p_zt = "2";
                    struct_ygzz.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "3";
                    struct_ygzz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                if (!struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr) && !struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "0";
                    struct_ygzz.p_sjbs = "0";
                }
                ygzz.Update_YGZZ_QZ(struct_ygzz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr))
                {
                    struct_ygzz.p_zt = "2";
                    struct_ygzz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygzz.p_sjc = sjc;
                    ygzz.Update_YGZZ_SJBS_LSSJ_ZT(struct_ygzz);

                    struct_ygzz.p_zt = "3";
                    struct_ygzz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                if (!struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr) && !struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "0";
                    struct_ygzz.p_sjbs = "2";
                }
                ygzz.Update_YGZZ_QZ(struct_ygzz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Request.Params["id"].ToString();
                int id_bf = ygzz.YGZZ_SJBF(Convert.ToInt32(id));
                struct_ygzz.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr))
                {
                    struct_ygzz.p_zt = "2";
                    struct_ygzz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygzz.p_sjc = sjc;
                    ygzz.Update_YGZZ_SJBS_LSSJ_ZT(struct_ygzz);

                    struct_ygzz.p_zt = "3";
                    struct_ygzz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                if (!struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr) && !struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "0";
                    struct_ygzz.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                ygzz.Update_YGZZ_QZ(struct_ygzz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);


            }

            //if (sjbs.Equals("0") || sjbs.Equals("2"))
            //{
            //    ygzz.Update_YGZZ_QZ(struct_ygzz);
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            //    Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);

            //}
            //else if (sjbs.Equals("1") || sjbs.Equals("3"))
            //{
            //    //生成该数据的副本,并返回新的备份id
            //    id = Request.Params["id"].ToString();
            //    int id_bf = ygzz.YGZZ_SJBF(Convert.ToInt32(id));
            //    struct_ygzz.p_id = id_bf;
            //    ygzz.Update_YGZZ_QZ(struct_ygzz);
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            //    Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);

            //}
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

            //异地签注项
            ddlt_ydqzx.DataTextField = "mc";
            ddlt_ydqzx.DataValueField = "bm";
            ddlt_ydqzx.DataSource = SysData.ZZQZX(zzqzlb).Copy();
            ddlt_ydqzx.DataBind();
            ddlt_ydqzx.Items.Insert(0, new ListItem("请选择", "-1"));

        }

    }
}