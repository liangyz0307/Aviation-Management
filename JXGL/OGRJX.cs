using Sys;
using System;
using System.Data;
using System.Data.OracleClient;

namespace CUST.MKG
{
    public struct Struct_GRJX
    {
        public string p_id;//id
        public string p_pcfabh;//评测方案编号
        public string p_pcfamc;//评测方案名称
        public string p_pcfaqz;//评测方案权重
        public double p_pcfadf;//评测方案得分
        public string p_pcxbh;//评测项编号
        public double p_pcxdf;//评测项打分
        public string p_zfabh;//总案编号
        public string p_zfamc;//总案名称
        public string p_ygbh;//员工编号
        public string p_zbms;//指标描述
        public string p_pcfazbms;//评测方案指标描述
        public double p_grdf;//个人得分
        public string p_bmdm;//部门代码
        public string p_gwdm;//岗位代码
        public string p_dfrq;//打分日期
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public string p_grjxzf;//个人绩效总分（每个人每个评测方案下的绩效分）
    }
    public class OGRJX
    {
        private UserState _us = null;
        private RZ rz = null;
        public OGRJX(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        //给部门添加评测方案
        protected void Insert_BMJXPCFA(string bmdm,string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = bmdm;
                parament[1].Value = pcfabh;            
                parament[2].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_BMJXPCFA", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[2].Value);
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
        //计算员工评测方案得分（各评测项权重之和）
        protected void Insert_GRJX_PCFA_DF(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfadf",OracleType.VarChar),
                                                 new OracleParameter("p_pcfazbms",OracleType.VarChar),
                                                 new OracleParameter("p_dfrq",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_grjx.p_ygbh;
                parament[1].Value = struct_grjx.p_pcfabh;
                parament[2].Value = struct_grjx.p_pcfadf;
                parament[3].Value = struct_grjx.p_pcfazbms;
                parament[4].Value = struct_grjx.p_dfrq;
                parament[5].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_GRJX_PCFA_DF", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[5].Value);
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
        //GRJX表中，插入员工每一个评测项的得分(打的分)
        protected void Insert_GRJX_Pro(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_zbms",OracleType.VarChar),
                                                 new OracleParameter("p_grdf",OracleType.VarChar),
                                                 new OracleParameter("p_dfrq",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_grjx.p_ygbh;
                parament[1].Value = struct_grjx.p_pcfabh;
                parament[2].Value = struct_grjx.p_pcxbh;
                parament[3].Value = struct_grjx.p_zbms;
                parament[4].Value = struct_grjx.p_grdf;
                parament[5].Value = struct_grjx.p_dfrq;
                parament[6].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_GRJX_Pro", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[6].Value);
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
        protected void Insert_GRJX_PCFAZA(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_zfamc",OracleType.VarChar),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfaqz",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = struct_grjx.p_zfabh;
                parament[1].Value = struct_grjx.p_zfamc;
                parament[2].Value = struct_grjx.p_pcfabh;
                parament[3].Value = struct_grjx.p_pcfaqz;
                parament[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_GRJX_ZFA", parament, out reslut);
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
        //给各个员工添加评测方案
        protected void Insert_YG_ZFA(string ygbh,string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_YG_ZFA", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[2].Value);
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
        protected void Insert_BM_ZFA(string bmdm, string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = bmdm;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_BM_ZFA", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[2].Value);
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
        protected void Delete_GRJX_ByID(string id, string p_czfs, string p_czxx)
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
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Delete_GRJX_ByID", parament, out reslut);

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
        protected void Delete_GRJX_ByYGBH(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_ygbh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Delete_GRJX_ByYGBH", parament, out reslut);

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
        protected void Delete_GRJXZF_ByYGBH(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_ygbh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Delete_GRJXZF_ByYGBH", parament, out reslut);

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
        //删除KG_PCFA_BM_Add表中的部门评测方案
        protected void Delete_BMPCFA(string bmdm,string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = bmdm;
                parament[1].Value = pcfabh;
                parament[2].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Delete_BMPCFA", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[2].Value);
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
        //删除KG_BMJX表中的评测方案相关信息（评测项打分）
        protected void Delete_BMJX_PCFA(string bmdm, string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = bmdm;
                parament[1].Value = pcfabh;
                parament[2].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Delete_BMJX_PCFA", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[2].Value);
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
        protected void Update_GRJX_Pro(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_zbms",OracleType.VarChar),
                                                 new OracleParameter("p_grdf",OracleType.VarChar),
                                                 new OracleParameter("p_dfrq",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_grjx.p_ygbh;
                parament[1].Value = struct_grjx.p_zfabh;
                parament[2].Value = struct_grjx.p_pcfabh;
                parament[3].Value = struct_grjx.p_pcxbh;
                parament[4].Value = struct_grjx.p_zbms;
                parament[5].Value = struct_grjx.p_grdf;
                parament[6].Value = struct_grjx.p_dfrq;
                parament[7].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Update_GRJX_Pro", parament, out reslut);
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
        protected void Update_GRJX_DF(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfadf",OracleType.VarChar),
                                                 new OracleParameter("p_zbms",OracleType.VarChar),
                                                 new OracleParameter("p_dfrq",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_grjx.p_ygbh;
                parament[1].Value = struct_grjx.p_pcfabh;
                parament[2].Value = struct_grjx.p_pcfadf;
                parament[3].Value = struct_grjx.p_zbms;
                parament[4].Value = struct_grjx.p_dfrq;
                parament[5].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Update_GRJX_DF", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[5].Value);
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
        protected void Update_GRJX_ZT(Struct_GRJX struct_grjx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_grjx.p_id;
                paras[1].Value = struct_grjx.p_zt;
                paras[2].Value = struct_grjx.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_JXGL_GRJX.Update_GRJX_ZT", paras, out rowsAffected);
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
        protected void Update_BMJX_Pro(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxdf",OracleType.VarChar),
                                                 new OracleParameter("p_zbms",OracleType.VarChar),
                                                 new OracleParameter("p_dfrq",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parament[0].Value = struct_grjx.p_bmdm;
                parament[1].Value = struct_grjx.p_zfabh;
                parament[2].Value = struct_grjx.p_pcfabh;
                parament[3].Value = struct_grjx.p_pcxbh;
                parament[4].Value = struct_grjx.p_pcxdf;
                parament[5].Value = struct_grjx.p_zbms;
                parament[6].Value = struct_grjx.p_dfrq;
                parament[7].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Update_BMJX_Pro", parament, out reslut);
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
        //查询
        protected DataSet Select_GRJX_Pro(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_gwdm",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_grjx.p_bmdm;
                parament[1].Value = struct_grjx.p_gwdm;
                parament[2].Value = struct_grjx.p_zt;
                parament[3].Value = struct_grjx.p_pagesize;
                parament[4].Value = struct_grjx.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_Pro", parament, "table"); 
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BMJX_Pro(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_grjx.p_pagesize;
                parament[1].Value = struct_grjx.p_currentpage;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询数量
        protected int Select_GRJX_Count(Struct_GRJX struct_grjx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_gwdm",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_grjx.p_bmdm;
                parament[1].Value = struct_grjx.p_gwdm;
                parament[2].Value = struct_grjx.p_zfabh;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected int Select_BM_Count()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_GRJX.Select_BM_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected new DataSet Select_GRJXZF(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_gwdm",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_grjx.p_bmdm;
                parament[1].Value = struct_grjx.p_gwdm;
                parament[2].Value = struct_grjx.p_zfabh;
                parament[3].Value = struct_grjx.p_pagesize;
                parament[4].Value = struct_grjx.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJXZF", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected new DataSet Select_BMJXZF(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
           
                parament[0].Value = struct_grjx.p_zfabh;
                parament[1].Value = struct_grjx.p_pagesize;
                parament[2].Value = struct_grjx.p_currentpage;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJXZF", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected new DataSet Select_PCX(string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = pcfabh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.SELECT_PCX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_GRJX_Detail(string p_ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_ygbh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = p_ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_Detail ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_GRJX_PCFA_DF_ByBh(string ygbh,string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_PCFA_DF_ByBh ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_BMJX_PCFA_DF_ByBh(string bmdm, string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = bmdm;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_PCFA_DF_ByBh ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //根据员工编号 总方案编号查看基本信息
        protected DataTable Select_GRJX_JBXX(string ygbh, string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_JBXX ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_BMJX_JBXX(string bmdm, string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = bmdm;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_JBXX ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //根据员工编号 总方案编号查看绩效详情
        protected DataTable Select_GRJX_Detail_MX(Struct_GRJX grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = grjx.p_ygbh;
                parament[1].Value = grjx.p_zfabh;
                parament[2].Value = grjx.p_pagesize;
                parament[3].Value = grjx.p_currentpage;
                parament[4].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_Detail_MX ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_GRJX_Detail_MX_COUNT(string ygbh, string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_Detail_MX_COUNT", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }




        protected DataTable Select_BMJX_Detail_MX(Struct_GRJX grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = grjx.p_bmdm;
                parament[1].Value = grjx.p_zfabh;
                parament[2].Value = grjx.p_pagesize;
                parament[3].Value = grjx.p_currentpage;
                parament[4].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_Detail_MX ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_BMJX_Detail_MX_COUNT(string bmdm, string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = bmdm;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_Detail_MX_COUNT", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //查询该总方案下的评测方案
        protected DataTable Select_GRJX_PCFA_ByZFA(string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = zfabh;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_PCFA_ByZFA ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }        
        protected DataSet Select_YGXMbyBH(string p_bh)
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
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_GRJX.Select_YGXMbyBH", paras, "table");
                return ds;
            }
            finally
            {
                db.Close();
            }
        }
        // 通过部门岗位查询员工
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
                dt = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_AllYG(Struct_GRJX struct_grjx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_gwdm",OracleType.VarChar),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = struct_grjx.p_bmdm;
                parament[1].Value = struct_grjx.p_gwdm;
                parament[2].Value = struct_grjx.p_pagesize;
                parament[3].Value = struct_grjx.p_currentpage;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_AllYG ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }   
        //查询总方案
        protected DataSet Select_ZFA()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_ZFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //根据员工编号查询已有的总方案
        protected DataTable Select_YYZFA_BYBH(string ygbh,string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_ygbh",OracleType.VarChar),
                                                   new OracleParameter("p_zfabh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt= dbclass.RunProcedure("PACK_JXGL_GRJX.Select_YYZFA_BYBH", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //查询总方案下的评测方案
        protected DataSet Select_ZFA_PCFA(string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_zfabh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = zfabh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_ZFA_PCFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
       //查全部部门名
        protected DataSet Select_allBM()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_allBM ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查部门已有评测方案
        protected DataSet Select_BMYYPCFA(string bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = bmdm;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMYYPCFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查部门某一评测方案的具体信息用于打分
        protected DataSet Select_BMJX_PCFA_DF(string bmdm,string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_bmdm",OracleType.VarChar),
                                                new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = bmdm;
                parament[1].Value = pcfabh;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_PCFA_DF ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询部门名下已有全部评测方案的评测方案总得分
        protected DataSet Select_BMJX_Detail(string bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = bmdm;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_Detail ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //个人绩效展示

        
        public void Update_GRJX_ZS(string ygbh, string zfabh, string zszt)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_zszt",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Value = zszt;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Update_GRJX_ZS", parament, out reslut);
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

        public void Insert_GRJX_ZS(string ygbh, string zfabh,string zf)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_zf",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Value = zf;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_GRJX_ZS", parament, out reslut);
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

        public void Delete_GRJX_ZS(string ygbh, string zfabh, string zf)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_zf",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = ygbh;
                parament[1].Value = zfabh;
                parament[2].Value = zf;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Delete_GRJX_ZS", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[3].Value);
            }
            finally
            {
                dbclass.Close();
            }
        }

        //部门绩效展示
        public void Update_BMJX_ZS(string bmdm, string zfabh, string zszt)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_zszt",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = bmdm;
                parament[1].Value = zfabh;
                parament[2].Value = zszt;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Update_BMJX_ZS", parament, out reslut);
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
        public void Insert_BMJX_ZS(string bmdm, string zfabh, string zf)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_zf",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = bmdm;
                parament[1].Value = zfabh;
                parament[2].Value = zf;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Insert_BMJX_ZS", parament, out reslut);
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

        public void Delete_BMJX_ZS(string bmdm, string zfabh, string zf)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zfabh",OracleType.VarChar),
                                                 new OracleParameter("p_zf",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = bmdm;
                parament[1].Value = zfabh;
                parament[2].Value = zf;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_GRJX.Delete_BMJX_ZS", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[3].Value);
            }
            finally
            {
                dbclass.Close();
            }
        }
		protected DataTable Select_BMJX_PCFA_ByZFA(string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = zfabh;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_PCFA_ByZFA ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //查询展示的总方案的个数
        protected int Select_GRJX_ZS_Count(string p_ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_ZS_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_GRJX_ZS(string p_ygbh, int p_pagesize, int p_currentpage)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_ygbh;
                parament[1].Value = p_pagesize;
                parament[2].Value = p_currentpage;
                parament[3].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_GRJX_ZS ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_BMJX_ZS_Count(string p_bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_bmdm;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_ZS_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_BMJX_ZS(string p_bmdm, int p_pagesize, int p_currentpage)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_bmdm;
                parament[1].Value = p_pagesize;
                parament[2].Value = p_currentpage;
                parament[3].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.Select_BMJX_ZS ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

    }
}