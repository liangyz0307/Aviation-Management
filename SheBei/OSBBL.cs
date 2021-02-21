using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public struct Struct_SBBL
    {
        public int p_id;
        public string p_sbbh;
        public string p_sblx;
        public string p_zxdm;
        public string p_sbmc;
        public string p_sbmcbz;
        public string p_dd;
        public string p_sygw;
        public string p_syr;
        public string p_synx;
        public DateTime p_gzsj;
        public DateTime p_gzkssj;
        public DateTime p_gzjssj;
        public string p_gzxx;
        public string p_gzyy;
        public string p_pgfs;
        public DateTime p_pgsj;
        public string p_bypc;
        public string p_wxry;
        public string p_bz;
        public string p_jlr;
        public DateTime p_jlsj;
        public string p_jlip;
        public string p_czfs;
        public string p_czxx;
        public int p_pagesize;
        public int p_currentpage;
    }
    public class OSBBL
    {
        private Struct_RZ_YH struct_RZ_YH = new Struct_RZ_YH();
        private RZ rz;
        private UserState _us = null;
        public OSBBL(UserState ygstate)
        {
            this._us = ygstate;
        }

        protected DataTable Select_SBBL_Pro(Struct_SBBL struct_SBBL) {
            DBClass db = new DBClass();
            try
            {
                OracleParameter[] op = {
                                         new OracleParameter("p_sblx" ,OracleType.VarChar),
                                       new OracleParameter("p_zxdm" ,OracleType.VarChar),
                                       new OracleParameter("p_sbmc" ,OracleType.VarChar),
                                       new OracleParameter("p_dd" ,OracleType.VarChar),
                                       new OracleParameter("p_gzxx" ,OracleType.VarChar),
                                       new OracleParameter("p_gzkssj" ,OracleType.DateTime),
                                       new OracleParameter("p_gzjssj" ,OracleType.DateTime),
                                       new OracleParameter("p_syr" ,OracleType.VarChar),
                                       new OracleParameter("p_wxry" ,OracleType.VarChar),
                                       new OracleParameter("p_pagesize" ,OracleType.Int32),
                                       new OracleParameter("p_currentpage" ,OracleType.Int32),
                                       new OracleParameter("p_cur" ,OracleType.Cursor),
                           };
                op[0].Value = struct_SBBL.p_sblx;
                op[1].Value = struct_SBBL.p_zxdm;
                op[2].Value = struct_SBBL.p_sbmc;
                op[3].Value = struct_SBBL.p_dd;
                op[4].Value = struct_SBBL.p_gzxx;
                op[5].Value = struct_SBBL.p_gzkssj;
                op[6].Value = struct_SBBL.p_gzjssj;
                op[7].Value = struct_SBBL.p_syr;
                op[8].Value = struct_SBBL.p_wxry;
                op[9].Value = struct_SBBL.p_pagesize;
                op[10].Value = struct_SBBL.p_currentpage;
                op[11].Direction = ParameterDirection.Output;
                DataTable dt = db.RunProcedure("PACK_SBGL_BL.Select_SBBL_Pro", op, "table").Tables[0];
                return dt;
            }
            finally{db.Close();}
        }
        protected int Select_SBBL_Count(Struct_SBBL struct_SBBL) {
            DBClass db = new DBClass();
            try {
                OracleParameter[] op = {
                                       new OracleParameter("p_sblx" ,OracleType.VarChar),
                                       new OracleParameter("p_zxdm" ,OracleType.VarChar),
                                       new OracleParameter("p_sbmc" ,OracleType.VarChar),
                                       new OracleParameter("p_dd" ,OracleType.VarChar),
                                       new OracleParameter("p_gzxx" ,OracleType.VarChar),
                                       new OracleParameter("p_gzkssj" ,OracleType.DateTime),
                                       new OracleParameter("p_gzjssj" ,OracleType.DateTime),
                                       new OracleParameter("p_syr" ,OracleType.VarChar),
                                       new OracleParameter("p_wxry" ,OracleType.VarChar),
                                       new OracleParameter("p_cur" ,OracleType.Cursor),
                };
                op[0].Value = struct_SBBL.p_sblx;
                op[1].Value = struct_SBBL.p_zxdm;
                op[2].Value = struct_SBBL.p_sbmc;
                op[3].Value = struct_SBBL.p_dd;
                op[4].Value = struct_SBBL.p_gzxx;
                op[5].Value = struct_SBBL.p_gzkssj;
                op[6].Value = struct_SBBL.p_gzjssj;
                op[7].Value = struct_SBBL.p_syr;
                op[8].Value = struct_SBBL.p_wxry;
                op[9].Direction = ParameterDirection.Output;
                int count = int.Parse( db.RunProcedure("PACK_SBGL_BL.Select_SBBL_Count", op, "table").Tables[0].Rows[0][0].ToString());
                return count;
            }
            finally { db.Close(); }
        }
        protected int Insert_SBBL(Struct_SBBL struct_SBBL) {
            DBClass db = new DBClass();
            int doNumber = 0;
            try
            {
                OracleParameter[] op = {
                                            new OracleParameter("p_sblx",OracleType.VarChar),
                                            new OracleParameter("p_zxdm",OracleType.VarChar),
                                            new OracleParameter("p_sbmc",OracleType.VarChar),
                                            new OracleParameter("p_sbmcbz",OracleType.VarChar),
                                            new OracleParameter("p_dd",OracleType.VarChar),
                                            new OracleParameter("p_sygw",OracleType.VarChar),
                                            new OracleParameter("p_syr",OracleType.VarChar),
                                            new OracleParameter("p_synx",OracleType.VarChar),
                                            new OracleParameter("p_gzsj",OracleType.DateTime),
                                            new OracleParameter("p_gzxx",OracleType.VarChar),
                                            new OracleParameter("p_gzyy",OracleType.VarChar),
                                            new OracleParameter("p_pgfs",OracleType.VarChar),
                                            new OracleParameter("p_pgsj",OracleType.DateTime),
                                            new OracleParameter("p_bypc",OracleType.VarChar),
                                            new OracleParameter("p_wxry",OracleType.VarChar),
                                            new OracleParameter("p_bz",OracleType.VarChar),
                                            new OracleParameter("p_jlr",OracleType.VarChar),
                                            new OracleParameter("p_jlsj",OracleType.DateTime),
                                            new OracleParameter("p_jlip",OracleType.VarChar),
                                            new OracleParameter("p_errorCode",OracleType.Int32),
                                            new OracleParameter("p_cur",OracleType.Cursor)
                };
                op[0].Value = struct_SBBL.p_sblx;
                op[1].Value = struct_SBBL.p_zxdm;
                op[2].Value = struct_SBBL.p_sbmc;
                op[3].Value = struct_SBBL.p_sbmcbz;
                op[4].Value = struct_SBBL.p_dd;
                op[5].Value = struct_SBBL.p_sygw;
                op[6].Value = struct_SBBL.p_syr;
                op[7].Value = struct_SBBL.p_synx;
                op[8].Value = struct_SBBL.p_gzsj;
                op[9].Value = struct_SBBL.p_gzxx;
                op[10].Value = struct_SBBL.p_gzyy;
                op[11].Value = struct_SBBL.p_pgfs;
                op[12].Value = struct_SBBL.p_pgsj;
                op[13].Value = struct_SBBL.p_bypc;
                op[14].Value = struct_SBBL.p_wxry;
                op[15].Value = struct_SBBL.p_bz;
                op[16].Value = _us.userLoginName;
                op[17].Value = DateTime.Now;
                op[18].Value = _us.IP;
                op[19].Direction = ParameterDirection.Output;
                op[20].Direction = ParameterDirection.Output;

                int id = Convert.ToInt32(db.RunProcedure("PACK_SBGL_BL.Insert_SBBL", op, "table").Tables[0].Rows[0][0]);

                int p_errorCode = Convert.ToInt32(op[19].Value);
                if (p_errorCode != 0)
                {
                    throw new EMException(p_errorCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_SBBL.p_czfs;
                struct_RZ_YH.czxx = struct_SBBL.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
                return id;
            }
            finally { db.Close(); }
        }
        protected void Update_SBBL(Struct_SBBL struct_SBBL) {
            DBClass db = new DBClass();
            int doNumber = 0;
            try {
                OracleParameter[] op = {
                                                new OracleParameter("p_sblx",OracleType.VarChar),
                                                new OracleParameter("p_zxdm",OracleType.VarChar),
                                                new OracleParameter("p_sbmc",OracleType.VarChar),
                                                new OracleParameter("p_sbmcbz",OracleType.VarChar),
                                                new OracleParameter("p_dd",OracleType.VarChar),
                                                new OracleParameter("p_sygw",OracleType.VarChar),
                                                new OracleParameter("p_syr",OracleType.VarChar),
                                                new OracleParameter("p_synx",OracleType.VarChar),
                                                new OracleParameter("p_gzsj",OracleType.DateTime),
                                                new OracleParameter("p_gzxx",OracleType.VarChar),
                                                new OracleParameter("p_gzyy",OracleType.VarChar),
                                                new OracleParameter("p_pgfs",OracleType.VarChar),
                                                new OracleParameter("p_pgsj",OracleType.DateTime),
                                                new OracleParameter("p_bypc",OracleType.VarChar),
                                                new OracleParameter("p_wxry",OracleType.VarChar),
                                                new OracleParameter("p_bz",OracleType.VarChar),
                                                new OracleParameter("p_errorCode",OracleType.Int32)
                                };
                op[0].Value = struct_SBBL.p_sblx;
                op[1].Value = struct_SBBL.p_zxdm;
                op[2].Value = struct_SBBL.p_sbmc;
                op[3].Value = struct_SBBL.p_sbmcbz;
                op[4].Value = struct_SBBL.p_dd;
                op[5].Value = struct_SBBL.p_sygw;
                op[6].Value = struct_SBBL.p_syr;
                op[7].Value = struct_SBBL.p_synx;
                op[8].Value = struct_SBBL.p_gzsj;
                op[9].Value = struct_SBBL.p_gzxx;
                op[10].Value = struct_SBBL.p_gzyy;
                op[11].Value = struct_SBBL.p_pgfs;
                op[12].Value = struct_SBBL.p_pgsj;
                op[13].Value = struct_SBBL.p_bypc;
                op[14].Value = struct_SBBL.p_wxry;
                op[15].Value = struct_SBBL.p_bz;
                op[16].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_SBGL_BL.Update_SBBL", op, out doNumber);
                int p_errorCode = Convert.ToInt32(op[16].Value);
                if (p_errorCode != 0) {
                    throw new EMException(p_errorCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = struct_SBBL.p_czfs;
                struct_RZ_YH.czxx = struct_SBBL.p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally { db.Close(); }
        }
        protected void Delete_SBBL(int p_id, string p_czfs, string p_czxx) {
            DBClass db = new DBClass();
            int doNumber = 0;
                try {
                OracleParameter[] op = {
                             new OracleParameter("p_id" , OracleType.Number),
                             new OracleParameter("p_errorCode" , OracleType.Int32)
                };
                op[0].Value = p_id;
                op[1].Direction = ParameterDirection.Output;
                db.RunProcedure("PACK_SBGL_BL.Delete_SBBL", op, out doNumber);
                int p_errorCode = Convert.ToInt32(op[1].Value);
                if (p_errorCode != 0) {
                    throw new EMException(p_errorCode);
                }
                rz = new RZ(_us);
                struct_RZ_YH.czfs = p_czfs;
                struct_RZ_YH.czxx = p_czxx;
                rz.RZ_Insert_CZ(struct_RZ_YH);
            }
            finally { db.Close(); }
            
        }
        protected DataTable Select_SBBLbyID(int p_id) {
            DBClass db = new DBClass();
                try {
                OracleParameter[] op = {
                     new OracleParameter("p_id" , OracleType.Number),
                     new OracleParameter("p_cur" , OracleType.Cursor)
                };
                op[0].Value = p_id;
                op[1].Direction = ParameterDirection.Output;
                return db.RunProcedure("PACK_SBGL_BL.Select_SBBLbyID", op, "table").Tables[0];
            }
            finally { db.Close(); }
            
        }
    }
    
}
