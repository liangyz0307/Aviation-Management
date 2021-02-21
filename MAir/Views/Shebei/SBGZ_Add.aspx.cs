using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Brettle.Web.NeatUpload;
using Sys;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CUST.WKG
{
    public partial class SBGZ_Add : System.Web.UI.Page
    {
        private UserState _usState;

        private WHWX whwx;
        private Struct_SBGZ struct_sbgz;
        private string saveFileName;
        private string SaveFileName;

        string sbbh_zz;//设备编号最终
        string sblx_zz;//设备类型最终
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

            whwx = new WHWX(_usState);
            struct_sbgz = new Struct_SBGZ();
            if (!IsPostBack)
            {
                tbx_gzqssj.Attributes.Add("readonly", "readonly");
                tbx_gzjssj.Attributes.Add("readonly", "readonly");
                ddltBind();
            }
        }

        private void ddltBind()
        { 
            //维护人部门
            ddlt_wxrbm.DataTextField = "mc";
            ddlt_wxrbm.DataValueField = "bm";
            ddlt_wxrbm.DataSource = SysData.BM().Copy();
            ddlt_wxrbm.DataBind();
            ddlt_wxrbm.Items.Insert(0, new ListItem("请选择", "-1"));

            //维护人岗位

            //DataTable dt_whrgw = new DataTable();
            //ddlt_wxrgw.DataSource = dt_whrgw;
            //ddlt_wxrgw.DataBind();
            //ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));


            ddlt_wxrgw.DataSource = SysData.GW().Copy();
            ddlt_wxrgw.DataTextField = "mc";
            ddlt_wxrgw.DataValueField = "bm";
            ddlt_wxrgw.DataBind();
            ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));



            //设备类型

            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX().Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备编号
            string sblx = ddlt_sblx.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = whwx.Select_SBDM(sblx);//text是设备代码 值则是该设备代码下的sblx 来满足选择设备代码时也能选取该设备类型
            ddlt_sbbh.DataSource = dt.Copy();
            ddlt_sbbh.DataTextField = "mc";
            ddlt_sbbh.DataValueField = "bm";
            ddlt_sbbh.DataBind();
            ddlt_sbbh.Items.Insert(0, new ListItem("请选择", "-1"));
            //设备种类

            ddlt_sbzl.DataTextField = "mc";
            ddlt_sbzl.DataValueField = "bm";
            ddlt_sbzl.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140802");

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
            ddlt_sjszbm.DataSource = SysData.BM("140802", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));


        }

        protected void ddlt_whrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_wxrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_wxrgw.DataSource = dt;
                ddlt_wxrgw.DataBind();
                ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_wxrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_wxrgw.DataTextField = "mc";
                ddlt_wxrgw.DataValueField = "bm";
                ddlt_wxrgw.DataBind();
                ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
           
           //   struct_sbgz.p_wxwjsc=wx  路径

            struct_sbgz.p_wxwjsc = "";


            #region 赋值
            int flag = 0;
            string bz = tbx_bz.Text.ToString();
            string clbz = tbx_clbz.Text.ToString();
            string czgc = tbx_czgc.Text.ToString();
            string gzbjcljg = tbx_gzbjcljg.Text.ToString();
            string gzjssj = tbx_gzjssj.Text.ToString();
            string gzqssj = tbx_gzqssj.Text.ToString();

            if (gzqssj != "" && gzjssj != "")
            {
                if (Convert.ToDateTime(gzqssj) > Convert.ToDateTime(gzjssj))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"故障起始时间不能大于故障结束时间！\")</script>");
                    return;
                }
            }



            string gzxx = tbx_gzxx.Text.ToString();
            string gzyyfx = tbx_gzyyfx.Text.ToString();
            string jycs = tbx_jycs.Text.ToString();
            string ljsc = tbx_ljsc.Text.ToString();
            string sbbh = null;
            if (ddlt_sbbh.SelectedItem.Text.ToString() != "请选择")
            {
                sbbh = ddlt_sbbh.SelectedItem.Text.ToString();
            }
            string tlgzdpcff = tbx_tlgzdpcff.Text.ToString();
            string wxr = tbx_wxr.Text.ToString();
            string zcyx = tbx_zcyx.Text.ToString();
            string sblx = ddlt_sbbh.SelectedValue.ToString();
            string wxrbm = ddlt_wxrbm.SelectedValue.ToString();
            string wxrgw = ddlt_wxrgw.SelectedValue.ToString();
            #endregion
            #region 上传
            string path = Upload_path(Upload_wxwjsc, "gz");
            #endregion
            #region 判断

            if (string.IsNullOrEmpty(sbbh))
            {
                lbl_sbbh.Text = "<span style=\"color:#ff0000\">" + "错误：设备编号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(gzqssj))
            {
                lbl_gzqssj.Text = "<span style=\"color:#ff0000\">" + "错误：故障起始时间不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzqssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(gzjssj))
            {
                lbl_gzjssj.Text = "<span style=\"color:#ff0000\">" + "错误：故障结束时间不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzjssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (!Regex.IsMatch(tbx_ljsc.Text, @"^[0-9]*$")|| string.IsNullOrEmpty(ljsc))
            {
                lbl_ljsc.Text = "<span style=\"color:#ff0000\">" + "错误：累计时长不能为空且只能输入数字" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ljsc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(wxr))
            {
                lbl_wxr.Text = "<span style=\"color:#ff0000\">" + "错误：维修人不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //if (sblx == "-1")
            //{
            //    lbl_sblx.Text = "<span style=\"color:#ff0000\">" + "错误：请选择设备类型" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sblx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}

            //维修人部门
            if (ddlt_wxrbm.SelectedValue.Trim() == "-1")
            {

                lbl_wxrbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxrbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            ////设备编号
            //if (tbx_sbbh.Text.Trim() == " ")
            //{

            //    lbl_sbbh.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sbbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //维修人岗位
            if (ddlt_wxrgw.SelectedValue.Trim() == "-1")
            {

                lbl_wxrgw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxrgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }



            //设备总类
            if (ddlt_sbzl.SelectedValue.Trim() == "-1")
            {

                lbl_sbzl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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

            struct_sbgz.p_bz = bz;
            struct_sbgz.p_clbz = clbz;
            struct_sbgz.p_czgc = czgc;
            struct_sbgz.p_gzbjcljg = gzbjcljg;
            struct_sbgz.p_gzjssj =Convert.ToDateTime(gzjssj);
            struct_sbgz.p_gzqssj =Convert.ToDateTime(gzqssj);
            struct_sbgz.p_gzxx = gzxx;
            struct_sbgz.p_gzyyfx = gzyyfx;
            struct_sbgz.p_jycs = jycs;
            struct_sbgz.p_ljsc = ljsc;
            struct_sbgz.p_sbbh = sbbh;
            struct_sbgz.p_sblx = sblx;
            struct_sbgz.p_tlgzpcff = tlgzdpcff;
            struct_sbgz.p_wxr = wxr;
            struct_sbgz.p_wxrbm = wxrbm;
            struct_sbgz.p_wxrgw = wxrgw;
            struct_sbgz.p_zcyx = zcyx;
            struct_sbgz.p_wxwjsc = path;

            struct_sbgz.p_sbzl = ddlt_sbzl.SelectedValue.ToString().Trim();//初审人
            struct_sbgz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_sbgz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_sbgz.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_sbgz.p_lrr = _usState.userLoginName.ToString();//录入人
            //struct_YGJL.p_sjbs = "0";
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr))
            {
                struct_sbgz.p_sjbs = "0";
                struct_sbgz.p_zt = "2";
                //给终审人添加提示
                SysData.Insert_TSR(struct_sbgz.p_zsr, "11", "1105", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
            {
                struct_sbgz.p_sjbs = "1";
                struct_sbgz.p_zt = "3";
            }
            if (!struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr) && !struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
            {
                struct_sbgz.p_sjbs = "0";
                struct_sbgz.p_zt = "0";
            }
            struct_sbgz.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳

            struct_sbgz.p_czfs = "02";

            struct_sbgz.p_czxx = "位置：设备管理->设备故障->添加 设备编号：" + struct_sbgz.p_sbbh +
                " 设备类型：" + struct_sbgz.p_sblx + " 故障起始时间：" + struct_sbgz.p_gzqssj + " 故障结束时间："
                + struct_sbgz.p_gzjssj + " 累计时长：" + struct_sbgz.p_ljsc + " 维修人部门：" + struct_sbgz.p_wxrbm
                + " 维修人岗位：" + struct_sbgz.p_wxrgw +  " 故障现象：" + struct_sbgz.p_gzxx + " 造成影响：" + struct_sbgz.p_zcyx
                + " 处置过程：" + struct_sbgz.p_czgc + " 故障原因分析：" + struct_sbgz.p_gzyyfx + " 故障板件处理结果：" 
                +struct_sbgz.p_gzbjcljg  + " 同类故障排除方法：" + struct_sbgz.p_tlgzpcff  + " 处理步骤：" + struct_sbgz.p_clbz  + " 建议措施：" + struct_sbgz.p_jycs  + " 备注：" +   struct_sbgz.p_bz 
             + "维修文件上传路径：" + struct_sbgz.p_wxwjsc;
            whwx.Insert_SBGZ(struct_sbgz);

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            bind_rep();
            #endregion
        }
        protected string Upload_path(InputFile Upload, string bs)
        {
            //上传
            SaveFileName = "";
            string FileName = Upload.FileName;//获取上传文件的全路径  
            if (FileName != null)
            {
                string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名  
                                                                         //string SaveFileName = System.IO.Path.Combine(Request.PhysicalApplicationPath, DateTime.Now.ToString("yyyyMMddhhmm") + ExtenName);//合并两个路径为上传到服务器上的全路径  
                string fpath = null;
                string filepath = "UpLoads/SBGL/SBGZ/" + tbx_sbbh.Text + "/";
                fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                if (!Directory.Exists(fpath))
                    Directory.CreateDirectory(fpath);
                saveFileName = this.MakeFileName(bs, FileName);
                SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径


                if (Upload.ContentLength > 0)

                {

                    Upload.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                }
            }
            return SaveFileName;

        }
        private void bind_rep()
        {
            DataTable dt = whwx.Select_SBGZbySBBH(tbx_sbbh.Text).Tables[0];

            DataTable dt_new = new DataTable();
            dt_new.Columns.Add("filename");
            dt_new.Columns.Add("scsj");
            dt_new.Columns.Add("path");
            bool flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                string path = dr["WXWJSC"].ToString();

                if (path != "")
                {
                    DataRow dr_new = dt_new.NewRow();
                    string filename = path.Substring(path.LastIndexOf("\\") + 1);
                    string time = filename.Substring(0, 14);
                    dr_new["filename"] = filename.Substring(16);
                    dr_new["scsj"] = changTimestyle(time);
                    dr_new["path"] = path;
                    dt_new.Rows.InsertAt(dr_new, 0);
                    flag = true;
                }
            }
            if (flag == true)
            {
                Repeater1.Visible = true;
                Repeater1.DataSource = dt_new;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
            }

        }
        public string changTimestyle(string time)
        {
            string change_time = time.Substring(0, 4) + "/" + time.Substring(4, 2) + "/" + time.Substring(6, 2) + " " +
                                               time.Substring(8, 2) + ":" + time.Substring(10, 2) + ":" + time.Substring(12, 2);
            return change_time;
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
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBGZ_GL.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "down")
            {
                try
                {
                    // string DownloadFileName = path + e.CommandArgument.ToString();//文件路径
                    string filePath = e.CommandArgument.ToString();//文件名
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    if (File.Exists(filePath))
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
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
                        //Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                        //Response.Redirect("../main/TZSB_GL.aspx");
                        //Response.End();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"文件不存在！\")</script>");
                        return;
                    }
                }
                catch { }

            }
        }

        #region 设备编号选择框
        protected void ddlt_sblx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sblx = ddlt_sblx.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = whwx.Select_SBDM(sblx);//text是设备代码 值则是该设备代码下的sblx 来满足选择设备代码时也能选取该设备类型
            ddlt_sbbh.DataSource = dt.Copy();
            ddlt_sbbh.DataTextField = "mc";
            ddlt_sbbh.DataValueField = "bm";
            ddlt_sbbh.DataBind();
            ddlt_sbbh.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string sblx = ddlt_sblx.SelectedValue.ToString();
            string sbbh = ddlt_sbbh.Text.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_sbbh.Items.Count > 0)
            {
                tbx_sbbh.Text = ddlt_sbbh.SelectedItem.Text;
                sbbh_zz = ddlt_sbbh.SelectedItem.Text.ToString();
                sblx_zz = ddlt_sbbh.SelectedValue.ToString();
            }
        }
        #endregion 
    }
}