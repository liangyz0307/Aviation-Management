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
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;


namespace CUST.WKG
{
    public partial class BS_YS_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private YS ys;
        private Struct_YS struct_ys;
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ys = new YS(_usState);
            if (!IsPostBack)
            {
                tbx_bssj.Attributes.Add("readonly", "readonly");
               
                ddltBind();
                Bind();
            }
        }
        private void ddltBind()
        {
            //报送类型
            ddlt_bslx.DataSource = SysData.BSLX().Copy();
            ddlt_bslx.DataTextField = "mc";
            ddlt_bslx.DataValueField = "bm";
            ddlt_bslx.DataBind();
            ddlt_bslx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_YS.aspx", true);
        }
        private void Bind()
        {
            ddlt_bslx.SelectedValue = "07";
            tbx_bh.Text = _usState.userLoginName;
            tbx_bsgw.Text = _usState.userGWMC.ToString().Trim();
            tbx_sqbm.Text = _usState.userBMMC.ToString().Trim();
            //tbx_bsip.Text = Page.Request.UserHostAddress;
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

   
        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_ys.p_bsbh = _usState.userGWDM + ys.SelectBS_YSMaxBH();
            struct_ys.p_bsyg = tbx_bh.Text.ToString().Trim();//员工编号
            struct_ys.p_bsgw = _usState.userGWDM;//报送岗位
            struct_ys.p_bslx = ddlt_bslx.SelectedValue.ToString().Trim();//报送类型

            struct_ys.p_bsip = "";//报送IP
            struct_ys.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());//报送时间
            struct_ys.p_sqbm = _usState.userBMDM;//申请部门
            struct_ys.p_ysze = tbx_ysze.Text.ToString().Trim();//预算总额
            struct_ys.p_ysly = tbx_ysly.Text.ToString().Trim();//预算来源
            struct_ys.p_ysyt = tbx_ysyt.Text.ToString().Trim();//预算用途
            struct_ys.p_yynx = tbx_yynx.Text.ToString().Trim();//应用年限
            struct_ys.p_bz = tbx_bz.Text.ToString().Trim();//备注
            struct_ys.p_czfs = "01";
            struct_ys.p_czxx = "位置：航务综合信息报送系统->预算->添加      描述：员工编号：" + struct_ys.p_bsyg + "报送岗位："
                + struct_ys.p_bsgw + "报送类型：" + struct_ys.p_bslx + "报送IP：" + struct_ys.p_bsip
                + "报送时间：" + struct_ys.p_bssj + "申请部门：" + struct_ys.p_sqbm + "预算总额：" + struct_ys.p_ysze
                + "预算来源：" + struct_ys.p_ysly + "预算用途：" + struct_ys.p_ysyt + "应用年限：" + struct_ys.p_yynx 
                + "备注：" + struct_ys.p_bz;
            ys.Insert_YS(struct_ys);
          
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            tbx_bz.Text = "";
            tbx_bssj.Text = "";
            tbx_ysze.Text = "";
            tbx_ysly.Text = "";
            tbx_ysyt.Text = "";
            tbx_yynx.Text = "";
        }
    }
}