using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;


namespace CUST.WKG
{
    public partial class ZJK_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private DataTable dt_detail;
        private static DataTable dt = new DataTable();
        private Struct_ZJK_Pro struct_zjk;
        private ZJK zjk;
        private string sjc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = Session["UserState"] as UserState) == null) {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zjk = new ZJK(_usState);
            if (!IsPostBack) {
                id = Convert.ToInt32(Request.Params["id"]);
                ddltBind();
                select_detail();
            }
        }
        private void ddltBind() {
            //专家类型
            ddlt_zjlx.DataTextField = "mc";
            ddlt_zjlx.DataValueField = "bm";
            ddlt_zjlx.DataSource = SysData.ZJLX().Copy();
            ddlt_zjlx.DataBind();
            ddlt_zjlx.Items.Insert(0, new ListItem("请选择", "-1"));
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("20", _usState.userID, "200502");
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
            //数据所在部门
            ddlt_bmdm.DataSource = SysData.BM("200502", _usState.userID).Copy();
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void select_detail() {
            id = Convert.ToInt32(Request.Params["id"]);
            dt_detail = zjk.Select_ZJK_Detail(id);
            tbx_xm.Text = dt_detail.Rows[0]["xm"].ToString();
            ddlt_zjlx.SelectedValue = dt_detail.Rows[0]["zjlx"].ToString();
            tbx_zd.Text = dt_detail.Rows[0]["zd"].ToString();
            tbx_csgz.Text = dt_detail.Rows[0]["csgz"].ToString();
            tbx_zy.Text = dt_detail.Rows[0]["zy"].ToString();
            tbx_zc.Text = dt_detail.Rows[0]["zc"].ToString();
            tbx_lxfs.Text = dt_detail.Rows[0]["lxfs"].ToString();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();
           
            ddlt_bmdm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();
        }
        protected void btn_save_Click(object sender, EventArgs e) {
            #region label判断
            int flag = 0;
            //姓名
            if (tbx_xm.Text == "")
            {
                lbl_xm.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //专家类型
            if (ddlt_zjlx.SelectedValue == "-1")
            {
                lbl_zjlx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zjlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //驻地
            if (tbx_zd.Text == "")
            {
                lbl_zd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //从事工作
            if (tbx_csgz.Text == "")
            {
                lbl_csgz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csgz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //专业
            if (tbx_zy.Text == "")
            {
                lbl_zy.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //专长
            if (tbx_zc.Text == "")
            {
                lbl_zc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //联系方式
            string lxfs = tbx_lxfs.Text.ToString().Trim();
            if (!Regex.IsMatch(tbx_lxfs.Text, @"^[0-9]*$") || string.IsNullOrEmpty(lxfs))
            {
                lbl_lxfs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空且为数字" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_lxfs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
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
            //数据所属部门
            if (ddlt_bmdm.SelectedValue == "-1")
            {
                lbl_bmdm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bmdm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            #endregion
            struct_zjk.p_xm = tbx_xm.Text.Trim().ToString();
            struct_zjk.p_zjlx = ddlt_zjlx.SelectedValue.Trim().ToString();
            struct_zjk.p_zd = tbx_zd.Text.Trim().ToString();
            struct_zjk.p_csgz = tbx_csgz.Text.Trim().ToString();
            struct_zjk.p_zy = tbx_zy.Text.Trim().ToString();
            struct_zjk.p_zc = tbx_zc.Text.Trim().ToString();
            struct_zjk.p_lxfs = tbx_lxfs.Text.Trim().ToString();
            struct_zjk.p_csr = ddlt_csr.SelectedValue.Trim().ToString();
            struct_zjk.p_zsr = ddlt_zsr.SelectedValue.Trim().ToString();
            struct_zjk.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_zjk.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//数据所在部门
            struct_zjk.p_czfs = "03";
            struct_zjk.p_czxx = "位置：员工管理->员工奖励->编辑   描述：员工编号：" + _usState.userLoginName;
            #region 判断数据状态
            string sjbs = Request.Params["sjbs"].ToString();
            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_zjk.p_lrr.Equals(struct_zjk.p_csr))
                {
                    struct_zjk.p_zt = "2";
                    struct_zjk.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_zjk.p_zsr, "20", "2005", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zjk.p_lrr.Equals(struct_zjk.p_zsr))
                {
                    struct_zjk.p_zt = "3";
                    struct_zjk.p_sjbs = "1";
                    SysData.Delete_TSR(struct_zjk.p_zsr, "20", "2005", id);
                }
                if (!struct_zjk.p_lrr.Equals(struct_zjk.p_csr) && !struct_zjk.p_lrr.Equals(struct_zjk.p_zsr))
                {
                    struct_zjk.p_zt = "0";
                    struct_zjk.p_sjbs = "0";
                }
                zjk.Update_ZJK(struct_zjk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_zjk.p_lrr.Equals(struct_zjk.p_csr))
                {
                    struct_zjk.p_zt = "2";
                    struct_zjk.p_sjbs = "2";
                    SysData.Insert_TSR(struct_zjk.p_zsr, "20", "2005", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zjk.p_lrr.Equals(struct_zjk.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_zjk.p_sjc = sjc;
                    zjk.Update_ZJK_SJBS_LSSJ_ZT(struct_zjk);

                    struct_zjk.p_zt = "3";
                    struct_zjk.p_sjbs = "1";
                    SysData.Delete_TSR(struct_zjk.p_zsr, "20", "2005", id);
                }
                if (!struct_zjk.p_lrr.Equals(struct_zjk.p_csr) && !struct_zjk.p_lrr.Equals(struct_zjk.p_zsr))
                {
                    struct_zjk.p_zt = "0";
                    struct_zjk.p_sjbs = "2";
                }
                zjk.Update_ZJK(struct_zjk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = zjk.ZJK_SJBF(Convert.ToInt32(id));
                struct_zjk.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_zjk.p_lrr.Equals(struct_zjk.p_csr))
                {
                    struct_zjk.p_zt = "2";
                    struct_zjk.p_sjbs = "2";
                    SysData.Insert_TSR(struct_zjk.p_zsr, "20", "2005", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zjk.p_lrr.Equals(struct_zjk.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_zjk.p_sjc = sjc;
                    zjk.Update_ZJK_SJBS_LSSJ_ZT(struct_zjk);

                    struct_zjk.p_zt = "3";
                    struct_zjk.p_sjbs = "1";
                    SysData.Delete_TSR(struct_zjk.p_zsr, "20", "2005", id);
                }
                if (!struct_zjk.p_lrr.Equals(struct_zjk.p_csr) && !struct_zjk.p_lrr.Equals(struct_zjk.p_zsr))
                {
                    struct_zjk.p_zt = "0";
                    struct_zjk.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                zjk.Update_ZJK(struct_zjk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            else
            {
                return;
            }
        }
        #endregion
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("SKJS_ZJK.aspx");
        }
    }
}