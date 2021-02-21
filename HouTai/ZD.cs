using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CUST.MKG
{
    public class ZD : OZD
    {
        public ZD(UserState us) : base(us) { }
        public new DataSet Select_ZD_Pro(Struct_ZD_Pro struct_ZD_Pro)
        {
            return base.Select_ZD_Pro(struct_ZD_Pro);
        }
        public new int Select_ZD_Count(Struct_ZD_Pro struct_ZD_Pro)
        {
            return base.Select_ZD_Count(struct_ZD_Pro);
        }
        public new void Insert_ZD(Struct_ZD_Pro struct_ZD_Pro)
        {
            base.Insert_ZD(struct_ZD_Pro);
        }
        public new void Update_ZD(Struct_ZD_Pro struct_ZD_Pro)
        {
            base.Update_ZD(struct_ZD_Pro);
        }
        public new void Delete_ZD(Struct_ZD_Pro struct_ZD_Pro)
        {
            base.Delete_ZD(struct_ZD_Pro);
        }
    }
}
