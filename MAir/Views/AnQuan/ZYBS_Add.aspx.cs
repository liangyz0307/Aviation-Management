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
using System.IO;
using System.Text.RegularExpressions;
using Sys;


namespace CUST.WKG
{
    public partial class ZYBS_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private ZYBS zybs;
        private Struct_ZYBS struct_zybs;
        public string SaveFileName;
        public string FileName;
        public string filepath;
        public string fpath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zybs = new ZYBS(_usState);
            struct_zybs = new Struct_ZYBS();
            if (!IsPostBack)
            {
                bind_drop();
                tbx_bssj.Attributes.Add("readonly", "readonly");
            }
        }
        private void bind_drop()
        {
            lbl_bsyg.Text = _usState.userXM;
            lbl_bsgw.Text = _usState.userGWMC;
            //报送类型
            ddlt_bslx.DataTextField = "mc";
            ddlt_bslx.DataValueField = "bm";
            ddlt_bslx.DataSource = SysData.BSLX().Copy();
            ddlt_bslx.DataBind();
            ddlt_bslx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected string MakeFileName(string biaoshi, string exeFileString)
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
            //上传
            struct_zybs.p_bsbh = zybs.SelectBSBH(struct_zybs.p_gw);
            if (struct_zybs.p_bsbh != "")
            {
                if (AttachFile.HasFile)

                {

                    FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀
                    string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                    filepath = "UpLoads/" + struct_zybs.p_bsbh + "/";
                    fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                    string bslx= ddlt_bslx.SelectedValue.ToString();
                    string saveFileName = this.MakeFileName(bslx, FileName);
                    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径
                    if (!Directory.Exists(fpath))
                        Directory.CreateDirectory(fpath);
                    AttachFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                    //string url = filepath + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName; //文件保存的路径
                    float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M

                }
                try
                {
                    struct_zybs.p_bsbh = _usState.userGWDM + zybs.SelectBS_ZYBSMaxBH();
                    struct_zybs.p_bsyg = _usState.userLoginName;
                    struct_zybs.p_bsgw = _usState.userGWDM;
                    struct_zybs.p_bslx = ddlt_bslx.SelectedValue.ToString();
                    struct_zybs.p_bsip = Page.Request.UserHostAddress;//报送IP
                    struct_zybs.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());
                    struct_zybs.p_bsms = tbx_bsms.Text.ToString().Trim();
                    struct_zybs.p_jjfa = tbx_jjfa.Text.ToString().Trim();
                    struct_zybs.p_bz = tbx_bz.Text.ToString().Trim();
                    struct_zybs.p_zt = "0";
                    struct_zybs.p_bhyy = "";
                    SC(struct_zybs.p_bsbh);
                    struct_zybs.p_zplj = HF_lj.Value;
                    struct_zybs.p_xtsj = DateTime.Now;
                    struct_zybs.p_czfs = "01";
                    struct_zybs.p_czxx = "位置：航务综合报送系统->自愿报送信息->添加      描述：报送员工编号：" + struct_zybs.p_bsyg + "报送岗位："
                        + struct_zybs.p_bsgw + "报送类型：" + struct_zybs.p_bslx + "报送IP：" + struct_zybs.p_bsip + "报送时间:" + struct_zybs.p_bssj
                        + "报送模式：" + struct_zybs.p_bsms + "解决方案：" + struct_zybs.p_jjfa
                        + "审批人" + struct_zybs.p_spr + "备注" + struct_zybs.p_bz;
                    zybs.InsertBS_ZYBS(struct_zybs);
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    Response.Redirect("../AnQuan/ZYBSGL.aspx", true);
                }
                catch (EMException ex)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                    return;
                }
            }
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
            public void SC(string bsbh)
            {
                if (ImageUpload.FileName.ToString() != "")
                {
                    if (this.ImageUpload.PostedFile.ContentLength < 20971520)
                    {
                        string type = this.ImageUpload.PostedFile.ContentType;
                        if (String.Compare(type, "image/jpg", true) == 0 || String.Compare(type, "image/png", true) == 0 || String.Compare(type, "image/jpeg", true) == 0)
                        {
                            string exeFileString = System.IO.Path.GetExtension(this.ImageUpload.PostedFile.FileName);//获取后缀
                            string saveFileName = bsbh + exeFileString;
                            string savePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\YuanGong\\Temp\\" + bsbh + "\\";
                            if (!System.IO.Directory.Exists(savePath))
                            {
                                System.IO.Directory.CreateDirectory(savePath);
                            }
                            string imagePath = savePath + saveFileName;
                            this.ImageUpload.PostedFile.SaveAs(imagePath);
                            HF_lj.Value = imagePath;
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
            protected void btn_fh_Click(object sender, EventArgs e)
            {
                Response.Redirect("ZYBSGL.aspx", true);
            }    
}
    }
