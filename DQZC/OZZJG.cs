using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_ZZJG_CX
    {
        public int p_id;
        public string p_dzzmc;//党组织名称
        public string p_jcdzbmc;//基层党支部名称
        public string p_dxzmc;//党小组名称
        public string p_xm;//姓名
        public string p_dnzw;//党内职务
        public string p_dyrs;//党员人数
        public string p_dzb_bs;//党支部标识
        public string p_bhyy;//驳回原因
        public string p_zt;//状态
        public string lx;//类型
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
    }
    public struct Struct_ZZJG
    {
        public int p_id;
        public string p_dzzmc;//党组织名称
        public string p_jcdzbmc;//基层党支部名称
        public string p_dxzmc;//党小组名称
        public string p_xm;//姓名
        public string p_dnzw;//党内职务
        public string p_dyrs;//党员人数
        public string p_dzb_bs;//党支部标识
        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public string p_ip;//IP
        public string lx;//类型
        public DateTime p_czsj;//操作时间
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
    }
    public class OZZJG
    {
        private UserState _us = null;
        private RZ rz = null;
        public OZZJG(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        //组织结构信息查询
        protected DataSet Select_ZZJG_All(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_dzzmc",OracleType.VarChar),
                                                  new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                  new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };

                parament[0].Value = strcut_zzjg.p_dzzmc;
                parament[1].Value = strcut_zzjg.p_jcdzbmc;
                parament[2].Value = strcut_zzjg.p_dxzmc;
                parament[3].Value = strcut_zzjg.p_zt;
                parament[4].Value = strcut_zzjg.p_pagesize;
                parament[5].Value = strcut_zzjg.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_ZZJG.Select_DQZC_ZZJG", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询基层党支部人员
        protected DataSet Select_ZZJG_JCDZB(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {   
                                                  new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };  
                parament[0].Value = strcut_zzjg.p_jcdzbmc;
                parament[1].Value = strcut_zzjg.p_pagesize;
                parament[2].Value = strcut_zzjg.p_currentpage;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_JCDZB", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询党小组人员
        protected DataSet Select_ZZJG_DXZ(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = strcut_zzjg.p_dxzmc;
                parament[1].Value = strcut_zzjg.p_pagesize;
                parament[2].Value = strcut_zzjg.p_currentpage;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_DXZ", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        //组织结构信息数量查询
        protected int Select_ZZJG_Count(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={


                                                new OracleParameter("p_dzzmc",OracleType.VarChar),
                                                  new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                  new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = strcut_zzjg.p_dzzmc;
                parament[1].Value = strcut_zzjg.p_jcdzbmc;
                parament[2].Value = strcut_zzjg.p_dxzmc;
                parament[3].Value = strcut_zzjg.p_zt;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_ZZJG.Select_DQZC_ZZJG_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //基层党支部人员数量
        protected int Select_ZZJG_JCDZB_Count(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = strcut_zzjg.p_jcdzbmc;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_JCDZB_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //基层党支部人员数量
        protected int Select_ZZJG_DXZ_Count(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = strcut_zzjg.p_dxzmc;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_DXZ_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //组织结构信息添加
        protected void ZZJG_Add(Struct_ZZJG strcut_zzjgxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={


                                                 new OracleParameter("p_dzzmc",OracleType.VarChar),
                                                 new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                 new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_ip",OracleType.VarChar),
                                                 new OracleParameter("p_czsj",OracleType.DateTime),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = strcut_zzjgxx.p_dzzmc;
                parament[1].Value = strcut_zzjgxx.p_jcdzbmc;
                parament[2].Value = strcut_zzjgxx.p_dxzmc;
                parament[3].Value = strcut_zzjgxx.p_id;
                parament[4].Value = strcut_zzjgxx.p_ip;
                parament[5].Value = strcut_zzjgxx.p_czsj;
                parament[6].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_ZZJG.ZZJG_Add", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[6].Value);
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
        //组织结构信息更新
        protected void ZZJG_Edit(Struct_ZZJG strcut_zzjgxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                                 new OracleParameter("p_dzzmc",OracleType.VarChar),
                                                 new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                 new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                 new OracleParameter("p_id",OracleType.Number),
                                                
                                                 new OracleParameter("p_ip",OracleType.VarChar),
                                                 new OracleParameter("p_czsj",OracleType.DateTime),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = strcut_zzjgxx.p_dzzmc;
                parament[1].Value = strcut_zzjgxx.p_jcdzbmc;
                parament[2].Value = strcut_zzjgxx.p_dxzmc;
                parament[3].Value = strcut_zzjgxx.p_id;
                parament[4].Value = strcut_zzjgxx.p_ip;
                parament[5].Value = strcut_zzjgxx.p_czsj;
                parament[6].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_ZZJG.ZZJG_Edit", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[6].Value);
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
       

        //状态更新
        protected void ZZJGZT_Edit(int id, string zt, string bhyy)
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
                paras[0].Value = id;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_DQZC_ZZJG.ZZJGZT_Edit", paras, out rowsAffected);
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
        //删除
        protected void ZZJG_Del(int id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_DQZC_ZZJG.ZZJG_Del", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
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
        protected DataTable Select_ZZJG_Detail(int id)
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
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_Detail ", parament, "table").Tables[0];
                
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
       
        //图片详情
        protected DataSet Select_ZZJG_TP(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_tzcz",OracleType.VarChar),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };

                parament[0].Value = strcut_zzjg.lx;
                parament[1].Value = strcut_zzjg.p_pagesize;
                parament[2].Value = strcut_zzjg.p_currentpage;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_TP", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_ZZJG_TPRS(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={


                                               
                                                  new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                 
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                
                parament[0].Value = strcut_zzjg.p_jcdzbmc;
              
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_TPRS", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        protected int Select_ZZJG_TPCount(Struct_ZZJG_CX strcut_zzjg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_tzcz",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = strcut_zzjg.lx;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_DQZC_ZZJG.Select_ZZJG_TPCount", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
    }
}
