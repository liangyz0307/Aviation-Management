using System;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_PCX
    {
        public string p_pcxbh;//评测项编号
        public string p_pcxmc;//评测项名称
        public string p_pcxzbms;//评测项指标描述
        public string p_pcxjjf;//评测项加减分
        public string p_bhyy;//驳回原因
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_zt;//状态
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
    }
    public class OPCX
    {
        private UserState _us = null;
        private RZ rz = null;
        public OPCX(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        //查询
        protected DataSet Select_PCX_Pro(Struct_PCX struct_pcx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {

                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                               
                                                
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_pcx.p_pcxmc;
              
            
                parament[1].Value = struct_pcx.p_zt;
                parament[2].Value = struct_pcx.p_pagesize;
                parament[3].Value = struct_pcx.p_currentpage;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCX.Select_PCX_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BMPCX_Pro(Struct_PCX struct_pcx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {

                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                               
                                                
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_pcx.p_pcxmc;


                parament[1].Value = struct_pcx.p_zt;
                parament[2].Value = struct_pcx.p_pagesize;
                parament[3].Value = struct_pcx.p_currentpage;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCX.Select_BMPCX_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询数量
        protected int Select_PCX_Count(Struct_PCX struct_pcx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_pcx.p_pcxmc;
                parament[1].Value = struct_pcx.p_zt;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_PCX.Select_PCX_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected int Select_BMPCX_Count(Struct_PCX struct_pcx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_pcx.p_pcxmc;
                parament[1].Value = struct_pcx.p_zt;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_PCX.Select_BMPCX_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //添加 
        protected void Insert_PCX_Pro(Struct_PCX struct_pcx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxzbms",OracleType.VarChar),
                                                 new OracleParameter("p_pcxjjf",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = struct_pcx.p_pcxbh;
                parament[1].Value = struct_pcx.p_pcxmc;
                parament[2].Value = struct_pcx.p_pcxzbms;
                parament[3].Value = struct_pcx.p_pcxjjf;
                parament[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCX.Insert_PCX_Pro", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[4].Value);
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
        protected void Insert_BMPCX(Struct_PCX struct_pcx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxzbms",OracleType.VarChar),
                                                 //new OracleParameter("p_pcxjjf",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = struct_pcx.p_pcxbh;
                parament[1].Value = struct_pcx.p_pcxmc;
                parament[2].Value = struct_pcx.p_pcxzbms;
                //parament[3].Value = struct_pcx.p_pcxjjf;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCX.Insert_BMPCX", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[3].Value);
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
        //更新
        protected void Update_PCX_Pro(Struct_PCX struct_pcx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                                 new OracleParameter("p_zbms",OracleType.VarChar),
                                                 new OracleParameter("p_pcxjjf",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_pcx.p_pcxbh;
                parament[1].Value = struct_pcx.p_pcxmc;
                parament[2].Value = struct_pcx.p_pcxzbms;
                parament[3].Value = struct_pcx.p_pcxjjf;
                parament[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCX.Update_PCX_Pro", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[4].Value);
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
        protected DataSet Select_PCX_Detail(string pcxbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = pcxbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCX.Select_PCXbyPCXBH ", parament, "table");

                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_PCX_ZT(Struct_PCX struct_pcx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_pcxbh",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_pcx.p_pcxbh;
                paras[1].Value = struct_pcx.p_zt;
                paras[2].Value = struct_pcx.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_JXGL_PCX.Update_PCX_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }

            }
            finally
            {
                db.Close();
            }
        }
        protected void Update_BMPCX_ZT(Struct_PCX struct_pcx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_pcxbh",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_pcx.p_pcxbh;
                paras[1].Value = struct_pcx.p_zt;
                paras[2].Value = struct_pcx.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_JXGL_PCX.Update_BMPCX_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
            }
            finally
            {
                db.Close();
            }
        }
        //删除
        protected void Delete_PCX(string pcxbh, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_pcxbh",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = pcxbh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCX.Delete_PCX", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
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
        protected void Delete_BMPCX(string pcxbh, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_pcxbh",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = pcxbh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCX.Delete_BMPCX", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
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
        //查询评测方案下的评测项，用于添加，
        protected DataSet Select_PCFA_Detail(string zfabh,string pcfabh,string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_zfabh",OracleType.VarChar),
                                                   new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                   new OracleParameter("p_ygbh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = zfabh;
                parament[1].Value = pcfabh;
                parament[2].Value = ygbh;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_PCFA_Detail ", parament, "table");

                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BMPCFA_Detail(string zfabh, string pcfabh, string bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_zfabh",OracleType.VarChar),
                                                   new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = zfabh;
                parament[1].Value = pcfabh;
                parament[2].Value = bmdm;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_BMPCFA_Detail ", parament, "table");

                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询评测项表，用于备选评测方案//20180720
        protected DataSet Select_PCXMC()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {                                          
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCX.Select_PCXMC", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询部门评测项表中全部评测项，用于组建新的评测方案
        protected DataSet Select_BMPCXMC()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {                                          
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCX.Select_BMPCXMC", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
    }
}
       
