using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace CUST.WKG
{
    public partial class GZJZXXGL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private GZJZ gzjz;
        public Struct_Select_GZJZ struct_select_gzjz;
        public Struct_GZJZ struct_gzjz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            gzjz = new GZJZ(_usState);
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {
                bind_drop();
                bind_select();
                show();

            }
        }
        //权限判断是否显示添加按钮
        protected void show()
        {

            #region 添加按钮
            Boolean flag_add = false;

            btn_add.Visible = false;
            if (SysData.HasThisBMQX(_usState.userID, "130102"))
            {
                btn_add.Visible = true;
            }
            if (flag_add) { btn_add.Visible = true; }
            #endregion
        }
        private void bind_drop()
        {
            ddlt_bsbm.DataTextField = "mc";
            ddlt_bsbm.DataValueField = "bm";
            ddlt_bsbm.DataSource = SysData.BM().Copy();
            ddlt_bsbm.DataBind();
            ddlt_bsbm.Items.Insert(0, new ListItem("全部", "-1"));
            //支线名称
            ddlt_zxmc.DataTextField = "mc";
            ddlt_zxmc.DataValueField = "bm";
            ddlt_zxmc.DataSource = SysData.ZXDM().Copy();
            ddlt_zxmc.DataBind();
            ddlt_zxmc.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

        }

        private void bind_select()
        {
            struct_select_gzjz.p_userid = _usState.userID;
            struct_select_gzjz.p_bsbm = ddlt_bsbm.SelectedValue.ToString().Trim();
            struct_select_gzjz.p_bszx = ddlt_zxmc.SelectedValue.ToString();
            struct_select_gzjz.p_zt = ddlt_zt.SelectedValue.ToString();
            int count = gzjz.SelectBS_GZJZ_Count(struct_select_gzjz);
            pg_fy.TotalRecord = count;
            struct_select_gzjz.p_currentpage = pg_fy.CurrentPage;
            struct_select_gzjz.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = gzjz.SelectBS_GZJZ_Pro(struct_select_gzjz);
            dt.Columns.Add("bszxmc");
            dt.Columns.Add("bmbssj");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("bsbmmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bmbssj"] = Convert.ToDateTime(dr["bssj"]).ToString("yyyy-MM-dd");
                dr["bszxmc"] = SysData.ZXDMByKey(dr["bszx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                dr["bsbmmc"] = SysData.BMByKey(dr["bsbm"].ToString()).mc;
            }
            ////绑定分页数据源  
            this.rpt_gzjz.DataSource = dt.DefaultView;
            this.rpt_gzjz.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_select();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/GZJZXXGL_Add.aspx");
        }
        protected void rpt_gzjz_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130103"))
                    {
                        Server.Transfer("GZJZXXGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc + "&zt=" + zt);
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
                        Server.Transfer("KG_gzjz_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_gzjz = new Struct_GZJZ();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务报送->工作进展管理->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                        gzjz.DeleteBS_GZJZ_byBH(sjc, zt, sjbs, Convert.ToString(id), p_czfs, p_czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130104"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务报送->工作进展管理->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                        gzjz.DeleteBS_GZJZ_byBH(sjc, zt, sjbs, Convert.ToString(id), p_czfs, p_czxx);
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
                struct_gzjz = new Struct_GZJZ();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_gzjz.p_id = Convert.ToString(id);
                        struct_gzjz.p_zt = "1";
                        struct_gzjz.p_bhyy = HF_yc.Value;
                        struct_gzjz.p_bzsjc = sjc;
                        struct_gzjz.p_sjbs = sjbs;
                        struct_gzjz.p_yzt = zt;
                        struct_gzjz.p_czfs = "05";
                        struct_gzjz.p_czxx = "位置：工作进展->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        gzjz.Update_GZJZZT(struct_gzjz);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "13", "1301", id);
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
                        struct_gzjz.p_id = Convert.ToString(id);
                        struct_gzjz.p_zt = "2";
                        struct_gzjz.p_bhyy = HF_yc.Value;
                        struct_gzjz.p_bzsjc = sjc;
                        struct_gzjz.p_sjbs = sjbs;
                        struct_gzjz.p_yzt = zt;
                        struct_gzjz.p_czfs = "06";
                        struct_gzjz.p_czxx = "位置：工作进展->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        gzjz.Update_GZJZZT(struct_gzjz);
                        SysData.Delete_TSR(csr, "13", "1301", id);
                        SysData.Insert_TSR(zsr, "13", "1301", id);
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
                        struct_gzjz.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_gzjz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_gzjz.p_bhyy = HF_yc.Value;
                            struct_gzjz.p_czfs = "06";
                            struct_gzjz.p_czxx = "位置：工作进展->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            gzjz.Update_GZJZ_SJBS_ZT(struct_gzjz);
                            SysData.Delete_TSR(zsr, "13", "1301", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_gzjz.p_sjc = sjc;
                            struct_gzjz.p_bhyy = HF_yc.Value;
                            struct_gzjz.p_czfs = "06";
                            struct_gzjz.p_czxx = "位置：工作进展->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            gzjz.Update_GZJZ_SJBS_LSSJ_ZT(struct_gzjz);

                            //将副本数据变为最终数据
                            struct_gzjz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_gzjz.p_bhyy = HF_yc.Value;
                            struct_gzjz.p_czfs = "06";
                            struct_gzjz.p_czxx = "位置：工作进展->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            gzjz.Update_GZJZ_SJBS_FBSJ_ZT(struct_gzjz);
                            SysData.Delete_TSR(zsr, "13", "1301", id);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工培训信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工培训信息已通过审核，不能重复审核！\")</script>");
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
                        struct_gzjz.p_id = Convert.ToString(id);
                        struct_gzjz.p_zt = "4";
                        struct_gzjz.p_bhyy = HF_yc.Value;
                        struct_gzjz.p_bzsjc = sjc;
                        struct_gzjz.p_sjbs = sjbs;
                        struct_gzjz.p_yzt = zt;
                        struct_gzjz.p_czfs = "07";
                        struct_gzjz.p_czxx = "位置：工作进展->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        gzjz.Update_GZJZZT(struct_gzjz);
                        SysData.Delete_TSR(csr, "13", "1301", id);
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
                        struct_gzjz.p_id = Convert.ToString(id);
                        struct_gzjz.p_zt = "4";
                        struct_gzjz.p_bhyy = HF_yc.Value;
                        struct_gzjz.p_bzsjc = sjc;
                        struct_gzjz.p_sjbs = sjbs;
                        struct_gzjz.p_yzt = zt;
                        struct_gzjz.p_czfs = "07";
                        struct_gzjz.p_czxx = "位置：工作进展->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        gzjz.Update_GZJZZT(struct_gzjz);
                        SysData.Delete_TSR(zsr, "13", "1301", id);
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
            bind_select();
        }

        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_select();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
                foreach (RepeaterItem li in rpt_gzjz.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
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