using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{

    public struct Struct_ghgl
    {
        public string id;
        public DateTime kssj;//开始时间
        public DateTime jssj;//结束时间
        public DateTime scsj;//上传时间
        public string wjm;//文件名
        //public string p_wdlx;//文件类型        
        public string p_scbm;//上传部门
        public string p_scgw;//上传岗位
        public string scr;//上传人
        public string scip;//上传IP
        public string sclj;//上传路径
        public string zt;//状态
        public string lx;//类型
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_GHGL
    {
        public int id;
        public DateTime kssj;//上传开始时间
        public DateTime jssj;//上传结束时间
        public string zt;//状态
        public string tzcz;//跳转传值
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OGHGL
    {
        private UserState _us = null;
        private RZ rz = null;
        public OGHGL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region    工会管理的查询、增加、删除
        protected DataSet Select_DQZC_GHGL(Struct_ghgl struct_ghgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                    new OracleParameter("p_kssj",OracleType.DateTime),
                                                    new OracleParameter("p_jssj",OracleType.DateTime),
                                                    new OracleParameter("p_zt",OracleType.VarChar),
                                                    new OracleParameter("p_tzcz",OracleType.VarChar),
                                                    new OracleParameter("p_pagesize",OracleType.Int32),
                                                    new OracleParameter("p_currentpage",OracleType.Int32),
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_ghgl.kssj;
                parament[1].Value = struct_ghgl.jssj;
                parament[2].Value = struct_ghgl.zt;
                parament[3].Value = struct_ghgl.lx;
                parament[4].Value = struct_ghgl.p_pagesize;
                parament[5].Value = struct_ghgl.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_GHGL.Select_DQZC_GHGL", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //首页more查询
        protected DataSet Select_GHGLShow_Pro(Struct_ghgl struct_ghgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                    new OracleParameter("p_wjm",OracleType.VarChar),
                                                    new OracleParameter("p_kssj",OracleType.DateTime),
                                                    new OracleParameter("p_jssj",OracleType.DateTime),

                                                    new OracleParameter("p_pagesize",OracleType.Int32),
                                                    new OracleParameter("p_currentpage",OracleType.Int32),
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_ghgl.wjm;
                parament[1].Value = struct_ghgl.kssj;
                parament[2].Value = struct_ghgl.jssj;
                parament[3].Value = struct_ghgl.p_pagesize;
                parament[4].Value = struct_ghgl.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_GHGL.Select_GHGLShow_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DQZC_GHGL_Count(Struct_ghgl struct_ghgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_kssj",OracleType.DateTime),
                                                new OracleParameter("p_jssj",OracleType.DateTime),
                                                new OracleParameter("p_tzcz",OracleType.VarChar),
                                                new OracleParameter("p_zt",OracleType.VarChar),
                                                new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_ghgl.kssj;
                parament[1].Value = struct_ghgl.jssj;
                parament[2].Value = struct_ghgl.lx;
                parament[3].Value = struct_ghgl.zt;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_GHGL.Select_DQZC_GHGL_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        //首页more 数量
        protected int Select_GHGLShow_Count(Struct_ghgl struct_ghgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_wjm",OracleType.VarChar),
                                                new OracleParameter("p_kssj",OracleType.DateTime),
                                                new OracleParameter("p_jssj",OracleType.DateTime),
                                                
                                                new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_ghgl.wjm;
                parament[1].Value = struct_ghgl.kssj;
                parament[2].Value = struct_ghgl.jssj;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_GHGL.Select_GHGLShow_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        protected DataSet Select_DQZC_GHGLShow(Struct_ghgl struct_ghgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                    new OracleParameter("p_kssj",OracleType.DateTime),
                                                    new OracleParameter("p_jssj",OracleType.DateTime),

                                                    new OracleParameter("p_tzcz",OracleType.VarChar),
                                                    new OracleParameter("p_pagesize",OracleType.Int32),
                                                    new OracleParameter("p_currentpage",OracleType.Int32),
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_ghgl.kssj;
                parament[1].Value = struct_ghgl.jssj;

                parament[2].Value = struct_ghgl.lx;
                parament[3].Value = struct_ghgl.p_pagesize;
                parament[4].Value = struct_ghgl.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_GHGL.Select_DQZC_GHGLShow", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DQZC_GHGLShow_Count(Struct_ghgl struct_ghgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_kssj",OracleType.DateTime),
                                                new OracleParameter("p_jssj",OracleType.DateTime),
                                                new OracleParameter("p_tzcz",OracleType.VarChar),

                                                new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_ghgl.kssj;
                parament[1].Value = struct_ghgl.jssj;
                parament[2].Value = struct_ghgl.lx;

                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_GHGL.Select_DQZC_GHGLShow_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        protected void Insert_DQZC_GHGL(Struct_ghgl struct_ghgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.VarChar),
                                                 new OracleParameter("p_wjm",OracleType.VarChar),
                                                 new OracleParameter("p_scsj",OracleType.DateTime),
                                                 new OracleParameter("p_scr",OracleType.VarChar),
                                                 new OracleParameter("p_scip",OracleType.VarChar),
                                                 new OracleParameter("p_sclj",OracleType.VarChar),
                                                 new OracleParameter("p_tzcz",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };

                parament[0].Value = struct_ghgl.id;
                parament[1].Value = struct_ghgl.wjm;
                parament[2].Value = struct_ghgl.scsj;
                parament[3].Value = struct_ghgl.scr;
                parament[4].Value = struct_ghgl.scip;
                parament[5].Value = struct_ghgl.sclj;
                parament[6].Value = struct_ghgl.lx;
                parament[7].Value = struct_ghgl.zt;/////////////这里有plsql里面没有状态，以前检查记录里面有待确定
                parament[8].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_GHGL.Insert_DQZC_GHGL", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[8].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_DQZC_GHGL(string id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parameter ={
                                                new OracleParameter("p_id",OracleType.VarChar),
                                                new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parameter[0].Value = id;
                parameter[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_GHGL.Delete_DQZC_GHGL", parameter, out reslut);
                int returnCode = Convert.ToInt32(parameter[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 更新状态
        protected void Update_DQZC_GHGLZT(string id, string zt, string bhyy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_id",OracleType.VarChar),
                                             new OracleParameter("p_zt",OracleType.VarChar),
                                             new OracleParameter("p_bhyy",OracleType.VarChar),
                                             new OracleParameter("p_errorCode",OracleType.Int32),
                                         };
                paras[0].Value = id;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_DQZC_GHGL.Update_DQZC_GHGLZT", paras, out rowsAffected);
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
        protected DataSet Select_ZLbyWDBH(string id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_GHGL.Select_DQZC_GHGLbyWDBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected string SelectWDBH(string id)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_DQZC_GHGL.Select_DQZC_GHGLMaxBH", paras, "dt");
                string maxbh = paras[0].Value.ToString();

                return id + maxbh;
            }
            finally
            {
                db.Close();
            }
        }

        // 按id查询党群工会动态
        protected DataTable Find_GHGL_ById()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                            new OracleParameter("p_cur",OracleType.Cursor)
                                          };
                paras[0].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_DQZC_GHGL.Find_GHGL_ById", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        



    }

}
