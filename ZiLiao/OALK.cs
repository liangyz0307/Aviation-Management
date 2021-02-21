using CUST;
using CUST.MKG;
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
    public struct Struct_ALK
    {
        public int p_id;
        public string p_albh;//案例编号，16位（6位岗位代码+10流水号）
        public string p_alm;//案例名称
        public string p_allx1;//案例类型1
        public string p_allx2;//案例类型2
        public string p_ally;//案例来源
        public DateTime p_fssj;//案例发生时间
        public DateTime p_kssj;//案例开始时间
        public DateTime p_jssj;//案例结束时间
        public string p_alfx;//案例分析
        public string p_aldj;//案例等级
        public string p_alms;//案例描述
        public string p_scyh;//上传用户
        public string p_scbm;//上传部门
        public string p_scgw;//上传岗位
        public DateTime p_scsj;//上传时间
        public string p_scip;//上传IP
        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public string sclj;//上传路径
        public int p_pagesize;
        public int p_currentpage;
        public string p_czfs;
        public string p_czxx;
        public int p_userid;
        public string p_bmdm;//数据所属部门
    }
    public class OALK
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private UserState _usState = null;
        private RZ rz;
        public OALK(UserState _usState)
        {
            this._usState = _usState;
            rz = new RZ(_usState);
        }
        #region  ===============案例的增删改查================


        /// <summary>
        /// 检索ALK表数据信息
        /// </summary>
        protected DataSet Select_AL_Pro(Struct_ALK struct_ALK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                      new OracleParameter("p_alm",OracleType.VarChar),
                                      new OracleParameter("p_allx1",OracleType.VarChar),
                                      new OracleParameter("p_allx2",OracleType.VarChar),
                                      new OracleParameter("p_ally",OracleType.VarChar),
                                      new OracleParameter("p_kssj",OracleType.DateTime),
                                      new OracleParameter("p_jssj",OracleType.DateTime),
                                      new OracleParameter("p_aldj",OracleType.VarChar),
                                    //  new OracleParameter("p_zt",OracleType.VarChar),
                                      new OracleParameter("p_userid",OracleType.Int32),
                                      new OracleParameter("p_currentpage",OracleType.VarChar),
                                      new OracleParameter("p_pagesize",OracleType.VarChar),
                                      new OracleParameter("p_cur",OracleType.Cursor)
                                  };
                paras[0].Value = struct_ALK.p_alm;
                paras[1].Value = struct_ALK.p_allx1;
                paras[2].Value = struct_ALK.p_allx2;
                paras[3].Value = struct_ALK.p_ally;
                paras[4].Value = struct_ALK.p_kssj;
                paras[5].Value = struct_ALK.p_jssj;
                paras[6].Value = struct_ALK.p_aldj;
            //  paras[7].Value = struct_ALK.p_zt;
                paras[7].Value = struct_ALK.p_userid;
                paras[8].Value = struct_ALK.p_currentpage;
                paras[9].Value = struct_ALK.p_pagesize;
                paras[10].Direction = ParameterDirection.Output;
                DataSet ds = db.RunProcedure("PACK_KG_ALK.Select_AL_Pro", paras, "table");
                return ds;
            }
            finally
            {
                db.Close();
            }
        }

        protected int Select_AL_Count(Struct_ALK struct_ALK)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                      new OracleParameter("p_alm",OracleType.VarChar),
                                      new OracleParameter("p_allx1",OracleType.VarChar),
                                      new OracleParameter("p_allx2",OracleType.VarChar),
                                      new OracleParameter("p_ally",OracleType.VarChar),
                                      new OracleParameter("p_kssj",OracleType.DateTime),
                                      new OracleParameter("p_jssj",OracleType.DateTime),
                                      new OracleParameter("p_aldj",OracleType.VarChar),
                                     // new OracleParameter("p_zt",OracleType.VarChar),
                                      new OracleParameter("p_userid",OracleType.Int32),
                                      new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                paras[0].Value = struct_ALK.p_alm;
                paras[1].Value = struct_ALK.p_allx1;
                paras[2].Value = struct_ALK.p_allx2;
                paras[3].Value = struct_ALK.p_ally;
                paras[4].Value = struct_ALK.p_kssj;
                paras[5].Value = struct_ALK.p_jssj;
                paras[6].Value = struct_ALK.p_aldj;
              //  paras[7].Value = struct_ALK.p_zt;
                paras[7].Value = struct_ALK.p_userid;
                paras[8].Direction = ParameterDirection.Output;

                int count = Convert.ToInt32(dbclass.RunProcedure("PACK_KG_ALK.Select_AL_Count", paras, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 删除ALK表数据信息
        /// </summary>
        protected void Delete_AL(int id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                             new OracleParameter("p_id",OracleType.Int32),
                                             new OracleParameter("p_errorCode",OracleType.Int32)
                                          };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ALK.Delete_AL", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 添加ALK表数据信息
        /// </summary>
        protected void Insert_AL(Struct_ALK struct_ALK)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                                            
                                             new OracleParameter("p_albh",OracleType.VarChar),
                                             new OracleParameter("p_alm",OracleType.VarChar),
                                             new OracleParameter("p_allx1",OracleType.VarChar),
                                             new OracleParameter("p_allx2",OracleType.VarChar),
                                             new OracleParameter("p_ally",OracleType.VarChar),
                                             new OracleParameter("p_fssj",OracleType.DateTime),
                                             new OracleParameter("p_alfx",OracleType.VarChar),
                                             new OracleParameter("p_aldj",OracleType.VarChar),
                                             new OracleParameter("p_alms",OracleType.VarChar),
                                             new OracleParameter("p_scyh",OracleType.VarChar),
                                             new OracleParameter("p_scbm",OracleType.VarChar),
                                             new OracleParameter("p_scgw",OracleType.VarChar),
                                             new OracleParameter("p_scsj",OracleType.DateTime),
                                             new OracleParameter("p_scip",OracleType.VarChar),
                                             new OracleParameter("p_sclj",OracleType.VarChar),
                                             new OracleParameter("p_bmdm",OracleType.VarChar),
                                             new OracleParameter("p_errorCode",OracleType.Int32)
                                          };
                paras[0].Value = struct_ALK.p_albh.Trim();
                paras[1].Value = struct_ALK.p_alm;
                paras[2].Value = struct_ALK.p_allx1;
                paras[3].Value = struct_ALK.p_allx2;
                paras[4].Value = struct_ALK.p_ally;
                paras[5].Value = struct_ALK.p_fssj;
                paras[6].Value = struct_ALK.p_alfx;
                paras[7].Value = struct_ALK.p_aldj;
                paras[8].Value = struct_ALK.p_alms;
                paras[9].Value = _usState.userLoginName;
                paras[10].Value = _usState.userBMDM;
                paras[11].Value = _usState.userGWDM;
                paras[12].Value = System.DateTime.Now;
                paras[13].Value = _usState.context.IP;
                paras[14].Value = struct_ALK.sclj;
                paras[15].Value = struct_ALK.p_bmdm;
                paras[16].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ALK.Insert_AL", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[16].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_ALK.p_czfs;
                struct_RZ_YH.czxx = struct_ALK.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 修改ALK表数据信息
        /// </summary>
        protected void Update_AL(Struct_ALK struct_ALK)
        {
            DBClass db = new DBClass(); try
            {
                OracleParameter[] paras = {
                                             new OracleParameter("p_albh",OracleType.VarChar),
                                             new OracleParameter("p_alm",OracleType.VarChar),
                                             new OracleParameter("p_allx1",OracleType.VarChar),
                                             new OracleParameter("p_allx2",OracleType.VarChar),
                                             new OracleParameter("p_ally",OracleType.VarChar),
                                             new OracleParameter("p_fssj",OracleType.DateTime),
                                             new OracleParameter("p_alfx",OracleType.VarChar),
                                             new OracleParameter("p_aldj",OracleType.VarChar),
                                             new OracleParameter("p_alms",OracleType.VarChar),
                                             new OracleParameter("p_scyh",OracleType.VarChar),
                                             new OracleParameter("p_scbm",OracleType.VarChar),
                                             new OracleParameter("p_scgw",OracleType.VarChar),
                                             new OracleParameter("p_scsj",OracleType.DateTime),
                                             new OracleParameter("p_scip",OracleType.VarChar),
                                             new OracleParameter("p_errorCode",OracleType.Int32)
                                          };
                paras[0].Value = struct_ALK.p_albh;
                paras[1].Value = struct_ALK.p_alm;
                paras[2].Value = struct_ALK.p_allx1;
                paras[3].Value = struct_ALK.p_allx2;
                paras[4].Value = struct_ALK.p_ally;
                paras[5].Value = struct_ALK.p_fssj;
                paras[6].Value = struct_ALK.p_alfx;
                paras[7].Value = struct_ALK.p_aldj;
                paras[8].Value = struct_ALK.p_alms;
                paras[9].Value = _usState.userLoginName;
                paras[10].Value = _usState.userBMDM;
                paras[11].Value = _usState.userGWDM;
                paras[12].Value = System.DateTime.Now;
                paras[13].Value = _usState.context.IP;
                paras[14].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ALK.Update_AL", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[14].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                rz = new RZ(_usState);
                struct_RZ_YH.czfs = struct_ALK.p_czfs;
                struct_RZ_YH.czxx = struct_ALK.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally
            {
                db.Close();
            }
        }
        //#region 更新状态
        //protected void Update_ALZT(Struct_ALK struct_ALK)
        //{
        //    DBClass db = new DBClass();
        //    try
        //    {
        //        OracleParameter[] paras ={
        //          new OracleParameter("p_albh",OracleType.Number),
        //          new OracleParameter("p_zt",OracleType.VarChar),
        //          new OracleParameter("p_bhyy",OracleType.VarChar),
        //          new OracleParameter("p_errorCode",OracleType.Int32)
        //};
        //        paras[0].Value = struct_ALK.p_albh.Trim();
        //        paras[1].Value = struct_ALK.p_zt;
        //        paras[2].Value = struct_ALK.p_bhyy;
        //        paras[3].Direction = ParameterDirection.Output;
        //        int rowsAffected = 0;
        //        db.RunProcedure("PACK_KG_ALK.Update_ALZT", paras, out rowsAffected);
        //        int errorCode = 0;
        //        errorCode = Convert.ToInt32(paras[3].Value);
        //        if (errorCode != 0)
        //        {
        //            throw new EMException(errorCode);
        //        }
        //        //插入日志表
        //        Struct_RZ_YH struct_rz = new Struct_RZ_YH();
        //        struct_rz.czfs = struct_ALK.p_czfs;
        //        struct_rz.czxx = struct_ALK.p_czxx;
        //        rz.RZ_Insert_CZ(struct_rz);
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //}
        //#endregion
        #region 更新状态
        protected void Update_ALZT(Struct_ALK struct_ALK)
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
                paras[0].Value = struct_ALK.p_id;
                paras[1].Value = struct_ALK.p_zt;
                paras[2].Value = struct_ALK.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_ALK.Update_ALZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_ALK.p_czfs;
                struct_rz.czxx = struct_ALK.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        protected DataSet Select_ALbyALBH(string p_albh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_albh",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = p_albh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_ALK.Select_ALbyALBH", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected string SelectALMaxBH(string gwdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_ALK.SelectALMaxBH", paras, "dt");
                string maxbh = paras[0].Value.ToString();

                return gwdm + maxbh;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
    }
}