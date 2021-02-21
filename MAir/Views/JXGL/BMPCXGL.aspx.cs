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
    public partial class BMPCXGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private PCX pcx;
        private Struct_PCX struct_pcx;
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
            pcx = new PCX(_usState);
            struct_pcx = new Struct_PCX();
            if (!IsPostBack)
            {
                bind_Main();
                show();
            }
        }
        private void bind_Main()
        {
            struct_pcx.p_pcxmc = tbx_pcxmc.Text.Trim().ToString();//评测项名称
            struct_pcx.p_zt = "-1";
            int count = pcx.Select_BMPCX_Count(struct_pcx);
            pg_fy.TotalRecord = count;
            struct_pcx.p_currentpage = pg_fy.CurrentPage;
            struct_pcx.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = pcx.Select_BMPCX_Pro(struct_pcx).Tables[0];

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        //添加按钮
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMPCXGL_Add.aspx", true);
        }
        //查询按钮
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;
            //有个人绩效添加权限
            if (SysData.HasThisBMQX(_usState.userID, "120202"))
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }
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
            string pcxbh = content[0];
            string zt = content[1];
           
             if (e.CommandName == "Delete")
            {
                struct_pcx = new Struct_PCX();
                if (!SysData.HasThisBMQX(_usState.userID,"140204"))
                {            
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限，不能删除！\")</script>");
                    return;
                }

                else 
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：绩效管理->指标信息->删除    描述：指标代码：[" + _usState.userLoginName + "]";
                    pcx.Delete_BMPCX(pcxbh, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }
            }
           
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            //{
            //    Label lbl_zt = (Label)li.FindControl("lbl_zt");
            //    if (lbl_zt.Text == "待提交")//0
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Blue;
            //    }
            //    if (lbl_zt.Text == "待初审")//1
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
            //    }
            //    if (lbl_zt.Text == "待终审")//2
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
            //    }
            //    if (lbl_zt.Text == "审核通过")//3
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Green;
            //    }
            //    if (lbl_zt.Text == "审核未通过")//4
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
        }

    }
}