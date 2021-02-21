using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys;
using CUST.WKG;
using System.Data;

namespace CUST.MKG
{
    public class AQWTK: OAQWTK
    {
        public AQWTK(UserState us) : base(us) { }

        public new DataTable Select_AQWTK(Struct_AQWTK struct_AQWTK)
        {
            return base.Select_AQWTK(struct_AQWTK);
        }
        public new int Select_AQWTK_Count(Struct_AQWTK struct_AQWTK)
        {
            return base.Select_AQWTK_Count(struct_AQWTK);
        }
        public new DataTable Select_AQWTK_Detail(int p_id)
        {
            return base.Select_AQWTK_Detail(p_id);
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }
        public new DataTable Select_YGbyBMGW(string p_bmdm, string p_gwdm)
        {
            return base.Select_YGbyBMGW(p_bmdm, p_gwdm);
        }
        public new void Insert_AQWTK(Struct_AQWTK struct_AQWTK)
        {
            base.Insert_AQWTK(struct_AQWTK);
        }
        public new void Update_AQWTK(Struct_AQWTK struct_AQWTK)
        {
            base.Update_AQWTK(struct_AQWTK);
        }
        public new void Delete_AQWTK(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_AQWTK(p_id, p_czfs, p_czxx);
        }
        public new void Update_AQWTKZT(Struct_AQWTK struct_AQWTK)
        {
            base.Update_AQWTKZT(struct_AQWTK);
        }
        public new void Update_AQWTK_SJBS_ZT(Struct_AQWTK struct_AQWTK)
        {
            base.Update_AQWTK_SJBS_ZT(struct_AQWTK);
        }
        public new void Update_AQWTK_SJBS_LSSJ_ZT(Struct_AQWTK struct_AQWTK)
        {
            base.Update_AQWTK_SJBS_LSSJ_ZT(struct_AQWTK);
        }
        public new void Update_AQWTK_SJBS_FBSJ_ZT(Struct_AQWTK struct_AQWTK)
        {
            base.Update_AQWTK_SJBS_FBSJ_ZT(struct_AQWTK);
        }
        public new int AQWTK_SJBF(int id)
        {
            return base.AQWTK_SJBF(id);
        }
    }
}
