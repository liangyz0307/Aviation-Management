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
using Sys;

namespace CUST.WKG
{
    public partial class YAGL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private YAGL yagl;
        private int id;
        private int p_id;
        private string sjc;
        private DataTable dt_detail;
        private Struct_YAGL struct_yagl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dt_detail = new DataTable();
            p_id = Convert.ToInt32(Request.QueryString["id"].ToString());

            yagl = new YAGL(_usState);
            if (!IsPostBack)
            {
                Bind();
               // ChangeFlag.Value = "false";

            }
        }
        private void ddltBind()
        {
            //绑定地区
            DataTable dt_dq = SysData.ZXDM().Copy();
            ddlt_dq.DataTextField = "mc";
            ddlt_dq.DataValueField = "bm";
            ddlt_dq.DataSource = dt_dq;
            ddlt_dq.DataBind();
            ddlt_dq.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定专业
            DataTable dt_zy = SysData.ZYLX().Copy();
            ddlt_zy.DataTextField = "mc";
            ddlt_zy.DataValueField = "bm";
            ddlt_zy.DataSource = dt_zy;
            ddlt_zy.DataBind();
            ddlt_zy.Items.Insert(0, new ListItem("全部", "-1"));
            ////初始化审批人
            //DataTable dt_spr = SysData.HasThisZXT_SPR("11");
            ////初审人
            //ddlt_csr.DataSource = dt_spr;
            //ddlt_csr.DataTextField = "mc";
            //ddlt_csr.DataValueField = "bm";
            //ddlt_csr.DataBind();

            ////终审人
            //ddlt_zsr.DataSource = dt_spr;
            //ddlt_zsr.DataTextField = "mc";
            //ddlt_zsr.DataValueField = "bm";
            //ddlt_zsr.DataBind();

            ////数据所在部门
            //ddlt_sjszbm.DataSource = SysData.BM().Copy();
            //ddlt_sjszbm.DataTextField = "mc";
            //ddlt_sjszbm.DataValueField = "bm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("18", _usState.userID, "180103");

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
            DataTable dt_bmdm = SysData.BM("180103", _usState.userID).Copy();
            ddlt_sjszbm.DataSource = dt_bmdm;
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void Bind()
        {
            ddltBind();
            dt_detail = yagl.Select_Yj_Yagl_Detail_Proc(p_id).Copy();
            tbx_mc.Text = dt_detail.Rows[0]["mc"].ToString().Trim();
            ddlt_dq.SelectedValue = dt_detail.Rows[0]["dq"].ToString().Trim();
            ddlt_zy.SelectedValue = dt_detail.Rows[0]["zy"].ToString().Trim();
            txtEditorContents.Text = dt_detail.Rows[0]["yanr"].ToString().Trim();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["sjssbmdm"].ToString();//数据所在部门
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string mc = tbx_mc.Text.Trim().ToString();
            string dq = ddlt_dq.SelectedValue.Trim().ToString();
            string zy = ddlt_zy.SelectedValue.Trim().ToString();
            string yanr = txtEditorContents.Text.ToString().Trim();
            #region lable判断
            if (mc == "")
            {
                lbl_mc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (dq == "-1")
            {
                lbl_dq.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (zy == "-1")
            {
                lbl_zy.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (yanr == "")
            {
                Response.Write("<script>alert('预案内容不能为空')</script>");
                flag = 1;
            }
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1)
            {
                return;
            }
            #endregion
            int check_rz = 0;
            struct_yagl.p_id = p_id;
            struct_yagl.p_mc = tbx_mc.Text.ToString();
            struct_yagl.p_dq = ddlt_dq.SelectedValue.Trim();
            struct_yagl.p_zy = ddlt_zy.SelectedValue.Trim();
            
            struct_yagl.p_yanr = txtEditorContents.Text.Trim();
            struct_yagl.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_yagl.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_yagl.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_yagl.p_sjssbm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_yagl.p_bhyy = "";//驳回原因
            struct_yagl.p_czfs = "02";
            struct_yagl.p_czxx = "位置：航务综合预警管理系统->预案管理->编辑    名称：[" + struct_yagl.p_mc + "]  描述：";
            //dt_detail = yg.Select_YGDetail(Request.Params["BH"].ToString());
            //名称
            dt_detail = yagl.Select_Yj_Yagl_Detail_Proc(p_id).Copy();
            if (struct_yagl.p_mc != dt_detail.Rows[0]["mc"].ToString())
            {
                //已修改
                struct_yagl.p_czxx += "名称：【" + dt_detail.Rows[0]["mc"].ToString() + "】->【" + struct_yagl.p_mc + "】";
                check_rz = 1;
            }
            //地区
            if (struct_yagl.p_dq != dt_detail.Rows[0]["dq"].ToString())
            {
                //已修改
                struct_yagl.p_czxx += "地区：【" + dt_detail.Rows[0]["dq"].ToString() + "】->【" + struct_yagl.p_dq + "】";
                check_rz = 1;
            }

            //专业
            if (struct_yagl.p_zy != dt_detail.Rows[0]["zy"].ToString())
            {
                //已修改
                struct_yagl.p_czxx += "专业：【" + dt_detail.Rows[0]["zy"].ToString() + "】->【" + struct_yagl.p_zy + "】";
                check_rz = 1;
            }

            //预案内容
            if (struct_yagl.p_yanr != dt_detail.Rows[0]["yanr"].ToString())
            {
                //已修改
                struct_yagl.p_czxx += "设备名称：【" + dt_detail.Rows[0]["yanr"].ToString() + "】->【" + struct_yagl.p_yanr + "】";
                check_rz = 1;
            }

            if (check_rz == 0)
            {
                struct_yagl.p_czxx += "未修改";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");

            }
            string sjbs = Request.Params["sjbs"].ToString();

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_yagl.p_lrr.Equals(struct_yagl.p_csr))
                {
                    struct_yagl.p_zt = "2";
                    struct_yagl.p_sjbs = "0";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
                {
                    struct_yagl.p_zt = "3";
                    struct_yagl.p_sjbs = "1";
                }
                if (!struct_yagl.p_lrr.Equals(struct_yagl.p_csr) && !struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
                {
                    struct_yagl.p_zt = "0";
                    struct_yagl.p_sjbs = "0";
                }
                yagl.Update_YJ_YAGL_Proc(struct_yagl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
               Response.Redirect("../YingJi/YJ_YAGL.aspx");
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_yagl.p_lrr.Equals(struct_yagl.p_csr))
                {
                    struct_yagl.p_zt = "2";
                    struct_yagl.p_sjbs = "2";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_yagl.p_sjc = sjc;
                    yagl.Update_YAGL_SJBS_LSSJ_ZT(struct_yagl);

                    struct_yagl.p_zt = "3";
                    struct_yagl.p_sjbs = "1";
                }
                if (!struct_yagl.p_lrr.Equals(struct_yagl.p_csr) && !struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
                {
                    struct_yagl.p_zt = "0";
                    struct_yagl.p_sjbs = "2";
                }
                yagl.Update_YJ_YAGL_Proc(struct_yagl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Response.Redirect("../YingJi/YJ_YAGL.aspx");
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = yagl.YAGL_SJBF(Convert.ToInt32(id));
                struct_yagl.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_yagl.p_lrr.Equals(struct_yagl.p_csr))
                {
                    struct_yagl.p_zt = "2";
                    struct_yagl.p_sjbs = "2";
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_yagl.p_sjc = sjc;
                    yagl.Update_YAGL_SJBS_LSSJ_ZT(struct_yagl);

                    struct_yagl.p_zt = "3";
                    struct_yagl.p_sjbs = "1";
                }
                if (!struct_yagl.p_lrr.Equals(struct_yagl.p_csr) && !struct_yagl.p_lrr.Equals(struct_yagl.p_zsr))
                {
                    struct_yagl.p_zt = "0";
                    struct_yagl.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                yagl.Update_YJ_YAGL_Proc(struct_yagl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
               Response.Redirect("../YingJi/YJ_YAGL.aspx");
            }
            else
            {
                return;
            }


        }
        #region 错误信息

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
        #endregion
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../YingJi/YJ_YAGL.aspx");
        }

        //protected void btn_bj_Command(object sender, CommandEventArgs e)
        //{
        //    btn_bc.Visible = true;
        //    tbx_mc.Enabled = true;
        //    ddlt_dq.Enabled = true;
        //    ddlt_zy.Enabled = true;
        //    ChangeFlag.Value = "true";
        //}


    }
}