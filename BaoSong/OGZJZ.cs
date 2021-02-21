using System;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_GZJZ
    {
        public string p_bsbh;

        public string p_bzsjc;

        public string p_bsyg;
        public string p_bszx;
        public string p_zxzx;
        public string p_bsip;
        public DateTime p_bssj;
        public DateTime p_bsxtsj;
        public string p_gzzt;
        public string p_gznr;
        public string p_wcjd;
        public DateTime p_wcsx;
        public string p_gzfzr;
        public string  p_gzlc;
        public string p_bz;
        public string p_zt;
        public string p_czfs;
        public string p_czxx;
        public string p_gzbz;
        public DateTime  p_bzwcsx;
        public string p_id;

        public string p_bsbm;
        public string p_bmdm;

        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间

        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码

        public string p_bhyy;

        public string p_yzt;

    }
    public struct Struct_Select_GZJZ
    {

        public string p_bsbm;
        public string p_bszx;
        public string p_zt;
        public string p_bsbh;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_bmdm;

        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bhyy;
    }
    public class OGZJZ
    {
        private UserState _us = null;
        private RZ rz = null;
        public OGZJZ(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询工作进展表基本信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable SelectBS_GZJZ_Pro(Struct_Select_GZJZ struct_select_gzjz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bsbm",OracleType.VarChar),
                                           new OracleParameter("p_bszx",OracleType.VarChar),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_userid",OracleType.Int32),
                                            new OracleParameter("p_pagesize",OracleType.Int32),
                                            new OracleParameter("p_currentpage",OracleType.Int32),
                                            new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_select_gzjz.p_bsbm;
                paras[1].Value = struct_select_gzjz.p_bszx;
                paras[2].Value = struct_select_gzjz.p_zt;
                paras[3].Value = struct_select_gzjz.p_userid;
                paras[4].Value = struct_select_gzjz.p_pagesize;
                paras[5].Value = struct_select_gzjz.p_currentpage;
                paras[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_GZJZ.SelectBS_GZJZ_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询工作进展数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int SelectBS_GZJZ_Count(Struct_Select_GZJZ struct_select_gzjz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bsbm",OracleType.VarChar),
                                           new OracleParameter("p_bszx",OracleType.VarChar),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_userid",OracleType.Int32),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = struct_select_gzjz.p_bsbm;
                paras[1].Value = struct_select_gzjz.p_bszx;
                paras[2].Value = struct_select_gzjz.p_zt;
                paras[3].Value = struct_select_gzjz.p_userid;
                paras[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_GZJZ.SelectBS_GZJZ_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 根据报送员工编号查询工作负责人
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable SelectBS_FZR_byBH(string gzfzr)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_gzfzr",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = gzfzr;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_GZJZ.SelectBS_FZR_byBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 根据部门岗位查人
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable SelectBS_FZR_byBMGW(string bmdm, string gwdm)
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
                dt = dbclass.RunProcedure("PACK_HWZHBS_GZJZ.SelectBS_FZR_byBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
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
                dt = dbclass.RunProcedure("PACK_HWZHBS_GZJZ.SelectBS_FZR_byBMDM", paras, "table").Tables[0];
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
        protected DataTable SelectBS_GZJZ_Detail(string id)
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
                dt = dbclass.RunProcedure("PACK_HWZHBS_GZJZ.SelectBS_GZJZ_Detail", paras, "table").Tables[0];
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
        protected string SelectBS_GZJZMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                                           new OracleParameter("p_maxbh",OracleType.VarChar,16)
                  };
                paras[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_GZJZ.SelectBS_GZJZMaxBH", paras, "tables");
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

        protected void DeleteBS_GZJZ_byBH(string p_bzsjc,string p_zt, string p_sjbs, string p_id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_bzsjc",OracleType.VarChar),
                               new OracleParameter("p_zt",OracleType.VarChar),
                               new OracleParameter("p_sjbs",OracleType.VarChar),
                               new OracleParameter("p_id",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_bzsjc;
                paras[1].Value = p_zt;
                paras[2].Value = p_sjbs;
                paras[3].Value = p_id;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.DeleteBS_GZJZ_byID", paras, out rowsAffected);
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
        protected void InsertBS_GZJZ(Struct_GZJZ struct_gzjz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_bsbh", OracleType.VarChar),
                                             new OracleParameter("p_bsyg", OracleType.VarChar),
                                             new OracleParameter("p_bsbm", OracleType.VarChar),
                                             new OracleParameter("p_bszx", OracleType.VarChar),
                                             new OracleParameter("p_bsip", OracleType.VarChar),
                                             new OracleParameter("p_bssj", OracleType.DateTime ),
                                             new OracleParameter("p_bsxtsj",OracleType.DateTime ),
                                             new OracleParameter("p_gzzt", OracleType.VarChar),
                                             new OracleParameter("p_gznr", OracleType.VarChar),
                                             new OracleParameter("p_wcjd", OracleType.VarChar),
                                             new OracleParameter("p_wcsx", OracleType.DateTime ),
                                             new OracleParameter("p_gzfzr", OracleType.VarChar),
                                             new OracleParameter("p_gzlc", OracleType.VarChar),
                                             new OracleParameter("p_bz", OracleType.VarChar),

                                             new OracleParameter("p_bmdm",OracleType.VarChar),
                                             new OracleParameter("p_csr",OracleType.VarChar),
                                             new OracleParameter("p_zsr",OracleType.VarChar),
                                             new OracleParameter("p_lrr",OracleType.VarChar),
                                             new OracleParameter("p_sjc",OracleType.VarChar),
                                             new OracleParameter("p_sjbs",OracleType.VarChar),
                                             new OracleParameter("p_zt",OracleType.VarChar),
                                             new OracleParameter("p_errorCode",OracleType.Number)
                                           };
                paras[0].Value = struct_gzjz.p_bsbh;
                paras[1].Value = struct_gzjz.p_bsyg;
                paras[2].Value = struct_gzjz.p_bsbm;
                paras[3].Value = struct_gzjz.p_bszx;
                paras[4].Value = struct_gzjz.p_bsip;
                paras[5].Value = struct_gzjz.p_bssj;
                paras[6].Value = struct_gzjz.p_bsxtsj;
                paras[7].Value = struct_gzjz.p_gzzt;
                paras[8].Value = struct_gzjz.p_gznr;
                paras[9].Value = struct_gzjz.p_wcjd;
                paras[10].Value = struct_gzjz.p_wcsx;
                paras[11].Value = struct_gzjz.p_gzfzr;
                paras[12].Value = struct_gzjz.p_gzlc;
                paras[13].Value = struct_gzjz.p_bz;

                paras[14].Value = struct_gzjz.p_bmdm;
                paras[15].Value = struct_gzjz.p_csr;
                paras[16].Value = struct_gzjz.p_zsr;
                paras[17].Value = struct_gzjz.p_lrr;
                paras[18].Value = struct_gzjz.p_sjc;
                paras[19].Value = struct_gzjz.p_sjbs;
                paras[20].Value = struct_gzjz.p_zt;
                paras[21].Direction = ParameterDirection.Output;
                int rowsAffected = 0; 
                db.RunProcedure("PACK_HWZHBS_GZJZ.InsertBS_GZJZ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[21].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gzjz.p_czfs;
                struct_rz.czxx = struct_gzjz.p_czxx;
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
        protected void UpdateBS_GZJZ(Struct_GZJZ struct_gzjz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_id",OracleType.VarChar),
                                             new OracleParameter("p_bsyg",OracleType.VarChar),
                                             new OracleParameter("p_bsbh",OracleType.VarChar),
                                             new OracleParameter("p_bsbm",OracleType.VarChar),                                          
                                             new OracleParameter("p_bsip",OracleType.VarChar),
                                             new OracleParameter("p_bssj",OracleType.DateTime ),
                                             new OracleParameter("p_bszx",OracleType.VarChar),
                                             new OracleParameter("p_gzzt",OracleType.VarChar),
                                             new OracleParameter("p_gznr",OracleType.VarChar),
                                             new OracleParameter("p_wcjd",OracleType.VarChar),
                                             new OracleParameter("p_gzfzr",OracleType.VarChar),
                                             new OracleParameter("p_gzlc",OracleType.Number),
                                             new OracleParameter("p_bz",OracleType.VarChar),
                                             new OracleParameter("p_wcsx",OracleType.DateTime),
                                             new OracleParameter("p_bsxtsj",OracleType.DateTime),

                                             new OracleParameter("p_bmdm",OracleType.VarChar),
                                             new OracleParameter("p_csr",OracleType.VarChar),
                                             new OracleParameter("p_zsr",OracleType.VarChar),
                                             new OracleParameter("p_lrr",OracleType.VarChar),
                                             new OracleParameter("p_sjbs",OracleType.VarChar),
                                             new OracleParameter("p_zt",OracleType.VarChar),
                                             new OracleParameter("p_errorCode",OracleType.Number)
            };
                paras[0].Value = struct_gzjz.p_id;
                paras[1].Value = struct_gzjz.p_bsyg; 
                paras[2].Value = struct_gzjz.p_bsbh;
                paras[3].Value = struct_gzjz.p_bsbm;
                paras[4].Value = struct_gzjz.p_bsip;
                paras[5].Value = struct_gzjz.p_bssj;
                paras[6].Value = struct_gzjz.p_bszx;
                paras[7].Value = struct_gzjz.p_gzzt;
                paras[8].Value = struct_gzjz.p_gznr;
                paras[9].Value = struct_gzjz.p_wcjd;
                paras[10].Value = struct_gzjz.p_gzfzr;
                paras[11].Value = struct_gzjz.p_gzlc;
                paras[12].Value = struct_gzjz.p_bz;
                paras[13].Value = struct_gzjz.p_wcsx;
                paras[14].Value = struct_gzjz.p_bsxtsj;

                paras[15].Value = struct_gzjz.p_bmdm;
                paras[16].Value = struct_gzjz.p_csr;
                paras[17].Value = struct_gzjz.p_zsr;
                paras[18].Value = struct_gzjz.p_lrr;
                paras[19].Value = struct_gzjz.p_sjbs;
                paras[20].Value = struct_gzjz.p_zt;
                paras[21].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.UpdateBS_GZJZ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[21].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gzjz.p_czfs;
                struct_rz.czxx = struct_gzjz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  工作步骤
        protected void  Insert_gzjz_bz(Struct_GZJZ struct_gzjz)
        { 
            DBClass db=new DBClass();
            try
            {
                OracleParameter[] paras ={                                  
                                        new OracleParameter("p_bzsjc",OracleType.VarChar),
                                        new OracleParameter("p_gzbz",OracleType.VarChar),
                                        new OracleParameter("p_wcsx",OracleType.DateTime),
                                        new OracleParameter("p_sjbs",OracleType.VarChar),
                                        new OracleParameter("p_zt",OracleType.VarChar),
                                        new OracleParameter("p_errorCode",OracleType.Number)
                                  };

                paras[0].Value = struct_gzjz.p_bzsjc;
                paras[1].Value = struct_gzjz.p_gzbz;
                paras[2].Value = struct_gzjz.p_bzwcsx;
                paras[3].Value = struct_gzjz.p_sjbs;
                paras[4].Value = struct_gzjz.p_zt;

                paras[5].Direction = ParameterDirection.Output;
                int rowAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Insert_gzjz_bz", paras, out  rowAffected);
                int errorCode = 0;
                if (errorCode > 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gzjz.p_czfs;
                struct_rz.czxx = struct_gzjz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally {
                db.Close();
            }
        }
        protected void Update_gzjz_bz(Struct_GZJZ struct_gzjz)
        {
            DBClass db=new DBClass ();
            try
            {
                OracleParameter[] paras ={ 
                                         new OracleParameter("p_id",OracleType.VarChar),
                                         new OracleParameter ("p_gzbz",OracleType.VarChar),
                                         new OracleParameter("p_wcsx",OracleType.DateTime),
                                         new OracleParameter ("p_errorCode",OracleType.Number)
                };
                paras[0].Value = struct_gzjz.p_id;
                paras[1].Value = struct_gzjz.p_gzbz;
                paras[2].Value = struct_gzjz.p_bzwcsx;
                paras[3].Direction = ParameterDirection.Output;
                int rowAfffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Update_gzjz_bz",paras,out rowAfffected);
                int errorCode = 0;
                if (errorCode > 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gzjz.p_czfs;
                struct_rz.czxx = struct_gzjz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);

            }
            finally
            {
                db.Close();
            }
        
        
        }
        protected void Delete_gzjz_bz(string bzsjc,string zt, string sjbs,string czfs,string czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = { 
                                          new  OracleParameter("p_bzsjc",OracleType.VarChar),
                                          new  OracleParameter("p_zt",OracleType.VarChar),
                                          new  OracleParameter("p_sjbs",OracleType.VarChar)
                                          };
                paras[0].Value = bzsjc;
                paras[0].Value = zt;
                paras[0].Value = sjbs;
                int rowAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Delete_gzjz_bz",paras,out rowAffected);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = czfs;
                struct_rz.czxx = czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        
        }
        protected void Delete_gzjzbz_id(string id)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = { 
                                          new  OracleParameter("p_id",OracleType.VarChar)
                                          };
                paras[0].Value = id;
                int rowAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Delete_gzjzbz_id", paras, out rowAffected);
                //插入日志表
                //Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                //struct_rz.czfs = czfs;
                //struct_rz.czxx = czxx;
                //rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }

        }
        protected DataTable Select_gzjz_bz(string bzsjc, string zt, string sjbs)
        {
            DBClass db = new DBClass();
            OracleParameter[] paras ={ 
                                    new  OracleParameter("p_bzsjc",OracleType.VarChar),
                                    new  OracleParameter("p_zt",OracleType.VarChar),
                                    new  OracleParameter("p_sjbs",OracleType.VarChar),
                                    new OracleParameter ("p_cur",OracleType.Cursor)
                                    };

            paras[0].Value = bzsjc;
            paras[1].Value = zt;
            paras[2].Value = sjbs;
            paras[3].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt=db.RunProcedure("PACK_HWZHBS_GZJZ.Select_gzjz_bz",paras,"table").Tables[0];
            return dt;
        }
        protected int Select_gzjz_bz_count(string bzsjc, string zt, string sjbs)
        {
            DBClass db = new DBClass();
            OracleParameter[] paras ={
                                    new  OracleParameter("p_bzsjc",OracleType.VarChar),
                                    new  OracleParameter("p_zt",OracleType.VarChar),
                                    new  OracleParameter("p_sjbs",OracleType.VarChar),
                                    new OracleParameter ("p_cur",OracleType.Cursor)
                                    };

            paras[0].Value = bzsjc;
            paras[1].Value = zt;
            paras[2].Value = sjbs;
            paras[3].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = db.RunProcedure("PACK_HWZHBS_GZJZ.Select_gzjz_bz_count", paras, "table").Tables[0];
            return  Convert.ToInt32(dt.Rows[0][0].ToString());
        }
        #endregion

        #region 更新状态
        protected void Update_GZJZZT(Struct_GZJZ struct_zgjz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_sjbs",OracleType.VarChar),
                  new OracleParameter("p_bzsjc",OracleType.VarChar),
                  new OracleParameter("p_yzt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_zgjz.p_id;
                paras[1].Value = struct_zgjz.p_zt;
                paras[2].Value = struct_zgjz.p_bhyy;
                paras[3].Value = struct_zgjz.p_sjbs;
                paras[4].Value = struct_zgjz.p_bzsjc;
                paras[5].Value = struct_zgjz.p_yzt;
                paras[6].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Update_GZJZZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[6].Value);
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

        //变更数据标识
        protected void Update_GZJZ_SJBS_ZT(Struct_GZJZ struct_gzjz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_gzjz.p_sjc;
                paras[1].Value = struct_gzjz.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Update_GZJZ_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gzjz.p_czfs;
                struct_rz.czxx = struct_gzjz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_GZJZ_SJBS_LSSJ_ZT(Struct_GZJZ struct_gzjz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_gzjz.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Update_GZJZ_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gzjz.p_czfs;
                struct_rz.czxx = struct_gzjz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }




        #region 将副本数据变为最终数据
        protected void Update_GZJZ_SJBS_FBSJ_ZT(Struct_GZJZ struct_gzjz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_gzjz.p_sjc;
                paras[1].Value = struct_gzjz.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_GZJZ.Update_GZJZ_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_gzjz.p_czfs;
                struct_rz.czxx = struct_gzjz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        protected int GZJZ_SJBF(int id )
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = SelectBS_GZJZ_Detail(Convert.ToString(id));

            #region 工作进展备份
            //备份数据
            Struct_GZJZ gzjz_bf = new Struct_GZJZ();

            gzjz_bf.p_bsbh = dt_detail.Rows[0]["bsbh"].ToString();
            gzjz_bf.p_bsyg = dt_detail.Rows[0]["bsyg"].ToString();
            gzjz_bf.p_bsbm = dt_detail.Rows[0]["bsbm"].ToString();
            gzjz_bf.p_bszx = dt_detail.Rows[0]["bszx"].ToString();
            gzjz_bf.p_bsip = dt_detail.Rows[0]["bsip"].ToString();
            gzjz_bf.p_bssj = Convert.ToDateTime(dt_detail.Rows[0]["bssj"].ToString());
            gzjz_bf.p_bsxtsj = Convert.ToDateTime(dt_detail.Rows[0]["bsxtsj"].ToString());
            gzjz_bf.p_gzzt = dt_detail.Rows[0]["gzzt"].ToString();
            gzjz_bf.p_gznr = dt_detail.Rows[0]["gznr"].ToString();
            gzjz_bf.p_wcjd = dt_detail.Rows[0]["wcjd"].ToString();
            gzjz_bf.p_wcsx = Convert.ToDateTime(dt_detail.Rows[0]["wcsx"].ToString());
            gzjz_bf.p_gzfzr = dt_detail.Rows[0]["gzfzr"].ToString();
            gzjz_bf.p_gzlc = dt_detail.Rows[0]["gzlc"].ToString();
            gzjz_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();


            gzjz_bf.p_zt = "0";
            gzjz_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            gzjz_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            gzjz_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            gzjz_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            gzjz_bf.p_lrr = _us.userLoginName;
            gzjz_bf.p_sjbs = "2";
            gzjz_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            gzjz_bf.p_shsj = "";
            gzjz_bf.p_czfs = "02";
            gzjz_bf.p_czxx = "工作进展id:" + id + "生成副本数据";
            //插入
            InsertBS_GZJZ(gzjz_bf);
            #endregion
            //查询ID
            #region 工作进展备份
            int gzjz_bz_count = Select_gzjz_bz_count(dt_detail.Rows[0]["sjc"].ToString(), dt_detail.Rows[0]["zt"].ToString(), dt_detail.Rows[0]["sjbs"].ToString());
            DataTable dt_detail_bz = new DataTable();
            dt_detail_bz = Select_gzjz_bz(dt_detail.Rows[0]["sjc"].ToString(), dt_detail.Rows[0]["zt"].ToString(), dt_detail.Rows[0]["sjbs"].ToString());
            for (int i = 0; i < gzjz_bz_count; i++)
            {
                gzjz_bf.p_bzsjc = dt_detail_bz.Rows[i]["bzsjc"].ToString();
                gzjz_bf.p_gzbz = dt_detail_bz.Rows[i]["gzbz"].ToString();
                gzjz_bf.p_bzwcsx = Convert.ToDateTime(dt_detail_bz.Rows[i]["wcsx"].ToString());
                gzjz_bf.p_sjbs = "2";
                gzjz_bf.p_zt = "0";

                gzjz_bf.p_czfs = "02";
                gzjz_bf.p_czxx = "工作进展步骤:" + id + "生成副本数据";

                Insert_gzjz_bz(gzjz_bf);
            }
            #endregion
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = gzjz_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_HWZHBS_GZJZ.Select_GZJZ_BFID", parament, out reslut);

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
