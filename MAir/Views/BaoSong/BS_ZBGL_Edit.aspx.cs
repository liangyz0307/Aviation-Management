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
    public partial class BS_ZBGL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        static string zbldbh;
        public bool flag = true;
        public int i = 0;
        private ZBGL zbgl;
        private static DataTable dt = new DataTable();
        private Struct_ZBGL struct_zbgl;
        private DataTable dt_detail;
        public string sjc;
        private int id;
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
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                tbx_rq.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
                select_detail();
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
            dt = zbgl.Select_YGByBMDQ(jc, bm);
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

        protected void select_detail()
        {
            dt_detail = zbgl.Select_ZBGL_Detail(id);
            ddlt_xq.SelectedValue = dt_detail.Rows[0]["xq"].ToString();
            tbx_rq.Text = dt_detail.Rows[0]["rq"].ToString();//日期
            ddlt_jc.SelectedValue = dt_detail.Rows[0]["jc"].ToString();
            ddlt_bm.SelectedValue = dt_detail.Rows[0]["bm"].ToString();
            ddlt_zbld.SelectedValue = dt_detail.Rows[0]["zbld"].ToString();
            tbx_zblddh.Text = dt_detail.Rows[0]["zblddh"].ToString();//日期

            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {

            struct_zbgl.p_id = Convert.ToInt32(Request.Params["id"].ToString()); //ID
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
            struct_zbgl.p_czfs = "03";
            struct_zbgl.p_czxx = "位置：航务综合报送->值班表->编辑   描述：员工编号：" + _usState.userLoginName;

            string sjbs = Request.Params["sjbs"].ToString();
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr))
                {
                    struct_zbgl.p_zt = "2";
                    struct_zbgl.p_sjbs = "0";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
                {
                    struct_zbgl.p_zt = "3";
                    struct_zbgl.p_sjbs = "1";
                }
                if (!struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr) && !struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
                {
                    struct_zbgl.p_zt = "0";
                    struct_zbgl.p_sjbs = "0";
                }
                zbgl.Update_ZBGL(struct_zbgl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            }
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr))
                {
                    struct_zbgl.p_zt = "2";
                    struct_zbgl.p_sjbs = "2";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_zbgl.p_sjc = sjc;
                    zbgl.Update_ZBGL_SJBS_LSSJ_ZT(struct_zbgl);

                    struct_zbgl.p_zt = "3";
                    struct_zbgl.p_sjbs = "1";
                }
                if (!struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr) && !struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
                {
                    struct_zbgl.p_zt = "0";
                    struct_zbgl.p_sjbs = "2";
                }
                zbgl.Update_ZBGL(struct_zbgl); ;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");

            }
            else if (sjbs.Equals("1"))
            {//生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = zbgl.ZBGL_SJBF(Convert.ToInt32(id));
                struct_zbgl.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr))
                {
                    struct_zbgl.p_zt = "2";
                    struct_zbgl.p_sjbs = "2";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_zbgl.p_sjc = sjc;
                    zbgl.Update_ZBGL_SJBS_LSSJ_ZT(struct_zbgl);

                    struct_zbgl.p_zt = "3";
                    struct_zbgl.p_sjbs = "1";
                }
                if (!struct_zbgl.p_lrr.Equals(struct_zbgl.p_csr) && !struct_zbgl.p_lrr.Equals(struct_zbgl.p_zsr))
                {
                    struct_zbgl.p_zt = "0";
                    struct_zbgl.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                zbgl.Update_ZBGL(struct_zbgl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");

            }
            else
            {
                return;
            }

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