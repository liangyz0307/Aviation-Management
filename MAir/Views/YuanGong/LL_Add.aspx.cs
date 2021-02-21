using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using System.Globalization;
using CUST;
using CUST.Tools;
using CUST.MKG;
using System.IO;
using Sys;

namespace CUST.WKG
{
    public partial class LL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        //private string id;
        private YGLL ygll;
        public int cpage;
        public int psize;
       
        private Struct_YGLL struct_ygll;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygll = new YGLL(_usState);
            if (!IsPostBack)
            {
                

                lbl_bh.Text = Request.Params["ygbh"].ToString();
                tbx_qzrq.Attributes.Add("readonly", "readonly");
                tbx_jzrq.Attributes.Add("readonly", "readonly");
               
                ddltBind();
            }
        }

        private void ddltBind()
        {
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110302");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();
            ddlt_csr.Items.Insert(0, new ListItem("请选择", "-1"));


            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();
            ddlt_zsr.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region MyRegion
            int flag = 0;

            string gzgw = tbx_gzgw.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzgw))
            {

                lbl_gzgw.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string gzbm = tbx_gzbm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzbm))
            {

                lbl_gzbm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string gzdw = tbx_gzdw.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzdw))
            {

                lbl_gzdw.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string gzdd = tbx_gzdd.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzdd))
            {

                lbl_gzdd.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzdd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string qzrq = tbx_qzrq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(qzrq))
            {

                lbl_qzrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_qzrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string jzrq = tbx_jzrq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jzrq)||DateTime.Compare(Convert.ToDateTime(jzrq), Convert.ToDateTime(qzrq)) <= 0)
            {

                lbl_jzrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jzrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1" || ddlt_csr.SelectedItem.Text.Trim() == "")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1" || ddlt_zsr.SelectedItem.Text.Trim() == "")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            #endregion
           
               
                   
                   // struct_ygll.p_scsj = DateTime.Now;
                    struct_ygll.p_ygbh = lbl_bh.Text.ToString().Trim();//员工编号
                    struct_ygll.p_bmdm = "";
                    struct_ygll.p_gzdw = tbx_gzdw.Text.ToString().Trim();//工作单位
                    struct_ygll.p_gzbm = tbx_gzbm.Text.ToString().Trim();//工作部门
                    struct_ygll.p_gzgw = tbx_gzgw.Text.ToString().Trim();//工作岗位
                    struct_ygll.p_gzdd = tbx_gzdd.Text.ToString().Trim();//工作地点
                    struct_ygll.p_qzrq = tbx_qzrq.Text.ToString().Trim();//起止日期
                    struct_ygll.p_jzrq = tbx_jzrq.Text.ToString().Trim();//截止日期
                    struct_ygll.p_lrr = _usState.userLoginName.ToString();//录入人
                    struct_ygll.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                    struct_ygll.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                    struct_ygll.p_bz = tbx_bz.Text;
                    //struct_ygll.p_sjbs = "0";
                    //如果是初审人录入数据，则状态默认初审通过，即待终审
                    if (struct_ygll.p_lrr.Equals(struct_ygll.p_csr))
                    {
                        struct_ygll.p_sjbs = "0";
                        struct_ygll.p_zt = "2";
                        //给终审人添加提示
                        SysData.Insert_TSR(struct_ygll.p_zsr, "11", "1103", -1);
                    }
                    //如果是终审人录入数据，则状态为审核通过
                    if (struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                    {
                        struct_ygll.p_sjbs = "1";
                        struct_ygll.p_zt = "3";
                    }
                    if (!struct_ygll.p_lrr.Equals(struct_ygll.p_csr) && !struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                    {
                        struct_ygll.p_sjbs = "0";
                        struct_ygll.p_zt = "0";
                    }
                    struct_ygll.p_bhyy = "";
                    struct_ygll.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
                    struct_ygll.p_czfs = "01";
                    struct_ygll.p_czxx = "位置：员工管理->履历管理->添加      描述： 录入人：" + _usState.userLoginName.ToString() + " 员工编号：" + struct_ygll.p_ygbh + "工作单位："
                        + struct_ygll.p_gzdw + "工作部门：" + struct_ygll.p_gzbm + "工作岗位：" + struct_ygll.p_gzgw
                        + "工作地点：" + struct_ygll.p_gzdd + "起止日期：" + struct_ygll.p_qzrq + "截止日期：" + struct_ygll.p_jzrq
                        + "备注：" + struct_ygll.p_bz;
                    ygll.Insert_YGLL(struct_ygll);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);
            //tbx_bh.Text = "";
            tbx_bz.Text = "";
                    tbx_gzbm.Text = "";
                    tbx_gzdd.Text = "";
                    tbx_gzdw.Text = "";
                    tbx_gzgw.Text = "";
                    tbx_jzrq.Text = "";
                    tbx_qzrq.Text = "";
           



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
            Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);

        }




    }
}