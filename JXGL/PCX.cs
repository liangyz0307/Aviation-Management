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
    public class PCX : OPCX
    {
        public PCX(UserState us) : base(us) { }
        public new DataSet Select_PCX_Pro(Struct_PCX struct_pcx)
        {
            return base.Select_PCX_Pro(struct_pcx);
        }
        public new DataSet Select_BMPCX_Pro(Struct_PCX struct_pcx)
        {
            return base.Select_BMPCX_Pro(struct_pcx);
        }
        public new int Select_PCX_Count(Struct_PCX struct_pcx)
        {
            return base.Select_PCX_Count(struct_pcx);
        }
        public new int Select_BMPCX_Count(Struct_PCX struct_pcx)
        {return base.Select_BMPCX_Count(struct_pcx);}
        public new void Insert_PCX_Pro(Struct_PCX struct_pcx)
        {
            base.Insert_PCX_Pro(struct_pcx);
        }
        public new void Insert_BMPCX(Struct_PCX struct_pcx)
        { base.Insert_BMPCX(struct_pcx); }
        public new DataSet Select_PCX_Detail(string pcxbh)
        {
            return base.Select_PCX_Detail(pcxbh);
        }
        public new DataSet Select_PCFA_Detail(string zfabh,string pcfabh,string ygbh)
        {
            return base.Select_PCFA_Detail(zfabh,pcfabh,ygbh);
        }
        public new DataSet Select_BMPCFA_Detail(string zfabh, string pcfabh, string bmdm)
        {
            return base.Select_BMPCFA_Detail(zfabh, pcfabh, bmdm);
        } 
        public new void Update_PCX_Pro(Struct_PCX struct_pcx)
        {
            base.Update_PCX_Pro(struct_pcx);
        }
        public new void Delete_PCX(string pcxbh, string p_czfs, string p_czxx)
        {
            base.Delete_PCX(pcxbh, p_czfs, p_czxx);
        }
        public new void Delete_BMPCX(string pcxbh, string p_czfs, string p_czxx)
        { base.Delete_BMPCX(pcxbh, p_czfs, p_czxx); }  
        public new void Update_PCX_ZT(Struct_PCX struct_pcx)
        {
            base.Update_PCX_ZT(struct_pcx);
        }
        public new void Update_BMPCX_ZT(Struct_PCX struct_pcx)
        {
            base.Update_BMPCX_ZT(struct_pcx);
        }
        public new DataSet Select_PCXMC()
        {return base.Select_PCXMC();}
        public new DataSet Select_BMPCXMC()
        { return base.Select_BMPCXMC(); }
    }
}
