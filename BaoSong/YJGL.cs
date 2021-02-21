using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{

   public  class YJGL:OYJGL
    {
        public YJGL(UserState _usState) : base(_usState) { }
        public new  DataTable Select_YJGL_Pro(Struct_YJGL struct_yjgl)
        {
            return base.Select_YJGL_Pro(struct_yjgl);
        }
        public new  int Select_YJGL_Count(Struct_YJGL struct_yjgl)
        {
            return base.Select_YJGL_Count(struct_yjgl);

        }
        public new  void Insert_YJGL(Struct_YJGL struct_yjgl)
        {
              base.Insert_YJGL(struct_yjgl);

        }
        public new void Update_YJGL(Struct_YJGL struct_yjgl)
        {
            base.Update_YJGL(struct_yjgl);

        }
        public new void Delete_YJGL(int id, string p_czfs, string p_czxx)
        {
            base.Delete_YJGL(id, p_czfs, p_czxx);

        }
        public new DataTable Select_YJGL_Detail(int id)
        {
            return  base.Select_YJGL_Detail(id );

        }
        public new  DataTable Select_YGXMbyBH(string bh)
        {
            return base.Select_YGXMbyBH(bh);

        }
        public new  DataTable Select_YGByBMDQ(string dqdm, string bmdm)
        {
            return base.Select_YGByBMDQ(dqdm, bmdm);

        }



    }
}
