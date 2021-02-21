using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sys;
using CUST.Sys;
using CUST;
using CUST.Tools;
using CUST.MKG;
using System.IO;

namespace CUST.WKG
{
    public partial class JCJL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private JCGL jcjl;
        private Struct_jcgl struct_jcgl;
        static string syrbh;
        public int p_id;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            jcjl = new JCGL(_usState);
            if (!IsPostBack)
            {
                tbx_jcsj.Attributes.Add("readonly", "readonly");
                lbl_jcr.Text = _usState.userXM;
                p_id = int.Parse(Request.QueryString["rwid"]);
                select_detail();
                yg_bind();
                ddltBind();
            }
        }

        private void ddltBind()
        {
            //字典项的绑定
            //被检单位
            ddlt_bjdw.DataTextField = "mc";
            ddlt_bjdw.DataValueField = "bm";
            ddlt_bjdw.DataSource = SysData.BM().Copy();
            ddlt_bjdw.DataBind();
            ddlt_bjdw.Items.Insert(0, new ListItem("全部", "-1"));

            //检查结果
            ddlt_jcjg.DataTextField = "mc";
            ddlt_jcjg.DataValueField = "bm";
            ddlt_jcjg.DataSource = SysData.JCJG().Copy();
            ddlt_jcjg.DataBind();
            ddlt_jcjg.Items.Insert(0, new ListItem("请选择", "-1"));
            
        }
        private void yg_bind()
        {
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
            dt = jcjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        
        # region 部门岗位绑定
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = jcjl.Select_YGbyBMGW(bmdm, gwdm);
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
            dt = jcjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        # endregion
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_syr.SelectedValue.ToString();

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
        public void select_detail()
        {

            DataTable dt = new DataTable();
            dt_detail = jcjl.Select_JCJL_Detil(p_id).Tables[0];

            tbx_jcsj.Text = DateTime.Parse(dt_detail.Rows[0]["jcsj"].ToString()).ToString("yyyy-MM-dd");
            ddlt_bjdw.SelectedValue = dt_detail.Rows[0]["bjdw"].ToString();
            tbx_tbdw.Text = SysData.TBDWByKey(dt_detail.Rows[0]["jcd"].ToString()).mc;
            tbx_jcxm.Text = dt_detail.Rows[0]["jcxm"].ToString();
            ddlt_jcjg.SelectedValue = dt_detail.Rows[0]["jcjg"].ToString();
            tbx_zgyj.Text = dt_detail.Rows[0]["zgyj"].ToString();
            tbx_tzzrry.Text = dt_detail.Rows[0]["tzzrry"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            tbx_lsqkfk.Text = dt_detail.Rows[0]["lsqkfk"].ToString();
            lbl_jcr.Text = dt_detail.Rows[0]["jcr"].ToString();
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

        protected void btn_Save_Click(object sender, EventArgs e)
        {

            //int check_jcsj = 0;
            if (tbx_jcsj.Text.Trim().ToString().Equals(""))
            {
                struct_jcgl.jcsj = new DateTime();

            }
            else
            {
                struct_jcgl.jcsj = DateTime.Parse(tbx_jcsj.Text.Trim().ToString());//检查时间

            }
            struct_jcgl.rwid = Convert.ToInt32(Request.Params["rwid"].ToString());
            struct_jcgl.bjdw = ddlt_bjdw.SelectedValue.ToString().Trim();//被检单位

            //struct_jcgl.jcd = tbx_tbdw.Text.ToString().Trim();//填报单位

            struct_jcgl.jcd = "1";
            struct_jcgl.jcxm = tbx_jcxm.Text.ToString().Trim();//检查项目
            struct_jcgl.jcjg = ddlt_jcjg.SelectedValue.ToString().Trim();//检查结果
            struct_jcgl.zgyj = tbx_zgyj.Text.ToString().Trim();//整改意见
            struct_jcgl.tzzrdw = ddlt_bmdm.SelectedValue.ToString().Trim();//通知责任单位
            struct_jcgl.tzzrry = tbx_tzzrry.Text.ToString().Trim();//通知责任人员
            struct_jcgl.lsqkfk = tbx_lsqkfk.Text.ToString().Trim();//落实情况反馈
            struct_jcgl.bz = tbx_bz.Text.ToString().Trim();//备注
            struct_jcgl.jcr = lbl_jcr.Text;//检查人


            //struct_jcgl.p_czfs = "02";
            //struct_jcgl.p_czxx = "位置：安全监管管理系统->检查记录->编辑  检查人：[" + struct_jcgl.jcr + "]   描述：";

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

            jcjl.Update_JCJL(struct_jcgl);
            //jcjl.Update_JCRWZT(struct_jcgl);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            //Server.Transfer("JCJL.aspx");
            Response.Write("<script languge='javascript'>alert('已保存');</script>");
            Response.Write("<script>window.location='JCJL.aspx'</script>");
        }
    }
}