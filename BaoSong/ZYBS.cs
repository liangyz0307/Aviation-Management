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
    public class ZYBS : OZYBS
    {
        public ZYBS(UserState us) : base(us) { }
        public new DataTable SelectBS_ZYBS_Pro(Struct_ZYBS struct_select_zybs)
        {
            return base.SelectBS_ZYBS_Pro(struct_select_zybs);
        }
        public new int SelectBS_ZYBS_Count(Struct_ZYBS struct_select_zybs)
        {
            return base.SelectBS_ZYBS_Count(struct_select_zybs);
        }
        public new string SelectBSBH(string gwdm)
        {
            return base.SelectBSBH(gwdm);
        }
        public new DataTable SelectBS_ZYBS_Detail(string bsbh)
        {
            return base.SelectBS_ZYBS_Detail(bsbh);
        }
        public new string SelectBS_ZYBSMaxBH()
        {
            return base.SelectBS_ZYBSMaxBH();
        }
        public new void DeleteBS_ZYBS_byBH(string p_bsbh, string p_czfs, string p_czxx)
        {
            base.DeleteBS_ZYBS_byBH(p_bsbh, p_czfs, p_czxx);
        }
        public new void InsertBS_ZYBS(Struct_ZYBS struct_zybs)
        {
            base.InsertBS_ZYBS(struct_zybs);
        }
        public new void UpdateBS_ZYBS(Struct_ZYBS struct_zybs)
        {
            base.UpdateBS_ZYBS(struct_zybs);
        }
        public new void Update_ZYBSZT(int id,string zt,string bhyy) {
            base.Update_ZYBSZT(id,zt,bhyy);
            }
    }
}
