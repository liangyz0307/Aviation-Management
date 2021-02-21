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
    public partial class BS_TQCZ : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private TQCZ tqcz;
        private Struct_TQCZ struct_select_tqcz;
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
            tqcz = new TQCZ(_usState);
            struct_select_tqcz = new Struct_TQCZ();
            if (!IsPostBack)
            {
                ddltBind();
                bind_Main();
            }
        }

        private void ddltBind()
        {
            //报送岗位
            ddlt_bsgw.DataSource = SysData.GW().Copy();
            ddlt_bsgw.DataTextField = "mc";
            ddlt_bsgw.DataValueField = "bm";
            ddlt_bsgw.DataBind();
            ddlt_bsgw.Items.Insert(0, new ListItem("全部", "-1"));
            //状态
            ddlt_zt.DataSource = SysData.ZTDM().Copy();
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void bind_Main()
        {
            
            struct_select_tqcz.p_bsyg = tbx_bsyg.Text.ToString().Trim();
            struct_select_tqcz.p_bsgw = ddlt_bsgw.SelectedValue.ToString();
            struct_select_tqcz.p_zt = ddlt_zt.SelectedValue.ToString();
            struct_select_tqcz.p_userid = _usState.userID;
            if (tbx_kssj.Text == "")
            {
                struct_select_tqcz.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_select_tqcz.p_kssj = Convert.ToDateTime(tbx_kssj.Text);
            }
            if (tbx_kssj.Text == "")
            {
                struct_select_tqcz.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_select_tqcz.p_jssj = Convert.ToDateTime(tbx_jssj.Text);
            }
            int count = tqcz.Select_TQCZ_Count(struct_select_tqcz);
            pg_fy.TotalRecord = count;
            struct_select_tqcz.p_currentpage = pg_fy.CurrentPage;
            struct_select_tqcz.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = tqcz.Select_TQCZ_Pro(struct_select_tqcz);
            dt.Columns.Add("bm");
            dt.Columns.Add("gw");
            dt.Columns.Add("bssjlx");
            dt.Columns.Add("sfsjlx");
            dt.Columns.Add("bgsjlx");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("zrdwmc");

            foreach (DataRow dr in dt.Rows)
            {
                dr["zrdwmc"] = SysData.BMByKey(dr["zrdw"].ToString()).mc;
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["gw"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;
                dr["bsgw"] = SysData.GWByKey(dr["bsgw"].ToString()).mc;
                dr["bssjlx"] = Convert.ToDateTime(dr["bssj"].ToString()).ToString("yyyy-MM-dd");
                dr["sfsjlx"] = Convert.ToDateTime(dr["sfsj"].ToString()).ToString("yyyy-MM-dd");
                dr["bgsjlx"] = Convert.ToDateTime(dr["bgsj"].ToString()).ToString("yyyy-MM-dd");
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
            Response.Redirect("../AnQuan/BS_TQCZ_Add.aspx", true);
        }

        //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Edit")
        //    {
        //        string[] czcs = new string[2];
        //        czcs = e.CommandArgument.ToString().Split('&');
        //        string bsbh = czcs[0];
        //        string bszt = czcs[1];
        //        if (bszt.ToString() != "0")
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('此状态不能编辑！');</script>");

        //        }
        //        else
        //        {
        //            Server.Transfer("../AnQuan/BS_TQCZ_Edit.aspx?bsbh=" + bsbh);
        //        }
        //    }
        //    else if (e.CommandName == "Delete")
        //    {
        //        string bsbh = e.CommandArgument.ToString();
        //        string czxx = "位置：航务综合信息报送系统->特情处置->删除 报送编号：" + bsbh;
        //        string czfs = "03";
        //        tqcz.Delete_TQCZ_byBH(bsbh, czfs, czxx);
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('删除成功！');</script>");
        //    }
        //    bind_Main();
        //}
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
                if (zt.ToString() != "0" || zt.ToString() != "3" || zt.ToString() != "4")
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200203"))
                    {
                        Server.Transfer("../AnQuan/BS_TQCZ_Edit.aspx?bsbh=" + bsbh);
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
                        string czxx = "位置：航务综合信息报送系统->特情处置->删除 报送编号：" + bsbh;
                        tqcz.Delete_TQCZ_byBH(bsbh, p_czfs, czxx);
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
                        tqcz.Update_TQCZZT(id, "2", "");
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
                        tqcz.Update_TQCZZT(id, "3", "");
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
                        tqcz.Update_TQCZZT(id, "4", bhyy);
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