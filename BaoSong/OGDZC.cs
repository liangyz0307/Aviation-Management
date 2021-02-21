using System;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_GDZC
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bsgw;
        public string p_bslx;
        public string p_bsip;
        public DateTime p_bssj;
        public string p_zcbh;
        public string p_zcmc;
        public string  p_dj;
        public string  p_sl;
        public string p_zclb;
        public string p_syfx;
        public string p_cfdd;
        public string p_sybm;
        public string p_zcly;
        public DateTime p_gzrq;
        public string p_rzxs;
        public DateTime p_rzrq;
        public string p_spr;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;

    }
   
    public struct Struct_Select_GDZC
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_xm;
        public string p_rzxs;
        public string p_zcly;
        public string p_bslx;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OGDZC
    {
        private UserState _us = null;
        private RZ rz = null;
        public OGDZC(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询固定资产表基本信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable SelectBS_GDZC_Pro(Struct_Select_GDZC struct_select_gdzc)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bsbh",OracleType.VarChar),
                    new OracleParameter("p_bsyg",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bslx",OracleType.VarChar),
                    new OracleParameter("p_zcly",OracleType.VarChar),
                    new OracleParameter("p_rzxs",OracleType.VarChar),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_select_gdzc.p_bsbh;
                paras[1].Value = struct_select_gdzc.p_bsyg;
                paras[2].Value = struct_select_gdzc.p_xm;
                paras[3].Value = struct_select_gdzc.p_bslx;
                paras[4].Value = struct_select_gdzc.p_zcly;
                paras[5].Value = struct_select_gdzc.p_rzxs;
                paras[6].Value = struct_select_gdzc.p_pagesize;
                paras[7].Value = struct_select_gdzc.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_GDZC.SelectBS_GDZC_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询固定资产数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int SelectBS_GDZC_Count(Struct_Select_GDZC struct_select_gdzc)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_bsbh",OracleType.VarChar),
                                             new OracleParameter("p_bsyg",OracleType.VarChar),
                                             new OracleParameter("p_xm",OracleType.VarChar),
                                             new OracleParameter("p_bslx",OracleType.VarChar),
                                             new OracleParameter("p_zcly",OracleType.VarChar),
                                             new OracleParameter("p_rzxs",OracleType.VarChar),
                                             new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = struct_select_gdzc.p_bsbh;
                paras[1].Value = struct_select_gdzc.p_bsyg;
                paras[2].Value = struct_select_gdzc.p_xm;
                paras[3].Value = struct_select_gdzc.p_bslx;
                paras[4].Value = struct_select_gdzc.p_zcly;
                paras[5].Value = struct_select_gdzc.p_rzxs;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_GDZC.SelectBS_GDZC_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 根据部门代码查询工作负责人
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable SelectBS_FZR_byBMDM(string bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bmdm;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_GDZC.SelectBS_FZR_byBMDM", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="bsbh"></param>
        /// <returns></returns>
        protected DataTable SelectBS_GDZC_Detail(string bsbh)
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
                dt = dbclass.RunProcedure("PACK_HWZHBS_GDZC.SelectBS_GDZC_Detail", paras, "table").Tables[0];
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
        protected string SelectBS_GDZCMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                                           new OracleParameter("p_maxbh",OracleType.VarChar,16)
                  };
                paras[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_GDZC.SelectBS_GDZCMaxBH", paras, "tables");
                string maxbh = "";
                maxbh = paras[0].Value.ToString();
                return maxbh;


            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询资产编号十位流水号
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected string SelectBS_ZCBHMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                                           new OracleParameter("p_maxbh",OracleType.VarChar,16)
                  };
                paras[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_GDZC.SelectBS_ZCBHMaxBH", paras, "tables");
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
        /// 删除工作进展信息
        /// </summary>
        /// <param name="bsbh"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>

        protected void DeleteBS_GDZC_byBH(string p_bsbh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_bsbh",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_bsbh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GDZC.DeleteBS_GDZC_byBH", paras, out rowsAffected);
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
        /// <param name="hb"></param>
        protected void InsertBS_GDZC(Struct_GDZC struct_gdzc)
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
                      new OracleParameter("p_bssj",OracleType.DateTime ),
                      new OracleParameter("p_zcbh",OracleType.VarChar),
                      new OracleParameter("p_zcmc",OracleType.VarChar),
                      new OracleParameter("p_dj",OracleType.Number),
                      new OracleParameter("p_sl",OracleType.Number ),
                      new OracleParameter("p_zclb",OracleType.VarChar ),
                      new OracleParameter("p_syfx",OracleType.VarChar),
                      new OracleParameter("p_cfdd",OracleType.VarChar),
                      new OracleParameter("p_sybm",OracleType.VarChar),
                      new OracleParameter("p_zcly",OracleType.VarChar),
                      new OracleParameter("p_gzrq",OracleType.DateTime),
                      new OracleParameter("p_rzxs",OracleType.VarChar),
                      new OracleParameter("p_rzrq",OracleType.DateTime ),
                      new OracleParameter("p_spr",OracleType.VarChar),
                      new OracleParameter("p_bz",OracleType.VarChar),
                      new OracleParameter("p_errorCode",OracleType.Int32)
            }; paras[0].Value = struct_gdzc.p_bsbh;
                paras[1].Value = struct_gdzc.p_bsyg;
                paras[2].Value = struct_gdzc.p_bsgw;
                paras[3].Value = struct_gdzc.p_bslx;
                paras[4].Value = struct_gdzc.p_bsip;
                paras[5].Value = struct_gdzc.p_bssj;
                paras[6].Value = struct_gdzc.p_zcbh;
                paras[7].Value = struct_gdzc.p_zcmc;
                paras[8].Value = struct_gdzc.p_dj;
                paras[9].Value = struct_gdzc.p_sl;
                paras[10].Value = struct_gdzc.p_zclb;
                paras[11].Value = struct_gdzc.p_syfx;
                paras[12].Value = struct_gdzc.p_cfdd;
                paras[13].Value = struct_gdzc.p_sybm;
                paras[14].Value = struct_gdzc.p_zcly;
                paras[15].Value = struct_gdzc.p_gzrq;
                paras[16].Value = struct_gdzc.p_rzxs;
                paras[17].Value = struct_gdzc.p_rzrq;
                paras[18].Value = struct_gdzc.p_spr;
                paras[19].Value = struct_gdzc.p_bz;
                paras[20].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GDZC.InsertBS_GDZC", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[20].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gdzc.p_czfs;
                struct_rz.czxx = struct_gdzc.p_czxx;
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
        /// <param name="hb"></param>
        protected void UpdateBS_GDZC(Struct_GDZC struct_gdzc)
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
                      new OracleParameter("p_bssj",OracleType.DateTime ),
                      new OracleParameter("p_zcbh",OracleType.VarChar),
                      new OracleParameter("p_zcmc",OracleType.VarChar),
                      new OracleParameter("p_dj",OracleType.Number ),
                      new OracleParameter("p_sl",OracleType.Number ),
                      new OracleParameter("p_zclb",OracleType.VarChar),
                      new OracleParameter("p_syfx",OracleType.VarChar),
                      new OracleParameter("p_cfdd",OracleType.VarChar),
                      new OracleParameter("p_sybm",OracleType.VarChar),
                      new OracleParameter("p_zcly",OracleType.VarChar),
                      new OracleParameter("p_gzrq",OracleType.DateTime),
                      new OracleParameter("p_rzxs",OracleType.VarChar),
                      new OracleParameter("p_rzrq",OracleType.DateTime ),
                      new OracleParameter("p_spr",OracleType.VarChar),
                      new OracleParameter("p_bz",OracleType.VarChar),   
                      new OracleParameter("p_errorCode",OracleType.Int32)
            };
                paras[0].Value = struct_gdzc.p_bsbh;
                paras[1].Value = struct_gdzc.p_bsyg;
                paras[2].Value = struct_gdzc.p_bsgw;
                paras[3].Value = struct_gdzc.p_bslx;
                paras[4].Value = struct_gdzc.p_bsip;
                paras[5].Value = struct_gdzc.p_bssj;
                paras[6].Value = struct_gdzc.p_zcbh;
                paras[7].Value = struct_gdzc.p_zcmc;
                paras[8].Value = struct_gdzc.p_dj;
                paras[9].Value = struct_gdzc.p_sl;
                paras[10].Value = struct_gdzc.p_zclb;
                paras[11].Value = struct_gdzc.p_syfx;
                paras[12].Value = struct_gdzc.p_cfdd;
                paras[13].Value = struct_gdzc.p_sybm;
                paras[14].Value = struct_gdzc.p_zcly;
                paras[15].Value = struct_gdzc.p_gzrq;
                paras[16].Value = struct_gdzc.p_rzxs;
                paras[17].Value = struct_gdzc.p_rzrq;
                paras[18].Value = struct_gdzc.p_spr;
                paras[19].Value = struct_gdzc.p_bz;
                paras[20].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GDZC.UpdateBS_GDZC", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[20].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gdzc.p_czfs;
                struct_rz.czxx = struct_gdzc.p_czxx;
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

