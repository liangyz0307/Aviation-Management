using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
     public   class JS:OJS
    {
        public JS(UserState ygstate) : base(ygstate) { }
        #region
        public new  DataSet Select_BS_BXD(Struct_JS struct_js)
        {

            return base.Select_BS_BXD(struct_js);
        }

        public new DataSet Select_BS_DZQM(Struct_JS struct_js)
        {

            return base.Select_BS_DZQM(struct_js);
        }

        public new DataSet Select_BS_FXY(Struct_JS struct_js)
        {

            return base.Select_BS_FXY(struct_js);
        }

        public new DataSet Select_BS_GDZC(Struct_JS struct_js)
        {

            return base.Select_BS_GDZC(struct_js);
        }

        public new DataSet Select_BS_GZJZ(Struct_JS struct_js)
        {

            return base.Select_BS_GZJZ(struct_js);
        }

        public new DataSet Select_BS_HBYXXX(Struct_JS struct_js)
        {

            return base.Select_BS_HBYXXX(struct_js);
        }

        public new DataSet Select_BS_SG(Struct_JS struct_js)
        {

            return base.Select_BS_SG(struct_js);
        }

        public new DataSet Select_BS_TQCZ(Struct_JS struct_js)
        {

            return base.Select_BS_TQCZ(struct_js);
        }

        public new DataSet Select_BS_YS(Struct_JS struct_js)
        {

            return base.Select_BS_YS(struct_js);
        }
        public new DataSet Select_BS_ZBAP(Struct_JS struct_js)
        {

            return base.Select_BS_ZBAP(struct_js);
        }
        public new DataSet Select_BS_ZDGZ(Struct_JS struct_js)
        {

            return base.Select_BS_ZDGZ(struct_js);
        }
        public new DataSet Select_BS_ZYBS(Struct_JS struct_js)
        {

            return base.Select_BS_ZYBS(struct_js);
        }


        public new int Select_BS_ZYBS_Count(Struct_JS struct_js)
        {

            return base.Select_BS_ZYBS_Count(struct_js);
        }

        public new int Select_BS_ZDGZ_Count(Struct_JS struct_js)
        {

            return base.Select_BS_ZDGZ_Count(struct_js);
        }

        public new int Select_BS_ZBAP_Count(Struct_JS struct_js)
        {

            return base.Select_BS_ZBAP_Count(struct_js);
        }

        public new int Select_BS_YS_Count(Struct_JS struct_js)
        {

            return base.Select_BS_YS_Count(struct_js);
        }

        public new int Select_BS_TQCZ_Count(Struct_JS struct_js)
        {

            return base.Select_BS_TQCZ_Count(struct_js);
        }

        public new int Select_BS_SG_Count(Struct_JS struct_js)
        {

            return base.Select_BS_SG_Count(struct_js);
        }

        public new int Select_BS_HBYXXX_Count(Struct_JS struct_js)
        {

            return base.Select_BS_HBYXXX_Count(struct_js);
        }

        public new int Select_BS_GZJZ_Count(Struct_JS struct_js)
        {

            return base.Select_BS_GZJZ_Count(struct_js);
        }

        public new int Select_BS_GDZC_Count(Struct_JS struct_js)
        {

            return base.Select_BS_GDZC_Count(struct_js);
        }
        public new int Select_BS_FXY_Count(Struct_JS struct_js)
        {

            return base.Select_BS_FXY_Count(struct_js);
        }
        public new int Select_BS_DZQM_Count(Struct_JS struct_js)
        {

            return base.Select_BS_DZQM_Count(struct_js);
        }
        public new int Select_BS_BXD_Count(Struct_JS struct_js)
        {

            return base.Select_BS_BXD_Count(struct_js);
        }



        public new DataSet Select_BS_BXD_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_BXD_Detail(struct_js);
        }

        public new DataSet Select_BS_DZQM_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_DZQM_Detail(struct_js);
        }

        public new DataSet Select_BS_FXY_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_FXY_Detail(struct_js);
        }

        public new DataSet Select_BS_GDZC_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_GDZC_Detail(struct_js);
        }

        public new DataSet Select_BS_GZJZ_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_GZJZ_Detail(struct_js);
        }

        public new DataSet Select_BS_HBYXXX_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_HBYXXX_Detail(struct_js);
        }

        public new DataSet Select_BS_SG_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_SG_Detail(struct_js);
        }

        public new DataSet Select_BS_TQCZ_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_TQCZ_Detail(struct_js);
        }

        public new DataSet Select_BS_YS_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_YS_Detail(struct_js);
        }
        public new DataSet Select_BS_ZBAP_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_ZBAP_Detail(struct_js);
        }
        public new DataSet Select_BS_ZDGZ_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_ZDGZ_Detail(struct_js);
        }
        public new DataSet Select_BS_ZYBS_Detail(Struct_JS struct_js)
        {

            return base.Select_BS_ZYBS_Detail(struct_js);
        }

        #endregion
        #region
        //设备检索
        public new DataSet Select_JS_DHSB(Struct_JS_DHSB struct_js_dhsb)
        {
            return base.Select_JS_DHSB(struct_js_dhsb);
        }
        public new DataSet Select_JS_YBSB(Struct_JS_YBSB struct_js_ybsb)
        {
            return base.Select_JS_YBSB(struct_js_ybsb);
        }
        public new DataSet Select_JS_TXSB(Struct_JS_TXSB struct_js_txsb)
        {
            return base.Select_JS_TXSB(struct_js_txsb);
        }
        public new DataSet Select_JS_QXSB(Struct_JS_QXSB struct_js_qxsb)
        {
            return base.Select_JS_QXSB(struct_js_qxsb);
        }

        public new int Select_JS_DHSBCount(Struct_JS_DHSB struct_js_dhsb)
        {

            return base.Select_JS_DHSBCount(struct_js_dhsb);
        }
        public new int Select_JS_YBSBCount(Struct_JS_YBSB struct_js_ybsb)
        {
            return base.Select_JS_YBSBCount(struct_js_ybsb);
        }
        public new int Select_JS_TXSBCount(Struct_JS_TXSB struct_js_txsb)
        {

            return base.Select_JS_TXSBCount(struct_js_txsb);
        }

        public new int Select_JS_QXSBCount(Struct_JS_QXSB struct_js_qxsb)
        {

            return base.Select_JS_QXSBCount(struct_js_qxsb);
        }

        public new DataSet Select_JS_DHSBDetail(Struct_JS_DHSB struct_js_dhsb)
        {
            return base.Select_JS_DHSBDetail(struct_js_dhsb);
        }
        public new DataSet Select_JS_YBSBDetail(Struct_JS_YBSB struct_js_ybsb)
        {
            return base.Select_JS_YBSBDetail(struct_js_ybsb);
        }
        public new DataSet Select_JS_TXSBDetail(Struct_JS_TXSB struct_js_txsb)
        {
            return base.Select_JS_TXSBDetail(struct_js_txsb);
        }

        public new DataSet Select_JS_QXSBDetail(Struct_JS_QXSB struct_js_qxsb)
        {
            return base.Select_JS_QXSBDetail(struct_js_qxsb);
        }
        #endregion
        #region 员工
        public new DataSet Select_JS_YGXX(Struct_JS_YG struct_js_yg)
        {
            return base.Select_JS_YGXX(struct_js_yg);
        }
        public new int Select_JS_YGCount(Struct_JS_YG struct_js_yg)
        {
            return base.Select_JS_YGCount(struct_js_yg);
        }
        public new DataSet Select_JS_YGLLDetail(Struct_JS_YG struct_js_yg)
        {
           return  base.Select_JS_YGLLDetail(struct_js_yg);
        }
        public new DataSet Select_JS_YGZZDetail(Struct_JS_YG struct_js_yg)
        {
            return base.Select_JS_YGZZDetail(struct_js_yg);
        }
        //新的
        public new DataSet Select_JS_YGDetail(Struct_JS_YG struct_js_yg)
        {
            return base.Select_JS_YGDetail(struct_js_yg);
        }
        //新的
        public new DataSet Select_YGLL_Detail(Struct_JS_YG struct_js_yg)
        {
            return base.Select_YGLL_Detail(struct_js_yg);
        }
        //新的
        public new DataSet Select_YGZZ_Detail(Struct_JS_YG struct_js_yg)
        {
            return base.Select_YGZZ_Detail(struct_js_yg);
        }
        public new DataSet Select_YXQ(string id)
        {
            return base.Select_YXQ(id);        
        }
        #endregion
        //后台检索
        #region
        public new DataSet Select_JS_HTXX(Struct_JS_HTBM struct_js_htbm)
        {
            return base.Select_JS_HTXX(struct_js_htbm);
        }
        public new DataSet Select_JS_HTXXDetail(Struct_JS_HTBM struct_js_htbm)
        {
            return base.Select_JS_HTXXDetail(struct_js_htbm);
        }

        public new int Select_JS_HTXXCount(Struct_JS_HTBM struct_js_htbm)
        {
            return base.Select_JS_HTXXCount(struct_js_htbm);
        }
        #endregion
        #region  备件
        public new DataSet Select_JS_BJDetail(Struct_JSBJ struct_bj)
        {
            return base.Select_JS_BJDetail(struct_bj);
        }
        public new DataSet Select_JS_BJCKDetail(Struct_JSBJ struct_bj)
        {
            return base.Select_JS_BJCKDetail(struct_bj);
        }
        public new DataSet Select_JS_BJRKDetail(Struct_JSBJ struct_bj)
        {
            return base.Select_JS_BJRKDetail(struct_bj);
        }
        public new DataSet Select_JS_BJXX(Struct_JSBJ struct_bj)
        {
            return base.Select_JS_BJXX(struct_bj);
        }
        public new int Select_JS_BJ(Struct_JSBJ struct_bj)
        {
            return base.Select_JS_BJ(struct_bj);
        }
        #endregion
        #region
        public new DataSet Select_JS_DBSX(string ygbh)
        {
            return base.Select_JS_DBSX(ygbh);
        }

        public new DataSet Select_JS_YGZZYXQ(string id)
        {
            return base.Select_JS_YGZZYXQ(id);
        }
        public new DataSet Select_JS_YGID(string ygbh)
        {
            return base.Select_JS_YGID(ygbh);
        }


        public new DataSet Select_JS_GG(string bmdm)
        {
            return base.Select_JS_GG(bmdm);
        }

        public new DataSet Select_JS_GGDetail(int id)
        {
            return base.Select_JS_GGDetail(id);
        }
        #endregion

        #region
        public new DataSet Select_JS_TZXX(Struct_JS_TZ struct_js_tz)
        {
            return base.Select_JS_TZXX(struct_js_tz);
        }
        public new int Select_JS_TZXXCount(Struct_JS_TZ struct_js_tz)
        {
            return base.Select_JS_TZXXCount(struct_js_tz);
        }
        public new DataSet Select_JS_TZXXDetail(Struct_JS_TZ struct_js_tz)
        {
            return base.Select_JS_TZXXDetail(struct_js_tz);
        }
        #endregion

        public new DataSet Select_JS_YGDA(Struct_JS_YG struct_js_yg)
        {
            return base.Select_JS_YGDA(struct_js_yg);
        }

         public new DataSet Select_JS_YGLL(string ygbh)
        {
            return base.Select_JS_YGLL(ygbh);
        }
        public new DataSet Select_JS_YGZZ(string ygbh)
        {
            return base.Select_JS_YGZZ(ygbh);
        }
        public new DataSet Select_JS_ZL(string scyh)
        {
            return base.Select_JS_ZL(scyh);
        }
        public new DataSet Select_JS_ZYBS(string bsyg)
        {
            return base.Select_JS_ZYBS(bsyg);
        }

        public new DataSet Select_JS_GGrl(string time)
        {
            return base.Select_JS_GGrl(time);
        }
        public new DataSet Select_JS_YGrl()
        {
            return base.Select_JS_YGrl();
        }
        public new DataSet Select_JS_SBrl(string time)
        {
            return base.Select_JS_SBrl(time);
        }
        public new DataSet Select_JS_KJRK(string ygbh)
        {
            return base.Select_JS_KJRK(ygbh);
        }
        public new DataSet Select_JS_WFPKJRK(string ygbh)
        {
            return base.Select_JS_WFPKJRK(ygbh);
        }
        public new void Insert_FPKJRK(string ygbh, string ymdm)
        {
             base.Insert_FPKJRK(ygbh,ymdm);
        }
        public new void Delete_FPKJRK(string ygbh, string ymdm)
        {
            base.Delete_FPKJRK(ygbh, ymdm);
        }
        
        public new DataSet Select_FPKJRK(string ygbh)
        {
            return base.Select_FPKJRK(ygbh);
        }

        public new DataSet Select_JS_ZLXX(Struct_JSZL struct_jszl)
        {
            return base.Select_JS_ZLXX(struct_jszl);
        }
        public new DataSet Select_JS_ALXX(Struct_JSALK struct_jsalk)
        {
            return base.Select_JS_ALXX(struct_jsalk);
        }

        public new DataSet Select_JS_ZLDetail(Struct_JSZL struct_jszl)
        {
            return base.Select_JS_ZLDetail(struct_jszl);
        }
        public new DataSet Select_JS_ALDetail(Struct_JSALK struct_jsalk)
        {
            return base.Select_JS_ALDetail(struct_jsalk);
        }

        public new int Select_JS_ZLCount(Struct_JSZL struct_jszl)
        {
            return base.Select_JS_ZLCount(struct_jszl);
        }
        public new int Select_JS_ALCount(Struct_JSALK struct_jsalk)
        {
            return base.Select_JS_ALCount(struct_jsalk);
        }
  
        public new DataSet Select_MH_DHSBYXQ()
        {
            return base.Select_MH_DHSBYXQ();
        }

        public new DataSet Select_MH_TXSBYXQ(string ygbh)
        {
            return base.Select_MH_TXSBYXQ(ygbh);
        }

        public new DataSet Select_MH_QXSBYXQ()
        {
            return base.Select_MH_QXSBYXQ();
        }
        public new DataSet Select_MH_YBSBYXQ()
        {
            return base.Select_MH_YBSBYXQ();
        }
    }
}
