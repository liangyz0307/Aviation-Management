using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys;
using CUST.MKG;
using System.Data;
using System.Data.OracleClient;

namespace CUST.MKG
{
    public struct Struct_AQYHK
    {
        public string p_id;
        public string p_ygbh;
        public DateTime p_tbrq;
        public string p_tbdw;
        public DateTime p_yhfxsj;
        public string p_ly;
        public string p_zt;
        public string p_yhms;
        public string p_knzcwh;
        public string p_yhdj;
        public string p_pgfjpz;
        public string p_zgcs;
        public string p_yjtrfy;
        public DateTime p_zgwcsx;
        public string p_wcjdms;
        public string p_zgzrdw;
        public string p_zgzrr;
        public string p_zgdbzrr;
        public string p_zgfapz;
        public string p_zgyzjg;
        public string p_zgyzr;
        public DateTime p_zggbsj;
        public string p_zggbbz;
        public string p_zggbpz;
        public string p_xgtzbcqk;
        public string p_czfs;
        public string p_czxx;
        public string p_bhyy;

        public int p_userid;
        public string p_bmdm;

        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
    public struct Struct_Select_AQYHK
    {
        public string p_ygbh;
        public DateTime p_tbrq_ks;
        public DateTime p_tbrq_js;
        public string p_ly;
        public string p_zt;
        public string p_yhdj;
        public int p_currentpage;
        public int p_pagesize;

        public int p_userid;
        public string p_bmdm;

        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
    public class OANQHK
    {
        private UserState _us = null;
        private RZ rz = null;
        public OANQHK(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 查询
        /// <summary>
        /// 查询安全隐患库信息总数
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
        protected int Select_AQYHK_Count(Struct_Select_AQYHK struct_select_aqyhk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    
                    new OracleParameter("p_ygbh",OracleType.VarChar),
                    new OracleParameter("p_tbrq_ks",OracleType.DateTime),
                    new OracleParameter("p_tbrq_js",OracleType.DateTime),
                    new OracleParameter("p_ly",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_yhdj",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = struct_select_aqyhk.p_ygbh;
                paras[1].Value = struct_select_aqyhk.p_tbrq_ks;
                paras[2].Value = struct_select_aqyhk.p_tbrq_js;
                paras[3].Value = struct_select_aqyhk.p_zt;
                paras[4].Value = struct_select_aqyhk.p_ly;
                paras[5].Value = struct_select_aqyhk.p_yhdj;
                paras[6].Value = struct_select_aqyhk.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_SKJS_AQYHK.Select_SKJS_AQYHK_Count", paras, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询安全隐患库信息
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
        protected DataTable Select_AQYHK_Pro(Struct_Select_AQYHK struct_select_aqyhk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_ygbh",OracleType.VarChar),
                    new OracleParameter("p_tbrq_ks",OracleType.DateTime),
                    new OracleParameter("p_tbrq_js",OracleType.DateTime),
                    new OracleParameter("p_ly",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_yhdj",OracleType.VarChar),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = struct_select_aqyhk.p_ygbh;
                paras[1].Value = struct_select_aqyhk.p_tbrq_ks;
                paras[2].Value = struct_select_aqyhk.p_tbrq_js;
                paras[3].Value = struct_select_aqyhk.p_ly;
                paras[4].Value = struct_select_aqyhk.p_zt;
                paras[5].Value = struct_select_aqyhk.p_yhdj;
                paras[6].Value = struct_select_aqyhk.p_currentpage;
                paras[7].Value = struct_select_aqyhk.p_pagesize;
                paras[8].Value = struct_select_aqyhk.p_userid;
                paras[9].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_SKJS_AQYHK.Select_SKJS_AQYHK_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询安全隐患库信息详情
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
        protected DataTable Select_AQYHK_Detail(int p_id)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_SKJS_AQYHK.Select_SKJS_AQYHK_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 根据员工编号查询员工姓名
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据部门岗位查询员工
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
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
                dt = db.RunProcedure("PACK_SKJS_AQYHK.Select_YGbyBMGW", paras, "tables").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
        protected void Insert_AQYHK(Struct_AQYHK struct_aqyhk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_ygbh",OracleType.VarChar),
                    new OracleParameter("p_tbrq",OracleType.DateTime),
                    new OracleParameter("p_tbdw",OracleType.VarChar),
                    new OracleParameter("p_yhfxsj",OracleType.DateTime),
                    new OracleParameter("p_ly",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_yhms",OracleType.VarChar),
                    new OracleParameter("p_knzcwh",OracleType.VarChar),
                    new OracleParameter("p_yhdj",OracleType.VarChar),
                    new OracleParameter("p_pgfjpz",OracleType.VarChar),
                    new OracleParameter("p_zgcs",OracleType.VarChar),
                    new OracleParameter("p_yjtrfy",OracleType.VarChar),
                    new OracleParameter("p_zgwcsx",OracleType.DateTime),
                    new OracleParameter("p_wcjdms",OracleType.VarChar),
                    new OracleParameter("p_zgzrdw",OracleType.VarChar),
                    new OracleParameter("p_zgzrr",OracleType.VarChar),
                    new OracleParameter("p_zgdbzrr",OracleType.VarChar),
                    new OracleParameter("p_zgfapz",OracleType.VarChar),
                    new OracleParameter("p_zgyzjg",OracleType.VarChar),
                    new OracleParameter("p_zgyzr",OracleType.VarChar),
                    new OracleParameter("p_zggbsj",OracleType.DateTime),
                    new OracleParameter("p_zggbbz",OracleType.VarChar),
                    new OracleParameter("p_zggbpz", OracleType.VarChar),
                    new OracleParameter("p_xgtzbcqk",OracleType.VarChar),

                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_sjbs",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),

                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = struct_aqyhk.p_ygbh;
                paras[1].Value = struct_aqyhk.p_tbrq;
                paras[2].Value = struct_aqyhk.p_tbdw;
                paras[3].Value = struct_aqyhk.p_yhfxsj;
                paras[4].Value = struct_aqyhk.p_ly;
                paras[5].Value = struct_aqyhk.p_zt;
                paras[6].Value = struct_aqyhk.p_yhms;
                paras[7].Value = struct_aqyhk.p_knzcwh;
                paras[8].Value = struct_aqyhk.p_yhdj;
                paras[9].Value = struct_aqyhk.p_pgfjpz;
                paras[10].Value = struct_aqyhk.p_zgcs;
                paras[11].Value = struct_aqyhk.p_yjtrfy;
                paras[12].Value = struct_aqyhk.p_zgwcsx;
                paras[13].Value = struct_aqyhk.p_wcjdms;
                paras[14].Value = struct_aqyhk.p_zgzrdw;
                paras[15].Value = struct_aqyhk.p_zgzrr;
                paras[16].Value = struct_aqyhk.p_zgdbzrr;
                paras[17].Value = struct_aqyhk.p_zgfapz;
                paras[18].Value = struct_aqyhk.p_zgyzjg;
                paras[19].Value = struct_aqyhk.p_zgyzr;
                paras[20].Value = struct_aqyhk.p_zggbsj;
                paras[21].Value = struct_aqyhk.p_zggbbz;
                paras[22].Value = struct_aqyhk.p_zggbpz;
                paras[23].Value = struct_aqyhk.p_xgtzbcqk;

                paras[24].Value = struct_aqyhk.p_csr;
                paras[25].Value = struct_aqyhk.p_zsr;
                paras[26].Value = struct_aqyhk.p_lrr;
                paras[27].Value = struct_aqyhk.p_sjc;
                paras[28].Value = struct_aqyhk.p_sjbs;
                paras[29].Value = struct_aqyhk.p_bmdm;

                paras[30].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQYHK.Insert_SKJS_AQYHK_Pro", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[30].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_aqyhk.p_czfs;
                struct_rz.czxx = struct_aqyhk.p_czxx;
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
        /// 删除安全隐患库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected void Delete_AQYHK(int p_id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = p_id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQYHK.Delete_SKJS_AQYHK_Pro", paras, out rowsAffected);
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
        #region 修改
        /// <summary>
        /// 修改设备病例库表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected void Update_AQYHK(Struct_AQYHK struct_aqyhk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_ygbh",OracleType.VarChar),
                    new OracleParameter("p_tbrq",OracleType.DateTime),
                    new OracleParameter("p_tbdw",OracleType.VarChar),
                    new OracleParameter("p_yhfxsj",OracleType.DateTime),
                    new OracleParameter("p_ly",OracleType.VarChar),
                    new OracleParameter("p_yhms",OracleType.VarChar),
                    new OracleParameter("p_knzcwh",OracleType.VarChar),
                    new OracleParameter("p_yhdj",OracleType.VarChar),
                    new OracleParameter("p_pgfjpz",OracleType.VarChar),
                    new OracleParameter("p_zgcs",OracleType.VarChar),
                    new OracleParameter("p_yjtrfy",OracleType.VarChar),
                    new OracleParameter("p_zgwcsx",OracleType.DateTime),
                    new OracleParameter("p_wcjdms",OracleType.VarChar),
                    new OracleParameter("p_zgzrdw",OracleType.VarChar),
                    new OracleParameter("p_zgzrr",OracleType.VarChar),
                    new OracleParameter("p_zgdbzrr",OracleType.VarChar),
                    new OracleParameter("p_zgfapz",OracleType.VarChar),
                    new OracleParameter("p_zgyzjg",OracleType.VarChar),
                    new OracleParameter("p_zgyzr",OracleType.VarChar),
                    new OracleParameter("p_zggbsj",OracleType.DateTime),
                    new OracleParameter("p_zggbbz",OracleType.VarChar),
                    new OracleParameter("p_zggbpz", OracleType.VarChar),
                    new OracleParameter("p_xgtzbcqk",OracleType.VarChar),

                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),

                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = Convert.ToInt32(struct_aqyhk.p_id);
                paras[1].Value = struct_aqyhk.p_ygbh;
                paras[2].Value = struct_aqyhk.p_tbrq;
                paras[3].Value = struct_aqyhk.p_tbdw;
                paras[4].Value = struct_aqyhk.p_yhfxsj;
                paras[5].Value = struct_aqyhk.p_ly;
                paras[6].Value = struct_aqyhk.p_yhms;
                paras[7].Value = struct_aqyhk.p_knzcwh;
                paras[8].Value = struct_aqyhk.p_yhdj;
                paras[9].Value = struct_aqyhk.p_pgfjpz;
                paras[10].Value = struct_aqyhk.p_zgcs;
                paras[11].Value = struct_aqyhk.p_yjtrfy;
                paras[12].Value = struct_aqyhk.p_zgwcsx;
                paras[13].Value = struct_aqyhk.p_wcjdms;
                paras[14].Value = struct_aqyhk.p_zgzrdw;
                paras[15].Value = struct_aqyhk.p_zgzrr;
                paras[16].Value = struct_aqyhk.p_zgdbzrr;
                paras[17].Value = struct_aqyhk.p_zgfapz;
                paras[18].Value = struct_aqyhk.p_zgyzjg;
                paras[19].Value = struct_aqyhk.p_zgyzr;
                paras[20].Value = struct_aqyhk.p_zggbsj;
                paras[21].Value = struct_aqyhk.p_zggbbz;
                paras[22].Value = struct_aqyhk.p_zggbpz;
                paras[23].Value = struct_aqyhk.p_xgtzbcqk;

                paras[24].Value = struct_aqyhk.p_csr;
                paras[25].Value = struct_aqyhk.p_zsr;
                paras[26].Value = struct_aqyhk.p_lrr;
                paras[27].Value = struct_aqyhk.p_bmdm;

                paras[28].Direction = ParameterDirection.Output;
                int rowsAffected = 0;

                db.RunProcedure("PACK_SKJS_AQYHK.Update_SKJS_AQYHK_Pro", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[28].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_aqyhk.p_czfs;
                struct_rz.czxx = struct_aqyhk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 更新状态
        protected void Update_AQYHKZT(Struct_AQYHK struct_aqyhk)
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
                paras[0].Value = struct_aqyhk.p_id;
                paras[1].Value = struct_aqyhk.p_zt;
                paras[2].Value = struct_aqyhk. p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQYHK.Update_AQYHKZT", paras, out rowsAffected);
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
        protected void Update_AQYHK_SJBS_ZT(Struct_AQYHK struct_aqyhk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_aqyhk.p_sjc;
                paras[1].Value = struct_aqyhk.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQYHK.Update_AQYHK_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_aqyhk.p_czfs;
                struct_rz.czxx = struct_aqyhk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_AQYHK_SJBS_LSSJ_ZT(Struct_AQYHK struct_aqyhk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_aqyhk.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQYHK.Update_AQYHK_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_aqyhk.p_czfs;
                struct_rz.czxx = struct_aqyhk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }




        #region 将副本数据变为最终数据
        protected void Update_AQYHK_SJBS_FBSJ_ZT(Struct_AQYHK struct_aqyhk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_aqyhk.p_sjc;
                paras[1].Value = struct_aqyhk.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQYHK.Update_AQYHK_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_aqyhk.p_czfs;
                struct_rz.czxx = struct_aqyhk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #endregion

        protected int AQYHK_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_AQYHK_Detail(id);
            //备份数据
            Struct_AQYHK aqyhk_bf = new Struct_AQYHK();

            aqyhk_bf.p_ygbh = dt_detail.Rows[0]["ygbh"].ToString();
            aqyhk_bf.p_tbrq = Convert.ToDateTime(dt_detail.Rows[0]["tbrq"].ToString());
            aqyhk_bf.p_tbdw = dt_detail.Rows[0]["tbdw"].ToString();
            aqyhk_bf.p_yhfxsj = Convert.ToDateTime(dt_detail.Rows[0]["yhfxsj"].ToString());
            aqyhk_bf.p_ly = dt_detail.Rows[0]["ly"].ToString();
            aqyhk_bf.p_yhms = dt_detail.Rows[0]["yhms"].ToString();
            aqyhk_bf.p_knzcwh = dt_detail.Rows[0]["knzcwh"].ToString();
            aqyhk_bf.p_yhdj = dt_detail.Rows[0]["yhdj"].ToString();
            aqyhk_bf.p_pgfjpz = dt_detail.Rows[0]["pgfjpz"].ToString();
            aqyhk_bf.p_zgcs = dt_detail.Rows[0]["zgcs"].ToString();
            aqyhk_bf.p_yjtrfy = dt_detail.Rows[0]["yjtrfy"].ToString();
            aqyhk_bf.p_zgwcsx = Convert.ToDateTime(dt_detail.Rows[0]["zgwcsx"].ToString());
            aqyhk_bf.p_wcjdms = dt_detail.Rows[0]["wcjdms"].ToString();
            aqyhk_bf.p_zgzrdw = dt_detail.Rows[0]["zgzrdw"].ToString();
            aqyhk_bf.p_zgzrr = dt_detail.Rows[0]["zgzrr"].ToString();
            aqyhk_bf.p_zgdbzrr = dt_detail.Rows[0]["zgdbzrr"].ToString();
            aqyhk_bf.p_zgfapz = dt_detail.Rows[0]["zgfapz"].ToString();
            aqyhk_bf.p_zgyzjg = dt_detail.Rows[0]["zgyzjg"].ToString();
            aqyhk_bf.p_zgyzr = dt_detail.Rows[0]["zgyzr"].ToString();
            aqyhk_bf.p_zggbsj = Convert.ToDateTime(dt_detail.Rows[0]["zggbsj"].ToString());
            aqyhk_bf.p_zggbbz = dt_detail.Rows[0]["zggbbz"].ToString();
            aqyhk_bf.p_zggbpz = dt_detail.Rows[0]["zggbpz"].ToString();
            aqyhk_bf.p_xgtzbcqk = dt_detail.Rows[0]["xgtzbcqk"].ToString();


            aqyhk_bf.p_zt = "0";
            aqyhk_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            aqyhk_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            aqyhk_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            aqyhk_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            aqyhk_bf.p_lrr = _us.userLoginName;
            aqyhk_bf.p_sjbs = "2";
            aqyhk_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            aqyhk_bf.p_shsj = "";
            aqyhk_bf.p_czfs = "02";
            aqyhk_bf.p_czxx = "安全隐患库id:" + id + "生成副本数据";
            //插入
            Insert_AQYHK(aqyhk_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = aqyhk_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SKJS_AQYHK.Select_AQYHK_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
    }
}

