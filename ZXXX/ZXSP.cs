using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUST.MKG
{
    public class ZXSP : OZXSP
    {

        public ZXSP(UserState userstate) : base(userstate) { }
        public new DataSet Select_ZXXX_SP(Struct_ZXSP struct_zxsp)
        {
            return base.Select_ZXXX_SP(struct_zxsp);
        }
        public new int Select_ZXXX_SP_Count(Struct_ZXSP struct_zxsp)
        {
            return base.Select_ZXXX_SP_Count(struct_zxsp);
        }
        public new void Insert_ZXXX_SP(Struct_ZXSP struct_zxsp)
        {
            base.Insert_ZXXX_SP(struct_zxsp);
        }
        public new void Delete_ZXXX_SPid(string id)
        {
            base.Delete_ZXXX_SP(id);
        }
        public new string SelectWDBH(string id)
        {
            return base.SelectWDBH(id);
        }
    }
}
