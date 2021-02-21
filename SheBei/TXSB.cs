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
    public class TXSB:OTXSB
    {
        public TXSB(UserState us) : base(us) { }
        
        public new DataSet Select_TXSB_Pro(Struct_TXSB struct_TXSB)
        {
            return base.Select_TXSB_Pro(struct_TXSB);
        }
        public new int Select_TXSB_Count(Struct_TXSB struct_txsb)
        {
            return base.Select_TXSB_Count(struct_txsb);
        }
        public new void Insert_TXSB(Struct_TXSB struct_TXSB)
        {
            base.Insert_TXSB(struct_TXSB);
        }
        public new DataTable Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }

        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
       

        public new DataTable Select_TXSB_Detail(int p_id)
        {
            return base.Select_TXSB_Detail(p_id);
        }


        public new void Delete_TXSB(int id, string p_czfs, string p_czxx)
        {
            base.Delete_TXSB(id, p_czfs, p_czxx);
        }
        public new void Update_TXSBZT(Struct_TXSB txsb)
        {
            base.Update_TXSBZT(txsb);
        }
        public new void Update_TXSB_SJBS_ZT(Struct_TXSB txsb)
        {
            base.Update_TXSB_SJBS_ZT(txsb);
        }
        public new void Update_TXSB_SJBS_LSSJ_ZT(Struct_TXSB txsb)
        {
            base.Update_TXSB_SJBS_LSSJ_ZT(txsb);
        }

        public new void Update_TXSB_SJBS_FBSJ_ZT(Struct_TXSB txsb)
        {
            base.Update_TXSB_SJBS_FBSJ_ZT(txsb);
        }
        public new int TXSB_SJBF(int id)
        {
            return base.TXSB_SJBF(id);
        }

        public new void Update_TXSB(Struct_TXSB struct_txsb)
        {
            base.Update_TXSB(struct_txsb);
        }
        public new string Select_SB_MaxNumber(string sjjd)
        {
            return base.Select_SB_MaxNumber(sjjd);
        }
        public new DataTable Select_TXSB_DC(int p_userid)
        {
            return base.Select_TXSB_DC(p_userid);
        }

    }
}
