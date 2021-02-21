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
    public partial class FAGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private PCFA pcfa;
        private Struct_PCFA struct_pcfa;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_LL;
            psize = _usState.C_YG_LL;
            pcfa = new PCFA(_usState);
            struct_pcfa = new Struct_PCFA();
            if (!IsPostBack)
            {
                bind_Main();
                show();
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;
            //有个人绩效添加权限
            if (SysData.HasThisBMQX(_usState.userID, "120102") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void bind_Main()
        {
            struct_pcfa.p_pcfamc = tbx_pcfamc.Text.Trim().ToString();//评测方案名称
            struct_pcfa.p_pcfabh = tbx_pcfabh.Text.Trim().ToString();//评测方案编号
            struct_pcfa.p_pcxbh = "";//评测项
            struct_pcfa.p_pcxqz = "";//评测项权重
            struct_pcfa.p_zt = "-1";//状态
            int count = pcfa.Select_PCFA_Count(struct_pcfa);
            pg_fy.TotalRecord = count;
            struct_pcfa.p_currentpage = pg_fy.CurrentPage;
            struct_pcfa.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = pcfa.Select_PCFA_Pro(struct_pcfa).Tables[0];
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            string pcfabh = content[0];
            string zt = content[1];
            //int id = Convert.ToInt16(content[2]);//删除时根据id删除pcfa中其他关联pcx
            
            if (e.CommandName == "Delete")
            {
                struct_pcfa = new Struct_PCFA();
                //个人删除权限
                if (!SysData.HasThisBMQX(_usState.userID, "120104"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限，不能删除！\")</script>");
                    return;
                }
                else
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：绩效管理->评测方案->删除    描述：指标代码：[" + _usState.userLoginName + "]";
                    pcfa.Delete_PCFA_ByPCFABH(pcfabh);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }                         
            }            
            bind_Main();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/PCFA_Add.aspx", true);
        }
        //权限
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }
    }
}










