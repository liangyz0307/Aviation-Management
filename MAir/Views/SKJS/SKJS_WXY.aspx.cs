using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using CUST.MKG;
using CUST.Sys;
using System.Data;
using Sys;
using CUST.Tools;
using System.Web.UI.WebControls;
using System.Globalization;

namespace CUST.WKG
{
    public partial class SKJS_WXY : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private WXY wxy;
        private Struct_WXY struct_wxy;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            wxy = new WXY(_usState);
            struct_wxy = new Struct_WXY();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
                show();
            }
        }

        protected void show()
        {
            Boolean flag_add = false;

            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "200202"))
            {
                btn_add.Visible = true;
            }
            if (flag_add) { btn_add.Visible = true; }
        }
        private void ddltBind()
        {
            //状态
            ddlt_zt.DataSource = SysData.FXYZT().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
            //控制状态
            ddlt_kzzt.DataSource = SysData.FXKZZT().Copy();
            ddlt_kzzt.DataTextField = "mc";
            ddlt_kzzt.DataValueField = "bm";
            ddlt_kzzt.DataBind();
            ddlt_kzzt.Items.Insert(0, new ListItem("全部", "-1"));
            //报送岗位
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
        }

        private void bind_Main()
        {
            struct_wxy.p_userid = _usState. userID;
            struct_wxy.p_mc = tbx_mc.Text.ToString().Trim();
            struct_wxy.p_gw = ddlt_gw.SelectedValue.ToString().Trim();//报送岗位
            struct_wxy.p_kzzt = ddlt_kzzt.SelectedValue.ToString().Trim();//控制状态
            struct_wxy.p_zt = ddlt_zt.SelectedValue.ToString().Trim();//状态
            int count = wxy.Select_WXY_Count(struct_wxy);
            pg_fy.TotalRecord = count;
            struct_wxy.p_currentpage = pg_fy.CurrentPage;
            struct_wxy.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = wxy.Select_WXY_Pro(struct_wxy);
            dt.Columns.Add("gwmc");
            dt.Columns.Add("stmc");
            dt.Columns.Add("wztmc");
            dt.Columns.Add("knxmc");
            dt.Columns.Add("kzztmc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["gwmc"] = SysData.GWByKey(dr["gw"].ToString()).mc;
                dr["stmc"] = SysData.STDMByKey(dr["st"].ToString()).mc;
                dr["knxmc"] = SysData.FXFSKNByKey(dr["knx"].ToString()).mc;
                dr["kzztmc"] = SysData.FXKZZTByKey(dr["kzzt"].ToString()).mc;
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SKJS/SKJS_WXY_Add.aspx", true);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200203"))
                    {
                        Server.Transfer("SKJS_WXY_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
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
                        Server.Transfer("SKJS_WXY_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
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
                struct_wxy = new Struct_WXY();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：三库建设->安全隐患库->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                        wxy.Delete_WXY(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：三库建设->安全隐患库->删除     描述：员工编号：[" + _usState.userLoginName + "]";
                        wxy.Delete_WXY(id, p_czfs, p_czxx);
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
                struct_wxy = new Struct_WXY();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_wxy.p_id = id;
                        struct_wxy.p_zt = "1";
                        struct_wxy.p_bhyy = HF_yc.Value;
                        struct_wxy.p_czfs = "05";
                        struct_wxy.p_czxx = "位置：安全隐患库->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wxy.Update_WXYZT(struct_wxy);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_wxy.p_id = id;
                        struct_wxy.p_zt = "2";
                        struct_wxy.p_bhyy = HF_yc.Value;
                        struct_wxy.p_czfs = "06";
                        struct_wxy.p_czxx = "位置：安全隐患库->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wxy.Update_WXYZT(struct_wxy);
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
                        struct_wxy.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_wxy.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_wxy.p_bhyy = HF_yc.Value;
                            struct_wxy.p_czfs = "06";
                            struct_wxy.p_czxx = "位置：安全隐患库->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            wxy.Update_WXY_SJBS_ZT(struct_wxy);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_wxy.p_sjc = sjc;
                            struct_wxy.p_bhyy = HF_yc.Value;
                            struct_wxy.p_czfs = "06";
                            struct_wxy.p_czxx = "位置：安全隐患库->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            wxy.Update_WXY_SJBS_LSSJ_ZT(struct_wxy);

                            //将副本数据变为最终数据
                            struct_wxy.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_wxy.p_bhyy = HF_yc.Value;
                            struct_wxy.p_czfs = "06";
                            struct_wxy.p_czxx = "位置：安全隐患库->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            wxy.Update_WXY_SJBS_FBSJ_ZT(struct_wxy);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_wxy.p_id = id;
                        struct_wxy.p_zt = "4";
                        struct_wxy.p_bhyy = HF_yc.Value;
                        struct_wxy.p_czfs = "07";
                        struct_wxy.p_czxx = "位置：安全隐患库->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wxy.Update_WXYZT(struct_wxy);
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
                        struct_wxy.p_id = id;
                        struct_wxy.p_zt = "4";
                        struct_wxy.p_bhyy = HF_yc.Value;
                        struct_wxy.p_czfs = "07";
                        struct_wxy.p_czxx = "位置：员工培训->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wxy.Update_WXYZT(struct_wxy);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

        protected void tbx_bsygbh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}