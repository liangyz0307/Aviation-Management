using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_YGJL_Pro//奖励记录
    {
        public int p_id;
        public DateTime p_rqks;//开始日期
        public DateTime p_rqjs;//结束日期
        public string p_sjr;//受奖人
        public string p_bmdm;//部门    
        public string p_jlyy;//奖励原因
        public string p_jlzl;//奖励种类
        public string p_jldj;//奖励等级
        public string p_jlnr;//奖励内容
        public string p_fzr;//负责人
        public string p_zt;//状态代码
        public string p_bhyy;//驳回原因
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;//操作方式
        public string p_czxx;//操作类型
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }

    public class OYGJL
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;

        public OYGJL(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region 奖励记录增删改查

        //查询奖励记录
        protected DataTable Select_YGJL_Pro(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_rqks",OracleType.DateTime),
                                                 new OracleParameter("p_rqjs",OracleType.DateTime),
                                                 new OracleParameter("p_sjr",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_jlzl",OracleType.VarChar),
                                                 new OracleParameter("p_jldj",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)       
                                             };
                parament[0].Value = struct_YGJL.p_rqks;
                parament[1].Value = struct_YGJL.p_rqjs;
                parament[2].Value = struct_YGJL.p_sjr;
                parament[3].Value = struct_YGJL.p_bmdm;
                parament[4].Value = struct_YGJL.p_jlzl;
                parament[5].Value = struct_YGJL.p_jldj;
                parament[6].Value = struct_YGJL.p_zt;
                parament[7].Value = struct_YGJL.p_userid;
                parament[8].Value = struct_YGJL.p_pagesize;
                parament[9].Value = struct_YGJL.p_currentpage;
                parament[10].Direction = ParameterDirection.Output;


                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //普通员工只能看见本人信息
        protected DataTable Select_YGJL_Pro_Ptyg(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_rqks",OracleType.DateTime),
                                                 new OracleParameter("p_rqjs",OracleType.DateTime),
                                                 new OracleParameter("p_sjr",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_jlzl",OracleType.VarChar),
                                                 new OracleParameter("p_jldj",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_YGJL.p_rqks;
                parament[1].Value = struct_YGJL.p_rqjs;
                parament[2].Value = struct_YGJL.p_sjr;
                parament[3].Value = struct_YGJL.p_bmdm;
                parament[4].Value = struct_YGJL.p_jlzl;
                parament[5].Value = struct_YGJL.p_jldj;
                parament[6].Value = struct_YGJL.p_zt;
                parament[7].Value = struct_YGJL.p_userid;
                parament[8].Value = struct_YGJL.p_pagesize;
                parament[9].Value = struct_YGJL.p_currentpage;
                parament[10].Direction = ParameterDirection.Output;


                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_Pro_Ptyg", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //查询详细信息
        protected DataTable Select_YGJL_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //查询奖励记录数量
        protected int Select_YGJL_Count(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_rqks",OracleType.DateTime),
                                                 new OracleParameter("p_rqjs",OracleType.DateTime),
                                                 new OracleParameter("p_sjr",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_jlzl",OracleType.VarChar),
                                                 new OracleParameter("p_jldj",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)       
                                             };
                parament[0].Value = struct_YGJL.p_rqks;
                parament[1].Value = struct_YGJL.p_rqjs;
                parament[2].Value = struct_YGJL.p_sjr;
                parament[3].Value = struct_YGJL.p_bmdm;
                parament[4].Value = struct_YGJL.p_jlzl;
                parament[5].Value = struct_YGJL.p_jldj;
                parament[6].Value = struct_YGJL.p_zt;
                parament[7].Value = struct_YGJL.p_userid;
                parament[8].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally { }
        }

        protected int Select_YGJL_Count_Ptyg(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_rqks",OracleType.DateTime),
                                                 new OracleParameter("p_rqjs",OracleType.DateTime),
                                                 new OracleParameter("p_sjr",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_jlzl",OracleType.VarChar),
                                                 new OracleParameter("p_jldj",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_YGJL.p_rqks;
                parament[1].Value = struct_YGJL.p_rqjs;
                parament[2].Value = struct_YGJL.p_sjr;
                parament[3].Value = struct_YGJL.p_bmdm;
                parament[4].Value = struct_YGJL.p_jlzl;
                parament[5].Value = struct_YGJL.p_jldj;
                parament[6].Value = struct_YGJL.p_userid;
                parament[7].Value = struct_YGJL.p_zt;
                parament[8].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_Count_Ptyg", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally { }
        }

        #region 查询员工
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
                dt = dbclass.RunProcedure("PACK_KG_YGJL.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        //添加奖励记录
        protected void Insert_YGJL(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_sjr",OracleType.VarChar),
                                                 new OracleParameter("p_rqks",OracleType.DateTime),
                                                 new OracleParameter("p_jlyy",OracleType.VarChar),
                                                 new OracleParameter("p_jlzl",OracleType.VarChar),
                                                 new OracleParameter("p_jldj",OracleType.VarChar),
                                                 new OracleParameter("p_jlnr",OracleType.VarChar),
                                                 new OracleParameter("p_fzr",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_YGJL.p_id;
                parament[1].Value = struct_YGJL.p_sjr;
                parament[2].Value = struct_YGJL.p_rqks;
                parament[3].Value = struct_YGJL.p_jlyy;
                parament[4].Value = struct_YGJL.p_jlzl;
                parament[5].Value = struct_YGJL.p_jldj;
                parament[6].Value = struct_YGJL.p_jlnr;
                parament[7].Value = struct_YGJL.p_fzr;
                parament[8].Value = "";
                parament[9].Value = struct_YGJL.p_csr;
                parament[10].Value = struct_YGJL.p_zsr;
                parament[11].Value = struct_YGJL.p_lrr;
                parament[12].Value = struct_YGJL.p_sjc;
                parament[13].Value = struct_YGJL.p_sjbs;
                parament[14].Value = struct_YGJL.p_zt;
                parament[15].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGJL.Insert_YGJL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[15].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_YGJL.p_czfs;
                struct_RZ_YH.czxx = struct_YGJL.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }

        //更改奖励记录

        //更改奖励状态
        #region 更新状态
        protected void Update_YGJLZT(Struct_YGJL_Pro ygjl)
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
                paras[0].Value = ygjl.p_id;
                paras[1].Value = ygjl.p_zt;
                paras[2].Value = ygjl.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGJL.Update_YGJLZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygjl.p_czfs;
                struct_rz.czxx = ygjl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //变更数据标识
        protected void Update_YGJL_SJBS_ZT(Struct_YGJL_Pro ygjl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                
                paras[0].Value = ygjl.p_sjc;
                paras[1].Value = ygjl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGJL.Update_YGJL_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygjl.p_czfs;
                struct_rz.czxx = ygjl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_YGJL_SJBS_LSSJ_ZT(Struct_YGJL_Pro ygjl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygjl.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGJL.Update_YGJL_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygjl.p_czfs;
                struct_rz.czxx = ygjl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        #region 将副本数据变为最终数据
        protected void Update_YGJL_SJBS_FBSJ_ZT(Struct_YGJL_Pro ygjl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygjl.p_sjc;
                paras[1].Value = ygjl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGJL.Update_YGJL_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygjl.p_czfs;
                struct_rz.czxx = ygjl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        
        protected void Update_YGJL(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_sjr",OracleType.VarChar),
                                                 new OracleParameter("p_rqks",OracleType.DateTime),
                                                 new OracleParameter("p_jlyy",OracleType.VarChar),
                                                 new OracleParameter("p_jlzl",OracleType.VarChar),
                                                 new OracleParameter("p_jldj",OracleType.VarChar),
                                                 new OracleParameter("p_jlnr",OracleType.VarChar),
                                                 new OracleParameter("p_fzr",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_YGJL.p_id;
                parament[1].Value = struct_YGJL.p_sjr;
                parament[2].Value = struct_YGJL.p_rqks;
                parament[3].Value = struct_YGJL.p_jlyy;
                parament[4].Value = struct_YGJL.p_jlzl;
                parament[5].Value = struct_YGJL.p_jldj;
                parament[6].Value = struct_YGJL.p_jlnr;
                parament[7].Value = struct_YGJL.p_fzr;
                parament[8].Value = "";
                parament[9].Value = struct_YGJL.p_csr;
                parament[10].Value = struct_YGJL.p_zsr;
                parament[11].Value = struct_YGJL.p_lrr;
                parament[12].Value = struct_YGJL.p_zt;
                parament[13].Value = struct_YGJL.p_sjbs;
                parament[14].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGJL.Update_YGJL", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[14].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_YGJL.p_czfs;
                struct_RZ_YH.czxx = struct_YGJL.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }

        //删除奖励记录
        protected void Delete_YGJL(int id, string p_czfs, string p_czxx)
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
                dbclass.RunProcedure("PACK_KG_YGJL.Delete_YGJL", parament, out result);

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

        
        protected int  YGJL_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_YGJL_Detail(id);
            //备份数据
            Struct_YGJL_Pro ygjl_bf = new Struct_YGJL_Pro();

            ygjl_bf.p_rqks = Convert.ToDateTime(dt_detail.Rows[0]["rq"].ToString());
            ygjl_bf.p_rqjs = Convert.ToDateTime(dt_detail.Rows[0]["rq"].ToString());
            ygjl_bf.p_sjr = dt_detail.Rows[0]["sjr"].ToString();
            ygjl_bf.p_jlyy = dt_detail.Rows[0]["jlyy"].ToString();
            ygjl_bf.p_jlzl = dt_detail.Rows[0]["jlzl"].ToString();
            ygjl_bf.p_jldj = dt_detail.Rows[0]["jldj"].ToString();
            ygjl_bf.p_jlnr = dt_detail.Rows[0]["jlnr"].ToString();
            ygjl_bf.p_fzr = dt_detail.Rows[0]["fzr"].ToString();
            ygjl_bf.p_zt = "0";
            ygjl_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            ygjl_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            ygjl_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            ygjl_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            ygjl_bf.p_lrr = _usState.userLoginName;
            ygjl_bf.p_sjbs = "2";
            ygjl_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            ygjl_bf.p_shsj = "";
            ygjl_bf.p_czfs = "02";
            ygjl_bf.p_czxx = "员工奖励id:"+id+"生成副本数据";
            //插入
            Insert_YGJL(ygjl_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = ygjl_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }


        public new DataTable Select_YGJL_BYBH(string ygbh, int userid)
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
                ds = dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_BYBH", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }


        //待审批提示
        //查询奖励记录
        protected DataTable Select_YGJL_Pro_DSPTS(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };

                parament[0].Value = struct_YGJL.p_userid;
                parament[1].Value = struct_YGJL.p_pagesize;
                parament[2].Value = struct_YGJL.p_currentpage;
                parament[3].Direction = ParameterDirection.Output;


                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_Pro_DSPTS", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //查询奖励记录数量
        protected int Select_YGJL_Count_DSPTS(Struct_YGJL_Pro struct_YGJL)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };

                parament[0].Value = struct_YGJL.p_userid;
                parament[1].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_Count_DSPTS", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally { }
        }

        //数据导出
        protected DataTable Select_YGJL_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_KG_YGJL.Select_YGJL_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

    }
}
