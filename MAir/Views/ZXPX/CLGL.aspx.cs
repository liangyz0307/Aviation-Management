using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace CUST.WKG
{
    public partial class CLGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private ZJ_CL cl;
        static DataTable dt_cl;
        private Struct_Select_ZJ_CL struct_cl;
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
            cl = new ZJ_CL(_usState);
            if (!IsPostBack)
            {
                ddltBind();
                Bind_Select();
            }
        }
        private void ddltBind()
        {
            //试题难度
            ddlt_stnd.DataTextField = "mc";
            ddlt_stnd.DataValueField = "bm";
            ddlt_stnd.DataSource = SysData.STND().Copy();
            ddlt_stnd.DataBind();
            ddlt_stnd.Items.Insert(0, new ListItem("全部", "-1"));
            //科目
            ddlt_km.DataTextField = "mc";
            ddlt_km.DataValueField = "bm";
            ddlt_km.DataSource = SysData.KM().Copy();
            ddlt_km.DataBind();
            ddlt_km.Items.Insert(0, new ListItem("全部", "-1"));
            //类别
            ddlt_lb.DataTextField = "mc";
            ddlt_lb.DataValueField = "bm";
            ddlt_lb.DataSource = SysData.STLB().Copy();
            ddlt_lb.DataBind();
            ddlt_lb.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataSource = SysData.STZT().Copy();
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Bind_Select()
        {
            cbk_qx.Checked = false;
            struct_cl = new Struct_Select_ZJ_CL();
            struct_cl.p_mc = tbx_mc.Text.Trim();
            struct_cl.p_nd = ddlt_stnd.SelectedValue.ToString();
            struct_cl.p_km = ddlt_km.SelectedValue.ToString();
            struct_cl.p_lb = ddlt_lb.SelectedValue.ToString();
            struct_cl.p_gw = ddlt_gw.SelectedValue.ToString();
            struct_cl.p_zt = ddlt_zt.SelectedValue.ToString();
            struct_cl.p_currentpage = pg_fy.CurrentPage;
            struct_cl.p_pagesize = pg_fy.NumPerPage;
            int count = cl.Select_ZJ_CL_Count(struct_cl);
            dt_cl = cl.Select_ZJ_CL_Pro(struct_cl);
            pg_fy.TotalRecord = count;
            dt_cl.Columns.Add("stnd");
            dt_cl.Columns.Add("sykm");
            dt_cl.Columns.Add("stlb");
            dt_cl.Columns.Add("sygw");
            dt_cl.Columns.Add("ztdm");
            foreach (DataRow dr in dt_cl.Rows)
            {
                dr["stnd"] = SysData.STNDByKey(dr["nd"].ToString()).mc;
                dr["sykm"] = SysData.KMByKey(dr["km"].ToString()).mc;
                dr["sygw"] = SysData.GWByKey(dr["gw"].ToString()).mc;
                dr["ztdm"] = SysData.STZTByKey(dr["zt"].ToString()).mc;
                //类别
                string str_stlb = dr["lb"].ToString();
                string[] arr_stlb = str_stlb.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string stlb = "";
                for (int i = 0; i < arr_stlb.Length; i++)
                {
                   stlb+=SysData.STLBByKey(arr_stlb[i]).mc+";";
                }
                dr["stlb"] = stlb;
            }
            //绑定分页数据源  
            this.dlt_cl.DataSource = dt_cl.DefaultView;
            this.dlt_cl.DataBind();
            ShowButtonByZT();
        }
        private void ShowButtonByZT()
        {
            //1.是否具有添加的权限
            btn_add.Visible = SysData.HasThisQX("190202", _usState.userID);
            string zt = ddlt_zt.SelectedValue;
            if (zt == "-1")
            {
                btn_sc.Visible = false;
                btn_tj.Visible = false;
                btn_shtg.Visible = false;
                btn_bh.Visible = false;
            }
            else if (zt == "0")
            {//保存 可以提交和删除，判断是否有提交的权限
                btn_sc.Visible = SysData.HasThisQX("190204", _usState.userID);
                btn_tj.Visible = SysData.HasThisQX("190205", _usState.userID);
                btn_shtg.Visible = false;
                btn_bh.Visible = false;
            }
            else if (zt == "1")//提交未审核状态   需要判断 是否具有审核和 驳回的权限 
            {
                btn_sc.Visible = false;
                btn_tj.Visible = false;
                btn_shtg.Visible = SysData.HasThisQX("190206", _usState.userID);
                btn_bh.Visible = SysData.HasThisQX("190207", _usState.userID);
            }
            else if (zt == "2")
            { //审核通过 只能驳回，判断是否  可以 驳回的权限
                btn_sc.Visible = false;
                btn_tj.Visible = false;
                btn_shtg.Visible = false;
                btn_bh.Visible = SysData.HasThisQX("190207", _usState.userID);
            }
        }
        protected void dlt_cl_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string[] Comargs = e.CommandArgument.ToString().Split('&');
            string id = Comargs[0];
            string zt = Comargs[1];
            if (e.CommandName == "Update")
            {
                if (zt != "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据不是保存状态，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "0")
                {
                    Response.Redirect("../ZXPX/CL_Update.aspx?id=" + id, true);
                }
            }
            else if (e.CommandName == "Delete")
            {
                if (zt != "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据不是保存状态，不能删除！\")</script>");
                    return;
                }
                else if (zt == "0")
                {
                    try
                    {
                        long L_id = Convert.ToInt64(id);
                        DataTable dt_detail = new DataTable();
                        dt_detail = cl.Select_ZJ_CL_Detail(L_id);
                        string p_czxx = "位置：在线培训->组卷策略管理->策略删除    描述：策略编号" + id;
                        cl.Delete_ZJ_CL_byID(L_id, "03", p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    catch (EMException ex)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                        return;
                    }
                }
            }
            Bind_Select();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            Bind_Select();
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
        #region btn
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZXPX/CL_Add.aspx", false);
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            Bind_Select();
        }
        protected void btn_sc_Click(object sender, EventArgs e)
        {
            string zt = null;
            int count = 0;
            foreach (DataListItem li in dlt_cl.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要删除的策略信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_cl.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_cl.Rows[li.ItemIndex];
                        zt = dr["zt"].ToString();
                        if (zt != "0")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据不是未提交状态，不能删除！\")</script>");
                            return;
                        }
                        long id = Convert.ToInt64(dlt_cl.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->组卷策略管理->策略删除    描述：策略编号" + id;
                        cl.Delete_ZJ_CL_byID(id, "03", p_czxx);
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                Bind_Select();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
            }
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_tj_Click(object sender, EventArgs e)
        {
            string zt = null;
            int count = 0;
            foreach (DataListItem li in dlt_cl.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要提交的策略信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_cl.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_cl.Rows[li.ItemIndex];
                        zt = dr["zt"].ToString();
                        if (zt != "0")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据不是未提交状态，不能提交！\")</script>");
                            return;
                        }
                        long id = Convert.ToInt64(dlt_cl.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->组卷策略管理->策略审核  提交数据   描述：策略编号" + id + ";";
                        Struct_SH struct_sh = new Struct_SH();
                        struct_sh.p_id = id;
                        struct_sh.p_zt = "1";
                        struct_sh.p_czfs = "08";
                        struct_sh.p_czxx = p_czxx;
                        cl.Update_ZJ_CL_TJ(struct_sh);
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"提交成功！\")</script>");
                Bind_Select();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_shtg_Click(object sender, EventArgs e)
        {
            string zt = null;
            int count = 0;
            foreach (DataListItem li in dlt_cl.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要审核的策略信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_cl.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_cl.Rows[li.ItemIndex];
                        zt = dr["zt"].ToString();
                        if (zt != "1")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据不是已提交状态，不能审核！\")</script>");
                            return;
                        }
                        long id = Convert.ToInt64(dlt_cl.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->组卷策略管理->策略审核  审核通过    描述：策略编号" + id + ";";
                        Struct_SH struct_sh = new Struct_SH();
                        struct_sh.p_id = id;
                        struct_sh.p_zt = "2";
                        struct_sh.p_czfs = "07";
                        struct_sh.p_czxx = p_czxx;
                        cl.Update_ZJ_CL_SHTG(struct_sh);
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"审核通过成功！\")</script>");
                Bind_Select();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_bh_Click(object sender, EventArgs e)
        {
            string zt = null;
            int count = 0;
            foreach (DataListItem li in dlt_cl.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要驳回的策略信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_cl.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_cl.Rows[li.ItemIndex];
                        zt = dr["zt"].ToString();
                        if (zt == "0")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据未提交，不能驳回！\")</script>");
                            return;
                        }
                        string bhyy = HF_yc.Value;
                        long id = Convert.ToInt64(dlt_cl.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->组卷策略管理->策略驳回    描述：策略编号" + id + ";";
                        if (bhyy != "")
                        {
                            p_czxx += " 驳回原因：【" + bhyy + "】";
                        }
                        Struct_SH struct_sh = new Struct_SH();
                        struct_sh.p_id = id;
                        struct_sh.p_zt = "0";
                        struct_sh.p_yysm = bhyy;
                        struct_sh.p_czfs = "06";
                        struct_sh.p_czxx = p_czxx;
                        cl.Update_ZJ_CL_BH(struct_sh);
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"驳回成功！\")</script>");
                Bind_Select();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        #endregion
        protected void dlt_cl_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            LinkButton lbtUpdate = (LinkButton)e.Item.FindControl("lbtUpdate");
            LinkButton lbtDelete = (LinkButton)e.Item.FindControl("lbtDelete");
            HtmlControl title_cz = (HtmlTableCell)e.Item.FindControl("title_cz");
            HtmlControl nr_cz = (HtmlTableCell)e.Item.FindControl("nr_cz");
            if (title_cz != null)
            {
                if ((SysData.HasThisQX("190203", _usState.userID)) || (SysData.HasThisQX("190204", _usState.userID)))
                {
                    title_cz.Visible = true;
                }
                else
                {
                    title_cz.Visible = false;
                }
            }
            if (nr_cz != null)
            {
                if ((SysData.HasThisQX("190203", _usState.userID)) || (SysData.HasThisQX("190204", _usState.userID)))
                {
                    nr_cz.Visible = true;
                }
                else
                {
                    nr_cz.Visible = false;
                }
            }
            //1.是否具有  编辑  的权限
            if (lbtUpdate != null)
            {
                lbtUpdate.Visible = SysData.HasThisQX("190203", _usState.userID);
            }
            if (lbtDelete != null)
            {
                //是否具有删除的权限
                lbtDelete.Visible = SysData.HasThisQX("190204", _usState.userID);
            }
        }
    }
}
