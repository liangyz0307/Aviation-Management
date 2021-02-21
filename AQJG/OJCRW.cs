using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_JCRW
        {
            public long id;
            public string jcd;
            public string jcr;
            public string bjcr;
            public DateTime jcsjks;
            public DateTime jcsjjs;
            public DateTime jcsj;
            public string czfs;
            public string czxx;
            public string zt;
            public int pagesize;//每页容量
            public int currentpage;//当前页码
            public string bhyy;
            public string bjbm;   //被检部门
            public string jcbm;   //检查部门
            public string jcxm;   //检查内容
            public string rwsm;   //任务说明
            public string bz;     //备注
            public int p_userid;        //权限用户
            public string jcrwzt;   //检查任务状态
        }        
        
    public class OJCRW
        {
             private UserState _us = null;
              private RZ rz = null;
        public OJCRW(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        protected DataSet Select_JCRW_PRO(Struct_JCRW struct_jcrw)//查询所有信息
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={                                                     
                                                  new OracleParameter("p_jcr",OracleType.VarChar),   
                                                  new OracleParameter("p_bjcr",OracleType.VarChar),
                                                  new OracleParameter ("p_jcsjks",OracleType .DateTime ),
                                                  new OracleParameter ("p_jcsjjs",OracleType .DateTime ),
                                                  new OracleParameter("p_jcd",OracleType.VarChar),
                                                  new OracleParameter("p_jcxm",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_jcrwzt",OracleType.VarChar),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jcrw.jcr;
                parament[1].Value = struct_jcrw.bjcr;
                parament[2].Value = struct_jcrw.jcsjks;
                parament[3].Value = struct_jcrw.jcsjjs;
                parament[4].Value = struct_jcrw.jcd;
                parament[5].Value = struct_jcrw.jcxm;
                parament[6].Value = struct_jcrw.p_userid;
                parament[7].Value = struct_jcrw.pagesize;
                parament[8].Value = struct_jcrw.currentpage;
                parament[9].Value = struct_jcrw.jcrwzt;
                parament[10].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_AQJG_JCRW.Select_JCRW_PRO", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JCRW_Count(Struct_JCRW struct_jcrw)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                                  new OracleParameter("p_jcsjks",OracleType.DateTime),
                                                  new OracleParameter("p_jcsjjs",OracleType.DateTime),
                                                  new OracleParameter("p_jcr",OracleType.VarChar),
                                                  new OracleParameter("p_jcd",OracleType.VarChar),
                                                  new OracleParameter("p_jcxm",OracleType.VarChar),
                                                  new OracleParameter("p_bjcr",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jcrw.jcsjks;
                parament[1].Value = struct_jcrw.jcsjjs;
                parament[2].Value = struct_jcrw.jcr;
                parament[3].Value = struct_jcrw.jcd;
                parament[4].Value = struct_jcrw.jcxm;
                parament[5].Value = struct_jcrw.bjcr;
                parament[6].Value = struct_jcrw.p_userid;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_AQJG_JCRW.Select_JCRW_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        protected void Insert_JCRW(Struct_JCRW struct_jcrw)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_jcsjks",OracleType.DateTime),
                                                   new OracleParameter("p_jcr",OracleType.VarChar),
                                                   new OracleParameter("p_bjcr",OracleType.VarChar),
                                                   new OracleParameter("p_jcd",OracleType.VarChar), 
                                                   new OracleParameter("p_bjbm",OracleType.VarChar),
                                                   new OracleParameter("p_jcbm",OracleType.VarChar),
                                                   new OracleParameter("p_jcxm",OracleType.VarChar),
                                                   new OracleParameter("p_rwsm",OracleType.VarChar),
                                                   new OracleParameter("p_bz",OracleType.VarChar),
                                                   new OracleParameter("p_jcrwzt",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_jcrw.id;
                parament[1].Value = struct_jcrw.jcsjks;
                parament[2].Value = struct_jcrw.jcr;
                parament[3].Value = struct_jcrw.bjcr;
                parament[4].Value = struct_jcrw.jcd;
                parament[5].Value = struct_jcrw.bjbm;
                parament[6].Value = struct_jcrw.jcbm;
                parament[7].Value = struct_jcrw.jcxm;
                parament[8].Value = struct_jcrw.rwsm;
                parament[9].Value = struct_jcrw.bz;
                parament[10].Value = struct_jcrw.jcrwzt;
                parament[11].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_AQJG_JCRW.Insert_JCRW", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[11].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jcrw.czfs;
                struct_rz.czxx = struct_jcrw.czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
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
                dt = db.RunProcedure("PACK_AQJG_JCRW.Select_YGXMbyBH", paras, "table").Tables[0];
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
                dt = dbclass.RunProcedure("PACK_AQJG_JCRW.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        protected DataTable Select_JCRW_Detail(long id)
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
                dt = dbclass.RunProcedure("PACK_AQJG_JCRW.Select_JCRW_Detail ", parament, "table").Tables[0];
                //int returnCode = Convert.ToInt32(parament[1].Value);
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #region
        protected void Update_YGCF(Struct_JCRW struct_jcrw)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_jcsjks",OracleType.DateTime),
                                                   new OracleParameter("p_jcr",OracleType.VarChar),
                                                   new OracleParameter("p_bjcr",OracleType.VarChar),
                                                   new OracleParameter("p_jcd",OracleType.VarChar),
                                                   new OracleParameter("p_jcxm",OracleType.VarChar),
                                                   new OracleParameter("p_bjbm",OracleType.VarChar),
                                                   new OracleParameter("p_rwsm",OracleType.VarChar),
                                                   new OracleParameter("p_bz",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_jcrw.id;
                parament[1].Value = struct_jcrw.jcsjks;
                parament[2].Value = struct_jcrw.jcr;
                parament[3].Value = struct_jcrw.bjcr;
                parament[4].Value = struct_jcrw.jcd;
                parament[5].Value = struct_jcrw.jcxm;
                parament[6].Value = struct_jcrw.bjbm;
                parament[7].Value = struct_jcrw.rwsm;
                parament[8].Value = struct_jcrw.bz;
                parament[9].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_AQJG_JCRW.Update_JCRW", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[9].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jcrw.czfs;
                struct_rz.czxx = struct_jcrw.czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 删除

        /// <summary>
        /// 删除员工惩罚
        /// </summary>
        /// <param name="bh"></param>
        protected void Delete_JCRW_byID(Struct_JCRW struct_jcrw)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Number),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_jcrw.id ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_AQJG_JCRW.Delete_JCRW_byID", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jcrw.czfs;
                struct_rz.czxx = struct_jcrw.czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        //#region 更新状态
        //protected void Update_JCRWZT(Struct_JCRW struct_jcrw)
        //{
        //    DBClass db = new DBClass();
        //    try
        //    {
        //        OracleParameter[] paras ={
        //          new OracleParameter("p_id",OracleType.Number),
        //          new OracleParameter("p_bhyy",OracleType.VarChar),
        //          new OracleParameter("p_errorCode",OracleType.Int32)
        //};
        //        paras[0].Value = struct_jcrw.id;
        //        paras[1].Value = struct_jcrw.bhyy;
        //        paras[2].Direction = ParameterDirection.Output;
        //        int rowsAffected = 0;
        //        db.RunProcedure("PACK_AQJG_JCRW.Update_JCRWZT", paras, out rowsAffected);
        //        int errorCode = 0;
        //        errorCode = Convert.ToInt32(paras[3].Value);
        //        if (errorCode != 0)
        //        {
        //            throw new EMException(errorCode);
        //        }
        //        //插入日志表
        //        Struct_RZ_YH struct_rz = new Struct_RZ_YH();
        //        struct_rz.czfs = struct_jcrw.czfs;
        //        struct_rz.czxx = struct_jcrw.czxx;
        //        rz.RZ_Insert_CZ(struct_rz);
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //}
        //#endregion


        #region
        protected DataTable Select_JCXM(string tbdw )
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_tbdw",OracleType.VarChar), 
                                                new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = tbdw;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_AQJG_JCRW.Select_JCXM ", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
            #endregion
        # region    查询对应的检查任务（详情页面）
        protected DataSet Select_JCJL(Struct_JCRW struct_jcrw)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {                                                   
                                                    new OracleParameter("p_jcd",OracleType.VarChar),
                                                    new OracleParameter("p_jcxm",OracleType.VarChar),                        
                                                    new OracleParameter("p_pagesize",OracleType.Int32),
                                                    new OracleParameter("p_currentpage",OracleType.Int32),                                                    
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };


                parament[0].Value = struct_jcrw.jcd;
                parament[1].Value = struct_jcrw.jcxm;
                parament[2].Value = struct_jcrw.pagesize;
                parament[3].Value = struct_jcrw.currentpage;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_AQJG_JCRW.Select_KG_JCGL", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        
        # endregion
        # region    查询对应的检查任务个数（详情页面）
         protected int Select_KG_JCGL_Count(Struct_JCRW struct_jcrw)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[]parament={                                               
                                                new OracleParameter("p_jcd",OracleType.VarChar),
                                                new OracleParameter("p_jcxm",OracleType.VarChar),                                                                                                
                                                new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_jcrw.jcd;
                parament[1].Value = struct_jcrw.jcxm;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_AQJG_JCRW.Select_KG_JCGL_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }       
        # endregion
        }
}
