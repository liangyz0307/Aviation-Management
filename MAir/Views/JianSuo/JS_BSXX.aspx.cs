using System;
using System.Web.UI.WebControls;
using CUST.Sys;
using CUST.MKG;
using CUST.Tools;
using System.Data;
using Sys;

namespace CUST.WKG
{
    public partial class JS_BSXX : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        public  JS js;
        public OJS.Struct_JS struct_js;
    
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
           // cpage = _usState.C_JS_BS;// _usState.C_JS_BS;// pg_fy.CurrentPage;
           // psize = _usState.C_JS_BS;// _usState.C_JS_BS;// pg_fy.NumPerPage;
            js = new JS(_usState);
            if (!IsPostBack)
            {
                bind_drop();
            
            }
        }
        private void bind_drop()
        {
            //报送类型
            ddlt_bslx.DataTextField = "mc";
            ddlt_bslx.DataValueField = "bm";
            ddlt_bslx.DataSource = SysData.BSLX().Copy();
            ddlt_bslx.DataBind();
            ddlt_bslx.Items.Insert(0, new ListItem("请选择", "-1"));

            ddlt_bsgw.DataTextField = "mc";
            ddlt_bsgw.DataValueField = "bm";
            ddlt_bsgw.DataSource = SysData.GW().Copy();
            ddlt_bsgw.DataBind();
            ddlt_bsgw.Items.Insert(0, new ListItem("全部", "-1"));

        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            select();
        }
        protected void select()
        {
            if (ddlt_bslx.SelectedValue == "-1")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"请先检索报送类型！\")</script>");
                return;
            }
            int count = 0;
         
            struct_js.p_bsgw = ddlt_bsgw.SelectedValue.ToString();
            struct_js.p_bslx = ddlt_bslx.SelectedValue.ToString();
            DateTime time = new DateTime();
            if (tbx_bssj.Text.ToString() == "")
            {

                struct_js.p_bssj = Convert.ToDateTime("0001/1/1 00:00:00");
            }
            else
            {
                struct_js.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString());
            }
            if (tbx_jssj.Text.ToString() == "")
            {
                struct_js.p_jssj = Convert.ToDateTime("9999/12/30 23:59:59");
            }
            else
            {
                struct_js.p_jssj = Convert.ToDateTime(tbx_jssj.Text.ToString());
            }
            struct_js.p_bsyg = tbx_bsyg.Text.ToString();
            if (ddlt_bslx.SelectedValue == "01")
            {
                count = js.Select_BS_HBYXXX_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "02")
            {
                count = js.Select_BS_TQCZ_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "03")
            {
                count = js.Select_BS_ZBAP_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "04")
            {
                count = js.Select_BS_GZJZ_Count(struct_js);

            }
            if (ddlt_bslx.SelectedValue == "05")
            {
                count = js.Select_BS_ZDGZ_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "06")
            {
                count = js.Select_BS_FXY_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "07")
            {
                count = js.Select_BS_YS_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "08")
            {
                count = js.Select_BS_GDZC_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "09")
            {
                count = js.Select_BS_BXD_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "10")
            {
                count = js.Select_BS_ZYBS_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "11")
            {
                count = js.Select_BS_SG_Count(struct_js);
            }
            if (ddlt_bslx.SelectedValue == "12")
            {
                count = js.Select_BS_DZQM_Count(struct_js);
            }
            pg_fy.TotalRecord = count;
            struct_js.p_currentpage = pg_fy.CurrentPage;
            struct_js.p_pagesize = pg_fy.NumPerPage;

            DataTable dt = new DataTable();
            if (ddlt_bslx.SelectedValue == "01")
            {
                dt= js.Select_BS_HBYXXX(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "02")
            {
                dt = js.Select_BS_TQCZ(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "03")
            {
                dt = js.Select_BS_ZBAP(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "04")
            {
                dt = js.Select_BS_GZJZ(struct_js).Tables[0];

            }
            if (ddlt_bslx.SelectedValue == "05")
            {
                dt = js.Select_BS_ZDGZ(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "06")
            {
                dt = js.Select_BS_FXY(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "07")
            {
                dt = js.Select_BS_YS(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "08")
            {
                dt = js.Select_BS_GDZC(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "09")
            {
                dt = js.Select_BS_BXD(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "10")
            {
                
                dt = js.Select_BS_ZYBS(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "11")
            {
                dt = js.Select_BS_SG(struct_js).Tables[0];
            }
            if (ddlt_bslx.SelectedValue == "12")
            {
                dt = js.Select_BS_DZQM(struct_js).Tables[0];
            }
            dt.Columns.Add("bslx_mc");
            dt.Columns.Add("bsgw_mc");
            dt.Columns.Add("bssjmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bslx_mc"] = SysData.BSLXByKey(dr["bslx"].ToString()).mc;
                dr["bsgw_mc"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;
                dr["bssjmc"] = DateTime.Parse(dr["bssj"].ToString()).ToString("yyyy-MM-dd");
            }
            this.Repeater1.DataSource = dt.DefaultView;
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