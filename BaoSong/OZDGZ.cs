using System;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_ZDGZ
    {
        public int p_id;
        public string p_bsbh;
        public string p_bsyg;
        public string p_bsgw;
        public string p_bslx;
        public string p_bsip;
        public DateTime p_bssj;
        public string p_bszx;
        public string p_zdgznr;
        public string p_zxzx;
        public string p_gzfzr;
        public int p_gzlc;
        public string p_spr;
        public string p_bz;
        public string p_gzbt;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bmdm;//部门    
        public string p_bhyy;//驳回原因
        public string p_czfs;//操作方式
        public string p_czxx;//操作类型
        public string p_zt;//状态代码
    }
    public struct Struct_Select_ZDGZ
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_xm;
        public string p_bszx;
        public string p_zxzx;
        public string p_bslx;
        public int p_userid;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_gzbt;
        public string p_zt;//状态代码
        public int p_id;

        public string p_bsgw;

        public string p_bsip;
        public DateTime p_bssj;

        public string p_zdgznr;

        public string p_gzfzr;
        public int p_gzlc;
        public string p_spr;
        public string p_bz;

        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bmdm;//部门    
        public string p_bhyy;//驳回原因
        public string p_czfs;//操作方式
        public string p_czxx;//操作类型

    }
    public class OZDGZ
    {
        private UserState _us = null;
        private RZ rz = null;
        public OZDGZ(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询重点工作表基本信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable SelectBS_ZDGZ_Pro(Struct_Select_ZDGZ struct_select_zdgz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bsbh",OracleType.VarChar),
                    new OracleParameter("p_bsyg",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bszx",OracleType.VarChar),
                //    new OracleParameter("p_bslx",OracleType.VarChar),
                    new OracleParameter("p_zxzx",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                   
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_select_zdgz.p_bsbh;
                paras[1].Value = struct_select_zdgz.p_bsyg;
                paras[2].Value = struct_select_zdgz.p_xm;
                paras[3].Value = struct_select_zdgz.p_bszx;
              //  paras[4].Value = struct_select_zdgz.p_bslx;
                paras[4].Value = struct_select_zdgz.p_zxzx;
                paras[5].Value = struct_select_zdgz.p_zt;
                paras[6].Value = struct_select_zdgz.p_userid;
                paras[7].Value = struct_select_zdgz.p_pagesize;
                paras[8].Value = struct_select_zdgz.p_currentpage;
                
                paras[9].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_ZDGZ.SelectBS_ZDGZ_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询重点工作数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int SelectBS_ZDGZ_Count(Struct_Select_ZDGZ struct_select_zdgz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bsbh",OracleType.VarChar),
                    new OracleParameter("p_bsyg",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bszx",OracleType.VarChar),
                //    new OracleParameter("p_bslx",OracleType.VarChar),
                    new OracleParameter("p_zxzx",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = struct_select_zdgz.p_bsbh;
                paras[1].Value = struct_select_zdgz.p_bsyg;
                paras[2].Value = struct_select_zdgz.p_xm;
                paras[3].Value = struct_select_zdgz.p_bszx;
             //   paras[4].Value = struct_select_zdgz.p_bslx;
                paras[4].Value = struct_select_zdgz.p_zxzx;
                paras[5].Value = struct_select_zdgz.p_zt;
                paras[6].Value = struct_select_zdgz.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_ZDGZ.SelectBS_ZDGZ_Count", paras, "tables");
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
                dt = dbclass.RunProcedure("PACK_HWZHBS_ZDGZ.SelectBS_FZR_byBMDM", paras, "table").Tables[0];
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
        protected DataTable SelectBS_ZDGZ_Detail(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_id",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_ZDGZ.SelectBS_ZDGZ_Detail", paras, "table").Tables[0];
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
        protected string SelectBS_ZDGZMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                                           new OracleParameter("p_maxbh",OracleType.VarChar,16)
                  };
                paras[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_ZDGZ.SelectBS_ZDGZMaxBH", paras, "tables");
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
        /// 删除重点工作信息
        /// </summary>
        /// <param name="bsbh"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>

        protected void DeleteBS_ZDGZ_byBH(int id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_id",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZDGZ.DeleteBS_ZDGZ_byBH", paras, out rowsAffected);
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
        protected void InsertBS_ZDGZ(Struct_ZDGZ struct_zdgz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                              new OracleParameter("p_id",OracleType.Number),
                                              new OracleParameter("p_bsbh",OracleType.VarChar),
                                              new OracleParameter("p_bsyg",OracleType.VarChar),
                                              new OracleParameter("p_bsgw",OracleType.VarChar),
                                              new OracleParameter("p_bszx",OracleType.VarChar),
                                              new OracleParameter("p_bslx",OracleType.VarChar),
                                              new OracleParameter("p_bsip",OracleType.VarChar),
                                              new OracleParameter("p_bssj",OracleType.DateTime ),
                                              new OracleParameter("p_zdgznr",OracleType.VarChar),
                                              new OracleParameter("p_zxzx",OracleType.VarChar),
                                              new OracleParameter("p_gzfzr",OracleType.VarChar),
                                              new OracleParameter("p_gzlc",OracleType.Number),
                                              new OracleParameter("p_spr",OracleType.VarChar),
                                              new OracleParameter("p_bz",OracleType.VarChar),
                                              new OracleParameter("p_gzbt",OracleType.VarChar),
                                              new OracleParameter("p_bmdm",OracleType.VarChar),
                                              new OracleParameter("p_csr",OracleType.VarChar),
                                              new OracleParameter("p_zsr",OracleType.VarChar),
                                              new OracleParameter("p_lrr",OracleType.VarChar),
                                              new OracleParameter("p_sjc",OracleType.VarChar),
                                              new OracleParameter("p_sjbs",OracleType.VarChar),
                                              new OracleParameter("p_zt",OracleType.VarChar),
                                              new OracleParameter("p_errorCode",OracleType.Int32)
            };
                paras[0].Value = struct_zdgz.p_id;
                paras[1].Value = struct_zdgz.p_bsbh;
                paras[2].Value = struct_zdgz.p_bsyg;
                paras[3].Value = struct_zdgz.p_bsgw;
                paras[4].Value = struct_zdgz.p_bszx;
                paras[5].Value = struct_zdgz.p_bslx;
                paras[6].Value = struct_zdgz.p_bsip;
                paras[7].Value = struct_zdgz.p_bssj;
                paras[8].Value = struct_zdgz.p_zdgznr;
                paras[9].Value = struct_zdgz.p_zxzx;
                paras[10].Value = struct_zdgz.p_gzfzr;
                paras[11].Value = struct_zdgz.p_gzlc;
                paras[12].Value = struct_zdgz.p_spr;
                paras[13].Value = struct_zdgz.p_bz;
                paras[14].Value = struct_zdgz.p_gzbt;
                paras[15].Value = struct_zdgz.p_bmdm;
                paras[16].Value = struct_zdgz.p_csr;
                paras[17].Value = struct_zdgz.p_zsr;
                paras[18].Value = struct_zdgz.p_lrr;
                paras[19].Value = struct_zdgz.p_sjc;
                paras[20].Value = struct_zdgz.p_sjbs;
                paras[21].Value = struct_zdgz.p_zt;
                paras[22].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZDGZ.InsertBS_ZDGZ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[22].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zdgz.p_czfs;
                struct_rz.czxx = struct_zdgz.p_czxx;
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
        protected void UpdateBS_ZDGZ(Struct_ZDGZ struct_zdgz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_id",OracleType.Number),
                                             new OracleParameter("p_bsbh",OracleType.VarChar),
                                             new OracleParameter("p_bsyg",OracleType.VarChar),
                                             new OracleParameter("p_bsgw",OracleType.VarChar),
                                              new OracleParameter("p_bszx",OracleType.VarChar),
                                             new OracleParameter("p_bslx",OracleType.VarChar),
                                             new OracleParameter("p_bsip",OracleType.VarChar),
                                             new OracleParameter("p_bssj",OracleType.DateTime ),
                                             new OracleParameter("p_zdgznr",OracleType.VarChar),
                                             new OracleParameter("p_zxzx",OracleType.VarChar),
                                             new OracleParameter("p_gzfzr",OracleType.VarChar),
                                             new OracleParameter("p_gzlc",OracleType.Number),
                                             new OracleParameter("p_spr",OracleType.VarChar),
                                             new OracleParameter("p_bz",OracleType.VarChar),
                                             new OracleParameter ("p_gzbt",OracleType.VarChar),
                                             new OracleParameter("p_bmdm",OracleType.VarChar),
                                              new OracleParameter("p_csr",OracleType.VarChar),
                                              new OracleParameter("p_zsr",OracleType.VarChar),
                                              new OracleParameter("p_lrr",OracleType.VarChar),
                                             new OracleParameter("p_sjbs",OracleType.VarChar),
                                              new OracleParameter("p_zt",OracleType.VarChar),
                                             new OracleParameter("p_errorCode",OracleType.Int32)
            };
                paras[0].Value = struct_zdgz.p_id;
                paras[1].Value = struct_zdgz.p_bsbh;
                paras[2].Value = struct_zdgz.p_bsyg;
                paras[3].Value = struct_zdgz.p_bsgw;
                paras[4].Value = struct_zdgz.p_bszx;
                paras[5].Value = struct_zdgz.p_bslx;
                paras[6].Value = struct_zdgz.p_bsip;
                paras[7].Value = struct_zdgz.p_bssj;
                paras[8].Value = struct_zdgz.p_zdgznr;
                paras[9].Value = struct_zdgz.p_zxzx;
                paras[10].Value = struct_zdgz.p_gzfzr;
                paras[11].Value = struct_zdgz.p_gzlc;
                paras[12].Value = struct_zdgz.p_spr;
                paras[13].Value = struct_zdgz.p_bz;
                paras[14].Value = struct_zdgz.p_gzbt;
                paras[15].Value = struct_zdgz.p_bmdm;
                paras[16].Value = struct_zdgz.p_csr;
                paras[17].Value = struct_zdgz.p_zsr;
                paras[18].Value = struct_zdgz.p_lrr;
               
                paras[19].Value = struct_zdgz.p_sjbs;
                paras[20].Value = struct_zdgz.p_zt;
                paras[21].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZDGZ.UpdateBS_ZDGZ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[21].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zdgz.p_czfs;
                struct_rz.czxx = struct_zdgz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 变更状态
        //更新状态
        protected void Update_ZDGZZT(Struct_ZDGZ struct_zdgz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Number),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_bhyy",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_zdgz.p_id;
                parament[1].Value = struct_zdgz.p_zt;
                parament[2].Value = struct_zdgz.p_bhyy;
                parament[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_HWZHBS_ZDGZ.Update_ZDGZZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zdgz.p_czfs;
                struct_rz.czxx = struct_zdgz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //变更数据标识
        protected void Update_ZDGZ_SJBS_ZT(Struct_ZDGZ struct_zdgz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_shsj",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_zdgz.p_sjc;
                parament[1].Value = struct_zdgz.p_shsj;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_HWZHBS_ZDGZ.Update_ZDGZ_SJBS_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zdgz.p_czfs;
                struct_rz.czxx = struct_zdgz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_ZDGZ_SJBS_LSSJ_ZT(Struct_ZDGZ struct_zdgz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                new OracleParameter("p_sjc",OracleType.VarChar),
                new OracleParameter("p_errorCode",OracleType.Int32)
            };
                parament[0].Value = struct_zdgz.p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_HWZHBS_ZDGZ.Update_ZDGZ_SJBS_LSSJ_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zdgz.p_czfs;
                struct_rz.czxx = struct_zdgz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将副本数据变为最终数据
        protected void Update_ZDGZ_SJBS_FBSJ_ZT(Struct_ZDGZ struct_zdgz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_zdgz.p_sjc;
                paras[1].Value = struct_zdgz.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZDGZ.Update_ZDGZ_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zdgz.p_czfs;
                struct_rz.czxx = struct_zdgz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }


        #endregion

        #region 生成备份
        protected int ZDGZ_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = SelectBS_ZDGZ_Detail(id);
            //备份数据
            Struct_ZDGZ zdgz_bf = new Struct_ZDGZ();

            zdgz_bf.p_bsbh = dt_detail.Rows[0]["bsbh"].ToString();
            zdgz_bf.p_bsyg = dt_detail.Rows[0]["bsyg"].ToString();
            zdgz_bf.p_bsgw = dt_detail.Rows[0]["bsgw"].ToString();
            zdgz_bf.p_bszx = dt_detail.Rows[0]["bszx"].ToString();
            zdgz_bf.p_bslx = "05";
            zdgz_bf.p_bsip = dt_detail.Rows[0]["bsip"].ToString();
            zdgz_bf.p_bssj = Convert.ToDateTime(dt_detail.Rows[0]["bssj"].ToString());
            zdgz_bf.p_zdgznr = dt_detail.Rows[0]["zdgznr"].ToString();
            zdgz_bf.p_zxzx = dt_detail.Rows[0]["zxzx"].ToString();
            zdgz_bf.p_gzfzr = dt_detail.Rows[0]["gzfzr"].ToString();
            zdgz_bf.p_gzlc = Convert.ToInt32(dt_detail.Rows[0]["gzlc"].ToString());
            zdgz_bf.p_spr = dt_detail.Rows[0]["spr"].ToString();
            zdgz_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            zdgz_bf.p_gzbt = dt_detail.Rows[0]["gzbt"].ToString();
            
            zdgz_bf.p_zt = "0";
        //    zdgz_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            zdgz_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            zdgz_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            zdgz_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            zdgz_bf.p_lrr = _us.userLoginName;
            zdgz_bf.p_sjbs = "2";
            zdgz_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            zdgz_bf.p_shsj = "";
            zdgz_bf.p_czfs = "02";
            zdgz_bf.p_czxx = "重点工作id:" + id + "生成副本数据";
            //插入
            InsertBS_ZDGZ(zdgz_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = zdgz_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_HWZHBS_ZDGZ.Select_ZFGZ_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
    }
}
