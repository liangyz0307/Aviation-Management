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
    public partial class ZBJSShow : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        public string filepath;
        public string fpath;
        private UserState _usState;
        private ZBJS js;
        private Struct_zbjs struct_js;
        public bool flag = true;
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            js = new ZBJS(_usState);
            struct_js = new Struct_zbjs();

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
                string lx = Request.Params["lx"];
              
                bind_Main();
               
            }
        }
      
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;
            }
        }
      
        private void bind_Main()
        {

            if (tbx_kssj.Text == "")
            {
                struct_js.kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_js.kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始日期               
            }
            if (tbx_jssj.Text == "")
            {
                struct_js.jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_js.jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//结束日期               
            }
          
            struct_js.lx = Request.Params["lx"];//文档类型
            int count = js.Select_DQZC_ZBJSShow_Count(struct_js);
            pg_fy.TotalRecord = count;
            struct_js.p_currentpage = pg_fy.CurrentPage;
            struct_js.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = js.Select_DQZC_ZBJSShow(struct_js).Tables[0];
          
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
        #region 错误信息
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
        #endregion
     
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            string id = content[0];
            string zt = content[1];
            filepath = "UpLoads/" + struct_js.id + "/";
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

       
    }
}