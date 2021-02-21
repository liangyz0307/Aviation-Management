using CUST;
using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;

namespace Sys
{
    public struct Struct_UserContext
    {
        public string IP;
        public string SessionID;
        public Struct_UserContext(string _IP, string _SessionID)
        {
            this.IP = _IP;
            this.SessionID = _SessionID;
        }
    }
    public class UserState
    {

        #region 字段

        protected static Hashtable _errorCode = InitializeErrorCode();
        protected static Hashtable InitializeErrorCode()
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "登录系统错误，帐号密码错误或不在有效时间内!");
            ht.Add(2, "账户未启用,请及时联系招办!");
            return ht;
        }
        protected int _userID;                    //用户ID
        protected int _userLB;                    //用户类别
        protected string _userLoginName;          //用户账号
        protected string _userPassword;           //用户密码
        protected string _userMC;                 //用户名称
        protected string _userXM;                 //用户姓名
        protected string _userBMDM;                 //部门代码
        protected string _userBMMC;                 //部门名称
        protected string _userGWDM;                 //岗位代码
        protected string _userGWMC;                 //岗位名称
        private string _DLLY;                      //登录来源
        protected DataTable _userGongNengList;    //用户功能权限列表
        protected DataTable dt_yhqx;//用户权限
        protected Struct_UserContext _userContext;//用户结构体
        protected string _userSFQY;               //是否启用
        protected string _IP;
        protected string _userSS;


        protected string _userSFSQXYH;            //是否是权限用户
        protected string _userSFSGLYH;           //是否是管理用户
        protected string _userSFSCDL;            //是否是首次登录

        
        ///39个
        //设备10
        public int _C_SB_TX;
        public int _C_SB_DH;
        public int _C_SB_QX;      
        public int _C_SB_JS;
        public int _C_SB_GZ;
        public int _C_SB_WH;
        public int _C_SB_BJGL;
        public int _C_SB_BJRK;
        public int _C_SB_BJCK;
        public int _C_SB_TZ;
        //后台6
        public int _C_HT_ZD;
        public int _C_HT_RZ;
        public int _C_HT_YH;
        public int _C_HT_BM;
        public int _C_HT_GW;
        public int _C_HT_FBGG;
        //员工7
        public int _C_YG_XX;
        public int _C_YG_ZZ;
        public int _C_YG_LL;
        public int _C_YG_CF;
        public int _C_YG_JL;
        public int _C_YG_PX;
        public int _C_YG_ZC;
        //资料2
        public int _C_ZL_ZL;
        public int _C_ZL_ZJ;
        //报送5
        public int _C_BS_ZBAP;
        public int _C_BS_GZJZ;
        public int _C_BS_YSSB;
        public int _C_BS_ZDGZ;
        public int _C_BS_WXFGL;
        //安全信息4
        public int _C_AQ_AQXX;
        public int _C_AQ_TQCZ;
        public int _C_AQ_BSSG;
        public int _C_AQ_ZYBS;
        //五库建设5
        public int _C_WK_SBBLK;
        public int _C_WK_WXYK;
        public int _C_WK_AQWTK;
        public int _C_WK_AQYHK;
        public int _C_WK_ZJXXK;
      
        #endregion
  
        public Struct_UserContext userContext;
        public UserState(string account,string pwd, Struct_UserContext context)//重载构造函数
        {
            this._userContext = context;
            //在checkuser函数中自动添加用户其他信息。 
            if (!checkuser(account, pwd))
            {
                throw (new Exception(_errorCode[1].ToString()));
            }
        }





        //刷新
        public void Refresh()
        {
        }

        //校验用户
        private bool checkuser(string loginname, string pwd)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                            new OracleParameter("p_zh", OracleType.VarChar),
                            new OracleParameter("p_mm", OracleType.VarChar),
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };

                paras[0].Value = loginname;
                paras[1].Value = CUST.Tools.StrConvert.GetMD5(pwd);//密码MD5加密
                paras[2].Direction = ParameterDirection.Output;

                DataSet ds = db.RunProcedure("PACK_WEB_SYS.YH_Select_UserState", paras, "UserState");
                if (ds.Tables["UserState"].Rows.Count > 0)
                {
                    _userID = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["yh_id"].ToString()); //用户ID
                    _userLB = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["yh_lb"].ToString()); //用户类别
                    _userLoginName = ds.Tables["UserState"].Rows[0]["yh_zh"].ToString();    //登录名
                    _userPassword = ds.Tables["UserState"].Rows[0]["yh_mm"].ToString();     //密码
                    _userMC = ds.Tables["UserState"].Rows[0]["yh_mc"].ToString();           //名称
                    _userXM = ds.Tables["UserState"].Rows[0]["xm"].ToString();           //员工姓名
                    _userSS = ds.Tables["UserState"].Rows[0]["ss"].ToString();           //员工姓名
                    _userBMDM = ds.Tables["UserState"].Rows[0]["bmdm"].ToString();           //员工部门代码
                    _userBMMC = ds.Tables["UserState"].Rows[0]["bmmc"].ToString();           //员工部门名称
                    _userGWDM = ds.Tables["UserState"].Rows[0]["gwdm"].ToString();           //岗位代码
                    _userGWMC = ds.Tables["UserState"].Rows[0]["gwmc"].ToString();           //岗位名称
                    _userSFQY = ds.Tables["UserState"].Rows[0]["yh_sfqy"].ToString(); //是否启用
                    _userSFSCDL = ds.Tables["UserState"].Rows[0]["yh_sfscdl"].ToString();//是否是首次登录 
                    _userSFSQXYH = ds.Tables["UserState"].Rows[0]["yh_sfsqxyh"].ToString(); //是否是权限用户
                    _userSFSGLYH = ds.Tables["UserState"].Rows[0]["sfsglyh"].ToString();
                    //员工
                    _C_YG_XX = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_YG_XX"]);
                    _C_YG_ZZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_YG_ZZ"]);
                    _C_YG_LL = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_YG_LL"]);
                    _C_YG_CF = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_YG_CF"]);
                    _C_YG_PX = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_YG_PX"]);
                    _C_YG_JL = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_YG_JL"]);
                    _C_YG_ZC = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_YG_ZC"]);
                    //设备
                    _C_SB_TX = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_TX"]);
                    _C_SB_DH = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_DH"]);
                    _C_SB_QX = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_QX"]);                   
                    _C_SB_JS = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_JS"]);
                    _C_SB_GZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_GZ"]);
                    _C_SB_WH = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_WH"]);
                    _C_SB_BJGL = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_BJGL"]);
                    _C_SB_BJCK = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_BJCK"]);
                    _C_SB_BJRK = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_BJRK"]);
                    _C_SB_TZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_SB_TZ"]);
                    //后台
                    _C_HT_ZD = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_HT_ZD"]);
                    _C_HT_RZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_HT_RZ"]);
                    _C_HT_YH = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_HT_YH"]);
                    _C_HT_BM = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_HT_BM"]);
                    _C_HT_GW = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_HT_GW"]);
                    _C_HT_FBGG = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_HT_FBGG"]);
                   //资料库 
                    _C_ZL_ZL = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_ZL_ZL"]);
                    _C_ZL_ZJ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_ZL_ZJ"]);
                    //报送
                    _C_BS_ZBAP = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_BS_ZBAP"]);
                    _C_BS_GZJZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_BS_GZJZ"]);
                    _C_BS_YSSB = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_BS_YSSB"]);
                    _C_BS_ZDGZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_BS_ZDGZ"]);
                    _C_BS_WXFGL = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_BS_WXFGL"]);
                    //安全
                    _C_AQ_AQXX = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_AQ_AQXX"]);
                    _C_AQ_TQCZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_AQ_TQCZ"]);
                    _C_AQ_BSSG = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_AQ_BSSG"]);
                    _C_AQ_ZYBS = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_AQ_ZYBS"]);
                    //五库
                    _C_WK_SBBLK = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_WK_SBBLK"]);
                    _C_WK_WXYK = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_WK_WXYK"]);
                    _C_WK_AQWTK = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_WK_AQWTK"]);
                    _C_WK_AQYHK = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_WK_AQYHK"]);
                    _C_WK_ZJXXK = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_WK_ZJXXK"]);
                    //_C_JS_BF = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_JS_BF"]);
                    //_C_JS_TZ = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_JS_TZ"]);
                    //_C_JS_ZL = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_JS_ZL"]);
                    //_C_JX_BF = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_JX_BF"]);
                    //_C_JSBF = Convert.ToInt32(ds.Tables["UserState"].Rows[0]["C_JSBF"]);


                    if (_userSFQY == "0")
                    {
                        throw (new Exception(_errorCode[2].ToString()));
                    }
                    #region  初始化GongNengList.
                    _userGongNengList = new DataTable();
                    DBClass db_gn = new DBClass();
                    try
                    {
                              OracleParameter[] paras_gn = 
                                                          {
                                                             new OracleParameter("p_yhid", OracleType.Number),
                                                             new OracleParameter("p_cur", OracleType.Cursor)
                        };
                        paras_gn[0].Value = _userID;
                        paras_gn[1].Direction = ParameterDirection.Output;
                        _userGongNengList = db_gn.RunProcedure("PACK_YHQXGL.YH_Select_YH_QX", paras_gn, "YH_GN").Tables["YH_GN"];
                    }
                    finally
                    {
                        db_gn.Close();
                    }
                    #endregion

                    #region 初始化用户权限
                    dt_yhqx = new DataTable();
                    DBClass db_yhqx = new DBClass();
                    try
                    {
                         OracleParameter[] paras_qx = 
                                                  {
                                                     new OracleParameter("p_yhid", OracleType.Number),
                                                     new OracleParameter("p_cur", OracleType.Cursor)
                        };
                        paras_qx[0].Value = _userID;
                        paras_qx[1].Direction = ParameterDirection.Output;
                        dt_yhqx = db_yhqx.RunProcedure("PACK_KG_YHJS.Select_QXByYHID", paras_qx, "table").Tables[0];
                    }
                    finally
                    {
                        db_yhqx.Close();
                    }
                    #endregion



                    return true;
                }

                else
                {
                    return false;
                }
            }
            finally
            {
                db.Close();
            }
        }

        //校验用户密码
        private bool checkusermm(string loginname, string pwd)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                            new OracleParameter("p_zh", OracleType.VarChar),
                            new OracleParameter("p_mm", OracleType.VarChar),
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };
                paras[0].Value = loginname;
                paras[1].Value = CUST.Tools.StrConvert.GetMD5(pwd);//密码MD5加密
                paras[2].Direction = ParameterDirection.Output;

                DataSet ds = db.RunProcedure("PACK_WEB_SYS.YH_Check", paras, "YHCheck");
                if (ds.Tables["YHCheck"].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                db.Close();
            }
        }

        //获取有效时间
        public DataSet SelectYXSJ(string zh)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                            new OracleParameter("p_zh", OracleType.VarChar),
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };
                paras[0].Value = zh;
                paras[1].Direction = ParameterDirection.Output;
                DataSet ds = db.RunProcedure("PACK_WEB_SYS.SelectYXSJ", paras, "table");
                return ds;
            }
            finally
            {
                db.Close();
            }
        }

        public void updatzcscdl(string loginname, string omm, string xpwd)
        {

            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                            new OracleParameter("p_zh", OracleType.VarChar),
                            new OracleParameter("p_mm", OracleType.VarChar),
                            new OracleParameter("p_mc", OracleType.VarChar),
                            new OracleParameter("p_errorCode", OracleType.Int32)
                        };
                paras[0].Value = loginname;
                paras[1].Value = CUST.Tools.StrConvert.GetMD5(xpwd);//密码MD5加密
                paras[2].Value = omm;
                paras[3].Direction = ParameterDirection.Output;

                int rowsAffected;
                db.RunProcedure("PACK_WEB_SYS.YH_Update", paras, out rowsAffected);
                int errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
            }
            finally
            {
                db.Close();
            }
        }
        //修改用户密码及名称
        public void updateuser(string loginname, string mc, string xpwd, string jpwd)
        {
            if (checkusermm(loginname, jpwd))
            {
                DBClass db = new DBClass();
                try
                {
                    OracleParameter[] paras = {
                            new OracleParameter("p_zh", OracleType.VarChar),
                            new OracleParameter("p_mm", OracleType.VarChar),
                            new OracleParameter("p_mc", OracleType.VarChar),
                            new OracleParameter("p_errorCode", OracleType.Int32)
                        };
                    paras[0].Value = loginname;
                    paras[1].Value = CUST.Tools.StrConvert.GetMD5(xpwd);//密码MD5加密
                    paras[2].Value = mc;
                    paras[3].Direction = ParameterDirection.Output;

                    int rowsAffected;
                    db.RunProcedure("PACK_WEB_SYS.YH_Update", paras, out rowsAffected);
                    int errorCode = Convert.ToInt32(paras[3].Value);
                    if (errorCode != 0)
                    {
                        throw new EMException(errorCode);
                    }
                }
                finally
                {
                    db.Close();
                }
            }
            else
            {
                throw new EMException(10000301);
            }
        }

        //修改用户密码
        public void updateusermm(string loginname, string csmm, string nmm)
        {
            if (checkusermm(loginname, csmm))
            {
                DBClass db = new DBClass();
                try
                {
                    OracleParameter[] paras = {
                            new OracleParameter("p_zh", OracleType.VarChar),
                            new OracleParameter("p_mm", OracleType.VarChar),
                            new OracleParameter("p_nmm", OracleType.VarChar),
                            new OracleParameter("p_errorCode", OracleType.Int32)
                        };
                    paras[0].Value = loginname;
                    paras[1].Value = CUST.Tools.StrConvert.GetMD5(csmm);//密码MD5加密
                    paras[2].Value = CUST.Tools.StrConvert.GetMD5(nmm);//密码MD5加密
                    paras[3].Direction = ParameterDirection.Output;

                    int rowsAffected;
                    db.RunProcedure("PACK_WEB_SYS.YH_UpdateMM", paras, out rowsAffected);
                    int errorCode = Convert.ToInt32(paras[3].Value);
                    if (errorCode != 0)
                    {
                        throw new EMException(errorCode);
                    }
                }
                finally
                {
                    db.Close();
                }
            }
            else
            {
                throw new EMException(10000301);
            }
        }

        //添加用户登录日志
        public void insertyhrz(int yh_id, string ip, DateTime sj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                        new OracleParameter("p_yh_id", OracleType.Number),
                        new OracleParameter("p_ip", OracleType.VarChar),
                        new OracleParameter("p_sj", OracleType.DateTime),
                        new OracleParameter("p_errorCode", OracleType.Int32)
                    };
                paras[0].Value = yh_id;
                paras[1].Value = ip;
                paras[2].Value = sj;
                paras[3].Direction = ParameterDirection.Output;

                int rowsAffected;
                db.RunProcedure("PACK_WEB_SYS.YHRZ_Insert", paras, out rowsAffected);
                int errorCode = Convert.ToInt32(paras[3].Value);
                if (errorCode != 0)
                {
                    throw new EMException(errorCode);
                }
            }
            finally
            {
                db.Close();
            }
        }

        //检索用户登录日志
        public DataTable showyhrz(int yh_id, DateTime kssj, DateTime jssj)
        {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] paras = {
                        new OracleParameter("p_yh_id", OracleType.Number),
                        new OracleParameter("p_kssj", OracleType.DateTime),
                        new OracleParameter("p_jssj", OracleType.DateTime),
                        new OracleParameter("p_cur", OracleType.Cursor)
                    };
                paras[0].Value = yh_id;
                paras[1].Value = kssj;
                paras[2].Value = jssj;
                paras[3].Direction = ParameterDirection.Output;

                DataTable dt = db.RunProcedure("PACK_WEB_SYS.YHRZ_Select", paras, "yhrz").Tables["yhrz"];
                dt.TableName = "yhrz";
                return dt;
            }
            finally
            {
                db.Close();
            }
        }

        //用户权限
        //将gn_dm改为dm
        //权限修改
        public bool HasThisFunction(int functionid)
        {
            if (_userGongNengList == null)
            {
                return false;
            }
            else
            {
                return _userGongNengList.Select("DM=" + functionid).Length > 0 ? true : false;
            }
        }

        public bool HasThisRight(string qx)
        {
            if (dt_yhqx.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_yhqx.Select("qx=" + qx).Length > 0 ? true : false;
            }
        }


        #region 属性

        public int userID//用户ID
        {
            get
            {
                return _userID;
            }
        }
        public string userPassword//用户密码
        {
            get
            {
                return _userPassword;
            }
        }
        public string userSFSGLYH//是否是管理用户
        {
            get
            {
                return _userSFSGLYH;
            }
        }
        public Struct_UserContext context//用户结构体
        {
            get
            {
                return _userContext;
            }
        }
        public int userLB//用户级别
        {
            get
            {
                return _userLB;
            }
        }
        public string userLoginName//用户账号
        {
            get
            {
                return _userLoginName;
            }
        }
        public string IP//用户账号
        {
            get
            {
                return _IP;
            }
        }
        public string userSS//用户账号
        {
            get
            {
                return _userSS;
            }
        }
        public string userMC//用户名称
        {
            get
            {
                return _userMC;
            }
        }
        public string userXM//员工姓名
        {
            get
            {
                return _userXM;
            }
        }
        public string userBMDM//员工部门代码
        {
            get
            {
                return _userBMDM;
            }
        }
        public string userBMMC//员工部门名称
        {
            get
            {
                return _userBMMC;
            }
        }
        public string userGWDM//员工岗位代码
        {
            get
            {
                return _userGWDM;
            }
        }
        public string userGWMC//员工岗位名称
        {
            get
            {
                return _userGWMC;
            }
        }
        public string DLLY
        {
            get
            {
                return _DLLY;
            }
            set
            {
                _DLLY = value;
            }
        }
        #region============是否是权限用户==========
        public string userSFSQXYH //是否是权限用户
        {
            get
            {
                return _userSFSQXYH;
            }
        }
        #endregion
        #region============是否是初次登录==========
        public string userSFSCDL
        {
            get
            {
                return _userSFSCDL;
            }
        }
        #endregion


        #region  检索参数配置
        
        //员工
        public int C_YG_XX
        {
            get { return _C_YG_XX; }
            set { _C_YG_XX = value; }
        }
        public int C_YG_ZZ
        {
            get { return _C_YG_ZZ; }
            set { _C_YG_ZZ = value; }
        }
        public int C_YG_LL
        {
            get { return _C_YG_LL; }
            set { _C_YG_LL = value; }
        }
        public int C_YG_CF
        {
            get { return _C_YG_CF; }
            set { _C_YG_CF = value; }
        }
        public int C_YG_JL
        {
            get { return _C_YG_JL; }
            set { _C_YG_JL = value; }
        }
        public int C_YG_ZC
        {
            get { return _C_YG_ZC; }
            set { _C_YG_ZC = value; }
        }
        public int C_YG_PX
        {
            get { return _C_YG_PX; }
            set { _C_YG_PX = value; }
        }
        //设备
        public int C_SB_TX
        {
            get { return _C_SB_TX; }
            set { _C_SB_TX = value; }
        }
        public int C_SB_DH
        {
            get { return _C_SB_DH; }
            set { _C_SB_DH = value; }
        }
        public int C_SB_QX
        {
            get { return _C_SB_QX; }
            set { _C_SB_QX = value; }
        }
       
        public int C_SB_JS
        {
            get { return _C_SB_JS; }
            set { _C_SB_JS = value; }
        }
        public int C_SB_GZ
        {
            get { return _C_SB_GZ; }
            set { _C_SB_GZ = value; }
        }
        public int C_SB_WH
        {
            get { return _C_SB_WH; }
            set { _C_SB_WH = value; }
        }
        public int C_SB_BJGL
        {
            get { return _C_SB_BJGL; }
            set { _C_SB_BJGL = value; }
        }

        public int C_SB_BJCK
        {
            get { return _C_SB_BJCK; }
            set { _C_SB_BJCK = value; }
        }
        public int C_SB_BJRK
        {
            get { return _C_SB_BJRK; }
            set { _C_SB_BJRK = value; }
        }
        public int C_SB_TZ
        {
            get { return _C_SB_TZ; }
            set { _C_SB_TZ = value; }
        }
        //后台
        public int C_HT_ZD
        {
            get { return _C_HT_ZD; }
            set { _C_HT_ZD = value; }
        }
        public int C_HT_RZ
        {
            get { return _C_HT_RZ; }
            set { _C_HT_RZ = value; }
        }
        public int C_HT_YH
        {
            get { return _C_HT_YH; }
            set { _C_HT_YH = value; }
        }
        public int C_HT_BM
        {
            get { return _C_HT_BM; }
            set { _C_HT_BM = value; }
        }
        public int C_HT_GW
        {
            get { return _C_HT_GW; }
            set { _C_HT_GW = value; }
        }
        public int C_HT_FBGG
        {
            get { return _C_HT_FBGG; }
            set { _C_HT_FBGG = value; }
        }
     
        //资料库

        public int C_ZL_ZL
        {
            get { return _C_ZL_ZL; }
            set { _C_ZL_ZL = value; }
        }
        public int C_ZL_ZJ
        {
            get { return _C_ZL_ZJ; }
            set { _C_ZL_ZJ = value; }
        }
        //报送
        public int C_BS_ZBAP
        {
            get { return _C_BS_ZBAP; }
            set { _C_BS_ZBAP = value; }
        }
        public int C_BS_GZJZ
        {
            get { return _C_BS_GZJZ; }
            set { _C_BS_GZJZ = value; }
        }
        public int C_BS_YSSB
        {
            get { return _C_BS_YSSB; }
            set { _C_BS_YSSB = value; }
        }
        public int C_BS_ZDGZ
        {
            get { return _C_BS_ZDGZ; }
            set { _C_BS_ZDGZ = value; }
        }
        public int C_BS_WXFGL
        {
            get { return _C_BS_WXFGL; }
            set { _C_BS_WXFGL = value; }
        }
        //安全信息
        public int C_AQ_AQXX
        {
            get { return _C_AQ_AQXX; }
            set { _C_AQ_AQXX = value; }
        }
        public int C_AQ_TQCZ
        {
            get { return _C_AQ_TQCZ; }
            set { _C_AQ_TQCZ = value; }
        }
        public int C_AQ_BSSG
        {
            get { return _C_AQ_BSSG; }
            set { _C_AQ_BSSG = value; }
        }
        public int C_AQ_ZYBS
        {
            get { return _C_AQ_ZYBS; }
            set { _C_AQ_ZYBS = value; }
        }
        //
        public int C_WK_SBBLK
        {
            get { return _C_WK_SBBLK; }
            set { _C_WK_SBBLK = value; }
        }
        public int C_WK_WXYK
        {
            get { return _C_WK_WXYK; }
            set { _C_WK_WXYK = value; }
        }
        public int C_WK_AQWTK
        {
            get { return _C_WK_AQWTK; }
            set { _C_WK_AQWTK = value; }
        }
        public int C_WK_AQYHK
        {
            get { return _C_WK_AQYHK; }
            set { _C_WK_AQYHK = value; }
        }
        public int C_WK_ZJXXK
        {
            get { return _C_WK_ZJXXK; }
            set { _C_WK_ZJXXK = value; }
        }

      

        #endregion


        //private bool checkUser(string account, string pwd)//验证登陆用户
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = User_Login(account, pwd).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            _userAccount = dt.Rows[0]["ZH"].ToString();
        //            _userPwd = dt.Rows[0]["MM"].ToString();
        //            _userType = dt.Rows[0]["LB"].ToString();
        //            _isLegal = dt.Rows[0]["SFSQXYH"].ToString();
        //            _isEnable = dt.Rows[0]["SFQY"].ToString();
        //            _userNO = dt.Rows[0]["XLH"].ToString();
        //            _userBelong = dt.Rows[0]["SS"].ToString();
        //            _isFirstLogin = dt.Rows[0]["SFSCDL"].ToString();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //protected DataSet User_Login(string account, string pwd)//用户登录
        //{
        //    DBClass db = new DBClass();
        //    try
        //    {
        //        OracleParameter[] paras = {
        //                                  new OracleParameter("p_zh",OracleType.VarChar),
        //                                  new OracleParameter("p_mm",OracleType.VarChar),
        //                                  new OracleParameter("p_cur",OracleType.Cursor)
        //                                  };
        //        paras[0].Value = account;
        //        paras[1].Value = CUST.Tools.StrConvert.GetMD5(pwd);
        //        paras[2].Direction = ParameterDirection.Output;
        //        DataSet ds = db.RunProcedure("PACK_WEB_SYS.YH_Check", paras, "tables");
        //        return ds;
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //}
    }
}
#endregion