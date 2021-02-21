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
    public partial class JS_ZZTX : System.Web.UI.Page
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
            cpage = _usState.C_YG_XX;
            psize = _usState.C_YG_XX;
            js = new JS(_usState);
            if (!IsPostBack)
            {
                select_zzyxq();
            }
        }
        private void select_zzyxq()
        {
            DataTable dt_id = new DataTable();
            DataTable dt_yxq = new DataTable();
            string ygbh = _usState.userLoginName;
            dt_id = js.Select_JS_YGID(ygbh).Tables[0];
            for (int i = 0; i < dt_id.Rows.Count; i++)
            {
                string id = dt_id.Rows[i]["id"].ToString();
                dt_yxq = js.Select_JS_YGZZYXQ(id).Tables[0];
                int count = 0;
                bool flag = false;
                dt_yxq.Columns.Add("ms");
                dt_yxq.Columns.Add("ygbh");
                foreach (DataRow dr in dt_yxq.Rows)
                {
                    dr["ygbh"] = "";
                    dr["ms"] = "";
                    if (Convert.ToInt32(dr["yydjyxq"]) < 30 && Convert.ToInt32(dr["yydjyxq"]) > 0)
                    {
                        flag = true;
                        dr["ms"] += SysData.YYDJLBByKey(dr["yydj"].ToString()).mc + "还有" + dr["yydjyxq"] + "天即将过期!\r\n";//将数据库表中值赋给新的变量 
                    }
                    if (Convert.ToInt32(dr["tjdjyxq"]) < 30 && Convert.ToInt32(dr["tjdjyxq"]) > 0)
                    {
                        flag = true;
                        dr["ms"] += SysData.TJDJBByKey(dr["tjdj"].ToString()).mc + "还有" + dr["tjdjyxq"] + "天即将过期!\r\n";
                    }
                    if (Convert.ToInt32(dr["ydqzyxq"]) < 30 && Convert.ToInt32(dr["ydqzyxq"]) > 0)
                    {
                        flag = true;
                        dr["ms"] += SysData.YDQZLBByKey(dr["ydqzlb"].ToString()).mc + "异地签注还有" + dr["ydqzyxq"] + "天即将过期! \r\n";
                    }
                    if (Convert.ToInt32(dr["zclbyxq"]) < 30 && Convert.ToInt32(dr["zclbyxq"]) > 0)
                    {
                        flag = true;
                        dr["ms"] += SysData.ZZQZLBByKey(dr["zzqzlb"].ToString()).mc + "有效期还有" + dr["zclbyxq"] + "天即将过期,\r\n";
                    }
                    if (flag == true)
                    {
                        dr["ygbh"] = _usState.userLoginName;
                        count += 1;
                    }
                }
               

                pg_fy.TotalRecord = count;
                Repeater1.DataSource = dt_yxq;
                Repeater1.DataBind();
            }
        }
    }
}