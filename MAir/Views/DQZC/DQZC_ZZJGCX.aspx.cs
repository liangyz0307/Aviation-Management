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
    public partial class DQZC_ZZJGCX : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private ZZJG zzjg;
        private Struct_ZZJG_CX strcut_zzjg;
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
            zzjg = new ZZJG(_usState);
            strcut_zzjg = new Struct_ZZJG_CX();
            if (!IsPostBack)
            {
                ddltBind();
                show();
                bind_Main();
            }
        }
        //下拉列表
        private void ddltBind()
        {



            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_zt.Items.RemoveAt(2);
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = true;
            if (SysData.HasThisBMQX(_usState.userID, "220503") == true)
            {
                flag_add = true;
            }

            if (flag_add) { btn_add.Visible = true; }

        }
        private void bind_Main()
        {

            strcut_zzjg.p_dzzmc = txb_dzzmc.Text.Trim().ToString();//党组织名称
            strcut_zzjg.p_jcdzbmc = txb_jcdzbmc.Text.Trim().ToString();//基层党支部名称
            strcut_zzjg.p_dxzmc = txb_dxzmc.Text.Trim().ToString();//党小组名称
            strcut_zzjg.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            int count = zzjg.Select_ZZJG_Count(strcut_zzjg);
            pg_fy.TotalRecord = count;
            strcut_zzjg.p_currentpage = pg_fy.CurrentPage;
            strcut_zzjg.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = zzjg.Select_ZZJG_All(strcut_zzjg).Tables[0];

            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        //分页
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        //错误信息
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
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);

            string zt = content[1];
            if (e.CommandName == "Edit")
            {
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不能编辑！\")</script>");
                    return;
                }
                else
                {
                    Server.Transfer("DQZC_ZZJGEdit.aspx?id=" + id);
                }
            }
            else if (e.CommandName == "Delete")
            {
                strcut_zzjg = new Struct_ZZJG_CX();
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不能删除！\")</script>");
                    return;
                }
                else
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：绩效管理->指标信息->删除    描述：指标代码：[" + _usState.userLoginName + "]";
                    zzjg.ZZJG_Del(id, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }

            }
            else if (e.CommandName == "Update_TJ")
            {
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else
                        if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，不可提交！\")</script>");
                    return;
                }
                else
                {

                    zzjg.ZZJGZT_Edit(id, "2", "");

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
                    if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不可重复审核！\")</script>");

                    return;
                }
                else
                        if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，不可审核！\")</script>");

                    return;
                }
                else
                {
                    //执行update改变状态（审核）

                    strcut_zzjg.p_id = id;
                    strcut_zzjg.p_zt = "3";
                    strcut_zzjg.p_bhyy = HF_yc.Value;
                    strcut_zzjg.p_czfs = "03";
                    strcut_zzjg.p_czxx = "位置：党群之窗->组织机构->状态->改变状态（审核）    描述：指标代码：[" + _usState.userLoginName + "]";
                    zzjg.ZZJGZT_Edit(id, "3", "");
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过，不可重复驳回！\")</script>");

                    return;
                }
                else
                        if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，不可重复驳回！\")</script>");

                    return;
                }
                else
                {
                    //执行update改变状态（驳回）
                    string bhyy = HF_yc.Value;
                    zzjg.ZZJGZT_Edit(id, "4", bhyy);
                }
            }
            bind_Main();
        }
        //查询按钮
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        //添加按钮
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DQZC_ZZJGAdd.aspx", true);
        }
        //权限
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_zt");
                if (lbl_zt.Text == "待提交")//0
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Blue;
                }
                if (lbl_zt.Text == "待初审")//1
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "待终审")//2
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "审核通过")//3
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_zt.Text == "审核未通过")//4
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                #region 编辑权限
                ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = false;
                //判断删除权限
                if (SysData.HasThisBMQX(_usState.userID, "220503") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }

                #endregion

                #region 删除的权限
                //删除隐藏
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220504") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }

                #endregion
                #region 提交的权限
                //提交隐藏
                ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220505") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }

                #endregion

                #region 审核的权限
                //审核隐藏
                ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = false;

                if (SysData.HasThisBMQX(_usState.userID, "220506") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }

                #endregion
                #region 驳回的权限
                //驳回隐藏
                ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220507") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }

                #endregion

            }
        }

        protected void Repeater1_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}