using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_SG
    {
        public string p_bsbh;
        public string p_bsyg;
        public string p_bsgw;
        public DateTime p_xtsj;
        public string p_bsip;
        public DateTime p_bssj;
        public DateTime p_sfsj;
        public string p_spr;
        public string p_bz;
        public string p_sgxq;
        public string p_sgfzr;
        public string p_czfs;
        public string p_czxx;
        public string p_fzr;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public string  p_zt;
        public string p_bhyy;
        public string p_bmdm;
        public string p_gwdm;
        public int p_userid;
        public int p_id;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
    }
   
    public class OSG
    {
        private UserState _us = null;
        private RZ rz = null;
        public OSG(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询事故表信息
        /// </summary>
        /// <param name="sg"></param>
        /// <returns></returns>
        protected DataTable Select_SG_Pro(Struct_SG sg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     
                                         new OracleParameter("p_bsgw",OracleType.VarChar),
                                         new OracleParameter("p_bsyg",OracleType.VarChar),
                                         new OracleParameter("p_kssj",OracleType.DateTime),
                                         new OracleParameter("p_jssj",OracleType.DateTime),
                                         new OracleParameter("p_zt",OracleType.VarChar),
                                         new OracleParameter("p_userid",OracleType.VarChar),
                                         new OracleParameter("p_pagesize",OracleType.Int32),
                                         new OracleParameter("p_currentpage",OracleType.Int32),
                                         new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = sg.p_bsgw;
                paras[1].Value = sg.p_bsyg;
                paras[2].Value = sg.p_kssj;
                paras[3].Value = sg.p_jssj;
                paras[4].Value = sg.p_zt;
                paras[5].Value = sg.p_userid;
                paras[6].Value = sg.p_pagesize;
                paras[7].Value = sg.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_SG.Select_SG_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询事故数量
        /// </summary>
        /// <param name="sg"></param>
        /// <returns></returns>
        protected int Select_SG_Count(Struct_SG sg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                        new OracleParameter("p_bsgw",OracleType.VarChar),
                                         new OracleParameter("p_bsyg",OracleType.VarChar),
                                         new OracleParameter("p_kssj",OracleType.DateTime),
                                         new OracleParameter("p_jssj",OracleType.DateTime),
                                         new OracleParameter("p_zt",OracleType.VarChar),
                                         new OracleParameter("p_userid",OracleType.VarChar),
                                         new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = sg.p_bsgw;
                paras[1].Value = sg.p_bsyg;
                paras[2].Value = sg.p_kssj;
                paras[3].Value = sg.p_jssj;
                paras[4].Value = sg.p_zt;
                paras[5].Value = sg.p_userid;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_SG.Select_SG_Count", paras, "tables");
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
        protected DataTable Select_SG_Detail(string bsbh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bsbh",OracleType.VarChar),
                                           new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bsbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = db.RunProcedure("PACK_HWZHBS_SG.Select_SG_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 报送编号十位流水号生成
        /// </summary>
        /// <returns></returns>
        protected string SelectBS_SGMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_HWZHBS_SG.SelectBS_SGMaxBH", paras);
                string maxbh = paras[0].Value.ToString();
                return maxbh;
            }
            finally
            {
                db.Close();
            }
        }
 

        /// <summary>
        /// 查询负责人
        /// </summary>
        /// <param name="fxy"></param>
        /// <returns></returns>
        protected DataTable Select_FZR(Struct_SG sg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                        new OracleParameter("p_bmdm",OracleType.VarChar),
                                        new OracleParameter("p_gwdm",OracleType.VarChar),
                                        new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = sg.p_bmdm;
                paras[1].Value = sg.p_gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_SG.Select_FZR", paras, "table").Tables[0];
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
        /// 删除
        /// </summary>
        /// <param name="bsbh"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>
        protected void Delete_SG_byBH(string bsbh, string p_czfs, string p_czxx)
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
                db.RunProcedure("PACK_HWZHBS_SG.Delete_SG_byBH", paras, out rowsAffected);
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
        /// <param name="sg"></param>
        protected void Insert_SG(Struct_SG sg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                           new OracleParameter("p_bsbh",OracleType.VarChar),
                                           new OracleParameter("p_bsyg",OracleType.VarChar),
                                           new OracleParameter("p_bsgw",OracleType.VarChar),
                                           new OracleParameter("p_xtsj",OracleType.DateTime),
                                           new OracleParameter("p_bsip",OracleType.VarChar),
                                           new OracleParameter("p_bssj",OracleType.DateTime),
                                           new OracleParameter("p_sfsj",OracleType.DateTime),
                                           new OracleParameter("p_sgxq",OracleType.VarChar),
                                           new OracleParameter("p_sgfzr",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                           new OracleParameter("p_zt",OracleType.VarChar),
                                           new OracleParameter("p_bhyy",OracleType.VarChar),
                                           new OracleParameter("p_errorCode",OracleType.Int32)
                                         };
                paras[0].Value = sg.p_bsbh;
                paras[1].Value = sg.p_bsyg;
                paras[2].Value = sg.p_bsgw;
                paras[3].Value = sg.p_xtsj;
                paras[4].Value = sg.p_bsip;
                paras[5].Value = sg.p_bssj;
                paras[6].Value = sg.p_sfsj;
                paras[7].Value = sg.p_sgxq;
                paras[8].Value = sg.p_sgfzr;
                paras[9].Value = sg.p_bz;
                paras[10].Value = "0";
                paras[11].Value = "";
                paras[12].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_SG.Insert_SG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[12].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = sg.p_czfs;
                struct_rz.czxx = sg.p_czxx;
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
        /// <param name="sg"></param>
        protected void Update_SG(Struct_SG sg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                            new OracleParameter("p_bsbh",OracleType.VarChar),
                                           new OracleParameter("p_bsyg",OracleType.VarChar),
                                           new OracleParameter("p_bsgw",OracleType.VarChar),
                                           new OracleParameter("p_xtsj",OracleType.DateTime),
                                           new OracleParameter("p_bsip",OracleType.VarChar),
                                           new OracleParameter("p_bssj",OracleType.DateTime),
                                           new OracleParameter("p_sfsj",OracleType.DateTime),
                                           new OracleParameter("p_sgxq",OracleType.VarChar),
                                           new OracleParameter("p_sgfzr",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                            new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = sg.p_bsbh;
                paras[1].Value = sg.p_bsyg;
                paras[2].Value = sg.p_bsgw;
                paras[3].Value = sg.p_xtsj;
                paras[4].Value = sg.p_bsip;
                paras[5].Value = sg.p_bssj;
                paras[6].Value = sg.p_sfsj;
                paras[7].Value = sg.p_sgxq;
                paras[8].Value = sg.p_sgfzr;
                paras[9].Value = sg.p_bz;
                paras[10].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_SG.Update_SG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[10].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = sg.p_czfs;
                struct_rz.czxx = sg.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        protected void Update_BSSGZT(int id, string zt, string bhyy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Int32),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = id;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_SG.Update_BSSGZT", paras, out rowsAffected);
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
        }
    }
}
