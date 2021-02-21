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
    public partial class BS_HWGLB_Add : System.Web.UI.Page
    {
        private UserState _usState;
        public HWGLB hwglb;
        public Struct_HWGLB struct_hwglb;
        static string zbldbh = "";
        static string dhbzsbh = "";
        static string dhbzs;
        static string dhbzs_cs;
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
            hwglb = new HWGLB(_usState);
            struct_hwglb = new Struct_HWGLB();
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

        protected void ddlt_dq_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bm.SelectedValue.ToString();
            string dqdm = ddlt_dq.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = hwglb.Select_YGByBMDQ(dqdm, bmdm);
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
            dt = hwglb.Select_YGByBMDQ(dqdm, bmdm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();
        }

        protected void ddlt_dq_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = hwglb.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_dhbzs.DataSource = dt;
            ddlt_dhbzs.DataTextField = "xm";
            ddlt_dhbzs.DataValueField = "bh";
            ddlt_dhbzs.DataBind();
        }

        protected void ddlt_bm_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = hwglb.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_dhbzs.DataSource = dt;
            ddlt_dhbzs.DataTextField = "xm";
            ddlt_dhbzs.DataValueField = "bh";
            ddlt_dhbzs.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_hwglb.p_xq = ddlt_xq.SelectedValue.ToString().Trim();
            struct_hwglb.p_rq = Convert.ToDateTime(tbx_rq.Text.ToString().Trim());
            struct_hwglb.p_zbld = zbldbh;
            struct_hwglb.p_yddh = tbx_yddh.Text.ToString().Trim();
            struct_hwglb.p_gddh = tbx_gddh.Text.ToString().Trim();
            // struct_hwglb.p_dhbzs = dhbzsbh;
            struct_hwglb.p_bz = tbx_bz.Text.ToString().Trim();
            struct_hwglb.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();

            struct_hwglb.p_czfs = "02";
            struct_hwglb.p_czxx = "位置：航务综合报送->值班表->添加   描述：员工编号：" + _usState.userLoginName;


            string[] Arry_tx = dhbzsbh.Split(new char[1] { ',' });

            if (Arry_tx.Length == 1)
            {
                struct_hwglb.p_dhbzs = dhbzsbh;
                try
                {
                    hwglb.Insert__HWGLB(struct_hwglb);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('添加成功');location.href='BS_HWGLB.aspx';</script>");
                }
                catch (EMException ex)
                {
                    Response.Write(EMException.ShowErrorScript(ex));
                    return;
                }
            }
            else
            {
                int i = Arry_tx.Length;
                for (int ry = 0; ry < i; ry++)
                {
                    struct_hwglb.p_dhbzs = Arry_tx[ry].ToString();
                    try
                    {
                        //DataTable ygpx = ChangeTable(struct_pxjl);
                        hwglb.Insert__HWGLB(struct_hwglb);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    }
                    catch (Exception em)
                    {
                        throw em;
                    }

                }

            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_HWGLB.aspx", true);
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

        protected void btn_bc_1_Click(object sender, EventArgs e)
        {
            if (tbx_dhbzs.Text == "")
            {
                string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
                string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();
                //    string dhbzs = ddlt_dhbzs.SelectedValue.ToString();                
                //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
                if (ddlt_dhbzs.Items.Count > 0)
                {
                    tbx_dhbzs.Text = ddlt_dhbzs.SelectedItem.Text;
                    dhbzsbh = ddlt_dhbzs.SelectedValue.ToString();
                }
            }
            else
            {
                dhbzs_cs = dhbzs + "," + ddlt_dhbzs.SelectedValue.ToString();
                string[] Arry_pxry = dhbzs_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_pxry) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此值班人员，不能重复添加！\")</script>");
                    return;
                }
                else
                {
                    tbx_dhbzs.Text = tbx_dhbzs.Text.ToString() + "," + ddlt_dhbzs.SelectedItem.Text;
                    dhbzsbh = dhbzs + "," + ddlt_dhbzs.SelectedValue.ToString();
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

            string bmdm = ddlt_bm.SelectedValue.ToString();
            string dqdm = ddlt_dq.SelectedValue.ToString();

            string bmdm_1 = ddlt_bm_1.SelectedValue.ToString();
            string dqdm_1 = ddlt_dq_1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = hwglb.Select_YGByBMDQ(dqdm, bmdm);
            ddlt_zbld.DataSource = dt;
            ddlt_zbld.DataTextField = "xm";
            ddlt_zbld.DataValueField = "bh";
            ddlt_zbld.DataBind();

            DataTable dt_1 = new DataTable();
            dt_1 = hwglb.Select_YGByBMDQ(dqdm_1, bmdm_1);
            ddlt_dhbzs.DataSource = dt_1;
            ddlt_dhbzs.DataTextField = "xm";
            ddlt_dhbzs.DataValueField = "bh";
            ddlt_dhbzs.DataBind();
        }

        private void ddltBind()
        {
            //星期
            ddlt_xq.DataTextField = "mc";
            ddlt_xq.DataValueField = "bm";
            ddlt_xq.DataSource = SysData.XQ().Copy();
            ddlt_xq.DataBind();
            ddlt_xq.Items.Insert(0, new ListItem("全部", "-1"));

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
    }
}