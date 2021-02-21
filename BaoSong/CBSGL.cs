using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
   public  class CBSGL:OCBSGL
    {

        public CBSGL(UserState _usState) : base(_usState) { }
        public new  DataTable Select_CBSGL_Pro(Struct_CBSGL struct_cbsgl)
        {
            return base.Select_CBSGL_Pro(struct_cbsgl);
        }
        public new  int Select_CBSGL_Count(Struct_CBSGL struct_cbsgl)
        {
           return  base.Select_CBSGL_Count(struct_cbsgl);
        }
        public new void Insert_CBSGL(Struct_CBSGL struct_cbsgl)
        { base.Insert_CBSGL(struct_cbsgl); }
        public new void Update_CBSGL(Struct_CBSGL struct_cbsgl)
        { base.Update_CBSGL(struct_cbsgl); }
        public new void Delete_CBSGL(int id, string p_czfs, string p_czxx)
        { base.Delete_CBSGL(id,p_czfs,p_czxx); }
        public new DataTable Select_CBSGL_Detail(int id)
        { return base.Select_CBSGL_Detail(id); }
        public new DataTable Select_YGXMbyBH(string bh)
        {
            return base.Select_YGXMbyBH(bh);
        }
        public new DataTable Select_YGByBMDQ(string dqdm, string bmdm)
        {
            return base.Select_YGByBMDQ(dqdm, bmdm);
        }

    }
}
