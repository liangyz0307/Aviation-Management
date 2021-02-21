using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using Sys;

namespace CUST.MKG
{
    public class DHSB : ODHSB
    {
        public DHSB(UserState us) : base(us) { }
        public new DataSet Select_DHSB(Struct_DHSB struct_DHSB)
        {
            return base.Select_DHSB(struct_DHSB);
        }
        public new DataTable Select_DHSB_Detail(int p_id)
        {
            return base.Select_DHSB_Detail(p_id);                
        }
        public new int Select_DHSB_Count(Struct_DHSB struct_DHSB)
        {
            return base.Select_DHSB_Count(struct_DHSB);
        }
        public new string Select_DHSB_MaxNumber(string sjjd)//时间节点
        {
            return base.Select_DHSB_MaxNumber(sjjd);
        }
        public new void Insert_DHSB(Struct_DHSB struct_DHSB)
        {
            base.Insert_DHSB(struct_DHSB);
        }
        public new void Update_DHSB(Struct_DHSB struct_DHSB)
        {
            base.Update_DHSB(struct_DHSB);
        }
        public new void Delete_DHSB(string p_id, string p_czfs, string p_czxx)
        {
            base.Delete_DHSB(p_id, p_czfs, p_czxx);
        }
        public new void Update_DHSBZT(Struct_DHSB struct_DHSB)
        {
            base.Update_DHSBZT(struct_DHSB);
        }
        public new void Update_DHSB_SJBS_ZT(Struct_DHSB struct_DHSB)
        {
            base.Update_DHSB_SJBS_ZT(struct_DHSB);
        }
        public new void Update_DHSJ_SJBS_LSSJ_ZT(Struct_DHSB struct_DHSB)
        {
            base.Update_DHSB_SJBS_LSSJ_ZT(struct_DHSB);
        }
        public new void Update_DHSB_SJBS_FBSJ_ZT(Struct_DHSB struct_DHSB)
        {
            base.Update_DHSB_SJBS_FBSJ_ZT(struct_DHSB);
        }
        public new DataTable Select_DHSB_DC(int p_userid)
        {
            return base.Select_DHSB_DC(p_userid);
        }
    }
}


