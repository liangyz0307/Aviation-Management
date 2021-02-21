using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
namespace CUST.WKG
{
    public partial class PXIndex : System.Web.UI.Page
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
            ShowMenuByQx();
        }
        /// <summary>
        /// 根据用户所拥有的权限,控制菜单栏的显示效果
        /// </summary>
        private void ShowMenuByQx()
        {
            //1.试题管理
            if (SysData.HasThisBMQX(_usState.userID,"190101") == true)
            {
                //是否显示整个
                sp_STGL.Visible = true;
                ul_STGL.Visible = true;
                li_STGL.Visible = true;
                //1.是否具有添加的权限
                if (SysData.HasThisBMQX(_usState.userID, "190102") == true)
                {
                    li_ST_XZT_Add.Visible = true;
                    li_ST_TKT_Add.Visible = true;
                    li_ST_PDT_Add.Visible = true;
                }
                else
                {
                    //隐藏
                    li_ST_XZT_Add.Visible = false;
                    li_ST_TKT_Add.Visible = false;
                    li_ST_PDT_Add.Visible = false;
                }
            }
            else
            {
                //隐藏
                sp_STGL.Visible = false;
                ul_STGL.Visible = false;
            }
            //2.策略管理
            if (SysData.HasThisBMQX(_usState.userID,"190201") == true)
            {
                sp_CLGL.Visible = true;
                ul_CLGL.Visible = true;
                if (SysData.HasThisBMQX(_usState.userID,"190202") == true)
                {
                    li_CL_Add.Visible = true;
                }
                else
                {
                    //隐藏
                    li_CL_Add.Visible = false;
                }
            }
            else
            {
                //隐藏
                sp_CLGL.Visible = false;
                ul_CLGL.Visible = false;
            }
            //3.考试管理
            if (SysData.HasThisMK("1903", _usState.userID) == true)
            {
                sp_KSGL.Visible = true;
                ul_KSGL.Visible = true;
            }
            else
            {
                //隐藏
                sp_KSGL.Visible = false;
                ul_KSGL.Visible = false;
            }
        }
        protected void btn_tc_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Login.aspx", true);
            Session.Clear();
            Session["YGState"] = null;
        }
        #region 错误处理
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
        public void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
        #endregion
    }
}
