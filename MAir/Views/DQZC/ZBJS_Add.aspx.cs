using CUST;
using CUST.MKG;
using CUST.Sys;
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

namespace MAir.Views.DQZC
{
    public partial class ZBJS_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ZBJS js;
        public string SaveFileName;
        public string FileName;
        public string firstGetFilePath;
        public string filepath;
        public string fpath;
        public Struct_zbjs struct_zbjs;
        protected void Page_Load(object sender, EventArgs e)
        {
            struct_zbjs.lx = Request.Params["tzcz"];
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new ZBJS(_usState);
            if (!IsPostBack)
            {               
                lbl_scr.Text = _usState.userXM.ToString();
                //lbl_scip.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
            }
        }
        private string MakeFileName(string biaoshi, string exeFileString)
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
            struct_zbjs.id = js.SelectWDBH(struct_zbjs.p_scgw);
            if (struct_zbjs.id != "")
            {
                if (AttachFile.HasFile)
                {

                    FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀

                    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                    filepath = "UpLoads/" + struct_zbjs.id + "/";
                    fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    //string lx = ddlt_wdlx.SelectedValue.ToString().Trim();
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

                    struct_zbjs.wjm = FileName;//文件名
                    //struct_zbjs.p_wdlx = ddlt_wdlx.SelectedValue.ToString().Trim();//文档类型
                    struct_zbjs.p_scbm = _usState.userBMDM;//部门代码
                    struct_zbjs.p_scgw = _usState.userGWDM;//岗位代码
                    struct_zbjs.scr = lbl_scr.Text; ;//上传用户
                    struct_zbjs.id = js.SelectWDBH(struct_zbjs.id);
                    struct_zbjs.sclj = SaveFileName;//上传路径
                    struct_zbjs.scsj = DateTime.Now;//上传时间
                    struct_zbjs.scip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
                    struct_zbjs.lx = Request.Params["lx"];
                    struct_zbjs.p_czfs = "01";
                    struct_zbjs.p_czxx = "位置：支部管理->文件管理->添加      描述：文档编号：" + struct_zbjs.id;
                    js.Insert_DQZC_ZBJS(struct_zbjs);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");

                    //查询操作：查询路径
                    DataTable dt = new DataTable();
                    dt = js.Select_ZLbyWDBH(struct_zbjs.id).Tables[0];
                    bind_rep(dt);
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
            struct_zbjs.lx = Request.Params["lx"];
            Response.Redirect("~/Views/DQZC/DQZC_ZBJS.aspx?lx="+Request.Params["lx"], true);
        }
        private void bind_rep(DataTable dt)
        {
            dt.Columns.Add("FileName");
            dt.Columns.Add("WDLXMC");
            dt.Columns.Add("FileTime");
            /// dt.Columns.Add("lj");
            // dt.Columns.Add("YuanshiFileName");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["FileName"] = dt.Rows[i]["wjm"].ToString();//个人技术档案名称
                dt.Rows[i]["WDLXMC"] = SysData.WDLXByKey(dt.Rows[i]["wdlx"].ToString()).mc;//业务培训档案名称
                DateTime dt_scsj = Convert.ToDateTime(dt.Rows[i]["scsj"].ToString());
                dt.Rows[i]["FileTime"] = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_scsj);//上传时间
                //if (dt.Rows[i]["FileName_js"].ToString()=="" && dt.Rows[i]["FileName_px"].ToString()==""&& dt.Rows[i]["FileName_jy"].ToString()=="")
                //{
                //        dt.Rows.Remove(dt.Rows[i]);
                //}
            }
            //  dt.Select("FileName_js is not null");

            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            filepath = "UpLoads/" + struct_zbjs.id + "/";
            string path = System.Web.HttpContext.Current.Request.MapPath(filepath);

            if (e.CommandName == "down")
            {
                try
                {
                    // string DownloadFileName = path + e.CommandArgument.ToString();//文件路径
                    string filename = e.CommandArgument.ToString();//文件名
                    string name = filename.Substring(filename.LastIndexOf("\\") + 1);

                    // string filePath = path + filename;
                    if (File.Exists(filename))
                    {
                        FileInfo fileInfo = new FileInfo(filename);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + name);
                        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                        Response.AddHeader("Content-Transfer-Encoding", "binary");
                        Response.ContentType = "application/octet-stream";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                        Response.WriteFile(fileInfo.FullName);
                        Response.Flush();
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                        Response.Redirect("~/Views/DQZC/DQZC_ZBJS.aspx");
                        Response.End();
                    }
                }
                catch { }

            }
        }
    }
}