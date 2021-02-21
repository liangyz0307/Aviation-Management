using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace CUST.MKG
{

    public class BCGL : OBCGL
    {
        public BCGL(UserState _usState) : base(_usState) { }


    public new DataTable Select_BCGL_Pro(Struct_BCGL struct_bcgl)
    {
        return base.Select_BCGL_Pro(struct_bcgl);

    }
        public new  int Select_BCGL_Count(Struct_BCGL struct_bcgl)
        {
            return base.Select_BCGL_Count(struct_bcgl);

        }
        public new void Insert_BCGL(Struct_BCGL struct_bcgl)
        {
            base.Insert_BCGL(struct_bcgl);
        }
        public new  void Update_BCGL(Struct_BCGL struct_bcgl)
        {
            base.Update_BCGL(struct_bcgl);

        }
        public new  void Delete_BCGL(int id, string p_czfs, string p_czxx)
        {
            base.Delete_BCGL(id, p_czfs, p_czxx);

        }
        public new DataTable Select_BCGL_Detail(int id)
        {
          return  base.Select_BCGL_Detail(id );

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




