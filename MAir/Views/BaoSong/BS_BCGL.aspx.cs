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

namespace CUST.MKG
{
    public partial class BS_BCGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        public BCGL bcgl;
        private Struct_BCGL struct_bcgl;
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
            bcgl = new BCGL(_usState);
            struct_bcgl = new Struct_BCGL();
            if (!IsPostBack)
            {
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
                ddltBind();
                bind_Main();
                //show();
            }
        }
        private void ddltBind()
        {
            DataTable dt = bcgl.Select_YGByBMDQ("-1", "-1");
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
            ddlt_zbld.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            if (tbx_kssj.Text == "")
            {
                struct_bcgl.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_bcgl.p_kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始日期       
            }
            if (tbx_jssj.Text == "")
            {
                struct_bcgl.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_bcgl.p_jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//开始日期               
            }
            if (!IsPostBack)
            {
                struct_bcgl.p_zbld = ddlt_zbld.SelectedValue.ToString();
            }
            else
            {
                if (ddlt_zbld.SelectedValue.ToString() == "-1")
                {
                    struct_bcgl.p_zbld = "-1";
                }
                else
                {
                    struct_bcgl.p_zbld = ddlt_zbld.SelectedValue.ToString() + ",";
                }
            }
            struct_bcgl.p_userid = _usState.userID;

            DataTable dt = new DataTable();
            int count = bcgl.Select_BCGL_Count(struct_bcgl);
            pg_fy.TotalRecord = count;
            struct_bcgl.p_currentpage = pg_fy.CurrentPage;
            struct_bcgl.p_pagesize = pg_fy.NumPerPage;
            dt = bcgl.Select_BCGL_Pro(struct_bcgl);

            dt.Columns.Add("rqmc");
            DateTime dt_rq = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {
                string zbld = dr["zbld"].ToString();
                string[] zblds = zbld.Split(',');
                dr["zbld"] = "";
                for (int n = 0; n < zblds.Length-1; n++)
                {
                    dr["zbld"] += bcgl.Select_YGXMbyBH(zblds[n]).Rows[0]["xm"].ToString() + ' ';
                }
               /* string ttzb = dr["ttzb"].ToString();
                string[] ttzbs = ttzb.Split(',');
                dr["ttzb"] = "";
                for (int n = 0; n < ttzbs.Length - 1; n++)
                {
                    dr["ttzb"] += bcgl.Select_YGXMbyBH(ttzbs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/
                //塔台值班
                string[] Array_ttzb = dr["ttzb"].ToString().Split(',');
                dr["ttzb"] = "";
                foreach (string ttzb_bh in Array_ttzb)
                {
                    dr["ttzb"] += bcgl.Select_YGXMbyBH(ttzb_bh.ToString()).Rows[0]["xm"].ToString() + ' ';

                }
                /*  string ffzb = dr["ffzb"].ToString();
                  string[] ffzbs = ffzb.Split(',');
                  dr["ffzb"] = "";
                  for (int n = 0; n < ffzbs.Length - 1; n++)
                  {
                      dr["ffzb"] += bcgl.Select_YGXMbyBH(ffzbs[n]).Rows[0]["xm"].ToString() + ' ';
                  }*/

                //飞服值班
                string[] Array_ffzb = dr["ffzb"].ToString().Split(',');
                dr["ffzb"] = "";
                foreach (string ffzb_bh in Array_ffzb)
                {
                    dr["ffzb"] += bcgl.Select_YGXMbyBH(ffzb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }
                /*  string tdzb = dr["tdzb"].ToString();
                  string[] tdzbs = tdzb.Split(',');
                  dr["tdzb"] = "";
                  for (int n = 0; n < tdzbs.Length; n++)
                  {
                      dr["tdzb"] += bcgl.Select_YGXMbyBH(tdzbs[n]).Rows[0]["xm"].ToString() + ' ';
                  }*/
                //通导值班
                string[] Array_tdzb = dr["tdzb"].ToString().Split(',');
                dr["tdzb"] = "";
                foreach (string tdzb_bh in Array_tdzb)
                { 
                    dr["tdzb"] += bcgl.Select_YGXMbyBH(tdzb_bh.ToString()).Rows[0][0].ToString() + ' ';

                }
           /*     string gczb = dr["gczb"].ToString();
                string[] gczbs = gczb.Split(',');
                dr["gczb"] = "";
                for (int n = 0; n < gczbs.Length - 1; n++)
                {
                    dr["gczb"] += bcgl.Select_YGXMbyBH(gczbs[n]).Rows[0]["xm"].ToString() + ' ';
                }*/


                //
                string[] Array_gczb = dr["gczb"].ToString().Split(',');
                dr["gczb"] = "";
                foreach (string gczb_bh in Array_gczb)
                {
                    dr["gczb"] += bcgl.Select_YGXMbyBH(gczb_bh.ToString()).Rows[0]["xm"].ToString() + ' ';

                }

                /* string ybzb = dr["ybzb"].ToString();
                 string[] ybzbs = ybzb.Split(',');
                 dr["ybzb"] = "";
                 for (int n = 0; n < ybzbs.Length - 1; n++)
                 {
                     dr["ybzb"] += bcgl.Select_YGXMbyBH(ybzbs[n]).Rows[0]["xm"].ToString() + ' ';
                 }*/
                //预报值班
                string[] Array_ybzb = dr["ybzb"].ToString().Split(',');
                dr["ybzb"] = "";
                foreach (string ybzb_bh in Array_ybzb)
                {
                    dr["ybzb"] += bcgl.Select_YGXMbyBH(ybzb_bh.ToString()).Rows[0]["xm"].ToString() + ' ';

                }
                dt_rq = Convert.ToDateTime(dr["rq"].ToString());
                dr["rqmc"] = string.Format("{0:yyyy-MM-dd}", dt_rq);
            }



            ///绑定分页数据源  
            this.dgdv_bcgl.DataSource = dt.DefaultView;
            this.dgdv_bcgl.DataBind();
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                Server.Transfer("../BaoSong/BS_BCGL_Edit.aspx?id=" + id);
            }
            else if (e.CommandName == "Delete")
            {
                string p_czfs = "04";
                string p_czxx = "位置：值班表->值班表管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                try
                {
                    bcgl.Delete_BCGL(id, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    bind_Main();
                }
                catch (EMException ex)
                {
                    Response.Write(EMException.ShowErrorScript(ex));
                    return;
                }
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_BCGL_Add.aspx", false);

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}
