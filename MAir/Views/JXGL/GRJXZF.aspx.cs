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
    public partial class GRJXZF : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        public bool flag = true;
        public int i = 0;
        private GRJX grjx;
        private Struct_GRJX struct_grjx;
        public string zfabh,zfamc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            pg_fy.NumPerPage = _usState.C_ZL_ZJ;
            psize = _usState.C_ZL_ZJ;
            grjx = new GRJX(_usState);
            struct_grjx = new Struct_GRJX();
            zfabh = ddlt_zfa.SelectedValue;//总方案编号
            zfamc = ddlt_zfa.Text;//总方案名称
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
            }
        }

        private void ddltBind()
        {
            //绑定部门代码ddlt_bmdm
            DataTable dt_bmdm = SysData.BM().Copy();
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //总方案
            ddlt_zfa.DataSource = grjx.Select_ZFA().Tables[0];//查询总方案表中的总方案
            ddlt_zfa.DataTextField = "zfamc";
            ddlt_zfa.DataValueField = "zfabh";
            ddlt_zfa.DataBind();
            ddlt_zfa.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
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
        private void bind_Main()
        {
            zfabh = ddlt_zfa.SelectedValue;//总方案编号
            struct_grjx.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//部门代码
            struct_grjx.p_zfabh= ddlt_zfa.SelectedValue.ToString().Trim();//总方案编号
            struct_grjx.p_gwdm = "-1";
            struct_grjx.p_zt = "-1";
            struct_grjx.p_zfabh = zfabh;
            int count = grjx.Select_GRJX_Count(struct_grjx);
            pg_fy.TotalRecord = count;
            struct_grjx.p_currentpage = pg_fy.CurrentPage;
            struct_grjx.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = grjx.Select_GRJXZF(struct_grjx).Tables[0];
            dt.Columns.Add("bmmc");
            dt.Columns.Add("gwmc");
            dt.Columns.Add("ylpj");//优良评价
            foreach (DataRow dr in dt.Rows)
            {

                if (dr["zszt"].ToString().Equals("") || dr["zszt"].ToString().Equals("0") || dr["zszt"].ToString().Equals(null))
                {
                  dr["zszt"] = "未公示";
                  //lbl_zt.ForeColor = System.Drawing.Color.Gray;
                }
                else {
                    dr["zszt"] = "已公示";
                    //lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门名称
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;//岗位名称
                //dr["zt"] = SysData.GWByKey(dr["zt"].ToString()).mc;//状态名称
                if (dr["ZF"].ToString().Equals(""))
                { dr["ylpj"] = "待添加"; }
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 90) || Convert.ToDouble(dr["ZF"].ToString()) == 90)
                {dr["ylpj"] = "优";}
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 80) || Convert.ToDouble(dr["ZF"].ToString()) == 80)
                {dr["ylpj"] = "良";}
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 70) || Convert.ToDouble(dr["ZF"].ToString()) == 70)
                {dr["ylpj"] = "中";}
                else if ((Convert.ToDouble(dr["ZF"].ToString()) > 60) || Convert.ToDouble(dr["ZF"].ToString()) == 60)
                {dr["ylpj"] = "及格";}
                else { dr["ylpj"] = "不及格"; }
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[6];
            content = e.CommandArgument.ToString().Split('&');
            string ygbh = content[0];
            string xm = content[1];
            string bm = content[2];
            string gw = content[3];
            string zfabh = content[4];
            string zf = content[5];
            if (e.CommandName == "Add")
            {
                Response.Redirect("../JXGL/YG_GRJX_DF.aspx?ygbh=" + ygbh + "&" + "xm=" + xm + "&" + "bm=" + bm + "&" + "gw=" + gw + "&" + "zfabh=" + zfabh + "&" + "zfamc=" + zfamc, true);
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
                        grjx.Update_GRJX_ZS(ygbh, zfabh, "1");
                        grjx.Insert_GRJX_ZS(ygbh, zfabh, zf);//展示
                    }
                }
            }
            else if (e.CommandName == "QX")
            {
                grjx.Update_GRJX_ZS(ygbh, zfabh, "0");
                grjx.Delete_GRJX_ZS(ygbh, zfabh, zf);//取消展示
            }
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_gszt");
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
        //查询按钮
        protected void btn_cx_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
    }
}