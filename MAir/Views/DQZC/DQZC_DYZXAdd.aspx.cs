using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace CUST.WKG
{
    public partial class DQZC_DYZXAdd : System.Web.UI.Page
    {
        public DYZX dyzx;
        public ODYZX.Struct_DYZX struct_dyzx;
        private UserState _usState;
        public bool flag = true;
        public int i = 0;
        static string yxdybh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dyzx = new DYZX(_usState);
            if (!IsPostBack)
            {
                tbx_sj.Attributes.Add("readonly", "readonly");
                lbl_ygbh.Text = _usState.userLoginName;
                yg_bind();
            }
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
            //DataTable dt_bmdm = SysData.BM().Copy();
            ////查询权限
            //int count = 0;
            ////查询权限
            //for (; i < dt_bmdm.Rows.Count; i++)
            //{
            //    check();
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "01" && SysData.HasThisQX("220302", _usState.userID, "01") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (i == dt_bmdm.Rows.Count) { break; }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "02" && SysData.HasThisQX("220302", _usState.userID, "02") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "03" && SysData.HasThisQX("220302", _usState.userID, "03") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "04" && SysData.HasThisQX("220302", _usState.userID, "04") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }

            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "05" && SysData.HasThisQX("220302", _usState.userID, "05") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    check();
            //}
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
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
            dt = dyzx.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_yxdy.DataSource = dt;
            ddlt_yxdy.DataTextField = "xm";
            ddlt_yxdy.DataValueField = "bh";
            ddlt_yxdy.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = dyzx.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_yxdy.DataSource = dt;
            ddlt_yxdy.DataTextField = "xm";
            ddlt_yxdy.DataValueField = "bh";
            ddlt_yxdy.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = dyzx.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_yxdy.DataSource = dt;
            ddlt_yxdy.DataTextField = "xm";
            ddlt_yxdy.DataValueField = "bh";
            ddlt_yxdy.DataBind();
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_yxdy.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_yxdy.Items.Count > 0)
            {
                tbx_yxdy.Text = ddlt_yxdy.SelectedItem.Text;
                yxdybh = ddlt_yxdy.SelectedValue.ToString();
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region MyRegion
            int flag = 0;
            //简要经历和原因
            string zysj = tbx_zysj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zysj))
            {

                lbl_zysj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zysj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (tbx_sj.Text == "")
            {
                lbl_sj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {


                lbl_sj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }


            //优秀党员
            string yxdy = yxdybh;
            if (string.IsNullOrEmpty(yxdy))
            {
                lbl_yxdy.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yxdy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (flag == 1) { return; }
            #endregion
            // struct_baqsjcf.p_id = baqsjcf.SelectIDMaxID(_usState.userGWDM);
            if (tbx_sj.Text.Trim().ToString().Equals(""))
            {
                struct_dyzx.p_kssj = new DateTime();
                struct_dyzx.p_jssj = new DateTime();
            }
            else
            {
                struct_dyzx.p_kssj = DateTime.Parse(tbx_sj.Text.Trim().ToString());//开始日期
                struct_dyzx.p_jssj = DateTime.Parse(tbx_sj.Text.Trim().ToString());//结束日期
            }
            // struct_ygcf.p_sjzl = ddlt_sjzl.SelectedValue.ToString().Trim();//事件种类
            struct_dyzx.p_bh = ddlt_yxdy.SelectedValue.ToString().Trim();
            struct_dyzx.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();
            struct_dyzx.p_gwdm = ddlt_gwdm.SelectedValue.ToString().Trim();

            struct_dyzx.p_zysj = tbx_zysj.Text.ToString().Trim();//主要事迹

            struct_dyzx.p_czfs = "02";
            struct_dyzx.p_czxx = "位置：党群之窗->党员在线->添加   描述：员工编号：" + lbl_ygbh.Text
                 + "起止日期：" + struct_dyzx.p_kssj + "截止日期：" + struct_dyzx.p_jssj
                + "备注：";
            dyzx.Insert_DYZX(struct_dyzx);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            Server.Transfer("DQZC_DYZX.aspx?ygbh=" + lbl_ygbh.Text);
            tbx_sj.Text = "";

            ddlt_yxdy.SelectedValue = "";

            tbx_zysj.Text = "";

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
            Server.Transfer("DQZC_DYZX.aspx?ygbh=" + lbl_ygbh.Text);

        }
    }
}