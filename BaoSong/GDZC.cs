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
    public class GDZC : OGDZC
    {
        public GDZC(UserState us) : base(us) { }
        public new DataTable SelectBS_GDZC_Pro(Struct_Select_GDZC struct_select_gdzc)
        {
            return base.SelectBS_GDZC_Pro(struct_select_gdzc);
        }
        public new int SelectBS_GDZC_Count(Struct_Select_GDZC struct_select_gdzc)
        {
            return base.SelectBS_GDZC_Count(struct_select_gdzc);
        }
        public new DataTable SelectBS_FZR_byBMDM(string bmdm)
        {
            return base.SelectBS_FZR_byBMDM(bmdm);
        }

        public new DataTable SelectBS_GDZC_Detail(string bsbh)
        {
            return base.SelectBS_GDZC_Detail(bsbh);
        }
        public new string SelectBS_GDZCMaxBH()
        {
            return base.SelectBS_GDZCMaxBH();
        }
        public new string SelectBS_ZCBHMaxBH()
        {
            return base.SelectBS_ZCBHMaxBH();
        }
        public new void DeleteBS_GDZC_byBH(string p_bsbh, string p_czfs, string p_czxx)
        {
            base.DeleteBS_GDZC_byBH(p_bsbh, p_czfs, p_czxx);
        }
        public new void InsertBS_GDZC(Struct_GDZC struct_gdzc)
        {
            base.InsertBS_GDZC(struct_gdzc);
        }
        public new void UpdateBS_GDZC(Struct_GDZC struct_gdzc)
        {
            base.UpdateBS_GDZC(struct_gdzc);
        }





    }
}
