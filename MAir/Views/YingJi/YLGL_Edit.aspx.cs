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
using Sys;
using System.Collections;

namespace CUST.WKG
{
    public partial class YLGL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private YLGL ylgl;
        private Struct_YLGL struct_ylgl;
        private string sjc;
        private int ylbh;
        private int bh;
        private static DataTable dt_detail;
        private static string syrbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ylgl = new YLGL(_usState);
            struct_ylgl = new Struct_YLGL();
            ylbh = Convert.ToInt32( Request.Params["bh"]);
            bh = Convert.ToInt32(Request.Params["bh"]);
            if (!IsPostBack)
            {
                //bind_enable();
                ddltBind();
                tbx_ylsj.Attributes.Add("readonly", "readonly");
                select_detail(ylbh);
                dt_detail = ylgl.Select_Ylgl_Detail(ylbh);
                syrbh = dt_detail.Rows[0]["cyry"].ToString();
            }
        }

        private void ddltBind()
        {
            //绑定支线名称
            ddlt_zxmc.DataTextField = "mc";
            ddlt_zxmc.DataValueField = "bm";
            ddlt_zxmc.DataSource = SysData.ZXDM().Copy();
            ddlt_zxmc.DataBind();
            ddlt_zxmc.Items.Insert(0, new ListItem("全部", "-1"));

            //绑定预案名
            ddlt_yam.DataSource = ylgl.Select_Ylgl_Yam_Mc().Copy();
            ddlt_yam.DataTextField = "mc";
            ddlt_yam.DataValueField = "sjc";
            ddlt_yam.DataBind();
            ddlt_yam.Items.Insert(0, new ListItem("全部", "-1"));

            //所属演练形式
            ddlt_ylxs.DataTextField = "mc";
            ddlt_ylxs.DataValueField = "bm";
            ddlt_ylxs.DataSource = SysData.YLXS().Copy();
            ddlt_ylxs.DataBind();
            ddlt_ylxs.Items.Insert(0, new ListItem("全部", "-1"));

            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ylgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
            ////初始化审批人
            //DataTable dt_spr = SysData.HasThisZXT_SPR("11");
            ////初审人
            //ddlt_csr.DataSource = dt_spr;
            //ddlt_csr.DataTextField = "mc";
            //ddlt_csr.DataValueField = "bm";
            //ddlt_csr.DataBind();

            ////终审人
            //ddlt_zsr.DataSource = dt_spr;
            //ddlt_zsr.DataTextField = "mc";
            //ddlt_zsr.DataValueField = "bm";
            //ddlt_zsr.DataBind();

            ////数据所在部门
            //ddlt_sjszbm.DataSource = SysData.BM().Copy();
            //ddlt_sjszbm.DataTextField = "mc";
            //ddlt_sjszbm.DataValueField = "bm";
            //ddlt_sjszbm.DataBind();
            //ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("18", _usState.userID, "180203");

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


            //数据所在部门
            DataTable dt_bmdm = SysData.BM("180203", _usState.userID).Copy();
            ddlt_sjszbm.DataSource = dt_bmdm;
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string ylxs = ddlt_ylxs.SelectedValue.Trim().ToString();
            string zxmc = ddlt_zxmc.SelectedValue.Trim().ToString();
           // string yam = ddlt_yam.SelectedValue.Trim().ToString();
            string cyry = tbx_syr.Text.ToString().Trim();
            string ylsj = tbx_ylsj.Text.ToString().Trim();
            string ylnr = tbx_ylnr.Text.ToString().Trim();
            string ylzj = tbx_ylzj.Text.ToString().Trim();
           // string yanr = tbx_yanr.Text.ToString().Trim();
            #region lable判断


            if (string.IsNullOrEmpty(cyry))
            {
                lbl_syr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_syr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (ddlt_zxmc.SelectedValue.Trim() == "-1")
            {
                lbl_zxmc.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zxmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (ddlt_ylxs.SelectedValue.Trim() == "-1")
            {
                lbl_ylxs.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ylxs.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(ylsj))
            {
                lbl_ylsj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ylsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(ylnr))
            {
                lbl_ylnr.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ylnr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
          
            //数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            if (flag == 1)
            {
                return;
            }
            DataTable dt_detail = ylgl.Select_Ylgl_Detail(ylbh);
            struct_ylgl = new Struct_YLGL();
            struct_ylgl.p_bh = ylbh;
           //struct_ylgl.p_yam = ddlt_yam.SelectedValue.ToString().Trim();
            struct_ylgl.p_ylxs = ddlt_ylxs.SelectedValue.ToString().Trim();
            struct_ylgl.p_zxmc = ddlt_zxmc.SelectedValue.ToString().Trim();
            struct_ylgl.p_cyry = syrbh;
            struct_ylgl.p_ylsj = Convert.ToDateTime(tbx_ylsj.Text.ToString().Trim());
            struct_ylgl.p_ylnr = tbx_ylnr.Text.ToString().Trim();
            struct_ylgl.p_lrr = _usState.userLoginName.ToString();//录入人
            struct_ylgl.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_ylgl.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_ylgl.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_ylgl.p_ylzj = tbx_ylzj.Text.ToString().Trim();
            struct_ylgl.p_bhyy = "";//驳回原因
            struct_ylgl.p_czfs = "02";
            try
            {
                int check_rz = 0;

                DataRow dt_row = dt_detail.Rows[0];
                struct_ylgl.p_czxx = "位置:航务应急系统->演练管理->编辑  [演练编号：" + struct_ylgl.p_bh + "      描述：";
                if (struct_ylgl.p_yam != dt_row["yam"].ToString())
                {
                    struct_ylgl.p_czxx += "预案名：【" + dt_row["yam"].ToString()+ "】->【" + struct_ylgl.p_yam+ "】";
                    check_rz = 1;
                }
                if (struct_ylgl.p_ylxs != dt_row["ylxs"].ToString())
                {
                    struct_ylgl.p_czxx += "演练形式：【" +dt_row["ylxs"].ToString() + "】->【" +struct_ylgl.p_ylxs + "】";
                    check_rz = 1;
                }
                if (struct_ylgl.p_zxmc != dt_row["dq"].ToString())
                {
                    struct_ylgl.p_czxx += "支线名称：【" + dt_row["dq"].ToString() + "】->【" + struct_ylgl.p_zxmc + "】";
                    check_rz = 1;
                }

                if (struct_ylgl.p_ylsj != Convert.ToDateTime(dt_row["ylsj"]))
                {
                    struct_ylgl.p_czxx += "演练时间：【" + dt_row["ylsj"].ToString() + "】->【" + struct_ylgl.p_ylsj + "】";
                    check_rz = 1;
                }

                if (struct_ylgl.p_cyry != dt_row["cyry"].ToString())
                {
                    struct_ylgl.p_czxx += "参与人员：【" + dt_row["cyry"].ToString() + "】->【" + struct_ylgl.p_cyry + "】";
                    check_rz = 1;
                }
                if (struct_ylgl.p_ylnr != dt_row["ylnr"].ToString())
                {
                    struct_ylgl.p_czxx += "演练内容：【" + dt_row["ylnr"].ToString() + "】->【" + struct_ylgl.p_ylnr + "】";
                    check_rz = 1;
                }
                if (struct_ylgl.p_ylzj != dt_row["ylzj"].ToString())
                {
                    struct_ylgl.p_czxx += "演练总结：【" + dt_row["ylzj"].ToString() + "】->【" + struct_ylgl.p_ylzj + "】";
                    check_rz = 1;
                }
                if (struct_ylgl.p_yanr != dt_row["yanr"].ToString())
                {
                    struct_ylgl.p_czxx += "预案内容：【" + dt_row["yanr"].ToString() + "】->【" + struct_ylgl.p_yanr+ "】";
                    check_rz = 1;
                }
                if (check_rz == 0)
                {
                    Response.Write("<script>window.location.href='YLGL_GL.aspx';</script>");
                }
                string sjbs = Request.Params["sjbs"].ToString();

                //如果是原始数据
                if (sjbs.Equals("0"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr))
                    {
                        struct_ylgl.p_zt = "2";
                        struct_ylgl.p_sjbs = "0";
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
                    {
                        struct_ylgl.p_zt = "3";
                        struct_ylgl.p_sjbs = "1";
                    }
                    if (!struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr) && !struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
                    {
                        struct_ylgl.p_zt = "0";
                        struct_ylgl.p_sjbs = "0";
                    }
                    ylgl.Update_Yj_Ylgl(struct_ylgl);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Response.Redirect("../YingJi/YLGL_GL.aspx");
                }
                //如果是副本数据
                else if (sjbs.Equals("2"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr))
                    {
                        struct_ylgl.p_zt = "2";
                        struct_ylgl.p_sjbs = "2";
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_ylgl.p_sjc = sjc;
                        ylgl.Update_YLGL_SJBS_LSSJ_ZT(struct_ylgl);

                        struct_ylgl.p_zt = "3";
                        struct_ylgl.p_sjbs = "1";
                    }
                    if (!struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr) && !struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
                    {
                        struct_ylgl.p_zt = "0";
                        struct_ylgl.p_sjbs = "2";
                    }
                    ylgl.Update_Yj_Ylgl(struct_ylgl);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Response.Redirect("../YingJi/YLGL_GL.aspx");
                }
                else if (sjbs.Equals("1"))
                {
                    //生成该数据的副本,并返回新的备份id
                    bh = Convert.ToInt32(Request.Params["bh"].ToString());
                    int id_bf = ylgl.YLGL_SJBF(Convert.ToInt32(bh));
                    struct_ylgl.p_bh = id_bf;


                    //初审人录入的数据，状态默认为待终审
                    if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr))
                    {
                        struct_ylgl.p_zt = "2";
                        struct_ylgl.p_sjbs = "2";
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_ylgl.p_sjc = sjc;
                        ylgl.Update_YLGL_SJBS_LSSJ_ZT(struct_ylgl);

                        struct_ylgl.p_zt = "3";
                        struct_ylgl.p_sjbs = "1";
                    }
                    if (!struct_ylgl.p_lrr.Equals(struct_ylgl.p_csr) && !struct_ylgl.p_lrr.Equals(struct_ylgl.p_zsr))
                    {
                        struct_ylgl.p_zt = "0";
                        struct_ylgl.p_sjbs = "2";
                    }
                    //将新数据更新到副本数据里
                    ylgl.Update_Yj_Ylgl(struct_ylgl);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Response.Redirect("../YingJi/YLGL_GL.aspx");
                }
                else
                {
                    return;
                }

            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));


                return;
            }
        }
        #endregion
        //private void bind_syrall()
        //{
        //    string bmdm = ddlt_bmdm.SelectedValue.ToString();
        //    string gwdm = ddlt_gwdm.SelectedValue.ToString();
        //    DataTable dt = new DataTable();
        //    dt = ylgl.Select_YGbyBMGW(bmdm, gwdm);
        //    //绑定所有员工
        //    ddl.DataSource = dt.DefaultView;
        //    ddl.DataTextField = "xm";
        //    ddl.DataValueField = "bh";
        //    ddl.DataBind();
        //}
        //protected void btn_syr_Click(object sender, EventArgs e)
        //{
        //    string bmdm = ddlt_bmdm.SelectedValue.ToString();
        //    string gwdm = ddlt_gwdm.SelectedValue.ToString();
        //    string yg = ddlt_syr.SelectedValue.ToString();
        //    //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值

        //}

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            //ddlt_syr.SelectedItemText获取下拉框DataTextField值.
            if (ddlt_syr.Items.Count > 0)
            {
                tbx_syr.Text += ddlt_syr.SelectedItem.Text + ",";
                syrbh += ddlt_syr.SelectedValue.ToString() + ",";
            }
        }
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ylgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = ylgl.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void select_detail(int bh)
        {
            dt_detail = ylgl.Select_Ylgl_Detail(bh);
            dt_detail.Columns.Add("syrxm");
            string yh = dt_detail.Rows[0]["cyry"].ToString();
            yh = yh.Substring(0, yh.Length - 1);
            foreach (DataRow dr in dt_detail.Rows)
            {
                string[] Array_syr = yh.Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += ylgl.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
            }
            tbx_syr.Text = dt_detail.Rows[0]["syrxm"].ToString();
            tbx_ylsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["ylsj"]).ToString("yyyy-MM-dd");
            ddlt_zxmc.SelectedValue = dt_detail.Rows[0]["dq"].ToString();
            ddlt_ylxs.SelectedValue = dt_detail.Rows[0]["ylxs"].ToString();
            ddlt_yam.SelectedValue = dt_detail.Rows[0]["yam"].ToString();
            lbl_yam.Text = ddlt_yam.SelectedItem.Text;
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            tbx_ylnr.Text = dt_detail.Rows[0]["ylnr"].ToString();
            tbx_ylzj.Text = dt_detail.Rows[0]["ylzj"].ToString();
        }
        protected void bind_enable()
        {
            lbl_img.Visible = false;
            ddlt_yam.Enabled = false;
            ddlt_ylxs.Enabled = false;
            ddlt_zxmc.Enabled = false;
            tbx_syr.Enabled = false;
            tbx_ylnr.Enabled = false;
            
            tbx_ylsj.Enabled = false;
            tbx_ylzj.Enabled = false;
            btn_save.Visible = false;
            ChangeFlag.Value = "false";
        }
        //protected void btn_bj_Click(object sender, EventArgs e)
        //{
        //    btn_bj.Visible = false;
        //    lbl_img.Visible = true;
        //    ddlt_yam.Enabled = true;
        //    ddlt_ylxs.Enabled = true;
        //    ddlt_zxmc.Enabled = true;
        //    tbx_syr.Enabled = false;
        //    tbx_ylnr.Enabled = true;
           
        //    tbx_ylsj.Enabled = true;
        //    tbx_ylzj.Enabled = true;
        //    btn_save.Visible = true;
        //    ChangeFlag.Value = "true";
        //}
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../YingJi/YLGL_GL.aspx");
        }
        #region 错误信息
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
        #endregion

        protected void tbx_yanr_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tbx_ylsj_TextChanged(object sender, EventArgs e)
        {

        }
    }
}