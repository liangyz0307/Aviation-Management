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
    public partial class ZXXX_WJ_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ZXXX zxxx;
        public string SaveFileName;
        public string FileName;
        public string firstGetFilePath;
        public string filepath;
        public string fpath;
        private Struct_ZXXX struct_zxxx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zxxx = new ZXXX(_usState);

            if (!IsPostBack)
            {
                lbl_scr.Text = _usState.userXM.ToString();
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
             #region 上传
            struct_zxxx.id = zxxx.SelectWDBH(struct_zxxx.bmdm);
            if (struct_zxxx.id != "")
            {
                if (AttachFile.HasFile)
                {

                    FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀

                    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                    filepath = "UpLoads/" + struct_zxxx.id + "/";
                    fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    string saveFileName = this.AttachFile.FileName;
                    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径

                    if (!Directory.Exists(fpath))
                        Directory.CreateDirectory(fpath);

                    AttachFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite); 
                    float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

                }
            #endregion
                if (!(string.IsNullOrEmpty(SaveFileName) || SaveFileName == ""))
                {

                    struct_zxxx.wjm = FileName;//文件名
                    struct_zxxx.bmdm = _usState.userBMDM;//部门代码
                    struct_zxxx.scr = lbl_scr.Text; ;//上传用户
                    struct_zxxx.id = zxxx.SelectWDBH(struct_zxxx.id);
                    struct_zxxx.sclj = SaveFileName;//上传路径
                    struct_zxxx.scsj = DateTime.Now;//上传时间
                    struct_zxxx.scip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
                    //struct_zbjs.lx = Request.Params["lx"];
                    struct_zxxx.p_czfs = "01";
                    struct_zxxx.p_czxx = "位置：在线学习->文件管理->添加      描述：文档编号：" + struct_zxxx.id;
                    zxxx.Insert_ZXXX_WJ(struct_zxxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加失败或文件正在上传中！请稍后再点击保存！\")</script>");
                }
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
            Response.Redirect("ZXXX_WJ.aspx", true);
        }

    }
}