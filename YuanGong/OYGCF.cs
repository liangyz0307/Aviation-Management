using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;
using CUST.MKG;

namespace CUST.MKG
{
    public struct Struct_YGCF
    {
        public int p_id;//惩罚编号
        public DateTime p_kssj;//开始事件
        public DateTime p_jssj;//结束时间
        public string p_sfr;//受罚人
        public string p_sjzl;//事件种类
        public string p_jyjlhyy;//简要经历和原因
        public string p_cdzr;//承担责任
        public string p_clyj;//处理意见
        public string p_fzr;//负责人
        public string p_zt;//状态代码
        public string p_czfs;//操作方式
        public string p_bhyy;//驳回原因
        public string p_czxx;//操作信息
        public string p_bmdm;//部门\
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间 
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public int p_userid;
    }
    public class OYGCF
    {
        private UserState _us = null;
        private RZ rz = null;
        public OYGCF(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }


        #region 查询员工惩罚
        /// <summary>
        /// 查询员工惩罚信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGCF_Pro(Struct_YGCF ygcf)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                                  new OracleParameter("p_kssj",OracleType.DateTime),
                                                  new OracleParameter("p_jssj",OracleType.DateTime),
                                                  new OracleParameter("p_sfr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_sjzl",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygcf.p_kssj;
                parament[1].Value = ygcf.p_jssj;
                parament[2].Value = ygcf.p_sfr;
                parament[3].Value = ygcf.p_bmdm;
                parament[4].Value = ygcf.p_sjzl;
                parament[5].Value = ygcf.p_zt;
                parament[6].Value = ygcf.p_userid;
                parament[7].Value = ygcf.p_pagesize;
                parament[8].Value = ygcf.p_currentpage;
                parament[9].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGCF.Select_YGCF_Pro", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        /// <summary>
        /// 查询员工惩罚数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_YGCF_Count(Struct_YGCF ygcf)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                                  new OracleParameter("p_kssj",OracleType.DateTime),
                                                  new OracleParameter("p_jssj",OracleType.DateTime),
                                                  new OracleParameter("p_sfr",OracleType.VarChar),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_sjzl",OracleType.VarChar),
                                                  new OracleParameter("p_zt",OracleType.VarChar),
                                                   new OracleParameter("p_userid",OracleType.Int32),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygcf.p_kssj;
                parament[1].Value = ygcf.p_jssj;
                parament[2].Value = ygcf.p_sfr;
                parament[3].Value = ygcf.p_bmdm;
                parament[4].Value = ygcf.p_sjzl;
                parament[5].Value = ygcf.p_zt;
                parament[6].Value = ygcf.p_userid;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_YGCF.Select_YGCF_Count", parament, "tables");
                int count=Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                db.Close();
            }
        }



        #region 通过编号查询员工姓名
        protected DataTable Select_YGXMbyBH(string p_bh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_bh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_KG_YGCF.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion



        #region 通过部门岗位查询员工
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
                dt = dbclass.RunProcedure("PACK_KG_YGCF.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion




        #region 查询惩罚详情
        protected DataTable Select_YGCF_Detail(int id)
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
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGCF.Select_YGCF_Detail ", parament, "table").Tables[0];
                //int returnCode = Convert.ToInt32(parament[1].Value);
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        protected void Insert_YGCF(Struct_YGCF ygcf)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_kssj",OracleType.DateTime),
                                                   new OracleParameter("p_sfr",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_sjzl",OracleType.VarChar),
                                                   new OracleParameter("p_jyjlhyy",OracleType.VarChar),
                                                   new OracleParameter("p_cdzr",OracleType.VarChar),
                                                   new OracleParameter("p_clyj",OracleType.VarChar),
                                                   new OracleParameter("p_fzr",OracleType.VarChar),
                                                   new OracleParameter("p_csr",OracleType.VarChar),
                                                   new OracleParameter("p_zsr",OracleType.VarChar),
                                                   new OracleParameter("p_lrr",OracleType.VarChar),
                                                   new OracleParameter("p_sjc",OracleType.VarChar),
                                                   new OracleParameter("p_sjbs",OracleType.VarChar),
                                                   new OracleParameter("p_zt",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = ygcf.p_kssj;
                parament[1].Value = ygcf.p_sfr;
                parament[2].Value = ygcf.p_bmdm;
                parament[3].Value = ygcf.p_sjzl;
                parament[4].Value = ygcf.p_jyjlhyy;
                parament[5].Value = ygcf.p_cdzr;
                parament[6].Value = ygcf.p_clyj;
                parament[7].Value = ygcf.p_fzr;
                parament[8].Value = ygcf.p_csr;
                parament[9].Value = ygcf.p_zsr;
                parament[10].Value = ygcf.p_lrr;
                parament[11].Value = ygcf.p_sjc;
                parament[12].Value = ygcf.p_sjbs;
                parament[13].Value = ygcf.p_zt;
                parament[14].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGCF.Insert_YGCF", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[14].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygcf.p_czfs;
                struct_rz.czxx = ygcf.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }

        #region 修改
        protected void Update_YGCF(Struct_YGCF ygcf)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.Number),
                                                   new OracleParameter("p_kssj",OracleType.DateTime),
                                                   new OracleParameter("p_sfr",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_sjzl",OracleType.VarChar),
                                                   new OracleParameter("p_jyjlhyy",OracleType.VarChar),
                                                   new OracleParameter("p_cdzr",OracleType.VarChar),
                                                   new OracleParameter("p_clyj",OracleType.VarChar),
                                                   new OracleParameter("p_fzr",OracleType.VarChar),
                                                   new OracleParameter("p_zt",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = ygcf.p_id;
                parament[1].Value = ygcf.p_kssj;
                parament[2].Value = ygcf.p_sfr;
                parament[3].Value = ygcf.p_bmdm;
                parament[4].Value = ygcf.p_sjzl;
                parament[5].Value = ygcf.p_jyjlhyy;
                parament[6].Value = ygcf.p_cdzr;
                parament[7].Value = ygcf.p_clyj;
                parament[8].Value = ygcf.p_fzr;
                parament[9].Value = ygcf.p_zt;
                parament[10].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGCF.Update_YGCF", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[10].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygcf.p_czfs;
                struct_rz.czxx = ygcf.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion


        #region 更新状态
        protected void Update_YGCFZT(Struct_YGCF ygcf)
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
                paras[0].Value = ygcf.p_id;
                paras[1].Value = ygcf.p_zt;
                paras[2].Value = ygcf.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGCF.Update_YGCFZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygcf.p_czfs;
                struct_rz.czxx = ygcf.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }


                //变更数据标识
        protected void Update_YGCF_SJBS_ZT(Struct_YGCF ygcf)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                
                paras[0].Value = ygcf.p_sjc;
                paras[1].Value = ygcf.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGCF.Update_YGCF_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygcf.p_czfs;
                struct_rz.czxx = ygcf.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_YGCF_SJBS_LSSJ_ZT(Struct_YGCF ygcf)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygcf.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGCF.Update_YGCF_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygcf.p_czfs;
                struct_rz.czxx = ygcf.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }




        #region 将副本数据变为最终数据
        protected void Update_YGCF_SJBS_FBSJ_ZT(Struct_YGCF ygcf)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygcf.p_sjc;
                paras[1].Value = ygcf.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGCF.Update_YGCF_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygcf.p_czfs;
                struct_rz.czxx = ygcf.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        #endregion

        #region 删除

        /// <summary>
        /// 删除员工惩罚
        /// </summary>
        /// <param name="bh"></param>
        protected void Delete_YGCF(int id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Number),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = id; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGCF.Delete_YGCF_byID", parament, out reslut);

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
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion


        protected int YGCF_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_YGCF_Detail(id);
            //备份数据
            Struct_YGCF ygcf_bf = new Struct_YGCF();

            ygcf_bf.p_kssj = Convert.ToDateTime(dt_detail.Rows[0]["cfsj"].ToString());
        //    ygcf_bf.p_jssj = Convert.ToDateTime(dt_detail.Rows[0]["rq"].ToString());
            ygcf_bf.p_sfr = dt_detail.Rows[0]["sfr"].ToString();
            ygcf_bf.p_sjzl = dt_detail.Rows[0]["sjzl"].ToString();
            ygcf_bf.p_jyjlhyy = dt_detail.Rows[0]["jyjlhyy"].ToString();
            ygcf_bf.p_cdzr = dt_detail.Rows[0]["cdzr"].ToString();
            ygcf_bf.p_clyj = dt_detail.Rows[0]["clyj"].ToString();
            ygcf_bf.p_fzr = dt_detail.Rows[0]["fzr"].ToString();
            ygcf_bf.p_zt = "0";
            ygcf_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            ygcf_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            ygcf_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            ygcf_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            ygcf_bf.p_lrr = _us.userLoginName;
            ygcf_bf.p_sjbs = "2";
            ygcf_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            ygcf_bf.p_shsj = "";
            ygcf_bf.p_czfs = "02";
            ygcf_bf.p_czxx = "员工惩罚id:" + id + "生成副本数据";
            //插入
            Insert_YGCF(ygcf_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = ygcf_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGCF.Select_YGCF_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //
        public new DataTable Select_YGCF_BYBH(string ygbh, int userid)
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
                ds = dbclass.RunProcedure("PACK_KG_YGCF.Select_YGCF_BYBH", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //数据导出
        protected DataTable Select_YGCF_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_KG_YGCF.Select_YGCF_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


    }
}


        #endregion

