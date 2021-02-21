using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using System.Collections;
using System.Web;
using CUST.Sys;
using NPOI.HSSF.Util;
using NPOI.HSSF.Model;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System.Windows.Forms;
using Sys;

namespace CUST.MXQ
{

    public class NPOI_Excel
    {
        #region  导入
        /// <summary>  
        /// 将excel导入到datatable  
        /// </summary>  
        /// <param name="filePath">excel路径</param>  
        /// <param name="isColumnName">第一行是否是列名</param>  
        /// <returns>返回datatable</returns>  
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook(fs);
            int sheetCount = book.NumberOfSheets;
            for (int sheetIndex = 0; sheetIndex < sheetCount; sheetIndex++)
            {
                NPOI.SS.UserModel.ISheet sheet = book.GetSheetAt(sheetIndex);
                if (sheet == null) continue;
         
                NPOI.SS.UserModel.IRow row = sheet.GetRow(0);
                if (row == null) continue;

                int firstCellNum = row.FirstCellNum;
                int lastCellNum = row.LastCellNum;   //相当于列数
                if (firstCellNum == lastCellNum) continue;

                dt = new DataTable(sheet.SheetName);
                //表头
                for (int i = firstCellNum; i < lastCellNum; i++)
                {
                    dt.Columns.Add(row.GetCell(i).StringCellValue, typeof(string));
                }
                bool sfhb =false;
                int rowSpan = 0; 
                int columnSpan;
                int j;
                //填充行
                for (int i = 1; i <= sheet.LastRowNum; i++)  //行数
                {
                    DataRow newRow = dt.Rows.Add();
                    for ( j = firstCellNum; j < lastCellNum; j++)//列数  每一行赋值完再下一行
                    {
                         ICell cell = row.GetCell(j);
                         // newRow[j] = sheet.GetRow(i).GetCell(j).StringCellValue;row.GetCell(j).CellType
                         //string ssa = sheet.GetRow(i).GetCell(j).CellType.ToString();
                         switch (sheet.GetRow(i).GetCell(j).CellType)
                         {
                             case CellType.Numeric:
                                 if (HSSFDateUtil.IsCellDateFormatted(sheet.GetRow(i).GetCell(j)))//日期类型
                                 {
                                     newRow[j] = sheet.GetRow(i).GetCell(j).DateCellValue.ToString("yyyy-MM-dd");
                                     
                                 }
                                 else//其他数字类型
                                 {
                                     newRow[j] = sheet.GetRow(i).GetCell(j).NumericCellValue;
                                     
                                 }
                                 break;
                             case CellType.Blank:
                                 newRow[j] = string.Empty;
                                 break;
                            
                             default:
                                 newRow[j] = sheet.GetRow(i).GetCell(j).StringCellValue;
                                 break;

                         }
                         if (newRow[j].ToString() == "")
                         {
                             sfhb = ExcelExtension.IsMergeCell(sheet, i, j, out  rowSpan, out columnSpan);  //合并单元格行列个数
                             Dimension dimension = new Dimension();
                             bool q1 = ExcelExtension.IsMergeCell(sheet, i, j, out dimension);
                             if (i == sheet.LastRowNum)  //最后一行识别不超过一合并了   没找到原因
                             {
                                 sfhb = true;
                                 q1 = true;
                             }
                             if (sfhb)
                             {
                                // newRow[j] = sheet.GetRow(dimension.FirstRowIndex).GetCell(j).StringCellValue;
                                 switch (sheet.GetRow(dimension.FirstRowIndex).GetCell(j).CellType)
                                 {
                                     case CellType.Numeric:
                                         if (HSSFDateUtil.IsCellDateFormatted(sheet.GetRow(dimension.FirstRowIndex).GetCell(j)))//日期类型
                                         {
                                             newRow[j] = sheet.GetRow(dimension.FirstRowIndex).GetCell(j).DateCellValue.ToString("yyyy-MM-dd");

                                         }
                                         else//其他数字类型
                                         {
                                             newRow[j] = sheet.GetRow(dimension.FirstRowIndex).GetCell(j).NumericCellValue;

                                         }
                                         break;
                                     case CellType.Blank:
                                         newRow[j] = string.Empty;
                                         break;

                                     default:
                                         newRow[j] = sheet.GetRow(dimension.FirstRowIndex).GetCell(j).StringCellValue;
                                         break;

                                 }
                                // string xz = newRow[j].ToString();
                             }
                         }    
                    }
                }
                
                ds.Tables.Add(dt);
            }
            return dt;
        }

      
    }
        #endregion
}
