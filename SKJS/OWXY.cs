using Sys;
using CUST.MKG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;

namespace CUST.MKG
{

       public struct Struct_WXY
        {
        public int p_id;
        public string p_mc;
        public string p_gw;
        public string p_fc;
        public string p_yy;
        public string p_hg;
        public string p_xgal;
        public int p_yf;
        public string p_st;
        public string p_knx;
        public string p_yzx;
        public string p_fxcd;
        public string p_zt;
        public string p_yj;
        public string p_kzzt;
        public string p_bzhqk;
        public string p_ya;
        public string p_bmej;
        public string p_bmsj;
        public string p_zrr;
        public string p_phbm;
        public int p_errorCode;
        public string p_czfs;
        public string p_czxx;
        public int p_pagesize;
        public int p_currentpage;
        public int p_userid;
        public string p_bmdm;
        public string p_bhyy;

        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
        public class OWXY
        {
            private UserState _us = null;
            private RZ rz = null;
            public OWXY(UserState userstate)
            {
                this._us = userstate;
                rz = new RZ(userstate);
            }
           #region 检索危险源数量
           protected int Select_WXY_Count(Struct_WXY struct_select_wxy)
           {
                DBClass db = new DBClass();
                try
                {
                    OracleParameter[] parament ={
                                                     new OracleParameter("p_mc",OracleType.NVarChar),
                                                     new OracleParameter("p_gw",OracleType.NVarChar),
                                                     new OracleParameter("p_zt",OracleType.NVarChar),
                                                     new OracleParameter("p_kzzt",OracleType.NVarChar),
                                                     new OracleParameter("p_userid",OracleType.Int32),
                                                     new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                     parament[0].Value = struct_select_wxy.p_mc;
                     parament[1].Value = struct_select_wxy.p_gw;
                     parament[2].Value = struct_select_wxy.p_zt;
                     parament[3].Value = struct_select_wxy.p_kzzt;
                     parament[4].Value = struct_select_wxy.p_userid;
                     parament[5].Direction = ParameterDirection.Output;
                     DataSet ds = new DataSet();
                     ds = db.RunProcedure("PACK_SKJS_WXY.SELECT_WXY_COUNT", parament, "table");
                     return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
         }
        #endregion
        #region 查询演练
        protected DataTable Select_WXY_Pro(Struct_WXY struct_select_wxy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                               new OracleParameter("p_mc",OracleType.NVarChar),
                                               new OracleParameter("p_gw",OracleType.NVarChar),
                                               new OracleParameter("p_zt",OracleType.NVarChar),
                                               new OracleParameter("p_kzzt",OracleType.NVarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                paras[0].Value = struct_select_wxy.p_mc;
                paras[1].Value = struct_select_wxy.p_gw;
                paras[2].Value = struct_select_wxy.p_zt;
                paras[3].Value = struct_select_wxy.p_kzzt;
                paras[4].Value = struct_select_wxy.p_pagesize;
                paras[5].Value = struct_select_wxy.p_currentpage;
                paras[6].Value = struct_select_wxy.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_SKJS_WXY.SELECT_WXY", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 删除演练
        protected void Delete_WXY(int p_id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_id",OracleType.Number),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_WXY.Delate_WXY", paras, out rowsAffected);
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
        #region 查询演练详情
        protected DataTable Select_WXY_Detail(int id)
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
                dt = dbclass.RunProcedure("PACK_SKJS_WXY.Select_WXY_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 通过编号查询员工姓名
        protected DataTable Select_YGXMbyBH(string p_bh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_bh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_SKJS_WXY.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 查询员工
        protected DataTable Select_YGbyBMGW(string bmdm, string gwdm)
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
                dt = dbclass.RunProcedure("PACK_SKJS_WXY.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
      
        #region 编辑演练
        protected void Update_WXY(Struct_WXY struct_wxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_id",OracleType.Number),
                      new OracleParameter("p_gw",OracleType.NVarChar),
                      new OracleParameter("p_mc",OracleType.NVarChar),
                      new OracleParameter("p_fc",OracleType.NVarChar),
                      new OracleParameter("p_yy",OracleType.NVarChar),
                      new OracleParameter("p_zchg",OracleType.NVarChar),
                      new OracleParameter("p_xgal",OracleType.NVarChar),
                      new OracleParameter("p_yf",OracleType.Number),
                      new OracleParameter("p_st",OracleType.NVarChar),
                      new OracleParameter("p_knx",OracleType.NVarChar),
                      new OracleParameter("p_yzx",OracleType.NVarChar),
                      new OracleParameter("p_fxcd",OracleType.NVarChar),
                      new OracleParameter("p_ya",OracleType.NVarChar),
                      new OracleParameter("p_kzzt",OracleType.NVarChar),
                      new OracleParameter("p_bzhqk",OracleType.NVarChar),
                      new OracleParameter("p_yjcs",OracleType.NVarChar),
                      new OracleParameter("p_zrej",OracleType.NVarChar),
                      new OracleParameter("p_zrsj",OracleType.NVarChar),
                      new OracleParameter("p_zrr",OracleType.NVarChar),
                      new OracleParameter("p_phbm",OracleType.NVarChar),

                      new OracleParameter("p_bmdm",OracleType.VarChar),
                      new OracleParameter("p_csr",OracleType.VarChar),
                      new OracleParameter("p_zsr",OracleType.VarChar),
                      new OracleParameter("p_lrr",OracleType.VarChar),

                      new OracleParameter("p_errorCode",OracleType.Int32)
            };
                paras[0].Value = struct_wxy.p_id;
                paras[1].Value = struct_wxy.p_gw;
                paras[2].Value = struct_wxy.p_mc;
                paras[3].Value = struct_wxy.p_fc;
                paras[4].Value = struct_wxy.p_yy;
                paras[5].Value = struct_wxy.p_hg;
                paras[6].Value = struct_wxy.p_xgal;
                paras[7].Value = struct_wxy.p_yf;
                paras[8].Value = struct_wxy.p_st;
                paras[9].Value = struct_wxy.p_knx;
                paras[10].Value = struct_wxy.p_yzx;
                paras[11].Value = struct_wxy.p_fxcd;
                paras[12].Value = struct_wxy.p_ya;
                paras[13].Value = struct_wxy.p_kzzt;
                paras[14].Value = struct_wxy.p_bzhqk;
                paras[15].Value = struct_wxy.p_yj;
                paras[16].Value = struct_wxy.p_bmej;
                paras[17].Value = struct_wxy.p_bmsj;
                paras[18].Value = struct_wxy.p_zrr;
                paras[19].Value = struct_wxy.p_phbm;

                paras[20].Value = struct_wxy.p_bmdm;
                paras[21].Value = struct_wxy.p_csr;
                paras[22].Value = struct_wxy.p_zsr;
                paras[23].Value = struct_wxy.p_lrr;

                paras[24].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_WXY.Update_WXY", paras, out rowsAffected);
                int errorCode = 0;
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_wxy.p_czfs;
                struct_rz.czxx = struct_wxy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 插入危险源
        protected void Insert_WXY(Struct_WXY struct_wxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_gw",OracleType.NVarChar),
                      new OracleParameter("p_mc",OracleType.NVarChar),
                      new OracleParameter("p_fc",OracleType.NVarChar),
                      new OracleParameter("p_yy",OracleType.NVarChar),
                      new OracleParameter("p_zchg",OracleType.NVarChar),
                      new OracleParameter("p_xgal",OracleType.NVarChar),
                      new OracleParameter("p_yf",OracleType.Number),
                      new OracleParameter("p_st",OracleType.NVarChar),
                      new OracleParameter("p_knx",OracleType.NVarChar),
                      new OracleParameter("p_yzx",OracleType.NVarChar),
                      new OracleParameter("p_fxcd",OracleType.NVarChar),
                      new OracleParameter("p_ya",OracleType.NVarChar),
                      new OracleParameter("p_kzzt",OracleType.NVarChar),
                      new OracleParameter("p_bzhqk",OracleType.NVarChar),
                      new OracleParameter("p_yjcs",OracleType.NVarChar),
                      new OracleParameter("p_zrej",OracleType.NVarChar),
                      new OracleParameter("p_zrsj",OracleType.NVarChar),
                      new OracleParameter("p_zrr",OracleType.NVarChar),
                      new OracleParameter("p_phbm",OracleType.NVarChar),

                      new OracleParameter("p_bmdm",OracleType.NVarChar),
                      new OracleParameter("p_csr",OracleType.VarChar),
                      new OracleParameter("p_zsr",OracleType.VarChar),
                      new OracleParameter("p_lrr",OracleType.VarChar),
                      new OracleParameter("p_sjc",OracleType.VarChar),
                      new OracleParameter("p_sjbs",OracleType.VarChar),

                      new OracleParameter("p_errorCode",OracleType.Int32)
            };
                paras[0].Value = struct_wxy.p_gw;
                paras[1].Value = struct_wxy.p_mc;
                paras[2].Value = struct_wxy.p_fc;
                paras[3].Value = struct_wxy.p_yy;
                paras[4].Value = struct_wxy.p_hg;
                paras[5].Value = struct_wxy.p_xgal;
                paras[6].Value = struct_wxy.p_yf;
                paras[7].Value = struct_wxy.p_st;
                paras[8].Value = struct_wxy.p_knx;
                paras[9].Value = struct_wxy.p_yzx;
                paras[10].Value = struct_wxy.p_fxcd;
                paras[11].Value = struct_wxy.p_ya;
                paras[12].Value = struct_wxy.p_kzzt;
                paras[13].Value = struct_wxy.p_bzhqk;
                paras[14].Value = struct_wxy.p_yj;
                paras[15].Value = struct_wxy.p_bmej;
                paras[16].Value = struct_wxy.p_bmsj;
                paras[17].Value = struct_wxy.p_zrr;
                paras[18].Value = struct_wxy.p_phbm;

                paras[19].Value = struct_wxy.p_bmdm;
                paras[20].Value = struct_wxy.p_csr;
                paras[21].Value = struct_wxy.p_zsr;
                paras[22].Value = struct_wxy.p_lrr;
                paras[23].Value = struct_wxy.p_sjc;
                paras[24].Value = struct_wxy.p_sjbs;

                paras[25].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_WXY.Insert_WXY", paras, out rowsAffected);
                int errorCode = 0;
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_wxy.p_czfs;
                struct_rz.czxx = struct_wxy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion


        protected int WXY_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_WXY_Detail(id);
            //备份数据
            Struct_WXY xwy_bf = new Struct_WXY();

            xwy_bf.p_gw = dt_detail.Rows[0]["gw"].ToString();
            xwy_bf.p_mc = dt_detail.Rows[0]["mc"].ToString();
            xwy_bf.p_fc = dt_detail.Rows[0]["fc"].ToString();
            xwy_bf.p_yy = dt_detail.Rows[0]["yy"].ToString();
            xwy_bf.p_hg = dt_detail.Rows[0]["zchg"].ToString();
            xwy_bf.p_xgal = dt_detail.Rows[0]["xgal"].ToString();
            xwy_bf.p_yf = Convert.ToInt32(dt_detail.Rows[0]["yf"].ToString());
            xwy_bf.p_st = dt_detail.Rows[0]["st"].ToString();
            xwy_bf.p_knx = dt_detail.Rows[0]["knx"].ToString();
            xwy_bf.p_yzx = dt_detail.Rows[0]["yzx"].ToString();
            xwy_bf.p_fxcd = dt_detail.Rows[0]["fxcd"].ToString();
            xwy_bf.p_ya = dt_detail.Rows[0]["ya"].ToString();
            xwy_bf.p_kzzt = dt_detail.Rows[0]["kzzt"].ToString();
            xwy_bf.p_bzhqk = dt_detail.Rows[0]["bzhqk"].ToString();
            xwy_bf.p_yj = dt_detail.Rows[0]["yjcs"].ToString();
            xwy_bf.p_bmej = dt_detail.Rows[0]["zrej"].ToString();
            xwy_bf.p_bmsj = dt_detail.Rows[0]["zrsj"].ToString();
            xwy_bf.p_zrr = dt_detail.Rows[0]["zrr"].ToString();
            xwy_bf.p_phbm = dt_detail.Rows[0]["phbm"].ToString();

            xwy_bf.p_zt = "0";
            xwy_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            xwy_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            xwy_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            xwy_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            xwy_bf.p_lrr = _us.userLoginName;
            xwy_bf.p_sjbs = "2";
            xwy_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            xwy_bf.p_shsj = "";
            xwy_bf.p_czfs = "02";
            xwy_bf.p_czxx = "危险源id:" + id + "生成副本数据";
            //插入
            Insert_WXY(xwy_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = xwy_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SKJS_WXY.Select_WXY_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #region 更新状态
        protected void Update_WXYZT(Struct_WXY struct_wxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_wxy.p_id;
                paras[1].Value = struct_wxy.p_zt;
                paras[2].Value = struct_wxy.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_WXY.Update_WXYZT", paras, out rowsAffected);
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

        //变更数据标识
        protected void Update_WXY_SJBS_ZT(Struct_WXY struct_wxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_wxy.p_sjc;
                paras[1].Value = struct_wxy.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_WXY.Update_WXY_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_wxy.p_czfs;
                struct_rz.czxx = struct_wxy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_WXY_SJBS_LSSJ_ZT(Struct_WXY struct_wxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_wxy.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_WXY.Update_WXY_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_wxy.p_czfs;
                struct_rz.czxx = struct_wxy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }




        #region 将副本数据变为最终数据
        protected void Update_WXY_SJBS_FBSJ_ZT(Struct_WXY struct_wxy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_wxy.p_sjc;
                paras[1].Value = struct_wxy.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_WXY.Update_WXY_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_wxy.p_czfs;
                struct_rz.czxx = struct_wxy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #endregion

    }
}

