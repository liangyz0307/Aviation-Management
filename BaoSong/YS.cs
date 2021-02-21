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
    public class YS : OYS
    {
        public YS(UserState us) : base(us) { }
        public new string SelectBS_YSMaxBH()
        {
            return base.SelectBS_YSMaxBH();
        }
        public new void Delete_YS_byBH(string bsbh, string p_czfs, string p_czxx)
        {
            base.Delete_YS_byBH(bsbh, p_czfs, p_czxx);
        }
        public new DataTable Select_YS_Pro(Struct_Select_YS ys)
        {
            return base.Select_YS_Pro(ys);
        }
        public new int Select_YS_Count(Struct_Select_YS ys)
        {
            return base.Select_YS_Count(ys);
        }
        public new DataTable Select_YS_Detail(string bsbh)
        {
            return base.Select_YS_Detail(bsbh);
        }
        public new void Insert_YS(Struct_YS ys)
        {
            base.Insert_YS(ys);
        }
        public new void Update_YS(Struct_YS ys)
        {
            base.Update_YS(ys);
        }
    }
}
