using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections;
using System.Globalization;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class YLGL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        public YLGL ylgl;
        public Struct_YLGL struct_ylgl;
        static string syrbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ylgl = new YLGL(_usState);
            if (!IsPostBack)
            {
                bind_drop(); 
                 ddltBind();
                 tbx_ylsj.Attributes.Add("readonly", "readonly");
            }
        }
        private void ddltBind()
        {
            //绑定支线名称
            ddlt_zxmc.DataTextField = "mc";
            ddlt_zxmc.DataValueField = "bm";
            ddlt_zxmc.DataSource = SysData.ZXDM().Copy();
            ddlt_zxmc.DataBind();
            ddlt_zxmc.Items.Insert(0, new ListItem("全部", "-1"));

            //绑定预案名
            ddlt_yam.DataTextField = "mc";
            ddlt_zxmc.DataValueField = "sjc";
            DataTable DT = ylgl.Select_Ylgl_Yam_Mc(); 
            ddlt_yam.DataSource = DT;
            ddlt_yam.DataBind();
            ddlt_yam.Items.Insert(0, new ListItem("全部", "-1"));
            //所属演练形式
            ddlt_ylxs.DataTextField = "mc";
            ddlt_ylxs.DataValueField = "bm";
            ddlt_ylxs.DataSource = SysData.YLXS().Copy();
            ddlt_ylxs.DataBind();
            ddlt_ylxs.Items.Insert(0, new ListItem("全部", "-1"));
            ////初始化审批人
            //DataTable dt_spr = SysData.HasThisZXT_SPR("11");

            ////初审人
            //ddlt_csr.DataSource = dt_spr;
            //ddlt_csr.DataTextField = "mc";
            //ddlt_csr.DataValueField = "bm";
            //ddlt_csr.DataBind();
            //ddlt_csr.Items.Insert(0, new ListItem("全部", "-1"));

            ////终审人
            //ddlt_zsr.DataSource = dt_spr;
            //ddlt_zsr.DataTextField = "mc";
            //ddlt_zsr.DataValueField = "bm";
            //ddlt_zsr.DataBind();
            //ddlt_zsr.Items.Insert(0, new ListItem("全部", "-1"));
            ////数据所在部门
            //ddlt_sjszbm.DataSource = SysData.BM().Copy();
            //ddlt_sjszbm.DataTextField = "mc";
            //ddlt_sjszbm.DataValueField = "bm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("18", _usState.userID, "180202");

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


            //数据所在部门
            DataTable dt_bmdm = SysData.BM("180202", _usState.userID).Copy();
            ddlt_sjszbm.DataSource = dt_bmdm;
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string ylxs = ddlt_ylxs.SelectedValue.Trim().ToString();
            string zxmc = ddlt_zxmc.SelectedValue.Trim().ToString();
            string yam = ddlt_yam.SelectedValue.Trim().ToString();
            string cyry = tbx_syr.Text.ToString().Trim();
            string ylsj = tbx_ylsj.Text.ToString().Trim();
            string ylnr = tbx_ylnr.Text.ToString().Trim();
            string ylzj = tbx_ylzj.Text.ToString().Trim();
            #region lable判断


            if (ddlt_yam.SelectedValue.Trim() == "-1")
            {
                lbl_yam.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yam.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(cyry))
            {
                lbl_syr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_syr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (ddlt_zxmc.SelectedValue.Trim() == "-1")
            {
                lbl_zxmc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zxmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (ddlt_ylxs.SelectedValue.Trim() == "-1")
            {
                lbl_ylxs.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ylxs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(ylsj))
            {
                lbl_ylsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ylsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(ylnr))
            {
                lbl_ylnr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ylnr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

           
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            if (flag == 1)
            {
                return;
            }

          
            #endregion
            struct_ylgl.p_yam = yam;
            struct_ylgl.p_ylsj = Convert.ToDateTime(ylsj); 
            struct_ylgl.p_ylxs = ylxs;
            struct_ylgl.p_cyry = syrbh;
            struct_ylgl.p_ylnr = ylnr;
            struct_ylgl.p_ylzj = ylzj;
            struct_ylgl.p_zxmc = zxmc;
            struct_ylgl.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_ylgl.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ylgl.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_ylgl.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//终审人
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr))
            {
                struct_ylgl.p_sjbs = "0";
                struct_ylgl.p_zt = "2";
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
            {
                struct_ylgl.p_sjbs = "1";
                struct_ylgl.p_zt = "3";
            }
            if (!struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr) && !struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
            {
                struct_ylgl.p_sjbs = "0";
                struct_ylgl.p_zt = "0";
            }
            struct_ylgl.p_bhyy = "";
            struct_ylgl.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_ylgl.p_czfs = "01";
            struct_ylgl.p_czxx = "位置：应急管理->演练管理->添加 描述：对应预案名称：【" + struct_ylgl.p_yam + "】    " + "地区：【" + struct_ylgl.p_zxmc + "】  "
                 + " 时间：【" + struct_ylgl.p_ylsj + "】" + " 演练形式：【" + struct_ylgl.p_ylxs + "】"+ " 参与人员：【" + struct_ylgl.p_cyry + "】"+
                 " 演练内容：【" + struct_ylgl.p_ylnr + "】"+ " 演练总结：【" + struct_ylgl.p_ylzj + "】";
            ylgl.Insert_Yj_Ylgl(struct_ylgl);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            #region 清除数据
            ddlt_yam.SelectedValue = "-1";
            ddlt_ylxs.SelectedValue = "-1";
            ddlt_zxmc.SelectedValue = "-1";
            ddlt_csr.SelectedValue = "-1";
            ddlt_zsr.SelectedValue = "-1";
            ddlt_sjszbm.SelectedValue = "-1";
            tbx_ylnr.Text = "";
            tbx_ylsj.Text = "";
            tbx_ylzj.Text = "";
            tbx_syr.Text = "";
            lbl_yam.Text = "";
            lbl_syr.Text= "";
            lbl_ylnr.Text = "";
            lbl_ylsj.Text = "";
            lbl_ylxs.Text= "";
            lbl_ylzj.Text="";
            lbl_zxmc.Text="";
            lbl_csr.Text = "";
            lbl_sjszbm.Text = "";
            lbl_zsr.Text = "";
            #endregion
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("YLGL_GL.aspx");
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

        protected void tbx_ylnr_TextChanged(object sender, EventArgs e)
        {

        }
        private void bind_drop()
        {
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
            dt = ylgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();


        }
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ylgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt =ylgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_syr.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr.Items.Count > 0)
            {
                tbx_syr.Text += ddlt_syr.SelectedItem.Text + ",";
                syrbh += ddlt_syr.SelectedValue.ToString() + ",";
            }
        }
    }
}