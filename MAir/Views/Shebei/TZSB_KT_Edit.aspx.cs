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
    public partial class TZSB_KT_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private int id;
        private string tzbh;
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
                select_detail();
                tzbh = Request.Params["tzbh"].ToString();

            }
        }
        private void ddltBind()
        {
            //是否配备
            ddlt_sfpb.DataTextField = "mc";
            ddlt_sfpb.DataValueField = "bm";
            ddlt_sfpb.DataSource = SysData.SFJB().Copy();
            ddlt_sfpb.DataBind();
            ddlt_sfpb.Items.Insert(0, new ListItem("请选择", "-1"));
            //是否安装紫气装置
            ddlt_sfazzqzz.DataTextField = "mc";
            ddlt_sfazzqzz.DataValueField = "bm";
            ddlt_sfazzqzz.DataSource = SysData.SFJB().Copy();
            ddlt_sfazzqzz.DataBind();
            ddlt_sfazzqzz.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void select_detail() {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            DataTable dt_detail = tzsb.Select_TZ_KT_Detail(id);
          //  tzbh= dt_detail.Rows[0]["tzbh"].ToString();
            ddlt_sfpb.SelectedValue = dt_detail.Rows[0]["sfpb"].ToString();
            tbx_sl.Text = dt_detail.Rows[0]["sl"].ToString();
            tbx_pp.Text = dt_detail.Rows[0]["pp"].ToString();
            tbx_azsj.Text = dt_detail.Rows[0]["azsj"].ToString();
            tbx_bxnx.Text= dt_detail.Rows[0]["bxnx"].ToString();
            ddlt_sfazzqzz.SelectedValue = dt_detail.Rows[0]["sfazzqzz"].ToString();
        }
        protected void btn_bc_Click(object sender, EventArgs e) {
                int id = Convert.ToInt32(Request.Params["id"].ToString());
                string sfpb = ddlt_sfpb.SelectedValue.ToString();
                string sl = tbx_sl.Text.ToString();
                string pp = tbx_pp.Text.ToString();
                string azsj = tbx_azsj.Text.ToString();
                string bxnx = tbx_bxnx.Text.ToString();
                string sfazzqzz = ddlt_sfazzqzz.SelectedValue.ToString();
            try
            {
                struct_tzsb.p_id = id;
                struct_tzsb.p_sfpb = sfpb;
                struct_tzsb.p_sl = sl;
                struct_tzsb.p_pp = pp;
                struct_tzsb.p_azsj = azsj;
                struct_tzsb.p_bxnx = bxnx;
                struct_tzsb.p_sfazzqzz = sfazzqzz;
                struct_tzsb.p_czfs = "02";
              
                struct_tzsb.p_czxx = "位置：设备管理->空调情况->编辑[设备编号：" + struct_tzsb.p_tzbh + "      描述：";
                    //if (struct_tzsb.p_sfpb != dt_row["sfpb"].ToString()) {
                    //    struct_tzsb.p_czxx += "备注：【" + dt_row["sfpb"].ToString() + "】->【" + struct_tzsb.p_sfpb + "】";
                    //}

                    //if (struct_tzsb.p_sl != dt_row["sl"].ToString())
                    //{
                    //    struct_tzsb.p_czxx += "备注：【" + dt_row["sl"].ToString() + "】->【" + struct_tzsb.p_sl + "】";
                    //}

                    //if (struct_tzsb.p_pp != dt_row["pp"].ToString())
                    //{
                    //    struct_tzsb.p_czxx += "备注：【" + dt_row["pp"].ToString() + "】->【" + struct_tzsb.p_pp + "】";
                    //}
                    //if (struct_tzsb.p_azsj != dt_row["azsj"].ToString())
                    //{
                    //    struct_tzsb.p_czxx += "备注：【" + dt_row["azsj"].ToString() + "】->【" + struct_tzsb.p_azsj + "】";
                    //}

                    //if (struct_tzsb.p_bxnx != dt_row["bxnx"].ToString())
                    //{
                    //    struct_tzsb.p_czxx += "备注：【" + dt_row["bxnx"].ToString() + "】->【" + struct_tzsb.p_bxnx + "】";
                    //}

                    //if (struct_tzsb.p_sfazzqzz != dt_row["sfazzqzz"].ToString())
                    //{
                    //    struct_tzsb.p_czxx += "备注：【" + dt_row["sfazzqzz"].ToString() + "】->【" + struct_tzsb.p_sfazzqzz + "】";
                    //}
                tzsb.Update_TZ_KT(struct_tzsb);
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