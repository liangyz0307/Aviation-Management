using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;

namespace CUST.WKG
{
    public partial class JS_BSDetail : System.Web.UI.Page
    {
        private UserState _usState;
        public JS js;
        public OJS.Struct_JS struct_js;
        public string bsbh;
        public string bslx;
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
            bsbh = Request.Params["bsbh"].ToString();
            bslx = Request.Params["bslx"].ToString();
            DataTable dt = new DataTable();
            if (bslx == "01")
            {
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_zdgz.Visible = false;
                t_fxy.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = true;

                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt=js.Select_BS_HBYXXX_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_hbh.Text= dt.Rows[0]["hbh"].ToString();
                lbl_hblx.Text =SysData.HBLXByKey( dt.Rows[0]["hblx"].ToString()).mc;
                lbl_hbzxmc.Text =SysData.ZXDMByKey( dt.Rows[0]["zxmc"].ToString()).mc;
                lbl_qxqk.Text = dt.Rows[0]["qxqk"].ToString();
                lbl_cfcs.Text = dt.Rows[0]["cfcs"].ToString();
                lbl_cfrq.Text = dt.Rows[0]["cfrq"].ToString();
                lbl_ddrq.Text = dt.Rows[0]["ddrq"].ToString();
                lbl_hbyxzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;

            }
            if (bslx == "02")
            {
                t_hbyxxx.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_zdgz.Visible = false;
                t_fxy.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_tq.Visible = true;

              
                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_TQCZ_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_tqzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_gzqk.Text= dt.Rows[0]["gzqk"].ToString();
                lbl_sjqk.Text= dt.Rows[0]["sjqk"].ToString();
                lbl_sbyxqk.Text= dt.Rows[0]["sbyxqk"].ToString();
                lbl_tqsfsj.Text= dt.Rows[0]["sfsj"].ToString();
                lbl_zrdw.Text=SysData.BMByKey( dt.Rows[0]["zrdw"].ToString()).mc;
                lbl_bgsj.Text= dt.Rows[0]["bgsj"].ToString();
                lbl_tqbz.Text= dt.Rows[0]["bz"].ToString();
                lbl_tqfzr.Text= dt.Rows[0]["lxrxm"].ToString();
            }
            if (bslx == "03")
            {
                t_hbyxxx.Visible = false;
                t_gzjz.Visible = false;
                t_zdgz.Visible = false;
                t_fxy.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = true;

                
                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_ZBAP_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_zazt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_zbap.Text= dt.Rows[0]["zbyxm"].ToString();
                lbl_zbsj.Text= dt.Rows[0]["zbsj"].ToString();
                lbl_zbdd.Text= dt.Rows[0]["zbdd"].ToString();
                lbl_zblc.Text= dt.Rows[0]["zblc"].ToString();
                lbl_zbbz.Text= dt.Rows[0]["bz"].ToString();
            }
            if (bslx == "04")
            {
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_fxy.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = true;

               
                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_GZJZ_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_gzjzzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;

                lbl_zxmc.Text = SysData.ZXDMByKey(dt.Rows[0]["zxmc"].ToString()).mc ;
                lbl_gznr.Text= dt.Rows[0]["gznr"].ToString();
                lbl_wcjd.Text= dt.Rows[0]["wcjd"].ToString();
                lbl_gzfzr.Text= dt.Rows[0]["gzfzrxm"].ToString();
                lbl_gzlc.Text= dt.Rows[0]["gzlc"].ToString();
                lbl_gzjz.Text= dt.Rows[0]["bz"].ToString();
            }
            if (bslx == "05")
            {
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_fxy.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = true;

                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_ZDGZ_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_bszx.Text=SysData.ZXDMByKey( dt.Rows[0]["bszx"].ToString()).mc;
                lbl_zdgznr.Text = dt.Rows[0]["zdgznr"].ToString();
                lbl_zxzx.Text =SysData.ZXDMByKey( dt.Rows[0]["zxzx"].ToString()).mc;
                lbl_zdgzfzr.Text = dt.Rows[0]["gzfzrxm"].ToString();
                lbl_zdgz.Text = dt.Rows[0]["bz"].ToString();
                lbl_zdgzzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
            }
            if (bslx == "06")
            {
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_fxy.Visible = true;

                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_FXY_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_fxyzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_fxymc.Text = dt.Rows[0]["fxymc"].ToString();
                lbl_fxyfc.Text =SysData.WXYFCByKey( dt.Rows[0]["fxyfc"].ToString()).mc;
                lbl_st.Text =SysData.STDMByKey( dt.Rows[0]["st"].ToString()).mc;
                lbl_fxknx.Text =SysData.FXFSKNByKey( dt.Rows[0]["fxknx"].ToString()).mc;
                lbl_fxcd.Text =SysData.FXCDByKey( dt.Rows[0]["fxcd"].ToString()).mc;
                lbl_hg.Text = dt.Rows[0]["hg"].ToString();
                lbl_zt.Text = dt.Rows[0]["zt"].ToString();
                lbl_fxkzcs.Text = dt.Rows[0]["fxkzcs"].ToString();
                lbl_kzzt.Text =SysData.FXKZZTByKey( dt.Rows[0]["kzzt"].ToString()).mc;
                lbl_kzcsbzhqk.Text =SysData.FXKZBZByKey( dt.Rows[0]["kzcsbzhqk"].ToString()).mc;
                lbl_yjcs.Text = dt.Rows[0]["yjcs"].ToString();
                lbl_zrbm.Text =SysData.BMByKey( dt.Rows[0]["zrbm"].ToString()).mc;
                lbl_zrr.Text = dt.Rows[0]["zrrxm"].ToString();
                lbl_fxy.Text = dt.Rows[0]["bz"].ToString();

            }
            if (bslx == "07")
            {
                t_fxy.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_ys.Visible = true;

                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_YS_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_yszt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_sqbm .Text= dt.Rows[0]["sqbm"].ToString();
                lbl_ysze.Text= dt.Rows[0]["ysze"].ToString();
                lbl_ysyt.Text= dt.Rows[0]["ysyt"].ToString();
                lbl_yynx.Text= dt.Rows[0]["yynx"].ToString();
                lbl_ysly.Text= dt.Rows[0]["ysly"].ToString();
                lbl_ysbz.Text= dt.Rows[0]["bz"].ToString();

            }
            if (bslx == "08")
            {
                t_fxy.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = true;

             
                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_GDZC_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_gdzczt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_zcbh.Text= dt.Rows[0]["zcbh"].ToString();
                lbl_zcmc.Text= dt.Rows[0]["zcmc"].ToString();
                lbl_zcdj.Text= dt.Rows[0]["dj"].ToString();
                lbl_zcsl.Text= dt.Rows[0]["sl"].ToString();
                lbl_zclb.Text=dt.Rows[0]["zclb"].ToString();
                lbl_syfx.Text= dt.Rows[0]["syfx"].ToString();
                lbl_cfdd.Text= dt.Rows[0]["cfdd"].ToString();
                lbl_sybm.Text= dt.Rows[0]["sybm"].ToString();
                lbl_zcly.Text=SysData.ZCLYByKey( dt.Rows[0]["zcly"].ToString()).mc;
                lbl_zcgzrq.Text= dt.Rows[0]["gzrq"].ToString();
                lbl_rzxs.Text=SysData.RZXSByKey( dt.Rows[0]["rzxs"].ToString()).mc;
                lbl_rzrq.Text= dt.Rows[0]["rzrq"].ToString();
                lbl_gdzcbz.Text= dt.Rows[0]["bz"].ToString();

            }
            if (bslx == "09")
            {
                t_fxy.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = true;

                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_BXD_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_bxdbz.Text = dt.Rows[0]["bz"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_bxdzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_wpmc.Text= dt.Rows[0]["wpmc"].ToString();
                lbl_wplb.Text=SysData.WPLBByKey( dt.Rows[0]["wplb"].ToString()).mc;
                lbl_dj.Text= dt.Rows[0]["dj"].ToString();
                lbl_sl.Text= dt.Rows[0]["sl"].ToString();
                lbl_sccj.Text= dt.Rows[0]["sccj"].ToString();
                lbl_gmyt.Text= dt.Rows[0]["gmyt"].ToString();
                lbl_gzr.Text= dt.Rows[0]["gzr"].ToString();
                lbl_gmrq.Text= dt.Rows[0]["gmrq"].ToString();
                lbl_bxr.Text= dt.Rows[0]["bxr"].ToString();
                lbl_hj.Text= dt.Rows[0]["hj"].ToString();
                lbl_fzr.Text= dt.Rows[0]["fzrxm"].ToString();
                lbl_scyj.Text= dt.Rows[0]["scyj"].ToString();
                lbl_bxxs.Text= dt.Rows[0]["bxxs"].ToString();
                lbl_ytje.Text= dt.Rows[0]["ytje"].ToString();
                lbl_ybje.Text= dt.Rows[0]["ybje"].ToString();
                lbl_bxdbz.Text= dt.Rows[0]["bz"].ToString();
            }
            if (bslx == "10")
            {
                t_fxy.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = true;


                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_ZYBS_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_bxdbz.Text = dt.Rows[0]["bz"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_zyzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_bsms.Text= dt.Rows[0]["bsms"].ToString();
                lbl_jjfa.Text= dt.Rows[0]["jjfa"].ToString();
                lbl_zybz.Text= dt.Rows[0]["bz"].ToString();
            }
            if (bslx == "11")
            {
                t_fxy.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_dzqm.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = true;

              
                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_SG_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_bxdbz.Text = dt.Rows[0]["bz"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_sgzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;

                lbl_sfsj.Text= dt.Rows[0]["sfsj"].ToString();
                lbl_sgxq.Text= dt.Rows[0]["sgxq"].ToString();
                lbl_sgfzr.Text= dt.Rows[0]["sgfzrxm"].ToString();
                lbl_sgbz.Text= dt.Rows[0]["bz"].ToString();

            }
            if (bslx == "12")
            {
                t_fxy.Visible = false;
                t_tq.Visible = false;
                t_zbap.Visible = false;
                t_gzjz.Visible = false;
                t_hbyxxx.Visible = false;
                t_zdgz.Visible = false;
                t_ys.Visible = false;
                t_gdzc.Visible = false;
                t_bxd.Visible = false;
                t_zy.Visible = false;
                t_sg.Visible = false;
                t_dzqm.Visible = true;

               
                struct_js.p_bsbh = bsbh;
                struct_js.p_bslx = bslx;
                dt = js.Select_BS_DZQM_Detail(struct_js).Tables[0];
                lbl_bsbh.Text = dt.Rows[0]["bsbh"].ToString();
                lbl_bsgw.Text = SysData.GWByKey(dt.Rows[0]["bsgw"].ToString()).mc;
                lbl_bsip.Text = dt.Rows[0]["bsip"].ToString();
                lbl_bslx.Text = SysData.BSLXByKey(dt.Rows[0]["bslx"].ToString()).mc;
                lbl_bssj.Text = dt.Rows[0]["bssj"].ToString();
                lbl_bsyg.Text = dt.Rows[0]["bsygxm"].ToString();
                lbl_bxdbz.Text = dt.Rows[0]["bz"].ToString();
                lbl_spr.Text = dt.Rows[0]["sprxm"].ToString();
                lbl_dzqmzt.Text = SysData.ZTByKey(dt.Rows[0]["zt"].ToString()).mc;
                lbl_qmdm.Text= dt.Rows[0]["qmdm"].ToString();
                lbl_qm.Text= dt.Rows[0]["qm"].ToString();
                lbl_dzqmbz.Text= dt.Rows[0]["bz"].ToString();
            }
            

        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_BSXX.aspx");
        }

    }
}