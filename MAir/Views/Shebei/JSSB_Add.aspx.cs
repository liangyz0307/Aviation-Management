﻿using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CUST;
using CUST.Tools;
using Sys;
using System.Globalization;

namespace CUST.WKG
{
    public partial class JSSB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private JSSB jssb;
        private Struct_JSSB struct_jssb;
        private int utils;
        public bool flag = true;
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["Userstate"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            jssb = new JSSB(_usState);
            struct_jssb = new Struct_JSSB();
            #region 判断日期控件是否输入正确，是否使用设备类型中的div
            if (!IsPostBack)
            {
                tbx_dtzzdqsj.Attributes.Add("readonly", "readonly");
                tbx_jgrq.Attributes.Add("readonly", "readonly");
                tbx_tcjyrq.Attributes.Add("readonly", "readonly");
                tbx_tckfhbarq.Attributes.Add("readonly", "readonly");
                tbx_wxdtzzyxq1.Attributes.Add("readonly", "readonly");
                tbx_wxdtzzyxq2.Attributes.Add("readonly", "readonly");
                tbx_zdxgjsxtsb_wxdtzzyxq.Attributes.Add("readonly", "readonly");
                tbx_dddwxt_wxdtzzyxq.Attributes.Add("readonly", "readonly");
                div_yjld.Style.Add("display", "none");
                div_ejld.Style.Add("display", "none");
                div_cmjssb.Style.Add("display", "none");
                div_zdxgjsxtsb.Style.Add("display", "none");
                div_dddwxt.Style.Add("display", "none");
                div_zdhxt.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                ddltBind();
            }
            #endregion

            string sjjd = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo);
            int lss = Convert.ToInt32(jssb.Select_SB_MaxNumber(sjjd));
            if (lss >= 99999)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"数据超出，请联系管理员整理数据！\")</script>");
                Response.Redirect("../SheBei/TXSB_GL.aspx");
            }
            tbx_sbbh.Text = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo) + "04" + Convert.ToString(lss + 1).PadLeft(5, '0');
        }
        #region 绑定下拉框
        private void ddltBind()
        {
            ////绑定设备类型
            //ddlt_sblx.DataTextField = "mc";
            //ddlt_sblx.DataValueField = "bm";
            //ddlt_sblx.DataSource = SysData.SBLX("03").Copy();
            //ddlt_sblx.DataBind();
            //ddlt_sblx.Items.Insert(0, new ListItem("请选择", "-1"));

            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 台站名称
            ddlt_tzmczl.DataTextField = "mc";
            ddlt_tzmczl.DataValueField = "bm";
            ddlt_tzmczl.DataSource = SysData.TZLX_ZH("04").Copy();
            ddlt_tzmczl.DataBind();
            ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));
            //所属支线
            ddlt_sszx.DataTextField = "mc";
            ddlt_sszx.DataValueField = "bm";
            ddlt_sszx.DataSource = SysData.ZXDM().Copy();
            ddlt_sszx.DataBind();
            ddlt_sszx.Items.Insert(0, new ListItem("请选择", "-1"));
            //设备状态
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("请选择", "-1"));
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "141002");
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
            ddlt_zsr.Items.Insert(0, new ListItem("请选择", "-1"));
            //是否配测试信标
            ddlt_zdxgjsxtsb_sfpcsxb.DataTextField = "mc";
            ddlt_zdxgjsxtsb_sfpcsxb.DataValueField = "bm";
            ddlt_zdxgjsxtsb_sfpcsxb.DataSource = SysData.ZXDM().Copy();
            ddlt_zdxgjsxtsb_sfpcsxb.DataBind();
            ddlt_zdxgjsxtsb_sfpcsxb.Items.Insert(0, new ListItem("请选择", "-1"));
            //工作频率
            ddlt_dddwxt_gzpl.DataTextField = "mc";
            ddlt_dddwxt_gzpl.DataValueField = "bm";
            ddlt_dddwxt_gzpl.DataSource = SysData.ZXDM().Copy();
            ddlt_dddwxt_gzpl.DataBind();
            ddlt_dddwxt_gzpl.Items.Insert(0, new ListItem("请选择", "-1"));
            //天线设置地点
            ddlt_dddwxt_txszdd.DataTextField = "mc";
            ddlt_dddwxt_txszdd.DataValueField = "bm";
            ddlt_dddwxt_txszdd.DataSource = SysData.ZXDM().Copy();
            ddlt_dddwxt_txszdd.DataBind();
            ddlt_dddwxt_txszdd.Items.Insert(0, new ListItem("请选择", "-1"));
            //数据所在部门
            ddlt_sjssbm.DataSource = SysData.BM("141002", _usState.userID).Copy();
            ddlt_sjssbm.DataTextField = "bmmc";
            ddlt_sjssbm.DataValueField = "bmdm";
            ddlt_sjssbm.DataBind();
            ddlt_sjssbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        #endregion
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "down")
            {
                try
                {
                    string path = e.CommandArgument.ToString();//路径

                    string fileName = Path.GetFileName(path); //文件名

                    if (File.Exists(path))
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
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
                        Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                        Response.Redirect("../main/JSSB_GL.aspx");
                        Response.End();
                    }
                }
                catch { }

            }
        }
        private string MakeFileName(string biaoshi, string exeFileString)
        {
            System.DateTime now = System.DateTime.Now;
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
        #region 保存按钮
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 判断上传文件是否有我们设计的路径 没有我们自己创建生成
            //判断是否有该路径  
            string path = Server.MapPath("../Shebei/UpLoads/SBGL/JSSB/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            #endregion
                #region lable判断 判断添加的值是否为空 为空的要给提示 24个基本信息的
                int flag = 0;
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
            //设备类型
            //if (ddlt_sblx.SelectedValue == "-1")
            //{
            //    lbl_sblx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sblx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}

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

                //台站
                if (ddlt_tzmczl.SelectedValue == "-1")
            {
                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tzmczl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //投产开放时间
            //所属支线
            if (ddlt_sszx.SelectedValue == "-1")
                {
                    lbl_sszx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sszx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
                //电台执照到期时间
                if (tbx_dtzzdqsj.Text == "")
                {
                    lbl_dtzzdqsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_dtzzdqsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
                //设备生产厂家
                if (tbx_sbsccj.Text == "")
                {
                    lbl_sbsccj.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sbsccj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //设备出厂编号
                if (tbx_sbccbh.Text == "")
                {
                    lbl_sbccbh.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sbccbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //设备许可证上传
                if (!tbx_sc.HasFile)
                {
                    lbl_sc.Text = "<span style=\"color:#ff0000\">" + "请选择上传文件" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sc.Text = "<span style=\"color:#00ff00\">" + "" + "</span>";
                }
                //所属台站
                if (tbx_sstz.Text == "")
                {
                    lbl_sstz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sstz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
                //设备型号
                if (tbx_sbxh.Text == "")
                {
                    lbl_sbxh.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                ////台站名称种类
                //if (tbx_tzmczl.Text == "")
                //{
                //    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                //    flag = 1;
                //}
                //else
                //{
                //    lbl_tzmczl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                //}
                //竣工日期
                if (tbx_jgrq.Text == "")
                {
                    lbl_jgrq.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_jgrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //投产校验日期
                if (tbx_tcjyrq.Text == "")
                {
                    lbl_tcjyrq.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tcjyrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //投产开放或备案日期
                if (tbx_tckfhbarq.Text == "")
                {
                    lbl_tckfhbarq.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tckfhbarq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //主要技术参数填写
                if (tbx_zyjscstx.Text == "")
                {
                    lbl_zyjscstx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zyjscstx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //供电方式
                if (tbx_csfs.Text == "")
                {
                    lbl_csfs.Text = "<span style=\"color:#ff0000\">" + "请选择上传文件" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_csfs.Text = "<span style=\"color:#00ff00\">" + "" + "</span>";
                }
                //传输方式
                if (tbx_csfs.Text == "")
                {
                    lbl_csfs.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_csfs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //大地坐标(北京54)经度
                if (tbx_ddzb_bj54_jd.Text == "")
                {
                    lbl_ddzb_bj54_jd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ddzb_bj54_jd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //大地坐标(北京54)纬度
                if (tbx_ddzb_bj54_wd.Text == "")
                {
                    lbl_ddzb_bj54_wd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ddzb_bj54_wd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //大地坐标（wgs84）经度
                if (tbx_ddzb_wgs84_jd.Text == "")
                {
                    lbl_ddzb_wgs84_jd.Text = "<span style=\"color:#ff0000\">" + "请选择调拨时间" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ddzb_wgs84_jd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //大地坐标（wgs84）纬度
                if (tbx_ddzb_wgs84_wd.Text == "")
                {
                    lbl_ddzb_wgs84_wd.Text = "<span style=\"color:#ff0000\">" + "请选择设备保管人" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ddzb_wgs84_wd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                //初审人
                if (ddlt_csr.SelectedValue == "-1")
                {
                    lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //终审人
                if (ddlt_zsr.SelectedValue == "-1")
                {
                    lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (flag == 1)
                {
                    return;
                }
                //上传文件
                if (!tbx_sc.HasFile)
                {
                    lbl_sc.Text = "请选择上传文件";
                    return;
                }
                if (tbx_sc.PostedFile.ContentLength > 10240000)
                {
                    lbl_sc.Text = "附件大小超出10Ｍ";
                    return;
                }
                #endregion
                #region 基本信息赋值
                //基本信息赋值24个
                struct_jssb.p_sbbh = tbx_sbbh.Text.ToString().Trim();
                struct_jssb.p_sblx =   ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
            struct_jssb.p_wz =  ddlt_tzmczl.SelectedValue.ToString().Substring(2, 2);
            struct_jssb.p_ssjc   = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
            struct_jssb.p_sszx = ddlt_sszx.SelectedValue.ToString().Trim();
                struct_jssb.p_dtzzdqsj = tbx_dtzzdqsj.Text.ToString().Trim();
                struct_jssb.p_sbzt = ddlt_sbzt.SelectedValue.ToString().Trim();
                struct_jssb.p_sbsccj = tbx_sbsccj.Text.ToString().Trim();
                struct_jssb.p_sbccbh = tbx_sbccbh.Text.ToString().Trim();
                //struct_jssb.p_sc = tbx_sc.FileName;
                struct_jssb.p_sstz = tbx_sstz.Text.ToString().Trim();
                struct_jssb.p_sbxh = tbx_sbxh.Text.ToString().Trim();
                //struct_jssb.p_tzmczl = tbx_tzmczl.Text.ToString().Trim();
                struct_jssb.p_jgrq = tbx_jgrq.Text.ToString().Trim();
                struct_jssb.p_tcjyrq = tbx_tcjyrq.Text.ToString().Trim();
                struct_jssb.p_tckfhbarq = tbx_tckfhbarq.Text.ToString().Trim();
                struct_jssb.p_zyjscstx = tbx_zyjscstx.Text.ToString().Trim();
                struct_jssb.p_gdfs = tbx_gdfs.Text.ToString().Trim();
                struct_jssb.p_csfs = tbx_csfs.Text.ToString().Trim();
                struct_jssb.p_ddzb_bj54_jd = tbx_ddzb_bj54_jd.Text.ToString().Trim();
                struct_jssb.p_ddzb_bj54_wd = tbx_ddzb_bj54_wd.Text.ToString().Trim();
                struct_jssb.p_ddzb_wgs84_jd = tbx_ddzb_wgs84_jd.Text.ToString().Trim();
                struct_jssb.p_ddzb_wgs84_wd = tbx_ddzb_wgs84_wd.Text.ToString().Trim();
                #region 判断文件上传路径 没有自动生成
                //上传文件
                //文件上传
                if (!tbx_sc.HasFile)
                {
                    lbl_sc.Text = "请选择上传文件";
                    return;
                }
                if (tbx_sc.PostedFile.ContentLength > 10240000)
                {
                    lbl_sc.Text = "附件大小超出10Ｍ";
                    return;
                }
                struct_jssb.p_sc = tbx_sc.FileName;
                tbx_sc.PostedFile.SaveAs(path + tbx_sc.FileName);
                #endregion
                #region 针对设备类型添加
                if (struct_jssb.p_sblx.Equals("0303") || struct_jssb.p_sblx.Equals("0307"))
                {
                    struct_jssb.p_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
                //一级雷达
                struct_jssb.p_ld_gzpl1 = "";
                struct_jssb.p_ld_csxbxh1 = "";
                struct_jssb.p_ld_fzgl1 = "";
                struct_jssb.p_ld_txszdd1 = "";
                struct_jssb.p_ld_txjcgc1 = "";
                struct_jssb.p_ld_txgd1 = "";
                struct_jssb.p_ld_txsccj1 = "";
                struct_jssb.p_ld_txxh_lx1 = "";
                struct_jssb.p_ld_fgqk1 = "";
                struct_jssb.p_wxdtzzyxq1 = "";
                struct_jssb.p_ld_sc1 = "";
                //二级雷达
                struct_jssb.p_ld_gzpl2 = "";
                struct_jssb.p_ld_csxbxh2 = "";
                struct_jssb.p_ld_fzgl2 = "";
                struct_jssb.p_ld_txszdd2 = "";
                struct_jssb.p_ld_txjcgc2 = "";
                struct_jssb.p_ld_txgd2 = "";
                struct_jssb.p_ld_txsccj2 = "";
                struct_jssb.p_ld_txxh_lx2 = "";
                struct_jssb.p_ld_fgqk2 = "";
                struct_jssb.p_wxdtzzyxq2 = "";
                struct_jssb.p_ld_sc2= "";
                //自动相关监视系统设备
                struct_jssb.p_zdxgjsxtsb_gzpl = "";
                struct_jssb.p_zdxgjsxtsb_sfpcsxb = "";
                struct_jssb.p_zdxgjsxtsb_csxbxh = "";
                struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm = "";
                struct_jssb.p_zdxgjsxtsb_cyzzrs = "";
                struct_jssb.p_zdxgjsxtsb_fzgl = "";
                struct_jssb.p_zdxgjsxtsb_csfs = "";
                struct_jssb.p_zdxgjsxtsb_txszdd = "";
                struct_jssb.p_zdxgjsxtsb_txjcgc = "";
                struct_jssb.p_zdxgjsxtsb_txsccj = "";
                struct_jssb.p_zdxgjsxtsb_txxh_lx = "";
                struct_jssb.p_zdxgjsxtsb_wxdtzzyxq = "";
                struct_jssb.p_zdxgjsxtsb_sc = "";
                //多点定位系统
                struct_jssb.p_dddwxt_gzpl = "";
                struct_jssb.p_dddwxt_fstfzgl = "";
                struct_jssb.p_dddwxt_txszdd = "";
                struct_jssb.p_dddwxt_txjcgc = "";
                struct_jssb.p_dddwxt_txsccj = "";
                struct_jssb.p_dddwxt_txxh_lx = "";
                struct_jssb.p_dddwxt_wxdtzzyxq = "";
                struct_jssb.p_dddwxt_sc = "";
                //自动化系统
                struct_jssb.p_zdhxt_jsyyjxl = "";
                struct_jssb.p_zdhxt_xtrjbb = "";
                struct_jssb.p_zdhxt_xtgm = "";
                struct_jssb.p_zdhxt_ATCgzsqs = "";
                struct_jssb.p_zdhxt_A_SMGCSxtfj = "";
                struct_jssb.p_zdhxt_cyzzrs = "";
            }
            else if (struct_jssb.p_sblx.Equals("0301"))
                {
                    //一级雷达
                    struct_jssb.p_ld_gzpl1 = tbx_ld_gzpl1.Text.ToString().Trim();
                    struct_jssb.p_ld_csxbxh1 = tbx_ld_csxbxh1.Text.ToString().Trim();
                    struct_jssb.p_ld_fzgl1 = tbx_ld_fzgl1.Text.ToString().Trim();
                    struct_jssb.p_ld_txszdd1 = tbx_ld_txszdd1.Text.ToString().Trim();
                    struct_jssb.p_ld_txjcgc1 = tbx_ld_txjcgc1.Text.ToString().Trim();
                    struct_jssb.p_ld_txgd1 = tbx_ld_txgd1.Text.ToString().Trim();
                    struct_jssb.p_ld_txsccj1 = tbx_ld_txsccj1.Text.ToString().Trim();
                    struct_jssb.p_ld_txxh_lx1 = tbx_ld_txxh_lx1.Text.ToString().Trim();
                    struct_jssb.p_ld_fgqk1 = tbx_ld_fgqk1.Text.ToString().Trim();
                    struct_jssb.p_wxdtzzyxq1 = tbx_wxdtzzyxq1.Text.ToString().Trim();
                    //    //上传文件
                    if (!tbx_ld_sc1.HasFile)
                    {
                        lbl_ld_sc1.Text = "请选择上传文件";
                        return;
                    }
                    if (tbx_ld_sc1.PostedFile.ContentLength > 10240000)
                    {
                        lbl_ld_sc1.Text = "附件大小超出10Ｍ";
                        return;
                    }
                    struct_jssb.p_ld_sc1 = tbx_ld_sc1.FileName;
                    tbx_ld_sc1.PostedFile.SaveAs(path + tbx_ld_sc1.FileName);
                //二级雷达
                struct_jssb.p_ld_gzpl2 = "";
                struct_jssb.p_ld_csxbxh2 = "";
                struct_jssb.p_ld_fzgl2 = "";
                struct_jssb.p_ld_txszdd2 = "";
                struct_jssb.p_ld_txjcgc2 = "";
                struct_jssb.p_ld_txgd2 = "";
                struct_jssb.p_ld_txsccj2 = "";
                struct_jssb.p_ld_txxh_lx2 = "";
                struct_jssb.p_ld_fgqk2 = "";
                struct_jssb.p_wxdtzzyxq2 = "";
                struct_jssb.p_ld_sc2 = "";
                //自动相关监视系统设备
                struct_jssb.p_zdxgjsxtsb_gzpl = "";
                struct_jssb.p_zdxgjsxtsb_sfpcsxb = "";
                struct_jssb.p_zdxgjsxtsb_csxbxh = "";
                struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm = "";
                struct_jssb.p_zdxgjsxtsb_cyzzrs = "";
                struct_jssb.p_zdxgjsxtsb_fzgl = "";
                struct_jssb.p_zdxgjsxtsb_csfs = "";
                struct_jssb.p_zdxgjsxtsb_txszdd = "";
                struct_jssb.p_zdxgjsxtsb_txjcgc = "";
                struct_jssb.p_zdxgjsxtsb_txsccj = "";
                struct_jssb.p_zdxgjsxtsb_txxh_lx = "";
                struct_jssb.p_zdxgjsxtsb_wxdtzzyxq = "";
                struct_jssb.p_zdxgjsxtsb_sc = "";
                //多点定位系统
                struct_jssb.p_dddwxt_gzpl = "";
                struct_jssb.p_dddwxt_fstfzgl = "";
                struct_jssb.p_dddwxt_txszdd = "";
                struct_jssb.p_dddwxt_txjcgc = "";
                struct_jssb.p_dddwxt_txsccj = "";
                struct_jssb.p_dddwxt_txxh_lx = "";
                struct_jssb.p_dddwxt_wxdtzzyxq = "";
                struct_jssb.p_dddwxt_sc = "";
                //自动化系统
                struct_jssb.p_zdhxt_jsyyjxl = "";
                struct_jssb.p_zdhxt_xtrjbb = "";
                struct_jssb.p_zdhxt_xtgm = "";
                struct_jssb.p_zdhxt_ATCgzsqs = "";
                struct_jssb.p_zdhxt_A_SMGCSxtfj = "";
                struct_jssb.p_zdhxt_cyzzrs = "";
            }


                else if (struct_jssb.p_sblx.Equals("0302"))
                {
                    //二级雷达
                    struct_jssb.p_ld_gzpl2 = tbx_ld_gzpl2.Text.ToString().Trim();
                    struct_jssb.p_ld_csxbxh2 = tbx_ld_csxbxh2.Text.ToString().Trim();
                    struct_jssb.p_ld_fzgl2 = tbx_ld_fzgl2.Text.ToString().Trim();
                    struct_jssb.p_ld_txszdd2 = tbx_ld_txszdd2.Text.ToString().Trim();
                    struct_jssb.p_ld_txjcgc2 = tbx_ld_txjcgc2.Text.ToString().Trim();
                    struct_jssb.p_ld_txgd2 = tbx_ld_txgd2.Text.ToString().Trim();
                    struct_jssb.p_ld_txsccj2 = tbx_ld_txsccj2.Text.ToString().Trim();
                    struct_jssb.p_ld_txxh_lx2 = tbx_ld_txxh_lx2.Text.ToString().Trim();
                    struct_jssb.p_ld_fgqk2 = tbx_ld_fgqk2.Text.ToString().Trim();
                    struct_jssb.p_wxdtzzyxq2 = tbx_wxdtzzyxq2.Text.ToString().Trim();
                    //上传文件
                    //文件上传
                    if (!tbx_ld_sc2.HasFile)
                    {
                        lbl_ld_sc2.Text = "请选择上传文件";
                        return;
                    }
                    if (tbx_ld_sc2.PostedFile.ContentLength > 10240000)
                    {
                        lbl_ld_sc2.Text = "附件大小超出10Ｍ";
                        return;
                    }
                    struct_jssb.p_ld_sc2 = tbx_ld_sc2.FileName;
                    tbx_ld_sc2.PostedFile.SaveAs(path + tbx_ld_sc2.FileName);
                //一级雷达
                struct_jssb.p_ld_gzpl1 = "";
                struct_jssb.p_ld_csxbxh1 = "";
                struct_jssb.p_ld_fzgl1 = "";
                struct_jssb.p_ld_txszdd1 = "";
                struct_jssb.p_ld_txjcgc1 = "";
                struct_jssb.p_ld_txgd1 = "";
                struct_jssb.p_ld_txsccj1 = "";
                struct_jssb.p_ld_txxh_lx1 = "";
                struct_jssb.p_ld_fgqk1 = "";
                struct_jssb.p_wxdtzzyxq1 = "";
                struct_jssb.p_ld_sc1 = "";
                //自动相关监视系统设备
                struct_jssb.p_zdxgjsxtsb_gzpl = "";
                struct_jssb.p_zdxgjsxtsb_sfpcsxb = "";
                struct_jssb.p_zdxgjsxtsb_csxbxh = "";
                struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm = "";
                struct_jssb.p_zdxgjsxtsb_cyzzrs = "";
                struct_jssb.p_zdxgjsxtsb_fzgl = "";
                struct_jssb.p_zdxgjsxtsb_csfs = "";
                struct_jssb.p_zdxgjsxtsb_txszdd = "";
                struct_jssb.p_zdxgjsxtsb_txjcgc = "";
                struct_jssb.p_zdxgjsxtsb_txsccj = "";
                struct_jssb.p_zdxgjsxtsb_txxh_lx = "";
                struct_jssb.p_zdxgjsxtsb_wxdtzzyxq = "";
                struct_jssb.p_zdxgjsxtsb_sc = "";
                //多点定位系统
                struct_jssb.p_dddwxt_gzpl = "";
                struct_jssb.p_dddwxt_fstfzgl = "";
                struct_jssb.p_dddwxt_txszdd = "";
                struct_jssb.p_dddwxt_txjcgc = "";
                struct_jssb.p_dddwxt_txsccj = "";
                struct_jssb.p_dddwxt_txxh_lx = "";
                struct_jssb.p_dddwxt_wxdtzzyxq = "";
                struct_jssb.p_dddwxt_sc = "";
                //自动化系统
                struct_jssb.p_zdhxt_jsyyjxl = "";
                struct_jssb.p_zdhxt_xtrjbb = "";
                struct_jssb.p_zdhxt_xtgm = "";
                struct_jssb.p_zdhxt_ATCgzsqs = "";
                struct_jssb.p_zdhxt_A_SMGCSxtfj = "";
                struct_jssb.p_zdhxt_cyzzrs = "";
            }
                else if (struct_jssb.p_sblx.Equals("0304"))
                {
                    //自动相关监视系统设备
                    struct_jssb.p_zdxgjsxtsb_gzpl = tbx_zdxgjsxtsb_gzpl.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_sfpcsxb = ddlt_zdxgjsxtsb_sfpcsxb.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_csxbxh = tbx_zdxgjsxtsb_csxbxh.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm = tbx_zdxgjsxtsb_csxbsmsdzdm.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_cyzzrs = tbx_zdxgjsxtsb_cyzzrs.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_fzgl = tbx_zdxgjsxtsb_fzgl.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_csfs = tbx_zdxgjsxtsb_csfs.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_txszdd = tbx_zdxgjsxtsb_txszdd.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_txjcgc = tbx_zdxgjsxtsb_txjcgc.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_txsccj = tbx_zdxgjsxtsb_txsccj.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_txxh_lx = tbx_zdxgjsxtsb_txxh_lx.Text.ToString().Trim();
                    struct_jssb.p_zdxgjsxtsb_wxdtzzyxq = tbx_zdxgjsxtsb_wxdtzzyxq.Text.ToString().Trim();
                    //上传文件
                    //文件上传
                    if (!tbx_zdxgjsxtsb_sc.HasFile)
                    {
                        lbl_zdxgjsxtsb_sc.Text = "请选择上传文件";
                        return;
                    }
                    if (tbx_zdxgjsxtsb_sc.PostedFile.ContentLength > 10240000)
                    {
                        lbl_zdxgjsxtsb_sc.Text = "附件大小超出10Ｍ";
                        return;
                    }
                    struct_jssb.p_zdxgjsxtsb_sc = tbx_zdxgjsxtsb_sc.FileName;
                    tbx_zdxgjsxtsb_sc.PostedFile.SaveAs(path + tbx_zdxgjsxtsb_sc.FileName);
                //一级雷达
                struct_jssb.p_ld_gzpl1 = "";
                struct_jssb.p_ld_csxbxh1 = "";
                struct_jssb.p_ld_fzgl1 = "";
                struct_jssb.p_ld_txszdd1 = "";
                struct_jssb.p_ld_txjcgc1 = "";
                struct_jssb.p_ld_txgd1 = "";
                struct_jssb.p_ld_txsccj1 = "";
                struct_jssb.p_ld_txxh_lx1 = "";
                struct_jssb.p_ld_fgqk1 = "";
                struct_jssb.p_wxdtzzyxq1 = "";
                struct_jssb.p_ld_sc1 = "";
                //二级雷达
                struct_jssb.p_ld_gzpl2 = "";
                struct_jssb.p_ld_csxbxh2 = "";
                struct_jssb.p_ld_fzgl2 = "";
                struct_jssb.p_ld_txszdd2 = "";
                struct_jssb.p_ld_txjcgc2 = "";
                struct_jssb.p_ld_txgd2 = "";
                struct_jssb.p_ld_txsccj2 = "";
                struct_jssb.p_ld_txxh_lx2 = "";
                struct_jssb.p_ld_fgqk2 = "";
                struct_jssb.p_wxdtzzyxq2 = "";
                struct_jssb.p_ld_sc2 = "";
                //多点定位系统
                struct_jssb.p_dddwxt_gzpl = "";
                struct_jssb.p_dddwxt_fstfzgl = "";
                struct_jssb.p_dddwxt_txszdd = "";
                struct_jssb.p_dddwxt_txjcgc = "";
                struct_jssb.p_dddwxt_txsccj = "";
                struct_jssb.p_dddwxt_txxh_lx = "";
                struct_jssb.p_dddwxt_wxdtzzyxq = "";
                struct_jssb.p_dddwxt_sc = "";
                //自动化系统
                struct_jssb.p_zdhxt_jsyyjxl = "";
                struct_jssb.p_zdhxt_xtrjbb = "";
                struct_jssb.p_zdhxt_xtgm = "";
                struct_jssb.p_zdhxt_ATCgzsqs = "";
                struct_jssb.p_zdhxt_A_SMGCSxtfj = "";
                struct_jssb.p_zdhxt_cyzzrs = "";
            }
                else if (struct_jssb.p_sblx.Equals("0305"))
                {
                    //多点定位系统
                    struct_jssb.p_dddwxt_gzpl = ddlt_dddwxt_gzpl.SelectedValue.ToString().Trim();
                    struct_jssb.p_dddwxt_fstfzgl = tbx_dddwxt_fstfzgl.Text.ToString().Trim();
                    struct_jssb.p_dddwxt_txszdd = ddlt_dddwxt_txszdd.SelectedValue.ToString().Trim();
                    struct_jssb.p_dddwxt_txjcgc = tbx_dddwxt_txjcgc.Text.ToString().Trim();
                    struct_jssb.p_dddwxt_txsccj = tbx_dddwxt_txsccj.Text.ToString().Trim();
                    struct_jssb.p_dddwxt_txxh_lx = tbx_dddwxt_txxh_lx.Text.ToString().Trim();
                    struct_jssb.p_dddwxt_wxdtzzyxq = tbx_dddwxt_wxdtzzyxq.Text.ToString().Trim();
                //上传文件
                //文件上传
                if (!tbx_dddwxt_sc.HasFile)
                {
                    lbl_dddwxt_sc.Text = "请选择上传文件";
                    return;
                }
                if (tbx_dddwxt_sc.PostedFile.ContentLength > 10240000)
                {
                    lbl_dddwxt_sc.Text = "附件大小超出10Ｍ";
                    return;
                }
                //一级雷达
                struct_jssb.p_ld_gzpl1 = "";
                struct_jssb.p_ld_csxbxh1 = "";
                struct_jssb.p_ld_fzgl1 = "";
                struct_jssb.p_ld_txszdd1 = "";
                struct_jssb.p_ld_txjcgc1 = "";
                struct_jssb.p_ld_txgd1 = "";
                struct_jssb.p_ld_txsccj1 = "";
                struct_jssb.p_ld_txxh_lx1 = "";
                struct_jssb.p_ld_fgqk1 = "";
                struct_jssb.p_wxdtzzyxq1 = "";
                struct_jssb.p_ld_sc1 = "";
                //二级雷达
                struct_jssb.p_ld_gzpl2 = "";
                struct_jssb.p_ld_csxbxh2 = "";
                struct_jssb.p_ld_fzgl2 = "";
                struct_jssb.p_ld_txszdd2 = "";
                struct_jssb.p_ld_txjcgc2 = "";
                struct_jssb.p_ld_txgd2 = "";
                struct_jssb.p_ld_txsccj2 = "";
                struct_jssb.p_ld_txxh_lx2 = "";
                struct_jssb.p_ld_fgqk2 = "";
                struct_jssb.p_wxdtzzyxq2 = "";
                struct_jssb.p_ld_sc2 = "";
                //自动相关监视系统设备
                struct_jssb.p_zdxgjsxtsb_gzpl = "";
                struct_jssb.p_zdxgjsxtsb_sfpcsxb = "";
                struct_jssb.p_zdxgjsxtsb_csxbxh = "";
                struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm = "";
                struct_jssb.p_zdxgjsxtsb_cyzzrs = "";
                struct_jssb.p_zdxgjsxtsb_fzgl = "";
                struct_jssb.p_zdxgjsxtsb_csfs = "";
                struct_jssb.p_zdxgjsxtsb_txszdd = "";
                struct_jssb.p_zdxgjsxtsb_txjcgc = "";
                struct_jssb.p_zdxgjsxtsb_txsccj = "";
                struct_jssb.p_zdxgjsxtsb_txxh_lx = "";
                struct_jssb.p_zdxgjsxtsb_wxdtzzyxq = "";
                struct_jssb.p_zdxgjsxtsb_sc = "";
                //自动化系统
                struct_jssb.p_zdhxt_jsyyjxl = "";
                struct_jssb.p_zdhxt_xtrjbb = "";
                struct_jssb.p_zdhxt_xtgm = "";
                struct_jssb.p_zdhxt_ATCgzsqs = "";
                struct_jssb.p_zdhxt_A_SMGCSxtfj = "";
                struct_jssb.p_zdhxt_cyzzrs = "";
            }
                else if (struct_jssb.p_sblx.Equals("0306"))
                {
                    //自动化系统
                    struct_jssb.p_zdhxt_jsyyjxl = tbx_zdhxt_jsyyjxl.Text.ToString().Trim();
                    struct_jssb.p_zdhxt_xtrjbb = tbx_zdhxt_xtrjbb.Text.ToString().Trim();
                    struct_jssb.p_zdhxt_xtgm = tbx_zdhxt_xtgm.Text.ToString().Trim();
                    struct_jssb.p_zdhxt_ATCgzsqs = tbx_zdhxt_ATCgzsqs.Text.ToString().Trim();
                    struct_jssb.p_zdhxt_A_SMGCSxtfj = tbx_zdhxt_A_SMGCSxtfj.Text.ToString().Trim();
                    struct_jssb.p_zdhxt_cyzzrs = tbx_zdhxt_cyzzrs.Text.ToString().Trim();
                //一级雷达
                struct_jssb.p_ld_gzpl1 = "";
                struct_jssb.p_ld_csxbxh1 = "";
                struct_jssb.p_ld_fzgl1 = "";
                struct_jssb.p_ld_txszdd1 = "";
                struct_jssb.p_ld_txjcgc1 = "";
                struct_jssb.p_ld_txgd1 = "";
                struct_jssb.p_ld_txsccj1 = "";
                struct_jssb.p_ld_txxh_lx1 = "";
                struct_jssb.p_ld_fgqk1 = "";
                struct_jssb.p_wxdtzzyxq1 = "";
                struct_jssb.p_ld_sc1 = "";
                //二级雷达
                struct_jssb.p_ld_gzpl2 = "";
                struct_jssb.p_ld_csxbxh2 = "";
                struct_jssb.p_ld_fzgl2 = "";
                struct_jssb.p_ld_txszdd2 = "";
                struct_jssb.p_ld_txjcgc2 = "";
                struct_jssb.p_ld_txgd2 = "";
                struct_jssb.p_ld_txsccj2 = "";
                struct_jssb.p_ld_txxh_lx2 = "";
                struct_jssb.p_ld_fgqk2 = "";
                struct_jssb.p_wxdtzzyxq2 = "";
                struct_jssb.p_ld_sc2 = "";
                //自动相关监视系统设备
                struct_jssb.p_zdxgjsxtsb_gzpl = "";
                struct_jssb.p_zdxgjsxtsb_sfpcsxb = "";
                struct_jssb.p_zdxgjsxtsb_csxbxh = "";
                struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm = "";
                struct_jssb.p_zdxgjsxtsb_cyzzrs = "";
                struct_jssb.p_zdxgjsxtsb_fzgl = "";
                struct_jssb.p_zdxgjsxtsb_csfs = "";
                struct_jssb.p_zdxgjsxtsb_txszdd = "";
                struct_jssb.p_zdxgjsxtsb_txjcgc = "";
                struct_jssb.p_zdxgjsxtsb_txsccj = "";
                struct_jssb.p_zdxgjsxtsb_txxh_lx = "";
                struct_jssb.p_zdxgjsxtsb_wxdtzzyxq = "";
                struct_jssb.p_zdxgjsxtsb_sc = "";
                //多点定位系统
                struct_jssb.p_dddwxt_gzpl = "";
                struct_jssb.p_dddwxt_fstfzgl = "";
                struct_jssb.p_dddwxt_txszdd = "";
                struct_jssb.p_dddwxt_txjcgc = "";
                struct_jssb.p_dddwxt_txsccj = "";
                struct_jssb.p_dddwxt_txxh_lx = "";
                struct_jssb.p_dddwxt_wxdtzzyxq = "";
                struct_jssb.p_dddwxt_sc = "";
            }
                #endregion
                //录入人 时间戳
                #endregion
                #region 判断文件上传路径 没有自动生成
                #endregion
                struct_jssb.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
                struct_jssb.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                struct_jssb.p_sjssbm=ddlt_sjssbm.SelectedValue.ToString().Trim();//数据所属部门
                struct_jssb.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                struct_jssb.p_lrr = _usState.userLoginName.ToString();//录入人
            #region 判断数据是什么状态的
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_jssb.p_lrr.Equals(struct_jssb.p_csr))
                {
                    struct_jssb.p_sjbs = "0";
                    struct_jssb.p_zt = "2";
                }
                //如果是终审人录入数据，则状态为审核通过
                if (struct_jssb.p_lrr.Equals(struct_jssb.p_zsr))
                {
                    struct_jssb.p_sjbs = "1";
                    struct_jssb.p_zt = "3";
                }
                if (!struct_jssb.p_lrr.Equals(struct_jssb.p_csr) && !struct_jssb.p_lrr.Equals(struct_jssb.p_zsr))
                {
                    struct_jssb.p_sjbs = "0";
                    struct_jssb.p_zt = "0";
                }
                #endregion
                struct_jssb.p_czfs = "02";
                struct_jssb.p_czxx = "位置：设备管理->监视设备->添加   描述：员工编号：" + _usState.userLoginName;
            
            jssb.Insert_JSSB(struct_jssb);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("JSSB_GL.aspx");
    }
        #region CHECK
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;

            }
        }
        #endregion

        #endregion

        #region 判断设备类型显示哪个div
        protected void ddlt_sblx_change(object sender, EventArgs e)
        {
            string sblx;
            ddlt_jc.SelectedValue = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
            if (ddlt_jc.SelectedValue == "-1")
            {

                sblx = " ";
            }
            else
            {
                sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
            }
            if (sblx.Equals("0301"))
            {
                div_yjld.Style.Add("display", "true");
                div_ejld.Style.Add("display", "none");
                div_cmjssb.Style.Add("display", "none");
                div_zdxgjsxtsb.Style.Add("display", "none");
                div_dddwxt.Style.Add("display", "none");
                div_zdhxt.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0302"))
            {
                div_yjld.Style.Add("display", "none");
                div_ejld.Style.Add("display", "true");
                div_cmjssb.Style.Add("display", "none");
                div_zdxgjsxtsb.Style.Add("display", "none");
                div_dddwxt.Style.Add("display", "none");
                div_zdhxt.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0303"))
            {
                div_yjld.Style.Add("display", "none");
                div_ejld.Style.Add("display", "none");
                div_cmjssb.Style.Add("display", "true");
                div_zdxgjsxtsb.Style.Add("display", "none");
                div_dddwxt.Style.Add("display", "none");
                div_zdhxt.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0304"))
            {
                div_yjld.Style.Add("display", "none");
                div_ejld.Style.Add("display", "none");
                div_cmjssb.Style.Add("display", "none");
                div_zdxgjsxtsb.Style.Add("display", "true");
                div_dddwxt.Style.Add("display", "none");
                div_zdhxt.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0305"))
            {
                div_yjld.Style.Add("display", "none");
                div_ejld.Style.Add("display", "none");
                div_cmjssb.Style.Add("display", "none");
                div_zdxgjsxtsb.Style.Add("display", "none");
                div_dddwxt.Style.Add("display", "true");
                div_zdhxt.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0306"))
            {
                div_yjld.Style.Add("display", "none");
                div_ejld.Style.Add("display", "none");
                div_cmjssb.Style.Add("display", "none");
                div_zdxgjsxtsb.Style.Add("display", "none");
                div_dddwxt.Style.Add("display", "none");
                div_zdhxt.Style.Add("display", "true");
                div_zdzbxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0307"))
            {
                div_yjld.Style.Add("display", "none");
                div_ejld.Style.Add("display", "none");
                div_cmjssb.Style.Add("display", "none");
                div_zdxgjsxtsb.Style.Add("display", "none");
                div_dddwxt.Style.Add("display", "none");
                div_zdhxt.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "true");
            }
        }
        #endregion
        protected void ddlt_jc_change(object sender, EventArgs e)
        {
            if (ddlt_jc.SelectedValue != "-1")
            {
                DataTable dt = SysData.TZLX_ZH(ddlt_jc.SelectedValue,"04");
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
                    ddlt_tzmczl.DataSource = SysData.TZLX_ZH("04").Copy();
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
                DataTable dt = SysData.TZLX_ZH("04");
                //台站名称种类 台站名称
                ddlt_tzmczl.DataTextField = "mc";
                ddlt_tzmczl.DataValueField = "bm";
                ddlt_tzmczl.DataSource = dt.Copy();
                ddlt_tzmczl.DataBind();
                ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
            }
        }
        #region 返回按钮
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("JSSB_GL.aspx");
        }
        #endregion
 
    }
}