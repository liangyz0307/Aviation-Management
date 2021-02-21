using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BS_YSSB_Detail : System.Web.UI.Page
    {
        private UserState _usState;

        private YSSB yssb;
        private Struct_Bs_Yssb_Update struct_bs_yssb_update;
      //  private string p_id;
        private int id;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}
            yssb = new YSSB(_usState);
            //p_id = Request.QueryString["id"].ToString();
            //struct_bs_yssb_update.p_id = Request.QueryString["id"].ToString();
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail();
            }
        }
        protected void select_detail()
        {
            dt_detail = yssb.Select_Bs_Yssb_Detail(id);
            dt_detail.Columns.Add("yslxmc");
            dt_detail.Columns.Add("bm");
            dt_detail.Columns.Add("sbztmc");
            foreach (DataRow dr in dt_detail.Rows)
            {
                dr["yslxmc"] = SysData.YSLXByKey(dr["yslx"].ToString()).mc;
                dr["bm"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["sbztmc"] = SysData.ZTByKey(dr["sbzt"].ToString()).mc;
            }
                lbl_tbdw.Text = dt_detail.Rows[0]["tbdw"].ToString();
            lbl_yjje.Text = dt_detail.Rows[0]["yjje"].ToString();
            lbl_yslxmc.Text = dt_detail.Rows[0]["yslxmc"].ToString();
            lbl_xmmc.Text = dt_detail.Rows[0]["xmmc"].ToString();
            lbl_whdw.Text = dt_detail.Rows[0]["whdw"].ToString();
            lbl_sbnf.Text = Convert.ToDateTime(dt_detail.Rows[0]["sbnf"]).ToString("yyyy-MM-dd");
            lbl_sjzxje.Text = dt_detail.Rows[0]["sjzxje"].ToString();
            lbl_yszx.Text = dt_detail.Rows[0]["yszx"].ToString();
            lbl_tzyy.Text = dt_detail.Rows[0]["tzyy"].ToString();
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            lbl_wcsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["wcsj"]).ToString("yyyy-MM-dd");
                lbl_sbzt.Text  = dt_detail.Rows[0]["sbztmc"].ToString();
                lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();
                lbl_sjszbm.Text = dt_detail.Rows[0]["bm"].ToString();
                lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
                lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
                lbl_shsj.Text = dt_detail.Rows[0]["shsj"].ToString();//审核时间
            

        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BaoSong/BS_YSSB.aspx", true);
        }
    }
}