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
    public partial class DQZC_DQGHDTShow : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private DataTable dt_detail;
        private DQGHDT dqghdt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dqghdt = new DQGHDT(_usState);
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }

        private void select_detail()
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = dqghdt.Select_DQGHDT_Detail(id);
            lbl_bt.Text = dt_detail.Rows[0]["bt"].ToString();//标题
            lbl_nr.Text = dt_detail.Rows[0]["nr"].ToString();//内容
            //lbl_fbr.Text = dt_detail.Rows[0]["fbr"].ToString();//发布人
            lbl_fbsj.Text = string.Format("{0:yyyy-MM-dd}", dt_detail.Rows[0]["fbsj"]);//发布时间
            //lbl_czsj.Text = dt_detail.Rows[0]["czsj"].ToString();//操作时间
           // lbl_fbip.Text = dt_detail.Rows[0]["fbip"].ToString();//发布IP
           // lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
           // lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();//驳回原因
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
            Server.Transfer("DQZC_DYIndex.aspx");
        }
    }
}
