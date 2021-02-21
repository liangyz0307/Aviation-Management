using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using Sys;

namespace CUST.MKG
{
   public class SG :OSG
    {
       public SG(UserState us) : base(us) { }
       public new DataTable Select_SG_Pro(Struct_SG sg)
        {
            return base.Select_SG_Pro(sg);
        }
        public new int Select_SG_Count(Struct_SG sg)
        {
            return base.Select_SG_Count(sg);
        }
        public new DataTable Select_SG_Detail(string bsbh)
        {
            return base.Select_SG_Detail(bsbh);
        }
        public new void Delete_SG_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            base.Delete_SG_byBH(bsbh, p_czfs, p_czxx);
        }
        public new void Insert_SG(Struct_SG sg)
        {
            base.Insert_SG(sg);
        }
      
        public new void Update_SG(Struct_SG sg)
        {
            base.Update_SG(sg);
        }

        public new string SelectBS_SGMaxBH()
        {
            return base.SelectBS_SGMaxBH();
        }
        public new DataTable  Select_FZR(Struct_SG sg)
        {
            return base.Select_FZR(sg);
        }
        public new void Update_BSSGZT(int id, string zt, string bhyy)
        {
            base.Update_BSSGZT(id, zt, bhyy);
        }
    }
}
