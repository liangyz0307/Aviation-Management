using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CUST.Tools;
using CUST.Sys;
using CUST.MKG;
using System.IO;
using System.Net;
using Sys;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;




namespace CUST.WKG
{
    public partial class DHSB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private DHSB dhsb;
        private Utils utils;
        private Struct_DHSB struct_dhsb;
        private string date_update;
        public string SaveFileName_wxd;
        public string SaveFileName_mcjf;
        public string SaveFileName_plhh;
        public string SaveFileName_sbxk;
        public string SaveFileName_tzpf;
        public string SaveFileName_bhq;
        public string FileName_wxd;
        public string FileName_mcjf;
        public string FileName_plhh;
        public string FileName_sbxk;
        public string FileName_tzpf;
        public string FileName_bhq;
        public string FirstGetFilePath;
        public string FilePath;
        public string fpath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dhsb = new DHSB(_usState);
            utils = new Utils();
            if (!IsPostBack)
            {
                bind_drop();

                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
                tbx_jfdqrq.Attributes.Add("readonly", "readonly");
                tbx_tckfsj.Attributes.Add("readonly", "readonly");
                tbx_tcjfsj.Attributes.Add("readonly", "readonly");
                tbx_mcfxjyrq.Attributes.Add("readonly", "readonly");
                string sjjd = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo);
                int lss= Convert.ToInt32(dhsb.Select_DHSB_MaxNumber(sjjd));//临时数
                if (lss>= 99999)
                {
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"数据超出，请联系管理员整理数据！\")</script>");
                   Response.Redirect("../SheBei/DHSB_GL.aspx");
                }
                tbx_sbbh.Text= DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo) + "01" + Convert.ToString(lss + 1).PadLeft(5, '0');
            }
        }
        protected void ddlt_sblx_change(object sender, EventArgs e)
        {
            string sblx;
            ddlt_jc.SelectedValue = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
            if(ddlt_jc.SelectedValue =="-1")
            { sblx = " "; }
            else
            {
                sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
            }
            if (sblx.Equals("0201"))
            {
                wxdhsb.Attributes.Add("style", "display:ture");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0202"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:ture");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0203"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:ture");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0204"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:ture");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0205"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:ture");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0206"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:ture");
                zdxb.Attributes.Add("style", "display:none");
            }
            else if (sblx.Equals("0207"))
            {
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:ture");
            }
        }
        protected void ddlt_jc_change(object sender, EventArgs e)
        {
            if (ddlt_jc.SelectedValue != "-1")
            {
                DataTable dt = SysData.TZLX_ZH(ddlt_jc.SelectedValue,"02");
                //台站名称种类 台站名称
                ddlt_tzmczl.DataTextField = "mc";
                ddlt_tzmczl.DataValueField = "bm";
                ddlt_tzmczl.DataSource = dt.Copy();
                ddlt_tzmczl.DataBind();
                ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                if (dt.Rows.Count == 0)
                {
                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "该机场下无台站，请在台站管理添加！" + "</span>";
                }
                else if (ddlt_jc.SelectedValue == "-1")
                {
                    //台站名称种类 台站名称
                    ddlt_tzmczl.DataTextField = "mc";
                    ddlt_tzmczl.DataValueField = "bm";
                    ddlt_tzmczl.DataSource = SysData.TZLX_ZH("02").Copy();
                    ddlt_tzmczl.DataBind();
                    ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
                }
                else
                {
                    lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
                }
            }
            else
            {
                DataTable dt = SysData.TZLX_ZH("02");
                //台站名称种类 台站名称
                ddlt_tzmczl.DataTextField = "mc";
                ddlt_tzmczl.DataValueField = "bm";
                ddlt_tzmczl.DataSource = dt.Copy();
                ddlt_tzmczl.DataBind();
                ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
            }
        }

        private void bind_drop()
        {

            #region 公共字段

            ////设备类型
            //ddlt_sblx.DataTextField = "mc";
            //ddlt_sblx.DataValueField = "bm";
            //ddlt_sblx.DataSource = SysData.SBLX("02").Copy();
            //ddlt_sblx.DataBind();
            //ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));

            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));


            //原所属机场
            ddlt_yssjc.DataTextField = "mc";
            ddlt_yssjc.DataValueField = "bm";
            ddlt_yssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_yssjc.DataBind();
            ddlt_yssjc.Items.Insert(0, new ListItem("全部", "-1"));

            //频率单位
            ddlt_pldw.DataTextField = "mc";
            ddlt_pldw.DataValueField = "bm";
            ddlt_pldw.DataSource = SysData.PLDW().Copy();
            ddlt_pldw.DataBind();
            ddlt_pldw.Items.Insert(0, new ListItem("全部", "-1"));

            //投产是否限用
            ddlt_tcxy.DataTextField = "mc";
            ddlt_tcxy.DataValueField = "bm";
            ddlt_tcxy.DataSource = SysData.TCSFXY().Copy();
            ddlt_tcxy.DataBind();
            ddlt_tcxy.Items.Insert(0, new ListItem("全部", "-1"));

            //台站名称种类 台站名称
            ddlt_tzmczl.DataTextField = "mc";
            ddlt_tzmczl.DataValueField = "bm";
            ddlt_tzmczl.DataSource = SysData.TZLX_ZH("02").Copy();
            ddlt_tzmczl.DataBind();
            ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));


            //末次飞行校验结果
            ddlt_mcfxjyjg.DataTextField = "mc";
            ddlt_mcfxjyjg.DataValueField = "bm";
            ddlt_mcfxjyjg.DataSource = SysData.MCFXJYJG().Copy();
            ddlt_mcfxjyjg.DataBind();
            ddlt_mcfxjyjg.Items.Insert(0, new ListItem("全部", "-1"));

            //覆盖范围 
            ddlt_fgfwdw.DataTextField = "mc";
            ddlt_fgfwdw.DataValueField = "bm";
            ddlt_fgfwdw.DataSource = SysData.FGFWDW().Copy();
            ddlt_fgfwdw.DataBind();
            ddlt_fgfwdw.Items.Insert(0, new ListItem("全部", "-1"));

            //输出功率单位 
            ddlt_scgldw.DataTextField = "mc";
            ddlt_scgldw.DataValueField = "bm";
            ddlt_scgldw.DataSource = SysData.SCGLDW().Copy();
            ddlt_scgldw.DataBind();
            ddlt_scgldw.Items.Insert(0, new ListItem("全部", "-1"));

            //设备状态
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("全部", "-1"));

            //现所属机场
            ddlt_xssjc.DataTextField = "mc";
            ddlt_xssjc.DataValueField = "bm";
            ddlt_xssjc.DataSource = SysData.ZXDM().Copy();
            ddlt_xssjc.DataBind();
            ddlt_xssjc.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            # region 航向设备(仪表着陆系统LOC)
            // 类别
            ddlt_hxsblb.DataTextField = "mc";
            ddlt_hxsblb.DataValueField = "bm";
            ddlt_hxsblb.DataSource = SysData.HXSBLB().Copy();
            ddlt_hxsblb.DataBind();
            ddlt_hxsblb.Items.Insert(0, new ListItem("全部", "-1"));

            //天线阵类型
            ddlt_hxsbtxzlx.DataTextField = "mc";
            ddlt_hxsbtxzlx.DataValueField = "bm";
            ddlt_hxsbtxzlx.DataSource = SysData.HXSBTXZLX().Copy();
            ddlt_hxsbtxzlx.DataBind();
            ddlt_hxsbtxzlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            # region 下滑设备（仪表着陆系统GP）
            //天线阵类型
            ddlt_xhtxzlx.DataTextField = "mc";
            ddlt_xhtxzlx.DataValueField = "bm";
            ddlt_xhtxzlx.DataSource = SysData.XHSBTXZLX().Copy();
            ddlt_xhtxzlx.DataBind();
            ddlt_xhtxzlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 测距仪(DME)
            //配套设备
            ddlt_cjyptsb.DataTextField = "mc";
            ddlt_cjyptsb.DataValueField = "bm";
            ddlt_cjyptsb.DataSource = SysData.CJYPYSB().Copy();
            ddlt_cjyptsb.DataBind();
            ddlt_cjyptsb.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 全向信标（VO2） 
            //地网类型
            ddlt_qxxbdwlx.DataTextField = "mc";
            ddlt_qxxbdwlx.DataValueField = "bm";
            ddlt_qxxbdwlx.DataSource = SysData.DWLX().Copy();
            ddlt_qxxbdwlx.DataBind();
            ddlt_qxxbdwlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 无方向信标（NDB）
            //地网类型
            ddlt_wfxxbdwlx.DataTextField = "mc";
            ddlt_wfxxbdwlx.DataValueField = "bm";
            ddlt_wfxxbdwlx.DataSource = SysData.DWLX().Copy();
            ddlt_wfxxbdwlx.DataBind();
            ddlt_wfxxbdwlx.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            #region 指点信标
            //类型选择
            ddlt_zdxblxxz.DataTextField = "mc";
            ddlt_zdxblxxz.DataValueField = "bm";
            ddlt_zdxblxxz.DataSource = SysData.ZDXBLXXZ().Copy();
            ddlt_zdxblxxz.DataBind();
            ddlt_zdxblxxz.Items.Insert(0, new ListItem("全部", "-1"));
            #endregion

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140102");

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

            ddlt_sjszbm.DataSource = SysData.BM("140102", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
          }        
        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_dhsb.p_scwjsjc = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo); ;
            //判断是否有该路径
            string path = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + struct_dhsb.p_scwjsjc + "/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            #region 校验
            int flag = 0;
            #region 公共字段
            string sj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";

            //设备编号
            if (tbx_sbbh.Text == "")
            {
                lbl_sbbh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            //设备型号
            if (tbx_sbxh.Text == "")
            {
                lbl_sbxh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            //机场
            if (ddlt_jc.SelectedValue == "-1")
            {
                lbl_jc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //台站名称种类
            if (ddlt_tzmczl.SelectedValue == "-1")
            {
                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //设备类型
            //if (ddlt_sblx.SelectedValue == "-1")
            //{
            //    lbl_sblx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{

            //    lbl_sblx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //频率
            if (tbx_pl.Text == "" || ddlt_pldw.SelectedValue == "-1")
            {
                lbl_pl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_pl.Text, @"^[0-9]*$"))
            {
                lbl_pl.Text = "<span style=\"color:#ff0000\">" + "只能输入数字" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_pl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //呼号
            if (tbx_hh.Text == "")
            {
                lbl_hh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_hh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //天线中心地面高程
            if (tbx_txzxdmgc.Text == "")
            {
                lbl_txzxdmgc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_txzxdmgc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //天线
            if (tbx_tx.Text == "")
            {
                lbl_tx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_tx.Text, @"^[0-9]*$"))
            {
                lbl_tx.Text = "<span style=\"color:#ff0000\">" + "只能输入数字" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_tx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //校飞周期
            if (tbx_jfzq.Text == "")
            {
                lbl_jfzq.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jfzq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //校飞到期日期 
            if (tbx_jfdqrq.Text == "")
            {
                lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_jfdqrq.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_jfdqrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //投产开放时间
            if (tbx_tckfsj.Text == "")
            {
                lbl_tckfsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_tckfsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tckfsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //投产校飞时间
            if (tbx_tcjfsj.Text == "")
            {
                lbl_tcjfsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_tcjfsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_tcjfsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //投产是否限用
            if (ddlt_tcxy.SelectedValue == "-1")
            {
                lbl_tcxy.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tcxy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //末次飞行校验日期
            if (tbx_mcfxjyrq.Text == "")
            {
                lbl_mcfxjyrq.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_jfdqrq.Text.ToString(), sj))
                {
                    lbl_mcfxjyrq.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_mcfxjyrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //末次飞行校验结果
            if (ddlt_mcfxjyjg.SelectedValue == "-1")
            {
                lbl_mcfxjyjg.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_mcfxjyjg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //原所属机场
            if (ddlt_yssjc.SelectedValue == "-1")
            {
                lbl_yssjc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_yssjc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（北京54）精度
            if (tbx_ddzbbjjd.Text == "")
            {
                lbl_ddzbbjjd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbbjjd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（北京54）纬度
            if (tbx_ddzbbjwd.Text == "")
            {
                lbl_ddzbbjwd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbbjwd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（wgs84）经度
            if (tbx_ddzbwgsjd.Text == "")
            {
                lbl_ddzbwgsjd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbwgsjd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //大地坐标（wgs84）纬度
            if (tbx_ddzbwgswd.Text == "")
            {
                lbl_ddzbwgswd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_ddzbwgswd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备厂家
            if (tbx_sbcj.Text == "")
            {
                lbl_sbcj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbcj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //输出功率
            if (tbx_scgl.Text == "" || ddlt_scgldw.SelectedValue == "-1")
            {
                lbl_scgl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_scgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备出厂编号
            if (tbx_sbccbh.Text == "")
            {
                lbl_sbccbh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbccbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //覆盖范围
            if (tbx_fgfw.Text == "" || ddlt_fgfwdw.SelectedValue == "-1")
            {
                lbl_fgfw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_fgfw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备状态
            if (ddlt_sbzt.SelectedValue == "-1")
            {
                lbl_sbzt.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbzt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电
            if (tbx_jlgd.Text == "")
            {
                lbl_jlgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jlgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电大小
            if (tbx_jlgddx.Text == "")
            {
                lbl_jlgddx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jlgddx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //交流供电数量
            if (tbx_jlgdsl.Text == "")
            {
                lbl_jlgdsl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_jlgdsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电
            if (tbx_zlgd.Text == "")
            {
                lbl_zlgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_zlgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电数量
            if (tbx_zlgdsl.Text == "")
            {
                lbl_zlgdsl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_zlgdsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电大小
            if (tbx_zlgddx.Text == "")
            {
                lbl_zlgddx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_zlgddx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //直流供电大小
            if (tbx_sbcsqk.Text == "")
            {
                lbl_sbcsqk.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbcsqk.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备方蕾配置
            if (tbx_sbflpz.Text == "")
            {
                lbl_sbflpz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {

                lbl_sbflpz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            #endregion

            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0202")
            {
                #region 航向设备
                //类别
                if (ddlt_hxsblb.SelectedValue == "-1")
                {
                    lbl_hxsblb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsblb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //跑道号
                if (tbx_hxsbpdh.Text == "")
                {
                    lbl_hxsblb.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsblb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                //天线阵类型
                if (ddlt_hxsbtxzlx.SelectedValue == "-1")
                {
                    lbl_hxsbtxzlx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbtxzlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵子书
                if (tbx_hxsbtxzzs.Text == "")
                {
                    lbl_hxsbtxzzs.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbtxzzs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵距跑道末端距离
                if (tbx_hxsbjpdmdjl.Text == "")
                {
                    lbl_hxsbjpdmdjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbjpdmdjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵距跑道入口距离
                if (tbx_hxsbjpdrkjl.Text == "")
                {
                    lbl_hxsbjpdrkjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbjpdrkjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵距跑道中心垂直距离
                if (tbx_hxsbpdzxczjl.Text == "")
                {
                    lbl_hxsbpdzxczjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_hxsbpdzxczjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion 航向设备
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0203")
            {
                #region 下滑设备

                //设计下滑角
                if (tbx_sjxhj.Text == "")
                {
                    lbl_sjxhj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_sjxhj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //设计入口高度
                if (tbx_sjrkgd.Text == "")
                {
                    lbl_sjrkgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_sjrkgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线阵类型
                if (ddlt_xhtxzlx.SelectedValue == "-1")
                {
                    lbl_xhtxzlx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_xhtxzlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //投产下天线高度
                if (tbx_tcxtxgd.Text == "")
                {
                    lbl_tcxtxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_tcxtxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //投产上天线高度
                if (tbx_tcstxgd.Text == "")
                {
                    lbl_tcstxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_tcstxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //目前下天线高度
                if (tbx_mqxtxgd.Text == "")
                {
                    lbl_mqxtxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_mqxtxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //目前上天线高度
                if (tbx_mqstxgd.Text == "")
                {
                    lbl_mqstxgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_mqstxgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //天线塔高度
                if (tbx_txtgd.Text == "")
                {
                    lbl_txtgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_txtgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //距跑道入口内撤距离
                if (tbx_pdrkncjl.Text == "")
                {
                    lbl_pdrkncjl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_pdrkncjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //距跑道中线垂距
                if (tbx_pdzcxcj.Text == "")
                {
                    lbl_pdzcxcj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_pdzcxcj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //位于跑道中心线
                if (tbx_wypdzxx.Text == "")
                {
                    lbl_wypdzxx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_wypdzxx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //盲降基准高RDH
                if (tbx_mjjzgrdh.Text == "")
                {
                    lbl_mjjzgrdh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_mjjzgrdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0204")
            {
                #region 测距仪（DME）

                //波道号
                if (tbx_bdh.Text == "")
                {
                    lbl_bdh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_bdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //配套设备
                if (ddlt_cjyptsb.SelectedValue == "-1")
                {
                    lbl_cjyptsb.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjyptsb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //接收频率
                if (tbx_cjyjspl.Text == "")
                {
                    lbl_cjyjspl.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjyjspl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //系统延迟
                if (tbx_cjyxtyc.Text == "")
                {
                    lbl_cjyxtyc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjyxtyc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //脉冲间隔
                if (tbx_cjymcjg.Text == "")
                {
                    lbl_cjymcjg.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_cjymcjg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0205")
            {
                #region 全向信标
                //磁偏差
                if (tbx_qxxbcpc.Text == "")
                {
                    lbl_qxxbcpc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbcpc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //地网高度
                if (tbx_qxxbdwgd.Text == "")
                {
                    lbl_qxxbdwgd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbdwgd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //监控器方位
                if (tbx_qxxbjkqfw.Text == "")
                {
                    lbl_qxxbjkqfw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbjkqfw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //地网直径
                if (tbx_qxxbdwzj.Text == "")
                {
                    lbl_qxxbdwzj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbdwzj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //地网类型
                if (ddlt_qxxbdwlx.SelectedValue == "-1")
                {
                    lbl_qxxbdwlx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_qxxbdwlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }
            if (ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4) == "0207")
            {
                #region 指点信标
                //跑道号
                if (tbx_zdxbpdh.Text == "")
                {
                    lbl_zdxbpdh.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zdxbpdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //端距
                if (tbx_zdxbdj.Text == "")
                {
                    lbl_zdxbdj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zdxbdj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //类型选择
                if (ddlt_cjyptsb.SelectedValue == "-1")
                {
                    ddlt_zdxblxxz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                    flag = 1;
                }
                else
                {

                    lbl_zdxblxxz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                #endregion
            }

            #region 权限相关
            //数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjssbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjssbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            #endregion

            #region 上传文件
            //无线电设备发射核准证件
            int flag1 = 0;
            if (FileUpload_wxd.FileName == "")
            {

                flag = 1;
                flag1 = 1;
            }
            lbl_wxdsbfshzzsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //末次校飞报告
            if (FileUpload_mcjf.FileName == "")
            {

                flag = 1;
                flag1 = 1;
            }
            lbl_mcjfbgsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //频率呼号文件
            if (FileUpload_plhh.FileName == "")
            {

                flag = 1;
                flag1 = 1;
            }
            lbl_pvhhwjsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //设备许可证
            if (FileUpload_sbxk.FileName == "")
            {

                flag = 1;
                flag1 = 1;
            }
            lbl_sbxkzsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //台址批复文件
            if (FileUpload_tzpf.FileName == "")
            {

                flag = 1;
                flag1 = 1;
            }
            lbl_tzpfwjsc.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            //保护区范围
            if (FileUpload_bhq.FileName == "")
            {

                flag = 1;
                flag1 = 1;
            }
            lbl_bhqfw.Text = "<span style=\"color:#ff0000\">" + "请上传文件" + "</span>";
            if (flag1 == 0)
            {
                string wjpd = FileUpload_wxd.FileName + "," + FileUpload_mcjf.FileName + "," + FileUpload_plhh.FileName + "," + FileUpload_sbxk.FileName + "," + FileUpload_tzpf.FileName + "," + FileUpload_bhq.FileName;
                string[] str = wjpd.Split(',');
                if (str.Distinct().Count() < 6)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"上传文件名不可重复，请重新上传！\")</script>");
                    flag = 1;
                }
            }
            #endregion

            if (flag == 1)
            { return;
            }
            #endregion


            #region 文件上传
            if (FileUpload_wxd.HasFile && FileUpload_mcjf.HasFile && FileUpload_plhh.HasFile && FileUpload_sbxk.HasFile && FileUpload_tzpf.HasFile && FileUpload_bhq.HasFile)
            {
                //对上传文件的大小进行检测，限定文件最大不超过10M
                if (FileUpload_wxd.PostedFile.ContentLength < 10240000 && FileUpload_mcjf.PostedFile.ContentLength < 10240000 && FileUpload_plhh.PostedFile.ContentLength < 10240000 && FileUpload_sbxk.PostedFile.ContentLength < 10240000 && FileUpload_tzpf.PostedFile.ContentLength < 10240000 && FileUpload_bhq.PostedFile.ContentLength < 10240000)
                {
                    struct_dhsb.p_sbbh = tbx_sbbh.Text.ToString();
                    struct_dhsb.p_sbxh = tbx_sbxh.Text.ToString();
                    struct_dhsb.p_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);
                    struct_dhsb.p_tzmczl_tzmc = ddlt_tzmczl.SelectedValue.ToString().Substring(0,2);
                    struct_dhsb.p_tzmczl_wz = ddlt_tzmczl.SelectedValue.ToString().Substring(2,2);
                    struct_dhsb.p_tzmczl_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4,4);
                    struct_dhsb.p_yssjc = ddlt_yssjc.SelectedValue.ToString();
                    struct_dhsb.p_pl = tbx_pl.Text.ToString();
                    struct_dhsb.p_pldw = ddlt_pldw.SelectedValue.ToString();
                    struct_dhsb.p_hh = tbx_hh.Text.ToString();
                    struct_dhsb.p_txzxdmgc = tbx_txzxdmgc.Text.ToString();
                    struct_dhsb.p_tx = tbx_tx.Text.ToString();
                    struct_dhsb.p_jfzq = tbx_jfzq.Text.ToString().Trim();
                    struct_dhsb.p_jfdqrq = tbx_jfdqrq.Text.ToString().Trim();
                    struct_dhsb.p_tckfsj = tbx_tckfsj.Text.ToString().Trim();
                    struct_dhsb.p_tcjfsj = tbx_tcjfsj.Text.ToString().Trim();
                    struct_dhsb.p_tcsfxy = ddlt_tcxy.SelectedValue.ToString();
                    struct_dhsb.p_tcsm = tbx_tcsm.Text.ToString();
                    struct_dhsb.p_mcfxjyrq = tbx_mcfxjyrq.Text.ToString();
                    struct_dhsb.p_mcfxjyjg = ddlt_mcfxjyjg.SelectedValue.ToString();
                    struct_dhsb.p_mcfxjysm = tbx_mcfxjyjgsm.Text.ToString();
                    struct_dhsb.p_ddzbbjjd = tbx_ddzbbjjd.Text.ToString().Trim();
                    struct_dhsb.p_ddzbbjwd = tbx_ddzbbjwd.Text.ToString().Trim();
                    struct_dhsb.p_ddzbwgsjd = tbx_ddzbwgsjd.Text.ToString().Trim();
                    struct_dhsb.p_ddzbwgswd = tbx_ddzbwgswd.Text.ToString().Trim();
                    struct_dhsb.p_sl = tbx_sl.Text.ToString().Trim();
                    struct_dhsb.p_sbcj = tbx_sbcj.Text.ToString();
                    struct_dhsb.p_scgl = tbx_scgl.Text.ToString();
                    struct_dhsb.p_scgldw = ddlt_scgldw.SelectedValue.ToString();
                    struct_dhsb.p_sbccbh = tbx_sbccbh.Text.ToString();
                    struct_dhsb.p_fgfw = tbx_fgfw.Text.ToString();
                    struct_dhsb.p_fgfwdw = ddlt_fgfwdw.Text.ToString();
                    struct_dhsb.p_sbzt = ddlt_sbzt.SelectedValue.ToString();
                    struct_dhsb.p_jpdzxjl = tbx_jpdzxjl.Text.ToString();
                    struct_dhsb.p_pdcd = tbx_pdcd.Text.ToString();
                    struct_dhsb.p_synx = tbx_synx.Text.ToString();
                    struct_dhsb.p_jlgd = tbx_jlgd.Text.ToString();
                    struct_dhsb.p_jlgddx = tbx_jlgddx.Text.ToString();
                    struct_dhsb.p_jlgdsl = tbx_jlgdsl.Text.ToString();
                    struct_dhsb.p_zlgd = tbx_zlgd.Text.ToString();
                    struct_dhsb.p_zlgddx = tbx_zlgddx.Text.ToString();
                    struct_dhsb.p_zlgdsl = tbx_zlgdsl.Text.ToString();
                    struct_dhsb.p_sbcsqk = tbx_sbcsqk.Text.ToString();
                    struct_dhsb.p_sbflpz = tbx_sbflpz.Text.ToString();
                    struct_dhsb.p_xssjc = ddlt_xssjc.SelectedValue.ToString();
                    struct_dhsb.p_dbsj = tbx_dbsj.Text.ToString();
                    struct_dhsb.p_sbbgr = tbx_sbbgr.Text.ToString();
                    //地面设备
                    struct_dhsb.p_dmsbtxlx = tbx_dmsbtxlx.Text.ToString();
                    //航向设备
                    struct_dhsb.p_hxsblb = ddlt_hxsblb.SelectedValue.ToString();
                    struct_dhsb.p_hxsbpdh = tbx_hxsbpdh.Text.ToString();
                    struct_dhsb.p_hxsbtxzxh = tbx_hxsbtxzxh.Text.ToString();
                    struct_dhsb.p_hxsbtxzlx = ddlt_hxsbtxzlx.SelectedValue.ToString();
                    struct_dhsb.p_hxsbtxzzs = tbx_hxsbtxzzs.Text.ToString();
                    struct_dhsb.p_hxsbjpdmdjl = tbx_hxsbjpdmdjl.Text.ToString();
                    struct_dhsb.p_hxsbjpdrkjl = tbx_hxsbjpdrkjl.Text.ToString();
                    struct_dhsb.p_hxsbzxczjl = tbx_hxsbpdzxczjl.Text.ToString();
                    //下滑设备
                    struct_dhsb.p_xhsbsjxhj = tbx_sjxhj.Text.ToString();
                    struct_dhsb.p_xhsbsjrkgd = tbx_sjrkgd.Text.ToString();
                    struct_dhsb.p_xhsbtxzlx = ddlt_xhtxzlx.SelectedValue.ToString();
                    struct_dhsb.p_xhsbtxzxh = tbx_xhtxzxh.Text.ToString();
                    struct_dhsb.p_xhsbtcxtxgd = tbx_tcxtxgd.Text.ToString();
                    struct_dhsb.p_xhsbmqxtxgd = tbx_mqxtxgd.Text.ToString();
                    struct_dhsb.p_xhsbtcstxgd = tbx_tcstxgd.Text.ToString();
                    struct_dhsb.p_xhsbmqstxgd = tbx_mqstxgd.Text.ToString();
                    struct_dhsb.p_xhsbtxtgd = tbx_txtgd.Text.ToString();
                    struct_dhsb.p_xhsbjpdrkncjl = tbx_pdrkncjl.Text.ToString();
                    struct_dhsb.p_xhsbjpdzxcj = tbx_pdzcxcj.Text.ToString();
                    struct_dhsb.p_xhsbwypdzxx = tbx_wypdzxx.Text.ToString();
                    struct_dhsb.p_xhsbmjjzgrdh = tbx_mjjzgrdh.Text.ToString();
                    //测距仪
                    struct_dhsb.p_cjycpc = tbx_cjycpc.Text.ToString();
                    struct_dhsb.p_cjypdh = tbx_cjypdh.Text.ToString();
                    struct_dhsb.p_cjydj = tbx_cjydj.Text.ToString();
                    struct_dhsb.p_cjybdh = tbx_bdh.Text.ToString();
                    struct_dhsb.p_cjyptsb = ddlt_cjyptsb.SelectedValue.ToString();
                    struct_dhsb.p_cjyjspl = tbx_cjyjspl.Text.ToString();
                    struct_dhsb.p_cjyxtyc = tbx_cjyxtyc.Text.ToString();
                    struct_dhsb.p_cjymcjg = tbx_cjymcjg.Text.ToString();
                    //全向信标
                    struct_dhsb.p_qxxbcpc = tbx_qxxbcpc.Text.ToString();
                    struct_dhsb.p_qxxbdwgd = tbx_qxxbdwgd.Text.ToString();
                    struct_dhsb.p_qxxbjkqfw = tbx_qxxbjkqfw.Text.ToString();
                    struct_dhsb.p_qxxbdwzj = tbx_qxxbdwzj.Text.ToString();
                    struct_dhsb.p_qxxbdwlx = ddlt_qxxbdwlx.SelectedValue.ToString();//!LXLL
                    struct_dhsb.p_qxxbpdh = tbx_qxxbpdh.Text.ToString();
                    struct_dhsb.p_qxxbdj = tbx_qxxbdj.Text.ToString();
                    //无方向信标
                    struct_dhsb.p_wfxxbcpc = tbx_wfxxbcpc.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbdwgd = tbx_wfxxbdwgd.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbjkqfw = tbx_wfxxbjkqfw.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbdwzj = tbx_wfxxbdwzj.Text.ToString();//FFFXZZZJ
                    struct_dhsb.p_wfxxbdwlx = ddlt_wfxxbdwlx.SelectedValue.ToString();//FFFX
                    struct_dhsb.p_wfxxbpdh = tbx_wfxxbpdh.Text.ToString();//FFFX
                    struct_dhsb.p_wfxxbdj = tbx_wfxxbdj.Text.ToString();//FFFX
                    //指点信标
                    struct_dhsb.p_zdxbpdh = tbx_zdxbpdh.Text.ToString();
                    struct_dhsb.p_zdxbdj = tbx_zdxbdj.Text.ToString();
                    struct_dhsb.p_zdxblxxz = ddlt_zdxblxxz.SelectedValue.ToString();

                    System.DateTime now = System.DateTime.Now;
                    struct_dhsb.p_xtsj = now;

                    struct_dhsb.p_wxdlj = path;
                    struct_dhsb.p_mcjflj = path;
                    struct_dhsb.p_plhhlj = path;
                    struct_dhsb.p_sbxkzlj = path;
                    struct_dhsb.p_tzpflj = path;
                    struct_dhsb.p_bhqlj = path;
                    struct_dhsb.p_scip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
                    struct_dhsb.p_wxdsbfshzzj = FileUpload_wxd.FileName;
                    struct_dhsb.p_mcjfbg = FileUpload_mcjf.FileName;
                    struct_dhsb.p_plhhwj = FileUpload_plhh.FileName;
                    struct_dhsb.p_sbxkz = FileUpload_sbxk.FileName;
                    struct_dhsb.p_tzpfwj = FileUpload_tzpf.FileName;
                    struct_dhsb.p_bhqfw = FileUpload_bhq.FileName;
                    struct_dhsb.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                    struct_dhsb.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                    struct_dhsb.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                    struct_dhsb.p_lrr = _usState.userLoginName.ToString();//录入人
                    //struct_YGJL.p_sjbs = "0";
                    //如果是初审人录入数据，则状态默认初审通过，即待终审
                    if (struct_dhsb.p_lrr.Equals(struct_dhsb.p_csr))
                    {
                        struct_dhsb.p_sjbs = "0";
                        struct_dhsb.p_zt = "2";
                    }
                    //如果是终审人录入数据，则状态为审核通过
                    if (struct_dhsb.p_lrr.Equals(struct_dhsb.p_zsr))
                    {
                        struct_dhsb.p_sjbs = "1";
                        struct_dhsb.p_zt = "3";
                    }
                    if (!struct_dhsb.p_lrr.Equals(struct_dhsb.p_csr) && !struct_dhsb.p_lrr.Equals(struct_dhsb.p_zsr))
                    {
                        struct_dhsb.p_sjbs = "0";
                        struct_dhsb.p_zt = "0";
                    }
                    struct_dhsb.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳


                    string czxx = "位置：设备管理->导航设备管理->添加   设备编号：" + struct_dhsb.p_sbbh;
                    struct_dhsb.p_czfs = "01";
                    struct_dhsb.p_czxx = czxx;
                    //上传文件
                    FileUpload_wxd.PostedFile.SaveAs(path + FileUpload_wxd.FileName);
                    FileUpload_mcjf.PostedFile.SaveAs(path + FileUpload_mcjf.FileName);
                    FileUpload_plhh.PostedFile.SaveAs(path + FileUpload_plhh.FileName);
                    FileUpload_sbxk.PostedFile.SaveAs(path + FileUpload_sbxk.FileName);
                    FileUpload_tzpf.PostedFile.SaveAs(path + FileUpload_tzpf.FileName);
                    FileUpload_bhq.PostedFile.SaveAs(path + FileUpload_bhq.FileName);


                    //存入数据库
                    dhsb.Insert_DHSB(struct_dhsb);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");

                    Response.Redirect("../SheBei/DHSB_GL.aspx");
                }
            }

            #endregion

        }
        //重命名
        private string MakeFileName(string biaoshi, string exeFileString)
        {
            System.DateTime now = System.DateTime.Now;
            struct_dhsb.p_xtsj = now;
            date_update = now.ToString();
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            string yearString = year.ToString();
            string monthString = month < 10 ? ("0" + month) : month.ToString();
            string dayString = day < 10 ? ("0" + day) : day.ToString();
            string hourString = hour < 10 ? ("0" + hour) : hour.ToString();
            string minuteString = minute < 10 ? ("0" + minute) : minute.ToString();
            string secondString = second < 10 ? ("0" + second) : second.ToString();

            string fileName = yearString + monthString + dayString + hourString + minuteString + secondString + biaoshi + exeFileString;
            return fileName;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/DHSB_GL.aspx");
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int p_id = Convert.ToInt32(e.CommandArgument.ToString());
            DataTable dt = dhsb.Select_DHSB_Detail(p_id);
            string path = dt.Rows[0]["WXDSBFSHZZJ"].ToString();
            string filename = path.Substring(path.LastIndexOf("\\") + 1);
            if (e.CommandName == "download")
            {
                try
                {
                    if (File.Exists(path))
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                        Response.AddHeader("Content-Transfer-Encoding", "binary");
                        Response.ContentType = "application/octet-stream";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                        Response.WriteFile(fileInfo.FullName);
                        Response.Flush();
                        Response.End();
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"文件不存在！\")</script>");
                        return;
                    }
                }
                catch { }

            }
        }

   
    }
}