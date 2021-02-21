
using System;
using System.Data;
using System.Text;
using CUST.MKG;
using Sys;
using CUST.Sys;
using System.Threading;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace CUST.WKG
{
    public partial class Sys_Index : System.Web.UI.Page
    {
        public static UserState userState;
        private YH yh;
        private JS js;
        public  static YG yg;
        public static YGZZ ygzz;
        private HT ht;
        public int zs=0;
        public int zs_DSPTS = 0;
        public string  ygbh;
        public  int count;
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
        public Struct_Schedule schedule;
        DateTime dtCurrentDate = DateTime.Now; //当前
        DateTime dtPriviousDate = DateTime.Now.AddMonths(-1); //上一个月

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            if (userState.userSFSCDL == "0")
            {
                Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用！\");window.top.location.href='PersonPwdXG.aspx';</script>");
                Response.End();
                return;
            }

            struct_js_yg = new OJS.Struct_JS_YG();
            js = new JS(userState);
            yh = new YH(userState);
            ht = new HT(userState);
            yg = new YG(userState);
            ygzz = new YGZZ(userState);
            if (!IsPostBack)
            {
                zs_DSPTS = 0;
                ygbh = userState.userLoginName;
                Insert_Login();
                Show_xx();
                //公告
                Show_gg();
                //快捷入口
                Show_krjk();
                //合同有效期
                HTGL_HT();
                HTGL_DSPTS();
                //设备有效期
                //SB_QXYXQ();
                //SB_YBYXQ();
                SB_TXYXQ();
                //SB_DHYXQ();
                //资质有效期            
                select_zzyxq();
                //lbl_zs.Text =Convert.ToString(zs);
                //   lbl_zs.ForeColor=System.Drawing.Color.Red;
                this.ltlScheduleCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                this.CalendarSchedule.SelectedDate = DateTime.Now;
            }
           // _lstSchedules = _scheduleBLL.GetModelList(" userid=" + _userInfo.userId + " and SchedulePlanDate>='" + dtPriviousDate.AddDays(-10) + "' and SchedulePlanDate <='" + dtCurrentDate.AddDays(30) + "'");

        }

        private void Insert_Login ()
        {
            string p_czfs="00";
            string p_czxx = "登录";
            yh.Insert_Login(p_czfs, p_czxx);
        }

        //合同
        private void HTGL_HT()
        {
            DataTable dt_ht = ht.Select_HT_OutTime();
            StringBuilder str = new StringBuilder();
            string bt = null;
            if (dt_ht != null && dt_ht.Rows.Count > 0)     //判断是否有数据  
            {
                count=dt_ht.Rows.Count;
                zs = count;
                str.Append("<ul>");
                bt = "合同到期通知：" + dt_ht.Rows[0]["htmc"].ToString() + "还有" + dt_ht.Rows[0]["time"].ToString() + "天到期！";
                str.Append("<li>");
                str.Append("<img src='../../Content/images/liebiao.png'>");
                //页面重新做
                str.Append("<a href='HT_SY_Detail.aspx?id=" + Convert.ToInt32(dt_ht.Rows[0]["id"].ToString()) +" '>");    //传值
                str.Append(bt);
                str.Append("</ul>");
                this.lbl_ht.Text = str.ToString();
            }
        }

        //待审批提示
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

                str_ygxx.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx?trans=yggl" + " style=\"color:#0516f3;\" > ");
                str_ygxx.Append(bt);
                str_ygxx.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_ygzz.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx?trans=ygzz" + " style=\"color:#0516f3;\" > ");
                str_ygzz.Append(bt);
                str_ygzz.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_ygll.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx?trans=ygll" + " style=\"color:#0516f3;\" > ");
                str_ygll.Append(bt);
                str_ygll.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_ygjl.Append("<a href=" + "../../Views/YuanGong/YGindex.aspx?trans=ygjl" + " style=\"color:#0516f3;\" > ");

                str_ygjl.Append(bt);
                str_ygjl.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_ygcf.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx?trans=ygcf" + " style=\"color:#0516f3;\" > ");

                str_ygcf.Append(bt);
                str_ygcf.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_ygpx.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx?trans=ygpx" + " style=\"color:#0516f3;\" > ");

                str_ygpx.Append(bt);
                str_ygpx.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_ygzc.Append("<a href=" + "../../Views/YuanGong/YGIndex.aspx?trans=ygzc" + " style=\"color:#0516f3;\" > ");

                str_ygzc.Append(bt);
                str_ygzc.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_dhsb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=dhsb" + " style=\"color:#0516f3;\" > ");

                str_dhsb.Append(bt);
                str_dhsb.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_txsb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=txsb" + " style=\"color:#0516f3;\" > ");
                str_txsb.Append(bt);
                str_txsb.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_qxsb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=qxsb" + " style=\"color:#0516f3;\" > ");
                str_qxsb.Append(bt);
                str_qxsb.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_tzgl.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=tzsb" + " style=\"color:#0516f3;\" > ");
                str_tzgl.Append(bt);
                str_tzgl.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_bjgl.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=bjgl" + " style=\"color:#0516f3;\" > ");
                str_bjgl.Append(bt);
                str_bjgl.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_bjck.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=bjck" + " style=\"color:#0516f3;\" > ");
                str_bjck.Append(bt);
                str_bjck.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_bjrk.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=bjrk" + " style=\"color:#0516f3;\" > ");
                str_bjrk.Append(bt);
                str_bjrk.Append("</ul>");
                if (zs_DSPTS <= 10)
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
                str_sbgz.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=sbgz" + " style=\"color:#0516f3;\" > ");
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
                str_sbwh.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=sbwh" + " style=\"color:#0516f3;\" > ");
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
                str_jssb.Append("<a href=" + "../../Views/Shebei/SBIndex.aspx?trans=jssb" + " style=\"color:#0516f3;\" > ");
                str_jssb.Append(bt);
                str_jssb.Append("</ul>");
                if (zs_DSPTS <= 30)
                {
                    this.lbl_dspts_jssb.Text = str_jssb.ToString();
                }
            }
            #endregion

        }

        //基本信息
        private void Show_xx()
        {
            DataTable dt = yh.YH_Select_SY().Tables[0];
            if (dt.Rows.Count > 0)
            {
                lbl_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
                lbl_gh.Text = dt.Rows[0]["bh"].ToString().Trim();
                lbl_bm.Text = SysData.BMByKey(dt.Rows[0]["bmdm"].ToString().Trim()).mc;
                lbl_gw.Text = SysData.GWByKey(dt.Rows[0]["gwdm"].ToString().Trim()).mc;
         
            }
        }
        //资质有效期
        private void select_zzyxq()
        {
            string ygbh = userState.userLoginName;
            DataTable dt_yydj = new DataTable();//英语等级
            DataTable dt_tjdj = new DataTable();//体检等级
            DataTable dt_qz = new DataTable();//签注 异地签注
            dt_yydj = js.Select_JS_YGZZYXQ(ygbh).Tables[0];
            dt_tjdj = js.Select_JS_YGZZYXQ(ygbh).Tables[1];
            dt_qz = js.Select_JS_YGZZYXQ(ygbh).Tables[2];
            StringBuilder str_yydj = new StringBuilder();
            StringBuilder str_tjdj = new StringBuilder();
            StringBuilder str_qz = new StringBuilder();
            string bt = "";
            bool flag_yy;
            if ((dt_yydj != null && dt_yydj.Rows.Count > 0) || ((dt_tjdj != null && dt_tjdj.Rows.Count > 0)))
            {  
                #region 英语
                  flag_yy = false;
                  str_yydj.Append("<ul>");
                  for (int j = 0; j < dt_yydj.Rows.Count; j++)
                  {
                      count = dt_yydj.Rows.Count;
                      zs += count;
                      //创建一个实例       //查询的内容，将表内容赋给dt  
                      object dbnull = DBNull.Value;
                      if (dt_yydj.Rows[j]["yydjyxq"] != dbnull)
                      {
                          if (Convert.ToInt32(dt_yydj.Rows[j]["yydjyxq"]) <= 30 && Convert.ToInt32(dt_yydj.Rows[j]["yydjyxq"]) > 0)
                          {
                              flag_yy = true;
                              bt += SysData.YYDJLBByKey(dt_yydj.Rows[j]["s1"].ToString()).mc + "还有" + dt_yydj.Rows[j]["yydjyxq"] + "天即将过期!\r\n";
                          }
                      }
                        if (flag_yy == true)
                         {
                                 //判断是否有待办事项，播放声音
                                 if (count != 0)
                                 {
                                     hf_count.Value = "1";
                                 }
                                 str_yydj.Append("<li style=\"border-bottom:1px dashed #bfbfbf;overflow:hidden;width:300px\">");
                                 str_yydj.Append("<img src='../../Content/images/liebiao.png'>");
                                 //页面重新做
                                 //str_yydj.Append("<a href='YXQ_Detail.aspx?id=" + dt_yydj.Rows[j]["id"].ToString() + "&lx=0" + "'>");  //传值
                                 str_yydj.Append(bt);
                                 str_yydj.Append("</br>");
                                 str_yydj.Append("</ul>");
                                 this.lbl_zztx.Text = str_yydj.ToString();
                         }
                  }
               
                #endregion
                #region 体检
                  bool flag_tj = false;
                  str_tjdj.Append("<ul>");
                  for (int j = 0; j < dt_tjdj.Rows.Count; j++)
                  {
                      count = dt_tjdj.Rows.Count;
                      zs += count;
                      //创建一个实例       //查询的内容，将表内容赋给dt  
                      object dbnull = DBNull.Value;
                      if (dt_tjdj.Rows[j]["tjyxq"] != dbnull)
                      {
                          if (Convert.ToInt32(dt_tjdj.Rows[j]["tjyxq"]) <= 30 && Convert.ToInt32(dt_tjdj.Rows[j]["tjyxq"]) > 0)
                          {
                              flag_tj = true;
                              bt += "体检还有" + dt_tjdj.Rows[j]["tjyxq"] + "天即将过期!\r\n";
                          }
                      }
                        if (flag_tj == true)
                         {
                                 //判断是否有待办事项，播放声音
                                 if (count != 0)
                                 {
                                     hf_count.Value = "1";
                                 }
                                 str_tjdj.Append("<li style=\"border-bottom:1px dashed #bfbfbf;overflow:hidden;width:300px\">");
                                 str_tjdj.Append("<img src='../../Content/images/liebiao.png'>");
                                 //页面重新做
                                 //str_tjdj.Append("<a href='YXQ_Detail.aspx?id=" + dt_tjdj.Rows[j]["id"].ToString() + "&lx=1" + "'>");  //传值
                                 str_tjdj.Append(bt);
                                 str_tjdj.Append("</br>");
                                 str_tjdj.Append("</ul>");
                                 this.lbl_zztx.Text = str_tjdj.ToString();
                         }
                  }
                #endregion
                #region 签注
                  bool flag_qz = false;
                  str_qz.Append("<ul>");
                  for (int j = 0; j < dt_qz.Rows.Count; j++)
                  {
                      count = dt_qz.Rows.Count;
                      zs += count;
                      //创建一个实例       //查询的内容，将表内容赋给dt  
                      object dbnull = DBNull.Value;
                      if (dt_qz.Rows[j]["qzyxq"] != dbnull)
                      {
                          if (Convert.ToInt32(dt_qz.Rows[j]["qzyxq"]) <= 30 && Convert.ToInt32(dt_qz.Rows[j]["qzyxq"]) > 0)
                          {
                              flag_qz = true;
                              bt += SysData.ZZQZXDMByKey(dt_qz.Rows[j]["s3"].ToString()).mc + "还有" + dt_qz.Rows[j]["qzyxq"] + "天即将过期!\r\n";
                          }
                      }
                      if (dt_qz.Rows[j]["ydqzyxq"] != dbnull)
                      {
                          if (Convert.ToInt32(dt_qz.Rows[j]["ydqzyxq"]) <= 30 && Convert.ToInt32(dt_qz.Rows[j]["ydqzyxq"]) > 0)
                          {
                              flag_qz = true;
                              bt += SysData.ZZQZXDMByKey(dt_qz.Rows[j]["s6"].ToString()).mc + "还有" + dt_qz.Rows[j]["ydqzyxq"] + "天即将过期!\r\n";
                          }
                      }
                      if (flag_qz == true)
                      {
                          //判断是否有待办事项，播放声音
                          if (count != 0)
                          {
                              hf_count.Value = "1";
                          }
                          str_qz.Append("<li  style=\"border-bottom:1px dashed #bfbfbf;overflow:hidden;width:300px\">");
                          str_qz.Append("<img src='../../Content/images/liebiao.png'>");
                          //页面重新做
                          //str_qz.Append("<a href='YXQ_Detail.aspx?id=" + dt_qz.Rows[j]["id"].ToString() + "&lx=2" + "'>");  //传值
                          str_qz.Append(bt);
                          str_qz.Append("</br>");
                          str_qz.Append("</ul>");
                          this.lbl_zztx.Text = str_qz.ToString();
                      }
                  }
                  #endregion
            }
          
        }
        //公告
        private void Show_gg()
        {
            
            StringBuilder str = new StringBuilder();
            string bt = "";
            int count = 0;
            string bmdm = userState.userBMDM;
            DataTable dt_gg = new DataTable();
            dt_gg = js.Select_JS_GG(bmdm).Tables[0];
            if (dt_gg != null && dt_gg.Rows.Count > 0)     //判断是否有数据  
            {
                for (int j = 0; j < dt_gg.Rows.Count; j++)
                {
                    str.Append("<ul>");
                    count += 1;
                    if (count <5)
                    {
                        if (Convert.ToInt32(dt_gg.Rows[j]["fbsjzx"]) < 3 && Convert.ToInt32(dt_gg.Rows[j]["fbsjzx"]) >= 0)
                        {
                            //创建一个实例 //查询的内容，将表内容赋给dt 
                            bt = dt_gg.Rows[j]["bt"].ToString() + "<img id=\"img\" src=\"../../Content/images/new.gif\" style=\"color:#ff0000;fontsize:5px;\" />";
                        }
                        else
                        {
                            bt = dt_gg.Rows[j]["bt"].ToString();
                        }
                        str.Append("<li  style=\"border-bottom:1px dashed #bfbfbf;overflow:hidden;width:300px\">");
                        str.Append("<img src='../../Content/images/liebiao.png'>");
                        str.Append("<a href='GG_Detail.aspx?id=" + Convert.ToInt32(dt_gg.Rows[j]["id"].ToString()) +"&bt="+dt_gg.Rows[j]["bt"].ToString()+ " '>");    //传值
                        str.Append(bt);
                        str.Append("</ul>");
                        this.lbl_gg.Text = str.ToString();
                    }
                }
            }
        }               
        //快捷入口
        private void Show_krjk()
        {
            string ygbh = userState.userLoginName;
            DataTable dt = new DataTable();
            dt = js.Select_FPKJRK(ygbh).Tables[0];
            StringBuilder str = new StringBuilder();
            string ym = "";
            str.Append("<tr>");
            for (int i = dt.Rows.Count / 2; i < dt.Rows.Count; i++)
            {
                ym = dt.Rows[i]["ymmc"].ToString();
                str.Append("<td style=\"text-align:center; width:30px;height:25px;\">");
                string s = dt.Rows[i]["ymdm"].ToString();
                if (dt.Rows[i]["ymdm"].ToString() == "YGIndex")
                {
                    str.Append("<a href=" + "../../Views/YuanGong/" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\" > ");
                }              
                else if (dt.Rows[i]["ymdm"].ToString() == "PXIndex")
                {
                    str.Append("<a href=" + "../ZXPX/" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\" > ");
                }
                else if (dt.Rows[i]["ymdm"].ToString() == "XXIndex")
                {
                    str.Append("<a href=" + "../ZXXX/" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\" > ");
                }
                else
                {
                    str.Append("<a href=" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\" > ");    //传值
                }
                str.Append(ym);
                str.Append("</a>");
                str.Append("</td>");
            }
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < dt.Rows.Count / 2; i++)
            {
                ym = dt.Rows[i]["ymmc"].ToString();
                str.Append("<td style=\"text-align:center; width:30px;height:25px;\">");
                string s = dt.Rows[i]["ymdm"].ToString();
                if (dt.Rows[i]["ymdm"].ToString().Trim() == "YGIndex")
                {
                    str.Append("<a href=" + "../../Views/YuanGong/" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\" > ");
                }                
                else if (dt.Rows[i]["ymdm"].ToString().Trim() == "PXIndex")
                {
                    str.Append("<a href=" + "../ZXPX/" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\" > ");
                }
                else if (dt.Rows[i]["ymdm"].ToString().Trim() == "XXIndex")
                {
                    str.Append("<a href=" + "../ZXXX/" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\" > ");
                }
                else
                {
                    str.Append("<a href=" + dt.Rows[i]["ymdm"].ToString() + ".aspx" + " style=\"color:#0516f3;\">");    //传值
                }
                str.Append(ym);
                str.Append("</a>");
                str.Append("</td>");
            }
            str.Append("</tr>");
            this.lbl_rk.Text = str.ToString();
        }
        //设备有效期
        private void SB_DHYXQ()
        {
            DataTable dt_dh = new DataTable();
            dt_dh = js.Select_MH_DHSBYXQ().Tables[0];
            StringBuilder str = new StringBuilder();
            string bt = "";
            string tx = "";
            //int count = 0;
            bool flag = false;
            if (dt_dh != null && dt_dh.Rows.Count > 0)     //判断是否有数据  
            {
                for (int j = 0; j < dt_dh.Rows.Count; j++)
                {
                    count += 1;
                   
                        str.Append("<ul>");
                        //创建一个实例       //查询的内容，将表内容赋给dt  

                        object dbnull = DBNull.Value;
                        if (dt_dh.Rows[j]["dhzzyxq"] != dbnull)
                        {
                            if (Convert.ToInt32(dt_dh.Rows[j]["dhzzyxq"]) <= 30 && Convert.ToInt32(dt_dh.Rows[j]["dhzzyxq"]) >= 0)
                            {
                                flag = true;
                                bt += "执照有效期还有" + dt_dh.Rows[j]["dhzzyxq"].ToString() + "天即将过期!\r\n";//将数据库表中值赋给新的变量 
                            }
                        }
                        if (dt_dh.Rows[j]["dhfxjyrq"] != dbnull)
                        {
                            if (Convert.ToInt32(dt_dh.Rows[j]["dhfxjyrq"]) <= 30 && Convert.ToInt32(dt_dh.Rows[j]["dhfxjyrq"]) >= 0)
                            {
                                flag = true;
                                bt += "飞行校验" + "还有" + dt_dh.Rows[j]["dhfxjyrq"] + "天即将过期! \r\n";
                            }
                        }
                        if (dt_dh.Rows[j]["dhkfxkdqr"] != dbnull)
                        {
                            if (Convert.ToInt32(dt_dh.Rows[j]["dhkfxkdqr"]) <= 30 && Convert.ToInt32(dt_dh.Rows[j]["dhkfxkdqr"]) >= 0)
                            {
                                flag = true;
                                bt += "开放许可还有" + dt_dh.Rows[j]["dhkfxkdqr"] + "天即将过期! \r\n";
                            }
                        }
                        if (flag == true)
                       {
                       
                            zs += 1;
                        if (count < 2)
                        {
                            //判断是否有待办事项
                            if (count != 0)
                            {
                                hf_count.Value = "1";
                            }
                             tx = "导航设备到期提醒：编号为" + dt_dh.Rows[j]["sbbh"].ToString() + "的导航设备，" + bt;      
                             str.Append("<li>");
                             str.Append("<img src='../../Content/images/liebiao.png'>");
                             str.Append("<a  href='SB_YXQ.aspx?sbbh=" + dt_dh.Rows[j]["sbbh"].ToString() + "'>");    //传值
                             str.Append(tx);
                             str.Append("</ul>");
                             this.lbl_dhsb.Text = str.ToString();
                        }
                    }
                }
            }

        }
        private void SB_TXYXQ()
        {
            ygbh = userState.userLoginName;
            DataTable dt_tx = new DataTable();
            dt_tx = js.Select_MH_TXSBYXQ(ygbh).Tables[0];
            StringBuilder str = new StringBuilder();
            string tx = "";
            bool flag = false;
            object dbnull = DBNull.Value;
            if (dt_tx != null && dt_tx.Rows.Count > 0)     //判断是否有数据  
            {
                for (int j = 0; j < dt_tx.Rows.Count; j++)
                {
                    if (dt_tx.Rows[j]["wxdmzxt_wxdtzzyxq"] != dbnull)
                    {
                        if (Convert.ToInt32(dt_tx.Rows[j]["wxdmzxt_wxdtzzyxq"]) <= 183 && Convert.ToInt32(dt_tx.Rows[j]["wxdmzxt_wxdtzzyxq"]) >= 0)
                        {
                            flag = true;
                            zs += 1;
                        }
                    }
                }
                if (flag == true)
                {
                    //判断是否有待办事项
                    if (count != 0)
                    {
                        hf_count.Value = "1";
                    }
                    tx = "通信设备到期提醒：有" + zs + "个卫星地面站系统的无线电台执照有效期即将过期";
                    str.Append("<li>");
                    str.Append("<img src='../../Content/images/liebiao.png'>");
                    str.Append(tx);
                    str.Append("</ul>");
                    this.lbl_txsb.Text = str.ToString();
                }
            }
        }
        private void SB_QXYXQ()
        {
            DataTable dt_qx = new DataTable();
            dt_qx = js.Select_MH_QXSBYXQ().Tables[0];
            StringBuilder str = new StringBuilder();
            string bt = "";
            //int count = 0;
            string tx = "";
            bool flag = false;
            if (dt_qx != null && dt_qx.Rows.Count > 0)     //判断是否有数据  
            {
                for (int j = 0; j < dt_qx.Rows.Count; j++)
                {
                     count += 1;

                        str.Append("<ul>");
                        //创建一个实例       //查询的内容，将表内容赋给dt  

                        object dbnull = DBNull.Value;
                        if (dt_qx.Rows[j]["qxcgqjdyxq"] != dbnull)
                        {
                            if (Convert.ToInt32(dt_qx.Rows[j]["qxcgqjdyxq"]) <= 30 && Convert.ToInt32(dt_qx.Rows[j]["qxcgqjdyxq"]) >= 0)
                            {
                                flag = true;
                                bt += "传感器鉴定有效期还有" + dt_qx.Rows[j]["qxcgqjdyxq"].ToString() + "天即将过期!\r\n";//将数据库表中值赋给新的变量 
                            }
                        }
                        
                        if (flag == true)
                        {

                            zs += 1;
                            if (count < 5)
                            {
                             
                            //判断是否有待办事项
                            if (count != 0)
                            {
                                hf_count.Value = "1";
                            }
                            tx = "气象设备到期提醒：编号为" + dt_qx.Rows[j]["sbbh"].ToString() + "的气象设备，" + bt;
                            str.Append("<li>");
                            str.Append("<img src='../../Content/images/liebiao.png'>");
                            str.Append("<a href='SB_YXQ.aspx?sbbh=" + dt_qx.Rows[j]["sbbh"].ToString() + "'>");    //传值
                            str.Append(tx);
                            str.Append("</ul>");
                            this.lbl_qxsb.Text = str.ToString();

                        }
                    }
                }
            }
        }
        private void SB_YBYXQ()
        {
            DataTable dt_yb = new DataTable();
            //dt_yb = js.Select_MH_YBSBYXQ().Tables[0];
            StringBuilder str = new StringBuilder();
            string bt = "";
            //int count = 0;
            string tx = "";
            bool flag = false;
            if (dt_yb != null && dt_yb.Rows.Count > 0)     //判断是否有数据  
            {
                for (int j = 0; j < dt_yb.Rows.Count; j++)
                {
                   
                        count += 1;
                   
                        str.Append("<ul>");
                        //创建一个实例       //查询的内容，将表内容赋给dt  

                        object dbnull = DBNull.Value;
                        if (dt_yb.Rows[j]["ybjcyxq"] != dbnull)
                        {
                            if (Convert.ToInt32(dt_yb.Rows[j]["ybjcyxq"]) <= 30 && Convert.ToInt32(dt_yb.Rows[j]["ybjcyxq"]) >= 0)
                            {
                                flag = true;
                                bt += "检测有效期还有" + dt_yb.Rows[j]["ybjcyxq"].ToString() + "天即将过期!\r\n";//将数据库表中值赋给新的变量 
                            }
                        }
                        if (flag == true)
                        {
                            zs += 1;
                            if (count <5)
                            {
                            //判断是否有待办事项
                            if (count != 0)
                            {
                                hf_count.Value = "1";
                            }
                            tx = "仪表设备到期提醒：编号为" + dt_yb.Rows[j]["sbbh"].ToString() + "的仪表设备，" + bt;
                            str.Append("<li>");
                            str.Append("<img src='../../Content/images/liebiao.png'>");
                            str.Append("<a href='SB_YXQ.aspx?sbbh=" + dt_yb.Rows[j]["sbbh"].ToString() + "'>");    //传值
                            str.Append(tx);
                            str.Append("</ul>");
                            this.lbl_ybsb.Text = str.ToString();
                        }
                    }
                }
            }
        }
        protected void more_zz_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("YXQTX.aspx");
        }
        protected void more_gg_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("GongGao.aspx");
        }



        //日历
        protected void calendar_PreRender(object sender, EventArgs e)
        {
            Thread t = Thread.CurrentThread;
            System.Globalization.CultureInfo c = (System.Globalization.CultureInfo)t.CurrentCulture.Clone();
            c.DateTimeFormat.DayNames = new string[] { "日", "一", "二", "三", "四", "五", "六" };
            c.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            t.CurrentCulture = c;
        }





        /// <summary>
        /// 初始化日历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CalendarSchedule_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Cell.Attributes.Add("date", e.Day.Date.ToString("yyyy-MM-dd"));
            e.Cell.Attributes.Add("id", "td" + e.Day.Date.ToString("MMdd"));
            e.Cell.Attributes.Add("scheduleId", "NO");
            DataTable dt = new DataTable();
            Struct_Schedule struct_schedule = new Struct_Schedule();
            struct_schedule.p_ygbh = userState.userLoginName;
            #region  查找日程
            dt = yg.Select_Schedule_By_Ygbh(struct_schedule);//查找日程
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string a = e.Day.Date.ToString("yyyy-MM-dd");
                    string b = DateTime.Parse(dr["schedule_plane_date"].ToString()).ToString("yyyy-MM-dd");
                    if (e.Day.Date.ToString("yyyy-MM-dd").Equals(DateTime.Parse(dr["schedule_plane_date"].ToString()).ToString("yyyy-MM-dd")))
                    {
                        e.Cell.Style.Add("background-color", dr["schedule_color"].ToString());
                        e.Cell.Attributes.Add("scheduleId", dr["id"].ToString());
                        e.Cell.Text = e.Day.Date.ToString("dd") + "<br/>" + dr["schedule_title"].ToString(); //+ "<br/>" + dr["schedule_description"].ToString();//标题+描述
                        e.Cell.Font.Bold = true;
                        e.Cell.Font.Size = FontUnit.Medium;
                        e.Cell.ToolTip = dr["schedule_title"].ToString() + "----" + dr["schedule_description"].ToString();//描述
                    }
                }
            }
            #endregion

            #region  查找资质
            dt  = ygzz.Select_YGZZByYGBH(userState.userLoginName, userState.userID).Tables[0];
            //查找资质
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //
                    //string a = e.Day.Date.ToString("yyyy-MM-dd");
                    //string b = DateTime.Parse(dr["yyyxq"].ToString()).ToString("yyyy-MM-dd");
                    if (e.Day.Date.ToString("yyyy-MM-dd").Equals(DateTime.Parse(dr["yyyxq"].ToString()).ToString("yyyy-MM-dd")))
                    {
                        //e.Cell.Style.Add("background-color", dr["schedule_color"].ToString());
                        if (e.Cell.Text == "")
                        {
                            e.Cell.Text = e.Day.Date.ToString("dd") + "<br/>" +"英语有效期到期提醒";
                            e.Cell.ToolTip = "英语有效期到期时间为：" + dr["yyyxq"].ToString();
                        }
                        else {
                            e.Cell.Text += "英语有效期到期提醒";
                            e.Cell.ToolTip += "英语有效期到期时间为："+dr["yyyxq"].ToString();
                        }

                    }
                }
            }
            #endregion
        }

        protected void CalendarSchedule_SelectionChanged(object sender, EventArgs e)
        {



        }
        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="strScheduleTitle">日程标题</param>
        /// <param name="strScheduleDescription">日程描述</param>
        /// <param name="strhdColor">标识颜色</param>
        /// <param name="strlblSchedulePlanDate">计划时间</param>
        /// <returns>1：成功，2：失败</returns>
        [WebMethod]
        public string AddSchedule(string Title, string Description, string Color, string PlanDate, string ID)
        {
            return "";
            //添加
            //if (ID == "NO")
            //{
            //    Struct_Schedule schedule = new Struct_Schedule();
            //    schedule.p_ygbh = userState.userLoginName;
            //    schedule.p_schedule_create_date = DateTime.Now;
            //    schedule.p_schedule_color = Color;
            //    schedule.p_schedule_description = Description;
            //    schedule.p_schedule_plane_date= Convert.ToDateTime(PlanDate);
            //    schedule.p_schedule_title= Title;
            //    yg.Insert_Schedule(schedule);
            //    return "1";
            //}
            //else
            //{
            //    //编辑
            //    Struct_Schedule schedule = new Struct_Schedule();
            //    schedule.p_ygbh = userState.userLoginName;
            //    schedule.p_schedule_create_date = DateTime.Now;
            //    schedule.p_schedule_color = strhdColor;
            //    schedule.p_schedule_description = strScheduleDescription;
            //    schedule.p_schedule_plane_date = Convert.ToDateTime(strlblSchedulePlanDate);
            //    schedule.p_schedule_title = strScheduleTitle;
            //    yg.Update_Schedule(schedule);
            //    return "3";
            //}
        }
        /// <summary>
        /// 编辑日程,显示该ID原日程信息
        /// </summary>
        /// <param name="shecduleID">日程id</param>
        /// <returns></returns>
        [WebMethod]
        public static string[] EditSchedule(string strScheduleID)
        {
            DataTable dt = new DataTable();
            Struct_Schedule struct_schedule = new Struct_Schedule();
            struct_schedule.p_id = Convert.ToInt32(strScheduleID);
            dt = yg.Select_Schedule_By_Id(struct_schedule);//查找日程
            string color = dt.Rows[0]["schedule_color"].ToString();
            string time= dt.Rows[0]["schedule_plane_date"].ToString();
            if (dt.Rows.Count > 0)
            {
                return new string[] { dt.Rows[0]["id"].ToString(), dt.Rows[0]["schedule_title"].ToString(), dt.Rows[0]["schedule_description"].ToString(), Convert.ToDateTime(dt.Rows[0]["schedule_create_date"].ToString()).ToString("yyyy-MM-dd hh:mm:ss"), dt.Rows[0]["schedule_color"].ToString(), Convert.ToDateTime(dt.Rows[0]["schedule_plane_date"].ToString()).ToString("yyyy-MM-dd") };
            }
            else {
                return new string[0];
            }
            //if (string.IsNullOrEmpty(strScheduleID))
            //{
            //    return new string[0];
            //}
            //else
            //{
            //    int intScheduleID = Convert.ToInt32(strScheduleID);
            //    ScheduleBLL scheduleBLL = new ScheduleBLL();
            //    IList<Schedule.Model.Schedule> lstSchedules = scheduleBLL.GetModelList(" userid=" + _userInfo.userId + " and scheduleId=" + intScheduleID + "");
            //    if (lstSchedules.Count > 0)
            //    {
            //        Schedule.Model.Schedule schedule = lstSchedules[0];
            //        return new string[] { schedule.scheduleId.ToString(), schedule.scheduleTitle, schedule.scheduleDescription, Convert.ToDateTime(schedule.scheduleCreateDate).ToString("yyyy-MM-dd hh:mm:ss"), schedule.scheduleColor, schedule.SchedulePlanDate.ToString("yyyy-MM-dd") };
            //    }
            //    else
            //    {
            //        return new string[0];
            //    }
            //}

            
        }
        /// <summary>
        /// 删除日程
        /// </summary>
        /// <param name="secheduleID">日程id</param>
        /// <returns></returns>
        [WebMethod]
        public static string DeleteSchedule(string strScheduleID)
        {
            if (string.IsNullOrEmpty(strScheduleID))
            {
                return "0";
            }
            else
            {
                Struct_Schedule struct_schedule = new Struct_Schedule();
                struct_schedule.p_id = Convert.ToInt32(strScheduleID);                
                string czfs="0";
                string czxx="1";
                yg.Delete_Schedule(struct_schedule.p_id,czfs,czxx);
                return "1";

            }
           
            //else
            //{
            //    int intScheduleID = Convert.ToInt32(strScheduleID);
            //    ScheduleBLL scheduleBLL = new ScheduleBLL();
            //    if (scheduleBLL.Delete(intScheduleID))
            //    {
            //        return "1";
            //    }
            //    else
            //    {
            //        return "0";
            //    }
            }
            //return "";
        
        /// <summary>
        /// 月改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CalendarSchedule_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            dtCurrentDate = e.NewDate;
            dtPriviousDate = e.PreviousDate;
            //_lstSchedules = _scheduleBLL.GetModelList(" userid=" + _userInfo.userId + " and SchedulePlanDate>='" + dtPriviousDate.AddDays(-10) + "' and SchedulePlanDate <='" + dtCurrentDate.AddDays(30) + "'");
        }


        [WebMethod]
        public static string add(string Title, string Description, string Color, string PlanDate, string ID)
        {

            //添加
            if (ID == "NO")
            {
                if (Title == "" || PlanDate == "")
                {
                    return "2";
                }
                Struct_Schedule schedule = new Struct_Schedule();
                schedule.p_ygbh = userState.userLoginName;
                schedule.p_schedule_create_date = DateTime.Now;
                schedule.p_schedule_color = Color;
                schedule.p_schedule_description = Description;
                schedule.p_schedule_plane_date = Convert.ToDateTime(PlanDate);
                schedule.p_schedule_title = Title;
                schedule.p_czfs = "02";
                schedule.p_czxx = "位置：日程添加>  描述：员工编号：" + userState.userLoginName;
                yg.Insert_Schedule(schedule);
                return "1";
            }
            else
            {
                if (Title == "" || PlanDate == ""||ID=="")
                {
                    return "4";
                }
                //编辑
                Struct_Schedule schedule = new Struct_Schedule();
                schedule.p_id= Convert.ToInt32(ID);
                schedule.p_ygbh = userState.userLoginName;
                schedule.p_schedule_create_date = DateTime.Now;
                schedule.p_schedule_color = Color;
                schedule.p_schedule_description = Description;
                schedule.p_schedule_plane_date = Convert.ToDateTime(PlanDate);
                schedule.p_schedule_title = Title;
                schedule.p_czfs = "03";
                schedule.p_czxx = "位置：日程编辑>  描述：员工编号：" + userState.userLoginName;
                yg.Update_Schedule(schedule);
                return "3";
            }
        }
    }
}