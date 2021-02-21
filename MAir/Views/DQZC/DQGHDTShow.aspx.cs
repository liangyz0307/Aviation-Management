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
    public partial class DQGHDTShow : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private DQGHDT dqghdt;
        private Struct_DQGHDT struct_DQGHDT;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = _usState.C_ZL_ZJ;

            dqghdt = new DQGHDT(_usState);
            struct_DQGHDT = new Struct_DQGHDT();
            if (!IsPostBack)
            {
                tbx_fbsjks.Attributes.Add("readonly", "readonly");
                tbx_fbsjjs.Attributes.Add("readonly", "readonly");
                bind_Main();
              

            }
        }
       

        //判断用户是否有添加权限
     
        private void bind_Main()
        {
            struct_DQGHDT.p_bt = tbx_bt.Text.ToString().Trim();//标题
          
            if (tbx_fbsjks.Text == "")
            {

                struct_DQGHDT.p_fbsjks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_DQGHDT.p_fbsjks = DateTime.Parse(tbx_fbsjks.Text.Trim().ToString());//开始时间
            }
            if (tbx_fbsjjs.Text == "")
            {
                // DateTime dt_jssj = new DateTime();
                struct_DQGHDT.p_fbsjjs = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_DQGHDT.p_fbsjjs = DateTime.Parse(tbx_fbsjjs.Text.Trim().ToString());//结束时间
            }
            int count = dqghdt.Select_DQGHDTShow_Count(struct_DQGHDT);
            pg_fy.TotalRecord = count;
            struct_DQGHDT.p_currentpage = pg_fy.CurrentPage;
            struct_DQGHDT.p_pagesize = pg_fy.NumPerPage;

            DataTable dt = dqghdt.Select_DQGHDTShow_Pro(struct_DQGHDT);
            dt.Columns.Add("fbsjmc");
           
            DateTime dt_fbsj = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {
                dt_fbsj = Convert.ToDateTime(dr["fbsj"].ToString());
                dr["fbsjmc"] = string.Format("{0:yyyy-MM-dd}", dt_fbsj);
              
               
            }


            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();

        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        #region 错误信息

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
        #endregion

       
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

     
    }
}