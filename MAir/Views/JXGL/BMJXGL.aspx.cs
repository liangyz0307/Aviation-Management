using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.JXGL
{
    public partial class BMJXGL : System.Web.UI.Page
    {
        private UserState _usState;
        private GRJX grjx;
        private Struct_GRJX struct_grjx;
        private PCFA pcfa;
        private PCX pcx;
        public string bmdm,bmmc,zfabh,pcfabh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            grjx = new GRJX(_usState);
            pcfa = new PCFA(_usState);
            pcx = new PCX(_usState);
            struct_grjx = new Struct_GRJX();
            bmdm = Request.QueryString.Get("bmdm").ToString();
            bmmc = Request.QueryString.Get("bmmc").ToString();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
            }
        }
        //绑定评测方案下拉框和权重label和评测项信息列表
        private void Binding()
        {
            pcfabh = this.ddlt_pcfa.SelectedValue;
            zfabh = ddlt_zfa.SelectedValue;
            //评测项联动
            DataTable dtpcx = pcx.Select_BMPCFA_Detail(zfabh, pcfabh, bmdm).Tables[0];//根据pcfabh查询评测方案详情（指标，权重，评测项）
            foreach (DataRow dr in dtpcx.Rows)
            {
                lbl_pcfaqz.Text = dr["PCFAQZ"].ToString();
            }
            //绑定数据源
            this.dlt_pcx.DataSource = dtpcx.DefaultView;
            this.dlt_pcx.DataBind();
        }
        //绑定总方案下拉框
        protected void ddltBind()
        {
            //接收部门代码（编号）
            bmdm = Request.Params["bmdm"].ToString();

            //查询该部门名下已有的总方案
            ddlt_zfa.DataSource = pcfa.Select_BMZFA_BYBH(bmdm);
            ddlt_zfa.DataTextField = "zfamc";
            ddlt_zfa.DataValueField = "zfabh";
            ddlt_zfa.DataBind();

            //所选择的该总方案下的评测方案
            zfabh = ddlt_zfa.SelectedValue;
            ddlt_pcfa.DataSource = pcfa.Select_BMJX_PCFA_ByZFA(zfabh);
            ddlt_pcfa.DataTextField = "pcfamc";
            ddlt_pcfa.DataValueField = "pcfabh";
            ddlt_pcfa.DataBind();
            ddlt_pcfa.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        //绑定初始值label控件和评测方案总分
        private void bind_Main()
        {
            lbl_bmdm.Text = bmdm;
            lbl_bmmc.Text = bmmc;
            zfabh = ddlt_zfa.SelectedValue;
            DataTable dt = grjx.Select_BMJX_PCFA_DF_ByBh(bmdm, zfabh);
            this.dlt_pcfa.DataSource = dt.DefaultView;
            this.dlt_pcfa.DataBind();
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BM_PCFA_ADD.aspx", true);
        }

        protected void dlt_pcx_CancelCommand(object source, DataListCommandEventArgs e)
        {
            dlt_pcx.EditItemIndex = -1;
            Binding();
        }

        protected void dlt_pcx_EditCommand(object source, DataListCommandEventArgs e)
        {
            dlt_pcx.EditItemIndex = e.Item.ItemIndex;
            Binding();
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMJXZF.aspx?", true);
        }

        protected void dlt_pcx_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            struct_grjx.p_bmdm = bmdm;
            struct_grjx.p_pcfabh = ddlt_pcfa.SelectedValue;
            Label lbl_pcxbh = ((System.Web.UI.WebControls.Label)dlt_pcx.Items[e.Item.ItemIndex].FindControl("lbl_pcxbh"));
            struct_grjx.p_pcxbh = lbl_pcxbh.Text.ToString();
            TextBox tbx_jxzbms = ((System.Web.UI.WebControls.TextBox)dlt_pcx.Items[e.Item.ItemIndex].FindControl("tbx_jxzbms"));
            struct_grjx.p_zbms = tbx_jxzbms.Text.ToString();
            TextBox tbx_pcxdf = ((System.Web.UI.WebControls.TextBox)dlt_pcx.Items[e.Item.ItemIndex].FindControl("tbx_pcxdf"));
            struct_grjx.p_pcxdf = Convert.ToDouble(tbx_pcxdf.Text.ToString());
            double pcxdf = Convert.ToDouble(struct_grjx.p_pcxdf);
            string dfrq = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);
            struct_grjx.p_dfrq = dfrq;//打分日期获取系统时间 
            Label lbl_pcxqz = ((System.Web.UI.WebControls.Label)dlt_pcx.Items[e.Item.ItemIndex].FindControl("lbl_pcxqz"));
            struct_grjx.p_zfabh = ddlt_zfa.SelectedValue;//获取总方案编号
            double sum = 0;
            if (tbx_pcxdf.Text.ToString() == "" || tbx_pcxdf.Text.ToString() == null)
            {
                Response.Write("<script>alert('打分不能为空！')</script>");
            }
            else
                if (pcxdf >= 0 && pcxdf <= 100)
                {
                    //评测项单项得分更改成功之后，计算总分，将评测方案的总分也进行更改，进而将个人绩效的总分也进行更改。
                    foreach (DataListItem li in dlt_pcx.Items)
                    {
                        sum = sum + Convert.ToDouble(tbx_pcxdf.Text.ToString()) * Convert.ToDouble(lbl_pcxqz.Text.ToString());
                    }
                    struct_grjx.p_pcfadf = sum;//评测方案得分(作为总方案加权之前的分)
                    struct_grjx.p_zfabh = ddlt_zfa.SelectedValue;
                    grjx.Update_BMJX_Pro(struct_grjx);//更改BMJX表，更改评测项打分和指标描述
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"更改成功！\")</script>");
                }
                else
                {
                    Response.Write("<script>alert('打分应该为0~100之间的整数')</script>");
                }
            dlt_pcx.EditItemIndex = -1;
            Binding();
        }

        protected void ddlt_zfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择了总方案，关联出下面的评测方案下拉框
            zfabh = ddlt_zfa.SelectedValue;
            DataTable dtt = grjx.Select_BMJX_PCFA_ByZFA(zfabh); 
            ddlt_pcfa.DataSource = dtt; 
            ddlt_pcfa.DataTextField = "pcfamc";
            ddlt_pcfa.DataValueField = "pcfabh";
            ddlt_pcfa.DataBind();
            ddlt_pcfa.Items.Insert(0, new ListItem("请选择", "-1"));
         
            bind_Main();
        }

        protected void ddlt_pcfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择评测方案，关联下面的datalist评测方案详细信息
            zfabh = ddlt_zfa.SelectedValue;
            pcfabh = this.ddlt_pcfa.SelectedValue;
            //评测项联动
            DataTable dtpcx = pcx.Select_BMPCFA_Detail(zfabh, pcfabh, bmdm).Tables[0];//根据pcfabh查询评测方案详情（指标，权重，评测项）
            foreach (DataRow dr in dtpcx.Rows)
            {
                lbl_pcfaqz.Text = dr["PCFAQZ"].ToString();
            }
            //绑定数据源
            this.dlt_pcx.DataSource = dtpcx.DefaultView;
            this.dlt_pcx.DataBind();
        }
    }
}