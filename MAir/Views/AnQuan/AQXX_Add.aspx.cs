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
    public partial class AQXX_Add : System.Web.UI.Page

    {
        private UserState _usState;
        private FXY fxy;
        private Struct_FXY struct_fxy;
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            fxy = new FXY(_usState);
            if (!IsPostBack)
            {
                tbx_sfsj.Attributes.Add("readonly", "readonly");
                tbx_bssj.Attributes.Add("readonly", "readonly");
                div_tqczf.Style.Add("display", "none");
                div_tqczs.Style.Add("display","none");
                ddltBind();
                Bind();
            }
        }

        private void ddltBind()
        {
            ////风险源状态
            //ddlt_fxyzt.DataSource = SysData.FXYZT().Copy();
            //ddlt_fxyzt.DataTextField = "mc";
            //ddlt_fxyzt.DataValueField = "bm";
            //ddlt_fxyzt.DataBind();
            //ddlt_fxyzt.Items.Insert(0, new ListItem("请选择", "-1"));
            ////控制状态
            //ddlt_kzzt.DataSource = SysData.FXKZZT().Copy();
            //ddlt_kzzt.DataTextField = "mc";
            //ddlt_kzzt.DataValueField = "bm";
            //ddlt_kzzt.DataBind();
            //ddlt_kzzt.Items.Insert(0, new ListItem("请选择", "-1"));
            ////危险源范畴
            //ddlt_fxyfc.DataSource = SysData.WXYFC().Copy();
            //ddlt_fxyfc.DataTextField = "mc";
            //ddlt_fxyfc.DataValueField = "bm";
            //ddlt_fxyfc.DataBind();
            //ddlt_fxyfc.Items.Insert(0, new ListItem("请选择", "-1"));
            ////时态
            //ddlt_st.DataSource = SysData.STDM().Copy();
            //ddlt_st.DataTextField = "mc";
            //ddlt_st.DataValueField = "bm";
            //ddlt_st.DataBind();
            //ddlt_st.Items.Insert(0, new ListItem("请选择", "-1"));
            ////风险情景发生的可能性
            //ddlt_fxknx.DataSource = SysData.FXFSKN().Copy();
            //ddlt_fxknx.DataTextField = "mc";
            //ddlt_fxknx.DataValueField = "bm";
            //ddlt_fxknx.DataBind();
            //ddlt_fxknx.Items.Insert(0, new ListItem("请选择", "-1"));
            ////风险程度
            //ddlt_fxcd.DataSource = SysData.FXCD().Copy();
            //ddlt_fxcd.DataTextField = "mc";
            //ddlt_fxcd.DataValueField = "bm";
            //ddlt_fxcd.DataBind();
            //ddlt_fxcd.Items.Insert(0, new ListItem("请选择", "-1"));
            //控制措施标准化情况
            ddlt_tqcz.DataSource = SysData.TQCZ().Copy();
            ddlt_tqcz.DataTextField = "mc";
            ddlt_tqcz.DataValueField = "bm";
            ddlt_tqcz.DataBind();
            ddlt_tqcz.Items.Insert(0, new ListItem("请选择", "-1"));

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

            ddlt_zrbm.DataSource = SysData.BM().Copy();
            ddlt_zrbm.DataTextField = "mc";
            ddlt_zrbm.DataValueField = "bm";
            ddlt_zrbm.DataBind();

            ddlt_zrdw.DataSource = SysData.BM().Copy();
            ddlt_zrdw.DataTextField = "mc";
            ddlt_zrdw.DataValueField = "bm";
            ddlt_zrdw.DataBind();

            struct_fxy.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_fxy.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = fxy.Select_FZR(struct_fxy);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
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
            Response.Redirect("../AnQuan/AQXX.aspx", true);
        }
        //绑定固定值
        private void Bind()
        {
            lbl_bh.Text = _usState.userXM;
            lbl_bsgw.Text = _usState.userGWMC.ToString().Trim();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_fxy.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_fxy.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = fxy.Select_FZR(struct_fxy);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_fxy.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_fxy.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = fxy.Select_FZR(struct_fxy);
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
        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_fxy.p_bsbh = _usState.userGWDM + fxy.SelectBS_FXYMaxBH();
            struct_fxy.p_bsyg = _usState.userLoginName;//员工编号
            struct_fxy.p_bsgw = _usState.userGWDM;//报送岗位
            struct_fxy.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());//报送时间
            struct_fxy.p_zrbm = ddlt_zrbm.SelectedValue.ToString();//责任部门
            struct_fxy.p_bz = tbx_bz.Text.ToString().Trim();//备注
            struct_fxy.p_tqcz = ddlt_tqcz.SelectedValue.Trim().ToString();//特情处置
            struct_fxy.p_gzqk = tbx_gzqk.Text.ToString().Trim();//管制情况
            struct_fxy.p_sjqk = tbx_sjqk.Text.ToString().Trim();//事件情况
            struct_fxy.p_sfsj = Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim());//报送时间
            struct_fxy.p_zrdw = ddlt_zrdw.SelectedValue.ToString().Trim();//责任单位
            struct_fxy.p_bgsj = Convert.ToDateTime(tbx_bgsj.Text.ToString().Trim());//报告时间
            struct_fxy.p_fxymc = " ";
            struct_fxy.p_st = " ";
            struct_fxy.p_fxyfc = " ";
            if (struct_fxy.p_tqcz.Equals("01")) {
                struct_fxy.p_gzqk = tbx_gzqk.Text.ToString().Trim();
                struct_fxy.p_sjqk = tbx_sjqk.Text.ToString().Trim();
                struct_fxy.p_sbyxqk = tbx_sbyxqk.Text.ToString().Trim();
                struct_fxy.p_sfsj = Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim());
                struct_fxy.p_zrdw = ddlt_zrdw.SelectedValue.ToString().Trim();
                struct_fxy.p_fzr = ddlt_yg.SelectedValue.ToString(); //负责人
                struct_fxy.p_bgsj = Convert.ToDateTime(tbx_bgsj.Text.ToString().Trim());
            }
            else if(struct_fxy.p_tqcz.Equals("02"))
            {
                struct_fxy.p_gzqk = "";
                struct_fxy.p_sjqk = "";
                struct_fxy.p_sbyxqk = "";
                //struct_fxy.p_sfsj = "";
                struct_fxy.p_zrdw = "";
                struct_fxy.p_fzr = "";
                //struct_fxy.p_bgsj = "";
            }
            struct_fxy.p_bhyy = "";
            struct_fxy.p_zt = "0";
            struct_fxy.p_czfs = "01";
            struct_fxy.p_czxx = "位置：航务综合信息报送系统->风险源分析->添加      描述： 报送编号：[" + struct_fxy.p_bsbh + "]报送岗位："
                + struct_fxy.p_bsgw + "报送时间：" + struct_fxy.p_bssj + "责任部门：" + struct_fxy.p_zrbm
                + "备注：" + struct_fxy.p_bz + "特情处置：" + struct_fxy.p_tqcz + "管制情况：" + struct_fxy.p_gzqk + "事件涉及的航空器和机组有关情况：" + struct_fxy.p_sjqk+ "事发时间：" + struct_fxy.p_sfsj
                +" 责任单位："+ struct_fxy.p_zrdw+ "负责人 ："+ struct_fxy.p_fzr+ "报告时间 ："+ struct_fxy.p_bgsj; 
            fxy.Insert_FXY(struct_fxy);
          //  Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Response.Redirect("../AnQuan/AQXX.aspx", true);
        }
        protected void ddlt_tqcz_change(object sender, EventArgs e) {
            string tqcz = ddlt_tqcz.SelectedValue.ToString();
            if (tqcz.Equals("01"))
            {
                div_tqczs.Style.Add("display", "true");
                div_tqczf.Style.Add("display", "none");
            }
            else {
                div_tqczf.Style.Add("display", "true");
                div_tqczs.Style.Add("display", "none");
            }
        }
    }
}