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
    public struct Struct_HT
    {
        public string p_htmc;
        public string p_qdf;
        public DateTime p_qdrq;
        public DateTime p_qxkssj;
        public DateTime p_qxjssj;
        public string p_zt;
        public string p_fzr;
        public int p_pagesize;
        public int p_currentpage;
        public decimal p_ze;
        public string p_ztbz;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
        public string  p_id;
    }
        public class OHT
    {
        private UserState _us = null;
        private RZ rz = null;
        public OHT(UserState userstate)
        {
            _us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询
       
        protected DataTable Select_HT(Struct_HT struct_ht)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_htmc",OracleType.VarChar),
                                           new OracleParameter("p_qdf",OracleType.VarChar),
                                           new OracleParameter("p_qxkssj",OracleType.DateTime),
                                           new OracleParameter("p_qxjssj",OracleType.DateTime),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_fzr",OracleType.VarChar),
                                           new OracleParameter("p_pagesize",OracleType.Int32),
                                           new OracleParameter("p_currentpage",OracleType.Int32),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_ht.p_htmc;
                paras[1].Value = struct_ht.p_qdf;
                paras[2].Value = struct_ht.p_qxkssj;
                paras[3].Value =struct_ht.p_qxjssj; 
                paras[4].Value =struct_ht.p_zt; 
                paras[5].Value =struct_ht.p_fzr; 
                paras[6].Value =struct_ht.p_pagesize; 
                paras[7].Value =struct_ht.p_currentpage; 
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HTGL_HT.Select_HT", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_HTDetail(Struct_HT struct_ht)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_id",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_ht.p_id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HTGL_HT.Select_HTDetail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_HT_Count(Struct_HT struct_ht)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_htmc",OracleType.VarChar),
                                           new OracleParameter("p_qdf",OracleType.VarChar),
                                           new OracleParameter("p_qxkssj",OracleType.DateTime),
                                           new OracleParameter("p_qxjssj",OracleType.DateTime),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_fzr",OracleType.VarChar), 
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_ht.p_htmc;
                paras[1].Value = struct_ht.p_qdf;
                paras[2].Value = struct_ht.p_qxkssj;
                paras[3].Value = struct_ht.p_qxjssj;
                paras[4].Value = struct_ht.p_zt;
                paras[5].Value = struct_ht.p_fzr;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HTGL_HT.Select_HT_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 删除
      
        protected void Delete_HT(Struct_HT struct_ht)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                           new OracleParameter("p_id",OracleType.VarChar),
                                           new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = struct_ht.p_id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_HT.Delete_HT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ht.p_czfs;
                struct_rz.czxx = struct_ht.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  添加
      
        protected void Insert_HT(Struct_HT struct_ht)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_htmc",OracleType.VarChar),
                                           new OracleParameter("p_qdf",OracleType.VarChar),
                                           new OracleParameter("p_ze",OracleType.Number),
                                           new OracleParameter("p_qdrq",OracleType.DateTime),
                                           new OracleParameter("p_qxkssj",OracleType.DateTime),
                                           new OracleParameter("p_qxjssj",OracleType.DateTime),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_ztbz",OracleType.VarChar),
                                           new OracleParameter("p_fzr",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                            new OracleParameter("p_errorCode",OracleType.Int32)
             };
                paras[0].Value = struct_ht.p_htmc;
                paras[1].Value = struct_ht.p_qdf;
                paras[2].Value = struct_ht.p_ze;
                paras[3].Value = struct_ht.p_qdrq;
                paras[4].Value = struct_ht.p_qxkssj;
                paras[5].Value = struct_ht.p_qxjssj;
                paras[6].Value = struct_ht.p_zt;
                paras[7].Value = struct_ht.p_ztbz;
                paras[8].Value = struct_ht.p_fzr;
                paras[9].Value = struct_ht.p_bz;
                paras[10].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_HT.Insert_HT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[10].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ht.p_czfs;
                struct_rz.czxx = struct_ht.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑
      
        protected void Update_HT(Struct_HT struct_ht)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_id",OracleType.VarChar),
                                           new OracleParameter("p_htmc",OracleType.VarChar),
                                           new OracleParameter("p_qdf",OracleType.VarChar),
                                           new OracleParameter("p_ze",OracleType.Number),
                                           new OracleParameter("p_qdrq",OracleType.DateTime),
                                           new OracleParameter("p_qxkssj",OracleType.DateTime),
                                           new OracleParameter("p_qxjssj",OracleType.DateTime),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_ztbz",OracleType.VarChar),
                                           new OracleParameter("p_fzr",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                            new OracleParameter("p_errorCode",OracleType.Int32)
             };
                paras[0].Value = struct_ht.p_id;
                paras[1].Value = struct_ht.p_htmc;
                paras[2].Value = struct_ht.p_qdf;
                paras[3].Value = struct_ht.p_ze;
                paras[4].Value = struct_ht.p_qdrq;
                paras[5].Value = struct_ht.p_qxkssj;
                paras[6].Value = struct_ht.p_qxjssj;
                paras[7].Value = struct_ht.p_zt;
                paras[8].Value = struct_ht.p_ztbz;
                paras[9].Value = struct_ht.p_fzr;
                paras[10].Value= struct_ht.p_bz;
                paras[11].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_HT.Update_HT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[11].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ht.p_czfs;
                struct_rz.czxx = struct_ht.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region  刘燕龙  2017-7-3 20:48:46   合同的一个月到期提醒
        protected DataTable Select_HT_OutTime()
        {
            DBClass db = new DBClass();
            try {
                OracleParameter[] op = {new OracleParameter("p_cur",OracleType.Cursor) };
                op[0].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_HTGL_HT.Select_HT_OutTime", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        #endregion
    }
}
