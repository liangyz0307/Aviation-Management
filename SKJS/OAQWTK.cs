using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using Sys;

namespace CUST.MKG
{
    public struct Struct_AQWTK
    {
        public string p_id;
        public string p_gw;//岗位
        public string p_aqwtmc;//安全问题名称
        public string p_ly;//来源
        public DateTime p_fssj;//发生时间
        public DateTime p_fssj_ks;//发生时间 开始
        public DateTime p_fssj_js;//发生时间 结束
        public string p_sjfc;//涉及范畴
        public string p_yfyy;//诱发原因分析
        public string p_knzchg;//可能造成的问题或后果  
        public string p_xgsj;//与危险源相关联的事件或典型案例 相关事件
        public string p_st;//时态
        public string p_hgyzcd;//后果的严重程度(严重性)
        public string p_wxcd;//危险程度
        public string p_wtaqzt;//问题安全状态（正常/异常/紧急)
        public string p_dxcs;//等效措施或预案
        public DateTime p_zgsx;//整改时限
        public string p_zgcs;//整改措施
        public string p_zgcsbzhqk;//整改措施标准化情况
        public string p_wtkzzt;//问题控制状态（未控制/整改中/已关闭)
        public string p_zrbm;//责任部门
        public string p_zrgw;//责任岗位
        public string p_zrr;//责任人
        public string p_sjbm;//涉及部门
        public string p_bz;//备注

        public string p_zt;
        public string p_bhyy;
        public string p_czfs;
        public string p_czxx;
        public int p_pagesize;
        public int p_currentpage;
        public int p_userid;
        public string p_bmdm;

        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
    }
     public class OAQWTK
    {



        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private RZ rz = null;
        private UserState _us = null;
        public OAQWTK(UserState state)
        {
            this._us = state;
            rz = new RZ(state);
        }


        protected DataTable Select_AQWTK_Detail(int p_id)
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
                dt = db.RunProcedure("PACK_SKJS_AQWTK.Select_SKJS_AQWTK_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }

        protected int Select_AQWTK_Count(Struct_AQWTK Struct_AQWTK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zrbm",OracleType.VarChar),
                                               new OracleParameter("p_sjfc",OracleType.VarChar),
                                               new OracleParameter("p_ly",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_fssj_ks",OracleType.DateTime),
                                               new OracleParameter("p_fssj_js",OracleType.DateTime),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = Struct_AQWTK.p_zrbm;
                parament[1].Value = Struct_AQWTK.p_sjfc;
                parament[2].Value = Struct_AQWTK.p_ly;
                parament[3].Value = Struct_AQWTK.p_zt;
                parament[4].Value = Struct_AQWTK.p_fssj_ks;
                parament[5].Value = Struct_AQWTK.p_fssj_js;
                parament[6].Value = Struct_AQWTK.p_userid;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_SKJS_AQWTK.Select_SKJS_AQWTK_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }

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
                dt = db.RunProcedure("PACK_SKJS_AQWTK.Select_YGXMbyBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }

        protected DataTable Select_YGbyBMGW(string p_bmdm, string p_gwdm)
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
                dt = db.RunProcedure("PACK_SKJS_AQWTK.Select_YGbyBMGW", paras, "tables").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }

        protected DataTable Select_AQWTK(Struct_AQWTK Struct_AQWTK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zrbm",OracleType.VarChar),
                                               new OracleParameter("p_sjfc",OracleType.VarChar),
                                               new OracleParameter("p_ly",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_fssj_ks",OracleType.DateTime),
                                               new OracleParameter("p_fssj_js",OracleType.DateTime),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_userid",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = Struct_AQWTK.p_zrbm;
                parament[1].Value = Struct_AQWTK.p_sjfc;
                parament[2].Value = Struct_AQWTK.p_ly;
                parament[3].Value = Struct_AQWTK.p_zt;
                parament[4].Value = Struct_AQWTK.p_fssj_ks;
                parament[5].Value = Struct_AQWTK.p_fssj_js;
                parament[6].Value = Struct_AQWTK.p_currentpage;
                parament[7].Value = Struct_AQWTK.p_pagesize;
                parament[8].Value = Struct_AQWTK.p_userid;
                parament[9].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_SKJS_AQWTK.Select_SKJS_AQWTK", parament, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected void Insert_AQWTK(Struct_AQWTK Struct_AQWTK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_gw",OracleType.VarChar),
                    new OracleParameter("p_aqwtmc",OracleType.VarChar),
                    new OracleParameter("p_ly",OracleType.VarChar),
                    new OracleParameter("p_fssj",OracleType.DateTime),
                    new OracleParameter("p_sjfc",OracleType.VarChar),
                    new OracleParameter("p_yfyy",OracleType.VarChar),
                    new OracleParameter("p_knzchg",OracleType.VarChar),
                    new OracleParameter("p_xgsj",OracleType.VarChar),
                    new OracleParameter("p_st",OracleType.VarChar),
                    new OracleParameter("p_hgyzcd",OracleType.VarChar),
                    new OracleParameter("p_wxcd",OracleType.VarChar),
                    new OracleParameter("p_wtaqzt",OracleType.VarChar),
                    new OracleParameter("p_dxcs",OracleType.VarChar),
                    new OracleParameter("p_zgsx",OracleType.DateTime),
                    new OracleParameter("p_zgcs",OracleType.VarChar),
                    new OracleParameter("p_zgcsbzhqk",OracleType.VarChar),
                    new OracleParameter("p_wtkzzt",OracleType.VarChar),
                    new OracleParameter("p_zrbm",OracleType.VarChar),
                    new OracleParameter("p_zrgw",OracleType.VarChar),
                    new OracleParameter("p_zrr",OracleType.VarChar),
                    new OracleParameter("p_sjbm",OracleType.VarChar),
                    new OracleParameter("p_bz",OracleType.VarChar),

                      new OracleParameter("p_bmdm",OracleType.VarChar),
                      new OracleParameter("p_csr",OracleType.VarChar),
                      new OracleParameter("p_zsr",OracleType.VarChar),
                      new OracleParameter("p_lrr",OracleType.VarChar),
                      new OracleParameter("p_sjc",OracleType.VarChar),
                      new OracleParameter("p_sjbs",OracleType.VarChar),

                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = Struct_AQWTK.p_gw;
                paras[1].Value = Struct_AQWTK.p_aqwtmc;
                paras[2].Value = Struct_AQWTK.p_ly;
                paras[3].Value = Struct_AQWTK.p_fssj;
                paras[4].Value = Struct_AQWTK.p_sjfc;
                paras[5].Value = Struct_AQWTK.p_yfyy;
                paras[6].Value = Struct_AQWTK.p_knzchg;
                paras[7].Value = Struct_AQWTK.p_xgsj;
                paras[8].Value = Struct_AQWTK.p_st;
                paras[9].Value = Struct_AQWTK.p_hgyzcd;
                paras[10].Value = Struct_AQWTK.p_wxcd;
                paras[11].Value = Struct_AQWTK.p_wtaqzt;
                paras[12].Value = Struct_AQWTK.p_dxcs;
                paras[13].Value = Struct_AQWTK.p_zgsx;
                paras[14].Value = Struct_AQWTK.p_zgcs;
                paras[15].Value = Struct_AQWTK.p_zgcsbzhqk;
                paras[16].Value = Struct_AQWTK.p_wtkzzt;
                paras[17].Value = Struct_AQWTK.p_zrbm;
                paras[18].Value = Struct_AQWTK.p_zrgw;
                paras[19].Value = Struct_AQWTK.p_zrr;
                paras[20].Value = Struct_AQWTK.p_sjbm;
                paras[21].Value = Struct_AQWTK.p_bz;

                paras[22].Value = Struct_AQWTK.p_bmdm;
                paras[23].Value = Struct_AQWTK.p_csr;
                paras[24].Value = Struct_AQWTK.p_zsr;
                paras[25].Value = Struct_AQWTK.p_lrr;
                paras[26].Value = Struct_AQWTK.p_sjc;
                paras[27].Value = Struct_AQWTK.p_sjbs;

                paras[28].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQWTK.Insert_SKJS_AQWTK", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[28].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = Struct_AQWTK.p_czfs;
                struct_rz.czxx = Struct_AQWTK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        protected void Delete_AQWTK(int p_id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_SKJS_AQWTK.Delete_SKJS_AQWTK", paras, out rowsAffected);
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

        protected void Update_AQWTK(Struct_AQWTK Struct_AQWTK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                {
                    new OracleParameter("p_id",OracleType.VarChar),
                    new OracleParameter("p_gw",OracleType.VarChar),
                    new OracleParameter("p_aqwtmc",OracleType.VarChar),
                    new OracleParameter("p_ly",OracleType.VarChar),
                    new OracleParameter("p_fssj",OracleType.DateTime),
                    new OracleParameter("p_sjfc",OracleType.VarChar),
                    new OracleParameter("p_yfyy",OracleType.VarChar),
                    new OracleParameter("p_knzchg",OracleType.VarChar),
                    new OracleParameter("p_xgsj",OracleType.VarChar),
                    new OracleParameter("p_st",OracleType.VarChar),
                    new OracleParameter("p_hgyzcd",OracleType.VarChar),
                    new OracleParameter("p_wxcd",OracleType.VarChar),
                    new OracleParameter("p_wtaqzt",OracleType.VarChar),
                    new OracleParameter("p_dxcs",OracleType.VarChar),
                    new OracleParameter("p_zgsx",OracleType.DateTime),
                    new OracleParameter("p_zgcs",OracleType.VarChar),
                    new OracleParameter("p_zgcsbzhqk",OracleType.VarChar),
                    new OracleParameter("p_wtkzzt",OracleType.VarChar),
                    new OracleParameter("p_zrbm",OracleType.VarChar),
                    new OracleParameter("p_zrgw",OracleType.VarChar),
                    new OracleParameter("p_zrr",OracleType.VarChar),
                    new OracleParameter("p_sjbm",OracleType.VarChar),
                    new OracleParameter("p_bz",OracleType.VarChar),

                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_csr",OracleType.VarChar),
                    new OracleParameter("p_zsr",OracleType.VarChar),
                    new OracleParameter("p_lrr",OracleType.VarChar),

                    new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = Struct_AQWTK.p_id;
                paras[1].Value = Struct_AQWTK.p_gw;
                paras[2].Value = Struct_AQWTK.p_aqwtmc;
                paras[3].Value = Struct_AQWTK.p_ly;
                paras[4].Value = Struct_AQWTK.p_fssj;
                paras[5].Value = Struct_AQWTK.p_sjfc;
                paras[6].Value = Struct_AQWTK.p_yfyy;
                paras[7].Value = Struct_AQWTK.p_knzchg;
                paras[8].Value = Struct_AQWTK.p_xgsj;
                paras[9].Value = Struct_AQWTK.p_st;
                paras[10].Value = Struct_AQWTK.p_hgyzcd;
                paras[11].Value = Struct_AQWTK.p_wxcd;
                paras[12].Value = Struct_AQWTK.p_wtaqzt;
                paras[13].Value = Struct_AQWTK.p_dxcs;
                paras[14].Value = Struct_AQWTK.p_zgsx;
                paras[15].Value = Struct_AQWTK.p_zgcs;
                paras[16].Value = Struct_AQWTK.p_zgcsbzhqk;
                paras[17].Value = Struct_AQWTK.p_wtkzzt;
                paras[18].Value = Struct_AQWTK.p_zrbm;
                paras[19].Value = Struct_AQWTK.p_zrgw;
                paras[20].Value = Struct_AQWTK.p_zrr;
                paras[21].Value = Struct_AQWTK.p_sjbm;
                paras[22].Value = Struct_AQWTK.p_bz;

                paras[23].Value = Struct_AQWTK.p_bmdm;
                paras[24].Value = Struct_AQWTK.p_csr;
                paras[25].Value = Struct_AQWTK.p_zsr;
                paras[26].Value = Struct_AQWTK.p_lrr;

                paras[27].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQWTK.Update_SKJS_AQWTK", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[27].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = Struct_AQWTK.p_czfs;
                struct_rz.czxx = Struct_AQWTK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #region 更新状态
        protected void Update_AQWTKZT(Struct_AQWTK Struct_AQWTK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = Struct_AQWTK.p_id;
                paras[1].Value = Struct_AQWTK.p_zt;
                paras[2].Value = Struct_AQWTK.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQWTK.Update_AQWTKZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
            }
            finally
            {
                db.Close();
            }
        }  //变更数据标识
        protected void Update_AQWTK_SJBS_ZT(Struct_AQWTK Struct_AQWTK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = Struct_AQWTK.p_sjc;
                paras[1].Value = Struct_AQWTK.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQWTK.Update_AQWTK_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = Struct_AQWTK.p_czfs;
                struct_rz.czxx = Struct_AQWTK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_AQWTK_SJBS_LSSJ_ZT(Struct_AQWTK Struct_AQWTK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = Struct_AQWTK.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQWTK.Update_AQWTK_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = Struct_AQWTK.p_czfs;
                struct_rz.czxx = Struct_AQWTK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #region 将副本数据变为最终数据
        protected void Update_AQWTK_SJBS_FBSJ_ZT(Struct_AQWTK Struct_AQWTK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = Struct_AQWTK.p_sjc;
                paras[1].Value = Struct_AQWTK.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_SKJS_AQWTK.Update_AQWTK_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = Struct_AQWTK.p_czfs;
                struct_rz.czxx = Struct_AQWTK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion
        #endregion


        protected int AQWTK_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_AQWTK_Detail(id);
            //备份数据
            Struct_AQWTK aqwtk_bf = new Struct_AQWTK();



            aqwtk_bf.p_gw= dt_detail.Rows[0]["gw"].ToString();
            aqwtk_bf.p_aqwtmc= dt_detail.Rows[0]["aqwtmc"].ToString();
            aqwtk_bf.p_ly= dt_detail.Rows[0]["ly"].ToString();
            aqwtk_bf.p_fssj = Convert.ToDateTime(dt_detail.Rows[0]["fssj"].ToString());
            aqwtk_bf.p_sjfc= dt_detail.Rows[0]["sjfc"].ToString();
            aqwtk_bf.p_yfyy= dt_detail.Rows[0]["yfyy"].ToString();
            aqwtk_bf.p_knzchg= dt_detail.Rows[0]["knzchg"].ToString();
            aqwtk_bf.p_xgsj= dt_detail.Rows[0]["xgsj"].ToString();
            aqwtk_bf.p_st= dt_detail.Rows[0]["st"].ToString();
            aqwtk_bf.p_hgyzcd= dt_detail.Rows[0]["hgyzcd"].ToString();
            aqwtk_bf.p_wxcd= dt_detail.Rows[0]["wxcd"].ToString();
            aqwtk_bf.p_wtaqzt= dt_detail.Rows[0]["wtaqzt"].ToString();
            aqwtk_bf.p_dxcs= dt_detail.Rows[0]["dxcs"].ToString();
            aqwtk_bf.p_zgsx = Convert.ToDateTime(dt_detail.Rows[0]["zgsx"].ToString());
            aqwtk_bf.p_zgcs= dt_detail.Rows[0]["zgcs"].ToString();
            aqwtk_bf.p_zgcsbzhqk= dt_detail.Rows[0]["zgcsbzhqk"].ToString();
            aqwtk_bf.p_wtkzzt= dt_detail.Rows[0]["wtkzzt"].ToString();
            aqwtk_bf.p_zrbm= dt_detail.Rows[0]["zrbm"].ToString();
            aqwtk_bf.p_zrgw= dt_detail.Rows[0]["zrgw"].ToString();
            aqwtk_bf.p_zrr= dt_detail.Rows[0]["zrr"].ToString();
            aqwtk_bf.p_sjbm= dt_detail.Rows[0]["sjbm"].ToString();
            aqwtk_bf.p_bz= dt_detail.Rows[0]["bz"].ToString();


            aqwtk_bf.p_zt = "0";
            aqwtk_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            aqwtk_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            aqwtk_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            aqwtk_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            aqwtk_bf.p_lrr = _us.userLoginName;
            aqwtk_bf.p_sjbs = "2";
            aqwtk_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            aqwtk_bf.p_shsj = "";
            aqwtk_bf.p_czfs = "02";
            aqwtk_bf.p_czxx = "安全问题库id:" + id + "生成副本数据";
            //插入
            Insert_AQWTK(aqwtk_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = aqwtk_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_SKJS_AQWTK.Select_AQWTK_BFID", parament, out reslut);

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
