using CUST.Sys;
using CUST;
using System;
using CUST.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using Sys;

namespace CUST.WKG
{
    public partial class CSPZ : System.Web.UI.Page
    {
        private UserState userstate;
        private YH yh;
        private Struct_YH struct_yh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (userstate.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            yh = new YH(userstate);
            if (!IsPostBack)
            {
                Pager_PZ();
             
            }
        }
        //protected void SYS_Pager_PZ()
        //{
        //    tbx_ygrz.Text = Convert.ToString(Config.C_JX_YGRZ);
        //    tbx_jcyxxx.Text = Convert.ToString(Config.C_HW_JCYXXX);
        //    tbx_txsb.Text = Convert.ToString(Config.C_SB_TX);
        //    tbx_dhsb.Text = Convert.ToString(Config.C_SB_DH);
        //    tbx_qxsb.Text = Convert.ToString(Config.C_SB_QX);
        //    tbx_qbsb.Text = Convert.ToString(Config.C_SB_QB);
        //    tbx_jssb.Text = Convert.ToString(Config.C_SB_JS);
        //    tbx_sbgl.Text = Convert.ToString(Config.C_SB_GZ);
        //    tbx_sbwh.Text = Convert.ToString(Config.C_SB_WH);
        //    tbx_zdgl.Text = Convert.ToString(Config.C_HT_ZD);
        //    tbx_rzgl.Text = Convert.ToString(Config.C_HT_RZ);
        //    tbx_yhgl.Text = Convert.ToString(Config.C_HT_YH);
        //    tbx_bmgl.Text = Convert.ToString(Config.C_HT_BM);
        //    tbx_gwgl.Text = Convert.ToString(Config.C_HT_GW);
        //    tbx_fbgg.Text = Convert.ToString(Config.C_HT_FBGG);
        //    tbx_ygxx.Text = Convert.ToString(Config.C_YG_XX);
        //    tbx_ygzl.Text = Convert.ToString(Config.C_YG_ZZ);
        //    tbx_ygll.Text = Convert.ToString(Config.C_YG_LL);
        //}
        protected void Pager_PZ()
        {
            //员工
            tbx_ygxx.Text = Convert.ToString(userstate.C_YG_XX);
            tbx_ygzl.Text = Convert.ToString(userstate.C_YG_ZZ);
            tbx_ygll.Text = Convert.ToString(userstate.C_YG_LL);
            tbx_ygcf.Text = Convert.ToString(userstate.C_YG_CF);
            tbx_ygjl.Text = Convert.ToString(userstate.C_YG_JL);
            tbx_ygpx.Text = Convert.ToString(userstate.C_YG_PX);
            tbx_ygzc.Text = Convert.ToString(userstate.C_YG_ZC);
            //设备
         
            tbx_txsb.Text = Convert.ToString(userstate.C_SB_TX);
            tbx_dhsb.Text = Convert.ToString(userstate.C_SB_DH);
            tbx_qxsb.Text = Convert.ToString(userstate.C_SB_QX);
            tbx_jssb.Text = Convert.ToString(userstate.C_SB_JS);      
            tbx_sbwh.Text = Convert.ToString(userstate.C_SB_WH);
            tbx_bjgl.Text = Convert.ToString(userstate.C_SB_BJGL);
            tbx_bjrk.Text = Convert.ToString(userstate.C_SB_BJRK);
            tbx_bjck.Text = Convert.ToString(userstate.C_SB_BJCK);
            tbx_tzsb.Text = Convert.ToString(userstate.C_SB_TZ);
            tbx_sbgz.Text = Convert.ToString(userstate.C_SB_GZ);
           //后台
            tbx_zdgl.Text = Convert.ToString(userstate.C_HT_ZD);
            tbx_rzgl.Text = Convert.ToString(userstate.C_HT_RZ);
            tbx_yhgl.Text = Convert.ToString(userstate.C_HT_YH);
            tbx_bmgl.Text = Convert.ToString(userstate.C_HT_BM);
            tbx_gwgl.Text = Convert.ToString(userstate.C_HT_GW);
            tbx_fbgg.Text = Convert.ToString(userstate.C_HT_FBGG);
           //资料
            tbx_zlgl.Text = Convert.ToString(userstate.C_ZL_ZL);
            tbx_zjzlgl.Text = Convert.ToString(userstate.C_ZL_ZJ);
            //报送
            tbx_zbap.Text = Convert.ToString(userstate.C_BS_ZBAP);
            tbx_gzjz.Text = Convert.ToString(userstate.C_BS_GZJZ);
            tbx_ys.Text = Convert.ToString(userstate.C_BS_YSSB);
            tbx_zdgz.Text = Convert.ToString(userstate.C_BS_ZDGZ);
            tbx_wxfgl.Text = Convert.ToString(userstate.C_BS_WXFGL);
            //安全
            tbx_aqxx.Text = Convert.ToString(userstate.C_AQ_AQXX);
            tbx_tqcz.Text = Convert.ToString(userstate.C_AQ_TQCZ);
            tbx_bssg.Text = Convert.ToString(userstate.C_AQ_BSSG);
            tbx_zybs.Text = Convert.ToString(userstate.C_AQ_ZYBS);
            //五库
            tbx_sbblk.Text = Convert.ToString(userstate.C_WK_SBBLK);
            tbx_wxyk.Text = Convert.ToString(userstate.C_WK_WXYK);
            tbx_aqwtk.Text = Convert.ToString(userstate.C_WK_AQWTK);
            tbx_aqyhk.Text = Convert.ToString(userstate.C_WK_AQYHK);
            tbx_zjxxk.Text = Convert.ToString(userstate.C_WK_ZJXXK);

            
        }
        protected void init()
        {
            //员工
            struct_yh.C_YG_XX = int.Parse(tbx_ygxx.Text);
            struct_yh.C_YG_ZZ = int.Parse(tbx_ygzl.Text);
            struct_yh.C_YG_LL = int.Parse(tbx_ygll.Text);
            struct_yh.C_YG_CF = int.Parse(tbx_ygcf.Text);
            struct_yh.C_YG_JL = int.Parse(tbx_ygjl.Text);
            struct_yh.C_YG_PX = int.Parse(tbx_ygpx.Text);
            struct_yh.C_YG_ZC = int.Parse(tbx_ygzc.Text);

            //设备
            struct_yh.C_SB_TX = int.Parse(tbx_txsb.Text);
            struct_yh.C_SB_DH = int.Parse(tbx_dhsb.Text);
            struct_yh.C_SB_QX = int.Parse(tbx_qxsb.Text);
            struct_yh.C_SB_JS = int.Parse(tbx_jssb.Text);    
            struct_yh.C_SB_WH = int.Parse(tbx_sbwh.Text);
            struct_yh.C_SB_GZ = int.Parse(tbx_sbgz.Text);
            struct_yh.C_SB_BJGL = int.Parse(tbx_bjgl.Text);
            struct_yh.C_SB_BJCK = int.Parse(tbx_bjck.Text);
            struct_yh.C_SB_BJRK = int.Parse(tbx_bjrk.Text);
            struct_yh.C_SB_TZ = int.Parse(tbx_tzsb.Text);
            //后台
            struct_yh.C_HT_ZD = int.Parse(tbx_zdgl.Text);
            struct_yh.C_HT_RZ = int.Parse(tbx_rzgl.Text);
            struct_yh.C_HT_YH = int.Parse(tbx_yhgl.Text);
            struct_yh.C_HT_BM = int.Parse(tbx_bmgl.Text);
            struct_yh.C_HT_GW = int.Parse(tbx_gwgl.Text);
            struct_yh.C_HT_FBGG = int.Parse(tbx_fbgg.Text);
              //资料库      
            struct_yh.C_ZL_ZL= int.Parse(tbx_zlgl.Text);
            struct_yh.C_ZL_ZJ   =int.Parse(tbx_zjzlgl.Text);
            //报送
            struct_yh.C_BS_GZJZ = int.Parse(tbx_gzjz.Text);
            struct_yh.C_BS_ZBAP = int.Parse(tbx_zbap.Text);
            struct_yh.C_BS_YSSB = int.Parse(tbx_ys.Text);
            struct_yh.C_BS_ZDGZ = int.Parse(tbx_zdgz.Text);
            struct_yh.C_BS_WXFGL = int.Parse(tbx_wxfgl.Text);
            //安全
            struct_yh.C_AQ_AQXX = int.Parse(tbx_aqxx.Text);
            struct_yh.C_AQ_TQCZ = int.Parse(tbx_tqcz.Text);
            struct_yh.C_AQ_BSSG = int.Parse(tbx_bssg.Text);
            struct_yh.C_AQ_ZYBS = int.Parse(tbx_zybs.Text);
            //
            struct_yh.C_WK_SBBLK = int.Parse(tbx_sbblk.Text);
            struct_yh.C_WK_WXYK = int.Parse(tbx_wxyk.Text);
            struct_yh.C_WK_AQWTK = int.Parse(tbx_aqwtk.Text);
            struct_yh.C_WK_AQYHK = int.Parse(tbx_aqyhk.Text);
            struct_yh.C_WK_ZJXXK = int.Parse(tbx_zjxxk.Text);
         

        }
        protected void btn_qd_Click(object sender, EventArgs e)
        {
            try
            {
                #region 页面设置校验
                int flag = 0;
                string reg = @"^[0-9]*$";
                //
                if (tbx_ygxx.Text == "")
                {
                    lbl_ygxx.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_ygxx.Text.ToString().Trim(), reg))
                {
                    lbl_ygxx.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_ygxx.Text.ToString().Trim()) <= 0)
                {
                    lbl_ygxx.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ygxx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_ygzl.Text == "")
                {
                    lbl_ygzl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_ygzl.Text.ToString().Trim(), reg))
                {
                    lbl_ygzl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_ygzl.Text.ToString().Trim()) <= 0)
                {
                    lbl_ygzl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ygzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_ygll.Text == "")
                {
                    lbl_ygll.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_ygll.Text.ToString().Trim(), reg))
                {
                    lbl_ygll.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_ygll.Text.ToString().Trim()) <= 0)
                {
                    lbl_ygll.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ygll.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_ygcf.Text == "")
                {
                    lbl_ygcf.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_ygcf.Text.ToString().Trim(), reg))
                {
                    lbl_ygcf.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_ygcf.Text.ToString().Trim()) <= 0)
                {
                    lbl_ygcf.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ygcf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_ygjl.Text == "")
                {
                    lbl_ygjl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_ygjl.Text.ToString().Trim(), reg))
                {
                    lbl_ygjl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_ygjl.Text.ToString().Trim()) <= 0)
                {
                    lbl_ygjl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ygjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_ygzc.Text == "")
                {
                    lbl_ygzc.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_ygzc.Text.ToString().Trim(), reg))
                {
                    lbl_ygzc.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_ygzc.Text.ToString().Trim()) <= 0)
                {
                    lbl_ygzc.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ygzc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //
          
                if (tbx_txsb.Text == "")
                {
                    lbl_txsb.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_txsb.Text.ToString().Trim(), reg))
                {
                    lbl_txsb.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_txsb.Text.ToString().Trim()) <= 0)
                {
                    lbl_txsb.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_txsb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
               
                if (tbx_jssb.Text == "")
                {
                    lbl_jssb.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_jssb.Text.ToString().Trim(), reg))
                {
                    lbl_jssb.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_jssb.Text.ToString().Trim()) <= 0)
                {
                    lbl_jssb.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_jssb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_jssb.Text == "")
                {
                    lbl_jssb.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_jssb.Text.ToString().Trim(), reg))
                {
                    lbl_jssb.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_jssb.Text.ToString().Trim()) <= 0)
                {
                    lbl_jssb.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_jssb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
               

                if (tbx_sbwh.Text == "")
                {
                    lbl_sbwh.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_sbwh.Text.ToString().Trim(), reg))
                {
                    lbl_sbwh.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_sbwh.Text.ToString().Trim()) <= 0)
                {
                    lbl_sbwh.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sbwh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_bjgl.Text == "")
                {
                    lbl_bjgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_bjgl.Text.ToString().Trim(), reg))
                {
                    lbl_bjgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_bjgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_bjgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bjgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_bjck.Text == "")
                {
                    lbl_bjck.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_bjck.Text.ToString().Trim(), reg))
                {
                    lbl_bjck.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_bjck.Text.ToString().Trim()) <= 0)
                {
                    lbl_bjck.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bjck.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_bjrk.Text == "")
                {
                    lbl_bjrk.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_bjrk.Text.ToString().Trim(), reg))
                {
                    lbl_bjrk.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_bjrk.Text.ToString().Trim()) <= 0)
                {
                    lbl_bjrk.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bjrk.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_sbgz.Text == "")
                {
                    lbl_sbgz.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_sbgz.Text.ToString().Trim(), reg))
                {
                    lbl_sbgz.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_sbgz.Text.ToString().Trim()) <= 0)
                {
                    lbl_sbgz.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_sbgz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                //

                if (tbx_zdgl.Text == "")
                {
                   lbl_zdgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_zdgl.Text.ToString().Trim(), reg))
                {
                    lbl_zdgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_zdgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_zdgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zdgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_rzgl.Text == "")
                {
                    lbl_rzgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_rzgl.Text.ToString().Trim(), reg))
                {
                    lbl_rzgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_rzgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_rzgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_rzgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_yhgl.Text == "")
                {
                    lbl_yhgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_yhgl.Text.ToString().Trim(), reg))
                {
                    lbl_yhgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_yhgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_yhgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_yhgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_bmgl.Text == "")
                {
                    lbl_bmgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_bmgl.Text.ToString().Trim(), reg))
                {
                    lbl_bmgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_bmgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_bmgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bmgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

                if (tbx_gwgl.Text == "")
                {
                    lbl_gwgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_gwgl.Text.ToString().Trim(), reg))
                {
                    lbl_gwgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_gwgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_gwgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_gwgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }


                if (tbx_fbgg.Text == "")
                {
                    lbl_fbgg.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_fbgg.Text.ToString().Trim(), reg))
                {
                    lbl_fbgg.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_fbgg.Text.ToString().Trim()) <= 0)
                {
                    lbl_fbgg.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_fbgg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }

             

           
                if (tbx_zbap.Text == "")
                {
                    lbl_zbap.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_zbap.Text.ToString().Trim(), reg))
                {
                    lbl_zbap.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_zbap.Text.ToString().Trim()) <= 0)
                {
                    lbl_zbap.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zbap.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_gzjz.Text == "")
                {
                    lbl_gzjz.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_gzjz.Text.ToString().Trim(), reg))
                {
                    lbl_gzjz.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_gzjz.Text.ToString().Trim()) <= 0)
                {
                    lbl_gzjz.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_gzjz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_zdgz.Text == "")
                {
                    lbl_zdgz.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_zdgz.Text.ToString().Trim(), reg))
                {
                    lbl_zdgz.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_zdgz.Text.ToString().Trim()) <= 0)
                {
                    lbl_zdgz.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zdgz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_ys.Text == "")
                {
                    lbl_ys.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_ys.Text.ToString().Trim(), reg))
                {
                    lbl_ys.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_ys.Text.ToString().Trim()) <= 0)
                {
                    lbl_ys.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_ys.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
             
                if (tbx_zlgl.Text == "")
                {
                    lbl_zlgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_zlgl.Text.ToString().Trim(), reg))
                {
                    lbl_zlgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_zlgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_zlgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zlgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_zjzlgl.Text == "")
                {
                    lbl_zjzlgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_zjzlgl.Text.ToString().Trim(), reg))
                {
                    lbl_zjzlgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_zjzlgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_zjzlgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zjzlgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (tbx_bjgl.Text == "")
                {
                    lbl_bjgl.Text = "<span style=\"color:#ff0000\">" + "不能为空！" + "</span>";
                    flag = 1;
                }
                else if (!Regex.IsMatch(tbx_bjgl.Text.ToString().Trim(), reg))
                {
                    lbl_bjgl.Text = "<span style=\"color:#ff0000\">" + "请输入数字！" + "</span>";
                    flag = 1;
                }
                else if (Convert.ToInt32(tbx_bjgl.Text.ToString().Trim()) <= 0)
                {
                    lbl_bjgl.Text = "<span style=\"color:#ff0000\">" + "输入必须大于0！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bjgl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
                if (flag == 1)
                {
                    return;
                }
                #endregion
                Set("C_YG_XX", tbx_ygxx.Text);
                Set("C_YG_ZZ", tbx_ygzl.Text);
                Set("C_YG_LL", tbx_ygll.Text);
                Set("C_YG_CF", tbx_ygcf.Text);
                Set("C_YG_JL", tbx_ygjl.Text);
                Set("C_YG_PX", tbx_ygpx.Text);
                Set("C_YG_ZC", tbx_ygzc.Text);
               
                Set("C_SB_TX", tbx_txsb.Text);
                Set("C_SB_DH", tbx_dhsb.Text);
                Set("C_SB_QX", tbx_qxsb.Text);               
                Set("C_SB_JS", tbx_jssb.Text);     
                Set("C_SB_WH", tbx_sbwh.Text);
                Set("C_SB_TZ", tbx_tzsb.Text);
                Set("C_SB_BJGL", tbx_bjgl.Text);
                Set("C_SB_BJCK", tbx_bjck.Text);
                Set("C_SB_BJRK", tbx_bjrk.Text);
                Set("C_SB_GZ", tbx_sbgz.Text);

                Set("C_HT_ZD", tbx_zdgl.Text);
                Set("C_HT_RZ", tbx_rzgl.Text);
                Set("C_HT_YH", tbx_yhgl.Text);
                Set("C_HT_BM", tbx_bmgl.Text);
                Set("C_HT_GW", tbx_gwgl.Text);
                Set("C_HT_FBGG",tbx_fbgg.Text);
               
                //---------------------------------------------
                //Set("C_HW_TQ", tbx_tqcz.Text);
                Set("C_BS_ZBAP", tbx_zbap.Text);
                Set("C_BS_GZJZ", tbx_gzjz.Text);
                Set("C_BS_ZDGZ", tbx_zdgz.Text);
                Set("C_BS_YSSB", tbx_ys.Text);
                Set("C_BS_WXFGL", tbx_wxfgl.Text);
               //
                Set("C_AQ_AQXX", tbx_aqxx.Text);
                Set("C_AQ_TQCZ", tbx_tqcz.Text);
                Set("C_AQ_BSSG", tbx_bssg.Text);
                Set("C_AQ_ZYBS", tbx_zybs.Text);

                Set("C_ZL_ZL", tbx_zlgl.Text);
                Set("C_ZL_ZJ", tbx_zjzlgl.Text);
               
                //
                Set("C_WK_SBBLK", tbx_zbap.Text);
                Set("C_WK_WXYK", tbx_gzjz.Text);
                Set("C_WK_AQWTK", tbx_zdgz.Text);
                Set("C_WK_AQYHK", tbx_ys.Text);
                Set("C_WK_ZJXXK", tbx_wxfgl.Text);
               // Config.ReSetValue();
                #region  更新
               
                bool check = true;
                struct_yh.p_id = userstate.userID;
                struct_yh.p_mc = userstate.userMC;
                init();
                struct_yh.p_czxx = "位置：后台管理->参数配置->编辑" + "     " + "[ 用户ID：" + struct_yh.p_id + "" + "    " + "用户名：" + struct_yh.p_mc + " ]" + "  描述：更改页码";
  
                
                yh.Update_Pager(struct_yh);
                //员工
                userstate.C_YG_XX = struct_yh.C_YG_XX;
                userstate.C_YG_ZZ = struct_yh.C_YG_ZZ;
                userstate.C_YG_LL = struct_yh.C_YG_LL;
                userstate.C_YG_CF = struct_yh.C_YG_CF;
                userstate.C_YG_JL = struct_yh.C_YG_JL;
                userstate.C_YG_PX = struct_yh.C_YG_PX;
                userstate.C_YG_ZC = struct_yh.C_YG_ZC;
                //设备
                userstate.C_SB_TX = struct_yh.C_SB_TX;
                userstate.C_SB_DH = struct_yh.C_SB_DH;
                userstate.C_SB_QX = struct_yh.C_SB_QX;              
                userstate.C_SB_JS = struct_yh.C_SB_JS;
                userstate.C_SB_GZ = struct_yh.C_SB_GZ;
                userstate.C_SB_WH = struct_yh.C_SB_WH;
                userstate.C_SB_BJCK = struct_yh.C_SB_BJCK;
                userstate.C_SB_BJGL = struct_yh.C_SB_BJGL;
                userstate.C_SB_BJRK = struct_yh.C_SB_BJRK;
                userstate.C_SB_TZ = struct_yh.C_SB_TZ;
                //后台
                userstate.C_HT_ZD = struct_yh.C_HT_ZD;
                userstate.C_HT_RZ = struct_yh.C_HT_RZ;
                userstate.C_HT_YH = struct_yh.C_HT_YH;
                userstate.C_HT_BM = struct_yh.C_HT_BM;
                userstate.C_HT_GW = struct_yh.C_HT_GW;
                userstate.C_HT_FBGG = struct_yh.C_HT_FBGG;
               //资料库
                userstate.C_ZL_ZL = struct_yh.C_ZL_ZL;
                userstate.C_ZL_ZJ = struct_yh.C_ZL_ZJ;
                //报送
                userstate.C_BS_ZDGZ = struct_yh.C_BS_ZDGZ;
                userstate.C_BS_ZBAP = struct_yh.C_BS_ZBAP;
                userstate.C_BS_YSSB = struct_yh.C_BS_YSSB;
                userstate.C_BS_WXFGL = struct_yh.C_BS_WXFGL;
                userstate.C_BS_GZJZ = struct_yh.C_BS_GZJZ;
                //安全
                userstate.C_AQ_AQXX = struct_yh.C_AQ_AQXX;
                userstate.C_AQ_BSSG = struct_yh.C_AQ_BSSG;
                userstate.C_AQ_TQCZ = struct_yh.C_AQ_TQCZ;
                userstate.C_AQ_ZYBS = struct_yh.C_AQ_ZYBS;
                //五库建设
                userstate.C_WK_AQWTK = struct_yh.C_WK_AQWTK;
                userstate.C_WK_AQYHK = struct_yh.C_WK_AQYHK;
                userstate.C_WK_SBBLK = struct_yh.C_WK_SBBLK;
                userstate.C_WK_WXYK = struct_yh.C_WK_WXYK;
                userstate.C_WK_ZJXXK = struct_yh.C_WK_ZJXXK;
                
                
                #endregion
               // Config.ReSetValue();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('设置成功！');</script>");
                btn_bj.Visible = true;
                btn_qd.Visible = false;
                return;
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        public string Set(string sKey, string sValue)
        {
            string _strFileName = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "#Sys.config";
            XmlDocument oXmlDocument = new XmlDocument();
            try
            {
                oXmlDocument.Load(_strFileName);
                XmlNodeList oXmlNodeList = oXmlDocument.DocumentElement.ChildNodes;
                foreach (XmlElement oXmlElement in oXmlNodeList)
                {
                    if (oXmlElement.Name.ToLower() == "appsettings")
                    {
                        XmlNodeList _node = oXmlElement.ChildNodes;
                        if (_node.Count > 0)
                        {
                            foreach (XmlElement _el in _node)
                            {
                                if (_el.Attributes["key"].InnerXml.ToLower() == sKey.ToLower())
                                {
                                    _el.Attributes["value"].Value = StrConvert.EncodeBase64(sValue);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return "";
            }
            oXmlDocument.Save(_strFileName);
            return sValue;
        }
        private void Page_Error(object sender, System.EventArgs e)
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

        protected void btn_bj_Command(object sender, CommandEventArgs e)
        {
            btn_bj.Visible = false;
            btn_qd.Visible = true;
        }

      
  
    }
}