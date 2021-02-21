using CUST.MKG;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class DQZC_DQGHDTAdd : System.Web.UI.Page
    {
        private UserState _usState;
         static string fbr;
        public int cpage;
        public int psize;
        int id;
        public bool flag = true;
        private DQGHDT dqghdt;
        private static DataTable dt = new DataTable();
        private Struct_DQGHDT struct_DQGHDT;
         private DataTable find_DQGHDT_ById;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            dqghdt = new DQGHDT(_usState);
            if (!IsPostBack)
            {
                tbx_nr.Attributes.Add("readonly", "readonly");
                //lbl_czsj.Text = DateTime.Now.ToString();
                //lbl_fbip.Text = Page.Request.UserHostAddress.ToString();
               // lbl_fbip.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
                tbx_fbsj.Attributes.Add("readonly", "readonly");
                lbl_fbr.Text = _usState.userXM.ToString();

               // yg_bind();

            }
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {

            #region 验证
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
           // 内容
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
           // 发布时间
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
                struct_DQGHDT.p_fbsjks = new DateTime();
                struct_DQGHDT.p_fbsjjs = new DateTime();
            }
            else
            {
                struct_DQGHDT.p_fbsjks = DateTime.Parse(tbx_fbsj.Text.Trim().ToString());//开始日期
                struct_DQGHDT.p_fbsjjs = DateTime.Parse(tbx_fbsj.Text.Trim().ToString());//结束日期
            }
            struct_DQGHDT.p_bt = tbx_bt.Text.ToString().Trim();
            struct_DQGHDT.p_nr = tbx_nr.Text.ToString().Trim();
            struct_DQGHDT.p_czsj = DateTime.Parse(DateTime.Now.ToString());
            struct_DQGHDT.p_fbip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString(); ;
            struct_DQGHDT.p_fbr = lbl_fbr.Text;

            struct_DQGHDT.p_czfs = "02";
            struct_DQGHDT.p_czxx = "位置：员工管理->员工奖励->添加   描述：员工编号：" + _usState.userLoginName
                 + "起始日期：" + struct_DQGHDT.p_fbsjks + "截止日期：" + struct_DQGHDT.p_fbsjjs
                + "备注：";
            dqghdt.Insert_DQGHDT(struct_DQGHDT);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("DQZC_DQGHDT.aspx?ygbh=" + _usState.userLoginName);
            tbx_bt.Text = "";
            tbx_fbsj.Text = "";
            tbx_nr.Text = "";

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
            Server.Transfer("DQZC_DQGHDT.aspx?ygbh=" + _usState.userLoginName);
        }
    }
}