using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.JXGL
{
    public partial class BMJX_PCFA_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private GRJX grjx;
        public string bmdm, bmmc, pcfabh, pcfamc;
        private Struct_GRJX struct_grjx;
        public int cpage;
        public int psize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_YG_LL;
            psize = _usState.C_YG_LL;
            grjx = new GRJX(_usState);
            struct_grjx = new Struct_GRJX();
            bmdm = Request.QueryString.Get("bmdm").ToString();
            pcfabh = Request.QueryString.Get("pcfabh").ToString();
            bmmc = Request.QueryString.Get("bmmc").ToString();
            pcfamc = Request.QueryString.Get("pcfamc").ToString();
            if (!IsPostBack)
            {
                BindList();
            }
        }
        private void BindList()
        {
            lbl_bmdm.Text = bmdm;
            lbl_bmmc.Text = bmmc;
            lbl_pcfabh.Text = pcfabh;
            lbl_pcfamc.Text = pcfamc;

            //查询该部门名下的已有评测方案
            DataTable dt = grjx.Select_BMJX_PCFA_DF(bmdm, pcfabh).Tables[0];
            dt.Columns.Add("bmmc");//该方案最终得分（打分*权重）
            foreach (DataRow dr in dt.Rows)
            {
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门名称
            }
            //绑定分页数据源  
            this.dlt_pcx_grdf.DataSource = dt.DefaultView;
            this.dlt_pcx_grdf.DataBind();
        }

        protected void dlt_pcx_grdf_CancelCommand(object source, DataListCommandEventArgs e)
        {
            dlt_pcx_grdf.EditItemIndex = -1;
            BindList();
        }

        protected void dlt_pcx_grdf_EditCommand(object source, DataListCommandEventArgs e)
        {
            dlt_pcx_grdf.EditItemIndex = e.Item.ItemIndex;
            BindList();
        }

        protected void dlt_pcx_grdf_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            int id = Convert.ToInt32(dlt_pcx_grdf.DataKeys[e.Item.ItemIndex].ToString());
            Label lbl_pcxbh = ((System.Web.UI.WebControls.Label)dlt_pcx_grdf.Items[e.Item.ItemIndex].FindControl("lbl_pcxbh"));
            Label lbl_pcxmc = ((System.Web.UI.WebControls.Label)dlt_pcx_grdf.Items[e.Item.ItemIndex].FindControl("lbl_pcxmc"));
            TextBox tbx_pcxdf = ((System.Web.UI.WebControls.TextBox)dlt_pcx_grdf.Items[e.Item.ItemIndex].FindControl("tbx_pcxdf"));
            TextBox tbx_pcxzbms = ((System.Web.UI.WebControls.TextBox)dlt_pcx_grdf.Items[e.Item.ItemIndex].FindControl("tbx_pcxzbms"));

            struct_grjx.p_bmdm = bmdm;//部门代码
            struct_grjx.p_pcfabh = pcfabh;//评测方案编号
            struct_grjx.p_pcxbh = lbl_pcxbh.Text.ToString().Trim();//评测项编号
            struct_grjx.p_pcxdf = Convert.ToDouble(tbx_pcxdf.Text.ToString().Trim());//评测项打分
            struct_grjx.p_zbms = tbx_pcxzbms.Text.ToString().Trim();//指标描述
            //struct_grjx.p_zt = "状态";//状态
            //struct_grjx.p_bhyy = "驳回原因";//驳回原因
            string dfrq = DateTime.Now.ToLocalTime().ToString();//打分日期
            struct_grjx.p_dfrq = dfrq;//打分日期获取系统时间 
            // double sum = 0;
            if (tbx_pcxdf.Text.ToString().Trim() == " ")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请给评测项打分！\")</script>");
            }
            else if (struct_grjx.p_pcxdf > 0 && struct_grjx.p_pcxdf < 100)
            {
                grjx.Update_BMJX_Pro(struct_grjx); //更改BMJX表，更改评测项单项打的分
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"更改成功！\")</script>");
            }
            else
            {
                Response.Write("<script>alert('打分应该为0~100之间的整数')</script>");
            }
            BindList();

        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            BindList();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMJXGL.aspx", true);
        }
    }
}