using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using Sys;

namespace CUST.MKG
{
    public class HBYX :OHBYX
    {
        public HBYX(UserState us) : base(us) { }
        public new DataTable Select_HBYX_Pro(Struct_Select_HBYX hb)
        {
            return base.Select_HBYX_Pro(hb);
        }
        public new int Select_HBYX_Count(Struct_Select_HBYX hb)
        {
            return base.Select_HBYX_Count(hb);
        }
        public new DataTable Select_HBXX_Detail(string bsbh)
        {
            return base.Select_HBXX_Detail(bsbh);
        }
        public new  string SelectBS_HBYXMaxBH()
        {
            return base.SelectBS_HBYXMaxBH();
        }
        public new void Delete_HBYX_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            base.Delete_HBYX_byBH(bsbh, p_czfs, p_czxx);
        }
        public new void Insert_HBYX(Struct_HBYX hb)
        {
            base.Insert_HBYX(hb);
        }
        public new void Update_HBYX(Struct_HBYX hb)
        {
            base.Update_HBYX(hb);
        }

    }
}
