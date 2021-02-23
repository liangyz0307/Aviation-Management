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
    public partial class BS_SG_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private SG sg;
        private Struct_SG struct_sg;
        private static string bsbh;
        private static DataTable dt_detail;
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
                bsbh = Request.QueryString["bsbh"];
                tbx_bssj.Attributes.Add("readonly", "readonly");
                tbx_sfsj.Attributes.Add("readonly", "readonly");
                select_detail();
                Bind();
            }
        }
        protected void Bind()
        {
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
        protected void select_detail()
        {

            dt_detail = sg.Select_SG_Detail(bsbh);
            dt_detail.Columns.Add("bm");
            dt_detail.Columns.Add("gw");
            foreach (DataRow dr in dt_detail.Rows)
            {
                dr["gw"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;
            }
            lbl_bh.Text = dt_detail.Rows[0]["bsrxm"].ToString();
            lbl_bsgw.Text = dt_detail.Rows[0]["gw"].ToString();
            tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            tbx_sgxq.Text = dt_detail.Rows[0]["sgxq"].ToString();
            tbx_sqfzr.Text = dt_detail.Rows[0]["fzrxm"].ToString();
            tbx_sfsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["sfsj"]).ToString("yyyy-MM-dd");
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int check_rz = 0;
            struct_sg.p_bsbh = bsbh;
            struct_sg.p_bsyg = dt_detail.Rows[0]["bsyg"].ToString();//员工编号
            struct_sg.p_bsgw = _usState.userGWDM;//报送岗位
            struct_sg.p_xtsj = DateTime.Now;
            struct_sg.p_bsip = Page.Request.UserHostAddress; //报送IP
            struct_sg.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());//报送时间
            struct_sg.p_sgxq = tbx_sgxq.Text.ToString().Trim();//事故详情
            struct_sg.p_sgfzr = dt_detail.Rows[0]["sgfzr"].ToString();
            struct_sg.p_sfsj = Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim());//事发时间
            struct_sg.p_bz = tbx_bz.Text.ToString().Trim();//备注
            struct_sg.p_czfs = "02";
            struct_sg.p_czxx = "位置：航务综合信息报送系统->事故->编辑     报送编号：[" + struct_sg.p_bsbh + "] 描述：";
            //报送岗位
            if (struct_sg.p_bsgw != dt_detail.Rows[0]["gw"].ToString())
            {
                struct_sg.p_czxx += "报送岗位：【" + dt_detail.Rows[0]["gw"].ToString() + "】->【" + struct_sg.p_bsgw + "】";
                check_rz = 1;
            }
            //报送时间
            if (struct_sg.p_bssj != Convert.ToDateTime(tbx_bssj.Text.ToString().Trim()))
            {
                struct_sg.p_czxx += "报送时间：【" + dt_detail.Rows[0]["bssj"].ToString() + "】->【" + struct_sg.p_bssj + "】";
                check_rz = 1;
            }

            //事故详情
            if (struct_sg.p_sgxq != tbx_sgxq.Text.ToString().Trim())
            {
                struct_sg.p_czxx += "事故详情：【" + dt_detail.Rows[0]["sgxq"].ToString() + "】->【" + struct_sg.p_sgxq + "】";
                check_rz = 1;
            }
            //事故负责人
            if (struct_sg.p_sgfzr != tbx_sqfzr.Text.ToString().Trim())
            {
                struct_sg.p_czxx += "事故负责人：【" + dt_detail.Rows[0]["sgfzr"].ToString() + "】->【" + struct_sg.p_sgfzr + "】";
                check_rz = 1;
            }
          
            //事发时间
            if (struct_sg.p_sfsj != Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim()))
            {
                struct_sg.p_czxx += "事发时间：【" + dt_detail.Rows[0]["sfsj"].ToString() + "】->【" + struct_sg.p_sfsj + "】";
                check_rz = 1;
            }
            
            //备注
            if (struct_sg.p_bz != tbx_bz.Text.ToString().Trim())
            {
                struct_sg.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_sg.p_bz + "】";
                check_rz = 1;
            }
            if (check_rz == 0)
            {
                struct_sg.p_czxx += "未修改";
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
                Response.Redirect("../AnQuan/BS_SG.aspx", true);
            }
            else
            {
                sg.Update_SG(struct_sg);
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
                Response.Redirect("../AnQuan/BS_SG.aspx", true);
            }
        }

    }
}