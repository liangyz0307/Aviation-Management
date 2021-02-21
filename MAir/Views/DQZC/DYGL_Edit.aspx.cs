using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class DYGL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private DYGL yg1;
        private Struct_DY_Pro strcut_dy;
        private string bh;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            yg1 = new DYGL(_usState);
            strcut_dy = new Struct_DY_Pro();
            if (!IsPostBack)
            {
                tbx_jrdzzsj.Attributes.Add("readonly", "readonly");
                tbx_zwzsdyrq.Attributes.Add("readonly", "readonly");
                tbx_djrdsqssj.Attributes.Add("readonly", "readonly");
                tbx_lwrdjjfzsj.Attributes.Add("readonly", "readonly");
                tbx_jjfzpxbbysj.Attributes.Add("readonly", "readonly");
                tbx_qdwfzdxsj.Attributes.Add("readonly", "readonly");
                tbx_dfjzrq.Attributes.Add("readonly", "readonly");
                bh = Request.Params["bh"].ToString();
                ddltBind();
                select_detail();
            }
        }
        private void select_detail()
        {
            dt_detail = yg1.Select_DYDetail(bh).Tables[0];
            tbx_bh.Text = dt_detail.Rows[0]["bh"].ToString();
         //   tbx_dzzmc.Text = dt_detail.Rows[0]["dzzmc"].ToString();
            ddlt_jcdzbmc.Text = dt_detail.Rows[0]["jcdzbmc"].ToString();
            ddlt_dxzmc.Text = dt_detail.Rows[0]["dxzmc"].ToString();
            tbx_dnzw.Text = dt_detail.Rows[0]["dnzw"].ToString();
            ddlt_ygxs.Text = dt_detail.Rows[0]["ygxs"].ToString();
            tbx_jrdzzsj.Text = dt_detail.Rows[0]["jrdzzsj"].ToString().Substring(0, 10);
            tbx_zwzsdyrq.Text = dt_detail.Rows[0]["zwzsdyrq"].ToString().Substring(0, 10); 
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();

            ddlt_dylx.Text = dt_detail.Rows[0]["dylx"].ToString();
            tbx_djrdsqssj.Text = dt_detail.Rows[0]["djrdsqssj"].ToString().Substring(0, 10);
            tbx_lwrdjjfzsj.Text = dt_detail.Rows[0]["lwrdjjfzsj"].ToString().Substring(0, 10);
            tbx_pyr1.Text = dt_detail.Rows[0]["pyr1"].ToString();
            tbx_pyr2.Text = dt_detail.Rows[0]["pyr2"].ToString();
            tbx_jjfzpxbbysj.Text = dt_detail.Rows[0]["jjfzpxbbysj"].ToString().Substring(0, 10);
            tbx_qdwfzdxsj.Text = dt_detail.Rows[0]["qdwfzdxsj"].ToString().Substring(0, 10);
            tbx_jsr1.Text = dt_detail.Rows[0]["jsr1"].ToString();
            tbx_jsr2.Text = dt_detail.Rows[0]["jsr2"].ToString();
            ddlt_zzqk.Text = dt_detail.Rows[0]["zzqk"].ToString();
            tbx_dfje.Text = dt_detail.Rows[0]["dfje"].ToString();
            tbx_dfjzrq.Text = dt_detail.Rows[0]["dfjzrq"].ToString().Substring(0, 10);




        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            int flag = 0;
            //编号
            string bh = tbx_bh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bh))
            {

                lbl_bh.Text = "<span style=\"color:#ff0000\">" + "错误！编号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            ////党组织名称
            //string dzzmc = tbx_dzzmc.Text.ToString().Trim();
            //if (string.IsNullOrEmpty(dzzmc))
            //{

            //    lbl_dzzmc.Text = "<span style=\"color:#ff0000\">" + "错误请输入党组织名称！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_dzzmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
            //基层党支部名称
            if (ddlt_jcdzbmc.SelectedValue.Trim() == "-1")
            {

                lbl_jcdzbmc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jcdzbmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //党小组名称 
            if (ddlt_dxzmc.SelectedValue.Trim() == "-1")
            {

                lbl_dxzmc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dxzmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //党内职务
            string dnzw = tbx_dnzw.Text.ToString().Trim();
            if (string.IsNullOrEmpty(dnzw))
            {

                lbl_dnzw.Text = "<span style=\"color:#ff0000\">" + "错误！请输入党内职务！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dnzw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //用工形式
            if (ddlt_ygxs.SelectedValue.Trim() == "-1")
            {

                lbl_ygxs.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ygxs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //加入党组织时间
            string jrdzzsj = tbx_jrdzzsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jrdzzsj))
            {

                lbl_jrdzzsj.Text = "<span style=\"color:#ff0000\">" + "错误！请输入正确的时间！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jrdzzsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //转为正式党员日期
            string zwzsdyrq = tbx_zwzsdyrq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zwzsdyrq))
            {

                lbl_zwzsdyrq.Text = "<span style=\"color:#ff0000\">" + "错误！请输入正确的时间！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zwzsdyrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //备注
            //string bz = tbx_bz.Text.ToString().Trim();
            //if (string.IsNullOrEmpty(bz))
            //{

            //    lbl_bz.Text = "<span style=\"color:#ff0000\">" + "错误！备注不能为空！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
          
          
            if (flag == 1) { return; }
            strcut_dy.p_bh = tbx_bh.Text.ToString();
            strcut_dy.p_dzzmc = "航务综合党总支";
            strcut_dy.p_jcdzbmc = ddlt_jcdzbmc.SelectedValue.ToString();
            strcut_dy.p_dxzmc = ddlt_dxzmc.SelectedValue.ToString();
            strcut_dy.p_dnzw = tbx_dnzw.Text.ToString();
            strcut_dy.p_ygxs = ddlt_ygxs.SelectedValue.ToString();
            strcut_dy.p_jrdzzsj = Convert.ToDateTime(tbx_jrdzzsj.Text.ToString());
            strcut_dy.p_zwzsdyrq = Convert.ToDateTime(tbx_zwzsdyrq.Text.ToString());
            strcut_dy.p_bz = tbx_bz.Text.ToString();
            strcut_dy.p_ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
            strcut_dy.p_czsj = DateTime.Parse(DateTime.Now.ToString());

            strcut_dy.p_dylx = ddlt_dylx.SelectedValue.ToString();
            strcut_dy.p_djrdsqssj = Convert.ToDateTime(tbx_djrdsqssj.Text.ToString());
            strcut_dy.p_lwrdjjfzsj = Convert.ToDateTime(tbx_lwrdjjfzsj.Text.ToString());
            strcut_dy.p_pyr1 = tbx_pyr1.Text.ToString();
            strcut_dy.p_pyr2 = tbx_pyr2.Text.ToString();
            strcut_dy.p_jjfzpxbbysj = Convert.ToDateTime(tbx_jjfzpxbbysj.Text.ToString());
            strcut_dy.p_qdwfzdxsj = Convert.ToDateTime(tbx_qdwfzdxsj.Text.ToString());
            strcut_dy.p_jsr1 = tbx_jsr1.Text.ToString();
            strcut_dy.p_jsr2 = tbx_jsr2.Text.ToString();
            strcut_dy.p_zzqk = ddlt_zzqk.SelectedValue.ToString();
            strcut_dy.p_dfje = tbx_dfje.Text.ToString();
            strcut_dy.p_dfjzrq = Convert.ToDateTime(tbx_dfjzrq.Text.ToString());

            yg1.DY_Edit(strcut_dy);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"更改成功！\")</script>");
        }
        private void ddltBind()
        {
            //党员类型
            ddlt_dylx.DataTextField = "mc";
            ddlt_dylx.DataValueField = "bm";
            ddlt_dylx.DataSource = SysData.DYLX().Copy();
            ddlt_dylx.DataBind();
            ddlt_dylx.Items.Insert(0, new ListItem("请选择", "-1"));
            //转正情况
            ddlt_zzqk.DataTextField = "mc";
            ddlt_zzqk.DataValueField = "bm";
            ddlt_zzqk.DataSource = SysData.ZZQK().Copy();
            ddlt_zzqk.DataBind();
            ddlt_zzqk.Items.Insert(0, new ListItem("请选择", "-1"));
            //用工形式
            ddlt_ygxs.DataTextField = "mc";
            ddlt_ygxs.DataValueField = "bm";
            ddlt_ygxs.DataSource = SysData.YGXS().Copy();
            ddlt_ygxs.DataBind();
            ddlt_ygxs.Items.Insert(0, new ListItem("请选择", "-1"));
            //党小组名称
            ddlt_dxzmc.DataTextField = "mc";
            ddlt_dxzmc.DataValueField = "bm";
            ddlt_dxzmc.DataSource = SysData.DXZMC().Copy();
            ddlt_dxzmc.DataBind();
            ddlt_dxzmc.Items.Insert(0, new ListItem("请选择", "-1"));
            //基层党支部名称
            ddlt_jcdzbmc.DataTextField = "mc";
            ddlt_jcdzbmc.DataValueField = "bm";
            ddlt_jcdzbmc.DataSource = SysData.JCDZBMC().Copy();
            ddlt_jcdzbmc.DataBind();
            ddlt_jcdzbmc.Items.Insert(0, new ListItem("请选择", "-1"));



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
            Response.Redirect("../DQZC/DYCX.aspx", false);
        }
    }
}