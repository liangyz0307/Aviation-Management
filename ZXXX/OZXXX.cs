﻿using CUST;
using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_ZXXX
    {
        public string id;
        public DateTime kssj;//开始时间
        public DateTime jssj;//结束时间
        public DateTime scsj;//上传时间
        public string wjm;//文件名
        public string bmdm;//上传部门
        public string scr;//上传人
        public string scip;//上传IP
        public string sclj;//上传路径
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_ZXXX
    {
        public int id;
        public DateTime kssj;//上传开始时间
        public DateTime jssj;//上传结束时间
        public string bmdm;//上传部门代码
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OZXXX
    {
        private UserState _us = null;
        private RZ rz = null;
        public OZXXX(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region  张先震   支部建设的查询、增加、删除
        protected DataSet Select_ZXXX_WJ(Struct_ZXXX struct_zxxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                    new OracleParameter("p_wjm",OracleType.VarChar),
                                                    new OracleParameter("p_kssj",OracleType.DateTime),
                                                    new OracleParameter("p_jssj",OracleType.DateTime),
                                                    new OracleParameter("p_bmdm",OracleType.VarChar),
                                                    new OracleParameter("p_pagesize",OracleType.Int32),
                                                    new OracleParameter("p_currentpage",OracleType.Int32),                                                    
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_zxxx.wjm;
                parament[1].Value = struct_zxxx.kssj;
                parament[2].Value = struct_zxxx.jssj;
                parament[3].Value = struct_zxxx.bmdm;
                parament[4].Value = struct_zxxx.p_pagesize;
                parament[5].Value = struct_zxxx.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_ZXXX_WJ.Select_ZXXX_WJ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_ZXXX_WJ_Count(Struct_ZXXX struct_zxxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                    new OracleParameter("p_wjm",OracleType.VarChar),
                                                    new OracleParameter("p_kssj",OracleType.DateTime),
                                                    new OracleParameter("p_jssj",OracleType.DateTime),
                                                    new OracleParameter("p_bmdm",OracleType.VarChar),
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_zxxx.wjm;
                parament[1].Value = struct_zxxx.kssj;
                parament[2].Value = struct_zxxx.jssj;
                parament[3].Value = struct_zxxx.bmdm;                
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_ZXXX_WJ.Select_ZXXX_WJ_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        protected void Insert_ZXXX_WJ(Struct_ZXXX struct_zxxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.VarChar),                                               
                                                 new OracleParameter("p_wjm",OracleType.VarChar),
                                                 new OracleParameter("p_scsj",OracleType.DateTime),
                                                 new OracleParameter("p_scr",OracleType.VarChar),
                                                 new OracleParameter("p_scip",OracleType.VarChar),
                                                 new OracleParameter("p_sclj",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };

                parament[0].Value = struct_zxxx.id;
                parament[1].Value = struct_zxxx.wjm;
                parament[2].Value = struct_zxxx.scsj;
                parament[3].Value = struct_zxxx.scr;
                parament[4].Value = struct_zxxx.scip;
                parament[5].Value = struct_zxxx.sclj;
                parament[6].Value = struct_zxxx.bmdm;
                parament[7].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_ZXXX_WJ.Insert_ZXXX_WJ", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[7].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_ZXXX_WJ(string id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parameter ={
                                                new OracleParameter("p_id",OracleType.VarChar),
                                                new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parameter[0].Value = id;
                parameter[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_ZXXX_WJ.Delete_ZXXX_WJ", parameter, out reslut);
                int returnCode = Convert.ToInt32(parameter[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion      
        protected string SelectWDBH(string id)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                              new OracleParameter("p_maxbh",OracleType.VarChar,10)
                                          };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_ZXXX_WJ.Select_ZXXX_WJMaxBH", paras, "dt");
                string maxbh = paras[0].Value.ToString();
                return id + maxbh;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
