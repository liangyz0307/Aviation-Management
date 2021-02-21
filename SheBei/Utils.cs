using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CUST.Sys;
using System.Data;

namespace CUST.MKG
{
   public  class Utils
    {
        public string Creat_Shebei_number(DataTable dt,string tcrq, string sblx)
        {
            lock (this)
            {
                string sbbh = sblx+tcrq;
                if (dt.Rows[0][0].ToString() == "")
                {
                    sbbh = sbbh + "01";
                }
                else
                {
                    sbbh = (Convert.ToInt64(dt.Rows[0][0].ToString()) + 1).ToString();
                    if (sbbh.Length == 9)
                    {
                        sbbh = "0" + sbbh;
                    }
                }
                return sbbh;
            }
        }
        #region 下载

        #endregion
    }
}
