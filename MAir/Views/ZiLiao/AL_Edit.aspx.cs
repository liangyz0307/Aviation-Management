using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST.Tools;
using CUST.MKG;
using Sys;
using System.IO;


namespace CUST.WKG
{
    public partial class AL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ALK alk;
        public string albh;
        public DataTable dt_detail;
        public Struct_ALK struct_alk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            alk = new ALK(_usState);
            if (!IsPostBack)
            {
                //案例类型1
                ddlt_allx1.DataTextField = "mc";
                ddlt_allx1.DataValueField = "bm";
                ddlt_allx1.DataSource = SysData.ALLX1().Copy();
                ddlt_allx1.DataBind();
                ddlt_allx1.Items.Insert(0, new ListItem("请选择", "-1"));
                //案例类型2
                ddlt_allx2.DataTextField = "mc";
                ddlt_allx2.DataValueField = "bm";
                ddlt_allx2.DataSource = SysData.ALLX2().Copy();
                ddlt_allx2.DataBind();
                ddlt_allx2.Items.Insert(0, new ListItem("请选择", "-1"));
                //案例来源
                ddlt_ally.DataTextField = "mc";
                ddlt_ally.DataValueField = "bm";
                ddlt_ally.DataSource = SysData.ALLY().Copy();
                ddlt_ally.DataBind();
                ddlt_ally.Items.Insert(0, new ListItem("请选择", "-1"));
                //风险等级
                ddlt_aldj.DataTextField = "mc";
                ddlt_aldj.DataValueField = "bm";
                ddlt_aldj.DataSource = SysData.ALDJ().Copy();
                ddlt_aldj.DataBind();
                ddlt_aldj.Items.Insert(0, new ListItem("请选择", "-1"));
                albh = Request.Params["albh"].ToString();
                select_detail();
                show();
                // tbx_fssj.Attributes.Add("readonly", "readonly");

            }
        }
        protected void ddlt_allx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlt_allx2.DataTextField = "mc";
            ddlt_allx2.DataValueField = "bm";
            ddlt_allx2.DataSource = SysData.ALLX2(ddlt_allx1.SelectedValue.ToString()).Copy();
            ddlt_allx2.DataBind();
            ddlt_allx2.Items.Insert(0, new ListItem("全部", "-1"));
        }
        public void show()
        {
            tbx_alm.Enabled = true;
            tbx_alms.Enabled = true;
            tbx_fssj.Enabled = true;
            tbx_alfx.Enabled = true;
            ddlt_aldj.Enabled = true;
            ddlt_allx1.Enabled = true;
            ddlt_allx2.Enabled = true;
            ddlt_ally.Enabled = true;
            btn_save.Visible = true;

        }
        protected void select_detail()
        {
            albh = Request.Params["albh"].ToString();
            dt_detail = alk.Select_ALbyALBH(albh).Tables[0];
            tbx_alm.Text = dt_detail.Rows[0]["alm"].ToString();//案例名
            tbx_fssj.Text = dt_detail.Rows[0]["fssj"].ToString();//案例发生时间
            ddlt_aldj.SelectedValue = dt_detail.Rows[0]["aldj"].ToString();//案例等级
            ddlt_allx1.SelectedValue = dt_detail.Rows[0]["allx1"].ToString();//案例类型1
            ddlt_allx2.SelectedValue = dt_detail.Rows[0]["allx2"].ToString();//案例类型2
            ddlt_ally.SelectedValue = dt_detail.Rows[0]["ally"].ToString();//案例来源
            tbx_alfx.Text = dt_detail.Rows[0]["alfx"].ToString();//案例分析
            tbx_alms.Text = dt_detail.Rows[0]["alms"].ToString();//案例描述
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region MyRegion
            int flag = 0;
            //案例名
            string alm = tbx_alm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(alm))
            {

                lbl_alm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_alm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //案例发生时间
            string fssj = tbx_fssj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(fssj))
            {

                lbl_fssj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //案例发生原因
            string fsyy = tbx_alfx.Text.ToString().Trim();
            if (string.IsNullOrEmpty(fsyy))
            {

                lbl_alfx.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_alfx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //案例描述
            string alms = tbx_alms.Text.ToString().Trim();
            if (string.IsNullOrEmpty(alms))
            {

                lbl_alms.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_alms.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //案例类型
            if (ddlt_allx1.SelectedValue.Trim() == "-1")
            {

                lbl_allx1.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_allx1.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            ////案例类型
            //if (ddlt_allx2.SelectedValue.Trim() == "-1")
            //{

            //    lbl_allx2.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_allx2.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //案例来源
            if (ddlt_ally.SelectedValue.Trim() == "-1")
            {

                lbl_ally.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ally.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //风险等级
            if (ddlt_aldj.SelectedValue.Trim() == "-1")
            {

                lbl_aldj.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_aldj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            #endregion
            int check_rz = 0;
            struct_alk.p_albh = Request.Params["albh"].ToString();
            struct_alk.p_alm = tbx_alm.Text.ToString().Trim();//案例名
            struct_alk.p_allx1 = ddlt_allx1.SelectedValue.ToString().Trim();//案例类型
            struct_alk.p_allx2 = ddlt_allx2.SelectedValue.ToString().Trim();//案例类型
            struct_alk.p_ally = ddlt_ally.SelectedValue.ToString().Trim();//案例来源
            struct_alk.p_aldj = ddlt_aldj.SelectedValue.ToString().Trim();//风险等级
            struct_alk.p_fssj = Convert.ToDateTime(tbx_fssj.Text.ToString().Trim());//发生时间
            struct_alk.p_alfx = tbx_alfx.Text.ToString().Trim();//发生原因
            struct_alk.p_alms = tbx_alms.Text.ToString().Trim();//案例描述
            struct_alk.p_czfs = "01";
            struct_alk.p_czxx = "位置：资料库管理->案例管理->编辑      描述：案例编号：" + struct_alk.p_albh;
            dt_detail = alk.Select_ALbyALBH(struct_alk.p_albh).Tables[0];
            //案例名
            if (struct_alk.p_alm != dt_detail.Rows[0]["alm"].ToString())
            {
                //已修改
                struct_alk.p_czxx += "案例名：【" + dt_detail.Rows[0]["alm"].ToString() + "】->【" + struct_alk.p_alm + "】";
                check_rz = 1;
            }
            //案例类型1
            if (struct_alk.p_allx1 != dt_detail.Rows[0]["allx1"].ToString())
            {
                //已修改
                struct_alk.p_czxx += "案例类型：【" + dt_detail.Rows[0]["allx1"].ToString() + "】->【" + struct_alk.p_allx1 + "】";
                check_rz = 1;
            }
            //案例类型2
            if (struct_alk.p_allx2 != dt_detail.Rows[0]["allx2"].ToString())
            {
                //已修改
                struct_alk.p_czxx += "案例类型：【" + dt_detail.Rows[0]["allx2"].ToString() + "】->【" + struct_alk.p_allx2 + "】";
                check_rz = 1;
            }
            //案例来源
            if (struct_alk.p_ally != dt_detail.Rows[0]["ally"].ToString())
            {
                //已修改
                struct_alk.p_czxx += "案例类型：【" + dt_detail.Rows[0]["ally"].ToString() + "】->【" + struct_alk.p_ally + "】";
                check_rz = 1;
            }
            //案例发生时间
            if (struct_alk.p_fssj != Convert.ToDateTime(dt_detail.Rows[0]["fssj"].ToString()))
            {
                //已修改
                struct_alk.p_czxx += "案例发生时间：【" + dt_detail.Rows[0]["fssj"].ToString() + "】->【" + struct_alk.p_fssj + "】";
                check_rz = 1;
            }
            //风险等级
            if (struct_alk.p_aldj != dt_detail.Rows[0]["aldj"].ToString())
            {
                //已修改
                struct_alk.p_czxx += "风险等级：【" + dt_detail.Rows[0]["aldj"].ToString() + "】->【" + struct_alk.p_aldj + "】";
                check_rz = 1;
            }
            //案例分析
            if (struct_alk.p_alfx != dt_detail.Rows[0]["alfx"].ToString())
            {
                //已修改
                struct_alk.p_czxx += "案例发生原因：【" + dt_detail.Rows[0]["alfx"].ToString() + "】->【" + struct_alk.p_alfx + "】";
                check_rz = 1;
            }
            //案例描述
            if (struct_alk.p_alms != dt_detail.Rows[0]["alms"].ToString())
            {
                //已修改
                struct_alk.p_czxx += "案例描述：【" + dt_detail.Rows[0]["alms"].ToString() + "】->【" + struct_alk.p_alms + "】";
                check_rz = 1;
            }
            if (check_rz == 0)
            {
                struct_alk.p_czxx += "未修改";
                alk.Update_AL(struct_alk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                show();

            }
            else
            {
                alk.Update_AL(struct_alk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                show();

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
            Response.Redirect("../ZiLiao/ALGL.aspx", true);
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            tbx_alm.Enabled = true;
            tbx_alms.Enabled = true;
            tbx_fssj.Enabled = true;
            tbx_alfx.Enabled = true;
            ddlt_aldj.Enabled = true;
            ddlt_allx1.Enabled = true;
            ddlt_allx2.Enabled = true;
            ddlt_ally.Enabled = true;
            btn_save.Visible = true;
        }
    }
}
