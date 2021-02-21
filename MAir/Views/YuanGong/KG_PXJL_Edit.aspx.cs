using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CUST.WKG
{
    public partial class KG_PXJL_Edit : System.Web.UI.Page
    {
        private UserState _us;
        private PXJL pxjl;
        private string pxs;
        private string sjyz;
        private string sjc;
        private string fzr;
        private Struct_PXJL struct_pxjl;
        private static int id;
        private DataTable dt_Detail;
        private Boolean flag=true;
        private int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
               pxjl = new PXJL(_us);
            struct_pxjl = new Struct_PXJL();
            id = Convert.ToInt32(Request.Params["id"].ToString());

            if (!IsPostBack) 
            {
                tbx_rqsj.Attributes.Add("readonly", "readonly");
                Bind();
                bind_Main();
            
            }
        }

        private void bind_Main()
        {
            dt_Detail = pxjl.Select_PXJL_Detail(id);
            dt_Detail.Columns.Add("pxsxm");
            dt_Detail.Columns.Add("sjyzxm");
            dt_Detail.Columns.Add("fzrxm");

            foreach (DataRow dr in dt_Detail.Rows)
            {
                string[] Array_pxs = dr["pxs"].ToString().Split(',');
                string[] Array_sjyz = dr["sjyz"].ToString().Split(',');
                string[] Array_fzr = dr["fzr"].ToString().Split(',');
                foreach (string pxs_bh in Array_pxs)
                {
                    dr["pxsxm"] = pxjl.Select_YGXMbyBH(pxs_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string sjyz_bh in Array_sjyz)
                {
                    dr["sjyzxm"] = pxjl.Select_YGXMbyBH(sjyz_bh.ToString()).Rows[0][0].ToString();
                }
                foreach (string fzr_bh in Array_fzr)
                {
                    dr["fzrxm"] = pxjl.Select_YGXMbyBH(fzr_bh.ToString()).Rows[0][0].ToString();
                }

                ddlt_type.SelectedValue = dt_Detail.Rows[0]["type"].ToString();
                ddlt_fzrbmdm.SelectedValue = dt_Detail.Rows[0]["bmdm"].ToString();
                tbx_rqsj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["rqsj"]).ToString("yyyy-MM-dd");
                tbx_xs.Text = dt_Detail.Rows[0]["xs"].ToString();
                tbx_ks.Text = dt_Detail.Rows[0]["ks"].ToString();
                ddlt_jb.SelectedValue = dt_Detail.Rows[0]["jb"].ToString();
                tbx_pxs.Text = dt_Detail.Rows[0]["pxsxm"].ToString();
                tbx_khfs.Text = dt_Detail.Rows[0]["khfs"].ToString();
                ddlt_khjg.SelectedValue = dt_Detail.Rows[0]["khjg"].ToString();
                tbx_sjyz.Text = dt_Detail.Rows[0]["sjyzxm"].ToString();
                tbx_fzr.Text = dt_Detail.Rows[0]["fzrxm"].ToString();
                ddlt_fzr.SelectedValue = dt_Detail.Rows[0]["fzr"].ToString();
                ddlt_sjyz.SelectedValue = dt_Detail.Rows[0]["sjyz"].ToString();
                ddlt_pxs.SelectedValue = dt_Detail.Rows[0]["pxs"].ToString();
                tbx_jxnr.Text = dt_Detail.Rows[0]["jxnr"].ToString();

                ddlt_csr.SelectedValue = dt_Detail.Rows[0]["csr"].ToString();//初审人
                ddlt_zsr.SelectedValue = dt_Detail.Rows[0]["zsr"].ToString();//终审人
                //ddlt_sjszbm.SelectedValue = dt_Detail.Rows[0]["bmdm"].ToString();//数据所在部门
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
        private void Bind()
        {
            DataTable dt_bmdm = SysData.BM("110603", _us.userID).Copy();
            //事件类型
            ddlt_type.DataSource = SysData.TYPE().Copy();
            ddlt_type.DataTextField = "mc";
            ddlt_type.DataValueField = "bm";
            ddlt_type.DataBind();
            ddlt_type.Items.Insert(0, new ListItem("请选择", "-1"));
            //级别
            ddlt_jb.DataSource = SysData.JB().Copy();
            ddlt_jb.DataTextField = "mc";
            ddlt_jb.DataValueField = "bm";
            ddlt_jb.DataBind();
            ddlt_jb.Items.Insert(0, new ListItem("请选择", "-1"));
            //考核结果
            ddlt_khjg.DataSource = SysData.KHJG().Copy();
            ddlt_khjg.DataTextField = "mc";
            ddlt_khjg.DataValueField = "bm";
            ddlt_khjg.DataBind();
            ddlt_khjg.Items.Insert(0, new ListItem("请选择", "-1"));
            #region 培训师
            //部门代码
            ddlt_pxsbmdm.DataSource = dt_bmdm;
            ddlt_pxsbmdm.DataTextField = "bmmc";
            ddlt_pxsbmdm.DataValueField = "bmdm";
            ddlt_pxsbmdm.DataBind();
         //   ddlt_pxsbmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_pxsgwdm.DataSource = SysData.GW().Copy();
            ddlt_pxsgwdm.DataTextField = "mc";
            ddlt_pxsgwdm.DataValueField = "bm";
            ddlt_pxsgwdm.DataBind();
            ddlt_pxsgwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_pxsbmdm.SelectedValue.ToString();
            string gwdm = ddlt_pxsgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_pxs.DataSource = dt;
            ddlt_pxs.DataTextField = "xm";
            ddlt_pxs.DataValueField = "bh";
            ddlt_pxs.DataBind();
            #endregion
            #region 受教育者
            //部门代码
            ddlt_sjyzbmdm.DataSource = dt_bmdm;
            ddlt_sjyzbmdm.DataTextField = "bmmc";
            ddlt_sjyzbmdm.DataValueField = "bmdm";
            ddlt_sjyzbmdm.DataBind();
          //  ddlt_sjyzbmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_sjyzgwdm.DataSource = SysData.GW().Copy();
            ddlt_sjyzgwdm.DataTextField = "mc";
            ddlt_sjyzgwdm.DataValueField = "bm";
            ddlt_sjyzgwdm.DataBind();
            ddlt_sjyzgwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm1 = ddlt_sjyzbmdm.SelectedValue.ToString();
            string gwdm1 = ddlt_sjyzgwdm.SelectedValue.ToString();
            DataTable dt1 = new DataTable();
            dt1 = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sjyz.DataSource = dt1;
            ddlt_sjyz.DataTextField = "xm";
            ddlt_sjyz.DataValueField = "bh";
            ddlt_sjyz.DataBind();
            #endregion
            #region 负责人
            //部门代码
            ddlt_fzrbmdm.DataSource = dt_bmdm;
            ddlt_fzrbmdm.DataTextField = "bmmc";
            ddlt_fzrbmdm.DataValueField = "bmdm";
            ddlt_fzrbmdm.DataBind();
          //  ddlt_fzrbmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_fzrgwdm.DataSource = SysData.GW().Copy();
            ddlt_fzrgwdm.DataTextField = "mc";
            ddlt_fzrgwdm.DataValueField = "bm";
            ddlt_fzrgwdm.DataBind();
            ddlt_fzrgwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm2 = ddlt_fzrbmdm.SelectedValue.ToString();
            string gwdm2 = ddlt_fzrgwdm.SelectedValue.ToString();
            DataTable dt2 = new DataTable();
            dt2 = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt2;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
            #endregion

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _us.userID, "110603");
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
        }

        #region tbx_pxs.Text数据绑定
        protected void ddlt_pxsbmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_pxsbmdm.SelectedValue.ToString();
            string gwdm = ddlt_pxsgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_pxs.DataSource = dt;
            ddlt_pxs.DataTextField = "xm";
            ddlt_pxs.DataValueField = "bh";
            ddlt_pxs.DataBind();
        }
        protected void ddlt_pxsgwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_pxsbmdm.SelectedValue.ToString();
            string gwdm = ddlt_pxsgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sjyz.DataSource = dt;
            ddlt_sjyz.DataTextField = "xm";
            ddlt_sjyz.DataValueField = "bh";
            ddlt_sjyz.DataBind();
        }
        protected void btn_bc_Click_pxs(object sender, EventArgs e)
        {
            string bmdm = ddlt_pxsbmdm.SelectedValue.ToString();
            string gwdm = ddlt_pxsgwdm.SelectedValue.ToString();
            string yg = ddlt_pxs.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_pxs.Items.Count > 0)
            {
                tbx_pxs.Text = ddlt_pxs.SelectedItem.Text;
                pxs = ddlt_pxs.SelectedValue.ToString();
            }
        }
        #endregion
        #region tbx_sjyz.Text数据绑定
        protected void ddlt_sjyzbmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_sjyzbmdm.SelectedValue.ToString();
            string gwdm = ddlt_sjyzgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sjyz.DataSource = dt;
            ddlt_sjyz.DataTextField = "xm";
            ddlt_sjyz.DataValueField = "bh";
            ddlt_sjyz.DataBind();
        }
        protected void ddlt_sjyzgwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_sjyzbmdm.SelectedValue.ToString();
            string gwdm = ddlt_sjyzgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_sjyz.DataSource = dt;
            ddlt_sjyz.DataTextField = "xm";
            ddlt_sjyz.DataValueField = "bh";
            ddlt_sjyz.DataBind();
        }
        protected void btn_bc_Click_sjyz(object sender, EventArgs e)
        {
            string bmdm1 = ddlt_sjyzbmdm.SelectedValue.ToString();
            string gwdm1 = ddlt_sjyzgwdm.SelectedValue.ToString();
            string yg = ddlt_pxs.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_sjyz.Items.Count > 0)
            {
                tbx_sjyz.Text = ddlt_sjyz.SelectedItem.Text;
                sjyz = ddlt_sjyz.SelectedValue.ToString();
            }
        }
        #endregion
        #region tbx_fzr.Text数据绑定
        protected void ddlt_fzrbmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_sjyzbmdm.SelectedValue.ToString();
            string gwdm = ddlt_sjyzgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
        }
        protected void ddlt_fzrgwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_fzrbmdm.SelectedValue.ToString();
            string gwdm = ddlt_fzrgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
        }
        protected void btn_bc_Click_fzr(object sender, EventArgs e)
        {
            string bmdm = ddlt_fzrbmdm.SelectedValue.ToString();
            string gwdm = ddlt_fzrgwdm.SelectedValue.ToString();
            string yg = ddlt_fzr.SelectedValue.ToString();
            if (ddlt_fzr.Items.Count > 0)
            {
                tbx_fzr.Text = ddlt_fzr.SelectedItem.Text;
                fzr = ddlt_pxs.SelectedValue.ToString();
            }
        }
        #endregion
        protected void btn_save_Click(object sender, EventArgs e)
        {

            #region 赋值
            //int check_rz = 0;
            //string rqsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            //string type = ddlt_type.SelectedValue.ToString().Trim();
            //string jb = ddlt_jb.SelectedValue.ToString().Trim();
            //string khjg = ddlt_khjg.SelectedValue.ToString().Trim();
            #endregion

            #region MyRegion
            int flag = 0;
            //类型
            if (ddlt_type.SelectedValue.Trim() == "-1")
            {

                lbl_type.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_type.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //日期
            string rqsj = tbx_rqsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(rqsj))
            {

                lbl_rqsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_rqsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //教学内容
            string jxnr = tbx_jxnr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jxnr))
            {

                lbl_jxnr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jxnr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //学时
             string xs = tbx_xs.Text.ToString().Trim();
            if (!Regex.IsMatch(tbx_xs.Text, @"^[0-9]*$") || string.IsNullOrEmpty(xs))
            {

                lbl_xs.Text = "<span style=\"color:#ff0000\">" + "错误，不能为空请输入数字" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //课时
             string ks = tbx_ks.Text.ToString().Trim();
            if (!Regex.IsMatch(tbx_ks.Text, @"^[0-9]*$") || string.IsNullOrEmpty(ks))
            {

                lbl_ks.Text = "<span style=\"color:#ff0000\">" + "错误,不能为空请输入数字" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ks.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            //培训师
            string pxs = tbx_pxs.Text.ToString().Trim();
            if (string.IsNullOrEmpty(pxs))
            {

                Label1.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                Label1.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //考核方式
            string khfs = tbx_khfs.Text.ToString().Trim();
            if (string.IsNullOrEmpty(khfs))
            {

                lbl_khfs.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_khfs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //考核结果
            if (ddlt_khjg.SelectedValue.Trim() == "-1")
            {

                lbl_khjg.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_khjg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //受教育者
            string sjyz = tbx_sjyz.Text.ToString().Trim();
            if (string.IsNullOrEmpty(sjyz))
            {

                lbl_sjyz.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjyz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //负责人
            string fzr = tbx_fzr.Text.ToString().Trim();
            if (string.IsNullOrEmpty(fzr))
            {

                Label2.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                Label2.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            struct_pxjl.p_id = Convert.ToInt32(id);
            struct_pxjl.p_type = ddlt_type.SelectedValue.ToString().Trim();//类型
            struct_pxjl.p_rqsj = DateTime.Parse(tbx_rqsj.Text.ToString().Trim());//日期时间
            struct_pxjl.p_xs = tbx_xs.Text.ToString().Trim();//学时
            struct_pxjl.p_ks = tbx_ks.Text.ToString().Trim();//课时
            struct_pxjl.p_jb = ddlt_jb.SelectedValue.ToString().Trim();//级别
            struct_pxjl.p_pxs= ddlt_pxs.SelectedValue.ToString().Trim();
            struct_pxjl.p_sjyz = ddlt_sjyz.SelectedValue.ToString().Trim();
            struct_pxjl.p_fzr = ddlt_fzr.SelectedValue.ToString().Trim();
            struct_pxjl.p_khfs = tbx_khfs.Text.ToString().Trim();//考核方式
            struct_pxjl.p_khjg = ddlt_khjg.SelectedValue.ToString().Trim();//考核结果
            struct_pxjl.p_jxnr = tbx_jxnr.Text.ToString().Trim();
            struct_pxjl.p_czfs = "03";

            struct_pxjl.p_lrr = _us.userLoginName;//录入人
            struct_pxjl.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_pxjl.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_pxjl.p_bmdm = "";//数据所在部门



            #region  操作信息判断
            struct_pxjl.p_czxx = "位置：员工管理->培训记录->编辑    序号：[" + _us.userLoginName + "]  描述：";

            string sjbs = Request.Params["sjbs"].ToString();

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr))
                {
                    struct_pxjl.p_zt = "2";
                    struct_pxjl.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_pxjl.p_zsr, "11", "1106", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
                {
                    struct_pxjl.p_zt = "3";
                    struct_pxjl.p_sjbs = "1";
                    SysData.Delete_TSR(struct_pxjl.p_zsr, "11", "1106", id);
                }
                if (!struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr) && !struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
                {
                    struct_pxjl.p_zt = "0";
                    struct_pxjl.p_sjbs = "0";
                }
                pxjl.Edit_PXJL_Pro(struct_pxjl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("KG_PXJL.aspx?ygbh=" + _us.userLoginName);
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr))
                {
                    struct_pxjl.p_zt = "2";
                    struct_pxjl.p_sjbs = "2";
                    SysData.Insert_TSR(struct_pxjl.p_zsr, "11", "1106", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_pxjl.p_sjc = sjc;
                    pxjl.Update_PXJL_SJBS_LSSJ_ZT(struct_pxjl);

                    struct_pxjl.p_zt = "3";
                    struct_pxjl.p_sjbs = "1";
                    SysData.Delete_TSR(struct_pxjl.p_zsr, "11", "1106", id);
                }
                if (!struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr) && !struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
                {
                    struct_pxjl.p_zt = "0";
                    struct_pxjl.p_sjbs = "2";
                }
                pxjl.Edit_PXJL_Pro(struct_pxjl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("KG_PXJL.aspx?ygbh=" + _us.userLoginName);
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = pxjl.PXJL_SJBF(Convert.ToInt32(id));
                struct_pxjl.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr))
                {
                    struct_pxjl.p_zt = "2";
                    struct_pxjl.p_sjbs = "2";
                    SysData.Insert_TSR(struct_pxjl.p_zsr, "11", "1106", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_pxjl.p_sjc = sjc;
                    pxjl.Update_PXJL_SJBS_LSSJ_ZT(struct_pxjl);

                    struct_pxjl.p_zt = "3";
                    struct_pxjl.p_sjbs = "1";
                    SysData.Delete_TSR(struct_pxjl.p_zsr, "11", "1106", id);
                }
                if (!struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr) && !struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
                {
                    struct_pxjl.p_zt = "0";
                    struct_pxjl.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                pxjl.Edit_PXJL_Pro(struct_pxjl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("KG_PXJL.aspx?ygbh=" + _us.userLoginName);
           
        }
            else
            {
                return;
            }
            //ddlt_type.Enabled = false;
            //tbx_rqsj.Enabled = false;
            //tbx_xs.Enabled = false;
            //tbx_ks.Enabled = false;
            //ddlt_jb.Enabled = false;
            //tbx_pxs.Enabled = false;
            //tbx_khfs.Enabled = false;
            //ddlt_khjg.Enabled = false;
            //tbx_sjyz.Enabled = false;
            //tbx_fzr.Enabled = false;
            #endregion
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("KG_PXJL.aspx", true);
        }
    }
}