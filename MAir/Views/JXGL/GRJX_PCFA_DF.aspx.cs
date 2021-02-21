using CUST;
using CUST.MKG;
using CUST.Tools;
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
    public partial class GRJX_PCFA_DF : System.Web.UI.Page
    {
        private UserState _usState;
        public bool flag = true;
        public int i = 0;
        private GRJX grjx;
        private PCX pcx;
        private Struct_GRJX struct_grjx;
        public string ygbh, pcfabh,xm, bm, gw;
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
            pcfabh = Request.QueryString.Get("pcfabh").ToString();
            xm = Request.QueryString.Get("xm").ToString();
            bm = Request.QueryString.Get("bm").ToString();
            gw = Request.QueryString.Get("gw").ToString();
            if (!IsPostBack)
            {
                bind_Main();
            }
        }
        private void bind_Main()
        {
            
            DataTable dtpcx = pcx.Select_PCFA_Detail("",pcfabh,ygbh).Tables[0];//根据pcfabh查询评测方案详情（指标，权重，评测项）
            foreach (DataRow dr in dtpcx.Rows)
            {
                lbl_pcfaqz.Text = dr["PCFAQZ"].ToString();
            }
            //绑定数据源
            this.dlt_pcx.DataSource = dtpcx.DefaultView;
            this.dlt_pcx.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_grjx.p_ygbh = ygbh;
            struct_grjx.p_pcfabh = pcfabh;
            double sum = 0;
            struct_grjx.p_dfrq = DateTime.Now.ToLocalTime().ToString();        //获取系统时间
            try
            {
                foreach (DataListItem li in dlt_pcx.Items)
                {
                    TextBox tbx_pcxdf = (TextBox)li.FindControl("tbx_pcxdf");
                    Label lbl_pcxbh = (Label)li.FindControl("lbl_pcxbh");
                    Label lbl_pcxqz = (Label)li.FindControl("lbl_pcxqz");
                    TextBox tbx_pcxzbms = (System.Web.UI.WebControls.TextBox)li.FindControl("tbx_pcxzbms");//评测项指标描述

                    if (Convert.ToInt32(tbx_pcxdf.Text) >= 0 && (Convert.ToInt32(tbx_pcxdf.Text)) <= 100)
                    {
                        sum = sum + Convert.ToInt32(lbl_pcxqz.Text) * Convert.ToInt32(tbx_pcxdf.Text);
                        
                        struct_grjx.p_pcxbh = lbl_pcxbh.Text.ToString().Trim();
                        struct_grjx.p_zbms = tbx_pcxzbms.Text.ToString().Trim();
                        struct_grjx.p_grdf = Convert.ToDouble(tbx_pcxdf.Text.ToString().Trim());//个人得分是打的分，个人得分*权重=单项得分（pcx）
                        //循环插入Datalist有几行插几次到,将每一个评测项插入到GRJX表中
                        grjx.Insert_GRJX_Pro(struct_grjx);
                    }
                    else
                    {
                        Response.Write("<script>alert('评测项打分应为0~100之间的整数')</script>");
                        break;
                    }
                   
                }
                //struct_grjx.p_pcfadf = sum;
                //struct_grjx.p_pcfaqz = lbl_pcfaqz.Text.ToString().Trim();
                //struct_grjx.p_pcfazbms = "";

                //计算出评测方案总分，插入到Grjx_Pcfa_Df表中
                //grjx.Insert_GRJX_PCFA_DF(struct_grjx);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
            }
            catch (Exception em)
            {
                throw em;
            }
        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;
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
    }
}