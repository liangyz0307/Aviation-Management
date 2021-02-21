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
    public class ODYZX
    {
        private UserState _us = null;
        private RZ rz = null;
        public struct Struct_DYZX
        {
            public long p_id;
            public string p_bh;
            public string p_xm;
            public string p_zysj;
            public string p_jcdzbmc;
            public string p_dxzmc;
            public DateTime p_kssj;
            public DateTime p_jssj;
            public DateTime p_sj;
            public string p_bmdm;
            public string p_gwdm;
            public string p_czfs;
            public string p_czxx;
            public string p_zt;
            public int p_pagesize;//每页容量
            public int p_currentpage;//当前页码
            public int p_userid;//用户id
            public string p_bhyy;
        }
        public ODYZX(UserState userstate)
        {
            _us = userstate;
            rz = new RZ(_us);
        }
        #region 查询

        protected DataTable Select_DYZX(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                          
                                           new OracleParameter("p_xm",OracleType.VarChar),
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_pagesize",OracleType.Int32),
                                           new OracleParameter("p_currentpage",OracleType.Int32),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_dyzx.p_xm;            
                paras[1].Value = struct_dyzx.p_kssj;
                paras[2].Value = struct_dyzx.p_jssj;
                paras[3].Value = struct_dyzx.p_zt;
                paras[4].Value = struct_dyzx.p_pagesize;
                paras[5].Value = struct_dyzx.p_currentpage;
                paras[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_DQZC_DYZX.Select_DYZX", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_DYZXShow(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           
                                           new OracleParameter("p_xm",OracleType.VarChar),
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                          
                                           new OracleParameter("p_pagesize",OracleType.Int32),
                                           new OracleParameter("p_currentpage",OracleType.Int32),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_dyzx.p_xm;
              
                paras[1].Value = struct_dyzx.p_kssj;
                paras[2].Value = struct_dyzx.p_jssj;
               
                paras[3].Value = struct_dyzx.p_pagesize;
                paras[4].Value = struct_dyzx.p_currentpage;
                paras[5].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_DQZC_DYZX.Select_DYZXShow", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DYZX_Count(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={                                                                                    
                                          
                                           new OracleParameter("p_xm",OracleType.VarChar),
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_dyzx.p_xm;
               
                paras[1].Value = struct_dyzx.p_kssj;
                paras[2].Value = struct_dyzx.p_jssj;
                paras[3].Value = struct_dyzx.p_zt;
                paras[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_DYZX.Select_DYZX_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DYZXShow_Count(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={                                                                                    
                                          
                                           new OracleParameter("p_xm",OracleType.VarChar),
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),
                                          
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_dyzx.p_xm;
               
                paras[1].Value = struct_dyzx.p_kssj;
                paras[2].Value = struct_dyzx.p_jssj;
             
                paras[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_DYZX.Select_DYZXShow_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查询员工
        protected DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                       new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bmdm;
                paras[1].Value = gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_AQJG_JCRW.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        protected void Insert_DYZX(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_kssj",OracleType.DateTime),
                                                   new OracleParameter("p_bh",OracleType.VarChar),                                                   
                                                   new OracleParameter("p_zysj",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_gwdm",OracleType.VarChar),
                                                   new OracleParameter("p_zt",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_dyzx.p_id;
                parament[1].Value = struct_dyzx.p_kssj;
                parament[2].Value = struct_dyzx.p_bh;
                parament[3].Value = struct_dyzx.p_zysj;
                parament[4].Value = struct_dyzx.p_bmdm;
                parament[5].Value = struct_dyzx.p_gwdm;
                parament[6].Value = struct_dyzx.p_zt;
                parament[7].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_DYZX.Insert_DYZX", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[6].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_dyzx.p_czfs;
                struct_rz.czxx = struct_dyzx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_DYZX_Detail(long id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_DQZC_DYZX.Select_DYZX_Detail ", parament, "table").Tables[0];
                //int returnCode = Convert.ToInt32(parament[1].Value);
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #region
        protected void Update_DYZX(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_kssj",OracleType.DateTime),
                                                   new OracleParameter("p_bh",OracleType.VarChar),                                                  
                                                   new OracleParameter("p_zysj",OracleType.VarChar),                                                   
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_dyzx.p_id;
                parament[1].Value = struct_dyzx.p_kssj;
                parament[2].Value = struct_dyzx.p_bh;
                parament[3].Value = struct_dyzx.p_zysj;                
                parament[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_DYZX.Update_DYZX", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[4].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_dyzx.p_czfs;
                struct_rz.czxx = struct_dyzx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 删除

        /// <summary>
        /// 删除员工惩罚
        /// </summary>
        /// <param name="bh"></param>
        protected void Delete_DYZX_byID(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Number),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_dyzx.p_id;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_DYZX.Delete_DYZX_byID", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_dyzx.p_czfs;
                struct_rz.czxx = struct_dyzx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 更新状态
        protected void Update_DYZXZT(Struct_DYZX struct_dyzx)
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
                paras[0].Value = struct_dyzx.p_id;
                paras[1].Value = struct_dyzx.p_zt;
                paras[2].Value = struct_dyzx.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_DQZC_DYZX.Update_DYZXZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_dyzx.p_czfs;
                struct_rz.czxx = struct_dyzx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        protected DataTable Select_DYZXbysj(Struct_DYZX struct_dyzx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                          
                                           new OracleParameter("p_kssj",OracleType.DateTime),
                                           new OracleParameter("p_jssj",OracleType.DateTime),                                          
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };               
                paras[0].Value = struct_dyzx.p_kssj;
                paras[1].Value = struct_dyzx.p_jssj;              
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_DQZC_DYZX.Select_DYZXbysj", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

    }

}
