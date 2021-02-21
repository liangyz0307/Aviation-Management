using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
   public  class JCD:OJCD
    {
        public JCD(UserState userstate) : base(userstate) { }

        public new void Insert_JCD(Struct_JCD struct_jcd)
        {
            base.Insert_JCD(struct_jcd);
        }
        public new void Update_Sjbs(string tbdw,string czfs,string czxx)
        {
            base.Update_sjbs(tbdw,czfs,czxx);
        } 

    }
   
}
