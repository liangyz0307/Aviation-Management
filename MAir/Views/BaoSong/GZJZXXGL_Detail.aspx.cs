using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Sys;

namespace CUST.WKG
{
    public partial class GZJZXXGL_Detail : System.Web.UI.Page
    {
        private UserState _usState;

        private GZJZ gzjz;
        private Struct_GZJZ struct_gzjz;
        private string bzsjc;
        private string zt;
        private string sjbs;
        private string id;
        public bool flag = true;
        public int i = 0;
        public string gzfzr;
        protected int totalcontrols
        {
            get
            {
                return ViewState["totcontrols"] == null ? 0 : (int)(ViewState["totcontrols"]);
            }
            set
            {
                ViewState["totcontrols"] = value;
            }
        }
        private DataTable dt_gzjz = new DataTable();
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
            gzjz = new GZJZ(_usState);
            struct_gzjz = new Struct_GZJZ();
            id = Request.Params["id"].ToString();
            bzsjc = Request.Params["bzsjc"].ToString();
            zt = Request.Params["zt"].ToString();
            sjbs = Request.Params["sjbs"].ToString();
            dt_gzjz = gzjz.Select_gzjz_bz(bzsjc,zt,sjbs);
            if (!IsPostBack)
            {
                totalcontrols = dt_gzjz.Rows.Count;
                select_detail(id);
            }


        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;

            }
        }
        protected void select_detail(string bsbh)
        {

            this.rpt_gzjz.DataSource = dt_gzjz.DefaultView;
            this.rpt_gzjz.DataBind();
            DataTable dt_detail = gzjz.SelectBS_GZJZ_Detail(bsbh);
            dt_detail.Columns.Add("gzfzrxm");
            dt_detail.Columns.Add("bsygxm");
            dt_detail.Columns.Add("bszxmc");

            foreach (DataRow dr in dt_detail.Rows)
            {

                string[] Array_gzfzr = dr["gzfzr"].ToString().Split();
                string[] Array_bsyg = dr["bsyg"].ToString().Split();
                foreach (string gzfzrxm in Array_gzfzr)
                {
                    dr["gzfzrxm"] = gzjz.SelectBS_FZR_byBH(dt_detail.Rows[0]["gzfzr"].ToString()).Rows[0][0].ToString();
                    //因SelectBS_FZR_byBH查询的是员工表 所以bsyg一样适用
                    dr["bsygxm"] = gzjz.SelectBS_FZR_byBH(dt_detail.Rows[0]["bsyg"].ToString()).Rows[0][0].ToString();
                }
                dr["bszxmc"] = SysData.ZXDMByKey(dr["bszx"].ToString()).mc;//状态

                struct_gzjz = new CUST.MKG.Struct_GZJZ();
                lbl_bsyg.Text = dt_detail.Rows[0]["bsygxm"].ToString();
                lbl_bsbm.Text = SysData.BMByKey(dt_detail.Rows[0]["bsbm"].ToString()).mc;
                lbl_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
                lbl_bszx.Text = dt_detail.Rows[0]["bszxmc"].ToString();
                lbl_gzzt.Text = dt_detail.Rows[0]["gzzt"].ToString();
                lbl_gznr.Text = dt_detail.Rows[0]["gznr"].ToString();
                lbl_wcjd.Text = dt_detail.Rows[0]["wcjd"].ToString();
                lbl_gzfzr.Text = dt_detail.Rows[0]["gzfzrxm"].ToString();
                lbl_gzlc.Text = dt_detail.Rows[0]["gzlc"].ToString();
                lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();
                lbl_wcsx.Text = Convert.ToDateTime(dt_detail.Rows[0]["wcsx"]).ToString("yyyy-MM-dd");

                lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人


            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("GZJZXXGL.aspx", true);
        }



    }
}