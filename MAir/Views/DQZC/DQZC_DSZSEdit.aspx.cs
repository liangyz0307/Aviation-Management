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
    public partial class DQZC_DSZSEdit : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        public bool flag = true;
        public int i = 0;
        public int cpage;
        public int psize;
        private DSZS dszs;
        private Struct_DSZS struct_DSZS;
        private DataTable dt_detail;
        private static DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dszs = new DSZS(_usState);
            if (!IsPostBack)
            {
                tbx_fbsj.Attributes.Add("readonly", "readonly");
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }

        private void select_detail()
        {
            dt_detail = dszs.Select_DSZS_Detail(id);
            tbx_bt.Text = dt_detail.Rows[0]["bt"].ToString();//标题
            tbx_nr.Text = dt_detail.Rows[0]["nr"].ToString();//内容
            lbl_fbr.Text = dt_detail.Rows[0]["fbr"].ToString();//发布人
            tbx_fbsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["fbsj"]); //发布时间
            lbl_czsj.Visible = false;
            lbl_fbip.Visible = false;
          //  lbl_czsj.Text = dt_detail.Rows[0]["czsj"].ToString();//操作时间
            lbl_fbip.Text = dt_detail.Rows[0]["fbip"].ToString();//发布IP

        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            #region
            int flag = 0;
            //标题
            string bt = tbx_bt.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bt))
            {

                lbl_bt.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //内容
            string nr = tbx_nr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(nr))
            {

                lbl_nr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_nr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //发布时间
            string fbsj = tbx_fbsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(fbsj))
            {

                lbl_fbsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fbsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1) { return; }
            #endregion

            if (tbx_fbsj.Text.Trim().ToString().Equals(""))
            {
                struct_DSZS.p_fbsjks = new DateTime();
                struct_DSZS.p_fbsjjs = new DateTime();
            }
            else
            {
                struct_DSZS.p_fbsjks = DateTime.Parse(tbx_fbsj.Text.Trim().ToString());//开始日期
                struct_DSZS.p_fbsjjs = DateTime.Parse(tbx_fbsj.Text.Trim().ToString());//结束日期
            }
            struct_DSZS.p_id = Convert.ToInt32(Request.Params["id"].ToString());//id
            struct_DSZS.p_bt = tbx_bt.Text.ToString().Trim();//标题
            struct_DSZS.p_nr = tbx_nr.Text.ToString().Trim();//内容
            struct_DSZS.p_fbr = lbl_fbr.Text.ToString().Trim();//发布人
            struct_DSZS.p_czsj = DateTime.Parse(DateTime.Now.ToString()); //操作时间
            struct_DSZS.p_fbip = lbl_fbip.Text.ToString().Trim();//发布IP

            struct_DSZS.p_czfs = "02";
            struct_DSZS.p_czxx = "03";
            struct_DSZS.p_czxx = "位置：党群之窗->党史知识->编辑   描述：员工编号：" + _usState.userLoginName
                 + "起始日期：" + struct_DSZS.p_fbsjjs + "截止日期：" + struct_DSZS.p_fbsjks
                + "备注：";

            dszs.Update_DSZS(struct_DSZS);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            Server.Transfer("DQZC_DSZS.aspx?ygbh=" + _usState.userLoginName);
            tbx_bt.Text = "";
            tbx_nr.Text = "";
            tbx_fbsj.Text = "";
        }

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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Server.Transfer("DQZC_DSZS.aspx?id=" + _usState.userLoginName);
        }
    }
}