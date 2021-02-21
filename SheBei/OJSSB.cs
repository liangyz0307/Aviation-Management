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
    public struct Struct_JSSB
        {
            public string p_sbbh;//设备编号
            public string p_sszx;//所属支线
            public string p_sstz;//所属台站
            public string p_dtzzdqsj;//电台执照到期时间
            public string p_sblx;//设备类型
            public string p_sbxh;//设备型号
            public string p_tzmczl;//台站名称种类
            public string p_ssjc;//所属机场
            public string p_jgrq;//竣工日期
            public string p_tcjyrq;//投产校验日期
            public string p_tckfhbarq;//投产开放或备案日期
            public string p_sbccbh;//设备出厂编号
            public string p_zyjscstx;//主要技术参数填写
            public string p_sbzt;//设备状态
            public string p_gdfs;//供电方式
            public string p_csfs;//传输方式
            public string p_sbsccj;//设备生产厂家
            public string p_sc;//上传
            public string p_ddzb_bj54_jd;//大地坐标(北京54)经度
            public string p_ddzb_bj54_wd;//大地坐标(北京54)纬度
            public string p_ddzb_wgs84_jd;//大地坐标(北京54)经度
            public string p_ddzb_wgs84_wd;//大地坐标(北京54)纬度


            //一级雷达设备
            public string p_ld_gzpl1;//雷达——工作频率1
            public string p_ld_csxbxh1;//雷达——测试信标型号2
            public string p_ld_fzgl1;//雷达——峰值功率3
            public string p_ld_txszdd1;//雷达——天线设置地点4
            public string p_ld_txjcgc1;//雷达——天线基础高程
            public string p_ld_txgd1;//雷达——天线高度
            public string p_ld_txsccj1;//雷达——天线生产厂家
            public string p_ld_txxh_lx1;//雷达——天线型号_类型
            public string p_ld_fgqk1;//雷达——覆盖情况5
            public string p_wxdtzzyxq1;//雷达——无线电台执照有效期6
            public string p_ld_sc;//雷达——上传7
            public string p_ld_sc1;//雷达——上传7

            //一级雷达设备
            public string p_ld_gzpl2;//雷达——工作频率1
            public string p_ld_csxbxh2;//雷达——测试信标型号2
            public string p_ld_fzgl2;//雷达——峰值功率3
            public string p_ld_txszdd2;//雷达——天线设置地点4
            public string p_ld_txjcgc2;//雷达——天线基础高程
            public string p_ld_txgd2;//雷达——天线高度
            public string p_ld_txsccj2;//雷达——天线生产厂家
            public string p_ld_txxh_lx2;//雷达——天线型号_类型
            public string p_ld_fgqk2;//雷达——覆盖情况5
            public string p_wxdtzzyxq2;//雷达——无线电台执照有效期6
            public string p_ld_sc2;//雷达——上传7

        //自动相关监视系统设备(ADSB)
        public string p_zdxgjsxtsb_gzpl;//自动相关监视系统设备_工作频率
            public string p_zdxgjsxtsb_sfpcsxb;//自动相关监视系统设备_是否配测试信标
            public string p_zdxgjsxtsb_csxbxh;//自动相关监视系统设备_测试信标型号
            public string p_zdxgjsxtsb_csxbsmsdzdm;//自动相关监视系统设备_测试信标S模式地址代码
            public string p_zdxgjsxtsb_cyzzrs;//自动相关监视系统设备_持有执照人数
            public string p_zdxgjsxtsb_fzgl;//自动相关监视系统设备_峰值功率
            public string p_zdxgjsxtsb_csfs;//自动相关监视系统设备_传输方式
            public string p_zdxgjsxtsb_txszdd;//自动相关监视系统设备_天线设置地点
            public string p_zdxgjsxtsb_txjcgc;//自动相关监视系统设备_天线基础高程
            public string p_zdxgjsxtsb_txsccj;//自动相关监视系统设备_天线生产厂家
            public string p_zdxgjsxtsb_txxh_lx;//自动相关监视系统设备_天线型号_类型
            public string p_zdxgjsxtsb_wxdtzzyxq;//自动相关监视系统设备_无线电台执照有效期
            public string p_zdxgjsxtsb_sc;//自动相关监视系统设备_上传


            //多点定位系统
            public string p_dddwxt_gzpl;//多点定位系统_工作频率
            public string p_dddwxt_fstfzgl;//多点定位系统_发射台峰值功率
            public string p_dddwxt_txszdd;//多点定位系统_天线设置地点
            public string p_dddwxt_txjcgc;//多点定位系统_天线基础高程
            public string p_dddwxt_txsccj;//多点定位系统_天线生产厂家
            public string p_dddwxt_txxh_lx;//多点定位系统_天线型号_类型
            public string p_dddwxt_wxdtzzyxq;//多点定位系统_无线电台执照有效期
            public string p_dddwxt_sc;//多点定位系统_上传

            //自动化系统
            public string p_zdhxt_jsyyjxl;//自动化系统_监视源引接线路
            public string p_zdhxt_xtrjbb;//自动化系统_系统软件版本
            public string p_zdhxt_xtgm;//自动化系统_系统规模
            public string p_zdhxt_ATCgzsqs;//自动化系统_ATC管制扇区数
            public string p_zdhxt_A_SMGCSxtfj;//自动化系统_A—SMGCS系统分级
            public string p_zdhxt_cyzzrs;//自动化系统_持有执照人数

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
            public int p_id;
            public string p_zt;//状态
            public string p_wz;//位置
        }
    public class OJSSB {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private RZ rz;
        private UserState _us = null;
        //private UserState _usState;
        public OJSSB(UserState userstate) {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 监视设备查询
        protected DataTable Select_JSSB_Pro(Struct_JSSB struct_jssb) {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_ssjc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_sbzt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor),
                };
                parament[0].Value = struct_jssb.p_ssjc;
                parament[1].Value = struct_jssb.p_wz;
                parament[2].Value = struct_jssb.p_sblx;
                parament[3].Value = struct_jssb.p_sbzt;
                parament[4].Value = struct_jssb.p_userid;
                parament[5].Value = struct_jssb.p_pagesize;
                parament[6].Value = struct_jssb.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_JSSB.Select_JSSB_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally {
                dbclass.Close();
            }
        }
        #endregion
        #region 查询监视设备数量
        protected int Select_JSSB_Count(Struct_JSSB struct_jssb) {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                    new OracleParameter("p_ssjc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_sbzt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor),
                };
                parament[0].Value = struct_jssb.p_ssjc;
                parament[1].Value = struct_jssb.p_wz;
                parament[2].Value = struct_jssb.p_sblx;
                parament[3].Value = struct_jssb.p_sbzt;
                parament[4].Value = struct_jssb.p_userid;
                parament[5].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_JSSB.Select_JSSB_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally {
                dbclass.Close();
            }
        }
        #endregion
        #region 查询监视设备详细信息
        protected DataTable Select_JSSB_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_JSSB.Select_JSSB_Detail_BySbID", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 修改状态
        protected void Update_JSSBZT(Struct_JSSB struct_jssb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sbbh",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_jssb.p_sbbh;
                paras[1].Value = struct_jssb.p_zt;
                paras[2].Value = struct_jssb.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_JSSB.Update_JSSBZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jssb.p_czfs;
                struct_rz.czxx = struct_jssb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 修改监视设备
        protected void Update_JSSB(Struct_JSSB struct_jssb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    //  24
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_sbbh",OracleType.VarChar),
                    new OracleParameter("p_sszx",OracleType.VarChar),
                    new OracleParameter("p_sstz",OracleType.VarChar),
                    new OracleParameter("p_dtzzdqsj",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_sbxh",OracleType.VarChar),
                    //new OracleParameter("p_tzmczl",OracleType.VarChar),
                    new OracleParameter("p_ssjc",OracleType.VarChar),
                    new OracleParameter("p_jgrq",OracleType.VarChar),
                    new OracleParameter("p_tcjyrq",OracleType.VarChar),
                    new OracleParameter("p_tckfhbarq",OracleType.VarChar),
                    new OracleParameter("p_sbccbh",OracleType.VarChar),
                    new OracleParameter("p_zyjscstx",OracleType.VarChar),
                    new OracleParameter("p_sbzt",OracleType.VarChar),
                    new OracleParameter("p_gdfs",OracleType.VarChar),
                    new OracleParameter("p_csfs",OracleType.VarChar),
                    new OracleParameter("p_sbsccj",OracleType.VarChar),
                    new OracleParameter("p_sc",OracleType.VarChar),
                    new OracleParameter("p_ddzb_bj54_jd",OracleType.VarChar),
                    new OracleParameter("p_ddzb_bj54_wd",OracleType.VarChar),
                    new OracleParameter("p_ddzb_wgs84_jd",OracleType.VarChar),
                    new OracleParameter("p_ddzb_wgs84_wd",OracleType.VarChar),

                    ////一级雷达设备  11
                    new OracleParameter("p_ld_gzpl1",OracleType.VarChar),
                    new OracleParameter("p_ld_csxbxh1",OracleType.VarChar),
                    new OracleParameter("p_ld_fzgl1",OracleType.VarChar),
                    new OracleParameter("p_ld_txszdd1",OracleType.VarChar),
                    new OracleParameter("p_ld_txjcgc1",OracleType.VarChar),
                    new OracleParameter("p_ld_txgd1",OracleType.VarChar),
                    new OracleParameter("p_ld_txsccj1",OracleType.VarChar),
                    new OracleParameter("p_ld_txxh_lx1",OracleType.VarChar),
                    new OracleParameter("p_ld_fgqk1",OracleType.VarChar),
                    new OracleParameter("p_wxdtzzyxq1",OracleType.VarChar),
                    new OracleParameter("p_ld_sc1",OracleType.VarChar),

                    ////二级雷达设备  11
                    new OracleParameter("p_ld_gzpl2",OracleType.VarChar),
                    new OracleParameter("p_ld_csxbxh2",OracleType.VarChar),
                    new OracleParameter("p_ld_fzgl2",OracleType.VarChar),
                    new OracleParameter("p_ld_txszdd2",OracleType.VarChar),
                    new OracleParameter("p_ld_txjcgc2",OracleType.VarChar),
                    new OracleParameter("p_ld_txgd2",OracleType.VarChar),
                    new OracleParameter("p_ld_txsccj2",OracleType.VarChar),
                    new OracleParameter("p_ld_txxh_lx2",OracleType.VarChar),
                    new OracleParameter("p_ld_fgqk2",OracleType.VarChar),
                    new OracleParameter("p_wxdtzzyxq2",OracleType.VarChar),
                    new OracleParameter("p_ld_sc2",OracleType.VarChar),

                    //自动相关监视系统设备(ADSB)  13
                    new OracleParameter("p_zdxgjsxtsb_gzpl",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_sfpcsxb",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_csxbxh",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_csxbsmsdzdm",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_cyzzrs",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_fzgl",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_csfs",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txszdd",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txjcgc",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txsccj",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txxh_lx",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_wxdtzzyxq",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_sc",OracleType.VarChar),

                    //多点定位系统 8
                    new OracleParameter("p_dddwxt_gzpl",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_fstfzgl",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txszdd",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txjcgc",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txsccj",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txxh_lx",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_wxdtzzyxq",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_sc",OracleType.VarChar),

                    //自动化系统  6
                    new OracleParameter("p_zdhxt_jsyyjxl",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_xtrjbb",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_xtgm",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_ATCgzsqs",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_A_SMGCSxtfj",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_cyzzrs",OracleType.VarChar),
                     // 6
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_sjbs",OracleType.VarChar),
                    new OracleParameter("p_sjssbm",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),
                    new OracleParameter("p_id",OracleType.Number),
                    new OracleParameter("p_errorCode",OracleType.Int32)
    };
                parament[0].Value = struct_jssb.p_wz;
                parament[1].Value = struct_jssb.p_zt;
                parament[2].Value = struct_jssb.p_sbbh;
                parament[3].Value = struct_jssb.p_sszx;
                parament[4].Value = struct_jssb.p_sstz;
                parament[5].Value = struct_jssb.p_dtzzdqsj;
                parament[6].Value = struct_jssb.p_sblx;
                parament[7].Value = struct_jssb.p_sbxh;
                //parament[8].Value = struct_jssb.p_tzmczl;
                parament[8].Value = struct_jssb.p_ssjc;
                parament[9].Value = struct_jssb.p_jgrq;
                parament[10].Value = struct_jssb.p_tcjyrq;
                parament[11].Value = struct_jssb.p_tckfhbarq;
                parament[12].Value = struct_jssb.p_sbccbh;
                parament[13].Value = struct_jssb.p_zyjscstx;
                parament[14].Value = struct_jssb.p_sbzt;
                parament[15].Value = struct_jssb.p_gdfs;
                parament[16].Value = struct_jssb.p_csfs;
                parament[17].Value = struct_jssb.p_sbsccj;
                parament[18].Value = struct_jssb.p_sc;
                parament[19].Value = struct_jssb.p_ddzb_bj54_jd;
                parament[20].Value = struct_jssb.p_ddzb_bj54_wd;
                parament[21].Value = struct_jssb.p_ddzb_wgs84_jd;
                parament[22].Value = struct_jssb.p_ddzb_wgs84_wd;

                ////雷达设备 11
                parament[23].Value = struct_jssb.p_ld_gzpl1;
                parament[24].Value = struct_jssb.p_ld_csxbxh1;
                parament[25].Value = struct_jssb.p_ld_fzgl1;
                parament[26].Value = struct_jssb.p_ld_txszdd1;
                parament[27].Value = struct_jssb.p_ld_txjcgc1;
                parament[28].Value = struct_jssb.p_ld_txgd1;
                parament[29].Value = struct_jssb.p_ld_txsccj1;
                parament[30].Value = struct_jssb.p_ld_txxh_lx1;
                parament[31].Value = struct_jssb.p_ld_fgqk1;
                parament[32].Value = struct_jssb.p_wxdtzzyxq1;
                parament[33].Value = struct_jssb.p_ld_sc1;

                ////二雷达设备
                parament[34].Value = struct_jssb.p_ld_gzpl2;
                parament[35].Value = struct_jssb.p_ld_csxbxh2;
                parament[36].Value = struct_jssb.p_ld_fzgl2;
                parament[37].Value = struct_jssb.p_ld_txszdd2;
                parament[38].Value = struct_jssb.p_ld_txjcgc2;
                parament[39].Value = struct_jssb.p_ld_txgd2;
                parament[40].Value = struct_jssb.p_ld_txsccj2;
                parament[41].Value = struct_jssb.p_ld_txxh_lx2;
                parament[42].Value = struct_jssb.p_ld_fgqk2;
                parament[43].Value = struct_jssb.p_wxdtzzyxq2;
                parament[44].Value = struct_jssb.p_ld_sc2;
                //自动相关监视系统设备(ADSB)
                parament[45].Value = struct_jssb.p_zdxgjsxtsb_gzpl;
                parament[46].Value = struct_jssb.p_zdxgjsxtsb_sfpcsxb;
                parament[47].Value = struct_jssb.p_zdxgjsxtsb_csxbxh;
                parament[48].Value = struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm;
                parament[49].Value = struct_jssb.p_zdxgjsxtsb_cyzzrs;
                parament[50].Value = struct_jssb.p_zdxgjsxtsb_fzgl;
                parament[51].Value = struct_jssb.p_zdxgjsxtsb_csfs;
                parament[52].Value = struct_jssb.p_zdxgjsxtsb_txszdd;
                parament[53].Value = struct_jssb.p_zdxgjsxtsb_txjcgc;
                parament[54].Value = struct_jssb.p_zdxgjsxtsb_txsccj;
                parament[55].Value = struct_jssb.p_zdxgjsxtsb_txxh_lx;
                parament[56].Value = struct_jssb.p_zdxgjsxtsb_wxdtzzyxq;
                parament[57].Value = struct_jssb.p_zdxgjsxtsb_sc;
                //多点定位系统
                parament[58].Value = struct_jssb.p_dddwxt_gzpl;
                parament[59].Value = struct_jssb.p_dddwxt_fstfzgl;
                parament[60].Value = struct_jssb.p_dddwxt_txszdd;
                parament[61].Value = struct_jssb.p_dddwxt_txjcgc;
                parament[62].Value = struct_jssb.p_dddwxt_txsccj;
                parament[63].Value = struct_jssb.p_dddwxt_txxh_lx;
                parament[64].Value = struct_jssb.p_dddwxt_wxdtzzyxq;
                parament[65].Value = struct_jssb.p_dddwxt_sc;
                //自动化系统
                parament[66].Value = struct_jssb.p_zdhxt_jsyyjxl;
                parament[67].Value = struct_jssb.p_zdhxt_xtrjbb;
                parament[68].Value = struct_jssb.p_zdhxt_xtgm;
                parament[69].Value = struct_jssb.p_zdhxt_ATCgzsqs;
                parament[70].Value = struct_jssb.p_zdhxt_A_SMGCSxtfj;
                parament[71].Value = struct_jssb.p_zdhxt_cyzzrs;

                parament[72].Value = struct_jssb.p_sjc;
                parament[73].Value = struct_jssb.p_sjbs;
                parament[74].Value = struct_jssb.p_sjssbm;
                parament[75].Value = struct_jssb.p_csr;
                parament[76].Value = struct_jssb.p_zsr;
                parament[77].Value = struct_jssb.p_lrr;
                parament[78].Value = struct_jssb.p_id;
                parament[79].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_JSSB.Update_JSSB", parament, out result);
                int returnCode = Convert.ToInt32(parament[79].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_jssb.p_czfs;
                struct_RZ_YH.czxx = struct_jssb.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 添加监视设备
        protected void Insert_JSSB(Struct_JSSB struct_jssb) {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    //  24
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_sbbh",OracleType.VarChar),
                    new OracleParameter("p_sszx",OracleType.VarChar),
                    new OracleParameter("p_sstz",OracleType.VarChar),
                    new OracleParameter("p_dtzzdqsj",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_sbxh",OracleType.VarChar),
                    //new OracleParameter("p_tzmczl",OracleType.VarChar),
                    new OracleParameter("p_ssjc",OracleType.VarChar),
                    new OracleParameter("p_jgrq",OracleType.VarChar),
                    new OracleParameter("p_tcjyrq",OracleType.VarChar),
                    new OracleParameter("p_tckfhbarq",OracleType.VarChar),
                    new OracleParameter("p_sbccbh",OracleType.VarChar),
                    new OracleParameter("p_zyjscstx",OracleType.VarChar),
                    new OracleParameter("p_sbzt",OracleType.VarChar),
                    new OracleParameter("p_gdfs",OracleType.VarChar),
                    new OracleParameter("p_csfs",OracleType.VarChar),
                    new OracleParameter("p_sbsccj",OracleType.VarChar),
                    new OracleParameter("p_sc",OracleType.VarChar),
                    new OracleParameter("p_ddzb_bj54_jd",OracleType.VarChar),
                    new OracleParameter("p_ddzb_bj54_wd",OracleType.VarChar),
                    new OracleParameter("p_ddzb_wgs84_jd",OracleType.VarChar),
                    new OracleParameter("p_ddzb_wgs84_wd",OracleType.VarChar),

                    ////一级雷达设备  11
                    new OracleParameter("p_ld_gzpl1",OracleType.VarChar),
                    new OracleParameter("p_ld_csxbxh1",OracleType.VarChar),
                    new OracleParameter("p_ld_fzgl1",OracleType.VarChar),
                    new OracleParameter("p_ld_txszdd1",OracleType.VarChar),
                    new OracleParameter("p_ld_txjcgc1",OracleType.VarChar),
                    new OracleParameter("p_ld_txgd1",OracleType.VarChar),
                    new OracleParameter("p_ld_txsccj1",OracleType.VarChar),
                    new OracleParameter("p_ld_txxh_lx1",OracleType.VarChar),
                    new OracleParameter("p_ld_fgqk1",OracleType.VarChar),
                    new OracleParameter("p_wxdtzzyxq1",OracleType.VarChar),
                    new OracleParameter("p_ld_sc1",OracleType.VarChar),

                    ////二级雷达设备  11
                    new OracleParameter("p_ld_gzpl2",OracleType.VarChar),
                    new OracleParameter("p_ld_csxbxh2",OracleType.VarChar),
                    new OracleParameter("p_ld_fzgl2",OracleType.VarChar),
                    new OracleParameter("p_ld_txszdd2",OracleType.VarChar),
                    new OracleParameter("p_ld_txjcgc2",OracleType.VarChar),
                    new OracleParameter("p_ld_txgd2",OracleType.VarChar),
                    new OracleParameter("p_ld_txsccj2",OracleType.VarChar),
                    new OracleParameter("p_ld_txxh_lx2",OracleType.VarChar),
                    new OracleParameter("p_ld_fgqk2",OracleType.VarChar),
                    new OracleParameter("p_wxdtzzyxq2",OracleType.VarChar),
                    new OracleParameter("p_ld_sc2",OracleType.VarChar),

                    //自动相关监视系统设备(ADSB)  13
                    new OracleParameter("p_zdxgjsxtsb_gzpl",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_sfpcsxb",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_csxbxh",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_csxbsmsdzdm",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_cyzzrs",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_fzgl",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_csfs",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txszdd",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txjcgc",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txsccj",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_txxh_lx",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_wxdtzzyxq",OracleType.VarChar),
                    new OracleParameter("p_zdxgjsxtsb_sc",OracleType.VarChar),

                    //多点定位系统 8
                    new OracleParameter("p_dddwxt_gzpl",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_fstfzgl",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txszdd",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txjcgc",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txsccj",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_txxh_lx",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_wxdtzzyxq",OracleType.VarChar),
                    new OracleParameter("p_dddwxt_sc",OracleType.VarChar),

                    //自动化系统  6
                    new OracleParameter("p_zdhxt_jsyyjxl",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_xtrjbb",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_xtgm",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_ATCgzsqs",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_A_SMGCSxtfj",OracleType.VarChar),
                    new OracleParameter("p_zdhxt_cyzzrs",OracleType.VarChar),
                     // 6
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_sjbs",OracleType.VarChar),
                    new OracleParameter("p_sjssbm",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
    };
                parament[0].Value = struct_jssb.p_wz;
                parament[1].Value = struct_jssb.p_zt;
                parament[2].Value = struct_jssb.p_sbbh;
                parament[3].Value = struct_jssb.p_sszx;
                parament[4].Value = struct_jssb.p_sstz;
                parament[5].Value = struct_jssb.p_dtzzdqsj;
                parament[6].Value = struct_jssb.p_sblx;
                parament[7].Value = struct_jssb.p_sbxh;
                //parament[8].Value = struct_jssb.p_tzmczl;
                parament[8].Value = struct_jssb.p_ssjc;
                parament[9].Value = struct_jssb.p_jgrq;
                parament[10].Value = struct_jssb.p_tcjyrq;
                parament[11].Value = struct_jssb.p_tckfhbarq;
                parament[12].Value = struct_jssb.p_sbccbh;
                parament[13].Value = struct_jssb.p_zyjscstx;
                parament[14].Value = struct_jssb.p_sbzt;
                parament[15].Value = struct_jssb.p_gdfs;
                parament[16].Value = struct_jssb.p_csfs;
                parament[17].Value = struct_jssb.p_sbsccj;
                parament[18].Value = struct_jssb.p_sc;
                parament[19].Value = struct_jssb.p_ddzb_bj54_jd;
                parament[20].Value = struct_jssb.p_ddzb_bj54_wd;
                parament[21].Value = struct_jssb.p_ddzb_wgs84_jd;
                parament[22].Value = struct_jssb.p_ddzb_wgs84_wd;

                ////雷达设备 11
                parament[23].Value = struct_jssb.p_ld_gzpl1;
                parament[24].Value = struct_jssb.p_ld_csxbxh1;
                parament[25].Value = struct_jssb.p_ld_fzgl1;
                parament[26].Value = struct_jssb.p_ld_txszdd1;
                parament[27].Value = struct_jssb.p_ld_txjcgc1;
                parament[28].Value = struct_jssb.p_ld_txgd1;
                parament[29].Value = struct_jssb.p_ld_txsccj1;
                parament[30].Value = struct_jssb.p_ld_txxh_lx1;
                parament[31].Value = struct_jssb.p_ld_fgqk1;
                parament[32].Value = struct_jssb.p_wxdtzzyxq1;
                parament[33].Value = struct_jssb.p_ld_sc1;

                ////二雷达设备
                parament[34].Value = struct_jssb.p_ld_gzpl2;
                parament[35].Value = struct_jssb.p_ld_csxbxh2;
                parament[36].Value = struct_jssb.p_ld_fzgl2;
                parament[37].Value = struct_jssb.p_ld_txszdd2;
                parament[38].Value = struct_jssb.p_ld_txjcgc2;
                parament[39].Value = struct_jssb.p_ld_txgd2;
                parament[40].Value = struct_jssb.p_ld_txsccj2;
                parament[41].Value = struct_jssb.p_ld_txxh_lx2;
                parament[42].Value = struct_jssb.p_ld_fgqk2;
                parament[43].Value = struct_jssb.p_wxdtzzyxq2;
                parament[44].Value = struct_jssb.p_ld_sc2;
                //自动相关监视系统设备(ADSB)
                parament[45].Value = struct_jssb.p_zdxgjsxtsb_gzpl;
                parament[46].Value = struct_jssb.p_zdxgjsxtsb_sfpcsxb;
                parament[47].Value = struct_jssb.p_zdxgjsxtsb_csxbxh;
                parament[48].Value = struct_jssb.p_zdxgjsxtsb_csxbsmsdzdm;
                parament[49].Value = struct_jssb.p_zdxgjsxtsb_cyzzrs;
                parament[50].Value = struct_jssb.p_zdxgjsxtsb_fzgl;
                parament[51].Value = struct_jssb.p_zdxgjsxtsb_csfs;
                parament[52].Value = struct_jssb.p_zdxgjsxtsb_txszdd;
                parament[53].Value = struct_jssb.p_zdxgjsxtsb_txjcgc;
                parament[54].Value = struct_jssb.p_zdxgjsxtsb_txsccj;
                parament[55].Value = struct_jssb.p_zdxgjsxtsb_txxh_lx;
                parament[56].Value = struct_jssb.p_zdxgjsxtsb_wxdtzzyxq;
                parament[57].Value = struct_jssb.p_zdxgjsxtsb_sc;
                //多点定位系统
                parament[58].Value = struct_jssb.p_dddwxt_gzpl;
                parament[59].Value = struct_jssb.p_dddwxt_fstfzgl;
                parament[60].Value = struct_jssb.p_dddwxt_txszdd;
                parament[61].Value = struct_jssb.p_dddwxt_txjcgc;
                parament[62].Value = struct_jssb.p_dddwxt_txsccj;
                parament[63].Value = struct_jssb.p_dddwxt_txxh_lx;
                parament[64].Value = struct_jssb.p_dddwxt_wxdtzzyxq;
                parament[65].Value = struct_jssb.p_dddwxt_sc;
                //自动化系统
                parament[66].Value = struct_jssb.p_zdhxt_jsyyjxl;
                parament[67].Value = struct_jssb.p_zdhxt_xtrjbb;
                parament[68].Value = struct_jssb.p_zdhxt_xtgm;
                parament[69].Value = struct_jssb.p_zdhxt_ATCgzsqs;
                parament[70].Value = struct_jssb.p_zdhxt_A_SMGCSxtfj;
                parament[71].Value = struct_jssb.p_zdhxt_cyzzrs;

                parament[72].Value = struct_jssb.p_sjc;
                parament[73].Value = struct_jssb.p_sjbs;
                parament[74].Value = struct_jssb.p_sjssbm;
                parament[75].Value = struct_jssb.p_csr;
                parament[76].Value = struct_jssb.p_zsr;
                parament[77].Value = struct_jssb.p_lrr;
                parament[78].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_JSSB.Insert_JSSB", parament, out result);
                int returnCode = Convert.ToInt32(parament[78].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_jssb.p_czfs;
                struct_RZ_YH.czxx = struct_jssb.p_czxx;
                //rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally {
                dbclass.Close();
            }
        }
        #endregion
        #region 删除监视设备
        protected void Delete_JSSB(int id,string p_czfs,string p_czxx) {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Int32),
                    new OracleParameter("p_errorCode",OracleType.Int32),
                };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_JSSB.Delete_JSSB", parament, out result);
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
            finally {
                dbclass.Close();
            }
        }
        #endregion
        #region 修改监视状态
        protected void Update_JSSB_ZT(Struct_JSSB struct_jssb)
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
                paras[0].Value = struct_jssb.p_id;
                paras[1].Value = struct_jssb.p_zt;
                paras[2].Value = struct_jssb.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_JSSB.Update_JSSB_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jssb.p_czfs;
                struct_rz.czxx = struct_jssb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 原始数据通过审核
        //变更数据标识
        protected void Update_JSSB_SJBS_ZT(Struct_JSSB struct_jssb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_jssb.p_sjc;
                paras[1].Value = struct_jssb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_JSSB.Update_JSSB_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jssb.p_czfs;
                struct_rz.czxx = struct_jssb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 将原最终数据变为历史数据
        //将原最终数据变为历史数据
        protected void Update_JSSB_SJBS_LSSJ_ZT(Struct_JSSB struct_jssb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_jssb.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_JSSB.Update_JSSB_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jssb.p_czfs;
                struct_rz.czxx = struct_jssb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 将原副本数据变为最终数据
        protected void Update_JSSB_SJBS_FBSJ_ZT(Struct_JSSB struct_jssb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_jssb.p_sjc;
                paras[1].Value = struct_jssb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_JSSB.Update_JSSB_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jssb.p_czfs;
                struct_rz.czxx = struct_jssb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 查询备份数据id
        //数据备份
        protected int JSSB_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_JSSB_Detail(id);
            //备份数据
            Struct_JSSB jssb_bf = new Struct_JSSB();

            jssb_bf.p_wz = dt_detail.Rows[0]["wz"].ToString();
            jssb_bf.p_zt = "0";
            jssb_bf.p_sbbh = dt_detail.Rows[0]["sbbh"].ToString();           
            jssb_bf.p_sszx = dt_detail.Rows[0]["sszx"].ToString();
            jssb_bf.p_sstz = dt_detail.Rows[0]["sstz"].ToString();
            jssb_bf.p_dtzzdqsj = dt_detail.Rows[0]["dtzzdqsj"].ToString();
            jssb_bf.p_sblx = dt_detail.Rows[0]["sblx"].ToString();
            jssb_bf.p_sbxh = dt_detail.Rows[0]["sbxh"].ToString();
            jssb_bf.p_sjssbm = dt_detail.Rows[0]["sjssbm"].ToString();
            //jssb_bf.p_tzmczl = dt_detail.Rows[0]["tzmczl"].ToString();
            jssb_bf.p_ssjc = dt_detail.Rows[0]["ssjc"].ToString();
            jssb_bf.p_jgrq = dt_detail.Rows[0]["jgrq"].ToString();
            jssb_bf.p_tcjyrq = dt_detail.Rows[0]["tcjyrq"].ToString();
            jssb_bf.p_tckfhbarq = dt_detail.Rows[0]["tckfhbarq"].ToString();
            jssb_bf.p_sbccbh = dt_detail.Rows[0]["sbccbh"].ToString();
            jssb_bf.p_zyjscstx = dt_detail.Rows[0]["zyjscstx"].ToString();
            jssb_bf.p_sbzt = dt_detail.Rows[0]["sbzt"].ToString();
            jssb_bf.p_gdfs = dt_detail.Rows[0]["gdfs"].ToString();
            jssb_bf.p_csfs = dt_detail.Rows[0]["csfs"].ToString();
            jssb_bf.p_sbsccj = dt_detail.Rows[0]["sbsccj"].ToString();
            jssb_bf.p_sc = dt_detail.Rows[0]["sc"].ToString();
            jssb_bf.p_ddzb_bj54_jd = dt_detail.Rows[0]["ddzb_bj54_jd"].ToString();      
            jssb_bf.p_ddzb_bj54_wd = dt_detail.Rows[0]["ddzb_bj54_wd"].ToString();
            jssb_bf.p_ddzb_wgs84_jd = dt_detail.Rows[0]["ddzb_wgs84_jd"].ToString();
            jssb_bf.p_ddzb_wgs84_wd = dt_detail.Rows[0]["ddzb_wgs84_wd"].ToString();
            //一级雷达设备
            jssb_bf.p_ld_gzpl1 = dt_detail.Rows[0]["ld_gzpl1"].ToString();
            jssb_bf.p_ld_csxbxh1 = dt_detail.Rows[0]["ld_csxbxh1"].ToString();
            jssb_bf.p_ld_fzgl1 = dt_detail.Rows[0]["ld_fzgl1"].ToString();
            jssb_bf.p_ld_txszdd1 = dt_detail.Rows[0]["ld_txszdd1"].ToString();
            jssb_bf.p_ld_txjcgc1 = dt_detail.Rows[0]["ld_txjcgc1"].ToString();
            jssb_bf.p_ld_txgd1 = dt_detail.Rows[0]["ld_txgd1"].ToString();
            jssb_bf.p_ld_txsccj1 = dt_detail.Rows[0]["ld_txsccj1"].ToString();
            jssb_bf.p_ld_txxh_lx1 = dt_detail.Rows[0]["ld_txxh_lx1"].ToString();
            jssb_bf.p_ld_fgqk1 = dt_detail.Rows[0]["ld_fgqk1"].ToString();
            jssb_bf.p_wxdtzzyxq1 = dt_detail.Rows[0]["wxdtzzyxq1"].ToString();
            jssb_bf.p_ld_sc1 = dt_detail.Rows[0]["ld_sc1"].ToString();
            //二级雷达设备
            jssb_bf.p_ld_gzpl2 = dt_detail.Rows[0]["ld_gzpl2"].ToString();
            jssb_bf.p_ld_csxbxh2 = dt_detail.Rows[0]["ld_csxbxh2"].ToString();
            jssb_bf.p_ld_fzgl2 = dt_detail.Rows[0]["ld_fzgl2"].ToString();
            jssb_bf.p_ld_txszdd2 = dt_detail.Rows[0]["ld_txszdd2"].ToString();
            jssb_bf.p_ld_txjcgc2 = dt_detail.Rows[0]["ld_txjcgc2"].ToString();
            jssb_bf.p_ld_txgd2 = dt_detail.Rows[0]["ld_txgd2"].ToString();
            jssb_bf.p_ld_txsccj2 = dt_detail.Rows[0]["ld_txsccj2"].ToString();
            jssb_bf.p_ld_txxh_lx2 = dt_detail.Rows[0]["ld_txxh_lx2"].ToString();
            jssb_bf.p_ld_fgqk2 = dt_detail.Rows[0]["ld_fgqk2"].ToString();
            jssb_bf.p_wxdtzzyxq2 = dt_detail.Rows[0]["wxdtzzyxq2"].ToString();
            jssb_bf.p_ld_sc2 = dt_detail.Rows[0]["ld_sc2"].ToString();
            //自动相关监视系统设备(ADSB)
            jssb_bf.p_zdxgjsxtsb_gzpl = dt_detail.Rows[0]["zdxgjsxtsb_gzpl"].ToString();
            jssb_bf.p_zdxgjsxtsb_sfpcsxb = dt_detail.Rows[0]["zdxgjsxtsb_sfpcsxb"].ToString();
            jssb_bf.p_zdxgjsxtsb_csxbxh = dt_detail.Rows[0]["zdxgjsxtsb_csxbxh"].ToString();
            jssb_bf.p_zdxgjsxtsb_csxbsmsdzdm = dt_detail.Rows[0]["zdxgjsxtsb_csxbsmsdzdm"].ToString();
            jssb_bf.p_zdxgjsxtsb_cyzzrs = dt_detail.Rows[0]["zdxgjsxtsb_cyzzrs"].ToString();
            jssb_bf.p_zdxgjsxtsb_fzgl = dt_detail.Rows[0]["zdxgjsxtsb_fzgl"].ToString();
            jssb_bf.p_zdxgjsxtsb_csfs = dt_detail.Rows[0]["zdxgjsxtsb_csfs"].ToString();
            jssb_bf.p_zdxgjsxtsb_txszdd = dt_detail.Rows[0]["zdxgjsxtsb_txszdd"].ToString();
            jssb_bf.p_zdxgjsxtsb_txjcgc = dt_detail.Rows[0]["zdxgjsxtsb_txjcgc"].ToString();
            jssb_bf.p_zdxgjsxtsb_txsccj = dt_detail.Rows[0]["zdxgjsxtsb_txsccj"].ToString();
            jssb_bf.p_zdxgjsxtsb_txxh_lx = dt_detail.Rows[0]["zdxgjsxtsb_txxh_lx"].ToString();
            jssb_bf.p_zdxgjsxtsb_wxdtzzyxq = dt_detail.Rows[0]["zdxgjsxtsb_wxdtzzyxq"].ToString();
            jssb_bf.p_zdxgjsxtsb_sc = dt_detail.Rows[0]["zdxgjsxtsb_sc"].ToString();
            //多点定位系统
            jssb_bf.p_dddwxt_gzpl = dt_detail.Rows[0]["dddwxt_gzpl"].ToString();
            jssb_bf.p_dddwxt_fstfzgl = dt_detail.Rows[0]["dddwxt_fstfzgl"].ToString();
            jssb_bf.p_dddwxt_txszdd = dt_detail.Rows[0]["dddwxt_txszdd"].ToString();
            jssb_bf.p_dddwxt_txjcgc = dt_detail.Rows[0]["dddwxt_txjcgc"].ToString();
            jssb_bf.p_dddwxt_txsccj = dt_detail.Rows[0]["dddwxt_txsccj"].ToString();
            jssb_bf.p_dddwxt_txxh_lx = dt_detail.Rows[0]["dddwxt_txxh_lx"].ToString();
            jssb_bf.p_dddwxt_wxdtzzyxq = dt_detail.Rows[0]["dddwxt_wxdtzzyxq"].ToString();
            jssb_bf.p_dddwxt_sc = dt_detail.Rows[0]["dddwxt_sc"].ToString();
            //自动化系统
            jssb_bf.p_zdhxt_jsyyjxl = dt_detail.Rows[0]["zdhxt_jsyyjxl"].ToString();
            jssb_bf.p_zdhxt_xtrjbb = dt_detail.Rows[0]["zdhxt_xtrjbb"].ToString();
            jssb_bf.p_zdhxt_xtgm = dt_detail.Rows[0]["zdhxt_xtgm"].ToString();
            jssb_bf.p_zdhxt_ATCgzsqs = dt_detail.Rows[0]["zdhxt_ATCgzsqs"].ToString();
            jssb_bf.p_zdhxt_A_SMGCSxtfj = dt_detail.Rows[0]["zdhxt_A_SMGCSxtfj"].ToString();
            jssb_bf.p_zdhxt_cyzzrs = dt_detail.Rows[0]["zdhxt_cyzzrs"].ToString();

            jssb_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            jssb_bf.p_sjbs = "2";
            jssb_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            jssb_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            jssb_bf.p_lrr = _us.userLoginName;
            jssb_bf.p_shsj = "";
            jssb_bf.p_czfs = "02";
            jssb_bf.p_czxx = "员工奖励id:" + id + "生成副本数据";
            //插入
            Insert_JSSB(jssb_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = jssb_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_JSSB.Select_JSSB_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
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
                string count = dbclass.RunProcedure("PACK_KG_JSSB.Select_SB_MaxNumber", parament, "table").Tables[0].Rows[0][0].ToString();
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
        //数据导出
        protected DataTable Select_JSSB_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_KG_JSSB.Select_JSSB_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


    }


}
