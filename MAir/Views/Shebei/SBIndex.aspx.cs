using System;
using Sys;
using CUST.Sys;

namespace CUST.WKG
{
    public partial class SBIndex : System.Web.UI.Page
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
            lbl_yhm.Text = _usState.userXM;
           MenuDIsplay();
        }

        protected void btn_tc_Click(object sender, EventArgs e)
        {

            Response.Redirect("../../Login.aspx", true);
            Session.Clear();
            Session["YGState"] = null;
        }        //判断权限,显示菜单
        private void MenuDIsplay()
        {
            if (_usState.userSS == "01")
            {
                title.Text = "长春航务保障部";
            }
            else if (_usState.userSS == "02")
            {
                title.Text = "延吉航务保障部";
            }
            else if (_usState.userSS == "03")
            {
                title.Text = "长白山航务保障部";
            }
            else if (_usState.userSS == "04")
            {
                title.Text = "通化航务保障部";
            }
            else if (_usState.userSS == "05")
            {
                title.Text = "白城航务保障部";
            }
            
        }
    }
     
    }
