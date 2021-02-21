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
    public partial class STGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private XZT xzt;
        private PDT pdt;
        private TKT tkt;
        static DataTable dt_st;
        private Struct_Select_ST struct_st;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage; ;
            xzt = new XZT(_usState);
            pdt = new PDT(_usState);
            tkt = new TKT(_usState);
            HF_delete.Value = ddlt_stlx.SelectedValue;
            if (!IsPostBack)
            {
                ddltBind();
                ShowButtonByZT_QX();
                HF_delete.Value = ddlt_stlx.SelectedValue;
                Bind_Select();
            }
        }
        private void ShowButtonByZT_QX()
        {
            //1.是否具有添加的权限
            btn_add.Visible = SysData.HasThisQX("190102", _usState.userID);
            string zt = ddlt_zt.SelectedValue;
            if (zt == "-1")//状态未选择的情况下，什么都不显示，不用判断
            {
                btn_sc.Visible = false;
                btn_tj.Visible = false;
                btn_shtg.Visible = false;
                btn_bh.Visible = false;
            }
            else if (zt == "0")//状态等于0，可以提交和删除，判断是否有提交的权限
            {//保存
                btn_sc.Visible = SysData.HasThisQX("190104", _usState.userID);
                btn_tj.Visible = SysData.HasThisQX("190105", _usState.userID);
                btn_shtg.Visible = false;
                btn_bh.Visible = false;
            }
            else if (zt == "1")//提交未审核状态，需要判断 是否具有审核和 驳回的权限
            {
                btn_sc.Visible = false;
                btn_tj.Visible = false;
                btn_shtg.Visible = SysData.HasThisQX("190106", _usState.userID);
                btn_bh.Visible = SysData.HasThisQX("190107", _usState.userID);
            }
            else if (zt == "2")
            { //审核通过，只能驳回，判断是否  可以 驳回的权限
                btn_sc.Visible = false;
                btn_tj.Visible = false;
                btn_shtg.Visible = false;
                btn_bh.Visible = SysData.HasThisQX("190107", _usState.userID);
            }
        }
        private void ddltBind()
        {
            //试题类型
            ddlt_stlx.DataTextField = "mc";
            ddlt_stlx.DataValueField = "bm";
            ddlt_stlx.DataSource = SysData.STLX().Copy();
            ddlt_stlx.DataBind();
            ddlt_stlx.SelectedIndex = 0;//默认选择题
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
            ddlt_stlb.DataTextField = "mc";
            ddlt_stlb.DataValueField = "bm";
            ddlt_stlb.DataSource = SysData.STLB().Copy();
            ddlt_stlb.DataBind();
            ddlt_stlb.Items.Insert(0, new ListItem("全部", "-1"));

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
            struct_st = new Struct_Select_ST();
            struct_st.p_tg = tbx_tg.Text.Trim();
            struct_st.p_nd = ddlt_stnd.SelectedValue.ToString();
            struct_st.p_km = ddlt_km.SelectedValue.ToString();
            struct_st.p_lb = ddlt_stlb.SelectedValue.ToString();
            struct_st.p_gw = ddlt_gw.SelectedValue.ToString();
            struct_st.p_zt = ddlt_zt.SelectedValue.ToString();
            string stlx = ddlt_stlx.SelectedValue.ToString();
            HF_delete.Value = ddlt_stlx.SelectedValue;
            struct_st.p_currentpage = pg_fy.CurrentPage;
            struct_st.p_pagesize = pg_fy.NumPerPage;
            int count = 0;
            if (stlx == "0")
            {
                struct_st.p_sfdx = "0";//单选
                count = xzt.Select_XZT_Count(struct_st);
                dt_st = xzt.Select_XZT_Pro(struct_st);
            }
            else if (stlx == "1")
            {
                count = pdt.Select_PDT_Count(struct_st);
                dt_st = pdt.Select_PDT_Pro(struct_st);
            }
            else if (stlx == "2")
            {
                count = tkt.Select_TKT_Count(struct_st);
                dt_st = tkt.Select_TKT_Pro(struct_st);
            }
            else if (stlx == "3")
            {
                struct_st.p_sfdx = "1";//多选
                count = xzt.Select_XZT_Count(struct_st);
                dt_st = xzt.Select_XZT_Pro(struct_st);
            }
            pg_fy.TotalRecord = count;
            dt_st.Columns.Add("stnd");
            dt_st.Columns.Add("sykm");
            dt_st.Columns.Add("sygw");
            dt_st.Columns.Add("ztdm");
            foreach (DataRow dr in dt_st.Rows)
            {
                dr["tg"] = dr["tg"].ToString().Replace("##&&##", "_______");
                dr["stnd"] = SysData.STNDByKey(dr["nd"].ToString()).mc;
                dr["sykm"] = SysData.KMByKey(dr["km"].ToString()).mc;
                //dr["sygw"] = SysData.GWByKey(dr["gw"].ToString()).mc;
                string str_gw = dr["gw"].ToString();
                string[] arr_gw = str_gw.Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
                string str_sygw = "";
                for (int i = 0; i < arr_gw.Length; i++)
                {
                    str_sygw += SysData.GWByKey(arr_gw[i]).mc + " ; ";
                }
                dr["sygw"] = str_sygw;
                dr["ztdm"] = SysData.STZTByKey(dr["zt"].ToString()).mc;
            }
            //绑定分页数据源  
            this.dlt_st.DataSource = dt_st.DefaultView;
            this.dlt_st.DataBind();
            ShowButtonByZT_QX();
        }
        protected void dlt_st_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string[] Comargs = e.CommandArgument.ToString().Split('&');
            string id = Comargs[0];
            string lx = Comargs[1];
            string zt = Comargs[2];
            if (e.CommandName == "Detail")
            {
                switch (lx)
                {
                    case "0"://单选题
                    case "3"://多选题
                        Response.Redirect("../ZXPX/ST_XZT_Detail.aspx?id=" + id, true);
                        break;
                    case "1"://判断题
                        Response.Redirect("../ZXPX/ST_PDT_Detail.aspx?id=" + id, true);
                        break;
                    case "2"://填空题
                        Response.Redirect("../ZXPX/ST_TKT_Detail.aspx?id=" + id, true);
                        break;
                    default: break;
                }
            }
            else if (e.CommandName == "Update")
            {
                if (zt != "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据不是保存状态，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "0")
                {
                    switch (lx)
                    {
                        case "0":
                        case "3":
                            Response.Redirect("../ZXPX/ST_XZT_Update.aspx?id=" + id, true);
                            break;
                        case "1":
                            Response.Redirect("../ZXPX/ST_PDT_Update.aspx?id=" + id, true);
                            break;
                        case "2":
                            Response.Redirect("../ZXPX/ST_TKT_Update.aspx?id=" + id, true);
                            break;
                        default: break;
                    }
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
                    long L_id = Convert.ToInt64(id);
                    string p_czxx = "位置：在线培训->试题管理->试题删除    描述：试题编号" + id;
                    try
                    {
                        switch (lx)
                        {
                            case "0":
                            case "3":
                                xzt.Delete_XZT_XX_bySTID(L_id, "03", p_czxx);
                                xzt.Delete_XZT_byID(L_id, "03", p_czxx);
                                break;
                            case "1":
                                pdt.Delete_PDT_byID(L_id, "03", p_czxx);
                                break;
                            case "2":
                                tkt.Delete_TKT_byID(L_id, "03", p_czxx);
                                break;
                            default: break;
                        }
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
        protected void dlt_st_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            LinkButton lbtUpdate = (LinkButton)e.Item.FindControl("lbtUpdate");
            LinkButton lbtDelete = (LinkButton)e.Item.FindControl("lbtDelete");
            HtmlControl title_cz = (HtmlTableCell)e.Item.FindControl("title_cz");
            HtmlControl nr_cz = (HtmlTableCell)e.Item.FindControl("nr_cz");
            if (title_cz != null)
            {
                if ((SysData.HasThisQX("190103", _usState.userID)) || (SysData.HasThisQX("190104", _usState.userID)))
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
                if ((SysData.HasThisQX("190103", _usState.userID)) || (SysData.HasThisQX("190104", _usState.userID)))
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
                lbtUpdate.Visible = SysData.HasThisQX("190103", _usState.userID);
            }
            if (lbtDelete != null)
            {
                //是否具有删除的权限
                lbtDelete.Visible = SysData.HasThisQX("190104", _usState.userID);
            }
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            Bind_Select();
        }
        #region btn
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string lx = ddlt_stlx.SelectedValue.ToString().Trim();
            switch (lx)
            {
                case "0":
                    Response.Redirect("../ZXPX/ST_XZT_Add.aspx?sfdx=0", true);
                    break;
                case "3":
                    Response.Redirect("../ZXPX/ST_XZT_Add.aspx?sfdx=1", true);
                    break;
                case "1":
                    Response.Redirect("../ZXPX/ST_PDT_Add.aspx", true);
                    break;
                case "2":
                    Response.Redirect("../ZXPX/ST_TKT_Add.aspx", true);
                    break;
                default: break;
            }
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            Bind_Select();
        }
        /// <summary>
        /// 删除 删除自己上传的，全选后点击删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sc_Click(object sender, EventArgs e)
        {
            string ztdm = null;
            int count = 0;
            foreach (DataListItem li in dlt_st.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要删除的试题信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_st.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_st.Rows[li.ItemIndex];
                        ztdm = dr["zt"].ToString();
                        if (ztdm != "0")//只能删除保存状态的数据
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"不能删除已经提交的试题！\")</script>");
                            return;
                        }
                        long id = Convert.ToInt64(dlt_st.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->试题管理->试题删除    描述：试题编号" + id;
                        string stlx = ddlt_stlx.SelectedValue.ToString();
                        switch (stlx)
                        {
                            case "0":
                            case "3":
                                xzt.Delete_XZT_byID(id, "03", p_czxx);
                                break;
                            case "1":
                                pdt.Delete_PDT_byID(id, "03", p_czxx);
                                break;
                            case "2":
                                tkt.Delete_TKT_byID(id, "03", p_czxx);
                                break;
                            default: break;
                        }
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
            foreach (DataListItem li in dlt_st.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要提交的试题信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_st.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_st.Rows[li.ItemIndex];
                        zt = dr["zt"].ToString();
                        if (zt != "0")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据不是未提交状态，不能提交！\")</script>");
                            return;
                        }
                        long id = Convert.ToInt64(dlt_st.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->试题管理->试题审核  提交数据    描述：试题编号" + id + ";";
                        Struct_SH struct_sh_st = new Struct_SH();
                        struct_sh_st.p_id = id;
                        struct_sh_st.p_zt = "1";
                        struct_sh_st.p_czfs = "08";
                        struct_sh_st.p_czxx = p_czxx;
                        string stlx = ddlt_stlx.SelectedValue.ToString();
                        switch (stlx)
                        {
                            case "0":
                            case "3":
                                xzt.Update_XZT_TJ(struct_sh_st);
                                break;
                            case "1":
                                pdt.Update_PDT_TJ(struct_sh_st);
                                break;
                            case "2":
                                tkt.Update_TKT_TJ(struct_sh_st);
                                break;
                            default: break;
                        }
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
            foreach (DataListItem li in dlt_st.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要审核的试题信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_st.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_st.Rows[li.ItemIndex];
                        zt = dr["zt"].ToString();
                        if (zt != "1")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据未提交，不能审核！\")</script>");
                            return;
                        }
                        long id = Convert.ToInt64(dlt_st.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->试题管理->试题审核  审核通过    描述：试题编号" + id + ";";
                        Struct_SH struct_sh_st = new Struct_SH();
                        struct_sh_st.p_id = id;
                        struct_sh_st.p_zt = "2";
                        struct_sh_st.p_czfs = "07";
                        struct_sh_st.p_czxx = p_czxx;
                        string stlx = ddlt_stlx.SelectedValue.ToString();
                        switch (stlx)
                        {
                            case "0":
                            case "3":
                                xzt.Update_XZT_SHTG(struct_sh_st);
                                break;
                            case "1":
                                pdt.Update_PDT_SHTG(struct_sh_st);
                                break;
                            case "2":
                                tkt.Update_TKT_SHTG(struct_sh_st);
                                break;
                            default: break;
                        }
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
            foreach (DataListItem li in dlt_st.Items)
            {
                CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                if (cb_xjh.Checked == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请选择要驳回的试题信息！\")</script>");
                return;
            }
            try
            {
                foreach (DataListItem li in dlt_st.Items)
                {
                    CheckBox cb_xjh = (CheckBox)li.FindControl("cbx_xz");
                    if (cb_xjh.Checked == true)
                    {
                        DataRow dr = dt_st.Rows[li.ItemIndex];
                        zt = dr["zt"].ToString();
                        if (zt == "0")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该数据未提交，不能驳回！\")</script>");
                            return;
                        }
                        string bhyy = HF_yc.Value;
                        long id = Convert.ToInt64(dlt_st.DataKeys[li.ItemIndex].ToString());
                        string p_czxx = "位置：在线培训->试题管理->试题驳回    描述：试题编号" + id + ";";
                        if (bhyy != "")
                        {
                            p_czxx += " 驳回原因：【" + bhyy + "】";
                        }
                        Struct_SH struct_sh_st = new Struct_SH();
                        struct_sh_st.p_id = id;
                        struct_sh_st.p_zt = "0";
                        struct_sh_st.p_yysm = bhyy;
                        struct_sh_st.p_czfs = "06";
                        struct_sh_st.p_czxx = p_czxx;
                        string stlx = ddlt_stlx.SelectedValue.ToString();
                        switch (stlx)
                        {
                            case "0":
                            case "3":
                                xzt.Update_XZT_BH(struct_sh_st);
                                break;
                            case "1":
                                pdt.Update_PDT_BH(struct_sh_st);
                                break;
                            case "2":
                                tkt.Update_TKT_BH(struct_sh_st);
                                break;
                            default: break;
                        }
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
    }
}
