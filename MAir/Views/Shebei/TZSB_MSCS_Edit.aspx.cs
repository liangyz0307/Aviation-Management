using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using CUST.Sys;
using System.Data;
using System.IO;
using Sys;

namespace CUST.WKG
{
    public partial class TZSB_MSCS_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private string tzbh;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tzbh = Request.Params["tzbh"].ToString();
            tzsb = new TZSB(_usState);
            struct_tzsb = new Struct_TZSB();
            
            if (!IsPostBack)
            {
                ddltBind();
                tzbh = Request.Params["tzbh"].ToString();
                select_detail();
            }
        }
        private void ddltBind()
        {
            //挡鼠板
            ddlt_dsb.DataTextField = "mc";
            ddlt_dsb.DataValueField = "bm";
            ddlt_dsb.DataSource = SysData.SFJB().Copy();
            ddlt_dsb.DataBind();
            ddlt_dsb.Items.Insert(0, new ListItem("请选择", "-1"));
            //防洪措施是否具备
            ddlt_fh.DataTextField = "mc";
            ddlt_fh.DataValueField = "bm";
            ddlt_fh.DataSource = SysData.SFJB().Copy();
            ddlt_fh.DataBind();
            ddlt_fh.Items.Insert(0, new ListItem("请选择", "-1"));
            //防盗措施是否具备
            ddlt_fd.DataTextField = "mc";
            ddlt_fd.DataValueField = "bm";
            ddlt_fd.DataSource = SysData.SFJB().Copy();
            ddlt_fd.DataBind();
            ddlt_fd.Items.Insert(0, new ListItem("请选择", "-1"));
            //维修工具是否满足该设备故障时紧急维修需求
            ddlt_wxgj.DataTextField = "mc";
            ddlt_wxgj.DataValueField = "bm";
            ddlt_wxgj.DataSource = SysData.SFJB().Copy();
            ddlt_wxgj.DataBind();
            ddlt_wxgj.Items.Insert(0, new ListItem("请选择", "-1"));
            //是否有地暖
            ddlt_sfydn.DataTextField = "mc";
            ddlt_sfydn.DataValueField = "bm";
            ddlt_sfydn.DataSource = SysData.SFJB().Copy();
            ddlt_sfydn.DataBind();
            ddlt_sfydn.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            DataTable dt_detail = tzsb.Select_TZ_MSCS_Detail(id);
            ddlt_dsb.SelectedValue = dt_detail.Rows[0]["dsb"].ToString();
            tbx_zsbgs.Text = dt_detail.Rows[0]["zsbgs"].ToString();
            ddlt_fh.SelectedValue = dt_detail.Rows[0]["fh"].ToString();
            ddlt_fd.SelectedValue = dt_detail.Rows[0]["fd"].ToString();
            ddlt_wxgj.SelectedValue = dt_detail.Rows[0]["wxgj"].ToString();
            tbx_jfflcs.Text = dt_detail.Rows[0]["jfflcs"].ToString();
            tbx_fljcdqrq.Text = dt_detail.Rows[0]["fljcdqrq"].ToString();
            ddlt_sfydn.SelectedValue = dt_detail.Rows[0]["sfydn"].ToString();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Params["id"].ToString());
            string dsb = ddlt_dsb.SelectedValue.ToString();
            string zsbgs = tbx_zsbgs.Text.ToString();
            string fh = ddlt_fh.SelectedValue.ToString();
            string fd = ddlt_fd.SelectedValue.ToString();
            string wxgj = ddlt_wxgj.SelectedValue.ToString();
            string jfflcs = tbx_jfflcs.Text.ToString();
            string fljcdqrq = tbx_fljcdqrq.Text.ToString();
            string sfydn = ddlt_sfydn.SelectedValue.ToString();
            try
            {
                struct_tzsb.p_id = id;
                struct_tzsb.p_dsb = dsb;
                struct_tzsb.p_zsbgs = zsbgs;
                struct_tzsb.p_fh = fh;
                struct_tzsb.p_fd = fd;
                struct_tzsb.p_wxgj = wxgj;
                struct_tzsb.p_jfflcs = jfflcs;
                struct_tzsb.p_fljcdqrq = fljcdqrq;
                struct_tzsb.p_sfydn = sfydn;
                struct_tzsb.p_czfs = "02";
                struct_tzsb.p_czxx = "位置：设备管理->灭鼠措施->编辑[设备编号：" + struct_tzsb.p_tzbh + "描述：";
                //if (struct_tzsb.p_dsb != dt_row["dsb"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["dsb"].ToString() + "】->【" + struct_tzsb.p_dsb + "】";
                //}

                //if (struct_tzsb.p_zsbgs != dt_row["zsbgs"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["zsbgs"].ToString() + "】->【" + struct_tzsb.p_zsbgs + "】";
                //}

                //if (struct_tzsb.p_qtcs != dt_row["qtcs"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["qtcs"].ToString() + "】->【" + struct_tzsb.p_qtcs + "】";
                //}

                //if (struct_tzsb.p_fh != dt_row["fh"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["fh"].ToString() + "】->【" + struct_tzsb.p_fh + "】";
                //}

                //if (struct_tzsb.p_fd != dt_row["fd"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["fd"].ToString() + "】->【" + struct_tzsb.p_fd + "】";
                //}

                //if (struct_tzsb.p_wxgj != dt_row["wxgj"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["wxgj"].ToString() + "】->【" + struct_tzsb.p_wxgj + "】";
                //}

                //if (struct_tzsb.p_jfflcs != dt_row["jfflcs"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["jfflcs"].ToString() + "】->【" + struct_tzsb.p_jfflcs + "】";
                //}

                //if (struct_tzsb.p_fljcdqrq != dt_row["fljcdqrq"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["fljcdqrq"].ToString() + "】->【" + struct_tzsb.p_fljcdqrq + "】";
                //}

                //    if (struct_tzsb.p_sfydn != dt_row["sfydn"].ToString())
                //{
                //    struct_tzsb.p_czxx += "备注：【" + dt_row["sfydn"].ToString() + "】->【" + struct_tzsb.p_sfydn + "】";
                //}


                tzsb.Update_TZ_MSCS(struct_tzsb);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }

        protected void btn_gb_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("../Shebei/SBTZ_CZ.aspx?tzbh=" + tzbh);
        }
    }
}