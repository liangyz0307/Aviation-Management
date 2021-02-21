using CUST;
using CUST.Sys;
using CUST.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using Sys;


namespace CUST.WKG
{
    public partial class SPR_Add : System.Web.UI.Page
    {
        private UserState _us;
        private SPR spr;
        static string sprdm;
        public bool flag = true;
        public int i = 0;
        private Struct_SPR struct_spr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            spr = new SPR(_us);
            struct_spr = new Struct_SPR();
            if (!IsPostBack)
            {
                Bind();

            }
        }
        private void Bind()
        {
            //子系统代码
            ddlt_zxt.DataSource = SysData.ZXTDM().Copy();
            ddlt_zxt.DataTextField = "mc";
            ddlt_zxt.DataValueField = "bm";
            ddlt_zxt.DataBind();
            ddlt_zxt.Items.Insert(0, new ListItem("请选择", "-1"));

            #region 员工选择框1
            DataTable dt_bmdm = SysData.BM().Copy();
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = spr.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
            #endregion

        }
        #region tbx_spr.Text数据绑定
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = spr.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = spr.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }
        protected void btn_bc_spr_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_spr.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_spr.Items.Count > 0)
            {
                tbx_spr.Text = ddlt_spr.SelectedItem.Text;
                sprdm = ddlt_spr.SelectedValue.ToString();
            }
        }
        #endregion
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 保存
            #region label判断
            int flag = 0;

            //隐患发现时间
            if (tbx_spr.Text == "")
            {
                lbl_spr.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            if (ddlt_zxt.SelectedValue == "-1")
            {
                lbl_zxt.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            if (flag == 1)
            { return; }
            #endregion
            struct_spr.p_zxtdm = ddlt_zxt.SelectedValue.ToString().Trim();
            struct_spr.p_spr = sprdm.Substring(0, sprdm.Length);
            struct_spr.p_czfs = "01";
            struct_spr.p_czxx = "位置：后台管理->审批人管理->添加 描述：子系统代码：" + struct_spr.p_zxtdm + "审批人："
                + struct_spr.p_spr ;
            try
            {
                spr.Insert_SPR(struct_spr);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (Exception em)
            {
                throw em;
            }
            #endregion
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/SPRGL.aspx", true);
        }


    }
}