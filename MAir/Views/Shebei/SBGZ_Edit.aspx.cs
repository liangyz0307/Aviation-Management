using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Brettle.Web.NeatUpload;
using System.IO;
using Sys;
using System.Text.RegularExpressions;

namespace CUST.WKG
{
    public partial class SBGZ_Edit : System.Web.UI.Page
    {
        private UserState _usState;

        private WHWX whwx;
        private Struct_SBGZ struct_sbgz;
        private int id;
        private string sjc;
        private string sb_lx;
        private string saveFileName;
        private string SaveFileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}

            whwx = new WHWX(_usState);
            struct_sbgz = new Struct_SBGZ();
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
                tbx_gzqssj.Attributes.Add("readonly", "readonly");
                tbx_gzjssj.Attributes.Add("readonly", "readonly");
                ddltBind();
                select_detail();
              
                bind_rep();
            }

        }
        private void select_detail()
        {
            id = Convert.ToInt32( Request.Params["id"].ToString());
          //  sb_lx = Request.Params["sblx"].ToString();
            DataTable dt_detail = whwx.Select_SBGZ_Detail(id);

            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            tbx_clbz.Text = dt_detail.Rows[0]["clbz"].ToString();
            tbx_czgc.Text = dt_detail.Rows[0]["czgc"].ToString();
            tbx_gzbjcljg.Text = dt_detail.Rows[0]["gzbjcljg"].ToString();
            tbx_gzjssj.Text = dt_detail.Rows[0]["gzjssj"].ToString();
            tbx_gzqssj.Text = dt_detail.Rows[0]["gzqssj"].ToString();
            tbx_gzxx.Text = dt_detail.Rows[0]["gzxx"].ToString();
            tbx_gzyyfx.Text = dt_detail.Rows[0]["gzyyfx"].ToString();
            tbx_jycs.Text = dt_detail.Rows[0]["jycs"].ToString();
            tbx_ljsc.Text = dt_detail.Rows[0]["ljsc"].ToString();
            tbx_sbbh.Text = dt_detail.Rows[0]["sbbh"].ToString();
            tbx_tlgzdpcff.Text = dt_detail.Rows[0]["tlgzpcff"].ToString();
           // tbx_sbbh.Text = dt_detail.Rows[0]["sbbh"].ToString();
            tbx_wxr.Text = dt_detail.Rows[0]["wxr"].ToString();
            tbx_zcyx.Text = dt_detail.Rows[0]["zcyx"].ToString();
            lbl_sblx.Text =SysData.SBLXByKey( dt_detail.Rows[0]["sblx"].ToString()).mc;
            ddlt_wxrbm.SelectedValue = dt_detail.Rows[0]["wxrbm"].ToString();
            ddlt_wxrgw.SelectedValue = dt_detail.Rows[0]["wxrgw"].ToString();
            ddlt_sbzl.SelectedValue = dt_detail.Rows[0]["sbzl"].ToString();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门




        }

       

        private void ddltBind()
        {
            //维护人部门
            ddlt_wxrbm.DataTextField = "mc";
            ddlt_wxrbm.DataValueField = "bm";
            ddlt_wxrbm.DataSource = SysData.BM().Copy();
            ddlt_wxrbm.DataBind();
            ddlt_wxrbm.Items.Insert(0, new ListItem("请选择", "-1"));

            //维护人岗位

            //DataTable dt_whrgw = new DataTable();
            //ddlt_wxrgw.DataSource = dt_whrgw;
            //ddlt_wxrgw.DataBind();
            //ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));


            ddlt_wxrgw.DataSource = SysData.GW().Copy();
            ddlt_wxrgw.DataTextField = "mc";
            ddlt_wxrgw.DataValueField = "bm";
            ddlt_wxrgw.DataBind();
            ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));

            //设备种类

            ddlt_sbzl.DataTextField = "mc";
            ddlt_sbzl.DataValueField = "bm";
            ddlt_sbzl.DataSource = SysData.SBZL().Copy();
            ddlt_sbzl.DataBind();
            ddlt_sbzl.Items.Insert(0, new ListItem("请选择", "-1"));
            ////设备类型

            //ddlt_sblx.DataTextField = "mc";
            //ddlt_sblx.DataValueField = "bm";
            //ddlt_sblx.DataSource = SysData.SBLX().Copy();
            //ddlt_sblx.DataBind();
            //ddlt_sblx.Items.Insert(0, new ListItem("请选择", "-1"));

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("14", _usState.userID, "140803");
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
            ddlt_sjszbm.DataSource = SysData.BM("140803", _usState.userID).Copy();
            ddlt_sjszbm.DataTextField = "bmmc";
            ddlt_sjszbm.DataValueField = "bmdm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("请选择", "-1"));


        }

        protected void ddlt_whrbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_wxrbm.SelectedValue;
            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_wxrgw.DataSource = dt;
                ddlt_wxrgw.DataBind();
                ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_wxrgw.DataSource = SysData.GW(bm).Copy();
                ddlt_wxrgw.DataTextField = "mc";
                ddlt_wxrgw.DataValueField = "bm";
                ddlt_wxrgw.DataBind();
                ddlt_wxrgw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.Params["id"].ToString());
            //  sb_lx = Request.Params["sblx"].ToString();
            DataTable dt_detail = whwx.Select_SBGZ_Detail(id);
            //   struct_sbgz.p_wxwjsc=wx  路径

            struct_sbgz.p_wxwjsc = "";

            #region 赋值
            int flag = 0;
            string bz = tbx_bz.Text.ToString();
            string clbz = tbx_clbz.Text.ToString();
            string czgc = tbx_czgc.Text.ToString();
            string gzbjcljg = tbx_gzbjcljg.Text.ToString();
            string gzqssj = tbx_gzqssj.Text.ToString();
            string gzjssj = tbx_gzjssj.Text.ToString();
            if (gzqssj != "" && gzjssj != "")
            {
                if (Convert.ToDateTime(gzqssj) > Convert.ToDateTime(gzjssj))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"故障起始时间不能大于故障结束时间！\")</script>");
                    return;
                }
            }

            string gzxx = tbx_gzxx.Text.ToString();
            string gzyyfx = tbx_gzyyfx.Text.ToString();
            string jycs = tbx_jycs.Text.ToString();
            string ljsc = tbx_ljsc.Text.ToString();
            string sbbh = tbx_sbbh.Text.ToString();
            string tlgzdpcff = tbx_tlgzdpcff.Text.ToString();
            string wxr = tbx_wxr.Text.ToString();
            string zcyx = tbx_zcyx.Text.ToString();
            string sblx = dt_detail.Rows[0]["sblx"].ToString();
            string wxrbm = ddlt_wxrbm.SelectedValue.ToString();
            string wxrgw = ddlt_wxrgw.SelectedValue.ToString();
            #endregion
            #region 上传
            string path = Upload_path(tbx_whwjsc, "gz");
            #endregion
            #region 判断

            if (string.IsNullOrEmpty(sbbh))
            {
                lbl_sbbh.Text = "<span style=\"color:#ff0000\">" + "错误：设备编号不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbbh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (string.IsNullOrEmpty(gzqssj))
            {
                lbl_gzqssj.Text = "<span style=\"color:#ff0000\">" + "错误：故障起始时间不能为空" + "</span>";
                flag = 1;
            }
            else if (Convert.ToDateTime(gzqssj)>DateTime.Now)
            {  
                lbl_gzqssj.Text = "<span style=\"color:#ff0000\">" + "错误：故障起始时间不能大于当前时间" + "</span>";
                flag = 1;
            }

            else
            {
                lbl_gzqssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(gzjssj))
            {
                lbl_gzjssj.Text = "<span style=\"color:#ff0000\">" + "错误：故障结束时间不能为空" + "</span>";
                flag = 1;
            }
            else if (Convert.ToDateTime(gzjssj)>DateTime.Now)
            {
                 lbl_gzjssj.Text = "<span style=\"color:#ff0000\">" + "错误：故障结束时间不能大于当前时间" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzjssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (!Regex.IsMatch(tbx_ljsc.Text, @"^[0-9]*$") || string.IsNullOrEmpty(ljsc))
            {
                lbl_ljsc.Text = "<span style=\"color:#ff0000\">" + "错误：累计时长不能为空且只能输入数字" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ljsc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(wxr))
            {
                lbl_wxr.Text = "<span style=\"color:#ff0000\">" + "错误：维修人不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }

            if (sblx == "-1")
            {
                lbl_sblx.Text = "<span style=\"color:#ff0000\">" + "错误：请选择设备类型" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sblx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //维修人部门
            if (ddlt_wxrbm.SelectedValue.Trim() == "-1")
            {

                lbl_wxrbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxrbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //维修人岗位
            if (ddlt_wxrgw.SelectedValue.Trim() == "-1")
            {

                lbl_wxrgw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_wxrgw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }



            //设备总类
            if (ddlt_sbzl.SelectedValue.Trim() == "-1")
            {

                lbl_sbzl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbzl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

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
            if (flag == 1)
                return;

            #endregion
            #region 保存

            struct_sbgz.p_bz = bz;
            struct_sbgz.p_clbz = clbz;
            struct_sbgz.p_czgc = czgc;
            struct_sbgz.p_gzbjcljg = gzbjcljg;
            struct_sbgz.p_gzjssj = Convert.ToDateTime(gzjssj);
            struct_sbgz.p_gzqssj = Convert.ToDateTime(gzqssj);
            struct_sbgz.p_gzxx = gzxx;
            struct_sbgz.p_gzyyfx = gzyyfx;
            struct_sbgz.p_jycs = jycs;
            struct_sbgz.p_ljsc = ljsc;
            struct_sbgz.p_sbbh = sbbh;
            struct_sbgz.p_sblx = sblx;
            struct_sbgz.p_tlgzpcff = tlgzdpcff;
            struct_sbgz.p_wxr = wxr;
            struct_sbgz.p_wxrbm = wxrbm;
            struct_sbgz.p_wxrgw = wxrgw;
            struct_sbgz.p_zcyx = zcyx;
            struct_sbgz.p_sbzl = ddlt_sbzl.SelectedValue.ToString().Trim();
            struct_sbgz.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();
            struct_sbgz.p_lrr = _usState.userLoginName;//录入人
            struct_sbgz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_sbgz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人

            struct_sbgz.p_czfs = "03";
            struct_sbgz.p_czxx = "位置：设备管理->设备故障->编辑";
            // int id = Convert.ToInt32(Request.QueryString[0].ToString());
            //// string sb_lx = Request.QueryString[1].ToString();
            // DataTable dt_detail = whwx.Select_SBGZ_Detail(id);
            // struct_sbgz.p_id = id;

            // DataRow dt_row = dt_detail.Rows[0];
            // if (path == "")
            // {
            //     struct_sbgz.p_wxwjsc = dt_row["wxwjsc"].ToString();
            // }
            // else
            // {
            //     struct_sbgz.p_wxwjsc = path;
            // }


            // struct_sbgz.p_czxx = "位置：设备管理->设备故障->编辑  [设备编号：" + struct_sbgz.p_sbbh + "      描述：";

            // if (struct_sbgz.p_sblx != dt_row["sblx"].ToString())
            // {
            //     struct_sbgz.p_czxx += "设备类型：【" + SysData.SBLXByKey(dt_row["sblx"].ToString()).ms + "】->【" + SysData.SBLXByKey(struct_sbgz.p_sblx).ms + "】";

            // }

            // if (struct_sbgz.p_gzqssj != Convert.ToDateTime(dt_row["GZQSSJ"].ToString()))
            // {
            //     struct_sbgz.p_czxx += "故障起始时间：【" + dt_row["GZQSSJ"].ToString() + "】->【" + struct_sbgz.p_gzqssj + "】";

            // }
            // if (struct_sbgz.p_gzjssj != Convert.ToDateTime(dt_row["GZJSSJ"].ToString()))
            // {
            //     struct_sbgz.p_czxx += "故障结束时间：【" + dt_row["GZJSSJ"].ToString() + "】->【" + struct_sbgz.p_gzjssj + "】";

            // }
            // if (struct_sbgz.p_ljsc != dt_row["LJSC"].ToString())
            // {
            //     struct_sbgz.p_czxx += "累计时长：【" + dt_row["LJSC"].ToString() + "】->【" + struct_sbgz.p_ljsc + "】";

            // }
            // if (struct_sbgz.p_wxrbm != dt_row["WXRBM"].ToString())
            // {
            //     struct_sbgz.p_czxx += "维修人部门：【" + dt_row["WXRBM"].ToString() + "】->【" + struct_sbgz.p_wxrbm + "】";

            // }
            // if (struct_sbgz.p_wxrgw != dt_row["WXRGW"].ToString())
            // {
            //     struct_sbgz.p_czxx += "维修人岗位：【" + dt_row["WXRGW"].ToString() + "】->【" + struct_sbgz.p_wxrgw + "】";

            // }
            // if (struct_sbgz.p_gzxx != dt_row["GZXX"].ToString())
            // {
            //     struct_sbgz.p_czxx += "故障现象：【" + dt_row["GZXX"].ToString() + "】->【" + struct_sbgz.p_gzxx + "】";

            // }
            // if (struct_sbgz.p_zcyx != dt_row["ZCYX"].ToString())
            // {
            //     struct_sbgz.p_czxx += "造成影响：【" + dt_row["ZCYX"].ToString() + "】->【" + struct_sbgz.p_zcyx + "】";

            // }
            // if (struct_sbgz.p_czgc != dt_row["CZGC"].ToString())
            // {
            //     struct_sbgz.p_czxx += "处置过程：【" + dt_row["CZGC"].ToString() + "】->【" + struct_sbgz.p_czgc + "】";

            // }
            // if (struct_sbgz.p_gzyyfx != dt_row["GZYYFX"].ToString())
            // {
            //     struct_sbgz.p_czxx += "故障原因分析：【" + dt_row["GZYYFX"].ToString() + "】->【" + struct_sbgz.p_gzyyfx + "】";

            // }
            // if (struct_sbgz.p_gzbjcljg != dt_row["GZBJCLJG"].ToString())
            // {
            //     struct_sbgz.p_czxx += "故障板件处理结果：【" + dt_row["GZBJCLJG"].ToString() + "】->【" + struct_sbgz.p_gzbjcljg + "】";

            // }

            // if (struct_sbgz.p_tlgzpcff != dt_row["TLGZPCFF"].ToString())
            // {
            //     struct_sbgz.p_czxx += " 同类故障排除方法：【" + dt_row["TLGZPCFF"].ToString() + "】->【" + struct_sbgz.p_tlgzpcff + "】";

            // }
            // if (struct_sbgz.p_clbz != dt_row["CLBZ"].ToString())
            // {
            //     struct_sbgz.p_czxx += " 处理步骤：【" + dt_row["CLBZ"].ToString() + "】->【" + struct_sbgz.p_clbz + "】";

            // }
            // if (struct_sbgz.p_jycs != dt_row["JYCS"].ToString())
            // {
            //     struct_sbgz.p_czxx += " 建议措施：【" + dt_row["JYCS"].ToString() + "】->【" + struct_sbgz.p_jycs + "】";

            // }
            // if (struct_sbgz.p_bz != dt_row["BZ"].ToString())
            // {
            //     struct_sbgz.p_czxx += " 备注：【" + dt_row["BZ"].ToString() + "】->【" + struct_sbgz.p_bz + "】";

            // }
            // if (struct_sbgz.p_wxwjsc != dt_row["WXWJSC"].ToString())
            // {
            //     struct_sbgz.p_czxx += " 维修文件上传路径：【" + dt_row["WXWJSC"].ToString() + "】->【" + struct_sbgz.p_wxwjsc + "】";

            // }

            string sjbs = Request.Params["sjbs"].ToString();

            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr))
                {
                    struct_sbgz.p_zt = "2";
                    struct_sbgz.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_sbgz.p_zsr, "14", "1408", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
                {
                    struct_sbgz.p_zt = "3";
                    struct_sbgz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_sbgz.p_zsr, "14", "1408", id);
                }
                if (!struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr) && !struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
                {
                    struct_sbgz.p_zt = "0";
                    struct_sbgz.p_sjbs = "0";
                }
                whwx.Update_SBGZZT(struct_sbgz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr))
                {
                    struct_sbgz.p_zt = "2";
                    struct_sbgz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_sbgz.p_zsr, "14", "1408", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_sbgz.p_sjc = sjc;
                    whwx.Update_SBGZ_SJBS_LSSJ_ZT(struct_sbgz);

                    struct_sbgz.p_zt = "3";
                    struct_sbgz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_sbgz.p_zsr, "14", "1408", id);
                }
                if (!struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr) && !struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
                {
                    struct_sbgz.p_zt = "0";
                    struct_sbgz.p_sjbs = "2";
                }
                whwx.Update_SBGZZT(struct_sbgz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = whwx.Struct_SBGZ_SJBF(Convert.ToInt32(id));
                struct_sbgz.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr))
                {
                    struct_sbgz.p_zt = "2";
                    struct_sbgz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_sbgz.p_zsr, "14", "1408", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_sbgz.p_sjc = sjc;
                    whwx.Update_SBGZ_SJBS_LSSJ_ZT(struct_sbgz);

                    struct_sbgz.p_zt = "3";
                    struct_sbgz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_sbgz.p_zsr, "14", "1408", id);
                }
                if (!struct_sbgz.p_lrr.Equals(struct_sbgz.p_csr) && !struct_sbgz.p_lrr.Equals(struct_sbgz.p_zsr))
                {
                    struct_sbgz.p_zt = "0";
                    struct_sbgz.p_sjbs = "2";
                }
                //将新数据更新到副本数据里
                whwx.Update_SBGZ(struct_sbgz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
               
            }
            else
            {
                return;
            }
            #endregion
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SheBei/SBGZ_GL.aspx");
        }

       
      
        private string MakeFileName(string biaoshi, string exeFileString)
        {
            System.DateTime now = System.DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            string yearString = year.ToString();
            string monthString = month < 10 ? ("0" + month) : month.ToString();
            string dayString = day < 10 ? ("0" + day) : day.ToString();
            string hourString = hour < 10 ? ("0" + hour) : hour.ToString();
            string minuteString = minute < 10 ? ("0" + minute) : minute.ToString();
            string secondString = second < 10 ? ("0" + second) : second.ToString();

            string fileName = yearString + monthString + dayString + hourString + minuteString + secondString + biaoshi + exeFileString;
            return fileName;
        }
        protected string Upload_path(InputFile Upload, string bs)
        {
            //上传
            SaveFileName = "";
            string FileName = Upload.FileName;//获取上传文件的全路径  
            if (FileName != null)
            {
                string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名  
                                                                         //string SaveFileName = System.IO.Path.Combine(Request.PhysicalApplicationPath, DateTime.Now.ToString("yyyyMMddhhmm") + ExtenName);//合并两个路径为上传到服务器上的全路径  
                string fpath = null;
                string filepath = "UpLoads/SBGL/SBGZ/" + tbx_sbbh.Text + "/";
                fpath = System.Web.HttpContext.Current.Request.MapPath(filepath);
                if (!Directory.Exists(fpath))
                    Directory.CreateDirectory(fpath);
                saveFileName = this.MakeFileName(bs, FileName);
                SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath(filepath), saveFileName);//合并两个路径为上传到服务器上的全路径


                if (Upload.ContentLength > 0)

                {

                    Upload.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                }
            }
            return SaveFileName;

        }
        private void bind_rep()
        {
            DataTable dt = whwx.Select_SBGZbySBBH(tbx_sbbh.Text).Tables[0];

            DataTable dt_new = new DataTable();
            dt_new.Columns.Add("filename");
            dt_new.Columns.Add("scsj");
            dt_new.Columns.Add("path");
            bool flag = false;
            foreach (DataRow dr in dt.Rows)
            {
                string path = dr["WXWJSC"].ToString();

                if (path != "")
                {
                    DataRow dr_new = dt_new.NewRow();
                    string filename = path.Substring(path.LastIndexOf("\\") + 1);
                    string time = filename.Substring(0, 14);
                    dr_new["filename"] = filename.Substring(16);
                    dr_new["scsj"] = changTimestyle(time);
                    dr_new["path"] = path;
                    dt_new.Rows.InsertAt(dr_new, 0);
                    flag = true;
                }
            }
            if (flag == true)
            {
                Repeater1.Visible = true;
                Repeater1.DataSource = dt_new;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
            }

        }
        public string changTimestyle(string time)
        {
            string change_time = time.Substring(0, 4) + "/" + time.Substring(4, 2) + "/" + time.Substring(6, 2) + " " +
                                               time.Substring(8, 2) + ":" + time.Substring(10, 2) + ":" + time.Substring(12, 2);
            return change_time;
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "down")
            {
                try
                {
                    // string DownloadFileName = path + e.CommandArgument.ToString();//文件路径
                    string filePath = e.CommandArgument.ToString();//文件名
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    if (File.Exists(filePath))
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                        Response.AddHeader("Content-Transfer-Encoding", "binary");
                        Response.ContentType = "application/octet-stream";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                        Response.WriteFile(fileInfo.FullName);
                        Response.Flush();
                        Response.End();
                    }
                    else
                    {
                        //Response.Write("<script languge='javascript'>alert('文件不存在！');</script>");
                        //Response.Redirect("../main/SBGZ_GL.aspx");
                        //Response.End();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"文件不存在！\")</script>");
                        return;
                    }
                }
                catch { }

            }
        }


    }
}