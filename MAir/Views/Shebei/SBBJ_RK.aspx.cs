using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CUST.Tools;
using CUST.Sys;
using CUST.MKG;
using Sys;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

namespace CUST.WKG
{
    public partial class SBBJ_RK : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private BJ bj;
        private Struct_BJRK struct_bjrk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            bj = new BJ(_usState);
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {
                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
                show();
                bind_drop();              
            }
            bind_select();
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "140702") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
    
        private  void bind_drop()
        {
            //备件分类
            ddlt_bjfl.DataTextField = "mc";
            ddlt_bjfl.DataValueField = "bm";
            ddlt_bjfl.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl.DataBind();
            ddlt_bjfl.Items.Insert(0, new ListItem("全部", "-1"));

            //备件适用
            ddlt_bjsy.DataTextField = "mc";
            ddlt_bjsy.DataValueField = "bm";
            ddlt_bjsy.DataSource = SysData.BJSY().Copy();
            ddlt_bjsy.DataBind();
            ddlt_bjsy.Items.Insert(0, new ListItem("全部", "-1"));

            //经办人部门
            ddlt_jbrbm.DataTextField = "mc";
            ddlt_jbrbm.DataValueField = "bm";
            ddlt_jbrbm.DataSource = SysData.BM().Copy();
            ddlt_jbrbm.DataBind();
            ddlt_jbrbm.Items.Insert(0, new ListItem("全部", "-1"));

            //经办人岗位
            DataTable dt_gw = new DataTable();
            ddlt_jbrgw.DataSource = dt_gw;
            ddlt_jbrgw.DataBind();
            ddlt_jbrgw.Items.Insert(0, new ListItem("全部", "-1"));


            //负责人部门
            ddlt_fzrbm.DataTextField = "mc";
            ddlt_fzrbm.DataValueField = "bm";
            ddlt_fzrbm.DataSource = SysData.BM().Copy();
            ddlt_fzrbm.DataBind();
            ddlt_fzrbm.Items.Insert(0, new ListItem("全部", "-1"));

            //负责人岗位
            DataTable dt_fzrgw = new DataTable();
            ddlt_fzrgw.DataSource = dt_fzrgw;
            ddlt_fzrgw.DataBind();
            ddlt_fzrgw.Items.Insert(0, new ListItem("全部", "-1"));


            //备件名称
            DataTable dt = new DataTable();
            dt = bj.Select_BJXX().Tables[0];
            ddlt_bjmc.DataTextField = "bjmc";
            ddlt_bjmc.DataValueField = "sjc";
            ddlt_bjmc.DataSource = dt;
            ddlt_bjmc.DataBind();
            ddlt_bjmc.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

        }
        private void bind_select()
        {
            struct_bjrk.p_bjbh = ddlt_bjmc.SelectedValue.ToString();
            struct_bjrk.p_bjfl = ddlt_bjfl.SelectedValue.ToString();
            struct_bjrk.p_sy = ddlt_bjsy.SelectedValue.ToString();
            struct_bjrk.p_jbrxm = tbx_jbr.Text.ToString();
            struct_bjrk.p_jbrbm = ddlt_jbrbm.SelectedValue.ToString();
            struct_bjrk.p_jbrgw = ddlt_jbrgw.SelectedValue.ToString();
            struct_bjrk.p_fzrxm = tbx_fzr.Text.ToString();
            struct_bjrk.p_fzrbm = ddlt_fzrbm.SelectedValue.ToString();
            struct_bjrk.p_fzrgw = ddlt_fzrgw.SelectedValue.ToString();
            struct_bjrk.p_zxdm = _usState.userSS;
            struct_bjrk.p_userid = _usState.userID;
            struct_bjrk.p_zt = ddlt_zt.SelectedValue.ToString();
            if (tbx_kssj.Text.ToString() == "")
            {
                DateTime dt_kssj = new DateTime();
                struct_bjrk.p_kssj = dt_kssj;
            }
            else
            {
                struct_bjrk.p_kssj = Convert.ToDateTime(tbx_kssj.Text.ToString());
            }
            if (tbx_jssj.Text.ToString() == "")
            {

                struct_bjrk.p_jssj = DateTime.Now;
            }
            else
            {
                struct_bjrk.p_jssj = Convert.ToDateTime(tbx_jssj.Text.ToString());
            }
            int count = bj.Select_BJRK_Count(struct_bjrk);
            pg_fy.TotalRecord = count;
            struct_bjrk.p_currentpage = pg_fy.CurrentPage;
            struct_bjrk.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = bj.Select_BJRK_Pro(struct_bjrk).Tables[0];

            dt.Columns.Add("bjfl_mc");
            //dt.Columns.Add("jbrbm_mc");
            //dt.Columns.Add("fzrbm_mc");
            //dt.Columns.Add("jbrgw_mc");
            //dt.Columns.Add("fzrgw_mc");
            dt.Columns.Add("bjsy_mc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("rksjz");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjfl_mc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;
                //dr["jbrbm_mc"] = SysData.BMByKey(dr["jbrbm"].ToString()).mc;
                //dr["fzrbm_mc"] = SysData.BMByKey(dr["fzrbm"].ToString()).mc;
                //dr["jbrgw_mc"] = SysData.GWByKey(dr["jbrgw"].ToString()).mc;
                //dr["fzrgw_mc"] = SysData.GWByKey(dr["fzrgw"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bjsy_mc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;
                dr["rksjz"] = DateTime.Parse(dr["rksj"].ToString()).ToString("yyyy-MM-dd");
            }

            ////绑定分页数据源  
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_select();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

            Response.Redirect("../SheBei/BJRK_Add.aspx");
        }

       
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_select();
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

        protected void ddlt_jbrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_jbrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_jbrgw.DataSource = dt;
                ddlt_jbrgw.DataBind();
                ddlt_jbrgw.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_jbrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_jbrgw.DataTextField = "mc";
                ddlt_jbrgw.DataValueField = "bm";
                ddlt_jbrgw.DataBind();
                ddlt_jbrgw.Items.Insert(0, new ListItem("全部", "-1"));
            }
        }

        protected void ddlt_fzrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_fzrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_fzrgw.DataSource = dt;
                ddlt_fzrgw.DataBind();
                ddlt_fzrgw.Items.Insert(0, new ListItem("全部", "-1"));
            }
            else
            {
                ddlt_fzrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_fzrgw.DataTextField = "mc";
                ddlt_fzrgw.DataValueField = "bm";
                ddlt_fzrgw.DataBind();
                ddlt_fzrgw.Items.Insert(0, new ListItem("全部", "-1"));
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140703"))
                    {
                        Server.Transfer("BJRK_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("BJRK_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_bjrk = new Struct_BJRK();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工奖励->员工奖励管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Delete_BJRK(Convert.ToString(id), p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "140704"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：员工奖励->员工奖励管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Delete_BJRK(Convert.ToString(id), p_czfs, p_czxx);
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
                struct_bjrk = new Struct_BJRK();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_bjrk.p_id = content[0];
                        struct_bjrk.p_zt = "1";
                        struct_bjrk.p_bhyy = HF_yc.Value;
                        struct_bjrk.p_czfs = "05";
                        struct_bjrk.p_czxx = "位置：员工奖励->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJRKZT(struct_bjrk);
                        //插入到HT_TSR表中
                        SysData.Insert_TSR(csr, "14", "1407", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_bjrk.p_id = content[0];
                        struct_bjrk.p_zt = "2";
                        struct_bjrk.p_bhyy = HF_yc.Value;
                        struct_bjrk.p_czfs = "06";
                        struct_bjrk.p_czxx = "位置：员工奖励->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJRKZT(struct_bjrk);
                        SysData.Delete_TSR(csr, "14", "1407", id);
                        SysData.Insert_TSR(zsr, "14", "1407", id);
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
                        struct_bjrk.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_bjrk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bjrk.p_bhyy = HF_yc.Value;
                            struct_bjrk.p_czfs = "06";
                            struct_bjrk.p_czxx = "位置：员工奖励->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            bj.Update_BJRK_SJBS_ZT(struct_bjrk);
                            SysData.Delete_TSR(zsr, "14", "1407", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_bjrk.p_sjc = sjc;
                            struct_bjrk.p_bhyy = HF_yc.Value;
                            struct_bjrk.p_czfs = "06";
                            struct_bjrk.p_czxx = "位置：员工奖励->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            bj.Update_BJRK_SJBS_LSSJ_ZT(struct_bjrk);

                            //将副本数据变为最终数据
                            struct_bjrk.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bjrk.p_bhyy = HF_yc.Value;
                            struct_bjrk.p_czfs = "06";
                            struct_bjrk.p_czxx = "位置：员工奖励->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            bj.Update_BJRK_SJBS_FBSJ_ZT(struct_bjrk);
                            SysData.Delete_TSR(zsr, "14", "1407", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该员工奖励信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_bjrk.p_id = content[0];
                        struct_bjrk.p_zt = "4";
                        struct_bjrk.p_bhyy = HF_yc.Value;
                        struct_bjrk.p_czfs = "07";
                        struct_bjrk.p_czxx = "位置：员工奖励->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJRKZT(struct_bjrk);
                        SysData.Delete_TSR(csr, "14", "1407", id);
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
                        struct_bjrk.p_id = content[0];
                        struct_bjrk.p_zt = "4";
                        struct_bjrk.p_bhyy = HF_yc.Value;
                        struct_bjrk.p_czfs = "07";
                        struct_bjrk.p_czxx = "位置：员工奖励->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        bj.Update_BJRKZT(struct_bjrk);
                        SysData.Delete_TSR(zsr, "14", "1407", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }

            //if (e.CommandName == "Edit")
            //{
            //    Server.Transfer("../SheBei/BJRK_Edit.aspx?id=" + e.CommandArgument.ToString());
            //}
            //if(e.CommandName== "Delete")
            //{
            //    string id = e.CommandArgument.ToString();
            //    string czfs = "03";
            //    string czxx = "位置：设备管理->设备备件->删除  备件入库ID="  ;
            //    bj.Delete_BJRK(id,czfs,czxx);
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
            //}
            if (e.CommandName == "CK")
            {
                if (zt !="3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息待审核，不能进行该操作！\")</script>");
                    return;
                }

                else if ( zt == "3")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        Server.Transfer("BJ_CRHD.aspx?id=" + id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有操作权限，不能进行该操作！\")</script>");
                        return;
                    }
                }
            }
            if (e.CommandName == "RK")
            {
                if (zt != "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该备件信息待审核，不能进行该操作！\")</script>");
                    return;
                }

                else if (zt == "3")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        Server.Transfer("BJ_RKHD.aspx?id=" + id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有操作权限，不能进行该操作！\")</script>");
                        return;
                    }
                }
            }
            bind_select();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
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

        //导出
        protected void btn_dc_Click(object sender, EventArgs e)
        {

            //得到需要导入Excel的DataTable
            DataTable dt_dc = new DataTable();
            dt_dc = bj.Select_BJCRK_DC(_usState.userID);
            dt_dc.Columns.Add("rksj_z");
            dt_dc.Columns.Add("sl_z");
            foreach (DataRow dr in dt_dc.Rows)
            {
                dr["zt"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["fzrbm"] = SysData.BMByKey(dr["fzrbm"].ToString()).mc;
                dr["fzrgw"] = SysData.GWByKey(dr["fzrgw"].ToString()).mc;
                dr["jbrbm"] = SysData.BMByKey(dr["jbrbm"].ToString()).mc;
                dr["jbrgw"] = SysData.GWByKey(dr["jbrgw"].ToString()).mc;

                DateTime dt_csrq = new DateTime();
                dt_csrq = Convert.ToDateTime(dr["rksj"].ToString());
                // dr["rq"]= dt_csrq.ToShortDateString().ToString();
                dr["rksj_z"] = string.Format("{0:yyyy-MM-dd}", dt_csrq);

                dr["sl_z"] = Convert.ToString(dr["rksl"].ToString());
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
            dt_dc.Columns.Remove("bmdm");
            dt_dc.Columns.Remove("kffzr");
            dt_dc.Columns.Remove("rkjbr");
            dt_dc.Columns.Remove("rksj");
            dt_dc.Columns.Remove("rksl");
            dt_dc.Columns.Remove("ZT");
            //将其列名添加进去！ （这一步注意是为了方便以后将该Excel导入内存表中 自动创建列名用。）
            dr_Insert[0] = "备件编号";
            dr_Insert[1] = "存放位置";
            dr_Insert[2] = "备注";
            dr_Insert[3] = "经办人部门";
            dr_Insert[4] = "经办人岗位";
            dr_Insert[5] = "负责人部门";
            dr_Insert[6] = "负责人岗位";
            dr_Insert[7] = "经办人姓名";
            dr_Insert[8] = "负责人姓名";
            dr_Insert[9] = "首次入库时间";
            dr_Insert[10] = "现有备件数量";

            dt_dc.Rows.InsertAt(dr_Insert, 0);

            //实例化一个Excel助手工具类
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(dt_dc, 1, 1);
            //时间戳后缀
            string hz = "设备备件出入库" + DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo) + ".xls";
            //导出Excel保存的路径！
            string path = Server.MapPath("../Shebei/BJCRK.xls");
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