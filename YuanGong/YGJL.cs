using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class YGJL : OYGJL
    {
        public YGJL(UserState _usState) : base(_usState) { }

        public new DataTable Select_YGJL_Pro(Struct_YGJL_Pro struct_YGJL)
        {
            return base.Select_YGJL_Pro(struct_YGJL);
        }
        //普通员工只能看见本人信息
        public new DataTable Select_YGJL_Pro_Ptyg(Struct_YGJL_Pro struct_YGJL)
        {
            return base.Select_YGJL_Pro_Ptyg(struct_YGJL);
        }
        public new void Insert_YGJL(Struct_YGJL_Pro struct_YGJL)
        {
            base.Insert_YGJL(struct_YGJL);
        }


        public new void Update_YGJL(Struct_YGJL_Pro struct_YGJL)
        {
            base.Update_YGJL(struct_YGJL);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new DataTable Select_YGJL_Detail(int id)
        {
            return base.Select_YGJL_Detail(id);
        }

        public new int Select_YGJL_Count(Struct_YGJL_Pro struct_YGJL)
        {
            return base.Select_YGJL_Count(struct_YGJL);
        }
        //普通员工只能看见本人信息
        public new int Select_YGJL_Count_Ptyg(Struct_YGJL_Pro struct_YGJL)
        {
            return base.Select_YGJL_Count_Ptyg(struct_YGJL);
        }
        public new void Delete_YGJL(int id, string p_czfs, string p_czxx)
        {
            base.Delete_YGJL(id, p_czfs, p_czxx);
        }
        public new void Update_YGJLZT(Struct_YGJL_Pro ygjl)
        {
            base.Update_YGJLZT(ygjl);
        }
        public new void Update_YGJL_SJBS_ZT(Struct_YGJL_Pro ygjl)
        {
            base.Update_YGJL_SJBS_ZT(ygjl);
        }
        public new void Update_YGJL_SJBS_LSSJ_ZT(Struct_YGJL_Pro ygjl)
        {
            base.Update_YGJL_SJBS_LSSJ_ZT(ygjl);
        }
        
        public new void Update_YGJL_SJBS_FBSJ_ZT(Struct_YGJL_Pro ygjl)
        {
            base.Update_YGJL_SJBS_FBSJ_ZT(ygjl);
        }
        public new int YGJL_SJBF(int id)
        {
            return base.YGJL_SJBF(id);
        }
        public new DataTable Select_YGJL_BYBH(string ygbh, int userid)
        {
            return base.Select_YGJL_BYBH(ygbh, userid);
        }
        public new DataTable Select_YGJL_Pro_DSPTS(Struct_YGJL_Pro struct_YGJL)
        {
            return base.Select_YGJL_Pro_DSPTS(struct_YGJL);
        }
        public new int Select_YGJL_Count_DSPTS(Struct_YGJL_Pro struct_YGJL)
        {
            return base.Select_YGJL_Count_DSPTS(struct_YGJL);
        }
        public new DataTable Select_YGJL_DC(int p_userid)
        {
            return base.Select_YGJL_DC(p_userid);
        }

    }
}
