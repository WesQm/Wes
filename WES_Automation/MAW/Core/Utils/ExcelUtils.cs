using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Specialized;
using System.Data;

namespace WESHybridFramework.Core.Utils
{
    class ExcelUtils
    {


        //.....

        public static DataTable readData(string filePath, string sheetName)
        {
            DataTable dt = new DataTable();

            XSSFWorkbook xssfwb;
            // IList<ListDictionary> listDict = new List<ListDictionary>();

            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                xssfwb = new XSSFWorkbook(file);
            }
            string value = null;
            ISheet sheet = xssfwb.GetSheet(sheetName);
            for (int i = 0; i < sheet.GetRow(0).LastCellNum; i++)
            {
                dt.Columns.Add(new DataColumn() { ColumnName = sheet.GetRow(0).GetCell(i).StringCellValue, DataType = typeof(string) });
            }
            int lastRowIndex = sheet.LastRowNum;
            for (int row = 1; row <= lastRowIndex; row++)
            {

                IRow Row = sheet.GetRow(row);
                /* if (Row != null)
                 {
                     int lastColumnIndex = Row.LastCellNum;
                     for (int column = 0; column < lastColumnIndex; column++)
                     {
                         ICell cell = Row.GetCell(column);
                         if (cell != null)
                         {
                             switch (cell.CellType)
                             {
                                 case CellType.Numeric: 
                                     value = cell.NumericCellValue.ToString(); break;
                                 case CellType.String: value =cell.StringCellValue; break;
                                 default: value = "Default"; break;
                             }
                         }
                         else {
                             value = "Default";
                         }

                     }
                 }*/
                dt.Rows.Add(Row);
            }
            return dt;
        }

    }
}
