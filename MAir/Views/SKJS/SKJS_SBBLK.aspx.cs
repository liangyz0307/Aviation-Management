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
    public partial class SKJS_SBBLK : System.Web.UI.Page
    {
        private UserState _usState;
        //private UserState _us;
        public int cpage;
        public int psize;
        private SBBLK sbblk;
        private Struct_Select_SBBLK struct_select_sbblk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if((_usState = (Session["UserState"]as UserState))==null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            sbblk = new SBBLK(_usState);
            struct_select_sbblk = new Struct_Select_SBBLK();
            if(!IsPostBack)
            {
                Bind();
                bind_Main();
             
            }
        }
       
      
        private void bind_Main()
        {
            struct_select_sbblk.p_sbmc = tbx_sbmc.Text.Trim().ToString();//设备名称
            struct_select_sbblk.p_bypc = ddlt_bypc.SelectedValue.ToString();//保养频次
            struct_select_sbblk.p_userid = _usState.userID;
            struct_select_sbblk.p_currentpage = pg_fy.CurrentPage;
            struct_select_sbblk.p_pagesize = pg_fy.NumPerPage;
            int count = sbblk.Select_SBBLK_Count(struct_select_sbblk);
            
            pg_fy.TotalRecord = count;
            DataTable dt = sbblk.Select_SBBLK_Pro(struct_select_sbblk);
            dt.Columns.Add("bypcmc");
            dt.Columns.Add("gzsjs");
            dt.Columns.Add("pgsjs");
            dt.Columns.Add("syrxm");
            dt.Columns.Add("wxryxm");
            dt.Columns.Add("bm");
            dt.Columns.Add("ztmc");
            string[] Array_syr = null;
            string[] Array_wxry = null;
            foreach (DataRow dr in dt.Rows)
            {
                Array_syr = dr["syr"].ToString().Split(',');
                Array_wxry = dr["wxry"].ToString().Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += sbblk.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                foreach (string wxryxm_dm in Array_wxry)
                {
                    dr["wxryxm"] += sbblk.Select_YGXMbyBH(wxryxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                dr["bypcmc"] = SysData.BYPCByKey(dr["bypc"].ToString()).mc;
                dr["gzsjs"] = DateTime.Parse(dr["gzsj"].ToString()).ToString("yyyy-MM-dd");
                dr["pgsjs"] = DateTime.Parse(dr["pgsj"].ToString()).ToString("yyyy-MM-dd");
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
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
        protected void Page_Error(object sender,EventArgs e)
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
           Response.Redirect("SKJS_SBBLK_Add.aspx");
        }
        protected void Bind()
        {
            //绑定保养频次
            ddlt_bypc.DataSource = SysData.BYPC().Copy();
            ddlt_bypc.DataTextField = "mc";
            ddlt_bypc.DataValueField = "bm";
            ddlt_bypc.DataBind();
            ddlt_bypc.Items.Insert(0, new ListItem("全部", "-1"));
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息待审核，不能编辑！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    //查询是否有权限编辑
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200103"))
                    {
                        Server.Transfer("SKJS_SBBLK_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该设备病例的编辑权限，不能编辑！\")</script>");
                        return;
                    }
                }

                else if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        Server.Transfer("SKJS_SBBLK_Edit.aspx?id=" + id + "&sjbs=" + sjbs);
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
                struct_select_sbblk = new Struct_Select_SBBLK();
                if (zt == "0" || zt == "4")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：三库建设->设备病例库    描述：员工编号：[" + _usState.userLoginName + "]";
                        sbblk.Delete_SBBLK(id, p_czfs, p_czxx);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
                else if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息待审核，不可删除！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "110504"))
                    {
                        string p_czfs = "04";
                        string p_czxx = "位置：三库建设->设备病例库    描述：员工编号：[" + _usState.userLoginName + "]";
                        sbblk.Delete_SBBLK(id, p_czfs, p_czxx);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该设备病例的删除权限，不可删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_TJ")
            {
                struct_select_sbblk = new Struct_Select_SBBLK();
                if (zt == "0")
                {
                    //如果是本人录入的信息
                    if (lrr.Equals(_usState.userLoginName))
                    {
                        struct_select_sbblk.p_id = id;
                        struct_select_sbblk.p_zt = "1";
                        struct_select_sbblk.p_bhyy = HF_yc.Value;
                        struct_select_sbblk.p_czfs = "05";
                        struct_select_sbblk.p_czxx = "位置：设备病例->状态->改变状态（提交）    描述：员工编号：[" + _usState.userLoginName + "]";
                        sbblk.Update_SBBLKZT(struct_select_sbblk);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交权限，不能提交！\")</script>");
                        return;
                    }
                }
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息待审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息已驳回，请先编辑再提交！\")</script>");
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
                        struct_select_sbblk.p_id = id;
                        struct_select_sbblk.p_zt = "2";
                        struct_select_sbblk.p_bhyy = HF_yc.Value;
                        struct_select_sbblk.p_czfs = "05";
                        struct_select_sbblk.p_czxx = "位置：设备病例->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                        sbblk.Update_SBBLKZT(struct_select_sbblk);
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
                        struct_select_sbblk.p_sjc = sjc;
                        if (sjbs.Equals("0"))
                        {
                            struct_select_sbblk.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_select_sbblk.p_bhyy = HF_yc.Value;
                            struct_select_sbblk.p_czfs = "06";
                            struct_select_sbblk.p_czxx = "位置：设备病例->状态->改变状态（审核）    描述：员工编号：[" + _usState.userLoginName + "]";
                            sbblk.Update_SBBLK_SJBS_ZT(struct_select_sbblk);
                        }
                        else if (sjbs.Equals("2"))
                        {
                            //在这之前，先把原始数据改为历史数据。
                            struct_select_sbblk.p_sjc = sjc;
                            struct_select_sbblk.p_bhyy = HF_yc.Value;
                            struct_select_sbblk.p_czfs = "06";
                            struct_select_sbblk.p_czxx = "位置：设备病例->状态->改变状态（审核） 将原最终数据变为历史数据   描述：员工编号：[" + _usState.userLoginName + "]";
                            sbblk.Update_SBBLK_SJBS_LSSJ_ZT(struct_select_sbblk);

                            //将副本数据变为最终数据
                            struct_select_sbblk.p_shsj = DateTime.Now.ToString("yyyy-MM dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                            struct_select_sbblk.p_bhyy = HF_yc.Value;
                            struct_select_sbblk.p_czfs = "06";
                            struct_select_sbblk.p_czxx = "位置：设备病例->状态->改变状态（审核）将原副本数据变为最终数据    描述：员工编号：[" + _usState.userLoginName + "]";
                            sbblk.Update_SBBLK_SJBS_FBSJ_ZT(struct_select_sbblk);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有提交该设备病例信息，不能审核！\")</script>");
                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息已通过审核，不能重复审核！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息已驳回，请先编辑信息后再提交才能审核！\")</script>");
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
                        struct_select_sbblk.p_id = id;
                        struct_select_sbblk.p_zt = "4";
                        struct_select_sbblk.p_bhyy = HF_yc.Value;
                        struct_select_sbblk.p_czfs = "07";
                        struct_select_sbblk.p_czxx = "位置：设备病例->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        sbblk.Update_SBBLKZT(struct_select_sbblk);
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
                        struct_select_sbblk.p_id = id;
                        struct_select_sbblk.p_zt = "4";
                        struct_select_sbblk.p_bhyy = HF_yc.Value;
                        struct_select_sbblk.p_czfs = "07";
                        struct_select_sbblk.p_czxx = "位置：设备病例->状态->改变状态（驳回）    描述：员工编号：[" + _usState.userLoginName + "]";
                        sbblk.Update_SBBLKZT(struct_select_sbblk);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您不是终审人，不能驳回！\")</script>");
                        return;
                    }
                }

                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息未提交，不能驳回！\")</script>");

                    return;
                }
                else if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息已通过审核，不能驳回！\")</script>");
                    return;
                }
                else if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该设备病例信息已驳回，不可重复驳回！\")</script>");
                    return;
                }
            }
            bind_Main();
        }
    }
}