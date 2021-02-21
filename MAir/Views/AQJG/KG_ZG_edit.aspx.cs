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
    public partial class KG_ZG_edit : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        static string zrrbh;
        private KG_ZG kg_zg;
        private Struct_KG_ZG struct_kg_zg;
        private DataTable dt_detail;
        public string p_id;
        public string rwid;

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
                id = Convert.ToInt32(Request.Params["id"].ToString());
                tbx_zgsx.Attributes.Add("readonly", "readonly");
                yg_bind();
                select_detail();
            }
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

            struct_kg_zg.p_id = int.Parse(Request.Params["id"].ToString()); //惩罚ID
            //struct_kg_zg.p_id = p_id;
            struct_kg_zg.p_bmdm = _usState.userBMDM;
            struct_kg_zg.p_tbdw = ddlt_jcd.SelectedValue.ToString().Trim();//检查单
            struct_kg_zg.p_zgxm = tbx_zgxm.Text.ToString().Trim();//整改项目
            struct_kg_zg.p_zgjd = tbx_zgjd.Text.ToString().Trim();//整改进度
            struct_kg_zg.p_zrr = ddlt_zrr.SelectedValue.ToString().Trim();//责任人
            struct_kg_zg.p_zgfa = tbx_zgfa.Text.ToString().Trim();//整改方案
            struct_kg_zg.p_fxkzcs = tbx_fxkzcs.Text.ToString().Trim();//风险控制措施
            struct_kg_zg.p_zgsx = DateTime.Parse(tbx_zgsx.Text.ToString().Trim());//整改时限
            struct_kg_zg.p_wtly = tbx_wtly.Text.ToString().Trim();//问题来源
            struct_kg_zg.p_wtlb = tbx_wtlb.Text.ToString().Trim();//问题类别
            struct_kg_zg.p_rwid = "1";//任务ID
            struct_kg_zg.p_czfs = "03";
            struct_kg_zg.p_czxx = "位置：安全监管->整改管理->修改      描述：任务编号：" + _usState.userLoginName
                 + "起止日期：" + struct_kg_zg.p_zgsx + "截止日期："
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


            kg_zg.Update_ZG(struct_kg_zg);//调用修改信息的存储过程
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            Response.Redirect("../AQJG/KG_ZG_select.aspx", true);


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
            Response.Redirect("../AQJG/KG_ZG_select.aspx", true);
        }
        protected void select_detail()
        {
            lbl_id.Text = Request.QueryString["id"];
            int id = int.Parse(Request.QueryString["id"]);
            dt_detail = kg_zg.Select_ZG_Detail(id);
            ddlt_jcd.SelectedValue = dt_detail.Rows[0]["tbdw"].ToString();//检查单
            tbx_zgxm.Text = dt_detail.Rows[0]["zgxm"].ToString();//整改项目
            tbx_zgfa.Text = dt_detail.Rows[0]["zgfa"].ToString();//整改方案
            tbx_zgjd.Text = dt_detail.Rows[0]["zgjd"].ToString();//整改进度
            tbx_fxkzcs.Text = dt_detail.Rows[0]["fxkzcs"].ToString();//风险控制措施
            tbx_zrr.Text = dt_detail.Rows[0]["zrrxm"].ToString();//责任人
            tbx_zgsx.Text = DateTime.Parse(dt_detail.Rows[0]["zgsx"].ToString()).ToString("yyyy-MM-dd");//整改时限
            tbx_wtly.Text = dt_detail.Rows[0]["wtly"].ToString();//问题来源
            tbx_wtlb.Text = dt_detail.Rows[0]["wtlb"].ToString();//问题类别
            rwid = dt_detail.Rows[0]["id"].ToString();//任务ID
        }
    }
}

