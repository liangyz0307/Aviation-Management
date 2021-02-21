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
    public struct Struct_BJ
    {
        public int p_id;
        public string p_bjbh;
        public string p_bjmc;
        public string p_sbxh;
        public string p_bjfl;
        public string p_bjzwmc;
        public string p_nhzj;
        public string p_nhzjmc;
        public string p_ywmc;
        public string p_yjsl;
        public string p_bjsbh;
        public string p_sy;
        public string p_xybjsl;
        public string p_cfwz;
        public string p_bz;
        public string p_zxdm;
        public string p_czfs;
        public string p_czxx;
        public string p_bjzt;
        public string p_zt;
        public string p_bhyy;
        public string p_bmdm;
        public int p_pagesize;
        public int p_currentpage;
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_sl;//数量
        public string p_czlx;//操作类型
        public DateTime p_czsj;//操作时间
        public string p_czsl;//操作数量
    }
    public struct Struct_BJCK
    {
        public string p_id;
        public string p_bjbh;
        public string p_cfwz;
        public string p_ckjbr;
        public string p_kffzr;
        public int p_cksl;
        public DateTime p_cksj;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public string p_bjfl;
        public string p_sy;
        public string p_jbrbm;
        public string p_jbrgw;
        public string p_fzrbm;
        public string p_fzrgw;
        public string p_czfs;
        public string p_czxx;
        public string p_zxdm;
        public string p_bz;

        public string p_bmdm;
        public string p_jbrxm;
        public string p_fzrxm;
        public string p_bhyy;
        public string p_zt;
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public int p_pagesize;
        public int p_currentpage;


    }
    public struct Struct_BJRK
    {
        public string p_id;
        public string p_bjbh;
        public string p_cfwz;
        public string p_rkjbr;
        public string p_kffzr;
        public int p_rksl;
        public DateTime p_rksj;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public string p_bjfl;
        public string p_sy;
        public string p_jbrbm;
        public string p_jbrgw;
        public string p_fzrbm;
        public string p_fzrgw;
        public string p_czfs;
        public string p_czxx;
        public string p_bz;
        public string p_zxdm;
        public int p_pagesize;
        public int p_currentpage;
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_zt;
        public string p_bhyy;
        public string p_bmdm;
        public string p_jbrxm;
        public string p_fzrxm;
    }
    public class OBJ
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private RZ rz;
        private UserState _us = null;
        public OBJ(UserState state)
        {
            _us = state;
            rz = new RZ(_us);
        }


        #region  ===============备件================


        protected DataSet Select_Max_BJBH(string p_lx_zl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_lx_zl",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_lx_zl;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_Max_BJBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataSet Select_BJ_Pro(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjbh",OracleType.VarChar),
                                               new OracleParameter("p_bjmc",OracleType.VarChar),
                                               new OracleParameter("p_sbxh",OracleType.VarChar),
                                               new OracleParameter("p_bjfl",OracleType.VarChar),
                                               new OracleParameter("p_sy",OracleType.VarChar),
                                               new OracleParameter("p_zxdm",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BJ.p_bjbh;
                parament[1].Value = struct_BJ.p_bjmc;
                parament[2].Value = struct_BJ.p_sbxh;
                parament[3].Value = struct_BJ.p_bjfl;
                parament[4].Value = struct_BJ.p_sy;
                parament[5].Value = struct_BJ.p_zxdm;
                parament[6].Value = struct_BJ.p_zt;
                parament[7].Value = struct_BJ.p_userid;
                parament[8].Value = struct_BJ.p_pagesize;
                parament[9].Value = struct_BJ.p_currentpage;
                parament[10].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJ_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BJbyBJBH(int p_id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJbyBJBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BJ_Count(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                              new OracleParameter("p_bjbh",OracleType.VarChar),
                                               new OracleParameter("p_bjmc",OracleType.VarChar),
                                               new OracleParameter("p_sbxh",OracleType.VarChar),
                                               new OracleParameter("p_bjfl",OracleType.VarChar),
                                               new OracleParameter("p_sy",OracleType.VarChar),
                                               new OracleParameter("p_zxdm",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BJ.p_bjbh;
                parament[1].Value = struct_BJ.p_bjmc;
                parament[2].Value = struct_BJ.p_sbxh;
                parament[3].Value = struct_BJ.p_bjfl;
                parament[4].Value = struct_BJ.p_sy;
                parament[5].Value = struct_BJ.p_zxdm;
                parament[6].Value = struct_BJ.p_zt;
                parament[7].Value = struct_BJ.p_userid;
                parament[8].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJ_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_BJ(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                    new OracleParameter("p_bjbh",OracleType.VarChar),
                                                       new OracleParameter("p_bjmc",OracleType.VarChar),
                                                       new OracleParameter("p_sbxh",OracleType.VarChar),
                                                       new OracleParameter("p_bjfl",OracleType.VarChar),
                                                       new OracleParameter("p_bjzwmc",OracleType.VarChar),
                                                       new OracleParameter("p_nhzj",OracleType.VarChar),
                                                       new OracleParameter("p_nhzjmc",OracleType.VarChar),
                                                       new OracleParameter("p_ywmc",OracleType.VarChar),
                                                       new OracleParameter("p_yjsl",OracleType.Number),
                                                       new OracleParameter("p_bjsbh",OracleType.VarChar),
                                                       new OracleParameter("p_sy",OracleType.VarChar),
                                                       new OracleParameter("p_xybjsl",OracleType.Number),
                                                       new OracleParameter("p_cfwz",OracleType.VarChar),
                                                       new OracleParameter("p_bz",OracleType.VarChar),
                                                       new OracleParameter("p_zxdm",OracleType.VarChar),


                                                      new OracleParameter("p_csr",OracleType.VarChar),
                                                      new OracleParameter("p_zsr",OracleType.VarChar),
                                                      new OracleParameter("p_lrr",OracleType.VarChar),
                                                      new OracleParameter("p_sjc",OracleType.VarChar),
                                                      new OracleParameter("p_sjbs",OracleType.VarChar),
                                                      new OracleParameter("p_zt",OracleType.VarChar),
                                                      new OracleParameter("p_bmdm",OracleType.VarChar),

                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJ.p_bjbh;
                parament[1].Value = struct_BJ.p_bjmc;
                parament[2].Value = struct_BJ.p_sbxh;
                parament[3].Value = struct_BJ.p_bjfl;
                parament[4].Value = struct_BJ.p_bjzwmc;
                parament[5].Value = struct_BJ.p_nhzj;
                parament[6].Value = struct_BJ.p_nhzjmc;
                parament[7].Value = struct_BJ.p_ywmc;
                parament[8].Value = struct_BJ.p_yjsl;
                parament[9].Value = struct_BJ.p_bjsbh;
                parament[10].Value = struct_BJ.p_sy;
                parament[11].Value = struct_BJ.p_xybjsl;
                parament[12].Value = struct_BJ.p_cfwz;
                parament[13].Value = struct_BJ.p_bz;
                parament[14].Value = struct_BJ.p_zxdm;

                parament[15].Value = struct_BJ.p_csr;
                parament[16].Value = struct_BJ.p_zsr;
                parament[17].Value = struct_BJ.p_lrr;
                parament[18].Value = struct_BJ.p_sjc;
                parament[19].Value = struct_BJ.p_sjbs;
                parament[20].Value = struct_BJ.p_zt;
                parament[21].Value = struct_BJ.p_bmdm;
                parament[22].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Insert_BJ", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[22].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_BJ.p_czfs;
                struct_RZ_YH.czxx = struct_BJ.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_BJ(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bjbh",OracleType.VarChar),
                                                       new OracleParameter("p_bjmc",OracleType.VarChar),
                                                       new OracleParameter("p_sbxh",OracleType.VarChar),
                                                       new OracleParameter("p_bjfl",OracleType.VarChar),
                                                       new OracleParameter("p_bjzwmc",OracleType.VarChar),
                                                       new OracleParameter("p_nhzj",OracleType.VarChar),
                                                       new OracleParameter("p_nhzjmc",OracleType.VarChar),
                                                       new OracleParameter("p_ywmc",OracleType.VarChar),
                                                       new OracleParameter("p_yjsl",OracleType.VarChar),
                                                       new OracleParameter("p_bjsbh",OracleType.VarChar),
                                                       new OracleParameter("p_sy",OracleType.VarChar),
                                                       new OracleParameter("p_xybjsl",OracleType.VarChar),
                                                       new OracleParameter("p_cfwz",OracleType.VarChar),
                                                       new OracleParameter("p_bz",OracleType.VarChar),
                                                       new OracleParameter("p_zxdm",OracleType.VarChar),

                                                      new OracleParameter("p_csr",OracleType.VarChar),
                                                      new OracleParameter("p_zsr",OracleType.VarChar),
                                                      new OracleParameter("p_lrr",OracleType.VarChar),
                                                      new OracleParameter("p_sjbs",OracleType.VarChar),
                                                      new OracleParameter("p_zt",OracleType.VarChar),
                                                      new OracleParameter("p_bmdm",OracleType.VarChar),

                                                      new OracleParameter("p_id",OracleType.Number),

                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJ.p_bjbh;
                parament[1].Value = struct_BJ.p_bjmc;
                parament[2].Value = struct_BJ.p_sbxh;
                parament[3].Value = struct_BJ.p_bjfl;
                parament[4].Value = struct_BJ.p_bjzwmc;
                parament[5].Value = struct_BJ.p_nhzj;
                parament[6].Value = struct_BJ.p_nhzjmc;
                parament[7].Value = struct_BJ.p_ywmc;
                parament[8].Value = struct_BJ.p_yjsl;
                parament[9].Value = struct_BJ.p_bjsbh;
                parament[10].Value = struct_BJ.p_sy;
                parament[11].Value = struct_BJ.p_xybjsl;
                parament[12].Value = struct_BJ.p_cfwz;
                parament[13].Value = struct_BJ.p_bz;
                parament[14].Value = struct_BJ.p_zxdm;

                parament[15].Value = struct_BJ.p_csr;
                parament[16].Value = struct_BJ.p_zsr;
                parament[17].Value = struct_BJ.p_lrr;
                parament[18].Value = struct_BJ.p_sjbs;
                parament[19].Value = struct_BJ.p_zt;
                parament[20].Value = struct_BJ.p_bmdm;

                parament[21].Value = struct_BJ.p_id;
                parament[22].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJ", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[22].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_BJ.p_czfs;
                struct_RZ_YH.czxx = struct_BJ.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_BJ(string p_sjc, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sjc",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Delete_BJ", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }

        //更新状态
        protected void Update_BJZT(Struct_BJ struct_BJ)
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
                parament[0].Value = struct_BJ.p_id;
                parament[1].Value = struct_BJ.p_zt;
                parament[2].Value = struct_BJ.p_bhyy;
                parament[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJ.p_czfs;
                struct_rz.czxx = struct_BJ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //变更数据标识
        protected void Update_BJ_SJBS_ZT(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_shsj",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_BJ.p_sjc;
                parament[1].Value = struct_BJ.p_shsj;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJ_SJBS_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJ.p_czfs;
                struct_rz.czxx = struct_BJ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_BJ_SJBS_LSSJ_ZT(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                new OracleParameter("p_sjc",OracleType.VarChar),
                new OracleParameter("p_errorCode",OracleType.Int32)
            };
                parament[0].Value = struct_BJ.p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJ_SJBS_LSSJ_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJ.p_czfs;
                struct_rz.czxx = struct_BJ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将副本数据变为最终数据
        protected void Update_BJ_SJBS_FBSJ_ZT(Struct_BJ struct_BJ)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_BJ.p_sjc;
                paras[1].Value = struct_BJ.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_BJ.Update_BJ_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJ.p_czfs;
                struct_rz.czxx = struct_BJ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected DataTable Select_BJ_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJ_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查出原始数据，备份数据
        protected int BJ_SJBF(int id)
        {

            DataTable dt_detail = new DataTable();
            dt_detail = Select_BJ_Detail(id);
            Struct_BJ bj_bf = new Struct_BJ();
            bj_bf.p_id = Convert.ToInt32(dt_detail.Rows[0]["id"].ToString());
            bj_bf.p_bjbh = dt_detail.Rows[0]["bjbh"].ToString();
            bj_bf.p_bjmc = dt_detail.Rows[0]["bjmc"].ToString();
            bj_bf.p_sbxh = dt_detail.Rows[0]["sbxh"].ToString();
            bj_bf.p_bjfl = dt_detail.Rows[0]["bjfl"].ToString();
            bj_bf.p_bjzwmc = dt_detail.Rows[0]["bjzwmc"].ToString();
            bj_bf.p_nhzj = dt_detail.Rows[0]["nhzj"].ToString();
            bj_bf.p_nhzjmc = dt_detail.Rows[0]["nhzjmc"].ToString();
            bj_bf.p_ywmc = dt_detail.Rows[0]["ywmc"].ToString();
            bj_bf.p_yjsl = dt_detail.Rows[0]["yjsl"].ToString();
            bj_bf.p_bjsbh = dt_detail.Rows[0]["bjsbh"].ToString();
            bj_bf.p_sy = dt_detail.Rows[0]["sy"].ToString();
            bj_bf.p_xybjsl = dt_detail.Rows[0]["xybjsl"].ToString();
            bj_bf.p_cfwz = dt_detail.Rows[0]["cfwz"].ToString();
            bj_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            bj_bf.p_zxdm = dt_detail.Rows[0]["zxdm"].ToString();
            bj_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            bj_bf.p_zt = "0";
            bj_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            bj_bf.p_sjbs = "2";
            bj_bf.p_lrr = _us.userLoginName;
            bj_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            bj_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            bj_bf.p_shsj = "";
            bj_bf.p_czfs = "02";
            bj_bf.p_czxx = "备件id:" + id + "生成副本数据";
            //插入
            Insert_BJ(bj_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = bj_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJ_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }


















#endregion

        #region  ===============备件出库================
        protected DataSet Select_BJCK_Pro(Struct_BJCK struct_BJCK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_bjbh",OracleType.VarChar),
                                                new OracleParameter("p_bjfl",OracleType.VarChar),
                                                new OracleParameter("p_sy",OracleType.VarChar),
                                                new OracleParameter("p_ckjbr",OracleType.VarChar),
                                                new OracleParameter("p_jbrbm",OracleType.VarChar),
                                                new OracleParameter("p_jbrgw",OracleType.VarChar),
                                                new OracleParameter("p_kffzr",OracleType.VarChar),
                                                new OracleParameter("p_fzrbm",OracleType.VarChar),
                                                new OracleParameter("p_fzrgw",OracleType.VarChar),
                                                new OracleParameter("p_kssj",OracleType.DateTime),
                                                new OracleParameter("p_jssj",OracleType.DateTime),
                                                new OracleParameter("p_zxdm",OracleType.VarChar),

                                               new OracleParameter("p_jbrxm",OracleType.VarChar),
                                               new OracleParameter("p_fzrxm",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BJCK.p_bjbh;
                parament[1].Value = struct_BJCK.p_bjfl;
                parament[2].Value = struct_BJCK.p_sy;
                parament[3].Value = struct_BJCK.p_ckjbr;
                parament[4].Value = struct_BJCK.p_jbrbm;
                parament[5].Value = struct_BJCK.p_jbrgw;
                parament[6].Value = struct_BJCK.p_kffzr;
                parament[7].Value = struct_BJCK.p_fzrbm;
                parament[8].Value = struct_BJCK.p_fzrgw;
                parament[9].Value = struct_BJCK.p_kssj;
                parament[10].Value = struct_BJCK.p_jssj;
                parament[11].Value = struct_BJCK.p_zxdm;

                parament[12].Value = struct_BJCK.p_jbrxm;
                parament[13].Value = struct_BJCK.p_fzrxm;
                parament[14].Value = struct_BJCK.p_zt;
                parament[15].Value = struct_BJCK.p_userid;
                parament[16].Value = struct_BJCK.p_pagesize;
                parament[17].Value = struct_BJCK.p_currentpage;
                parament[18].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCK_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BJCKbyID(string p_id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCKbyID", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BJXX()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BJCK_Count(Struct_BJCK struct_BJCK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_bjbh",OracleType.VarChar),
                                               new OracleParameter("p_bjfl",OracleType.VarChar),
                                               new OracleParameter("p_sy",OracleType.VarChar),
                                               //new OracleParameter("p_ckjbr",OracleType.VarChar),
                                               new OracleParameter("p_jbrbm",OracleType.VarChar),
                                               new OracleParameter("p_jbrgw",OracleType.VarChar),
                                               //new OracleParameter("p_kffzr",OracleType.VarChar),
                                               new OracleParameter("p_fzrbm",OracleType.VarChar),
                                               new OracleParameter("p_fzrgw",OracleType.VarChar),
                                               new OracleParameter("p_kssj",OracleType.DateTime),
                                                new OracleParameter("p_jssj",OracleType.DateTime),
                                                new OracleParameter("p_zxdm",OracleType.VarChar),


                                               new OracleParameter("p_jbrxm",OracleType.VarChar),
                                               new OracleParameter("p_fzrxm",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BJCK.p_bjbh;
                parament[1].Value = struct_BJCK.p_bjfl;
                parament[2].Value = struct_BJCK.p_sy;
                //parament[3].Value = struct_BJCK.p_ckjbr;
                parament[3].Value = struct_BJCK.p_jbrbm;
                parament[4].Value = struct_BJCK.p_jbrgw;
                //parament[6].Value = struct_BJCK.p_kffzr;
                parament[5].Value = struct_BJCK.p_fzrbm;
                parament[6].Value = struct_BJCK.p_fzrgw;
                parament[7].Value = struct_BJCK.p_kssj;
                parament[8].Value = struct_BJCK.p_jssj;
                parament[9].Value = struct_BJCK.p_zxdm;

                parament[10].Value = struct_BJCK.p_jbrxm;
                parament[11].Value = struct_BJCK.p_fzrxm;
                parament[12].Value = struct_BJCK.p_zt;
                parament[13].Value = struct_BJCK.p_userid;
                parament[14].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCK_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_BJCK(Struct_BJCK struct_BJCK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                    new OracleParameter("p_bjbh",OracleType.VarChar),
                                                    new OracleParameter("p_cfwz",OracleType.VarChar),
                                                    new OracleParameter("p_ckjbr",OracleType.VarChar),
                                                    new OracleParameter("p_jbrbm",OracleType.VarChar),
                                                    new OracleParameter("p_jbrgw",OracleType.VarChar),
                                                    new OracleParameter("p_kffzr",OracleType.VarChar),
                                                    new OracleParameter("p_fzrbm",OracleType.VarChar),
                                                    new OracleParameter("p_fzrgw",OracleType.VarChar),
                                                    new OracleParameter("p_cksl",OracleType.Int32),
                                                    new OracleParameter("p_cksj",OracleType.DateTime),
                                                    new OracleParameter("p_bz",OracleType.VarChar),

                                                   new OracleParameter("p_jbrxm",OracleType.VarChar),
                                                   new OracleParameter("p_fzrxm",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_csr",OracleType.VarChar),
                                                   new OracleParameter("p_zsr",OracleType.VarChar),
                                                   new OracleParameter("p_lrr",OracleType.VarChar),
                                                   new OracleParameter("p_sjc",OracleType.VarChar),
                                                   new OracleParameter("p_sjbs",OracleType.VarChar),
                                                   new OracleParameter("p_zt",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJCK.p_bjbh;
                parament[1].Value = struct_BJCK.p_cfwz;
                parament[2].Value = struct_BJCK.p_ckjbr;
                parament[3].Value = struct_BJCK.p_jbrbm;
                parament[4].Value = struct_BJCK.p_jbrgw;
                parament[5].Value = struct_BJCK.p_kffzr;
                parament[6].Value = struct_BJCK.p_fzrbm;
                parament[7].Value = struct_BJCK.p_fzrgw;
                parament[8].Value = struct_BJCK.p_cksl;
                parament[9].Value = struct_BJCK.p_cksj;
                parament[10].Value = struct_BJCK.p_bz;

                parament[11].Value = struct_BJCK.p_jbrxm;
                parament[12].Value = struct_BJCK.p_fzrxm;
                parament[13].Value = struct_BJCK.p_bmdm;
                parament[14].Value = struct_BJCK.p_csr;
                parament[15].Value = struct_BJCK.p_zsr;
                parament[16].Value = struct_BJCK.p_lrr;
                parament[17].Value = struct_BJCK.p_sjc;
                parament[18].Value = struct_BJCK.p_sjbs;
                parament[19].Value = struct_BJCK.p_zt;
                parament[20].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Insert_BJCK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[20].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_BJCK.p_czfs;
                struct_RZ_YH.czxx = struct_BJCK.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_BJCK(Struct_BJCK struct_BJCK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_id",OracleType.VarChar),
                                                  new OracleParameter("p_bjbh",OracleType.VarChar),
                                                   new OracleParameter("p_cfwz",OracleType.VarChar),
                                                    new OracleParameter("p_ckjbr",OracleType.VarChar),
                                                    new OracleParameter("p_jbrbm",OracleType.VarChar),
                                                    new OracleParameter("p_jbrgw",OracleType.VarChar),
                                                    new OracleParameter("p_kffzr",OracleType.VarChar),
                                                    new OracleParameter("p_fzrbm",OracleType.VarChar),
                                                    new OracleParameter("p_fzrgw",OracleType.VarChar),
                                                    new OracleParameter("p_cksl",OracleType.Int32),
                                                    new OracleParameter("p_cksj",OracleType.DateTime),
                                                     new OracleParameter("p_bz",OracleType.VarChar),

                                                   new OracleParameter("p_jbrxm",OracleType.VarChar),
                                                   new OracleParameter("p_fzrxm",OracleType.VarChar),
                                                   new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_csr",OracleType.VarChar),
                                                   new OracleParameter("p_zsr",OracleType.VarChar),
                                                   new OracleParameter("p_lrr",OracleType.VarChar),
                                                   new OracleParameter("p_sjbs",OracleType.VarChar),
                                                   new OracleParameter("p_zt",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJCK.p_id;
                parament[1].Value = struct_BJCK.p_bjbh;
                parament[2].Value = struct_BJCK.p_cfwz;
                parament[3].Value = struct_BJCK.p_ckjbr;
                parament[4].Value = struct_BJCK.p_jbrbm;
                parament[5].Value = struct_BJCK.p_jbrgw;
                parament[6].Value = struct_BJCK.p_kffzr;
                parament[7].Value = struct_BJCK.p_fzrbm;
                parament[8].Value = struct_BJCK.p_fzrgw;
                parament[9].Value = struct_BJCK.p_cksl;
                parament[10].Value = struct_BJCK.p_cksj;
                parament[11].Value = struct_BJCK.p_bz;

                parament[12].Value = struct_BJCK.p_jbrxm;
                parament[13].Value = struct_BJCK.p_fzrxm;
                parament[14].Value = struct_BJCK.p_bmdm;
                parament[15].Value = struct_BJCK.p_csr;
                parament[16].Value = struct_BJCK.p_zsr;
                parament[17].Value = struct_BJCK.p_lrr;
                parament[18].Value = struct_BJCK.p_sjbs;
                parament[19].Value = struct_BJCK.p_zt;
                parament[20].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJCK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[20].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_BJCK.p_czfs;
                struct_RZ_YH.czxx = struct_BJCK.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_BJCK(string p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_id; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Delete_BJCK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }



        //更新状态
        protected void Update_BJCKZT(Struct_BJCK struct_BJCK)
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
                parament[0].Value = struct_BJCK.p_id;
                parament[1].Value = struct_BJCK.p_zt;
                parament[2].Value = struct_BJCK.p_bhyy;
                parament[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJCKZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJCK.p_czfs;
                struct_rz.czxx = struct_BJCK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //变更数据标识
        protected void Update_BJCK_SJBS_ZT(Struct_BJCK struct_BJCK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_shsj",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_BJCK.p_sjc;
                parament[1].Value = struct_BJCK.p_shsj;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJCK_SJBS_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJCK.p_czfs;
                struct_rz.czxx = struct_BJCK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_BJCK_SJBS_LSSJ_ZT(Struct_BJCK struct_BJCK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                new OracleParameter("p_sjc",OracleType.VarChar),
                new OracleParameter("p_errorCode",OracleType.Int32)
            };
                parament[0].Value = struct_BJCK.p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJCK_SJBS_LSSJ_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJCK.p_czfs;
                struct_rz.czxx = struct_BJCK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将副本数据变为最终数据
        protected void Update_BJCK_SJBS_FBSJ_ZT(Struct_BJCK struct_BJCK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_BJCK.p_sjc;
                paras[1].Value = struct_BJCK.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_BJ.Update_BJCK_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJCK.p_czfs;
                struct_rz.czxx = struct_BJCK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }


        protected int BJCK_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_BJCKbyID(Convert.ToString(id)).Tables[0];
            //备份数据
            Struct_BJCK bjck_bf = new Struct_BJCK();

            //pxjl_bf.p_rqsj = Convert.ToDateTime(dt_detail.Rows[0]["rqsj"].ToString());


            bjck_bf.p_bjbh = dt_detail.Rows[0]["bjbh"].ToString();
            bjck_bf.p_cfwz = dt_detail.Rows[0]["cfwz"].ToString();
            bjck_bf.p_ckjbr = dt_detail.Rows[0]["ckjbr"].ToString();
            bjck_bf.p_jbrbm = dt_detail.Rows[0]["jbrbm"].ToString();
            bjck_bf.p_jbrgw = dt_detail.Rows[0]["jbrgw"].ToString();
            bjck_bf.p_kffzr = dt_detail.Rows[0]["kffzr"].ToString();
            bjck_bf.p_fzrbm = dt_detail.Rows[0]["fzrbm"].ToString();
            bjck_bf.p_fzrgw = dt_detail.Rows[0]["fzrgw"].ToString();
            bjck_bf.p_cksl = Convert.ToInt32(dt_detail.Rows[0]["cksl"].ToString());
            bjck_bf.p_cksj = Convert.ToDateTime(dt_detail.Rows[0]["cksj"].ToString());
            bjck_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();

            bjck_bf.p_jbrxm = dt_detail.Rows[0]["jbrxm"].ToString();
            bjck_bf.p_fzrxm = dt_detail.Rows[0]["fzrxm"].ToString();

            bjck_bf.p_zt = "0";
            bjck_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            bjck_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            bjck_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            bjck_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            bjck_bf.p_lrr = _us.userLoginName;
            bjck_bf.p_sjbs = "2";
            bjck_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            bjck_bf.p_shsj = "";
            bjck_bf.p_czfs = "02";
            bjck_bf.p_czxx = "员工培训id:" + id + "生成副本数据";
            //插入
            Insert_BJCK(bjck_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = bjck_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCK_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
      
        #region  ===============备件入库================
        protected DataSet Select_BJRK_Pro(Struct_BJRK struct_BJRK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjbh",OracleType.VarChar),
                                                new OracleParameter("p_bjfl",OracleType.VarChar),
                                                new OracleParameter("p_sy",OracleType.VarChar),
                                                new OracleParameter("p_jbrxm",OracleType.VarChar),
                                                new OracleParameter("p_jbrbm",OracleType.VarChar),
                                                new OracleParameter("p_jbrgw",OracleType.VarChar),
                                                new OracleParameter("p_fzrxm",OracleType.VarChar),
                                                new OracleParameter("p_fzrbm",OracleType.VarChar),
                                                new OracleParameter("p_fzrgw",OracleType.VarChar),
                                                 new OracleParameter("p_kssj",OracleType.DateTime),
                                                new OracleParameter("p_jssj",OracleType.DateTime),
                                                new OracleParameter("p_zxdm",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BJRK.p_bjbh;
                parament[1].Value = struct_BJRK.p_bjfl;
                parament[2].Value = struct_BJRK.p_sy;
                parament[3].Value = struct_BJRK.p_jbrxm;
                parament[4].Value = struct_BJRK.p_jbrbm;
                parament[5].Value = struct_BJRK.p_jbrgw;
                parament[6].Value = struct_BJRK.p_fzrxm;
                parament[7].Value = struct_BJRK.p_fzrbm;
                parament[8].Value = struct_BJRK.p_fzrgw;
                parament[9].Value = struct_BJRK.p_kssj;
                parament[10].Value = struct_BJRK.p_jssj;
                parament[11].Value = struct_BJRK.p_zxdm;
                parament[12].Value = struct_BJRK.p_pagesize;
                parament[13].Value = struct_BJRK.p_currentpage;
                parament[14].Value = struct_BJRK.p_zt;
                parament[15].Value = struct_BJRK.p_userid;
                parament[16].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJRK_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BJRKbyID(string p_id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_id;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJRKbyID", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BJRK_Count(Struct_BJRK struct_BJRK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_bjbh",OracleType.VarChar),
                                                new OracleParameter("p_bjfl",OracleType.VarChar),
                                                new OracleParameter("p_sy",OracleType.VarChar),
                                                new OracleParameter("p_jbrxm",OracleType.VarChar),
                                                new OracleParameter("p_jbrbm",OracleType.VarChar),
                                                new OracleParameter("p_jbrgw",OracleType.VarChar),
                                                new OracleParameter("p_fzrxm",OracleType.VarChar),
                                                new OracleParameter("p_fzrbm",OracleType.VarChar),
                                                new OracleParameter("p_fzrgw",OracleType.VarChar),
                                                 new OracleParameter("p_kssj",OracleType.DateTime),
                                                new OracleParameter("p_jssj",OracleType.DateTime),
                                                new OracleParameter("p_zxdm",OracleType.VarChar),
                                                new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_BJRK.p_bjbh;
                parament[1].Value = struct_BJRK.p_bjfl;
                parament[2].Value = struct_BJRK.p_sy;
                parament[3].Value = struct_BJRK.p_jbrxm;
                parament[4].Value = struct_BJRK.p_jbrbm;
                parament[5].Value = struct_BJRK.p_jbrgw;
                parament[6].Value = struct_BJRK.p_fzrxm;
                parament[7].Value = struct_BJRK.p_fzrbm;
                parament[8].Value = struct_BJRK.p_fzrgw;
                parament[9].Value = struct_BJRK.p_kssj;
                parament[10].Value = struct_BJRK.p_jssj;
                parament[11].Value = struct_BJRK.p_zxdm;
                parament[12].Value = struct_BJRK.p_zt;
                parament[13].Value = struct_BJRK.p_userid;
                parament[14].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJRK_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_BJRK(Struct_BJRK struct_BJRK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                  new OracleParameter("p_bjbh",OracleType.VarChar),
                                                   new OracleParameter("p_cfwz",OracleType.VarChar),
                                                    new OracleParameter("p_rkjbr",OracleType.VarChar),
                                                    new OracleParameter("p_jbrbm",OracleType.VarChar),
                                                    new OracleParameter("p_jbrgw",OracleType.VarChar),
                                                    new OracleParameter("p_kffzr",OracleType.VarChar),
                                                    new OracleParameter("p_fzrbm",OracleType.VarChar),
                                                    new OracleParameter("p_fzrgw",OracleType.VarChar),
                                                    new OracleParameter("p_rksl",OracleType.Int32),
                                                    new OracleParameter("p_rksj",OracleType.DateTime),
                                                     new OracleParameter("p_bz",OracleType.VarChar),

                                                      new OracleParameter("p_jbrxm",OracleType.VarChar),
                                                    new OracleParameter("p_fzrxm",OracleType.VarChar),
                                                    new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_csr",OracleType.VarChar),
                                                   new OracleParameter("p_zsr",OracleType.VarChar),
                                                   new OracleParameter("p_lrr",OracleType.VarChar),
                                                   new OracleParameter("p_sjc",OracleType.VarChar),
                                                   new OracleParameter("p_sjbs",OracleType.VarChar),
                                                   new OracleParameter("p_zt",OracleType.VarChar),
                                                   //new OracleParameter("p_bhyy",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJRK.p_bjbh;
                parament[1].Value = struct_BJRK.p_cfwz;
                parament[2].Value = struct_BJRK.p_rkjbr;
                parament[3].Value = struct_BJRK.p_jbrbm;
                parament[4].Value = struct_BJRK.p_jbrgw;
                parament[5].Value = struct_BJRK.p_kffzr;
                parament[6].Value = struct_BJRK.p_fzrbm;
                parament[7].Value = struct_BJRK.p_fzrgw;
                parament[8].Value = struct_BJRK.p_rksl;
                parament[9].Value = struct_BJRK.p_rksj;
                parament[10].Value = struct_BJRK.p_bz;
                parament[11].Value = struct_BJRK.p_jbrxm;
                parament[12].Value = struct_BJRK.p_fzrxm;
                parament[13].Value = struct_BJRK.p_bmdm;
                parament[14].Value = struct_BJRK.p_csr;
                parament[15].Value = struct_BJRK.p_zsr;
                parament[16].Value = struct_BJRK.p_lrr;
                parament[17].Value = struct_BJRK.p_sjc;
                parament[18].Value = struct_BJRK.p_sjbs;
                parament[19].Value = struct_BJRK.p_zt;
                parament[20].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Insert_BJRK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[20].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_BJRK.p_czfs;
                struct_RZ_YH.czxx = struct_BJRK.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_BJRK(Struct_BJRK struct_BJRK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                    new OracleParameter("p_id",OracleType.VarChar),
                                                  new OracleParameter("p_bjbh",OracleType.VarChar),
                                                   new OracleParameter("p_cfwz",OracleType.VarChar),
                                                    new OracleParameter("p_rkjbr",OracleType.VarChar),
                                                    new OracleParameter("p_jbrbm",OracleType.VarChar),
                                                    new OracleParameter("p_jbrgw",OracleType.VarChar),
                                                    new OracleParameter("p_kffzr",OracleType.VarChar),
                                                    new OracleParameter("p_fzrbm",OracleType.VarChar),
                                                    new OracleParameter("p_fzrgw",OracleType.VarChar),
                                                    new OracleParameter("p_rksl",OracleType.Int32),
                                                    new OracleParameter("p_rksj",OracleType.DateTime),
                                                     new OracleParameter("p_bz",OracleType.VarChar),
                                                     new OracleParameter("p_jbrxm",OracleType.VarChar),
                                                    new OracleParameter("p_fzrxm",OracleType.VarChar),
                                                    new OracleParameter("p_bmdm",OracleType.VarChar),
                                                   new OracleParameter("p_csr",OracleType.VarChar),
                                                   new OracleParameter("p_zsr",OracleType.VarChar),
                                                   new OracleParameter("p_lrr",OracleType.VarChar),                                                   
                                                   new OracleParameter("p_sjbs",OracleType.VarChar),
                                                   new OracleParameter("p_zt",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJRK.p_id;
                parament[1].Value = struct_BJRK.p_bjbh;
                parament[2].Value = struct_BJRK.p_cfwz;
                parament[3].Value = struct_BJRK.p_rkjbr;
                parament[4].Value = struct_BJRK.p_jbrbm;
                parament[5].Value = struct_BJRK.p_jbrgw;
                parament[6].Value = struct_BJRK.p_kffzr;
                parament[7].Value = struct_BJRK.p_fzrbm;
                parament[8].Value = struct_BJRK.p_fzrgw;
                parament[9].Value = struct_BJRK.p_rksl;
                parament[10].Value = struct_BJRK.p_rksj;
                parament[11].Value = struct_BJRK.p_bz;
                parament[12].Value = struct_BJRK.p_jbrxm;
                parament[13].Value = struct_BJRK.p_fzrxm;
                parament[14].Value = struct_BJRK.p_bmdm;
                parament[15].Value = struct_BJRK.p_csr;
                parament[16].Value = struct_BJRK.p_zsr;
                parament[17].Value = struct_BJRK.p_lrr;
                parament[18].Value = struct_BJRK.p_sjbs;
                parament[19].Value = struct_BJRK.p_zt;
                parament[20].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJRK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[20].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_BJRK.p_czfs;
                struct_RZ_YH.czxx = struct_BJRK.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_BJRK(string p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_id; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Delete_BJRK", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #region 更新状态
        protected void Update_BJRKZT(Struct_BJRK struct_BJRK)
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
                paras[0].Value = struct_BJRK.p_id;
                paras[1].Value = struct_BJRK.p_zt;
                paras[2].Value = struct_BJRK.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_BJ.Update_BJRKZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJRK.p_czfs;
                struct_rz.czxx = struct_BJRK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #region
        //变更数据标识
        protected void Update_BJRK_SJBS_ZT(Struct_BJRK struct_BJRK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_BJRK.p_sjc;
                paras[1].Value = struct_BJRK.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_BJ.Update_BJRK_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJRK.p_czfs;
                struct_rz.czxx = struct_BJRK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_BJRK_SJBS_LSSJ_ZT(Struct_BJRK struct_BJRK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_BJRK.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_BJ.Update_BJRK_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJRK.p_czfs;
                struct_rz.czxx = struct_BJRK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        #region 将副本数据变为最终数据
        protected void Update_BJRK_SJBS_FBSJ_ZT(Struct_BJRK struct_BJRK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_BJRK.p_sjc;
                paras[1].Value = struct_BJRK.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_BJ.Update_BJRK_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_BJRK.p_czfs;
                struct_rz.czxx = struct_BJRK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        protected int BJRK_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_BJRKbyID(Convert.ToString(id)).Tables[0];
            //备份数据
            Struct_BJRK bjrk_bf = new Struct_BJRK();

            bjrk_bf.p_bjbh = dt_detail.Rows[0]["bjbh"].ToString();
            bjrk_bf.p_cfwz = dt_detail.Rows[0]["cfwz"].ToString();
            bjrk_bf.p_rkjbr = dt_detail.Rows[0]["rkjbr"].ToString();
            bjrk_bf.p_rksj = Convert.ToDateTime(dt_detail.Rows[0]["rksj"].ToString());
            bjrk_bf.p_rksl = Convert.ToInt32(dt_detail.Rows[0]["rksl"].ToString());
            bjrk_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            bjrk_bf.p_jbrbm = dt_detail.Rows[0]["jbrbm"].ToString();
            bjrk_bf.p_jbrgw = dt_detail.Rows[0]["jbrgw"].ToString();
            bjrk_bf.p_kffzr = dt_detail.Rows[0]["kffzr"].ToString();
            bjrk_bf.p_fzrbm = dt_detail.Rows[0]["fzrbm"].ToString();
            bjrk_bf.p_fzrgw = dt_detail.Rows[0]["fzrgw"].ToString();
            bjrk_bf.p_jbrxm = dt_detail.Rows[0]["jbrxm"].ToString();
            bjrk_bf.p_fzrxm = dt_detail.Rows[0]["fzrxm"].ToString();
            bjrk_bf.p_zt = "0";
            bjrk_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            bjrk_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            bjrk_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            bjrk_bf.p_lrr = _us.userLoginName;
            bjrk_bf.p_sjbs = "2";
            bjrk_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            bjrk_bf.p_shsj = "";
            bjrk_bf.p_czfs = "02";
            bjrk_bf.p_czxx = "员工奖励id:" + id + "生成副本数据";
            //插入
            Insert_BJRK(bjrk_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = bjrk_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJRK_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #endregion

        #region  ===============备件清单================
        protected void Update_BJSL(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_id",OracleType.VarChar),
                                                   new OracleParameter("p_sl",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJ.p_id;
                parament[1].Value = struct_BJ.p_sl;
                parament[2].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Update_BJSL", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[2].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }

            }
            finally
            {
                dbclass.Close();
            }

            Insert_BJCRKQD(struct_BJ);
        }
        protected void Insert_BJCRKQD(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bjbh",OracleType.VarChar),
                                                   new OracleParameter("p_userid",OracleType.VarChar),
                                                   new OracleParameter("p_czlx",OracleType.VarChar),
                                                   new OracleParameter("p_czsj",OracleType.DateTime),
                                                   new OracleParameter("p_czsl",OracleType.VarChar),
                                                   new OracleParameter("p_sjc",OracleType.VarChar),
                                                   new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_BJ.p_bjbh;
                parament[1].Value = struct_BJ.p_userid;
                parament[2].Value = struct_BJ.p_czlx;
                parament[3].Value = struct_BJ.p_czsj;
                parament[4].Value = struct_BJ.p_czsl;
                parament[5].Value = struct_BJ.p_sjc;
                parament[6].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_BJ.Insert_BJCRKQD", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[6].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataSet Select_BJCRKQD(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bjbh",OracleType.VarChar),
                                                   new OracleParameter("p_sjc",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = struct_BJ.p_bjbh;
                parament[1].Value = struct_BJ.p_sjc;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCRKQD", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BJCRKQD_Count(Struct_BJ struct_BJ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bjbh",OracleType.VarChar),
                                                   new OracleParameter("p_sjc",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = struct_BJ.p_bjbh;
                parament[1].Value = struct_BJ.p_sjc;
                parament[2].Direction = ParameterDirection.Output;
                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCRKQD_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;

            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        protected string SHTG_BJBH(string p_bjbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = p_bjbh;
                parament[1].Direction = ParameterDirection.Output;

                string ds = dbclass.RunProcedure("PACK_SBGL_BJ.Select_SHTG_BJBH", parament, "table").Tables[0].Rows[0][0].ToString();
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        //数据导出
        protected DataTable Select_BJ_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJ_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        #region  ===============导出================
        //数据导出
        protected DataTable Select_BJCRK_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCRK_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //数据导出
        protected DataTable Select_BJCRKQD_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_SBGL_BJ.Select_BJCRKQD_DC", paras, "table").Tables[0];
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
