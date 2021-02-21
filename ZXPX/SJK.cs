using Sys;
using System.Data;
namespace CUST.MKG
{
    public class SJK : OSJK
    {
        public SJK(UserState us) : base(us) { }
        public new DataTable Select_SJK_Pro(Struct_Select_SJK sjk)
        {
            return base.Select_SJK_Pro(sjk);
        }
        public new int Select_SJK_Count(Struct_Select_SJK sjk)
        {
            return base.Select_SJK_Count(sjk);
        }
        public new DataTable Select_SJK_Detail(long id)
        {
            return base.Select_SJK_Detail(id);
        }
        public new DataTable Select_SJK_by_dj_id(string dj_id, string st_lx)
        {
            return base.Select_SJK_by_dj_id(dj_id, st_lx);
        }
        public new DataTable Select_XZT_XX(string p_st_id)
        {
            return base.Select_XZT_XX(p_st_id);
        }
        public new DataTable Select_STK_By_ZJCL(string p_zj_cl_id, string st_lx)
        {
            return base.Select_STK_By_ZJCL(p_zj_cl_id, st_lx);
        }
        public new void Delete_SJK_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_SJK_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_SJK(Struct_SJK sjk)
        {
            base.Insert_SJK(sjk);
        }
        public new void Update_SJK(Struct_SJK sjk)
        {
            base.Update_SJK(sjk);
        }
    }
}
