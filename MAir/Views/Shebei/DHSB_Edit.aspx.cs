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
using System.Text;
using CUST.Tools;
using CUST;
using CUST.Sys;
using CUST.MKG;
using System.IO;
using System.Web.Services;
using Sys;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;

namespace CUST.WKG
{
    public partial class DHSB_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private DataTable dt_select;
        private DHSB dhsb;
        private Utils utils;
        private Struct_DHSB struct_dhsb;
        private string date_update;

        private int id;
        private string sjc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dhsb = new DHSB(_usState);
            utils = new Utils();
            if (!IsPostBack)
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                bind_drop();
                select_detail();
                tbx_jfdqrq.Attributes.Add("readonly", "readonly");
                tbx_tckfsj.Attributes.Add("readonly", "readonly");
                tbx_tcjfsj.Attributes.Add("readonly", "readonly");
                tbx_mcfxjyrq.Attributes.Add("readonly", "readonly");
            }
           
        }
        protected void ddlt_sblx_change(object sender, EventArgs e)
        {
            string sblx;
            ddlt_jc.SelectedValue = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
            if (ddlt_jc.SelectedValue == "-1")
            { sblx = " "; }
            else
            {
                sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
            }
            if (sblx.Equals("0201"))
            {
                wxdhsb.Attributes.Add("style", "display:ture");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0202"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:ture");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0203"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:ture");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0204"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:ture");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0205"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:ture");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0206"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:ture");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0207"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:ture");
            }
        }

        protected void ddlt_jc_change(object sender, EventArgs e)
        {
            if (ddlt_jc.SelectedValue != "-1")
            {
                DataTable dt = SysData.TZLX_ZH(ddlt_jc.SelectedValue,"02");
                //台站名称种类 台站名称
                ddlt_tzmczl.DataTextField = "mc";
                ddlt_tzmczl.DataValueField = "bm";
                ddlt_tzmczl.DataSource = dt.Copy();
                ddlt_tzmczl.DataBind();
                ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                if (dt.Rows.Count == 0)
                {
                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "该机场下无台站，请在台站管理添加！" + "</span>";
                }
                else if (ddlt_jc.SelectedValue == "-1")
                {
                    //台站名称种类 台站名称
                    ddlt_tzmczl.DataTextField = "mc";
                    ddlt_tzmczl.DataValueField = "bm";
                    ddlt_tzmczl.DataSource = SysData.TZLX_ZH("02").Copy();
                    ddlt_tzmczl.DataBind();
                    ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
                }
                else
                {
                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
                }
            }
            else
            {
                DataTable dt = SysData.TZLX_ZH("02");
                //台站名称种类 台站名称
                ddlt_tzmczl.DataTextField = "mc";
                ddlt_tzmczl.DataValueField = "bm";
                ddlt_tzmczl.DataSource = dt.Copy();
                ddlt_tzmczl.DataBind();
                ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
            }
        }
        private void bind_drop()
        {

            #region 公共字段

            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            //原所属机场
            ddlt_yssjc.DataTextField = "mc";
            ddlt_yssjc.DataValueField = "bm";
            ddlt_yssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_yssjc.DataBind();
            ddlt_yssjc.Items.Insert(0, new ListItem("全部", "-1"));

            //频率单位
            ddlt_pldw.DataTextField = "mc";
            ddlt_pldw.DataValueField = "bm";
            ddlt_pldw.DataSource = SysData.PLDW().Copy();
            ddlt_pldw.DataBind();
            ddlt_pldw.Items.Insert(0, new ListItem("全部", "-1"));

            //投产是否限用
            ddlt_tcxy.DataTextField = "mc";
            ddlt_tcxy.DataValueField = "bm";
            ddlt_tcxy.DataSource = SysData.TCSFXY().Copy();
            ddlt_tcxy.DataBind();
            ddlt_tcxy.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 台站名称
            ddlt_tzmczl.DataTextField = "mc";
            ddlt_tzmczl.DataValueField = "bm";
            ddlt_tzmczl.DataSource = SysData.TZLX_ZH("02").Copy();
            ddlt_tzmczl.DataBind();
            ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));


            //末次飞行校验结果
            ddlt_mcfxjyjg.DataTextField = "mc";
            ddlt_mcfxjyjg.DataValueField = "bm";
            ddlt_mcfxjyjg.DataSource = SysData.MCFXJYJG().Copy();
            ddlt_mcfxjyjg.DataBind();
            ddlt_mcfxjyjg.Items.Insert(0, new ListItem("全部", "-1"));

            //覆盖范围 
            ddlt_fgfwdw.DataTextField = "mc";
            ddlt_fgfwdw.DataValueField = "bm";
            ddlt_fgfwdw.DataSource = SysData.FGFWDW().Copy();
            ddlt_fgfwdw.DataBind();
            ddlt_fgfwdw.Items.Insert(0, new ListItem("全部", "-1"));

            //输出功率单位 
            ddlt_scgldw.DataTextField = "mc";
            ddlt_scgldw.DataValueField = "bm";
            ddlt_scgldw.DataSource = SysData.SCGLDW().Copy();
            ddlt_scgldw.DataBind();
            ddlt_scgldw.Items.Insert(0, new ListItem("全部", "-1"));

            //设备状态
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("全部", "-1"));

            //现所属机场
            ddlt_xssjc.DataTextField = "mc";
            ddlt_xssjc.DataValueField = "bm";
            ddlt_xssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_xssjc.DataBind();
            ddlt_xssjc.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            # region 航向设备(仪表着陆系统LOC)
            // 类别
            ddlt_hxsblb.DataTextField = "mc";
            ddlt_hxsblb.DataValueField = "bm";
            ddlt_hxsblb.DataSource = SysData.HXSBLB().Copy();
            ddlt_hxsblb.DataBind();
            ddlt_hxsblb.Items.Insert(0, new ListItem("全部", "-1"));

            //天线阵类型
            ddlt_hxsbtxzlx.DataTextField = "mc";
            ddlt_hxsbtxzlx.DataValueField = "bm";
            ddlt_hxsbtxzlx.DataSource = SysData.HXSBTXZLX().Copy();
            ddlt_hxsbtxzlx.DataBind();
            ddlt_hxsbtxzlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            # region 下滑设备（仪表着陆系统GP）
            //天线阵类型
            ddlt_xhtxzlx.DataTextField = "mc";
            ddlt_xhtxzlx.DataValueField = "bm";
            ddlt_xhtxzlx.DataSource = SysData.XHSBTXZLX().Copy();
            ddlt_xhtxzlx.DataBind();
            ddlt_xhtxzlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 测距仪(DME)
            //配套设备
            ddlt_cjyptsb.DataTextField = "mc";
            ddlt_cjyptsb.DataValueField = "bm";
            ddlt_cjyptsb.DataSource = SysData.CJYPYSB().Copy();
            ddlt_cjyptsb.DataBind();
            ddlt_cjyptsb.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 全向信标（VO2）
            //地网类型
            ddlt_qxxbdwlx.DataTextField = "mc";
            ddlt_qxxbdwlx.DataValueField = "bm";
            ddlt_qxxbdwlx.DataSource = SysData.DWLX().Copy();
            ddlt_qxxbdwlx.DataBind();
            ddlt_qxxbdwlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 无方向信标（NDB）
            //地网类型
            ddlt_wfxxbdwlx.DataTextField = "mc";
            ddlt_wfxxbdwlx.DataValueField = "bm";
            ddlt_wfxxbdwlx.DataSource = SysData.DWLX().Copy();
            ddlt_wfxxbdwlx.DataBind();
            ddlt_wfxxbdwlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 指点信标
            //类型选择
            ddlt_zdxblxxz.DataTextField = "mc";
            ddlt_zdxblxxz.DataValueField = "bm";
            ddlt_zdxblxxz.DataSource = SysData.ZDXBLXXZ().Copy();
            ddlt_zdxblxxz.DataBind();
            ddlt_zdxblxxz.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140103");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();
            ddlt_csr.Items.Insert(0, new ListItem("请选择", "-1"));

            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();
            ddlt_csr.Items.Insert(0, new ListItem("请选择", "-1"));

            //数据所在部门
            //DataTable dt_bmdm = SysData.BM("110502", _usState.userID).Copy();

            ddlt_sjszbm.DataSource = SysData.BM("140103", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void select_detail()
        {
            string id = Request.Params["id"].ToString();
            dt_select = dhsb.Select_DHSB_Detail(Convert.ToInt32(id));
              

                tbx_sbbh.Text = dt_select.Rows[0]["sbbh"].ToString();
                tbx_sbxh.Text = dt_select.Rows[0]["sbxh"].ToString();
                ddlt_jc.SelectedValue = dt_select.Rows[0]["tzmczl_tzmc"].ToString();
                ddlt_tzmczl.SelectedValue = dt_select.Rows[0]["tzmczl_tzmc"].ToString()+ dt_select.Rows[0]["tzmczl_wz"].ToString()+ dt_select.Rows[0]["tzmczl_sblx"].ToString();
                ddlt_yssjc.SelectedValue = dt_select.Rows[0]["yssjc"].ToString();
                tbx_pl.Text = dt_select.Rows[0]["pl"].ToString();
                ddlt_pldw.SelectedValue = dt_select.Rows[0]["pldw"].ToString();
                tbx_hh.Text = dt_select.Rows[0]["hh"].ToString();
                tbx_txzxdmgc.Text = dt_select.Rows[0]["txzxdmgc"].ToString();
                tbx_tx.Text = dt_select.Rows[0]["tx"].ToString();
                tbx_jfzq.Text = dt_select.Rows[0]["jfzq"].ToString();
                tbx_jfdqrq.Text = dt_select.Rows[0]["jfdqrq"].ToString();
                tbx_tckfsj.Text = dt_select.Rows[0]["tckfsj"].ToString();
                tbx_tcjfsj.Text = dt_select.Rows[0]["tcjfsj"].ToString();
                ddlt_tcxy.SelectedValue = dt_select.Rows[0]["tcsfxy"].ToString();
                tbx_tcsm.Text = dt_select.Rows[0]["tcsm"].ToString();
                tbx_mcfxjyrq.Text = dt_select.Rows[0]["mcfxjyrq"].ToString();
                ddlt_mcfxjyjg.SelectedValue = dt_select.Rows[0]["mcfxjyjg"].ToString();
                tbx_mcfxjyjgsm.Text = dt_select.Rows[0]["mcfxjysm"].ToString();
                tbx_ddzbbjjd.Text = dt_select.Rows[0]["ddzb_bj_jd"].ToString();
                tbx_ddzbbjwd.Text = dt_select.Rows[0]["ddzb_bj_wd"].ToString();
                tbx_ddzbwgsjd.Text = dt_select.Rows[0]["ddzb_wgs_jd"].ToString();
                tbx_ddzbwgswd.Text = dt_select.Rows[0]["ddzb_wgs_wd"].ToString();
                tbx_sl.Text = dt_select.Rows[0]["sl"].ToString();
                tbx_mcfxjyrq.Text = dt_select.Rows[0]["mcfxjyrq"].ToString();
                tbx_scgl.Text = dt_select.Rows[0]["scgl"].ToString();
                ddlt_scgldw.SelectedValue = dt_select.Rows[0]["scgldw"].ToString();
                tbx_sbccbh.Text = dt_select.Rows[0]["sbccbh"].ToString();
                tbx_fgfw.Text = dt_select.Rows[0]["fgfw"].ToString();
                ddlt_fgfwdw.SelectedValue = dt_select.Rows[0]["fgfwdw"].ToString();
                ddlt_sbzt.SelectedValue = dt_select.Rows[0]["sbzt"].ToString();
                tbx_jpdzxjl.Text = dt_select.Rows[0]["jpdzxjl"].ToString();
                tbx_pdcd.Text = dt_select.Rows[0]["pdcd"].ToString();
                tbx_synx.Text = dt_select.Rows[0]["synx"].ToString();
                tbx_jlgd.Text = dt_select.Rows[0]["jlgd"].ToString();
                tbx_jlgddx.Text = dt_select.Rows[0]["jlgddx"].ToString();
                tbx_jlgdsl.Text = dt_select.Rows[0]["jlgdsl"].ToString();
                tbx_zlgd.Text = dt_select.Rows[0]["zlgd"].ToString();
                tbx_zlgddx.Text = dt_select.Rows[0]["zlgddx"].ToString();
                tbx_zlgdsl.Text = dt_select.Rows[0]["zlgdsl"].ToString();
                tbx_sbcsqk.Text = dt_select.Rows[0]["sbcsqk"].ToString();
                ddlt_xssjc.SelectedValue = dt_select.Rows[0]["xssjc"].ToString();
                tbx_dbsj.Text = dt_select.Rows[0]["dbsj"].ToString();
                tbx_sbbgr.Text = dt_select.Rows[0]["sbbgr"].ToString();

                //地面设备
                tbx_dmsbtxlx.Text = dt_select.Rows[0]["wxdhdmsb_txlx"].ToString();
                //航向设备
                ddlt_hxsblb.SelectedValue = dt_select.Rows[0]["hxsb_lb"].ToString();
                tbx_hxsbpdh.Text = dt_select.Rows[0]["hxsb_pdh"].ToString();
                tbx_hxsbtxzxh.Text = dt_select.Rows[0]["hxsb_txzxh"].ToString();
                ddlt_hxsbtxzlx.SelectedValue = dt_select.Rows[0]["hxsb_txzlx"].ToString();
                tbx_hxsbtxzzs.Text = dt_select.Rows[0]["hxsb_txzzs"].ToString();
                tbx_hxsbjpdmdjl.Text = dt_select.Rows[0]["hxsb_txzjpdmdjl"].ToString();
                tbx_hxsbjpdrkjl.Text = dt_select.Rows[0]["hxsb_txzjpdrkdjl"].ToString();
                tbx_hxsbpdzxczjl.Text = dt_select.Rows[0]["HXSB_TXZJPDZXCZJL"].ToString();
                //下滑设备
                tbx_sjxhj.Text = dt_select.Rows[0]["xhsb_sjxhj"].ToString();
                tbx_sjrkgd.Text = dt_select.Rows[0]["xhsb_sjrkgd"].ToString();
                ddlt_xhtxzlx.SelectedValue = dt_select.Rows[0]["xhsb_txzlx"].ToString();
                tbx_xhtxzxh.Text = dt_select.Rows[0]["xhsb_txzxh"].ToString();
                tbx_tcxtxgd.Text = dt_select.Rows[0]["XHSB_TCXTXGD"].ToString();
                tbx_mqxtxgd.Text = dt_select.Rows[0]["xhsb_mqxtxgd"].ToString();
                tbx_tcstxgd.Text = dt_select.Rows[0]["XHSB_TCSTXGD"].ToString();
                tbx_mqstxgd.Text = dt_select.Rows[0]["xhsb_mqstxgd"].ToString();
                tbx_txtgd.Text = dt_select.Rows[0]["xhsb_txtgd"].ToString();
                tbx_pdrkncjl.Text = dt_select.Rows[0]["xhsb_jpdrkncjl"].ToString();
                tbx_pdzcxcj.Text = dt_select.Rows[0]["xhsb_jpdzxcj"].ToString();
                tbx_wypdzxx.Text = dt_select.Rows[0]["xhsb_wypdzxx"].ToString();
                tbx_mjjzgrdh.Text = dt_select.Rows[0]["xhsb_mjjzgrdh"].ToString();
                //测距仪
                tbx_cjycpc.Text = dt_select.Rows[0]["cjy_cpc"].ToString();
                tbx_cjypdh.Text = dt_select.Rows[0]["cjy_pdh"].ToString();
                tbx_cjydj.Text = dt_select.Rows[0]["cjy_dj"].ToString();
                tbx_bdh.Text = dt_select.Rows[0]["cjy_bdh"].ToString();
                ddlt_cjyptsb.SelectedValue = dt_select.Rows[0]["cjy_ptsb"].ToString();
                tbx_cjyjspl.Text = dt_select.Rows[0]["cjy_jspl"].ToString();
                tbx_cjyxtyc.Text = dt_select.Rows[0]["cjy_xtyc"].ToString();
                tbx_cjymcjg.Text = dt_select.Rows[0]["cjy_mcjg"].ToString();
                //全向信标
                tbx_qxxbcpc.Text = dt_select.Rows[0]["qxxb_cpc"].ToString();
                tbx_qxxbdwgd.Text = dt_select.Rows[0]["qxxb_dwgd"].ToString();
                tbx_qxxbjkqfw.Text = dt_select.Rows[0]["qxxb_jkqfw"].ToString();
                tbx_qxxbdwzj.Text = dt_select.Rows[0]["qxxb_dwzj"].ToString();
                ddlt_qxxbdwlx.SelectedValue = dt_select.Rows[0]["qxxb_dwlx"].ToString();
                tbx_qxxbpdh.Text = dt_select.Rows[0]["qxxb_pdh"].ToString();
                tbx_qxxbdj.Text = dt_select.Rows[0]["qxxb_dj"].ToString();
                //无方向信标
                tbx_wfxxbcpc.Text = dt_select.Rows[0]["wfxxb_cpc"].ToString();
                tbx_wfxxbdwgd.Text = dt_select.Rows[0]["wfxxb_dwgd"].ToString();
                tbx_wfxxbjkqfw.Text = dt_select.Rows[0]["wfxxb_jkqfw"].ToString();
                tbx_wfxxbdwzj.Text = dt_select.Rows[0]["wfxxb_dwzj"].ToString();
                ddlt_wfxxbdwlx.SelectedValue = dt_select.Rows[0]["wfxxb_dwlx"].ToString();
                tbx_wfxxbpdh.Text = dt_select.Rows[0]["wfxxb_pdh"].ToString();
                tbx_wfxxbdj.Text = dt_select.Rows[0]["wfxxb_dj"].ToString();
                //指点信标
                tbx_zdxbpdh.Text = dt_select.Rows[0]["zdxb_pdh"].ToString();
                tbx_zdxbdj.Text = dt_select.Rows[0]["zdxb_dj"].ToString();
                ddlt_zdxblxxz.SelectedValue = dt_select.Rows[0]["zdxb_lxxz"].ToString();
                ddlt_csr.SelectedValue = dt_select.Rows[0]["csr"].ToString();
                ddlt_zsr.SelectedValue = dt_select.Rows[0]["zsr"].ToString();
                ddlt_sjszbm.SelectedValue = dt_select.Rows[0]["bmdm"].ToString();
                //状态信息

                tbx_wxdsbfshzzbh.Text = dt_select.Rows[0]["wxdsbfshzzj"].ToString();
                tbx_mcjfbgbh.Text = dt_select.Rows[0]["mcjfbg"].ToString();
                tbx_pvhhwnbh.Text = dt_select.Rows[0]["plhhwj"].ToString();
                tbx_sbxkzbh.Text = dt_select.Rows[0]["sbxkz"].ToString();
                tbx_tzpfwjbh.Text = dt_select.Rows[0]["tzpfwj"].ToString();
                tbx_bhq.Text = dt_select.Rows[0]["bhqfw"].ToString();
                tbx_sbcj.Text = dt_select.Rows[0]["sbcj"].ToString();
                tbx_sbflsz.Text = dt_select.Rows[0]["SBFLPZ"].ToString();
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_dhsb.p_scwjsjc = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo); 
            //判断是否有该路径  
            string path = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + struct_dhsb.p_scwjsjc+"/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            #region 校验
            int flag = 0;
            #region 公共字段
            string sj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";


            //机场
            if (ddlt_jc.SelectedValue == "-1")
            {
                lbl_jc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //设备编号
            if (tbx_sbbh.Text == "")
            {
                lbl_sbbh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            //设备型号
            if (tbx_sbxh.Text == "")
            {
                lbl_sbxh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //台站名称种类
            if (ddlt_tzmczl.SelectedValue == "-1" )
            {
                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            
            //频率
            if (tbx_pl.Text == "" || ddlt_pldw.SelectedValue == "-1")
            {
                lbl_pl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_pl.Text, @"^[0-9]*$"))
            {
                lbl_pl.Text = "<span style=\"color:#ff0000\">" + "只能输入数字" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_pl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //呼号
            if (tbx_hh.Text == "")
            {
                lbl_hh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_hh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //天线中心地面高程
            if (tbx_txzxdmgc.Text == "")
            {
                lbl_txzxdmgc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_txzxdmgc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //天线
            if (tbx_tx.Text == "")
            {
                lbl_tx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_tx.Text, @"^[0-9]*$"))
            {
                lbl_tx.Text = "<span style=\"color:#ff0000\">" + "只能输入数字" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_tx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //校飞周期
            if (tbx_jfzq.Text == "")
            {
                lbl_jfzq.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jfzq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //校飞到期日期 
            if (tbx_jfdqrq.Text == "")
            {
                lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_jfdqrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //投产开放时间
            if (tbx_tckfsj.Text == "")
            {
                lbl_tckfsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_tckfsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tckfsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //投产校飞时间
            if (tbx_tcjfsj.Text == "")
            {
                lbl_tcjfsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_tcjfsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tcjfsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //投产是否限用
            if (ddlt_tcxy.SelectedValue == "-1")
            {
                lbl_tcxy.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tcxy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //末次飞行校验日期
            if (tbx_mcfxjyrq.Text == "")
            {
                lbl_mcfxjyrq.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_mcfxjyrq.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_mcfxjyrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //末次飞行校验结果
            if (ddlt_mcfxjyjg.SelectedValue == "-1")
            {
                lbl_mcfxjyjg.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_mcfxjyjg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //原所属机场
            if (ddlt_yssjc.SelectedValue == "-1")
            {
                lbl_yssjc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_yssjc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（北京54）精度
            if (tbx_ddzbbjjd.Text == "")
            {
                lbl_ddzbbjjd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbbjjd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（北京54）纬度
            if (tbx_ddzbbjwd.Text == "")
            {
                lbl_ddzbbjwd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbbjwd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（wgs84）经度
            if (tbx_ddzbwgsjd.Text == "")
            {
                lbl_ddzbwgsjd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbwgsjd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（wgs84）纬度
            if (tbx_ddzbwgswd.Text == "")
            {
                lbl_ddzbwgswd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbwgswd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备厂家
            if (tbx_sbcj.Text == "")
            {
                lbl_sbcj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbcj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //输出功率
            if (tbx_scgl.Text == "" || ddlt_scgldw.SelectedValue == "-1")
            {
                lbl_scgl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_scgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备出厂编号
            if (tbx_sbccbh.Text == "")
            {
                lbl_sbccbh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbccbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //覆盖范围
            if (tbx_fgfw.Text == "" || ddlt_fgfwdw.SelectedValue == "-1")
            {
                lbl_fgfw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_fgfw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备状态
            if (ddlt_sbzt.SelectedValue == "-1")
            {
                lbl_sbzt.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbzt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电
            if (tbx_jlgd.Text == "")
            {
                lbl_jlgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jlgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电大小
            if (tbx_jlgddx.Text == "")
            {
                lbl_jlgddx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jlgddx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电数量
            if (tbx_jlgdsl.Text == "")
            {
                lbl_jlgdsl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jlgdsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电
            if (tbx_zlgd.Text == "")
            {
                lbl_zlgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_zlgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电数量
            if (tbx_zlgdsl.Text == "")
            {
                lbl_zlgdsl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_zlgdsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电大小
            if (tbx_zlgddx.Text == "")
            {
                lbl_zlgddx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_zlgddx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电大小
            if (tbx_sbcsqk.Text == "")
            {
                lbl_sbcsqk.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbcsqk.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备方蕾配置
            if (tbx_sbflsz.Text == "")
            {
                lbl_sbflsz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbflsz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            #endregion

            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4,4) == "0202")
            {
                #region 航向设备
                //类别
                if (ddlt_hxsblb.SelectedValue == "-1")
                {
                    lbl_hxsblb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsblb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //跑道号
                if (tbx_hxsbpdh.Text == "")
                {
                    lbl_hxsblb.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsblb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                //天线阵类型
                if (ddlt_hxsbtxzlx.SelectedValue == "-1")
                {
                    lbl_hxsbtxzlx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbtxzlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵子书
                if (tbx_hxsbtxzzs.Text == "")
                {
                    lbl_hxsbtxzzs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbtxzzs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵距跑道末端距离
                if (tbx_hxsbjpdmdjl.Text == "")
                {
                    lbl_hxsbjpdmdjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbjpdmdjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵距跑道入口距离
                if (tbx_hxsbjpdrkjl.Text == "")
                {
                    lbl_hxsbjpdrkjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbjpdrkjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵距跑道中心垂直距离
                if (tbx_hxsbpdzxczjl.Text == "")
                {
                    lbl_hxsbpdzxczjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbpdzxczjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion 航向设备
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0203")
            {
                #region 下滑设备

                //设计下滑角
                if (tbx_sjxhj.Text == "")
                {
                    lbl_sjxhj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_sjxhj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //设计入口高度
                if (tbx_sjrkgd.Text == "")
                {
                    lbl_sjrkgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_sjrkgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵类型
                if (ddlt_xhtxzlx.SelectedValue == "-1")
                {
                    lbl_xhtxzlx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_xhtxzlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //投产下天线高度
                if (tbx_tcxtxgd.Text == "")
                {
                    lbl_tcxtxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_tcxtxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //投产上天线高度
                if (tbx_tcstxgd.Text == "")
                {
                    lbl_tcstxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_tcstxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //目前下天线高度
                if (tbx_mqxtxgd.Text == "")
                {
                    lbl_mqxtxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_mqxtxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //目前上天线高度
                if (tbx_mqstxgd.Text == "")
                {
                    lbl_mqstxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_mqstxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线塔高度
                if (tbx_txtgd.Text == "")
                {
                    lbl_txtgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_txtgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //距跑道入口内撤距离
                if (tbx_pdrkncjl.Text == "")
                {
                    lbl_pdrkncjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_pdrkncjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //距跑道中线垂距
                if (tbx_pdzcxcj.Text == "")
                {
                    lbl_pdzcxcj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_pdzcxcj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //位于跑道中心线
                if (tbx_wypdzxx.Text == "")
                {
                    lbl_wypdzxx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_wypdzxx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //盲降基准高RDH
                if (tbx_mjjzgrdh.Text == "")
                {
                    lbl_mjjzgrdh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_mjjzgrdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0204")
            {
                #region 测距仪（DME）

                //波道号
                if (tbx_bdh.Text == "")
                {
                    lbl_bdh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_bdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //配套设备
                if (ddlt_cjyptsb.SelectedValue == "-1")
                {
                    lbl_cjyptsb.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjyptsb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //接收频率
                if (tbx_cjyjspl.Text == "")
                {
                    lbl_cjyjspl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjyjspl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //系统延迟
                if (tbx_cjyxtyc.Text == "")
                {
                    lbl_cjyxtyc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjyxtyc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //脉冲间隔
                if (tbx_cjymcjg.Text == "")
                {
                    lbl_cjymcjg.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjymcjg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0205")
            {
                #region 全向信标
                //磁偏差
                if (tbx_qxxbcpc.Text == "")
                {
                    lbl_qxxbcpc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbcpc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //地网高度
                if (tbx_qxxbdwgd.Text == "")
                {
                    lbl_qxxbdwgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbdwgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //监控器方位
                if (tbx_qxxbjkqfw.Text == "")
                {
                    lbl_qxxbjkqfw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbjkqfw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //地网直径
                if (tbx_qxxbdwzj.Text == "")
                {
                    lbl_qxxbdwzj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbdwzj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //地网类型
                if (ddlt_qxxbdwlx.SelectedValue == "-1")
                {
                    lbl_qxxbdwlx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbdwlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0207")
            {
                #region 指点信标
                //跑道号
                if (tbx_zdxbpdh.Text == "")
                {
                    lbl_zdxbpdh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zdxbpdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //端距
                if (tbx_zdxbdj.Text == "")
                {
                    lbl_zdxbdj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zdxbdj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //类型选择
                if (ddlt_cjyptsb.SelectedValue == "-1")
                {
                    ddlt_zdxblxxz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_zdxblxxz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }

            #region 权限相关
            //数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjssbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjssbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            #endregion

            #region 上传文件
            //无线电设备发射核准证件
            int flag1 = 0;
            if (FileUpload_wxd.FileName == "")
            {
             
                flag = 1;
                flag1 = 1;
            }
            lbl_wxdsbfshzzsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //末次校飞报告
            if (FileUpload_mcjf.FileName == "")
            {
            
                flag = 1;
                flag1 = 1;
            }
            lbl_mcjfbgsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //频率呼号文件
            if (FileUpload_plhh.FileName == "")
            {
            
                flag = 1;
                flag1 = 1;
            }
            lbl_pvhhwjsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //设备许可证
            if (FileUpload_sbxk.FileName == "")
            {
            
                flag = 1;
                flag1 = 1;
            }
            lbl_sbxkzsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //台址批复文件
            if (FileUpload_tzpf.FileName == "")
            {
            
                flag = 1;
                flag1 = 1;
            }
            lbl_tzpfwjsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //保护区范围
            if (FileUpload_bhq.FileName == "")
            {
                
                flag = 1;
                flag1 = 1;
            }
            lbl_bhqfw.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            if (flag1 == 0)
            {
                string wjpd = FileUpload_wxd.FileName + "," + FileUpload_mcjf.FileName + "," + FileUpload_plhh.FileName + "," + FileUpload_sbxk.FileName + "," + FileUpload_tzpf.FileName + "," + FileUpload_bhq.FileName;
                string[] str = wjpd.Split(',');
                if (str.Distinct().Count() < 6)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"上传文件名不可重复，请重新上传！\")</script>");
                    flag = 1;
                }
            }
            #endregion

            if (flag == 1)
            { return; }
            #endregion


            #region 文件上传
            if(FileUpload_wxd.HasFile && FileUpload_mcjf.HasFile && FileUpload_plhh.HasFile && FileUpload_sbxk.HasFile && FileUpload_tzpf.HasFile && FileUpload_bhq.HasFile)
            {
                //对上传文件的大小进行检测，限定文件最大不超过10M
                if(FileUpload_wxd.PostedFile.ContentLength < 10240000 && FileUpload_mcjf.PostedFile.ContentLength < 10240000 && FileUpload_plhh.PostedFile.ContentLength < 10240000 && FileUpload_sbxk.PostedFile.ContentLength < 10240000 && FileUpload_tzpf.PostedFile.ContentLength < 10240000 && FileUpload_bhq.PostedFile.ContentLength < 10240000)
                {

                    string id = Request.Params["id"].ToString();

                    struct_dhsb.p_sbbh = tbx_sbbh.Text.ToString();
                    struct_dhsb.p_sbxh = tbx_sbxh.Text.ToString();
                    struct_dhsb.p_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
                    struct_dhsb.p_tzmczl_tzmc = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
                    struct_dhsb.p_tzmczl_wz = ddlt_tzmczl.SelectedValue.ToString().Substring(2, 2);
                    struct_dhsb.p_tzmczl_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
                    struct_dhsb.p_yssjc = ddlt_yssjc.SelectedValue.ToString();
                    struct_dhsb.p_pl = tbx_pl.Text.ToString();
                    struct_dhsb.p_pldw = ddlt_pldw.SelectedValue.ToString();
                    struct_dhsb.p_hh = tbx_hh.Text.ToString();
                    struct_dhsb.p_txzxdmgc = tbx_txzxdmgc.Text.ToString();
                    struct_dhsb.p_tx = tbx_tx.Text.ToString();
                    struct_dhsb.p_jfzq = tbx_jfzq.Text.ToString().Trim();
                    struct_dhsb.p_jfdqrq = tbx_jfdqrq.Text.ToString().Trim();
                    struct_dhsb.p_tckfsj = tbx_tckfsj.Text.ToString().Trim();
                    struct_dhsb.p_tcjfsj = tbx_tcjfsj.Text.ToString().Trim();
                    struct_dhsb.p_tcsfxy = ddlt_tcxy.SelectedValue.ToString();
                    struct_dhsb.p_tcsm = tbx_tcsm.Text.ToString();
                    struct_dhsb.p_mcfxjyrq = tbx_mcfxjyrq.Text.ToString();
                    struct_dhsb.p_mcfxjyjg = ddlt_mcfxjyjg.SelectedValue.ToString();
                    struct_dhsb.p_mcfxjysm = tbx_mcfxjyjgsm.Text.ToString();
                    struct_dhsb.p_ddzbbjjd = tbx_ddzbbjjd.Text.ToString().Trim();
                    struct_dhsb.p_ddzbbjwd = tbx_ddzbbjwd.Text.ToString().Trim();
                    struct_dhsb.p_ddzbwgsjd = tbx_ddzbwgsjd.Text.ToString().Trim();
                    struct_dhsb.p_ddzbwgswd = tbx_ddzbwgswd.Text.ToString().Trim();
                    struct_dhsb.p_sl = tbx_sl.Text.ToString().Trim();
                    struct_dhsb.p_sbcj = tbx_sbcj.Text.ToString();
                    struct_dhsb.p_scgl = tbx_scgl.Text.ToString();
                    struct_dhsb.p_scgldw = ddlt_scgldw.SelectedValue.ToString();
                    struct_dhsb.p_sbccbh = tbx_sbccbh.Text.ToString();
                    struct_dhsb.p_fgfw = tbx_fgfw.Text.ToString();
                    struct_dhsb.p_fgfwdw = ddlt_fgfwdw.Text.ToString();
                    struct_dhsb.p_sbzt = ddlt_sbzt.SelectedValue.ToString();
                    struct_dhsb.p_jpdzxjl = tbx_jpdzxjl.Text.ToString();
                    struct_dhsb.p_pdcd = tbx_pdcd.Text.ToString();
                    struct_dhsb.p_synx = tbx_synx.Text.ToString();
                    struct_dhsb.p_jlgd = tbx_jlgd.Text.ToString();
                    struct_dhsb.p_jlgddx = tbx_jlgddx.Text.ToString();
                    struct_dhsb.p_jlgdsl = tbx_jlgdsl.Text.ToString();
                    struct_dhsb.p_zlgd = tbx_zlgd.Text.ToString();
                    struct_dhsb.p_zlgddx = tbx_zlgddx.Text.ToString();
                    struct_dhsb.p_zlgdsl = tbx_zlgdsl.Text.ToString();
                    struct_dhsb.p_sbcsqk = tbx_sbcsqk.Text.ToString();
                    struct_dhsb.p_sbflpz = tbx_sbflsz.Text.ToString();
                    struct_dhsb.p_xssjc = ddlt_xssjc.SelectedValue.ToString();
                    struct_dhsb.p_dbsj = tbx_dbsj.Text.ToString();
                    struct_dhsb.p_sbbgr = tbx_sbbgr.Text.ToString();
                    //地面设备
                    struct_dhsb.p_dmsbtxlx = tbx_dmsbtxlx.Text.ToString();
                    //航向设备
                    struct_dhsb.p_hxsblb = ddlt_hxsblb.SelectedValue.ToString();
                    struct_dhsb.p_hxsbpdh = tbx_hxsbpdh.Text.ToString();
                    struct_dhsb.p_hxsbtxzxh = tbx_hxsbtxzxh.Text.ToString();
                    struct_dhsb.p_hxsbtxzlx = ddlt_hxsbtxzlx.SelectedValue.ToString();
                    struct_dhsb.p_hxsbtxzzs = tbx_hxsbtxzzs.Text.ToString();
                    struct_dhsb.p_hxsbjpdmdjl = tbx_hxsbjpdmdjl.Text.ToString();
                    struct_dhsb.p_hxsbjpdrkjl = tbx_hxsbjpdrkjl.Text.ToString();
                    struct_dhsb.p_hxsbzxczjl = tbx_hxsbpdzxczjl.Text.ToString();
                    //下滑设备
                    struct_dhsb.p_xhsbsjxhj = tbx_sjxhj.Text.ToString();
                    struct_dhsb.p_xhsbsjrkgd = tbx_sjrkgd.Text.ToString();
                    struct_dhsb.p_xhsbtxzlx = ddlt_xhtxzlx.SelectedValue.ToString();
                    struct_dhsb.p_xhsbtxzxh = tbx_xhtxzxh.Text.ToString();
                    struct_dhsb.p_xhsbtcxtxgd = tbx_tcxtxgd.Text.ToString();
                    struct_dhsb.p_xhsbmqxtxgd = tbx_mqxtxgd.Text.ToString();
                    struct_dhsb.p_xhsbtcstxgd = tbx_tcstxgd.Text.ToString();
                    struct_dhsb.p_xhsbmqstxgd = tbx_mqstxgd.Text.ToString();
                    struct_dhsb.p_xhsbtxtgd = tbx_txtgd.Text.ToString();
                    struct_dhsb.p_xhsbjpdrkncjl = tbx_pdrkncjl.Text.ToString();
                    struct_dhsb.p_xhsbjpdzxcj = tbx_pdzcxcj.Text.ToString();
                    struct_dhsb.p_xhsbwypdzxx = tbx_wypdzxx.Text.ToString();
                    struct_dhsb.p_xhsbmjjzgrdh = tbx_mjjzgrdh.Text.ToString();
                    //测距仪
                    struct_dhsb.p_cjycpc = tbx_cjycpc.Text.ToString();
                    struct_dhsb.p_cjypdh = tbx_cjypdh.Text.ToString();
                    struct_dhsb.p_cjydj = tbx_cjydj.Text.ToString();
                    struct_dhsb.p_cjybdh = tbx_bdh.Text.ToString();
                    struct_dhsb.p_cjyptsb = ddlt_cjyptsb.SelectedValue.ToString();
                    struct_dhsb.p_cjyjspl = tbx_cjyjspl.Text.ToString();
                    struct_dhsb.p_cjyxtyc = tbx_cjyxtyc.Text.ToString();
                    struct_dhsb.p_cjymcjg = tbx_cjymcjg.Text.ToString();
                    //全向信标
                    struct_dhsb.p_qxxbcpc = tbx_qxxbcpc.Text.ToString();
                    struct_dhsb.p_qxxbdwgd = tbx_qxxbdwgd.Text.ToString();
                    struct_dhsb.p_qxxbjkqfw = tbx_qxxbjkqfw.Text.ToString();
                    struct_dhsb.p_qxxbdwzj = tbx_qxxbdwzj.Text.ToString();
                    struct_dhsb.p_qxxbdwlx = ddlt_qxxbdwlx.SelectedValue.ToString();//!LXLL
                    struct_dhsb.p_qxxbpdh = tbx_qxxbpdh.Text.ToString();
                    struct_dhsb.p_qxxbdj = tbx_qxxbdj.Text.ToString();
                    //无方向信标
                    struct_dhsb.p_wfxxbcpc = tbx_wfxxbcpc.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbdwgd = tbx_wfxxbdwgd.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbjkqfw = tbx_wfxxbjkqfw.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbdwzj = tbx_wfxxbdwzj.Text.ToString();//FFFXZZZJ
                    struct_dhsb.p_wfxxbdwlx = ddlt_wfxxbdwlx.SelectedValue.ToString();//FFFX
                    struct_dhsb.p_wfxxbpdh = tbx_wfxxbpdh.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbdj = tbx_wfxxbdj.Text.ToString();//FFFX
                    //指点信标
                    struct_dhsb.p_zdxbpdh = tbx_zdxbpdh.Text.ToString();
                    struct_dhsb.p_zdxbdj = tbx_zdxbdj.Text.ToString();
                    struct_dhsb.p_zdxblxxz = ddlt_zdxblxxz.SelectedValue.ToString();

                    System.DateTime now = System.DateTime.Now;
                    struct_dhsb.p_xtsj = now;

                    struct_dhsb.p_wxdlj = path;
                    struct_dhsb.p_mcjflj = path;
                    struct_dhsb.p_plhhlj = path;
                    struct_dhsb.p_sbxkzlj = path;
                    struct_dhsb.p_tzpflj = path;
                    struct_dhsb.p_bhqlj = path;
                    struct_dhsb.p_scip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
                    struct_dhsb.p_wxdsbfshzzj = FileUpload_wxd.FileName;
                    struct_dhsb.p_mcjfbg = FileUpload_mcjf.FileName;
                    struct_dhsb.p_plhhwj = FileUpload_plhh.FileName;
                    struct_dhsb.p_sbxkz = FileUpload_sbxk.FileName;
                    struct_dhsb.p_tzpfwj = FileUpload_tzpf.FileName;
                    struct_dhsb.p_bhqfw = FileUpload_bhq.FileName;
                    struct_dhsb.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                    struct_dhsb.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                    struct_dhsb.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                    struct_dhsb.p_lrr = _usState.userLoginName.ToString();//录入人

                    struct_dhsb.p_id = Convert.ToInt32(id);


                    //struct_YGJL.p_sjbs = "0";
                    //如果是初审人录入数据，则状态默认初审通过，即待终审
                    if (struct_dhsb.p_lrr.Equals(struct_dhsb.p_csr))
                    {
                        struct_dhsb.p_sjbs = "0";
                        struct_dhsb.p_zt = "2";
                    }
                    //如果是终审人录入数据，则状态为审核通过
                    if (struct_dhsb.p_lrr.Equals(struct_dhsb.p_zsr))
                    {
                        struct_dhsb.p_sjbs = "1";
                        struct_dhsb.p_zt = "3";
                    }
                    if (!struct_dhsb.p_lrr.Equals(struct_dhsb.p_csr) && !struct_dhsb.p_lrr.Equals(struct_dhsb.p_zsr))
                    {
                        struct_dhsb.p_sjbs = "0";
                        struct_dhsb.p_zt = "0";
                    }
                    struct_dhsb.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
                    string czxx = "位置：设备管理->导航设备管理->编辑   设备编号：" + struct_dhsb.p_sbbh;

                    struct_dhsb.p_czfs = "03";
                    struct_dhsb.p_czxx = "czxx";

                    
                    //上传文件
                    FileUpload_wxd.PostedFile.SaveAs(path + FileUpload_wxd.FileName);
                    FileUpload_mcjf.PostedFile.SaveAs(path + FileUpload_mcjf.FileName);
                    FileUpload_plhh.PostedFile.SaveAs(path + FileUpload_plhh.FileName);
                    FileUpload_sbxk.PostedFile.SaveAs(path + FileUpload_sbxk.FileName);
                    FileUpload_tzpf.PostedFile.SaveAs(path + FileUpload_tzpf.FileName);
                    FileUpload_bhq.PostedFile.SaveAs(path + FileUpload_bhq.FileName);
                    
                    
                    //存入数据库
                    dhsb.Update_DHSB(struct_dhsb);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");

                    Response.Redirect("../SheBei/DHSB_GL.aspx");
                }
            }
           
            #endregion
 
        }       
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/DHSB_GL.aspx");
        }

        //重命名
        private string MakeFileName(string biaoshi, string exeFileString)
        {
            System.DateTime now = System.DateTime.Now;
            struct_dhsb.p_xtsj = now;
            date_update = now.ToString();
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            string yearString = year.ToString();
            string monthString = month < 10 ? ("0" + month) : month.ToString();
            string dayString = day < 10 ? ("0" + day) : day.ToString();
            string hourString = hour < 10 ? ("0" + hour) : hour.ToString();
            string minuteString = minute < 10 ? ("0" + minute) : minute.ToString();
            string secondString = second < 10 ? ("0" + second) : second.ToString();

            string fileName = yearString + monthString + dayString + hourString + minuteString + secondString + biaoshi + exeFileString;
            return fileName;
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