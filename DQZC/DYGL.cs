using Sys;
using System.Data;

namespace CUST.MKG
{
    public class DYGL : ODYGL
    {
        public DYGL(UserState us) : base(us) { }
        public new DataSet Select_YG_All(Struct_YG_Pro strcut_yg)
        {
            return base.Select_YG_All(strcut_yg);
        }
        public new int Select_YG_Count(Struct_YG_Pro strcut_yg)
        {
            return base.Select_YG_Count(strcut_yg);
        }
        public new void DY_Add(Struct_DY_Pro strcut_dy)
        {
            base.DY_Add(strcut_dy);
        }
        public new void DY_Edit(Struct_DY_Pro strcut_dy)
        {
            base.DY_Edit(strcut_dy);
        }
        public new DataSet Select_DYDetail(string bh)
        {
            return base.Select_DYDetail(bh);
        }
        public new void DYZT_Edit(string bh, string zt, string bhyy)
        {
            base.DYZT_Edit(bh, zt, bhyy);
        }
        public new void DY_Del(string bh, string p_czfs, string p_czxx)
        {
            base.DY_Del(bh, p_czfs, p_czxx);
        }
    }
}
