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
    public partial class BS_ZBGL_CZ : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage1;
        public int psize1;
        public ZBGL zbgl;
        private int id;
        private Struct_ZBGL struct_zbgl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            
            zbgl = new ZBGL(_usState);

            id = Convert.ToInt32(Request.Params["id"].ToString());
            if (!IsPostBack)
            {
                bind_Main();
                show();
            }
        }
    
        public void show()
        {

            Boolean flag_add = false;

            btn_add_zbyg.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "130502") == true)
            {
                flag_add = true;
            }

            if (flag_add) { btn_add_zbyg.Visible = true; }

        }
        private void bind_Main()
        {
            DataTable dt = new DataTable();
            dt = zbgl.Select_ZBTJByID(Convert.ToInt32(Request.Params["id"].ToString()));
            dt.Columns.Add("zbgwmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["zbgwmc"] = SysData.GWByKey(dr["zbgw"].ToString()).mc;
            }


            ///绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string[] content_kt = new string[2];
            content_kt = e.CommandArgument.ToString().Split('&');
            int xh = Convert.ToInt32(content_kt[1]);

            if (e.CommandName == "Delete")
            {

                struct_zbgl = new Struct_ZBGL();
                string p_czfs = "04";
                string p_czxx = "位置：航务综合值班管理->子表值班员工->删除   描述：员工编号：[" + _usState.userLoginName + "]";
                zbgl.Delete_ZBTJ(xh, p_czfs, p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            bind_Main();
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
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("BS_ZBGL.aspx");
        }
        protected void btn_add_zbyg_Click(object sender, EventArgs e)
        {
           // Response.Redirect("BS_ZBTJ.aspx?id=" + Request.Params["id"].ToString());
            Response.Redirect("BS_ZBTJ.aspx?id="+ id);
        }
    }
}