using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
namespace CUST.Sys
{
    internal struct ZdType
    {
        public const string CZFS = "czfs";//性别
        public const string XBDM = "xbdm";//性别
        public const string FXYZT = "fxyzt";//风险源状态
        public const string YZCD = "yzcddm";//
        public const string YDQZ = "ydqz";//异地签注
        public const string YDZC = "ydzc";//异地注册
        public const string YDQZLB = "ydqzlb";//异地签注类别
        public const string YYDJ = "yydj"; //英语等级
        public const string TJDJ = "tjdj"; //体检等级
        public const string HTDJ = "htlx"; //合同等级
        public const string ZZQZLB = "zzqzlb"; //执照签注类别
        public const string BMDM = "bmdm";//部门
        public const string GWDM = "gwdm";//岗位
        public const string GZDDM = "gzddm";//工作地
        public const string MZDM = "mzdm";//民族
        public const string XLDM = "xldm";//学历
        public const string ZZMMDM = "zzmmdm";//政治面貌
        public const string HTLXDM = "htlxdm";//合同类型
        public const string ZTDM = "ztdm";//状态代码
        public const string WD1DM = "wd1dm";//维度1代码
        public const string WD2DM = "wd2dm";//维度2代码
        public const string WD3DM = "wd3dm";//维度3代码
        public const string YHLBDM = "yhlbdm";//用户类别代码
        public const string HTGXDM = "htgxdm";//合同关系代码
        public const string HTQXDM = "htqxdm";//合同期限代码
        public const string YGZTDM = "ygztdm";//员工状态代码
        public const string YHZTDM = "yhztdm";//用户状态代码
        public const string QZZYDM = "qzzydm";//签注专业代码
        public const string WJLB = "wjlb";//文件类别
        public const string SBLX = "sblx";//设备类型
        public const string SBZTDM = "sbztdm";//设备状态代码
        public const string SBLBDM = "sblbdm";//设备类别代码
        public const string SBZL = "sbzl";//设备种类
        public const string DZB_BS = "dzb_bs";//党支部标识
        public const string ZDLX = "zdlx";//站点类型
        public const string SBPZ = "sbpz";//设备配置
        public const string MFCXY = "mfcxy";//MFC协议
        public const string QSIGXY = "qsigxy";//Q-SIG协议
        public const string IPXY = "ipxy";//IP协议
        public const string PCXJJF = "pcxjjf";//评测项加减分
        public const string ZCJB = "zcjb";//职称级别
        public const string ZG = "zg";//资格
        public const string PR = "pr";//是否聘任
        public const string ZXTDM = "zxtdm";//子系统代码
        public const string SBWZ = "sbwz";//设备位置
        public const string WXLB = "wxlb";//维修类别代码
        public const string TZLXDM = "tzlxdm";//台站类型代码
        public const string SBYTDM = "sbytdm";//设备用途代码
        public const string DWLXDM = "dwlxdm";//地网类型代码
        public const string FXXJDM = "fxxjdm";//飞行校检代码
        public const string FGFWDM = "fgfwdm";//覆盖范围代码
        public const string SFWXDSB = "sfwxdsb";//是否无线电设备
        public const string TXFSDM = "txfsdm";//通信方式代码
        public const string TXLXDM = "txlxdm";//天线类型代码
        public const string BSLX = "bslx";//报送类型
        public const string ZJLBDM = "zjlbdm";//专家类别代码
        public const string ZJSSDM = "zjssdm";//专家所属代码
        public const string WDLX = "wdlx";//文档类型
        public const string BJLXDM = "bjlxdm";//备件类型代码
        public const string BJSY = "bjsy";//备件适用
        public const string WHZTDM = "whztdm";//维护状态代码
        public const string HBLXDM = "hblxdm";//航班类型代码
        public const string ZXDM = "zxdm";//支线代码
        public const string WXYFC = "wxyfc";//危险源范畴
        public const string STDM = "stdm";//时态代码
        public const string FXFSKN = "fxfskn";//风险发生可能
        public const string FXCD = "fxcd";//风险程度
        public const string FXKZZT = "fxkzzt";//风险控制状态
        public const string FXKZBZ = "fxkzbz";//风险控制标准
        public const string FXZT = "fxzt";//风险控制标准
        public const string ZCLY = "zcly";//资产来源
        public const string RZXS = "rzxs";//入账形式
        public const string WPLBDM = "wplbdm";//物品类别代码
        public const string SHZTDM = "shztdm";//审核状态代码
        public const string YLXS = "ylxsdm";//演练形式
        public const string YXQK = "yxqk";//运行情况
        public const string SFWC = "sfwc";//是否完成
        public const string RZLX = "rzlx";//日志类型
        public const string ZZZT = "zzzt";//资质状态
        public const string ZYMC = "zymc";//专业名称
        public const string ZCMC = "zcmc";//职称名称
        public const string ZCDJ = "zcdj";//职称等级
        public const string JNMC = "jnmc";//技能名称
        public const string JNDJ = "jndj";//技能等级
        public const string BMZT = "bmztdm";//部门状态
        public const string GGLX = "gglxdm";//公告类型
        public const string ALLX = "allx";//案例类型
        public const string FXDJ = "fxdj";//风险等级
        public const string BZQK = "bzqk";//保障情况
        public const string GZYYDM = "gzyydm";//故障原因代码
        public const string WXDGRLX = "wxdgrlx";//无线电干扰类型
        public const string JHXTJYY = "jhxtjyy";//计划性停机原因
        public const string BYPC = "bypc";//保养频次
        public const string HTZT = "htzt";//合同状态
        public const string YGXS = "ygxs";//用工形式
        public const string DZZMC = "dzzmc";//党组织名称
        public const string JCDZBMC = "jcdzbmc";//基层党支部名称
        public const string DXZMC = "dxzmc";//党小组名称
        public const string STND = "stnd";//试题难度
        public const string STLX = "stlx";//试题类型
        public const string STLB = "stlb";//试题类型
        public const string XQ = "xq";//星期
        public const string STZT = "stzt";//试题状态
        public const string KM = "km";//科目
        public const string ZT = "shzt";//状态
        public const string ZZQZX = "zzqzx";//执照签注项
        public const string ZZQZLBDM = "zzqzlb";//执照签注类别代码
        public const string ZZQZXDM = "zzqzx";//执照签注项代码
        public const string SFDB = "sfdb";
        public const string YG = "yg";
        public const string WXLX = "wxlx";//维修类型代码
        public const string ZYLX = "zylx";//专业类型代码
        public const string YSLX = "yslx";//预算类型代码
        public const string ZT2 = "zt";//状态代码(预算申报)
        public const string HXZT = "hxzt";//航线申请状态
        public const string LY = "ly";//来源
        public const string YHDJ = "yhdj";//隐患等级
        public const string ZGGBPZ = "zggbpz";//整改关闭批准
        public const string SJZLDM = "sjzldm";//事件种类代码
        public const string JLZL = "jlzl";//奖励种类
        public const string JLDJ = "jldj";//奖励等级
        public const string TYPE = "type";//培训记事件类型
        public const string JB = "jb";//培训记录级别
        public const string KHJG = "khjg";//培训记录考核结果
        public const string BMLB = "bmlb";//部门类别
        public const string ZJLX = "zjlx";
        public const string ALLX1 = "allx1";//案例类型1
        public const string ALLX2 = "allx2";//案例类型2
        public const string ALLY = "ally";//案例来源
        public const string ALDJ = "aldj";//案例等级
        public const string ZLLX1 = "zllx1";//资料类型一
        public const string ZLLX2 = "zllx2";//资料类型二
        public const string PLDW = "pldw";//频率单位
        public const string TCSFXY = "tcsfxy";//投产是否限用
        public const string MCFXJYJG = "mcfxjyjg";//末次飞行校验结果
        public const string FGFWDW = "fgfwdw";//覆盖范围单位
        public const string SCGLDW = "scgldw";//输出功率单位
        public const string HXSBLB = "hxsblb";//航向设备(仪表着陆系统LOC)类别
        public const string HXSBTXZLX = "hxsbtxzlx";//航向设备(仪表着陆系统LOC)天线阵类型
        public const string XHSBTXZLX = "xhsbtxzlx";//下滑设备（仪表着陆系统GP)天线阵类型
        public const string CJYPYSB = "cjyptsb";//测距仪(DME)配套设备
        public const string ZDXBLXXZ = "zdxblxxz";//指点信标 类型选择
        public const string SJFC = "sjfc";//涉及范畴
        public const string HGYZX = "hgyzx";//后果严重程度
        public const string WXCD = "wxcd";//危险程度
        public const string AQZT = "aqzt";//安全状态
        public const string ZGCSBZHQK = "zgcsbzhqk";//整改措施标准化情况
        public const string WTZT = "wtzt";//问题状态
        public const string TBDW = "tbdw";//填报单位
        public const string jcrwzt = "jcrwzt";//检查任务状态
        public const string JCJG = "jcjg";//检查结果
        public const string ZGZT = "zgzt";//整改结果
        public const string DYLX = "dylx";//党员类型
        public const string ZZQK = "zzqk";//专家情况

        public const string TQCZ = "tqcz";//特情处置
        public const string BJBS = "bjbs";//比较标识
        public const string SJZL = "sjzl";//事件种类代码
        public const string SFJB = "sfjb";//是否具备（台站）
        public const string MHSBLX = "mhsblx";//灭火设备类型（台站）
        public const string JDFS = "jdfs";//检定方式
    }

    #region 结构体
    /// <summary>
    /// 字典结构体.
    /// </summary>
    public struct Struct_ZD
    {
        /// <summary>
        /// 字典码.
        /// </summary>
        public string zdm;
        /// <summary>
        /// 编码.
        /// </summary>
        public string bm;
        /// <summary>
        /// 名称.
        /// </summary>
        public string mc;
        /// <summary>
        /// 【编码】名称.
        /// </summary>
        public string ms;
    }
    public struct Struct_BM
    {
        public string bm;
        public string mc;
        public string sjbmdm;
        public string bmlb;
        public string fzr;
        public string lxdh;
        public string zt;
        public string ms;
    }
    public struct Struct_GW
    {
        public string bm;
        public string bmdm;
        public string mc;
        public string ms;
    }
    public struct Struct_ZZQZLB
    {
        public string bm;
        public string mc;
        public string ms;
    }
    #endregion
    public class SysData
    {
        #region 工具
        //初始化字典
        private static DataTable InitZDData(string zdm)
        {
            lock (typeof(SysData))
            {
                DBClass dbc = new DBClass();
                try
                {
                    OracleParameter[] opara ={
                                             new OracleParameter("p_zdm",OracleType.VarChar),
                                             new OracleParameter("p_mycur",OracleType.Cursor)
                                         };
                    opara[0].Value = zdm;
                    opara[1].Direction = ParameterDirection.Output;
                    DataSet ds = dbc.RunProcedure("PACK_SYS.Sys_ZD_selectByZDM", opara, "table");
                    return ds.Tables[0];
                }
                finally
                {
                    dbc.Close();
                }
            }
        }
        /// <summary>
        /// 从静态表转化为哈希表.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static Hashtable FromZDDataTableToHashTable(DataTable dt)
        {
            lock (typeof(SysData))
            {
                Hashtable ht = new Hashtable();
                Struct_ZD zd;
                string bm;
                foreach (DataRow dr in dt.Rows)
                {
                    bm = dr["BM"].ToString();
                    //字典码.
                    zd.zdm = dr["ZDM"].ToString();
                    //编码.
                    zd.bm = dr["BM"].ToString();
                    //描述.
                    zd.mc = dr["MC"].ToString();
                    zd.ms = "[" + dr["BM"].ToString().Trim() + "]" + dr["MC"].ToString();
                    ht.Add(bm, zd);
                }
                return ht;
            }
        }
        /// <summary>
        /// 从哈希表转化为静态表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        private static DataTable FromHashTableToDataTable(Hashtable ht)
        {
            lock (typeof(SysData))
            {
                if (ht == null) return null;
                DataTable dt = new DataTable();
                dt.Columns.Add("bm", typeof(string));
                dt.Columns.Add("mc", typeof(string));
                dt.Columns.Add("ms", typeof(string));
                DataRow dr;
                foreach (DictionaryEntry de in ht)
                {
                    dr = dt.NewRow();
                    dr["bm"] = de.Key;
                    dr["mc"] = de.Value;
                    dr["ms"] = de.Value;
                    dt.Rows.Add(dr);
                }
                dt.DefaultView.Sort = "bm asc";
                return dt.DefaultView.ToTable();
            }
        }
        //datarow[]转化为datatable
        private static DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable dt = rows[0].Table.Clone(); // 复制DataRow的表结构
            foreach (DataRow row in rows)
            {
                dt.ImportRow(row); // 将DataRow添加到DataTable中
            }
            return dt;
        }
        #endregion
        #region 初始化各个静态“字典”
        #region  ===============mzdm================
        private static DataTable dt_mz = InitZDData(ZdType.MZDM);
        public static DataTable MZ()
        {
            return dt_mz;
        }
        private static Hashtable ht_mz = FromZDDataTableToHashTable(dt_mz);
        public static Struct_ZD MZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_mz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============czfs  操作方式================
        private static DataTable dt_czfs = InitZDData(ZdType.CZFS);
        public static DataTable CZFS()
        {
            return dt_czfs;
        }
        private static Hashtable ht_czfs = FromZDDataTableToHashTable(dt_czfs);
        public static Struct_ZD CZFSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_czfs[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============xbdm  性别================
        private static DataTable dt_xb = InitZDData(ZdType.XBDM);
        public static DataTable XB()
        {
            return dt_xb;
        }
        private static Hashtable ht_xb = FromZDDataTableToHashTable(dt_xb);
        public static Struct_ZD XBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_xb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region========================wxlx 维修类型===================
        private static DataTable dt_wxlx = InitZDData(ZdType.WXLX);
        public static DataTable WXLX()
        {
            return dt_wxlx;
        }
        private static Hashtable ht_wxlx = FromZDDataTableToHashTable(dt_wxlx);
        public static Struct_ZD WXLXByKey(string key)
        {
            object obj = ht_wxlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="tqcz";//特情处置================
        private static DataTable dt_tqcz = InitZDData(ZdType.TQCZ);
        public static DataTable TQCZ()
        {
            return dt_tqcz;
        }
        private static Hashtable ht_tqcz = FromZDDataTableToHashTable(dt_tqcz);
        public static Struct_ZD TQCZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_tqcz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region==========================hxzt 航线申请状态======
        private static DataTable dt_hxzt = InitZDData(ZdType.HXZT);
        public static DataTable HXZT()
        {
            return dt_hxzt;
        }
        private static Hashtable ht_hxzt = FromZDDataTableToHashTable(dt_hxzt);
        public static Struct_ZD HXZTByKey(string key)
        {
            object obj = ht_hxzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region================ zylx 专业类型===================
        private static DataTable dt_zylx = InitZDData(ZdType.ZYLX);
        public static DataTable ZYLX()
        {
            return dt_zylx;
        }
        private static Hashtable ht_zylx = FromZDDataTableToHashTable(dt_zylx);
        public static Struct_ZD ZYLXByKey(string key)
        {
            object obj = ht_zylx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region========================yslx 预算类型===================
        private static DataTable dt_yslx = InitZDData(ZdType.YSLX);
        public static DataTable YSLX()
        {
            return dt_yslx;
        }
        private static Hashtable ht_yslx = FromZDDataTableToHashTable(dt_yslx);
        public static Struct_ZD YSLXByKey(string key)
        {
            object obj = ht_yslx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region========================zts 状态2===================
        private static DataTable dt_zts = InitZDData(ZdType.ZT2);
        public static DataTable ZT2()
        {
            return dt_zts;
        }
        private static Hashtable ht_zts = FromZDDataTableToHashTable(dt_zts);
        public static Struct_ZD ZT2ByKey(string key)
        {
            object obj = ht_zts[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ydqz  异地签注================
        private static DataTable dt_ydqz = InitZDData(ZdType.YDQZ);
        public static DataTable YDQZ()
        {
            return dt_ydqz;
        }
        private static Hashtable ht_ydqz = FromZDDataTableToHashTable(dt_ydqz);
        public static Struct_ZD YDQZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ydqz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ydzc 异地注册================
        private static DataTable dt_ydzc = InitZDData(ZdType.YDZC);
        public static DataTable YDZC()
        {
            return dt_ydzc;
        }
        private static Hashtable ht_ydzc = FromZDDataTableToHashTable(dt_ydzc);
        public static Struct_ZD YDZCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ydzc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ydqzlb 异地签注类别================
        private static DataTable dt_ydqzlb = InitZDData(ZdType.YDQZLB);
        public static DataTable YDQZLB()
        {
            return dt_ydqzlb;
        }
        private static Hashtable ht_ydqzlb = FromZDDataTableToHashTable(dt_ydqzlb);
        public static Struct_ZD YDQZLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ydqzlb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  =============== yydj 英语等级================
        private static DataTable dt_yydj = InitZDData(ZdType.YYDJ);
        public static DataTable YYDJ()
        {
            return dt_yydj;
        }
        private static Hashtable ht_yydj = FromZDDataTableToHashTable(dt_yydj);
        public static Struct_ZD YYDJLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_yydj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  =============== tjdj 体检等级================
        private static DataTable dt_tjdj = InitZDData(ZdType.TJDJ);
        public static DataTable TJDJ()
        {
            return dt_tjdj;
        }
        private static Hashtable ht_tjdj = FromZDDataTableToHashTable(dt_tjdj);
        public static Struct_ZD TJDJBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_tjdj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="dzb_bs";//党支部标识================
        private static DataTable dt_dzb_bs = InitZDData(ZdType.DZB_BS);
        public static DataTable DZB_BS()
        {
            return dt_dzb_bs;
        }
        private static Hashtable ht_dzb_bs = FromZDDataTableToHashTable(dt_dzb_bs);
        public static Struct_ZD DZB_BSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_dzb_bs[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============zjlx";//专家类型================
        private static DataTable dt_zjlx = InitZDData(ZdType.ZJLX);
        public static DataTable ZJLX()
        {
            return dt_zjlx;
        }
        private static Hashtable ht_zjlx = FromZDDataTableToHashTable(dt_zjlx);
        public static Struct_ZD ZJLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zjlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ztdm  状态代码================
        private static DataTable dt_ztdm = InitZDData(ZdType.ZTDM);
        public static DataTable ZT()
        {
            return dt_ztdm;
        }
        private static Hashtable ht_ztdm = FromZDDataTableToHashTable(dt_ztdm);
        public static Struct_ZD ZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ztdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============bmdm  部门================
        private static DataTable dt_bm = InitBMData();
        public static DataTable BM()
        {
            return dt_bm;
        }
        public static DataTable BM(string qxdm, int userId)
        {
            return InitBMData(qxdm, userId);
        }
        private static Hashtable ht_bm = FromBMDataTableToHashTable(dt_bm);
        public static Struct_BM BMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bm[key];
            Struct_BM struct_BM = new Struct_BM();
            struct_BM.bm = key;
            return (obj != null ? (Struct_BM)obj : struct_BM);
        }
        private static DataTable InitBMData()
        {
            lock (typeof(SysData))
            {
                DBClass dbc = new DBClass();
                try
                {
                    OracleParameter[] opara ={
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                         };
                    opara[0].Direction = ParameterDirection.Output;
                    DataSet ds = dbc.RunProcedure("PACK_HTGL_BMGW.Select_BMALL", opara, "table");
                    return ds.Tables[0];
                }
                finally
                {
                    dbc.Close();
                }
            }
        }

        private static DataTable InitBMData(string qxdm, int userId)
        {
            lock (typeof(SysData))
            {
                DBClass dbc = new DBClass();
                try
                {
                    OracleParameter[] opara ={
                                             new OracleParameter("p_qxdm",OracleType.VarChar),
                                             new OracleParameter("p_userId",OracleType.Int32),
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                         };

                    opara[0].Value = qxdm;
                    opara[1].Value = userId;
                    opara[2].Direction = ParameterDirection.Output;
                    DataSet ds = dbc.RunProcedure("PACK_HTGL_BMGW.Select_BM_BY_BMQX_YHID", opara, "table");
                    return ds.Tables[0];
                }
                finally
                {
                    dbc.Close();
                }
            }
        }

        private static Hashtable FromBMDataTableToHashTable(DataTable dt)
        {
            lock (typeof(SysData))
            {
                Hashtable ht = new Hashtable();
                Struct_BM bm;
                string bmdm;
                foreach (DataRow dr in dt.Rows)
                {
                    bmdm = dr["BM"].ToString();
                    bm.bm = dr["BM"].ToString();
                    bm.mc = dr["MC"].ToString();
                    bm.sjbmdm = dr["SJBMDM"].ToString();
                    bm.bmlb = dr["BMLB"].ToString();
                    bm.fzr = dr["FZR"].ToString();
                    bm.lxdh = dr["LXDH"].ToString();
                    bm.zt = dr["ZT"].ToString();
                    bm.ms = dr["MS"].ToString();
                    ht.Add(bmdm, bm);
                }
                return ht;
            }
        }
        #endregion
        private static DataTable dt_gw = InitGWData();
        public static DataTable GW()
        {
            return dt_gw;
        }
        public static DataTable GW(string bmdm)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_gw.Select("bmdm like '" + bmdm + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_gw = FromGWDataTableToHashTable(dt_gw);
        public static Struct_GW GWByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_gw[key];
            Struct_GW struct_GW = new Struct_GW();
            struct_GW.bm = key;
            return (obj != null ? (Struct_GW)obj : struct_GW);
        }
        private static DataTable InitGWData()
        {
            lock (typeof(SysData))
            {
                DBClass dbc = new DBClass();
                try
                {
                    OracleParameter[] opara ={
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                         };
                    opara[0].Direction = ParameterDirection.Output;
                    DataSet ds = dbc.RunProcedure("PACK_KG_GWGL.Select_GWALL", opara, "table");
                    return ds.Tables[0];
                }
                finally
                {
                    dbc.Close();
                }
            }
        }
        private static Hashtable FromGWDataTableToHashTable(DataTable dt)
        {
            lock (typeof(SysData))
            {
                Hashtable ht = new Hashtable();
                Struct_GW gw;
                string gwdm;
                foreach (DataRow dr in dt.Rows)
                {
                    gwdm = dr["BM"].ToString();
                    gw.bm = dr["BM"].ToString();
                    gw.mc = dr["MC"].ToString();
                    gw.bmdm = dr["BMDM"].ToString();
                    gw.ms = dr["MS"].ToString();
                    ht.Add(gwdm, gw);
                }
                return ht;
            }
        }
        #endregion
        #region  ===============zzqzlb   执照签注类别================
        private static DataTable dt_zzqzlb = InitZZQZLBData();
        public static DataTable ZZQZLB()
        {
            return dt_zzqzlb;
        }
        public static DataTable ZZQZLB(string qzzydm)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_zzqzlb.Select("bm like '" + qzzydm + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_zzqzlb = FromZZQZLBDataTableToHashTable(dt_zzqzlb);
        public static Struct_ZD ZZQZLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zzqzlb[key];
            Struct_ZD struct_zd = new Struct_ZD();
            struct_zd.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_zd);
        }
        private static DataTable InitZZQZLBData()
        {
            lock (typeof(SysData))
            {
                DBClass dbc = new DBClass();
                try
                {
                    OracleParameter[] opara ={
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                         };
                    opara[0].Direction = ParameterDirection.Output;
                    DataSet ds = dbc.RunProcedure("PACK_KG_YGZZ.Select_ZZQZLB", opara, "table");
                    return ds.Tables[0];
                }
                finally
                {
                    dbc.Close();
                }
            }
        }
        private static Hashtable FromZZQZLBDataTableToHashTable(DataTable dt)
        {
            lock (typeof(SysData))
            {
                Hashtable ht = new Hashtable();
                Struct_ZD zzqzlb;
                foreach (DataRow dr in dt.Rows)
                {
                    zzqzlb.bm = dr["BM"].ToString();
                    zzqzlb.mc = dr["MC"].ToString();
                    zzqzlb.ms = dr["MS"].ToString();
                    ht.Add(zzqzlb.bm, zzqzlb.mc);
                }
                return ht;
            }
        }
        #endregion
        #region  ===============zzqzlb   执照签注项================
        private static DataTable dt_zzqzx = InitZZQZXData();
        public static DataTable ZZQZX()
        {
            return dt_zzqzx;
        }
        public static DataTable ZZQZX(string zzqzlb)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_zzqzx.Select("bm like '" + zzqzlb + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_zzqzx = FromZZQZXDataTableToHashTable(dt_zzqzx);
        public static Struct_ZD ZZQZXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zzqzx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        private static DataTable InitZZQZXData()
        {
            lock (typeof(SysData))
            {
                DBClass dbc = new DBClass();
                try
                {
                    OracleParameter[] opara ={
                                             new OracleParameter("p_cur",OracleType.Cursor)
                                         };
                    opara[0].Direction = ParameterDirection.Output;
                    DataSet ds = dbc.RunProcedure("PACK_KG_YGZZ.Select_ZZQZX", opara, "table");
                    return ds.Tables[0];
                }
                finally
                {
                    dbc.Close();
                }
            }
        }
        private static Hashtable FromZZQZXDataTableToHashTable(DataTable dt)
        {
            lock (typeof(SysData))
            {
                Hashtable ht = new Hashtable();
                string zzqzxdm, zzqzxmc, zzqzxms;
                foreach (DataRow dr in dt.Rows)
                {
                    zzqzxdm = dr["BM"].ToString();
                    zzqzxmc = dr["MC"].ToString();
                    zzqzxms = dr["MS"].ToString();
                    ht.Add(zzqzxdm, zzqzxmc);
                }
                return ht;
            }
        }
        #endregion
        /*
        #region  ===============gzddm  工作地================
        private static DataTable dt_gzddm = InitZDData(ZdType.GZDDM);
        public static DataTable GZD()
        {
            return dt_gzddm;
        }
        private static Hashtable ht_gzddm = FromZDDataTableToHashTable(dt_gzddm);
        public static Struct_ZD GZDByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_gzddm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

    */
        #region  ===============zzmmdm   政治面貌================
        private static DataTable dt_zzmm = InitZDData(ZdType.ZZMMDM);
        public static DataTable ZZMM()
        {
            return dt_zzmm;
        }
        private static Hashtable ht_zzmm = FromZDDataTableToHashTable(dt_zzmm);
        public static Struct_ZD ZZMMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zzmm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============htlxdm     合同类型================
        private static DataTable dt_htlxdm = InitZDData(ZdType.HTLXDM);
        public static DataTable HTLX()
        {
            return dt_htlxdm;
        }
        private static Hashtable ht_htlxdm = FromZDDataTableToHashTable(dt_htlxdm);
        public static Struct_ZD HTLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_htlxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============xldm 学历================
        private static DataTable dt_xldm = InitZDData(ZdType.XLDM);
        public static DataTable XL()
        {
            return dt_xldm;
        }
        private static Hashtable ht_xldm = FromZDDataTableToHashTable(dt_xldm);
        public static Struct_ZD XLByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_xldm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============wd1dm  维度1代码================
        private static DataTable dt_wd1dm = InitZDData(ZdType.WD1DM);
        public static DataTable WD1()
        {
            return dt_wd1dm;
        }
        private static Hashtable ht_wd1dm = FromZDDataTableToHashTable(dt_wd1dm);
        public static Struct_ZD WD1ByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wd1dm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============wd2dm  维度2代码================
        private static DataTable dt_wd2dm = InitZDData(ZdType.WD2DM);
        public static DataTable WD2()
        {
            return dt_wd2dm;
        }
        private static Hashtable ht_wd2dm = FromZDDataTableToHashTable(dt_wd2dm);
        public static Struct_ZD WD2ByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wd2dm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============wd3dm  维度3代码================
        private static DataTable dt_wd3dm = InitZDData(ZdType.WD3DM);
        public static DataTable WD3()
        {
            return dt_wd3dm;
        }
        private static Hashtable ht_wd3dm = FromZDDataTableToHashTable(dt_wd3dm);
        public static Struct_ZD WD3ByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wd3dm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============xzqhdm 行政区划================
        //private static DataTable dt_xzqh = InitZDData(ZdType.XZQH);
        //public static DataTable XZQH()
        //{
        //    return dt_xzqh;
        //}
        //private static Hashtable ht_xzqh = FromZDDataTableToHashTable(dt_xzqh);
        //public static Struct_ZD XZQHByKey(string key)   //根据键值,返回一个结构
        //{
        //    object obj = ht_xzqh[key];
        //    Struct_ZD struct_ZD = new Struct_ZD();
        //    struct_ZD.bm = key;
        //    return (obj != null ? (Struct_ZD)obj : struct_ZD);
        //}
        #endregion
        #region  ===============htgxdm 合同关系代码================
        private static DataTable dt_htgxdm = InitZDData(ZdType.HTGXDM);
        public static DataTable HTGX()
        {
            return dt_htgxdm;
        }
        private static Hashtable ht_htgxdm = FromZDDataTableToHashTable(dt_htgxdm);
        public static Struct_ZD HTGXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_htgxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============htqxdm 合同期限代码================
        private static DataTable dt_htqxdm = InitZDData(ZdType.HTQXDM);
        public static DataTable HTQX()
        {
            return dt_htqxdm;
        }
        private static Hashtable ht_htqxdm = FromZDDataTableToHashTable(dt_htqxdm);
        public static Struct_ZD HTQXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_htqxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ygztdm 员工状态代码================
        private static DataTable dt_ygztdm = InitZDData(ZdType.YGZTDM);
        public static DataTable YGZT()
        {
            return dt_ygztdm;
        }
        private static Hashtable ht_ygztdm = FromZDDataTableToHashTable(dt_ygztdm);
        public static Struct_ZD YGZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ygztdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============yhztdm 用户状态代码================
        private static DataTable dt_yhztdm = InitZDData(ZdType.YHZTDM);
        public static DataTable YHZT()
        {
            return dt_yhztdm;
        }
        private static Hashtable ht_yhztdm = FromZDDataTableToHashTable(dt_yhztdm);
        public static Struct_ZD YHZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_yhztdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============qzzy 签注专业代码================
        private static DataTable dt_qzzydm = InitZDData(ZdType.QZZYDM);
        public static DataTable QZZY()
        {
            return dt_qzzydm;
        }
        private static Hashtable ht_qzzydm = FromZDDataTableToHashTable(dt_qzzydm);
        public static Struct_ZD QZZYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_qzzydm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============wjlb 文件类别================
        private static DataTable dt_wjlb = InitZDData(ZdType.WJLB);
        public static DataTable WJLB()
        {
            return dt_wjlb;
        }
        private static Hashtable ht_wjlb = FromZDDataTableToHashTable(dt_wjlb);
        public static Struct_ZD WJLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wjlb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============sblx 设备类型================
        private static DataTable dt_sblx = InitZDData(ZdType.SBLX);
        public static DataTable SBLX()
        {
            return dt_sblx;
        }
        public static DataTable SBLX(string sbzl)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_sblx.Select("substring(bm,1,3) like'" + sbzl + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_sblx = FromZDDataTableToHashTable(dt_sblx);
        public static Struct_ZD SBLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sblx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zcjb";//职称级别================
        private static DataTable dt_zcjb = InitZDData(ZdType.ZCJB);
        public static DataTable ZCJB()
        {
            return dt_zcjb;
        }
        private static Hashtable ht_zcjb = FromZDDataTableToHashTable(dt_zcjb);
        public static Struct_ZD ZCJBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zcjb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zg";//资格================
        private static DataTable dt_zg = InitZDData(ZdType.ZG);
        public static DataTable ZG()
        {
            return dt_zg;
        }
        private static Hashtable ht_zg = FromZDDataTableToHashTable(dt_zg);
        public static Struct_ZD ZGByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zg[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="pr";//是否聘任================
        private static DataTable dt_pr = InitZDData(ZdType.PR);
        public static DataTable PR()
        {
            return dt_pr;
        }
        private static Hashtable ht_pr = FromZDDataTableToHashTable(dt_pr);
        public static Struct_ZD PRByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_pr[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============sfjb   是否具备（台站）================
        private static DataTable dt_sfjb = InitZDData(ZdType.SFJB);
        public static DataTable SFJB()
        {
            return dt_sfjb;
        }
        private static Hashtable ht_sfjb = FromZDDataTableToHashTable(dt_sfjb);
        public static Struct_ZD SFJBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sfjb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============jdfs";//检定方式================
        private static DataTable dt_jdfs = InitZDData(ZdType.JDFS);
        public static DataTable JDFS()
        {
            return dt_jdfs;
        }
        private static Hashtable ht_jdfs = FromZDDataTableToHashTable(dt_jdfs);
        public static Struct_ZD JDFSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jdfs[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="mhsblx";//灭火设备类型================
        private static DataTable dt_mhsblx = InitZDData(ZdType.MHSBLX);
        public static DataTable MHSBLX()
        {
            return dt_mhsblx;
        }
        private static Hashtable ht_mhsblx = FromZDDataTableToHashTable(dt_mhsblx);
        public static Struct_ZD MHSBLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_mhsblx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion





        #region  ==============="sbztdm";//设备状态代码================
        private static DataTable dt_sbztdm = InitZDData(ZdType.SBZTDM);
        public static DataTable SBZT()
        {
            return dt_sbztdm;
        }
        private static Hashtable ht_sbztdm = FromZDDataTableToHashTable(dt_sbztdm);
        public static Struct_ZD SBZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sbztdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="sblbdm";//设备类别代码================
        private static DataTable dt_sblbdm = InitZDData(ZdType.SBLBDM);
        public static DataTable SBLB()
        {
            return dt_sblbdm;
        }
        private static Hashtable ht_sblbdm = FromZDDataTableToHashTable(dt_sblbdm);
        public static Struct_ZD SBLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sblbdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="sbzl";//设备种类================
        private static DataTable dt_sbzl = InitZDData(ZdType.SBZL);
        public static DataTable SBZL()
        {
            return dt_sbzl;
        }
        public static DataTable SBZL(string sblx)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_sbzl.Select("bm like '" + sblx + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_sbzl = FromZDDataTableToHashTable(dt_sbzl);
        public static Struct_ZD SBZLByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sbzl[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ===============zdlx 站点类型================
        private static DataTable dt_zdlx = InitZDData(ZdType.ZDLX);
        public static DataTable ZDLX()
        {
            return dt_zdlx;
        }

        private static Hashtable ht_zdlx = FromZDDataTableToHashTable(dt_zdlx);
        public static Struct_ZD ZDLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zdlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============sbpz 设备配置================
        private static DataTable dt_sbpz = InitZDData(ZdType.SBPZ);
        public static DataTable SBPZ()
        {
            return dt_sbpz;
        }

        private static Hashtable ht_sbpz = FromZDDataTableToHashTable(dt_sbpz);
        public static Struct_ZD SBPZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sbpz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============mfcxy MFC协议================
        private static DataTable dt_mfcxy = InitZDData(ZdType.MFCXY);
        public static DataTable MFCXY()
        {
            return dt_mfcxy;
        }

        private static Hashtable ht_mfcxy = FromZDDataTableToHashTable(dt_mfcxy);
        public static Struct_ZD MFCXYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_mfcxy[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============qsigxy Q-SIG协议================
        private static DataTable dt_qsigxy = InitZDData(ZdType.QSIGXY);
        public static DataTable QSIGXY()
        {
            return dt_qsigxy;
        }

        private static Hashtable ht_qsigxy = FromZDDataTableToHashTable(dt_qsigxy);
        public static Struct_ZD QSIGXYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_qsigxy[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ipxy IP协议================
        private static DataTable dt_ipxy = InitZDData(ZdType.IPXY);
        public static DataTable IPXY()
        {
            return dt_ipxy;
        }

        private static Hashtable ht_ipxy = FromZDDataTableToHashTable(dt_ipxy);
        public static Struct_ZD IPXYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ipxy[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ===============pcxjjf 评测项加减分================
        private static DataTable dt_pcxjjf = InitZDData(ZdType.PCXJJF);
        public static DataTable PCXJJF()
        {
            return dt_pcxjjf;
        }

        private static Hashtable ht_pcxjjf = FromZDDataTableToHashTable(dt_pcxjjf);
        public static Struct_ZD PCXJJFByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_pcxjjf[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ===============ylxs  演练形式================
        private static DataTable dt_ylxs = InitZDData(ZdType.YLXS);
        public static DataTable YLXS()
        {
            return dt_ylxs;
        }
        private static Hashtable ht_ylxs = FromZDDataTableToHashTable(dt_ylxs);
        public static Struct_ZD YLXSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ylxs[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="tzlxdm";//台站类型代码================
        private static DataTable dt_tzlxdm = InitZDData(ZdType.TZLXDM);
        public static DataTable TZLX()
        {
            return dt_tzlxdm;
        }
        private static Hashtable ht_tzlxdm = FromZDDataTableToHashTable(dt_tzlxdm);
        public static Struct_ZD TZLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_tzlxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="sbytdm";//设备用途代码================
        private static DataTable dt_sbytdm = InitZDData(ZdType.SBYTDM);
        public static DataTable SBYT()
        {
            return dt_sbytdm;
        }
        private static Hashtable ht_sbytdm = FromZDDataTableToHashTable(dt_sbytdm);
        public static Struct_ZD SBYTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sbytdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="dwlxdm";//地网类型代码================
        private static DataTable dt_dwlxdm = InitZDData(ZdType.DWLXDM);
        public static DataTable DWLX()
        {
            return dt_dwlxdm;
        }
        private static Hashtable ht_dwlxdm = FromZDDataTableToHashTable(dt_dwlxdm);
        public static Struct_ZD DWLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_dwlxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fxxjdm";//飞行校检代码================
        private static DataTable dt_fxxjdm = InitZDData(ZdType.FXXJDM);
        public static DataTable FXXJ()
        {
            return dt_fxxjdm;
        }
        private static Hashtable ht_fxxjdm = FromZDDataTableToHashTable(dt_fxxjdm);
        public static Struct_ZD FXXJByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fxxjdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fgfwdm";//覆盖范围代码================
        private static DataTable dt_fgfwdm = InitZDData(ZdType.FGFWDM);
        public static DataTable FGFW()
        {
            return dt_fgfwdm;
        }
        private static Hashtable ht_fgfwdm = FromZDDataTableToHashTable(dt_fgfwdm);
        public static Struct_ZD FGFWByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fgfwdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="sfwxdsb";//是否无线电设备================
        private static DataTable dt_sfwxdsb = InitZDData(ZdType.SFWXDSB);
        public static DataTable SFWXDSB()
        {
            return dt_sfwxdsb;
        }
        private static Hashtable ht_sfwxdsb = FromZDDataTableToHashTable(dt_sfwxdsb);
        public static Struct_ZD SFWXDSBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sfwxdsb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="txfsdm";//通信方式代码================
        private static DataTable dt_txfsdm = InitZDData(ZdType.TXFSDM);
        public static DataTable TXFS()
        {
            return dt_txfsdm;
        }
        private static Hashtable ht_txfsdm = FromZDDataTableToHashTable(dt_txfsdm);
        public static Struct_ZD TXFSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_txfsdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="txlxdm";//天线类型代码================
        private static DataTable dt_txlxdm = InitZDData(ZdType.TXLXDM);
        public static DataTable TXLX()
        {
            return dt_txlxdm;
        }
        private static Hashtable ht_txlxdm = FromZDDataTableToHashTable(dt_txlxdm);
        public static Struct_ZD TXLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_txlxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============bslx  报送类型================
        private static DataTable dt_bslx = InitZDData(ZdType.BSLX);
        public static DataTable BSLX()
        {
            return dt_bslx;
        }
        private static Hashtable ht_bslx = FromZDDataTableToHashTable(dt_bslx);
        public static Struct_ZD BSLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bslx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zjlbdm";//专家类别代码================
        private static DataTable dt_zjlbdm = InitZDData(ZdType.ZJLBDM);
        public static DataTable ZJLB()
        {
            return dt_zjlbdm;
        }
        private static Hashtable ht_zjlbdm = FromZDDataTableToHashTable(dt_zjlbdm);
        public static Struct_ZD ZJLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zjlbdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zjssdm";//专家所属代码================
        private static DataTable dt_zjssdm = InitZDData(ZdType.ZJSSDM);
        public static DataTable ZJSS()
        {
            return dt_zjssdm;
        }
        private static Hashtable ht_zjssdm = FromZDDataTableToHashTable(dt_zjssdm);
        public static Struct_ZD ZJSSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zjssdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============wdlx";//文档类型================
        private static DataTable dt_wdlx = InitZDData(ZdType.WDLX);
        public static DataTable WDLX()
        {
            return dt_wdlx;
        }
        private static Hashtable ht_wdlx = FromZDDataTableToHashTable(dt_wdlx);
        public static Struct_ZD WDLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wdlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============allx";//案例类型================
        private static DataTable dt_allx = InitZDData(ZdType.ALLX);
        public static DataTable ALLX()
        {
            return dt_allx;
        }
        private static Hashtable ht_allx = FromZDDataTableToHashTable(dt_allx);
        public static Struct_ZD ALLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_allx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============fxdj";//风险等级================
        private static DataTable dt_fxdj = InitZDData(ZdType.FXDJ);
        public static DataTable FXDJ()
        {
            return dt_fxdj;
        }
        private static Hashtable ht_fxdj = FromZDDataTableToHashTable(dt_fxdj);
        public static Struct_ZD FXDJByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fxdj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="bjlxdm";//备件类型代码================
        private static DataTable dt_bjlxdm = InitZDData(ZdType.BJLXDM);
        public static DataTable BJLX()
        {
            return dt_bjlxdm;
        }
        private static Hashtable ht_bjlxdm = FromZDDataTableToHashTable(dt_bjlxdm);
        public static Struct_ZD BJLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bjlxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="bjsy";//备件适用================
        private static DataTable dt_bjsy = InitZDData(ZdType.BJSY);
        public static DataTable BJSY()
        {
            return dt_bjsy;
        }
        private static Hashtable ht_bjsy = FromZDDataTableToHashTable(dt_bjsy);
        public static Struct_ZD BJSYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bjsy[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="whztdm";//维护状态代码================
        private static DataTable dt_whztdm = InitZDData(ZdType.WHZTDM);
        public static DataTable WHZT()
        {
            return dt_whztdm;
        }
        private static Hashtable ht_whztdm = FromZDDataTableToHashTable(dt_whztdm);
        public static Struct_ZD WHZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_whztdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="hblxdm";//航班类型代码================
        private static DataTable dt_hblxdm = InitZDData(ZdType.HBLXDM);
        public static DataTable HBLX()
        {
            return dt_hblxdm;
        }
        private static Hashtable ht_hblxdm = FromZDDataTableToHashTable(dt_hblxdm);
        public static Struct_ZD HBLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_hblxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion


        #region  ==============="zxdm";//支线代码================
        private static DataTable dt_zxdm = InitZDData(ZdType.ZXDM);
        public static DataTable ZXDM()
        {
            return dt_zxdm;
        }
        private static Hashtable ht_zxdm = FromZDDataTableToHashTable(dt_zxdm);
        public static Struct_ZD ZXDMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="sbwz";//设备位置================
        private static DataTable dt_sbwz = InitZDData(ZdType.SBWZ);
        public static DataTable SBWZ()
        {
            return dt_sbwz;
        }
        private static Hashtable ht_sbwz = FromZDDataTableToHashTable(dt_sbwz);
        public static Struct_ZD SBWZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sbwz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="wxlb";//维修类别================
        private static DataTable dt_wxlb = InitZDData(ZdType.WXLB);
        public static DataTable WXLB()
        {
            return dt_wxlb;
        }
        private static Hashtable ht_wxlb = FromZDDataTableToHashTable(dt_wxlb);
        public static Struct_ZD WXLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wxlb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="wxyfc";//危险源范畴================
        private static DataTable dt_wxyfc = InitZDData(ZdType.WXYFC);
        public static DataTable WXYFC()
        {
            return dt_wxyfc;
        }
        private static Hashtable ht_wxyfc = FromZDDataTableToHashTable(dt_wxyfc);
        public static Struct_ZD WXYFCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wxyfc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============STDM = "stdm";//时态代码================
        private static DataTable dt_stdm = InitZDData(ZdType.STDM);
        public static DataTable STDM()
        {
            return dt_stdm;
        }
        private static Hashtable ht_stdm = FromZDDataTableToHashTable(dt_stdm);
        public static Struct_ZD STDMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_stdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fxyzt";//风险源状态================
        private static DataTable dt_fxyzt = InitZDData(ZdType.FXYZT);
        public static DataTable FXYZT()
        {
            return dt_fxyzt;
        }
        private static Hashtable ht_fxyzt = FromZDDataTableToHashTable(dt_fxyzt);
        public static Struct_ZD FXYZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fxyzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fxfskn";//风险发生可能================
        private static DataTable dt_fxfskn = InitZDData(ZdType.FXFSKN);
        public static DataTable FXFSKN()
        {
            return dt_fxfskn;
        }
        private static Hashtable ht_fxfskn = FromZDDataTableToHashTable(dt_fxfskn);
        public static Struct_ZD FXFSKNByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fxfskn[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fxcd";//风险程度================
        private static DataTable dt_fxcd = InitZDData(ZdType.FXCD);
        public static DataTable FXCD()
        {
            return dt_fxcd;
        }
        private static Hashtable ht_fxcd = FromZDDataTableToHashTable(dt_fxcd);
        public static Struct_ZD FXCDByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fxcd[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fxkzzt";//后果的严重程度================
        private static DataTable dt_yzcd = InitZDData(ZdType.YZCD);
        public static DataTable YZCD()
        {
            return dt_yzcd;
        }
        private static Hashtable ht_yzcd = FromZDDataTableToHashTable(dt_yzcd);
        public static Struct_ZD YZCDByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_yzcd[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fxkzzt";//风险控制状态================
        private static DataTable dt_fxkzzt = InitZDData(ZdType.FXKZZT);
        public static DataTable FXKZZT()
        {
            return dt_fxkzzt;
        }
        private static Hashtable ht_fxkzzt = FromZDDataTableToHashTable(dt_fxkzzt);
        public static Struct_ZD FXKZZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fxkzzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fxkzbz";//风险控制标准================
        private static DataTable dt_fxkzbz = InitZDData(ZdType.FXKZBZ);
        public static DataTable FXKZBZ()
        {
            return dt_fxkzbz;
        }
        private static Hashtable ht_fxkzbz = FromZDDataTableToHashTable(dt_fxkzbz);
        public static Struct_ZD FXKZBZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fxkzbz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zcly";//资产来源================
        private static DataTable dt_zcly = InitZDData(ZdType.ZCLY);
        public static DataTable ZCLY()
        {
            return dt_zcly;
        }
        private static Hashtable ht_zcly = FromZDDataTableToHashTable(dt_zcly);
        public static Struct_ZD ZCLYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zcly[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="rzxs";//入账形式================
        private static DataTable dt_rzxs = InitZDData(ZdType.RZXS);
        public static DataTable RZXS()
        {
            return dt_rzxs;
        }
        private static Hashtable ht_rzxs = FromZDDataTableToHashTable(dt_rzxs);
        public static Struct_ZD RZXSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_rzxs[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="sfwc";//是否完成================
        private static DataTable dt_sfwc = InitZDData(ZdType.SFWC);
        public static DataTable SFWC()
        {
            return dt_sfwc;
        }
        private static Hashtable ht_sfwc = FromZDDataTableToHashTable(dt_sfwc);
        public static Struct_ZD SFWCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sfwc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="rzlx";//日志类型================
        private static DataTable dt_rzlx = InitZDData(ZdType.RZLX);
        public static DataTable RZLX()
        {
            return dt_rzlx;
        }
        private static Hashtable ht_rzlx = FromZDDataTableToHashTable(dt_rzlx);
        public static Struct_ZD RZLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_rzlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============WPLBDM = "wplbdm";//物品类别代码================
        private static DataTable dt_wplbdm = InitZDData(ZdType.WPLBDM);
        public static DataTable WPLB()
        {
            return dt_wplbdm;
        }
        private static Hashtable ht_wplbdm = FromZDDataTableToHashTable(dt_wplbdm);
        public static Struct_ZD WPLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wplbdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="shztdm";//审核状态代码================
        private static DataTable dt_shztdm = InitZDData(ZdType.SHZTDM);
        public static DataTable SHZT()
        {
            return dt_shztdm;
        }
        private static Hashtable ht_shztdm = FromZDDataTableToHashTable(dt_shztdm);
        public static Struct_ZD SHZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_shztdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zzqzlbdm";//执照签注类别代码================
        private static DataTable dt_zzqzlbdm = InitZDData(ZdType.ZZQZLBDM);
        public static DataTable ZZQZLBDM()
        {
            return dt_zzqzlbdm;
        }
        private static Hashtable ht_zzqzlbdm = FromZDDataTableToHashTable(dt_zzqzlbdm);
        public static Struct_ZD ZZQZLBDMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zzqzlbdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zzqzxdm";//执照签注项代码================
        private static DataTable dt_zzqzxdm = InitZDData(ZdType.ZZQZXDM);
        public static DataTable ZZQZXDM()
        {
            return dt_zzqzxdm;
        }
        private static Hashtable ht_zzqzxdm = FromZDDataTableToHashTable(dt_zzqzxdm);
        public static Struct_ZD ZZQZXDMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zzqzxdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="zzzt";//资质状态================
        private static DataTable dt_zzzt = InitZDData(ZdType.ZZZT);
        public static DataTable ZZZT()
        {
            return dt_zzzt;
        }
        private static Hashtable ht_zzzt = FromZDDataTableToHashTable(dt_zzzt);
        public static Struct_ZD ZZZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zzzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="gglx";//公告类型================
        private static DataTable dt_gglx = InitZDData(ZdType.GGLX);
        public static DataTable GGLX()
        {
            return dt_gglx;
        }
        private static Hashtable ht_gglx = FromZDDataTableToHashTable(dt_gglx);
        public static Struct_ZD GGLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_gglx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ZYMC 专业名称================
        private static DataTable dt_zymc = InitZDData(ZdType.ZYMC);
        public static DataTable ZYMC()
        {
            return dt_zymc;
        }
        private static Hashtable ht_zymc = FromZDDataTableToHashTable(dt_zymc);
        public static Struct_ZD ZYMCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zymc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ZYMC 职称名称================
        private static DataTable dt_zcmc = InitZDData(ZdType.ZCMC);
        public static DataTable ZCMC()
        {
            return dt_zcmc;
        }
        public static DataTable ZCMC(string zymc)
        {
            DataTable dt = new DataTable();
            zymc = zymc.Substring(0, 2);
            DataRow[] rows = dt_zcmc.Select("substring(bm,1,2) like '" + zymc + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_zcmc = FromZDDataTableToHashTable(dt_zcmc);
        public static Struct_ZD ZCMCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zcmc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ZCDJ//职称等级================
        private static DataTable dt_zcdj = InitZDData(ZdType.ZCDJ);
        public static DataTable ZCDJ()
        {
            return dt_zcdj;
        }
        private static Hashtable ht_zcdj = FromZDDataTableToHashTable(dt_zcdj);
        public static Struct_ZD ZCDJByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zcdj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============JNMC //技能名称================
        private static DataTable dt_jnmc = InitZDData(ZdType.JNMC);
        public static DataTable JNMC()
        {
            return dt_jnmc;
        }
        private static Hashtable ht_jnmc = FromZDDataTableToHashTable(dt_jnmc);
        public static Struct_ZD JNMCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jnmc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============JNDJ//技能等级================
        private static DataTable dt_jndj = InitZDData(ZdType.JNDJ);
        public static DataTable JNDJ()
        {
            return dt_jndj;
        }
        public static DataTable JNDJ(string jnmc)
        {
            DataTable dt = new DataTable();
            jnmc = jnmc.Substring(0, 1);
            DataRow[] rows = dt_jndj.Select("substring(bm,1,1) like '" + jnmc + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_jndj = FromZDDataTableToHashTable(dt_jndj);
        public static Struct_ZD JNDJByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jndj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============BMZT//部门状态================
        private static DataTable dt_bmzt = InitZDData(ZdType.BMZT);
        public static DataTable BMZT()
        {
            return dt_bmzt;
        }
        private static Hashtable ht_bmzt = FromZDDataTableToHashTable(dt_bmzt);
        public static Struct_ZD BMZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bmzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============YXQK//运行情况================
        private static DataTable dt_yxqk = InitZDData(ZdType.YXQK);
        public static DataTable YXQK()
        {
            return dt_yxqk;
        }
        private static Hashtable ht_yxqk = FromZDDataTableToHashTable(dt_yxqk);
        public static Struct_ZD YXQKByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_yxqk[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============bzqk保障情况================
        private static DataTable dt_bzqk = InitZDData(ZdType.BZQK);
        public static DataTable BZQK()
        {
            return dt_bzqk;
        }
        private static Hashtable ht_bzqk = FromZDDataTableToHashTable(dt_bzqk);
        public static Struct_ZD BZQKByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bzqk[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============GZYYDM = "gzyydm";//故障原因代码================
        private static DataTable dt_gzyy = InitZDData(ZdType.GZYYDM);
        public static DataTable GZYY()
        {
            return dt_gzyy;
        }
        private static Hashtable ht_gzyy = FromZDDataTableToHashTable(dt_gzyy);
        public static Struct_ZD GZYYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_gzyy[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============WXDGRLX = "wxdgrlx";//无线电干扰类型================
        private static DataTable dt_wxdgrlx = InitZDData(ZdType.WXDGRLX);
        public static DataTable WXDGRLX()
        {
            return dt_wxdgrlx;
        }
        private static Hashtable ht_wxdgrlx = FromZDDataTableToHashTable(dt_wxdgrlx);
        public static Struct_ZD WXDGRLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wxdgrlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============JHXTJYY = "jhxtjyy";//计划性停机原因================
        private static DataTable dt_jhxtjyy = InitZDData(ZdType.JHXTJYY);
        public static DataTable JHXTJYY()
        {
            return dt_jhxtjyy;
        }
        private static Hashtable ht_jhxtjyy = FromZDDataTableToHashTable(dt_jhxtjyy);
        public static Struct_ZD JHXTJYYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jhxtjyy[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  =============== //保养频次================
        private static DataTable dt_bypc = InitZDData(ZdType.BYPC);
        public static DataTable BYPC()
        {
            return dt_bypc;
        }
        private static Hashtable ht_bypc = FromZDDataTableToHashTable(dt_bypc);
        public static Struct_ZD BYPCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bypc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============HTZT="htzt" //合同状态================
        private static DataTable dt_htzt = InitZDData(ZdType.HTZT);
        public static DataTable HTZT()
        {
            return dt_htzt;
        }
        private static Hashtable ht_htzt = FromZDDataTableToHashTable(dt_htzt);
        public static Struct_ZD HTZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_htzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion



        #region  ==============="tbdw";//填报单位================
        private static DataTable dt_tbdw = InitZDData(ZdType.TBDW);
        public static DataTable TBDW()
        {
            return dt_tbdw;
        }
        private static Hashtable ht_tbdw = FromZDDataTableToHashTable(dt_tbdw);
        public static Struct_ZD TBDWByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_tbdw[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="jcrwzt";//检查任务状态================
        private static DataTable dt_jcrwzt = InitZDData(ZdType.jcrwzt);
        public static DataTable JCRWZT()
        {
            return dt_jcrwzt;
        }
        private static Hashtable ht_jcrwzt = FromZDDataTableToHashTable(dt_jcrwzt);
        public static Struct_ZD JCRWZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jcrwzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="jcjg";//检查结果================
        private static DataTable dt_jcjg = InitZDData(ZdType.JCJG);
        public static DataTable JCJG()
        {
            return dt_jcjg;
        }
        private static Hashtable ht_jcjg = FromZDDataTableToHashTable(dt_jcjg);
        public static Struct_ZD JCJGByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jcjg[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #region  ==============="zgzt";//整改状态================
        private static DataTable dt_zgzt = InitZDData(ZdType.ZGZT);
        public static DataTable ZGZT()
        {
            return dt_zgzt;
        }
        private static Hashtable ht_zgzt = FromZDDataTableToHashTable(dt_zgzt);
        public static Struct_ZD ZGZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zgzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="bjbs";//比较标识================
        private static DataTable dt_bjbs = InitZDData(ZdType.BJBS);
        public static DataTable BJBS()
        {
            return dt_bjbs;
        }
        private static Hashtable ht_bjbs = FromZDDataTableToHashTable(dt_bjbs);
        public static Struct_ZD BJBSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_bjbs[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion



        private static DataTable InitZDData_tzlx()//台站名称获取专用（放在工具中的InitZDData下面）
        {
            lock (typeof(SysData))
            {
                DBClass dbc = new DBClass();
                try
                {
                    OracleParameter[] opara ={
                                             new OracleParameter("p_mycur",OracleType.Cursor)
                                         };
                    opara[0].Direction = ParameterDirection.Output;
                    DataSet ds = dbc.RunProcedure("PACK_SYS.Sys_ZD_selectByZDM_tzlx", opara, "table");
                    return ds.Tables[0];
                }
                finally
                {
                    dbc.Close();
                }
            }
        }



        #region  ==============="tzlxzhmcdm";//台站类型组合代码================
        private static DataTable dt_tzlxzhmcdm = InitZDData_tzlx();
        public static DataTable TZLX_ZH(string sblx)
        {
            DataTable dt = new DataTable();
            DataRow[] rows_sblx = dt_tzlxzhmcdm.Select("sblx like'" + sblx + "%'");
            return (ToDataTable(rows_sblx) != null ? ToDataTable(rows_sblx) : dt);
        }
        public static DataTable TZLX_ZH(string jc, string sblx)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_tzlxzhmcdm.Select("jc like'" + jc + "%' and sblx like'" + sblx + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        #endregion        #region  ===============YGXS="ygxs" //用工形式================
        private static DataTable dt_ygxs = InitZDData(ZdType.YGXS);
        public static DataTable YGXS()
        {
            return dt_ygxs;
        }
        private static Hashtable ht_ygxs = FromZDDataTableToHashTable(dt_ygxs);
        public static Struct_ZD YGXSByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ygxs[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============DZZMC="dzzmc" //党组织名称================
        private static DataTable dt_dzzmc = InitZDData(ZdType.DZZMC);
        public static DataTable DZZMC()
        {
            return dt_dzzmc;
        }
        private static Hashtable ht_dzzmc = FromZDDataTableToHashTable(dt_dzzmc);
        public static Struct_ZD DZZMCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_dzzmc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============JCDZBMC="jcdzbmc" //基层党支部名称================
        private static DataTable dt_jcdzbmc = InitZDData(ZdType.JCDZBMC);
        public static DataTable JCDZBMC()
        {
            return dt_jcdzbmc;
        }
        private static Hashtable ht_jcdzbmc = FromZDDataTableToHashTable(dt_jcdzbmc);
        public static Struct_ZD JCDZBMCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jcdzbmc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============DXZMC="dxzmc" //党小组名称================
        private static DataTable dt_dxzmc = InitZDData(ZdType.DXZMC);
        public static DataTable DXZMC()
        {
            return dt_dxzmc;
        }
        public static DataTable DXZMC(string jcdzbmc)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_dxzmc.Select("bm like '" + jcdzbmc + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_dxzmc = FromZDDataTableToHashTable(dt_dxzmc);
        public static Struct_ZD DXZMCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_dxzmc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============STND 试题难度================
        private static DataTable dt_stnd = InitZDData(ZdType.STND);
        public static DataTable STND()
        {
            return dt_stnd;
        }
        private static Hashtable ht_stnd = FromZDDataTableToHashTable(dt_stnd);
        public static Struct_ZD STNDByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_stnd[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  =============== STLX 试题类型================
        private static DataTable dt_stlx = InitZDData(ZdType.STLX);
        public static DataTable STLX()
        {
            return dt_stlx;
        }
        private static Hashtable ht_stlx = FromZDDataTableToHashTable(dt_stlx);
        public static Struct_ZD STLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_stlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  =============== STLB 试题类别================
        private static DataTable dt_stlb = InitZDData(ZdType.STLB);
        public static DataTable STLB()
        {
            return dt_stlb;
        }
        private static Hashtable ht_stlb = FromZDDataTableToHashTable(dt_stlb);
        public static Struct_ZD STLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_stlb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  =============== STZT 试题状态================
        private static DataTable dt_stzt = InitZDData(ZdType.STZT);
        public static DataTable STZT()
        {
            return dt_stzt;
        }
        private static Hashtable ht_stzt = FromZDDataTableToHashTable(dt_stzt);
        public static Struct_ZD STZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_stzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============KM 科目================
        private static DataTable dt_km = InitZDData(ZdType.KM);
        public static DataTable KM()
        {
            return dt_km;
        }
        private static Hashtable ht_km = FromZDDataTableToHashTable(dt_km);
        public static Struct_ZD KMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_km[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ZT 状态================
        private static DataTable dt_zt = InitZDData(ZdType.ZTDM);
        public static DataTable ZTDM()
        {
            return dt_zt;
        }
        private static Hashtable ht_zt = FromZDDataTableToHashTable(dt_zt);
        public static Struct_ZD ZTDMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============sfdb   是否待办================
        private static DataTable dt_sfdb = InitZDData(ZdType.SFDB);
        public static DataTable SFDB()
        {
            return dt_sfdb;
        }
        private static Hashtable ht_sfdb = FromZDDataTableToHashTable(dt_sfdb);
        public static Struct_ZD SFDBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sfdb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region======民族状态=====
        private static Hashtable InitMZZT()
        {
            lock (typeof(SysData))
            {
                Hashtable mzzt = new Hashtable();
                mzzt.Add("0", "汉族");
                mzzt.Add("1", "非汉族");
                return mzzt;
            }
        }
        private static Hashtable ht_mzzt = InitMZZT();
        public static string MZZTByKey(string key)
        {
            object obj = ht_mzzt[key];
            return (obj != null ? (string)obj : key.ToString());
        }
        private static DataTable dt_mzzt = FromHashTableToDataTable(ht_mzzt);
        public static DataTable MZZT()
        {
            return dt_mzzt;
        }
        #endregion
        #region  ===============yhlbdm 用户类别================
        private static DataTable dt_yhlbdm = InitZDData(ZdType.YHLBDM);
        public static DataTable YHLB()
        {
            return dt_yhlbdm;
        }
        private static Hashtable ht_yhlbdm = FromZDDataTableToHashTable(dt_yhlbdm);
        public static Struct_ZD YHLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_yhlbdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region======是否启用=====
        private static Hashtable InitSFQY()
        {
            lock (typeof(SysData))
            {
                Hashtable sfqy = new Hashtable();
                sfqy.Add("0", "[0]禁用");
                sfqy.Add("1", "[1]启用");
                return sfqy;
            }
        }
        private static Hashtable ht_sfqy = InitSFQY();
        public static string SFQYByKey(string key)
        {
            object obj = ht_sfqy[key];
            return (obj != null ? (string)obj : key.ToString());
        }
        private static DataTable dt_sfqy = FromHashTableToDataTable(ht_sfqy);
        public static DataTable SFQY()
        {
            return dt_sfqy;
        }
        #endregion
        #region======是否是管理用户=====
        private static Hashtable InitSFSGLYH()
        {
            lock (typeof(SysData))
            {
                Hashtable sfsglyh = new Hashtable();
                sfsglyh.Add("0", "[0]普通员工");
                sfsglyh.Add("1", "[1]管理用户");
                return sfsglyh;
            }
        }
        private static Hashtable ht_sfsglyh = InitSFSGLYH();
        public static string SFSGLYHByKey(string key)
        {
            object obj = ht_sfsglyh[key];
            return (obj != null ? (string)obj : key.ToString());
        }
        private static DataTable dt_sfsglyh = FromHashTableToDataTable(ht_sfsglyh);
        public static DataTable SFSGLYH()
        {
            return dt_sfsglyh;
        }
        #endregion
        #region======工作内容状态=====
        private static Hashtable InitGZNRZT()
        {
            lock (typeof(SysData))
            {
                Hashtable zt = new Hashtable();
                zt.Add("0", "[0]保存");
                zt.Add("1", "[1]提交");
                zt.Add("2", "[2]已评");
                return zt;
            }
        }
        private static Hashtable ht_gznrzt = InitGZNRZT();
        public static string GZNRZTByKey(int key)
        {
            object obj = ht_gznrzt[key];
            return (obj != null ? (string)obj : key.ToString());
        }
        public static string GZNRZTByKey(string key)
        {
            object obj = ht_gznrzt[key];
            return (obj != null ? (string)obj : key.ToString());
        }
        private static DataTable dt_gznrzt = FromHashTableToDataTable(ht_gznrzt);
        public static DataTable GZNRZT()
        {
            return dt_gznrzt;
        }
        #endregion
        #region  =============== //整改关闭批准================
        private static DataTable dt_zggbpz = InitZDData(ZdType.ZGGBPZ);
        public static DataTable ZGGBPZ()
        {
            return dt_zggbpz;
        }
        private static Hashtable ht_zggbpz = FromZDDataTableToHashTable(dt_zggbpz);
        public static Struct_ZD ZGGBPZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zggbpz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion


        #region  =============== //隐患等级================
        private static DataTable dt_yhdj = InitZDData(ZdType.YHDJ);
        public static DataTable YHDJ()
        {
            return dt_yhdj;
        }
        private static Hashtable ht_yhdj = FromZDDataTableToHashTable(dt_yhdj);
        public static Struct_ZD YHDJByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_yhdj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  =============== //来源================
        private static DataTable dt_ly = InitZDData(ZdType.LY);
        public static DataTable LY()
        {
            return dt_ly;
        }
        private static Hashtable ht_ly = FromZDDataTableToHashTable(dt_ly);
        public static Struct_ZD LYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ly[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion


        #region =============查询审批人===================

        private static DataTable dt_spr = Select_SPR_ALL();

        //查询所有子系统审批人
        private static DataTable Select_SPR_ALL()
        {
            DataTable dt_spr = new DataTable();
            DBClass db_spr = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_cur", OracleType.Cursor)

                        };
                paras_qx[0].Direction = ParameterDirection.Output;
                dt_spr = db_spr.RunProcedure("PACK_KG_YGJL.Select_SPR_Pro", paras_qx, "table").Tables[0];
                return dt_spr;
            }
            finally
            {
                db_spr.Close();
            }
        }

        private static DataTable Select_SPR_ALL(int p_userid, string p_qxdm)
        {
            DataTable dt_spr = new DataTable();
            DBClass db_spr = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_userid", OracleType.Int32),
                            new OracleParameter("p_qxdm", OracleType.VarChar),
                            new OracleParameter("p_cur", OracleType.Cursor)

                        };
                paras_qx[0].Value = p_userid;
                paras_qx[1].Value = p_qxdm;
                paras_qx[2].Direction = ParameterDirection.Output;
                dt_spr = db_spr.RunProcedure("PACK_KG_YGJL.Select_SPR_Pro_BYID", paras_qx, "table").Tables[0];
                return dt_spr;
            }
            finally
            {
                db_spr.Close();
            }
        }
        //查询对应子系统的审批人
        public static DataTable HasThisZXT_SPR(string zxtdm)
        {
            dt_spr = Select_SPR_ALL();
            if (dt_spr.Rows.Count == 0)
            {
                return new DataTable();
            }
            else
            {
                DataTable dt = new DataTable();

                DataRow[] dr = dt_spr.Select("zxtdm='" + zxtdm + "'");
                if (dr.Length == 0)
                {
                    return new DataTable();
                }
                else
                {
                    dt = dr[0].Table.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt.ImportRow((DataRow)dr[i]);
                    }
                }
                return dt;
            }
        }

        public static DataTable HasThisZXT_SPR(string zxtdm, int p_userid, string p_qxdm)
        {
            dt_spr = Select_SPR_ALL(p_userid, p_qxdm);
            if (dt_spr.Rows.Count == 0)
            {
                return new DataTable();
            }
            else
            {
                DataTable dt = new DataTable();

                DataRow[] dr = dt_spr.Select("zxtdm='" + zxtdm + "'");
                if (dr.Length == 0)
                {
                    return new DataTable();
                }
                else
                {
                    dt = dr[0].Table.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt.ImportRow((DataRow)dr[i]);
                    }
                }
                return dt;
            }
        }
        #endregion



        #region  ==============="zzqk";//专家情况代码================
        private static DataTable dt_zzqk = InitZDData(ZdType.ZZQK);
        public static DataTable ZZQK()
        {
            return dt_zzqk;
        }
        private static Hashtable ht_zzqk = FromZDDataTableToHashTable(dt_zzqk);
        public static Struct_ZD ZZQKByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zzqk[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="dylx";//党员类型代码================
        private static DataTable dt_dylx = InitZDData(ZdType.DYLX);
        public static DataTable DYLX()
        {
            return dt_dylx;
        }
        private static Hashtable ht_dylx = FromZDDataTableToHashTable(dt_dylx);
        public static Struct_ZD DYLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_dylx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion


        #region =============提示审批人待办事项===================

        //添加待审批事项
        public static void Insert_TSR(string p_ygbh, string p_zxt, string p_zxtmk, int p_dspxid)
        {
            DBClass db_tsr = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_ygbh", OracleType.VarChar),//员工编号
                            new OracleParameter("p_zxt", OracleType.VarChar),//子系统
                            new OracleParameter("p_zxtmk", OracleType.VarChar),//子系统模块，比如员工下的员工奖励
                            new OracleParameter("p_dspxid", OracleType.Number),//待审批项id
                            new OracleParameter("p_errorCode",OracleType.Int32)
                        };
                paras_qx[0].Value = p_ygbh;
                paras_qx[1].Value = p_zxt;
                paras_qx[2].Value = p_zxtmk;
                paras_qx[3].Value = p_dspxid;
                paras_qx[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                db_tsr.RunProcedure("PACK_HTGL_HT.Insert_TSR", paras_qx, out reslut);

                int returnCode = Convert.ToInt32(paras_qx[4].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
            }
            finally
            {
                db_tsr.Close();
            }
        }

        //删除待审批事项
        public static void Delete_TSR(string p_ygbh, string p_zxt, string p_zxtmk, int p_dspxid)
        {
            DBClass db_tsr = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_ygbh", OracleType.VarChar),//员工编号
                            new OracleParameter("p_zxt", OracleType.VarChar),//子系统
                            new OracleParameter("p_zxtmk", OracleType.VarChar),//子系统模块，比如员工下的员工奖励
                            new OracleParameter("p_dspxid", OracleType.Number),//待审批项id
                            new OracleParameter("p_errorCode",OracleType.Int32)
                        };
                paras_qx[0].Value = p_ygbh;
                paras_qx[1].Value = p_zxt;
                paras_qx[2].Value = p_zxtmk;
                paras_qx[3].Value = p_dspxid;
                paras_qx[4].Direction = ParameterDirection.Output;
                int reslut = 0;
                db_tsr.RunProcedure("PACK_HTGL_HT.Delete_TSR", paras_qx, out reslut);

                int returnCode = Convert.ToInt32(paras_qx[4].Value);
                if (returnCode != 0)
                {
                    throw new EMException(returnCode);
                }
            }
            finally
            {
                db_tsr.Close();
            }
        }

        //查询待审批事项
        public static DataTable Select_TSR(string ygbh)
        {
            DataTable dt_tsr = new DataTable();
            DBClass db_tsr = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_ygbh", OracleType.VarChar),
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };
                paras_qx[0].Value = ygbh;//员工编号
                paras_qx[1].Direction = ParameterDirection.Output;
                dt_tsr = db_tsr.RunProcedure("PACK_HTGL_HT.Select_HT_TSRDBSX", paras_qx, "table").Tables[0];
                return dt_tsr;
            }
            finally
            {
                db_tsr.Close();
            }
        }

        //查询该模块下待审批的数据个数
        public static DataTable Select_TSR_MK(string ygbh, string zxtmk)
        {
            DataTable dt_tsr = new DataTable();
            DBClass db_tsr = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_ygbh", OracleType.VarChar),
                            new OracleParameter("p_zxtmk", OracleType.VarChar),
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };

                paras_qx[0].Value = ygbh;//员工编号
                paras_qx[1].Value = zxtmk;//子系统
                paras_qx[2].Direction = ParameterDirection.Output;
                dt_spr = db_tsr.RunProcedure("PACK_HTGL_HT.Select_HT_TSRDBSX_BYZXTMK", paras_qx, "table").Tables[0];
                return dt_spr;
            }
            finally
            {
                db_tsr.Close();
            }
        }

        #endregion


        #region  ===============zxtdm   子系统代码================
        private static DataTable dt_zxtdm = InitZDData(ZdType.ZXTDM);
        public static DataTable ZXTDM()
        {
            return dt_zxtdm;
        }
        private static Hashtable ht_zxtdm = FromZDDataTableToHashTable(dt_zxtdm);
        public static Struct_ZD ZXTDMByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zxtdm[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============sjfc 涉及范畴================
        private static DataTable dt_sjfc = InitZDData(ZdType.SJFC);
        public static DataTable SJFC()
        {
            return dt_sjfc;
        }
        private static Hashtable ht_sjfc = FromZDDataTableToHashTable(dt_sjfc);
        public static Struct_ZD SJFCByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sjfc[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============hgyzx 后果严重程度================
        private static DataTable dt_hgyzx = InitZDData(ZdType.HGYZX);
        public static DataTable HGYZX()
        {
            return dt_hgyzx;
        }
        private static Hashtable ht_hgyzx = FromZDDataTableToHashTable(dt_hgyzx);
        public static Struct_ZD HGYZXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_hgyzx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============wxcd 危险程度================
        private static DataTable dt_wxcd = InitZDData(ZdType.WXCD);
        public static DataTable WXCD()
        {
            return dt_wxcd;
        }
        private static Hashtable ht_wxcd = FromZDDataTableToHashTable(dt_wxcd);
        public static Struct_ZD WXCDByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wxcd[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }



        #endregion
        #region  ===============aqzt 安全状态================
        private static DataTable dt_aqzt = InitZDData(ZdType.AQZT);
        public static DataTable AQZT()
        {
            return dt_aqzt;
        }
        private static Hashtable ht_aqzt = FromZDDataTableToHashTable(dt_aqzt);
        public static Struct_ZD AQZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_aqzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============zgcsbzhqk 整改措施标准化情况================
        private static DataTable dt_zgcsbzhqk = InitZDData(ZdType.ZGCSBZHQK);
        public static DataTable ZGCSBZHQK()
        {
            return dt_zgcsbzhqk;
        }
        private static Hashtable ht_zgcsbzhqk = FromZDDataTableToHashTable(dt_zgcsbzhqk);
        public static Struct_ZD ZGCSBZHQKByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zgcsbzhqk[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============wtzt 问题状态================
        private static DataTable dt_wtzt = InitZDData(ZdType.WTZT);
        public static DataTable WTZT()
        {
            return dt_wtzt;
        }
        private static Hashtable ht_wtzt = FromZDDataTableToHashTable(dt_wtzt);
        public static Struct_ZD WTZTByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_wtzt[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion




        #region =============查询是否是管理用户且是权限用户===================

        private static DataTable dt_gly = Select_GLY_ALL();

        //查询所有的管理用户
        private static DataTable Select_GLY_ALL()
        {
            DataTable dt_gly = new DataTable();
            DBClass db_gly = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };
                paras_qx[0].Direction = ParameterDirection.Output;
                dt_gly = db_gly.RunProcedure("PACK_KG_YGJL.Select_QXYH", paras_qx, "table").Tables[0];
                return dt_gly;
            }
            finally
            {
                db_gly.Close();
            }
        }

        //判断该用户是否是管理员
        public static bool SFS_GLY(string zh)
        {
            if (dt_gly.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_gly.Select("zh = " + "'" + zh + "'").Length > 0 ? true : false;
            }
        }
        #endregion

        #region  ==============="xq";//星期================
        private static DataTable dt_xq = InitZDData(ZdType.XQ);
        public static DataTable XQ()
        {
            return dt_xq;
        }
        public static DataTable XQ(string xq)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_xq.Select("bm like '" + xq + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }
        private static Hashtable ht_xq = FromZDDataTableToHashTable(dt_xq);
        public static Struct_ZD XQByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_xq[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion



        #region  ==============="jlzl";//奖励种类================
        private static DataTable dt_jlzl = InitZDData(ZdType.JLZL);
        public static DataTable JLZL()
        {
            return dt_jlzl;
        }
        private static Hashtable ht_jlzl = FromZDDataTableToHashTable(dt_jlzl);
        public static Struct_ZD JLZLByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jlzl[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ==============="jldj";//奖励等级================
        private static DataTable dt_jldj = InitZDData(ZdType.JLDJ);
        public static DataTable JLDJ()
        {
            return dt_jldj;
        }
        private static Hashtable ht_jldj = FromZDDataTableToHashTable(dt_jldj);
        public static Struct_ZD JLDJByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_jldj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region================ type 培训记录事件类型===================
        private static DataTable dt_type = InitZDData(ZdType.TYPE);
        public static DataTable TYPE()
        {
            return dt_type;
        }
        private static Hashtable ht_type = FromZDDataTableToHashTable(dt_type);
        public static Struct_ZD typeByKey(string key)
        {
            object obj = ht_type[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region================ jb 培训记录级别===================
        private static DataTable dt_jb = InitZDData(ZdType.JB);
        public static DataTable JB()
        {
            return dt_jb;
        }
        private static Hashtable ht_jb = FromZDDataTableToHashTable(dt_jb);
        public static Struct_ZD JBByKey(string key)
        {
            object obj = ht_jb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region================ khjg 培训记录考核结果===================
        private static DataTable dt_khjg = InitZDData(ZdType.KHJG);
        public static DataTable KHJG()
        {
            return dt_khjg;
        }
        private static Hashtable ht_khjg = FromZDDataTableToHashTable(dt_khjg);
        public static Struct_ZD khjgByKey(string key)
        {
            object obj = ht_khjg[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region================ bmlb 部门类别===================
        private static DataTable dt_bmlb = InitZDData(ZdType.BMLB);
        public static DataTable BMLB()
        {
            return dt_bmlb;
        }
        private static Hashtable ht_bmlb = FromZDDataTableToHashTable(dt_bmlb);
        public static Struct_ZD bmlbByKey(string key)
        {
            object obj = ht_bmlb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  ===============allx1";//案例类型1================
        private static DataTable dt_allx1 = InitZDData(ZdType.ALLX1);
        public static DataTable ALLX1()
        {
            return dt_allx1;
        }
        private static Hashtable ht_allx1 = FromZDDataTableToHashTable(dt_allx1);
        public static Struct_ZD ALLX1ByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_allx1[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============allx2";//案例类型2================
        private static DataTable dt_allx2 = InitZDData(ZdType.ALLX2);
        public static DataTable ALLX2()
        {
            return dt_allx2;
        }
        public static DataTable ALLX2(string allx1)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_allx2.Select("substring(bm,1,2) like'" + allx1 + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }

        private static Hashtable ht_allx2 = FromZDDataTableToHashTable(dt_allx2);
        public static Struct_ZD ALLX2ByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_allx2[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============ally";//案例来源================
        private static DataTable dt_ally = InitZDData(ZdType.ALLY);
        public static DataTable ALLY()
        {
            return dt_ally;
        }
        private static Hashtable ht_ally = FromZDDataTableToHashTable(dt_ally);
        public static Struct_ZD ALLYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_ally[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============aldj";//风险等级================
        private static DataTable dt_aldj = InitZDData(ZdType.ALDJ);
        public static DataTable ALDJ()
        {
            return dt_aldj;
        }
        private static Hashtable ht_aldj = FromZDDataTableToHashTable(dt_aldj);
        public static Struct_ZD ALDJByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_aldj[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============zllx1";//资料类型一================
        private static DataTable dt_zllx1 = InitZDData(ZdType.ZLLX1);
        public static DataTable ZLLX1()
        {
            return dt_zllx1;
        }
        private static Hashtable ht_zllx1 = FromZDDataTableToHashTable(dt_zllx1);
        public static Struct_ZD ZLLX1ByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zllx1[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============zllx2";//资料类型一================
        private static DataTable dt_zllx2 = InitZDData(ZdType.ZLLX2);
        public static DataTable ZLLX2()
        {
            return dt_zllx2;
        }
        public static DataTable ZLLX2(string zllx1)
        {
            DataTable dt = new DataTable();
            DataRow[] rows = dt_zllx2.Select("substring(bm,1,2) like'" + zllx1 + "%'");
            return (ToDataTable(rows) != null ? ToDataTable(rows) : dt);
        }

        private static Hashtable ht_zllx2 = FromZDDataTableToHashTable(dt_zllx2);
        public static Struct_ZD ZLLX2ByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zllx2[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="sjzl";//事件种类代码================
        private static DataTable dt_sjzl = InitZDData(ZdType.SJZL);
        public static DataTable SJZL()
        {
            return dt_sjzl;
        }
        private static Hashtable ht_sjzl = FromZDDataTableToHashTable(dt_sjzl);
        public static Struct_ZD SJZLByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_sjzl[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

        #region  字典重新绑值.
        public static void ReSetZdData()
        {
            ReSetCZFS(); //操作方式
            ReSetXB();//性别
            ReSetBM();//部门
            //ReSetGZD();//工作地
            ReSetMZ();//民族
            ReSetXL();//学历
            ReSetZZMM();//政治面貌
            ReSetHTLX();//合同类型
            ReSetYHLB();//用户类别代码
            ReSetWD1();//维度1
            ReSetWD2();//维度2
            ReSetHTGX();//合同关系代码
            ReSetHTQX();
            ReSetYGZT();
            ReSetYHZT();
            ReSetQZZY();
            ReSetWJLB();
            ReSetSBLX();
            ReSetZDLX();
            ReSetSBPZ();
            ReSetTXLX();
            ReSetMFCXY();
            ReSetQSIGXY();
            ReSetIPXY();
            ReSetPCXJJF();
            ReSetSBZT();
            ReSetSBLB();
            ReSetSBZL();
            ReSetTZLX();
            ReSetSBYT();
            ReSetDWLX();
            ReSetFXXJ();
            ReSetFGFW();
            ReSetSFWXDSB();
            ReSetTXFS();
            ReSetTXLX();
            ReSetBSLX();
            ReSetZJLB();
            ReSetZJSS();
            ReSetWDLX();
            ReSetBJLX();
            ReSetBJSY();
            ReSetWHZT();
            ReSetHBLX();
            ReSetSBWZ();
            ReSetWXLB();
            ReSetZXDM();
            ReSetWXYFC();
            ReSetSTDM();
            ReSetFXFSKN();
            ReSetFXCD();
            ReSetFXKZZT();
            ReSetFXKZBZ();
            ReSetZCLY();
            ReSetRZXS();
            ReSetWPLB();
            ReSetSHZT();
            ReSetZZQZLBDM();
            ReSetZZQZXDM();
            ReSetSFWC();
            ReSetRZLX();
            ReSetZZZT();
            ReSetBMZT();
            ReSetGGLX();
            ReSetALLX();
            ReSetFXDJ();
            ReSetGZYYDM();
            ReSetWXDGRLX();
            ReSetJHXTJYY();
            ReSetBYPC();
            ReSetSTND();
            ReSetSTLX();
            ReSetSTLB();
            ReSetSTZT();
            ReSetKM();
            ReSetZTDM();
            ReSetZZQZX();
            ReSetJS_QX();
            ReSetXQ();
            ReSetZJLX();
            ReSetSFDB();
            ReSetWXLX();//维修类型
            ReSetZYLX();//专业类型
            ReSetYSLX();//预算类型
            ReSetZT2();//状态(预算类型)
            ReSetHXZT();//航线申请状态
            ReSetLY();
            ReSetYHDJ();
            ReSetZGGBPZ();
            ReSetJLZL();//奖励种类
            ReSetJLDJ();//奖励等级
            ReSetTYPE();//培训记录事件类型
            ReSetJB();//培训记录级别
            ReSetKHJG();//培训记录考核结果
            ReSetBMLB();//部门类别
            ReSetALLX1();//案例类型1
            ReSetALLX2();//案例类型2
            ReSetALLY();//案例来源
            ReSetALDJ();
            ReSetZLLX1();
            ReSetZLLX2();
            ReSetZCJB();///职称级别
            ReSetZG();//资格            
            ReSetPR();//是否聘任
            ReSetDZB_BS();
            ReSetPLDW();//频率单位
            ReSetTCSFXY();//投产是否限用
            ReSetMCFXJYJG();//末次飞行校验结果
            ReSetFGFWDW();//覆盖范围单位
            ReSetSCGLDW();//输出功率单位
            ReSetHXSBLB();//航向设备类别
            ReSetHXSBTXZLX();//航向设备天线阵类型
            ReSetXHSBTXZLX();//下滑设备天线阵类型
            ReSetCJYPTSB();//测距仪配套设备
            ReSetZDXBLXXZ();//指点信标类型选择
            ReSetZXTDM(); //子系统代码
            ReSetSJFC(); //涉及范畴
            ReSetHGYZX(); //后果严重程度
            ReSetWXCD(); //后果严重程度
            ReSetAQZT(); //安全状态
            ReSetZGCSBZHQK(); //安全状态
            ReSetWTZT(); //问题状态
            ReSetSJZL();
            ReSetSFJB();
            ReSetJDFS();//检定方式
            ReSetMHSBLX();
            ReSetTBDW();//填报单位
            ReSetJCRWZT();//检查任务状态
            ReSetJCJG();//检查结果
            ReSetZGZT();//整改状态

            ReSetTQCZ();
            ReSetDYLX();
            ReSetZZQK();
        }
        #endregion

        #region  Reset()方法
        public static void ReSetCZFS()
        {
            dt_czfs = InitZDData(ZdType.CZFS);
            ht_czfs = FromZDDataTableToHashTable(dt_czfs);
        }
        public static void ReSetHXZT()
        {
            dt_hxzt = InitZDData(ZdType.HXZT);
            ht_hxzt = FromZDDataTableToHashTable(dt_hxzt);
        }
        public static void ReSetZJLX()
        {
            dt_zjlx = InitZDData(ZdType.ZJLX);
            ht_zjlx = FromZDDataTableToHashTable(dt_zjlx);
        }
        public static void ReSetBMZT()
        {
            dt_bmzt = InitZDData(ZdType.BMZT);
            ht_bmzt = FromZDDataTableToHashTable(dt_bmzt);
        }
        //性别
        public static void ReSetXB()
        {
            dt_xb = InitZDData(ZdType.XBDM);
            ht_xb = FromZDDataTableToHashTable(dt_xb);
        }
        //部门
        public static void ReSetBM()
        {
            dt_bm = InitBMData();
            ht_bm = FromBMDataTableToHashTable(dt_bm);
        }
        //岗位
        public static void ReSetGW()
        {
            dt_gw = InitGWData();
            ht_gw = FromGWDataTableToHashTable(dt_gw);
        }

        //工作地
        /*
        public static void ReSetGZD()
        {
            dt_gzddm = InitZDData(ZdType.GZDDM);
            ht_gzddm = FromZDDataTableToHashTable(dt_gzddm);
        }
        */
        //民族
        public static void ReSetMZ()
        {
            dt_mz = InitZDData(ZdType.MZDM);
            ht_mz = FromZDDataTableToHashTable(dt_mz);
        }
        //学历
        public static void ReSetXL()
        {
            dt_xldm = InitZDData(ZdType.XLDM);
            ht_xldm = FromZDDataTableToHashTable(dt_xldm);
        }
        //政治面貌
        public static void ReSetZZMM()
        {
            dt_zzmm = InitZDData(ZdType.ZZMMDM);
            ht_zzmm = FromZDDataTableToHashTable(dt_zzmm);
        }
        //是否待办
        public static void ReSetSFDB()
        {
            dt_sfdb = InitZDData(ZdType.SFDB);
            ht_sfdb = FromZDDataTableToHashTable(dt_sfdb);
        }
        //合同类型
        public static void ReSetHTLX()
        {
            dt_htlxdm = InitZDData(ZdType.HTLXDM);
            ht_htlxdm = FromZDDataTableToHashTable(dt_htlxdm);
        }
        //用户类别代码
        public static void ReSetYHLB()
        {
            dt_ztdm = InitZDData(ZdType.ZTDM);
            ht_ztdm = FromZDDataTableToHashTable(dt_ztdm);
        }
        //维度2
        public static void ReSetWD2()
        {
            dt_wd2dm = InitZDData(ZdType.WD2DM);
            ht_wd2dm = FromZDDataTableToHashTable(dt_wd2dm);
        }
        //维修类型
        public static void ReSetWXLX()
        {
            dt_wxlx = InitZDData(ZdType.WXLX);
            ht_wxlx = FromZDDataTableToHashTable(dt_wxlx);
        }
        //专业类型
        public static void ReSetZYLX()
        {
            dt_zylx = InitZDData(ZdType.ZYLX);
            ht_zylx = FromZDDataTableToHashTable(dt_zylx);
        }
        //预算类型
        public static void ReSetYSLX()
        {
            dt_yslx = InitZDData(ZdType.YSLX);
            ht_yslx = FromZDDataTableToHashTable(dt_yslx);
        }
        //状态(预算申报)
        public static void ReSetZT2()
        {
            dt_zts = InitZDData(ZdType.ZT2);
            ht_zts = FromZDDataTableToHashTable(dt_zts);
        }

        //维度1
        public static void ReSetWD1()
        {
            dt_wd1dm = InitZDData(ZdType.WD1DM);
            ht_wd1dm = FromZDDataTableToHashTable(dt_wd1dm);
        }
        public static void ReSetTBDW()
        {
            dt_tbdw = InitZDData(ZdType.TBDW);
            ht_tbdw = FromZDDataTableToHashTable(dt_tbdw);
        }
        //安全监管-检查任务状态
        public static void ReSetJCRWZT()
        {
            dt_jcrwzt = InitZDData(ZdType.jcrwzt);
            ht_jcrwzt = FromZDDataTableToHashTable(dt_jcrwzt);
        }
        public static void ReSetJCJG()
        {
            dt_jcjg = InitZDData(ZdType.JCJG);
            ht_jcjg = FromZDDataTableToHashTable(dt_jcjg);
        }
        public static void ReSetZGZT()
        {
            dt_zgzt = InitZDData(ZdType.ZGZT);
            ht_zgzt = FromZDDataTableToHashTable(dt_zgzt);
        }

        public static void ReSetBJBS()
        {
            dt_bjbs = InitZDData(ZdType.BJBS);
            ht_bjbs = FromZDDataTableToHashTable(dt_bjbs);
        }
        public static void ReSetHTGX()
        {
            dt_wd1dm = InitZDData(ZdType.HTGXDM);
            ht_wd1dm = FromZDDataTableToHashTable(dt_htgxdm);
        }
        public static void ReSetHTQX()
        {
            dt_htqxdm = InitZDData(ZdType.HTQXDM);
            ht_htqxdm = FromZDDataTableToHashTable(dt_htqxdm);
        }
        public static void ReSetYGZT()
        {
            dt_ygztdm = InitZDData(ZdType.YGZTDM);
            ht_ygztdm = FromZDDataTableToHashTable(dt_ygztdm);
        }
        public static void ReSetYHZT()
        {
            dt_yhztdm = InitZDData(ZdType.YHZTDM);
            ht_yhztdm = FromZDDataTableToHashTable(dt_yhztdm);
        }
        public static void ReSetQZZY()
        {
            dt_qzzydm = InitZDData(ZdType.QZZYDM);
            ht_qzzydm = FromZDDataTableToHashTable(dt_qzzydm);
        }
        public static void ReSetWJLB()
        {
            dt_wjlb = InitZDData(ZdType.WJLB);
            ht_wjlb = FromZDDataTableToHashTable(dt_wjlb);
        }
        public static void ReSetSBLX()
        {
            dt_sblx = InitZDData(ZdType.SBLX);
            ht_sblx = FromZDDataTableToHashTable(dt_sblx);
        }
        public static void ReSetTQCZ()
        {
            dt_tqcz = InitZDData(ZdType.TQCZ);
            ht_tqcz = FromZDDataTableToHashTable(dt_tqcz);
        }
        public static void ReSetZDLX()
        {
            dt_zdlx = InitZDData(ZdType.ZDLX);
            ht_zdlx = FromZDDataTableToHashTable(dt_zdlx);
        }
        public static void ReSetSBPZ()
        {
            dt_sbpz = InitZDData(ZdType.SBPZ);
            ht_sbpz = FromZDDataTableToHashTable(dt_sbpz);
        }
        public static void ReSetMFCXY()
        {
            dt_mfcxy = InitZDData(ZdType.MFCXY);
            ht_mfcxy = FromZDDataTableToHashTable(dt_mfcxy);
        }
        public static void ReSetQSIGXY()
        {
            dt_qsigxy = InitZDData(ZdType.QSIGXY);
            ht_qsigxy = FromZDDataTableToHashTable(dt_qsigxy);
        }
        public static void ReSetIPXY()
        {
            dt_ipxy = InitZDData(ZdType.IPXY);
            ht_ipxy = FromZDDataTableToHashTable(dt_ipxy);
        }
        public static void ReSetPCXJJF()
        {
            dt_pcxjjf = InitZDData(ZdType.PCXJJF);
            ht_pcxjjf = FromZDDataTableToHashTable(dt_pcxjjf);
        }
        public static void ReSetSBZT()
        {
            dt_sbztdm = InitZDData(ZdType.SBZTDM);
            ht_sbztdm = FromZDDataTableToHashTable(dt_sbztdm);
        }
        public static void ReSetSBLB()
        {
            dt_sblbdm = InitZDData(ZdType.SBLBDM);
            ht_sblbdm = FromZDDataTableToHashTable(dt_sblbdm);
        }
        public static void ReSetSBZL()
        {
            dt_sbzl = InitZDData(ZdType.SBZL);
            ht_sbzl = FromZDDataTableToHashTable(dt_sbzl);
        }
        public static void ReSetXQ()
        {
            dt_xq = InitZDData(ZdType.XQ);
            ht_xq = FromZDDataTableToHashTable(dt_xq);
        }

        public static void ReSetTZLX()
        {
            dt_tzlxdm = InitZDData(ZdType.TZLXDM);
            ht_tzlxdm = FromZDDataTableToHashTable(dt_tzlxdm);
        }
        public static void ReSetSBYT()
        {
            dt_sbytdm = InitZDData(ZdType.SBYTDM);
            ht_sbytdm = FromZDDataTableToHashTable(dt_sbytdm);
        }
        public static void ReSetDWLX()
        {
            dt_dwlxdm = InitZDData(ZdType.DWLXDM);
            ht_dwlxdm = FromZDDataTableToHashTable(dt_dwlxdm);
        }
        public static void ReSetFXXJ()
        {
            dt_fxxjdm = InitZDData(ZdType.FXXJDM);
            ht_fxxjdm = FromZDDataTableToHashTable(dt_fxxjdm);
        }
        public static void ReSetFGFW()
        {
            dt_fgfwdm = InitZDData(ZdType.FGFWDM);
            ht_fgfwdm = FromZDDataTableToHashTable(dt_fgfwdm);
        }
        public static void ReSetSFWXDSB()
        {
            dt_sfwxdsb = InitZDData(ZdType.SFWXDSB);
            ht_sfwxdsb = FromZDDataTableToHashTable(dt_sfwxdsb);
        }
        public static void ReSetTXFS()
        {
            dt_txfsdm = InitZDData(ZdType.TXFSDM);
            ht_txfsdm = FromZDDataTableToHashTable(dt_txfsdm);
        }
        public static void ReSetTXLX()
        {
            dt_txlxdm = InitZDData(ZdType.TXLXDM);
            ht_txlxdm = FromZDDataTableToHashTable(dt_txlxdm);
        }
        public static void ReSetBSLX()
        {
            dt_bslx = InitZDData(ZdType.BSLX);
            ht_bslx = FromZDDataTableToHashTable(dt_bslx);
        }
        public static void ReSetZJLB()
        {
            dt_zjlbdm = InitZDData(ZdType.ZJLBDM);
            ht_zjlbdm = FromZDDataTableToHashTable(dt_zjlbdm);
        }
        public static void ReSetZJSS()
        {
            dt_zjssdm = InitZDData(ZdType.ZJSSDM);
            ht_zjssdm = FromZDDataTableToHashTable(dt_zjssdm);
        }
        public static void ReSetWDLX()
        {
            dt_wdlx = InitZDData(ZdType.WDLX);
            ht_wdlx = FromZDDataTableToHashTable(dt_wdlx);
        }
        public static void ReSetBJLX()
        {
            dt_bjlxdm = InitZDData(ZdType.BJLXDM);
            ht_bjlxdm = FromZDDataTableToHashTable(dt_bjlxdm);
        }
        public static void ReSetBJSY()
        {
            dt_bjsy = InitZDData(ZdType.BJSY);
            ht_bjsy = FromZDDataTableToHashTable(dt_bjsy);
        }
        public static void ReSetWHZT()
        {
            dt_whztdm = InitZDData(ZdType.WHZTDM);
            ht_whztdm = FromZDDataTableToHashTable(dt_whztdm);
        }
        public static void ReSetHBLX()
        {
            dt_hblxdm = InitZDData(ZdType.HBLXDM);
            ht_hblxdm = FromZDDataTableToHashTable(dt_hblxdm);
        }
        public static void ReSetSBWZ()
        {
            dt_sbwz = InitZDData(ZdType.SBWZ);
            ht_sbwz = FromZDDataTableToHashTable(dt_sbwz);
        }
        public static void ReSetWXLB()
        {
            dt_wxlb = InitZDData(ZdType.WXLB);
            ht_wxlb = FromZDDataTableToHashTable(dt_wxlb);
        }
        public static void ReSetZXDM()
        {
            dt_zxdm = InitZDData(ZdType.ZXDM);
            ht_zxdm = FromZDDataTableToHashTable(dt_zxdm);
        }
        public static void ReSetWXYFC()
        {
            dt_wxyfc = InitZDData(ZdType.WXYFC);
            ht_wxyfc = FromZDDataTableToHashTable(dt_wxyfc);
        }
        public static void ReSetSTDM()
        {
            dt_stdm = InitZDData(ZdType.STDM);
            ht_stdm = FromZDDataTableToHashTable(dt_stdm);
        }
        public static void ReSetFXFSKN()
        {
            dt_fxfskn = InitZDData(ZdType.FXFSKN);
            ht_fxfskn = FromZDDataTableToHashTable(dt_fxfskn);
        }
        public static void ReSetFXCD()
        {
            dt_fxcd = InitZDData(ZdType.FXCD);
            ht_fxcd = FromZDDataTableToHashTable(dt_fxcd);
        }
        public static void ReSetFXKZZT()
        {
            dt_fxkzzt = InitZDData(ZdType.FXKZZT);
            ht_fxkzzt = FromZDDataTableToHashTable(dt_fxkzzt);
        }
        public static void ReSetFXKZBZ()
        {
            dt_fxkzbz = InitZDData(ZdType.FXKZBZ);
            ht_fxkzbz = FromZDDataTableToHashTable(dt_fxkzbz);
        }
        public static void ReSetZCLY()
        {
            dt_zcly = InitZDData(ZdType.ZCLY);
            ht_zcly = FromZDDataTableToHashTable(dt_zcly);
        }
        public static void ReSetALLX()
        {
            dt_allx = InitZDData(ZdType.ALLX);
            ht_allx = FromZDDataTableToHashTable(dt_allx);
        }
        public static void ReSetFXDJ()
        {
            dt_fxdj = InitZDData(ZdType.FXDJ);
            ht_fxdj = FromZDDataTableToHashTable(dt_fxdj);
        }
        public static void ReSetRZXS()
        {
            dt_rzxs = InitZDData(ZdType.RZXS);
            ht_rzxs = FromZDDataTableToHashTable(dt_rzxs);
        }
        public static void ReSetSFWC()
        {
            dt_sfwc = InitZDData(ZdType.SFWC);
            ht_sfwc = FromZDDataTableToHashTable(dt_sfwc);
        }
        public static void ReSetGGLX()
        {
            dt_gglx = InitZDData(ZdType.GGLX);
            ht_gglx = FromZDDataTableToHashTable(dt_gglx);
        }
        public static void ReSetRZLX()
        {
            dt_rzlx = InitZDData(ZdType.RZLX);
            ht_rzlx = FromZDDataTableToHashTable(dt_rzlx);
        }
        public static void ReSetWPLB()
        {
            dt_wplbdm = InitZDData(ZdType.WPLBDM);
            ht_wplbdm = FromZDDataTableToHashTable(dt_wplbdm);
        }
        public static void ReSetSHZT()
        {
            dt_shztdm = InitZDData(ZdType.SHZTDM);
            ht_shztdm = FromZDDataTableToHashTable(dt_shztdm);
        }
        public static void ReSetZZQZXDM()
        {
            dt_zzqzxdm = InitZDData(ZdType.ZZQZXDM);
            ht_zzqzxdm = FromZDDataTableToHashTable(dt_zzqzxdm);
        }
        public static void ReSetZZQZLBDM()
        {
            dt_zzqzlbdm = InitZDData(ZdType.ZZQZLBDM);
            ht_zzqzlbdm = FromZDDataTableToHashTable(dt_zzqzlbdm);
        }
        public static void ReSetZZQZX()
        {
            dt_zzqzx = InitZDData(ZdType.ZZQZX);
            ht_zzqzx = FromZDDataTableToHashTable(dt_zzqzx);
        }
        public static void ReSetZZZT()
        {
            dt_zzzt = InitZDData(ZdType.ZZZT);
            ht_zzzt = FromZDDataTableToHashTable(dt_zzzt);
        }
        public static void ReSetGZYYDM()
        {
            dt_gzyy = InitZDData(ZdType.GZYYDM);
            ht_gzyy = FromZDDataTableToHashTable(dt_gzyy);
        }
        public static void ReSetWXDGRLX()
        {
            dt_wxdgrlx = InitZDData(ZdType.WXDGRLX);
            ht_wxdgrlx = FromZDDataTableToHashTable(dt_wxdgrlx);
        }
        public static void ReSetJHXTJYY()
        {
            dt_jhxtjyy = InitZDData(ZdType.JHXTJYY);
            ht_jhxtjyy = FromZDDataTableToHashTable(dt_jhxtjyy);
        }
        public static void ReSetBYPC()
        {
            dt_bypc = InitZDData(ZdType.BYPC);
            ht_bypc = FromZDDataTableToHashTable(dt_bypc);
        }
        public static void ReSetHTZT()
        {
            dt_htzt = InitZDData(ZdType.HTZT);
            ht_htzt = FromZDDataTableToHashTable(dt_htzt);
        }
        public static void ReSetYGXS()
        {
            dt_ygxs = InitZDData(ZdType.YGXS);
            ht_ygxs = FromZDDataTableToHashTable(dt_ygxs);
        }
        public static void ReSetDZZMC()
        {
            dt_dzzmc = InitZDData(ZdType.DZZMC);
            ht_dzzmc = FromZDDataTableToHashTable(dt_dzzmc);
        }
        public static void ReSetJCDZBMC()
        {
            dt_jcdzbmc = InitZDData(ZdType.JCDZBMC);
            ht_jcdzbmc = FromZDDataTableToHashTable(dt_jcdzbmc);
        }
        public static void ReSetDXZMC()
        {
            dt_dxzmc = InitZDData(ZdType.DXZMC);
            ht_dxzmc = FromZDDataTableToHashTable(dt_dxzmc);
        }
        public static void ReSetSTND()
        {
            dt_stnd = InitZDData(ZdType.STND);
            ht_stnd = FromZDDataTableToHashTable(dt_stnd);
        }
        public static void ReSetSTLX()
        {
            dt_stlx = InitZDData(ZdType.STLX);
            ht_stlx = FromZDDataTableToHashTable(dt_stlx);
        }
        public static void ReSetSTLB()
        {
            dt_stlb = InitZDData(ZdType.STLB);
            ht_stlb = FromZDDataTableToHashTable(dt_stlb);
        }
        public static void ReSetSTZT()
        {
            dt_stzt = InitZDData(ZdType.STZT);
            ht_stzt = FromZDDataTableToHashTable(dt_stzt);
        }
        public static void ReSetKM()
        {
            dt_km = InitZDData(ZdType.KM);
            ht_km = FromZDDataTableToHashTable(dt_km);
        }
        public static void ReSetZTDM()
        {
            dt_zt = InitZDData(ZdType.ZT);
            ht_zt = FromZDDataTableToHashTable(dt_zt);
        }
        public static void ReSetJS_QX()
        {
            Select_QX_ALLYH();
        }
        public static void ReSetLY()
        {
            dt_ly = InitZDData(ZdType.LY);
            ht_ly = FromZDDataTableToHashTable(dt_ly);
        }
        public static void ReSetZGGBPZ()
        {
            dt_zggbpz = InitZDData(ZdType.ZGGBPZ);
            ht_zggbpz = FromZDDataTableToHashTable(dt_zggbpz);
        }
        public static void ReSetYHDJ()
        {
            dt_yhdj = InitZDData(ZdType.YHDJ);
            ht_yhdj = FromZDDataTableToHashTable(dt_yhdj);
        }
        private static void ReSetJLDJ()
        {
            dt_jldj = InitZDData(ZdType.JLDJ);
            ht_jldj = FromZDDataTableToHashTable(dt_jldj);
        }

        private static void ReSetJLZL()
        {
            dt_jlzl = InitZDData(ZdType.JLZL);
            ht_jlzl = FromZDDataTableToHashTable(dt_jlzl);
        }

        public static void ReSetZLLX1()
        {
            dt_zllx1 = InitZDData(ZdType.ZLLX1);
            ht_zllx1 = FromZDDataTableToHashTable(dt_zllx1);
        }
        public static void ReSetZLLX2()
        {
            dt_zllx2 = InitZDData(ZdType.ZLLX2);
            ht_zllx2 = FromZDDataTableToHashTable(dt_zllx2);
        }
        private static void ReSetZCJB()
        {
            dt_jb = InitZDData(ZdType.ZCJB);
            ht_zcjb = FromZDDataTableToHashTable(dt_jb);
        }
        private static void ReSetZG()
        {
            dt_zg = InitZDData(ZdType.ZG);
            ht_zg = FromZDDataTableToHashTable(dt_zg);
        }



        private static void ReSetPR()
        {
            dt_pr = InitZDData(ZdType.PR);
            ht_pr = FromZDDataTableToHashTable(dt_pr);
        }
        //培训记录事件类型
        public static void ReSetTYPE()
        {
            dt_type = InitZDData(ZdType.TYPE);
            ht_type = FromZDDataTableToHashTable(dt_type);
        }
        //培训记录级别
        public static void ReSetJB()
        {
            dt_jb = InitZDData(ZdType.JB);
            ht_jb = FromZDDataTableToHashTable(dt_jb);
        }
        //培训记录考核结果
        public static void ReSetKHJG()
        {
            dt_khjg = InitZDData(ZdType.KHJG);
            ht_khjg = FromZDDataTableToHashTable(dt_khjg);
        }
        //部门类别
        public static void ReSetBMLB()
        {
            dt_bmlb = InitZDData(ZdType.BMLB);
            ht_bmlb = FromZDDataTableToHashTable(dt_bmlb);
        }
        public static void ReSetALLX1()
        {
            dt_allx1 = InitZDData(ZdType.ALLX1);
            ht_allx1 = FromZDDataTableToHashTable(dt_allx1);
        }
        public static void ReSetALLX2()
        {
            dt_allx2 = InitZDData(ZdType.ALLX2);
            ht_allx2 = FromZDDataTableToHashTable(dt_allx2);
        }
        public static void ReSetALLY()
        {
            dt_ally = InitZDData(ZdType.ALLY);
            ht_ally = FromZDDataTableToHashTable(dt_ally);
        }
        public static void ReSetALDJ()
        {
            dt_aldj = InitZDData(ZdType.ALDJ);
            ht_aldj = FromZDDataTableToHashTable(dt_aldj);
        }
        public static void ReSetDZB_BS()
        {
            dt_dzb_bs = InitZDData(ZdType.DZB_BS);
            ht_dzb_bs = FromZDDataTableToHashTable(dt_dzb_bs);
        }

        //频率单位
        public static void ReSetPLDW()
        {
            dt_pldw = InitZDData(ZdType.PLDW);
            ht_pldw = FromZDDataTableToHashTable(dt_pldw);
        }
        //投产是否限用
        public static void ReSetTCSFXY()
        {
            dt_tcsfxy = InitZDData(ZdType.TCSFXY);
            ht_tcsfxy = FromZDDataTableToHashTable(dt_tcsfxy);
        }
        //末次飞行校验结果
        public static void ReSetMCFXJYJG()
        {
            dt_mcfxjyjg = InitZDData(ZdType.MCFXJYJG);
            ht_mcfxjyjg = FromZDDataTableToHashTable(dt_mcfxjyjg);
        }
        //覆盖范围单位
        public static void ReSetFGFWDW()
        {
            dt_fgfwdw = InitZDData(ZdType.FGFWDW);
            ht_fgfwdw = FromZDDataTableToHashTable(dt_fgfwdw);
        }
        //输出功率单位
        public static void ReSetSCGLDW()
        {
            dt_scgldw = InitZDData(ZdType.SCGLDW);
            ht_scgldw = FromZDDataTableToHashTable(dt_scgldw);
        }
        //航向设备类别
        public static void ReSetHXSBLB()
        {
            dt_hxsblb = InitZDData(ZdType.HXSBLB);
            ht_hxsblb = FromZDDataTableToHashTable(dt_hxsblb);
        }
        //航向设备天线阵类型
        public static void ReSetHXSBTXZLX()
        {
            dt_hxsbtxzlx = InitZDData(ZdType.HXSBTXZLX);
            ht_hxsbtxzlx = FromZDDataTableToHashTable(dt_hxsbtxzlx);
        }
        //下滑设备天线阵类型
        public static void ReSetXHSBTXZLX()
        {
            dt_xhsbtxzlx = InitZDData(ZdType.XHSBTXZLX);
            ht_xhsbtxzlx = FromZDDataTableToHashTable(dt_xhsbtxzlx);
        }
        //测距仪配套设备
        public static void ReSetCJYPTSB()
        {
            dt_cjyptsb = InitZDData(ZdType.CJYPYSB);
            ht_cjyptsb = FromZDDataTableToHashTable(dt_cjyptsb);
        }
        //指点信标类型选择
        public static void ReSetZDXBLXXZ()
        {
            dt_zdxblxxz = InitZDData(ZdType.ZDXBLXXZ);
            ht_zdxblxxz = FromZDDataTableToHashTable(dt_zdxblxxz);
        }
        public static void ReSetZXTDM()
        {
            dt_zxtdm = InitZDData(ZdType.ZXTDM);
            ht_zxtdm = FromZDDataTableToHashTable(dt_zxtdm);
        }
        public static void ReSetSJFC()
        {
            dt_sjfc = InitZDData(ZdType.SJFC);
            ht_sjfc = FromZDDataTableToHashTable(dt_sjfc);
        }

        public static void ReSetHGYZX()
        {
            dt_hgyzx = InitZDData(ZdType.HGYZX);
            ht_hgyzx = FromZDDataTableToHashTable(dt_hgyzx);
        }
        public static void ReSetWXCD()
        {
            dt_wxcd = InitZDData(ZdType.WXCD);
            ht_wxcd = FromZDDataTableToHashTable(dt_wxcd);
        }
        public static void ReSetAQZT()
        {
            dt_aqzt = InitZDData(ZdType.AQZT);
            ht_aqzt = FromZDDataTableToHashTable(dt_aqzt);
        }
        public static void ReSetZGCSBZHQK()
        {
            dt_zgcsbzhqk = InitZDData(ZdType.ZGCSBZHQK);
            ht_zgcsbzhqk = FromZDDataTableToHashTable(dt_zgcsbzhqk);
        }
        public static void ReSetWTZT()
        {
            dt_wtzt = InitZDData(ZdType.WTZT);
            ht_wtzt = FromZDDataTableToHashTable(dt_wtzt);
        }
        public static void ReSetSJZL()
        {
            dt_sjzl = InitZDData(ZdType.SJZL);
            ht_sjzl = FromZDDataTableToHashTable(dt_sjzl);
        }
        public static void ReSetSFJB()
        {
            dt_sfjb = InitZDData(ZdType.SFJB);
            ht_sfjb = FromZDDataTableToHashTable(dt_sfjb);
        }
        public static void ReSetJDFS()
        {
            dt_jdfs = InitZDData(ZdType.JDFS);
            ht_jdfs = FromZDDataTableToHashTable(dt_jdfs);
        }
        public static void ReSetMHSBLX()
        {
            dt_mhsblx = InitZDData(ZdType.MHSBLX);
            ht_mhsblx = FromZDDataTableToHashTable(dt_mhsblx);
        }

        public static void ReSetZZQK()
        {
            dt_zzqk = InitZDData(ZdType.ZZQK);
            ht_zzqk = FromZDDataTableToHashTable(dt_zzqk);
        }
        public static void ReSetDYLX()
        {
            dt_dylx = InitZDData(ZdType.DYLX);
            ht_dylx = FromZDDataTableToHashTable(dt_dylx);
        }
        #endregion


        #region======字典码============
        private static Hashtable InitZDM()
        {
            lock (typeof(SysData))
            {
                Hashtable yg = new Hashtable();
                yg.Add("czfs", "操作方式");
                yg.Add("xbdm", "性别代码");
                yg.Add("bmdm", "部门代码");
                yg.Add("gwdm", "岗位代码");
                yg.Add("zzqzlb", "执照签注类别");
                yg.Add("zzqzx", "执照签注项");
                yg.Add("gzddm", "工作地代码");
                yg.Add("mzdm", "民族代码");
                yg.Add("xldm", "学历代码");
                yg.Add("zzmmdm", "政治面貌代码");
                yg.Add("htlxdm", "合同类型代码");
                yg.Add("yhlbdm", "用户类别代码");
                yg.Add("wd1dm", "维度1代码");
                yg.Add("wd2dm", "维度2代码");
                yg.Add("wd3dm", "维度3代码");
                yg.Add("ztdm", "状态代码");
                yg.Add("htgxdm", "合同关系代码");
                yg.Add("htqxdm", "合同期限代码");
                yg.Add("ygztdm", "员工状态代码");
                yg.Add("yhztdm", "用户状态代码");
                yg.Add("qzzydm", "签注专业代码");
                yg.Add("wjlb", "文件类别");
                yg.Add("sblx", "设备类型");
                yg.Add("zdlx", "站点类型");
                yg.Add("sbpz", "设备配置");
                yg.Add("mfcxy", "MFC协议");
                yg.Add("qsigxy", "Q-SIG协议");
                yg.Add("ipxy", "IP协议");
                yg.Add("pcxjjf", "评测项加减分");
                yg.Add("sbztdm", "设备状态代码");
                yg.Add("sblbdm", "设备类别代码");
                yg.Add("sbzl", "设备种类");
                yg.Add("tzlxdm", "台站类型代码");
                yg.Add("sbytdm", "设备用途代码");
                yg.Add("dwlxdm", "地网类型代码");
                yg.Add("fxxjdm", "飞行校检代码");
                yg.Add("fgfwdm", "覆盖范围代码");
                yg.Add("sfwxdsb", "是否无线电设备");
                yg.Add("txfsdm", "通信方式代码");
                yg.Add("txlxdm", "天线类型代码");
                yg.Add("bslx", "报送类型");
                yg.Add("ydqz", "异地签注");
                yg.Add("ydqzlb", "异地签注类别");
                yg.Add("tjdj", "体检等级代码");
                yg.Add("yydj", "英语等级");
                yg.Add("zjlbdm", "专家类别代码");
                yg.Add("zjssdm", "专家所属代码");
                yg.Add("wdlx", "文档类型");
                yg.Add("bjlxdm", "备件类型代码");
                yg.Add("bjsy", "备件适用");
                yg.Add("whztdm", "维护状态代码");
                yg.Add("hblxdm", "航班类型代码");
                yg.Add("zxdm", "支线代码");
                yg.Add("jdfs", "检定方式");
                yg.Add("sbwz", "设备位置");
                yg.Add("wxlb", "维修类别");
                yg.Add("wxlx", "维修类型");
                yg.Add("zylx", "专业类型");
                yg.Add("yslx", "预算类型");
                yg.Add("zt", "状态");
                yg.Add("wxyfc", "危险源范畴");
                yg.Add("stdm", "时态代码");
                yg.Add("fxfskn", "风险发生可能");
                yg.Add("fxcd", "风险程度");
                yg.Add("fxkzzt", "风险控制状态");
                yg.Add("fxkzbz", "风险控制标准");
                yg.Add("zcly", "资产来源");
                yg.Add("rzxs", "入账形式");
                yg.Add("wplbdm", "物品类别代码");
                yg.Add("shztdm", "审核状态代码");
                yg.Add("sfwc", "是否完成");
                yg.Add("rzlx", "日志类型");
                yg.Add("zzzt", "资质状态");
                yg.Add("bmzt", "部门状态");
                yg.Add("gglxdm", "公告类型代码");
                yg.Add("allx", "案例类型");
                yg.Add("fxdj", "风险等级");
                yg.Add("gzyydm", "故障原因代码");
                yg.Add("wxdgrlx", "无线电干扰类型");
                yg.Add("jhxtjyy", "计划性停机原因");
                yg.Add("bypc", "保养频次");
                yg.Add("htzt", "合同状态");
                yg.Add("ygxs", "用工形式");
                yg.Add("dzzmc", "党组织名称");
                yg.Add("jcdzbmc", "基层党支部名称");
                yg.Add("dxzmc", "党小组名称");
                yg.Add("sfdb", "是否待办");
                yg.Add("ly", "来源");
                yg.Add("yhdj", "隐患等级");
                yg.Add("zggbpz", "整改关闭批准");
                yg.Add("sjzldm", "事件种类代码");
                yg.Add("jlzl", "奖励种类");
                yg.Add("jldj", "奖励等级");
                yg.Add("type", "培训记录事件类型");
                yg.Add("jb", "培训记录级别");
                yg.Add("khjg", "培训记录考核结果");
                yg.Add("bmlb", "部门类别");
                yg.Add("allx1", "案例类型1");
                yg.Add("allx2", "案例类型2");
                yg.Add("ally", "案例来源");
                yg.Add("aldj", "案例等级");
                yg.Add("zllx1", "资料类型一");
                yg.Add("zllx2", "资料类型二");
                yg.Add("zcjb", "职称级别");
                yg.Add("zg", "资格");
                yg.Add("pr", "是否聘任");
                yg.Add("dzb_bs", "党支部标识");
                yg.Add("pldw", "频率单位");
                yg.Add("tcsfxy", "投产是否限用");
                yg.Add("mcfxjyjg", "末次飞行校验结果");
                yg.Add("fgfwdw", "覆盖范围单位");
                yg.Add("scgldw", "输出功率单位");
                yg.Add("hxsblb", "航向设备类别");
                yg.Add("hxsbtxzlx", "航向设备天线阵类型");
                yg.Add("xhsbtxzlx", "下滑设备天线阵类型");
                yg.Add("cjyptsb", "测距仪配套设备");
                yg.Add("zdxblxxz", "指点信标类型选择");
                yg.Add("zxtdm", "子系统代码");
                yg.Add("sjfc", "涉及范畴");
                yg.Add("hgyzx", "后果严重程度");
                yg.Add("wxcd", "危险程度");
                yg.Add("aqzt", "安全状态");
                yg.Add("zgcsbzhqk", "整改措施标准化情况");
                yg.Add("wtzt", "问题状态");
                yg.Add("sjzl", "事件种类代码");
                yg.Add("sfjb", "是否具备");
                yg.Add("mhsblx", "灭火设备类型");
                yg.Add("xq", "星期");
                yg.Add("tbdw", "填报单位");
                yg.Add("jcrwzt", "检查任务状态");
                yg.Add("jcjg", "检查结果");
                yg.Add("zgzt", "整改状态");
                yg.Add("bjbs", "比较标识");
                yg.Add("dylx", "党员类型代码");
                yg.Add("zzqk", "专家情况代码");
                yg.Add("tqcz", "特情处置");
                return yg;
            }
        }
        private static Hashtable ht_zdm = InitZDM();
        public static string ZDMByKey(string key)
        {
            object obj = ht_zdm[key];
            return (obj != null ? (string)obj : key.ToString());
        }
        private static DataTable dt_zdm = FromHashTableToDataTable(ht_zdm);
        public static DataTable ZDM()
        {
            return dt_zdm;
        }
        #endregion
        #region 用户权限
        #region======是否是权限用户=====
        private static Hashtable InitSFSQXYH()
        {
            lock (typeof(SysData))
            {
                Hashtable sfsqxyh = new Hashtable();
                sfsqxyh.Add("1", "[1]是");
                sfsqxyh.Add("0", "[0]否");
                return sfsqxyh;
            }
        }
        private static Hashtable ht_sfsqxyh = InitSFSQXYH();
        public static string SFSQXYHByKey(string key)
        {
            object obj = ht_sfsqxyh[key];
            return (obj != null ? (string)obj : key.ToString());
        }
        private static DataTable dt_sfsqxyh = FromHashTableToDataTable(ht_sfsqxyh);
        public static DataTable SFSQXYH()
        {
            return dt_sfsqxyh;
        }
        #endregion
        #region =============用户权限===================
        private static DataTable dt_yhqx = Select_QX_ALLYH();
        private static DataTable Select_QX_ALLYH()
        {
            DataTable dt = new DataTable();
            DBClass db_yhqx = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };
                paras_qx[0].Direction = ParameterDirection.Output;
                dt = db_yhqx.RunProcedure("PACK_KG_YHJS.Select_QX_ALLYH", paras_qx, "table").Tables[0];
                return dt;
            }
            finally
            {
                db_yhqx.Close();
            }
        }

        #region =============用户部门权限===================
        #endregion
        private static DataTable dt_yhbmqx = Select_BMQX_ALLYH();

        private static DataTable dt_ptyh = Select_BMQX_PTYH();

        private static DataTable Select_BMQX_ALLYH()
        {
            DataTable dt = new DataTable();
            DBClass db_yhqx = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };
                paras_qx[0].Direction = ParameterDirection.Output;
                dt = db_yhqx.RunProcedure("PACK_KG_YHJS.Select_BMQX_ALLYH", paras_qx, "table").Tables[0];
                return dt;
            }
            finally
            {
                db_yhqx.Close();
            }
        }

        private static DataTable Select_BMQX_PTYH()
        {
            DataTable dt = new DataTable();
            DBClass db_yhqx = new DBClass();
            try
            {
                OracleParameter[] paras_qx = {
                            new OracleParameter("p_cur", OracleType.Cursor)
                        };
                paras_qx[0].Direction = ParameterDirection.Output;
                dt = db_yhqx.RunProcedure("PACK_KG_YHJS.Select_BMQX_PTYH", paras_qx, "table").Tables[0];
                return dt;
            }
            finally
            {
                db_yhqx.Close();
            }
        }

        public static bool HasThisBMQX(int yhid, string qxdm)
        {
            if (dt_yhbmqx.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_yhbmqx.Select("yhid=" + yhid + "and qxdm='" + qxdm + "'").Length > 0 ? true : false;
            }
        }
        //查询该用户下有无角色（判断是否为普通员工）
        public static bool HasThisPTYH(int yhid, string jsdm)
        {
            if (dt_ptyh.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_ptyh.Select("jsdm='" + jsdm + "'" + " and yhid='" + yhid + "'").Length > 0 ? true : false;
            }
        }
        //查询用户部门权限
        public static bool HasThisBMQX(int yhid, string bmdm, string qxdm)
        {
            if (dt_yhbmqx.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_yhbmqx.Select("yhid='" + yhid + "'" + "and  bmdm='" + bmdm + "'" + "and qxdm='" + qxdm + "'").Length > 0 ? true : false;
            }
        }

        //查询子系统权限
        public static bool HasThisZXT(string zxt, int yhid)
        {
            if (dt_yhqx.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_yhqx.Select("zxt='" + zxt + "'" + "and yhid='" + yhid + "'").Length > 0 ? true : false;
            }
        }
        //查询模块权限
        public static bool HasThisMK(string mk, int yhid)
        {
            if (dt_yhqx.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_yhqx.Select("mk='" + mk + "'" + "and yhid='" + yhid + "'").Length > 0 ? true : false;
            }
        }
        //查询权限
        public static bool HasThisQX(string qxdm, int yhid, string dq)
        {
            if (dt_yhqx.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_yhqx.Select("qxdm='" + qxdm + "'" + "and yhid='" + yhid + "'" + "and dqdm='" + dq + "'").Length > 0 ? true : false;
            }
        }
        //查询权限
        public static bool HasThisQX(string qxdm, int yhid)
        {
            if (dt_yhqx.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return dt_yhqx.Select("qxdm='" + qxdm + "'" + "and yhid='" + yhid + "'").Length > 0 ? true : false;
            }
        }
        #endregion
        #endregion
        #region  ==============="pldw";//频率单位================
        private static DataTable dt_pldw = InitZDData(ZdType.PLDW);
        public static DataTable PLDW()
        {
            return dt_pldw;
        }
        private static Hashtable ht_pldw = FromZDDataTableToHashTable(dt_pldw);
        public static Struct_ZD PLDWByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_pldw[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============tcsfxy  投产是否限用================
        private static DataTable dt_tcsfxy = InitZDData(ZdType.TCSFXY);
        public static DataTable TCSFXY()
        {
            return dt_tcsfxy;
        }
        private static Hashtable ht_tcsfxy = FromZDDataTableToHashTable(dt_tcsfxy


            );
        public static Struct_ZD TCSFXYByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_tcsfxy[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="mcfxjyjg";//末次飞行校验结果================
        private static DataTable dt_mcfxjyjg = InitZDData(ZdType.MCFXJYJG);
        public static DataTable MCFXJYJG()
        {
            return dt_mcfxjyjg;
        }
        private static Hashtable ht_mcfxjyjg = FromZDDataTableToHashTable(dt_mcfxjyjg);
        public static Struct_ZD MCFXJYJGByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_mcfxjyjg[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ==============="fgfwdw";//覆盖范围单位================
        private static DataTable dt_fgfwdw = InitZDData(ZdType.FGFWDW);
        public static DataTable FGFWDW()
        {
            return dt_fgfwdw;
        }
        private static Hashtable ht_fgfwdw = FromZDDataTableToHashTable(dt_fgfwdw);
        public static Struct_ZD FGFWDWByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_fgfwdw[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============scgldw 输出功率单位================
        private static DataTable dt_scgldw = InitZDData(ZdType.SCGLDW);
        public static DataTable SCGLDW()
        {
            return dt_scgldw;
        }
        private static Hashtable ht_scgldw = FromZDDataTableToHashTable(dt_scgldw);
        public static Struct_ZD SCGLDWByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_scgldw[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============hxsblb 航向设备(仪表着陆系统LOC)类别================
        private static DataTable dt_hxsblb = InitZDData(ZdType.HXSBLB);
        public static DataTable HXSBLB()
        {
            return dt_hxsblb;
        }
        private static Hashtable ht_hxsblb = FromZDDataTableToHashTable(dt_hxsblb);
        public static Struct_ZD HXSBLBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_hxsblb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============hxsbtxzlx 航向设备(仪表着陆系统LOC)天线阵类型================
        private static DataTable dt_hxsbtxzlx = InitZDData(ZdType.HXSBTXZLX);
        public static DataTable HXSBTXZLX()
        {
            return dt_hxsbtxzlx;
        }
        private static Hashtable ht_hxsbtxzlx = FromZDDataTableToHashTable(dt_hxsbtxzlx);
        public static Struct_ZD HXSBTXZLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_hxsbtxzlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============xhsbtxzlx 下滑设备（仪表着陆系统GP)天线阵类型================
        private static DataTable dt_xhsbtxzlx = InitZDData(ZdType.XHSBTXZLX);
        public static DataTable XHSBTXZLX()
        {
            return dt_xhsbtxzlx;
        }
        private static Hashtable ht_xhsbtxzlx = FromZDDataTableToHashTable(dt_xhsbtxzlx);
        public static Struct_ZD XHSBTXZLXByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_xhsbtxzlx[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============cjyptsb 测距仪(DME)配套设备================
        private static DataTable dt_cjyptsb = InitZDData(ZdType.CJYPYSB);
        public static DataTable CJYPYSB()
        {
            return dt_cjyptsb;
        }
        private static Hashtable ht_cjyptsb = FromZDDataTableToHashTable(dt_cjyptsb);
        public static Struct_ZD CJYPYSBByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_cjyptsb[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion
        #region  ===============zdxblxxz 指点信标 类型选择================
        private static DataTable dt_zdxblxxz = InitZDData(ZdType.ZDXBLXXZ);
        public static DataTable ZDXBLXXZ()
        {
            return dt_zdxblxxz;
        }
        private static Hashtable ht_zdxblxxz = FromZDDataTableToHashTable(dt_zdxblxxz);
        public static Struct_ZD ZDXBLXXZByKey(string key)   //根据键值,返回一个结构
        {
            object obj = ht_zdxblxxz[key];
            Struct_ZD struct_ZD = new Struct_ZD();
            struct_ZD.bm = key;
            return (obj != null ? (Struct_ZD)obj : struct_ZD);
        }
        #endregion

    }
    
}