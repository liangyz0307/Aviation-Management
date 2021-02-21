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
using System.Text.RegularExpressions;
using Sys;
using System.Globalization;


namespace CUST.WKG
{
    public partial class GZJZXXGL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        public bool flag = true;
        public int i = 0;
        private GZJZ gzjz;
        static string gzfzr;
        private Struct_GZJZ struct_gzjz;


        public String GetClientIp()
        {
            String clientIP = "";
            if (System.Web.HttpContext.Current != null)
            {
                clientIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(clientIP) || (clientIP.ToLower() == "unknown"))
                {
                    clientIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_REAL_IP"];
                    if (string.IsNullOrEmpty(clientIP))
                    {
                        clientIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    clientIP = clientIP.Split(',')[0];
                }
            }
            return clientIP;
        }

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            gzjz = new GZJZ (_usState);
          
            if (!IsPostBack)
            {
                ddltBind();
                texBind();
                tbx_bssj.Attributes.Add("readonly", "readonly");
                tbx_wcsx.Attributes.Add("readonly", "readonly");
                tbx_bzwcsx.Attributes.Add("readonly", "readonly");
                tbx_gzfzr.Attributes.Add("readonly", "readonly");

            }
            for (int i = 0; i < totalcontrols; i++)
            {
                dymanicallygeneratetextboxcontrol(i + 1);
            }
            show(totalcontrols);
        }
        #region 工作步骤样式以及内容
        //动态添加的工作步骤的全部样式 控件位置是页面的plah_gzbz
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
        #endregion
        private void texBind()
        {
            lbl_bsyg.Text = _usState.userXM;
            lbl_bsbm.Text = _usState.userBMMC;
            //tbx_gzfzr.Text = gzjz.SelectBS_FZR_byBMDM(_usState.userBMDM).Rows[0]["xm"].ToString();
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

            #region 员工选择框1
            DataTable dt_bmdm = SysData.BM("130102", _usState.userID).Copy();
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
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string sjc= DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);//时间戳
            struct_gzjz.p_bzsjc = sjc;//时间戳
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
            //工作步骤
            if (string.IsNullOrEmpty(tbx_gzbz.Text))
            {

                lbl_gzbz.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzbz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            //步骤完成时限
            if (tbx_bzwcsx.Text == "")
            {
                lbl_bzwcsx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_bzwcsx.Text.ToString(), sj))
                {
                    lbl_bzwcsx.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_bzwcsx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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

                if (tbx_gzbz_bz.Text.Trim() == "" || tbx_bzwcsx_bz.Text.Trim()== "" || (!Regex.IsMatch(tbx_bzwcsx_bz.Text.ToString(), sj)))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"工作步骤填写不正确！请确认时间格式和工作步骤内容！\")</script>");
                    return;
                }
            }
            #endregion
            try
            {
                //System.Net.Sockets.TcpClient c = new System.Net.Sockets.TcpClient();

                struct_gzjz.p_bsbh = _usState.userGWDM + gzjz.SelectBS_GZJZMaxBH();
                struct_gzjz.p_bsyg = _usState.userLoginName.ToString();
                struct_gzjz.p_bsbm = _usState.userBMDM.ToString().Trim();
                struct_gzjz.p_bsip = GetClientIp();
                struct_gzjz.p_bssj = DateTime.Parse(tbx_bssj.Text.ToString().Trim());
                struct_gzjz.p_bsxtsj = DateTime.Parse(DateTime.Now.ToString());
                struct_gzjz.p_bszx = ddlt_bszx.SelectedValue;
                struct_gzjz.p_gzzt = tbx_gzzt.Text.ToString().Trim();
                struct_gzjz.p_gznr = tbx_gznr.Text.ToString().Trim();
                struct_gzjz.p_wcjd = tbx_wcjd.Text.ToString().Trim();
                struct_gzjz.p_gzfzr = gzfzr; /*gzjz.SelectBS_FZR_byBMDM(_usState.userBMDM).Rows[0]["fzr"].ToString();*/
                struct_gzjz.p_gzlc = tbx_gzlc.Text.ToString().Trim();
                struct_gzjz.p_bz = tbx_bz.Text.ToString().Trim();
                struct_gzjz.p_gzbz = tbx_gzbz.Text.ToString().Trim();
                struct_gzjz.p_wcsx = DateTime.Parse(tbx_wcsx.Text.ToString().Trim());
                struct_gzjz.p_bzwcsx = DateTime.Parse(tbx_bzwcsx.Text.ToString().Trim());

                struct_gzjz.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();
                struct_gzjz.p_sjc = sjc;//时间戳
                struct_gzjz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                struct_gzjz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                struct_gzjz.p_lrr = _usState.userLoginName.ToString();//录入人
                struct_gzjz.p_czfs = "01";
                struct_gzjz.p_czxx = "位置：航务综合报送系统->工作进展信息->添加      描述：报送部门：" + struct_gzjz.p_bsbm + "报送IP：" + struct_gzjz.p_bsip + "报送时间:" + struct_gzjz.p_bssj
                    + "支线名称：" + struct_gzjz.p_bszx + "工作标题：" + struct_gzjz.p_gzzt + "完成进度：" + struct_gzjz.p_wcjd + "完成时限：" + struct_gzjz.p_wcsx + "工作负责人：" + struct_gzjz.p_gzfzr
                    + "工作轮次：" + struct_gzjz.p_gzlc + "备注" + struct_gzjz.p_bz;

                if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr))
                {
                    struct_gzjz.p_sjbs = "0";
                    struct_gzjz.p_zt = "2";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_gzjz.p_zsr, "13", "1301", -1);
                }
                //如果是终审人录入数据，则状态为审核通过
                if (struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                {
                    struct_gzjz.p_sjbs = "1";
                    struct_gzjz.p_zt = "3";
                }
                if (!struct_gzjz.p_lrr.Equals(struct_gzjz.p_csr) && !struct_gzjz.p_lrr.Equals(struct_gzjz.p_zsr))
                {
                    struct_gzjz.p_sjbs = "0";
                    struct_gzjz.p_zt = "0";
                }
                //先插入必有的一条工作步骤
                gzjz.InsertBS_GZJZ(struct_gzjz);
                gzjz.Insert_gzjz_bz(struct_gzjz);

                //动态添加的工作步骤插入
                #region 工作步骤添加

                DateTime[] bzwcsx = new DateTime[totalcontrols];
                string[] gzbz = new string[totalcontrols];
                for (int i = 0; i < totalcontrols; i++)
                {
                    //control下标为0开始  单数为数据 控件位置是plah_gzbz Controls【】中数字为对应控件ID 控件ID在dymanicallygeneratetextboxcontrol添加时生成
                    TextBox tbx_gzbz = (TextBox)this.plah_gzbz.Controls[i * 6 + 1];
                    gzbz[i] = tbx_gzbz.Text.Trim();
                    TextBox tbx_bzwcsx = (TextBox)this.plah_gzbz.Controls[i * 6 + 4];
                    bzwcsx[i] = Convert.ToDateTime(tbx_bzwcsx.Text.Trim());
                }

                for (int j = 0; j < totalcontrols; j++)
                {

                    struct_gzjz.p_gzbz = gzbz[j];
                    struct_gzjz.p_bzwcsx = bzwcsx[j];
                    //struct_gzjz.p_bzsjc = sjc;

                    struct_gzjz.p_czfs = "01";
                    struct_gzjz.p_czxx = "位置：航务综合报送系统->工作进展信息->添加  描述：报送编号：" + struct_gzjz.p_bsbh + "工作步骤：" + struct_gzjz.p_gzbz + "完成时限：" + struct_gzjz.p_bzwcsx;
                    gzjz.Insert_gzjz_bz(struct_gzjz);
                }
                #endregion
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");

            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
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
            Response.Redirect("GZJZXXGL.aspx", true);
        }
        #region 工作步骤按钮
        //工作步骤不足一个将不显示删除按键
        protected void show(int totalcontrols)
        {
            if (totalcontrols < 1)
                btn_scgzbz.Visible = false;
            else
                btn_scgzbz.Visible = true;
        }
        protected void btn_gzbz_Click(object sender, EventArgs e)
        {
            totalcontrols = totalcontrols + 1;
            dymanicallygeneratetextboxcontrol(totalcontrols);
            show(totalcontrols);
        }

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
               gzbz_j[j] = (TextBox)this.plah_gzbz.Controls[j * 6 + 1] ;
               gzbz_j[j].Text = gzbz[j];

               TextBox[] wcsx_n = new TextBox[totalcontrols];
               wcsx_n[j] = (TextBox)this.plah_gzbz.Controls[j * 6 + 4];
               wcsx_n[j].Text = wcsx[j].ToString("yyyy-MM-dd");
            }

        }

        //删除
        private void DymanicallyDelete(int totalControls)
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
            tax_wcsx.ID = "wcsx" + totalcontrols;
            this.plah_gzbz.Controls.Remove(lbl_gzbz);
            this.plah_gzbz.Controls.Remove(tbx_gznr);
            Literal lit = new Literal();
            lit.Text = "<br/>";
            this.plah_gzbz.Controls.Remove(lit);
            this.plah_gzbz.Controls.Remove(lbl_wcsx);
            this.plah_gzbz.Controls.Remove(tax_wcsx);
            Literal lite = new Literal();
            lite.Text = "<br/>";
            this.plah_gzbz.Controls.Remove(lite);
        }
        #endregion

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