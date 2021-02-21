using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using Sys;

namespace CUST.MKG
{
    public struct Struct_TXSB
    {
        public string p_sbbh;//设备编号
        public string p_sblx;//设备类型
        public string p_tzmc;//台站名称
        public string p_ssjc;//所属机场
        public string p_tckfsj;//投产开放时间
        public string p_sl;//数量
        public string p_sbzt;//设备状态
        public string p_sbsccj;//设备生产厂家
        public string p_sbccbh;//设备出场编号
        public string p_sbxkzsc;//设备许可证上传
        public string p_yt;//用途
        public string p_jlgd;//交流供电
        public string p_jlgddx;//交流供电大小
        public string p_jlgdsl;//交流供电数量
        public string p_zlgd;//直流供电
        public string p_zlgddx;//直流供电大小
        public string p_zlgdsl;//直流供电数量
        public string p_bhqfw;//保护区范围
        public string p_sbcsqk;//设备传输情况
        public string p_sbflpz;//设备防雷配置
        public string p_zt;//状态
        public string p_xssjc;//现所属机场
        public string p_dbsj;//调拨时间
        public string p_sbbgr;//设备保管人
        public string p_yyjly_xyyhs;//语音记录仪_现有用户数
        public string p_yyjly_yyxds;//语音记录仪_语音信道数
        public string p_yyjly_sjxds;//语音记录仪_语音信道数
        public string p_wxdmzxt_zdlx;//卫星地面站系统_站点类型
        public string p_wxdmzxt_txkj;//卫星地面站系统_天线口径
        public string p_wxdmzxt_swdygl;//卫星地面站系统_室外单元功率
        public string p_wxdmzxt_fspl;//卫星地面站系统_发射频率
        public string p_wxdmzxt_jspl;//卫星地面站系统_接收频率
        public string p_wxdmzxt_xds; //卫星地面站系统_信道数
        public string p_wxdmzxt_tzzb_bj54_jd;//卫星地面站系统_台站坐标（北京54）经度
        public string p_wxdmzxt_tzzb_bj54_wd;//卫星地面站系统_台站坐标（北京54）纬度
        public string p_wxdmzxt_tzzb_wgs84_jd;//卫星地面站系统_台站坐标（wgs54)经度
        public string p_wxdmzxt_tzzb_wgs84_wd;//卫星地面站系统_台站坐标（wgs54)纬度
        public string p_wxdmzxt_txszdd;//卫星地面站系统_天线设置地点
        public string p_wxdmzxt_txjcgc;//卫星地面站系统_天线基础高程
        public string p_wxdmzxt_wxdtzzyxq;//卫星地面站系统_无线电台执照有效期
        public string p_wxdmzxt_sc;//卫星地面站系统_上传
        public string p_sgpdktxxt_sbpz;//甚高频地空通信系统_设备配置
        public string p_sgpdktxxt_sbxds;//甚高频地空通信系统_设备信道数
        public string p_sgpdktxxt_txlx;//甚高频地空通信系统_天线类型
        public string p_sgpdktxxt_tcjfrq;//甚高频地空通信系统_投产校飞日期
        public string p_sgpdktxxt_fspl;//甚高频地空通信系统_发射频率
        public string p_sgpdktxxt_scgl;//甚高频地空通信系统_输出功率
        public string p_sgpdktxxt_csfs;//甚高频地空通信系统_传输方式
        public string p_sgpdktxxt_sc;//甚高频地空通信系统_上传
        public string p_sgpdktxxt_tzzb_bj54_jd;//甚高频地空通信系统_台站坐标（北京54）经度
        public string p_sgpdktxxt_tzzb_bj54_wd;//甚高频地空通信系统_台站坐标（北京54）纬度
        public string p_sgpdktxxt_tzzb_wgs84_jd;//甚高频地空通信系统_台站坐标（wgs84）经度
        public string p_sgpdktxxt_tzzb_wgs84_wd;//甚高频地空通信系统_台站坐标（wgs84）纬度
        public string p_sgpdktxxt_txjcgc;//甚高频地空通信系统_天线基础高程
        public string p_sgpdktxxt_txgd;//甚高频地空通信系统_天线高度
        public string p_sgpdktxxt_txszdd;//甚高频地空通信系统_天线设置地点
        public string p_sgpdktxxt_wxdtzzyxq;//甚高频地空通信系统_无线电台执照有效期
        public string p_sgpdktxxt_txsccj;//甚高频地空通信系统_天线生产厂家
        public string p_sgpdktxxt_txxh_lx;//高频地空通信系统_天线型号/类型
        public string p_yyjhxt_nh_xtpz;//语音交换系统（内话）_系统配置
        public string p_yyjhxt_nh_xwjtpz;//语音交换系统（内话）_席位具体配置
        public string p_yyjhxt_nh_xtrjbb;//语音交换系统（内话）_系统软件版本
        public string p_yyjhxt_nh_jksl_yx;//语音交换系统（内话）_接口数量有线
        public string p_yyjhxt_nh_jksl_wx;//语音交换系统（内话）_接口数量无线
        public string p_yyjhxt_nh_MFCxy;//语音交换系统（内话）_MFC协议
        public string p_yyjhxt_nh_QSIGxy;//语音交换系统（内话）_Q-SIG协议 
        public string p_yyjhxt_nh_IPxy;//语音交换系统（内话）_IP协议
        public string p_zdzbxt_xtpz;//自动转报系统_系统配置
        public string p_zdzbxt_xtrjbb;//自动转报系统_系统软件版本
        public string p_zdzbxt_zyxt;//自动转报系统_在用系统
        public string p_zdzbxt_zdyhlb;//自动转报系统_终端用户列表
        public string p_gpdktxxt_sbpz;//高频地空通信系统设备配置
        public string p_gpdktxxt_sbxds;//高频地空通信系统_设备信道数
        public string p_gpdktxxt_txlx;//高频地空通信系统_天线类型
        public string p_gpdktxxt_tcjfrq;//高频地空通信系统_投产校飞日期
        public string p_gpdktxxt_fspl;//高频地空通信系统_发射频率
        public string p_gpdktxxt_scgl;//高频地空通信系统_输出功率
        public string p_gpdktxxt_csfs;//高频地空通信系统_传输方式
        public string p_gpdktxxt_sc;//高频地空通信系统_上传
        public string p_gpdktxxt_tzzb_bj54_jd;//高频地空通信系统_台站坐标（北京54）经度
        public string p_gpdktxxt_tzzb_bj54_wd;//高频地空通信系统_台站坐标（北京54）纬度
        public string p_gpdktxxt_tzzb_wgs84_jd;//高频地空通信系统_台站坐标（wgs84）经度
        public string p_gpdktxxt_tzzb_wgs84_wd;//高频地空通信系统_台站坐标（wgs84）纬度
        public string p_gpdktxxt_txjcgc;//高频地空通信系统_天线基础高程
        public string p_gpdktxxt_txgd;//高频地空通信系统_天线高度
        public string p_gpdktxxt_txszdd;//高频地空通信系统_天线设置地点
        public string p_gpdktxxt_wxdtzzyxq;//高频地空通信系统_无线电台执照有效期
        public string p_gpdktxxt_txsccj;//高频地空通信系统_天线生产厂家
        public string p_gpdktxxt_txxh_lx;//高频地空通信系统_天线型号/类型
        public string p_czfs;
        public string p_czxx;
        public string p_bhyy;
        public int p_pagesize;
        public int p_currentpage;
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_sjssbm;//数据所属部门
        public string p_sbxh;//设备型号
        public int p_id;
        public string p_wz;
    }

    public class OTXSB
    {
        private Struct_RZ_YH struct_RZ_YH=new Struct_RZ_YH();
        private RZ rz;
        private UserState _us = null;
        public OTXSB(UserState state)
        {
            _us = state;
            rz = new RZ(_us);
        }
        #region  ===============通信设备================
        protected DataSet Select_TXSB_Pro(Struct_TXSB struct_TXSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_wz",OracleType.VarChar),
                                               new OracleParameter("p_ssjc",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_TXSB.p_sblx;
                parament[1].Value = struct_TXSB.p_wz;
                parament[2].Value = struct_TXSB.p_ssjc;
                parament[3].Value = struct_TXSB.p_zt;
                parament[4].Value = struct_TXSB.p_pagesize;
                parament[5].Value = struct_TXSB.p_currentpage;
                parament[6].Value = struct_TXSB.p_userid;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_TXSB.Select_TXSB_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_TXSB_Count(Struct_TXSB struct_txsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_wz",OracleType.VarChar),
                                               new OracleParameter("p_ssjc",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_txsb.p_sblx;
                parament[1].Value = struct_txsb.p_wz;
                parament[2].Value = struct_txsb.p_ssjc;
                parament[3].Value = struct_txsb.p_zt;
                parament[4].Value = struct_txsb.p_userid;
                parament[5].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32( dbclass.RunProcedure("PACK_SBGL_TXSB.Select_TXSB_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }


        #region 添加通信设备
        protected void Insert_TXSB(Struct_TXSB struct_TXSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                    new OracleParameter("p_sbbh",OracleType.VarChar),
                                                    new OracleParameter("p_sblx",OracleType.VarChar),
                                                    new OracleParameter("p_wz",OracleType.VarChar),
                                                    new OracleParameter("p_ssjc",OracleType.VarChar),
                                                    new OracleParameter("p_tckfsj",OracleType.VarChar),
                                                    new OracleParameter("p_sl",OracleType.VarChar),
                                                    new OracleParameter("p_sbzt",OracleType.VarChar),
                                                    new OracleParameter("p_sbsccj",OracleType.VarChar),
                                                    new OracleParameter("p_sbccbh",OracleType.VarChar),
                                                    new OracleParameter("p_sbxkzsc",OracleType.VarChar),
                                                    new OracleParameter("p_yt",OracleType.VarChar),
                                                    new OracleParameter("p_jlgd",OracleType.VarChar),
                                                    new OracleParameter("p_jlgddx",OracleType.VarChar),
                                                    new OracleParameter("p_jlgdsl",OracleType.VarChar),
                                                    new OracleParameter("p_zlgd",OracleType.VarChar),
                                                    new OracleParameter("p_zlgddx",OracleType.VarChar),
                                                    new OracleParameter("p_zlgdsl",OracleType.VarChar),
                                                    new OracleParameter("p_bhqfw",OracleType.VarChar),
                                                    new OracleParameter("p_sbcsqk",OracleType.VarChar),
                                                    new OracleParameter("p_sbflpz",OracleType.VarChar),
                                                    new OracleParameter("p_zt",OracleType.VarChar),
                                                    new OracleParameter("p_xssjc",OracleType.VarChar),
                                                    new OracleParameter("p_dbsj",OracleType.VarChar),
                                                    new OracleParameter("p_sbbgr",OracleType.VarChar),
                                                    new OracleParameter("p_yyjly_xyyhs",OracleType.VarChar),
                                                    new OracleParameter("p_yyjly_yyxds",OracleType.VarChar),
                                                    new OracleParameter("p_yyjly_sjxds",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_zdlx",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_txkj",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_swdygl",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_fspl",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_jspl",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_xds",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_bj54_jd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_bj54_wd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_wgs84_jd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_wgs84_wd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_txszdd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_txjcgc",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_wxdtzzyxq",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_sc",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_sbpz",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_sbxds",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txlx",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tcjfrq",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_fspl",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_scgl",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_csfs",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_sc",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_bj54_jd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_bj54_wd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_wgs84_jd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_wgs84_wd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txjcgc",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txgd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txszdd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_wxdtzzyxq",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txsccj",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txxh_lx",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_xtpz",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_xwjtpz",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_xtrjbb",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_jksl_yx",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_jksl_wx",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_MFCxy",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_QSIGxy",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_IPxy",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_xtpz",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_xtrjbb",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_zyxt",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_zdyhlb",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_sbpz",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_sbxds",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txlx",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tcjfrq",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_fspl",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_scgl",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_csfs",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_sc",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_bj54_jd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_bj54_wd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_wgs84_jd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_wgs84_wd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txjcgc",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txgd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txszdd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_wxdtzzyxq",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txsccj",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txxh_lx",OracleType.VarChar),

                                                    new OracleParameter("p_sjc",OracleType.VarChar),
                                                    new OracleParameter("p_sjbs",OracleType.VarChar),
                                                    new OracleParameter("p_sjssbm",OracleType.VarChar),
                                                    new OracleParameter("p_csr",OracleType.VarChar),
                                                    new OracleParameter("p_zsr",OracleType.VarChar),
                                                    new OracleParameter("p_lrr",OracleType.VarChar),
                                                    new OracleParameter("p_sbxh",OracleType.VarChar),
                                                    new OracleParameter("p_errorCode",OracleType.Int32)

                                           };
                parament[0].Value = struct_TXSB.p_sbbh;
                parament[1].Value = struct_TXSB.p_sblx;
                parament[2].Value = struct_TXSB.p_wz;
                parament[3].Value = struct_TXSB.p_ssjc;
                parament[4].Value = struct_TXSB.p_tckfsj;
                parament[5].Value = struct_TXSB.p_sl;
                parament[6].Value = struct_TXSB.p_sbzt;
                parament[7].Value = struct_TXSB.p_sbsccj;
                parament[8].Value = struct_TXSB.p_sbccbh;
                parament[9].Value = struct_TXSB.p_sbxkzsc;
                parament[10].Value = struct_TXSB.p_yt;
                parament[11].Value = struct_TXSB.p_jlgd;
                parament[12].Value = struct_TXSB.p_jlgddx;
                parament[13].Value = struct_TXSB.p_jlgdsl;
                parament[14].Value = struct_TXSB.p_zlgd;
                parament[15].Value = struct_TXSB.p_zlgddx;
                parament[16].Value = struct_TXSB.p_zlgdsl;
                parament[17].Value = struct_TXSB.p_bhqfw;
                parament[18].Value = struct_TXSB.p_sbcsqk;
                parament[19].Value = struct_TXSB.p_sbflpz;
                parament[20].Value = struct_TXSB.p_zt;
                parament[21].Value = struct_TXSB.p_xssjc;
                parament[22].Value = struct_TXSB.p_dbsj;
                parament[23].Value = struct_TXSB.p_sbbgr;



                parament[24].Value = struct_TXSB.p_yyjly_xyyhs;
                parament[25].Value = struct_TXSB.p_yyjly_yyxds;
                parament[26].Value = struct_TXSB.p_yyjly_sjxds;


                parament[27].Value = struct_TXSB.p_wxdmzxt_zdlx;
                parament[28].Value = struct_TXSB.p_wxdmzxt_txkj;
                parament[29].Value = struct_TXSB.p_wxdmzxt_swdygl;
                parament[30].Value = struct_TXSB.p_wxdmzxt_fspl;
                parament[31].Value = struct_TXSB.p_wxdmzxt_jspl;
                parament[32].Value = struct_TXSB.p_wxdmzxt_xds;
                parament[33].Value = struct_TXSB.p_wxdmzxt_tzzb_bj54_jd;
                parament[34].Value = struct_TXSB.p_wxdmzxt_tzzb_bj54_wd;
                parament[35].Value = struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd;
                parament[36].Value = struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd;
                parament[37].Value = struct_TXSB.p_wxdmzxt_txszdd;
                parament[38].Value = struct_TXSB.p_wxdmzxt_txjcgc;
                parament[39].Value = struct_TXSB.p_wxdmzxt_wxdtzzyxq;
                parament[40].Value = struct_TXSB.p_wxdmzxt_sc;


                parament[41].Value = struct_TXSB.p_sgpdktxxt_sbpz;
                parament[42].Value = struct_TXSB.p_sgpdktxxt_sbxds;
                parament[43].Value = struct_TXSB.p_sgpdktxxt_txlx;
                parament[44].Value = struct_TXSB.p_sgpdktxxt_tcjfrq;
                parament[45].Value = struct_TXSB.p_sgpdktxxt_fspl;
                parament[46].Value = struct_TXSB.p_sgpdktxxt_scgl;
                parament[47].Value = struct_TXSB.p_sgpdktxxt_csfs;
                parament[48].Value = struct_TXSB.p_sgpdktxxt_sc;
                parament[49].Value = struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd;
                parament[50].Value = struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd;
                parament[51].Value = struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd;
                parament[52].Value = struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd;
                parament[53].Value = struct_TXSB.p_sgpdktxxt_txjcgc;
                parament[54].Value = struct_TXSB.p_sgpdktxxt_txgd;
                parament[55].Value = struct_TXSB.p_sgpdktxxt_txszdd;
                parament[56].Value = struct_TXSB.p_sgpdktxxt_wxdtzzyxq;
                parament[57].Value = struct_TXSB.p_sgpdktxxt_txsccj;
                parament[58].Value = struct_TXSB.p_sgpdktxxt_txxh_lx;


                parament[59].Value = struct_TXSB.p_yyjhxt_nh_xtpz;
                parament[60].Value = struct_TXSB.p_yyjhxt_nh_xwjtpz;
                parament[61].Value = struct_TXSB.p_yyjhxt_nh_xtrjbb;
                parament[62].Value = struct_TXSB.p_yyjhxt_nh_jksl_yx;
                parament[63].Value = struct_TXSB.p_yyjhxt_nh_jksl_wx;
                parament[64].Value = struct_TXSB.p_yyjhxt_nh_MFCxy;
                parament[65].Value = struct_TXSB.p_yyjhxt_nh_QSIGxy;
                parament[66].Value = struct_TXSB.p_yyjhxt_nh_IPxy;


                parament[67].Value = struct_TXSB.p_zdzbxt_xtpz;
                parament[68].Value = struct_TXSB.p_zdzbxt_xtrjbb;
                parament[69].Value = struct_TXSB.p_zdzbxt_zyxt;
                parament[70].Value = struct_TXSB.p_zdzbxt_zdyhlb;


                parament[71].Value = struct_TXSB.p_gpdktxxt_sbpz;
                parament[72].Value = struct_TXSB.p_gpdktxxt_sbxds;
                parament[73].Value = struct_TXSB.p_gpdktxxt_txlx;
                parament[74].Value = struct_TXSB.p_gpdktxxt_tcjfrq;
                parament[75].Value = struct_TXSB.p_gpdktxxt_fspl;
                parament[76].Value = struct_TXSB.p_gpdktxxt_scgl;
                parament[77].Value = struct_TXSB.p_gpdktxxt_csfs;
                parament[78].Value = struct_TXSB.p_gpdktxxt_sc;
                parament[79].Value = struct_TXSB.p_gpdktxxt_tzzb_bj54_jd;
                parament[80].Value = struct_TXSB.p_gpdktxxt_tzzb_bj54_wd;
                parament[81].Value = struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd;
                parament[82].Value = struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd;
                parament[83].Value = struct_TXSB.p_gpdktxxt_txjcgc;
                parament[84].Value = struct_TXSB.p_gpdktxxt_txgd;
                parament[85].Value = struct_TXSB.p_gpdktxxt_txszdd;
                parament[86].Value = struct_TXSB.p_gpdktxxt_wxdtzzyxq;
                parament[87].Value = struct_TXSB.p_gpdktxxt_txsccj;
                parament[88].Value = struct_TXSB.p_gpdktxxt_txxh_lx;

                parament[89].Value = struct_TXSB.p_sjc;
                parament[90].Value = struct_TXSB.p_sjbs;
                parament[91].Value = struct_TXSB.p_sjssbm;
                parament[92].Value = struct_TXSB.p_csr;
                parament[93].Value = struct_TXSB.p_zsr;
                parament[94].Value = struct_TXSB.p_lrr;
                parament[95].Value = struct_TXSB.p_sbxh;


                parament[96].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_TXSB.Insert_TXSB", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[96].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_TXSB.p_czfs;
                struct_RZ_YH.czxx = struct_TXSB.p_czxx;
                //rz.RZ_Insert_CZ(struct_RZ_YH);       
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion    

        #region 通过编号查询员工姓名
        protected DataTable Select_YGXMbyBH(string p_bh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_bh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_SBGL_TXSB.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 通过部门岗位查询员工
        protected DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                       new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bmdm;
                paras[1].Value = gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_SBGL_TXSB.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion


        /**
        protected DataSet Select_TXSBbySBBH(string p_sbbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_sbbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_SB.Select_TXSBbySBBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_Max_txsbbh(string bm_sblx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                               new OracleParameter("p_bm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = bm_sblx;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_SB.Select_Max_txsbbh", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
       
        protected void Update_TXSB(Struct_TXSB struct_TXSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                    new OracleParameter("p_sbbh",OracleType.VarChar),
                                                    new OracleParameter("p_sbzl",OracleType.VarChar),
                                                    new OracleParameter("p_sstzmc",OracleType.VarChar),
                                                    new OracleParameter("p_jgysrq",OracleType.VarChar),
                                                    new OracleParameter("p_tckfrq",OracleType.VarChar),
                                                    new OracleParameter("p_sfwxdsb",OracleType.VarChar),
                                                    new OracleParameter("p_wxdsbfshzzbh",OracleType.VarChar),
                                                    new OracleParameter("p_wxdsbfshzzj",OracleType.VarChar),
                                                    new OracleParameter("p_zzyxq",OracleType.VarChar),
                                                    new OracleParameter("p_sbcqdw",OracleType.VarChar),
                                                    new OracleParameter("p_sbwhdw",OracleType.VarChar),
                                                    new OracleParameter("p_sbsyxkzh",OracleType.VarChar),
                                                    new OracleParameter("p_txfs",OracleType.VarChar),
                                                    new OracleParameter("p_sbpz",OracleType.VarChar),
                                                    new OracleParameter("p_sbyt",OracleType.VarChar),
                                                    new OracleParameter("p_sl",OracleType.Int32),
                                                    new OracleParameter("p_txlx",OracleType.VarChar),
                                                    new OracleParameter("p_ykxt_zkf",OracleType.VarChar),
                                                    new OracleParameter("p_ykxt_skf",OracleType.VarChar),
                                                    new OracleParameter("p_gzpl",OracleType.Number),
                                                    new OracleParameter("p_fsgl",OracleType.Number),
                                                    new OracleParameter("p_gdfs",OracleType.VarChar),
                                                    new OracleParameter("p_cszl",OracleType.VarChar),
                                                    new OracleParameter("p_sbazdd",OracleType.VarChar),
                                                    new OracleParameter("p_cyzzrs",OracleType.Int32),
                                                    new OracleParameter("p_fxjy",OracleType.VarChar),
                                                    new OracleParameter("p_fxjyrq",OracleType.VarChar),
                                                    new OracleParameter("p_kfxkdqr",OracleType.VarChar),
                                                    new OracleParameter("p_fxjyzqzt",OracleType.Int32),
                                                    new OracleParameter("p_ddzb_bj_jd",OracleType.Number),
                                                    new OracleParameter("p_ddzb_bj_wd",OracleType.Number),
                                                    new OracleParameter("p_ddzb_wgs_jd",OracleType.Number),
                                                    new OracleParameter("p_ddzb_wgs_wd",OracleType.Number),
                                                    new OracleParameter("p_hhgc",OracleType.Number),
                                                    new OracleParameter("p_gcbz",OracleType.VarChar),
                                                    new OracleParameter("p_bz",OracleType.VarChar),
                                                    new OracleParameter("p_scsj",OracleType.DateTime),
                                                     new OracleParameter("p_zxdm",OracleType.VarChar),
                                                     new OracleParameter("p_bzqk",OracleType.VarChar),
                                                    new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_TXSB.p_sbbh;
                parament[1].Value = struct_TXSB.p_sbzl;
                parament[2].Value = struct_TXSB.p_sstzmc;
                parament[3].Value = struct_TXSB.p_jgysrq;
                parament[4].Value = struct_TXSB.p_tckfrq;
                parament[5].Value = struct_TXSB.p_sfwxdsb;
                parament[6].Value = struct_TXSB.p_wxdsbfshzzbh;
                parament[7].Value = struct_TXSB.p_wxdsbfshzzj;
                parament[8].Value = struct_TXSB.p_zzyxq;
                parament[9].Value = struct_TXSB.p_sbcqdw;
                parament[10].Value = struct_TXSB.p_sbwhdw;
                parament[11].Value = struct_TXSB.p_sbsyxkzh;
                parament[12].Value = struct_TXSB.p_txfs;
                parament[13].Value = struct_TXSB.p_sbpz;
                parament[14].Value = struct_TXSB.p_sbyt;
                parament[15].Value = struct_TXSB.p_sl;
                parament[16].Value = struct_TXSB.p_txlx;
                parament[17].Value = struct_TXSB.p_ykxt_zkf;
                parament[18].Value = struct_TXSB.p_ykxt_skf;
                parament[19].Value = struct_TXSB.p_gzpl;
                parament[20].Value = struct_TXSB.p_fsgl;
                parament[21].Value = struct_TXSB.p_gdfs;
                parament[22].Value = struct_TXSB.p_cszl;
                parament[23].Value = struct_TXSB.p_sbazdd;
                parament[24].Value = struct_TXSB.p_cyzzrs;
                parament[25].Value = struct_TXSB.p_fxjy;
                parament[26].Value = struct_TXSB.p_fxjyrq;
                parament[27].Value = struct_TXSB.p_kfxkdqr;
                parament[28].Value = struct_TXSB.p_fxjyzqzt;
                parament[29].Value = struct_TXSB.p_ddzb_bj_jd;
                parament[30].Value = struct_TXSB.p_ddzb_bj_wd;
                parament[31].Value = struct_TXSB.p_ddzb_wgs_jd;
                parament[32].Value = struct_TXSB.p_ddzb_wgs_wd;
                parament[33].Value = struct_TXSB.p_hhgc;
                parament[34].Value = struct_TXSB.p_gcbz;
                parament[35].Value = struct_TXSB.p_bz;
                parament[36].Value = struct_TXSB.p_scsj;
                parament[37].Value = struct_TXSB.p_zxdm;
                parament[38].Value = struct_TXSB.p_bzqk;
                parament[39].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_SB.Update_TXSB", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[39].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_TXSB.p_czfs;
                struct_RZ_YH.czxx = struct_TXSB.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_TXSB(string p_sbbh,string p_czfs,string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),

                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_sbbh; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_SB.Delete_TXSB", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        */
        #endregion

        protected void Update_TXSB(Struct_TXSB struct_TXSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                    new OracleParameter("p_sbbh",OracleType.VarChar),
                                                    new OracleParameter("p_sblx",OracleType.VarChar),
                                                    new OracleParameter("p_wz",OracleType.VarChar),
                                                    //new OracleParameter("p_tzmc",OracleType.VarChar),
                                                    new OracleParameter("p_ssjc",OracleType.VarChar),
                                                    new OracleParameter("p_tckfsj",OracleType.VarChar),
                                                    new OracleParameter("p_sl",OracleType.VarChar),
                                                    new OracleParameter("p_sbzt",OracleType.VarChar),
                                                    new OracleParameter("p_sbsccj",OracleType.VarChar),
                                                    new OracleParameter("p_sbccbh",OracleType.VarChar),
                                                    new OracleParameter("p_sbxkzsc",OracleType.VarChar),
                                                    new OracleParameter("p_yt",OracleType.VarChar),
                                                    new OracleParameter("p_jlgd",OracleType.VarChar),
                                                    new OracleParameter("p_jlgddx",OracleType.VarChar),
                                                    new OracleParameter("p_jlgdsl",OracleType.VarChar),
                                                    new OracleParameter("p_zlgd",OracleType.VarChar),
                                                    new OracleParameter("p_zlgddx",OracleType.VarChar),
                                                    new OracleParameter("p_zlgdsl",OracleType.VarChar),
                                                    new OracleParameter("p_bhqfw",OracleType.VarChar),
                                                    new OracleParameter("p_sbcsqk",OracleType.VarChar),
                                                    new OracleParameter("p_sbflpz",OracleType.VarChar),
                                                    new OracleParameter("p_zt",OracleType.VarChar),
                                                    new OracleParameter("p_xssjc",OracleType.VarChar),
                                                    new OracleParameter("p_dbsj",OracleType.VarChar),
                                                    new OracleParameter("p_sbbgr",OracleType.VarChar),
                                                    new OracleParameter("p_yyjly_xyyhs",OracleType.VarChar),
                                                    new OracleParameter("p_yyjly_yyxds",OracleType.VarChar),
                                                    new OracleParameter("p_yyjly_sjxds",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_zdlx",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_txkj",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_swdygl",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_fspl",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_jspl",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_xds",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_bj54_jd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_bj54_wd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_wgs84_jd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_tzzb_wgs84_wd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_txszdd",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_txjcgc",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_wxdtzzyxq",OracleType.VarChar),
                                                    new OracleParameter("p_wxdmzxt_sc",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_sbpz",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_sbxds",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txlx",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tcjfrq",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_fspl",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_scgl",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_csfs",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_sc",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_bj54_jd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_bj54_wd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_wgs84_jd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_tzzb_wgs84_wd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txjcgc",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txgd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txszdd",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_wxdtzzyxq",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txsccj",OracleType.VarChar),
                                                    new OracleParameter("p_sgpdktxxt_txxh_lx",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_xtpz",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_xwjtpz",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_xtrjbb",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_jksl_yx",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_jksl_wx",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_MFCxy",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_QSIGxy",OracleType.VarChar),
                                                    new OracleParameter("p_yyjhxt_nh_IPxy",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_xtpz",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_xtrjbb",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_zyxt",OracleType.VarChar),
                                                    new OracleParameter("p_zdzbxt_zdyhlb",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_sbpz",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_sbxds",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txlx",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tcjfrq",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_fspl",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_scgl",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_csfs",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_sc",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_bj54_jd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_bj54_wd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_wgs84_jd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_tzzb_wgs84_wd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txjcgc",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txgd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txszdd",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_wxdtzzyxq",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txsccj",OracleType.VarChar),
                                                    new OracleParameter("p_gpdktxxt_txxh_lx",OracleType.VarChar),
                                                    //new OracleParameter("p_sjc",OracleType.VarChar),
                                                    new OracleParameter("p_id",OracleType.Int32),
                                                    new OracleParameter("p_sjbs",OracleType.VarChar),
                                                    new OracleParameter("p_sjssbm",OracleType.VarChar),
                                                    new OracleParameter("p_csr",OracleType.VarChar),
                                                    new OracleParameter("p_zsr",OracleType.VarChar),
                                                    new OracleParameter("p_lrr",OracleType.VarChar),
                                                    new OracleParameter("p_sbxh",OracleType.VarChar,500),
                                                    new OracleParameter("p_errorCode",OracleType.Int32)

                                           };
                parament[0].Value = struct_TXSB.p_sbbh;
                parament[1].Value = struct_TXSB.p_sblx;
                parament[2].Value = struct_TXSB.p_wz;
                //parament[3].Value = struct_TXSB.p_tzmc;
                parament[3].Value = struct_TXSB.p_ssjc;
                parament[4].Value = struct_TXSB.p_tckfsj;
                parament[5].Value = struct_TXSB.p_sl;
                parament[6].Value = struct_TXSB.p_sbzt;
                parament[7].Value = struct_TXSB.p_sbsccj;
                parament[8].Value = struct_TXSB.p_sbccbh;
                parament[9].Value = struct_TXSB.p_sbxkzsc;
                parament[10].Value = struct_TXSB.p_yt;
                parament[11].Value = struct_TXSB.p_jlgd;
                parament[12].Value = struct_TXSB.p_jlgddx;
                parament[13].Value = struct_TXSB.p_jlgdsl;
                parament[14].Value = struct_TXSB.p_zlgd;
                parament[15].Value = struct_TXSB.p_zlgddx;
                parament[16].Value = struct_TXSB.p_zlgdsl;
                parament[17].Value = struct_TXSB.p_bhqfw;
                parament[18].Value = struct_TXSB.p_sbcsqk;
                parament[19].Value = struct_TXSB.p_sbflpz;
                parament[20].Value = struct_TXSB.p_zt;
                parament[21].Value = struct_TXSB.p_xssjc;
                parament[22].Value = struct_TXSB.p_dbsj;
                parament[23].Value = struct_TXSB.p_sbbgr;



                parament[24].Value = struct_TXSB.p_yyjly_xyyhs;
                parament[25].Value = struct_TXSB.p_yyjly_yyxds;
                parament[26].Value = struct_TXSB.p_yyjly_sjxds;


                parament[27].Value = struct_TXSB.p_wxdmzxt_zdlx;
                parament[28].Value = struct_TXSB.p_wxdmzxt_txkj;
                parament[29].Value = struct_TXSB.p_wxdmzxt_swdygl;
                parament[30].Value = struct_TXSB.p_wxdmzxt_fspl;
                parament[31].Value = struct_TXSB.p_wxdmzxt_jspl;
                parament[32].Value = struct_TXSB.p_wxdmzxt_xds;
                parament[33].Value = struct_TXSB.p_wxdmzxt_tzzb_bj54_jd;
                parament[34].Value = struct_TXSB.p_wxdmzxt_tzzb_bj54_wd;
                parament[35].Value = struct_TXSB.p_wxdmzxt_tzzb_wgs84_jd;
                parament[36].Value = struct_TXSB.p_wxdmzxt_tzzb_wgs84_wd;
                parament[37].Value = struct_TXSB.p_wxdmzxt_txszdd;
                parament[38].Value = struct_TXSB.p_wxdmzxt_txjcgc;
                parament[39].Value = struct_TXSB.p_wxdmzxt_wxdtzzyxq;
                parament[40].Value = struct_TXSB.p_wxdmzxt_sc;


                parament[41].Value = struct_TXSB.p_sgpdktxxt_sbpz;
                parament[42].Value = struct_TXSB.p_sgpdktxxt_sbxds;
                parament[43].Value = struct_TXSB.p_sgpdktxxt_txlx;
                parament[44].Value = struct_TXSB.p_sgpdktxxt_tcjfrq;
                parament[45].Value = struct_TXSB.p_sgpdktxxt_fspl;
                parament[46].Value = struct_TXSB.p_sgpdktxxt_scgl;
                parament[47].Value = struct_TXSB.p_sgpdktxxt_csfs;
                parament[48].Value = struct_TXSB.p_sgpdktxxt_sc;
                parament[49].Value = struct_TXSB.p_sgpdktxxt_tzzb_bj54_jd;
                parament[50].Value = struct_TXSB.p_sgpdktxxt_tzzb_bj54_wd;
                parament[51].Value = struct_TXSB.p_sgpdktxxt_tzzb_wgs84_jd;
                parament[52].Value = struct_TXSB.p_sgpdktxxt_tzzb_wgs84_wd;
                parament[53].Value = struct_TXSB.p_sgpdktxxt_txjcgc;
                parament[54].Value = struct_TXSB.p_sgpdktxxt_txgd;
                parament[55].Value = struct_TXSB.p_sgpdktxxt_txszdd;
                parament[56].Value = struct_TXSB.p_sgpdktxxt_wxdtzzyxq;
                parament[57].Value = struct_TXSB.p_sgpdktxxt_txsccj;
                parament[58].Value = struct_TXSB.p_sgpdktxxt_txxh_lx;


                parament[59].Value = struct_TXSB.p_yyjhxt_nh_xtpz;
                parament[60].Value = struct_TXSB.p_yyjhxt_nh_xwjtpz;
                parament[61].Value = struct_TXSB.p_yyjhxt_nh_xtrjbb;
                parament[62].Value = struct_TXSB.p_yyjhxt_nh_jksl_yx;
                parament[63].Value = struct_TXSB.p_yyjhxt_nh_jksl_wx;
                parament[64].Value = struct_TXSB.p_yyjhxt_nh_MFCxy;
                parament[65].Value = struct_TXSB.p_yyjhxt_nh_QSIGxy;
                parament[66].Value = struct_TXSB.p_yyjhxt_nh_IPxy;


                parament[67].Value = struct_TXSB.p_zdzbxt_xtpz;
                parament[68].Value = struct_TXSB.p_zdzbxt_xtrjbb;
                parament[69].Value = struct_TXSB.p_zdzbxt_zyxt;
                parament[70].Value = struct_TXSB.p_zdzbxt_zdyhlb;


                parament[71].Value = struct_TXSB.p_gpdktxxt_sbpz;
                parament[72].Value = struct_TXSB.p_gpdktxxt_sbxds;
                parament[73].Value = struct_TXSB.p_gpdktxxt_txlx;
                parament[74].Value = struct_TXSB.p_gpdktxxt_tcjfrq;
                parament[75].Value = struct_TXSB.p_gpdktxxt_fspl;
                parament[76].Value = struct_TXSB.p_gpdktxxt_scgl;
                parament[77].Value = struct_TXSB.p_gpdktxxt_csfs;
                parament[78].Value = struct_TXSB.p_gpdktxxt_sc;
                parament[79].Value = struct_TXSB.p_gpdktxxt_tzzb_bj54_jd;
                parament[80].Value = struct_TXSB.p_gpdktxxt_tzzb_bj54_wd;
                parament[81].Value = struct_TXSB.p_gpdktxxt_tzzb_wgs84_jd;
                parament[82].Value = struct_TXSB.p_gpdktxxt_tzzb_wgs84_wd;
                parament[83].Value = struct_TXSB.p_gpdktxxt_txjcgc;
                parament[84].Value = struct_TXSB.p_gpdktxxt_txgd;
                parament[85].Value = struct_TXSB.p_gpdktxxt_txszdd;
                parament[86].Value = struct_TXSB.p_gpdktxxt_wxdtzzyxq;
                parament[87].Value = struct_TXSB.p_gpdktxxt_txsccj;
                parament[88].Value = struct_TXSB.p_gpdktxxt_txxh_lx;

                //parament[89].Value = struct_TXSB.p_sjc;
                parament[89].Value = struct_TXSB.p_id;
                parament[90].Value = struct_TXSB.p_sjbs;
                parament[91].Value = struct_TXSB.p_sjssbm;
                parament[92].Value = struct_TXSB.p_csr;
                parament[93].Value = struct_TXSB.p_zsr;
                parament[94].Value = struct_TXSB.p_lrr;
                parament[95].Value = struct_TXSB.p_sbxh;

                parament[96].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_TXSB.Update_TXSB", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[96].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_TXSB.p_czfs;
                struct_RZ_YH.czxx = struct_TXSB.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }


        //查询详细信息
        protected DataTable Select_TXSB_Detail(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_id",OracleType.Number),
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                          };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_SBGL_TXSB.Select_TXSB_Detail_BySbID", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //数据备份
        protected int TXSB_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_TXSB_Detail(id);
            //备份数据
            Struct_TXSB txsb_bf = new Struct_TXSB();

            txsb_bf.p_sbbh = dt_detail.Rows[0]["sbbh"].ToString();
            txsb_bf.p_sblx = dt_detail.Rows[0]["sblx"].ToString();
            txsb_bf.p_wz = dt_detail.Rows[0]["wz"].ToString();
            txsb_bf.p_ssjc = dt_detail.Rows[0]["ssjc"].ToString();
            txsb_bf.p_tckfsj = dt_detail.Rows[0]["tckfsj"].ToString();
            txsb_bf.p_sl = dt_detail.Rows[0]["sl"].ToString();
            txsb_bf.p_sbzt = dt_detail.Rows[0]["sbzt"].ToString();
            txsb_bf.p_sbsccj = dt_detail.Rows[0]["sbsccj"].ToString();
            txsb_bf.p_sbccbh = dt_detail.Rows[0]["sbccbh"].ToString();
            txsb_bf.p_sbxkzsc = dt_detail.Rows[0]["sbxkzsc"].ToString();
            txsb_bf.p_yt = dt_detail.Rows[0]["yt"].ToString();
            txsb_bf.p_jlgd = dt_detail.Rows[0]["jlgd"].ToString();
            txsb_bf.p_jlgddx = dt_detail.Rows[0]["jlgddx"].ToString();
            txsb_bf.p_jlgdsl = dt_detail.Rows[0]["jlgdsl"].ToString();
            txsb_bf.p_zlgd = dt_detail.Rows[0]["zlgd"].ToString();
            txsb_bf.p_zlgddx = dt_detail.Rows[0]["zlgddx"].ToString();
            txsb_bf.p_zlgdsl = dt_detail.Rows[0]["zlgdsl"].ToString();
            txsb_bf.p_bhqfw = dt_detail.Rows[0]["bhqfw"].ToString();
            txsb_bf.p_sbcsqk = dt_detail.Rows[0]["sbcsqk"].ToString();
            txsb_bf.p_sbflpz = dt_detail.Rows[0]["sbflpz"].ToString();
            txsb_bf.p_zt = "0";
            txsb_bf.p_xssjc = dt_detail.Rows[0]["xssjc"].ToString();
            txsb_bf.p_dbsj = dt_detail.Rows[0]["dbsj"].ToString();
            txsb_bf.p_sbbgr = dt_detail.Rows[0]["sbbgr"].ToString();

            //txsb_bf.p_zlgd = dt_detail.Rows[0]["yyjhxt_nh_xtpz"].ToString();
            txsb_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            txsb_bf.p_xssjc = dt_detail.Rows[0]["xssjc"].ToString();
            txsb_bf.p_dbsj = dt_detail.Rows[0]["dbsj"].ToString();
            txsb_bf.p_sbbgr = dt_detail.Rows[0]["sbbgr"].ToString();

            //语音记录仪
            txsb_bf.p_yyjly_xyyhs = dt_detail.Rows[0]["yyjly_xyyhs"].ToString();
            txsb_bf.p_yyjly_yyxds = dt_detail.Rows[0]["yyjly_yyxds"].ToString();
            txsb_bf.p_yyjly_sjxds = dt_detail.Rows[0]["yyjly_sjxds"].ToString();

            //卫星地面站系统
            txsb_bf.p_wxdmzxt_zdlx = dt_detail.Rows[0]["wxdmzxt_zdlx"].ToString();
            txsb_bf.p_wxdmzxt_txkj = dt_detail.Rows[0]["wxdmzxt_txkj"].ToString();
            txsb_bf.p_wxdmzxt_swdygl = dt_detail.Rows[0]["wxdmzxt_swdygl"].ToString();
            txsb_bf.p_wxdmzxt_fspl = dt_detail.Rows[0]["wxdmzxt_fspl"].ToString();
            txsb_bf.p_wxdmzxt_jspl = dt_detail.Rows[0]["wxdmzxt_jspl"].ToString();
            txsb_bf.p_wxdmzxt_xds = dt_detail.Rows[0]["wxdmzxt_xds"].ToString();
            txsb_bf.p_wxdmzxt_tzzb_bj54_jd = dt_detail.Rows[0]["wxdmzxt_tzzb_bj54_jd"].ToString();
            txsb_bf.p_wxdmzxt_tzzb_bj54_wd = dt_detail.Rows[0]["wxdmzxt_tzzb_bj54_wd"].ToString();
            txsb_bf.p_wxdmzxt_tzzb_wgs84_jd = dt_detail.Rows[0]["wxdmzxt_tzzb_wgs84_jd"].ToString();
            txsb_bf.p_wxdmzxt_tzzb_wgs84_wd = dt_detail.Rows[0]["wxdmzxt_tzzb_wgs84_wd"].ToString();
            txsb_bf.p_wxdmzxt_txszdd = dt_detail.Rows[0]["wxdmzxt_txszdd"].ToString();
            txsb_bf.p_wxdmzxt_txjcgc = dt_detail.Rows[0]["wxdmzxt_txjcgc"].ToString();
            txsb_bf.p_wxdmzxt_wxdtzzyxq = dt_detail.Rows[0]["wxdmzxt_wxdtzzyxq"].ToString();
            txsb_bf.p_wxdmzxt_sc = dt_detail.Rows[0]["wxdmzxt_sc"].ToString();

            //甚高频地空通信系统
            txsb_bf.p_sgpdktxxt_sbpz = dt_detail.Rows[0]["sgpdktxxt_sbpz"].ToString();
            txsb_bf.p_sgpdktxxt_sbxds = dt_detail.Rows[0]["sgpdktxxt_sbxds"].ToString();
            txsb_bf.p_sgpdktxxt_txlx = dt_detail.Rows[0]["sgpdktxxt_txlx"].ToString();
            txsb_bf.p_sgpdktxxt_tcjfrq = dt_detail.Rows[0]["sgpdktxxt_tcjfrq"].ToString();
            txsb_bf.p_sgpdktxxt_fspl = dt_detail.Rows[0]["sgpdktxxt_fspl"].ToString();
            txsb_bf.p_sgpdktxxt_scgl = dt_detail.Rows[0]["sgpdktxxt_scgl"].ToString();
            txsb_bf.p_sgpdktxxt_csfs = dt_detail.Rows[0]["sgpdktxxt_csfs"].ToString();
            txsb_bf.p_sgpdktxxt_sc = dt_detail.Rows[0]["sgpdktxxt_sc"].ToString();
            txsb_bf.p_sgpdktxxt_tzzb_bj54_jd = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_jd"].ToString();
            txsb_bf.p_sgpdktxxt_tzzb_bj54_wd = dt_detail.Rows[0]["sgpdktxxt_tzzb_bj54_wd"].ToString();
            txsb_bf.p_sgpdktxxt_tzzb_wgs84_jd = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_jd"].ToString();
            txsb_bf.p_sgpdktxxt_tzzb_wgs84_wd = dt_detail.Rows[0]["sgpdktxxt_tzzb_wgs84_wd"].ToString();
            txsb_bf.p_sgpdktxxt_txjcgc = dt_detail.Rows[0]["sgpdktxxt_txjcgc"].ToString();
            txsb_bf.p_sgpdktxxt_txgd = dt_detail.Rows[0]["sgpdktxxt_txgd"].ToString();
            txsb_bf.p_sgpdktxxt_txszdd = dt_detail.Rows[0]["sgpdktxxt_txszdd"].ToString();
            txsb_bf.p_sgpdktxxt_wxdtzzyxq = dt_detail.Rows[0]["sgpdktxxt_wxdtzzyxq"].ToString();
            txsb_bf.p_sgpdktxxt_txsccj = dt_detail.Rows[0]["sgpdktxxt_txsccj"].ToString();
            txsb_bf.p_sgpdktxxt_txxh_lx = dt_detail.Rows[0]["sgpdktxxt_txxh_lx"].ToString();

            //语音交换系统(内话)
            txsb_bf.p_yyjhxt_nh_xtpz = dt_detail.Rows[0]["yyjhxt_nh_xtpz"].ToString();
            txsb_bf.p_yyjhxt_nh_xwjtpz = dt_detail.Rows[0]["yyjhxt_nh_xwjtpz"].ToString();
            txsb_bf.p_yyjhxt_nh_xtrjbb = dt_detail.Rows[0]["yyjhxt_nh_xtrjbb"].ToString();
            txsb_bf.p_yyjhxt_nh_jksl_yx = dt_detail.Rows[0]["yyjhxt_nh_jksl_yx"].ToString();
            txsb_bf.p_yyjhxt_nh_jksl_wx = dt_detail.Rows[0]["yyjhxt_nh_jksl_wx"].ToString();
            txsb_bf.p_yyjhxt_nh_MFCxy = dt_detail.Rows[0]["yyjhxt_nh_MFCxy"].ToString();
            txsb_bf.p_yyjhxt_nh_QSIGxy = dt_detail.Rows[0]["yyjhxt_nh_QSIGxy"].ToString();
            txsb_bf.p_yyjhxt_nh_IPxy = dt_detail.Rows[0]["yyjhxt_nh_IPxy"].ToString();

            //自动转报系统
            txsb_bf.p_zdzbxt_xtpz= dt_detail.Rows[0]["zdzbxt_xtpz"].ToString();
            txsb_bf.p_zdzbxt_xtrjbb = dt_detail.Rows[0]["zdzbxt_xtrjbb"].ToString();
            txsb_bf.p_zdzbxt_zyxt = dt_detail.Rows[0]["zdzbxt_zyxt"].ToString();
            txsb_bf.p_zdzbxt_zdyhlb = dt_detail.Rows[0]["zdzbxt_zdyhlb"].ToString();

            //高频地空通信系统
            txsb_bf.p_gpdktxxt_sbpz= dt_detail.Rows[0]["gpdktxxt_sbpz"].ToString();
            txsb_bf.p_gpdktxxt_sbxds = dt_detail.Rows[0]["gpdktxxt_sbxds"].ToString();
            txsb_bf.p_gpdktxxt_txlx = dt_detail.Rows[0]["gpdktxxt_txlx"].ToString();
            txsb_bf.p_gpdktxxt_tcjfrq = dt_detail.Rows[0]["gpdktxxt_tcjfrq"].ToString();
            txsb_bf.p_gpdktxxt_fspl = dt_detail.Rows[0]["gpdktxxt_fspl"].ToString();
            txsb_bf.p_gpdktxxt_scgl = dt_detail.Rows[0]["gpdktxxt_scgl"].ToString();
            txsb_bf.p_gpdktxxt_csfs = dt_detail.Rows[0]["gpdktxxt_csfs"].ToString();
            txsb_bf.p_gpdktxxt_sc = dt_detail.Rows[0]["gpdktxxt_sc"].ToString();
            txsb_bf.p_gpdktxxt_tzzb_bj54_jd = dt_detail.Rows[0]["gpdktxxt_tzzb_bj54_jd"].ToString();
            txsb_bf.p_gpdktxxt_tzzb_bj54_wd = dt_detail.Rows[0]["gpdktxxt_tzzb_bj54_wd"].ToString();
            txsb_bf.p_gpdktxxt_tzzb_wgs84_jd = dt_detail.Rows[0]["gpdktxxt_tzzb_wgs84_jd"].ToString();
            txsb_bf.p_gpdktxxt_tzzb_wgs84_wd = dt_detail.Rows[0]["gpdktxxt_tzzb_wgs84_wd"].ToString();
            txsb_bf.p_gpdktxxt_txjcgc = dt_detail.Rows[0]["gpdktxxt_txjcgc"].ToString();
            txsb_bf.p_gpdktxxt_txgd = dt_detail.Rows[0]["gpdktxxt_txgd"].ToString();
            txsb_bf.p_gpdktxxt_txszdd = dt_detail.Rows[0]["gpdktxxt_txszdd"].ToString();
            txsb_bf.p_gpdktxxt_wxdtzzyxq = dt_detail.Rows[0]["gpdktxxt_wxdtzzyxq"].ToString();
            txsb_bf.p_gpdktxxt_txsccj = dt_detail.Rows[0]["gpdktxxt_txsccj"].ToString();
            txsb_bf.p_gpdktxxt_txxh_lx = dt_detail.Rows[0]["gpdktxxt_txxh_lx"].ToString();

            txsb_bf.p_sbxh= dt_detail.Rows[0]["sbxh"].ToString();

            txsb_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            txsb_bf.p_sjbs = "2";
            txsb_bf.p_sjssbm = dt_detail.Rows[0]["sjssbm"].ToString();
            
            txsb_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            txsb_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            txsb_bf.p_lrr = _us.userLoginName;
            txsb_bf.p_shsj = "";
            txsb_bf.p_czfs = "02";
            txsb_bf.p_czxx = "员工奖励id:" + id + "生成副本数据";
            //插入
            Insert_TXSB(txsb_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = txsb_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_TXSB.Select_TXSB_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }


        #region 更新状态
        protected void Update_TXSBZT(Struct_TXSB txsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = txsb.p_id;
                paras[1].Value = txsb.p_zt;
                paras[2].Value = txsb.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_TXSB.Update_TXSBZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = txsb.p_czfs;
                struct_rz.czxx = txsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //变更数据标识
        protected void Update_TXSB_SJBS_ZT(Struct_TXSB txsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = txsb.p_sjc;
                paras[1].Value = txsb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_TXSB.Update_TXSB_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = txsb.p_czfs;
                struct_rz.czxx = txsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_TXSB_SJBS_LSSJ_ZT(Struct_TXSB txsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = txsb.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_TXSB.Update_TXSB_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = txsb.p_czfs;
                struct_rz.czxx = txsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        #region 将副本数据变为最终数据
        protected void Update_YGJL_SJBS_FBSJ_ZT(Struct_TXSB txsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = txsb.p_sjc;
                paras[1].Value = txsb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_TXSB.Update_TXSB_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = txsb.p_czfs;
                struct_rz.czxx = txsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        protected void Delete_TXSB(int id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                              new OracleParameter("p_id",OracleType.Number),
                                              new OracleParameter("p_errorCode",OracleType.Int32)
                                          };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_SBGL_TXSB.Delete_TXSB", parament, out result);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_us);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }


        #region 将副本数据变为最终数据
        protected void Update_TXSB_SJBS_FBSJ_ZT(Struct_TXSB txsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = txsb.p_sjc;
                paras[1].Value = txsb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_TXSB.Update_TXSB_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = txsb.p_czfs;
                struct_rz.czxx = txsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        protected string Select_SB_MaxNumber(string sjjd)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("sjjd",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = sjjd;
                parament[1].Direction = ParameterDirection.Output;
                string count = dbclass.RunProcedure("PACK_SBGL_TXSB.Select_SB_MaxNumber", parament, "table").Tables[0].Rows[0][0].ToString();
                if (count == "")
                {
                    count = "0";
                }
                
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_TXSB_DC(int p_userid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_userid",OracleType.Int32),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };

                paras[0].Value = p_userid;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_SBGL_TXSB.Select_TXSB_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

    }
}
