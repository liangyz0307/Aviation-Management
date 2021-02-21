using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class JS_YGXX : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        private UserState _usState;
        public JS js;
        public OJS.Struct_JS_YG struct_js_yg;
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
           // cpage =  _usState.C_JS_YG;//pg_fy.CurrentPage;
           // psize =  _usState.C_JS_YG;// pg_fy.NumPerPage;
            js = new JS(_usState);
            if (!IsPostBack)
            {
                bind_drop();
            }
        }
        private void bind_drop()
        {
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            DataTable dt_gw = new DataTable();
            ddlt_gwdm.DataSource = dt_gw;
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            ddlt_xb.DataSource = SysData.XB().Copy();
            ddlt_xb.DataTextField = "mc";
            ddlt_xb.DataValueField = "bm";
            ddlt_xb.DataBind();
            ddlt_xb.Items.Insert(0, new ListItem("全部", "-1"));

            ddlt_zzmm.DataSource = SysData.ZZMM().Copy();
            ddlt_zzmm.DataTextField = "mc";
            ddlt_zzmm.DataValueField = "bm";
            ddlt_zzmm.DataBind();
            ddlt_zzmm.Items.Insert(0, new ListItem("全部", "-1"));
            
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bmdm.SelectedValue.ToString();
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_gwdm.DataSource = dt;
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_gwdm.DataSource = SysData.GW(bm).Copy();
                ddlt_gwdm.DataTextField = "mc";
                ddlt_gwdm.DataValueField = "bm";
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }
        private void select()
        {
            struct_js_yg.p_bh = tbx_ygbh.Text;
            struct_js_yg.p_xm = tbx_xm.Text;
            struct_js_yg.p_xbdm = ddlt_xb.SelectedValue.ToString();
            struct_js_yg.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_js_yg.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            struct_js_yg.p_zzmm = ddlt_zzmm.SelectedValue.ToString();
            zcount = js.Select_JS_YGCount(struct_js_yg);
            pg_fy.TotalRecord = zcount;
            struct_js_yg.p_currentpage = pg_fy.CurrentPage;
            struct_js_yg.p_pagesize = pg_fy.NumPerPage;
            //pg_fy.TotalRecord = count;
            //struct_js_yg.p_currentpage = 1; 
           // struct_js_yg.p_pagesize = 20; 
            DataTable dt = new DataTable();
            dt = js.Select_JS_YGXX(struct_js_yg).Tables[0];
            dt.Columns.Add("xb");
            dt.Columns.Add("bmmc");
            dt.Columns.Add("gwmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["xb"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
            }
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
        }
        protected void btn_cx_Click(object sender, EventArgs e)
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

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            select();
        }
    }
}