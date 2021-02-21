using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class TZSB:OTZSB
    {
        public TZSB(UserState us) : base(us) {}
        public new DataSet Select_TZ_Pro(Struct_TZSB struct_tzsb) {
            return base.Select_TZ_Pro(struct_tzsb);
        }
        public new int Select_TZ_Count(Struct_TZSB struct_tzsb) {
            return base.Select_TZ_Count(struct_tzsb);
        }
        public new int Select_Table_Count_HD(Struct_SELECT_COUNT Struct_select_count)
        {
            return base.Select_Table_Count_HD(Struct_select_count);
        }
        public new int Select_Table_Count_TX(Struct_SELECT_COUNT Struct_select_count)
        {
            return base.Select_Table_Count_TX(Struct_select_count);
        }
        public new int Select_Table_Count_JS(Struct_SELECT_COUNT Struct_select_count)
        {
            return base.Select_Table_Count_JS(Struct_select_count);
        }
        public new int Select_Table_Count_QX(Struct_SELECT_COUNT Struct_select_count)
        {
            return base.Select_Table_Count_QX(Struct_select_count);
        }
        public new void Insert_TZ(Struct_TZSB struct_tzsb) {
            base.Insert_TZ(struct_tzsb);
        }
        public new void Update_TZ(Struct_TZSB struct_tzsb)
        {
            base.Update_TZ(struct_tzsb);
        }
        public new void Delete_TZ(string p_tzbh,string p_czfs,string p_czxx) {
            base.Delete_TZ(p_tzbh, p_czfs, p_czxx);
        }
        public  DataTable Select_KTByBh(string p_tzbh) {
            return base.Select_KTByBh(p_tzbh);
        }
        public new void Insert_TZ_KT(Struct_TZSB struct_tzsb)
        {
            base.Insert_TZ_KT(struct_tzsb);
        }
        public new void Update_TZ_KT(Struct_TZSB struct_tzsb)
        {
            base.Update_TZ_KT(struct_tzsb);
        }
        public new void Delete_TZ_KT(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_TZ_KT(p_id, p_czfs, p_czxx);
        }
        public  DataTable Select_JSQByBh(string p_tzbh)
        {
            return base.Select_JSQByBh(p_tzbh);
        }
        public new void Insert_TZ_JSQQK(Struct_TZSB struct_tzsb)
        {
            base.Insert_TZ_JSQQK(struct_tzsb);
        }
        public new void Update_TZ_JSQQK(Struct_TZSB struct_tzsb)
        {
            base.Update_TZ_JSQQK(struct_tzsb);
        }
        public new void Delete_TZ_JSQQK(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_TZ_JSQQK(p_id, p_czfs, p_czxx);
        }
        public new DataTable Select_FHSBByBh(string p_tzbh)
        {
            return base.Select_FHSBByBh(p_tzbh);
        }
        public new void Insert_TZ_FHSB(Struct_TZSB struct_tzsb)
        {
            base.Insert_TZ_FHSB(struct_tzsb);
        }
        public new void Update_TZ_FHSB(Struct_TZSB struct_tzsb)
        {
            base.Update_TZ_FHSB(struct_tzsb);
        }
        public new void Delete_TZ_FHSB(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_TZ_FHSB(p_id, p_czfs, p_czxx);
        }
        public new DataTable Select_MSCSByBh(string p_tzbh)
        {
            return base.Select_MSCSByBh(p_tzbh);
        }
        public new void Insert_TZ_MSCS(Struct_TZSB struct_tzsb)
        {
            base.Insert_TZ_MSCS(struct_tzsb);
        }
        public new void Update_TZ_MSCS(Struct_TZSB struct_tzsb)
        {
            base.Update_TZ_MSCS(struct_tzsb);
        }
        public new void Delete_TZ_MSCS(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_TZ_MSCS(p_id, p_czfs, p_czxx);
        }
        public new DataTable Select_TZ_Detail(int id) {
            return base.Select_TZ_Detail(id);
        }
        public new DataTable Select_TZ_KT_Detail(int id)
        {
            return base.Select_TZ_KT_Detail(id);
        }
        public new DataTable Select_TZ_FHSB_Detail(int id)
        {
            return base.Select_TZ_FHSB_Detail(id);
        }
        public new DataTable Select_TZ_JSQ_Detail(int id)
        {
            return base.Select_TZ_JSQ_Detail(id);
        }
        public new DataTable Select_TZ_MSCS_Detail(int id)
        {
            return base.Select_TZ_MSCS_Detail(id);
        }

        public new void Update_TZZT(Struct_TZSB struct_tzsb) {
            base.Update_TZZT(struct_tzsb);
        }
        public new void Update_TZ_SJBS_ZT(Struct_TZSB struct_tzsb) {
            base.Update_TZ_SJBS_ZT(struct_tzsb);
        }
        public new void Update_TZ_SJBS_LSSJ_ZT(Struct_TZSB struct_tzsb) {
            base.Update_TZ_SJBS_LSSJ_ZT(struct_tzsb);
        }
        public new void Update_TZ_SJBS_FBSJ_ZT(Struct_TZSB struct_tzsb) {
            base.Update_TZ_SJBS_FBSJ_ZT(struct_tzsb);
        }
        public new int Struct_TZSB_SJBF(int id) {
            return base.Struct_TZSB_SJBF(id);
        }
        public new DataTable Select_TZ_DC(int p_userid)
        {
            return base.Select_TZ_DC(p_userid);
        }




        public new int Select_TXSBQD_Count(Struct_TZSB struct_tzsb)
        {
            return base.Select_TXSBQD_Count(struct_tzsb);
        }
        public new int Select_DHSBQD_Count(Struct_TZSB struct_tzsb)
        {
            return base.Select_DHSBQD_Count(struct_tzsb);
        }
        public new int Select_QXSBQD_Count(Struct_TZSB struct_tzsb)
        {
            return base.Select_QXSBQD_Count(struct_tzsb);
        }
        public new int Select_JSSBQD_Count(Struct_TZSB struct_tzsb)
        {
            return base.Select_JSSBQD_Count(struct_tzsb);
        }
        public new DataSet Select_TXSBQD(Struct_TZSB struct_tzsb)
        {
            return base.Select_TXSBQD(struct_tzsb);
        }
        public new DataSet Select_DHSBQD(Struct_TZSB struct_tzsb)
        {
            return base.Select_DHSBQD(struct_tzsb);
        }
        public new DataSet Select_QXSBQD(Struct_TZSB struct_tzsb)
        {
            return base.Select_QXSBQD(struct_tzsb);
        }
        public new DataSet Select_JSSBQD(Struct_TZSB struct_tzsb)
        {
            return base.Select_JSSBQD(struct_tzsb);
        }

    }
}
