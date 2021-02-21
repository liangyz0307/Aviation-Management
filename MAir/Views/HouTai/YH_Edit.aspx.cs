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

namespace CUST.WKG
{
    public partial class YH_Edit : System.Web.UI.Page
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
               
                string id = Request.QueryString["id"];
                bind_dropdownlist();
               show();
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
            ddlt_ss.DataSource = SysData.YHLB().Copy(); ;
            ddlt_ss.DataTextField = "ms";
            ddlt_ss.DataValueField = "bm";
            ddlt_ss.DataBind();
            ddlt_ss.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        public void show()
        {
            DataTable dt_detail = new DataTable();
            string id = Request.QueryString["id"];
            dt_detail = yh.Select_YH_Detail(Convert.ToInt32(id));
            lbl_bh.Text = dt_detail.Rows[0]["zh"].ToString().Trim();//用户编号
            tbx_mm.Text = "";//密码
            ddlt_lb.SelectedValue= dt_detail.Rows[0]["lb"].ToString().Trim();//用户类别
            tbx_mc.Text= dt_detail.Rows[0]["mc"].ToString().Trim();//名称
            DateTime dt_kssj = new DateTime();
            dt_kssj = Convert.ToDateTime(dt_detail.Rows[0]["yxkssj"].ToString());
            tbx_kssj.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_kssj);
            // tbx_kssj.Text= dt_detail.Rows[0]["yxkssj"].ToString().Trim();//开始时间
            // tbx_jssj.Text= dt_detail.Rows[0]["yxjssj"].ToString().Trim();//结束时间
            DateTime dt_jssj = new DateTime();
            dt_jssj = Convert.ToDateTime(dt_detail.Rows[0]["yxjssj"].ToString());
            tbx_jssj.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_jssj);
            ddlt_sfsqxyh.SelectedValue = dt_detail.Rows[0]["sfsqxyh"].ToString();//是否是权限用户
            ddlt_sfqy.SelectedValue = dt_detail.Rows[0]["sfqy"].ToString();//是否启用
            ddlt_sfsglyh.SelectedValue= dt_detail.Rows[0]["sfsglyh"].ToString();//是否是管理用户
           
            tbx_xlh.Text = dt_detail.Rows[0]["xlh"].ToString().Trim();
           
            ddlt_ss.SelectedValue = dt_detail.Rows[0]["ss"].ToString().Trim();//所属
           
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;
           
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
            if (tbx_kssj.Text != "" && tbx_jssj.Text == "")
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

                //if (DateTime.ParseExact(tbx_kssj.Text, "yyyymmdd", null) > DateTime.ParseExact(tbx_jssj.Text, "yyyymmdd", null))
                DateTime kssj = Convert.ToDateTime(tbx_kssj.Text);
                DateTime jssj = Convert.ToDateTime(tbx_jssj.Text);
                if (kssj>jssj)
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
            if (flag == 1)
            {
                return ;
            }
            #endregion

            bool check = false;
            DataTable dt_detail = new DataTable();
            string id = Request.QueryString["id"];
            dt_detail = yh.Select_YH_Detail(Convert.ToInt32(id));
            struct_yh.p_id = Convert.ToInt32(id);
            struct_yh.p_zh = lbl_bh.Text.ToString().Trim();//用户编号
            struct_yh.p_czfs = "02";
            struct_yh.p_czxx ="位置：系统管理->用户管理->编辑    [用户编号：" + struct_yh.p_zh+ "]         描述：";
            string mm = tbx_mm.Text.Trim();
            string oldMM = dt_detail.Rows[0]["mm"].ToString();
            //如果密码不为空
            if (!string.IsNullOrEmpty(mm))
            {
                mm = StrConvert.GetMD5(mm);
                //如果新旧密码不相等，那么就添加日志
                if (!mm.Equals(oldMM))
                {
                    struct_yh.p_czxx += "密码：【" + oldMM + " 】->【" + mm + "】 ";
                    check = true;
                }
                //无论新旧密码是否一致，修改后的密码都是新密码
                struct_yh.p_mm = mm;
            }
            else
            {
                struct_yh.p_mm = oldMM;
            }
            
            struct_yh.p_lb = ddlt_lb.SelectedValue.ToString().Trim();//类别
            if (struct_yh.p_lb!= dt_detail.Rows[0]["lb"].ToString())
            {
                struct_yh.p_czxx += "类别：【" + dt_detail.Rows[0]["lb"].ToString() + " 】->【" + struct_yh.p_lb + "】 ";
                check = true;
            }
            struct_yh.p_mc = tbx_mc.Text.ToString().Trim();//名称
            if (struct_yh.p_mc!=dt_detail.Rows[0]["mc"].ToString())
            {
                struct_yh.p_czxx += "名称：【" + dt_detail.Rows[0]["mc"].ToString() + " 】->【" + struct_yh.p_mc + "】 ";
                check = true;
            }
            // struct_yh.p_yxkssj = DateTime.ParseExact(dt_detail.Rows[0]["yxkssj"].ToString().Trim(), "yyyyMMdd", null);//开始时间
            struct_yh.p_yxkssj = DateTime.Parse(dt_detail.Rows[0]["yxkssj"].ToString().Trim());
            if (tbx_kssj.Text.ToString().Trim() != dt_detail.Rows[0]["yxkssj"].ToString())
            {
                if (tbx_kssj.Text.ToString().Trim() != "")
                {
                    // struct_yh.p_yxkssj = DateTime.ParseExact(tbx_kssj.Text.ToString().Trim(), "yyyyMMdd", null);//开始时间
                    
                    struct_yh.p_yxkssj = DateTime.Parse(tbx_kssj.Text.ToString().Trim());
                    struct_yh.p_czxx += "开始时间：【" + dt_detail.Rows[0]["yxkssj"].ToString() + " 】->【" + struct_yh.p_yxkssj + "】 ";
                    check = true;
                }
                else
                {
                    DateTime dt = new DateTime();
                    struct_yh.p_yxkssj = dt;
                    struct_yh.p_czxx += "开始时间：【" + dt_detail.Rows[0]["yxkssj"].ToString() + " 】->【" + struct_yh.p_yxkssj + "】 ";
                    check = true;
                }
            }


            // struct_yh.p_yxjssj = DateTime.ParseExact(dt_detail.Rows[0]["yxjssj"].ToString().Trim(), "yyyyMMdd", null);//结束时间
            struct_yh.p_yxjssj = DateTime.Parse(dt_detail.Rows[0]["yxjssj"].ToString().Trim());
            if (tbx_jssj.Text.ToString().Trim() != dt_detail.Rows[0]["yxjssj"].ToString())
            {
                if (tbx_jssj.Text.ToString().Trim() != "")
                {
                    // struct_yh.p_yxjssj = DateTime.ParseExact(tbx_jssj.Text.ToString().Trim(), "yyyyMMdd", null);//结束时间
                    struct_yh.p_yxjssj = DateTime.Parse(tbx_jssj.Text.ToString().Trim());
                    struct_yh.p_czxx += "结束时间：【" + dt_detail.Rows[0]["yxjssj"].ToString() + " 】->【" + struct_yh.p_yxjssj + "】 ";
                    check = true;
                }
                else
                {
                    DateTime dt = new DateTime();
                    struct_yh.p_yxjssj = dt;
                    struct_yh.p_czxx += "结束时间：【" + dt_detail.Rows[0]["yxjssj"].ToString() + " 】->【" + struct_yh.p_yxjssj + "】 ";
                    check = true;
                }
            }
            struct_yh.p_xlh = tbx_xlh.Text.ToString().Trim();//序列号
            if (struct_yh.p_xlh!= dt_detail.Rows[0]["xlh"].ToString())
            {
                struct_yh.p_czxx += "序列号：【" + dt_detail.Rows[0]["xlh"].ToString() + " 】->【" + struct_yh.p_xlh + "】 ";
                check = true;
            }
            struct_yh.p_ss = ddlt_ss.SelectedValue.ToString().Trim();//所属
            if (struct_yh.p_ss!= dt_detail.Rows[0]["ss"].ToString())
            {
                struct_yh.p_czxx += "所属：【" + dt_detail.Rows[0]["ss"].ToString() + " 】->【" + struct_yh.p_ss + "】 ";
                check = true;
            }
            //是否是权限用户
            struct_yh.p_sfsqxyh = ddlt_sfsqxyh.SelectedValue.ToString().Trim();//是否是权限用户
            if (struct_yh.p_sfsqxyh != dt_detail.Rows[0]["sfsqxyh"].ToString())
            {
                struct_yh.p_czxx += "是否是权限用户：【" + dt_detail.Rows[0]["sfsqxyh"].ToString() + " 】->【" + struct_yh.p_sfsqxyh + "】 ";
                check = true;
            }


            //是否启用
            struct_yh.p_sfqy = ddlt_sfqy.SelectedValue.ToString().Trim();//是否启用
            if (struct_yh.p_sfqy != dt_detail.Rows[0]["sfqy"].ToString())
            {
                struct_yh.p_czxx += "是否启用：【" + dt_detail.Rows[0]["sfqy"].ToString() + " 】->【" + struct_yh.p_sfqy + "】 ";
                check = true;
            }


            //是否是管理员用户
            struct_yh.p_sfsglyh = ddlt_sfsglyh.SelectedValue.ToString().Trim();//是否是挂
            if (struct_yh.p_sfsglyh != dt_detail.Rows[0]["sfsglyh"].ToString())
            {
                struct_yh.p_czxx += "是否启用：【" + dt_detail.Rows[0]["sfsglyh"].ToString() + " 】->【" + struct_yh.p_sfsglyh + "】 ";
                check = true;
            }

            if (check == false)
            {
                struct_yh.p_czxx += "未修改";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
            
            }
            else { 
            yh.Update_YH(struct_yh);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
          
            
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
            Response.Redirect("YHGL.aspx");
        }

        //protected void btn_bj_Command(object sender, CommandEventArgs e)
        //{
        //    //btn_bj.Visible = false;
        //    //btn_save.Visible = true;
        //}
    }
}