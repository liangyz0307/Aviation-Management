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
    public partial class KG_ZG_select : System.Web.UI.Page
    {
        private UserState _usState;
        protected int cpage;
        protected int psize;
        private KG_ZG kg_zg;
        private Struct_KG_Select_ZG struct_kg_zg;
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
            kg_zg = new KG_ZG(_usState);
            struct_kg_zg = new Struct_KG_Select_ZG();
            if (!IsPostBack)
            {
                tbx_zgsxks.Attributes.Add("readonly", "readonly");
                tbx_zgsxjs.Attributes.Add("readonly", "readonly");
                ddltBind();
                bind_Main();
                show();
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;
            //有整改任务添加权限
            if (SysData.HasThisBMQX(_usState.userID, "170202") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void ddltBind()
        {
             //状态
            ddlt_zgzt.DataSource = SysData.ZTDM().Copy();
            ddlt_zgzt.DataTextField = "mc";
            ddlt_zgzt.DataValueField = "bm";
            ddlt_zgzt.DataBind();
            ddlt_zgzt.Items.Insert(0, new ListItem("全部", "-1"));

            //检查单
            ddlt_jcd.DataTextField = "mc";
            ddlt_jcd.DataValueField = "bm";
            ddlt_jcd.DataSource = SysData.TBDW().Copy();
            ddlt_jcd.DataBind();
            ddlt_jcd.Items.Insert(0, new ListItem("全部", "-1"));

            //整改项目
            string tbdw = ddlt_jcd.SelectedValue.ToString();
            DataTable dt_zgxm = new DataTable();
            dt_zgxm = kg_zg.Select_JCJL(tbdw);
            ddlt_zgxm.DataSource = dt_zgxm;
            ddlt_zgxm.DataTextField = "jcxm";
            ddlt_zgxm.DataValueField = "jcxm";
            ddlt_zgxm.DataBind();
            ddlt_zgxm.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_kg_zg.p_bmdm = _usState.userBMDM;
            struct_kg_zg.p_wtly = tbx_wtly.Text.Trim().ToString();
            struct_kg_zg.p_tbdw = ddlt_jcd.SelectedValue.ToString();
            struct_kg_zg.p_zgxm = ddlt_zgxm.SelectedValue.ToString();
            struct_kg_zg.p_zrr = "";
            struct_kg_zg.p_zt = ddlt_zgzt.SelectedValue.ToString().Trim();//状态
            struct_kg_zg.p_userid = _usState.userID;
           if (tbx_zgsxks.Text.Trim().ToString() == "")
            {
                struct_kg_zg.p_zgsxks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_kg_zg.p_zgsxjs = DateTime.Parse(tbx_zgsxjs.Text.Trim().ToString());//开始时间
            }
            if (tbx_zgsxjs.Text.Trim().ToString() == "")
            {
                struct_kg_zg.p_zgsxjs = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_kg_zg.p_zgsxjs= DateTime.Parse(tbx_zgsxjs.Text.Trim().ToString());//结束时间
            }
            int count = kg_zg.Select_ZG_Count(struct_kg_zg);
            pg_fy.TotalRecord = count;
            struct_kg_zg.p_currentpage = pg_fy.CurrentPage;
            struct_kg_zg.p_pagesize = pg_fy.NumPerPage;
            
            DataTable dt = kg_zg.Select_ZG_Pro(struct_kg_zg).Tables[0];
            //dt.Columns.Add("zrrmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("jcdmc");
            dt.Columns.Add("zgsxmc");
             foreach (DataRow dr in dt.Rows)
            {
                dr["ztmc"] = SysData.ZGZTByKey(dr["zt"].ToString()).mc;//状态
                dr["jcdmc"] = SysData.TBDWByKey(dr["tbdw"].ToString()).mc;//状态
                dr["zgsxmc"] = DateTime.Parse(dr["zgsx"].ToString()).ToString("yyyy-MM-dd");
            }

            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        
        }
        protected void ddlt_jcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tbdw = ddlt_jcd.SelectedValue.ToString();
            string zgxm = ddlt_jcd.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = kg_zg.Select_JCJL(tbdw);
            ddlt_zgxm.DataSource = dt;
            ddlt_zgxm.DataTextField = "jcxm";
            ddlt_zgxm.DataValueField = "jcxm";
            ddlt_zgxm.DataBind();

        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            
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
            int id = int.Parse(content[0]);
            string zt = content[1];
            if (e.CommandName == "Edit")
            {
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已提交，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已审核通过，不能编辑！\")</script>");
                    return;
                }

                else if (zt == "0" || zt == "3")
                {
                    Server.Transfer("KG_ZG_edit.aspx?id=" + id);
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_kg_zg = new Struct_KG_Select_ZG();
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已提交，不能删除！\")</script>");
                    return;
                }
                else if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已审核通过，不能删除！\")</script>");
                    return;
                }

                else if (zt == "0" || zt == "3")
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：安全监管->整改管理->删除    描述：员工编号：[" +_usState.userLoginName + "]";
                    kg_zg.Delete_ZG(id, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }

            }
            else if (e.CommandName == "Update_TJ")
            {
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else
                {
                    struct_kg_zg.p_id = id;
                    struct_kg_zg.p_zt = "1";
                    struct_kg_zg.p_bhyy = "驳回原因：" + HF_yc.Value;
                    struct_kg_zg.p_czfs = "03";
                    struct_kg_zg.p_czxx = "位置：员工整改->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                    kg_zg.Update_ZG_ZT(struct_kg_zg);
                }

            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息未提交，不能审核！\")</script>");
                    return;
                }
                else
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已通过审核，不可重复审核！\")</script>");

                    return;
                }
                else
                {
                    //执行update改变状态（审核）
                    struct_kg_zg.p_id = id;
                    struct_kg_zg.p_zt = "2";
                    struct_kg_zg.p_bhyy = "驳回原因：" + HF_yc.Value;
                    struct_kg_zg.p_czfs = "02";
                    struct_kg_zg.p_czxx = "位置：员工整改->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                    kg_zg.Update_ZG_ZT(struct_kg_zg);
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息未提交，不能驳回！\")</script>");

                    return;
                }
                else
                if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工整改信息已驳回，不可重复驳回！\")</script>");

                    return;
                }
                else
                {
                    //执行update改变状态（驳回）
                    struct_kg_zg.p_id = id;
                    struct_kg_zg.p_zt = "3";
                    struct_kg_zg.p_bhyy = "驳回原因：" + HF_yc.Value;
                    struct_kg_zg.p_czfs = "03";
                    struct_kg_zg.p_czxx = "位置：整改管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                    kg_zg.Update_ZG_ZT(struct_kg_zg);
                }
            }
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("KG_ZG_add.aspx", true);
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_byyx");
                if (lbl_zt.Text == "待提交")//0
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Blue;
                }
                if (lbl_zt.Text == "保存")//1
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "待审核")//2
                {
                    lbl_zt.ForeColor = System.Drawing.Color.DarkGray;
                }
                if (lbl_zt.Text == "审核通过")//3
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Green;
                }
                if (lbl_zt.Text == "驳回")//4
                {
                    lbl_zt.ForeColor = System.Drawing.Color.Red;
                }
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                #region 编辑权限
                ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = false;
                //判断删除权限
                if (SysData.HasThisQX("170303", _usState.userID, "01") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }
                if (SysData.HasThisQX("170303", _usState.userID, "02") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }
                if (SysData.HasThisQX("170303", _usState.userID, "03") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }
                if (SysData.HasThisQX("170303", _usState.userID, "04") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }
                if (SysData.HasThisQX("170303", _usState.userID, "05") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }
                #endregion
                #region 删除的权限
                //删除隐藏
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisQX("170304", _usState.userID, "01") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170304", _usState.userID, "02") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170304", _usState.userID, "03") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170304", _usState.userID, "04") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                if (SysData.HasThisQX("170304", _usState.userID, "05") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }
                #endregion
                #region 提交的权限
                //提交隐藏
                ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = false;
                if (SysData.HasThisQX("170305", _usState.userID, "01") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }
                if (SysData.HasThisQX("170305", _usState.userID, "02") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }
                if (SysData.HasThisQX("170305", _usState.userID, "03") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }
                if (SysData.HasThisQX("170305", _usState.userID, "04") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }
                if (SysData.HasThisQX("170305", _usState.userID, "05") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }
                #endregion
                #region 审核的权限
                //审核隐藏
                ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = false;

                if (SysData.HasThisQX("170306", _usState.userID, "01") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }
                if (SysData.HasThisQX("170306", _usState.userID, "02") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }
                if (SysData.HasThisQX("170306", _usState.userID, "03") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }
                if (SysData.HasThisQX("170306", _usState.userID, "04") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }
                if (SysData.HasThisQX("170306", _usState.userID, "05") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }
                #endregion
                #region 驳回的权限
                //驳回隐藏
                ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = false;
                if (SysData.HasThisQX("170307", _usState.userID, "01") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }
                if (SysData.HasThisQX("170307", _usState.userID, "02") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }
                if (SysData.HasThisQX("170307", _usState.userID, "03") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }
                if (SysData.HasThisQX("170307", _usState.userID, "04") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }
                if (SysData.HasThisQX("170307", _usState.userID, "05") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = true;

                }
                #endregion
            }
        }
        internal int Select_ZG_MAXID()
        {
            throw new NotImplementedException();

        }

        protected void tbx_zgxm_TextChanged(object sender, EventArgs e)
        {

        }
        protected void btn_gjjs_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_YGXX.aspx", true);
        }
    }
}