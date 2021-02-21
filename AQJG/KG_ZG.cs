using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class KG_ZG : OKG_ZG
    {
        public KG_ZG(UserState us) : base(us) { }

        public new DataSet Select_ZG_Pro(Struct_KG_Select_ZG struct_kg_zg)
        {
            return base.Select_ZG_Pro(struct_kg_zg);
        }
        public new int Select_ZG_Count(Struct_KG_Select_ZG kg_zg)
        {
            return base.Select_ZG_Count(kg_zg);
        }
        public new DataTable Select_ZG_Detail(long id)
        {
            return base.Select_ZG_Detail(id);
        }

        public new void Insert_ZG(Struct_KG_ZG struct_kg_zg)
        {
            base.Insert_ZG(struct_kg_zg);
        }

        public new void Update_ZG(Struct_KG_ZG struct_kg_zg)
        {
            base.Update_ZG(struct_kg_zg);
        }
        public new void Delete_ZG(long p_id, string p_czfs, string p_czxx)
        {
            base.Delete_ZG(p_id,p_czfs,p_czxx);
        }

        public void ZG_Edit(Struct_KG_ZG struct_kg_zg)
        {
            throw new NotImplementedException();
        }

        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }

        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new void Update_ZG_ZT(Struct_KG_Select_ZG struct_kg_zg)
        {
            base.Update_ZG_ZT(struct_kg_zg);
        }
        public new DataTable Select_JCJL(string jcd)
        {
            return base.Select_JCJL (jcd);
        }
        public new DataTable Select_JCJLID(string jcd, string jcxm)
        {
            return base.Select_JCJL(jcd, jcxm);
        }
    }
}
