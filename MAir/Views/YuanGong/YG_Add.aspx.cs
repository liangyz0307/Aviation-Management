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
using System.Text.RegularExpressions;
using Sys;
using System.Globalization;

namespace CUST.WKG
{
    public partial class YG_Add : System.Web.UI.Page
    {
        private UserState _usState;
        //private string ygbh;
        private YG yg;
        private Struct_YG struct_yg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yg = new YG(_usState);
            if (!IsPostBack)
            {
                bind_dropdownlist();
                //tbx_bysj.Attributes.Add("readonly", "readonly");
                tbx_bysj.Attributes.Add("readonly", "readonly");
                tbx_rzsj.Attributes.Add("readonly", "readonly");
               
            }
        }
       
        protected void bind_dropdownlist()
        {
            DataTable dt_bmdm = SysData.BM().Copy();
            ddlt_bm.DataSource = dt_bmdm;
            ddlt_bm.DataTextField = "mc";
            ddlt_bm.DataValueField = "bm";
            ddlt_bm.DataBind();
            ddlt_bm.Items.Insert(0, new ListItem("请选择", "-1"));
          

            //岗位代码
            //DataTable dt_gw = new DataTable();
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
          //  ddlt_gw.DataSource = dt_gw;
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));


            //民族
            ddlt_mz.DataTextField = "mc";
            ddlt_mz.DataValueField = "bm";
            ddlt_mz.DataSource = SysData.MZ().Copy();
            ddlt_mz.DataBind();
            ddlt_mz.Items.Insert(0, new ListItem("请选择", "-1"));


            //工作地
            ddlt_gzd.DataTextField = "mc";
            ddlt_gzd.DataValueField = "bm";
            ddlt_gzd.DataSource = SysData.ZXDM().Copy();
            ddlt_gzd.DataBind();
            ddlt_gzd.Items.Insert(0, new ListItem("请选择", "-1"));



            //学历

            ddlt_xl.DataTextField = "mc";
            ddlt_xl.DataValueField = "bm";
            ddlt_xl.DataSource = SysData.XL().Copy();
            ddlt_xl.DataBind();
            ddlt_xl.Items.Insert(0, new ListItem("请选择", "-1"));


            //政治面貌
            ddlt_zzmm.DataTextField = "mc";
            ddlt_zzmm.DataValueField = "bm";
            ddlt_zzmm.DataSource = SysData.ZZMM().Copy();
            ddlt_zzmm.DataBind();
            ddlt_zzmm.Items.Insert(0, new ListItem("请选择", "-1"));

          

            //合同等级
            ddlt_htlx.DataTextField = "mc";
            ddlt_htlx.DataValueField = "bm";
            ddlt_htlx.DataSource = SysData.HTLX().Copy();
            ddlt_htlx.DataBind();
            ddlt_htlx.Items.Insert(0, new ListItem("请选择", "-1"));

            //合同关系
            ddlt_htgx.DataTextField = "mc";
            ddlt_htgx.DataValueField = "bm";
            ddlt_htgx.DataSource = SysData.HTGX().Copy();
            ddlt_htgx.DataBind();
            ddlt_htgx.Items.Insert(0, new ListItem("请选择", "-1"));

            //用工性质
            ddlt_ygxz.DataTextField = "mc";
            ddlt_ygxz.DataValueField = "bm";
            ddlt_ygxz.DataSource = SysData.HTQX().Copy();
            ddlt_ygxz.DataBind();
            ddlt_ygxz.Items.Insert(0, new ListItem("请选择", "-1"));


            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11",_usState.userID,"110102");

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


            ////数据所在部门
            //ddlt_sjssbm.DataSource = SysData.BM().Copy();
            //ddlt_sjssbm.DataTextField = "mc";
            //ddlt_sjssbm.DataValueField = "bm";
            //ddlt_sjssbm.DataBind();
            //ddlt_sjssbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        public void GW(string bm)
        {

            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_gw.DataSource = dt;
                ddlt_gw.DataBind();
                ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_gw.DataSource = SysData.GW(bm).Copy();
                ddlt_gw.DataTextField = "mc";
                ddlt_gw.DataValueField = "bm";
                ddlt_gw.DataBind();
                ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;

            //员工姓名
            string xm = tbx_xm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(xm))
            {

                lbl_xm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //身份证号
            string sfzh = tbx_sfzh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(sfzh))
            {

                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：身份证号不能为空！" + "</span>";
                flag = 1;
            }
            else if (sfzh.Length != 18)
            {
                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：身份证号必须为18位！" + "</span>";
                flag = 1;
            }
            else if ((!Regex.IsMatch(tbx_sfzh.Text, @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
            {
                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：请输入正确的身份证号码！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfzh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }



            //民族
            if (ddlt_mz.SelectedValue.Trim() == "-1")
            {

                lbl_mz.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //部门
            if (ddlt_bm.SelectedValue.Trim() == "-1")
            {

                lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //岗位
            if (ddlt_gw.SelectedValue.Trim() == "-1")
            {

                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //联系电话
            string lxdh = tbx_lxdh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(lxdh))
            {
                lbl_lxdh.Text = "<span style=\"color:#ff0000\">" + "错误：联系方式不能为空！" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(lxdh, @"^[1][3578]\d{9}$"))
                {
                    lbl_lxdh.Text = "<span style=\"color:#ff0000\">" + "错误：格式错误！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_lxdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //工作地
            if (ddlt_gzd.SelectedValue.Trim() == "-1")
            {

                lbl_gzd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            string jg = tbx_jg.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jg))
            {

                lbl_jg.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //毕业院校
            //lbl_byyx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //专业
            string zy = tbx_zy.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zy))
            {
                lbl_zy.Text = "<span style=\"color:#ff0000\">" + "错误：专业不能为空！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //学历
            if (ddlt_xl.SelectedValue.Trim() == "-1")
            {

                lbl_xl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //毕业时间
            //lbl_bysj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            string sj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            if (!Regex.IsMatch(tbx_bysj.Text.ToString(), sj))
            {
                lbl_rzsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                flag = 1;
            }
        
            else
            {
                    lbl_bysj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //入职时间
            //lbl_rzsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            if (tbx_rzsj.Text == "")
            {
                lbl_rzsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }

            else
            {
                if (!Regex.IsMatch(tbx_rzsj.Text.ToString(), sj))
                {
                    lbl_rzsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_rzsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }

            //政治面貌
            if (ddlt_zzmm.SelectedValue.Trim() == "-1")
            {

                lbl_zzmm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zzmm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }


            //判断照片的格式
            string type = this.ImageUpload.PostedFile.ContentType;
            if (String.Compare(type, "image/jpg", true) == 0 || String.Compare(type, "image/png", true) == 0 || String.Compare(type, "image/jpeg", true) == 0)
            {
                lbl_sc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            else
            {
                lbl_sc.Text = "<span style=\"color:#ff0000\">" + "照片格式错误！<支持格式为：jpg/png/jpeg>" + "</span>";
                flag = 1;
            }



            //合同关系
            if (ddlt_htgx.SelectedValue.Trim() == "-1")
            {

                lbl_htgx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_htgx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //合同类型
            if (ddlt_htlx.SelectedValue.Trim() == "-1")
            {

                lbl_htlx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_htlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            ////数据所在部门
            //if (ddlt_sjssbm.SelectedValue.Trim() == "-1")
            //{

            //    lbl_sjssbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sjssbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
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
            if (flag!= 1)
            {
                if (tbx_sfzh.Text.Length == 18)
                {
                    lbl_csrq.Text = string.Format("{0:yyyy-MM-dd}", tbx_sfzh.Text.Substring(6, 8)); //出生日期
                    int show_xb = Convert.ToInt32(tbx_sfzh.Text.Substring(16, 1));//性别
                    if (show_xb % 2 == 0)
                    {
                        //偶数
                        lbl_xb.Text = "女";//女
                    }
                    else
                    { //奇数
                        lbl_xb.Text = "男";//男
                    }
                }
                //return;
            }

            if (flag == 1) { return; }
            #endregion

            struct_yg.p_xm = tbx_xm.Text;
            struct_yg.p_sfzh = tbx_sfzh.Text;
            //ToShortDateString().ToString();
            struct_yg.p_csrq = DateTime.ParseExact(struct_yg.p_sfzh.Substring(6, 8),"yyyyMMdd",null) ;
            int xb =Convert.ToInt32( struct_yg.p_sfzh.Substring(16, 1));
            if (xb % 2 == 0)
            {
                //偶数
                struct_yg.p_xbdm = "2";//女
            }
            else
            { //奇数
                struct_yg.p_xbdm = "1";//男
            }  
            struct_yg.p_mzdm = ddlt_mz.SelectedValue.ToString();
            struct_yg.p_lxdh = tbx_lxdh.Text;
            struct_yg.p_gwdm = ddlt_gw.SelectedValue.ToString();
            struct_yg.p_bmdm = ddlt_bm.SelectedValue.ToString();
            struct_yg.p_gzddm = ddlt_gzd.SelectedValue.ToString();
            struct_yg.p_xxdz = tbx_xxdz.Text;
            struct_yg.p_jg = tbx_jg.Text;
            struct_yg.p_byyx = tbx_byyx.Text;
            struct_yg.p_zy = tbx_zy.Text;
            struct_yg.p_xldm = ddlt_xl.SelectedValue.ToString();
            struct_yg.p_bysj = tbx_bysj.Text;
            struct_yg.p_rzsj = tbx_rzsj.Text;
            struct_yg.p_zzmmdm = ddlt_zzmm.SelectedValue.ToString();
           
            struct_yg.p_htgx = ddlt_htgx.SelectedValue;
            struct_yg.p_htlxdm = ddlt_htlx.SelectedValue.ToString();

            struct_yg.p_ygxz = ddlt_ygxz.SelectedValue.ToString();

            struct_yg.p_bz = tbx_bz.Text;
            struct_yg.p_rznf = struct_yg.p_rzsj.Substring(0,4);//入职年份
            struct_yg.p_bh = struct_yg.p_rznf+ struct_yg.p_xbdm+yg.SelectYGMaxBH(struct_yg.p_rzsj);

            struct_yg.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_yg.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_yg.p_sjssbm = "";//数据所在部门
            struct_yg.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_yg.p_sjbs = "0";
            struct_yg.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳

            SC(struct_yg.p_bh);
            struct_yg.p_zplj = HF_lj.Value;

            #region 审批人添加数据
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_yg.p_lrr.Equals(struct_yg.p_csr))
            {
                struct_yg.p_sjbs = "0";
                struct_yg.p_zt = "2";
                //给终审人添加提示
                SysData.Insert_TSR(struct_yg.p_zsr, "11", "1101", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_yg.p_lrr.Equals(struct_yg.p_zsr))
            {
                struct_yg.p_sjbs = "1";
                struct_yg.p_zt = "3";
            }
            if (!struct_yg.p_lrr.Equals(struct_yg.p_csr) && !struct_yg.p_lrr.Equals(struct_yg.p_zsr))
            {
                struct_yg.p_sjbs = "0";
                struct_yg.p_zt = "0";
                ////给终审人添加提示
                //SysData.Insert_TSR(struct_yg.p_zsr, "11", "1101", -1);
                ////给初审人添加提示
                //SysData.Insert_TSR(struct_yg.p_csr, "11", "1101", -1);
            }
            #endregion
            struct_yg.p_czfs = "01";
            struct_yg.p_czxx = "位置：员工管理->资质管理->添加    描述：员工编号："+ struct_yg.p_bh+"员工姓名："+ struct_yg.p_xm
                +"员工性别："+ struct_yg.p_xbdm+"身份证号："+ struct_yg .p_sfzh+"出生日期："+ struct_yg.p_csrq+"民族："+ struct_yg .p_mzdm
                +"部门："+struct_yg .p_bmdm+"岗位："+ struct_yg .p_gwdm+"联系电话："+ struct_yg .p_lxdh+"工作地："+ struct_yg.p_gzddm
                +"详细地址："+ struct_yg.p_xxdz+"籍贯："+ struct_yg.p_jg+"毕业院校："+ struct_yg.p_byyx+"专业："+ struct_yg.p_zy+"学历："+ struct_yg.p_xldm+"毕业时间："+ struct_yg.p_bysj
                +"入职时间："+ struct_yg.p_rzsj+"政治面貌："+ struct_yg.p_zzmmdm +"合同关系："+ struct_yg.p_htgx+"合同类型："+ struct_yg.p_htlxdm+"用工性质："+struct_yg.p_ygxz +"照片路径："+ struct_yg.p_zplj+ "备注：" + struct_yg.p_bz;
            yg.Insert_YG(struct_yg);
            Response.Write("<script>alert('添加成功！')</script>");
            Response.Redirect("YGGL.aspx", true);
            tbx_bysj.Text = "";
            tbx_byyx.Text = "";
            tbx_bz.Text = "";
            ddlt_htgx.SelectedValue = "-1";
            tbx_jg.Text = "";
            tbx_lxdh.Text = "";
           
            tbx_rzsj.Text = "";
            tbx_sfzh.Text = "";
            tbx_xm.Text = "";
            tbx_xxdz.Text = "";
            tbx_zy.Text = "";
            ddlt_bm.SelectedValue = "-1";
            ddlt_gw.SelectedValue = "-1";
            ddlt_gzd.SelectedValue = "-1";
            ddlt_htlx.SelectedValue = "-1";

            ddlt_ygxz.SelectedValue = "-1";

            ddlt_mz.SelectedValue = "-1";
            ddlt_xl.SelectedValue = "-1";
            ddlt_zzmm.SelectedValue = "-1";
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
            Response.Redirect("YGGL.aspx", true);
        }

        protected void ddlt_bm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue;
            GW(bm);
            if (bm == "-1")
            {
                lbl_bm.Visible = true;
                lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                
              
                if (ddlt_gw.SelectedValue == "-1")
                {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                   
                }
                else
                {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                   
                }
            }
            else
            {
                lbl_bm.Visible = true;
                lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                if (ddlt_gw.SelectedValue == "-1")
                {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                   
                }
                else {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                   
                }
            }
        }

        protected void ddlt_gw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlt_gw.SelectedValue == "-1")
            {
                lbl_gw.Visible = true;
                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
               
                if (ddlt_bm.SelectedValue == "-1")
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                  
                }
                else
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    
                }
            }
            else
            {
                lbl_gw.Visible = true;
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
               
                if (ddlt_bm.SelectedValue == "-1")
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    
                }
                else
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                   
                }
            }
        }
        public void SC(string ygbh)
        {
            
            if (ImageUpload.FileName.ToString() != "")
            {
                if (this.ImageUpload.PostedFile.ContentLength < 20971520)
                {
                    string type = this.ImageUpload.PostedFile.ContentType;
                    if (String.Compare(type, "image/jpg", true) == 0 || String.Compare(type, "image/png", true) == 0 || String.Compare(type, "image/jpeg", true) == 0)
                    {
                        string exeFileString = System.IO.Path.GetExtension(this.ImageUpload.PostedFile.FileName);//获取后缀
                        string saveFileName = ygbh + exeFileString;
                        string savePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\YuanGong\\Temp\\" + ygbh + "\\";
                        if (!System.IO.Directory.Exists(savePath))
                        {
                            System.IO.Directory.CreateDirectory(savePath);
                        }
                        string imagePath = savePath + saveFileName;
                        this.ImageUpload.PostedFile.SaveAs(imagePath);

                        HF_lj.Value = imagePath;
                       // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"上传成功！\")</script>");
                       // img_ygzp.ImageUrl = urlconvertor(imagePath);

                        //刷新后出生日期丢失
                        if (tbx_sfzh.Text.Length == 18)
                        {
                            lbl_csrq.Text = string.Format("{0:yyyy-MM-dd}", tbx_sfzh.Text.Substring(6, 8)); //出生日期
                            int show_xb = Convert.ToInt32(tbx_sfzh.Text.Substring(16, 1));//性别
                            if (show_xb % 2 == 0)
                            {
                                //偶数
                                lbl_xb.Text = "女";//女
                            }
                            else
                            { //奇数
                                lbl_xb.Text = "男";//男
                            }
                        }

                    }
                    else
                    {
                        lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误：图片格式应为JPG或者PNG！" + "</span>";
                    }
                 }
                else
                {
                    lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误：图片大小在2M之内！" + "</span>";
                }
            }
            else
            {
                lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误：请选择要上传的图片！" + "</span>";
            }
        }
        
        //转换路径
        private string urlconvertor(string imagesurl)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl_xd = imagesurl.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl_xd = imagesurl_xd.Replace(@"\", @"/");
            return imagesurl_xd;
        }

        protected void tbx_sfzh_TextChanged(object sender, EventArgs e)
        {
            //身份证号
            int flag = 0;
            string sfzh = tbx_sfzh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(sfzh))
            {

                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：身份证号不能为空！" + "</span>";
                flag = 1;
            }
            else if (sfzh.Length != 18)
            {
                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：身份证号必须为18位！" + "</span>";
                flag = 1;
            }
            else if ((!Regex.IsMatch(tbx_sfzh.Text, @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
            {
                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：请输入正确的身份证号码！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfzh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            struct_yg.p_sfzh = tbx_sfzh.Text;
            //ToShortDateString().ToString();
            IFormatProvider ifp = new CultureInfo("zh-CN", true);
            string year = struct_yg.p_sfzh.Substring(6, 4);
            string month= struct_yg.p_sfzh.Substring(10, 2);
            string day= struct_yg.p_sfzh.Substring(12, 2);
            lbl_csrq.Text = year + "/" + month + "/" + day;
            int xb = Convert.ToInt32(struct_yg.p_sfzh.Substring(16, 1));
            if (xb % 2 == 0)
            {
                //偶数
                lbl_xb.Text = SysData.XBByKey("2").mc;//女
            }
            else
            { //奇数
                lbl_xb.Text = SysData.XBByKey("1").mc;//男
            }
        }
    }
}