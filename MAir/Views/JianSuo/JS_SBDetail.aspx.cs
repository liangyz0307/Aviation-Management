
using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.IO;

namespace CUST.WKG
{
    public partial class JS_SBDetail : System.Web.UI.Page
    {
        private UserState _usState;
        public JS js;
        public string sbbh;
        public string sblx;
        public OJS.Struct_JS_DHSB struct_js_dhsb;
        public OJS.Struct_JS_TXSB struct_js_txsb;
        public OJS.Struct_JS_QXSB struct_js_qxsb;
        public OJS.Struct_JS_YBSB struct_js_ybsb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new JS(_usState);
            if (!IsPostBack)
            {
                show();
            }
        }
        private void show()
        {
            sbbh = Request.Params["sbbh"].ToString();
            sblx = Request.Params["sblx"].ToString();
            #region
            if(sblx=="导航")
            {

                t_dh.Visible = true;
                t_tx.Visible = false;
                t_qx.Visible = false;
                t_wh.Visible = true;
                t_gz.Visible = true;
                t_yb.Visible = false;

                
                struct_js_dhsb.p_sbbh = sbbh;
                DataTable dt_select = new DataTable();
                dt_select = js.Select_JS_DHSBDetail(struct_js_dhsb).Tables[0];
                lbl_sbbh.Text = sbbh;
                lbl_sblb.Text = SysData.SBLBByKey(dt_select.Rows[0]["sblb"].ToString()).mc;
                lbl_sbzl.Text = SysData.SBZLByKey(dt_select.Rows[0]["sbzl"].ToString()).mc;
                lbl_tcrq.Text = dt_select.Rows[0]["tcrq"].ToString();
                lbl_jgrq.Text = dt_select.Rows[0]["jgrq"].ToString();
                lbl_pl.Text = dt_select.Rows[0]["pl"].ToString();
                lbl_hh.Text = dt_select.Rows[0]["hh"].ToString();
                lbl_wxdsbfshzzbh.Text = dt_select.Rows[0]["wxdsbfshzzbh"].ToString();
                lbl_zzyxq.Text = dt_select.Rows[0]["zzyxq"].ToString();
                lbl_txgd.Text = dt_select.Rows[0]["txgd"].ToString();
                lbl_jkqfw.Text = dt_select.Rows[0]["jkqfw"].ToString();
                lbl_cpc.Text = dt_select.Rows[0]["cpc"].ToString();
                lbl_dwzj.Text = dt_select.Rows[0]["dwzj"].ToString();
                lbl_dwgd.Text = dt_select.Rows[0]["dwgd"].ToString();
                lbl_dwlx.Text = SysData.DWLXByKey(dt_select.Rows[0]["dwlx"].ToString()).mc;
                lbl_gn.Text = dt_select.Rows[0]["gn"].ToString();
                lbl_sl.Text = dt_select.Rows[0]["sl"].ToString();
                lbl_djdw.Text = dt_select.Rows[0]["dj"].ToString();
                lbl_fxjy.Text = SysData.FXXJByKey(dt_select.Rows[0]["fxjy"].ToString()).mc;
                lbl_fxjyrq.Text = dt_select.Rows[0]["fxjyrq"].ToString();
                lbl_kfxkdqr.Text = dt_select.Rows[0]["kfxkdqr"].ToString();
                lbl_fxjyzq.Text = dt_select.Rows[0]["fxjyzqzt"].ToString();
                lbl_dlwz.Text = dt_select.Rows[0]["dlwz"].ToString();
                lbl_fgfw.Text = SysData.FGFWByKey(dt_select.Rows[0]["fgfw"].ToString()).mc;
                lbl_fgbfhsm.Text = dt_select.Rows[0]["fgbfhqksm"].ToString();
                lbl_ddzbbjjd.Text = dt_select.Rows[0]["ddzb_bj_jd"].ToString();
                lbl_ddzbbjwd.Text = dt_select.Rows[0]["ddzb_bj_wd"].ToString();
                lbl_ddzbwgsjd.Text = dt_select.Rows[0]["ddzb_wgs_jd"].ToString();
                lbl_ddzbwgswd.Text = dt_select.Rows[0]["ddzb_wgs_wd"].ToString();
                lbl_hhgc.Text = dt_select.Rows[0]["hhgc"].ToString();
                lbl_sstzmc.Text = SysData.TZLXByKey(dt_select.Rows[0]["sstzmc"].ToString()).mc;
                lbl_zxmc.Text = SysData.ZXDMByKey(dt_select.Rows[0]["zxdm"].ToString()).mc;
                lbl_bzqk.Text=SysData.BZQKByKey( dt_select.Rows[0]["bzqk"].ToString()).mc;
                lbl_gcbz.Text = dt_select.Rows[0]["gcbz"].ToString();
                if (dt_select.Rows[0]["wxdsbfshzzj"].ToString() != "")
                {
                    string tzpfname = dt_select.Rows[0]["wxdsbfshzzj"].ToString().Substring(dt_select.Rows[0]["wxdsbfshzzj"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_wxdsbfshzzj.Text = tzpfname;
                }
                lbl_whr.Text = dt_select.Rows[0]["whr"].ToString();
                lbl_whrbm.Text =SysData.BMByKey( dt_select.Rows[0]["whrbm"].ToString()).mc;
                lbl_whrgw.Text = SysData.GWByKey(dt_select.Rows[0]["whrgw"].ToString()).mc;
                lbl_sbztxxxx.Text = dt_select.Rows[0]["sbztxxxx"].ToString();
                lbl_whjl.Text = dt_select.Rows[0]["whjl"].ToString();
                lbl_cdhjhdchjcsjl.Text = dt_select.Rows[0]["cdhjhdchjxsjl"].ToString();
                lbl_whzt.Text =SysData.WHZTByKey( dt_select.Rows[0]["whzt"].ToString()).mc;
                if (dt_select.Rows[0]["whwjsc"].ToString() != "")
                {
                    string tzpfname = dt_select.Rows[0]["whwjsc"].ToString().Substring(dt_select.Rows[0]["whwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_whwj.Text = tzpfname;
                }
                lbl_whsj.Text = dt_select.Rows[0]["whsj"].ToString();
                lbl_whbz.Text = dt_select.Rows[0]["whbz"].ToString();

                lbl_gzqssj.Text = dt_select.Rows[0]["gzqssj"].ToString();
                lbl_gzjssj.Text = dt_select.Rows[0]["gzjssj"].ToString();
                lbl_ljsc.Text = dt_select.Rows[0]["ljsc"].ToString();
                lbl_wxr.Text = dt_select.Rows[0]["wxr"].ToString();
                lbl_wxrbm.Text = SysData.BMByKey(dt_select.Rows[0]["wxrbm"].ToString()).mc;
                lbl_wxrgw.Text = SysData.GWByKey(dt_select.Rows[0]["wxrgw"].ToString()).mc;
                lbl_gzxx.Text = dt_select.Rows[0]["gzxx"].ToString();
                lbl_zcyx.Text = dt_select.Rows[0]["zcyx"].ToString();
                lbl_czgc.Text = dt_select.Rows[0]["czgc"].ToString();
                lbl_clbz.Text = dt_select.Rows[0]["czgc"].ToString();
                lbl_gzyyfx.Text = dt_select.Rows[0]["gzyyfx"].ToString();
                lbl_gzbjcljg.Text = dt_select.Rows[0]["gzbjcljg"].ToString();
                lbl_tlgzpcff.Text = dt_select.Rows[0]["tlgzpcff"].ToString();
                lbl_jycs.Text = dt_select.Rows[0]["jycs"].ToString();
                if (dt_select.Rows[0]["wxwjsc"].ToString() != "")
                {
                    string tzpfname = dt_select.Rows[0]["wxwjsc"].ToString().Substring(dt_select.Rows[0]["wxwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_wxwj.Text = tzpfname;
                }
                lbl_gzbz.Text = dt_select.Rows[0]["gzbz"].ToString();
            }
            #endregion
            #region
            if (sblx == "通信")
            {
                t_dh.Visible = false;
                t_tx.Visible = true;
                t_qx.Visible = false;
                t_wh.Visible = true;
                t_gz.Visible = true;
                t_yb.Visible = false;
                struct_js_txsb.p_sbbh = sbbh;
                DataTable dt = new DataTable();
                dt = js.Select_JS_TXSBDetail(struct_js_txsb).Tables[0];
                lbl_txsbbh.Text = dt.Rows[0]["sbbh"].ToString();
                lbl_txsbzl.Text = SysData.SBZLByKey(dt.Rows[0]["sbzl"].ToString()).mc;
                lbl_txsstzmc.Text = SysData.TZLXByKey(dt.Rows[0]["sstzmc"].ToString()).mc;
                lbl_jgysrq.Text = dt.Rows[0]["jgysrq"].ToString();
                lbl_tckfrq.Text = dt.Rows[0]["tckfrq"].ToString();
                lbl_sfwwxdsb.Text = SysData.SFWXDSBByKey(dt.Rows[0]["SFWXDSB"].ToString()).mc;
                if (dt.Rows[0]["wxdsbfshzzj"].ToString() != "")
                {
                    string tzpfname = dt.Rows[0]["wxdsbfshzzj"].ToString().Substring(dt.Rows[0]["wxdsbfshzzj"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_txwxdsbfshzzj.Text = tzpfname;
                }
                lbl_txzgyxq.Text = dt.Rows[0]["ZZYXQ"].ToString();
                lbl_sbcqdw.Text = dt.Rows[0]["SBCQDW"].ToString();
                lbl_sbwhdw.Text = dt.Rows[0]["SBWHDW"].ToString();
                lbl_sblssyxkz.Text = dt.Rows[0]["SBSYXKZH"].ToString();
                lbl_txfs.Text = SysData.TXFSByKey(dt.Rows[0]["TXFS"].ToString()).mc;
                lbl_sbpz.Text = dt.Rows[0]["SBPZ"].ToString();
                lbl_sbyt.Text = SysData.SBYTByKey(dt.Rows[0]["sbyt"].ToString()).mc;
                lbl_txsl.Text = dt.Rows[0]["sl"].ToString();
                lbl_txlx.Text = dt.Rows[0]["txlx"].ToString();
                lbl_ykxtzkf.Text = dt.Rows[0]["YKXT_ZKF"].ToString();
                lbl_ykxtskf.Text = dt.Rows[0]["YKXT_SKF"].ToString();
                lbl_gzpl.Text = dt.Rows[0]["GZPL"].ToString();
                lbl_fsgl.Text = dt.Rows[0]["FSGL"].ToString();
                lbl_gdfs.Text = dt.Rows[0]["GDFS"].ToString();
                lbl_cszl.Text = dt.Rows[0]["CSZL"].ToString();
                lbl_sbazdd.Text = dt.Rows[0]["SBAZDD"].ToString();
                lbl_cyzzrs.Text = dt.Rows[0]["CYZZRS"].ToString();
                lbl_txfxjy.Text = SysData.FXXJByKey(dt.Rows[0]["FXJY"].ToString()).mc;
                lbl_fxjyrq.Text = dt.Rows[0]["FXJYRQ"].ToString();
                lbl_txfxjyrq.Text = dt.Rows[0]["KFXKDQR"].ToString();
                lbl_txfxjyzq.Text =dt.Rows[0]["FXJYZQZT"].ToString();
                lbl_tzzbjdbj.Text = dt.Rows[0]["DDZB_BJ_JD"].ToString();
                lbl_tzzbwdbj.Text = dt.Rows[0]["DDZB_BJ_WD"].ToString();
                lbl_tzzbjd.Text = dt.Rows[0]["DDZB_WGS_JD"].ToString();
                lbl_tzzbwd.Text = dt.Rows[0]["DDZB_WGS_WD"].ToString();
                lbl_txhhgc.Text = dt.Rows[0]["HHGC"].ToString();
                lbl_txgcbz.Text = dt.Rows[0]["GCBZ"].ToString();
                lbl_bz.Text = dt.Rows[0]["BZ"].ToString();
                lbl_kfxkdrq.Text = dt.Rows[0]["kfxkdqr"].ToString();
                lbl_txzxmc.Text = SysData.ZXDMByKey(dt.Rows[0]["zxdm"].ToString()).mc;
                lbl_txbzqk.Text = SysData.BZQKByKey(dt.Rows[0]["bzqk"].ToString()).mc;
                //维护
                lbl_whr.Text = dt.Rows[0]["whr"].ToString();
                lbl_whrbm.Text = SysData.BMByKey(dt.Rows[0]["whrbm"].ToString()).mc;
                lbl_whrgw.Text = SysData.GWByKey(dt.Rows[0]["whrgw"].ToString()).mc;
                lbl_sbztxxxx.Text = dt.Rows[0]["sbztxxxx"].ToString();
                lbl_whjl.Text = dt.Rows[0]["whjl"].ToString();
                lbl_cdhjhdchjcsjl.Text = dt.Rows[0]["cdhjhdchjxsjl"].ToString();
                lbl_whzt.Text = SysData.WHZTByKey(dt.Rows[0]["whzt"].ToString()).mc;
                if (dt.Rows[0]["whwjsc"].ToString() != "")
                {
                    string tzpfname = dt.Rows[0]["whwjsc"].ToString().Substring(dt.Rows[0]["whwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_whwj.Text = tzpfname;
                }
                lbl_whsj.Text = dt.Rows[0]["whsj"].ToString();
                lbl_whbz.Text = dt.Rows[0]["whbz"].ToString();
                //故障
                lbl_gzqssj.Text = dt.Rows[0]["gzqssj"].ToString();
                lbl_gzjssj.Text = dt.Rows[0]["gzjssj"].ToString();
                lbl_ljsc.Text = dt.Rows[0]["ljsc"].ToString();
                lbl_wxr.Text = dt.Rows[0]["wxr"].ToString();
                lbl_wxrbm.Text = SysData.BMByKey(dt.Rows[0]["wxrbm"].ToString()).mc;
                lbl_wxrgw.Text = SysData.GWByKey(dt.Rows[0]["wxrgw"].ToString()).mc;
                lbl_gzxx.Text = dt.Rows[0]["gzxx"].ToString();
                lbl_zcyx.Text = dt.Rows[0]["zcyx"].ToString();
                lbl_czgc.Text = dt.Rows[0]["czgc"].ToString();
                lbl_clbz.Text = dt.Rows[0]["czgc"].ToString();
                lbl_gzyyfx.Text = dt.Rows[0]["gzyyfx"].ToString();
                lbl_gzbjcljg.Text = dt.Rows[0]["gzbjcljg"].ToString();
                lbl_tlgzpcff.Text = dt.Rows[0]["tlgzpcff"].ToString();
                lbl_jycs.Text = dt.Rows[0]["jycs"].ToString();
                if (dt.Rows[0]["wxwjsc"].ToString() != "")
                {
                    string tzpfname = dt.Rows[0]["wxwjsc"].ToString().Substring(dt.Rows[0]["wxwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_wxwj.Text = tzpfname;
                }
                lbl_gzbz.Text = dt.Rows[0]["gzbz"].ToString();
            }
            #endregion
            #region
            if (sblx == "气象")
            {
                t_dh.Visible = false;
                t_tx.Visible = false;
                t_qx.Visible = true;
                t_wh.Visible = true;
                t_gz.Visible = true;
                t_yb.Visible = false;
                struct_js_qxsb.p_sbbh = sbbh;
                DataTable dt = new DataTable();
                dt = js.Select_JS_QXSBDetail(struct_js_qxsb).Tables[0];
                lbl_qxsbbh.Text = sbbh;
                lbl_qxsbzl.Text = SysData.SBZLByKey(dt.Rows[0]["sbzl"].ToString()).mc;
                lbl_qxsstzmc.Text = SysData.TZLXByKey(dt.Rows[0]["sstzmc"].ToString()).mc;
                lbl_sbzt.Text = SysData.SBZTByKey(dt.Rows[0]["sbzt"].ToString()).mc;
                lbl_qxtcrq.Text = dt.Rows[0]["tcrq"].ToString();
                lbl_qxjgrq.Text = dt.Rows[0]["jgrq"].ToString();
                lbl_qxsbpz.Text = dt.Rows[0]["sbpz"].ToString();
                lbl_qxsbyt.Text = dt.Rows[0]["sbyt"].ToString();
                lbl_qxsl.Text = dt.Rows[0]["sl"].ToString();
                lbl_qxyxqk.Text = dt.Rows[0]["yxqk"].ToString();
                lbl_cgqjdzsbh.Text = dt.Rows[0]["cgqjdzsbh"].ToString();
                if (dt.Rows[0]["cgqjdzs"].ToString() != "")
                {
                    string tzpfname = dt.Rows[0]["cgqjdzs"].ToString().Substring(dt.Rows[0]["cgqjdzs"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_cgqjdzs.Text = tzpfname;
                }
                lbl_cgqjdyxq.Text = dt.Rows[0]["cgqjdyxq"].ToString();
                lbl_qxzxmc.Text = SysData.ZXDMByKey(dt.Rows[0]["zxdm"].ToString()).mc;
                lbl_qxbz.Text = dt.Rows[0]["bz"].ToString();

                //维护
                lbl_whr.Text = dt.Rows[0]["whr"].ToString();
                lbl_whrbm.Text = SysData.BMByKey(dt.Rows[0]["whrbm"].ToString()).mc;
                lbl_whrgw.Text = SysData.GWByKey(dt.Rows[0]["whrgw"].ToString()).mc;
                lbl_sbztxxxx.Text = dt.Rows[0]["sbztxxxx"].ToString();
                lbl_whjl.Text = dt.Rows[0]["whjl"].ToString();
                lbl_cdhjhdchjcsjl.Text = dt.Rows[0]["cdhjhdchjxsjl"].ToString();
                lbl_whzt.Text = SysData.WHZTByKey(dt.Rows[0]["whzt"].ToString()).mc;
                if (dt.Rows[0]["whwjsc"].ToString() != "")
                {
                    string tzpfname = dt.Rows[0]["whwjsc"].ToString().Substring(dt.Rows[0]["whwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_whwj.Text = tzpfname;
                }
                lbl_whsj.Text = dt.Rows[0]["whsj"].ToString();
                lbl_whbz.Text = dt.Rows[0]["whbz"].ToString();
                //故障
                lbl_gzqssj.Text = dt.Rows[0]["gzqssj"].ToString();
                lbl_gzjssj.Text = dt.Rows[0]["gzjssj"].ToString();
                lbl_ljsc.Text = dt.Rows[0]["ljsc"].ToString();
                lbl_wxr.Text = dt.Rows[0]["wxr"].ToString();
                lbl_wxrbm.Text = SysData.BMByKey(dt.Rows[0]["wxrbm"].ToString()).mc;
                lbl_wxrgw.Text = SysData.GWByKey(dt.Rows[0]["wxrgw"].ToString()).mc;
                lbl_gzxx.Text = dt.Rows[0]["gzxx"].ToString();
                lbl_zcyx.Text = dt.Rows[0]["zcyx"].ToString();
                lbl_czgc.Text = dt.Rows[0]["czgc"].ToString();
                lbl_clbz.Text = dt.Rows[0]["czgc"].ToString();
                lbl_gzyyfx.Text = dt.Rows[0]["gzyyfx"].ToString();
                lbl_gzbjcljg.Text = dt.Rows[0]["gzbjcljg"].ToString();
                lbl_tlgzpcff.Text = dt.Rows[0]["tlgzpcff"].ToString();
                lbl_jycs.Text = dt.Rows[0]["jycs"].ToString();
                if (dt.Rows[0]["wxwjsc"].ToString() != "")
                {
                    string tzpfname = dt.Rows[0]["wxwjsc"].ToString().Substring(dt.Rows[0]["wxwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_wxwj.Text = tzpfname;
                }
                lbl_gzbz.Text = dt.Rows[0]["gzbz"].ToString();
            }
            #endregion
            #region
            if(sblx=="仪表")
            {
                t_dh.Visible = false;
                t_tx.Visible = false;
                t_qx.Visible = false;
                t_wh.Visible = true;
                t_gz.Visible = true;
                t_yb.Visible = true;
                struct_js_ybsb.p_sbbh = sbbh;
                DataTable dt_select = new DataTable();
                dt_select = js.Select_JS_YBSBDetail(struct_js_ybsb).Tables[0];
                lbl_ybsbbh.Text = dt_select.Rows[0]["sbbh"].ToString();
                lbl_ybsbzl.Text =SysData.SBZLByKey( dt_select.Rows[0]["sbzl"].ToString()).mc;
                lbl_ybsbmc.Text = dt_select.Rows[0]["sbmc"].ToString();
                lbl_ybsbxh.Text = dt_select.Rows[0]["sbxh"].ToString();
                lbl_ybjcrq.Text = dt_select.Rows[0]["jcrq"].ToString();
                lbl_ybjcyxq.Text = dt_select.Rows[0]["jcyxq"].ToString();
                lbl_ybhgzbh.Text = dt_select.Rows[0]["jchgzbh"].ToString();
                lbl_ybhgzsc.Text = dt_select.Rows[0]["jchgz"].ToString();
                lbl_ybscsj.Text = dt_select.Rows[0]["scsj"].ToString();
                lbl_ybgzrq.Text = dt_select.Rows[0]["gzrq"].ToString();
                lbl_ybjg.Text = dt_select.Rows[0]["jg"].ToString();
                lbl_ybsl.Text = dt_select.Rows[0]["sl"].ToString();
                lbl_yybtcrq.Text = dt_select.Rows[0]["tcrq"].ToString();
                lbl_ybsccj.Text = dt_select.Rows[0]["sccj"].ToString();
                lbl_yblxr.Text = dt_select.Rows[0]["lxr"].ToString();
                lbl_ybcjtxfs.Text = dt_select.Rows[0]["cjtxfs"].ToString();
                lbl_ybsbzt.Text = dt_select.Rows[0]["sbzt"].ToString();
                lbl_ybgzbmdm.Text = dt_select.Rows[0]["gzbmdm"].ToString();
                lbl_yybcpcs.Text = dt_select.Rows[0]["cpcs"].ToString();
                lbl_ybsbpz.Text = dt_select.Rows[0]["sbpz"].ToString();
                lbl_ybsbyt.Text = dt_select.Rows[0]["sbyt"].ToString();
                lbl_ybsszxmc.Text =SysData.TZLXByKey( dt_select.Rows[0]["sstzmc"].ToString()).mc;
                lbl_ybsszx.Text =SysData.ZXDMByKey( dt_select.Rows[0]["zxdm"].ToString()).mc;
                lbl_ybbzqk.Text = dt_select.Rows[0]["bzqk"].ToString();
                lbl_ybbz.Text = dt_select.Rows[0]["bz"].ToString();
                lbl_whr.Text = dt_select.Rows[0]["whr"].ToString();
                lbl_whrbm.Text = SysData.BMByKey(dt_select.Rows[0]["whrbm"].ToString()).mc;
                lbl_whrgw.Text = SysData.GWByKey(dt_select.Rows[0]["whrgw"].ToString()).mc;
                lbl_sbztxxxx.Text = dt_select.Rows[0]["sbztxxxx"].ToString();
                lbl_whjl.Text = dt_select.Rows[0]["whjl"].ToString();
                lbl_cdhjhdchjcsjl.Text = dt_select.Rows[0]["cdhjhdchjxsjl"].ToString();
                lbl_whzt.Text = SysData.WHZTByKey(dt_select.Rows[0]["whzt"].ToString()).mc;
                if (dt_select.Rows[0]["whwjsc"].ToString() != "")
                {
                    string tzpfname = dt_select.Rows[0]["whwjsc"].ToString().Substring(dt_select.Rows[0]["whwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_whwj.Text = tzpfname;
                }
                lbl_whsj.Text = dt_select.Rows[0]["whsj"].ToString();
                lbl_whbz.Text = dt_select.Rows[0]["whbz"].ToString();

                lbl_gzqssj.Text = dt_select.Rows[0]["gzqssj"].ToString();
                lbl_gzjssj.Text = dt_select.Rows[0]["gzjssj"].ToString();
                lbl_ljsc.Text = dt_select.Rows[0]["ljsc"].ToString();
                lbl_wxr.Text = dt_select.Rows[0]["wxr"].ToString();
                lbl_wxrbm.Text = SysData.BMByKey(dt_select.Rows[0]["wxrbm"].ToString()).mc;
                lbl_wxrgw.Text = SysData.GWByKey(dt_select.Rows[0]["wxrgw"].ToString()).mc;
                lbl_gzxx.Text = dt_select.Rows[0]["gzxx"].ToString();
                lbl_zcyx.Text = dt_select.Rows[0]["zcyx"].ToString();
                lbl_czgc.Text = dt_select.Rows[0]["czgc"].ToString();
                lbl_clbz.Text = dt_select.Rows[0]["czgc"].ToString();
                lbl_gzyyfx.Text = dt_select.Rows[0]["gzyyfx"].ToString();
                lbl_gzbjcljg.Text = dt_select.Rows[0]["gzbjcljg"].ToString();
                lbl_tlgzpcff.Text = dt_select.Rows[0]["tlgzpcff"].ToString();
                lbl_jycs.Text = dt_select.Rows[0]["jycs"].ToString();
                if (dt_select.Rows[0]["wxwjsc"].ToString() != "")
                {
                    string tzpfname = dt_select.Rows[0]["wxwjsc"].ToString().Substring(dt_select.Rows[0]["wxwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

                    lbtn_wxwj.Text = tzpfname;
                }
                lbl_gzbz.Text = dt_select.Rows[0]["gzbz"].ToString();


            }
            #endregion
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SBXX.aspx");
        }

        protected void lbtn_wxdsbfshzzj_Click(object sender, EventArgs e)
        {
            sbbh = Request.Params["sbbh"].ToString();
            struct_js_dhsb.p_sbbh = sbbh;
            DataTable dt_select = new DataTable();
            dt_select = js.Select_JS_DHSBDetail(struct_js_dhsb).Tables[0];
          
            string filePath = dt_select.Rows[0]["wxdsbfshzzj"].ToString();//文件名
            string filename = dt_select.Rows[0]["wxdsbfshzzj"].ToString().Substring(dt_select.Rows[0]["wxdsbfshzzj"].ToString().LastIndexOf("\\") + 1).Substring(16);
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                lbl_wxdsbfshzzj.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                //Response.End();
            }

        }

        protected void lbtn_whwj_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string filename = ""; 
            if (t_dh.Visible == true)
            {
                sbbh = Request.Params["sbbh"].ToString();
                struct_js_dhsb.p_sbbh = sbbh;
                DataTable dt_select = new DataTable();
                dt_select = js.Select_JS_DHSBDetail(struct_js_dhsb).Tables[0];
                filePath = dt_select.Rows[0]["whwjsc"].ToString();//文件名
                filename = dt_select.Rows[0]["whwjsc"].ToString().Substring(dt_select.Rows[0]["whwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);
               
            }
            if (t_tx.Visible == true)
            {
                struct_js_txsb.p_sbbh =Request.Params["sbbh"].ToString();
                DataTable dt = new DataTable();
                dt = js.Select_JS_TXSBDetail(struct_js_txsb).Tables[0];
                filePath = dt.Rows[0]["whwjsc"].ToString();//文件名
                filename = dt.Rows[0]["whwjsc"].ToString().Substring(dt.Rows[0]["whwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);
               
            }
            if(t_qx.Visible == true)
            {
                struct_js_qxsb.p_sbbh = Request.Params["sbbh"].ToString();
                DataTable dt = new DataTable();
                dt = js.Select_JS_QXSBDetail(struct_js_qxsb).Tables[0];
                filePath = dt.Rows[0]["whwjsc"].ToString();//文件名
                filename = dt.Rows[0]["whwjsc"].ToString().Substring(dt.Rows[0]["whwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);
               
            }
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                lbl_sbwhwj.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>";
            }
        }

        protected void lbtn_wxwj_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string filename = "";
            if (t_dh.Visible == true)
            {
                sbbh = Request.Params["sbbh"].ToString();
                struct_js_dhsb.p_sbbh = sbbh;
                DataTable dt_select = new DataTable();
                dt_select = js.Select_JS_DHSBDetail(struct_js_dhsb).Tables[0];

               filePath = dt_select.Rows[0]["wxwjsc"].ToString();//文件名
               filename = dt_select.Rows[0]["wxwjsc"].ToString().Substring(dt_select.Rows[0]["wxwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);
            }
            if (t_tx.Visible == true)
            {
                struct_js_txsb.p_sbbh = Request.Params["sbbh"].ToString();
                DataTable dt = new DataTable();
                dt = js.Select_JS_TXSBDetail(struct_js_txsb).Tables[0];

                 filePath = dt.Rows[0]["wxwjsc"].ToString();//文件名
                 filename = dt.Rows[0]["wxwjsc"].ToString().Substring(dt.Rows[0]["wxwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);
            }
            if (t_qx.Visible == true)
            {
                struct_js_qxsb.p_sbbh = Request.Params["sbbh"].ToString();
                DataTable dt = new DataTable();
                dt = js.Select_JS_QXSBDetail(struct_js_qxsb).Tables[0];

                 filePath = dt.Rows[0]["wxwjsc"].ToString();//文件名
                 filename = dt.Rows[0]["wxwjsc"].ToString().Substring(dt.Rows[0]["wxwjsc"].ToString().LastIndexOf("\\") + 1).Substring(16);

            }
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                lbl_wxwj.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>";
            }
        }

        protected void lbtn_cgqjdzs_Click(object sender, EventArgs e)
        {
            struct_js_qxsb.p_sbbh = Request.Params["sbbh"].ToString();
            DataTable dt = new DataTable();
            dt = js.Select_JS_QXSBDetail(struct_js_qxsb).Tables[0];
            string filePath = dt.Rows[0]["cgqjdzs"].ToString();//文件名
            string filename = dt.Rows[0]["cgqjdzs"].ToString().Substring(dt.Rows[0]["cgqjdzs"].ToString().LastIndexOf("\\") + 1).Substring(16);
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                lbl_cgqjdzs.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                //Response.End();
            }

        }

        protected void lbtn_txwxdsbfshzzj_Click(object sender, EventArgs e)
        {
            struct_js_txsb.p_sbbh = Request.Params["sbbh"].ToString();
            DataTable dt = new DataTable();
            dt = js.Select_JS_TXSBDetail(struct_js_txsb).Tables[0];

            string filePath = dt.Rows[0]["wxdsbfshzzj"].ToString();//文件名
            string filename = dt.Rows[0]["wxdsbfshzzj"].ToString().Substring(dt.Rows[0]["wxdsbfshzzj"].ToString().LastIndexOf("\\") + 1).Substring(16);
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                lbl_txwxdsbfshzzj.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                                                                                                  //Response.End();
            }
        }
    }
}