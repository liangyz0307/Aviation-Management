using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sys;
using CUST.MKG;
using System.Data;
using CUST.Sys;
using CUST.Tools;
using System.Globalization;

namespace CUST.WKG
{
    public partial class SKJS_AQWTK : System.Web.UI.Page
    {
        private UserState _us;
        public int cpage;
        public int psize;
        private AQWTK aqwtk;
        private Struct_AQWTK struct_aqwtk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            aqwtk = new AQWTK(_us);
            struct_aqwtk = new Struct_AQWTK();
            if (!IsPostBack)
            {
                Bind();
                bind_Main();
                show();
                tbx_fssj_ks.Attributes.Add("readonly", "readonly");
                tbx_fssj_js.Attributes.Add("readonly", "readonly");
            }
        }
        protected void show()
        {
            Boolean flag_add = false;

            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_us.userID, "200402"))
            {
                btn_add.Visible = true;
            }
            if (flag_add) { btn_add.Visible = true; }
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SKJS_AQWTK_Add.aspx");
        }
        private void Bind()
        {
            //来源
            ddlt_ly.DataSource = SysData.LY().Copy();
            ddlt_ly.DataTextField = "mc";
            ddlt_ly.DataValueField = "bm";
            ddlt_ly.DataBind();
            ddlt_ly.Items.Insert(0, new ListItem("全部", "-1"));
            //涉及范畴
            ddlt_sjfc.DataSource = SysData.SJFC().Copy();
            ddlt_sjfc.DataTextField = "mc";
            ddlt_sjfc.DataValueField = "bm";
            ddlt_sjfc.DataBind();
            ddlt_sjfc.Items.Insert(0, new ListItem("全部", "-1"));
            //责任部门
            ddlt_zrbm.DataSource = SysData.BM().Copy();
            ddlt_zrbm.DataTextField = "mc";
            ddlt_zrbm.DataValueField = "bm";
            ddlt_zrbm.DataBind();
            ddlt_zrbm.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }

        private void bind_Main()
        {
            #region 判断
            if (tbx_fssj_ks.Text == "")
            {
                struct_aqwtk.p_fssj_ks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_aqwtk.p_fssj_ks = DateTime.Parse(tbx_fssj_ks.Text.ToString().Trim());
            }
            if (tbx_fssj_js.Text == "")
            {
                struct_aqwtk.p_fssj_js = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_aqwtk.p_fssj_js = DateTime.Parse(tbx_fssj_js.Text.ToString().Trim());
            }
            #endregion
            struct_aqwtk.p_ly = ddlt_ly.SelectedValue.Trim().ToString();
            struct_aqwtk.p_sjfc = ddlt_sjfc.Text.ToString().Trim();
            struct_aqwtk.p_zrbm = ddlt_zrbm.SelectedValue.Trim().ToString();
            struct_aqwtk.p_zt = ddlt_zt.SelectedValue.Trim().ToString();
            struct_aqwtk.p_userid = _us.userID;
            int count = aqwtk.Select_AQWTK_Count(struct_aqwtk);
            pg_fy.TotalRecord = count;
            struct_aqwtk.p_currentpage = pg_fy.CurrentPage;
            struct_aqwtk.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = aqwtk.Select_AQWTK(struct_aqwtk);
            dt.Columns.Add("lymc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sjfcmc");
            dt.Columns.Add("wtkzztmc");
            dt.Columns.Add("zrbmmc");
            dt.Columns.Add("fssjz");
            dt.Columns.Add("zgsxz");

            foreach (DataRow dr in dt.Rows)
            {

                dr["lymc"] = SysData.LYByKey(dr["ly"].ToString()).mc;
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;
                dr["sjfcmc"] = SysData.SJFCByKey(dr["sjfc"].ToString()).mc;
                dr["wtkzztmc"] = SysData.WTZTByKey(dr["wtkzzt"].ToString()).mc;
                dr["zrbmmc"] = SysData.BMByKey(dr["zrbm"].ToString()).mc;
                dr["fssjz"] = DateTime.Parse(dr["fssj"].ToString()).ToString("yyyy-MM-dd");
                dr["zgsxz"] = DateTime.Parse(dr["zgsx"].ToString()).ToString("yyyy-MM-dd");

            }
            //绑定分页数据源  
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_us.userID, bmdm, "200403"))
                    {
                        Server.Transfer("SKJS_AQWTK_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
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
                    if (lrr.Equals(_us.userLoginName))
                    {
                        Server.Transfer("SKJS_AQWTK_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
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
                struct_aqwtk = new Struct_AQWTK();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_us.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：四库建设->安全问题库->删除    描述：员工编号：[" + _us.userLoginName + "]";
                        aqwtk.Delete_AQWTK(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_us.userID, bmdm, "200404"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：四库建设->安全问题库->删除    描述：员工编号：[" + _us.userLoginName + "]";
                        aqwtk.Delete_AQWTK(id, p_czfs, p_czxx);
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
                struct_aqwtk = new Struct_AQWTK();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_us.userLoginName))
                    {
                        struct_aqwtk.p_id = Convert.ToString(id);
                        struct_aqwtk.p_zt = "1";
                        struct_aqwtk.p_bhyy = HF_yc.Value;
                        struct_aqwtk.p_czfs = "05";
                        struct_aqwtk.p_czxx = "位置：四库建设->安全问题库->改变状态（提交）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqwtk.Update_AQWTKZT(struct_aqwtk);
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
                    if (csr.Equals(_us.userLoginName))
                    {
                        struct_aqwtk.p_id = Convert.ToString(id);
                        struct_aqwtk.p_zt = "2";
                        struct_aqwtk.p_bhyy = HF_yc.Value;
                        struct_aqwtk.p_czfs = "06";
                        struct_aqwtk.p_czxx = "位置：四库建设->安全问题库->改变状态（审核）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqwtk.Update_AQWTKZT(struct_aqwtk);
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
                    if (zsr.Equals(_us.userLoginName))
                    {
                        struct_aqwtk.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_aqwtk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_aqwtk.p_bhyy = HF_yc.Value;
                            struct_aqwtk.p_czfs = "06";
                            struct_aqwtk.p_czxx = "位置：安全问题库->状态->改变状态（审核）    描述：员工编号：[" + _us.userLoginName + "]";
                            aqwtk.Update_AQWTK_SJBS_ZT(struct_aqwtk);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_aqwtk.p_sjc = sjc;
                            struct_aqwtk.p_bhyy = HF_yc.Value;
                            struct_aqwtk.p_czfs = "06";
                            struct_aqwtk.p_czxx = "位置：安全问题库->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _us.userLoginName + "]";
                            aqwtk.Update_AQWTK_SJBS_LSSJ_ZT(struct_aqwtk);

                            //将副本数据变为最终数据
                            struct_aqwtk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_aqwtk.p_bhyy = HF_yc.Value;
                            struct_aqwtk.p_czfs = "06";
                            struct_aqwtk.p_czxx = "位置：安全问题库->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _us.userLoginName + "]";
                            aqwtk.Update_AQWTK_SJBS_FBSJ_ZT(struct_aqwtk);
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
                    if (csr.Equals(_us.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_aqwtk.p_id =Convert.ToString( id);
                        struct_aqwtk.p_zt = "4";
                        struct_aqwtk.p_bhyy = HF_yc.Value;
                        struct_aqwtk.p_czfs = "07";
                        struct_aqwtk.p_czxx = "位置：安全问题库->状态->改变状态（驳回）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqwtk.Update_AQWTKZT(struct_aqwtk);
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
                    if (zsr.Equals(_us.userLoginName))
                    {
                        //执行update改变状态（驳回）
                        struct_aqwtk.p_id = Convert.ToString(id);
                        struct_aqwtk.p_zt = "4";
                        struct_aqwtk.p_bhyy = HF_yc.Value;
                        struct_aqwtk.p_czfs = "07";
                        struct_aqwtk.p_czxx = "位置：安全问题库->状态->改变状态（驳回）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqwtk.Update_AQWTKZT(struct_aqwtk);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
    }
}