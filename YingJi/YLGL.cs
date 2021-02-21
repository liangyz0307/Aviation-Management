using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.MKG
{
    public class YLGL : OYLGL
    {
        public new DataTable Select_Ylgl_Yam_Mc()
        { return base.Select_Ylgl_Yam_Mc(); }
        public new DataTable Select_Ylgl_Cyry_Mc()
        { return base.Select_Ylgl_Cyry_Mc(); }

        public YLGL(UserState us) : base(us) { }

        public new DataTable Select_Ylgl_Detail(int ylbh)
        { return base.Select_Ylgl_Detail(ylbh); }

        public new DataTable Select_Ylgl(Struct_YLGL struct_ylgl)
        { return base.Select_Ylgl(struct_ylgl); }

        public new int Select_YLGL_Count(Struct_YLGL struct_ylgl)
        { return base.Select_YLGL_Count(struct_ylgl); }

        public new void Delete_Ylgl(int p_bh, string p_czfs, string p_czxx)
        { base.Delete_Ylgl(p_bh,p_czfs,p_czxx); }

        public new void Update_Yj_Ylgl(Struct_YLGL struct_ylgl)
        { base.Update_Yj_Ylgl(struct_ylgl); }
        public new void Insert_Yj_Ylgl(Struct_YLGL struct_ylgl)
        { base.Insert_Yj_Ylgl(struct_ylgl); }

        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        { return base.Select_YGbyBMGW(bmdm, gwdm); }

        public new DataTable Select_YGXMbyBH(string p_bh)
        { return base.Select_YGXMbyBH(p_bh); }

        public new string YAMByKey(string p_sjc)
        { return base.YAMByKey(p_sjc); }

        public new void Update_YLGLZT(Struct_YLGL struct_ylgl)
        {
            base.Update_YLGLZT(struct_ylgl);
        }
        public new void Update_YLGL_SJBS_ZT(Struct_YLGL struct_ylgl)
        {
            base.Update_YLGL_SJBS_ZT(struct_ylgl);
        }
        public new void Update_YLGL_SJBS_LSSJ_ZT(Struct_YLGL struct_ylgl)
        {
            base.Update_YLGL_SJBS_LSSJ_ZT(struct_ylgl);
        }

        public new void Update_YAGL_SJBS_FBSJ_ZT(Struct_YLGL struct_ylgl)
        {
            base.Update_YAGL_SJBS_FBSJ_ZT(struct_ylgl);
        }
        public new int YLGL_SJBF(int bh)
        {
            return base.YLGL_SJBF(bh);
        }
    }
}
