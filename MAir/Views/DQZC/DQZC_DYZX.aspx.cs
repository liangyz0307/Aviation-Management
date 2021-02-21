using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace CUST.WKG
{
    public partial class DQZC_DYZX : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        private UserState _usState;
        public DYZX dyzx;
        public ODYZX.Struct_DYZX struct_dyzx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            // struct_dyzx = new CUST.MKG.ODYZX.Struct_DYZX();
            dyzx = new DYZX(_usState);
            if (!IsPostBack)
            {
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
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
        private void bind_Main()
        {
            struct_dyzx.p_xm = txb_xm.Text.Trim().ToString();//姓名;
            
            struct_dyzx.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            if (tbx_kssj.Text.Trim().ToString() == "")
            {

                struct_dyzx.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_dyzx.p_kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {

                struct_dyzx.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");

            }
            else
            {
                struct_dyzx.p_jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//开始时间
            }
            int count = dyzx.Select_DYZX_Count(struct_dyzx);
            pg_fy.TotalRecord = count;
            struct_dyzx.p_currentpage = pg_fy.CurrentPage;
            struct_dyzx.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = dyzx.Select_DYZX(struct_dyzx);
            dt.Columns.Add("bmmc", typeof(string));
            dt.Columns.Add("gwmc", typeof(string));
            dt.Columns.Add("ztmc", typeof(string));
            dt.Columns.Add("sjmc");

            foreach (DataRow dr in dt.Rows)
            {
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;//岗位
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["sjmc"] = dr["sj"].ToString().Substring(0, 10);
            }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
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
        #region 截取字符串(如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串)
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">规定该字符串显示的长度</param>
        /// <returns>结果字符串</returns>
        public string GetCut(string str, int len)
        {
            //如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串
            if (str.Length > len)
            {
                return str.Substring(0, len) + "...";

            }
            else
            {
                return str;
            }
        }
        #endregion
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "220302") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DQZC/DQZC_DYZXAdd.aspx", true);
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            long id = long.Parse(content[0]);
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
                    Server.Transfer("../DQZC/DQZC_DYZXEdit.aspx?id=" + e.CommandArgument.ToString());
                }
            }
            else if (e.CommandName == "Delete")
            {

                struct_dyzx.p_id = id;
                if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已提交，不能删除！\")</script>");
                    return;
                }
                else
                {
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    struct_dyzx.p_czfs = "03";
                    struct_dyzx.p_czxx = "位置：党群之窗->党员在线->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                    dyzx.Delete_DYZX_byID(struct_dyzx);
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
                            struct_dyzx.p_id = id;
                            struct_dyzx.p_zt = "2";
                            struct_dyzx.p_bhyy = HF_yc.Value;
                            struct_dyzx.p_czfs = "03";
                            struct_dyzx.p_czxx = "位置：党群之窗->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                            dyzx.Update_DYZXZT(struct_dyzx);
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
                            struct_dyzx.p_id = id;
                            struct_dyzx.p_zt = "3";
                            struct_dyzx.p_bhyy = HF_yc.Value;
                            struct_dyzx.p_czfs = "02";
                            struct_dyzx.p_czxx = "位置：党群之窗->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";

                            dyzx.Update_DYZXZT(struct_dyzx);
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
                            struct_dyzx.p_id = id;
                            struct_dyzx.p_zt = "4";
                            struct_dyzx.p_bhyy = HF_yc.Value;
                            struct_dyzx.p_czfs = "03";
                            struct_dyzx.p_czxx = "位置：党群之窗->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                            dyzx.Update_DYZXZT(struct_dyzx);
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
                if (SysData.HasThisBMQX(_usState.userID, "220303") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtEdit")).Visible = true;
                }

                #endregion

                #region 删除的权限
                //删除隐藏
                ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220304") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbtDelete")).Visible = true;

                }

                #endregion
                #region 提交的权限
                //提交隐藏
                ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220305") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_tj")).Visible = true;

                }

                #endregion

                #region 审核的权限
                //审核隐藏
                ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = false;

                if (SysData.HasThisBMQX(_usState.userID, "220306") == true)
                {
                    ((LinkButton)e.Item.FindControl("lbt_sh")).Visible = true;

                }

                #endregion
                #region 驳回的权限
                //驳回隐藏
                ((LinkButton)e.Item.FindControl("lbt_bh")).Visible = false;
                if (SysData.HasThisBMQX(_usState.userID, "220307") == true)
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