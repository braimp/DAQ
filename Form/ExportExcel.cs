using System;
using System.Diagnostics;
using System.Windows.Forms;
using Telerik.WinControls.UI;
public class ExportExcel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt"></param>
    public void DataExportExcel(RadGridView dt)
    {
        //bool fileSaved = false;
        //SaveFileDialog saveDialog = new SaveFileDialog();
        //saveDialog.DefaultExt = "xls";
        //saveDialog.Filter = "Excel文件|*.xls";
        //saveDialog.FileName = "采集结果 " + DateTime.Today.ToString("yyyy-MM-dd");
        //saveDialog.ShowDialog();
        //string saveFileName = saveDialog.FileName;
        //if (saveFileName.IndexOf(":") < 0)
        //{
        //    return; //被点了取消
        //}
        //if (dt == null || dt.Rows.Count == 0) { return; }
        //var xlApp = new Microsoft.Office.Interop.Excel.Application();
        //var workbooks = xlApp.Workbooks;
        //var workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
        //var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
        //try
        //{

        //    for (int i = 0; i < dt.Columns.Count; i++)
        //    {
        //        var p = i + 1;
        //        if (p < dt.Columns.Count)
        //        {
        //            worksheet.Cells[1, i + 1] = dt.Columns[p].HeaderText;
        //            var range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, p + 1];

        //            range.Font.Bold = true;
        //            range.ColumnWidth = 30;
        //            range.RowHeight = 30;
        //            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //        }
        //    }

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {

        //        for (int j = 0; j < dt.Columns.Count; j++)
        //        {
        //            var p = j + 1;
        //            if (p < dt.Columns.Count)
        //            {
        //                if (dt.Rows[i].Cells[p].GetType() == typeof(string))
        //                {

        //                    worksheet.Cells[i + 2, j + 1] = "" + dt.Rows[i].Cells[p].Value;
        //                    var range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 2, j + 1];
        //                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //                    range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //                    if (i + 1 < dt.Rows.Count)
        //                    {
        //                        if (dt.Rows[i].Cells[1].Value.ToString().Trim() == dt.Rows[i + 1].Cells[1].Value.ToString().Trim())
        //                        {
        //                            worksheet.Range[worksheet.Cells[i + 2, 1], worksheet.Cells[i + 3, 1]].Merge();
        //                        }
        //                    }


        //                }
        //                else
        //                {

        //                    worksheet.Cells[i + 2, j + 1] = dt.Rows[i].Cells[p].Value.ToString();
        //                    var range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 2, j + 1];
        //                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //                    range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        //                    if (i + 1 < dt.Rows.Count)
        //                    {
        //                        if (dt.Rows[i].Cells[1].Value.ToString().Trim() == dt.Rows[i + 1].Cells[1].Value.ToString().Trim())
        //                        {
        //                            worksheet.Range[worksheet.Cells[i + 2, 1], worksheet.Cells[i + 3, 1]].Merge();

        //                        }
        //                    }
        //                }

        //            }

        //        }

        //    }
        //    workbook.Saved = true;
        //    workbook.SaveCopyAs(saveFileName);
        //    OpenFile(saveFileName);
        //}
        //catch
        //{

        //}
        //finally
        //{
        //    worksheet.ClearArrows();
        //    worksheet.ClearCircles();
        //    // workbook.Close();
        //    //  workbooks.Close();
        //    //xlApp.Quit();
        //    NAR(worksheet);
        //    // workbook.Close();
        //    NAR(workbook);
        //    // xlApp.Quit();
        //    NAR(xlApp);
        //}
    }
    /// <summary>
    /// 释放资源
    /// </summary>
    /// <param name="o"></param>
    private void NAR(object o)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
        }
        catch { }
        finally
        {

            o = null;

        }

    }

    private void OpenFile(string filepath)
    {
        Process.Start(filepath);
    }
}