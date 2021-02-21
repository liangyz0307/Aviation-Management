using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_BCGL
    {
        public int p_id;//id 
        public DateTime p_kssj;
        public DateTime p_jssj;
        public DateTime p_rq;
        public string p_zbld;
        public string p_ttzb;
        public string p_tdzb;

        public string p_ffzb;
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;

        public string p_gczb;
        public string p_ybzb;
        public string p_tdzbdh;
        public string p_bmdm;// 
        public string p_ldzbdh;
        public string p_ttzbdh;
        public string p_zsr;//终 
        public string p_bhyy;// 

        public string p_ffzbdh;//终 
        public string p_ybzbdh;// 
        public string p_gczbdh;//终  

        public int p_userid;
        public string p_dqdm;

    }
    public class OBCGL
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;

        public OBCGL(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region  ===============值班表信息查询================
        public DataTable Select_BCGL_Pro(Struct_BCGL struct_bcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_kssj",OracleType.DateTime),
                    new OracleParameter("p_jssj",OracleType.DateTime),
                    new OracleParameter("p_zbld",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_bcgl.p_kssj;
                parament[1].Value = struct_bcgl.p_jssj;
                parament[2].Value = struct_bcgl.p_zbld;
                parament[3].Value = struct_bcgl.p_userid;
                parament[4].Value = struct_bcgl.p_pagesize;
                parament[5].Value = struct_bcgl.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_BS_BCGL.Select_BCGL_Pro", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============值班表信息数量查询================
        public int Select_BCGL_Count(Struct_BCGL struct_bcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_kssj",OracleType.DateTime),
                    new OracleParameter("p_jssj",OracleType.DateTime),
                    new OracleParameter("p_zbld",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),

                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_bcgl.p_kssj;
                parament[1].Value = struct_bcgl.p_jssj;
                parament[2].Value = struct_bcgl.p_zbld;
                parament[3].Value = struct_bcgl.p_userid;

                parament[4].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_BS_BCGL.Select_BCGL_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表添加================
        protected void Insert_BCGL(Struct_BCGL struct_bcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                               //  new OracleParameter("p_id",OracleType.Number), 
                                                 new OracleParameter("p_rq",OracleType.DateTime),
                                                 new OracleParameter("p_zbld",OracleType.VarChar),
                                                 new OracleParameter("p_ttzb",OracleType.VarChar),
                                                 new OracleParameter("p_tdzb",OracleType.VarChar),
                                                 new OracleParameter("p_ffzb",OracleType.VarChar),
                                                 new OracleParameter("p_gczb",OracleType.VarChar),
                                                 new OracleParameter("p_ybzb",OracleType.VarChar),
                                                 new OracleParameter("p_tdzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ldzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ttzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ffzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ybzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_gczbdh",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter  ("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_bcgl.p_rq;
                parament[1].Value = struct_bcgl.p_zbld;
                parament[2].Value = struct_bcgl.p_ttzb;
                parament[3].Value = struct_bcgl.p_tdzb;

                parament[4].Value = struct_bcgl.p_ffzb;
                parament[5].Value = struct_bcgl.p_gczb;
                parament[6].Value = struct_bcgl.p_ybzb;
                parament[7].Value = struct_bcgl.p_tdzbdh;
                parament[8].Value = struct_bcgl.p_ldzbdh;
                parament[9].Value = struct_bcgl.p_ttzbdh;
                parament[10].Value = struct_bcgl.p_ffzbdh;
                parament[11].Value = struct_bcgl.p_ybzbdh;
                parament[12].Value = struct_bcgl.p_gczbdh;
                parament[13].Value = struct_bcgl.p_bmdm;
                parament[14].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_BCGL.Insert_BCGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[14].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bcgl.p_czfs;
                struct_rz.czxx = struct_bcgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表修改================
        public void Update_BCGL(Struct_BCGL struct_bcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_rq",OracleType.DateTime),
                                                 new OracleParameter("p_zbld",OracleType.VarChar),
                                                 new OracleParameter("p_ttzb",OracleType.VarChar),
                                                 new OracleParameter("p_tdzb",OracleType.VarChar),
                                                 new OracleParameter("p_ffzb",OracleType.VarChar),
                                                 new OracleParameter("p_gczb",OracleType.VarChar),
                                                 new OracleParameter("p_ybzb",OracleType.VarChar),
                                                 new OracleParameter("p_tdzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ldzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ttzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ffzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ybzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_gczbdh",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_bcgl.p_id;
                parament[1].Value = struct_bcgl.p_rq;
                parament[2].Value = struct_bcgl.p_zbld;
                parament[3].Value = struct_bcgl.p_ttzb;
                parament[4].Value = struct_bcgl.p_tdzb;
                parament[5].Value = struct_bcgl.p_ffzb;
                parament[6].Value = struct_bcgl.p_gczb;
                parament[7].Value = struct_bcgl.p_ybzb;
                parament[8].Value = struct_bcgl.p_tdzbdh;
                parament[9].Value = struct_bcgl.p_ldzbdh;
                parament[10].Value = struct_bcgl.p_ttzbdh;
                parament[11].Value = struct_bcgl.p_ffzbdh;
                parament[12].Value = struct_bcgl.p_ybzbdh;
                parament[13].Value = struct_bcgl.p_gczbdh;
                parament[14].Value = struct_bcgl.p_bmdm;
                parament[15].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_BCGL  .Update_BCGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[15].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bcgl.p_czfs;
                struct_rz.czxx = struct_bcgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=============删除值班表信息=================
        protected void Delete_BCGL(int id, string p_czfs, string p_czxx)
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
                dbclass.RunProcedure("PACK_BS_BCGL  .Delete_BCGL", parament, out result);

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
        #region===============通过ID查询值班表信息详情================
        public DataTable Select_BCGL_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_BS_BCGL  .Select_BCGL_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region ============子表=====查询员工============
        protected DataTable Select_YGXMbyBH(string bh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bh",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_BS_BCGL  .Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region =============根据地区代码查询部门=======
        protected DataTable Select_YGByBMDQ(string dqdm, string bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_dqdm",OracleType.VarChar),
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = dqdm;
                paras[1].Value = bmdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_BS_BCGL .Select_YGByBMDQ", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
    }
}
