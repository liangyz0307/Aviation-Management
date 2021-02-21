using Sys;
using System.Data;

namespace CUST.MKG
{
    public class PDT : OPDT
    {
        public PDT(UserState us) : base(us) { }

        public new DataTable Select_PDT_Pro(Struct_Select_ST pdt)
        {
            return base.Select_PDT_Pro(pdt);
        }
        public new int Select_PDT_Count(Struct_Select_ST pdt)
        {
            return base.Select_PDT_Count(pdt);
        }
        public new DataTable Select_PDT_Detail(long id)
        {
            return base.Select_PDT_Detail(id);
        }

        public new void Delete_PDT_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_PDT_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_PDT(Struct_PDT pdt)
        {
            base.Insert_PDT(pdt);
        }
        public new void Update_PDT(Struct_PDT pdt)
        {
            base.Update_PDT(pdt);
        }

        public new void Update_PDT_TJ(Struct_SH pdt)
        {
            base.Update_PDT_TJ(pdt);
        }
        
        public new void Update_PDT_SHTG(Struct_SH pdt)
        {
            base.Update_PDT_SHTG(pdt);
        }
      
        public new void Update_PDT_BH(Struct_SH pdt)
        {
            base.Update_PDT_BH(pdt);
        }
    }
}
