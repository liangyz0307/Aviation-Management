using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_ZBGL {
        public int p_id;//id
        public int p_xh;//序号
        public string p_xq;//星期
        public string p_rq;//日期
        public string p_jc;//机场
        public string p_bm;//部门
        public string p_zbld;//值班领导
        public string p_zblddh;//值班领导电话

        public string p_zbgw;//值班岗位
        public string p_zbyg;//值班员工
        public string p_zbdh;//值班电话

        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
        public string p_zt;
        public string p_shsj;//审核时间
        public string p_sjc;//时间戳
        public string p_sjbs;//时间标识
        public string p_bmdm;//数据所属部门
        public string p_lrr;//录入人
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_bhyy;//驳回原因
        public int p_userid;
        public string p_dqdm;
        
    }
    public class OZBGL
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;

        public OZBGL(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region  ===============值班表信息查询================
        public DataTable Select_ZBGL_Pro(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_xq",OracleType.VarChar),
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_bm",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_zbgl.p_xq;
                parament[1].Value = struct_zbgl.p_jc;
                parament[2].Value = struct_zbgl.p_bm;
                parament[3].Value = struct_zbgl.p_zt;
                parament[4].Value = struct_zbgl.p_userid;
                parament[5].Value = struct_zbgl.p_pagesize;
                parament[6].Value = struct_zbgl.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_BS_ZBGL.Select_ZBGL_Pro", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============值班表信息数量查询================
        public int Select_ZBGL_Count(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_xq",OracleType.VarChar),
                    new OracleParameter("p_jc",OracleType.VarChar),
                    new OracleParameter("p_bm",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = struct_zbgl.p_xq;
                parament[1].Value = struct_zbgl.p_jc;
                parament[2].Value = struct_zbgl.p_bm;
                parament[3].Value = struct_zbgl.p_zt;
                parament[4].Value = struct_zbgl.p_userid;
                
                parament[5].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_BS_ZBGL.Select_ZBGL_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表添加================
        public void Insert_ZBGL(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_xq",OracleType.VarChar),
                                                 new OracleParameter("p_rq",OracleType.VarChar),
                                                 new OracleParameter("p_jc",OracleType.VarChar),
                                                 new OracleParameter("p_bm",OracleType.VarChar),
                                                 new OracleParameter("p_zbld",OracleType.VarChar),
                                                 new OracleParameter("p_zblddh",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_zbgl.p_id;
                parament[1].Value = struct_zbgl.p_xq;
                parament[2].Value = struct_zbgl.p_rq;
                parament[3].Value = struct_zbgl.p_jc;
                parament[4].Value = struct_zbgl.p_bm;
                parament[5].Value = struct_zbgl.p_zbld;
                parament[6].Value = struct_zbgl.p_zblddh;
                parament[7].Value = struct_zbgl.p_zt;
                parament[8].Value = struct_zbgl.p_bmdm;
                parament[9].Value = struct_zbgl.p_csr;
                parament[10].Value = struct_zbgl.p_zsr;
                parament[11].Value = struct_zbgl.p_lrr;
                parament[12].Value = struct_zbgl.p_sjc;
                parament[13].Value = struct_zbgl.p_sjbs;
                parament[14].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Insert_ZBGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[14].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zbgl.p_czfs;
                struct_rz.czxx = struct_zbgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=================值班表修改================
        public void Update_ZBGL(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_xq",OracleType.VarChar),
                                                 new OracleParameter("p_rq",OracleType.VarChar),
                                                 new OracleParameter("p_jc",OracleType.VarChar),
                                                 new OracleParameter("p_bm",OracleType.VarChar),
                                                 new OracleParameter("p_zbld",OracleType.VarChar),
                                                 new OracleParameter("p_zblddh",OracleType.VarChar),

                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_zbgl.p_id;
                parament[1].Value = struct_zbgl.p_xq;
                parament[2].Value = struct_zbgl.p_rq;
                parament[3].Value = struct_zbgl.p_jc;
                parament[4].Value = struct_zbgl.p_bm;
                parament[5].Value = struct_zbgl.p_zbld;
                parament[6].Value = struct_zbgl.p_zblddh;

                parament[7].Value = struct_zbgl.p_bmdm;
                parament[8].Value = struct_zbgl.p_csr;
                parament[9].Value = struct_zbgl.p_zsr;
                parament[10].Value = struct_zbgl.p_lrr;
                parament[11].Value = struct_zbgl.p_zt;
                parament[12].Value = struct_zbgl.p_sjbs;
                parament[13].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Update_ZBGL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[13].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zbgl.p_czfs;
                struct_rz.czxx = struct_zbgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region=============删除值班表信息=================
        public void Delete_ZBGL(int id, string p_czfs, string p_czxx)
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
                dbclass.RunProcedure("PACK_BS_ZBGL.Delete_ZBGL", parament, out result);

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
        public DataTable Select_ZBGL_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_BS_ZBGL.Select_ZBGL_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region ============子表=====查询员工============
        protected DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                       new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bmdm;
                paras[1].Value = gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_BS_ZBGL.Select_YGbyBMGW", paras, "table").Tables[0];
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
                dt = dbclass.RunProcedure("PACK_BS_ZBGL.Select_YGByBMDQ", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region===============通过id查询子表值班员工情况================
        protected DataTable Select_ZBTJByID(int id)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_BS_ZBGL.Select_ZBTJByID", parament, "table").Tables[0];

                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region  ===============值班员工添加================
        protected void Insert_ZBTJ(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                        new OracleParameter("p_id",OracleType.Int32),
                        new OracleParameter("p_zbgw",OracleType.VarChar),
                        new OracleParameter("p_zbyg",OracleType.VarChar),
                        new OracleParameter("p_zbdh",OracleType.VarChar),
                        new OracleParameter("p_xh",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_zbgl.p_id;
                parament[1].Value = struct_zbgl.p_zbgw;
                parament[2].Value = struct_zbgl.p_zbyg;
                parament[3].Value = struct_zbgl.p_zbdh;
                parament[4].Value = struct_zbgl.p_xh;
                parament[5].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Insert_ZBTJ", parament, out result);
                int returnCode = Convert.ToInt32(parament[5].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zbgl.p_czfs;
                struct_rz.czxx = struct_zbgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region===============值班员工信息删除================
        protected void Delete_ZBTJ(int p_xh, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_xh",OracleType.Int32),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = p_xh;
                parament[1].Direction = ParameterDirection.Output;
                int result = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Delete_ZBTJ", parament, out result);
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
        #endregion


        #region ======================更新状态==========================
        //更新状态
        public void Update_ZBGLZT(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Number),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_bhyy",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_zbgl.p_id;
                parament[1].Value = struct_zbgl.p_zt;
                parament[2].Value = struct_zbgl.p_bhyy;
                parament[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Update_ZBGLZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zbgl.p_czfs;
                struct_rz.czxx = struct_zbgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //变更数据标识
        public void Update_ZBGL_SJBS_ZT(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_shsj",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_zbgl.p_sjc;
                parament[1].Value = struct_zbgl.p_shsj;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Update_ZBGL_SJBS_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zbgl.p_czfs;
                struct_rz.czxx = struct_zbgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将原最终数据变为历史数据
        public void Update_ZBGL_SJBS_LSSJ_ZT(Struct_ZBGL struct_zbgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                new OracleParameter("p_sjc",OracleType.VarChar),
                new OracleParameter("p_errorCode",OracleType.Int32)
            };
                parament[0].Value = struct_zbgl.p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Update_ZBGL_SJBS_LSSJ_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_usState);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zbgl.p_czfs;
                struct_rz.czxx = struct_zbgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将副本数据变为最终数据
        public void Update_ZBGL_SJBS_FBSJ_ZT(Struct_ZBGL struct_zbgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_zbgl.p_sjc;
                paras[1].Value = struct_zbgl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_BS_ZBGL.Update_ZBGL_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_usState);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_zbgl.p_czfs;
                struct_rz.czxx = struct_zbgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region======================备份数据=====================
        //查出原始数据，备份数据
        public int ZBGL_SJBF(int id)
        {

            DataTable dt_detail = new DataTable();
            dt_detail = Select_ZBGL_Detail(id);
            Struct_ZBGL struct_zbgl = new Struct_ZBGL();


            struct_zbgl.p_xq = dt_detail.Rows[0]["xq"].ToString();
            struct_zbgl.p_rq = dt_detail.Rows[0]["rq"].ToString();
            struct_zbgl.p_jc = dt_detail.Rows[0]["jc"].ToString();
            struct_zbgl.p_bm = dt_detail.Rows[0]["bm"].ToString();
            struct_zbgl.p_zbld = dt_detail.Rows[0]["zbld"].ToString();
            struct_zbgl.p_zblddh = dt_detail.Rows[0]["zblddh"].ToString();

            struct_zbgl.p_zt = "0";
            struct_zbgl.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            struct_zbgl.p_sjbs = "2";
            struct_zbgl.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            struct_zbgl.p_lrr = _usState.userLoginName;
            struct_zbgl.p_csr = dt_detail.Rows[0]["csr"].ToString();
            struct_zbgl.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            struct_zbgl.p_shsj = "";
            struct_zbgl.p_czfs = "02";
            struct_zbgl.p_czxx = "值班信息id:" + id + "生成副本数据";
            //插入
            Insert_ZBGL(struct_zbgl);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = struct_zbgl.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_BS_ZBGL.Select_ZBGL_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion



    }
}
