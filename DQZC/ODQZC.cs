using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CUST.Sys;
using CUST;
using Sys;
using System.Data.OracleClient;
using CUST.MKG;

namespace CUST.MKG
{
    public class ODQZC
    {
        private UserState _us = null;
        private RZ rz = null;
        public struct Struct_DY
        {
            public string p_sfzh;
            public string p_xm;
            public string p_xb;
            public string p_xl;
            public string p_dnzw;
            public string p_ygxs;
            public DateTime p_rdsj;
            public int p_currentpage;
            public int p_pagesize;
            public string p_czfs;
            public string p_czxx;
            public string p_bz;
            public string p_jcdzbmc;
            public string p_dxzmc;
            public string p_bh;
            public string p_dzzmc;
            public string p_zzmm;
            public string p_zt;
            public string p_bmdm;
        }
        public ODQZC(UserState userstate)
        {
            _us = userstate;
            rz = new RZ(_us);
        }
        #region 查询

        protected DataTable Select_DY(Struct_DY struct_dy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_xm",OracleType.VarChar),
                                           new OracleParameter("p_sfzh",OracleType.VarChar),
                                           new OracleParameter("p_dnzw",OracleType.VarChar),
                                           new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                           new OracleParameter("p_dxzmc",OracleType.VarChar),
                                           new OracleParameter("p_pagesize",OracleType.Int32),
                                           new OracleParameter("p_currentpage",OracleType.Int32),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_dy.p_xm;
                paras[1].Value = struct_dy.p_sfzh;
                paras[2].Value = struct_dy.p_dnzw;
                paras[3].Value = struct_dy.p_jcdzbmc;
                paras[4].Value = struct_dy.p_dxzmc;
                paras[5].Value = struct_dy.p_pagesize;
                paras[6].Value = struct_dy.p_currentpage;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_DQZC.Select_DY", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Detail_DY(Struct_DY struct_dy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bh",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor),
                                              };
                paras[0].Value = struct_dy.p_bh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_DQZC.Detail_DY", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DYCount(Struct_DY struct_dy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_xm",OracleType.VarChar),
                                           new OracleParameter("p_sfzh",OracleType.VarChar),                                         
                                           new OracleParameter("p_dnzw",OracleType.VarChar),                                         
                                           new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                           new OracleParameter("p_dxzmc",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_dy.p_xm;
                paras[1].Value = struct_dy.p_sfzh;
                paras[2].Value = struct_dy.p_dnzw;
                paras[3].Value = struct_dy.p_jcdzbmc;
                paras[4].Value = struct_dy.p_dxzmc;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC.Select_DYCount", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 删除

        protected void Delete_DY(Struct_DY struct_dy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                           new OracleParameter("p_bh",OracleType.VarChar),
                                           new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = struct_dy.p_bh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_DQZC.Delete_DY", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_dy.p_czfs;
                struct_rz.czxx = struct_dy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  添加

        protected void Insert_DY(Struct_DY struct_dy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                    
                                           new OracleParameter("p_bh",OracleType.VarChar),
                                           new OracleParameter("p_dnzw",OracleType.VarChar),
                                           new OracleParameter("p_dxzmc",OracleType.VarChar),
                                           new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                           new OracleParameter("p_dzzmc",OracleType.VarChar),
                                           new OracleParameter("p_ygxs",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                           new OracleParameter("p_rdsj",OracleType.DateTime),
                                            new OracleParameter("p_zzmm",OracleType.VarChar),
                                           
                                           new OracleParameter("p_errorCode",OracleType.Int32)
             };
                paras[0].Value = struct_dy.p_bh;
                paras[1].Value = struct_dy.p_dnzw;
                paras[2].Value = struct_dy.p_dxzmc;
                paras[3].Value = struct_dy.p_jcdzbmc;
                paras[4].Value = struct_dy.p_dzzmc;
                paras[5].Value = struct_dy.p_ygxs;
                paras[6].Value = struct_dy.p_bz;
                paras[7].Value = struct_dy.p_rdsj;
                paras[8].Value = struct_dy.p_zzmm;
                paras[9].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_DQZC.Insert_DY", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[9].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_dy.p_czfs;
                struct_rz.czxx = struct_dy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑

        protected void Update_DY(Struct_DY struct_dy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bh",OracleType.VarChar),
                                           new OracleParameter("p_dnzw",OracleType.VarChar),
                                           new OracleParameter("p_dxzmc",OracleType.VarChar),
                                           new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                           new OracleParameter("p_dzzmc",OracleType.VarChar),
                                           new OracleParameter("p_ygxs",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                           new OracleParameter("p_rdsj",OracleType.DateTime),
                                           new OracleParameter("p_zzmm",OracleType.VarChar),
                                           new OracleParameter("p_errorCode",OracleType.Int32)
             };
                paras[0].Value = struct_dy.p_bh;
                paras[1].Value = struct_dy.p_dnzw;
                paras[2].Value = struct_dy.p_dxzmc;
                paras[3].Value = struct_dy.p_jcdzbmc;
                paras[4].Value = struct_dy.p_dzzmc;
                paras[5].Value = struct_dy.p_ygxs;
                paras[6].Value = struct_dy.p_bz;
                paras[7].Value = struct_dy.p_rdsj;
                paras[8].Value = struct_dy.p_zzmm;
                paras[9].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_DQZC.Update_DY", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[9].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_dy.p_czfs;
                struct_rz.czxx = struct_dy.p_czxx;
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
