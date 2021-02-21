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
    public class AQYHK : OANQHK
    {
        public AQYHK(UserState us) : base(us) { }

        public new int Select_AQYHK_Count(Struct_Select_AQYHK struct_select_aqyhk)
        {
            return base.Select_AQYHK_Count(struct_select_aqyhk);
        }
        public new DataTable Select_AQYHK_Pro(Struct_Select_AQYHK struct_select_aqyhk)
        {
            return base.Select_AQYHK_Pro(struct_select_aqyhk);
        }
        public new DataTable Select_AQYHK_Detail(int p_id)
        {
            return base.Select_AQYHK_Detail(p_id);
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }
        public new DataTable Select_YGbyBMGW(string p_bmdm, string p_gwdm)
        {
            return base.Select_YGbyBMGW(p_bmdm, p_gwdm);
        }
        public new void Insert_AQYHK(Struct_AQYHK struct_aqyhk)
        {
            base.Insert_AQYHK(struct_aqyhk);
        }
        public new void Delete_AQYHK(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_AQYHK(p_id, p_czfs, p_czxx);
        }
        public new void Update_AQYHK(Struct_AQYHK struct_aqyhk)
        {
            base.Update_AQYHK(struct_aqyhk);
        }
        public new void Update_AQYHKZT(Struct_AQYHK struct_aqyhk)
        {
            base.Update_AQYHKZT(struct_aqyhk);
        }


        public new void Update_AQYHK_SJBS_ZT(Struct_AQYHK struct_aqyhk)
        {
            base.Update_AQYHK_SJBS_ZT(struct_aqyhk);
        }
        public new void Update_AQYHK_SJBS_LSSJ_ZT(Struct_AQYHK struct_aqyhk)
        {
            base.Update_AQYHK_SJBS_LSSJ_ZT(struct_aqyhk);
        }

        public new void Update_AQYHK_SJBS_FBSJ_ZT(Struct_AQYHK struct_aqyhk)
        {
            base.Update_AQYHK_SJBS_FBSJ_ZT(struct_aqyhk);
        }
        public new int AQYHK_SJBF(int id)
        {
            return base.AQYHK_SJBF(id);
        }
    }
}
