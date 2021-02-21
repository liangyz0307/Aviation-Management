using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using System.Data;
using Sys;
using CUST.Sys;
using CUST;
using CUST.Tools;
using System.IO;

namespace CUST.WKG
{
    public partial class JCJL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private JCGL jcgl;
        private Struct_jcgl struct_jcgl;
        static string syrbh;
        public string rwid;         //任务ID
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            jcgl = new JCGL(_usState);
            if (!IsPostBack)
            {
                tbx_jcsj.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
            }

        }
        private void yg_bind()
        {
            //_usState.
            lbl_jcr.Text = _usState.userXM;
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        private void ddltBind()
        {
            //字典项的绑定
            //被检单位
            ddlt_bjdw.DataTextField = "mc";
            ddlt_bjdw.DataValueField = "bm";
            ddlt_bjdw.DataSource = SysData.BM().Copy();
            ddlt_bjdw.DataBind();
            ddlt_bjdw.Items.Insert(0, new ListItem("请选择", "-1"));
            //检查单
            ddlt_tbdw.DataTextField = "mc";
            ddlt_tbdw.DataValueField = "bm";
            ddlt_tbdw.DataSource = SysData.TBDW().Copy();
            ddlt_tbdw.DataBind();
            ddlt_tbdw.Items.Insert(0, new ListItem("请选择", "-1"));
            //检查项目
            string tbdw = ddlt_tbdw.SelectedValue.ToString();
            DataTable dt_jcxm = new DataTable();
            dt_jcxm = jcgl.Select_JCRW(tbdw);
            ddlt_jcxm.DataSource = dt_jcxm;
            ddlt_jcxm.DataTextField = "jcxm";
            ddlt_jcxm.DataValueField = "jcxm";
            ddlt_jcxm.DataBind();
            ddlt_jcxm.Items.Insert(0, new ListItem("请选择", "-1"));

            //检查结果
            ddlt_jcjg.DataTextField = "mc";
            ddlt_jcjg.DataValueField = "bm";
            ddlt_jcjg.DataSource = SysData.JCJG().Copy();
            ddlt_jcjg.DataBind();
            ddlt_jcjg.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void ddlt_tbdw_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string tbdw = ddlt_tbdw.SelectedValue.ToString();
            string jcxm = ddlt_jcxm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcgl.Select_JCRW(tbdw);
            ddlt_jcxm.DataSource = dt;
            ddlt_jcxm.DataTextField = "jcxm";
            ddlt_jcxm.DataValueField = "jcxm";
            ddlt_jcxm.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_syr.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr.Items.Count > 0)
            {
                tbx_tzzrry.Text += ddlt_syr.SelectedItem.Text + ",";
                syrbh += ddlt_syr.SelectedValue.ToString() + ",";
            }
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("JCJL.aspx", true);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {


            #region 输入校验
            int flag = 0;
            //检查项目
            if (ddlt_jcxm.SelectedValue.Trim() == "-1")
            {
                if (ddlt_tbdw.SelectedValue.Trim() == "-1")
                {
                    lbl_jcxm.Text = "<span style=\"color:#ff0000\">" + "该填报单位未发布检查任务" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_jcxm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                    flag = 1;
                }
            }
            else
            {
                lbl_jcxm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //检查结果
            if (ddlt_jcjg.SelectedValue.Trim() == "-1")
            {

                lbl_jcjg.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jcjg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //整改意见
            string zgyj = tbx_zgyj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zgyj))
            {

                lbl_zgyj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zgyj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //通知责任人员
            string tzzrry = tbx_tzzrry.Text.ToString().Trim();
            if (string.IsNullOrEmpty(tzzrry))
            {

                lbl_tzzrry.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tzzrry.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //落实情况反馈
            string lsqkfk = tbx_lsqkfk.Text.ToString().Trim();
            if (string.IsNullOrEmpty(lsqkfk))
            {

                lbl_lsqkfk.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_lsqkfk.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //被检单位
            if (ddlt_bjdw.SelectedValue.Trim() == "-1")
            {

                lbl_bjdw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            #endregion
            if (tbx_jcsj.Text.Trim().ToString().Equals(""))
            {
                struct_jcgl.jcsj = new DateTime();
            }
            else
            {
                struct_jcgl.jcsj = DateTime.Parse(tbx_jcsj.Text.Trim().ToString()); //检查时间
            }
            struct_jcgl.bjdw = ddlt_bjdw.SelectedValue.ToString().Trim();           //被检单位
            struct_jcgl.jcd = ddlt_tbdw.SelectedValue.ToString().Trim();            //填报单位
            struct_jcgl.jcxm = ddlt_jcxm.SelectedValue.ToString().Trim();           //检查项目
            struct_jcgl.jcjg = ddlt_jcjg.SelectedValue.ToString().Trim();           //检查结果
            struct_jcgl.zgyj = tbx_zgyj.Text.ToString().Trim();                     //整改意见
            struct_jcgl.jcjg = ddlt_jcjg.SelectedValue.ToString().Trim();           //检查结果
            struct_jcgl.tzzrdw = ddlt_bmdm.SelectedValue.ToString().Trim();         //通知责任单位
            struct_jcgl.tzzrry = tbx_tzzrry.Text.ToString().Trim();                 //整改意见
            struct_jcgl.lsqkfk = tbx_lsqkfk.Text.ToString().Trim();                 //落实情况反馈
            struct_jcgl.bz = tbx_bz.Text.ToString().Trim();                         //备注
            struct_jcgl.jcr = lbl_jcr.Text;                                         //检查人

            string jcd = struct_jcgl.jcd;
            string jcxm = struct_jcgl.jcxm;
            DataTable dt = new DataTable();
            dt = jcgl.Select_JCRWID(jcd, jcxm);
            struct_jcgl.rwid = Convert.ToInt32(dt.Rows[0]["id"].ToString());
            string upload_file = "";
            try
            {
              
                if (fiup_wj.HasFile == true)
                {
                    string fileloadr = _usState.userLB + _usState.userLoginName;
                    string exName = System.IO.Path.GetExtension(fiup_wj.FileName);
                    string FileName = Path.GetFileNameWithoutExtension(fiup_wj.PostedFile.FileName) + _usState.userLB + _usState.userLoginName;
                    string allFileloadr = Server.MapPath("./JCJLPic/" + fileloadr + "/");
                    if (!Directory.Exists(allFileloadr))
                    {
                        Directory.CreateDirectory(allFileloadr);
                    }
                    upload_file = allFileloadr + FileName + exName;
                    DirectoryInfo root = new DirectoryInfo(allFileloadr);
                    foreach (FileInfo f in root.GetFiles())
                    {
                        f.Delete();
                    }
                    fiup_wj.PostedFile.SaveAs(upload_file);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择文件！\")</script>");
                  //  Response.End();
                    return;
                }
            }

            catch (Exception esx)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"上传文件错误，请重新上传！\")</script>");
              //  Response.End();
                return;
            }
            //struct_jcgl.filepath = upload_file;
            jcgl.Insert_JCJL(struct_jcgl);
            //jcgl.Update_JCRWZT(struct_jcgl);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            //Response.Redirect("JCJL.aspx", true);
            Response.Write("<script languge='javascript'>alert('添加成功');</script>");
            Response.Write("<script>window.location='JCJL.aspx'</script>");


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

        //protected void btn_sc_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (fiup_wj.HasFile == true)
        //        {
        //            string fileloadr = _usState.userLB + _usState.userLoginName;
        //            string exName = System.IO.Path.GetExtension(fiup_wj.FileName);
        //            string FileName = Path.GetFileNameWithoutExtension(fiup_wj.PostedFile.FileName) + _usState.userLB + _usState.userLoginName;
        //            string allFileloadr = Server.MapPath("./JCJLPic/" + fileloadr + "/");
        //            if (!Directory.Exists(allFileloadr))
        //            {
        //                Directory.CreateDirectory(allFileloadr);
        //            }
        //            string upload_file = allFileloadr + FileName + exName;
        //            DirectoryInfo root = new DirectoryInfo(allFileloadr);
        //            foreach (FileInfo f in root.GetFiles())
        //            {
        //                f.Delete();
        //            }
        //            fiup_wj.PostedFile.SaveAs(upload_file);
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择文件！\")</script>");
        //        }
        //    }
        //    catch
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"上传文件出错，请重新上传！\")</script>");

        //    }

        //}
    }
}