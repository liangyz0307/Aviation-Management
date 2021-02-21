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
    public partial class TZSB_FHSB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        public bool flag = true;
        private string tzbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tzsb = new TZSB(_usState);
            if (!IsPostBack)
            {
                tbx_jcdqsj.Attributes.Add("readonly", "readonly");
                bind_drop();
                tzbh = Request.Params["tzbh"].ToString();
            }
        }
        private void bind_drop()
        {
            //是否配备
            ddlt_mhsblx.DataTextField = "mc";
            ddlt_mhsblx.DataValueField = "bm";
            ddlt_mhsblx.DataSource = SysData.MHSBLX().Copy();
            ddlt_mhsblx.DataBind();
            ddlt_mhsblx.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string tzbh = Request.Params["tzbh"].ToString();
            string mhsblx = ddlt_mhsblx.SelectedValue.ToString();
            string jcdqsj = tbx_jcdqsj.Text.ToString();
            string mhqgs = tbx_mhqgs.Text.ToString();
            
            try
            {
                struct_tzsb.p_tzbh = tzbh;
                struct_tzsb.p_mhsblx = mhsblx;
                struct_tzsb.p_jcdqsj = DateTime.Parse(tbx_jcdqsj.Text.ToString());
                struct_tzsb.p_mhqgs = mhqgs;
                //路径
                struct_tzsb.p_czfs = "01";
                struct_tzsb.p_czxx = "位置：设备管理->台站设备->防火设备添加 灭火设备类型："; /*+ struct_tzsb.p_mhsblx + " 监测到期时间：" + struct_tzsb.p_jcdqsj +
                    "灭火器个数：" + struct_tzsb.p_mhqgs;*/ ;
                tzsb.Insert_TZ_FHSB(struct_tzsb);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        protected void btn_gb_Click1(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBTZ_CZ.aspx?tzbh=" + Request.Params["tzbh"].ToString());
        }
    }
}










