using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class SPRGL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public Struct_SPR struct_spr;
        public SPR spr;
        private UserState _usState;
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
            spr = new SPR(_usState);
            if (!IsPostBack)
            {
                Bind();
                select();
            }
        }

        private void select()
        {
            struct_spr.p_zxtdm = ddlt_zxt.SelectedValue.Trim().ToString();
            int count = spr.Select_SPR_Count(struct_spr);
            pg_fy.TotalRecord = count;

                struct_spr.p_currentpage = pg_fy.CurrentPage;
                struct_spr.p_pagesize = pg_fy.NumPerPage;
                DataTable dt_spr = new DataTable();
                dt_spr = spr.Select_SPR(struct_spr);
                dt_spr.Columns.Add("sprxm");
                dt_spr.Columns.Add("zxtmc");
                foreach (DataRow dr in dt_spr.Rows)
                {
                    string[] Array_spr = dr["spr"].ToString().Split(',');
                    foreach (string bh in Array_spr)
                    {
                        dr["sprxm"] = spr.Select_YGXMbyBH(bh.ToString()).Rows[0][0].ToString();
                    }
                    dr["zxtmc"] = SysData.ZXTDMByKey(dr["zxtdm"].ToString()).mc;//状态
                }

                this.Repeater1.DataSource = dt_spr;
                this.Repeater1.DataBind();
            
    
        }
        private void Bind()
        {
            //隐患等级
            ddlt_zxt.DataSource = SysData.ZXTDM().Copy();
            ddlt_zxt.DataTextField = "mc";
            ddlt_zxt.DataValueField = "bm";
            ddlt_zxt.DataBind();
            ddlt_zxt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            select();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/SPR_Add.aspx");
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                struct_spr.p_id = e.CommandArgument.ToString();
                struct_spr.p_czfs = "03";
                struct_spr.p_czxx = "位置：后台管理->合同管理->删除  描述：ID：【" + struct_spr.p_id + "】";
                DataTable dt = new DataTable();
                spr.Delete_SPR(struct_spr);
                Response.Write("<script>alert(\"删除成功！\");</script>");
            }
            select();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            select();
        }
    }
}