using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MAir.Views.JXGL
{
    public partial class GRJX_PCFA_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private GRJX grjx;
        private Struct_GRJX struct_grjx;
        public string ygbh,xm,bm, gw,pcfabh;
       
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
            ygbh = Request.QueryString.Get("ygbh").ToString();
            pcfabh = Request.QueryString.Get("pcfabh").ToString();
            xm = Request.QueryString.Get("xm").ToString();
            bm = Request.QueryString.Get("bm").ToString();
            gw = Request.QueryString.Get("gw").ToString();
            if (!IsPostBack)
            {
                BindList();
            }
        }
        private void BindList()
        {
            lbl_ygbh.Text = ygbh;
            hlnk_xm.Text = xm;
            lbl_bmdm.Text = bm;
            lbl_gwdm.Text = gw;

            DataTable dt = grjx.Select_GRJX_Detail(ygbh).Tables[0];
            this.dlt_pcx_grdf.DataSource = dt.DefaultView;
            this.dlt_pcx_grdf.DataBind();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            BindList();
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
            TextBox tbx_jxzbms = ((System.Web.UI.WebControls.TextBox)dlt_pcx_grdf.Items[e.Item.ItemIndex].FindControl("tbx_jxzbms"));
            TextBox tbx_grdf = ((System.Web.UI.WebControls.TextBox)dlt_pcx_grdf.Items[e.Item.ItemIndex].FindControl("tbx_grdf"));
            Label lbl_pcxqz = ((System.Web.UI.WebControls.Label)dlt_pcx_grdf.Items[e.Item.ItemIndex].FindControl("lbl_qz"));
            struct_grjx.p_ygbh = ygbh;
            struct_grjx.p_pcxbh = lbl_pcxbh.Text.ToString();
            struct_grjx.p_zbms = tbx_jxzbms.Text.ToString();
            struct_grjx.p_grdf = Convert.ToDouble(tbx_grdf.Text.ToString());
            double grdf = Convert.ToDouble(struct_grjx.p_grdf);
            struct_grjx.p_pcfabh = pcfabh;
            string dfrq = DateTime.Now.ToLocalTime().ToString();
            struct_grjx.p_dfrq = dfrq;//打分日期获取系统时间 
            double sum=0;
            if (grdf > 0 && grdf < 100)
            {
                grjx.Update_GRJX_Pro(struct_grjx);//更改GRJX表，更改评测项单项打的分
                //评测项单项得分更改成功之后，计算总分，将评测方案的总分也进行更改，进而将个人绩效的总分也进行更改。
                foreach (DataListItem li in dlt_pcx_grdf.Items)
                {
                    sum = sum + Convert.ToDouble(tbx_grdf.Text.ToString()) * Convert.ToDouble(lbl_pcxqz.Text.ToString());
                }
                struct_grjx.p_pcfadf = sum;
                grjx.Update_GRJX_DF(struct_grjx);//更改GRJX_PCFA_DF表，更改评测方案单方案得的总分
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"更改成功！\")</script>");
            }
            else
            {
                Response.Write("<script>alert('打分应该为0~100之间的整数')</script>");
            }
            BindList();
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("GRJXGL.aspx?ygbh=" + ygbh + "&" + "xm=" + xm + "&" + "bm=" + bm + "&" + "gw=" + gw, true);
        }
    }
}