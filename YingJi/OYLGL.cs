using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.MKG
{
    public struct Struct_YLGL
    {
        public int p_bh;
        public string p_zxmc;
        public string p_dq;
        public string p_yam;
        public DateTime p_ylsj;
        public string p_ylxs;
        public string p_cyry;
        public string p_ylnr;
        public string p_ylzj;
        public string p_czfs;
        public string p_czxx;
        public string p_yanr;
        public int p_pagesize;   //每页容量
        public int p_currentpage;//当前页
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bhyy;//驳回原因
        public string p_bmdm;//数据所属部门
        public string p_zt;//状态
        public int p_userid;//用户id
    }
    //public struct struct_ylgl
    //{
    //    public int p_bh;
    //    public string p_yam;
    //    public DateTime p_ylsj;
    //    public string p_ylxs;
    //    public string p_zxmc;
    //    public string p_cyry;
    //    public string p_ylnr;
    //    public string p_ylzj;
    //    public string p_yanr;
    //    public string p_czfs;
    //    public string p_czxx;

    //}

    //public struct struct_ylgl
    //{
    //    public string p_yam;
    //    public DateTime p_ylsj;
    //    public string p_ylxs;
    //    public string p_zxmc;
    //    public string p_cyry;
    //    public string p_ylnr;
    //    public string p_ylzj;
    //    public string p_czfs;
    //    public string p_czxx;
    //}
    //public struct struct_ylgl
    //{
    //    public string p_yam;
        
    //    public string p_ylxs;
    //    public int p_pagesize;//每页容量
    //    public int p_currentpage;//当前页码
    //}
    //public struct Struct_Ylgl_Count
    //{
    //    public string p_yam;
    //    public string p_dq;
    //    public string p_ylxs;
    //}
    public class OYLGL
    {
        private UserState _us = null;
        private RZ rz = null;
        public OYLGL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
       // public struct_ylgl struct_ylgl;
        public Struct_YLGL struct_ylgl;
       
        #region 查询演练
        protected DataTable Select_Ylgl(Struct_YLGL struct_ylgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                               new OracleParameter("p_yam",OracleType.NVarChar),
                                               new OracleParameter("p_dq",OracleType.VarChar),
                                               new OracleParameter("p_ylxs",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                paras[0].Value = struct_ylgl.p_yam;
                paras[1].Value = struct_ylgl.p_dq;
                paras[2].Value = struct_ylgl.p_ylxs;
                paras[3].Value = struct_ylgl.p_pagesize;
                paras[4].Value = struct_ylgl.p_currentpage;
                paras[5].Value = struct_ylgl.p_zt;
                paras[6].Value = struct_ylgl.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_YJ_YLGL.Select_YJ_YLGL", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
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
                dt = db.RunProcedure("PACK_YJ_YLGL.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 查询演练详情
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
                dt = dbclass.RunProcedure("PACK_YJ_YLGL.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查出预案表中的名称
        protected DataTable Select_Ylgl_Yam_Mc()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = _us.userID;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_YJ_YLGL.Select_YAMALL", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion
        #region 查出预案表中的名称
        protected DataTable Select_Ylgl_Cyry_Mc()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_YJ_YLGL.Select_Cyry", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion
        #region 删除演练
        protected void Delete_Ylgl(int p_bh, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_YJ_YLGL.Delete_Yl", paras, out rowsAffected);
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
        #region 编辑演练
        protected void Update_Yj_Ylgl(Struct_YLGL struct_ylgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bh",OracleType.Number),                     
                      new OracleParameter("p_zxmc",OracleType.VarChar),
                      new OracleParameter("p_ylxs",OracleType.VarChar),
                      new OracleParameter("p_cyry",OracleType.NVarChar),
                      new OracleParameter("p_ylsj",OracleType.DateTime),
                      new OracleParameter("p_ylnr",OracleType.NVarChar),
                      new OracleParameter("p_ylzj",OracleType.NVarChar),
                      
                    new OracleParameter("p_csr",OracleType.VarChar),//初审人
                    new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                    new OracleParameter("p_lrr",OracleType.VarChar),//录入人                  
                    new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识                       
                    new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                    new OracleParameter("p_zt",OracleType.VarChar),//状态
                    new OracleParameter("p_bmdm",OracleType.VarChar),//数据所属部门
                      new OracleParameter("p_errorCode",OracleType.Int32)
            };
                paras[0].Value = struct_ylgl.p_bh;             
                paras[1].Value = struct_ylgl.p_zxmc;
                paras[2].Value = struct_ylgl.p_ylxs;
                paras[3].Value = struct_ylgl.p_cyry;
                paras[4].Value = struct_ylgl.p_ylsj;
                paras[5].Value = struct_ylgl.p_ylnr;
                paras[6].Value = struct_ylgl.p_ylzj;              
                paras[7].Value = struct_ylgl.p_csr;
                paras[8].Value = struct_ylgl.p_zsr;
                paras[9].Value = struct_ylgl.p_lrr;
                paras[10].Value = struct_ylgl.p_sjbs;
                paras[11].Value = struct_ylgl.p_bhyy;
                paras[12].Value = struct_ylgl.p_zt;
                paras[13].Value = struct_ylgl.p_bmdm;
                paras[14].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_YJ_YLGL.Update_Ylgl", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[14].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ylgl.p_czfs;
                struct_rz.czxx = struct_ylgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 查询演练详情
        protected DataTable Select_Ylgl_Detail(int ylbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bh",OracleType.Number),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = ylbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_YJ_YLGL.Select_Yl_Bybh", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 插入演练
        protected void Insert_Yj_Ylgl(Struct_YLGL struct_ylgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_yam",OracleType.NVarChar),
                      new OracleParameter("p_zxmc",OracleType.VarChar),
                      new OracleParameter("p_ylxs",OracleType.VarChar),
                      new OracleParameter("p_cyry",OracleType.NVarChar),
                      new OracleParameter("p_ylsj",OracleType.DateTime),
                      new OracleParameter("p_ylnr",OracleType.NVarChar),
                      new OracleParameter("p_ylzj",OracleType.NVarChar),
                       new OracleParameter("p_csr",OracleType.VarChar),//初审人
                    new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                    new OracleParameter("p_lrr",OracleType.VarChar),//录入人
                    new OracleParameter("p_sjc",OracleType.VarChar),//时间戳
                    new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识                       
                    new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                    new OracleParameter("p_zt",OracleType.VarChar),//状态
                    new OracleParameter("p_bmdm",OracleType.VarChar),//数据所属部门
            };
                paras[0].Value = struct_ylgl.p_yam;
                paras[1].Value = struct_ylgl.p_zxmc;
                paras[2].Value = struct_ylgl.p_ylxs;
                paras[3].Value = struct_ylgl.p_cyry;
                paras[4].Value = struct_ylgl.p_ylsj;
                paras[5].Value = struct_ylgl.p_ylnr;
                paras[6].Value = struct_ylgl.p_ylzj;
                paras[7].Value = struct_ylgl.p_csr;
                paras[8].Value = struct_ylgl.p_zsr;
                paras[9].Value = struct_ylgl.p_lrr;
                paras[10].Value = struct_ylgl.p_sjc;
                paras[11].Value = struct_ylgl.p_sjbs;
                paras[12].Value = struct_ylgl.p_bhyy;
                paras[13].Value = struct_ylgl.p_zt;
                paras[14].Value = struct_ylgl.p_bmdm;
                int rowsAffected = 0;
                db.RunProcedure("PACK_YJ_YLGL.Insert_YL", paras, out rowsAffected);
               
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ylgl.p_czfs;
                struct_rz.czxx = struct_ylgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 查询演练数量
        protected int Select_YLGL_Count(Struct_YLGL struct_ylgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                               new OracleParameter("p_dq",OracleType.VarChar),
                                               new OracleParameter("p_yam",OracleType.VarChar),
                                               new OracleParameter("p_ylxs",OracleType.VarChar),
                                                new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                paras[0].Value = struct_ylgl.p_dq;
                paras[1].Value = struct_ylgl.p_yam;
                paras[2].Value = struct_ylgl.p_ylxs;
                paras[3].Value = struct_ylgl.p_zt;
                paras[4].Value = struct_ylgl.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_YJ_YLGL.Select_YJ_Count", paras, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        protected string YAMByKey(string p_sjc)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                               new OracleParameter("p_sjc",OracleType.VarChar) ,
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                paras[0].Value =p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                DataSet ds = db.RunProcedure("PACK_YJ_YLGL.Select_YAMbyID",paras,"table");
                return ds.Tables[0].Rows[0][0].ToString();
            }
            finally
            {
                db.Close();
            }

        }
        #region 将副本数据变为最终数据
        protected void Update_YAGL_SJBS_FBSJ_ZT(Struct_YLGL struct_ylgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_ylgl.p_sjc;
                paras[1].Value = struct_ylgl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_YJ_YLGL.Update_YLGL_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ylgl.p_czfs;
                struct_rz.czxx = struct_ylgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        //更改奖励状态
        #region 更新状态
        protected void Update_YLGLZT(Struct_YLGL struct_ylgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_bh",OracleType.Number),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_ylgl.p_bh;
                paras[1].Value = struct_ylgl.p_zt;
                paras[2].Value = struct_ylgl.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_YJ_YLGL.Update_YLGLZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ylgl.p_czfs;
                struct_rz.czxx = struct_ylgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //变更数据标识
        protected void Update_YLGL_SJBS_ZT(Struct_YLGL struct_ylgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_ylgl.p_sjc;
                paras[1].Value = struct_ylgl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_YJ_YLGL.Update_YLGL_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ylgl.p_czfs;
                struct_rz.czxx = struct_ylgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_YLGL_SJBS_LSSJ_ZT(Struct_YLGL struct_ylgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_ylgl.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_YJ_YLGL.Update_YLGL_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ylgl.p_czfs;
                struct_rz.czxx = struct_ylgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        protected int YLGL_SJBF(int bh)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_Ylgl_Detail(bh);
            //备份数据
            Struct_YLGL struct_ylgl = new Struct_YLGL();
            struct_ylgl.p_yam = dt_detail.Rows[0]["yam"].ToString();
            struct_ylgl.p_zxmc = dt_detail.Rows[0]["dq"].ToString();
            struct_ylgl.p_cyry = dt_detail.Rows[0]["cyry"].ToString();
            struct_ylgl.p_ylzj = dt_detail.Rows[0]["ylzj"].ToString();
            struct_ylgl.p_ylxs = dt_detail.Rows[0]["ylxs"].ToString();
            struct_ylgl.p_ylnr = dt_detail.Rows[0]["ylnr"].ToString();
            struct_ylgl.p_ylsj = Convert.ToDateTime(dt_detail.Rows[0]["ylsj"].ToString());
            struct_ylgl.p_zt = "0";
            struct_ylgl.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            struct_ylgl.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            struct_ylgl.p_csr = dt_detail.Rows[0]["csr"].ToString();
            struct_ylgl.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            struct_ylgl.p_lrr = _us.userLoginName;
            struct_ylgl.p_sjbs = "2";
            struct_ylgl.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            // struct_ylgl.p_shsj = "";
            struct_ylgl.p_czfs = "02";
            struct_ylgl.p_czxx = "员工奖励id:" + bh + "生成副本数据";
            //插入
            Insert_Yj_Ylgl(struct_ylgl);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfbh",OracleType.Int32)
                                             };
                parament[0].Value = struct_ylgl.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_YJ_YLGL.Select_YLGL_BFID", parament, out reslut);

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
