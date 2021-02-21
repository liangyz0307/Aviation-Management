using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys;

namespace CUST.MKG
{
    public class DYZX : ODYZX
    {
        public DYZX(UserState us) : base(us) { }
        public new DataTable Select_DYZX(Struct_DYZX struct_dyzx)
        {
            return base.Select_DYZX(struct_dyzx);
        }
        public new int Select_DYZX_Count(Struct_DYZX struct_dyzx)
        {
            return base.Select_DYZX_Count(struct_dyzx);
        }
        public new DataTable Select_DYZXShow(Struct_DYZX struct_dyzx)
        {
            return base.Select_DYZXShow(struct_dyzx);
        }
        public new int Select_DYZXShow_Count(Struct_DYZX struct_dyzx)
        {
            return base.Select_DYZXShow_Count(struct_dyzx);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new void Insert_DYZX(Struct_DYZX struct_dyzx)
        {
            base.Insert_DYZX(struct_dyzx);
        }
        public new DataTable Select_DYZX_Detail(long id)
        {
            return base.Select_DYZX_Detail(id);
        }
        public new void Update_DYZX(Struct_DYZX struct_dyzx)
        {
            base.Update_DYZX(struct_dyzx);
        }
        public new void Delete_DYZX_byID(Struct_DYZX struct_dyzx)
        {
            base.Delete_DYZX_byID(struct_dyzx);
        }
        public new void Update_DYZXZT(Struct_DYZX struct_dyzx)
        {
            base.Update_DYZXZT(struct_dyzx);
        }
        public new DataTable Select_DYZXbysj(Struct_DYZX struct_dyzx)
        {
            return base.Select_DYZXbysj(struct_dyzx);
        }

    }
}
