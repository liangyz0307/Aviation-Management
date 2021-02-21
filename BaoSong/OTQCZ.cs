
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
   
    public struct Struct_TQCZ
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bsgw;
        public string p_bsip;
        public DateTime p_bssj;
        public string p_gzqk;
        public string p_sjqk;
        public string p_sbyxqk;
        public DateTime p_sfsj;
        public string p_zrdw;
        public string p_lxr;
        public DateTime p_bgsj;
        public string p_spr;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
        public string p_fzr;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_zt;
        public string p_bhyy;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public DateTime p_xtsj;
        public string p_bmdm;
        public string p_gwdm;
        public int p_userid;
        public int id;
    }
   
    public class OTQCZ
    {
        private UserState _us = null;
        private RZ rz = null;
        public OTQCZ(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询员工资质表信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_TQCZ_Pro(Struct_TQCZ tqcz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                            new OracleParameter("p_bsyg",OracleType.VarChar),
                                            new OracleParameter("p_bsgw",OracleType.VarChar),
                                            new OracleParameter("p_kssj",OracleType.DateTime),
                                            new OracleParameter("p_jssj",OracleType.DateTime),
                                            new OracleParameter("p_zt",OracleType.VarChar),
                                            new OracleParameter("p_userid",OracleType.Int32),
                                            new OracleParameter("p_pagesize",OracleType.Int32),
                                            new OracleParameter("p_currentpage",OracleType.Int32),
                                            new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = tqcz.p_bsyg;
                paras[1].Value = tqcz.p_bsgw;
                paras[2].Value = tqcz.p_kssj;
                paras[3].Value = tqcz.p_jssj;
                paras[4].Value = tqcz.p_zt;
                paras[5].Value = tqcz.p_userid;
                paras[6].Value = tqcz.p_pagesize;
                paras[7].Value = tqcz.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_TQCZ.Select_TQCZ_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询员工资质数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_TQCZ_Count(Struct_TQCZ tqcz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                            new OracleParameter("p_bsyg",OracleType.VarChar),
                                            new OracleParameter("p_bsgw",OracleType.VarChar),
                                            new OracleParameter("p_kssj",OracleType.DateTime),
                                            new OracleParameter("p_jssj",OracleType.DateTime),
                                            new OracleParameter("p_zt",OracleType.VarChar),
                                            new OracleParameter("p_userid",OracleType.Int32),
                                             new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = tqcz.p_bsyg;
                paras[1].Value = tqcz.p_bsgw;
                paras[2].Value = tqcz.p_kssj;
                paras[3].Value = tqcz.p_jssj;
                paras[4].Value = tqcz.p_zt;
                paras[5].Value = tqcz.p_userid;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_TQCZ.Select_TQCZ_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 查询负责人
        /// </summary>
        /// <param name="fxy"></param>
        /// <returns></returns>
        protected DataTable Select_FZR(Struct_TQCZ tqcz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                        new OracleParameter("p_bmdm",OracleType.VarChar),
                                        new OracleParameter("p_gwdm",OracleType.VarChar),
                                        new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = tqcz.p_bmdm;
                paras[1].Value = tqcz.p_gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_FXY.Select_FZR", paras, "table").Tables[0];
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
        protected DataTable Select_TQCZ_Detail(string bsbh)
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
                dt = db.RunProcedure("PACK_HWZHBS_TQCZ.Select_TQCZ_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 查询负责人
        /// </summary>
        /// <param name="bmdm"></param>
        /// <returns></returns>
        protected DataTable Select_FZR_byBMDM(string bmdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bmdm;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_HWZHBS_TQCZ.Select_FZR_byBMDM", paras, "table").Tables[0];
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
        protected string SelectBS_TQCZMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_HWZHBS_TQCZ.SelectBS_TQCZMaxBH", paras);
                string maxbh = paras[0].Value.ToString();
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
        protected void Delete_TQCZ_byBH(string bsbh, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_HWZHBS_TQCZ.Delete_TQCZ_byBH", paras, out rowsAffected);
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
        /// <param name="tqcz"></param>
        protected void Insert_TQCZ(Struct_TQCZ tqcz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                          new OracleParameter("p_bsbh",OracleType.VarChar),
                                          new OracleParameter("p_bsyg",OracleType.VarChar),
                                          new OracleParameter("p_bsgw",OracleType.VarChar),
                                          new OracleParameter("p_xtsj",OracleType.DateTime),
                                          new OracleParameter("p_bsip",OracleType.VarChar),
                                          new OracleParameter("p_bssj",OracleType.DateTime),
                                          new OracleParameter("p_gzqk",OracleType.VarChar),
                                          new OracleParameter("p_sjqk",OracleType.VarChar),
                                          new OracleParameter("p_sbyxqk",OracleType.VarChar),
                                          new OracleParameter("p_sfsj",OracleType.DateTime),
                                          new OracleParameter("p_zrdw",OracleType.VarChar),
                                          new OracleParameter("p_lxr",OracleType.VarChar),
                                          new OracleParameter("p_bgsj",OracleType.DateTime),
                                          new OracleParameter("p_bz",OracleType.VarChar),
                                          new OracleParameter("p_zt",OracleType.VarChar),
                                          new OracleParameter("p_bhyy",OracleType.VarChar),
                                          new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = tqcz.p_bsbh;
                paras[1].Value = tqcz.p_bsyg;
                paras[2].Value = tqcz.p_bsgw;
                paras[3].Value = tqcz.p_xtsj;
                paras[4].Value = tqcz.p_bsip;
                paras[5].Value = tqcz.p_bssj;
                paras[6].Value = tqcz.p_gzqk;
                paras[7].Value = tqcz.p_sjqk;
                paras[8].Value = tqcz.p_sbyxqk;
                paras[9].Value = tqcz.p_sfsj;
                paras[10].Value = tqcz.p_zrdw;
                paras[11].Value = tqcz.p_lxr;
                paras[12].Value = tqcz.p_bgsj;
                paras[13].Value = tqcz.p_bz;
                paras[14].Value = tqcz.p_zt;
                paras[15].Value = tqcz.p_bhyy;
                paras[16].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_TQCZ.Insert_TQCZ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[16].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = tqcz.p_czfs;
                struct_rz.czxx = tqcz.p_czxx;
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
        /// <param name="tqcz"></param>
        protected void Update_TQCZ(Struct_TQCZ tqcz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                          new OracleParameter("p_bsbh",OracleType.VarChar),
                                          new OracleParameter("p_bsyg",OracleType.VarChar),
                                          new OracleParameter("p_bsgw",OracleType.VarChar),
                                          new OracleParameter("p_xtsj",OracleType.DateTime),
                                          new OracleParameter("p_bsip",OracleType.VarChar),
                                          new OracleParameter("p_bssj",OracleType.DateTime),
                                          new OracleParameter("p_gzqk",OracleType.VarChar),
                                          new OracleParameter("p_sjqk",OracleType.VarChar),
                                          new OracleParameter("p_sbyxqk",OracleType.VarChar),
                                          new OracleParameter("p_sfsj",OracleType.DateTime),
                                          new OracleParameter("p_zrdw",OracleType.VarChar),
                                          new OracleParameter("p_lxr",OracleType.VarChar),
                                          new OracleParameter("p_bgsj",OracleType.DateTime),
                                          new OracleParameter("p_bz",OracleType.VarChar),
                                            new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = tqcz.p_bsbh;
                paras[1].Value = tqcz.p_bsyg;
                paras[2].Value = tqcz.p_bsgw;
                paras[3].Value = tqcz.p_xtsj;
                paras[4].Value = tqcz.p_bsip;
                paras[5].Value = tqcz.p_bssj;
                paras[6].Value = tqcz.p_gzqk;
                paras[7].Value = tqcz.p_sjqk;
                paras[8].Value = tqcz.p_sbyxqk;
                paras[9].Value = tqcz.p_sfsj;
                paras[10].Value = tqcz.p_zrdw;
                paras[11].Value = tqcz.p_lxr;
                paras[12].Value = tqcz.p_bgsj;
                paras[13].Value = tqcz.p_bz;
                paras[14].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_TQCZ.Update_TQCZ", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[14].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = tqcz.p_czfs;
                struct_rz.czxx = tqcz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        protected void Update_TQCZZT(int id, string zt, string bhyy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Int32),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = id;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_TQCZ.Update_TQCZZT", paras, out rowsAffected);
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



    }
}
