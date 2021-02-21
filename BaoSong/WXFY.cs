using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
   public class WXFY:OWXFY
    {
        public WXFY(UserState us) : base(us) { }
        //添加维修费用(请示登记)
        public new void Insert_Bs_Wxfy(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            base.Insert_Bs_Wxfy(struct_bs_wxfy);
        }
        //查找维修类型
        public new DataTable Select_Bs_Wxfy_Wxlx()
        { return base.Select_Bs_Wxfy_Wxlx(); }
        //查找维修费用(请示登记)
        public new DataTable SelectBS_Wxfy_Pro(Struct_Bs_Wxfy struct_select_bs_wxfy)
        {
            return base.SelectBS_Wxfy_Pro(struct_select_bs_wxfy);
        }
        //查找登记单位
        public new DataTable Select_Bs_Wxfy_Djdw()
        {
            return base.Select_Bs_Wxfy_Djdw();
        }
        //删除维修费用(请示登记)
        public new void Delete_Bs_Wxfy(int p_wxbh, string p_czfs, string p_czxx)
        {
            base.Delete_Bs_Wxfy(p_wxbh, p_czfs,p_czxx);
        }
        //更改维修费用(请示登记)
        public new void Update_Bs_Wxfy(Struct_Bs_Wxfy struct_bs_wxfy_update)
        {
            base.Update_Bs_Wxfy(struct_bs_wxfy_update);
        }
        //查找维修费用(请示登记)详细信息
        public new DataTable Select_Bs_Wxfy_Detail(int p_wxbh)
        {
            return base.Select_Bs_Wxfy_Detail(p_wxbh);
        }
        //查找维修费用(请示登记)的数量
        public new int Select_Bs_Wxfy_Count(Struct_Bs_Wxfy struct_bs_wxfy_count)
        {
            return base.Select_Bs_Wxfy_Count(struct_bs_wxfy_count);
        }
        //更改维修费用(请示登记)的状态
        public new void Update_WXFYZT(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            base.Update_WXFYZT(struct_bs_wxfy);
        }

        //通过项目名称查询报销登记
        public new DataTable Select_Bxdj_ByXmmc(Struct_Bs_Wxfy_Bxdj struct_select_bs_bxdj)
        {
            return base.Select_Bxdj_ByXmmc(struct_select_bs_bxdj);
        }

        //添加报销登记
        public new void Insert_Bs_Bxdj(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj)
        {
            base.Insert_Bs_Bxdj(struct_bs_bxdj);
        }

        //通过项目名称查询报销登记明细
        public new DataTable Select_Bxdj_Mx_ByXmmc(Struct_Bs_Wxfy_Bxdj_Mx struct_select_bs_bxdj_mx)
        {
            return base.Select_Bxdj_Mx_ByXmmc(struct_select_bs_bxdj_mx);
        }
        //通过明细编号查询报销登记明细
        public new DataTable Select_Bxdj_Mx_ByMxbh(Struct_Bs_Wxfy_Bxdj_Mx struct_select_bs_bxdj_mx)
        {
            return base.Select_Bxdj_Mx_ByMxbh(struct_select_bs_bxdj_mx);
        }

        //删除报销登记
        public new void Delete_Bs_Bxdj(string p_xmmc, string p_czfs, string p_czxx)
        {
            base.Delete_Bs_Bxdj(p_xmmc, p_czfs, p_czxx);
        }

        //通过项目名称更改报销登记
        public new void Update_Bs_Bxdj(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj)
        {
            base.Update_Bs_Bxdj(struct_bs_bxdj);
        }
               //通过明细编号更改报销登记(明细)
        public new void Update_Bs_Bxdj_Mx(Struct_Bs_Wxfy_Bxdj_Mx struct_bxdj_mx)
        {
            base.Update_Bs_Bxdj_Mx(struct_bxdj_mx);
        }

        //更改报销登记的状态关联明细的状态
        public new void Update_BXDJ_ZT(Struct_Bs_Wxfy_Bxdj struct_bs_bxdj)
        {
            base.Update_BXDJ_ZT(struct_bs_bxdj);
        }

        //添加报销登记
        public new void Insert_Bs_Bxdj_Mx(Struct_Bs_Wxfy_Bxdj_Mx struct_bxdj_mx)
        {
            base.Insert_Bs_Bxdj_Mx(struct_bxdj_mx);
        }

        //删除报销登记明细（通过明细编号）
        public new void Delete_Bs_Bxdj_Mx_ByMxbh(string p_mxbh, string p_czfs, string p_czxx)
        {
            base.Delete_Bs_Bxdj_Mx_ByMxbh(p_mxbh, p_czfs, p_czxx);
        }
        public new void Update_WXFY_SJBS_ZT(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            base.Update_WXFY_SJBS_ZT(struct_bs_wxfy);
        }
        public new void Update_WXFT_SJBS_LSSJ_ZT(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            base.Update_WXFY_SJBS_LSSJ_ZT(struct_bs_wxfy);
        }

        public new void Update_WXFY_SJBS_FBSJ_ZT(Struct_Bs_Wxfy struct_bs_wxfy)
        {
            base.Update_WXFY_SJBS_FBSJ_ZT(struct_bs_wxfy);
        }
        public new int WXFY_SJBF(int wxbh)
        {
            return base.WXFY_SJBF(wxbh);
        }
    }
}
