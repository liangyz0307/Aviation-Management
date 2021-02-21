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
    public struct Struct_YGZC//员工职称
    {
        public int p_id;//id
        public string p_spr;//受聘人
        public string p_lb;//类别
        public string p_jb;//级别
        public string p_zg;//资格
        public string p_pr;//聘任
        public string p_zgsqdw;//资格审权单位
        public DateTime p_hdsj;//获得时间
        public DateTime p_prsjks;//聘任时间开始
        public DateTime p_prsjjs;//聘任时间结束
        public DateTime p_dqsj;//到期时间
        public string p_zt;//状态代码
        public string p_bhyy;//驳回原因
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;//操作方式
        public string p_czxx;//操作类型 
        public int p_userid;
        public string p_bmdm;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
    public class OYGZC
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;
        public OYGZC(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region 查询职称记录
        protected DataTable Select_YGZC_Pro(Struct_YGZC struct_YGZC)
        {

            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_spr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_lb",OracleType.VarChar),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                  new OracleParameter("p_zg",OracleType.VarChar),
                                                  new OracleParameter("p_prsjks",OracleType.DateTime),
                                                  new OracleParameter("p_prsjjs",OracleType.DateTime),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor) 
                                              };
                parament[0].Value = struct_YGZC.p_spr;
                parament[1].Value = struct_YGZC.p_bmdm;
                parament[2].Value = struct_YGZC.p_lb;
                parament[3].Value = struct_YGZC.p_jb;
                parament[4].Value = struct_YGZC.p_zg;
                parament[5].Value = struct_YGZC.p_prsjks;
                parament[6].Value = struct_YGZC.p_prsjjs;
                parament[7].Value = struct_YGZC.p_zt;
                parament[8].Value = struct_YGZC.p_userid;
                parament[9].Value = struct_YGZC.p_pagesize;
                parament[10].Value = struct_YGZC.p_currentpage;
                parament[11].Direction = ParameterDirection.Output;

                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //普通员工履历查询
        protected DataTable Select_YGZC_Pro_Ptyg(Struct_YGZC struct_YGZC)
        {

            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_spr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_lb",OracleType.VarChar),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                  new OracleParameter("p_zg",OracleType.VarChar),
                                                  new OracleParameter("p_prsjks",OracleType.DateTime),
                                                  new OracleParameter("p_prsjjs",OracleType.DateTime),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                              };
                parament[0].Value = struct_YGZC.p_spr;
                parament[1].Value = struct_YGZC.p_bmdm;
                parament[2].Value = struct_YGZC.p_lb;
                parament[3].Value = struct_YGZC.p_jb;
                parament[4].Value = struct_YGZC.p_zg;
                parament[5].Value = struct_YGZC.p_prsjks;
                parament[6].Value = struct_YGZC.p_prsjjs;
                parament[7].Value = struct_YGZC.p_zt;
                parament[8].Value = struct_YGZC.p_userid;
                parament[9].Value = struct_YGZC.p_pagesize;
                parament[10].Value = struct_YGZC.p_currentpage;
                parament[11].Direction = ParameterDirection.Output;

                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_Pro_Ptyg", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查询职称数量
        protected int Select_YGZC_Count(Struct_YGZC struct_YGZC)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_spr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_lb",OracleType.VarChar),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                  new OracleParameter("p_zg",OracleType.VarChar),
                                                  new OracleParameter("p_prsjks",OracleType.DateTime),
                                                  new OracleParameter("p_prsjjs",OracleType.DateTime),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor) 
                                              };
                parament[0].Value = struct_YGZC.p_spr;
                parament[1].Value = struct_YGZC.p_bmdm;
                parament[2].Value = struct_YGZC.p_lb;
                parament[3].Value = struct_YGZC.p_jb;
                parament[4].Value = struct_YGZC.p_zg;
                parament[5].Value = struct_YGZC.p_prsjks;
                parament[6].Value = struct_YGZC.p_prsjjs;
                parament[7].Value = struct_YGZC.p_zt;
                parament[8].Value = struct_YGZC.p_userid;
                parament[9].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }

        }
        //普通员工履历数量查询
        protected int Select_YGZC_Count_Ptyg(Struct_YGZC struct_YGZC)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_spr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_lb",OracleType.VarChar),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                  new OracleParameter("p_zg",OracleType.VarChar),
                                                  new OracleParameter("p_prsjks",OracleType.DateTime),
                                                  new OracleParameter("p_prsjjs",OracleType.DateTime),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                              };
                parament[0].Value = struct_YGZC.p_spr;
                parament[1].Value = struct_YGZC.p_bmdm;
                parament[2].Value = struct_YGZC.p_lb;
                parament[3].Value = struct_YGZC.p_jb;
                parament[4].Value = struct_YGZC.p_zg;
                parament[5].Value = struct_YGZC.p_prsjks;
                parament[6].Value = struct_YGZC.p_prsjjs;
                parament[7].Value = struct_YGZC.p_zt;
                parament[8].Value = struct_YGZC.p_userid;
                parament[9].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_Count_Ptyg", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }

        }
        #endregion
        #region 查询职称详情
        protected DataTable Select_YGZC_Detail(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                             new OracleParameter("p_id",OracleType.Number),
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                          };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_Detail", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 按部门岗位查询员工
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
                dt = dbclass.RunProcedure("PACK_KG_YGZC.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 添加职称
        protected void Insert_YGZC(Struct_YGZC struct_YGZC)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_id",OracleType.Number),
                                                  new OracleParameter("p_spr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_lb",OracleType.VarChar),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                  new OracleParameter("p_zg",OracleType.VarChar),
                                                  new OracleParameter("p_pr",OracleType.VarChar),
                                                  new OracleParameter("p_zgsqdw",OracleType.VarChar),
                                                  new OracleParameter("p_hdsj",OracleType.DateTime),
                                                  new OracleParameter("p_prsjks",OracleType.DateTime),
                                                  new OracleParameter("p_dqsj",OracleType.DateTime),
                                                  new OracleParameter("p_csr",OracleType.VarChar),
                                                  new OracleParameter("p_zsr",OracleType.VarChar),
                                                  new OracleParameter("p_lrr",OracleType.VarChar),
                                                  new OracleParameter("p_sjc",OracleType.VarChar),
                                                  new OracleParameter("p_sjbs",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_errorCode",OracleType.Int32)
                                              };
                parament[0].Value = struct_YGZC.p_id;
                parament[1].Value = struct_YGZC.p_spr;
                parament[2].Value = struct_YGZC.p_bmdm;
                parament[3].Value = struct_YGZC.p_lb;
                parament[4].Value = struct_YGZC.p_jb;
                parament[5].Value = struct_YGZC.p_zg;
                parament[6].Value = struct_YGZC.p_pr;
                parament[7].Value = struct_YGZC.p_zgsqdw;
                parament[8].Value = struct_YGZC.p_hdsj;
                parament[9].Value = struct_YGZC.p_prsjks;
                parament[10].Value = struct_YGZC.p_dqsj;
                parament[11].Value = struct_YGZC.p_csr;
                parament[12].Value = struct_YGZC.p_zsr;
                parament[13].Value = struct_YGZC.p_lrr;
                parament[14].Value = struct_YGZC.p_sjc;
                parament[15].Value = struct_YGZC.p_sjbs;
                parament[16].Value = struct_YGZC.p_zt;
                parament[17].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGZC.Insert_YGZC", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[17].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_YGZC.p_czfs;
                struct_RZ_YH.czxx = struct_YGZC.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 更改职称
        protected void Update_YGZC(Struct_YGZC struct_YGZC)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                  new OracleParameter("p_id",OracleType.Number),
                                                  new OracleParameter("p_spr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_lb",OracleType.VarChar),
                                                  new OracleParameter("p_jb",OracleType.VarChar),
                                                  new OracleParameter("p_zg",OracleType.VarChar),
                                                  new OracleParameter("p_pr",OracleType.VarChar),
                                                  new OracleParameter("p_zgsqdw",OracleType.VarChar),
                                                  new OracleParameter("p_hdsj",OracleType.DateTime),
                                                  new OracleParameter("p_prsjks",OracleType.DateTime),
                                                  new OracleParameter("p_dqsj",OracleType.DateTime),
                                                  new OracleParameter("p_csr",OracleType.VarChar),
                                                  new OracleParameter("p_zsr",OracleType.VarChar),
                                                  new OracleParameter("p_lrr",OracleType.VarChar),
                                                  new OracleParameter("p_sjbs",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_errorCode",OracleType.Int32)
                                              };
                parament[0].Value = struct_YGZC.p_id;
                parament[1].Value = struct_YGZC.p_spr;
                parament[2].Value = struct_YGZC.p_bmdm;
                parament[3].Value = struct_YGZC.p_lb;
                parament[4].Value = struct_YGZC.p_jb;
                parament[5].Value = struct_YGZC.p_zg;
                parament[6].Value = struct_YGZC.p_pr;
                parament[7].Value = struct_YGZC.p_zgsqdw;
                parament[8].Value = struct_YGZC.p_hdsj;
                parament[9].Value = struct_YGZC.p_prsjks;
                parament[10].Value = struct_YGZC.p_dqsj;
                parament[11].Value = struct_YGZC.p_csr;
                parament[12].Value = struct_YGZC.p_zsr;
                parament[13].Value = struct_YGZC.p_lrr;
                parament[14].Value = struct_YGZC.p_sjbs;
                parament[15].Value = struct_YGZC.p_zt;
                parament[16].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGZC.Update_YGZC", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[16].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_YGZC.p_czfs;
                struct_RZ_YH.czxx = struct_YGZC.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 更新状态
        protected void Update_YGZCZT(Struct_YGZC struct_YGZC)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_YGZC.p_id;
                paras[1].Value = struct_YGZC.p_zt;
                paras[2].Value = struct_YGZC.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZC.Update_YGZCZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_YGZC.p_czfs;
                struct_rz.czxx = struct_YGZC.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 变更数据标识
        //变更数据标识
        protected void Update_YGZC_SJBS_ZT(Struct_YGZC struct_YGZC)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_YGZC.p_sjc;
                paras[1].Value = struct_YGZC.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZC.Update_YGZC_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_YGZC.p_czfs;
                struct_rz.czxx = struct_YGZC.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 将原最终数据变为历史数据
        //将原最终数据变为历史数据
        protected void Update_YGZC_SJBS_LSSJ_ZT(Struct_YGZC struct_YGZC)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_YGZC.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZC.Update_YGZC_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_YGZC.p_czfs;
                struct_rz.czxx = struct_YGZC.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #region 将副本数据变为最终数据
        protected void Update_YGZC_SJBS_FBSJ_ZT(Struct_YGZC struct_YGZC)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_YGZC.p_sjc;
                paras[1].Value = struct_YGZC.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGZC.Update_YGZC_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_YGZC.p_czfs;
                struct_rz.czxx = struct_YGZC.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #region 删除职称记录
        protected void Delete_YGZC(int id, string p_czfs, string p_czxx)
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
                dbclass.RunProcedure("PACK_KG_YGZC.Delete_YGZC", parament, out result);

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
        protected int YGZC_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_YGZC_Detail(id);
            //备份数据
            Struct_YGZC ygzc_bf = new Struct_YGZC();


            ygzc_bf.p_lb = dt_detail.Rows[0]["lb"].ToString();//类别
            ygzc_bf.p_jb = dt_detail.Rows[0]["jb"].ToString();//级别
            ygzc_bf.p_zg = dt_detail.Rows[0]["zg"].ToString();//资格
            ygzc_bf.p_pr = dt_detail.Rows[0]["pr"].ToString();//是否聘任
            ygzc_bf.p_zgsqdw = dt_detail.Rows[0]["zgsqdw"].ToString();//资格审权单位
            ygzc_bf.p_hdsj = Convert.ToDateTime(dt_detail.Rows[0]["hdsj"]);//获得时间
            ygzc_bf.p_prsjks = Convert.ToDateTime(dt_detail.Rows[0]["prsj"]);//聘任时间开始
            ygzc_bf.p_prsjjs = Convert.ToDateTime(dt_detail.Rows[0]["prsj"]);//聘任时间开始
            ygzc_bf.p_dqsj = Convert.ToDateTime(dt_detail.Rows[0]["dqsj"]);//到期时间
            ygzc_bf.p_zt = "0";
            ygzc_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            ygzc_bf.p_spr = dt_detail.Rows[0]["spr"].ToString();
            ygzc_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            ygzc_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            ygzc_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            ygzc_bf.p_lrr = _usState.userLoginName;
            ygzc_bf.p_sjbs = "2";
            ygzc_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            ygzc_bf.p_shsj = "";
            ygzc_bf.p_czfs = "02";
            ygzc_bf.p_czxx = "员工职称id:" + id + "生成副本数据";
            //插入
            Insert_YGZC(ygzc_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = ygzc_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        public new DataTable Select_YGZC_BYBH(string ygbh, int userid)
        {

            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = ygbh;
                parament[1].Value = userid;
                parament[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_BYBH", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //数据导出
        protected DataTable Select_YGZC_DC(int p_userid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_userid",OracleType.Int32),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };
                paras[0].Value = p_userid;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGZC.Select_YGZC_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
    }
}
