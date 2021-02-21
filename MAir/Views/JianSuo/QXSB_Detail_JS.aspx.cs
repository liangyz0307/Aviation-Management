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
    public partial class QXSB_Detail_JS : System.Web.UI.Page
    {
        private UserState _usState;
        private QXSB qxsb;
        private Struct_QXSB struct_qxsb;
        private string id;
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
            string id = struct_qxsb.p_id;
            if (!IsPostBack)
            {
                Repeater1.Visible = false;


                select_detail();

            }
        }





        private void select_detail()
        {
            id = Request.Params["id"].ToString();
            DataTable dt_detail = qxsb.Select_QXSBbySBBH(id).Tables[0];
            lbl_sbmc.Text = dt_detail.Rows[0]["sbmc"].ToString();
            lbl_xh.Text = dt_detail.Rows[0]["xh"].ToString();
            lbl_zzcj.Text = dt_detail.Rows[0]["zzcj"].ToString();
            lbl_ccbh.Text = dt_detail.Rows[0]["ccbh"].ToString();
            lbl_tcrq.Text = dt_detail.Rows[0]["tcrq"].ToString();
            lbl_jgrq.Text = dt_detail.Rows[0]["jgrq"].ToString();
            lbl_qysj.Text = SysData.DWLXByKey(dt_detail.Rows[0]["qysj"].ToString()).mc;
            lbl_yxqk.Text = dt_detail.Rows[0]["yxqk"].ToString();
            lbl_sbzt.Text = SysData.SBZTByKey(dt_detail.Rows[0]["sbzt"].ToString()).mc;
            lbl_sbyt.Text = SysData.SBYTByKey(dt_detail.Rows[0]["sbyt"].ToString()).mc;
            lbl_sszx.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["sszx"].ToString()).mc;
            lbl_azwz.Text = dt_detail.Rows[0]["azwz"].ToString();
            lbl_jdrq.Text = dt_detail.Rows[0]["jdrq"].ToString();
            lbl_jdyxq.Text = dt_detail.Rows[0]["jdyxq"].ToString();
            lbl_jdzsbh.Text = dt_detail.Rows[0]["jdzsbh"].ToString();
            lbl_jdys.Text = dt_detail.Rows[0]["jdys"].ToString();
            lbl_jdfs.Text = SysData.JDFSByKey(dt_detail.Rows[0]["jdfs"].ToString()).mc; ;
            lbl_jddw.Text = dt_detail.Rows[0]["jddw"].ToString();
            lbl_jdjl.Text = dt_detail.Rows[0]["jdjl"].ToString();
            lbl_fljcrq.Text = dt_detail.Rows[0]["fljcrq"].ToString();
            lbl_fljcyxq.Text = dt_detail.Rows[0]["fljcyxq"].ToString();
            lbl_dzscz.Text = dt_detail.Rows[0]["dzscz"].ToString();
            lbl_sbgzll.Text = dt_detail.Rows[0]["sbgzll"].ToString();
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            string lujing = dt_detail.Rows[0]["sccgqjdzs"].ToString();//证书路径
            //  DateTime scsj = Convert.ToDateTime(dt.Rows[0]["scsj"].ToString());//上传时间
            string filename = lujing.Substring(lujing.LastIndexOf("\\") + 1);
            lbl_sccgqjdzs.Text = filename.Substring(16);
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_sjszbm.Text = dt_detail.Rows[0]["bmmc"].ToString();

            bind_rep();
            Repeater1.Visible = true;

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
            Response.Redirect("../JianSuo/JS_SBGL.aspx");
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
                        //Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                        //Response.Redirect("../main/TXSB_GL.aspx");
                        //
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"文件不存在！\")</script>");
                        //Response.End();
                        return;
                    }
                }
                catch { }

            }

        }
    }
}