using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace CUST.WKG
{
    public partial class TZSB_FHSB_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private string tzbh;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tzsb = new TZSB(_usState);
            struct_tzsb = new Struct_TZSB();
            tzbh = Request.Params["tzbh"].ToString();
            if (!IsPostBack)
            {
                ddltBind();
                select_detail();
                tzbh = Request.Params["tzbh"].ToString();
            }
        }
        private void ddltBind()
        {
            //是否配备
            ddlt_mhsblx.DataTextField = "mc";
            ddlt_mhsblx.DataValueField = "bm";
            ddlt_mhsblx.DataSource = SysData.MHSBLX().Copy();
            ddlt_mhsblx.DataBind();
            ddlt_mhsblx.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            DataTable dt_detail = tzsb.Select_TZ_FHSB_Detail(id);
            ddlt_mhsblx.SelectedValue = dt_detail.Rows[0]["mhsblx"].ToString();
            tbx_jcdqsj.Text = dt_detail.Rows[0]["jcdqsj"].ToString();
            tbx_mhqgs.Text = dt_detail.Rows[0]["mhqgs"].ToString();

        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Params["id"].ToString());
            string mhsblx = ddlt_mhsblx.SelectedValue.ToString();
            string jcdqsj = tbx_jcdqsj.Text.ToString();
            string mhqgs = tbx_mhqgs.Text.ToString();
            try
            {
                struct_tzsb.p_id = id;
                struct_tzsb.p_mhsblx = mhsblx;
                struct_tzsb.p_jcdqsj = DateTime.Parse(tbx_jcdqsj.Text.ToString());
                struct_tzsb.p_mhqgs = mhqgs;
                struct_tzsb.p_czfs = "02";
                struct_tzsb.p_czxx = "位置：设备管理->防火设备->编辑[设备编号：" + struct_tzsb.p_tzbh + "描述：";
                //if (struct_tzsb.p_mhsblx != dt_row["mhsblx"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["mhsblx"].ToString() + "】->【" + struct_tzsb.p_mhsblx + "】";
                //}

                //if (struct_tzsb.p_jcdqsj != dt_row["jcdqsj"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["jcdqsj"].ToString() + "】->【" + struct_tzsb.p_jcdqsj + "】";
                //}

                //if (struct_tzsb.p_mhqgs != dt_row["mhqgs"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["mhqgs"].ToString() + "】->【" + struct_tzsb.p_mhqgs + "】";
                //}

                tzsb.Update_TZ_FHSB(struct_tzsb);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }

        protected void btn_gb_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Shebei/SBTZ_CZ.aspx?tzbh=" + tzbh);
        }
    }
}