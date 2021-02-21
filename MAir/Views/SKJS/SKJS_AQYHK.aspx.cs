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
    public partial class SKJS_AQYHK : System.Web.UI.Page
    {
        private UserState _us;
        public int cpage;
        public int psize;
        private AQYHK aqyhk;
        static string ygbh;
        private Struct_Select_AQYHK struct_select_aqyhk;
        private Struct_AQYHK struct_aqyhk;

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
            aqyhk = new AQYHK(_us);

            struct_select_aqyhk = new Struct_Select_AQYHK();
            if (!IsPostBack)
            {
                Bind();
                bind_Main();
                show();
                tbx_tbrq_ks.Attributes.Add("readonly", "readonly");
                tbx_tbrq_js.Attributes.Add("readonly", "readonly");
            }
        }
        //权限判断是否显示添加按钮
        protected void show()
        {
            #region 添加按钮
            Boolean flag_add = false;
            btn_add.Visible = false;
            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_us.userID, "200302"))
            {
                btn_add.Visible = true;
            }
            if (flag_add) { btn_add.Visible = true; }
          
            #endregion
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
        private void bind_Main()
        {
            #region 判断
            if (tbx_tbrq_ks.Text == "")
            {
                struct_select_aqyhk.p_tbrq_ks = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_select_aqyhk.p_tbrq_ks = DateTime.Parse(tbx_tbrq_ks.Text.ToString().Trim());
            }
            if (tbx_tbrq_js.Text == "")
            {
                struct_select_aqyhk.p_tbrq_js = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_select_aqyhk.p_tbrq_js = DateTime.Parse(tbx_tbrq_js.Text.ToString().Trim());
            }
            #endregion
            struct_select_aqyhk.p_ly = ddlt_ly.SelectedValue.Trim().ToString();
            struct_select_aqyhk.p_zt = ddlt_zt.SelectedValue.Trim().ToString();
            struct_select_aqyhk.p_yhdj = ddlt_yhdj.SelectedValue.Trim().ToString();
            struct_select_aqyhk.p_ygbh = tbx_ygbh.Text.ToString().Trim();
            struct_select_aqyhk.p_userid = _us. userID;
            int count = aqyhk.Select_AQYHK_Count(struct_select_aqyhk);
            pg_fy.TotalRecord = count;
            struct_select_aqyhk.p_currentpage = pg_fy.CurrentPage;
            struct_select_aqyhk.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = aqyhk.Select_AQYHK_Pro(struct_select_aqyhk);
            dt.Columns.Add("tbdwmc");
            dt.Columns.Add("yhdjmc");
            dt.Columns.Add("zgzrdwmc");
            dt.Columns.Add("zggbpzmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("yhfxsjz");
            dt.Columns.Add("zgwcsxz");

            foreach (DataRow dr in dt.Rows)
            {
                string[] Array_zgzzr = dr["zgzrr"].ToString().Split(',');
                string[] Array_zgdbzrr = dr["zgdbzrr"].ToString().Split(',');
                string[] Array_zgyzr = dr["zgyzr"].ToString().Split(',');
                dr["tbdwmc"] = SysData.BMByKey(dr["tbdw"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["yhdjmc"] = SysData.YHDJByKey(dr["yhdj"].ToString()).mc;
                dr["zgzrdwmc"] = SysData.BMByKey(dr["zgzrdw"].ToString()).mc;
                dr["zggbpzmc"] = SysData.ZGGBPZByKey(dr["zggbpz"].ToString()).mc;
                dr["yhfxsjz"] = DateTime.Parse(dr["yhfxsj"].ToString()).ToString("yyyy-MM-dd");
                dr["zgwcsxz"] = DateTime.Parse(dr["zgwcsx"].ToString()).ToString("yyyy-MM-dd");
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SKJS_AQYHK_Add.aspx");
        }
        private void Bind()
        {
            //隐患等级
            ddlt_yhdj.DataSource = SysData.YHDJ().Copy();
            ddlt_yhdj.DataTextField = "mc";
            ddlt_yhdj.DataValueField = "bm";
            ddlt_yhdj.DataBind();
            ddlt_yhdj.Items.Insert(0, new ListItem("全部", "-1"));
            //来源
            ddlt_ly.DataSource = SysData.LY().Copy();
            ddlt_ly.DataTextField = "mc";
            ddlt_ly.DataValueField = "bm";
            ddlt_ly.DataBind();
            ddlt_ly.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
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
                    if (SysData.HasThisBMQX(_us.userID, bmdm, "200303"))
                    {
                        Server.Transfer("SKJS_AQYHK_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
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
                        Server.Transfer("SKJS_AQYHK_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
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
                struct_aqyhk = new Struct_AQYHK();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_us.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：安全隐患库->安全隐患库管理->奖励    描述：员工编号：[" + _us.userLoginName + "]";
                        aqyhk.Delete_AQYHK(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_us.userID, bmdm, "200304"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：安全隐患库->安全隐患库管理->奖励    描述：员工编号：[" + _us.userLoginName + "]";
                        aqyhk.Delete_AQYHK(id, p_czfs, p_czxx);
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
                struct_aqyhk = new Struct_AQYHK();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_us.userLoginName))
                    {
                        struct_aqyhk.p_id = Convert.ToString(id);
                        struct_aqyhk.p_zt = "1";
                        struct_aqyhk.p_bhyy = HF_yc.Value;
                        struct_aqyhk.p_czfs = "05";
                        struct_aqyhk.p_czxx = "位置：安全隐患库->状态->改变状态（提交）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqyhk.Update_AQYHKZT(struct_aqyhk);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_aqyhk.p_id = Convert.ToString(id);
                        struct_aqyhk.p_zt = "2";
                        struct_aqyhk.p_bhyy = HF_yc.Value;
                        struct_aqyhk.p_czfs = "06";
                        struct_aqyhk.p_czxx = "位置：安全隐患库->状态->改变状态（审核）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqyhk.Update_AQYHKZT(struct_aqyhk);
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
                        struct_aqyhk.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_aqyhk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_aqyhk.p_bhyy = HF_yc.Value;
                            struct_aqyhk.p_czfs = "06";
                            struct_aqyhk.p_czxx = "位置：安全隐患库->状态->改变状态（审核）    描述：员工编号：[" + _us.userLoginName + "]";
                            aqyhk.Update_AQYHK_SJBS_ZT(struct_aqyhk);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_aqyhk.p_sjc = sjc;
                            struct_aqyhk.p_bhyy = HF_yc.Value;
                            struct_aqyhk.p_czfs = "06";
                            struct_aqyhk.p_czxx = "位置：安全隐患库->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _us.userLoginName + "]";
                            aqyhk.Update_AQYHK_SJBS_LSSJ_ZT(struct_aqyhk);

                            //将副本数据变为最终数据
                            struct_aqyhk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_aqyhk.p_bhyy = HF_yc.Value;
                            struct_aqyhk.p_czfs = "06";
                            struct_aqyhk.p_czxx = "位置：安全隐患库->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _us.userLoginName + "]";
                            aqyhk.Update_AQYHK_SJBS_FBSJ_ZT(struct_aqyhk);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该安全隐患库信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_aqyhk.p_id = Convert.ToString(id);
                        struct_aqyhk.p_zt = "4";
                        struct_aqyhk.p_bhyy = HF_yc.Value;
                        struct_aqyhk.p_czfs = "07";
                        struct_aqyhk.p_czxx = "位置：安全隐患库->状态->改变状态（驳回）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqyhk.Update_AQYHKZT(struct_aqyhk);
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
                        struct_aqyhk.p_id = Convert.ToString(id); 
                        struct_aqyhk.p_zt = "4";
                        struct_aqyhk.p_bhyy = HF_yc.Value;
                        struct_aqyhk.p_czfs = "07";
                        struct_aqyhk.p_czxx = "位置：安全隐患库->状态->改变状态（驳回）    描述：员工编号：[" + _us.userLoginName + "]";
                        aqyhk.Update_AQYHKZT(struct_aqyhk);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该安全隐患库信息已驳回，不可重复驳回！\")</script>");
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
