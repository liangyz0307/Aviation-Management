using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CUST.WKG
{
    public partial class BJ_CRHD : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJ struct_bj;
        private string bjbh;
        private int id;
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

            bj = new BJ(_usState);
            struct_bj = new Struct_BJ();
            if (!IsPostBack)
            {

                //ddltBind();
                //show();
                id = Convert.ToInt32(Request.Params["id"].ToString());
                bind_select();
                //lbl_bjbh.Text = bjbh;
                //btn_save.Visible = false;


            }

        }

        private void bind_select()
        {
            string id = Request.Params["id"].ToString();
            DataTable dt = bj.Select_BJRKbyID(id).Tables[0];

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

                lbl_cfwz.Text = dt.Rows[0]["cfwz"].ToString();
                DateTime dt_rksj = new DateTime();
                dt_rksj = Convert.ToDateTime(dt.Rows[0]["rksj"].ToString());

                //tbx_cksj.Text= dt.Rows[0]["cksj"].ToString();
                lbl_sl.Text = dt.Rows[0]["rksl"].ToString();
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (tbx_sl.Text == "" || !Regex.IsMatch(tbx_sl.Text, @"^[0-9]*$"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请填写数字！\")</script>");
                return;
            }
            if (Convert.ToInt32(tbx_sl.Text) <= Convert.ToInt32(lbl_sl.Text))
            {
                string id = Request.Params["id"].ToString();
                DataTable dt = bj.Select_BJRKbyID(id).Tables[0];
                struct_bj.p_sl = Convert.ToString(Convert.ToInt32(lbl_sl.Text) - Convert.ToInt32(tbx_sl.Text));
                struct_bj.p_id = Convert.ToInt32(Request.Params["id"].ToString());
                struct_bj.p_bjbh = lbl_bjbh.Text;
                struct_bj.p_userid = Convert.ToInt32(_usState.userLoginName);
                struct_bj.p_czlx = "出库";
                struct_bj.p_czsj = System.DateTime.Now;
                struct_bj.p_czsl = tbx_sl.Text;
                struct_bj.p_sjc = dt.Rows[0]["sjc"].ToString(); ;
                bj.Update_BJSL(struct_bj);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"出库成功！\")</script>");
                Server.Transfer("../SheBei/SBBJ_RK.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"数量过大！请重新填写数量！\")</script>");
            }
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBBJ_RK.aspx");
        }
    }
}