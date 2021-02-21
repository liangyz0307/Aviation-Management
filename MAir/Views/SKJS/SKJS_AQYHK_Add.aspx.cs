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
    public partial class SKJS_AQYHK_Add : System.Web.UI.Page
    {
        private UserState _us;
        private AQYHK aqyhk;
        static string zgzrr;
        static string zgdbzrr;
        static string zgyzr;
        public bool flag = true;
        public int i = 0;
        private Struct_AQYHK struct_aqyhk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            aqyhk = new AQYHK(_us);
            struct_aqyhk = new Struct_AQYHK();
            if (!IsPostBack)
            {
                Bind();

            }
        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;

            }
        }
        private void Bind()
        {
            //隐患等级
            ddlt_yhdj.DataSource = SysData.YHDJ().Copy();
            ddlt_yhdj.DataTextField = "mc";
            ddlt_yhdj.DataValueField = "bm";
            ddlt_yhdj.DataBind();
            ddlt_yhdj.Items.Insert(0, new ListItem("请选择", "-1"));
            //来源
            ddlt_ly.DataSource = SysData.LY().Copy();
            ddlt_ly.DataTextField = "mc";
            ddlt_ly.DataValueField = "bm";
            ddlt_ly.DataBind();
            ddlt_ly.Items.Insert(0, new ListItem("请选择", "-1"));
            //整改关闭批准
            ddlt_zggbpz.DataSource = SysData.ZGGBPZ().Copy();
            ddlt_zggbpz.DataTextField = "mc";
            ddlt_zggbpz.DataValueField = "bm";
            ddlt_zggbpz.DataBind();
            ddlt_zggbpz.Items.Insert(0, new ListItem("请选择", "-1"));
            //整改责任单位
            #region 整改责任单位
            DataTable dt_bmdm = SysData.BM().Copy();
            int count = 0;

            //查询权限

            for (; i < dt_bmdm.Rows.Count; i++)
            {

                check();
                if (dt_bmdm.Rows[i]["bm"].ToString() == "01" && SysData.HasThisQX("200302", _us.userID, "01") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (i == dt_bmdm.Rows.Count) { break; }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "02" && SysData.HasThisQX("200302", _us.userID, "02") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "03" && SysData.HasThisQX("200302", _us.userID, "03") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "04" && SysData.HasThisQX("200302", _us.userID, "04") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }

                if (dt_bmdm.Rows[i]["bm"].ToString() == "05" && SysData.HasThisQX("200302", _us.userID, "05") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                check();
            }

            ddlt_zgzrdw.DataSource = dt_bmdm;
            ddlt_zgzrdw.DataTextField = "mc";
            ddlt_zgzrdw.DataValueField = "bm";
            ddlt_zgzrdw.DataBind();
            ddlt_zgzrdw.Items.Insert(0, new ListItem("请选择", "-1"));
            #endregion
            //填报单位
            #region 填报单位
            ddlt_tbdw.DataSource = dt_bmdm;
            ddlt_tbdw.DataTextField = "mc";
            ddlt_tbdw.DataValueField = "bm";
            ddlt_tbdw.DataBind();
            ddlt_tbdw.Items.Insert(0, new ListItem("请选择", "-1"));
            #endregion
            #region 员工选择框1
            ddlt_bmdm1.DataSource = dt_bmdm;
            ddlt_bmdm1.DataTextField = "mc";
            ddlt_bmdm1.DataValueField = "bm";
            ddlt_bmdm1.DataBind();
            ddlt_bmdm1.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm1.DataSource = SysData.GW().Copy();
            ddlt_gwdm1.DataTextField = "mc";
            ddlt_gwdm1.DataValueField = "bm";
            ddlt_gwdm1.DataBind();
            ddlt_gwdm1.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr1.DataSource = dt;
            ddlt_syr1.DataTextField = "xm";
            ddlt_syr1.DataValueField = "bh";
            ddlt_syr1.DataBind();
            #endregion
            #region 员工选择框2
            ddlt_bmdm2.DataSource = dt_bmdm;
            ddlt_bmdm2.DataTextField = "mc";
            ddlt_bmdm2.DataValueField = "bm";
            ddlt_bmdm2.DataBind();
            ddlt_bmdm2.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm2.DataSource = SysData.GW().Copy();
            ddlt_gwdm2.DataTextField = "mc";
            ddlt_gwdm2.DataValueField = "bm";
            ddlt_gwdm2.DataBind();
            ddlt_gwdm2.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm2 = ddlt_bmdm2.SelectedValue.ToString();
            string gwdm2 = ddlt_gwdm2.SelectedValue.ToString();
            DataTable dt2 = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr2.DataSource = dt;
            ddlt_syr2.DataTextField = "xm";
            ddlt_syr2.DataValueField = "bh";
            ddlt_syr2.DataBind();
            #endregion
            #region 员工选择框3
            ddlt_bmdm3.DataSource = dt_bmdm;
            ddlt_bmdm3.DataTextField = "mc";
            ddlt_bmdm3.DataValueField = "bm";
            ddlt_bmdm3.DataBind();
            ddlt_bmdm3.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm3.DataSource = SysData.GW().Copy();
            ddlt_gwdm3.DataTextField = "mc";
            ddlt_gwdm3.DataValueField = "bm";
            ddlt_gwdm3.DataBind();
            ddlt_gwdm3.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm3 = ddlt_bmdm3.SelectedValue.ToString();
            string gwdm3 = ddlt_gwdm3.SelectedValue.ToString();
            DataTable dt3 = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr3.DataSource = dt;
            ddlt_syr3.DataTextField = "xm";
            ddlt_syr3.DataValueField = "bh";
            ddlt_syr3.DataBind();
            #endregion

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
        #region tbx_zgzrrxm.Text数据绑定
        protected void ddlt_gwdm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr1.DataSource = dt;
            ddlt_syr1.DataTextField = "xm";
            ddlt_syr1.DataValueField = "bh";
            ddlt_syr1.DataBind();
        }
        protected void ddlt_bmdm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr1.DataSource = dt;
            ddlt_syr1.DataTextField = "xm";
            ddlt_syr1.DataValueField = "bh";
            ddlt_syr1.DataBind();
        }
        protected void btn_bc_syr1_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            string yg = ddlt_syr1.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr1.Items.Count > 0)
            {
                tbx_zgzrrxm.Text = ddlt_syr1.SelectedItem.Text;
                zgzrr = ddlt_syr1.SelectedValue.ToString();
            }
        }
        #endregion
        #region tbx_zgdbzrrxm.Text数据绑定
        protected void ddlt_gwdm2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm2.SelectedValue.ToString();
            string gwdm = ddlt_gwdm2.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr2.DataSource = dt;
            ddlt_syr2.DataTextField = "xm";
            ddlt_syr2.DataValueField = "bh";
            ddlt_syr2.DataBind();
        }
        protected void ddlt_bmdm2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm2.SelectedValue.ToString();
            string gwdm = ddlt_gwdm2.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr2.DataSource = dt;
            ddlt_syr2.DataTextField = "xm";
            ddlt_syr2.DataValueField = "bh";
            ddlt_syr2.DataBind();
        }
        protected void btn_bc_syr2_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm2.SelectedValue.ToString();
            string gwdm = ddlt_gwdm2.SelectedValue.ToString();
            string yg = ddlt_syr2.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr2.Items.Count > 0)
            {
                tbx_zgdbzrrxm.Text = ddlt_syr2.SelectedItem.Text;
                zgdbzrr = ddlt_syr2.SelectedValue.ToString();
            }
        }
        #endregion
        #region tbx_zgyzrxm.Text数据绑定
        protected void ddlt_gwdm3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm3.SelectedValue.ToString();
            string gwdm = ddlt_gwdm3.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr3.DataSource = dt;
            ddlt_syr3.DataTextField = "xm";
            ddlt_syr3.DataValueField = "bh";
            ddlt_syr3.DataBind();
        }
        protected void ddlt_bmdm3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm3.SelectedValue.ToString();
            string gwdm = ddlt_gwdm3.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqyhk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr3.DataSource = dt;
            ddlt_syr3.DataTextField = "xm";
            ddlt_syr3.DataValueField = "bh";
            ddlt_syr3.DataBind();
        }
        protected void btn_bc_syr3_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm3.SelectedValue.ToString();
            string gwdm = ddlt_gwdm3.SelectedValue.ToString();
            string yg = ddlt_syr2.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr3.Items.Count > 0)
            {
                tbx_zgyzrxm.Text = ddlt_syr3.SelectedItem.Text;
                zgyzr = ddlt_syr3.SelectedValue.ToString();
            }
        }
        #endregion
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 赋值
            string yhfxsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string zggbsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string zgwcsx = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string ly = ddlt_ly.SelectedValue.ToString().Trim();
            string tbdw = ddlt_tbdw.SelectedValue.ToString().Trim();
            string yhdj = ddlt_yhdj.SelectedValue.ToString().Trim();
            string zgzrdw = ddlt_zgzrdw.SelectedValue.ToString().Trim();
            string zggbpz = ddlt_zggbpz.SelectedValue.ToString().Trim();
            #endregion
            #region label判断
            int flag = 0;

            //隐患发现时间
            if (tbx_yhfxsj.Text == "")
            {
                lbl_yhfxsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_yhfxsj.Text.ToString(), yhfxsj))
                {
                    lbl_yhfxsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_yhfxsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //整改关闭时间
            if (tbx_zggbsj.Text == "")
            {
                lbl_zggbsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_zggbsj.Text.ToString(), zggbsj))
                {
                    lbl_zggbsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zggbsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //整改完成时限
            if (tbx_zgwcsx.Text == "")
            {
                lbl_zgwcsx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_zgwcsx.Text.ToString(), zgwcsx))
                {
                    lbl_zgwcsx.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zgwcsx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            struct_aqyhk.p_ygbh = _us.userLoginName;//填报人
            struct_aqyhk.p_tbrq = DateTime.Parse(DateTime.Now.ToString());//填报日期
            struct_aqyhk.p_tbdw = tbdw;//填报单位
            struct_aqyhk.p_yhfxsj = DateTime.Parse(tbx_yhfxsj.Text.ToString().Trim());//隐患发现时间
            struct_aqyhk.p_ly = ly;//来源
            struct_aqyhk.p_zt = "0";//状态
            struct_aqyhk.p_yhms = tbx_yhms.Text.ToString().Trim(); //隐患描述
            struct_aqyhk.p_knzcwh = tbx_knzcwh.Text.ToString().Trim(); //可能造成的危害
            struct_aqyhk.p_yhdj = yhdj; // 隐患等级
            struct_aqyhk.p_pgfjpz = tbx_pgfjpz.Text.ToString().Trim(); // 评估分级批准
            struct_aqyhk.p_zgcs = tbx_zgcs.Text.ToString().Trim(); // 整改措施及临时控制措施
            struct_aqyhk.p_yjtrfy = tbx_yjtrfy.Text.ToString().Trim(); // 预计投入费用
            struct_aqyhk.p_zgwcsx = DateTime.Parse(tbx_zgwcsx.Text.ToString().Trim()); // 整改完成时限
            struct_aqyhk.p_wcjdms = tbx_wcjdms.Text.ToString().Trim(); // 完成进度描述
            struct_aqyhk.p_zgzrdw = zgzrdw; // 整改责任单位
            struct_aqyhk.p_zgzrr = zgzrr.Substring(0, zgzrr.Length); // 整改责任人
            struct_aqyhk.p_zgdbzrr = zgdbzrr.Substring(0, zgdbzrr.Length); ; // 整改督办责任人
            struct_aqyhk.p_zgfapz = tbx_zgfapz.Text.ToString().Trim(); // 整改方案批准
            struct_aqyhk.p_zgyzjg = tbx_zgyzjg.Text.ToString().Trim();// 整改验证结果
            struct_aqyhk.p_zgyzr = zgyzr.Substring(0, zgyzr.Length);// 整改验证人
            struct_aqyhk.p_zggbsj = DateTime.Parse(tbx_zggbsj.Text.ToString().Trim());// 整改关闭时间
            struct_aqyhk.p_zggbbz = tbx_zggbbz.Text.ToString().Trim();//整改关闭标准
            struct_aqyhk.p_zggbpz = zggbpz;//整改关闭批准
            struct_aqyhk.p_xgtzbcqk = tbx_xgtzbcqk.Text.ToString().Trim();//相关台账保存情况

            struct_aqyhk.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_aqyhk.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_aqyhk.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_aqyhk.p_lrr = _us.userLoginName.ToString();//录入人
            struct_aqyhk.p_sjbs = "0";
            struct_aqyhk.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);//时间戳

            struct_aqyhk.p_czfs = "01";
            struct_aqyhk.p_czxx = "位置：三库建设->安全隐患库->添加 描述：填报人：" + struct_aqyhk.p_ygbh + "填报日期："
                + struct_aqyhk.p_tbrq + "填报单位：" + struct_aqyhk.p_tbdw + "隐患发现时间" + struct_aqyhk.p_yhfxsj
                + "来源：" + struct_aqyhk.p_ly + "隐患描述：" + struct_aqyhk.p_yhms + "可能造成的危害： " + struct_aqyhk.p_knzcwh + "隐患等级" + struct_aqyhk.p_yhdj
                + "评估分级批准：" + struct_aqyhk.p_pgfjpz + "整改措施及临时控制措施：" + struct_aqyhk.p_zgcs + "预计投入费用：" + struct_aqyhk.p_yjtrfy + "整改完成时限" + struct_aqyhk.p_zgwcsx
                + "完成进度描述" + struct_aqyhk.p_wcjdms + "整改责任单位：" + struct_aqyhk.p_zgzrdw + "整改责任人： " + struct_aqyhk.p_zgzrr + "整改督办责任人" + struct_aqyhk.p_zgdbzrr
                + "整改方案批准：" + struct_aqyhk.p_zgfapz + "整改验证结果：" + struct_aqyhk.p_zgyzjg + "整改验证人：" + struct_aqyhk.p_zgyzr + "整改关闭时间" + struct_aqyhk.p_zggbsj
                + "整改关闭标准" + struct_aqyhk.p_zggbbz + "整改关闭批准" + struct_aqyhk.p_zggbpz + "相关台账保存情况" + struct_aqyhk.p_xgtzbcqk;
            try
            {
                aqyhk.Insert_AQYHK(struct_aqyhk);
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
            Response.Redirect("../SKJS/SKJS_AQYHK.aspx", true);
        }
    }
}