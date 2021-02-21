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
    public partial class BS_TQCZ_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private TQCZ tqcz;
        private Struct_TQCZ struct_tqcz;
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tqcz = new TQCZ(_usState);
            if (!IsPostBack)
            {
                tbx_bgsj.Attributes.Add("readonly", "readonly");
                tbx_bssj.Attributes.Add("readonly", "readonly");
                tbx_sfsj.Attributes.Add("readonly", "readonly");
                ddltBind();
                Bind();

            }

        }
        private void ddltBind()
        {
            //报送类型
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            DataTable dt = new DataTable();
            struct_tqcz.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_tqcz.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            dt = tqcz.Select_FZR(struct_tqcz);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();

            ddlt_zrbm.DataSource = SysData.BM().Copy();
            ddlt_zrbm.DataTextField = "mc";
            ddlt_zrbm.DataValueField = "bm";
            ddlt_zrbm.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_tqcz.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_tqcz.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = tqcz.Select_FZR(struct_tqcz);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_tqcz.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_tqcz.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = tqcz.Select_FZR(struct_tqcz);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
        }
        protected void btn_zrr_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_yg.SelectedValue.ToString();
            tbx_fzr.Text = ddlt_yg.SelectedItem.Text;
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
            Response.Redirect("../AnQuan/BS_TQCZ.aspx", true);
        }
        //绑定固定值
        private void Bind()
        {
            lbl_bh.Text = _usState.userXM;
            lbl_bsgw.Text = _usState.userGWMC.ToString().Trim();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
          
            struct_tqcz.p_bsbh = _usState.userGWDM + tqcz.SelectBS_TQCZMaxBH();
            struct_tqcz.p_bsyg = _usState.userLoginName;//员工编号
            struct_tqcz.p_bsgw = _usState.userGWDM;//报送岗位
            struct_tqcz.p_xtsj = DateTime.Now;
            struct_tqcz.p_bsip = Page.Request.UserHostAddress;//报送IP
            struct_tqcz.p_bssj =Convert.ToDateTime( tbx_bssj.Text.ToString().Trim());//报送时间
            struct_tqcz.p_gzqk = tbx_gzqk.Text.ToString().Trim();//管制情况
            struct_tqcz.p_sjqk = tbx_sjqk.Text.ToString().Trim();//事件涉及的航空器和机组有关情况
            struct_tqcz.p_sbyxqk = tbx_sbyxqk.Text.ToString().Trim();//空管相关设备运行状况
            struct_tqcz.p_sfsj =Convert .ToDateTime( tbx_sfsj.Text.ToString().Trim());//事发时间
            struct_tqcz.p_zrdw = _usState.userBMDM;//责任单位
            struct_tqcz.p_lxr = ddlt_yg.SelectedValue.ToString();//负责人
            struct_tqcz.p_bgsj = Convert.ToDateTime(tbx_bgsj.Text.ToString().Trim());//报告时间
            struct_tqcz.p_bz= tbx_bz.Text.ToString().Trim();//备注
            struct_tqcz.p_zt = "0";
            struct_tqcz.p_bhyy = "";
            struct_tqcz.p_czfs = "01";
            struct_tqcz.p_czxx = "位置：航务综合信息报送系统->特情处置->添加      描述： 报送编号：[" + struct_tqcz.p_bsbh + "]报送岗位："
                + struct_tqcz.p_bsgw + "报送IP：" + struct_tqcz.p_bsip
                + "报送时间：" + struct_tqcz.p_bssj + "管制情况：" + struct_tqcz.p_gzqk + "事件涉及的航空器和机组有关情况：" + struct_tqcz.p_sjqk
                + "空管相关设备运行状况：" + struct_tqcz.p_sbyxqk + "事发时间：" + struct_tqcz.p_sfsj + "责任单位：" + struct_tqcz.p_zrdw
                + "负责人：" + struct_tqcz.p_fzr + "报告时间：" + struct_tqcz.p_bgsj
                + "备注：" + struct_tqcz.p_bz;
            tqcz.Insert_TQCZ(struct_tqcz);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Response.Redirect("../AnQuan/BS_TQCZ.aspx", true);
        }
    }
}