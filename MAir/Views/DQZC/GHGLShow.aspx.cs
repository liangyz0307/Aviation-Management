using CUST.MKG;
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
    public partial class GHGLShow : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        public string filepath;
        public string fpath;
        private UserState _usState;
        private GHGL ghgl;
        private Struct_ghgl struct_ghgl;
        public bool flag = true;
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ghgl = new GHGL(_usState);
            struct_ghgl = new Struct_ghgl();

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_XX;
            psize = _usState.C_YG_XX;
            if (!IsPostBack)
            {
                bind_Main();
            }
        }
        private void bind_Main()
        {
            struct_ghgl.wjm = tbx_wjm.Text.ToString().Trim();//文件名
            if (tbx_kssj.Text == "")
            {
                struct_ghgl.kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_ghgl.kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始日期               
            }
            if (tbx_jssj.Text == "")
            {
                struct_ghgl.jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_ghgl.jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//结束日期               
            }
            
            int count = ghgl.Select_GHGLShow_Count(struct_ghgl);
            pg_fy.TotalRecord = count;
            struct_ghgl.p_currentpage = pg_fy.CurrentPage;
            struct_ghgl.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = ghgl.Select_GHGLShow_Pro(struct_ghgl).Tables[0];
            
            dt.Columns.Add("scsjmc");
            foreach (DataRow dr in dt.Rows)
            {
                //登记日期    
                dr["scsjmc"] = DateTime.Parse(dr["scsj"].ToString()).ToString("yyyy-MM-dd");
                       
            }

            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e) {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
           // string id = content[0];
          //  string zt = content[1];
            filepath = "UpLoads/" + struct_ghgl.id + "/";
            string path = System.Web.HttpContext.Current.Request.MapPath(filepath);
            if (e.CommandName == "down")
            {
                try
                {
                    content = e.CommandArgument.ToString().Split('&');
                    string wjm = content[0];
                    string sclj = content[1];
                    string filename = e.CommandArgument.ToString();//文件名
                    string name = filename.Substring(filename.LastIndexOf("\\") + 1);
                    if (File.Exists(sclj))
                    {
                        FileInfo fileInfo = new FileInfo(sclj);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + wjm);
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
                        return;
                        //Response.End();
                    }
                }
                catch { }
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DQZC_DYIndex.aspx");
        }

    }
}