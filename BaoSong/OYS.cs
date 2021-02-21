using System;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_YS
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bsgw;
        public string p_bslx;
        public string p_bsip;
        public DateTime p_bssj;
        public string p_sqbm;
        public string p_ysze;
        public string p_ysyt;
        public string p_ysly;
        public string p_yynx;
        public string p_spr;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_YS
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_xm;
        public string p_bslx;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OYS
    {
        private UserState _us = null;
        private RZ rz = null;
        public OYS(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 查询


        /// <summary>
        /// 查询预算表信息
        /// </summary>
        /// <param name="ys"></param>
        /// <returns></returns>
        protected DataTable Select_YS_Pro(Struct_Select_YS ys)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                       new OracleParameter("p_bsbh",OracleType.VarChar),
                       new OracleParameter("p_bsyg",OracleType.VarChar),
                       new OracleParameter("p_xm",OracleType.VarChar),
                       new OracleParameter("p_bslx",OracleType.VarChar),
                       new OracleParameter("p_pagesize",OracleType.Int32),
                       new OracleParameter("p_currentpage",OracleType.Int32),
                       new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = ys.p_bsbh;
                paras[1].Value = ys.p_bsyg;
                paras[2].Value = ys.p_xm;
                paras[3].Value = ys.p_bslx;
                paras[4].Value = ys.p_pagesize;
                paras[5].Value = ys.p_currentpage;
                paras[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_YS.Select_YS_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询预算数量
        /// </summary>
        /// <param name="ys"></param>
        /// <returns></returns>
        protected int Select_YS_Count(Struct_Select_YS ys)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_bsbh",OracleType.VarChar),
                        new OracleParameter("p_bsyg",OracleType.VarChar),
                        new OracleParameter("p_xm",OracleType.VarChar),
                        new OracleParameter("p_bslx",OracleType.VarChar),
                        new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = ys.p_bsbh;
                paras[1].Value = ys.p_bsyg;
                paras[2].Value = ys.p_xm;
                paras[3].Value = ys.p_bslx;
                paras[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_YS.Select_YS_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 查询预算详情
        /// </summary>
        /// <param name="bsbh"></param>
        /// <returns></returns>
        protected DataTable Select_YS_Detail(string bsbh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bsbh",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bsbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_HWZHBS_YS.Select_YS_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 报送编号十位流水号生成
        /// </summary>
        /// <returns></returns>
        protected string SelectBS_YSMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_HWZHBS_YS.SelectBS_YSMaxBH", paras);
                string maxbh = paras[0].Value.ToString();
                return maxbh;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ys"></param>
        protected void Insert_YS(Struct_YS ys)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_bsbh",OracleType.VarChar),
                  new OracleParameter("p_bsyg",OracleType.VarChar),
                  new OracleParameter("p_bsgw",OracleType.VarChar),
                  new OracleParameter("p_bslx",OracleType.VarChar),
                  new OracleParameter("p_bsip",OracleType.VarChar),
                  new OracleParameter("p_bssj",OracleType.DateTime),
                  new OracleParameter("p_sqbm",OracleType.VarChar),
                  new OracleParameter("p_ysze",OracleType.VarChar),
                  new OracleParameter("p_ysyt",OracleType.VarChar),
                  new OracleParameter("p_ysly",OracleType.VarChar),
                  new OracleParameter("p_yynx",OracleType.VarChar),
                  new OracleParameter("p_spr",OracleType.VarChar),
                  new OracleParameter("p_bz",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)

        };
                paras[0].Value = ys.p_bsbh;
                paras[1].Value = ys.p_bsyg;
                paras[2].Value = ys.p_bsgw;
                paras[3].Value = ys.p_bslx;
                paras[4].Value = ys.p_bsip;
                paras[5].Value = ys.p_bssj;
                paras[6].Value = ys.p_sqbm;
                paras[7].Value = ys.p_ysze;
                paras[8].Value = ys.p_ysyt;
                paras[9].Value = ys.p_ysly;
                paras[10].Value = ys.p_yynx;
                paras[11].Value = "";
                paras[12].Value = ys.p_bz;
                paras[13].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YS.InsertBS_YS", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[13].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ys.p_czfs;
                struct_rz.czxx = ys.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bsbh"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_YS_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_bsbh",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = bsbh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YS.Delete_YS_byBH", paras, out rowsAffected);
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
        #region  编辑
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="YS"></param>
        protected void Update_YS(Struct_YS ys)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_bsbh",OracleType.VarChar),
                  new OracleParameter("p_bsyg",OracleType.VarChar),
                  new OracleParameter("p_bsgw",OracleType.VarChar),
                  new OracleParameter("p_bslx",OracleType.VarChar),
                  new OracleParameter("p_bsip",OracleType.VarChar),
                  new OracleParameter("p_bssj",OracleType.DateTime),
                  new OracleParameter("p_sqbm",OracleType.VarChar),
                  new OracleParameter("p_ysze",OracleType.VarChar),
                  new OracleParameter("p_ysyt",OracleType.VarChar),
                  new OracleParameter("p_ysly",OracleType.VarChar),
                  new OracleParameter("p_yynx",OracleType.VarChar),
                  new OracleParameter("p_spr",OracleType.VarChar),
                  new OracleParameter("p_bz",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = ys.p_bsbh;
                paras[1].Value = ys.p_bsyg;
                paras[2].Value = ys.p_bsgw;
                paras[3].Value = ys.p_bslx;
                paras[4].Value = ys.p_bsip;
                paras[5].Value = ys.p_bssj;
                paras[6].Value = ys.p_sqbm;
                paras[7].Value = ys.p_ysze;
                paras[8].Value = ys.p_ysyt;
                paras[9].Value = ys.p_ysly;
                paras[10].Value = ys.p_yynx;
                paras[11].Value = "";
                paras[12].Value = ys.p_bz;
                paras[13].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YS.Update_YS", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[13].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ys.p_czfs;
                struct_rz.czxx = ys.p_czxx;
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
