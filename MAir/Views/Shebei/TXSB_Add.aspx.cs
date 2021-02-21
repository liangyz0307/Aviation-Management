using CUST.MKG;
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
    public partial class TXSB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private TXSB txsb;
        private Struct_TXSB struct_TXSB;
        private Utils utils;
        private string sbbgrbh;
        public bool flag = true;
        public int i = 0;
        private YGJL ygjl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            txsb = new TXSB(_usState);
            ygjl = new YGJL(_usState);
            struct_TXSB = new Struct_TXSB();
            utils = new Utils();
            if (!IsPostBack)
            {
                tbx_tckfsj.Attributes.Add("readonly", "readonly");
                tbx_dbsj.Attributes.Add("readonly", "readonly");
                tbx_sgpdktxxt_tcjfrq.Attributes.Add("readonly", "readonly");
                tbx_gpdktxxt_tcjfrq.Attributes.Add("readonly", "readonly");
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "none");
                tbx_tckfsj.Attributes.Add("readonly", "readonly");//投产开放时间
                tbx_dbsj.Attributes.Add("readonly", "readonly");//调拨时间
                ddltBind();

                string sjjd = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo);//时间节点
                int lss = Convert.ToInt32(txsb.Select_SB_MaxNumber(sjjd));
                if (lss >= 99999)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"数据超出，请联系管理员整理数据！\")</script>");
                    Response.Redirect("../SheBei/QXSB_GL.aspx");
                }
                tbx_sbbh.Text = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo) + "02" + Convert.ToString(lss + 1).PadLeft(5, '0');
            }
        }

        private void ddltBind()
        {
            ////绑定设备类型
            //ddlt_sblx.DataTextField = "mc";
            //ddlt_sblx.DataValueField = "bm";
            //ddlt_sblx.DataSource = SysData.SBLX("01").Copy();
            //ddlt_sblx.DataBind();
            //ddlt_sblx.Items.Insert(0, new ListItem("请选择", "-1"));

            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            //台站
            ddlt_tzmczl.DataTextField = "mc";
            ddlt_tzmczl.DataValueField = "bm";
            ddlt_tzmczl.DataSource = SysData.TZLX_ZH("01").Copy();
            ddlt_tzmczl.DataBind();
            ddlt_tzmczl.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备状态
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("请选择", "-1"));

            //用途
            ddlt_yt.DataTextField = "mc";
            ddlt_yt.DataValueField = "bm";
            ddlt_yt.DataSource = SysData.SBYT().Copy();
            ddlt_yt.DataBind();
            ddlt_yt.Items.Insert(0, new ListItem("请选择", "-1"));


            //现所属机场(调拨涉及信息)(支线)
            ddlt_xssjc.DataTextField = "mc";
            ddlt_xssjc.DataValueField = "bm";
            ddlt_xssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_xssjc.DataBind();
            ddlt_xssjc.Items.Insert(0, new ListItem("请选择", "-1"));

            //站点类型(卫星地面站系统)
            ddlt_wxdmzxt_zdlx.DataTextField = "mc";
            ddlt_wxdmzxt_zdlx.DataValueField = "bm";
            ddlt_wxdmzxt_zdlx.DataSource = SysData.ZDLX().Copy();
            ddlt_wxdmzxt_zdlx.DataBind();
            ddlt_wxdmzxt_zdlx.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备配置(甚高频低空通信系统)
            ddlt_sgpdktxxt_sbpz.DataTextField = "mc";
            ddlt_sgpdktxxt_sbpz.DataValueField = "bm";
            ddlt_sgpdktxxt_sbpz.DataSource = SysData.SBPZ().Copy();
            ddlt_sgpdktxxt_sbpz.DataBind();
            ddlt_sgpdktxxt_sbpz.Items.Insert(0, new ListItem("请选择", "-1"));

            //天线类型(甚高频低空通信系统)
            ddlt_sgpdktxxt_txlx.DataTextField = "mc";
            ddlt_sgpdktxxt_txlx.DataValueField = "bm";
            ddlt_sgpdktxxt_txlx.DataSource = SysData.TXLX().Copy();
            ddlt_sgpdktxxt_txlx.DataBind();
            ddlt_sgpdktxxt_txlx.Items.Insert(0, new ListItem("请选择", "-1"));

            //MFC协议(语音交换系统（内话）)
            ddlt_yyjhxt_nh_MFCxy.DataTextField = "mc";
            ddlt_yyjhxt_nh_MFCxy.DataValueField = "bm";
            ddlt_yyjhxt_nh_MFCxy.DataSource = SysData.MFCXY().Copy();
            ddlt_yyjhxt_nh_MFCxy.DataBind();
            ddlt_yyjhxt_nh_MFCxy.Items.Insert(0, new ListItem("请选择", "-1"));

            //Q-SIG协议(语音交换系统（内话）)
            ddlt_yyjhxt_nh_QSIGxy.DataTextField = "mc";
            ddlt_yyjhxt_nh_QSIGxy.DataValueField = "bm";
            ddlt_yyjhxt_nh_QSIGxy.DataSource = SysData.QSIGXY().Copy();
            ddlt_yyjhxt_nh_QSIGxy.DataBind();
            ddlt_yyjhxt_nh_QSIGxy.Items.Insert(0, new ListItem("请选择", "-1"));

            //IP协议(语音交换系统（内话）)
            ddlt_yyjhxt_nh_IPxy.DataTextField = "mc";
            ddlt_yyjhxt_nh_IPxy.DataValueField = "bm";
            ddlt_yyjhxt_nh_IPxy.DataSource = SysData.IPXY().Copy();
            ddlt_yyjhxt_nh_IPxy.DataBind();
            ddlt_yyjhxt_nh_IPxy.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备配置(高频低空通信系统)
            ddlt_gpdktxxt_sbpz.DataTextField = "mc";
            ddlt_gpdktxxt_sbpz.DataValueField = "bm";
            ddlt_gpdktxxt_sbpz.DataSource = SysData.SBPZ().Copy();
            ddlt_gpdktxxt_sbpz.DataBind();
            ddlt_gpdktxxt_sbpz.Items.Insert(0, new ListItem("请选择", "-1"));

            //天线类型(高频低空通信系统)
            ddlt_gpdktxxt_txlx.DataTextField = "mc";
            ddlt_gpdktxxt_txlx.DataValueField = "bm";
            ddlt_gpdktxxt_txlx.DataSource = SysData.TXLX().Copy();
            ddlt_gpdktxxt_txlx.DataBind();
            ddlt_gpdktxxt_txlx.Items.Insert(0, new ListItem("请选择", "-1"));


            DataTable dt_bmdm = SysData.BM("140202", _usState.userID).Copy();
            //DataTable dt_bmdm = SysData.BM().Copy();
            //设备保管人
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
            //ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sbbgr.DataSource = dt;
            ddlt_sbbgr.DataTextField = "xm";
            ddlt_sbbgr.DataValueField = "bh";
            ddlt_sbbgr.DataBind();


            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140202");

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


            //数据所在部门
            ddlt_sjssbm.DataSource = SysData.BM("140202", _usState.userID).Copy();
            ddlt_sjssbm.DataTextField = "bmmc";
            ddlt_sjssbm.DataValueField = "bmdm";
            ddlt_sjssbm.DataBind();
            ddlt_sjssbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }

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
                        Response.Redirect("../main/TXSB_GL.aspx");
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

        protected void btn_save_Click(object sender, EventArgs e)
        {

            //判断是否有该路径  
            string path = Server.MapPath("../Shebei/UpLoads/SBGL/TXSB/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            #region lable判断
            int flag = 0;

            //所属机场
            if (ddlt_jc.SelectedValue == "-1")
            {
                lbl_jc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //设备类型
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
            if (tbx_tckfsj.Text == "")
            {
                lbl_tckfsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tckfsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //数量
            if (tbx_sl.Text == "")
            {
                lbl_sl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            if (!tbx_sbxkzsc.HasFile)
            {
                lbl_sbxkzsc.Text = "<span style=\"color:#ff0000\">" + "请选择上传文件" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbxkzsc.Text = "<span style=\"color:#00ff00\">" + "" + "</span>";
            }
            //用途
            if (ddlt_yt.SelectedValue == "-1")
            {
                lbl_yt.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电
            if (tbx_jlgd.Text == "")
            {
                lbl_jlgd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jlgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电大小
            if (tbx_jlgddx.Text == "")
            {
                lbl_jlgddx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jlgddx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电数量
            if (tbx_jlgdsl.Text == "")
            {
                lbl_jlgdsl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jlgdsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电
            if (tbx_zlgd.Text == "")
            {
                lbl_zlgd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zlgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电大小
            if (tbx_zlgddx.Text == "")
            {
                lbl_zlgddx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zlgddx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电数量
            if (tbx_zlgdsl.Text == "")
            {
                lbl_zlgdsl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zlgdsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //保护区范围
            if (!tbx_bhqfw.HasFile)
            {
                lbl_bhqfw.Text = "<span style=\"color:#ff0000\">" + "请选择上传文件" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bhqfw.Text = "<span style=\"color:#00ff00\">" + "" + "</span>";
            }
            //设备传输情况
            if (tbx_sbcsqk.Text == "")
            {
                lbl_sbcsqk.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbcsqk.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备防雷配置
            if (tbx_sbflpz.Text == "")
            {
                lbl_sbflpz.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbflpz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //现所属机场
            if (ddlt_xssjc.SelectedValue == "-1")
            {
                lbl_xssjc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xssjc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //调拨时间
            if (tbx_dbsj.Text == "")
            {
                lbl_dbsj.Text = "<span style=\"color:#ff0000\">" + "请选择调拨时间" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dbsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备保管人
            if (tbx_sbbgr.Text == "")
            {
                lbl_sbbgr.Text = "<span style=\"color:#ff0000\">" + "请选择设备保管人" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbbgr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            //数据所属部门
            if (ddlt_sjssbm.SelectedValue == "-1")
            {
                lbl_sjssbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjssbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1) { return; }

            #endregion

            //基本信息
            struct_TXSB.p_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4,4);
            struct_TXSB.p_wz = ddlt_tzmczl.SelectedValue.ToString().Substring(2,2);
            struct_TXSB.p_ssjc = ddlt_tzmczl.SelectedValue.ToString().Substring(0,2);
            struct_TXSB.p_tckfsj = tbx_tckfsj.Text.Trim().ToString();
            struct_TXSB.p_sl = tbx_sl.Text.Trim().ToString();
            struct_TXSB.p_sbzt = ddlt_sbzt.SelectedValue.Trim().ToString();
            struct_TXSB.p_sbsccj = tbx_sbsccj.Text.Trim().ToString();
            struct_TXSB.p_sbccbh = tbx_sbccbh.Text.Trim().ToString();
            struct_TXSB.p_yt = ddlt_yt.SelectedValue.Trim().ToString();
            struct_TXSB.p_jlgd = tbx_jlgd.Text.Trim().ToString();
            struct_TXSB.p_jlgddx = tbx_jlgddx.Text.Trim().ToString();
            struct_TXSB.p_jlgdsl = tbx_jlgdsl.Text.Trim().ToString();
            struct_TXSB.p_zlgd = tbx_zlgd.Text.Trim().ToString();
            struct_TXSB.p_zlgddx = tbx_zlgddx.Text.Trim().ToString();
            struct_TXSB.p_zlgdsl = tbx_zlgdsl.Text.Trim().ToString();
            struct_TXSB.p_sbcsqk = tbx_sbcsqk.Text.Trim().ToString();
            struct_TXSB.p_sbflpz = tbx_sbflpz.Text.Trim().ToString();
            struct_TXSB.p_xssjc = ddlt_xssjc.SelectedValue.Trim().ToString();
            struct_TXSB.p_dbsj = tbx_dbsj.Text.Trim().ToString();
            struct_TXSB.p_sbbgr = ddlt_sbbgr.SelectedValue.Trim().ToString();
            struct_TXSB.p_sbbh = tbx_sbbh.Text.ToString();
            //上传文件
            if (!tbx_sbxkzsc.HasFile)
            {
                lbl_sbxkzsc.Text = "请选择上传文件";
                return;
            }
            if (tbx_sbxkzsc.PostedFile.ContentLength > 10240000)
            {
                lbl_sbxkzsc.Text = "附件大小超出10Ｍ";
                return;
            }
            //上传文件
            //文件上传
            if (!tbx_bhqfw.HasFile)
            {
                lbl_bhqfw.Text = "请选择上传文件";
                return;
            }
            if (tbx_bhqfw.PostedFile.ContentLength > 10240000)
            {
                lbl_bhqfw.Text = "附件大小超出10Ｍ";
                return;
            }
            struct_TXSB.p_bhqfw = tbx_bhqfw.FileName;//保护区范围
            struct_TXSB.p_sbxkzsc = tbx_sbxkzsc.FileName;//设备许可证上传

            tbx_bhqfw.PostedFile.SaveAs(path + tbx_bhqfw.FileName);
            tbx_sbxkzsc.PostedFile.SaveAs(path + tbx_sbxkzsc.FileName);
            //struct_txsb.p_sbbh = "";
            //struct_txsb.p_zt = "";
            //时间戳
            struct_TXSB.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_TXSB.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_TXSB.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_TXSB.p_sjssbm = ddlt_sjssbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_TXSB.p_lrr = _usState.userLoginName.ToString();//录入人

            struct_TXSB.p_sbxh = tbx_sbxh.Text;//设备型号

            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_TXSB.p_lrr.Equals(struct_TXSB.p_csr))
            {
                struct_TXSB.p_sjbs = "0";
                struct_TXSB.p_zt = "2";
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_TXSB.p_lrr.Equals(struct_TXSB.p_zsr))
            {
                struct_TXSB.p_sjbs = "1";
                struct_TXSB.p_zt = "3";
            }
            if (!struct_TXSB.p_lrr.Equals(struct_TXSB.p_csr) && !struct_TXSB.p_lrr.Equals(struct_TXSB.p_zsr))
            {
                struct_TXSB.p_sjbs = "0";
                struct_TXSB.p_zt = "0";
            }
            //设备类型详细添加
            if (struct_TXSB.p_sblx.Equals("0101") || struct_TXSB.p_sblx.Equals("0102"))
            {
                #region 将其他设备置空
                struct_TXSB.p_yyjly_xyyhs = "";
                struct_TXSB.p_yyjly_yyxds = "";
                struct_TXSB.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_TXSB.p_wxdmzxt_zdlx = "";
                struct_TXSB.p_wxdmzxt_txkj = "";
                struct_TXSB.p_wxdmzxt_swdygl = "";
                struct_TXSB.p_wxdmzxt_fspl = "";
                struct_TXSB.p_wxdmzxt_jspl = "";
                struct_TXSB.p_wxdmzxt_xds = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_wxdmzxt_txszdd = "";
                struct_TXSB.p_wxdmzxt_txjcgc = "";
                struct_TXSB.p_wxdmzxt_wxdtzzyxq = "";
                struct_TXSB.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_TXSB.p_sgpdktxxt_sbpz = "";
                struct_TXSB.p_sgpdktxxt_sbxds = "";
                struct_TXSB.p_sgpdktxxt_txlx = "";
                struct_TXSB.p_sgpdktxxt_tcjfrq = "";
                struct_TXSB.p_sgpdktxxt_fspl = "";
                struct_TXSB.p_sgpdktxxt_scgl = "";
                struct_TXSB.p_sgpdktxxt_csfs = "";
                struct_TXSB.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_sgpdktxxt_txjcgc = "";
                struct_TXSB.p_sgpdktxxt_txgd = "";
                struct_TXSB.p_sgpdktxxt_txszdd = "";
                struct_TXSB.p_sgpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_sgpdktxxt_txxh_lx = "";
                struct_TXSB.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_TXSB.p_yyjhxt_nh_xtpz = "";
                struct_TXSB.p_yyjhxt_nh_xwjtpz = "";
                struct_TXSB.p_yyjhxt_nh_xtrjbb = "";
                struct_TXSB.p_yyjhxt_nh_jksl_yx = "";
                struct_TXSB.p_yyjhxt_nh_jksl_wx = "";
                struct_TXSB.p_yyjhxt_nh_MFCxy = "";
                struct_TXSB.p_yyjhxt_nh_QSIGxy = "";
                struct_TXSB.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_TXSB.p_zdzbxt_xtpz = "";
                struct_TXSB.p_zdzbxt_xtrjbb = "";
                struct_TXSB.p_zdzbxt_zyxt = "";
                struct_TXSB.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_TXSB.p_gpdktxxt_sbpz = "";
                struct_TXSB.p_gpdktxxt_sbxds = "";
                struct_TXSB.p_gpdktxxt_txlx = "";
                struct_TXSB.p_gpdktxxt_tcjfrq = "";
                struct_TXSB.p_gpdktxxt_fspl = "";
                struct_TXSB.p_gpdktxxt_scgl = "";
                struct_TXSB.p_gpdktxxt_csfs = "";
                struct_TXSB.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_gpdktxxt_txjcgc = "";
                struct_TXSB.p_gpdktxxt_txgd = "";
                struct_TXSB.p_gpdktxxt_txszdd = "";
                struct_TXSB.p_gpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_gpdktxxt_txxh_lx = "";
                struct_TXSB.p_gpdktxxt_txsccj = "";
                #endregion
            }
            //语音记录仪
            else if (struct_TXSB.p_sblx.Equals("0103"))
            {
                #region 语音记录仪 3个
                struct_TXSB.p_yyjly_xyyhs = tbx_yyjly_xyyhs.Text.Trim().ToString();
                struct_TXSB.p_yyjly_yyxds = tbx_yyjly_yyxds.Text.Trim().ToString();
                struct_TXSB.p_yyjly_sjxds = tbx_yyjly_sjxds.Text.Trim().ToString();

                #region 将其他设备置空
                //卫星地面站系统
                struct_TXSB.p_wxdmzxt_zdlx = "";
                struct_TXSB.p_wxdmzxt_txkj = "";
                struct_TXSB.p_wxdmzxt_swdygl = "";
                struct_TXSB.p_wxdmzxt_fspl = "";
                struct_TXSB.p_wxdmzxt_jspl = "";
                struct_TXSB.p_wxdmzxt_xds = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_wxdmzxt_txszdd = "";
                struct_TXSB.p_wxdmzxt_txjcgc = "";
                struct_TXSB.p_wxdmzxt_wxdtzzyxq = "";
                struct_TXSB.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_TXSB.p_sgpdktxxt_sbpz = "";
                struct_TXSB.p_sgpdktxxt_sbxds = "";
                struct_TXSB.p_sgpdktxxt_txlx = "";
                struct_TXSB.p_sgpdktxxt_tcjfrq = "";
                struct_TXSB.p_sgpdktxxt_fspl = "";
                struct_TXSB.p_sgpdktxxt_scgl = "";
                struct_TXSB.p_sgpdktxxt_csfs = "";
                struct_TXSB.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_sgpdktxxt_txjcgc = "";
                struct_TXSB.p_sgpdktxxt_txgd = "";
                struct_TXSB.p_sgpdktxxt_txszdd = "";
                struct_TXSB.p_sgpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_sgpdktxxt_txxh_lx = "";
                struct_TXSB.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_TXSB.p_yyjhxt_nh_xtpz = "";
                struct_TXSB.p_yyjhxt_nh_xwjtpz = "";
                struct_TXSB.p_yyjhxt_nh_xtrjbb = "";
                struct_TXSB.p_yyjhxt_nh_jksl_yx = "";
                struct_TXSB.p_yyjhxt_nh_jksl_wx = "";
                struct_TXSB.p_yyjhxt_nh_MFCxy = "";
                struct_TXSB.p_yyjhxt_nh_QSIGxy = "";
                struct_TXSB.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_TXSB.p_zdzbxt_xtpz = "";
                struct_TXSB.p_zdzbxt_xtrjbb = "";
                struct_TXSB.p_zdzbxt_zyxt = "";
                struct_TXSB.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_TXSB.p_gpdktxxt_sbpz = "";
                struct_TXSB.p_gpdktxxt_sbxds = "";
                struct_TXSB.p_gpdktxxt_txlx = "";
                struct_TXSB.p_gpdktxxt_tcjfrq = "";
                struct_TXSB.p_gpdktxxt_fspl = "";
                struct_TXSB.p_gpdktxxt_scgl = "";
                struct_TXSB.p_gpdktxxt_csfs = "";
                struct_TXSB.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_gpdktxxt_txjcgc = "";
                struct_TXSB.p_gpdktxxt_txgd = "";
                struct_TXSB.p_gpdktxxt_txszdd = "";
                struct_TXSB.p_gpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_gpdktxxt_txxh_lx = "";
                struct_TXSB.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion 
            }
            //卫星地面站系统
            else if (struct_TXSB.p_sblx.Equals("0104"))
            {
                #region 卫星地面站系统 14个
                struct_TXSB.p_wxdmzxt_zdlx = ddlt_wxdmzxt_zdlx.SelectedValue.Trim().ToString();
                struct_TXSB.p_wxdmzxt_txkj = tbx_wxdmzxt_txkj.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_swdygl = tbx_wxdmzxt_swdygl.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_fspl = tbx_wxdmzxt_fspl.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_jspl = tbx_wxdmzxt_jspl.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_xds = tbx_wxdmzxt_xds.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_tzzb_bj54_jd = tbx_wxdmzxt_tzzb_bj54_jd.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_tzzb_bj54_wd = tbx_wxdmzxt_tzzb_bj54_wd.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd = tbx_wxdmzxt_tzzb_wgs84_jd.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd = tbx_wxdmzxt_tzzb_wgs84_wd.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_txszdd = tbx_wxdmzxt_txszdd.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_txjcgc = tbx_wxdmzxt_txjcgc.Text.Trim().ToString();
                struct_TXSB.p_wxdmzxt_wxdtzzyxq = tbx_wxdmzxt_wxdtzzyxq.Text.Trim().ToString();

                //文件上传
                if (!tbx_wxdmzxt_sc.HasFile)
                {
                    lbl_wxdmzxt_sc.Text = "请选择上传文件";
                    return;
                }
                if (tbx_wxdmzxt_sc.PostedFile.ContentLength > 10240000)
                {
                    lbl_wxdmzxt_sc.Text = "附件大小超出10Ｍ";
                    return;
                }
                struct_TXSB.p_wxdmzxt_sc = tbx_wxdmzxt_sc.FileName;//上传
                //上传文件
                tbx_wxdmzxt_sc.PostedFile.SaveAs(path + tbx_wxdmzxt_sc.FileName);

                #region 将其他设备置空
                struct_TXSB.p_yyjly_xyyhs = "";
                struct_TXSB.p_yyjly_yyxds = "";
                struct_TXSB.p_yyjly_sjxds = "";

                //甚高频地空通信系统
                struct_TXSB.p_sgpdktxxt_sbpz = "";
                struct_TXSB.p_sgpdktxxt_sbxds = "";
                struct_TXSB.p_sgpdktxxt_txlx = "";
                struct_TXSB.p_sgpdktxxt_tcjfrq = "";
                struct_TXSB.p_sgpdktxxt_fspl = "";
                struct_TXSB.p_sgpdktxxt_scgl = "";
                struct_TXSB.p_sgpdktxxt_csfs = "";
                struct_TXSB.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_sgpdktxxt_txjcgc = "";
                struct_TXSB.p_sgpdktxxt_txgd = "";
                struct_TXSB.p_sgpdktxxt_txszdd = "";
                struct_TXSB.p_sgpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_sgpdktxxt_txxh_lx = "";
                struct_TXSB.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_TXSB.p_yyjhxt_nh_xtpz = "";
                struct_TXSB.p_yyjhxt_nh_xwjtpz = "";
                struct_TXSB.p_yyjhxt_nh_xtrjbb = "";
                struct_TXSB.p_yyjhxt_nh_jksl_yx = "";
                struct_TXSB.p_yyjhxt_nh_jksl_wx = "";
                struct_TXSB.p_yyjhxt_nh_MFCxy = "";
                struct_TXSB.p_yyjhxt_nh_QSIGxy = "";
                struct_TXSB.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_TXSB.p_zdzbxt_xtpz = "";
                struct_TXSB.p_zdzbxt_xtrjbb = "";
                struct_TXSB.p_zdzbxt_zyxt = "";
                struct_TXSB.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_TXSB.p_gpdktxxt_sbpz = "";
                struct_TXSB.p_gpdktxxt_sbxds = "";
                struct_TXSB.p_gpdktxxt_txlx = "";
                struct_TXSB.p_gpdktxxt_tcjfrq = "";
                struct_TXSB.p_gpdktxxt_fspl = "";
                struct_TXSB.p_gpdktxxt_scgl = "";
                struct_TXSB.p_gpdktxxt_csfs = "";
                struct_TXSB.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_gpdktxxt_txjcgc = "";
                struct_TXSB.p_gpdktxxt_txgd = "";
                struct_TXSB.p_gpdktxxt_txszdd = "";
                struct_TXSB.p_gpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_gpdktxxt_txxh_lx = "";
                struct_TXSB.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //甚高频地空通信系统
            else if (struct_TXSB.p_sblx.Equals("0105"))
            {
                #region 甚高频地空通信系统 18个
                struct_TXSB.p_sgpdktxxt_sbpz = ddlt_sgpdktxxt_sbpz.SelectedValue.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_sbxds = tbx_sgpdktxxt_sbxds.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_txlx = ddlt_sgpdktxxt_txlx.SelectedValue.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tcjfrq = tbx_sgpdktxxt_tcjfrq.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_fspl = tbx_sgpdktxxt_fspl.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_scgl = tbx_sgpdktxxt_scgl.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_csfs = tbx_sgpdktxxt_csfs.Text.Trim().ToString();

                //文件上传
                if (!tbx_sgpdktxxt_sc.HasFile)
                {
                    lbl_sgpdktxxt_sc.Text = "请选择上传文件";
                    return;
                }
                if (tbx_sgpdktxxt_sc.PostedFile.ContentLength > 10240000)
                {
                    lbl_sgpdktxxt_sc.Text = "附件大小超出10Ｍ";
                    return;
                }
                struct_TXSB.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.FileName;
                tbx_sgpdktxxt_sc.PostedFile.SaveAs(path + tbx_sgpdktxxt_sc.FileName);
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd = tbx_sgpdktxxt_tzzb_bj54_jd.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd = tbx_sgpdktxxt_tzzb_bj54_wd.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd = tbx_sgpdktxxt_tzzb_wgs84_jd.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd = tbx_sgpdktxxt_tzzb_wgs84_wd.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_txjcgc = tbx_sgpdktxxt_txjcgc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_txgd = tbx_sgpdktxxt_txgd.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_txszdd = tbx_sgpdktxxt_txszdd.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_wxdtzzyxq = tbx_sgpdktxxt_wxdtzzyxq.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_txsccj = tbx_sgpdktxxt_txsccj.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_txxh_lx = tbx_sgpdktxxt_txxh_lx.Text.Trim().ToString();

                #region 将其他设备置空
                struct_TXSB.p_yyjly_xyyhs = "";
                struct_TXSB.p_yyjly_yyxds = "";
                struct_TXSB.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_TXSB.p_wxdmzxt_zdlx = "";
                struct_TXSB.p_wxdmzxt_txkj = "";
                struct_TXSB.p_wxdmzxt_swdygl = "";
                struct_TXSB.p_wxdmzxt_fspl = "";
                struct_TXSB.p_wxdmzxt_jspl = "";
                struct_TXSB.p_wxdmzxt_xds = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_wxdmzxt_txszdd = "";
                struct_TXSB.p_wxdmzxt_txjcgc = "";
                struct_TXSB.p_wxdmzxt_wxdtzzyxq = "";
                struct_TXSB.p_wxdmzxt_sc = "";//上传

                //语音交换系统（内话）
                struct_TXSB.p_yyjhxt_nh_xtpz = "";
                struct_TXSB.p_yyjhxt_nh_xwjtpz = "";
                struct_TXSB.p_yyjhxt_nh_xtrjbb = "";
                struct_TXSB.p_yyjhxt_nh_jksl_yx = "";
                struct_TXSB.p_yyjhxt_nh_jksl_wx = "";
                struct_TXSB.p_yyjhxt_nh_MFCxy = "";
                struct_TXSB.p_yyjhxt_nh_QSIGxy = "";
                struct_TXSB.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_TXSB.p_zdzbxt_xtpz = "";
                struct_TXSB.p_zdzbxt_xtrjbb = "";
                struct_TXSB.p_zdzbxt_zyxt = "";
                struct_TXSB.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_TXSB.p_gpdktxxt_sbpz = "";
                struct_TXSB.p_gpdktxxt_sbxds = "";
                struct_TXSB.p_gpdktxxt_txlx = "";
                struct_TXSB.p_gpdktxxt_tcjfrq = "";
                struct_TXSB.p_gpdktxxt_fspl = "";
                struct_TXSB.p_gpdktxxt_scgl = "";
                struct_TXSB.p_gpdktxxt_csfs = "";
                struct_TXSB.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_gpdktxxt_txjcgc = "";
                struct_TXSB.p_gpdktxxt_txgd = "";
                struct_TXSB.p_gpdktxxt_txszdd = "";
                struct_TXSB.p_gpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_gpdktxxt_txxh_lx = "";
                struct_TXSB.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //语音交换系统（内话）
            else if (struct_TXSB.p_sblx.Equals("0106"))
            {
                #region 语音交换系统（内话）8个
                struct_TXSB.p_yyjhxt_nh_xtpz = tbx_yyjhxt_nh_xtpz.Text.Trim().ToString();
                struct_TXSB.p_yyjhxt_nh_xwjtpz = tbx_yyjhxt_nh_xwjtpz.Text.Trim().ToString();
                struct_TXSB.p_yyjhxt_nh_xtrjbb = tbx_yyjhxt_nh_xtrjbb.Text.Trim().ToString();
                struct_TXSB.p_yyjhxt_nh_jksl_yx = tbx_yyjhxt_nh_jksl_yx.Text.Trim().ToString();
                struct_TXSB.p_yyjhxt_nh_jksl_wx = tbx_yyjhxt_nh_jksl_wx.Text.Trim().ToString();
                struct_TXSB.p_yyjhxt_nh_MFCxy = ddlt_yyjhxt_nh_MFCxy.SelectedValue.Trim().ToString();
                struct_TXSB.p_yyjhxt_nh_QSIGxy = ddlt_yyjhxt_nh_QSIGxy.SelectedValue.Trim().ToString();
                struct_TXSB.p_yyjhxt_nh_IPxy = ddlt_yyjhxt_nh_IPxy.SelectedValue.Trim().ToString();

                #region 将其他设备置空
                struct_TXSB.p_yyjly_xyyhs = "";
                struct_TXSB.p_yyjly_yyxds = "";
                struct_TXSB.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_TXSB.p_wxdmzxt_zdlx = "";
                struct_TXSB.p_wxdmzxt_txkj = "";
                struct_TXSB.p_wxdmzxt_swdygl = "";
                struct_TXSB.p_wxdmzxt_fspl = "";
                struct_TXSB.p_wxdmzxt_jspl = "";
                struct_TXSB.p_wxdmzxt_xds = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_wxdmzxt_txszdd = "";
                struct_TXSB.p_wxdmzxt_txjcgc = "";
                struct_TXSB.p_wxdmzxt_wxdtzzyxq = "";
                struct_TXSB.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_TXSB.p_sgpdktxxt_sbpz = "";
                struct_TXSB.p_sgpdktxxt_sbxds = "";
                struct_TXSB.p_sgpdktxxt_txlx = "";
                struct_TXSB.p_sgpdktxxt_tcjfrq = "";
                struct_TXSB.p_sgpdktxxt_fspl = "";
                struct_TXSB.p_sgpdktxxt_scgl = "";
                struct_TXSB.p_sgpdktxxt_csfs = "";
                struct_TXSB.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_sgpdktxxt_txjcgc = "";
                struct_TXSB.p_sgpdktxxt_txgd = "";
                struct_TXSB.p_sgpdktxxt_txszdd = "";
                struct_TXSB.p_sgpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_sgpdktxxt_txxh_lx = "";
                struct_TXSB.p_sgpdktxxt_txsccj = "";

                //自动转报系统
                struct_TXSB.p_zdzbxt_xtpz = "";
                struct_TXSB.p_zdzbxt_xtrjbb = "";
                struct_TXSB.p_zdzbxt_zyxt = "";
                struct_TXSB.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_TXSB.p_gpdktxxt_sbpz = "";
                struct_TXSB.p_gpdktxxt_sbxds = "";
                struct_TXSB.p_gpdktxxt_txlx = "";
                struct_TXSB.p_gpdktxxt_tcjfrq = "";
                struct_TXSB.p_gpdktxxt_fspl = "";
                struct_TXSB.p_gpdktxxt_scgl = "";
                struct_TXSB.p_gpdktxxt_csfs = "";
                struct_TXSB.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_gpdktxxt_txjcgc = "";
                struct_TXSB.p_gpdktxxt_txgd = "";
                struct_TXSB.p_gpdktxxt_txszdd = "";
                struct_TXSB.p_gpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_gpdktxxt_txxh_lx = "";
                struct_TXSB.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //自动转报系统
            else if (struct_TXSB.p_sblx.Equals("0107"))
            {
                #region 自动转报系统 4个
                struct_TXSB.p_zdzbxt_xtpz = tbx_zdzbxt_xtpz.Text.Trim().ToString();
                struct_TXSB.p_zdzbxt_xtrjbb = tbx_zdzbxt_xtrjbb.Text.Trim().ToString();
                struct_TXSB.p_zdzbxt_zyxt = tbx_zdzbxt_zyxt.Text.Trim().ToString();
                struct_TXSB.p_zdzbxt_zdyhlb = tbx_zdzbxt_zdyhlb.Text.Trim().ToString();
                #region 将其他设备置空
                struct_TXSB.p_yyjly_xyyhs = "";
                struct_TXSB.p_yyjly_yyxds = "";
                struct_TXSB.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_TXSB.p_wxdmzxt_zdlx = "";
                struct_TXSB.p_wxdmzxt_txkj = "";
                struct_TXSB.p_wxdmzxt_swdygl = "";
                struct_TXSB.p_wxdmzxt_fspl = "";
                struct_TXSB.p_wxdmzxt_jspl = "";
                struct_TXSB.p_wxdmzxt_xds = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_wxdmzxt_txszdd = "";
                struct_TXSB.p_wxdmzxt_txjcgc = "";
                struct_TXSB.p_wxdmzxt_wxdtzzyxq = "";
                struct_TXSB.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_TXSB.p_sgpdktxxt_sbpz = "";
                struct_TXSB.p_sgpdktxxt_sbxds = "";
                struct_TXSB.p_sgpdktxxt_txlx = "";
                struct_TXSB.p_sgpdktxxt_tcjfrq = "";
                struct_TXSB.p_sgpdktxxt_fspl = "";
                struct_TXSB.p_sgpdktxxt_scgl = "";
                struct_TXSB.p_sgpdktxxt_csfs = "";
                struct_TXSB.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_sgpdktxxt_txjcgc = "";
                struct_TXSB.p_sgpdktxxt_txgd = "";
                struct_TXSB.p_sgpdktxxt_txszdd = "";
                struct_TXSB.p_sgpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_sgpdktxxt_txxh_lx = "";
                struct_TXSB.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_TXSB.p_yyjhxt_nh_xtpz = "";
                struct_TXSB.p_yyjhxt_nh_xwjtpz = "";
                struct_TXSB.p_yyjhxt_nh_xtrjbb = "";
                struct_TXSB.p_yyjhxt_nh_jksl_yx = "";
                struct_TXSB.p_yyjhxt_nh_jksl_wx = "";
                struct_TXSB.p_yyjhxt_nh_MFCxy = "";
                struct_TXSB.p_yyjhxt_nh_QSIGxy = "";
                struct_TXSB.p_yyjhxt_nh_IPxy = "";

                //高频地空通信系统
                struct_TXSB.p_gpdktxxt_sbpz = "";
                struct_TXSB.p_gpdktxxt_sbxds = "";
                struct_TXSB.p_gpdktxxt_txlx = "";
                struct_TXSB.p_gpdktxxt_tcjfrq = "";
                struct_TXSB.p_gpdktxxt_fspl = "";
                struct_TXSB.p_gpdktxxt_scgl = "";
                struct_TXSB.p_gpdktxxt_csfs = "";
                struct_TXSB.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_gpdktxxt_txjcgc = "";
                struct_TXSB.p_gpdktxxt_txgd = "";
                struct_TXSB.p_gpdktxxt_txszdd = "";
                struct_TXSB.p_gpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_gpdktxxt_txxh_lx = "";
                struct_TXSB.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //高频地空通信系统
            else if (struct_TXSB.p_sblx.Equals("0108"))
            {
                #region 高频地空通信系统 18个
                struct_TXSB.p_gpdktxxt_sbpz = ddlt_gpdktxxt_sbpz.SelectedValue.Trim().ToString();
                struct_TXSB.p_gpdktxxt_sbxds = tbx_gpdktxxt_sbxds.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_txlx = ddlt_gpdktxxt_txlx.SelectedValue.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tcjfrq = tbx_gpdktxxt_tcjfrq.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_fspl = tbx_gpdktxxt_fspl.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_scgl = tbx_gpdktxxt_scgl.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_csfs = tbx_gpdktxxt_csfs.Text.Trim().ToString();

                //文件上传
                if (!tbx_gpdktxxt_sc.HasFile)
                {
                    lbl_gpdktxxt_sc.Text = "请选择上传文件";
                    return;
                }
                if (tbx_gpdktxxt_sc.PostedFile.ContentLength > 10240000)
                {
                    lbl_gpdktxxt_sc.Text = "附件大小超出10Ｍ";
                    return;
                }
                //文件上传
                struct_TXSB.p_gpdktxxt_sc = tbx_gpdktxxt_sc.FileName;
                tbx_gpdktxxt_sc.PostedFile.SaveAs(path + tbx_gpdktxxt_sc.FileName);
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_jd = tbx_gpdktxxt_tzzb_bj54_jd.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_bj54_wd = tbx_gpdktxxt_tzzb_bj54_wd.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd = tbx_gpdktxxt_tzzb_wgs84_jd.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd = tbx_gpdktxxt_tzzb_wgs84_wd.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_txjcgc = tbx_gpdktxxt_txjcgc.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_txgd = tbx_gpdktxxt_txgd.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_txszdd = tbx_gpdktxxt_txszdd.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_wxdtzzyxq = tbx_gpdktxxt_wxdtzzyxq.Text.Trim().ToString();
                struct_TXSB.p_gpdktxxt_txsccj = tbx_gpdktxxt_txsccj.Text.Trim().ToString();

                struct_TXSB.p_gpdktxxt_txxh_lx = tbx_gpdktxxt_txxh_lx.Text.Trim().ToString();

                #region 将其他设备置空
                struct_TXSB.p_yyjly_xyyhs = "";
                struct_TXSB.p_yyjly_yyxds = "";
                struct_TXSB.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_TXSB.p_wxdmzxt_zdlx = "";
                struct_TXSB.p_wxdmzxt_txkj = "";
                struct_TXSB.p_wxdmzxt_swdygl = "";
                struct_TXSB.p_wxdmzxt_fspl = "";
                struct_TXSB.p_wxdmzxt_jspl = "";
                struct_TXSB.p_wxdmzxt_xds = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_wxdmzxt_txszdd = "";
                struct_TXSB.p_wxdmzxt_txjcgc = "";
                struct_TXSB.p_wxdmzxt_wxdtzzyxq = "";
                struct_TXSB.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_TXSB.p_sgpdktxxt_sbpz = "";
                struct_TXSB.p_sgpdktxxt_sbxds = "";
                struct_TXSB.p_sgpdktxxt_txlx = "";
                struct_TXSB.p_sgpdktxxt_tcjfrq = "";
                struct_TXSB.p_sgpdktxxt_fspl = "";
                struct_TXSB.p_sgpdktxxt_scgl = "";
                struct_TXSB.p_sgpdktxxt_csfs = "";
                struct_TXSB.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_TXSB.p_sgpdktxxt_txjcgc = "";
                struct_TXSB.p_sgpdktxxt_txgd = "";
                struct_TXSB.p_sgpdktxxt_txszdd = "";
                struct_TXSB.p_sgpdktxxt_wxdtzzyxq = "";
                struct_TXSB.p_sgpdktxxt_txxh_lx = "";
                struct_TXSB.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_TXSB.p_yyjhxt_nh_xtpz = "";
                struct_TXSB.p_yyjhxt_nh_xwjtpz = "";
                struct_TXSB.p_yyjhxt_nh_xtrjbb = "";
                struct_TXSB.p_yyjhxt_nh_jksl_yx = "";
                struct_TXSB.p_yyjhxt_nh_jksl_wx = "";
                struct_TXSB.p_yyjhxt_nh_MFCxy = "";
                struct_TXSB.p_yyjhxt_nh_QSIGxy = "";
                struct_TXSB.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_TXSB.p_zdzbxt_xtpz = "";
                struct_TXSB.p_zdzbxt_xtrjbb = "";
                struct_TXSB.p_zdzbxt_zyxt = "";
                struct_TXSB.p_zdzbxt_zdyhlb = "";
                #endregion
                #endregion
            }
            struct_TXSB.p_czfs = "02";
            struct_TXSB.p_czxx = "位置：设备管理->通信设备->添加   描述：员工编号：" + _usState.userLoginName;
            txsb.Insert_TXSB(struct_TXSB);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("TXSB_GL.aspx");
        }

        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;

            }
        }
        private void Creat_Shebei_number()
        {
            /*
            string tcrq = struct_txsb.p_tckfrq.Replace("-", "").Substring(0, 6);
            DataTable dt = txsb.Select_Max_txsbbh("02" + tcrq).Tables[0];
            string sbbh = utils.Creat_Shebei_number(dt, tcrq, "02");
            //tbx_sbbh.Text = sbbh;
            struct_txsb.p_sbbh = sbbh;
            */
        }
        private void Clear()
        {

        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("TXSB_GL.aspx");
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
            if (sblx.Equals("0101"))
            {
                div_sjl.Style.Add("display", "true");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0102"))
            {
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "true");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0103"))
            {
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "true");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0104"))
            {
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "true");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0105"))
            {
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "true");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0106"))
            {
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "true");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0107"))
            {
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "true");
                div_gpdktxxt.Style.Add("display", "none");
            }
            else if (sblx.Equals("0108"))
            {
                div_sjl.Style.Add("display", "none");
                div_sjtx.Style.Add("display", "none");
                div_yyjly.Style.Add("display", "none");
                div_wxdmzxt.Style.Add("display", "none");
                div_sgpdktxxt.Style.Add("display", "none");
                div_yyjhxt_nh.Style.Add("display", "none");
                div_zdzbxt.Style.Add("display", "none");
                div_gpdktxxt.Style.Add("display", "true");
            }
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sbbgr.DataSource = dt;
            ddlt_sbbgr.DataTextField = "xm";
            ddlt_sbbgr.DataValueField = "bh";
            ddlt_sbbgr.DataBind();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sbbgr.DataSource = dt;
            ddlt_sbbgr.DataTextField = "xm";
            ddlt_sbbgr.DataValueField = "bh";
            ddlt_sbbgr.DataBind();
        }

        protected void ddlt_jc_change(object sender, EventArgs e)
        {
            if (ddlt_jc.SelectedValue != "-1")
            {
                DataTable dt = SysData.TZLX_ZH(ddlt_jc.SelectedValue,"01");
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
                    ddlt_tzmczl.DataSource = SysData.TZLX_ZH("01").Copy();
                    ddlt_tzmczl.DataBind();
                    ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
                }
                else
                {
                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
                }
            }
            else {
                DataTable dt = SysData.TZLX_ZH("01");
                //台站名称种类 台站名称
                ddlt_tzmczl.DataTextField = "mc";
                ddlt_tzmczl.DataValueField = "bm";
                ddlt_tzmczl.DataSource = dt.Copy();
                ddlt_tzmczl.DataBind();
                ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
            }
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_sbbgr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_sbbgr.Items.Count > 0)
            {
                tbx_sbbgr.Text = ddlt_sbbgr.SelectedItem.Text;
                sbbgrbh = ddlt_sbbgr.SelectedValue.ToString();
            }
        }
    }
}