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
    public partial class BS_ZBGL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        static string zbldbh;
        public bool flag = true;
        public int i = 0;
        private ZBGL zbgl;
        private static DataTable dt = new DataTable();
        private Struct_ZBGL struct_zbgl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            zbgl = new ZBGL(_usState);
            
            if (!IsPostBack)
            {
                tbx_rq.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
            }
        }
        private void ddltBind()
        {
            //星期
            ddlt_xq.DataTextField = "mc";
            ddlt_xq.DataValueField = "bm";
            ddlt_xq.DataSource = SysData.XQ().Copy();
            ddlt_xq.DataBind();
            ddlt_xq.Items.Insert(0, new ListItem("全部", "-1"));


            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();

            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();

            //数据所在部门
            ddlt_sjszbm.DataSource = SysData.BM().Copy();
            ddlt_sjszbm.DataTextField = "mc";
            ddlt_sjszbm.DataValueField = "bm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
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
            //部门
            ddlt_bm.DataSource = dt_bmdm;
            ddlt_bm.DataTextField = "mc";
            ddlt_bm.DataValueField = "bm";
            ddlt_bm.DataBind();
            ddlt_bm.Items.Insert(0, new ListItem("全部", "-1"));
            //机场（支线）
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            string bm = ddlt_bm.SelectedValue.ToString();
            string jc = ddlt_jc.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = zbgl.Select_YGByBMDQ(jc,bm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();

        }
        protected void ddlt_jc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue.ToString();
            string jc = ddlt_jc.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = zbgl.Select_YGByBMDQ(jc, bm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
        }
        protected void ddlt_bm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue.ToString();
            string jc = ddlt_jc.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = zbgl.Select_YGByBMDQ(jc, bm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue.ToString();
            string jc = ddlt_jc.SelectedValue.ToString();
            string zbld = ddlt_zbld.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_zbld.Items.Count > 0)
            {
                tbx_zbld.Text = ddlt_zbld.SelectedItem.Text;
                zbldbh = ddlt_zbld.SelectedValue.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e) {


            struct_zbgl.p_xq = ddlt_xq.SelectedValue.ToString().Trim();//星期
            struct_zbgl.p_rq = tbx_rq.Text.ToString().Trim();
            struct_zbgl.p_jc = ddlt_jc.SelectedValue.ToString().Trim();
            struct_zbgl.p_bm = ddlt_bm.SelectedValue.ToString().Trim();
            struct_zbgl.p_zbld = ddlt_zbld.SelectedValue.ToString().Trim();
            struct_zbgl.p_zblddh = tbx_zblddh.Text.ToString().Trim();
            struct_zbgl.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_zbgl.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_zbgl.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_zbgl.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_zbgl.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳

            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr))
            {
                struct_zbgl.p_sjbs = "0";
                struct_zbgl.p_zt = "2";
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
            {
                struct_zbgl.p_sjbs = "1";
                struct_zbgl.p_zt = "3";
            }
            if (!struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr) && !struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
            {
                struct_zbgl.p_sjbs = "0";
                struct_zbgl.p_zt = "0";
            }


            struct_zbgl.p_czfs = "02";
            struct_zbgl.p_czxx = "位置：航务综合报送->值班表->添加   描述：员工编号：" + _usState.userLoginName;
                 
            zbgl.Insert_ZBGL(struct_zbgl);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            
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
            Server.Transfer("BS_ZBGL.aspx?ygbh=" + _usState.userLoginName);

        }

    }
}