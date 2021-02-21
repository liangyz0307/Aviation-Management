using CUST;
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
    public partial class KG_ZG_add : System.Web.UI.Page
    {
        private UserState _usState;
        static string zrrbh;
        private KG_ZG kg_zg;
        protected int cpage = 0;
        protected int psize = 0;
        private static DataTable dt = new DataTable();
        private Struct_KG_ZG struct_kg_zg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            kg_zg = new KG_ZG(_usState);
            if (!IsPostBack)
            {
                tbx_zgsx.Attributes.Add("readonly", "readonly");
                yg_bind();
            }
        }
        //检查单绑定
        protected void ddlt_jcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tbdw = ddlt_jcd.SelectedValue.ToString();
            string jcxm = ddlt_zgxm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = kg_zg.Select_JCJL(tbdw);
            ddlt_zgxm.DataSource = dt;
            ddlt_zgxm.DataTextField = "jcxm";
            ddlt_zgxm.DataValueField = "jcxm";
            ddlt_zgxm.DataBind();
        }
        private void yg_bind()
        {
            //责任人
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            //ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = kg_zg.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zrr.DataSource = dt;
            ddlt_zrr.DataTextField = "xm";
            ddlt_zrr.DataValueField = "bh";
            ddlt_zrr.DataBind();

            //检查单
            ddlt_jcd.DataTextField = "mc";
            ddlt_jcd.DataValueField = "bm";
            ddlt_jcd.DataSource = SysData.TBDW().Copy();
            ddlt_jcd.DataBind();
            ddlt_jcd.Items.Insert(0, new ListItem("请选择", "-1"));

            //整改项目
            string tbdw = ddlt_jcd.SelectedValue.ToString();
            DataTable dt_zgxm = new DataTable();
            dt_zgxm = kg_zg.Select_JCJL(tbdw);
            ddlt_zgxm.DataSource = dt_zgxm;
            ddlt_zgxm.DataTextField = "jcxm";
            ddlt_zgxm.DataValueField = "jcxm";
            ddlt_zgxm.DataBind();
            ddlt_zgxm.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = kg_zg.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zrr.DataSource = dt;
            ddlt_zrr.DataTextField = "xm";
            ddlt_zrr.DataValueField = "bh";
            ddlt_zrr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = kg_zg.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zrr.DataSource = dt;
            ddlt_zrr.DataTextField = "xm";
            ddlt_zrr.DataValueField = "bh";
            ddlt_zrr.DataBind();
        }
        //选好员工保存的方法
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_zrr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_zrr.Items.Count > 0)
            {
                tbx_zrr.Text = ddlt_zrr.SelectedItem.Text;
                zrrbh = ddlt_zrr.SelectedValue.ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int flag = 0;
            //整改时限
            string zgsx = tbx_zgsx.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zgsx))
            {

                lbl_zgsx.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zgsx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //责任人
            string zrr = tbx_zrr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zrr))
            {

                lbl_zrr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zrr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //整改项目
            if (ddlt_zgxm.SelectedValue.Trim() == "-1")
            {
                if (ddlt_jcd.SelectedValue.Trim() == "-1")
                {
                    lbl_zgxm.Text = "<span style=\"color:#ff0000\">" + "该填报单位没有整改任务" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zgxm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                    flag = 1;
                }
            }
            else
            {
                lbl_zgxm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //整改方案
            string zgfa = tbx_zgfa.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zgfa))
            {
                lbl_zgfa.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zgfa.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //整改进度
            string zgjd = tbx_zgjd.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zgjd))
            {
                lbl_zgjd.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zgjd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1) { return; }
            // #endregion
            // struct_baqsjcf.p_id = baqsjcf.SelectIDMaxID(_usState.userGWDM);
            if (tbx_zgsx.Text.Trim().ToString().Equals(""))
            {
                struct_kg_zg.p_zgsxks = new DateTime();
                struct_kg_zg.p_zgsxjs = new DateTime();
            }
            else
            {
                struct_kg_zg.p_zgsxks = DateTime.Parse(tbx_zgsx.Text.Trim().ToString());//开始日期
                struct_kg_zg.p_zgsxjs = DateTime.Parse(tbx_zgsx.Text.Trim().ToString());//结束日期
            }
            struct_kg_zg.p_id = 0;
            struct_kg_zg.p_tbdw = ddlt_jcd.SelectedValue.ToString().Trim();//检查单
            struct_kg_zg.p_zgxm = ddlt_zgxm.SelectedValue.ToString().Trim();//整改项目

            string jcd = struct_kg_zg.p_tbdw;
            string jcxm = struct_kg_zg.p_zgxm;
            DataTable dt = new DataTable();
            dt = kg_zg.Select_JCJLID(jcd, jcxm);
            struct_kg_zg.p_rwid = dt.Rows[0]["rwid"].ToString();

            struct_kg_zg.p_zgjd = tbx_zgjd.Text.ToString().Trim();//整改进度
            struct_kg_zg.p_zrr = ddlt_zrr.SelectedValue.ToString().Trim();//责任人
            struct_kg_zg.p_zgfa = tbx_zgfa.Text.ToString().Trim();//整改方案
            struct_kg_zg.p_fxkzcs = tbx_fxkzcs.Text.ToString().Trim();//风险控制措施
            struct_kg_zg.p_zgsx = DateTime.Parse(tbx_zgsx.Text.ToString().Trim());//整改时限
            struct_kg_zg.p_wtly = tbx_wtly.Text.ToString().Trim();//问题来源
            struct_kg_zg.p_wtlb = tbx_wtlb.Text.ToString().Trim();//问题类别
            struct_kg_zg.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            struct_kg_zg.p_czfs = "2";
            struct_kg_zg.p_czxx = "位置：安全监管->整改->添加   描述：员工编号："
                + "起止日期：" + struct_kg_zg.p_zgsxks + "截止日期：" + struct_kg_zg.p_zgsxjs
               + "备注：";

            string upload_file = "";
            try
            {

                if (fiup_wj.HasFile == true)
                {
                    string fileloadr = _usState.userLB + _usState.userLoginName;
                    string exName = System.IO.Path.GetExtension(fiup_wj.FileName);
                    string FileName = Path.GetFileNameWithoutExtension(fiup_wj.PostedFile.FileName) + _usState.userLB + _usState.userLoginName;
                    string allFileloadr = Server.MapPath("./ZGPic/" + fileloadr + "/");
                    if (!Directory.Exists(allFileloadr))
                    {
                        Directory.CreateDirectory(allFileloadr);
                    }
                    upload_file = allFileloadr + FileName + exName;
                    //DirectoryInfo root = new DirectoryInfo(allFileloadr);
                    //foreach (FileInfo f in root.GetFiles())
                    //{
                    //    f.Delete();
                    //}
                    fiup_wj.PostedFile.SaveAs(upload_file);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择文件！\")</script>");
                    return;
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"上传文件出错，请重新上传！\")</script>");
               // Response.End();
                return;
            }

            struct_kg_zg.filepath = upload_file;
            kg_zg.Insert_ZG(struct_kg_zg);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("KG_ZG_select.aspx");

        

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
        Response.Redirect("../AQJG/KG_ZG_select.aspx");
    }

    protected void btn_sc_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (fiup_wj.HasFile == true)
        //    {
        //        string fileloadr = _usState.userLB + _usState.userLoginName;
        //        string exName = System.IO.Path.GetExtension(fiup_wj.FileName);
        //        string FileName = Path.GetFileNameWithoutExtension(fiup_wj.PostedFile.FileName) + _usState.userLB + _usState.userLoginName;
        //        string allFileloadr = Server.MapPath("./ZGPic/" + fileloadr + "/");
        //        if (!Directory.Exists(allFileloadr))
        //        {
        //            Directory.CreateDirectory(allFileloadr);
        //        }
        //        string upload_file = allFileloadr + FileName + exName;
        //        DirectoryInfo root = new DirectoryInfo(allFileloadr);
        //        foreach (FileInfo f in root.GetFiles())
        //        {
        //            f.Delete();
        //        }
        //        fiup_wj.PostedFile.SaveAs(upload_file);
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择文件！\")</script>");
        //    }
        //}
        //catch
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"上传文件出错，请重新上传！\")</script>");

        //}
    }
}
}