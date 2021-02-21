using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class SBTZ_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        static string fzrbh;
        static string sjrbh;
        static string csrbh;
        static string zsrbh;
        public int cpage;
        public int psize;
        public bool flag = true;
        public int i = 0;
        private TZSB tzsb;
        private Struct_TZSB struct_tzsb;
        private static DataTable dt = new DataTable();
        private DataTable dt_detail;
        public string sjc;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            tzsb = new TZSB(_usState);

            struct_tzsb = new Struct_TZSB();
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                tbx_jgsj.Attributes.Add("readonly", "readonly");
                select_detail();
                ddltBind();
            }
        }
        protected void select_detail()
        {
            dt_detail = tzsb.Select_TZ_Detail(id);
            
            ddlt_jc.SelectedValue = dt_detail.Rows[0]["jc"].ToString();
            ddlt_wz.SelectedValue = dt_detail.Rows[0]["wz"].ToString();
            ddlt_sblx.SelectedValue = dt_detail.Rows[0]["sblx"].ToString();
            tbx_fwxx.Text = dt_detail.Rows[0]["fwxx"].ToString();
            tbx_lc.Text = dt_detail.Rows[0]["lc"].ToString();
            tbx_fjh.Text = dt_detail.Rows[0]["fjh"].ToString();
            tbx_jg.Text = dt_detail.Rows[0]["jg"].ToString();
            tbx_jgsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["jgsj"]);
            tbx_tzwzxx.Text = dt_detail.Rows[0]["tzwzxx"].ToString();
            tbx_jfsrxlqk.Text = dt_detail.Rows[0]["jfsrxlqk"].ToString();
            tbx_jfzsc.Text = dt_detail.Rows[0]["jfzsc"].ToString();
            tbx_jfzscdx.Text = dt_detail.Rows[0]["jfzscdx"].ToString();
            tbx_jfzscsl.Text = dt_detail.Rows[0]["jfzscsl"].ToString();
            //文件没有获取
            ddlt_tzwdsfdb.SelectedValue = dt_detail.Rows[0]["tzwdsfdb"].ToString();
            tbx_bdbyy.Text = dt_detail.Rows[0]["bdbyy"].ToString();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门

        }
        private void ddltBind()
        {
            //台站温度是否达标
            ddlt_tzwdsfdb.DataTextField = "mc";
            ddlt_tzwdsfdb.DataValueField = "bm";
            ddlt_tzwdsfdb.DataSource = SysData.SFJB().Copy();
            ddlt_tzwdsfdb.DataBind();
            ddlt_tzwdsfdb.Items.Insert(0, new ListItem("全部", "-1"));
            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            // 设备位置
            ddlt_wz.DataSource = SysData.SBWZ().Copy();
            ddlt_wz.DataTextField = "mc";
            ddlt_wz.DataValueField = "bm";
            ddlt_wz.DataBind();
            ddlt_wz.Items.Insert(0, new ListItem("全部", "-1"));

            //设备类型
            ddlt_sblx.DataTextField = "mc";
            ddlt_sblx.DataValueField = "bm";
            ddlt_sblx.DataSource = SysData.SBLX().Copy();
            ddlt_sblx.DataBind();
            ddlt_sblx.Items.Insert(0, new ListItem("全部", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140403");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();

            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();

            //数据所在部门
            ddlt_sjszbm.DataSource = SysData.BM("140403", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            // ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //判断是否有该路径  
            string path = Server.MapPath("../uploads/");
            //没有就创建该路径
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            #region 验证
            int flag = 0;
            //机场
            if (ddlt_jc.SelectedValue.Trim() == "-1")
            {
                lbl_jc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //位置
            if (ddlt_wz.SelectedValue.Trim() == "-1")
            {
                lbl_wz.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //设备类型
            if (ddlt_sblx.SelectedValue.Trim() == "-1")
            {
                lbl_sblx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sblx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //房屋信息
            string fwxx = tbx_fwxx.Text.ToString().Trim();
            if (string.IsNullOrEmpty(fwxx))
            {

                lbl_fwxx.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fwxx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //楼层
            string lc = tbx_lc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(lc))
            {

                lbl_lc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_lc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //房间号   
            string fjh = tbx_fjh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(fjh))
            {

                lbl_fjh.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fjh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //结构   
            string jg = tbx_jg.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jg))
            {

                lbl_jg.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //竣工时间
            string jgsj = tbx_jgsj.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jgsj))
            {

                lbl_jgsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jgsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //台站位置信息
            string tzwzxx = tbx_tzwzxx.Text.ToString().Trim();
            if (string.IsNullOrEmpty(tzwzxx))
            {

                lbl_tzwzxx.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tzwzxx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //机房输入线路情况
            string jfsrxlqk = tbx_jfsrxlqk.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jfsrxlqk))
            {

                lbl_jfsrxlqk.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jfsrxlqk.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //机房总输出
            string jfzsc = tbx_jfzsc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jfzsc))
            {

                lbl_jfzsc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jfzsc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //机房总输出大小
            string jfzscdx = tbx_jfzscdx.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jfzscdx))
            {

                lbl_jfzscdx.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jfzscdx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //机房总输出数量
            string jfzscsl = tbx_jfzscsl.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jfzscsl))
            {

                lbl_jfzscsl.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jfzscsl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //上传
            if ((!FileUpload_sc.HasFile))
            {
                lbl_sc.Text = "<span style=\"color:#ff0000\">" + "附件不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //台站温度是否达标
            if (ddlt_tzwdsfdb.SelectedValue.Trim() == "-1")
            {
                lbl_tzwdsfdb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tzwdsfdb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //不达标原因
            string bdbyy = tbx_bdbyy.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bdbyy))
            {

                lbl_bdbyy.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bdbyy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            if (flag == 1) { return; }
            #endregion


            if (FileUpload_sc.HasFile)
            {
                //对上传文件的大小进行检测，限定文件最大不超过10M
                if (FileUpload_sc.PostedFile.ContentLength < 10240000)
                {
                    
                    struct_tzsb.p_jc = ddlt_jc.SelectedValue.ToString().Trim();//机场
                    struct_tzsb.p_wz = ddlt_wz.SelectedValue.ToString().Trim();//位置
                    struct_tzsb.p_sblx = ddlt_sblx.SelectedValue.ToString().Trim();//设备类型

                    struct_tzsb.p_fwxx = tbx_fwxx.Text.ToString().Trim();//房屋信息
                    struct_tzsb.p_lc = tbx_lc.Text.ToString().Trim();
                    struct_tzsb.p_fjh = tbx_fjh.Text.ToString().Trim();
                    struct_tzsb.p_jg = tbx_jg.Text.ToString().Trim();
                    struct_tzsb.p_jgsj = DateTime.Parse(tbx_jgsj.Text.Trim().ToString());//竣工时间
                    struct_tzsb.p_tzwzxx = tbx_tzwzxx.Text.ToString().Trim();
                    struct_tzsb.p_jfsrxlqk = tbx_jfsrxlqk.Text.ToString().Trim();
                    struct_tzsb.p_jfzsc = tbx_jfzsc.Text.ToString().Trim();
                    struct_tzsb.p_jfzscdx = tbx_jfzscdx.Text.ToString().Trim();
                    struct_tzsb.p_jfzscsl = tbx_jfzscsl.Text.ToString().Trim();

                    struct_tzsb.p_sc = FileUpload_sc.FileName;
                    struct_tzsb.p_sc = path;//上传路径
                    FileUpload_sc.PostedFile.SaveAs(path + FileUpload_sc.FileName);

                    struct_tzsb.p_tzwdsfdb = ddlt_tzwdsfdb.SelectedValue.ToString().Trim();//台站温度是否达标
                    struct_tzsb.p_bdbyy = tbx_bdbyy.Text.ToString().Trim();
                    struct_tzsb.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                    struct_tzsb.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                    struct_tzsb.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
                    struct_tzsb.p_lrr = _usState.userLoginName.ToString();//录入人

                    struct_tzsb.p_tzmc = SysData.ZXDMByKey(struct_tzsb.p_jc).mc + " " + struct_tzsb.p_wz + " " + SysData.SBLXByKey(struct_tzsb.p_sblx.ToString()).mc;

                    struct_tzsb.p_czfs = "02";
                    struct_tzsb.p_czxx = "位置：台站基本信息管理->台站设备->添加   描述：员工编号：" + _usState.userLoginName;

                    string sjbs = Request.Params["sjbs"].ToString();
                    if (sjbs.Equals("0"))
                    {
                        //初审人录入的数据，状态默认为待终审
                        if (struct_tzsb.p_lrr.Equals(struct_tzsb.p_csr))
                        {
                            struct_tzsb.p_zt = "2";
                            struct_tzsb.p_sjbs = "0";
                        }
                        //终审人录入的数据，状态默认为审核通过
                        if (struct_tzsb.p_lrr.Equals(struct_tzsb.p_zsr))
                        {
                            struct_tzsb.p_zt = "3";
                            struct_tzsb.p_sjbs = "1";
                        }
                        if (!struct_tzsb.p_lrr.Equals(struct_tzsb.p_csr) && !struct_tzsb.p_lrr.Equals(struct_tzsb.p_zsr))
                        {
                            struct_tzsb.p_zt = "0";
                            struct_tzsb.p_sjbs = "0";
                        }
                        tzsb.Update_TZ(struct_tzsb);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    }
                    else if (sjbs.Equals("2"))
                    {
                        //初审人录入的数据，状态默认为待终审
                        if (struct_tzsb.p_lrr.Equals(struct_tzsb.p_csr))
                        {
                            struct_tzsb.p_zt = "2";
                            struct_tzsb.p_sjbs = "2";
                        }
                        //终审人录入的数据，状态默认为审核通过
                        if (struct_tzsb.p_lrr.Equals(struct_tzsb.p_zsr))
                        {
                            //将原最终数据变为历史数据
                            sjc = Request.Params["sjc"].ToString();
                            struct_tzsb.p_sjc = sjc;
                            tzsb.Update_TZ_SJBS_LSSJ_ZT(struct_tzsb);

                            struct_tzsb.p_zt = "3";
                            struct_tzsb.p_sjbs = "1";
                        }
                        if (!struct_tzsb.p_lrr.Equals(struct_tzsb.p_csr) && !struct_tzsb.p_lrr.Equals(struct_tzsb.p_zsr))
                        {
                            struct_tzsb.p_zt = "0";
                            struct_tzsb.p_sjbs = "2";
                        }
                        tzsb.Update_TZ(struct_tzsb);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                       
                    }
                    else if (sjbs.Equals("1"))
                    {//生成该数据的副本,并返回新的备份id
                        id = Convert.ToInt32(Request.Params["id"].ToString());
                        int id_bf = tzsb.Struct_TZSB_SJBF(Convert.ToInt32(id));
                        struct_tzsb.p_id = id_bf;


                        //初审人录入的数据，状态默认为待终审
                        if (struct_tzsb.p_lrr.Equals(struct_tzsb.p_csr))
                        {
                            struct_tzsb.p_zt = "2";
                            struct_tzsb.p_sjbs = "2";
                        }
                        //终审人录入的数据，状态默认为审核通过
                        if (struct_tzsb.p_lrr.Equals(struct_tzsb.p_zsr))
                        {
                            //将原最终数据变为历史数据
                            sjc = Request.Params["sjc"].ToString();
                            struct_tzsb.p_sjc = sjc;
                            tzsb.Update_TZ_SJBS_LSSJ_ZT(struct_tzsb);

                            struct_tzsb.p_zt = "3";
                            struct_tzsb.p_sjbs = "1";
                        }
                        if (!struct_tzsb.p_lrr.Equals(struct_tzsb.p_csr) && !struct_tzsb.p_lrr.Equals(struct_tzsb.p_zsr))
                        {
                            struct_tzsb.p_zt = "0";
                            struct_tzsb.p_sjbs = "2";
                        }
                        //将新数据更新到副本数据里
                        tzsb.Update_TZ(struct_tzsb);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                        
                    }
                    else
                    {
                        return;
                    }

                   

                }
            }
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
            Response.Redirect("../Shebei/SBTZ.aspx", true);

        }


    }
}