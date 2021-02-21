using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class JS_SBBJ : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private BJ bj;
        private Struct_BJ struct_bj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            //cpage = pg_fy.CurrentPage;
            //pg_fy.NumPerPage = _usState.C_SB_BJ;
            //psize = _usState.C_SB_BJ;

            bj = new BJ(_usState);
            struct_bj = new Struct_BJ();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();

            }
        }
        private void ddltBind()
        {
            //绑定备件分类 ddlt_bjfl
            ddlt_bjfl.DataTextField = "mc";
            ddlt_bjfl.DataValueField = "bm";
            ddlt_bjfl.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl.DataBind();
            ddlt_bjfl.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            string sbbh = tbx_sbbh.Text.Trim().ToString().Trim();
            string bjmc = tbx_sbmc.Text.ToString().Trim();
            string sbxh = tbx_sbxh.Text.Trim().ToString().Trim();
            string bjfl = ddlt_bjfl.SelectedValue.ToString();


            struct_bj.p_bjbh = sbbh;
            struct_bj.p_bjmc = bjmc;
            struct_bj.p_bjfl = bjfl;
            struct_bj.p_sy = "-1";
            struct_bj.p_sbxh = sbxh;
            struct_bj.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态
            struct_bj.p_zxdm = _usState.userSS;
            struct_bj.p_userid = _usState.userID;

            int count = bj.Select_BJ_Count(struct_bj);
            pg_fy.TotalRecord = count;
            struct_bj.p_currentpage = pg_fy.CurrentPage;
            struct_bj.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = bj.Select_BJ_Pro(struct_bj).Tables[0];

            dt.Columns.Add("bm");
            dt.Columns.Add("bjflmc");
            dt.Columns.Add("symc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjflmc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;//备件分类
                dr["symc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;//备件分类
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
            }

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            //{
            //    Label lbl_zt = (Label)li.FindControl("lbl_byyx");
            //    if (lbl_zt.Text == "待提交")//0
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Blue;
            //    }
            //    if (lbl_zt.Text == "待初审")//1
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
            //    }
            //    if (lbl_zt.Text == "待终审")//2
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
            //    }
            //    if (lbl_zt.Text == "审核通过")//3
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Green;
            //    }
            //    if (lbl_zt.Text == "审核未通过")//4
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
        }
    }
}