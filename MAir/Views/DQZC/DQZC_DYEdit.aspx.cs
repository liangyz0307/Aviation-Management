using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG.MenHu.main
{
    public partial class DQZC_DYEdit : System.Web.UI.Page
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
                select();
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
        private void select()
        {
            DataTable dt = new DataTable();
            struct_dy.p_bh = Request.QueryString["bh"];
            dt = dqzc.Detail_DY(struct_dy);
            lbl_bh.Text = Request.QueryString["bh"];
            tbx_dnzw.Text = dt.Rows[0]["dnzw"].ToString();
            ddlt_dxzmc.SelectedValue = dt.Rows[0]["dxzmc"].ToString();
            ddlt_dzzmc.SelectedValue = dt.Rows[0]["dzzmc"].ToString();
            ddlt_jcdzbmc.SelectedValue = dt.Rows[0]["jcdzbmc"].ToString();
            ddlt_ygxs.SelectedValue = dt.Rows[0]["ygxs"].ToString();
            tbx_rdsj.Text = dt.Rows[0]["rdsj"].ToString();
            tbx_bz.Text = dt.Rows[0]["bz"].ToString();
            struct_dy.p_zzmm = ddlt_zzmm.SelectedValue.ToString().Trim();
        }
       
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            if (ddlt_dxzmc.SelectedValue.ToString().Trim() == "-1")
            {
                lbl_dxzmc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                return;
            }
            if ( ddlt_jcdzbmc.SelectedValue.ToString().Trim() == "-1")
            {

                lbl_jcdzbmc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                return;
            }
            if (ddlt_dzzmc.SelectedValue.ToString().Trim() == "-1")
            {

                lbl_dzzmc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                return;
            }
            if (ddlt_ygxs.SelectedValue.ToString().Trim() == "-1")
            {

                lbl_ygxs.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                return;
            }
            DataTable dt = new DataTable();
            struct_dy.p_bh = Request.QueryString["bh"];
            dt = dqzc.Detail_DY(struct_dy);
            bool flag = false;
            struct_dy.p_bh = lbl_bh.Text.ToString();
            struct_dy.p_dzzmc = ddlt_dzzmc.SelectedValue.ToString().Trim();
            struct_dy.p_jcdzbmc = ddlt_jcdzbmc.SelectedValue.ToString().Trim();
            struct_dy.p_dxzmc = ddlt_dxzmc.SelectedValue.ToString().Trim();
            struct_dy.p_ygxs = ddlt_ygxs.SelectedValue.ToString();
            struct_dy.p_rdsj = Convert.ToDateTime(tbx_rdsj.Text.ToString());
            struct_dy.p_dnzw = tbx_dnzw.Text.ToString();
            struct_dy.p_bz = tbx_bz.Text.ToString();
            struct_dy.p_zzmm = ddlt_zzmm.SelectedValue.ToString().Trim();
            struct_dy.p_czfs = "01";
            struct_dy.p_czxx = "位置：党群之窗->党员管理->添加  描述：";
            if (struct_dy.p_bh != Request.QueryString["bh"])
            {
                flag = true;
                struct_dy.p_czxx += "编号：【" + Request.QueryString["bh"] + "->" + struct_dy.p_bh + "】";
            }
            if(struct_dy.p_ygxs != dt.Rows[0]["ygxs"].ToString())
            {
                flag = true;
                struct_dy.p_czxx += "用工形式：【" + dt.Rows[0]["ygxs"].ToString()+"->"+ struct_dy.p_ygxs+"】";
            }
            if(struct_dy.p_rdsj!=Convert .ToDateTime( dt.Rows[0]["rdsj"].ToString()))
            {
                flag = true;
                struct_dy.p_czxx += "入党时间：【"+ Convert.ToDateTime(dt.Rows[0]["rdsj"].ToString())+"->"+ struct_dy.p_rdsj+"】";
            }
            if(struct_dy.p_dnzw!= dt.Rows[0]["dnzw"].ToString())
            {
                flag = true;
                struct_dy.p_czxx += "党内职务：【"+ dt.Rows[0]["dnzw"].ToString()+"->"+ struct_dy.p_dnzw+"]】";
            }
            if(struct_dy.p_bz!= dt.Rows[0]["bz"].ToString())
            {
                flag = true;
                struct_dy.p_czxx += "备注：【" + dt.Rows[0]["bz"].ToString()+"->"+ struct_dy.p_bz+"】";
            }
            if(flag==false)
            {
                struct_dy.p_czxx = "无操作";
            }
            else
            {
                dqzc.Update_DY(struct_dy);
                
            }
            Response.Write("<script>alert(\"编辑成功！\");</script>");
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