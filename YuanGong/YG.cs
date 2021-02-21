using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys;

namespace CUST.MKG
{
    public class YG : OYG
    {
        public YG(UserState us) : base(us) { }

        public new DataTable Select_YG_Pro(Struct_YG yg)
        {
            return base.Select_YG_Pro(yg);
        }
        //普通员工只能看见本人信息
        public new DataTable Select_YG_Pro_Ptyg(Struct_YG yg)
        {
            return base.Select_YG_Pro_Ptyg(yg);
        }
        public new int Select_YGCount(Struct_YG yg)
        {
            return base.Select_YGCount(yg);
        }
        public new int Select_YGCount_Ptyg(Struct_YG yg)
        {
            return base.Select_YGCount_Ptyg(yg);
        }
        public new DataTable Select_YGDetail(int id)
        {
            return base.Select_YGDetail(id);
        }
        public new DataTable Select_YGDetail_ByBH(string bh)
        {
            return base.Select_YGDetail_ByBH(bh);
        }
        public new DataTable Select_GW_ByBM(string bmdm)
        {
            return base.Select_GW_ByBM(bmdm);
        }

        public new void Delete_YG(int id, string p_czfs, string p_czxx)
        {
            base.Delete_YG(id, p_czfs, p_czxx);
        }
        public new void Insert_YG(Struct_YG yg)
        {
            base.Insert_YG(yg);
        }
        public new void Update_YG(Struct_YG yg)
        {
            base.Update_YG(yg);
        }
        public new string SelectYGMaxBH(string rzsj)
        {
            return base.SelectYGMaxBH(rzsj);
        }
        public new void Update_YGXXZT(Struct_YG yg)
        {
            base.Update_YGXXZT(yg);
        }

        public new void Update_YGXX_SJBS_ZT(Struct_YG ygxx)
        {
            base.Update_YGXX_SJBS_ZT(ygxx);
        }
        public new void Update_YGXX_SJBS_LSSJ_ZT(Struct_YG ygxx)
        {
            base.Update_YGXX_SJBS_LSSJ_ZT(ygxx);
        }

        public new void Update_YGXX_SJBS_FBSJ_ZT(Struct_YG ygxx)
        {
            base.Update_YGXX_SJBS_FBSJ_ZT(ygxx);
        }
        public new int YGXX_SJBF(int   id)
        {
            return base.YGXX_SJBF(id);
        }
        public new void Delete_YH_SPR_BYBH(string bh, string p_czfs, string p_czxx)
        {
            base.Delete_YH_SPR_BYBH(bh, p_czfs, p_czxx);
        }

        //导出
        public new DataTable Select_YG_DC(int p_userid)
        {
            return base.Select_YG_DC(p_userid);
        }
        //员工高级检索
        public new DataTable Select_YG_Pro_GJJS(Struct_YG yg)
        {
            return base.Select_YG_Pro(yg);
        }

        //根据编号查询个人全部日程
        public new DataTable Select_Schedule_By_Ygbh(Struct_Schedule struct_schedule)
        {
            return base.Select_Schedule_By_Ygbh(struct_schedule);
        }

        //根据ID查询指定日程
        public new DataTable Select_Schedule_By_Id(Struct_Schedule struct_schedule)
        {
            return base.Select_Schedule_By_Id(struct_schedule);
        }
        //添加日程
        public new void Insert_Schedule(Struct_Schedule struct_schedule)
        {
            base.Insert_Schedule(struct_schedule);
        }

        //编辑日程
        public new void Update_Schedule(Struct_Schedule struct_schedule)
        {
            base.Update_Schedule(struct_schedule);
        }
        //删除日程
        public new void Delete_Schedule(int id, string p_czfs, string p_czxx)
        {
            base.Delete_Schedule(id,p_czfs, p_czxx);
        }
    }

}
