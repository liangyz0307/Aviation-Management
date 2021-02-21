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

namespace CUST.WKG
{
    public partial class GRXX : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private string bh;
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
        private YGJL ygjl;
        private YGCF ygcf;
        private YGZC ygzc;
        private PXJL pxjl;
        public int cpage_ygjl;
        public int psize_ygjl;
        public int cpage_ygcf;
        public int psize_ygcf;
        public int cpage_pxjl;
        public int psize_pxjl;
        public int cpage_ygzc;
        public int psize_ygzc;
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
            ygjl = new YGJL(_usState);
            ygcf = new YGCF(_usState);
            pxjl = new PXJL(_usState);
            ygzc = new YGZC(_usState);
            if (!IsPostBack)
            {
                //id = Request.Params["id"].ToString();
                //bh = Request.Params["ygbh"].ToString();
                select_detail();
            }
        }


        protected void select_detail()
        {
            string ygbh =_usState.userLoginName;
            dt_detail = yg.Select_YGDetail_ByBH(ygbh);
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
                img_ygzp.ImageUrl = urlconvertor(zplj) + "?temp=" + DateTime.Now.Millisecond.ToString();//照片路径

            }
            lbl_htgx.Text = SysData.HTGXByKey(dt_detail.Rows[0]["htgx"].ToString()).mc;//合同关系
            lbl_htlx.Text = SysData.HTLXByKey(dt_detail.Rows[0]["htlxdm"].ToString()).mc;//合同类型

            lbl_ygxz.Text = SysData.HTQXByKey(dt_detail.Rows[0]["ygxz"].ToString()).mc;//用工性质

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
            Response.Redirect("../../Views/MenHu/Sys_Index.aspx", true);
        }
    }
}