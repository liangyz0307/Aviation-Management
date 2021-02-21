using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys;

namespace CUST.MKG
{
    public class RZ : ORZ
    {
        public RZ(UserState us) : base(us) { }
        //插入日志
        public new void RZ_Insert_CZ(Struct_RZ_YH rz_struct)
        {
            base.RZ_Insert_CZ(rz_struct);
        }
        public new DataTable Select_RZ_Pro(Struct_Select_RZ rz)
        {
            return base.Select_RZ_Pro(rz);
        }
        public new int Select_RZ_Count(Struct_Select_RZ rz)
        {
            return base.Select_RZ_Count(rz);
        }
    }
}
