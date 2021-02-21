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
    public partial class YHGL : System.Web.UI.Page

    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YH yh;
        private Struct_Select_YH struct_yh;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_HT_YH;
            psize = _usState.C_HT_YH;
            //cpage = pg_fy.CurrentPage;
            // psize = pg_fy.NumPerPage; 
            yh = new YH(_usState);
            struct_yh = new Struct_Select_YH();
            if (!IsPostBack)
            {

                ddltBind();
                bind_Main();
            }
        }

        public void GW(string bm)
        {
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_gwdm.DataSource = dt;
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_gwdm.DataSource = SysData.GW(bm).Copy();
                ddlt_gwdm.DataTextField = "ms";
                ddlt_gwdm.DataValueField = "bm";
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }
        private void ddltBind()
        {
            //部门代码
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "ms";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //岗位代码
            DataTable dt_gw = new DataTable();
            ddlt_gwdm.DataSource = dt_gw;
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));



        }

        private DataTable table_zdm(DataTable dt)
        {
            dt.Columns.Add("bm", typeof(string));
            dt.Columns.Add("gw", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = "[" + dr["bmdm"] + "]" + SysData.BMByKey(dr["bmdm"].ToString().Trim()).mc;
                dr["gw"] = "[" + dr["gwdm"] + "]" + SysData.GWByKey(dr["gwdm"].ToString().Trim()).mc;
            }
           
            return dt;
        }
        private void bind_Main()
        {
            struct_yh.p_bh =tbx_bh.Text.ToString().Trim();//用户编号
            struct_yh.p_xm = tbx_xm.Text.ToString().Trim();//姓名
            struct_yh.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            struct_yh.p_gwdm = ddlt_gwdm.SelectedValue.ToString().Trim();//岗位代码

            int count = yh.Select_YH_Count(struct_yh);
            pg_fy.TotalRecord = count;
            struct_yh.p_currentpage = pg_fy.CurrentPage;
            struct_yh.p_pagesize= pg_fy.NumPerPage;
            DataTable dt = yh.Select_YH_Pro(struct_yh);//性别

            table_zdm(dt);
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string id = e.CommandArgument.ToString();

                Response.Redirect("../HouTai/YH_Edit.aspx?id=" + id + "");
                //Server.Transfer("ZD_Edit.aspx?BH=" + e.CommandArgument.ToString());
            }
          
            else if (e.CommandName == "Delete")
            {
                string id = e.CommandArgument.ToString();
                string p_czfs = "03";
                DataTable dt = new DataTable();
                dt = yh.Select_YH_Detail(Convert.ToInt32(id));
                string p_czxx = "位置：后台管理->用户管理->删除      描述：用户编号：【" + dt.Rows[0]["zh"] + "】      ";
                yh.Delete_YH_byID(Convert.ToInt32(id),p_czfs,p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            else if (e.CommandName == "KJRK")
            {
                string bh = e.CommandArgument.ToString();
                Response.Redirect("../HouTai/YH_KJRK.aspx?bh=" + bh + "");
            }
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/YH_Add.aspx");
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bmdm.SelectedValue;
            GW(bm);
        }
    }
}










