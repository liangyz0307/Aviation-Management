using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.MKG
{
    public class WXY : OWXY
    {
        public WXY(UserState us) :base(us)
        { }
        public new int Select_WXY_Count(Struct_WXY struct_wxy)
        { return base.Select_WXY_Count(struct_wxy); }

        public new DataTable Select_WXY_Pro(Struct_WXY struct_wxy)
        { return base.Select_WXY_Pro(struct_wxy); }

        public new DataTable Select_WXY_Detail(int id)
        { return base.Select_WXY_Detail(id); }

        public new void Update_WXY(Struct_WXY struct_wxy)
        { base.Update_WXY(struct_wxy); }

        public new void Delete_WXY(int p_id, string p_czfs, string p_czxx)
        { base.Delete_WXY(p_id, p_czfs,  p_czxx); }

        public new void Insert_WXY(Struct_WXY struct_wxy)
        { base.Insert_WXY(struct_wxy); }

        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        { return base.Select_YGbyBMGW(bmdm,gwdm); }

        public new DataTable Select_YGXMbyBH(string p_bh)
        { return base.Select_YGXMbyBH(p_bh); }

        public new void Update_WXYZT(Struct_WXY struct_PXJL_Pro)
        {
            base.Update_WXYZT(struct_PXJL_Pro);
        }
        public new void Update_WXY_SJBS_ZT(Struct_WXY struct_wxy)
        {
            base.Update_WXY_SJBS_ZT(struct_wxy);
        }
        public new void Update_WXY_SJBS_LSSJ_ZT(Struct_WXY struct_wxy)
        {
            base.Update_WXY_SJBS_LSSJ_ZT(struct_wxy);
        }
        public new void Update_WXY_SJBS_FBSJ_ZT(Struct_WXY struct_wxy)
        {
            base.Update_WXY_SJBS_FBSJ_ZT(struct_wxy);
        }
        public new int WXY_SJBF(int id)
        {
            return base.WXY_SJBF(id);
        }
    }
}
