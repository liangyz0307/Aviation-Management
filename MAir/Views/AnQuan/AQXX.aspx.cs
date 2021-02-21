using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class AQXX : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private FXY fxy;
        private string p_czfs;
        private string p_czxx;
        private Struct_FXY struct_select_fxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            fxy = new FXY(_usState);
            struct_select_fxy = new Struct_FXY();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
            }
        }

        private void ddltBind()
        {
            //DataTable dt_bmdm = SysData.BM().Copy();
            //ddlt_bmdm.DataSource = dt_bmdm;
            //ddlt_bmdm.DataTextField = "mc";
            //ddlt_bmdm.DataValueField = "bm";
            //ddlt_bmdm.DataBind();
            //ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));

            ////风险源状态
            //ddlt_fxyzt.DataSource = SysData.FXYZT().Copy();
            //ddlt_fxyzt.DataTextField = "mc";
            //ddlt_fxyzt.DataValueField = "bm";
            //ddlt_fxyzt.DataBind();
            //ddlt_fxyzt.Items.Insert(0, new ListItem("全部", "-1"));

            ////控制状态
            //ddlt_kzzt.DataSource = SysData.FXKZZT().Copy();
            //ddlt_kzzt.DataTextField = "mc";
            //ddlt_kzzt.DataValueField = "bm";
            //ddlt_kzzt.DataBind();
            //ddlt_kzzt.Items.Insert(0, new ListItem("全部", "-1"));


            //报送岗位
            ddlt_bsgw.DataSource = SysData.GW().Copy();
            ddlt_bsgw.DataTextField = "mc";
            ddlt_bsgw.DataValueField = "bm";
            ddlt_bsgw.DataBind();
            ddlt_bsgw.Items.Insert(0, new ListItem("全部", "-1"));
        }

        private void bind_Main()
        {
            struct_select_fxy.p_bsgw = ddlt_bsgw.SelectedValue.ToString().Trim();//报送岗位
            struct_select_fxy.p_bsyg = tbx_bsygbh.Text.ToString().Trim();//报送员工
            //struct_select_fxy.p_kzzt = ddlt_kzzt.SelectedValue.ToString().Trim();//控制状态
            struct_select_fxy.p_zt = ddlt_zt.SelectedValue.ToString();//状态
            //struct_select_fxy.p_fxyzt = ddlt_fxyzt.SelectedValue.ToString().Trim();//风险源状态
            struct_select_fxy.p_userid = _usState.userID;
            int count = fxy.Select_FXY_Count(struct_select_fxy);
            pg_fy.TotalRecord = count;
            struct_select_fxy.p_currentpage = pg_fy.CurrentPage;
            struct_select_fxy.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = fxy.Select_FXY_Pro(struct_select_fxy);
            dt.Columns.Add("bm");
            dt.Columns.Add("gw");
            //dt.Columns.Add("fxyfcmc");
            //dt.Columns.Add("stmc");
            dt.Columns.Add("fxknxmc");
            dt.Columns.Add("fxcdmc");
            //dt.Columns.Add("fxyztmc"); 
            //dt.Columns.Add("kzztmc");
            dt.Columns.Add("kzcsbzhqkmc");
            dt.Columns.Add("zrbmmc");
            dt.Columns.Add("zrrmc");
            dt.Columns.Add("bssjmc");
            dt.Columns.Add("ztmc");
            //dt.Columns.Add("tqczmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gw"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                dr["bsgw"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;

                //dr["fxyfcmc"] = SysData.WXYFCByKey(dr["fxyfc"].ToString()).mc;
                //dr["stmc"] = SysData.STDMByKey(dr["st"].ToString()).mc;
                dr["fxknxmc"] = SysData.FXFSKNByKey(dr["fxknx"].ToString()).mc;
                //dr["tqczmc"] = SysData.SBLXByKey(dr["tqcz"].ToString()).mc;//特情处置
                dr["fxcdmc"] = SysData.FXCDByKey(dr["fxcd"].ToString()).mc;
                //dr["fxyztmc"] = SysData.FXYZTByKey(dr["fxyzt"].ToString()).mc;
                //dr["kzztmc"] = SysData.FXKZZTByKey(dr["kzzt"].ToString()).mc;
                //dr["kzcsbzhqkmc"] = SysData.FXKZBZByKey(dr["kzzt"].ToString()).mc;
                dr["zrbmmc"] = SysData.BMByKey(dr["zrbm"].ToString()).mc;
                dr["bssjmc"] = Convert.ToDateTime(dr["bssj"].ToString()).ToString("yyyy-MM-dd");
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;
            }
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

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AnQuan/AQXX_Add.aspx", true);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[4];
            content = e.CommandArgument.ToString().Split('&');
            string bsbh = content[0];
            string zt = content[1];
            string bmdm = content[2];
            int id = Convert.ToInt32(content[3]);
            if (e.CommandName == "Edit")
            {
                if (zt.ToString() != "0" || zt.ToString() !="3"|| zt.ToString() != "4")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200203")) {
                        Server.Transfer("../AnQuan/AQXX_Edit.aspx?bsbh=" + bsbh);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
                    }                    
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('此状态不能编辑！');</script>");
                }
            }
            else if (e.CommandName == "Delete")
            {
                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已提交，不能删除！\")</script>");
                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200204"))
                    {
                        string p_czfs = "04";
                        string czxx = "位置：航务综合信息报送系统->风险源分析->删除 报送编号：" + bsbh;
                        fxy.Delete_FXY_byBH(bsbh, p_czfs, czxx);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('删除成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有删除权限，不能删除！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_TJ")
            {

                if (zt == "1" || zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200205"))
                    {
                        fxy.Update_FXYZT(id, "2", "");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"提交成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该资料信息的提交权限，不能提交！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0" || zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息未提交，不能审核！\")</script>");

                    return;
                }
                else
                if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已通过审核，不可重复审核！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200206"))
                    {
                        fxy.Update_FXYZT(id, "3", "");
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('审核成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该资料信息的审核权限，不能审核！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息未提交，不能驳回！\")</script>");

                    return;
                }
                else
                if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该资料信息已驳回，不可重复驳回！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200207"))
                    {
                        string bhyy = HF_yc.Value;
                        fxy.Update_FXYZT(id, "4", bhyy);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('驳回成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该信息的驳回权限，不能驳回！\")</script>");
                        return;
                    }
                }
            }
            bind_Main();
        }
    }
}
