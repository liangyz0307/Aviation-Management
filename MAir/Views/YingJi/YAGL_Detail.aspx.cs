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
    public partial class YAGL_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private YAGL yagl;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yagl = new YAGL(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }

        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = yagl.Select_Yj_Yagl_Detail_Proc(id);
            lbl_mc.Text = dt_detail.Rows[0]["mc"].ToString();//日期      
            lbl_dq.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["dq"].ToString()).mc;
            lbl_zy.Text = SysData.ZYLXByKey(dt_detail.Rows[0]["zy"].ToString()).mc;
            lbl_yanr.Text = dt_detail.Rows[0]["yanr"].ToString();//奖励原因
            lbl_sjssbm.Text = dt_detail.Rows[0]["bmmc"].ToString();//奖励内容
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();//驳回原因
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
          //  lbl_shsj.Text = dt_detail.Rows[0]["shsj"].ToString();//审核时间

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
            Response.Redirect("../Yingji/YJ_YAGL.aspx");

        }
    }
}