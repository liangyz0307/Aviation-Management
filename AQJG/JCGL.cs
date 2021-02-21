using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Sys;


namespace CUST.MKG
{
    public class JCGL:OJCGL
    {
        public JCGL(UserState userstate) : base(userstate) { }
        public new DataSet Select_JCJL(Struct_jcgl struct_jcgl)
        {
            return base.Select_JCJL(struct_jcgl); 
        }
        public new int Select_KG_JCGL_Count(Struct_jcgl struct_jcgl)
        {
            return base.Select_KG_JCGL_Count(struct_jcgl);
        }
        public new void Insert_JCJL(Struct_jcgl struct_jcgl)
        {
            base.Insert_JCJL(struct_jcgl);
        }
        public new DataTable Select_JCRW(string jcd)
        {
            return base.Select_JCRW(jcd);
        }
        public new DataTable Select_JCRWID(string jcd, string jcxm)
        {
            return base.Select_JCRW(jcd,jcxm);
        }
        public new  DataSet Select_JCJL_Detil(int id)
        {
            return base.Select_JCJL_Detil(id);
        }
        public new void Update_JCJL(Struct_jcgl struct_jcgl)
        {
            base.Update_JCJL(struct_jcgl);
        }
        public new void Delete_JCJL(string id)
        {
            base.Delete_JCJL(id);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
          return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        //通过填报单位和检查项目更新检查任务状态
        public new void Update_JCRWZT(Struct_jcgl struct_jcgl)
        {
            base.Update_JCRWZT(struct_jcgl);
        }
        //查询对应的整改记录（详情页面）
        public new DataSet Select_ZGJL(Struct_jcgl struct_jcgl)
        {
            return base.Select_ZGJL(struct_jcgl);
        }
        //查询对应的整改记录个数（详情页面）
        public new int Select_ZGJL_Count(Struct_jcgl struct_jcgl)
        {
            return base.Select_ZGJL_Count(struct_jcgl);
        }
    }
}

