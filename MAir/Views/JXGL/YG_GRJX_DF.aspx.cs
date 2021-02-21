using CUST;
using CUST.MKG;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MAir.Views.JXGL
{
    public partial class YG_GRJX_DF : System.Web.UI.Page
    {
        private UserState _usState;
        public bool flag = true;
        public int i = 0;
        private GRJX grjx;
        private PCX pcx;
        private Struct_GRJX struct_grjx;
        public string ygbh, xm, bm, gw, zfabh, pcfabh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            grjx = new GRJX(_usState);
            pcx = new PCX(_usState);
            struct_grjx = new Struct_GRJX();
            ygbh = Request.QueryString.Get("ygbh").ToString();//由总分页面，点击添加跳转而来  
            xm = Request.QueryString.Get("xm").ToString();
            bm = Request.QueryString.Get("bm").ToString();
            gw = Request.QueryString.Get("gw").ToString();
            zfabh = Request.QueryString.Get("zfabh").ToString();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
            }
        }
        private void bind_Main()
        {
            lbl_ygbh.Text = ygbh;
            hlnk_xm.Text = xm;
            lbl_bmdm.Text = bm;
            lbl_gwdm.Text = gw;
            zfabh = ddlt_zfa.SelectedValue;
            DataTable dt = grjx.Select_GRJX_PCFA_DF_ByBh(ygbh, zfabh);
            this.dlt_pcfa.DataSource = dt.DefaultView;
            this.dlt_pcfa.DataBind();
        }
        private void Binding()
        {
            pcfabh = this.ddlt_pcfa.SelectedValue;
            zfabh = ddlt_zfa.SelectedValue;
            //评测项联动
            DataTable dtpcx = pcx.Select_PCFA_Detail(zfabh, pcfabh, ygbh).Tables[0];//根据pcfabh查询评测方案详情（指标，权重，评测项）
            foreach (DataRow dr in dtpcx.Rows)
            {
                lbl_pcfaqz.Text = dr["PCFAQZ"].ToString();
            }
            //绑定数据源
            this.dlt_pcx.DataSource = dtpcx.DefaultView;
            this.dlt_pcx.DataBind();
        }
        protected void ddltBind()
        {
            //获取员工编号
            ygbh = Request.Params["ygbh"].ToString();//员工编号
            zfabh = Request.Params["zfabh"].ToString(); //总方案编号
            //查询已有的总方案
            DataTable dtt = new DataTable();

            dtt = grjx.Select_YYZFA_BYBH(ygbh, zfabh);
            ddlt_zfa.DataSource = dtt;
            ddlt_zfa.DataTextField = "zfamc";
            ddlt_zfa.DataValueField = "zfabh";
            ddlt_zfa.DataBind();

            //员工已有总方案下的评测方案
            zfabh = ddlt_zfa.SelectedValue;
            ddlt_pcfa.DataSource = grjx.Select_GRJX_PCFA_ByZFA(zfabh);
            ddlt_pcfa.DataTextField = "pcfamc";
            ddlt_pcfa.DataValueField = "pcfabh";
            ddlt_pcfa.DataBind();
            ddlt_pcfa.Items.Insert(0, new ListItem("请选择", "-1"));
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
        //该员工没有评测方案时，给员工添加评测方案
        protected void btn_save_Click(object sender, EventArgs e)
        {
            //传入员工信息
            Response.Redirect("../JXGL/YG_ZFA_Add.aspx?ygbh=" + ygbh, true);
        }
        //总方案下拉框
        protected void ddlt_zfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择总方案关联出该员工的该总方案下的所有评测方案以及得分
            //员工已有总方案下的评测方案
            zfabh = ddlt_zfa.SelectedValue;
            ddlt_pcfa.DataSource = grjx.Select_GRJX_PCFA_ByZFA(zfabh);
            ddlt_pcfa.DataTextField = "pcfamc";
            ddlt_pcfa.DataValueField = "pcfabh";
            ddlt_pcfa.DataBind();
            ddlt_pcfa.Items.Insert(0, new ListItem("请选择", "-1"));
            bind_Main();

        }
        protected void ddlt_pcfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            zfabh = ddlt_zfa.SelectedValue;
            pcfabh = this.ddlt_pcfa.SelectedValue;
            //评测项联动
            DataTable dtpcx = pcx.Select_PCFA_Detail(zfabh, pcfabh, ygbh).Tables[0];//根据pcfabh查询评测方案详情（指标，权重，评测项）
            foreach (DataRow dr in dtpcx.Rows)
            {
                lbl_pcfaqz.Text = dr["PCFAQZ"].ToString();
            }
            //绑定数据源
            this.dlt_pcx.DataSource = dtpcx.DefaultView;
            this.dlt_pcx.DataBind();
        }

        protected void dlt_pcx_EditCommand(object source, DataListCommandEventArgs e)
        {
            dlt_pcx.EditItemIndex = e.Item.ItemIndex;
            Binding();
        }

        protected void dlt_pcx_CancelCommand(object source, DataListCommandEventArgs e)
        {
            dlt_pcx.EditItemIndex = -1;
            Binding();
        }

        protected void dlt_pcx_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            //int id = Convert.ToInt32(dlt_pcx.DataKeys[e.Item.ItemIndex].ToString());

            struct_grjx.p_ygbh = ygbh;
            struct_grjx.p_pcfabh = ddlt_pcfa.SelectedValue;
            Label lbl_pcxbh = ((System.Web.UI.WebControls.Label)dlt_pcx.Items[e.Item.ItemIndex].FindControl("lbl_pcxbh"));
            struct_grjx.p_pcxbh = lbl_pcxbh.Text.ToString();
            TextBox tbx_jxzbms = ((System.Web.UI.WebControls.TextBox)dlt_pcx.Items[e.Item.ItemIndex].FindControl("tbx_jxzbms"));
            struct_grjx.p_zbms = tbx_jxzbms.Text.ToString();
            TextBox tbx_grdf = ((System.Web.UI.WebControls.TextBox)dlt_pcx.Items[e.Item.ItemIndex].FindControl("tbx_pcxdf"));
            struct_grjx.p_grdf = Convert.ToDouble(tbx_grdf.Text.ToString());
            double grdf = Convert.ToDouble(struct_grjx.p_grdf);
            string dfrq = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);
            struct_grjx.p_dfrq = dfrq;//打分日期获取系统时间 
            Label lbl_pcxqz = ((System.Web.UI.WebControls.Label)dlt_pcx.Items[e.Item.ItemIndex].FindControl("lbl_pcxqz"));
            struct_grjx.p_zfabh = ddlt_zfa.SelectedValue;//获取总方案编号
            double sum = 0;
            if (tbx_grdf.Text.ToString() == "" || tbx_grdf.Text.ToString() == null)
            {
                Response.Write("<script>alert('打分不能为空！')</script>");
            }
            else if(grdf >= 0 && grdf <= 100)
                {
                    //grjx.Update_GRJX_Pro(struct_grjx);//更改GRJX表，更改评测项单项打的分
                    //评测项单项得分更改成功之后，计算总分，将评测方案的总分也进行更改，进而将个人绩效的总分也进行更改。
                    foreach (DataListItem li in dlt_pcx.Items)
                    {
                        sum = sum + Convert.ToDouble(tbx_grdf.Text.ToString()) * Convert.ToDouble(lbl_pcxqz.Text.ToString());
                    }
                    struct_grjx.p_pcfadf = sum;//评测方案得分(作为总方案加权之前的分)
                    //grjx.Update_GRJX_DF(struct_grjx);//更改GRJX_PCFA_DF表，更改评测方案单方案得的总分
                    struct_grjx.p_zfabh = ddlt_zfa.SelectedValue;
                    grjx.Update_GRJX_Pro(struct_grjx);//更改GRJX表，更改评测项打分和指标描述
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"更改成功！\")</script>");
                }
                else
                {
                    Response.Write("<script>alert('打分应该为0~100之间的整数')</script>");
                }
            dlt_pcx.EditItemIndex = -1;
            Binding();
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/GRJXZF.aspx", true);
        }

    }
}