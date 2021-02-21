using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_KG_ZG
    {
        public long p_id;
        public string p_tbdw;//填报单位
        public string p_zgxm;
        public string p_bmdm;//部门代码
        public string p_rwid;//任务ID
        public string p_zgfa;
        public string p_zgjd;
        public string p_fxkzcs;
        public string p_zrr;
        public DateTime p_zgsx;
        public DateTime p_zgsxks;
        public DateTime p_zgsxjs;
        public string p_wtly;
        public string p_wtlb;
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public int p_userid;
        public string filepath;
    }

    public struct Struct_KG_Select_ZG
    {
        public long p_id;
        public string p_tbdw;//填报单位
        public string p_zgxm;
        public string p_bmdm;//部门代码
        public string p_rwid;//任务ID
        public string p_zgfa;
        public string p_zgjd;
        public string p_fxkzcs;
        public string p_zrr;
        public DateTime p_zgsx;
        public DateTime p_zgsxks;
        public DateTime p_zgsxjs;
        public string p_wtly;
        public string p_wtlb;
        public string p_zt;//状态代码
        public string p_bhyy;//驳回原因
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public int p_userid;


        //pagesize currentpage  

    }
     public class OKG_ZG
    {
        private UserState _us = null;
        private RZ rz = null;
        public OKG_ZG(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }


        #region  ===============长春保障部自查整改表================

        protected DataSet Select_ZG_Pro(Struct_KG_Select_ZG struct_kg_zg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_tbdw",OracleType.VarChar),
                                                  new OracleParameter("p_zgxm",OracleType.VarChar),
                                                  new OracleParameter("p_zgsxks",OracleType.DateTime),
                                                  new OracleParameter("p_zgsxjs",OracleType.DateTime),
                                                  new OracleParameter("p_zrr",OracleType.VarChar),
                                                  new OracleParameter("p_wtly",OracleType.VarChar),
                                                  //new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_kg_zg.p_tbdw;
                parament[1].Value = struct_kg_zg.p_zgxm;
                parament[2].Value = struct_kg_zg.p_zgsxks;
                parament[3].Value = struct_kg_zg.p_zgsxjs;
                parament[4].Value = struct_kg_zg.p_zrr;
                parament[5].Value = struct_kg_zg.p_wtly;
                //parament[6].Value = struct_kg_zg.p_bmdm;
                parament[6].Value = struct_kg_zg.p_zt;
                parament[7].Value = struct_kg_zg.p_pagesize;
                parament[8].Value = struct_kg_zg.p_currentpage;
                parament[9].Value = struct_kg_zg.p_userid;
                parament[10].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_ZG.Select_ZG_Pro", parament, "Tables");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询员工惩罚数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_ZG_Count(Struct_KG_Select_ZG kg_zg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  
                                                  new OracleParameter("p_zgsxks",OracleType.DateTime),
                                                  new OracleParameter("p_zgsxjs",OracleType.DateTime),
                                                  new OracleParameter("p_zrr",OracleType.VarChar),
                                                  new OracleParameter("p_tbdw",OracleType.VarChar),
                                                  new OracleParameter("p_zgxm",OracleType.VarChar),
                                                  new OracleParameter("p_wtly",OracleType.VarChar),
                                                  //new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = kg_zg.p_zgsxks;
                parament[1].Value = kg_zg.p_zgsxjs;
                parament[2].Value = kg_zg.p_zrr;
                parament[3].Value = kg_zg.p_tbdw;
                parament[4].Value = kg_zg.p_zgxm;
                parament[5].Value = kg_zg.p_wtly;
               // parament[6].Value = kg_zg.p_bmdm;
                parament[6].Value = kg_zg.p_zt;
                parament[7].Value = kg_zg.p_userid;
                parament[8].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_ZG.Select_ZG_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
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
                dt = db.RunProcedure("PACK_KG_ZG.Select_YGXMbyBH", paras, "table").Tables[0];
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
                dt = dbclass.RunProcedure("PACK_KG_ZG.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查询整改详情
        protected DataTable Select_ZG_Detail(long id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_ZG.Select_ZG_Detail ", parament, "table").Tables[0];
                //int returnCode = Convert.ToInt32(parament[1].Value);
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        protected void Insert_ZG(Struct_KG_ZG struct_kg_zg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_tbdw",OracleType.VarChar),
                                                   new OracleParameter("p_zgxm",OracleType.VarChar),
                                                   new OracleParameter("p_rwid",OracleType.VarChar),
                                                   new OracleParameter("p_zgfa",OracleType.VarChar),
                                                   new OracleParameter("p_zgjd",OracleType.VarChar),
                                                   new OracleParameter("p_fxkzcs",OracleType.VarChar),
                                                   new OracleParameter("p_zrr",OracleType.VarChar),
                                                   new OracleParameter("p_zgsx",OracleType.DateTime),
                                                   new OracleParameter("p_wtly",OracleType.VarChar),
                                                   new OracleParameter("p_wtlb",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                                   //new OracleParameter("p_filepath",OracleType.VarChar)
                                           };
                parament[0].Value = struct_kg_zg.p_id;
                parament[1].Value = struct_kg_zg.p_tbdw;
                parament[2].Value = struct_kg_zg.p_zgxm;
                parament[3].Value = struct_kg_zg.p_rwid;
                parament[4].Value = struct_kg_zg.p_zgfa;
                parament[5].Value = struct_kg_zg.p_zgjd;
                parament[6].Value = struct_kg_zg.p_fxkzcs;
                parament[7].Value = struct_kg_zg.p_zrr;
                parament[8].Value = struct_kg_zg.p_zgsx;
                parament[9].Value = struct_kg_zg.p_wtly;
                parament[10].Value = struct_kg_zg.p_wtlb;
                parament[11].Value = struct_kg_zg.p_bmdm;
                parament[12].Direction = ParameterDirection.Output;
                //parament[13].Value = struct_kg_zg.filepath;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZG.Insert_ZG", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[12].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_kg_zg.p_czfs;
                struct_rz.czxx = struct_kg_zg.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 更新状态
        protected void Update_ZG_ZT(Struct_KG_Select_ZG struct_kg_zg)
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
                paras[0].Value = struct_kg_zg.p_id;
                paras[1].Value = struct_kg_zg.p_zt;
                paras[2].Value = struct_kg_zg.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ZG.Update_ZG_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_kg_zg.p_czfs;
                struct_rz.czxx = struct_kg_zg.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 编辑整改内容
        protected void Update_ZG(Struct_KG_ZG struct_kg_zg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_tbdw",OracleType.VarChar),
                                                   new OracleParameter("p_zgxm",OracleType.VarChar),
                                                   new OracleParameter("p_rwid",OracleType.VarChar),
                                                   new OracleParameter("p_zgfa",OracleType.VarChar),
                                                   new OracleParameter("p_zgjd",OracleType.VarChar),
                                                   new OracleParameter("p_fxkzcs",OracleType.VarChar),
                                                   new OracleParameter("p_zrr",OracleType.VarChar),
                                                   new OracleParameter("p_zgsx",OracleType.DateTime),
                                                   new OracleParameter("p_wtly",OracleType.VarChar),
                                                   new OracleParameter("p_wtlb",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                                   //new OracleParameter("p_filepath",OracleType.VarChar)
                                           };
                parament[0].Value = struct_kg_zg.p_id;
                parament[1].Value = struct_kg_zg.p_tbdw;
                parament[2].Value = struct_kg_zg.p_zgxm;
                parament[3].Value = struct_kg_zg.p_rwid;
                parament[4].Value = struct_kg_zg.p_zgfa;
                parament[5].Value = struct_kg_zg.p_zgjd;
                parament[6].Value = struct_kg_zg.p_fxkzcs;
                parament[7].Value = struct_kg_zg.p_zrr;
                parament[8].Value = struct_kg_zg.p_zgsx;
                parament[9].Value = struct_kg_zg.p_wtly;
                parament[10].Value = struct_kg_zg.p_wtlb;
                parament[11].Value = struct_kg_zg.p_bmdm;
                parament[12].Direction = ParameterDirection.Output;
                //parament[13].Value = struct_kg_zg.filepath;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZG.ZG_Edit", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[12].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_kg_zg.p_czfs;
                struct_rz.czxx = struct_kg_zg.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 删除整改内容
        internal void Delete_ZG(long p_id,string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Number),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_id; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZG.Delete_ZG", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
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

        #endregion
        #region 添加时查询检查记录ID、检查单、检查内容
        protected DataTable Select_JCJL(string jcd)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parameter = {
                                                  new OracleParameter("p_tbdw",OracleType.VarChar),
                                                  new OracleParameter ("p_cur",OracleType .Cursor )
                                              };
                parameter[0].Value = jcd;
                parameter[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_ZG.Select_JCJL", parameter, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 根据检查单、检查内容查询检查记录中的ID
        protected DataTable Select_JCJL(string jcd, string jcxm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parameter = {
                                                  new OracleParameter("p_tbdw",OracleType.VarChar),
                                                  new OracleParameter("p_jcxm",OracleType.VarChar),
                                                  new OracleParameter ("p_cur",OracleType .Cursor )
                                              };
                parameter[0].Value = jcd;
                parameter[1].Value = jcxm;
                parameter[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_ZG.Select_JCJLID", parameter, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
    }
}
#endregion      