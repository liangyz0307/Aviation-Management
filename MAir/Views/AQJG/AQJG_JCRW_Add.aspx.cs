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
    public partial class AQJG_JCRW_Add : System.Web.UI.Page
    {
        private UserState _usState;
        static string jcrbh;
        static string bjcrbh;
        static string jcbm;
        static string bjbm;
        private JCRW jcrw;
        protected int cpage = 0;
        protected int psize = 0;
        public bool flag = true;
        public int i = 0;
        private static DataTable dt = new DataTable();
        private Struct_JCRW struct_jcrw;
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
                tbx_jcsj.Attributes.Add("readonly", "readonly");
                tbx_jcr.Attributes.Add("readonly", "readonly");
                tbx_bjcr.Attributes.Add("readonly", "readonly");
                // lbl_ygbh.Text = _usState.userLoginName;
                yg_bind();


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
        private void yg_bind()
        {
            DataTable dt_bmdm = SysData.BM().Copy();
            //查询权限
            int count = 0;
            //查询权限
            for (; i < dt_bmdm.Rows.Count; i++)
            {
                check();
                if (dt_bmdm.Rows[i]["dqdm"].ToString() == "01" && SysData.HasThisQX("170202", _usState.userID, "01") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (i == dt_bmdm.Rows.Count) { break; }
                if (dt_bmdm.Rows[i]["dqdm"].ToString() == "02" && SysData.HasThisQX("170202", _usState.userID, "02") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["dqdm"].ToString() == "03" && SysData.HasThisQX("170202", _usState.userID, "03") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["dqdm"].ToString() == "04" && SysData.HasThisQX("170202", _usState.userID, "04") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }

                if (dt_bmdm.Rows[i]["dqdm"].ToString() == "05" && SysData.HasThisQX("170202", _usState.userID, "05") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                check();
            }
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

            //检查单
            ddlt_jcd.DataTextField = "mc";
            ddlt_jcd.DataValueField = "bm";
            ddlt_jcd.DataSource = SysData.TBDW().Copy();
            ddlt_jcd.DataBind();
            //ddlt_bjdw.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_jcd.Items.Insert(0, new ListItem("请选择", "-1"));
            ////检查项目
            //string tbdw = ddlt_jcd.SelectedValue.ToString();
            //DataTable dt_jcxm = new DataTable();
            //dt_jcxm = jcrw.Select_JCXM(tbdw);
            //ddlt_jcxm.DataSource = dt_jcxm;
            //ddlt_jcxm.DataTextField = "jcxm";
            //ddlt_jcxm.DataValueField = "jcxm";
            //ddlt_jcxm.DataBind();
            //ddlt_jcxm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        #region 下拉框值改变
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            jcbm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcrw.Select_YGbyBMGW(jcbm, gwdm);
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
        protected void ddlt_jcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tbdw = ddlt_jcd.SelectedValue.ToString();
            //string jcxm = ddlt_jcxm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcrw.Select_JCXM(tbdw);
            //ddlt_jcxm.DataSource = dt;
            //ddlt_jcxm.DataTextField = "jcnr";
            //ddlt_jcxm.DataValueField = "jcnr";
            //ddlt_jcxm.DataBind();

            //
            //绑定数据源
            this.dlt_jcnr.DataSource = dt.DefaultView;
            this.dlt_jcnr.DataBind();
        }
        #endregion
        #region 检查人与被检查人选择
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
                bjbm = bmdm;
            }
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
                bjbm = bmdm;
            }
        }
        #endregion
        //遍历检查内容被选择的个数
        protected int check_Count()
        {
            int checkCount = 0;
            foreach (DataListItem li in dlt_jcnr.Items)
            {
                CheckBox cbx_jcnr = (CheckBox)li.FindControl("cbx_jcnr");
                if (cbx_jcnr.Checked == true)
                {
                    checkCount++;
                }
            }
            return checkCount;
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region MyRegion
            int flag = 0;
            if (tbx_jcsj.Text == "")
            {
                lbl_jcsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jcsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (check_Count() == 0)//验证检查内容是否至少被选择了一个
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请先选择检查内容！\")</script>");
                flag = 1;
            }
            else if (ddlt_jcd.SelectedValue == "-1")
            {
                lbl_jcd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jcd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //负责人
            string jcr = jcrbh;
            if (string.IsNullOrEmpty(jcr))
            {
                lbl_jcr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jcr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //受罚人
            string bjcr = bjcrbh;
            if (string.IsNullOrEmpty(bjcr))
            {
                lbl_bjcr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjcr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1) { return; }
            #endregion
            // struct_baqsjcf.p_id = baqsjcf.SelectIDMaxID(_usState.userGWDM);
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
            // struct_ygcf.p_sjzl = ddlt_sjzl.SelectedValue.ToString().Trim();//事件种类
            struct_jcrw.jcr = ddlt_jcr.SelectedValue.ToString().Trim(); //负责人
            struct_jcrw.bjcr = ddlt_bjcr.SelectedValue.ToString().Trim(); //受罚人
            struct_jcrw.jcd = ddlt_jcd.SelectedValue.ToString();// tbx_jcd.Text.ToString().Trim();//简要经历和原因
            //struct_jcrw.bjbm = bjbm; //被检部门
            //struct_jcrw.jcbm = jcbm; //检查部门

            struct_jcrw.bjbm = ddlt_bmdm1.SelectedValue.ToString().Trim();
            struct_jcrw.jcbm = ddlt_bmdm.SelectedValue.ToString().Trim();

            struct_jcrw.jcd = ddlt_jcd.SelectedValue.ToString().Trim(); //检查单

            struct_jcrw.rwsm = tbx_rwsm.Text.Trim().ToString();         //任务说明
            struct_jcrw.bz = tbx_bz.Text.Trim().ToString();             //备注
            struct_jcrw.jcrwzt = "0";                                   //检查任务状态
            struct_jcrw.czfs = "02";
            struct_jcrw.czxx = "位置：安全监管->检查任务->添加   描述：员工编号：" + _usState.userLoginName
                 + "起止日期：" + struct_jcrw.jcsjks + "截止日期：" + struct_jcrw.jcsjjs
                + "备注：" + struct_jcrw.bz;

            foreach (DataListItem li in dlt_jcnr.Items)
            {
                CheckBox cbx_jcnr = (CheckBox)li.FindControl("cbx_jcnr");
                Label lbl_jcnr = (Label)li.FindControl("lbl_jcnr");
                if (cbx_jcnr.Checked == true)//前面校验通过，一次插入每一个选中行
                {
                    struct_jcrw.jcxm = lbl_jcnr.Text.Trim(); //检查内容

                    jcrw.Insert_JCRW(struct_jcrw);

                }
            }
           
            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("AQJG_JCRW.aspx?ygbh=" + _usState.userLoginName);
          
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
            Server.Transfer("AQJG_JCRW.aspx?ygbh=" + _usState.userLoginName);

        }

    }
}