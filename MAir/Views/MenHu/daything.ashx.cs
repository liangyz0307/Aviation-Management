using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.SessionState;
using CUST.MKG;
using CUST.Sys;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Globalization;
using Sys;

namespace WebApplication1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class daything : IHttpHandler, IRequiresSessionState
    {
        private UserState yg;
        public JS js;
       // private Struct_YGRL struct_YGRL=new Struct_YGRL ();
        //private Yuangongrili js;
        private HttpContext _context;
        public void ProcessRequest(HttpContext context)
        {   //获取GET方法传递参数：Request.QueryString["参数名称"];
            //获取POST方法传递参数：Request.Form["参数名称"];
            //本例使用的POST方法
            this._context = context;
            if ((yg = (context.Session["UserState"] as UserState)) == null)
            {
                context.Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                context.Response.End();
                return;
            }
            context.Response.ContentType = "application/json"; //指定返回数据格式为json
            js = new JS(yg);
            // js = new Yuangongrili(yg);
            string time = context.Request.Form["time"];
            string year = context.Request.Form["year"];
            string done = context.Request.Form["done"];
            string thisDay = context.Request.Form["thisDay"];
            string title = context.Request.Form["title"];
            switch (done) {
                case "show":
                    {
                        day_do(time ,year);
                        break;
                    }
                case "add":
                    {
                        day_add(time,  thisDay,  title);
                        break;
                    }
                case "delete":
                    {
                        day_delete(time, thisDay, title);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private static DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable dt = rows[0].Table.Clone(); // 复制DataRow的表结构
            foreach (DataRow row in rows)
            {

                dt.ImportRow(row); // 将DataRow添加到DataTable中
            }
            return dt;
        }
        private DataTable CreateDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("rqlx", typeof(string));
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("context", typeof(string));
            dt.Columns.Add("day", typeof(string));
            dt.Columns.Add("time", typeof(string));
            dt.Columns.Add("oneday", typeof(string));
            return dt;
        }
        private DataTable get(string month ,string year)
        {
            DataTable dt = CreateDt();
            DataSet ds = new DataSet();
            DataSet ds_sb = new DataSet();
            if (month.Length == 1)
            {
                ds = js.Select_JS_GGrl(year + "0" + month);
                ds_sb = js.Select_JS_SBrl(year + "-0" + month);
            }
            else
            {
                ds = js.Select_JS_GGrl(year+month);
                ds_sb = js.Select_JS_SBrl(year + month);
            }
            DataTable dt_gg = ds.Tables[0];
            DataTable dt_zz = ds.Tables[1];
            DataTable dt_yd = ds.Tables[2];
            DataTable dt_yy = ds.Tables[3];
            DataTable dt_tj = ds.Tables[4];
            for (int i=0;i<dt_gg.Rows.Count;i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = dt_gg.Rows[i]["lx"].ToString();
                dr["title"] = dt_gg.Rows[i]["bt"].ToString();
                dr["context"] = dt_gg.Rows[i]["lr"].ToString();
                dr["day"] = Convert.ToDateTime(dt_gg.Rows[i]["fbsj"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_gg.Rows[i]["fbsj"].ToString()).ToShortTimeString();
                dr["oneday"] = Convert.ToDateTime(dt_gg.Rows[i]["fbsj"].ToString()).ToShortDateString().Split('/')[2];
            }
            for (int i = 0; i < dt_tj.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "体检等级";
                dr["title"] = SysData.TJDJBByKey(dt_tj.Rows[i]["tjdj"].ToString()).mc;
                dr["context"] = "";
                dr["day"] = Convert.ToDateTime(dt_tj.Rows[i]["tjyxq"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_tj.Rows[i]["tjyxq"].ToString()).ToShortTimeString();
                dr["oneday"] = Convert.ToDateTime(dt_tj.Rows[i]["tjyxq"].ToString()).ToShortDateString().Split('/')[2];
            }
            for (int i = 0; i < dt_yy.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "英语等级";
                dr["title"] = SysData.YYDJLBByKey(dt_yy.Rows[i]["yydj"].ToString()).mc;
                dr["context"] = "";
                dr["day"] = Convert.ToDateTime(dt_yy.Rows[i]["yyyxq"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_yy.Rows[i]["yyyxq"].ToString()).ToShortTimeString();
                dr["oneday"] = Convert.ToDateTime(dt_yy.Rows[i]["yyyxq"].ToString()).ToShortDateString().Split('/')[2];
            }
            for (int i = 0; i < dt_yd.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "异地签注";
                dr["title"] = SysData.YDQZLBByKey(dt_yd.Rows[i]["ydqzlb"].ToString()).mc;
                dr["context"] = dt_yd.Rows[i]["ydqz"].ToString();
                dr["day"] = Convert.ToDateTime(dt_yd.Rows[i]["ydqzyxq"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_yd.Rows[i]["ydqzyxq"].ToString()).ToShortTimeString();
                dr["oneday"] = Convert.ToDateTime(dt_yd.Rows[i]["ydqzyxq"].ToString()).ToShortDateString().Split('/')[2];
            }
            for (int i = 0; i < dt_zz.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "执照签注";
                dr["title"] = SysData.ZZQZLBDMByKey(dt_zz.Rows[i]["zzqzlb"].ToString()).mc;
                dr["context"] = "执照文件号："+dt_zz.Rows[i]["zzwjhm"].ToString()+",执照编号："+ dt_zz.Rows[i]["zzbh"].ToString();
                dr["day"] = Convert.ToDateTime(dt_zz.Rows[i]["zclbyxq"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_zz.Rows[i]["zclbyxq"].ToString()).ToShortTimeString();
                dr["oneday"] = Convert.ToDateTime(dt_zz.Rows[i]["zclbyxq"].ToString()).ToShortDateString().Split('/')[2];
            }
           
            DataTable dt_dhzz = ds_sb.Tables[0];
            for (int i = 0; i < dt_dhzz.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "无线电设备发射核准证";
                dr["context"] = "设备编号：" + dt_dhzz.Rows[i]["sbbh"].ToString() + ",设备种类：" + SysData.SBZLByKey(dt_dhzz.Rows[i]["sbzl"].ToString()).mc;
                dr["title"] = "核准证编号：" + dt_dhzz.Rows[i]["WXDSBFSHZZBH"].ToString(); ;
                dr["day"] = Convert.ToDateTime(dt_dhzz.Rows[i]["ZZYXQ"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_dhzz.Rows[i]["ZZYXQ"].ToString()).ToShortTimeString();
                dr["oneday"] = dt_dhzz.Rows[i]["ZZYXQ"].ToString().Split('-')[2];
            }
            DataTable dt_dhfx = ds_sb.Tables[1];
            for (int i = 0; i < dt_dhfx.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "导航设备飞行校验";
                dr["context"] = "开放许可到期日："+ dt_dhfx.Rows[i]["KFXKDQR"].ToString()+
                                ",飞行校检周期："+ dt_dhfx.Rows[i]["FXJYZQZT"].ToString()+
                                ",设备编号：" + dt_dhfx.Rows[i]["sbbh"].ToString()+ 
                                ",设备种类：" + SysData.SBZLByKey(dt_dhfx.Rows[i]["sbzl"].ToString()).mc;
                dr["title"] = "校检结果："+SysData.FXXJByKey(dt_dhfx.Rows[i]["FXJY"].ToString()).mc;
                dr["day"] = Convert.ToDateTime(dt_dhfx.Rows[i]["FXJYRQ"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_dhfx.Rows[i]["FXJYRQ"].ToString()).ToShortTimeString();
                dr["oneday"] = dt_dhfx.Rows[i]["FXJYRQ"].ToString().Split('-')[2];
            }
            DataTable dt_txzz = ds_sb.Tables[2];
            for (int i = 0; i < dt_txzz.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "无线电设备发射核准证";
                dr["context"] = "设备编号：" + dt_txzz.Rows[i]["sbbh"].ToString() + ",设备种类：" + SysData.SBZLByKey(dt_txzz.Rows[i]["sbzl"].ToString()).mc;
                dr["title"] = "核准证编号：" + dt_txzz.Rows[i]["WXDSBFSHZZBH"].ToString();
                dr["day"] = Convert.ToDateTime(dt_txzz.Rows[i]["ZZYXQ"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_txzz.Rows[i]["ZZYXQ"].ToString()).ToShortTimeString();
                dr["oneday"] = dt_txzz.Rows[i]["ZZYXQ"].ToString().Split('-')[2];
            }
            DataTable dt_txfx = ds_sb.Tables[3];
            for (int i = 0; i < dt_txfx.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "通信设备飞行校验";
                dr["context"] = "开放许可到期日：" + dt_txfx.Rows[i]["KFXKDQR"].ToString() +
                                ",飞行校检周期：" + dt_txfx.Rows[i]["FXJYZQZT"].ToString() + 
                                ",设备编号：" + dt_txfx.Rows[i]["sbbh"].ToString() + 
                                ",设备种类：" + SysData.SBZLByKey(dt_txfx.Rows[i]["sbzl"].ToString()).mc;
                dr["title"] = "校检结果：" + SysData.FXXJByKey(dt_txfx.Rows[i]["FXJY"].ToString()).mc;
                dr["day"] = Convert.ToDateTime(dt_txfx.Rows[i]["FXJYRQ"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_txfx.Rows[i]["FXJYRQ"].ToString()).ToShortTimeString();
                dr["oneday"] = dt_txfx.Rows[i]["FXJYRQ"].ToString().Split('-')[2];
            }
            DataTable dt_qxcgq = ds_sb.Tables[4];
            for (int i = 0; i < dt_qxcgq.Rows.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["rqlx"] = "传感器检定证书";
                dr["context"] = "设备编号：" + dt_qxcgq.Rows[i]["sbbh"].ToString() + ",设备种类：" + SysData.SBZLByKey(dt_qxcgq.Rows[i]["sbzl"].ToString()).mc;
                dr["title"] = "传感器检定证书编号：" + dt_qxcgq.Rows[i]["CGQJDZSBH"].ToString();
                dr["day"] = Convert.ToDateTime(dt_qxcgq.Rows[i]["CGQJDYXQ"].ToString()).ToShortDateString();
                dr["time"] = Convert.ToDateTime(dt_qxcgq.Rows[i]["CGQJDYXQ"].ToString()).ToShortTimeString();
                dr["oneday"] = dt_qxcgq.Rows[i]["CGQJDYXQ"].ToString().Split('-')[2];
            }
            return dt;
         }
        private void day_do(string time , string year)
        {
            DataTable dt = new DataTable();// get(time, year).Copy();
            string s = DTtoJSON(dt);
            string jsonResult = "";
            try
            {
                jsonResult = "{\"Data\":"+s+ "}";
            }
            catch
            {
                jsonResult = "{\"Data\":[{\"status\":\"false\"}]}";
            }
            _context.Response.Write(jsonResult);//向客户端返回数据
            _context.Response.End();
           
        }
        public void day_add(string time ,string thisDay ,string title)
        {
            string jsonResult = "";
            try
            {
                
                jsonResult = "{\"Data\":[{\"status\":\"true\"}]}";
            }
            catch
            {
                jsonResult = "{\"Data\":[{\"status\":\"false\"}]}";
            }
            _context.Response.Write(jsonResult);//向客户端返回数据
            _context.Response.End();
        }
        public void day_delete(string time, string thisDay, string title)
        {
            string jsonResult = "";
            try
            {
               
                jsonResult = "{\"Data\":[{\"status\":\"true\"}]}";
            }
            catch
            {
                jsonResult = "{\"Data\":[{\"status\":\"false\"}]}";
            }
            _context.Response.Write(jsonResult);//向客户端返回数据
            _context.Response.End();
        }
        public static string DTtoJSON(DataTable dt)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    drow.Add(col.ColumnName, row[col.ColumnName]);
                }
                dic.Add(drow);
            }
            return jss.Serialize(dic);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
