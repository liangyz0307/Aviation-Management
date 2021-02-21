using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using System.IO;
using Sys;

namespace CUST.WKG
{
    public partial class DQZC_DYZXDetail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private DYZX dyzx;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dyzx = new DYZX(_usState);
            if (!IsPostBack)
            {

                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }

        }
        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = dyzx.Select_DYZX_Detail(id);
            lbl_sjmc.Text = dt_detail.Rows[0]["sj"].ToString().Substring(0, 10); ;//日期

            lbl_yxdy.Text = dt_detail.Rows[0]["yxdyxm"].ToString();//优秀党员 
            lbl_bm.Text = SysData.BMByKey(dt_detail.Rows[0]["bmdm"].ToString()).mc;//部门
            lbl_gw.Text = SysData.GWByKey(dt_detail.Rows[0]["gwdm"].ToString()).mc;//岗位
            lbl_zysj.Text = dt_detail.Rows[0]["zysj"].ToString();//主要事迹
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();//驳回原因
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
        }

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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Server.Transfer("DQZC_DYZX.aspx");
        }
    }
}