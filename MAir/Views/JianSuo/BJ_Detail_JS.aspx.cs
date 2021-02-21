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

namespace CUST.WKG
{
    public partial class BJ_Detail_JS : System.Web.UI.Page
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
                select_detail(id);
                //lbl_bjbh.Text = bjbh;
                //btn_save.Visible = false;


            }

        }
        //private void show()
        //{
        //    tbx_bjmc.Enabled = false;
        //    tbx_bjsbh.Enabled = false;
        //    tbx_bjzwmc.Enabled = false;
        //    tbx_bz.Enabled = false;
        //    tbx_cfwz.Enabled = false;
        //    tbx_nhzj.Enabled = false;
        //    tbx_nhzjmc.Enabled = false;
        //    tbx_sbxh.Enabled = false;
        //    tbx_xybj.Enabled = false;
        //    tbx_yjsl.Enabled = false;
        //    tbx_ywmc.Enabled = false;
        //    ddlt_bjfl.Enabled = false;
        //    ddlt_sy.Enabled = false;


        //}
        //private void ddltBind()
        //{

        //    绑定设备类别
        //    ddlt_sy.DataTextField = "mc";
        //    ddlt_sy.DataValueField = "bm";
        //    ddlt_sy.DataSource = SysData.BJSY().Copy();
        //    ddlt_sy.DataBind();
        //    ddlt_sy.Items.Insert(0, new ListItem("请选择", "-1"));

        //    绑定设备类别
        //    ddlt_bjfl.DataTextField = "mc";
        //    ddlt_bjfl.DataValueField = "bm";
        //    ddlt_bjfl.DataSource = SysData.BJLX().Copy();
        //    ddlt_bjfl.DataBind();
        //    ddlt_bjfl.Items.Insert(0, new ListItem("请选择", "-1"));

        //}


        private void select_detail(int id)
        {
            DataTable dt_detail = bj.Select_BJbyBJBH(id).Tables[0];

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
                lbl_sy.Text = dt_detail.Rows[0]["symc"].ToString();
                lbl_xybj.Text = dt_detail.Rows[0]["xybjsl"].ToString();
                lbl_cfwz.Text = dt_detail.Rows[0]["cfwz"].ToString();
                lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();

                lbl_zt.Text = dt_detail.Rows[0]["ztmc"].ToString();
                lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();

                lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
                lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
                lbl_shjsbmmc.Text = dt_detail.Rows[0]["shjsbmmc"].ToString();

            }




        }


        //protected void btn_save_Click(object sender, EventArgs e)
        //{

        //    int flag = 0;

        //    string bjbh = lbl_bjh.Text.ToString();


        //    string sy = ddlt_sy.SelectedValue.ToString();
        //    string bjfl = ddlt_bjfl.SelectedValue.ToString();
        //    string bjmc = tbx_bjmc.Text.ToString();
        //    string sbxh = tbx_sbxh.Text.ToString();

        //    string bjzwmc = tbx_bjzwmc.Text.ToString();
        //    string nhzj = tbx_nhzj.Text.ToString();
        //    string nhzjmc = tbx_nhzjmc.Text.ToString();
        //    string ywmc = tbx_ywmc.Text.ToString();
        //    string yjsl = tbx_yjsl.Text.ToString();
        //    string bjsbh = tbx_bjsbh.Text.ToString();

        //    string xybj = tbx_xybj.Text.ToString();
        //    string cfwz = tbx_cfwz.Text.ToString();
        //    string bz = tbx_bz.Text.ToString();
        //    //判断 tbx是否为空
        //    #region label提示
        //    if (sy == "-1")
        //    {
        //        lbl_sy.Text = "<span style=\"color:#ff0000\">" + "错误：请选择备件适用情况" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_sy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }


        //    if (bjfl == "-1")
        //    {
        //        lbl_bjfl.Text = "<span style=\"color:#ff0000\">" + "错误：请选择备件分类" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_bjfl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }


        //    if (string.IsNullOrEmpty(bjmc))
        //    {
        //        lbl_bjmc.Text = "<span style=\"color:#ff0000\">" + "错误：备件名称不能为空" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_bjmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }


        //    if (string.IsNullOrEmpty(sbxh))
        //    {
        //        lbl_sbxh.Text = "<span style=\"color:#ff0000\">" + "错误：设备型号不能为空" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_sbxh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }

        //    if (string.IsNullOrEmpty(bjzwmc))
        //    {
        //        lbl_bjzwmc.Text = "<span style=\"color:#ff0000\">" + "错误：中文名称不能为空" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_bjzwmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }

        //    //if (string.IsNullOrEmpty(nhzj))
        //    //{
        //    //    lbl_nhzj.Text = "<span style=\"color:#ff0000\">" + "错误：内含组件不能为空！" + "</span>";
        //    //    flag = 1;
        //    //}
        //    //else  
        //    //{
        //    //    lbl_nhzj.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
        //    //}


        //    //if (string.IsNullOrEmpty(nhzjmc))
        //    //{
        //    //    lbl_nhzjmc.Text = "<span style=\"color:#ff0000\">" + "错误：不能为空！" + "</span>";
        //    //    flag = 1;
        //    //}
        //    //else
        //    //{
        //    //    lbl_nhzjmc.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";

        //    //}

        //    //if (string.IsNullOrEmpty(ywmc))
        //    //{

        //    //    lbl_ywmc.Text = "<span style=\"color:#ff0000\">" + "错误：英文名称不能为空！" + "</span>";
        //    //    flag = 1;
        //    //}
        //    //else
        //    //{
        //    //    lbl_ywmc.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
        //    //}

        //    //if (string.IsNullOrEmpty(yjsl))
        //    //{
        //    //    lbl_yjsl.Text = "<span style=\"color:#ff0000\">" + "错误：原机数量不能为空！" + "</span>";
        //    //    flag = 1;
        //    //}

        //    //else
        //    //{
        //    //    lbl_yjsl.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
        //    //}
        //    if (string.IsNullOrEmpty(bjsbh))
        //    {
        //        lbl_bjsbh.Text = "<span style=\"color:#ff0000\">" + "错误：板件识别号不能为空" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_bjsbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }

        //    if (string.IsNullOrEmpty(xybj))
        //    {
        //        lbl_xybj.Text = "<span style=\"color:#ff0000\">" + "错误：现有备件数量不能为空" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_xybj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }
        //    if (string.IsNullOrEmpty(cfwz))
        //    {
        //        lbl_cfwz.Text = "<span style=\"color:#ff0000\">" + "错误：存放位置不能为空" + "</span>";
        //        flag = 1;
        //    }
        //    else
        //    {
        //        lbl_cfwz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
        //    }
        //    //if (string.IsNullOrEmpty(bz))
        //    //{
        //    //    lbl_bz.Text = "<span style=\"color:#ff0000\">" + "错误：备注不能为空！" + "</span>";
        //    //    flag = 1;
        //    //}
        //    //else
        //    //{
        //    //    lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确！" + "</span>";
        //    //}
        //    if (flag == 1)
        //        return;

        //    #endregion

        //    try
        //    {
        //        //赋值
        //        struct_bj.p_bjbh = lbl_bjh.Text.ToString();
        //        struct_bj.p_bjmc = tbx_bjmc.Text.ToString();
        //        struct_bj.p_sbxh = tbx_sbxh.Text.ToString();
        //        struct_bj.p_bjfl = ddlt_bjfl.SelectedValue.ToString();
        //        struct_bj.p_bjzwmc = tbx_bjzwmc.Text.ToString();
        //        struct_bj.p_nhzj = tbx_nhzj.Text.ToString();
        //        struct_bj.p_nhzjmc = tbx_nhzjmc.Text.ToString();
        //        struct_bj.p_ywmc = tbx_ywmc.Text.ToString();
        //        struct_bj.p_yjsl = tbx_yjsl.Text.ToString();
        //        struct_bj.p_bjsbh = tbx_bjsbh.Text.ToString();
        //        struct_bj.p_sy = ddlt_sy.SelectedValue.ToString();
        //        struct_bj.p_xybjsl = tbx_xybj.Text.ToString();
        //        struct_bj.p_cfwz = tbx_cfwz.Text.ToString();
        //        struct_bj.p_bz = tbx_bz.Text.ToString();
        //        struct_bj.p_zxdm = _usState.userSS;



        //        //路径

        //        // struct_txsb.p_wxdsbfshzzj = toPath;
        //        struct_bj.p_czfs = "02";

        //        int check_rz = 0;

        //        string bj_detail = Request.Params["bjbh"].ToString();

        //        DataTable dt_detail = bj.Select_BJbyBJBH(lbl_bjh.Text.ToString()).Tables[0];
        //        DataRow dt_row = dt_detail.Rows[0];
        //        struct_bj.p_czxx = "位置：设备管理->备件管理->编辑  [备件编号：" + lbl_bjh + "      描述：";

        //        if (struct_bj.p_bjmc != dt_row["bjmc"].ToString())
        //        {
        //            struct_bj.p_czxx += "备件名称：【" + dt_row["bjmc"].ToString() + "】->【" + struct_bj.p_bjmc + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_sbxh != dt_row["sbxh"].ToString())
        //        {
        //            struct_bj.p_czxx += "备件型号：【" + dt_row["sbxh"].ToString() + "】->【" + struct_bj.p_sbxh + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_bjfl != dt_row["bjfl"].ToString())
        //        {
        //            struct_bj.p_czxx += "板件中文名称：【" + dt_row["bjfl"].ToString() + "】->【" + struct_bj.p_bjfl + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_nhzj != dt_row["nhzj"].ToString())
        //        {
        //            struct_bj.p_czxx += "内含组件：【" + dt_row["nhzj"].ToString() + "】->【" + struct_bj.p_nhzj + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_nhzjmc != dt_row["nhzjmc"].ToString())
        //        {
        //            struct_bj.p_czxx += "内含组件名称：【" + dt_row["nhzjmc"].ToString() + "】->【" + struct_bj.p_nhzjmc + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_ywmc != dt_row["ywmc"].ToString())
        //        {
        //            struct_bj.p_czxx += "英文名称：【" + dt_row["ywmc"].ToString() + "】->【" + struct_bj.p_ywmc + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_yjsl != dt_row["yjsl"].ToString())
        //        {
        //            struct_bj.p_czxx += "原机数量：【" + dt_row["yjsl"].ToString() + "】->【" + struct_bj.p_yjsl + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_bjsbh != dt_row["bjsbh"].ToString())
        //        {
        //            struct_bj.p_czxx += "板件识别号：【" + dt_row["bjsbh"].ToString() + "】->【" + struct_bj.p_bjsbh + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_sy != dt_row["sy"].ToString())
        //        {
        //            struct_bj.p_czxx += "适用：【" + dt_row["sy"].ToString() + "】->【" + struct_bj.p_sy + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_xybjsl != dt_row["XYBJSL"].ToString())
        //        {
        //            struct_bj.p_czxx += "现有备件数量：【" + dt_row["XYBJSL"].ToString() + "】->【" + struct_bj.p_xybjsl + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_cfwz != dt_row["CFWZ"].ToString())
        //        {
        //            struct_bj.p_czxx += "存放位置：【" + dt_row["CFWZ"].ToString() + "】->【" + struct_bj.p_xybjsl + "】";
        //            check_rz = 1;
        //        }
        //        if (struct_bj.p_bz != dt_row["bz"].ToString())
        //        {
        //            struct_bj.p_czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_bj.p_bz + "】";
        //            check_rz = 1;
        //        }

        //        bj.Update_BJ(struct_bj);

        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
        //        btn_save.Visible = false;
        //    }
        //    catch (EMException ex)
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));

        //        return;
        //    }

        //}

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JianSuo/JS_SBGL.aspx");
        }

        //protected void btn_edit_Click(object sender, EventArgs e)
        //{
        //    tbx_bjmc.Enabled = true;
        //    tbx_bjsbh.Enabled = true;
        //    tbx_bjzwmc.Enabled = true;
        //    tbx_bz.Enabled = true;
        //    tbx_cfwz.Enabled = true;
        //    tbx_nhzj.Enabled = true;
        //    tbx_nhzjmc.Enabled = true;
        //    tbx_sbxh.Enabled = true;
        //    tbx_xybj.Enabled = true;
        //    tbx_yjsl.Enabled = true;
        //    tbx_ywmc.Enabled = true;
        //    ddlt_bjfl.Enabled = true;
        //    ddlt_sy.Enabled = true;
        //    btn_save.Visible = true;
        //}
    }
}