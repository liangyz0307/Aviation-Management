﻿using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Globalization;

namespace CUST.WKG
{
    public partial class JS_YG : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YG yg;
        public string dm1;
        public string dm2;
        public bool flag = true;
        public int i = 0;
        private Struct_YG struct_yg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = pg_fy.NumPerPage;
            yg = new YG(_usState);
            struct_yg = new Struct_YG();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();

            }
        }
        private void ddltBind()
        {
            //绑定部门代码ddlt_bmdm
            DataTable dt_bmdm = SysData.BM().Copy();
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //岗位代码
            //DataTable dt_gw = new DataTable();
            //ddlt_gwdm.DataSource = dt_gw;
            //ddlt_gwdm.DataBind();
            //ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

            //民族
            ddlt_mz.DataSource = SysData.MZ().Copy();
            ddlt_mz.DataTextField = "mc";
            ddlt_mz.DataValueField = "bm";
            ddlt_mz.DataBind();
            ddlt_mz.Items.Insert(0, new ListItem("全部", "-1"));

            //性别
            ddlt_xb.DataSource = SysData.XB().Copy();
            ddlt_xb.DataTextField = "mc";
            ddlt_xb.DataValueField = "bm";
            ddlt_xb.DataBind();
            ddlt_xb.Items.Insert(0, new ListItem("全部", "-1"));

            //政治面貌
            ddlt_zzmm.DataSource = SysData.ZZMM().Copy();
            ddlt_zzmm.DataTextField = "mc";
            ddlt_zzmm.DataValueField = "bm";
            ddlt_zzmm.DataBind();
            ddlt_zzmm.Items.Insert(0, new ListItem("全部", "-1"));

            //比较标识
            //ddlt_bjbs.DataSource = SysData.BJBS().Copy();
            //ddlt_bjbs.DataTextField = "mc";
            //ddlt_bjbs.DataValueField = "bm";
            //ddlt_bjbs.DataBind();
            //ddlt_bjbs.Items.Insert(0, new ListItem("全部", "-1"));

            //合同类型
            ddlt_htlx.DataSource = SysData.HTLX().Copy();
            ddlt_htlx.DataTextField = "mc";
            ddlt_htlx.DataValueField = "bm";
            ddlt_htlx.DataBind();
            ddlt_htlx.Items.Insert(0, new ListItem("全部", "-1"));

        }
        public void GW(string bm)
        {

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
            if (ddlt_bmdm.SelectedValue == "-2")
            {
                Response.Write("<script>alert('请选择部门！')</script>");
                return;
            }
            bind_Main();
        }
        private void bind_Main()
        {

            struct_yg.p_bh = tbx_bh.Text.Trim().ToString();
            struct_yg.p_xm = tbx_ygxm.Text.Trim().ToString();
            struct_yg.p_sfzh = "";
            struct_yg.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();
            struct_yg.p_gwdm = ddlt_gwdm.SelectedValue.ToString().Trim();
            struct_yg.p_zt = ddlt_zt.SelectedValue.ToString().Trim();
            struct_yg.p_mz = ddlt_mz.SelectedValue.ToString().Trim();//民族
            struct_yg.p_zzmm = ddlt_zzmm.SelectedValue.ToString().Trim();//政治面貌
            struct_yg.p_xb = ddlt_xb.SelectedValue.ToString().Trim();//性别
            struct_yg.p_htlx = ddlt_htlx.SelectedValue.ToString().Trim();//合同类型
            if (tbx_csrq_qs.Text.Trim().ToString() == "")
            {
                struct_yg.p_csrq_qs = Convert.ToDateTime("0001-1-20");
            }
            else
            {
                struct_yg.p_csrq_qs = DateTime.Parse(tbx_csrq_qs.Text.Trim().ToString());//起始日期
            }
            if (tbx_csrq_jz.Text.Trim().ToString() == "")
            {
                struct_yg.p_csrq_jz = Convert.ToDateTime("9999-12-20");
            }
            else
            {
                struct_yg.p_csrq_jz = DateTime.Parse(tbx_csrq_jz.Text.Trim().ToString());//截止日期
            }
            //struct_yg.p_bjbs = ddlt_bjbs.SelectedValue.ToString().Trim();//比较标识
            struct_yg.p_userid = _usState.userID;
            DataTable dt = new DataTable();
            //判断是否为普通员工
            if (!SysData.SFS_GLY(_usState.userLoginName))
            {
                int count = yg.Select_YGCount_Ptyg(struct_yg);
                pg_fy.TotalRecord = count;
                struct_yg.p_currentpage = pg_fy.CurrentPage;
                struct_yg.p_pagesize = pg_fy.NumPerPage;
                dt = yg.Select_YG_Pro_Ptyg(struct_yg);

            }
            else
            {
                int count = yg.Select_YGCount(struct_yg);
                pg_fy.TotalRecord = count;
                struct_yg.p_currentpage = pg_fy.CurrentPage;
                struct_yg.p_pagesize = pg_fy.NumPerPage;
                dt = yg.Select_YG_Pro(struct_yg);

            }
            dt.Columns.Add("bmmc");
            dt.Columns.Add("gwmc");
            dt.Columns.Add("xbmc");
            dt.Columns.Add("zzmm");
            dt.Columns.Add("xl");
            dt.Columns.Add("gzdd");
            dt.Columns.Add("rq");//出生日期
            dt.Columns.Add("ztmc");
            // dt.Columns.Add("sj");//毕业时间
            foreach (DataRow dr in dt.Rows)
            {
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["bmdm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                dr["gwdm"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                dr["xbmc"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["zzmm"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//政治面貌
                dr["xl"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历
                dr["xldm"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历
                dr["gzdd"] = SysData.ZXDMByKey(dr["gzddm"].ToString()).mc;//工作地
                dr["gzddm"] = SysData.ZXDMByKey(dr["gzddm"].ToString()).mc;//工作地代码
                dr["htgx"] = SysData.HTGXByKey(dr["htgx"].ToString()).mc;//合同关系
                dr["htlxdm"] = SysData.HTLXByKey(dr["htlxdm"].ToString()).mc;//合同类型
                dr["mzdm"] = SysData.MZByKey(dr["mzdm"].ToString()).mc;//名族
                dr["xbdm"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;//性别
                dr["zzmmdm"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//政治面貌代码

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["csrq"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["rq"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bmdm.SelectedValue;
            GW(bm);
        }

    }
}










