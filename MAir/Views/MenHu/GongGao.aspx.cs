using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//用li显示查询出的数据，所需要引用
using System.Text;
using CUST.MKG;
using System.Text.RegularExpressions;
using Sys;

namespace CUST.Web.MengHu.main
{

    public partial class GongGao : System.Web.UI.Page
    {
        private JS js;
        private UserState userstate;
        private YH yh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new JS(userstate);
            yh = new YH(userstate);
            if (!IsPostBack)
            {
                Show_gg();
            }
        }
        
        private void Show_gg()
        {
            string time = "";
            DateTime fbsj;
            StringBuilder str = new StringBuilder();
            string bt = "";
            StringBuilder sj = new StringBuilder();
            string bmdm = userstate.userBMDM;
            DataTable dt_gg = new DataTable();
            dt_gg = js.Select_JS_GG(bmdm).Tables[0];

            if (dt_gg != null && dt_gg.Rows.Count > 0)     //判断是否有数据  
            {
                for (int j = 0; j < dt_gg.Rows.Count; j++)
                {
                    str.Append("<ul>");
                    if (Convert.ToInt32(dt_gg.Rows[j]["fbsjzx"]) < 3 && Convert.ToInt32(dt_gg.Rows[j]["fbsjzx"]) >0)
                    {
                        //创建一个实例 //查询的内容，将表内容赋给dt 
                        bt = dt_gg.Rows[j]["bt"].ToString() + "<img id=\"img\" src=\"../../Content/images/new.gif\" style=\"color:#ff0000;fontsize:5px;\" />";
                        fbsj = DateTime.Parse(dt_gg.Rows[0]["fbsj"].ToString());
                        time = fbsj.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        bt = dt_gg.Rows[j]["bt"].ToString();
                        fbsj = DateTime.Parse(dt_gg.Rows[0]["fbsj"].ToString());
                        time = fbsj.ToString("yyyy-MM-dd");
                    }
                    str.Append("<li  style=\"border-bottom:1px dashed #bfbfbf;height:43px;line-height:43px;font-size:16px;overflow:hidden;width:855px\">");
                    sj.Append("<li  style=\" background-color:#e8f0f9;color:#0858b1;width:74px;height:40px;line-height:35px;margin-top:5px\">");
                    str.Append("<img src='../../Content/images/liebiao.png'>");
                    str.Append("<a href='GG_Detail.aspx?id=" + Convert.ToInt32(dt_gg.Rows[j]["id"].ToString()) + "&bt=" + dt_gg.Rows[j]["bt"].ToString() + "'>");    //传值
                    str.Append(bt);
                    sj.Append(time);
                    str.Append("</li>");
                    sj.Append("</li>");
                    str.Append("</ul>");
                    sj.Append("</ul>");
                    this.lbl_gg.Text = str.ToString();
                    this.lbl_sj.Text = sj.ToString();
                }
            }
        }

    }
}