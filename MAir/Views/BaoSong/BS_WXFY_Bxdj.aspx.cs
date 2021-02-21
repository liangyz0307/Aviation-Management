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
    public partial class BS_WXFY_Bxdj : System.Web.UI.Page
    {
        public int cpage1;
        public int psize1;
        public int cpage2;
        public int psize2;
        private UserState _usState;
        private WXFY wxfy;
        private Struct_Bs_Wxfy_Bxdj struct_bs_bxdj;//报销登记结构体
        private Struct_Bs_Wxfy_Bxdj_Mx struct_bs_bxdj_mx;//报销登记结构体明细
        public int cpage;
        public int psize;
        private string mxbh;
        private string xmmc;
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
                bind_Main();
              //  show();
            }
        }
        public void show()
        {
            btn_add_bxdj.Visible = false;
            btn_add_bxdj_mx.Visible = false;
            if (SysData.HasThisQX("130302", _usState.userID, "01") == true)
            {
                btn_add_bxdj.Visible = true;
                btn_add_bxdj_mx.Visible = true;
            }
            if (SysData.HasThisQX("130302", _usState.userID, "02") == true)
            {
                btn_add_bxdj.Visible = true;
                btn_add_bxdj_mx.Visible = true;
            }
            if (SysData.HasThisQX("130302", _usState.userID, "03") == true)
            {
                btn_add_bxdj.Visible = true;
                btn_add_bxdj_mx.Visible = true;
            }
            if (SysData.HasThisQX("130302", _usState.userID, "04") == true)
            {
                btn_add_bxdj.Visible = true;
                btn_add_bxdj_mx.Visible = true;
            }
            if (SysData.HasThisQX("130302", _usState.userID, "05") == true)
            {
                btn_add_bxdj.Visible = true;
                btn_add_bxdj_mx.Visible = true;
            }
        }


        private void bind_Main()
        {
            #region 报销登记
            struct_bs_bxdj.p_xmmc = Request.Params["xmmc"].ToString();
            DataTable dt_bxdj = wxfy.Select_Bxdj_ByXmmc(struct_bs_bxdj);
            dt_bxdj.Columns.Add("xmmcmc");
            dt_bxdj.Columns.Add("sjyszxjcmc");
            dt_bxdj.Columns.Add("ztmc");
            dt_bxdj.Columns.Add("djrqmc");
            //项目名称
            string xmmc_sbzl;
            string xmmc_sbwz;
            string xmmc_sblx;
            foreach (DataRow dr in dt_bxdj.Rows)
            {
                //状态
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;
                //项目名称
                xmmc_sbzl = dr["xmmc"].ToString().Substring(0, 2);//项目名称_设备种类
                xmmc_sbwz = dr["xmmc"].ToString().Substring(2, 2);//项目名称_设备位置
                xmmc_sblx = dr["xmmc"].ToString().Substring(4, 4);//项目名称_设备类型               
                dr["xmmcmc"] = SysData.SBZLByKey(xmmc_sbzl).mc + xmmc_sbwz + SysData.SBLXByKey(xmmc_sblx).mc;
                //实际预算执行机场
                dr["sjyszxjcmc"] = SysData.ZXDMByKey(dr["sjyszxjc"].ToString()).mc;
                //登记日期    
                DateTime dt_djrq = new DateTime();
                dt_djrq = Convert.ToDateTime(dr["djrq"].ToString());
                dr["djrqmc"] = string.Format("{0:yyyy-MM-dd}",dt_djrq);
                //dr["djrqmc"] = dr["djrq"].ToString().Trim().Substring(0, 10);
            }
            //绑定分页数据源  (报销登记)
            this.Repeater1.DataSource = dt_bxdj.DefaultView;
            this.Repeater1.DataBind();
            #endregion


            #region 报销登记明细
            struct_bs_bxdj_mx.p_xmmc = Request.Params["xmmc"].ToString();
            DataTable dt_bxdj_mx = wxfy.Select_Bxdj_Mx_ByXmmc(struct_bs_bxdj_mx);
            dt_bxdj_mx.Columns.Add("xmmcmc");
            //项目名称
            string xmmc_sbzl_mx;
            string xmmc_sbwz_mx;
            string xmmc_sblx_mx;
            foreach (DataRow dr in dt_bxdj_mx.Rows)
            {
                //项目名称
                xmmc_sbzl_mx = dr["xmmc"].ToString().Substring(0, 2);//项目名称_设备种类
                xmmc_sbwz_mx = dr["xmmc"].ToString().Substring(2, 2);//项目名称_设备位置
                xmmc_sblx_mx = dr["xmmc"].ToString().Substring(4, 4);//项目名称_设备类型               
                dr["xmmcmc"] = SysData.SBZLByKey(xmmc_sbzl_mx).mc + xmmc_sbwz_mx + SysData.SBLXByKey(xmmc_sblx_mx).mc;
            }
            //绑定分页数据源  (报销登记)
            this.Repeater2.DataSource = dt_bxdj_mx.DefaultView;
            this.Repeater2.DataBind();
            #endregion
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
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            xmmc = content[0];
            string zt = content[1];
            if (e.CommandName == "Delete")
            {
                struct_bs_bxdj = new Struct_Bs_Wxfy_Bxdj();
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该条报销登记已提交，不能删除！\")</script>");
                    return;
                }
                else if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该条报销登记已审核通过，不能删除！\")</script>");
                    return;
                }
                else if (zt == "0" || zt == "3")
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：报送->维修费用->报销登记->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                    wxfy.Delete_Bs_Bxdj(xmmc, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }
            }
            
            bind_Main();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            
        }


        //明细

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] content = new string[2];
            content = e.CommandArgument.ToString().Split('&');
            mxbh = content[0];
            string zt = content[1];
            if (e.CommandName == "Delete")
            {
                struct_bs_bxdj_mx = new Struct_Bs_Wxfy_Bxdj_Mx();
                if (zt == "1")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该条报销登记已提交，不能删除！\")</script>");
                    return;
                }
                else if (zt == "2")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"该条报销登记已审核通过，不能删除！\")</script>");
                    return;
                }
                else if (zt == "0" || zt == "3")
                {
                    string p_czfs = "03";
                    string p_czxx = "位置：报送->维修费用->报销登记->明细->删除    描述：员工编号：[" + _usState.userLoginName + "]";
                    wxfy.Delete_Bs_Bxdj_Mx_ByMxbh(mxbh, p_czfs, p_czxx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"删除成功！\")</script>");
                }
            }            
            bind_Main();
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void btn_add_bxdj_click(object sender, EventArgs e)
        {
            Response.Redirect("BS_BXDJ_Add.aspx?xmmc=" + Request.Params["xmmc"].ToString());
        }

        protected void btn_add_bxdj_mx_click(object sender, EventArgs e)
        {
            Response.Redirect("BS_BXDJ_Mx_Add.aspx?xmmc=" + Request.Params["xmmc"].ToString());
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Server.Transfer("BS_WXFY.aspx");
        }
        
    }
}