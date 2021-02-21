using System;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public struct Struct_ZYBS
    {
        public string p_bsbh;//报送编号         16位 （6位岗位部门+10位流水号）
        public string p_bsyg;//报送员工          外键，关联YG表YGBH
        public string p_bsgw;//报送岗位          外键，关联GW表GWDM
        public string p_bslx;//报送类型          01：航班02：特情03：值班04：工作进展05：重点工作06:风险源分析07预算08固定资产09报销单10自愿报送11事故12电子签名等
        public string p_bsip;//报送IP
        public DateTime p_bssj;//报送时间
        public string p_bsms;//报送描述
        public string p_jjfa;//解决方案
        public string p_spr;//审批人                外键，关联YG表YGBH
        public string p_bz;//备注
        public string p_czfs ;
        public string p_czxx;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_zt;
        public string p_bhyy;
        public DateTime p_xtsj;
        public DateTime p_kssj;
        public DateTime p_jssj;
        public int p_userid;
        public int p_id;
        public string p_sfzh;
        public string p_gw;
        //public string p_bh;//员工编号1
        public string p_zplj;//照片路径
    }
    public class OZYBS
    {
        private UserState _us = null;
        private RZ rz = null;
        public OZYBS(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询自愿报送表基本信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable SelectBS_ZYBS_Pro(Struct_ZYBS struct_select_zybs)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                      
                                        new OracleParameter("p_bsyg",OracleType.VarChar),
                                        new OracleParameter("p_bsgw",OracleType.VarChar),
                                        new OracleParameter("p_bslx",OracleType.VarChar),
                                        new OracleParameter("p_kssj",OracleType.DateTime),
                                        new OracleParameter("p_jssj",OracleType.DateTime),
                                        new OracleParameter("p_userid",OracleType.Int32),
                                        new OracleParameter("p_pagesize",OracleType.Int32),
                                        new OracleParameter("p_currentpage",OracleType.Int32),
                                        new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_select_zybs.p_bsyg;
                paras[1].Value = struct_select_zybs.p_bsgw;
                paras[2].Value = struct_select_zybs.p_bslx;
                paras[3].Value = struct_select_zybs.p_kssj;
                paras[4].Value = struct_select_zybs.p_jssj;
                paras[5].Value = struct_select_zybs.p_userid;
                paras[6].Value = struct_select_zybs.p_pagesize;
                paras[7].Value = struct_select_zybs.p_currentpage;
                paras[8].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_ZYBS.SelectBS_ZYBS_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        /// <summary>
        /// 查询固定资产数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int SelectBS_ZYBS_Count(Struct_ZYBS struct_select_zybs)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                             new OracleParameter("p_bsyg",OracleType.VarChar),
                                             new OracleParameter("p_bsgw",OracleType.VarChar),
                                             new OracleParameter("p_bslx",OracleType.VarChar),
                                             new OracleParameter("p_kssj",OracleType.DateTime),
                                             new OracleParameter("p_jssj",OracleType.DateTime),
                                             new OracleParameter("p_userid",OracleType.Int32),
                                             new OracleParameter("p_cur",OracleType.Cursor)
                  };
                paras[0].Value = struct_select_zybs.p_bsyg;
                paras[1].Value = struct_select_zybs.p_bsgw;
                paras[2].Value = struct_select_zybs.p_bslx;
                paras[3].Value = struct_select_zybs.p_kssj;
                paras[4].Value = struct_select_zybs.p_jssj;
                paras[5].Value = struct_select_zybs.p_userid;
                paras[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_ZYBS.SelectBS_ZYBS_Count", paras, "tables");
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
        protected DataTable SelectBS_ZYBS_Detail(string bsbh)
        {
            DBClass dbclass = new DBClass();
             try{
                  OracleParameter[] paras ={
                                                 new OracleParameter("p_bsbh",OracleType.VarChar),
                                                  new OracleParameter("p_cur",OracleType.Cursor)
                                             };
               paras[0].Value = bsbh;
               paras[1].Direction = ParameterDirection.Output;
               DataTable dt = new DataTable();
               dt = dbclass.RunProcedure("PACK_HWZHBS_ZYBS.SelectBS_ZYBS_Detail", paras, "table").Tables[0];
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
        protected string SelectBS_ZYBSMaxBH()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                                           new OracleParameter("p_maxbh",OracleType.VarChar,16)
                  };
                paras[0].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_ZYBS.SelectBS_ZYBSMaxBH", paras, "tables");
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
        /// 删除自愿报送信息
        /// </summary>
        /// <param name="bsbh"></param>
        /// <param name="p_czfs"></param>
        /// <param name="p_czxx"></param>

        protected void DeleteBS_ZYBS_byBH(string p_bsbh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_bsbh",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_bsbh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZYBS.DeleteBS_ZYBS_byBH", paras, out rowsAffected);
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
        /// 添加BS_ZYBS表数据信息
        /// </summary>
        protected void InsertBS_ZYBS(Struct_ZYBS struct_zybs)
        {
            DBClass db = new DBClass(); try
            {
                OracleParameter[] paras = {
                                           new OracleParameter("p_bsbh",OracleType.VarChar),
                                           new OracleParameter("p_bsyg",OracleType.VarChar),
                                           new OracleParameter("p_bsgw",OracleType.VarChar),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_bsip",OracleType.VarChar),
                                           new OracleParameter("p_bssj",OracleType.DateTime),
                                           new OracleParameter("p_bsms",OracleType.VarChar),
                                           new OracleParameter("p_jjfa",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                           new OracleParameter("p_bhyy",OracleType.VarChar),
                                           new OracleParameter("p_xtsj",OracleType.DateTime),
                                           new OracleParameter("p_errorCode",OracleType.Int32)
                };
                paras[0].Value = struct_zybs.p_bsbh;
                paras[1].Value = struct_zybs.p_bsyg;
                paras[2].Value = struct_zybs.p_bsgw;
                paras[3].Value = struct_zybs.p_bslx;
                paras[4].Value = struct_zybs.p_bsip;
                paras[5].Value = struct_zybs.p_bssj;
                paras[6].Value = struct_zybs.p_bsms;
                paras[7].Value = struct_zybs.p_jjfa;
                paras[8].Value = struct_zybs.p_bz;
                paras[9].Value = struct_zybs.p_bhyy;
                paras[10].Value = struct_zybs.p_xtsj;
                paras[11].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZYBS.InsertBS_ZYBS", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[11].Value);
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
        #endregion

        #region  编辑
        /// <summary>
        /// 修改BS_ZYBS表数据信息
        /// </summary>
        protected void UpdateBS_ZYBS(Struct_ZYBS struct_zybs)
        {
            DBClass db = new DBClass(); try
            {
                OracleParameter[] paras = {
                                           new OracleParameter("p_bsbh",OracleType.VarChar),
                                           new OracleParameter("p_bsyg",OracleType.VarChar),
                                           new OracleParameter("p_bsgw",OracleType.VarChar),
                                           new OracleParameter("p_bslx",OracleType.VarChar),
                                           new OracleParameter("p_bsip",OracleType.VarChar),
                                           new OracleParameter("p_bssj",OracleType.DateTime),
                                           new OracleParameter("p_bsms",OracleType.VarChar),
                                           new OracleParameter("p_jjfa",OracleType.VarChar),
                                           new OracleParameter("p_bz",OracleType.VarChar),
                                           new OracleParameter("p_bhyy",OracleType.VarChar),
                                           new OracleParameter("p_xtsj",OracleType.DateTime),
                                           new OracleParameter("p_errorCode",OracleType.Int32)
             };
                paras[0].Value = struct_zybs.p_bsbh;
                paras[1].Value = struct_zybs.p_bsyg;
                paras[2].Value = struct_zybs.p_bsgw;
                paras[3].Value = struct_zybs.p_bslx;
                paras[4].Value = struct_zybs.p_bsip;
                paras[5].Value = struct_zybs.p_bssj;
                paras[6].Value = struct_zybs.p_bsms;
                paras[7].Value = struct_zybs.p_jjfa;
                paras[8].Value = struct_zybs.p_bz;
                paras[9].Value = struct_zybs.p_bhyy;
                paras[10].Value = struct_zybs.p_xtsj;
                paras[11].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_ZYBS.UpdateBS_ZYBS", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[11].Value);
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
        #endregion

        protected void Update_ZYBSZT(int id, string zt, string bhyy)
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
                db.RunProcedure("PACK_HWZHBS_ZYBS.Update_ZYBSZT", paras, out rowsAffected);
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
        protected string SelectBSBH(string gwdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_HWZHBS_ZYBS.SelectBSMaxBH", paras, "dt");
                string maxbh = paras[0].Value.ToString();

                return gwdm + maxbh;
            }
            finally
            {
                db.Close();
            }
        }
    }
}

