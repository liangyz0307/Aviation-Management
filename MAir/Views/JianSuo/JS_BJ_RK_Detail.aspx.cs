using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class JS_BJ_RK_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJRK struct_bjrk;
        private BMGW bmgw;
        private DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            bj = new BJ(_usState);
            bmgw = new BMGW(_usState);
            if (!IsPostBack)
            {
                //bind_drop();
                bind_select();

            }
        }

        private void bind_select()
        {
            string id = Request.Params["id"].ToString();
            dt = bj.Select_BJRKbyID(id).Tables[0];

            lbl_bjbh.Text = dt.Rows[0]["bh"].ToString();
            lbl_bjmc.Text = dt.Rows[0]["bjmc"].ToString();
            lbl_bz.Text = dt.Rows[0]["bz"].ToString();
            lbl_cfwz.Text = dt.Rows[0]["cfwz"].ToString();
            DateTime dt_rksj = new DateTime();
            dt_rksj = Convert.ToDateTime(dt.Rows[0]["rksj"].ToString());
            lbl_rksj.Text = string.Format("{0:yyyy-MM-dd}", dt_rksj);
            lbl_rksl.Text = dt.Rows[0]["rksl"].ToString();

            lbl_fzr.Text = dt.Rows[0]["fzrxm"].ToString();
            lbl_jbr.Text = dt.Rows[0]["jbrxm"].ToString();

            lbl_fzrbm.Text = SysData.BMByKey(dt.Rows[0]["fzrbm"].ToString()).mc;
            lbl_fzrgw.Text = SysData.GWByKey(dt.Rows[0]["fzrgw"].ToString()).mc;
            lbl_jbrbm.Text = SysData.BMByKey(dt.Rows[0]["jbrbm"].ToString()).mc;
            lbl_jbrgw.Text = SysData.GWByKey(dt.Rows[0]["jbrgw"].ToString()).mc;
            lbl_sjszbm.Text = SysData.BMByKey(dt.Rows[0]["bmdm"].ToString()).mc;
            lbl_bjfl.Text = SysData.BJLXByKey(dt.Rows[0]["bjfl"].ToString()).mc;
            lbl_bjsy.Text = SysData.BJSYByKey(dt.Rows[0]["sy"].ToString()).mc;

            lbl_bhyy.Text = dt.Rows[0]["bhyy"].ToString();//驳回原因

            lbl_lrr.Text = dt.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt.Rows[0]["zsrxm"].ToString();//终审人


        }



        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SBBJ.aspx");
        }




    }
}