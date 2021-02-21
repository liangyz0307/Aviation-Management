using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CUST.MKG
{
    public struct Struct_YG
    {
        public int p_id;//id
        public string p_bh;//员工编号1
        public string p_xm;//员工姓名2
        public string p_xbdm;//性别代码3
        public string p_sfzh;//员工身份证号4
        public string p_lxdh;//联系电话5
        public string p_bmdm;//部门代码6
        public string p_gwdm;//岗位代码7
        public string p_zt;//状态代码
        public string p_gzddm;//工作地点码8
        public string p_xxdz;//详细地址9
        public string p_jg;//籍贯10
        public string p_byyx;//毕业院校11
        public string p_zy;//专业12
        public string p_xldm;//学历代码13
        public string p_bysj;//毕业时间14
        public string p_rzsj;//入职时间15
        public string p_zzmmdm;//政治面貌代码16
        public string p_rdsj;//入党时间17
        public string p_htgx;//合同关系30
        public string p_htlxdm;//合同类型31

        public string p_ygxz;//用工性质

        public string p_bz;//备注32
        public string p_mzdm;//民族代码33
        public DateTime p_csrq;//出生日期34
        public string p_zplj;//照片路径
        public string p_czfs;
        public string p_czxx;
        public string p_rznf;//入职年份
        public string p_sjc;//时间戳
        public string p_shsj;//审核时间
        public string p_lrr;//录入人
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_sjbs;//数据标识
        public string p_sjssbm;//数据标识
        public string p_bhyy;//驳回原因
        public string p_mz;//民族
        public string p_zzmm;//政治面貌
        public string p_xb;//性别
        public DateTime p_csrq_qs;//出生日期_起始
        public DateTime p_csrq_jz;//出生日期_截止
        public string p_htlx;//合同类型
        public int p_userid;
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码


    }

    /*日程*/
    public struct Struct_Schedule
    {
        public string p_ygbh;//员工编号
        public int p_id;//日程ID
        public DateTime p_schedule_create_date;//日程创建时间
        public string p_schedule_description;//日程描述
        public string p_schedule_color;//提示颜色
        public DateTime p_schedule_plane_date;//日程计划时间
        public string p_schedule_title;//标题
        public int p_pagesize;   //每页容量
        public int p_currentpage;//当前页
        public string p_czfs;
        public string p_czxx;
    }
    public struct Struct_Select_YG
    {
        public string p_bh;//员工编号
        public string p_xm;//员工姓名
        public string p_sfzh;//员工身份证号
        public string p_bmdm;//部门代码
        public string p_gwdm;//岗位代码
        public string p_zt;//状态代码
        public string p_sjc;//时间戳
        public string p_shsj;//审核时间
        public string p_lrr;//录入人
        public string p_csr;//初审人
        public string p_zsr;//终审人
        public string p_sjbs;//数据标识
        public string p_sjssbm;//数据标识
        public int p_pagesize;//每页容量
        public int p_currentpage;//当前页码
        public int p_userid;
    }

    public class OYG
    {
        private UserState _us = null;
        private RZ rz = null;
        private UserState _usState=null;

        public OYG(UserState userstate)
        {
            this._us = userstate;
            this._usState = userstate;
            rz = new RZ(userstate);
        }

        #region 查询


        /// <summary>
        /// 查询员工表信息
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YG_Pro(Struct_YG yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bh",OracleType.VarChar),
                      new OracleParameter("p_xm",OracleType.VarChar),
                      new OracleParameter("p_sfzh",OracleType.VarChar),
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                      new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_zt",OracleType.VarChar),
                      new OracleParameter("p_userid",OracleType.Int32),
                      new OracleParameter("p_pagesize",OracleType.Int32),
                      new OracleParameter("p_currentpage",OracleType.Int32),
                      new OracleParameter("p_mz",OracleType.VarChar),
                      new OracleParameter("p_xb",OracleType.VarChar),
                      new OracleParameter("p_csrq_qs",OracleType.DateTime),
                      new OracleParameter("p_csrq_jz",OracleType.DateTime),
                      new OracleParameter("p_zzmm",OracleType.VarChar),
                      new OracleParameter("p_htlx",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };
                paras[0].Value = yg.p_bh;
                paras[1].Value = yg.p_xm;
                paras[2].Value = yg.p_sfzh;
                paras[3].Value = yg.p_bmdm;
                paras[4].Value = yg.p_gwdm;
                paras[5].Value = yg.p_zt;
                paras[6].Value = yg.p_userid;
                paras[7].Value = yg.p_pagesize;
                paras[8].Value = yg.p_currentpage;
                paras[9].Value = yg.p_mz;
                paras[10].Value = yg.p_xb;
                paras[11].Value = yg.p_csrq_qs;
                paras[12].Value = yg.p_csrq_jz;
                paras[13].Value = yg.p_zzmm;
                paras[14].Value = yg.p_htlx;
                paras[15].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_YG_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }





        
        //普通员工信息查询
        protected DataTable Select_YG_Pro_Ptyg(Struct_YG yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bh",OracleType.VarChar),
                      new OracleParameter("p_xm",OracleType.VarChar),
                      new OracleParameter("p_sfzh",OracleType.VarChar),
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                      new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_zt",OracleType.VarChar),
                      new OracleParameter("p_userid",OracleType.Int32),
                      new OracleParameter("p_pagesize",OracleType.Int32),
                      new OracleParameter("p_currentpage",OracleType.Int32),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };
                paras[0].Value = yg.p_bh;
                paras[1].Value = yg.p_xm;
                paras[2].Value = yg.p_sfzh;
                paras[3].Value = yg.p_bmdm;
                paras[4].Value = yg.p_gwdm;
                paras[5].Value = yg.p_zt;
                paras[6].Value = yg.p_userid;
                paras[7].Value = yg.p_pagesize;
                paras[8].Value = yg.p_currentpage;
                paras[9].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_YG_Pro_Ptyg", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        /// <summary>
        /// 查询员工数量
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected int Select_YGCount(Struct_YG yg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_bh",OracleType.VarChar),
                     new OracleParameter("p_xm",OracleType.VarChar),
                     new OracleParameter("p_sfzh",OracleType.VarChar),
                     new OracleParameter("p_bmdm",OracleType.VarChar),
                     new OracleParameter("p_gwdm",OracleType.VarChar),
                     new OracleParameter("p_zt",OracleType.VarChar),
                     new OracleParameter("p_userid",OracleType.Int32),
                     new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = yg.p_bh;
                paras[1].Value = yg.p_xm;
                paras[2].Value = yg.p_sfzh;
                paras[3].Value = yg.p_bmdm;
                paras[4].Value = yg.p_gwdm;
                paras[5].Value = yg.p_zt;
                paras[6].Value = yg.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_YGXX.Select_YGCount", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }
        //普通员工信息数量查询
        protected int Select_YGCount_Ptyg(Struct_YG yg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_bh",OracleType.VarChar),
                     new OracleParameter("p_xm",OracleType.VarChar),
                     new OracleParameter("p_sfzh",OracleType.VarChar),
                     new OracleParameter("p_bmdm",OracleType.VarChar),
                     new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_zt",OracleType.VarChar),
                       new OracleParameter("p_userid",OracleType.Int32),
                     new OracleParameter("p_cur",OracleType.Cursor)
                };
                paras[0].Value = yg.p_bh;
                paras[1].Value = yg.p_xm;
                paras[2].Value = yg.p_sfzh;
                paras[3].Value = yg.p_bmdm;
                paras[4].Value = yg.p_gwdm;
                paras[5].Value = yg.p_zt;
                paras[6].Value = yg.p_userid;
                paras[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = db.RunProcedure("PACK_KG_YGXX.Select_YGCount_Ptyg", paras, "tables");
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 查询员工详情
        /// </summary>
        /// <param name="yg"></param>
        /// <returns></returns>
        protected DataTable Select_YGDetail(int id)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_id",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = id;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_YGDetail", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        protected DataTable Select_YGDetail_ByBH(string bh)
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
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_YGDetail_ByBH", parament, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        protected string SelectYGMaxBH(string rzsj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                     new OracleParameter("p_rzsj",OracleType.VarChar),
                     new OracleParameter("p_maxbh",OracleType.VarChar,10)

                 };
                paras[0].Value = rzsj;
                paras[1].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YGXX.SelectYGMaxBH", paras, "dt");
                string maxbh = paras[1].Value.ToString();

                return maxbh;
            }
            finally
            {
                db.Close();
            }
        }


        /// <summary>
        /// 部门岗位联动
        /// </summary>
        /// <param name="bmdm"></param>
        /// <returns></returns>
        protected DataTable Select_GW_ByBM(string bmdm)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament ={
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_cur",OracleType.Cursor)
                                            };
                parament[0].Value = bmdm;
                parament[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_GW_ByBM", parament, "table").Tables[0];
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
        /// 删除员工表
        /// </summary>
        /// <param name="bh"></param>
        protected void Delete_YG(int id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_id",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                                         };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Delete_YG", paras, out rowsAffected);
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
        protected void Insert_YG(Struct_YG yg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                               new OracleParameter("p_bh",OracleType.VarChar),
                                               new OracleParameter("p_xm",OracleType.VarChar),
                                               new OracleParameter("p_xbdm",OracleType.VarChar),
                                               new OracleParameter("p_sfzh",OracleType.VarChar),
                                               new OracleParameter("p_lxdh",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_gzddm",OracleType.VarChar),
                                               new OracleParameter("p_xxdz",OracleType.VarChar),
                                               new OracleParameter("p_jg",OracleType.VarChar),
                                               new OracleParameter("p_byyx",OracleType.VarChar),
                                               new OracleParameter("p_zy",OracleType.VarChar),
                                               new OracleParameter("p_xldm",OracleType.VarChar),
                                               new OracleParameter("p_bysj",OracleType.VarChar),
                                               new OracleParameter("p_rzsj",OracleType.VarChar),
                                               new OracleParameter("p_zzmmdm",OracleType.VarChar),
                                               new OracleParameter("p_htgx",OracleType.VarChar),
                                               new OracleParameter("p_htlxdm",OracleType.VarChar),

                                               new OracleParameter("p_ygxz",OracleType.VarChar),//用工性质

                                               new OracleParameter("p_bz",OracleType.VarChar),
                                               new OracleParameter("p_mzdm",OracleType.VarChar),
                                               new OracleParameter("p_csrq",OracleType.DateTime),
                                               new OracleParameter("p_zplj",OracleType.VarChar),

                                               new OracleParameter("p_sjssbm",OracleType.VarChar),
                                               new OracleParameter("p_csr",OracleType.VarChar),
                                               new OracleParameter("p_zsr",OracleType.VarChar),
                                               new OracleParameter("p_lrr",OracleType.VarChar),
                                               new OracleParameter("p_sjc",OracleType.VarChar),
                                               new OracleParameter("p_sjbs",OracleType.VarChar),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                paras[0].Value = yg.p_bh;
                paras[1].Value = yg.p_xm;
                paras[2].Value = yg.p_xbdm;
                paras[3].Value = yg.p_sfzh;
                paras[4].Value = yg.p_lxdh;
                paras[5].Value = yg.p_bmdm;
                paras[6].Value = yg.p_gwdm;
                paras[7].Value = yg.p_gzddm;
                paras[8].Value = yg.p_xxdz;
                paras[9].Value = yg.p_jg;
                paras[10].Value = yg.p_byyx;
                paras[11].Value = yg.p_zy;
                paras[12].Value = yg.p_xldm;
                paras[13].Value = yg.p_bysj;
                paras[14].Value = yg.p_rzsj;
                paras[15].Value = yg.p_zzmmdm;
                paras[16].Value = yg.p_htgx;
                paras[17].Value = yg.p_htlxdm;

                paras[18].Value = yg.p_ygxz;

                paras[19].Value = yg.p_bz;
                paras[20].Value = yg.p_mzdm;
                paras[21].Value = yg.p_csrq;
                paras[22].Value = yg.p_zplj;

                paras[23].Value = yg.p_sjssbm;
                paras[24].Value = yg.p_csr;
                paras[25].Value = yg.p_zsr;
                paras[26].Value = yg.p_lrr;
                paras[27].Value = yg.p_sjc;
                paras[28].Value = yg.p_sjbs;
                paras[29].Value = yg.p_zt;
                paras[30].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Insert_YG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[30].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = yg.p_czfs;
                struct_rz.czxx = yg.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region  编辑
        protected void Update_YG(Struct_YG yg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                                               new OracleParameter("p_bh",OracleType.VarChar),
                                               new OracleParameter("p_xm",OracleType.VarChar),
                                               new OracleParameter("p_xbdm",OracleType.VarChar),
                                               new OracleParameter("p_sfzh",OracleType.VarChar),
                                               new OracleParameter("p_lxdh",OracleType.VarChar),
                                               new OracleParameter("p_bmdm",OracleType.VarChar),
                                               new OracleParameter("p_gwdm",OracleType.VarChar),
                                               new OracleParameter("p_gzddm",OracleType.VarChar),
                                               new OracleParameter("p_xxdz",OracleType.VarChar),
                                               new OracleParameter("p_jg",OracleType.VarChar),
                                               new OracleParameter("p_byyx",OracleType.VarChar),
                                               new OracleParameter("p_zy",OracleType.VarChar),
                                               new OracleParameter("p_xldm",OracleType.VarChar),
                                               new OracleParameter("p_bysj",OracleType.VarChar),
                                               new OracleParameter("p_rzsj",OracleType.VarChar),
                                               new OracleParameter("p_zzmmdm",OracleType.VarChar),
                                               //new OracleParameter("p_rdsj",OracleType.VarChar),
                                               //new OracleParameter("p_zzwjhm",OracleType.VarChar),
                                               //new OracleParameter("p_zzbh",OracleType.VarChar),
                                               //new OracleParameter("p_zzbfrq",OracleType.VarChar),
                                               //new OracleParameter("p_zzqzlb",OracleType.VarChar),
                                               //new OracleParameter("p_zclbyxq",OracleType.VarChar),
                                               //new OracleParameter("p_ydqz",OracleType.VarChar),
                                               //new OracleParameter("p_ydqzlb",OracleType.VarChar),
                                               //new OracleParameter("p_ydqzyxq",OracleType.VarChar),
                                               //new OracleParameter("p_yydj",OracleType.VarChar),
                                               //new OracleParameter("p_yyyxq",OracleType.VarChar),
                                               //new OracleParameter("p_tjdj",OracleType.VarChar),
                                               //new OracleParameter("p_tjyxq",OracleType.VarChar),
                                               new OracleParameter("p_htgx",OracleType.VarChar),
                                               new OracleParameter("p_htlxdm",OracleType.VarChar),

                                               new OracleParameter("p_ygxz",OracleType.VarChar),

                                               new OracleParameter("p_bz",OracleType.VarChar),
                                               new OracleParameter("p_mzdm",OracleType.VarChar),
                                               new OracleParameter("p_csrq",OracleType.DateTime),
                                               new OracleParameter("p_zplj",OracleType.VarChar),
                                               new OracleParameter("p_sjssbm",OracleType.VarChar),
                                               new OracleParameter("p_csr",OracleType.VarChar),
                                               new OracleParameter("p_zsr",OracleType.VarChar),
                                               new OracleParameter("p_lrr",OracleType.VarChar),
                                               new OracleParameter("p_sjbs",OracleType.VarChar),
                                               new OracleParameter("p_id",OracleType.Int32),
                                               new OracleParameter("p_zt",OracleType.VarChar),
                                               new OracleParameter("p_errorCode",OracleType.Int32)
                                            };
                paras[0].Value = yg.p_bh;
                paras[1].Value = yg.p_xm;
                paras[2].Value = yg.p_xbdm;
                paras[3].Value = yg.p_sfzh;
                paras[4].Value = yg.p_lxdh;
                paras[5].Value = yg.p_bmdm;
                paras[6].Value = yg.p_gwdm;
                paras[7].Value = yg.p_gzddm;
                paras[8].Value = yg.p_xxdz;
                paras[9].Value = yg.p_jg;
                paras[10].Value = yg.p_byyx;
                paras[11].Value = yg.p_zy;
                paras[12].Value = yg.p_xldm;
                paras[13].Value = yg.p_bysj;
                paras[14].Value = yg.p_rzsj;
                paras[15].Value = yg.p_zzmmdm;
                paras[16].Value = yg.p_htgx;
                paras[17].Value = yg.p_htlxdm;

                paras[18].Value = yg.p_ygxz;

                paras[19].Value = yg.p_bz;
                paras[20].Value = yg.p_mzdm;
                paras[21].Value = yg.p_csrq;
                paras[22].Value = yg.p_zplj;

                paras[23].Value = yg.p_sjssbm;
                paras[24].Value = yg.p_csr;
                paras[25].Value = yg.p_zsr;
                paras[26].Value = yg.p_lrr;
                paras[27].Value = yg.p_sjbs;
                paras[28].Value = yg.p_id;
                paras[29].Value = yg.p_zt;
                paras[30].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Update_YG", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[30].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = yg.p_czfs;
                struct_rz.czxx = yg.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion

        #region 更新状态
        protected void Update_YGXXZT(Struct_YG yg)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.VarChar),
                  new OracleParameter("p_zt",OracleType.VarChar),
                  new OracleParameter("p_bhyy",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };
                paras[0].Value = yg.p_id;
                paras[1].Value = yg.p_zt;
                paras[2].Value = yg.p_bhyy;
                paras[3].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Update_YGXXZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                //Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                //struct_rz.czfs = ygll.p_czfs;
                //struct_rz.czxx = ygll.p_czxx;
                //rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion


        protected void Update_YGXX_SJBS_ZT(Struct_YG ygxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={

                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygxx.p_sjc;
                paras[1].Value = ygxx.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Update_YGXX_SJBS_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygxx.p_czfs;
                struct_rz.czxx = ygxx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //将原最终数据变为历史数据
        protected void Update_YGXX_SJBS_LSSJ_ZT(Struct_YG ygxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygxx.p_sjc;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Update_YGXX_SJBS_LSSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[1].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygxx.p_czfs;
                struct_rz.czxx = ygxx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }


        #region 将副本数据变为最终数据
        protected void Update_YGXX_SJBS_FBSJ_ZT(Struct_YG ygxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_sjc",OracleType.VarChar),
                  new OracleParameter("p_shsj",OracleType.VarChar),
                  new OracleParameter("p_errorCode",OracleType.Int32)
        };

                paras[0].Value = ygxx.p_sjc;
                paras[1].Value = ygxx.p_shsj;
                paras[2].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Update_YGXX_SJBS_FBSJ_ZT", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[2].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = ygxx.p_czfs;
                struct_rz.czxx = ygxx.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        protected int YGXX_SJBF(int id)
        {
            //查出原始数据
            DataTable dt_detail = new DataTable();
            dt_detail = Select_YGDetail(id);
            //备份数据
            Struct_YG ygxx_bf = new Struct_YG();

            ygxx_bf.p_bh = dt_detail.Rows[0]["bh"].ToString();
            ygxx_bf.p_xm = dt_detail.Rows[0]["xm"].ToString();
            ygxx_bf.p_xbdm = dt_detail.Rows[0]["xbdm"].ToString();
            ygxx_bf.p_sfzh = dt_detail.Rows[0]["sfzh"].ToString();
            ygxx_bf.p_csrq = Convert.ToDateTime(dt_detail.Rows[0]["csrq"].ToString());
            ygxx_bf.p_mzdm = dt_detail.Rows[0]["mzdm"].ToString();
            ygxx_bf.p_lxdh = dt_detail.Rows[0]["lxdh"].ToString();
            ygxx_bf.p_gwdm = dt_detail.Rows[0]["gwdm"].ToString();
            ygxx_bf.p_bmdm = dt_detail.Rows[0]["bmdm"].ToString();
            ygxx_bf.p_gzddm = dt_detail.Rows[0]["gzddm"].ToString();
            ygxx_bf.p_xxdz = dt_detail.Rows[0]["xxdz"].ToString();
            ygxx_bf.p_jg = dt_detail.Rows[0]["jg"].ToString();
            ygxx_bf.p_byyx = dt_detail.Rows[0]["byyx"].ToString();
            ygxx_bf.p_zy = dt_detail.Rows[0]["zy"].ToString();
            ygxx_bf.p_xldm = dt_detail.Rows[0]["xldm"].ToString();
            ygxx_bf.p_bysj = dt_detail.Rows[0]["bysj"].ToString();
            ygxx_bf.p_rzsj = dt_detail.Rows[0]["rzsj"].ToString();
            ygxx_bf.p_zzmmdm = dt_detail.Rows[0]["zzmmdm"].ToString();
            ygxx_bf.p_htgx = dt_detail.Rows[0]["htgx"].ToString();
            ygxx_bf.p_htlxdm = dt_detail.Rows[0]["htlxdm"].ToString();

            ygxx_bf.p_ygxz = dt_detail.Rows[0]["ygxz"].ToString();

            ygxx_bf.p_zplj = dt_detail.Rows[0]["zplj"].ToString();
            ygxx_bf.p_bz = dt_detail.Rows[0]["bz"].ToString();
            ygxx_bf.p_zt = dt_detail.Rows[0]["zt"].ToString();
            ygxx_bf.p_bhyy = dt_detail.Rows[0]["bhyy"].ToString();

            ygxx_bf.p_lrr = _usState.userLoginName;
            ygxx_bf.p_csr = dt_detail.Rows[0]["csr"].ToString();
            ygxx_bf.p_zsr = dt_detail.Rows[0]["zsr"].ToString();
            ygxx_bf.p_sjc = dt_detail.Rows[0]["sjc"].ToString();
            ygxx_bf.p_sjssbm = dt_detail.Rows[0]["sjssbm"].ToString();
            ygxx_bf.p_sjbs = "2";
            ygxx_bf.p_shsj = "";

            ygxx_bf.p_czfs = "02";
            ygxx_bf.p_czxx = "员工奖励 ID:" + id + "生成副本数据";
            //插入
            Insert_YG(ygxx_bf);
            //查询ID
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] parament = {
                                                 new OracleParameter("p_sjc",OracleType.VarChar),
                                                 new OracleParameter("p_bfid",OracleType.Int32)
                                             };
                parament[0].Value = ygxx_bf.p_sjc;
                parament[1].Direction = ParameterDirection.Output;

                int reslut = 0;
                dbclass.RunProcedure("PACK_KG_YGXX.Select_YGXX_BFID", parament, out reslut);

                int ID_BF = Convert.ToInt32(parament[1].Value);
                return ID_BF;
            }
            finally
            {
                dbclass.Close();
            }
        }



        protected void Delete_YH_SPR_BYBH(string bh, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_bh",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                                         };
                paras[0].Value = bh;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Delete_YH_SPR_BYBH", paras, out rowsAffected);
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


        //数据导出
        protected DataTable Select_YG_DC(int p_userid)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_userid",OracleType.Int32),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };

                paras[0].Value = p_userid;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_YG_DC", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        //高级检索
        protected DataTable Select_YG_Pro_GJJS(Struct_YG yg)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_bh",OracleType.VarChar),
                      new OracleParameter("p_xm",OracleType.VarChar),
                      new OracleParameter("p_sfzh",OracleType.VarChar),
                      new OracleParameter("p_bmdm",OracleType.VarChar),
                      new OracleParameter("p_gwdm",OracleType.VarChar),
                      new OracleParameter("p_zt",OracleType.VarChar),
                      new OracleParameter("p_userid",OracleType.Int32),

                      new OracleParameter("p_mz",OracleType.VarChar),
                      new OracleParameter("p_zzmm",OracleType.VarChar),
                      new OracleParameter("p_xb",OracleType.VarChar),
                      new OracleParameter("p_csrq_qs",OracleType.VarChar),
                      new OracleParameter("p_csrq_jz",OracleType.VarChar),
                      new OracleParameter("p_htlx",OracleType.VarChar),
                      new OracleParameter("p_yydj",OracleType.VarChar),//英语等级
                      new OracleParameter("p_yyyxq",OracleType.VarChar),//英语有效期
                      new OracleParameter("p_zzwjhm",OracleType.VarChar),//执照文件号码
                      new OracleParameter("p_zzbh",OracleType.VarChar),//执照编号
                      new OracleParameter("p_zzbfrq",OracleType.VarChar),//执照颁发日期
                      new OracleParameter("p_qzzy",OracleType.VarChar),//签注专业
                      new OracleParameter("p_qzlb",OracleType.VarChar),//签注类别
                      new OracleParameter("p_qzyxq",OracleType.VarChar),//签注有效期
                      new OracleParameter("p_ydqzd",OracleType.VarChar),//异地签注地
                      new OracleParameter("p_ydqzyxq",OracleType.VarChar),//异地签注有效期
                      new OracleParameter("p_tjdj",OracleType.VarChar),//体检等级
                      new OracleParameter("p_tjyxq",OracleType.VarChar),//体检有效期
                      new OracleParameter("p_ygll",OracleType.VarChar),//员工履历
                      new OracleParameter("p_ygcf",OracleType.VarChar),//员工惩罚
                      new OracleParameter("p_ygjl",OracleType.VarChar),//员工奖励
                      new OracleParameter("p_ygpx",OracleType.VarChar),//员工培训
                      new OracleParameter("p_ygzc",OracleType.VarChar),//员工职称
                      new OracleParameter("p_cur",OracleType.Cursor)
               };
                paras[0].Value = yg.p_bh;
                paras[1].Value = yg.p_xm;
                paras[2].Value = yg.p_sfzh;
                paras[3].Value = yg.p_bmdm;
                paras[4].Value = yg.p_gwdm;
                paras[5].Value = yg.p_zt;
                paras[6].Value = yg.p_userid;

                paras[9].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_YG_Pro", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }


        #region 主页面日历上个人日程

        //根据编号查询全部日程
        protected DataTable Select_Schedule_By_Ygbh(Struct_Schedule struct_schedule)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_ygbh",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };
                paras[0].Value = struct_schedule.p_ygbh;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_SCHEDULE_BY_YGBH", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }

        //根据ID查询指定日程
        protected DataTable Select_Schedule_By_Id(Struct_Schedule struct_schedule)
        {
            DBClass dbclass = new DBClass();
            try
            {
                OracleParameter[] paras ={
                      new OracleParameter("p_id",OracleType.VarChar),
                      new OracleParameter("p_cur",OracleType.Cursor)
               };
                paras[0].Value = struct_schedule.p_id;
                paras[1].Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = dbclass.RunProcedure("PACK_KG_YGXX.Select_SCHEDULE_BY_ID", paras, "table").Tables[0];
                return dt;
            }
            finally
            {
                dbclass.Close();
            }
        }
        //添加
        public void Insert_Schedule(Struct_Schedule struct_schedule)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_ygbh",OracleType.VarChar),
                  new OracleParameter("p_schedule_create_date",OracleType.DateTime),
                  new OracleParameter("p_schedule_color",OracleType.VarChar),
                  new OracleParameter("p_schedule_plane_date",OracleType.DateTime),
                  new OracleParameter("p_schedule_title",OracleType.VarChar),
                  new OracleParameter("p_schedule_description",OracleType.VarChar),
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_schedule.p_ygbh;
                paras[1].Value = struct_schedule.p_schedule_create_date;
                paras[2].Value = struct_schedule.p_schedule_color;
                paras[3].Value = struct_schedule.p_schedule_plane_date;
                paras[4].Value = struct_schedule.p_schedule_title;
                paras[5].Value = struct_schedule.p_schedule_description;
                paras[6].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Insert_SCHEDULE", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[6].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_schedule.p_czfs;
                struct_rz.czxx = struct_schedule.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //编辑
        public void Update_Schedule(Struct_Schedule struct_schedule)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras ={
                  new OracleParameter("p_id",OracleType.Int32),
                  new OracleParameter("p_ygbh",OracleType.VarChar),
                  new OracleParameter("p_schedule_create_date",OracleType.DateTime),
                  new OracleParameter("p_schedule_color",OracleType.VarChar),
                  new OracleParameter("p_schedule_plane_date",OracleType.DateTime),
                  new OracleParameter("p_schedule_title",OracleType.VarChar),
                  new OracleParameter("p_schedule_description",OracleType.VarChar),
                  new OracleParameter("p_errorCode", OracleType.Int32)
            };
                paras[0].Value = struct_schedule.p_id;
                paras[1].Value = struct_schedule.p_ygbh;
                paras[2].Value = struct_schedule.p_schedule_create_date;
                paras[3].Value = struct_schedule.p_schedule_color;
                paras[4].Value = struct_schedule.p_schedule_plane_date;
                paras[5].Value = struct_schedule.p_schedule_title;
                paras[6].Value = struct_schedule.p_schedule_description;
                paras[7].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Update_SCHEDULE", paras, out rowsAffected);
                int errorCode = 0;
                errorCode = Convert.ToInt32(paras[7].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
                //插入日志表
                Struct_RZ_YH struct_rz = new Struct_RZ_YH();
                struct_rz.czfs = struct_schedule.p_czfs;
                struct_rz.czxx = struct_schedule.p_czxx;
                rz.RZ_Insert_CZ(struct_rz);
            }
            finally
            {
                db.Close();
            }
        }

        //删除
        protected void Delete_Schedule(int id, string p_czfs, string p_czxx)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                               new OracleParameter("p_id",OracleType.VarChar),
                               new OracleParameter("p_errorCode",OracleType.Int32)
                                         };
                paras[0].Value = id;
                paras[1].Direction = ParameterDirection.Output;
                int rowsAffected = 0;
                db.RunProcedure("PACK_KG_YGXX.Delete_SCHEDULE", paras, out rowsAffected);
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




    }

}
