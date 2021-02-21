using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class YGCF : OYGCF
    {
        public YGCF(UserState us) : base(us) { }

        public new DataTable Select_YGCF_Pro(Struct_YGCF ygcf)
        {
            return base.Select_YGCF_Pro(ygcf);
        }
        //普通员工只能看见本人信息

        public new void Insert_YGCF(Struct_YGCF ygcf)
        {
            base.Insert_YGCF(ygcf);
        }


        public new void Update_YGCF(Struct_YGCF ygcf)
        {
            base.Update_YGCF(ygcf);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new DataTable Select_YGCF_Detail(int id)
        {
            return base.Select_YGCF_Detail(id);
        }

        public new int Select_YGCF_Count(Struct_YGCF ygcf)
        {
            return base.Select_YGCF_Count(ygcf);
        }
        //普通员工只能看见本人信息
        public new void Delete_YGCF(int id, string p_czfs, string p_czxx)
        {
            base.Delete_YGCF(id, p_czfs, p_czxx);
        }
        public new void Update_YGCFZT(Struct_YGCF ygcf)
        {
            base.Update_YGCFZT(ygcf);
        }
        public new void Update_YGCF_SJBS_ZT(Struct_YGCF ygcf)
        {
            base.Update_YGCF_SJBS_ZT(ygcf);
        }
        public new void Update_YGCF_SJBS_LSSJ_ZT(Struct_YGCF ygcf)
        {
            base.Update_YGCF_SJBS_LSSJ_ZT(ygcf);
        }

        public new void Update_YGCF_SJBS_FBSJ_ZT(Struct_YGCF ygcf)
        {
            base.Update_YGCF_SJBS_FBSJ_ZT(ygcf);
        }
        public new int YGCF_SJBF(int id)
        {
            return base.YGCF_SJBF(id);
        }
        public new DataTable Select_YGCF_BYBH(string ygbh, int userid)
        {
            return base.Select_YGCF_BYBH(ygbh, userid);
        }

        //导出
        public new DataTable Select_YGCF_DC(int p_userid)
        {
            return base.Select_YGCF_DC(p_userid);
        }
    }
}









