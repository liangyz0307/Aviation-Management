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
    public partial class GRJXGL : System.Web.UI.Page
    {
        private UserState _usState;
        public bool flag = true;
        public int i = 0;
        private GRJX grjx;
        private Struct_GRJX struct_grjx;
        public string ygbh,xm,bm,gw,zfabh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            grjx = new GRJX(_usState);
            struct_grjx = new Struct_GRJX();
            ygbh = Request.QueryString.Get("ygbh").ToString();
            zfabh = Request.QueryString.Get("zfabh").ToString();
            xm = Request.QueryString.Get("xm").ToString();
            bm = Request.QueryString.Get("bm").ToString();
            gw = Request.QueryString.Get("gw").ToString();
            if (!IsPostBack)
            {
                bind_Main();
            }
        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;
            }
        }
        private void bind_Main()
        {
            lbl_ygbh.Text = ygbh;
            hlnk_xm.Text = xm;
            lbl_bmdm.Text = bm;
            lbl_gwdm.Text = gw;
           
            //调存储过程，查询员工名下的所有评测方案及得分。
            ///DataTable dt = grjx.Select_GRJX_SUM(struct_grjx.p_bmdm, struct_grjx.p_gwdm).Tables[0];
            DataTable dt = grjx.Select_GRJX_PCFA_DF_ByBh(ygbh,zfabh);
            dt.Columns.Add("GFAZZDF");//该方案最终得分（打分*权重）
            foreach (DataRow dr in dt.Rows)
            {
                dr["GFAZZDF"] = Convert.ToDouble((dr["pcfadf"].ToString())) * Convert.ToDouble((dr["pcfaqz"].ToString())) * 0.01;
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
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
        //传值，通过get返回需要传递的数据
        //public string TransferData {
        //    get {
        //        return bh;
        //    }
        //}
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[1];
            //content = e.CommandArgument.ToString().Split('&');
            string pcfabh = content[0];

            //删除该员工名下的某个评测方案？
            //评测方案权重之和为100，所以不允许这样单独删除一个，要删除，就到总分表中，删除员工总成绩。
            //员工绩效评测方案详情这里应该只允许修改打分。//点击编辑，变为可编辑模板
            if (e.CommandName == "Delete")
            {
                grjx.Delete_GRJX_ByYGBH(ygbh);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
            }
            bind_Main();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            //根据部门和岗位查询员工的个人绩效//从查询全部员工的个人绩效的结果集中筛选查询
            bind_Main();
        }
        //权限
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                #region 删除按钮
                //((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                //if (SysData.HasThisQX("120104", _usState.userID, "01"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                //if (SysData.HasThisQX("120104", _usState.userID, "02"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                //if (SysData.HasThisQX("120104", _usState.userID, "03"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                //if (SysData.HasThisQX("120104", _usState.userID, "04"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                //if (SysData.HasThisQX("120104", _usState.userID, "05"))
                //{
                //    //删除
                //    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                //}
                #endregion
            }
        }
    }
}










