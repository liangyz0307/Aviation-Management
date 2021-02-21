using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.WKG
{
    public class YSSB:OYSSB
    {
        public YSSB(UserState us) : base(us) { }
        //添加
        public new void Insert_Bs_Yssb(Struct_Bs_Yssb struct_bs_yssb)
        {
            base.Insert_Bs_Yssb(struct_bs_yssb);
        }
        //查找维修类型
        public new DataTable Select_Bs_Yssb_Yslx()
        { return base.Select_Bs_Yssb_Yslx(); }
        //查找表中数据
        public new DataTable SelectBS_Yssb_Pro(Select_Bs_Yssb struct_select_bs_yssb)
        {
            return base.SelectBS_Yssb_Pro(struct_select_bs_yssb);
        }
        //查找填报单位
        public new DataTable Select_Bs_Yssb_Tbdw()
        {
            return base.Select_Bs_Yssb_Tbdw();
        }
        //查找状态
        public new DataTable Select_Bs_Yssb_Zt()
        {
            return base.Select_Bs_Yssb_Zt();
        }
        //查找申报状态
        public new DataTable Select_Bs_Yssb_Sbzt()
        {
            return base.Select_Bs_Yssb_Sbzt();
        }
        //删除
        public new void Delete_Bs_Yssb(int p_id, string p_czfs, string p_czxx)
        {
            base.Delete_Bs_Yssb(p_id, p_czfs, p_czxx);
        }
        //更改信息
        public new void Update_Bs_Yssb(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            base.Update_Bs_Yssb(struct_bs_yssb_update);
        }
        //查找详细信息
        public new DataTable Select_Bs_Yssb_Detail(int id)
        {
            return base.Select_Bs_Yssb_Detail(id);
        }
        //查找表的数量
        public new int Select_Bs_Yssb_Count(Select_Bs_Yssb struct_bs_yssb_count)
        {
            return base.Select_Bs_Yssb_Count(struct_bs_yssb_count);
        }
        //修改申报状态
        public new void Update_Bs_Yssb_Sbzt(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            base.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
        }


        public new void Update_YSSB_SJBS_ZT(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            base.Update_YSSB_SJBS_ZT(struct_bs_yssb_update);
        }
        public new void Update_YSSB_SJBS_LSSJ_ZT(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            base.Update_YSSB_SJBS_LSSJ_ZT(struct_bs_yssb_update);
        }

        public new void Update_YSSB_SJBS_FBSJ_ZT(Struct_Bs_Yssb_Update struct_bs_yssb_update)
        {
            base.Update_YSSB_SJBS_FBSJ_ZT(struct_bs_yssb_update);
        }
        public new int YSSB_SJBF(int id)
        {
            return base.YSSB_SJBF(id);
        }


    }
}
