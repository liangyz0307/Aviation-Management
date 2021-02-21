using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CUST.WKG
{
    public partial class BJCK_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJCK struct_bjck;
        private BMGW bmgw;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            bj = new BJ(_usState);
            bmgw = new BMGW(_usState);
            if (!IsPostBack)
            {
                bind_drop();

                tbx_cksj.Attributes.Add("readonly", "readonly");
            }
        }
        private void bind_drop()
        {
            //经办人
            ddlt_jbrbm.DataTextField = "mc";
            ddlt_jbrbm.DataValueField = "bm";
            ddlt_jbrbm.DataSource = SysData.BM().Copy();
            ddlt_jbrbm.DataBind();
            ddlt_jbrbm.Items.Insert(0, new ListItem("请选择", "-1"));

            DataTable dt_gw = new DataTable();
            ddlt_jbrgw.DataSource = dt_gw;
            ddlt_jbrgw.DataBind();
            ddlt_jbrgw.Items.Insert(0, new ListItem("请选择", "-1"));

            DataTable dt_jbr = new DataTable();
            ddlt_jbr.DataSource = dt_jbr;
            ddlt_jbr.DataBind();
            ddlt_jbr.Items.Insert(0, new ListItem("请选择", "-1"));

            //负责人
            ddlt_fzrbm.DataTextField = "mc";
            ddlt_fzrbm.DataValueField = "bm";
            ddlt_fzrbm.DataSource = SysData.BM().Copy();
            ddlt_fzrbm.DataBind();
            ddlt_fzrbm.Items.Insert(0, new ListItem("请选择", "-1"));

            DataTable dt_fzrgw = new DataTable();
            ddlt_fzrgw.DataSource = dt_fzrgw;
            ddlt_fzrgw.DataBind();
            ddlt_fzrgw.Items.Insert(0, new ListItem("请选择", "-1"));

            DataTable dt_fzr = new DataTable();
            ddlt_fzr.DataSource = dt_fzr;
            ddlt_fzr.DataBind();
            ddlt_fzr.Items.Insert(0, new ListItem("请选择", "-1"));

            //ddlt_bjfl.DataTextField = "mc";
            //ddlt_bjfl.DataValueField = "bm";
            //ddlt_bjfl.DataSource = SysData.BJLX().Copy();
            //ddlt_bjfl.DataBind();
            //ddlt_bjfl.Items.Insert(0, new ListItem("请选择", "-1"));

            //ddlt_bjsy.DataTextField = "mc";
            //ddlt_bjsy.DataValueField = "bm";
            //ddlt_bjsy.DataSource = SysData.BJSY().Copy();
            //ddlt_bjsy.DataBind();
            //ddlt_bjsy.Items.Insert(0, new ListItem("请选择", "-1"));

            //DataTable dt = new DataTable();
            //dt = bj.Select_BJXX().Tables[0];
            //ddlt_bjmc.DataTextField = "bjmc";
            //ddlt_bjmc.DataValueField = "bjbh";
            //ddlt_bjmc.DataSource = dt;
            //ddlt_bjmc.DataBind();
            //ddlt_bjmc.Items.Insert(0, new ListItem("全部", "-1"));



            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140602");

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
            ddlt_sjszbm.DataSource = SysData.BM("140602", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            #region MyRegion
            int flag = 0;

            //存放位置
            if (tbx_cfwz.Text == "")
            {
                lbl_cfwz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {


                lbl_cfwz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //时间
            if (tbx_cksj.Text == "")
            {
                lbl_cksj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {


                lbl_cksj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //出库数量
            if (tbx_cksl.Text == "")
            {
                lbl_cksl.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_cksl.Text, @"^[0-9]*$"))
            {
                lbl_cksl.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {


                lbl_cksl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人
            if (ddlt_jbrbm.SelectedValue.Trim() == "-1")
            {

                lbl_jbrbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jbrbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人岗位
            if (ddlt_jbrgw.SelectedValue.Trim() == "-1")
            {

                lbl_jbrgw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jbrgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人
            if (ddlt_jbr.SelectedValue.Trim() == "-1")
            {

                lbl_jbr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jbr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //负责人部门
            if (ddlt_fzrbm.SelectedValue.Trim() == "-1")
            {

                lbl_fzrbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzrbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人岗位
            if (ddlt_fzrgw.SelectedValue.Trim() == "-1")
            {

                lbl_fzrgw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzrgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人
            if (ddlt_fzr.SelectedValue.Trim() == "-1")
            {

                lbl_fzr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //数据所属部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            if (flag == 1) { return; }
            #endregion
            string bjbh = tbx_bjbh.Text.ToString().Trim();
            bjbh = bj.SHTG_BJBH(bjbh);
            if (bjbh == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"无当前备件编号，请确认后重新填写！\")</script>");

                return;
            }
            struct_bjck.p_bjbh = bjbh;

            struct_bjck.p_cfwz = tbx_cfwz.Text.ToString();
            struct_bjck.p_ckjbr = ddlt_jbr.SelectedValue.ToString();
            if (tbx_cksj.Text.ToString() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"入库时间不能为空！\")</script>");
                return;
            }

            struct_bjck.p_cfwz = tbx_cfwz.Text.ToString().Trim();
            struct_bjck.p_ckjbr = ddlt_jbr.SelectedValue.ToString();

            struct_bjck.p_cksj = Convert.ToDateTime(tbx_cksj.Text.ToString());

            struct_bjck.p_cksl = Convert.ToInt16(tbx_cksl.Text.ToString());
            struct_bjck.p_bz = tbx_bz.Text.ToString();
            struct_bjck.p_jbrbm = ddlt_jbrbm.SelectedValue.ToString();
            struct_bjck.p_jbrgw = ddlt_jbrgw.SelectedValue.ToString();
            struct_bjck.p_kffzr = ddlt_fzr.SelectedValue.ToString();
            struct_bjck.p_fzrbm = ddlt_fzrbm.SelectedValue.ToString();
            struct_bjck.p_fzrgw = ddlt_fzrgw.SelectedValue.ToString();
            struct_bjck.p_fzrxm = ddlt_fzr.SelectedItem.Text.ToString();
            struct_bjck.p_jbrxm = ddlt_jbr.SelectedItem.Text.ToString();
            struct_bjck.p_zxdm = _usState.userSS;
            struct_bjck.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_bjck.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_bjck.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_bjck.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_bjck.p_lrr = _usState.userLoginName.ToString();//录入人

            //struct_bjck.p_bjfl = ddlt_bjfl.SelectedValue.ToString();
            //struct_bjck.p_sy = ddlt_bjsy.SelectedValue.ToString();
            struct_bjck.p_czxx = "位置：设备管理->备件出库->编辑  备件编号：" + struct_bjck.p_bjbh + "存放位置" + struct_bjck.p_cfwz
                    + "出库经办人:" + struct_bjck.p_ckjbr + "出库时间 " + struct_bjck.p_cksj + " 出库数量" + struct_bjck.p_cksl + "经办人部门" + struct_bjck.p_jbrbm
                    + " 经办人岗位" + struct_bjck.p_jbrgw + " 负责人 " + struct_bjck.p_kffzr + " 负责人部门 " + struct_bjck.p_fzrbm + " 负责人岗位" + struct_bjck.p_fzrgw
                    + " 备件分类" + struct_bjck.p_bjfl + "备件适用" + struct_bjck.p_sy + " 备注" + struct_bjck.p_bz;
                struct_bjck.p_czfs = "01";
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_bjck.p_lrr.Equals(struct_bjck.p_csr))
            {
                struct_bjck.p_sjbs = "0";
                struct_bjck.p_zt = "2";
                //给终审人添加提示
                SysData.Insert_TSR(struct_bjck.p_zsr, "14", "1405", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_bjck.p_lrr.Equals(struct_bjck.p_zsr))
            {
                struct_bjck.p_sjbs = "1";
                struct_bjck.p_zt = "3";
            }
            if (!struct_bjck.p_lrr.Equals(struct_bjck.p_csr) && !struct_bjck.p_lrr.Equals(struct_bjck.p_zsr))
            {
                struct_bjck.p_sjbs = "0";
                struct_bjck.p_zt = "0";
            }
            try
            {
                bj.Insert_BJCK(struct_bjck);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (Exception em)
            {
                throw em;
            }

        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBBJ_CK.aspx");
        }

     

        protected void ddlt_jbrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_jbrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_jbrgw.DataSource = dt;
                ddlt_jbrgw.DataBind();
                ddlt_jbrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_jbrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_jbrgw.DataTextField = "mc";
                ddlt_jbrgw.DataValueField = "bm";
                ddlt_jbrgw.DataBind();
                ddlt_jbrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void ddlt_jbrgw_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gw = ddlt_jbrgw.SelectedValue;
            if (gw == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_jbr.DataSource = dt;
                ddlt_jbr.DataBind();
                ddlt_jbr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                DataTable dt = new DataTable();
                dt = bmgw.Select_YGALL(gw).Tables[0];
                ddlt_jbr.DataSource = dt;
                ddlt_jbr.DataTextField = "xm";
                ddlt_jbr.DataValueField = "bh";
                ddlt_jbr.DataBind();
                ddlt_jbr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void ddlt_fzrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_fzrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_fzrgw.DataSource = dt;
                ddlt_fzrgw.DataBind();
                ddlt_fzrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_fzrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_fzrgw.DataTextField = "mc";
                ddlt_fzrgw.DataValueField = "bm";
                ddlt_fzrgw.DataBind();
                ddlt_fzrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void ddlt_fzrgw_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gw = ddlt_fzrgw.SelectedValue;
            if (gw == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_fzr.DataSource = dt;
                ddlt_fzr.DataBind();
                ddlt_fzr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                DataTable dt = new DataTable();
                dt = bmgw.Select_YGALL(gw).Tables[0];
                ddlt_fzr.DataSource = dt;
                ddlt_fzr.DataTextField = "xm";
                ddlt_fzr.DataValueField = "bh";
                ddlt_fzr.DataBind();
                ddlt_fzr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }
    }
}