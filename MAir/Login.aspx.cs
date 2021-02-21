using CUST;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;

namespace MAir
{
    public partial class Login : System.Web.UI.Page
    {
        private UserState _usState;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (checkYZM())
            {
                Struct_UserContext suc = new Struct_UserContext(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);
                UserState userstate = null;
                try
                {
                    userstate = new UserState(tbx_zh.Text.Trim(), tbx_mm.Text.Trim(), suc);

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                    return;
                }
                Session["UserState"] = userstate;
                DataTable dt = new DataTable();
                dt= userstate.SelectYXSJ(tbx_zh.Text.Trim()).Tables[0];
                DateTime time = DateTime.Now;//当前时间
                DateTime time_yxkssj = Convert.ToDateTime(dt.Rows[0]["yxkssj"].ToString());//有效开始时间
                DateTime time_yxjssj = Convert.ToDateTime(dt.Rows[0]["yxjssj"].ToString());//有效结束时间
                if (time >= time_yxkssj && time <= time_yxjssj)
                {
                    Response.Redirect("Views/MenHu/Sys_Index.aspx");
                }
                else {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('该账号不在有效期，请联系管理员！');</script>");

                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "");
                    return;
                }

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "用户名或密码错误！");
                return;
            }
        }
        protected bool checkYZM()//判断验证码
        {
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('验证码已过期！');</script>");
                return false;
            }
            bool right = Session["ValidateCode"].ToString() == tbx_yzm.Text.Trim();
            if (!right)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('验证码错误！');</script>");
                return false;
            }
            return right;
        }
        private void Page_Error(object sender, System.EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Write(ShowErrorScript(Server.GetLastError()));
                Response.Write(StrConvert.ShowScript("history.back();"));
                Response.End();
            }
            finally
            {
                Server.ClearError();
            }
        }
        private static string ShowErrorScript(Exception mEx)
        {
            try
            {
                throw (mEx);
            }
            catch (Exception ex)
            {
                StringBuilder ErrStr = new StringBuilder();
                ErrStr.Append("<SCRIPT LANGUAGE=\"JavaScript\">\n");
                ErrStr.Append("<!-->\n");
                ErrStr.Append("alert(\"错误！\\n\\n");
                ErrStr.Append(StrUsedToScript(ex.Message));
                ErrStr.Append("\");\n");
                ErrStr.Append("//-->\n");
                ErrStr.Append("</SCRIPT>");
                return ErrStr.ToString();
            }
         
        }
        private static string StrUsedToScript(string str)
        {
            return str.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", " ").Replace("\t", " ").Replace("\r", " ");
        }
    }
}