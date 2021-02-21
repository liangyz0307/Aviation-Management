using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using CUST;
using CUST.Sys;
using Sys;

namespace CUST.MKG
{
    public struct Struct_YH
    {
        public long p_id;
        public string p_zh;
        public string p_mm;
        public string p_lb;
        public string p_mc;
        public DateTime p_yxkssj;
        public DateTime p_yxjssj;
        public string p_sfsqxyh;
        public string p_sfqy;
        public string p_xlh;
        public string p_sfscdl;
        public string p_ss;
        public string p_sfsglyh;
        public string p_czfs;
        public string p_czxx;
        //public int C_JX_YGRZ;
        //public int C_HW_JCYXXX;
        ///39个
        //员工7
        public int C_YG_XX;
        public int C_YG_ZZ;
        public int C_YG_LL;
        public int C_YG_CF;
        public int C_YG_JL;
        public int C_YG_PX;
        public int C_YG_ZC;
        //设备10
        public int C_SB_TX;
        public int C_SB_DH;
        public int C_SB_QX;
       // public int C_SB_QB;
        public int C_SB_JS;
        public int C_SB_GZ;
        public int C_SB_WH;
        public int C_SB_BJGL;
        public int C_SB_BJRK;
        public int C_SB_BJCK;
        public int C_SB_TZ;
        //后台6
        public int C_HT_ZD;
        public int C_HT_RZ;
        public int C_HT_YH;
        public int C_HT_BM;
        public int C_HT_GW;
        public int C_HT_FBGG;
       
        //资料2
        public int C_ZL_ZL;
        public int C_ZL_ZJ;
        //报送5
        public int C_BS_ZBAP;
        public int C_BS_GZJZ;
        public int C_BS_YSSB;
        public int C_BS_ZDGZ;
        public int C_BS_WXFGL;
        //安全信息4
        public int C_AQ_AQXX;
        public int C_AQ_TQCZ;
        public int C_AQ_BSSG;
        public int C_AQ_ZYBS;
        //五库建设5
        public int C_WK_SBBLK;
        public int C_WK_WXYK;
        public int C_WK_AQWTK;
        public int C_WK_AQYHK;
        public int C_WK_ZJXXK;
      









       
    }
    public struct Struct_Select_YH
    {
        public string p_bh;//员工编号
        public string p_xm;//员工姓名
        public string p_bmdm;//部门代码
        public string p_gwdm;//岗位代码
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }

    public class OYH
    {
        private UserState _us = null;
        private RZ rz = null;
        public OYH(UserState userstate)
        {
            _us = userstate;
            rz = new RZ(userstate);
        }
        protected DataSet YH_Select_SY()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_yh",OracleType.VarChar),
                                               new OracleParameter("p_czfs",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = _us.userLoginName;
                parament[1].Value = "00";
                parament[2].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_WEB_SYS.YH_Select_SY", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #region 查询
        
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="ygll"></param>
        /// <returns></returns>
        protected DataTable Select_YH_Pro(Struct_Select_YH yh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bh",OracleType.VarChar),
                    new OracleParameter("p_xm",OracleType.VarChar),
                    new OracleParameter("p_bmdm",OracleType.VarChar),
                    new OracleParameter("p_gwdm",OracleType.VarChar),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = yh.p_bh;
                paras[1].Value = yh.p_xm;
                paras[2].Value = yh.p_bmdm;
                paras[3].Value = yh.p_gwdm;
                paras[4].Value = yh.p_pagesize;
                paras[5].Value = yh.p_currentpage;
                paras[6].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HTGL_YHGL.Select_YH_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

       /// <summary>
        /// 查询用户数量
       /// </summary>
       /// <param name="yh"></param>
       /// <returns></returns>
        protected int Select_YH_Count(Struct_Select_YH yh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_bh",OracleType.VarChar),
                        new OracleParameter("p_xm",OracleType.VarChar),
                        new OracleParameter("p_bmdm",OracleType.VarChar),
                        new OracleParameter("p_gwdm",OracleType.VarChar),
                        new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = yh.p_bh;
                paras[1].Value = yh.p_xm;
                paras[2].Value = yh.p_bmdm;
                paras[3].Value = yh.p_gwdm;
                paras[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HTGL_YHGL.Select_YH_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 查询用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected DataTable Select_YH_Detail(long id)
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
                dt = dbclass.RunProcedure("PACK_HTGL_YHGL.Select_YH_Detail", paras, "table").Tables[0];
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
        /// 删除用户信息
       /// </summary>
       /// <param name="id"></param>
       /// <param name="p_czfs"></param>
       /// <param name="p_czxx"></param>
        protected void Delete_YH_byID(long id, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_HTGL_YHGL.Delete_YH_byID", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new Exception(errorCode.ToString());
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
        protected void Insert_YH(Struct_YH yh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_zh",OracleType.VarChar),
                        new OracleParameter("p_mm",OracleType.VarChar),
                        new OracleParameter("p_lb",OracleType.VarChar),
                        new OracleParameter("p_mc",OracleType.VarChar),
                        new OracleParameter("p_yxkssj",OracleType.DateTime),
                        new OracleParameter("p_yxjssj",OracleType.DateTime),
                        new OracleParameter("p_sfsqxyh",OracleType.VarChar),
                        new OracleParameter("p_sfqy",OracleType.VarChar),
                        new OracleParameter("p_xlh",OracleType.VarChar),
                        new OracleParameter("p_ss",OracleType.VarChar),
                        new OracleParameter("p_sfsglyh",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = yh.p_zh;
                paras[1].Value = yh.p_mm;
                paras[2].Value = yh.p_lb;
                paras[3].Value = yh.p_mc;
                paras[4].Value = yh.p_yxkssj;
                paras[5].Value = yh.p_yxjssj;
                paras[6].Value = yh.p_sfsqxyh;
                paras[7].Value = yh.p_sfqy;
                paras[8].Value = yh.p_xlh;
                paras[9].Value = yh.p_ss;
                paras[10].Value = yh.p_sfsglyh;
                paras[11].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_YHGL.Insert_YH", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[11].Value);
                if (errorCode != 0)
                {
                    throw new Exception(errorCode.ToString());
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = yh.p_czfs;
                struct_rz.czxx = yh.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion



        protected void Insert_Login(string p_czfs,string p_czxx)
        {
            DBClass db = new DBClass();
           

                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = p_czfs;
                struct_rz.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
        }



        #region  编辑
        protected void Update_YH(Struct_YH yh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                        new OracleParameter("p_id",OracleType.Number),
                        new OracleParameter("p_zh",OracleType.VarChar),
                        new OracleParameter("p_mm",OracleType.VarChar),
                        new OracleParameter("p_lb",OracleType.VarChar),
                        new OracleParameter("p_mc",OracleType.VarChar),
                        new OracleParameter("p_yxkssj",OracleType.DateTime),
                        new OracleParameter("p_yxjssj",OracleType.DateTime),
                        new OracleParameter("p_sfsqxyh",OracleType.VarChar),
                        new OracleParameter("p_sfqy",OracleType.VarChar),
                        new OracleParameter("p_xlh",OracleType.VarChar),
                        new OracleParameter("p_ss",OracleType.VarChar),
                        new OracleParameter("p_sfsglyh",OracleType.VarChar),
                        new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = yh.p_id;
                paras[1].Value = yh.p_zh;
                paras[2].Value = yh.p_mm;
                paras[3].Value = yh.p_lb;
                paras[4].Value = yh.p_mc;
                paras[5].Value = yh.p_yxkssj;
                paras[6].Value = yh.p_yxjssj;
                paras[7].Value = yh.p_sfsqxyh;
                paras[8].Value = yh.p_sfqy;
                paras[9].Value = yh.p_xlh;
                paras[10].Value = yh.p_ss;
                paras[11].Value = yh.p_sfsglyh;
                paras[12].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_YHGL.Update_YH", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new Exception(errorCode.ToString());
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = yh.p_czfs;
                struct_rz.czxx = yh.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion


        #region 检索页面参数更新
        protected void Update_Pager(Struct_YH yh)
        {

            DBClass db = new DBClass();
            try
            {
                OracleParameter[] pars = {
                                            new OracleParameter("p_id",OracleType.Int32),
                                             new OracleParameter("p_C_YG_XX",OracleType.Int32),
                                            new OracleParameter("p_C_YG_ZZ",OracleType.Int32),
                                            new OracleParameter("p_C_YG_LL",OracleType.Int32),
                                            new OracleParameter("p_C_YG_CF",OracleType.Int32),
                                            new OracleParameter("p_C_YG_JL",OracleType.Int32),
                                            new OracleParameter("p_C_YG_PX",OracleType.Int32),
                                            new OracleParameter("p_C_YG_ZC",OracleType.Int32),

                                            new OracleParameter("p_C_SB_TX",OracleType.Int32),
                                            new OracleParameter("p_C_SB_DH",OracleType.Int32),
                                            new OracleParameter("p_C_SB_QX",OracleType.Int32),                                         
                                            new OracleParameter("p_C_SB_JS",OracleType.Int32),
                                            new OracleParameter("p_C_SB_GZ",OracleType.Int32),
                                            new OracleParameter("p_C_SB_BJGL",OracleType.Int32),
                                            new OracleParameter("p_C_SB_BJCK",OracleType.Int32),
                                            new OracleParameter("p_C_SB_BJRK",OracleType.Int32),                                         
                                            new OracleParameter("p_C_SB_TZ",OracleType.Int32),
                                            new OracleParameter("p_C_SB_WH",OracleType.Int32),

                                            new OracleParameter("p_C_HT_ZD",OracleType.Int32),
                                            new OracleParameter("p_C_HT_RZ",OracleType.Int32),
                                            new OracleParameter("p_C_HT_YH",OracleType.Int32),
                                            new OracleParameter("p_C_HT_BM",OracleType.Int32),
                                            new OracleParameter("p_C_HT_GW",OracleType.Int32),
                                            new OracleParameter("p_C_HT_FBGG",OracleType.Int32),

                                            new OracleParameter("p_C_ZL_ZL",OracleType.Int32),
                                            new OracleParameter("p_C_ZL_ZJ",OracleType.Int32),

                                            new OracleParameter("p_C_BS_ZBAP",OracleType.Int32),
                                            new OracleParameter("p_C_BS_GZJZ",OracleType.Int32),
                                            new OracleParameter("p_C_BS_YSSB",OracleType.Int32),
                                            new OracleParameter("p_C_BS_ZDGZ",OracleType.Int32),
                                            new OracleParameter("p_C_BS_WXFGL",OracleType.Int32),

                                            new OracleParameter("p_C_AQ_AQXX",OracleType.Int32),
                                            new OracleParameter("p_C_AQ_TQCZ",OracleType.Int32),
                                            new OracleParameter("p_C_AQ_BSSG",OracleType.Int32),
                                            new OracleParameter("p_C_AQ_ZYBS",OracleType.Int32),

                                            new OracleParameter("p_C_WK_SBBLK",OracleType.Int32),
                                            new OracleParameter("p_C_WK_WXYK",OracleType.Int32),
                                            new OracleParameter("p_C_WK_AQWTK",OracleType.Int32),
                                            new OracleParameter("p_C_WK_AQYHK",OracleType.Int32),
                                            new OracleParameter("p_C_WK_ZJXXK",OracleType.Int32),
                                           
                                            new OracleParameter("p_errorCode",OracleType.Int32)

                                         };
                pars[0].Value = yh.p_id;
                pars[1].Value = yh.C_YG_XX;
                pars[2].Value = yh.C_YG_ZZ;
                pars[3].Value = yh.C_YG_LL;
                pars[4].Value = yh.C_YG_CF;
                pars[5].Value = yh.C_YG_JL;
                pars[6].Value = yh.C_YG_PX;
                pars[7].Value = yh.C_YG_ZC;

                pars[8].Value = yh.C_SB_TX;
                pars[9].Value = yh.C_SB_DH;
                pars[10].Value = yh.C_SB_QX;               
                pars[11].Value = yh.C_SB_JS;
                pars[12].Value = yh.C_SB_GZ;
                pars[13].Value = yh.C_SB_BJGL;
                pars[14].Value = yh.C_SB_BJCK;
                pars[15].Value = yh.C_SB_BJRK;
                pars[16].Value = yh.C_SB_TZ;
                pars[17].Value = yh.C_SB_WH;

                pars[18].Value = yh.C_HT_ZD;
                pars[19].Value = yh.C_HT_RZ;
                pars[20].Value = yh.C_HT_YH;
                pars[21].Value = yh.C_HT_BM;
                pars[22].Value = yh.C_HT_GW;
                pars[23].Value = yh.C_HT_FBGG;

                pars[24].Value = yh.C_ZL_ZL;
                pars[25].Value = yh.C_ZL_ZJ;

                pars[26].Value = yh.C_BS_ZBAP;
                pars[27].Value = yh.C_BS_GZJZ;
                pars[28].Value = yh.C_BS_YSSB;
                pars[29].Value = yh.C_BS_ZDGZ;
                pars[30].Value = yh.C_BS_WXFGL;

                pars[31].Value = yh.C_AQ_AQXX;
                pars[32].Value = yh.C_AQ_TQCZ;
                pars[33].Value = yh.C_AQ_BSSG;
                pars[34].Value = yh.C_AQ_ZYBS;

                pars[35].Value = yh.C_WK_SBBLK;
                pars[36].Value = yh.C_WK_WXYK;
                pars[37].Value = yh.C_WK_AQWTK;
                pars[38].Value = yh.C_WK_AQYHK;
                pars[39].Value = yh.C_WK_ZJXXK;
                
                pars[40].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HTGL_CSPZ.Update_Pager", pars, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(pars[40].Value);
                if (errorCode != 0)
                {
                    throw new Exception(errorCode.ToString());
                }
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = "02";
                struct_rz.czxx = yh.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
                //rz.Insert_XT_RZ("02", yh.p_czxx);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

    }
}
