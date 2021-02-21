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

namespace MAir.Views.JXGL
{
    public partial class YG_PCFA_Add : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private Struct_GRJX struct_grjx;
        private PCFA pcfa;
        private GRJX grjx;
        public bool flag = true;
        static DataTable dt_st;
        public int i = 0;
        public string ygbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            grjx = new GRJX(_usState);
            pcfa = new PCFA(_usState);
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            struct_grjx = new Struct_GRJX();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
                bind_checkboxlist();
            }
        }
        private void bind_checkboxlist()
        {
            //绑定已有总方案
            DataTable dt_zfa = new DataTable();
            
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                Label lbl_ygbh = (Label)ri.FindControl("lbl_ygbh");
                dt_zfa = pcfa.Select_YGYYZFA(lbl_ygbh.Text);//查员工已有总方案
                //绑定到checkboxList
                DropDownList cbl_zfa = (DropDownList)ri.FindControl("cbl_zfa");

                cbl_zfa.DataSource = dt_zfa;
                cbl_zfa.DataTextField = "ZFAMC";
                cbl_zfa.DataValueField = "ZFABH";
                cbl_zfa.DataBind();
            }
        }
        private void bind_Main()
        {
            //绑定员工信息，给每个员工选择添加评测方案
            struct_grjx.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();
            struct_grjx.p_gwdm = "-1";//"-1"表示所有岗位
            struct_grjx.p_zt = "-1";
            struct_grjx.p_zfabh = ddlt_zfa.SelectedValue;
            int count = grjx.Select_GRJX_Count(struct_grjx);
            pg_fy.TotalRecord = count;
            struct_grjx.p_currentpage = pg_fy.CurrentPage;
            struct_grjx.p_pagesize = pg_fy.NumPerPage;

            DataTable dt = grjx.Select_AllYG(struct_grjx).Tables[0];//查询符合条件的所有员工
            dt.Columns.Add("bmmc");
            dt.Columns.Add("gwmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门名称
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;//岗位名称
            }
            //绑定分页数据源 
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        private void ddltBind()
        {
            //绑定部门代码ddlt_bmdm
            DataTable dt_bmdm = SysData.BM().Copy();       
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //总方案
            ddlt_zfa.DataSource = grjx.Select_ZFA().Tables[0];//查询总方案表中的总方案
            ddlt_zfa.DataTextField = "zfamc";
            ddlt_zfa.DataValueField = "zfabh";
            ddlt_zfa.DataBind();
            ddlt_zfa.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void ddlt_zfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //联动评测方案
            //string zfabh = ddlt_zfa.SelectedValue;
            //ddlt_pcfa.DataSource = grjx.Select_ZFA_PCFA(zfabh).Tables[0];//查询总方案下的评测方案
            //ddlt_pcfa.DataTextField = "pcfamc";
            //ddlt_pcfa.DataValueField = "pcfabh";
            //ddlt_pcfa.DataBind();
            //ddlt_pcfa.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string zfabh = ddlt_zfa.SelectedValue;
            int count = 0;
            if (ddlt_zfa.SelectedValue == "-1" || ddlt_zfa.SelectedValue == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请先选择总方案！\")</script>");
            }
            else
            {
                foreach (RepeaterItem li in Repeater1.Items)
                {
                    CheckBox cb_pcfa = (CheckBox)li.FindControl("chk");
                    if (cb_pcfa.Checked == true)
                    {
                        count += 1;
                    }
                }
                if (count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择员工！\")</script>");
                    return;
                }
                try
                {
                    foreach (RepeaterItem li in Repeater1.Items)
                    {
                        CheckBox chk = (CheckBox)li.FindControl("chk");
                        Label lbl_ygbh = (Label)li.FindControl("lbl_ygbh");
                        if (chk.Checked == true)
                        {
                            ygbh = lbl_ygbh.Text.ToString().Trim();
                            grjx.Insert_YG_ZFA(ygbh, zfabh);//给员工添加总方案
                        }
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    bind_Main();
                    bind_checkboxlist();
                }
                catch (EMException ex)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                    return;
                }
            }
        }
        protected void btn_cx_Click(object sender, EventArgs e)
        {
            //点击查询，查询条件为“部门代码”，查询结果为“该部门下的员工已有总方案”
            bind_Main();
            bind_checkboxlist();
        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;
            }
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
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
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsPostBack) { chkAll.Text = "全选"; }
            if (chkAll.Text == "全选")
            {
                foreach (RepeaterItem ri in this.Repeater1.Items)
                {
                    CheckBox ck = (CheckBox)ri.FindControl("chk");
                    ck.Checked = true;
                }
                this.chkAll.Text = "取消";
            }
            else {
                foreach (RepeaterItem ri in this.Repeater1.Items)
                {
                    CheckBox ck = (CheckBox)ri.FindControl("chk");
                    ck.Checked = false;
                }
                this.chkAll.Text = "全选";
            }
        }
    }
}