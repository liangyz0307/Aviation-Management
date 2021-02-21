using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MAir.HouTai
{
    public partial class JS_Edit : System.Web.UI.Page
    {
        private UserState userstate;

        private YHJS js;
        private DataTable dt;
        private string jsdm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //jsbh = Request.Params["jsbh"].ToString();
            jsdm = Request.QueryString["jsdm"].ToString();
            //jcsb = new JCSB(_usState);
            js = new YHJS(userstate);
            //cpage = pg_fy.CurrentPage;
            //pg_fy.NumPerPage = _usState.C_SB_DH;
            //psize = _usState.C_SB_TX;
            if (!IsPostBack)
            {
                bind_select();
            }

        }

        private void bind_select()
        {
            dt = js.Select_JSbyJSDM(jsdm);


            tbx_jsmc.Text = dt.Rows[0]["jsmc"].ToString();
            tbx_bz.Text = dt.Rows[0]["jsmc"].ToString();

        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string jsmc = tbx_jsmc.Text.ToString();


            string bz = tbx_bz.Text.ToString();

            string czxx = "位置：后台管理->角色管理->编辑  角色代码：" + jsdm;


            DataTable dt = js.Select_JSbyJSDM(jsdm);
            DataRow dt_row = dt.Rows[0];
            if (jsmc != dt_row["jsmc"].ToString())
            {
                czxx += "角色名称：【" + dt_row["jsmc"].ToString() + "】->【" + jsmc + "】";
            }
            if (bz != dt_row["bz"].ToString())
            {
                czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + bz + "】";
            }
            try
            {
                string czfs = "01";
                js.Update_JS(jsdm,jsmc, bz, czfs, czxx);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"保存成功！\")</script>");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("JS_GL.aspx");
        }
    }
}