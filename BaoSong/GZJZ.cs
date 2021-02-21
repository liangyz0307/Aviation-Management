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
    public class GZJZ : OGZJZ
    {
        public GZJZ(UserState us) : base(us) { }
        public new DataTable SelectBS_GZJZ_Pro(Struct_Select_GZJZ struct_select_gzjz)
        {
            return base.SelectBS_GZJZ_Pro(struct_select_gzjz);
        }
        public new int SelectBS_GZJZ_Count(Struct_Select_GZJZ struct_select_gzjz)
        {
            return base.SelectBS_GZJZ_Count(struct_select_gzjz);
        }
        public new DataTable SelectBS_FZR_byBH(string gzfzr)
        {
            return base.SelectBS_FZR_byBH(gzfzr);
        }
        public new DataTable SelectBS_FZR_byBMGW(string bmdm,string gwdm)
        {
            return base.SelectBS_FZR_byBMGW(bmdm,gwdm);
        }
        public new DataTable SelectBS_FZR_byBMDM(string bmdm)
        {
            return base.SelectBS_FZR_byBMDM(bmdm);
        }
        public new  DataTable SelectBS_GZJZ_Detail(string bsbh)
        {
            return base.SelectBS_GZJZ_Detail(bsbh);
        }
        public new string SelectBS_GZJZMaxBH()
        {
            return base.SelectBS_GZJZMaxBH();
        }
        public new  void DeleteBS_GZJZ_byBH(string p_bzsjc, string p_zt, string p_sjbs, string p_id, string p_czfs, string p_czxx)
       {
            base.DeleteBS_GZJZ_byBH(p_bzsjc,p_zt,p_sjbs,p_id, p_czfs, p_czxx);
        }
        public new void InsertBS_GZJZ(Struct_GZJZ struct_gzjz)
        {
            base.InsertBS_GZJZ(struct_gzjz);
        }
        public new  void UpdateBS_GZJZ(Struct_GZJZ struct_gzjz)
        {
            base.UpdateBS_GZJZ(struct_gzjz);
        }

        public new void Insert_gzjz_bz(Struct_GZJZ struct_gzjz) {
            base.Insert_gzjz_bz(struct_gzjz);
        }
        public new void Update_gzjz_bz(Struct_GZJZ struct_gzjz)
        {
            base.Update_gzjz_bz(struct_gzjz);
        }
        public new void Delete_gzjz_bz(string bzsjc, string zt, string sjbs, string czfs, string czxx)
        {
            base.Delete_gzjz_bz(bzsjc, zt, sjbs, czfs,czxx);
        }
        public new DataTable Select_gzjz_bz(string bsbh,string zt,string sjbs)
        {
            return base.Select_gzjz_bz(bsbh,zt,sjbs);
        }
        public new void Delete_gzjzbz_id(string id)
        {
            base.Delete_gzjzbz_id(id);
        }
        public new void Update_GZJZZT(Struct_GZJZ struct_gzjz)
        {
            base.Update_GZJZZT(struct_gzjz);
        }
        public new void Update_GZJZ_SJBS_ZT(Struct_GZJZ struct_gzjz)
        {
            base.Update_GZJZ_SJBS_ZT(struct_gzjz);
        }
        public new void Update_GZJZ_SJBS_LSSJ_ZT(Struct_GZJZ struct_gzjz)
        {
            base.Update_GZJZ_SJBS_LSSJ_ZT(struct_gzjz);
        }
        public new void Update_GZJZ_SJBS_FBSJ_ZT(Struct_GZJZ struct_gzjz)
        {
            base.Update_GZJZ_SJBS_FBSJ_ZT(struct_gzjz);
        }
        public new int GZJZ_SJBF(int id)
        {
            return base.GZJZ_SJBF(id);
        }
    }
}
