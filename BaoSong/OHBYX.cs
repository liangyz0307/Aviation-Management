using System;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_HBYX
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bslx;
        public string p_bsip;
        public DateTime  p_bssj;
        public string p_hbh;
        public string p_hblx;
        public string p_zxmc;
        public string p_qxqk;
        public string p_cfcs;
        public string p_ddcs;
        public DateTime p_cfrq;
        public DateTime p_ddrq;
        public string p_spr;
        public string p_czfs;
        public string p_czxx;
        public string p_bsgw;
        public string p_yxqk;
        public string p_yy;
    }
    public struct Struct_Select_HBYX
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bslx;
        public string p_hbh;
        public string p_hblx;
        public string p_zxmc;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
    public class OHBYX
    {
        private UserState _us = null;
        private RZ rz = null;
        public OHBYX(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询员工资质表信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_HBYX_Pro(Struct_Select_HBYX hb)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_bsbh",OracleType.VarChar),
                    new OracleParameter("p_bsyg",OracleType.VarChar),
                    new OracleParameter("p_bslx",OracleType.VarChar),
                    new OracleParameter("p_hbh",OracleType.VarChar),
                    new OracleParameter("p_hblx",OracleType.VarChar),
                    new OracleParameter("p_zxmc",OracleType.VarChar),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = hb.p_bsbh;
                paras[1].Value = hb.p_bsyg;
                paras[2].Value = hb.p_bslx;
                paras[3].Value = hb.p_hbh;
                paras[4].Value = hb.p_hblx;
                paras[5].Value = hb.p_zxmc;
                paras[6].Value = hb.p_pagesize;
                paras[7].Value = hb.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_HBYX.Select_HBYX_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询员工资质数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_HBYX_Count(Struct_Select_HBYX hb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bsbh",OracleType.VarChar),
                                           new OracleParameter("p_bsyg",OracleType.VarChar),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_hbh",OracleType.VarChar),
                                           new OracleParameter("p_hblx",OracleType.VarChar),
                                           new OracleParameter("p_zxmc",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = hb.p_bsbh;
                paras[1].Value = hb.p_bsyg;
                paras[2].Value = hb.p_bslx;
                paras[3].Value = hb.p_hbh;
                paras[4].Value = hb.p_hblx;
                paras[5].Value = hb.p_zxmc;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_HBYX.Select_HBYX_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 查询详情
        /// </summary>
        /// <param name="bsbh"></param>
        /// <returns></returns>
        protected DataTable Select_HBXX_Detail(string bsbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bsbh",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bsbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_HBYX.Select_HBXX_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 查询十位流水号
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected string  SelectBS_HBYXMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                         
                                           new OracleParameter("p_maxbh",OracleType.VarChar,16)
                  };
                paras[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_HBYX.SelectBS_HBYXMaxBH", paras, "tables");
                string maxbh = "";
                maxbh = paras[0].Value.ToString();
                return maxbh;


            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bsbh"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_HBYX_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_bsbh",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = bsbh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_HBYX.Delete_HBYX_byBH", paras, out rowsAffected);
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
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="hb"></param>
        protected void Insert_HBYX(Struct_HBYX hb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_bsbh",OracleType.VarChar),   
                  new OracleParameter("p_bsyg",OracleType.VarChar),
                  new OracleParameter("p_bslx",OracleType.VarChar),
                  new OracleParameter("p_bsip",OracleType.VarChar),
                  new OracleParameter("p_bssj",OracleType.DateTime),
                  new OracleParameter("p_hbh",OracleType.VarChar),
                  new OracleParameter("p_hblx",OracleType.VarChar),
                  new OracleParameter("p_zxmc",OracleType.VarChar),
                  new OracleParameter("p_qxqk",OracleType.VarChar),
                  new OracleParameter("p_cfcs",OracleType.VarChar),
                  new OracleParameter("p_ddcs",OracleType.VarChar),
                  new OracleParameter("p_cfrq",OracleType.DateTime),
                  new OracleParameter("p_ddrq",OracleType.DateTime),
                  new OracleParameter("p_spr",OracleType.VarChar),
                  new OracleParameter("p_bsgw",OracleType.VarChar),
                    new OracleParameter("p_yxqk",OracleType.VarChar),
                      new OracleParameter("p_yy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };      paras[0].Value = hb.p_bsbh;
                paras[1].Value = hb.p_bsyg;
                paras[2].Value = hb.p_bslx;
                paras[3].Value = hb.p_bsip;
                paras[4].Value = hb.p_bssj;
                paras[5].Value = hb.p_hbh;
                paras[6].Value = hb.p_hblx;
                paras[7].Value = hb.p_zxmc;
                paras[8].Value = hb.p_qxqk;
                paras[9].Value = hb.p_cfcs;
                paras[10].Value = hb.p_ddcs;
                paras[11].Value = hb.p_cfrq;
                paras[12].Value = hb.p_ddrq;
                paras[13].Value = hb.p_spr;
                paras[14].Value = hb.p_bsgw;
                paras[15].Value = hb.p_yxqk;
                paras[16].Value = hb.p_yy;
                paras[17].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_HBYX.Insert_HBYX", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[17].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = hb.p_czfs;
                struct_rz.czxx = hb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="hb"></param>
        protected void Update_HBYX(Struct_HBYX hb)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_bsbh",OracleType.VarChar),
                  new OracleParameter("p_bsyg",OracleType.VarChar),
                  new OracleParameter("p_bslx",OracleType.VarChar),
                  new OracleParameter("p_bsip",OracleType.VarChar),
                  new OracleParameter("p_bssj",OracleType.DateTime),
                  new OracleParameter("p_hbh",OracleType.VarChar),
                  new OracleParameter("p_hblx",OracleType.VarChar),
                  new OracleParameter("p_zxmc",OracleType.VarChar),
                  new OracleParameter("p_qxqk",OracleType.VarChar),
                  new OracleParameter("p_cfcs",OracleType.VarChar),
                  new OracleParameter("p_ddcs",OracleType.VarChar),
                  new OracleParameter("p_cfrq",OracleType.DateTime),
                  new OracleParameter("p_ddrq",OracleType.DateTime),
                  new OracleParameter("p_spr",OracleType.VarChar),
                   new OracleParameter("p_bsgw",OracleType.VarChar),
                   new OracleParameter("p_yxqk",OracleType.VarChar),
                      new OracleParameter("p_yy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = hb.p_bsbh;
                paras[1].Value = hb.p_bsyg;
                paras[2].Value = hb.p_bslx;
                paras[3].Value = hb.p_bsip;
                paras[4].Value = hb.p_bssj;
                paras[5].Value = hb.p_hbh;
                paras[6].Value = hb.p_hblx;
                paras[7].Value = hb.p_zxmc;
                paras[8].Value = hb.p_qxqk;
                paras[9].Value = hb.p_cfcs;
                paras[10].Value = hb.p_ddcs;
                paras[11].Value = hb.p_cfrq;
                paras[12].Value = hb.p_ddrq;
                paras[13].Value = hb.p_spr;
                paras[14].Value = hb.p_bsgw;
                paras[15].Value = hb.p_yxqk;
                paras[16].Value = hb.p_yy;
                paras[17].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                 db.RunProcedure("PACK_HWZHBS_HBYX.Update_HBYX", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[17].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = hb.p_czfs;
                struct_rz.czxx = hb.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion



    }
}
