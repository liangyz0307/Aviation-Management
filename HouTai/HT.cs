using CUST.Sys;
using Sys;
using System.Data;

namespace CUST.MKG
{
   public  class HT:OHT
    {
        public HT(UserState userstate) : base(userstate) { }
        public new  DataTable Select_HT(Struct_HT struct_ht)
        {
            return base.Select_HT(struct_ht);
        }
        public new DataTable Select_HTDetail(Struct_HT struct_ht)
        {
            return base.Select_HTDetail(struct_ht);
        }
        public new int Select_HT_Count(Struct_HT struct_ht)
        {
            return base.Select_HT_Count(struct_ht);
        }
        public new void  Delete_HT(Struct_HT struct_ht)
        {
             base.Delete_HT(struct_ht);
        }
        public new void Insert_HT(Struct_HT struct_ht)
        {
            base.Insert_HT(struct_ht);
        }
        public new void Update_HT(Struct_HT struct_ht)
        {
            base.Update_HT(struct_ht);
        }
        public  new  DataTable Select_HT_OutTime()
        {
            return base.Select_HT_OutTime();
        }
    }
}
