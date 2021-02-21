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

namespace CUST.WKG
{
    public partial class BS_YS : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YS ys;
        private Struct_Select_YS struct_select_ys;
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
            psize = pg_fy.NumPerPage;
            ys = new YS(_usState);
            struct_select_ys = new Struct_Select_YS();
            if (!IsPostBack)
            {
                //ddltBind();
                bind_Main();
            }
        }
        private void ddltBind()
        {
            //报送类型
            //ddlt_bslx.DataSource = SysData.BSLX().Copy();
            //ddlt_bslx.DataTextField = "mc";
            //ddlt_bslx.DataValueField = "bm";
            //ddlt_bslx.DataBind();
            //ddlt_bslx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_select_ys.p_bsbh = tbx_bsbh.Text.ToString().Trim();//报送编号
            struct_select_ys.p_bsyg = tbx_bsygbh.Text.ToString().Trim();//报送员工
            struct_select_ys.p_xm = tbx_bsygxm.Text.ToString().Trim();//姓名
            struct_select_ys.p_bslx = "07";// ddlt_bslx.SelectedValue.ToString().Trim();//姓名

            int count = ys.Select_YS_Count(struct_select_ys);
            pg_fy.TotalRecord = count;
            struct_select_ys.p_currentpage = pg_fy.CurrentPage;
            struct_select_ys.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = ys.Select_YS_Pro(struct_select_ys);
            dt.Columns.Add("bm");
            dt.Columns.Add("gw");
            dt.Columns.Add("bsgwmc");
            dt.Columns.Add("bslxmc");
            dt.Columns.Add("bssjlx");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sqbmmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["sqbmmc"] = SysData.BMByKey(dr["sqbm"].ToString()).mc;
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gw"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                dr["bsgwmc"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;
                dr["bslxmc"] = SysData.BSLXByKey(dr["bslx"].ToString()).mc;
                dr["bssjlx"] = Convert.ToDateTime(dr["bssj"].ToString()).ToString("yyyy-MM-dd");
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;
            }
            // table_zdm(dt);
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_YS_Add.aspx", true);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Server.Transfer("../BaoSong/BS_YS_Edit.aspx?bsbh=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Delete")
            {
                string bsbh = e.CommandArgument.ToString();
                string czxx = "位置：航务综合信息报送系统->预算->删除 报送编号：" + bsbh;
                string czfs = "03";
                ys.Delete_YS_byBH(bsbh, czfs, czxx);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('删除成功！');</script>");
            }
            bind_Main();
        }
    }
}