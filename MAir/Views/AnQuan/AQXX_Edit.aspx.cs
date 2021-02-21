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
    public partial class AQXX_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private FXY fxy;
        private Struct_FXY struct_fxy;
        private static string bsbh;
       // private string bszt;
        private static DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            fxy = new FXY(_usState);
            if (!IsPostBack)
            {
                bsbh = Request.QueryString["bsbh"];
             
                tbx_bssj.Attributes.Add("readonly", "readonly");
                ddltBind();
                select_detail();
            }
        }
        private void ddltBind()
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
            struct_fxy.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_fxy.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            dt = fxy.Select_FZR(struct_fxy);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();

            ddlt_zrbm.DataSource = SysData.BM().Copy();
            ddlt_zrbm.DataTextField = "mc";
            ddlt_zrbm.DataValueField = "bm";
            ddlt_zrbm.DataBind();     

            ddlt_tqcz.DataSource = SysData.TQCZ().Copy();
            ddlt_tqcz.DataTextField = "mc";
            ddlt_tqcz.DataValueField = "bm";
            ddlt_tqcz.DataBind();
            ddlt_tqcz.Items.Insert(0, new ListItem("请选择", "-1"));

            ddlt_zrdw.DataSource = SysData.BM().Copy();
            ddlt_zrdw.DataTextField = "mc";
            ddlt_zrdw.DataValueField = "bm";
            ddlt_zrdw.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_fxy.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_fxy.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = fxy.Select_FZR(struct_fxy);
            ddlt_yg.DataSource = dt;
            ddlt_yg.DataTextField = "xm";
            ddlt_yg.DataValueField = "bh";
            ddlt_yg.DataBind();

        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            struct_fxy.p_bmdm = ddlt_bmdm.SelectedValue.ToString();
            struct_fxy.p_gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = fxy.Select_FZR(struct_fxy);
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
            tbx_fzr.Text = ddlt_yg.SelectedItem.Text;
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
            Response.Redirect("../AnQuan/AQXX.aspx", true);
        }

        protected void select_detail()
        {

            dt_detail = fxy.Select_FXY_Detail(bsbh);
            dt_detail.Columns.Add("gw");
            dt_detail.Columns.Add("bm");
            dt_detail.Columns.Add("zrbmmc");
            foreach (DataRow dr in dt_detail.Rows)
            {
                dr["gw"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;
                dr["zrbmmc"] = SysData.BMByKey(dr["zrbm"].ToString()).mc;
            }
            lbl_bsgw.Text = dt_detail.Rows[0]["gw"].ToString();
            lbl_bh.Text = _usState.userXM;//员工编号
            tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            ddlt_zrbm.SelectedValue = dt_detail.Rows[0]["zrbmmc"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            //tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            ddlt_tqcz.SelectedValue = dt_detail.Rows[0]["tqcz"].ToString();
            tbx_gzqk.Text = dt_detail.Rows[0]["gzqk"].ToString();
            tbx_sjqk.Text = dt_detail.Rows[0]["sjqk"].ToString();
            tbx_sbyxqk.Text = dt_detail.Rows[0]["sbyxqk"].ToString();
            tbx_sfsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["sfsj"]).ToString("yyyy-MM-dd");
            tbx_bgsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bgsj"]).ToString("yyyy-MM-dd");
            tbx_fzr.Text = dt_detail.Rows[0]["fzr"].ToString();//负责人

            //tbx_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();
            //ddlt_ztdm.SelectedValue = dt_detail.Rows[0]["zt"].ToString();


        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int check_rz = 0;
            struct_fxy.p_bsbh = bsbh;
            struct_fxy.p_bsyg = dt_detail.Rows[0]["bsyg"].ToString();//员工编号
            struct_fxy.p_bsgw = _usState.userGWDM;//报送岗位
            struct_fxy.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());//报送时间
            struct_fxy.p_zrbm = ddlt_zrbm.SelectedValue.ToString();//责任部门
            struct_fxy.p_bz = tbx_bz.Text.ToString().Trim();//备注
            struct_fxy.p_tqcz = ddlt_tqcz.SelectedValue.Trim().ToString();//特情处置
            struct_fxy.p_gzqk = tbx_gzqk.Text.ToString().Trim();//管制情况
            struct_fxy.p_sjqk = tbx_sjqk.Text.ToString().Trim();//事件情况
            struct_fxy.p_sfsj = Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim());//事发时间
            struct_fxy.p_sbyxqk = tbx_sbyxqk.Text.Trim().ToString();
            struct_fxy.p_zrdw = ddlt_zrdw.SelectedValue.ToString().Trim();//责任单位
            struct_fxy.p_bgsj = Convert.ToDateTime(tbx_bgsj.Text.ToString().Trim());//报告时间
            struct_fxy.p_fzr = ddlt_yg.SelectedValue.ToString(); //负责人
            struct_fxy.p_fxymc = " ";
            struct_fxy.p_st = " ";
            struct_fxy.p_fxyfc = " ";
            if (dt_detail.Rows[0]["tqcz"].ToString().Equals("01"))
            {
                div_tqczf.Visible = false;
            }
            struct_fxy.p_bhyy = "";
            struct_fxy.p_zt = "0";
            struct_fxy.p_czfs = "02";
            struct_fxy.p_czxx = "位置：航务综合信息报送系统->风险源分析->编辑     报送编号：[" + struct_fxy.p_bsbh + "] 描述：";
            ////报送岗位
            if (struct_fxy.p_bsgw != dt_detail.Rows[0]["gw"].ToString())
            {
                //已修改
                struct_fxy.p_czxx += "报送岗位：【" + dt_detail.Rows[0]["gw"].ToString() + "】->【" + struct_fxy.p_bsgw + "】";
                check_rz = 1;
            }

            //报送时间
            if (struct_fxy.p_bssj != Convert.ToDateTime(tbx_bssj.Text.ToString().Trim()))
            {
                struct_fxy.p_czxx += "报送时间：【" + dt_detail.Rows[0]["bssj"].ToString() + "】->【" + struct_fxy.p_bssj + "】";
                check_rz = 1;
            }
            //责任部门
            if (struct_fxy.p_zrbm != ddlt_zrbm.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_fxy.p_czxx += "责任部门【" + dt_detail.Rows[0]["zrbm"].ToString() + "】->【" + struct_fxy.p_zrbm + "】";
                check_rz = 1;
            }
            //备注
            if (struct_fxy.p_bz != tbx_bz.Text.ToString().Trim())
            {
                //已修改
                struct_fxy.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_fxy.p_bz + "】";
                check_rz = 1;
            }
            //特情处置
            if (struct_fxy.p_tqcz != ddlt_tqcz.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_fxy.p_czxx += "特情处置【" + dt_detail.Rows[0]["tqcz"].ToString() + "】->【" + struct_fxy.p_tqcz + "】";
                check_rz = 1;
            }
            //管制情况
            if (struct_fxy.p_gzqk != tbx_gzqk.Text.ToString().Trim())
            {
                //已修改
                struct_fxy.p_czxx += "管制情况：【" + dt_detail.Rows[0]["gzqk"].ToString() + "】->【" + struct_fxy.p_gzqk + "】";
                check_rz = 1;
            }
            //事件情况
            if (struct_fxy.p_sjqk != tbx_sjqk.Text.ToString().Trim())
            {
                //已修改
                struct_fxy.p_czxx += "事件情况：【" + dt_detail.Rows[0]["sjqk"].ToString() + "】->【" + struct_fxy.p_sjqk + "】";
                check_rz = 1;
            }
            //设备运行情况
            if (struct_fxy.p_sbyxqk != tbx_sbyxqk.Text.ToString().Trim())
            {
                //已修改
                struct_fxy.p_czxx += "空管相关设备运行情况：【" + dt_detail.Rows[0]["sbyxqk"].ToString() + "】->【" + struct_fxy.p_sbyxqk + "】";
                check_rz = 1;
            }
            //事发时间
            if (struct_fxy.p_sfsj != Convert.ToDateTime(tbx_sfsj.Text.ToString().Trim()))
            {
                //已修改
                struct_fxy.p_czxx += "事发时间：【" + dt_detail.Rows[0]["sfsj"].ToString() + "】->【" + struct_fxy.p_sfsj + "】";
                check_rz = 1;
            }
            //责任单位
            if (struct_fxy.p_zrdw != ddlt_zrdw.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_fxy.p_czxx += "责任单位【" + dt_detail.Rows[0]["zrdw"].ToString() + "】->【" + struct_fxy.p_zrdw + "】";
                check_rz = 1;
            }
            //报告时间
            if (struct_fxy.p_bgsj != Convert.ToDateTime(tbx_bgsj.Text.ToString().Trim()))
            {
                //已修改
                struct_fxy.p_czxx += "报告时间：【" + dt_detail.Rows[0]["bgsj"].ToString() + "】->【" + struct_fxy.p_bgsj + "】";
                check_rz = 1;
            }
            if (check_rz == 0)
            {
                struct_fxy.p_czxx += "未修改";
                Response.Redirect("../AnQuan/AQXX.aspx", true);
            }
            else
            {
                fxy.Update_FXY(struct_fxy);
                Response.Redirect("../AnQuan/AQXX.aspx", true);
            }    
        }
        
        protected void ddlt_tqcz_change(object sender, EventArgs e)
        {
            string tqcz = ddlt_tqcz.SelectedValue.ToString();
            if (tqcz.Equals("01"))
            {
                div_tqczs.Style.Add("display", "true");
                div_tqczf.Style.Add("display", "none");
            }
            else
            {
                div_tqczf.Style.Add("display", "true");
                div_tqczs.Style.Add("display", "none");
            }
        }
    }
}