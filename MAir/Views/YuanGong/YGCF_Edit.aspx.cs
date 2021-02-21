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
    public partial class YGCF_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        static string fzrbh;
        static string sfrbh;
        private YGCF ygcf;
        public bool flag = true;
        public int i = 0;
        private Struct_YGCF struct_ygcf=new Struct_YGCF();
        private DataTable dt_detail;
        public string sjc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygcf = new YGCF(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                yg_bind();
                ddltBind();
                tbx_cfsj.Attributes.Add("readonly", "readonly");
                select_detail();

            }
        }

        private void ddltBind()
        {
            //事件种类
            ddlt_sjzl.DataSource = SysData.SJZL().Copy();
            ddlt_sjzl.DataTextField = "mc";
            ddlt_sjzl.DataValueField = "bm";
            ddlt_sjzl.DataBind();
            ddlt_sjzl.Items.Insert(0, new ListItem("请选择", "-1"));


            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110403");
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
            //ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }


        private void yg_bind()
        {
            // DataTable dt_bmdm = SysData.BM().Copy();
            DataTable dt_bmdm = SysData.BM("110403", _usState.userID).Copy();
            //负责人
            //部门
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
            // ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();

            //受罚人
            //部门

            ddlt_bmdm1.DataSource = dt_bmdm;
            ddlt_bmdm1.DataTextField = "bmmc";
            ddlt_bmdm1.DataValueField = "bmdm";
            ddlt_bmdm1.DataBind();
            //岗位代码
            ddlt_gwdm1.DataSource = SysData.GW().Copy();
            ddlt_gwdm1.DataTextField = "mc";
            ddlt_gwdm1.DataValueField = "bm";
            ddlt_gwdm1.DataBind();
            ddlt_gwdm1.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm1 = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm1 = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt1 = new DataTable();
            dt1 = ygcf.Select_YGbyBMGW(bmdm1, gwdm1);
            ddlt_sfr.DataSource = dt1;
            ddlt_sfr.DataTextField = "xm";
            ddlt_sfr.DataValueField = "bh";
            ddlt_sfr.DataBind();
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_fzr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_fzr.Items.Count > 0)
            {
                tbx_fzr.Text = ddlt_fzr.SelectedItem.Text;
                fzrbh = ddlt_fzr.SelectedValue.ToString();
            }
        }

        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sfr.DataSource = dt;
            ddlt_sfr.DataTextField = "xm";
            ddlt_sfr.DataValueField = "bh";
            ddlt_sfr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygcf.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sfr.DataSource = dt;
            ddlt_sfr.DataTextField = "xm";
            ddlt_sfr.DataValueField = "bh";
            ddlt_sfr.DataBind();
        }
        protected void btn_bc_Click1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            string yg = ddlt_sfr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_sfr.Items.Count > 0)
            {
                tbx_sfr.Text = ddlt_sfr.SelectedItem.Text;
                sfrbh = ddlt_sfr.SelectedValue.ToString();
            }
        }

        protected void select_detail()
        {
            dt_detail = ygcf.Select_YGCF_Detail(id);
            tbx_cfsj.Text = dt_detail.Rows[0]["cfsj"].ToString();//日期
            ddlt_sjzl.SelectedValue = dt_detail.Rows[0]["sjzl"].ToString();//事件种类
            tbx_fzr.Text = dt_detail.Rows[0]["fzrxm"].ToString();//负责人
            tbx_sfr.Text = dt_detail.Rows[0]["sfrxm"].ToString();//受罚人
            ddlt_bmdm1.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//受罚人部门
            ddlt_sfr.SelectedValue = dt_detail.Rows[0]["sfr"].ToString();//受罚人编号
            ddlt_fzr.SelectedValue = dt_detail.Rows[0]["fzr"].ToString();//负责人编号
            tbx_jyjlhyy.Text = dt_detail.Rows[0]["jyjlhyy"].ToString();//简要经历和原因
            tbx_cdzr.Text = dt_detail.Rows[0]["cdzr"].ToString();//承担责任
            tbx_clyj.Text = dt_detail.Rows[0]["clyj"].ToString();//事件种类
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            //ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门
        }
        //修改惩罚信息
        protected void btn_save_Click(object sender, EventArgs e)
        {

            #region MyRegion
            int flag = 0;
            //负责人
            string fzr = tbx_fzr.Text.ToString().Trim(); ;
            if (string.IsNullOrEmpty(fzr))
            {
                lbl_fzr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //受罚人
            string sfr = tbx_sfr.Text.ToString().Trim(); ;
            if (string.IsNullOrEmpty(sfr))
            {
                lbl_sfr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //奖励种类
            if (ddlt_sjzl.SelectedValue.Trim() == "-1")
            {

                lbl_sjzl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //日期
            string cfsj = tbx_cfsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(cfsj))
            {

                lbl_cfsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_cfsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //简要经历和原因
            string jyjlhyy = tbx_jyjlhyy.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jyjlhyy))
            {

                lbl_jyjlhyy.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jyjlhyy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //承担责任
            string cdzr = tbx_cdzr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(cdzr))
            {

                lbl_cdzr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_cdzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //处理意见
            string alms = tbx_clyj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(alms))
            {

                lbl_clyj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_clyj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //事件种类
            if (ddlt_sjzl.SelectedValue.Trim() == "-1")
            {

                lbl_sjzl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            // struct_baqsjcf.p_id = baqsjcf.SelectIDMaxID(_usState.userGWDM);
            if (tbx_cfsj.Text.Trim().ToString().Equals(""))
            {
                struct_ygcf.p_kssj = new DateTime();
                struct_ygcf.p_jssj = new DateTime();
            }
            else
            {
                struct_ygcf.p_kssj = DateTime.Parse(tbx_cfsj.Text.Trim().ToString());//开始日期
                struct_ygcf.p_jssj = DateTime.Parse(tbx_cfsj.Text.Trim().ToString());//结束日期
            }
            struct_ygcf.p_sjzl = ddlt_sjzl.SelectedValue.ToString().Trim();//事件种类

            struct_ygcf.p_id = Convert.ToInt32(Request.Params["id"].ToString()); //惩罚ID
            //struct_ygcf.p_id = id;
            struct_ygcf.p_fzr = ddlt_fzr.SelectedValue.ToString().Trim();//负责人
            struct_ygcf.p_sfr = ddlt_sfr.SelectedValue.ToString().Trim();//受罚人
            struct_ygcf.p_bmdm = ddlt_bmdm1.SelectedValue.ToString().Trim();//受罚人部门
            struct_ygcf.p_jyjlhyy = tbx_jyjlhyy.Text.ToString().Trim();//简要经历和原因
            struct_ygcf.p_cdzr = tbx_cdzr.Text.ToString().Trim();//承担责任
            struct_ygcf.p_clyj = tbx_clyj.Text.ToString().Trim();//处理意见
            struct_ygcf.p_lrr = _usState.userLoginName;//录入人
            struct_ygcf.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ygcf.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人

            struct_ygcf.p_czfs = "03";
            struct_ygcf.p_czxx = "位置：员工管理->员工惩罚->修改      描述：员工编号：" + _usState.userLoginName
                 + "起止日期：" + struct_ygcf.p_kssj + "截止日期：" + struct_ygcf.p_jssj
                + "备注：";

            string sjbs = Request.Params["sjbs"].ToString();

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr))
                {
                    struct_ygcf.p_zt = "2";
                    struct_ygcf.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_ygcf.p_zsr, "11", "1104", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
                {
                    struct_ygcf.p_zt = "3";
                    struct_ygcf.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygcf.p_zsr, "11", "1104", id);
                }
                if (!struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr) && !struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
                {
                    struct_ygcf.p_zt = "0";
                    struct_ygcf.p_sjbs = "0";
                }
                ygcf.Update_YGCF(struct_ygcf);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("CFGL.aspx?ygbh=" + _usState.userLoginName);
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr))
                {
                    struct_ygcf.p_zt = "2";
                    struct_ygcf.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygcf.p_zsr, "11", "1104", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygcf.p_sjc = sjc;
                    ygcf.Update_YGCF_SJBS_LSSJ_ZT(struct_ygcf);

                    struct_ygcf.p_zt = "3";
                    struct_ygcf.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygcf.p_zsr, "11", "1104", id);
                }
                if (!struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr) && !struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
                {
                    struct_ygcf.p_zt = "0";
                    struct_ygcf.p_sjbs = "2";
                }
                ygcf.Update_YGCF(struct_ygcf);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("CFGL.aspx?ygbh=" + _usState.userLoginName);
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = ygcf.YGCF_SJBF(Convert.ToInt32(id));
                struct_ygcf.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr))
                {
                    struct_ygcf.p_zt = "2";
                    struct_ygcf.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygcf.p_zsr, "11", "1104", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygcf.p_sjc = sjc;
                    ygcf.Update_YGCF_SJBS_LSSJ_ZT(struct_ygcf);

                    struct_ygcf.p_zt = "3";
                    struct_ygcf.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygcf.p_zsr, "11", "1104", id);
                }
                if (!struct_ygcf.p_lrr.Equals(struct_ygcf.p_csr) && !struct_ygcf.p_lrr.Equals(struct_ygcf.p_zsr))
                {
                    struct_ygcf.p_zt = "0";
                    struct_ygcf.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                ygcf.Update_YGCF(struct_ygcf);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("CFGL.aspx");
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
            //Response.Redirect("LL_Edit.aspx");
            Server.Transfer("CFGL.aspx");
        }
    }
}