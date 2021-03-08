using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sys;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using System.Data;
using System.Globalization;

namespace CUST.WKG
{
    public partial class BS_HWGLB : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        public HWGLB hwglb;
        public Struct_HWGLB struct_hwglb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = _usState.C_ZL_ZJ;
            hwglb = new HWGLB(_usState);
            struct_hwglb = new Struct_HWGLB();
            if (!IsPostBack)
            {
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
                ddltBind();
                bind_Main();
            }
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

        #region  绑定下拉菜单
        protected void ddltBind()
        {
            //星期
            ddlt_xq.DataTextField = "mc";
            ddlt_xq.DataValueField = "bm";
            ddlt_xq.DataSource = SysData.XQ().Copy();
            ddlt_xq.DataBind();
            ddlt_xq.Items.Insert(0, new ListItem("全部", "-1"));
            //值班领导
            DataTable dt = new DataTable();
            dt = hwglb.Select_YGByBMDQ("-1", "-1");
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
            ddlt_zbld.Items.Insert(0, new ListItem("全部", "-1"));
        }
        #endregion

        protected void bind_Main()
        {
            struct_hwglb.p_xq = ddlt_xq.Text.ToString();
            if (!IsPostBack)
            {
                struct_hwglb.p_zbld = ddlt_zbld.SelectedValue.ToString();
            }
            else
            {
                if (ddlt_zbld.SelectedValue.ToString() == "-1")
                {
                    struct_hwglb.p_zbld = "-1";
                }
                else
                {
                    struct_hwglb.p_zbld = ddlt_zbld.SelectedValue.ToString() + ",";
                }
            }
            struct_hwglb.p_userid = _usState.userID;
            if (tbx_kssj.Text.Trim().ToString() == "")
            {
                struct_hwglb.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_hwglb.p_kssj = Convert.ToDateTime(tbx_kssj.Text.Trim().ToString().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {
                struct_hwglb.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_hwglb.p_jssj = Convert.ToDateTime(tbx_jssj.Text.Trim().ToString().ToString());//结束时间
            }

            DataTable dt = new DataTable();
        

            struct_hwglb.p_currentpage = pg_fy.CurrentPage;
            struct_hwglb.p_pagesize = pg_fy.NumPerPage;
            dt = hwglb.Select_HWGLB_Pro(struct_hwglb);
            
            dt.Columns.Add("xqmc");
            dt.Columns.Add("rqmc");
            DateTime dt_rq = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {
               /* string list = dr["dhbzs"].ToString();
                string[] lists = list.Split(',');
                dr["dhbzs"] = "";
                for (int n = 0; n < lists.Length-1; n++)
                {
                    dr["dhbzs"] += hwglb.Select_YGXMbyBH(lists[n]).Rows[0]["xm"].ToString() + ' ';
                }*/


                string[] Array_dhbzs = dr["dhbzs"].ToString().Split(',');
                dr["dhbzs"] = "";
                foreach (string dhbzs_bh in Array_dhbzs)
                {
                    dr["dhbzs"] += hwglb.Select_YGXMbyBH(dhbzs_bh.ToString()).Rows[0]["xm"].ToString() + ' ';

                }


                string zbld = dr["zbld"].ToString();
                string[] zblds = zbld.Split(',');
                dr["zbld"] = "";
                for (int n = 0; n < zblds.Length-1; n++)
                {
                    dr["zbld"] += hwglb.Select_YGXMbyBH(zblds[n]).Rows[0]["xm"].ToString() + ' ';
                }
                dr["xqmc"] = SysData.XQByKey(dr["xq"].ToString()).mc;
                dt_rq = Convert.ToDateTime(dr["rq"].ToString());
                dr["rqmc"] = string.Format("{0:yyyy-MM-dd}", dt_rq);
            }

            ///绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_HWGLB_Add.aspx", true);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                Server.Transfer("../BaoSong/BS_HWGLB_Edit.aspx?id=" + id);
            }
            if (e.CommandName == "Delete")
            {
                string p_czfs = "04";
                string p_czxx = "位置：值班表->值班表管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                try
                {
                    hwglb.Delete_HWGLB(id, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('删除成功');location.href='BS_HWGLB.aspx';</script>");
                    bind_Main();
                }
                catch (EMException ex)
                {
                    Response.Write(EMException.ShowErrorScript(ex));
                    return;
                }
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
    }
}