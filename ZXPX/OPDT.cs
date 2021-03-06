﻿using Sys;
using System;
using System.Data;
using System.Data.OracleClient;

namespace CUST.MKG
{
    public struct Struct_PDT
    {
        public long p_id;
        public string p_tg;
        public string p_da;
        public string p_lj;
        public string p_sfytp;
        public string p_km;
        public string p_gw;
        public string p_nd;
        public string p_lb;
        public string p_kczsd;
        public string p_sfqy;
        public string p_lrr;
        public DateTime p_lrsj;
        public string p_shr;
        public string p_zt;
        public string p_yysm;
        public string p_czfs;
        public string p_czxx;
    }

    public class OPDT
    {
        private UserState _us = null;
        private RZ rz = null;
        public OPDT(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }


        #region 查询判断题


        /// <summary>
        /// 查询判断题表信息
        /// </summary>
        /// <param name="pdt"></param>
        /// <returns></returns>
        protected DataTable Select_PDT_Pro(Struct_Select_ST pdt)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_pagesize",OracleType.Int32),
                  new OracleParameter("p_currentpage",OracleType.Int32),
                  new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = pdt.p_tg;
                paras[1].Value = pdt.p_km;
                paras[2].Value = pdt.p_gw;
                paras[3].Value = pdt.p_nd;
                paras[4].Value = pdt.p_lb;
                paras[5].Value = pdt.p_zt;
                paras[6].Value = pdt.p_pagesize;
                paras[7].Value = pdt.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_PDT.Select_PDT_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询判断题数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_PDT_Count(Struct_Select_ST pdt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = pdt.p_tg;
                paras[1].Value = pdt.p_km;
                paras[2].Value = pdt.p_gw;
                paras[3].Value = pdt.p_nd;
                paras[4].Value = pdt.p_lb;
                paras[5].Value = pdt.p_zt;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_ZXPX_PDT.Select_PDT_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 查询判断题详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_PDT_Detail(long id)
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
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_PDT.Select_PDT_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 删除


        /// <summary>
        /// 删除判断题表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_PDT_byID(long id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_id",OracleType.Number),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_PDT.Delete_PDT_byID", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = p_czfs;
                struct_rz.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  添加
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pdt"></param>
        protected void Insert_PDT(Struct_PDT pdt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_da",OracleType.VarChar),
                  new OracleParameter("p_lj",OracleType.VarChar),
                  new OracleParameter("p_sfytp",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_kczsd",OracleType.VarChar),
                  new OracleParameter("p_sfqy",OracleType.VarChar),
                  new OracleParameter("p_lrr",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = pdt.p_tg;
                paras[1].Value = pdt.p_da;
                paras[2].Value = pdt.p_lj;
                paras[3].Value = pdt.p_sfytp;
                paras[4].Value = pdt.p_km;
                paras[5].Value = pdt.p_gw;
                paras[6].Value = pdt.p_nd;
                paras[7].Value = pdt.p_lb;
                paras[8].Value = pdt.p_kczsd;
                paras[9].Value = "1";//启用
                paras[10].Value = _us.userLoginName;
                paras[11].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_PDT.Insert_PDT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[11].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pdt.p_czfs;
                struct_rz.czxx = pdt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pdt"></param>
        protected void Update_PDT(Struct_PDT pdt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                 new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_da",OracleType.VarChar),
                  new OracleParameter("p_lj",OracleType.VarChar),
                  new OracleParameter("p_sfytp",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_kczsd",OracleType.VarChar),
                  new OracleParameter("p_sfqy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = pdt.p_id;
                paras[1].Value = pdt.p_tg;
                paras[2].Value = pdt.p_da;
                paras[3].Value = pdt.p_lj;
                paras[4].Value = pdt.p_sfytp;
                paras[5].Value = pdt.p_km;
                paras[6].Value = pdt.p_gw;
                paras[7].Value = pdt.p_nd;
                paras[8].Value = pdt.p_lb;
                paras[9].Value = pdt.p_kczsd;
                paras[10].Value = pdt.p_sfqy;
                paras[11].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_PDT.Update_PDT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[11].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pdt.p_czfs;
                struct_rz.czxx = pdt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="pdt"></param>
        protected void Update_PDT_TJ(Struct_SH pdt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_shr",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = pdt.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = pdt.p_zt;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_PDT.Update_PDT_TJ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pdt.p_czfs;
                struct_rz.czxx = pdt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="pdt"></param>
        protected void Update_PDT_SHTG(Struct_SH pdt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_shr",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = pdt.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = pdt.p_zt;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_PDT.Update_PDT_SHTG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pdt.p_czfs;
                struct_rz.czxx = pdt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="pdt"></param>
        protected void Update_PDT_BH(Struct_SH pdt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_shr",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_yysm",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = pdt.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = pdt.p_zt;
                paras[3].Value = pdt.p_yysm;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_PDT.Update_PDT_BH", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[4].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pdt.p_czfs;
                struct_rz.czxx = pdt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

    }
}
