using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BS_WXFY_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private WXFY wxfy;
        private DataTable dt_detail;
        private int wxbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            wxfy = new WXFY(_usState);
            if (!IsPostBack)
            {
                wxbh = Convert.ToInt32(Request.Params["wxbh"].ToString());
                select_detail();
            }
        }

        protected void select_detail()
        {
            wxbh = Convert.ToInt32(Request.Params["wxbh"]);
            dt_detail = wxfy.Select_Bs_Wxfy_Detail(wxbh);
            //项目名称
            string xmmc_sbzl;
            string xmmc_sbwz;
            string xmmc_sblx;

            //设备类别
            string sblb_sbzl;
            string sblb_sbwz;
            string sblb_sblx;
            //设备名称
            string sbmc_zx;
            string sbmc_sbzl;
            string sbmc_sbwz;
            string sbmc_sblx;
            //存放地点
            string cfdd_zx;//存放地点_支线
            string cfdd_tx;//存放地点_填写
            //登记单位
            lbl_djdw.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["djdw"].ToString()).mc;
            //预算批复
            lbl_yspf.Text = dt_detail.Rows[0]["yspf"].ToString() + "万";
            //维修类别
            lbl_wxlb.Text = SysData.WXLBByKey(dt_detail.Rows[0]["wxlb"].ToString()).mc;
            //设备类别
            sblb_sbzl = dt_detail.Rows[0]["sblb"].ToString().Substring(0, 2);//设备类别_设备种类
            sblb_sbwz = dt_detail.Rows[0]["sblb"].ToString().Substring(2, 2);//设备类别_设备位置
            sblb_sblx = dt_detail.Rows[0]["sblb"].ToString().Substring(4, 4);//设备类别_设备类型
            lbl_sblb.Text = SysData.SBZLByKey(sblb_sbzl).mc + sblb_sbwz + SysData.SBLXByKey(sblb_sblx).mc;
            //设备名称
            sbmc_zx = dt_detail.Rows[0]["sbmc"].ToString().Substring(0, 2);//设备名称_支线
            sbmc_sbzl = dt_detail.Rows[0]["sbmc"].ToString().Substring(2, 2);//设备名称_设备种类
            sbmc_sbwz = dt_detail.Rows[0]["sbmc"].ToString().Substring(4, 2);//设备名称_设备位置
            sbmc_sblx = dt_detail.Rows[0]["sbmc"].ToString().Substring(6, 4);//设备名称_设备类型
            lbl_sbmc.Text = SysData.ZXDMByKey(sbmc_zx).mc + SysData.SBZLByKey(sbmc_sbzl).mc + sbmc_sbwz + SysData.SBLXByKey(sbmc_sblx).mc;
            //存放地点
            cfdd_zx = dt_detail.Rows[0]["cfdd"].ToString().Substring(0, 2);//存放地点_支线
            cfdd_tx = dt_detail.Rows[0]["cfdd"].ToString().Substring(2);//存放地点_填写
            lbl_cfdd.Text = SysData.ZXDMByKey(cfdd_zx).mc + cfdd_tx;
            //供应商/维修单位
            lbl_gys_wxdw.Text = dt_detail.Rows[0]["gys_wxdw"].ToString();
            //维修日期
            lbl_wxrq.Text = dt_detail.Rows[0]["qswxrq"].ToString().Substring(0, 10) + "-" + dt_detail.Rows[0]["jzwxrq"].ToString().Substring(0, 10);
            //维修预算
            lbl_wxys.Text = dt_detail.Rows[0]["wxys"].ToString();
            //板件名称
            lbl_bjmc.Text = dt_detail.Rows[0]["bjmc"].ToString();
            //预算执行机场
            lbl_yszxjc.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["yszxjc"].ToString()).mc;
            //维修预算
            lbl_wxys.Text = dt_detail.Rows[0]["wxys"].ToString() + "万";
            //年度
            lbl_nd.Text = dt_detail.Rows[0]["nd"].ToString();
            ////状态
            //lbl_zt.Text = SysData.ZTByKey(dt_detail.Rows[0]["zt"].ToString()).mc;
            //驳回原因
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();
            //执行额度
            lbl_zxed.Text = dt_detail.Rows[0]["zxed"].ToString();
            //剩余额度
            lbl_syed.Text = dt_detail.Rows[0]["syed"].ToString();
            //项目名称
            xmmc_sbzl = dt_detail.Rows[0]["xmmc"].ToString().Substring(0, 2);//项目名称_设备种类
            xmmc_sbwz = dt_detail.Rows[0]["xmmc"].ToString().Substring(2, 2);//项目名称_设备位置
            xmmc_sblx = dt_detail.Rows[0]["xmmc"].ToString().Substring(4, 4);//项目名称_设备类型
            lbl_xmmc.Text = SysData.SBZLByKey(xmmc_sbzl).mc + xmmc_sbwz + SysData.SBLXByKey(xmmc_sblx).mc;

            lbl_qs.Text = dt_detail.Rows[0]["qs"].ToString(); 
            lbl_gzbg.Text = dt_detail.Rows[0]["gzbg"].ToString(); 
            lbl_qtfj.Text = dt_detail.Rows[0]["qtfj"].ToString();
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
            Server.Transfer("BS_WXFY.aspx");
        }


        protected void btn_qs_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_qs.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../uploads/")+ fileName;          //目标文件路径
            FileInfo fileInfo = new FileInfo(filePath);
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

        protected void btn_gzbg_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_gzbg.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../uploads/") + fileName;          //目标文件路径
            FileInfo fileInfo = new FileInfo(filePath);
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

        protected void btn_qtfj_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_qtfj.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../uploads/") + fileName;          //目标文件路径
            FileInfo fileInfo = new FileInfo(filePath);
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
    }
}