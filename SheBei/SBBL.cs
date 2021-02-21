using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class SBBL : OSBBL
    {
        public SBBL(UserState us) : base(us) { }
        public new DataTable Select_SBBL_Pro(Struct_SBBL struct_SBBL)
        {
            return base.Select_SBBL_Pro(struct_SBBL);
        }
        public new int Select_SBBL_Count(Struct_SBBL struct_SBBL)
        {
            return base.Select_SBBL_Count(struct_SBBL);
        }
        public  new int Insert_SBBL(Struct_SBBL struct_SBBL) {
            return base.Insert_SBBL(struct_SBBL);
        }
        public new void Update_SBBL(Struct_SBBL struct_SBBL) {
            base.Update_SBBL(struct_SBBL);
        }
        public  new void Delete_SBBL(int p_id, string p_czfs, string p_czxx) {
            base.Delete_SBBL(p_id, p_czfs, p_czxx);
        }
        public new DataTable Select_SBBLbyID(int p_id) {
            return base.Select_SBBLbyID(p_id);
        }
    }
}
