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
    public partial class AQJG_JCRW_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private long id;
        static string jcbm;
        static string jcrbh;
        static string bjcrbh;
        private JCRW jcrw;
        public bool flag = true;
        public int i = 0;
        private Struct_JCRW struct_jcrw;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            jcrw = new JCRW(_usState);
            if (!IsPostBack)
            {
                
                //show();
                //lbl_ygbh.Text = _usState.userLoginName;
                tbx_jcsj.Attributes.Add("readonly", "readonly");
                tbx_jcr.Attributes.Add("readonly", "readonly");
                tbx_bjcr.Attributes.Add("readonly", "readonly");
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
                yg_bind();
                
            }
        }
        //public void show()
        //{
        //    Boolean flag = false;
        //    if (SysData.HasThisQX("170203", _usState.userID, "01") == true)
        //    {
        //        flag = true;
        //    }
        //    if (SysData.HasThisQX("170203", _usState.userID, "02") == true)
        //    {
        //        flag = true;
        //    }
        //    if (SysData.HasThisQX("170203", _usState.userID, "03") == true)
        //    {
        //        flag = true;
        //    }
        //    if (SysData.HasThisQX("170203", _usState.userID, "04") == true)
        //    {
        //        flag = true;
        //    }
        //    if (SysData.HasThisQX("170203", _usState.userID, "05") == true)
        //    {
        //        flag = true;
        //    }
        //    if (!flag)
        //    {
        //       // tbx_jcd.Enabled = false;
        //        ddlt_jcd.Enabled = false;

        //        tbx_jcsj.Enabled = false;
                
        //        tbx_jcr.Enabled = false;
        //        tbx_bjcr.Enabled = false;
        //        btn_save.Visible = false;
        //        ChangeFlag.Value = "false";
        //    }
        //}

        //public void check()
        //{
        //    if (flag == false)
        //    {
        //        i--;
        //        flag = true;

        //    }
        //}
        private void yg_bind()
        {
            DataTable dt_bmdm = SysData.BM().Copy();
            //int count = 0;
            ////查询部门权限
            //for (; i < dt_bmdm.Rows.Count; i++)
            //{
            //    check();
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "01" && SysData.HasThisQX("130203", _usState.userID, "01") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (i == dt_bmdm.Rows.Count) { break; }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "02" && SysData.HasThisQX("130203", _usState.userID, "02") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "03" && SysData.HasThisQX("130203", _usState.userID, "03") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "04" && SysData.HasThisQX("130203", _usState.userID, "04") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }

            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "05" && SysData.HasThisQX("130203", _usState.userID, "05") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    check();
            //}
            //检查人
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            //ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcrw.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_jcr.DataSource = dt;
            ddlt_jcr.DataTextField = "xm";
            ddlt_jcr.DataValueField = "bh";
            ddlt_jcr.DataBind();

            //被检查人
            ddlt_bmdm1.DataSource = SysData.BM().Copy();
            ddlt_bmdm1.DataTextField = "mc";
            ddlt_bmdm1.DataValueField = "bm";
            ddlt_bmdm1.DataBind();
            //ddlt_bmdm1.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm1.DataSource = SysData.GW().Copy();
            ddlt_gwdm1.DataTextField = "mc";
            ddlt_gwdm1.DataValueField = "bm";
            ddlt_gwdm1.DataBind();
            ddlt_gwdm1.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm1 = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm1 = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt1 = new DataTable();
            dt1 = jcrw.Select_YGbyBMGW(bmdm1, gwdm1);
            ddlt_bjcr.DataSource = dt1;
            ddlt_bjcr.DataTextField = "xm";
            ddlt_bjcr.DataValueField = "bh";
            ddlt_bjcr.DataBind();

            ddlt_jcd.DataSource = SysData.TBDW().Copy();
            ddlt_jcd.DataTextField = "mc";
            ddlt_jcd.DataValueField = "bm";
            ddlt_jcd.DataBind();
            ddlt_jcd.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcrw.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_jcr.DataSource = dt;
            ddlt_jcr.DataTextField = "xm";
            ddlt_jcr.DataValueField = "bh";
            ddlt_jcr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcrw.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_jcr.DataSource = dt;
            ddlt_jcr.DataTextField = "xm";
            ddlt_jcr.DataValueField = "bh";
            ddlt_jcr.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_jcr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_jcr.Items.Count > 0)
            {
                tbx_jcr.Text = ddlt_jcr.SelectedItem.Text;
                jcrbh = ddlt_jcr.SelectedValue.ToString();
                jcbm = bmdm;
            }
        }

        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcrw.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_bjcr.DataSource = dt;
            ddlt_bjcr.DataTextField = "xm";
            ddlt_bjcr.DataValueField = "bh";
            ddlt_bjcr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcrw.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_bjcr.DataSource = dt;
            ddlt_bjcr.DataTextField = "xm";
            ddlt_bjcr.DataValueField = "bh";
            ddlt_bjcr.DataBind();
        }
        protected void btn_bc_Click1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            string yg = ddlt_bjcr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_bjcr.Items.Count > 0)
            {
                tbx_bjcr.Text = ddlt_bjcr.SelectedItem.Text;
                bjcrbh = ddlt_bjcr.SelectedValue.ToString();
            }
        }

        protected void select_detail()
        {

            dt_detail = jcrw.Select_YGCF_Detail(id);
            tbx_jcsj.Text = dt_detail.Rows[0]["jcsj"].ToString();//日期
           // ddlt_sjzl.SelectedValue = dt_detail.Rows[0]["sjzl"].ToString();//事件种类
            //tbx_jcr.Text = dt_detail.Rows[0]["jcrxm"].ToString();//负责人
            //tbx_bjcr.Text = dt_detail.Rows[0]["bjcrxm"].ToString();//受罚人
           // tbx_jcd.Text = dt_detail.Rows[0]["jcd"].ToString();//检查单
            ddlt_jcd.SelectedValue = dt_detail.Rows[0]["jcd"].ToString();  //检查单
            tbx_jcxm.Text = dt_detail.Rows[0]["jcxm"].ToString();//检查项目
            tbx_rwsm.Text = dt_detail.Rows[0]["rwsm"].ToString();//任务说明
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();//任务说明
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {

        
            if (tbx_jcsj.Text.Trim().ToString().Equals(""))
            {
                struct_jcrw.jcsjks = new DateTime();
                struct_jcrw.jcsjjs = new DateTime();
            }
            else
            {
                struct_jcrw.jcsjks = DateTime.Parse(tbx_jcsj.Text.Trim().ToString());//开始日期
                struct_jcrw.jcsjjs = DateTime.Parse(tbx_jcsj.Text.Trim().ToString());//结束日期
            }


            struct_jcrw.id = Convert.ToInt32(Request.Params["id"].ToString()); //惩罚ID
          
            struct_jcrw.jcr = ddlt_jcr.SelectedValue.ToString().Trim();//检查人
            struct_jcrw.bjcr = ddlt_bjcr.SelectedValue.ToString().Trim();//被检查人

            struct_jcrw.jcd = ddlt_jcd.SelectedValue.ToString();// tbx_jcd.Text.ToString().Trim();//检查单
            struct_jcrw.jcxm = tbx_jcxm.Text.ToString().Trim();//检查项目

            //struct_jcrw.bjbm = jcbm;
            struct_jcrw.bjbm = ddlt_bmdm1.SelectedValue.ToString().Trim();
            //struct_jcrw.jcbm = ddlt_bmdm.SelectedValue.ToString().Trim();

            struct_jcrw.rwsm = tbx_rwsm.Text.ToString();//任务说明
            struct_jcrw.bz = tbx_bz.Text.ToString();//备注

            struct_jcrw.czfs = "03";
            struct_jcrw.czxx = "位置：安全监管->检查任务->修改      描述：员工编号：" + _usState.userLoginName
                 + "起止日期：" + struct_jcrw.jcsjks + "截止日期：" + struct_jcrw.jcsjjs
                + "备注：" + struct_jcrw.bz;
            jcrw.Update_JCRW(struct_jcrw);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            Server.Transfer("AQJG_JCRW.aspx");
         
            //tbx_jcsj.Text = "";
          
            //ddlt_jcr.SelectedValue = "";
            //tbx_bjcr.Text = "";
            //tbx_jcd.Text = "";
           
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




    }
}