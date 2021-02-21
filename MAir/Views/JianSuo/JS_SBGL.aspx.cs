using CUST.Sys;
using System;
using System.Web.UI.WebControls;
using System.Data;
using CUST.MKG;
using Sys;
using System.Text.RegularExpressions;
using CUST.Tools;

namespace CUST.WKG
{
    public partial class JS_SBGL : System.Web.UI.Page
    {
        #region 分页
        public int cpage_dhsb;
        public int psize_dhsb;
        public int cpage_txsb;
        public int psize_txsb;
        public int cpage_qxsb;
        public int psize_qxsb;
        public int cpage_jssb;
        public int psize_jssb;
        public int cpage_tzgl;
        public int psize_tzgl;
        public int cpage_bjgl;
        public int psize_bjgl;
        public int cpage_bjck;
        public int psize_bjck;
        public int cpage_bjrk;
        public int psize_bjrk;
        public int cpage_sbgz;
        public int psize_sbgz;
        public int cpage_sbwh;
        public int psize_sbwh;
        #endregion
        #region
        private UserState _usState;
        private BJ_GL bjgl;
        private SBBJ_CK bjck;
        private SBBJ_RK bjrk;

        private DHSB dhsb;
        private Struct_DHSB struct_dhsb;
        private TXSB txsb;
        private Struct_TXSB struct_txsb;
        private QXSB qxsb;
        private Struct_QXSB struct_qxsb;
        private JSSB jssb;
        private Struct_JSSB struct_jssb;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private Struct_BJ struct_bj;
        private BJ bj;
        private Struct_BJCK struct_bjck;
        private Struct_BJRK struct_bjrk;
        private WHWX wh;
        private Struct_SBGZ struct_sbgz;
        private Struct_SBWH struct_sbwh;
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
            dhsb = new DHSB(_usState);
            struct_dhsb = new Struct_DHSB();
            txsb = new TXSB(_usState);
            struct_txsb = new Struct_TXSB();           
            qxsb = new QXSB(_usState);
            struct_qxsb = new Struct_QXSB();
            jssb = new JSSB(_usState);
            struct_jssb = new Struct_JSSB();
            tzsb = new TZSB(_usState);
            struct_tzsb = new Struct_TZSB();
            bj = new BJ(_usState);
            struct_bj = new Struct_BJ();
            struct_bjck = new Struct_BJCK();
            struct_bjrk = new Struct_BJRK();
            wh = new WHWX(_usState);
            struct_sbgz = new Struct_SBGZ();
            struct_sbwh = new Struct_SBWH();

            //导航
            cpage_dhsb = pg_dhsb.CurrentPage;
            pg_dhsb.NumPerPage = _usState.C_SB_DH;
            psize_dhsb = _usState.C_SB_DH;
            //通信
            cpage_txsb = pg_txsb.CurrentPage;
            pg_txsb.NumPerPage = _usState.C_SB_TX;
            psize_txsb = _usState.C_SB_TX;
            //气象
            cpage_qxsb = pg_qxsb.CurrentPage;
            pg_qxsb.NumPerPage = _usState.C_SB_QX;
            psize_qxsb = _usState.C_SB_QX;
            //监视
            cpage_jssb = pg_jssb.CurrentPage;
            pg_jssb.NumPerPage = _usState.C_SB_JS;
            psize_jssb = _usState.C_SB_JS;
            //台站
            cpage_tzgl = pg_tzgl.CurrentPage;
            pg_tzgl.NumPerPage = _usState.C_SB_TZ;
            psize_tzgl = _usState.C_SB_TZ;
            //备件管理
            cpage_bjgl = pg_bjgl.CurrentPage;
            pg_bjgl.NumPerPage = _usState.C_SB_BJGL;
            psize_bjgl = _usState.C_SB_BJGL;
            //备件出库
            cpage_bjck = pg_bjck.CurrentPage;
            pg_bjck.NumPerPage = _usState.C_SB_BJCK;
            psize_bjck = _usState.C_SB_BJCK;
            //备件入库
            cpage_bjrk = pg_bjrk.CurrentPage;
            pg_bjrk.NumPerPage = _usState.C_SB_BJRK;
            psize_bjrk = _usState.C_SB_BJRK;
            //设备故障
            cpage_sbgz = pg_sbgz.CurrentPage;
            pg_sbgz.NumPerPage = _usState.C_SB_GZ;
            psize_sbgz = _usState.C_SB_GZ;
            //设备维护
            cpage_sbwh = pg_sbwh.CurrentPage;
            pg_sbwh.NumPerPage = _usState.C_SB_WH;
            psize_sbwh = _usState.C_SB_WH;
            #endregion
            if (!IsPostBack)
            {
                tbx_jfdqrq.Attributes.Add("readonly", "readonly");
                tbx_kssj_bjck.Attributes.Add("readonly", "readonly");
                tbx_jssj_bjck.Attributes.Add("readonly", "readonly");
                tbx_kssj_bjrk.Attributes.Add("readonly", "readonly");
                tbx_jssj_bjrk.Attributes.Add("readonly", "readonly");

                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");

                ddltBind_cxmk();
            }
        }

        private void ddltBind_cxmk()
        {
            ddlt_cxmk.Items.Insert(0, new ListItem("请选择", "-1"));
            ddlt_cxmk.Items.Insert(1, new ListItem("导航设备", "1401"));
            ddlt_cxmk.Items.Insert(2, new ListItem("通信设备", "1402"));
            ddlt_cxmk.Items.Insert(3, new ListItem("气象设备", "1403"));
            ddlt_cxmk.Items.Insert(4, new ListItem("监视设备", "1410"));
            ddlt_cxmk.Items.Insert(5, new ListItem("台站管理", "1404"));
            ddlt_cxmk.Items.Insert(6, new ListItem("备件管理", "1405"));
            ddlt_cxmk.Items.Insert(7, new ListItem("备件出库", "1406"));
            ddlt_cxmk.Items.Insert(8, new ListItem("备件入库", "1407"));
            ddlt_cxmk.Items.Insert(9, new ListItem("设备故障", "1408"));
            ddlt_cxmk.Items.Insert(10, new ListItem("设备维护", "1409"));
            

        }

        protected void ddlt_cxmk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlt_cxmk.SelectedValue == "-1")
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
            }
            if (ddlt_cxmk.SelectedValue == "1401")//导航
            {
                div_dhsb.Attributes.Add("style", "display:true");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_dhsb();
                Select_dhsb();
            }
            if (ddlt_cxmk.SelectedValue == "1402")//通信
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:true");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_txsb();
                Select_txsb();
            }
            if (ddlt_cxmk.SelectedValue == "1403")//气象
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:true");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_qxsb();
                Select_qxsb();
            }
            if (ddlt_cxmk.SelectedValue == "1410")//监视
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:true");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_jssb();
                Select_jssb();
            }
            if (ddlt_cxmk.SelectedValue == "1404")//台站
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:true");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_tzgl();
                Select_tzgl();
            }
            if (ddlt_cxmk.SelectedValue == "1405")//备件管理
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:true");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_bjgl();
                Select_bjgl();
            }
            if (ddlt_cxmk.SelectedValue == "1406")//备件出库
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:true");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_bjck();
                Select_bjck();
            }
            if (ddlt_cxmk.SelectedValue == "1407")//备件入库
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:true");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_bjrk();
                Select_bjrk();
            }
            if (ddlt_cxmk.SelectedValue == "1408")//设备故障
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:true");
                div_sbwh.Attributes.Add("style", "display:none");
                ddltBind_sbgz();
                Select_sbgz();
            }
            if (ddlt_cxmk.SelectedValue == "1409")//设备维护
            {
                div_dhsb.Attributes.Add("style", "display:none");
                div_txsb.Attributes.Add("style", "display:none");
                div_qxsb.Attributes.Add("style", "display:none");
                div_jssb.Attributes.Add("style", "display:none");
                div_tzgl.Attributes.Add("style", "display:none");
                div_bjgl.Attributes.Add("style", "display:none");
                div_bjck.Attributes.Add("style", "display:none");
                div_bjrk.Attributes.Add("style", "display:none");
                div_sbgz.Attributes.Add("style", "display:none");
                div_sbwh.Attributes.Add("style", "display:true");
                ddltBind_sbwh();
                Select_sbwh();
            }
        }


        #region  导航设备
        private void ddltBind_dhsb()
        {
            //设备类型
            ddlt_sblx_dhsb.DataTextField = "mc";
            ddlt_sblx_dhsb.DataValueField = "bm";
            ddlt_sblx_dhsb.DataSource = SysData.SBLX("02").Copy();
            ddlt_sblx_dhsb.DataBind();
            ddlt_sblx_dhsb.Items.Insert(0, new ListItem("全部", "-1"));

            //所属机场
            ddlt_yssjc.DataTextField = "mc";
            ddlt_yssjc.DataValueField = "bm";
            ddlt_yssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_yssjc.DataBind();
            ddlt_yssjc.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 台站名称
            ddlt_tzmczl_tzmc.DataTextField = "mc";
            ddlt_tzmczl_tzmc.DataValueField = "bm";
            ddlt_tzmczl_tzmc.DataSource = SysData.TZLX().Copy();
            ddlt_tzmczl_tzmc.DataBind();
            ddlt_tzmczl_tzmc.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 绑定设备位置
            ddlt_tzmczl_wz.DataSource = SysData.SBWZ().Copy();
            ddlt_tzmczl_wz.DataTextField = "mc";
            ddlt_tzmczl_wz.DataValueField = "bm";
            ddlt_tzmczl_wz.DataBind();
            ddlt_tzmczl_wz.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 设备类型
            ddlt_tzmczl_sblx.DataTextField = "mc";
            ddlt_tzmczl_sblx.DataValueField = "bm";
            ddlt_tzmczl_sblx.DataSource = SysData.SBLX("02").Copy();
            ddlt_tzmczl_sblx.DataBind();
            ddlt_tzmczl_sblx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Select_dhsb()
        {
            int jfdqrqbs = 0;
            string sj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            if (tbx_jfdqrq.Text == "")
            {
                jfdqrqbs = 1;
                lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "" + "</span>";
            }
            if (jfdqrqbs == 0 && !Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
            {
                lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
            }
            struct_dhsb.p_sbxh = tbx_sbxh_dhsb.Text.ToString();
            struct_dhsb.p_sblx = ddlt_sblx_dhsb.SelectedValue.ToString();
            struct_dhsb.p_tzmczl_tzmc = ddlt_tzmczl_tzmc.SelectedValue.ToString();
            struct_dhsb.p_tzmczl_wz = ddlt_tzmczl_wz.SelectedValue.ToString();
            struct_dhsb.p_tzmczl_sblx = ddlt_tzmczl_sblx.SelectedValue.ToString();
            struct_dhsb.p_jfdqrq = tbx_jfdqrq.Text.ToString();
            struct_dhsb.p_yssjc = ddlt_yssjc.SelectedValue.ToString();
            struct_dhsb.p_userid = _usState.userID;
            int count = dhsb.Select_DHSB_Count(struct_dhsb);
            pg_dhsb.TotalRecord = count;
            struct_dhsb.p_currentpage = pg_dhsb.CurrentPage;
            struct_dhsb.p_pagesize = pg_dhsb.NumPerPage;
            DataTable dt = dhsb.Select_DHSB(struct_dhsb).Tables[0];
            dt.Columns.Add("yssjc_mc");
            dt.Columns.Add("sstz_mc");
            dt.Columns.Add("plmc");
            dt.Columns.Add("jfdqrqz");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sblxmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["yssjc_mc"] = SysData.ZXDMByKey(dr["yssjc"].ToString()).mc;
                dr["sstz_mc"] = Convert.ToString(SysData.TZLXByKey(dr["TZMCZL_TZMC"].ToString()).mc + "." + SysData.SBWZByKey(dr["TZMCZL_WZ"].ToString()).mc + "." + SysData.SBZLByKey(dr["TZMCZL_SBLX"].ToString()).mc);
                dr["plmc"] = Convert.ToString(dr["pl"].ToString() + SysData.PLDWByKey(dr["pldw"].ToString()).mc);
                dr["jfdqrqz"] = DateTime.Parse(dr["jfdqrq"].ToString()).ToString("yyyy-MM-dd");
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
            }
            //绑定分页数据源  
            this.Repeater_dhsb.DataSource = dt.DefaultView;
            this.Repeater_dhsb.DataBind();
        }

        #endregion

        #region 通信设备
        private void ddltBind_txsb()
        {
            //绑定设备类型 ddlt_sblx           
            ddlt_sblx_txsb.DataTextField = "mc";
            ddlt_sblx_txsb.DataValueField = "bm";
            ddlt_sblx_txsb.DataSource = SysData.SBLX("01").Copy();
            ddlt_sblx_txsb.DataBind();
            ddlt_sblx_txsb.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt_txsb.DataTextField = "mc";
            ddlt_zt_txsb.DataValueField = "bm";
            ddlt_zt_txsb.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_txsb.DataBind();
            ddlt_zt_txsb.Items.Insert(0, new ListItem("全部", "-1"));
            //位置
            ddlt_wz_txsb.DataTextField = "mc";
            ddlt_wz_txsb.DataValueField = "bm";
            ddlt_wz_txsb.DataSource = SysData.ZXDM().Copy();
            ddlt_wz_txsb.DataBind();
            ddlt_wz_txsb.Items.Insert(0, new ListItem("全部", "-1"));

            //绑定所属机场 ddlt_ssjc(支线)
            ddlt_ssjc_txsb.DataTextField = "mc";
            ddlt_ssjc_txsb.DataValueField = "bm";
            ddlt_ssjc_txsb.DataSource = SysData.ZXDM().Copy();
            ddlt_ssjc_txsb.DataBind();
            ddlt_ssjc_txsb.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Select_txsb()
        {
            struct_txsb.p_sblx = ddlt_sblx_txsb.SelectedValue.ToString();
            struct_txsb.p_ssjc = ddlt_ssjc_txsb.SelectedValue.ToString();
            struct_txsb.p_wz = ddlt_wz_txsb.SelectedValue.ToString();
            //struct_txsb.p_tzmc = ddlt_wz.SelectedValue.ToString()+ddlt_sblx.SelectedValue.ToString();
            struct_txsb.p_zt = ddlt_zt_txsb.SelectedValue.ToString();
            struct_txsb.p_userid = _usState.userID;

            int count = txsb.Select_TXSB_Count(struct_txsb);
            pg_txsb.TotalRecord = count;
            struct_txsb.p_currentpage = pg_txsb.CurrentPage;
            struct_txsb.p_pagesize = pg_txsb.NumPerPage;
            DataTable dt = txsb.Select_TXSB_Pro(struct_txsb).Tables[0];
            dt.Columns.Add("ssjcmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("tzmcmc");
            dt.Columns.Add("wzmc");
            dt.Columns.Add("sbztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ssjcmc"] = SysData.ZXDMByKey(dr["ssjc"].ToString()).mc;//所属机场
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;//设备类型
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["wzmc"] = SysData.ZXDMByKey(dr["wz"].ToString()).mc;
                dr["sbztmc"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["tzmcmc"] = SysData.ZXDMByKey(dr["wz"].ToString()).mc + SysData.SBLXByKey(dr["sblx"].ToString()).mc;//台站名称
            }
            //绑定分页数据源  
            this.Repeater_txsb.DataSource = dt.DefaultView;
            this.Repeater_txsb.DataBind();
        }

        #endregion

        #region 气象设备
        private void ddltBind_qxsb()
        {
            //运行情况
            ddlt_yxqk.DataTextField = "mc";
            ddlt_yxqk.DataValueField = "bm";
            ddlt_yxqk.DataSource = SysData.YXQK().Copy();
            ddlt_yxqk.DataBind();
            ddlt_yxqk.Items.Insert(0, new ListItem("全部", "-1"));

            //设备状态 
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("全部", "-1"));

            //设备用途
            ddlt_sbyt.DataTextField = "mc";
            ddlt_sbyt.DataValueField = "bm";
            ddlt_sbyt.DataSource = SysData.SBYT().Copy();
            ddlt_sbyt.DataBind();
            ddlt_sbyt.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定所属支线 
            ddlt_sszx.DataTextField = "mc";
            ddlt_sszx.DataValueField = "bm";
            ddlt_sszx.DataSource = SysData.ZXDM().Copy();
            ddlt_sszx.DataBind();
            ddlt_sszx.Items.Insert(0, new ListItem("全部", "-1"));
            //检定方式 
            ddlt_jdfs.DataTextField = "mc";
            ddlt_jdfs.DataValueField = "bm";
            ddlt_jdfs.DataSource = SysData.JDFS().Copy();
            ddlt_jdfs.DataBind();
            ddlt_jdfs.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt_qxsb.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_qxsb.DataTextField = "mc";
            ddlt_zt_qxsb.DataValueField = "bm";
            ddlt_zt_qxsb.DataBind();
            ddlt_zt_qxsb.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Select_qxsb()
        {
            struct_qxsb.p_ccbh = tbx_ccbh.Text.Trim().ToString();
            // struct_qxsb.p_tcrq = tbx_tcrq.Text.Trim().ToString();
            // struct_qxsb.p_jgrq = tbx_jgrq.Text.Trim().ToString();
            struct_qxsb.p_yxqk = ddlt_yxqk.SelectedValue.ToString();
            struct_qxsb.p_sbzt = ddlt_sbzt.SelectedValue.ToString();
            struct_qxsb.p_sbyt = ddlt_sbyt.SelectedValue.ToString();
            struct_qxsb.p_sszx = ddlt_sszx.SelectedValue.ToString();
            struct_qxsb.p_jdfs = ddlt_jdfs.SelectedValue.ToString();
            struct_qxsb.p_zt = ddlt_zt_qxsb.SelectedValue.ToString();
            struct_qxsb.p_userid = _usState.userID;
            int count = qxsb.Select_QXSB_Count(struct_qxsb);
            pg_qxsb.TotalRecord = count;
            struct_qxsb.p_currentpage = pg_qxsb.CurrentPage;
            struct_qxsb.p_pagesize = pg_qxsb.NumPerPage;
            DataTable dt = qxsb.Select_QXSB(struct_qxsb).Tables[0];
            dt.Columns.Add("yxqkmc");
            dt.Columns.Add("sbztmc");
            dt.Columns.Add("sbytmc");
            dt.Columns.Add("sszxmc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["yxqkmc"] = SysData.SBYTByKey(dr["yxqk"].ToString()).mc;
                dr["sbztmc"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["sbytmc"] = SysData.SBYTByKey(dr["sbyt"].ToString()).mc;
                dr["sszxmc"] = SysData.SBZLByKey(dr["sszx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
            }

            //绑定分页数据源  
            this.Repeater_qxsb.DataSource = dt.DefaultView;
            this.Repeater_qxsb.DataBind();
        }
        #endregion

        #region 监视设备

        public void ddltBind_jssb()
        {
            //绑定设备类型 ddlt_sblx           
            ddlt_sblx_jssb.DataTextField = "mc";
            ddlt_sblx_jssb.DataValueField = "bm";
            ddlt_sblx_jssb.DataSource = SysData.SBLX("03").Copy();
            ddlt_sblx_jssb.DataBind();
            ddlt_sblx_jssb.Items.Insert(0, new ListItem("全部", "-1"));
            //位置
            ddlt_wz_jssb.DataTextField = "mc";
            ddlt_wz_jssb.DataValueField = "bm";
            ddlt_wz_jssb.DataSource = SysData.ZXDM().Copy();
            ddlt_wz_jssb.DataBind();
            ddlt_wz_jssb.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定所属机场 ddlt_ssjc(支线)
            ddlt_ssjc_jssb.DataTextField = "mc";
            ddlt_ssjc_jssb.DataValueField = "bm";
            ddlt_ssjc_jssb.DataSource = SysData.ZXDM().Copy();
            ddlt_ssjc_jssb.DataBind();
            ddlt_ssjc_jssb.Items.Insert(0, new ListItem("全部", "-1"));
            //设备状态
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Select_jssb()
        {
            struct_jssb.p_ssjc = ddlt_ssjc_jssb.SelectedValue.ToString();
            struct_jssb.p_wz = ddlt_wz_jssb.SelectedValue.ToString();
            struct_jssb.p_sblx = ddlt_sblx_jssb.SelectedValue.ToString();
            struct_jssb.p_sbzt = ddlt_sbzt.SelectedValue.ToString();
            struct_jssb.p_userid = _usState.userID;

            DataTable dt = new DataTable();
            int count = jssb.Select_JSSB_Count(struct_jssb);
            pg_jssb.TotalRecord = count;
            struct_jssb.p_currentpage = pg_jssb.CurrentPage;
            struct_jssb.p_pagesize = pg_jssb.NumPerPage;
            dt = jssb.Select_JSSB_Pro(struct_jssb);


            dt.Columns.Add("ssjcmc");
            dt.Columns.Add("wzmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("sbztmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("tzmczlmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ssjcmc"] = SysData.ZXDMByKey(dr["ssjc"].ToString()).mc;//所属机场
                dr["wzmc"] = SysData.ZXDMByKey(dr["wz"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;//设备类型
                dr["sbztmc"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["tzmczlmc"] = SysData.ZXDMByKey(dr["wz"].ToString()).mc + SysData.SBLXByKey(dr["sblx"].ToString()).mc;//台站名称


            }
            this.Repeater_jssb.DataSource = dt.DefaultView;
            this.Repeater_jssb.DataBind();
        }
        #endregion

        #region 台站管理
        private void ddltBind_tzgl()
        {
            //所属机场
            ddlt_jc_tzgl.DataTextField = "mc";
            ddlt_jc_tzgl.DataValueField = "bm";
            ddlt_jc_tzgl.DataSource = SysData.ZXDM().Copy();
            ddlt_jc_tzgl.DataBind();
            ddlt_jc_tzgl.Items.Insert(0, new ListItem("全部", "-1"));

            // 设备位置
            ddlt_wz_tzgl.DataSource = SysData.SBWZ().Copy();
            ddlt_wz_tzgl.DataTextField = "mc";
            ddlt_wz_tzgl.DataValueField = "bm";
            ddlt_wz_tzgl.DataBind();
            ddlt_wz_tzgl.Items.Insert(0, new ListItem("全部", "-1"));

            //设备类型
            ddlt_sblx_tzgl.DataTextField = "mc";
            ddlt_sblx_tzgl.DataValueField = "bm";
            ddlt_sblx_tzgl.DataSource = SysData.SBLX("02").Copy();
            ddlt_sblx_tzgl.DataBind();
            ddlt_sblx_tzgl.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt_tzgl.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_tzgl.DataTextField = "mc";
            ddlt_zt_tzgl.DataValueField = "bm";
            ddlt_zt_tzgl.DataBind();
            ddlt_zt_tzgl.Items.Insert(0, new ListItem("全部", "-1"));

        }
        private void Select_tzgl()
        {
            struct_tzsb.p_jc = ddlt_jc_tzgl.SelectedValue.ToString();
            struct_tzsb.p_wz = ddlt_wz_tzgl.SelectedValue.ToString();
            struct_tzsb.p_sblx = ddlt_sblx_tzgl.SelectedValue.ToString();
            struct_tzsb.p_zt = ddlt_zt_tzgl.SelectedValue.ToString();
            struct_tzsb.p_fwxx = tbx_fwxx_tzgl.Text.ToString();
            struct_tzsb.p_userid = _usState.userID;
            int count = tzsb.Select_TZ_Count(struct_tzsb);
            pg_tzgl.TotalRecord = count;
            struct_tzsb.p_currentpage = pg_tzgl.CurrentPage;
            struct_tzsb.p_pagesize = pg_tzgl.NumPerPage;
            DataTable dt = tzsb.Select_TZ_Pro(struct_tzsb).Tables[0];
            dt.Columns.Add("jcmc");
            //  dt.Columns.Add("wzmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("bm");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("tzwdsfdbmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["jcmc"] = SysData.ZXDMByKey(dr["jc"].ToString()).mc;
                // dr["wzmc"] = SysData.BMByKey(dr["wz].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;

                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["tzwdsfdbmc"] = SysData.SFJBByKey(dr["tzwdsfdb"].ToString()).mc;
            }


            ///绑定分页数据源  
            this.Repeater_tzgl.DataSource = dt.DefaultView;
            this.Repeater_tzgl.DataBind();
        }

        #endregion

        #region 备件管理
        private void ddltBind_bjgl()
        {
            //绑定备件分类 ddlt_bjfl
            ddlt_bjfl_bjgl.DataTextField = "mc";
            ddlt_bjfl_bjgl.DataValueField = "bm";
            ddlt_bjfl_bjgl.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl_bjgl.DataBind();
            ddlt_bjfl_bjgl.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定适用 ddlt_sy
            ddlt_sy_bjgl.DataTextField = "mc";
            ddlt_sy_bjgl.DataValueField = "bm";
            ddlt_sy_bjgl.DataSource = SysData.BJSY().Copy();
            ddlt_sy_bjgl.DataBind();
            ddlt_sy_bjgl.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt_bjgl.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_bjgl.DataTextField = "mc";
            ddlt_zt_bjgl.DataValueField = "bm";
            ddlt_zt_bjgl.DataBind();
            ddlt_zt_bjgl.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Select_bjgl()
        {
            string sbbh = tbx_sbbh_bjgl.Text.Trim().ToString().Trim();
            string bjmc = tbx_sbmc_bjgl.Text.ToString().Trim();
            string sbxh = tbx_sbxh_bjgl.Text.Trim().ToString().Trim();
            string bjfl = ddlt_bjfl_bjgl.SelectedValue.ToString();
            string sy = ddlt_sy_bjgl.SelectedValue.ToString();


            struct_bj.p_bjbh = sbbh;
            struct_bj.p_bjmc = bjmc;
            struct_bj.p_bjfl = bjfl;
            struct_bj.p_sy = sy;
            struct_bj.p_sbxh = sbxh;
            struct_bj.p_zt = ddlt_zt_bjgl.SelectedValue.Trim().ToString();//状态
            struct_bj.p_zxdm = _usState.userSS;
            struct_bj.p_userid = _usState.userID;

            int count = bj.Select_BJ_Count(struct_bj);
            pg_bjgl.TotalRecord = count;
            struct_bj.p_currentpage = pg_bjgl.CurrentPage;
            struct_bj.p_pagesize = pg_bjgl.NumPerPage;
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
            this.Repeater_bjgl.DataSource = dt.DefaultView;
            this.Repeater_bjgl.DataBind();
        }

        #endregion

        #region 备件出库

        private void ddltBind_bjck()
        {
            //备件分类
            ddlt_bjfl_bjck.DataTextField = "mc";
            ddlt_bjfl_bjck.DataValueField = "bm";
            ddlt_bjfl_bjck.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl_bjck.DataBind();
            ddlt_bjfl_bjck.Items.Insert(0, new ListItem("全部", "-1"));

            //备件适用
            ddlt_bjsy_bjck.DataTextField = "mc";
            ddlt_bjsy_bjck.DataValueField = "bm";
            ddlt_bjsy_bjck.DataSource = SysData.BJSY().Copy();
            ddlt_bjsy_bjck.DataBind();
            ddlt_bjsy_bjck.Items.Insert(0, new ListItem("全部", "-1"));

            //经办人部门
            ddlt_jbrbm_bjck.DataTextField = "mc";
            ddlt_jbrbm_bjck.DataValueField = "bm";
            ddlt_jbrbm_bjck.DataSource = SysData.BM().Copy();
            ddlt_jbrbm_bjck.DataBind();
            ddlt_jbrbm_bjck.Items.Insert(0, new ListItem("全部", "-1"));

            //岗位代码
            DataTable dt_gw = new DataTable();
            ddlt_jbrgw_bjck.DataSource = dt_gw;
            //ddlt_jbrgw.DataTextField = "mc";
            //ddlt_jbrgw.DataValueField = "bm";
            //ddlt_jbrgw.DataSource = SysData.GW().Copy();
            ddlt_jbrgw_bjck.DataBind();
            ddlt_jbrgw_bjck.Items.Insert(0, new ListItem("全部", "-1"));

            //负责人部门
            ddlt_fzrbm_bjck.DataTextField = "mc";
            ddlt_fzrbm_bjck.DataValueField = "bm";
            ddlt_fzrbm_bjck.DataSource = SysData.BM().Copy();
            ddlt_fzrbm_bjck.DataBind();
            ddlt_fzrbm_bjck.Items.Insert(0, new ListItem("全部", "-1"));

            DataTable dt_fzrgw = new DataTable();
            ddlt_fzrgw_bjck.DataSource = dt_fzrgw;
            //ddlt_fzrgw.DataTextField = "mc";
            //ddlt_fzrgw.DataValueField = "bm";
            //ddlt_fzrgw.DataSource = SysData.GW().Copy();
            ddlt_fzrgw_bjck.DataBind();
            ddlt_fzrgw_bjck.Items.Insert(0, new ListItem("全部", "-1"));


            //备件名称
            DataTable dt = new DataTable();
            dt = bj.Select_BJXX().Tables[0];
            ddlt_bjmc_bjck.DataTextField = "bjmc";
            ddlt_bjmc_bjck.DataValueField = "sjc";
            ddlt_bjmc_bjck.DataSource = dt;
            ddlt_bjmc_bjck.DataBind();
            ddlt_bjmc_bjck.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt_bjck.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_bjck.DataTextField = "mc";
            ddlt_zt_bjck.DataValueField = "bm";
            ddlt_zt_bjck.DataBind();
            ddlt_zt_bjck.Items.Insert(0, new ListItem("全部", "-1"));

        }
        private void Select_bjck()
        {
            struct_bjck.p_bjbh = ddlt_bjmc_bjck.SelectedValue.ToString();
            struct_bjck.p_bjfl = ddlt_bjfl_bjck.SelectedValue.ToString();
            struct_bjck.p_sy = ddlt_bjsy_bjck.SelectedValue.ToString();
            struct_bjck.p_jbrxm = tbx_jbr_bjck.Text.ToString();
            struct_bjck.p_jbrbm = ddlt_jbrbm_bjck.SelectedValue.ToString();
            struct_bjck.p_jbrgw = ddlt_jbrgw_bjck.SelectedValue.ToString();
            struct_bjck.p_fzrxm = tbx_fzr_bjck.Text.ToString();
            struct_bjck.p_fzrbm = ddlt_fzrbm_bjck.SelectedValue.ToString();
            struct_bjck.p_fzrgw = ddlt_fzrgw_bjck.SelectedValue.ToString();
            struct_bjck.p_zxdm = _usState.userSS;
            struct_bjck.p_zt = ddlt_zt_bjck.SelectedValue.Trim().ToString();
            struct_bjck.p_userid = _usState.userID;
            if (tbx_kssj_bjck.Text.ToString() == "")
            {
                DateTime dt_kssj = new DateTime();
                struct_bjck.p_kssj = dt_kssj;
            }
            else
            {
                struct_bjck.p_kssj = Convert.ToDateTime(tbx_kssj_bjck.Text.ToString());
            }
            if (tbx_jssj_bjck.Text.ToString() == "")
            {

                struct_bjck.p_jssj = DateTime.Now;
            }
            else
            {
                struct_bjck.p_jssj = Convert.ToDateTime(tbx_jssj_bjck.Text.ToString());
            }

            int count = bj.Select_BJCK_Count(struct_bjck);
            pg_bjck.TotalRecord = count;
            struct_bjck.p_currentpage = pg_bjck.CurrentPage;
            struct_bjck.p_pagesize = pg_bjck.NumPerPage;
            DataTable dt = bj.Select_BJCK_Pro(struct_bjck).Tables[0];

            dt.Columns.Add("bjfl_mc");
            dt.Columns.Add("bjsy_mc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("bmmc");
            dt.Columns.Add("cksjz");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjfl_mc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bjsy_mc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["cksjz"] = DateTime.Parse(dr["cksj"].ToString()).ToString("yyyy-MM-dd");
            }

            ////绑定分页数据源  
            this.Repeater_bjck.DataSource = dt.DefaultView;
            this.Repeater_bjck.DataBind();
        }

        #endregion

        #region 备件入库

        private void ddltBind_bjrk()
        {
            //备件分类
            ddlt_bjfl_bjrk.DataTextField = "mc";
            ddlt_bjfl_bjrk.DataValueField = "bm";
            ddlt_bjfl_bjrk.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl_bjrk.DataBind();
            ddlt_bjfl_bjrk.Items.Insert(0, new ListItem("全部", "-1"));

            //备件适用
            ddlt_bjsy_bjrk.DataTextField = "mc";
            ddlt_bjsy_bjrk.DataValueField = "bm";
            ddlt_bjsy_bjrk.DataSource = SysData.BJSY().Copy();
            ddlt_bjsy_bjrk.DataBind();
            ddlt_bjsy_bjrk.Items.Insert(0, new ListItem("全部", "-1"));

            //经办人部门
            ddlt_jbrbm_bjrk.DataTextField = "mc";
            ddlt_jbrbm_bjrk.DataValueField = "bm";
            ddlt_jbrbm_bjrk.DataSource = SysData.BM().Copy();
            ddlt_jbrbm_bjrk.DataBind();
            ddlt_jbrbm_bjrk.Items.Insert(0, new ListItem("全部", "-1"));

            //经办人岗位
            DataTable dt_gw = new DataTable();
            ddlt_jbrgw_bjrk.DataSource = dt_gw;
            ddlt_jbrgw_bjrk.DataBind();
            ddlt_jbrgw_bjrk.Items.Insert(0, new ListItem("全部", "-1"));


            //负责人部门
            ddlt_fzrbm_bjrk.DataTextField = "mc";
            ddlt_fzrbm_bjrk.DataValueField = "bm";
            ddlt_fzrbm_bjrk.DataSource = SysData.BM().Copy();
            ddlt_fzrbm_bjrk.DataBind();
            ddlt_fzrbm_bjrk.Items.Insert(0, new ListItem("全部", "-1"));

            //负责人岗位
            DataTable dt_fzrgw = new DataTable();
            ddlt_fzrgw_bjrk.DataSource = dt_fzrgw;
            ddlt_fzrgw_bjrk.DataBind();
            ddlt_fzrgw_bjrk.Items.Insert(0, new ListItem("全部", "-1"));


            //备件名称
            DataTable dt = new DataTable();
            dt = bj.Select_BJXX().Tables[0];
            ddlt_bjmc_bjrk.DataTextField = "bjmc";
            ddlt_bjmc_bjrk.DataValueField = "sjc";
            ddlt_bjmc_bjrk.DataSource = dt;
            ddlt_bjmc_bjrk.DataBind();
            ddlt_bjmc_bjrk.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt_bjrk.DataSource = SysData.ZTDM().Copy();
            ddlt_zt_bjrk.DataTextField = "mc";
            ddlt_zt_bjrk.DataValueField = "bm";
            ddlt_zt_bjrk.DataBind();
            ddlt_zt_bjrk.Items.Insert(0, new ListItem("全部", "-1"));

        }
        private void Select_bjrk()
        {
            struct_bjrk.p_bjbh = ddlt_bjmc_bjrk.SelectedValue.ToString();
            struct_bjrk.p_bjfl = ddlt_bjfl_bjrk.SelectedValue.ToString();
            struct_bjrk.p_sy = ddlt_bjsy_bjrk.SelectedValue.ToString();
            struct_bjrk.p_jbrxm = tbx_jbr_bjrk.Text.ToString();
            struct_bjrk.p_jbrbm = ddlt_jbrbm_bjrk.SelectedValue.ToString();
            struct_bjrk.p_jbrgw = ddlt_jbrgw_bjrk.SelectedValue.ToString();
            struct_bjrk.p_fzrxm = tbx_fzr_bjrk.Text.ToString();
            struct_bjrk.p_fzrbm = ddlt_fzrbm_bjrk.SelectedValue.ToString();
            struct_bjrk.p_fzrgw = ddlt_fzrgw_bjrk.SelectedValue.ToString();
            struct_bjrk.p_zxdm = _usState.userSS;
            struct_bjrk.p_userid = _usState.userID;
            struct_bjrk.p_zt = ddlt_zt_bjrk.SelectedValue.ToString();
            if (tbx_kssj_bjrk.Text.ToString() == "")
            {
                DateTime dt_kssj = new DateTime();
                struct_bjrk.p_kssj = dt_kssj;
            }
            else
            {
                struct_bjrk.p_kssj = Convert.ToDateTime(tbx_kssj_bjrk.Text.ToString());
            }
            if (tbx_jssj_bjrk.Text.ToString() == "")
            {

                struct_bjrk.p_jssj = DateTime.Now;
            }
            else
            {
                struct_bjrk.p_jssj = Convert.ToDateTime(tbx_jssj_bjrk.Text.ToString());
            }
            int count = bj.Select_BJRK_Count(struct_bjrk);
            pg_bjrk.TotalRecord = count;
            struct_bjrk.p_currentpage = pg_bjrk.CurrentPage;
            struct_bjrk.p_pagesize = pg_bjrk.NumPerPage;
            DataTable dt = bj.Select_BJRK_Pro(struct_bjrk).Tables[0];

            dt.Columns.Add("bjfl_mc");
            dt.Columns.Add("bjsy_mc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("rksjz");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjfl_mc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bjsy_mc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;
                dr["rksjz"] = DateTime.Parse(dr["rksj"].ToString()).ToString("yyyy-MM-dd");
            }

            ////绑定分页数据源  
            this.Repeater_bjrk.DataSource = dt.DefaultView;
            this.Repeater_bjrk.DataBind();
        }
        #endregion

        #region 设备故障
        private void ddltBind_sbgz()
        {
            //设备种类
            ddlt_sbzl_sbgz.DataTextField = "mc";
            ddlt_sbzl_sbgz.DataValueField = "bm";
            ddlt_sbzl_sbgz.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl_sbgz.DataBind();
            ddlt_sbzl_sbgz.Items.Insert(0, new ListItem("请选择", "-1"));

            //维修人部门
            ddlt_wxrbm_sbgz.DataTextField = "mc";
            ddlt_wxrbm_sbgz.DataValueField = "bm";
            ddlt_wxrbm_sbgz.DataSource = SysData.BM().Copy();
            ddlt_wxrbm_sbgz.DataBind();
            ddlt_wxrbm_sbgz.Items.Insert(0, new ListItem("全部", "-1"));
            //维修人岗位

            DataTable dt_whrgw = new DataTable();
            ddlt_wxrgw_sbgz.DataSource = dt_whrgw;
            ddlt_wxrgw_sbgz.DataBind();
            ddlt_wxrgw_sbgz.Items.Insert(0, new ListItem("全部", "-1"));

            //设备类型
            ddlt_sblx_sbgz.DataTextField = "mc";
            ddlt_sblx_sbgz.DataValueField = "bm";
            ddlt_sblx_sbgz.DataSource = SysData.SBLX().Copy();
            ddlt_sblx_sbgz.DataBind();
            ddlt_sblx_sbgz.Items.Insert(0, new ListItem("全部", "-1"));
        }

        private void Select_sbgz()
        {
            struct_sbgz.p_sbbh = tbx_sbbh_sbgz.Text.ToString();
            struct_sbgz.p_sblx = ddlt_sblx_sbgz.SelectedValue.ToString();
            struct_sbgz.p_sbzl = ddlt_sbzl_sbgz.SelectedValue.ToString();
            struct_sbgz.p_wxr = tbx_wxr_sbgz.Text.ToString();
            struct_sbgz.p_wxrbm = ddlt_wxrbm_sbgz.SelectedValue.ToString();
            struct_sbgz.p_wxrgw = ddlt_wxrgw_sbgz.SelectedValue.ToString();
            struct_sbgz.p_sblx = ddlt_sblx_sbgz.SelectedValue.ToString();
            struct_sbgz.p_userid = _usState.userID;

            int count = wh.Select_SBGZ_Count(struct_sbgz);
            pg_sbgz.TotalRecord = count;
            struct_sbgz.p_currentpage = pg_sbgz.CurrentPage;
            struct_sbgz.p_pagesize = pg_sbgz.NumPerPage;
            DataTable dt = wh.Select_SBGZ_Pro(struct_sbgz).Tables[0];

            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("wxrbmmc");
            dt.Columns.Add("wxrgwmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("bm");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
                dr["wxrbmmc"] = SysData.BMByKey(dr["WXRBM"].ToString()).mc;
                dr["wxrgwmc"] = SysData.GWByKey(dr["WXRGW"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
            }

            //绑定分页数据源  
            this.Repeater_sbgz.DataSource = dt.DefaultView;
            this.Repeater_sbgz.DataBind();
        }

        #endregion

        #region 设备维护

        private void ddltBind_sbwh()
        {
            struct_sbwh.p_sbbh = tbx_sbbh_sbwh.Text.ToString();
            struct_sbwh.p_sbzl = ddlt_sbzl_sbwh.SelectedValue.ToString();
            struct_sbwh.p_whr = tbx_whr_sbwh.Text.ToString();
            struct_sbwh.p_whrbm = ddlt_whrbm_sbwh.SelectedValue.ToString();
            struct_sbwh.p_whrgw = ddlt_whrgw_sbwh.SelectedValue.ToString();
            struct_sbwh.p_whzt = ddlt_whzt_sbwh.SelectedValue.ToString();
            struct_sbwh.p_sblx = ddlt_sblx_sbwh.SelectedValue.ToString();
            struct_sbwh.p_userid = _usState.userID;

            int count = wh.Select_SBWH_Count(struct_sbwh);
            pg_sbwh.TotalRecord = count;
            struct_sbwh.p_currentpage = pg_sbwh.CurrentPage;
            struct_sbwh.p_pagesize = pg_sbwh.NumPerPage;
            DataTable dt = wh.Select_SBWH_Pro(struct_sbwh).Tables[0];

            dt.Columns.Add("sbzlmc");
            dt.Columns.Add("sblxmc");
            dt.Columns.Add("whztmc");
            dt.Columns.Add("whrbmmc");
            dt.Columns.Add("whrgwmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("bm");
            dt.Columns.Add("whsjmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sbzlmc"] = SysData.SBZLByKey(dr["sbzl"].ToString()).mc;
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblxdm"].ToString()).mc;
                dr["whztmc"] = SysData.WHZTByKey(dr["whzt"].ToString()).mc;
                dr["whrbmmc"] = SysData.BMByKey(dr["whrbm"].ToString()).mc;
                dr["whrgwmc"] = SysData.GWByKey(dr["whrgw"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["whsjmc"] = DateTime.Parse(dr["whsj"].ToString()).ToString("yyyy-MM-dd");

            }

            //绑定分页数据源  
            this.Repeater_sbwh.DataSource = dt.DefaultView;
            this.Repeater_sbwh.DataBind();
        }
        private void Select_sbwh()
        {
            //设备种类
            ddlt_sbzl_sbwh.DataTextField = "mc";
            ddlt_sbzl_sbwh.DataValueField = "bm";
            ddlt_sbzl_sbwh.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl_sbwh.DataBind();
            ddlt_sbzl_sbwh.Items.Insert(0, new ListItem("请选择", "-1"));

            //维护人部门
            ddlt_whrbm_sbwh.DataTextField = "mc";
            ddlt_whrbm_sbwh.DataValueField = "bm";
            ddlt_whrbm_sbwh.DataSource = SysData.BM().Copy();
            ddlt_whrbm_sbwh.DataBind();
            ddlt_whrbm_sbwh.Items.Insert(0, new ListItem("全部", "-1"));
            //维护人岗位

            DataTable dt_whrgw = new DataTable();
            ddlt_whrgw_sbwh.DataSource = dt_whrgw;
            ddlt_whrgw_sbwh.DataBind();
            ddlt_whrgw_sbwh.Items.Insert(0, new ListItem("全部", "-1"));

            //设备类型
            ddlt_sblx_sbwh.DataTextField = "mc";
            ddlt_sblx_sbwh.DataValueField = "bm";
            ddlt_sblx_sbwh.DataSource = SysData.SBLX().Copy();
            ddlt_sblx_sbwh.DataBind();
            ddlt_sblx_sbwh.Items.Insert(0, new ListItem("全部", "-1"));

            //维护状态
            ddlt_whzt_sbwh.DataTextField = "mc";
            ddlt_whzt_sbwh.DataValueField = "bm";
            ddlt_whzt_sbwh.DataSource = SysData.WHZT().Copy();
            ddlt_whzt_sbwh.DataBind();
            ddlt_whzt_sbwh.Items.Insert(0, new ListItem("全部", "-1"));
        }
        #endregion

        #region 状态显示颜色
        protected void Repeater_DHSB_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_dhsb.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_dhsb");
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

        protected void Repeater_TXSB_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_txsb.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_txsb");
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

        protected void Repeater_QXSB_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_qxsb.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_qxsb");
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

        protected void Repeater_JSSB_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_jssb.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_jssb");
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

        protected void Repeater_TZGL_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_tzgl.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_tzgl");
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

        protected void Repeater_BJGL_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_bjgl.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_bjgl");
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


        protected void Repeater_BJCK_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_bjck.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_bjck");
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


        protected void Repeater_BJRK_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_bjrk.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_bjrk");
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


        protected void Repeater_SBGZ_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_sbgz.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_sbgz");
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

        protected void Repeater_SBWH_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater_sbwh.Items)
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt_sbwh");
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

        #endregion

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

        #region 分页事件
        protected void pg_txsb_PageChanged(object sender, EventArgs e)
        {
            Select_txsb();
        }
        protected void pg_dhsb_PageChanged(object sender, EventArgs e)
        {
            Select_dhsb();
        }
        protected void pg_qxsb_PageChanged(object sender, EventArgs e)
        {
            Select_qxsb();
        }
        protected void pg_jssb_PageChanged(object sender, EventArgs e)
        {
            Select_jssb();
        }
        protected void pg_tzgl_PageChanged(object sender, EventArgs e)
        {
            Select_tzgl();
        }
        protected void pg_bjgl_PageChanged(object sender, EventArgs e)
        {
            Select_bjgl();
        }
        protected void pg_bjck_PageChanged(object sender, EventArgs e)
        {
            Select_bjck();
        }
        protected void pg_bjrk_PageChanged(object sender, EventArgs e)
        {
            Select_bjrk();
        }
        protected void pg_sbgz_PageChanged(object sender, EventArgs e)
        {
            Select_sbgz();
        }
        protected void pg_sbwh_PageChanged(object sender, EventArgs e)
        {
            Select_sbwh();
        }

        #endregion

        #region 查询按钮

        protected void btn_SelectDHSB_Click(object sender, EventArgs e)
        {
            Select_dhsb();
        }
        protected void btn_SelectTXSB_Click(object sender, EventArgs e)
        {
            Select_txsb();
        }
        protected void btn_SelectQXSB_Click(object sender, EventArgs e)
        {
            Select_qxsb();
        }
        protected void btn_SelectJSSB_Click(object sender, EventArgs e)
        {
            Select_jssb();
        }
        protected void btn_SelectTZGL_Click(object sender, EventArgs e)
        {
            Select_tzgl();
        }
        protected void btn_SelectBJGL_Click(object sender, EventArgs e)
        {
            Select_bjgl();
        }
        protected void btn_SelectBJCK_Click(object sender, EventArgs e)
        {
            Select_bjck();
        }
        protected void btn_SelectBJRK_Click(object sender, EventArgs e)
        {
            Select_bjrk();
        }
        protected void btn_SelectSBGZ_Click(object sender, EventArgs e)
        {
            Select_sbgz();
        }
        protected void btn_SelectSBWH_Click(object sender, EventArgs e)
        {
            Select_sbwh();
        }
        #endregion



        protected void ddlt_jbrbm_SelectedIndexChanged_bjck(object sender, EventArgs e)
        {
            string bm = ddlt_jbrbm_bjck.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_jbrgw_bjck.DataSource = dt;
                ddlt_jbrgw_bjck.DataBind();
                ddlt_jbrgw_bjck.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_jbrgw_bjck.DataSource = SysData.GW(bm).Copy();
                ddlt_jbrgw_bjck.DataTextField = "mc";
                ddlt_jbrgw_bjck.DataValueField = "bm";
                ddlt_jbrgw_bjck.DataBind();
                ddlt_jbrgw_bjck.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        protected void ddlt_fzrbm_SelectedIndexChanged_bjck(object sender, EventArgs e)
        {
            string bm = ddlt_fzrbm_bjck.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_fzrgw_bjck.DataSource = dt;
                ddlt_fzrgw_bjck.DataBind();
                ddlt_fzrgw_bjck.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_fzrgw_bjck.DataSource = SysData.GW(bm).Copy();
                ddlt_fzrgw_bjck.DataTextField = "mc";
                ddlt_fzrgw_bjck.DataValueField = "bm";
                ddlt_fzrgw_bjck.DataBind();
                ddlt_fzrgw_bjck.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        protected void ddlt_jbrbm_SelectedIndexChanged_bjrk(object sender, EventArgs e)
        {
            string bm = ddlt_jbrbm_bjrk.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_jbrgw_bjrk.DataSource = dt;
                ddlt_jbrgw_bjrk.DataBind();
                ddlt_jbrgw_bjrk.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_jbrgw_bjrk.DataSource = SysData.GW(bm).Copy();
                ddlt_jbrgw_bjrk.DataTextField = "mc";
                ddlt_jbrgw_bjrk.DataValueField = "bm";
                ddlt_jbrgw_bjrk.DataBind();
                ddlt_jbrgw_bjrk.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        protected void ddlt_fzrbm_SelectedIndexChanged_bjrk(object sender, EventArgs e)
        {
            string bm = ddlt_fzrbm_bjrk.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_fzrgw_bjrk.DataSource = dt;
                ddlt_fzrgw_bjrk.DataBind();
                ddlt_fzrgw_bjrk.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_fzrgw_bjrk.DataSource = SysData.GW(bm).Copy();
                ddlt_fzrgw_bjrk.DataTextField = "mc";
                ddlt_fzrgw_bjrk.DataValueField = "bm";
                ddlt_fzrgw_bjrk.DataBind();
                ddlt_fzrgw_bjrk.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }
        protected void ddlt_whrbm_SelectedIndexChanged_sbwh(object sender, EventArgs e)
        {
            string bm = ddlt_whrbm_sbwh.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_whrgw_sbwh.DataSource = dt;
                ddlt_whrgw_sbwh.DataBind();
                ddlt_whrgw_sbwh.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_whrgw_sbwh.DataSource = SysData.GW(bm).Copy();
                ddlt_whrgw_sbwh.DataTextField = "mc";
                ddlt_whrgw_sbwh.DataValueField = "bm";
                ddlt_whrgw_sbwh.DataBind();
                ddlt_whrgw_sbwh.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        protected void ddlt_sblx_SelectedIndexChanged_sbwh(object sender, EventArgs e)
        {
            string lx = ddlt_sblx_sbwh.SelectedValue.ToString();
            if (lx == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_sbzl_sbwh.DataSource = dt;
                ddlt_sbzl_sbwh.DataBind();
                ddlt_sbzl_sbwh.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_sbzl_sbwh.DataSource = SysData.SBZL(lx).Copy();
                ddlt_sbzl_sbwh.DataTextField = "mc";
                ddlt_sbzl_sbwh.DataValueField = "bm";
                ddlt_sbzl_sbwh.DataBind();
                ddlt_sbzl_sbwh.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        protected void ddlt_sblx_SelectedIndexChanged_sbgz(object sender, EventArgs e)
        {
            string lx = ddlt_sblx_sbgz.SelectedValue.ToString();
            if (lx == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_sbzl_sbgz.DataSource = dt;
                ddlt_sbzl_sbgz.DataBind();
                ddlt_sbzl_sbgz.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_sbzl_sbgz.DataSource = SysData.SBZL(lx).Copy();
                ddlt_sbzl_sbgz.DataTextField = "mc";
                ddlt_sbzl_sbgz.DataValueField = "bm";
                ddlt_sbzl_sbgz.DataBind();
                ddlt_sbzl_sbgz.Items.Insert(0, new ListItem("全部", "-1"));
            }

        }

        protected void ddlt_whrbm_SelectedIndexChanged_sbgz(object sender, EventArgs e)
        {
            string bm = ddlt_wxrbm_sbgz.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_wxrgw_sbgz.DataSource = dt;
                ddlt_wxrgw_sbgz.DataBind();
                ddlt_wxrgw_sbgz.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_wxrgw_sbgz.DataSource = SysData.GW(bm).Copy();
                ddlt_wxrgw_sbgz.DataTextField = "mc";
                ddlt_wxrgw_sbgz.DataValueField = "bm";
                ddlt_wxrgw_sbgz.DataBind();
                ddlt_wxrgw_sbgz.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }
    }
}