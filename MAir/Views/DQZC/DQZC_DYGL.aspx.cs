using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG.MenHu.main
{
    public partial class DQZC_DYGL : System.Web.UI.Page
    {
        public DQZC dqzc;
        public ODQZC.Struct_DY struct_dy;
        private UserState _usState;
        public int cpage;
        public int psize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dqzc = new DQZC(_usState);
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {
               
                bind_drop();
            }
        }
        private void bind_drop()
        {
            ddlt_jcdzbmc.DataTextField = "mc";
            ddlt_jcdzbmc.DataValueField = "bm";
            ddlt_jcdzbmc.DataSource = SysData.JCDZBMC().Copy();
            ddlt_jcdzbmc.DataBind();
            ddlt_jcdzbmc.Items.Insert(0, new ListItem("全部", "-1"));

            ddlt_dxzmc.DataTextField = "mc";
            ddlt_dxzmc.DataValueField = "bm";
            ddlt_dxzmc.DataSource = SysData.DXZMC().Copy();
            ddlt_dxzmc.DataBind();
            ddlt_dxzmc.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_zt.Items.RemoveAt(2);
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void select()
        {
            struct_dy.p_xm = tbx_xm.Text.ToString();
            struct_dy.p_zt = ddlt_zt.SelectedValue.ToString();
            struct_dy.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_dy.p_sfzh = tbx_sfzh.Text.ToString();
            struct_dy.p_dnzw = tbx_dnzw.Text.ToString();
            struct_dy.p_jcdzbmc = ddlt_jcdzbmc.SelectedValue.ToString();
            struct_dy.p_dxzmc = ddlt_dxzmc.SelectedValue.ToString();
            int count = dqzc.Select_DYCount(struct_dy);
            pg_fy.TotalRecord = count;
            struct_dy.p_currentpage = pg_fy.CurrentPage;
            struct_dy.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = dqzc.Select_DY(struct_dy);
             dt.Columns.Add("ygxs_mc", typeof(string));
             dt.Columns.Add("dzb_mc", typeof(string));
             dt.Columns.Add("dxz_mc", typeof(string));
             dt.Columns.Add("dzz_mc", typeof(string));
             dt.Columns.Add("ztmc", typeof(string));
             foreach (DataRow dr in dt.Rows)
             {
                 dr["ygxs_mc"] = SysData.YGXSByKey(dr["ygxs"].ToString().Trim()).mc;
                 dr["dzb_mc"] = SysData.JCDZBMCByKey(dr["jcdzbmc"].ToString().Trim()).mc;
                 dr["dxz_mc"] = SysData.DXZMCByKey(dr["dxzmc"].ToString().Trim()).mc;
                 dr["dzz_mc"] = SysData.DZZMCByKey(dr["dzzmc"].ToString().Trim()).mc;
                 dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
             }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            select();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            select();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DQZC_DYAdd.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName== "Edit")
            {
                string bh = e.CommandArgument.ToString();
                Response.Redirect("../DQZC/DQZC_DYEdit.aspx?bh=" + bh + "");
            }
            if (e.CommandName == "Delete")
            {
                struct_dy.p_bh = e.CommandArgument.ToString();
                struct_dy.p_czfs = "03";
                struct_dy.p_czxx = "位置：党群之窗->党员管理->删除  描述：身份证号：【" + struct_dy.p_bh + "】";
                DataTable dt = new DataTable();
                dqzc.Delete_DY(struct_dy);
                Response.Write("<script>alert(\"删除成功！\");</script>");
                select();
            }
        }
    }
}
