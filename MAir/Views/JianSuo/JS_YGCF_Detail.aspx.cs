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
    public partial class JS_YGCF_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private YGCF ygcf;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygcf = new YGCF(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }

        protected void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = ygcf.Select_YGCF_Detail(id);
            lbl_cfsj.Text = dt_detail.Rows[0]["cfsj"].ToString();//日期
            lbl_sjzl.Text = SysData.SJZLByKey(dt_detail.Rows[0]["sjzl"].ToString()).mc; ;//事件种类
            lbl_fzr.Text = dt_detail.Rows[0]["fzrxm"].ToString();//负责人
            lbl_sfr.Text = dt_detail.Rows[0]["sfrxm"].ToString();//受罚人
            lbl_jyjlhyy.Text = dt_detail.Rows[0]["jyjlhyy"].ToString();//简要经历和原因
            lbl_cdzr.Text = dt_detail.Rows[0]["cdzr"].ToString();//承担责任
            lbl_clyj.Text = dt_detail.Rows[0]["clyj"].ToString();//处理意见
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
            Server.Transfer("YGGL.aspx");
        }
    }
}