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
    public struct Struct_SBWH
    {
        public int p_id;
        public string p_sbbh;
        public string p_sblx;
        public string p_whr;
        public string p_whrbm;
        public string p_whrgw;
        public string p_sbztxxxx;
        public string p_whjl;
        public string p_cdhjhdchjxsjl;
        public string p_whzt;
        public string p_whwjsc;
        public DateTime p_whsj;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public DateTime p_scsj;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
        public string p_sbzl;
        public string p_zxdm;
        public int p_pagesize;
        public int p_currentpage;
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
    }
    public struct Struct_SBGZ
    {
        public int p_id;
        public string p_sbbh;
        public string p_sblx;
        public DateTime p_gzqssj;
        public DateTime p_gzjssj;
        public string p_ljsc;
        public string p_wxr;
        public string p_gzxx;
        public string p_wxrbm;
        public string p_wxrgw;
        public string p_zcyx;
        public string p_czgc;
        public string p_gzyyfx;
        public string p_gzbjcljg;
        public string p_tlgzpcff;
        public string p_clbz;
        public string p_jycs;
        public string p_wxwjsc;
        public string p_bz;
        public string p_czfs;
        public string p_czxx;
        public string p_zxdm;
        public string p_sbzl;
        public int p_pagesize;
        public int p_currentpage;
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
    }
    public class OWHWX
    {
        private Struct_RZ_YH struct_RZ_YH;
        private UserState _us = null;
        private RZ rz;

        public OWHWX(UserState ygstate)
        {
            this._us = ygstate;
            rz = new RZ(ygstate);
            struct_RZ_YH = new Struct_RZ_YH();
        }
        #region  ===============设备维护================
        protected DataSet Select_SBWH_Pro(Struct_SBWH struct_SBWH)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_whr",OracleType.VarChar),
                                               new OracleParameter("p_whrbm",OracleType.VarChar),
                                               new OracleParameter("p_whrgw",OracleType.VarChar),
                                               new OracleParameter("p_whzt",OracleType.VarChar),
                                            //   new OracleParameter("p_kssj",OracleType.DateTime),
                                          //     new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_zxdm",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_SBWH.p_sbbh;
                parament[1].Value = struct_SBWH.p_sbzl;
                parament[2].Value = struct_SBWH.p_whr;
                parament[3].Value = struct_SBWH.p_whrbm;
                parament[4].Value = struct_SBWH.p_whrgw;
                parament[5].Value = struct_SBWH.p_whzt;
                //    parament[6].Value = struct_SBWH.p_kssj;
                //    parament[7].Value = struct_SBWH.p_jssj;
                parament[6].Value = struct_SBWH.p_sblx;
                parament[7].Value = struct_SBWH.p_zxdm;
                parament[8].Value = struct_SBWH.p_userid;
                parament[9].Value = struct_SBWH.p_pagesize;
                parament[10].Value = struct_SBWH.p_currentpage;
                parament[11].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBWH_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_SBWHbyID(int p_id, string p_sblx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_id;
                parament[1].Value = p_sblx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBWHbyID", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataSet Select_SBWHbySBBH(string p_sbbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_sbbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBWHbySBBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_SBWH_Count(Struct_SBWH struct_SBWH)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_whr",OracleType.VarChar),
                                               new OracleParameter("p_whrbm",OracleType.VarChar),
                                               new OracleParameter("p_whrgw",OracleType.VarChar),
                                               new OracleParameter("p_whzt",OracleType.VarChar),
                                           //    new OracleParameter("p_kssj",OracleType.DateTime),
                                            //   new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_zxdm",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_SBWH.p_sbbh;
                parament[1].Value = struct_SBWH.p_sbzl;
                parament[2].Value = struct_SBWH.p_whr;
                parament[3].Value = struct_SBWH.p_whrbm;
                parament[4].Value = struct_SBWH.p_whrgw;
                parament[5].Value = struct_SBWH.p_whzt;
                //    parament[6].Value = struct_SBWH.p_kssj;
                //    parament[7].Value = struct_SBWH.p_jssj;
                parament[6].Value = struct_SBWH.p_sblx;
                parament[7].Value = struct_SBWH.p_zxdm;
                parament[8].Value = struct_SBWH.p_userid;
                parament[9].Direction = ParameterDirection.Output;


                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBWH_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_SBWH(Struct_SBWH struct_SBWH)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Number),
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_whr",OracleType.VarChar),
                                               new OracleParameter("p_whrbm",OracleType.VarChar),
                                               new OracleParameter("p_whrgw",OracleType.VarChar),
                                               new OracleParameter("p_sbztxxxx",OracleType.VarChar),
                                               new OracleParameter("p_whjl",OracleType.VarChar),
                                               new OracleParameter("p_cdhjhdchjxsjl",OracleType.VarChar),
                                               new OracleParameter("p_whzt",OracleType.VarChar),
                                               new OracleParameter("p_whwjsc",OracleType.VarChar),
                                               new OracleParameter("p_whsj",OracleType.DateTime),
                                               new OracleParameter("p_scsj",OracleType.DateTime),
                                               new OracleParameter("p_bz",OracleType.VarChar),
                                                new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_SBWH.p_id;
                parament[1].Value = struct_SBWH.p_sbbh;
                parament[2].Value = struct_SBWH.p_sblx;
                parament[3].Value = struct_SBWH.p_whr;
                parament[4].Value = struct_SBWH.p_whrbm;
                parament[5].Value = struct_SBWH.p_whrgw;
                parament[6].Value = struct_SBWH.p_sbztxxxx;
                parament[7].Value = struct_SBWH.p_whjl;
                parament[8].Value = struct_SBWH.p_cdhjhdchjxsjl;
                parament[9].Value = struct_SBWH.p_whzt;
                parament[10].Value = struct_SBWH.p_whwjsc;
                parament[11].Value = struct_SBWH.p_whsj;
                parament[12].Value = struct_SBWH.p_scsj;
                parament[13].Value = struct_SBWH.p_bz;
                parament[14].Value = struct_SBWH.p_sbzl;
                parament[15].Value = struct_SBWH.p_bmdm;
                parament[16].Value = struct_SBWH.p_csr;
                parament[17].Value = struct_SBWH.p_zsr;
                parament[18].Value = struct_SBWH.p_lrr;
                parament[19].Value = struct_SBWH.p_sjc;
                parament[20].Value = struct_SBWH.p_sjbs;
                parament[21].Value = struct_SBWH.p_zt;
                parament[22].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Insert_SBWH", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[22].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_SBWH.p_czfs;
                struct_RZ_YH.czxx = struct_SBWH.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_SBWH(Struct_SBWH struct_SBWH)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_whr",OracleType.VarChar),
                                               new OracleParameter("p_whrbm",OracleType.VarChar),
                                               new OracleParameter("p_whrgw",OracleType.VarChar),
                                               new OracleParameter("p_sbztxxxx",OracleType.VarChar),
                                               new OracleParameter("p_whjl",OracleType.VarChar),
                                               new OracleParameter("p_cdhjhdchjxsjl",OracleType.VarChar),
                                               new OracleParameter("p_whzt",OracleType.VarChar),
                                               new OracleParameter("p_whwjsc",OracleType.VarChar),
                                               new OracleParameter("p_whsj",OracleType.DateTime),
                                               new OracleParameter("p_scsj",OracleType.DateTime),
                                               new OracleParameter("p_bz",OracleType.VarChar),
                                                new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),

                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_SBWH.p_id;
                parament[1].Value = struct_SBWH.p_sbbh;
                parament[2].Value = struct_SBWH.p_sblx;
                parament[3].Value = struct_SBWH.p_whr;
                parament[4].Value = struct_SBWH.p_whrbm;
                parament[5].Value = struct_SBWH.p_whrgw;
                parament[6].Value = struct_SBWH.p_sbztxxxx;
                parament[7].Value = struct_SBWH.p_whjl;
                parament[8].Value = struct_SBWH.p_cdhjhdchjxsjl;
                parament[9].Value = struct_SBWH.p_whzt;
                parament[10].Value = struct_SBWH.p_whwjsc;
                parament[11].Value = struct_SBWH.p_whsj;
                parament[12].Value = struct_SBWH.p_scsj;
                parament[13].Value = struct_SBWH.p_bz;
                parament[14].Value = struct_SBWH.p_sbzl;
                parament[15].Value = struct_SBWH.p_bmdm;
                parament[16].Value = struct_SBWH.p_csr;
                parament[17].Value = struct_SBWH.p_zsr;
                parament[18].Value = struct_SBWH.p_lrr;

                parament[19].Value = struct_SBWH.p_sjbs;
                parament[20].Value = struct_SBWH.p_zt;
                parament[21].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBWH", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[21].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_SBWH.p_czfs;
                struct_RZ_YH.czxx = struct_SBWH.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_SBWH(int p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_id; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Delete_SBWH", parament, out reslut);

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
        protected DataTable Select_SBWH_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBWH_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //更新状态
        protected void Update_SBWHZT(Struct_SBWH struct_SBWH)
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
                parament[0].Value = struct_SBWH.p_id;
                parament[1].Value = struct_SBWH.p_zt;
                //   parament[2].Value = struct_SBWH.p_bhyy;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBWHZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBWH.p_czfs;
                struct_rz.czxx = struct_SBWH.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //变更数据标识
        protected void Update_SBWH_SJBS_ZT(Struct_SBWH struct_SBWH)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_shsj",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_SBWH.p_sjc;
                parament[1].Value = struct_SBWH.p_shsj;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBWH_SJBS_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBWH.p_czfs;
                struct_rz.czxx = struct_SBWH.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_SBWH_SJBS_LSSJ_ZT(Struct_SBWH struct_SBWH)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                new OracleParameter("p_sjc",OracleType.VarChar),
                new OracleParameter("p_errorCode",OracleType.Int32)
            };
                parament[0].Value = struct_SBWH.p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBWH_SJBS_LSSJ_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBWH.p_czfs;
                struct_rz.czxx = struct_SBWH.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将副本数据变为最终数据
        protected void Update_SBWH_SJBS_FBSJ_ZT(Struct_SBWH struct_SBWH)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_SBWH.p_sjc;
                paras[1].Value = struct_SBWH.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_WHWX.Update_SBWH_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBWH.p_czfs;
                struct_rz.czxx = struct_SBWH.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        //查出原始数据，备份数据
        protected int Struct_SBWH_SJBF(int id)
        {

            DataTable dt_detail = new DataTable();
            dt_detail = Select_SBWH_Detail(id);
            Struct_SBWH sbwh_bf = new Struct_SBWH();
            sbwh_bf.p_sbbh = dt_detail.Rows[0]["sbbh"].ToString();
            sbwh_bf.p_sblx = dt_detail.Rows[0]["sblxdm"].ToString();
            sbwh_bf.p_whr = dt_detail.Rows[0]["whr"].ToString();
            sbwh_bf.p_whrbm = dt_detail.Rows[0]["whrbm"].ToString();
            sbwh_bf.p_whrgw = dt_detail.Rows[0]["whrgw"].ToString();
            sbwh_bf.p_sbztxxxx = dt_detail.Rows[0]["sbztxxxx"].ToString();
            sbwh_bf.p_whjl = dt_detail.Rows[0]["whjl"].ToString();
            sbwh_bf.p_cdhjhdchjxsjl = dt_detail.Rows[0]["cdhjhdchjxsjl"].ToString();
            sbwh_bf.p_whzt = dt_detail.Rows[0]["whzt"].ToString();
            sbwh_bf.p_whwjsc = dt_detail.Rows[0]["whwjsc"].ToString();
            sbwh_bf.p_whsj = Convert.ToDateTime(dt_detail.Rows[0]["whsj"].ToString());
            sbwh_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            sbwh_bf.p_scsj = Convert.ToDateTime(dt_detail.Rows[0]["scsj"].ToString());
            sbwh_bf.p_sbzl = dt_detail.Rows[0]["sbzl"].ToString();

            sbwh_bf.p_zt = "0";
            sbwh_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            sbwh_bf.p_sjbs = "2";
            sbwh_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            sbwh_bf.p_lrr = _us.userLoginName;
            sbwh_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            sbwh_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            sbwh_bf.p_shsj = "";
            sbwh_bf.p_czfs = "02";
            sbwh_bf.p_czxx = "设备故障id:" + id + "生成副本数据";
            //插入
            Insert_SBWH(sbwh_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = sbwh_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBWH_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataTable Select_SBWH_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBWH_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion





        #region  ===============设备故障================
        protected DataSet Select_SBGZ_Pro(Struct_SBGZ struct_SBGZ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_wxr",OracleType.VarChar),
                                               new OracleParameter("p_wxrbm",OracleType.VarChar),
                                               new OracleParameter("p_wxrgw",OracleType.VarChar),
                                           //    new OracleParameter("p_gzqssj",OracleType.DateTime),
                                           //    new OracleParameter("p_gzjssj",OracleType.DateTime),
                                            //   new OracleParameter("p_zxdm",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_SBGZ.p_sbbh;
                parament[1].Value = struct_SBGZ.p_sblx;
                parament[2].Value = struct_SBGZ.p_sbzl;
                parament[3].Value = struct_SBGZ.p_wxr;
                parament[4].Value = struct_SBGZ.p_wxrbm;
                parament[5].Value = struct_SBGZ.p_wxrgw;
                //    parament[6].Value = struct_SBGZ.p_gzqssj;
                //    parament[7].Value = struct_SBGZ.p_gzjssj;
                //  parament[8].Value = struct_SBGZ.p_zxdm;
                parament[6].Value = struct_SBGZ.p_userid;
                parament[7].Value = struct_SBGZ.p_pagesize;
                parament[8].Value = struct_SBGZ.p_currentpage;
                parament[9].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBGZ_Pro", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_SBGZbyID(int p_id, string p_sblx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_id;
                parament[1].Value = p_sblx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBGZbyID", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataSet Select_SBGZbySBBH(string p_sbbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_sbbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBGZbySBBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_SBGZ_Count(Struct_SBGZ struct_SBGZ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_wxr",OracleType.VarChar),
                                               new OracleParameter("p_wxrbm",OracleType.VarChar),
                                               new OracleParameter("p_wxrgw",OracleType.VarChar),
                                             //  new OracleParameter("p_gzqssj",OracleType.DateTime),
                                            //   new OracleParameter("p_gzjssj",OracleType.DateTime),
                                           //    new OracleParameter("p_zxdm",OracleType.VarChar),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_SBGZ.p_sbbh;
                parament[1].Value = struct_SBGZ.p_sblx;
                parament[2].Value = struct_SBGZ.p_sbzl;
                parament[3].Value = struct_SBGZ.p_wxr;
                parament[4].Value = struct_SBGZ.p_wxrbm;
                parament[5].Value = struct_SBGZ.p_wxrgw;
                //    parament[6].Value = struct_SBGZ.p_gzqssj;
                //    parament[7].Value = struct_SBGZ.p_gzjssj;
                //   parament[8].Value = struct_SBGZ.p_zxdm;
                parament[6].Value = struct_SBGZ.p_userid;
                parament[7].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBGZ_Count", parament, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Insert_SBGZ(Struct_SBGZ struct_SBGZ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_gzqssj",OracleType.DateTime),
                                               new OracleParameter("p_gzjssj",OracleType.DateTime),
                                               new OracleParameter("p_ljsc",OracleType.VarChar),
                                               new OracleParameter("p_wxr",OracleType.VarChar),
                                               new OracleParameter("p_gzxx",OracleType.VarChar),
                                               new OracleParameter("p_wxrbm",OracleType.VarChar),
                                               new OracleParameter("p_wxrgw",OracleType.VarChar),
                                               new OracleParameter("p_zcyx",OracleType.VarChar),
                                               new OracleParameter("p_czgc",OracleType.VarChar),
                                               new OracleParameter("p_gzyyfx",OracleType.VarChar),
                                               new OracleParameter("p_gzbjcljg",OracleType.VarChar),
                                               new OracleParameter("p_tlgzpcff",OracleType.VarChar),
                                               new OracleParameter("p_clbz",OracleType.VarChar),
                                               new OracleParameter("p_jycs",OracleType.VarChar),
                                               new OracleParameter("p_wxwjsc",OracleType.VarChar),
                                               new OracleParameter("p_bz",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_SBGZ.p_id;
                parament[1].Value = struct_SBGZ.p_sbbh;
                parament[2].Value = struct_SBGZ.p_sblx;
                parament[3].Value = struct_SBGZ.p_gzqssj;
                parament[4].Value = struct_SBGZ.p_gzjssj;
                parament[5].Value = struct_SBGZ.p_ljsc;
                parament[6].Value = struct_SBGZ.p_wxr;
                parament[7].Value = struct_SBGZ.p_gzxx;
                parament[8].Value = struct_SBGZ.p_wxrbm;
                parament[9].Value = struct_SBGZ.p_wxrgw;
                parament[10].Value = struct_SBGZ.p_zcyx;
                parament[11].Value = struct_SBGZ.p_czgc;
                parament[12].Value = struct_SBGZ.p_gzyyfx;
                parament[13].Value = struct_SBGZ.p_gzbjcljg;
                parament[14].Value = struct_SBGZ.p_tlgzpcff;
                parament[15].Value = struct_SBGZ.p_clbz;
                parament[16].Value = struct_SBGZ.p_jycs;
                parament[17].Value = struct_SBGZ.p_wxwjsc;
                parament[18].Value = struct_SBGZ.p_bz;
                parament[19].Value = struct_SBGZ.p_sbzl;
                parament[20].Value = struct_SBGZ.p_bmdm;
                parament[21].Value = struct_SBGZ.p_csr;
                parament[22].Value = struct_SBGZ.p_zsr;
                parament[23].Value = struct_SBGZ.p_lrr;
                parament[24].Value = struct_SBGZ.p_sjc;
                parament[25].Value = struct_SBGZ.p_sjbs;
                parament[26].Value = struct_SBGZ.p_zt;
                parament[27].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Insert_SBGZ", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[27].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_SBGZ.p_czfs;
                struct_RZ_YH.czxx = struct_SBGZ.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_SBGZ(Struct_SBGZ struct_SBGZ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sblx",OracleType.VarChar),
                                               new OracleParameter("p_gzqssj",OracleType.DateTime),
                                               new OracleParameter("p_gzjssj",OracleType.DateTime),
                                               new OracleParameter("p_ljsc",OracleType.VarChar),
                                               new OracleParameter("p_wxr",OracleType.VarChar),
                                               new OracleParameter("p_gzxx",OracleType.VarChar),
                                               new OracleParameter("p_wxrbm",OracleType.VarChar),
                                               new OracleParameter("p_wxrgw",OracleType.VarChar),
                                               new OracleParameter("p_zcyx",OracleType.VarChar),
                                               new OracleParameter("p_czgc",OracleType.VarChar),
                                               new OracleParameter("p_gzyyfx",OracleType.VarChar),
                                               new OracleParameter("p_gzbjcljg",OracleType.VarChar),
                                               new OracleParameter("p_tlgzpcff",OracleType.VarChar),
                                               new OracleParameter("p_clbz",OracleType.VarChar),
                                               new OracleParameter("p_jycs",OracleType.VarChar),
                                               new OracleParameter("p_wxwjsc",OracleType.VarChar),
                                               new OracleParameter("p_bz",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_csr",OracleType.VarChar),
                                                 new OracleParameter("p_zsr",OracleType.VarChar),
                                                 new OracleParameter("p_lrr",OracleType.VarChar),

                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = struct_SBGZ.p_id;
                parament[1].Value = struct_SBGZ.p_sbbh;
                parament[2].Value = struct_SBGZ.p_sblx;
                parament[3].Value = struct_SBGZ.p_gzqssj;
                parament[4].Value = struct_SBGZ.p_gzjssj;
                parament[5].Value = struct_SBGZ.p_ljsc;
                parament[6].Value = struct_SBGZ.p_wxr;
                parament[7].Value = struct_SBGZ.p_gzxx;
                parament[8].Value = struct_SBGZ.p_wxrbm;
                parament[9].Value = struct_SBGZ.p_wxrgw;
                parament[10].Value = struct_SBGZ.p_zcyx;
                parament[11].Value = struct_SBGZ.p_czgc;
                parament[12].Value = struct_SBGZ.p_gzyyfx;
                parament[13].Value = struct_SBGZ.p_gzbjcljg;
                parament[14].Value = struct_SBGZ.p_tlgzpcff;
                parament[15].Value = struct_SBGZ.p_clbz;
                parament[16].Value = struct_SBGZ.p_jycs;
                parament[17].Value = struct_SBGZ.p_wxwjsc;
                parament[18].Value = struct_SBGZ.p_bz;
                parament[19].Value = struct_SBGZ.p_sbzl;
                parament[20].Value = struct_SBGZ.p_bmdm;
                parament[21].Value = struct_SBGZ.p_csr;
                parament[22].Value = struct_SBGZ.p_zsr;
                parament[23].Value = struct_SBGZ.p_lrr;

                parament[24].Value = struct_SBGZ.p_sjbs;
                parament[25].Value = struct_SBGZ.p_zt;
                parament[26].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBGZ", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[26].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_SBGZ.p_czfs;
                struct_RZ_YH.czxx = struct_SBGZ.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_SBGZ(int p_id, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = p_id; ;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Delete_SBGZ", parament, out reslut);

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
        protected DataTable Select_SBGZ_Detail(int id)
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
                ds = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBGZ_Detail", paras, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //更新状态
        protected void Update_SBGZZT(Struct_SBGZ struct_SBGZ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_id",OracleType.Number),
                    new OracleParameter("p_zt",OracleType.VarChar),
                 //   new OracleParameter("p_bhyy",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_SBGZ.p_id;
                parament[1].Value = struct_SBGZ.p_zt;
                //   parament[2].Value = struct_SBGZ.p_bhyy;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBGZZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBGZ.p_czfs;
                struct_rz.czxx = struct_SBGZ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //变更数据标识
        protected void Update_SBGZ_SJBS_ZT(Struct_SBGZ struct_SBGZ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                    new OracleParameter("p_sjc",OracleType.VarChar),
                    new OracleParameter("p_shsj",OracleType.VarChar),
                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                parament[0].Value = struct_SBGZ.p_sjc;
                parament[1].Value = struct_SBGZ.p_shsj;
                parament[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBGZ_SJBS_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBGZ.p_czfs;
                struct_rz.czxx = struct_SBGZ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将原最终数据变为历史数据
        protected void Update_SBGZ_SJBS_LSSJ_ZT(Struct_SBGZ struct_SBGZ)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                new OracleParameter("p_sjc",OracleType.VarChar),
                new OracleParameter("p_errorCode",OracleType.Int32)
            };
                parament[0].Value = struct_SBGZ.p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Update_SBGZ_SJBS_LSSJ_ZT", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBGZ.p_czfs;
                struct_rz.czxx = struct_SBGZ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        //将副本数据变为最终数据
        protected void Update_SBGZ_SJBS_FBSJ_ZT(Struct_SBGZ struct_SBGZ)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = struct_SBGZ.p_sjc;
                paras[1].Value = struct_SBGZ.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SBGL_WHWX.Update_SBGZ_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_us);
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_SBGZ.p_czfs;
                struct_rz.czxx = struct_SBGZ.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        //查出原始数据，备份数据
        protected int Struct_SBGZ_SJBF(int id)
        {

            DataTable dt_detail = new DataTable();
            dt_detail = Select_SBGZ_Detail(id);
            Struct_SBGZ sbgz_bf = new Struct_SBGZ();
            sbgz_bf.p_sbbh = dt_detail.Rows[0]["sbbh"].ToString();
            sbgz_bf.p_sblx = dt_detail.Rows[0]["sblx"].ToString();
            sbgz_bf.p_gzqssj = Convert.ToDateTime(dt_detail.Rows[0]["gzqssj"].ToString());
            sbgz_bf.p_gzjssj = Convert.ToDateTime(dt_detail.Rows[0]["gzjssj"].ToString());
            sbgz_bf.p_ljsc = dt_detail.Rows[0]["ljsc"].ToString();
            sbgz_bf.p_wxr = dt_detail.Rows[0]["wxr"].ToString();
            sbgz_bf.p_gzxx = dt_detail.Rows[0]["gzxx"].ToString();
            sbgz_bf.p_wxrbm = dt_detail.Rows[0]["wxrbm"].ToString();
            sbgz_bf.p_wxrgw = dt_detail.Rows[0]["wxrgw"].ToString();
            sbgz_bf.p_zcyx = dt_detail.Rows[0]["zcyx"].ToString();
            sbgz_bf.p_czgc = dt_detail.Rows[0]["czgc"].ToString();
            sbgz_bf.p_gzyyfx = dt_detail.Rows[0]["gzyyfx"].ToString();
            sbgz_bf.p_gzbjcljg = dt_detail.Rows[0]["gzbjcljg"].ToString();
            sbgz_bf.p_tlgzpcff = dt_detail.Rows[0]["tlgzpcff"].ToString();
            sbgz_bf.p_clbz = dt_detail.Rows[0]["clbz"].ToString();
            sbgz_bf.p_jycs = dt_detail.Rows[0]["jycs"].ToString();
            sbgz_bf.p_wxwjsc = dt_detail.Rows[0]["wxwjsc"].ToString();
            sbgz_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            sbgz_bf.p_sbzl = dt_detail.Rows[0]["sbzl"].ToString();

            sbgz_bf.p_zt = "0";
            sbgz_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            sbgz_bf.p_sjbs = "2";
            sbgz_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            sbgz_bf.p_lrr = _us.userLoginName;
            sbgz_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            sbgz_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            sbgz_bf.p_shsj = "";
            sbgz_bf.p_czfs = "02";
            sbgz_bf.p_czxx = "设备故障id:" + id + "生成副本数据";
            //插入
            Insert_SBGZ(sbgz_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = sbgz_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBGZ_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //数据导出
        protected DataTable Select_SBGZ_DC(int p_userid)
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
                dt = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBGZ_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  ===============设备故障================
        //数据导出
        protected DataTable Select_SBDM(string sblx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_sblx",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };

                paras[0].Value = sblx;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_SBGL_WHWX.Select_SBDM", paras, "table").Tables[0];
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


