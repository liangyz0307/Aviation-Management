using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG.MenHu.main
{
    public partial class DQZC_DYAdd : System.Web.UI.Page
    {
        public DQZC dqzc;
        public ODQZC.Struct_DY struct_dy;
        private UserState _usState;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dqzc = new DQZC(_usState);
            if (!IsPostBack)
            {
                tbx_rdsj.Attributes.Add("readonly", "readonly");
                bind_drop();
            }
        }
        private void bind_drop()
        {
            DataTable dt_zzmm = SysData.ZZMM();
            DataRow[] rows = dt_zzmm.Copy().Select("bm not in('0','1')");
            DataTable dt_tmp = rows[0].Table.Clone();
            foreach (DataRow row in rows)
            {
                dt_tmp.Rows.Add(row.ItemArray);
            }
            ddlt_zzmm.DataTextField = "mc";
            ddlt_zzmm.DataValueField = "bm";
            ddlt_zzmm.DataSource = dt_tmp.DefaultView;
            ddlt_zzmm.DataBind();
            ddlt_zzmm.Items.Insert(0, new ListItem("请选择", "-1"));

            ddlt_ygxs.DataTextField = "mc";
            ddlt_ygxs.DataValueField = "bm";
            ddlt_ygxs.DataSource = SysData.YGXS().Copy();
            ddlt_ygxs.DataBind();
            ddlt_ygxs.Items.Insert(0, new ListItem("请选择", "-1"));

            ddlt_dxzmc.DataTextField = "mc";
            ddlt_dxzmc.DataValueField = "bm";
            ddlt_dxzmc.DataSource = SysData.DXZMC().Copy();
            ddlt_dxzmc.DataBind();
            ddlt_dxzmc.Items.Insert(0, new ListItem("请选择", "-1"));

            ddlt_jcdzbmc.DataTextField = "mc";
            ddlt_jcdzbmc.DataValueField = "bm";
            ddlt_jcdzbmc.DataSource = SysData.JCDZBMC().Copy();
            ddlt_jcdzbmc.DataBind();
            ddlt_jcdzbmc.Items.Insert(0, new ListItem("请选择", "-1"));

            ddlt_dzzmc.DataTextField = "mc";
            ddlt_dzzmc.DataValueField = "bm";
            ddlt_dzzmc.DataSource = SysData.DZZMC().Copy();
            ddlt_dzzmc.DataBind();
            ddlt_dzzmc.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            struct_dy.p_bh = tbx_bh.Text.ToString();
            struct_dy.p_dnzw = tbx_dnzw.Text.ToString();
            struct_dy.p_dxzmc = ddlt_dxzmc.SelectedValue.ToString();
            struct_dy.p_jcdzbmc = ddlt_jcdzbmc.SelectedValue.ToString();
            struct_dy.p_dzzmc = ddlt_dzzmc.SelectedValue.ToString();
            struct_dy.p_ygxs = ddlt_ygxs.SelectedValue.ToString();
            struct_dy.p_rdsj =Convert.ToDateTime( tbx_rdsj.Text.ToString());
            struct_dy.p_bz = tbx_bz.Text.ToString();
            struct_dy.p_zzmm = ddlt_zzmm.SelectedValue.ToString().Trim();
            struct_dy.p_czfs = "01";
            struct_dy.p_czxx = "位置：党群之窗->党员管理->添加  描述：编号:[" + struct_dy.p_bh + "] 用工形式：【" + struct_dy.p_ygxs + "】 入党时间：【"
            + struct_dy.p_rdsj + "】 党内职务：【" + struct_dy.p_dnzw + "】备注：【" + struct_dy.p_bz + "】" ;
            dqzc.Insert_DY(struct_dy);
            Response.Write("<script>alert(\"添加成功！\");</script>");
        }

      
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DQZC_DYGL.aspx");
        }
        #region 错误信息

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

        #endregion

        protected void ddlt_jcdzbmc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jcdzbmc = ddlt_jcdzbmc.SelectedValue.ToString();
            if (ddlt_jcdzbmc.SelectedValue.ToString() == "0101")
            {
                ddlt_dxzmc.DataTextField = "mc";
                ddlt_dxzmc.DataValueField = "bm";
                ddlt_dxzmc.DataSource = SysData.DXZMC(jcdzbmc).Copy();
                ddlt_dxzmc.DataBind();
                ddlt_dxzmc.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            if (ddlt_jcdzbmc.SelectedValue.ToString() == "0102")
            {
                ddlt_dxzmc.DataTextField = "mc";
                ddlt_dxzmc.DataValueField = "bm";
                ddlt_dxzmc.DataSource = SysData.DXZMC(jcdzbmc).Copy();
                ddlt_dxzmc.DataBind();
                ddlt_dxzmc.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            if (ddlt_jcdzbmc.SelectedValue.ToString() == "0103")
            {
                ddlt_dxzmc.DataTextField = "mc";
                ddlt_dxzmc.DataValueField = "bm";
                ddlt_dxzmc.DataSource = SysData.DXZMC(jcdzbmc).Copy();
                ddlt_dxzmc.DataBind();
                ddlt_dxzmc.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            if (ddlt_jcdzbmc.SelectedValue.ToString() == "0104")
            {
                ddlt_dxzmc.DataTextField = "mc";
                ddlt_dxzmc.DataValueField = "bm";
                ddlt_dxzmc.DataSource = SysData.DXZMC(jcdzbmc).Copy();
                ddlt_dxzmc.DataBind();
                ddlt_dxzmc.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

    }
}