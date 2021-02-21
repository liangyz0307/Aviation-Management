using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.Sys
{
    public class OYHJS
    {
        private UserState userState;
        //需要添加日志
        public OYHJS(UserState userState)
        {
            this.userState = userState;
        }
        #region  刘燕龙   角色的增删改查
        //查询所有的角色
        protected DataTable Select_YHJS_Pro(string p_jsmc, string p_bz, string p_currentpage, string p_pagesize)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                          new OracleParameter("p_jsmc",OracleType.VarChar),
                                          new OracleParameter("p_bz",OracleType.VarChar),
                                          new OracleParameter("p_currentpage",OracleType.VarChar),
                                          new OracleParameter("p_pagesize",OracleType.VarChar),
                                          new OracleParameter("p_cur",OracleType.Cursor)
                                       };
                op[0].Value = p_jsmc;
                op[1].Value = p_bz;
                op[2].Value = p_currentpage;
                op[3].Value = p_pagesize;
                op[4].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_YHJS_Pro", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        //查询所有的角色的数量
        protected DataTable Select_YHJS_Count(string p_jsmc, string p_bz)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                          new OracleParameter("p_jsmc",OracleType.VarChar),
                                          new OracleParameter("p_bz",OracleType.VarChar),
                                          new OracleParameter("p_cur",OracleType.Cursor)
                                       };
                op[0].Value = p_jsmc;
                op[1].Value = p_bz;
                op[2].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_YHJS_Count", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        //通过角色代码JSDM查询角色
        protected DataTable Select_JSbyJSDM(string p_jsdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                          new OracleParameter("p_jsdm",OracleType.VarChar),
                                          new OracleParameter("p_cur",OracleType.Cursor)
                                       };
                op[0].Value = p_jsdm;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_JSbyJSDM", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        //插入角色
        protected void Insert_JS(string p_jsmc, string p_bz, string czfs, string czxx)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {    new OracleParameter("p_jsmc",OracleType.VarChar),
                                            new OracleParameter("p_bz",OracleType.VarChar),
                                            new OracleParameter("p_errorCode" , OracleType.Int32)};
                op[0].Value = p_jsmc;
                op[1].Value = p_bz;
                op[2].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YHJS.Insert_JS", op, out result);
                int p_errorCode = Convert.ToInt32(op[2].Value);
                if (p_errorCode != 0)
                {
                    throw new EMException(p_errorCode);
                }
                /*
                 * 日志的添加
                 */
            }
            finally { db.Close(); }
        }
        //更新角色
        protected void Update_JS(string p_jsdm, string p_jsmc, string p_bz, string czfs, string czxx)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {
                       new OracleParameter("p_jsdm",OracleType.VarChar),
                    new OracleParameter("p_jsmc",OracleType.VarChar),
                                            new OracleParameter("p_bz",OracleType.VarChar),
                                            new OracleParameter("p_errorCode" , OracleType.Int32)};
                op[0].Value = p_jsdm;
                op[1].Value = p_jsmc;
                op[2].Value = p_bz;
                op[3].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YHJS.Update_JS", op, out result);
                int p_errorCode = Convert.ToInt32(op[3].Value);
                if (p_errorCode != 0)
                {
                    throw new EMException(p_errorCode);
                }
                /*
                 * 日志的添加
                 */
            }
            finally { db.Close(); }
        }
        //删除角色
        protected void Delete_JS(string p_jsdm, string czfs, string czxx)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {    new OracleParameter("p_jsdm",OracleType.VarChar),
                                            new OracleParameter("p_errorCode" , OracleType.Int32)};
                op[0].Value = p_jsdm;
                op[1].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YHJS.Delete_JS", op, out result);
                int p_errorCode = Convert.ToInt32(op[1].Value);
                if (p_errorCode != 0)
                {
                    throw new EMException(p_errorCode);
                }
                /*
                 * 日志的添加
                 */
            }
            finally { db.Close(); }
        }
        #endregion
        #region  刘燕龙   给用户分配角色的操作
        //查询用户拥有的权限 
        protected DataTable Select_YH_YJS(int p_yhid)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                          new OracleParameter("p_yhid",OracleType.Int32),
                                          new OracleParameter("p_cur",OracleType.Cursor)
                                       };
                op[0].Value = p_yhid;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_YH_YJS", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        //查询用户没有拥有的权限
        protected DataTable Select_YH_WJS(int p_yhid)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                          new OracleParameter("p_yhid",OracleType.Int32),
                                          new OracleParameter("p_cur",OracleType.Cursor)
                                       };
                op[0].Value = p_yhid;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_YH_WJS", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        //给用户分配权限
        protected void Insert_YH_JS(int p_yhid, string p_jsdm, string czfs, string czxx)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {
                                          new OracleParameter("p_yhid",OracleType.Int32),
                                          new OracleParameter("p_jsdm",OracleType.VarChar),
                                          new OracleParameter("p_errorCode",OracleType.Int32)
                                       };
                op[0].Value = p_yhid;
                op[1].Value = p_jsdm;
                op[2].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YHJS.Insert_YH_JS", op, out result);
                int p_erroeCode = Convert.ToInt32(op[2].Value);
                if (p_erroeCode != 0)
                {
                    throw new EMException(p_erroeCode);
                }
                /*
                 * 需要添加日志的记录
                 */
            }
            finally { db.Close(); }
        }
        protected void Delete_YH_JS(int p_yhid, string p_jsdm, string czfs, string czxx)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {
                                          new OracleParameter("p_yhid",OracleType.Int32),
                                          new OracleParameter("p_jsdm",OracleType.VarChar),
                                          new OracleParameter("p_errorCode",OracleType.Int32)
                                       };
                op[0].Value = p_yhid;
                op[1].Value = p_jsdm;
                op[2].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YHJS.Delete_YH_JS", op, out result);
                int p_erroeCode = Convert.ToInt32(op[2].Value);
                if (p_erroeCode != 0)
                {
                    throw new EMException(p_erroeCode);
                }
                /*
                 * 需要添加日志的记录
                 */
            }
            finally { db.Close(); }
        }
        #endregion
        #region  刘燕龙  查询角色的权限回显
        //查询角色拥有的权限
        protected DataTable Select_QX_DMbyJSDM(string jsdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {new OracleParameter("p_jsdm" , OracleType.VarChar),
                                        new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Value = jsdm;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_QX_DMbyJSDM", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        //查询功能权限
        protected DataTable Select_GNDM(string qxdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {new OracleParameter("p_qxdm" , OracleType.VarChar),
                                        new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Value = qxdm;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_GNDM", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        #endregion
        #region 邵晓文 角色-权限
        protected DataTable Select_QX_ALL()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                        new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_QX_ALL", op, "table").Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        protected void Insert_JS_QX(string jsdm, string dqdm, string qxdm)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {
                                            new OracleParameter("p_jsdm",OracleType.VarChar),
                                            new OracleParameter("p_dqdm",OracleType.VarChar),
                                            new OracleParameter("p_qxdm",OracleType.VarChar),
                                            new OracleParameter("p_errorCode" , OracleType.Int32)};
                op[0].Value = jsdm;
                op[1].Value = dqdm;
                op[2].Value = qxdm;
                op[3].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YHJS.Insert_JS_QX", op, out result);
                int p_errorCode = Convert.ToInt32(op[3].Value);
                if (p_errorCode != 0)
                {
                    throw new EMException(p_errorCode);
                }
            }
            finally
            {
                db.Close();
            }
            
        }

        protected void Delete_QXByJS(string jsdm)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {
                                            new OracleParameter("p_jsdm",OracleType.VarChar) };

                op[0].Value = jsdm;
                db.RunProcedure("PACK_KG_YHJS.Delete_QXByJS", op, out result);
            }
            finally
            {
                db.Close();
            }
        }
        protected DataTable Selete_QXByJS_DQ(string jsdm, string dqdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                                       new OracleParameter("p_jsdm",OracleType.VarChar),
                                                       new OracleParameter("p_dqdm", OracleType.VarChar),
                                                       new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Value = jsdm;
                op[1].Value = dqdm;
                op[2].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Selete_QXByJS_DQ", op, "table").Tables[0];
            }
            finally
            {
                db.Close();
            }
        }
        protected DataTable Select_QXByYHID(string yhid)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                    new OracleParameter("p_yhid",OracleType.VarChar),
                    new OracleParameter("p_cur" , OracleType.Cursor)
                };
                op[0].Value = yhid;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_QXByYHID", op, "table").Tables[0];
            }
            finally
            {
                db.Close();
            }
        }


        #endregion

        //根据部门查询权限
        protected DataTable Selete_QXByJS_BM(string jsdm, string bmdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                                       new OracleParameter("p_jsdm",OracleType.VarChar),
                                                       new OracleParameter("p_bmdm", OracleType.VarChar),
                                                       new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Value = jsdm;
                op[1].Value = bmdm;
                op[2].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Selete_QXByJS_BM", op, "table").Tables[0];
            }
            finally
            {
                db.Close();
            }
        }

        //根据用户ID查找部门权限
        protected DataTable Select_BMQXByYHID(string yhid)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                    new OracleParameter("p_yhid",OracleType.VarChar),
                    new OracleParameter("p_cur" , OracleType.Cursor)
                };
                op[0].Value = yhid;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_BMQXByYHID", op, "table").Tables[0];
            }
            finally
            {
                db.Close();
            }
        }

        //根据角色代码删除部门权限
        protected void Delete_BMQXByJS(string jsdm)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {
                                            new OracleParameter("p_jsdm",OracleType.VarChar) };

                op[0].Value = jsdm;
                db.RunProcedure("PACK_KG_YHJS.Delete_BMQXByJS", op, out result);
            }
            finally
            {
                db.Close();
            }
        }

        protected DataTable Select_BMQX_DMbyJSDM(string jsdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {new OracleParameter("p_jsdm" , OracleType.VarChar),
                                        new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Value = jsdm;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_BMQX_DMbyJSDM", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }

        //查询部门功能权限
        protected DataTable Select_BMGNDM(string qxdm)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {new OracleParameter("p_qxdm" , OracleType.VarChar),
                                        new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Value = qxdm;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_BMGNDM", op, "table").Tables[0];
            }
            finally { db.Close(); }
        }
        
        
        //插入部门权限
        protected void Insert_JSQX_BM(string jsdm, string bmdm, string qxdm)
        {
            DBClass db = new DBClass();
            int result = 0;
            try
            {
                OracleParameter[] op = {
                                            new OracleParameter("p_jsdm",OracleType.VarChar),
                                            new OracleParameter("p_bmdm",OracleType.VarChar),
                                            new OracleParameter("p_qxdm",OracleType.VarChar),
                                            new OracleParameter("p_errorCode" , OracleType.Int32)};
                op[0].Value = jsdm;
                op[1].Value = bmdm;
                op[2].Value = qxdm;
                op[3].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_KG_YHJS.Insert_JSQX_BM", op, out result);
                int p_errorCode = Convert.ToInt32(op[3].Value);
                if (p_errorCode != 0)
                {
                    throw new EMException(p_errorCode);
                }
            }
            finally
            {
                db.Close();
            }

        }

        //查询所有部门
        protected DataTable Select_BM()
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                        new OracleParameter("p_cur" , OracleType.Cursor) };
                op[0].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_KG_YHJS.Select_BM", op, "table").Tables[0];
            }
            finally
            {
                db.Close();
            }
        }




    }
}

