using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CUST.MKG;
using CUST.Sys;
using System.IO;
using System.Data;
using Sys;

namespace CUST.WKG
{
    public partial class QXSB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private QXSB qxsb;
        private Struct_QXSB struct_qxsb;
        private Utils utils;
        public int flag = 0;
        public int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            qxsb = new QXSB(_usState);
            struct_qxsb = new Struct_QXSB();
            utils = new Utils();
            if (!IsPostBack)
            {
                tbx_tcrq.Attributes.Add("readonly", "readonly");
                tbx_jgrq.Attributes.Add("readonly", "readonly");
                tbx_qysj.Attributes.Add("readonly", "readonly");
                tbx_jdrq.Attributes.Add("readonly", "readonly");
                tbx_fljcrq.Attributes.Add("readonly", "readonly");
                tbx_jdyxq.Attributes.Add("readonly", "readonly");
                tbx_fljcyxq.Attributes.Add("readonly", "readonly");


                ddltBind();
                yg_bind();

                string sjjd = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo);
                int lss = Convert.ToInt32(qxsb.Select_SB_MaxNumber(sjjd));
                if (lss >= 99999)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"数据超出，请联系管理员整理数据！\")</script>");
                    Response.Redirect("../SheBei/TXSB_GL.aspx");
                }
                tbx_sbbh.Text = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo) + "03" + Convert.ToString(lss + 1).PadLeft(5, '0');
            }
        }

       
        private void yg_bind()
        {

        }
        private void ddltBind()
        {
            //台站名称种类 台站名称
            ddlt_tzmczl.DataTextField = "mc";
            ddlt_tzmczl.DataValueField = "bm";
            ddlt_tzmczl.DataSource = SysData.TZLX_ZH("03").Copy();
            ddlt_tzmczl.DataBind();
            ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

            //运行情况
            ddlt_yxqk.DataTextField = "mc";
            ddlt_yxqk.DataValueField = "bm";
            ddlt_yxqk.DataSource = SysData.YXQK().Copy();
            ddlt_yxqk.DataBind();
            ddlt_yxqk.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备状态 
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataSource = SysData.SBZT().Copy();
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备用途
            ddlt_sbyt.DataTextField = "mc";
            ddlt_sbyt.DataValueField = "bm";
            ddlt_sbyt.DataSource = SysData.SBYT().Copy();
            ddlt_sbyt.DataBind();
            ddlt_sbyt.Items.Insert(0, new ListItem("请选择", "-1"));
            //绑定所属支线 
            ddlt_sszx.DataTextField = "mc";
            ddlt_sszx.DataValueField = "bm";
            ddlt_sszx.DataSource = SysData.ZXDM().Copy();
            ddlt_sszx.DataBind();
            ddlt_sszx.Items.Insert(0, new ListItem("请选择", "-1"));
            //检定方式 
            ddlt_jdfs.DataTextField = "mc";
            ddlt_jdfs.DataValueField = "bm";
            ddlt_jdfs.DataSource = SysData.JDFS().Copy();
            ddlt_jdfs.DataBind();
            ddlt_jdfs.Items.Insert(0, new ListItem("请选择", "-1"));
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14" ,_usState.userID, "140302");

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
            ddlt_sjszbm.DataSource = SysData.BM("140302", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private string MakeFileName(string biaoshi, string exeFileString)
        {
            System.DateTime now = System.DateTime.Now;
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string p_sbbh = tbx_sbbh.Text.ToString();
            string p_sbmc = tbx_sbmc.Text.ToString();
            string p_xh = tbx_xh.Text.ToString();
            string p_zzcj = tbx_zzcj.Text.ToString();
            string p_ccbh = tbx_ccbh.Text.ToString();
            string p_tcrq = tbx_tcrq.Text.ToString();
            string p_jgrq = tbx_jgrq.Text.ToString();
            string p_qysj = tbx_qysj.Text.ToString();
            string p_yxqk = ddlt_yxqk.SelectedValue.ToString();
            string p_sbzt = ddlt_sbzt.SelectedValue.ToString();
            string p_sbyt = ddlt_sbyt.SelectedValue.ToString();
            string p_sszx = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
            string p_azwz = tbx_azwz.Text.ToString();
            string p_jdrq = tbx_jdrq.Text.ToString();
            string p_jdyxq = tbx_jdyxq.Text.ToString();
            string p_jdzsbh = tbx_jdzsbh.Text.ToString();
            string p_jdys = tbx_jdys.Text.ToString();
            string p_jdfs = ddlt_jdfs.SelectedValue.ToString();
            string p_jddw = tbx_jddw.Text.ToString();
            string p_jdjl = tbx_jdjl.Text.ToString();
            string p_fljcrq = tbx_fljcrq.Text.ToString();
            string p_fljcyxq = tbx_fljcyxq.Text.ToString();
            string p_dzscz = tbx_dzscz.Text.ToString();
            string p_sbgzll = tbx_sbgzll.Text.ToString();
            string p_bz = tbx_bz.Text.ToString();
            #region 上传  上传传感器检定证书
            string SaveFileName = "";
            if (tbx_sccgqjdzs.HasFile)
            {
                string FileName = this.tbx_sccgqjdzs.FileName;//获取上传文件的文件名,包括后缀
                string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                string filepath = "UpLoads/SBGL/QXSB/" + struct_qxsb.p_id + "/";
                string fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                string saveFileName = this.MakeFileName("CG", FileName);
                SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径
                if (!Directory.Exists(fpath))
                    Directory.CreateDirectory(fpath);
                tbx_sccgqjdzs.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
            }
            if (File.Exists(SaveFileName))
            {
                struct_qxsb.p_sccgqjdzs = SaveFileName;
                struct_qxsb.p_scsj = DateTime.Now;
            }
            else
            {
                struct_qxsb.p_sccgqjdzs = "";
                flag = 1;
                lbl_sccgqjdzs.Text = "<span style=\"color:#ff0000\">" + "请选择文件" + "</span>";
                struct_qxsb.p_scsj = DateTime.Now;

            }
            #endregion
            #region 判断

            if (ddlt_tzmczl.SelectedValue == "-1")
            {

                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + "错误：请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tzmczl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (p_sszx == "-1")
            {

                lbl_sszx.Text = "<span style=\"color:#ff0000\">" + "错误：请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sszx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (p_yxqk  == "-1")
            {

                lbl_yxqk.Text = "<span style=\"color:#ff0000\">" + "错误：请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yxqk.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (p_sbyt == "-1")
            {

                lbl_sbyt.Text = "<span style=\"color:#ff0000\">" + "错误：请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbyt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (p_sbzt == "-1")
            {

                lbl_sbzt.Text = "<span style=\"color:#ff0000\">" + "错误：请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbzt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (p_jdfs == "-1")
            {

                lbl_jdfs.Text = "<span style=\"color:#ff0000\">" + "错误：请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jdfs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_sbmc))
            {

                lbl_sbmc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }



            if (string.IsNullOrEmpty(p_xh))
            {

                lbl_xh.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            if (string.IsNullOrEmpty(p_zzcj))
            {

                lbl_zzcj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zzcj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            if (string.IsNullOrEmpty(p_ccbh))
            {

                lbl_ccbh.Text = "<span style=\"color:#ff0000\">" + "错误：投产日期不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ccbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            if (string.IsNullOrEmpty(p_tcrq))
            {

                lbl_tcrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tcrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            if (string.IsNullOrEmpty(p_jgrq))
            {

                lbl_jgrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jgrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_qysj))
            {

                lbl_qysj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_qysj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(p_azwz))
            {

                lbl_azwz.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_azwz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_jdrq))
            {

                lbl_jdrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jdrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_jdyxq))
            {

                lbl_jdyxq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jdyxq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_jdzsbh))
            {

                lbl_jdzsbh.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jdzsbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_jdys))
            {

                lbl_jdys.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jdys.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_jddw))
            {

                lbl_jddw.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jddw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(p_jdjl))
            {

                lbl_jdjl.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jdjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(p_fljcrq))
            {

                lbl_fljcrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fljcrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(p_fljcyxq))
            {

                lbl_fljcyxq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fljcyxq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(p_dzscz))
            {

                lbl_dzscz.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dzscz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(p_sbgzll))
            {

                lbl_sbgzll.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbgzll.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
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
                struct_qxsb.p_sbmc = p_sbmc;
                struct_qxsb.p_xh = p_xh;
                struct_qxsb.p_zzcj = p_zzcj;
                struct_qxsb.p_ccbh = p_ccbh;
                struct_qxsb.p_tcrq = p_tcrq;
                struct_qxsb.p_jgrq = p_jgrq;
                struct_qxsb.p_qysj = p_qysj;
                struct_qxsb.p_yxqk = p_yxqk;
                struct_qxsb.p_sbzt = p_sbzt;
                struct_qxsb.p_sbyt = p_sbyt;
                struct_qxsb.p_sszx = p_sszx;
                struct_qxsb.p_azwz = p_azwz;
                struct_qxsb.p_jdrq = p_jdrq;
                struct_qxsb.p_jdyxq = p_jdyxq;
                struct_qxsb.p_jdzsbh = p_jdzsbh;
                struct_qxsb.p_jdys = p_jdys;
                struct_qxsb.p_jdfs = p_jdfs;
                struct_qxsb.p_jddw = p_jddw;
                struct_qxsb.p_jdjl = p_jdjl;
                struct_qxsb.p_fljcrq = p_fljcrq;
                struct_qxsb.p_fljcyxq = p_fljcyxq;
                struct_qxsb.p_dzscz = p_dzscz;
                struct_qxsb.p_sbgzll = p_sbgzll;
                struct_qxsb.p_bz = p_bz;
                struct_qxsb.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                struct_qxsb.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                struct_qxsb.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                struct_qxsb.p_lrr = _usState.userLoginName.ToString();//录入人

                struct_qxsb.p_wz=ddlt_tzmczl.SelectedValue.ToString().Substring(2, 2);
                struct_qxsb.p_sblx= ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);

                struct_qxsb.p_czfs = "01";
                struct_qxsb.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
                //路径
                // struct_qxsb.p_wxdsbfshzzj = toPath;
                struct_qxsb.p_czfs = "01";
                struct_qxsb.p_czxx = "位置：设备管理->气象设备->添加 设备名称：" + struct_qxsb.p_sbmc + " 设备型号/规格：" + struct_qxsb.p_xh + "制造厂家"+ struct_qxsb.p_zzcj + "制造厂家" + struct_qxsb.p_zzcj + 
                    "制造厂家" + struct_qxsb.p_zzcj + "出厂编号" + struct_qxsb.p_ccbh + "投产日期" + struct_qxsb.p_tcrq + " 竣工日期：" + struct_qxsb.p_jgrq + "启用时间"+ struct_qxsb.p_qysj + "运行情况" + struct_qxsb.p_yxqk + 
                    "设备状态" + struct_qxsb.p_sbzt + "设备用途" + struct_qxsb.p_sbyt + " 所属支线：" + struct_qxsb.p_sszx + " 安装位置：" + struct_qxsb.p_azwz + " 检定日期：" + struct_qxsb.p_jdrq +
                    "检定有效期 ：" + struct_qxsb.p_jdyxq + " 检定证书编号：" + struct_qxsb.p_jdzsbh + "上传传感器检定证书编号：" + struct_qxsb.p_sccgqjdzs + " 检定预算：" + struct_qxsb.p_jdys + 
                    "检定方式：" + struct_qxsb.p_jdfs + "检定单位" + struct_qxsb.p_jddw + " 检定结论：" + struct_qxsb.p_jdjl + "防雷检测日期：" + struct_qxsb.p_fljcrq + " 防雷检测有效期：" + struct_qxsb.p_fljcyxq +
                    " 电阻实测值：" + struct_qxsb.p_dzscz + " 设备故障履历：" + struct_qxsb.p_sbgzll + " 备注：" + struct_qxsb.p_bz;
                //如果是初审人录入数据，则状态默认初审通过，即待终审
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr))
                {
                    struct_qxsb.p_sjbs = "0";
                    struct_qxsb.p_zt = "2";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_qxsb.p_zsr, "14", "1403", -1);
                }
                //如果是终审人录入数据，则状态为审核通过
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    struct_qxsb.p_sjbs = "1";
                    struct_qxsb.p_zt = "3";
                }
                if (!struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr) && !struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    struct_qxsb.p_sjbs = "0";
                    struct_qxsb.p_zt = "0";
                }
                qxsb.Insert_QXSB(struct_qxsb);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
            #endregion
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/QXSB_GL.aspx");
        }
        protected void ddlt_sblx_change(object sender, EventArgs e)
        {
            ddlt_sszx.SelectedValue = ddlt_tzmczl.SelectedValue.ToString().Substring(0, 2);
           
        }
        protected void ddlt_jc_change(object sender, EventArgs e)
        {
            if (ddlt_sszx.SelectedValue != "-1")
            {
                DataTable dt = SysData.TZLX_ZH(ddlt_sszx.SelectedValue, "03");
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
                else if (ddlt_sszx.SelectedValue == "-1")
                {
                    //台站名称种类 台站名称
                    ddlt_tzmczl.DataTextField = "mc";
                    ddlt_tzmczl.DataValueField = "bm";
                    ddlt_tzmczl.DataSource = SysData.TZLX_ZH("03").Copy();
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
                DataTable dt = SysData.TZLX_ZH("03");
                //台站名称种类 台站名称
                ddlt_tzmczl.DataTextField = "mc";
                ddlt_tzmczl.DataValueField = "bm";
                ddlt_tzmczl.DataSource = dt.Copy();
                ddlt_tzmczl.DataBind();
                ddlt_tzmczl.Items.Insert(0, new ListItem("全部", "-1"));

                lbl_tzmczl.Text = "<span style=\"color:#ff0000\">" + " " + "</span>";
            }
        }
        //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "down")
        //    {
        //        try
        //        {
        //            string path = e.CommandArgument.ToString();//路径

        //            string fileName = Path.GetFileName(path); //文件名

        //            if (File.Exists(path))
        //            {
        //                FileInfo fileInfo = new FileInfo(path);
        //                Response.Clear();
        //                Response.ClearContent();
        //                Response.ClearHeaders();
        //                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        //                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        //                Response.AddHeader("Content-Transfer-Encoding", "binary");
        //                Response.ContentType = "application/octet-stream";
        //                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        //                Response.WriteFile(fileInfo.FullName);
        //                Response.Flush();
        //                Response.End();
        //            }
        //            else
        //            {
        //                //Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
        //                //Response.Redirect("../main/TXSB_GL.aspx");
        //                //Response.End();
        //                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"文件不存在！\")</script>");
        //                return;
        //            }
        //        }
        //        catch { }

        //    }
    }
    }
