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
    public partial class DYGL_Add : System.Web.UI.Page
    {
        public DYZX dyzx;
        private UserState _usState;
        public int cpage = 0;
        public int psize = 0;
        private DYGL yg1;
        private Struct_DY_Pro strcut_dy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dyzx = new DYZX(_usState);
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

                ddltBind();
                
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int flag = 0;
            //编号
            string bh = ddlt_ygxm.SelectedValue.ToString().Trim();
            if (string.IsNullOrEmpty(bh))
            {

                lbl_ygxm.Text = "<span style=\"color:#ff0000\">" + "错误！编号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ygxm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            //加入党组织时间和转为正式党员日期
            if ((tbx_jrdzzsj.Text == "" || tbx_zwzsdyrq.Text == ""))
            {
                lbl_jrdzzsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                string jrdzzsj = tbx_jrdzzsj.Text;
                string zwzsdyrq = tbx_zwzsdyrq.Text;
                if (jrdzzsj.CompareTo(zwzsdyrq) > 0)
                {
                    lbl_jrdzzsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zwzsdyrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }




            if (flag == 1) { return; }
            strcut_dy.p_bh = ddlt_ygxm.SelectedValue.ToString();
            strcut_dy.p_dzzmc = "航务管理党总支";
            strcut_dy.p_jcdzbmc = ddlt_jcdzbmc.SelectedItem.Text.Trim();
           
            strcut_dy.p_dxzmc = ddlt_dxzmc.SelectedItem.Text.Trim();
            strcut_dy.p_dnzw = tbx_dnzw.Text.ToString();
            strcut_dy.p_ygxs = ddlt_ygxs.SelectedValue.ToString();
            strcut_dy.p_jrdzzsj = Convert.ToDateTime(tbx_jrdzzsj.Text.ToString());
            strcut_dy.p_zwzsdyrq = Convert.ToDateTime(tbx_zwzsdyrq.Text.ToString());
            strcut_dy.p_bz = tbx_bz.Text.ToString();
            
            strcut_dy.p_ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
            strcut_dy.p_czsj = DateTime.Parse(DateTime.Now.ToString());
            strcut_dy.p_tzcz = ddlt_jcdzbmc.SelectedIndex.ToString();

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

            yg1.DY_Add(strcut_dy);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
        }
        private void ddltBind()
        {

            
            //用工形式
            ddlt_ygxs.DataTextField = "mc";
            ddlt_ygxs.DataValueField = "bm";
            ddlt_ygxs.DataSource = SysData.YGXS().Copy();
            ddlt_ygxs.DataBind();
            ddlt_ygxs.Items.Insert(0, new ListItem("请选择", "-1"));
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
            //部门
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

            dt = dyzx.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_ygxm.DataSource = dt;
            ddlt_ygxm.DataTextField = "xm";
            ddlt_ygxm.DataValueField = "bh";
            ddlt_ygxm.DataBind();

        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = dyzx.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_ygxm.DataSource = dt;
            ddlt_ygxm.DataTextField = "xm";
            ddlt_ygxm.DataValueField = "bh";
            ddlt_ygxm.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = dyzx.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_ygxm.DataSource = dt;
            ddlt_ygxm.DataTextField = "xm";
            ddlt_ygxm.DataValueField = "bh";
            ddlt_ygxm.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_ygxm.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_ygxm.Items.Count > 0)
            {
                tbx_ygxm.Text = ddlt_ygxm.SelectedItem.Text;
                //yxdybh = ddlt_ygxm.SelectedValue.ToString();
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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DYCX.aspx", false);
        }
    }
}