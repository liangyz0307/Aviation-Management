using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CUST.Sys;
using Sys;


namespace CUST.MKG
{
    public class OBSTJ
    {
        private UserState _us = null;
        private RZ rz = null;
        public OBSTJ(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 特情处置
        /// <summary>
        /// 查询特情处置情况
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_TQCZQK_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Value = bslx;
                paras[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_TQCZ.Select_TQCZ_byBSLX", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 工作进展
        /// <summary>
        /// 查询工作进展情况
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_GZJZ_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Value = bslx;
                paras[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_GZJZ.Select_GZJZ_byBSLX", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 重点工作
        /// <summary>
        /// 查询重点工作情况
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_ZDGZ_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Value = bslx;
                paras[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_ZDGZ.Select_ZDGZ_byBSLX", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 航班运行
        /// <summary>
        /// 查询航班正常架次
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_HBYXJC_CountZC(DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_HBYX.Select_HBYXJC_CountZC", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询航班异常架次
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_HBYXJC_CountYC(DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_HBYX.Select_HBYXJC_CountYC", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询航班异常原因和气象情况
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_HBYXYCYYandQXQK(DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_HBYX.Select_HBYXYCYYandQXQK", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询上报日期
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_BSRQMax(DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_HBYX.Select_BSRQMax", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 风险源分析
        /// <summary>
        /// 查询风险源报送信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_FXY_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Value = bslx;
                paras[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_FXY.Select_FXY_byBSLX", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 设备保障情况
        /// <summary>
        /// 查询气象设备保障情况
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_QXSBBZQK(DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_TJ_HWYXXX.Select_QXSBBZQK", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询导航设备保障情况
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_DHSBBZQK(DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_TJ_HWYXXX.Select_DHSBBZQK", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询通信设备保障情况
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_TXSBBZQK(DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = kssj;
                paras[1].Value = jssj;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_TJ_HWYXXX.Select_TXSBBZQK", paras, "tables");
                return ds.Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
    }
}
