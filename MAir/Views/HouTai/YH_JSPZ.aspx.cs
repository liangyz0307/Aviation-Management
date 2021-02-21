
using CUST.MKG;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI;

namespace CUST.WKG
{
    public partial class YH_JSPZ : System.Web.UI.Page
    {

        private UserState _usState;
        private string yhbh;
        private string yhid;
        private YHJS yhrole;
        public DataTable dt_wfp;
        public DataTable dt_yfp;
        private Struct_YH struct_yh;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yhrole = new YHJS(_usState);
            if (!IsPostBack)
            {
                yhbh = Request.Params["bh"].ToString();
                yhid= Request.Params["id"].ToString();
               // lbl_yhbh.Text = yhbh;
                select_detail();
               
            }
        }

      
        protected void select_detail()
        {
           
            dt_wfp = yhrole.Select_YH_WJS(Convert.ToInt32(yhid));

            cbxl_wfpjs.DataSource = dt_wfp;
            cbxl_wfpjs.DataTextField = "jsmc";
            cbxl_wfpjs.DataValueField = "jsdm";
            cbxl_wfpjs.DataBind();

            dt_yfp = yhrole.Select_YH_YJS(Convert.ToInt32(yhid));
            cbxl_yfpjs.DataSource = dt_yfp;
            cbxl_yfpjs.DataTextField = "jsmc";
            cbxl_yfpjs.DataValueField = "jsdm";
            cbxl_yfpjs.DataBind();
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

        protected void btn_add_js_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool flag = true;
           
             yhid = Request.QueryString["id"];
            dt_wfp = yhrole.Select_YH_WJS(Convert.ToInt32(yhid));
            dt_yfp = yhrole.Select_YH_YJS(Convert.ToInt32(yhid));

            if (cbxl_wfpjs.Items.Count != 0)
            {
                foreach (DataRow dr in dt_wfp.Rows)
                {
                    if (cbxl_wfpjs.Items[i].Selected == true)
                    {
                        string jsid = cbxl_wfpjs.Items[i].Value;

                        yhid = Request.QueryString["id"];
                        string czfs = "01";
                        string czxx = "位置：后台管理->用户管理->角色配置添加    描述：用户ID：【" + yhid + "】 分配角色【" + jsid + "】";
                        yhrole.Insert_YH_JS(Convert.ToInt32(yhid), jsid, czfs, czxx);
                        flag = false;


                    }//if  check
                    i++;


                }//foreach

                cbx_wfp.Checked = false;
                if (flag == true)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('请选择要配置的角色！');</script>");
                    return;
                }
                select_detail();

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('请选择要配置的角色！');</script>");
                return;
            }
        }

        protected void btn_del_js_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool flag = true;
          
             yhid = Request.QueryString["id"];
            dt_yfp = yhrole.Select_YH_YJS(Convert.ToInt32(yhid));

            if (cbxl_yfpjs.Items.Count != 0)
            {
                foreach (DataRow dr in dt_yfp.Rows)
                {
                    if (cbxl_yfpjs.Items[i].Selected == true)
                    {

                        string jsid = cbxl_yfpjs.Items[i].Value;
                        string czfs = "03";
                        string czxx = "位置：后台管理->用户管理->角色配置删除    描述：用户ID：【" + yhid + "  】 分配角色【" + jsid + "】";
                        yhrole.Delete_YH_JS(Convert.ToInt32(yhid), jsid, czfs, czxx);
                        flag = false;

                    }
                    i++;
                }//foreach
                cbx_yfp.Checked = false;

                if (flag == true)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('请选择要配置的角色！');</script>");
                    return;
                }
                select_detail();

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('请选择要配置的角色！');</script>");
                return;
            }
        }
        #region 全选

        protected void cbx_wfp_CheckedChanged(object sender, EventArgs e)
        {

            string yhid = Request.QueryString["id"];
           dt_wfp = yhrole.Select_YH_WJS(Convert.ToInt32(yhid));
            if (cbxl_wfpjs.Items.Count != 0)
            {
                int j = 0;
                if (cbx_wfp.Checked == true)
                {
                    foreach (DataRow dr in dt_wfp.Rows)
                    {
                        cbxl_wfpjs.Items[j].Selected = true;
                        j++;
                    }
                }
                else
                {
                    foreach (DataRow dr in dt_wfp.Rows)
                    {
                        cbxl_wfpjs.Items[j].Selected = false;
                        j++;
                    }
                }

            }
        }

        protected void cbx_yfp_CheckedChanged(object sender, EventArgs e)
        {
            string yhid = Request.QueryString["id"];
            dt_yfp = yhrole.Select_YH_YJS(Convert.ToInt32(yhid));
            if (cbxl_yfpjs.Items.Count != 0)
            {

                int j = 0;
                if (cbx_yfp.Checked == true)
                {
                    foreach (DataRow dr in dt_yfp.Rows)
                    {
                        cbxl_yfpjs.Items[j].Selected = true;
                        j++;
                    }
                }
                else
                {
                    foreach (DataRow dr in dt_yfp.Rows)
                    {
                        cbxl_yfpjs.Items[j].Selected = false;
                        j++;
                    }
                }
            }
        }
        #endregion
    }
}