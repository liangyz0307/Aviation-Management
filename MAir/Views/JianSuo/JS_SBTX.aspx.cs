using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG.JSuo.main
{
    public partial class JS_SBTX : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        public JS js;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
           // cpage = _usState.C_JS_ZL;
           // psize = _usState.C_JS_ZL;
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_XX;
            psize = _usState.C_YG_XX;
            js = new JS(_usState);
            if (!IsPostBack)
            {
                select_dbsx();
            }
        }
        private void select_dbsx()
        {
            DataTable dt_dh = new DataTable();
            dt_dh = js.Select_MH_DHSBYXQ().Tables[0];
            dt_dh.Columns.Add("ms");
            int count = 0;
            bool flag = false;
            foreach (DataRow dr in dt_dh.Rows)
            { 
              
                dr["ms"] = "";
                if (Convert.ToInt32(dr["dhzzyxq"]) < 30 && Convert.ToInt32(dr["dhzzyxq"]) > 0)
                {
                    flag = true;
                    dr["ms"] += "执照有效期还有" + dr["dhzzyxq"].ToString() + "天即将过期!\r\n";
                }
                if (Convert.ToInt32(dr["dhfxjyrq"]) < 30 && Convert.ToInt32(dr["dhfxjyrq"]) > 0)
                {
                    flag = true;
                    dr["ms"] += "飞行校验" + "还有" + dr["dhfxjyrq"] + "天即将过期! \r\n";
                }
                if (Convert.ToInt32(dr["dhkfxkdqr"]) < 30 && Convert.ToInt32(dr["dhkfxkdqr"]) > 0)
                {
                    flag = true;
                    dr["ms"] += "开放许可还有" + dr["dhkfxkdqr"] + "天即将过期! \r\n";
                }
                if (flag == true)
                {
                    count += 1;
                } 
            }
            DataTable dt_tx = new DataTable();
          //  dt_tx = js.Select_MH_TXSBYXQ().Tables[0];
            dt_tx.Columns.Add("ms");
            foreach (DataRow dr in dt_tx.Rows)
            {

                dr["ms"] = "";
                if (Convert.ToInt32(dr["txzzyxq"]) < 30 && Convert.ToInt32(dr["txzzyxq"]) > 0)
                {
                    flag = true;
                    dr["ms"] += "执照有效期还有" + dr["txzzyxq"].ToString() + "天即将过期!\r\n";
                }
                if (Convert.ToInt32(dr["txfxjyrq"]) < 30 && Convert.ToInt32(dr["txfxjyrq"]) > 0)
                {
                    flag = true;
                    dr["ms"] += "飞行校验" + "还有" + dr["txfxjyrq"] + "天即将过期! \r\n";
                }
                if (Convert.ToInt32(dr["txkfxkdqr"]) < 30 && Convert.ToInt32(dr["txkfxkdqr"]) > 0)
                {
                    flag = true;
                    dr["ms"] += "开放许可还有" + dr["txkfxkdqr"] + "天即将过期! \r\n";
                }
                if (flag == true)
                {
                    count += 1;
                }
            }
            DataTable dt_qx = new DataTable();
            dt_qx = js.Select_MH_QXSBYXQ().Tables[0];
            dt_qx.Columns.Add("ms");
            dt_qx.Columns.Add("txzzyxq").SetOrdinal(1); 
            dt_qx.Columns.Add("txkfxkdqr").SetOrdinal(2);
            foreach (DataRow dr in dt_qx.Rows)
            {
                dr["txzzyxq"] = dr["qxcgqjdyxq"];
                dr["txkfxkdqr"] = dr["qxcgqjdyxq"];
                dr["ms"] = "";
                if (Convert.ToInt32(dr["qxcgqjdyxq"]) < 30 && Convert.ToInt32(dr["qxcgqjdyxq"]) > 0)
                {
                    flag = true;
                    dr["ms"] += "传感器鉴定还有" + dr["qxcgqjdyxq"].ToString() + "天即将过期!\r\n";
                }
                if (flag == true)
                {
                    count += 1;
                }
            }
            //两个结构一样的DT合并
            DataTable dt_yxq = dt_dh.Clone();
            //再向新表中加入DataTable2的列结构
            //dt_yxq.Columns.Add(dt_qx.Columns[1].ColumnName);
            object[] obj = new object[dt_yxq.Columns.Count];
            for (int i = 0; i < dt_dh.Rows.Count; i++)
            {
                dt_dh.Rows[i].ItemArray.CopyTo(obj, 0);
                dt_yxq.Rows.Add(obj);
            }
            for (int i = 0; i < dt_tx.Rows.Count; i++)
            {
                dt_tx.Rows[i].ItemArray.CopyTo(obj, 0);
                dt_yxq.Rows.Add(obj);
            }
            for (int i = 0; i < dt_qx.Rows.Count; i++)
            {
                dt_qx.Rows[i].ItemArray.CopyTo(obj, 0);
                dt_yxq.Rows.Add(obj);
            }
            pg_fy.TotalRecord = count ;
            Repeater1.DataSource = dt_yxq;
            Repeater1.DataBind();

        }
    }
}