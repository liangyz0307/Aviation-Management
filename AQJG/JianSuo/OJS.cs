using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Data.OracleClient;

namespace CUST.MKG
{

    public class OJS
    {
        private UserState ygstate;
        public struct Struct_JS
        {
            public string p_bsbh;
            public string p_bsyg;
            public string p_bsgw;
            public string p_bslx;
            public DateTime p_bssj;
            public DateTime p_jssj;
            public int p_currentpage;
            public int p_pagesize;
            public string p_czxx;
            public string p_czfs;
        }
        public struct Struct_JS_DHSB
        {
            public string p_sbbh;
            public string p_sbzl;
            public string p_sstzmc;
            public int p_pagesize;
            public int p_currentpage;
        }
        public struct Struct_JS_TXSB
        {
            public string p_sbbh;
            public string p_sbzl;
            public string p_sstzmc;
            public int p_pagesize;
            public int p_currentpage;
        }
        public struct Struct_JS_QXSB
        {
            public string p_sbbh;
            public string p_sbzl;
            public string p_sstzmc;
            public int p_pagesize;
            public int p_currentpage;
        }
        public struct Struct_JS_HTBM
        {
            public string p_bmdm;
            public string p_gwdm;
            public string p_zt;
            public int p_pagesize;
            public int p_currentpage;
        };
        public struct Struct_JS_YG
        {
            public string p_bh;
            public string p_xm;
            public string p_xbdm;
            public string p_bmdm;
            public string p_gwdm;
            public string p_zzmm;
            public int p_pagesize;
            public int p_currentpage;
        }
        public struct Struct_JS_TZ
        {
            public string p_tzbh;
            public string p_tzmc;
            public string p_tzlx;
            public string p_ssjgj;
            public string p_sqdw;
            public int p_pagesize;
            public int p_currentpage;
        }
        public struct Struct_JSBJ
        {
            public string p_bjbh;
            public string p_bjmc;
            public string p_bjfl;
            public string p_bjsy;
            public string p_cfwz;
            public int p_pagesize;
            public int p_currentpage;
        }
        public struct Struct_JSZL
        {
            public string p_zllx;
            public string p_scbm;
            public string p_scgw;
            public string p_scsj;
            public string p_jssj;
            public string p_zlbh;
            public int p_pagesize;
            public int p_currentpage;
        }
        public struct Struct_JSALK
        {
            public string p_allx;
            public string p_scbm;
            public string p_scgw;
            public string p_scsj;
            public string p_jssj;
            public string p_albh;
            public int p_pagesize;
            public int p_currentpage;
        }
        
        public struct Struct_JS_YBSB
        {
            public string p_sbbh;
            public string p_sbzl;
            public string p_sstzmc;
            public int p_pagesize;
            public int p_currentpage;
        }
        public OJS(UserState state)
        {
            ygstate = state;

        }
        #region
        /// <summary>
        /// 报送系统检索
        /// </summary>
        /// <param name="struct_js"></param>
        /// <returns></returns>
        protected DataSet Select_BS_BXD(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_BXD", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_DZQM(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_DZQM", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_FXY(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_FXY", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_GDZC(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_GDZC", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_GZJZ(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_GZJZ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_HBYXXX(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_HBYXXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_SG(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_SG", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_TQCZ(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_TQCZ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_YS(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_YS", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_ZBAP(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZBAP", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_ZDGZ(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZDGZ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_ZYBS(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Value = struct_js.p_pagesize;
                parament[6].Value = struct_js.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZYBS", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }


        protected int Select_BS_BXD_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_BXD_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_DZQM_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_DZQM_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_FXY_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_FXY_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_GDZC_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_GDZC_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_GZJZ_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_GZJZ_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_HBYXXX_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_HBYXXX_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_SG_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_SG_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_TQCZ_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_TQCZ_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_YS_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_YS_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_ZBAP_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZBAP_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_ZDGZ_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZDGZ_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_BS_ZYBS_Count(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_bsgw",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_bssj",OracleType.DateTime),
                                               new OracleParameter("p_jssj",OracleType.DateTime),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsyg;
                parament[1].Value = struct_js.p_bsgw;
                parament[2].Value = struct_js.p_bslx;
                parament[3].Value = struct_js.p_bssj;
                parament[4].Value = struct_js.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZYBS_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_BXD_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_BXD_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_DZQM_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_DZQM_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_FXY_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_FXY_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_GDZC_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_GDZC_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_GZJZ_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_GZJZ_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_HBYXXX_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_HBYXXX_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_SG_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_SG_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_TQCZ_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_TQCZ_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_YS_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_YS_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_ZBAP_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZBAP_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_ZDGZ_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZDGZ_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_BS_ZYBS_Detail(Struct_JS struct_js)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsbh",OracleType.VarChar),
                                               new OracleParameter("p_bslx",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js.p_bsbh;
                parament[1].Value = struct_js.p_bslx;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_BS_ZYBS_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region
        /// <summary>
        /// 设备检索系统
        /// </summary>
        /// <param name="struct_js"></param>
        /// <returns></returns>
        protected DataSet Select_JS_DHSB(Struct_JS_DHSB struct_js_dhsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_dhsb.p_sbbh;
                parament[1].Value = struct_js_dhsb.p_sbzl;
                parament[2].Value = struct_js_dhsb.p_sstzmc;
                parament[3].Value = struct_js_dhsb.p_pagesize;
                parament[4].Value = struct_js_dhsb.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_DHSB", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_YBSB(Struct_JS_YBSB struct_js_ybsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_ybsb.p_sbbh;
                parament[1].Value = struct_js_ybsb.p_sbzl;
                parament[2].Value = struct_js_ybsb.p_sstzmc;
                parament[3].Value = struct_js_ybsb.p_pagesize;
                parament[4].Value = struct_js_ybsb.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YBSB", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_TXSB(Struct_JS_TXSB struct_js_txsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_txsb.p_sbbh;
                parament[1].Value = struct_js_txsb.p_sbzl;
                parament[2].Value = struct_js_txsb.p_sstzmc;
                parament[3].Value = struct_js_txsb.p_pagesize;
                parament[4].Value = struct_js_txsb.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_TXSB", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_QXSB(Struct_JS_QXSB struct_js_qxsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_qxsb.p_sbbh;
                parament[1].Value = struct_js_qxsb.p_sbzl;
                parament[2].Value = struct_js_qxsb.p_sstzmc;
                parament[3].Value = struct_js_qxsb.p_pagesize;
                parament[4].Value = struct_js_qxsb.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_QXSB", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_DHSBCount(Struct_JS_DHSB struct_js_dhsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_dhsb.p_sbbh;
                parament[1].Value = struct_js_dhsb.p_sbzl;
                parament[2].Value = struct_js_dhsb.p_sstzmc;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_DHSBCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected int Select_JS_YBSBCount(Struct_JS_YBSB struct_js_ybsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_ybsb.p_sbbh;
                parament[1].Value = struct_js_ybsb.p_sbzl;
                parament[2].Value = struct_js_ybsb.p_sstzmc;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YBSBCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_TXSBCount(Struct_JS_TXSB struct_js_txsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_txsb.p_sbbh;
                parament[1].Value = struct_js_txsb.p_sbzl;
                parament[2].Value = struct_js_txsb.p_sstzmc;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_TXSBCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_QXSBCount(Struct_JS_QXSB struct_js_qxsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_sbzl",OracleType.VarChar),
                                               new OracleParameter("p_sstzmc",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_qxsb.p_sbbh;
                parament[1].Value = struct_js_qxsb.p_sbzl;
                parament[2].Value = struct_js_qxsb.p_sstzmc;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_QXSBCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataSet Select_JS_DHSBDetail(Struct_JS_DHSB struct_js_dhsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_dhsb.p_sbbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_DHSBDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_YBSBDetail(Struct_JS_YBSB struct_js_ybsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_ybsb.p_sbbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YBSBDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_TXSBDetail(Struct_JS_TXSB struct_js_txsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value =  struct_js_txsb.p_sbbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_TXSBDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_QXSBDetail(Struct_JS_QXSB struct_js_qxsb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_sbbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_qxsb.p_sbbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_QXSBDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  员工
        protected DataSet Select_JS_YGXX(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_xm",OracleType.VarChar),
                                               new OracleParameter("p_xb",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_zzmm",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Value = struct_js_yg.p_xm;
                parament[2].Value = struct_js_yg.p_xbdm;
                parament[3].Value = struct_js_yg.p_bmdm;
                parament[4].Value = struct_js_yg.p_gwdm;
                parament[5].Value = struct_js_yg.p_zzmm;
                parament[6].Value = struct_js_yg.p_pagesize;
                parament[7].Value = struct_js_yg.p_currentpage;
                parament[8].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YGXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_YGCount(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_xm",OracleType.VarChar),
                                               new OracleParameter("p_xb",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_zzmm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Value = struct_js_yg.p_xm;
                parament[2].Value = struct_js_yg.p_xbdm;
                parament[3].Value = struct_js_yg.p_bmdm;
                parament[4].Value = struct_js_yg.p_gwdm;
                parament[5].Value = struct_js_yg.p_zzmm;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YGCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_YGLLDetail(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_YGLLDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_YGZZDetail(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YGZZDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //新的
        protected DataSet Select_JS_YGDetail(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_YGDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //新的
        protected DataSet Select_YGLL_Detail(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_YGLL_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //新的
        protected DataSet Select_YGZZ_Detail(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_yycur",OracleType.Cursor),
                                                new OracleParameter("p_zzcur",OracleType.Cursor),
                                                 new OracleParameter("p_qzcur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Direction = ParameterDirection.Output;
                parament[2].Direction = ParameterDirection.Output;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_YGZZ_Detail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion        
        #region
        /// <summary>
        /// 后台部门系统检索
        /// </summary>
        /// <param name="struct_js"></param>
        /// <returns></returns>
        protected DataSet Select_JS_HTXX(Struct_JS_HTBM struct_js_htbm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value =struct_js_htbm.p_bmdm;
                parament[1].Value =struct_js_htbm.p_gwdm;
                parament[2].Value = struct_js_htbm.p_zt;
                parament[3].Value = struct_js_htbm.p_pagesize;
                parament[4].Value = struct_js_htbm.p_currentpage;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_HTXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_HTXXCount(Struct_JS_HTBM struct_js_htbm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_htbm.p_bmdm;
                parament[1].Value = struct_js_htbm.p_gwdm;
                parament[2].Value = struct_js_htbm.p_zt;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_HTXXCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_HTXXDetail(Struct_JS_HTBM struct_js_htbm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_htbm.p_bmdm;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_HTXXDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region//门户
        protected DataSet Select_JS_DBSX(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_DBSX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //检索有效期提醒
        protected DataSet Select_JS_YGZZYXQ(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_yydj",OracleType.Cursor),
                                                new OracleParameter("p_tjdj",OracleType.Cursor),
                                                 new OracleParameter("p_ydqz",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                parament[2].Direction = ParameterDirection.Output;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_YGZZYXQ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //检索有效期详情
        protected DataSet Select_YXQ(string id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_id",OracleType.VarChar),
                                                 new OracleParameter("p_yydj",OracleType.Cursor),
                                                 new OracleParameter("p_tjdj",OracleType.Cursor),
                                                 new OracleParameter("p_ydqz",OracleType.Cursor)
                                            };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                parament[2].Direction = ParameterDirection.Output;
                parament[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_YXQ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_YGID(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_YGID", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
       
        protected DataSet Select_JS_GG(string bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                              
                                               new OracleParameter("p_bmdm",OracleType.Number),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = bmdm;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_GG", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_GGDetail(int id)
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
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_GGDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion
        protected DataSet Select_JS_GGBM()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                             
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };

                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_GGBM", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #region   //备件出库
        protected DataSet Select_JS_BJDetail(Struct_JSBJ struct_bj)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_bj.p_bjbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_BJDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_BJCKDetail(Struct_JSBJ struct_bj)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_bj.p_bjbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_BJCKDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_BJRKDetail(Struct_JSBJ struct_bj)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_bj.p_bjbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_BJRKDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_BJ(Struct_JSBJ struct_bj)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjmc",OracleType.VarChar),
                                               new OracleParameter("p_bjfl",OracleType.VarChar),
                                               new OracleParameter("p_bjsy",OracleType.VarChar),
                                               new OracleParameter("p_cfwz",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_bj.p_bjmc;
                parament[1].Value = struct_bj.p_bjfl;
                parament[2].Value = struct_bj.p_bjsy;
                parament[3].Value = struct_bj.p_cfwz;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_BJ", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_BJXX(Struct_JSBJ struct_bj)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bjmc",OracleType.VarChar),
                                               new OracleParameter("p_bjfl",OracleType.VarChar),
                                               new OracleParameter("p_bjsy",OracleType.VarChar),
                                                new OracleParameter("p_cfwz",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_bj.p_bjmc;
                parament[1].Value = struct_bj.p_bjfl;
                parament[2].Value = struct_bj.p_bjsy;
                parament[3].Value = struct_bj.p_cfwz;
                parament[4].Value = struct_bj.p_pagesize;
                parament[5].Value = struct_bj.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_BJXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        #endregion
        #region//台站
        protected DataSet Select_JS_TZXX(Struct_JS_TZ struct_js_tz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_tzmc",OracleType.VarChar),
                                               new OracleParameter("p_tzlx",OracleType.VarChar),
                                               new OracleParameter("p_ssjgj",OracleType.VarChar),
                                               new OracleParameter("p_sqdw",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_tz.p_tzmc;
                parament[1].Value = struct_js_tz.p_tzlx;
                parament[2].Value = struct_js_tz.p_ssjgj;
                parament[3].Value = struct_js_tz.p_sqdw;
                parament[4].Value = struct_js_tz.p_pagesize;
                parament[5].Value = struct_js_tz.p_currentpage;
                parament[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_TZXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_TZXXCount(Struct_JS_TZ struct_js_tz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_tzmc",OracleType.VarChar),
                                               new OracleParameter("p_tzlx",OracleType.VarChar),
                                               new OracleParameter("p_ssjgj",OracleType.VarChar),
                                               new OracleParameter("p_sqdw",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_tz.p_tzmc;
                parament[1].Value = struct_js_tz.p_tzlx;
                parament[2].Value = struct_js_tz.p_ssjgj;
                parament[3].Value = struct_js_tz.p_sqdw;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_TZXXCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_TZXXDetail(Struct_JS_TZ struct_js_tz)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_tzbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_tz.p_tzbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_TZXXDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region
        //档案
        protected DataSet Select_JS_YGDA(Struct_JS_YG struct_js_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_js_yg.p_bh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YGDA", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
       //快捷入口
        protected DataSet Select_JS_YGLL(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YGLL", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_YGZZ(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_YGZZ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_ZL(string scyh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_scyh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = scyh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ZL", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_ZYBS(string bsyg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bsyg",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = bsyg;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ZYBS", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region
        //查询公告之日历显示
        protected DataSet Select_JS_GGrl(string time)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bh",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_sj",OracleType.Int32),
                                               new OracleParameter("p_ggrl",OracleType.Cursor),
                                               new OracleParameter("p_zz",OracleType.Cursor),
                                               new OracleParameter("p_yd",OracleType.Cursor),
                                               new OracleParameter("p_yy",OracleType.Cursor),
                                               new OracleParameter("p_tj",OracleType.Cursor)
                                            };
                parament[0].Value = ygstate.userLoginName;
                parament[1].Value = ygstate.userBMDM;
                parament[2].Value = time;
                parament[3].Direction = ParameterDirection.Output;
                parament[4].Direction = ParameterDirection.Output;
                parament[5].Direction = ParameterDirection.Output;
                parament[6].Direction = ParameterDirection.Output;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_GGrl", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
         
        }
        //查询设备之日历显示
        protected DataSet Select_JS_SBrl(string time)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                new OracleParameter("p_sj",OracleType.VarChar),
                                                new OracleParameter("p_dhzz",OracleType.Cursor),
                                                new OracleParameter("p_dhfx",OracleType.Cursor),
                                                new OracleParameter("p_txzz",OracleType.Cursor),
                                                new OracleParameter("p_txfx",OracleType.Cursor),
                                                new OracleParameter("p_qxcgq",OracleType.Cursor)
                                            };
                parament[0].Value = time;
                parament[1].Direction = ParameterDirection.Output;
                parament[2].Direction = ParameterDirection.Output;
                parament[3].Direction = ParameterDirection.Output;
                parament[4].Direction = ParameterDirection.Output;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_SBrl", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询公告之日历显示
        protected DataSet Select_JS_YGrl()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygstate.userLoginName;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_YGrl", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
            return null;
        }
        #endregion
        #region 
        //页面分配
        protected DataSet Select_JS_KJRK(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value =ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_KJRK", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
       
       protected void Insert_FPKJRK( string ygbh,string ymdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_ymdm",OracleType.VarChar),
                                                  new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parament[0].Value = ygbh;
                parament[1].Value = ymdm;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                int rowsAffected = 0;
                 dbclass.RunProcedure("PACK_XXMH.Insert_FPKJRK", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new Exception(errorCode.ToString());
                }
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Delete_FPKJRK(string ygbh, string ymdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                 new OracleParameter("p_ygbh",OracleType.VarChar),
                                                 new OracleParameter("p_ymdm",OracleType.VarChar),
                                                  new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parament[0].Value = ygbh;
                parament[1].Value = ymdm;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                int rowsAffected = 0;
                dbclass.RunProcedure("PACK_XXMH.Delete_FPKJRK", parament, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(parament[2].Value);
                if (errorCode != 0)
                {
                    throw new Exception(errorCode.ToString());
                }
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_FPKJRK(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_FPKJRK", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        
        protected DataSet Select_JS_WFPKJRK(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_JS_WFPKJRK", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region
        //资料库案例库
        protected DataSet Select_JS_ZLXX(Struct_JSZL struct_jszl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zllx",OracleType.VarChar),
                                               new OracleParameter("p_scbm",OracleType.VarChar),
                                               new OracleParameter("p_scgw",OracleType.VarChar),
                                               new OracleParameter("p_scsj",OracleType.VarChar),
                                               new OracleParameter("p_jssj",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jszl.p_zllx;
                parament[1].Value = struct_jszl.p_scbm;
                parament[2].Value = struct_jszl.p_scgw;
                parament[3].Value = struct_jszl.p_scsj;
                parament[4].Value = struct_jszl.p_jssj;
                parament[5].Value = struct_jszl.p_pagesize;
                parament[6].Value = struct_jszl.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ZLXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_ALXX(Struct_JSALK struct_jsalk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_allx",OracleType.VarChar),
                                               new OracleParameter("p_scbm",OracleType.VarChar),
                                               new OracleParameter("p_scgw",OracleType.VarChar),
                                               new OracleParameter("p_scsj",OracleType.VarChar),
                                               new OracleParameter("p_jssj",OracleType.VarChar),
                                               new OracleParameter("p_pagesize",OracleType.Int32),
                                               new OracleParameter("p_currentpage",OracleType.Int32),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jsalk.p_allx;
                parament[1].Value = struct_jsalk.p_scbm;
                parament[2].Value = struct_jsalk.p_scgw;
                parament[3].Value = struct_jsalk.p_scsj;
                parament[4].Value = struct_jsalk.p_jssj;
                parament[5].Value = struct_jsalk.p_pagesize;
                parament[6].Value = struct_jsalk.p_currentpage;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ALXX", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_ZLCount(Struct_JSZL struct_jszl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zllx",OracleType.VarChar),
                                               new OracleParameter("p_scbm",OracleType.VarChar),
                                               new OracleParameter("p_scgw",OracleType.VarChar),
                                               new OracleParameter("p_scsj",OracleType.VarChar),
                                               new OracleParameter("p_jssj",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jszl.p_zllx;
                parament[1].Value = struct_jszl.p_scbm;
                parament[2].Value = struct_jszl.p_scgw;
                parament[3].Value = struct_jszl.p_scsj;
                parament[4].Value = struct_jszl.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ZLCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected int Select_JS_ALCount(Struct_JSALK struct_jsalk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_allx",OracleType.VarChar),
                                               new OracleParameter("p_scbm",OracleType.VarChar),
                                               new OracleParameter("p_scgw",OracleType.VarChar),
                                               new OracleParameter("p_scsj",OracleType.VarChar),
                                               new OracleParameter("p_jssj",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jsalk.p_allx;
                parament[1].Value = struct_jsalk.p_scbm;
                parament[2].Value = struct_jsalk.p_scgw;
                parament[3].Value = struct_jsalk.p_scsj;
                parament[4].Value = struct_jsalk.p_jssj;
                parament[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ALCount", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected DataSet Select_JS_ZLDetail(Struct_JSZL struct_jszl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_zlbh",OracleType.VarChar),
                                             
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jszl.p_zlbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ZLDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_JS_ALDetail(Struct_JSALK struct_jsalk)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_albh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = struct_jsalk.p_albh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_JSXT.Select_JS_ALDetail", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
       

        //设备有效期
        protected DataSet Select_MH_DHSBYXQ()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };

                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_MH_DHSBYXQ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_MH_TXSBYXQ(string ygbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_ygbh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value =ygbh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_MH_TXSBYXQ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_MH_QXSBYXQ()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };

                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_MH_QXSBYXQ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected DataSet Select_MH_YBSBYXQ()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };

                parament[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_XXMH.Select_MH_YBSBYXQ", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
    }
}

