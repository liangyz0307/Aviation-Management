using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using Sys;


namespace CUST.MKG
{
   public class HWGLB:OHWGLB
    {
        public HWGLB(UserState us) : base(us) { }
        public new DataTable Select_HWGLB_Pro(Struct_HWGLB struct_hwglb)
        {
            return base.Select_HWGLB_Pro(struct_hwglb);
        }
        public new int Select_HWGLB_Count(Struct_HWGLB struct_hwglb)
        {
            return base.Select_HWGLB_Count(struct_hwglb);
        }
        public new  void Insert__HWGLB(Struct_HWGLB struct_hwglb)
        {
            base.Insert__HWGLB(struct_hwglb);
        }
        public new void Update_HWGLB(Struct_HWGLB struct_hwglb)
        {
            base.Update_HWGLB(struct_hwglb);
        }
        public new  void Delete_HWGLB(int id, string p_czfs, string p_czxx)
        {
            base.Delete_HWGLB(id, p_czfs, p_czxx);

        }
        public new  DataTable Select_HWGLB_Detail(int id)
        {
            return base.Select_HWGLB_Detail(id);
        }
        public new  DataTable Select_YGXMbyBH(string bh)
        {
            return base.Select_YGXMbyBH(bh);
        }
        public new DataTable Select_YGByBMDQ(string dqdm, string bmdm)
        {
            return base.Select_YGByBMDQ(dqdm, bmdm);
        }
        public new DataTable Select_YGByBMDQ_Dhbzb(string dqdm, string bmdm)
        {
            return base.Select_YGByBMDQ_Dhbzb(dqdm, bmdm);
        }
        public new DataTable Select_YGXMbyBH_Dhbzb(string bh)
        {
            return base.Select_YGXMbyBH_Dhbzb(bh );
        
        }
    }

}
