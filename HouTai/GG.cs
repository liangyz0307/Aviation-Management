using System;
using System.Collections.Generic;
using System.Text;
using CUST.Sys;
using System.Data;
using Sys;

namespace CUST.MKG
{
   
    public  class GG:OGG
    {
        public GG(UserState _usState) : base(_usState) { }

        public new DataTable Select_GG_Pro(Struct_GG_Pro _struct)
        {
            return base.Select_GG_Pro(_struct);
        }
        public new DataTable Select_GG(int id)
        {
            return base.Select_GG(id);
        }
        public new int Select_GG_count(Struct_GG_Pro _struct)
        {
            return base.Select_GG_count(_struct);
        }
        public new void GG_insert(Struct_GG_Pro _struct)
        {
            base.GG_insert(_struct);
        }
        public new void GG_update(Struct_GG_Pro _struct)
        {
            base.GG_update(_struct);
        }
        public new void delete_GG(int id,string p_czfs,string p_czxx)
        {
            base.delete_GG(id, p_czfs, p_czxx);
        }
    }
}
