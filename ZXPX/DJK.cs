using Sys;
using System.Data;
namespace CUST.MKG
{
    public class DJK : ODJK
    {
        public DJK(UserState us) : base(us) { }
        public new DataTable Select_DJK_Pro(Struct_Select_DJK djk)
        {
            return base.Select_DJK_Pro(djk);
        }
        public new int Select_DJK_Count(Struct_Select_DJK djk)
        {
            return base.Select_DJK_Count(djk);
        }
        public new DataTable Select_DJK_Detail(long id)
        {
            return base.Select_DJK_Detail(id);
        }
        public new DataTable Select_DJK_By_KSH_CL_ZT(string zj_cl_id, string ksh, string zt)
        {
            return base.Select_DJK_By_KSH_CL_ZT(zj_cl_id, ksh, zt);
        }
        public new DataTable Select_DJK_TJ(Struct_DJK_TJ tj)
        {
            return base.Select_DJK_TJ(tj);
        }
        public new void Delete_DJK_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_DJK_byID(id, p_czfs, p_czxx);
        }
        public new string Insert_DJK(string zj_cl_id, string p_czfs, string p_czxx)
        {
            return base.Insert_DJK(zj_cl_id, p_czfs, p_czxx);
        }
		
		
        public new void Update_DJK(Struct_DJK djk)
        {
            base.Update_DJK(djk);
        }

		
		
        public new void Update_DJK_KSSJ(string p_id, string p_czfs, string p_czxx)
        {
            base.Update_DJK_KSSJ(p_id, p_czfs, p_czxx);
        }

        public new void Update_DJK_HS(long p_id, double p_hs, string p_czfs, string p_czxx)
        {
            base.Update_DJK_HS(p_id, p_hs, p_czfs, p_czxx);
        }
    }
}