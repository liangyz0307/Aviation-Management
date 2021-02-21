using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sys;
using CUST.MKG;
using System.Data;
using CUST.Sys;
using CUST.Tools;
using System.Globalization;
using System.IO;

namespace CUST.WKG
{
    public partial class JS_SKJS : System.Web.UI.Page
    {
        private UserState _us;

        public int cpage_sbblk;
        public int psize_sbblk;
        public int cpage_wxy;
        public int psize_wxy;
        public int cpage_aqyhk;
        public int psize_aqyhk;
        public int cpage_aqwtk;
        public int psize_aqwtk;
        public int cpage_zjk;
        public int psize_zjk;

        private SBBLK sbblk;
        private WXY wxy;
        private AQYHK aqyhk;
        private AQWTK aqwtk;
        private ZJK zjk;

        private Struct_Select_SBBLK struct_sbblk;
        private Struct_WXY struct_wxy;
        private Struct_Select_AQYHK struct_aqyhk;
        private Struct_AQWTK struct_aqwtk;
        private Struct_ZJK_Pro struct_zjk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            cpage_sbblk = Pager_sbblk.CurrentPage;
            psize_sbblk = Pager_sbblk.NumPerPage;
            cpage_wxy = Pager_wxy.CurrentPage;
            psize_wxy = Pager_wxy.NumPerPage;
            cpage_aqyhk = Pager_aqyhk.CurrentPage;
            psize_aqyhk = Pager_aqyhk.NumPerPage;
            cpage_aqwtk = Pager_aqwtk.CurrentPage;
            psize_aqwtk = Pager_aqwtk.NumPerPage;
            cpage_zjk = Pager_zjk.CurrentPage;
            psize_zjk = Pager_zjk.NumPerPage;

            sbblk = new SBBLK(_us);
            wxy= new WXY(_us);
            aqyhk = new AQYHK(_us);
            aqwtk = new AQWTK(_us);
            zjk = new ZJK(_us);

            struct_aqwtk = new Struct_AQWTK();
            if (!IsPostBack)
            {
                Bind_zxt();
                div_sbblk.Attributes.Add("style", "display:none");
                div_wxy.Attributes.Add("style", "display:none");
                div_aqyhk.Attributes.Add("style", "display:none");
                div_aqwtk.Attributes.Add("style", "display:none");
                div_zjk.Attributes.Add("style", "display:none");

                tbx_fssj_ks.Attributes.Add("readonly", "readonly");
                tbx_fssj_js.Attributes.Add("readonly", "readonly");
                tbx_tbrq_ks.Attributes.Add("readonly", "readonly");
                tbx_tbrq_js.Attributes.Add("readonly", "readonly");


            }
        }

        #region Bindzxt
        protected void Bind_zxt()
        {
            //ddlt_zxt.DataTextField = "mc";
            //ddlt_zxt.DataValueField = "bm";
            //ddlt_zxt.DataBind();
            ddlt_zxt.Items.Insert(0, new ListItem("请选择", "-1"));
            ddlt_zxt.Items.Insert(1, new ListItem("设备病例库", "200101"));
            ddlt_zxt.Items.Insert(2, new ListItem("危险源库", "200201"));
            ddlt_zxt.Items.Insert(3, new ListItem("安全隐患库", "200301"));
            ddlt_zxt.Items.Insert(4, new ListItem("安全问题库", "200401"));
            ddlt_zxt.Items.Insert(5, new ListItem("专家信息库", "200501"));
        }

        #endregion
        protected void Authority(object sender, EventArgs e)
        {
            if (ddlt_zxt.SelectedValue == "-1")
            {
                div_sbblk.Attributes.Add("style", "display:none");
                div_wxy.Attributes.Add("style", "display:none");
                div_aqyhk.Attributes.Add("style", "display:none");
                div_aqwtk.Attributes.Add("style", "display:none");
                div_zjk.Attributes.Add("style", "display:none");
            }
            if (ddlt_zxt.SelectedValue== "200101")
            {
                div_sbblk.Attributes.Add("style", "display:ture");
                div_wxy.Attributes.Add("style", "display:none");
                div_aqyhk.Attributes.Add("style", "display:none");
                div_aqwtk.Attributes.Add("style", "display:none");
                div_zjk.Attributes.Add("style", "display:none");
                Bind_sbblk();
                Main_sbblk();
            }
            if (ddlt_zxt.SelectedValue == "200201")
            {
                div_wxy.Attributes.Add("style", "display:ture");
                div_sbblk.Attributes.Add("style", "display:none");
                div_aqyhk.Attributes.Add("style", "display:none");
                div_aqwtk.Attributes.Add("style", "display:none");
                div_zjk.Attributes.Add("style", "display:none");
                Bind_wxy();
                Main_wxy(); 
            }
            if (ddlt_zxt.SelectedValue == "200301")
            {
                div_aqyhk.Attributes.Add("style", "display:ture");
                div_sbblk.Attributes.Add("style", "display:none");
                div_wxy.Attributes.Add("style", "display:none");
                div_aqwtk.Attributes.Add("style", "display:none");
                div_zjk.Attributes.Add("style", "display:none");
                Bind_aqyhk();
                Main_aqyhk();
            }
            if (ddlt_zxt.SelectedValue == "200401")
            {
                div_aqwtk.Attributes.Add("style", "display:ture");
                div_sbblk.Attributes.Add("style", "display:none");
                div_wxy.Attributes.Add("style", "display:none");
                div_aqyhk.Attributes.Add("style", "display:none");
                div_zjk.Attributes.Add("style", "display:none");
                Bind_aqwtk();
                Main_aqwtk();
            }
            if (ddlt_zxt.SelectedValue == "200501")
            {
                div_aqwtk.Attributes.Add("style", "display:none");
                div_sbblk.Attributes.Add("style", "display:none");
                div_wxy.Attributes.Add("style", "display:none");
                div_aqyhk.Attributes.Add("style", "display:none");
                div_zjk.Attributes.Add("style", "display:ture");
                Bind_zjk();
                Main_zjk();
            }
        }

        #region Main
        private void Main_sbblk()
        {
            struct_sbblk.p_sbmc = tbx_sbmc.Text.Trim().ToString();//设备名称
            struct_sbblk.p_bypc = ddlt_bypc.SelectedValue.ToString();//保养频次
            struct_sbblk.p_userid = _us.userID;
            struct_sbblk.p_currentpage = Pager_sbblk.CurrentPage;
            struct_sbblk.p_pagesize = Pager_sbblk.NumPerPage;
            int count = sbblk.Select_SBBLK_Count(struct_sbblk);

            Pager_sbblk.TotalRecord = count;
            DataTable dt_sbblk = sbblk.Select_SBBLK_Pro(struct_sbblk);
            dt_sbblk.Columns.Add("bypcmc");
            dt_sbblk.Columns.Add("gzsjs");
            dt_sbblk.Columns.Add("pgsjs");
            dt_sbblk.Columns.Add("syrxm");
            dt_sbblk.Columns.Add("wxryxm");
            dt_sbblk.Columns.Add("ztmc_sbblk");
            string[] Array_syr = null;
            string[] Array_wxry = null;
            foreach (DataRow dr in dt_sbblk.Rows)
            {
                Array_syr = dr["syr"].ToString().Split(',');
                Array_wxry = dr["wxry"].ToString().Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += sbblk.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                foreach (string wxryxm_dm in Array_wxry)
                {
                    dr["wxryxm"] += sbblk.Select_YGXMbyBH(wxryxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                dr["bypcmc"] = SysData.BYPCByKey(dr["bypc"].ToString()).mc;
                dr["gzsjs"] = DateTime.Parse(dr["gzsj"].ToString()).ToString("yyyy-MM-dd");
                dr["pgsjs"] = DateTime.Parse(dr["pgsj"].ToString()).ToString("yyyy-MM-dd");
                dr["ztmc_sbblk"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                //绑定分页数据源
            }
            this.Repeater_sbblk.DataSource = dt_sbblk.DefaultView;
            this.Repeater_sbblk.DataBind();
        }
        private void Main_wxy()
        {
            struct_wxy.p_userid = _us.userID;
            struct_wxy.p_mc = tbx_mc.Text.ToString().Trim();
            struct_wxy.p_gw = ddlt_gw.SelectedValue.ToString().Trim();//报送岗位
            struct_wxy.p_kzzt = ddlt_kzzt.SelectedValue.ToString().Trim();//控制状态
            struct_wxy.p_zt = ddlt_zt_wxy.SelectedValue.ToString().Trim();//状态
            int count = wxy.Select_WXY_Count(struct_wxy);
            Pager_wxy.TotalRecord = count;
            struct_wxy.p_currentpage = Pager_wxy.CurrentPage;
            struct_wxy.p_pagesize = Pager_wxy.NumPerPage;
            DataTable dt_wxy = wxy.Select_WXY_Pro(struct_wxy);
            dt_wxy.Columns.Add("gwmc");
            dt_wxy.Columns.Add("stmc");
            dt_wxy.Columns.Add("wztmc");
            dt_wxy.Columns.Add("knxmc");
            dt_wxy.Columns.Add("kzztmc");
            dt_wxy.Columns.Add("ztmc_wxy");
            foreach (DataRow dr in dt_wxy.Rows)
            {
                dr["gwmc"] = SysData.GWByKey(dr["gw"].ToString()).mc;
                dr["stmc"] = SysData.STDMByKey(dr["st"].ToString()).mc;
                dr["knxmc"] = SysData.FXFSKNByKey(dr["knx"].ToString()).mc;
                dr["kzztmc"] = SysData.FXKZZTByKey(dr["kzzt"].ToString()).mc;
                dr["ztmc_wxy"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            //绑定分页数据源  
            this.Repeater_wxy.DataSource = dt_wxy.DefaultView;
            this.Repeater_wxy.DataBind();
        }
        private void Main_aqyhk()
        {
            #region 判断
            if (tbx_tbrq_ks.Text == "")
            {
                struct_aqyhk.p_tbrq_ks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_aqyhk.p_tbrq_ks = DateTime.Parse(tbx_tbrq_ks.Text.ToString().Trim());
            }
            if (tbx_tbrq_js.Text == "")
            {
                struct_aqyhk.p_tbrq_js = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_aqyhk.p_tbrq_js = DateTime.Parse(tbx_tbrq_js.Text.ToString().Trim());
            }
            #endregion
            struct_aqyhk.p_ly = ddlt_ly_aqyhk.SelectedValue.Trim().ToString();
            struct_aqyhk.p_zt = ddlt_zt_aqyhk.SelectedValue.Trim().ToString();
            struct_aqyhk.p_yhdj = ddlt_yhdj.SelectedValue.Trim().ToString();
            struct_aqyhk.p_ygbh = "";
            struct_aqyhk.p_userid = _us.userID;
            int count = aqyhk.Select_AQYHK_Count(struct_aqyhk);
            Pager_aqyhk.TotalRecord = count;
            struct_aqyhk.p_currentpage = Pager_aqyhk.CurrentPage;
            struct_aqyhk.p_pagesize = Pager_aqyhk.NumPerPage;
            DataTable dt_aqyhk = aqyhk.Select_AQYHK_Pro(struct_aqyhk);
            dt_aqyhk.Columns.Add("tbdwmc");
            dt_aqyhk.Columns.Add("yhdjmc");
            dt_aqyhk.Columns.Add("zgzrdwmc");
            dt_aqyhk.Columns.Add("zggbpzmc");
            dt_aqyhk.Columns.Add("ztmc_aqyhk");
            dt_aqyhk.Columns.Add("yhfxsjz");
            dt_aqyhk.Columns.Add("zgwcsxz");
            dt_aqyhk.Columns.Add("lymc");
            foreach (DataRow dr in dt_aqyhk.Rows)
            {
                string[] Array_zgzzr = dr["zgzrr"].ToString().Split(',');
                string[] Array_zgdbzrr = dr["zgdbzrr"].ToString().Split(',');
                string[] Array_zgyzr = dr["zgyzr"].ToString().Split(',');
                dr["tbdwmc"] = SysData.BMByKey(dr["tbdw"].ToString()).mc;
                dr["ztmc_aqyhk"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["yhdjmc"] = SysData.YHDJByKey(dr["yhdj"].ToString()).mc;
                dr["lymc"] = SysData.LYByKey(dr["ly"].ToString()).mc;
                dr["zgzrdwmc"] = SysData.BMByKey(dr["zgzrdw"].ToString()).mc;
                dr["zggbpzmc"] = SysData.ZGGBPZByKey(dr["zggbpz"].ToString()).mc;
                dr["yhfxsjz"] = DateTime.Parse(dr["yhfxsj"].ToString()).ToString("yyyy-MM-dd");
                dr["zgwcsxz"] = DateTime.Parse(dr["zgwcsx"].ToString()).ToString("yyyy-MM-dd");
            }
            //绑定分页数据源  
            this.Repeater_aqyhk.DataSource = dt_aqyhk.DefaultView;
            this.Repeater_aqyhk.DataBind();
        }
        private void Main_aqwtk()
        {
            #region 判断
            if (tbx_fssj_ks.Text == "")
            {
                struct_aqwtk.p_fssj_ks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_aqwtk.p_fssj_ks = DateTime.Parse(tbx_fssj_ks.Text.ToString().Trim());
            }
            if (tbx_fssj_js.Text == "")
            {
                struct_aqwtk.p_fssj_js = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_aqwtk.p_fssj_js = DateTime.Parse(tbx_fssj_js.Text.ToString().Trim());
            }
            #endregion
            struct_aqwtk.p_ly = ddlt_ly_aqwtk.SelectedValue.Trim().ToString();
            struct_aqwtk.p_sjfc = ddlt_sjfc.Text.ToString().Trim();
            struct_aqwtk.p_zrbm = ddlt_zrbm.SelectedValue.Trim().ToString();
            struct_aqwtk.p_zt = ddlt_zt_aqwtk.SelectedValue.Trim().ToString();
            struct_aqwtk.p_userid = _us.userID;
            int count = aqwtk.Select_AQWTK_Count(struct_aqwtk);
            Pager_aqwtk.TotalRecord = count;
            struct_aqwtk.p_currentpage = Pager_aqwtk.CurrentPage;
            struct_aqwtk.p_pagesize = Pager_aqwtk.NumPerPage;
            DataTable dt_aqwtk = aqwtk.Select_AQWTK(struct_aqwtk);
            dt_aqwtk.Columns.Add("lymc");
            dt_aqwtk.Columns.Add("ztmc_aqwtk");
            dt_aqwtk.Columns.Add("sjfcmc");
            dt_aqwtk.Columns.Add("wtkzztmc");
            dt_aqwtk.Columns.Add("zrbmmc");
            dt_aqwtk.Columns.Add("fssjz");
            dt_aqwtk.Columns.Add("zgsxz");

            foreach (DataRow dr in dt_aqwtk.Rows)
            {

                dr["lymc"] = SysData.LYByKey(dr["ly"].ToString()).mc;
                dr["ztmc_aqwtk"] = SysData.ZTByKey(dr["zt"].ToString()).mc;
                dr["sjfcmc"] = SysData.SJFCByKey(dr["sjfc"].ToString()).mc;
                dr["wtkzztmc"] = SysData.WTZTByKey(dr["wtkzzt"].ToString()).mc;
                dr["zrbmmc"] = SysData.BMByKey(dr["zrbm"].ToString()).mc;
                dr["fssjz"] = DateTime.Parse(dr["fssj"].ToString()).ToString("yyyy-MM-dd");
                dr["zgsxz"] = DateTime.Parse(dr["zgsx"].ToString()).ToString("yyyy-MM-dd");

            }
            //绑定分页数据源  
            this.Repeater_aqwtk.DataSource = dt_aqwtk.DefaultView;
            this.Repeater_aqwtk.DataBind();
        }
        private void Main_zjk()
        {
            struct_zjk.p_xm = tbx_xm.Text.Trim().ToString();
            struct_zjk.p_bmdm = "-1";//部门代码
            struct_zjk.p_zjlx = ddlt_zjlx.SelectedValue.Trim().ToString();
            struct_zjk.p_zt = ddlt_zt_zjk.SelectedValue.Trim().ToString();//状态

            struct_zjk.p_userid = _us.userID;
            DataTable dt = new DataTable();
            int count = zjk.Select_ZJK_Count(struct_zjk);
            Pager_zjk.TotalRecord = count;
            struct_zjk.p_currentpage = Pager_zjk.CurrentPage;
            struct_zjk.p_pagesize = Pager_zjk.NumPerPage;
            dt = zjk.Select_ZJK_Pro(struct_zjk);

            dt.Columns.Add("bm");
            dt.Columns.Add("zjlxmc");
            dt.Columns.Add("ztmc");

            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["zjlxmc"] = SysData.ZJLXByKey(dr["zjlx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            //绑定分页数据源  
            this.Repeater_zjk.DataSource = dt.DefaultView;
            this.Repeater_zjk.DataBind();
        }
        #endregion

        #region Bind
        protected void Bind_sbblk()
        {
            //绑定保养频次
            ddlt_bypc.DataSource = SysData.BYPC().Copy();
            ddlt_bypc.DataTextField = "mc";
            ddlt_bypc.DataValueField = "bm";
            ddlt_bypc.DataBind();
            ddlt_bypc.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void Bind_wxy()
        {
            //状态
            ddlt_zt_wxy.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_wxy.DataTextField = "mc";
            ddlt_zt_wxy.DataValueField = "bm";
            ddlt_zt_wxy.DataBind();
            ddlt_zt_wxy.Items.Insert(0, new ListItem("全部", "-1"));
            //控制状态
            ddlt_kzzt.DataSource = SysData.FXKZZT().Copy();
            ddlt_kzzt.DataTextField = "mc";
            ddlt_kzzt.DataValueField = "bm";
            ddlt_kzzt.DataBind();
            ddlt_kzzt.Items.Insert(0, new ListItem("全部", "-1"));
            //报送岗位
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void Bind_aqyhk()
        {
            //隐患等级
            ddlt_yhdj.DataSource = SysData.YHDJ().Copy();
            ddlt_yhdj.DataTextField = "mc";
            ddlt_yhdj.DataValueField = "bm";
            ddlt_yhdj.DataBind();
            ddlt_yhdj.Items.Insert(0, new ListItem("全部", "-1"));
            //来源
            ddlt_ly_aqyhk.DataSource = SysData.LY().Copy();
            ddlt_ly_aqyhk.DataTextField = "mc";
            ddlt_ly_aqyhk.DataValueField = "bm";
            ddlt_ly_aqyhk.DataBind();
            ddlt_ly_aqyhk.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt_aqyhk.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_aqyhk.DataTextField = "mc";
            ddlt_zt_aqyhk.DataValueField = "bm";
            ddlt_zt_aqyhk.DataBind();
            ddlt_zt_aqyhk.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void Bind_aqwtk()
        {
            //来源
            ddlt_ly_aqwtk.DataSource = SysData.LY().Copy();
            ddlt_ly_aqwtk.DataTextField = "mc";
            ddlt_ly_aqwtk.DataValueField = "bm";
            ddlt_ly_aqwtk.DataBind();
            ddlt_ly_aqwtk.Items.Insert(0, new ListItem("全部", "-1"));
            //涉及范畴
            ddlt_sjfc.DataSource = SysData.SJFC().Copy();
            ddlt_sjfc.DataTextField = "mc";
            ddlt_sjfc.DataValueField = "bm";
            ddlt_sjfc.DataBind();
            ddlt_sjfc.Items.Insert(0, new ListItem("全部", "-1"));
            //责任部门
            ddlt_zrbm.DataSource = SysData.BM().Copy();
            ddlt_zrbm.DataTextField = "mc";
            ddlt_zrbm.DataValueField = "bm";
            ddlt_zrbm.DataBind();
            ddlt_zrbm.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt_aqwtk.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_aqwtk.DataTextField = "mc";
            ddlt_zt_aqwtk.DataValueField = "bm";
            ddlt_zt_aqwtk.DataBind();
            ddlt_zt_aqwtk.Items.Insert(0, new ListItem("全部", "-1"));

        }

        protected void Bind_zjk()
        {

            //奖励等级
            ddlt_zjlx.DataSource = SysData.ZJLX().Copy();
            ddlt_zjlx.DataTextField = "mc";
            ddlt_zjlx.DataValueField = "bm";
            ddlt_zjlx.DataBind();
            ddlt_zjlx.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt_zjk.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_zjk.DataTextField = "mc";
            ddlt_zt_zjk.DataValueField = "bm";
            ddlt_zt_zjk.DataBind();
            ddlt_zt_zjk.Items.Insert(0, new ListItem("全部", "-1"));

        }
        #endregion

        #region Select
        protected void btn_select_Click_sbblk(object sender, EventArgs e)
        {
            Main_sbblk();
        }
        protected void btn_select_Click_wxy(object sender, EventArgs e)
        {
            Main_wxy();
        }
        protected void btn_select_Click_aqyhk(object sender, EventArgs e)
        {
            Main_aqyhk();
        }
        protected void btn_select_Click_aqwtk(object sender, EventArgs e)
        {
            Main_aqwtk();
        }
        protected void btn_select_Click_zjk(object sender, EventArgs e)
        {
            Main_zjk();
        }
        #endregion

        #region pg_fy_PageChanged
        protected void pg_fy_PageChanged_sbblk(object sender, EventArgs e)
        {
            Main_sbblk();
        }
        protected void pg_fy_PageChanged_wxy(object sender, EventArgs e)
        {
            Main_wxy();
        }
        protected void pg_fy_PageChanged_aqyhk(object sender, EventArgs e)
        {
            Main_aqyhk();
        }
        protected void pg_fy_PageChanged_aqwtk(object sender, EventArgs e)
        {
            Main_aqwtk();
        }
        protected void pg_fy_PageChanged_zjk(object sender, EventArgs e)
        {
            Main_zjk();
        }
        #endregion




    }
}