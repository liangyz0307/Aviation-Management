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
    public partial class BS_TQCZ_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private TQCZ tqcz;
        private Struct_TQCZ struct_tqcz;
        private static  string bsbh;
        private static  DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tqcz = new TQCZ(_usState);
            if (!IsPostBack)
            {
                bsbh = Request.QueryString["bsbh"];
                tbx_bgsj.Attributes.Add("readonly", "readonly");
                tbx_bssj.Attributes.Add("readonly", "readonly");
                tbx_sfsj.Attributes.Add("readonly", "readonly");
                ddltBind();
                select_detail();
            }
        }
        private void ddltBind()
        {
            //报送类型
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
            struct_tqcz.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_tqcz.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            dt = tqcz.Select_FZR(struct_tqcz);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();

            ddlt_zrbm.DataSource = SysData.BM().Copy();
            ddlt_zrbm.DataTextField = "mc";
            ddlt_zrbm.DataValueField = "bm";
            ddlt_zrbm.DataBind();
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
            Response.Redirect("../AnQuan/BS_TQCZ.aspx", true);
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_tqcz.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_tqcz.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = tqcz.Select_FZR(struct_tqcz);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_tqcz.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_tqcz.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = tqcz.Select_FZR(struct_tqcz);
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
            tbx_fzr.Text= ddlt_yg.SelectedItem.Text;
        }


         protected void select_detail()
        {
            dt_detail = tqcz.Select_TQCZ_Detail(bsbh);
            dt_detail.Columns.Add("bm");
            dt_detail.Columns.Add("gw");
            foreach (DataRow dr in dt_detail.Rows)
            {
                dr["gw"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;
             
            }
            lbl_bh.Text = dt_detail.Rows[0]["bsyg"].ToString();
            lbl_bsgw.Text = dt_detail.Rows[0]["gw"].ToString();
            tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            tbx_bgsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bgsj"]).ToString("yyyy-MM-dd");
            tbx_gzqk.Text = dt_detail.Rows[0]["gzqk"].ToString();
            tbx_sbyxqk.Text = dt_detail.Rows[0]["sbyxqk"].ToString();
            tbx_sfsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["sfsj"]).ToString("yyyy-MM-dd");
            tbx_sjqk.Text = dt_detail.Rows[0]["sjqk"].ToString();
            ddlt_zrbm.SelectedValue = dt_detail.Rows[0]["zrdw"].ToString();
            tbx_fzr.Text = dt_detail.Rows[0]["fzrxm"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int check_rz = 0;
            struct_tqcz.p_bsbh = bsbh;
            struct_tqcz.p_bsyg = _usState.userLoginName;//员工编号
            struct_tqcz.p_bsgw = _usState.userGWDM;//报送岗位
            struct_tqcz.p_bsip = Page.Request.UserHostAddress;//报送IP
            struct_tqcz.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());//报送时间
            struct_tqcz.p_gzqk = tbx_gzqk.Text.ToString().Trim();//管制情况
            struct_tqcz.p_sjqk = tbx_sjqk.Text.ToString().Trim();//事件涉及的航空器和机组有关情况
            struct_tqcz.p_sbyxqk = tbx_sbyxqk.Text.ToString().Trim();//空管相关设备运行状况
            struct_tqcz.p_sfsj = Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim());//事发时间
            struct_tqcz.p_zrdw = ddlt_zrbm.SelectedValue.ToString();
            struct_tqcz.p_lxr = dt_detail.Rows[0]["lxr"].ToString();//负责人
            struct_tqcz.p_bgsj = Convert.ToDateTime(tbx_bgsj.Text.ToString().Trim());//报告时间
            struct_tqcz.p_bz = tbx_bz.Text.ToString().Trim();//备注
            struct_tqcz.p_czfs = "02";
            struct_tqcz.p_czxx = "位置：航务综合信息报送系统->特情处置->编辑     报送编号：[" + struct_tqcz.p_bsbh + "] 描述：";
            struct_tqcz.p_xtsj = DateTime.Now;
            //报送岗位
            if (struct_tqcz.p_bsgw != dt_detail.Rows[0]["gw"].ToString())
            {
                //已修改
                struct_tqcz.p_czxx += "报送岗位：【" + dt_detail.Rows[0]["gw"].ToString() + "】->【" + struct_tqcz.p_bsgw + "】";
                check_rz = 1;
            }


            //报送时间
            if (struct_tqcz.p_bssj != Convert.ToDateTime(tbx_bssj.Text.ToString().Trim()))
            {
                //已修改
                struct_tqcz.p_czxx += "报送时间：【" + dt_detail.Rows[0]["bssj"].ToString() + "】->【" + struct_tqcz.p_bssj + "】";
                check_rz = 1;
            }

            //管制情况
            if (struct_tqcz.p_gzqk != tbx_gzqk.Text.ToString().Trim())
            {
                //已修改
                struct_tqcz.p_czxx += "管制情况：【" + dt_detail.Rows[0]["gzqk"].ToString() + "】->【" + struct_tqcz.p_gzqk + "】";
                check_rz = 1;
            }
            //事件涉及的航空器和机组有关情况
            if (struct_tqcz.p_sjqk != tbx_sjqk.Text.ToString().Trim())
            {
                //已修改
                struct_tqcz.p_czxx += "事件涉及的航空器和机组有关情况：【" + dt_detail.Rows[0]["sjqk"].ToString() + "】->【" + struct_tqcz.p_sjqk + "】";
                check_rz = 1;
            }
            //空管相关设备运行状况
            if (struct_tqcz.p_sbyxqk != tbx_sbyxqk.Text.ToString().Trim())
            {
                //已修改
                struct_tqcz.p_czxx += "空管相关设备运行状况：【" + dt_detail.Rows[0]["sbyxqk"].ToString() + "】->【" + struct_tqcz.p_sbyxqk + "】";
                check_rz = 1;
            }
           //事发时间
            if (struct_tqcz.p_sfsj != Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim()))
            {
                //已修改
                struct_tqcz.p_czxx += "事发时间：【" + dt_detail.Rows[0]["sfsj"].ToString() + "】->【" + struct_tqcz.p_sfsj + "】";
                check_rz = 1;
            }
            //报告时间
            if (struct_tqcz.p_bgsj!= Convert.ToDateTime(tbx_bgsj.Text.ToString().Trim()))
            {
                //已修改
                struct_tqcz.p_czxx += "报告时间：【" + dt_detail.Rows[0]["bgsj"].ToString() + "】->【" + struct_tqcz.p_bgsj + "】";
                check_rz = 1;
            }
            //备注
            if (struct_tqcz.p_bz != tbx_bz.Text.ToString().Trim())
            {
                //已修改
                struct_tqcz.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_tqcz.p_bz + "】";
                check_rz = 1;
            }
            if (check_rz == 0)
            {
                struct_tqcz.p_czxx += "未修改";
                Response.Redirect("../AnQuan/BS_TQCZ.aspx", true);
            }
            else
            {
                tqcz.Update_TQCZ(struct_tqcz);
                Response.Redirect("../AnQuan/BS_TQCZ.aspx", true);
            }

        }
    }
}