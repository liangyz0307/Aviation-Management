using Sys;
using System;
using System.Data;
using System.Data.OracleClient;

namespace CUST.MKG
{
    public struct Struct_PCFA
    {
        public int p_id;//ID
        public string p_zfabh;//总方案编号
        public string p_zfamc;//总方案名称
        public string p_pcfabh;//评测方案编号
        public string p_pcfamc;//评测方案名称
        public string p_pcfaqz;//评测方案权重
        public string p_pcxbh;//评测项编号
        public string p_pcxqz;//评测项权重
        public string p_bhyy;//驳回原因
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_zt;//状态
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
    }
    public struct Struct_PCFA_Pro
    {
        public string p_pcfabh;//评测方案编号
        public string p_pcfamc;//评测方案名称
        public string p_pcxbh;//评测项编号
        public string p_pcxmc;//评测项名称
        public string p_pcxqz;//评测项权重
    }
    public class OPCFA
    {
        private UserState _us = null;
        private RZ rz = null;
        public OPCFA(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        //添加
        protected void Insert_PCFA_Pro(Struct_PCFA_Pro struct_pcfa_pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfamc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxmc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxqz",OracleType.VarChar)
                                                  //new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_pcfa_pro.p_pcfabh;
                parament[1].Value = struct_pcfa_pro.p_pcfamc;
                parament[2].Value = struct_pcfa_pro.p_pcxbh;
                parament[3].Value = struct_pcfa_pro.p_pcxmc;
                parament[4].Value = struct_pcfa_pro.p_pcxqz;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Insert_PCFA_Pro", parament, out reslut);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_BMPCFA_Pro(Struct_PCFA_Pro struct_pcfa_pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfamc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 //new OracleParameter("p_pcxmc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxqz",OracleType.VarChar)
                                                  //new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_pcfa_pro.p_pcfabh;
                parament[1].Value = struct_pcfa_pro.p_pcfamc;
                parament[2].Value = struct_pcfa_pro.p_pcxbh;
                //parament[3].Value = struct_pcfa_pro.p_pcxmc;
                parament[3].Value = struct_pcfa_pro.p_pcxqz;
                // parament[5].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Insert_BMPCFA_Pro", parament, out reslut);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_BMZFA(Struct_PCFA struct_pcfa)
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

                parament[0].Value = struct_pcfa.p_zfabh;
                parament[1].Value = struct_pcfa.p_zfamc;
                parament[2].Value = struct_pcfa.p_pcfabh;
                parament[3].Value = struct_pcfa.p_pcfaqz;
                parament[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Insert_BMZFA", parament, out reslut);
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
        //删除总方案
        protected void Delete_ZFA_ByZFABH(string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = zfabh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Delete_ZFA_ByZFABH", parament, out reslut);

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
        protected void Delete_BMZFA_ByZFABH(string zfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zfabh",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = zfabh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Delete_BMZFA_ByZFABH", parament, out reslut);

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
        //根据选中的评测项，的评测方案编号，删除该条评测项
        protected void Delete_PCFA_ByPCFABH(string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_pcfabh",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = pcfabh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Delete_PCFA_ByPCFABH", parament, out reslut);

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
        protected void Delete_BMPCFA_ByPCFABH(string pcfabh, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_pcfabh",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = pcfabh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Delete_BMPCFA_ByPCFABH", parament, out reslut);

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
        //根据ID删除该条评测项
        protected void Delete_PCFA_ByID(int id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Delete_PCFA_ByID", parament, out reslut);

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
        //更新
        protected void Update_PCFA_Pro(Struct_PCFA struct_pcfa)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfamc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxqz",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = struct_pcfa.p_pcfabh;
                parament[1].Value = struct_pcfa.p_pcfamc;
                parament[2].Value = struct_pcfa.p_pcxbh;
                parament[3].Value = struct_pcfa.p_pcxqz;
                parament[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_JXGL_PCFA.Update_PCFA_Pro", parament, out reslut);
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
        // 更新状态
        protected void Update_PCFA_ZT(Struct_PCFA struct_pcfa)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_pcfabh",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_pcfa.p_pcfabh;
                paras[1].Value = struct_pcfa.p_zt;
                paras[2].Value = struct_pcfa.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_JXGL_PCFA.Update_PCFA_ZT", paras, out rowsAffected);
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
        protected void Update_BMPCFA_ZT(Struct_PCFA struct_pcfa)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_pcfabh",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_pcfa.p_pcfabh;
                paras[1].Value = struct_pcfa.p_zt;
                paras[2].Value = struct_pcfa.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_JXGL_PCFA.Update_BMPCFA_ZT", paras, out rowsAffected);
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

        //查询全部部门评测方案，用于添加
        protected DataTable Select_ALL_BM_PCFA()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_ALL_BM_PCFA", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_PCFA_Pro(Struct_PCFA struct_pcfa)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfamc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxqz",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_pcfa.p_id;
                parament[1].Value = struct_pcfa.p_pcfabh;
                parament[2].Value = struct_pcfa.p_pcfamc;
                parament[3].Value = struct_pcfa.p_pcxbh;
                parament[4].Value = struct_pcfa.p_pcxqz;
                parament[5].Value = struct_pcfa.p_zt;
                parament[6].Value = struct_pcfa.p_pagesize;
                parament[7].Value = struct_pcfa.p_currentpage;
                parament[8].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_PCFA_Pro", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BMPCFA_Pro(Struct_PCFA struct_pcfa)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                 new OracleParameter("p_pcfamc",OracleType.VarChar),
                                                 new OracleParameter("p_pcxbh",OracleType.VarChar),
                                                 new OracleParameter("p_pcxqz",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_pcfa.p_id;
                parament[1].Value = struct_pcfa.p_pcfabh;
                parament[2].Value = struct_pcfa.p_pcfamc;
                parament[3].Value = struct_pcfa.p_pcxbh;
                parament[4].Value = struct_pcfa.p_pcxqz;
                parament[5].Value = struct_pcfa.p_zt;
                parament[6].Value = struct_pcfa.p_pagesize;
                parament[7].Value = struct_pcfa.p_currentpage;
                parament[8].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_BMPCFA_Pro", parament, "table");
                return ds;

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
        //查询数量
        protected int Select_PCFA_Count(Struct_PCFA struct_pcfa)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };

                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_PCFA.Select_PCFA_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected int Select_BMPCFA_Count(Struct_PCFA struct_pcfa)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };

                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_PCFA.Select_BMPCFA_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected DataSet SELECT_PCFA_BYPCFABH(string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = pcfabh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.SELECT_PCFA_BYPCFABH ", parament, "table");

                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet SELECT_BMFA_BYPCFABH(string pcfabh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_pcfabh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = pcfabh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.SELECT_BMFA_BYPCFABH ", parament, "table");

                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询总方案下的评测方案
        protected DataSet Select_BMZFA_PCFA(string zfabh)
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
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_BMZFA_PCFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询部门名下已有的总方案
        protected DataSet Select_BMZFA_BYBH(string bmdm)
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
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_BMZFA_BYBH ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_PCFA()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_GRJX.SELECT_PCFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BMPCFA()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_BMPCFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_ZFA(Struct_PCFA struct_pcfa)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_pagesize",OracleType.Int32),
                                                new OracleParameter("p_currentpage",OracleType.Int32),
                                                new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = struct_pcfa.p_pagesize;
                parament[1].Value = struct_pcfa.p_currentpage;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_ZFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BMZFA(Struct_PCFA struct_pcfa)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_pagesize",OracleType.Int32),
                                                new OracleParameter("p_currentpage",OracleType.Int32),
                                                new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = struct_pcfa.p_pagesize;
                parament[1].Value = struct_pcfa.p_currentpage;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_BMZFA ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_ZFA_Count(Struct_PCFA struct_pcfa)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_PCFA.Select_ZFA_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected int Select_BMZFA_Count(Struct_PCFA struct_pcfa)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_JXGL_PCFA.Select_BMZFA_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        //查询根据选中的评测项的ID，查询出所在pcfa的其他pcx的id，
        //删除该条评测项，意味着删除该评测项所在的评测方案里的其他评测项，即删除整个评测方案
        protected DataTable Select_PCFA_PCX_ID_DeleteByID(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_PCFA_PCX_ID_DeleteByID", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查员工已有总方案
        protected DataTable Select_YGYYZFA(string ygbh)
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
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_JXGL_PCFA.Select_YGYYZFA ", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
    }
}
