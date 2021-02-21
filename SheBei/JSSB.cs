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
    public class JSSB:OJSSB
    {
        public JSSB(UserState us) : base(us) { }
        public new DataTable Select_JSSB_Pro(Struct_JSSB struct_jssb) {
            return base.Select_JSSB_Pro(struct_jssb);
        }
        public new int Select_JSSB_Count(Struct_JSSB struct_jssb) {
            return base.Select_JSSB_Count(struct_jssb);
        }
        public new DataTable Select_JSSB_Detail(int id) {
            return base.Select_JSSB_Detail(id);
        }
        public new void Update_JSSBZT(Struct_JSSB struct_jssb) {
            base.Update_JSSBZT(struct_jssb);
        }
        public new void Insert_JSSB(Struct_JSSB struct_jssb) {
             base.Insert_JSSB(struct_jssb);
        }
        public new void Update_JSSB(Struct_JSSB struct_jssb)
        {
            base.Update_JSSB(struct_jssb);
        }
        public new void Delete_JSSB(int id, string p_czfs, string p_czxx) {
            base.Delete_JSSB(id, p_czfs, p_czxx);
        }
        public new void Update_JSSB_ZT(Struct_JSSB struct_jssb) {
            base.Update_JSSB_ZT(struct_jssb);
        }
        public new void Update_JSSB_SJBS_ZT(Struct_JSSB Struct_JSSB)
        {
            base.Update_JSSB_SJBS_ZT(Struct_JSSB);
        }
        public new void Update_JSSB_SJBS_LSSJ_ZT(Struct_JSSB struct_jssb)
        {
            base.Update_JSSB_SJBS_LSSJ_ZT(struct_jssb);
        }
        public new void Update_JSSB_SJBS_FBSJ_ZT(Struct_JSSB struct_jssb)
        {
            base.Update_JSSB_SJBS_FBSJ_ZT(struct_jssb);
        }
        public new int JSSB_SJBF(int id)
        {
            return base.JSSB_SJBF(id);
        }
        public new string Select_SB_MaxNumber(string sjjd)//时间节点
        {
            return base.Select_SB_MaxNumber(sjjd);
        }
        public new DataTable Select_JSSB_DC(int p_userid)
        {
            return base.Select_JSSB_DC(p_userid);
        }

    }
}
