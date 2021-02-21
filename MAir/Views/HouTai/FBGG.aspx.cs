using CUST.Sys;
using CUST;
using System;
using CUST.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using System.Data;
using Sys;

namespace CUST.WKG
{
    public partial class FBGG : System.Web.UI.Page
    {
         private UserState _usState;
        public int cpage;
        public int psize;
        private GG fbgg;
        private CUST.MKG.OGG.Struct_GG_Pro struct_gg;
    
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
            pg_fy.NumPerPage = _usState.C_HT_FBGG;
            psize = _usState.C_HT_FBGG;
            fbgg = new GG(_usState);
           
            struct_gg = new CUST.MKG.OGG.Struct_GG_Pro();
            if (!IsPostBack)
            {

                ddltBind();
                bind_Main();
            }
        }

        private void ddltBind()
        {
           //绑定公告类型ddlt_gglx
            DataTable dt_gglx = SysData.GGLX().Copy();
            ddlt_gglx.DataSource = dt_gglx;
            ddlt_gglx.DataTextField = "mc";
            ddlt_gglx.DataValueField = "bm";
            ddlt_gglx.DataBind();
            ddlt_gglx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_gg.p_lx =ddlt_gglx.Text.ToString().Trim();//公告类型
            struct_gg.p_bt = tbx_bt.Text.ToString().Trim();//姓名
            if (tbx_sj1.Text.ToString().Trim() != "")
            {
                struct_gg.p_fbrqks = Convert.ToDateTime(tbx_sj1.Text);
            }
            else
            {
                DateTime de = new DateTime();
                struct_gg.p_fbrqks = de;
            }
            if (tbx_sj2.Text.ToString().Trim() != "")
            {
                struct_gg.p_fbrqjs = Convert.ToDateTime(tbx_sj2.Text);
            }
            else
            {
                DateTime de = System.DateTime.Now;
                struct_gg.p_fbrqjs = de;
            }
            int count = fbgg.Select_GG_count(struct_gg);
            pg_fy.TotalRecord = count;
            struct_gg.p_currentpage = pg_fy.CurrentPage;
            struct_gg.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = fbgg.Select_GG_Pro(struct_gg);
        
            //接受部门
            dt.Columns.Add("jsbmmc");
            dt.Columns.Add("lxmc");
            foreach( DataRow dr in dt.Rows)
            {
                string[] sArray = dr["jsbm"].ToString().Split(',');
                foreach (string jsbm_dm in sArray)
                {
                    dr["jsbmmc"] += SysData.BMByKey(jsbm_dm).mc+"    ";
                }
                dr["lxmc"] = SysData.GGLXByKey(dr["lx"].ToString()).mc;
               
            }
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/FBGG_Add.aspx");
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("../HouTai/FBGG_Detail.aspx?id=" + id + "");
            }
            else if (e.CommandName == "Delete")
            {
                string id = e.CommandArgument.ToString();
                string p_czfs = "03";
                DataTable dt = new DataTable();
                dt = fbgg.Select_GG(Convert.ToInt32(id));
                string p_czxx = "位置：后台管理->发布公告->删除      描述：公告标题：【" + dt.Rows[0]["bt"] + "】      ";
                fbgg.delete_GG(Convert.ToInt32(id), p_czfs, p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
            }
            bind_Main();
        }
    }
}