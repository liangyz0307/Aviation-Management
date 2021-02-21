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
    public partial class ZZGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YGZZ ygzz;
        private Struct_Select_YGZZ struct_ygzz;
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
            ygzz = new YGZZ(_usState);
            struct_ygzz = new Struct_Select_YGZZ();
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

            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));



            //岗位代码
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
            struct_ygzz.p_bh = tbx_bh.Text.Trim().ToString();//编号
            struct_ygzz.p_xm = tbx_xm.Text.Trim().ToString();//姓名
            struct_ygzz.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门
            struct_ygzz.p_gwdm = ddlt_gwdm.SelectedValue.ToString().Trim();//岗位
            struct_ygzz.p_userid = _usState.userID;
            DataTable dt = new DataTable();
            if (SysData.SFS_GLY(_usState.userLoginName))
            {
                int count = ygzz.Select_YGZZCount(struct_ygzz);
                pg_fy.TotalRecord = count;
                struct_ygzz.p_currentpage = pg_fy.CurrentPage;
                struct_ygzz.p_pagesize = pg_fy.NumPerPage;
                dt = ygzz.Select_YGZZ_Pro(struct_ygzz);

               
            }
            else {
                int count = ygzz.Select_YGZZCount_Ptyg(struct_ygzz);
                pg_fy.TotalRecord = count;
                struct_ygzz.p_currentpage = pg_fy.CurrentPage;
                struct_ygzz.p_pagesize = pg_fy.NumPerPage;
                dt = ygzz.Select_YGZZ_Pro_Ptyg(struct_ygzz);
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
                if (SysData.HasThisBMQX(_usState.userID, bmdm, "110203"))
                {
                    Server.Transfer("ZZ_Edit.aspx?ygbh=" + e.CommandArgument.ToString() + "&bmdm=" + bmdm);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有管理权限！\")</script>");
                    return;
                }

            }      
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }



        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bmdm.SelectedValue;
            GW(bm);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            

        }
    }
}










