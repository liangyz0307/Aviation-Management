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
    public class ZXXX : OZXXX
    {

        public ZXXX(UserState userstate) : base(userstate) { }
        public new DataSet Select_ZXXX_WJ(Struct_ZXXX struct_zxxx)
        {
            return base.Select_ZXXX_WJ(struct_zxxx);
        }
        public new int Select_ZXXX_WJ_Count(Struct_ZXXX struct_zxxx)
        {
            return base.Select_ZXXX_WJ_Count(struct_zxxx);
        }
        public new void Insert_ZXXX_WJ(Struct_ZXXX struct_zxxx)
        {
            base.Insert_ZXXX_WJ(struct_zxxx);
        }
        public new void Delete_ZXXX_WJid(string id)
        {
            base.Delete_ZXXX_WJ(id);
        }
        public new string SelectWDBH(string id)
        {
            return base.SelectWDBH(id);
        }
    }
}
