using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using CUST.Tools;
using CUST;
using CUST.Sys;
using CUST.MKG;
using System.IO;
using System.Web.Services;
using Sys;

namespace CUST.WKG
{
    public partial class DHSB_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private string sblx;
        private DataTable dt_select;
        private DHSB dhsb;
        private string id;
        private string scwjsjc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dhsb = new DHSB(_usState);
            if (!IsPostBack)
            {
                id = Request.Params["id"].ToString();
                wxdhsb.Attributes.Add("style", "display:none");
                hxsb.Attributes.Add("style", "display:none");
                xhsb.Attributes.Add("style", "display:none");
                cjy.Attributes.Add("style", "display:none");
                qxxb.Attributes.Add("style", "display:none");
                wfxxb.Attributes.Add("style", "display:none");
                zdxb.Attributes.Add("style", "display:none");
                select_detail();

            }
           
        }
        private void select_detail()
        {
            string id = Request.Params["id"].ToString();
            dt_select = dhsb.Select_DHSB_Detail(Convert.ToInt32(id));

            dt_select.Columns.Add("sblxmc");
            dt_select.Columns.Add("tzmczl_tzmcmc");
            dt_select.Columns.Add("tzmczl_wzmc");
            dt_select.Columns.Add("tzmczl_sblxmc");
            dt_select.Columns.Add("yssjcmc");
            dt_select.Columns.Add("pldwmc");
            dt_select.Columns.Add("tcsfxymc");
            dt_select.Columns.Add("mcfxjyjgmc");
            dt_select.Columns.Add("scgldwmc");
            dt_select.Columns.Add("sbztmc");
            dt_select.Columns.Add("xssjcmc");
            dt_select.Columns.Add("hxsb_lbmc");
            dt_select.Columns.Add("hxsb_txzlxmc");
            dt_select.Columns.Add("xhsb_txzlxmc");
            dt_select.Columns.Add("cjy_ptsbmc");
            dt_select.Columns.Add("qxxb_dwlxmc");
            dt_select.Columns.Add("wfxxb_dwlxmc");
            dt_select.Columns.Add("zdxb_lxxzmc");
            dt_select.Columns.Add("ztmc");

            foreach (DataRow dr in dt_select.Rows)
            {
                //公共字段
                string ss = dr["sblx"].ToString();
                string sblxmv = SysData.SBZLByKey(dr["sblx"].ToString()).mc;
                
                dr["sblxmc"] = SysData.SBLXByKey(dr["sblx"].ToString()).mc;
                dr["tzmczl_tzmcmc"] = SysData.ZXDMByKey(dr["tzmczl_tzmc"].ToString()).mc;
                dr["tzmczl_wzmc"] = SysData.SBWZByKey(dr["tzmczl_wz"].ToString()).mc;
                dr["tzmczl_sblxmc"] = SysData.SBLXByKey(dr["tzmczl_sblx"].ToString()).mc;
                dr["yssjcmc"] = SysData.ZXDMByKey(dr["yssjc"].ToString()).mc;
                dr["pldwmc"] = SysData.PLDWByKey(dr["pldw"].ToString()).mc;
                dr["tcsfxymc"] = SysData.TCSFXYByKey(dr["tcsfxy"].ToString()).mc;
                dr["mcfxjyjgmc"] = SysData.MCFXJYJGByKey(dr["mcfxjyjg"].ToString()).mc;
                dr["scgldwmc"] = SysData.DWLXByKey(dr["scgldw"].ToString()).mc;
                dr["sbztmc"] = SysData.SBZTByKey(dr["sbzt"].ToString()).mc;
                dr["xssjcmc"] = SysData.ZXDMByKey(dr["xssjc"].ToString()).mc;
                //航向设备
                dr["hxsb_lbmc"] = SysData.HXSBLBByKey(dr["hxsb_lb"].ToString()).mc;
                dr["hxsb_txzlxmc"] = SysData.HXSBTXZLXByKey(dr["hxsb_txzlx"].ToString()).mc;
                //下滑设备
                dr["xhsb_txzlxmc"] = SysData.XHSBTXZLXByKey(dr["xhsb_txzlx"].ToString()).mc;
                //测距仪
                dr["cjy_ptsbmc"] = SysData.CJYPYSBByKey(dr["cjy_ptsb"].ToString()).mc;
                //全向信标
                dr["qxxb_dwlxmc"] = SysData.DWLXByKey(dr["qxxb_dwlx"].ToString()).mc;
                //无方向信标
                dr["wfxxb_dwlxmc"] = SysData.DWLXByKey(dr["wfxxb_dwlx"].ToString()).mc;
                //指点信标
                dr["zdxb_lxxzmc"] = SysData.ZDXBLXXZByKey(dr["zdxb_lxxz"].ToString()).mc;
                //状态信息
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            lbl_sbbh.Text = dt_select.Rows[0]["sbbh"].ToString();
            lbl_sbxh.Text = dt_select.Rows[0]["sbxh"].ToString();
            lbl_sblx.Text = dt_select.Rows[0]["sblxmc"].ToString();
            lbl_tzmczl_tzmc.Text = dt_select.Rows[0]["tzmczl_tzmcmc"].ToString();
            lbl_tzmczl_wz.Text = dt_select.Rows[0]["tzmczl_wzmc"].ToString();
            lbl_tzmczl_sblx.Text = dt_select.Rows[0]["tzmczl_sblxmc"].ToString();
            lbl_yssjc.Text = dt_select.Rows[0]["yssjcmc"].ToString();
            lbl_pl.Text = dt_select.Rows[0]["pl"].ToString();
            lbl_pldw.Text = dt_select.Rows[0]["pldwmc"].ToString();
            lbl_hh.Text = dt_select.Rows[0]["hh"].ToString();
            lbl_txzxdmgc.Text = dt_select.Rows[0]["txzxdmgc"].ToString();
            lbl_tx.Text = dt_select.Rows[0]["tx"].ToString();
            lbl_jfzq.Text = dt_select.Rows[0]["jfzq"].ToString();
            lbl_jfdqrq.Text = dt_select.Rows[0]["jfdqrq"].ToString();
            lbl_tckfsj.Text = dt_select.Rows[0]["tckfsj"].ToString();
            lbl_tcjfsj.Text = dt_select.Rows[0]["tcjfsj"].ToString();
            lbl_tcxy.Text = dt_select.Rows[0]["tcsfxymc"].ToString();
            lbl_tcsm.Text = dt_select.Rows[0]["tcsm"].ToString();
            lbl_mcfxjyrq.Text = dt_select.Rows[0]["mcfxjyrq"].ToString();
            lbl_mcfxjyjg.Text = dt_select.Rows[0]["mcfxjyjgmc"].ToString();
            lbl_mcfxjyjgsm.Text = dt_select.Rows[0]["mcfxjysm"].ToString();
            lbl_ddzbbjjd.Text = dt_select.Rows[0]["ddzb_bj_jd"].ToString();
            lbl_ddzbbjwd.Text = dt_select.Rows[0]["ddzb_bj_wd"].ToString();
            lbl_ddzbwgsjd.Text = dt_select.Rows[0]["ddzb_wgs_jd"].ToString();
            lbl_ddzbwgswd.Text = dt_select.Rows[0]["ddzb_wgs_wd"].ToString();
            lbl_sl.Text = dt_select.Rows[0]["sl"].ToString();
            lbl_mcfxjyrq.Text = dt_select.Rows[0]["mcfxjyrq"].ToString();
            lbl_sbcj.Text = dt_select.Rows[0]["sbcj"].ToString();
            lbl_scgl.Text = dt_select.Rows[0]["scgl"].ToString();
            //lbl_scgldw.Text = dt_select.Rows[0]["scgldwmc"].ToString();
            lbl_sbccbh.Text = dt_select.Rows[0]["sbccbh"].ToString();
            lbl_fgfw.Text = dt_select.Rows[0]["fgfw"].ToString();
            lbl_fgfwdw.Text = dt_select.Rows[0]["fgfwdw"].ToString();
            lbl_sbzt.Text = dt_select.Rows[0]["sbzt"].ToString();
            lbl_jpdzxjl.Text = dt_select.Rows[0]["jpdzxjl"].ToString();
            lbl_pdcd.Text = dt_select.Rows[0]["pdcd"].ToString();
            lbl_synx.Text = dt_select.Rows[0]["synx"].ToString();
            lbl_jlgd.Text = dt_select.Rows[0]["jlgd"].ToString();
            lbl_jlgddx.Text = dt_select.Rows[0]["jlgddx"].ToString();
            lbl_jlgdsl.Text = dt_select.Rows[0]["jlgdsl"].ToString();
            lbl_zlgd.Text = dt_select.Rows[0]["zlgd"].ToString();
            lbl_zlgddx.Text = dt_select.Rows[0]["zlgddx"].ToString();
            lbl_zlgdsl.Text = dt_select.Rows[0]["zlgdsl"].ToString();
            lbl_sbcsqk.Text = dt_select.Rows[0]["sbcsqk"].ToString();
            lbl_xssjc.Text = dt_select.Rows[0]["xssjcmc"].ToString();
            lbl_dbsj.Text = dt_select.Rows[0]["dbsj"].ToString();
            lbl_sbbgr.Text = dt_select.Rows[0]["sbbgr"].ToString();

            lbl_Wxd.Text = dt_select.Rows[0]["wxdsbfshzzj"].ToString();
            lbl_mcjf.Text = dt_select.Rows[0]["mcjfbg"].ToString();
            lbl_plhh.Text = dt_select.Rows[0]["plhhwj"].ToString();
            lbl_sbxkz.Text = dt_select.Rows[0]["sbxkz"].ToString();
            lbl_tzpf.Text = dt_select.Rows[0]["tzpfwj"].ToString();
            lbl_bhq.Text = dt_select.Rows[0]["bhqfw"].ToString();


            //地面设备
            lbl_dmsbtxlx.Text = dt_select.Rows[0]["wxdhdmsb_txlx"].ToString();
            //航向设备
            lbl_hxsblb.Text = dt_select.Rows[0]["hxsb_lbmc"].ToString();
            lbl_hxsbpdh.Text = dt_select.Rows[0]["hxsb_pdh"].ToString();
            lbl_hxsbtxzxh.Text = dt_select.Rows[0]["hxsb_txzxh"].ToString();
            lbl_hxsbtxzlx.Text = dt_select.Rows[0]["hxsb_txzlxmc"].ToString();
            lbl_hxsbtxzzs.Text = dt_select.Rows[0]["hxsb_txzzs"].ToString();
            lbl_hxsbjpdmdjl.Text = dt_select.Rows[0]["hxsb_txzjpdmdjl"].ToString();
            lbl_hxsbjpdrkjl.Text = dt_select.Rows[0]["hxsb_txzjpdrkdjl"].ToString();
            lbl_hxsbpdzxczjl.Text = dt_select.Rows[0]["HXSB_TXZJPDZXCZJL"].ToString();
            //下滑设备
            lbl_sjxhj.Text = dt_select.Rows[0]["xhsb_sjxhj"].ToString();
            lbl_sjrkgd.Text = dt_select.Rows[0]["xhsb_sjrkgd"].ToString();
            lbl_xhtxzlx.Text = dt_select.Rows[0]["xhsb_txzlxmc"].ToString();
            lbl_xhtxzxh.Text = dt_select.Rows[0]["xhsb_txzxh"].ToString();
            lbl_tcxtxgd.Text = dt_select.Rows[0]["XHSB_TCXTXGD"].ToString();
            lbl_mqxtxgd.Text = dt_select.Rows[0]["xhsb_mqxtxgd"].ToString();
            lbl_tcstxgd.Text = dt_select.Rows[0]["XHSB_TCSTXGD"].ToString();
            lbl_mqstxgd.Text = dt_select.Rows[0]["xhsb_mqstxgd"].ToString();
            lbl_txtgd.Text = dt_select.Rows[0]["xhsb_txtgd"].ToString();
            lbl_pdrkncjl.Text = dt_select.Rows[0]["xhsb_jpdrkncjl"].ToString();
            lbl_pdzcxcj.Text = dt_select.Rows[0]["xhsb_jpdzxcj"].ToString();
            lbl_wypdzxx.Text = dt_select.Rows[0]["xhsb_wypdzxx"].ToString();
            lbl_mjjzgrdh.Text = dt_select.Rows[0]["xhsb_mjjzgrdh"].ToString();
            //测距仪
            lbl_cjycpc.Text = dt_select.Rows[0]["cjy_cpc"].ToString();
            lbl_cjypdh.Text = dt_select.Rows[0]["cjy_pdh"].ToString();
            lbl_cjydj.Text = dt_select.Rows[0]["cjy_dj"].ToString();
            lbl_bdh.Text = dt_select.Rows[0]["cjy_bdh"].ToString();
            lbl_cjyptsb.Text = dt_select.Rows[0]["cjy_ptsbmc"].ToString();
            lbl_cjyjspl.Text = dt_select.Rows[0]["cjy_jspl"].ToString();
            lbl_cjyxtyc.Text = dt_select.Rows[0]["cjy_xtyc"].ToString();
            lbl_cjymcjg.Text = dt_select.Rows[0]["cjy_mcjg"].ToString();
            //全向信标
            lbl_qxxbcpc.Text = dt_select.Rows[0]["qxxb_cpc"].ToString();
            lbl_qxxbdwgd.Text = dt_select.Rows[0]["qxxb_dwgd"].ToString();
            lbl_qxxbjkqfw.Text = dt_select.Rows[0]["qxxb_jkqfw"].ToString();
            lbl_qxxbdwzj.Text = dt_select.Rows[0]["qxxb_dwzj"].ToString();
            lbl_qxxbdwlx.Text = dt_select.Rows[0]["qxxb_dwlxmc"].ToString();
            lbl_qxxbpdh.Text = dt_select.Rows[0]["qxxb_pdh"].ToString();
            lbl_qxxbdj.Text = dt_select.Rows[0]["qxxb_dj"].ToString();
            //无方向信标
            lbl_wfxxbcpc.Text = dt_select.Rows[0]["wfxxb_cpc"].ToString();
            lbl_wfxxbdwgd.Text = dt_select.Rows[0]["wfxxb_dwgd"].ToString();
            lbl_wfxxbjkqfw.Text = dt_select.Rows[0]["wfxxb_jkqfw"].ToString();
            lbl_wfxxbdwzj.Text = dt_select.Rows[0]["wfxxb_dwzj"].ToString();
            lbl_wfxxbdwlx.Text = dt_select.Rows[0]["wfxxb_dwlxmc"].ToString();
            lbl_wfxxbpdh.Text = dt_select.Rows[0]["wfxxb_pdh"].ToString();
            lbl_wfxxbdj.Text = dt_select.Rows[0]["wfxxb_dj"].ToString();
            //指点信标
            lbl_zdxbpdh.Text = dt_select.Rows[0]["zdxb_pdh"].ToString();
            lbl_zdxbdj.Text = dt_select.Rows[0]["zdxb_dj"].ToString();
            lbl_zdxblxxz.Text = dt_select.Rows[0]["zdxb_lxxzmc"].ToString();
            //状态信息
            lbl_zt.Text = dt_select.Rows[0]["ztmc"].ToString();
            lbl_bhyy.Text = dt_select.Rows[0]["bhyy"].ToString();
            lbl_scwjsjc.Text = dt_select.Rows[0]["scwjsjc"].ToString();



            lbl_sblx.Text = dt_select.Rows[0]["sblxmc"].ToString();

            lbl_sbflsz.Text = dt_select.Rows[0]["sbflpz"].ToString();
            scwjsjc = dt_select.Rows[0]["scwjsjc"].ToString();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/DHSB_GL.aspx");
        }

        #region 错误信息

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
        #endregion
        #region 文件下载
        protected void btn_wxd_xz_Click(object sender, EventArgs e)
        {

            string fileName = lbl_Wxd.Text.Trim();                               //客户端保存的文件名
            string scwjsjc = lbl_scwjsjc.Text;
            string filePath = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + scwjsjc + "/") + fileName;    //目标文件路径
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
        protected void btn_mcjf_xz_Click(object sender, EventArgs e)
        {
            string fileName = lbl_mcjf.Text;                               //客户端保存的文件名
            string scwjsjc = lbl_scwjsjc.Text;
            string filePath = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + scwjsjc + "/") + fileName;   //目标文件路径
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
        protected void btn_plhh_xz_Click(object sender, EventArgs e)
        {
            string fileName = lbl_plhh.Text;                               //客户端保存的文件名
            string scwjsjc = lbl_scwjsjc.Text;
            string filePath = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + scwjsjc + "/") + fileName;
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
        protected void bth_sbxkz_xz_Click(object sender, EventArgs e)
        {
            string fileName = lbl_sbxkz.Text;                               //客户端保存的文件名
            string scwjsjc = lbl_scwjsjc.Text;
            string filePath = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + scwjsjc + "/") + fileName;
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
        protected void btn_tzpf_xz_Click(object sender, EventArgs e)
        {
            string fileName = lbl_tzpf.Text;                               //客户端保存的文件名
            string scwjsjc = lbl_scwjsjc.Text;
            string filePath = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + scwjsjc + "/") + fileName;
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
        protected void lbl_bhq_xz_Click(object sender, EventArgs e)
        {
            string fileName = lbl_bhq.Text;                               //客户端保存的文件名
            string scwjsjc = lbl_scwjsjc.Text;
            string filePath = Server.MapPath("../shebei/Uploads/SBGL/DHSB/" + scwjsjc + "/") + fileName;
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
        #endregion
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/DHSB_GL.aspx");
        }

    }
}