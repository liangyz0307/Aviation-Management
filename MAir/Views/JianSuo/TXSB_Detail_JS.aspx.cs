using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class TXSB_Detail_JS : System.Web.UI.Page
    {
        private UserState _usState;
        private TXSB txsb;
        private DataTable dt_detail;
        private int id;
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
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }

        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"]);
            dt_detail = txsb.Select_TXSB_Detail(id);

            //数据所属部门
            lbl_sjssbm.Text = dt_detail.Rows[0]["sjssbmmc"].ToString();
            //设备类型
            lbl_sblx.Text = SysData.SBLXByKey(dt_detail.Rows[0]["sblx"].ToString()).mc;
            //台站名称
            lbl_wz.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["wz"].ToString()).mc;
            //所属机场
            lbl_ssjc.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["ssjc"].ToString()).mc;
            //投产开放时间
            lbl_tckfsj.Text = dt_detail.Rows[0]["tckfsj"].ToString();
            //投产开放时间
            lbl_sl.Text = dt_detail.Rows[0]["sl"].ToString();
            //设备状态
            lbl_sbzt.Text = SysData.SBZTByKey(dt_detail.Rows[0]["sbzt"].ToString()).mc;
            //设备生产厂家
            lbl_sbsccj.Text = dt_detail.Rows[0]["sbsccj"].ToString();
            //设备出场编号
            lbl_sbccbh.Text = dt_detail.Rows[0]["sbccbh"].ToString();
            //设备出场编号
            lbl_sbxkzsc.Text = dt_detail.Rows[0]["sbxkzsc"].ToString();
            //用途
            lbl_yt.Text = SysData.SBYTByKey(dt_detail.Rows[0]["yt"].ToString()).mc;
            //交流供电
            lbl_jlgd.Text = dt_detail.Rows[0]["jlgd"].ToString();
            //交流供电大小
            lbl_jlgddx.Text = dt_detail.Rows[0]["jlgddx"].ToString();
            //交流供电数量
            lbl_jlgdsl.Text = dt_detail.Rows[0]["jlgdsl"].ToString();
            //直流供电
            lbl_zlgd.Text = dt_detail.Rows[0]["zlgd"].ToString();
            //直流供电大小
            lbl_zlgddx.Text = dt_detail.Rows[0]["zlgddx"].ToString();
            //直流供电数量
            lbl_zlgdsl.Text = dt_detail.Rows[0]["zlgdsl"].ToString();
            //保护区范围
            lbl_bhqfw.Text = dt_detail.Rows[0]["bhqfw"].ToString();
            //设备传输情况
            lbl_sbcsqk.Text = dt_detail.Rows[0]["sbcsqk"].ToString();
            //设备防雷配置
            lbl_sbflpz.Text = dt_detail.Rows[0]["sbflpz"].ToString();
            //现所属机场
            lbl_xssjc.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["xssjc"].ToString()).mc;
            //调拨时间
            lbl_dbsj.Text = dt_detail.Rows[0]["dbsj"].ToString();
            //设备保管人
            lbl_sbbgr.Text = dt_detail.Rows[0]["sbbgrxm"].ToString();
            //初审人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();
            //终审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();
            //设备型号
            lbl_sbxh.Text = dt_detail.Rows[0]["sbxh"].ToString();

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
                lbl_yyjly_xyyhs.Text = dt_detail.Rows[0]["yyjly_xyyhs"].ToString();
                //语音信道数
                lbl_yyjly_yyxds.Text = dt_detail.Rows[0]["yyjly_yyxds"].ToString();
                //数据信道数
                lbl_yyjly_sjxds.Text = dt_detail.Rows[0]["yyjly_sjxds"].ToString();

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
                lbl_wxdmzxt_zdlx.Text = SysData.ZDLXByKey(dt_detail.Rows[0]["wxdmzxt_zdlx"].ToString()).mc;
                //天线口径
                lbl_wxdmzxt_txkj.Text = dt_detail.Rows[0]["wxdmzxt_txkj"].ToString();
                //室外单元功率
                lbl_wxdmzxt_swdygl.Text = dt_detail.Rows[0]["wxdmzxt_swdygl"].ToString();
                //发射频率
                lbl_wxdmzxt_fspl.Text = dt_detail.Rows[0]["wxdmzxt_fspl"].ToString();
                //接收频率
                lbl_wxdmzxt_jspl.Text = dt_detail.Rows[0]["wxdmzxt_jspl"].ToString();
                //信道数
                lbl_wxdmzxt_xds.Text = dt_detail.Rows[0]["wxdmzxt_xds"].ToString();
                //台站坐标(北京54)经度
                lbl_wxdmzxt_tzzb_bj54_jd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_bj54_jd"].ToString();
                //台站坐标(北京54)纬度
                lbl_wxdmzxt_tzzb_bj54_wd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_bj54_wd"].ToString();
                //台站坐标(wgs84)经度
                lbl_wxdmzxt_tzzb_wgs84_jd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_wgs84_jd"].ToString();
                //台站坐标(wgs84)纬度
                lbl_wxdmzxt_tzzb_wgs84_wd.Text = dt_detail.Rows[0]["wxdmzxt_tzzb_wgs84_wd"].ToString();
                //天线设置地点
                lbl_wxdmzxt_txszdd.Text = dt_detail.Rows[0]["wxdmzxt_txszdd"].ToString();
                //天线基础高程
                lbl_wxdmzxt_txjcgc.Text = dt_detail.Rows[0]["wxdmzxt_txjcgc"].ToString();
                //天线电台执照有效期
                lbl_wxdmzxt_wxdtzzyxq.Text = dt_detail.Rows[0]["wxdmzxt_wxdtzzyxq"].ToString();
                //上传
                lbl_wxdmzxt_sc.Text = dt_detail.Rows[0]["wxdmzxt_sc"].ToString();


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
                lbl_sgpdktxxt_sbpz.Text = SysData.SBPZByKey(dt_detail.Rows[0]["sgpdktxxt_sbpz"].ToString()).mc;
                //设备信道数
                lbl_sgpdktxxt_sbxds.Text = dt_detail.Rows[0]["sgpdktxxt_sbxds"].ToString();
                //天线类型
                lbl_sgpdktxxt_txlx.Text = SysData.TXLXByKey(dt_detail.Rows[0]["sgpdktxxt_txlx"].ToString()).mc;
                //投产校飞日期
                lbl_sgpdktxxt_tcjfrq.Text = dt_detail.Rows[0]["sgpdktxxt_tcjfrq"].ToString();
                //发射频率
                lbl_sgpdktxxt_fspl.Text = dt_detail.Rows[0]["sgpdktxxt_fspl"].ToString();
                //输出功率
                lbl_sgpdktxxt_scgl.Text = dt_detail.Rows[0]["sgpdktxxt_scgl"].ToString();
                //传输方式
                lbl_sgpdktxxt_csfs.Text = dt_detail.Rows[0]["sgpdktxxt_csfs"].ToString();
                //上传
                lbl_sgpdktxxt_sc.Text = dt_detail.Rows[0]["sgpdktxxt_sc"].ToString();
                //台站坐标(北京54)经度
                lbl_sgpdktxxt_tzzb_bj54_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_jd"].ToString();
                //台站坐标(wgs84)纬度
                lbl_sgpdktxxt_tzzb_bj54_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_wd"].ToString();
                //台站坐标(wgs84)经度
                lbl_sgpdktxxt_tzzb_wgs84_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_jd"].ToString();
                //台站坐标(wgs84)纬度
                lbl_sgpdktxxt_tzzb_wgs84_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_wd"].ToString();
                //天线基础高程
                lbl_sgpdktxxt_txjcgc.Text = dt_detail.Rows[0]["sgpdktxxt_txjcgc"].ToString();
                //天线高度
                lbl_sgpdktxxt_txgd.Text = dt_detail.Rows[0]["sgpdktxxt_txgd"].ToString();
                //天线设置地点
                lbl_sgpdktxxt_txszdd.Text = dt_detail.Rows[0]["sgpdktxxt_txszdd"].ToString();
                //无线电台执照有效期
                lbl_sgpdktxxt_wxdtzzyxq.Text = dt_detail.Rows[0]["sgpdktxxt_wxdtzzyxq"].ToString();
                //天线生产厂家
                lbl_sgpdktxxt_sccj.Text = dt_detail.Rows[0]["sgpdktxxt_txsccj"].ToString();
                //天线型号
                lbl_sgpdktxxt_txxh_lx.Text = dt_detail.Rows[0]["sgpdktxxt_txxh_lx"].ToString();
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
                lbl_yyjhxt_nh_xtpz.Text = dt_detail.Rows[0]["yyjhxt_nh_xtpz"].ToString();
                //席位具体配置
                lbl_yyjhxt_nh_xwjtpz.Text = dt_detail.Rows[0]["yyjhxt_nh_xwjtpz"].ToString();
                //系统软件版本
                lbl_yyjhxt_nh_xtrjbb.Text = dt_detail.Rows[0]["yyjhxt_nh_xtrjbb"].ToString();
                //接口数量 有线
                lbl_yyjhxt_nh_jksl_yx.Text = dt_detail.Rows[0]["yyjhxt_nh_jksl_yx"].ToString();
                //接口数量 无线
                lbl_yyjhxt_nh_jksl_wx.Text = dt_detail.Rows[0]["yyjhxt_nh_jksl_wx"].ToString();
                //MFC协议
                lbl_yyjhxt_nh_MFCxy.Text = SysData.MFCXYByKey(dt_detail.Rows[0]["yyjhxt_nh_MFCxy"].ToString()).mc;
                //Q-SIG协议
                lbl_yyjhxt_nh_QSIGxy.Text = SysData.QSIGXYByKey(dt_detail.Rows[0]["yyjhxt_nh_QSIGxy"].ToString()).mc;
                //IP协议
                lbl_yyjhxt_nh_IPxy.Text = SysData.IPXYByKey(dt_detail.Rows[0]["yyjhxt_nh_IPxy"].ToString()).mc;


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
                lbl_zdzbxt_xtpz.Text = dt_detail.Rows[0]["zdzbxt_xtpz"].ToString();
                //系统软件版本
                lbl_zdzbxt_xtrjbb.Text = dt_detail.Rows[0]["zdzbxt_xtrjbb"].ToString();
                //在用系统
                lbl_zdzbxt_zyxt.Text = dt_detail.Rows[0]["zdzbxt_zyxt"].ToString();
                //终端用户列表
                lbl_zdzbxt_zdyhlb.Text = dt_detail.Rows[0]["zdzbxt_zdyhlb"].ToString();

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
                lbl_gpdktxxt_sbpz.Text = SysData.SBPZByKey(dt_detail.Rows[0]["sgpdktxxt_sbpz"].ToString()).mc;
                //设备信道数
                lbl_gpdktxxt_sbxds.Text = dt_detail.Rows[0]["sgpdktxxt_sbxds"].ToString();
                //天线类型
                lbl_gpdktxxt_txlx.Text = SysData.TXLXByKey(dt_detail.Rows[0]["sgpdktxxt_txlx"].ToString()).mc;
                //投产校飞日期
                lbl_gpdktxxt_tcjfrq.Text = dt_detail.Rows[0]["sgpdktxxt_tcjfrq"].ToString();
                //发射频率
                lbl_gpdktxxt_fspl.Text = dt_detail.Rows[0]["sgpdktxxt_fspl"].ToString();
                //输出功率
                lbl_gpdktxxt_scgl.Text = dt_detail.Rows[0]["sgpdktxxt_scgl"].ToString();
                //传输方式
                lbl_gpdktxxt_csfs.Text = dt_detail.Rows[0]["sgpdktxxt_csfs"].ToString();
                //上传
                lbl_gpdktxxt_sc.Text = dt_detail.Rows[0]["sgpdktxxt_sc"].ToString();
                //台站坐标(北京54)经度
                lbl_gpdktxxt_tzzb_bj54_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_jd"].ToString();
                //台站坐标(wgs84)纬度
                lbl_gpdktxxt_tzzb_bj54_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_wd"].ToString();
                //台站坐标(wgs84)经度
                lbl_gpdktxxt_tzzb_wgs84_jd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_jd"].ToString();
                //台站坐标(wgs84)纬度
                lbl_gpdktxxt_tzzb_wgs84_wd.Text = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_wd"].ToString();
                //天线基础高程
                lbl_gpdktxxt_txjcgc.Text = dt_detail.Rows[0]["sgpdktxxt_txjcgc"].ToString();
                //天线高度
                lbl_gpdktxxt_txgd.Text = dt_detail.Rows[0]["sgpdktxxt_txgd"].ToString();
                //天线设置地点
                lbl_sgpdktxxt_txszdd.Text = dt_detail.Rows[0]["sgpdktxxt_txszdd"].ToString();
                //无线电台执照有效期
                lbl_gpdktxxt_wxdtzzyxq.Text = dt_detail.Rows[0]["sgpdktxxt_wxdtzzyxq"].ToString();
                //天线生产厂家
                lbl_gpdktxxt_txsccj.Text = dt_detail.Rows[0]["sgpdktxxt_txsccj"].ToString();
                //天线型号
                lbl_gpdktxxt_txxh_lx.Text = dt_detail.Rows[0]["sgpdktxxt_txxh_lx"].ToString();
            }
            #endregion
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

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SBGL.aspx");
        }


        protected void btn_sbxkzsc_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_sbxkzsc.Text;//客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/TXSB/") + fileName;//目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }

        }

        protected void btn_bhqfw_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_bhqfw.Text;//客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/TXSB/") + fileName;//目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }

        }

        protected void btn_wxdmzxt_sc_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_wxdmzxt_sc.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/TXSB/") + fileName;          //目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }
        }

        protected void btn_sgpdktxxt_sc_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_sgpdktxxt_sc.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/TXSB/") + fileName;          //目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }

        }

        protected void btn_gpdktxxt_sc_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_gpdktxxt_sc.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/TXSB/") + fileName;          //目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }

        }


    }
}