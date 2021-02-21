using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.WKG
{
    public class YXXX:OYXXX
    {
        public YXXX(UserState us) : base(us) { }


        //查找表的数量
        public new int Select_Bs_Yxxx_Count(Struct_Bs_YXXX struct_yxxx)
        {
            return base.Select_Bs_Yxxx_Count(struct_yxxx);
        }

        //查找运行信息报送
        public new DataTable Select_Bs_YXXX(Struct_Bs_YXXX struct_yxxx)
        {
            return base.Select_Bs_YXXX(struct_yxxx);
        }
        //添加
        public new void Insert_BS_YXXX(Struct_Bs_YXXX struct_bs_yxxx)
        {
            base.Insert_BS_YXXX(struct_bs_yxxx);
        }

        ////查找表中数据
        //public new DataTable SelectBS_Yssb_Pro(Struct_Bs_YXXX struct_select_bs_yssb)
        //{
        //    return base.SelectBS_Yssb_Pro(struct_select_bs_yssb);
        //}

        ////查找填报单位
        //public new DataTable Select_Bs_Yssb_Tbdw()
        //{
        //    return base.Select_Bs_Yssb_Tbdw();
        //}
        ////查找状态
        //public new DataTable Select_Bs_Yssb_Zt()
        //{
        //    return base.Select_Bs_Yssb_Zt();
        //}
        ////查找申报状态
        //public new DataTable Select_Bs_Yssb_Sbzt()
        //{
        //    return base.Select_Bs_Yssb_Sbzt();
        //}
        //删除
        public new void Delete_Bs_Yxxx(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_Bs_Yxxx(p_id, p_czfs, p_czxx);
        }
        ////更改信息
        //public new void Update_Bs_Yssb(Struct_Bs_YXXX struct_bs_yssb_update)
        //{
        //    base.Update_Bs_Yssb(struct_bs_yssb_update);
        //}
        ////查找详细信息
        //public new DataTable Select_Bs_Yssb_Detail(int id)
        //{
        //    return base.Select_Bs_Yssb_Detail(id);
        //}

        ////修改申报状态
        //public new void Update_Bs_Yssb_Sbzt(Struct_Bs_YXXX struct_bs_yssb_update)
        //{
        //    base.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
        //}


        //public new void Update_YSSB_SJBS_ZT(Struct_Bs_YXXX struct_bs_yssb_update)
        //{
        //    base.Update_YSSB_SJBS_ZT(struct_bs_yssb_update);
        //}
        //public new void Update_YSSB_SJBS_LSSJ_ZT(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        //{
        //    base.Update_YSSB_SJBS_LSSJ_ZT(struct_bs_yssb_update);
        //}

        //public new void Update_YSSB_SJBS_FBSJ_ZT(Struct_Bs_YXXX struct_bs_yssb_update)
        //{
        //    base.Update_YSSB_SJBS_FBSJ_ZT(struct_bs_yssb_update);
        //}
        //public new int YSSB_SJBF(int id)
        //{
        //    return base.YSSB_SJBF(id);
        //}


    }
}
