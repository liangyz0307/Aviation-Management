using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Tools;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace CUST.WKG
{
    public partial class WXFY_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private Struct_Bs_Wxfy struct_bs_wxfy;
        public WXFY wxfy;
        public string SaveFileName_qs;
        public string SaveFileName_gzbg;
        public string SaveFileName_qtfj;
        public string FileName_qs;
        public string FileName_gzbg;
        public string FileName_qtfj;
        public string firstGetFilePath;
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
            wxfy = new WXFY(_usState);
            if(!IsPostBack)
            { ddltBind(); }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //判断是否有该路径  
            string path = Server.MapPath("../uploads/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        
            #region 赋值
            string djdw = ddlt_djdw.SelectedValue.Trim().ToString();
            string yspf = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数
            string wxys = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数或小数         
            string wxlb = ddlt_wxlb.SelectedValue.Trim().ToString();
            string sblb_sbzl = ddlt_sblb_sbzl.SelectedValue.Trim().ToString();
            string sblb_sbwz = ddlt_sblb_sbwz.SelectedValue.Trim().ToString();
            string sblb_sblx = ddlt_sblb_sblx.SelectedValue.Trim().ToString();
            string yszxjc = ddlt_yszxjc.SelectedValue.Trim().ToString();
            string cfdd = ddlt_cfdd.SelectedValue.Trim().ToString();
            string cfdd_qt = tbx_cfdd_qt.Text.Trim().ToString();
            string gys_wxdw = tbx_gys_wxdw.Text.Trim().ToString();
            string csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            string zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            string bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            string lrr = _usState.userLoginName.ToString();//录入人
            string sjbs = "0";
            string sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳            
            #endregion

            #region lable判断
            int flag = 0;
            //登记单位
            if (ddlt_djdw.SelectedValue == "-1")
            {
                lbl_djdw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_djdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //预算费用
            if (tbx_yspf.Text == "")
            {
                lbl_yspf.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_yspf.Text.ToString(), yspf))
                {
                    lbl_yspf.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_yspf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //维修预算
            if (tbx_wxys.Text == "")
            {
                lbl_wxys.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_wxys.Text.ToString(), wxys))
                {
                    lbl_wxys.Text = "<span style=\"color:#ff0000\">" + "请输入小数或整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_wxys.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //维修类型
            if (ddlt_wxlb.SelectedValue == "-1")
            {
                lbl_wxlb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxlb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //设备种类
            if (ddlt_sblb_sbzl.SelectedValue == "-1" || ddlt_sblb_sblx.SelectedValue == "-1" || ddlt_sblb_sbwz.SelectedValue == "-1")
            {
                lbl_sblb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sblb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //存放地点
            if (ddlt_cfdd.SelectedValue == "-1" || tbx_cfdd_qt.Text == "")
            {
                lbl_cfdd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_cfdd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //供应商/维修单位
            if (tbx_gys_wxdw.Text == "")
            {
                lbl_gys_wxdw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gys_wxdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //年度
            if (tbx_nd.Text == "")
            {
                lbl_nd.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_nd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //板件名称
            if (tbx_bjmc.Text == "")
            {
                lbl_bjmc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //请示附件,故障报告,其他附件
            if ((!FileUpload_qs.HasFile) )
            {
                lbl_qs.Text = "<span style=\"color:#ff0000\">" + "附件不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_qs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //故障报告
            if ((!FileUpload_gzbg.HasFile))
            {
                lbl_gzbg.Text = "<span style=\"color:#ff0000\">" + "附件不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzbg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //其他附件
            if ((!FileUpload_qtfj.HasFile))
            {
                lbl_qtfj.Text = "<span style=\"color:#ff0000\">" + "附件不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_qtfj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //维修日期
            if ((tbx_qswxrq.Text == ""))
            {
                lbl_wxrq.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                //string qswxrq = tbx_qswxrq.Text;
                //string jzwxrq = tbx_jzwxrq.Text;
                //if (qswxrq.CompareTo(jzwxrq)>0) {
                //    lbl_wxrq.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期" + "</span>";
                //    flag = 1;
                //}     
                //else {
                //    lbl_wxrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                //}
            }         
            if (flag == 1)
            { return; }
            #endregion

            #region 上传
            if (FileUpload_qs.HasFile && FileUpload_gzbg.HasFile && FileUpload_qtfj.HasFile)
            {
                //对上传文件的大小进行检测，限定文件最大不超过10M
                if (FileUpload_qs.PostedFile.ContentLength < 10240000 && FileUpload_gzbg.PostedFile.ContentLength < 10240000 && FileUpload_qtfj.PostedFile.ContentLength < 10240000)
                {
                    struct_bs_wxfy.p_djdw = djdw;//登记单位
                    struct_bs_wxfy.p_yspf = tbx_yspf.Text.Trim().ToString();//预算批复
                    struct_bs_wxfy.p_wxlb = wxlb;//维修类别
                    struct_bs_wxfy.p_sblb = sblb_sbzl + sblb_sbwz + sblb_sblx;//设备类别=设备种类+设备位置+设备类型
                    struct_bs_wxfy.p_cfdd = cfdd + cfdd_qt;//存放地点
                    struct_bs_wxfy.p_sbmc = djdw + sblb_sbzl + sblb_sbwz + sblb_sblx;//设备名称=支线+设备类别
                    struct_bs_wxfy.p_gys_wxdw = gys_wxdw;//供应商_维修单位
                    struct_bs_wxfy.p_qswxrq = Convert.ToDateTime(tbx_qswxrq.Text.Trim().ToString());
                    struct_bs_wxfy.p_jzwxrq = Convert.ToDateTime(tbx_qswxrq.Text.Trim().ToString());
                    struct_bs_wxfy.p_wxys = tbx_wxys.Text.Trim().ToString();//维修预算
                    struct_bs_wxfy.p_bjmc = tbx_bjmc.Text.Trim().ToString();//板件名称
                    struct_bs_wxfy.p_yszxjc = yszxjc;//预算执行机场
                    struct_bs_wxfy.p_nd = tbx_nd.Text.Trim().ToString();//年度
                    struct_bs_wxfy.p_xmmc = djdw + sblb_sbwz + sblb_sblx;//项目名称=支线+位置+设备类型
                    struct_bs_wxfy.p_qs = FileUpload_qs.FileName;//请示
                    struct_bs_wxfy.p_gzbg = FileUpload_gzbg.FileName;//故障报告
                    struct_bs_wxfy.p_qtfj = FileUpload_qtfj.FileName;//其他附件
                    struct_bs_wxfy.p_qslj = path;//请示路径
                    struct_bs_wxfy.p_gzbglj = path;//故障报告路径
                    struct_bs_wxfy.p_qtfjlj = path;//其他附件路径
                    struct_bs_wxfy.p_csr = csr;//初审人
                    struct_bs_wxfy.p_zsr = zsr;//终审人
                    struct_bs_wxfy.p_bmdm = bmdm;//数据所在部门
                    struct_bs_wxfy.p_lrr = lrr;//录入人
                    struct_bs_wxfy.p_sjbs = sjbs;//数据标识
                    struct_bs_wxfy.p_sjc = sjc;//时间戳
                    struct_bs_wxfy.p_czfs = "01";//操作方式
                    struct_bs_wxfy.p_czxx = "位置：航务综合信息报送系统->维修费用->添加      描述：登记单位：" + struct_bs_wxfy.p_djdw + "预算费用："
                        + struct_bs_wxfy.p_yspf + "维修类别：" + struct_bs_wxfy.p_wxlb + "设备名称" + struct_bs_wxfy.p_sbmc
                        + "存放地点：" + struct_bs_wxfy.p_cfdd + "维修预算：" + struct_bs_wxfy.p_wxys + "维修日期" + struct_bs_wxfy.p_qswxrq
                        + "预算执行机场：" + struct_bs_wxfy.p_yszxjc;
                    //上传文件
                    FileUpload_qs.PostedFile.SaveAs(path + FileUpload_qs.FileName);
                    FileUpload_gzbg.PostedFile.SaveAs(path + FileUpload_gzbg.FileName);
                    FileUpload_qtfj.PostedFile.SaveAs(path + FileUpload_qtfj.FileName);
                    //插入数据库
                    wxfy.Insert_Bs_Wxfy(struct_bs_wxfy);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");                  
                    #region 清空数据
                    //ddlt_djdw.SelectedValue = "-1";
                    //tbx_yspf.Text = "";
                    //ddlt_wxlb.SelectedValue = "-1";
                    //ddlt_sblb_sbwz.SelectedValue = "-1";
                    //ddlt_cfdd.SelectedValue = "-1";
                    //ddlt_yszxjc.SelectedValue = "-1";
                    //tbx_cfdd_qt.Text = "";
                    //tbx_wxys.Text = "";
                    //tbx_bjmc.Text = "";
                    //tbx_qswxrq.Text = "";
                    //tbx_qswxrq.Text = "";
                    //tbx_nd.Text = "";
                    Response.Redirect("../BaoSong/BS_WXFY.aspx", true);
                }
                else {
                    lbl_qs.Text = "附件大小超出10Ｍ";
                    lbl_gzbg.Text = "附件大小超出10Ｍ";
                    lbl_qtfj.Text = "附件大小超出10Ｍ";
                }
                #endregion
            }
            #endregion
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
            Response.Redirect("../BaoSong/BS_WXFY.aspx", true);
        }

        protected void ddltBind()
        {
            //登记单位(支线)
            ddlt_djdw.DataSource = SysData.ZXDM().Copy();
            ddlt_djdw.DataTextField = "mc";
            ddlt_djdw.DataValueField = "bm";
            ddlt_djdw.DataBind();
            ddlt_djdw.Items.Insert(0, new ListItem("请选择", "-1"));

            //绑定维修类别
            ddlt_wxlb.DataSource = SysData.WXLB().Copy();
            ddlt_wxlb.DataTextField = "mc";
            ddlt_wxlb.DataValueField = "bm";
            ddlt_wxlb.DataBind();
            ddlt_wxlb.Items.Insert(0, new ListItem("请选择", "-1"));

            //绑定设备种类
            ddlt_sblb_sbzl.DataSource = SysData.SBZL().Copy();
            ddlt_sblb_sbzl.DataTextField = "mc";
            ddlt_sblb_sbzl.DataValueField = "bm";
            ddlt_sblb_sbzl.DataBind();

            //绑定设备位置
            ddlt_sblb_sbwz.DataSource = SysData.SBWZ().Copy();
            ddlt_sblb_sbwz.DataTextField = "mc";
            ddlt_sblb_sbwz.DataValueField = "bm";
            ddlt_sblb_sbwz.DataBind();
            ddlt_sblb_sbwz.Items.Insert(0, new ListItem("请选择", "-1"));


            //绑定设备类型
            ddlt_sblb_sblx.DataSource = SysData.SBLX(ddlt_sblb_sbzl.SelectedValue.ToString()).Copy();
            ddlt_sblb_sblx.DataTextField = "mc";
            ddlt_sblb_sblx.DataValueField = "bm";
            ddlt_sblb_sblx.DataBind();


            //绑定存放地点(支线)
            ddlt_cfdd.DataSource = SysData.ZXDM().Copy();
            ddlt_cfdd.DataTextField = "mc";
            ddlt_cfdd.DataValueField = "bm";
            ddlt_cfdd.DataBind();
            ddlt_cfdd.Items.Insert(0, new ListItem("请选择", "-1"));

            //绑定预算执行机场(支线)
            ddlt_yszxjc.DataSource = SysData.ZXDM().Copy();
            ddlt_yszxjc.DataTextField = "mc";
            ddlt_yszxjc.DataValueField = "bm";
            ddlt_yszxjc.DataBind();
            ddlt_yszxjc.Items.Insert(0, new ListItem("请选择", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();

            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();

            //数据所在部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
        }
        
        protected void ddlt_sbzl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlt_sblb_sblx.DataTextField = "mc";
            ddlt_sblb_sblx.DataValueField = "bm";
            ddlt_sblb_sblx.DataSource = SysData.SBLX(ddlt_sblb_sbzl.SelectedValue.ToString()).Copy();
            ddlt_sblb_sblx.DataBind();
        }

    }
}