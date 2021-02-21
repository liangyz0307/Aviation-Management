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
    public  class FXY:OFXY
    {
        public FXY(UserState us) : base(us) { }
        public new DataTable Select_FXY_Pro(Struct_FXY fxy)
        {
            return base.Select_FXY_Pro(fxy);
        }
        public new DataTable Select_FZR(Struct_FXY fxy)
        {
            return base.Select_FZR(fxy);
        }
        public new int Select_FXY_Count(Struct_FXY fxy)
        {
            return base.Select_FXY_Count(fxy);
        }
        public new DataTable Select_FXY_Detail(string bsbh)
        {
            return base.Select_FXY_Detail(bsbh);
        }
        public new void Delete_FXY_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            base.Delete_FXY_byBH(bsbh, p_czfs, p_czxx);
        }
        public new void Insert_FXY(Struct_FXY fxy)
        {
            base.Insert_FXY(fxy);
        }
        public new void Update_FXY(Struct_FXY fxy)
        {
            base.Update_FXY(fxy);
        }

        public new DataTable Select_FZR_byBMDM(string bmdm)
        {
            return base.Select_FZR_byBMDM(bmdm);
        }
        public new string SelectBS_FXYMaxBH()
        {
            return base.SelectBS_FXYMaxBH();
        }
        public new void Update_FXYZT(int id, string zt, string bhyy)
        {
            base.Update_FXYZT(id, zt,bhyy);
            }
    }
}
