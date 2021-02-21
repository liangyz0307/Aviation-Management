using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CUST.Sys;
using Sys;

namespace CUST.MKG
{
    public class BSTJ:OBSTJ
    {
        public BSTJ(UserState us) : base(us) { }
        public new DataTable Select_TQCZQK_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            return base.Select_TQCZQK_byBSLX(kssj, jssj, bslx);
        }
        public new DataTable Select_ZDGZ_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            return base.Select_ZDGZ_byBSLX(kssj, jssj, bslx);
        }
        public new DataTable Select_GZJZ_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            return base.Select_GZJZ_byBSLX(kssj, jssj, bslx);
        }
        public new int Select_HBYXJC_CountZC(DateTime kssj, DateTime jssj)
        {
            return base.Select_HBYXJC_CountZC(kssj, jssj);
        }
        public new int Select_HBYXJC_CountYC(DateTime kssj, DateTime jssj)
        {
            return base.Select_HBYXJC_CountYC(kssj, jssj);
        }
        public new DataTable Select_HBYXYCYYandQXQK(DateTime kssj, DateTime jssj)
        {
            return base.Select_HBYXYCYYandQXQK(kssj, jssj);
        }
        public new DataTable Select_BSRQMax(DateTime kssj, DateTime jssj)
        {
            return base.Select_BSRQMax(kssj, jssj);
        }
        public new DataTable Select_FXY_byBSLX(DateTime kssj, DateTime jssj, string bslx)
        {
            return base.Select_FXY_byBSLX(kssj, jssj, bslx);
        }
        public new DataTable Select_QXSBBZQK(DateTime kssj, DateTime jssj)
        {
            return base.Select_QXSBBZQK(kssj, jssj);
        }
        public new DataTable Select_DHSBBZQK(DateTime kssj, DateTime jssj)
        {
            return base.Select_DHSBBZQK(kssj, jssj);
        }
        public new DataTable Select_TXSBBZQK(DateTime kssj, DateTime jssj)
        {
            return base.Select_TXSBBZQK(kssj, jssj);
        }
    }
}
