

using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class JS_SBXX : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        public JS js;
        public OJS.Struct_JS_DHSB struct_dhsb;
        public OJS.Struct_JS_TXSB struct_txsb;
        public OJS.Struct_JS_QXSB struct_qxsb;
        public OJS.Struct_JS_YBSB struct_ybsb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //cpage = _usState.C_JS_SB;// pg_fy.CurrentPage;
            // psize = _usState.C_JS_SB;// pg_fy.NumPerPage;
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_XX;
            psize = _usState.C_YG_XX;
            js = new JS(_usState);
            if (!IsPostBack)
            {
                bind_drop(); 
            }
        }
        private void bind_drop()
        {
            ddlt_sstzmc.DataTextField = "mc";
            ddlt_sstzmc.DataValueField = "bm";
            ddlt_sstzmc.DataSource = SysData.ZXDM().Copy();
            ddlt_sstzmc.DataBind();
            ddlt_sstzmc.Items.Insert(0, new ListItem("全部", "-1"));

            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX().Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("请选择", "-1"));

            DataTable dt_zl = new DataTable();
            ddlt_sbzl.DataSource = dt_zl;
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void show_sb()
        {
           if(ddlt_sblx.SelectedValue=="1")
            {
                select_dhsb(); 
            }
           if(ddlt_sblx.SelectedValue=="2")
            {
                select_txsb();
            }
           if(ddlt_sblx.SelectedValue=="3")
            {
                select_qxsb();
            }
            if (ddlt_sblx.SelectedValue == "5")
            {
                select_ybsb();
            }
        }
        private void select_dhsb()
        {
            struct_dhsb.p_sbzl = ddlt_sbzl.SelectedValue;
            struct_dhsb.p_sstzmc = ddlt_sstzmc.SelectedValue;
            struct_dhsb.p_sbbh = tbx_sbbh.Text.ToString();
            int count = js.Select_JS_DHSBCount(struct_dhsb);
            pg_fy.TotalRecord = count;
            struct_dhsb.p_currentpage = pg_fy.CurrentPage;
            struct_dhsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = js.Select_JS_DHSB(struct_dhsb).Tables[0];
            dt.Columns.Add("sblx");
            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sstz_mc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sblx"] = SysData.SBLXByKey(ddlt_sblx.SelectedValue).mc;
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sstz_mc"] = SysData.TZLXByKey(dr["sstzmc"].ToString()).mc;
            }
            this.rpt_sb.DataSource = dt.DefaultView;
            this.rpt_sb.DataBind();
        }
        private void select_txsb()
        {
            struct_txsb.p_sbbh = tbx_sbbh.Text.ToString();
            struct_txsb.p_sbzl = ddlt_sbzl.SelectedValue.ToString();
            struct_txsb.p_sstzmc = ddlt_sstzmc.SelectedValue.ToString();
            int count = js.Select_JS_TXSBCount(struct_txsb);
            pg_fy.TotalRecord = count;
            struct_txsb.p_currentpage = pg_fy.CurrentPage;
            struct_txsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = js.Select_JS_TXSB(struct_txsb).Tables[0];
            dt.Columns.Add("sblx");
            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sstz_mc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sblx"] = SysData.SBLXByKey(ddlt_sblx.SelectedValue).mc;
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sstz_mc"] = SysData.TZLXByKey(dr["sstzmc"].ToString()).mc;
            }
            this.rpt_sb.DataSource = dt.DefaultView;
            this.rpt_sb.DataBind();
        }
       private void select_qxsb()
        {
            struct_qxsb.p_sbbh = tbx_sbbh.Text.ToString();
            struct_qxsb.p_sbzl = ddlt_sbzl.SelectedValue.ToString();
            struct_qxsb.p_sstzmc = ddlt_sstzmc.SelectedValue.ToString();
            int count = js.Select_JS_QXSBCount(struct_qxsb);
            pg_fy.TotalRecord = count;
            struct_qxsb.p_currentpage = pg_fy.CurrentPage;
            struct_qxsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = js.Select_JS_QXSB(struct_qxsb).Tables[0];
            dt.Columns.Add("sblx");
            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sstz_mc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sblx"] = SysData.SBLXByKey(ddlt_sblx.SelectedValue).mc;
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sstz_mc"] = SysData.TZLXByKey(dr["sstzmc"].ToString()).mc;
            }
            this.rpt_sb.DataSource = dt.DefaultView;
            this.rpt_sb.DataBind();
        }
        private void select_ybsb()
        {
            struct_ybsb.p_sbzl = ddlt_sbzl.SelectedValue;
            struct_ybsb.p_sstzmc = ddlt_sstzmc.SelectedValue;
            struct_ybsb.p_sbbh = tbx_sbbh.Text.ToString();
            int count = js.Select_JS_YBSBCount(struct_ybsb);
            pg_fy.TotalRecord = count;
            struct_ybsb.p_currentpage = pg_fy.CurrentPage;
            struct_ybsb.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = js.Select_JS_YBSB(struct_ybsb).Tables[0];
            dt.Columns.Add("sblx");
            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sstz_mc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sblx"] = SysData.SBLXByKey(ddlt_sblx.SelectedValue).mc;
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sstz_mc"] = SysData.TZLXByKey(dr["sstzmc"].ToString()).mc;
            }
            this.rpt_sb.DataSource = dt.DefaultView;
            this.rpt_sb.DataBind();
        }
        protected void ddlt_sblx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ddlt_sbzl.DataTextField = "mc";
            ddlt_sbzl.DataValueField = "bm";
            ddlt_sbzl.DataSource = SysData.SBZL(ddlt_sblx.SelectedValue).Copy();
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("全部", "-1"));
        }

        protected void btn_cx_Click(object sender, EventArgs e)
        {
            if(ddlt_sblx.SelectedValue=="-1")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"请先检索报送类型！\")</script>");
                return;
            }
            show_sb();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            show_sb();
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
    }
}