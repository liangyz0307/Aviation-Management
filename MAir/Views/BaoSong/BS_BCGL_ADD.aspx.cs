﻿using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.MKG
{
    public partial class BS_BCGL_ADD : System.Web.UI.Page
    {
        private UserState _usState;
        static string ttzb_cs;
        static string tdzb_cs;
        static string ffzb_cs;
        static string gczb_cs;
        static string ybzb_cs;
        static string zbldbh = "";
        static string ttzbbh = "";
        static string tdzbbh = "";
        static string ffzbbh = "";
        static string gczbbh = "";
        static string ybzbbh = "";
        public bool flag = true;
        public int i = 0;
        private BCGL bcgl;
        private static DataTable dt = new DataTable();
        private Struct_BCGL struct_bcgl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            bcgl = new BCGL(_usState);

            if (!IsPostBack)
            {
                tbx_rq.Attributes.Add("readonly", "readonly");
                yg_bind();
                ddltBind();
                yg_bind1();
                yg_bind2();
                yg_bind3();
                yg_bind4();
                yg_bind5();
            }
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
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;

            }
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
            //机场（支线）
            ddlt_dq.DataSource = SysData.ZXDM().Copy();
            ddlt_dq.DataTextField = "mc";
            ddlt_dq.DataValueField = "bm";
            ddlt_dq.DataBind();
            ddlt_dq.Items.Insert(0, new ListItem("全部", "-1"));

            string bm = ddlt_bm.SelectedValue.ToString();
            string jc = ddlt_dq.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(jc, bm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();

        }
        protected void ddlt_dq_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue.ToString();
            string dq = ddlt_dq.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
        }
        protected void ddlt_bm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue.ToString();
            string dq = ddlt_dq.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue.ToString();
            string jc = ddlt_dq.SelectedValue.ToString();
            string zbld = ddlt_zbld.SelectedValue.ToString();
            zbldbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_zbld.Items.Count > 0)
            {
                tbx_zbld.Text = ddlt_zbld.SelectedItem.Text;
                zbldbh = ddlt_zbld.SelectedValue.ToString() + ",";
            }
        }
        private void yg_bind1()
        {

            DataTable dt_bmdm = SysData.BM().Copy();
            //部门
            ddlt_bm1.DataSource = dt_bmdm;
            ddlt_bm1.DataTextField = "mc";
            ddlt_bm1.DataValueField = "bm";
            ddlt_bm1.DataBind();
            ddlt_bm1.Items.Insert(0, new ListItem("全部", "-1"));
            //机场（支线）
            ddlt_dq1.DataSource = SysData.ZXDM().Copy();
            ddlt_dq1.DataTextField = "mc";
            ddlt_dq1.DataValueField = "bm";
            ddlt_dq1.DataBind();
            ddlt_dq1.Items.Insert(0, new ListItem("全部", "-1"));

            string bm = ddlt_bm1.SelectedValue.ToString();
            string jc = ddlt_dq1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(jc, bm);
            ddlt_ttzb.DataSource = dt;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();

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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Server.Transfer("BS_BCGL.aspx?ygbh=" + _usState.userLoginName);
        }

        protected void ddlt_dq1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm1.SelectedValue.ToString();
            string dq = ddlt_dq1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_ttzb.DataSource = dt;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
        }

        protected void ddlt_bm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm1.SelectedValue.ToString();
            string dq = ddlt_dq1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_ttzb.DataSource = dt;
            ddlt_ttzb.DataTextField = "xm";
            ddlt_ttzb.DataValueField = "bh";
            ddlt_ttzb.DataBind();
        }

        protected void btn_bc1_Click(object sender, EventArgs e)
        {
            /*       string bm = ddlt_bm1.SelectedValue.ToString();
                   string jc = ddlt_dq1.SelectedValue.ToString();
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
                string bmdm_1 = ddlt_bm1.SelectedValue.ToString();
                string dqdm_1 = ddlt_dq1.SelectedValue.ToString();
                //    string dhbzs = ddlt_dhbzs.SelectedValue.ToString();                
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_ttzb.Items.Count > 0)
                {
                    tbx_ttzb.Text += ddlt_ttzb.SelectedItem.Text;
                    ttzbbh = ddlt_ttzb.SelectedValue.ToString();
                }
            }
            else
            {
                ttzb_cs = ttzbbh + "," + ddlt_ttzb.SelectedValue.ToString();
                string[] Arry_pxry = ttzb_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_pxry) == true)
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
        private void yg_bind2()
        {

            DataTable dt_bmdm = SysData.BM().Copy();
            //部门
            ddlt_bm2.DataSource = dt_bmdm;
            ddlt_bm2.DataTextField = "mc";
            ddlt_bm2.DataValueField = "bm";
            ddlt_bm2.DataBind();
            ddlt_bm2.Items.Insert(0, new ListItem("全部", "-1"));
            //机场（支线）
            ddlt_dq2.DataSource = SysData.ZXDM().Copy();
            ddlt_dq2.DataTextField = "mc";
            ddlt_dq2.DataValueField = "bm";
            ddlt_dq2.DataBind();
            ddlt_dq2.Items.Insert(0, new ListItem("全部", "-1"));

            string bm = ddlt_bm2.SelectedValue.ToString();
            string jc = ddlt_dq2.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(jc, bm);
            ddlt_ffzb.DataSource = dt;
            ddlt_ffzb.DataTextField = "xm";
            ddlt_ffzb.DataValueField = "bh";
            ddlt_ffzb.DataBind();

        }
        protected void ddlt_dq2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm2.SelectedValue.ToString();
            string dq = ddlt_dq2.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_ffzb.DataSource = dt;
            ddlt_ffzb.DataTextField = "xm";
            ddlt_ffzb.DataValueField = "bh";
            ddlt_ffzb.DataBind();
        }

        protected void ddlt_bm2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm2.SelectedValue.ToString();
            string dq = ddlt_dq2.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_ffzb.DataSource = dt;
            ddlt_ffzb.DataTextField = "xm";
            ddlt_ffzb.DataValueField = "bh";
            ddlt_ffzb.DataBind();
        }

        protected void btn_bc2_Click(object sender, EventArgs e)
        {
            /*string bm = ddlt_bm2.SelectedValue.ToString();
            string jc = ddlt_dq2.SelectedValue.ToString();
            string ffzb = ddlt_ffzb.SelectedValue.ToString();
            ffzbbh = "";
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_ffzb.Items.Count > 0)
            {
                tbx_ffzb.Text += ddlt_ffzb.SelectedItem.Text + ",";
                ffzbbh += ddlt_ffzb.SelectedValue.ToString() + ",";
            }
*/
            if (tbx_ffzb.Text == "")
            {
                string bmdm_5 = ddlt_bm2.SelectedValue.ToString();
                string dqdm_5 = ddlt_bm2.SelectedValue.ToString();
                ffzbbh = "";
                if (ddlt_ffzb.Items.Count > 0)
                {
                    tbx_ffzb.Text += ddlt_ffzb.SelectedItem.Text;
                    ffzbbh += ddlt_ffzb.SelectedValue.ToString();
                }
            }
            else
            {
                ffzb_cs = ffzbbh + "," + ddlt_ffzb.SelectedValue.ToString();
                string[] Arry_ffzb = ffzb_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_ffzb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_ffzb.Text = tbx_ffzb.Text.ToString() + "," + ddlt_ffzb.SelectedItem.Text;
                    ffzbbh = ffzbbh + "," + ddlt_ffzb.SelectedValue.ToString();
                }
            }
        }
        private void yg_bind3()
        {

            DataTable dt_bmdm = SysData.BM().Copy();
            //部门
            ddlt_bm3.DataSource = dt_bmdm;
            ddlt_bm3.DataTextField = "mc";
            ddlt_bm3.DataValueField = "bm";
            ddlt_bm3.DataBind();
            ddlt_bm3.Items.Insert(0, new ListItem("全部", "-1"));
            //机场（支线）
            ddlt_dq3.DataSource = SysData.ZXDM().Copy();
            ddlt_dq3.DataTextField = "mc";
            ddlt_dq3.DataValueField = "bm";
            ddlt_dq3.DataBind();
            ddlt_dq3.Items.Insert(0, new ListItem("全部", "-1"));

            string bm = ddlt_bm3.SelectedValue.ToString();
            string jc = ddlt_dq3.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(jc, bm);
            ddlt_tdzb.DataSource = dt;
            ddlt_tdzb.DataTextField = "xm";
            ddlt_tdzb.DataValueField = "bh";
            ddlt_tdzb.DataBind();

        }

        protected void ddlt_dq3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm3.SelectedValue.ToString();
            string dq = ddlt_dq3.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_tdzb.DataSource = dt;
            ddlt_tdzb.DataTextField = "xm";
            ddlt_tdzb.DataValueField = "bh";
            ddlt_tdzb.DataBind();
        }

        protected void ddlt_bm3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm3.SelectedValue.ToString();
            string dq = ddlt_dq3.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_tdzb.DataSource = dt;
            ddlt_tdzb.DataTextField = "xm";
            ddlt_tdzb.DataValueField = "bh";
            ddlt_tdzb.DataBind();
        }

        protected void btn_bc3_Click(object sender, EventArgs e)
        {
            /*  string bm = ddlt_bm3.SelectedValue.ToString();
              string jc = ddlt_dq3.SelectedValue.ToString();
              string zbld = ddlt_tdzb.SelectedValue.ToString();
              tdzbbh = "";
              //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
              if (ddlt_tdzb.Items.Count > 0)
              {
                  tbx_tdzb.Text += ddlt_tdzb.SelectedItem.Text + ",";
                  tdzbbh += ddlt_tdzb.SelectedValue.ToString() + ",";
              }*/
            if (tbx_tdzb.Text == "")
            {
                string bmdm_3 = ddlt_bm3.SelectedValue.ToString();
                string dqdm_3 = ddlt_bm3.SelectedValue.ToString();
                tdzbbh = "";
                if (ddlt_tdzb.Items.Count > 0)
                {
                    tbx_tdzb.Text += ddlt_tdzb.SelectedItem.Text;
                    tdzbbh += ddlt_tdzb.SelectedValue.ToString();
                }
            }
            else
            {
                tdzb_cs = tdzbbh + "," + ddlt_tdzb.SelectedValue.ToString();
                string[] Arry_tdzb = tdzb_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_tdzb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_tdzb.Text = tbx_tdzb.Text.ToString() + "," + ddlt_tdzb.SelectedItem.Text;
                    tdzbbh = tdzbbh + "," + ddlt_tdzb.SelectedValue.ToString();
                }
            }
        }
        private void yg_bind4()
        {

            DataTable dt_bmdm = SysData.BM().Copy();
            //部门
            ddlt_bm4.DataSource = dt_bmdm;
            ddlt_bm4.DataTextField = "mc";
            ddlt_bm4.DataValueField = "bm";
            ddlt_bm4.DataBind();
            ddlt_bm4.Items.Insert(0, new ListItem("全部", "-1"));
            //机场（支线）
            ddlt_dq4.DataSource = SysData.ZXDM().Copy();
            ddlt_dq4.DataTextField = "mc";
            ddlt_dq4.DataValueField = "bm";
            ddlt_dq4.DataBind();
            ddlt_dq4.Items.Insert(0, new ListItem("全部", "-1"));

            string bm = ddlt_bm4.SelectedValue.ToString();
            string jc = ddlt_dq4.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(jc, bm);
            ddlt_gczb.DataSource = dt;
            ddlt_gczb.DataTextField = "xm";
            ddlt_gczb.DataValueField = "bh";
            ddlt_gczb.DataBind();

        }

        protected void ddlt_dq4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm4.SelectedValue.ToString();
            string dq = ddlt_dq4.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_gczb.DataSource = dt;
            ddlt_gczb.DataTextField = "xm";
            ddlt_gczb.DataValueField = "bh";
            ddlt_gczb.DataBind();
        }

        protected void ddlt_bm4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm4.SelectedValue.ToString();
            string dq = ddlt_dq4.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_gczb.DataSource = dt;
            ddlt_gczb.DataTextField = "xm";
            ddlt_gczb.DataValueField = "bh";
            ddlt_gczb.DataBind();
        }

        protected void btn_bc4_Click(object sender, EventArgs e)
        {
            /*   string bm = ddlt_bm4.SelectedValue.ToString();
               string jc = ddlt_dq4.SelectedValue.ToString();
               string gczb = ddlt_gczb.SelectedValue.ToString();
               gczbbh = "";
               //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
               if (ddlt_gczb.Items.Count > 0)
               {
                   tbx_gczb.Text += ddlt_gczb.SelectedItem.Text + ",";
                   gczbbh += ddlt_gczb.SelectedValue.ToString() + ",";
               }
   */
            if (tbx_gczb.Text == "")
            {
                string bmdm_4 = ddlt_bm4.SelectedValue.ToString();
                string dqdm_4 = ddlt_bm4.SelectedValue.ToString();
                gczbbh = "";
                if (ddlt_gczb.Items.Count > 0)
                {
                    tbx_gczb.Text += ddlt_gczb.SelectedItem.Text;
                    gczbbh += ddlt_gczb.SelectedValue.ToString();
                }
            }
            else
            {
                gczb_cs = gczbbh + "," + ddlt_gczb.SelectedValue.ToString();
                string[] Arry_qxyb = gczb_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_qxyb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_gczb.Text = tbx_gczb.Text.ToString() + "," + ddlt_gczb.SelectedItem.Text;
                    gczbbh = gczbbh + "," + ddlt_gczb.SelectedValue.ToString();
                }
            }

        }
        private void yg_bind5()
        {

            DataTable dt_bmdm = SysData.BM().Copy();
            //部门
            ddlt_bm5.DataSource = dt_bmdm;
            ddlt_bm5.DataTextField = "mc";
            ddlt_bm5.DataValueField = "bm";
            ddlt_bm5.DataBind();
            ddlt_bm5.Items.Insert(0, new ListItem("全部", "-1"));
            //机场（支线）
            ddlt_dq5.DataSource = SysData.ZXDM().Copy();
            ddlt_dq5.DataTextField = "mc";
            ddlt_dq5.DataValueField = "bm";
            ddlt_dq5.DataBind();
            ddlt_dq5.Items.Insert(0, new ListItem("全部", "-1"));

            string bm = ddlt_bm5.SelectedValue.ToString();
            string jc = ddlt_dq5.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(jc, bm);
            ddlt_ybzb.DataSource = dt;
            ddlt_ybzb.DataTextField = "xm";
            ddlt_ybzb.DataValueField = "bh";
            ddlt_ybzb.DataBind();

        }

        protected void ddlt_dq5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm5.SelectedValue.ToString();
            string dq = ddlt_dq5.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_ybzb.DataSource = dt;
            ddlt_ybzb.DataTextField = "xm";
            ddlt_ybzb.DataValueField = "bh";
            ddlt_ybzb.DataBind();
        }

        protected void ddlt_bm5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm5.SelectedValue.ToString();
            string dq = ddlt_dq5.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = bcgl.Select_YGByBMDQ(dq, bm);
            ddlt_ybzb.DataSource = dt;
            ddlt_ybzb.DataTextField = "xm";
            ddlt_ybzb.DataValueField = "bh";
            ddlt_ybzb.DataBind();
        }

        protected void btn_bc5_Click(object sender, EventArgs e)
        {
            /*  string bm = ddlt_bm5.SelectedValue.ToString();
              string jc = ddlt_dq5.SelectedValue.ToString();
              string zbld = ddlt_ybzb.SelectedValue.ToString();
              ybzbbh = "";
              //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
              if (ddlt_ybzb.Items.Count > 0)
              {
                  tbx_ybzb.Text += ddlt_ybzb.SelectedItem.Text + ",";
                  ybzbbh += ddlt_ybzb.SelectedValue.ToString() + ",";
              }*/

            if (tbx_ybzb.Text == "")
            {
                string bmdm_5 = ddlt_bm5.SelectedValue.ToString();
                string dqdm_5 = ddlt_bm5.SelectedValue.ToString();
                ybzbbh = "";
                if (ddlt_gczb.Items.Count > 0)
                {
                    tbx_ybzb.Text += ddlt_ybzb.SelectedItem.Text;
                    ybzbbh += ddlt_ybzb.SelectedValue.ToString();
                }
            }
            else
            {
                ybzb_cs = ybzbbh + "," + ddlt_ybzb.SelectedValue.ToString();
                string[] Arry_qxyb = ybzb_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_qxyb) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_ybzb.Text = tbx_ybzb.Text.ToString() + "," + ddlt_ybzb.SelectedItem.Text;
                    ybzbbh = ybzbbh + "," + ddlt_ybzb.SelectedValue.ToString();
                }
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (tbx_rq.Text.ToString().Trim() == "")
            {
                struct_bcgl.p_rq = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_bcgl.p_rq = DateTime.Parse(tbx_rq.Text.Trim().ToString());//开始日期       
            }
            struct_bcgl.p_zbld = zbldbh;
            struct_bcgl.p_ttzb = ttzbbh;
            struct_bcgl.p_tdzb = tdzbbh;

            struct_bcgl.p_ffzb = ffzbbh;
            struct_bcgl.p_gczb = gczbbh;
            struct_bcgl.p_ybzb = ybzbbh;

            struct_bcgl.p_ldzbdh = tbx_zblddh.Text.ToString().Trim();
            struct_bcgl.p_tdzbdh = tbx_tdzbdh.Text.ToString().Trim();
            struct_bcgl.p_ttzbdh = tbx_ttzbdh.Text.ToString().Trim();
            struct_bcgl.p_ffzbdh = tbx_ffzbdh.Text.ToString().Trim();
            struct_bcgl.p_ybzbdh = tbx_ybzbdh.Text.ToString().Trim();
            struct_bcgl.p_gczbdh = tbx_gczbdh.Text.ToString().Trim();

            struct_bcgl.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门 

            //如果是初审人录入数据，则状态默认初审通过，即待终审



            struct_bcgl.p_czfs = "02";
            struct_bcgl.p_czxx = "位置：航务综合报送->值班表->添加   描述：员工编号：" + _usState.userLoginName;
            try
            {

                bcgl.Insert_BCGL(struct_bcgl);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('添加成功');location.href='BS_BCGL.aspx';</script>");
            }
            catch (EMException ex)
            {
                Response.Write(EMException.ShowErrorScript(ex));
                return;
            }

        }
    }
}