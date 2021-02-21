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
    public class ZDGZ : OZDGZ
    {
        public ZDGZ(UserState us) : base(us) { }
        public new DataTable SelectBS_ZDGZ_Pro(Struct_Select_ZDGZ struct_select_zdgz)
        {
            return base.SelectBS_ZDGZ_Pro(struct_select_zdgz);
        }
        public new int SelectBS_ZDGZ_Count(Struct_Select_ZDGZ struct_select_zdgz)
        {
            return base.SelectBS_ZDGZ_Count(struct_select_zdgz);
        }
        public new DataTable SelectBS_FZR_byBMDM(string bmdm)
        {
            return base.SelectBS_FZR_byBMDM(bmdm);
        }
        public new DataTable SelectBS_ZDGZ_Detail(int id)
        {
            return base.SelectBS_ZDGZ_Detail(id);
        }
        public new string SelectBS_ZDGZMaxBH()
        {
            return base.SelectBS_ZDGZMaxBH();
        }
        public new void DeleteBS_ZDGZ_byBH(int id, string p_czfs, string p_czxx)
        {
            base.DeleteBS_ZDGZ_byBH(id, p_czfs, p_czxx);
        }
        public new void InsertBS_ZDGZ(Struct_ZDGZ struct_zdgz)
        {
            base.InsertBS_ZDGZ(struct_zdgz);
        }
        public new void UpdateBS_ZDGZ(Struct_ZDGZ struct_zdgz)
        {
            base.UpdateBS_ZDGZ(struct_zdgz);
        }

        public new void Update_ZDGZZT(Struct_ZDGZ struct_zdgz)
        {
            base.Update_ZDGZZT(struct_zdgz);
        }
        public new void Update_ZDGZ_SJBS_ZT(Struct_ZDGZ struct_zdgz)
        {
            base.Update_ZDGZ_SJBS_ZT(struct_zdgz);
        }
        public new void Update_ZDGZ_SJBS_LSSJ_ZT(Struct_ZDGZ struct_zdgz)
        {
            base.Update_ZDGZ_SJBS_LSSJ_ZT(struct_zdgz);
        }

        public new void Update_ZDGZ_SJBS_FBSJ_ZT(Struct_ZDGZ struct_zdgz)
        {
            base.Update_ZDGZ_SJBS_FBSJ_ZT(struct_zdgz);
        }
        public new int ZDGZ_SJBF(int id)
        {
            return base.ZDGZ_SJBF(id);
        }



    }
}
