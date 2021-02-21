using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brettle.Web.NeatUpload;
using System.IO;
using Sys;
using CUST.Tools;

namespace CUST.WKG
{
    public partial class SBGZ_Detail_JS : System.Web.UI.Page
    {
        private UserState _usState;

        private WHWX whwx;
        private Struct_SBGZ struct_sbgz;
        private int id;
        private string sb_lx;
        private string saveFileName;
        private DataTable dt_detail;
        private string SaveFileName;
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

                select_detail();

            }

        }
        private void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = whwx.Select_SBGZ_Detail(id);


            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            lbl_clbz.Text = dt_detail.Rows[0]["clbz"].ToString();
            lbl_czgc.Text = dt_detail.Rows[0]["czgc"].ToString();
            lbl_gzbjcljg.Text = dt_detail.Rows[0]["gzbjcljg"].ToString();
            lbl_gzjssj.Text = dt_detail.Rows[0]["gzjssj"].ToString();
            lbl_gzqssj.Text = dt_detail.Rows[0]["gzqssj"].ToString();
            lbl_gzxx.Text = dt_detail.Rows[0]["gzxx"].ToString();
            lbl_gzyyfx.Text = dt_detail.Rows[0]["gzyyfx"].ToString();
            lbl_jycs.Text = dt_detail.Rows[0]["jycs"].ToString();
            lbl_ljsc.Text = dt_detail.Rows[0]["ljsc"].ToString();
            lbl_sbbh.Text = dt_detail.Rows[0]["sbbh"].ToString();
            lbl_tlgzdpcff.Text = dt_detail.Rows[0]["tlgzpcff"].ToString();
            // lbl_whwjsc.Text = dt_detail.Rows[0]["sbbh"].ToString();
            lbl_wxr.Text = dt_detail.Rows[0]["wxr"].ToString();
            lbl_zcyx.Text = dt_detail.Rows[0]["zcyx"].ToString();
            lbl_sblx.Text = SysData.SBLXByKey(dt_detail.Rows[0]["sblx"].ToString()).mc;
            lbl_wxrbm.Text = SysData.BMByKey(dt_detail.Rows[0]["wxrbm"].ToString()).mc;
            lbl_wxrgw.Text = SysData.GWByKey(dt_detail.Rows[0]["wxrgw"].ToString()).mc;
            lbl_sjssbm.Text = SysData.BMByKey(dt_detail.Rows[0]["bmdm"].ToString()).mc;
            lbl_sbzl.Text = SysData.SBZLByKey(dt_detail.Rows[0]["sbzl"].ToString()).mc;
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
                                                                 //   lbl_shsj.Text = dt_detail.Rows[0]["shsj"].ToString();//审核时间
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态

        }


        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SBGL.aspx");
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
                        //Response.Redirect("../main/SBGZ_GL.aspx");
                        //Response.End();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"文件不存在！\")</script>");
                        return;
                    }
                }
                catch { }

            }
        }
    }
}