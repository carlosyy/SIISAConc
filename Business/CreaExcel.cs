using System;
using System.IO;
using System.Reflection;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Business
{
    public class CreaExcel
    {
        /*Excel.Application xlApp = null;
        Excel._Workbook xlWB = null;
        Excel._Worksheet xlSheet = null;
        String strArchivo;

        public void ExportToExcel(String strFileName, String strSheetName)
        {
            strArchivo = strFileName;
            // Run the garbage collector
            GC.Collect();

            // Delete the file if it already exists
            if (System.IO.File.Exists(strFileName))
            {
                System.IO.File.SetAttributes(strFileName, FileAttributes.Normal);
                System.IO.File.Delete(strFileName);
            }

            // Open an instance of excel. Create a new workbook.
            // A workbook by default has three sheets, so if you just want a single one, delete sheet 2 and 3
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWB = (Excel._Workbook)xlApp.Workbooks.Add(Missing.Value);
            xlSheet = (Excel._Worksheet)xlWB.Sheets;

            ((Excel._Worksheet)xlWB.Sheets).Delete();
            ((Excel._Worksheet)xlWB.Sheets).Delete();

            xlSheet.Name = strSheetName;
            // Write a value into A1
        }

        public void generaFila(Int32 fila, Int32 columna, String valor)
        {
            xlSheet.Cells[fila, columna] = valor;
        }

        public void finalizaArchivo()
        {
            // Tell Excel to save your spreadsheet
            xlWB.SaveAs(strArchivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlApp.Quit();

            // Release the COM object, set the Excel variables to Null, and tell the Garbage Collector to do its thing
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWB);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            xlSheet = null;
            xlWB = null;
            xlApp = null;

            GC.Collect();
        }*/


    }

}