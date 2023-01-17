using GS_DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace GS_Project
{
    public class ExcelUtil
   {
      public static string ExcelExportListDTO<T>(List<T> list, string fileName, string exceptProperty)
      {
         Excel.Application xlApp = new Excel.Application();//엑셀프로그램
         Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();//엑셀파일 
         Excel.Worksheet xlWorksheet = xlWorkBook.Worksheets.get_Item(1);//엑셀시트

         try
         {
            //컬럼헤더를 찍어준다.(DTO의 속성명으로 컬럼헤더를 찍는다)
            int c = 0;
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
               if (!exceptProperty.Contains(prop.Name))
               {
                  xlWorksheet.Cells[1, c + 1] = prop.Name;
                  c++;
               }
            }

            //데이터를 찍어준다.
            for (int r = 0; r < list.Count; r++)
            {
               c = 0;
               foreach (PropertyInfo prop in typeof(T).GetProperties())
               {
                  if (!exceptProperty.Contains(prop.Name))
                  {
                     if (prop.GetValue(list[r], null) != null)
                     {
                        xlWorksheet.Cells[r + 2, c + 1] = prop.GetValue(list[r], null).ToString();
                     }
                     c++;
                  }
               }
            }

            xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);
            xlWorkBook.Close();
            xlApp.Quit();

            return null;
         }
         catch (Exception err)
         {
            return err.Message;
         }
         finally
         {
            releaseObject(xlWorksheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
         }
      }

      private static void releaseObject(object obj)
      {
         try
         {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
         }
         catch (Exception ex)
         {
            obj = null;
            //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
         }
         finally
         {
            GC.Collect();
         }
      }
      public static bool PurChaseExcel(IncomeDTO purchase, List<IncomeDetailDTO> details, string fileName)
      {
         Excel.Application xlApp = new Excel.Application();
         string path = Application.StartupPath;
         Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path + @"\Templates\incomeReport.xlsx");
         Excel.Worksheet xlWorksheet = xlWorkBook.Worksheets.get_Item(1);
         xlWorksheet.Name = purchase.INCOME_COMPANY_NAME;
         try
         {

            xlWorksheet.Cells[2, 2] = purchase.INCOME_COMPANY_NAME;
            xlWorksheet.Cells[2, 7] = purchase.INCOME_STATE_NAME;
            for (int i = 0; i < details.Count; i++)
            {
               xlWorksheet.Cells[i + 4, 1] = i;
               xlWorksheet.Cells[i + 4, 2] = details[i].INCOME_DETAIL_PRODUCT_NAME;
               xlWorksheet.Cells[i + 4, 3] = purchase.INCOME_ORDER_DATE;
               xlWorksheet.Cells[i + 4, 4] = details[i].INCOME_DETAIL_PRODUCT_QYT;
               xlWorksheet.Cells[i + 4, 5] = details[i].INCOME_DETAIL_PRODUCT_QYT_CHECK;
               xlWorksheet.Cells[i + 4, 6] = details[i].INCOME_DETAIL_PRODUCT_PRICE;
            }
            xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);
            xlWorkBook.Close();
            xlApp.Quit();
            return true;
         }
         catch (Exception err)
         {
            Debug.WriteLine(err.StackTrace);
            return false;
         }
         finally
         {
            releaseObject(xlWorksheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
         }
      }
      public static bool PurChaseExcelAll(List<IncomeDTO> purchases, List<IncomeDetailDTO> details, string fileName)
      {
         Excel.Application xlApp = new Excel.Application();
         string path = Application.StartupPath;
         Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path + @"\Templates\incomeReport.xlsx");
         Excel.Worksheet xlWorksheet = null;
         try
         {
            for (int i = 0; i < purchases.Count; i++)
            {
               xlWorksheet = xlWorkBook.Worksheets.get_Item(i + 1);
               xlWorksheet.Name = purchases[i].INCOME_COMPANY_NAME + "(" + purchases[i].INCOME_ORDER_DATE + ")" + i;
               if(i + 1 < purchases.Count)
               xlWorksheet.Copy(Type.Missing, xlWorkBook.Sheets[i + 1]);

               var list = details.FindAll((d) => d.INCOME_DETAIL_NUM.Equals(purchases[i].INCOME_NUM));

               xlWorksheet.Cells[2, 2] = purchases[i].INCOME_COMPANY_NAME;
               xlWorksheet.Cells[2, 7] = purchases[i].INCOME_STATE_NAME;
               for (int j = 0; j < list.Count; j++)
               {
                  xlWorksheet.Cells[j + 4, 1] = j;
                  xlWorksheet.Cells[j + 4, 2] = list[j].INCOME_DETAIL_PRODUCT_NAME;
                  xlWorksheet.Cells[j + 4, 3] = purchases[i].INCOME_ORDER_DATE;
                  xlWorksheet.Cells[j + 4, 4] = list[j].INCOME_DETAIL_PRODUCT_QYT;
                  xlWorksheet.Cells[j + 4, 5] = list[j].INCOME_DETAIL_PRODUCT_QYT_CHECK;
                  xlWorksheet.Cells[j + 4, 6] = list[j].INCOME_DETAIL_PRODUCT_PRICE;
               }
            }
            xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);
            xlWorkBook.Close();
            xlApp.Quit();
            return true;
         }
         catch (Exception err)
         {
            Debug.WriteLine(err.StackTrace);
            Debug.WriteLine(err.Message);
            return false;
         }
         finally
         {
            releaseObject(xlWorksheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
         }
      }

        public static bool OrderExcel(OrderDTO order, List<OrderDetailDTO> detail, string fileName)
        {
            Excel.Application xlApp = new Excel.Application();
            string path = Application.StartupPath;
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path + @"\Templates\OrderReport.xlsx");
            Excel.Worksheet xlWorksheet = null;
            try
            {
                xlWorksheet = xlWorkBook.Worksheets.get_Item(1);
                xlWorksheet.Name = order.ORDER_NUM.ToString() + order.ORDER_COMPANY_NAME + "(" + order.ORDER_DATE + ")";

                var list = detail.FindAll((d) => d.ORDER_DETAIL_NUM.Equals(order.ORDER_NUM));

                xlWorksheet.Cells[2, 2] = order.ORDER_COMPANY_NAME;
                xlWorksheet.Cells[2, 7] = order.ORDER_STATE_NAME;
                for (int i = 0; i < list.Count; i++)
                {
                    xlWorksheet.Cells[i + 4, 1] = list[i].ORDER_DETAIL_NUM;
                    xlWorksheet.Cells[i + 4, 2] = list[i].ORDER_PRODUCT_NAME;
                    xlWorksheet.Cells[i + 4, 3] = order.ORDER_DATE;
                    xlWorksheet.Cells[i + 4, 4] = list[i].ORDER_DETAIL_PRODUCT_QTY;
                    xlWorksheet.Cells[i + 4, 5] = list[i].ORDER_DETAIL_PRODUCT_PRICE;
                    xlWorksheet.Cells[i + 4, 6] = list[i].ORDER_TOTAL_PRICE;
                }
            
            xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);
            xlWorkBook.Close();
            xlApp.Quit();
            return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                Debug.WriteLine(err.Message);
                return false;
            }
            finally
            {
                releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
        }
        public static bool ReleaseReport(ReleaseDTO release, List<ReleaseDetailDTO> details, string fileName)
        {
            Excel.Application xlApp = new Excel.Application();
            string path = Application.StartupPath;
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path + @"\Templates\releaseReport2.xlsx");
            Excel.Worksheet xlWorksheet = xlWorkBook.Worksheets.get_Item(1);
            xlWorksheet.Name = release.COMPANY_NAME + " - " + DateTime.Now.ToString("yyyy-MM-dd");
            try
            {

                xlWorksheet.Cells[2, 2] = release.COMPANY_NAME;
                xlWorksheet.Cells[2, 5] = release.OUTCOME_DATE;
                xlWorksheet.Cells[26, 4] = release.OUTCOME_USER;
                for (int i = 0; i < details.Count; i++)
                {
                    xlWorksheet.Cells[i + 4, 1] = details[i].OUTCOME_DETAIL_NUM;
                    xlWorksheet.Cells[i + 4, 2] = details[i].OUTCOME_DETAIL_PRODUCT_NAME;
                    xlWorksheet.Cells[i + 4, 3] = details[i].OUTCOME_DETAIL_PRODUCT_QTY;
                    xlWorksheet.Cells[i + 4, 4] = details[i].OUTCOME_DETAIL_PRODUCT_PRICE / details[i].OUTCOME_DETAIL_PRODUCT_QTY;
                }
                xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);
                xlWorkBook.Close();
                xlApp.Quit();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.StackTrace);
                return false;
            }
            finally
            {
                releaseObject(xlWorksheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
        }
    }
}
