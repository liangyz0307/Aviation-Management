using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_ZJK_Pro
    {
        public int p_id;
        public string p_xm;//姓名
        public string p_zjlx;//专家类型
        public string p_zd;//驻地
        public string p_csgz;//从事工作
        public string p_zy;//专业
        public string p_zc;//专长
        public string p_lxfs;//联系方式
        public string p_bmdm;//部门    
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
     public class OZJK
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState;
        private RZ rz;

        public OZJK(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }

        protected DataTable Select_ZJK_Pro(Struct_ZJK_Pro struct_zjk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_xm",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zjlx",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_pagesize",OracleType.Int32),
                                                 new OracleParameter("p_currentpage",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_zjk.p_xm;
                parament[1].Value = struct_zjk.p_bmdm;
                parament[2].Value = struct_zjk.p_zjlx;
                parament[3].Value = struct_zjk.p_zt;
                parament[4].Value = struct_zjk.p_userid;
                parament[5].Value = struct_zjk.p_pagesize;
                parament[6].Value = struct_zjk.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;


                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_ZJK.Select_ZJK_Pro", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_ZJK_Count(Struct_ZJK_Pro struct_zjk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_xm",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zjlx",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = struct_zjk.p_xm;
                parament[1].Value = struct_zjk.p_bmdm;
                parament[2].Value = struct_zjk.p_zjlx;
                parament[3].Value = struct_zjk.p_zt;
                parament[4].Value = struct_zjk.p_userid;
                parament[5].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_ZJK.Select_ZJK_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally { }
        }
        protected DataTable Select_ZJK_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_KG_ZJK.Select_ZJK_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_ZJK(Struct_ZJK_Pro struct_zjk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_xm",OracleType.VarChar),
                                                 new OracleParameter("p_zjlx",OracleType.VarChar),
                                                 new OracleParameter("p_zd",OracleType.VarChar),
                                                 new OracleParameter("p_csgz",OracleType.VarChar),
                                                 new OracleParameter("p_zy",OracleType.VarChar),
                                                 new OracleParameter("p_zc",OracleType.VarChar),
                                                 new OracleParameter("p_lxfs",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_zjk.p_id;
                parament[1].Value = struct_zjk.p_xm;
                parament[2].Value = struct_zjk.p_zjlx;
                parament[3].Value = struct_zjk.p_zd;
                parament[4].Value = struct_zjk.p_csgz;
                parament[5].Value = struct_zjk.p_zy;
                parament[6].Value = struct_zjk.p_zc;
                parament[7].Value = struct_zjk.p_lxfs;
                parament[8].Value = struct_zjk.p_bmdm;
                parament[9].Value = struct_zjk.p_csr;
                parament[10].Value = struct_zjk.p_zsr;
                parament[11].Value = struct_zjk.p_lrr;
                parament[12].Value = struct_zjk.p_sjc;
                parament[13].Value = struct_zjk.p_sjbs;
                parament[14].Value = struct_zjk.p_zt;
                parament[15].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZJK.Insert_ZJK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[15].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_zjk.p_czfs;
                struct_RZ_YH.czxx = struct_zjk.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_ZJK(Struct_ZJK_Pro struct_zjk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Number),
                                                 new OracleParameter("p_xm",OracleType.VarChar),
                                                 new OracleParameter("p_zjlx",OracleType.VarChar),
                                                 new OracleParameter("p_zd",OracleType.VarChar),
                                                 new OracleParameter("p_csgz",OracleType.VarChar),
                                                 new OracleParameter("p_zy",OracleType.VarChar),
                                                 new OracleParameter("p_zc",OracleType.VarChar),
                                                 new OracleParameter("p_lxfs",OracleType.VarChar),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_zjk.p_id;
                parament[1].Value = struct_zjk.p_xm;
                parament[2].Value = struct_zjk.p_zjlx;
                parament[3].Value = struct_zjk.p_zd;
                parament[4].Value = struct_zjk.p_csgz;
                parament[5].Value = struct_zjk.p_zy;
                parament[6].Value = struct_zjk.p_zc;
                parament[7].Value = struct_zjk.p_lxfs;
                parament[8].Value = struct_zjk.p_bmdm;
                parament[9].Value = struct_zjk.p_csr;
                parament[10].Value = struct_zjk.p_zsr;
                parament[11].Value = struct_zjk.p_lrr;
                
                parament[12].Value = struct_zjk.p_sjbs;
                parament[13].Value = struct_zjk.p_zt;
                parament[14].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZJK.Update_ZJK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[14].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

                //日志
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_zjk.p_czfs;
                struct_RZ_YH.czxx = struct_zjk.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_ZJK(int id, string p_czfs, string p_czxx)
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
                dbclass.RunProcedure("PACK_KG_ZJK.Delete_ZJK", parament, out result);

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

        protected void Update_ZJKZT(Struct_ZJK_Pro zjk)
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
                paras[0].Value = zjk.p_id;
                paras[1].Value = zjk.p_zt;
                paras[2].Value = zjk.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ZJK.Update_ZJKZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zjk.p_czfs;
                struct_rz.czxx = zjk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected void Update_ZJK_SJBS_ZT(Struct_ZJK_Pro zjk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = zjk.p_sjc;
                paras[1].Value = zjk.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ZJK.Update_ZJK_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zjk.p_czfs;
                struct_rz.czxx = zjk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected void Update_ZJK_SJBS_LSSJ_ZT(Struct_ZJK_Pro zjk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = zjk.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ZJK.Update_ZJK_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zjk.p_czfs;
                struct_rz.czxx = zjk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected void Update_ZJK_SJBS_FBSJ_ZT(Struct_ZJK_Pro zjk)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = zjk.p_sjc;
                paras[1].Value = zjk.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ZJK.Update_ZJK_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = zjk.p_czfs;
                struct_rz.czxx = zjk.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected int ZJK_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_ZJK_Detail(id);
            //备份数据
            Struct_ZJK_Pro zjk_bf = new Struct_ZJK_Pro();


            zjk_bf.p_xm = dt_detail.Rows[0]["xm"].ToString();
            zjk_bf.p_zjlx = dt_detail.Rows[0]["zjlx"].ToString();
            zjk_bf.p_zd = dt_detail.Rows[0]["zd"].ToString();
            zjk_bf.p_csgz = dt_detail.Rows[0]["csgz"].ToString();
            zjk_bf.p_zy = dt_detail.Rows[0]["zy"].ToString();
            zjk_bf.p_zc = dt_detail.Rows[0]["zc"].ToString();
            zjk_bf.p_lxfs = dt_detail.Rows[0]["lxfs"].ToString();
            zjk_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            zjk_bf.p_zt = "0";
            zjk_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            zjk_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            zjk_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            zjk_bf.p_lrr = _usState.userLoginName;
            zjk_bf.p_sjbs = "2";
            zjk_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            zjk_bf.p_shsj = "";
            zjk_bf.p_czfs = "02";
            zjk_bf.p_czxx = "专家信息id:" + id + "生成副本数据";
            //插入
            Insert_ZJK(zjk_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = zjk_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_ZJK.Select_ZJK_BFID", parament, out reslut);

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
