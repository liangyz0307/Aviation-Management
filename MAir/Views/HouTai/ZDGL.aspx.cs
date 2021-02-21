using CUST;
using CUST.Sys;
using CUST.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using Sys;


namespace CUST.WKG
{
    public partial class ZDGL : System.Web.UI.Page

    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private ZD zd;
        private ZD.Struct_ZD_Pro struct_zd;

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
            pg_fy.NumPerPage = _usState.C_HT_ZD;
            psize = _usState.C_HT_ZD;
            //cpage = pg_fy.CurrentPage;
            // psize = pg_fy.NumPerPage; 
            zd = new ZD(_usState);
            struct_zd = new ZD.Struct_ZD_Pro();
            if (!IsPostBack)
            {

                ddltBind();
                bind_Main();
            }
        }


        private void ddltBind()
        {
            //字典项的绑定
            ddlt_zdm.DataSource = SysData.ZDM().Copy(); 
            ddlt_zdm.DataTextField = "mc";
            ddlt_zdm.DataValueField = "bm";
            ddlt_zdm.DataBind();
            ddlt_zdm.Items.Insert(0, new ListItem("全部", "-1"));
        }

        private DataTable table_zdm(DataTable dt)
        {
            dt.Columns.Add("zdmmc", typeof(string));
            dt.Columns.Add("zdm_mc", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["zdmmc"] = "[" + dr["zdm"] + "]" + SysData.ZDMByKey(dr["zdm"].ToString().Trim());
                dr["zdm_mc"] = SysData.ZDMByKey(dr["zdm"].ToString().Trim());

            }
           
            return dt;
        }
        private void bind_Main()
        {
            struct_zd.p_zdm = ddlt_zdm.SelectedValue;//字典码
            struct_zd.p_bm = tbx_bm.Text.ToString().Trim();//编码
            struct_zd.p_mc = tbx_mc.Text.ToString().Trim();//名称

            int count = zd.Select_ZD_Count(struct_zd);
            pg_fy.TotalRecord = count;
            struct_zd.p_currentpage = pg_fy.CurrentPage;
            struct_zd.p_pagesize= pg_fy.NumPerPage;
            DataTable dt = zd.Select_ZD_Pro(struct_zd).Tables[0];//性别

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
                string temp = e.CommandArgument.ToString();
                string[] zdmbm = temp.Split('&');
                struct_zd.p_zdm = zdmbm[0].ToString();
                struct_zd.p_bm = zdmbm[1].ToString();
                struct_zd.p_mc = zdmbm[2].ToString();
               string zdm_mc= zdmbm[3].ToString();
                Response.Redirect("../HouTai/ZD_Edit.aspx?bj_zdm=" + struct_zd.p_zdm + "&bj_bm=" + struct_zd.p_bm + "&bj_mc=" + struct_zd.p_mc + "&bj_zdmmc=" + zdm_mc + "");
                //Server.Transfer("ZD_Edit.aspx?BH=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Delete")
            {
                struct_zd = new ZD.Struct_ZD_Pro();
                string del = e.CommandArgument.ToString();
                string[] zdmbm = del.Split('&');
                struct_zd.p_zdm = zdmbm[0].ToString();
                struct_zd.p_bm = zdmbm[1].ToString();
                struct_zd.p_czfs = "03";
                struct_zd.p_czxx = "位置：后台管理->字典管理->删除      描述：字典码：【" + struct_zd.p_zdm +"编码："+ struct_zd.p_bm+ "】      ";
                zd.Delete_ZD(struct_zd);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/ZD_Add.aspx");
        }
        
    }
}










