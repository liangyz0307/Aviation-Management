using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class YH_Detail : System.Web.UI.Page
    {

        private UserState _usState;
        private string id;
        private YH yh;
        private Struct_YH struct_yh;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yh = new YH(_usState);
            if (!IsPostBack)
            {
                id = Request.Params["id"].ToString();
                select_detail();
               
            }
        }

      
        protected void select_detail()
        {
            dt_detail = yh.Select_YH_Detail(Convert.ToInt32(id));
            lbl_bh.Text = dt_detail.Rows[0]["zh"].ToString();//员工编号
            lbl_lb.Text =SysData.YHLBByKey( dt_detail.Rows[0]["lb"].ToString()).ms;//类别
            lbl_mc.Text = dt_detail.Rows[0]["mc"].ToString();//名称
            DateTime dt_kssj = new DateTime();
            dt_kssj =Convert.ToDateTime( dt_detail.Rows[0]["yxkssj"].ToString());
            lbl_kssj.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_kssj);
            // lbl_kssj.Text = dt_detail.Rows[0]["yxkssj"].ToString();//开始时间
            DateTime dt_jssj = new DateTime();
            dt_jssj = Convert.ToDateTime(dt_detail.Rows[0]["yxjssj"].ToString());
            lbl_jssj.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_jssj);
            // lbl_jssj.Text = dt_detail.Rows[0]["yxjssj"].ToString();//结束时间
            lbl_sfsqxyh.Text =SysData.SFSQXYHByKey( dt_detail.Rows[0]["sfsqxyh"].ToString());//是否是权限用户
            lbl_sfqy.Text =SysData.SFQYByKey( dt_detail.Rows[0]["sfqy"].ToString());//是否启用
            lbl_xlh.Text = dt_detail.Rows[0]["xlh"].ToString();//序列号
            lbl_ss.Text = SysData.YHLBByKey(dt_detail.Rows[0]["ss"].ToString()).ms; //所属
            lbl_sfsglyh.Text =SysData.SFSGLYHByKey( dt_detail.Rows[0]["sfsglyh"].ToString()); //是否是管理用户
        }
       
        protected void Page_Error(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Write(EMException.ShowErrorScript(Server.GetLastError()));
                Response.Write(StrConvert.ShowScript("history.back();"));
                Response.End();
            }
            finally
            {
                Server.ClearError();
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("YHGL.aspx");
        }
    }
}