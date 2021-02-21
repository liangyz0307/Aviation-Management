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
    public struct Struct_FXY
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bsgw;
        public DateTime p_xtsj;
        public string p_bsip;
        public DateTime p_bssj;
        public string p_zrr;
        public string p_fxymc;
        public string p_fxyfc;
        public string p_fxknx;
        public string p_st;
        public string p_fxcd;
        public string p_hg;
        public string p_fxyzt;
        public string p_fxkzcs;
        public string p_kzzt;
        public string p_kzcsbzhqk;
        public string p_yjcs;
        public string p_zrbm;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
        public string p_fzr;
        public string p_zt;
        public string p_bhyy;
        public string p_bmdm;
        public string p_gwdm;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public int p_id;//当前页码
        public int p_userid;
        public string p_gzqk;
        public string p_sjqk;
        public DateTime p_sfsj;
        public string p_zrdw;
        public string p_tqcz;
        public string p_sbyxqk;
        public DateTime p_bgsj;
        public string p_lxr;

    }
    public struct Struct_Select_FXY
    {
        
    }
    public  class OFXY
    {
        private UserState _us = null;
        private RZ rz = null;
        public OFXY(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 查询

        /// <summary>
        /// 查询负责人
        /// </summary>
        /// <param name="fxy"></param>
        /// <returns></returns>
        protected DataTable Select_FZR(Struct_FXY fxy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                        new OracleParameter("p_bmdm",OracleType.VarChar),
                                        new OracleParameter("p_gwdm",OracleType.VarChar),
                                        new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = fxy.p_bmdm;
                paras[1].Value = fxy.p_gwdm;
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
        /// 查询员风险源分析表信息
        /// </summary>
        /// <param name="fxy"></param>
        /// <returns></returns>
        protected DataTable Select_FXY_Pro(Struct_FXY fxy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                       new OracleParameter("p_bsyg",OracleType.VarChar),
                       new OracleParameter("p_bsgw",OracleType.VarChar),
                       //new OracleParameter("p_fxyzt",OracleType.VarChar),
                       //new OracleParameter("p_kzzt",OracleType.VarChar),
                        new OracleParameter("p_zt",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                       new OracleParameter("p_pagesize",OracleType.Int32),
                       new OracleParameter("p_currentpage",OracleType.Int32),
                       new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = fxy.p_bsyg;
                paras[1].Value = fxy.p_bsgw;
                //paras[2].Value = fxy.p_fxyzt;
                //paras[3].Value = fxy.p_kzzt;
                paras[2].Value = fxy.p_zt;
                paras[3].Value = fxy.p_userid;
                paras[4].Value = fxy.p_pagesize;
                paras[5].Value = fxy.p_currentpage;
                paras[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_FXY.Select_FXY_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询风险源分析数量
        /// </summary>
        /// <param name="fxy"></param>
        /// <returns></returns>
        protected int Select_FXY_Count(Struct_FXY fxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                          new OracleParameter("p_bsyg",OracleType.VarChar),
                          new OracleParameter("p_bsgw",OracleType.VarChar),
                          //new OracleParameter("p_fxyzt",OracleType.VarChar),
                          //new OracleParameter("p_kzzt",OracleType.VarChar),
                          new OracleParameter("p_zt",OracleType.VarChar),
                          new OracleParameter("p_userid",OracleType.Int32),
                          new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = fxy.p_bsyg;
                paras[1].Value = fxy.p_bsgw;
                //paras[2].Value = fxy.p_fxyzt;
                //paras[3].Value = fxy.p_kzzt;
                paras[2].Value = fxy.p_zt;
                paras[3].Value = fxy.p_userid;
                paras[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_FXY.Select_FXY_Count", paras, "tables");
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
        protected DataTable Select_FXY_Detail(string bsbh)
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
                dt = db.RunProcedure("PACK_HWZHBS_FXY.Select_FXY_Detail", paras, "table").Tables[0];
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
                dt = db.RunProcedure("PACK_HWZHBS_FXY.Select_FZR_byBMDM", paras, "table").Tables[0];
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
        protected string SelectBS_FXYMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_HWZHBS_FXY.SelectBS_FXYMaxBH", paras);
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
        protected void Delete_FXY_byBH(string bsbh, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_HWZHBS_FXY.Delete_FXY_byBH", paras, out rowsAffected);
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
        /// <param name="fxy"></param>
        protected void Insert_FXY(Struct_FXY fxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                          new OracleParameter("p_bsbh",OracleType.VarChar),
                                          new OracleParameter("p_bsyg",OracleType.VarChar),
                                          new OracleParameter("p_bsgw",OracleType.VarChar),
                                          //new OracleParameter("p_xtsj",OracleType.DateTime),
                                          //new OracleParameter("p_bsip",OracleType.VarChar),
                                          new OracleParameter("p_bssj",OracleType.DateTime),
                                          new OracleParameter("p_fxymc",OracleType.VarChar),
                                          new OracleParameter("p_fxyfc",OracleType.VarChar),
                                          new OracleParameter("p_st",OracleType.VarChar),
                                         // new OracleParameter("p_fxknx",OracleType.VarChar),
                                         // new OracleParameter("p_fxcd",OracleType.VarChar),
                                          //new OracleParameter("p_hg",OracleType.VarChar),
                                          new OracleParameter("p_zt",OracleType.VarChar),
                                         // new OracleParameter("p_fxkzcs",OracleType.VarChar),
                                          //new OracleParameter("p_kzzt",OracleType.VarChar),
                                         // new OracleParameter("p_kzcsbzhqk",OracleType.VarChar),
                                          //new OracleParameter("p_yjcs",OracleType.VarChar),
                                          new OracleParameter("p_zrbm",OracleType.VarChar),
                                          //new OracleParameter("p_zrr",OracleType.VarChar),
                                          new OracleParameter("p_bz",OracleType.VarChar),

                                          new OracleParameter("p_tqcz",OracleType.VarChar),
                                          new OracleParameter("p_gzqk",OracleType.VarChar),
                                          new OracleParameter("p_sjqk",OracleType.VarChar),
                                          new OracleParameter("p_sbyxqk",OracleType.VarChar),
                                          new OracleParameter("p_sfsj",OracleType.DateTime),
                                          new OracleParameter("p_zrdw",OracleType.VarChar),
                                          new OracleParameter("p_fzr",OracleType.VarChar),
                                          new OracleParameter("p_bgsj",OracleType.DateTime),

                                          //new OracleParameter("p_fxyzt",OracleType.VarChar),
                                          new OracleParameter("p_bhyy",OracleType.VarChar),
                                          new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = fxy.p_bsbh;
                paras[1].Value = fxy.p_bsyg;
                paras[2].Value = fxy.p_bsgw;
                //paras[3].Value = fxy.p_xtsj;
                //paras[4].Value = fxy.p_bsip;
                paras[3].Value = fxy.p_bssj;
                paras[4].Value = fxy.p_fxymc;
                paras[5].Value = fxy.p_fxyfc;
                paras[6].Value = fxy.p_st;
                //paras[9].Value = fxy.p_fxknx;
                //paras[10].Value = fxy.p_fxcd;
                //paras[11].Value = fxy.p_hg;
                paras[7].Value = fxy.p_zt;
                //paras[13].Value = fxy.p_fxkzcs;
                //paras[14].Value = fxy.p_kzzt;
                //paras[15].Value = fxy.p_kzcsbzhqk;
               // paras[16].Value = fxy.p_yjcs;
                paras[8].Value = fxy.p_zrbm;
               // paras[18].Value = fxy.p_zrr;
                paras[9].Value = fxy.p_bz;

                paras[10].Value = fxy.p_tqcz;
                paras[11].Value = fxy.p_gzqk;
                paras[12].Value = fxy.p_sjqk;
                paras[13].Value = fxy.p_sbyxqk;
                paras[14].Value = fxy.p_sfsj;
                paras[15].Value = fxy.p_zrdw;
                paras[16].Value = fxy.p_fzr;
                paras[17].Value = fxy.p_bgsj;
                //paras[28].Value = fxy.p_fxyzt;
                paras[18].Value = fxy.p_bhyy;
                paras[19].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_FXY.Insert_FXY", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[19].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = fxy.p_czfs;
                struct_rz.czxx = fxy.p_czxx;
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
        /// <param name="fxy"></param>
        protected void Update_FXY(Struct_FXY fxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                                         new OracleParameter("p_bsbh",OracleType.VarChar),
                                          new OracleParameter("p_bsyg",OracleType.VarChar),
                                          new OracleParameter("p_bsgw",OracleType.VarChar),
                                          //new OracleParameter("p_xtsj",OracleType.DateTime),
                                          //new OracleParameter("p_bsip",OracleType.VarChar),
                                          new OracleParameter("p_bssj",OracleType.DateTime),
                                          new OracleParameter("p_fxymc",OracleType.VarChar),
                                          new OracleParameter("p_fxyfc",OracleType.VarChar),
                                          new OracleParameter("p_st",OracleType.VarChar),
                                         // new OracleParameter("p_fxknx",OracleType.VarChar),
                                         // new OracleParameter("p_fxcd",OracleType.VarChar),
                                          //new OracleParameter("p_hg",OracleType.VarChar),
                                          new OracleParameter("p_zt",OracleType.VarChar),
                                         // new OracleParameter("p_fxkzcs",OracleType.VarChar),
                                          //new OracleParameter("p_kzzt",OracleType.VarChar),
                                         // new OracleParameter("p_kzcsbzhqk",OracleType.VarChar),
                                          //new OracleParameter("p_yjcs",OracleType.VarChar),
                                          new OracleParameter("p_zrbm",OracleType.VarChar),
                                          //new OracleParameter("p_zrr",OracleType.VarChar),
                                          new OracleParameter("p_bz",OracleType.VarChar),

                                          new OracleParameter("p_tqcz",OracleType.VarChar),
                                          new OracleParameter("p_gzqk",OracleType.VarChar),
                                          new OracleParameter("p_sjqk",OracleType.VarChar),
                                          new OracleParameter("p_sbyxqk",OracleType.VarChar),
                                          new OracleParameter("p_sfsj",OracleType.DateTime),
                                          new OracleParameter("p_zrdw",OracleType.VarChar),
                                          new OracleParameter("p_fzr",OracleType.VarChar),
                                          new OracleParameter("p_bgsj",OracleType.DateTime),

                                          //new OracleParameter("p_fxyzt",OracleType.VarChar),
                                          new OracleParameter("p_bhyy",OracleType.VarChar),
                                          new OracleParameter("p_errorCode",OracleType.Int32)
                   };

                paras[0].Value = fxy.p_bsbh;
                paras[1].Value = fxy.p_bsyg;
                paras[2].Value = fxy.p_bsgw;
                //paras[3].Value = fxy.p_xtsj;
                //paras[4].Value = fxy.p_bsip;
                paras[3].Value = fxy.p_bssj;
                paras[4].Value = fxy.p_fxymc;
                paras[5].Value = fxy.p_fxyfc;
                paras[6].Value = fxy.p_st;
                //paras[9].Value = fxy.p_fxknx;
                //paras[10].Value = fxy.p_fxcd;
                //paras[11].Value = fxy.p_hg;
                paras[7].Value = fxy.p_zt;
                //paras[13].Value = fxy.p_fxkzcs;
                //paras[14].Value = fxy.p_kzzt;
                //paras[15].Value = fxy.p_kzcsbzhqk;
                // paras[16].Value = fxy.p_yjcs;
                paras[8].Value = fxy.p_zrbm;
                // paras[18].Value = fxy.p_zrr;
                paras[9].Value = fxy.p_bz;

                paras[10].Value = fxy.p_tqcz;
                paras[11].Value = fxy.p_gzqk;
                paras[12].Value = fxy.p_sjqk;
                paras[13].Value = fxy.p_sbyxqk;
                paras[14].Value = fxy.p_sfsj;
                paras[15].Value = fxy.p_zrdw;
                paras[16].Value = fxy.p_fzr;
                paras[17].Value = fxy.p_bgsj;
                //paras[28].Value = fxy.p_fxyzt;
                paras[18].Value = fxy.p_bhyy;
                paras[19].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_FXY.Update_FXY", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[19].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = fxy.p_czfs;
                struct_rz.czxx = fxy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected void Update_FXYZT(int id, string zt, string bhyy)
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
                db.RunProcedure("PACK_HWZHBS_FXY.Update_FXYZT", paras, out rowsAffected);
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
        #endregion

    }
}
