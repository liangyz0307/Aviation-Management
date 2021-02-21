using Sys;
using System;
using System.Data;
using System.Data.OracleClient;
namespace CUST.MKG
{
    public struct Struct_ZJ_CL
    {
        public long p_id;
        public string p_mc;
        public double p_zf;
        public string p_ctr;
        public DateTime p_ctsj;
        public string p_km;
        public string p_gw;
        public string p_nd;
        public string p_lb;
        public int p_xz_sl;
        public double p_xz_fz;
        public int p_dx_sl;
        public double p_dx_fz;
        public int p_pd_sl;
        public double p_pd_fz;
        public int p_tk_sl;
        public double p_tk_fz;
        public int p_sc;
        public string p_shr;
        public string p_zt;
        public string p_yysm;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_ZJ_CL
    {
        public string p_mc;
        public string p_km;
        public string p_gw;
        public string p_nd;
        public string p_lb;
        public string p_zt;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OZJ_CL
    {
        private UserState _us = null;
        private RZ rz = null;
        public OZJ_CL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zj_cl"></param>
        /// <returns></returns>
        protected DataTable Select_ZJ_CL_Pro(Struct_Select_ZJ_CL zj_cl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_mc",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_pagesize",OracleType.Int32),
                  new OracleParameter("p_currentpage",OracleType.Int32),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = zj_cl.p_mc;
                paras[1].Value = zj_cl.p_km;
                paras[2].Value = zj_cl.p_gw;
                paras[3].Value = zj_cl.p_nd;
                paras[4].Value = zj_cl.p_lb;
                paras[5].Value = zj_cl.p_zt;
                paras[6].Value = zj_cl.p_pagesize;
                paras[7].Value = zj_cl.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_ZXPX_ZJ_CL.Select_ZJ_CL_Pro", paras, "table").Tables[0];
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
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_ZJ_CL_Count(Struct_Select_ZJ_CL zj_cl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_mc",OracleType.VarChar),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = zj_cl.p_mc;
                paras[1].Value = zj_cl.p_km;
                paras[2].Value = zj_cl.p_gw;
                paras[3].Value = zj_cl.p_nd;
                paras[4].Value = zj_cl.p_lb;
                paras[5].Value = zj_cl.p_zt;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_ZXPX_ZJ_CL.Select_ZJ_CL_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_ZJ_CL_Detail(long id)
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
                dt = dbclass.RunProcedure("PACK_ZXPX_ZJ_CL.Select_ZJ_CL_Detail", paras, "table").Tables[0];
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
        /// 删除填空题表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_ZJ_CL_byID(long id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_ZXPX_ZJ_CL.Delete_ZJ_CL_byID", paras, out rowsAffected);
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
        /// <param name="zj_cl"></param>
        protected void Insert_ZJ_CL(Struct_ZJ_CL zj_cl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_mc",OracleType.VarChar),
                  new OracleParameter("p_zf",OracleType.Number),
                  new OracleParameter("p_ctr",OracleType.VarChar),
                  new OracleParameter("p_ctsj",OracleType.DateTime),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_xz_sl",OracleType.Number),
                  new OracleParameter("p_xz_fz",OracleType.Double),
                  new OracleParameter("p_dx_sl",OracleType.Number),
                  new OracleParameter("p_dx_fz",OracleType.Double),
                  new OracleParameter("p_pd_sl",OracleType.Number),
                  new OracleParameter("p_pd_fz",OracleType.Double),
                  new OracleParameter("p_tk_sl",OracleType.Number),
                  new OracleParameter("p_tk_fz",OracleType.Double),
                  new OracleParameter("p_sc",OracleType.Number),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = zj_cl.p_mc;
                paras[1].Value = zj_cl.p_zf;
                paras[2].Value = _us.userLoginName;
                paras[3].Value = DateTime.Now;
                paras[4].Value = zj_cl.p_km;
                paras[5].Value = zj_cl.p_gw;
                paras[6].Value = zj_cl.p_nd;
                paras[7].Value = zj_cl.p_lb;
                paras[8].Value = zj_cl.p_xz_sl;
                paras[9].Value = zj_cl.p_xz_fz;
                paras[10].Value = zj_cl.p_dx_sl;
                paras[11].Value = zj_cl.p_dx_fz;
                paras[12].Value = zj_cl.p_pd_sl;
                paras[13].Value = zj_cl.p_pd_fz;
                paras[14].Value = zj_cl.p_tk_sl;
                paras[15].Value = zj_cl.p_tk_fz;
                paras[16].Value = zj_cl.p_sc;
                paras[17].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_ZJ_CL.Insert_ZJ_CL", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[17].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zj_cl.p_czfs;
                struct_rz.czxx = zj_cl.p_czxx;
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
        /// <param name="zj_cl"></param>
        protected void Update_ZJ_CL(Struct_ZJ_CL zj_cl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_mc",OracleType.VarChar),
                  new OracleParameter("p_zf",OracleType.Number),
                  new OracleParameter("p_km",OracleType.VarChar),
                  new OracleParameter("p_gw",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_lb",OracleType.VarChar),
                  new OracleParameter("p_xz_sl",OracleType.Number),
                  new OracleParameter("p_xz_fz",OracleType.Double),
                  new OracleParameter("p_dx_sl",OracleType.Number),
                  new OracleParameter("p_dx_fz",OracleType.Double),
                  new OracleParameter("p_pd_sl",OracleType.Number),
                  new OracleParameter("p_pd_fz",OracleType.Double),
                  new OracleParameter("p_tk_sl",OracleType.Number),
                  new OracleParameter("p_tk_fz",OracleType.Double),
                  new OracleParameter("p_sc",OracleType.Number),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = zj_cl.p_id;
                paras[1].Value = zj_cl.p_mc;
                paras[2].Value = zj_cl.p_zf;
                paras[3].Value = zj_cl.p_km;
                paras[4].Value = zj_cl.p_gw;
                paras[5].Value = zj_cl.p_nd;
                paras[6].Value = zj_cl.p_lb;
                paras[7].Value = zj_cl.p_xz_sl;
                paras[8].Value = zj_cl.p_xz_fz;
                paras[9].Value = zj_cl.p_dx_sl;
                paras[10].Value = zj_cl.p_dx_fz;
                paras[11].Value = zj_cl.p_pd_sl;
                paras[12].Value = zj_cl.p_pd_fz;
                paras[13].Value = zj_cl.p_tk_sl;
                paras[14].Value = zj_cl.p_tk_fz;
                paras[15].Value = zj_cl.p_sc;
                paras[16].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_ZJ_CL.Update_ZJ_CL", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[16].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zj_cl.p_czfs;
                struct_rz.czxx = zj_cl.p_czxx;
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
        /// <param name="zj_cl"></param>
        protected void Update_ZJ_CL_TJ(Struct_SH zj_cl)
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
                paras[0].Value = zj_cl.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = zj_cl.p_zt;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_ZJ_CL.Update_ZJ_CL_TJ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zj_cl.p_czfs;
                struct_rz.czxx = zj_cl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="zj_cl"></param>
        protected void Update_ZJ_CL_SHTG(Struct_SH zj_cl)
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
                paras[0].Value = zj_cl.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = zj_cl.p_zt;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_ZJ_CL.Update_ZJ_CL_SHTG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zj_cl.p_czfs;
                struct_rz.czxx = zj_cl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="zj_cl"></param>
        protected void Update_ZJ_CL_BH(Struct_SH zj_cl)
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
                paras[0].Value = zj_cl.p_id;
                paras[1].Value = _us.userLoginName;
                paras[2].Value = zj_cl.p_zt;
                paras[3].Value = zj_cl.p_yysm;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_ZXPX_ZJ_CL.Update_ZJ_CL_BH", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[4].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zj_cl.p_czfs;
                struct_rz.czxx = zj_cl.p_czxx;
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
