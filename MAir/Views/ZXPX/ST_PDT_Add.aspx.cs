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
    public partial class ST_PDT_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private PDT pdt;
        private Struct_PDT struct_pdt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            pdt = new PDT(_usState);
            if (!IsPostBack)
            {
                ddltBind();
            }
        }
        #region 数据绑定
        protected void ddltBind()
        {
            ddlt_da.Items.Insert(0, new ListItem("请选择", "-1"));
            ddlt_da.Items.Insert(1, new ListItem("正确", "1"));
            ddlt_da.Items.Insert(2, new ListItem("错误", "0"));
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
            //答案
            string da = ddlt_da.SelectedValue.ToString().Trim();
            if(da=="-1")
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
                struct_pdt = new Struct_PDT();
                struct_pdt.p_tg = tg;
                struct_pdt.p_da = da;
                struct_pdt.p_lj = "";
                struct_pdt.p_sfytp = "";
                struct_pdt.p_nd = nd;
                struct_pdt.p_km = km;
                struct_pdt.p_lb = st_lb;
                struct_pdt.p_gw = str_gw;
                struct_pdt.p_kczsd = kczsd;
                struct_pdt.p_czfs = "01";
                struct_pdt.p_czxx = "位置：在线培训->试题管理->试题添加  判断题  试题题干：" + struct_pdt.p_tg +
                    " 试题答案：" + struct_pdt.p_da + "试题难度：" + struct_pdt.p_nd + " 适用科目：" + struct_pdt.p_km +
                    "适用岗位：" + struct_pdt.p_gw + " 考察知识点：" + struct_pdt.p_kczsd;
                pdt.Insert_PDT(struct_pdt);
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
            tbx_kczsd.Text = "";
            lbl_tg.Text = "";
            lbl_da.Text = "";
            lbl_nd.Text = "";
            lbl_km.Text = "";
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
    }
}