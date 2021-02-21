using CUST;
using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Data;

namespace CUST.MKG
{
    //维修费用
    public struct Struct_Bs_Wxfy 
    {
        public int p_wxbh;//维修编号
        public string p_djdw;//登记单位
        public string p_yspf;//预算批复,单位万
        public string p_wxlb;//维修类别
        public string p_sblb;//设备类别
        public string p_sbmc;//设备名称
        public string p_cfdd;//存放地点
        public string p_gys_wxdw;//供应商/维修单位
        public DateTime p_qswxrq;//起始维修日期
        public DateTime p_jzwxrq;//截止维修日期
        public string p_wxys;//维修预算
        public string p_bjmc;//板件名称
        public string p_qs;//请示
        public string p_gzbg;//故障报告
        public string p_qtfj;//其他附件
        public string p_qslj;//请示
        public string p_gzbglj;//故障报告
        public string p_qtfjlj;//其他附件
        public string p_yszxjc;//预算执行机场
        public string p_nd;//年度
        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public string p_zxed;//执行额度
        public string p_syed;//剩余额度
        public int p_pagesize;   //每页容量
        public int p_currentpage;//当前页
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bmdm;//数据所属部门
        public string p_xmmc;//项目名称

    }

    //报销登记
    public struct Struct_Bs_Wxfy_Bxdj
    {
        public string p_bxbh;//报销编号
        public string p_xmmc;//项目名称
        public string p_zj;//总计
        public string p_sjyszxjc;//实际预算执行机场
        public string p_djrq;//登记日期
        public string p_zt;//状态
        public string p_bhyy;//驳回原因       
        public int p_pagesize;   //每页容量
        public int p_currentpage;//当前页
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public int p_userid;
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_lrr;//录入人
        public string p_sjc;//时间戳
        public string p_sjbs;//数据标识
        public string p_shsj;//审核时间
        public string p_bmdm;//数据所属部门
    }

    //报销登记明细
    public struct Struct_Bs_Wxfy_Bxdj_Mx
    {
        public string p_mxbh;//明细编号
        public string p_xmmc;//项目名称
        public string p_rgfmx;//人工费明细
        public int p_rgfsl;//人工费数量
        public double p_rgfbhs;//人工费(不含税)
        public double p_rgfhs;//人工费(含税)

        public string p_pjmc;//配件名称
        public int p_pjsl;//配件数量
        public double p_pjfybhs;//配件费用(不含税)
        public double p_pjfyhs;//配件费用(含税)     
        public string p_zt;//状态
        public int p_pagesize;   //每页容量
        public int p_currentpage;//当前页

        public string p_czfs;//操作方式
        public string p_czxx;//操作信息

    }

    public   class OWXFY
    {
        private UserState _us = null;
        private RZ rz = null;
        public OWXFY(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region 添加维修费用(请示登记)
        protected void Insert_Bs_Wxfy(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_djdw",OracleType.VarChar),
                  new OracleParameter("p_yspf",OracleType.VarChar),
                  new OracleParameter("p_wxlb",OracleType.VarChar),
                  new OracleParameter("p_sblb",OracleType.VarChar),
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_sbmc",OracleType.VarChar),
                  new OracleParameter("p_cfdd",OracleType.VarChar),
                  new OracleParameter("p_gys_wxdw",OracleType.VarChar),
                  new OracleParameter("p_qswxrq",OracleType.DateTime),
                  new OracleParameter("p_jzwxrq",OracleType.DateTime),
                  new OracleParameter("p_wxys",OracleType.VarChar),
                  new OracleParameter("p_bjmc",OracleType.VarChar),
                  new OracleParameter("p_qs",OracleType.VarChar),
                  new OracleParameter("p_gzbg",OracleType.VarChar),
                  new OracleParameter("p_qtfj",OracleType.VarChar),
                  new OracleParameter("p_yszxjc",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_qslj",OracleType.VarChar),
                  new OracleParameter("p_gzbglj",OracleType.VarChar),
                  new OracleParameter("p_qtfjlj",OracleType.VarChar),
                  new OracleParameter("p_csr",OracleType.VarChar),
                  new OracleParameter("p_zsr",OracleType.VarChar),
                  new OracleParameter("p_lrr",OracleType.VarChar),
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_bmdm",OracleType.VarChar),
                  new OracleParameter("p_sjbs",OracleType.VarChar),
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_bs_wxfy.p_djdw;
                paras[1].Value = struct_bs_wxfy.p_yspf;
                paras[2].Value = struct_bs_wxfy.p_wxlb;
                paras[3].Value = struct_bs_wxfy.p_sblb;
                paras[4].Value = struct_bs_wxfy.p_xmmc;
                paras[5].Value = struct_bs_wxfy.p_sbmc;
                paras[6].Value = struct_bs_wxfy.p_cfdd;
                paras[7].Value = struct_bs_wxfy.p_gys_wxdw;
                paras[8].Value = struct_bs_wxfy.p_qswxrq;
                paras[9].Value = struct_bs_wxfy.p_jzwxrq;
                paras[10].Value = struct_bs_wxfy.p_wxys;
                paras[11].Value = struct_bs_wxfy.p_bjmc;
                paras[12].Value = struct_bs_wxfy.p_qs;
                paras[13].Value = struct_bs_wxfy.p_gzbg;
                paras[14].Value = struct_bs_wxfy.p_qtfj;
                paras[15].Value = struct_bs_wxfy.p_yszxjc;
                paras[16].Value = struct_bs_wxfy.p_nd;
                paras[17].Value = struct_bs_wxfy.p_qslj;
                paras[18].Value = struct_bs_wxfy.p_gzbglj;
                paras[19].Value = struct_bs_wxfy.p_qtfjlj;
                paras[20].Value = struct_bs_wxfy.p_csr;
                paras[21].Value = struct_bs_wxfy.p_zsr;
                paras[22].Value = struct_bs_wxfy.p_lrr;
                paras[23].Value = struct_bs_wxfy.p_sjc;                
                paras[24].Value = struct_bs_wxfy.p_bmdm;
                paras[25].Value = struct_bs_wxfy.p_sjbs;
                paras[26].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Insert_Bs_Wxfy_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[26].Value);
                if (errorCode != 0)
               {
                    throw new EMException(errorCode);
               }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_wxfy.p_czfs;
                struct_rz.czxx = struct_bs_wxfy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 查出维修类型
        protected DataTable Select_Bs_Wxfy_Wxlx()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                   
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_Bs_Wxfy_Wxlx", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 查找维修费用(请示登记)
        protected DataTable SelectBS_Wxfy_Pro(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_nd",OracleType.VarChar),
                    new OracleParameter("p_djdw",OracleType.VarChar),
                    new OracleParameter("p_wxlb",OracleType.VarChar),
                    new OracleParameter("p_zt",OracleType.VarChar),
                    new OracleParameter("p_pagesize",OracleType.Int32),
                    new OracleParameter("p_currentpage",OracleType.Int32),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_bs_wxfy.p_nd;
                paras[1].Value = struct_bs_wxfy.p_djdw;
                paras[2].Value = struct_bs_wxfy.p_wxlb;
                paras[3].Value = struct_bs_wxfy.p_zt;
                paras[4].Value = struct_bs_wxfy.p_pagesize;
                paras[5].Value = struct_bs_wxfy.p_currentpage;
                paras[6].Value = struct_bs_wxfy.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_Bs_wxfy_Proc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 查出登记单位
        protected DataTable Select_Bs_Wxfy_Djdw()
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={

                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_Bs_Wxfy_Djdw", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 删除维修费用(请示登记)  
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_id"></param>        
        protected void Delete_Bs_Wxfy(int p_wxbh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_wxbh",OracleType.Number),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_wxbh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Delete_Bs_Wxfy_Proc", paras, out rowsAffected);
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

        #region  编辑维修费用(请示登记)
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="hb"></param>
        protected void Update_Bs_Wxfy(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_wxbh",OracleType.VarChar),
                  new OracleParameter("p_djdw",OracleType.VarChar),
                  new OracleParameter("p_yspf",OracleType.VarChar),
                  new OracleParameter("p_wxlb",OracleType.VarChar),
                  new OracleParameter("p_sblb",OracleType.VarChar),
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_sbmc",OracleType.VarChar),
                  new OracleParameter("p_cfdd",OracleType.VarChar),
                  new OracleParameter("p_gys_wxdw",OracleType.VarChar),
                  new OracleParameter("p_qswxrq",OracleType.DateTime),
                  new OracleParameter("p_jzwxrq",OracleType.DateTime),
                  new OracleParameter("p_wxys",OracleType.VarChar),
                  new OracleParameter("p_bjmc",OracleType.VarChar),
                  new OracleParameter("p_qs",OracleType.VarChar),
                  new OracleParameter("p_gzbg",OracleType.VarChar),
                  new OracleParameter("p_qtfj",OracleType.VarChar),
                  new OracleParameter("p_yszxjc",OracleType.VarChar),
                  new OracleParameter("p_nd",OracleType.VarChar),
                  new OracleParameter("p_qslj",OracleType.VarChar),
                  new OracleParameter("p_gzbglj",OracleType.VarChar),
                  new OracleParameter("p_qtfjlj",OracleType.VarChar),
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_bs_wxfy.p_wxbh;
                paras[1].Value = struct_bs_wxfy.p_djdw;
                paras[2].Value = struct_bs_wxfy.p_yspf;
                paras[3].Value = struct_bs_wxfy.p_wxlb;
                paras[4].Value = struct_bs_wxfy.p_sblb;
                paras[5].Value = struct_bs_wxfy.p_xmmc;
                paras[6].Value = struct_bs_wxfy.p_sbmc;
                paras[7].Value = struct_bs_wxfy.p_cfdd;
                paras[8].Value = struct_bs_wxfy.p_gys_wxdw;
                paras[9].Value = struct_bs_wxfy.p_qswxrq;
                paras[10].Value = struct_bs_wxfy.p_jzwxrq;
                paras[11].Value = struct_bs_wxfy.p_wxys;
                paras[12].Value = struct_bs_wxfy.p_bjmc;
                paras[13].Value = struct_bs_wxfy.p_qs;
                paras[14].Value = struct_bs_wxfy.p_gzbg;
                paras[15].Value = struct_bs_wxfy.p_qtfj;
                paras[16].Value = struct_bs_wxfy.p_yszxjc;
                paras[17].Value = struct_bs_wxfy.p_nd;
                paras[18].Value = struct_bs_wxfy.p_qslj;
                paras[19].Value = struct_bs_wxfy.p_gzbglj;
                paras[20].Value = struct_bs_wxfy.p_qtfjlj;
                paras[21].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_Bs_Wxfy_Proc", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[21].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs =struct_bs_wxfy.p_czfs;
                struct_rz.czxx =struct_bs_wxfy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 检索维修费用(报销登记)详细信息
        protected DataTable Select_Bs_Wxfy_Detail(int p_wxbh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_wxbh",OracleType.Number),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = p_wxbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_Bs_Wxfy_Detail", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region  查找维修费(请示登记)数量
        protected int Select_Bs_Wxfy_Count(Struct_Bs_Wxfy struct_bs_wxfy_count )
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras =
                    {
                        new OracleParameter("p_nd",OracleType.VarChar),
                        new OracleParameter("p_djdw",OracleType.VarChar),
                        new OracleParameter("p_wxlb",OracleType.VarChar),                        
                        new OracleParameter("p_zt",OracleType.VarChar),
                        new OracleParameter("p_userid",OracleType.Int32),
                        new OracleParameter("p_cur",OracleType.Cursor)
                   };
                paras[0].Value = struct_bs_wxfy_count.p_nd;
                paras[1].Value = struct_bs_wxfy_count.p_djdw;
                paras[2].Value = struct_bs_wxfy_count.p_wxlb;                              
                paras[3].Value = struct_bs_wxfy_count.p_zt;
                paras[4].Value = struct_bs_wxfy_count.p_userid;
                paras[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_HWZHBS_WXFY.Select_Bs_Wxfy_Count", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        #region 更新维修费用(请示登记)状态
        protected void Update_WXFYZT(Struct_Bs_Wxfy struct_bs_wxfy_zt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_wxbh",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),                  
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_bs_wxfy_zt.p_wxbh;
                paras[1].Value = struct_bs_wxfy_zt.p_bhyy;
                paras[2].Value = struct_bs_wxfy_zt.p_zt;                
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_WXFY_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_wxfy_zt.p_czfs;
                struct_rz.czxx = struct_bs_wxfy_zt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        /*报销登记*/
        #region 通过项目名称查找报销登记
        protected DataTable Select_Bxdj_ByXmmc(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_xmmc",OracleType.VarChar),
                    new OracleParameter("p_userid",OracleType.Int32),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_bs_bxdj.p_xmmc;
                paras[1].Value = struct_bs_bxdj.p_userid;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_Bxdj_ByXMMC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 添加报销登记
        protected void Insert_Bs_Bxdj(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_zj",OracleType.Number),
                  new OracleParameter("p_sjyszxjc",OracleType.VarChar),
                  new OracleParameter("p_djrq",OracleType.DateTime), 
                //  new OracleParameter("p_csr",OracleType.VarChar),
                //  new OracleParameter("p_zsr",OracleType.VarChar),
               //   new OracleParameter("p_lrr",OracleType.VarChar),
              //    new OracleParameter("p_sjc",OracleType.VarChar),
                //  new OracleParameter("p_bmdm",OracleType.VarChar),
               //   new OracleParameter("p_sjbs",OracleType.VarChar),
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_bs_bxdj.p_xmmc;
                paras[1].Value = struct_bs_bxdj.p_zj;
                paras[2].Value = struct_bs_bxdj.p_sjyszxjc;
                paras[3].Value = struct_bs_bxdj.p_djrq;
             //   paras[4].Value = struct_bs_bxdj.p_csr;
              //  paras[5].Value = struct_bs_bxdj.p_zsr;
             //   paras[6].Value = struct_bs_bxdj.p_lrr;
             //   paras[7].Value = struct_bs_bxdj.p_sjc;
             //   paras[8].Value = struct_bs_bxdj.p_bmdm;
              //  paras[9].Value = struct_bs_bxdj.p_sjbs;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Insert_Bs_Bxdj", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[4].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_bxdj.p_czfs;
                struct_rz.czxx = struct_bs_bxdj.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑报销登记（通过项目名称）
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="xmmc"></param>
        protected void Update_Bs_Bxdj(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_zj",OracleType.Number),
                  new OracleParameter("p_sjyszxjc",OracleType.VarChar),
                  new OracleParameter("p_djrq",OracleType.DateTime),                  
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_bs_bxdj.p_xmmc;
                paras[1].Value = struct_bs_bxdj.p_zj;
                paras[2].Value = struct_bs_bxdj.p_sjyszxjc;
                paras[3].Value = struct_bs_bxdj.p_djrq;
                paras[4].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_Bs_Bxdj", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[4].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_bxdj.p_czfs;
                struct_rz.czxx = struct_bs_bxdj.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 删除报销登记  
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_xmmc"></param>        
        protected void Delete_Bs_Bxdj(string p_xmmc, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_xmmc",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_xmmc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Delete_Bs_Bxdj_ByXmmc", paras, out rowsAffected);
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

        #region 更新报销登记状态关联明细的状态
        protected void Update_BXDJ_ZT(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj_zt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_bs_bxdj_zt.p_xmmc;
                paras[1].Value = struct_bs_bxdj_zt.p_zt;
                paras[2].Value = struct_bs_bxdj_zt.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_BXDJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_bxdj_zt.p_czfs;
                struct_rz.czxx = struct_bs_bxdj_zt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 通过项目名称查找报销登记_明细
        protected DataTable Select_Bxdj_Mx_ByXmmc(Struct_Bs_Wxfy_Bxdj_Mx struct_bxdj_mx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_xmmc",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_bxdj_mx.p_xmmc;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_Bxdj_Mx_ByXmmc", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion

        #region 添加报销登记明细
        protected void Insert_Bs_Bxdj_Mx(Struct_Bs_Wxfy_Bxdj_Mx struct_bs_bxdj_mx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_rgfmx",OracleType.VarChar),
                  new OracleParameter("p_rgfsl",OracleType.Number),
                  new OracleParameter("p_rgfbhs",OracleType.Number),
                  new OracleParameter("p_rgfhs",OracleType.Number),
                  new OracleParameter("p_pjmc",OracleType.VarChar),
                  new OracleParameter("p_pjsl",OracleType.Number),
                  new OracleParameter("p_pjfybhs",OracleType.Number),
                  new OracleParameter("p_pjfyhs",OracleType.Number),
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_bs_bxdj_mx.p_xmmc;
                paras[1].Value = struct_bs_bxdj_mx.p_rgfmx;
                paras[2].Value = struct_bs_bxdj_mx.p_rgfsl;
                paras[3].Value = struct_bs_bxdj_mx.p_rgfbhs;
                paras[4].Value = struct_bs_bxdj_mx.p_rgfhs;
                paras[5].Value = struct_bs_bxdj_mx.p_pjmc;
                paras[6].Value = struct_bs_bxdj_mx.p_pjsl;
                paras[7].Value = struct_bs_bxdj_mx.p_pjfybhs;
                paras[8].Value = struct_bs_bxdj_mx.p_pjfyhs;
                paras[9].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Insert_Bs_Bxdj_Mx", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[9].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_bxdj_mx.p_czfs;
                struct_rz.czxx = struct_bs_bxdj_mx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑报销登记(明细)（通过明细编号）
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="mxbh"></param>
        protected void Update_Bs_Bxdj_Mx(Struct_Bs_Wxfy_Bxdj_Mx struct_bs_bxdj_mx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_mxbh",OracleType.VarChar),
                  new OracleParameter("p_rgfmx",OracleType.VarChar),
                  new OracleParameter("p_rgfsl",OracleType.Number),
                  new OracleParameter("p_rgfbhs",OracleType.Number),
                  new OracleParameter("p_rgfhs",OracleType.Number),
                  new OracleParameter("p_pjmc",OracleType.VarChar),
                  new OracleParameter("p_pjsl",OracleType.Number),
                  new OracleParameter("p_pjfybhs",OracleType.Number),
                  new OracleParameter("p_pjfyhs",OracleType.Number),
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_bs_bxdj_mx.p_mxbh;
                paras[1].Value = struct_bs_bxdj_mx.p_rgfmx;
                paras[2].Value = struct_bs_bxdj_mx.p_rgfsl;
                paras[3].Value = struct_bs_bxdj_mx.p_rgfbhs;
                paras[4].Value = struct_bs_bxdj_mx.p_rgfhs;
                paras[5].Value = struct_bs_bxdj_mx.p_pjmc;
                paras[6].Value = struct_bs_bxdj_mx.p_pjsl;
                paras[7].Value = struct_bs_bxdj_mx.p_pjfybhs;
                paras[8].Value = struct_bs_bxdj_mx.p_pjfyhs;
                paras[9].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_Bs_Bxdj_Mx", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[9].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_bxdj_mx.p_czfs;
                struct_rz.czxx = struct_bs_bxdj_mx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 删除报销登记明细(明细编号)
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_xmmc"></param>        
        protected void Delete_Bs_Bxdj_Mx_ByMxbh(string p_mxbh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_mxbh",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                     };
                paras[0].Value = p_mxbh;
                paras[1].Direction = ParameterDirection.Output; 
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Delete_Bs_Bxdj_Mx_ByMxbh", paras, out rowsAffected);
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

        #region 更新报销登记状态
        protected void Update_BXDJ_MX_ZT(Struct_Bs_Wxfy_Bxdj_Mx struct_bs_bxdj_mx_zt)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_bs_bxdj_mx_zt.p_xmmc;
                paras[1].Value = struct_bs_bxdj_mx_zt.p_zt;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_BXDJ_MX_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_bxdj_mx_zt.p_czfs;
                struct_rz.czxx = struct_bs_bxdj_mx_zt.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 关联报销登记状态
        protected void Update_BXDJ_Relate_MX_ZT(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_xmmc",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = struct_bs_bxdj.p_xmmc;
                paras[1].Value = struct_bs_bxdj.p_zt;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_BXDJ_Relate_MX_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_bs_bxdj.p_czfs;
                struct_rz.czxx = struct_bs_bxdj.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion        

        #region 通过明细编号查找报销登记_明细
        protected DataTable Select_Bxdj_Mx_ByMxbh(Struct_Bs_Wxfy_Bxdj_Mx struct_bxdj_mx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                    new OracleParameter("p_mxbh",OracleType.VarChar),
                    new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = struct_bxdj_mx.p_mxbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_Bxdj_Mx_ByMxbh", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion



        #region       //变更数据标识
        protected void Update_WXFY_SJBS_ZT(Struct_Bs_Wxfy wxfy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = wxfy.p_sjc;
                paras[1].Value = wxfy.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_WXFY_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = wxfy.p_czfs;
                struct_rz.czxx = wxfy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_WXFY_SJBS_LSSJ_ZT(Struct_Bs_Wxfy wxfy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = wxfy.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_WXFY_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = wxfy.p_czfs;
                struct_rz.czxx = wxfy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion


        #region 将副本数据变为最终数据
        protected void Update_WXFY_SJBS_FBSJ_ZT(Struct_Bs_Wxfy wxfy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = wxfy.p_sjc;
                paras[1].Value = wxfy.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_HWZHBS_WXFY.Update_WXFY_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = wxfy.p_czfs;
                struct_rz.czxx = wxfy.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        //复制副本数据并返回最新的wxbh
        protected int WXFY_SJBF(int wxbh)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_Bs_Wxfy_Detail(wxbh);
            //备份数据
            Struct_Bs_Wxfy wxfy_bf = new Struct_Bs_Wxfy();
                        
            wxfy_bf.p_djdw = dt_detail.Rows[0]["djdw"].ToString();
            wxfy_bf.p_yspf = dt_detail.Rows[0]["yspf"].ToString();
            wxfy_bf.p_wxlb = dt_detail.Rows[0]["wxlb"].ToString();
            wxfy_bf.p_sblb = dt_detail.Rows[0]["sblb"].ToString();
            wxfy_bf.p_xmmc = dt_detail.Rows[0]["xmmc"].ToString();
            wxfy_bf.p_sbmc = dt_detail.Rows[0]["sbmc"].ToString();
            wxfy_bf.p_cfdd = dt_detail.Rows[0]["cfdd"].ToString();
            wxfy_bf.p_gys_wxdw = dt_detail.Rows[0]["gys_wxdw"].ToString();
            wxfy_bf.p_qswxrq = Convert.ToDateTime(dt_detail.Rows[0]["qswxrq"].ToString());
            wxfy_bf.p_jzwxrq = Convert.ToDateTime(dt_detail.Rows[0]["jzwxrq"].ToString());
            wxfy_bf.p_wxys = dt_detail.Rows[0]["wxys"].ToString();
            wxfy_bf.p_bjmc = dt_detail.Rows[0]["bjmc"].ToString();
            wxfy_bf.p_qs = dt_detail.Rows[0]["qs"].ToString();
            wxfy_bf.p_gzbg = dt_detail.Rows[0]["gzbg"].ToString();
            wxfy_bf.p_qtfj = dt_detail.Rows[0]["qtfj"].ToString();
            wxfy_bf.p_yszxjc = dt_detail.Rows[0]["yszxjc"].ToString();
            wxfy_bf.p_nd = dt_detail.Rows[0]["nd"].ToString();
            wxfy_bf.p_qslj = dt_detail.Rows[0]["qslj"].ToString();
            wxfy_bf.p_gzbglj = dt_detail.Rows[0]["gzbglj"].ToString();
            wxfy_bf.p_qtfjlj = dt_detail.Rows[0]["qtfjlj"].ToString();
            wxfy_bf.p_zt = "0";
            wxfy_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();
            wxfy_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            wxfy_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            wxfy_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            wxfy_bf.p_lrr = _us.userLoginName;
            wxfy_bf.p_sjbs = "2";
            wxfy_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            wxfy_bf.p_shsj = "";
            wxfy_bf.p_czfs = "02";
            wxfy_bf.p_czxx = "维修费用wxbh:" + wxbh + "生成副本数据";
            //插入
            Insert_Bs_Wxfy(wxfy_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = wxfy_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_HWZHBS_WXFY.Select_WXFY_BFWXBH", parament, out reslut);

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
