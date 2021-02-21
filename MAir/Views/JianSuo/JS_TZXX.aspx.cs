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
    public partial class JS_TZXX : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        public JS js;
        public OJS.Struct_JS_TZ struct_js_tz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
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
            //台站类型
            ddlt_tzlx.DataTextField = "mc";
            ddlt_tzlx.DataValueField = "bm";
            ddlt_tzlx.DataSource = SysData.TZLX().Copy();
            ddlt_tzlx.DataBind();
            ddlt_tzlx.Items.Insert(0, new ListItem("全部", "-1"));
            //所属地 ddlt_ssd 所属空管局
            ddlt_ssjgj.DataTextField = "mc";
            ddlt_ssjgj.DataValueField = "bm";
            ddlt_ssjgj.DataSource = SysData.ZXDM().Copy();
            ddlt_ssjgj.DataBind();
            ddlt_ssjgj.Items.Insert(0, new ListItem("全部", "-1"));

            //申请单位 ddlt_sqdw
            ddlt_sqdw.DataTextField = "mc";
            ddlt_sqdw.DataValueField = "bm";
            ddlt_sqdw.DataSource = SysData.ZXDM().Copy();
            ddlt_sqdw.DataBind();
            ddlt_sqdw.Items.Insert(0, new ListItem("全部", "-1"));
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            select();
        }
        private void select()
        {
            struct_js_tz.p_sqdw = ddlt_sqdw.SelectedValue.ToString();
            struct_js_tz.p_ssjgj = ddlt_ssjgj.SelectedValue.ToString();
            struct_js_tz.p_tzlx = ddlt_tzlx.SelectedValue.ToString();
            struct_js_tz.p_tzmc = tbx_tzmc.Text.ToString();
            int count = js.Select_JS_TZXXCount(struct_js_tz);
            pg_fy.TotalRecord = count;
            struct_js_tz.p_currentpage = pg_fy.CurrentPage;
            struct_js_tz.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = js.Select_JS_TZXX(struct_js_tz).Tables[0];
             dt.Columns.Add("tzlxmc");
             dt.Columns.Add("sqdwmc");
             dt.Columns.Add("ssjgjmc");
                dt.Columns.Add("CDJDCHJFHQKmc");
             foreach (DataRow dr in dt.Rows)
             {
                 dr["tzlxmc"] = SysData.TZLXByKey(dr["tzlx"].ToString()).mc;
                 dr["sqdwmc"] = SysData.ZXDMByKey(dr["sqdw"].ToString()).mc;
                 dr["ssjgjmc"] = SysData.BMByKey(dr["ssjgj"].ToString()).mc;
                  dr["CDJDCHJFHQKmc"] = SysData.FGFWByKey(dr["CDJDCHJFHQK"].ToString()).mc;
             }
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            select();
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