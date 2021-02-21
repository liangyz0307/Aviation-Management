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
    public partial class YG_ZFA_Add : System.Web.UI.Page
    {
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
            struct_grjx = new Struct_GRJX();
            ygbh = Request.QueryString.Get("ygbh").ToString();
            if (!IsPostBack)
            {
                ddltBind();//总方案
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
                dt_zfa = pcfa.Select_YGYYZFA(ygbh);//查员工已有总方案
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
            //绑定员工信息
            DataTable dt = grjx.Select_YGXMbyBH(ygbh).Tables[0];//查询符合条件的所有员工
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
            //总方案
            ddlt_zfa.DataSource = grjx.Select_ZFA().Tables[0];//查询总方案表中的总方案
            ddlt_zfa.DataTextField = "zfamc";
            ddlt_zfa.DataValueField = "zfabh";
            ddlt_zfa.DataBind();
            ddlt_zfa.Items.Insert(0, new ListItem("请选择", "-1"));
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
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string zfabh = ddlt_zfa.SelectedValue;
            if (ddlt_zfa.SelectedValue == "-1" || ddlt_zfa.SelectedValue == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请先选择总方案！\")</script>");
            }
            else
            {
                try
                {
                    grjx.Insert_YG_ZFA(ygbh, zfabh);//给员工添加总方案
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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/GRJXZF.aspx?", true);
        }
    }
}