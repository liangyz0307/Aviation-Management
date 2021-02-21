using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG
{
    public partial class ST_TKT_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private TKT tkt;
        private Struct_TKT struct_tkt;
        protected int TotalControls
        {
            get
            {
                return ViewState["TotControls"] == null ? 1 : (int)(ViewState["TotControls"]);
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
            tkt = new TKT(_usState);
            if (!IsPostBack)
            {
                ddltBind();
            }
            for (int i = 0; i < TotalControls; i++)
            {
                DymanicallyGenerateTGTK(i + 1);
            }
        }
        #region 数据绑定
        protected void ddltBind()
        {
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
        private void DymanicallyGenerateTGTK(int totalControls)
        {
            //1.产生题干
            //Label tg = new Label();
            //tg.ID = "lbl_tg_" + totalControls;
            //tg.Text = "<font size=\"5px\"> _______ </font>";
            //this.ph_tg.Controls.Add(tg);
            //TextBox tbx_tg = new TextBox();
            //tbx_tg.ID = "tbx_tg_" + totalControls;
            //tbx_tg.TextMode = TextBoxMode.MultiLine;
            //tbx_tg.MaxLength = 100;
            //tbx_tg.CssClass = "";
            //tbx_tg.Width = 200;
            //tbx_tg.Height = 30;
            //this.ph_tg.Controls.Add(tbx_tg);
            //2.产生答案
            Label lbl_da = new Label();
            lbl_da.ID = "lbl_da" + totalControls;
            lbl_da.Text = "<font size=\"5px\">  " + totalControls + " . </font>";
            this.ph_da.Controls.Add(lbl_da);
            TextBox tbx_da = new TextBox();
            tbx_da.ID = "tbx_da_" + totalControls;
            tbx_da.TextMode = TextBoxMode.MultiLine;
            tbx_da.MaxLength = 100;
            tbx_da.CssClass = "";
            tbx_da.Width = 200;
            tbx_da.Height = 30;
            this.ph_da.Controls.Add(tbx_da);
        }
        private void DymanicallyDeleteTGTK(int totalControls)
        {
            //1.移除答案
            TextBox tbx_da = new TextBox();
            tbx_da.ID = "tbx_da_" + totalControls;
            tbx_da.TextMode = TextBoxMode.MultiLine;
            tbx_da.MaxLength = 100;
            tbx_da.CssClass = "";
            tbx_da.Width = 200;
            this.ph_da.Controls.Remove(tbx_da);
            Label lbl_da = new Label();
            lbl_da.ID = "lbl_da" + totalControls;
            lbl_da.Text = "  " + totalControls + " . ";
            this.ph_da.Controls.Remove(lbl_da);
            //2.移除题干
            //TextBox tbx_tg = new TextBox();
            //tbx_tg.ID = "tbx_tg_" + totalControls;
            //tbx_tg.TextMode = TextBoxMode.MultiLine;
            //tbx_tg.MaxLength = 100;
            //tbx_tg.CssClass = "";
            //tbx_tg.Width = 200;
            //this.ph_tg.Controls.Remove(tbx_tg);
            //Label tg = new Label();
            //tg.ID = "lbl_tg_" + totalControls;
            //tg.Text = "  " + totalControls + " . ";
            //this.ph_tg.Controls.Remove(tg);
        }
        protected void btn_add_tg_Click(object sender, EventArgs e)
        {
            TotalControls = TotalControls + 1;
            DymanicallyGenerateTGTK(TotalControls);

        }
        protected void btn_delete_tg_Click(object sender, EventArgs e)
        {
            if (TotalControls > 1)
            {
                DymanicallyDeleteTGTK(TotalControls);
                TotalControls = TotalControls - 1;
                //保存
                string[] das = new string[TotalControls];
                for (int i = 0; i < TotalControls; i++)
                {
                    TextBox tbx_da = (TextBox)this.ph_da.Controls[i * 2 + 1];
                    das[i] = tbx_da.Text.Trim();
                }
                //清空
                ph_da.Controls.Clear();
                //重新加载
                this.Page_Load(sender, e);
                //复原
                for (int i = 0; i < TotalControls; i++)
                {
                    TextBox tbx_da = (TextBox)this.ph_da.Controls[i * 2 + 1];
                    tbx_da.Text = das[i];
                }
            }
            else if (TotalControls == 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"填空不得少于一个！\")</script>");
                return;
            }
        }
        #endregion
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 数据校验
            int flag = 0;
            //试题题干
            string tg = tbx_tg.Text.ToString().Trim();
            string[] das = new string[TotalControls];
            if (string.IsNullOrEmpty(tg))
            {
                lbl_tg.Text = "<span style=\"color:#ff0000\">" + "错误：不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            for (int i = 0; i < TotalControls; i++)
            {
                TextBox tbx_da = (TextBox)this.ph_da.Controls[i * 2 + 1];
                das[i] = tbx_da.Text.Trim();
                if (string.IsNullOrEmpty(das[i]))
                {
                    lbl_da.Text = "<span style=\"color:#ff0000\">" + "错误：不能为空" + "</span>";
                    flag = 1;
                    break;
                }
                else
                {
                    lbl_da.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
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
                    TextBox tbx_da = (TextBox)this.ph_da.Controls[i * 2 + 1];
                    tbx_da.Text = das[i];
                }
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
                struct_tkt = new Struct_TKT();
                string da = "";
                for (int i = 0; i < TotalControls; i++)
                {
                    if (i == 0)
                    {
                        da = das[0];
                    }
                    else
                    {
                        da += "##&&##" + das[i];
                    }
                }
                struct_tkt.p_tg = tg;
                struct_tkt.p_da = da;
                struct_tkt.p_lj = "";
                struct_tkt.p_sfytp = "";
                struct_tkt.p_nd = nd;
                struct_tkt.p_km = km;
                struct_tkt.p_lb = st_lb;
                struct_tkt.p_gw = str_gw;
                struct_tkt.p_kczsd = kczsd;
                struct_tkt.p_czfs = "01";
                struct_tkt.p_czxx = "位置：在线培训->试题管理->试题添加  填空题  试题题干：" + struct_tkt.p_tg +
                    " 试题答案：" + struct_tkt.p_da + "试题难度：" + struct_tkt.p_nd + " 适用科目：" + struct_tkt.p_km +
                    "适用岗位：" + struct_tkt.p_gw + " 考察知识点：" + struct_tkt.p_kczsd;
                tkt.Insert_TKT(struct_tkt);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
            #endregion
            #region 添加成功，进行清除
            for (int i = 0; i < TotalControls; i++)
            {
                TextBox tbx_da = (TextBox)this.ph_da.Controls[i * 2 + 1];
                tbx_da.Text = "";
            }
            tbx_tg.Text = "";
            tbx_kczsd.Text = "";
            lbl_tg.Text = "";
            lbl_da.Text = "";
            lbl_nd.Text = "";
            lbl_km.Text = "";
            lbl_gw.Text = "";
            lbl_kczsd.Text = "";
            #endregion
        }


        #region 部门全选+错误处理
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
        #endregion



    }
}