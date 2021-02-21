using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class YGZC : OYGZC
    {
        public YGZC(UserState _usState) : base(_usState) { }
        public new DataTable Select_YGZC_Pro(Struct_YGZC struct_YGZC)
        {
            return base.Select_YGZC_Pro(struct_YGZC);
        }
        public new DataTable Select_YGZC_Pro_Ptyg(Struct_YGZC struct_YGZC)
        {
            return base.Select_YGZC_Pro_Ptyg(struct_YGZC);
        }
        public new int Select_YGZC_Count(Struct_YGZC struct_YGZC)
        {
            return base.Select_YGZC_Count(struct_YGZC);
        }
        public new int Select_YGZC_Count_Ptyg(Struct_YGZC struct_YGZC)
        {
            return base.Select_YGZC_Count_Ptyg(struct_YGZC);
        }
        public new DataTable Select_YGZC_Detail(int id)
        {
            return base.Select_YGZC_Detail(id);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new void Insert_YGZC(Struct_YGZC struct_YGZC)
        {
            base.Insert_YGZC(struct_YGZC);
        }
        public new void Update_YGZC(Struct_YGZC struct_YGZC)
        {
            base.Update_YGZC(struct_YGZC);
        }
        public new void Update_YGZCZT(Struct_YGZC struct_YGZC)
        {
            base.Update_YGZCZT(struct_YGZC);
        }
        public new void Update_YGZC_SJBS_ZT(Struct_YGZC struct_YGZC)
        {
            base.Update_YGZC_SJBS_ZT(struct_YGZC);
        }
        public new void Update_YGZC_SJBS_LSSJ_ZT(Struct_YGZC struct_YGZC)
        {
            base.Update_YGZC_SJBS_LSSJ_ZT(struct_YGZC);
        }
        public new void Update_YGZC_SJBS_FBSJ_ZT(Struct_YGZC struct_YGZC)
        {
            base.Update_YGZC_SJBS_FBSJ_ZT(struct_YGZC);
        }
        public new void Delete_YGZC(int id, string p_czfs, string p_czxx)
        {
            base.Delete_YGZC(id, p_czfs, p_czxx);
        }
        public new int YGZC_SJBF(int id)
        {
            return base.YGZC_SJBF(id);
        }
        public new DataTable Select_YGZC_BYBH(string ygbh, int userid)
        {
            return base.Select_YGZC_BYBH(ygbh, userid);
        }
        public new DataTable Select_YGZC_DC(int p_userid)
        {
            return base.Select_YGZC_DC(p_userid);
        }
    }
}
