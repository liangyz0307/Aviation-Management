
using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CUST.WKG
{
    public partial class BS_YSSB : System.Web.UI.Page
    {
        private UserState _usState;
        private YSSB yssb;
        private Select_Bs_Yssb select_bs_yssb;//结构体
        private Struct_Bs_Yssb_Update struct_bs_yssb_update;
        public int cpage;
        public int psize;
        static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            yssb = new YSSB(_usState);
            struct_bs_yssb_update = new Struct_Bs_Yssb_Update();
            cpage = pg_fy.CurrentPage;
            select_bs_yssb = new Select_Bs_Yssb();
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {

                Bind();
                bind_Main();
               // show();
            }
        }
        protected void show()
        {

            
        }
        private void bind_Main()
        {
            select_bs_yssb.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态
            select_bs_yssb.p_yslx = ddlt_yslx.SelectedValue.Trim().ToString();//预算类型
            select_bs_yssb.p_sbzt = ddlt_sbzt.SelectedValue.Trim().ToString();//申报状态
            select_bs_yssb.p_tbdw = tbx_tbdw.Text.Trim().ToString();//填报单位

            select_bs_yssb.p_userid = _usState.userID;
            select_bs_yssb.p_currentpage = pg_fy.CurrentPage;
            select_bs_yssb.p_pagesize = pg_fy.NumPerPage;
            int count = yssb.Select_Bs_Yssb_Count(select_bs_yssb);
            pg_fy.TotalRecord = count;
            dt = yssb.SelectBS_Yssb_Pro(select_bs_yssb);
            dt.Columns.Add("bm");
            dt.Columns.Add("yslxmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sbztmc");
            dt.Columns.Add("sbnfs");
            dt.Columns.Add("wcsjs");

            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["yslxmc"] = SysData.YSLXByKey(dr["yslx"].ToString()).mc;
                dr["ztmc"] =SysData.ZT2ByKey( dr["zt"].ToString()).mc;
                dr["sbztmc"] =SysData.ZTByKey( dr["sbzt"].ToString()).mc;
                dr["sbnfs"] = Convert.ToDateTime(dr["sbnf"]).ToString("yyyy-MM-dd");
                dr["wcsjs"] = Convert.ToDateTime(dr["wcsj"]).ToString("yyyy-MM-dd");
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("BS_YSSB_Add.aspx");
        }
        #endregion
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Bind()
        {
            //绑定预算类型
            ddlt_yslx.DataSource = yssb.Select_Bs_Yssb_Yslx().Copy();
            ddlt_yslx.DataTextField = "mc";
            ddlt_yslx.DataValueField = "bm";
            ddlt_yslx.DataBind();
            ddlt_yslx.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定状态
            ddlt_zt.DataSource = yssb.Select_Bs_Yssb_Zt().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            //绑定申报状态
            ddlt_sbzt.DataSource = yssb.Select_Bs_Yssb_Sbzt().Copy();
            ddlt_sbzt.DataTextField = "mc";
            ddlt_sbzt.DataValueField = "bm";
            ddlt_sbzt.DataBind();
            ddlt_sbzt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void rpt_gzjz_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
            string sbzt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识

            if (e.CommandName == "Edit")
            {
                if (sbzt == "1" || sbzt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报待审核，不能编辑！\")</script>");
                    return;
                }
                else if (sbzt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130403"))
                    {
                        Server.Transfer("BS_YSSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该申报预算信息的编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }

                else if (sbzt == "0" || sbzt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        Server.Transfer("BS_YSSB_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该申报预算信息的编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_bs_yssb_update = new Struct_Bs_Yssb_Update();
                if (sbzt == "0" || sbzt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务综合->申报预算管理    描述：员工编号：[" + _usState.userLoginName + "]";
                        yssb.Delete_Bs_Yssb(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (sbzt == "1" || sbzt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该申报预算信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (sbzt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130404"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务综合->申报预算管理    描述：员工编号：[" + _usState.userLoginName + "]";
                        yssb.Delete_Bs_Yssb(id, p_czfs, p_czxx); ;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该预算申报信息的删除权限，不可删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_TJ")
            {
                struct_bs_yssb_update = new Struct_Bs_Yssb_Update();
                if (sbzt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_bs_yssb_update.p_id = id;
                        struct_bs_yssb_update.p_sbzt = "1";
                        struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                        struct_bs_yssb_update.p_czfs = "05";
                        struct_bs_yssb_update.p_czxx = "位置：航务综合->预算申报->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (sbzt == "1" || sbzt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报待审核，不可提交！\")</script>");
                    return;
                }
                else if (sbzt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (sbzt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已驳回，请先编辑再提交！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (sbzt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        struct_bs_yssb_update.p_id = id;
                        struct_bs_yssb_update.p_sbzt = "2";
                        struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                        struct_bs_yssb_update.p_czfs = "06";
                        struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (sbzt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        struct_bs_yssb_update.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_bs_yssb_update.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                            struct_bs_yssb_update.p_czfs = "06";
                            struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            yssb.Update_YSSB_SJBS_ZT(struct_bs_yssb_update);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_bs_yssb_update.p_sjc = sjc;
                            struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                            struct_bs_yssb_update.p_czfs = "06";
                            struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            yssb.Update_YSSB_SJBS_LSSJ_ZT(struct_bs_yssb_update);

                            //将副本数据变为最终数据
                            struct_bs_yssb_update.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                            struct_bs_yssb_update.p_czfs = "06";
                            struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            yssb.Update_YSSB_SJBS_FBSJ_ZT(struct_bs_yssb_update);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (sbzt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该预算申报，不能审核！\")</script>");
                    return;
                }
                else if (sbzt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (sbzt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已驳回，请先编辑信息后再提交才能审核！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (sbzt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_bs_yssb_update.p_id = id;
                        struct_bs_yssb_update.p_sbzt = "4";
                        struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                        struct_bs_yssb_update.p_czfs = "07";
                        struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能驳回！\")</script>");
                        return;
                    }
                }
                else if (sbzt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_bs_yssb_update.p_id = id;
                        struct_bs_yssb_update.p_sbzt = "4";
                        struct_bs_yssb_update.p_bhyy = HF_yc.Value;
                        struct_bs_yssb_update.p_czfs = "07";
                        struct_bs_yssb_update.p_czxx = "位置：预算申报->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yssb.Update_Bs_Yssb_Sbzt(struct_bs_yssb_update);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (sbzt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报未提交，不能驳回！\")</script>");

                    return;
                }
                else if (sbzt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (sbzt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预算申报已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_ztmc");
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
        }

    }
}