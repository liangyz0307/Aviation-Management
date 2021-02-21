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
    public partial class SKJS_ZJK : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private ZJK zjk;
        private Struct_ZJK_Pro struct_zjk;
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
            zjk = new ZJK(_usState);
            struct_zjk = new Struct_ZJK_Pro();
            if (!IsPostBack)
            {
                ddltBind();
                show();
                bind_Main();
            }
        }
       public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "200502") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void ddltBind()
        {
            

            //部门
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //奖励等级
            ddlt_zjlx.DataSource = SysData.ZJLX().Copy();
            ddlt_zjlx.DataTextField = "mc";
            ddlt_zjlx.DataValueField = "bm";
            ddlt_zjlx.DataBind();
            ddlt_zjlx.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            struct_zjk.p_xm = tbx_xm.Text.Trim().ToString();
            struct_zjk.p_bmdm = ddlt_bmdm.SelectedValue.Trim().ToString();//部门代码
            struct_zjk.p_zjlx = ddlt_zjlx.SelectedValue.Trim().ToString();
            struct_zjk.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态

            struct_zjk.p_userid = _usState.userID;
            DataTable dt = new DataTable();
            int count = zjk.Select_ZJK_Count(struct_zjk);
            pg_fy.TotalRecord = count;
            struct_zjk.p_currentpage = pg_fy.CurrentPage;
            struct_zjk.p_pagesize = pg_fy.NumPerPage;
            dt = zjk.Select_ZJK_Pro(struct_zjk);

            dt.Columns.Add("bm");
            dt.Columns.Add("zjlxmc");
            dt.Columns.Add("ztmc");
 
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["zjlxmc"] = SysData.ZJLXByKey(dr["zjlx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200503"))
                    {
                        Server.Transfer("ZJK_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("ZJK_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_zjk = new Struct_ZJK_Pro();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：五库建设->专家管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        zjk.Delete_ZJK(id, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200504"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：五库建设->专家管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        zjk.Delete_ZJK(id, p_czfs, p_czxx);
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
                struct_zjk = new Struct_ZJK_Pro();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_zjk.p_id = id;
                        struct_zjk.p_zt = "1";
                        struct_zjk.p_bhyy = HF_yc.Value;
                        struct_zjk.p_czfs = "05";
                        struct_zjk.p_czxx = "位置：五库建设->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zjk.Update_ZJKZT(struct_zjk);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1105", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_zjk.p_id = id;
                        struct_zjk.p_zt = "2";
                        struct_zjk.p_bhyy = HF_yc.Value;
                        struct_zjk.p_czfs = "06";
                        struct_zjk.p_czxx = "位置：五库建设->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zjk.Update_ZJKZT(struct_zjk);
                        SysData.Delete_TSR(csr, "11", "1105", id);
                        SysData.Insert_TSR(zsr, "11", "1105", id);
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
                        struct_zjk.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_zjk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_zjk.p_bhyy = HF_yc.Value;
                            struct_zjk.p_czfs = "06";
                            struct_zjk.p_czxx = "位置：五库建设->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            zjk.Update_ZJK_SJBS_ZT(struct_zjk);
                            SysData.Delete_TSR(zsr, "20", "2005", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_zjk.p_sjc = sjc;
                            struct_zjk.p_bhyy = HF_yc.Value;
                            struct_zjk.p_czfs = "06";
                            struct_zjk.p_czxx = "位置：五库建设->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            zjk.Update_ZJK_SJBS_LSSJ_ZT(struct_zjk);

                            //将副本数据变为最终数据
                            struct_zjk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_zjk.p_bhyy = HF_yc.Value;
                            struct_zjk.p_czfs = "06";
                            struct_zjk.p_czxx = "位置：五库建设->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            zjk.Update_ZJK_SJBS_FBSJ_ZT(struct_zjk);
                            SysData.Delete_TSR(zsr, "20", "2005", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该专家信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_zjk.p_id = id;
                        struct_zjk.p_zt = "4";
                        struct_zjk.p_bhyy = HF_yc.Value;
                        struct_zjk.p_czfs = "07";
                        struct_zjk.p_czxx = "位置：五库建设->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zjk.Update_ZJKZT(struct_zjk);
                        SysData.Delete_TSR(csr, "20", "2005", id);
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
                        struct_zjk.p_id = id;
                        struct_zjk.p_zt = "4";
                        struct_zjk.p_bhyy = HF_yc.Value;
                        struct_zjk.p_czfs = "07";
                        struct_zjk.p_czxx = "位置：五库建设->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zjk.Update_ZJKZT(struct_zjk);
                        SysData.Delete_TSR(zsr, "20", "2005", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该专家信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
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
            Response.Redirect("../SKJS/ZJK_Add.aspx", false);
        }





















    }
}