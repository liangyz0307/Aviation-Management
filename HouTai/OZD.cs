using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace CUST.MKG
{
    public class OZD
    {
        public struct Struct_ZD_Pro
        {
            public String p_zdm;
            public String p_bm;
            public String p_mc;
            public int p_pagesize;
            public int p_currentpage;
            public string p_czxx;//操作信息
            public string p_czfs;//操作信息
        }
        private UserState userstate;
        private RZ rz;
        private Struct_RZ_YH struct_RZ_YH;
        public OZD(UserState userstate)
        {
            userstate = userstate;
            rz = new RZ(userstate);
        }
        protected DataSet Select_ZD_Pro(Struct_ZD_Pro struct_ZD_Pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zdm",OracleType.VarChar),
                                               new OracleParameter("p_bm",OracleType.VarChar),
                                               new OracleParameter("p_mc",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_ZD_Pro.p_zdm;
                parament[1].Value = struct_ZD_Pro.p_bm;
                parament[2].Value = struct_ZD_Pro.p_mc;
                parament[3].Value = struct_ZD_Pro.p_pagesize;
                parament[4].Value = struct_ZD_Pro.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_WEB_SYS.Select_ZD_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_ZD_Count(Struct_ZD_Pro struct_ZD_Pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zdm",OracleType.VarChar),
                                               new OracleParameter("p_bm",OracleType.VarChar),
                                               new OracleParameter("p_mc",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_ZD_Pro.p_zdm;
                parament[1].Value = struct_ZD_Pro.p_bm;
                parament[2].Value = struct_ZD_Pro.p_mc;
                parament[3].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_WEB_SYS.Select_ZD_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_ZD(Struct_ZD_Pro struct_ZD_Pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zdm",OracleType.VarChar),
                                               new OracleParameter("p_bm",OracleType.VarChar),
                                               new OracleParameter("p_mc",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_ZD_Pro.p_zdm;
                parament[1].Value = struct_ZD_Pro.p_bm;
                parament[2].Value = struct_ZD_Pro.p_mc;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_WEB_SYS.Insert_ZD", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[3].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                struct_RZ_YH.czfs = struct_ZD_Pro.p_czfs;
                struct_RZ_YH.czxx = struct_ZD_Pro.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }

            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_ZD(Struct_ZD_Pro struct_ZD_Pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zdm",OracleType.VarChar),
                                               new OracleParameter("p_bm",OracleType.VarChar),
                                               new OracleParameter("p_mc",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_ZD_Pro.p_zdm;
                parament[1].Value = struct_ZD_Pro.p_bm;
                parament[2].Value = struct_ZD_Pro.p_mc;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_WEB_SYS.Update_ZD", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[3].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                struct_RZ_YH.czfs = struct_ZD_Pro.p_czfs;
                struct_RZ_YH.czxx = struct_ZD_Pro.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_ZD(Struct_ZD_Pro struct_ZD_Pro)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zdm",OracleType.VarChar),
                                               new OracleParameter("p_bm",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_ZD_Pro.p_zdm;
                parament[1].Value = struct_ZD_Pro.p_bm;
                parament[2].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_WEB_SYS.Delete_ZD", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[2].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                struct_RZ_YH.czfs = struct_ZD_Pro.p_czfs;
                struct_RZ_YH.czxx = struct_ZD_Pro.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
    }
}
