
using CUST;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BS_YSSB_Edit : System.Web.UI.Page
    {
        private UserState _usState;

        private YSSB yssb;
        private Struct_Bs_Yssb_Update struct_bs_yssb_update;
       // private string p_id;
        private int id;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            
            yssb = new YSSB(_usState);
            //p_id = Request.QueryString["id"].ToString();
            //struct_bs_yssb_update.p_id = Request.QueryString["id"].ToString();
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                ddlt_yslxBind();
                ddlt_ztBind();
                select_detail();
            }
        }
        protected void select_detail()
        {
            dt_detail = yssb.Select_Bs_Yssb_Detail(id);
            tbx_tbdw.Text = dt_detail.Rows[0]["tbdw"].ToString();
            tbx_yjje.Text = dt_detail.Rows[0]["yjje"].ToString();
            ddlt_yslx.SelectedValue = dt_detail.Rows[0]["yslx"].ToString();
            tbx_xmmc.Text = dt_detail.Rows[0]["xmmc"].ToString();
            tbx_whdw.Text = dt_detail.Rows[0]["whdw"].ToString();
            ddlt_zt.SelectedValue = dt_detail.Rows[0]["zt"].ToString();
            tbx_sbnf.Text = Convert.ToDateTime(dt_detail.Rows[0]["sbnf"]).ToString("yyyy-MM-dd");
            tbx_sjzxje.Text = dt_detail.Rows[0]["sjzxje"].ToString();
            tbx_yszx.Text = dt_detail.Rows[0]["yszx"].ToString();
            tbx_tzyy.Text = dt_detail.Rows[0]["tzyy"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            tbx_wcsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["wcsj"]).ToString("yyyy-MM-dd");
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门

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


            //初始化审批人
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
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 赋值
            string tbdw = tbx_tbdw.Text.Trim().ToString();
            string yjje = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            string sjzxje= @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            string yslx = ddlt_yslx.SelectedValue.Trim().ToString();
            string xmmc = tbx_xmmc.Text.Trim().ToString();
            string whdw = tbx_whdw.Text.Trim().ToString();
            string zt = ddlt_zt.SelectedValue.Trim().ToString();
            string sbnf = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string bz = tbx_bz.Text.Trim().ToString();
            string yszx = tbx_yszx.Text.Trim().ToString();
            string tzyy = tbx_tzyy.Text.Trim().ToString();
            string wcsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            #endregion
            #region lable判断输入
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
            //预算金额
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
            if (tbx_sbnf.Text == "")
            {
                lbl_sbnf.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_sbnf.Text.ToString(), sbnf))
                {
                    lbl_sbnf.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sbnf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
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
            //备注
            if (tbx_bz.Text == "")
            {
               
                lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            else
                lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
                    lbl_sjzxje.Text = "<span style=\"color:#ff0000\">" + "只能输入小数或整数" + "</span>";
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
                if (tbx_wcsj.Text == "")
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
                    DateTime sbnf1 = DateTime.Parse(tbx_wcsj.Text.ToString());
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
            #region 判断修改
            id = Convert.ToInt32(Request.Params["id"].ToString());
            struct_bs_yssb_update.p_id = id;
            struct_bs_yssb_update.p_tbdw = tbdw;
            struct_bs_yssb_update.p_yjje = tbx_yjje.Text.Trim().ToString();
            struct_bs_yssb_update.p_yslx = yslx;
            struct_bs_yssb_update.p_xmmc = xmmc;
            struct_bs_yssb_update.p_bz = bz;
            struct_bs_yssb_update.p_whdw = whdw;
            struct_bs_yssb_update.p_zt = zt;
            struct_bs_yssb_update.p_sbnf = tbx_sbnf.Text.Trim().ToString();
            struct_bs_yssb_update.p_sjzxje = tbx_sjzxje.Text.Trim().ToString();
            struct_bs_yssb_update.p_yszx = tbx_yszx.Text.Trim().ToString();
            struct_bs_yssb_update.p_tzyy = tbx_tzyy.Text.Trim().ToString();
            struct_bs_yssb_update.p_wcsj = tbx_wcsj.Text.Trim().ToString();

            struct_bs_yssb_update.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所属部门
            struct_bs_yssb_update.p_lrr = _usState.userLoginName;//录入人
            struct_bs_yssb_update.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_bs_yssb_update.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_bs_yssb_update.p_czfs = "02";
            
            DataTable dt_detail = yssb.Select_Bs_Yssb_Detail(id);
            struct_bs_yssb_update.p_czxx = "位置：航务综合信息报送系统->预算申报->编辑    报送编号：[" + struct_bs_yssb_update.p_tbdw + "] ";

            string sjbs = Request.Params["sjbs"].ToString();
            if (sjbs.Equals("0") || sjbs.Equals("2"))
            {
                yssb.Update_Bs_Yssb(struct_bs_yssb_update);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
            }
            else if (sjbs.Equals("1") || sjbs.Equals("3"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = yssb.YSSB_SJBF(Convert.ToInt32(id));
                struct_bs_yssb_update.p_id = id_bf;
                yssb.Update_Bs_Yssb(struct_bs_yssb_update);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
                

            }
            else
            {
                return;
            }
            
            

            #endregion
        }

    }
}