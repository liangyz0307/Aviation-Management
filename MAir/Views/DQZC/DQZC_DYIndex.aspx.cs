using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using CUST.Tools;

namespace CUST.WKG
{
    public partial class DQZC_DYIndex : System.Web.UI.Page
    {

        private DQGHDT dqghdt;
        private GHGL ghgl;
        private UserState userstate;
        public DYZX dyzx;
        public ODYZX.Struct_DYZX struct_dyzx;
        private DSZS dszs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((userstate = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            dqghdt = new DQGHDT(userstate);
            dyzx = new DYZX(userstate);
            dszs = new DSZS(userstate);
            ghgl = new GHGL(userstate);
            if (!IsPostBack)
            {
                Show_dyzx();
                Show_dqghdt();
                Show_dszs();
            }
        }

        #region 党群公会动态
        //private void Show_dqghdt()
        //{
        //    StringBuilder str = new StringBuilder();
        //    //id = userstate.userID;
        //    string bt = "";
        //    DataTable dt_dqghdt = new DataTable();
        //    dt_dqghdt = dqghdt.Find_DQGHDT_ById();
        //    int c = dt_dqghdt.Rows.Count;
        //    if (dt_dqghdt != null && dt_dqghdt.Rows.Count > 0)     //判断是否有数据  
        //    {
        //        if (dt_dqghdt.Rows.Count < 7)
        //        {
        //            for (int j = 0; j < dt_dqghdt.Rows.Count; j++)
        //            {
        //                str.Append("<ul>");
        //                str.Append("<li style='height:31px'>");
        //                str.Append("<img src='../../Content/images/hq.gif'>");
        //                //创建一个实例 //查询的内容，将表内容赋给dt 
        //                bt = dt_dqghdt.Rows[j]["bt"].ToString();
        //            //    str.Append("<a href='DQZC_DQGHDTShow.aspx?id=" + Convert.ToInt32(dt_dqghdt.Rows[j]["id"].ToString()) + "&bt=" + dt_dqghdt.Rows[j]["bt"].ToString() + "'>");    //传值
        //                str.Append(bt);
        //                str.Append("</a>");
        //                str.Append("</li style='height:31px'>");
        //                str.Append("</ul>");
        //                this.lbl_gg.Text = str.ToString();
        //            }
        //            for (int i = 1; i <= 7 - dt_dqghdt.Rows.Count; i++)
        //            {
        //                str.Append("<ul>");
        //                str.Append("<li >");
        //                str.Append("</li>");
        //                str.Append("</ul>");
        //            }
        //        }
        //        else
        //        {
        //            for (int j = 0; j < 7; j++)
        //            {
        //                // str.Append("<ul>");
        //                str.Append("<li style='height:30px'>");
        //                str.Append("<img src='../../Content/images/hq.gif'>");
        //                //创建一个实例 //查询的内容，将表内容赋给dt 
        //                bt = dt_dqghdt.Rows[j]["bt"].ToString();
        //           //     str.Append("<a href='DQZC_DQGHDTShow.aspx?id=" + Convert.ToInt32(dt_dqghdt.Rows[j]["id"].ToString()) + "&bt=" + dt_dqghdt.Rows[j]["bt"].ToString() + "'>");    //传值
        //                str.Append(bt);
        //                str.Append("</a>");
        //                str.Append("</li>");
        //                // str.Append("</ul>");
        //                this.lbl_gg.Text = str.ToString();
        //            }
        //        }

        //    }

        //}
        private void Show_dqghdt()
        {
            StringBuilder str = new StringBuilder();
            //id = userstate.userID;
            string wjm = "";
            DataTable dt_ghgl = new DataTable();
            dt_ghgl = ghgl.Find_GHGL_ById();
            int c = dt_ghgl.Rows.Count;
            if (dt_ghgl != null && dt_ghgl.Rows.Count > 0)     //判断是否有数据  
            {
                if (dt_ghgl.Rows.Count < 7)
                {
                    for (int j = 0; j < dt_ghgl.Rows.Count; j++)
                    {
                        str.Append("<ul>");
                        str.Append("<li style='height:31px'>");
                        str.Append("<img src='../../Content/images/hq.gif'>");
                        //创建一个实例 //查询的内容，将表内容赋给dt 
                        wjm = dt_ghgl.Rows[j]["wjm"].ToString();
                        //    str.Append("<a href='DQZC_DQGHDTShow.aspx?id=" + Convert.ToInt32(dt_dqghdt.Rows[j]["id"].ToString()) + "&bt=" + dt_dqghdt.Rows[j]["bt"].ToString() + "'>");    //传值
                        str.Append(wjm);
                        str.Append("</a>");
                        str.Append("</li style='height:31px'>");
                        str.Append("</ul>");
                        this.lbl_gg.Text = str.ToString();
                    }
                    for (int i = 1; i <= 7 - dt_ghgl.Rows.Count; i++)
                    {
                        str.Append("<ul>");
                        str.Append("<li >");
                        str.Append("</li>");
                        str.Append("</ul>");
                    }
                }
                else
                {
                    for (int j = 0; j < 7; j++)
                    {
                        // str.Append("<ul>");
                        str.Append("<li style='height:30px'>");
                        str.Append("<img src='../../Content/images/hq.gif'>");
                        //创建一个实例 //查询的内容，将表内容赋给dt 
                        wjm = dt_ghgl.Rows[j]["wjm"].ToString();
                        //     str.Append("<a href='DQZC_DQGHDTShow.aspx?id=" + Convert.ToInt32(dt_dqghdt.Rows[j]["id"].ToString()) + "&bt=" + dt_dqghdt.Rows[j]["bt"].ToString() + "'>");    //传值
                        str.Append(wjm);
                        str.Append("</a>");
                        str.Append("</li>");
                        // str.Append("</ul>");
                        this.lbl_gg.Text = str.ToString();
                    }
                }

            }

        }
        #endregion

        #region 党员在线
        private void Show_dyzx()
        {
            string zp = "";
            string xm = "";
            string bm = "";
            string gw = "";
            string zysj = "";
            DataTable dt = new DataTable();
            struct_dyzx.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            struct_dyzx.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");
            dt = dyzx.Select_DYZXbysj(struct_dyzx);
            dt.Columns.Add("bmmc", typeof(string));
            dt.Columns.Add("gwmc", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;//岗位
            }
            if (dt != null && dt.Rows.Count > 0)     //判断是否有数据  
            {
                if (dt.Rows.Count < 4)
                { }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        StringBuilder zp1 = new StringBuilder();
                        StringBuilder bm1 = new StringBuilder();
                        StringBuilder xm1 = new StringBuilder();
                        StringBuilder gw1 = new StringBuilder();
                        StringBuilder zysj1 = new StringBuilder();
                        zp = dt.Rows[j]["zplj"].ToString();

                        zp1.Append(zp);


                        xm = dt.Rows[j]["xm"].ToString();
                        bm = dt.Rows[j]["bmmc"].ToString();
                        gw = dt.Rows[j]["gwmc"].ToString();
                        zysj = dt.Rows[j]["zysj"].ToString();
                        string zplj = dt.Rows[j]["zplj"].ToString();
                        xm1.Append(xm);
                        bm1.Append(bm);
                        gw1.Append(gw);

                        zysj1.Append("<li >");
                        zysj1.Append("<a href='DQZC_ZYSJDetail.aspx?id=" + Convert.ToInt32(dt.Rows[j]["id"].ToString()) + "&zysj=" + dt.Rows[j]["zysj"].ToString() + "'style='color:#F00'>");    //传值
                        zysj1.Append(zysj);
                        zysj1.Append("</a>");
                        zysj1.Append("</li>");

                        if (j == 0)
                        {
                            //this.Image3.ImageUrl = urlconvertor(zplj);
                            this.Image3.ImageUrl = "../../" + zplj;
                            this.Labe_xm1.Text = xm1.ToString();
                            this.Labe_bm1.Text = bm1.ToString();
                            this.Labe_gw1.Text = gw1.ToString();
                            this.Labe_zysj1.Text = zysj1.ToString();
                        }
                        else if (j == 1)
                        {
                           // this.Image4.ImageUrl = urlconvertor(zplj);
                            this.Image4.ImageUrl = "../../" + zplj;

                            this.Labe_xm2.Text = xm1.ToString();
                            this.Labe_bm2.Text = bm1.ToString();
                            this.Labe_gw2.Text = gw1.ToString();
                            this.Labe_zysj2.Text = zysj1.ToString();
                        }
                        else if (j == 2)
                        {
                            //this.Image5.ImageUrl = urlconvertor(zplj);
                            this.Image5.ImageUrl = "../../"+zplj;
                            this.Labe_xm3.Text = xm1.ToString();
                            this.Labe_bm3.Text = bm1.ToString();
                            this.Labe_gw3.Text = gw1.ToString();
                            this.Labe_zysj3.Text = zysj1.ToString();
                        }
                        else
                        {
                            //this.Image6.ImageUrl = urlconvertor(zplj);
                            this.Image6.ImageUrl = "../../" + zplj;
                            this.Labe_xm4.Text = xm1.ToString();
                            this.Labe_bm4.Text = bm1.ToString();
                            this.Labe_gw4.Text = gw1.ToString();
                            this.Labe_zysj4.Text = zysj1.ToString();
                        }
                    }
                }
            }
        }

        #endregion

        #region 党史知识
        private void Show_dszs()
        {
            StringBuilder str = new StringBuilder();
            string bt = "";
            DataTable dt_dszs = new DataTable();
            dt_dszs = dszs.Find_DSZS_ById();
            int c = dt_dszs.Rows.Count;
            if (dt_dszs != null && dt_dszs.Rows.Count > 0)     //判断是否有数据  
            {
                if (dt_dszs.Rows.Count < 7)
                {
                    for (int j = 0; j < dt_dszs.Rows.Count; j++)
                    {
                        str.Append("<ul>");
                        str.Append("<li style='height:31px'>");
                        str.Append("<img src='../../Content/images/hq.gif'>");
                        //创建一个实例 //查询的内容，将表内容赋给dt 
                        bt = dt_dszs.Rows[j]["bt"].ToString();
                        str.Append("<a href='DQZC_DSZSShow.aspx?id=" + Convert.ToInt32(dt_dszs.Rows[j]["id"].ToString()) + "&bt=" + dt_dszs.Rows[j]["bt"].ToString() + "'>");    //传值
                        str.Append(bt);
                        str.Append("</a>");
                        str.Append("</li style='height:31px'>");
                        str.Append("</ul>");
                        this.lbl_dszs.Text = str.ToString();
                    }
                    for (int i = 1; i <= 7 - dt_dszs.Rows.Count; i++)
                    {
                        str.Append("<ul>");
                        str.Append("<li >");
                        str.Append("</li>");
                        str.Append("</ul>");
                    }
                }
                else
                {
                    for (int j = 0; j < 7; j++)
                    {
                        // str.Append("<ul>");
                        str.Append("<li style='height:30px'>");
                        str.Append("<img src='../../Content/images/hq.gif'>");
                        //创建一个实例 //查询的内容，将表内容赋给dt 
                        bt = dt_dszs.Rows[j]["bt"].ToString();
                        str.Append("<a href='DQZC_DSZSShow.aspx?id=" + Convert.ToInt32(dt_dszs.Rows[j]["id"].ToString()) + "&bt=" + dt_dszs.Rows[j]["bt"].ToString() + "'>");    //传值
                        str.Append(bt);
                        str.Append("</a>");
                        str.Append("</li>");
                        // str.Append("</ul>");
                        this.lbl_dszs.Text = str.ToString();
                    }
                }

            }

        }
        #endregion  

        protected void more_dszs_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DSZSShow.aspx");
        }

        protected void more_dqghdt_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GHGLShow.aspx");
        }

        protected void more_dyzx_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DYZXShow.aspx");
        }
        protected void more_dyxx_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../ZXXX/XXIndex.aspx");
        }
        //private string urlconvertor(string imagesurl)
        //{
        //    string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
        //    string imagesurl_xd = imagesurl.Replace(tmpRootDir, ""); //转换成相对路径
        //    imagesurl_xd = imagesurl_xd.Replace(@"\", @"/");
        //    return imagesurl_xd;
        //}
    }
}