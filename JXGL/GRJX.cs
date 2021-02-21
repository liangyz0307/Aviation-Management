using Sys;
using System.Data;

namespace CUST.MKG
{
    public class GRJX : OGRJX
    {
        public GRJX(UserState us) : base(us) { }
        public new void Insert_BMJXPCFA(string bmdm,string pcfabh)
        { base.Insert_BMJXPCFA(bmdm,pcfabh); }
        public new void Insert_GRJX_Pro(Struct_GRJX struct_grjx)
        { base.Insert_GRJX_Pro(struct_grjx); }
        public new void Insert_GRJX_PCFAZA(Struct_GRJX struct_grjx)
        { base.Insert_GRJX_PCFAZA(struct_grjx); }
            public new void Insert_GRJX_PCFA_DF(Struct_GRJX struct_grjx)
        { base.Insert_GRJX_PCFA_DF(struct_grjx); }
        public new void Insert_YG_ZFA(string ygbh,string zfabh)
        { base.Insert_YG_ZFA(ygbh,zfabh); }
        public new void Insert_BM_ZFA(string bmdm, string zfabh)
        { base.Insert_BM_ZFA(bmdm, zfabh); }
        public new void Delete_GRJX_ByID(string id, string p_czfs, string p_czxx)
        { base.Delete_GRJX_ByID(id, p_czfs, p_czxx); }
        public new void Delete_GRJX_ByYGBH(string ygbh)
        { base.Delete_GRJX_ByYGBH(ygbh); }
        public new void Delete_BMPCFA(string bmdm,string pcfabh)
        { base.Delete_BMPCFA(bmdm, pcfabh); }
        public new void Delete_BMJX_PCFA(string bmdm, string pcfabh)
        { base.Delete_BMJX_PCFA(bmdm, pcfabh); }
        public new void Delete_GRJXZF_ByYGBH(string ygbh)
        { base.Delete_GRJXZF_ByYGBH(ygbh); }
        public new void Update_GRJX_Pro(Struct_GRJX struct_grjx)
        { base.Update_GRJX_Pro(struct_grjx); }
        public new void Update_GRJX_DF(Struct_GRJX struct_grjx)
        { base.Update_GRJX_DF(struct_grjx); }
        public new void Update_GRJX_ZT(Struct_GRJX struct_grjx)
        { base.Update_GRJX_ZT(struct_grjx); }
        public new void Update_BMJX_Pro(Struct_GRJX struct_grjx)
        { base.Update_BMJX_Pro(struct_grjx); }
        public new DataSet Select_GRJX_Pro(Struct_GRJX struct_grjx)
        {return base.Select_GRJX_Pro(struct_grjx);}
        public new DataSet Select_BMJX_Pro(Struct_GRJX struct_grjx)
        { return base.Select_BMJX_Pro(struct_grjx); }
        public new int Select_GRJX_Count(Struct_GRJX struct_grjx)
        { return base.Select_GRJX_Count(struct_grjx);}
        public new int Select_BM_Count()
        { return base.Select_BM_Count(); }
        public new DataSet Select_GRJX_Detail(string id)
        {return base.Select_GRJX_Detail(id);}
        public new DataTable Select_GRJX_PCFA_DF_ByBh(string ygbh,string zfabh)
        {
            return base.Select_GRJX_PCFA_DF_ByBh(ygbh,zfabh);
        }
        public new DataTable Select_BMJX_PCFA_DF_ByBh(string bmdm, string zfabh)
        {
            return base.Select_BMJX_PCFA_DF_ByBh(bmdm, zfabh);
        }
        public new DataTable Select_GRJX_Detail_MX(Struct_GRJX grjx)
        {
            return base.Select_GRJX_Detail_MX(grjx);
        }
        public new DataTable Select_BMJX_Detail_MX(Struct_GRJX grjx)
        {
            return base.Select_BMJX_Detail_MX(grjx);
        }
        public new int Select_GRJX_Detail_MX_COUNT(string ygbh, string zfabh)
        {
            return base.Select_GRJX_Detail_MX_COUNT(ygbh, zfabh);
        }
        public new int Select_BMJX_Detail_MX_COUNT(string ygbh, string zfabh)
        {
            return base.Select_BMJX_Detail_MX_COUNT(ygbh, zfabh);
        }
        public new DataTable Select_GRJX_JBXX(string ygbh, string zfabh)
        {
            return base.Select_GRJX_JBXX(ygbh, zfabh);
        }
        public new DataTable Select_BMJX_JBXX(string bmdm, string zfabh)
        {
            return base.Select_BMJX_JBXX(bmdm, zfabh);
        }
        //查询该总方案下的评测方案
        public new DataTable Select_GRJX_PCFA_ByZFA(string zfabh)
        {
            return base.Select_GRJX_PCFA_ByZFA(zfabh);
        }
        public new DataSet Select_PCX(string pcfabh)
        {
            return base.Select_PCX(pcfabh);
        }
        public new DataSet Select_GRJXZF(Struct_GRJX struct_grjx)
        {
            return base.Select_GRJXZF(struct_grjx);
        }


        public new DataSet Select_YGXMbyBH(string p_bh)
        {
            return base.Select_YGXMbyBH(p_bh);
        }
        public new DataTable Select_YGbyBMGW(string bmdm, string gwdm)
        {
            return base.Select_YGbyBMGW(bmdm, gwdm);
        }
        public new DataSet Select_BMJXZF(Struct_GRJX struct_grjx)
        {
            return base.Select_BMJXZF(struct_grjx);
        }
        public new DataSet Select_AllYG(Struct_GRJX struct_grjx)
        {
            return base.Select_AllYG(struct_grjx);
        }
        public new DataSet Select_ZFA()
        { return base.Select_ZFA(); }

        //根据员工编号查询已有的总方案
        public new DataTable Select_YYZFA_BYBH(string ygbh,string zfabh)
        {
            return base.Select_YYZFA_BYBH(ygbh,zfabh);
        }
        
        public new DataSet Select_ZFA_PCFA(string zfabh)
        { return base.Select_ZFA_PCFA(zfabh); }
        public new DataSet Select_allBM()
        { return base.Select_allBM(); }
        public new DataSet Select_BMYYPCFA(string bmdm)
        { return base.Select_BMYYPCFA(bmdm); }
        public new DataSet Select_BMJX_Detail(string bmdm)
        { return base.Select_BMJX_Detail(bmdm); }
        public new DataSet Select_BMJX_PCFA_DF(string bmdm, string pcfabh)
        { return base.Select_BMJX_PCFA_DF(bmdm, pcfabh); }



        //展示个人绩效     
        public void Update_GRJX_ZS(string ygbh, string zfabh, string zszt)
        {
            base.Update_GRJX_ZS(ygbh, zfabh, zszt);
        }
       
        public void Insert_GRJX_ZS(string ygbh, string zfabh, string zf)
        {
            base.Insert_GRJX_ZS(ygbh, zfabh, zf);
        }
        public void Delete_GRJX_ZS(string ygbh, string zfabh, string zf)
        {
            base.Delete_GRJX_ZS(ygbh, zfabh, zf);
        }

        //展示部门绩效
        public void Update_BMJX_ZS(string bmdm, string zfabh, string zszt)
        {
            base.Update_BMJX_ZS(bmdm, zfabh, zszt);
        }
        public void Insert_BMJX_ZS(string bmdm, string zfabh, string zf)
        {
            base.Insert_BMJX_ZS(bmdm, zfabh, zf);
        }
        public void Delete_BMJX_ZS(string bmdm, string zfabh, string zf)
        {
            base.Delete_BMJX_ZS(bmdm,zfabh,zf);
        }
		  public new DataTable Select_BMJX_PCFA_ByZFA(string zfabh)
        {
            return base.Select_BMJX_PCFA_ByZFA(zfabh);
        }

        //查询展示的总方案数
        public new int Select_GRJX_ZS_Count(string ygbh)
        {
            return base.Select_GRJX_ZS_Count(ygbh);
        }
        public new DataTable Select_GRJX_ZS(string p_ygbh, int p_pagesize, int p_currentpage)
        {
            return base.Select_GRJX_ZS(p_ygbh, p_pagesize, p_currentpage);
        }
        public new int Select_BMJX_ZS_Count(string bmdm)
        {
            return base.Select_BMJX_ZS_Count(bmdm);
        }
        public new DataTable Select_BMJX_ZS(string p_bmdm, int p_pagesize, int p_currentpage)
        {
            return base.Select_BMJX_ZS(p_bmdm, p_pagesize, p_currentpage);
        }
    }
}
