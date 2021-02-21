﻿using CUST;
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
namespace MAir.Views.YuanGong
{
    public partial class ZZ_Edit_YY : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private string sjc;
        private YGZZ ygzz;
        private Struct_YGZZ struct_ygzz;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../loginAdmin.aspx';</script>");
                Response.End();
                return;
            }
            ygzz = new YGZZ(_usState);
            if (!IsPostBack)
            {
                id = Request.Params["id"].ToString();
                tbx_yyyxq.Attributes.Add("readonly", "readonly");
                bind_dropdownlist();
                select_detail();
                ddltBind();
            }
        }
        
        protected void bind_dropdownlist()
        {
            //英语等级
            ddlt_yydj.DataTextField = "mc";
            ddlt_yydj.DataValueField = "bm";
            ddlt_yydj.DataSource = SysData.YYDJ().Copy();
            ddlt_yydj.DataBind();
            ddlt_yydj.Items.Insert(0, new ListItem("请选择", "-1"));       
        }
        private void ddltBind()
        {
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110203");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();
            ddlt_csr.Items.Insert(0, new ListItem("请选择", "-1"));

            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();
            ddlt_zsr.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        protected void select_detail()
        {
            dt_detail = ygzz.Select_YGZZByZZID(Convert.ToInt32(id));
            lbl_bh.Text = dt_detail.Rows[0]["ygbh"].ToString();//员工编号
            ddlt_yydj.SelectedValue = dt_detail.Rows[0]["s1"].ToString();//英语等级
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            DateTime dt = new DateTime();
            if (dt_detail.Rows[0]["d1"].ToString() != dt.ToString())
            {
                DateTime yyyxq = DateTime.Parse(dt_detail.Rows[0]["d1"].ToString());
                tbx_yyyxq.Text = yyyxq.ToString("yyyy-MM-dd");//英语有效期
            }
            else
            {
                tbx_yyyxq.Text = "";
            }

          



            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();//备注
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;
            //英语等级
            if (ddlt_yydj.SelectedValue.Trim() == "-1")
            {

                lbl_yydj.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yydj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //英语有效期 

            string yyyxq = tbx_yyyxq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(yyyxq))
            {

                lbl_yyyxq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yyyxq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1" || ddlt_csr.SelectedItem.Text.Trim() == "")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1" || ddlt_zsr.SelectedItem.Text.Trim() == "")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1) { return; }
            #endregion
            int check_rz = 0;

            string id = Request.Params["id"].ToString();
            struct_ygzz.p_id = Convert.ToInt32(id);
            struct_ygzz.p_ygbh = lbl_bh.Text.ToString().Trim();//员工编号
            struct_ygzz.p_yydj = ddlt_yydj.SelectedValue.ToString();//英语等级
            if (tbx_yyyxq.Text != "")
            {
                struct_ygzz.p_yyyxq = DateTime.Parse(tbx_yyyxq.Text);//英语有效期
            }
            else
            {
                DateTime dt = new DateTime();
                struct_ygzz.p_yyyxq = dt;
            }

            struct_ygzz.p_lrr = _usState.userLoginName;//录入人
            struct_ygzz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ygzz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_ygzz.p_bz = tbx_bz.Text;//备注
            struct_ygzz.p_czfs = "02";
            struct_ygzz.p_czxx = "位置：员工管理->资质管理->编辑    员工编号：[" + struct_ygzz.p_ygbh + "]  描述：";
            dt_detail = ygzz.Select_YGZZByZZID(Convert.ToInt32(id));
            //英语等级
            if (struct_ygzz.p_yydj != dt_detail.Rows[0]["s1"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "英语等级：【" + dt_detail.Rows[0]["s1"].ToString() + "】->【" + struct_ygzz.p_yydj + "】";
                check_rz = 1;
            }

            //英语有效期
            if (dt_detail.Rows[0]["d1"].ToString() != "")
            {
                if (struct_ygzz.p_yyyxq != DateTime.Parse(dt_detail.Rows[0]["d1"].ToString()))
                {
                    //已修改
                    struct_ygzz.p_czxx += "英语有效期：【" + dt_detail.Rows[0]["d1"].ToString() + "】->【" + struct_ygzz.p_yyyxq + "】";
                    check_rz = 1;
                }
            }
          
            //备注
            if (struct_ygzz.p_bz != dt_detail.Rows[0]["bz"].ToString())
            {
                //已修改
                struct_ygzz.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_ygzz.p_bz + "】";
                check_rz = 1;
            }
         
            if (check_rz == 0)
            {
                struct_ygzz.p_czxx += "未修改";
              
            }
           
            string sjbs = Request.Params["sjbs"].ToString();



            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr))
                {
                    struct_ygzz.p_zt = "2";
                    struct_ygzz.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "3";
                    struct_ygzz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                if (!struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr) && !struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "0";
                    struct_ygzz.p_sjbs = "0";
                }
                ygzz.Update_YGZZ_ENG(struct_ygzz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr))
                {
                    struct_ygzz.p_zt = "2";
                    struct_ygzz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygzz.p_sjc = sjc;
                    ygzz.Update_YGZZ_SJBS_LSSJ_ZT(struct_ygzz);

                    struct_ygzz.p_zt = "3";
                    struct_ygzz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                if (!struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr) && !struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "0";
                    struct_ygzz.p_sjbs = "2";
                }
                ygzz.Update_YGZZ_ENG(struct_ygzz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Request.Params["id"].ToString();
                int id_bf = ygzz.YGZZ_SJBF(Convert.ToInt32(id));
                struct_ygzz.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr))
                {
                    struct_ygzz.p_zt = "2";
                    struct_ygzz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygzz.p_sjc = sjc;
                    ygzz.Update_YGZZ_SJBS_LSSJ_ZT(struct_ygzz);

                    struct_ygzz.p_zt = "3";
                    struct_ygzz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygzz.p_zsr, "11", "1102", Convert.ToInt32(id));
                }
                if (!struct_ygzz.p_lrr.Equals(struct_ygzz.p_csr) && !struct_ygzz.p_lrr.Equals(struct_ygzz.p_zsr))
                {
                    struct_ygzz.p_zt = "0";
                    struct_ygzz.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                ygzz.Update_YGZZ_ENG(struct_ygzz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);


            }

            //if (sjbs.Equals("0") || sjbs.Equals("2"))
            //{
            //    ygzz.Update_YGZZ_ENG(struct_ygzz);
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            //    Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);

            //}
            //else if (sjbs.Equals("1") || sjbs.Equals("3"))
            //{
            //    //生成该数据的副本,并返回新的备份id
            //    id = Request.Params["id"].ToString();
            //    int id_bf = ygzz.YGZZ_SJBF(Convert.ToInt32(id));
            //    struct_ygzz.p_id = id_bf;
            //    ygzz.Update_YGZZ_ENG(struct_ygzz);
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            //    Server.Transfer("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);

            //}
            else
            {
                return;
            }
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
            Response.Redirect("ZZ_Edit.aspx?ygbh=" + lbl_bh.Text);
        }


    }
}