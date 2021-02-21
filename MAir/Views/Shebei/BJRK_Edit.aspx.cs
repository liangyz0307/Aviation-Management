using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CUST.WKG
{
    public partial class BJRK_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private BJ bj;
        private string id;
        private Struct_BJRK struct_bjrk;
        private string sjc;
        private BMGW bmgw;
        private DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            
            bj = new BJ(_usState);
             id = Request.Params["id"].ToString();
            bmgw = new BMGW(_usState);
            if (!IsPostBack)
            {
               
                bind_drop();
                bind_select();
              
                tbx_rksj.Attributes.Add("readonly", "readonly");
            }
        }
        private void bind_drop()
        {

           // string id = Request.Params["id"].ToString();
            dt = bj.Select_BJRKbyID(id).Tables[0];

            //经办人
            ddlt_jbrbm.DataTextField = "mc";
            ddlt_jbrbm.DataValueField = "bm";
            ddlt_jbrbm.DataSource = SysData.BM().Copy();
            ddlt_jbrbm.DataBind();
            ddlt_jbrbm.Items.Insert(0, new ListItem("请选择", "-1"));

            ddlt_jbrgw.DataTextField = "mc";
            ddlt_jbrgw.DataValueField = "bm";
            ddlt_jbrgw.DataSource = SysData.GW().Copy();
            ddlt_jbrgw.DataBind();
            ddlt_jbrgw.Items.Insert(0, new ListItem("请选择", "-1"));

            string gw_jbr = dt.Rows[0]["jbrgw"].ToString();
            DataTable dt_jbr = new DataTable();
            dt_jbr = bmgw.Select_YGALL(gw_jbr).Tables[0];
            ddlt_jbr.DataSource = dt_jbr;
            ddlt_jbr.DataTextField = "xm";
            ddlt_jbr.DataValueField = "bh";
            ddlt_jbr.DataBind();
            ddlt_jbr.Items.Insert(0, new ListItem("请选择", "-1"));
        

            //负责人
            ddlt_fzrbm.DataTextField = "mc";
            ddlt_fzrbm.DataValueField = "bm";
            ddlt_fzrbm.DataSource = SysData.BM().Copy();
            ddlt_fzrbm.DataBind();
            ddlt_fzrbm.Items.Insert(0, new ListItem("请选择", "-1"));
          

            ddlt_fzrgw.DataTextField = "mc";
            ddlt_fzrgw.DataValueField = "bm";
            ddlt_fzrgw.DataSource = SysData.GW().Copy();
            ddlt_fzrgw.DataBind();
            ddlt_fzrgw.Items.Insert(0, new ListItem("请选择", "-1"));


            string gw = dt.Rows[0]["fzrgw"].ToString();
            DataTable dt_fzrgw = new DataTable();
            dt_fzrgw = bmgw.Select_YGALL(gw).Tables[0];
            ddlt_fzr.DataSource = dt_fzrgw;
            ddlt_fzr.DataTextField = "xm";
            ddlt_fzr.DataValueField = "bh";
            ddlt_fzr.DataBind();
            ddlt_fzr.Items.Insert(0, new ListItem("请选择", "-1"));
        

            //ddlt_bjfl.DataTextField = "mc";
            //ddlt_bjfl.DataValueField = "bm";
            //ddlt_bjfl.DataSource = SysData.BJLX().Copy();
            //ddlt_bjfl.DataBind();
            //ddlt_bjfl.Items.Insert(0, new ListItem("请选择", "-1"));
         

            //ddlt_bjsy.DataTextField = "mc";
            //ddlt_bjsy.DataValueField = "bm";
            //ddlt_bjsy.DataSource = SysData.BJSY().Copy();
            //ddlt_bjsy.DataBind();
            //ddlt_bjsy.Items.Insert(0, new ListItem("请选择", "-1"));
            ///
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140703");

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
            ddlt_sjszbm.DataSource = SysData.BM("140703", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));

        }
        private void bind_select()
        {
           
            lbl_bjbh.Text= dt.Rows[0]["bh"].ToString();
            lbl_bjmc.Text = dt.Rows[0]["bjmc"].ToString();
            tbx_bz.Text= dt.Rows[0]["bz"].ToString();
            tbx_cfwz.Text= dt.Rows[0]["cfwz"].ToString();
            DateTime dt_rksj = new DateTime();
            dt_rksj = Convert.ToDateTime(dt.Rows[0]["rksj"].ToString());
            tbx_rksj.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt_rksj);
            //tbx_rksj.Text= dt.Rows[0]["rksj"].ToString();
            tbx_rksl.Text= dt.Rows[0]["rksl"].ToString();

            ddlt_fzr.SelectedValue = dt.Rows[0]["kffzr"].ToString();

            ddlt_fzrbm.SelectedValue=dt.Rows[0]["fzrbm"].ToString();
            ddlt_fzrgw.SelectedValue=dt.Rows[0]["fzrgw"].ToString();

            ddlt_jbr.SelectedValue = dt.Rows[0]["rkjbr"].ToString();

            ddlt_jbrbm.SelectedValue= dt.Rows[0]["jbrbm"].ToString();
            ddlt_jbrgw.SelectedValue= dt.Rows[0]["jbrgw"].ToString();
            //ddlt_bjfl.SelectedValue =dt.Rows[0]["bjfl"].ToString();
            //ddlt_bjsy.SelectedValue=dt.Rows[0]["sy"].ToString();
            ddlt_csr.SelectedValue = dt.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt.Rows[0]["bmdm"].ToString();//数据所在部门

        }
      

      
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBBJ_RK.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag=0;
              //存放位置
            if (tbx_cfwz.Text == "")
            {
                lbl_cfwz.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {


                lbl_cfwz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                
            }
            //时间
            if (tbx_rksj.Text == "")
            {
                lbl_rksj.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {


                lbl_rksj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //入库数量
            if (tbx_rksl.Text == "")
            {
                lbl_rksl.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else if (!Regex.IsMatch(tbx_rksl.Text, @"^[0-9]*$"))
            {
                lbl_rksl.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {


                lbl_rksl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人
            if (ddlt_jbrbm.SelectedValue.Trim() == "-1")
            {

                lbl_jbrbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jbrbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人岗位
            if (ddlt_jbrgw.SelectedValue.Trim() == "-1")
            {

                lbl_jbrgw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jbrgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人
            if (ddlt_jbr.SelectedValue.Trim() == "-1")
            {

                lbl_jbr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_jbr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //负责人部门
            if (ddlt_fzrbm.SelectedValue.Trim() == "-1")
            {

                lbl_fzrbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzrbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人岗位
            if (ddlt_fzrgw.SelectedValue.Trim() == "-1")
            {

                lbl_fzrgw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzrgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //经办人
            if (ddlt_fzr.SelectedValue.Trim() == "-1")
            {

                lbl_fzr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fzr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            if (flag == 1) { return; }
            #endregion


            try
            { 
            struct_bjrk.p_bjbh = lbl_bjbh.Text.ToString();
            struct_bjrk.p_cfwz = tbx_cfwz.Text.ToString();
            struct_bjrk.p_rkjbr = ddlt_jbr.SelectedValue.ToString();
            struct_bjrk.p_rksj =Convert.ToDateTime(tbx_rksj.Text.ToString());     
            struct_bjrk.p_rksl = Convert.ToInt32(tbx_rksl.Text);
            struct_bjrk.p_bz = tbx_bz.Text.ToString();
            struct_bjrk.p_jbrbm = ddlt_jbrbm.SelectedValue.ToString();
            struct_bjrk.p_jbrgw = ddlt_jbrgw.SelectedValue.ToString();
            struct_bjrk.p_kffzr =ddlt_fzr.SelectedValue.ToString();
            struct_bjrk.p_fzrbm = ddlt_fzrbm.SelectedValue.ToString();
            struct_bjrk.p_fzrgw = ddlt_fzrgw.SelectedValue.ToString();
            //struct_bjrk.p_bjfl = ddlt_bjfl.SelectedValue.ToString();
            //struct_bjrk.p_sy = ddlt_bjsy.SelectedValue.ToString();
            struct_bjrk.p_zxdm = _usState.userSS;
            if (tbx_bz.Text.ToString() == "")
            {
                struct_bjrk.p_bz = "";
            }
            else
            {
                struct_bjrk.p_bz = tbx_bz.Text.ToString();
            }
            struct_bjrk.p_fzrxm = ddlt_jbr.SelectedItem.Text;
            struct_bjrk.p_jbrxm = ddlt_fzr.SelectedItem.Text;
            struct_bjrk.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_bjrk.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_bjrk.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门
            struct_bjrk.p_lrr = _usState.userLoginName.ToString();//录入人

            struct_bjrk.p_id = id;
            DataTable dt = bj.Select_BJRKbyID(id).Tables[0];
            DataRow dt_row = dt.Rows[0];
            string czxx = "位置：设备管理->备件入库->编辑  备件编号：" + struct_bjrk.p_bjbh +"备件名称" + lbl_bjmc.Text;
            struct_bjrk.p_czxx = czxx;
            struct_bjrk.p_czfs = "03";
            int check = 0;
            //#region
            //if (struct_bjrk.p_bjfl != dt_row["bjfl"].ToString())
            //{
            //    //已修改
            //    czxx += "备件分类：【" + SysData.BJLXByKey(dt_row["bjfl"].ToString()).mc + "】->【" + SysData.BJLXByKey(struct_bjrk.p_bjfl).mc + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_bz != dt_row["bz"].ToString())
            //{
            //    //已修改
            //    czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_bjrk.p_bz + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_cfwz != dt_row["cfwz"].ToString())
            //{
            //    //已修改
            //    czxx += "存放位置：【" + dt_row["cfwz"].ToString() + "】->【" + struct_bjrk.p_cfwz + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_rkjbr != dt_row["rkjbr"].ToString())
            //{
            //    //已修改
            //    czxx += "经办人：【" + dt_row["rkjbr"].ToString() + "】->【" + struct_bjrk.p_rkjbr + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_rksj != Convert.ToDateTime(dt_row["rksj"].ToString()))
            //{
            //    //已修改
            //    czxx += "入库时间：【" + dt_row["rksj"].ToString() + "】->【" + struct_bjrk.p_rksj + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_rksl !=Convert.ToInt16( dt_row["rksl"].ToString()))
            //{
            //    //已修改
            //    czxx += "入库数量：【" + dt_row["rksl"].ToString() + "】->【" + struct_bjrk.p_rksl + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_fzrbm!= dt_row["fzrbm"].ToString())
            //{
            //    //已修改
            //    czxx += "负责人部门：【" +SysData.BMByKey( dt_row["fzrbm"].ToString() ).mc+ "】->【" + SysData.BMByKey(struct_bjrk.p_fzrbm ).mc+ "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_fzrgw != dt_row["fzrgw"].ToString())
            //{
            //    //已修改
            //    czxx += "负责人岗位：【" +SysData.GWByKey( dt_row["fzrgw"].ToString()).mc + "】->【" +SysData.GWByKey( struct_bjrk.p_fzrgw).mc + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_jbrbm != dt_row["jbrbm"].ToString())
            //{
            //    //已修改
            //    czxx += "经办人部门：【" + SysData.BMByKey(dt_row["jbrbm"].ToString()).mc + "】->【" + SysData.BMByKey(struct_bjrk.p_jbrbm).mc + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_jbrgw != dt_row["jbrgw"].ToString())
            //{
            //    //已修改
            //    czxx += "经办人岗位：【" + SysData.GWByKey(dt_row["jbrgw"].ToString()).mc + "】->【" + SysData.GWByKey(struct_bjrk.p_jbrgw).mc + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_kffzr != dt_row["kffzr"].ToString())
            //{
            //    //已修改
            //    czxx += "负责人：【" + dt_row["kffzr"].ToString() + "】->【" + struct_bjrk.p_kffzr + "】";
            //    check = 1;
            //}
            //if (struct_bjrk.p_sy != dt_row["sy"].ToString())
            //{
            //    //已修改
            //    czxx += "备件适用：【" + dt_row["sy"].ToString() + "】->【" + struct_bjrk.p_sy + "】";
            //    check = 1;
            //}

            //#endregion
           
                struct_bjrk.p_czfs = "02";
                struct_bjrk.p_czxx =czxx;
                string sjbs = Request.Params["sjbs"].ToString();
                   //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_bjrk.p_lrr.Equals(struct_bjrk.p_csr)) {
                    struct_bjrk.p_zt = "2";
                    struct_bjrk.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_bjrk.p_zsr, "14", "1407", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_bjrk.p_lrr.Equals(struct_bjrk.p_zsr)) {
                    struct_bjrk.p_zt = "3";
                    struct_bjrk.p_sjbs = "1";
                   SysData.Delete_TSR(struct_bjrk.p_zsr, "14", "1407", Convert.ToInt32(id));
                }
                if (!struct_bjrk.p_lrr.Equals(struct_bjrk.p_csr) && !struct_bjrk.p_lrr.Equals(struct_bjrk.p_zsr))
                {
                    struct_bjrk.p_zt = "0";
                    struct_bjrk.p_sjbs = "0";

                }
                bj.Update_BJRK(struct_bjrk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
              //  Server.Transfer("JLGL.aspx?ygbh=" + _usState.userLoginName);
            }
            //如果是副本数据
            else if (sjbs.Equals("2")) {
                //初审人录入的数据，状态默认为待终审
                if (struct_bjrk.p_lrr.Equals(struct_bjrk.p_csr))
                {
                    struct_bjrk.p_zt = "2";
                    struct_bjrk.p_sjbs = "2";
                    SysData.Insert_TSR(struct_bjrk.p_zsr, "14", "1407", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_bjrk.p_lrr.Equals(struct_bjrk.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_bjrk.p_sjc = sjc;
                    bj.Update_BJRK_SJBS_LSSJ_ZT(struct_bjrk);

                    struct_bjrk.p_zt = "3";
                    struct_bjrk.p_sjbs = "1";
                    SysData.Delete_TSR(struct_bjrk.p_zsr, "14", "1407", Convert.ToInt32(id));
                }
                if (!struct_bjrk.p_lrr.Equals(struct_bjrk.p_csr) && !struct_bjrk.p_lrr.Equals(struct_bjrk.p_zsr))
                {
                    struct_bjrk.p_zt = "0";
                    struct_bjrk.p_sjbs = "2";
                }
                bj.Update_BJRK(struct_bjrk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
               // Server.Transfer("JLGL.aspx?ygbh=" + _usState.userLoginName);
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
               // id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = bj.BJRK_SJBF(Convert.ToInt32(id));
                struct_bjrk.p_id = Convert.ToString(id_bf);


                //初审人录入的数据，状态默认为待终审
                if (struct_bjrk.p_lrr.Equals(struct_bjrk.p_csr))
                {
                    struct_bjrk.p_zt = "2";
                    struct_bjrk.p_sjbs = "2";
                    SysData.Insert_TSR(struct_bjrk.p_zsr, "14", "1407", Convert.ToInt32(id));
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_bjrk.p_lrr.Equals(struct_bjrk.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_bjrk.p_sjc = sjc;
                    bj.Update_BJRK_SJBS_LSSJ_ZT(struct_bjrk);

                    struct_bjrk.p_zt = "3";
                    struct_bjrk.p_sjbs = "1";
                    SysData.Delete_TSR(struct_bjrk.p_zsr, "14", "1407", Convert.ToInt32(id));
                }
                if (!struct_bjrk.p_lrr.Equals(struct_bjrk.p_csr) && !struct_bjrk.p_lrr.Equals(struct_bjrk.p_zsr))
                {
                    struct_bjrk.p_zt = "0";
                    struct_bjrk.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                bj.Update_BJRK(struct_bjrk);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                //bj.Update_BJRK(struct_bjrk);
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

         }

        protected void ddlt_jbrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_jbrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_jbrgw.DataSource = dt;
                ddlt_jbrgw.DataBind();
                ddlt_jbrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_jbrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_jbrgw.DataTextField = "mc";
                ddlt_jbrgw.DataValueField = "bm";
                ddlt_jbrgw.DataBind();
                ddlt_jbrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void ddlt_fzrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_fzrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_fzrgw.DataSource = dt;
                ddlt_fzrgw.DataBind();
                ddlt_fzrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_fzrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_fzrgw.DataTextField = "mc";
                ddlt_fzrgw.DataValueField = "bm";
                ddlt_fzrgw.DataBind();
                ddlt_fzrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void ddlt_jbrgw_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gw = ddlt_jbrgw.SelectedValue;
            if (gw == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_jbr.DataSource = dt;
                ddlt_jbr.DataBind();
                ddlt_jbr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                DataTable dt = new DataTable();
                dt = bmgw.Select_YGALL(gw).Tables[0];
                ddlt_jbr.DataSource =dt;
                ddlt_jbr.DataTextField = "xm";
                ddlt_jbr.DataValueField = "bh";
                ddlt_jbr.DataBind();
                ddlt_jbr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void ddlt_fzrgw_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gw = ddlt_fzrgw.SelectedValue;
            if (gw == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_fzr.DataSource = dt;
                ddlt_fzr.DataBind();
                ddlt_fzr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                DataTable dt = new DataTable();
                dt = bmgw.Select_YGALL(gw).Tables[0];
                ddlt_fzr.DataSource =dt;
                ddlt_fzr.DataTextField = "xm";
                ddlt_fzr.DataValueField = "bh";
                ddlt_fzr.DataBind();
                ddlt_fzr.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }
    }
}