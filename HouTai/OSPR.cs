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
    public struct Struct_SPR
    {
        public string p_zxtdm;
        public string p_spr;
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
        public string p_id;
        public string p_bh;
        public string p_gwdm;
        public string p_bmdm;

    }
    public class OSPR
    {
        private UserState _us = null;
        private RZ rz = null;
        public OSPR(UserState userstate)
        {
            _us = userstate;
            rz = new RZ(userstate);
        }

        protected DataTable Select_SPR(Struct_SPR struct_spr)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_zxtdm",OracleType.VarChar),
                                           new OracleParameter("p_pagesize",OracleType.Int32),
                                           new OracleParameter("p_currentpage",OracleType.Int32),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_spr.p_zxtdm;
                paras[1].Value = struct_spr.p_pagesize;
                paras[2].Value = struct_spr.p_currentpage;
                paras[3].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HTGL_SPR.Select_SPR", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_SPR_Count(Struct_SPR struct_spr)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_zxtdm",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_spr.p_zxtdm;
                paras[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HTGL_SPR.Select_SPR_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
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
                dt = db.RunProcedure("PACK_HTGL_SPR.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        protected DataTable Select_YGbyBMGW(string p_bmdm, string p_gwdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_bmdm;
                paras[1].Value = p_gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_HTGL_SPR.Select_YGbyBMGW", paras, "tables").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        protected void Insert_SPR(Struct_SPR struct_spr)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_zxtdm",OracleType.VarChar),
                                           new OracleParameter("p_spr",OracleType.VarChar),
                                            new OracleParameter("p_errorCode",OracleType.Int32)
             };
                paras[0].Value = struct_spr.p_zxtdm;
                paras[1].Value = struct_spr.p_spr;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_SPR.Insert_SPR", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_spr.p_czfs;
                struct_rz.czxx = struct_spr.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected void Delete_SPR(Struct_SPR struct_spr)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                           new OracleParameter("p_id",OracleType.VarChar),
                                           new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = struct_spr.p_id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_SPR.Delete_SPR", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_spr.p_czfs;
                struct_rz.czxx = struct_spr.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
    }
}
