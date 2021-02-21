using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys;
namespace CUST.MKG
{
    public class DQZC : ODQZC
    {
        public DQZC(UserState us) : base(us) { }
        public new DataTable Select_DY(Struct_DY struct_dy)
        {
            return base.Select_DY(struct_dy);
        }
        public new DataTable Detail_DY(Struct_DY struct_dy)
        {
            return base.Detail_DY(struct_dy);
        }
        public new int Select_DYCount(Struct_DY struct_dy)
        {
            return base.Select_DYCount(struct_dy);
        }
        public new void Delete_DY(Struct_DY struct_dy)
        {
            base.Delete_DY(struct_dy);
        }
        public new void Insert_DY(Struct_DY struct_dy)
        {
            base.Insert_DY(struct_dy);
        }
        public new void Update_DY(Struct_DY struct_dy)
        {
            base.Update_DY(struct_dy);
        }
    }
}
