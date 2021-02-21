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
    public partial class BS_YS_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private YS ys;
        private Struct_YS struct_ys;
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
            ys = new YS(_usState);
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
            //报送类型
            ddlt_bslx.DataSource = SysData.BSLX().Copy();
            ddlt_bslx.DataTextField = "mc";
            ddlt_bslx.DataValueField = "bm";
            ddlt_bslx.DataBind();
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
            Response.Redirect("../BaoSong/BS_YS.aspx", true);
        }

        protected void select_detail()
        {

            dt_detail = ys.Select_YS_Detail(bsbh);
            dt_detail.Columns.Add("bm");
            dt_detail.Columns.Add("gw");
            dt_detail.Columns.Add("bslxmc");
            dt_detail.Columns.Add("bssjcl");
            foreach (DataRow dr in dt_detail.Rows)
            {
                dr["gw"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;
                dr["bslxmc"] = SysData.BSLXByKey(dr["bslx"].ToString()).mc;
                dr["bm"] = SysData.BMByKey(dr["sqbm"].ToString()).mc;
            }
            tbx_bh.Text = dt_detail.Rows[0]["bsyg"].ToString();
            tbx_bsgw.Text = dt_detail.Rows[0]["gw"].ToString();
            ddlt_bslx.SelectedValue = dt_detail.Rows[0]["bslx"].ToString();
            tbx_bsip.Text = dt_detail.Rows[0]["bsip"].ToString();
            tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            tbx_sqbm.Text = dt_detail.Rows[0]["bm"].ToString();
            tbx_ysze.Text = dt_detail.Rows[0]["ysze"].ToString();
            tbx_ysly.Text = dt_detail.Rows[0]["ysly"].ToString();
            tbx_ysyt.Text = dt_detail.Rows[0]["ysyt"].ToString();
            tbx_yynx.Text = dt_detail.Rows[0]["yynx"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
        }


        protected void btn_edit_Click(object sender, EventArgs e)
        {
            this.btn_save.Visible = true;
            //ddlt_bslx.Enabled = true;
            tbx_bssj.Enabled = true;
            tbx_ysze.Enabled = true;
            tbx_ysly.Enabled = true;
            tbx_ysyt.Enabled = true;
            tbx_yynx.Enabled = true;
            tbx_bz.Enabled = true;
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            int check_rz = 0;
            struct_ys.p_bsbh = bsbh;
            struct_ys.p_bsyg = tbx_bh.Text.ToString().Trim();//员工编号
            struct_ys.p_bsgw = dt_detail.Rows[0]["bsgw"].ToString();//报送岗位
            struct_ys.p_bslx = ddlt_bslx.SelectedValue.ToString().Trim();//报送类型
            struct_ys.p_bsip = tbx_bsip.Text.ToString().Trim();//报送IP
            struct_ys.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());//报送时间
            struct_ys.p_sqbm = dt_detail.Rows[0]["sqbm"].ToString();//申请部门
            struct_ys.p_ysze = tbx_ysze.Text.ToString().Trim();//预算总额
            struct_ys.p_ysly = tbx_ysly.Text.ToString().Trim();//预算来源
            struct_ys.p_ysyt = tbx_ysyt.Text.ToString();//预算用途
            struct_ys.p_yynx = tbx_yynx.Text.ToString();//应用年限
            struct_ys.p_bz = tbx_bz.Text.ToString().Trim();//备注
            struct_ys.p_czfs = "02";
            struct_ys.p_czxx = "位置：航务综合信息报送系统->预算->编辑    报送编号：[" + struct_ys.p_bsbh + "]  描述：";
            //dt_detail = yg.Select_YGDetail(Request.Params["BH"].ToString());
            //报送岗位
            if (struct_ys.p_bsgw != dt_detail.Rows[0]["gw"].ToString())
            {
                //已修改
                struct_ys.p_czxx += "报送岗位：【" + dt_detail.Rows[0]["gw"].ToString() + "】->【" + struct_ys.p_bsgw + "】";
                check_rz = 1;
            }
            //报送类型
            if (struct_ys.p_bslx != ddlt_bslx.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_ys.p_czxx += "报送类型：【" + dt_detail.Rows[0]["bslx"].ToString() + "】->【" + struct_ys.p_bslx + "】";
                check_rz = 1;
            }

            //报送时间
            if (struct_ys.p_bssj != Convert.ToDateTime(tbx_bssj.Text.ToString().Trim()))
            {
                //已修改
                struct_ys.p_czxx += "报送时间：【" + dt_detail.Rows[0]["bssj"].ToString() + "】->【" + struct_ys.p_bssj + "】";
                check_rz = 1;
            }

            //预算总额
            if (struct_ys.p_ysze != tbx_ysze.Text.ToString().Trim())
            {
                //已修改
                struct_ys.p_czxx += "预算总额：【" + dt_detail.Rows[0]["ysze"].ToString() + "】->【" + struct_ys.p_ysze + "】";
                check_rz = 1;
            }
            //预算来源
            if (struct_ys.p_ysly != tbx_ysly.Text.ToString().Trim())
            {
                //已修改
                struct_ys.p_czxx += "预算来源：【" + dt_detail.Rows[0]["ysly"].ToString() + "】->【" + struct_ys.p_ysly + "】";
                check_rz = 1;
            }
            //预算用途
            if (struct_ys.p_ysyt != tbx_ysyt.Text.ToString())
            {
                //已修改
                struct_ys.p_czxx += "预算用途：【" + dt_detail.Rows[0]["ysyt"].ToString() + "】->【" + struct_ys.p_ysyt + "】";
                check_rz = 1;
            }
            //应用年限
            if (struct_ys.p_yynx != tbx_yynx.Text.ToString())
            {
                //已修改
                struct_ys.p_czxx += "应用年限：【" + dt_detail.Rows[0]["yynx"].ToString() + "】->【" + struct_ys.p_yynx + "】";
                check_rz = 1;
            }
           
            //备注
            if (struct_ys.p_bz != tbx_bz.Text.ToString().Trim())
            {
                //已修改
                struct_ys.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_ys.p_bz + "】";
                check_rz = 1;
            }
            if (check_rz == 0)
            {
                struct_ys.p_czxx += "未修改";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");

            }
            else
            {
                ys.Update_YS(struct_ys);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
            }

            //this.btn_save.Visible = true;
            //ddlt_bslx.Enabled = false;
            tbx_bssj.Enabled = false;
            tbx_ysze.Enabled = false;
            tbx_ysly.Enabled = false;
            tbx_ysyt.Enabled = false;
            tbx_yynx.Enabled = false;
            tbx_bz.Enabled = false;
        }

    }
}