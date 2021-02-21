using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public  class THGL: OTHGL
    {
        public THGL(UserState _usState) : base(_usState) { }
        public new     DataTable Select_THGL_Pro(Struct_THGL struct_thgl)
        {
            return base.Select_THGL_Pro(struct_thgl);
        }
        public new  int Select_THGL_Count(Struct_THGL struct_thgl)
        {
            return base.Select_THGL_Count(struct_thgl);

        }
        protected new void Insert_THGL(Struct_THGL struct_thgl)
        {
            base.Insert_THGL(struct_thgl);
        }
        public new  void Update_CBSGL(Struct_THGL struct_thgl)
        {
            base.Update_CBSGL(struct_thgl);

        }
        protected new void Delete_THGL(int id, string p_czfs, string p_czxx)
        {
            base.Delete_THGL(id, p_czfs, p_czxx);

        }
        public new DataTable Select_THGL_Detail(int id)
        {
           return  base.Select_THGL_Detail(id );

        }
        public new  DataTable Select_YGXMbyBH(string bh)
        {
            return  base.Select_YGXMbyBH(bh );
      
        }
        public new  DataTable Select_YGByBMDQ(string dqdm, string bmdm)
        {
            return base.Select_YGByBMDQ(dqdm, dqdm);
        }

    }
}
