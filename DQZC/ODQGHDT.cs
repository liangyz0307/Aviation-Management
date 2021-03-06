﻿using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_DQGHDT //党群工会动态
    {
        public int p_id;//id
        public string p_bt;//标题
        public string p_nr;//内容
        public string p_fbr;//发布人
        public DateTime p_fbsjks;//发布时间开始
        public DateTime p_fbsjjs;//发布时间结束
        public DateTime p_czsj;//操作时间
        public string p_fbip;//发布IP
        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;//操作方式
        public string p_czxx;//操作类型

    }
    public class ODQGHDT
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;

        public ODQGHDT(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region 党群工会动态查询
        protected DataTable Select_DQGHDT_Pro(Struct_DQGHDT struct_DQGHDT)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_fbsjks",OracleType.DateTime),
                                                 new OracleParameter("p_fbsjjs",OracleType.DateTime),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)    
                                             };
                parament[0].Value = struct_DQGHDT.p_bt;
                parament[1].Value = struct_DQGHDT.p_fbsjks;
                parament[2].Value = struct_DQGHDT.p_fbsjjs;
                parament[3].Value = struct_DQGHDT.p_zt;
                parament[4].Value = struct_DQGHDT.p_pagesize;
                parament[5].Value = struct_DQGHDT.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;

                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_DQGHDT.Select_DQGHDT_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataTable Select_DQGHDTShow_Pro(Struct_DQGHDT struct_DQGHDT)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_fbsjks",OracleType.DateTime),
                                                 new OracleParameter("p_fbsjjs",OracleType.DateTime),
                                                
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)    
                                             };
                parament[0].Value = struct_DQGHDT.p_bt;
                parament[1].Value = struct_DQGHDT.p_fbsjks;
                parament[2].Value = struct_DQGHDT.p_fbsjjs;
               
                parament[3].Value = struct_DQGHDT.p_pagesize;
                parament[4].Value = struct_DQGHDT.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;

                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_DQGHDT.Select_DQGHDTShow_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 党群工会动态数量
        protected int Select_DQGHDT_Count(Struct_DQGHDT struct_DQGHDT)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_fbsjks",OracleType.DateTime),
                                                 new OracleParameter("p_fbsjjs",OracleType.DateTime),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                               
                                             };
                parament[0].Value = struct_DQGHDT.p_bt;
                parament[1].Value = struct_DQGHDT.p_fbsjks;
                parament[2].Value = struct_DQGHDT.p_fbsjjs;
                parament[3].Value = struct_DQGHDT.p_zt;
                parament[4].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_DQGHDT.Select_DQGHDT_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_DQGHDTShow_Count(Struct_DQGHDT struct_DQGHDT)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_fbsjks",OracleType.DateTime),
                                                 new OracleParameter("p_fbsjjs",OracleType.DateTime),
                                                
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                               
                                             };
                parament[0].Value = struct_DQGHDT.p_bt;
                parament[1].Value = struct_DQGHDT.p_fbsjks;
                parament[2].Value = struct_DQGHDT.p_fbsjjs;
               
                parament[3].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_DQGHDT.Select_DQGHDTShow_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  党群工会动态详情
        protected DataTable Select_DQGHDT_Detail(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_id",OracleType.Number),
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                          };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_DQGHDT.Select_DQGHDT_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }

        }
        #endregion
        #region 按id查询党群工会动态
        protected DataTable Find_DQGHDT_ById()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={   
                                            new OracleParameter("p_cur",OracleType.Cursor)
                                          };
                paras[0].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_DQGHDT.Find_DQGHDT_ById", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 添加党群工会动态
        protected void Insert_DQGHDT(Struct_DQGHDT struct_DQGHDT)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_nr",OracleType.VarChar),
                                                 new OracleParameter("p_fbsjks",OracleType.DateTime),
                                                 new OracleParameter("p_fbr",OracleType.VarChar),
                                                 new OracleParameter("p_fbip",OracleType.VarChar),
                                                 new OracleParameter("p_czsj",OracleType.DateTime),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_DQGHDT.p_id;
                parament[1].Value = struct_DQGHDT.p_bt;
                parament[2].Value = struct_DQGHDT.p_nr;
                parament[3].Value = struct_DQGHDT.p_fbsjks;
                parament[4].Value = struct_DQGHDT.p_fbr;
                parament[5].Value = struct_DQGHDT.p_fbip;
                parament[6].Value = struct_DQGHDT.p_czsj;
                parament[7].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DQGHDT.Insert_DQGHDT", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[7].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_DQGHDT.p_czfs;
                struct_RZ_YH.czxx = struct_DQGHDT.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);

            }
            finally
            {
                dbclass.Close();
            }

        }
        #endregion

        #region 更改党群工会动态
        protected void Update_DQGHDT(Struct_DQGHDT struct_DQGHDT)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_nr",OracleType.VarChar),
                                                 new OracleParameter("p_fbsjks",OracleType.DateTime),
                                                 new OracleParameter("p_fbr",OracleType.VarChar),
                                                 new OracleParameter("p_fbip",OracleType.VarChar),
                                                 new OracleParameter("p_czsj",OracleType.DateTime),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_DQGHDT.p_id;
                parament[1].Value = struct_DQGHDT.p_bt;
                parament[2].Value = struct_DQGHDT.p_nr;
                parament[3].Value = struct_DQGHDT.p_fbsjks;
                parament[4].Value = struct_DQGHDT.p_fbr;
                parament[5].Value = struct_DQGHDT.p_fbip;
                parament[6].Value = struct_DQGHDT.p_czsj;
                parament[7].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DQGHDT.Update_DQGHDT", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[7].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_DQGHDT.p_czfs;
                struct_RZ_YH.czxx = struct_DQGHDT.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);

            }
            finally
            {
                dbclass.Close();
            }

        }
        #endregion

        #region 更改党群工会动态状态
        protected void Update_DQGHDTZT(Struct_DQGHDT struct_DQGGHDT)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
              };

                parament[0].Value = struct_DQGGHDT.p_id;
                parament[1].Value = struct_DQGGHDT.p_zt;
                parament[2].Value = struct_DQGGHDT.p_bhyy;
                parament[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_DQGHDT.Update_DQGHDTZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_DQGGHDT.p_czfs;
                struct_rz.czxx = struct_DQGGHDT.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 删除党群工会动态
        protected void Delete_DQGHDT(int id, string p_czfs, string p_czxx)
        {

            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_id",OracleType.Number),
                                                  new OracleParameter("p_errorCode",OracleType.Int32)
                                              };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_KG_DQGHDT.Delete_DQGHDT", parament, out result);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
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
        #endregion
    }
}
