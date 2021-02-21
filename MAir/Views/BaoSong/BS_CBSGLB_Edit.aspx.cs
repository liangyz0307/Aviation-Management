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
    public partial class BS_CBSGLB_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        public CBSGL cbsgl;
        public Struct_CBSGL struct_cbsgl;
        static string zbldbh = "";
        static string ttzbbh = "";
        static string zdzbbh = "";
        static string tdzbbh = "";
        static string qxybbh = "";
        static string gcbh = "";
        public bool flag = true;
        public int i = 0;
        private int id;
        private static DataTable dt_detail = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cbsgl = new CBSGL(_usState);
            struct_cbsgl = new Struct_CBSGL();
            id = Convert.ToInt32(Request.Params["id"].ToString());
            if (!IsPostBack)
            {
                tbx_rq.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
                select_detail();
            }
        }
        #region 错误信息
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
        #endregion

        protected void select_detail()
        {
            dt_detail = cbsgl.Select_CBSGL_Detail(id);
            tbx_rq.Text = dt_detail.Rows[0]["rq"].ToString();//日期
            tbx_ttzbdh.Text = dt_detail.Rows[0]["ttzbdh"].ToString();
            tbx_zdzbdh.Text = dt_detail.Rows[0]["zdzbdh"].ToString();
            tbx_tdzbdh.Text = dt_detail.Rows[0]["tdzbdh"].ToString();
            tbx_qxybdh.Text = dt_detail.Rows[0]["qxybzbdh"].ToString();
            tbx_gcdh.Text = dt_detail.Rows[0]["qxgczbdh"].ToString();
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门
        }

        private void yg_bind()
        {
            DataTable dt_bmdm = SysData.BM().Copy();
            //部门
            ddlt_bm.DataSource = dt_bmdm;
            ddlt_bm.DataTextField = "mc";
            ddlt_bm.DataValueField = "bm";
            ddlt_bm.DataBind();
            ddlt_bm.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq.DataSource = SysData.ZXDM().Copy();
            ddlt_dq.DataTextField = "mc";
            ddlt_dq.DataValueField = "bm";
            ddlt_dq.DataBind();
            ddlt_dq.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_1.DataSource = dt_bmdm;
            ddlt_bm_1.DataTextField = "mc";
            ddlt_bm_1.DataValueField = "bm";
            ddlt_bm_1.DataBind();
            ddlt_bm_1.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_1.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_1.DataTextField = "mc";
            ddlt_dq_1.DataValueField = "bm";
            ddlt_dq_1.DataBind();
            ddlt_dq_1.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_2.DataSource = dt_bmdm;
            ddlt_bm_2.DataTextField = "mc";
            ddlt_bm_2.DataValueField = "bm";
            ddlt_bm_2.DataBind();
            ddlt_bm_2.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_2.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_2.DataTextField = "mc";
            ddlt_dq_2.DataValueField = "bm";
            ddlt_dq_2.DataBind();
            ddlt_dq_2.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_3.DataSource = dt_bmdm;
            ddlt_bm_3.DataTextField = "mc";
            ddlt_bm_3.DataValueField = "bm";
            ddlt_bm_3.DataBind();
            ddlt_bm_3.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_3.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_3.DataTextField = "mc";
            ddlt_dq_3.DataValueField = "bm";
            ddlt_dq_3.DataBind();
            ddlt_dq_3.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_4.DataSource = dt_bmdm;
            ddlt_bm_4.DataTextField = "mc";
            ddlt_bm_4.DataValueField = "bm";
            ddlt_bm_4.DataBind();
            ddlt_bm_4.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_4.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_4.DataTextField = "mc";
            ddlt_dq_4.DataValueField = "bm";
            ddlt_dq_4.DataBind();
            ddlt_dq_4.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_5.DataSource = dt_bmdm;
            ddlt_bm_5.DataTextField = "mc";
            ddlt_bm_5.DataValueField = "bm";
            ddlt_bm_5.DataBind();
            ddlt_bm_5.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_5.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_5.DataTextField = "mc";
            ddlt_dq_5.DataValueField = "bm";
            ddlt_dq_5.DataBind();
            ddlt_dq_5.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bm.SelectedValue.ToString();
            string dqdm = ddlt_dq.SelectedValue.ToString();

            string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();

            string bmdm_2 = ddlt_bm_2.SelectedValue.ToString();
            string dqdm_2 = ddlt_dq_2.SelectedValue.ToString();

            string bmdm_3 = ddlt_bm_3.SelectedValue.ToString();
            string dqdm_3 = ddlt_dq_3.SelectedValue.ToString();

            string bmdm_4 = ddlt_bm_4.SelectedValue.ToString();
            string dqdm_4 = ddlt_dq_4.SelectedValue.ToString();

            string bmdm_5 = ddlt_bm_5.SelectedValue.ToString();
            string dqdm_5 = ddlt_dq_5.SelectedValue.ToString();

            DataTable dt = new DataTable();
            dt = cbsgl.Select_YGByBMDQ(dqdm, bmdm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
            DataTable dt_1 = new DataTable();
            dt_1 = cbsgl.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_ttzb.DataSource = dt_1;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
            DataTable dt_2 = new DataTable();
            dt_2 = cbsgl.Select_YGByBMDQ(dqdm_2, bmdm_2);
            ddlt_zdzb.DataSource = dt_2;
            ddlt_zdzb.DataTextField = "xm";
            ddlt_zdzb.DataValueField = "bh";
            ddlt_zdzb.DataBind();
            DataTable dt_3 = new DataTable();
            dt_3 = cbsgl.Select_YGByBMDQ(dqdm_3, bmdm_3);
            ddlt_tdzb.DataSource = dt_3;
            ddlt_tdzb.DataTextField = "xm";
            ddlt_tdzb.DataValueField = "bh";
            ddlt_tdzb.DataBind();
            DataTable dt_4 = new DataTable();
            dt_4 = cbsgl.Select_YGByBMDQ(dqdm_4, bmdm_4);
            ddlt_qxyb.DataSource = dt_4;
            ddlt_qxyb.DataTextField = "xm";
            ddlt_qxyb.DataValueField = "bh";
            ddlt_qxyb.DataBind();
            DataTable dt_5 = new DataTable();
            dt_5 = cbsgl.Select_YGByBMDQ(dqdm_5, bmdm_5);
            ddlt_gc.DataSource = dt_5;
            ddlt_gc.DataTextField = "xm";
            ddlt_gc.DataValueField = "bh";
            ddlt_gc.DataBind();
        }

        private void ddltBind()
        {
            //数据所在部门
            ddlt_sjszbm.DataSource = SysData.BM().Copy();
            ddlt_sjszbm.DataTextField = "mc";
            ddlt_sjszbm.DataValueField = "bm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
        }

        protected void ddlt_dq_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bm.SelectedValue.ToString();
            string dqdm = ddlt_dq.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = cbsgl.Select_YGByBMDQ(dqdm, bmdm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
        }

        protected void ddlt_bm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bm.SelectedValue.ToString();
            string dqdm = ddlt_dq.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = cbsgl.Select_YGByBMDQ(dqdm, bmdm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bm.SelectedValue.ToString();
            string dqdm = ddlt_dq.SelectedValue.ToString();
            string zbld = ddlt_zbld.SelectedValue.ToString();
            zbldbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_zbld.Items.Count > 0)
            {
                tbx_zbld.Text = ddlt_zbld.SelectedItem.Text;
                zbldbh = ddlt_zbld.SelectedValue.ToString() + ",";
            }
        }

        protected void ddlt_dq_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();
            DataTable dt_1 = new DataTable();
            dt_1 = cbsgl.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_ttzb.DataSource = dt_1;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
        }

        protected void ddlt_bm_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();
            DataTable dt_1 = new DataTable();
            dt_1 = cbsgl.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_ttzb.DataSource = dt_1;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
        }

        protected void btn_bc_1_Click(object sender, EventArgs e)
        {
            string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();
            string ttzb = ddlt_ttzb.SelectedValue.ToString();
            ttzbbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_ttzb.Items.Count > 0)
            {
                tbx_ttzb.Text += ddlt_ttzb.SelectedItem.Text + ",";
                ttzbbh += ddlt_ttzb.SelectedValue.ToString() + ",";
            }
        }

        protected void ddlt_dq_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_2 = ddlt_bm_2.SelectedValue.ToString();
            string dqdm_2 = ddlt_dq_2.SelectedValue.ToString();
            DataTable dt_2 = new DataTable();
            dt_2 = cbsgl.Select_YGByBMDQ(dqdm_2, bmdm_2);
            ddlt_zdzb.DataSource = dt_2;
            ddlt_zdzb.DataTextField = "xm";
            ddlt_zdzb.DataValueField = "bh";
            ddlt_zdzb.DataBind();
        }

        protected void ddlt_bm_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_2 = ddlt_bm_2.SelectedValue.ToString();
            string dqdm_2 = ddlt_dq_2.SelectedValue.ToString();
            DataTable dt_2 = new DataTable();
            dt_2 = cbsgl.Select_YGByBMDQ(dqdm_2, bmdm_2);
            ddlt_zdzb.DataSource = dt_2;
            ddlt_zdzb.DataTextField = "xm";
            ddlt_zdzb.DataValueField = "bh";
            ddlt_zdzb.DataBind();
        }

        protected void btn_bc_2_Click(object sender, EventArgs e)
        {
            string bmdm_2 = ddlt_bm_2.SelectedValue.ToString();
            string dqdm_2 = ddlt_dq_2.SelectedValue.ToString();
            string zdzb = ddlt_zdzb.SelectedValue.ToString();
            zdzbbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_zdzb.Items.Count > 0)
            {
                tbx_zdzb.Text += ddlt_zdzb.SelectedItem.Text + ",";
                zdzbbh += ddlt_zdzb.SelectedValue.ToString() + ",";
            }
        }

        protected void ddlt_dq_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_3 = ddlt_bm_3.SelectedValue.ToString();
            string dqdm_3 = ddlt_dq_3.SelectedValue.ToString();
            DataTable dt_3 = new DataTable();
            dt_3 = cbsgl.Select_YGByBMDQ(dqdm_3, bmdm_3);
            ddlt_tdzb.DataSource = dt_3;
            ddlt_tdzb.DataTextField = "xm";
            ddlt_tdzb.DataValueField = "bh";
            ddlt_tdzb.DataBind();
        }

        protected void ddlt_bm_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_3 = ddlt_bm_3.SelectedValue.ToString();
            string dqdm_3 = ddlt_dq_3.SelectedValue.ToString();
            DataTable dt_3 = new DataTable();
            dt_3 = cbsgl.Select_YGByBMDQ(dqdm_3, bmdm_3);
            ddlt_tdzb.DataSource = dt_3;
            ddlt_tdzb.DataTextField = "xm";
            ddlt_tdzb.DataValueField = "bh";
            ddlt_tdzb.DataBind();
        }

        protected void btn_bc_3_Click(object sender, EventArgs e)
        {
            string bmdm_3 = ddlt_bm_3.SelectedValue.ToString();
            string dqdm_3 = ddlt_dq_3.SelectedValue.ToString();
            string tdzb = ddlt_tdzb.SelectedValue.ToString();
            tdzbbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_tdzb.Items.Count > 0)
            {
                tbx_tdzb.Text += ddlt_tdzb.SelectedItem.Text + ",";
                tdzbbh += ddlt_tdzb.SelectedValue.ToString() + ",";
            }
        }

        protected void ddlt_dq_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_4 = ddlt_bm_4.SelectedValue.ToString();
            string dqdm_4 = ddlt_dq_4.SelectedValue.ToString();
            DataTable dt_4 = new DataTable();
            dt_4 = cbsgl.Select_YGByBMDQ(dqdm_4, bmdm_4);
            ddlt_qxyb.DataSource = dt_4;
            ddlt_qxyb.DataTextField = "xm";
            ddlt_qxyb.DataValueField = "bh";
            ddlt_qxyb.DataBind();
        }

        protected void ddlt_bm_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_4 = ddlt_bm_4.SelectedValue.ToString();
            string dqdm_4 = ddlt_dq_4.SelectedValue.ToString();
            DataTable dt_4 = new DataTable();
            dt_4 = cbsgl.Select_YGByBMDQ(dqdm_4, bmdm_4);
            ddlt_qxyb.DataSource = dt_4;
            ddlt_qxyb.DataTextField = "xm";
            ddlt_qxyb.DataValueField = "bh";
            ddlt_qxyb.DataBind();
        }

        protected void btn_bc_4_Click(object sender, EventArgs e)
        {
            string bmdm_4 = ddlt_bm_4.SelectedValue.ToString();
            string dqdm_4 = ddlt_dq_4.SelectedValue.ToString();
            string qxyb = ddlt_qxyb.SelectedValue.ToString();
            qxybbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_qxyb.Items.Count > 0)
            {
                tbx_qxyb.Text += ddlt_qxyb.SelectedItem.Text + ",";
                qxybbh += ddlt_qxyb.SelectedValue.ToString() + ",";
            }
        }

        protected void ddlt_dq_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_5 = ddlt_bm_5.SelectedValue.ToString();
            string dqdm_5 = ddlt_dq_5.SelectedValue.ToString();
            DataTable dt_5 = new DataTable();
            dt_5 = cbsgl.Select_YGByBMDQ(dqdm_5, bmdm_5);
            ddlt_gc.DataSource = dt_5;
            ddlt_gc.DataTextField = "xm";
            ddlt_gc.DataValueField = "bh";
            ddlt_gc.DataBind();
        }

        protected void ddlt_bm_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_5 = ddlt_bm_5.SelectedValue.ToString();
            string dqdm_5 = ddlt_dq_5.SelectedValue.ToString();
            DataTable dt_5 = new DataTable();
            dt_5 = cbsgl.Select_YGByBMDQ(dqdm_5, bmdm_5);
            ddlt_gc.DataSource = dt_5;
            ddlt_gc.DataTextField = "xm";
            ddlt_gc.DataValueField = "bh";
            ddlt_gc.DataBind();
        }

        protected void btn_bc_5_Click(object sender, EventArgs e)
        {
            string bmdm_5 = ddlt_bm_5.SelectedValue.ToString();
            string dqdm_5 = ddlt_dq_5.SelectedValue.ToString();
            string gc = ddlt_gc.SelectedValue.ToString();
            gcbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_gc.Items.Count > 0)
            {
                tbx_gc.Text += ddlt_gc.SelectedItem.Text + ",";
                gcbh += ddlt_gc.SelectedValue.ToString() + ",";
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_cbsgl.p_id = id;
            struct_cbsgl.p_rq = Convert.ToDateTime(tbx_rq.Text.ToString().Trim());
            if (zbldbh == "")
            {
                struct_cbsgl.p_zbld = dt_detail.Rows[0]["zbld"].ToString();
            }
            else
            {
                struct_cbsgl.p_zbld = zbldbh;
            }
            if (ttzbbh == "")
            {
                struct_cbsgl.p_ttzb = dt_detail.Rows[0]["ttzb"].ToString();
            }
            else
            {
                struct_cbsgl.p_ttzb = ttzbbh;
            }
            if (zdzbbh == "")
            {
                struct_cbsgl.p_zdzb = dt_detail.Rows[0]["zdzb"].ToString();
            }
            else
            {
                struct_cbsgl.p_zdzb = zdzbbh;
            }
            if (tdzbbh == "")
            {
                struct_cbsgl.p_tdzb = dt_detail.Rows[0]["tdzb"].ToString();
            }
            else
            {
                struct_cbsgl.p_tdzb = tdzbbh;
            }
            if (qxybbh == "")
            {
                struct_cbsgl.p_qxyb = dt_detail.Rows[0]["qxyb"].ToString();
            }
            else
            {
                struct_cbsgl.p_qxyb = qxybbh;
            }
            if (gcbh == "")
            {
                struct_cbsgl.p_gc = dt_detail.Rows[0]["gc"].ToString();
            }
            else
            {
                struct_cbsgl.p_gc = gcbh;
            }
            struct_cbsgl.p_qxgczbdh = tbx_gcdh.Text.ToString().Trim();
            struct_cbsgl.p_qxybzbdh = tbx_qxybdh.Text.ToString().Trim();
            struct_cbsgl.p_tdzbdh = tbx_tdzbdh.Text.ToString().Trim();
            struct_cbsgl.p_zdzbdh = tbx_zdzbdh.Text.ToString().Trim();
            struct_cbsgl.p_ttzbdh = tbx_ttzbdh.Text.ToString().Trim();
            struct_cbsgl.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();

            struct_cbsgl.p_czfs = "03";
            struct_cbsgl.p_czxx = "位置：航务综合报送->值班表->编辑   描述：员工编号：" + _usState.userLoginName;
            try
            {
                cbsgl.Update_CBSGL(struct_cbsgl);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('修改成功');location.href='BS_CBSGLB.aspx';</script>");
            }
            catch (EMException ex)
            {
                Response.Write(EMException.ShowErrorScript(ex));
                return;
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_CBSGLB.aspx", true);
        }
    }
}