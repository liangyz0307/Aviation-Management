using Sys;
using System;
using System.Data;
using System.Data.OracleClient;
namespace CUST.MKG
{
    public struct Struct_SJK
    {
        public long p_id;
        public long p_dj_id;
        public long p_st_id;
        public string p_st_lx;
        public int p_st_bh;
        public double p_st_fz;
        public string p_ks_da;
        public double p_df;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_SJK
    {
        public string p_dj_id;
        public string p_st_id;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OSJK
    {
        private UserState _us = null;
        private RZ rz = null;
        public OSJK(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 查询试卷库
     
        /// <summary>
        /// 查询试卷库表信息
        /// </summary>
        /// <param name="sjk"></param>
        /// <returns></returns>
        protected DataTable Select_SJK_Pro(Struct_Select_SJK sjk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_dj_id",OracleType.Number),
                  new OracleParameter("p_st_id",OracleType.Number),
                  new OracleParameter("p_pagesize",OracleType.Int32),
                  new OracleParameter("p_currentpage",OracleType.Int32),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = sjk.p_dj_id;
                paras[1].Value = sjk.p_st_id;
                paras[2].Value = sjk.p_pagesize;
                paras[3].Value = sjk.p_currentpage;
                paras[4].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_SJK.Select_SJK_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
     
        /// <summary>
        /// 查询试卷库数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_SJK_Count(Struct_Select_SJK sjk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_dj_id",OracleType.Number),
                      new OracleParameter("p_st_id",OracleType.Number),
                      new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = sjk.p_dj_id;
                paras[1].Value = sjk.p_st_id;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_ZXPX_SJK.Select_SJK_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
      
        /// <summary>
        /// 查询试卷库详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_SJK_Detail(long id)
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
                dt = dbclass.RunProcedure("PACK_ZXPX_SJK.Select_SJK_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dj_id"></param>
        /// <param name="st_lx"></param>
        /// <returns></returns>
        protected DataTable Select_SJK_by_dj_id(string dj_id,string st_lx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_dj_id",OracleType.Number),
                      new OracleParameter("p_st_lx",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = dj_id;
                paras[1].Value = st_lx;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_SJK.Select_SJK_by_dj_id", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }



      /// <summary>
      /// 
      /// </summary>
      /// <param name="p_st_id"></param>
      /// <returns></returns>
        protected DataTable Select_XZT_XX(string p_st_id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_st_id",OracleType.Number),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = p_st_id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_SJK.Select_XZT_XX", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }








        /// <summary>
        /// 
        /// </summary>
        /// <param name="dj_id"></param>
        /// <param name="st_lx"></param>
        /// <returns></returns>
        protected DataTable Select_STK_By_ZJCL(string p_zj_cl_id, string st_lx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_zj_cl_id",OracleType.Number),
                      new OracleParameter("p_st_lx",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = p_zj_cl_id;
                paras[1].Value = st_lx;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_SJK.Select_STK_By_ZJCL", paras, "table").Tables[0];
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
        /// 删除试卷库表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_SJK_byID(long id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_ZXPX_SJK.Delete_SJK_byID", paras, out rowsAffected);
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
        /// <param name="sjk"></param>
        protected void Insert_SJK(Struct_SJK sjk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_dj_id",OracleType.Number),
                  new OracleParameter("p_st_id",OracleType.Number),
                  new OracleParameter("p_st_lx",OracleType.VarChar),
                  new OracleParameter("p_st_bh",OracleType.Number),
                  new OracleParameter("p_st_fz",OracleType.Double),
                  new OracleParameter("p_ks_da",OracleType.VarChar),
                  new OracleParameter("p_df",OracleType.Double),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = sjk.p_dj_id;
                paras[1].Value = sjk.p_st_id;
                paras[2].Value = sjk.p_st_lx;
                paras[3].Value = sjk.p_st_bh;
                paras[4].Value = sjk.p_st_fz;
                paras[5].Value = sjk.p_ks_da;
                paras[6].Value = sjk.p_df;
                paras[7].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_SJK.Insert_SJK", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[7].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = sjk.p_czfs;
                struct_rz.czxx = sjk.p_czxx;
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
        /// <param name="sjk"></param>
        protected void Update_SJK(Struct_SJK sjk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_ks_da",OracleType.VarChar),
                  new OracleParameter("p_df",OracleType.Double),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = sjk.p_id;
                paras[1].Value = sjk.p_ks_da;
                paras[2].Value = sjk.p_df;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_SJK.Update_SJK", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = sjk.p_czfs;
                struct_rz.czxx = sjk.p_czxx;
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
