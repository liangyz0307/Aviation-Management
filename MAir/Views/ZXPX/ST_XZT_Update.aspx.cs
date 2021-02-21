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
    public partial class ST_XZT_Update : System.Web.UI.Page
    {
        private UserState _usState;
        private XZT xzt;
        private Struct_XZT struct_xzt;
        private DataTable dt_xzt;
        private DataTable dt_xx;
        private long st_id;
        private static string sfdx;
        private int TotalControls;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            xzt = new XZT(_usState);
            st_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
            dt_xzt = xzt.Select_XZT_Detail(st_id);
            dt_xx = xzt.Select_XZT_XX(st_id);
            TotalControls = dt_xx.Rows.Count;
            if (!IsPostBack)
            {
                Data_Bind();
            }
            for (int i = 0; i < TotalControls; i++)
            {
                DymanicallyGenerateXX(i + 1);
            }
        }
        protected void Data_Bind()
        {
            dt_xzt = xzt.Select_XZT_Detail(st_id);
            dt_xx = xzt.Select_XZT_XX(st_id);
            tbx_tg.Text = dt_xzt.Rows[0]["tg"].ToString();
            //正确选项下拉框
            sfdx = dt_xzt.Rows[0]["sfdx"].ToString();
            if (sfdx == "0")
            {
                ddlt_da.Visible = true;
                cbxl_da.Visible = false;
                ddlt_da.Items.Insert(0, new ListItem("请选择", "-1"));
                for (int i = 0; i < TotalControls; i++)
                {
                    ddlt_da.Items.Insert(i + 1, new ListItem("" + Convert.ToChar('A' + i), "" + Convert.ToChar('A' + i)));
                }
                ddlt_da.SelectedValue = dt_xzt.Rows[0]["da"].ToString();
            }else {
                ddlt_da.Visible = false;
                cbxl_da.Visible = true;
                for (int i = 0; i < TotalControls; i++)
                {
                    cbxl_da.Items.Insert(i, new ListItem("" + Convert.ToChar('A' + i), "" + Convert.ToChar('A' + i)));
                }
                string str_da = dt_xzt.Rows[0]["da"].ToString();
                string[] arr_da = str_da.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr_da.Length; i++)
                {
                    cbxl_da.Items.FindByValue(arr_da[i]).Selected = true;
                }
            }
            //试题难度
            ddlt_stnd.DataTextField = "mc";
            ddlt_stnd.DataValueField = "bm";
            ddlt_stnd.DataSource = SysData.STND().Copy();
            ddlt_stnd.DataBind();
            ddlt_stnd.SelectedValue = dt_xzt.Rows[0]["nd"].ToString();
            //科目
            ddlt_km.DataTextField = "mc";
            ddlt_km.DataValueField = "bm";
            ddlt_km.DataSource = SysData.KM().Copy();
            ddlt_km.DataBind();
            ddlt_km.SelectedValue = dt_xzt.Rows[0]["km"].ToString();

            //类别
            ddlt_stlb.DataTextField = "mc";
            ddlt_stlb.DataValueField = "bm";
            ddlt_stlb.DataSource = SysData.STLB().Copy();
            ddlt_stlb.DataBind();
            ddlt_stlb.SelectedValue = dt_xzt.Rows[0]["lb"].ToString();
            //岗位
            //ddlt_gw.DataTextField = "mc";
            //ddlt_gw.DataValueField = "bm";
            //ddlt_gw.DataSource = SysData.GW().Copy();
            //ddlt_gw.DataBind();
            //ddlt_gw.SelectedValue = dt_xzt.Rows[0]["gw"].ToString();
            cbxl_gw.DataTextField = "mc";
            cbxl_gw.DataValueField = "bm";
            cbxl_gw.DataSource = SysData.GW().Copy();
            cbxl_gw.DataBind();
            string str_gw = dt_xzt.Rows[0]["gw"].ToString();
            string[] arr_gw = str_gw.Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr_gw.Length; i++)
            {
                cbxl_gw.Items.FindByValue(arr_gw[i]).Selected = true;
            }
            tbx_kczsd.Text = dt_xzt.Rows[0]["kczsd"].ToString();
        }
        /// <summary>
        ///  动态产生选项个数
        /// </summary>
        /// <param name="totalControls"></param>
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
            tb.Text = dt_xx.Rows[totalControls - 1]["xxnr"].ToString();
            tb.MaxLength = 100;
            tb.CssClass = "";
            tb.Width = 426;
            this.ph_xx.Controls.Add(tb);
            //Label
            Label la = new Label();
            la.ID = "lbl_" + xx_str;
            this.ph_xx.Controls.Add(la);
            //回车
            ph_xx.Controls.Add(new LiteralControl("<br>"));
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
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
            if (da == "" || da == "-1")
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
            DataTable dt_st = dt_xzt.Copy();
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
                struct_xzt.p_id = Convert.ToInt64(dt_st.Rows[0]["id"].ToString());
                struct_xzt.p_tg = tg;
                struct_xzt.p_da = da;
                struct_xzt.p_sfdx = sfdx;
                struct_xzt.p_lj = "";
                struct_xzt.p_sfytp = "";
                struct_xzt.p_nd = nd;
                struct_xzt.p_km = km;
                struct_xzt.p_lb = st_lb;
                struct_xzt.p_gw = str_gw;
                struct_xzt.p_kczsd = kczsd;
                struct_xzt.p_sfqy = dt_st.Rows[0]["sfqy"].ToString();
                struct_xzt.p_czfs = "02";// 编辑
                int check_rz = 0;
                struct_xzt.p_czxx = "位置：在线培训->试题管理->试题编辑  选择题编辑 试题ID：[" + struct_xzt.p_id + "]  描述：";
                //试题题干
                if (struct_xzt.p_tg != dt_st.Rows[0]["tg"].ToString())
                {
                    //已修改
                    struct_xzt.p_czxx += "试题题干：【" + dt_st.Rows[0]["tg"].ToString() + "】->【" + struct_xzt.p_tg + "】";
                    check_rz = 1;
                }
                //选项
                Struct_XZT_XX struct_xzt_xx=new Struct_XZT_XX();
                struct_xzt_xx.p_st_id=Convert.ToInt64(dt_st.Rows[0]["id"].ToString());
                struct_xzt_xx.p_czfs="02";
                for (int i = 0; i < TotalControls; i++)
                {
                    if (xxStrs[i] != dt_xx.Rows[i]["xxnr"].ToString())
                    {
                        //已修改
                        struct_xzt_xx.p_id = Convert.ToInt64(dt_xx.Rows[i]["id"]);
                        struct_xzt_xx.p_xx = dt_xx.Rows[i]["xx"].ToString();
                        struct_xzt_xx.p_xxnr = xxStrs[i];
                        struct_xzt.p_czxx += "试题选项：" + dt_xx.Rows[i]["xx"].ToString() + " . 【" + dt_xx.Rows[i]["xxnr"].ToString() + "】->【" + xxStrs[i] + "】";
                        struct_xzt_xx.p_czxx = "位置：在线培训->试题管理->试题编辑  选择题选项编辑  描述：";
                        xzt.Update_XZT_XX(struct_xzt_xx);
                        check_rz = 1;
                    }
                }
                //答案
                if (struct_xzt.p_da != dt_st.Rows[0]["da"].ToString())
                {
                    //已修改
                    struct_xzt.p_czxx += "试题答案：【" + dt_st.Rows[0]["da"].ToString() + "】->【" + struct_xzt.p_da + "】";
                    check_rz = 1;
                }
                //试题难度
                if (struct_xzt.p_nd != dt_st.Rows[0]["nd"].ToString())
                {
                    //已修改
                    struct_xzt.p_czxx += "试题难度：【" + dt_st.Rows[0]["nd"].ToString() + "】->【" + struct_xzt.p_nd + "】";
                    check_rz = 1;
                }
                //适用科目
                if (struct_xzt.p_km != dt_st.Rows[0]["km"].ToString())
                {
                    //已修改
                    struct_xzt.p_czxx += "适用科目：【" + dt_st.Rows[0]["km"].ToString() + "】->【" + struct_xzt.p_km + "】";
                    check_rz = 1;
                }
                //适用类别
                if (struct_xzt.p_lb != dt_st.Rows[0]["lb"].ToString())
                {
                    //已修改
                    struct_xzt.p_czxx += "类别：【" + dt_st.Rows[0]["lb"].ToString() + "】->【" + struct_xzt.p_lb + "】";
                    check_rz = 1;
                }
                //适用岗位
                if (struct_xzt.p_gw != dt_st.Rows[0]["gw"].ToString())
                {
                    //已修改
                    struct_xzt.p_czxx += "适用岗位：【" + dt_st.Rows[0]["gw"].ToString() + "】->【" + struct_xzt.p_gw + "】";
                    check_rz = 1;
                }
                //考察知识点
                if (struct_xzt.p_kczsd != dt_st.Rows[0]["kczsd"].ToString())
                {
                    //已修改
                    struct_xzt.p_czxx += "考察知识点：【" + dt_st.Rows[0]["kczsd"].ToString() + "】->【" + struct_xzt.p_kczsd + "】";
                    check_rz = 1;
                }
                if (check_rz == 0)
                {
                    struct_xzt.p_czxx += "未修改";
                }
                xzt.Update_XZT(struct_xzt);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
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
    }
}