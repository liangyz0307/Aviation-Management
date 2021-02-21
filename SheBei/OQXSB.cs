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
    public struct Struct_QXSB
    {
        public string p_id;
        public string p_sbbh;
        public string p_sbmc;
        public string p_xh;
        public string p_zzcj;
        public string p_ccbh;
        public string p_tcrq;
        public string p_jgrq;
        public string p_qysj;
        public string p_yxqk;
        public string p_sbzt;
        public string p_sbyt;
        public string p_sszx;
        public string p_azwz;
        public string p_jdrq;
        public string p_jdyxq;
        public string p_jdzsbh;
        public string p_sccgqjdzs;
        public string p_jdys;
        public string p_jdfs;
        public string p_jddw;
        public string p_jdjl;
        public string p_fljcrq;
        public string p_fljcyxq;
        public string p_dzscz;
        public string p_sbgzll;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
        public int p_currentpage;
        public int p_pagesize;
        public DateTime p_scsj;
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
       public string p_zt;
        public string p_bhyy;
        public string p_bmdm;

        public string p_wz;
        public string p_sblx;


    }
    public class OQXSB
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private RZ rz;
        private UserState _us = null;
        public OQXSB(UserState state)
        {
            _us = state;
            rz = new RZ(_us);
        }
        #region  ===============气象设备================
        #region  ===============查询================
        protected DataSet Select_QXSB(Struct_QXSB struct_qxsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament =
                {
                        new OracleParameter("p_ccbh",OracleType.VarChar),                      
                        new OracleParameter("p_yxqk",OracleType.VarChar),
                        new OracleParameter("p_sbzt",OracleType.VarChar),
                        new OracleParameter("p_sbyt",OracleType.VarChar),
                        new OracleParameter("p_sszx",OracleType.VarChar),
                        new OracleParameter("p_jdfs",OracleType.VarChar),
                        new OracleParameter("p_pagesize",OracleType.Int32),
                        new OracleParameter("p_currentpage",OracleType.Int32),
                        new OracleParameter("p_zt",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
            };
                parament[0].Value = struct_qxsb.p_ccbh;             
                parament[1].Value = struct_qxsb.p_yxqk;
                parament[2].Value = struct_qxsb.p_sbzt;
                parament[3].Value = struct_qxsb.p_sbyt;
                parament[4].Value = struct_qxsb.p_sszx;
                parament[5].Value = struct_qxsb.p_jdfs;
                parament[6].Value = struct_qxsb.p_pagesize;
                parament[7].Value = struct_qxsb.p_currentpage;
                parament[8].Value = struct_qxsb.p_zt;
                parament[9].Value = struct_qxsb.p_userid;
                parament[10].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_QXSB.Select_QXSB", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============添加================
        protected void Insert_QXSB(Struct_QXSB struct_qxsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbmc",OracleType.VarChar),
                                               new OracleParameter("p_xh",OracleType.VarChar),
                                               new OracleParameter("p_zzcj",OracleType.VarChar),
                                               new OracleParameter("p_ccbh",OracleType.VarChar),
                                               new OracleParameter("p_tcrq",OracleType.VarChar),
                                               new OracleParameter("p_jgrq",OracleType.VarChar),
                                               new OracleParameter("p_qysj",OracleType.VarChar),
                                               new OracleParameter("p_yxqk",OracleType.VarChar),
                                               new OracleParameter("p_sbzt",OracleType.VarChar),
                                               new OracleParameter("p_sbyt",OracleType.VarChar),
                                               new OracleParameter("p_sszx",OracleType.VarChar),
                                               new OracleParameter("p_azwz",OracleType.VarChar),
                                               new OracleParameter("p_jdrq",OracleType.VarChar),
                                               new OracleParameter("p_jdyxq",OracleType.VarChar),
                                               new OracleParameter("p_jdzsbh",OracleType.VarChar),
                                               new OracleParameter("p_sccgqjdzs",OracleType.VarChar),
                                               new OracleParameter("p_jdys",OracleType.VarChar),
                                               new OracleParameter("p_jdfs",OracleType.VarChar),
                                               new OracleParameter("p_jddw",OracleType.VarChar),
                                               new OracleParameter("p_jdjl",OracleType.VarChar),
                                               new OracleParameter("p_fljcrq",OracleType.VarChar),
                                               new OracleParameter("p_fljcyxq",OracleType.VarChar),
                                               new OracleParameter("p_dzscz",OracleType.VarChar),
                                               new OracleParameter("p_sbgzll",OracleType.VarChar),
                                               new OracleParameter("p_bz",OracleType.VarChar),
                                                new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_sbbh",OracleType.VarChar),

                                                new OracleParameter("p_wz",OracleType.VarChar),
                                                 new OracleParameter("p_sblx",OracleType.VarChar),

                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parament[0].Value = struct_qxsb.p_sbmc;
                parament[1].Value = struct_qxsb.p_xh;
                parament[2].Value = struct_qxsb.p_zzcj;
                parament[3].Value = struct_qxsb.p_ccbh;
                parament[4].Value = struct_qxsb.p_tcrq;
                parament[5].Value = struct_qxsb.p_jgrq;
                parament[6].Value = struct_qxsb.p_qysj;
                parament[7].Value = struct_qxsb.p_yxqk;
                parament[8].Value = struct_qxsb.p_sbzt;
                parament[9].Value = struct_qxsb.p_sbyt;
                parament[10].Value = struct_qxsb.p_sszx;
                parament[11].Value = struct_qxsb.p_azwz;
                parament[12].Value = struct_qxsb.p_jdrq;
                parament[13].Value = struct_qxsb.p_jdyxq;
                parament[14].Value = struct_qxsb.p_jdzsbh;
                parament[15].Value = struct_qxsb.p_sccgqjdzs;
                parament[16].Value = struct_qxsb.p_jdys;
                parament[17].Value = struct_qxsb.p_jdfs;
                parament[18].Value = struct_qxsb.p_jddw;
                parament[19].Value = struct_qxsb.p_jdjl;
                parament[20].Value = struct_qxsb.p_fljcrq;
                parament[21].Value = struct_qxsb.p_fljcyxq;
                parament[22].Value = struct_qxsb.p_dzscz;
                parament[23].Value = struct_qxsb.p_sbgzll;
                parament[24].Value = struct_qxsb.p_bz;
                parament[25].Value = struct_qxsb.p_bmdm;
                parament[26].Value = struct_qxsb.p_csr;
                parament[27].Value = struct_qxsb.p_zsr;
                parament[28].Value = struct_qxsb.p_lrr;
                parament[29].Value = struct_qxsb.p_sjc;
                parament[30].Value = struct_qxsb.p_sjbs;
                parament[31].Value = struct_qxsb.p_zt;
                parament[32].Value = struct_qxsb.p_sbbh;

                parament[33].Value = struct_qxsb.p_wz;
                parament[34].Value = struct_qxsb.p_sblx;

                parament[35].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_QXSB.Insert_QXSB", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[35].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_qxsb.p_czfs;
                struct_RZ_YH.czxx = struct_qxsb.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);

            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============编辑================
        protected void Update_QXSB(Struct_QXSB struct_qxsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbmc",OracleType.VarChar),
                                               new OracleParameter("p_xh",OracleType.VarChar),
                                               new OracleParameter("p_zzcj",OracleType.VarChar),
                                               new OracleParameter("p_ccbh",OracleType.VarChar),
                                               new OracleParameter("p_tcrq",OracleType.VarChar),
                                               new OracleParameter("p_jgrq",OracleType.VarChar),
                                               new OracleParameter("p_qysj",OracleType.VarChar),
                                               new OracleParameter("p_yxqk",OracleType.VarChar),
                                               new OracleParameter("p_sbzt",OracleType.VarChar),
                                               new OracleParameter("p_sbyt",OracleType.VarChar),
                                               new OracleParameter("p_azwz",OracleType.VarChar),
                                               new OracleParameter("p_jdrq",OracleType.VarChar),
                                               new OracleParameter("p_jdyxq",OracleType.VarChar),
                                               new OracleParameter("p_jdzsbh",OracleType.VarChar),
                                               new OracleParameter("p_sccgqjdzs",OracleType.VarChar),
                                               new OracleParameter("p_jdys",OracleType.VarChar),
                                               new OracleParameter("p_jdfs",OracleType.VarChar),
                                               new OracleParameter("p_jddw",OracleType.VarChar),
                                               new OracleParameter("p_jdjl",OracleType.VarChar),
                                               new OracleParameter("p_fljcrq",OracleType.VarChar),
                                               new OracleParameter("p_fljcyxq",OracleType.VarChar),
                                               new OracleParameter("p_dzscz",OracleType.VarChar),
                                               new OracleParameter("p_sbgzll",OracleType.VarChar),
                                               new OracleParameter("p_bz",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                  new OracleParameter("p_id",OracleType.VarChar),
                                                  new OracleParameter("p_sszx",OracleType.VarChar),

                                                  new OracleParameter("p_wz",OracleType.VarChar),
                                                  new OracleParameter("p_sblx",OracleType.VarChar),

                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parament[0].Value = struct_qxsb.p_sbmc;
                parament[1].Value = struct_qxsb.p_xh;
                parament[2].Value = struct_qxsb.p_zzcj;
                parament[3].Value = struct_qxsb.p_ccbh;
                parament[4].Value = struct_qxsb.p_tcrq;
                parament[5].Value = struct_qxsb.p_jgrq;
                parament[6].Value = struct_qxsb.p_qysj;
                parament[7].Value = struct_qxsb.p_yxqk;
                parament[8].Value = struct_qxsb.p_sbzt;
                parament[9].Value = struct_qxsb.p_sbyt;
                parament[10].Value = struct_qxsb.p_azwz;
                parament[11].Value = struct_qxsb.p_jdrq;
                parament[12].Value = struct_qxsb.p_jdyxq;
                parament[13].Value = struct_qxsb.p_jdzsbh;
                parament[14].Value = struct_qxsb.p_sccgqjdzs;
                parament[15].Value = struct_qxsb.p_jdys;
                parament[16].Value = struct_qxsb.p_jdfs;
                parament[17].Value = struct_qxsb.p_jddw;
                parament[18].Value = struct_qxsb.p_jdjl;
                parament[19].Value = struct_qxsb.p_fljcrq;
                parament[20].Value = struct_qxsb.p_fljcyxq;
                parament[21].Value = struct_qxsb.p_dzscz;
                parament[22].Value = struct_qxsb.p_sbgzll;
                parament[23].Value = struct_qxsb.p_bz;
                parament[24].Value = struct_qxsb.p_bmdm;
                parament[25].Value = struct_qxsb.p_csr;
                parament[26].Value = struct_qxsb.p_zsr;
                parament[27].Value = struct_qxsb.p_lrr;
                parament[28].Value = struct_qxsb.p_zt;
                parament[29].Value = struct_qxsb.p_sjbs;
                parament[30].Value = struct_qxsb.p_id;
                parament[31].Value = struct_qxsb.p_sszx;

                parament[32].Value = struct_qxsb.p_wz;
                parament[33].Value = struct_qxsb.p_sblx;

                parament[34].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_QXSB.Update_QXSB", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[34].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_qxsb.p_czfs;
                struct_RZ_YH.czxx = struct_qxsb.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);

            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============删除================
        protected void Delete_QXSB(string p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_id; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_QXSB.Delete_QXSB", parament, out reslut);

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
        #region  ===============Count================
        protected int Select_QXSB_Count(Struct_QXSB struct_qxsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ccbh",OracleType.VarChar),
                                              
                                               new OracleParameter("p_yxqk",OracleType.VarChar),
                                               new OracleParameter("p_sbzt",OracleType.VarChar),
                                               new OracleParameter("p_sbyt",OracleType.VarChar),
                                               new OracleParameter("p_sszx",OracleType.VarChar),
                                               new OracleParameter("p_jdfs",OracleType.VarChar),
                                                new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_qxsb.p_ccbh;            
                parament[1].Value = struct_qxsb.p_yxqk;
                parament[2].Value = struct_qxsb.p_sbzt;
                parament[3].Value = struct_qxsb.p_sbyt;
                parament[4].Value = struct_qxsb.p_sszx;
                parament[5].Value = struct_qxsb.p_jdfs;
                parament[6].Value = struct_qxsb.p_zt;
                parament[7].Value = struct_qxsb.p_userid;
                parament[8].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_QXSB.Select_QXSB_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============气象管理设备编号================
        protected DataSet Select_QXSBbySBBH(string id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_QXSB.Select_QXSBbySBBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============气象管理设备最大编号================
        protected DataSet Select_Max_qxsbbh(string bm_sblx)
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
                ds = dbclass.RunProcedure("PACK_SBGL_SB.Select_Max_qxsbbh", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 权限
        #region 更新状态
        protected void Update_QXSBZT(Struct_QXSB struct_qxsb)
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
                paras[0].Value = struct_qxsb.p_id;
                paras[1].Value = struct_qxsb.p_zt;
                paras[2].Value = struct_qxsb.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_QXSB.Update_QXSBZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_qxsb.p_czfs;
                struct_rz.czxx = struct_qxsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #region
        //变更数据标识
        protected void Update_QXSB_SJBS_ZT(Struct_QXSB struct_qxsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_qxsb.p_sjc;
                paras[1].Value = struct_qxsb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_QXSB.Update_QXSB_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_qxsb.p_czfs;
                struct_rz.czxx = struct_qxsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_QXSB_SJBS_LSSJ_ZT(Struct_QXSB struct_qxsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_qxsb.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_QXSB.Update_QXSB_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_qxsb.p_czfs;
                struct_rz.czxx = struct_qxsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        #region 将副本数据变为最终数据
        protected void Update_QXSB_SJBS_FBSJ_ZT(Struct_QXSB struct_qxsb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_qxsb.p_sjc;
                paras[1].Value = struct_qxsb.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_QXSB.Update_QXSB_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_qxsb.p_czfs;
                struct_rz.czxx = struct_qxsb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected int QXSB_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_QXSBbySBBH(Convert.ToString(id)).Tables[0];
            //备份数据
            Struct_QXSB qxsb_bf = new Struct_QXSB();
            qxsb_bf.p_sbbh = dt_detail.Rows[0]["sbbh"].ToString();
            qxsb_bf.p_sbmc = dt_detail.Rows[0]["sbmc"].ToString();
            qxsb_bf.p_xh = dt_detail.Rows[0]["xh"].ToString();
            qxsb_bf.p_zzcj = dt_detail.Rows[0]["zzcj"].ToString();
            qxsb_bf.p_ccbh = dt_detail.Rows[0]["ccbh"].ToString();
            qxsb_bf.p_tcrq = dt_detail.Rows[0]["tcrq"].ToString();
            qxsb_bf.p_jgrq = dt_detail.Rows[0]["jgrq"].ToString();
            qxsb_bf.p_qysj = dt_detail.Rows[0]["qysj"].ToString();
            qxsb_bf.p_yxqk = dt_detail.Rows[0]["yxqk"].ToString();
            qxsb_bf.p_sbzt = dt_detail.Rows[0]["sbzt"].ToString();
            qxsb_bf.p_sbyt = dt_detail.Rows[0]["sbyt"].ToString();
            qxsb_bf.p_sszx = dt_detail.Rows[0]["sszx"].ToString();
            qxsb_bf.p_azwz = dt_detail.Rows[0]["azwz"].ToString();
            qxsb_bf.p_jdrq = dt_detail.Rows[0]["jdrq"].ToString();
            qxsb_bf.p_jdyxq = dt_detail.Rows[0]["jdyxq"].ToString();
            qxsb_bf.p_jdzsbh = dt_detail.Rows[0]["jdzsbh"].ToString();
            qxsb_bf.p_sccgqjdzs = dt_detail.Rows[0]["sccgqjdzs"].ToString();
            qxsb_bf.p_jdys = dt_detail.Rows[0]["jdys"].ToString();
            qxsb_bf.p_jdfs = dt_detail.Rows[0]["jdfs"].ToString();
            qxsb_bf.p_jddw = dt_detail.Rows[0]["jddw"].ToString();
            qxsb_bf.p_jdjl = dt_detail.Rows[0]["jdjl"].ToString();
            qxsb_bf.p_fljcrq = dt_detail.Rows[0]["fljcrq"].ToString();
            qxsb_bf.p_fljcyxq = dt_detail.Rows[0]["fljcyxq"].ToString();
            qxsb_bf.p_dzscz = dt_detail.Rows[0]["dzscz"].ToString();
            qxsb_bf.p_sbgzll = dt_detail.Rows[0]["sbgzll"].ToString();
            qxsb_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();


            qxsb_bf.p_wz = dt_detail.Rows[0]["wz"].ToString();
            qxsb_bf.p_sblx = dt_detail.Rows[0]["sblx"].ToString();


            qxsb_bf.p_zt = "0";
            qxsb_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            qxsb_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            qxsb_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            qxsb_bf.p_lrr = _us.userLoginName;
            qxsb_bf.p_sjbs = "2";
            qxsb_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            qxsb_bf.p_shsj = "";
            qxsb_bf.p_czfs = "02";
            qxsb_bf.p_czxx = "员工奖励id:" + id + "生成副本数据";
            //插入
            Insert_QXSB(qxsb_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = qxsb_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_QXSB.Select_QXSB_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
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
                string count = dbclass.RunProcedure("PACK_KG_QXSB.Select_SB_MaxNumber", parament, "table").Tables[0].Rows[0][0].ToString();
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
        protected DataTable Select_QXSB_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_KG_QXSB.Select_QXSB_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

    }
}
//protected DataSet Select_Max_qxsbbh(string bm_sblx)
//{
//    DBClass dbclass = new DBClass();
//    try
//    {
//        OracleParameter[] parament ={

//                                       new OracleParameter("p_bm",OracleType.VarChar),
//                                       new OracleParameter("p_cur",OracleType.Cursor)
//                                    };
//        parament[0].Value = bm_sblx;
//        parament[1].Direction = ParameterDirection.Output;
//        DataSet ds = new DataSet();
//        ds = dbclass.RunProcedure("PACK_SBGL_SB.Select_Max_qxsbbh", parament, "table");
//        return ds;
//    }
//    finally
//    {
//        dbclass.Close();
//    }
#endregion