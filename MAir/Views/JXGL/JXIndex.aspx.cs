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

using System.Text;
using CUST.Tools;
using CUST;
using CUST.Sys;
using Sys;

namespace CUST.WKG
{
    public partial class JXIndex : System.Web.UI.Page
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
            QX_ZXT();//判断权限
            lbl_yhm.Text = _usState.userXM;
        }

        protected void btn_tc_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Login.aspx", true);
            Session.Clear();
            Session["UserState"] = null;
        }
        //后台权限
        private void QX_ZXT()
        {
            //判断是否为普通员工
            if (!SysData.SFS_GLY(_usState.userLoginName))
            {
                grjx_pcx.Visible = false;
                grjx_pcfa.Visible = false;
                jgrjx_jxzfa.Visible = false;
                grjx_tjzfa.Visible = false;
                grjx_grjxzf.Visible = false;

                bmjx_pcx.Visible = false;
                bmjx_pcfa.Visible = false;
                bmjx_bmzfa.Visible = false;
                bmjx_tjzfa.Visible = false;
                bmjx_bmjxzf.Visible = false;
            }
        }
    }

}
