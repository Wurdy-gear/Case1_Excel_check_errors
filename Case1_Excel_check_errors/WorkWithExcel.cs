using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Case1_Excel_check_errors
{
    class WorkWithExcel
    {
        public Microsoft.Office.Interop.Excel.Application ObjExcel = null;
        public Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = null;
        public Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
        Thread thread;

        public WorkWithExcel(OpenFileDialog openFileDialog)
        {
            thread = new Thread(() => OpenFile(openFileDialog));
            thread.Start();//передача параметра в поток
        }

        public bool ThreadIsAlive()
        {
            if (thread.IsAlive)
            {
                return true;
            }
            else
                return false;
        }

        public void OpenFile(OpenFileDialog openFileDialog)
        {
            //Открываем файл Экселя
            try
            {
                //Создаём приложение.
                ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                //Открываем книгу.
                ObjWorkBook = ObjExcel.Workbooks.Open(openFileDialog.FileName, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //Выбираем таблицу(лист).
                ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии файла", "Ошибка");
                CloseExcel();
            }
        }

        public Microsoft.Office.Interop.Excel.Worksheet GetWorksheet()
        {
            return ObjWorkSheet;
        }

        public Microsoft.Office.Interop.Excel.Application GetApplication()
        {
            return ObjExcel;
        }

        public int LastRowCell()
        {
            int str = 0;
            int lastrow = ObjExcel.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;
            for (int i = lastrow; i >= 1; i--)
            {
                if (ObjExcel.Cells[i, 1].Value != null)
                {
                    str = i;
                    break;
                }
            }
            return str;
        }

        public void CloseExcel()
        {
            ObjWorkBook.Close();
            ObjExcel.Quit();
        }
    }
}
