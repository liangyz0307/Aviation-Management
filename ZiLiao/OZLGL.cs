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


namespace CUST.MKG
{
    public struct Struct_ZL
    {
        public int p_id;
        public string p_zlbh;
        public string p_zllx1;
        public string p_zllx2;
        public DateTime p_sj;
        public string p_lj;
        public string p_zlm;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public string p_yh;
        public string p_bm;
        public string p_gw;
        public string p_zt;
        public string p_wjlj;
        public string p_bhyy;
        public string p_czfs;
        public string p_czxx;
        public int p_pagesize;
        public int p_currentpage;
        public int p_userid;
        public string p_bmdm;//数据所属部门
        
       
    }
    public class OZLGL
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        
        private UserState _usState;
        private RZ rz;
        public OZLGL(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region  ===============资料的增删改查================
        protected DataSet Select_ZL_Pro(Struct_ZL struct_zl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  
                                                  new OracleParameter("p_zllx1",OracleType.VarChar),
                                                  new OracleParameter("p_zllx2",OracleType.VarChar),
                                                  new OracleParameter("p_kssj",OracleType.DateTime),
                                                  new OracleParameter("p_jssj",OracleType.DateTime),
                                                  
                                                 // new OracleParameter("p_wjlj",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                
                parament[0].Value = struct_zl.p_zllx1;
                parament[1].Value = struct_zl.p_zllx2;
                parament[2].Value = struct_zl.p_kssj;
                parament[3].Value = struct_zl.p_jssj;
               
              //  parament[4].Value = struct_zl.p_wjlj;
                parament[4].Value = struct_zl.p_userid;
                parament[5].Value = struct_zl.p_pagesize;
                parament[6].Value = struct_zl.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_ZL.Select_ZL_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_byZLBH(string p_zlbh)
        {
            DataSet ds = new DataSet();
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zlbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_zlbh;
                parament[1].Direction = ParameterDirection.Output;
                
                ds = dbclass.RunProcedure("PACK_KG_ZL.Select_byZLBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_ZL_Count(Struct_ZL struct_zl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 
                                                  new OracleParameter("p_zllx1",OracleType.VarChar),
                                                  new OracleParameter("p_zllx2",OracleType.VarChar),
                                                  new OracleParameter("p_kssj",OracleType.DateTime),
                                                  new OracleParameter("p_jssj",OracleType.DateTime),
                                                  
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                
                parament[0].Value = struct_zl.p_zllx1;
                parament[1].Value = struct_zl.p_zllx2;
                parament[2].Value = struct_zl.p_kssj;
                parament[3].Value = struct_zl.p_jssj;
                
                parament[4].Value = struct_zl.p_userid;
                parament[5].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_ZL.Select_ZL_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
       
        protected DataSet Select_ZLbyZLBH(string p_zlbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zlbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_zlbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_ZL.Select_ZLbyZLBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected string SelectZLBH(string gwdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_ZL.SelectZLMaxBH", paras, "dt");
                string maxbh = paras[0].Value.ToString();

                return gwdm + maxbh;
            }
            finally
            {
                db.Close();
            }
        }
        protected void Insert_ZL(Struct_ZL struct_zl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_zlbh",OracleType.VarChar),
                                                   new OracleParameter("p_zlm",OracleType.VarChar),
                                                   new OracleParameter("p_zllx1",OracleType.VarChar),
                                                   new OracleParameter("p_zllx2",OracleType.VarChar),
                                                   new OracleParameter("p_yh",OracleType.VarChar),
                                                   new OracleParameter("p_bm",OracleType.VarChar),
                                                   new OracleParameter("p_gw",OracleType.VarChar),
                                                   new OracleParameter("p_ip",OracleType.VarChar),
                                                   new OracleParameter("p_sj",OracleType.DateTime),
                                                   new OracleParameter("p_wjlj",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = SelectZLBH(struct_zl.p_gw);
                parament[1].Value = struct_zl.p_zlm;
                parament[2].Value = struct_zl.p_zllx1;
                parament[3].Value = struct_zl.p_zllx2;
                parament[4].Value = struct_zl.p_yh;
                parament[5].Value = struct_zl.p_bm;
                parament[6].Value = struct_zl.p_gw;
                parament[7].Value = _usState.context.IP;
                parament[8].Value = struct_zl.p_sj;
                parament[9].Value = struct_zl.p_wjlj;
                parament[10].Value = struct_zl.p_bmdm;
                parament[11].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZL.Insert_ZL_Pro", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[11].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_zl.p_czfs;
                struct_RZ_YH.czxx = struct_zl.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_ZLGLZT(int id, string zt, string bhyy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Int32),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = id;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ZL.Update_ZLGLZT", paras, out rowsAffected);
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
        protected void Struct_Delete_Pro(int id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZL.Delete_ZL_Pro", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
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
                dt = db.RunProcedure("PACK_KG_ZL.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
    }
}