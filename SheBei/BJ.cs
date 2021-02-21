using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class BJ:OBJ
    {
        public BJ(UserState us) : base(us) { }

        public new DataSet Select_Max_BJBH(string p_lx_zl)
        {
            return base.Select_Max_BJBH(p_lx_zl);
        }

        public new DataSet Select_BJ_Pro(Struct_BJ struct_BJ)
        {
            return base.Select_BJ_Pro(struct_BJ);
        }
        public new DataSet Select_BJbyBJBH(int  p_id)
        {
            return base.Select_BJbyBJBH(p_id);
        }
        public new int Select_BJ_Count(Struct_BJ struct_BJ)
        {
            return base.Select_BJ_Count(struct_BJ);
        }
        public new void Insert_BJ(Struct_BJ struct_BJ)
        {
            base.Insert_BJ(struct_BJ);
        }
        public new void Update_BJ(Struct_BJ struct_BJ)
        {
            base.Update_BJ(struct_BJ);
        }
        public new void Delete_BJ(string p_sjc, string p_czfs, string p_czxx)
        {
            base.Delete_BJ(p_sjc, p_czfs, p_czxx);
        }

        public new DataTable Select_BJ_Detail(int p_id)
        {
            return base.Select_BJ_Detail(p_id);
        }
        public new void Update_BJZT(Struct_BJ struct_BJ)
        {
            base.Update_BJZT(struct_BJ);
        }
        public new void Update_BJ_SJBS_ZT(Struct_BJ struct_BJ)
        {
            base.Update_BJ_SJBS_ZT(struct_BJ);
        }
        public new void Update_BJ_SJBS_LSSJ_ZT(Struct_BJ struct_BJ)
        {
            base.Update_BJ_SJBS_LSSJ_ZT(struct_BJ);
        }

        public new void Update_BJ_SJBS_FBSJ_ZT(Struct_BJ struct_BJ)
        {
            base.Update_BJ_SJBS_FBSJ_ZT(struct_BJ);
        }
        public new int BJ_SJBF(int id)
        {
            return base.BJ_SJBF(id);
        }

        public new string SHTG_BJBH(string bjbh)
        {
            return base.SHTG_BJBH(bjbh);
        }
      





     
        public new DataSet Select_BJXX()
        {
            return base.Select_BJXX();
        }
       
        public new DataSet Select_BJRK_Pro(Struct_BJRK struct_BJRK)
        {
            return base.Select_BJRK_Pro(struct_BJRK);
        }
        public new DataSet Select_BJRKbyID(string p_id)
        {
            return base.Select_BJRKbyID(p_id);
        }
        public new int Select_BJRK_Count(Struct_BJRK struct_BJRK)
        {
            return base.Select_BJRK_Count(struct_BJRK);
        }
        public new void Insert_BJRK(Struct_BJRK struct_BJRK)
        {
            base.Insert_BJRK(struct_BJRK);
        }
        public new void Update_BJRK(Struct_BJRK struct_BJRK)
        {
            base.Update_BJRK(struct_BJRK);
        }
        public new void Delete_BJRK(string p_id, string p_czfs, string p_czxx)
        {
            base.Delete_BJRK(p_id, p_czfs, p_czxx);
        }
        public new void Update_BJRKZT(Struct_BJRK struct_BJRK)
        {
            base.Update_BJRKZT(struct_BJRK);
        }

        public new void Update_BJRK_SJBS_ZT(Struct_BJRK struct_BJRK)
        {
            base.Update_BJRK_SJBS_ZT(struct_BJRK);
        }
        public new void Update_BJRK_SJBS_LSSJ_ZT(Struct_BJRK struct_BJRK)
        {
            base.Update_BJRK_SJBS_LSSJ_ZT(struct_BJRK);
        }

        public new void Update_BJRK_SJBS_FBSJ_ZT(Struct_BJRK struct_BJRK)
        {
            base.Update_BJRK_SJBS_FBSJ_ZT(struct_BJRK);
        }
        public new int BJRK_SJBF(int id)
        {
            return base.BJRK_SJBF(id);
        }

        public new int BJCK_SJBF(int id)
        {
            return base.BJCK_SJBF(id);
        }

        public new DataSet Select_BJCK_Pro(Struct_BJCK struct_BJCK)
        {
            return base.Select_BJCK_Pro(struct_BJCK);
        }
       
        public new DataSet Select_BJCKbyID(string p_id)
        {
            return base.Select_BJCKbyID(p_id);
        }
        public new int Select_BJCK_Count(Struct_BJCK struct_BJCK)
        {
            return base.Select_BJCK_Count(struct_BJCK);
        }
        public new void Insert_BJCK(Struct_BJCK struct_BJCK)
        {
            base.Insert_BJCK(struct_BJCK);
        }
        public new void Update_BJCK(Struct_BJCK struct_BJCK)
        {
            base.Update_BJCK(struct_BJCK);
        }
        public new void Delete_BJCK(string p_id, string p_czfs, string p_czxx)
        {
            base.Delete_BJCK(p_id, p_czfs, p_czxx);
        }
        public new void Update_BJCKZT(Struct_BJCK struct_BJCK)
        {
            base.Update_BJCKZT(struct_BJCK);
        }
        public new void Update_BJCK_SJBS_ZT(Struct_BJCK struct_BJCK)
        {
            base.Update_BJCK_SJBS_ZT(struct_BJCK);
        }
        public new void Update_BJCK_SJBS_LSSJ_ZT(Struct_BJCK struct_BJCK)
        {
            base.Update_BJCK_SJBS_LSSJ_ZT(struct_BJCK);
        }

        public new void Update_BJCK_SJBS_FBSJ_ZT(Struct_BJCK struct_BJCK)
        {
            base.Update_BJCK_SJBS_FBSJ_ZT(struct_BJCK);
        }

        public new void Update_BJSL(Struct_BJ Struct_BJ)
        {
             base.Update_BJSL(Struct_BJ);
        }

        public new DataSet Select_BJCRKQD(Struct_BJ struct_BJ)
        {
            return base.Select_BJCRKQD(struct_BJ);
        }

        public new int Select_BJCRKQD_Count(Struct_BJ struct_BJ)
        {
            return base.Select_BJCRKQD_Count(struct_BJ);
        }
        public new DataTable Select_BJ_DC(int p_userid)
        {
            return base.Select_BJ_DC(p_userid);
        }
        //导出
        public new DataTable Select_BJCRK_DC(int p_userid)
        {
            return base.Select_BJCRK_DC(p_userid);
        }
        public new DataTable Select_BJCRKQD_DC(int p_userid)
        {
            return base.Select_BJCRKQD_DC(p_userid);
        }
    }
}
