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
    public struct Struct_BM
    {
        public string  p_bmdm;   
        public string p_bmmc;    
        public string p_sjbmdm ; 
        public string p_bmlb ;   
        public string p_fzr ;    
        public string p_lxdh;
        public string p_zt;    
        public string p_czfs;
        public string p_czxx;
        public int p_pagesize;
        public int p_currentpage;
    }
    public struct Struct_GW
    {
        public string p_bmdm;
        public string p_gwdm;
        public string p_gwmc;
        public string p_lb; 
        public string p_czfs;
        public string p_czxx;
        public int p_pagesize;
        public int p_currentpage;
        public string p_zt;
    }
    public class OBMGW
    {
        private Struct_RZ_YH struct_RZ_YH=new Struct_RZ_YH ();
        private UserState _usState;
        private RZ rz;
        public OBMGW(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region  ===============部门的增删改查================
        protected DataSet Select_BM_Pro(Struct_BM struct_BM)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),   
                                                  new OracleParameter("p_bmmc",OracleType.VarChar),   
                                                  new OracleParameter("p_bmlb",OracleType.VarChar),   
                                                  new OracleParameter("p_zt",OracleType.VarChar),     
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BM.p_bmdm;
                parament[1].Value = struct_BM.p_bmmc;
                parament[2].Value = struct_BM.p_bmlb;
                parament[3].Value = struct_BM.p_zt;
                parament[4].Value = struct_BM.p_pagesize;
                parament[5].Value = struct_BM.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HTGL_BMGW.Select_BM_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BMbyBMDM(string p_bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_bmdm;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HTGL_BMGW.Select_BMbyBMDM", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BM_Count(Struct_BM struct_BM)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),   
                                                  new OracleParameter("p_bmmc",OracleType.VarChar),   
                                                  new OracleParameter("p_bmlb",OracleType.VarChar),   
                                                  new OracleParameter("p_zt",OracleType.VarChar),     
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BM.p_bmdm;
                parament[1].Value = struct_BM.p_bmmc;
                parament[2].Value = struct_BM.p_bmlb;
                parament[3].Value = struct_BM.p_zt;
                parament[4].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_HTGL_BMGW.Select_BM_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_BM(Struct_BM struct_BM)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),  
                                                   new OracleParameter("p_bmmc",OracleType.VarChar),   
                                                   new OracleParameter("p_sjbmdm",OracleType.VarChar), 
                                                   new OracleParameter("p_bmlb",OracleType.VarChar),   
                                                   new OracleParameter("p_fzr",OracleType.VarChar),    
                                                   new OracleParameter("p_lxdh",OracleType.VarChar),   
                                                   new OracleParameter("p_zt",OracleType.VarChar),     
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BM.p_bmdm;
                parament[1].Value = struct_BM.p_bmmc;
                parament[2].Value = struct_BM.p_sjbmdm;
                parament[3].Value = struct_BM.p_bmlb;
                parament[4].Value = struct_BM.p_fzr;
                parament[5].Value = struct_BM.p_lxdh;
                parament[6].Value = struct_BM.p_zt;
                parament[7].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_BMGW.Insert_BM", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[7].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_BM.p_czfs;
                struct_RZ_YH.czxx = struct_BM.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
                SysData.ReSetBM();
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_BM(Struct_BM struct_BM)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_bmdm",OracleType.VarChar),  
                                                   new OracleParameter("p_bmmc",OracleType.VarChar),   
                                                   new OracleParameter("p_sjbmdm",OracleType.VarChar), 
                                                   new OracleParameter("p_bmlb",OracleType.VarChar),   
                                                   new OracleParameter("p_fzr",OracleType.VarChar),    
                                                   new OracleParameter("p_lxdh",OracleType.VarChar),   
                                                   new OracleParameter("p_zt",OracleType.VarChar),     
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BM.p_bmdm;
                parament[1].Value = struct_BM.p_bmmc;
                parament[2].Value = struct_BM.p_sjbmdm;
                parament[3].Value = struct_BM.p_bmlb;
                parament[4].Value = struct_BM.p_fzr;
                parament[5].Value = struct_BM.p_lxdh;
                parament[6].Value = struct_BM.p_zt;
                parament[7].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_BMGW.Update_BM", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[7].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_BM.p_czfs;
                struct_RZ_YH.czxx = struct_BM.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
                SysData.ReSetBM();
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_BM(string p_bmdm, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_bmdm; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_BMGW.Delete_BM", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
                SysData.ReSetBM();
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============岗位的增删改查================
        protected DataSet Select_GW_Pro(Struct_GW struct_GW)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),   
                                                  new OracleParameter("p_gwdm",OracleType.VarChar),
                                                  new OracleParameter("p_gwmc",OracleType.VarChar),   
                                                  new OracleParameter("p_lb",OracleType.VarChar), 
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_GW.p_bmdm;
                parament[1].Value = struct_GW.p_gwdm;
                parament[2].Value = struct_GW.p_gwmc;
                parament[3].Value = struct_GW.p_zt;
                parament[4].Value = struct_GW.p_lb;
                parament[5].Value = struct_GW.p_pagesize;
                parament[6].Value = struct_GW.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HTGL_BMGW.Select_GW_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_GWbyGWDM(string p_gwdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_gwdm;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HTGL_BMGW.Select_GWbyGWDM", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_GW_Count(Struct_GW struct_GW)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),   
                                                  new OracleParameter("p_gwdm",OracleType.VarChar),
                                                  new OracleParameter("p_gwmc",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),   
                                                  new OracleParameter("p_lb",OracleType.VarChar),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_GW.p_bmdm;
                parament[1].Value = struct_GW.p_gwdm;
                parament[2].Value = struct_GW.p_gwmc;
                parament[3].Value = struct_GW.p_zt;
                parament[4].Value = struct_GW.p_lb;
                parament[5].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_HTGL_BMGW.Select_GW_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_GW(Struct_GW struct_GW)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),  
                                                   new OracleParameter("p_gwdm",OracleType.VarChar),  
                                                   new OracleParameter("p_gwmc",OracleType.VarChar),  
                                                   new OracleParameter("p_lb",OracleType.VarChar),

                                                   new OracleParameter("p_zt",OracleType.VarChar),

                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_GW.p_bmdm;
                parament[1].Value = struct_GW.p_gwdm;
                parament[2].Value = struct_GW.p_gwmc;
                parament[3].Value = struct_GW.p_lb;

                parament[4].Value = struct_GW.p_zt;

                parament[5].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_BMGW.Insert_GW", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[5].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_GW.p_czfs;
                struct_rz.czxx = struct_GW.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
                SysData.ReSetGW();
                
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_GW(Struct_GW struct_GW)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),  
                                                 new OracleParameter("p_gwdm",OracleType.VarChar),  
                                                 new OracleParameter("p_gwmc",OracleType.VarChar),  
                                                 new OracleParameter("p_lb",OracleType.VarChar),

                                                 new OracleParameter("p_zt",OracleType.VarChar),

                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_GW.p_bmdm;
                parament[1].Value = struct_GW.p_gwdm;
                parament[2].Value = struct_GW.p_gwmc;
                parament[3].Value = struct_GW.p_lb;

                parament[4].Value = struct_GW.p_zt;

                parament[5].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_BMGW.Update_GW", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[5].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_GW.p_czfs;
                struct_rz.czxx = struct_GW.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
                SysData.ReSetGW();
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_GW(string p_gwdm, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_gwdm; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_BMGW.Delete_GW", parament, out reslut);

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
                SysData.ReSetGW();
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        protected DataSet Select_YGALL(string p_gwdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_gwdm;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HTGL_BMGW.Select_YGALL", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

    }
}
