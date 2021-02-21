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


namespace CUST.WKG
{
    public partial class SKJS_AQYHK_Edit : System.Web.UI.Page
    {
        private UserState _us;
        private AQYHK aqyhk;
        private string zgzrr;
        private string zgdbzrr;
        private string zgyzr;
        public bool flag = true;
        public int i = 0;
        private Struct_AQYHK struct_aqyhk;
        private static int id;
        private DataTable dt_Detail;

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
            id = Convert.ToInt32(Request.Params["id"].ToString());

            if (!IsPostBack)
            {
                zgzrrxmHiddenField.Value = "0";
                zgdbzrrxmHiddenField.Value = "0";
                zgyzrxmHiddenField.Value = "0";
                Bind();
                bind_Main();
            }
        }


        private void bind_Main()
        {
            dt_Detail = aqyhk.Select_AQYHK_Detail(id);
            dt_Detail.Columns.Add("zgzrrxm");
            dt_Detail.Columns.Add("zgdbzrrxm");
            dt_Detail.Columns.Add("zgyzrxm");

            foreach (DataRow dr in dt_Detail.Rows)
            {
                string[] Array_zgzzr = dr["zgzrr"].ToString().Split(',');
                string[] Array_zgdbzrr = dr["zgdbzrr"].ToString().Split(',');
                string[] Array_zgyzr = dr["zgyzr"].ToString().Split(',');
                foreach (string zgzzrxm_bh in Array_zgzzr)
                {
                    dr["zgzrrxm"] = aqyhk.Select_YGXMbyBH(zgzzrxm_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string zgdbzrrxm_bh in Array_zgdbzrr)
                {
                    dr["zgdbzrrxm"] = aqyhk.Select_YGXMbyBH(zgdbzrrxm_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string zgyzrxm_bh in Array_zgyzr)
                {
                    dr["zgyzrxm"] = aqyhk.Select_YGXMbyBH(zgyzrxm_bh.ToString()).Rows[0][0].ToString();
                }

                ddlt_tbdw.Text = dt_Detail.Rows[0]["tbdw"].ToString();
                tbx_yhfxsj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["yhfxsj"]).ToString("yyyy-MM-dd");
                ddlt_ly.Text = dt_Detail.Rows[0]["ly"].ToString();
                tbx_yhms.Text = dt_Detail.Rows[0]["yhms"].ToString();
                tbx_knzcwh.Text = dt_Detail.Rows[0]["knzcwh"].ToString();
                ddlt_yhdj.Text = dt_Detail.Rows[0]["yhdj"].ToString();
                tbx_pgfjpz.Text = dt_Detail.Rows[0]["pgfjpz"].ToString();
                tbx_zgcs.Text = dt_Detail.Rows[0]["zgcs"].ToString();
                tbx_yjtrfy.Text = dt_Detail.Rows[0]["yjtrfy"].ToString();
                tbx_zgwcsx.Text = Convert.ToDateTime(dt_Detail.Rows[0]["zgwcsx"]).ToString("yyyy-MM-dd");
                tbx_wcjdms.Text = dt_Detail.Rows[0]["wcjdms"].ToString();
                ddlt_zgzrdw.Text = dt_Detail.Rows[0]["zgzrdw"].ToString();
                tbx_zgzrrxm.Text = dt_Detail.Rows[0]["zgzrrxm"].ToString();
                tbx_zgdbzrrxm.Text = dt_Detail.Rows[0]["zgdbzrrxm"].ToString();
                tbx_zgfapz.Text = dt_Detail.Rows[0]["zgfapz"].ToString();
                tbx_zgyzjg.Text = dt_Detail.Rows[0]["zgyzjg"].ToString();
                tbx_zgyzrxm.Text = dt_Detail.Rows[0]["zgyzrxm"].ToString();
                tbx_zggbsj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["zggbsj"]).ToString("yyyy-MM-dd");
                tbx_zggbbz.Text = dt_Detail.Rows[0]["zggbbz"].ToString();
                ddlt_zggbpz.Text = dt_Detail.Rows[0]["zggbpz"].ToString();
                tbx_xgtzbcqk.Text = dt_Detail.Rows[0]["xgtzbcqk"].ToString();

                ddlt_csr.SelectedValue = dt_Detail.Rows[0]["csr"].ToString();//初审人
                ddlt_zsr.SelectedValue = dt_Detail.Rows[0]["zsr"].ToString();//终审人
                ddlt_sjszbm.SelectedValue = dt_Detail.Rows[0]["bmdm"].ToString();//数据所在部门

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
                if (dt_bmdm.Rows[i]["bm"].ToString() == "01" && SysData.HasThisQX("200303", _us.userID, "01") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (i == dt_bmdm.Rows.Count) { break; }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "02" && SysData.HasThisQX("200303", _us.userID, "02") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "03" && SysData.HasThisQX("200303", _us.userID, "03") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "04" && SysData.HasThisQX("200303", _us.userID, "04") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }

                if (dt_bmdm.Rows[i]["bm"].ToString() == "05" && SysData.HasThisQX("200303", _us.userID, "05") == false)
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
            int check_rz = 0;
            string yhfxsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string zggbsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string zgwcsx = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string ly = ddlt_ly.SelectedValue.ToString().Trim();
            string tbdw = ddlt_tbdw.SelectedValue.ToString().Trim();
            string yhdj = ddlt_yhdj.SelectedValue.ToString().Trim();
            string zgzrdw = ddlt_zgzrdw.SelectedValue.ToString().Trim();
            string zggbpz = ddlt_zggbpz.SelectedValue.ToString().Trim();
            string zgzrr = tbx_zgzrrxm.Text.ToString().Trim();
            #endregion
            #region 判断时间是否为空以及员工选择框是否有操作改动
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
            dt_Detail = aqyhk.Select_AQYHK_Detail(id);
            if (Convert.ToInt32(zgzrrxmHiddenField.Value) == 0)
            {
                struct_aqyhk.p_zgzrr = dt_Detail.Rows[0]["zgzrr"].ToString(); // 整改责任人
            }
            else
            {
                struct_aqyhk.p_zgzrr = zgzrr.Substring(0, zgzrr.Length); // 整改责任人
            }
            if (Convert.ToInt32(zgdbzrrxmHiddenField.Value) == 0)
            {
                struct_aqyhk.p_zgdbzrr = dt_Detail.Rows[0]["zgdbzrr"].ToString();  //整改督办责任人
            }
            else
            {
                struct_aqyhk.p_zgdbzrr = zgdbzrr.Substring(0, zgdbzrr.Length - 1); // 整改督办责任人
            }
            if (Convert.ToInt32(zgyzrxmHiddenField.Value) == 0)
            {
                struct_aqyhk.p_zgyzr = dt_Detail.Rows[0]["zgyzr"].ToString();   // 整改责任人
            }
            else
            {
                struct_aqyhk.p_zgyzr = zgyzr.Substring(0, zgyzr.Length); // 整改责任人
            }
            #endregion
            #region 保存
            struct_aqyhk.p_id = Convert.ToString(id); 
            struct_aqyhk.p_ygbh = _us.userLoginName;//填报人
            struct_aqyhk.p_tbrq = DateTime.Parse(DateTime.Now.ToString());//填报日期
            struct_aqyhk.p_tbdw = tbdw;//填报单位
            struct_aqyhk.p_yhfxsj = DateTime.Parse(tbx_yhfxsj.Text.ToString().Trim());//隐患发现时间
            struct_aqyhk.p_ly = ly;//来源
            struct_aqyhk.p_yhms = tbx_yhms.Text.ToString().Trim(); //隐患描述
            struct_aqyhk.p_knzcwh = tbx_knzcwh.Text.ToString().Trim(); //可能造成的危害
            struct_aqyhk.p_yhdj = yhdj; // 隐患等级
            struct_aqyhk.p_pgfjpz = tbx_pgfjpz.Text.ToString().Trim(); // 评估分级批准
            struct_aqyhk.p_zgcs = tbx_zgcs.Text.ToString().Trim(); // 整改措施及临时控制措施
            struct_aqyhk.p_yjtrfy = tbx_yjtrfy.Text.ToString().Trim(); // 预计投入费用
            struct_aqyhk.p_zgwcsx = DateTime.Parse(tbx_zgwcsx.Text.ToString().Trim()); // 整改完成时限
            struct_aqyhk.p_wcjdms = tbx_wcjdms.Text.ToString().Trim(); // 完成进度描述
            struct_aqyhk.p_zgzrdw = zgzrdw; // 整改责任单位
            struct_aqyhk.p_zgfapz = tbx_zgfapz.Text.ToString().Trim(); // 整改方案批准
            struct_aqyhk.p_zgyzjg = tbx_zgyzjg.Text.ToString().Trim();// 整改验证结果
            struct_aqyhk.p_zggbsj = DateTime.Parse(tbx_zggbsj.Text.ToString().Trim());// 整改关闭时间
            struct_aqyhk.p_zggbbz = tbx_zggbbz.Text.ToString().Trim();//整改关闭标准
            struct_aqyhk.p_zggbpz = zggbpz;//整改关闭批准
            struct_aqyhk.p_xgtzbcqk = tbx_xgtzbcqk.Text.ToString().Trim();//相关台账保存情况

            struct_aqyhk.p_lrr = _us.userLoginName;//录入人
            struct_aqyhk.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_aqyhk.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_aqyhk.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门


            struct_aqyhk.p_czfs = "02";
            #region  操作信息判断
            struct_aqyhk.p_czxx = "位置：三库建设->安全隐患库->编辑    序号：[" + struct_aqyhk.p_id + "]  描述：";
            if (struct_aqyhk.p_ygbh != dt_Detail.Rows[0]["ygbh"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "填报人：【" + dt_Detail.Rows[0]["ygbh"].ToString() + "】->【" + struct_aqyhk.p_ygbh + "】";
                check_rz = 1;
            }
            if (Convert.ToString(struct_aqyhk.p_tbrq) != dt_Detail.Rows[0]["tbrq"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "填报日期：【" + dt_Detail.Rows[0]["tbrq"].ToString() + "】->【" + struct_aqyhk.p_tbrq + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_tbdw != dt_Detail.Rows[0]["tbdw"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "填报单位：【" + dt_Detail.Rows[0]["tbdw"].ToString() + "】->【" + struct_aqyhk.p_tbdw + "】";
                check_rz = 1;
            }

            if (Convert.ToString(struct_aqyhk.p_yhfxsj) != dt_Detail.Rows[0]["yhfxsj"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "隐患发现时间：【" + dt_Detail.Rows[0]["yhfxsj"].ToString() + "】->【" + struct_aqyhk.p_yhfxsj + "】";
                check_rz = 1;
            }

            if (struct_aqyhk.p_ly != dt_Detail.Rows[0]["ly"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "来源：【" + dt_Detail.Rows[0]["ly"].ToString() + "】->【" + struct_aqyhk.p_ly + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_yhms != dt_Detail.Rows[0]["yhms"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "隐患描述：【" + dt_Detail.Rows[0]["yhms"].ToString() + "】->【" + struct_aqyhk.p_yhms + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_knzcwh != dt_Detail.Rows[0]["knzcwh"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "可能造成的危害：【" + dt_Detail.Rows[0]["knzcwh"].ToString() + "】->【" + struct_aqyhk.p_knzcwh + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_yhdj != dt_Detail.Rows[0]["yhdj"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "隐患等级：【" + dt_Detail.Rows[0]["yhdj"].ToString() + "】->【" + struct_aqyhk.p_yhdj + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_pgfjpz != dt_Detail.Rows[0]["pgfjpz"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "评估分级批准：【" + dt_Detail.Rows[0]["pgfjpz"].ToString() + "】->【" + struct_aqyhk.p_pgfjpz + "】";
                check_rz = 1;
            }

            if (struct_aqyhk.p_zgcs != dt_Detail.Rows[0]["zgcs"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改措施及临时控制措施：【" + dt_Detail.Rows[0]["zgcs"].ToString() + "】->【" + struct_aqyhk.p_zgcs + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_yjtrfy != dt_Detail.Rows[0]["yjtrfy"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "预计投入费用：【" + dt_Detail.Rows[0]["yjtrfy"].ToString() + "】->【" + struct_aqyhk.p_yjtrfy + "】";
                check_rz = 1;
            }
            if (Convert.ToString(struct_aqyhk.p_zgwcsx) != dt_Detail.Rows[0]["zgwcsx"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改完成时限：【" + dt_Detail.Rows[0]["zgwcsx"].ToString() + "】->【" + struct_aqyhk.p_zgwcsx + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_wcjdms != dt_Detail.Rows[0]["wcjdms"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "完成进度描述：【" + dt_Detail.Rows[0]["wcjdms"].ToString() + "】->【" + struct_aqyhk.p_wcjdms + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_zgzrdw != dt_Detail.Rows[0]["zgzrdw"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改责任单位：【" + dt_Detail.Rows[0]["zgzrdw"].ToString() + "】->【" + struct_aqyhk.p_zgzrdw + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_zgfapz != dt_Detail.Rows[0]["zgfapz"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改方案批准：【" + dt_Detail.Rows[0]["zgfapz"].ToString() + "】->【" + struct_aqyhk.p_zgfapz + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_zgyzjg != dt_Detail.Rows[0]["zgyzjg"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改验证结果：【" + dt_Detail.Rows[0]["zgyzjg"].ToString() + "】->【" + struct_aqyhk.p_zgyzjg + "】";
                check_rz = 1;
            }
            if (Convert.ToString(struct_aqyhk.p_zggbsj) != dt_Detail.Rows[0]["zggbsj"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改关闭时间：【" + dt_Detail.Rows[0]["zggbsj"].ToString() + "】->【" + struct_aqyhk.p_zggbsj + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_zggbbz != dt_Detail.Rows[0]["zggbbz"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改关闭标准：【" + dt_Detail.Rows[0]["zggbbz"].ToString() + "】->【" + struct_aqyhk.p_zggbbz + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_zggbpz != dt_Detail.Rows[0]["zggbpz"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "整改关闭批准：【" + dt_Detail.Rows[0]["zggbpz"].ToString() + "】->【" + struct_aqyhk.p_zggbpz + "】";
                check_rz = 1;
            }
            if (struct_aqyhk.p_xgtzbcqk != dt_Detail.Rows[0]["xgtzbcqk"].ToString())
            {
                //已修改
                struct_aqyhk.p_czxx += "相关台账保存情况：【" + dt_Detail.Rows[0]["xgtzbcqk"].ToString() + "】->【" + struct_aqyhk.p_xgtzbcqk + "】";
                check_rz = 1;
            }
            if (check_rz == 0)
            {
                struct_aqyhk.p_czxx += "未修改";

            }
            else
            {
                string sjbs = Request.Params["sjbs"].ToString();

                if (sjbs.Equals("0") || sjbs.Equals("2"))
                {
                    aqyhk.Update_AQYHK(struct_aqyhk);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("SKJS_AQYHK.aspx?ygbh=" + _us.userLoginName);

                }
                else if (sjbs.Equals("1") || sjbs.Equals("3"))
                {
                    //生成该数据的副本,并返回新的备份id
                    id = Convert.ToInt32(Request.Params["id"].ToString());
                    int id_bf = aqyhk.AQYHK_SJBF(Convert.ToInt32(id));
                    struct_aqyhk.p_id = Convert.ToString(id_bf);
                    aqyhk.Update_AQYHK(struct_aqyhk);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("SKJS_AQYHK.aspx?ygbh=" + _us.userLoginName);
                }
                else
                {
                    return;
                }
            }
            #endregion

            #endregion
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SKJS/SKJS_AQYHK.aspx", true);
        }
    }
}