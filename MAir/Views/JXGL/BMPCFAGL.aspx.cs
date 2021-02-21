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

namespace MAir.Views.JXGL
{
    public partial class BMPCFAGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private PCFA pcfa;
        private Struct_PCFA struct_pcfa;
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
            pcfa = new PCFA(_usState);
            struct_pcfa = new Struct_PCFA();
            if (!IsPostBack)
            {
                bind_Main();
            }
        }
        private void bind_Main()
        {
            struct_pcfa.p_pcfamc = tbx_pcfamc.Text.Trim().ToString();//评测方案名称
            struct_pcfa.p_pcfabh = tbx_pcfabh.Text.Trim().ToString();//评测方案编号
            struct_pcfa.p_pcxbh = "";//评测项
            struct_pcfa.p_pcxqz = "";//评测项权重
            struct_pcfa.p_zt = "-1";//状态
            int count = pcfa.Select_BMPCFA_Count(struct_pcfa);
            pg_fy.TotalRecord = count;
            struct_pcfa.p_currentpage = pg_fy.CurrentPage;
            struct_pcfa.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = pcfa.Select_BMPCFA_Pro(struct_pcfa).Tables[0];
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        //查询
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        //添加
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMPCFAGL_Add.aspx", true);
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
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            string pcfabh = content[0];
            string zt = content[1];
            //int id = Convert.ToInt16(content[2]);//删除时根据id删除pcfa中其他关联pcx
            if (e.CommandName == "Edit")
            {
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该已审核通过，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "0" || zt == "3")
                {
                    Server.Transfer("PCFA_Edit.aspx?pcfabh=" + pcfabh);
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_pcfa = new Struct_PCFA();
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不能删除！\")</script>");
                    return;
                }
                else if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已审核通过，不能删除！\")</script>");
                    return;
                }
                else if (zt == "0" || zt == "3")
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：绩效管理->评测方案->删除    描述：指标代码：[" + _usState.userLoginName + "]";

                    //pcfa.Delete_PCFA_ByPCFABH(pcfabh, p_czfs, p_czxx);
                    //for循环，查询出同一个pcfa里相关的pcx的个数n，执行n次根据id删除 //参数id用于查询关联的其他id

                    //for (int i = 0; i <= Convert.ToInt16(pcfa.Select_PCFA_PCX_ID_DeleteByID(id)); i++)
                    //{
                    //    int iid = Convert.ToInt16(pcfa.Select_PCFA_PCX_ID_DeleteByID(id).Rows[i]);
                    //    pcfa.Delete_BMPCFA_ByID(iid, p_czfs, p_czxx);
                    //}
                    pcfa.Delete_BMPCFA_ByPCFABH(pcfabh, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }
            }
            else if (e.CommandName == "Update_TJ")
            {
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                    if (zt == "2")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不可提交！\")</script>");
                        return;
                    }
                    else
                    {
                        struct_pcfa.p_pcfabh = pcfabh;
                        struct_pcfa.p_zt = "1";
                        struct_pcfa.p_bhyy = HF_yc.Value;
                        struct_pcfa.p_czfs = "03";
                        struct_pcfa.p_czxx = "位置：绩效管理->评测项方案>状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        pcfa.Update_BMPCFA_ZT(struct_pcfa);
                    }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息未提交，不能审核！\")</script>");
                    return;
                }
                else
                    if (zt == "2")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不可重复审核！\")</script>");
                        return;
                    }
                    else
                    {
                        //执行update改变状态（审核）
                        struct_pcfa.p_pcfabh = pcfabh;
                        struct_pcfa.p_zt = "2";
                        struct_pcfa.p_bhyy = HF_yc.Value;
                        struct_pcfa.p_czfs = "03";
                        struct_pcfa.p_czxx = "位置：绩效管理->评测方案->状态->改变状态（审核）    描述：指标代码：[" + _usState.userLoginName + "]";
                        pcfa.Update_BMPCFA_ZT(struct_pcfa);
                    }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息未提交，不能驳回！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，不可重复驳回！\")</script>");
                        return;
                    }
                    else
                    {
                        //执行update改变状态（驳回）
                        struct_pcfa.p_pcfabh = pcfabh;
                        struct_pcfa.p_zt = "3";
                        struct_pcfa.p_bhyy = HF_yc.Value;
                        struct_pcfa.p_czfs = "03";
                        struct_pcfa.p_czxx = "位置：绩效管理->评测方案->状态->改变状态（驳回）    描述：指标代码：[" + _usState.userLoginName + "]";
                        pcfa.Update_BMPCFA_ZT(struct_pcfa);
                    }
            }
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            //{
            //    Label lbl_zt = (Label)li.FindControl("lbl_zt");
            //    if (lbl_zt.Text == "待提交")//0
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Blue;
            //    }
            //    if (lbl_zt.Text == "待初审")//1
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
            //    }
            //    if (lbl_zt.Text == "待终审")//2
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
            //    }
            //    if (lbl_zt.Text == "审核通过")//3
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Green;
            //    }
            //    if (lbl_zt.Text == "审核未通过")//4
            //    {
            //        lbl_zt.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
        }
    }
}