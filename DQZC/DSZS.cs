using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class DSZS : ODSZS
    {
        public DSZS(UserState _usState) : base(_usState) { }

        public new DataTable Select_DSZS_Pro(Struct_DSZS struct_DSZS)
        {
            return base.Select_DSZS_Pro(struct_DSZS);
        }
        public new int Select_DSZS_Count(Struct_DSZS struct_DSZS)
        {
            return base.Select_DSZS_Count(struct_DSZS);
        }
        public new DataTable Select_DSZSShow_Pro(Struct_DSZS struct_DSZS)
        {
            return base.Select_DSZSShow_Pro(struct_DSZS);
        }
        public new int Select_DSZSShow_Count(Struct_DSZS struct_DSZS)
        {
            return base.Select_DSZSShow_Count(struct_DSZS);
        }
        public new DataTable Select_DSZS_Detail(int id)
        {
            return base.Select_DSZS_Detail(id);
        }

        public new DataTable Find_DSZS_ById()
        {
            return base.Find_DSZS_ById();
        }
        public new void Insert_DSZS(Struct_DSZS struct_DSZS)
        {
            base.Insert_DSZS(struct_DSZS);
        }

        public new void Update_DSZS(Struct_DSZS struct_DSZS)
        {
            base.Update_DSZS(struct_DSZS);
        }
        public new void Update_DSZSZT(Struct_DSZS struct_DSZS)
        {
            base.Update_DSZSZT(struct_DSZS);
        }
        public new void Delete_DSZS(int id, string p_czfs, string p_czxx)
        {
            base.Delete_DSZS(id, p_czfs, p_czxx);
        }

    }
}