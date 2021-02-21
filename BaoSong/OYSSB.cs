using CUST;
using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.WKG
{
    public struct Struct_Bs_Yssb
    {
        public int p_id;
        public string p_tbdw;
        public string p_yslx;
        public string p_sbnf;
        public string p_xmmc;
        public string p_whdw;
        public string p_yjje;
        public string p_sjzxje;
        public string p_yszx;
        public string p_tzyy;
        public string p_zt;
        public string p_wcsj;
        public string p_bz;
        public string p_sbzt;
        public string p_czfs;
        public string p_czxx;
        public string p_bhyy;
        public string p_bmdm;//部门  
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
    public struct Struct_Bs_Yssb_Update
    {
        public int p_id;
        public string p_tbdw;
        public string p_yslx;
        public string p_sbnf;
        public string p_xmmc;
        public string p_whdw;
        public string p_yjje;
        public string p_sjzxje;
        public string p_yszx;
        public string p_tzyy;
        public string p_zt;
        public string p_wcsj;
        public string p_bz;
        public string p_sbzt; 
        public string p_czfs;
        public string p_czxx;
        public string p_bhyy;
        public string p_bmdm;//部门  
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
    public struct Select_Bs_Yssb
    {
        public int p_id;
        public string p_tbdw;
        public string p_yslx;
        public string p_zt;
        public string p_sbzt;
        public string p_czfs;
        public string p_czxx;
        public int p_userid;
        public string p_bmdm;//部门  
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public int p_pagesize;   //每页容量
        public int p_currentpage;//当前页
    }
    public class OYSSB
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz = null;
        public OYSSB(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region 添加
        protected void Insert_Bs_Yssb(Struct_Bs_Yssb struct_bs_yssb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_tbdw",OracleType.VarChar),
                  new OracleParameter("p_yslx",OracleType.VarChar),
                  new OracleParameter("p_sbnf",OracleType.DateTime),
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_whdw",OracleType.VarChar),
                  new OracleParameter("p_yjje",OracleType.Number),
                  new OracleParameter("p_sjzxje",OracleType.Number),
                  new OracleParameter("p_yszx",OracleType.VarChar),
                  new OracleParameter("p_tzyy",OracleType.VarChar),
                  new OracleParameter("p_wcsj",OracleType.DateTime),
                  new OracleParameter("p_bz",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_sbzt",OracleType.VarChar),
                  new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_sjbs",OracleType.VarChar),
                    
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_bs_yssb.p_tbdw;
                paras[1].Value = struct_bs_yssb.p_yslx;
                paras[2].Value = struct_bs_yssb.p_sbnf;
                paras[3].Value = struct_bs_yssb.p_xmmc;
                paras[4].Value = struct_bs_yssb.p_whdw;
                paras[5].Value = struct_bs_yssb.p_yjje;
                paras[6].Value = struct_bs_yssb.p_sjzxje;
                paras[7].Value = struct_bs_yssb.p_yszx;
                paras[8].Value = struct_bs_yssb.p_tzyy;
                paras[9].Value = struct_bs_yssb.p_wcsj;
                paras[10].Value = struct_bs_yssb.p_bz;
                paras[11].Value= struct_bs_yssb.p_zt;
                paras[12].Value= struct_bs_yssb.p_sbzt;
                paras[13].Value = struct_bs_yssb.p_bmdm;
                paras[14].Value = struct_bs_yssb.p_csr;
                paras[15].Value = struct_bs_yssb.p_zsr;
                paras[16].Value = struct_bs_yssb.p_lrr;
                paras[17].Value = struct_bs_yssb.p_sjc;
                paras[18].Value = struct_bs_yssb.p_sjbs;
                
                paras[19].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YSSB.Insert_Bs_YSSB_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[19].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_yssb.p_czfs;
                struct_rz.czxx = struct_bs_yssb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 查出预算类型
        protected DataTable Select_Bs_Yssb_Yslx()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_YSSB.Select_Bs_Yssb_Yslx", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查出状态
        protected DataTable Select_Bs_Yssb_Zt()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras = {
                    new OracleParameter("p_cur", OracleType.Cursor)
                };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_YSSB.Select_Bs_Yssb_Zt", paras, "table").Tables[0];
                return dt;
                
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  查出申报状态
        protected DataTable Select_Bs_Yssb_Sbzt()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_YSSB.Select_Bs_Yssb_Sbzt", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查找
        protected DataTable SelectBS_Yssb_Pro(Select_Bs_Yssb struct_select_bs_yssb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_tbdw",OracleType.VarChar),
                    new OracleParameter("p_yslx",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_sbzt",OracleType.VarChar),
                     new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_select_bs_yssb.p_tbdw;
                paras[1].Value = struct_select_bs_yssb.p_yslx;
                paras[2].Value = struct_select_bs_yssb.p_zt;
                paras[3].Value = struct_select_bs_yssb.p_sbzt;
                paras[4].Value = struct_select_bs_yssb.p_userid;
                paras[5].Value = struct_select_bs_yssb.p_pagesize;
                paras[6].Value = struct_select_bs_yssb.p_currentpage;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_YSSB.Select_Bs_yssb_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查出填报单位
        protected DataTable Select_Bs_Yssb_Tbdw()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_YSSB.Select_Bs_Yssb_Tbdw", paras, "table").Tables[0];
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
        /// 删除
        /// </summary>
        /// <param name="p_id"></param>

        protected void Delete_Bs_Yssb(int p_id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_HWZHBS_YSSB.Delete_Bs_Yssb_Proc", paras, out rowsAffected);
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
        /// <param name="hb"></param>
        protected void Update_Bs_Yssb(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                 new OracleParameter("p_tbdw",OracleType.VarChar),
                  new OracleParameter("p_yslx",OracleType.VarChar),
                  new OracleParameter("p_sbnf",OracleType.DateTime),
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_whdw",OracleType.VarChar),
                  new OracleParameter("p_yjje",OracleType.Number),
                  new OracleParameter("p_sjzxje",OracleType.Number),
                  new OracleParameter("p_yszx",OracleType.VarChar),
                  new OracleParameter("p_tzyy",OracleType.VarChar),
                  new OracleParameter("p_wcsj",OracleType.DateTime),
                  new OracleParameter("p_bz",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bmdm",OracleType.VarChar),
                  new OracleParameter("p_csr",OracleType.VarChar),
                  new OracleParameter("p_zsr",OracleType.VarChar),
                  new OracleParameter("p_lrr",OracleType.VarChar),
                   
                  new OracleParameter("p_errorCode", OracleType.Int32)
        };
                paras[0].Value = struct_bs_yssb_update.p_id;
                paras[1].Value = struct_bs_yssb_update.p_tbdw;
                paras[2].Value = struct_bs_yssb_update.p_yslx;
                paras[3].Value =Convert.ToDateTime( struct_bs_yssb_update.p_sbnf);
                paras[4].Value = struct_bs_yssb_update.p_xmmc;
                paras[5].Value = struct_bs_yssb_update.p_whdw;
                paras[6].Value =Convert.ToDouble( struct_bs_yssb_update.p_yjje);
                paras[7].Value =Convert.ToDouble( struct_bs_yssb_update.p_sjzxje);
                paras[8].Value = struct_bs_yssb_update.p_yszx;
                paras[9].Value = struct_bs_yssb_update.p_tzyy;
                paras[10].Value =Convert.ToDateTime( struct_bs_yssb_update.p_wcsj);
                paras[11].Value = struct_bs_yssb_update.p_bz;
                paras[12].Value = struct_bs_yssb_update.p_zt;
                paras[13].Value = struct_bs_yssb_update.p_bmdm;
                paras[14].Value = struct_bs_yssb_update.p_csr;
                paras[15].Value = struct_bs_yssb_update.p_zsr;
                paras[16].Value = struct_bs_yssb_update.p_lrr;
                
                paras[17].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YSSB.Update_Bs_Yssb_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[17].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_yssb_update.p_czfs;
                struct_rz.czxx = struct_bs_yssb_update.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 检索详细信息
        protected DataTable Select_Bs_Yssb_Detail(int id)
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
                dt = dbclass.RunProcedure("PACK_HWZHBS_YSSB.Select_Bs_Yssb_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  查找预算申报数量
        protected int Select_Bs_Yssb_Count(Select_Bs_Yssb struct_bs_yssb_count)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                    {
                        new OracleParameter("p_tbdw",OracleType.VarChar),
                        new OracleParameter("p_yslx",OracleType.VarChar),
                        new OracleParameter("p_zt",OracleType.VarChar),
                        new OracleParameter("p_sbzt",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
                   };
                paras[0].Value = struct_bs_yssb_count.p_tbdw;
                paras[1].Value = struct_bs_yssb_count.p_yslx;
                paras[2].Value = struct_bs_yssb_count.p_zt;
                paras[3].Value = struct_bs_yssb_count.p_sbzt;
                paras[4].Value = struct_bs_yssb_count.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_YSSB.Select_Bs_Yssb_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 修改申报状态
        protected void Update_Bs_Yssb_Sbzt(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_sbzt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode", OracleType.Int32)
        };
                paras[0].Value = struct_bs_yssb_update.p_id;
                paras[1].Value = struct_bs_yssb_update.p_sbzt;
                paras[2].Value = struct_bs_yssb_update.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YSSB.Update_Bs_Yssb_Sbzt", paras, out rowsAffected);
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
        #region 变更数据标识
        protected void Update_YSSB_SJBS_ZT(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_bs_yssb_update.p_sjc;
                paras[1].Value = struct_bs_yssb_update.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YSSB.Update_YSSB_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_yssb_update.p_czfs;
                struct_rz.czxx = struct_bs_yssb_update.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 将原最终数据变为历史数据
        protected void Update_YSSB_SJBS_LSSJ_ZT(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_bs_yssb_update.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YSSB.Update_YSSB_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_yssb_update.p_czfs;
                struct_rz.czxx = struct_bs_yssb_update.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #region 将副本数据变为最终数据
        protected void Update_YSSB_SJBS_FBSJ_ZT(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_bs_yssb_update.p_sjc;
                paras[1].Value = struct_bs_yssb_update.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_YSSB.Update_YSSB_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_yssb_update.p_czfs;
                struct_rz.czxx = struct_bs_yssb_update.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #region 生成备份
        protected int YSSB_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_Bs_Yssb_Detail(id);
            //备份数据
            Struct_Bs_Yssb yssb_bf = new Struct_Bs_Yssb();

            yssb_bf.p_tbdw = dt_detail.Rows[0]["tbdw"].ToString();
            yssb_bf.p_yjje = dt_detail.Rows[0]["yjje"].ToString();
            yssb_bf.p_yslx = dt_detail.Rows[0]["yslx"].ToString();
            yssb_bf.p_xmmc = dt_detail.Rows[0]["xmmc"].ToString();
            yssb_bf.p_whdw = dt_detail.Rows[0]["whdw"].ToString();
            yssb_bf.p_zt = dt_detail.Rows[0]["zt"].ToString();
            yssb_bf.p_sbnf = Convert.ToDateTime(dt_detail.Rows[0]["sbnf"]).ToString("yyyy-MM-dd");
            yssb_bf.p_sjzxje = dt_detail.Rows[0]["sjzxje"].ToString();
            yssb_bf.p_yszx = dt_detail.Rows[0]["yszx"].ToString();
            yssb_bf.p_tzyy = dt_detail.Rows[0]["tzyy"].ToString();
            yssb_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            yssb_bf.p_wcsj = Convert.ToDateTime(dt_detail.Rows[0]["wcsj"]).ToString("yyyy-MM-dd");
            yssb_bf.p_sbzt = "0";
            yssb_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            yssb_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            yssb_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            yssb_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            yssb_bf.p_lrr = _usState.userLoginName;
            yssb_bf.p_sjbs = "2";
            yssb_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            yssb_bf.p_shsj = "";
            yssb_bf.p_czfs = "02";
            yssb_bf.p_czxx = "设备病例信息id:" + id + "生成副本数据";
            //插入
            Insert_Bs_Yssb(yssb_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = yssb_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_HWZHBS_YSSB.Select_YSSB_BFID", parament, out reslut);

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
