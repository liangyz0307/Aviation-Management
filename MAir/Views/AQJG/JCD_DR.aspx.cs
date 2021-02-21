using CUST.MKG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Sys;
using CUST.Sys;
using System.Net;


namespace CUST.WKG
{
    public partial class JCD_DR : System.Web.UI.Page
    {
        private JCD jcd;
        private Struct_JCD struct_jcd;
        private UserState _usState;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            jcd = new JCD(_usState);
            if (!IsPostBack)
            {
                btn_Upload.Attributes.Add("onclick", "return confirm('该操作会更新该填报单位原有的检查单，请确认！')"); 
                bind_drop();
            }
            struct_jcd = new Struct_JCD();
            jcd = new JCD(_usState);
            

        }
        #region   问题：未在本地计算机上注册Microsoft.ACE.OLEDB.12.0提供程序
        //  解决访问Excel数据源时出现 未在本地计算机上注册Microsoft.ACE.OLEDB.12.0提供程序
        //  1、确保安装了Microsoft.ACE.OLEDB.12.0驱动
        //  http://download.microsoft.com/download/7/0/3/703ffbcb-dc0c-4e19-b0da-1463960fdcdb/AccessDatabaseEngine.exe
        //  2、在vs中右击项目--》属性--》生成 下的 目标平台 改为x86
        //  如果以上两个方法还是不行的话，用第三个方法
        //  3、在对应的 IIS 应用程序池中，“设置应用程序池默认属性”右击/“高级设置”/"启用32位应用程序"，设置为 true。
        #endregion
        public System.Data.DataTable GetExcelDatatable(string fileUrl)
        {
            //支持.xls和.xlsx，即包括office2010等版本的   HDR=Yes代表第一行是标题，不是数据；
            string cmdText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
            System.Data.DataTable dt = null;
            //建立连接
            OleDbConnection conn = new OleDbConnection(string.Format(cmdText, fileUrl));
            try
            {
                //打开连接
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //string strSql = "select * from [Sheet1$A3:F20]";
                string strSql = "select * from [Sheet1$]";
                OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                //测试遍历DataTable

                //测试
                return dt;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        protected void btn_Upload_Click(object sender, EventArgs e)
        {
          //对上传文件的大小进行检测，限定文件最大不超过10M
         if(FileUpload1.PostedFile.ContentLength < 2048000)
          {
            if (ddlt_tbdw.SelectedValue.Trim() == "-1")
            {

                lbl_tbdw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                return; 
            }

            if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls")
            {
                Response.Write("<script>alert('只可以选择Excel文件')</script>");
                return;//当选择的不是Excel文件时,返回
            }
            string filename = FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数
            string savePath = Server.MapPath(("upload\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
            DataTable ds = new DataTable();
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
            ds = GetExcelDatatable(savePath);           //调用自定义方法
            DataRow[] dr = ds.Select();            //定义一个DataRow数组
            int rowsnum = ds.Rows.Count;
            int successly = 0;
            if (rowsnum == 0)
            {
                Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
            }
            else
            {
                DateTime rq = DateTime.Now;       //更改状态时间
                string czfs = "01";
                string czxx = "位置：安全监管->检查任务->更新数据标识   描述：员工编号：" + _usState.userLoginName
                     + "日期：" + rq + "截止日期：" + "备注：" + struct_jcd.bz;
                string tbdw = ddlt_tbdw.SelectedValue.ToString().Trim();
                jcd.Update_Sjbs(tbdw, czfs, czxx);
                for (int i = 0; i < dr.Length; i++)
                {
                    //前面除了你需要在建立一个“upfiles”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                    struct_jcd.id = i;
                    struct_jcd.rq = DateTime.Now;//上传时间

                    struct_jcd.zymc = dr[i]["专业名称"].ToString();
                    struct_jcd.ywbh = dr[i]["业务编号"].ToString();
                    struct_jcd.ywmc = dr[i]["业务名称"].ToString();
                    struct_jcd.gssc = dr[i]["公司手册"].ToString();
                    struct_jcd.xmbh = dr[i]["项目编号"].ToString();
                    struct_jcd.jcxm = dr[i]["检查项目"].ToString();
                    struct_jcd.nrbh = dr[i]["内容编号"].ToString();
                    struct_jcd.jcnr = dr[i]["检查内容"].ToString();
                    struct_jcd.jcff = dr[i]["检查方法"].ToString();
                    struct_jcd.jcbz = dr[i]["检查标准"].ToString();
                    struct_jcd.scyj = dr[i]["手册依据"].ToString();
                    struct_jcd.zrbm = dr[i]["责任部门"].ToString();
                    struct_jcd.sjbm = dr[i]["涉及部门"].ToString();
                    struct_jcd.jcpc = dr[i]["检查频次"].ToString();
                    struct_jcd.ly = dr[i]["来源"].ToString();
                    struct_jcd.bz = dr[i]["备注"].ToString();

                    struct_jcd.tbdw = ddlt_tbdw.SelectedValue.ToString().Trim();
                    struct_jcd.sjbs = "1";
                    struct_jcd.scip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
                    struct_jcd.scr = "";    //上传用户
                    try
                    {
                        struct_jcd.czfs = "02";
                        struct_jcd.czxx = "位置：检查单->导入->添加   描述：员工编号：" + _usState.userLoginName
                             + "检查日期：" + struct_jcd.rq + "备注：" + struct_jcd.bz;
                        jcd.Insert_JCD(struct_jcd);
                        successly++;
                    }
                    catch
                    {

                    }
                }
                if (successly == rowsnum)
                {
                    string strmsg = "Excle表导入成功!";
                    System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strmsg + "');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Excle表导入失败!');</script>");
                }
            }
            }
         else
         {
             Response.Write("<script>alert('该文件过大，导入失败!');</script>");
         }
        }
        private void bind_drop()
        {
            //填报单位
            ddlt_tbdw.DataTextField = "mc";
            ddlt_tbdw.DataValueField = "bm";
            ddlt_tbdw.DataSource = SysData.TBDW().Copy();
            ddlt_tbdw.DataBind();
            //ddlt_bjdw.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_tbdw.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        
        #region Excel模板下载
        protected void btn_mbxz_Click(object sender, EventArgs e)
        {
            string fileName = "AQJG.xlsx";                               //客户端保存的文件名
            string filePath = Server.MapPath("../AQJG/Upload/ExcelForm/" ) + fileName;    //目标文件路径
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }
        #endregion
    }
}