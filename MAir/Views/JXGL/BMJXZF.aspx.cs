using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BMJXZF : System.Web.UI.Page
    {
        private UserState _usState;
        private GRJX grjx;
        private Struct_GRJX struct_grjx;
        private PCFA pcfa;
        private Struct_PCFA struct_pcfa;
        public string zfabh, zfamc;
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
            pcfa = new PCFA(_usState);
            struct_pcfa = new Struct_PCFA();
            zfabh = ddlt_zfa.SelectedValue;//总方案编号
            zfamc = ddlt_zfa.Text;//总方案名称
            if (!IsPostBack)
            {
                ddltBind();
                bind();
            }
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        private void ddltBind()
        {
            struct_pcfa.p_currentpage = 1;
            struct_pcfa.p_pagesize = 999999;
            //总方案
            ddlt_zfa.DataSource = pcfa.Select_BMZFA(struct_pcfa).Tables[0];//查询部门总方案表中的总方案
            ddlt_zfa.DataTextField = "zfamc";
            ddlt_zfa.DataValueField = "zfabh";
            ddlt_zfa.DataBind();
            ddlt_zfa.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind()
        {
            struct_grjx.p_zfabh = ddlt_zfa.SelectedValue.ToString().Trim();//总方案编号
            int count=grjx.Select_BM_Count();
            struct_grjx.p_currentpage = pg_fy.CurrentPage;
            struct_grjx.p_pagesize = pg_fy.NumPerPage;
            pg_fy.TotalRecord = count;
            DataTable dt = grjx.Select_BMJXZF(struct_grjx).Tables[0];
            dt.Columns.Add("bmmc");
            dt.Columns.Add("zfabh");
            dt.Columns.Add("ylpj");//优良评价
             foreach (DataRow dr in dt.Rows)
            {
                if (dr["zszt"].ToString().Equals("") || dr["zszt"].ToString().Equals("0") || dr["zszt"].ToString().Equals(null))
                {
                    dr["zszt"] = "未公示";
                    //lbl_zt.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    dr["zszt"] = "已公示";
                    //lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门名称
                dr["zfabh"] = ddlt_zfa.SelectedValue;
                if (dr["ZF"].ToString().Equals(""))
                { dr["ylpj"] = "待添加"; }
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 90) || Convert.ToDouble(dr["ZF"].ToString()) == 90)
                { dr["ylpj"] = "优"; }
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 80) || Convert.ToDouble(dr["ZF"].ToString()) == 80)
                { dr["ylpj"] = "良"; }
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 70) || Convert.ToDouble(dr["ZF"].ToString()) == 70)
                { dr["ylpj"] = "中"; }
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 60) || Convert.ToDouble(dr["ZF"].ToString()) == 60)
                { dr["ylpj"] = "及格"; }
                else { dr["ylpj"] = "不及格"; }
             }
             this.Repeater1.DataSource = dt.DefaultView;
             this.Repeater1.DataBind();
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[3];
            content = e.CommandArgument.ToString().Split('&');
            string bmdm = content[0];
            string bmmc=content[1];
            string zf = content[2];
            if (e.CommandName == "Add")
            {
                Response.Redirect("../JXGL/BMJXGL.aspx?bmdm=" + bmdm+"&"+"bmmc="+bmmc+"&"+"zfabh="+zfabh, true);
            }
            else if (e.CommandName == "ZS")
            {
                if (ddlt_zfa.SelectedValue.Equals("-1"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请先选择总方案！\")</script>");
                    return;

                }
                else
                {
                    if (zf.Equals("") || zf.Equals(null))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请先打分，再公示！\")</script>");
                        return;
                    }
                    else
                    {
                        grjx.Update_BMJX_ZS(bmdm, zfabh, "1");
                        grjx.Insert_BMJX_ZS(bmdm, zfabh, zf);//展示
                    }
                }
            }
            else if (e.CommandName == "QX")
            {
                grjx.Update_BMJX_ZS(bmdm, zfabh, "0");
                grjx.Delete_BMJX_ZS(bmdm, zfabh, zf);//取消展示
            }
            bind();
        }
        //查询所有部门该总方案下的分数
        protected void btn_cx_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_gszt");
                Label lbl_bm = (Label)li.FindControl("lbl_bmmc");
                string a = lbl_zt.Text;
                string b = lbl_bm.Text;
                if (lbl_zt.Text == "未公示")//1
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }

                if (lbl_zt.Text == "已公示")//3
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
    }
}