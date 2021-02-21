using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_YJGL
    {
        public int p_id;//id 
        public DateTime p_kssj;
        public DateTime p_jssj;
        public DateTime p_rq;
        public string p_zbld;
        public string p_ttzb;
        public string p_zdzb;

        public string p_xzb;
        public string p_gzdbzr;
        public string p_qb;
        public string p_tddb;
        public string p_tx;
        public string p_dh;
        public string p_bt;
        public string p_qxjw;
        public string p_qxgc;
        public string p_qxyb;
        public string p_qxgczbdh;
        public string p_qxybzbdh;
        public string p_tdzbdh;
        public string p_dhddh;
        public string p_xlsdh;
        public string p_btdh;

        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx; 
        public string p_bmdm;// 
        public string p_zdzbdh;
        public string p_ttzbdh;
        public string p_zsr;//终 
        public string p_bhyy;// 
        public int p_userid;
        public string p_dqdm;

    }
    public  class OYJGL
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;

        public OYJGL(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region  ===============值班表信息查询================
        public DataTable Select_YJGL_Pro(Struct_YJGL struct_yjgl)
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
                parament[0].Value = struct_yjgl.p_kssj;
                parament[1].Value = struct_yjgl.p_jssj;
                parament[2].Value = struct_yjgl.p_zbld;
                parament[3].Value = struct_yjgl.p_userid;
                parament[4].Value = struct_yjgl.p_pagesize;
                parament[5].Value = struct_yjgl.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_BS_YJGL.Select_YJGL_Pro", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============值班表信息数量查询================
        public int Select_YJGL_Count(Struct_YJGL struct_yjgl)
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
                parament[0].Value = struct_yjgl.p_kssj;
                parament[1].Value = struct_yjgl.p_jssj;
                parament[2].Value = struct_yjgl.p_zbld;
                parament[3].Value = struct_yjgl.p_userid;

                parament[4].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_BS_YJGL.Select_YJGL_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表添加================
        protected void Insert_YJGL(Struct_YJGL struct_yjgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                               //  new OracleParameter("p_id",OracleType.Number), 
                                                 new OracleParameter("p_rq",OracleType.DateTime),
                                                 new OracleParameter("p_zbld",OracleType.VarChar),
                                                 new OracleParameter("p_ttzb",OracleType.VarChar),
                                                 new OracleParameter("p_zdzb",OracleType.VarChar), 

                                                 new OracleParameter("p_xzb",OracleType.VarChar),
                                                 new OracleParameter("p_gzdbzr",OracleType.VarChar),
                                                 new OracleParameter("p_qb",OracleType.VarChar),
                                                 new OracleParameter("p_tddb",OracleType.VarChar),
                                                 new OracleParameter("p_tx",OracleType.VarChar),
                                                 new OracleParameter("p_dh",OracleType.VarChar),
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_qxjw",OracleType.VarChar),
                                                 new OracleParameter("p_qxgc",OracleType.VarChar),
                                                 new OracleParameter("p_qxyb",OracleType.VarChar),
                                                 new OracleParameter("p_qxgczbdh",OracleType.VarChar),
                                                 new OracleParameter("p_qxybzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_tdzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_dhddh",OracleType.VarChar),
                                                 new OracleParameter("p_xlsdh",OracleType.VarChar),
                                                 new OracleParameter("p_btdh",OracleType.VarChar),
                                                 new OracleParameter("p_zdzbdh",OracleType.VarChar), 
                                                 new OracleParameter("p_ttzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter  ("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_yjgl.p_rq;
                parament[1].Value = struct_yjgl.p_zbld;
                parament[2].Value = struct_yjgl.p_ttzb;
                parament[3].Value = struct_yjgl.p_zdzb; 

                parament[4].Value = struct_yjgl.p_xzb;
                parament[5].Value = struct_yjgl.p_gzdbzr;
                parament[6].Value = struct_yjgl.p_qb;
                parament[7].Value = struct_yjgl.p_tddb;
                parament[8].Value = struct_yjgl.p_tx;
                parament[9].Value = struct_yjgl.p_dh;
                parament[10].Value = struct_yjgl.p_bt;
                parament[11].Value = struct_yjgl.p_qxjw;
                parament[12].Value = struct_yjgl.p_qxgc;
                parament[13].Value = struct_yjgl.p_qxyb;
                parament[14].Value = struct_yjgl.p_qxgczbdh;
                parament[15].Value = struct_yjgl.p_qxybzbdh;
                parament[16].Value = struct_yjgl.p_tdzbdh;
                parament[17].Value = struct_yjgl.p_dhddh;
                parament[18].Value = struct_yjgl.p_xlsdh;
                parament[19].Value = struct_yjgl.p_btdh; 

                parament[20].Value = struct_yjgl.p_tdzbdh;
                parament[21].Value = struct_yjgl.p_zdzbdh;
                parament[21].Value = struct_yjgl.p_ttzbdh;
                parament[22].Value = struct_yjgl.p_bmdm;
                parament[23].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_YJGL.Insert_YJGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[23].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yjgl.p_czfs;
                struct_rz.czxx = struct_yjgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表修改================
        public void Update_YJGL(Struct_YJGL struct_yjgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_rq",OracleType.DateTime),
                                                 new OracleParameter("p_zbld",OracleType.VarChar),
                                                 new OracleParameter("p_ttzb",OracleType.VarChar),
                                                 new OracleParameter("p_zdzb",OracleType.VarChar), 
                                                 
                                                 new OracleParameter("p_xzb",OracleType.VarChar),
                                                 new OracleParameter("p_gzdbzr",OracleType.VarChar),
                                                 new OracleParameter("p_qb",OracleType.VarChar),
                                                 new OracleParameter("p_tddb",OracleType.VarChar),
                                                 new OracleParameter("p_tx",OracleType.VarChar),
                                                 new OracleParameter("p_dh",OracleType.VarChar),
                                                 new OracleParameter("p_bt",OracleType.VarChar),
                                                 new OracleParameter("p_qxjw",OracleType.VarChar),
                                                 new OracleParameter("p_qxgc",OracleType.VarChar),
                                                 new OracleParameter("p_qxyb",OracleType.VarChar),
                                                 new OracleParameter("p_qxgczbdh",OracleType.VarChar),
                                                 new OracleParameter("p_qxybzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_tdzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_dhddh",OracleType.VarChar),
                                                 new OracleParameter("p_xlsdh",OracleType.VarChar),
                                                 new OracleParameter("p_btdh",OracleType.VarChar),
                                                 new OracleParameter("p_zdzbdh",OracleType.VarChar), 
                                                 new OracleParameter("p_ttzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter  ("p_errorCode",OracleType.Int32)
                                                 
                                             };
                parament[0].Value = struct_yjgl.p_id;
                parament[1].Value = struct_yjgl.p_rq;
                parament[2].Value = struct_yjgl.p_zbld;
                parament[3].Value = struct_yjgl.p_ttzb;
                parament[4].Value = struct_yjgl.p_zdzb; 
                parament[5].Value = struct_yjgl.p_xzb;
                parament[6].Value = struct_yjgl.p_gzdbzr;
                parament[7].Value = struct_yjgl.p_qb;
                parament[8 ].Value = struct_yjgl.p_tddb;
                parament[9 ].Value = struct_yjgl.p_tx;
                parament[10].Value = struct_yjgl.p_dh;
                parament[11].Value = struct_yjgl.p_bt;
                parament[12].Value = struct_yjgl.p_qxjw;
                parament[13].Value = struct_yjgl.p_qxgc;
                parament[14].Value = struct_yjgl.p_qxyb;
                parament[15].Value = struct_yjgl.p_qxgczbdh;
                parament[16].Value = struct_yjgl.p_qxybzbdh;
                parament[17].Value = struct_yjgl.p_tdzbdh;
                parament[18].Value = struct_yjgl.p_dhddh;
                parament[19].Value = struct_yjgl.p_xlsdh;
                parament[20].Value = struct_yjgl.p_btdh; 
                parament[21].Value = struct_yjgl.p_tdzbdh;
                parament[21].Value = struct_yjgl.p_zdzbdh;
                parament[22].Value = struct_yjgl.p_ttzbdh;
                parament[23].Value = struct_yjgl.p_bmdm;
                parament[24].Direction = ParameterDirection.Output;





                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_YJGL  .Update_YJGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[24].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yjgl.p_czfs;
                struct_rz.czxx = struct_yjgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=============删除值班表信息=================
        protected void Delete_YJGL(int id, string p_czfs, string p_czxx)
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
                dbclass.RunProcedure("PACK_BS_YJGL  . Delete_YJGL", parament, out result);

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
        public DataTable Select_YJGL_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_BS_YJGL  .Select_YJGL_Detail", paras, "table").Tables[0];
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
                dt = dbclass.RunProcedure("PACK_BS_YJGL  .Select_YGXMbyBH", paras, "table").Tables[0];
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
                dt = dbclass.RunProcedure("PACK_BS_YJGL .Select_YGByBMDQ", paras, "table").Tables[0];
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
