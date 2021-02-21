using CUST.MKG;
using CUST.Sys;
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
    public partial class ZDGZXXGL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private ZDGZ  zdgz;
        public Struct_Select_ZDGZ struct_select_zdgz;
        public Struct_ZDGZ struct_zdgz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zdgz = new ZDGZ (_usState);
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {
                bind_drop();
                bind_select();
                show();
            }
        }
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "130202") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }
        private void bind_drop()
        {

            //报送支线
            ddlt_bszx.DataTextField = "mc";
            ddlt_bszx.DataValueField = "bm";
            ddlt_bszx.DataSource = SysData.ZXDM().Copy();
            ddlt_bszx.DataBind();
            ddlt_bszx.Items.Insert(0, new ListItem("全部", "-1"));
            //执行支线
            ddlt_zxzx.DataTextField = "mc";
            ddlt_zxzx.DataValueField = "bm";
            ddlt_zxzx.DataSource = SysData.ZXDM().Copy();
            ddlt_zxzx.DataBind();
            ddlt_zxzx.Items.Insert(0, new ListItem("全部", "-1"));

            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

        }

        private void bind_select()
        {
            struct_select_zdgz.p_bsbh = tbx_bsbh.Text.ToString().Trim();
            struct_select_zdgz.p_bsyg = tbx_bsyg.Text.ToString().Trim();
            struct_select_zdgz.p_xm = tbx_bsygxm.Text.ToString().Trim();
          //  struct_select_zdgz.p_bslx = "05";// ddlt_bslx.SelectedValue.ToString().Trim();
            struct_select_zdgz.p_bszx = ddlt_bszx.SelectedValue.ToString().Trim();
            struct_select_zdgz.p_zxzx = ddlt_zxzx.SelectedValue.ToString().Trim();
            struct_select_zdgz.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态

            struct_select_zdgz.p_userid = _usState.userID;
            int count = zdgz.SelectBS_ZDGZ_Count(struct_select_zdgz);
            pg_fy.TotalRecord = count;
            struct_select_zdgz.p_currentpage = pg_fy.CurrentPage;
            struct_select_zdgz.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = zdgz.SelectBS_ZDGZ_Pro(struct_select_zdgz);

            dt.Columns.Add("bm");
            dt.Columns.Add("bslxmc");
            dt.Columns.Add("zxlxmc");
            dt.Columns.Add("bssjgs");
            dt.Columns.Add("zxzxmc");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["bssjgs"] = Convert.ToDateTime(dr["bssj"]).ToString("yyyy-MM-dd");
                dr["bslxmc"] = SysData.BSLXByKey(dr["bslx"].ToString()).mc;
                dr["zxlxmc"] = SysData.ZXDMByKey(dr["bszx"].ToString()).mc;
                dr["zxzxmc"] = SysData.ZXDMByKey(dr["zxzx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;
            }
            ////绑定分页数据源  
            this.rpt_zdgz.DataSource = dt.DefaultView;
            this.rpt_zdgz.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_select();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/ZDGZXXGL_Add.aspx");
        }

        protected void rpt_zdgz_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130203"))
                    {
                        Server.Transfer("ZDGZXXGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                        Server.Transfer("ZDGZXXGL_Edit.aspx?id=" + id + "&sjbs=" + sjbs + "&sjc=" + sjc);
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
                struct_select_zdgz = new Struct_Select_ZDGZ();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务报送->重点工作管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        zdgz.DeleteBS_ZDGZ_byBH(id, p_czfs, p_czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130204"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务报送->重点工作管理->奖励    描述：员工编号：[" + _usState.userLoginName + "]";
                        zdgz.DeleteBS_ZDGZ_byBH(id, p_czfs, p_czxx);
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
                struct_zdgz = new Struct_ZDGZ();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_zdgz.p_id = id;
                        struct_zdgz.p_zt = "1";
                        struct_zdgz.p_bhyy = HF_yc.Value;
                        struct_zdgz.p_czfs = "05";
                        struct_zdgz.p_czxx = "位置：航务报送->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zdgz.Update_ZDGZZT(struct_zdgz);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_zdgz.p_id = id;
                        struct_zdgz.p_zt = "2";
                        struct_zdgz.p_bhyy = HF_yc.Value;
                        struct_zdgz.p_czfs = "06";
                        struct_zdgz.p_czxx = "位置：航务报送->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zdgz.Update_ZDGZZT(struct_zdgz);
                        SysData.Delete_TSR(csr, "13", "1302", id);
                        SysData.Insert_TSR(zsr, "13", "1302", id);
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
                        struct_zdgz.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_zdgz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_zdgz.p_bhyy = HF_yc.Value;
                            struct_zdgz.p_czfs = "06";
                            struct_zdgz.p_czxx = "位置：航务报送->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            zdgz.Update_ZDGZ_SJBS_ZT(struct_zdgz);
                            SysData.Delete_TSR(zsr, "13", "1302", id);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_zdgz.p_sjc = sjc;
                            struct_zdgz.p_bhyy = HF_yc.Value;
                            struct_zdgz.p_czfs = "06";
                            struct_zdgz.p_czxx = "位置：航务报送->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            zdgz.Update_ZDGZ_SJBS_LSSJ_ZT(struct_zdgz);

                            //将副本数据变为最终数据
                            struct_zdgz.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_zdgz.p_bhyy = HF_yc.Value;
                            struct_zdgz.p_czfs = "06";
                            struct_zdgz.p_czxx = "位置：航务报送->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            zdgz.Update_ZDGZ_SJBS_FBSJ_ZT(struct_zdgz);
                            SysData.Delete_TSR(zsr, "13", "1302", id);

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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该重点工作信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_zdgz.p_id = id;
                        struct_zdgz.p_zt = "4";
                        struct_zdgz.p_bhyy = HF_yc.Value;
                        struct_zdgz.p_czfs = "07";
                        struct_zdgz.p_czxx = "位置：航务报送重点工作->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zdgz.Update_ZDGZZT(struct_zdgz);
                        SysData.Delete_TSR(csr, "13", "1302", id);
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
                        struct_zdgz.p_id = id;
                        struct_zdgz.p_zt = "4";
                        struct_zdgz.p_bhyy = HF_yc.Value;
                        struct_zdgz.p_czfs = "07";
                        struct_zdgz.p_czxx = "位置：航务报送重点工作->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        zdgz.Update_ZDGZZT(struct_zdgz);
                        SysData.Delete_TSR(zsr, "13", "1302", id);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该重点工作信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_select();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in rpt_zdgz.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
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
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_select();
        }
    }
}