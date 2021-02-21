
using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.IO;

namespace CUST.WKG.JSuo.main
{
    public partial class JS_TZDetail : System.Web.UI.Page
    {
        private UserState _usState;
        public JS js;
        public OJS.Struct_JS_TZ struct_js_tz;
        string tzpf = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
           
            js = new JS(_usState);
            if (!IsPostBack)
            {
                select();
            }  
        }
        private void select()
        {
            struct_js_tz.p_tzbh = Request.Params["tzbh"].ToString();
            DataTable dt = new DataTable();
            dt=js.Select_JS_TZXXDetail(struct_js_tz).Tables[0];
            lbl_tzbh.Text = struct_js_tz.p_tzbh.ToString();
            lbl_tzlx.Text =SysData.TZLXByKey( dt.Rows[0]["tzlx"].ToString()).mc;
            lbl_tzmc.Text =SysData.ZXDMByKey( dt.Rows[0]["tzmc"].ToString()).mc;
            lbl_ssd.Text = dt.Rows[0]["tzmc"].ToString();
            lbl_sqdw.Text = dt.Rows[0]["sqdw"].ToString();
            lbl_fhqk.Text = dt.Rows[0]["cdjdchjfhqk"].ToString();
            lbl_ssjgj.Text = dt.Rows[0]["ssjgj"].ToString();
            lbl_dlwz.Text = dt.Rows[0]["ssdlwz"].ToString();
            lbl_bfhqk.Text = dt.Rows[0]["bfqksm"].ToString();
            lbl_ddzbjd.Text = dt.Rows[0]["ddzb_bj_jd"].ToString();
            lbl_ddzbwd.Text = dt.Rows[0]["ddzb_bj_wd"].ToString();
            lbl_ddzbjdw.Text = dt.Rows[0]["ddzb_wgs_jd"].ToString();
            lbl_ddzbwdw.Text = dt.Rows[0]["ddzb_wgs_wd"].ToString();
            lbl_hhgc.Text = dt.Rows[0]["hhgc"].ToString();
            lbl_gcbz.Text = dt.Rows[0]["gcbz"].ToString();
            lbl_tzpfbh.Text = dt.Rows[0]["tzpfbh"].ToString();
            lbl_plpfbh.Text = dt.Rows[0]["plpfbh"].ToString();
            lbl_sbmpfbh.Text = dt.Rows[0]["sbmpfbh"].ToString();
            lbl_xkzbh.Text = dt.Rows[0]["tcsyxkzhpfbh"].ToString();    
            lbl_bz.Text = dt.Rows[0]["bz"].ToString();
            if(dt.Rows[0]["tzpf"].ToString()!="")
            {
                string tzpfname = dt.Rows[0]["tzpf"].ToString().Substring(dt.Rows[0]["tzpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
                lbtn_tzpf.Text= tzpfname;
            }
            if(dt.Rows[0]["plpf"].ToString()!="")
            {
                string plpfname = dt.Rows[0]["plpf"].ToString().Substring(dt.Rows[0]["tzpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
                lbtn_plpf.Text = plpfname;               
            }
            if (dt.Rows[0]["sbmpf"].ToString()!="")
            {
                string sbmpfname = dt.Rows[0]["sbmpf"].ToString().Substring(dt.Rows[0]["sbmpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
                lbtn_sbmpf.Text = sbmpfname;               
            }
            if(dt.Rows[0]["tcsyxkzhpf"].ToString()!="")
            {
                string tcsyxkzhpfname = dt.Rows[0]["tcsyxkzhpf"].ToString().Substring(dt.Rows[0]["tcsyxkzhpf"].ToString().LastIndexOf("\\") + 1).Substring(16);               
                lbtn_tcsyxkzhpf.Text = tcsyxkzhpfname;
            }
            if (dt.Rows[0]["tzjczlsc"].ToString()!="")
            {
                string tzjczlscname = dt.Rows[0]["tzjczlsc"].ToString().Substring(dt.Rows[0]["tzjczlsc"].ToString().LastIndexOf("\\") + 1).Substring(16);
                lbtn_tzjczlsc.Text = tzjczlscname;
            }

        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_TZXX.aspx");
        }

        protected void lbtn_tzjcjl_Click(object sender, EventArgs e)
        {
            struct_js_tz.p_tzbh = Request.Params["tzbh"].ToString();
            DataTable dt = new DataTable();
            dt = js.Select_JS_TZXXDetail(struct_js_tz).Tables[0];
            string filePath = dt.Rows[0]["tzjczlsc"].ToString();//文件名
            string filename = dt.Rows[0]["tzjczlsc"].ToString().Substring(dt.Rows[0]["tzpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
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
                lbl_tzjczlsc.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                Response.End();
            }

        }

        protected void lbtn_tzpf_Click(object sender, EventArgs e)
        {
            struct_js_tz.p_tzbh = Request.Params["tzbh"].ToString();
            DataTable dt = new DataTable();
            dt = js.Select_JS_TZXXDetail(struct_js_tz).Tables[0];
            string filePath = dt.Rows[0]["tzpf"].ToString();//文件名
            string filename = dt.Rows[0]["tzpf"].ToString().Substring(dt.Rows[0]["tzpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
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
                lbl_tzpf.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                //Response.End();
            }

        }

        protected void lbtn_plpf_Click(object sender, EventArgs e)
        {
            struct_js_tz.p_tzbh = Request.Params["tzbh"].ToString();
            DataTable dt = new DataTable();
            dt = js.Select_JS_TZXXDetail(struct_js_tz).Tables[0];
            string filePath = dt.Rows[0]["plpf"].ToString();//文件名
            string filename = dt.Rows[0]["plpf"].ToString().Substring(dt.Rows[0]["tzpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
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
                lbl_plpf.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                //Response.End();
            }

        }

        protected void lbtn_sbmpf_Click(object sender, EventArgs e)
        {
            struct_js_tz.p_tzbh = Request.Params["tzbh"].ToString();
            DataTable dt = new DataTable();
            dt = js.Select_JS_TZXXDetail(struct_js_tz).Tables[0];
            string filePath = dt.Rows[0]["sbmpf"].ToString();//文件名
            string filename = dt.Rows[0]["sbmpf"].ToString().Substring(dt.Rows[0]["tzpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
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
                lbl_sbmpf.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                //Response.End();
            }

        }

        protected void lbtn_tcsyxkzhpf_Click(object sender, EventArgs e)
        {
            struct_js_tz.p_tzbh = Request.Params["tzbh"].ToString();
            DataTable dt = new DataTable();
            dt = js.Select_JS_TZXXDetail(struct_js_tz).Tables[0];
            string filePath = dt.Rows[0]["tcsyxkzhpf"].ToString();//文件名
            string filename = dt.Rows[0]["tcsyxkzhpf"].ToString().Substring(dt.Rows[0]["tzpf"].ToString().LastIndexOf("\\") + 1).Substring(16);
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
                lbl_tcsyxkzhpf.Text = "<span style=\"color:#ff0000\">" + "文件不存在!" + "</span>"; // Response.Redirect("../main/TZSB_GL.aspx");
                //Response.End();
            }

        }
    }
}