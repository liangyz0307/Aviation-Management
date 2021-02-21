using CUST.Sys;
using System;
using System.Web.UI.WebControls;
using Sys;

using CUST.Tools;
using CUST.MKG;
using System.Data;

namespace CUST.WKG
{
    public partial class DYCX : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private DYGL yg1;
        private Struct_YG_Pro strcut_yg;

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
            yg1 = new DYGL(_usState);
            strcut_yg = new Struct_YG_Pro();
            if (!IsPostBack)
            {
                txb_jrdzzsj.Attributes.Add("readonly", "readonly");
                txb_zwzsdyrq.Attributes.Add("readonly", "readonly");
                txb_jrdzzsj1.Attributes.Add("readonly", "readonly");
                txb_zwzsdyrq1.Attributes.Add("readonly", "readonly");
                ddltBind();
                show();
                bind_Main();
            }
        }
        //下拉列表
        private void ddltBind()
        {
            //人员类别
            ddlt_zzmmdm.DataSource = SysData.ZZMM().Copy();
            ddlt_zzmmdm.DataTextField = "mc";
            ddlt_zzmmdm.DataValueField = "bm";
            ddlt_zzmmdm.DataBind();
            ddlt_zzmmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = true;
            if (SysData.HasThisBMQX(_usState.userID, "220205") == true)
            {
                flag_add = true;
            }
          
            if (flag_add) { btn_add.Visible = true; }

        }
        private void bind_Main()
        {

            strcut_yg.p_userid = _usState.userID;
            strcut_yg.p_xm = txb_xm.Text.Trim().ToString();//姓名
            strcut_yg.p_zzmmdm = ddlt_zzmmdm.SelectedValue.ToString().Trim();//人员类别
            strcut_yg.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            strcut_yg.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();//状态
            if (txb_jrdzzsj.Text == "")
            {

                strcut_yg.p_jrdzzsj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                strcut_yg.p_jrdzzsj = DateTime.Parse(txb_jrdzzsj.Text.Trim().ToString());//加入党组织开始时间
            }
            if (txb_jrdzzsj1.Text == "")
            {

                strcut_yg.p_jrdzzsj1 = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                strcut_yg.p_jrdzzsj1 = DateTime.Parse(txb_jrdzzsj1.Text.Trim().ToString());//加入党组织结束时间
            }
            if (txb_zwzsdyrq.Text == "")
            {

                strcut_yg.p_zwzsdyrq = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                strcut_yg.p_zwzsdyrq = DateTime.Parse(txb_zwzsdyrq.Text.Trim().ToString());//开始时间
            }
            if (txb_zwzsdyrq1.Text == "")
            {

                strcut_yg.p_zwzsdyrq1 = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                strcut_yg.p_zwzsdyrq1 = DateTime.Parse(txb_zwzsdyrq1.Text.Trim().ToString());//结束时间
            }
            int count = yg1.Select_YG_Count(strcut_yg);
            pg_fy.TotalRecord = count;
            strcut_yg.p_currentpage = pg_fy.CurrentPage;
            strcut_yg.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = yg1.Select_YG_All(strcut_yg).Tables[0];
            dt.Columns.Add("zzmmdmmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("xbdmmc");
            dt.Columns.Add("xldmmc");
            dt.Columns.Add("jrdzzsjmc");
            dt.Columns.Add("zwzsdyrqmc");
            dt.Columns.Add("csrqmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["zzmmdmmc"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//人员类别
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["xbdmmc"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;//性别
                dr["xldmmc"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历 

                DateTime dt_jrdzzsj = new DateTime();
                dt_jrdzzsj = Convert.ToDateTime(dr["jrdzzsj"].ToString());
                dr["jrdzzsjmc"] = string.Format("{0:yyyy-MM-dd}", dt_jrdzzsj);//加入党组织时间

                DateTime dt_zwzsdyrq = new DateTime();
                dt_zwzsdyrq = Convert.ToDateTime(dr["zwzsdyrq"].ToString());
                dr["zwzsdyrqmc"] = string.Format("{0:yyyy-MM-dd}", dt_zwzsdyrq);//加入党组织时间

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["csrq"].ToString());
                dr["csrqmc"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);//出生日期
               


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
        //根据状态判断增删改
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            string bh = content[0];

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
                    Server.Transfer("DYGL_Edit.aspx?bh=" + bh);
                }
            }
            else if (e.CommandName == "Delete")
            {
                strcut_yg = new Struct_YG_Pro();
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不能删除！\")</script>");
                    return;
                }            
                else 
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：绩效管理->指标信息->删除    描述：指标代码：[" + _usState.userLoginName + "]";
                    yg1.DY_Del(bh, p_czfs, p_czxx);
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
                    
                    yg1.DYZT_Edit(bh, "2", "");

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

                    strcut_yg.p_bh = bh;
                    strcut_yg.p_zt = "3";
                    strcut_yg.p_bhyy = HF_yc.Value;
                    strcut_yg.p_czfs = "03";
                    strcut_yg.p_czxx = "位置：员工惩罚->状态->改变状态（审核）    描述：指标代码：[" + _usState.userLoginName + "]";
                    yg1.DYZT_Edit(bh, "3", "");
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
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过，不可驳回！\")</script>");

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
                    string bhyy =  HF_yc.Value;
                    yg1.DYZT_Edit(bh, "4", bhyy);
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
            Response.Redirect("../DQZC/DYGL_Add.aspx", true);
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
                if (SysData.HasThisBMQX(_usState.userID, "220203") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }

                #endregion

                #region 删除的权限
                //删除隐藏
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220204") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }

                #endregion
                #region 提交的权限
                //提交隐藏
                ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220205") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }

                #endregion

                #region 审核的权限
                //审核隐藏
                ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = false;

                if (SysData.HasThisBMQX(_usState.userID, "220206") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }

                #endregion
                #region 驳回的权限
                //驳回隐藏
                ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220207") == true)
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