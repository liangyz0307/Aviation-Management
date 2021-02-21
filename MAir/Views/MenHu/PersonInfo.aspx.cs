using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.MKG;
using CUST.Sys;
using System.Data;
using System.IO;
using Sys;
namespace MAir.Views.MenHu
{
    public partial class PersonInfo : System.Web.UI.Page
    {
        private UserState _usState;
        public JS js;
        private YG yg;
        public OJS.Struct_JS_YG struct_js_yg;
        public string ygbh;
        public string filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='Sys_Index.aspx';</script>");
                Response.End();
                return;
            }
            yg = new YG(_usState);
            js = new JS(_usState);
            if (!IsPostBack)
            {

            }
            bind();
        }
        private void bind()
        {
            #region//基本信息 
            struct_js_yg.p_bh = _usState.userLoginName;// Request.Params["bh"].ToString();
            DataTable dt_detail = new DataTable();
            dt_detail = yg.Select_YGDetail_ByBH(ygbh);
            lbl_ygbh.Text = dt_detail.Rows[0]["bh"].ToString();//员工编号
            lbl_xm.Text = dt_detail.Rows[0]["xm"].ToString();//员工姓名
            lbl_xb.Text = SysData.XBByKey(dt_detail.Rows[0]["xbdm"].ToString()).mc;//性别
            lbl_sfzh.Text = dt_detail.Rows[0]["sfzh"].ToString();//身份证号
            DateTime dt_csrq = new DateTime();
            dt_csrq = Convert.ToDateTime(dt_detail.Rows[0]["csrq"].ToString());
            lbl_csrq.Text = string.Format("{0:yyyy-MM-dd}", dt_csrq);//出生日期
            lbl_mz.Text = SysData.MZByKey(dt_detail.Rows[0]["mzdm"].ToString()).mc;//民族
            lbl_lxdh.Text = dt_detail.Rows[0]["lxdh"].ToString();//联系电话         
            lbl_gwdm.Text = SysData.GWByKey(dt_detail.Rows[0]["gwdm"].ToString()).mc;//岗位
            lbl_bmdm.Text = SysData.BMByKey(dt_detail.Rows[0]["bmdm"].ToString()).mc;//部门
            lbl_gzd.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["gzddm"].ToString()).mc;//工作地
            lbl_xxdz.Text = dt_detail.Rows[0]["xxdz"].ToString();//详细地址
            lbl_jg.Text = dt_detail.Rows[0]["jg"].ToString();//籍贯
            lbl_byyx.Text = dt_detail.Rows[0]["byyx"].ToString();//毕业院校
            lbl_zy.Text = dt_detail.Rows[0]["zy"].ToString();//专业
            lbl_xl.Text = SysData.XLByKey(dt_detail.Rows[0]["xldm"].ToString()).mc;//学历
            lbl_bysj.Text = dt_detail.Rows[0]["bysj"].ToString();//毕业时间
            lbl_rzsj.Text = dt_detail.Rows[0]["rzsj"].ToString();//入职时间
            lbl_zzmm.Text = SysData.ZZMMByKey(dt_detail.Rows[0]["zzmmdm"].ToString()).mc;//政治面貌
            lbl_htgx.Text = SysData.HTGXByKey(dt_detail.Rows[0]["htgx"].ToString()).mc;//合同关系
            lbl_htlx.Text = SysData.HTLXByKey(dt_detail.Rows[0]["htlxdm"].ToString()).mc;//合同类型
            lbl_ygbz.Text = dt_detail.Rows[0]["bz"].ToString();//备注
            img_ygzp.ImageUrl = urlconvertor(dt_detail.Rows[0]["zplj"].ToString());//照片路径
            lbl_zt.Text =SysData.ZTDMByKey( dt_detail.Rows[0]["zt"].ToString()).mc;
            #endregion
            

        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sys_Index.aspx");
        }
        //转换路径
        private string urlconvertor(string imagesurl)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl_xd = imagesurl.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl_xd = imagesurl_xd.Replace(@"\", @"/");
            return imagesurl_xd;
        }

     
    }
}