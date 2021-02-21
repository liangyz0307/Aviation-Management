using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_CBSGL
    {
        public int p_id;//id 
        public DateTime p_kssj;//日期 
        public DateTime p_jssj;//日期 
        public DateTime p_rq;//日期 
        public string p_zbld;//值班领导
        public string p_ttzb;//值班领导电话
        public string p_zdzb;//值班岗位
        public string p_tdzb;//值班员工
        public string p_qxyb;//值班电话
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
        public string p_gc;
        public string p_qxgczbdh;//审核时间
        public string p_qxybzbdh;//时间戳
        public string p_tdzbdh;//时间标识
        public string p_bmdm;//数据所属部门
        public string p_zdzbdh;//录入人
        public string p_ttzbdh;//初审人
        public string p_zsr;//终审人
        public string p_bhyy;//驳回原因
        public int p_userid;
        public string p_dqdm;

    }
    public class OCBSGL
    { 
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;

        public OCBSGL(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region  ===============值班表信息查询================
        public DataTable Select_CBSGL_Pro(Struct_CBSGL struct_cbsgl)
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
                parament[0].Value = struct_cbsgl.p_kssj;
                parament[1].Value = struct_cbsgl.p_jssj;
                parament[2].Value = struct_cbsgl.p_zbld;
                parament[3].Value = struct_cbsgl.p_userid;
                parament[4].Value = struct_cbsgl.p_pagesize;
                parament[5].Value = struct_cbsgl.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_BS_CBSGL.Select_CBSGL_Pro", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============值班表信息数量查询================
        public int Select_CBSGL_Count(Struct_CBSGL struct_cbsgl)
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
                parament[0].Value = struct_cbsgl.p_kssj;
                parament[1].Value = struct_cbsgl.p_jssj;
                parament[2].Value = struct_cbsgl.p_zbld;
                parament[3].Value = struct_cbsgl.p_userid;

                parament[4].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_BS_CBSGL.Select_CBSGL_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表添加================
        protected  void Insert_CBSGL(Struct_CBSGL struct_cbsgl)
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
                                                 new OracleParameter("p_tdzb",OracleType.VarChar),
                                                 new OracleParameter("p_qxyb",OracleType.VarChar),
                                                 new OracleParameter("p_gc",OracleType.VarChar),
                                                 new OracleParameter("p_qxgczbdh",OracleType.VarChar),
                                                 new OracleParameter("p_qxybzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_tdzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_zdzbdh",OracleType.VarChar), 
                                                 new OracleParameter("p_ttzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter  ("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_cbsgl.p_rq;
                parament[1].Value = struct_cbsgl.p_zbld;
                parament[2].Value = struct_cbsgl.p_ttzb;
                parament[3].Value = struct_cbsgl.p_zdzb;
                parament[4].Value = struct_cbsgl.p_tdzb;
                parament[5].Value = struct_cbsgl.p_qxyb;
                parament[6].Value = struct_cbsgl.p_gc;
                parament[7].Value = struct_cbsgl.p_qxgczbdh;
                parament[8].Value = struct_cbsgl.p_qxybzbdh;
                parament[9].Value = struct_cbsgl.p_tdzbdh;
                parament[10].Value = struct_cbsgl.p_zdzbdh;
                parament[11].Value = struct_cbsgl.p_ttzbdh; 
                parament[12].Value = struct_cbsgl.p_bmdm;
                parament[13].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_CBSGL  .Insert_CBSGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[13].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_cbsgl.p_czfs;
                struct_rz.czxx = struct_cbsgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表修改================
        public void Update_CBSGL(Struct_CBSGL struct_cbsgl)
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
                                                 new OracleParameter("p_tdzb",OracleType.VarChar),
                                                 new OracleParameter("p_qxyb",OracleType.VarChar),
                                                 new OracleParameter("p_gc",OracleType.VarChar),
                                                 new OracleParameter("p_qxgczbdh",OracleType.VarChar),
                                                 new OracleParameter("p_qxybzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_tdzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_zdzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_ttzbdh",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_cbsgl.p_id;
                parament[1].Value = struct_cbsgl.p_rq;
                parament[2].Value = struct_cbsgl.p_zbld;
                parament[3].Value = struct_cbsgl.p_ttzb;
                parament[4].Value = struct_cbsgl.p_zdzb;
                parament[5].Value = struct_cbsgl.p_tdzb;
                parament[6].Value = struct_cbsgl.p_qxyb;
                parament[7].Value = struct_cbsgl.p_gc;
                parament[8].Value = struct_cbsgl.p_qxgczbdh;
                parament[9].Value = struct_cbsgl.p_qxybzbdh;
                parament[10].Value = struct_cbsgl.p_tdzbdh;
                parament[11].Value = struct_cbsgl.p_zdzbdh;
                parament[12].Value = struct_cbsgl.p_ttzbdh;
                parament[13].Value = struct_cbsgl.p_bmdm;
                parament[14].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_CBSGL  .Update_CBSGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[14].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_cbsgl.p_czfs;
                struct_rz.czxx = struct_cbsgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=============删除值班表信息=================
        protected  void Delete_CBSGL(int id, string p_czfs, string p_czxx)
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
                dbclass.RunProcedure("PACK_BS_CBSGL  .Delete_CBSGL", parament, out result);

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
        public DataTable Select_CBSGL_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_BS_CBSGL  .Select_CBSGL_Detail", paras, "table").Tables[0];
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
                dt = dbclass.RunProcedure("PACK_BS_CBSGL  .Select_YGXMbyBH", paras, "table").Tables[0];
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
                dt = dbclass.RunProcedure("PACK_BS_CBSGL  .Select_YGByBMDQ", paras, "table").Tables[0];
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
