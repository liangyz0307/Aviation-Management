using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class ZLGL:OZLGL
    {
        public ZLGL(UserState us) : base(us) { }
        public new DataSet Select_ZL_Pro(Struct_ZL struct_zl)
        {
            return base.Select_ZL_Pro(struct_zl);
        }
        public new DataSet Select_byZLBH(string p_zlbh)
        {
            return base.Select_byZLBH(p_zlbh);
        }
        public new int Select_ZL_Count(Struct_ZL struct_zl)
        {
            return base.Select_ZL_Count(struct_zl);
        }
        public new void Struct_Delete_Pro(int id, string p_czfs, string p_czxx)
        {
            base.Struct_Delete_Pro(id, p_czfs, p_czxx);
        }
        public new void Update_ZLGLZT(int id, string zt, string bhyy)
        {
            base.Update_ZLGLZT(id, zt, bhyy);
        }
        public new string SelectZLBH(string gwdm)
        {
            return base.SelectZLBH(gwdm);
        }
        public new void Insert_ZL(Struct_ZL struct_ZL)
        {
            base.Insert_ZL(struct_ZL);
        }
        public new DataSet Select_ZLbyZLBH(string p_zlbh)
        {
            return base.Select_ZLbyZLBH(p_zlbh);
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }
    }
}
