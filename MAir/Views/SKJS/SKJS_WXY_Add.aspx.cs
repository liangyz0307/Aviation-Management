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
using System.Text.RegularExpressions;
using System.Globalization;

namespace CUST.WKG
{
    public partial class SKJS_WXY_Add : System.Web.UI.Page

    {
        private UserState _usState;
        private WXY wxy;
        private Struct_WXY struct_wxy;
        static string syrbh;
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            wxy = new WXY(_usState);
            if (!IsPostBack)
            {
                 yg_bind();
                 ddltBind();

            }
        }
        private void yg_bind()
        {
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = wxy.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = wxy.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = wxy.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_syr.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr.Items.Count > 0)
            {
                tbx_syr.Text += ddlt_syr.SelectedItem.Text + ",";
                syrbh += ddlt_syr.SelectedValue.ToString() + ",";
            }
        }
        private void ddltBind()
        {
            //岗位
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
            //严重性
            ddlt_yzx.DataSource = SysData.YZCD().Copy();
            ddlt_yzx.DataTextField = "mc";
            ddlt_yzx.DataValueField = "bm";
            ddlt_yzx.DataBind();
            ddlt_yzx.Items.Insert(0, new ListItem("全部", "-1"));
            //危险源范畴
            ddlt_fc.DataSource = SysData.WXYFC().Copy();
            ddlt_fc.DataTextField = "mc";
            ddlt_fc.DataValueField = "bm";
            ddlt_fc.DataBind();
            ddlt_fc.Items.Insert(0, new ListItem("全部", "-1"));
            //时态
            ddlt_st.DataSource = SysData.STDM().Copy();
            ddlt_st.DataTextField = "mc";
            ddlt_st.DataValueField = "bm";
            ddlt_st.DataBind();
            ddlt_st.Items.Insert(0, new ListItem("全部", "-1"));
            //风险情景发生的可能性
            ddlt_knx.DataSource = SysData.FXFSKN().Copy();
            ddlt_knx.DataTextField = "mc";
            ddlt_knx.DataValueField = "bm";
            ddlt_knx.DataBind();
            ddlt_knx.Items.Insert(0, new ListItem("全部", "-1"));
            //风险程度
            ddlt_fxcd.DataSource = SysData.FXCD().Copy();
            ddlt_fxcd.DataTextField = "mc";
            ddlt_fxcd.DataValueField = "bm";
            ddlt_fxcd.DataBind();
            ddlt_fxcd.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.FXYZT().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            //控制状态
            ddlt_kzzt.DataSource = SysData.FXKZZT().Copy();
            ddlt_kzzt.DataTextField = "mc";
            ddlt_kzzt.DataValueField = "bm";
            ddlt_kzzt.DataBind();
            ddlt_kzzt.Items.Insert(0, new ListItem("全部", "-1"));
            //控制措施标准化情况
            ddlt_bzh.DataSource = SysData.ZGCSBZHQK().Copy();
            ddlt_bzh.DataTextField = "mc";
            ddlt_bzh.DataValueField = "bm";
            ddlt_bzh.DataBind();
            ddlt_bzh.Items.Insert(0, new ListItem("全部", "-1"));
            //控制部门（二级）
            ddlt_bmej.DataSource = SysData.BM().Copy();
            ddlt_bmej.DataTextField = "mc";
            ddlt_bmej.DataValueField = "bm";
            ddlt_bmej.DataBind();
            ddlt_bmej.Items.Insert(0, new ListItem("全部", "-1"));
            //控制部门（三级）
            ddlt_bmsj.DataSource = SysData.BM().Copy();
            ddlt_bmsj.DataTextField = "mc";
            ddlt_bmsj.DataValueField = "bm";
            ddlt_bmsj.DataBind();
            ddlt_bmsj.Items.Insert(0, new ListItem("全部", "-1"));
            //配合部门
            ddlt_phbm.DataSource = SysData.BM().Copy();
            ddlt_phbm.DataTextField = "mc";
            ddlt_phbm.DataValueField = "bm";
            ddlt_phbm.DataBind();
            ddlt_phbm.Items.Insert(0, new ListItem("全部", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("20");

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
            Response.Redirect("../SKJS/SKJS_WXY.aspx", true);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int flag=0;
            string mc = tbx_mc.Text.Trim();
            string gw = ddlt_gw.SelectedValue.ToString().Trim();
            string fc = ddlt_fc.SelectedValue.ToString().Trim();
            string yy = tbx_yy.Text.Trim();
            string hg = tbx_hg.Text.Trim(); ;
            string xgal = tbx_xgal.Text.Trim();
            string yf = @"^(0?[[1-9]|1[0-2])$";
            string st = ddlt_st.SelectedValue.ToString().Trim();
            string knx = ddlt_knx.SelectedValue.ToString().Trim();
            string yzx = ddlt_yzx.SelectedValue.ToString().Trim();
            string fxcd = ddlt_fxcd.SelectedValue.ToString().Trim();
            string zt = ddlt_zt.SelectedValue.ToString().Trim();
            string yj = tbx_yj.Text.Trim();
            string kzzt = ddlt_kzzt.SelectedValue.ToString().Trim();
            string bzhqk = ddlt_bzh.SelectedValue.ToString().Trim();
            string ya = tbx_ya.Text.Trim();
            string bmej = ddlt_bmej.SelectedValue.ToString().Trim();
            string bmsj = ddlt_bmsj.SelectedValue.ToString().Trim();
            string phbm = ddlt_phbm.SelectedValue.ToString().Trim();
            string zrr = syrbh.Substring(0, syrbh.Length - 1);

            if (string.IsNullOrEmpty(mc))
            {
                lbl_mc.Text = "<span style=\"color:#ff0000\">" + "错误：名称不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(fc))
            {
                lbl_fc.Text = "<span style=\"color:#ff0000\">" + "错误：危险源范畴不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(gw))
            {
                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "错误：岗位不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //月份
            if (tbx_yf.Text == "")
            {
                lbl_yf.Text = "<span style=\"color:#ff0000\">" + "月份不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_yf.Text.ToString(), yf))
                {
                    lbl_yf.Text = "<span style=\"color:#ff0000\">" + "月份格式不正确" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_yf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            if (string.IsNullOrEmpty(st))
            {
                lbl_st.Text = "<span style=\"color:#ff0000\">" + "错误：时态不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_st.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(knx))
            {
                lbl_knx.Text = "<span style=\"color:#ff0000\">" + "错误：风险发生的可能性不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_knx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(yzx))
            {
                lbl_yzx.Text = "<span style=\"color:#ff0000\">" + "错误：后果的严重性不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yzx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(fxcd))
            {
                lbl_fxcd.Text = "<span style=\"color:#ff0000\">" + "错误：风险程度不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fxcd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(zt))
            {
                lbl_zt.Text = "<span style=\"color:#ff0000\">" + "错误：状态不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(kzzt))
            {
                lbl_kzzt.Text = "<span style=\"color:#ff0000\">" + "错误：风险控制状态不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_kzzt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(yy))
            {
                lbl_yy.Text = "<span style=\"color:#ff0000\">" + "错误：诱发原因不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(hg))
            {
                lbl_hg.Text = "<span style=\"color:#ff0000\">" + "错误：后果不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_hg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(ya))
            {
                lbl_ya.Text = "<span style=\"color:#ff0000\">" + "错误：风险控制预案不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ya.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(yj))
            {
                lbl_yj.Text = "<span style=\"color:#ff0000\">" + "错误：应急措施不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            if (flag == 1) { return; }
            lbl_xgal.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_bzh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_bmej.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_bmsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_phbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            if (flag==1)
                return;
            struct_wxy.p_mc = tbx_mc.Text.Trim();
            struct_wxy.p_gw = ddlt_gw.SelectedValue.ToString().Trim();
            struct_wxy.p_fc = ddlt_fc.SelectedValue.ToString().Trim();
            struct_wxy.p_yy = tbx_yy.Text.Trim();
            struct_wxy.p_hg = tbx_hg.Text.Trim(); ;
            struct_wxy.p_xgal = tbx_xgal.Text.Trim();
            struct_wxy.p_yf = Convert.ToInt32(tbx_yf.Text);
            struct_wxy.p_st = ddlt_st.SelectedValue.ToString().Trim();
            struct_wxy.p_knx = ddlt_knx.SelectedValue.ToString().Trim();
            struct_wxy.p_yzx = ddlt_yzx.SelectedValue.ToString().Trim();
            struct_wxy.p_fxcd = ddlt_fxcd.SelectedValue.ToString().Trim();
            struct_wxy.p_yj = tbx_yj.Text.Trim();
            struct_wxy.p_kzzt = ddlt_kzzt.SelectedValue.ToString().Trim();
            struct_wxy.p_bzhqk = ddlt_bzh.SelectedValue.ToString().Trim();
            struct_wxy.p_ya = tbx_ya.Text.Trim();
            struct_wxy.p_bmej = ddlt_bmej.SelectedValue.ToString().Trim();
            struct_wxy.p_bmsj = ddlt_bmsj.SelectedValue.ToString().Trim();
            struct_wxy.p_phbm = ddlt_phbm.SelectedValue.ToString().Trim();
            struct_wxy.p_zrr = zrr;

            struct_wxy.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_wxy.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_wxy.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_wxy.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_wxy.p_sjbs = "0";
            struct_wxy.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);//时间戳


            struct_wxy.p_czfs = "01";
            struct_wxy.p_czxx = "位置：三库建设->危险源->添加      描述：报送岗位："
                + struct_wxy.p_gw + "危险源范畴：" + struct_wxy.p_fc + "诱发原因：" + struct_wxy.p_yy
                + "后果：" + struct_wxy.p_hg + "相关案例：" + struct_wxy.p_xgal + "月份：" + struct_wxy.p_yf
                + "时态：" + struct_wxy.p_st + "风险情景发生的可能性：" + struct_wxy.p_knx + "风险情景发生的严重性：" + struct_wxy.p_yzx
                + "风险控制措施或预案：" + struct_wxy.p_ya
                + "风 险 程 度：" + struct_wxy.p_fxcd + "风 险 源 状 态：" + struct_wxy.p_zt
                + "控 制 状 态：" + struct_wxy.p_kzzt + "控制措施标准化情况：" + struct_wxy.p_bzhqk
                 + "应急措施：" + struct_wxy.p_yj 
                + "责任部门（二级）：" + struct_wxy.p_bmej + "责任部门（三级）：" + struct_wxy.p_bmsj + "配合部门：" + struct_wxy.p_phbm + "责任人：" + struct_wxy.p_zrr;
            wxy.Insert_WXY(struct_wxy);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");

            
        }

        protected void tbx_mc_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tbx_yj_TextChanged(object sender, EventArgs e)
        {

        }
    }
}