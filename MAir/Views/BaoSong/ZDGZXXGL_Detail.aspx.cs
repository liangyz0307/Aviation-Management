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
    public partial class ZDGZXXGL_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private string sjc;
        private ZDGZ zdgz;
        private Struct_ZDGZ struct_zdgz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zdgz = new ZDGZ(_usState);
            struct_zdgz = new Struct_ZDGZ();

            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail(id);
            }
        }
        protected void select_detail(int id)
        {

            DataTable dt_detail = zdgz.SelectBS_ZDGZ_Detail(id);
            lbl_bsbh.Text = dt_detail.Rows[0]["bsbh"].ToString();
            lbl_bsyg.Text = dt_detail.Rows[0]["ygxm"].ToString();
            lbl_bsgw.Text = SysData.GWByKey(dt_detail.Rows[0]["bsgw"].ToString()).mc;
            lbl_bslx.Text = SysData.BSLXByKey(dt_detail.Rows[0]["bslx"].ToString()).mc;
            
            lbl_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            lbl_bszx.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["bszx"].ToString()).mc;
            lbl_zxzx.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["zxzx"].ToString()).mc;
            lbl_gzfzr.Text = dt_detail.Rows[0]["xm"].ToString();
            lbl_gzlc.Text = dt_detail.Rows[0]["gzlc"].ToString();
            lbl_zdgznr.Text = dt_detail.Rows[0]["zdgznr"].ToString();
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            lbl_gzbt.Text = dt_detail.Rows[0]["gzbt"].ToString();
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();
            lbl_sjssbm.Text = SysData.BMByKey(dt_detail.Rows[0]["bmdm"].ToString()).mc;//数据所在部门
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZDGZXXGL.aspx", true);
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

    }
}