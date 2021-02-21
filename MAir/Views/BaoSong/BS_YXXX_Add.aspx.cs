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
using Sys;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Globalization;

namespace CUST.WKG
{
    public partial class BS_YXXX_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private YXXX yxxx;
        private Struct_Bs_YXXX struct_bs_yxxx;
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yxxx = new YXXX(_usState);
            if (!IsPostBack)
            {    
                ddltBind();
            }
        }
        private void ddltBind()
        {
            //报送类型
            ddlt_bm.DataSource = SysData.BM().Copy();
            ddlt_bm.DataTextField = "mc";
            ddlt_bm.DataValueField = "bm";
            ddlt_bm.DataBind();
            ddlt_bm.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_YXXX.aspx", true);
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

   
        protected void btn_save_Click(object sender, EventArgs e)
        {
           
            int flag = 0;
            //判断是否有该路径  
            string path = Server.MapPath("../BaoSong/YXXX/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //上传文件
            if (!tbx_bswj.HasFile)
            {
                lbl_bswj.Text = "请选择上传文件";
                return;
            }
            if (tbx_bswj.PostedFile.ContentLength > 10240000)
            {
                lbl_bswj.Text = "附件大小超出10Ｍ";
                return;
            }
            #region MyRegion
                //部门
                if (ddlt_bm.SelectedValue == "-1")
                {
                    lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
                //设备类型
                if (tbx_bssj.Text.ToString()== "")
                {
                    lbl_bssj.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
                if (flag == 1) { return; }
            #endregion
            struct_bs_yxxx.p_bsbh = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);
            struct_bs_yxxx.p_bsbm =ddlt_bm.SelectedValue.ToString();
            struct_bs_yxxx.p_bsrq = Convert.ToDateTime(tbx_bssj.Text.ToString());
            //文件上传
            struct_bs_yxxx.p_bswj = tbx_bswj.FileName.ToString();
            tbx_bswj.PostedFile.SaveAs(path + tbx_bswj.FileName);
            

            struct_bs_yxxx.p_czfs = "01";
            struct_bs_yxxx.p_czxx = "位置：航务综合信息报送系统->运行信息报送->添加      描述：员工编号："+_usState.userLoginName;
            yxxx.Insert_BS_YXXX(struct_bs_yxxx);
          
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
        }
    }
}