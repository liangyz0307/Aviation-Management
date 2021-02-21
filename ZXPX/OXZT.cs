using Sys;
using System;
using System.Data;
using System.Data.OracleClient;
namespace CUST.MKG
{
    public struct Struct_XZT
    {
        public long p_id;
        public string p_tg;
        public string p_sfdx;
        public string p_da;
        public string p_lj;
        public string p_sfytp;
        public string p_km;
        public string p_gw;
        public string p_nd;
        public string p_lb;
        public string p_kczsd;
        public string p_sfqy;
        public string p_lrr;
        public DateTime p_lrsj;
        public string p_shr;
        public string p_zt;
        public string p_yysm;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_ST
    {
        public string p_tg;
        public string p_sfdx;
        public string p_km;
        public string p_gw;
        public string p_nd;
        public string p_lb;
        public string p_zt;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public struct Struct_SH
    {
        public long p_id;
        public string p_shr;
        public string p_zt;
        public string p_yysm;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_XZT_XX
    {
        public long p_id;
        public long p_st_id;
        public string p_xx;
        public string p_xxnr;
        public string p_czfs;
        public string p_czxx;
    }
    public class OXZT
    {
        private UserState _us = null;
        private RZ rz = null;
        public OXZT(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询选择题
        /// <summary>
        /// 查询选择题表信息
        /// </summary>
        /// <param name="xzt"></param>
        /// <returns></returns>
        protected DataTable Select_XZT_Pro(Struct_Select_ST xzt)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_sfdx",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_pagesize",OracleType.Int32),
                  new OracleParameter("p_currentpage",OracleType.Int32),
                  new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = xzt.p_tg;
                paras[1].Value = xzt.p_sfdx;
                paras[2].Value = xzt.p_km;
                paras[3].Value = xzt.p_gw;
                paras[4].Value = xzt.p_nd;
                paras[5].Value = xzt.p_lb;
                paras[6].Value = xzt.p_zt;
                paras[7].Value = xzt.p_pagesize;
                paras[8].Value = xzt.p_currentpage;
                paras[9].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_XZT.Select_XZT_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询选择题数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_XZT_Count(Struct_Select_ST xzt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                   new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_sfdx",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = xzt.p_tg;
                paras[1].Value = xzt.p_sfdx;
                paras[2].Value = xzt.p_km;
                paras[3].Value = xzt.p_gw;
                paras[4].Value = xzt.p_nd;
                paras[5].Value = xzt.p_lb;
                paras[6].Value = xzt.p_zt;
                paras[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_ZXPX_XZT.Select_XZT_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 查询选择题详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_XZT_Detail(long id)
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
                dt = dbclass.RunProcedure("PACK_ZXPX_XZT.Select_XZT_Detail", paras, "table").Tables[0];
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
        /// 删除选择题表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_XZT_byID(long id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_ZXPX_XZT.Delete_XZT_byID", paras, out rowsAffected);
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
        /// <param name="xzt"></param>
        protected void Insert_XZT(Struct_XZT xzt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_sfdx",OracleType.VarChar),
                  new OracleParameter("p_da",OracleType.VarChar),
                  new OracleParameter("p_lj",OracleType.VarChar),
                  new OracleParameter("p_sfytp",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_kczsd",OracleType.VarChar),
                  new OracleParameter("p_sfqy",OracleType.VarChar),
                  new OracleParameter("p_lrr",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = xzt.p_tg;
                paras[1].Value = xzt.p_sfdx;
                paras[2].Value = xzt.p_da;
                paras[3].Value = xzt.p_lj;
                paras[4].Value = xzt.p_sfytp;
                paras[5].Value = xzt.p_km;
                paras[6].Value = xzt.p_gw;
                paras[7].Value = xzt.p_nd;
                paras[8].Value = xzt.p_lb;
                paras[9].Value = xzt.p_kczsd;
                paras[10].Value = "0";//启用
                paras[11].Value = _us.userLoginName;
                paras[12].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Insert_XZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = xzt.p_czfs;
                struct_rz.czxx = xzt.p_czxx;
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
        /// <param name="xzt"></param>
        protected void Update_XZT(Struct_XZT xzt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_tg",OracleType.VarChar),
                  new OracleParameter("p_da",OracleType.VarChar),
                  new OracleParameter("p_lj",OracleType.VarChar),
                  new OracleParameter("p_sfytp",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_kczsd",OracleType.VarChar),
                  new OracleParameter("p_sfqy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = xzt.p_id;
                paras[1].Value = xzt.p_tg;
                paras[2].Value = xzt.p_da;
                paras[3].Value = xzt.p_lj;
                paras[4].Value = xzt.p_sfytp;
                paras[5].Value = xzt.p_km;
                paras[6].Value = xzt.p_gw;
                paras[7].Value = xzt.p_nd;
                paras[8].Value = xzt.p_lb;
                paras[9].Value = xzt.p_kczsd;
                paras[10].Value = xzt.p_sfqy;
                paras[11].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Update_XZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[11].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = xzt.p_czfs;
                struct_rz.czxx = xzt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="xzt"></param>
        protected void Update_XZT_TJ(Struct_SH xzt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_shr",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = xzt.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = xzt.p_zt;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Update_XZT_TJ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = xzt.p_czfs;
                struct_rz.czxx = xzt.p_czxx;
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
        /// <param name="xzt"></param>
        protected void Update_XZT_SHTG(Struct_SH xzt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_shr",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = xzt.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = xzt.p_zt;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Update_XZT_SHTG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = xzt.p_czfs;
                struct_rz.czxx = xzt.p_czxx;
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
        /// <param name="xzt"></param>
        protected void Update_XZT_BH(Struct_SH xzt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_shr",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_yysm",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = xzt.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = xzt.p_zt;
                paras[3].Value = xzt.p_yysm;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Update_XZT_BH", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[4].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = xzt.p_czfs;
                struct_rz.czxx = xzt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
      
        #region 选项的增删改查
        /// <summary>
        /// 查询选择题选项
        /// </summary>
        /// <param name="stid"></param>
        /// <returns></returns>
        protected DataTable Select_XZT_XX(long stid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_st_id",OracleType.VarChar),
                  new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = stid;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_XZT.Select_XZT_XX", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 根据试题编号删除选择题
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_XZT_XX_bySTID(long stid, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_st_id",OracleType.Number),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = stid;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Delete_XZT_XX_bySTID", paras, out rowsAffected);
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
        /// <summary>
        /// 根据选项删除选择题
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_XZT_XX_byID(long id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_ZXPX_XZT.Delete_XZT_XX_byID", paras, out rowsAffected);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xzt_xx"></param>
        protected void Insert_XZT_XX(Struct_XZT_XX xzt_xx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_st_id",OracleType.Number),
                  new OracleParameter("p_xx",OracleType.VarChar),
                  new OracleParameter("p_xxnr",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = xzt_xx.p_st_id;
                paras[1].Value = xzt_xx.p_xx;
                paras[2].Value = xzt_xx.p_xxnr;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Insert_XZT_XX", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = xzt_xx.p_czfs;
                struct_rz.czxx = xzt_xx.p_czxx;
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
        /// <param name="xzt_xx"></param>
        protected void Update_XZT_XX(Struct_XZT_XX xzt_xx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_xx",OracleType.VarChar),
                  new OracleParameter("p_xxnr",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = xzt_xx.p_id;
                paras[1].Value = xzt_xx.p_xx;
                paras[2].Value = xzt_xx.p_xxnr;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_XZT.Update_XZT_XX", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = xzt_xx.p_czfs;
                struct_rz.czxx = xzt_xx.p_czxx;
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
