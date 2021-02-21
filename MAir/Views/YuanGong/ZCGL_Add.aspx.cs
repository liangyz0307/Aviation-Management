using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CUST.WKG
{
    public partial class ZCGL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        static string sprbh;
        //static string sjrbh;
        //static string csrbh;
        //static string zsrbh;
        public int cpage;
        public int psize;
        public bool flag = true;
        public int i = 0;
        private YGZC ygzc;
        private static DataTable dt = new DataTable();
        private Struct_YGZC struct_YGZC;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygzc = new YGZC(_usState);
            if (!IsPostBack)
            {
                //tbx_jlnr.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
                tbx_hdsj.Attributes.Add("readonly", "readonly");
                tbx_dqsj.Attributes.Add("readonly", "readonly");
                tbx_prsj.Attributes.Add("readonly", "readonly");
            }
        }

        private void ddltBind()
        {
            
            //类别
            ddlt_lb.DataSource = SysData.QZZY().Copy();
            ddlt_lb.DataTextField = "mc";
            ddlt_lb.DataValueField = "bm";
            ddlt_lb.DataBind();
            ddlt_lb.Items.Insert(0, new ListItem("全部", "-1"));
            //级别
            ddlt_jb.DataSource = SysData.ZCJB().Copy();
            ddlt_jb.DataTextField = "mc";
            ddlt_jb.DataValueField = "bm";
            ddlt_jb.DataBind();
            ddlt_jb.Items.Insert(0, new ListItem("全部", "-1"));
            //资格
            ddlt_zg.DataSource = SysData.ZG().Copy();
            ddlt_zg.DataTextField = "mc";
            ddlt_zg.DataValueField = "bm";
            ddlt_zg.DataBind();
            ddlt_zg.Items.Insert(0, new ListItem("全部", "-1"));
            //是否聘任
            ddlt_pr.DataSource = SysData.PR().Copy();
            ddlt_pr.DataTextField = "mc";
            ddlt_pr.DataValueField = "bm";
            ddlt_pr.DataBind();
            ddlt_pr.Items.Insert(0, new ListItem("全部", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110702");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();
            ddlt_csr.Items.Insert(0, new ListItem("请选择", "-1"));


            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();
            ddlt_zsr.Items.Insert(0, new ListItem("请选择", "-1"));



            ////数据所在部门
            //ddlt_sjszbm.DataSource = SysData.BM().Copy();
            //ddlt_sjszbm.DataTextField = "mc";
            //ddlt_sjszbm.DataValueField = "bm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void yg_bind()
        {
           DataTable dt_bmdm = SysData.BM("110702", _usState.userID).Copy();
            //DataTable dt_bmdm = SysData.BM().Copy();
            //部门代码
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
         //   ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygzc.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygzc.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygzc.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_spr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_spr.Items.Count > 0)
            {
                tbx_spr.Text = ddlt_spr.SelectedItem.Text;
                sprbh = ddlt_spr.SelectedValue.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 验证
            int flag = 0;
            //受聘人
            string spr = tbx_spr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(spr))
            {

                lbl_spr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_spr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //类别
            if (ddlt_lb.SelectedValue.Trim() == "-1")
            {
                lbl_lb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_lb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //级别
            if (ddlt_jb.SelectedValue.Trim() == "-1")
            {
                lbl_jb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //资格
            if (ddlt_zg.SelectedValue.Trim() == "-1")
            {
                lbl_zg.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //是否聘任
            if (ddlt_pr.SelectedValue.Trim() == "-1")
            {
                lbl_pr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_pr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //资格审权单位
            string zgsqdw = tbx_zgsqdw.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zgsqdw))
            {

                lbl_zgsqdw.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zgsqdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //获得时间
            string hdsj = tbx_hdsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(hdsj))
            {

                lbl_hdsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_hdsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //到期时间
            string dqsj = tbx_dqsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(dqsj))
            {

                lbl_dqsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else if ( DateTime.Compare(Convert.ToDateTime(dqsj), Convert.ToDateTime(hdsj)) <= 0) {
                lbl_dqsj.Text = "<span style=\"color:#ff0000\">" + "到期时间不能小于获得时间" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dqsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
          
            //聘任时间
            string prsj = tbx_prsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(prsj))
            {

                lbl_prsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_prsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1)
            {
                return; 
            }
            ////数据所在部门
            //if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            //{

            //    lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //初审人
            if (ddlt_csr.SelectedItem.Text.Trim() == "" || ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedItem.Text.Trim() == "" || ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            #endregion
            //聘任时间
            if (tbx_prsj.Text.Trim().ToString().Equals(""))
            {
                struct_YGZC.p_prsjks = new DateTime();
                struct_YGZC.p_prsjjs = new DateTime();
            }
            else
            {
                struct_YGZC.p_prsjks = DateTime.Parse(tbx_prsj.Text.Trim().ToString());
                struct_YGZC.p_prsjjs = DateTime.Parse(tbx_prsj.Text.Trim().ToString());
            }
           

            struct_YGZC.p_hdsj = DateTime.Parse(tbx_hdsj.Text.Trim().ToString());//获得时间
            struct_YGZC.p_dqsj = DateTime.Parse(tbx_dqsj.Text.Trim().ToString());//到期时间
            struct_YGZC.p_spr = ddlt_spr.SelectedValue.ToString().Trim();//受聘人
           // struct_YGZC.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            struct_YGZC.p_lb = ddlt_lb.SelectedValue.ToString().Trim();//类别
            struct_YGZC.p_jb = ddlt_jb.SelectedValue.ToString().Trim();//级别
            struct_YGZC.p_zg = ddlt_zg.SelectedValue.ToString().Trim();//资格
            struct_YGZC.p_pr = ddlt_pr.SelectedValue.ToString().Trim();//是否聘任
            struct_YGZC.p_zgsqdw = tbx_zgsqdw.Text.ToString().Trim();//资格审权单位

            struct_YGZC.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_YGZC.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_YGZC.p_bmdm = "";//数据所在部门
            struct_YGZC.p_lrr = _usState.userLoginName.ToString();//录入人
            
            struct_YGZC.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳

            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr))
            {
                struct_YGZC.p_sjbs = "0";
                struct_YGZC.p_zt = "2";
                //给终审人添加提示
                SysData.Insert_TSR(struct_YGZC.p_zsr, "11", "1107", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
            {
                struct_YGZC.p_sjbs = "1";
                struct_YGZC.p_zt = "3";
            }
            if (!struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr) && !struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
            {
                struct_YGZC.p_sjbs = "0";
                struct_YGZC.p_zt = "0";
            }

            struct_YGZC.p_czfs = "02";
            struct_YGZC.p_czxx = "位置：员工管理->员工职称->添加   描述：员工编号：" + _usState.userLoginName;
            ygzc.Insert_YGZC(struct_YGZC);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("ZCGL.aspx?ygbh=" + _usState.userLoginName);
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
            Server.Transfer("ZCGL.aspx?ygbh=" + _usState.userLoginName);
        }
    }
}