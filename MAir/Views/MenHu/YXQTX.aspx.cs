using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Text;

namespace CUST.WKG
{
    public partial class YXQTX : System.Web.UI.Page
    {
        private UserState userState;
        private YH yh;
        private JS js;
        private HT ht;
        public int zs = 0;
        public int zs_DSPTS = 0;
        public string ygbh;
        public int count;
        public int count_dspts_ygxx;//员工信息待审批个数
        public int count_dspts_ygzz;//员工资质待审批个数
        public int count_dspts_ygll;//员工履历待审批个数
        public int count_dspts_ygcf;//员工惩罚待审批个数
        public int count_dspts_ygjl;//员工奖励待审批个数
        public int count_dspts_ygpx;//员工培训待审批个数
        public int count_dspts_ygzc;//员工职称待审批个数
        public int count_dspts_dhsb;//导航设备待审批个数
        public int count_dspts_txsb;//通信设备待审批个数
        public int count_dspts_qxsb;//气象设备待审批个数
        public int count_dspts_tzsb;//台站设备待审批个数
        public int count_dspts_bjgl;//备件管理待审批个数
        public int count_dspts_bjck;//备件出库待审批个数
        public int count_dspts_bjrk;//备件入库待审批个数
        public int count_dspts_sbgz;//设备故障待审批个数
        public int count_dspts_sbwh;//设备维护待审批个数
        public int count_dspts_jssb;//监视设备待审批个数
        public OJS.Struct_JS_YG struct_js_yg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            js = new JS(userState);
            if (!IsPostBack)
            {
                HTGL_DSPTS();


            }
        }
        private void HTGL_DSPTS()
        {
            //StringBuilder str = "";

            DataTable dt_ygxx = SysData.Select_TSR_MK(userState.userLoginName, "1101");
            DataTable dt_ygzz = SysData.Select_TSR_MK(userState.userLoginName, "1102");
            DataTable dt_ygll = SysData.Select_TSR_MK(userState.userLoginName, "1103");
            DataTable dt_ygcf = SysData.Select_TSR_MK(userState.userLoginName, "1104");
            DataTable dt_ygjl = SysData.Select_TSR_MK(userState.userLoginName, "1105");
            DataTable dt_ygpx = SysData.Select_TSR_MK(userState.userLoginName, "1106");
            DataTable dt_ygzc = SysData.Select_TSR_MK(userState.userLoginName, "1107");
            DataTable dt_dhsb = SysData.Select_TSR_MK(userState.userLoginName, "1401");//导航设备
            DataTable dt_txsb = SysData.Select_TSR_MK(userState.userLoginName, "1402");//通信设备
            DataTable dt_qxsb = SysData.Select_TSR_MK(userState.userLoginName, "1403");//气象设备
            DataTable dt_tzsb = SysData.Select_TSR_MK(userState.userLoginName, "1404");//台站管理
            DataTable dt_bjgl = SysData.Select_TSR_MK(userState.userLoginName, "1405");//备件管理
            DataTable dt_bjck = SysData.Select_TSR_MK(userState.userLoginName, "1406");//备件出库
            DataTable dt_bjrk = SysData.Select_TSR_MK(userState.userLoginName, "1407");//备件入库
            DataTable dt_sbgz = SysData.Select_TSR_MK(userState.userLoginName, "1408");//设备故障
            DataTable dt_sbwh = SysData.Select_TSR_MK(userState.userLoginName, "1409");//设备维护
            DataTable dt_jssb = SysData.Select_TSR_MK(userState.userLoginName, "1410");//监视设备
            StringBuilder str_ygxx = new StringBuilder();
            StringBuilder str_ygzz = new StringBuilder();
            StringBuilder str_ygll = new StringBuilder();
            StringBuilder str_ygcf = new StringBuilder();
            StringBuilder str_ygjl = new StringBuilder();
            StringBuilder str_ygpx = new StringBuilder();
            StringBuilder str_ygzc = new StringBuilder();
            StringBuilder str_txsb = new StringBuilder();
            StringBuilder str_dhsb = new StringBuilder();
            StringBuilder str_qxsb = new StringBuilder();
            StringBuilder str_tzgl = new StringBuilder();
            StringBuilder str_bjgl = new StringBuilder();
            StringBuilder str_bjck = new StringBuilder();
            StringBuilder str_bjrk = new StringBuilder();
            StringBuilder str_jssb = new StringBuilder();
            StringBuilder str_sbgz = new StringBuilder();
            StringBuilder str_sbwh = new StringBuilder();
            string bt = null;
            #region 员工信息
            if (dt_ygxx != null && dt_ygxx.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_ygxx = dt_ygxx.Rows.Count;
                zs_DSPTS += 1;
                str_ygxx.Append("<ul>");
                bt = "您有" + count_dspts_ygxx + "个" + "员工信息待审批！";
                str_ygxx.Append("<li>");
                str_ygxx.Append("<img src='../../Content/images/liebiao.png'>");

                str_ygxx.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx"  + " style=\"color:#0516f3;\" > ");
                str_ygxx.Append(bt);
                str_ygxx.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_ygxx.Text = str_ygxx.ToString();
                }

            }
            #endregion
            #region 员工资质
            if (dt_ygzz != null && dt_ygzz.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_ygzz = dt_ygzz.Rows.Count;
                zs_DSPTS += 1;
                str_ygzz.Append("<ul>");
                bt = "您有" + count_dspts_ygzz + "个" + "员工资质信息待审批！";
                str_ygzz.Append("<li>");
                str_ygzz.Append("<img src='../../Content/images/liebiao.png'>");
                str_ygzz.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_ygzz.Append(bt);
                str_ygzz.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_ygzz.Text = str_ygzz.ToString();
                }
            }
            #endregion
            #region 员工履历
            if (dt_ygll != null && dt_ygll.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_ygll = dt_ygll.Rows.Count;
                zs_DSPTS += 1;
                str_ygll.Append("<ul>");
                bt = "您有" + count_dspts_ygll + "个" + "员工履历信息待审批！";
                str_ygll.Append("<li>");
                str_ygll.Append("<img src='../../Content/images/liebiao.png'>");
                str_ygll.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_ygll.Append(bt);
                str_ygll.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_ygll.Text = str_ygll.ToString();
                }
            }
            #endregion
            #region 员工奖励
            if (dt_ygjl != null && dt_ygjl.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_ygjl = dt_ygjl.Rows.Count;
                zs_DSPTS += 1;
                str_ygjl.Append("<ul>");
                bt = "您有" + count_dspts_ygjl + "个" + "员工奖励信息待审批！";
                str_ygjl.Append("<li>");
                str_ygjl.Append("<img src='../../Content/images/liebiao.png'>");
                str_ygjl.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx" + " style=\"color:#0516f3;\" > ");

                str_ygjl.Append(bt);
                str_ygjl.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_ygjl.Text = str_ygjl.ToString();
                }
            }
            #endregion
            #region 员工惩罚
            if (dt_ygcf != null && dt_ygcf.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_ygcf = dt_ygcf.Rows.Count;
                zs_DSPTS += 1;
                str_ygcf.Append("<ul>");
                bt = "您有" + count_dspts_ygcf + "个" + "员工惩罚信息待审批！";
                str_ygcf.Append("<li>");
                str_ygcf.Append("<img src='../../Content/images/liebiao.png'>");
                str_ygcf.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx" + " style=\"color:#0516f3;\" > ");

                str_ygcf.Append(bt);
                str_ygcf.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_ygcf.Text = str_ygcf.ToString();
                }
            }
            #endregion
            #region 员工培训
            if (dt_ygpx != null && dt_ygpx.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_ygpx = dt_ygpx.Rows.Count;
                zs_DSPTS += 1;
                str_ygpx.Append("<ul>");
                bt = "您有" + count_dspts_ygpx + "个" + "员工培训信息待审批！";
                str_ygpx.Append("<li>");
                str_ygpx.Append("<img src='../../Content/images/liebiao.png'>");
                str_ygpx.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx" + " style=\"color:#0516f3;\" > ");

                str_ygpx.Append(bt);
                str_ygpx.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_ygpx.Text = str_ygpx.ToString();
                }
            }
            #endregion
            #region 员工职称
            if (dt_ygzc != null && dt_ygzc.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_ygzc = dt_ygzc.Rows.Count;
                zs_DSPTS += 1;
                str_ygzc.Append("<ul>");
                bt = "您有" + count_dspts_ygzc + "个" + "员工职称信息待审批！";
                str_ygzc.Append("<li>");
                str_ygzc.Append("<img src='../../Content/images/liebiao.png'>");
                str_ygzc.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx" + " style=\"color:#0516f3;\" > ");

                str_ygzc.Append(bt);
                str_ygzc.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_ygzc.Text = str_ygzc.ToString();
                }
            }
            #endregion

            #region 导航设备
            if (dt_dhsb != null && dt_dhsb.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_dhsb = dt_dhsb.Rows.Count;
                zs_DSPTS += 1;
                str_dhsb.Append("<ul>");
                bt = "您有" + count_dspts_dhsb + "个" + "导航信息待审批！";
                str_dhsb.Append("<li>");
                str_dhsb.Append("<img src='../../Content/images/liebiao.png'>");
                str_dhsb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");

                str_dhsb.Append(bt);
                str_dhsb.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_dhsb.Text = str_dhsb.ToString();
                }
            }
            #endregion
            #region 通信设备
            if (dt_txsb != null && dt_txsb.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_txsb = dt_txsb.Rows.Count;
                zs_DSPTS += 1;
                str_txsb.Append("<ul>");
                bt = "您有" + count_dspts_txsb + "个" + "通信信息待审批！";
                str_txsb.Append("<li>");
                str_txsb.Append("<img src='../../Content/images/liebiao.png'>");
                str_txsb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_txsb.Append(bt);
                str_txsb.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_txsb.Text = str_txsb.ToString();
                }
            }
            #endregion
            #region 气象设备
            if (dt_qxsb != null && dt_qxsb.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_qxsb = dt_qxsb.Rows.Count;
                zs_DSPTS += 1;
                str_qxsb.Append("<ul>");
                bt = "您有" + count_dspts_qxsb + "个" + "气象信息待审批！";
                str_qxsb.Append("<li>");
                str_qxsb.Append("<img src='../../Content/images/liebiao.png'>");
                str_qxsb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_qxsb.Append(bt);
                str_qxsb.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_qxsb.Text = str_qxsb.ToString();
                }
            }
            #endregion
            #region 台站设备
            if (dt_tzsb != null && dt_tzsb.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_tzsb = dt_tzsb.Rows.Count;
                zs_DSPTS += 1;
                str_tzgl.Append("<ul>");
                bt = "您有" + count_dspts_tzsb + "个" + "台站信息待审批！";
                str_tzgl.Append("<li>");
                str_tzgl.Append("<img src='../../Content/images/liebiao.png'>");
                str_tzgl.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_tzgl.Append(bt);
                str_tzgl.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_tzsb.Text = str_tzgl.ToString();
                }
            }
            #endregion
            #region 备件管理
            if (dt_bjgl != null && dt_bjgl.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_bjgl = dt_bjgl.Rows.Count;
                zs_DSPTS += 1;
                str_bjgl.Append("<ul>");
                bt = "您有" + count_dspts_bjgl + "个" + "备件管理信息待审批！";
                str_bjgl.Append("<li>");
                str_bjgl.Append("<img src='../../Content/images/liebiao.png'>");
                str_bjgl.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_bjgl.Append(bt);
                str_bjgl.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_bjgl.Text = str_bjgl.ToString();
                }
            }
            #endregion
            #region 备件出库
            if (dt_bjck != null && dt_bjck.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_bjck = dt_bjck.Rows.Count;
                zs_DSPTS += 1;
                str_bjck.Append("<ul>");
                bt = "您有" + count_dspts_bjck + "个" + "设备出库信息待审批！";
                str_bjck.Append("<li>");
                str_bjck.Append("<img src='../../Content/images/liebiao.png'>");
                str_bjck.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_bjck.Append(bt);
                str_bjck.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_bjck.Text = str_bjck.ToString();
                }
            }
            #endregion
            #region 备件入库
            if (dt_bjrk != null && dt_bjrk.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_bjrk = dt_bjrk.Rows.Count;
                zs_DSPTS += 1;
                str_bjrk.Append("<ul>");
                bt = "您有" + count_dspts_bjrk + "个" + "设备入库信息待审批！";
                str_bjrk.Append("<li>");
                str_bjrk.Append("<img src='../../Content/images/liebiao.png'>");
                str_bjrk.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_bjrk.Append(bt);
                str_bjrk.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_bjrk.Text = str_bjrk.ToString();
                }
            }
            #endregion
            #region 设备故障
            if (dt_sbgz != null && dt_sbgz.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_sbgz = dt_sbgz.Rows.Count;
                zs_DSPTS += 1;
                str_sbgz.Append("<ul>");
                bt = "您有" + count_dspts_sbgz + "个" + "设备故障信息待审批！";
                str_sbgz.Append("<li>");
                str_sbgz.Append("<img src='../../Content/images/liebiao.png'>");
                str_sbgz.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_sbgz.Append(bt);
                str_sbgz.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_sbgz.Text = str_sbgz.ToString();
                }
            }
            #endregion
            #region 设备维护
            if (dt_sbwh != null && dt_sbwh.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_sbwh = dt_sbwh.Rows.Count;
                zs_DSPTS += 1;
                str_sbwh.Append("<ul>");
                bt = "您有" + count_dspts_sbwh + "个" + "设备维护信息待审批！";
                str_sbwh.Append("<li>");
                str_sbwh.Append("<img src='../../Content/images/liebiao.png'>");
                str_sbwh.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_sbwh.Append(bt);
                str_sbwh.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_sbwh.Text = str_sbwh.ToString();
                }
            }
            #endregion
            #region 监视设备
            if (dt_jssb != null && dt_jssb.Rows.Count > 0)     //判断是否有数据  
            {
                count_dspts_jssb = dt_jssb.Rows.Count;
                zs_DSPTS += 1;
                str_jssb.Append("<ul>");
                bt = "您有" + count_dspts_jssb + "个" + "监视设备信息待审批！";
                str_jssb.Append("<li>");
                str_jssb.Append("<img src='../../Content/images/liebiao.png'>");
                str_jssb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx" + " style=\"color:#0516f3;\" > ");
                str_jssb.Append(bt);
                str_jssb.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_jssb.Text = str_jssb.ToString();
                }
            }
            #endregion

        }


    }
    
}