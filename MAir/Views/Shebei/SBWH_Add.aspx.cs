using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brettle.Web.NeatUpload;
using Sys;
using System.Globalization;

namespace CUST.WKG.SheBei.main
{
    public partial class SBWH_Add : System.Web.UI.Page
    {
        private UserState _usState;

        private WHWX whwx;
        private Struct_SBWH struct_whwx;
        private BMGW bmgw;
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
            bmgw = new BMGW(_usState);
            struct_whwx = new Struct_SBWH();
            if (!IsPostBack)
            {
                tbx_whsj.Attributes.Add("readonly", "readonly");
                ddltBind();

            }
        }

        private void ddltBind()
        {
            //维护人部门
            ddlt_whrbm.DataTextField = "mc";
            ddlt_whrbm.DataValueField = "bm";
            ddlt_whrbm.DataSource = SysData.BM().Copy();
            ddlt_whrbm.DataBind();
            ddlt_whrbm.Items.Insert(0, new ListItem("请选择", "-1"));
          
            //维护人岗位

            DataTable dt_whrgw = new DataTable();
            ddlt_whrgw.DataSource = dt_whrgw;
            ddlt_whrgw.DataBind();
            ddlt_whrgw.Items.Insert(0, new ListItem("请选择", "-1"));


            DataTable dt_whr = new DataTable();
            ddlt_whr.DataSource = dt_whr;
            ddlt_whr.DataBind();
            ddlt_whr.Items.Insert(0, new ListItem("请选择", "-1"));
         
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
            //维护状态

            ddlt_whzt.DataTextField = "mc";
            ddlt_whzt.DataValueField = "bm";
            ddlt_whzt.DataSource = SysData.WHZT().Copy();
            ddlt_whzt.DataBind();
            ddlt_whzt.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备种类

            ddlt_sbzl.DataTextField = "mc";
            ddlt_sbzl.DataValueField = "bm";
            ddlt_sbzl.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140902");

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
            ddlt_sjszbm.DataSource = SysData.BM("140902", _usState.userID).Copy();
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
            #region 赋值判断
            int flag = 0;
            string sbbh=null;
            if (ddlt_sbbh.SelectedItem.Text.ToString() != "请选择")
            {
                sbbh = ddlt_sbbh.SelectedItem.Text.ToString();
            }
            string sblx = ddlt_sbbh.SelectedValue.ToString();
            string sbztxxxx = tbx_sbztxxxx.Text.ToString();
            string whzt = ddlt_whzt.SelectedValue.ToString();
            string whsj = tbx_whsj.Text.ToString();
            string whr = ddlt_whr.SelectedValue.ToString();
            string whrbm = ddlt_whrbm.SelectedValue.ToString();
            string whrgw = ddlt_whrgw.SelectedValue.ToString();
            string whjl = tbx_whjl.Text.ToString();
            string xsjl = tbx_xsjl.Text.ToString();
            string bz = tbx_bz.Text.ToString();
            if (string.IsNullOrEmpty(whsj))
            {
                lbl_whsj.Text = "<span style=\"color:#ff0000\">" + "错误：维护时间不能为空" + "</span>";
                flag = 1;
            }

            else if (Convert.ToDateTime(whsj) > DateTime.Now)
            {
                lbl_whsj.Text = "<span style=\"color:#ff0000\">" + "错误：维护时间不能大于当前时间" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_whsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(sbbh))
            {
                lbl_sbbh.Text = "<span style=\"color:#ff0000\">" + "错误：设备编号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(sbztxxxx))
            {
                lbl_sbztxxxx.Text = "<span style=\"color:#ff0000\">" + "错误：设备状态详细信息不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbztxxxx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //if (sblx == "-1")
            //{
            //    lbl_sblx.Text = "<span style=\"color:#ff0000\">" + "错误：请选择维护状态" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sblx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
            //设备编号
            //if (tbx_sbbh.Text.Trim() == " ")
            //{

            //    lbl_sbbh.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sbbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            if (whzt == "-1")
            {
                lbl_whzt.Text = "<span style=\"color:#ff0000\">" + "错误：请选择维护状态" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_whzt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (whrbm == "-1")
            {
                lbl_whrbm.Text = "<span style=\"color:#ff0000\">" + "错误：请选择维护人部门" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_whrbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (whrgw == "-1")
            {
                lbl_whrgw.Text = "<span style=\"color:#ff0000\">" + "错误：请选择维护人岗位" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_whrgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (whr == "-1")
            {
                lbl_whr.Text = "<span style=\"color:#ff0000\">" + "错误：请选择维护人" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_whr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(whjl))
            {
                lbl_whjl.Text = "<span style=\"color:#ff0000\">" + "错误：维护记录不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_whjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(xsjl))
            {
                lbl_xsjl.Text = "<span style=\"color:#ff0000\">" + "错误：场地环境和电磁环境巡视记录不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xsjl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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

            #region 上传
            struct_whwx.p_scsj = DateTime.Now;
            string path = Upload_path(Upload, "wh");

            #endregion
            try
            {
                struct_whwx.p_sbbh = sbbh;
                struct_whwx.p_whwjsc = path;
                struct_whwx.p_sblx = sblx;
                struct_whwx.p_sbztxxxx = sbztxxxx;
                struct_whwx.p_whzt = whzt;
                struct_whwx.p_whsj = Convert.ToDateTime(whsj);
                struct_whwx.p_whr = whr;
                struct_whwx.p_whrbm = whrbm;
                struct_whwx.p_whrgw = whrgw;
                struct_whwx.p_whjl = whjl;
                struct_whwx.p_cdhjhdchjxsjl = xsjl;
                struct_whwx.p_bz = bz;

                struct_whwx.p_sbzl = ddlt_sbzl.SelectedValue.ToString().Trim();//初审人
                struct_whwx.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                struct_whwx.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                struct_whwx.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                struct_whwx.p_lrr = _usState.userLoginName.ToString();//录入人
                                                                      //struct_YGJL.p_sjbs = "0";
                                                                      //如果是初审人录入数据，则状态默认初审通过，即待终审
                if (struct_whwx.p_lrr.Equals(struct_whwx.p_csr))
                {
                    struct_whwx.p_sjbs = "0";
                    struct_whwx.p_zt = "2";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_whwx.p_zsr, "11", "1105", -1);
                }
                //如果是终审人录入数据，则状态为审核通过
                if (struct_whwx.p_lrr.Equals(struct_whwx.p_zsr))
                {
                    struct_whwx.p_sjbs = "1";
                    struct_whwx.p_zt = "3";
                }
                if (!struct_whwx.p_lrr.Equals(struct_whwx.p_csr) && !struct_whwx.p_lrr.Equals(struct_whwx.p_zsr))
                {
                    struct_whwx.p_sjbs = "0";
                    struct_whwx.p_zt = "0";
                }
                struct_whwx.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳



                struct_whwx.p_czfs = "01";

                struct_whwx.p_czxx = "位置：设备管理->设备维护->添加 设备编号：" + struct_whwx.p_sbbh +
                    " 设备类型：" + struct_whwx.p_sblx + " 设备状态详细信息：" + struct_whwx.p_sbztxxxx + " 维护状态：" + struct_whwx.p_whzt
                    + " 维护时间：" + struct_whwx.p_whsj + " 维护人部门：" + struct_whwx.p_whrbm + " 维护人岗位：" + struct_whwx.p_whrgw +
                    " 维护记录：" + struct_whwx.p_whjl + " 场地环境和电磁环境巡视记录：" + struct_whwx.p_cdhjhdchjxsjl + " 备注：" +
                    struct_whwx.p_bz + "维护文件上传路径：" + struct_whwx.p_whwjsc;
                whwx.Insert_SBWH(struct_whwx);

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));

                return;
            }
            bind_rep();
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
                string filepath = "UpLoads/SBGL/SBWH/" + tbx_sbbh.Text + "/";
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
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBWH_GL.aspx");
        }
        private void bind_rep()
        {
            DataTable dt = whwx.Select_SBWHbySBBH(tbx_sbbh.Text).Tables[0];

            DataTable dt_new = new DataTable();
            dt_new.Columns.Add("filename");
            dt_new.Columns.Add("scsj");
            dt_new.Columns.Add("path");
            bool flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                string path = dr["WHWJSC"].ToString();
                
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


        #region 岗位部门人 三联动

        //根据部门找岗位
        protected void ddlt_whrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_whrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_whrgw.DataSource = dt;
                ddlt_whrgw.DataBind();
                ddlt_whrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_whrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_whrgw.DataTextField = "mc";
                ddlt_whrgw.DataValueField = "bm";
                ddlt_whrgw.DataBind();
                ddlt_whrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }
        //根据岗位找人
        protected void ddlt_whrgw_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gw = ddlt_whrgw.SelectedValue;
            if (gw == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_whr.DataSource = dt;
                ddlt_whr.DataBind();
                ddlt_whr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                DataTable dt = new DataTable();
                dt = bmgw.Select_YGALL(gw).Tables[0];
                ddlt_whr.DataSource = dt;
                ddlt_whr.DataTextField = "xm";
                ddlt_whr.DataValueField = "bh";
                ddlt_whr.DataBind();
                ddlt_whr.Items.Insert(0, new ListItem("请选择", "-1"));
            }

        }
        #endregion

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