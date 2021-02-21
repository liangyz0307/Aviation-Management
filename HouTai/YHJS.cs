using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.MKG
{
  public  class YHJS:OYHJS
    {
        public YHJS(UserState userState) : base(userState) { }

        public new DataTable Select_YH_YJS(int p_yhid)
        {
            return base.Select_YH_YJS(p_yhid);
        }
        public new DataTable Select_YH_WJS(int p_yhid)
        {
            return base.Select_YH_WJS(p_yhid);
        }
        public new void Insert_YH_JS(int p_yhid, string p_roleid, string czfs, string czxx)
        {
            base.Insert_YH_JS(p_yhid, p_roleid, czfs, czxx);
        }
        public new void Delete_YH_JS(int p_yhid, string p_roleid, string czfs, string czxx)
        {
            base.Delete_YH_JS(p_yhid, p_roleid, czfs, czxx);
        }
        public new DataTable Select_YHJS_Pro(string p_jsdm, string p_bz, string p_currentpage, string p_pagesize)
        {
            return base.Select_YHJS_Pro(p_jsdm, p_bz, p_currentpage, p_pagesize);
        }
        public new DataTable Select_YHJS_Count(string p_jsdm, string p_bz)
        {
            return base.Select_YHJS_Count(p_jsdm, p_bz);
        }
        public new DataTable Select_JSbyJSDM(string p_jsdm)
        {
            return base.Select_JSbyJSDM(p_jsdm);
        }
        //插入角色
        public new void Insert_JS(string p_jsmc, string p_bz, string czfs, string czxx)
        {
            base.Insert_JS(p_jsmc, p_bz, czfs, czxx);
        }
        //更新角色
        public new void Update_JS(string p_jsdm, string p_jsmc, string p_bz, string czfs, string czxx)
        {
            base.Update_JS(p_jsdm, p_jsmc,p_bz, czfs, czxx);
        }
        //删除角色
        public new void Delete_JS(string p_jsdm, string czfs, string czxx)
        {
            base.Delete_JS(p_jsdm, czfs, czxx);
        }
        public new DataTable Select_QX_DMbyJSDM(string jsdm)
        {
            return base.Select_QX_DMbyJSDM(jsdm);
        }
        public new DataTable Select_GNDM(string qxdm)
        {
            return base.Select_GNDM(qxdm);
        }
        public new DataTable Select_QX_ALL()
        { return base.Select_QX_ALL(); }

        public new void Insert_JS_QX( string jsdm, string dqdm, string qxdm)
        {
            base.Insert_JS_QX( jsdm, dqdm,qxdm);
        }
        public new void Delete_QXByJS(string jsdm)
        {
            base.Delete_QXByJS(jsdm);
        }
        public new DataTable Selete_QXByJS_DQ(string jsdm, string dqdm)
        {
            return base.Selete_QXByJS_DQ(jsdm, dqdm);
        }




        //部门权限
        public new DataTable Selete_QXByJS_BM(string jsdm, string bmdm)
        {
            return base.Selete_QXByJS_BM(jsdm, bmdm);
        }
        public new void Delete_BMQXByJS(string jsdm)
        {
            base.Delete_BMQXByJS(jsdm);
        }
        public new void Insert_JSQX_BM(string jsdm, string bmdm, string qxdm)
        {
            base.Insert_JSQX_BM(jsdm, bmdm, qxdm);
        }
        public new DataTable Select_BMGNDM(string qxdm)
        {
            return base.Select_BMGNDM(qxdm);
        }
        public new DataTable Select_BMQX_DMbyJSDM(string jsdm)
        {
            return base.Select_BMQX_DMbyJSDM(jsdm);
        }
        public new DataTable Select_BM()
        {
            return base.Select_BM();
        }
    }
}

