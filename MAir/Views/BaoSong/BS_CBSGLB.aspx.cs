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
    public partial class BS_CBSGLB : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        public CBSGL cbsgl;
        public Struct_CBSGL struct_cbsgl;
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
            cbsgl = new CBSGL(_usState);
            struct_cbsgl = new Struct_CBSGL();
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
            //值班领导
            DataTable dt = new DataTable();
            dt = cbsgl.Select_YGByBMDQ("-1", "-1");
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
            ddlt_zbld.Items.Insert(0, new ListItem("全部", "-1"));
        }
        #endregion

        protected void bind_Main()
        {
            if (!IsPostBack)
            {
                struct_cbsgl.p_zbld = ddlt_zbld.SelectedValue.ToString();
            }
            else
            {
                if (ddlt_zbld.SelectedValue.ToString() == "-1")
                {
                    struct_cbsgl.p_zbld = "-1";
                }
                else
                {
                    struct_cbsgl.p_zbld = ddlt_zbld.SelectedValue.ToString() + ",";
                }
            }
            struct_cbsgl.p_userid = _usState.userID;
            if (tbx_kssj.Text.Trim().ToString() == "")
            {
                struct_cbsgl.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_cbsgl.p_kssj = Convert.ToDateTime(tbx_kssj.Text.Trim().ToString().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {
                struct_cbsgl.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_cbsgl.p_jssj = Convert.ToDateTime(tbx_jssj.Text.Trim().ToString().ToString());//结束时间
            }

            DataTable dt = new DataTable();
            int count = cbsgl.Select_CBSGL_Count(struct_cbsgl);
            struct_cbsgl.p_currentpage = pg_fy.CurrentPage;
            struct_cbsgl.p_pagesize = pg_fy.NumPerPage;
            dt = cbsgl.Select_CBSGL_Pro(struct_cbsgl);
            
            dt.Columns.Add("rqmc");
            DateTime dt_rq = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {
                string zbld = dr["zbld"].ToString();
                string[] zblds = zbld.Split(',');
                dr["zbld"] = "";
                for (int n = 0; n < zblds.Length-1; n++)
                {
                    dr["zbld"] += cbsgl.Select_YGXMbyBH(zblds[n]).Rows[0]["xm"].ToString() + ' ';
                }
               
                //塔台值班
                string[] Array_ttzb = dr["ttzb"].ToString().Split(',');
                dr["ttzb"] = "";
                foreach (string dhbzs_bh in Array_ttzb)
                {
                    dr["ttzb"] += cbsgl.Select_YGXMbyBH(dhbzs_bh.ToString()).Rows[0][0].ToString()+" ";                   
                }
         
                //站调值班               
                string[] Array_zdzb = dr["zdzb"].ToString().Split(',');
                dr["zdzb"] = "";
                foreach (string zdzb_bh in Array_zdzb)
                {
                    dr["zdzb"] += cbsgl.Select_YGXMbyBH(zdzb_bh.ToString()).Rows[0]["xm"].ToString() + ' ';
                }

                //通导值班
                string[] Array_tdzb = dr["tdzb"].ToString().Split(',');
                dr["tdzb"] = "";             
                foreach (string tdzb_bh in Array_tdzb)
                {
                    dr["tdzb"] += cbsgl.Select_YGXMbyBH(tdzb_bh.ToString()).Rows[0]["xm"].ToString() + ' ';
                }

                //气象预报
                string[] Array_qxyb = dr["qxyb"].ToString().Split(',');
                dr["qxyb"] = "";
                foreach (string qxyb_bh in Array_ttzb)
                {
                    dr["qxyb"] += cbsgl.Select_YGXMbyBH(qxyb_bh.ToString()).Rows[0]["xm"].ToString() + ' ';
                }

                //观测
                string[] Array_gc = dr["gc"].ToString().Split(',');
                dr["gc"] = "";
                foreach (string gc_bh in Array_ttzb)
                {
                    dr["gc"] += cbsgl.Select_YGXMbyBH(gc_bh.ToString()).Rows[0]["xm"].ToString() + ' ';
                }

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
            Response.Redirect("../BaoSong/BS_CBSGLB_Add.aspx", true);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                Server.Transfer("../BaoSong/BS_CBSGLB_Edit.aspx?id=" + id);
            }
            if (e.CommandName == "Delete")
            {
                string p_czfs = "04";
                string p_czxx = "位置：值班表->值班表管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                try
                {
                    cbsgl.Delete_CBSGL(id, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('删除成功');location.href='BS_CBSGLB.aspx';</script>");
                    bind_Main();
                }
                catch (EMException ex)
                {
                    Response.Write(EMException.ShowErrorScript(ex));
                    return;
                }
            }
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}