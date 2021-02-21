using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class DQGHDT : ODQGHDT
    {
        public DQGHDT(UserState _usState) : base(_usState) { }

        public new DataTable Select_DQGHDT_Pro(Struct_DQGHDT struct_DQGHDT)
        {
            return base.Select_DQGHDT_Pro(struct_DQGHDT);
        }
        public new int Select_DQGHDT_Count(Struct_DQGHDT struct_DQGHDT)
        {
            return base.Select_DQGHDT_Count(struct_DQGHDT);
        }
        public new DataTable Select_DQGHDTShow_Pro(Struct_DQGHDT struct_DQGHDT)
        {
            return base.Select_DQGHDTShow_Pro(struct_DQGHDT);
        }
        public new int Select_DQGHDTShow_Count(Struct_DQGHDT struct_DQGHDT)
        {
            return base.Select_DQGHDTShow_Count(struct_DQGHDT);
        }
        public new DataTable Select_DQGHDT_Detail(int id)
        {
            return base.Select_DQGHDT_Detail(id);
        }
       
        public new DataTable Find_DQGHDT_ById()
        {
            return base.Find_DQGHDT_ById();
        }
        public new void Insert_DQGHDT(Struct_DQGHDT struct_DQGHDT)
        {
            base.Insert_DQGHDT(struct_DQGHDT);
        }

        public new void Update_DQGHDT(Struct_DQGHDT struct_DQGHDT)
        {
            base.Update_DQGHDT(struct_DQGHDT);
        }
        public new void Update_DQGHDTZT(Struct_DQGHDT struct_DQGHDT)
        {
            base.Update_DQGHDTZT(struct_DQGHDT);
        }
        public new void Delete_DQGHDT(int id, string p_czfs, string p_czxx)
        {
            base.Delete_DQGHDT(id, p_czfs, p_czxx);
        }
    }
}
