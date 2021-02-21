using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUST.Sys;
using System.Data;
using System.Data.OracleClient;
using Sys;

namespace CUST.MKG
{
    public class YGZZ:OYGZZ
    {
        public YGZZ(UserState us) : base(us) { }

        public new DataTable Select_YGZZ_Pro(Struct_Select_YGZZ ygzz)
        {
            return base.Select_YGZZ_Pro(ygzz);
        }
        public new DataTable Select_YGZZ_Pro_Ptyg(Struct_Select_YGZZ ygzz)
        {
            return base.Select_YGZZ_Pro_Ptyg(ygzz);
        }
        public new int Select_YGZZCount(Struct_Select_YGZZ ygzz)
        {
            return base.Select_YGZZCount(ygzz);
        }
        public new int Select_YGZZCount_Ptyg(Struct_Select_YGZZ ygzz)
        {
            return base.Select_YGZZCount_Ptyg(ygzz);
        }
        public new DataSet Select_YGZZByYGBH(string p_ygbh,int p_userid)
        {
            return base.Select_YGZZByYGBH(p_ygbh,p_userid);
        }

        public new String Select_BmdmByBh(string bh)
        {
            return base.Select_BmdmByBh(bh);
        }
        public new void Delete_YGZZ_byID(int id, string p_czfs, string p_czxx)
        {
            base.Delete_YGZZ_byID(id, p_czfs, p_czxx);
        }
        public new void Insert_YGZZ_ENG(Struct_YGZZ ygzz)
        {
            base.Insert_YGZZ_ENG(ygzz);
        }
        public new void Insert_YGZZ_ZZ(Struct_YGZZ ygzz)
        {
            base.Insert_YGZZ_ZZ(ygzz);
        }
        public new  void Insert_YGZZ_QZ(Struct_YGZZ ygzz)
        {
            base.Insert_YGZZ_QZ(ygzz);
        }
        public new  DataTable Select_YGZZByZZID(int id)
        {
            return base.Select_YGZZByZZID(id);
        }
        public new  void Update_YGZZ_ENG(Struct_YGZZ ygzz)
        {
            base.Update_YGZZ_ENG(ygzz);
        }
        public new  void Update_YGZZ_ZZ(Struct_YGZZ ygzz)
        {
            base.Update_YGZZ_ZZ(ygzz);
        }
        public new  void Update_YGZZ_QZ(Struct_YGZZ ygzz)
        {
            base.Update_YGZZ_QZ(ygzz);
        }
        public new  void Update_ygzz_ZT(long id, string zt, string bhyy)
        {
            base.Update_ygzz_ZT(id,zt,bhyy);
        }
        public new void Update_YGZZ_SJBS_ZT(Struct_YGZZ ygzz)
        {
            base.Update_YGZZ_SJBS_ZT(ygzz);
        }
        public new void Update_YGZZ_SJBS_LSSJ_ZT(Struct_YGZZ ygzz)
        {
            base.Update_YGZZ_SJBS_LSSJ_ZT(ygzz);
        }

        public new void Update_YGZZ_SJBS_FBSJ_ZT(Struct_YGZZ ygzz)
        {
            base.Update_YGZZ_SJBS_FBSJ_ZT(ygzz);
        }
        public new int YGZZ_SJBF(int id)
        {
            return base.YGZZ_SJBF(id);
        }
        }
}
