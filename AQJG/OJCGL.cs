using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    #region 检查管理（检查记录-整改）结构体
    public struct Struct_jcgl
    {
        public int rwid;
        public DateTime jcsj;       //检查时间
        public DateTime jcsjs;      //检查开始时间
        public DateTime jcsje;      //检查结束时间
        public string bjdw;         //被检单位
        public string jcxm;         //检查项目
        public string jcjg;         //检查结果
        public string zgyj;         //整改意见
        public string tzzrdw;       //通知责任单位
        public string tzzrry;       //通知责任人员
        public string lsqkfk;       //落实情况反馈
        public string bz;           //备注
        public string jcr;          //检查人
        public string zt;           //状态
        public int p_userid;        //权限用户
        public int p_pagesize;      //每页容量
        public int p_currentpage;   //当前页码
        public string p_czfs;       //操作方式
        public string p_czxx;       //操作信息
        
        public string jcd;          //检查单
        public string zgfa;         //整改方案
        public string fxkzcs;       //风险控制措施
        public string zgsm;         //整改说明
        public DateTime zgsj;       //整改时间
        public string zgbz;         //整改备注
        public string bmdm;         //部门代码
        public string csr;          //初审人
        public string zsr;          //终审人
        public string lrr;          //录入人
        public string sjbs;         //数据标识
        public string sjc;          //时间戳
        public string shsj;         //审核时间
        public string filepath;
    }
    #endregion 
    #region 检查记录查询结构体
    public struct Struct_Select_JCJL
    {
        public int rwid;
        public DateTime jcsjs;      //检查开始时间
        public DateTime jcsje;      //检查结束时间
        public string bjdw;         //被检单位
        public string jcd;          //检查单
        public string jcxm;         //检查项目
        public string jcjg;         //检查结果
        public int p_pagesize;      //每页容量
        public int p_currentpage;   //当前页码
    }
    #endregion
    public class OJCGL
    {
        private UserState _us = null;
        private RZ rz = null;
        public OJCGL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        #region  张先震   检查记录的增删改查
        #region 检查记录查询
        protected DataSet Select_JCJL(Struct_jcgl struct_jcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                    new OracleParameter("p_jcsjs",OracleType.DateTime),
                                                    new OracleParameter("p_jcsje",OracleType.DateTime),
                                                    new OracleParameter("p_bjdw",OracleType.VarChar),
                                                    new OracleParameter("p_jcd",OracleType.VarChar),
                                                    new OracleParameter("p_jcxm",OracleType.VarChar),
                                                    new OracleParameter("p_jcjg",OracleType.VarChar),
                                                    new OracleParameter("p_userid",OracleType.Int32),
                                                    new OracleParameter("p_pagesize",OracleType.Int32),
                                                    new OracleParameter("p_currentpage",OracleType.Int32),                                                    
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };

                parament[0].Value = struct_jcgl.jcsjs;
                parament[1].Value = struct_jcgl.jcsje;
                parament[2].Value = struct_jcgl.bjdw;
                parament[3].Value = struct_jcgl.jcd;
                parament[4].Value = struct_jcgl.jcxm;
                parament[5].Value = struct_jcgl.jcjg;
                parament[6].Value = struct_jcgl.p_userid;
                parament[7].Value = struct_jcgl.p_pagesize;
                parament[8].Value = struct_jcgl.p_currentpage;                
                parament[9].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_JCJL.Select_KG_JCGL", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 检查记录个数查询
        protected int Select_KG_JCGL_Count(Struct_jcgl struct_jcgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[]parament={
                                                new OracleParameter("p_jcsjs",OracleType.DateTime),
                                                new OracleParameter("p_jcsje",OracleType.DateTime),
                                                new OracleParameter("p_bjdw",OracleType.VarChar),
                                                new OracleParameter("p_jcd",OracleType.VarChar),
                                                new OracleParameter("p_jcxm",OracleType.VarChar),
                                                new OracleParameter("p_jcjg",OracleType.VarChar),
                                                new OracleParameter("p_userid",OracleType.Int32),
                                                new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value =struct_jcgl.jcsjs;
                parament[1].Value = struct_jcgl.jcsje;
                parament[2].Value = struct_jcgl.bjdw;
                parament[3].Value = struct_jcgl.jcd;
                parament[4].Value = struct_jcgl.jcxm;
                parament[5].Value = struct_jcgl.jcjg;
                parament[6].Value = struct_jcgl.p_userid;
                parament[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_JCJL.Select_KG_JCGL_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        #endregion
        #region 检查记录添加
        protected void Insert_JCJL(Struct_jcgl struct_jcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_rwid",OracleType.Int32),
                                                 new OracleParameter("p_jcsj",OracleType.DateTime),
                                                 new OracleParameter("p_bjdw",OracleType.VarChar),
                                                 new OracleParameter("p_jcxm",OracleType.VarChar),
                                                 new OracleParameter("p_jcjg",OracleType.VarChar),
                                                 new OracleParameter("p_zgyj",OracleType.VarChar),
                                                 new OracleParameter("p_zrdw",OracleType.VarChar),
                                                 new OracleParameter("p_zrr",OracleType.VarChar),
                                                 new OracleParameter("p_lsqkfk",OracleType.VarChar),
                                                 new OracleParameter("p_bz",OracleType.VarChar),
                                                 new OracleParameter("p_jcr",OracleType.VarChar),
                                                 new OracleParameter("p_jcd",OracleType.VarChar),
                                                 //new OracleParameter("p_filepath",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                                  
                                             };
                parament[0].Value = struct_jcgl.rwid;
                parament[1].Value = struct_jcgl.jcsj;
                parament[2].Value = struct_jcgl.bjdw;
                parament[3].Value = struct_jcgl.jcxm;
                parament[4].Value = struct_jcgl.jcjg;
                parament[5].Value = struct_jcgl.zgyj;
                parament[6].Value = struct_jcgl.tzzrdw;
                parament[7].Value = struct_jcgl.tzzrry;
                parament[8].Value = struct_jcgl.lsqkfk;
                parament[9].Value = struct_jcgl.bz;
                parament[10].Value = struct_jcgl.jcr;
                parament[11].Value = struct_jcgl.jcd;
                //parament[12].Value = struct_jcgl.filepath;
                parament[12].Direction = ParameterDirection.Output;
                

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_JCJL.Insert_KG_JCGL", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[12].Value);
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
        #endregion
        #region 添加时查询检查任务ID、检查单、检查项目
        protected DataTable Select_JCRW(string jcd)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parameter = {
                                                  new OracleParameter("p_tbdw",OracleType.VarChar),
                                                  new OracleParameter ("p_cur",OracleType .Cursor )
                                              };
                parameter[0].Value = jcd;
                parameter[1].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_JCJL.Select_JCRW", parameter, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 根据检查单、检查项目查询检查任务中的ID
        protected DataTable Select_JCRW(string jcd, string jcxm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parameter = {
                                                  new OracleParameter("p_tbdw",OracleType.VarChar),
                                                  new OracleParameter("p_jcxm",OracleType.VarChar),
                                                  new OracleParameter ("p_cur",OracleType .Cursor )
                                              };
                parameter[0].Value = jcd;
                parameter[1].Value = jcxm;
                parameter[2].Direction = ParameterDirection.Output;
                DataTable ds = new DataTable();
                ds = dbclass.RunProcedure("PACK_KG_JCJL.Select_JCRWID", parameter, "table").Tables[0];
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 检查记录详情查询
        protected DataSet Select_JCJL_Detil(int rwid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_rwid",OracleType.Number),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = rwid;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_JCJL.Select_KG_JCJLbyID",parament,"table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 检查记录更新
        protected void Update_JCJL(Struct_jcgl struct_jcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={    new OracleParameter("p_rwid",OracleType.Int32),
                                                 new OracleParameter("p_jcsj",OracleType.DateTime),
                                                 new OracleParameter("p_bjdw",OracleType.VarChar),
                                                 new OracleParameter("p_jcxm",OracleType.VarChar),
                                                 new OracleParameter("p_jcjg",OracleType.VarChar),
                                                 new OracleParameter("p_zgyj",OracleType.VarChar),
                                                 new OracleParameter("p_zrdw",OracleType.VarChar),
                                                 new OracleParameter("p_zrr",OracleType.VarChar),
                                                 new OracleParameter("p_lsqkfk",OracleType.VarChar),
                                                 new OracleParameter("p_bz",OracleType.VarChar),
                                                 new OracleParameter("p_jcr",OracleType.VarChar),
                                                 new OracleParameter("p_jcd",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                                  //new OracleParameter("p_filepath",OracleType.VarChar)
                                            };
                parament[0].Value = struct_jcgl.rwid;
                parament[1].Value = struct_jcgl.jcsj;
                parament[2].Value = struct_jcgl.bjdw;
                parament[3].Value = struct_jcgl.jcxm;
                parament[4].Value = struct_jcgl.jcjg;
                parament[5].Value = struct_jcgl.zgyj;
                parament[6].Value = struct_jcgl.tzzrdw;
                parament[7].Value = struct_jcgl.tzzrry;
                parament[8].Value = struct_jcgl.lsqkfk;
                parament[9].Value = struct_jcgl.bz;
                parament[10].Value = struct_jcgl.jcr;
                parament[11].Value = struct_jcgl.jcd;
                parament[12].Direction = ParameterDirection.Output;
                //parament[13].Value = struct_jcgl.jcd;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_JCJL.Update_KG_JCJL", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[12].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jcgl.p_czfs;
                struct_rz.czxx = struct_jcgl.p_czxx;
                // rz.RZ_Insert_CZ(struct_rz);                
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 检查记录删除
        protected void Delete_JCJL(string rwid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parameter ={
                                                new OracleParameter("p_rwid",OracleType.Number),
                                                new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parameter[0].Value = rwid;
                parameter[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_JCJL.Delete_KG_JCGL",parameter,out reslut);
                int returnCode = Convert.ToInt32(parameter[1].Value);
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
        #endregion
        #endregion
        #region 用部门岗位查询员工
        protected DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                       new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
                 };
                paras[0].Value = bmdm;
                paras[1].Value = gwdm;
                paras[2].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_JCJL.Select_YGbyBMGW", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        #region 通过填报单位和检查项目更新检查任务状态
        protected void Update_JCRWZT(Struct_jcgl struct_jcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={    
                                                 new OracleParameter("p_jcd",OracleType.VarChar),
                                                 new OracleParameter("p_jcxm",OracleType.VarChar),
                                                 new OracleParameter("p_jcjg",OracleType.VarChar),

                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                parament[0].Value = struct_jcgl.jcd;
                parament[1].Value = struct_jcgl.jcxm;
                parament[2].Value = struct_jcgl.jcjg;
                parament[3].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_JCJL.Update_JCRWZT", parament, out reslut);
                int returnCode = Convert.ToInt32(parament[3].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_jcgl.p_czfs;
                struct_rz.czxx = struct_jcgl.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                dbclass.Close();
            }
        }
        #endregion
        # region    查询对应的整改记录（详情页面）
        protected DataSet Select_ZGJL(Struct_jcgl struct_jcgl)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {                                                   
                                                    new OracleParameter("p_tbdw",OracleType.VarChar),
                                                    new OracleParameter("p_zgxm",OracleType.VarChar),                        
                                                    new OracleParameter("p_pagesize",OracleType.Int32),
                                                    new OracleParameter("p_currentpage",OracleType.Int32),                                                    
                                                    new OracleParameter ("p_cur",OracleType .Cursor )
                                             };


                parament[0].Value = struct_jcgl.jcd;
                parament[1].Value = struct_jcgl.jcxm;
                parament[2].Value = struct_jcgl.p_pagesize;
                parament[3].Value = struct_jcgl.p_currentpage;
                parament[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_JCJL.Select_KG_ZG", parament, "table");
                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }

        # endregion
        # region    查询对应的整改记录个数（详情页面）
        protected int Select_ZGJL_Count(Struct_jcgl struct_jcgl)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={                                               
                                                new OracleParameter("p_tbdw",OracleType.VarChar),
                                                new OracleParameter("p_zgxm",OracleType.VarChar),                                                                                                
                                                new OracleParameter ("p_cur",OracleType .Cursor )
                                             };
                parament[0].Value = struct_jcgl.jcd;
                parament[1].Value = struct_jcgl.jcxm;
                parament[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_JCJL.Select_KG_ZG_Count", parament, "table");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally { db.Close(); }
        }
        # endregion
    }
}
