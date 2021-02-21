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
    public partial class BMGL : System.Web.UI.Page

    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private BMGW bmgw;
        private MKG.Struct_BM struct_bm;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_HT_BM;
            psize = _usState.C_HT_BM;
            bmgw = new BMGW(_usState);
            struct_bm = new MKG.Struct_BM();
            if (!IsPostBack)
            {

                ddltBind();
                bind_Main();
            }
        }

      
        private void ddltBind()
        {
            
            //状态
            ddlt_zt.DataSource = SysData.ZT().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

            //部门类别(暂用用户类别)
            ddlt_bmlb.DataSource = SysData.YHLB().Copy();
            ddlt_bmlb.DataTextField = "mc";
            ddlt_bmlb.DataValueField = "bm";
            ddlt_bmlb.DataBind();
            ddlt_bmlb.Items.Insert(0, new ListItem("全部", "-1"));


        }

        private DataTable table_zdm(DataTable dt)
        {
            dt.Columns.Add("bm", typeof(string));
            dt.Columns.Add("sjbm", typeof(string));
            dt.Columns.Add("lb", typeof(string));
            dt.Columns.Add("ztmc", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] =  SysData.BMByKey(dr["bmdm"].ToString().Trim()).mc;
                dr["sjbm"] = SysData.BMByKey(dr["sjbmdm"].ToString().Trim()).mc;
                dr["lb"] = SysData.YHLBByKey(dr["bmlb"].ToString().Trim()).mc;//
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString().Trim()).mc;
            }
           
            return dt;
        }
        private void bind_Main()
        {
            struct_bm.p_bmdm =tbx_bmdm.Text.ToString().Trim();//部门代码
            struct_bm.p_bmmc = tbx_bmmc.Text.ToString().Trim();//部门名称
            struct_bm.p_bmlb= ddlt_bmlb.SelectedValue.ToString().Trim();//部门代码类别
            struct_bm.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态

            int count = bmgw.Select_BM_Count(struct_bm);
            pg_fy.TotalRecord = count;
            struct_bm.p_currentpage = pg_fy.CurrentPage;
            struct_bm.p_pagesize= pg_fy.NumPerPage;
            DataTable dt = bmgw.Select_BM_Pro(struct_bm).Tables[0];

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
                string bmdm = e.CommandArgument.ToString();

                Response.Redirect("../HouTai/BM_Edit.aspx?bmdm=" + bmdm + "");
                //Server.Transfer("ZD_Edit.aspx?BH=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Delete")
            {
                string bmdm = e.CommandArgument.ToString();
                //DataTable dt = new DataTable();
                //dt = bmgw.Select_BMbyBMDM(bmdm).Tables[0];
                string p_czxx = "位置：后台管理->部门管理->删除      描述：部门编号：【" + bmdm + "】      ";
                bmgw.Delete_BM(bmdm,"03",p_czxx);
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
            Response.Redirect("../HouTai/BM_Add.aspx");
        }

     
    }
}










