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
    public partial class RZGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private RZ rz;
        private Struct_Select_RZ struct_rz;

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
            pg_fy.NumPerPage = _usState.C_HT_RZ;
            psize = _usState.C_HT_RZ;
            //cpage = pg_fy.CurrentPage;
            //psize = pg_fy.NumPerPage; 
            rz = new RZ(_usState);
            struct_rz = new Struct_Select_RZ();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
            }
        }


        private void ddltBind()
        {
            //绑定部门代码ddlt_bmdm
            DataTable dt_bmdm = SysData.BM().Copy();
            //DataRow dr_bmdm = dt_bmdm.NewRow();
            //dr_bmdm["mc"] = "全部";
            //dr_bmdm["bm"] = "-1";
            //dt_bmdm.Rows.InsertAt(dr_bmdm, 0);

            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "ms";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            DataTable dt_gw = new DataTable();
            ddlt_gwdm.DataSource = dt_gw;
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            //操作方式
            ddlt_czfs.DataSource = SysData.CZFS().Copy();
            ddlt_czfs.DataTextField = "ms";
            ddlt_czfs.DataValueField = "bm";
            ddlt_czfs.DataBind();
            ddlt_czfs.Items.Insert(0, new ListItem("全部", "-1"));

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
                ddlt_gwdm.DataTextField = "ms";
                ddlt_gwdm.DataValueField = "bm";
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }
        private DataTable table_zdm(DataTable dt)
        {
            dt.Columns.Add("bm", typeof(string));
            dt.Columns.Add("gw", typeof(string));
            dt.Columns.Add("fs", typeof(string));
            dt.Columns.Add("czsjmc", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = "[" + dr["bmdm"] + "]" + SysData.BMByKey(dr["bmdm"].ToString().Trim()).mc;
                dr["gw"] = "[" + dr["gwdm"] + "]" + SysData.GWByKey(dr["gwdm"].ToString().Trim()).mc;
                dr["fs"] = "[" + dr["czfs"] + "]" + SysData.CZFSByKey(dr["czfs"].ToString().Trim()).mc;
                if (dr["czsjmc"].ToString() == "")
                {
                    dr["czsjmc"] = DateTime.Parse(dr["sj"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    dr["czsjmc"] = "";
                }
            }
           
            return dt;
        }
        private void bind_Main()
        {
            struct_rz.p_bh = tbx_bh.Text.ToString().Trim();//用户编号
            struct_rz.p_xm = tbx_xm.Text.ToString().Trim();//姓名
            struct_rz.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            struct_rz.p_gwdm = ddlt_gwdm.SelectedValue.ToString().Trim();//岗位代码
            struct_rz.p_czfs = ddlt_czfs.SelectedValue.ToString().Trim();//操作方式

            int count = rz.Select_RZ_Count(struct_rz);
            pg_fy.TotalRecord = count;
            struct_rz.p_currentpage = pg_fy.CurrentPage;
            struct_rz.p_pagesize= pg_fy.NumPerPage;
            struct_rz.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = rz.Select_RZ_Pro(struct_rz);

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
     

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

       
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bmdm.SelectedValue;
            GW(bm);
        }
    }
}










