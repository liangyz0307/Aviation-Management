using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Tools;
using System.Text.RegularExpressions;
using System.IO;

namespace CUST.WKG
{
    public partial class BS_BXDJ_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private Struct_Bs_Wxfy_Bxdj struct_bs_wxfy_bxdj;
        public string xmmc;
        public WXFY wxfy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            wxfy = new WXFY(_usState);
            if (!IsPostBack)
            {
                xmmc = Request.Params["xmmc"].ToString();
                ddltBind();
                select_detail();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string zj = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            #region lable判断
            int flag = 0;
            //登记单位
            if (ddlt_sjyszxjc.SelectedValue == "-1")
            {
                lbl_sjyszxjc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjyszxjc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //预算费用
            if (tbx_zj.Text == "")
            {
                lbl_zj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_zj.Text.ToString(), zj))
                {
                    lbl_zj.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            if (flag == 1)
            { return; }
            #endregion
            struct_bs_wxfy_bxdj.p_xmmc = Request.Params["xmmc"].ToString();//项目名称
            struct_bs_wxfy_bxdj.p_zj = tbx_zj.Text.Trim().ToString();//总计
            struct_bs_wxfy_bxdj.p_sjyszxjc = ddlt_sjyszxjc.SelectedValue.Trim().ToString();//实际预算执行机场
            struct_bs_wxfy_bxdj.p_djrq = tbx_djrq.Text.Trim().ToString().Substring(0,10);//登记日期

            struct_bs_wxfy_bxdj.p_czfs = "03";//操作方式
            struct_bs_wxfy_bxdj.p_czxx = "位置：航务综合信息报送系统->维修费用->报销登记->编辑      描述：员工：" + _usState.userLoginName;
            wxfy.Update_Bs_Bxdj(struct_bs_wxfy_bxdj);
            Server.Transfer("../BaoSong/BS_WXFY_Bxdj.aspx?xmmc=" + Request.Params["xmmc"].ToString());
            //Response.Redirect("../BaoSong/BS_WXFY_Bxdj.aspx?xmmc=" + Request.Params["xmmc"].ToString(), true);
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
            xmmc = Request.Params["xmmc"].ToString();
            Response.Redirect("../BaoSong/BS_WXFY_Bxdj.aspx?xmmc=" + xmmc, true);
        }

        protected void ddltBind()
        {
            //实际预算执行机场(支线)
            ddlt_sjyszxjc.DataSource = SysData.ZXDM().Copy();
            ddlt_sjyszxjc.DataTextField = "mc";
            ddlt_sjyszxjc.DataValueField = "bm";
            ddlt_sjyszxjc.DataBind();
            ddlt_sjyszxjc.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        protected void select_detail()
        {
            //项目名称
            struct_bs_wxfy_bxdj.p_xmmc= Request.Params["xmmc"].ToString();            
            DataTable dt_bxdj=wxfy.Select_Bxdj_ByXmmc(struct_bs_wxfy_bxdj);
            tbx_zj.Text = dt_bxdj.Rows[0]["zj"].ToString();
            tbx_djrq.Text = dt_bxdj.Rows[0]["djrq"].ToString().Substring(0,10);
            ddlt_sjyszxjc.SelectedValue = dt_bxdj.Rows[0]["sjyszxjc"].ToString();
        }
    }
}