using CUST;
using CUST.Sys;
using CUST.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using Sys;

namespace CUST.WKG
{
    public partial class LLGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YGLL ygll;
        private Struct_Select_YGLL struct_ygll;
        public bool flag = true;
        public int i = 0;
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
            ygll = new YGLL(_usState);
            struct_ygll = new Struct_Select_YGLL();
            if (!IsPostBack)
            {

                ddltBind();
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
        private void ddltBind()
        {
            //绑定部门代码ddlt_bmdm
            DataTable dt_bmdm = SysData.BM().Copy();

            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));



            ////岗位代码
            //DataTable dt_gw = new DataTable();
            //ddlt_gwdm.DataSource = dt_gw;
            //ddlt_gwdm.DataBind();
            //ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

        }
        public void GW(string bm)
        {

            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_gwdm.DataSource = dt;
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_gwdm.DataSource = SysData.GW(bm).Copy();
                ddlt_gwdm.DataTextField = "mc";
                ddlt_gwdm.DataValueField = "bm";
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }
        private void bind_Main()
        {
            struct_ygll.p_bh = tbx_bh.Text.Trim().ToString();//编号
            struct_ygll.p_xm = tbx_xm.Text.Trim().ToString();//姓名
            struct_ygll.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门
            struct_ygll.p_gwdm = ddlt_gwdm.SelectedValue.ToString().Trim();//岗位
            struct_ygll.p_userid = _usState.userID;
            DataTable dt = new DataTable();
            //是否是管理员
            if (SysData.SFS_GLY(_usState.userLoginName))
            {
                int count = ygll.Select_YGLLCount(struct_ygll);
                pg_fy.TotalRecord = count;
                struct_ygll.p_currentpage = pg_fy.CurrentPage;
                struct_ygll.p_pagesize = pg_fy.NumPerPage;
                dt = ygll.Select_YGLL_Pro(struct_ygll);
            }
            else {              
                int count = ygll.Select_YGLLCount_Ptyg(struct_ygll);
                pg_fy.TotalRecord = count;
                struct_ygll.p_currentpage = pg_fy.CurrentPage;
                struct_ygll.p_pagesize = pg_fy.NumPerPage;
                dt = ygll.Select_YGLL_Pro_Ptyg(struct_ygll);
            }
            dt.Columns.Add("bm");
            dt.Columns.Add("gw");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gw"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;

            }

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            if (ddlt_bmdm.SelectedValue == "-2")
            {
                Response.Write("<script>alert('请选择部门！')</script>");
                return;
            }
            bind_Main();
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            string bmdm = content[1];
            if (e.CommandName == "Edit")
            {
                if (SysData.HasThisBMQX(_usState.userID, bmdm, "110303"))
                {
                    Server.Transfer("LL_Edit.aspx?ygbh=" + e.CommandArgument.ToString()+ "&bmdm="+bmdm);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有管理权限！\")</script>");
                    return;
                }
                
            }
           
            //else if (e.CommandName == "Delete")
            //{
            //    struct_ygll = new Struct_Select_YGLL();
            //    string bh = e.CommandArgument.ToString();
            //    //DataTable dt_detail = new DataTable();
            //    //dt_detail = ygll.Select_YGLL_BYBH(bh);
            //    string p_czxx = "位置：员工管理->履历管理->删除    描述：员工编号：["+ bh+"]";
            //    ygll.Delete_YGLL_byBH(bh,"03",p_czxx);
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            //}
             bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

       

   

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{

            //    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = false;

            //}
        }

        //protected void btn_gjjs_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("../JianSuo/JS_YGXX.aspx", true);
        //}

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bmdm.SelectedValue;
            GW(bm);
        }
    }
}










