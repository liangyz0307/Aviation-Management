using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys;
using CUST.MKG;
using System.Data;
using System.Data.OracleClient;
namespace CUST.WKG
{
    public struct Struct_SBBLK
    {
        public int p_id;
        public string p_sbmc;
        public string p_dd;
        public string p_sygw;
        public string p_syr;
        public string p_synx;
        public string p_gzsj;
        public string p_xx;
        public string p_yy;
        public string p_pgfs;
        public string p_pgsj;
        public string p_bypc;
        public string p_wxry;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
        public string p_bmdm;//数据所属部门
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_zt;//状态代码
        public string p_bhyy;//驳回原因
    }
    public struct Struct_Select_SBBLK
    {
        public int p_id;
        public string p_sbmc;
        public string p_dd;
        public string p_sygw;
        public string p_syr;
        public string p_synx;
        public string p_gzsj;
        public string p_xx;
        public string p_yy;
        public string p_pgfs;
        public string p_pgsj;
        public string p_bypc;
        public string p_wxry;
        public string p_bz;
        public int p_currentpage;
        public int p_pagesize;
        public string p_zt;//状态代码
        public string p_bhyy;//驳回原因
        public string p_bmdm;//数据所属部门
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

    public class OSBBLK
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;
        public OSBBLK(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region 查询
        /// <summary>
        /// 查询设备病例库表信息
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
        protected DataTable Select_SBBLK_Pro(Struct_Select_SBBLK struct_select_sbblk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_sbmc",OracleType.VarChar),
                    new OracleParameter("p_bypc",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = struct_select_sbblk.p_sbmc;
                paras[1].Value = struct_select_sbblk.p_bypc;
                paras[2].Value = struct_select_sbblk.p_userid;
                paras[3].Value = struct_select_sbblk.p_currentpage;
                paras[4].Value = struct_select_sbblk.p_pagesize;
                paras[5].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_SKJS_SBBLK.Select_SKJS_SBBLK_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询设备病例库数量
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>

        protected int Select_SBBLK_Count(Struct_Select_SBBLK struct_select_sbblk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_sbmc",OracleType.VarChar),
                    new OracleParameter("p_bypc",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = struct_select_sbblk.p_sbmc;
                paras[1].Value = struct_select_sbblk.p_bypc;
                paras[2].Value = struct_select_sbblk.p_userid;
                paras[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_SKJS_SBBLK.Select_SKJS_SBBLK_Count", paras, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 查询设备病例库详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected DataTable Select_SBBLK_Detail(int p_id)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_SKJS_SBBLK.Select_SKJS_SBBLK_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 根据员工编号查询员工姓名
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
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
                dt = db.RunProcedure("PACK_SKJS_SBBLK.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 根据部门岗位查询员工
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
        protected DataTable Select_YGbyBMGW(string p_bmdm,string p_gwdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = p_bmdm;
                paras[1].Value = p_gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_SKJS_SBBLK.Select_YGbyBMGW", paras, "tables").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sbblk"></param>
        /// <returns></returns>
        protected void Insert_SBBLK(Struct_SBBLK struct_sbblk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_sbmc",OracleType.VarChar),
                    new OracleParameter("p_dd",OracleType.VarChar),
                    new OracleParameter("p_sygw",OracleType.VarChar),
                    new OracleParameter("p_syr",OracleType.VarChar),
                    new OracleParameter("p_synx",OracleType.Number),
                    new OracleParameter("p_gzsj",OracleType.DateTime),
                    new OracleParameter("p_xx",OracleType.VarChar),
                    new OracleParameter("p_yy",OracleType.VarChar),
                    new OracleParameter("p_pgfs",OracleType.VarChar),
                    new OracleParameter("p_pgsj",OracleType.DateTime),
                    new OracleParameter("p_bypc",OracleType.VarChar),
                    new OracleParameter("p_wxry",OracleType.VarChar),
                    new OracleParameter("p_bz",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_sjbs",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = struct_sbblk.p_sbmc;
                paras[1].Value = struct_sbblk.p_dd;
                paras[2].Value = struct_sbblk.p_sygw;
                paras[3].Value = struct_sbblk.p_syr;
                paras[4].Value = struct_sbblk.p_synx;
                paras[5].Value = struct_sbblk.p_gzsj;
                paras[6].Value = struct_sbblk.p_xx;
                paras[7].Value = struct_sbblk.p_yy;
                paras[8].Value = struct_sbblk.p_pgfs;
                paras[9].Value = struct_sbblk.p_pgsj;
                paras[10].Value = struct_sbblk.p_bypc;
                paras[11].Value = struct_sbblk.p_wxry;
                paras[12].Value = struct_sbblk.p_bz;
                paras[13].Value = struct_sbblk.p_bmdm;
                paras[14].Value = struct_sbblk.p_csr;
                paras[15].Value = struct_sbblk.p_zsr;
                paras[16].Value = struct_sbblk.p_lrr;
                paras[17].Value = struct_sbblk.p_sjc;
                paras[18].Value = struct_sbblk.p_sjbs;
                paras[19].Value = struct_sbblk.p_zt;
                paras[20].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_SBBLK.Insert_SKJS_SBBLK_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[20].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_sbblk.p_czfs;
                struct_rz.czxx = struct_sbblk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除设备病例库表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected void Delete_SBBLK(int p_id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = p_id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_SBBLK.Delete_SKJS_SBBLK_Proc", paras, out rowsAffected);
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

        #region 修改
        /// <summary>
        /// 修改设备病例库表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected void Update_SBBLK(Struct_SBBLK struct_sbblk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_sbmc",OracleType.VarChar),
                    new OracleParameter("p_dd",OracleType.VarChar),
                    new OracleParameter("p_sygw",OracleType.VarChar),
                    new OracleParameter("p_syr",OracleType.VarChar),
                    new OracleParameter("p_synx",OracleType.Number),
                    new OracleParameter("p_gzsj",OracleType.DateTime),
                    new OracleParameter("p_xx",OracleType.VarChar),
                    new OracleParameter("p_yy",OracleType.VarChar),
                    new OracleParameter("p_pgfs",OracleType.VarChar),
                    new OracleParameter("p_pgsj",OracleType.DateTime),
                    new OracleParameter("p_bypc",OracleType.VarChar),
                    new OracleParameter("p_wxry",OracleType.VarChar),
                    new OracleParameter("p_bz",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),
                    
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value =Convert.ToInt32(struct_sbblk.p_id);
                paras[1].Value = struct_sbblk.p_sbmc;
                paras[2].Value = struct_sbblk.p_dd;
                paras[3].Value = struct_sbblk.p_sygw;
                paras[4].Value = struct_sbblk.p_syr;
                paras[5].Value = struct_sbblk.p_synx;
                paras[6].Value = struct_sbblk.p_gzsj;
                paras[7].Value = struct_sbblk.p_xx;
                paras[8].Value = struct_sbblk.p_yy;
                paras[9].Value = struct_sbblk.p_pgfs;
                paras[10].Value = struct_sbblk.p_pgsj;
                paras[11].Value = struct_sbblk.p_bypc;
                paras[12].Value = struct_sbblk.p_wxry;
                paras[13].Value = struct_sbblk.p_bz;
                paras[14].Value = struct_sbblk.p_bmdm;
                paras[15].Value = struct_sbblk.p_csr;
                paras[16].Value = struct_sbblk.p_zsr;
                paras[17].Value = struct_sbblk.p_lrr;
                
                paras[18].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_SBBLK.Update_SKJS_SBBLK_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[18].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_sbblk.p_czfs;
                struct_rz.czxx = struct_sbblk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion


        #region 变更状态
        protected void Update_SBBLKZT(Struct_Select_SBBLK struct_select_sbblk)
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
                paras[0].Value = struct_select_sbblk.p_id;
                paras[1].Value = struct_select_sbblk.p_zt;
                paras[2].Value = struct_select_sbblk.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_SBBLK.Update_SBBLKZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_select_sbblk.p_czfs;
                struct_rz.czxx = struct_select_sbblk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 变更数据标识
        protected void Update_SBBLK_SJBS_ZT(Struct_Select_SBBLK struct_select_sbblk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_select_sbblk.p_sjc;
                paras[1].Value = struct_select_sbblk.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_SBBLK.Update_SBBLK_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_select_sbblk.p_czfs;
                struct_rz.czxx = struct_select_sbblk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 将原最终数据变为历史数据
        protected void Update_SBBLK_SJBS_LSSJ_ZT(Struct_Select_SBBLK struct_select_sbblk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_select_sbblk.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_SBBLK.Update_SBBLK_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_select_sbblk.p_czfs;
                struct_rz.czxx = struct_select_sbblk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        #region 将副本数据变为最终数据
        protected void Update_SBBLK_SJBS_FBSJ_ZT(Struct_Select_SBBLK struct_select_sbblk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_select_sbblk.p_sjc;
                paras[1].Value = struct_select_sbblk.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_SBBLK.Update_SBBLK_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_select_sbblk.p_czfs;
                struct_rz.czxx = struct_select_sbblk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        #region 生成备份
        protected int SBBLK_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_SBBLK_Detail(id);
            //备份数据
            Struct_SBBLK sbblk_bf = new Struct_SBBLK();

            sbblk_bf.p_sbmc = dt_detail.Rows[0]["sbmc"].ToString();
            sbblk_bf.p_dd = dt_detail.Rows[0]["dd"].ToString();
            sbblk_bf.p_bypc = dt_detail.Rows[0]["bypc"].ToString();
            sbblk_bf.p_sygw = dt_detail.Rows[0]["sygw"].ToString();
            sbblk_bf.p_syr = dt_detail.Rows[0]["syr"].ToString();
            sbblk_bf.p_gzsj = Convert.ToDateTime(dt_detail.Rows[0]["gzsj"]).ToString("yyyy-MM-dd");
            sbblk_bf.p_synx = dt_detail.Rows[0]["synx"].ToString();
            sbblk_bf.p_xx = dt_detail.Rows[0]["xx"].ToString();
            sbblk_bf.p_yy = dt_detail.Rows[0]["yy"].ToString();
            sbblk_bf.p_pgfs = dt_detail.Rows[0]["pgfs"].ToString();
            sbblk_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            sbblk_bf.p_wxry = dt_detail.Rows[0]["wxry"].ToString();
            sbblk_bf.p_pgsj = Convert.ToDateTime(dt_detail.Rows[0]["pgsj"]).ToString("yyyy-MM-dd");
            sbblk_bf.p_zt = "0";
            sbblk_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            sbblk_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            sbblk_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            sbblk_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            sbblk_bf.p_lrr = _usState.userLoginName;
            sbblk_bf.p_sjbs = "2";
            sbblk_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            sbblk_bf.p_shsj = "";
            sbblk_bf.p_czfs = "02";
            sbblk_bf.p_czxx = "设备病例信息id:" + id + "生成副本数据";
            //插入
            Insert_SBBLK(sbblk_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = sbblk_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SKJS_SBBLK.Select_SBBLK_BFID", parament, out reslut);

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

