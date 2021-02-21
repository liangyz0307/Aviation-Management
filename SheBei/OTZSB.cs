using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;


namespace CUST.MKG
{
    public struct Struct_TZSB
    {
        public int p_id;//id
        public string p_tzbh;//台站编号
        public string p_tzmc;//台站名称
        public string p_jc;//机场
        public string p_wz;//位置
        public string p_sblx;//设备类型
        public string p_fwxx;//房屋信息
        public string p_lc;//楼层
        public string p_fjh;//房间号
        public string p_jg;//结构
        public DateTime p_jgsj;//竣工时间
        public string p_tzwzxx;//台站位置信息
        public string p_jfsrxlqk;//机房输入线路情况
        public string p_jfzsc;//机房总输出
        public string p_jfzscdx;//机房总输出大小
        public string p_jfzscsl;//机房总输出数量
        public string p_tzsbmcjxh;//台站设备名称及型号
        public string p_sc;//上传
        public string p_tzwdsfdb;//台站温度是否达标
        public string p_bdbyy;//不达标原因
        public string p_sfpb;//是否配备
        public string p_sl;//数量
        public string p_pp;//品牌
        public string p_azsj;//安装时间
        public string p_bxnx;//保修年限
        public string p_sfazzqzz;//是否安装紫气装置
        public string p_mhsblx;//灭火设备类型
        public DateTime p_jcdqsj;//监测到期时间
        public string p_mhqgs;//灭火器个数
        public string p_dsb;//挡鼠板
        public string p_zsbgs;//粘鼠板个数
        public string p_qtcs;//其他措施
        public string p_fh;//防洪措施是否具备
        public string p_fd;//防盗措施是否具备
        public string p_wxgj;//维修工具是否满足该设备故障时紧急维修需求
        public string p_jfflcs;//机房防雷措施
        public string p_fljcdqrq;//防雷检测到期日期
        public string p_sfydn;//是否有地暖
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
        public string p_zt;
        public string p_shsj;//审核时间
        public string p_sjc;//时间戳
        public string p_sjbs;//时间标识
        public string p_bmdm;//数据所属部门
        public string p_lrr;//录入人
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_bhyy;//驳回原因
        public int p_userid;

    }
    public struct Struct_SELECT_COUNT
    {
        public int p_id;//id
        public string p_tzbh;//台站编号
        public string p_tzmc;//台站名称
        public string p_jc;//机场
        public string p_wz;//位置
        public string p_sblx;//设备类型
        public string p_fwxx;//房屋信息
        public string p_lc;//楼层
        public string p_fjh;//房间号
        public string p_jg;//结构
        public DateTime p_jgsj;//竣工时间
        public string p_tzwzxx;//台站位置信息
        public string p_jfsrxlqk;//机房输入线路情况
        public string p_jfzsc;//机房总输出
        public string p_jfzscdx;//机房总输出大小
        public string p_jfzscsl;//机房总输出数量
        public string p_tzsbmcjxh;//台站设备名称及型号
        public string p_sc;//上传
        public string p_tzwdsfdb;//台站温度是否达标
        public string p_bdbyy;//不达标原因
        public string p_sfpb;//是否配备
        public string p_sl;//数量
        public string p_pp;//品牌
        public string p_azsj;//安装时间
        public string p_bxnx;//保修年限
        public string p_sfazzqzz;//是否安装紫气装置
        public string p_mhsblx;//灭火设备类型
        public DateTime p_jcdqsj;//监测到期时间
        public string p_mhqgs;//灭火器个数
        public string p_dsb;//挡鼠板
        public string p_zsbgs;//粘鼠板个数
        public string p_qtcs;//其他措施
        public string p_fh;//防洪措施是否具备
        public string p_fd;//防盗措施是否具备
        public string p_wxgj;//维修工具是否满足该设备故障时紧急维修需求
        public string p_jfflcs;//机房防雷措施
        public string p_fljcdqrq;//防雷检测到期日期
        public string p_sfydn;//是否有地暖
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
        public string p_zt;
        public string p_shsj;//审核时间
        public string p_sjc;//时间戳
        public string p_sjbs;//时间标识
        public string p_bmdm;//数据所属部门
        public string p_lrr;//录入人
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_bhyy;//驳回原因
        public int p_userid;

    }
    public class OTZSB
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private RZ rz;
        private UserState _us = null;
        //private UserState _usState;
        public OTZSB(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region===============台站设备增删改查================
        #region  ===============台站基本信息查询================
        protected DataSet Select_TZ_Pro(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_fwxx",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Value = struct_tzsb.p_fwxx;
                parament[4].Value = struct_tzsb.p_zt;
                parament[5].Value = struct_tzsb.p_userid;
                parament[6].Value = struct_tzsb.p_pagesize;
                parament[7].Value = struct_tzsb.p_currentpage;
                parament[8].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============台站查询总数================
        protected int Select_TZ_Count(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_fwxx",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Value = struct_tzsb.p_fwxx;
                parament[4].Value = struct_tzsb.p_zt;
                parament[5].Value = struct_tzsb.p_userid;
                parament[6].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_Table_Count_HD(Struct_SELECT_COUNT Struct_select_count)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = Struct_select_count.p_jc;
                parament[1].Value = Struct_select_count.p_wz;
                parament[2].Value = Struct_select_count.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_Table_Count_DH", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_Table_Count_TX(Struct_SELECT_COUNT Struct_select_count)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = Struct_select_count.p_jc;
                parament[1].Value = Struct_select_count.p_wz;
                parament[2].Value = Struct_select_count.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_Table_Count_TX", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_Table_Count_JS(Struct_SELECT_COUNT Struct_select_count)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = Struct_select_count.p_jc;
                parament[1].Value = Struct_select_count.p_wz;
                parament[2].Value = Struct_select_count.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_Table_Count_JS", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_Table_Count_QX(Struct_SELECT_COUNT Struct_select_count)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = Struct_select_count.p_jc;
                parament[1].Value = Struct_select_count.p_wz;
                parament[2].Value = Struct_select_count.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_Table_Count_QX", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region  ===============台站添加基本信息================
        protected void Insert_TZ(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_tzbh",OracleType.VarChar),
                     //   new OracleParameter("p_tzmc",OracleType.VarChar),
                        new OracleParameter("p_jc",OracleType.VarChar),
                        new OracleParameter("p_wz",OracleType.VarChar),
                        new OracleParameter("p_sblx",OracleType.VarChar),
                        new OracleParameter("p_fwxx",OracleType.VarChar),
                        new OracleParameter("p_lc",OracleType.VarChar),
                        new OracleParameter("p_fjh",OracleType.VarChar),
                        new OracleParameter("p_jg",OracleType.VarChar),
                        new OracleParameter("p_jgsj",OracleType.DateTime),
                        new OracleParameter("p_tzwzxx",OracleType.VarChar),
                        new OracleParameter("p_jfsrxlqk",OracleType.VarChar),
                        new OracleParameter("p_jfzsc",OracleType.VarChar),
                        new OracleParameter("p_jfzscdx",OracleType.VarChar),
                        new OracleParameter("p_jfzscsl",OracleType.VarChar),
                    //    new OracleParameter("p_tzsbmcjxh",OracleType.VarChar),
                        new OracleParameter("p_sc",OracleType.VarChar),
                        new OracleParameter("p_tzwdsfdb",OracleType.VarChar),
                        new OracleParameter("p_bdbyy",OracleType.VarChar),
                        new OracleParameter("p_zt",OracleType.VarChar),
                       
                        new OracleParameter("p_sjc",OracleType.VarChar),
                        new OracleParameter("p_sjbs",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_lrr",OracleType.VarChar),
                        new OracleParameter("p_csr",OracleType.VarChar),
                        new OracleParameter("p_zsr",OracleType.VarChar),
                        new OracleParameter("p_tzmc",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_tzbh;
            //    parament[2].Value = struct_tzsb.p_tzmc;
                parament[2].Value = struct_tzsb.p_jc;
                parament[3].Value = struct_tzsb.p_wz;
                parament[4].Value = struct_tzsb.p_sblx;
                parament[5].Value = struct_tzsb.p_fwxx;
                parament[6].Value = struct_tzsb.p_lc;
                parament[7].Value = struct_tzsb.p_fjh;
                parament[8].Value = struct_tzsb.p_jg;
                parament[9].Value = struct_tzsb.p_jgsj;
                parament[10].Value = struct_tzsb.p_tzwzxx;
                parament[11].Value = struct_tzsb.p_jfsrxlqk;
                parament[12].Value = struct_tzsb.p_jfzsc;
                parament[13].Value = struct_tzsb.p_jfzscdx;
                parament[14].Value = struct_tzsb.p_jfzscsl;
            //    parament[15].Value = struct_tzsb.p_tzsbmcjxh;
                parament[15].Value = struct_tzsb.p_sc;
                parament[16].Value = struct_tzsb.p_tzwdsfdb;
                parament[17].Value = struct_tzsb.p_bdbyy;
                parament[18].Value = struct_tzsb.p_zt;
              
                parament[19].Value = struct_tzsb.p_sjc;
                parament[20].Value = struct_tzsb.p_sjbs;
                parament[21].Value = struct_tzsb.p_bmdm;
                parament[22].Value = struct_tzsb.p_lrr;
                parament[23].Value = struct_tzsb.p_csr;
                parament[24].Value = struct_tzsb.p_zsr;
                parament[25].Value = struct_tzsb.p_tzmc;
                parament[26].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Insert_TZ", parament, out result);
                int returnCode = Convert.ToInt32(parament[26].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_tzsb.p_czfs;
                struct_RZ_YH.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============台站编辑基本信息================
        protected void Update_TZ(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                     //   new OracleParameter("p_tzbh",OracleType.VarChar),
                    //    new OracleParameter("p_tzmc",OracleType.VarChar),
                        new OracleParameter("p_jc",OracleType.VarChar),
                        new OracleParameter("p_wz",OracleType.VarChar),
                        new OracleParameter("p_sblx",OracleType.VarChar),
                        new OracleParameter("p_fwxx",OracleType.VarChar),
                        new OracleParameter("p_lc",OracleType.VarChar),
                        new OracleParameter("p_fjh",OracleType.VarChar),
                        new OracleParameter("p_jg",OracleType.VarChar),
                        new OracleParameter("p_jgsj",OracleType.DateTime),
                        new OracleParameter("p_tzwzxx",OracleType.VarChar),
                        new OracleParameter("p_jfsrxlqk",OracleType.VarChar),
                        new OracleParameter("p_jfzsc",OracleType.VarChar),
                        new OracleParameter("p_jfzscdx",OracleType.VarChar),
                        new OracleParameter("p_jfzscsl",OracleType.VarChar),
                   //     new OracleParameter("p_tzsbmcjxh",OracleType.VarChar),
                        new OracleParameter("p_sc",OracleType.VarChar),
                        new OracleParameter("p_tzwdsfdb",OracleType.VarChar),
                        new OracleParameter("p_bdbyy",OracleType.VarChar),
                        new OracleParameter("p_zt",OracleType.VarChar),
                   //     new OracleParameter("p_shsj",OracleType.VarChar),
                   //     new OracleParameter("p_sjc",OracleType.VarChar),
                        new OracleParameter("p_sjbs",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_lrr",OracleType.VarChar),
                        new OracleParameter("p_csr",OracleType.VarChar),
                        new OracleParameter("p_zsr",OracleType.VarChar),
                        new OracleParameter("p_tzmc",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
             //   parament[1].Value = struct_tzsb.p_tzbh;
           //     parament[2].Value = struct_tzsb.p_tzmc;
                parament[1].Value = struct_tzsb.p_jc;
                parament[2].Value = struct_tzsb.p_wz;
                parament[3].Value = struct_tzsb.p_sblx;
                parament[4].Value = struct_tzsb.p_fwxx;
                parament[5].Value = struct_tzsb.p_lc;
                parament[6].Value = struct_tzsb.p_fjh;
                parament[7].Value = struct_tzsb.p_jg;
                parament[8].Value = struct_tzsb.p_jgsj;
                parament[9].Value = struct_tzsb.p_tzwzxx;
                parament[10].Value = struct_tzsb.p_jfsrxlqk;
                parament[11].Value = struct_tzsb.p_jfzsc;
                parament[12].Value = struct_tzsb.p_jfzscdx;
                parament[13].Value = struct_tzsb.p_jfzscsl;
            //    parament[16].Value = struct_tzsb.p_tzsbmcjxh;
                parament[14].Value = struct_tzsb.p_sc;
                parament[15].Value = struct_tzsb.p_tzwdsfdb;
                parament[16].Value = struct_tzsb.p_bdbyy;
                parament[17].Value = struct_tzsb.p_zt;
             //   parament[21].Value = struct_tzsb.p_shsj;
             //   parament[19].Value = struct_tzsb.p_sjc;
                parament[18].Value = struct_tzsb.p_sjbs;
                parament[19].Value = struct_tzsb.p_bmdm;
                parament[20].Value = struct_tzsb.p_lrr;
                parament[21].Value = struct_tzsb.p_csr;
                parament[22].Value = struct_tzsb.p_zsr;
                parament[23].Value = struct_tzsb.p_tzmc;
                parament[24].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Update_TZ", parament, out result);
                int returnCode = Convert.ToInt32(parament[24].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_tzsb.p_czfs;
                struct_RZ_YH.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============台站删除基本信息================
        protected void Delete_TZ(string p_tzbh, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_tzbh",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = p_tzbh;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Delete_TZ", parament, out result);
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
        #endregion

        #region===============通过基本信息编号查找空调情况================
        protected  DataTable Select_KTByBh(string p_tzbh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_tzbh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = p_tzbh;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
               dt= db.RunProcedure("PACK_KG_TZ.Select_KTByBh", parament, "table").Tables[0];
             
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region  ===============台站添加空调情况================
        protected void Insert_TZ_KT(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_tzbh",OracleType.VarChar),
                        new OracleParameter("p_sfpb",OracleType.VarChar),
                        new OracleParameter("p_sl",OracleType.VarChar),
                        new OracleParameter("p_pp",OracleType.VarChar),
                        new OracleParameter("p_azsj",OracleType.VarChar),
                        new OracleParameter("p_bxnx",OracleType.VarChar),
                        new OracleParameter("p_sfazzqzz",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_tzbh;
                parament[2].Value = struct_tzsb.p_sfpb;
                parament[3].Value = struct_tzsb.p_sl;
                parament[4].Value = struct_tzsb.p_pp;
                parament[5].Value = struct_tzsb.p_azsj;
                parament[6].Value = struct_tzsb.p_bxnx;
                parament[7].Value = struct_tzsb.p_sfazzqzz;
                parament[8].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Insert_TZ_KT", parament, out result);
                int returnCode = Convert.ToInt32(parament[8].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============台站编辑空调情况================
        protected void Update_TZ_KT(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_sfpb",OracleType.VarChar),
                        new OracleParameter("p_sl",OracleType.VarChar),
                        new OracleParameter("p_pp",OracleType.VarChar),
                        new OracleParameter("p_azsj",OracleType.VarChar),
                        new OracleParameter("p_bxnx",OracleType.VarChar),
                        new OracleParameter("p_sfazzqzz",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_sfpb;
                parament[2].Value = struct_tzsb.p_sl;
                parament[3].Value = struct_tzsb.p_pp;
                parament[4].Value = struct_tzsb.p_azsj;
                parament[5].Value = struct_tzsb.p_bxnx;
                parament[6].Value = struct_tzsb.p_sfazzqzz;
                parament[7].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Update_TZ_KT", parament, out result);
                int returnCode = Convert.ToInt32(parament[7].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============台站删除空调情况================
        protected void Delete_TZ_KT(int p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Int32),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Delete_TZ_KT", parament, out result);
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
        #endregion

        #region===============通过基本信息编号查找加湿器情况================
        protected DataTable Select_JSQByBh(string p_tzbh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_tzbh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = p_tzbh;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_KG_TZ.Select_JSQByBh", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region  ===============台站添加加湿器情况================
        protected void Insert_TZ_JSQQK(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_tzbh",OracleType.VarChar),
                        new OracleParameter("p_sfpb",OracleType.VarChar),
                        new OracleParameter("p_sl",OracleType.VarChar),
                        new OracleParameter("p_pp",OracleType.VarChar),
                        new OracleParameter("p_azsj",OracleType.VarChar),
                        new OracleParameter("p_bxnx",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_tzbh;
                parament[2].Value = struct_tzsb.p_sfpb;
                parament[3].Value = struct_tzsb.p_sl;
                parament[4].Value = struct_tzsb.p_pp;
                parament[5].Value = struct_tzsb.p_azsj;
                parament[6].Value = struct_tzsb.p_bxnx;
                parament[7].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Insert_TZ_JSQ", parament, out result);
                int returnCode = Convert.ToInt32(parament[7].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============台站编辑加湿器情况================
        protected void Update_TZ_JSQQK(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_sfpb",OracleType.VarChar),
                        new OracleParameter("p_sl",OracleType.VarChar),
                        new OracleParameter("p_pp",OracleType.VarChar),
                        new OracleParameter("p_azsj",OracleType.VarChar),
                        new OracleParameter("p_bxnx",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_sfpb;
                parament[2].Value = struct_tzsb.p_sl;
                parament[3].Value = struct_tzsb.p_pp;
                parament[4].Value = struct_tzsb.p_azsj;
                parament[5].Value = struct_tzsb.p_bxnx;
                parament[6].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Update_TZ_JSQ", parament, out result);
                int returnCode = Convert.ToInt32(parament[6].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============台站删除加湿器情况================
        protected void Delete_TZ_JSQQK(int p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Int32),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Delete_TZ_JSQ", parament, out result);
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
        #endregion

        #region===============通过基本信息编号查找防火设备情况================
        protected DataTable Select_FHSBByBh(string p_tzbh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_tzbh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = p_tzbh;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_KG_TZ.Select_FHSBByBh", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region  ===============台站添加防火设备================
        protected void Insert_TZ_FHSB(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_tzbh",OracleType.VarChar),
                        new OracleParameter("p_mhsblx",OracleType.VarChar),
                        new OracleParameter("p_jcdqsj",OracleType.VarChar),
                        new OracleParameter("p_mhqgs",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_tzbh;
                parament[2].Value = struct_tzsb.p_mhsblx;
                parament[3].Value = struct_tzsb.p_jcdqsj;
                parament[4].Value = struct_tzsb.p_mhqgs;
                parament[5].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Insert_TZ_FHSB", parament, out result);
                int returnCode = Convert.ToInt32(parament[5].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============台站编辑防火设备================
        protected void Update_TZ_FHSB(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_mhsblx",OracleType.VarChar),
                        new OracleParameter("p_jcdqsj",OracleType.VarChar),
                        new OracleParameter("p_mhqgs",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_mhsblx;
                parament[2].Value = struct_tzsb.p_jcdqsj;
                parament[3].Value = struct_tzsb.p_mhqgs;
                parament[4].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Update_TZ_FHSB", parament, out result);
                int returnCode = Convert.ToInt32(parament[4].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============台站删除防火设备================
        protected void Delete_TZ_FHSB(int p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Int32),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Delete_TZ_FHSB", parament, out result);
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
        #endregion



        #region===============通过基本信息编号查找灭鼠措施情况================
        protected DataTable Select_MSCSByBh(string p_tzbh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_tzbh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = p_tzbh;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_KG_TZ.Select_MSCSByBh", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region  ===============台站添加灭鼠措施================
        protected void Insert_TZ_MSCS(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_tzbh",OracleType.VarChar),
                        new OracleParameter("p_dsb",OracleType.VarChar),
                        new OracleParameter("p_zsbgs",OracleType.VarChar),
                        new OracleParameter("p_qtcs",OracleType.VarChar),//其他措施
                        new OracleParameter ("p_fh",OracleType.VarChar),//防洪措施是否具备
                        new OracleParameter ("p_fd",OracleType.VarChar),//防盗措施是否具备
                        new OracleParameter ("p_wxgj",OracleType.VarChar),//维修工具是否满足该设备故障时紧急维修需求
                        new OracleParameter ("p_jfflcs",OracleType.VarChar),//机房防雷措施
                        new OracleParameter ("p_fljcdqrq",OracleType.VarChar),//防雷检测到期日期
                        new OracleParameter ("p_sfydn",OracleType.VarChar),//是否有地暖
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_tzbh;
                parament[2].Value = struct_tzsb.p_dsb;
                parament[3].Value = struct_tzsb.p_zsbgs;
                parament[4].Value = struct_tzsb.p_qtcs;
                parament[5].Value = struct_tzsb.p_fh;
                parament[6].Value = struct_tzsb.p_fd;
                parament[7].Value = struct_tzsb.p_wxgj;
                parament[8].Value = struct_tzsb.p_jfflcs;
                parament[9].Value = struct_tzsb.p_fljcdqrq;
                parament[10].Value = struct_tzsb.p_sfydn;
                parament[11].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Insert_TZ_MSCS", parament, out result);
                int returnCode = Convert.ToInt32(parament[11].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============台站编辑灭鼠措施================
        protected void Update_TZ_MSCS(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_dsb",OracleType.VarChar),
                        new OracleParameter("p_zsbgs",OracleType.VarChar),
                        new OracleParameter("p_qtcs",OracleType.VarChar),//其他措施
                        new OracleParameter ("p_fh",OracleType.VarChar),//防洪措施是否具备
                        new OracleParameter ("p_fd",OracleType.VarChar),//防盗措施是否具备
                        new OracleParameter ("p_wxgj",OracleType.VarChar),//维修工具是否满足该设备故障时紧急维修需求
                        new OracleParameter ("p_jfflcs",OracleType.VarChar),//机房防雷措施
                        new OracleParameter ("p_fljcdqrq",OracleType.DateTime),//防雷检测到期日期
                        new OracleParameter ("p_sfydn",OracleType.VarChar),//是否有地暖
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_dsb;
                parament[2].Value = struct_tzsb.p_zsbgs;
                parament[3].Value = struct_tzsb.p_qtcs;
                parament[4].Value = struct_tzsb.p_fh;
                parament[5].Value = struct_tzsb.p_fd;
                parament[6].Value = struct_tzsb.p_wxgj;
                parament[7].Value = struct_tzsb.p_jfflcs;
                parament[8].Value = struct_tzsb.p_fljcdqrq;
                parament[9].Value = struct_tzsb.p_sfydn;
                parament[10].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Update_TZ_MSCS", parament, out result);
                int returnCode = Convert.ToInt32(parament[10].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============台站删除灭鼠措施设备================
        protected void Delete_TZ_MSCS(int p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Int32),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Delete_TZ_MSCS", parament, out result);
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
        #endregion
#endregion

        #region===============通过ID查询基本信息详情================
        protected DataTable Select_TZ_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============通过ID查询空调信息详情================
        protected DataTable Select_TZ_KT_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_KT_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============通过ID查询防火设备信息详情================
        protected DataTable Select_TZ_FHSB_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_FHSB_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============通过ID查询加湿器信息详情================
        protected DataTable Select_TZ_JSQ_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_JSQ_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============通过ID查询灭鼠措施/其他措施信息详情================
        protected DataTable Select_TZ_MSCS_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_MSCS_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region ======================更新状态==========================
        //更新状态
        protected void Update_TZZT(Struct_TZSB struct_tzsb) {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Number),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_bhyy",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_id;
                parament[1].Value = struct_tzsb.p_zt;
                parament[2].Value = struct_tzsb.p_bhyy;
                parament[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Update_TZZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally {
                dbclass.Close();
            }
        }
        //变更数据标识
        protected void Update_TZ_SJBS_ZT(Struct_TZSB struct_tzsb) {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_shsj",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_tzsb.p_sjc;
                parament[1].Value = struct_tzsb.p_shsj;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Update_TZ_SJBS_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally {
                dbclass.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_TZ_SJBS_LSSJ_ZT(Struct_TZSB struct_tzsb) {
            DBClass dbclass = new DBClass();
            try { 
            OracleParameter[] parament = {
                new OracleParameter("p_sjc",OracleType.VarChar),
                new OracleParameter("p_errorCode",OracleType.Int32)
            };
            parament[0].Value = struct_tzsb.p_sjc;
            parament[1].Direction = ParameterDirection.Output;
            int rowsAffected = 0;
            dbclass.RunProcedure("PACK_KG_TZ.Update_TZ_SJBS_LSSJ_ZT", parament, out rowsAffected);
            int errorCode = 0;
            errorCode = Convert.ToInt32(parament[1].Value);
            if (errorCode != 0) {
                throw new EMException(errorCode);
            }
            rz = new RZ(_us);
            Struct_RZ_YH struct_rz = new Struct_RZ_YH();
            struct_rz.czfs = struct_tzsb.p_czfs;
            struct_rz.czxx = struct_tzsb.p_czxx;
            rz.RZ_Insert_CZ(struct_rz);
        }
        finally{
                dbclass.Close();
        }
}
        //将副本数据变为最终数据
        protected void Update_TZ_SJBS_FBSJ_ZT(Struct_TZSB struct_tzsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_tzsb.p_sjc;
                paras[1].Value = struct_tzsb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_TZ.Update_TZ_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_tzsb.p_czfs;
                struct_rz.czxx = struct_tzsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        //查出原始数据，备份数据
        protected int Struct_TZSB_SJBF(int id) {

            DataTable dt_detail = new DataTable();
            dt_detail = Select_TZ_Detail(id);
            Struct_TZSB tzsb_bf = new Struct_TZSB();

            //  struct_tzsb.p_tzbh = dt_detail.Rows[0]["jc"].ToString() + dt_detail.Rows[0]["wz"].ToString() + dt_detail.Rows[0]["sblx"].ToString();
            tzsb_bf.p_tzbh = dt_detail.Rows[0]["tzbh"].ToString();
            tzsb_bf.p_jc= dt_detail.Rows[0]["jc"].ToString();
            tzsb_bf.p_wz = dt_detail.Rows[0]["wz"].ToString();
            tzsb_bf.p_sblx = dt_detail.Rows[0]["sblx"].ToString();

            tzsb_bf.p_fwxx = dt_detail.Rows[0]["fwxx"].ToString();
            tzsb_bf.p_lc = dt_detail.Rows[0]["lc"].ToString();
            tzsb_bf.p_fjh = dt_detail.Rows[0]["fjh"].ToString();
            tzsb_bf.p_jg = dt_detail.Rows[0]["jg"].ToString();
            tzsb_bf.p_jgsj = Convert.ToDateTime(dt_detail.Rows[0]["jgsj"].ToString());
            tzsb_bf.p_tzwzxx = dt_detail.Rows[0]["tzwzxx"].ToString();
            tzsb_bf.p_jfsrxlqk = dt_detail.Rows[0]["jfsrxlqk"].ToString();
            tzsb_bf.p_jfzsc = dt_detail.Rows[0]["jfzsc"].ToString();
            tzsb_bf.p_jfzscdx = dt_detail.Rows[0]["jfzscdx"].ToString();
            tzsb_bf.p_jfzscsl = dt_detail.Rows[0]["jfzscsl"].ToString();
            // struct_tzsb.p_tzsbmcjxh = dt_detail.Rows[0]["tzsbmcjxh"].ToString();
            tzsb_bf.p_sc = dt_detail.Rows[0]["sc"].ToString();
            tzsb_bf.p_tzwdsfdb = dt_detail.Rows[0]["tzwdsfdb"].ToString();
            tzsb_bf.p_bdbyy = dt_detail.Rows[0]["bdbyy"].ToString();
            tzsb_bf.p_zt = "0";
            tzsb_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            tzsb_bf.p_sjbs = "2";
            tzsb_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            tzsb_bf.p_lrr = _us.userLoginName;
            tzsb_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            tzsb_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            tzsb_bf.p_tzmc = dt_detail.Rows[0]["tzmc"].ToString();
            // struct_tzsb.p_shsj = "";
            tzsb_bf.p_czfs = "02";
            tzsb_bf.p_czxx = "台站设备id:" + id + "生成副本数据";
            //插入
            Insert_TZ(tzsb_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = tzsb_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //数据导出
        protected DataTable Select_TZ_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_KG_TZ.Select_TZ_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion


        #region===============台站下设备清单查询================
        protected int Select_TXSBQD_Count(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_TXSBQD_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DHSBQD_Count(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_DHSBQD_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_QXSBQD_Count(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_QXSBQD_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JSSBQD_Count(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_TZ.Select_JSSBQD_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }


        protected DataSet Select_TXSBQD(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_TXSBQD", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_DHSBQD(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_DHSBQD", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_QXSBQD(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_QXSBQD", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JSSBQD(Struct_TZSB struct_tzsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_wz",OracleType.VarChar),
                    new OracleParameter("p_sblx",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_tzsb.p_jc;
                parament[1].Value = struct_tzsb.p_wz;
                parament[2].Value = struct_tzsb.p_sblx;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_TZ.Select_JSSBQD", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

    }
}



