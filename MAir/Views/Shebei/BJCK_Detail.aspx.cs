using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class BJCK_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJCK struct_bjck;
        private Struct_BJ struct_bj;
        private BMGW bmgw;
        private DataTable dt;
        public int cpage;
        public int psize;

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
                bind_select();
            }
        }
        private void bind_select()
        {
            string id = Request.Params["id"].ToString();
            DataTable dt = bj.Select_BJCKbyID(id).Tables[0];

            dt.Columns.Add("bjflmc");
            dt.Columns.Add("symc");
            dt.Columns.Add("fzrbmmc");
            dt.Columns.Add("fzrgwmc");
            dt.Columns.Add("jbrbmmc");
            dt.Columns.Add("jbrgwmc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("sjssbmmc");


            foreach (DataRow dr in dt.Rows)
            {

                dr["bjflmc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;//状态
                dr["symc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;
                dr["fzrbmmc"] = SysData.BMByKey(dr["fzrbm"].ToString()).mc;
                dr["fzrgwmc"] = SysData.GWByKey(dr["fzrgw"].ToString()).mc;
                dr["jbrbmmc"] = SysData.BMByKey(dr["jbrbm"].ToString()).mc;
                dr["jbrgwmc"] = SysData.GWByKey(dr["jbrgw"].ToString()).mc;
                dr["sjssbmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc;


                lbl_bjbh.Text = dt.Rows[0]["bh"].ToString();
                lbl_bjmc.Text = dt.Rows[0]["bjmc"].ToString();
                lbl_rkbz.Text = dt.Rows[0]["bz"].ToString();
                lbl_cfwz.Text = dt.Rows[0]["cfwz"].ToString();
                DateTime dt_cksj = new DateTime();
                dt_cksj = Convert.ToDateTime(dt.Rows[0]["cksj"].ToString());
                lbl_cksj.Text = string.Format("{0:yyyy-MM-dd }", dt_cksj);
                //tbx_cksj.Text= dt.Rows[0]["cksj"].ToString();
                lbl_cksl.Text = dt.Rows[0]["cksl"].ToString();
                lbl_fzr.Text = dt.Rows[0]["fzrxm"].ToString();//ddlt_fzr
                lbl_fzrbm.Text = dt.Rows[0]["fzrbmmc"].ToString();//ddlt_fzrbm
                lbl_fzrgw.Text = dt.Rows[0]["fzrgwmc"].ToString();//ddlt_fzrgw

                lbl_jbr.Text = dt.Rows[0]["jbrxm"].ToString();//ddlt_jbr

                lbl_jbrbm.Text = dt.Rows[0]["jbrbmmc"].ToString();//ddlt_jbrbm
                lbl_jbrgw.Text = dt.Rows[0]["jbrgwmc"].ToString();//ddlt_jbrgw
                lbl_bjfl.Text = dt.Rows[0]["bjflmc"].ToString();//ddlt_bjfl
                lbl_bjsy.Text = dt.Rows[0]["symc"].ToString();//ddlt_bjsy

                lbl_lrr.Text = dt.Rows[0]["lrrxm"].ToString();//录入人
                lbl_csr.Text = dt.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt.Rows[0]["zsrxm"].ToString();//终审人
                lbl_sjszbm.Text = dt.Rows[0]["sjssbmmc"].ToString();//数据所属部门

            }
        }






        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBBJ_CK.aspx");
        }


    }
}