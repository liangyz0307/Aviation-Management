using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using CUST.Sys;
using System.Data;
using System.IO;
using Sys;

namespace CUST.WKG
{
    public partial class QXSB_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private QXSB qxsb;
        private Struct_QXSB struct_qxsb;
        private string id;
        private string sjc;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}

            qxsb = new QXSB(_usState);
            struct_qxsb = new Struct_QXSB();
           // string id = struct_qxsb.p_id;
            if (!IsPostBack)
            {
                tbx_tcrq.Attributes.Add("readonly", "readonly");
                tbx_jgrq.Attributes.Add("readonly", "readonly");
                tbx_qysj.Attributes.Add("readonly", "readonly");
                tbx_jdrq.Attributes.Add("readonly", "readonly");
                tbx_fljcrq.Attributes.Add("readonly", "readonly");
                tbx_jdyxq.Attributes.Add("readonly", "readonly");
                tbx_fljcyxq.Attributes.Add("readonly", "readonly");
                 id = Request.Params["id"].ToString();
                sjc = Request.Params["sjc"].ToString();
                bind_rep();
                ddltBind();
                select_detail();

            }
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
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140303");

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
            ddlt_sjszbm.DataSource = SysData.BM("140303", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        private void select_detail()
        {
            id = Request.Params["id"].ToString();
            DataTable dt_detail = qxsb.Select_QXSBbySBBH(id).Tables[0];
            tbx_sbbh.Text = dt_detail.Rows[0]["sbbh"].ToString();
            tbx_sbmc.Text = dt_detail.Rows[0]["sbmc"].ToString();
            tbx_xh.Text = dt_detail.Rows[0]["xh"].ToString();
            tbx_zzcj.Text = dt_detail.Rows[0]["zzcj"].ToString();
            tbx_ccbh.Text = dt_detail.Rows[0]["ccbh"].ToString();
            tbx_tcrq.Text = dt_detail.Rows[0]["tcrq"].ToString();
            tbx_jgrq.Text = dt_detail.Rows[0]["jgrq"].ToString();
            tbx_qysj.Text = dt_detail.Rows[0]["qysj"].ToString();
            ddlt_yxqk.SelectedValue = dt_detail.Rows[0]["yxqk"].ToString();
            ddlt_sbzt.SelectedValue = dt_detail.Rows[0]["sbzt"].ToString();
            ddlt_sbyt.SelectedValue = dt_detail.Rows[0]["sbyt"].ToString();
            ddlt_sszx.SelectedValue = dt_detail.Rows[0]["sszx"].ToString();
            tbx_azwz.Text = dt_detail.Rows[0]["azwz"].ToString();
            tbx_jdrq.Text = dt_detail.Rows[0]["jdrq"].ToString();
            tbx_jdyxq.Text = dt_detail.Rows[0]["jdyxq"].ToString();
            tbx_jdzsbh.Text = dt_detail.Rows[0]["jdzsbh"].ToString();
            tbx_jdys.Text = dt_detail.Rows[0]["jdys"].ToString();
            ddlt_jdfs.SelectedValue = dt_detail.Rows[0]["jdfs"].ToString();
            tbx_jddw.Text = dt_detail.Rows[0]["jddw"].ToString();
            tbx_jdjl.Text = dt_detail.Rows[0]["jdjl"].ToString();
            tbx_fljcrq.Text = dt_detail.Rows[0]["fljcrq"].ToString();
            tbx_fljcyxq.Text = dt_detail.Rows[0]["fljcyxq"].ToString();
            tbx_dzscz.Text = dt_detail.Rows[0]["dzscz"].ToString();
            tbx_sbgzll.Text = dt_detail.Rows[0]["sbgzll"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门

            ddlt_tzmczl.SelectedValue = dt_detail.Rows[0]["sszx"].ToString() + dt_detail.Rows[0]["wz"].ToString() + dt_detail.Rows[0]["sblx"].ToString();

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
            #region 赋值
            int flag = 0;
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
            //  string sbzl=ddlt_sbzl.
            #endregion
            #region 上传
            //上传  上传传感器检定证书
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
                //  struct_qxsb.p_scsj = DateTime.Now;
            }
            else
            {

                id = Request.Params["id"].ToString();
                DataTable dt_detail = qxsb.Select_QXSBbySBBH(id).Tables[0];
                struct_qxsb.p_sccgqjdzs = dt_detail.Rows[0]["sccgqjdzs"].ToString();
                //struct_qxsb.p_scsj = Convert.ToDateTime(dt_detail.Rows[0]["scsj"].ToString());

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

            if (p_yxqk == "-1")
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
            //终审人
            if (struct_qxsb.p_sccgqjdzs=="")
            {

                lbl_sccgqjdzs.Text = "<span style=\"color:#ff0000\">" + "请选择文件" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sccgqjdzs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }


            if (flag == 1)
                return;
            #endregion
            //#region 上传
            ////上传  上传传感器检定证书
            //string SaveFileName = "";
            //if (tbx_sccgqjdzs.HasFile)
            //{

            //    string FileName = this.tbx_sccgqjdzs.FileName;//获取上传文件的文件名,包括后缀

            //    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
            //    string filepath = "UpLoads/SBGL/QXSB/" + struct_qxsb.p_id + "/";
            //    string fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
            //    string saveFileName = this.MakeFileName("CG", FileName);
            //    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径

            //    if (!Directory.Exists(fpath))
            //        Directory.CreateDirectory(fpath);

            //    tbx_sccgqjdzs.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
            //}

            //if (File.Exists(SaveFileName))
            //{
            //    struct_qxsb.p_sccgqjdzs = SaveFileName;
            //  //  struct_qxsb.p_scsj = DateTime.Now;
            //}
            //else
            //{

            //    id = Request.Params["id"].ToString();
            //    DataTable dt_detail = qxsb.Select_QXSBbySBBH(id).Tables[0];
            //    struct_qxsb.p_sccgqjdzs = dt_detail.Rows[0]["sccgqjdzs"].ToString();
            //    //struct_qxsb.p_scsj = Convert.ToDateTime(dt_detail.Rows[0]["scsj"].ToString());

            //}
            //#endregion


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
                struct_qxsb.p_czfs = "02";

                struct_qxsb.p_wz = ddlt_tzmczl.SelectedValue.ToString().Substring(2, 2);
                struct_qxsb.p_sblx = ddlt_tzmczl.SelectedValue.ToString().Substring(4, 4);

                struct_qxsb.p_id = Request.Params["id"].ToString();
                DataTable dt_detail = qxsb.Select_QXSBbySBBH(id).Tables[0];
                DataRow dt_row = dt_detail.Rows[0];
                struct_qxsb.p_czxx = "位置：设备管理->气象设备->编辑  [设备编号：" + struct_qxsb.p_id + "描述：";

                if (struct_qxsb.p_sbmc != dt_row["sbmc"].ToString())
                {
                    struct_qxsb.p_czxx += "设备名称：【" + SysData.SBZLByKey(dt_row["sbmc"].ToString()).ms + "】->【" + struct_qxsb.p_sbmc + "】";
                }
                if (struct_qxsb.p_xh != dt_row["xh"].ToString())
                {
                    struct_qxsb.p_czxx += "型号/规格：【" + SysData.SBZLByKey(dt_row["xh"].ToString()).ms + "】->【" + struct_qxsb.p_xh + "】";
                }
                if (struct_qxsb.p_zzcj != dt_row["zzcj"].ToString())
                {
                    struct_qxsb.p_czxx += "制造厂家：【" + SysData.SBZLByKey(dt_row["zzcj"].ToString()).ms + "】->【" + struct_qxsb.p_zzcj + "】";
                }
                if (struct_qxsb.p_ccbh != dt_row["ccbh"].ToString())
                {
                    struct_qxsb.p_czxx += "出厂编号：【" + SysData.SBZLByKey(dt_row["ccbh"].ToString()).ms + "】->【" + struct_qxsb.p_ccbh + "】";
                }
                if (struct_qxsb.p_tcrq != dt_row["tcrq"].ToString())
                {
                    struct_qxsb.p_czxx += "投产日期：【" + dt_row["tcrq"].ToString() + "】->【" + struct_qxsb.p_tcrq + "】";
                }
                if (struct_qxsb.p_jgrq != dt_row["jgrq"].ToString())
                {
                    struct_qxsb.p_czxx += "竣工日期：【" + dt_row["jgrq"].ToString() + "】->【" + struct_qxsb.p_jgrq + "】";
                }
                if (struct_qxsb.p_qysj != dt_row["qysj"].ToString())
                {
                    struct_qxsb.p_czxx += "启用时间：【" + SysData.SBZLByKey(dt_row["qysj"].ToString()).ms + "】->【" + struct_qxsb.p_qysj + "】";
                }
                if (struct_qxsb.p_yxqk != dt_row["yxqk"].ToString())
                {
                    struct_qxsb.p_czxx += "运行情况：【" + dt_row["yxqk"].ToString() + "】->【" + struct_qxsb.p_yxqk + "】";
                }
                if (struct_qxsb.p_sbzt != dt_row["sbzt"].ToString())
                {
                    struct_qxsb.p_czxx += "设备状态：【" + dt_row["sbzt"].ToString() + "】->【" + struct_qxsb.p_sbzt + "】";
                }
                if (struct_qxsb.p_sbyt != dt_row["sbyt"].ToString())
                {
                    struct_qxsb.p_czxx += "设备用途：【" + dt_row["sbyt"].ToString() + "】->【" + struct_qxsb.p_sbyt + "】";
                }
                if (struct_qxsb.p_sszx != dt_row["sszx"].ToString())
                {
                    struct_qxsb.p_czxx += "所属支线：【" + dt_row["sszx"].ToString() + "】->【" + struct_qxsb.p_sszx + "】";
                }
                if (struct_qxsb.p_azwz != dt_row["azwz"].ToString())
                {
                    struct_qxsb.p_czxx += "安装位置：【" + dt_row["azwz"].ToString() + "】->【" + struct_qxsb.p_azwz + "】";
                }
                if (struct_qxsb.p_jdrq != dt_row["jdrq"].ToString())
                {
                    struct_qxsb.p_czxx += "检定日期：【" + dt_row["jdrq"].ToString() + "】->【" + struct_qxsb.p_jdrq + "】";
                }
                if (struct_qxsb.p_jdyxq != dt_row["jdyxq"].ToString())
                {
                    struct_qxsb.p_czxx += "检定有效期：【" + dt_row["jdyxq"].ToString() + "】->【" + struct_qxsb.p_jdyxq + "】";
                }
                if (struct_qxsb.p_jdzsbh != dt_row["jdzsbh"].ToString())
                {
                    struct_qxsb.p_czxx += "检定证书编号：【" + dt_row["jdzxbh"].ToString() + "】->【" + struct_qxsb.p_jdzsbh + "】";
                }

                if (struct_qxsb.p_sccgqjdzs != dt_row["sccgqjdzs"].ToString())
                {
                    struct_qxsb.p_czxx += "数量：【" + dt_row["sccgqjdzs"].ToString() + "】->【" + struct_qxsb.p_sccgqjdzs + "】";
                }
                if (struct_qxsb.p_jdys != dt_row["jdys"].ToString())
                {
                    struct_qxsb.p_czxx += "检定预算：【" + SysData.TZLXByKey(dt_row["jdys"].ToString()) + "】->【" + struct_qxsb.p_jdys + "】";
                }
                if (struct_qxsb.p_jdfs != dt_row["jdfs"].ToString())
                {
                    struct_qxsb.p_czxx += "检定方式：【" + SysData.SBYTByKey(dt_row["jdfs"].ToString()).ms + "】->【" + struct_qxsb.p_jdfs + "】";
                }
                if (struct_qxsb.p_jddw != dt_row["jddw"].ToString())
                {
                    struct_qxsb.p_czxx += "检定单位：【" + SysData.SBZTByKey(dt_row["jddw"].ToString()).ms + "】->【" + struct_qxsb.p_jddw + "】";
                }
                if (struct_qxsb.p_jdjl != dt_row["jdjl"].ToString())
                {
                    struct_qxsb.p_czxx += "检定结论：【" + SysData.SBZTByKey(dt_row["jdjl"].ToString()).ms + "】->【" + struct_qxsb.p_jdjl + "】";
                }
                if (struct_qxsb.p_fljcrq != dt_row["fljcrq"].ToString())
                {
                    struct_qxsb.p_czxx += "防雷检测日期：【" + dt_row["fljcrq"].ToString() + "】->【" + struct_qxsb.p_fljcrq + "】";
                }
                if (struct_qxsb.p_fljcyxq != dt_row["fljcyxq"].ToString())
                {
                    struct_qxsb.p_czxx += "防雷检测有效期：【" + dt_row["fljcyxq"].ToString() + "】->【" + struct_qxsb.p_fljcyxq + "】";
                }
                if (struct_qxsb.p_dzscz != dt_row["dzscz"].ToString())
                {
                    struct_qxsb.p_czxx += "电阻实测值：【" + dt_row["dzscz"].ToString() + "】->【" + struct_qxsb.p_dzscz + "】";
                }
                if (struct_qxsb.p_sbgzll != dt_row["sbgzll"].ToString())
                {
                    struct_qxsb.p_czxx += "设备故障履历：【" + dt_row["sbgzll"].ToString() + "】->【" + struct_qxsb.p_sbgzll + "】";
                }
                if (struct_qxsb.p_bz != dt_row["bz"].ToString())
                {
                    struct_qxsb.p_czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_qxsb.p_bz + "】";
                }

                
            string sjbs = Request.Params["sjbs"].ToString();

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr))
                {
                    struct_qxsb.p_zt = "2";
                    struct_qxsb.p_sjbs = "0";
                    SysData.Insert_TSR(struct_qxsb.p_zsr, "14", "1406", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    struct_qxsb.p_zt = "3";
                    struct_qxsb.p_sjbs = "1";
                    SysData.Delete_TSR(struct_qxsb.p_zsr, "14", "1406", Convert.ToInt32(id));
                }
                if (!struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr) && !struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    struct_qxsb.p_zt = "0";
                    struct_qxsb.p_sjbs = "0";
                }
                qxsb.Update_QXSB(struct_qxsb);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("../SheBei/QXSB_GL.aspx");
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr))
                {
                    struct_qxsb.p_zt = "2";
                    struct_qxsb.p_sjbs = "2";
                    SysData.Insert_TSR(struct_qxsb.p_zsr, "14", "1406", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_qxsb.p_sjc = sjc;
                    qxsb.Update_QXSB_SJBS_LSSJ_ZT(struct_qxsb);

                    struct_qxsb.p_zt = "3";
                    struct_qxsb.p_sjbs = "1";
                    SysData.Delete_TSR(struct_qxsb.p_zsr, "14", "1406", Convert.ToInt32(id));
                }
                if (!struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr) && !struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    struct_qxsb.p_zt = "0";
                    struct_qxsb.p_sjbs = "2";
                }
                qxsb.Update_QXSB(struct_qxsb);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("../SheBei/QXSB_GL.aspx");
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToString(Request.Params["id"].ToString());
                int id_bf = qxsb.QXSB_SJBF(Convert.ToInt32(id));
                struct_qxsb.p_id = Convert.ToString(id_bf);


                //初审人录入的数据，状态默认为待终审
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr))
                {
                    struct_qxsb.p_zt = "2";
                    struct_qxsb.p_sjbs = "2";
                    SysData.Insert_TSR(struct_qxsb.p_zsr, "14", "1406", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_qxsb.p_sjc = sjc;
                    qxsb.Update_QXSB_SJBS_LSSJ_ZT(struct_qxsb);

                    struct_qxsb.p_zt = "3";
                    struct_qxsb.p_sjbs = "1";
                    SysData.Delete_TSR(struct_qxsb.p_zsr, "14", "1406", Convert.ToInt32(id));
                }
                if (!struct_qxsb.p_lrr.Equals(struct_qxsb.p_csr) && !struct_qxsb.p_lrr.Equals(struct_qxsb.p_zsr))
                {
                    struct_qxsb.p_zt = "0";
                    struct_qxsb.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                qxsb.Update_QXSB(struct_qxsb);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("../SheBei/QXSB_GL.aspx");
            }














                bind_rep();
                Repeater1.Visible = true;


            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));

                return;
            }

        }


        private void bind_rep()
        {
            //string id = struct_qxsb.p_id.ToString();
            DataTable dt = qxsb.Select_QXSBbySBBH(id).Tables[0];
            string lujing = dt.Rows[0]["sccgqjdzs"].ToString();//证书路径
          //  DateTime scsj = Convert.ToDateTime(dt.Rows[0]["scsj"].ToString());//上传时间
            string filename = lujing.Substring(lujing.LastIndexOf("\\") + 1);
            if (filename == "")
                return;
            dt.Columns.Add("FileName");
           // dt.Columns.Add("scsj");
            dt.Rows[0]["FileName"] = filename.Substring(16);
            //dt.Rows[0]["scsj"] = string.Format("{0:yyyy-MM-dd}", scsj);
            if (lujing == "")
            {
                dt.Rows.Remove(dt.Rows[0]);
            }
            ////绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/QXSB_GL.aspx");
        }

        protected void tbx_jdzsbh_TextChanged(object sender, EventArgs e)
        {

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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "down")
            {
                try
                {
                    string path = e.CommandArgument.ToString();//路径

                    string fileName = Path.GetFileName(path); //文件名

                    if (File.Exists(path))
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
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
                        Response.End();
                        return;
                    }
                }
                catch { }

            }

        }
    }
}
