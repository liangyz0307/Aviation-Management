using Sys;
using System.Data;

namespace CUST.MKG
{
    public class PCFA : OPCFA
    {
        public PCFA(UserState us) : base(us) { }
        public new void Insert_PCFA_Pro(Struct_PCFA_Pro struct_pcfa_pro)
        {
            base.Insert_PCFA_Pro(struct_pcfa_pro);
        }
        public new void Insert_BMPCFA_Pro(Struct_PCFA_Pro struct_pcfa_pro)
        {
            base.Insert_BMPCFA_Pro(struct_pcfa_pro);
        }
        public new void Insert_BMZFA(Struct_PCFA struct_pcfa)
        { base.Insert_BMZFA(struct_pcfa); }
        public new void Delete_PCFA_ByPCFABH(string pcfabh)
        {
            base.Delete_PCFA_ByPCFABH(pcfabh);
        }
        public new void Delete_BMPCFA_ByPCFABH(string pcfabh, string p_czfs, string p_czxx)
        {
            base.Delete_BMPCFA_ByPCFABH(pcfabh, p_czfs, p_czxx);
        }
        public new void Delete_PCFA_ByID(int id, string p_czfs, string p_czxx)
        {
            base.Delete_PCFA_ByID(id, p_czfs, p_czxx);
        }
        public new void Delete_ZFA_ByZFABH(string zfabh)
        {
            base.Delete_ZFA_ByZFABH(zfabh);
        }
        public new void Delete_BMZFA_ByZFABH(string zfabh)
        {
            base.Delete_BMZFA_ByZFABH(zfabh);
        }
        public new void Update_PCFA_Pro(Struct_PCFA struct_pcfa)
        {
            base.Update_PCFA_Pro(struct_pcfa);
        }
        public new void Update_PCFA_ZT(Struct_PCFA struct_pcfa)
        {
            base.Update_PCFA_ZT(struct_pcfa);
        }
        public new void Update_BMPCFA_ZT(Struct_PCFA struct_pcfa)
        {base.Update_BMPCFA_ZT(struct_pcfa);}
        public new DataSet Select_PCFA_Pro(Struct_PCFA struct_pcfa)
        {
            return base.Select_PCFA_Pro(struct_pcfa);
        }
        public new DataSet Select_BMPCFA_Pro(Struct_PCFA struct_pcfa)
        {
            return base.Select_BMPCFA_Pro(struct_pcfa);
        }
        public new DataTable Select_BMJX_PCFA_ByZFA(string zfabh)
        {
            return base.Select_BMJX_PCFA_ByZFA(zfabh);
        }
        public new int Select_PCFA_Count(Struct_PCFA struct_pcfa)
        {
            return base.Select_PCFA_Count(struct_pcfa);
        }
        public new int Select_ZFA_Count(Struct_PCFA struct_pcfa)
        {
            return base.Select_ZFA_Count(struct_pcfa);
        }
        public new int Select_BMZFA_Count(Struct_PCFA struct_pcfa)
        {
            return base.Select_BMZFA_Count(struct_pcfa);
        }
        public new int Select_BMPCFA_Count(Struct_PCFA struct_pcfa)
        {
            return base.Select_BMPCFA_Count(struct_pcfa);
        }
        public new DataTable Select_ALL_BM_PCFA()
        {
            return base.Select_ALL_BM_PCFA();
        }
        public new DataSet SELECT_PCFA_BYPCFABH(string pcfabh)
        {
            return base.SELECT_PCFA_BYPCFABH(pcfabh);
        }
        public new DataSet Select_BMZFA_PCFA(string zfabh)
        {
            return base.Select_BMZFA_PCFA(zfabh);
        }
        public new DataSet Select_BMZFA_BYBH(string bmdm)
        {
            return base.Select_BMZFA_BYBH(bmdm);
        }
        public new DataSet SELECT_BMFA_BYPCFABH(string pcfabh)
        {
            return base.SELECT_BMFA_BYPCFABH(pcfabh);
        }
        public new DataSet Select_PCFA()
        {
            return base.Select_PCFA();
        }
        public new DataSet Select_BMPCFA()
        {
            return base.Select_BMPCFA();
        }
        public new DataSet Select_ZFA(Struct_PCFA struct_pcfa)
        {
            return base.Select_ZFA(struct_pcfa);
        }
        public new DataSet Select_BMZFA(Struct_PCFA struct_pcfa)
        {
            return base.Select_BMZFA(struct_pcfa);
        } 
        public new DataTable Select_PCFA_PCX_ID_DeleteByID(int id)
        {
            return base.Select_PCFA_PCX_ID_DeleteByID(id);
        }
        public new DataTable Select_YGYYZFA(string ygbh)
        {
            return base.Select_YGYYZFA(ygbh);
        }
    }
}
