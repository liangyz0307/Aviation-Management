using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class BMGW:OBMGW
    {
        public BMGW(UserState _usState) : base(_usState) { }
        public new DataSet Select_BM_Pro(Struct_BM  struct_BM )
        {
            return base.Select_BM_Pro(struct_BM );
        }
        public new DataSet Select_BMbyBMDM(string p_bmdm)
        {
            return base.Select_BMbyBMDM(p_bmdm);
        }
        public new int Select_BM_Count(Struct_BM  struct_BM )
        {
            return base.Select_BM_Count(struct_BM );
        }
        public new void Insert_BM (Struct_BM  struct_BM )
        {
            base.Insert_BM (struct_BM );
        }
        public new void Update_BM (Struct_BM  struct_BM )
        {
            base.Update_BM (struct_BM );
        }
        public new void Delete_BM(string p_bmdm, string p_czfs, string p_czxx)
        {
            base.Delete_BM(p_bmdm, p_czfs, p_czxx);
        }
        public new DataSet Select_GW_Pro(Struct_GW struct_GW)
        {
            return base.Select_GW_Pro(struct_GW);
        }
        public new DataSet Select_GWbyGWDM(string p_gwdm)
        {
            return base.Select_GWbyGWDM(p_gwdm);
        }
        public new int Select_GW_Count(Struct_GW struct_GW)
        {
            return base.Select_GW_Count(struct_GW);
        }
        public new void Insert_GW(Struct_GW struct_GW)
        {
            base.Insert_GW(struct_GW);
        }
        public new void Update_GW(Struct_GW struct_GW)
        {
            base.Update_GW(struct_GW);
        }
        public new void Delete_GW(string p_gwdm, string p_czfs, string p_czxx)
        {
            base.Delete_GW(p_gwdm, p_czfs, p_czxx);
        }

        public new DataSet Select_YGALL(string p_gwdm)
        {
            return base.Select_YGALL(p_gwdm);
        }

    }
}
