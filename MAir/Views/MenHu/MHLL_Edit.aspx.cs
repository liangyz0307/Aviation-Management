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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class MHLL_Edit : System.Web.UI.Page
    {

        private UserState userState;
        private string id;
        private YGLL ygll;
        private Struct_YGLL struct_ygll;
        private DataTable dt_detail;
        public string filepath;
        public string fpath;
        public string SaveFileName_js;
        public string SaveFileName_px;
        public string SaveFileName_jy;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((userState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygll = new YGLL(userState);
            if (!IsPostBack)
            {
                id = Request.Params["id"].ToString();
                select_detail();
                show();
                DataTable dt = new DataTable();
                dt = ygll.Select_YGLL_Detail(Convert.ToInt32(id));
                bind_rep(dt);
            }
        }

        public void show()
        {
            tbx_gzdw.Enabled = false;
            tbx_gzgw.Enabled = false;
            tbx_gzbm.Enabled = false;
            tbx_gzdd.Enabled = false;
            tbx_jzrq.Enabled = false;
            tbx_qzrq.Enabled = false;
            tbx_bz.Enabled = false;
            btn_save.Visible = false;
            AttachFile.Enabled = false;
            AttachFile_px.Enabled = false;
            AttachFile_jy.Enabled = false;

        }
        protected void select_detail()
        {
            dt_detail = ygll.Select_YGLL_Detail(Convert.ToInt32(id));
            lbl_bh.Text = dt_detail.Rows[0]["ygbh"].ToString();//员工编号
            tbx_gzdw.Text = dt_detail.Rows[0]["gzdw"].ToString();//工作单位
            tbx_gzbm.Text = dt_detail.Rows[0]["gzbm"].ToString();//工作部门
            tbx_gzgw.Text = dt_detail.Rows[0]["gzgw"].ToString();//工作岗位
            tbx_gzdd.Text = dt_detail.Rows[0]["gzdd"].ToString();//工作地点
            tbx_qzrq.Text = dt_detail.Rows[0]["qzrq"].ToString();//起止日期
            tbx_jzrq.Text = dt_detail.Rows[0]["jzrq"].ToString();//截止日期
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();//备注
        }
        private void bind_rep(DataTable dt)
        {
            dt.Columns.Add("FileName_js");
            dt.Columns.Add("FileName_px");
            dt.Columns.Add("FileName_jy");
            dt.Columns.Add("FileTime");
            /// dt.Columns.Add("lj");
            // dt.Columns.Add("YuanshiFileName");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["FileName_js"] = dt.Rows[i]["grjsdamc"].ToString();//个人技术档案名称
                dt.Rows[i]["FileName_px"] = dt.Rows[i]["ywpxdamc"].ToString();//业务培训档案名称
                dt.Rows[i]["FileName_jy"] = dt.Rows[i]["aqjydamc"].ToString();//安全教育档案名称
              //  dt.Rows[i]["FileTime"] = dt.Rows[i]["scsj"].ToString();//上传时间
                DateTime dt_scsj = Convert.ToDateTime(dt.Rows[i]["scsj"].ToString());
                dt.Rows[i]["FileTime"] = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_scsj);//上传时间
                if (dt.Rows[i]["FileName_js"].ToString() == "" && dt.Rows[i]["FileName_px"].ToString() == "" && dt.Rows[i]["FileName_jy"].ToString() == "")
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
          
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
            
            #region 校验
            int flag = 0;

            //起止日期 
            lbl_qzrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //截止日期  
            lbl_jzrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
          
            lbl_gzdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_gzbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_gzgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_gzdd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            if (flag == 1) { return; }
            #endregion
            #region 上传
            if (lbl_bh.Text != "")
            {
                if (AttachFile.HasFile)

                {

                    string FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀

                    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                    filepath = "UpLoads/" + lbl_bh.Text + "/";
                    fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    string saveFileName = this.MakeFileName("JS", FileName);
                    SaveFileName_js = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径
               
                    if (!Directory.Exists(fpath))
                        Directory.CreateDirectory(fpath);

                    AttachFile.MoveTo(SaveFileName_js, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);

                    string url = filepath + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName; //文件保存的路径

                    float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

                }
                if (AttachFile_px.HasFile)

                {

                    string FileName = this.AttachFile_px.FileName;//获取上传文件的文件名,包括后缀

                    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                    filepath = "UpLoads/" + lbl_bh.Text + "/";
                    fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    string saveFileName = this.MakeFileName("PX", FileName);
                    SaveFileName_px = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径
                   
                    if (!Directory.Exists(fpath))
                        Directory.CreateDirectory(fpath);

                    AttachFile_px.MoveTo(SaveFileName_px, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);

                    string url = filepath + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName; //文件保存的路径

                    float FileSize = (float)System.Math.Round((float)AttachFile_px.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

                }
                if (AttachFile_jy.HasFile)

                {

                    string FileName = this.AttachFile_jy.FileName;//获取上传文件的文件名,包括后缀

                    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                    filepath = "UpLoads/" + lbl_bh.Text + "/";
                    fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    string saveFileName = this.MakeFileName("JY", FileName);
                    SaveFileName_jy = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径
             
                    if (!Directory.Exists(fpath))
                        Directory.CreateDirectory(fpath);

                    AttachFile_jy.MoveTo(SaveFileName_jy, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);

                    string url = filepath + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName; //文件保存的路径

                    float FileSize = (float)System.Math.Round((float)AttachFile_jy.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

                }
            }
                #endregion
                int check_rz = 0;
            id = Request.Params["id"].ToString();
            struct_ygll.p_id = Convert.ToInt32(id);
            struct_ygll.p_ygbh = lbl_bh.Text;
            
               
               
               
            struct_ygll.p_scsj = DateTime.Now;
                struct_ygll.p_gzdw = tbx_gzdw.Text.ToString().Trim();//工作单位
            struct_ygll.p_gzbm = tbx_gzbm.Text.ToString().Trim();//工作部门
            struct_ygll.p_gzgw = tbx_gzgw.Text.ToString().Trim();//工作岗位
            struct_ygll.p_gzdd = tbx_gzdd.Text.ToString().Trim();//工作地点
            struct_ygll.p_qzrq = tbx_qzrq.Text.ToString().Trim();//起止日期
            struct_ygll.p_jzrq = tbx_jzrq.Text.ToString().Trim();//截止日期
            struct_ygll.p_bz = tbx_bz.Text;
            struct_ygll.p_czfs = "02";
            struct_ygll.p_czxx = "位置：员工管理->履历管理->编辑    员工编号：[" + struct_ygll.p_ygbh + "]  描述：";
            dt_detail = ygll.Select_YGLL_Detail(Convert.ToInt32(id));
            //个人技术档案
            if (SaveFileName_js == null)
            {

                struct_ygll.p_grjsda = dt_detail.Rows[0]["grjsda"].ToString();
            }
            else
            {
                struct_ygll.p_grjsda = SaveFileName_js;
            }
            //业务培训档案
            if (SaveFileName_px == null)
            {

                struct_ygll.p_ywpxda = dt_detail.Rows[0]["ywpxda"].ToString();
            }
            else
            {
                struct_ygll.p_ywpxda = SaveFileName_px;
            }
            //安全教育档案
            if (SaveFileName_jy == null)
            {

                struct_ygll.p_aqjyda = dt_detail.Rows[0]["aqjyda"].ToString();
            }
            else
            {
                struct_ygll.p_aqjyda = SaveFileName_jy;
            }
            //工作单位
            if (struct_ygll.p_gzdw != dt_detail.Rows[0]["gzdw"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作单位：【" + dt_detail.Rows[0]["gzdw"].ToString() + "】->【" + struct_ygll.p_gzdw + "】";
                check_rz = 1;
            }
            //工作部门
            if (struct_ygll.p_gzbm != dt_detail.Rows[0]["gzbm"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作部门：【" + dt_detail.Rows[0]["gzbm"].ToString() + "】->【" + struct_ygll.p_gzbm + "】";
                check_rz = 1;
            }
            //工作岗位
            if (struct_ygll.p_gzgw != dt_detail.Rows[0]["gzgw"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作岗位：【" + dt_detail.Rows[0]["gzgw"].ToString() + "】->【" + struct_ygll.p_gzgw + "】";
                check_rz = 1;
            }
            
            //工作地点
            if (struct_ygll.p_gzdd != dt_detail.Rows[0]["gzdd"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作地点：【" + dt_detail.Rows[0]["gzdd"].ToString() + "】->【" + struct_ygll.p_gzdd + "】";
                check_rz = 1;
            }
            //起止日期
            if (struct_ygll.p_qzrq != dt_detail.Rows[0]["qzrq"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "起止日期：【" + dt_detail.Rows[0]["qzrq"].ToString() + "】->【" + struct_ygll.p_qzrq + "】";
                check_rz = 1;
            }
            //截止日期
            if (struct_ygll.p_jzrq != dt_detail.Rows[0]["jzrq"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "截止日期：【" + dt_detail.Rows[0]["jzrq"].ToString() + "】->【" + struct_ygll.p_jzrq + "】";
                check_rz = 1;
            }
            //备注
            if (struct_ygll.p_bz != dt_detail.Rows[0]["bz"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_ygll.p_bz + "】";
                check_rz = 1;
            }
          
            if (check_rz == 0)
            {
                struct_ygll.p_czxx += "未修改";
                ygll.Update_YGLL(struct_ygll);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                show();
                DataTable dt = new DataTable();
                dt = ygll.Select_YGLL_Detail(Convert.ToInt32(id));
                bind_rep(dt);
            }
            else {
            ygll.Update_YGLL(struct_ygll);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                show();
                DataTable dt = new DataTable();
                dt = ygll.Select_YGLL_Detail(Convert.ToInt32(id));
                bind_rep(dt);
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
            Response.Redirect("MHLL_GL.aspx");
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            tbx_gzdw.Enabled = true;
            tbx_gzgw.Enabled = true;
            tbx_gzbm.Enabled = true;
            tbx_gzdd.Enabled = true;
            tbx_jzrq.Enabled = true;
            tbx_qzrq.Enabled = true;
            tbx_bz.Enabled = true;
            btn_save.Visible = true;
            tbx_qzrq.Attributes.Add("readonly", "readonly");
            tbx_jzrq.Attributes.Add("readonly", "readonly");
            btn_save.Visible = true;
            AttachFile.Enabled = true;
            AttachFile_px.Enabled = true;
            AttachFile_jy.Enabled = true;
        }
      //下载和删除
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            filepath = "UpLoads/" + lbl_bh.Text + "/";
            string path = System.Web.HttpContext.Current.Request.MapPath(filepath);

            if (e.CommandName == "down")
            {
                try
                {
                 
                    string filename = e.CommandArgument.ToString();//文件名
                    string name = filename.Substring(filename.LastIndexOf("\\") + 1);
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
                        Response.Redirect("../main/LLGL.aspx");
                        Response.End();
                    }
                }
                catch { }

            }
            //if (e.CommandName == "delete")
            //{
            //    try
            //    {
            //        string filename = e.CommandArgument.ToString();//文件名
            //        string filePath = path + filename;
            //        if (File.Exists(filePath))
            //        {
            //            FileInfo fileInfo = new FileInfo(filePath);
            //            fileInfo.Attributes = FileAttributes.Normal;
            //            fileInfo.Delete();//删除文件
            //            Response.Write("<script languge='javascript'>alert('删除成功！');</script>");
            //           // bind_rep(path);//删除成功重新绑定
            //        }
            //        else
            //        {
            //            Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
            //            Response.Redirect("../main/LLGL.aspx");
            //            Response.End();
            //        }
            //    }
            //    catch { }

            //}
        }
    }
}