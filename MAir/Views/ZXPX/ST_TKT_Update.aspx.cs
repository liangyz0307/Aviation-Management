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
    public partial class ST_TKT_Update : System.Web.UI.Page
    {
        private UserState _usState;
        private TKT tkt;
        private Struct_TKT struct_tkt;
        protected int TotalControls;
        private DataTable dt_st;
        private long st_id;
        private string[] tgs;
        private string[] das;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            tkt = new TKT(_usState);
            st_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
            dt_st = tkt.Select_TKT_Detail(st_id);
            tgs = dt_st.Rows[0]["tg"].ToString().Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
            das = dt_st.Rows[0]["da"].ToString().Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
            TotalControls = das.Length;
            if (!IsPostBack)
            {
                Data_Bind();
            }
            for (int i = 0; i < TotalControls; i++)
            {
                DymanicallyGenerateTGTK(i + 1);
            }
        }
        #region 数据绑定
        protected void Data_Bind()
        {
            dt_st = tkt.Select_TKT_Detail(st_id);
            das = dt_st.Rows[0]["da"].ToString().Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
            TotalControls = das.Length;
            tbx_tg.Text = dt_st.Rows[0]["tg"].ToString();
            //试题难度
            ddlt_stnd.DataTextField = "mc";
            ddlt_stnd.DataValueField = "bm";
            ddlt_stnd.DataSource = SysData.STND().Copy();
            ddlt_stnd.DataBind();
            ddlt_stnd.SelectedValue = dt_st.Rows[0]["nd"].ToString();
            //科目
            ddlt_km.DataTextField = "mc";
            ddlt_km.DataValueField = "bm";
            ddlt_km.DataSource = SysData.KM().Copy();
            ddlt_km.DataBind();
            ddlt_km.SelectedValue = dt_st.Rows[0]["km"].ToString();
            //类别
            ddlt_stlb.DataTextField = "mc";
            ddlt_stlb.DataValueField = "bm";
            ddlt_stlb.DataSource = SysData.STLB().Copy();
            ddlt_stlb.DataBind();
            ddlt_stlb.SelectedValue = dt_st.Rows[0]["lb"].ToString();
            //岗位
            cbxl_gw.DataTextField = "mc";
            cbxl_gw.DataValueField = "bm";
            cbxl_gw.DataSource = SysData.GW().Copy();
            cbxl_gw.DataBind();
            string str_gw = dt_st.Rows[0]["gw"].ToString();
            string[] arr_gw = str_gw.Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr_gw.Length; i++)
            {
                cbxl_gw.Items.FindByValue(arr_gw[i]).Selected = true;
            }
            tbx_kczsd.Text = dt_st.Rows[0]["kczsd"].ToString();
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
            //tbx_tg.Text = tgs[totalControls];
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
            tbx_da.Text = das[totalControls - 1];
            tbx_da.CssClass = "";
            tbx_da.Width = 200;
            tbx_da.Height = 30;
            this.ph_da.Controls.Add(tbx_da);
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
                struct_tkt.p_id = st_id;
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
                struct_tkt.p_sfqy = dt_st.Rows[0]["sfqy"].ToString();
                struct_tkt.p_czfs = "02";
                int check_rz = 0;
                struct_tkt.p_czxx = "位置：在线培训->试题管理->试题编辑  填空题题编辑 试题ID：[" + struct_tkt.p_id + "]  描述：";
                //试题题干
                if (struct_tkt.p_tg != dt_st.Rows[0]["tg"].ToString())
                {
                    //已修改
                    check_rz = 1;
                }
                //答案
                if (struct_tkt.p_da != dt_st.Rows[0]["da"].ToString())
                {
                    //已修改
                    struct_tkt.p_czxx += "试题答案：【" + dt_st.Rows[0]["da"].ToString() + "】->【" + struct_tkt.p_da + "】";
                    check_rz = 1;
                }
                //试题难度
                if (struct_tkt.p_nd != dt_st.Rows[0]["nd"].ToString())
                {
                    //已修改
                    struct_tkt.p_czxx += "试题难度：【" + dt_st.Rows[0]["nd"].ToString() + "】->【" + struct_tkt.p_nd + "】";
                    check_rz = 1;
                }
                //适用科目
                if (struct_tkt.p_km != dt_st.Rows[0]["km"].ToString())
                {
                    //已修改
                    struct_tkt.p_czxx += "适用科目：【" + dt_st.Rows[0]["km"].ToString() + "】->【" + struct_tkt.p_km + "】";
                    check_rz = 1;
                }
                //适用类别
                if (struct_tkt.p_lb != dt_st.Rows[0]["lb"].ToString())
                {
                    //已修改
                    struct_tkt.p_czxx += "类别：【" + dt_st.Rows[0]["lb"].ToString() + "】->【" + struct_tkt.p_lb + "】";
                    check_rz = 1;
                }
                //适用岗位
                if (struct_tkt.p_gw != dt_st.Rows[0]["gw"].ToString())
                {
                    //已修改
                    struct_tkt.p_czxx += "适用岗位：【" + dt_st.Rows[0]["gw"].ToString() + "】->【" + struct_tkt.p_gw + "】";
                    check_rz = 1;
                }
                //考察知识点
                if (struct_tkt.p_kczsd != dt_st.Rows[0]["kczsd"].ToString())
                {
                    //已修改
                    struct_tkt.p_czxx += "考察知识点：【" + dt_st.Rows[0]["kczsd"].ToString() + "】->【" + struct_tkt.p_kczsd + "】";
                    check_rz = 1;
                }
                if (check_rz == 0)
                {
                    struct_tkt.p_czxx += "未修改";
                }
                tkt.Update_TKT(struct_tkt);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！\")</script>");
                Data_Bind();
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