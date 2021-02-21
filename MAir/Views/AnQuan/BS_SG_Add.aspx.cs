using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using Sys;
namespace CUST.WKG
{
    public partial class BS_SG_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private SG sg;
        private Struct_SG struct_sg;
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            sg = new SG(_usState);
            if (!IsPostBack)
            {
                tbx_bssj.Attributes.Add("readonly", "readonly");
                tbx_sfsj.Attributes.Add("readonly", "readonly");
                Bind();

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
            Response.Redirect("../AnQuan/BS_SG.aspx", true);
        }
        //绑定固定值
        private void Bind()
        {
            lbl_bh.Text = _usState.userXM;
            lbl_bsgw.Text = _usState.userGWMC.ToString().Trim();

            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));


            DataTable dt = new DataTable();
            struct_sg.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_sg.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            dt = sg.Select_FZR(struct_sg);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_sg.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_sg.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sg.Select_FZR(struct_sg);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_sg.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_sg.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sg.Select_FZR(struct_sg);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
        }
        protected void btn_zrr_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_yg.SelectedValue.ToString();
            tbx_sqfzr.Text = ddlt_yg.SelectedItem.Text;
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_sg.p_bsbh = _usState.userGWDM + sg.SelectBS_SGMaxBH();
            struct_sg.p_bsyg = _usState.userLoginName; ;//员工编号
            struct_sg.p_bsgw = _usState.userGWDM;//报送岗位
            struct_sg.p_bsip = Page.Request.UserHostAddress; 
            struct_sg.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());//报送时间
            struct_sg.p_sgfzr =ddlt_yg.SelectedValue.ToString();//事故负责人
            struct_sg.p_sgxq = tbx_sgxq.Text.ToString().Trim();//事故详情
            struct_sg.p_sfsj = Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim());//事发时间
            struct_sg.p_bz = tbx_bz.Text.ToString().Trim();//备注
            struct_sg.p_zt = "0";
            struct_sg.p_bhyy = "";
            struct_sg.p_xtsj = DateTime.Now;
            struct_sg.p_czfs = "01";
            struct_sg.p_czxx = "位置：航务综合信息报送系统->事故->添加      描述： 报送编号：[" + struct_sg.p_bsbh + "]报送岗位："
                + struct_sg.p_bsgw + "系统时间：" + struct_sg.p_xtsj + "报送IP：" + struct_sg.p_bsip
                + "报送时间：" + struct_sg.p_bssj + "事故负责人：" + struct_sg.p_sgfzr + "事故详情：" + struct_sg.p_sgxq
                + "事发时间：" + struct_sg.p_sfsj 
                + "备注：" + struct_sg.p_bz;
            sg.Insert_SG(struct_sg);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Response.Redirect("../AnQuan/BS_SG.aspx", true);
        }
    }
}