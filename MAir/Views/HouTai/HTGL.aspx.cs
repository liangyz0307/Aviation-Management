using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class HTGL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        public HT ht;
        public Struct_HT struct_ht;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            ht = new HT(_usState);
            if (!IsPostBack)
            {
                bind_drop();
                select();
            }
        }
        private void bind_drop()
        {
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataSource = SysData.HTZT().Copy();
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void select()
        {
            struct_ht.p_htmc = tbx_htmc.Text.ToString();
            struct_ht.p_qdf = tbx_qdf.Text.ToString();
            if (tbx_qxkssj.Text.ToString() == "")
            {
                struct_ht.p_qxkssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_ht.p_qxkssj = Convert.ToDateTime(tbx_qxkssj.Text.ToString());
            }
            if (tbx_qxjssj.Text.ToString() == "")
            {
                struct_ht.p_qxjssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_ht.p_qxjssj = Convert.ToDateTime(tbx_qxjssj.Text.ToString());
            } 
            struct_ht.p_fzr = tbx_fzr.Text.ToString();
            struct_ht.p_zt = ddlt_zt.SelectedValue.ToString();
            int count = ht.Select_HT_Count(struct_ht);
            pg_fy.TotalRecord = count;
            struct_ht.p_currentpage = pg_fy.CurrentPage;
            struct_ht.p_pagesize = pg_fy.NumPerPage;
            DataTable dt_ht = new DataTable();
            dt_ht = ht.Select_HT(struct_ht);
            dt_ht.Columns.Add("qdsj");
            dt_ht.Columns.Add("kssj");
            dt_ht.Columns.Add("jssj");
            dt_ht.Columns.Add("ztmc");
            foreach (DataRow dr in dt_ht.Rows)
            {
                DateTime dt_qdrq = new DateTime();
                dt_qdrq = Convert.ToDateTime(dr["qdrq"].ToString().Trim());
                dr["qdsj"] = string.Format("{0:yyyy-MM-dd }", dt_qdrq);

                DateTime dt_kssj = new DateTime();
                dt_kssj = Convert.ToDateTime(dr["qxkssj"].ToString().Trim());
                DateTime time=new DateTime ();
                if (time == Convert.ToDateTime(dr["qxkssj"].ToString().Trim()))
                {
                    dr["kssj"] = "";
                }
                else
                {
                    dr["kssj"] = string.Format("{0:yyyy-MM-dd }", dt_kssj)+"至";
                }
                DateTime dt_jssj = new DateTime();
                dt_jssj = Convert.ToDateTime(dr["qxjssj"].ToString().Trim());
                if (time == Convert.ToDateTime(dr["qxjssj"].ToString().Trim()))
                {
                    dr["jssj"] = "";
                }
                else
                {
                    dr["jssj"] = string.Format("{0:yyyy-MM-dd }", dt_jssj);
                }
                dr["ztmc"]= SysData.HTZTByKey(dr["zt"].ToString().Trim()).mc+ dr["ztbz"].ToString().Trim();
            }

            this.Repeater1.DataSource = dt_ht;
            this.Repeater1.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            select();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            select();
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("HT_Add.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName== "Delete")
            {
                struct_ht.p_id=e.CommandArgument.ToString();
                struct_ht.p_czfs = "03";                
                struct_ht.p_czxx = "位置：后台管理->合同管理->删除  描述：ID：【" + struct_ht.p_id + "】";
                DataTable dt = new DataTable();
                ht.Delete_HT(struct_ht);
                Response.Write("<script>alert(\"删除成功！\");</script>");
            }
            if(e.CommandName== "Edit")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("HT_Edit.aspx?id=" + id + "");
            }
            if(e.CommandName== "Detail")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("HT_Detail.aspx?id=" + id + "");
            }
            select();
        }
    }
}