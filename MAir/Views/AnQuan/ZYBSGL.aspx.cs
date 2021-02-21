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
    public partial class ZYBSGL : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        private UserState _usState;
        private ZYBS zybs;
        public Struct_ZYBS struct_zybs;
        private string p_czfs;
        private string p_czxx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            struct_zybs = new Struct_ZYBS();
            zybs = new ZYBS(_usState);
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            if (!IsPostBack)
            {
                bind_drop();
                bind_select();

            }
        }
        private void bind_drop()
        {
            //报送类型
            ddlt_bslx.DataTextField = "mc";
            ddlt_bslx.DataValueField = "bm";
            ddlt_bslx.DataSource = SysData.BSLX().Copy();
            ddlt_bslx.DataBind();
            ddlt_bslx.Items.Insert(0, new ListItem("全部", "-1"));
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

        private void bind_select()
        {
            struct_zybs.p_bsyg = tbx_bsyg.Text.ToString().Trim();
            struct_zybs.p_bsgw = ddlt_bsgw.SelectedValue.ToString();
            struct_zybs.p_bslx = ddlt_bslx.SelectedValue.ToString();
            struct_zybs.p_userid = _usState.userID;
            if (tbx_kssj.Text == "")
            {
                struct_zybs.p_jssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_zybs.p_kssj = Convert.ToDateTime(tbx_kssj.Text.Trim());
            }
            if (tbx_kssj.Text == "")
            {
                struct_zybs.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            }
            else
            {
                struct_zybs.p_jssj = Convert.ToDateTime(tbx_jssj.Text.Trim());
            }
           
            
            int count = zybs.SelectBS_ZYBS_Count(struct_zybs);
            pg_fy.TotalRecord = count;
            struct_zybs.p_currentpage = pg_fy.CurrentPage;
            struct_zybs.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = zybs.SelectBS_ZYBS_Pro(struct_zybs);
            dt.Columns.Add("bslxmc");
            dt.Columns.Add("bssjgs");
            dt.Columns.Add("ztmc");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bssjgs"] = Convert.ToDateTime(dr["bssj"]).ToString("yyyy-MM-dd");
                dr["bslxmc"] = SysData.BSLXByKey(dr["bslx"].ToString()).mc;
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;

            }
            ////绑定分页数据源  
            this.rpt_zybs.DataSource = dt.DefaultView;
            this.rpt_zybs.DataBind();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_select();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AnQuan/ZYBS_Add.aspx");
        }

        //protected void rpt_zybs_ItemCommand(object source, RepeaterCommandEventArgs e)
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
        //            Server.Transfer("../AnQuan/ZYBS_Edit.aspx?bsbh=" + bsbh);
        //        }
        //    }

        //    else if (e.CommandName == "Delete")
        //    {
        //        try
        //        {
        //            string bsbh = e.CommandArgument.ToString();
        //            string czxx = "位置：航务综合报送系统->自愿报送信息->删除 报送编号：" + bsbh;
        //            string czfs = "02";
        //            zybs.DeleteBS_ZYBS_byBH(bsbh, czfs, czxx);
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
        //        }
        //        catch (EMException ex)
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));

        //            return;
        //        }
        //    }
        //    bind_select();
        //}
        protected void rpt_zybs_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        Server.Transfer("../AnQuan/ZYBS_Edit.aspx?bsbh=" + bsbh);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该自愿报送信息已提交，不能删除！\")</script>");
                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200204"))
                    {
                        string p_czfs = "04";
                        string czxx = "位置：航务综合信息报送系统->志愿报送->删除 报送编号：" + bsbh;
                        zybs.DeleteBS_ZYBS_byBH(bsbh, p_czfs, czxx);
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该自愿报送信息已提交，不可重复提交！\")</script>");
                    return;
                }
                else
                if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该自愿报送信息已通过审核，不可提交！\")</script>");
                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200205"))
                    {
                        zybs.Update_ZYBSZT(id, "2", "");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"提交成功！\")</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该自愿报送信息的提交权限，不能提交！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_SH")
            {
                if (zt == "0" || zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该自愿报送信息未提交，不能审核！\")</script>");

                    return;
                }
                else
                if (zt == "3")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该自愿报送信息已通过审核，不可重复审核！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200206"))
                    {
                        zybs.Update_ZYBSZT(id, "3", "");
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('审核成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该自愿报送信息的审核权限，不能审核！\")</script>");
                        return;
                    }
                }
            }
            else if (e.CommandName == "Update_BH")
            {
                if (zt == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该自愿报送信息未提交，不能驳回！\")</script>");

                    return;
                }
                else
                if (zt == "4")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该自愿报送信息已驳回，不可重复驳回！\")</script>");

                    return;
                }
                else
                {
                    if (SysData.HasThisBMQX(_usState.userID, bmdm, "200207"))
                    {
                        string bhyy = HF_yc.Value;
                        zybs.Update_ZYBSZT(id, "4", bhyy);
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('驳回成功！');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"您还没有该信息的驳回权限，不能驳回！\")</script>");
                        return;
                    }
                }
            }
            bind_select();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_select();
        }
    }
}