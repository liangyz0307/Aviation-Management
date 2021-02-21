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
    public partial class TZSB_MSCS_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        public bool flag = true;
        private int i;
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
                tbx_fljcdqrq.Attributes.Add("readonly", "readonly");
                bind_drop();
                tzbh=Request.Params["tzbh"].ToString();

            }
        }
        private void bind_drop()
        {
            //挡鼠板
            ddlt_dsb.DataTextField = "mc";
            ddlt_dsb.DataValueField = "bm";
            ddlt_dsb.DataSource = SysData.SFJB().Copy();
            ddlt_dsb.DataBind();
            ddlt_dsb.Items.Insert(0, new ListItem("请选择", "-1"));
            //防洪措施是否具备
            ddlt_fh.DataTextField = "mc";
            ddlt_fh.DataValueField = "bm";
            ddlt_fh.DataSource = SysData.SFJB().Copy();
            ddlt_fh.DataBind();
            ddlt_fh.Items.Insert(0, new ListItem("请选择", "-1"));
            //防盗措施是否具备
            ddlt_fd.DataTextField = "mc";
            ddlt_fd.DataValueField = "bm";
            ddlt_fd.DataSource = SysData.SFJB().Copy();
            ddlt_fd.DataBind();
            ddlt_fd.Items.Insert(0, new ListItem("请选择", "-1"));
            //维修工具是否满足该设备故障时紧急维修需求
            ddlt_wxgj.DataTextField = "mc";
            ddlt_wxgj.DataValueField = "bm";
            ddlt_wxgj.DataSource = SysData.SFJB().Copy();
            ddlt_wxgj.DataBind();
            ddlt_wxgj.Items.Insert(0, new ListItem("请选择", "-1"));
            //是否有地暖
            ddlt_sfydn.DataTextField = "mc";
            ddlt_sfydn.DataValueField = "bm";
            ddlt_sfydn.DataSource = SysData.SFJB().Copy();
            ddlt_sfydn.DataBind();
            ddlt_sfydn.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string tzbh = Request.Params["tzbh"].ToString();
            string dsb = ddlt_dsb.SelectedValue.ToString();
            string zsbgs = tbx_zsbgs.Text.ToString();
            string qtcs = tbx_qtcs.Text.ToString();
            string fh = ddlt_fh.SelectedValue.ToString();
            string fd = ddlt_fd.SelectedValue.ToString();
            string wxgj = ddlt_wxgj.SelectedValue.ToString();
            string jfflcs = tbx_jfflcs.Text.ToString();
            string fljcdqrq = tbx_fljcdqrq.Text.ToString();
            string sfydn = ddlt_sfydn.SelectedValue.ToString();
            try
            {
                struct_tzsb.p_tzbh = tzbh;
                struct_tzsb.p_dsb = dsb;
                struct_tzsb.p_zsbgs = zsbgs;
                struct_tzsb.p_qtcs = qtcs;
                struct_tzsb.p_fh = fh;
                struct_tzsb.p_fd = fd;
                struct_tzsb.p_wxgj = wxgj;
                struct_tzsb.p_jfflcs = jfflcs;
                struct_tzsb.p_fljcdqrq = fljcdqrq;
                struct_tzsb.p_sfydn = sfydn;
                //路径
                struct_tzsb.p_czfs = "01";
                struct_tzsb.p_czxx = "位置：设备管理->台站设备->灭鼠措施添加 挡鼠板："/*+ struct_tzsb.p_dsb + " 粘鼠板个数：" + struct_tzsb.p_zsbgs +
                    "其他措施：" + struct_tzsb.p_qtcs + " 防洪措施是否具备：" + struct_tzsb.p_fh + " 防盗措施是否具备：" + struct_tzsb.p_fd +
                    " 维修工具是否满足该设备故障时紧急维修需求：" + struct_tzsb.p_wxgj + "机房防雷措施："+ struct_tzsb.p_jfflcs
                 + "防雷检测到期日期：" + struct_tzsb.p_fljcdqrq + "是否有地暖："  + struct_tzsb.p_sfydn*/;
                tzsb.Insert_TZ_MSCS(struct_tzsb);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }

        protected void btn_gb_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBTZ_CZ.aspx?tzbh=" + Request.Params["tzbh"].ToString());
        }
    }
}










