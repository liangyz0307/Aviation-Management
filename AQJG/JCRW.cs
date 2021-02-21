using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public class JCRW : OJCRW
    {
        public JCRW(UserState us) : base(us) { }
        public new DataSet Select_JCRW_Pro(Struct_JCRW struct_jcrw)
        {
            return base.Select_JCRW_PRO(struct_jcrw);
        }
        public new int Select_JCRW_Count(Struct_JCRW struct_jcrw)
        {
            return base.Select_JCRW_Count(struct_jcrw);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }
        public new void Insert_JCRW(Struct_JCRW struct_jcrw)
        {
            base.Insert_JCRW(struct_jcrw);
        }
        public new DataTable Select_YGCF_Detail(long id)
        {
            return base.Select_JCRW_Detail(id);
        }
        public new void Update_JCRW(Struct_JCRW struct_jcrw)
        {
            base.Update_YGCF(struct_jcrw);
        }
        public new void Delete_JCRW_byID(Struct_JCRW struct_jcrw)
        {
            base.Delete_JCRW_byID(struct_jcrw);
        }
        //public new void Update_JCRWZT(Struct_JCRW struct_jcrw)
        //{
        //    base.Update_JCRWZT(struct_jcrw);
        //}
        public new DataTable Select_JCXM(String tbdw)
        {
            return base.Select_JCXM(tbdw);
        }
        //查询对应的检查任务（详情页面）
        public new DataSet Select_JCJL(Struct_JCRW struct_jcrw)
        {
            return base.Select_JCJL(struct_jcrw);
        }
        //查询对应的检查任务个数（详情页面）
        public new int Select_KG_JCGL_Count(Struct_JCRW struct_jcrw)
        {
            return base.Select_KG_JCGL_Count(struct_jcrw);
        }
    }
}
