using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BS_ZBTJ : System.Web.UI.Page
    {
        private UserState _usState;
        static string zbygbh;
        public bool flag = true;
        public int i = 0;
        private ZBGL zbgl;
        private static DataTable dt = new DataTable();
        private Struct_ZBGL struct_zbgl;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            zbgl = new ZBGL(_usState);
            id = Convert.ToInt32(Request.Params["id"].ToString());
            if (!IsPostBack)
            {
                
                yg_bind();
            }
        }
        private void yg_bind()
        {
            //DataTable dt_bmdm = SysData.BM("110502", _usState.userID).Copy();
            DataTable dt_bmdm = SysData.BM().Copy();
            //负责人
            ddlt_bmdm.DataSource = dt_bmdm;
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
            dt = zbgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zbyg.DataSource = dt;
            ddlt_zbyg.DataTextField = "xm";
            ddlt_zbyg.DataValueField = "bh";
            ddlt_zbyg.DataBind();



        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = zbgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zbyg.DataSource = dt;
            ddlt_zbyg.DataTextField = "xm";
            ddlt_zbyg.DataValueField = "bh";
            ddlt_zbyg.DataBind();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = zbgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zbyg.DataSource = dt;
            ddlt_zbyg.DataTextField = "xm";
            ddlt_zbyg.DataValueField = "bh";
            ddlt_zbyg.DataBind();
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string zbyg = ddlt_zbyg.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_zbyg.Items.Count > 0)
            {
                tbx_zbyg.Text = ddlt_zbyg.SelectedItem.Text;
                zbygbh = ddlt_zbyg.SelectedValue.ToString();
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_zbgl.p_id = Convert.ToInt32(Request.Params["id"].ToString());
            struct_zbgl.p_zbgw = ddlt_gwdm.SelectedValue.ToString().Trim();
            struct_zbgl.p_zbyg = ddlt_zbyg.SelectedValue.ToString().Trim();
            struct_zbgl.p_zbdh = tbx_zbdh.Text.ToString().Trim();
            struct_zbgl.p_czfs = "02";
            struct_zbgl.p_czxx = "位置：航务综合报送->值班表->添加   描述：员工编号：" + _usState.userLoginName;

            zbgl.Insert_ZBTJ(struct_zbgl);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");

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
            Server.Transfer("BS_ZBGL_CZ.aspx?id=" + id);

        }
    }
}