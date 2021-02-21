using CUST;
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

namespace MAir.Views.JXGL
{
    public partial class GRJX_YGXX : System.Web.UI.Page
    {
        private UserState _usState;
        private YG yg;
        private YGZZ ygzz;
        private YGLL ygll;
        private Struct_YG struct_yg;
        public int cpage1;
        public int psize1;
        public int cpage2;
        public int psize2;
        public int cpage3;
        public int psize3;
        public int cpage;
        public int psize;
        private string bh;
        private DataTable dt_detail;
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
                bh = Request.QueryString.Get("bh").ToString();
                select_detail();
                bind_Main();
                bind_Main_ll();
            }
        }
        private void bind_Main_ll()
        {
            DataTable dt = ygll.Select_YGLL_BYBH(bh, _usState.userID);
            //绑定分页数据源  
            this.Repeater4.DataSource = dt.DefaultView;
            this.Repeater4.DataBind();
        }
        private void bind_Main()
        {
            #region 英语列表
            DateTime dt = new DateTime();
            DataTable dt_yy = ygzz.Select_YGZZByYGBH(bh,_usState.userID).Tables[0];
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
                else
                {
                    DateTime dt_sj = Convert.ToDateTime(dr["yyyxq"].ToString().Trim());
                    dr["yyyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_sj);
                }
            }
            //绑定分页数据源  
            this.Repeater1.DataSource = dt_yy.DefaultView;
            this.Repeater1.DataBind();
            #endregion
            #region 执照列表
            DataTable dt_zz = ygzz.Select_YGZZByYGBH(bh,_usState.userID).Tables[1];
            dt_zz.Columns.Add("ztmc");
            dt_zz.Columns.Add("bfrq", typeof(string));
            foreach (DataRow dr in dt_zz.Rows)
            {
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                if (dr["zzbfrq"].ToString() == dt.ToString())
                {
                    dr["bfrq"] = "";
                }
                else
                {
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
            DataTable dt_qz = ygzz.Select_YGZZByYGBH(bh,_usState.userID).Tables[2];
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
                else
                {
                    DateTime dt_qzsj = Convert.ToDateTime(dr["qzyxq"].ToString().Trim());
                    dr["qzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_qzsj);
                    //dr["qzyxqmc"] = dr["qzyxq"].ToString(); 
                }
                if (dr["ydqzyxq"].ToString() == dt.ToString())
                {
                    dr["ydqzyxqmc"] = "";
                }
                else
                {
                    DateTime dt_ydsj = Convert.ToDateTime(dr["ydqzyxq"].ToString().Trim());
                    dr["ydqzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_ydsj);
                    //dr["ydqzyxqmc"] = dr["ydqzyxq"].ToString();
                }
                if (dr["tjyxq"].ToString() == dt.ToString())
                {
                    dr["tjyxqmc"] = "";
                }
                else
                {
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
        protected void select_detail()
        {
            bh = Request.QueryString.Get("bh").ToString();
            dt_detail = yg.Select_YGDetail_ByBH(bh);
            lbl_ygbh.Text = dt_detail.Rows[0]["bh"].ToString();//员工编号
            lbl_xm.Text = dt_detail.Rows[0]["xm"].ToString();//员工姓名
            lbl_xb.Text = SysData.XBByKey(dt_detail.Rows[0]["xbdm"].ToString()).mc;//性别
            lbl_sfzh.Text = dt_detail.Rows[0]["sfzh"].ToString();//身份证号
            DateTime dt_csrq = new DateTime();
            dt_csrq = Convert.ToDateTime(dt_detail.Rows[0]["csrq"].ToString());
            lbl_csrq.Text = string.Format("{0:yyyy-MM-dd}", dt_csrq);//出生日期
            lbl_mz.Text = SysData.MZByKey(dt_detail.Rows[0]["mzdm"].ToString()).mc;//民族
            lbl_bm.Text = SysData.BMByKey(dt_detail.Rows[0]["bmdm"].ToString()).mc;//部门
            lbl_gw.Text = SysData.GWByKey(dt_detail.Rows[0]["gwdm"].ToString()).mc;//岗位
            lbl_lxdh.Text = dt_detail.Rows[0]["lxdh"].ToString();//联系电话
            lbl_gzd.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["gzddm"].ToString()).mc;//工作地
            lbl_xxdz.Text = dt_detail.Rows[0]["xxdz"].ToString();//详细地址
            lbl_jg.Text = dt_detail.Rows[0]["jg"].ToString();//籍贯

            lbl_byyx.Text = dt_detail.Rows[0]["byyx"].ToString();//毕业院校
            lbl_zy.Text = dt_detail.Rows[0]["zy"].ToString();//专业
            lbl_xl.Text = SysData.XLByKey(dt_detail.Rows[0]["xldm"].ToString()).mc;//学历
            lbl_bysj.Text = dt_detail.Rows[0]["bysj"].ToString();//毕业时间
            lbl_rzsj.Text = dt_detail.Rows[0]["rzsj"].ToString();//入职时间
            lbl_zzmm.Text = SysData.ZZMMByKey(dt_detail.Rows[0]["zzmmdm"].ToString()).mc;//政治面貌

            string zplj = dt_detail.Rows[0]["zplj"].ToString();
            if (zplj != "")
            {
                img_ygzp.ImageUrl = urlconvertor(zplj);//照片路径
            }
            //lbl_zzwjhm.Text = dt_detail.Rows[0]["zzwjhm"].ToString();//执照文件号码
            //lbl_zzbh.Text = dt_detail.Rows[0]["zzbh"].ToString();//执照编号
            //lbl_bfrq.Text = dt_detail.Rows[0]["zzbfrq"].ToString();//执照颁发日期
            //lbl_zzqzlb.Text =SysData.ZZQZLBByKey( dt_detail.Rows[0]["zzqzlb"].ToString()).ms;//执照签注类别
            //lbl_zclbyxq.Text = dt_detail.Rows[0]["zclbyxq"].ToString();//注册类别有效期
            //lbl_ydqz.Text =SysData.YDQZByKey( dt_detail.Rows[0]["ydqz"].ToString()).ms;//异地签注
            //lbl_ydqzlb.Text =SysData.YDQZLBByKey( dt_detail.Rows[0]["ydqzlb"].ToString()).ms;//异地签注类别
            //lbl_ydqzyxq.Text = dt_detail.Rows[0]["ydqzyxq"].ToString();//异地签注有效期
            //lbl_yydj.Text =SysData.YYDJLBByKey( dt_detail.Rows[0]["yydj"].ToString()).ms;//英语等级
            //lbl_yyyxq.Text = dt_detail.Rows[0]["yyyxq"].ToString();//英语有效期
            //lbl_tjdj.Text =SysData.TJDJBByKey( dt_detail.Rows[0]["tjdj"].ToString()).ms;//体检等级
            //lbl_tjyxq.Text = dt_detail.Rows[0]["tjyxq"].ToString();//体检等级有效期
            lbl_htgx.Text = SysData.HTGXByKey(dt_detail.Rows[0]["htgx"].ToString()).mc;//合同关系
            lbl_htlx.Text = SysData.HTLXByKey(dt_detail.Rows[0]["htlxdm"].ToString()).mc;//合同类型
            lbl_bz.Text = dt_detail.Rows[0]["bz"].ToString();//备注
        }
        //转换路径
        private string urlconvertor(string imagesurl)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl_xd = imagesurl.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl_xd = imagesurl_xd.Replace(@"\", @"/");
            return imagesurl_xd;
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
            bh = Request.QueryString.Get("bh").ToString();
            Response.Redirect("GRJXZF.aspx?ygbh="+bh, true);
        }

    }
}