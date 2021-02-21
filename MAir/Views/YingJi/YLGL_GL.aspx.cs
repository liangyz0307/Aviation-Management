using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;
using System.Text;
using CUST.Tools;
using CUST;
using CUST.Sys;
using CUST.MKG;
using Sys;
namespace CUST.WKG
{
    public partial class YLGL_GL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private YLGL ylgl;
        public Struct_YLGL struct_ylgl;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ylgl = new YLGL(_usState);
            if (!IsPostBack)
            {
                Bind();
                show();
                bind_Main();
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "180202") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private  void Bind()
        {
            //绑定支线名称
            ddlt_dq.DataTextField = "mc";
            ddlt_dq.DataValueField = "bm";
            ddlt_dq.DataSource = SysData.ZXDM() .Copy();
            ddlt_dq.DataBind();
            ddlt_dq.Items.Insert(0, new ListItem("全部", "-1"));

            //绑定预案名
            ddlt_yam.DataTextField = "mc";
            ddlt_yam.DataValueField = "sjc";
            ddlt_yam.DataSource = ylgl.Select_Ylgl_Yam_Mc().Copy();
            ddlt_yam.DataBind();
            ddlt_yam.Items.Insert(0, new ListItem("全部", "-1"));

            //所属演练形式
            ddlt_ylxs.DataTextField = "mc";
            ddlt_ylxs.DataValueField = "bm";
            ddlt_ylxs.DataSource = SysData.YLXS().Copy();
            ddlt_ylxs.DataBind();
            ddlt_ylxs.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_ylgl.p_dq = ddlt_dq.SelectedValue.Trim().ToString();
            struct_ylgl.p_yam = ddlt_yam.SelectedValue.Trim().ToString();
            struct_ylgl.p_ylxs = ddlt_ylxs.SelectedValue.Trim().ToString();
            struct_ylgl.p_zt = ddlt_zt.SelectedValue.Trim().ToString();
            struct_ylgl.p_currentpage = pg_fy.CurrentPage;
            struct_ylgl.p_pagesize = pg_fy.NumPerPage;
            struct_ylgl.p_userid = _usState.userID;
            int count = ylgl.Select_YLGL_Count(struct_ylgl);
            pg_fy.TotalRecord = count;
            DataTable dt = ylgl.Select_Ylgl(struct_ylgl);
            dt.Columns.Add("ylxsmc");
            dt.Columns.Add("dqmc");
            dt.Columns.Add("yammc");
            dt.Columns.Add("ylsjmc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["ylxsmc"] = SysData.YLXSByKey(dr["ylxs"].ToString()).mc;
                dr["dqmc"] = SysData.ZXDMByKey(dr["dq"].ToString()).mc;
                dr["yammc"] = ylgl.YAMByKey( dr["yam"].ToString());
                dr["ylsjmc"] = DateTime.Parse(dr["ylsj"].ToString()).ToString("yyyy-MM-dd");
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            ////绑定分页数据源  
            this.rpt_ylgl.DataSource = dt.DefaultView;
            this.rpt_ylgl.DataBind();
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
         
            Response.Redirect("../YingJi/YLGL_Add.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int bh = Convert.ToInt32(content[0]);
            string zt = content[1];
            string bmdm = content[2];
            string lrr = content[3];//录入人
            string csr = content[4];//初审人
            string zsr = content[5];//终审人
            string sjc = content[6];//时间戳
            string sjbs = content[7];//数据标识

            if (e.CommandName == "Edit")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "180203"))
                    {
                        Server.Transfer("YLGL_Edit.aspx?bh=" + bh + "&sjbs=" + sjbs + "&sjc=" + sjc);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该部门的编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
                else if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        Server.Transfer("YLGL_Edit.aspx?bh=" + bh + "&sjbs=" + sjbs + "&sjc=" + sjc);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                struct_ylgl = new Struct_YLGL();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：应急管理->应急管理管理->演练    描述：员工编号：[" + _usState.userLoginName + "]";
                        ylgl.Delete_Ylgl(bh, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "180204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：应急管理->应急管理管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        ylgl.Delete_Ylgl(bh, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该部门删除权限，不可删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_TJ")
            {
                struct_ylgl = new Struct_YLGL();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_ylgl.p_bh = bh;
                        struct_ylgl.p_zt = "1";
                        struct_ylgl.p_bhyy = HF_yc.Value;
                        struct_ylgl.p_czfs = "05";
                        struct_ylgl.p_czxx = "位置：应急管理->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ylgl.Update_YLGLZT(struct_ylgl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已驳回，请先编辑再提交！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        struct_ylgl.p_bh = bh;
                        struct_ylgl.p_zt = "2";
                        struct_ylgl.p_bhyy = HF_yc.Value;
                        struct_ylgl.p_czfs = "06";
                        struct_ylgl.p_czxx = "位置：应急管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ylgl.Update_YLGLZT(struct_ylgl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (zt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        struct_ylgl.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_ylgl.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ylgl.p_bhyy = HF_yc.Value;
                            struct_ylgl.p_czfs = "06";
                            struct_ylgl.p_czxx = "位置：应急管理->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            ylgl.Update_YLGL_SJBS_ZT(struct_ylgl);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_ylgl.p_sjc = sjc;
                            struct_ylgl.p_bhyy = HF_yc.Value;
                            struct_ylgl.p_czfs = "06";
                            struct_ylgl.p_czxx = "位置：应急管理->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            ylgl.Update_YLGL_SJBS_LSSJ_ZT(struct_ylgl);

                            //将副本数据变为最终数据
                            struct_ylgl.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_ylgl.p_bhyy = HF_yc.Value;
                            struct_ylgl.p_czfs = "06";
                            struct_ylgl.p_czxx = "位置：应急管理->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            ylgl.Update_YAGL_SJBS_FBSJ_ZT(struct_ylgl);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能审核！\")</script>");
                        return;
                    }
                }
                else if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该预案信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "1")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_ylgl.p_bh = bh;
                        struct_ylgl.p_zt = "4";
                        struct_ylgl.p_bhyy = HF_yc.Value;
                        struct_ylgl.p_czfs = "07";
                        struct_ylgl.p_czxx = "位置：演练管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ylgl.Update_YLGLZT(struct_ylgl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能驳回！\")</script>");
                        return;
                    }
                }
                else if (zt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_ylgl.p_bh = bh;
                        struct_ylgl.p_zt = "4";
                        struct_ylgl.p_bhyy = HF_yc.Value;
                        struct_ylgl.p_czfs = "07";
                        struct_ylgl.p_czxx = "位置：应急管理->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        ylgl.Update_YLGLZT(struct_ylgl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该预案信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
            Bind();
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

        protected void rpt_ylgl_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in rpt_ylgl.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
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
        }


    }
}