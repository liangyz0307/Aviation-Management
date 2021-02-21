using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace CUST.WKG
{

    public partial class JS_BJDetail : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJ struct_bj;
        private string bjbh;
        private Struct_BJRK struct_bjrk;
        private Struct_BJCK struct_bjck;
        private int id;
        public int cpage_rk;
        public int psize_rk;
        public int cpage_ck;
        public int psize_ck;
        DataTable dt_detail;
        string bjsjc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }

            bj = new BJ(_usState);
            struct_bj = new Struct_BJ();
            struct_bjrk = new Struct_BJRK();
            struct_bjck = new Struct_BJCK();
            cpage_rk = pg_fy_rk.CurrentPage;
            psize_rk = pg_fy_rk.NumPerPage;
            cpage_ck = pg_fy_ck.CurrentPage;
            psize_ck = pg_fy_ck.NumPerPage;
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                select_detail(id);

            }

        }


        private void select_detail(int id)
        {
            dt_detail = bj.Select_BJbyBJBH(id).Tables[0];
            bjsjc = dt_detail.Rows[0]["sjc"].ToString();
            dt_detail.Columns.Add("bjflmc");//后果严重程度
            dt_detail.Columns.Add("symc");
            dt_detail.Columns.Add("shjsbmmc");
            dt_detail.Columns.Add("ztmc");

            foreach (DataRow dr in dt_detail.Rows)
            {
                dr["bjflmc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;//岗位
                dr["symc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc; //来源
                dr["shjsbmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc; //来源
                dr["ztmc"] = SysData.ZTByKey(dr["zt"].ToString()).mc; //来源

                lbl_bjbh.Text = dt_detail.Rows[0]["bjbh"].ToString();
                lbl_bjmc.Text = dt_detail.Rows[0]["bjmc"].ToString();
                lbl_sbxh.Text = dt_detail.Rows[0]["sbxh"].ToString();
                lbl_bjfl.Text = dt_detail.Rows[0]["bjflmc"].ToString();
                lbl_bjzwmc.Text = dt_detail.Rows[0]["bjzwmc"].ToString();
                lbl_nhzj.Text = dt_detail.Rows[0]["nhzj"].ToString();
                lbl_nhzjmc.Text = dt_detail.Rows[0]["nhzjmc"].ToString();
                lbl_ywmc.Text = dt_detail.Rows[0]["ywmc"].ToString();
                lbl_yjsl.Text = dt_detail.Rows[0]["yjsl"].ToString();
                lbl_bjsbh.Text = dt_detail.Rows[0]["bjsbh"].ToString();
                lbl_bjsy.Text = dt_detail.Rows[0]["symc"].ToString();
                lbl_xybjsl.Text = dt_detail.Rows[0]["xybjsl"].ToString();
                lbl_cfwz.Text = dt_detail.Rows[0]["cfwz"].ToString();
                lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();

                lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
                lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
                lbl_shjsbmmc.Text = dt_detail.Rows[0]["shjsbmmc"].ToString();

            }

            select_detail_ck(bjsjc);
            select_detail_rk(bjsjc);
        }

        private void select_detail_rk(string bjsjc)
        {
            struct_bjrk.p_bjbh = bjsjc;
            struct_bjrk.p_bjfl = "-1";
            struct_bjrk.p_sy = "-1";
            struct_bjrk.p_jbrxm = "";
            struct_bjrk.p_jbrbm = "-1";
            struct_bjrk.p_jbrgw = "-1";
            struct_bjrk.p_fzrxm = "";
            struct_bjrk.p_fzrbm = "-1";
            struct_bjrk.p_fzrgw = "-1";
            struct_bjrk.p_zxdm = _usState.userSS;
            struct_bjrk.p_userid = _usState.userID;
            struct_bjrk.p_zt = "-1";

                DateTime dt_kssj = new DateTime();
                struct_bjrk.p_kssj = dt_kssj;
                struct_bjrk.p_jssj = DateTime.Now;

            int count = bj.Select_BJRK_Count(struct_bjrk);
            pg_fy_rk.TotalRecord = count;
            struct_bjrk.p_currentpage = pg_fy_rk.CurrentPage;
            struct_bjrk.p_pagesize = pg_fy_rk.NumPerPage;
            DataTable dt = bj.Select_BJRK_Pro(struct_bjrk).Tables[0];

            dt.Columns.Add("bjfl_mc");
            dt.Columns.Add("bjsy_mc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("rksjz");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjfl_mc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bjsy_mc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;
                dr["rksjz"] = DateTime.Parse(dr["rksj"].ToString()).ToString("yyyy-MM-dd");
            }

            ////绑定分页数据源  
            this.Repeater_rk.DataSource = dt.DefaultView;
            this.Repeater_rk.DataBind();
        }
        private void select_detail_ck(string bjsjc)
        {
            struct_bjck.p_bjbh = bjsjc;
            struct_bjck.p_bjfl = "-1";
            struct_bjck.p_sy = "-1";
            struct_bjck.p_jbrxm = "";
            struct_bjck.p_jbrbm = "-1";
            struct_bjck.p_jbrgw = "-1";
            struct_bjck.p_fzrxm = "";
            struct_bjck.p_fzrbm = "-1";
            struct_bjck.p_fzrgw = "-1";
            struct_bjck.p_zxdm = _usState.userSS;
            struct_bjck.p_zt = "-1";
            struct_bjck.p_userid = _usState.userID;

                DateTime dt_kssj = new DateTime();
                struct_bjck.p_kssj = dt_kssj;
                struct_bjck.p_jssj = DateTime.Now;

            int count = bj.Select_BJCK_Count(struct_bjck);
            pg_fy_ck.TotalRecord = count;
            struct_bjck.p_currentpage = pg_fy_ck.CurrentPage;
            struct_bjck.p_pagesize = pg_fy_ck.NumPerPage;
            DataTable dt = bj.Select_BJCK_Pro(struct_bjck).Tables[0];

            dt.Columns.Add("bjfl_mc");
            dt.Columns.Add("bjsy_mc");
            dt.Columns.Add("ztmc");
            dt.Columns.Add("bmmc");
            dt.Columns.Add("cksjz");
            foreach (DataRow dr in dt.Rows)
            {
                dr["bjfl_mc"] = SysData.BJLXByKey(dr["bjfl"].ToString()).mc;
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["bjsy_mc"] = SysData.BJSYByKey(dr["sy"].ToString()).mc;
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;
                dr["cksjz"] = DateTime.Parse(dr["cksj"].ToString()).ToString("yyyy-MM-dd");
            }

            ////绑定分页数据源  
            this.Repeater_ck.DataSource = dt.DefaultView;
            this.Repeater_ck.DataBind();
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SBBJ.aspx");
        }

        protected void pg_fy_PageChanged_ck(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            select_detail(id);
        }
        protected void pg_fy_PageChanged_rk(object sender, EventArgs e)
        {
            select_detail_rk(bjsjc);
        }

    }
}