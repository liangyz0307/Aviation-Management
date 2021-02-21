using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Globalization;
using System.IO;

namespace CUST.WKG
{
    public partial class YGGL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private YG yg;
        public string dm1;
        public string dm2;
        public bool flag = true;
        public int i = 0;
        private Struct_YG struct_yg;

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
            psize = pg_fy.NumPerPage;
            yg = new YG(_usState);
            struct_yg = new Struct_YG();

            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
                show();
            }
        }
        public void show()
        {
            Boolean flag_add = false;

            btn_tj.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "110102") == true)
            {
                btn_tj.Visible = true;
            }
            if (flag_add) { btn_tj.Visible = true; }
        }
        private void ddltBind()
        {
            //绑定部门代码ddlt_bmdm
            DataTable dt_bmdm = SysData.BM().Copy();
            ddlt_bmdm.DataSource = dt_bmdm;
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));

            //岗位代码
            //DataTable dt_gw = new DataTable();
            //ddlt_gwdm.DataSource = dt_gw;
            //ddlt_gwdm.DataBind();
            //ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

            //民族
            ddlt_mz.DataSource = SysData.MZ().Copy();
            ddlt_mz.DataTextField = "mc";
            ddlt_mz.DataValueField = "bm";
            ddlt_mz.DataBind();
            ddlt_mz.Items.Insert(0, new ListItem("全部", "-1"));

            //性别
            ddlt_xb.DataSource = SysData.XB().Copy();
            ddlt_xb.DataTextField = "mc";
            ddlt_xb.DataValueField = "bm";
            ddlt_xb.DataBind();
            ddlt_xb.Items.Insert(0, new ListItem("全部", "-1"));

            //政治面貌
            ddlt_zzmm.DataSource = SysData.ZZMM().Copy();
            ddlt_zzmm.DataTextField = "mc";
            ddlt_zzmm.DataValueField = "bm";
            ddlt_zzmm.DataBind();
            ddlt_zzmm.Items.Insert(0, new ListItem("全部", "-1"));

            //比较标识
            //ddlt_bjbs.DataSource = SysData.BJBS().Copy();
            //ddlt_bjbs.DataTextField = "mc";
            //ddlt_bjbs.DataValueField = "bm";
            //ddlt_bjbs.DataBind();
            //ddlt_bjbs.Items.Insert(0, new ListItem("全部", "-1"));

            //合同类型
            ddlt_htlx.DataSource = SysData.HTLX().Copy();
            ddlt_htlx.DataTextField = "mc";
            ddlt_htlx.DataValueField = "bm";
            ddlt_htlx.DataBind();
            ddlt_htlx.Items.Insert(0, new ListItem("全部", "-1"));

        }
        public void GW(string bm)
        {

            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_gwdm.DataSource = dt;
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {

                ddlt_gwdm.DataSource = SysData.GW(bm).Copy();
                ddlt_gwdm.DataTextField = "mc";
                ddlt_gwdm.DataValueField = "bm";
                ddlt_gwdm.DataBind();
                ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }
        private void bind_Main()
        {

            struct_yg.p_bh = tbx_bh.Text.Trim().ToString();
            struct_yg.p_xm = tbx_ygxm.Text.Trim().ToString();
            struct_yg.p_sfzh = "";
            struct_yg.p_bmdm = ddlt_bmdm.SelectedValue.ToString().Trim();
            struct_yg.p_gwdm = ddlt_gwdm.SelectedValue.ToString().Trim();
            struct_yg.p_zt = ddlt_zt.SelectedValue.ToString().Trim();
            struct_yg.p_mz = ddlt_mz.SelectedValue.ToString().Trim();//民族
            struct_yg.p_zzmm = ddlt_zzmm.SelectedValue.ToString().Trim();//政治面貌
            struct_yg.p_xb = ddlt_xb.SelectedValue.ToString().Trim();//性别
            struct_yg.p_htlx = ddlt_htlx.SelectedValue.ToString().Trim();//合同类型
            if (tbx_csrq_qs.Text.Trim().ToString() == "")
            {
                struct_yg.p_csrq_qs = Convert.ToDateTime("0001-1-20");
            }
            else
            {
                struct_yg.p_csrq_qs = DateTime.Parse(tbx_csrq_qs.Text.Trim().ToString());//起始日期
            }
            if (tbx_csrq_jz.Text.Trim().ToString() == "")
            {
                struct_yg.p_csrq_jz = Convert.ToDateTime("9999-12-20");
            }
            else
            {
                struct_yg.p_csrq_jz = DateTime.Parse(tbx_csrq_jz.Text.Trim().ToString());//截止日期
            }
            //struct_yg.p_bjbs = ddlt_bjbs.SelectedValue.ToString().Trim();//比较标识
            struct_yg.p_userid = _usState.userID;
            DataTable dt = new DataTable();
            //判断是否为普通员工
            if (!SysData.SFS_GLY(_usState.userLoginName))
            {
                int count = yg.Select_YGCount_Ptyg(struct_yg);
                pg_fy.TotalRecord = count;
                struct_yg.p_currentpage = pg_fy.CurrentPage;
                struct_yg.p_pagesize = pg_fy.NumPerPage;
                dt = yg.Select_YG_Pro_Ptyg(struct_yg);

            }
            else
            {
                int count = yg.Select_YGCount(struct_yg);
                pg_fy.TotalRecord = count;
                struct_yg.p_currentpage = pg_fy.CurrentPage;
                struct_yg.p_pagesize = pg_fy.NumPerPage;
                dt = yg.Select_YG_Pro(struct_yg);

            }
            dt.Columns.Add("bmmc");
            dt.Columns.Add("gwmc");
            dt.Columns.Add("xbmc");
            dt.Columns.Add("zzmm");
            dt.Columns.Add("xl");
            dt.Columns.Add("gzdd");
            dt.Columns.Add("rq");//出生日期
            dt.Columns.Add("ztmc");
            dt.Columns.Add("mzmc");
            // dt.Columns.Add("sj");//毕业时间
            foreach (DataRow dr in dt.Rows)
            {
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                //dr["bmdm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                //dr["gwdm"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                dr["xbmc"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["zzmm"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//政治面貌
                dr["xl"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历
                //dr["xldm"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历
                dr["gzdd"] = SysData.ZXDMByKey(dr["gzddm"].ToString()).mc;//工作地
                //dr["gzddm"] = SysData.ZXDMByKey(dr["gzddm"].ToString()).mc;//工作地代码
                dr["htgx"] = SysData.HTGXByKey(dr["htgx"].ToString()).mc;//合同关系
                dr["htlxdm"] = SysData.HTLXByKey(dr["htlxdm"].ToString()).mc;//合同类型
                //dr["mzdm"] = SysData.MZByKey(dr["mzdm"].ToString()).mc;//名族
                //dr["xbdm"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;//性别
                //dr["zzmmdm"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//政治面貌代码

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["csrq"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["rq"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);
                dr["mzmc"] = SysData.MZByKey(dr["mzdm"].ToString()).mc;
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
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[9];
            content = e.CommandArgument.ToString().Split('&');
            string bh = content[0];
            int id = Convert.ToInt32(content[1]);
            string zt = content[2];
            string bmdm = content[3];
            string lrr = content[4];//录入人
            string csr = content[5];//初审人
            string zsr = content[6];//终审人
            string sjc = content[7];//时间戳
            string sjbs = content[8];//数据标识
            if (e.CommandName == "Edit")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110103"))
                    {
                        Server.Transfer("YG_Edit.aspx?BH=" + bh + "&id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("YG_Edit.aspx?BH=" + bh + "&id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_yg = new Struct_YG();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工信息->员工管理->员工信息    描述：员工编号：[" + _usState.userLoginName + "]";
                        yg.Delete_YG(id, p_czfs, p_czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110104"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工->员工管理->员工信息    描述：员工编号：[" + _usState.userLoginName + "]";

                        yg.Delete_YG(id, p_czfs, p_czxx);
                        //yg.Delete_YH_SPR_BYBH(bh, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该部门删除权限，不可删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "KJRK")
            {
                Server.Transfer("YG_KJRK.aspx?BH=" + bh);
            }
            else if (e.CommandName == "Update_TJ")
            {
                struct_yg = new Struct_YG();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_yg.p_id = id;

                        struct_yg.p_zt = "1";
                        struct_yg.p_bhyy = HF_yc.Value;
                        struct_yg.p_czfs = "05";
                        struct_yg.p_czxx = "位置：员工奖励->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yg.Update_YGXXZT(struct_yg);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "11", "1101", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已驳回，请先编辑再提交！\")</script>");
                    return;
                }
            }
            else if (e.CommandName == "Update_SH")
            {

                if (zt == "1" && sjbs == "0")
                {
                    //如果是初审人
                    if (csr.Equals(_usState.userLoginName))
                    {
                        struct_yg.p_id = id;
                        struct_yg.p_zt = "2";
                        struct_yg.p_bhyy = HF_yc.Value;
                        struct_yg.p_czfs = "06";
                        struct_yg.p_czxx = "位置：员工信息->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yg.Update_YGXXZT(struct_yg);
                        SysData.Delete_TSR(csr, "11", "1101", id);
                        SysData.Insert_TSR(zsr, "11", "1101", id);
                    }
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是初审人，不能审核！\")</script>");
                        return;
                    }
                }
                if (zt == "2")
                {
                    //如果是终审人
                    if (zsr.Equals(_usState.userLoginName))
                    {
                        struct_yg.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_yg.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_yg.p_bhyy = HF_yc.Value;
                            struct_yg.p_czfs = "06";
                            struct_yg.p_czxx = "位置：员工信息->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            yg.Update_YGXX_SJBS_ZT(struct_yg);
                            SysData.Delete_TSR(zsr, "11", "1101", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_yg.p_sjc = sjc;
                            struct_yg.p_bhyy = HF_yc.Value;
                            struct_yg.p_czfs = "06";
                            struct_yg.p_czxx = "位置：员工信息->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            yg.Update_YGXX_SJBS_LSSJ_ZT(struct_yg);

                            //将副本数据变为最终数据
                            struct_yg.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_yg.p_bhyy = HF_yc.Value;
                            struct_yg.p_czfs = "06";
                            struct_yg.p_czxx = "位置：员工信息->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            yg.Update_YGXX_SJBS_FBSJ_ZT(struct_yg);
                            SysData.Delete_TSR(zsr, "11", "1101", id);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        if (zt == "1")
                        {
                            //如果是初审人
                            if (csr.Equals(_usState.userLoginName))
                            {
                                //执行update改变状态（驳回）
                                struct_yg.p_id = id;
                                struct_yg.p_zt = "4";
                                struct_yg.p_bhyy = HF_yc.Value;
                                struct_yg.p_czfs = "07";
                                struct_yg.p_czxx = "位置：员工奖励->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                                yg.Update_YGXXZT(struct_yg);
                                SysData.Delete_TSR(csr, "11", "1101", id);
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
                                struct_yg.p_id = id;
                                struct_yg.p_zt = "4";
                                struct_yg.p_bhyy = HF_yc.Value;
                                struct_yg.p_czfs = "07";
                                struct_yg.p_czxx = "位置：员工奖励->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                                yg.Update_YGXXZT(struct_yg);
                                SysData.Delete_TSR(zsr, "11", "1101", id);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                                return;
                            }
                        }

                        if (zt == "0")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息未提交，不能驳回！\")</script>");

                            return;
                        }
                        else if (zt == "3")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已通过审核，不能驳回！\")</script>");
                            return;
                        }
                        else if (zt == "4")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已驳回，不可重复驳回！\")</script>");
                            return;
                        }
                        struct_yg.p_id = id;
                        struct_yg.p_zt = "4";
                        struct_yg.p_bhyy = HF_yc.Value;
                        struct_yg.p_czfs = "07";
                        struct_yg.p_czxx = "位置：员工奖励->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yg.Update_YGXXZT(struct_yg);
                        SysData.Delete_TSR(csr, "11", "1101", id);
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
                        struct_yg.p_id = id;
                        struct_yg.p_zt = "4";
                        struct_yg.p_bhyy = HF_yc.Value;
                        struct_yg.p_czfs = "07";
                        struct_yg.p_czxx = "位置：员工信息->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        yg.Update_YGXXZT(struct_yg);
                        SysData.Delete_TSR(zsr, "11", "1101", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            if (ddlt_bmdm.SelectedValue == "-2")
            {
                Response.Write("<script>alert('请选择部门！')</script>");
                return;
            }
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("YG_Add.aspx", true);
        }
        protected void ddlt_bmdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bmdm.SelectedValue;
            GW(bm);
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

        //导出
        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = yg.Select_YG_DC(_usState.userID);
            if (dt_dc.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"暂无数据，请先录入数据再导出！\")</script>");
                return;
            }
            dt_dc.Columns.Add("rq");//毕业时间
            //dt_dc.Columns.Add("xtsj1_new");//毕业时间
            //dt_dc.Columns.Add("xtsj2_new");//毕业时间
            //dt_dc.Columns.Add("xtsj3_new");//毕业时间
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["bmdm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gwdm"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["xldm"] = SysData.XLByKey(dr["xldm"].ToString()).mc;//学历
                dr["gzddm"] = SysData.ZXDMByKey(dr["gzddm"].ToString()).mc;//工作地
                dr["htgx"] = SysData.HTGXByKey(dr["htgx"].ToString()).mc;//合同关系
                dr["htlxdm"] = SysData.HTLXByKey(dr["htlxdm"].ToString()).mc;//合同类型
                dr["mzdm"] = SysData.MZByKey(dr["mzdm"].ToString()).mc;//名族
                dr["xbdm"] = SysData.XBByKey(dr["xbdm"].ToString()).mc;//性别
                dr["zzmmdm"] = SysData.ZZMMByKey(dr["zzmmdm"].ToString()).mc;//政治面貌代码

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["csrq"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["rq"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);

            }

            //删除不用的列
            DataRow dr_Insert = dt_dc.NewRow();
            dt_dc.Columns.Remove("ID");
            dt_dc.Columns.Remove("BHYY");
            dt_dc.Columns.Remove("CSR");
            dt_dc.Columns.Remove("ZSR");
            dt_dc.Columns.Remove("LRR");
            dt_dc.Columns.Remove("SHSJ");
            dt_dc.Columns.Remove("SJC");
            dt_dc.Columns.Remove("SJBS");
            dt_dc.Columns.Remove("SJSSBM");
            dt_dc.Columns.Remove("ZPLJ");
            dt_dc.Columns.Remove("CSRQ");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "编号";
            dr_Insert[1] = "姓名";
            dr_Insert[2] = "性别";
            dr_Insert[3] = "身份证号";
            dr_Insert[4] = "民族";
            dr_Insert[5] = "联系电话";
            dr_Insert[6] = "岗位";
            dr_Insert[7] = "部门";
            dr_Insert[8] = "工作地";
            dr_Insert[9] = "详细地址";
            dr_Insert[10] = "籍贯";
            dr_Insert[11] = "毕业院校";
            dr_Insert[12] = "专业";
            dr_Insert[13] = "学历";
            dr_Insert[14] = "毕业时间";
            dr_Insert[15] = "入职时间";
            dr_Insert[16] = "政治面貌";
            dr_Insert[17] = "合同关系";
            dr_Insert[18] = "合同类型";
            dr_Insert[19] = "备注";
            dr_Insert[20] = "出生日期";

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "员工信息_" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../YuanGong/YGXX.xls");
            // 1、首先判断文件或者文件路径是否存在
            if (File.Exists(path))
            {
                // 3.2、删除文件
                File.Delete(path);
            }

            ex.OutputFilePath = path;
            ex.OutputExcelFile();

            string fileName = hz;//客户端保存的文件名 
            string filePath = path;//目标文件路径

            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该文件不在指定目录下！\")</script>");
                return;
            }
        }
    }
}










