using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace CUST.WKG
{
    public partial class KG_PXJL_ADD : System.Web.UI.Page
    {
        private UserState _us;
        private PXJL pxjl;
        static string pxs;
        static string sjyz;
        static string fzr;
        public bool flag = true;
        public int i = 0;
        static string pxry;
        static string pxry_cs;
        private Struct_PXJL struct_pxjl;
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
            if (!IsPostBack)
            {
                tbx_rqsj.Attributes.Add("readonly", "readonly");
                Bind();
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

            DataTable dt_bmdm = SysData.BM("110602", _us.userID).Copy();


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
           // ddlt_sjyzbmdm.Items.Insert(0, new ListItem("全部", "-1"));

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
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _us.userID, "110602");

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
            ddlt_pxs.DataSource = dt;
            ddlt_pxs.DataTextField = "xm";
            ddlt_pxs.DataValueField = "bh";
            ddlt_pxs.DataBind();
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
        #endregion
        protected void ddlt_sjyzbmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm1 = ddlt_sjyzbmdm.SelectedValue.ToString();
            string gwdm1 = ddlt_sjyzgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm1, gwdm1);
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
            if (tbx_sjyz.Text == "")
            {
                string bmdm = ddlt_sjyzbmdm.SelectedValue.ToString();
                string gwdm = ddlt_sjyzgwdm.SelectedValue.ToString();
                string yg = ddlt_sjyz.SelectedValue.ToString();
                //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
                sjyz = "";
                if (ddlt_sjyz.Items.Count > 0)
                {
                    tbx_sjyz.Text = ddlt_sjyz.SelectedItem.Text;
                    sjyz = ddlt_sjyz.SelectedValue.ToString();
                    pxry= ddlt_sjyz.SelectedValue.ToString();
                }
            }
            else
            {
                pxry_cs= sjyz + ","+ ddlt_sjyz.SelectedValue.ToString();
                string[] Arry_pxry = pxry_cs.Split(new char[1] { ',' });
                if (IsRepeat2(Arry_pxry) == true)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"已添加此培训人员，不能重复添加！\")</script>");
                    return;
                }   
                else
                {
                    tbx_sjyz.Text = tbx_sjyz.Text.ToString() + "," + ddlt_sjyz.SelectedItem.Text;
                    pxry = pxry + "," + ddlt_sjyz.SelectedValue.ToString();
                }
            }
        }

        /// <summary>
        /// for循环
        /// </summary>
        /// <param name="yourValue"></param>
        /// <returns></returns>
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

        #region tbx_fzr.Text数据绑定
        protected void ddlt_fzrbmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm2 = ddlt_fzrbmdm.SelectedValue.ToString();
            string gwdm2 = ddlt_fzrgwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = pxjl.Select_YGbyBMGW(bmdm2, gwdm2);
            ddlt_fzr.DataSource = dt;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();


            
        }
        protected void ddlt_fzrgwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm2 = ddlt_fzrbmdm.SelectedValue.ToString();
            string gwdm2 = ddlt_fzrgwdm.SelectedValue.ToString();
            string yg = ddlt_fzr.SelectedValue.ToString();
        }
        protected void btn_bc_Click_fzr(object sender, EventArgs e)
        {
            tbx_fzr.Text = ddlt_fzr.SelectedItem.Text;
            fzr = ddlt_fzr.SelectedValue.ToString();

        }
        #endregion
        protected void btn_save_Click(object sender, EventArgs e)
        {
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
            if (!Regex.IsMatch(tbx_xs.Text, @"^[0-9]*$")|| string.IsNullOrEmpty(xs))
            {

                Label_xs.Text = "<span style=\"color:#ff0000\">" + "错误，不能为空请输入数字" + "</span>";
                flag = 1;
            }
            else
            {
                Label_xs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            if (ddlt_csr.SelectedItem.Text.Trim() == ""|| ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedItem.Text.Trim() == ""||ddlt_zsr.SelectedValue.Trim() == "-1")
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
            struct_pxjl.p_type = ddlt_type.SelectedValue.ToString().Trim();//类型
            struct_pxjl.p_rqsj = DateTime.Parse(tbx_rqsj.Text.ToString().Trim());//日期时间
          
            struct_pxjl.p_jxnr = tbx_jxnr.Text.ToString().Trim();
            struct_pxjl.p_xs = tbx_xs.Text.ToString().Trim();//学时
            struct_pxjl.p_ks = tbx_ks.Text.ToString().Trim();//课时
            struct_pxjl.p_jb = ddlt_jb.Text.ToString().Trim();//级别
            struct_pxjl.p_pxs = ddlt_pxs.SelectedValue.ToString().Trim();//培训师
            struct_pxjl.p_khfs = tbx_khfs.Text.ToString().Trim();//考核方式
            struct_pxjl.p_khjg = ddlt_khjg.Text.ToString().Trim();//考核结果

        
            //struct_pxjl.p_sjyz = ddlt_sjyz.SelectedValue.ToString().Trim();//受教育者
            struct_pxjl.p_fzr = ddlt_fzr.SelectedValue.ToString().Trim();//负责人

            struct_pxjl.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_pxjl.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_pxjl.p_bmdm = "";//数据所在部门
            struct_pxjl.p_lrr = _us.userLoginName.ToString();//录入人
            //struct_pxjl.p_sjbs = "0";
            //如果是初审人录入数据，则状态默认初审通过，即待终审
            if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr))
            {
                struct_pxjl.p_sjbs = "0";
                struct_pxjl.p_zt = "2";
                //给终审人添加提示
                SysData.Insert_TSR(struct_pxjl.p_zsr, "11", "1106", -1);
            }
            //如果是终审人录入数据，则状态为审核通过
            if (struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
            {
                struct_pxjl.p_sjbs = "1";
                struct_pxjl.p_zt = "3";
            }
            if (!struct_pxjl.p_lrr.Equals(struct_pxjl.p_csr) && !struct_pxjl.p_lrr.Equals(struct_pxjl.p_zsr))
            {
                struct_pxjl.p_sjbs = "0";
                struct_pxjl.p_zt = "0";
            }
            struct_pxjl.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);//时间戳

            struct_pxjl.p_czfs = "01";
            struct_pxjl.p_czxx = "位置：员工->培训记录->添加 " + struct_pxjl.p_type + "事件类型：" + struct_pxjl.p_bmdm + "负责人部门："
                + struct_pxjl.p_rqsj + "日期类型：" + struct_pxjl.p_xs + "教学内容" + struct_pxjl.p_ks + "学时" + struct_pxjl.p_jxnr 
                + "课时：" + struct_pxjl.p_jb + "级别：" + struct_pxjl.p_pxs + "培训师： " + struct_pxjl.p_khfs + "考核方式" + struct_pxjl.p_khjg
                + "考核结果：" + struct_pxjl.p_sjyz + "受教育者：" + struct_pxjl.p_fzr + "负责人：";
           
 //           string[] Arry_tx = pxry.Split(new char[1] { ',' });
 //           int i = Arry_tx.Length;
            if (pxry == null )
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"培训人员不得少于2人！\")</script>");
            }
            else
            {
                string[] Arry_tx = pxry.Split(new char[1] { ',' });
                int i = Arry_tx.Length;
                for (int ry = 0; ry < i; ry++)
                {

                    struct_pxjl.p_sjyz = Arry_tx[ry].ToString();
                    try
                    {
                        //DataTable ygpx = ChangeTable(struct_pxjl);
                        pxjl.Insert_PXJL_Pro(struct_pxjl);
                        struct_pxjl.p_sjc += 1;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                    }
                    catch (Exception em)
                    {
                        throw em;
                    }
                }
            }
        }
        private DataTable ChangeTable(Struct_PXJL xs)
        {
            DataTable dl = new DataTable();
            dl.Columns.Add("xbdm", typeof(string));
            dl.Columns.Add("zzmmdm", typeof(string));
            dl.Columns.Add("mzdm", typeof(string));
            dl.Columns.Add("hjlbdm", typeof(string));
            dl.Columns.Add("zjxydm", typeof(string));
            dl.Columns.Add("dszndm", typeof(string));
            dl.Columns.Add("hj_sf", typeof(string));
            dl.Columns.Add("hj_sd", typeof(string));
            dl.Columns.Add("hj_xq", typeof(string));
            dl.Columns.Add("hj_mph", typeof(string));
            dl.Columns.Add("txdzjyb_sf", typeof(string));
            dl.Columns.Add("txdzjyb_sd", typeof(string));
            dl.Columns.Add("txdzjyb_xq", typeof(string));
            dl.Columns.Add("txdzjyb_mph", typeof(string));

            dl.Columns.Add("lxdh", typeof(string));


            foreach (DataRow dr in dl.Rows)
            { }
            return dl;
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("KG_PXJL.aspx", true);
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
       
    }
}