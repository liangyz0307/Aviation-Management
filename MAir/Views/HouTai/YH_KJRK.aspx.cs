using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;

namespace CUST.WKG
{
    public partial class YG_KJRK : System.Web.UI.Page
    {
        private UserState _usState;
        public JS js;
        public string yhbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            js = new JS(_usState);
            if (!IsPostBack)
            {
                select_yfp();
                select_wfp();
            }
        }
        private void select_yfp()
        {
            yhbh = Request.Params["BH"].ToString();
            DataTable dt_yfp = new DataTable();
            dt_yfp = js.Select_JS_KJRK(yhbh).Tables[0];
            cbxl_yfpym.DataSource = dt_yfp;
            cbxl_yfpym.DataTextField = "ymmc";
            cbxl_yfpym.DataValueField = "ymdm";
            cbxl_yfpym.DataBind();
        }
        private void select_wfp()
        {
            yhbh = Request.Params["BH"].ToString();
            DataTable dt_wfp = new DataTable();
            dt_wfp = js.Select_JS_WFPKJRK(yhbh).Tables[0];
            cbxl_wfpym.DataSource = dt_wfp;
            cbxl_wfpym.DataTextField = "ymmc";
            cbxl_wfpym.DataValueField = "ymdm";
            cbxl_wfpym.DataBind();
        }
        protected void btn_add_qx_Click(object sender, EventArgs e)
        {           
                for (int j = 0; j < cbxl_wfpym.Items.Count; j++)
                {
                    if (cbxl_wfpym.Items[j].Selected)
                    {
                        string ygbh = Request.Params["BH"].ToString();
                        string ymdm = cbxl_wfpym.Items[j].Value.ToString();
                        js.Insert_FPKJRK(ygbh, ymdm);
                       
                    }
                }
                select_wfp();
                select_yfp();
        }

        protected void btn_del_qx_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbxl_yfpym.Items.Count; i++)
            {               
                    if (cbxl_yfpym.Items[i].Selected)
                    {
                        string ygbh = Request.Params["BH"].ToString();
                        string ymdm = cbxl_yfpym.Items[i].Value.ToString();
                        js.Delete_FPKJRK(ygbh, ymdm);                       
                    }              
            }
            select_yfp();
            select_wfp();
        }

        protected void cbx_wfp_CheckedChanged(object sender, EventArgs e)
        {
            yhbh = Request.Params["BH"].ToString();
            DataTable dt_wfp = new DataTable();
            dt_wfp = js.Select_JS_WFPKJRK(yhbh).Tables[0];
            if (cbxl_wfpym.Items.Count != 0)
            {
                int j = 0;
                if (cbx_wfp.Checked == true)
                {
                    foreach (DataRow dr in dt_wfp.Rows)
                    {
                        cbxl_wfpym.Items[j].Selected = true;
                        j++;
                    }
                }
                else
                {
                    foreach (DataRow dr in dt_wfp.Rows)
                    {
                        cbxl_wfpym.Items[j].Selected = false;
                        j++;
                    }
                }
            }
        }

        protected void cbx_yfp_CheckedChanged(object sender, EventArgs e)
        {
            yhbh = Request.Params["BH"].ToString();
            DataTable dt_yfp = new DataTable();
            dt_yfp = js.Select_JS_KJRK(yhbh).Tables[0];
            if (cbxl_yfpym.Items.Count != 0)
            {
                int j = 0;
                if (cbx_yfp.Checked == true)
                {
                    foreach (DataRow dr in dt_yfp.Rows)
                    {
                        cbxl_yfpym.Items[j].Selected = true;
                        j++;
                    }
                }
                else
                {
                    foreach (DataRow dr in dt_yfp.Rows)
                    {
                        cbxl_yfpym.Items[j].Selected = false;
                        j++;
                    }
                }
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("YHGL.aspx");
        }
    }
}                