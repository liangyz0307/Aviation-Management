using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class ZJK:OZJK
    {
        public ZJK(UserState _usState) : base(_usState) { }
        public new DataTable Select_ZJK_Pro(Struct_ZJK_Pro struct_zjk)
        {
            return base.Select_ZJK_Pro(struct_zjk);
        }
        public new int Select_ZJK_Count(Struct_ZJK_Pro struct_zjk)
        {
            return base.Select_ZJK_Count(struct_zjk);
        }
        public new DataTable Select_ZJK_Detail(int id)
        {
            return base.Select_ZJK_Detail(id);
        }
        public new void Insert_ZJK(Struct_ZJK_Pro struct_zjk)
        {
            base.Insert_ZJK(struct_zjk);
        }
        public new void Update_ZJK(Struct_ZJK_Pro struct_zjk)
        {
            base.Update_ZJK(struct_zjk);
        }
        public new void Delete_ZJK(int id, string p_czfs, string p_czxx)
        {
            base.Delete_ZJK(id, p_czfs, p_czxx);
        }
        public new void Update_ZJKZT(Struct_ZJK_Pro zjk)
        {
            base.Update_ZJKZT(zjk);
        }
        public new void Update_ZJK_SJBS_ZT(Struct_ZJK_Pro zjk)
        {
            base.Update_ZJK_SJBS_ZT(zjk);
        }
        public new void Update_ZJK_SJBS_LSSJ_ZT(Struct_ZJK_Pro zjk)
        {
            base.Update_ZJK_SJBS_LSSJ_ZT(zjk);
        }
        public new void Update_ZJK_SJBS_FBSJ_ZT(Struct_ZJK_Pro zjk)
        {
            base.Update_ZJK_SJBS_FBSJ_ZT(zjk);
        }
        public new int ZJK_SJBF(int id)
        {
            return base.ZJK_SJBF(id);
        }



    }
}
