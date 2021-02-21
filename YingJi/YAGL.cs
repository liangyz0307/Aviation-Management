using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CUST.MKG
{
       public class YAGL:OYAGL
       {
        public YAGL(UserState us):base(us) { }
        //添加
        public new void Insert_YJ_YAGL_Proc(Struct_YAGL struct_yagl)
        {
            base.Insert_YJ_YAGL_Proc(struct_yagl);
        }
        //编辑
        public new void Update_YJ_YAGL_Proc(Struct_YAGL struct_yagl)
        {
            base.Update_YJ_YAGL_Proc(struct_yagl);
        }
        //检索
        public new DataTable Select_YJ_YAGL_Proc(Struct_YAGL struct_yagl)
        {
            return base.Select_YJ_YAGL_Proc(struct_yagl);
        }
        //删除
        public new void Delete_Yj_Yagl_Proc(string p_sjc, string p_czfs, string p_czxx)
        {
            base.Delete_Yj_Yagl_Proc(p_sjc, p_czfs, p_czxx);
        }
        //检索详细情况
        public new DataTable Select_Yj_Yagl_Detail_Proc(int p_id)
        {
            return base.Select_Yj_Yagl_Detail_Proc(p_id);
        }
        //查找名称
        public new DataTable Select_Yj_Yagl_Mc_Proc()
        {
            return base.Select_Yj_Yagl_Mc_Proc();
        }
        //查找地区
        public new DataTable Select_Zd_Zxdm_Proc()
        {
            return base.Select_Zd_Zxdm_Proc();
        }
        //查找专业
        public new DataTable Select_Zd_Zylx_Proc()
        {
            return base.Select_Zd_Zylx_Proc();
        }
        //检索表中的数量
        public new int Select_Yj_Yagl_Count_Proc(Struct_YAGL struct_yagl)
        {
            return base.Select_Yj_Yagl_Count_Proc(struct_yagl);
        }
        public new void Update_YAGLZT(Struct_YAGL struct_yagl)
        {
            base.Update_YAGLZT(struct_yagl);
        }
        public new void Update_YAGL_SJBS_ZT(Struct_YAGL struct_yagl)
        {
            base.Update_YAGL_SJBS_ZT(struct_yagl);
        }
        public new void Update_YAGL_SJBS_LSSJ_ZT(Struct_YAGL struct_yagl)
        {
            base.Update_YAGL_SJBS_LSSJ_ZT(struct_yagl);
        }

        public new void Update_YAGL_SJBS_FBSJ_ZT(Struct_YAGL struct_yagl)
        {
            base.Update_YAGL_SJBS_FBSJ_ZT(struct_yagl);
        }
        public new int YAGL_SJBF(int id)
        {
            return base.YAGL_SJBF(id);
        }
    }
}
