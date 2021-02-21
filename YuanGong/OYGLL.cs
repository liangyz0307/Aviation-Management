using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;
namespace CUST.MKG
{
    public struct Struct_YGLL
    {
        public long p_id;  //id
        public string p_ygbh;//员工编号
        public string p_gzdw;//工作单位
        public string p_gzbm;//工作部门
        public string p_gzgw;//工作岗位
        public string p_gzdd;//工作地点
        public string p_qzrq;//起始日期
        public string p_jzrq;//截止日期
        public string p_bz;//备注
        public string p_grjsda;
        public string p_ywpxda;
        public string p_aqjyda;
        public DateTime p_scsj;
        public string p_czfs;
        public string p_czxx;
        public string p_zt;//状态
        public int p_userid;
        public string p_bmdm;//部门代码
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bhyy;//驳回原因
    }
    public struct Struct_Select_YGLL
    {
        public string p_bh;//员工编号
        public string p_xm;//员工姓名
        public string p_bmdm;//部门代码
        public string p_gwdm;//岗位代码
        
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public int p_userid;
    }
    public class OYGLL
    {
        private UserState _us = null;
        private RZ rz = null;
        private UserState _usState;
        public OYGLL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询员工履历


        /// <summary>
        /// 查询员工履历表信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGLL_Pro(Struct_Select_YGLL ygll)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = ygll.p_bh;
                paras[1].Value = ygll.p_xm;
                paras[2].Value = ygll.p_bmdm;
                paras[3].Value = ygll.p_gwdm;
                paras[4].Value = ygll.p_userid;
                paras[5].Value = ygll.p_pagesize;
                paras[6].Value = ygll.p_currentpage;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGLL.Select_YGLL_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //普通员工履历查询
        protected DataTable Select_YGLL_Pro_Ptyg(Struct_Select_YGLL ygll)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = ygll.p_bh;
                paras[1].Value = ygll.p_xm;
                paras[2].Value = ygll.p_bmdm;
                paras[3].Value = ygll.p_gwdm;
                paras[4].Value = ygll.p_userid;
                paras[5].Value = ygll.p_pagesize;
                paras[6].Value = ygll.p_currentpage;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGLL.Select_YGLL_Pro_Ptyg", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        /// <summary>
        /// 查询员工履历数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_YGLLCount(Struct_Select_YGLL ygll)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_bh",OracleType.VarChar),
                        new OracleParameter("p_xm",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_gwdm",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = ygll.p_bh;
                paras[1].Value = ygll.p_xm;
                paras[2].Value = ygll.p_bmdm;
                paras[3].Value = ygll.p_gwdm;
                paras[4].Value = ygll.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_YGLL.Select_YGLLCount", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //普通员工履历数量查询
        protected int Select_YGLLCount_Ptyg(Struct_Select_YGLL ygll)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_bh",OracleType.VarChar),
                        new OracleParameter("p_xm",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_gwdm",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = ygll.p_bh;
                paras[1].Value = ygll.p_xm;
                paras[2].Value = ygll.p_bmdm;
                paras[3].Value = ygll.p_gwdm;
                paras[4].Value = ygll.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_YGLL.Select_YGLLCount_Ptyg", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 查询员工履历详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGLL_Detail(int id)
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
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGLL.Select_YGLL_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 查询员工履历管理详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGLLGL_Detail(long id)
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
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGLL.Select_YGLLGL_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 查询员工履历详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGLL_BYBH(string p_ygbh,int p_userid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bh",OracleType.Number),
                       new OracleParameter("p_userid",OracleType.Int32),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = p_ygbh;
                paras[1].Value = p_userid;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGLL.Select_YGLL_BYBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 删除


        /// <summary>
        /// 删除员工履历表
        /// </summary>
        /// <param name="bh"></param>
        protected void Delete_YGLL_byID(long id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_id",OracleType.Number),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Delete_YGLL_byID", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = p_czfs;
                struct_rz.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
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
        /// <summary>
        /// 根据员工编号删除员工履历表
        /// </summary>
        /// <param name="bh"></param>
        protected void Delete_YGLL_byBH(string p_bh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_bh",OracleType.Number),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_bh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Delete_YGLL_byBH", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = p_czfs;
                struct_rz.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  添加
        protected void Insert_YGLL(Struct_YGLL ygll)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_ygbh",OracleType.VarChar),                     
                        new OracleParameter("p_gzdw",OracleType.VarChar),
                        new OracleParameter("p_gzbm",OracleType.VarChar),
                        new OracleParameter("p_gzgw",OracleType.VarChar),
                        new OracleParameter("p_gzdd",OracleType.VarChar),
                        new OracleParameter("p_qzrq",OracleType.VarChar),
                        new OracleParameter("p_jzrq",OracleType.VarChar),
                        new OracleParameter("p_bz",OracleType.VarChar),
                        new OracleParameter("p_csr",OracleType.VarChar),//初审人
                        new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                        new OracleParameter("p_lrr",OracleType.VarChar),//录入人
                        new OracleParameter("p_sjc",OracleType.VarChar),//时间戳
                        new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识
                       
                        new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                        new OracleParameter("p_zt",OracleType.VarChar),//状态
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = ygll.p_ygbh;             
                paras[1].Value = ygll.p_gzdw;
                paras[2].Value = ygll.p_gzbm;
                paras[3].Value = ygll.p_gzgw;
                paras[4].Value = ygll.p_gzdd;
                paras[5].Value = ygll.p_qzrq;
                paras[6].Value = ygll.p_jzrq;
                paras[7].Value = ygll.p_bz;
                paras[8].Value = ygll.p_csr;
                paras[9].Value = ygll.p_zsr;
                paras[10].Value = ygll.p_lrr;
                paras[11].Value = ygll.p_sjc;
                paras[12].Value = ygll.p_sjbs;
                paras[13].Value = ygll.p_bhyy;
                paras[14].Value = ygll.p_zt;
                paras[15].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Insert_YGLL", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[15].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygll.p_czfs;
                struct_rz.czxx = ygll.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑
        protected void Update_YGLL(Struct_YGLL ygll)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Number),
                  new OracleParameter("p_ygbh",OracleType.VarChar),
                  new OracleParameter("p_bmdm",OracleType.VarChar),
                  new OracleParameter("p_gzdw",OracleType.VarChar),
                  new OracleParameter("p_gzbm",OracleType.VarChar),
                  new OracleParameter("p_gzgw",OracleType.VarChar),
                  new OracleParameter("p_gzdd",OracleType.VarChar),
                  new OracleParameter("p_qzrq",OracleType.VarChar),
                  new OracleParameter("p_jzrq",OracleType.VarChar),
                  new OracleParameter("p_bz",OracleType.VarChar),
                  new OracleParameter("p_csr",OracleType.VarChar),
                  new OracleParameter("p_zsr",OracleType.VarChar),
                  new OracleParameter("p_lrr",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_sjbs",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = ygll.p_id;
                paras[1].Value = ygll.p_ygbh;
                paras[2].Value = ygll.p_bmdm;
                paras[3].Value = ygll.p_gzdw;
                paras[4].Value = ygll.p_gzbm;
                paras[5].Value = ygll.p_gzgw;
                paras[6].Value = ygll.p_gzdd;
                paras[7].Value = ygll.p_qzrq;
                paras[8].Value = ygll.p_jzrq;
                paras[9].Value = ygll.p_bz;
                paras[10].Value = ygll.p_csr;
                paras[11].Value = ygll.p_zsr;
                paras[12].Value = ygll.p_lrr;
                paras[13].Value = ygll.p_zt;
                paras[14].Value = ygll.p_sjbs;
                paras[15].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Update_YGLL", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[15].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygll.p_czfs;
                struct_rz.czxx = ygll.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 更新状态
        protected void Update_ygll_ZT(long id, string zt, string bhyy)
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
                paras[0].Value = id;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Update_ygll_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                //Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                //struct_rz.czfs = ygll.p_czfs;
                //struct_rz.czxx = ygll.p_czxx;
                //rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        //变更数据标识
        protected void Update_YGLL_SJBS_ZT(Struct_YGLL ygll)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygll.p_sjc;
                paras[1].Value = ygll.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Update_YGLL_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygll.p_czfs;
                struct_rz.czxx = ygll.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_YGLL_SJBS_LSSJ_ZT(Struct_YGLL ygll)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygll.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Update_YGLL_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygll.p_czfs;
                struct_rz.czxx = ygll.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 将副本数据变为最终数据
        protected void Update_YGLL_SJBS_FBSJ_ZT(Struct_YGLL ygll)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygll.p_sjc;
                paras[1].Value = ygll.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGLL.Update_YGLL_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygll.p_czfs;
                struct_rz.czxx = ygll.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        protected int YGLL_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_YGLLGL_Detail(id);
            //备份数据
            Struct_YGLL ygll_bf = new Struct_YGLL();

            ygll_bf.p_qzrq = dt_detail.Rows[0]["qzrq"].ToString();
            ygll_bf.p_jzrq = dt_detail.Rows[0]["jzrq"].ToString();
            ygll_bf.p_gzdw = dt_detail.Rows[0]["gzdw"].ToString();
            ygll_bf.p_gzbm = dt_detail.Rows[0]["gzbm"].ToString();
            ygll_bf.p_gzgw = dt_detail.Rows[0]["gzgw"].ToString();
            ygll_bf.p_gzdd = dt_detail.Rows[0]["gzdd"].ToString();
            ygll_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            ygll_bf.p_ygbh = dt_detail.Rows[0]["ygbh"].ToString();
          
            ygll_bf.p_zt = "0";
            ygll_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            ygll_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            ygll_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            ygll_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            ygll_bf.p_lrr = _us.userLoginName;
            ygll_bf.p_sjbs = "2";
            ygll_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            ygll_bf.p_shsj = "";
            ygll_bf.p_czfs = "02";
            ygll_bf.p_czxx = "员工履历id:" + id + "生成副本数据";
            //插入
            Insert_YGLL(ygll_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = ygll_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGLL.Select_YGLL_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }


    }

}
