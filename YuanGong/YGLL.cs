using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;
namespace CUST.MKG
{
    public class YGLL : OYGLL
    {
        public YGLL(UserState us) : base(us) { }

        public new DataTable Select_YGLL_Pro(Struct_Select_YGLL ygzz)
        {
            return base.Select_YGLL_Pro(ygzz);
        }
        public new DataTable Select_YGLL_Pro_Ptyg(Struct_Select_YGLL ygzz)
        {
            return base.Select_YGLL_Pro_Ptyg(ygzz);
        }
        public new int Select_YGLLCount(Struct_Select_YGLL ygzz)
        {
            return base.Select_YGLLCount(ygzz);
        }
        public new int Select_YGLLCount_Ptyg(Struct_Select_YGLL ygzz)
        {
            return base.Select_YGLLCount_Ptyg(ygzz);
        }
        public new DataTable Select_YGLL_Detail(int id)
        {
            return base.Select_YGLL_Detail(id);
        }
        public new DataTable Select_YGLLGL_Detail(long id)
        {
            return base.Select_YGLLGL_Detail(id);
        }
        public new void Delete_YGLL_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_YGLL_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_YGLL(Struct_YGLL ygzz)
        {
            base.Insert_YGLL(ygzz);
        }
        public new void Update_YGLL(Struct_YGLL ygzz)
        {
            base.Update_YGLL(ygzz);
        }

        public new DataTable Select_YGLL_BYBH(string p_ygbh, int p_userid)
        {
            return base.Select_YGLL_BYBH(p_ygbh, p_userid);
        }
        public new void Delete_YGLL_byBH(string p_bh, string p_czfs, string p_czxx)
        {
            base.Delete_YGLL_byBH(p_bh, p_czfs, p_czxx);
        }
        public new void Update_ygll_ZT(long id, string zt, string bhyy)
        {
            base.Update_ygll_ZT(id, zt, bhyy);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new void Update_YGLL_SJBS_ZT(Struct_YGLL ygll)
        {
            base.Update_YGLL_SJBS_ZT(ygll);
        }
        public new void Update_YGLL_SJBS_LSSJ_ZT(Struct_YGLL ygll)
        {
            base.Update_YGLL_SJBS_LSSJ_ZT(ygll);
        }

        public new void Update_YGLL_SJBS_FBSJ_ZT(Struct_YGLL ygll)
        {
            base.Update_YGLL_SJBS_FBSJ_ZT(ygll);
        }
        public new int YGLL_SJBF(int id)
        {
            return base.YGLL_SJBF(id);
        }
    }

}
