using CUST;
using CUST.MKG;
using Sys;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;


namespace CUST.MKG
{
    public struct Struct_YG_Pro
    {

        public string p_bh;//员工编号
        public string p_xm;//姓名
        public string p_sfzh;//身份证号
        public string p_xbdm;//性别
        public DateTime p_csrq;//出生日期
        public string p_xldm;//学历
        public string p_zzmmdm;//政治面貌代码
        public DateTime p_jrdzzsj;//加入党组织时间
        public DateTime p_jrdzzsj1;//加入党组织时间
        public DateTime p_zwzsdyrq;//转为正式党员日期
        public DateTime p_zwzsdyrq1;//转为正式党员日期
        public string p_lxdh;//联系电话
        public string p_bhyy;//驳回原因
        public string p_zt;//状态
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public string p_bmdm;//部门代码
        public string p_tzcz;
        public int p_userid;//用户id
    }
    public struct Struct_DY_Pro
    {
        public string p_bh;//员工编号
        public string p_dzzmc;//党组织名称
        public string p_jcdzbmc;//基层党支部名称
        public string p_dxzmc;//党小组名称
        public string p_dnzw;//党内职务
        public string p_ygxs;//用工形式
        public DateTime p_jrdzzsj;//加入党组织时间
        public DateTime p_jrdzzsj1;//加入党组织时间
        public DateTime p_zwzsdyrq;//转为正式党员日期
        public DateTime p_zwzsdyrq1;//转为正式党员日期
        public string p_bz;//备注
        public string p_zt;//状态
        public string p_bhyy;//驳回原因
        public string p_ip;//IP
        public DateTime p_czsj;//操作时间
        public string p_czfs;//操作方式
        public string p_czxx;//操作信息
        public string p_bmdm;//部门代码
        public string p_tzcz;

        public string p_dylx;//党员类型
        public DateTime p_djrdsqssj;//递交入党申请书时间
        public DateTime p_lwrdjjfzsj;//列为入积极分子时间
        public string p_pyr1;//培养人1
        public string p_pyr2;
        public DateTime p_jjfzpxbbysj;//积极分子培训班毕业时间
        public DateTime p_qdwfzdxsj;//确定为发展对象时间
        public string p_jsr1;//介绍人1
        public string p_jsr2;
        public string p_zzqk;//转正情况
        public string p_dfje;//党费金额
        public DateTime p_dfjzrq;//党费交致日期

    }

    public class ODYGL
    {
        private UserState _us = null;
        private RZ rz = null;
        public ODYGL(UserState userstate)
        {
            this._us = userstate;
            rz = new RZ(userstate);
        }
        //查询党员信息
        protected DataSet Select_YG_All(Struct_YG_Pro strcut_yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {

                                                 new OracleParameter("p_xm",OracleType.VarChar),
                                                 new OracleParameter("p_zzmmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_jrdzzsj",OracleType.DateTime),
                                                 new OracleParameter("p_jrdzzsj1",OracleType.DateTime),
                                                 new OracleParameter("p_zwzsdyrq",OracleType.DateTime),
                                                 new OracleParameter("p_zwzsdyrq1",OracleType.DateTime),
                                                  new OracleParameter("p_pagesize",OracleType.Int32),
                                                  new OracleParameter("p_currentpage",OracleType.Int32),
                                                  new OracleParameter("p_bmdm",OracleType.VarChar),
                                                  new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                             };
                parament[0].Value = strcut_yg.p_xm;
                parament[1].Value = strcut_yg.p_zzmmdm;
                parament[2].Value = strcut_yg.p_zt;
                parament[3].Value = strcut_yg.p_jrdzzsj;
                parament[4].Value = strcut_yg.p_jrdzzsj1;
                parament[5].Value = strcut_yg.p_zwzsdyrq;
                parament[6].Value = strcut_yg.p_zwzsdyrq1;
                parament[7].Value = strcut_yg.p_pagesize;
                parament[8].Value = strcut_yg.p_currentpage;
                parament[9].Value = strcut_yg.p_bmdm;
                parament[10].Value = strcut_yg.p_userid;
                parament[11].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_DYGL.Select_YG_All", parament, "table");
                return ds;

            }
            finally
            {
                dbclass.Close();
            }
        }
        //查询数量
        protected int Select_YG_Count(Struct_YG_Pro strcut_yg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] parament ={


                                                 new OracleParameter("p_xm",OracleType.VarChar),
                                                 new OracleParameter("p_zzmmdm",OracleType.VarChar),
                                                 new OracleParameter("p_zt",OracleType.VarChar),
                                                 new OracleParameter("p_jrdzzsj",OracleType.DateTime),
                                                 new OracleParameter("p_jrdzzsj1",OracleType.DateTime),
                                                 new OracleParameter("p_zwzsdyrq",OracleType.DateTime),
                                                 new OracleParameter("p_zwzsdyrq1",OracleType.DateTime),
                                                 new OracleParameter("p_bmdm",OracleType.VarChar),
                                                 new OracleParameter("p_userid",OracleType.Int32),
                                                 new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = strcut_yg.p_xm;
                parament[1].Value = strcut_yg.p_zzmmdm;
                parament[2].Value = strcut_yg.p_zt;
                parament[3].Value = strcut_yg.p_jrdzzsj;
                parament[4].Value = strcut_yg.p_jrdzzsj1;
                parament[5].Value = strcut_yg.p_zwzsdyrq;
                parament[6].Value = strcut_yg.p_zwzsdyrq1;
                parament[7].Value = strcut_yg.p_bmdm;
                parament[8].Value = strcut_yg.p_userid;
                parament[9].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_DYGL.Select_YG_Count", parament, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //添加
        protected void DY_Add(Struct_DY_Pro strcut_dy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                                 new OracleParameter("p_bh",OracleType.VarChar),
                                                 new OracleParameter("p_dzzmc",OracleType.VarChar),
                                                 new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                 new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                 new OracleParameter("p_dnzw",OracleType.VarChar),
                                                 new OracleParameter("p_ygxs",OracleType.VarChar),
                                                 new OracleParameter("p_jrdzzsj",OracleType.DateTime),
                                                 new OracleParameter("p_zwzsdyrq",OracleType.DateTime),
                                                 new OracleParameter("p_bz",OracleType.VarChar),
                                                 new OracleParameter("p_ip",OracleType.VarChar),
                                                 new OracleParameter("p_czsj",OracleType.DateTime),
                                                 new OracleParameter("p_tzcz",OracleType.VarChar),

                                                  new OracleParameter("p_dylx",OracleType.VarChar),
                                                  new OracleParameter("p_djrdsqssj",OracleType.DateTime),
                                                  new OracleParameter("p_lwrdjjfzsj",OracleType.DateTime),
                                                  new OracleParameter("p_pyr1",OracleType.VarChar),
                                                  new OracleParameter("p_pyr2",OracleType.VarChar),
                                                  new OracleParameter("p_jjfzpxbbysj",OracleType.DateTime),
                                                  new OracleParameter("p_qdwfzdxsj",OracleType.DateTime),
                                                  new OracleParameter("p_jsr1",OracleType.VarChar),
                                                  new OracleParameter("p_jsr2",OracleType.VarChar),
                                                  new OracleParameter("p_zzqk",OracleType.VarChar),
                                                  new OracleParameter("p_dfje",OracleType.VarChar),
                                                  new OracleParameter("p_dfjzrq",OracleType.DateTime),
                                                  new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = strcut_dy.p_bh;
                parament[1].Value = strcut_dy.p_dzzmc;
                parament[2].Value = strcut_dy.p_jcdzbmc;
                parament[3].Value = strcut_dy.p_dxzmc;
                parament[4].Value = strcut_dy.p_dnzw;
                parament[5].Value = strcut_dy.p_ygxs;
                parament[6].Value = strcut_dy.p_jrdzzsj;
                parament[7].Value = strcut_dy.p_zwzsdyrq;
                parament[8].Value = strcut_dy.p_bz;
                parament[9].Value = strcut_dy.p_ip;
                parament[10].Value = strcut_dy.p_czsj;
                parament[11].Value = strcut_dy.p_tzcz;

                parament[12].Value = strcut_dy.p_dylx;
                parament[13].Value = strcut_dy.p_djrdsqssj;
                parament[14].Value = strcut_dy.p_lwrdjjfzsj;
                parament[15].Value = strcut_dy.p_pyr1;
                parament[16].Value = strcut_dy.p_pyr2;
                parament[17].Value = strcut_dy.p_jjfzpxbbysj;
                parament[18].Value = strcut_dy.p_qdwfzdxsj;
                parament[19].Value = strcut_dy.p_jsr1;
                parament[20].Value = strcut_dy.p_jsr2;
                parament[21].Value = strcut_dy.p_zzqk;
                parament[22].Value = strcut_dy.p_dfje;
                parament[23].Value = strcut_dy.p_dfjzrq;
                parament[24].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DYGL.DY_Add", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[24].Value);
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
        //更新
        protected void DY_Edit(Struct_DY_Pro strcut_dy)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={

                                                 new OracleParameter("p_bh",OracleType.VarChar),
                                                 new OracleParameter("p_dzzmc",OracleType.VarChar),
                                                 new OracleParameter("p_jcdzbmc",OracleType.VarChar),
                                                 new OracleParameter("p_dxzmc",OracleType.VarChar),
                                                 new OracleParameter("p_dnzw",OracleType.VarChar),
                                                 new OracleParameter("p_ygxs",OracleType.VarChar),
                                                 new OracleParameter("p_jrdzzsj",OracleType.DateTime),
                                                 new OracleParameter("p_zwzsdyrq",OracleType.DateTime),
                                                 new OracleParameter("p_bz",OracleType.VarChar),

                                                 new OracleParameter("p_dylx",OracleType.VarChar),
                                                  new OracleParameter("p_djrdsqssj",OracleType.DateTime),
                                                  new OracleParameter("p_lwrdjjfzsj",OracleType.DateTime),
                                                  new OracleParameter("p_pyr1",OracleType.VarChar),
                                                  new OracleParameter("p_pyr2",OracleType.VarChar),
                                                  new OracleParameter("p_jjfzpxbbysj",OracleType.DateTime),
                                                  new OracleParameter("p_qdwfzdxsj",OracleType.DateTime),
                                                  new OracleParameter("p_jsr1",OracleType.VarChar),
                                                  new OracleParameter("p_jsr2",OracleType.VarChar),
                                                  new OracleParameter("p_zzqk",OracleType.VarChar),
                                                  new OracleParameter("p_dfje",OracleType.VarChar),
                                                  new OracleParameter("p_dfjzrq",OracleType.DateTime),
                                                 new OracleParameter("p_errorCode",OracleType.Int32)
                                           };

                parament[0].Value = strcut_dy.p_bh;
                parament[1].Value = strcut_dy.p_dzzmc;
                parament[2].Value = strcut_dy.p_jcdzbmc;
                parament[3].Value = strcut_dy.p_dxzmc;
                parament[4].Value = strcut_dy.p_dnzw;
                parament[5].Value = strcut_dy.p_ygxs;
                parament[6].Value = strcut_dy.p_jrdzzsj;
                parament[7].Value = strcut_dy.p_zwzsdyrq;
                parament[8].Value = strcut_dy.p_bz;

                parament[9].Value = strcut_dy.p_dylx;
                parament[10].Value = strcut_dy.p_djrdsqssj;
                parament[11].Value = strcut_dy.p_lwrdjjfzsj;
                parament[12].Value = strcut_dy.p_pyr1;
                parament[13].Value = strcut_dy.p_pyr2;
                parament[14].Value = strcut_dy.p_jjfzpxbbysj;
                parament[15].Value = strcut_dy.p_qdwfzdxsj;
                parament[16].Value = strcut_dy.p_jsr1;
                parament[17].Value = strcut_dy.p_jsr2;
                parament[18].Value = strcut_dy.p_zzqk;
                parament[19].Value = strcut_dy.p_dfje;
                parament[20].Value = strcut_dy.p_dfjzrq;
                parament[21].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DYGL.DY_Edit", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[21].Value);
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
        //详情
        protected DataSet Select_DYDetail(string bh)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                                   new OracleParameter("p_bh",OracleType.VarChar),
                                                   new OracleParameter("p_cur",OracleType.Cursor)
                                           };
                parament[0].Value = bh;
                parament[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = dbclass.RunProcedure("PACK_KG_DYGL.Select_XQbyBH ", parament, "table");

                return ds;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //详情更新
        protected void DYZT_Edit(string bh, string zt, string bhyy)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_bh",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = bh;
                paras[1].Value = zt;
                paras[2].Value = bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_DYGL.DYZT_Edit", paras, out rowsAffected);
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
        //删除
        protected void DY_Del(string bh, string p_czfs, string p_czxx)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bh",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                           };
                parament[0].Value = bh;
                parament[1].Direction = ParameterDirection.Output;
                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_DYGL.DY_Del", parament, out reslut);

                int returnCode = Convert.ToInt32(parament[1].Value);
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
    }
}
