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
    public partial class AL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ALK alk;
        public string SaveFileName;
        public string FileName;
        public string firstGetFilePath;
        public string filepath;
        public string fpath;
        public string cpage;

        public Struct_ALK struct_alk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            alk = new ALK(_usState);
            if (!IsPostBack)
            {
                //案例来源
                ddlt_ally.DataSource = SysData.ALLY().Copy();
                ddlt_ally.DataTextField = "mc";
                ddlt_ally.DataValueField = "bm";
                ddlt_ally.DataBind();
                ddlt_ally.Items.Insert(0, new ListItem("请选择", "-1"));
                //案例类型1
                ddlt_allx1.DataSource = SysData.ALLX1().Copy();
                ddlt_allx1.DataTextField = "mc";
                ddlt_allx1.DataValueField = "bm";
                ddlt_allx1.DataBind();
                ddlt_allx1.Items.Insert(0, new ListItem("请选择", "-1"));
                //案例类型2
                ddlt_allx2.DataSource = SysData.ALLX2().Copy();
                ddlt_allx2.DataTextField = "mc";
                ddlt_allx2.DataValueField = "bm";
                ddlt_allx2.DataBind();
                ddlt_allx2.Items.Insert(0, new ListItem("请选择", "-1"));
                //案例等级
                ddlt_aldj.DataSource = SysData.ALDJ().Copy();
                ddlt_aldj.DataTextField = "mc";
                ddlt_aldj.DataValueField = "bm";
                ddlt_aldj.DataBind();
                ddlt_aldj.Items.Insert(0, new ListItem("请选择", "-1"));

                //数据所在部门
                ddlt_sjszbm.DataSource = SysData.BM().Copy();
                ddlt_sjszbm.DataTextField = "mc";
                ddlt_sjszbm.DataValueField = "bm";
                ddlt_sjszbm.DataBind();
                ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        protected void ddlt_allx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlt_allx2.DataTextField = "mc";
            ddlt_allx2.DataValueField = "bm";
            ddlt_allx2.DataSource = SysData.ALLX2(ddlt_allx1.SelectedValue.ToString()).Copy();
            ddlt_allx2.DataBind();
            ddlt_allx2.Items.Insert(0, new ListItem("请选择", "-1"));
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
             #region MyRegion
             int flag = 0;
             //案例名
             string alm = tbx_alm.Text.ToString().Trim();
             if (string.IsNullOrEmpty(alm))
             {

                 lbl_alm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                 flag = 1;
             }
             else
             {
                 lbl_alm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
             }
             //案例发生时间
             string fssj = tbx_fssj.Text.ToString().Trim();
             if (string.IsNullOrEmpty(fssj))
             {

                 lbl_fssj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                 flag = 1;
             }
             else
             {
                 lbl_fssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
             }
             //案例分析
             string alfx = tbx_alfx.Text.ToString().Trim();
             if (string.IsNullOrEmpty(alfx))
             {

                 lbl_alfx.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                 flag = 1;
             }
             else
             {
                 lbl_alfx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
             }
             //案例描述
             string alms = tbx_alms.Text.ToString().Trim();
             if (string.IsNullOrEmpty(alms))
             {

                 lbl_alms.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                 flag = 1;
             }
             else
             {
                 lbl_alms.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
             }
             //案例来源
             if (ddlt_ally.SelectedValue.Trim() == "-1")
             {

                 lbl_ally.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                 flag = 1;
             }
             else
             {
                 lbl_ally.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

             }
             //案例类型
             if (ddlt_allx1.SelectedValue.Trim() == "-1")
             {

                 lbl_allx1.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                 flag = 1;
             }
             else
             {
                 lbl_allx1.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

             }
             //案例类型
             //if (ddlt_allx2.SelectedValue.Trim() == "-1")
             //{

             //    lbl_allx2.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
             //    flag = 1;
             //}
             //else
             //{
             //    lbl_allx2.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

             //}
             //案例等级
             if (ddlt_aldj.SelectedValue.Trim() == "-1")
             {

                 lbl_aldj.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                 flag = 1;
             }
             else
             {
                 lbl_aldj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

             }
           // 数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
             #endregion
             #region 上传
             struct_alk.p_scgw = alk.SelectALMaxBH(struct_alk.p_scgw);
             if (struct_alk.p_albh != "")
             {
                 if (AttachFile.HasFile)
                 {

                     FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀

                     string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                     filepath = "UpLoads/" + struct_alk.p_albh + "/";
                     fpath = System.Web.HttpContext.Current.Request.MapPath(filepath); 
                     string saveFileName = this.AttachFile.FileName;
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

                     struct_alk.p_albh = alk.SelectALMaxBH(_usState.userGWDM);
                     struct_alk.p_alm = tbx_alm.Text.ToString().Trim();//案例名
                     struct_alk.p_ally = ddlt_ally.SelectedValue.ToString().Trim();//案例来源
                     struct_alk.p_allx1 = ddlt_allx1.SelectedValue.ToString().Trim();//案例类型1
                     struct_alk.p_allx2 = ddlt_allx2.SelectedValue.ToString().Trim();//案例类型2
                     struct_alk.p_aldj = ddlt_aldj.SelectedValue.ToString().Trim();//案例等级
                     struct_alk.p_fssj = Convert.ToDateTime(tbx_fssj.Text.ToString().Trim());//发生时间
                     struct_alk.p_alfx = tbx_alfx.Text.ToString().Trim();//发生原因
                     struct_alk.sclj = SaveFileName;//上传路径
                     struct_alk.p_alms = tbx_alms.Text.ToString().Trim();//案例描述
                     struct_alk.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                     struct_alk.p_czfs = "02";
                     struct_alk.p_czxx = "位置：资料库管理->案例管理->添加      描述：案例编号：" + struct_alk.p_albh;
                     alk.Insert_AL(struct_alk);
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                     //查询操作：查询路径
                     DataTable dt = new DataTable();
                     dt = alk.Select_ALbyALBH(struct_alk.p_albh).Tables[0];
                     bind_rep(dt);
                 }
                 else
                 {
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加失败或文件正在上传中！请稍后再点击保存！\")</script>");
                 }
             }
         }
         //    #region 上传
         //    struct_alk.p_scgw = _usState.userGWDM;
         //    struct_alk.p_albh = alk.SelectALMaxBH(struct_alk.p_scgw).Trim();
         //   if (struct_alk.p_albh != "")
         //    {
         //        if (AttachFile.HasFile)
         //        {

         //            FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀
         //            string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
         //            filepath = "UpLoads/" + struct_alk.p_albh + "/";
         //            fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
         //            string zllx1 = ddlt_allx1.SelectedValue.ToString().Trim() + ddlt_allx2.SelectedValue.ToString().Trim();
         //            string saveFileName = this.MakeFileName(zllx1, FileName);
         //            SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径
         //            if (!Directory.Exists(fpath))
         //                Directory.CreateDirectory(fpath);
         //            AttachFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
         //            //string url = filepath + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName; //文件保存的路径
         //            float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

         //        }
         //    #endregion

         //        struct_alk.p_albh = alk.SelectALMaxBH(_usState.userGWDM);
         //        struct_alk.p_alm = tbx_alm.Text.ToString().Trim();//案例名
         //        struct_alk.p_ally = ddlt_ally.SelectedValue.ToString().Trim();//案例来源
         //        struct_alk.p_allx1 = ddlt_allx1.SelectedValue.ToString().Trim();//案例类型1
         //        struct_alk.p_allx2 = ddlt_allx2.SelectedValue.ToString().Trim();//案例类型2
         //        struct_alk.p_aldj = ddlt_aldj.SelectedValue.ToString().Trim();//案例等级
         //        struct_alk.p_fssj = Convert.ToDateTime(tbx_fssj.Text.ToString().Trim());//发生时间
         //        struct_alk.p_alfx = tbx_alfx.Text.ToString().Trim();//发生原因
         //        struct_alk.p_alms = tbx_alms.Text.ToString().Trim();//案例描述
         //        struct_alk.p_czfs = "01";
         //        struct_alk.p_czxx = "位置：资料库管理->案例管理->添加      描述：案例编号：" + struct_alk.p_albh;
         //        alk.Insert_AL(struct_alk);
         //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
         //    }
         //}
         private void bind_rep(DataTable dt)
         {
             dt.Columns.Add("FileName");  
             dt.Columns.Add("FileTime");
             /// dt.Columns.Add("lj");
             // dt.Columns.Add("YuanshiFileName");
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 dt.Rows[i]["FileName"] = dt.Rows[i]["alm"].ToString();//个人技术档案名称
                 DateTime dt_scsj = Convert.ToDateTime(dt.Rows[i]["scsj"].ToString());
                 dt.Rows[i]["FileTime"] = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_scsj);//上传时间
                 //if (dt.Rows[i]["FileName_js"].ToString()=="" && dt.Rows[i]["FileName_px"].ToString()==""&& dt.Rows[i]["FileName_jy"].ToString()=="")
                 //{
                 //        dt.Rows.Remove(dt.Rows[i]);
                 //}
             }
             //  dt.Select("FileName_js is not null");

             //Repeater1.DataSource = dt;
             //Repeater1.DataBind();

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
            Response.Redirect("../ZiLiao/ALGL.aspx", true);
        }




    }
}
