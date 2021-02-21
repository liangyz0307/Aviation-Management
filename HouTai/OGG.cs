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
   public class OGG
    {
        public struct Struct_GG_Pro
        {
            public int p_id;
            public string p_lx;
            public string p_bt;
            public DateTime p_fbsj;
            public string p_jsbm;
            public string p_lr;
            public string p_fbr;
            public int p_pagesize;
            public int p_currentpage;
            public DateTime p_fbrqks; //开始时间
            public DateTime p_fbrqjs;//结束时间
            public string p_czxx;//操作信息
            public string p_czfs;//操作
            public DateTime p_xgsj;//修改时间
            public string p_xgr;//修改人
            public string p_sfdb;
            public DateTime p_blsx;
        }
        private UserState _usState;
        private RZ rz;
        private Struct_RZ_YH struct_RZ_YH;
        public OGG(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region 添加
        protected void GG_insert(Struct_GG_Pro _struct)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_lx",OracleType.VarChar),
                                               new OracleParameter("p_bt",OracleType.VarChar),
                                               new OracleParameter("p_fbsj",OracleType.DateTime),
                                               new OracleParameter("p_lr",OracleType.VarChar),
                                               new OracleParameter("p_jsbm",OracleType.VarChar),
                                               new OracleParameter("p_fbr",OracleType.VarChar),
                                                new OracleParameter("p_sfdb",OracleType.VarChar),
                                               new OracleParameter("p_blsx",OracleType.DateTime),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = _struct.p_lx;
                parament[1].Value = _struct.p_bt;
                parament[2].Value = _struct.p_fbsj;
                parament[3].Value = _struct.p_lr.Trim();
                parament[4].Value = _struct.p_jsbm;
                parament[5].Value = _struct.p_fbr;
                parament[6].Value = _struct.p_sfdb;
                parament[7].Value = _struct.p_blsx;
                parament[8].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_GG.GG_insert", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[8].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                struct_RZ_YH.czfs = _struct.p_czfs;
                struct_RZ_YH.czxx = _struct.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 查询
        
      
        protected int Select_GG_count(Struct_GG_Pro _struct)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_lx",OracleType.VarChar),
                                               new OracleParameter("p_bt",OracleType.VarChar),
                                               new OracleParameter("p_fbrqks",OracleType.DateTime),
                                               new OracleParameter("p_fbrqjs",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = _struct.p_lx;
                parament[1].Value = _struct.p_bt;
                parament[2].Value = _struct.p_fbrqks;
                parament[3].Value = _struct.p_fbrqjs;
                parament[4].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_HTGL_GG.Select_GG_count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataTable Select_GG_Pro(Struct_GG_Pro _struct)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                             new OracleParameter("p_lx",OracleType.VarChar),
                                               new OracleParameter("p_bt",OracleType.VarChar),
                                               new OracleParameter("p_fbrqks",OracleType.DateTime),
                                               new OracleParameter("p_fbrqjs",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = _struct.p_lx;
                parament[1].Value = _struct.p_bt;
                parament[2].Value = _struct.p_fbrqks;
                parament[3].Value = _struct.p_fbrqjs;
                parament[4].Value = _struct.p_pagesize;
                parament[5].Value = _struct.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_HTGL_GG.Select_GG_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataTable Select_GG(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_HTGL_GG.Select_GG", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 更新
        protected void GG_update(Struct_GG_Pro _struct)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_lx",OracleType.VarChar),
                                               new OracleParameter("p_bt",OracleType.VarChar),
                                               new OracleParameter("p_lr",OracleType.VarChar),
                                               new OracleParameter("p_jsbm",OracleType.VarChar),
                                               new OracleParameter("p_xgsj",OracleType.DateTime),
                                               new OracleParameter("p_xgr",OracleType.VarChar),
                                                   new OracleParameter("p_sfdb",OracleType.VarChar),
                                               new OracleParameter("p_blsx",OracleType.DateTime),
                                                new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = _struct.p_id;
                parament[1].Value = _struct.p_lx;
                parament[2].Value = _struct.p_bt;
                parament[3].Value = _struct.p_lr;
                parament[4].Value = _struct.p_jsbm;
                parament[5].Value = _struct.p_xgsj;
                parament[6].Value = _struct.p_xgr;
                parament[7].Value = _struct.p_sfdb;
                parament[8].Value = _struct.p_blsx;
                parament[9].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_GG.GG_update", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[9].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                struct_RZ_YH.czfs = _struct.p_czfs;
                struct_RZ_YH.czxx = _struct.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 删除
 protected void delete_GG(int id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value =id;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HTGL_GG.delete_GG", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
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
