using CUST;
using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_PXJL
    {
        public int p_id;//id
        public string p_type;//类型
        public DateTime p_rqsj;//日期
        public DateTime p_rqsj_ks;//日期
        public DateTime p_rqsj_js;//日期
        public string p_xs;//学时
        public string p_ks;//课时
        public string p_jb;//级别
        public string p_pxs;//培训师
        public string p_khfs;//考核方式
        public string p_khjg;//考核结果
        public string p_sjyz;//受教育者
        public string p_fzr;//负责人
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public int p_CurrentPage;
        public int p_pagesize;
        public string p_jxnr;
        public int p_userid;
        public string p_bmdm;

        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
    public class OPXJL
    {
        private UserState _us = null;
        private RZ rz = null;
        public OPXJL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        internal DataTable Select_PXJL_Detail(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor),
                                             };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_PXJL.Select_KG_PXJL_Detail", parament, "table").Tables[0];
                return dt;

            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_PXJL_Pro(Struct_PXJL struct_PXJL_Pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_type",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_rqsj_ks",OracleType.DateTime),
                                                 new OracleParameter("p_rqsj_js",OracleType.DateTime),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                 new OracleParameter("p_pxs",OracleType.VarChar),
                                                 new OracleParameter("p_sjyz",OracleType.VarChar),
                                                 new OracleParameter("p_khjg",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor),
                                             };
                parament[0].Value = struct_PXJL_Pro.p_type;
                parament[1].Value = struct_PXJL_Pro.p_bmdm;
                parament[2].Value = struct_PXJL_Pro.p_rqsj_ks;
                parament[3].Value = struct_PXJL_Pro.p_rqsj_js;
                parament[4].Value = struct_PXJL_Pro.p_jb;
                parament[5].Value = struct_PXJL_Pro.p_pxs;
                parament[6].Value = struct_PXJL_Pro.p_sjyz;
                parament[7].Value = struct_PXJL_Pro.p_khjg;
                parament[8].Value = struct_PXJL_Pro.p_zt;
                parament[9].Value = struct_PXJL_Pro.p_userid;
                parament[10].Value = struct_PXJL_Pro.p_CurrentPage;
                parament[11].Value = struct_PXJL_Pro.p_pagesize;
                parament[12].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_PXJL.Select_PXJL_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //普通员工查询
        protected DataTable Select_PXJL_Pro_Ptyg(Struct_PXJL struct_PXJL_Pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_type",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_rqsj_ks",OracleType.DateTime),
                                                 new OracleParameter("p_rqsj_js",OracleType.DateTime),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                 new OracleParameter("p_pxs",OracleType.VarChar),
                                                 new OracleParameter("p_sjyz",OracleType.VarChar),
                                                 new OracleParameter("p_khjg",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor),
                                             };
                parament[0].Value = struct_PXJL_Pro.p_type;
                parament[1].Value = struct_PXJL_Pro.p_bmdm;
                parament[2].Value = struct_PXJL_Pro.p_rqsj_ks;
                parament[3].Value = struct_PXJL_Pro.p_rqsj_js;
                parament[4].Value = struct_PXJL_Pro.p_jb;
                parament[5].Value = struct_PXJL_Pro.p_pxs;
                parament[6].Value = struct_PXJL_Pro.p_sjyz;
                parament[7].Value = struct_PXJL_Pro.p_khjg;
                parament[8].Value = struct_PXJL_Pro.p_zt;
                parament[9].Value = struct_PXJL_Pro.p_userid;
                parament[10].Value = struct_PXJL_Pro.p_CurrentPage;
                parament[11].Value = struct_PXJL_Pro.p_pagesize;
                parament[12].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_PXJL.Select_PXJL_Pro_Ptyg", parament, "table").Tables[0];
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_PXJL_Count(Struct_PXJL struct_PXJL_Pro)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_type",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_rqsj_ks",OracleType.DateTime),
                    new OracleParameter("p_rqsj_js",OracleType.DateTime),
                    new OracleParameter("p_jb",OracleType.VarChar),
                    new OracleParameter("p_khjg",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = struct_PXJL_Pro.p_type;
                paras[1].Value = struct_PXJL_Pro.p_bmdm;
                paras[2].Value = struct_PXJL_Pro.p_rqsj_ks;
                paras[3].Value = struct_PXJL_Pro.p_rqsj_js;
                paras[4].Value = struct_PXJL_Pro.p_jb;
                paras[5].Value = struct_PXJL_Pro.p_khjg;
                paras[6].Value = struct_PXJL_Pro.p_zt;
                paras[7].Value = struct_PXJL_Pro.p_userid;
                paras[8].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_PXJL.Select_PXJL_Count", paras, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //普通员工信息数量查询
        protected int Select_PXJL_Count_Ptyg(Struct_PXJL struct_PXJL_Pro)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_type",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_rqsj_ks",OracleType.DateTime),
                    new OracleParameter("p_rqsj_js",OracleType.DateTime),
                    new OracleParameter("p_jb",OracleType.VarChar),
                    new OracleParameter("p_khjg",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = struct_PXJL_Pro.p_type;
                paras[1].Value = struct_PXJL_Pro.p_bmdm;
                paras[2].Value = struct_PXJL_Pro.p_rqsj_ks;
                paras[3].Value = struct_PXJL_Pro.p_rqsj_js;
                paras[4].Value = struct_PXJL_Pro.p_jb;
                paras[5].Value = struct_PXJL_Pro.p_khjg;
                paras[6].Value = struct_PXJL_Pro.p_zt;
                paras[7].Value = struct_PXJL_Pro.p_userid;
                paras[8].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_PXJL.Select_PXJL_Count_Ptyg", paras, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected DataTable Select_YGbyBMGW(string p_bmdm, string p_gwdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_bmdm;
                paras[1].Value = p_gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_KG_PXJL.Select_YGbyBMGW", paras, "tables").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
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
                dt = db.RunProcedure("PACK_SKJS_AQYHK.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        protected void Insert_PXJL_Pro(Struct_PXJL struct_PXJL_ADD)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_type",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_rqsj",OracleType.DateTime),
                                                 new OracleParameter("p_xs",OracleType.VarChar),
                                                  new OracleParameter("p_jxnr",OracleType.VarChar),
                                                 new OracleParameter("p_ks",OracleType.VarChar),
                                                 new OracleParameter("p_jb",OracleType.VarChar),
                                                 new OracleParameter("p_pxs",OracleType.VarChar),
                                                 new OracleParameter("p_khfs",OracleType.VarChar),
                                                 new OracleParameter("p_khjg",OracleType.VarChar),
                                                 new OracleParameter("p_sjyz",OracleType.VarChar),
                                                 new OracleParameter("p_fzr",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_PXJL_ADD.p_type;
                parament[1].Value = struct_PXJL_ADD.p_bmdm;
                parament[2].Value = struct_PXJL_ADD.p_rqsj;
                parament[3].Value = struct_PXJL_ADD.p_xs;
                parament[4].Value = struct_PXJL_ADD.p_jxnr;
                parament[5].Value = struct_PXJL_ADD.p_ks;
                parament[6].Value = struct_PXJL_ADD.p_jb;
                parament[7].Value = struct_PXJL_ADD.p_pxs;
                parament[8].Value = struct_PXJL_ADD.p_khfs;
                parament[9].Value = struct_PXJL_ADD.p_khjg;
                parament[10].Value = struct_PXJL_ADD.p_sjyz;
                parament[11].Value = struct_PXJL_ADD.p_fzr;
                parament[12].Value = struct_PXJL_ADD.p_csr;
                parament[13].Value = struct_PXJL_ADD.p_zsr;
                parament[14].Value = struct_PXJL_ADD.p_lrr;
                parament[15].Value = struct_PXJL_ADD.p_sjc;
                parament[16].Value = struct_PXJL_ADD.p_sjbs;
                parament[17].Value = struct_PXJL_ADD.p_zt;
                parament[18].Direction = ParameterDirection.Output;
                int errorCode = 0;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_PXJL.Insert_KG_PXJL_Pro", parament, out reslut);
                errorCode = Convert.ToInt32(parament[18].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_PXJL_ADD.p_czfs;
                struct_rz.czxx = struct_PXJL_ADD.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Edit_PXJL_Pro(Struct_PXJL struct_PXJL_Edit)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Int32),
                                                 new OracleParameter("p_type",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_rqsj",OracleType.DateTime),
                                                 new OracleParameter("p_xs",OracleType.VarChar),
                                                 new OracleParameter("p_jxnr",OracleType.VarChar),
                                                 new OracleParameter("p_ks",OracleType.VarChar),
                                                 new OracleParameter("p_jb",OracleType.VarChar),
                                                 new OracleParameter("p_pxs",OracleType.VarChar),
                                                 new OracleParameter("p_khfs",OracleType.VarChar),
                                                 new OracleParameter("p_khjg",OracleType.VarChar),
                                                 new OracleParameter("p_sjyz",OracleType.VarChar),
                                                 new OracleParameter("p_fzr",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_PXJL_Edit.p_id;
                parament[1].Value = struct_PXJL_Edit.p_type;
                parament[2].Value = struct_PXJL_Edit.p_bmdm;
                parament[3].Value = struct_PXJL_Edit.p_rqsj;
                parament[4].Value = struct_PXJL_Edit.p_xs;
                parament[5].Value = struct_PXJL_Edit.p_jxnr;
                parament[6].Value = struct_PXJL_Edit.p_ks;
                parament[7].Value = struct_PXJL_Edit.p_jb;
                parament[8].Value = struct_PXJL_Edit.p_pxs;
                parament[9].Value = struct_PXJL_Edit.p_khfs;
                parament[10].Value = struct_PXJL_Edit.p_khjg;
                parament[11].Value = struct_PXJL_Edit.p_sjyz;
                parament[12].Value = struct_PXJL_Edit.p_fzr;
                parament[13].Value = struct_PXJL_Edit.p_csr;
                parament[14].Value = struct_PXJL_Edit.p_zsr;
                parament[15].Value = struct_PXJL_Edit.p_lrr;
                parament[16].Value = struct_PXJL_Edit.p_zt;
                parament[17].Value = struct_PXJL_Edit.p_sjbs;
                parament[18].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_PXJL.Update_KG_PXJL_Pro", parament, out reslut);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[18].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_PXJL_Edit.p_czfs;
                struct_rz.czxx = struct_PXJL_Edit.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #region 更新状态
        protected void Update_PXJLZT(Struct_PXJL struct_PXJL)
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
                paras[0].Value = struct_PXJL.p_id;
                paras[1].Value = struct_PXJL.p_zt;
                paras[2].Value = struct_PXJL.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_PXJL.Update_PXJLZT", paras, out rowsAffected);
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
        protected void Update_PXJL_SJBS_ZT(Struct_PXJL pxjl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = pxjl.p_sjc;
                paras[1].Value = pxjl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_PXJL.Update_PXJL_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pxjl.p_czfs;
                struct_rz.czxx = pxjl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_PXJL_SJBS_LSSJ_ZT(Struct_PXJL pxjl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = pxjl.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_PXJL.Update_PXJL_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pxjl.p_czfs;
                struct_rz.czxx = pxjl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }




        #region 将副本数据变为最终数据
        protected void Update_PXJL_SJBS_FBSJ_ZT(Struct_PXJL pxjl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = pxjl.p_sjc;
                paras[1].Value = pxjl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_PXJL.Update_PXJL_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = pxjl.p_czfs;
                struct_rz.czxx = pxjl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #endregion
        protected void Delete_PXJL_Pro(int id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Int32),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_PXJL.Delete_KG_PXJL_Pro", parament, out reslut);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[1].Value);
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
                dbclass.Close();
            }
        }
        protected int PXJL_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_PXJL_Detail(id);
            //备份数据
            Struct_PXJL pxjl_bf = new Struct_PXJL();

            pxjl_bf.p_rqsj = Convert.ToDateTime(dt_detail.Rows[0]["rqsj"].ToString());

            pxjl_bf.p_type = dt_detail.Rows[0]["type"].ToString();
            pxjl_bf.p_xs = dt_detail.Rows[0]["xs"].ToString();
            pxjl_bf.p_ks = dt_detail.Rows[0]["ks"].ToString();
            pxjl_bf.p_jb = dt_detail.Rows[0]["jb"].ToString();
            pxjl_bf.p_pxs = dt_detail.Rows[0]["pxs"].ToString();
            pxjl_bf.p_khfs = dt_detail.Rows[0]["khfs"].ToString();
            pxjl_bf.p_khjg = dt_detail.Rows[0]["khjg"].ToString();
            pxjl_bf.p_sjyz = dt_detail.Rows[0]["sjyz"].ToString();
            pxjl_bf.p_fzr = dt_detail.Rows[0]["fzr"].ToString();
            pxjl_bf.p_jxnr = dt_detail.Rows[0]["jxnr"].ToString();

            pxjl_bf.p_zt = "0";
            pxjl_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            pxjl_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            pxjl_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            pxjl_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            pxjl_bf.p_lrr = _us.userLoginName;
            pxjl_bf.p_sjbs = "2";
            pxjl_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            pxjl_bf.p_shsj = "";
            pxjl_bf.p_czfs = "02";
            pxjl_bf.p_czxx = "员工培训id:" + id + "生成副本数据";
            //插入
            Insert_PXJL_Pro(pxjl_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = pxjl_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_PXJL.Select_PXJL_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        public new DataTable Select_YGPX_BYBH(string ygbh, int userid)
        {

            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = ygbh;
                parament[1].Value = userid;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_PXJL.Select_YGPX_BYBH", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //数据导出
        protected DataTable Select_YGPX_DC(int p_userid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_userid",OracleType.Int32),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };
                paras[0].Value = p_userid;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_PXJL.Select_YGPX_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

    }
}

