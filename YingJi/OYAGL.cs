using CUST;
using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Data;
namespace CUST.MKG
{
   
    //public struct Struct_Insert_Yj_Yagl
    //{
    //    public string p_mc;
    //    public string p_dq;
    //    public string p_zy;
    //    public string p_yanr;
    //    public string p_czfs;
    //    public string p_czxx;
    //}
    //public struct Struct_Update_Yj_Yagl
    //{
    //    public int p_id;
    //    public string p_mc;
    //    public string p_dq;
    //    public string p_zy;
    //    public string p_yanr;
    //    public string p_czfs;
    //    public string p_czxx;
    //}
    public struct Struct_YAGL
    {
        public int p_id;
        public string p_mc;
        public string p_dq;
        public string p_zy;
        public string p_yanr;
        public string p_czfs;
        public string p_czxx;
        public int p_pagesize;   //每页容量
        public int p_currentpage;//当前页
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bhyy;//驳回原因
        public string p_sjssbm;//数据所属部门
        public string p_zt;//状态
        public int p_userid;//用户id
    }
    public class OYAGL
    {
        private UserState _us = null;
        private RZ rz = null;
        public OYAGL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 添加
        protected void Insert_YJ_YAGL_Proc(Struct_YAGL struct_yagl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_mc",OracleType.VarChar),
                    new OracleParameter("p_dq",OracleType.VarChar),
                    new OracleParameter("p_zy",OracleType.VarChar),
                    new OracleParameter("p_yanr",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),//初审人
                    new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                    new OracleParameter("p_lrr",OracleType.VarChar),//录入人
                    new OracleParameter("p_sjc",OracleType.VarChar),//时间戳
                    new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识                       
                    new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                    new OracleParameter("p_zt",OracleType.VarChar),//状态
                    new OracleParameter("p_sjssbm",OracleType.VarChar),//数据所属部门
                    new OracleParameter("p_errorCode", OracleType.Int32)
               };
                paras[0].Value = struct_yagl.p_mc;
                paras[1].Value = struct_yagl.p_dq;
                paras[2].Value = struct_yagl.p_zy;
                paras[3].Value = struct_yagl.p_yanr;
                paras[4].Value = struct_yagl.p_csr;
                paras[5].Value = struct_yagl.p_zsr;
                paras[6].Value = struct_yagl.p_lrr;
                paras[7].Value = struct_yagl.p_sjc;
                paras[8].Value = struct_yagl.p_sjbs;
                paras[9].Value = struct_yagl.p_bhyy;
                paras[10].Value = struct_yagl.p_zt;
                paras[11].Value = struct_yagl.p_sjssbm;
                paras[12].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Insert_YJ_YAGL_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yagl.p_czfs;
                struct_rz.czxx = struct_yagl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);


            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 编辑
        protected void Update_YJ_YAGL_Proc(Struct_YAGL struct_yagl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.Int32),
                     new OracleParameter("p_mc",OracleType.VarChar),
                    new OracleParameter("p_dq",OracleType.VarChar),
                    new OracleParameter("p_zy",OracleType.VarChar),
                    new OracleParameter("p_yanr",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),//初审人
                    new OracleParameter("p_zsr",OracleType.VarChar),//终审人
                    new OracleParameter("p_lrr",OracleType.VarChar),//录入人                  
                    new OracleParameter("p_sjbs",OracleType.VarChar),//数据标识                       
                    new OracleParameter("p_bhyy",OracleType.VarChar),//驳回原因
                    new OracleParameter("p_zt",OracleType.VarChar),//状态
                    new OracleParameter("p_sjssbm",OracleType.VarChar),//数据所属部门
                    new OracleParameter("p_errorCode", OracleType.Int32)
                };
                paras[0].Value = struct_yagl.p_id;
                paras[1].Value = struct_yagl.p_mc;
                paras[2].Value = struct_yagl.p_dq;
                paras[3].Value = struct_yagl.p_zy;
                paras[4].Value = struct_yagl.p_yanr;
                paras[5].Value = struct_yagl.p_csr;
                paras[6].Value = struct_yagl.p_zsr;
                paras[7].Value = struct_yagl.p_lrr;               
                paras[8].Value = struct_yagl.p_sjbs;
                paras[9].Value = struct_yagl.p_bhyy;
                paras[10].Value = struct_yagl.p_zt;
                paras[11].Value = struct_yagl.p_sjssbm;
                paras[12].Direction= ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Update_YJ_YAGL_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yagl.p_czfs;
                struct_rz.czxx = struct_yagl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);


            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查找
        protected DataTable Select_YJ_YAGL_Proc(Struct_YAGL struct_yagl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras = 
                {
                    new OracleParameter("p_mc",OracleType.VarChar),
                    new OracleParameter("p_dq",OracleType.VarChar),
                    new OracleParameter("p_zy",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = struct_yagl.p_mc;
                paras[1].Value = struct_yagl.p_dq;
                paras[2].Value = struct_yagl.p_zy;
                paras[3].Value = struct_yagl.p_zt;
                paras[4].Value = struct_yagl.p_pagesize;
                paras[5].Value = struct_yagl.p_currentpage;
                paras[6].Value = struct_yagl.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt=dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Select_YJ_YAGL_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 删除
        protected void Delete_Yj_Yagl_Proc(string p_sjc, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_sjc",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHYJ_YAGL.Delete_Yj_Yagl_Proc", paras, out rowsAffected);
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
        #region 查找出预案表详情
        protected DataTable Select_Yj_Yagl_Detail_Proc(int p_id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_id",OracleType.Number),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = p_id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Select_Yj_Yagl_Detail_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查出预案表中的名称
        protected DataTable Select_Yj_Yagl_Mc_Proc()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Select_Yj_Yagl_Mc_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查出字典中的地区
        protected DataTable Select_Zd_Zxdm_Proc()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Select_Zd_Zxdm_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 查出字典中的专业
        protected DataTable Select_Zd_Zylx_Proc()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Select_Zd_Zylx_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 预案表中的数量
        protected int Select_Yj_Yagl_Count_Proc(Struct_YAGL struct_yagl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras =
                    {
                        new OracleParameter("p_mc",OracleType.VarChar),
                        new OracleParameter("p_dq",OracleType.VarChar),
                        new OracleParameter("p_zy",OracleType.VarChar),
                         new OracleParameter("p_zt",OracleType.VarChar),
                         new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
                   };
                paras[0].Value = struct_yagl.p_mc;
                paras[1].Value = struct_yagl.p_dq;
                paras[2].Value = struct_yagl.p_zy;
                paras[3].Value = struct_yagl.p_zt;
                paras[4].Value = struct_yagl.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Select_Yj_Yagl_Count_Proc", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 将副本数据变为最终数据
        protected void Update_YAGL_SJBS_FBSJ_ZT(Struct_YAGL struct_yagl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_yagl.p_sjc;
                paras[1].Value = struct_yagl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHYJ_YAGL.Update_YAGL_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yagl.p_czfs;
                struct_rz.czxx = struct_yagl.p_czxx;
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
        protected void Update_YAGLZT(Struct_YAGL struct_yagl)
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
                paras[0].Value = struct_yagl.p_id;
                paras[1].Value = struct_yagl.p_zt;
                paras[2].Value = struct_yagl.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHYJ_YAGL.Update_YAGLZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yagl.p_czfs;
                struct_rz.czxx = struct_yagl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //变更数据标识
        protected void Update_YAGL_SJBS_ZT(Struct_YAGL struct_yagl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_yagl.p_sjc;
                paras[1].Value = struct_yagl.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHYJ_YAGL.Update_YAGL_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yagl.p_czfs;
                struct_rz.czxx = struct_yagl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_YAGL_SJBS_LSSJ_ZT(Struct_YAGL struct_yagl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_yagl.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHYJ_YAGL.Update_YAGL_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_yagl.p_czfs;
                struct_rz.czxx = struct_yagl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        protected int YAGL_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_Yj_Yagl_Detail_Proc(id);
            //备份数据
            Struct_YAGL yagl_bf = new Struct_YAGL();
            yagl_bf.p_mc=dt_detail.Rows[0]["mc"].ToString();
            yagl_bf.p_dq=dt_detail.Rows[0]["dq"].ToString();
            yagl_bf.p_zy=dt_detail.Rows[0]["zy"].ToString();
            yagl_bf.p_yanr = dt_detail.Rows[0]["yanr"].ToString();
            yagl_bf.p_zt = "0";
            yagl_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            yagl_bf.p_sjssbm = dt_detail.Rows[0]["sjssbmdm"].ToString();
            yagl_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            yagl_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            yagl_bf.p_lrr = _us.userLoginName;
            yagl_bf.p_sjbs = "2";
            yagl_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
           // yagl_bf.p_shsj = "";
            yagl_bf.p_czfs = "02";
            yagl_bf.p_czxx = "员工奖励id:" + id + "生成副本数据";
            //插入
            Insert_YJ_YAGL_Proc(yagl_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = yagl_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_HWZHYJ_YAGL.Select_YAGL_BFID", parament, out reslut);

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
