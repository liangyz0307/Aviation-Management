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
    public partial class SBTZ_CZ : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage1;
        public int psize1;
        public int cpage2;
        public int psize2;
        public int cpage3;
        public int psize3;
        public int cpage4;
        public int psize4;
        private string tzbh;
        private string bmdm;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tzsb = new TZSB(_usState);
            
            if (!IsPostBack)
            {
                tzbh = Request.Params["tzbh"].ToString();
                bind_Main();
                show();
            }
        }
        public void show()
        {
            Boolean flag_add_kt = false;
            Boolean flag_add_jsq = false;
            Boolean flag_add_fhsb = false;
            Boolean flag_add_mscs = false;
            btn_add_kt.Visible = false;
            btn_add_jsq.Visible = false;
            btn_add_fhsb.Visible = false;
            btn_add_mscs.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "140402") == true)
            {
                flag_add_kt = true;
                flag_add_jsq = true;
                flag_add_fhsb = true;
                flag_add_mscs = true;
            }
            if (flag_add_kt) { btn_add_kt.Visible = true; }
            if (flag_add_jsq) { btn_add_jsq.Visible = true; }
            if (flag_add_fhsb) { btn_add_fhsb.Visible = true; }
            if (flag_add_mscs) { btn_add_mscs.Visible = true; }
        }
        private void bind_Main()
        {

            #region 空调信息列表

            DateTime dt = new DateTime();
            DataTable dt_kt = tzsb.Select_KTByBh(Request.Params["tzbh"].ToString());
            dt_kt.Columns.Add("sfjbmc");
            dt_kt.Columns.Add("sfazzqzzmc");
            dt_kt.Columns.Add("azsjmc");
            foreach (DataRow dr in dt_kt.Rows)
            {

                dr["sfjbmc"] = SysData.SFJBByKey(dr["sfpb"].ToString()).mc;
                dr["sfazzqzzmc"] = SysData.SFJBByKey(dr["sfazzqzz"].ToString()).mc;
                dr["azsjmc"] = DateTime.Parse(dr["azsj"].ToString()).ToString("yyyy-MM-dd");

            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt_kt.DefaultView;
            this.Repeater1.DataBind();
            #endregion
            #region 加湿器列表
            
            DataTable dt_jsq = tzsb.Select_JSQByBh(Request.Params["tzbh"].ToString());
            dt_jsq.Columns.Add("sfjbmc");
            dt_jsq.Columns.Add("azsjmc");
            foreach (DataRow dr in dt_jsq.Rows)
            {

                dr["sfjbmc"] = SysData.SFJBByKey(dr["sfpb"].ToString()).mc;
                
                dr["azsjmc"] = DateTime.Parse(dr["azsj"].ToString()).ToString("yyyy-MM-dd");

            }

            //绑定分页数据源  
            this.Repeater2.DataSource = dt_jsq.DefaultView;
            this.Repeater2.DataBind();
            #endregion
            #region 防火设备列表


            DataTable dt_fhsb = tzsb.Select_FHSBByBh(Request.Params["tzbh"].ToString());
            dt_fhsb.Columns.Add("mhsblxmc");
            dt_fhsb.Columns.Add("jcdqsjmc");
            foreach (DataRow dr in dt_fhsb.Rows)
            {
                dr["mhsblxmc"] = SysData.SFJBByKey(dr["mhsblx"].ToString()).mc;
                dr["jcdqsjmc"] = DateTime.Parse(dr["jcdqsj"].ToString()).ToString("yyyy-MM-dd");
            }



            //绑定分页数据源  
            this.Repeater3.DataSource = dt_fhsb.DefaultView;
            this.Repeater3.DataBind();
            #endregion
            #region 灭鼠措施列表


            DataTable dt_mscs = tzsb.Select_MSCSByBh(Request.Params["tzbh"].ToString());

            dt_mscs.Columns.Add("dsbmc");
            dt_mscs.Columns.Add("fdmc");
            dt_mscs.Columns.Add("wxgjmc");
            dt_mscs.Columns.Add("fhmc");
            dt_mscs.Columns.Add("sfydnmc");
         //   dt_mscs.Columns.Add("fljcdqrqmc");
            foreach (DataRow dr in dt_mscs.Rows)
            {

                dr["dsbmc"] = SysData.SFJBByKey(dr["dsb"].ToString()).mc;
                dr["fdmc"] = SysData.SFJBByKey(dr["fd"].ToString()).mc;
                dr["wxgjmc"] = SysData.SFJBByKey(dr["wxgj"].ToString()).mc;
                dr["fhmc"] = SysData.SFJBByKey(dr["fh"].ToString()).mc;
                dr["sfydnmc"] = SysData.SFJBByKey(dr["sfydn"].ToString()).mc;
              //  dr["fljcdqrqmc"] = DateTime.Parse(dr["fljcdqrq"].ToString()).ToString("yyyy-MM-dd");
            }

            //绑定分页数据源  
            this.Repeater4.DataSource = dt_mscs.DefaultView;
            this.Repeater4.DataBind();
            #endregion
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


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e) {

            string[] content_kt = new string[2];
            content_kt = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content_kt[0]);
            string tzbh = content_kt[1];
            if (e.CommandName == "Edit")
            {

                Response.Redirect("TZSB_KT_Edit.aspx?id=" + id + "&tzbh=" + tzbh);
                
            }
            else if (e.CommandName == "Delete")
            {

                struct_tzsb = new Struct_TZSB();
                string p_czfs = "04";
                string p_czxx = "位置：设备台站->空调->删除   描述：员工编号：[" + _usState.userLoginName + "]";
                tzsb.Delete_TZ_KT(id, p_czfs, p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            bind_Main();
        }
        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e) {
            string[] content_jsq = new string[2];
            content_jsq = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content_jsq[0]);
            string tzbh = content_jsq[1];
            if (e.CommandName == "Edit")
            {

                Response.Redirect("TZSB_JSQQK_Edit.aspx?id=" + id + "&tzbh=" + tzbh);

            }
            else if (e.CommandName == "Delete")
            {

                struct_tzsb = new Struct_TZSB();
                string p_czfs = "04";
                string p_czxx = "位置：设备台站->加湿器->删除   描述：员工编号：[" + _usState.userLoginName + "]";
                tzsb.Delete_TZ_JSQQK(id, p_czfs, p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            bind_Main();
        }
        protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e) {
            string[] content_fhsb = new string[2];
            content_fhsb = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content_fhsb[0]);
            string tzbh = content_fhsb[1];
            if (e.CommandName == "Edit")
            {

                Response.Redirect("TZSB_FHSB_Edit.aspx?id=" + id + "&tzbh=" + tzbh);

            }
            else if (e.CommandName == "Delete")
            {

                struct_tzsb = new Struct_TZSB();
                string p_czfs = "04";
                string p_czxx = "位置：设备台站->防火设备->删除   描述：员工编号：[" + _usState.userLoginName + "]";
                tzsb.Delete_TZ_FHSB(id, p_czfs, p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            bind_Main();
        }
        protected void Repeater4_ItemCommand(object source, RepeaterCommandEventArgs e) {
            string[] content_mscs = new string[2];
            content_mscs = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content_mscs[0]);
            string tzbh = content_mscs[1];
            if (e.CommandName == "Edit")
            {

                Response.Redirect("TZSB_MSCS_Edit.aspx?id=" + id + "&tzbh=" + tzbh);

            }
            else if (e.CommandName == "Delete")
            {
                
                struct_tzsb = new Struct_TZSB();
                string p_czfs = "04";
                string p_czxx = "位置：设备台站->灭鼠措施->删除   描述：员工编号：[" + _usState.userLoginName + "]";
                tzsb.Delete_TZ_MSCS(id, p_czfs, p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) { }








        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("SBTZ.aspx");
        }
        //跳转添加空调信息页面
        protected void btn_add_kt_Click(object sender, EventArgs e)
        {
            Response.Redirect("TZSB_KT_Add.aspx?tzbh=" + Request.Params["tzbh"].ToString());
        }
        //跳转到添加加湿器信息页面
        protected void btn_add_jsq_Click(object sender, EventArgs e)
        {
            Response.Redirect("TZSB_JSQQK_Add.aspx?tzbh=" + Request.Params["tzbh"].ToString());
        }
        //跳转到防火设备页面
        protected void btn_add_fhsb_Click(object sender, EventArgs e)
        {
            Response.Redirect("TZSB_FHSB_Add.aspx?tzbh=" + Request.Params["tzbh"].ToString());
        }
        //跳转到灭鼠措施页面
        protected void btn_add_mscs_Click(object sender, EventArgs e)
        {
            Response.Redirect("TZSB_MSCS_Add.aspx?tzbh=" + Request.Params["tzbh"].ToString());
        }

    }
}