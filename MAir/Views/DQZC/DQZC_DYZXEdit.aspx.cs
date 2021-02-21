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
using System.IO;
using Sys;

namespace CUST.WKG
{
    public partial class DQZC_DYZXEdit : System.Web.UI.Page
    {
        private UserState _usState;
        private long id;
        public bool flag = true;
        public int i = 0;
        private DataTable dt_detail;
        public DYZX dyzx;
        public ODYZX.Struct_DYZX struct_dyzx;
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
                show();                
                id = Convert.ToInt32(Request.Params["id"].ToString());
                lbl_ygbh.Text = _usState.userLoginName;
               select_detail();
                yg_bind();
                
            }
        }
        public void show()
        {
            Boolean flag = false;
            if (SysData.HasThisBMQX(_usState.userID, "220303") == true)
            {
            
                flag = true;
            }
            if (!flag)
            {
                
                tbx_zysj.Enabled = false;
                tbx_sj.Enabled = false;
                tbx_yxdy.Enabled = false;               
                btn_save.Visible = false;
                ChangeFlag.Value = "false";
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
            //int count = 0;
            ////查询部门权限
            //for (; i < dt_bmdm.Rows.Count; i++)
            //{
            //    check();
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "01" && SysData.HasThisQX("220303", _usState.userID, "01") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (i == dt_bmdm.Rows.Count) { break; }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "02" && SysData.HasThisQX("220303", _usState.userID, "02") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "03" && SysData.HasThisQX("220303", _usState.userID, "03") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "04" && SysData.HasThisQX("220303", _usState.userID, "04") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }

            //    if (dt_bmdm.Rows[i]["dqdm"].ToString() == "05" && SysData.HasThisQX("220303", _usState.userID, "05") == false)
            //    {
            //        dt_bmdm.Rows.RemoveAt(i);
            //        count++;
            //        flag = false;
            //    }
            //    check();
            //}
            //优秀党员
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
        protected void select_detail()
        {

            dt_detail = dyzx.Select_DYZX_Detail(id);
            tbx_sj.Text = dt_detail.Rows[0]["sj"].ToString();//日期            
            tbx_yxdy.Text = dt_detail.Rows[0]["yxdyxm"].ToString();//优秀党员           
            tbx_zysj.Text = dt_detail.Rows[0]["zysj"].ToString();//主要事迹

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {

            #region MyRegion
            int flag = 0;
            //主要事迹
            string jcd = tbx_zysj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jcd))
            {

                lbl_zysj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zysj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (flag == 1) { return; }
            #endregion

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


            struct_dyzx.p_id = Convert.ToInt32(Request.Params["id"].ToString()); //ID

            struct_dyzx.p_bh = ddlt_yxdy.SelectedValue.ToString().Trim();//优秀党员编号            
            struct_dyzx.p_zysj = tbx_zysj.Text.ToString().Trim();//主要事迹

            struct_dyzx.p_czfs = "03";
            struct_dyzx.p_czxx = "位置：党群之窗->党员在线->修改      描述：员工编号：" + _usState.userLoginName
                 + "起止日期：" + struct_dyzx.p_kssj + "截止日期：" + struct_dyzx.p_jssj
                + "备注：";
            dyzx.Update_DYZX(struct_dyzx);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            Server.Transfer("DQZC_DYZX.aspx");

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
            Server.Transfer("DQZC_DYZX.aspx");
        }
        }
    }
