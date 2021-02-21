using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using System.IO;
using Sys;

namespace CUST.WKG
{
    public partial class KG_ZLGL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private string p_zlbh;
        private ZLGL zlgl;
        public string SaveFileName;
        public string FileName;
        public string firstGetFilePath;
        public string filepath;
        public string fpath;
        public string cpage;
        public Struct_ZL struct_zl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zlgl = new ZLGL(_usState);
            if (!IsPostBack)
            {
                bind_drop();
            }
        }

       

        protected void bind_drop()
        {
            //资料类型一
            ddlt_zllx1.DataTextField = "mc";
            ddlt_zllx1.DataValueField = "bm";
            ddlt_zllx1.DataSource = SysData.ZLLX1().Copy();
            ddlt_zllx1.DataBind();
            //资料类型二
            ddlt_zllx2.DataTextField = "mc";
            ddlt_zllx2.DataValueField = "bm";
            ddlt_zllx2.DataSource = SysData.ZLLX2(ddlt_zllx1.SelectedValue.ToString()).Copy();
            ddlt_zllx2.DataBind();

            //数据所在部门
            ddlt_sjszbm.DataSource = SysData.BM().Copy();
            ddlt_sjszbm.DataTextField = "mc";
            ddlt_sjszbm.DataValueField = "bm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
        }

        protected string MakeFileName(string biaoshi, string exeFileString)
        {
            System.DateTime now = System.DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            string yearString = year.ToString();
            string monthString = month < 10 ? ("0" + month) : month.ToString();
            string dayString = day < 10 ? ("0" + day) : day.ToString();
            string hourString = hour < 10 ? ("0" + hour) : hour.ToString();
            string minuteString = minute < 10 ? ("0" + minute) : minute.ToString();
            string secondString = second < 10 ? ("0" + second) : second.ToString();

            string fileName = yearString + monthString + dayString + hourString + minuteString + secondString + biaoshi + exeFileString;
            return fileName;
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 上传
            struct_zl.p_zlbh = zlgl.SelectZLBH(struct_zl.p_gw);
            if (struct_zl.p_zlbh != "")
            {
                if (AttachFile.HasFile)

                {

                    FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀
                    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                    filepath = "UpLoads/" + struct_zl.p_zlbh + "/";
                    fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    string zllx1 = ddlt_zllx1.SelectedValue.ToString().Trim()+ddlt_zllx2.SelectedValue.ToString().Trim();
                    string saveFileName = this.MakeFileName(zllx1, FileName);
                    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径
                    if (!Directory.Exists(fpath))
                        Directory.CreateDirectory(fpath);
                    AttachFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                    //string url = filepath + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName; //文件保存的路径
                    float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

                }
                #endregion
                if (!(string.IsNullOrEmpty(SaveFileName) || SaveFileName == ""))
                {

                    struct_zl.p_zlm = FileName;//文件名
                    struct_zl.p_zllx1 = ddlt_zllx1.SelectedValue.ToString().Trim();//资料类型一
                    struct_zl.p_zllx2 = ddlt_zllx2.SelectedValue.ToString().Trim();//资料类型二
                    struct_zl.p_bm = _usState.userBMDM;//部门
                    struct_zl.p_gw = _usState.userGWDM;//岗位
                    struct_zl.p_yh = _usState.userLoginName;//上传用户
                    struct_zl.p_sj = DateTime.Now;//上传时间
                    struct_zl.p_zlbh = zlgl.SelectZLBH(struct_zl.p_gw);
                    struct_zl.p_wjlj = SaveFileName;//文件路径
                    struct_zl.p_sj = DateTime.Now;//上传时间
                    struct_zl.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                    struct_zl.p_czfs = "02";
                    struct_zl.p_czxx = "位置：资料库管理->资料管理->添加      描述：文档编号：" + struct_zl.p_zlbh;
                    zlgl.Insert_ZL(struct_zl);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    //Response.Redirect("../ZiLiao/KG_ZLGL.aspx", true);
      
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
            Response.Redirect("../ZiLiao/KG_ZLGL.aspx", true);
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            filepath = "UpLoads/" + struct_zl.p_zlbh + "/";
            string path = System.Web.HttpContext.Current.Request.MapPath(filepath);

           
        }

        protected void ddlt_zllx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlt_zllx2.DataTextField = "mc";
            ddlt_zllx2.DataValueField = "bm";
            ddlt_zllx2.DataSource = SysData.ZLLX2(ddlt_zllx1.SelectedValue.ToString()).Copy();
            ddlt_zllx2.DataBind();

        }
    }
}