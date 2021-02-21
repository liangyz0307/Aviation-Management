using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;
using System.Text;
using CUST.Tools;
using CUST;
using CUST.Sys;
using CUST.MKG;
using Sys;

namespace CUST.WKG
{
    public partial class JS_YJGL : System.Web.UI.Page
    {
        #region 分页
        public int cpage_yagl;
        public int psize_yagl;
        public int cpage_ylgl;
        public int psize_ylgl;
        #endregion
        #region
        private UserState _usState;
        private YAGL yagl;
        public Struct_YAGL struct_yagl;
        private YLGL ylgl;
        public Struct_YLGL struct_ylgl;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            #region
            yagl = new YAGL(_usState);
            ylgl = new YLGL(_usState);
            cpage_yagl = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_LL;
            psize_yagl = _usState.C_YG_LL;
            #endregion
            if (!IsPostBack) {
                ddltBind_cxmk();
                div_yagl.Attributes.Add("style", "display:none");
                div_ylgl.Attributes.Add("style", "display:none");
                
            }
        }
        private void ddltBind_cxmk() {
            ddlt_cxmk.Items.Insert(0,new ListItem("请选择","-1"));
            ddlt_cxmk.Items.Insert(1, new ListItem("预案管理", "1801"));
            ddlt_cxmk.Items.Insert(2, new ListItem("演练管理", "1802"));
        }
        protected void ddlt_cxmk_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlt_cxmk.SelectedValue == "-1") {
                div_yagl.Attributes.Add("style","display:none");
                div_ylgl.Attributes.Add("style", "display:none");
            }
            if (ddlt_cxmk.SelectedValue == "1801") {
                div_yagl.Attributes.Add("style", "display:true");
                div_ylgl.Attributes.Add("style", "display:none");
                ddltBind_yagl();
                Select_yagl();
            }
            if (ddlt_cxmk.SelectedValue == "1802") {
                div_yagl.Attributes.Add("style", "display:none");
                div_ylgl.Attributes.Add("style", "display:true");
                ddltBind_ylgl();
                Select_ylgl();
            }
        }
        private void ddltBind_yagl()
        {
            //绑定名称
            DataTable dt_mc = yagl.Select_Yj_Yagl_Mc_Proc().Copy();
            ddlt_mc_yagl.DataTextField = "mc";
            ddlt_mc_yagl.DataSource = dt_mc;
            ddlt_mc_yagl.DataBind();
            ddlt_mc_yagl.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定地区
            DataTable dt_dq = SysData.ZXDM().Copy();
            ddlt_dq_yagl.DataTextField = "mc";
            ddlt_dq_yagl.DataValueField = "bm";
            ddlt_dq_yagl.DataSource = dt_dq;
            ddlt_dq_yagl.DataBind();
            ddlt_dq_yagl.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定专业
            DataTable dt_zy = SysData.ZYLX().Copy();
            ddlt_zy_yagl.DataTextField = "mc";
            ddlt_zy_yagl.DataValueField = "bm";
            ddlt_zy_yagl.DataSource = dt_zy;
            ddlt_zy_yagl.DataBind();
            ddlt_zy_yagl.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt_yagl.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_yagl.DataTextField = "mc";
            ddlt_zt_yagl.DataValueField = "bm";
            ddlt_zt_yagl.DataBind();
            ddlt_zt_yagl.Items.Insert(0, new ListItem("全部", "-1"));

        }
        private void Select_yagl()
        {
            struct_yagl.p_mc = ddlt_mc_yagl.SelectedValue.Trim().ToString();//名称
            struct_yagl.p_dq = ddlt_dq_yagl.SelectedValue.Trim().ToString();//地区
            struct_yagl.p_zy = ddlt_zy_yagl.SelectedValue.Trim().ToString(); //专业
            struct_yagl.p_zt = ddlt_zt_yagl.SelectedValue.Trim().ToString(); //状态
            struct_yagl.p_currentpage = pg_fy.CurrentPage;
            struct_yagl.p_pagesize = pg_fy.NumPerPage;
            struct_yagl.p_userid = _usState.userID;
            int count = yagl.Select_Yj_Yagl_Count_Proc(struct_yagl);
            pg_fy.TotalRecord = count;
            DataTable dt = yagl.Select_YJ_YAGL_Proc(struct_yagl);
            dt.Columns.Add("zxdm");
            dt.Columns.Add("zylx");
            dt.Columns.Add("ztmc");


            foreach (DataRow dr in dt.Rows)
            {
                dr["zxdm"] = SysData.ZXDMByKey(dr["dq"].ToString()).mc;
                dr["zylx"] = SysData.ZYLXByKey(dr["zy"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            //绑定分页数据源  
            this.Repeater_yagl.DataSource = dt.DefaultView;
            this.Repeater_yagl.DataBind();
        }
        private void ddltBind_ylgl()
        {
            //绑定支线名称
            ddlt_dq_ylgl.DataTextField = "mc";
            ddlt_dq_ylgl.DataValueField = "bm";
            ddlt_dq_ylgl.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_ylgl.DataBind();
            ddlt_dq_ylgl.Items.Insert(0, new ListItem("全部", "-1"));

            //绑定预案名
            ddlt_yam_ylgl.DataTextField = "mc";
            ddlt_yam_ylgl.DataValueField = "sjc";
            ddlt_yam_ylgl.DataSource = ylgl.Select_Ylgl_Yam_Mc().Copy();
            ddlt_yam_ylgl.DataBind();
            ddlt_yam_ylgl.Items.Insert(0, new ListItem("全部", "-1"));

            //所属演练形式
            ddlt_ylxs_ylgl.DataTextField = "mc";
            ddlt_ylxs_ylgl.DataValueField = "bm";
            ddlt_ylxs_ylgl.DataSource = SysData.YLXS().Copy();
            ddlt_ylxs_ylgl.DataBind();
            ddlt_ylxs_ylgl.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt_ylgl.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_ylgl.DataTextField = "mc";
            ddlt_zt_ylgl.DataValueField = "bm";
            ddlt_zt_ylgl.DataBind();
            ddlt_zt_ylgl.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Select_ylgl()
        {
            struct_ylgl.p_dq = ddlt_dq_ylgl.SelectedValue.Trim().ToString();
            struct_ylgl.p_yam = ddlt_yam_ylgl.SelectedValue.Trim().ToString();
            struct_ylgl.p_ylxs = ddlt_ylxs_ylgl.SelectedValue.Trim().ToString();
            struct_ylgl.p_zt = ddlt_zt_ylgl.SelectedValue.Trim().ToString();
            struct_ylgl.p_currentpage = pg_fy.CurrentPage;
            struct_ylgl.p_pagesize = pg_fy.NumPerPage;
            struct_ylgl.p_userid = _usState.userID;
            int count = ylgl.Select_YLGL_Count(struct_ylgl);
            pg_fy.TotalRecord = count;
            DataTable dt = ylgl.Select_Ylgl(struct_ylgl);
            dt.Columns.Add("ylxsmc");
            dt.Columns.Add("dqmc");
            dt.Columns.Add("yammc");
            dt.Columns.Add("ylsjmc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ylxsmc"] = SysData.YLXSByKey(dr["ylxs"].ToString()).mc;
                dr["dqmc"] = SysData.ZXDMByKey(dr["dq"].ToString()).mc;
                dr["yammc"] = ylgl.YAMByKey(dr["yam"].ToString());
                dr["ylsjmc"] = DateTime.Parse(dr["ylsj"].ToString()).ToString("yyyy-MM-dd");
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            ////绑定分页数据源  
            this.Repeater_ylgl.DataSource = dt.DefaultView;
            this.Repeater_ylgl.DataBind();
        }
        #region GetCut
        //截取字符串(如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串)
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">规定该字符串显示的长度</param>
        /// <returns>结果字符串</returns>
        public string GetCut(string str, int len)
        {
            //如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串
            if (str.Length > len)
            {
                return str.Substring(0, len) + "...";

            }
            else
            {
                return str;
            }
        }
        #endregion
        protected void btn_selectYAGL_Click(object sender, EventArgs e) {
            Select_yagl();
        }
        protected void btn_selectYLGL_Click(object sender, EventArgs e)
        {
            Select_ylgl();
        }
        protected void Repeater_YAGL_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_yagl.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_yagl");
                if (lbl_zt.Text == "待提交")//0
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Blue;
                }
                if (lbl_zt.Text == "待初审")//1
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "待终审")//2
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "审核通过")//3
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_zt.Text == "审核未通过")//4
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void Repeater_YLGL_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_ylgl.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_ylgl");
                if (lbl_zt.Text == "待提交")//0
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Blue;
                }
                if (lbl_zt.Text == "待初审")//1
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "待终审")//2
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "审核通过")//3
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_zt.Text == "审核未通过")//4
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void pg_yagl_PageChanged(object sender, EventArgs e)
        {
            Select_yagl();
        }
        protected void pg_ylgl_PageChanged(object sender, EventArgs e)
        {
            Select_ylgl();
        }
    }
}