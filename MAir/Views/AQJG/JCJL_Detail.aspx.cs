using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.AQJG
{
    public partial class JCJL_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private JCGL jcgl;
        private DataTable dt_detail;
        protected int cpage;    //当前页
        protected int psize;    //页面容量
        public string jcd;      //全局变量检查单
        public string jcxm;     //全局变量检查内容
        private Struct_jcgl struct_jcgl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_LL;
            psize = _usState.C_YG_LL;
            jcgl = new JCGL(_usState);
            if (!IsPostBack)
            {

                id = Convert.ToInt32(Request.Params["rwid"].ToString());
                select_detail();
                bind_Main();
            }
        }

        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["rwid"].ToString());
            dt_detail = jcgl.Select_JCJL_Detil(id).Tables[0];
            lbl_jcsj.Text = DateTime.Parse(dt_detail.Rows[0]["jcsj"].ToString()).ToString("yyyy-MM-dd");                           //日期
            lbl_bjdw.Text = SysData.BMByKey(dt_detail.Rows[0]["bjdw"].ToString()).mc;                                              //被检单位
            lbl_tzzrdw.Text = SysData.BMByKey(dt_detail.Rows[0]["tzzrdw"].ToString()).mc;                                          //通知责任单位
            jcxm = dt_detail.Rows[0]["jcxm"].ToString(); //检查内容（暂存）
            lbl_jcxm.Text = dt_detail.Rows[0]["jcxm"].ToString();                                                                  //检查项目
            lbl_jcjg.Text = SysData.JCJGByKey(dt_detail.Rows[0]["jcjg"].ToString()).mc;                                            //检查结果
            lbl_zgyj.Text = dt_detail.Rows[0]["zgyj"].ToString();                                                                  //整改意见
            lbl_tzzrry.Text = dt_detail.Rows[0]["tzzrry"].ToString();                                                              //通知责任人员
            lbl_lsqkfk.Text = dt_detail.Rows[0]["lsqkfk"].ToString();                                                              //落实情况反馈
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();                                                                      //备注
            lbl_jcr.Text = dt_detail.Rows[0]["jcr"].ToString();                                                                    //检查人 
            jcd = dt_detail.Rows[0]["jcd"].ToString();  // 检查单（暂存）
            lbl_tbdw.Text = SysData.TBDWByKey(dt_detail.Rows[0]["jcd"].ToString()).mc;                                             //填报单位
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


        protected void btn_fh_Click1(object sender, EventArgs e)
        {
            Server.Transfer("JCJL.aspx");
        }
        private void bind_Main()
        {

            struct_jcgl.jcd = jcd;
            struct_jcgl.jcxm = jcxm;
            int count = jcgl.Select_ZGJL_Count(struct_jcgl);
            pg_fy.TotalRecord = count;
            struct_jcgl.p_currentpage = pg_fy.CurrentPage;
            struct_jcgl.p_pagesize = pg_fy.NumPerPage;

            DataTable dt = jcgl.Select_ZGJL(struct_jcgl).Tables[0];
            //dt.Columns.Add("zrrmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("jcdmc");
            dt.Columns.Add("zgsxmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ztmc"] = SysData.ZGZTByKey(dr["zt"].ToString()).mc;//状态
                dr["jcdmc"] = SysData.TBDWByKey(dr["tbdw"].ToString()).mc;//状态
                dr["zgsxmc"] = DateTime.Parse(dr["zgsx"].ToString()).ToString("yyyy-MM-dd");
            }

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();

        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            bind_Main();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btn_ck_Click(object sender, EventArgs e)
        {

            id = Convert.ToInt32(Request.Params["rwid"].ToString());
            string ck = jcgl.Select_JCJL_Detil(id).Tables[0].Rows[0]["filepath"].ToString();
            //Response.Redirect(ck);

            // string fileName = "AQJG.xlsx";                               //客户端保存的文件名
            int start = ck.LastIndexOf("\\");                               //客户端保存的文件名
            string fileName = ck.Substring(start + 1, ck.Length - (start + 1));
            string filePath = ck;//Server.MapPath("../AQJG/JCJLPic/" + _usState.userLB + _usState.userLoginName + "/") + fileName;    //目标文件路径
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
    }
}