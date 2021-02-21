using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CUST.MKG
{
    public class ZZJG : OZZJG
    {
        public ZZJG(UserState us) : base(us) { }
        public new DataSet Select_ZZJG_All(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_All(strcut_zzjg);
        }
        public new DataSet Select_ZZJG_JCDZB(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_JCDZB(strcut_zzjg);
        }
        public new DataSet Select_ZZJG_DXZ(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_DXZ(strcut_zzjg);
        }
        public new int Select_ZZJG_Count(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_Count(strcut_zzjg);
        }
        public new int Select_ZZJG_JCDZB_Count(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_JCDZB_Count(strcut_zzjg);
        }
        public new int Select_ZZJG_DXZ_Count(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_DXZ_Count(strcut_zzjg);
        }
        public new void ZZJG_Add(Struct_ZZJG strcut_zzjgxx)
        {
            base.ZZJG_Add(strcut_zzjgxx);
        }
        public new void ZZJG_Edit(Struct_ZZJG strcut_zzjgxx)
        {
            base.ZZJG_Edit(strcut_zzjgxx);
        }
        
        public new void ZZJGZT_Edit(int id, string zt, string bhyy)
        {
            base.ZZJGZT_Edit(id, zt, bhyy);
        }
        public new void ZZJG_Del(int id, string p_czfs, string p_czxx)
        {
            base.ZZJG_Del(id, p_czfs, p_czxx);
        }
        public new DataTable Select_ZZJG_Detail(int  id)
        {
            return base.Select_ZZJG_Detail(id);
        }
       
        public new DataSet Select_ZZJG_TP(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_TP(strcut_zzjg);
        }
        public new int Select_ZZJG_TPRS(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_TPRS(strcut_zzjg);
        }
        public new int Select_ZZJG_TPCount(Struct_ZZJG_CX strcut_zzjg)
        {
            return base.Select_ZZJG_TPCount(strcut_zzjg);
        }
    }
}