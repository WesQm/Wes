using Syncfusion.XlsIO;
using System.Data;
using System.IO;
using System.Reflection;

namespace WESHybridFramework.Core.Utils
{
    class ExcelDataUtils
    {
        public static DataTable getData(string fileName, int sheetNo)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            FileStream inputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            IWorkbook workbook = application.Workbooks.Open(inputStream);
            IWorksheet worksheet = workbook.Worksheets[sheetNo];
            DataTable Table = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
            return Table;
        }

    }

}
