using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Sys;

namespace CUST.MKG
{
    public class PXJL:OPXJL
    {
        public PXJL(UserState us) : base(us) { }
        public  new DataTable Select_PXJL_Pro(Struct_PXJL struct_PXJL_Pro)
        {
            return base.Select_PXJL_Pro(struct_PXJL_Pro);
        }
        public new DataTable Select_PXJL_Pro_Ptyg(Struct_PXJL struct_PXJL_Pro)
        {
            return base.Select_PXJL_Pro_Ptyg(struct_PXJL_Pro);
        }
        public new int Select_PXJL_Count(Struct_PXJL struct_PXJL_Pro)
        {
            return base.Select_PXJL_Count(struct_PXJL_Pro);
        }
        public new int Select_PXJL_Count_Ptyg(Struct_PXJL struct_PXJL_Pro)
        {
            return base.Select_PXJL_Count_Ptyg(struct_PXJL_Pro);
        }
        public new DataTable Select_YGbyBMGW(string p_bmdm, string p_gwdm)
        {
            return base.Select_YGbyBMGW(p_bmdm, p_gwdm);
        }
        public  new void Insert_PXJL_Pro(Struct_PXJL struct_PXJL_ADD)
        {
            base.Insert_PXJL_Pro(struct_PXJL_ADD);
        }
        public new void Edit_PXJL_Pro(Struct_PXJL struct_PXJL_Edit)
        {
            base.Edit_PXJL_Pro(struct_PXJL_Edit);
        }
        public new DataTable Select_PXJL_Detail(int id)
        {
            return base.Select_PXJL_Detail(id);
        }
        public new void Delete_PXJL_Pro(int id, string czfs, string czxx)
        {
            base.Delete_PXJL_Pro(id, czfs, czxx);
        }

        public int Select_PXJL_Count(Struct_PXJL struct_pxjl, object struct_PXJL_Pro)
        {
            throw new NotImplementedException();
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
           return base.Select_YGXMbyBH(p_bh);
        }
        public new void Update_PXJLZT(Struct_PXJL struct_PXJL_Pro)
        {
            base.Update_PXJLZT(struct_PXJL_Pro);
        }
        public new void Update_PXJL_SJBS_ZT(Struct_PXJL struct_PXJL_Pro)
        {
            base.Update_PXJL_SJBS_ZT(struct_PXJL_Pro);
        }
        public new void Update_PXJL_SJBS_LSSJ_ZT(Struct_PXJL struct_PXJL_Pro)
        {
            base.Update_PXJL_SJBS_LSSJ_ZT(struct_PXJL_Pro);
        }
        public new void Update_PXJL_SJBS_FBSJ_ZT(Struct_PXJL struct_PXJL_Pro)
        {
            base.Update_PXJL_SJBS_FBSJ_ZT(struct_PXJL_Pro);
        }
        public new int PXJL_SJBF(int id)
        {
            return base.PXJL_SJBF(id);
        }
        public new DataTable Select_YGPX_BYBH(string ygbh, int userid)
        {
            return base.Select_YGPX_BYBH(ygbh, userid);
        }
        public new DataTable Select_YGPX_DC(int p_userid)
        {
            return base.Select_YGPX_DC(p_userid);
        }

    }
}
