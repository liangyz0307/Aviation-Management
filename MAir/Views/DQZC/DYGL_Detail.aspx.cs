using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class DYGL_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private DYGL yg1;
        private Struct_DY_Pro strcut_dy;
        private string bh;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            yg1 = new DYGL(_usState);
            strcut_dy = new Struct_DY_Pro();
            if (!IsPostBack)
            {
               
                bh = Request.Params["bh"].ToString();
              
                select_detail();
            }
        }
        private void select_detail()
        {
            dt_detail = yg1.Select_DYDetail(bh).Tables[0];
            lbl_bh.Text = dt_detail.Rows[0]["bh"].ToString();
            lbl_xm.Text = dt_detail.Rows[0]["xm"].ToString();
            lbl_sfzh.Text = dt_detail.Rows[0]["sfzh"].ToString();
            lbl_xbdm.Text = SysData.XBByKey(dt_detail.Rows[0]["xbdm"].ToString()).mc;
            lbl_csrq.Text = dt_detail.Rows[0]["csrq"].ToString().Substring(0, 10);
            lbl_xldm.Text = SysData.XLByKey(dt_detail.Rows[0]["xldm"].ToString()).mc;
            lbl_lxdh.Text = dt_detail.Rows[0]["lxdh"].ToString();
            lbl_dzzmc.Text = dt_detail.Rows[0]["dzzmc"].ToString();
            lbl_jcdzbmc.Text = SysData.JCDZBMCByKey(dt_detail.Rows[0]["jcdzbmc"].ToString()).mc;
            lbl_dxzmc.Text = SysData.DXZMCByKey(dt_detail.Rows[0]["dxzmc"].ToString()).mc;
            lbl_dnzw.Text = dt_detail.Rows[0]["dnzw"].ToString();
            lbl_ygxs.Text = SysData.YGXSByKey(dt_detail.Rows[0]["ygxs"].ToString()).mc;
            lbl_jrdzzsj.Text = dt_detail.Rows[0]["jrdzzsj"].ToString().Substring(0,10);
            lbl_zwzsdyrq.Text = dt_detail.Rows[0]["zwzsdyrq"].ToString().Substring(0, 10);
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            //lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
            //lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();
            lbl_dylx.Text = SysData.DYLXByKey(dt_detail.Rows[0]["dylx"].ToString()).mc;
            lbl_djrdsqssj.Text = dt_detail.Rows[0]["djrdsqssj"].ToString().Substring(0, 10);
            lbl_lwrdjjfzsj.Text = dt_detail.Rows[0]["lwrdjjfzsj"].ToString().Substring(0, 10);
            lbl_pyr1.Text = dt_detail.Rows[0]["pyr1"].ToString();
            lbl_pyr2.Text = dt_detail.Rows[0]["pyr2"].ToString();
            lbl_jjfzpxbbysj.Text = dt_detail.Rows[0]["jjfzpxbbysj"].ToString().Substring(0, 10);
            lbl_qdwfzdxsj.Text = dt_detail.Rows[0]["qdwfzdxsj"].ToString().Substring(0, 10);
            lbl_jsr1.Text = dt_detail.Rows[0]["jsr1"].ToString();
            lbl_jsr2.Text = dt_detail.Rows[0]["jsr2"].ToString();
            lbl_zzqk.Text = SysData.ZZQKByKey(dt_detail.Rows[0]["zzqk"].ToString()).mc;
            lbl_dfje.Text = dt_detail.Rows[0]["dfje"].ToString();
            lbl_dfjzrq.Text = dt_detail.Rows[0]["dfjzrq"].ToString().Substring(0, 10);

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
            Response.Redirect("../DQZC/DYCX.aspx", false);
        }
    }
}