using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace CUST.MKG
{
    public class ALK : OALK
    {
        public ALK(UserState us) : base(us) { }
        public new DataSet Select_AL_Pro(Struct_ALK struct_ALK)
        {

            return base.Select_AL_Pro(struct_ALK);
        }
        public new int Select_AL_Count(Struct_ALK struct_ALK)
        {
            return base.Select_AL_Count(struct_ALK);
        }
        public new void Delete_AL(int id, string p_czfs, string p_czxx)
        {
            base.Delete_AL(id, p_czfs, p_czxx);
        }
        public new void Insert_AL(Struct_ALK struct_ALK)
        {
            base.Insert_AL(struct_ALK);
        }
        public new void Update_AL(Struct_ALK struct_ALK)
        {
            base.Update_AL(struct_ALK);
        }
        public new DataSet Select_ALbyALBH(string p_albh)
        {
            return base.Select_ALbyALBH(p_albh);
        }
        public new string SelectALMaxBH(string gwdm)
        {
            return base.SelectALMaxBH(gwdm);
        }
        public new void Update_ALZT(Struct_ALK struct_ALK)
        {
            base.Update_ALZT(struct_ALK);
        }
    }
}