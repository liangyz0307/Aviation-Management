using CUST;
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
    public partial class BS_WXFY : System.Web.UI.Page
    {
        private UserState _usState;
        private WXFY wxfy;
        private Struct_Bs_Wxfy struct_bs_wxfy;//结构体
        public int cpage;
        public int psize;
        public int wxbh;
        public string xmmc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
           
            wxfy = new WXFY(_usState);
            if (!IsPostBack)
            {                
                ddltBind();
                bind_Main();
                show();
            }
        }
        //判断用户是否有添加权限
        //判断用户是否有添加权限
        public void show()
        {
            //添加和删除的判断标识符
            Boolean flag_add = false;
            //默认隐藏添加按钮
            btn_add.Visible = false;

            if (SysData.HasThisBMQX(_usState.userID, "130302") == true)
            {
                flag_add = true;
            }
            if (flag_add) { btn_add.Visible = true; }

        }

        protected void ddltBind()
        {
            //登记单位(支线)
            ddlt_djdw.DataSource = SysData.ZXDM().Copy();
            ddlt_djdw.DataTextField = "mc";
            ddlt_djdw.DataValueField = "bm";
            ddlt_djdw.DataBind();
            ddlt_djdw.Items.Insert(0, new ListItem("全部", "-1"));

            //绑定维修类别
            ddlt_wxlb.DataSource = SysData.WXLB().Copy();
            ddlt_wxlb.DataTextField = "mc";
            ddlt_wxlb.DataValueField = "bm";
            ddlt_wxlb.DataBind();
            ddlt_wxlb.Items.Insert(0, new ListItem("全部", "-1"));




            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }

        private void bind_Main()
        {
            struct_bs_wxfy.p_nd = tbx_nd.Text.Trim().ToString();//年度
            struct_bs_wxfy.p_djdw = ddlt_djdw.SelectedValue.Trim().ToString();//登记单位
            struct_bs_wxfy.p_wxlb = ddlt_wxlb.SelectedValue.Trim().ToString();//维修类别
            struct_bs_wxfy.p_bmdm = Request.Params["bmdm"]; ;//部门代码
            struct_bs_wxfy.p_zt = ddlt_zt.SelectedValue.Trim().ToString();//状态
            struct_bs_wxfy.p_userid = _usState.userID;//用户ID
            struct_bs_wxfy.p_currentpage = pg_fy.CurrentPage;
            struct_bs_wxfy.p_pagesize = pg_fy.NumPerPage;
            int count = wxfy.Select_Bs_Wxfy_Count(struct_bs_wxfy);
            pg_fy.TotalRecord = count;
            DataTable dt= wxfy.SelectBS_Wxfy_Pro(struct_bs_wxfy);
            dt.Columns.Add("djdwmc");
            dt.Columns.Add("bm");
            dt.Columns.Add("yspfmc");
            dt.Columns.Add("wxlbmc");
            dt.Columns.Add("xmmcmc");
            dt.Columns.Add("wxrq");
            dt.Columns.Add("sblbmc");
            dt.Columns.Add("sbmcmc");
            dt.Columns.Add("cfddmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("wxrqmc");
            //项目名称
            string xmmc_sbzl;
            string xmmc_sbwz;
            string xmmc_sblx;
            //设备类别
            string sblb_sbzl;
            string sblb_sbwz;
            string sblb_sblx;
            //设备名称
            string sbmc_zx;
            string sbmc_sbzl;
            string sbmc_sbwz;
            string sbmc_sblx;
            //存放地点
            string cfdd_zx;//存放地点_支线
            string cfdd_tx;//存放地点_填写
            foreach (DataRow dr in dt.Rows)
           {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["djdwmc"] = SysData.ZXDMByKey(dr["djdw"].ToString()).mc;//登记单位
                dr["yspfmc"] = dr["yspf"].ToString()+"万";//预算批复
                dr["wxlbmc"] = SysData.WXLBByKey(dr["wxlb"].ToString()).mc;//维修类别
                //项目名称
                xmmc_sbzl = dr["xmmc"].ToString().Substring(0,2);//项目名称_设备种类
                xmmc_sbwz = dr["xmmc"].ToString().Substring(2,2);//项目名称_设备位置
                xmmc_sblx = dr["xmmc"].ToString().Substring(4,4);//项目名称_设备类型              
                dr["xmmcmc"] = SysData.SBZLByKey(xmmc_sbzl).mc + xmmc_sbwz + SysData.SBLXByKey(xmmc_sblx).mc;
                //维修日期  
                DateTime dt_qswxrq = new DateTime();
                DateTime dt_jzwxrq = new DateTime();
                dt_qswxrq = Convert.ToDateTime(dr["qswxrq"].ToString());
                dt_jzwxrq = Convert.ToDateTime(dr["jzwxrq"].ToString());
                dr["wxrqmc"] = string.Format("{0:yyyy-MM-dd}", dt_qswxrq)+"-" + string.Format("{0:yyyy-MM-dd}", dt_jzwxrq);
                //dr["wxrqmc"] = dr["qswxrq"].ToString().Substring(0,10)+"-" + dr["jzwxrq"].ToString().Substring(0, 10);
                //设备类别
                sblb_sbzl = dr["sblb"].ToString().Substring(0, 2);//设备类别_设备种类
                sblb_sbwz = dr["sblb"].ToString().Substring(2, 2);//设备类别_设备位置
                sblb_sblx = dr["sblb"].ToString().Substring(4, 4);//设备类别_设备类型
                dr["sblbmc"]= SysData.SBZLByKey(sblb_sbzl).mc + sblb_sbwz + SysData.SBLXByKey(sblb_sblx).mc;

                //设备名称
                sbmc_zx = dr["sbmc"].ToString().Substring(0, 2);//设备名称_支线
                sbmc_sbzl = dr["sbmc"].ToString().Substring(2, 2);//设备名称_设备种类
                sbmc_sbwz = dr["sbmc"].ToString().Substring(4, 2);//设备名称_设备位置
                sbmc_sblx = dr["sbmc"].ToString().Substring(6, 4);//设备名称_设备类型
                dr["sbmcmc"] = SysData.ZXDMByKey(sbmc_zx).mc + SysData.SBZLByKey(sbmc_sbzl).mc + sbmc_sbwz + SysData.SBLXByKey(sbmc_sblx).mc;
                //存放地点
                cfdd_zx= dr["cfdd"].ToString().Substring(0, 2);//存放地点_支线
                cfdd_tx = dr["cfdd"].ToString().Substring(2);//存放地点_填写
                dr["cfddmc"] = SysData.ZXDMByKey(cfdd_zx).mc + cfdd_tx;
                //状态
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("WXFY_Add.aspx");
        }
        #endregion

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[8];
            content = e.CommandArgument.ToString().Split('&');
            int wxbh = Convert.ToInt32(content[0]);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该请示登记待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130303"))
                    {
                        Server.Transfer("WXFY_Edit.aspx?wxbh=" + wxbh + "&sjbs=" + sjbs);
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
                        Server.Transfer("WXFY_Edit.aspx?wxbh=" + wxbh + "&sjbs=" + sjbs);
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
                struct_bs_wxfy = new Struct_Bs_Wxfy();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务综合->维修费->删除    描述：维修编号：[" + _usState.userLoginName + "]";
                        wxfy.Delete_Bs_Wxfy(wxbh, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该请示登记待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "130304"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：航务综合->维修费->删除记录    描述：维修编号：[" + _usState.userLoginName + "]";
                        wxfy.Delete_Bs_Wxfy(wxbh, p_czfs, p_czxx);
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
                struct_bs_wxfy = new Struct_Bs_Wxfy();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_bs_wxfy.p_wxbh = wxbh;
                        struct_bs_wxfy.p_zt = "1";
                        struct_bs_wxfy.p_bhyy = HF_yc.Value;
                        struct_bs_wxfy.p_czfs = "05";
                        struct_bs_wxfy.p_czxx = "位置：员工奖励->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wxfy.Update_WXFYZT(struct_bs_wxfy);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该请示登记待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该请示登记已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该请示登记已驳回，请先编辑再提交！\")</script>");
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
                        struct_bs_wxfy.p_wxbh = wxbh;
                        struct_bs_wxfy.p_zt = "2";
                        struct_bs_wxfy.p_bhyy = HF_yc.Value;
                        struct_bs_wxfy.p_czfs = "06";
                        struct_bs_wxfy.p_czxx = "位置：航务综合->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        wxfy.Update_WXFYZT(struct_bs_wxfy);
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
                        struct_bs_wxfy.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_bs_wxfy.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bs_wxfy.p_bhyy = HF_yc.Value;
                            struct_bs_wxfy.p_czfs = "06";
                            struct_bs_wxfy.p_czxx = "位置：维修费用->状态->改变状态（审核）    描述：维修编号：[" + _usState.userLoginName + "]";
                            wxfy.Update_WXFY_SJBS_ZT(struct_bs_wxfy);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_bs_wxfy.p_sjc = sjc;
                            struct_bs_wxfy.p_bhyy = HF_yc.Value;
                            struct_bs_wxfy.p_czfs = "06";
                            struct_bs_wxfy.p_czxx = "位置：维修费用->报销状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            wxfy.Update_WXFT_SJBS_LSSJ_ZT(struct_bs_wxfy);

                            //将副本数据变为最终数据
                            struct_bs_wxfy.p_shsj = DateTime.Now.ToString("yyyy-MM-dd HHo:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_bs_wxfy.p_bhyy = HF_yc.Value;
                            struct_bs_wxfy.p_czfs = "06";
                            struct_bs_wxfy.p_czxx = "位置：维修费用->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            wxfy.Update_WXFY_SJBS_FBSJ_ZT(struct_bs_wxfy);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该维修费信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该维修费信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
                    return;
                }
                else if (e.CommandName == "Update_BH")
                {
                    if (zt == "1")
                    {
                        //如果是初审人
                        if (csr.Equals(_usState.userLoginName))
                        {
                            //执行update改变状态（驳回）
                            struct_bs_wxfy.p_wxbh = wxbh;
                            struct_bs_wxfy.p_zt = "4";
                            struct_bs_wxfy.p_bhyy = HF_yc.Value;
                            struct_bs_wxfy.p_czfs = "07";
                            struct_bs_wxfy.p_czxx = "位置：维修费用->状态->改变状态（驳回）    描述：维修编号：[" + _usState.userLoginName + "]";
                            wxfy.Update_WXFYZT(struct_bs_wxfy);
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
                            struct_bs_wxfy.p_wxbh = wxbh;
                            struct_bs_wxfy.p_zt = "4";
                            struct_bs_wxfy.p_bhyy = HF_yc.Value;
                            struct_bs_wxfy.p_czfs = "07";
                            struct_bs_wxfy.p_czxx = "位置：维修费用->状态->改变状态（驳回）    描述：维修编号：[" + _usState.userLoginName + "]";
                            wxfy.Update_WXFYZT(struct_bs_wxfy);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                            return;
                        }
                    }
                    if (zt == "0")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该条请示登记未提交，不能驳回！\")</script>");
                        return;
                    }
                    else if (zt == "3")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该条请示登记已驳回，不可重复驳回！\")</script>");
                        return;
                    }
                    else if (zt == "4")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该员工奖励信息已驳回，不可重复驳回！\")</script>");
                        return;
                    }
                    else
                    {
                        //执行update改变状态（驳回）
                        struct_bs_wxfy.p_wxbh = wxbh;
                        struct_bs_wxfy.p_zt = "3";
                        struct_bs_wxfy.p_bhyy = HF_yc.Value;
                        struct_bs_wxfy.p_czfs = "03";
                        struct_bs_wxfy.p_czxx = "位置：报送->维修费用->状态->改变状态（驳回） 描述：员工编号：[" + _usState.userLoginName + "]";
                        wxfy.Update_WXFYZT(struct_bs_wxfy);
                    }
                }

            }
            //报销登记
            else if (e.CommandName == "Bxdj")
            {
                string[] content_bxdj = new string[2];
                content_bxdj = e.CommandArgument.ToString().Split('&');
                xmmc = content_bxdj[0];
                if (!zt.Equals("3"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该条请示登记未审核通过,不可报销登记！\")</script>");
                    return;
                }
                else
                {
                    Server.Transfer("BS_WXFY_Bxdj.aspx?xmmc=" + xmmc);
                }
            }
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem li in Repeater1.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
            {
                Label lbl_zt = (Label)li.FindControl("lbl_ztmc");
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