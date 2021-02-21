using CUST.MKG;
using CUST.Sys;
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
    public partial class ZCGL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        static string sprbh;
        public bool flag = true;
        public int i = 0;
        public int cpage;
        public int psize;
        private YGZC ygzc;
        private DataTable dt_detail;
        private static DataTable dt = new DataTable();
        private Struct_YGZC struct_YGZC;
        public string sjc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            ygzc = new YGZC(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                select_detail();
                yg_bind();
                ddltBind();
                tbx_hdsj.Attributes.Add("readonly", "readonly");
                tbx_dqsj.Attributes.Add("readonly", "readonly");
                tbx_prsj.Attributes.Add("readonly", "readonly");
            }

        }

        private void ddltBind()
        {
            //类别
            ddlt_lb.DataSource = SysData.QZZY().Copy();
            ddlt_lb.DataTextField = "mc";
            ddlt_lb.DataValueField = "bm";
            ddlt_lb.DataBind();
            ddlt_lb.Items.Insert(0, new ListItem("全部", "-1"));
            //级别
            ddlt_jb.DataSource = SysData.ZCJB().Copy();
            ddlt_jb.DataTextField = "mc";
            ddlt_jb.DataValueField = "bm";
            ddlt_jb.DataBind();
            ddlt_jb.Items.Insert(0, new ListItem("全部", "-1"));
            //资格
            ddlt_zg.DataSource = SysData.ZG().Copy();
            ddlt_zg.DataTextField = "mc";
            ddlt_zg.DataValueField = "bm";
            ddlt_zg.DataBind();
            ddlt_zg.Items.Insert(0, new ListItem("全部", "-1"));
            //是否聘任
            ddlt_pr.DataSource = SysData.PR().Copy();
            ddlt_pr.DataTextField = "mc";
            ddlt_pr.DataValueField = "bm";
            ddlt_pr.DataBind();
            ddlt_pr.Items.Insert(0, new ListItem("全部", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110703");
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


            ////数据所在部门
            //ddlt_sjszbm.DataSource = SysData.BM().Copy();
            //ddlt_sjszbm.DataTextField = "mc";
            //ddlt_sjszbm.DataValueField = "bm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));

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
             DataTable dt_bmdm = SysData.BM("110703", _usState.userID).Copy();

          //  DataTable dt_bmdm = SysData.BM().Copy();
            //部门代码
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "bmmc";
            ddlt_bmdm.DataValueField = "bmdm";
            ddlt_bmdm.DataBind();
        //    ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygzc.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }

        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygzc.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ygzc.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_spr.DataSource = dt;
            ddlt_spr.DataTextField = "xm";
            ddlt_spr.DataValueField = "bh";
            ddlt_spr.DataBind();
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_spr.SelectedValue.ToString();
            //ddlt_fzr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_spr.Items.Count > 0)
            {
                tbx_spr.Text = ddlt_spr.SelectedItem.Text;
                sprbh = ddlt_spr.SelectedValue.ToString();
            }
        }

        private void select_detail()
        {
           // id = Convert.ToInt32(Request.Params["ygbh"].ToString());
            dt_detail = ygzc.Select_YGZC_Detail(id);
            tbx_spr.Text = dt_detail.Rows[0]["sprxm"].ToString();//受聘人
          //  ddlt_bmdm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();
            ddlt_spr.SelectedValue = dt_detail.Rows[0]["spr"].ToString();//受聘人编号
            ddlt_lb.SelectedValue = dt_detail.Rows[0]["lb"].ToString();//类别
            ddlt_jb.SelectedValue = dt_detail.Rows[0]["jb"].ToString();//级别
            ddlt_zg.SelectedValue = dt_detail.Rows[0]["zg"].ToString();//资格
            ddlt_pr.SelectedValue = dt_detail.Rows[0]["pr"].ToString();//是否聘任
            tbx_zgsqdw.Text = dt_detail.Rows[0]["zgsqdw"].ToString();//资格审权单位
            tbx_hdsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["hdsj"]);//获得时间
            tbx_dqsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["dqsj"]);//到期时间
            tbx_prsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["prsj"]);//聘任时间
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            //ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 验证
            int flag = 0;
            //受聘人
            string spr = tbx_spr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(spr))
            {

                lbl_spr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_spr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //类别
            if (ddlt_lb.SelectedValue.Trim() == "-1")
            {
                lbl_lb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_lb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //级别
            if (ddlt_jb.SelectedValue.Trim() == "-1")
            {
                lbl_jb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //资格
            if (ddlt_zg.SelectedValue.Trim() == "-1")
            {
                lbl_zg.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //是否聘任
            if (ddlt_pr.SelectedValue.Trim() == "-1")
            {
                lbl_pr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_pr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //资格审权单位
            string zgsqdw = tbx_zgsqdw.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zgsqdw))
            {

                lbl_zgsqdw.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zgsqdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //获得时间
            string hdsj = tbx_hdsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(hdsj))
            {

                lbl_hdsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_hdsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            // 到期时间
            string dqsj = tbx_dqsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(dqsj))
            {

                lbl_dqsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else if (DateTime.Compare(Convert.ToDateTime(dqsj), Convert.ToDateTime(hdsj)) <= 0)
            {
                lbl_dqsj.Text = "<span style=\"color:#ff0000\">" + "到期时间不能小于获得时间" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dqsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //聘任时间
            string prsj = tbx_prsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(prsj))
            {

                lbl_prsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_prsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1)
            {
                return;
            }
            ////数据所在部门
            //if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            //{

            //    lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //初审人
            if (ddlt_csr.SelectedItem.Text.Trim() == "" || ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedItem.Text.Trim() == "" || ddlt_zsr.SelectedValue.Trim() == "-1")
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


            //聘任时间
            if (tbx_prsj.Text.Trim().ToString().Equals(""))
            {
                struct_YGZC.p_prsjks = new DateTime();
                struct_YGZC.p_prsjjs = new DateTime();
            }
            else
            {
                struct_YGZC.p_prsjks = DateTime.Parse(tbx_prsj.Text.Trim().ToString());
                struct_YGZC.p_prsjjs = DateTime.Parse(tbx_prsj.Text.Trim().ToString());
            }
            struct_YGZC.p_id = Convert.ToInt32(Request.Params["id"].ToString());//id
            struct_YGZC.p_spr = ddlt_spr.SelectedValue.ToString().Trim();//受聘人
           // struct_YGZC.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            struct_YGZC.p_lb = ddlt_lb.SelectedValue.ToString().Trim();//类别
            struct_YGZC.p_jb = ddlt_jb.SelectedValue.ToString().Trim();//级别
            struct_YGZC.p_zg = ddlt_zg.SelectedValue.ToString().Trim();//资格
            struct_YGZC.p_pr = ddlt_pr.SelectedValue.ToString().Trim();//是否聘任
            struct_YGZC.p_zgsqdw = tbx_zgsqdw.Text.ToString().Trim();//资格审权单位
            struct_YGZC.p_hdsj = DateTime.Parse(tbx_hdsj.Text.Trim().ToString());//获得时间
            struct_YGZC.p_dqsj = DateTime.Parse(tbx_dqsj.Text.Trim().ToString());//到期时间
            struct_YGZC.p_lrr = _usState.userLoginName;//录入人
            struct_YGZC.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_YGZC.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_YGZC.p_bmdm = "";//部门代码


            struct_YGZC.p_czfs = "03";
            struct_YGZC.p_czxx = "位置：员工管理->员工职称->编辑   描述：员工编号：" + _usState.userLoginName;


            string sjbs = Request.Params["sjbs"].ToString();

            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr))
                {
                    struct_YGZC.p_zt = "2";
                    struct_YGZC.p_sjbs = "0";
                    SysData.Insert_TSR(struct_YGZC.p_zsr, "11", "1107", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
                {
                    struct_YGZC.p_zt = "3";
                    struct_YGZC.p_sjbs = "1";
                    SysData.Delete_TSR(struct_YGZC.p_zsr, "11", "1107", id);
                }
                if (!struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr) && !struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
                {
                    struct_YGZC.p_zt = "0";
                    struct_YGZC.p_sjbs = "0";
                }
                ygzc.Update_YGZC(struct_YGZC);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZCGL.aspx?ygbh=" + _usState.userLoginName);
            }
            else if (sjbs.Equals("2")) {
                //初审人录入的数据，状态默认为待终审
                if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr))
                {
                    struct_YGZC.p_zt = "2";
                    struct_YGZC.p_sjbs = "2";
                    SysData.Insert_TSR(struct_YGZC.p_zsr, "11", "1107", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_YGZC.p_sjc = sjc;
                    ygzc.Update_YGZC_SJBS_LSSJ_ZT(struct_YGZC);

                    struct_YGZC.p_zt = "3";
                    struct_YGZC.p_sjbs = "1";
                    SysData.Delete_TSR(struct_YGZC.p_zsr, "11", "1107", id);
                }
                if (!struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr) && !struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
                {
                    struct_YGZC.p_zt = "0";
                    struct_YGZC.p_sjbs = "2";
                }
                ygzc.Update_YGZC(struct_YGZC);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZCGL.aspx?ygbh=" + _usState.userLoginName);
            }
            else if (sjbs.Equals("1"))
            {//生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = ygzc.YGZC_SJBF(Convert.ToInt32(id));
                struct_YGZC.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr))
                {
                    struct_YGZC.p_zt = "2";
                    struct_YGZC.p_sjbs = "2";
                    SysData.Insert_TSR(struct_YGZC.p_zsr, "11", "1107", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_YGZC.p_sjc = sjc;
                    ygzc.Update_YGZC_SJBS_LSSJ_ZT(struct_YGZC);

                    struct_YGZC.p_zt = "3";
                    struct_YGZC.p_sjbs = "1";
                    SysData.Delete_TSR(struct_YGZC.p_zsr, "11", "1107", id);
                }
                if (!struct_YGZC.p_lrr.Equals(struct_YGZC.p_csr) && !struct_YGZC.p_lrr.Equals(struct_YGZC.p_zsr))
                {
                    struct_YGZC.p_zt = "0";
                    struct_YGZC.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                ygzc.Update_YGZC(struct_YGZC);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZCGL.aspx?ygbh=" + _usState.userLoginName);
            }
            else
            {
                return;
            }
        }
       
        


        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Server.Transfer("ZCGL.aspx?ygbh=" + _usState.userLoginName);
        }

    }
}