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
    public struct Struct_zbjs
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
    public struct Struct_Select_JCJL
    {
        public int id;
        public DateTime kssj;//上传开始时间
        public DateTime jssj;//上传结束时间
        public string zt;//状态
        public string tzcz;//跳转传值
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OZBJS
    {
        private UserState _us = null;
        private RZ rz = null;
        public OZBJS(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region  张先震   支部建设的查询、增加、删除
        protected DataSet Select_DQZC_ZBJS(Struct_zbjs struct_zbjs)
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
                parament[0].Value = struct_zbjs.kssj;
                parament[1].Value = struct_zbjs.jssj;
                parament[2].Value = struct_zbjs.zt;
                parament[3].Value = struct_zbjs.lx;
                parament[4].Value = struct_zbjs.p_pagesize;
                parament[5].Value = struct_zbjs.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_ZBJS.Select_DQZC_ZBJS", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DQZC_ZBJS_Count(Struct_zbjs struct_zbjs)
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
                parament[0].Value = struct_zbjs.kssj;
                parament[1].Value = struct_zbjs.jssj;
                parament[2].Value = struct_zbjs.lx;
                parament[3].Value = struct_zbjs.zt;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_ZBJS.Select_DQZC_ZBJS_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        protected DataSet Select_DQZC_ZBJSShow(Struct_zbjs struct_zbjs)
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
                parament[0].Value = struct_zbjs.kssj;
                parament[1].Value = struct_zbjs.jssj;
                
                parament[2].Value = struct_zbjs.lx;
                parament[3].Value = struct_zbjs.p_pagesize;
                parament[4].Value = struct_zbjs.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_ZBJS.Select_DQZC_ZBJSShow", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DQZC_ZBJSShow_Count(Struct_zbjs struct_zbjs)
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
                parament[0].Value = struct_zbjs.kssj;
                parament[1].Value = struct_zbjs.jssj;
                parament[2].Value = struct_zbjs.lx;
               
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_ZBJS.Select_DQZC_ZBJSShow_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        protected void Insert_DQZC_ZBJS(Struct_zbjs struct_zbjs)
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

                parament[0].Value = struct_zbjs.id;
                parament[1].Value = struct_zbjs.wjm;
                parament[2].Value = struct_zbjs.scsj;
                parament[3].Value = struct_zbjs.scr;
                parament[4].Value = struct_zbjs.scip;
                parament[5].Value = struct_zbjs.sclj;
                parament[6].Value = struct_zbjs.lx;
                parament[7].Value = struct_zbjs.zt;/////////////这里有plsql里面没有状态，以前检查记录里面有待确定
                parament[8].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_ZBJS.Insert_DQZC_ZBJS", parament, out reslut);
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
        protected void Delete_DQZC_ZBJS(string id)
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
                dbclass.RunProcedure("PACK_DQZC_ZBJS.Delete_DQZC_ZBJS", parameter, out reslut);
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
        protected void Update_DQZC_ZBJSZT(string id, string zt, string bhyy)
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
                db.RunProcedure("PACK_DQZC_ZBJS.Update_DQZC_ZBJSZT", paras, out rowsAffected);
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
                ds = dbclass.RunProcedure("PACK_DQZC_ZBJS.Select_DQZC_ZBJSbyWDBH", parament, "table");
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
                db.RunProcedure("PACK_DQZC_ZBJS.Select_DQZC_ZBJMaxBH", paras, "dt");
                string maxbh = paras[0].Value.ToString();

                return id + maxbh;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
