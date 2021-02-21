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
    public partial class TZSB_KT_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        public bool flag = true;
        public string tzbh;
        private int i;
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
                tbx_azsj.Attributes.Add("readonly", "readonly");
                tzbh = Request.Params["tzbh"].ToString();
                bind_drop();

            }
        }
        
        private void bind_drop()
        {
            //是否配备
            ddlt_sfpb.DataTextField = "mc";
            ddlt_sfpb.DataValueField = "bm";
            ddlt_sfpb.DataSource = SysData.SFJB().Copy();
            ddlt_sfpb.DataBind();
            ddlt_sfpb.Items.Insert(0, new ListItem("请选择", "-1"));
            //是否安装紫气装置
            ddlt_sfazzqzz.DataTextField = "mc";
            ddlt_sfazzqzz.DataValueField = "bm";
            ddlt_sfazzqzz.DataSource = SysData.SFJB().Copy();
            ddlt_sfazzqzz.DataBind();
            ddlt_sfazzqzz.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string tzbh = Request.Params["tzbh"].ToString();
            string sfpb = ddlt_sfpb.SelectedValue.ToString();
            string sl = tbx_sl.Text.ToString();
            string pp = tbx_pp.Text.ToString();
            string azsj = tbx_azsj.Text.ToString();
            string bxnx = tbx_bxnx.Text.ToString();
            string sfazzqzz = ddlt_sfazzqzz.SelectedValue.ToString();
            try
            {
                struct_tzsb.p_tzbh = tzbh;
                struct_tzsb.p_sfpb = sfpb;
                struct_tzsb.p_sl = sl;
                struct_tzsb.p_pp = pp;
                struct_tzsb.p_azsj = azsj;
                struct_tzsb.p_bxnx = bxnx;
                struct_tzsb.p_sfazzqzz = sfazzqzz;
                //路径
                struct_tzsb.p_czfs = "01";
                struct_tzsb.p_czxx = "位置：设备管理->台站设备->空调添加 是否配备："+ struct_tzsb.p_sfpb + " 数量：" + struct_tzsb.p_sl + "品牌：" + struct_tzsb.p_pp + " 安装时间：" + struct_tzsb.p_azsj + " 保修年限：" + struct_tzsb.p_bxnx +  " 是否安装紫气装置：" + struct_tzsb.p_sfazzqzz;
                tzsb.Insert_TZ_KT(struct_tzsb);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Shebei/SBTZ_CZ.aspx?tzbh=" + Request.Params["tzbh"].ToString()); 
        }
    }
    
}










