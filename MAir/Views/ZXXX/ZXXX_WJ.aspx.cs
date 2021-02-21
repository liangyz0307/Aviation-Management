using CUST;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using CUST.MKG;


namespace CUST.WKG
{
    public partial class ZXXX_WJ : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        public string filepath;
        public string fpath;
        private UserState _usState;
        private ZXXX zxxx;
        private Struct_ZXXX struct_zxxx;
        public bool flag = true;
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)//session 浏览器服务器的一次对话，session【name】判断是否登录
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            zxxx = new ZXXX(_usState);
            struct_zxxx = new Struct_ZXXX();
            if (!IsPostBack)
            {

                ddltBind();
                bind_Main();
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
            }
        }
        private void ddltBind()
           {
             //数据所在部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
           }
        private void bind_Main()
      {
          struct_zxxx.wjm = tbx_wjm.Text.Trim();
          struct_zxxx.bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();
          if (tbx_kssj.Text.Trim().ToString() == "")
          {
              DateTime dt_kssj = new DateTime();
              struct_zxxx.kssj = dt_kssj;
          }
          else
          {
              struct_zxxx.kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始时间
          }
          if (tbx_jssj.Text.Trim().ToString() == "")
          {
              // DateTime dt_jssj = new DateTime();
              struct_zxxx.jssj = DateTime.Now;
          }
          else
          {
              struct_zxxx.jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//结束时间
          }
          int count = zxxx.Select_ZXXX_WJ_Count(struct_zxxx);
          pg_fy.TotalRecord = count;
          struct_zxxx.p_currentpage = pg_fy.CurrentPage;
          struct_zxxx.p_pagesize = pg_fy.NumPerPage;
          DataTable dt = zxxx.Select_ZXXX_WJ(struct_zxxx).Tables[0];
          dt.Columns.Add("bmmc");
          dt.Columns.Add("scsjmc");
          foreach (DataRow dr in dt.Rows)
          {
              dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
              DateTime dt_scsj = new DateTime();
              dt_scsj = Convert.ToDateTime(dr["scsj"].ToString());
              
              dr["scsjmc"] = DateTime.Parse(dr["scsj"].ToString()).ToString("yyyy-MM-dd");
           }
          //绑定分页数据源  
          this.Repeater1.DataSource = dt.DefaultView;
          this.Repeater1.DataBind();
      }
        protected void btn_select_Click(object sender, EventArgs e)
      {
          bind_Main();
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
          string[] content = new string[2];
          content = e.CommandArgument.ToString().Split('&');
          string id = content[0];
          //string zt = content[1];
          filepath = "UpLoads/" + struct_zxxx.id + "/";
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
                      Response.Redirect("~/Views/ZXXX/ZXXX_WJ.aspx");
                      Response.End();
                  }
              }
              catch { }
          }
          if (e.CommandName == "Delete")
          {
              if(SysData.HasThisBMQX(_usState.userID,"210104"))
              {
                    struct_zxxx = new Struct_ZXXX();
                    string p_czfs = "03";
                    string p_czxx = "位置：文件管理->文件提交管理->删除  描述：文件管理：[" + id + "]";
                    zxxx.Delete_ZXXX_WJid(id);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    bind_Main();
              }
              else
              {
                  Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您没有删除权限！\")</script>");
                  return;
              }

          }
      }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
         {
           

         }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZXXX/ZXXX_WJ_Add.aspx");
        }
   }
}
