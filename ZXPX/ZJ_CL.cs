using Sys;
using System.Data;
namespace CUST.MKG
{
    public class ZJ_CL : OZJ_CL
    {
        public ZJ_CL(UserState us) : base(us) { }

        public new DataTable Select_ZJ_CL_Pro(Struct_Select_ZJ_CL zj_cl)
        {
            return base.Select_ZJ_CL_Pro(zj_cl);
        }
        public new int Select_ZJ_CL_Count(Struct_Select_ZJ_CL zj_cl)
        {
            return base.Select_ZJ_CL_Count(zj_cl);
        }
        public new DataTable Select_ZJ_CL_Detail(long id)
        {
            return base.Select_ZJ_CL_Detail(id);
        }

        public new void Delete_ZJ_CL_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_ZJ_CL_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_ZJ_CL(Struct_ZJ_CL zj_cl)
        {
            base.Insert_ZJ_CL(zj_cl);
        }
        public new void Update_ZJ_CL(Struct_ZJ_CL zj_cl)
        {
            base.Update_ZJ_CL(zj_cl);
        }

        public new void Update_ZJ_CL_TJ(Struct_SH zj_cl)
        {
            base.Update_ZJ_CL_TJ(zj_cl);
        }
        
        public new void Update_ZJ_CL_SHTG(Struct_SH zj_cl)
        {
            base.Update_ZJ_CL_SHTG(zj_cl);
        }
    
        public new void Update_ZJ_CL_BH(Struct_SH zj_cl)
        {
            base.Update_ZJ_CL_BH(zj_cl);
        }

    }
}
