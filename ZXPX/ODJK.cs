using Sys;
using System;
using System.Data;
using System.Data.OracleClient;
namespace CUST.MKG
{
    public struct Struct_DJK
    {
        public long p_id;
        public string p_ksh;
        public long p_zj_cl_id;
        public int p_zf;
        public string p_ip;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public double p_hs;
        public string p_zt;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_DJK_TJ
    {
        public string p_mc;
        public string p_ksh;
        public string p_km;
        public string p_gw;
        public string p_nd;
    }
    public struct Struct_Select_DJK
    {
        public string p_ksh;
        public string p_zjmc;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class ODJK
    {
        private UserState _us = null;
        private RZ rz = null;
        public ODJK(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 查询答卷库
        /// <summary>
        /// 查询答卷库表信息
        /// </summary>
        /// <param name="djk"></param>
        /// <returns></returns>
        protected DataTable Select_DJK_Pro(Struct_Select_DJK djk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_ksh",OracleType.VarChar),
                  new OracleParameter("p_zjmc",OracleType.VarChar),
                  new OracleParameter("p_pagesize",OracleType.Int32),
                  new OracleParameter("p_currentpage",OracleType.Int32),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = djk.p_ksh;
                paras[1].Value = djk.p_zjmc;
                paras[2].Value = djk.p_pagesize;
                paras[3].Value = djk.p_currentpage;
                paras[4].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_DJK.Select_DJK_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 查询答卷库数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_DJK_Count(Struct_Select_DJK djk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_ksh",OracleType.VarChar),
                    new OracleParameter("p_zjmc",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = djk.p_ksh;
                paras[1].Value = djk.p_zjmc;
                paras[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_ZXPX_DJK.Select_DJK_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询答卷库详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_DJK_Detail(long id)
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
                dt = dbclass.RunProcedure("PACK_ZXPX_DJK.Select_DJK_Detail", paras, "table").Tables[0];
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
        /// <param name="zj_cl_id"></param>
        /// <param name="ksh"></param>
        /// <param name="zt"></param>
        /// <returns></returns>
        protected DataTable Select_DJK_By_KSH_CL_ZT(string zj_cl_id, string ksh, string zt)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_zj_cl_id",OracleType.Number),
                  new OracleParameter("p_ksh",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = zj_cl_id;
                paras[1].Value = ksh;
                paras[2].Value = zt;
                paras[3].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_DJK.Select_DJK_By_KSH_CL_ZT", paras, "table").Tables[0];
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
        /// <param name="tj"></param>
        /// <returns></returns>
        protected DataTable Select_DJK_TJ(Struct_DJK_TJ tj)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_mc",OracleType.VarChar),
                  new OracleParameter("p_ksh",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = tj.p_mc;
                paras[1].Value = tj.p_ksh;
                paras[2].Value = tj.p_km;
                paras[3].Value = tj.p_gw;
                paras[4].Value = tj.p_nd;
                paras[5].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_DJK.Select_DJK_TJ", paras, "table").Tables[0];
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
        /// 删除答卷库表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_DJK_byID(long id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_ZXPX_DJK.Delete_DJK_byID", paras, out rowsAffected);
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
        /// <param name="djk"></param>
        protected string Insert_DJK(string zj_cl_id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_dj_id",OracleType.Number),
                  new OracleParameter("p_ksh",OracleType.VarChar),
                  new OracleParameter("p_zj_cl_id",OracleType.Number),
                  new OracleParameter("p_ip",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = "-1";
                paras[0].Direction = ParameterDirection.Output;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = zj_cl_id;
                paras[3].Value = _us.context.IP;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_DJK.Insert_DJK", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[4].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = p_czfs;
                struct_rz.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
                //返回答卷库的id
                return paras[0].Value.ToString();
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
        /// <param name="djk"></param>
        protected void Update_DJK(Struct_DJK djk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_jssj",OracleType.DateTime ),
                  new OracleParameter("p_hs",OracleType.Double ),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = djk.p_id;
                paras[1].Value = djk.p_jssj;
                paras[2].Value = djk.p_hs;
                paras[3].Value = djk.p_zt;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_DJK.Update_DJK", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[4].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = djk.p_czfs;
                struct_rz.czxx = djk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="djk"></param>
        protected void Update_DJK_KSSJ(string p_id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_kssj",OracleType.DateTime ),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = p_id;
                paras[1].Value = System.DateTime.Now;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_DJK.Update_DJK_KSSJ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="djk"></param>
        protected void Update_DJK_HS(long p_id, double p_hs, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_hs",OracleType.Double ),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = p_id;
                paras[1].Value = p_hs;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_DJK.Update_DJK_HS", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
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
    }
}
