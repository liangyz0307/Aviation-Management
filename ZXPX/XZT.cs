using Sys;
using System.Data;
namespace CUST.MKG
{
    public class XZT : OXZT
    {
        public XZT(UserState us) : base(us) { }
        public new DataTable Select_XZT_Pro(Struct_Select_ST xzt)
        {
            return base.Select_XZT_Pro(xzt);
        }
        public new int Select_XZT_Count(Struct_Select_ST xzt)
        {
            return base.Select_XZT_Count(xzt);
        }
        public new DataTable Select_XZT_Detail(long id)
        {
            return base.Select_XZT_Detail(id);
        }
        public new void Delete_XZT_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_XZT_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_XZT(Struct_XZT xzt)
        {
            base.Insert_XZT(xzt);
        }
        public new void Update_XZT(Struct_XZT xzt)
        {
            base.Update_XZT(xzt);
        }

        public new void Update_XZT_TJ(Struct_SH xzt)
        {
            base.Update_XZT_TJ(xzt);
        }

        public new void Update_XZT_SHTG(Struct_SH xzt)
        {
            base.Update_XZT_SHTG(xzt);
        }
       
        public new void Update_XZT_BH(Struct_SH xzt)
        {
            base.Update_XZT_BH(xzt);
        }
        //----------------
        public new DataTable Select_XZT_XX(long stid)
        {
            return base.Select_XZT_XX(stid);
        }
        public new void Delete_XZT_XX_bySTID(long stid, string p_czfs, string p_czxx)
        {
            base.Delete_XZT_XX_bySTID(stid, p_czfs, p_czxx);
        }
        public new void Delete_XZT_XX_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_XZT_XX_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_XZT_XX(Struct_XZT_XX xzt_xx)
        {
            base.Insert_XZT_XX(xzt_xx);
        }
        public new void Update_XZT_XX(Struct_XZT_XX xzt_xx)
        {
            base.Update_XZT_XX(xzt_xx);
        }
    }
}
