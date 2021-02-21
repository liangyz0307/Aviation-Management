using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys;
using CUST.WKG;
using System.Data;
namespace CUST.MKG
{
    public class SBBLK : OSBBLK
    {
        public SBBLK(UserState us) : base(us) { }
        public new void Insert_SBBLK(Struct_SBBLK struct_sbblk)
        {
            base.Insert_SBBLK(struct_sbblk);
        }
        public new void Delete_SBBLK(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_SBBLK(p_id, p_czfs, p_czxx);
        }
        public new void Update_SBBLK(Struct_SBBLK struct_sbblk)
        {
            base.Update_SBBLK(struct_sbblk);
        }
        public new DataTable Select_SBBLK_Pro(Struct_Select_SBBLK struct_select_sbblk)
        {
            return base.Select_SBBLK_Pro(struct_select_sbblk);
        }
        public new DataTable Select_SBBLK_Detail(int p_id)
        {
            return base.Select_SBBLK_Detail(p_id);
        }
        public new int Select_SBBLK_Count(Struct_Select_SBBLK struct_select_sbblk)
        {
            return base.Select_SBBLK_Count(struct_select_sbblk);
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }
        public new DataTable Select_YGbyBMGW(string p_bmdm,string p_gwdm)
        {
            return base.Select_YGbyBMGW(p_bmdm, p_gwdm);
        }

        public new void Update_SBBLKZT(Struct_Select_SBBLK struct_select_sbblk)
        {
            base.Update_SBBLKZT(struct_select_sbblk);
        }
        public new void Update_SBBLK_SJBS_ZT(Struct_Select_SBBLK struct_select_sbblk)
        {
            base.Update_SBBLK_SJBS_ZT(struct_select_sbblk);
        }
        public new void Update_SBBLK_SJBS_LSSJ_ZT(Struct_Select_SBBLK struct_select_sbblk)
        {
            base.Update_SBBLK_SJBS_LSSJ_ZT(struct_select_sbblk);
        }

        public new void Update_SBBLK_SJBS_FBSJ_ZT(Struct_Select_SBBLK struct_select_sbblk)
        {
            base.Update_SBBLK_SJBS_FBSJ_ZT(struct_select_sbblk);
        }
        public new int SBBLK_SJBF(int id)
        {
            return base.SBBLK_SJBF(id);
        }
    }
}
