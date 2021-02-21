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
    public partial class BJ_Edit : System.Web.UI.Page            
    {
        private UserState _usState;
        private BJ bj;
        private Struct_BJ struct_bj;
        private string bjbh;
        private int id;
        private string sjc;
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

                ddltBind();
              
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                select_detail(id);
                //lbl_bjbh.Text = bjbh;
              


            }

        }
  
        private void ddltBind()
        {

            //绑定设备类别
            ddlt_sy.DataTextField = "mc";
            ddlt_sy.DataValueField = "bm";
            ddlt_sy.DataSource = SysData.BJSY().Copy();
            ddlt_sy.DataBind();
            ddlt_sy.Items.Insert(0, new ListItem("请选择", "-1"));

            //绑定设备类别
            ddlt_bjfl.DataTextField = "mc";
            ddlt_bjfl.DataValueField = "bm";
            ddlt_bjfl.DataSource = SysData.BJLX().Copy();
            ddlt_bjfl.DataBind();
            ddlt_bjfl.Items.Insert(0, new ListItem("请选择", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140503");
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
            ddlt_sjszbm.DataSource = SysData.BM("140503", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }


        private void select_detail(int id)
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            DataTable dt_detail = bj.Select_BJbyBJBH(id).Tables[0];
            lbl_bjbh.Text = dt_detail.Rows[0]["bjbh"].ToString();
            tbx_bjmc.Text = dt_detail.Rows[0]["bjmc"].ToString();
            tbx_sbxh.Text = dt_detail.Rows[0]["sbxh"].ToString();
            ddlt_bjfl.SelectedValue = dt_detail.Rows[0]["bjfl"].ToString();
            tbx_bjzwmc.Text = dt_detail.Rows[0]["bjzwmc"].ToString();
            tbx_nhzj.Text = dt_detail.Rows[0]["nhzj"].ToString();
            tbx_nhzjmc.Text = dt_detail.Rows[0]["nhzjmc"].ToString();
            tbx_ywmc.Text = dt_detail.Rows[0]["ywmc"].ToString();
            tbx_yjsl.Text = dt_detail.Rows[0]["yjsl"].ToString();
            tbx_bjsbh.Text = dt_detail.Rows[0]["bjsbh"].ToString();
            ddlt_sy.SelectedValue = dt_detail.Rows[0]["sy"].ToString();
            tbx_xybj.Text = dt_detail.Rows[0]["xybjsl"].ToString();
            tbx_cfwz.Text = dt_detail.Rows[0]["cfwz"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();

            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门

        }


        protected void btn_save_Click(object sender, EventArgs e)
        {

            int flag = 0;

            string bjbh = lbl_bjbh.Text.ToString();


            string sy = ddlt_sy.SelectedValue.ToString();
            string bjfl = ddlt_bjfl.SelectedValue.ToString();
            string bjmc = tbx_bjmc.Text.ToString();
            string sbxh = tbx_sbxh.Text.ToString();

            string bjzwmc = tbx_bjzwmc.Text.ToString();
            string nhzj = tbx_nhzj.Text.ToString();
            string nhzjmc = tbx_nhzjmc.Text.ToString();
            string ywmc = tbx_ywmc.Text.ToString();
            string yjsl = tbx_yjsl.Text.ToString();
            string bjsbh = tbx_bjsbh.Text.ToString();

            string xybj = tbx_xybj.Text.ToString();
            string cfwz = tbx_cfwz.Text.ToString();
            string bz = tbx_bz.Text.ToString();
            //判断 tbx是否为空
            #region label提示
            if (sy == "-1")
            {
                lbl_sy.Text = "<span style=\"color:#ff0000\">" + "错误：请选择备件适用情况" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            if (bjfl == "-1")
            {
                lbl_bjfl.Text = "<span style=\"color:#ff0000\">" + "错误：请选择备件分类" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjfl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            if (string.IsNullOrEmpty(bjmc))
            {
                lbl_bjmc.Text = "<span style=\"color:#ff0000\">" + "错误：备件名称不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }


            if (string.IsNullOrEmpty(sbxh))
            {
                lbl_sbxh.Text = "<span style=\"color:#ff0000\">" + "错误：设备型号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(bjzwmc))
            {
                lbl_bjzwmc.Text = "<span style=\"color:#ff0000\">" + "错误：中文名称不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjzwmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            //if (string.IsNullOrEmpty(nhzj))
            //{
            //    lbl_nhzj.Text = "<span style=\"color:#ff0000\">" + "错误：内含组件不能为空！" + "</span>";
            //    flag = 1;
            //}
            //else  
            //{
            //    lbl_nhzj.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
            //}


            //if (string.IsNullOrEmpty(nhzjmc))
            //{
            //    lbl_nhzjmc.Text = "<span style=\"color:#ff0000\">" + "错误：不能为空！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_nhzjmc.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";

            //}

            if (string.IsNullOrEmpty(ywmc))
            {
                lbl_ywmc.Text = "<span style=\"color:#ff0000\">" + "错误：不可为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(ywmc, @"^[A-Za-z0-9]+$"))
            {
                lbl_ywmc.Text = "<span style=\"color:#ff0000\">" + "请输入英文！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ywmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

             if (!Regex.IsMatch(tbx_yjsl.Text, @"^[0-9]*$"))
             {
                 lbl_yjsl.Text = "<span style=\"color:#ff0000\">" + "错误：请输入数字！" + "</span>";
                 flag = 1;
             }
            if (string.IsNullOrEmpty(bjsbh))
            {
                lbl_bjsbh.Text = "<span style=\"color:#ff0000\">" + "错误：板件识别号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bjsbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(xybj))
            {
                lbl_xybj.Text = "<span style=\"color:#ff0000\">" + "错误：现有备件数量不能为空" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_xybj.Text, @"^[0-9]*$"))
            {
                lbl_xybj.Text = "span style=\"color:#ff0000\">" + "错误：请输入数字" + "</span>";
            }
            else
            {
                lbl_bjsbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(cfwz))
            {
                lbl_cfwz.Text = "<span style=\"color:#ff0000\">" + "错误：存放位置不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_cfwz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //数据所属部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            //初审人
            if (ddlt_csr.SelectedItem.Text.Trim() == "" || ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedItem.Text.Trim() == "" || ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //if (string.IsNullOrEmpty(bz))
            //{
            //    lbl_bz.Text = "<span style=\"color:#ff0000\">" + "错误：备注不能为空！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
            //}
            if (flag == 1)
                return;

            #endregion


                //赋值
                struct_bj.p_bjbh = lbl_bjbh.Text.ToString();
                struct_bj.p_bjmc = tbx_bjmc.Text.ToString();
                struct_bj.p_sbxh = tbx_sbxh.Text.ToString();
                struct_bj.p_bjfl = ddlt_bjfl.SelectedValue.ToString();
                struct_bj.p_bjzwmc = tbx_bjzwmc.Text.ToString();
                struct_bj.p_nhzj = tbx_nhzj.Text.ToString();
                struct_bj.p_nhzjmc = tbx_nhzjmc.Text.ToString();
                struct_bj.p_ywmc = tbx_ywmc.Text.ToString();
                struct_bj.p_yjsl = tbx_yjsl.Text.ToString();
                struct_bj.p_bjsbh = tbx_bjsbh.Text.ToString();
                struct_bj.p_sy = ddlt_sy.SelectedValue.ToString();
                struct_bj.p_xybjsl = tbx_xybj.Text.ToString();
                struct_bj.p_cfwz = tbx_cfwz.Text.ToString();
                struct_bj.p_bz = tbx_bz.Text.ToString();
                struct_bj.p_zxdm = _usState.userSS;

                struct_bj.p_lrr = _usState.userLoginName;//录入人
                struct_bj.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                struct_bj.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                struct_bj.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门


                //路径

                // struct_txsb.p_wxdsbfshzzj = toPath;
                struct_bj.p_czfs = "02";

                int check_rz = 0;

                string bj_detail = Request.Params["id"].ToString();
            id = Convert.ToInt32(Request.Params["id"].ToString());
            DataTable dt_detail = bj.Select_BJbyBJBH(id).Tables[0];
                DataRow dt_row = dt_detail.Rows[0];
                struct_bj.p_czxx = "位置：设备管理->备件管理->编辑  [备件编号：" + lbl_bjbh + "      描述：";

                if (struct_bj.p_bjmc != dt_row["bjmc"].ToString())
                {
                    struct_bj.p_czxx += "备件名称：【" + dt_row["bjmc"].ToString() + "】->【" + struct_bj.p_bjmc + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_sbxh != dt_row["sbxh"].ToString())
                {
                    struct_bj.p_czxx += "备件型号：【" + dt_row["sbxh"].ToString() + "】->【" + struct_bj.p_sbxh + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_bjfl != dt_row["bjfl"].ToString())
                {
                    struct_bj.p_czxx += "板件中文名称：【" + dt_row["bjfl"].ToString() + "】->【" + struct_bj.p_bjfl + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_nhzj != dt_row["nhzj"].ToString())
                {
                    struct_bj.p_czxx += "内含组件：【" + dt_row["nhzj"].ToString() + "】->【" + struct_bj.p_nhzj + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_nhzjmc != dt_row["nhzjmc"].ToString())
                {
                    struct_bj.p_czxx += "内含组件名称：【" + dt_row["nhzjmc"].ToString() + "】->【" + struct_bj.p_nhzjmc + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_ywmc != dt_row["ywmc"].ToString())
                {
                    struct_bj.p_czxx += "英文名称：【" + dt_row["ywmc"].ToString() + "】->【" + struct_bj.p_ywmc + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_yjsl != dt_row["yjsl"].ToString())
                {
                    struct_bj.p_czxx += "原机数量：【" + dt_row["yjsl"].ToString() + "】->【" + struct_bj.p_yjsl + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_bjsbh != dt_row["bjsbh"].ToString())
                {
                    struct_bj.p_czxx += "板件识别号：【" + dt_row["bjsbh"].ToString() + "】->【" + struct_bj.p_bjsbh + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_sy != dt_row["sy"].ToString())
                {
                    struct_bj.p_czxx += "适用：【" + dt_row["sy"].ToString() + "】->【" + struct_bj.p_sy + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_xybjsl != dt_row["XYBJSL"].ToString())
                {
                    struct_bj.p_czxx += "现有备件数量：【" + dt_row["XYBJSL"].ToString() + "】->【" + struct_bj.p_xybjsl + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_cfwz != dt_row["CFWZ"].ToString())
                {
                    struct_bj.p_czxx += "存放位置：【" + dt_row["CFWZ"].ToString() + "】->【" + struct_bj.p_xybjsl + "】";
                    check_rz = 1;
                }
                if (struct_bj.p_bz != dt_row["bz"].ToString())
                {
                    struct_bj.p_czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_bj.p_bz + "】";
                    check_rz = 1;
                }

            string sjbs = Request.Params["sjbs"].ToString();

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_bj.p_lrr.Equals(struct_bj.p_csr))
                {
                    struct_bj.p_zt = "2";
                    struct_bj.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_bj.p_zsr, "14", "1405", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    struct_bj.p_zt = "3";
                    struct_bj.p_sjbs = "1";
                    SysData.Delete_TSR(struct_bj.p_zsr, "14", "1405", id);
                }
                if (!struct_bj.p_lrr.Equals(struct_bj.p_csr) && !struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    struct_bj.p_zt = "0";
                    struct_bj.p_sjbs = "0";
                }
                bj.Update_BJ(struct_bj);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_bj.p_lrr.Equals(struct_bj.p_csr))
                {
                    struct_bj.p_zt = "2";
                    struct_bj.p_sjbs = "2";
                    SysData.Insert_TSR(struct_bj.p_zsr, "14", "1405", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_bj.p_sjc = sjc;
                    bj.Update_BJ_SJBS_LSSJ_ZT(struct_bj);

                    struct_bj.p_zt = "3";
                    struct_bj.p_sjbs = "1";
                    SysData.Delete_TSR(struct_bj.p_zsr, "14", "1405", id);
                }
                if (!struct_bj.p_lrr.Equals(struct_bj.p_csr) && !struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    struct_bj.p_zt = "0";
                    struct_bj.p_sjbs = "2";
                }
                bj.Update_BJ(struct_bj);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = bj.BJ_SJBF(Convert.ToInt32(id));
                struct_bj.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_bj.p_lrr.Equals(struct_bj.p_csr))
                {
                    struct_bj.p_zt = "2";
                    struct_bj.p_sjbs = "2";
                    SysData.Insert_TSR(struct_bj.p_zsr, "14", "1405", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_bj.p_sjc = sjc;
                    bj.Update_BJ_SJBS_LSSJ_ZT(struct_bj);

                    struct_bj.p_zt = "3";
                    struct_bj.p_sjbs = "1";
                    SysData.Delete_TSR(struct_bj.p_zsr, "14", "1405", id);
                }
                if (!struct_bj.p_lrr.Equals(struct_bj.p_csr) && !struct_bj.p_lrr.Equals(struct_bj.p_zsr))
                {
                    struct_bj.p_zt = "0";
                    struct_bj.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                bj.Update_BJ(struct_bj);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            else
            {
                return;
            }
        }



        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/BJ_GL.aspx");
        }

 
    }
}