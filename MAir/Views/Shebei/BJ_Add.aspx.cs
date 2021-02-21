using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CUST.WKG
{
    public partial class BJ_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJ struct_bj;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}

            bj = new BJ(_usState);
            struct_bj = new Struct_BJ();
            if (!IsPostBack)
            {

                ddltBind();

            }
        }
        private void ddltBind()
        {

            //绑定   设备类型
            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX().Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("请选择", "-1"));

            //绑定   设备种类
            //DataTable dt_sbzl = new DataTable();
            ddlt_sbzl.DataTextField = "mc";
            ddlt_sbzl.DataValueField = "bm";
            ddlt_sbzl.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));


            //绑定   适用
            ddlt_sy.DataTextField = "mc";
            ddlt_sy.DataValueField = "bm";
            ddlt_sy.DataSource = SysData.BJSY().Copy();
            ddlt_sy.DataBind();
            ddlt_sy.Items.Insert(0, new ListItem("请选择", "-1"));


            //绑定设备类别
            ddlt_bjfl.DataTextField = "mc";
            ddlt_bjfl.DataValueField = "bm";
            ddlt_bjfl.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl.DataBind();
            ddlt_bjfl.Items.Insert(0, new ListItem("请选择", "-1"));


            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14",_usState.userID,"140502");

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
            //ddlt_sjszbm.DataSource = SysData.BM("140102", _usState.userID).Copy();

            ddlt_sjszbm.DataSource = SysData.BM("140502", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }


        protected string AutoSbbh()
        {
            //DH+BJ+2017+4位流水号，传类型


            string lx = ddlt_sblx.SelectedValue.ToString();
            if (lx.Substring(0,2) == "01")
            {
                lx = "DH";
            }
            if (lx.Substring(0,2) == "02")
            {
                lx = "TX";
            }
            if (lx.Substring(0, 2) == "03")
            {
                lx = "QX";
            }
            if (lx.Substring(0, 2) == "04")
            {
                lx = "JK";
            }
            //else if (lx == "3")
            //{
            //    lx = "QX";
            //}
            //else if (lx == "4")
            //{
            //    lx = "JS";
            //}
            //else
            ////if (lx == "5")
            //{
            //    lx = "YB";

            //}

            DataTable dt_maxSbbh = bj.Select_Max_BJBH(lx).Tables[0];

            string sbbh = dt_maxSbbh.Rows[0]["MBJBH"].ToString();
            int maxSbbh;
            if (sbbh == "")
            {
                maxSbbh = 0;
            }
            else
            {
                maxSbbh = Convert.ToInt32(sbbh.Substring(sbbh.Length - 4, 4));
            }
            string zdbh = Convert.ToString(maxSbbh + 1);
            zdbh = zdbh.PadLeft(4, '0');
            string bh = lx + "BJ" + DateTime.Now.Year + zdbh;
            return bh;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            #region 赋值
          

            int flag = 0;

            string sy = ddlt_sy.SelectedValue.ToString();
            string bjfl = ddlt_bjfl.SelectedValue.ToString();
            string bjmc = tbx_bjmc.Text.ToString().Trim();
            string sbxh = tbx_sbxh.Text.ToString().Trim();

            string bjzwmc = tbx_bjzwmc.Text.ToString();
            string nhzj = tbx_nhzj.Text.ToString();
            string nhzjmc = tbx_nhzjmc.Text.ToString();
            string ywmc = tbx_ywmc.Text.ToString();
            string yjsl = tbx_yjsl.Text.ToString();
            string bjsbh = tbx_bjsbh.Text.ToString();

            string xybj = tbx_xybj.Text.ToString();
            string cfwz = tbx_cfwz.Text.ToString();
            string bz = tbx_bz.Text.ToString();
            string sbzl = ddlt_sbzl.SelectedValue.ToString();
            #endregion

            #region label提示 +判断 tbx是否为空
            if (sbzl == "-1")
            {
                lbl_sbzl.Text = "<span style=\"color:#ff0000\">" + "错误：请选择设备种类" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (sy == "-1")
            {
                lbl_sy.Text = "<span style=\"color:#ff0000\">" + "错误：请选择备件适用情况" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (bjfl == "-1")
            {
                lbl_bjfl.Text = "<span style=\"color:#ff0000\">" + "错误：请选择备件分类" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjfl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(bjmc))
            {
                lbl_bjmc.Text = "<span style=\"color:#ff0000\">" + "错误：备件名称不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(sbxh))
            {
                lbl_sbxh.Text = "<span style=\"color:#ff0000\">" + "错误：设备型号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(bjzwmc))
            {
                lbl_bjzwmc.Text = "<span style=\"color:#ff0000\">" + "错误：板件中文名称不能为空" + "</span>";
                flag = 1;

            }
            else
            {
                lbl_bjzwmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //if (string.IsNullOrEmpty(nhzj))
            //{
            //    lbl_nhzj.Text = "<span style=\"color:#ff0000\">" + "错误：内含组件不能为空！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_nhzj.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
            //}

            //if (string.IsNullOrEmpty(nhzjmc))
            //{
            //    lbl_nhzjmc.Text = "<span style=\"color:#ff0000\">" + "错误：内含组件名称不能为空！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_nhzjmc.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";

            //}
            if (string.IsNullOrEmpty(ywmc))
            {
                lbl_ywmc.Text = "<span style=\"color:#ff0000\">" + "错误：不可为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(ywmc, @"^[A-Za-z0-9]+$"))
            {
                lbl_ywmc.Text = "<span style=\"color:#ff0000\">" + "请输入英文！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ywmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (!Regex.IsMatch(tbx_yjsl.Text, @"^[0-9]*$"))
            {
                lbl_yjsl.Text = "<span style=\"color:#ff0000\">" + "错误：请输入数字！" + "</span>";
                flag = 1;
            }
            if (string.IsNullOrEmpty(bjsbh))
            {
                lbl_bjsbh.Text = "<span style=\"color:#ff0000\">" + "错误：板件识别号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjsbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(xybj))
            {
                lbl_xybj.Text = "<span style=\"color:#ff0000\">" + "错误：现有备件数量不能为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_xybj.Text, @"^[0-9]*$"))
            {
                lbl_xybj.Text = "span style=\"color:#ff0000\">" + "错误：请输入数字" + "</span>";
            }
            else
            {
                lbl_bjsbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(cfwz))
            {
                lbl_cfwz.Text = "<span style=\"color:#ff0000\">" + "错误：存放位置不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_cfwz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //if (string.IsNullOrEmpty(bz))
            //{
            //    lbl_bz.Text = "<span style=\"color:#ff0000\">" + "错误：备注不能为空！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
            //}
           
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
            if (flag == 1)
                return;

            #endregion


            #region 保存
            try
            {
                //赋值
                string bjbh = AutoSbbh();
                struct_bj.p_sy = sy;
                struct_bj.p_bjfl = bjfl;
                struct_bj.p_bjbh = bjbh;
                struct_bj.p_bjmc = bjmc;
                struct_bj.p_sbxh = sbxh;
                struct_bj.p_bjzwmc = bjzwmc;
                struct_bj.p_nhzj = nhzj;
                struct_bj.p_nhzjmc = nhzjmc;
                struct_bj.p_ywmc = ywmc;
                struct_bj.p_yjsl = yjsl;
                struct_bj.p_bjsbh = bjsbh;
                struct_bj.p_xybjsl = xybj;
                struct_bj.p_cfwz = cfwz;
                struct_bj.p_bz = bz;
                struct_bj.p_zxdm = _usState.userSS;
                struct_bj.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                struct_bj.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                struct_bj.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                struct_bj.p_lrr = _usState.userLoginName.ToString();//录入人

                if (struct_bj.p_lrr.Equals(struct_bj.p_csr))
                {
                    struct_bj.p_sjbs = "0";
                    struct_bj.p_zt = "2";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_bj.p_zsr, "14", "1405", -1);
                }
                //如果是终审人录入数据，则状态为审核通过
                if (struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    struct_bj.p_sjbs = "1";
                    struct_bj.p_zt = "3";
                }
                if (!struct_bj.p_lrr.Equals(struct_bj.p_csr) && !struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    struct_bj.p_sjbs = "0";
                    struct_bj.p_zt = "0";
                }
                struct_bj.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
                //路径
                // struct_txsb.p_wxdsbfshzzj = toPath;
                struct_bj.p_czfs = "01";

                struct_bj.p_czxx = "位置：设备管理->备件管理->添加 备件编号：" + struct_bj.p_bjbh + " 备件名称：" + struct_bj.p_bjmc + " 备件分类：" + struct_bj.p_bjfl + " 备件适用：" +
                    struct_bj.p_sy + " 备件型号：" + struct_bj.p_sbxh + " 备件中文名称：" + struct_bj.p_bjzwmc + " 内含组件：" + struct_bj.p_nhzj + " 内含组件名称：" + struct_bj.p_nhzjmc +
                    " 英文名称：" + struct_bj.p_ywmc + " 原机数量：" + struct_bj.p_yjsl + " 板件识别号：" + struct_bj.p_bjsbh + " 现有备件数量：" +
                    struct_bj.p_xybjsl + " 存放位置：" + struct_bj.p_cfwz + " 备注：" + struct_bj.p_bz;
                bj.Insert_BJ(struct_bj);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));

                return;
            }

            ClearAfterAdd();
            #endregion
        }
        protected void ClearAfterAdd()
        {

            tbx_bjmc.Text = "";
            tbx_sbxh.Text = "";
            ddlt_bjfl.SelectedValue = "-1";
            tbx_bjzwmc.Text = "";
            tbx_nhzj.Text = "";
            tbx_nhzjmc.Text = "";
            tbx_ywmc.Text = "";
            tbx_yjsl.Text = "";
            tbx_bjsbh.Text = "";
            ddlt_sy.SelectedValue = "-1";
            tbx_xybj.Text = "";
            tbx_cfwz.Text = "";
            tbx_bz.Text = "";
            ddlt_sblx.SelectedValue = "-1";
            ddlt_sbzl.SelectedValue = "-1";

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/BJ_GL.aspx");
        }

        protected void tbx_xybj_TextChanged(object sender, EventArgs e)
        {

        }

        //根据设备类型找种类
        //protected void ddlt_sblx_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string sblx = ddlt_sblx.SelectedValue.ToString();
        //    if (sblx == "-1")
        //    {
        //        DataTable dt_sblx = new DataTable();
        //        ddlt_sbzl.DataSource = dt_sblx;
        //        ddlt_sbzl.DataBind();
        //        ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));
        //    }
        //    else
        //    {

        //        ddlt_sbzl.DataTextField = "mc";
        //        ddlt_sbzl.DataValueField = "bm";
        //        ddlt_sbzl.DataSource = SysData.SBZL(sblx).Copy();
        //        ddlt_sbzl.DataBind();
        //        ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));

        //    }
        //}
    }
}