using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct  Struct_JCD
    {
        public int id;
        public DateTime rq;         //日期
        public string zymc;       //专业名称
        public string ywbh;       //业务编号
        public string ywmc;       //业务名称
        public string gssc;       //公司手册
        public string xmbh;       //项目编号
        public string jcxm;       //检查内容
        public string nrbh;       //内容编号
        public string jcnr;       //检查内容
        public string jcff;       //检查方法
        public string jcbz;       //检查标准
        public string scyj;       //手册依据
        public string zrbm;       //责任部门
        public string sjbm;       //涉及部门
        public string jcpc;       //检查频次
        public string ly;         //来源
        public string bz;         //备注
        public string tbdw;       //填报单位
        public string sjbs;       //数据标识
        public string scip;       //上传IP
        public string scr;        //上传人

        public string czfs;       //操作方式
        public string czxx;       //操作信息
    }
    public  class OJCD
    {
        private UserState _us = null;
        private RZ rz = null;
        public OJCD(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }

        protected void Insert_JCD(Struct_JCD struct_jcd)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_id",OracleType.Int32),
                                                 new OracleParameter("p_rq",OracleType.DateTime), 
                                                 new OracleParameter("p_zymc",OracleType.VarChar),                                               
                                                 new OracleParameter("p_ywbh",OracleType.VarChar),
                                                 new OracleParameter("p_ywmc",OracleType.VarChar),
                                                 new OracleParameter("p_gssc",OracleType.VarChar),
                                                 new OracleParameter("p_xmbh",OracleType.VarChar),
                                                 new OracleParameter("p_jcxm",OracleType.VarChar),
                                                 new OracleParameter("p_nrbh",OracleType.VarChar),
                                                 new OracleParameter("p_jcnr",OracleType.VarChar),
                                                 new OracleParameter("p_jcff",OracleType.VarChar),
                                                 new OracleParameter("p_jcbz",OracleType.VarChar),
                                                 new OracleParameter("p_scyj",OracleType.VarChar),
                                                 new OracleParameter("p_zrbm",OracleType.VarChar),
                                                 new OracleParameter("p_sjbm",OracleType.VarChar),
                                                 new OracleParameter("p_jcpc",OracleType.VarChar),
                                                 new OracleParameter("p_ly",OracleType.VarChar),
                                                 new OracleParameter("p_bz",OracleType.VarChar),
                                                 new OracleParameter("p_tbdw",OracleType.VarChar),
                                                 new OracleParameter("p_sjbs",OracleType.VarChar),
                                                 new OracleParameter("p_scip",OracleType.VarChar),
                                                 new OracleParameter("p_scr",OracleType.VarChar),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                             };
                parament[0].Value = struct_jcd.id;
                parament[1].Value = struct_jcd.rq;
                parament[2].Value = struct_jcd.zymc;
                parament[3].Value = struct_jcd.ywbh;
                parament[4].Value = struct_jcd.ywmc;
                parament[5].Value = struct_jcd.gssc;
                parament[6].Value = struct_jcd.xmbh;
                parament[7].Value = struct_jcd.jcxm;
                parament[8].Value = struct_jcd.nrbh;
                parament[9].Value = struct_jcd.jcnr;
                parament[10].Value = struct_jcd.jcff;
                parament[11].Value = struct_jcd.jcbz;
                parament[12].Value = struct_jcd.scyj;
                parament[13].Value = struct_jcd.zrbm;
                parament[14].Value = struct_jcd.sjbm;
                parament[15].Value = struct_jcd.jcpc;
                parament[16].Value = struct_jcd.ly;
                parament[17].Value = struct_jcd.bz;
                parament[18].Value = struct_jcd.tbdw;
                parament[19].Value = struct_jcd.sjbs;
                parament[20].Value = struct_jcd.scip;
                parament[21].Value = struct_jcd.scr;
                parament[22].Direction = ParameterDirection.Output;
                int reslut = 0;
                int returnCode = Convert.ToInt32(parament[22].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
                dbclass.RunProcedure("PACK_AQJG_JCD.Insert_JCD", parament, out reslut);
            }
            finally
            {
                dbclass.Close();
            }
        }
        protected void Update_sjbs(string tbdw, string czfs, string czxx)
        {
            DBClass db = new DBClass();
            try
            {
                  OracleParameter[] paras ={
                  new OracleParameter("p_tbdw",OracleType.Number),
                  new OracleParameter("p_errorCode",OracleType.Int32)
            };
                paras[0].Value = tbdw;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_AQJG_JCD.Update_SJBS", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = czfs;
                struct_rz.czxx = czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
    }
}
