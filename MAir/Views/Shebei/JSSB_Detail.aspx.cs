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
    public partial class JSSB_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private JSSB jssb;
        private int id;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            jssb = new JSSB(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }
        protected void select_detail() {
            id = Convert.ToInt32(Request.Params["id"]);
            dt_detail = jssb.Select_JSSB_Detail(id);
            lbl_sbbh.Text = dt_detail.Rows[0]["sbbh"].ToString();
            lbl_sblx.Text = SysData.SBLXByKey(dt_detail.Rows[0]["sblx"].ToString()).mc;
            lbl_wz.Text = SysData.SBWZByKey(dt_detail.Rows[0]["wz"].ToString()).mc;
            lbl_ssjc.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["ssjc"].ToString()).mc;
            lbl_sszx.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["sszx"].ToString()).mc;
            lbl_dtzzdqsj.Text = dt_detail.Rows[0]["dtzzdqsj"].ToString();
            lbl_sbzt.Text = SysData.SBZTByKey(dt_detail.Rows[0]["sbzt"].ToString()).mc;
            lbl_sbsccj.Text = dt_detail.Rows[0]["sbsccj"].ToString();
            lbl_sbccbh.Text = dt_detail.Rows[0]["sbccbh"].ToString();
            lbl_sc.Text = dt_detail.Rows[0]["sc"].ToString();
            lbl_sjssbm.Text = dt_detail.Rows[0]["sjssbmmc"].ToString();
            lbl_sstz.Text = dt_detail.Rows[0]["sstz"].ToString();
            lbl_sbxh.Text = dt_detail.Rows[0]["sbxh"].ToString();
            //lbl_tzmczl.Text = dt_detail.Rows[0]["tzmczl"].ToString();
            lbl_jgrq.Text = dt_detail.Rows[0]["jgrq"].ToString();
            lbl_tcjyrq.Text = dt_detail.Rows[0]["tcjyrq"].ToString();
            lbl_tckfhbarq.Text = dt_detail.Rows[0]["tckfhbarq"].ToString();
            lbl_zyjscstx.Text = dt_detail.Rows[0]["zyjscstx"].ToString();
            lbl_gdfs.Text = dt_detail.Rows[0]["gdfs"].ToString();
            lbl_csfs.Text = dt_detail.Rows[0]["csfs"].ToString();
            lbl_ddzb_bj54_jd.Text = dt_detail.Rows[0]["ddzb_bj54_jd"].ToString();
            lbl_ddzb_bj54_wd.Text = dt_detail.Rows[0]["ddzb_bj54_wd"].ToString();
            lbl_ddzb_wgs84_jd.Text = dt_detail.Rows[0]["ddzb_wgs84_jd"].ToString();
            lbl_ddzb_wgs84_wd.Text = dt_detail.Rows[0]["ddzb_wgs84_wd"].ToString();
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();
            if (dt_detail.Rows[0]["sblx"].ToString().Equals("0303")) {
                div_yjld.Visible = false;
                div_ejld.Visible = false;
                //div_cmjssb.Visible = false;
                div_zdxgjsxtsb.Visible = false;
                div_dddwxt.Visible = false;
                div_zdhxt.Visible = false;
                div_zdzbxt.Visible = false;
            } else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0307")) {
                div_yjld.Visible = false;
                div_ejld.Visible = false;
                div_cmjssb.Visible = false;
                div_zdxgjsxtsb.Visible = false;
                div_dddwxt.Visible = false;
                div_zdhxt.Visible = false;
                //div_zdzbxt.Visible = false;
            }
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0301")) {
                //div_yjld.Visible = false;
                div_ejld.Visible = false;
                div_cmjssb.Visible = false;
                div_zdxgjsxtsb.Visible = false;
                div_dddwxt.Visible = false;
                div_zdhxt.Visible = false;
                div_zdzbxt.Visible = false;
                //一级雷达
                lbl_ldgzpl1.Text = dt_detail.Rows[0]["ld_gzpl1"].ToString();
                lbl_csxbxh1.Text = dt_detail.Rows[0]["ld_csxbxh1"].ToString();
                lbl_ldfzgl1.Text = dt_detail.Rows[0]["ld_fzgl1"].ToString();
                lbl_txszdd1.Text = dt_detail.Rows[0]["ld_txszdd1"].ToString();
                lbl_txjcgc1.Text = dt_detail.Rows[0]["ld_txjcgc1"].ToString();
                lbl_txgd1.Text = dt_detail.Rows[0]["ld_txgd1"].ToString();
                lbl_txsccj1.Text = dt_detail.Rows[0]["ld_txsccj1"].ToString();
                lbl_txxh_lx1.Text = dt_detail.Rows[0]["ld_txxh_lx1"].ToString();
                lbl_fgqk1.Text = dt_detail.Rows[0]["ld_fgqk1"].ToString();
                lbl_wxdtzzyxq1.Text = dt_detail.Rows[0]["wxdtzzyxq1"].ToString();
                lbl_ld_sc1.Text = dt_detail.Rows[0]["ld_sc1"].ToString();
            }
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0302")) {
                div_yjld.Visible = false;
                //div_ejld.Visible = false;
                div_cmjssb.Visible = false;
                div_zdxgjsxtsb.Visible = false;
                div_dddwxt.Visible = false;
                div_zdhxt.Visible = false;
                div_zdzbxt.Visible = false;
                //二级雷达
                lbl_ld_gzpl2.Text = dt_detail.Rows[0]["ld_gzpl2"].ToString();
                lbl_ld_csxbxh2.Text = dt_detail.Rows[0]["ld_csxbxh2"].ToString();
                lbl_ld_fzgl2.Text = dt_detail.Rows[0]["ld_fzgl2"].ToString();
                lbl_ld_txszdd2.Text = dt_detail.Rows[0]["ld_txszdd2"].ToString();
                lbl_ld_txjcgc2.Text = dt_detail.Rows[0]["ld_txjcgc2"].ToString();
                lbl_ld_txgd2.Text = dt_detail.Rows[0]["ld_txgd2"].ToString();
                lbl_ld_txsccj2.Text = dt_detail.Rows[0]["ld_txsccj2"].ToString();
                lbl_ld_txxh_lx2.Text = dt_detail.Rows[0]["ld_txxh_lx2"].ToString();
                lbl_ld_fgqk2.Text = dt_detail.Rows[0]["ld_fgqk2"].ToString();
                lbl_wxdtzzyxq2.Text = dt_detail.Rows[0]["wxdtzzyxq2"].ToString();
                lbl_ld_sc2.Text = dt_detail.Rows[0]["ld_sc2"].ToString();
            }
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0304")) {
                div_yjld.Visible = false;
                div_ejld.Visible = false;
                div_cmjssb.Visible = false;
                //div_zdxgjsxtsb.Visible = false;
                div_dddwxt.Visible = false;
                div_zdhxt.Visible = false;
                div_zdzbxt.Visible = false;
                //自动相关监视系统设备
                lbl_zdxgjsxtsb_gzpl.Text = dt_detail.Rows[0]["zdxgjsxtsb_gzpl"].ToString();
                lbl_zdxgjsxtsb_sfpcsxb.Text = dt_detail.Rows[0]["zdxgjsxtsb_sfpcsxb"].ToString();
                lbl_zdxgjsxtsb_csxbxh.Text = dt_detail.Rows[0]["zdxgjsxtsb_csxbxh"].ToString();
                lbl_zdxgjsxtsb_csxbsmsdzdm.Text = dt_detail.Rows[0]["zdxgjsxtsb_csxbsmsdzdm"].ToString();
                lbl_zdxgjsxtsb_cyzzrs.Text = dt_detail.Rows[0]["zdxgjsxtsb_cyzzrs"].ToString();
                lbl_zdxgjsxtsb_fzgl.Text = dt_detail.Rows[0]["zdxgjsxtsb_fzgl"].ToString();
                lbl_zdxgjsxtsb_csfs.Text = dt_detail.Rows[0]["zdxgjsxtsb_csfs"].ToString();
                lbl_zdxgjsxtsb_txszdd.Text = dt_detail.Rows[0]["zdxgjsxtsb_txszdd"].ToString();
                lbl_zdxgjsxtsb_txjcgc.Text = dt_detail.Rows[0]["zdxgjsxtsb_txjcgc"].ToString();
                lbl_zdxgjsxtsb_txsccj.Text = dt_detail.Rows[0]["zdxgjsxtsb_txsccj"].ToString();
                lbl_zdxgjsxtsb_txxh_lx.Text = dt_detail.Rows[0]["zdxgjsxtsb_txxh_lx"].ToString();
                lbl_zdxgjsxtsb_wxdtzzyxq.Text = dt_detail.Rows[0]["zdxgjsxtsb_wxdtzzyxq"].ToString();
                lbl_zdxgjsxtsb_sc.Text = dt_detail.Rows[0]["zdxgjsxtsb_sc"].ToString();
            }
            else if (dt_detail.Rows[0]["sblx"].ToString().Equals("0305")){
                div_yjld.Visible = false;
                div_ejld.Visible = false;
                div_cmjssb.Visible = false;
                div_zdxgjsxtsb.Visible = false;
                //div_dddwxt.Visible = false;
                div_zdhxt.Visible = false;
                div_zdzbxt.Visible = false;
                //多点定位系统
                lbl_dddwxt_gzpl.Text = dt_detail.Rows[0]["dddwxt_gzpl"].ToString();
                lbl_dddwxt_fstfzgl.Text = dt_detail.Rows[0]["dddwxt_fstfzgl"].ToString();
                lbl_dddwxt_txszdd.Text = dt_detail.Rows[0]["dddwxt_txszdd"].ToString();
                lbl_dddwxt_txjcgc.Text = dt_detail.Rows[0]["dddwxt_txjcgc"].ToString();
                lbl_dddwxt_txsccj.Text = dt_detail.Rows[0]["dddwxt_txsccj"].ToString();
                lbl_dddwxt_txxh_lx.Text = dt_detail.Rows[0]["dddwxt_txxh_lx"].ToString();
                lbl_dddwxt_wxdtzzyxq.Text = dt_detail.Rows[0]["dddwxt_wxdtzzyxq"].ToString();
                lbl_dddwxt_sc.Text = dt_detail.Rows[0]["dddwxt_sc"].ToString();
            }
            else if(dt_detail.Rows[0]["sblx"].ToString().Equals("0306"))
            {
                div_yjld.Visible = false;
                div_ejld.Visible = false;
                div_cmjssb.Visible = false;
                div_zdxgjsxtsb.Visible = false;
                div_dddwxt.Visible = false;
                //div_zdhxt.Visible = false;
                div_zdzbxt.Visible = false;
                //自动化系统
                lbl_zdhxt_jsyyjxl.Text = dt_detail.Rows[0]["zdhxt_jsyyjxl"].ToString();
                lbl_zdhxt_xtrjbb.Text = dt_detail.Rows[0]["zdhxt_xtrjbb"].ToString();
                lbl_zdhxt_xtgm.Text = dt_detail.Rows[0]["zdhxt_xtgm"].ToString();
                lbl_zdhxt_ATCgzsqs.Text = dt_detail.Rows[0]["zdhxt_ATCgzsqs"].ToString();
                lbl_zdhxt_A_SMGCSxtfj.Text = dt_detail.Rows[0]["zdhxt_A_SMGCSxtfj"].ToString();
                lbl_zdhxt_cyzzrs.Text = dt_detail.Rows[0]["zdhxt_cyzzrs"].ToString();
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
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Server.Transfer("JSSB_GL.aspx");
        }
        protected void btn_sc_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_sc.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/JSSB/") + fileName;          //目标文件路径
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
        protected void btn_sc1_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_ld_sc1.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/JSSB/") + fileName;          //目标文件路径
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
        protected void btn_sc2_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_ld_sc2.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/JSSB/") + fileName;          //目标文件路径
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
        protected void btn_zdxgjsxtsb_sc_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_zdxgjsxtsb_sc.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/JSSB/") + fileName;          //目标文件路径
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
        protected void btn_dddwxt_sc_down_Click(object sender, EventArgs e)
        {
            string fileName = lbl_dddwxt_sc.Text;                               //客户端保存的文件名 
            string filePath = Server.MapPath("../Shebei/UpLoads/SBGL/JSSB/") + fileName;          //目标文件路径
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