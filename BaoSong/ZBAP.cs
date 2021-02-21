using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys;
namespace CUST.MKG
{
   public  class ZBAP:OZBAP
    {
       public ZBAP(UserState us) : base(us) { }
        public new DataTable Select_ZBAP_Pro(Struct_Select_ZBAP struct_zbap)
        {
            return base.Select_ZBAP_Pro(struct_zbap);
        }
        public new int Select_ZBAP_Count(Struct_Select_ZBAP struct_zbap)
        {
            return base.Select_ZBAP_Count(struct_zbap);
        }
        public new string SelectBS_ZBAPMaxBH()
        {
            return base.SelectBS_ZBAPMaxBH();
        }
        public new DataTable Select_ZBAP_Detail(string bsbh)
        {
            return base.Select_ZBAP_Detail(bsbh);
        }
        public new void Delete_ZBAP_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            base.Delete_ZBAP_byBH(bsbh, p_czfs, p_czxx);
        }
        public new void Insert_ZBAP(Struct_ZBAP zbap)
        {
            base.Insert_ZBAP(zbap);
        }
        public new void Update_ZBAP(Struct_ZBAP zbap)
        {
            base.Update_ZBAP(zbap);
        }
    }
}
