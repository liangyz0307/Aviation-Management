
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BS_YSSB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private Struct_Bs_Yssb struct_bs_yssb;
        public YSSB yssb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yssb = new YSSB(_usState);
            if (!IsPostBack)
            {
                ddlt_yslxBind();
                ddlt_ztBind();
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 赋值
            string tbdw = tbx_tbdw.Text.Trim().ToString();
            string yjje = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            string yslx = ddlt_yslx.SelectedValue.Trim().ToString();
            string xmmc = tbx_xmmc.Text.Trim().ToString();
            string bz = tbx_bz.Text.Trim().ToString();
            string whdw = tbx_whdw.Text.Trim().ToString();
            string zt = ddlt_zt.SelectedValue.Trim().ToString();
            string sbnf = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string sjzxje = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            string yszx = tbx_yszx.Text.Trim().ToString();
            string tzyy = tbx_tzyy.Text.Trim().ToString();
            string wcsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            #endregion
            #region lable判断
            int flag = 0;
            //填报单位
            if (tbx_tbdw.Text == "")
            {
                lbl_tbdw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tbdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //预计金额
            if (tbx_yjje.Text == "")
            {
                lbl_yjje.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_yjje.Text.ToString(), yjje))
                {
                    lbl_yjje.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_yjje.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //预算类型
            if (ddlt_yslx.SelectedValue == "-1")
            {
                lbl_yslx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yslx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //项目名称
            if (tbx_xmmc.Text == "")
            {
                lbl_xmmc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xmmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //备注
            if (tbx_bz.Text == "")
            {
                lbl_bz.Text = "<span style=\"color:#ff0000\">" + "正确" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //维护单位
            if (tbx_whdw.Text == "")
            {
                lbl_whdw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_whdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //状态
            if (ddlt_zt.SelectedValue == "-1")
            {
                lbl_zt.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //申报年份
            //if (tbx_sbnf.Text == "")
            //{
            //    lbl_sbnf.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    if (!Regex.IsMatch(tbx_sbnf.Text.ToString(), sbnf))
            //    {
            //        lbl_sbnf.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
            //        flag = 1;
            //    }
            //    else
            //    {
            //        lbl_sbnf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //    }
            //}
            if (!Regex.IsMatch(tbx_sbnf.Text.ToString(), sbnf))
            {
                tbx_sbnf.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbnf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //实际执行金额
            if (tbx_sjzxje.Text == "")
            {
                lbl_sjzxje.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_sjzxje.Text.ToString(), sjzxje))
                {
                    lbl_sjzxje.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sjzxje.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //完成时间
            if (tbx_wcsj.Text == "")
            {
                lbl_wcsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (tbx_sbnf.Text == "")
                {
                    lbl_wcsj.Text = "<span style=\"color:#ff0000\">" + "维修日期不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    if (!Regex.IsMatch(tbx_wcsj.Text.ToString(), wcsj))
                    {
                        lbl_wcsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_wcsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    }
                    DateTime sbnf1 = DateTime.Parse(tbx_sbnf.Text.ToString());
                    DateTime wcsj2 = DateTime.Parse(tbx_wcsj.Text.ToString());
                    if (sbnf1 > wcsj2)
                    {
                        lbl_wcsj.Text = "<span style=\"color:#ff0000\">" + "登记日期不能小于维修日期" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_wcsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    }
                }
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
            if (flag == 1)
            { return; }
            #endregion
            #region 保存
            struct_bs_yssb.p_tbdw = tbdw;
            struct_bs_yssb.p_yjje = tbx_yjje.Text.Trim().ToString();
            struct_bs_yssb.p_yslx = yslx;
            struct_bs_yssb.p_xmmc = xmmc;
            struct_bs_yssb.p_bz = bz;
            struct_bs_yssb.p_whdw = whdw;
            struct_bs_yssb.p_sbnf = Convert.ToDateTime(tbx_sbnf.Text.Trim()).ToString("yyyy-MM-dd");
            struct_bs_yssb.p_sjzxje = tbx_sjzxje.Text.Trim().ToString();
            struct_bs_yssb.p_yszx = yszx;
            struct_bs_yssb.p_tzyy = tzyy;
            struct_bs_yssb.p_wcsj = Convert.ToDateTime(tbx_wcsj.Text.Trim()).ToString("yyyy-MM-dd");
            struct_bs_yssb.p_czfs = "01";
            struct_bs_yssb.p_zt = zt;


            struct_bs_yssb.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_bs_yssb.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_bs_yssb.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_bs_yssb.p_lrr = _usState.userLoginName.ToString();//录入人

            struct_bs_yssb.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳

            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_bs_yssb.p_lrr.Equals(struct_bs_yssb.p_csr))
            {
                struct_bs_yssb.p_sjbs = "0";
                struct_bs_yssb.p_sbzt = "2";
            }
            //如果是终审人录入数据，则状态为审核通过
            else if (struct_bs_yssb.p_lrr.Equals(struct_bs_yssb.p_zsr))
            {
                struct_bs_yssb.p_sjbs = "1";
                struct_bs_yssb.p_sbzt = "3";
            }
            else
            {
                struct_bs_yssb.p_sjbs = "0";
                struct_bs_yssb.p_sbzt = "0";
            }




            struct_bs_yssb.p_czxx = "位置：航务综合信息报送系统->预算申报->添加      描述：填报单位：" + struct_bs_yssb.p_tbdw + "预计金额："
                + struct_bs_yssb.p_yjje + "预算类型：" + struct_bs_yssb.p_yslx + "项目名称" + struct_bs_yssb.p_xmmc
                + "备注：" + struct_bs_yssb.p_bz + "维护单位：" + struct_bs_yssb.p_whdw + "状态： " + struct_bs_yssb.p_zt + "申报年份" + struct_bs_yssb.p_sbnf
                + "实际执行金额：" + struct_bs_yssb.p_sjzxje + "预算增项：" + struct_bs_yssb.p_yszx + "调整原因：" + struct_bs_yssb.p_tzyy + "完成时间：" + struct_bs_yssb.p_wcsj;
            try
            {
                yssb.Insert_Bs_Yssb(struct_bs_yssb);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (Exception em)
            {
                throw em;
            }
            #endregion

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
            Response.Redirect("../BaoSong/BS_YSSB.aspx", true);
        }
        protected void ddlt_yslxBind()//绑定预算类型
        {
            ddlt_yslx.DataSource = yssb.Select_Bs_Yssb_Yslx().Copy();
            ddlt_yslx.DataTextField = "mc";
            ddlt_yslx.DataValueField = "bm";
            ddlt_yslx.DataBind();
            ddlt_yslx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void ddlt_ztBind()//绑定状态
        {
            ddlt_zt.DataSource = yssb.Select_Bs_Yssb_Zt().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));


            // 初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("13");

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

    }
}