using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sys;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using System.Data;
using System.Globalization;

namespace CUST.WKG
{
    public partial class BS_YJGLB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private YJGL yjgl;
        private Struct_YJGL struct_yjgl;
        static string xzbbh_cs;
        static string gzdbzrbh_cs = "";
        static string ttzbbh_cs = "";
        static string zdzbbh_cs = "";
        static string qbbh_cs = "";
        static string tddbbh_cs = "";
        static string txbh_cs = "";
        static string dhbh_cs = "";
        static string btbh_cs = "";
        static string qxjwbh_cs = "";
        static string qxgcbh_cs = "";
        static string qxybbh_cs = "";

        static string zbldbh = "";
        static string xzbbh = "";
        static string gzdbzrbh = "";
        static string ttzbbh = "";
        static string zdzbbh = "";
        static string qbbh = "";
        static string tddbbh = "";
        static string txbh = "";
        static string dhbh = "";
        static string btbh = "";
        static string qxjwbh = "";
        static string qxgcbh = "";
        static string qxybbh = "";
        public bool flag = true;
        public int i = 0;
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yjgl = new YJGL(_usState);
            struct_yjgl = new Struct_YJGL();
            if (!IsPostBack)
            {
                tbx_rq.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
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
            //部门
            ddlt_bm_6.DataSource = dt_bmdm;
            ddlt_bm_6.DataTextField = "mc";
            ddlt_bm_6.DataValueField = "bm";
            ddlt_bm_6.DataBind();
            ddlt_bm_6.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_6.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_6.DataTextField = "mc";
            ddlt_dq_6.DataValueField = "bm";
            ddlt_dq_6.DataBind();
            ddlt_dq_6.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_7.DataSource = dt_bmdm;
            ddlt_bm_7.DataTextField = "mc";
            ddlt_bm_7.DataValueField = "bm";
            ddlt_bm_7.DataBind();
            ddlt_bm_7.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_7.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_7.DataTextField = "mc";
            ddlt_dq_7.DataValueField = "bm";
            ddlt_dq_7.DataBind();
            ddlt_dq_7.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_8.DataSource = dt_bmdm;
            ddlt_bm_8.DataTextField = "mc";
            ddlt_bm_8.DataValueField = "bm";
            ddlt_bm_8.DataBind();
            ddlt_bm_8.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_8.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_8.DataTextField = "mc";
            ddlt_dq_8.DataValueField = "bm";
            ddlt_dq_8.DataBind();
            ddlt_dq_8.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_9.DataSource = dt_bmdm;
            ddlt_bm_9.DataTextField = "mc";
            ddlt_bm_9.DataValueField = "bm";
            ddlt_bm_9.DataBind();
            ddlt_bm_9.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_9.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_9.DataTextField = "mc";
            ddlt_dq_9.DataValueField = "bm";
            ddlt_dq_9.DataBind();
            ddlt_dq_9.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_10.DataSource = dt_bmdm;
            ddlt_bm_10.DataTextField = "mc";
            ddlt_bm_10.DataValueField = "bm";
            ddlt_bm_10.DataBind();
            ddlt_bm_10.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_10.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_10.DataTextField = "mc";
            ddlt_dq_10.DataValueField = "bm";
            ddlt_dq_10.DataBind();
            ddlt_dq_10.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_11.DataSource = dt_bmdm;
            ddlt_bm_11.DataTextField = "mc";
            ddlt_bm_11.DataValueField = "bm";
            ddlt_bm_11.DataBind();
            ddlt_bm_11.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_11.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_11.DataTextField = "mc";
            ddlt_dq_11.DataValueField = "bm";
            ddlt_dq_11.DataBind();
            ddlt_dq_11.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bm_12.DataSource = dt_bmdm;
            ddlt_bm_12.DataTextField = "mc";
            ddlt_bm_12.DataValueField = "bm";
            ddlt_bm_12.DataBind();
            ddlt_bm_12.Items.Insert(0, new ListItem("全部", "-1"));
            //地区（支线）
            ddlt_dq_12.DataSource = SysData.ZXDM().Copy();
            ddlt_dq_12.DataTextField = "mc";
            ddlt_dq_12.DataValueField = "bm";
            ddlt_dq_12.DataBind();
            ddlt_dq_12.Items.Insert(0, new ListItem("全部", "-1"));

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

            string bmdm_6 = ddlt_bm_6.SelectedValue.ToString();
            string dqdm_6 = ddlt_dq_6.SelectedValue.ToString();

            string bmdm_7 = ddlt_bm_7.SelectedValue.ToString();
            string dqdm_7 = ddlt_dq_7.SelectedValue.ToString();

            string bmdm_8 = ddlt_bm_8.SelectedValue.ToString();
            string dqdm_8 = ddlt_dq_8.SelectedValue.ToString();

            string bmdm_9 = ddlt_bm_9.SelectedValue.ToString();
            string dqdm_9 = ddlt_dq_9.SelectedValue.ToString();

            string bmdm_10 = ddlt_bm_10.SelectedValue.ToString();
            string dqdm_10 = ddlt_dq_10.SelectedValue.ToString();

            string bmdm_11 = ddlt_bm_11.SelectedValue.ToString();
            string dqdm_11 = ddlt_dq_11.SelectedValue.ToString();

            string bmdm_12 = ddlt_bm_12.SelectedValue.ToString();
            string dqdm_12 = ddlt_dq_12.SelectedValue.ToString();

            DataTable dt = new DataTable();
            dt = yjgl.Select_YGByBMDQ(dqdm, bmdm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
            DataTable dt_1 = new DataTable();
            dt_1 = yjgl.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_xzb.DataSource = dt_1;
            ddlt_xzb.DataTextField = "xm";
            ddlt_xzb.DataValueField = "bh";
            ddlt_xzb.DataBind();
            DataTable dt_2 = new DataTable();
            dt_2 = yjgl.Select_YGByBMDQ(dqdm_2, bmdm_2);
            ddlt_gzdbzr.DataSource = dt_2;
            ddlt_gzdbzr.DataTextField = "xm";
            ddlt_gzdbzr.DataValueField = "bh";
            ddlt_gzdbzr.DataBind();
            DataTable dt_3 = new DataTable();
            dt_3 = yjgl.Select_YGByBMDQ(dqdm_3, bmdm_3);
            ddlt_ttzb.DataSource = dt_3;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
            DataTable dt_4 = new DataTable();
            dt_4 = yjgl.Select_YGByBMDQ(dqdm_4, bmdm_4);
            ddlt_zdzb.DataSource = dt_4;
            ddlt_zdzb.DataTextField = "xm";
            ddlt_zdzb.DataValueField = "bh";
            ddlt_zdzb.DataBind();
            DataTable dt_5 = new DataTable();
            dt_5 = yjgl.Select_YGByBMDQ(dqdm_5, bmdm_5);
            ddlt_qb.DataSource = dt_5;
            ddlt_qb.DataTextField = "xm";
            ddlt_qb.DataValueField = "bh";
            ddlt_qb.DataBind();
            DataTable dt_6 = new DataTable();
            dt_6 = yjgl.Select_YGByBMDQ(dqdm_6, bmdm_6);
            ddlt_tddb.DataSource = dt_6;
            ddlt_tddb.DataTextField = "xm";
            ddlt_tddb.DataValueField = "bh";
            ddlt_tddb.DataBind();
            DataTable dt_7 = new DataTable();
            dt_7 = yjgl.Select_YGByBMDQ(dqdm_7, bmdm_7);
            ddlt_tx.DataSource = dt_7;
            ddlt_tx.DataTextField = "xm";
            ddlt_tx.DataValueField = "bh";
            ddlt_tx.DataBind();
            DataTable dt_8 = new DataTable();
            dt_8 = yjgl.Select_YGByBMDQ(dqdm_8, bmdm_8);
            ddlt_dh.DataSource = dt_8;
            ddlt_dh.DataTextField = "xm";
            ddlt_dh.DataValueField = "bh";
            ddlt_dh.DataBind();
            DataTable dt_9 = new DataTable();
            dt_9 = yjgl.Select_YGByBMDQ(dqdm_9, bmdm_9);
            ddlt_bt.DataSource = dt_9;
            ddlt_bt.DataTextField = "xm";
            ddlt_bt.DataValueField = "bh";
            ddlt_bt.DataBind();
            DataTable dt_10 = new DataTable();
            dt_10 = yjgl.Select_YGByBMDQ(dqdm_10, bmdm_10);
            ddlt_qxjw.DataSource = dt_10;
            ddlt_qxjw.DataTextField = "xm";
            ddlt_qxjw.DataValueField = "bh";
            ddlt_qxjw.DataBind();
            DataTable dt_11 = new DataTable();
            dt_11 = yjgl.Select_YGByBMDQ(dqdm_11, bmdm_11);
            ddlt_qxgc.DataSource = dt_11;
            ddlt_qxgc.DataTextField = "xm";
            ddlt_qxgc.DataValueField = "bh";
            ddlt_qxgc.DataBind();
            DataTable dt_12 = new DataTable();
            dt_12 = yjgl.Select_YGByBMDQ(dqdm_12, bmdm_12);
            ddlt_qxyb.DataSource = dt_12;
            ddlt_qxyb.DataTextField = "xm";
            ddlt_qxyb.DataValueField = "bh";
            ddlt_qxyb.DataBind();
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
            dt = yjgl.Select_YGByBMDQ(dqdm, bmdm);
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
            dt = yjgl.Select_YGByBMDQ(dqdm, bmdm);
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
                zbldbh = ddlt_zbld.SelectedValue.ToString()+",";
            }
        }

        protected void ddlt_dq_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_1 = ddlt_bm.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_1 = new DataTable();
            dt_1 = yjgl.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_xzb.DataSource = dt_1;
            ddlt_xzb.DataTextField = "xm";
            ddlt_xzb.DataValueField = "bh";
            ddlt_xzb.DataBind();
        }

        protected void ddlt_bm_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_1 = ddlt_bm.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_1 = new DataTable();
            dt_1 = yjgl.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_xzb.DataSource = dt_1;
            ddlt_xzb.DataTextField = "xm";
            ddlt_xzb.DataValueField = "bh";
            ddlt_xzb.DataBind();
        }

        protected void btn_bc_1_Click(object sender, EventArgs e)
        {
            /*           string bmdm_1 = ddlt_bm.SelectedValue.ToString();
                       string dqdm_1 = ddlt_dq.SelectedValue.ToString();
                       string xzb = ddlt_xzb.SelectedValue.ToString();
                       xzbbh = "";
                       //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                       if (ddlt_xzb.Items.Count > 0)
                       {
                           tbx_xzb.Text += ddlt_xzb.SelectedItem.Text + ",";
                           xzbbh += ddlt_xzb.SelectedValue.ToString() + ",";
                       }*/

            if (tbx_xzb.Text == "")
            {
                string bmdm_1 = ddlt_bm.SelectedValue.ToString();
                string dqdm_1 = ddlt_bm.SelectedValue.ToString();
                xzbbh = "";
                if (ddlt_xzb.Items.Count > 0)
                {
                    tbx_xzb.Text += ddlt_xzb.SelectedItem.Text;
                    xzbbh += ddlt_xzb.SelectedValue.ToString();
                }
            }
            else
            {
                xzbbh_cs = xzbbh + "," + ddlt_xzb.SelectedValue.ToString();
                string[] Arry_pxry = xzbbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_pxry) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_xzb.Text = tbx_xzb.Text.ToString() + "," + ddlt_xzb.SelectedItem.Text;
                    xzbbh = xzbbh + "," + ddlt_xzb.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_2 = ddlt_bm.SelectedValue.ToString();
            string dqdm_2 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_2 = new DataTable();
            dt_2 = yjgl.Select_YGByBMDQ(dqdm_2, bmdm_2);
            ddlt_gzdbzr.DataSource = dt_2;
            ddlt_gzdbzr.DataTextField = "xm";
            ddlt_gzdbzr.DataValueField = "bh";
            ddlt_gzdbzr.DataBind();
        }

        protected void ddlt_bm_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_2 = ddlt_bm.SelectedValue.ToString();
            string dqdm_2 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_2 = new DataTable();
            dt_2 = yjgl.Select_YGByBMDQ(dqdm_2, bmdm_2);
            ddlt_gzdbzr.DataSource = dt_2;
            ddlt_gzdbzr.DataTextField = "xm";
            ddlt_gzdbzr.DataValueField = "bh";
            ddlt_gzdbzr.DataBind();
        }

        protected void btn_bc_2_Click(object sender, EventArgs e)
        {
            /* string bmdm_2 = ddlt_bm.SelectedValue.ToString();
             string dqdm_2 = ddlt_dq.SelectedValue.ToString();
             string gzdbzr = ddlt_gzdbzr.SelectedValue.ToString();
             gzdbzrbh = "";
             //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
             if (ddlt_gzdbzr.Items.Count > 0)
             {
                 tbx_gzdbzr.Text += ddlt_gzdbzr.SelectedItem.Text + ",";
                 gzdbzrbh += ddlt_gzdbzr.SelectedValue.ToString() + ",";
             }*/

            if (tbx_gzdbzr.Text == "")
            {
                string bmdm_2 = ddlt_bm.SelectedValue.ToString();
                string dqdm_2 = ddlt_bm.SelectedValue.ToString();
                gzdbzrbh = "";
                if (ddlt_gzdbzr.Items.Count > 0)
                {
                    tbx_gzdbzr.Text += ddlt_gzdbzr.SelectedItem.Text;
                    gzdbzrbh += ddlt_gzdbzr.SelectedValue.ToString();
                }
            }
            else
            {
                gzdbzrbh_cs = gzdbzrbh + "," + ddlt_gzdbzr.SelectedValue.ToString();
                string[] Arry_gzdbzrbh = gzdbzrbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_gzdbzrbh) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_gzdbzr.Text = tbx_gzdbzr.Text.ToString() + "," + ddlt_gzdbzr.SelectedItem.Text;
                    gzdbzrbh = gzdbzrbh + "," + ddlt_gzdbzr.SelectedValue.ToString();
                }
            }



        }

        protected void ddlt_dq_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_3 = ddlt_bm.SelectedValue.ToString();
            string dqdm_3 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_3 = new DataTable();
            dt_3 = yjgl.Select_YGByBMDQ(dqdm_3, bmdm_3);
            ddlt_ttzb.DataSource = dt_3;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
        }

        protected void ddlt_bm_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_3 = ddlt_bm.SelectedValue.ToString();
            string dqdm_3 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_3 = new DataTable();
            dt_3 = yjgl.Select_YGByBMDQ(dqdm_3, bmdm_3);
            ddlt_ttzb.DataSource = dt_3;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
        }

        protected void btn_bc_3_Click(object sender, EventArgs e)
        {
            /*string bmdm_3 = ddlt_bm.SelectedValue.ToString();
            string dqdm_3 = ddlt_dq.SelectedValue.ToString();
            string ttzb = ddlt_ttzb.SelectedValue.ToString();
            ttzbbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_ttzb.Items.Count > 0)
            {
                tbx_ttzb.Text += ddlt_ttzb.SelectedItem.Text + ",";
                ttzbbh += ddlt_ttzb.SelectedValue.ToString() + ",";
            }
*/
            if (tbx_ttzb.Text == "")
            {
                string bmdm_3 = ddlt_bm.SelectedValue.ToString();
                string dqdm_3 = ddlt_dq.SelectedValue.ToString();
                ttzbbh = "";
                if (ddlt_ttzb.Items.Count > 0)
                {
                    tbx_ttzb.Text += ddlt_ttzb.SelectedItem.Text;
                    ttzbbh += ddlt_ttzb.SelectedValue.ToString();
                }
            }
            else
            {
                ttzbbh_cs = ttzbbh + "," + ddlt_ttzb.SelectedValue.ToString();
                string[] Arry_ttzbbh = ttzbbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_ttzbbh) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_ttzb.Text = tbx_ttzb.Text.ToString() + "," + ddlt_ttzb.SelectedItem.Text;
                    ttzbbh = ttzbbh + "," + ddlt_ttzb.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_4 = ddlt_bm.SelectedValue.ToString();
            string dqdm_4 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_4 = new DataTable();
            dt_4 = yjgl.Select_YGByBMDQ(dqdm_4, bmdm_4);
            ddlt_zdzb.DataSource = dt_4;
            ddlt_zdzb.DataTextField = "xm";
            ddlt_zdzb.DataValueField = "bh";
            ddlt_zdzb.DataBind();
        }

        protected void ddlt_bm_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_4 = ddlt_bm.SelectedValue.ToString();
            string dqdm_4 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_4 = new DataTable();
            dt_4 = yjgl.Select_YGByBMDQ(dqdm_4, bmdm_4);
            ddlt_zdzb.DataSource = dt_4;
            ddlt_zdzb.DataTextField = "xm";
            ddlt_zdzb.DataValueField = "bh";
            ddlt_zdzb.DataBind();
        }

        protected void btn_bc_4_Click(object sender, EventArgs e)
        {
            /* string bmdm_4 = ddlt_bm.SelectedValue.ToString();
             string dqdm_4 = ddlt_dq.SelectedValue.ToString();
             string zdzb = ddlt_zdzb.SelectedValue.ToString();
             zdzbbh = "";
             //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
             if (ddlt_zdzb.Items.Count > 0)
             {
                 tbx_zdzb.Text += ddlt_zdzb.SelectedItem.Text + ",";
                 zdzbbh += ddlt_zdzb.SelectedValue.ToString() + ",";
             }*/


            if (tbx_zdzb.Text == "")
            {
                string bmdm_4 = ddlt_bm.SelectedValue.ToString();
                string dqdm_4 = ddlt_dq.SelectedValue.ToString();
                zdzbbh = "";
                if (ddlt_zdzb.Items.Count > 0)
                {
                    tbx_zdzb.Text += ddlt_zdzb.SelectedItem.Text;
                    zdzbbh += ddlt_zdzb.SelectedValue.ToString();
                }
            }
            else
            {
                zdzbbh_cs = zdzbbh + "," + ddlt_zdzb.SelectedValue.ToString();
                string[] Arry_zdzb = zdzbbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_zdzb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_zdzb.Text = tbx_zdzb.Text.ToString() + "," + ddlt_zdzb.SelectedItem.Text;
                    zdzbbh = zdzbbh + "," + ddlt_zdzb.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_5 = ddlt_bm.SelectedValue.ToString();
            string dqdm_5 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_5 = new DataTable();
            dt_5 = yjgl.Select_YGByBMDQ(dqdm_5, bmdm_5);
            ddlt_qb.DataSource = dt_5;
            ddlt_qb.DataTextField = "xm";
            ddlt_qb.DataValueField = "bh";
            ddlt_qb.DataBind();
        }

        protected void ddlt_bm_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_5 = ddlt_bm.SelectedValue.ToString();
            string dqdm_5 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_5 = new DataTable();
            dt_5 = yjgl.Select_YGByBMDQ(dqdm_5, bmdm_5);
            ddlt_qb.DataSource = dt_5;
            ddlt_qb.DataTextField = "xm";
            ddlt_qb.DataValueField = "bh";
            ddlt_qb.DataBind();
        }

        protected void btn_bc_5_Click(object sender, EventArgs e)
        {
            /* string bmdm_5 = ddlt_bm.SelectedValue.ToString();
             string dqdm_5 = ddlt_dq.SelectedValue.ToString();
             string qb = ddlt_qb.SelectedValue.ToString();
             qbbh = "";
             //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
             if (ddlt_qb.Items.Count > 0)
             {
                 tbx_qb.Text += ddlt_qb.SelectedItem.Text + ",";
                 qbbh += ddlt_qb.SelectedValue.ToString() + ",";
             }
 */
            if (tbx_qb.Text == "")
            {
                string bmdm_5 = ddlt_bm.SelectedValue.ToString();
                string dqdm_5 = ddlt_dq.SelectedValue.ToString();
                qbbh = "";
                if (ddlt_qb.Items.Count > 0)
                {
                    tbx_qb.Text += ddlt_qb.SelectedItem.Text;
                    qbbh += ddlt_qb.SelectedValue.ToString();
                }
            }
            else
            {
                qbbh_cs = qbbh + "," + ddlt_qb.SelectedValue.ToString();
                string[] Arry_qb = qbbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_qb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_qb.Text = tbx_qb.Text.ToString() + "," + ddlt_qb.SelectedItem.Text;
                    qbbh = qbbh + "," + ddlt_qb.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_6 = ddlt_bm.SelectedValue.ToString();
            string dqdm_6 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_6 = new DataTable();
            dt_6 = yjgl.Select_YGByBMDQ(dqdm_6, bmdm_6);
            ddlt_tddb.DataSource = dt_6;
            ddlt_tddb.DataTextField = "xm";
            ddlt_tddb.DataValueField = "bh";
            ddlt_tddb.DataBind();
        }

        protected void ddlt_bm_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_6 = ddlt_bm.SelectedValue.ToString();
            string dqdm_6 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_6 = new DataTable();
            dt_6 = yjgl.Select_YGByBMDQ(dqdm_6, bmdm_6);
            ddlt_tddb.DataSource = dt_6;
            ddlt_tddb.DataTextField = "xm";
            ddlt_tddb.DataValueField = "bh";
            ddlt_tddb.DataBind();
        }

        protected void btn_bc_6_Click(object sender, EventArgs e)
        {
            /*        string bmdm_6 = ddlt_bm.SelectedValue.ToString();
                    string dqdm_6 = ddlt_dq.SelectedValue.ToString();
                    string tddb = ddlt_tddb.SelectedValue.ToString();
                    tddbbh = "";
                    //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                    if (ddlt_tddb.Items.Count > 0)
                    {
                        tbx_tddb.Text += ddlt_tddb.SelectedItem.Text + ",";
                        tddbbh += ddlt_tddb.SelectedValue.ToString() + ",";
                    }
        */
            if (tbx_tddb.Text == "")
            {
                string bmdm_5 = ddlt_bm.SelectedValue.ToString();
                string dqdm_5 = ddlt_dq.SelectedValue.ToString();
                tddbbh = "";
                if (ddlt_tddb.Items.Count > 0)
                {
                    tbx_tddb.Text += ddlt_tddb.SelectedItem.Text;
                    tddbbh += ddlt_tddb.SelectedValue.ToString();
                }
            }
            else
            {
                tddbbh_cs = tddbbh + "," + ddlt_tddb.SelectedValue.ToString();
                string[] Arry_tddb = tddbbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_tddb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_tddb.Text = tbx_tddb.Text.ToString() + "," + ddlt_tddb.SelectedItem.Text;
                    tddbbh = tddbbh + "," + ddlt_tddb.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_7 = ddlt_bm.SelectedValue.ToString();
            string dqdm_7 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_7 = new DataTable();
            dt_7 = yjgl.Select_YGByBMDQ(dqdm_7, bmdm_7);
            ddlt_tx.DataSource = dt_7;
            ddlt_tx.DataTextField = "xm";
            ddlt_tx.DataValueField = "bh";
            ddlt_tx.DataBind();
        }

        protected void ddlt_bm_7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_7 = ddlt_bm.SelectedValue.ToString();
            string dqdm_7 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_7 = new DataTable();
            dt_7 = yjgl.Select_YGByBMDQ(dqdm_7, bmdm_7);
            ddlt_tx.DataSource = dt_7;
            ddlt_tx.DataTextField = "xm";
            ddlt_tx.DataValueField = "bh";
            ddlt_tx.DataBind();
        }

        protected void btn_bc_7_Click(object sender, EventArgs e)
        {
            /*   string bmdm_7 = ddlt_bm.SelectedValue.ToString();
               string dqdm_7 = ddlt_dq.SelectedValue.ToString();
               string tx = ddlt_tx.SelectedValue.ToString();
               txbh = "";
               //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
               if (ddlt_tx.Items.Count > 0)
               {
                   tbx_tx.Text += ddlt_tx.SelectedItem.Text + ",";
                   txbh += ddlt_tx.SelectedValue.ToString() + ",";
               }
   */
            if (tbx_tx.Text == "")
            {
                string bmdm_7 = ddlt_bm.SelectedValue.ToString();
                string dqdm_7 = ddlt_dq.SelectedValue.ToString();
                txbh = "";
                if (ddlt_tx.Items.Count > 0)
                {
                    tbx_tx.Text += ddlt_tx.SelectedItem.Text;
                    txbh += ddlt_tx.SelectedValue.ToString();
                }
            }
            else
            {
                txbh_cs = txbh + "," + ddlt_tx.SelectedValue.ToString();
                string[] Arry_tx = txbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_tx) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_tx.Text = tbx_tx.Text.ToString() + "," + ddlt_tx.SelectedItem.Text;
                    txbh = txbh + "," + ddlt_tx.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_8 = ddlt_bm.SelectedValue.ToString();
            string dqdm_8 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_8 = new DataTable();
            dt_8 = yjgl.Select_YGByBMDQ(dqdm_8, bmdm_8);
            ddlt_dh.DataSource = dt_8;
            ddlt_dh.DataTextField = "xm";
            ddlt_dh.DataValueField = "bh";
            ddlt_dh.DataBind();
        }

        protected void ddlt_bm_8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_8 = ddlt_bm.SelectedValue.ToString();
            string dqdm_8 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_8 = new DataTable();
            dt_8 = yjgl.Select_YGByBMDQ(dqdm_8, bmdm_8);
            ddlt_dh.DataSource = dt_8;
            ddlt_dh.DataTextField = "xm";
            ddlt_dh.DataValueField = "bh";
            ddlt_dh.DataBind();
        }

        protected void btn_bc_8_Click(object sender, EventArgs e)
        {
            /*   string bmdm_8 = ddlt_bm.SelectedValue.ToString();
               string dqdm_8 = ddlt_dq.SelectedValue.ToString();
               string dh = ddlt_dh.SelectedValue.ToString();
               dhbh = "";
               //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
               if (ddlt_dh.Items.Count > 0)
               {
                   tbx_dh.Text += ddlt_dh.SelectedItem.Text + ",";
                   dhbh += ddlt_dh.SelectedValue.ToString() + ",";
               }*/
            if (tbx_dh.Text == "")
            {
                string bmdm_5 = ddlt_bm.SelectedValue.ToString();
                string dqdm_5 = ddlt_dq.SelectedValue.ToString();
                dhbh = "";
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_dh.Items.Count > 0)
                {
                    tbx_dh.Text += ddlt_dh.SelectedItem.Text;
                    dhbh += ddlt_dh.SelectedValue.ToString();
                }
            }
            else
            {
                dhbh_cs = dhbh + "," + ddlt_dh.SelectedValue.ToString();
                string[] Arry_dh = dhbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_dh) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_dh.Text = tbx_dh.Text.ToString() + "," + ddlt_dh.SelectedItem.Text;
                    dhbh = dhbh + "," + ddlt_dh.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_9 = ddlt_bm.SelectedValue.ToString();
            string dqdm_9 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_9 = new DataTable();
            dt_9 = yjgl.Select_YGByBMDQ(dqdm_9, bmdm_9);
            ddlt_bt.DataSource = dt_9;
            ddlt_bt.DataTextField = "xm";
            ddlt_bt.DataValueField = "bh";
            ddlt_bt.DataBind();
        }

        protected void ddlt_bm_9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_9 = ddlt_bm.SelectedValue.ToString();
            string dqdm_9 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_9 = new DataTable();
            dt_9 = yjgl.Select_YGByBMDQ(dqdm_9, bmdm_9);
            ddlt_bt.DataSource = dt_9;
            ddlt_bt.DataTextField = "xm";
            ddlt_bt.DataValueField = "bh";
            ddlt_bt.DataBind();
        }

        protected void btn_bc_9_Click(object sender, EventArgs e)
        {
            /* string bmdm_9 = ddlt_bm.SelectedValue.ToString();
             string dqdm_9 = ddlt_dq.SelectedValue.ToString();
             string bt = ddlt_bt.SelectedValue.ToString();
             btbh = "";
             //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
             if (ddlt_bt.Items.Count > 0)
             {
                 tbx_bt.Text += ddlt_bt.SelectedItem.Text + ",";
                 btbh += ddlt_bt.SelectedValue.ToString() + ",";
             }*/

            if (tbx_bt.Text == "")
            {
                string bmdm_5 = ddlt_bm.SelectedValue.ToString();
                string dqdm_5 = ddlt_dq.SelectedValue.ToString();
                btbh = "";
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_bt.Items.Count > 0)
                {
                    tbx_bt.Text += ddlt_bt.SelectedItem.Text;
                    btbh += ddlt_bt.SelectedValue.ToString();
                }
            }
            else
            {
                btbh_cs = btbh + "," + ddlt_bt.SelectedValue.ToString();
                string[] Arry_bt = btbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_bt) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_bt.Text = tbx_bt.Text.ToString() + "," + ddlt_bt.SelectedItem.Text;
                    btbh = btbh + "," + ddlt_bt.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_10 = ddlt_bm.SelectedValue.ToString();
            string dqdm_10 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_10 = new DataTable();
            dt_10 = yjgl.Select_YGByBMDQ(dqdm_10, bmdm_10);
            ddlt_qxjw.DataSource = dt_10;
            ddlt_qxjw.DataTextField = "xm";
            ddlt_qxjw.DataValueField = "bh";
            ddlt_qxjw.DataBind();
        }

        protected void ddlt_bm_10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_10 = ddlt_bm.SelectedValue.ToString();
            string dqdm_10 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_10 = new DataTable();
            dt_10 = yjgl.Select_YGByBMDQ(dqdm_10, bmdm_10);
            ddlt_qxjw.DataSource = dt_10;
            ddlt_qxjw.DataTextField = "xm";
            ddlt_qxjw.DataValueField = "bh";
            ddlt_qxjw.DataBind();
        }

        protected void btn_bc_10_Click(object sender, EventArgs e)
        {
            /*    string bmdm_10 = ddlt_bm.SelectedValue.ToString();
                string dqdm_10 = ddlt_dq.SelectedValue.ToString();
                string qxjw = ddlt_qxjw.SelectedValue.ToString();
                qxjwbh = "";
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_qxjw.Items.Count > 0)
                {
                    tbx_qxjw.Text += ddlt_qxjw.SelectedItem.Text + ",";
                    qxjwbh += ddlt_qxjw.SelectedValue.ToString() + ",";
                }*/

            if (tbx_qxjw.Text == "")
            {
                string bmdm_5 = ddlt_bm.SelectedValue.ToString();
                string dqdm_5 = ddlt_dq.SelectedValue.ToString();
                qxjwbh = "";
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_qxjw.Items.Count > 0)
                {
                    tbx_qxjw.Text += ddlt_qxjw.SelectedItem.Text;
                    qxjwbh += ddlt_qxjw.SelectedValue.ToString();
                }
            }
            else
            {
                qxjwbh_cs = qxjwbh + "," + ddlt_qxjw.SelectedValue.ToString();
                string[] Arry_qxjw = qxjwbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_qxjw) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_qxjw.Text = tbx_qxjw.Text.ToString() + "," + ddlt_qxjw.SelectedItem.Text;
                    qxjwbh = qxjwbh + "," + ddlt_qxjw.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_11_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_11 = ddlt_bm.SelectedValue.ToString();
            string dqdm_11 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_11 = new DataTable();
            dt_11 = yjgl.Select_YGByBMDQ(dqdm_11, bmdm_11);
            ddlt_qxgc.DataSource = dt_11;
            ddlt_qxgc.DataTextField = "xm";
            ddlt_qxgc.DataValueField = "bh";
            ddlt_qxgc.DataBind();
        }

        protected void ddlt_bm_11_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_11 = ddlt_bm.SelectedValue.ToString();
            string dqdm_11 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_11 = new DataTable();
            dt_11 = yjgl.Select_YGByBMDQ(dqdm_11, bmdm_11);
            ddlt_qxgc.DataSource = dt_11;
            ddlt_qxgc.DataTextField = "xm";
            ddlt_qxgc.DataValueField = "bh";
            ddlt_qxgc.DataBind();
        }

        protected void btn_bc_11_Click(object sender, EventArgs e)
        {
            /*string bmdm_11 = ddlt_bm.SelectedValue.ToString();
            string dqdm_11 = ddlt_dq.SelectedValue.ToString();
            string qxgc = ddlt_qxgc.SelectedValue.ToString();
            qxgcbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_qxgc.Items.Count > 0)
            {
                tbx_qxgc.Text += ddlt_qxgc.SelectedItem.Text + ",";
                qxgcbh += ddlt_qxgc.SelectedValue.ToString() + ",";
            }
*/

            if (tbx_qxgc.Text == "")
            {
                string bmdm_5 = ddlt_bm.SelectedValue.ToString();
                string dqdm_5 = ddlt_dq.SelectedValue.ToString();
                qxgcbh = "";
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_qxgc.Items.Count > 0)
                {
                    tbx_qxgc.Text += ddlt_qxgc.SelectedItem.Text;
                    qxgcbh += ddlt_qxgc.SelectedValue.ToString();
                }
            }
            else
            {
                qxgcbh_cs = qxgcbh + "," + ddlt_qxgc.SelectedValue.ToString();
                string[] Arry_qxgc = qxgcbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_qxgc) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_qxgc.Text = tbx_qxgc.Text.ToString() + "," + ddlt_qxgc.SelectedItem.Text;
                    qxgcbh = qxgcbh + "," + ddlt_qxgc.SelectedValue.ToString();
                }
            }
        }

        protected void ddlt_dq_12_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_12 = ddlt_bm.SelectedValue.ToString();
            string dqdm_12 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_12 = new DataTable();
            dt_12 = yjgl.Select_YGByBMDQ(dqdm_12, bmdm_12);
            ddlt_qxyb.DataSource = dt_12;
            ddlt_qxyb.DataTextField = "xm";
            ddlt_qxyb.DataValueField = "bh";
            ddlt_qxyb.DataBind();
        }

        protected void ddlt_bm_12_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_12 = ddlt_bm.SelectedValue.ToString();
            string dqdm_12 = ddlt_dq.SelectedValue.ToString();
            DataTable dt_12 = new DataTable();
            dt_12 = yjgl.Select_YGByBMDQ(dqdm_12, bmdm_12);
            ddlt_qxyb.DataSource = dt_12;
            ddlt_qxyb.DataTextField = "xm";
            ddlt_qxyb.DataValueField = "bh";
            ddlt_qxyb.DataBind();
        }

        protected void btn_bc_12_Click(object sender, EventArgs e)
        {
            /*     string bmdm_12 = ddlt_bm.SelectedValue.ToString();
                 string dqdm_12 = ddlt_dq.SelectedValue.ToString();
                 string qxyb = ddlt_qxyb.SelectedValue.ToString();
                 qxybbh = "";
                 //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                 if (ddlt_qxyb.Items.Count > 0)
                 {
                     tbx_qxyb.Text += ddlt_qxyb.SelectedItem.Text + ",";
                     qxybbh += ddlt_qxyb.SelectedValue.ToString() + ",";
                 }
     */

            if (tbx_qxyb.Text == "")
            {
                string bmdm_12 = ddlt_bm.SelectedValue.ToString();
                string dqdm_12 = ddlt_dq.SelectedValue.ToString();
                qxybbh = "";
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_qxyb.Items.Count > 0)
                {
                    tbx_qxyb.Text += ddlt_qxyb.SelectedItem.Text;
                    qxybbh += ddlt_qxyb.SelectedValue.ToString();
                }
            }
            else
            {
                qxybbh_cs = qxybbh + "," + ddlt_qxyb.SelectedValue.ToString();
                string[] Arry_qxyb = qxybbh_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_qxyb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_qxyb.Text = tbx_qxyb.Text.ToString() + "," + ddlt_qxyb.SelectedItem.Text;
                    qxybbh = qxybbh + "," + ddlt_qxyb.SelectedValue.ToString();
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_yjgl.p_rq = Convert.ToDateTime(tbx_rq.Text.ToString().Trim());
            struct_yjgl.p_zbld = zbldbh;
            struct_yjgl.p_xzb = xzbbh;
            struct_yjgl.p_gzdbzr = gzdbzrbh;
            struct_yjgl.p_ttzb = ttzbbh;
            struct_yjgl.p_zdzb = zdzbbh;
            struct_yjgl.p_qb = qbbh;
            struct_yjgl.p_tddb = tddbbh;
            struct_yjgl.p_tx = txbh;
            struct_yjgl.p_dh = dhbh;
            struct_yjgl.p_bt = btbh;
            struct_yjgl.p_qxjw = qxjwbh;
            struct_yjgl.p_qxgc = qxgcbh;
            struct_yjgl.p_qxyb = qxybbh;
            struct_yjgl.p_qxgczbdh = tbx_qxgczbdh.Text.ToString().Trim();
            struct_yjgl.p_qxybzbdh = tbx_qxybzbdh.Text.ToString().Trim();
            struct_yjgl.p_tdzbdh = tbx_tdzbdh.Text.ToString().Trim();
            struct_yjgl.p_dhddh = tbx_dhddh.Text.ToString().Trim();
            struct_yjgl.p_xlsdh = tbx_xlsdh.Text.ToString().Trim();
            struct_yjgl.p_btdh = tbx_btdh.Text.ToString().Trim();
            struct_yjgl.p_zdzbdh = tbx_zdzbdh.Text.ToString().Trim();
            struct_yjgl.p_ttzbdh = tbx_ttzbdh.Text.ToString().Trim();
            struct_yjgl.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();

            struct_yjgl.p_czfs = "02";
            struct_yjgl.p_czxx = "位置：航务综合报送->值班表->添加   描述：员工编号：" + _usState.userLoginName;
            try
            {
                yjgl.Insert_YJGL(struct_yjgl);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('添加成功');location.href='BS_YJGLB.aspx';</script>");
            }
            catch (EMException ex)
            {
                Response.Write(EMException.ShowErrorScript(ex));
                return;
            }
        }



        public static bool IsRepeat2(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        array[j].Remove(j);
                        return true;
                    }
                }
            }
            return false;
        }




        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_YJGLB.aspx", true);
        }

        protected void ddlt_sjszbm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}