using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class WHWX : OWHWX
    {
        public WHWX(UserState us) : base(us) { }
        public new DataSet Select_SBWH_Pro(Struct_SBWH struct_SBWH)
        {
            return base.Select_SBWH_Pro(struct_SBWH);
        }
        public new DataSet Select_SBWHbyID(int p_id, string p_sblx)
        {
            return base.Select_SBWHbyID( p_id,  p_sblx);
        }
        public new int Select_SBWH_Count(Struct_SBWH struct_SBWH)
        {
            return base.Select_SBWH_Count(struct_SBWH);
        }
        public new void Insert_SBWH(Struct_SBWH struct_SBWH)
        {
             base.Insert_SBWH(struct_SBWH);
        }
        public new void Update_SBWH(Struct_SBWH struct_SBWH)
        {
             base.Update_SBWH(struct_SBWH);
        }
        public new void Delete_SBWH(int p_id, string p_czfs, string p_czxx)
        {
             base.Delete_SBWH( p_id,  p_czfs,  p_czxx);
        }
        public new DataTable Select_SBWH_Detail(int id)
        {
            return base.Select_SBWH_Detail(id);
        }
        public new void Update_SBWHZT(Struct_SBWH struct_SBWH)
        {
            base.Update_SBWHZT(struct_SBWH);
        }
        public new void Update_SBWH_SJBS_ZT(Struct_SBWH struct_SBWH)
        {
            base.Update_SBWH_SJBS_ZT(struct_SBWH);
        }
        public new void Update_SBWH_SJBS_LSSJ_ZT(Struct_SBWH struct_SBWH)
        {
            base.Update_SBWH_SJBS_LSSJ_ZT(struct_SBWH);
        }
        public new void Update_SBWH_SJBS_FBSJ_ZT(Struct_SBWH struct_SBWH)
        {
            base.Update_SBWH_SJBS_FBSJ_ZT(struct_SBWH);
        }
        public new int Struct_SBWH_SJBF(int id)
        {
            return base.Struct_SBWH_SJBF(id);
        }


        //导出
        public new DataTable Select_SBGZ_DC(int p_userid)
        {
            return base.Select_SBGZ_DC(p_userid);
        }

        //导出
        public new DataTable Select_SBWH_DC(int p_userid)
        {
            return base.Select_SBWH_DC(p_userid);
        }


        public new DataSet Select_SBGZ_Pro(Struct_SBGZ struct_SBGZ)
        {
            return base.Select_SBGZ_Pro(struct_SBGZ);
        }
        public new DataSet Select_SBGZbyID(int p_id, string p_sblx)
        {
            return base.Select_SBGZbyID(p_id, p_sblx);
        }
        public new int Select_SBGZ_Count(Struct_SBGZ struct_SBGZ)
        {
            return base.Select_SBGZ_Count(struct_SBGZ);
        }
        public new void Insert_SBGZ(Struct_SBGZ struct_SBGZ)
        {
            base.Insert_SBGZ(struct_SBGZ);
        }
        public new void Update_SBGZ(Struct_SBGZ struct_SBGZ)
        {
            base.Update_SBGZ(struct_SBGZ);
        }
        public new void Delete_SBGZ(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_SBGZ(p_id, p_czfs, p_czxx);
        }
        public new DataSet Select_SBWHbySBBH(string sbbh)
        {
            return base.Select_SBWHbySBBH(sbbh);
        }
        public new DataSet Select_SBGZbySBBH(string sbbh)
        {
            return base.Select_SBGZbySBBH(sbbh);
        }
        public new DataTable Select_SBGZ_Detail(int id)
        {
            return base.Select_SBGZ_Detail(id);
        }
        public new void Update_SBGZZT(Struct_SBGZ struct_SBGZ)
        {
            base.Update_SBGZZT(struct_SBGZ);
        }
        public new void Update_SBGZ_SJBS_ZT(Struct_SBGZ struct_SBGZ)
        {
            base.Update_SBGZ_SJBS_ZT(struct_SBGZ);
        }
        public new void Update_SBGZ_SJBS_LSSJ_ZT(Struct_SBGZ struct_SBGZ)
        {
            base.Update_SBGZ_SJBS_LSSJ_ZT(struct_SBGZ);
        }
        public new void Update_SBGZ_SJBS_FBSJ_ZT(Struct_SBGZ struct_SBGZ)
        {
            base.Update_SBGZ_SJBS_FBSJ_ZT(struct_SBGZ);
        }
        public new int Struct_SBGZ_SJBF(int id)
        {
            return base.Struct_SBGZ_SJBF(id);
        }

        public new DataTable Select_SBDM(string sblx)
        {
            return base.Select_SBDM(sblx);
        }
    }
}
