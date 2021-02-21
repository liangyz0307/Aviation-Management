using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class YG_Edit : System.Web.UI.Page
    {

        private UserState _usState;
        public  string ygbh;
        public string sjc;
        private YG yg;
        private YGZZ ygzz;
        private YGLL ygll;
        private Struct_YG struct_yg;
        private DataTable dt_detail;
        public int cpage1;
        public int psize1;
        public int cpage2;
        public int psize2;
        public int cpage3;
        public int psize3;
        public int cpage;
        public int psize;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            yg = new YG(_usState);
            ygzz = new YGZZ(_usState);
            ygll = new YGLL(_usState);
            if (!IsPostBack)
            {
                ygbh = Request.Params["BH"].ToString();
                lbl_ygbh.Text = ygbh;
                bind_dropdownlist();
                select_detail();
                bind_Main();
                bind_Main_ll();

                tbx_rzsj.Enabled = false;
              //  show();
                tbx_bysj.Attributes.Add("readonly", "readonly");
                tbx_rzsj.Attributes.Add("readonly", "readonly");
            }
        }
        public void show()
        {
            tbx_bysj.Enabled = false;
            tbx_byyx.Enabled = false;
            tbx_bz.Enabled = false;
            tbx_jg.Enabled = false;
            tbx_lxdh.Enabled = false;
            tbx_rzsj.Enabled = false;
            tbx_sfzh.Enabled = false;
            tbx_xm.Enabled = false;
            tbx_xxdz.Enabled = false;
            tbx_zy.Enabled = false;
            ddlt_bm.Enabled = false;
            ddlt_gw.Enabled = false;
            ddlt_gzd.Enabled = false;
            ddlt_htgx.Enabled = false;
            ddlt_htlx.Enabled = false;
            ddlt_mz.Enabled = false;
            ddlt_xl.Enabled = false;
            ddlt_zzmm.Enabled = false;
            btn_save.Visible = false;
            ImageUpload.Enabled = false;


        }
        private void bind_Main_ll()
        {
            DataTable dt = ygll.Select_YGLL_BYBH(ygbh,_usState.userID);

            //绑定分页数据源  
            this.Repeater4.DataSource = dt.DefaultView;
            this.Repeater4.DataBind();
        }
        private void bind_Main()
        {

            #region 英语列表

            DateTime dt = new DateTime();
            DataTable dt_yy = ygzz.Select_YGZZByYGBH(ygbh, _usState.userID).Tables[0];
            dt_yy.Columns.Add("ztmc");
            dt_yy.Columns.Add("yydjmc");
            dt_yy.Columns.Add("yyyxqmc", typeof(string));
            foreach (DataRow dr in dt_yy.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["yydjmc"] = SysData.YYDJLBByKey(dr["yydj"].ToString()).mc;//英语等级
                if (dr["yyyxq"].ToString() == dt.ToString())
                {
                    dr["yyyxqmc"] = "";
                }
                else {
                    DateTime dt_sj = Convert.ToDateTime(dr["yyyxq"].ToString().Trim());
                    dr["yyyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_sj);
                }
            }


            //绑定分页数据源  
            this.Repeater1.DataSource = dt_yy.DefaultView;
            this.Repeater1.DataBind();
            #endregion
            #region 执照列表


            DataTable dt_zz = ygzz.Select_YGZZByYGBH(ygbh, _usState.userID).Tables[1];
            dt_zz.Columns.Add("ztmc");
            dt_zz.Columns.Add("bfrq", typeof(string));
            foreach (DataRow dr in dt_zz.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态

                if (dr["zzbfrq"].ToString() == dt.ToString())
                {
                    dr["bfrq"] = "";
                }
                else {
                    DateTime dt_bfsj = Convert.ToDateTime(dr["zzbfrq"].ToString().Trim());
                    dr["bfrq"] = string.Format("{0:yyyy-MM-dd}", dt_bfsj);
                   // dr["bfrq"] = dr["zzbfrq"];
                }
            }


            //绑定分页数据源  
            this.Repeater2.DataSource = dt_zz.DefaultView;
            this.Repeater2.DataBind();
            #endregion

            #region 签注列表
            DataTable dt_qz = ygzz.Select_YGZZByYGBH(ygbh, _usState.userID).Tables[2];
            dt_qz.Columns.Add("ztmc");
            dt_qz.Columns.Add("qzzymc");
            dt_qz.Columns.Add("qzlbmc");
            dt_qz.Columns.Add("qzxmc");
            dt_qz.Columns.Add("tjdjmc");
            dt_qz.Columns.Add("qzyxqmc", typeof(string));
            dt_qz.Columns.Add("ydqzyxqmc", typeof(string));
            dt_qz.Columns.Add("tjyxqmc", typeof(string));
            dt_qz.Columns.Add("ydqzxmc");
            dt_qz.Columns.Add("ydqzmc");

            foreach (DataRow dr in dt_qz.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["qzzymc"] = SysData.QZZYByKey(dr["qzzy"].ToString()).mc;//签注专业
                dr["qzlbmc"] = SysData.ZZQZLBDMByKey(dr["qzlb"].ToString()).mc;//签注类别
                dr["qzxmc"] = SysData.ZZQZXDMByKey(dr["qzx"].ToString()).mc;//签注项
                dr["tjdjmc"] = SysData.TJDJBByKey(dr["tjdj"].ToString()).mc;//体检等级
                dr["ydqzxmc"] = SysData.ZZQZXDMByKey(dr["ydqzx"].ToString()).mc;//异地签注项
                dr["ydqzmc"] = SysData.YDQZByKey(dr["ydqz"].ToString()).mc;//异地签注项
                if (dr["qzyxq"].ToString() == dt.ToString())
                {
                    dr["qzyxqmc"] = "";
                }
                else {
                    DateTime dt_qzsj = Convert.ToDateTime(dr["qzyxq"].ToString().Trim());
                    dr["qzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_qzsj);
                    //dr["qzyxqmc"] = dr["qzyxq"].ToString(); 
                }
                if (dr["ydqzyxq"].ToString() == dt.ToString())
                {
                    dr["ydqzyxqmc"] = "";
                }
                else {
                    DateTime dt_ydsj = Convert.ToDateTime(dr["ydqzyxq"].ToString().Trim());
                    dr["ydqzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_ydsj);
                    //dr["ydqzyxqmc"] = dr["ydqzyxq"].ToString();
                }
                if (dr["tjyxq"].ToString() == dt.ToString())
                {
                    dr["tjyxqmc"] = "";
                }
                else {
                    DateTime dt_tjsj = Convert.ToDateTime(dr["tjyxq"].ToString().Trim());
                    dr["tjyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_tjsj);
                    //dr["tjyxqmc"] = dr["tjyxq"].ToString();
                }
            }


            //绑定分页数据源  
            this.Repeater3.DataSource = dt_qz.DefaultView;
            this.Repeater3.DataBind();
            #endregion
        }
        protected void bind_dropdownlist()
        {
            DataTable dt_bmdm = SysData.BM().Copy();


            ddlt_bm.DataSource = dt_bmdm;
            ddlt_bm.DataTextField = "mc";
            ddlt_bm.DataValueField = "bm";
            ddlt_bm.DataBind();
            ddlt_bm.Items.Insert(0, new ListItem("请选择", "-1"));

            ////岗位代码
            //ddlt_gw.DataSource = SysData.GW().Copy();
            //ddlt_gw.DataTextField = "mc";
            //ddlt_gw.DataValueField = "bm";

            //ddlt_gw.DataBind();
            //ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));


            //岗位代码
            //DataTable dt_gw = new DataTable();
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            //  ddlt_gw.DataSource = dt_gw;
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));


            //民族
            ddlt_mz.DataTextField = "mc";
            ddlt_mz.DataValueField = "bm";
            ddlt_mz.DataSource = SysData.MZ().Copy();
            ddlt_mz.DataBind();
            ddlt_mz.Items.Insert(0, new ListItem("请选择", "-1"));


            //工作地
            ddlt_gzd.DataTextField = "mc";
            ddlt_gzd.DataValueField = "bm";
            ddlt_gzd.DataSource = SysData.ZXDM().Copy();
            ddlt_gzd.DataBind();
            ddlt_gzd.Items.Insert(0, new ListItem("请选择", "-1"));



            //学历

            ddlt_xl.DataTextField = "mc";
            ddlt_xl.DataValueField = "bm";
            ddlt_xl.DataSource = SysData.XL().Copy();
            ddlt_xl.DataBind();
            ddlt_xl.Items.Insert(0, new ListItem("请选择", "-1"));


            //政治面貌
            ddlt_zzmm.DataTextField = "mc";
            ddlt_zzmm.DataValueField = "bm";
            ddlt_zzmm.DataSource = SysData.ZZMM().Copy();
            ddlt_zzmm.DataBind();
            ddlt_zzmm.Items.Insert(0, new ListItem("请选择", "-1"));



            //合同等级
            ddlt_htlx.DataTextField = "mc";
            ddlt_htlx.DataValueField = "bm";
            ddlt_htlx.DataSource = SysData.HTLX().Copy();
            ddlt_htlx.DataBind();
            ddlt_htlx.Items.Insert(0, new ListItem("请选择", "-1"));

            //合同关系
            ddlt_htgx.DataTextField = "mc";
            ddlt_htgx.DataValueField = "bm";
            ddlt_htgx.DataSource = SysData.HTGX().Copy();
            ddlt_htgx.DataBind();
            ddlt_htgx.Items.Insert(0, new ListItem("请选择", "-1"));

            //用工性质
            ddlt_ygxz.DataTextField = "mc";
            ddlt_ygxz.DataValueField = "bm";
            ddlt_ygxz.DataSource = SysData.HTQX().Copy();
            ddlt_ygxz.DataBind();
            ddlt_ygxz.Items.Insert(0, new ListItem("请选择", "-1"));


            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("11", _usState.userID, "110103");
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


            ////数据所在部门
            //ddlt_sjssbm.DataSource = SysData.BM().Copy();
            //ddlt_sjssbm.DataTextField = "mc";
            //ddlt_sjssbm.DataValueField = "bm";
            //ddlt_sjssbm.DataBind();
            //ddlt_sjssbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        public void GW(string bm)
        {

            if (bm == "-1")
            {
                DataTable dt = new DataTable();
                ddlt_gw.DataSource = dt;
                ddlt_gw.DataBind();
                ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            else
            {
                ddlt_gw.DataSource = SysData.GW(bm).Copy();
                ddlt_gw.DataTextField = "mc";
                ddlt_gw.DataValueField = "bm";
                ddlt_gw.DataBind();
                ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));
            }
        }

        protected void select_detail()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lbl_ygbh.Text = ygbh;
            dt_detail = yg.Select_YGDetail(id);
            tbx_xm.Text = dt_detail.Rows[0]["xm"].ToString();
            string xb = dt_detail.Rows[0]["xbdm"].ToString();
            if (xb == "1")
            { lbl_xb.Text = "男"; }
            else { lbl_xb.Text = "女"; }

            tbx_sfzh.Text = dt_detail.Rows[0]["sfzh"].ToString();
            lbl_csrq.Text = dt_detail.Rows[0]["sfzh"].ToString().Substring(6, 8);
            ddlt_mz.SelectedValue = dt_detail.Rows[0]["mzdm"].ToString();
            tbx_lxdh.Text = dt_detail.Rows[0]["lxdh"].ToString();

            ddlt_bm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();
            ddlt_gw.SelectedValue = dt_detail.Rows[0]["gwdm"].ToString();
            ddlt_gzd.SelectedValue = dt_detail.Rows[0]["gzddm"].ToString();
            tbx_xxdz.Text = dt_detail.Rows[0]["xxdz"].ToString();
            tbx_jg.Text = dt_detail.Rows[0]["jg"].ToString();
            tbx_byyx.Text = dt_detail.Rows[0]["byyx"].ToString();
            tbx_zy.Text = dt_detail.Rows[0]["zy"].ToString();
            ddlt_xl.SelectedValue = dt_detail.Rows[0]["xldm"].ToString();
            tbx_bysj.Text = dt_detail.Rows[0]["bysj"].ToString();
            tbx_rzsj.Text = dt_detail.Rows[0]["rzsj"].ToString();
            ddlt_zzmm.SelectedValue = dt_detail.Rows[0]["zzmmdm"].ToString();
            ddlt_htgx.SelectedValue = dt_detail.Rows[0]["htgx"].ToString();
            ddlt_htlx.SelectedValue = dt_detail.Rows[0]["htlxdm"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
           // ddlt_sjssbm.SelectedValue = dt_detail.Rows[0]["sjssbm"].ToString();//数据所在部门
            #region 资质详情
            //lbl_zzwjhm.Text = dt_detail.Rows[0]["zzwjhm"].ToString();//执照文件号码
            //lbl_zzbh.Text = dt_detail.Rows[0]["zzbh"].ToString();//执照编号
            //lbl_bfrq.Text = dt_detail.Rows[0]["zzbfrq"].ToString();//执照颁发日期
            //lbl_zzqzlb.Text = SysData.ZZQZLBByKey(dt_detail.Rows[0]["zzqzlb"].ToString()).mc;//执照签注类别
            //DateTime dt = new DateTime();
            //if (dt_detail.Rows[0]["zclbyxq"].ToString() != "") {
            //    if (dt_detail.Rows[0]["zclbyxq"].ToString() == dt.ToString())
            //    {
            //        lbl_zclbyxq.Text = "";
            //    }
            //    else
            //    {
            //        DateTime zclbyxq = DateTime.Parse(dt_detail.Rows[0]["zclbyxq"].ToString());
            //        lbl_zclbyxq.Text = zclbyxq.ToString("yyyy-MM-dd");//注册类别有效期

            //    }
            //}
            //else
            //{
            //    lbl_zclbyxq.Text = "";
            //}
            //lbl_ydqz.Text = SysData.YDQZByKey(dt_detail.Rows[0]["ydqz"].ToString()).mc;//异地签注
            //lbl_ydqzlb.Text = SysData.YDQZLBByKey(dt_detail.Rows[0]["ydqzlb"].ToString()).mc;//异地签注类别
            //if (dt_detail.Rows[0]["ydqzyxq"].ToString() != "")
            //{
            //    if (dt_detail.Rows[0]["ydqzyxq"].ToString() != dt.ToString())
            //    {
            //        lbl_ydqzyxq.Text = "";
            //    }
            //    else
            //    {
            //        DateTime ydqzyxq = DateTime.Parse(dt_detail.Rows[0]["ydqzyxq"].ToString());
            //        lbl_ydqzyxq.Text = ydqzyxq.ToString("yyyy-MM-dd");//异地签注有效期

            //    }
            //}
            //else
            //{
            //    lbl_ydqzyxq.Text = "";
            //}
            //lbl_yydj.Text = SysData.YYDJLBByKey(dt_detail.Rows[0]["yydj"].ToString()).mc;//英语等级

            //if (dt_detail.Rows[0]["yyyxq"].ToString() != "")
            //{
            //    if (dt_detail.Rows[0]["yyyxq"].ToString() != dt.ToString())
            //    {
            //        lbl_yyyxq.Text = "";
            //    }
            //    else
            //    {
            //        DateTime yyyxq = DateTime.Parse(dt_detail.Rows[0]["yyyxq"].ToString());
            //        lbl_yyyxq.Text = yyyxq.ToString("yyyy-MM-dd");//英语有效期

            //    }
            //}
            //else
            //{
            //    lbl_yyyxq.Text = "";
            //}

            //lbl_tjdj.Text = SysData.TJDJBByKey(dt_detail.Rows[0]["tjdj"].ToString()).mc;//体检等级
            //if (dt_detail.Rows[0]["tjyxq"].ToString() != "")
            //{
            //    if (dt_detail.Rows[0]["tjyxq"].ToString() != dt.ToString())
            //    {
            //        lbl_tjyxq.Text = "";
            //    }
            //    else
            //    {
            //        DateTime tjyxq = DateTime.Parse(dt_detail.Rows[0]["tjyxq"].ToString());
            //        lbl_tjyxq.Text = tjyxq.ToString("yyyy-MM-dd");//体检等级有效期

            //    }
            //}
            //else
            //{
            //    lbl_tjyxq.Text = "";
            //}
            //lbl_qzzy.Text=SysData.QZZYByKey( dt_detail.Rows[0]["qzzy"].ToString()).mc;//签注专业
            string zplj = dt_detail.Rows[0]["zplj"].ToString();
            if (zplj != "") {
            img_ygzp.ImageUrl = urlconvertor(zplj);//照片路径
               
            }
            #endregion
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Params["id"].ToString());
            string sjbs = Request.Params["sjbs"].ToString();

            #region 校验
            int flag = 0;
            //员工姓名
            string xm = tbx_xm.Text.ToString().Trim();
            if (string.IsNullOrEmpty(xm))
            {

                lbl_xm.Text = "<span style=\"color:#ff0000\">" + "错误" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //员工性别
            //if (rbt_n.Checked == true || rbt_n.Checked == true)
            //{
            //    lbl_xb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //}
            //else
            //{
            //    lbl_xb.Text = "<span style=\"color:#ff0000\">" + "错误：请选择性别！" + "</span>";
            //    flag = 1;
            //}
            //身份证号
            string sfzh = tbx_sfzh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(sfzh))
            {

                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：身份证号不能为空！" + "</span>";
                flag = 1;
            }
            else if (sfzh.Length != 18)
            {
                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：身份证号必须为18位！" + "</span>";
                flag = 1;
            }
            else if ((!Regex.IsMatch(tbx_sfzh.Text, @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
            {
                lbl_sfzh.Text = "<span style=\"color:#ff0000\">" + "错误：请输入正确的身份证号码！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sfzh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
         

            //民族
            if (ddlt_mz.SelectedValue.Trim() == "-1")
            {

                lbl_mz.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }

            //判断照片的格式
            if (ImageUpload.FileName != "") { 
            string type = this.ImageUpload.PostedFile.ContentType;
           
            if (String.Compare(type, "image/jpg", true) == 0 || String.Compare(type, "image/png", true) == 0 || String.Compare(type, "image/jpeg", true) == 0)
            {
                lbl_sc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            else
            {
                lbl_sc.Text = "<span style=\"color:#ff0000\">" + "照片格式错误！<支持格式为：jpg/png/jpeg>" + "</span>";
                flag = 1;
            }
            
            }
            //部门
            if (ddlt_bm.SelectedValue.Trim() == "-1")
            {

                lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //岗位
            if (ddlt_gw.SelectedValue.Trim() == "-1")
            {

                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //联系电话
            string lxdh = tbx_lxdh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(lxdh))
            {
                lbl_lxdh.Text = "<span style=\"color:#ff0000\">" + "错误：联系方式不能为空！" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(lxdh, @"^[1][3578]\d{9}$"))
                {
                    lbl_lxdh.Text = "<span style=\"color:#ff0000\">" + "错误：格式错误！" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_lxdh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //工作地
            if (ddlt_gzd.SelectedValue.Trim() == "-1")
            {

                lbl_gzd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gzd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            ////详细地址
            //lbl_xxdz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            ////籍贯
            //lbl_jg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            ////毕业院校
            //lbl_byyx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //专业
            string zy = tbx_zy.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zy))
            {
                lbl_zy.Text = "<span style=\"color:#ff0000\">" + "错误：专业不能为空！" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //学历
            if (ddlt_xl.SelectedValue.Trim() == "-1")
            {

                lbl_xl.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //毕业时间
            lbl_bysj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //入职时间
            lbl_rzsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
          
            //政治面貌
            if (ddlt_zzmm.SelectedValue.Trim() == "-1")
            {

                lbl_zzmm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zzmm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }


            //合同关系
            if (ddlt_htgx.SelectedValue.Trim() == "-1")
            {

                lbl_htgx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_htgx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //合同类型
            if (ddlt_htlx.SelectedValue.Trim() == "-1")
            {

                lbl_htlx.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_htlx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            ////检查照片路径是否存在 
            //if (img_ygzp.ImageUrl == "")
            //{
            //    lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误！" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            ////备注
            //lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            ////数据所在部门
            //if (ddlt_sjssbm.SelectedValue.Trim() == "-1")
            //{

            //    lbl_sjssbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
            //    flag = 1;
            //}
            //else
            //{
            //    lbl_sjssbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            //}
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag != 1)
            {
                if (tbx_sfzh.Text.Length==18)
                {
                    lbl_csrq.Text = string.Format("{0:yyyy-MM-dd}", tbx_sfzh.Text.Substring(6, 8)); //出生日期
                    int show_xb = Convert.ToInt32(tbx_sfzh.Text.Substring(16, 1));//性别
                    if (show_xb % 2 == 0)
                    {
                        //偶数
                        lbl_xb.Text = "女";//女
                    }
                    else
                    { //奇数
                        lbl_xb.Text = "男";//男
                    }
                }
                //return;
            }
            if (flag == 1) { return; }
            #endregion
            struct_yg.p_bh = lbl_ygbh.Text;
            struct_yg.p_xm = tbx_xm.Text;
            struct_yg.p_sfzh = tbx_sfzh.Text;
            struct_yg.p_csrq = DateTime.ParseExact(struct_yg.p_sfzh.Substring(6, 8), "yyyyMMdd", null);
            int xb = Convert.ToInt32(struct_yg.p_sfzh.Substring(16, 1));
            if (xb % 2 == 0)
            {
                //偶数
                struct_yg.p_xbdm = "2";//女
            }
            else
            { //奇数
                struct_yg.p_xbdm = "1";//男
            }
            int check_rz = 0;
            id = Convert.ToInt32(Request.Params["id"].ToString());
            dt_detail = yg.Select_YGDetail(id);
            struct_yg.p_mzdm = ddlt_mz.SelectedValue.ToString();
            struct_yg.p_lxdh = tbx_lxdh.Text;
            struct_yg.p_gwdm = ddlt_gw.SelectedValue.ToString();
            struct_yg.p_bmdm = ddlt_bm.SelectedValue.ToString();
            struct_yg.p_gzddm = ddlt_gzd.SelectedValue.ToString();
            struct_yg.p_xxdz = tbx_xxdz.Text;
            struct_yg.p_jg = tbx_jg.Text;
            struct_yg.p_byyx = tbx_byyx.Text;
            struct_yg.p_zy = tbx_zy.Text;
            struct_yg.p_xldm = ddlt_xl.SelectedValue.ToString();
            struct_yg.p_bysj = tbx_bysj.Text;
            struct_yg.p_rzsj = tbx_rzsj.Text;
            struct_yg.p_zzmmdm = ddlt_zzmm.SelectedValue.ToString();
            struct_yg.p_htgx = ddlt_htgx.SelectedValue.ToString();
            struct_yg.p_htlxdm = ddlt_htlx.SelectedValue.ToString();

            struct_yg.p_ygxz = ddlt_ygxz.SelectedValue.ToString();

            struct_yg.p_bz = tbx_bz.Text;

            struct_yg.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_yg.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_yg.p_sjssbm = "";//数据所在部门
            struct_yg.p_lrr = _usState.userLoginName.ToString();//录入人
            //清空文件夹
            //   File.Delete(Server.MapPath(urlconvertor(dt_detail.Rows[0]["zplj"].ToString())));
            if (ImageUpload.FileName.ToString() != "")
            {
                SC();//调用上传
                struct_yg.p_zplj = HF_lj.Value;
            }
            else
            {
                struct_yg.p_zplj = dt_detail.Rows[0]["zplj"].ToString();
            }
            struct_yg.p_czfs = "02";
            struct_yg.p_czxx = "位置：员工管理->员工信息管理->编辑    员工编号：[" + struct_yg.p_bh + "]  描述：";
          
            //姓名
            if (struct_yg.p_xm != dt_detail.Rows[0]["xm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "姓名：【" + dt_detail.Rows[0]["xm"].ToString() + "】->【" + struct_yg.p_xm + "】";
                check_rz = 1;
            }
            //性别
            if (struct_yg.p_xbdm != dt_detail.Rows[0]["xbdm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "性别：【" + dt_detail.Rows[0]["xbdm"].ToString() + "】->【" + struct_yg.p_xbdm + "】";
                check_rz = 1;
            }

            //身份证号
            if (struct_yg.p_sfzh != dt_detail.Rows[0]["sfzh"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "身份证号：【" + dt_detail.Rows[0]["sfzh"].ToString() + "】->【" + struct_yg.p_sfzh + "】";
                check_rz = 1;
            }

            //出生日期
            if (struct_yg.p_csrq.ToString()!= dt_detail.Rows[0]["csrq"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "出生日期：【" + dt_detail.Rows[0]["csrq"].ToString() + "】->【" + struct_yg.p_csrq + "】";
                check_rz = 1;
            }
            //民族
            if (struct_yg.p_mzdm != dt_detail.Rows[0]["mzdm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "民族：【" + dt_detail.Rows[0]["mzdm"].ToString() + "】->【" + struct_yg.p_mzdm + "】";
                check_rz = 1;
            }
            //部门
            if (struct_yg.p_bmdm != dt_detail.Rows[0]["bmdm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "部门：【" + dt_detail.Rows[0]["bmdm"].ToString() + "】->【" + struct_yg.p_bmdm + "】";
                check_rz = 1;
            }
            //岗位
            if (struct_yg.p_gwdm != dt_detail.Rows[0]["gwdm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "岗位：【" + dt_detail.Rows[0]["gwdm"].ToString() + "】->【" + struct_yg.p_gwdm + "】";
                check_rz = 1;
            }
            //联系电话
            if (struct_yg.p_lxdh != dt_detail.Rows[0]["lxdh"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "联系电话：【" + dt_detail.Rows[0]["lxdh"].ToString() + "】->【" + struct_yg.p_lxdh + "】";
                check_rz = 1;
            }
            //工作地
            if (struct_yg.p_gzddm != dt_detail.Rows[0]["gzddm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "工作地：【" + dt_detail.Rows[0]["gzddm"].ToString() + "】->【" + struct_yg.p_gzddm + "】";
                check_rz = 1;
            }
            //详细地址
            if (struct_yg.p_xxdz != dt_detail.Rows[0]["xxdz"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "详细地址：【" + dt_detail.Rows[0]["xxdz"].ToString() + "】->【" + struct_yg.p_xxdz + "】";
                check_rz = 1;
            }
            //籍贯
            if (struct_yg.p_jg != dt_detail.Rows[0]["jg"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "籍贯：【" + dt_detail.Rows[0]["jg"].ToString() + "】->【" + struct_yg.p_jg + "】";
                check_rz = 1;
            }
            //毕业院校
            if (struct_yg.p_byyx != dt_detail.Rows[0]["byyx"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "毕业院校：【" + dt_detail.Rows[0]["byyx"].ToString() + "】->【" + struct_yg.p_byyx + "】";
                check_rz = 1;
            }
            //专业
            if (struct_yg.p_zy != dt_detail.Rows[0]["zy"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "专业：【" + dt_detail.Rows[0]["zy"].ToString() + "】->【" + struct_yg.p_zy + "】";
                check_rz = 1;
            }
            //学历
            if (struct_yg.p_xldm != dt_detail.Rows[0]["xldm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "学历：【" + dt_detail.Rows[0]["xldm"].ToString() + "】->【" + struct_yg.p_xldm + "】";
                check_rz = 1;
            }
            //毕业时间
            if (struct_yg.p_bysj != dt_detail.Rows[0]["bysj"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "毕业时间：【" + dt_detail.Rows[0]["bysj"].ToString() + "】->【" + struct_yg.p_bysj + "】";
                check_rz = 1;
            }
            //入职时间
            if (struct_yg.p_rzsj != dt_detail.Rows[0]["rzsj"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "入职时间：【" + dt_detail.Rows[0]["rzsj"].ToString() + "】->【" + struct_yg.p_rzsj + "】";
                check_rz = 1;
            }
            //政治面貌
            if (struct_yg.p_zzmmdm != dt_detail.Rows[0]["zzmmdm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "政治面貌：【" + dt_detail.Rows[0]["zzmmdm"].ToString() + "】->【" + struct_yg.p_zzmmdm + "】";
                check_rz = 1;
            }
          
            //合同关系
            if (struct_yg.p_htgx != dt_detail.Rows[0]["htgx"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "合同关系：【" + dt_detail.Rows[0]["htgx"].ToString() + "】->【" + struct_yg.p_htgx + "】";
                check_rz = 1;
            }
            //合同类型
            if (struct_yg.p_htlxdm != dt_detail.Rows[0]["htlxdm"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "合同类型：【" + dt_detail.Rows[0]["htlxdm"].ToString() + "】->【" + struct_yg.p_htlxdm + "】";
                check_rz = 1;
            }
            //备注
            if (struct_yg.p_bz != dt_detail.Rows[0]["bz"].ToString())
            {
                //已修改
                struct_yg.p_czxx += "备注：【" + dt_detail.Rows[0]["bz"].ToString() + "】->【" + struct_yg.p_bz + "】";
                check_rz = 1;
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

            if (check_rz == 0)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjbs = Request.Params["sjbs"].ToString();

                //如果是原始数据
                if (sjbs.Equals("0"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_yg.p_lrr.Equals(struct_yg.p_csr))
                    {
                        struct_yg.p_zt = "2";
                        struct_yg.p_sjbs = "0";
                        //给终审人添加提示
                        SysData.Insert_TSR(struct_yg.p_zsr, "11", "1101", id);
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "3";
                        struct_yg.p_sjbs = "1";
                        SysData.Delete_TSR(struct_yg.p_zsr, "11", "1101", id);
                    }
                    if(!struct_yg.p_lrr.Equals(struct_yg.p_csr)&&!struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "0";
                        struct_yg.p_sjbs = "0";
                    }
                    yg.Update_YG(struct_yg);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("YGGL.aspx?ygbh=" + _usState.userLoginName);
                }
                else if (sjbs.Equals("2"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_yg.p_lrr.Equals(struct_yg.p_csr))
                    {
                        struct_yg.p_zt = "2";
                        struct_yg.p_sjbs = "2";
                        SysData.Insert_TSR(struct_yg.p_zsr, "11", "1101", id);
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_yg.p_sjc = sjc;
                        yg.Update_YGXX_SJBS_LSSJ_ZT(struct_yg);

                        struct_yg.p_zt = "3";
                        struct_yg.p_sjbs = "1";
                        SysData.Delete_TSR(struct_yg.p_zsr, "11", "1101", id);
                    }
                    if (!struct_yg.p_lrr.Equals(struct_yg.p_csr) && !struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "0";
                        struct_yg.p_sjbs = "2";
                    }
                    yg.Update_YG(struct_yg);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("YGGL.aspx?ygbh=" + _usState.userLoginName);
                }
                else if (sjbs.Equals("1"))
                {
                    //生成该数据的副本,并返回新的备份id
                    id = Convert.ToInt32(Request.Params["id"].ToString());
                    int id_bf = yg.YGXX_SJBF(Convert.ToInt32(id));
                    struct_yg.p_id = id_bf;

                    //初审人录入的数据，状态默认为待终审
                    if (struct_yg.p_lrr.Equals(struct_yg.p_csr))
                    {
                        struct_yg.p_zt = "2";
                        struct_yg.p_sjbs = "2";
                        SysData.Insert_TSR(struct_yg.p_zsr, "11", "1101", id);
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_yg.p_sjc = sjc;
                        yg.Update_YGXX_SJBS_LSSJ_ZT(struct_yg);

                        struct_yg.p_zt = "3";
                        struct_yg.p_sjbs = "1";
                        SysData.Delete_TSR(struct_yg.p_zsr, "11", "1101", id);
                    }
                    if (!struct_yg.p_lrr.Equals(struct_yg.p_csr) && !struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "0";
                        struct_yg.p_sjbs = "2";
                    }
                    //将新数据更新到副本数据里
                    yg.Update_YG(struct_yg);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    img_ygzp.ImageUrl = urlconvertor(struct_yg.p_zplj);//照片路径

                    Server.Transfer("YGGL.aspx?ygbh=" + _usState.userLoginName);
                }
                else
                {
                    return;
                }
            }
            else {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjbs = Request.Params["sjbs"].ToString();
                if (sjbs.Equals("0"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_yg.p_lrr.Equals(struct_yg.p_csr))
                    {
                        struct_yg.p_zt = "2";
                        struct_yg.p_sjbs = "0";
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "3";
                        struct_yg.p_sjbs = "1";
                    }
                    if (!struct_yg.p_lrr.Equals(struct_yg.p_csr) && !struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "0";
                        struct_yg.p_sjbs = "0";
                    }

                    yg.Update_YG(struct_yg);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("YGGL.aspx?ygbh=" + _usState.userLoginName);
                }
                else if (sjbs.Equals("2"))
                {
                    //初审人录入的数据，状态默认为待终审
                    if (struct_yg.p_lrr.Equals(struct_yg.p_csr))
                    {
                        struct_yg.p_zt = "2";
                        struct_yg.p_sjbs = "2";
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_yg.p_sjc = sjc;
                        yg.Update_YGXX_SJBS_LSSJ_ZT(struct_yg);

                        struct_yg.p_zt = "3";
                        struct_yg.p_sjbs = "1";
                    }
                    if (!struct_yg.p_lrr.Equals(struct_yg.p_csr) && !struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "0";
                        struct_yg.p_sjbs = "2";
                    }
                    yg.Update_YG(struct_yg);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("YGGL.aspx?ygbh=" + _usState.userLoginName);
                }
                else if (sjbs.Equals("1"))
                {
                    //生成该数据的副本,并返回新的备份id
                    id = Convert.ToInt32(Request.Params["id"].ToString());
                    int id_bf = yg.YGXX_SJBF(Convert.ToInt32(id));
                    struct_yg.p_id = id_bf;
                    //初审人录入的数据，状态默认为待终审
                    if (struct_yg.p_lrr.Equals(struct_yg.p_csr))
                    {
                        struct_yg.p_zt = "2";
                        struct_yg.p_sjbs = "2";
                    }
                    //终审人录入的数据，状态默认为审核通过
                    if (struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        //将原最终数据变为历史数据
                        sjc = Request.Params["sjc"].ToString();
                        struct_yg.p_sjc = sjc;
                        yg.Update_YGXX_SJBS_LSSJ_ZT(struct_yg);

                        struct_yg.p_zt = "3";
                        struct_yg.p_sjbs = "1";
                    }
                    if (!struct_yg.p_lrr.Equals(struct_yg.p_csr) && !struct_yg.p_lrr.Equals(struct_yg.p_zsr))
                    {
                        struct_yg.p_zt = "0";
                        struct_yg.p_sjbs = "2";
                    }
                    //将新数据更新到副本数据里

                    yg.Update_YG(struct_yg);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    img_ygzp.ImageUrl = urlconvertor(struct_yg.p_zplj);//照片路径

                    Server.Transfer("YGGL.aspx?ygbh=" + _usState.userLoginName);
                }
                else
                {
                    return;
                }
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
            Response.Redirect("YGGL.aspx", true);
        }

        protected void ddlt_bm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bm = ddlt_bm.SelectedValue;
            GW(bm);
            if (bm == "-1")
            {
                lbl_bm.Visible = true;
                lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";


                if (ddlt_gw.SelectedValue == "-1")
                {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";

                }
                else
                {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
            }
            else
            {
                lbl_bm.Visible = true;
                lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                if (ddlt_gw.SelectedValue == "-1")
                {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";

                }
                else
                {
                    lbl_gw.Visible = true;
                    lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
            }
        }

        protected void ddlt_gw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlt_gw.SelectedValue == "-1")
            {
                lbl_gw.Visible = true;
                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";

                if (ddlt_bm.SelectedValue == "-1")
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";

                }
                else
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
            }
            else
            {
                lbl_gw.Visible = true;
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                if (ddlt_bm.SelectedValue == "-1")
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";

                }
                else
                {
                    lbl_bm.Visible = true;
                    lbl_bm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

                }
            }
        }
        public void SC()
        {

            if (ImageUpload.FileName.ToString() != "")
            {
                if (this.ImageUpload.PostedFile.ContentLength < 2097152)
                {
                    string type = this.ImageUpload.PostedFile.ContentType;
                    if (String.Compare(type, "image/jpg", true) == 0 || String.Compare(type, "image/png", true) == 0 || String.Compare(type, "image/jpeg", true) == 0)
                    {
                        string exeFileString = System.IO.Path.GetExtension(this.ImageUpload.PostedFile.FileName);//获取后缀
                        string saveFileName = lbl_ygbh.Text + exeFileString;
                        string savePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\YuanGong\\Temp\\" + lbl_ygbh.Text + "\\";
                        if (!System.IO.Directory.Exists(savePath))
                        {
                            System.IO.Directory.CreateDirectory(savePath);
                        }
                        string imagePath = savePath + saveFileName;
                        this.ImageUpload.PostedFile.SaveAs(imagePath);

                        HF_lj.Value = imagePath;
                       // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"上传成功！\")</script>");
                        img_ygzp.ImageUrl = urlconvertor(imagePath);

                        //刷新后出生日期丢失
                        if (tbx_sfzh.Text.Length == 18)
                        {
                            lbl_csrq.Text = string.Format("{0:yyyy-MM-dd}", tbx_sfzh.Text.Substring(6, 8)); //出生日期
                            int show_xb = Convert.ToInt32(tbx_sfzh.Text.Substring(16, 1));//性别
                            if (show_xb % 2 == 0)
                            {
                                //偶数
                                lbl_xb.Text = "女";//女
                            }
                            else
                            { //奇数
                                lbl_xb.Text = "男";//男
                            }
                        }

                    }
                    else
                    {
                        lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误：图片格式应为JPG或者PNG！" + "</span>";
                    }
                }
                else
                {
                    lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误：图片大小在2M之内！" + "</span>";
                }
            }
            else
            {
                lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误：请选择要上传的图片！" + "</span>";
            }
        }
       
        //转换路径
        private string urlconvertor(string imagesurl)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl_xd = imagesurl.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl_xd = imagesurl_xd.Replace(@"\", @"/");
            return imagesurl_xd;
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            //tbx_bysj.Enabled = true;
            //tbx_byyx.Enabled = true;
            //tbx_bz.Enabled = true;
            //tbx_jg.Enabled = true;
            //tbx_lxdh.Enabled = true;
          
            //tbx_rzsj.Enabled = false;
            //tbx_sfzh.Enabled = true;
            //tbx_xm.Enabled = true;
            //tbx_xxdz.Enabled = true;
            //tbx_zy.Enabled = true;
            //ddlt_bm.Enabled = true;
            //ddlt_gw.Enabled = true;
            //ddlt_gzd.Enabled = true;
            //ddlt_htgx.Enabled = true;
            //ddlt_htlx.Enabled = true;
            //ddlt_mz.Enabled = true;
            //ddlt_xl.Enabled = true;
            //ddlt_zzmm.Enabled = true;
            //btn_save.Visible = true;
            //ImageUpload.Enabled = true;
        }
    }
}