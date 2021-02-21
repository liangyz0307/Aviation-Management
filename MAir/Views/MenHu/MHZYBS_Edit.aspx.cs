
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using CUST.MKG;
using Sys;

namespace CUST.WKG
{
    public partial class MHZYBS_Edit : System.Web.UI.Page
    {
        private UserState userstate;
        private ZYBS zybs;
        private Struct_ZYBS struct_zybs;
        private string bsbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            if (userstate.userSFSCDL == "0")
            {
                Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
                Response.End();
                return;
            }

            zybs = new ZYBS(userstate);
            struct_zybs = new Struct_ZYBS();
            bsbh = Request.Params["bsbh"].ToString();
            if (!IsPostBack)
            {
                //bind_drop();

                select_detail(bsbh);
            }

        }
        //private void bind_drop()
        //{
        //    //报送类型
        //    ddlt_bslx.DataTextField = "mc";
        //    ddlt_bslx.DataValueField = "bm";
        //    ddlt_bslx.DataSource = SysData.BSLX().Copy();
        //    ddlt_bslx.DataBind();
        //    ddlt_bslx.Items.Insert(0, new ListItem("全部", "-1"));

           
        //}

        protected void select_detail(string sbbh)
        {

            DataTable dt_detail = zybs.SelectBS_ZYBS_Detail(bsbh);
            tbx_bsygbh.Text = dt_detail.Rows[0]["bsyg"].ToString();
            tbx_bsgw.Text = dt_detail.Rows[0]["bsgw"].ToString();
            tbx_bslx.Text = SysData.BSLXByKey(dt_detail.Rows[0]["bslx"].ToString()).mc;
            tbx_bsip.Text = dt_detail.Rows[0]["bsip"].ToString();
            tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            tbx_bsms.Text = dt_detail.Rows[0]["bsms"].ToString();
            tbx_jjfa.Text = dt_detail.Rows[0]["jjfa"].ToString(); 
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            //#region 校验
            //int flag = 0;
            //string reg = string.Empty;
            //reg = @"^\d{6}$";
            ////报送类型
            //if (ddlt_bslx.SelectedValue.Trim() == "-1")
            //{

            //    lbl_bslx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_bslx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            ////报送时间
            //if (string.IsNullOrEmpty(tbx_bssj.Text.ToString().Trim()))
            //{

            //    lbl_bssj.Text = "<span style=\"color:#ff0000\">" + "报送时间不能为空" + "</span>";
            //    flag = 1;
            //}

            //else
            //{
            //    lbl_bssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
            ////支线名称
            //if (ddlt_zxmc.SelectedValue.Trim() == "-1")
            //{

            //    lbl_zxmc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_zxmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            ////工作内容
            //if (string.IsNullOrEmpty(tbx_gznr.Text.ToString().Trim()))
            //{

            //    lbl_gznr.Text = "<span style=\"color:#ff0000\">" + "工作内容不能为空" + "</span>";
            //    flag = 1;
            //}

            //else
            //{
            //    lbl_gznr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
            ////完成进度
            //if (string.IsNullOrEmpty(tbx_wcjd.Text.ToString().Trim()))
            //{

            //    lbl_wcjd.Text = "<span style=\"color:#ff0000\">" + "完成进度不能为空" + "</span>";
            //    flag = 1;
            //}

            //else
            //{
            //    lbl_wcjd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
            ////工作轮次
            //if (string.IsNullOrEmpty(tbx_gzlc.Text.ToString().Trim()))
            //{

            //    lbl_gzlc.Text = "<span style=\"color:#ff0000\">" + "工作轮次不能为空" + "</span>";
            //    flag = 1;
            //}

            //else
            //{
            //    lbl_gzlc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
            //if (flag == 1) { return; }
            //#endregion
            DataTable dt_detail = zybs.SelectBS_ZYBS_Detail(bsbh);
            struct_zybs = new CUST.MKG.Struct_ZYBS();
            struct_zybs.p_bsbh = bsbh;
            struct_zybs.p_bsyg = tbx_bsygbh.Text.ToString().Trim();
            struct_zybs.p_bsgw = tbx_bsgw.Text .ToString ().Trim ();
            struct_zybs.p_bslx = dt_detail.Rows[0]["bslx"].ToString();
            struct_zybs.p_bsip = tbx_bsip.Text.ToString().Trim();
            struct_zybs.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());
            struct_zybs.p_bsms = tbx_bsms.Text.ToString().Trim();
            struct_zybs.p_jjfa = tbx_jjfa.Text.ToString().Trim();

            struct_zybs.p_spr = "";
            struct_zybs.p_bz = tbx_bz.Text.ToString().Trim();
            try
            {
                int check_rz = 0;
              
                DataRow dt_row = dt_detail.Rows[0];
                struct_zybs.p_czxx = "位置:航务综合报送系统->自愿报送信息->编辑  [报送编号：" + struct_zybs.p_bsbh + "      描述：";
                //if (struct_zybs.p_bslx != dt_row["bslx"].ToString())
                //{
                //    struct_zybs.p_czxx += "报送类型：【" + SysData.BSLXByKey(dt_row["bslx"].ToString()).ms + "】->【" + SysData.BSLXByKey(struct_zybs.p_bslx).ms + "】";
                //    check_rz = 1;
                //}
               
                if (struct_zybs.p_bssj != Convert.ToDateTime(dt_row["bssj"]))
                {
                    struct_zybs.p_czxx += "报送时间：【" + dt_row["bssj"].ToString() + "】->【" + struct_zybs.p_bssj + "】";
                    check_rz = 1;
                }
                if (struct_zybs.p_bsms != dt_row["bsms"].ToString())
                {
                    struct_zybs.p_czxx += "报送模式：【" + dt_row["bsms"].ToString() + "】->【" + struct_zybs.p_bsms + "】";
                    check_rz = 1;
                }
                if (struct_zybs.p_jjfa != dt_row["jjfa"].ToString())
                {
                    struct_zybs.p_czxx += "解决方案：【" + dt_row["jjfa"].ToString() + "】->【" + struct_zybs.p_jjfa + "】";
                    check_rz = 1;
                }
              
                if (struct_zybs.p_bz != dt_row["bz"].ToString())
                {
                    struct_zybs.p_czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_zybs.p_bz + "】";
                    check_rz = 1;
                }

                if (check_rz != 0)
                {
                    struct_zybs.p_czfs = "02";
                    zybs.UpdateBS_ZYBS(struct_zybs);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    tbx_bsygbh.Enabled = false;
                    tbx_bsgw.Enabled = false;
                    tbx_bsip.Enabled = false;
                    tbx_bssj.Enabled = false;
                    tbx_bsms.Enabled = false;
                    tbx_jjfa.Enabled = false;
                    tbx_bz.Enabled = false;
                    btn_save.Visible = false;
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    tbx_bsygbh.Enabled = false;
                    tbx_bsgw.Enabled = false;
                    tbx_bsip.Enabled = false;
                    tbx_bssj.Enabled = false;
                    tbx_bsms.Enabled = false;
                    tbx_jjfa.Enabled = false;
                    tbx_bz.Enabled = false;
                    btn_save.Visible = false;
                }
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }

        protected void btn_bj_Click(object sender, EventArgs e)
        {

           
            tbx_bssj.Enabled = true;
         
            tbx_bsms.Enabled = true;
            tbx_jjfa.Enabled = true;
           
            tbx_bz.Enabled = true;
            btn_save.Visible = true;
            tbx_bssj.Attributes.Add("readonly", "readonly");
          
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("MHZYBS_GL.aspx", true);
        }
    }
}