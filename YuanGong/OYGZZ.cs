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
    public struct Struct_YGZZ{
        public long p_id;
        public string p_ygbh;
        public string lx;
        public string p_yydj;
        public DateTime p_yyyxq;
        public string p_zzwjhm;
        public string p_zzbh;
        public DateTime p_bfrq;
        public string p_qzzy;
        public string p_zzqzlb;
        public DateTime p_zclbyxq;
        public string p_ydqz;
        public string p_ydqzlb;
        public DateTime p_ydqzyxq;
        public string p_tjdj;
        public DateTime p_tjyxq;
        public string p_bz;
        public string p_zt;
        public string p_czfs;
        public string p_czxx;
        public string p_zzqzx;
        public string p_zzqzd;
        public string p_ydqzd;
        public DateTime p_qzyxq;
        public string p_ydqzx;
        public string p_bmdm;//部门代码
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bhyy;//驳回原因
        public string p_userid;//驳回原因
        public string p_s1;
        public string p_s2;
        public string p_s3;
        public string p_s4;
        public string p_s5;
        public string p_s6;
        public string p_s7;
        public string p_s8;
        public DateTime p_d1;
        public DateTime p_d2;
        public DateTime p_d3;



    }
    public struct Struct_Select_YGZZ { 
        public string p_bh;//员工编号
        public string p_xm;//员工姓名
        public string p_bmdm;//部门代码
        public string p_gwdm;//岗位代码
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public int p_userid;
    }
    public class OYGZZ
    {
        private UserState _us = null;
        private RZ rz = null;
        private UserState _usState;
        public OYGZZ(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询员工资质


        /// <summary>
        /// 查询员工基本信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGZZ_Pro(Struct_Select_YGZZ ygzz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = ygzz.p_bh;
                paras[1].Value = ygzz.p_xm;
                paras[2].Value = ygzz.p_bmdm;
                paras[3].Value = ygzz.p_gwdm;
                paras[4].Value = ygzz.p_userid;
                paras[5].Value = ygzz.p_pagesize;
                paras[6].Value = ygzz.p_currentpage;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGZZ.Select_YGZZ_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //普通员工基本信息查询
        protected DataTable Select_YGZZ_Pro_Ptyg(Struct_Select_YGZZ ygzz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = ygzz.p_bh;
                paras[1].Value = ygzz.p_xm;
                paras[2].Value = ygzz.p_bmdm;
                paras[3].Value = ygzz.p_gwdm;
                paras[4].Value = ygzz.p_userid;
                paras[5].Value = ygzz.p_pagesize;
                paras[6].Value = ygzz.p_currentpage;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGZZ.Select_YGZZ_Pro_Ptyg", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        /// <summary>
        /// 查询员工数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_YGZZCount(Struct_Select_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_bh",OracleType.VarChar),
                        new OracleParameter("p_xm",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_gwdm",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = ygzz.p_bh;
                paras[1].Value = ygzz.p_xm;
                paras[2].Value = ygzz.p_bmdm;
                paras[3].Value = ygzz.p_gwdm;
                paras[4].Value = ygzz.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_YGZZ.Select_YGZZCount", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        //普通员工信息数量查询
        protected int Select_YGZZCount_Ptyg(Struct_Select_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_bh",OracleType.VarChar),
                        new OracleParameter("p_xm",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_gwdm",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = ygzz.p_bh;
                paras[1].Value = ygzz.p_xm;
                paras[2].Value = ygzz.p_bmdm;
                paras[3].Value = ygzz.p_gwdm;
                paras[4].Value = ygzz.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_YGZZ.Select_YGZZCount_Ptyg", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 查询员工资质详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataSet Select_YGZZByYGBH(string p_ygbh,int p_userid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                       new OracleParameter("p_ygbh",OracleType.VarChar),
                       new OracleParameter("p_userid",OracleType.Int32),
                       new OracleParameter("p_cur1",OracleType.Cursor),
                       new OracleParameter("p_cur2",OracleType.Cursor),
                       new OracleParameter("p_cur3",OracleType.Cursor)
                 };
                paras[0].Value = p_ygbh;
                paras[1].Value = p_userid;
                paras[2].Direction = ParameterDirection.Output;
                paras[3].Direction = ParameterDirection.Output;
                paras[4].Direction = ParameterDirection.Output;
                DataSet dt_zz = new DataSet();
                dt_zz = dbclass.RunProcedure("PACK_KG_YGZZ.Select_YGZZByYGBH", paras, "tables");
                return dt_zz;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected String Select_BmdmByBh(string bh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                       new OracleParameter("p_bh",OracleType.VarChar),
                       new OracleParameter("p_cur",OracleType.Cursor),
                       
                 };
                paras[0].Value = bh;
                paras[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_YGZZ.Select_BmdmByBh", paras, "tables");
                return(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 根据id查询员工资质详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGZZByZZID(int  id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                       new OracleParameter("p_id",OracleType.Int32),
                       new OracleParameter("p_cur",OracleType.Cursor)
                       
                 };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;                
                DataTable dt_zz = new DataTable();
                dt_zz = dbclass.RunProcedure("PACK_KG_YGZZ.Select_YGZZByZZID", paras, "tables").Tables[0];
                return dt_zz;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion

        #region 删除


        /// <summary>
        /// 删除员工资质表
        /// </summary>
        /// <param name="bh"></param>
        protected void Delete_YGZZ_byID(int id,string p_czfs,string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_id",OracleType.Number),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                        };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZZ.Delete_YGZZ_byID", paras, out rowsAffected);
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
        /// 插入英语资质
        /// </summary>
        /// <param name="ygzz"></param>
        protected void Insert_YGZZ_ENG(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                         new OracleParameter("p_ygbh",OracleType.VarChar),
                         new OracleParameter("p_lx",OracleType.VarChar),
                         new OracleParameter("p_yydj",OracleType.VarChar),
                         new OracleParameter("p_yyyxq",OracleType.DateTime),
                         new OracleParameter("p_bz",OracleType.VarChar),
                         new OracleParameter("p_csr",OracleType.VarChar),//初审人
                        new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                        new OracleParameter("p_lrr",OracleType.VarChar),//录入人
                        new OracleParameter("p_sjc",OracleType.VarChar),//时间戳
                        new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识
                        new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                         new OracleParameter("p_zt",OracleType.VarChar),
                         new OracleParameter("p_errorCode",OracleType.Int32)
                      };
                paras[0].Value = ygzz.p_ygbh;
                paras[1].Value = ygzz.lx;
                paras[2].Value = ygzz.p_yydj;
                paras[3].Value = ygzz.p_yyyxq;
                paras[4].Value = ygzz.p_bz;
                paras[5].Value = ygzz.p_csr;
                paras[6].Value = ygzz.p_zsr;
                paras[7].Value = ygzz.p_lrr;
                paras[8].Value = ygzz.p_sjc;
                paras[9].Value = ygzz.p_sjbs;
                paras[10].Value = ygzz.p_bhyy;
                paras[11].Value = ygzz.p_zt;
                paras[12].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZZ.Insert_YGZZ_ENG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygzz.p_czfs;
                struct_rz.czxx = ygzz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 插入执照资质
        protected void Insert_YGZZ_ZZ(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            OracleParameter[] paras = {
                                                        new OracleParameter("p_ygbh",OracleType.VarChar),
                                                        new OracleParameter("p_lx",OracleType.VarChar),
                                                        new OracleParameter("p_zzwjhm",OracleType.VarChar),
                                                        new OracleParameter("p_zzbh",OracleType.VarChar),
                                                        new OracleParameter("p_zzbfrq",OracleType.DateTime),
                                                        new OracleParameter("p_bz",OracleType.VarChar),
                                                         new OracleParameter("p_csr",OracleType.VarChar),//初审人
                                                       new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                                                       new OracleParameter("p_lrr",OracleType.VarChar),//录入人
                                                       new OracleParameter("p_sjc",OracleType.VarChar),//时间戳
                                                       new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识
                                                        new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                                                         new OracleParameter("p_zt",OracleType.VarChar),
                                                        new OracleParameter("p_errorCode",OracleType.Int32)
                                                         };
            paras[0].Value = ygzz.p_ygbh;
            paras[1].Value = ygzz.lx;
            paras[2].Value = ygzz.p_zzwjhm;
            paras[3].Value = ygzz.p_zzbh;
            paras[4].Value = ygzz.p_bfrq;
            paras[5].Value = ygzz.p_bz;
            paras[6].Value = ygzz.p_csr;
            paras[7].Value = ygzz.p_zsr;
            paras[8].Value = ygzz.p_lrr;
            paras[9].Value = ygzz.p_sjc;
            paras[10].Value = ygzz.p_sjbs;
            paras[11].Value = ygzz.p_bhyy;
            paras[12].Value = ygzz.p_zt;
            paras[13].Direction = ParameterDirection.Output;
            int rowsAffected = 0;
            db.RunProcedure("PACK_KG_YGZZ.Insert_YGZZ_ZZ", paras, out rowsAffected);
            int errorCode = 0;
            errorCode = Convert.ToInt32(paras[13].Value);
            if (errorCode != 0)
            {
                throw new EMException(errorCode);
            }
            //插入日志表
            Struct_RZ_YH struct_rz = new Struct_RZ_YH();
            struct_rz.czfs = ygzz.p_czfs;
            struct_rz.czxx = ygzz.p_czxx;
            rz.RZ_Insert_CZ(struct_rz);

        }
        #endregion
        #region 插入签注
        protected void Insert_YGZZ_QZ(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            OracleParameter[] paras = {
                                                        new OracleParameter("p_ygbh",OracleType.VarChar),
                                                        new OracleParameter("p_lx",OracleType.VarChar),
                                                        new OracleParameter("p_qzzy",OracleType.VarChar),
                                                        new OracleParameter("p_qzlb",OracleType.VarChar),
                                                        new OracleParameter("p_qzx",OracleType.VarChar),
                                                        new OracleParameter("p_qzyxq",OracleType.DateTime),
                                                        new OracleParameter("p_qzd",OracleType.VarChar),
                                                        new OracleParameter("p_ydqz",OracleType.VarChar),
                                                        new OracleParameter("p_ydqzx",OracleType.VarChar),
                                                        new OracleParameter("p_ydqzyxq",OracleType.DateTime),
                                                        new OracleParameter("p_ydqzd",OracleType.VarChar),
                                                        new OracleParameter("p_tjdj",OracleType.VarChar),
                                                        new OracleParameter("p_tjyxq",OracleType.DateTime),
                                                        new OracleParameter("p_bz",OracleType.VarChar),
                                                        new OracleParameter("p_csr",OracleType.VarChar),//初审人
                                                        new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                                                       new OracleParameter("p_lrr",OracleType.VarChar),//录入人
                                                         new OracleParameter("p_sjc",OracleType.VarChar),//时间戳
                                                          new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识
                                                         new OracleParameter("p_bhyy",OracleType.VarChar),//驳回因原
                                                          new OracleParameter("p_zt",OracleType.VarChar),
                                                        new OracleParameter("p_errorCode",OracleType.Int32)
                                                         };
            paras[0].Value = ygzz.p_ygbh;
            paras[1].Value = ygzz.lx;
            paras[2].Value = ygzz.p_qzzy;
            paras[3].Value = ygzz.p_zzqzlb;
            paras[4].Value = ygzz.p_zzqzx;
            paras[5].Value = ygzz.p_zclbyxq;
            paras[6].Value = ygzz.p_zzqzd;
            paras[7].Value = ygzz.p_ydqz;
            paras[8].Value = ygzz.p_ydqzx;
            paras[9].Value = ygzz.p_ydqzyxq;
            paras[10].Value = ygzz.p_ydqzd;
            paras[11].Value = ygzz.p_tjdj;
            paras[12].Value = ygzz.p_tjyxq;
            paras[13].Value = ygzz.p_bz;
            paras[14].Value = ygzz.p_csr;
            paras[15].Value = ygzz.p_zsr;
            paras[16].Value = ygzz.p_lrr;
            paras[17].Value = ygzz.p_sjc;
            paras[18].Value = ygzz.p_sjbs;
            paras[19].Value = ygzz.p_bhyy;
            paras[20].Value = ygzz.p_zt;
            paras[21].Direction = ParameterDirection.Output;
            int rowsAffected = 0;
            db.RunProcedure("PACK_KG_YGZZ.Insert_YGZZ_QZ", paras, out rowsAffected);
            int errorCode = 0;
            errorCode = Convert.ToInt32(paras[21].Value);
            if (errorCode != 0)
            {
                throw new EMException(errorCode);
            }
            //插入日志表
            Struct_RZ_YH struct_rz = new Struct_RZ_YH();
            struct_rz.czfs = ygzz.p_czfs;
            struct_rz.czxx = ygzz.p_czxx;
            rz.RZ_Insert_CZ(struct_rz);

        }
        #endregion
        #region  编辑
        /// <summary>
        /// 编辑英语资质
        /// </summary>
        /// <param name="ygzz"></param>
        protected void Update_YGZZ_ENG(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                         new OracleParameter("p_id",OracleType.Int32),
                         new OracleParameter("p_yydj",OracleType.VarChar),
                         new OracleParameter("p_yyyxq",OracleType.DateTime),
                         new OracleParameter("p_bz",OracleType.VarChar),
                         new OracleParameter("p_csr",OracleType.VarChar),
                         new OracleParameter("p_zsr",OracleType.VarChar),
                         new OracleParameter("p_lrr",OracleType.VarChar),
                         new OracleParameter("p_zt",OracleType.VarChar),
                         new OracleParameter("p_sjbs",OracleType.VarChar),
                         new OracleParameter("p_errorCode",OracleType.Int32)
                      };
                paras[0].Value = ygzz.p_id;
                paras[1].Value = ygzz.p_yydj;
                paras[2].Value = ygzz.p_yyyxq;
                paras[3].Value = ygzz.p_bz;
                paras[4].Value = ygzz.p_csr;
                paras[5].Value = ygzz.p_zsr;
                paras[6].Value = ygzz.p_lrr;
                paras[7].Value = ygzz.p_zt;
                paras[8].Value = ygzz.p_sjbs;
                paras[9].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZZ.Update_YGZZ_ENG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[9].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygzz.p_czfs;
                struct_rz.czxx = ygzz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 更新执照资质
        /// </summary>
        /// <param name="ygzz"></param>
        protected void Update_YGZZ_ZZ(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            OracleParameter[] paras = {
                                                        new OracleParameter("p_id",OracleType.Int32),
                                                        new OracleParameter("p_zzwjhm",OracleType.VarChar),
                                                        new OracleParameter("p_zzbh",OracleType.VarChar),
                                                        new OracleParameter("p_zzbfrq",OracleType.DateTime),
                                                        new OracleParameter("p_bz",OracleType.VarChar),
                                                        new OracleParameter("p_csr",OracleType.VarChar),
                                                        new OracleParameter("p_zsr",OracleType.VarChar),
                                                        new OracleParameter("p_lrr",OracleType.VarChar),
                                                        new OracleParameter("p_zt",OracleType.VarChar),
                                                        new OracleParameter("p_sjbs",OracleType.VarChar),
                                                        new OracleParameter("p_errorCode",OracleType.Int32)
                                                         };
            paras[0].Value = ygzz.p_id;
            paras[1].Value = ygzz.p_zzwjhm;
            paras[2].Value = ygzz.p_zzbh;
            paras[3].Value = ygzz.p_bfrq;
            paras[4].Value = ygzz.p_bz;
            paras[5].Value = ygzz.p_csr;
            paras[6].Value = ygzz.p_zsr;
            paras[7].Value = ygzz.p_lrr;
            paras[8].Value = ygzz.p_zt;
            paras[9].Value = ygzz.p_sjbs;
            paras[10].Direction = ParameterDirection.Output;
            int rowsAffected = 0;
            db.RunProcedure("PACK_KG_YGZZ.Update_YGZZ_ZZ", paras, out rowsAffected);
            int errorCode = 0;
            errorCode = Convert.ToInt32(paras[10].Value);
            if (errorCode != 0)
            {
                throw new EMException(errorCode);
            }
            //插入日志表
            Struct_RZ_YH struct_rz = new Struct_RZ_YH();
            struct_rz.czfs = ygzz.p_czfs;
            struct_rz.czxx = ygzz.p_czxx;
            rz.RZ_Insert_CZ(struct_rz);

        }
        /// <summary>
        /// 更新执照资质
        /// </summary>
        /// <param name="ygzz"></param>
        protected void Update_YGZZ_QZ(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            OracleParameter[] paras = {
                                                        new OracleParameter("p_id",OracleType.Int32),
                                                        new OracleParameter("p_qzzy",OracleType.VarChar),
                                                        new OracleParameter("p_qzlb",OracleType.VarChar),
                                                        new OracleParameter("p_qzx",OracleType.VarChar),
                                                        new OracleParameter("p_qzyxq",OracleType.DateTime),
                                                        new OracleParameter("p_qzd",OracleType.VarChar),
                                                        new OracleParameter("p_ydqz",OracleType.VarChar),
                                                        new OracleParameter("p_ydqzx",OracleType.VarChar),
                                                        new OracleParameter("p_ydqzyxq",OracleType.DateTime),
                                                        new OracleParameter("p_ydqzd",OracleType.VarChar),
                                                        new OracleParameter("p_tjdj",OracleType.VarChar),
                                                        new OracleParameter("p_tjyxq",OracleType.DateTime),
                                                        new OracleParameter("p_bz",OracleType.VarChar),
                                                        new OracleParameter("p_csr",OracleType.VarChar),
                                                        new OracleParameter("p_zsr",OracleType.VarChar),
                                                        new OracleParameter("p_lrr",OracleType.VarChar),
                                                        new OracleParameter("p_zt",OracleType.VarChar),
                                                        new OracleParameter("p_sjbs",OracleType.VarChar),
                                                        new OracleParameter("p_errorCode",OracleType.Int32)
                                                         };
            paras[0].Value = ygzz.p_id;
            paras[1].Value = ygzz.p_qzzy;
            paras[2].Value = ygzz.p_zzqzlb;
            paras[3].Value = ygzz.p_zzqzx;
            paras[4].Value = ygzz.p_zclbyxq;
            paras[5].Value = ygzz.p_zzqzd;
            paras[6].Value = ygzz.p_ydqz;
            paras[7].Value = ygzz.p_ydqzx;
            paras[8].Value = ygzz.p_ydqzyxq;
            paras[9].Value = ygzz.p_ydqzd;
            paras[10].Value = ygzz.p_tjdj;
            paras[11].Value = ygzz.p_tjyxq;
            paras[12].Value = ygzz.p_bz;
            paras[13].Value = ygzz.p_csr;
            paras[14].Value = ygzz.p_zsr;
            paras[15].Value = ygzz.p_lrr;
            paras[16].Value = ygzz.p_zt;
            paras[17].Value = ygzz.p_sjbs;
            paras[18].Direction = ParameterDirection.Output;
            int rowsAffected = 0;
            db.RunProcedure("PACK_KG_YGZZ.Update_YGZZ_QZ", paras, out rowsAffected);
            int errorCode = 0;
            errorCode = Convert.ToInt32(paras[18].Value);
            if (errorCode != 0)
            {
                throw new EMException(errorCode);
            }
            //插入日志表
            Struct_RZ_YH struct_rz = new Struct_RZ_YH();
            struct_rz.czfs = ygzz.p_czfs;
            struct_rz.czxx = ygzz.p_czxx;
            rz.RZ_Insert_CZ(struct_rz);

        }
        //protected void Update_YGZZ(Struct_YGZZ ygzz)
        //{
        //    DBClass db = new DBClass();
        //    try
        //    {
        //        OracleParameter[] paras ={
        //                new OracleParameter("p_id",OracleType.Number),
        //                new OracleParameter("p_ygbh",OracleType.VarChar),
        //                new OracleParameter("p_yydj",OracleType.VarChar),
        //                new OracleParameter("p_yyyxq",OracleType.DateTime),
        //                new OracleParameter("p_zzwjhm",OracleType.VarChar),
        //                new OracleParameter("p_zzbh",OracleType.VarChar),
        //                new OracleParameter("p_bfrq",OracleType.VarChar),
        //                new OracleParameter("p_qzzy",OracleType.VarChar),
        //                new OracleParameter("p_zzqzlb",OracleType.VarChar),
        //                new OracleParameter("p_zclbyxq",OracleType.DateTime),
        //                new OracleParameter("p_ydqz",OracleType.VarChar),
        //                new OracleParameter("p_ydqzlb",OracleType.VarChar),
        //                new OracleParameter("p_ydqzyxq",OracleType.DateTime),
        //                new OracleParameter("p_tjdj",OracleType.VarChar),
        //                new OracleParameter("p_tjyxq",OracleType.DateTime),
        //                new OracleParameter("p_bz",OracleType.VarChar),
        //                new OracleParameter("p_errorCode",OracleType.Int32)
        //         };
        //        paras[0].Value = ygzz.p_id;
        //        paras[1].Value = ygzz.p_ygbh;
        //        paras[2].Value = ygzz.p_yydj;
        //        paras[3].Value = ygzz.p_yyyxq;
        //        paras[4].Value = ygzz.p_zzwjhm;
        //        paras[5].Value = ygzz.p_zzbh;
        //        paras[6].Value = ygzz.p_bfrq;
        //        paras[7].Value = ygzz.p_qzzy;
        //        paras[8].Value = ygzz.p_zzqzlb;
        //        paras[9].Value = ygzz.p_zclbyxq;
        //        paras[10].Value = ygzz.p_ydqz;
        //        paras[11].Value = ygzz.p_ydqzlb;
        //        paras[12].Value = ygzz.p_ydqzyxq;
        //        paras[13].Value = ygzz.p_tjdj;
        //        paras[14].Value = ygzz.p_tjyxq;
        //        paras[15].Value = ygzz.p_bz;
        //        paras[16].Direction = ParameterDirection.Output;
        //        int rowsAffected = 0;
        //        db.RunProcedure("PACK_YGGL_YGZZ.Update_YGZZ", paras, out rowsAffected);
        //        int errorCode = 0;
        //        errorCode = Convert.ToInt32(paras[16].Value);
        //        if (errorCode != 0)
        //        {
        //            throw new EMException(errorCode);
        //        }
        //        //插入日志表
        //        Struct_RZ_YH struct_rz = new Struct_RZ_YH();
        //        struct_rz.czfs = ygzz.p_czfs;
        //        struct_rz.czxx = ygzz.p_czxx;
        //        rz.RZ_Insert_CZ(struct_rz);
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //}


        ///// <summary>
        ///// 更新员工表中的资质信息
        ///// </summary>
        ///// <param name="ygzz"></param>
        //protected void Update_YG_YGZZ(Struct_YGZZ ygzz)
        //{
        //    DBClass db = new DBClass();
        //    try
        //    {
        //        OracleParameter[] paras ={
        //                new OracleParameter("p_ygbh",OracleType.VarChar),
        //                new OracleParameter("p_yydj",OracleType.VarChar),
        //                new OracleParameter("p_yyyxq",OracleType.DateTime),
        //                new OracleParameter("p_zzwjhm",OracleType.VarChar),
        //                new OracleParameter("p_zzbh",OracleType.VarChar),
        //                new OracleParameter("p_bfrq",OracleType.VarChar),
        //                new OracleParameter("p_qzzy",OracleType.VarChar),
        //                new OracleParameter("p_zzqzlb",OracleType.VarChar),
        //                new OracleParameter("p_zclbyxq",OracleType.DateTime),
        //                new OracleParameter("p_ydqz",OracleType.VarChar),
        //                new OracleParameter("p_ydqzlb",OracleType.VarChar),
        //                new OracleParameter("p_ydqzyxq",OracleType.DateTime),
        //                new OracleParameter("p_tjdj",OracleType.VarChar),
        //                new OracleParameter("p_tjyxq",OracleType.DateTime),
        //                new OracleParameter("p_errorCode",OracleType.Int32)
        //         };
        //        paras[0].Value = ygzz.p_ygbh;
        //        paras[1].Value = ygzz.p_yydj;
        //        paras[2].Value = ygzz.p_yyyxq;
        //        paras[3].Value = ygzz.p_zzwjhm;
        //        paras[4].Value = ygzz.p_zzbh;
        //        paras[5].Value = ygzz.p_bfrq;
        //        paras[6].Value = ygzz.p_qzzy;
        //        paras[7].Value = ygzz.p_zzqzlb;
        //        paras[8].Value = ygzz.p_zclbyxq;
        //        paras[9].Value = ygzz.p_ydqz;
        //        paras[10].Value = ygzz.p_ydqzlb;
        //        paras[11].Value = ygzz.p_ydqzyxq;
        //        paras[12].Value = ygzz.p_tjdj;
        //        paras[13].Value = ygzz.p_tjyxq;
        //        paras[14].Direction = ParameterDirection.Output;
        //        int rowsAffected = 0;
        //        db.RunProcedure("PACK_YGGL_YGZZ.Update_YG_YGZZ", paras, out rowsAffected);
        //        int errorCode = 0;
        //        errorCode = Convert.ToInt32(paras[14].Value);
        //        if (errorCode != 0)
        //        {
        //            throw new EMException(errorCode);
        //        }
        //        //插入日志表
        //        Struct_RZ_YH struct_rz = new Struct_RZ_YH();
        //        struct_rz.czfs = ygzz.p_czfs;
        //        struct_rz.czxx = ygzz.p_czxx;
        //        rz.RZ_Insert_CZ(struct_rz);
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //}



        #endregion

        #region 更新状态
        protected void Update_ygzz_ZT(long id, string zt, string bhyy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = id;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZZ.Update_ygzz_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 变更数据标识
        protected void Update_YGZZ_SJBS_ZT(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygzz.p_sjc;
                paras[1].Value = ygzz.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZZ.Update_YGZZ_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygzz.p_czfs;
                struct_rz.czxx = ygzz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_YGZZ_SJBS_LSSJ_ZT(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygzz.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZZ.Update_YGZZ_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygzz.p_czfs;
                struct_rz.czxx = ygzz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 将副本数据变为最终数据
        protected void Update_YGZZ_SJBS_FBSJ_ZT(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygzz.p_sjc;
                paras[1].Value = ygzz.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZZ.Update_YGZZ_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygzz.p_czfs;
                struct_rz.czxx = ygzz.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        protected int YGZZ_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_YGZZByZZID(id);
            //备份数据
            Struct_YGZZ ygzz_bf = new Struct_YGZZ();
           
            ygzz_bf.p_ygbh = dt_detail.Rows[0]["ygbh"].ToString();
            ygzz_bf.lx = dt_detail.Rows[0]["lx"].ToString();
            ygzz_bf.p_s1 = dt_detail.Rows[0]["s1"].ToString();
            ygzz_bf.p_s2 = dt_detail.Rows[0]["s2"].ToString();
            ygzz_bf.p_s3 = dt_detail.Rows[0]["s3"].ToString();
            ygzz_bf.p_s4 = dt_detail.Rows[0]["s4"].ToString();
            ygzz_bf.p_s5 = dt_detail.Rows[0]["s5"].ToString();
            ygzz_bf.p_s6 = dt_detail.Rows[0]["s6"].ToString();
            ygzz_bf.p_s7 = dt_detail.Rows[0]["s7"].ToString();
            ygzz_bf.p_s8 = dt_detail.Rows[0]["s8"].ToString();

            if (dt_detail.Rows[0]["d1"].ToString() != "")
            {
                ygzz_bf.p_d1 = Convert.ToDateTime(dt_detail.Rows[0]["d1"].ToString());
            }
            else
            {
            }
            if (dt_detail.Rows[0]["d2"].ToString() != "")
            {
                ygzz_bf.p_d2 = Convert.ToDateTime(dt_detail.Rows[0]["d2"].ToString());
            }
            else
            {
                ygzz_bf.p_d2 = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            if (dt_detail.Rows[0]["d3"].ToString() != "")
            {
                ygzz_bf.p_d3 = Convert.ToDateTime(dt_detail.Rows[0]["d3"].ToString());
            }
            else
            {
                ygzz_bf.p_d2 = Convert.ToDateTime("0001-1-1 00:00:00");
            }                 
            ygzz_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            ygzz_bf.p_zt = "0";
            ygzz_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();           
            ygzz_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            ygzz_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            ygzz_bf.p_lrr = _us.userLoginName;
            ygzz_bf.p_sjbs = "2";
            ygzz_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            ygzz_bf.p_shsj = "";
            ygzz_bf.p_czfs = "02";
            ygzz_bf.p_czxx = "员工资质id:" + id + "生成副本数据";
            //插入
            Insert_YGZZ_BF(ygzz_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = ygzz_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGZZ.Select_YGZZ_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
      #region  添加
        /// <summary>
        /// 插入资质备份
        /// </summary>
        /// <param name="ygzz"></param>
        protected void Insert_YGZZ_BF(Struct_YGZZ ygzz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_ygbh",OracleType.VarChar),
                        new OracleParameter("lx",OracleType.VarChar),
                        new OracleParameter("p_s1",OracleType.VarChar),                       
                        new OracleParameter("p_s2",OracleType.VarChar),
                        new OracleParameter("p_s3",OracleType.VarChar),
                        new OracleParameter("p_s4",OracleType.VarChar),                        
                        new OracleParameter("p_s5",OracleType.VarChar),
                        new OracleParameter("p_s6",OracleType.VarChar),
                        new OracleParameter("p_s7",OracleType.VarChar),                        
                        new OracleParameter("p_s8",OracleType.VarChar),
                        new OracleParameter("p_d1",OracleType.DateTime),
                        new OracleParameter("p_d2",OracleType.DateTime),
                        new OracleParameter("p_d3",OracleType.DateTime),
                        new OracleParameter("p_bz",OracleType.VarChar),
                        new OracleParameter("p_csr",OracleType.VarChar),//初审人
                        new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                        new OracleParameter("p_lrr",OracleType.VarChar),//录入人
                        new OracleParameter("p_sjc",OracleType.VarChar),//时间戳
                        new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识
                        new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                        new OracleParameter("p_errorCode",OracleType.Int32)
                                         };
                paras[0].Value = ygzz.p_ygbh;
                paras[1].Value = ygzz.lx;
                paras[2].Value = ygzz.p_s1;
                paras[3].Value = ygzz.p_s2;
                paras[4].Value = ygzz.p_s3;
                paras[5].Value = ygzz.p_s4;
                paras[6].Value = ygzz.p_s5;
                paras[7].Value = ygzz.p_s6;
                paras[8].Value = ygzz.p_s7;
                paras[9].Value = ygzz.p_s8;
                paras[10].Value = ygzz.p_d1;
                paras[11].Value = ygzz.p_d2;
                paras[12].Value = ygzz.p_d3;               
                paras[13].Value = ygzz.p_bz;
                paras[14].Value = ygzz.p_csr;
                paras[15].Value = ygzz.p_zsr;
                paras[16].Value = ygzz.p_lrr;
                paras[17].Value = ygzz.p_sjc;
                paras[18].Value = ygzz.p_sjbs;
                paras[19].Value = ygzz.p_bhyy;
                paras[20].Direction = ParameterDirection.Output;
            int rowsAffected = 0;
            db.RunProcedure("PACK_KG_YGZZ.Insert_YGZZ_PRO", paras, out rowsAffected);
            int errorCode = 0;
            errorCode = Convert.ToInt32(paras[20].Value);
            if (errorCode != 0)
            {
                throw new EMException(errorCode);
            }
            //插入日志表
            Struct_RZ_YH struct_rz = new Struct_RZ_YH();
            struct_rz.czfs = ygzz.p_czfs;
            struct_rz.czxx = ygzz.p_czxx;
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
