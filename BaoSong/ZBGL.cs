using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{

    public class ZBGL : OZBGL
    {
        public ZBGL(UserState _usState) : base(_usState) { }
        public new DataTable Select_ZBGL_Pro(Struct_ZBGL struct_zbgl)
        {
            return base.Select_ZBGL_Pro(struct_zbgl);
        }
        public new int Select_ZBGL_Count(Struct_ZBGL struct_zbgl) {
            return base.Select_ZBGL_Count(struct_zbgl);
        }

        public new void Insert_ZBGL(Struct_ZBGL struct_zbgl) {
            base.Insert_ZBGL(struct_zbgl);
        }
        public new  void Update_ZBGL(Struct_ZBGL struct_zbgl) {
            base.Update_ZBGL(struct_zbgl);
        }
        public new DataTable Select_YGByBMDQ(string dqdm, string bmdm)
        {
            return base.Select_YGByBMDQ(dqdm,bmdm);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }

        public new DataTable Select_ZBGL_Detail(int id) {
            return base.Select_ZBGL_Detail(id);
        }
        public new void Delete_ZBGL(int id, string p_czfs, string p_czxx)
        {
            base.Delete_ZBGL(id, p_czfs, p_czxx);
        }


        public new void Update_ZBGLZT(Struct_ZBGL struct_zbgl)
        {
            base.Update_ZBGLZT(struct_zbgl);
        }
        public new void Update_ZBGL_SJBS_ZT(Struct_ZBGL struct_zbgl)
        {
            base.Update_ZBGL_SJBS_ZT(struct_zbgl);
        }
        public new void Update_ZBGL_SJBS_LSSJ_ZT(Struct_ZBGL struct_zbgl)
        {
            base.Update_ZBGL_SJBS_LSSJ_ZT(struct_zbgl);
        }

        public new void Update_ZBGL_SJBS_FBSJ_ZT(Struct_ZBGL struct_zbgl)
        {
            base.Update_ZBGL_SJBS_FBSJ_ZT(struct_zbgl);
        }
        public new int ZBGL_SJBF(int id)
        {
            return base.ZBGL_SJBF(id);
        }
        public DataTable Select_ZBTJByID(int id)
        {
            return base.Select_ZBTJByID(id);
        }
        public new void Insert_ZBTJ(Struct_ZBGL struct_zbgl)
        {
            base.Insert_ZBTJ(struct_zbgl);
        }
        
        public new void Delete_ZBTJ(int p_xh, string p_czfs, string p_czxx)
        {
            base.Delete_ZBTJ(p_xh, p_czfs, p_czxx);
        }

    }
}
