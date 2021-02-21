using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using CUST.Sys;
using CUST;
using Sys;

namespace CUST.MKG
{
    public struct Struct_RZ_YH
    {
        public int id;
        public string zh;
        public string lb;
        public string ip;
        public DateTime sj;
        public string czfs;
        public string czxx;
    }
    public struct Struct_Select_RZ
    {
        public string p_bh;//员工编号
        public string p_xm;//员工姓名
        public string p_bmdm;//部门代码
        public string p_gwdm;//岗位代码
        public string p_czfs;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class ORZ
    {
        private UserState _us = null;
        public ORZ(UserState userstate)
        {
            _us = userstate;
        }
        protected void RZ_Insert_CZ(Struct_RZ_YH rz_struct)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_zh",OracleType.VarChar),
                                               new OracleParameter("p_lb",OracleType.VarChar),
                                               new OracleParameter("p_ip",OracleType.VarChar),
                                               new OracleParameter("p_sj",OracleType.DateTime),
                                               new OracleParameter("p_czfs",OracleType.VarChar),
                                               new OracleParameter("p_czxx",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parament[0].Value = _us.userLoginName;
                parament[1].Value = _us.userLB;
                parament[2].Value = _us.context.IP;
                parament[3].Value = DateTime.Now;
                parament[4].Value = rz_struct.czfs;
                parament[5].Value = rz_struct.czxx;
                parament[6].Direction = ParameterDirection.Output;
                int result = 0;
                db.RunProcedure("PACK_RZGL.RZ_Insert_CZ", parament, out result);
                int errorCode = Convert.ToInt32(parament[6].Value);
                if (errorCode != 0)
                {
                    throw new Exception(errorCode.ToString());
                }
            }
            finally
            {
                db.Close();
            }
        }

       
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="rz"></param>
        /// <returns></returns>
        protected DataTable Select_RZ_Pro(Struct_Select_RZ rz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_czfs",OracleType.VarChar),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = rz.p_bh;
                paras[1].Value = rz.p_xm;
                paras[2].Value = rz.p_bmdm;
                paras[3].Value = rz.p_gwdm;
                paras[4].Value = rz.p_czfs;
                paras[5].Value = rz.p_pagesize;
                paras[6].Value = rz.p_currentpage;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_RZGL.Select_RZ_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

      /// <summary>
        /// 查询日志数量
      /// </summary>
      /// <param name="rz"></param>
      /// <returns></returns>
        protected int Select_RZ_Count(Struct_Select_RZ rz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_bh",OracleType.VarChar),
                        new OracleParameter("p_xm",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_gwdm",OracleType.VarChar),
                        new OracleParameter("p_czfs",OracleType.VarChar),
                        new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = rz.p_bh;
                paras[1].Value = rz.p_xm;
                paras[2].Value = rz.p_bmdm;
                paras[3].Value = rz.p_gwdm;
                paras[4].Value = rz.p_czfs;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_RZGL.Select_RZ_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
    
    }
}
