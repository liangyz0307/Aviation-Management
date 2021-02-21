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
    public class TQCZ : OTQCZ
    {
        public TQCZ(UserState us) : base(us) { }
        public new DataTable Select_TQCZ_Pro(Struct_TQCZ tqcz)
        {
            return base.Select_TQCZ_Pro(tqcz);
        }
        public new int Select_TQCZ_Count(Struct_TQCZ tqcz)
        {
            return base.Select_TQCZ_Count(tqcz);
        }
        public new DataTable Select_TQCZ_Detail(string bsbh)
        {
            return base.Select_TQCZ_Detail(bsbh);
        }
        public new void Delete_TQCZ_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            base.Delete_TQCZ_byBH(bsbh, p_czfs, p_czxx);
        }
        public new void Insert_TQCZ(Struct_TQCZ tqcz)
        {
            base.Insert_TQCZ(tqcz);
        }
        public new void Update_TQCZ(Struct_TQCZ tqcz)
        {
            base.Update_TQCZ(tqcz);
        }

        public new DataTable Select_FZR_byBMDM(string bmdm)
        {
            return base.Select_FZR_byBMDM(bmdm);
        }
        public new string SelectBS_TQCZMaxBH()
        {
            return base.SelectBS_TQCZMaxBH();
        }
        public new DataTable Select_FZR(Struct_TQCZ tqcz)
        {
            return base.Select_FZR(tqcz);
        }
        public new void Update_TQCZZT(int id, string zt, string bhyy) {
             base.Update_TQCZZT(id, zt, bhyy);
        }
    }
}
