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
    public struct Struct_DHSB
    {
        public int p_id;
        public string p_sbbh;//设备编号
        public string p_sbxh;//设备型号
        public string p_sblx;//设备类型
        public string p_tzmczl_tzmc;//台站名称种类_台站名称
        public string p_tzmczl_wz;//台站名称种类_位置
        public string p_tzmczl_sblx;//台站名称种类_设备类型
        public string p_yssjc;//原所属机场
        public string p_pl;//频率
        public string p_pldw;//频率单位
        public string p_hh;//呼号
        public string p_txzxdmgc;//天线中心地面高程
        public string p_tx;//天线
        public string p_jfzq;//校飞周期
        public string p_jfdqrq;//校飞到期日期
        public string p_tckfsj;//投产开放时间
        public string p_tcjfsj;//投产校飞时间
        public string p_tcsfxy;//投产是否限用
        public string p_tcsm;//投产说明
        public string p_mcfxjyrq;//末次飞行校验日期
        public string p_mcfxjyjg;//末次飞行校验结果
        public string p_mcfxjysm;//末次飞行校验说明
        public string p_ddzbbjjd;//大地坐标（北京54）经度
        public string p_ddzbbjwd;//大地坐标（北京54）纬度
        public string p_ddzbwgsjd;//大地坐标（wgs84）经度
        public string p_ddzbwgswd;//大地坐标（wgs84）纬度
        public string p_sl;//数量
        public string p_sbcj;//设备厂家
        public string p_scgl;//输出功率
        public string p_scgldw;//输出功率单位
        public string p_sbccbh;//设备出厂编号
        public string p_fgfw;//覆盖范围
        public string p_fgfwdw;//覆盖范围单位
        public string p_sbzt;//设备状态
        public string p_jpdzxjl;//距跑道中心距离
        public string p_pdcd;//跑道长度
        public string p_synx;//使用年限
        public string p_jlgd;//交流供电
        public string p_jlgddx;//交流供电大小
        public string p_jlgdsl;//交流供电数量
        public string p_zlgd;//直流供电
        public string p_zlgddx;//直流供电大小
        public string p_zlgdsl;//直流供电数量
        public string p_sbcsqk;//设备传输情况
        public string p_sbflpz;//设备防雷配置
        public string p_xssjc;//现所属机场
        public string p_dbsj;//调拨时间
        public string p_sbbgr;//设备保管人




        //地面设备
        public string p_dmsbtxlx;//地卖弄设备 天线类型
        //航向设备
        public string p_hxsblb;//航向设备 类别
        public string p_hxsbpdh;//航向设备 跑道号
        public string p_hxsbtxzxh;//航向设备 天线阵型号
        public string p_hxsbtxzlx;//航向设备 天线阵类型
        public string p_hxsbtxzzs;//航向设备 天线阵子数
        public string p_hxsbjpdmdjl;//航向设备 天线阵距跑道末端距离
        public string p_hxsbjpdrkjl;//航向设备 天线阵距跑道入口距离
        public string p_hxsbzxczjl;//航向设备 天线阵距跑道中心垂直距离
        //下滑设备
        public string p_xhsbsjxhj;//下滑设备 设计下滑角
        public string p_xhsbsjrkgd;//下滑设备 设计入口高度
        public string p_xhsbtxzlx;//下滑设备 天线阵类型
        public string p_xhsbtcxtxgd;//下滑设备 投产下天线高度
        public string p_xhsbmqxtxgd;//下滑设备 目前下天线高度
        public string p_xhsbtcstxgd;//下滑设备 投产上天线高度
        public string p_xhsbmqstxgd;//下滑设备 目前上天线高度
        public string p_xhsbtxtgd;//下滑设备 天线塔高度 
        public string p_xhsbjpdrkncjl;//下滑设备 距跑道入口内侧距离
        public string p_xhsbjpdzxcj;//下滑设备 距跑道中心线垂距
        public string p_xhsbwypdzxx;//下滑设备 位于跑道中心线
        public string p_xhsbtxzxh;//下滑设备 天线阵型号
        public string p_xhsbmjjzgrdh;//下滑设备 盲降基准高RDH
        //测距仪
        public string p_cjycpc;//测距仪 磁盘差
        public string p_cjypdh;//测距仪 跑道号
        public string p_cjydj;//测距仪 端距
        public string p_cjybdh;//测距仪 波道号
        public string p_cjyptsb;//测距仪 配套设备
        public string p_cjyjspl;//测距仪 接收频率
        public string p_cjyxtyc;//测距仪 系统延迟
        public string p_cjymcjg;//测距仪 脉冲间隔
        //全向信标
        public string p_qxxbcpc;//全向信标 磁偏差
        public string p_qxxbdwgd;//全向信标 地网高度
        public string p_qxxbjkqfw;//全向信标 监控器方位
        public string p_qxxbdwzj;//全向信标 地网直径
        public string p_qxxbdwlx;//全向信标 地网类型
        public string p_qxxbpdh;//全向信标 跑道号
        public string p_qxxbdj;//全向信标 端距
        //无方向信标
        public string p_wfxxbcpc;//无方向信标 磁偏差
        public string p_wfxxbdwgd;//无方向信标 地网高度
        public string p_wfxxbjkqfw;//无方向信标 监控器方位
        public string p_wfxxbdwzj;//无方向信标 地网直径
        public string p_wfxxbdwlx;//无方向信标 地网类型
        public string p_wfxxbpdh;//无方向信标 跑道号
        public string p_wfxxbdj;//无方向信标 端距
        //指点信标
        public string p_zdxbpdh;//指点信标 跑道号
        public string p_zdxbdj;//指点信标 端距
        public string p_zdxblxxz;//指点信标 类型选择

        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public int p_pagesize;
        public int p_currentpage;

        public DateTime p_xtsj;

        public string p_wxdlj;//无线电设备发射核准证件路径
        public string p_mcjflj;//末次校飞报告路径
        public string p_plhhlj;//频率呼号文件路径
        public string p_sbxkzlj;//设备许可证路径
        public string p_tzpflj;//台址批复文件路径
        public string p_bhqlj;//保护区范围路径
        public string p_scip;//上传IP
        public string p_wjscsj;//文件上传时间
        public string p_wxdsbfshzzj;//无线电设备法神核准证件
        public string p_mcjfbg;//末次校飞报告
        public string p_plhhwj;//频率呼号文件
        public string p_sbxkz;//设备许可证
        public string p_tzpfwj;//台址批复文件
        public string p_bhqfw;//保护区范围
        public string p_scwjsjc;//上传文件时间戳


        public int p_userid;
        public string p_bmdm;

        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }

    public class ODHSB
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private RZ rz;
        private UserState _us = null;
        public ODHSB(UserState state)
        {
            _us = state;
        }
        #region  ===============导航设备================
        protected DataSet Select_DHSB(Struct_DHSB struct_DHSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbxh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_tzmczl_tzmc",OracleType.VarChar),
                                               new OracleParameter("p_tzmczl_wz",OracleType.VarChar),
                                               new OracleParameter("p_tzmczl_sblx",OracleType.VarChar),
                                               new OracleParameter("p_yssjc",OracleType.VarChar),
                                               new OracleParameter("p_jfdqrq",OracleType.VarChar),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_DHSB.p_sbxh;
                parament[1].Value = struct_DHSB.p_sblx;
                parament[2].Value = struct_DHSB.p_tzmczl_tzmc;
                parament[3].Value = struct_DHSB.p_tzmczl_wz;
                parament[4].Value = struct_DHSB.p_tzmczl_sblx;
                parament[5].Value = struct_DHSB.p_yssjc;
                parament[6].Value = struct_DHSB.p_jfdqrq;
                parament[7].Value = struct_DHSB.p_currentpage;
                parament[8].Value = struct_DHSB.p_pagesize;
                parament[9].Value = struct_DHSB.p_userid;
                parament[10].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_DHSB.Select_DHSB", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_DHSB_Detail(int p_id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_DHSB.Select_DHSB_Detail", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DHSB_Count(Struct_DHSB struct_DHSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbxh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_tzmczl_tzmc",OracleType.VarChar),
                                               new OracleParameter("p_tzmczl_wz",OracleType.VarChar),
                                               new OracleParameter("p_tzmczl_sblx",OracleType.VarChar),
                                               new OracleParameter("p_yssjc",OracleType.VarChar),
                                               new OracleParameter("p_jfdqrq",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_DHSB.p_sbxh;
                parament[1].Value = struct_DHSB.p_sblx;
                parament[2].Value = struct_DHSB.p_tzmczl_tzmc;
                parament[3].Value = struct_DHSB.p_tzmczl_wz;
                parament[4].Value = struct_DHSB.p_tzmczl_sblx;
                parament[5].Value = struct_DHSB.p_yssjc;
                parament[6].Value = struct_DHSB.p_jfdqrq;
                parament[7].Value = struct_DHSB.p_userid;
                parament[8].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_DHSB.Select_DHSB_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected string Select_DHSB_MaxNumber(string sjjd)
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
                string count = dbclass.RunProcedure("PACK_KG_DHSB.Select_DHSB_MaxNumber", parament, "table").Tables[0].Rows[0][0].ToString();
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
        protected DataSet Select_Max_dhsbbh(string bm_sblx)
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
                ds = dbclass.RunProcedure("PACK_KG_DHSB.Select_Max_dhsbbh", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_DHSB(Struct_DHSB struct_DHSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                      new OracleParameter("p_sbbh",OracleType.VarChar),
                                                      new OracleParameter("p_sbxh",OracleType.VarChar),
                                                      new OracleParameter("p_sblx",OracleType.VarChar),
                                                      new OracleParameter("p_tzmczl_tzmc",OracleType.VarChar),
                                                      new OracleParameter("p_tzmczl_wz",OracleType.VarChar),
                                                      new OracleParameter("p_tzmczl_sblx",OracleType.VarChar),
                                                      new OracleParameter("p_yssjc",OracleType.VarChar),
                                                      new OracleParameter("p_pl",OracleType.VarChar),
                                                      new OracleParameter("p_pldw",OracleType.VarChar),
                                                      new OracleParameter("p_hh",OracleType.VarChar),
                                                      new OracleParameter("p_txzxdmgc",OracleType.VarChar),
                                                      new OracleParameter("p_tx",OracleType.VarChar),
                                                      new OracleParameter("p_jfzq",OracleType.VarChar),
                                                      new OracleParameter("p_jfdqrq",OracleType.VarChar),
                                                      new OracleParameter("p_tckfsj",OracleType.VarChar),
                                                      new OracleParameter("p_tcjfsj",OracleType.VarChar),
                                                      new OracleParameter("p_tcsfxy",OracleType.VarChar),
                                                      new OracleParameter("p_tcsm",OracleType.VarChar),
                                                      new OracleParameter("p_mcfxjyrq",OracleType.VarChar),
                                                      new OracleParameter("p_mcfxjyjg",OracleType.VarChar),
                                                      new OracleParameter("p_mcfxjysm",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbbjjd",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbbjwd",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbwgsjd",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbwgswd",OracleType.VarChar),
                                                      new OracleParameter("p_sl",OracleType.VarChar),
                                                      new OracleParameter("p_sbcj",OracleType.VarChar),
                                                      new OracleParameter("p_scgl",OracleType.VarChar),
                                                      new OracleParameter("p_scgldw",OracleType.VarChar),
                                                      new OracleParameter("p_sbccbh",OracleType.VarChar),
                                                      new OracleParameter("p_fgfw",OracleType.VarChar),
                                                      new OracleParameter("p_fgfwdw",OracleType.VarChar),
                                                      new OracleParameter("p_sbzt",OracleType.VarChar),
                                                      new OracleParameter("p_jpdzxjl",OracleType.VarChar),
                                                      new OracleParameter("p_pdcd",OracleType.VarChar),
                                                      new OracleParameter("p_synx",OracleType.VarChar),
                                                      new OracleParameter("p_jlgd",OracleType.VarChar),
                                                      new OracleParameter("p_jlgddx",OracleType.VarChar),
                                                      new OracleParameter("p_jlgdsl",OracleType.VarChar),
                                                      new OracleParameter("p_zlgd",OracleType.VarChar),
                                                      new OracleParameter("p_zlgddx",OracleType.VarChar),
                                                      new OracleParameter("p_zlgdsl",OracleType.VarChar),
                                                      new OracleParameter("p_sbcsqk",OracleType.VarChar),
                                                      new OracleParameter("p_sbflpz",OracleType.VarChar),
                                                      new OracleParameter("p_xssjc",OracleType.VarChar),
                                                      new OracleParameter("p_dbsj",OracleType.VarChar),
                                                      new OracleParameter("p_sbbgr",OracleType.VarChar),
                                                      //地面设备
                                                      new OracleParameter("p_dmsbtxlx",OracleType.VarChar),
                                                      //航向设备
                                                      new OracleParameter("p_hxsblb",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbtxzxh",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbtxzlx",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbtxzzs",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbjpdmdjl",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbjpdrkjl",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbzxczjl",OracleType.VarChar),
                                                      //下滑设备
                                                      new OracleParameter("p_xhsbsjxhj",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbsjrkgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtxzlx",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtcxtxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbmqxtxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtcstxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbmqstxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtxtgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbjpdrkncjl",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbjpdzxcj",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbwypdzxx",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtxzxh",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbmjjzgrdh",OracleType.VarChar),
                                                      //测距仪
                                                      new OracleParameter("p_cjycpc",OracleType.VarChar),
                                                      new OracleParameter("p_cjypdh",OracleType.VarChar),
                                                      new OracleParameter("p_cjydj",OracleType.VarChar),
                                                      new OracleParameter("p_cjybdh",OracleType.VarChar),
                                                      new OracleParameter("p_cjyptsb",OracleType.VarChar),
                                                      new OracleParameter("p_cjyjspl",OracleType.VarChar),
                                                      new OracleParameter("p_cjyxtyc",OracleType.VarChar),
                                                      new OracleParameter("p_cjymcjg",OracleType.VarChar),
                                                      //全向信标
                                                      new OracleParameter("p_qxxbcpc",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdwgd",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbjkqfw",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdwzj",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdwlx",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdj",OracleType.VarChar),
                                                      //无方向信标
                                                      new OracleParameter("p_wfxxbcpc",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdwgd",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbjkqfw",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdwzj",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdwlx",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdj",OracleType.VarChar),
                                                      //指点信标
                                                      new OracleParameter("p_zdxbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_zdxbdj",OracleType.VarChar),
                                                      new OracleParameter("p_zdxblxxz",OracleType.VarChar),

                                                      new OracleParameter("p_xtsj",OracleType.DateTime),

                                                      new OracleParameter("p_wxdlj",OracleType.VarChar),
                                                      new OracleParameter("p_mcjflj",OracleType.VarChar),
                                                      new OracleParameter("p_plhhlj",OracleType.VarChar),
                                                      new OracleParameter("p_sbxkzlj",OracleType.VarChar),
                                                      new OracleParameter("p_tzpflj",OracleType.VarChar),
                                                      new OracleParameter("p_bhqlj",OracleType.VarChar),
                                                      new OracleParameter("p_scip",OracleType.VarChar),

                                                      new OracleParameter("p_wxdsbfshzzj",OracleType.VarChar),
                                                      new OracleParameter("p_mcjfbg",OracleType.VarChar),
                                                      new OracleParameter("p_plhhwj",OracleType.VarChar),
                                                      new OracleParameter("p_sbxkz",OracleType.VarChar),
                                                      new OracleParameter("p_tzpfwj",OracleType.VarChar),
                                                      new OracleParameter("p_bhqfw",OracleType.VarChar),
                                                      new OracleParameter("p_scwjsjc",OracleType.VarChar),

                                                      new OracleParameter("p_csr",OracleType.VarChar),
                                                      new OracleParameter("p_zsr",OracleType.VarChar),
                                                      new OracleParameter("p_lrr",OracleType.VarChar),
                                                      new OracleParameter("p_sjc",OracleType.VarChar),
                                                      new OracleParameter("p_sjbs",OracleType.VarChar),
                                                      new OracleParameter("p_zt",OracleType.VarChar),
                                                      new OracleParameter("p_bmdm",OracleType.VarChar),

                                                      new OracleParameter("p_errorCode",OracleType.Int32)
                                           };


                parament[0].Value = struct_DHSB.p_sbbh;
                parament[1].Value = struct_DHSB.p_sbxh;
                parament[2].Value = struct_DHSB.p_sblx;
                parament[3].Value = struct_DHSB.p_tzmczl_tzmc;
                parament[4].Value = struct_DHSB.p_tzmczl_wz;
                parament[5].Value = struct_DHSB.p_tzmczl_sblx;
                parament[6].Value = struct_DHSB.p_yssjc;
                parament[7].Value = struct_DHSB.p_pl;
                parament[8].Value = struct_DHSB.p_pldw;
                parament[9].Value = struct_DHSB.p_hh;
                parament[10].Value = struct_DHSB.p_txzxdmgc;
                parament[11].Value = struct_DHSB.p_tx;
                parament[12].Value = struct_DHSB.p_jfzq;
                parament[13].Value = struct_DHSB.p_jfdqrq;
                parament[14].Value = struct_DHSB.p_tckfsj;
                parament[15].Value = struct_DHSB.p_tcjfsj;
                parament[16].Value = struct_DHSB.p_tcsfxy;
                parament[17].Value = struct_DHSB.p_tcsm;
                parament[18].Value = struct_DHSB.p_mcfxjyrq;
                parament[19].Value = struct_DHSB.p_mcfxjyjg;
                parament[20].Value = struct_DHSB.p_mcfxjysm;
                parament[21].Value = struct_DHSB.p_ddzbbjjd;
                parament[22].Value = struct_DHSB.p_ddzbbjwd;
                parament[23].Value = struct_DHSB.p_ddzbwgsjd;
                parament[24].Value = struct_DHSB.p_ddzbwgswd;
                parament[25].Value = struct_DHSB.p_sl;
                parament[26].Value = struct_DHSB.p_sbcj;
                parament[27].Value = struct_DHSB.p_scgl;
                parament[28].Value = struct_DHSB.p_scgldw;
                parament[29].Value = struct_DHSB.p_sbccbh;
                parament[30].Value = struct_DHSB.p_fgfw;
                parament[31].Value = struct_DHSB.p_fgfwdw;
                parament[32].Value = struct_DHSB.p_sbzt;
                parament[33].Value = struct_DHSB.p_jpdzxjl;
                parament[34].Value = struct_DHSB.p_pdcd;
                parament[35].Value = struct_DHSB.p_synx;
                parament[36].Value = struct_DHSB.p_jlgd;
                parament[37].Value = struct_DHSB.p_jlgddx;
                parament[38].Value = struct_DHSB.p_jlgdsl;
                parament[39].Value = struct_DHSB.p_zlgd;
                parament[40].Value = struct_DHSB.p_zlgddx;
                parament[41].Value = struct_DHSB.p_zlgdsl;
                parament[42].Value = struct_DHSB.p_sbcsqk;
                parament[43].Value = struct_DHSB.p_sbflpz;
                parament[44].Value = struct_DHSB.p_xssjc;
                parament[45].Value = struct_DHSB.p_dbsj;
                parament[46].Value = struct_DHSB.p_sbbgr;
                //地面设备
                parament[47].Value = struct_DHSB.p_dmsbtxlx;
                //航向设备
                parament[48].Value = struct_DHSB.p_hxsblb;
                parament[49].Value = struct_DHSB.p_hxsbpdh;
                parament[50].Value = struct_DHSB.p_hxsbtxzxh;
                parament[51].Value = struct_DHSB.p_hxsbtxzlx;
                parament[52].Value = struct_DHSB.p_hxsbtxzzs;
                parament[53].Value = struct_DHSB.p_hxsbjpdmdjl;
                parament[54].Value = struct_DHSB.p_hxsbjpdrkjl;
                parament[55].Value = struct_DHSB.p_hxsbzxczjl;
                //下滑设备
                parament[56].Value = struct_DHSB.p_xhsbsjxhj;
                parament[57].Value = struct_DHSB.p_xhsbsjrkgd;
                parament[58].Value = struct_DHSB.p_xhsbtxzlx;
                parament[59].Value = struct_DHSB.p_xhsbtcxtxgd;
                parament[60].Value = struct_DHSB.p_xhsbmqxtxgd;
                parament[61].Value = struct_DHSB.p_xhsbtcstxgd;
                parament[62].Value = struct_DHSB.p_xhsbmqstxgd;
                parament[63].Value = struct_DHSB.p_xhsbtxtgd;
                parament[64].Value = struct_DHSB.p_xhsbjpdrkncjl;
                parament[65].Value = struct_DHSB.p_xhsbjpdzxcj;
                parament[66].Value = struct_DHSB.p_xhsbwypdzxx;
                parament[67].Value = struct_DHSB.p_xhsbtxzxh;
                parament[68].Value = struct_DHSB.p_xhsbmjjzgrdh;
                //测距仪
                parament[69].Value = struct_DHSB.p_cjycpc;
                parament[70].Value = struct_DHSB.p_cjypdh;
                parament[71].Value = struct_DHSB.p_cjydj;
                parament[72].Value = struct_DHSB.p_cjybdh;
                parament[73].Value = struct_DHSB.p_cjyptsb;
                parament[74].Value = struct_DHSB.p_cjyjspl;
                parament[75].Value = struct_DHSB.p_cjyxtyc;
                parament[76].Value = struct_DHSB.p_cjymcjg;
                //全向信标
                parament[77].Value = struct_DHSB.p_qxxbcpc;
                parament[78].Value = struct_DHSB.p_qxxbdwgd;
                parament[79].Value = struct_DHSB.p_qxxbjkqfw;
                parament[80].Value = struct_DHSB.p_qxxbdwzj;
                parament[81].Value = struct_DHSB.p_qxxbdwlx;
                parament[82].Value = struct_DHSB.p_qxxbpdh;
                parament[83].Value = struct_DHSB.p_qxxbdj;
                //无方向信标
                parament[84].Value = struct_DHSB.p_wfxxbcpc;
                parament[85].Value = struct_DHSB.p_wfxxbdwgd;
                parament[86].Value = struct_DHSB.p_wfxxbjkqfw;
                parament[87].Value = struct_DHSB.p_wfxxbdwzj;
                parament[88].Value = struct_DHSB.p_wfxxbdwlx;
                parament[89].Value = struct_DHSB.p_wfxxbpdh;
                parament[90].Value = struct_DHSB.p_wfxxbdj;
                //指点信标
                parament[91].Value = struct_DHSB.p_zdxbpdh;
                parament[92].Value = struct_DHSB.p_zdxbdj;
                parament[93].Value = struct_DHSB.p_zdxblxxz;

                parament[94].Value = struct_DHSB.p_xtsj;

                parament[95].Value = struct_DHSB.p_wxdlj;
                parament[96].Value = struct_DHSB.p_mcjflj;
                parament[97].Value = struct_DHSB.p_plhhlj;
                parament[98].Value = struct_DHSB.p_sbxkzlj;
                parament[99].Value = struct_DHSB.p_tzpflj;
                parament[100].Value = struct_DHSB.p_bhqlj;
                parament[101].Value = struct_DHSB.p_scip;


                parament[102].Value = struct_DHSB.p_wxdsbfshzzj;
                parament[103].Value = struct_DHSB.p_mcjfbg;
                parament[104].Value = struct_DHSB.p_plhhwj;
                parament[105].Value = struct_DHSB.p_sbxkz;
                parament[106].Value = struct_DHSB.p_tzpfwj;
                parament[107].Value = struct_DHSB.p_bhqfw;
                parament[108].Value = struct_DHSB.p_scwjsjc;

                parament[109].Value = struct_DHSB.p_csr;
                parament[110].Value = struct_DHSB.p_zsr;
                parament[111].Value = struct_DHSB.p_lrr;
                parament[112].Value = struct_DHSB.p_sjc;
                parament[113].Value = struct_DHSB.p_sjbs;
                parament[114].Value = struct_DHSB.p_zt;
                parament[115].Value = struct_DHSB.p_bmdm;

                parament[116].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DHSB.Insert_DHSB", parament, out reslut);

                int returnCode = /*Convert.ToInt32(parament[95].Value)*/0;
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_DHSB.p_czfs;
                struct_RZ_YH.czxx = struct_DHSB.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_DHSB(Struct_DHSB struct_DHSB)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                      new OracleParameter("p_sbbh",OracleType.VarChar),
                                                      new OracleParameter("p_sbxh",OracleType.VarChar),
                                                      new OracleParameter("p_sblx",OracleType.VarChar),
                                                      new OracleParameter("p_tzmczl_tzmc",OracleType.VarChar),
                                                      new OracleParameter("p_tzmczl_wz",OracleType.VarChar),
                                                      new OracleParameter("p_tzmczl_sblx",OracleType.VarChar),
                                                      new OracleParameter("p_yssjc",OracleType.VarChar),
                                                      new OracleParameter("p_pl",OracleType.VarChar),
                                                      new OracleParameter("p_pldw",OracleType.VarChar),
                                                      new OracleParameter("p_hh",OracleType.VarChar),
                                                      new OracleParameter("p_txzxdmgc",OracleType.VarChar),
                                                      new OracleParameter("p_tx",OracleType.VarChar),
                                                      new OracleParameter("p_jfzq",OracleType.VarChar),
                                                      new OracleParameter("p_jfdqrq",OracleType.VarChar),
                                                      new OracleParameter("p_tckfsj",OracleType.VarChar),
                                                      new OracleParameter("p_tcjfsj",OracleType.VarChar),
                                                      new OracleParameter("p_tcsfxy",OracleType.VarChar),
                                                      new OracleParameter("p_tcsm",OracleType.VarChar),
                                                      new OracleParameter("p_mcfxjyrq",OracleType.VarChar),
                                                      new OracleParameter("p_mcfxjyjg",OracleType.VarChar),
                                                      new OracleParameter("p_mcfxjysm",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbbjjd",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbbjwd",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbwgsjd",OracleType.VarChar),
                                                      new OracleParameter("p_ddzbwgswd",OracleType.VarChar),
                                                      new OracleParameter("p_sl",OracleType.VarChar),
                                                      new OracleParameter("p_sbcj",OracleType.VarChar),
                                                      new OracleParameter("p_scgl",OracleType.VarChar),
                                                      new OracleParameter("p_scgldw",OracleType.VarChar),
                                                      new OracleParameter("p_sbccbh",OracleType.VarChar),
                                                      new OracleParameter("p_fgfw",OracleType.VarChar),
                                                      new OracleParameter("p_fgfwdw",OracleType.VarChar),
                                                      new OracleParameter("p_sbzt",OracleType.VarChar),
                                                      new OracleParameter("p_jpdzxjl",OracleType.VarChar),
                                                      new OracleParameter("p_pdcd",OracleType.VarChar),
                                                      new OracleParameter("p_synx",OracleType.VarChar),
                                                      new OracleParameter("p_jlgd",OracleType.VarChar),
                                                      new OracleParameter("p_jlgddx",OracleType.VarChar),
                                                      new OracleParameter("p_jlgdsl",OracleType.VarChar),
                                                      new OracleParameter("p_zlgd",OracleType.VarChar),
                                                      new OracleParameter("p_zlgddx",OracleType.VarChar),
                                                      new OracleParameter("p_zlgdsl",OracleType.VarChar),
                                                      new OracleParameter("p_sbcsqk",OracleType.VarChar),
                                                      new OracleParameter("p_sbflpz",OracleType.VarChar),
                                                      new OracleParameter("p_xssjc",OracleType.VarChar),
                                                      new OracleParameter("p_dbsj",OracleType.VarChar),
                                                      new OracleParameter("p_sbbgr",OracleType.VarChar),
                                                      //地面设备
                                                      new OracleParameter("p_dmsbtxlx",OracleType.VarChar),
                                                      //航向设备
                                                      new OracleParameter("p_hxsblb",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbtxzxh",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbtxzlx",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbtxzzs",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbjpdmdjl",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbjpdrkjl",OracleType.VarChar),
                                                      new OracleParameter("p_hxsbzxczjl",OracleType.VarChar),
                                                      //下滑设备
                                                      new OracleParameter("p_xhsbsjxhj",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbsjrkgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtxzlx",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtcxtxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbmqxtxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtcstxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbmqstxgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtxtgd",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbjpdrkncjl",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbjpdzxcj",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbwypdzxx",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbtxzxh",OracleType.VarChar),
                                                      new OracleParameter("p_xhsbmjjzgrdh",OracleType.VarChar),
                                                      //测距仪
                                                      new OracleParameter("p_cjycpc",OracleType.VarChar),
                                                      new OracleParameter("p_cjypdh",OracleType.VarChar),
                                                      new OracleParameter("p_cjydj",OracleType.VarChar),
                                                      new OracleParameter("p_cjybdh",OracleType.VarChar),
                                                      new OracleParameter("p_cjyptsb",OracleType.VarChar),
                                                      new OracleParameter("p_cjyjspl",OracleType.VarChar),
                                                      new OracleParameter("p_cjyxtyc",OracleType.VarChar),
                                                      new OracleParameter("p_cjymcjg",OracleType.VarChar),
                                                      //全向信标
                                                      new OracleParameter("p_qxxbcpc",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdwgd",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbjkqfw",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdwzj",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdwlx",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_qxxbdj",OracleType.VarChar),
                                                      //无方向信标
                                                      new OracleParameter("p_wfxxbcpc",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdwgd",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbjkqfw",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdwzj",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdwlx",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_wfxxbdj",OracleType.VarChar),
                                                      //指点信标
                                                      new OracleParameter("p_zdxbpdh",OracleType.VarChar),
                                                      new OracleParameter("p_zdxbdj",OracleType.VarChar),
                                                      new OracleParameter("p_zdxblxxz",OracleType.VarChar),

                                                      new OracleParameter("p_xtsj",OracleType.DateTime),

                                                      new OracleParameter("p_wxdlj",OracleType.VarChar),
                                                      new OracleParameter("p_mcjflj",OracleType.VarChar),
                                                      new OracleParameter("p_plhhlj",OracleType.VarChar),
                                                      new OracleParameter("p_sbxkzlj",OracleType.VarChar),
                                                      new OracleParameter("p_tzpflj",OracleType.VarChar),
                                                      new OracleParameter("p_bhqlj",OracleType.VarChar),
                                                      new OracleParameter("p_scip",OracleType.VarChar),

                                                      new OracleParameter("p_wxdsbfshzzj",OracleType.VarChar),
                                                      new OracleParameter("p_mcjfbg",OracleType.VarChar),
                                                      new OracleParameter("p_plhhwj",OracleType.VarChar),
                                                      new OracleParameter("p_sbxkz",OracleType.VarChar),
                                                      new OracleParameter("p_tzpfwj",OracleType.VarChar),
                                                      new OracleParameter("p_bhqfw",OracleType.VarChar),
                                                      new OracleParameter("p_scwjsjc",OracleType.VarChar),

                                                      new OracleParameter("p_csr",OracleType.VarChar),
                                                      new OracleParameter("p_zsr",OracleType.VarChar),
                                                      new OracleParameter("p_lrr",OracleType.VarChar),
                                                      new OracleParameter("p_sjc",OracleType.VarChar),
                                                      new OracleParameter("p_sjbs",OracleType.VarChar),
                                                      new OracleParameter("p_zt",OracleType.VarChar),
                                                      new OracleParameter("p_bmdm",OracleType.VarChar),

                                                      new OracleParameter("p_id",OracleType.VarChar),

                                                      new OracleParameter("p_errorCode",OracleType.Int32)
                                           };


                parament[0].Value = struct_DHSB.p_sbbh;
                parament[1].Value = struct_DHSB.p_sbxh;
                parament[2].Value = struct_DHSB.p_sblx;
                parament[3].Value = struct_DHSB.p_tzmczl_tzmc;
                parament[4].Value = struct_DHSB.p_tzmczl_wz;
                parament[5].Value = struct_DHSB.p_tzmczl_sblx;
                parament[6].Value = struct_DHSB.p_yssjc;
                parament[7].Value = struct_DHSB.p_pl;
                parament[8].Value = struct_DHSB.p_pldw;
                parament[9].Value = struct_DHSB.p_hh;
                parament[10].Value = struct_DHSB.p_txzxdmgc;
                parament[11].Value = struct_DHSB.p_tx;
                parament[12].Value = struct_DHSB.p_jfzq;
                parament[13].Value = struct_DHSB.p_jfdqrq;
                parament[14].Value = struct_DHSB.p_tckfsj;
                parament[15].Value = struct_DHSB.p_tcjfsj;
                parament[16].Value = struct_DHSB.p_tcsfxy;
                parament[17].Value = struct_DHSB.p_tcsm;
                parament[18].Value = struct_DHSB.p_mcfxjyrq;
                parament[19].Value = struct_DHSB.p_mcfxjyjg;
                parament[20].Value = struct_DHSB.p_mcfxjysm;
                parament[21].Value = struct_DHSB.p_ddzbbjjd;
                parament[22].Value = struct_DHSB.p_ddzbbjwd;
                parament[23].Value = struct_DHSB.p_ddzbwgsjd;
                parament[24].Value = struct_DHSB.p_ddzbwgswd;
                parament[25].Value = struct_DHSB.p_sl;
                parament[26].Value = struct_DHSB.p_sbcj;
                parament[27].Value = struct_DHSB.p_scgl;
                parament[28].Value = struct_DHSB.p_scgldw;
                parament[29].Value = struct_DHSB.p_sbccbh;
                parament[30].Value = struct_DHSB.p_fgfw;
                parament[31].Value = struct_DHSB.p_fgfwdw;
                parament[32].Value = struct_DHSB.p_sbzt;
                parament[33].Value = struct_DHSB.p_jpdzxjl;
                parament[34].Value = struct_DHSB.p_pdcd;
                parament[35].Value = struct_DHSB.p_synx;
                parament[36].Value = struct_DHSB.p_jlgd;
                parament[37].Value = struct_DHSB.p_jlgddx;
                parament[38].Value = struct_DHSB.p_jlgdsl;
                parament[39].Value = struct_DHSB.p_zlgd;
                parament[40].Value = struct_DHSB.p_zlgddx;
                parament[41].Value = struct_DHSB.p_zlgdsl;
                parament[42].Value = struct_DHSB.p_sbcsqk;
                parament[43].Value = struct_DHSB.p_sbflpz;
                parament[44].Value = struct_DHSB.p_xssjc;
                parament[45].Value = struct_DHSB.p_dbsj;
                parament[46].Value = struct_DHSB.p_sbbgr;
                //地面设备
                parament[47].Value = struct_DHSB.p_dmsbtxlx;
                //航向设备
                parament[48].Value = struct_DHSB.p_hxsblb;
                parament[49].Value = struct_DHSB.p_hxsbpdh;
                parament[50].Value = struct_DHSB.p_hxsbtxzxh;
                parament[51].Value = struct_DHSB.p_hxsbtxzlx;
                parament[52].Value = struct_DHSB.p_hxsbtxzzs;
                parament[53].Value = struct_DHSB.p_hxsbjpdmdjl;
                parament[54].Value = struct_DHSB.p_hxsbjpdrkjl;
                parament[55].Value = struct_DHSB.p_hxsbzxczjl;
                //下滑设备
                parament[56].Value = struct_DHSB.p_xhsbsjxhj;
                parament[57].Value = struct_DHSB.p_xhsbsjrkgd;
                parament[58].Value = struct_DHSB.p_xhsbtxzlx;
                parament[59].Value = struct_DHSB.p_xhsbtcxtxgd;
                parament[60].Value = struct_DHSB.p_xhsbmqxtxgd;
                parament[61].Value = struct_DHSB.p_xhsbtcstxgd;
                parament[62].Value = struct_DHSB.p_xhsbmqstxgd;
                parament[63].Value = struct_DHSB.p_xhsbtxtgd;
                parament[64].Value = struct_DHSB.p_xhsbjpdrkncjl;
                parament[65].Value = struct_DHSB.p_xhsbjpdzxcj;
                parament[66].Value = struct_DHSB.p_xhsbwypdzxx;
                parament[67].Value = struct_DHSB.p_xhsbtxzxh;
                parament[68].Value = struct_DHSB.p_xhsbmjjzgrdh;
                //测距仪
                parament[69].Value = struct_DHSB.p_cjycpc;
                parament[70].Value = struct_DHSB.p_cjypdh;
                parament[71].Value = struct_DHSB.p_cjydj;
                parament[72].Value = struct_DHSB.p_cjybdh;
                parament[73].Value = struct_DHSB.p_cjyptsb;
                parament[74].Value = struct_DHSB.p_cjyjspl;
                parament[75].Value = struct_DHSB.p_cjyxtyc;
                parament[76].Value = struct_DHSB.p_cjymcjg;
                //全向信标
                parament[77].Value = struct_DHSB.p_qxxbcpc;
                parament[78].Value = struct_DHSB.p_qxxbdwgd;
                parament[79].Value = struct_DHSB.p_qxxbjkqfw;
                parament[80].Value = struct_DHSB.p_qxxbdwzj;
                parament[81].Value = struct_DHSB.p_qxxbdwlx;
                parament[82].Value = struct_DHSB.p_qxxbpdh;
                parament[83].Value = struct_DHSB.p_qxxbdj;
                //无方向信标
                parament[84].Value = struct_DHSB.p_wfxxbcpc;
                parament[85].Value = struct_DHSB.p_wfxxbdwgd;
                parament[86].Value = struct_DHSB.p_wfxxbjkqfw;
                parament[87].Value = struct_DHSB.p_wfxxbdwzj;
                parament[88].Value = struct_DHSB.p_wfxxbdwlx;
                parament[89].Value = struct_DHSB.p_wfxxbpdh;
                parament[90].Value = struct_DHSB.p_wfxxbdj;
                //指点信标
                parament[91].Value = struct_DHSB.p_zdxbpdh;
                parament[92].Value = struct_DHSB.p_zdxbdj;
                parament[93].Value = struct_DHSB.p_zdxblxxz;

                parament[94].Value = struct_DHSB.p_xtsj;

                parament[95].Value = struct_DHSB.p_wxdlj;
                parament[96].Value = struct_DHSB.p_mcjflj;
                parament[97].Value = struct_DHSB.p_plhhlj;
                parament[98].Value = struct_DHSB.p_sbxkzlj;
                parament[99].Value = struct_DHSB.p_tzpflj;
                parament[100].Value = struct_DHSB.p_bhqlj;
                parament[101].Value = struct_DHSB.p_scip;


                parament[102].Value = struct_DHSB.p_wxdsbfshzzj;
                parament[103].Value = struct_DHSB.p_mcjfbg;
                parament[104].Value = struct_DHSB.p_plhhwj;
                parament[105].Value = struct_DHSB.p_sbxkz;
                parament[106].Value = struct_DHSB.p_tzpfwj;
                parament[107].Value = struct_DHSB.p_bhqfw;
                parament[108].Value = struct_DHSB.p_scwjsjc;

                parament[109].Value = struct_DHSB.p_csr;
                parament[110].Value = struct_DHSB.p_zsr;
                parament[111].Value = struct_DHSB.p_lrr;
                parament[112].Value = struct_DHSB.p_sjc;
                parament[113].Value = struct_DHSB.p_sjbs;
                parament[114].Value = struct_DHSB.p_zt;
                parament[115].Value = struct_DHSB.p_bmdm;

                parament[116].Value = struct_DHSB.p_id;

                parament[117].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DHSB.Update_DHSB", parament, out reslut);

                int returnCode = 0;// Convert.ToInt32(parament[95].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_DHSB.p_czfs;
                struct_RZ_YH.czxx = struct_DHSB.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected void Delete_DHSB(string p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DHSB.Delete_DHSB", parament, out reslut);

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

        #region 更新状态
        protected void Update_DHSBZT(Struct_DHSB struct_DHSB)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_DHSB.p_id;
                paras[1].Value = struct_DHSB.p_zt;
                paras[2].Value = struct_DHSB.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_DHSB.Update_DHSBZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
            }
            finally
            {
                db.Close();
            }
        }

        //变更数据标识
        protected void Update_DHSB_SJBS_ZT(Struct_DHSB struct_DHSB)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_DHSB.p_sjc;
                paras[1].Value = struct_DHSB.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_DHSB.Update_DHSB_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_DHSB.p_czfs;
                struct_rz.czxx = struct_DHSB.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_DHSB_SJBS_LSSJ_ZT(Struct_DHSB struct_DHSB)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_DHSB.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_DHSB.Update_DHSB_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_DHSB.p_czfs;
                struct_rz.czxx = struct_DHSB.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #region 将副本数据变为最终数据
        protected void Update_DHSB_SJBS_FBSJ_ZT(Struct_DHSB struct_DHSB)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_DHSB.p_sjc;
                paras[1].Value = struct_DHSB.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_DHSB.Update_DHSB_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_DHSB.p_czfs;
                struct_rz.czxx = struct_DHSB.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #endregion
        protected int DHSB_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_DHSB_Detail(id); ;
            //备份数据
            Struct_DHSB dhsb_bf = new Struct_DHSB();

            dhsb_bf. p_sbbh= dt_detail.Rows[0]["SBBH"].ToString();//设备编号
            dhsb_bf. p_sbxh= dt_detail.Rows[0]["SBXH"].ToString();//设备型号
            dhsb_bf. p_sblx=dt_detail.Rows[0]["SBLX"].ToString();//设备类型
            dhsb_bf. p_tzmczl_tzmc = dt_detail.Rows[0]["TZMCZL_TZMC"].ToString();//台站名称种类_台站名称
            dhsb_bf. p_tzmczl_wz= dt_detail.Rows[0]["TZMCZL_WZ"].ToString();//台站名称种类_位置
            dhsb_bf. p_tzmczl_sblx = dt_detail.Rows[0]["TZMCZL_SBLX"].ToString();//台站名称种类_设备类型
            dhsb_bf. p_yssjc = dt_detail.Rows[0]["YSSJC"].ToString();//原所属机场
            dhsb_bf.p_pl = dt_detail.Rows[0]["PL"].ToString();//频率
            dhsb_bf. p_pldw = dt_detail.Rows[0]["PLDW"].ToString();//频率单位
            dhsb_bf. p_hh = dt_detail.Rows[0]["HH"].ToString();//呼号
            dhsb_bf. p_txzxdmgc = dt_detail.Rows[0]["TXZXDMGC"].ToString();//天线中心地面高程
            dhsb_bf. p_tx = dt_detail.Rows[0]["TX"].ToString();//天线
            dhsb_bf. p_jfzq = dt_detail.Rows[0]["JFZQ"].ToString();//校飞周期
            dhsb_bf. p_jfdqrq = dt_detail.Rows[0]["JFDQRQ"].ToString();//校飞到期日期
            dhsb_bf. p_tckfsj = dt_detail.Rows[0]["TCKFSJ"].ToString();//投产开放时间
            dhsb_bf. p_tcjfsj = dt_detail.Rows[0]["TCJFSJ"].ToString();//投产校飞时间
            dhsb_bf. p_tcsfxy = dt_detail.Rows[0]["TCSFXY"].ToString();//投产是否限用
            dhsb_bf.p_tcsm = dt_detail.Rows[0]["TCSM"].ToString();//投产说明
            dhsb_bf.p_mcfxjyrq = dt_detail.Rows[0]["MCFXJYRQ"].ToString();//末次飞行校验日期
            dhsb_bf. p_mcfxjyjg = dt_detail.Rows[0]["MCFXJYJG"].ToString();//末次飞行校验结果
            dhsb_bf. p_mcfxjysm = dt_detail.Rows[0]["MCFXJYSM"].ToString();//末次飞行校验说明
            dhsb_bf. p_ddzbbjjd= dt_detail.Rows[0]["DDZB_BJ_JD"].ToString();//大地坐标（北京54）经度
            dhsb_bf. p_ddzbbjwd = dt_detail.Rows[0]["DDZB_BJ_WD"].ToString();//大地坐标（北京54）纬度
            dhsb_bf. p_ddzbwgsjd = dt_detail.Rows[0]["DDZB_WGS_JD"].ToString();//大地坐标（wgs84）经度
            dhsb_bf.p_ddzbwgswd = dt_detail.Rows[0]["DDZB_WGS_WD"].ToString();//大地坐标（wgs84）纬度
            dhsb_bf. p_sl = dt_detail.Rows[0]["SL"].ToString();//数量
            dhsb_bf. p_sbcj = dt_detail.Rows[0]["SBCJ"].ToString();//设备厂家
            dhsb_bf. p_scgl = dt_detail.Rows[0]["SCGL"].ToString();//输出功率
            dhsb_bf. p_scgldw = dt_detail.Rows[0]["SCGLDW"].ToString();//输出功率单位
            dhsb_bf.p_sbccbh = dt_detail.Rows[0]["SBCCBH"].ToString();//设备出厂编号
            dhsb_bf. p_fgfw = dt_detail.Rows[0]["FGFW"].ToString();//覆盖范围
            dhsb_bf. p_fgfwdw = dt_detail.Rows[0]["FGFWDW"].ToString();//覆盖范围单位
            dhsb_bf.p_sbzt = dt_detail.Rows[0]["SBZT"].ToString();//设备状态
            dhsb_bf. p_jpdzxjl = dt_detail.Rows[0]["JPDZXJL"].ToString();//距跑道中心距离
            dhsb_bf.p_pdcd = dt_detail.Rows[0]["PDCD"].ToString();//跑道长度
            dhsb_bf. p_synx = dt_detail.Rows[0]["SYNX"].ToString(); ;//使用年限
            dhsb_bf.p_jlgd = dt_detail.Rows[0]["JLGD"].ToString();//交流供电
            dhsb_bf.p_jlgddx = dt_detail.Rows[0]["JLGDDX"].ToString();//交流供电大小
            dhsb_bf.p_jlgdsl = dt_detail.Rows[0]["JLGDSL"].ToString();//交流供电数量
            dhsb_bf.p_zlgd = dt_detail.Rows[0]["ZLGD"].ToString();//直流供电
            dhsb_bf.p_zlgddx = dt_detail.Rows[0]["ZLGDDX"].ToString();//直流供电大小
            dhsb_bf.p_zlgdsl = dt_detail.Rows[0]["ZLGDSL"].ToString();//直流供电数量
            dhsb_bf.p_sbcsqk = dt_detail.Rows[0]["SBCSQK"].ToString();//设备传输情况
            dhsb_bf.p_sbflpz = dt_detail.Rows[0]["SBFLPZ"].ToString();//设备防雷配置
            dhsb_bf.p_xssjc = dt_detail.Rows[0]["XSSJC"].ToString();//现所属机场
            dhsb_bf.p_dbsj = dt_detail.Rows[0]["DBSJ"].ToString();//调拨时间
            dhsb_bf.p_sbbgr = dt_detail.Rows[0]["SBBGR"].ToString();//设备保管人

            //地面设备
            dhsb_bf.p_dmsbtxlx = dt_detail.Rows[0]["WXDHDMSB_TXLX"].ToString();//地卖弄设备 天线类型
                                                                      //航向设备
            dhsb_bf.p_hxsblb = dt_detail.Rows[0]["HXSB_LB"].ToString();//航向设备 类别
            dhsb_bf.p_hxsbpdh = dt_detail.Rows[0]["HXSB_PDH"].ToString();//航向设备 跑道号
            dhsb_bf.p_hxsbtxzxh = dt_detail.Rows[0]["HXSB_TXZXH"].ToString();//航向设备 天线阵型号
            dhsb_bf.p_hxsbtxzlx = dt_detail.Rows[0]["HXSB_TXZLX"].ToString();//航向设备 天线阵类型
            dhsb_bf. p_hxsbtxzzs = dt_detail.Rows[0]["HXSB_TXZZS"].ToString();// 航向设备 天线阵子数
            dhsb_bf.p_hxsbjpdmdjl = dt_detail.Rows[0]["HXSB_TXZJPDMDJL"].ToString();//航向设备 天线阵距跑道末端距离
            dhsb_bf.p_hxsbjpdrkjl = dt_detail.Rows[0]["HXSB_TXZJPDRKDJL"].ToString();//航向设备 天线阵距跑道入口距离
            dhsb_bf.p_hxsbzxczjl = dt_detail.Rows[0]["HXSB_TXZJPDZXCZJL"].ToString();//航向设备 天线阵距跑道中心垂直距离
             //下滑设备
            dhsb_bf.p_xhsbsjxhj = dt_detail.Rows[0]["XHSB_SJXHJ"].ToString();//下滑设备 设计下滑角
            dhsb_bf.p_xhsbsjrkgd = dt_detail.Rows[0]["XHSB_SJRKGD"].ToString();//下滑设备 设计入口高度
            dhsb_bf.p_xhsbtxzlx = dt_detail.Rows[0]["XHSB_TXZLX"].ToString();//下滑设备 天线阵类型
            dhsb_bf.p_xhsbtcxtxgd = dt_detail.Rows[0]["XHSB_TCXTXGD"].ToString();//下滑设备 投产下天线高度
            dhsb_bf.p_xhsbmqxtxgd = dt_detail.Rows[0]["XHSB_MQXTXGD"].ToString();//下滑设备 目前下天线高度
            dhsb_bf.p_xhsbtcstxgd = dt_detail.Rows[0]["XHSB_TCSTXGD"].ToString();//下滑设备 投产上天线高度
            dhsb_bf.p_xhsbmqstxgd = dt_detail.Rows[0]["XHSB_MQSTXGD"].ToString();//下滑设备 目前上天线高度
            dhsb_bf.p_xhsbtxtgd = dt_detail.Rows[0]["XHSB_TXTGD"].ToString();//下滑设备 天线塔高度 
            dhsb_bf.p_xhsbjpdrkncjl = dt_detail.Rows[0]["XHSB_JPDRKNCJL"].ToString();//下滑设备 距跑道入口内侧距离
            dhsb_bf. p_xhsbjpdzxcj = dt_detail.Rows[0]["XHSB_JPDZXCJ"].ToString();//下滑设备 距跑道中心线垂距
            dhsb_bf.p_xhsbwypdzxx = dt_detail.Rows[0]["XHSB_WYPDZXX"].ToString();//下滑设备 位于跑道中心线
            dhsb_bf.p_xhsbtxzxh = dt_detail.Rows[0]["XHSB_TXZXH"].ToString();//下滑设备 天线阵型号
            dhsb_bf.p_xhsbmjjzgrdh = dt_detail.Rows[0]["XHSB_MJJZGRDH"].ToString();//下滑设备 盲降基准高RDH
            //测距仪
            dhsb_bf.p_cjycpc = dt_detail.Rows[0]["CJY_CPC"].ToString();//测距仪 磁盘差
            dhsb_bf.p_cjypdh = dt_detail.Rows[0]["CJY_PDH"].ToString();//测距仪 跑道号
            dhsb_bf.p_cjydj = dt_detail.Rows[0]["CJY_DJ"].ToString();//测距仪 端距
            dhsb_bf.p_cjybdh = dt_detail.Rows[0]["CJY_BDH"].ToString();//测距仪 波道号
            dhsb_bf.p_cjyptsb = dt_detail.Rows[0]["CJY_PTSB"].ToString();//测距仪 配套设备
            dhsb_bf.p_cjyjspl = dt_detail.Rows[0]["CJY_JSPL"].ToString();//测距仪 接收频率
            dhsb_bf.p_cjyxtyc = dt_detail.Rows[0]["CJY_XTYC"].ToString();//测距仪 系统延迟
            dhsb_bf.p_cjymcjg = dt_detail.Rows[0]["CJY_MCJG"].ToString();//测距仪 脉冲间隔
           //全向信标
            dhsb_bf.p_qxxbcpc = dt_detail.Rows[0]["QXXB_CPC"].ToString();//全向信标 磁偏差
            dhsb_bf.p_qxxbdwgd = dt_detail.Rows[0]["QXXB_DWGD"].ToString();//全向信标 地网高度
            dhsb_bf.p_qxxbjkqfw = dt_detail.Rows[0]["QXXB_JKQFW"].ToString();//全向信标 监控器方位
            dhsb_bf. p_qxxbdwzj= dt_detail.Rows[0]["QXXB_DWZJ"].ToString();// 全向信标 地网直径
            dhsb_bf.p_qxxbdwlx = dt_detail.Rows[0]["QXXB_DWLX"].ToString();//全向信标 地网类型
            dhsb_bf.p_qxxbpdh = dt_detail.Rows[0]["QXXB_PDH"].ToString();//全向信标 跑道号
            dhsb_bf.p_qxxbdj = dt_detail.Rows[0]["QXXB_DJ"].ToString();//全向信标 端距
            //无方向信标
            dhsb_bf.p_wfxxbcpc = dt_detail.Rows[0]["WFXXB_CPC"].ToString();//无方向信标 磁偏差
            dhsb_bf.p_wfxxbdwgd = dt_detail.Rows[0]["WFXXB_DWGD"].ToString();//无方向信标 地网高度
            dhsb_bf.p_wfxxbjkqfw = dt_detail.Rows[0]["WFXXB_JKQFW"].ToString();//无方向信标 监控器方位
            dhsb_bf.p_wfxxbdwzj = dt_detail.Rows[0]["WFXXB_DWZJ"].ToString();//无方向信标 地网直径
            dhsb_bf.p_wfxxbdwlx = dt_detail.Rows[0]["WFXXB_DWLX"].ToString();//无方向信标 地网类型
            dhsb_bf.p_wfxxbpdh = dt_detail.Rows[0]["WFXXB_PDH"].ToString();//无方向信标 跑道号
            dhsb_bf.p_wfxxbdj = dt_detail.Rows[0]["WFXXB_DJ"].ToString();//无方向信标 端距
            //指点信标
            dhsb_bf.p_zdxbpdh = dt_detail.Rows[0]["ZDXB_PDH"].ToString();//指点信标 跑道号
            dhsb_bf.p_zdxbdj = dt_detail.Rows[0]["ZDXB_DJ"].ToString();//指点信标 端距
            dhsb_bf.p_zdxblxxz = dt_detail.Rows[0]["ZDXB_LXXZ"].ToString();//指点信标 类型选择


            dhsb_bf.p_xtsj = Convert.ToDateTime(dt_detail.Rows[0]["XTSJ"].ToString());

            dhsb_bf. p_wxdlj = dt_detail.Rows[0]["WXDLJ"].ToString();///无线电设备发射核准证件路径
            dhsb_bf. p_mcjflj = dt_detail.Rows[0]["MCJFLJ"].ToString();///末次校飞报告路径
            dhsb_bf. p_plhhlj = dt_detail.Rows[0]["PLHHLJ"].ToString();///频率呼号文件路径
            dhsb_bf. p_sbxkzlj = dt_detail.Rows[0]["SBXKZLJ"].ToString();///设备许可证路径
            dhsb_bf. p_tzpflj = dt_detail.Rows[0]["TZPFLJ"].ToString();///台址批复文件路径
            dhsb_bf. p_bhqlj = dt_detail.Rows[0]["BHQLJ"].ToString();///保护区范围路径
            dhsb_bf. p_scip = dt_detail.Rows[0]["SCIP"].ToString();///上传IP
            dhsb_bf. p_wjscsj = dt_detail.Rows[0]["SCWJSJC"].ToString();///文件上传时间
            dhsb_bf. p_wxdsbfshzzj = dt_detail.Rows[0]["wxdsbfshzzj"].ToString();///无线电设备法神核准证件
            dhsb_bf. p_mcjfbg = dt_detail.Rows[0]["mcjfbg"].ToString();///末次校飞报告
            dhsb_bf. p_plhhwj = dt_detail.Rows[0]["plhhwj"].ToString();///频率呼号文件
            dhsb_bf. p_sbxkz = dt_detail.Rows[0]["sbxkz"].ToString();///设备许可证
            dhsb_bf. p_tzpfwj = dt_detail.Rows[0]["tzpfwj"].ToString();///台址批复文件
            dhsb_bf. p_bhqfw = dt_detail.Rows[0]["bhqfw"].ToString();///保护区范围
            dhsb_bf. p_scwjsjc = dt_detail.Rows[0]["scwjsjc"].ToString();///上传文件时间戳


            dhsb_bf.p_zt = "0";
            dhsb_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            dhsb_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            dhsb_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            dhsb_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            dhsb_bf.p_lrr = _us.userLoginName;
            dhsb_bf.p_sjbs = "2";
            dhsb_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            dhsb_bf.p_shsj = "";
            dhsb_bf.p_czfs = "02";
            dhsb_bf.p_czxx = "导航设备id:" + id + "生成副本数据";
            //插入
            Insert_DHSB(dhsb_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = dhsb_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DHSB.Select_DHSB_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion
        protected DataTable Select_DHSB_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_KG_DHSB.Select_DHSB_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
    }

}


