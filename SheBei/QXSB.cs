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
    public class QXSB : OQXSB
    {
        public QXSB(UserState us) : base(us) { }
        public new DataSet Select_QXSB(Struct_QXSB struct_qxsb)
        {
            return base.Select_QXSB(struct_qxsb);
        }
        public new void Insert_QXSB(Struct_QXSB struct_qxsb)
        {
             base.Insert_QXSB(struct_qxsb);
        }
        public new void Update_QXSB(Struct_QXSB struct_qxsb)
        {
                base.Update_QXSB(struct_qxsb);
        }
        public new void Delete_QXSB(string p_id,string p_czfs, string p_czxx)
        {
            base.Delete_QXSB(p_id,p_czfs,p_czxx);
        }
        public new int Select_QXSB_Count(Struct_QXSB struct_qxsb)
        {
            return base.Select_QXSB_Count(struct_qxsb);
        }
        public new DataSet Select_QXSBbySBBH(string id)
        {
            return base.Select_QXSBbySBBH(id);
        }
        public new DataSet Select_Max_qxsbbh(string bm_sblx)
        {
            return base.Select_Max_qxsbbh(bm_sblx);
        }
        public new void Update_QXSBZT(Struct_QXSB struct_qxsb)
        {
            base.Update_QXSBZT(struct_qxsb);
        }
        public new void Update_QXSB_SJBS_ZT(Struct_QXSB struct_qxsb)
        {
            base.Update_QXSB_SJBS_ZT(struct_qxsb);
        }
        public new void Update_QXSB_SJBS_LSSJ_ZT(Struct_QXSB struct_qxsb)
        {
            base.Update_QXSB_SJBS_LSSJ_ZT(struct_qxsb);
        }

        public new void Update_QXSB_SJBS_FBSJ_ZT(Struct_QXSB struct_qxsb)
        {
            base.Update_QXSB_SJBS_FBSJ_ZT(struct_qxsb);
        }
        public new int QXSB_SJBF(int id)
        {
            return base.QXSB_SJBF(id);
        }
        public new string Select_SB_MaxNumber(string sjjd)//时间节点
        {
            return base.Select_SB_MaxNumber(sjjd);
        }
        public new DataTable Select_QXSB_DC(int p_userid)
        {
            return base.Select_QXSB_DC(p_userid);
        }

    }
}
