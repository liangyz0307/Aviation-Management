using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.SKJS
{
    public partial class SKJS_SBBLK_Add : System.Web.UI.Page
    {
       // public UserState _us;
        private UserState _usState;
        private Struct_SBBLK struct_sbblk;
        static string csrbh;
        static string zsrbh;
        private SBBLK sbblk;
        private YG yg;
        static string syrbh;
        static string wxrybh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if((_usState = (Session["UserState"]as UserState))==null)
            {
                Response.Write("<script>alert(\"您还没有登陆或超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            sbblk = new SBBLK(_usState);
            yg = new YG(_usState);
            if(!IsPostBack)
            {
                ddlt_bypcBind();
                bind_drop();
            }
        }
        private void ddlt_bypcBind()
        {
            //保养频次
            ddlt_bypc.DataSource = SysData.BYPC().Copy();
            ddlt_bypc.DataTextField = "mc";
            ddlt_bypc.DataValueField = "bm";
            ddlt_bypc.DataBind();
            ddlt_bypc.Items.Insert(0, new ListItem("全部", "-1"));


            // 初始化审批人
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
            ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));


        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 赋值
            string sbmc = tbx_sbmc.Text.Trim().ToString();
            string dd = tbx_dd.Text.Trim().ToString();
            string sygw = tbx_sygw.Text.Trim().ToString();
            string synx = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            string gzsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string xx = tbx_xx.Text.Trim().ToString();
            string yy = tbx_yy.Text.Trim().ToString();
            string pgfs = tbx_pgfs.Text.Trim().ToString();
            string pgsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string bypc = ddlt_bypc.SelectedValue.ToString().Trim();
            string bz = tbx_bz.Text.Trim().ToString();
            
            #endregion
            #region label判断
            int flag = 0;
            //设备名称
            if (tbx_sbmc.Text == "")
            {
                lbl_sbmc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //地点
            if (tbx_dd.Text == "")
            {
                lbl_dd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //使用岗位
            if (tbx_sygw.Text == "")
            {
                lbl_sygw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sygw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //使用人
            if (tbx_syr.Text == "")
            {
                lbl_syr.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_syr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //使用年限
            if (tbx_synx.Text == "")
            {
                lbl_synx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_synx.Text.ToString(), synx))
                {
                    lbl_synx.Text = "<span style=\"color:#ff0000\">" + "请输入整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_synx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
           
            //故障时间
            if (tbx_gzsj.Text == "")
            {
                lbl_gzsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_gzsj.Text.ToString(), gzsj))
                {
                    lbl_gzsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_gzsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //现象
            if (tbx_xx.Text == "")
            {
                lbl_xx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //原因
            if (tbx_yy.Text == "")
            {
                lbl_yy.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //排故方式
            if (tbx_pgfs.Text == "")
            {
                lbl_pgfs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_pgfs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //排故时间
            if (tbx_pgsj.Text == "")
            {
                lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (tbx_pgsj.Text == "")
                {
                    lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "维修日期不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    if (!Regex.IsMatch(tbx_pgsj.Text.ToString(), pgsj))
                    {
                        lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_pgsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    }
                    DateTime gzsj1 = DateTime.Parse(tbx_gzsj.Text.ToString());
                    DateTime pgsj1 = DateTime.Parse(tbx_pgsj.Text.ToString());
                    if (gzsj1 > pgsj1)
                    {
                        lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "登记日期不能小于维修日期" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_pgsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    }
                }
            }
            //维修人员
            if (tbx_wxry.Text == "")
            {
                lbl_wxry.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxry.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            struct_sbblk.p_sbmc = sbmc;
            struct_sbblk.p_dd = dd;
            struct_sbblk.p_sygw = sygw;
            struct_sbblk.p_syr =syrbh.Substring(0,syrbh.Length-1);
            struct_sbblk.p_synx = tbx_synx.Text.ToString().Trim();
            struct_sbblk.p_gzsj = Convert.ToDateTime(tbx_gzsj.Text.Trim()).ToString("yyyy-MM-dd");
            struct_sbblk.p_xx = xx;
            struct_sbblk.p_yy = yy;
            struct_sbblk.p_pgfs = pgfs;
            struct_sbblk.p_pgsj = Convert.ToDateTime(tbx_pgsj.Text.Trim()).ToString("yyyy-MM-dd");
            struct_sbblk.p_czfs = "01";
            struct_sbblk.p_bypc = bypc;
            struct_sbblk.p_wxry = wxrybh.Substring(0,wxrybh.Length-1);
            struct_sbblk.p_bz = bz;
            struct_sbblk.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_sbblk.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_sbblk.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_sbblk.p_lrr = _usState.userLoginName.ToString();//录入人
            
            struct_sbblk.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳

            if (struct_sbblk.p_lrr.Equals(struct_sbblk.p_csr))
            {
                struct_sbblk.p_sjbs = "0";
                struct_sbblk.p_zt = "2";
            }
            //如果是终审人录入数据，则状态为审核通过
            else if (struct_sbblk.p_lrr.Equals(struct_sbblk.p_zsr))
            {
                struct_sbblk.p_sjbs = "1";
                struct_sbblk.p_zt = "3";
            }
            else
            {
                struct_sbblk.p_sjbs = "0";
                struct_sbblk.p_zt = "0";
            }


            struct_sbblk.p_czxx = "位置：三库建设->设备病例库->添加 描述：设备名称：" + struct_sbblk.p_sbmc + "地点："
                + struct_sbblk.p_dd + "使用岗位：" + struct_sbblk.p_sygw + "使用人" + struct_sbblk.p_syr
                + "使用年限：" + struct_sbblk.p_bz + "故障时间：" + struct_sbblk.p_gzsj + "现象： " + struct_sbblk.p_xx + "原因" + struct_sbblk.p_yy
                + "排故方式：" + struct_sbblk.p_pgfs + "排故时间：" + struct_sbblk.p_pgsj + "保养频次：" + struct_sbblk.p_bypc + "维修人员" + struct_sbblk.p_wxry
                + "备注" + struct_sbblk.p_bz;
            try
            {
                sbblk.Insert_SBBLK(struct_sbblk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (Exception em)
            {
                throw em;
            }
            #endregion
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SKJS/SKJS_SBBLK.aspx", true);
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
        
        private void bind_drop()
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
            string bmdm_wxry = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm_wxry = ddlt_gwdm_wxry.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();

            DataTable dt2 = new DataTable();
            dt2 = sbblk.Select_YGbyBMGW(bmdm_wxry, gwdm_wxry);
            ddlt_wxry.DataSource = dt;
            ddlt_wxry.DataTextField = "xm";
            ddlt_wxry.DataValueField = "bh";
            ddlt_wxry.DataBind();

            ddlt_bmdm_wxry.DataSource = SysData.BM().Copy();
            ddlt_bmdm_wxry.DataTextField = "mc";
            ddlt_bmdm_wxry.DataValueField = "bm";
            ddlt_bmdm_wxry.DataBind();
            ddlt_bmdm_wxry.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm_wxry.DataSource = SysData.GW().Copy();
            ddlt_gwdm_wxry.DataTextField = "mc";
            ddlt_gwdm_wxry.DataValueField = "bm";
            ddlt_gwdm_wxry.DataBind();
            ddlt_gwdm_wxry.Items.Insert(0, new ListItem("全部", "-1"));

        }
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm = ddlt_gwdm_wxry.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_wxry.DataSource = dt;
            ddlt_wxry.DataTextField = "xm";
            ddlt_wxry.DataValueField = "bh";
            ddlt_wxry.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm = ddlt_gwdm_wxry.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_wxry.DataSource = dt;
            ddlt_wxry.DataTextField = "xm";
            ddlt_wxry.DataValueField = "bh";
            ddlt_wxry.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }

        protected void btn_bc_syr_Click(object sender, EventArgs e)
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
        protected void btn_bc_wxry_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm = ddlt_gwdm_wxry.SelectedValue.ToString();
            string yg = ddlt_wxry.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_wxry.Items.Count > 0)
            {
                tbx_wxry.Text += ddlt_wxry.SelectedItem.Text + ",";
                wxrybh += ddlt_wxry.SelectedValue.ToString() + ",";
            }
        }
    }
}