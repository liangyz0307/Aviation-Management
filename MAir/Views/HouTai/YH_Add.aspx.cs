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
using Sys;

namespace CUST.WKG
{
    public partial class YH_Add : System.Web.UI.Page

    {
        private UserState _usState;
        private string ygbh;
        private YH yh;
        private Struct_YH struct_yh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yh = new YH(_usState);
            if (!IsPostBack)
            {
                bind_dropdownlist();
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
            }
        }
        protected void bind_dropdownlist()
        {

            //类别
            ddlt_lb.DataSource = SysData.YHLB().Copy(); ;
            ddlt_lb.DataTextField = "ms";
            ddlt_lb.DataValueField = "bm";
            ddlt_lb.DataBind();
            ddlt_lb.Items.Insert(0, new ListItem("请选择", "-1"));

            //是否是权限用户
            ddlt_sfsqxyh.DataSource = SysData.SFSQXYH().Copy(); ;
            ddlt_sfsqxyh.DataTextField = "ms";
            ddlt_sfsqxyh.DataValueField = "bm";
            ddlt_sfsqxyh.DataBind();
            ddlt_sfsqxyh.Items.Insert(0, new ListItem("请选择", "-1"));
            //是否启用
            ddlt_sfqy.DataSource = SysData.SFQY().Copy(); ;
            ddlt_sfqy.DataTextField = "ms";
            ddlt_sfqy.DataValueField = "bm";
            ddlt_sfqy.DataBind();
            ddlt_sfqy.Items.Insert(0, new ListItem("请选择", "-1"));
            //是否是管理用户
            ddlt_sfsglyh.DataSource = SysData.SFSGLYH().Copy(); ;
            ddlt_sfsglyh.DataTextField = "ms";
            ddlt_sfsglyh.DataValueField = "bm";
            ddlt_sfsglyh.DataBind();
            ddlt_sfsglyh.Items.Insert(0, new ListItem("请选择", "-1"));
            //所属
            ddlt_ss.DataSource = SysData.ZXDM().Copy(); ;
            ddlt_ss.DataTextField = "ms";
            ddlt_ss.DataValueField = "bm";
            ddlt_ss.DataBind();
            ddlt_ss.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;
            //员工编号
            string bh = tbx_bh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bh))
            {

                lbl_bh.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            if (bh.Length > 10)
            {

                lbl_bh.Text = "<span style=\"color:#ff0000\">" + "错误：员工编号不能超过10位！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //密码
            string mm = tbx_mm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(mm))
            {

                lbl_mm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            //名称
            lbl_mc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //是否是管理用户
           
            if (ddlt_sfsglyh.SelectedValue.Trim() == "-1")
            {

                lbl_sfsglyh.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfsglyh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //是否是权限用户
            if (ddlt_sfsqxyh.SelectedValue.Trim() == "-1")
            {

                lbl_sfsqxyh.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfsqxyh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //是否启用
            if (ddlt_sfqy.SelectedValue.Trim() == "-1")
            {

                lbl_sfqy.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfqy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //序列号
            lbl_xlh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //所属
            if (ddlt_ss.SelectedValue.Trim() == "-1")
            {

                lbl_ss.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ss.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //开始时间结束时间

            if (tbx_kssj.Text!=""&&tbx_jssj.Text=="")
            {
                lbl_jssj.Text = "<span style=\"color:#ff0000\">" + "请输入结束时间！" + "</span>";
                flag = 1;
            }
            if (tbx_jssj.Text != "" && tbx_kssj.Text == "")
            {
                lbl_kssj.Text = "<span style=\"color:#ff0000\">" + "请输入开始时间！" + "</span>";
                flag = 1;
            }
            if (tbx_kssj.Text != "" && tbx_jssj.Text != "")
            {
                DateTime dt_kssj = Convert.ToDateTime(tbx_kssj.Text);
                DateTime dt_jssj = Convert.ToDateTime(tbx_jssj.Text);
                if (dt_kssj > dt_jssj)
                {
                    lbl_kssj.Text = "<span style=\"color:#ff0000\">" + "开始时间要小于结束时间！" + "</span>";
                    flag = 1;
                }
            }
            else
            {
                lbl_kssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                lbl_jssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if(flag==1)
            {
                return;
            }
            #endregion
            struct_yh.p_zh = tbx_bh.Text.ToString().Trim();//用户编号
            struct_yh.p_mm = StrConvert.GetMD5( tbx_mm.Text.ToString().Trim());//密码
            struct_yh.p_lb = ddlt_lb.SelectedValue.ToString().Trim();//类别
            struct_yh.p_mc = tbx_mc.Text.ToString().Trim();//名称
            if (tbx_kssj.Text.ToString().Trim() != "")
            {
                struct_yh.p_yxkssj =Convert.ToDateTime( tbx_kssj.Text);//开始时间
            }
            else {
                DateTime dt = new DateTime();
                struct_yh.p_yxkssj = dt;
            }
            if (tbx_jssj.Text.ToString().Trim() != "")
            {
                struct_yh.p_yxjssj =Convert.ToDateTime(tbx_jssj.Text);//结束时间
            }
            else
            {
                DateTime dt = System.DateTime.Now;
                struct_yh.p_yxjssj = dt;
            }
            struct_yh.p_xlh= tbx_xlh.Text.ToString().Trim();//序列号
            struct_yh.p_ss = ddlt_ss.SelectedValue.ToString().Trim();//所属
                                                                     //是否是权限用户
            struct_yh.p_sfsqxyh = ddlt_sfsqxyh.SelectedValue.ToString().Trim();

            //是否启用
            struct_yh.p_sfqy = ddlt_sfqy.SelectedValue.ToString().Trim();
            //是否启用首次登录

            //是否是管理员用户
            struct_yh.p_sfsglyh = ddlt_sfsglyh.SelectedValue.ToString().Trim();
            struct_yh.p_czfs = "01";
            struct_yh.p_czxx = "位置：后台管理->用户管理->添加 描述：用户编号：【" + struct_yh.p_zh + "】      "
                + " 密码：【" + struct_yh.p_mm + "】      "+ " 类别：【" + struct_yh.p_lb + "】      " 
                +" 名称：【" + struct_yh.p_mc + "】        " + " 开始时间：【" + struct_yh.p_yxkssj + "】        "
                + " 结束时间：【" + struct_yh.p_yxjssj + "】        " + " 是否是权限用户：【" + struct_yh.p_sfsqxyh + "】        "
                + " 是否启用：【" + struct_yh.p_sfqy + "】        " + " 序列号：【" + struct_yh.p_xlh + "】        "
                + " 是否首次登录：【" + struct_yh.p_sfscdl + "】        " + " 所属：【" + struct_yh.p_ss + "】        "
                + " 是否是管理用户：【" + struct_yh.p_sfsglyh + "】        ";

            yh.Insert_YH(struct_yh);
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
            Response.Redirect("../HouTai/YHGL.aspx");
        }
    }
}