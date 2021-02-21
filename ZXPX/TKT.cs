using Sys;
using System.Data;

namespace CUST.MKG
{
    public class TKT : OTKT
    {
        public TKT(UserState us) : base(us) { }

        public new DataTable Select_TKT_Pro(Struct_Select_ST tkt)
        {
            return base.Select_TKT_Pro(tkt);
        }
        public new int Select_TKT_Count(Struct_Select_ST tkt)
        {
            return base.Select_TKT_Count(tkt);
        }
        public new DataTable Select_TKT_Detail(long id)
        {
            return base.Select_TKT_Detail(id);
        }

        public new void Delete_TKT_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_TKT_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_TKT(Struct_TKT tkt)
        {
            base.Insert_TKT(tkt);
        }
        public new void Update_TKT(Struct_TKT tkt)
        {
            base.Update_TKT(tkt);
        }
        public new void Update_TKT_TJ(Struct_SH tkt)
        {
            base.Update_TKT_TJ(tkt);
        }
        
        public new void Update_TKT_SHTG(Struct_SH tkt)
        {
            base.Update_TKT_SHTG(tkt);
        }
        
        public new void Update_TKT_BH(Struct_SH tkt)
        {
            base.Update_TKT_BH(tkt);
        }
    }
}
