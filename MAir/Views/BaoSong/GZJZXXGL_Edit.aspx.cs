using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Sys;

namespace CUST.WKG
{
    public partial class GZJZXXGL_Edit : System.Web.UI.Page
    {
        private UserState _usState;

        private GZJZ gzjz;
        private Struct_GZJZ struct_gzjz;
        private string id;
        private string bzsjc;
        private string zt;
        private string sjbs;
        private int count;
        public bool flag = true;
        public int i = 0;
        private string sjc;
        public string gzfzr;
        private DataTable dt_detail;
        protected int totalcontrols
        {
            get
            {
                return ViewState["totcontrols"] == null ? 0 : (int)(ViewState["totcontrols"]);
            }
            set
            {
                ViewState["totcontrols"] = value;
            }
        }
        private DataTable dt_gzjz = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            gzjz = new GZJZ(_usState);
            struct_gzjz = new Struct_GZJZ();
            id = Request.Params["id"].ToString();
            bzsjc = Request.Params["sjc"].ToString();
            zt = Request.Params["zt"].ToString();
            sjbs = Request.Params["sjbs"].ToString();
            dt_gzjz = gzjz.Select_gzjz_bz(bzsjc, zt, sjbs);
            if (!IsPostBack)
            {
                gzfzrHiddenField.Value = "0";
                totalcontrols = dt_gzjz.Rows.Count; 
                ddltBind();
                select_detail(id);
                tbx_bssj.Attributes.Add("readonly", "readonly");
                tbx_wcsx.Attributes.Add("readonly", "readonly");
                tbx_gzfzr.Attributes.Add("readonly", "readonly");
            }
            count = dt_gzjz.Rows.Count;
            for (int i = 0; i < totalcontrols; i++)
            {
                dymanicallygeneratetextboxcontrol(i + 1);
            }
            show(totalcontrols);

        }
        protected void show(int totalcontrols)
        {
            if (totalcontrols <= 1)
                btn_scgzbz.Visible = false;
            else
                btn_scgzbz.Visible = true;
        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;

            }
        }
        private void ddltBind()
        {

            //绑定支线名称 
            ddlt_bszx.DataTextField = "mc";
            ddlt_bszx.DataValueField = "bm";
            ddlt_bszx.DataSource = SysData.ZXDM().Copy();
            ddlt_bszx.DataBind();
            ddlt_bszx.Items.Insert(0, new ListItem("请选择", "-1"));

            // 部门单位权限判断
            DataTable dt_bmdm = SysData.BM("130103", _usState.userID).Copy();
            #region 员工选择框1
            ddlt_bmdm1.DataSource = dt_bmdm;
            ddlt_bmdm1.DataTextField = "bmmc";
            ddlt_bmdm1.DataValueField = "bmdm";
            ddlt_bmdm1.DataBind();
            ddlt_bmdm1.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm1.DataSource = SysData.GW().Copy();
            ddlt_gwdm1.DataTextField = "mc";
            ddlt_gwdm1.DataValueField = "bm";
            ddlt_gwdm1.DataBind();
            ddlt_gwdm1.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = gzjz.SelectBS_FZR_byBMGW(bmdm, gwdm);
            ddlt_syr1.DataSource = dt;
            ddlt_syr1.DataTextField = "xm";
            ddlt_syr1.DataValueField = "bh";
            ddlt_syr1.DataBind();
            #endregion
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("13", _usState.userID, "130102");

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
            ddlt_sjszbm.DataSource = SysData.BM().Copy();
            ddlt_sjszbm.DataTextField = "mc";
            ddlt_sjszbm.DataValueField = "bm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        protected void select_detail(string id)
        {

            DataTable dt_detail = gzjz.SelectBS_GZJZ_Detail(id);
            dt_detail.Columns.Add("gzfzrxm");
            dt_detail.Columns.Add("bsygxm");

            foreach (DataRow dr in dt_detail.Rows)
            {
               
                string[] Array_gzfzr=dr["gzfzr"].ToString().Split();
                string[] Array_bsyg = dr["bsyg"].ToString().Split();
                foreach (string gzfzrxm in Array_gzfzr)
                {
                    dr["gzfzrxm"] = gzjz.SelectBS_FZR_byBH(dt_detail.Rows[0]["gzfzr"].ToString()).Rows[0][0].ToString();
                    dr["bsygxm"] = gzjz.SelectBS_FZR_byBH(dt_detail.Rows[0]["bsyg"].ToString()).Rows[0][0].ToString();
                }

                struct_gzjz = new CUST.MKG.Struct_GZJZ();
                lbl_bsyg.Text = dt_detail.Rows[0]["bsygxm"].ToString();
                lbl_bsbm.Text = SysData.BMByKey(dt_detail.Rows[0]["bsbm"].ToString()).mc;
                tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
                ddlt_bszx.Text = dt_detail.Rows[0]["bszx"].ToString();
                tbx_gzzt.Text = dt_detail.Rows[0]["gzzt"].ToString();
                tbx_gznr.Text = dt_detail.Rows[0]["gznr"].ToString();
                tbx_wcjd.Text = dt_detail.Rows[0]["wcjd"].ToString();
                tbx_gzfzr.Text = dt_detail.Rows[0]["gzfzrxm"].ToString();
                tbx_gzlc.Text = dt_detail.Rows[0]["gzlc"].ToString();
                tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
                tbx_wcsx.Text = Convert.ToDateTime(dt_detail.Rows[0]["wcsx"]).ToString("yyyy-MM-dd");
                ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();
                ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();
                ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();
            }
        }
        //添加
        private void dymanicallygeneratetextboxcontrol(int totalcontrols)
        {
                Label lbl_gzbz = new Label();
                lbl_gzbz.Text = "工作步骤：";
                TextBox tbx_gznr = new TextBox();
                tbx_gznr.ID = "gzbz" + totalcontrols;
                tbx_gznr.Style["width"] = "450px";
                tbx_gznr.Style["height"] = "100px";
                tbx_gznr.Style["textmode"] = "MultiLine";
                tbx_gznr.Style["MaxLength"] = "3000";
                Label lbl_wcsx = new Label();
                lbl_wcsx.Text = "步骤完成时限：";
                lbl_wcsx.Style["width"] = "20%";
                lbl_wcsx.Style["height"] = "30px";
                TextBox tax_wcsx = new TextBox();
                tax_wcsx.Style["width"] = "450px";
                tax_wcsx.Style["height"] = "30px";
                tax_wcsx.Attributes.Add("onclick", "lhgcalendar()");
                tax_wcsx.Attributes.Add("readonly", "readonly");

            if (count >=totalcontrols)
            {
                tbx_gznr.Text = dt_gzjz.Rows[totalcontrols-1]["gzbz"].ToString();
                tax_wcsx.Text = Convert.ToDateTime(dt_gzjz.Rows[totalcontrols-1]["wcsx"]).ToString("yyyy-MM-dd");
            }

                tax_wcsx.ID = "wcsx" + totalcontrols;
                this.plah_gzbz.Controls.Add(lbl_gzbz);
                this.plah_gzbz.Controls.Add(tbx_gznr);
                Literal lit = new Literal();
                lit.Text = "<br/>";
                this.plah_gzbz.Controls.Add(lit);
                this.plah_gzbz.Controls.Add(lbl_wcsx);
                this.plah_gzbz.Controls.Add(tax_wcsx);
                Literal lite = new Literal();
                lite.Text = "<br/>";
                this.plah_gzbz.Controls.Add(lite);

            }
        
        //删除
        private void DymanicallyDelete(int totalControls)
        {
            Label lbl_gzbz = new Label();
            lbl_gzbz.Text = "工作步骤：";
            TextBox tbx_gzbz = new TextBox();
            tbx_gzbz.ID = "gzbz" + totalcontrols;
            tbx_gzbz.Style["width"] = "450px";
            tbx_gzbz.Style["height"] = "100px";
            tbx_gzbz.Style["textmode"] = "MultiLine";
            tbx_gzbz.Style["MaxLength"] = "3000";
            Label lbl_bzwcsx = new Label();
            lbl_bzwcsx.Text = "步骤完成时限：";
            lbl_bzwcsx.Style["width"] = "20%";
            lbl_bzwcsx.Style["height"] = "30px";
            TextBox tax_bzwcsx = new TextBox();
            tax_bzwcsx.Style["width"] = "450px";
            tax_bzwcsx.Style["height"] = "30px";
            tax_bzwcsx.Attributes.Add("onclick", "lhgcalendar()");
            tax_bzwcsx.Attributes.Add("readonly", "readonly");
            tax_bzwcsx.ID = "wcsx" + totalcontrols;
            this.plah_gzbz.Controls.Remove(lbl_gzbz);
            this.plah_gzbz.Controls.Remove(tbx_gznr);
            Literal lit = new Literal();
            lit.Text = "<br/>";
            this.plah_gzbz.Controls.Remove(lit);
            this.plah_gzbz.Controls.Remove(lbl_bzwcsx);
            this.plah_gzbz.Controls.Remove(tax_bzwcsx);
            Literal lite = new Literal();
            lite.Text = "<br/>";
            this.plah_gzbz.Controls.Remove(lite);
        }

        protected void save_GZJZ_BZ( int totalcontrols)
        {
            //添加新步骤
            DateTime[] wcsx = new DateTime[totalcontrols];
            string[] gzbz = new string[totalcontrols];

            for (int i = 0; i < totalcontrols; i++)
            {
                //control下标为0开始  单数为数据 控件位置是plah_gzbz Controls【】中数字为对应控件ID 控件ID在dymanicallygeneratetextboxcontrol添加时生成
                TextBox tbx_gzbz = (TextBox)this.plah_gzbz.Controls[i * 6 + 1];
                gzbz[i] = tbx_gzbz.Text.Trim();
                TextBox tbx_bzwcsx = (TextBox)this.plah_gzbz.Controls[i * 6 + 4];
                wcsx[i] = Convert.ToDateTime(tbx_bzwcsx.Text.Trim());
            }
            for (int j = count; j >= 1; j--)
            {

                string id = dt_gzjz.Rows[j - 1]["id"].ToString();
                gzjz.Delete_gzjzbz_id(id);

            }
            for (int j = 0; j < totalcontrols; j++)
            {
                struct_gzjz.p_gzbz = gzbz[j];
                struct_gzjz.p_bzwcsx = wcsx[j];
                struct_gzjz.p_czfs = "02";
                struct_gzjz.p_czxx = "位置：航务综合报送系统->工作进展信息->添加  描述：报送编号：" + struct_gzjz.p_bsbh + "工作步骤：" + struct_gzjz.p_gzbz + "完成时限：" + struct_gzjz.p_bzwcsx;
                gzjz.Insert_gzjz_bz(struct_gzjz);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            #region 员工框是否被点击判断
            id = Request.Params["id"].ToString();
            dt_detail = gzjz.SelectBS_GZJZ_Detail(id);
            if (Convert.ToInt32(gzfzrHiddenField.Value) == 0)
            {
                struct_gzjz.p_gzfzr = dt_detail.Rows[0]["gzfzr"].ToString(); // 整改责任人
            }
            else
            {
                struct_gzjz.p_gzfzr = gzfzr.Substring(0, gzfzr.Length); // 整改责任人
            }
            #endregion
            #region label判断
            int flag = 0;

            //报送支线
            if (ddlt_bszx.SelectedValue.Trim() == "-1")
            {

                lbl_bszx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bszx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //工作主题
            if (string.IsNullOrEmpty(tbx_gzzt.Text))
            {

                lbl_gzzt.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzzt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //工作内容
            if (string.IsNullOrEmpty(tbx_gznr.Text))
            {

                lbl_gznr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gznr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //工作轮次
            if (string.IsNullOrEmpty(tbx_gzlc.Text))
            {

                lbl_gzlc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzlc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
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
            //工作负责人
            if (string.IsNullOrEmpty(tbx_gzfzr.Text))
            {

                lbl_gzfzr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzfzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //完成进度
            if (string.IsNullOrEmpty(tbx_wcjd.Text))
            {

                lbl_wcjd.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wcjd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            string sj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            //报送时间
            if (tbx_bssj.Text == "")
            {
                lbl_bssj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_bssj.Text.ToString(), sj))
                {
                    lbl_bssj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //完成时限
            if (tbx_wcsx.Text == "")
            {
                lbl_wcsx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_wcsx.Text.ToString(), sj))
                {
                    lbl_wcsx.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_wcsx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
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
            //数据所在部门
            if (ddlt_sjszbm.SelectedItem.Text.Trim() == "" || ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1)
            { return; }
            //动态添加工作步骤判断
            for (int i = 0; i < totalcontrols; i++)
            {
                TextBox tbx_gzbz_bz = (TextBox)this.plah_gzbz.Controls[i * 6 + 1];
                TextBox tbx_bzwcsx_bz = (TextBox)this.plah_gzbz.Controls[i * 6 + 4];

                if (tbx_gzbz_bz.Text.Trim() == "" || tbx_bzwcsx_bz.Text.Trim() == "" || (!Regex.IsMatch(tbx_bzwcsx_bz.Text.ToString(), sj)))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"工作步骤填写不正确！请确认时间格式和工作步骤内容！\")</script>");
                    return;
                }
            }
            #endregion
            //DataTable dt_detail = gzjz.SelectBS_GZJZ_Detail(bsbh);
            //struct_gzjz = new CUST.MKG.Struct_GZJZ();
            struct_gzjz.p_bsyg = _usState.userLoginName.ToString();
            struct_gzjz.p_bsbh = _usState.userGWDM + gzjz.SelectBS_GZJZMaxBH();
            struct_gzjz.p_bsbm = _usState.userBMDM;
            struct_gzjz.p_bsip = dt_detail.Rows[0]["bsip"].ToString();
            struct_gzjz.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());
            struct_gzjz.p_bsxtsj = DateTime.Parse(DateTime.Now.ToString());
            struct_gzjz.p_bszx = ddlt_bszx.SelectedValue;
            struct_gzjz.p_gzzt = tbx_gzzt.Text.ToString().Trim();
            struct_gzjz.p_gznr = tbx_gznr.Text.ToString().Trim();
            struct_gzjz.p_wcjd = tbx_wcjd.Text.ToString().Trim();
            struct_gzjz.p_gzlc = tbx_gzlc.Text.ToString().Trim();
            struct_gzjz.p_bz = tbx_bz.Text.ToString().Trim();
            struct_gzjz.p_wcsx = Convert.ToDateTime(tbx_wcsx.Text.ToString().Trim());
            struct_gzjz.p_bzsjc = dt_detail.Rows[0]["sjc"].ToString();

            struct_gzjz.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();
            struct_gzjz.p_sjc = sjc;//时间戳
            struct_gzjz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_gzjz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_gzjz.p_lrr = _usState.userLoginName.ToString();//录入人
            try
            {
                //int check_rz = 0;

                DataRow dt_row = dt_detail.Rows[0];
                struct_gzjz.p_czfs = "02";
                struct_gzjz.p_czxx = "位置:航务综合报送系统->工作进展信息->编辑  [报送编号：" + struct_gzjz.p_bsbh + "      描述：";
                if (struct_gzjz.p_bssj != Convert.ToDateTime(dt_row["bssj"]))
                {
                    struct_gzjz.p_czxx += "报送时间：【" + dt_row["bssj"].ToString() + "】->【" + struct_gzjz.p_bssj + "】";
                    //check_rz = 1;
                }
                if (struct_gzjz.p_bszx != dt_row["bszx"].ToString())
                {
                    struct_gzjz.p_czxx += "支线名称：【" + SysData.ZXDMByKey(dt_row["bszx"].ToString()).ms + "】->【" + SysData.ZXDMByKey(struct_gzjz.p_bszx).ms + "】";
                    //check_rz = 1;
                }
                if (struct_gzjz.p_gznr != dt_row["gznr"].ToString())
                {
                    struct_gzjz.p_czxx += "工作内容：【" + dt_row["gznr"].ToString() + "】->【" + struct_gzjz.p_gznr + "】";
                    //check_rz = 1;
                }
                if (struct_gzjz.p_wcjd != dt_row["wcjd"].ToString())
                {
                    struct_gzjz.p_czxx += "完成进度：【" + dt_row["wcjd"].ToString() + "】->【" + struct_gzjz.p_wcjd + "】";
                    //check_rz = 1;
                }
                if (struct_gzjz.p_gzlc != dt_row["gzlc"].ToString())
                {
                    struct_gzjz.p_czxx += "工作轮次：【" + dt_row["gzlc"].ToString() + "】->【" + struct_gzjz.p_gzlc + "】";
                    //check_rz = 1;
                }
                if (struct_gzjz.p_bz != dt_row["bz"].ToString())
                {
                    struct_gzjz.p_czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_gzjz.p_bz + "】";
                    //check_rz = 1;
                }
                //check_rz = 1;
                //if (check_rz == 0)
                //{
                //    Response.Write("<script>window.location.href='GZJZXXGL.aspx';</script>");
                //}
                string sjbs = Request.Params["sjbs"].ToString();

                //如果是原始数据
                if (sjbs.Equals("0"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr))
                    {
                        struct_gzjz.p_zt = "2";
                        struct_gzjz.p_sjbs = "0";
                        //给终审人添加提示
                        SysData.Insert_TSR(struct_gzjz.p_zsr, "13", "1306", Convert.ToInt32(id));
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                    {
                        struct_gzjz.p_zt = "3";
                        struct_gzjz.p_sjbs = "1";
                        SysData.Delete_TSR(struct_gzjz.p_zsr, "13", "1306", Convert.ToInt32(id));
                    }
                    if (!struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr) && !struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                    {
                        struct_gzjz.p_zt = "0";
                        struct_gzjz.p_sjbs = "0";
                    }
                    gzjz.UpdateBS_GZJZ(struct_gzjz);
                    save_GZJZ_BZ(totalcontrols);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("GZJZXXGL.aspx");
                }
                //如果是副本数据
                else if (sjbs.Equals("2"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr))
                    {
                        struct_gzjz.p_zt = "2";
                        struct_gzjz.p_sjbs = "2";
                        SysData.Insert_TSR(struct_gzjz.p_zsr, "13", "1306", Convert.ToInt32(id));
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_gzjz.p_sjc = sjc;
                        gzjz.Update_GZJZ_SJBS_LSSJ_ZT(struct_gzjz);

                        struct_gzjz.p_zt = "3";
                        struct_gzjz.p_sjbs = "1";
                        SysData.Delete_TSR(struct_gzjz.p_zsr, "13", "1306", Convert.ToInt32(id));
                    }
                    if (!struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr) && !struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                    {
                        struct_gzjz.p_zt = "0";
                        struct_gzjz.p_sjbs = "2";
                    }
                    gzjz.UpdateBS_GZJZ(struct_gzjz);
                    save_GZJZ_BZ(totalcontrols);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("GZJZXXGL.aspx");
                }
                else if (sjbs.Equals("1"))
                {
                    //生成该数据的副本,并返回新的备份id
                    id = Request.Params["id"].ToString();
                    int id_bf = gzjz.GZJZ_SJBF(Convert.ToInt32(id));
                    struct_gzjz.p_id = Convert.ToString(id_bf);


                    //初审人录入的数据，状态默认为待终审
                    if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr))
                    {
                        struct_gzjz.p_zt = "2";
                        struct_gzjz.p_sjbs = "2";
                        SysData.Insert_TSR(struct_gzjz.p_zsr, "13", "1306", Convert.ToInt32(id));
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_gzjz.p_sjc = sjc;
                        gzjz.Update_GZJZ_SJBS_LSSJ_ZT(struct_gzjz);

                        struct_gzjz.p_zt = "3";
                        struct_gzjz.p_sjbs = "1";
                        SysData.Delete_TSR(struct_gzjz.p_zsr, "13", "1306", Convert.ToInt32(id));
                    }
                    if (!struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr) && !struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                    {
                        struct_gzjz.p_zt = "0";
                        struct_gzjz.p_sjbs = "2";
                    }
                    //将新数据更新到副本数据里
                    gzjz.UpdateBS_GZJZ(struct_gzjz);
                    save_GZJZ_BZ(totalcontrols);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("GZJZXXGL.aspx");

                }
                else
                {
                    return;
                }
                //else
                //{
                //    struct_gzjz.p_czfs = "02";
                //    gzjz.UpdateBS_GZJZ(struct_gzjz);
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                //}

            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("GZJZXXGL.aspx", true);
        }
        //动态添加
        protected void btn_gzbz_Click(object sender, EventArgs e)
        {
            totalcontrols = totalcontrols + 1;
            dymanicallygeneratetextboxcontrol(totalcontrols);
            show(totalcontrols);
        }
        //动态删除
        protected void btn_scgzbz_Click(object sender, EventArgs e)
        {
            DymanicallyDelete(totalcontrols);
            totalcontrols = totalcontrols - 1;
              DateTime[] wcsx = new DateTime[totalcontrols];
           string[] gzbz = new string[totalcontrols];
           for (int i = 0; i < totalcontrols; i++)
           {
               //control下标为0开始  单数为数据
               TextBox tbx_gzbz = (TextBox)this.plah_gzbz.Controls[i * 6 + 1];
               gzbz[i] = tbx_gzbz.Text.Trim();
               TextBox tbx_bzwcsx = (TextBox)this.plah_gzbz.Controls[i * 6 + 4];
                if (tbx_bzwcsx.Text.Trim().ToString() == "")
                {

                    wcsx[i] = DateTime.Now;
                }
                else
                {
                    wcsx[i] = Convert.ToDateTime(tbx_bzwcsx.Text.Trim().ToString());
                }
            }
           this.plah_gzbz.Controls.Clear();
           Page_Load(sender,e);
           for (int j = 0; j < totalcontrols; j++)
           {
               TextBox[] gzbz_j = new TextBox[totalcontrols];
               gzbz_j[j] = (TextBox)this.plah_gzbz.Controls[j * 6 + 1];
               gzbz_j[j].Text = gzbz[j];

               TextBox[] wcsx_n = new TextBox[totalcontrols];
               wcsx_n[j] = (TextBox)this.plah_gzbz.Controls[j * 6 + 4];
               wcsx_n[j].Text = wcsx[j].ToString("yyyy-MM-dd");
           }
        }

        #region tbx_gzfzr.Text数据绑定
        protected void ddlt_gwdm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = gzjz.SelectBS_FZR_byBMGW(bmdm, gwdm);
            ddlt_syr1.DataSource = dt;
            ddlt_syr1.DataTextField = "xm";
            ddlt_syr1.DataValueField = "bh";
            ddlt_syr1.DataBind();
        }
        protected void ddlt_bmdm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = gzjz.SelectBS_FZR_byBMGW(bmdm, gwdm);
            ddlt_syr1.DataSource = dt;
            ddlt_syr1.DataTextField = "xm";
            ddlt_syr1.DataValueField = "bh";
            ddlt_syr1.DataBind();
        }
        protected void btn_bc_syr1_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm1.SelectedValue.ToString();
            string gwdm = ddlt_gwdm1.SelectedValue.ToString();
            string yg = ddlt_syr1.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr1.Items.Count > 0)
            {
                tbx_gzfzr.Text = ddlt_syr1.SelectedItem.Text;
                gzfzr = ddlt_syr1.SelectedValue.ToString();
            }
        }
        #endregion
    }
}