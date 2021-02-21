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
    public partial class JS_YGZC_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private YGZC ygzc;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygzc = new YGZC(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }

        private void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = ygzc.Select_YGZC_Detail(id);
            lbl_spr.Text = dt_detail.Rows[0]["sprxm"].ToString();//受聘人
            lbl_lb.Text = SysData.QZZYByKey(dt_detail.Rows[0]["lb"].ToString()).mc;//类别
            lbl_jb.Text = SysData.JBByKey(dt_detail.Rows[0]["jb"].ToString()).mc;//级别
            lbl_zg.Text = SysData.ZGByKey(dt_detail.Rows[0]["zg"].ToString()).mc;//资格
            lbl_pr.Text = SysData.PRByKey(dt_detail.Rows[0]["pr"].ToString()).mc;//是否聘任
            lbl_zgsqdw.Text = dt_detail.Rows[0]["zgsqdw"].ToString();//资格审权单位
            lbl_hdsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["hdsj"]);//获得时间
            lbl_dqsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["dqsj"]);//到期时间
            lbl_prsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["prsj"]);//聘任时间
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();//驳回原因
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
            lbl_shsj.Text = dt_detail.Rows[0]["shsj"].ToString();//审核时间
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
            Server.Transfer("JS_YG.aspx");
        }


    }
}