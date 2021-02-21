using System;
using System.Collections.Generic;
using System.Text;
using CUST.Sys;
using System.Data;
using Sys;

namespace CUST.MKG
{
    public class YH : OYH
    {
        public YH(UserState us) : base(us) { }
        public new DataSet YH_Select_SY()
        {
            return base.YH_Select_SY();
        }

        public new DataTable Select_YH_Pro(Struct_Select_YH yh)
        {
            return base.Select_YH_Pro(yh);
        }
        public new int Select_YH_Count(Struct_Select_YH yh)
        {
            return base.Select_YH_Count(yh);
        }
        public new DataTable Select_YH_Detail(long id)
        {
            return base.Select_YH_Detail(id);
        }
        public new void Delete_YH_byID(long id, string p_czfs, string p_czxx)
        {
            base.Delete_YH_byID(id, p_czfs, p_czxx);
        }

        public new void Insert_Login(string p_czfs, string p_czxx)
        {
            base.Insert_Login( p_czfs,  p_czxx);
        }

        public new void Insert_YH(Struct_YH yh)
        {
            base.Insert_YH(yh);
        }
        public new void Update_YH(Struct_YH yh)
        {
            base.Update_YH(yh);
        }
        public new void Update_Pager(Struct_YH yh)
        {
            base.Update_Pager(yh);
        }
        


    }
}