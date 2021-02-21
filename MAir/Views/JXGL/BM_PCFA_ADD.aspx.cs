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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BM_PCFA_ADD : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState userstate;
        private Struct_PCFA struct_pcfa;
        private PCFA pcfa;
        private GRJX grjx;
        public string bmdm;
        DataTable dt_allzfa;
        DataTable dt_yyzfa;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            pcfa = new PCFA(userstate);
            grjx = new GRJX(userstate);
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            struct_pcfa = new Struct_PCFA();
            dt_allzfa = new DataTable();
            dt_yyzfa = new DataTable();
            struct_pcfa.p_pagesize = 9999;
            struct_pcfa.p_currentpage = 1;
            dt_allzfa = pcfa.Select_BMZFA(struct_pcfa).Tables[0];//查询总方案表中全部总方案用于添加
            if (!IsPostBack)
            {
                ddltZfaBind();
                bind();
                bind_checkboxlist();
            }
        }
        private void bind()
        {
            int count = grjx.Select_BM_Count(); //查询部门数量,每条部门显示一行，该数量用于分页
            pg_fy.TotalRecord = count;
            struct_pcfa.p_currentpage = pg_fy.CurrentPage;
            struct_pcfa.p_pagesize = pg_fy.NumPerPage;

            DataTable dt = grjx.Select_allBM().Tables[0];//查询全部部门名称
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        private void bind_checkboxlist()
        {
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                Label lbl_bmdm = (Label)ri.FindControl("lbl_bmdm");
                dt_yyzfa = pcfa.Select_BMZFA_BYBH(lbl_bmdm.Text).Tables[0];
                //绑定已有总方案checkboxList
                DropDownList cbl_yyzfa = (DropDownList)ri.FindControl("cbl_yyzfa");
                cbl_yyzfa.DataSource = dt_yyzfa;
                cbl_yyzfa.DataTextField = "ZFAMC";
                cbl_yyzfa.DataValueField = "ZFABH";
                cbl_yyzfa.DataBind();
                ////绑定全部评测方案checkboxList
                //CheckBoxList cbl_allzfa = (CheckBoxList)ri.FindControl("cbl_allzfa");
                //cbl_allzfa.DataSource = dt_allzfa;
                //cbl_allzfa.DataTextField = "ZFAMC";
                //cbl_allzfa.DataValueField = "ZFABH";
                //cbl_allzfa.DataBind();
            }
        }
        //保存
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int count = 0;
            string zfabh = ddlt_zfa.SelectedValue;
            if (ddlt_zfa.SelectedValue == "-1" || ddlt_zfa.SelectedValue == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请先选择总方案！\")</script>");
            }
            else
            {
                foreach (RepeaterItem li in Repeater1.Items)
                {
                    CheckBox cb_zfa = (CheckBox)li.FindControl("chk");
                    if (cb_zfa.Checked == true)
                    {
                        count += 1;
                    }
                }
                if (count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择部门！\")</script>");
                    return;
                }
                try
                {
                    foreach (RepeaterItem li in Repeater1.Items)
                    {
                        CheckBox chk = (CheckBox)li.FindControl("chk");
                        Label lbl_bmdm = (Label)li.FindControl("lbl_bmdm");
                        if (chk.Checked == true)
                        {
                            bmdm = lbl_bmdm.Text.ToString().Trim();
                            grjx.Insert_BM_ZFA(bmdm, zfabh);//给部门添加总方案
                        }
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    bind();
                    bind_checkboxlist();
                }
                catch (EMException ex)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                    return;
                }
            }
        }
        private void ddltZfaBind()
        {
            struct_pcfa.p_currentpage = 1;//Select_BMZFA这个存储过程需要参数
            struct_pcfa.p_pagesize = 999999;
            //总方案
            ddlt_zfa.DataSource = pcfa.Select_BMZFA(struct_pcfa).Tables[0];//查询部门总方案表中的总方案
            ddlt_zfa.DataTextField = "zfamc";
            ddlt_zfa.DataValueField = "zfabh";
            ddlt_zfa.DataBind();
            ddlt_zfa.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind();
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
            else
            {
                foreach (RepeaterItem ri in this.Repeater1.Items)
                {
                    CheckBox ck = (CheckBox)ri.FindControl("chk");
                    ck.Checked = false;
                }
                this.chkAll.Text = "全选";
            }
        }
        #region//全选反选取消按钮
        ////反选
        //protected void btn_fanxuan_Click(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem ri in Repeater1.Items)
        //    {
        //        CheckBoxList cbl_allpcfa = (CheckBoxList)ri.FindControl("cbl_allpcfa");
        //        for (int i = 0; i < cbl_allpcfa.Items.Count; i++)
        //        {
        //            if (cbl_allpcfa.Items[i].Selected == true)
        //            {
        //                cbl_allpcfa.Items[i].Selected = false;
        //            }
        //            else
        //            {
        //                cbl_allpcfa.Items[i].Selected = true;
        //            }
        //        }
        //    }
        //}
        ////全选
        //protected void btn_quanxuan_Click(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem ri in Repeater1.Items)
        //    {
        //        CheckBoxList cbl_allpcfa = (CheckBoxList)ri.FindControl("cbl_allpcfa");
        //        for (int i = 0; i < cbl_allpcfa.Items.Count; i++)
        //        {
        //            cbl_allpcfa.Items[i].Selected = true;
        //        }
        //    }
        //}
        ////取消
        //protected void btn_quxiao_Click(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem ri in Repeater1.Items)
        //    {
        //        CheckBoxList cbl_allpcfa = (CheckBoxList)ri.FindControl("cbl_allpcfa");
        //        for (int i = 0; i < cbl_allpcfa.Items.Count; i++)
        //        {
        //            cbl_allpcfa.Items[i].Selected = false;
        //        }
        //    }
        //}
       
        #endregion
    }
}