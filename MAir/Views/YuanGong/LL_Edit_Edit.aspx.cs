using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using System.IO;
using Sys;

namespace CUST.WKG
{
    public partial class LL_Edit_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        public string ygbh;
        private string sjc;
        private YGLL ygll;
        private Struct_YGLL struct_ygll;
        private DataTable dt_detail;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygll = new YGLL(_usState);
            if (!IsPostBack)
            {
                ygbh = Request.Params["ygbh"].ToString();
                id = Request.Params["id"].ToString();
                select_detail();
                tbx_qzrq.Attributes.Add("readonly", "readonly");
                tbx_jzrq.Attributes.Add("readonly", "readonly");
              
                ddltBind();

            }
        
     
        }
      
        private void ddltBind()
        {
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11",_usState.userID, "110303");

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
            dt_detail = ygll.Select_YGLLGL_Detail(Convert.ToInt32(id));
            lbl_bh.Text = dt_detail.Rows[0]["ygbh"].ToString();//员工编号
          //  ddlt_bmdm.SelectedValue = "";
            tbx_gzdw.Text = dt_detail.Rows[0]["gzdw"].ToString();//工作单位
            tbx_gzbm.Text = dt_detail.Rows[0]["gzbm"].ToString();//工作部门
            tbx_gzgw.Text = dt_detail.Rows[0]["gzgw"].ToString();//工作岗位
            tbx_gzdd.Text = dt_detail.Rows[0]["gzdd"].ToString();//工作地点
            tbx_qzrq.Text = dt_detail.Rows[0]["qzrq"].ToString();//起止日期
            tbx_jzrq.Text = dt_detail.Rows[0]["jzrq"].ToString();//截止日期
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();//备注
        }

       

      

        protected void btn_save_Click(object sender, EventArgs e)
        {

            #region 校验
            int flag = 0;

            string gzgw = tbx_gzgw.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzgw))
            {

                lbl_gzgw.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string gzbm = tbx_gzbm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzbm))
            {

                lbl_gzbm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string gzdw = tbx_gzdw.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzdw))
            {

                lbl_gzdw.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzdw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string gzdd = tbx_gzdd.Text.ToString().Trim();
            if (string.IsNullOrEmpty(gzdd))
            {

                lbl_gzdd.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzdd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string qzrq = tbx_qzrq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(qzrq))
            {

                lbl_qzrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_qzrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string jzrq = tbx_jzrq.Text.ToString().Trim();
            if (string.IsNullOrEmpty(jzrq) || DateTime.Compare(Convert.ToDateTime(jzrq), Convert.ToDateTime(qzrq)) <= 0)
            {

                lbl_jzrq.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jzrq.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            id = Request.Params["id"].ToString();
            struct_ygll.p_id = Convert.ToInt32(id);
            struct_ygll.p_ygbh = lbl_bh.Text;
            // struct_ygll.p_scsj = DateTime.Now;
            struct_ygll.p_bmdm = "";
            struct_ygll.p_gzdw = tbx_gzdw.Text.ToString().Trim();//工作单位
            struct_ygll.p_gzbm = tbx_gzbm.Text.ToString().Trim();//工作部门
            struct_ygll.p_gzgw = tbx_gzgw.Text.ToString().Trim();//工作岗位
            struct_ygll.p_gzdd = tbx_gzdd.Text.ToString().Trim();//工作地点
            struct_ygll.p_qzrq = tbx_qzrq.Text.ToString().Trim();//起止日期
            struct_ygll.p_jzrq = tbx_jzrq.Text.ToString().Trim();//截止日期
            struct_ygll.p_bz = tbx_bz.Text;
            struct_ygll.p_lrr = _usState.userLoginName;//录入人
            struct_ygll.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ygll.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_ygll.p_czfs = "02";
            struct_ygll.p_czxx = "位置：员工管理->履历管理->编辑    员工编号：[" + struct_ygll.p_ygbh + "]  描述：";
            dt_detail = ygll.Select_YGLLGL_Detail(Convert.ToInt32(id));
           
           
           
            //工作单位
            if (struct_ygll.p_gzdw != dt_detail.Rows[0]["gzdw"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作单位：【" + dt_detail.Rows[0]["gzdw"].ToString() + "】->【" + struct_ygll.p_gzdw + "】";
                check_rz = 1;
            }
            //工作部门
            if (struct_ygll.p_gzbm != dt_detail.Rows[0]["gzbm"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作部门：【" + dt_detail.Rows[0]["gzbm"].ToString() + "】->【" + struct_ygll.p_gzbm + "】";
                check_rz = 1;
            }
            //工作岗位
            if (struct_ygll.p_gzgw != dt_detail.Rows[0]["gzgw"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作岗位：【" + dt_detail.Rows[0]["gzgw"].ToString() + "】->【" + struct_ygll.p_gzgw + "】";
                check_rz = 1;
            }

            //工作地点
            if (struct_ygll.p_gzdd != dt_detail.Rows[0]["gzdd"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "工作地点：【" + dt_detail.Rows[0]["gzdd"].ToString() + "】->【" + struct_ygll.p_gzdd + "】";
                check_rz = 1;
            }
            //起止日期
            if (struct_ygll.p_qzrq != dt_detail.Rows[0]["qzrq"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "起止日期：【" + dt_detail.Rows[0]["qzrq"].ToString() + "】->【" + struct_ygll.p_qzrq + "】";
                check_rz = 1;
            }
            //截止日期
            if (struct_ygll.p_jzrq != dt_detail.Rows[0]["jzrq"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "截止日期：【" + dt_detail.Rows[0]["jzrq"].ToString() + "】->【" + struct_ygll.p_jzrq + "】";
                check_rz = 1;
            }
            //备注
            if (struct_ygll.p_bz != dt_detail.Rows[0]["bz"].ToString())
            {
                //已修改
                struct_ygll.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_ygll.p_bz + "】";
                check_rz = 1;
            }

            if (check_rz == 0)
            {
                struct_ygll.p_czxx += "未修改";             
            }
            
            string sjbs = Request.Params["sjbs"].ToString();

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygll.p_lrr.Equals(struct_ygll.p_csr))
                {
                    struct_ygll.p_zt = "2";
                    struct_ygll.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_ygll.p_zsr, "11", "1103", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                {
                    struct_ygll.p_zt = "3";
                    struct_ygll.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygll.p_zsr, "11", "1103", Convert.ToInt32(id));
                }
                if (!struct_ygll.p_lrr.Equals(struct_ygll.p_csr) && !struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                {
                    struct_ygll.p_zt = "0";
                    struct_ygll.p_sjbs = "0";
                }
                ygll.Update_YGLL(struct_ygll);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_ygll.p_lrr.Equals(struct_ygll.p_csr))
                {
                    struct_ygll.p_zt = "2";
                    struct_ygll.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygll.p_zsr, "11", "1103", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygll.p_sjc = sjc;
                    ygll.Update_YGLL_SJBS_LSSJ_ZT(struct_ygll);

                    struct_ygll.p_zt = "3";
                    struct_ygll.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygll.p_zsr, "11", "1103", Convert.ToInt32(id));
                }
                if (!struct_ygll.p_lrr.Equals(struct_ygll.p_csr) && !struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                {
                    struct_ygll.p_zt = "0";
                    struct_ygll.p_sjbs = "2";
                }
                ygll.Update_YGLL(struct_ygll);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Request.Params["id"].ToString();
                int id_bf = ygll.YGLL_SJBF(Convert.ToInt32(id));
                struct_ygll.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_ygll.p_lrr.Equals(struct_ygll.p_csr))
                {
                    struct_ygll.p_zt = "2";
                    struct_ygll.p_sjbs = "2";
                    SysData.Insert_TSR(struct_ygll.p_zsr, "11", "1103", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_ygll.p_sjc = sjc;
                    ygll.Update_YGLL_SJBS_LSSJ_ZT(struct_ygll);

                    struct_ygll.p_zt = "3";
                    struct_ygll.p_sjbs = "1";
                    SysData.Delete_TSR(struct_ygll.p_zsr, "11", "1103", Convert.ToInt32(id));
                }
                if (!struct_ygll.p_lrr.Equals(struct_ygll.p_csr) && !struct_ygll.p_lrr.Equals(struct_ygll.p_zsr))
                {
                    struct_ygll.p_zt = "0";
                    struct_ygll.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                ygll.Update_YGLL(struct_ygll);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);
            }





            //if (sjbs.Equals("0") || sjbs.Equals("2"))
            //{
            //    ygll.Update_YGLL(struct_ygll);
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            //    Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);
                
            //}
            //else if (sjbs.Equals("1") || sjbs.Equals("3"))
            //{
            //    //生成该数据的副本,并返回新的备份id
            //    id = Request.Params["id"].ToString();
            //    int id_bf = ygll.YGLL_SJBF(Convert.ToInt32(id));
            //    struct_ygll.p_id = id_bf;
            //    ygll.Update_YGLL(struct_ygll);
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            //    Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);
               
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
            //Response.Redirect("LL_Edit.aspx");
            Server.Transfer("LL_Edit.aspx?ygbh=" + lbl_bh.Text);
        }




    }
}