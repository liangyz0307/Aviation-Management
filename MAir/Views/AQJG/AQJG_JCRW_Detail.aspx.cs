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
    public partial class AQJG_JCRW_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private JCRW jcrw;
        private Struct_JCRW struct_jcrw;
        private DataTable dt_detail;
        public int cpage;//当前页
        public int psize;//页面容量
        public int zcount;//数据数量
        public string jcd;//全局变量检查单
        public string jcxm;//全局变量检查内容

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_XX;
            psize = _usState.C_YG_XX;
            jcrw = new JCRW(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
                bind_Main();
            }
        }

        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = jcrw.Select_YGCF_Detail(id);
            lbl_jcsj.Text = DateTime.Parse(dt_detail.Rows[0]["jcsj"].ToString()).ToString("yyyy-MM-dd");//日期
            lbl_jcr.Text = dt_detail.Rows[0]["jcrxm"].ToString();//检查人
            lbl_bjcr.Text = dt_detail.Rows[0]["bjcrxm"].ToString();//被检查人
            jcd = dt_detail.Rows[0]["jcd"].ToString();             //检查单（暂存）
            lbl_jcd.Text = SysData.TBDWByKey(dt_detail.Rows[0]["jcd"].ToString()).mc;//检查单
            jcxm = dt_detail.Rows[0]["jcxm"].ToString();           //检查内容（暂存）
            lbl_jcxm.Text = dt_detail.Rows[0]["jcxm"].ToString();//检查内容
            lbl_rwsm.Text = dt_detail.Rows[0]["rwsm"].ToString();//任务说明
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();//备注

            //lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();//驳回原因
           
            //lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
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
            Server.Transfer("AQJG_JCRW.aspx");
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历查询出的检查结果，合格为绿，不合格为红
            {
                Label lbl_jcjg = (Label)li.FindControl("Label5");
                if (lbl_jcjg.Text == "合格")//3
                {
                    lbl_jcjg.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_jcjg.Text == "不合格")//4
                {
                    lbl_jcjg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        private void bind_Main()
        {           
            struct_jcrw.jcd = jcd;
            struct_jcrw.jcxm = jcxm;
            int count = jcrw.Select_KG_JCGL_Count(struct_jcrw);
            pg_fy.TotalRecord = count;
            struct_jcrw.currentpage = pg_fy.CurrentPage;
            struct_jcrw.pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = jcrw.Select_JCJL(struct_jcrw).Tables[0];
            dt.Columns.Add("bjdwmc");
            dt.Columns.Add("jcjgmc");
            dt.Columns.Add("jcsjmc");
            dt.Columns.Add("jcdmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjdwmc"] = SysData.BMByKey(dr["bjdw"].ToString()).mc;                       //被检单位
                dr["jcjgmc"] = SysData.JCJGByKey(dr["jcjg"].ToString()).mc;                     //检查结果
                dr["jcsjmc"] = DateTime.Parse(dr["jcsj"].ToString()).ToString("yyyy-MM-dd");    //检查时间
                dr["jcdmc"] = SysData.TBDWByKey(dr["jcd"].ToString()).mc;                       //检查单

            }
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {           
            bind_Main();
        }
    }
}