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
    public partial class BS_ZBGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        public ZBGL zbgl;
        private Struct_ZBGL struct_zbgl;
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
            zbgl = new ZBGL(_usState);
            struct_zbgl = new Struct_ZBGL();
            if (!IsPostBack)
            {
               ddltBind();
                bind_Main();
                show();
            }
        }
        #region 判断用户是否有添加权限
        public void show()
        {

            Boolean flag_add = false;

            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "130502") == true)
            {
                flag_add = true;
            }

            if (flag_add) { btn_add.Visible = true; }

        }
        #endregion

        #region  绑定下拉菜单
        private void ddltBind()
        {
            //星期
            ddlt_xq.DataTextField = "mc";
            ddlt_xq.DataValueField = "bm";
            ddlt_xq.DataSource = SysData.XQ().Copy();
            ddlt_xq.DataBind();
            ddlt_xq.Items.Insert(0, new ListItem("全部", "-1"));


            //所属机场
            ddlt_jc.DataTextField = "mc";
            ddlt_jc.DataValueField = "bm";
            ddlt_jc.DataSource = SysData.ZXDM().Copy();
            ddlt_jc.DataBind();
            ddlt_jc.Items.Insert(0, new ListItem("全部", "-1"));

            //部门
            ddlt_bm.DataSource = SysData.BM().Copy();
            ddlt_bm.DataTextField = "mc";
            ddlt_bm.DataValueField = "bm";
            ddlt_bm.DataBind();
            ddlt_bm.Items.Insert(0, new ListItem("全部", "-1"));
            
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        #endregion

        private void bind_Main()
        {
            struct_zbgl.p_xq = ddlt_xq.SelectedValue.ToString();
            struct_zbgl.p_jc = ddlt_jc.SelectedValue.ToString();
            struct_zbgl.p_bm = ddlt_bm.SelectedValue.ToString();
            struct_zbgl.p_zt = ddlt_zt.SelectedValue.ToString();
            struct_zbgl.p_userid = _usState.userID;

            DataTable dt = new DataTable();
            int count = zbgl.Select_ZBGL_Count(struct_zbgl);
            pg_fy.TotalRecord = count;
            struct_zbgl.p_currentpage = pg_fy.CurrentPage;
            struct_zbgl.p_pagesize = pg_fy.NumPerPage;
            dt = zbgl.Select_ZBGL_Pro(struct_zbgl);

            
            dt.Columns.Add("jcmc");
            dt.Columns.Add("xqmc");
            dt.Columns.Add("bmmc");
            dt.Columns.Add("sjssbm");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("rqmc");
            DateTime dt_rq = new DateTime();

            foreach (DataRow dr in dt.Rows)
            {
                dr["jcmc"] = SysData.ZXDMByKey(dr["jc"].ToString()).mc;   
                dr["xqmc"] = SysData.XQByKey(dr["xq"].ToString()).mc;
                dr["bmmc"] = SysData.BMByKey(dr["bm"].ToString()).mc;//部门
                dr["sjssbm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//数据所属部门
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dt_rq = Convert.ToDateTime(dr["rq"].ToString());
                dr["rqmc"] = string.Format("{0:yyyy-MM-dd}", dt_rq);

            }


            ///绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int id = Convert.ToInt32(content[0]);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130503"))
                    {
                        Server.Transfer("BS_ZBGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("BS_ZBGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_zbgl = new Struct_ZBGL();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：值班表->值班表管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                        zbgl.Delete_ZBGL(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130504"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：值班表->值班表管理->职称    描述：员工编号：[" + _usState.userLoginName + "]";
                        zbgl.Delete_ZBGL(id, p_czfs, p_czxx);
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
                struct_zbgl = new Struct_ZBGL();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_zbgl.p_id = id;
                        struct_zbgl.p_zt = "1";
                        struct_zbgl.p_bhyy = HF_yc.Value;
                        struct_zbgl.p_czfs = "05";
                        struct_zbgl.p_czxx = "位置：值班表->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zbgl.Update_ZBGLZT(struct_zbgl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_zbgl.p_id = id;
                        struct_zbgl.p_zt = "2";
                        struct_zbgl.p_bhyy = HF_yc.Value;
                        struct_zbgl.p_czfs = "06";
                        struct_zbgl.p_czxx = "位置：值班表->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zbgl.Update_ZBGLZT(struct_zbgl);
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
                        struct_zbgl.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_zbgl.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_zbgl.p_bhyy = HF_yc.Value;
                            struct_zbgl.p_czfs = "06";
                            struct_zbgl.p_czxx = "位置：值班表->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            zbgl.Update_ZBGL_SJBS_ZT(struct_zbgl);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_zbgl.p_sjc = sjc;
                            struct_zbgl.p_bhyy = HF_yc.Value;
                            struct_zbgl.p_czfs = "06";
                            struct_zbgl.p_czxx = "位置：值班表->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            zbgl.Update_ZBGL_SJBS_LSSJ_ZT(struct_zbgl);

                            //将副本数据变为最终数据
                            struct_zbgl.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_zbgl.p_bhyy = HF_yc.Value;
                            struct_zbgl.p_czfs = "06";
                            struct_zbgl.p_czxx = "位置：值班表->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            zbgl.Update_ZBGL_SJBS_FBSJ_ZT(struct_zbgl);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该值班表信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_zbgl.p_id = id;
                        struct_zbgl.p_zt = "4";
                        struct_zbgl.p_bhyy = HF_yc.Value;
                        struct_zbgl.p_czfs = "07";
                        struct_zbgl.p_czxx = "位置：值班表->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zbgl.Update_ZBGLZT(struct_zbgl);
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
                        struct_zbgl.p_id = id;
                        struct_zbgl.p_zt = "4";
                        struct_zbgl.p_bhyy = HF_yc.Value;
                        struct_zbgl.p_czfs = "07";
                        struct_zbgl.p_czxx = "位置：值班表->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zbgl.Update_ZBGLZT(struct_zbgl);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该值班表信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "CZGL")
            {
                if (SysData.HasThisBMQX(_usState.userID, bmdm, "130503"))
                {
                    //点击操作管理跳转到操作页面
                    Response.Redirect("BS_ZBGL_CZ.aspx?id=" + id );
                    
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有操作权限！\")</script>");
                    return;
                }

            }
            bind_Main();
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
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_byyx");
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_ZBGL_Add.aspx", false);
        }

    }
}