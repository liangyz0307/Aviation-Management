using CUST;
using CUST.MKG;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class ZXXX_SP_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ZXSP zxsp;
        public string SaveFileName;
        public string FileName;
        public string firstGetFilePath;
        public string filepath;
        public string fpath;
        private Struct_ZXSP struct_zxsp;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zxsp = new ZXSP(_usState);

            if (!IsPostBack)
            {
                lbl_scr.Text = _usState.userXM.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
           
            try
            {
                struct_zxsp.wjm = tbx_wjm.Text.ToString().Trim();//文件名
                struct_zxsp.bmdm = _usState.userBMDM;//部门代码
                struct_zxsp.scr = lbl_scr.Text; ;//上传用户
                struct_zxsp.id = zxsp.SelectWDBH(struct_zxsp.id);
                struct_zxsp.sclj =" C://Users//Logan//Desktop//KG//MAir//UEdit//utf8-net//net//upload//video";//上传路径
                struct_zxsp.scsj = DateTime.Now;//上传时间
                struct_zxsp.scip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
                //struct_zbjs.lx = Request.Params["lx"];
                struct_zxsp.p_czfs = "01";
                struct_zxsp.p_czxx = "位置：在线学习->视频管理->添加      描述：视频编号：" + struct_zxsp.id;
                zxsp.Insert_ZXXX_SP(struct_zxsp);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));

                return;
            }
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
            Response.Redirect("ZXXX_SP.aspx", true);
        }
    }
}