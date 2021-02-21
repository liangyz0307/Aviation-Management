using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Tools;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace CUST.WKG
{
    public partial class TXSB_Edit : System.Web.UI.Page
    {
        public string filepath;
        public string fpath;
        private string sjc;

        private UserState _usState;
        private DataTable dt_detail;
        private Struct_TXSB struct_txsb;
        public TXSB txsb;
        private int id;
        private string sbbgrbh;


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            txsb = new TXSB(_usState);
            if (!IsPostBack)
            {
                tbx_tckfsj.Attributes.Add("readonly", "readonly");
                tbx_dbsj.Attributes.Add("readonly", "readonly");
                tbx_sgpdktxxt_tcjfrq.Attributes.Add("readonly", "readonly");
                tbx_gpdktxxt_tcjfrq.Attributes.Add("readonly", "readonly");
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                yg_bind();
                ddltBind();
                select_detail();
            }
        }

        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"]);
            dt_detail = txsb.Select_TXSB_Detail(id);

            //数据所属部门 
            ddlt_sjssbm.SelectedValue = dt_detail.Rows[0]["sjssbm"].ToString();
            //设备类型
            //ddlt_sblx.SelectedValue = dt_detail.Rows[0]["sblx"].ToString();
            //台站名称
            ddlt_jc.SelectedValue = dt_detail.Rows[0]["ssjc"].ToString();
            //台站名称
            ddlt_tzmczl.SelectedValue = dt_detail.Rows[0]["ssjc"].ToString() + dt_detail.Rows[0]["wz"].ToString() + dt_detail.Rows[0]["sblx"].ToString();
            //投产开放时间
            tbx_tckfsj.Text = dt_detail.Rows[0]["tckfsj"].ToString();
            //数量
            tbx_sl.Text = dt_detail.Rows[0]["sl"].ToString();
            //设备编号
            tbx_sbbh.Text = dt_detail.Rows[0]["sbbh"].ToString();
            //设备状态
            ddlt_sbzt.SelectedValue = dt_detail.Rows[0]["sbzt"].ToString();
            //设备生产厂家
            tbx_sbsccj.Text = dt_detail.Rows[0]["sbsccj"].ToString();
            //设备出场编号
            tbx_sbccbh.Text = dt_detail.Rows[0]["sbccbh"].ToString();
            //设备许可证上传
            //lbl_sbxkzsc.Text = dt_detail.Rows[0]["sbxkzsc"].ToString();//文件
            //用途
            ddlt_yt.SelectedValue = dt_detail.Rows[0]["yt"].ToString();
            //交流供电
            tbx_jlgd.Text = dt_detail.Rows[0]["jlgd"].ToString();
            //交流供电大小
            tbx_jlgddx.Text = dt_detail.Rows[0]["jlgddx"].ToString();
            //交流供电数量
            tbx_jlgdsl.Text = dt_detail.Rows[0]["jlgdsl"].ToString();
            //直流供电
            tbx_zlgd.Text = dt_detail.Rows[0]["zlgd"].ToString();
            //直流供电大小
            tbx_zlgddx.Text = dt_detail.Rows[0]["zlgddx"].ToString();
            //直流供电数量
            tbx_zlgdsl.Text = dt_detail.Rows[0]["zlgdsl"].ToString();
            //保护区范围
            //lbl_bhqfw.Text = dt_detail.Rows[0]["bhqfw"].ToString();//文件
            //设备传输情况
            tbx_sbcsqk.Text = dt_detail.Rows[0]["sbcsqk"].ToString();
            //设备防雷配置
            tbx_sbflpz.Text = dt_detail.Rows[0]["sbflpz"].ToString();
            //现所属机场
            ddlt_xssjc.Text = dt_detail.Rows[0]["xssjc"].ToString();
            //调拨时间
            tbx_dbsj.Text = dt_detail.Rows[0]["dbsj"].ToString();
            //设备保管人
            tbx_sbbgr.Text = dt_detail.Rows[0]["sbbgrxm"].ToString();
            //初审人
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();
            //终审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();
            //设备型号
            tbx_sbxh.Text = dt_detail.Rows[0]["sbxh"].ToString();

            #region 数据链           
            //数据链
            if (dt_detail.Rows[0]["sblx"].ToString().Equals("0101"))
            {
                //div_sjl.Visible = false;
                div_sjtx.Visible = false;
                div_yyjly.Visible = false;
                div_wxdmzxt.Visible = false;
                div_sgpdktxxt.Visible = false;
                div_yyjhxt_nh.Visible = false;
                div_zdzbxt.Visible = false;
                div_gpdktxxt.Visible = false;
            }
            #endregion

            #region 数据通信            
            //数据通信
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0102"))
            {
                div_sjl.Visible = false;
                //div_sjtx.Visible = false;
                div_yyjly.Visible = false;
                div_wxdmzxt.Visible = false;
                div_sgpdktxxt.Visible = false;
                div_yyjhxt_nh.Visible = false;
                div_zdzbxt.Visible = false;
                div_gpdktxxt.Visible = false;
            }
            #endregion

            #region 语音记录仪
            //语音记录仪
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0103"))
            {
                div_sjl.Visible = false;
                div_sjtx.Visible = false;
                //div_yyjly.Visible = false;
                div_wxdmzxt.Visible = false;
                div_sgpdktxxt.Visible = false;
                div_yyjhxt_nh.Visible = false;
                div_zdzbxt.Visible = false;
                div_gpdktxxt.Visible = false;

                //现有用户数
                tbx_yyjly_xyyhs.Text = dt_detail.Rows[0]["yyjly_xyyhs"].ToString();
                //语音信道数
                tbx_yyjly_yyxds.Text = dt_detail.Rows[0]["yyjly_yyxds"].ToString();
                //数据信道数
                tbx_yyjly_sjxds.Text = dt_detail.Rows[0]["yyjly_sjxds"].ToString();

            }
            #endregion

            #region 卫星地面站系统
            //卫星地面站系统
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0104"))
            {
                div_sjl.Visible = false;
                div_sjtx.Visible = false;
                div_yyjly.Visible = false;
                //div_wxdmzxt.Visible = false;
                div_sgpdktxxt.Visible = false;
                div_yyjhxt_nh.Visible = false;
                div_zdzbxt.Visible = false;
                div_gpdktxxt.Visible = false;

                //站点类型
                ddlt_wxdmzxt_zdlx.SelectedValue = dt_detail.Rows[0]["wxdmzxt_zdlx"].ToString();
                //天线口径
                tbx_wxdmzxt_txkj.Text = dt_detail.Rows[0]["wxdmzxt_txkj"].ToString();
                //室外单元功率
                tbx_wxdmzxt_swdygl.Text = dt_detail.Rows[0]["wxdmzxt_swdygl"].ToString();
                //发射频率
                tbx_wxdmzxt_fspl.Text = dt_detail.Rows[0]["wxdmzxt_fspl"].ToString();
                //接收频率
                tbx_wxdmzxt_jspl.Text = dt_detail.Rows[0]["wxdmzxt_jspl"].ToString();
                //信道数
                tbx_wxdmzxt_xds.Text = dt_detail.Rows[0]["wxdmzxt_xds"].ToString();
                //台站坐标(北京54)经度
                tbx_wxdmzxt_tzzb_bj54_jd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_bj54_jd"].ToString();
                //台站坐标(北京54)纬度
                tbx_wxdmzxt_tzzb_bj54_wd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_bj54_wd"].ToString();
                //台站坐标(wgs84)经度
                tbx_wxdmzxt_tzzb_wgs84_jd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_wgs84_jd"].ToString();
                //台站坐标(wgs84)纬度
                tbx_wxdmzxt_tzzb_wgs84_wd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_wgs84_wd"].ToString();
                //天线设置地点
                tbx_wxdmzxt_txszdd.Text = dt_detail.Rows[0]["wxdmzxt_txszdd"].ToString();
                //天线基础高程
                tbx_wxdmzxt_txjcgc.Text = dt_detail.Rows[0]["wxdmzxt_txjcgc"].ToString();
                //天线电台执照有效期
                tbx_wxdmzxt_wxdtzzyxq.Text = dt_detail.Rows[0]["wxdmzxt_wxdtzzyxq"].ToString();
                //上传
                //lbl_wxdmzxt_sc.Text = dt_detail.Rows[0]["wxdmzxt_sc"].ToString();


            }
            #endregion

            #region 甚高频低空通信系统
            //甚高频低空通信系统
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0105"))
            {
                div_sjl.Visible = false;
                div_sjtx.Visible = false;
                div_yyjly.Visible = false;
                div_wxdmzxt.Visible = false;
                //div_sgpdktxxt.Visible = false;
                div_yyjhxt_nh.Visible = false;
                div_zdzbxt.Visible = false;
                div_gpdktxxt.Visible = false;

                //设备配置
                ddlt_sgpdktxxt_sbpz.SelectedValue =dt_detail.Rows[0]["sgpdktxxt_sbpz"].ToString();
                //设备信道数
                tbx_sgpdktxxt_sbxds.Text = dt_detail.Rows[0]["sgpdktxxt_sbxds"].ToString();
                //天线类型
                ddlt_sgpdktxxt_txlx.SelectedValue = dt_detail.Rows[0]["sgpdktxxt_txlx"].ToString();
                //投产校飞日期
                tbx_sgpdktxxt_tcjfrq.Text = dt_detail.Rows[0]["sgpdktxxt_tcjfrq"].ToString();
                //发射频率
                tbx_sgpdktxxt_fspl.Text = dt_detail.Rows[0]["sgpdktxxt_fspl"].ToString();
                //输出功率
                tbx_sgpdktxxt_scgl.Text = dt_detail.Rows[0]["sgpdktxxt_scgl"].ToString();
                //传输方式
                tbx_sgpdktxxt_csfs.Text = dt_detail.Rows[0]["sgpdktxxt_csfs"].ToString();
                //上传
                //lbl_sgpdktxxt_sc.Text = dt_detail.Rows[0]["sgpdktxxt_sc"].ToString();//文件
                //台站坐标(北京54)经度
                tbx_sgpdktxxt_tzzb_bj54_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_jd"].ToString();
                //台站坐标(wgs84)纬度
                tbx_sgpdktxxt_tzzb_bj54_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_wd"].ToString();
                //台站坐标(wgs84)经度
                tbx_sgpdktxxt_tzzb_wgs84_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_jd"].ToString();
                //台站坐标(wgs84)纬度
                tbx_sgpdktxxt_tzzb_wgs84_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_wd"].ToString();
                //天线基础高程
                tbx_sgpdktxxt_txjcgc.Text = dt_detail.Rows[0]["sgpdktxxt_txjcgc"].ToString();
                //天线高度
                tbx_sgpdktxxt_txgd.Text = dt_detail.Rows[0]["sgpdktxxt_txgd"].ToString();
                //天线设置地点
                tbx_sgpdktxxt_txszdd.Text = dt_detail.Rows[0]["sgpdktxxt_txszdd"].ToString();
                //无线电台执照有效期
                tbx_sgpdktxxt_wxdtzzyxq.Text = dt_detail.Rows[0]["sgpdktxxt_wxdtzzyxq"].ToString();
                //天线生产厂家
                tbx_sgpdktxxt_txsccj.Text = dt_detail.Rows[0]["sgpdktxxt_txsccj"].ToString();
                //天线型号
                tbx_sgpdktxxt_txxh_lx.Text = dt_detail.Rows[0]["sgpdktxxt_txxh_lx"].ToString();
            }
            #endregion

            #region 语音交换系统(内话)
            //语音交换系统(内话)
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0106"))
            {
                div_sjl.Visible = false;
                div_sjtx.Visible = false;
                div_yyjly.Visible = false;
                div_wxdmzxt.Visible = false;
                div_sgpdktxxt.Visible = false;
                //div_yyjhxt_nh.Visible = false;
                div_zdzbxt.Visible = false;
                div_gpdktxxt.Visible = false;

                //系统配置
                tbx_yyjhxt_nh_xtpz.Text = dt_detail.Rows[0]["yyjhxt_nh_xtpz"].ToString();
                //席位具体配置
                tbx_yyjhxt_nh_xwjtpz.Text = dt_detail.Rows[0]["yyjhxt_nh_xwjtpz"].ToString();
                //系统软件版本
                tbx_yyjhxt_nh_xtrjbb.Text = dt_detail.Rows[0]["yyjhxt_nh_xtrjbb"].ToString();
                //接口数量 有线
                tbx_yyjhxt_nh_jksl_yx.Text = dt_detail.Rows[0]["yyjhxt_nh_jksl_yx"].ToString();
                //接口数量 无线
                tbx_yyjhxt_nh_jksl_wx.Text = dt_detail.Rows[0]["yyjhxt_nh_jksl_wx"].ToString();
                //MFC协议
                ddlt_yyjhxt_nh_MFCxy.SelectedValue = dt_detail.Rows[0]["yyjhxt_nh_MFCxy"].ToString();
                //Q-SIG协议
                ddlt_yyjhxt_nh_QSIGxy.SelectedValue = dt_detail.Rows[0]["yyjhxt_nh_QSIGxy"].ToString();
                //IP协议
                ddlt_yyjhxt_nh_IPxy.SelectedValue = dt_detail.Rows[0]["yyjhxt_nh_IPxy"].ToString();


            }
            #endregion

            #region 自动转报系统
            //自动转报系统
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0107"))
            {
                div_sjl.Visible = false;
                div_sjtx.Visible = false;
                div_yyjly.Visible = false;
                div_wxdmzxt.Visible = false;
                div_sgpdktxxt.Visible = false;
                div_yyjhxt_nh.Visible = false;
                //div_zdzbxt.Visible = false;
                div_gpdktxxt.Visible = false;

                //系统配置
                tbx_zdzbxt_xtpz.Text = dt_detail.Rows[0]["zdzbxt_xtpz"].ToString();
                //系统软件版本
                tbx_zdzbxt_xtrjbb.Text = dt_detail.Rows[0]["zdzbxt_xtrjbb"].ToString();
                //在用系统
                tbx_zdzbxt_zyxt.Text = dt_detail.Rows[0]["zdzbxt_zyxt"].ToString();
                //终端用户列表
                tbx_zdzbxt_zdyhlb.Text = dt_detail.Rows[0]["zdzbxt_zdyhlb"].ToString();

            }
            #endregion

            #region 高频低空通信系统
            //高频低空通信系统
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0108"))
            {
                div_sjl.Visible = false;
                div_sjtx.Visible = false;
                div_yyjly.Visible = false;
                div_wxdmzxt.Visible = false;
                div_sgpdktxxt.Visible = false;
                div_yyjhxt_nh.Visible = false;
                div_zdzbxt.Visible = false;
                //div_gpdktxxt.Visible = false;

                //设备配置
                ddlt_gpdktxxt_sbpz.SelectedValue = dt_detail.Rows[0]["sgpdktxxt_sbpz"].ToString();
                //设备信道数
                tbx_gpdktxxt_sbxds.Text = dt_detail.Rows[0]["sgpdktxxt_sbxds"].ToString();
                //天线类型
                ddlt_gpdktxxt_txlx.SelectedValue = dt_detail.Rows[0]["sgpdktxxt_txlx"].ToString();
                //投产校飞日期
                tbx_gpdktxxt_tcjfrq.Text = dt_detail.Rows[0]["sgpdktxxt_tcjfrq"].ToString();
                //发射频率
                tbx_gpdktxxt_fspl.Text = dt_detail.Rows[0]["sgpdktxxt_fspl"].ToString();
                //输出功率
                tbx_gpdktxxt_scgl.Text = dt_detail.Rows[0]["sgpdktxxt_scgl"].ToString();
                //传输方式
                tbx_gpdktxxt_csfs.Text = dt_detail.Rows[0]["sgpdktxxt_csfs"].ToString();
                //上传
                //lbl_gpdktxxt_sc.Text = dt_detail.Rows[0]["sgpdktxxt_sc"].ToString();//文件
                //台站坐标(北京54)经度
                tbx_gpdktxxt_tzzb_bj54_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_jd"].ToString();
                //台站坐标(wgs84)纬度
                tbx_gpdktxxt_tzzb_bj54_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_wd"].ToString();
                //台站坐标(wgs84)经度
                tbx_gpdktxxt_tzzb_wgs84_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_jd"].ToString();
                //台站坐标(wgs84)纬度
                tbx_gpdktxxt_tzzb_wgs84_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_wd"].ToString();
                //天线基础高程
                tbx_gpdktxxt_txjcgc.Text = dt_detail.Rows[0]["sgpdktxxt_txjcgc"].ToString();
                //天线高度
                tbx_gpdktxxt_txgd.Text = dt_detail.Rows[0]["sgpdktxxt_txgd"].ToString();
                //天线设置地点
                tbx_sgpdktxxt_txszdd.Text = dt_detail.Rows[0]["sgpdktxxt_txszdd"].ToString();
                //无线电台执照有效期
                tbx_gpdktxxt_wxdtzzyxq.Text = dt_detail.Rows[0]["sgpdktxxt_wxdtzzyxq"].ToString();
                //天线生产厂家
                tbx_gpdktxxt_txsccj.Text = dt_detail.Rows[0]["sgpdktxxt_txsccj"].ToString();
                //天线型号
                tbx_gpdktxxt_txxh_lx.Text = dt_detail.Rows[0]["sgpdktxxt_txxh_lx"].ToString();
            }
            #endregion
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.Params["id"]);

            //判断是否有该路径  
            string path = Server.MapPath("../Shebei/UpLoads/SBGL/TXSB/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            #region lable判断
            int flag = 0;
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
            //台站名称
            if (ddlt_tzmczl.SelectedValue == "-1")
            {
                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
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

            if (!tbx_bhqfw.HasFile)
            {
                lbl_bhqfw.Text = "请选择上传文件";
                return;
            }
            if (!tbx_sbxkzsc.HasFile)
            {
                lbl_bhqfw.Text = "请选择上传文件";
                return;
            }
            if (tbx_bhqfw.PostedFile.ContentLength > 10240000)
            {
                lbl_bhqfw.Text = "附件大小超出10Ｍ";
                return;
            }
            if (tbx_sbxkzsc.PostedFile.ContentLength > 10240000)
            {
                lbl_sbxkzsc.Text = "附件大小超出10Ｍ";
                return;
            }
            //基本信息
            struct_txsb.p_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
            struct_txsb.p_wz = ddlt_tzmczl.SelectedValue.ToString().Substring(2, 2);
            struct_txsb.p_ssjc = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
            struct_txsb.p_tckfsj = tbx_tckfsj.Text.Trim().ToString();
            struct_txsb.p_sl = tbx_sl.Text.Trim().ToString();
            struct_txsb.p_sbzt = ddlt_sbzt.SelectedValue.Trim().ToString();
            struct_txsb.p_sbsccj = tbx_sbsccj.Text.Trim().ToString();
            struct_txsb.p_sbccbh = tbx_sbccbh.Text.Trim().ToString();
            struct_txsb.p_yt = ddlt_yt.SelectedValue.Trim().ToString();
            struct_txsb.p_jlgd = tbx_jlgd.Text.Trim().ToString();
            struct_txsb.p_jlgddx = tbx_jlgddx.Text.Trim().ToString();
            struct_txsb.p_jlgdsl = tbx_jlgdsl.Text.Trim().ToString();
            struct_txsb.p_zlgd = tbx_zlgd.Text.Trim().ToString();
            struct_txsb.p_zlgddx = tbx_zlgddx.Text.Trim().ToString();
            struct_txsb.p_zlgdsl = tbx_zlgdsl.Text.Trim().ToString();
            struct_txsb.p_sbcsqk = tbx_sbcsqk.Text.Trim().ToString();
            struct_txsb.p_sbflpz = tbx_sbflpz.Text.Trim().ToString();
            struct_txsb.p_xssjc = ddlt_xssjc.SelectedValue.Trim().ToString();
            struct_txsb.p_dbsj = tbx_dbsj.Text.Trim().ToString();
            struct_txsb.p_sbbgr = ddlt_sbbgr.SelectedValue.Trim().ToString();
            struct_txsb.p_bhqfw = tbx_bhqfw.FileName;//保护区范围
            struct_txsb.p_sbxkzsc = tbx_sbxkzsc.FileName;//设备许可证上传
            //上传文件
            tbx_bhqfw.PostedFile.SaveAs(path + tbx_bhqfw.FileName);
            tbx_sbxkzsc.PostedFile.SaveAs(path + tbx_sbxkzsc.FileName);

            //时间戳
            struct_txsb.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_txsb.p_sbbh = tbx_sbbh.Text.ToString();
            struct_txsb.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_txsb.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_txsb.p_sjssbm = ddlt_sjssbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_txsb.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_txsb.p_sbxh = tbx_sbxh.Text;//设备型号
            struct_txsb.p_id = id;//ID
            //设备类型详细添加
            if (struct_txsb.p_sblx.Equals("0101") || struct_txsb.p_sblx.Equals("0102"))
            {
                #region 将其他设备置空
                struct_txsb.p_yyjly_xyyhs = "";
                struct_txsb.p_yyjly_yyxds = "";
                struct_txsb.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_txsb.p_wxdmzxt_zdlx = "";
                struct_txsb.p_wxdmzxt_txkj = "";
                struct_txsb.p_wxdmzxt_swdygl = "";
                struct_txsb.p_wxdmzxt_fspl = "";
                struct_txsb.p_wxdmzxt_jspl = "";
                struct_txsb.p_wxdmzxt_xds = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_txsb.p_wxdmzxt_txszdd = "";
                struct_txsb.p_wxdmzxt_txjcgc = "";
                struct_txsb.p_wxdmzxt_wxdtzzyxq = "";
                struct_txsb.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_txsb.p_sgpdktxxt_sbpz = "";
                struct_txsb.p_sgpdktxxt_sbxds = "";
                struct_txsb.p_sgpdktxxt_txlx = "";
                struct_txsb.p_sgpdktxxt_tcjfrq = "";
                struct_txsb.p_sgpdktxxt_fspl = "";
                struct_txsb.p_sgpdktxxt_scgl = "";
                struct_txsb.p_sgpdktxxt_csfs = "";
                struct_txsb.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_sgpdktxxt_txjcgc = "";
                struct_txsb.p_sgpdktxxt_txgd = "";
                struct_txsb.p_sgpdktxxt_txszdd = "";
                struct_txsb.p_sgpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_sgpdktxxt_txxh_lx = "";
                struct_txsb.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_txsb.p_yyjhxt_nh_xtpz = "";
                struct_txsb.p_yyjhxt_nh_xwjtpz = "";
                struct_txsb.p_yyjhxt_nh_xtrjbb = "";
                struct_txsb.p_yyjhxt_nh_jksl_yx = "";
                struct_txsb.p_yyjhxt_nh_jksl_wx = "";
                struct_txsb.p_yyjhxt_nh_MFCxy = "";
                struct_txsb.p_yyjhxt_nh_QSIGxy = "";
                struct_txsb.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_txsb.p_zdzbxt_xtpz = "";
                struct_txsb.p_zdzbxt_xtrjbb = "";
                struct_txsb.p_zdzbxt_zyxt = "";
                struct_txsb.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_txsb.p_gpdktxxt_sbpz = "";
                struct_txsb.p_gpdktxxt_sbxds = "";
                struct_txsb.p_gpdktxxt_txlx = "";
                struct_txsb.p_gpdktxxt_tcjfrq = "";
                struct_txsb.p_gpdktxxt_fspl = "";
                struct_txsb.p_gpdktxxt_scgl = "";
                struct_txsb.p_gpdktxxt_csfs = "";
                struct_txsb.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_gpdktxxt_txjcgc = "";
                struct_txsb.p_gpdktxxt_txgd = "";
                struct_txsb.p_gpdktxxt_txszdd = "";
                struct_txsb.p_gpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_gpdktxxt_txxh_lx = "";
                struct_txsb.p_gpdktxxt_txsccj = "";
                #endregion
            }
            //语音记录仪
            else if (struct_txsb.p_sblx.Equals("0103"))
            {
                #region 语音记录仪
                struct_txsb.p_yyjly_xyyhs = tbx_yyjly_xyyhs.Text.Trim().ToString();
                struct_txsb.p_yyjly_yyxds = tbx_yyjly_yyxds.Text.Trim().ToString();
                struct_txsb.p_yyjly_sjxds = tbx_yyjly_sjxds.Text.Trim().ToString();

                #region 将其他设备置空
                //卫星地面站系统
                struct_txsb.p_wxdmzxt_zdlx = "";
                struct_txsb.p_wxdmzxt_txkj = "";
                struct_txsb.p_wxdmzxt_swdygl = "";
                struct_txsb.p_wxdmzxt_fspl = "";
                struct_txsb.p_wxdmzxt_jspl = "";
                struct_txsb.p_wxdmzxt_xds = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_txsb.p_wxdmzxt_txszdd = "";
                struct_txsb.p_wxdmzxt_txjcgc = "";
                struct_txsb.p_wxdmzxt_wxdtzzyxq = "";
                struct_txsb.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_txsb.p_sgpdktxxt_sbpz = "";
                struct_txsb.p_sgpdktxxt_sbxds = "";
                struct_txsb.p_sgpdktxxt_txlx = "";
                struct_txsb.p_sgpdktxxt_tcjfrq = "";
                struct_txsb.p_sgpdktxxt_fspl = "";
                struct_txsb.p_sgpdktxxt_scgl = "";
                struct_txsb.p_sgpdktxxt_csfs = "";
                struct_txsb.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_sgpdktxxt_txjcgc = "";
                struct_txsb.p_sgpdktxxt_txgd = "";
                struct_txsb.p_sgpdktxxt_txszdd = "";
                struct_txsb.p_sgpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_sgpdktxxt_txxh_lx = "";
                struct_txsb.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_txsb.p_yyjhxt_nh_xtpz = "";
                struct_txsb.p_yyjhxt_nh_xwjtpz = "";
                struct_txsb.p_yyjhxt_nh_xtrjbb = "";
                struct_txsb.p_yyjhxt_nh_jksl_yx = "";
                struct_txsb.p_yyjhxt_nh_jksl_wx = "";
                struct_txsb.p_yyjhxt_nh_MFCxy = "";
                struct_txsb.p_yyjhxt_nh_QSIGxy = "";
                struct_txsb.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_txsb.p_zdzbxt_xtpz = "";
                struct_txsb.p_zdzbxt_xtrjbb = "";
                struct_txsb.p_zdzbxt_zyxt = "";
                struct_txsb.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_txsb.p_gpdktxxt_sbpz = "";
                struct_txsb.p_gpdktxxt_sbxds = "";
                struct_txsb.p_gpdktxxt_txlx = "";
                struct_txsb.p_gpdktxxt_tcjfrq = "";
                struct_txsb.p_gpdktxxt_fspl = "";
                struct_txsb.p_gpdktxxt_scgl = "";
                struct_txsb.p_gpdktxxt_csfs = "";
                struct_txsb.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_gpdktxxt_txjcgc = "";
                struct_txsb.p_gpdktxxt_txgd = "";
                struct_txsb.p_gpdktxxt_txszdd = "";
                struct_txsb.p_gpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_gpdktxxt_txxh_lx = "";
                struct_txsb.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //卫星地面站系统
            else if (struct_txsb.p_sblx.Equals("0104"))
            {
                #region 卫星地面站系统
                struct_txsb.p_wxdmzxt_zdlx = ddlt_wxdmzxt_zdlx.SelectedValue.Trim().ToString();
                struct_txsb.p_wxdmzxt_txkj = tbx_wxdmzxt_txkj.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_swdygl = tbx_wxdmzxt_swdygl.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_fspl = tbx_wxdmzxt_fspl.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_jspl = tbx_wxdmzxt_jspl.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_xds = tbx_wxdmzxt_xds.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_tzzb_bj54_jd = tbx_wxdmzxt_tzzb_bj54_jd.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_tzzb_bj54_wd = tbx_wxdmzxt_tzzb_bj54_wd.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_tzzb_wgs84_jd = tbx_wxdmzxt_tzzb_wgs84_jd.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_tzzb_wgs84_wd = tbx_wxdmzxt_tzzb_wgs84_wd.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_txszdd = tbx_wxdmzxt_txszdd.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_txjcgc = tbx_wxdmzxt_txjcgc.Text.Trim().ToString();
                struct_txsb.p_wxdmzxt_wxdtzzyxq = tbx_wxdmzxt_wxdtzzyxq.Text.Trim().ToString();

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
                struct_txsb.p_wxdmzxt_sc = tbx_wxdmzxt_sc.FileName;//上传
                //上传文件
                tbx_wxdmzxt_sc.PostedFile.SaveAs(path + tbx_wxdmzxt_sc.FileName);

                #region 将其他设备置空
                struct_txsb.p_yyjly_xyyhs = "";
                struct_txsb.p_yyjly_yyxds = "";
                struct_txsb.p_yyjly_sjxds = "";

                //甚高频地空通信系统
                struct_txsb.p_sgpdktxxt_sbpz = "";
                struct_txsb.p_sgpdktxxt_sbxds = "";
                struct_txsb.p_sgpdktxxt_txlx = "";
                struct_txsb.p_sgpdktxxt_tcjfrq = "";
                struct_txsb.p_sgpdktxxt_fspl = "";
                struct_txsb.p_sgpdktxxt_scgl = "";
                struct_txsb.p_sgpdktxxt_csfs = "";
                struct_txsb.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_sgpdktxxt_txjcgc = "";
                struct_txsb.p_sgpdktxxt_txgd = "";
                struct_txsb.p_sgpdktxxt_txszdd = "";
                struct_txsb.p_sgpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_sgpdktxxt_txxh_lx = "";
                struct_txsb.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_txsb.p_yyjhxt_nh_xtpz = "";
                struct_txsb.p_yyjhxt_nh_xwjtpz = "";
                struct_txsb.p_yyjhxt_nh_xtrjbb = "";
                struct_txsb.p_yyjhxt_nh_jksl_yx = "";
                struct_txsb.p_yyjhxt_nh_jksl_wx = "";
                struct_txsb.p_yyjhxt_nh_MFCxy = "";
                struct_txsb.p_yyjhxt_nh_QSIGxy = "";
                struct_txsb.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_txsb.p_zdzbxt_xtpz = "";
                struct_txsb.p_zdzbxt_xtrjbb = "";
                struct_txsb.p_zdzbxt_zyxt = "";
                struct_txsb.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_txsb.p_gpdktxxt_sbpz = "";
                struct_txsb.p_gpdktxxt_sbxds = "";
                struct_txsb.p_gpdktxxt_txlx = "";
                struct_txsb.p_gpdktxxt_tcjfrq = "";
                struct_txsb.p_gpdktxxt_fspl = "";
                struct_txsb.p_gpdktxxt_scgl = "";
                struct_txsb.p_gpdktxxt_csfs = "";
                struct_txsb.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_gpdktxxt_txjcgc = "";
                struct_txsb.p_gpdktxxt_txgd = "";
                struct_txsb.p_gpdktxxt_txszdd = "";
                struct_txsb.p_gpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_gpdktxxt_txxh_lx = "";
                struct_txsb.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //甚高频地空通信系统
            else if (struct_txsb.p_sblx.Equals("0105"))
            {
                #region 甚高频地空通信系统
                struct_txsb.p_sgpdktxxt_sbpz = ddlt_sgpdktxxt_sbpz.SelectedValue.Trim().ToString();
                struct_txsb.p_sgpdktxxt_sbxds = tbx_sgpdktxxt_sbxds.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_txlx = ddlt_sgpdktxxt_txlx.SelectedValue.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tcjfrq = tbx_sgpdktxxt_tcjfrq.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_fspl = tbx_sgpdktxxt_fspl.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_scgl = tbx_sgpdktxxt_scgl.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_csfs = tbx_sgpdktxxt_csfs.Text.Trim().ToString();

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
                //文件上传
                struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.FileName;
                tbx_sgpdktxxt_sc.PostedFile.SaveAs(path + tbx_sgpdktxxt_sc.FileName);
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_jd = tbx_sgpdktxxt_tzzb_bj54_jd.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_wd = tbx_sgpdktxxt_tzzb_bj54_wd.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_jd = tbx_sgpdktxxt_tzzb_wgs84_jd.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_wd = tbx_sgpdktxxt_tzzb_wgs84_wd.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_txjcgc = tbx_sgpdktxxt_txjcgc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_txgd = tbx_sgpdktxxt_txgd.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_txszdd = tbx_sgpdktxxt_txszdd.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_wxdtzzyxq = tbx_sgpdktxxt_wxdtzzyxq.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_txsccj = tbx_sgpdktxxt_txsccj.Text.Trim().ToString();

                struct_txsb.p_sgpdktxxt_txxh_lx = tbx_sgpdktxxt_txxh_lx.Text.Trim().ToString();

                #region 将其他设备置空
                struct_txsb.p_yyjly_xyyhs = "";
                struct_txsb.p_yyjly_yyxds = "";
                struct_txsb.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_txsb.p_wxdmzxt_zdlx = "";
                struct_txsb.p_wxdmzxt_txkj = "";
                struct_txsb.p_wxdmzxt_swdygl = "";
                struct_txsb.p_wxdmzxt_fspl = "";
                struct_txsb.p_wxdmzxt_jspl = "";
                struct_txsb.p_wxdmzxt_xds = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_txsb.p_wxdmzxt_txszdd = "";
                struct_txsb.p_wxdmzxt_txjcgc = "";
                struct_txsb.p_wxdmzxt_wxdtzzyxq = "";
                struct_txsb.p_wxdmzxt_sc = "";//上传

                //语音交换系统（内话）
                struct_txsb.p_yyjhxt_nh_xtpz = "";
                struct_txsb.p_yyjhxt_nh_xwjtpz = "";
                struct_txsb.p_yyjhxt_nh_xtrjbb = "";
                struct_txsb.p_yyjhxt_nh_jksl_yx = "";
                struct_txsb.p_yyjhxt_nh_jksl_wx = "";
                struct_txsb.p_yyjhxt_nh_MFCxy = "";
                struct_txsb.p_yyjhxt_nh_QSIGxy = "";
                struct_txsb.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_txsb.p_zdzbxt_xtpz = "";
                struct_txsb.p_zdzbxt_xtrjbb = "";
                struct_txsb.p_zdzbxt_zyxt = "";
                struct_txsb.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_txsb.p_gpdktxxt_sbpz = "";
                struct_txsb.p_gpdktxxt_sbxds = "";
                struct_txsb.p_gpdktxxt_txlx = "";
                struct_txsb.p_gpdktxxt_tcjfrq = "";
                struct_txsb.p_gpdktxxt_fspl = "";
                struct_txsb.p_gpdktxxt_scgl = "";
                struct_txsb.p_gpdktxxt_csfs = "";
                struct_txsb.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_gpdktxxt_txjcgc = "";
                struct_txsb.p_gpdktxxt_txgd = "";
                struct_txsb.p_gpdktxxt_txszdd = "";
                struct_txsb.p_gpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_gpdktxxt_txxh_lx = "";
                struct_txsb.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //语音交换系统（内话）
            else if (struct_txsb.p_sblx.Equals("0106"))
            {
                #region 语音交换系统（内话）
                struct_txsb.p_yyjhxt_nh_xtpz = tbx_yyjhxt_nh_xtpz.Text.Trim().ToString();
                struct_txsb.p_yyjhxt_nh_xwjtpz = tbx_yyjhxt_nh_xwjtpz.Text.Trim().ToString();
                struct_txsb.p_yyjhxt_nh_xtrjbb = tbx_yyjhxt_nh_xtrjbb.Text.Trim().ToString();
                struct_txsb.p_yyjhxt_nh_jksl_yx = tbx_yyjhxt_nh_jksl_yx.Text.Trim().ToString();
                struct_txsb.p_yyjhxt_nh_jksl_wx = tbx_yyjhxt_nh_jksl_wx.Text.Trim().ToString();
                struct_txsb.p_yyjhxt_nh_MFCxy = ddlt_yyjhxt_nh_MFCxy.SelectedValue.Trim().ToString();
                struct_txsb.p_yyjhxt_nh_QSIGxy = ddlt_yyjhxt_nh_QSIGxy.SelectedValue.Trim().ToString();
                struct_txsb.p_yyjhxt_nh_IPxy = ddlt_yyjhxt_nh_IPxy.SelectedValue.Trim().ToString();

                #region 将其他设备置空
                struct_txsb.p_yyjly_xyyhs = "";
                struct_txsb.p_yyjly_yyxds = "";
                struct_txsb.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_txsb.p_wxdmzxt_zdlx = "";
                struct_txsb.p_wxdmzxt_txkj = "";
                struct_txsb.p_wxdmzxt_swdygl = "";
                struct_txsb.p_wxdmzxt_fspl = "";
                struct_txsb.p_wxdmzxt_jspl = "";
                struct_txsb.p_wxdmzxt_xds = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_txsb.p_wxdmzxt_txszdd = "";
                struct_txsb.p_wxdmzxt_txjcgc = "";
                struct_txsb.p_wxdmzxt_wxdtzzyxq = "";
                struct_txsb.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_txsb.p_sgpdktxxt_sbpz = "";
                struct_txsb.p_sgpdktxxt_sbxds = "";
                struct_txsb.p_sgpdktxxt_txlx = "";
                struct_txsb.p_sgpdktxxt_tcjfrq = "";
                struct_txsb.p_sgpdktxxt_fspl = "";
                struct_txsb.p_sgpdktxxt_scgl = "";
                struct_txsb.p_sgpdktxxt_csfs = "";
                struct_txsb.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_sgpdktxxt_txjcgc = "";
                struct_txsb.p_sgpdktxxt_txgd = "";
                struct_txsb.p_sgpdktxxt_txszdd = "";
                struct_txsb.p_sgpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_sgpdktxxt_txxh_lx = "";
                struct_txsb.p_sgpdktxxt_txsccj = "";

                //自动转报系统
                struct_txsb.p_zdzbxt_xtpz = "";
                struct_txsb.p_zdzbxt_xtrjbb = "";
                struct_txsb.p_zdzbxt_zyxt = "";
                struct_txsb.p_zdzbxt_zdyhlb = "";

                //高频地空通信系统
                struct_txsb.p_gpdktxxt_sbpz = "";
                struct_txsb.p_gpdktxxt_sbxds = "";
                struct_txsb.p_gpdktxxt_txlx = "";
                struct_txsb.p_gpdktxxt_tcjfrq = "";
                struct_txsb.p_gpdktxxt_fspl = "";
                struct_txsb.p_gpdktxxt_scgl = "";
                struct_txsb.p_gpdktxxt_csfs = "";
                struct_txsb.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_gpdktxxt_txjcgc = "";
                struct_txsb.p_gpdktxxt_txgd = "";
                struct_txsb.p_gpdktxxt_txszdd = "";
                struct_txsb.p_gpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_gpdktxxt_txxh_lx = "";
                struct_txsb.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //自动转报系统
            else if (struct_txsb.p_sblx.Equals("0107"))
            {
                #region 自动转报系统
                struct_txsb.p_zdzbxt_xtpz = tbx_zdzbxt_xtpz.Text.Trim().ToString();
                struct_txsb.p_zdzbxt_xtrjbb = tbx_zdzbxt_xtrjbb.Text.Trim().ToString();
                struct_txsb.p_zdzbxt_zyxt = tbx_zdzbxt_zyxt.Text.Trim().ToString();
                struct_txsb.p_zdzbxt_zdyhlb = tbx_zdzbxt_zdyhlb.Text.Trim().ToString();
                #region 将其他设备置空
                struct_txsb.p_yyjly_xyyhs = "";
                struct_txsb.p_yyjly_yyxds = "";
                struct_txsb.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_txsb.p_wxdmzxt_zdlx = "";
                struct_txsb.p_wxdmzxt_txkj = "";
                struct_txsb.p_wxdmzxt_swdygl = "";
                struct_txsb.p_wxdmzxt_fspl = "";
                struct_txsb.p_wxdmzxt_jspl = "";
                struct_txsb.p_wxdmzxt_xds = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_txsb.p_wxdmzxt_txszdd = "";
                struct_txsb.p_wxdmzxt_txjcgc = "";
                struct_txsb.p_wxdmzxt_wxdtzzyxq = "";
                struct_txsb.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_txsb.p_sgpdktxxt_sbpz = "";
                struct_txsb.p_sgpdktxxt_sbxds = "";
                struct_txsb.p_sgpdktxxt_txlx = "";
                struct_txsb.p_sgpdktxxt_tcjfrq = "";
                struct_txsb.p_sgpdktxxt_fspl = "";
                struct_txsb.p_sgpdktxxt_scgl = "";
                struct_txsb.p_sgpdktxxt_csfs = "";
                struct_txsb.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_sgpdktxxt_txjcgc = "";
                struct_txsb.p_sgpdktxxt_txgd = "";
                struct_txsb.p_sgpdktxxt_txszdd = "";
                struct_txsb.p_sgpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_sgpdktxxt_txxh_lx = "";
                struct_txsb.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_txsb.p_yyjhxt_nh_xtpz = "";
                struct_txsb.p_yyjhxt_nh_xwjtpz = "";
                struct_txsb.p_yyjhxt_nh_xtrjbb = "";
                struct_txsb.p_yyjhxt_nh_jksl_yx = "";
                struct_txsb.p_yyjhxt_nh_jksl_wx = "";
                struct_txsb.p_yyjhxt_nh_MFCxy = "";
                struct_txsb.p_yyjhxt_nh_QSIGxy = "";
                struct_txsb.p_yyjhxt_nh_IPxy = "";

                //高频地空通信系统
                struct_txsb.p_gpdktxxt_sbpz = "";
                struct_txsb.p_gpdktxxt_sbxds = "";
                struct_txsb.p_gpdktxxt_txlx = "";
                struct_txsb.p_gpdktxxt_tcjfrq = "";
                struct_txsb.p_gpdktxxt_fspl = "";
                struct_txsb.p_gpdktxxt_scgl = "";
                struct_txsb.p_gpdktxxt_csfs = "";
                struct_txsb.p_gpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_gpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_gpdktxxt_txjcgc = "";
                struct_txsb.p_gpdktxxt_txgd = "";
                struct_txsb.p_gpdktxxt_txszdd = "";
                struct_txsb.p_gpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_gpdktxxt_txxh_lx = "";
                struct_txsb.p_gpdktxxt_txsccj = "";
                #endregion
                #endregion
            }
            //高频地空通信系统
            else if (struct_txsb.p_sblx.Equals("0108"))
            {
                #region 高频地空通信系统
                struct_txsb.p_gpdktxxt_sbpz = ddlt_gpdktxxt_sbpz.SelectedValue.Trim().ToString();
                struct_txsb.p_gpdktxxt_sbxds = tbx_gpdktxxt_sbxds.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_txlx = ddlt_gpdktxxt_txlx.SelectedValue.Trim().ToString();
                struct_txsb.p_gpdktxxt_tcjfrq = tbx_gpdktxxt_tcjfrq.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_fspl = tbx_gpdktxxt_fspl.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_scgl = tbx_gpdktxxt_scgl.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_csfs = tbx_gpdktxxt_csfs.Text.Trim().ToString();

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
                struct_txsb.p_gpdktxxt_sc = tbx_gpdktxxt_sc.FileName;
                tbx_gpdktxxt_sc.PostedFile.SaveAs(path + tbx_gpdktxxt_sc.FileName);
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_jd = tbx_gpdktxxt_tzzb_bj54_jd.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_bj54_wd = tbx_gpdktxxt_tzzb_bj54_wd.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_wgs84_jd = tbx_gpdktxxt_tzzb_wgs84_jd.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_tzzb_wgs84_wd = tbx_gpdktxxt_tzzb_wgs84_wd.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_txjcgc = tbx_gpdktxxt_txjcgc.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_txgd = tbx_gpdktxxt_txgd.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_txszdd = tbx_gpdktxxt_txszdd.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_wxdtzzyxq = tbx_gpdktxxt_wxdtzzyxq.Text.Trim().ToString();
                struct_txsb.p_gpdktxxt_txsccj = tbx_gpdktxxt_txsccj.Text.Trim().ToString();

                struct_txsb.p_gpdktxxt_txxh_lx = tbx_gpdktxxt_txxh_lx.Text.Trim().ToString();

                #region 将其他设备置空
                struct_txsb.p_yyjly_xyyhs = "";
                struct_txsb.p_yyjly_yyxds = "";
                struct_txsb.p_yyjly_sjxds = "";
                //卫星地面站系统
                struct_txsb.p_wxdmzxt_zdlx = "";
                struct_txsb.p_wxdmzxt_txkj = "";
                struct_txsb.p_wxdmzxt_swdygl = "";
                struct_txsb.p_wxdmzxt_fspl = "";
                struct_txsb.p_wxdmzxt_jspl = "";
                struct_txsb.p_wxdmzxt_xds = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_bj54_wd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_jd = "";
                struct_txsb.p_wxdmzxt_tzzb_wgs84_wd = "";
                struct_txsb.p_wxdmzxt_txszdd = "";
                struct_txsb.p_wxdmzxt_txjcgc = "";
                struct_txsb.p_wxdmzxt_wxdtzzyxq = "";
                struct_txsb.p_wxdmzxt_sc = "";//上传

                //甚高频地空通信系统
                struct_txsb.p_sgpdktxxt_sbpz = "";
                struct_txsb.p_sgpdktxxt_sbxds = "";
                struct_txsb.p_sgpdktxxt_txlx = "";
                struct_txsb.p_sgpdktxxt_tcjfrq = "";
                struct_txsb.p_sgpdktxxt_fspl = "";
                struct_txsb.p_sgpdktxxt_scgl = "";
                struct_txsb.p_sgpdktxxt_csfs = "";
                struct_txsb.p_sgpdktxxt_sc = "";
                //struct_txsb.p_sgpdktxxt_sc = tbx_sgpdktxxt_sc.Text.Trim().ToString();
                struct_txsb.p_sgpdktxxt_tzzb_bj54_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_bj54_wd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_jd = "";
                struct_txsb.p_sgpdktxxt_tzzb_wgs84_wd = "";
                struct_txsb.p_sgpdktxxt_txjcgc = "";
                struct_txsb.p_sgpdktxxt_txgd = "";
                struct_txsb.p_sgpdktxxt_txszdd = "";
                struct_txsb.p_sgpdktxxt_wxdtzzyxq = "";
                struct_txsb.p_sgpdktxxt_txxh_lx = "";
                struct_txsb.p_sgpdktxxt_txsccj = "";

                //语音交换系统（内话）
                struct_txsb.p_yyjhxt_nh_xtpz = "";
                struct_txsb.p_yyjhxt_nh_xwjtpz = "";
                struct_txsb.p_yyjhxt_nh_xtrjbb = "";
                struct_txsb.p_yyjhxt_nh_jksl_yx = "";
                struct_txsb.p_yyjhxt_nh_jksl_wx = "";
                struct_txsb.p_yyjhxt_nh_MFCxy = "";
                struct_txsb.p_yyjhxt_nh_QSIGxy = "";
                struct_txsb.p_yyjhxt_nh_IPxy = "";

                //自动转报系统
                struct_txsb.p_zdzbxt_xtpz = "";
                struct_txsb.p_zdzbxt_xtrjbb = "";
                struct_txsb.p_zdzbxt_zyxt = "";
                struct_txsb.p_zdzbxt_zdyhlb = "";
                #endregion
                #endregion
            }

            struct_txsb.p_czfs = "02";
            struct_txsb.p_czxx = "位置：设备管理->通信设备->添加   描述：员工编号：" + _usState.userLoginName;
            
            //审批流程
            string sjbs = Request.Params["sjbs"].ToString();
            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_txsb.p_lrr.Equals(struct_txsb.p_csr))
                {
                    struct_txsb.p_zt = "2";
                    struct_txsb.p_sjbs = "0";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_txsb.p_lrr.Equals(struct_txsb.p_zsr))
                {
                    struct_txsb.p_zt = "3";
                    struct_txsb.p_sjbs = "1";
                }
                if (!struct_txsb.p_lrr.Equals(struct_txsb.p_csr) && !struct_txsb.p_lrr.Equals(struct_txsb.p_zsr))
                {
                    struct_txsb.p_zt = "0";
                    struct_txsb.p_sjbs = "0";
                }
                txsb.Update_TXSB(struct_txsb);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("TXSB_GL.aspx?ygbh=" + _usState.userLoginName);
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_txsb.p_lrr.Equals(struct_txsb.p_csr))
                {
                    struct_txsb.p_zt = "2";
                    struct_txsb.p_sjbs = "2";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_txsb.p_lrr.Equals(struct_txsb.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_txsb.p_sjc = sjc;
                    txsb.Update_TXSB_SJBS_LSSJ_ZT(struct_txsb);

                    struct_txsb.p_zt = "3";
                    struct_txsb.p_sjbs = "1";
                }
                if (!struct_txsb.p_lrr.Equals(struct_txsb.p_csr) && !struct_txsb.p_lrr.Equals(struct_txsb.p_zsr))
                {
                    struct_txsb.p_zt = "0";
                    struct_txsb.p_sjbs = "2";
                }
                txsb.Update_TXSB(struct_txsb);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("TXSB_GL.aspx?ygbh=" + _usState.userLoginName);
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = txsb.TXSB_SJBF(Convert.ToInt32(id));
                struct_txsb.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_txsb.p_lrr.Equals(struct_txsb.p_csr))
                {
                    struct_txsb.p_zt = "2";
                    struct_txsb.p_sjbs = "2";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_txsb.p_lrr.Equals(struct_txsb.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_txsb.p_sjc = sjc;
                    txsb.Update_TXSB_SJBS_LSSJ_ZT(struct_txsb);

                    struct_txsb.p_zt = "3";
                    struct_txsb.p_sjbs = "1";
                }
                if (!struct_txsb.p_lrr.Equals(struct_txsb.p_csr) && !struct_txsb.p_lrr.Equals(struct_txsb.p_zsr))
                {
                    struct_txsb.p_zt = "0";
                    struct_txsb.p_sjbs = "2";
                }
                //将新数据更新到副本数据里

                txsb.Update_TXSB(struct_txsb);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                Server.Transfer("TXSB_GL.aspx");
            }
            else
            {
                return;
            }
        }
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


        private void ddltBind()
        {
            //台站
            ddlt_tzmczl.DataTextField = "mc";
            ddlt_tzmczl.DataValueField = "bm";
            ddlt_tzmczl.DataSource = SysData.TZLX_ZH("01").Copy();
            ddlt_tzmczl.DataBind();
            ddlt_tzmczl.Items.Insert(0, new ListItem("请选择", "-1"));

            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            ////绑定设备类型
            //ddlt_sblx.DataTextField = "mc";
            //ddlt_sblx.DataValueField = "bm";
            //ddlt_sblx.DataSource = SysData.SBLX("01").Copy();
            //ddlt_sblx.DataBind();
            //ddlt_sblx.Items.Insert(0, new ListItem("请选择", "-1"));



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

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140203");

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
            ddlt_sjssbm.DataSource = SysData.BM("140203", _usState.userID).Copy();
            ddlt_sjssbm.DataTextField = "bmmc";
            ddlt_sjssbm.DataValueField = "bmdm";
            ddlt_sjssbm.DataBind();
            ddlt_sjssbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }



        private void yg_bind()
        {
            DataTable dt_bmdm = SysData.BM("140203", _usState.userID).Copy();
 
            //设备保管人
            //部门
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = txsb.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sbbgr.DataSource = dt;
            ddlt_sbbgr.DataTextField = "xm";
            ddlt_sbbgr.DataValueField = "bh";
            ddlt_sbbgr.DataBind();
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = txsb.Select_YGbyBMGW(bmdm, gwdm);
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
            dt = txsb.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sbbgr.DataSource = dt;
            ddlt_sbbgr.DataTextField = "xm";
            ddlt_sbbgr.DataValueField = "bh";
            ddlt_sbbgr.DataBind();
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
            else
            {
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

    }


}