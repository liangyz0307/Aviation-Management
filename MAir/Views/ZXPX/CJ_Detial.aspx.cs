using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG.ZXPX.main
{
    public partial class CJ_Detial : System.Web.UI.Page
    {
        private UserState _usState;
        private ZJ_CL zj_cl;
        private DJK djk;
        private static long zj_cl_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zj_cl = new ZJ_CL(_usState);
            djk = new DJK(_usState);
            if (!IsPostBack)
            {
                zj_cl_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
                DataTable dt_zj_cl = zj_cl.Select_ZJ_CL_Detail(zj_cl_id);
                lbl_mc.Text = dt_zj_cl.Rows[0]["mc"].ToString();
                if (!SysData.HasThisQX("190301", _usState.userID))
                {
                    div_CX.Visible = false;
                    Bind_Select();
                }
            }
        }
        protected void btn_cjcx_Click(object sender, EventArgs e)
        {
            Bind_Select();
        }
        private void Bind_Select()
        {
            string ksh = "";
            if (!SysData.HasThisQX("190301", _usState.userID))//------根据用户的权限，来决定用户可以查询成绩的范围
            {
                ksh = _usState.userLoginName;
            }
            else
            {
                ksh = tbx_ksh.Text.Trim();
            }
            if (ksh== "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"请输入考生号！\")</script>");
                return;
            }
            string cl_id = Convert.ToString(zj_cl_id);
            DataTable dt_djk = djk.Select_DJK_By_KSH_CL_ZT(cl_id, ksh, "1");
            dt_djk.Columns.Add("xzt");
            dt_djk.Columns.Add("dxt");
            dt_djk.Columns.Add("pdt");
            dt_djk.Columns.Add("tkt");
            foreach (DataRow dr in dt_djk.Rows)
            {
                int xz_zq_sl = Convert.ToInt32(dr["xz_zq_sl"].ToString());
                int dx_zq_sl = Convert.ToInt32(dr["dx_zq_sl"].ToString());
                int pd_zq_sl = Convert.ToInt32(dr["pd_zq_sl"].ToString());
                int tk_zq_sl = Convert.ToInt32(dr["tk_zq_sl"].ToString());
                int xz_sl = Convert.ToInt32(dr["xz_sl"].ToString());
                int dx_sl = Convert.ToInt32(dr["dx_sl"].ToString());
                int pd_sl = Convert.ToInt32(dr["pd_sl"].ToString());
                int tk_sl = Convert.ToInt32(dr["tk_sl"].ToString());
                int xz_fz = Convert.ToInt32(dr["xz_fz"].ToString());
                int dx_fz = Convert.ToInt32(dr["dx_fz"].ToString());
                int pd_fz = Convert.ToInt32(dr["pd_fz"].ToString());
                int tk_fz = Convert.ToInt32(dr["tk_fz"].ToString());
                dr["xzt"] = xz_zq_sl * xz_fz + " 分（" + xz_zq_sl + "/" + xz_sl + ")";
                dr["dxt"] = dx_zq_sl * dx_fz + " 分（" + dx_zq_sl + "/" + dx_sl + ")";
                dr["pdt"] = pd_zq_sl * pd_fz + " 分（" + pd_zq_sl + "/" + pd_sl + ")";
                dr["tkt"] = tk_zq_sl * tk_fz + " 分（" + tk_zq_sl + "/" + tk_sl + ")";

            }
            //绑定分页数据源  
            this.dlt_djk.DataSource = dt_djk.DefaultView;
            this.dlt_djk.DataBind();
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZXPX/CJ_GL.aspx", true);
        }
    }
}