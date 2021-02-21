using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

namespace CUST.WKG
{
    public partial class BJRK_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJRK struct_bjrk;
        private Struct_BJ struct_bj;
        private BMGW bmgw;
        private DataTable dt;
        public int cpage;
        public int psize;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            bj = new BJ(_usState);
            bmgw = new BMGW(_usState);

            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {
                //bind_drop();
                bind_select();
                bind_select_crkqd();


            }
        }
     
        private void bind_select()
        {
            string id = Request.Params["id"].ToString();
            dt = bj.Select_BJRKbyID(id).Tables[0];
           
            lbl_bjbh.Text= dt.Rows[0]["bh"].ToString();
            lbl_bjmc.Text = dt.Rows[0]["bjmc"].ToString();
            lbl_bz.Text= dt.Rows[0]["bz"].ToString();
            lbl_cfwz.Text= dt.Rows[0]["cfwz"].ToString();
            DateTime dt_rksj = new DateTime();
            dt_rksj = Convert.ToDateTime(dt.Rows[0]["rksj"].ToString());
            lbl_rksj.Text = string.Format("{0:yyyy-MM-dd}", dt_rksj);          
            lbl_rksl.Text= dt.Rows[0]["rksl"].ToString();

            lbl_fzr.Text = dt.Rows[0]["fzrxm"].ToString();
            lbl_jbr.Text = dt.Rows[0]["jbrxm"].ToString();

            lbl_fzrbm.Text = SysData.BMByKey(dt.Rows[0]["fzrbm"].ToString()).mc;
            lbl_fzrgw.Text = SysData.GWByKey(dt.Rows[0]["fzrgw"].ToString()).mc; 
            lbl_jbrbm.Text = SysData.BMByKey(dt.Rows[0]["jbrbm"].ToString()).mc;
            lbl_jbrgw.Text = SysData.GWByKey(dt.Rows[0]["jbrgw"].ToString()).mc; 
            lbl_sjszbm.Text = SysData.BMByKey(dt.Rows[0]["bmdm"].ToString()).mc; 
            lbl_bjfl.Text =SysData.BJLXByKey(dt.Rows[0]["bjfl"].ToString()).mc;
            lbl_bjsy.Text =SysData.BJSYByKey(dt.Rows[0]["sy"].ToString()).mc;
            
            lbl_bhyy.Text = dt.Rows[0]["bhyy"].ToString();//驳回原因

            lbl_lrr.Text = dt.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt.Rows[0]["zsrxm"].ToString();//终审人
 

        }


        private void bind_select_crkqd()
        {
            string id = Request.Params["id"].ToString();
            dt = bj.Select_BJRKbyID(id).Tables[0];
            struct_bj.p_bjbh = dt.Rows[0]["bh"].ToString(); ;
            struct_bj.p_sjc = dt.Rows[0]["sjc"].ToString(); ;
            int count = bj.Select_BJCRKQD_Count(struct_bj);
            pg_fy.TotalRecord = count;
            struct_bj.p_currentpage = pg_fy.CurrentPage;
            struct_bj.p_pagesize = pg_fy.NumPerPage;
            DataTable dt_qd = bj.Select_BJCRKQD(struct_bj).Tables[0];

            dt_qd.Columns.Add("bjcrkczr_mc");
            dt_qd.Columns.Add("czsjz");
            foreach (DataRow dr in dt_qd.Rows)
            {
                dr["bjcrkczr_mc"] = dr["czrxm"].ToString();
                dr["czsjz"] = DateTime.Parse(dr["czsj"].ToString()).ToString("yyyy-MM-dd");
            }

            ////绑定分页数据源  
            this.Repeater1.DataSource = dt_qd.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_select_crkqd();
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBBJ_RK.aspx");
        }
        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = bj.Select_BJCRKQD_DC(_usState.userID);
            dt_dc.Columns.Add("czsj_z");
            foreach (DataRow dr in dt_dc.Rows)
            {

 

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["czsj"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["czsj_z"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);

            }

            //删除不用的列
            DataRow dr_Insert = dt_dc.NewRow();
            dt_dc.Columns.Remove("ID");
            dt_dc.Columns.Remove("czr");
            dt_dc.Columns.Remove("bjsjc");
            dt_dc.Columns.Remove("czsj");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "备件编号";
            dr_Insert[1] = "操作类型";
            dr_Insert[2] = "操作数量";
            dr_Insert[3] = "操作人";
            dr_Insert[4] = "操作时间";
            

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "设备备件出入库清单" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../Shebei/BJCRKQD.xls");
            // 1、首先判断文件或者文件路径是否存在
            if (File.Exists(path))
            {
                // 3.2、删除文件
                File.Delete(path);
            }

            ex.OutputFilePath = path;
            ex.OutputExcelFile();

            string fileName = hz;//客户端保存的文件名 
            string filePath = path;//目标文件路径

            if (File.Exists(filePath))
            {
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
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }
        }



    }
}