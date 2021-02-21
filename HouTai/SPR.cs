using CUST.Sys;
using Sys;
using System.Data;

namespace CUST.MKG
{
    public class SPR:OSPR
    {
        public SPR(UserState userstate) : base(userstate) { }

        public new int Select_SPR_Count(Struct_SPR struct_spr)
        {
            return base.Select_SPR_Count( struct_spr);
        }
        public new DataTable Select_SPR(Struct_SPR struct_spr)
        {
            return base.Select_SPR(struct_spr);
        }
        public new void Delete_SPR(Struct_SPR struct_spr)
        {
            base.Delete_SPR(struct_spr);
        }
        public new void Insert_SPR(Struct_SPR struct_spr)
        {
            base.Insert_SPR(struct_spr);
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }
        public new DataTable Select_YGbyBMGW(string p_bmdm, string p_gwdm)
        {
            return base.Select_YGbyBMGW(p_bmdm, p_gwdm);
        }
    }
}
