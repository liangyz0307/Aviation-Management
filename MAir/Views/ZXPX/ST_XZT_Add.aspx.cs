using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG
{
    public partial class ST_XZT_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private XZT xzt;
        private static string sfdx;
        private Struct_XZT struct_xzt;
        protected int TotalControls
        {
            get
            {
                return ViewState["TotControls"] == null ? 4 : (int)(ViewState["TotControls"]);
            }
            set
            {
                ViewState["TotControls"] = value;
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
            xzt = new XZT(_usState);
            if (!IsPostBack)
            {
                //需要判断是否有此参数
                if (Request.Params["sfdx"] != null)
                {
                    sfdx = Request.Params["sfdx"].ToString().Trim();
                }
                else
                {
                    sfdx = "0";
                }
                ddltBind();
                da_Bind();
            }
            for (int i = 0; i < TotalControls; i++)
            {
                DymanicallyGenerateXX(i + 1);
            }
        }
        #region 数据绑定
        protected void da_Bind()
        {
            //正确选项下拉框
            ddlt_da.Items.Clear();
            ddlt_da.Items.Insert(0, new ListItem("请选择", "-1"));
            for (int i = 0; i < TotalControls; i++)
            {
                ddlt_da.Items.Insert(i + 1, new ListItem("" + Convert.ToChar('A' + i), "" + Convert.ToChar('A' + i)));
            }
            cbxl_da.Items.Clear();
            for (int i = 0; i < TotalControls; i++)
            {
                cbxl_da.Items.Insert(i, new ListItem("" + Convert.ToChar('A' + i), "" + Convert.ToChar('A' + i)));
            }
        }
        protected void ddltBind()
        {
            //类型
            ddlt_stlx.Items.Insert(0, new ListItem("单选题", "0"));
            ddlt_stlx.Items.Insert(1, new ListItem("多选题", "1"));
            ddlt_stlx.SelectedValue = sfdx;
            if (sfdx == "0")
            {
                ddlt_da.Visible = true;
                cbxl_da.Visible = false;
            }
            else
            {
                ddlt_da.Visible = false;
                cbxl_da.Visible = true;
            }
            //试题难度
            ddlt_stnd.DataTextField = "mc";
            ddlt_stnd.DataValueField = "bm";
            ddlt_stnd.DataSource = SysData.STND().Copy();
            ddlt_stnd.DataBind();
            ddlt_stnd.Items.Insert(0, new ListItem("请选择", "-1"));
            //科目
            ddlt_km.DataTextField = "mc";
            ddlt_km.DataValueField = "bm";
            ddlt_km.DataSource = SysData.KM().Copy();
            ddlt_km.DataBind();
            ddlt_km.Items.Insert(0, new ListItem("请选择", "-1"));

            //类别
            ddlt_stlb.DataTextField = "mc";
            ddlt_stlb.DataValueField = "bm";
            ddlt_stlb.DataSource = SysData.STLB().Copy();
            ddlt_stlb.DataBind();
            ddlt_stlb.Items.Insert(0, new ListItem("请选择", "-1"));

            //岗位
            cbxl_gw.DataTextField = "mc";
            cbxl_gw.DataValueField = "bm";
            cbxl_gw.DataSource = SysData.GW().Copy();
            cbxl_gw.DataBind();
        }
        #endregion
        #region 动态产生选项个数
        private void DymanicallyGenerateXX(int totalControls)
        {
            //Label
            string xx_str = Convert.ToChar('A' + (totalControls - 1)).ToString();
            Label xx = new Label();
            xx.ID = "lbl_xx" + xx_str;
            xx.Text = " " + xx_str + ".";
            this.ph_xx.Controls.Add(xx);
            //TextBox
            TextBox tb = new TextBox();
            tb.ID = "tbx_" + xx_str;
            tb.TextMode = TextBoxMode.MultiLine;
            tb.MaxLength = 100;
            tb.CssClass = "";
            tb.Width = 426;
            tb.Height = 30;
            this.ph_xx.Controls.Add(tb);
            //Label
            Label la = new Label();
            la.ID = "lbl_" + xx_str;
            this.ph_xx.Controls.Add(la);
            //回车
            ph_xx.Controls.Add(new LiteralControl("<br>"));
        }
        private void DymanicallyDeleteXX(int totalControls)
        {
            this.ph_xx.Controls.Remove(new LiteralControl("<br>"));
            string xx_str = Convert.ToChar('A' + (totalControls - 1)).ToString();
            Label la = new Label();
            la.ID = "lbl_" + xx_str;
            this.ph_xx.Controls.Remove(la);
            TextBox tb = new TextBox();
            tb.ID = "tbx_" + xx_str;
            this.ph_xx.Controls.Remove(tb);
            Label xx = new Label();
            xx.ID = "lbl_xx" + xx_str;
            this.ph_xx.Controls.Remove(xx);
        }
        protected void btn_add_xx_Click(object sender, EventArgs e)
        {
            TotalControls = TotalControls + 1;
            DymanicallyGenerateXX(TotalControls);
            da_Bind();
        }
        protected void btn_delete_xx_Click(object sender, EventArgs e)
        {
            if (TotalControls > 3)
            {
                DymanicallyDeleteXX(TotalControls);
                TotalControls = TotalControls - 1;
                da_Bind();
                //保存
                string[] xxStrs = new string[TotalControls];
                for (int i = 0; i < TotalControls; i++)
                {
                    TextBox txb = (TextBox)this.ph_xx.Controls[i * 4 + 1];
                    xxStrs[i] = txb.Text;
                }
                //清空
                this.ph_xx.Controls.Clear();
                //重新加载
                this.Page_Load(sender, e);
                //复原
                for (int i = 0; i < TotalControls; i++)
                {
                    TextBox txb = (TextBox)this.ph_xx.Controls[i * 4 + 1];
                    txb.Text = xxStrs[i];
                }
            }
            else if (TotalControls == 3)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"选项不得少于三个！\")</script>");
                return;
            }
        }
        #endregion
        protected void btn_save_Click(object sender, EventArgs e)
        {
            sfdx = ddlt_stlx.SelectedValue;
            #region 数据校验
            int flag = 0;
            //试题题干
            string tg = tbx_tg.Text.ToString().Trim();
            if (string.IsNullOrEmpty(tg))
            {
                lbl_tg.Text = "<span style=\"color:#ff0000\">" + "错误：不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //选项
            string[] xxStrs = new string[TotalControls];
            for (int i = 0; i < TotalControls; i++)
            {
                TextBox txb = (TextBox)this.ph_xx.Controls[i * 4 + 1];
                xxStrs[i] = txb.Text;
                Label lbl = (Label)this.ph_xx.Controls[i * 4 + 2];
                if (string.IsNullOrEmpty(xxStrs[i]))
                {
                    lbl.Text = "<span style=\"color:#ff0000\">" + "错误：不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //答案
            string da = "";
            if (sfdx == "0")
            {
                da = ddlt_da.SelectedValue.ToString().Trim();
            }
            else
            {
                for (int i = 0; i < cbxl_da.Items.Count; i++)
                {
                    if (cbxl_da.Items[i].Selected)
                    {
                        da += cbxl_da.Items[i].Value + ";";
                    }
                }
            }
            if (da == ""||da == "-1")
            {
                lbl_da.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_da.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //试题难度
            string nd = ddlt_stnd.SelectedValue.ToString().Trim();
            if (nd == "-1")
            {
                lbl_nd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_nd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //科目
            string km = ddlt_km.SelectedValue.ToString().Trim();
            if (km == "-1")
            {
                lbl_km.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_km.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //类别
            string st_lb = ddlt_stlb.SelectedValue.ToString().Trim();
            if (st_lb == "-1")
            {
                lbl_stlb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_stlb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //岗位
            ArrayList gw = new ArrayList();
            for (int i = 0; i < cbxl_gw.Items.Count; i++)
            {
                if (cbxl_gw.Items[i].Selected)
                {
                    gw.Add(cbxl_gw.Items[i].Value);
                }
            }
            if (gw.Count == 0)
            {
                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //考察知识点
            string kczsd = tbx_kczsd.Text.ToString().Trim();
            if (string.IsNullOrEmpty(kczsd))
            {
                lbl_kczsd.Text = "<span style=\"color:#ff0000\">" + "错误：不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_kczsd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1)
            {
                tbx_tg.Text = tg;
                for (int i = 0; i < TotalControls; i++)
                {
                    TextBox txb = (TextBox)this.ph_xx.Controls[i * 4 + 1];
                    txb.Text = xxStrs[i];
                }
                ddlt_da.SelectedValue = da;
                ddlt_stnd.SelectedValue = nd;
                ddlt_km.SelectedValue = km;
                //ddlt_gw.SelectedValue = gw;
                for (int i = 0; i < gw.Count; i++)
                {
                    cbxl_gw.Items.FindByValue(gw[i].ToString()).Selected = true;
                }
                tbx_kczsd.Text = kczsd;
                return;
            }
            #endregion
            #region 数据封装,添加
            try
            {
                string str_gw = "";
                for (int i = 0; i < gw.Count; i++)
                {
                    if (i == 0)
                    {
                        str_gw = gw[i].ToString();
                    }
                    else
                    {
                        str_gw += "##&&##" + gw[i].ToString();
                    }
                }
                struct_xzt = new Struct_XZT();
                struct_xzt.p_tg = tg;
                struct_xzt.p_sfdx = sfdx;//===========================================================================
                struct_xzt.p_lj = "";
                struct_xzt.p_sfytp = "";
                struct_xzt.p_da = da;
                struct_xzt.p_nd = nd;
                struct_xzt.p_km = km;
                struct_xzt.p_lb = st_lb;
                struct_xzt.p_gw = str_gw;
                struct_xzt.p_kczsd = kczsd;
                struct_xzt.p_czfs = "01";
                struct_xzt.p_czxx = "位置：在线培训->试题管理->试题添加  选择题  试题题干：" + struct_xzt.p_tg +
                    "试题答案：" + struct_xzt.p_da +
                    "试题难度：" + struct_xzt.p_nd + " 适用科目：" + struct_xzt.p_km +
                    "适用岗位：" + struct_xzt.p_gw + " 考察知识点：" + struct_xzt.p_kczsd;
                xzt.Insert_XZT(struct_xzt);
                //插入选择题选项
                //查询当前试题的试题编号
                Struct_Select_ST struct_st = new Struct_Select_ST();
                struct_st.p_tg = tg;
                struct_st.p_sfdx = sfdx;//===========================================================================
                struct_st.p_nd = nd;
                struct_st.p_km = km;
                struct_st.p_lb = st_lb;
                struct_st.p_gw = str_gw;
                struct_st.p_zt = "0";
                struct_st.p_currentpage = 1;
                struct_st.p_pagesize = 5;
                DataTable dt_st = xzt.Select_XZT_Pro(struct_st);
                long st_id = Convert.ToInt64(dt_st.Rows[0]["id"]);
                Struct_XZT_XX struct_xzt_xx = new Struct_XZT_XX();
                struct_xzt_xx.p_st_id = st_id;
                for (int i = 0; i < TotalControls; i++)
                {
                    struct_xzt_xx.p_xx = Convert.ToChar('A' + (i)).ToString();
                    struct_xzt_xx.p_xxnr = xxStrs[i];
                    struct_xzt_xx.p_czfs = "01";
                    struct_xzt_xx.p_czxx = "位置：在线培训->试题管理->试题添加->试题选项添加   试题编号： " + st_id +
                        "试题选项：" + struct_xzt_xx.p_xx + " 选项内容：" + struct_xzt_xx.p_xxnr;
                    xzt.Insert_XZT_XX(struct_xzt_xx);
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
            #endregion
            #region 添加成功，进行清除
            tbx_tg.Text = "";
            for (int i = 0; i < TotalControls; i++)
            {
                TextBox txb = (TextBox)this.ph_xx.Controls[i * 4 + 1];
                txb.Text = "";
                Label lbl = (Label)this.ph_xx.Controls[i * 4 + 2];
                lbl.Text = "";
            }
            tbx_kczsd.Text = "";
            lbl_tg.Text = "";
            lbl_da.Text = "";
            lbl_nd.Text = "";
            lbl_km.Text = "";
            lbl_stlb.Text = "";
            lbl_gw.Text = "";
            lbl_kczsd.Text = "";
            #endregion
        }
        protected void cbx_qx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_qx.Checked)
            {
                for (int j = 0; j < cbxl_gw.Items.Count; j++)
                {
                    cbxl_gw.Items[j].Selected = true;
                }
            }
            else
            {
                for (int j = 0; j < cbxl_gw.Items.Count; j++)
                {
                    cbxl_gw.Items[j].Selected = false;
                }
            }
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZXPX/STGL.aspx", true);
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

        protected void ddlt_stlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sfdx = ddlt_stlx.SelectedValue.ToString();
            if (sfdx == "0")
            {
                ddlt_da.Visible = true;
                cbxl_da.Visible = false;
            }
            else
            {
                ddlt_da.Visible = false;
                cbxl_da.Visible = true;
            }
        }
    }
}