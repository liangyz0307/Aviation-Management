using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brettle.Web.NeatUpload;
using Sys;

namespace CUST.WKG
{
    public partial class SBWH_Detail : System.Web.UI.Page
    {
        private UserState _usState;

        private WHWX whwx;
        private Struct_SBWH struct_whwx;
        private  int id;
        private BMGW bmgw;
        private string sblx;
        private DataTable dt_detail;
        private string saveFileName;
        private string SaveFileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}

            whwx = new WHWX(_usState);
            bmgw = new BMGW(_usState);
            struct_whwx = new Struct_SBWH();
            if (!IsPostBack)
            {
               
              
                select_detail();
               
            
            }
        }
        private void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = whwx.Select_SBWH_Detail(id);

            lbl_bh.Text = dt_detail.Rows[0]["sbbh"].ToString();
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            lbl_sbztxxxx.Text = dt_detail.Rows[0]["sbztxxxx"].ToString();
            lbl_whjl.Text = dt_detail.Rows[0]["whjl"].ToString();
            //lbl_whr.Text = dt_detail.Rows[0]["xm"].ToString();//维护人
            lbl_whr.Text = dt_detail.Rows[0]["xm"].ToString();//维护人
            lbl_whsj.Text = dt_detail.Rows[0]["whsj"].ToString();
            lbl_xsjl.Text = dt_detail.Rows[0]["cdhjhdchjxsjl"].ToString();
            lbl_sblx.Text = SysData.SBLXByKey(dt_detail.Rows[0]["sblxdm"].ToString()).mc;
            lbl_whrbm.Text = SysData.BMByKey(dt_detail.Rows[0]["whrbm"].ToString()).mc;
            lbl_whrgw.Text = SysData.GWByKey(dt_detail.Rows[0]["whrgw"].ToString()).mc;
            lbl_whzt.Text = SysData.WHZTByKey(dt_detail.Rows[0]["whzt"].ToString()).mc;
            lbl_sjssbm.Text = SysData.BMByKey(dt_detail.Rows[0]["bmdm"].ToString()).mc;
            lbl_sbzl.Text = SysData.SBZLByKey(dt_detail.Rows[0]["sbzl"].ToString()).mc;
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
                                                                 // lbl_shsj.Text = dt_detail.Rows[0]["shsj"].ToString();//审核时间
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态

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
        protected string Upload_path(InputFile Upload, string bs)
        {
            //上传
            SaveFileName = "";
            string FileName = Upload.FileName;//获取上传文件的全路径  
            if (FileName != null)
            {
                string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名  
                                                                         //string SaveFileName = System.IO.Path.Combine(Request.PhysicalApplicationPath, DateTime.Now.ToString("yyyyMMddhhmm") + ExtenName);//合并两个路径为上传到服务器上的全路径  
                string fpath = null;
                string filepath = "UpLoads/SBGL/SBWH/" + lbl_bh.Text + "/";
                fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                if (!Directory.Exists(fpath))
                    Directory.CreateDirectory(fpath);
                saveFileName = this.MakeFileName(bs, FileName);
                SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径


                if (Upload.ContentLength > 0)

                {

                    Upload.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                }
            }
            return SaveFileName;

        }
        private void bind_rep()
        {
            DataTable dt = whwx.Select_SBWHbySBBH(lbl_bh.Text).Tables[0];

            DataTable dt_new = new DataTable();
            dt_new.Columns.Add("filename");
            dt_new.Columns.Add("scsj");
            dt_new.Columns.Add("path");
            bool flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                string path = dr["WHWJSC"].ToString();

                if (path != "")
                {
                    DataRow dr_new = dt_new.NewRow();
                    string filename = path.Substring(path.LastIndexOf("\\") + 1);
                    string time = filename.Substring(0, 14);
                    dr_new["filename"] = filename.Substring(16);
                    dr_new["scsj"] = changTimestyle(time);
                    dr_new["path"] = path;
                    dt_new.Rows.InsertAt(dr_new, 0);
                    flag = true;
                }
            }
            if (flag == true)
            {
                Repeater1.Visible = true;
                Repeater1.DataSource = dt_new;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
            }

        }
        public string changTimestyle(string time)
        {
            string change_time = time.Substring(0, 4) + "/" + time.Substring(4, 2) + "/" + time.Substring(6, 2) + " " +
                                               time.Substring(8, 2) + ":" + time.Substring(10, 2) + ":" + time.Substring(12, 2);
            return change_time;
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBWH_GL.aspx");
        }

   

      

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "down")
            {
                try
                {
                    // string DownloadFileName = path + e.CommandArgument.ToString();//文件路径
                    string filePath = e.CommandArgument.ToString();//文件名
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    if (File.Exists(filePath))
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
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
                        //Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                        //Response.Redirect("../main/SBWH_GL.aspx");
                        //Response.End();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"文件不存在！\")</script>");
                        return;
                    }
                }
                catch { }

            }
        }

  
    }
}