using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CUST.Sys;
using CUST.Tools;
using Sys;

namespace CUST.Web.MengHu.main
{
    public partial class PersonPwdXG : System.Web.UI.Page
    {
        private UserState _usState;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            if (!IsPostBack) {
                lbl_ygbh.Text = _usState.userLoginName;
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string csmm = tbx_csmm.Text.Trim();
            string nmm = tbx_nmm.Text.Trim();
            string qnmm = tbx_qnmm.Text.Trim();
            if (string.IsNullOrEmpty(csmm))
            {
                Response.Write("<script>alert('请填写初始密码！')</script>");
                return;
            }
            else if (string.IsNullOrEmpty(nmm))
            {
                Response.Write("<script>alert('请填写新密码！')</script>");
                return;
            }
            else if (string.IsNullOrEmpty(qnmm))
            {
                Response.Write("<script>alert('请填写确认密码！')</script>");
                return;
            }
            else if (!nmm.Equals(qnmm))
            {
                Response.Write("<script>alert('新密码和确认密码不一致！')</script>");
                tbx_nmm.Text = "";
                tbx_qnmm.Text = "";
                return;
            }
         
            _usState.updateusermm(lbl_ygbh.Text.Trim(), csmm, nmm);
            Session.Clear();
            Session["YGState"] = null;
            Response.Write("<script>alert(\"您当前的密码已修改成功，请重新登录！\");window.top.location.href='../../Login.aspx';</script>");
            Response.End();
            return;
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
    }
}
