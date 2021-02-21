using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_ZBAP
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bsgw;
        public string p_bslx;
        public string p_bsip;
        public DateTime p_bssj;
        public string p_zbybh;
        public DateTime p_zbsj;
        public string p_zbdd;
        public string p_zblc;
        public string p_spr;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_ZBAP
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bslx;
        public string p_zbybh;
        public string p_zbdd;
        public string p_zblc;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
   public  class OZBAP
    {
       private UserState _us = null;
        private RZ rz = null;
        public OZBAP(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 查询


        /// <summary>
        /// 查询值班安排表信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_ZBAP_Pro(Struct_Select_ZBAP struct_zbap)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bsbh",OracleType.VarChar),
                    new OracleParameter("p_bsyg",OracleType.VarChar),
                    new OracleParameter("p_bslx",OracleType.VarChar),
                    new OracleParameter("p_zbybh",OracleType.VarChar),
                    new OracleParameter("p_zbdd",OracleType.VarChar),
                    new OracleParameter("p_zblc",OracleType.VarChar),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_zbap.p_bsbh;
                paras[1].Value = struct_zbap.p_bsyg;
                paras[2].Value = struct_zbap.p_bslx;
                paras[3].Value = struct_zbap.p_zbybh;
                paras[4].Value = struct_zbap.p_zbdd;
                paras[5].Value = struct_zbap.p_zblc;
                paras[6].Value = struct_zbap.p_pagesize;
                paras[7].Value = struct_zbap.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_ZBAP.Select_ZBAP_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询值班安排信息数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_ZBAP_Count(Struct_Select_ZBAP struct_zbap)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bsbh",OracleType.VarChar),
                                           new OracleParameter("p_bsyg",OracleType.VarChar),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_zbybh",OracleType.VarChar),
                                           new OracleParameter("p_zbdd",OracleType.VarChar),
                                           new OracleParameter("p_zblc",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = struct_zbap.p_bsbh;
                paras[1].Value = struct_zbap.p_bsyg;
                paras[2].Value = struct_zbap.p_bslx;
                paras[3].Value = struct_zbap.p_zbybh;
                paras[4].Value = struct_zbap.p_zbdd;
                paras[5].Value = struct_zbap.p_zblc;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_ZBAP.Select_ZBAP_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="bsbh"></param>
        /// <returns></returns>
        protected DataTable Select_ZBAP_Detail(string bsbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bsbh",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bsbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_ZBAP.Select_ZBAP_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 查询十位流水号
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected string SelectBS_ZBAPMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                                           new OracleParameter("p_maxbh",OracleType.VarChar,16)
                  };
                paras[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_ZBAP.SelectBS_ZBAPMaxBH", paras, "tables");
                string maxbh = "";
                maxbh = paras[0].Value.ToString();
                return maxbh;


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
        protected void Delete_ZBAP_byBH(string bsbh, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_HWZHBS_ZBAP.Delete_ZBAP_byBH", paras, out rowsAffected);
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
        /// 添加
        /// </summary>
        /// <param name="zbap"></param>
        protected void Insert_ZBAP(Struct_ZBAP zbap)
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
                  new OracleParameter("p_zbybh",OracleType.VarChar),
                  new OracleParameter("p_zbsj",OracleType.DateTime),
                  new OracleParameter("p_zbdd",OracleType.VarChar),
                  new OracleParameter("p_zblc",OracleType.VarChar),
                  new OracleParameter("p_spr",OracleType.VarChar),
                  new OracleParameter("p_bz",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = zbap.p_bsbh;
                paras[1].Value = zbap.p_bsyg;
                paras[2].Value = zbap.p_bsgw;
                paras[3].Value = zbap.p_bslx;
                paras[4].Value = zbap.p_bsip;
                paras[5].Value = zbap.p_bssj;
                paras[6].Value = zbap.p_zbybh;
                paras[7].Value = zbap.p_zbsj;
                paras[8].Value = zbap.p_zbdd;
                paras[9].Value = zbap.p_zblc;
                paras[10].Value = zbap.p_spr;
                paras[11].Value = zbap.p_bz;
                paras[12].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZBAP.Insert_ZBAP", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zbap.p_czfs;
                struct_rz.czxx = zbap.p_czxx;
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
        /// <param name="zbap"></param>
        protected void Update_ZBAP(Struct_ZBAP zbap)
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
                  new OracleParameter("p_zbybh",OracleType.VarChar),
                  new OracleParameter("p_zbsj",OracleType.DateTime),
                  new OracleParameter("p_zbdd",OracleType.VarChar),
                  new OracleParameter("p_zblc",OracleType.VarChar),
                  new OracleParameter("p_spr",OracleType.VarChar),
                  new OracleParameter("p_bz",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = zbap.p_bsbh;
                paras[1].Value = zbap.p_bsyg;
                paras[2].Value = zbap.p_bsgw;
                paras[3].Value = zbap.p_bslx;
                paras[4].Value = zbap.p_bsip;
                paras[5].Value = zbap.p_bssj;
                paras[6].Value = zbap.p_zbybh;
                paras[7].Value = zbap.p_zbsj;
                paras[8].Value = zbap.p_zbdd;
                paras[9].Value = zbap.p_zblc;
                paras[10].Value = zbap.p_spr;
                paras[11].Value = zbap.p_bz;
                paras[12].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZBAP.Update_ZBAP", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zbap.p_czfs;
                struct_rz.czxx = zbap.p_czxx;
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
