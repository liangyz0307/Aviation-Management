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
    public partial class GWGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private BMGW bmgw;
        private MKG.Struct_GW struct_gw;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            if (_usState.userSFSCDL == "0")
            {
                Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_HT_GW;
            psize = _usState.C_HT_GW;
            bmgw = new BMGW(_usState);
            struct_gw = new MKG.Struct_GW();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
            }
        }

      
        private void ddltBind()
        {
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            //部门代码
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //部门类别
            ddlt_bmlb.DataSource = SysData.BMLB() .Copy();
            ddlt_bmlb.DataTextField = "mc";
            ddlt_bmlb.DataValueField = "bm";
            ddlt_bmlb.DataBind();
            ddlt_bmlb.Items.Insert(0, new ListItem("全部", "-1"));


        }
     
        private DataTable table_zdm(DataTable dt)
        {
            dt.Columns.Add("bm", typeof(string));
            dt.Columns.Add("gw", typeof(string));
            dt.Columns.Add("bmlb", typeof(string));
            dt.Columns.Add("ztmc", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString().Trim()).mc;
                dr["gw"] = SysData.GWByKey(dr["gwdm"].ToString().Trim()).mc;
                dr["bmlb"] = SysData.bmlbByKey(dr["lb"].ToString().Trim()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString().Trim()).mc;
            }
           
            return dt;
        }
        private void bind_Main()
        {
            struct_gw.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            struct_gw.p_gwdm = tbx_gwdm.Text.ToString().Trim();//岗位代码
            struct_gw.p_gwmc = tbx_gwmc.Text.ToString().Trim();//岗位名称
            struct_gw.p_lb = ddlt_bmlb.SelectedValue.ToString().Trim();//部门类别
            struct_gw.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            int count = bmgw.Select_GW_Count(struct_gw);
            pg_fy.TotalRecord = count;
            struct_gw.p_currentpage = pg_fy.CurrentPage;
            struct_gw.p_pagesize= pg_fy.NumPerPage;
            DataTable dt = bmgw.Select_GW_Pro(struct_gw).Tables[0];
            table_zdm(dt);
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
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
            if (e.CommandName == "Edit")
            {
                string gwdm = e.CommandArgument.ToString();
                Response.Redirect("../HouTai/GW_Edit.aspx?gwdm=" + gwdm + "");
            }
            else if (e.CommandName == "Delete")
            {
                string gwdm = e.CommandArgument.ToString();
                //DataTable dt = new DataTable();
                //dt = bmgw.Select_BMbyBMDM(bmdm).Tables[0];
                string p_czxx = "位置：后台管理->岗位管理->删除      描述：岗位编号：【" + gwdm + "】      ";
                bmgw.Delete_GW(gwdm,"03",p_czxx);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");

            }
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/GW_Add.aspx");
        }

        //protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string bm = ddlt_bmdm.SelectedValue;
        //    GW(bm);
        //}
    }
}










