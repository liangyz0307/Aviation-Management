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
    public partial class DQZC_DQGHDT : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private DQGHDT dqghdt;
        private Struct_DQGHDT struct_DQGHDT;

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

            dqghdt = new DQGHDT(_usState);
            struct_DQGHDT = new Struct_DQGHDT();
            if (!IsPostBack)
            {
                tbx_fbsjks.Attributes.Add("readonly", "readonly");
                tbx_fbsjjs.Attributes.Add("readonly", "readonly");
                ddltBind();
                bind_Main();
                show();

            }
        }
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
        private void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID,"220402") == true)
            {
                flag_add = true;
            }
          
            if (flag_add) { btn_add.Visible = true; }
        }

        private void bind_Main()
        {
            struct_DQGHDT.p_bt = tbx_bt.Text.ToString().Trim();//标题
            struct_DQGHDT.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            if (tbx_fbsjks.Text == "")
            {

                struct_DQGHDT.p_fbsjks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_DQGHDT.p_fbsjks = DateTime.Parse(tbx_fbsjks.Text.Trim().ToString());//开始时间
            }
            if (tbx_fbsjjs.Text == "")
            {
                // DateTime dt_jssj = new DateTime();
                struct_DQGHDT.p_fbsjjs = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_DQGHDT.p_fbsjjs = DateTime.Parse(tbx_fbsjjs.Text.Trim().ToString());//结束时间
            }
            int count = dqghdt.Select_DQGHDT_Count(struct_DQGHDT);
            pg_fy.TotalRecord = count;
            struct_DQGHDT.p_currentpage = pg_fy.CurrentPage;
            struct_DQGHDT.p_pagesize = pg_fy.NumPerPage;

            DataTable dt = dqghdt.Select_DQGHDT_Pro(struct_DQGHDT);
            dt.Columns.Add("fbsjmc");
            dt.Columns.Add("ztmc", typeof(string));
            DateTime dt_fbsj = new DateTime();
            foreach (DataRow dr in dt.Rows)
            {
                dt_fbsj = Convert.ToDateTime(dr["fbsj"].ToString());
                dr["fbsjmc"] = string.Format("{0:yyyy-MM-dd}", dt_fbsj);
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态

                // dr["fbsjmc"] = dr["fbsj"].ToString().Substring(0, 9);
            }


            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();

        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        #region 错误信息

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
        #endregion

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已提交，不能编辑！\")</script>");
                    return;
                }

                else
                {
                    Server.Transfer("DQZC_DQGHDTEdit.aspx?id=" + id);
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_DQGHDT = new Struct_DQGHDT();
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已提交，不能删除！\")</script>");
                    return;
                }
                else
                {
                    string p_czfs = "02";
                    string p_czxx = "位置：党群之窗->党群工会动态管理->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                    dqghdt.Delete_DQGHDT(id, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }

            }
            else if (e.CommandName == "Update_TJ")
            {
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已通过审核，不可提交！\")</script>");
                        return;
                    }
                    else
                        if (zt == "4")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已驳回，不可提交！\")</script>");
                            return;
                        }
                        else
                        {
                            struct_DQGHDT.p_id = id;
                            struct_DQGHDT.p_zt = "2";
                            struct_DQGHDT.p_bhyy = HF_yc.Value;
                            struct_DQGHDT.p_czfs = "03";
                            struct_DQGHDT.p_czxx = "位置：党群之窗->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                            dqghdt.Update_DQGHDTZT(struct_DQGHDT);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态提交成功！\")</script>");

                        }

            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态未提交，不能审核！\")</script>");
                    return;
                }
                else
                    if (zt == "3")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已通过审核，不可重复审核！\")</script>");

                        return;
                    }
                    else
                        if (zt == "4")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已驳回，不可审核！\")</script>");

                            return;
                        }
                        else
                        {
                            //执行update改变状态（审核）
                            struct_DQGHDT.p_id = id;
                            struct_DQGHDT.p_zt = "3";
                            struct_DQGHDT.p_bhyy = HF_yc.Value;
                            struct_DQGHDT.p_czfs = "03";
                            struct_DQGHDT.p_czxx = "位置：党群之窗->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            dqghdt.Update_DQGHDTZT(struct_DQGHDT);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态审核成功！\")</script>");

                        }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态未提交，不能驳回！\")</script>");

                    return;
                }
                else
                    if (zt == "3")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该党群工会动态已通过，不可重复驳回！\")</script>");

                        return;
                    }
                    else
                        if (zt == "4")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"党群工会动态已驳回，不可重复驳回！\")</script>");

                            return;
                        }
                        else
                        {
                            //执行update改变状态（驳回）
                            struct_DQGHDT.p_id = id;
                            struct_DQGHDT.p_zt = "4";
                            struct_DQGHDT.p_bhyy = HF_yc.Value;
                            struct_DQGHDT.p_czfs = "03";
                            struct_DQGHDT.p_czxx = "位置：党群之窗->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                            dqghdt.Update_DQGHDTZT(struct_DQGHDT);
                        }
            }
            bind_Main();
        }

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
                if (SysData.HasThisBMQX(_usState.userID, "220403") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }
               
                #endregion

                #region 删除的权限
                //删除隐藏
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220404") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
               
                #endregion
                #region 提交的权限
                //提交隐藏
                ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = false;
                if (SysData.HasThisBMQX( _usState.userID,"220405") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }
             
                #endregion

                #region 审核的权限
                //审核隐藏
                ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = false;

                if (SysData.HasThisBMQX( _usState.userID,"220406") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }
             
                #endregion
                #region 驳回的权限
                //驳回隐藏
                ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = false;
                if (SysData.HasThisBMQX( _usState.userID,"220407") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }
               
                #endregion
            }
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DQZC_DQGHDTAdd.aspx", false);
        }

        protected void Repeater1_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {

        }

    }
}