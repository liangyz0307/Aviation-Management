using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG.MenHu.main
{
    public partial class Sys_DQZC : System.Web.UI.MasterPage
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
            if (!IsPostBack)
            {
              
                show();
               
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_zzjg = false;
          // Boolean flag_zbjs = false;
            Boolean flag_dygl = false;
            Boolean flag_dqghdt = false;
            Boolean flag_dszs = false;
            Boolean flag_dyzx = false;
            //默认隐藏添加按钮
            zzjg.Visible = false;
           // zbjs.Visible = false;
            dygl.Visible = false;
            dqghdt.Visible = false;
            dszs.Visible = false;
            dyzx.Visible = false;
        
          
            //
            if (SysData.HasThisBMQX( _usState.userID,"220201") == true)
            {
                flag_dygl = true;
            }
           
            //
            if (SysData.HasThisBMQX( _usState.userID,"220301") == true)
            {
                flag_dyzx = true;
            }
           
            //
            if (SysData.HasThisBMQX( _usState.userID,"220402") == true)
            {
                flag_dqghdt = true;
            }
           
            //
            if (SysData.HasThisBMQX( _usState.userID,"220501") == true)
            {
                flag_zzjg = true;
            }
           
            //
            if (SysData.HasThisBMQX( _usState.userID,"220602") == true)
            {
                flag_dszs = true;
            }
          
            
           // if (flag_zbjs) { zbjs.Visible = true; }
            if (flag_dygl) { dygl.Visible = true; }
            if (flag_dyzx) { dyzx.Visible = true; }
            if (flag_dqghdt) { dqghdt.Visible = true; }
            if (flag_zzjg) { zzjg.Visible = true; }
            if (flag_dszs) { dszs.Visible = true; }

        }
        protected void zbjs_Click(object sender, EventArgs e)
        {
            if (SysData.HasThisBMQX(_usState.userID, "220101") == true)
            {
                Response.Redirect("ZBJS_Index.aspx");
            }
            else
            {
                Response.Redirect("ZBJSShow_Index.aspx");
            }
          
        }

        protected void dqghdt_ServerClick(object sender, EventArgs e)
        {
            if (SysData.HasThisBMQX(_usState.userID, "220401") == true)
            {
                Response.Redirect("DQZC_DQGHDT.aspx");
            }
            else
            {
                Response.Redirect("DQGHDTShow.aspx");
            }
        }
    }
}