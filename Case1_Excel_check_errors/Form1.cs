using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Case1_Excel_check_errors
{
    public partial class Form1 : Form
    {
        #region variables

        Microsoft.Office.Interop.Excel.Application ObjExcel = null;
        Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = null;
        Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;

        Microsoft.Office.Interop.Excel.Range Material_range = null;
        Microsoft.Office.Interop.Excel.Range Zapas_range = null;
        Microsoft.Office.Interop.Excel.Range DefaultPrice_range = null;
        Microsoft.Office.Interop.Excel.Range TotalPrice_range = null;
        Microsoft.Office.Interop.Excel.Range NextMaterial_range = null;
        Microsoft.Office.Interop.Excel.Range NumberDocument_range = null;

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Открываем файл Экселя
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Создаём приложение.
                    ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                    //Открываем книгу.
                    ObjWorkBook = ObjExcel.Workbooks.Open(OpenFileDialog.FileName, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                    //Выбираем таблицу(лист).
                    ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии файла", "Ошибка");
                    ObjExcel.Quit();
                }

                
                Thread ChecksumsThread = new Thread(new ThreadStart(Checksums));
                ChecksumsThread.Priority = ThreadPriority.Highest;
                ChecksumsThread.Start();
                

            }
        }

        private void Checksums() //Проверка при помощи сложения всех цен одного материала и последующего сравнения с итоговой ценой в обоих таблицах
        {
            try 
            {
                #region variables

                List<Material> OstatkiMaterial_list = new List<Material>();
                List<Material> Saldomaterial_list = new List<Material>();

                double SummOfAllMaterial_double = 0;
                double TotalPrice_double = 0;
                double PriceSaldo_double = 0;

                double SummOfAllMaterialOstatkiTable_double = 0;
                double SummOfAllMaterialSaldoTable_double = 0;

                double SaldoTotalPrice_double = 0;

                double NextMaterial_double = 0;
                long Material_double = 0;

                #endregion

                for (int i = 2; i <= 56606; i++) //проверка сумм в таблице сальдо //56606
                {
                    Material_range = ObjWorkSheet.Range["S" + i.ToString()];
                    NumberDocument_range = ObjWorkSheet.Range["N" + i.ToString()];
                    TotalPrice_range = ObjWorkSheet.Range["T" + i.ToString()];

                    if (NumberDocument_range.Value as string == "" || NumberDocument_range.Value == null)//Проверка на строку с итоговой суммой
                    {
                        Material_double = Convert.ToInt64(Material_range.Value);

                        TotalPrice_double = Convert.ToDouble(TotalPrice_range.Value); //Итоговая сумма материала

                        double alpha = Math.Abs(SummOfAllMaterial_double - TotalPrice_double);

                        SummOfAllMaterialSaldoTable_double += TotalPrice_double;//Общая сумма всей таблицы сальдо

                        if (TotalPrice_double != 0)//Если итоговая сумма не 0 то добавляем в список для дальнейшей работы
                        {
                            Saldomaterial_list.Add(new Material()
                            {
                                IDMaterial = Convert.ToInt64(Material_range.Value),
                                TotalPrice = Convert.ToDouble(TotalPrice_range.Value)
                            });
                        }

                        if (EqualTo(SummOfAllMaterial_double, TotalPrice_double))
                        {
                            //Все сходится
                            SummOfAllMaterial_double = 0;

                            if(TotalPrice_double < 0)
                            {
                                SumErrorRichTextBox.Text += "Внимание отрицательная сумма сальдо в строке: " + i.ToString() + " \n";
                                SumErrorRichTextBox.Text += "Материал: " + Material_double + " \n";
                                SumErrorRichTextBox.Text += "Сумма: " + TotalPrice_double + " \n\n";
                            }
                        }
                        else
                        {
                            SummOfAllMaterial_double = 0;
                            SumErrorRichTextBox.Text += "Сумма составляющих материала " + Convert.ToInt64(Material_range.Value) + " не сходятся в строке: " + i.ToString() + " \n";
                            SumErrorRichTextBox.Text += "Разница составила: " + alpha + " \n\n";
                        }
                    }
                    else
                    {
                        SummOfAllMaterial_double += Convert.ToDouble(TotalPrice_range.Value);//Сложение состовляющих цен материала
                    }
                    SumProgressBar.PerformStep();
                }

                SummOfAllMaterial_double = 0;
                for (int i = 2; i <= 9251; i++) //проверка сумм в таблице остатков //9251
                {
                    Material_range = ObjWorkSheet.Range["D" + i.ToString()];
                    Zapas_range = ObjWorkSheet.Range["H" + i.ToString()];
                    DefaultPrice_range = ObjWorkSheet.Range["I" + i.ToString()];
                    TotalPrice_range = ObjWorkSheet.Range["K" + i.ToString()];

                    if (Zapas_range.Value == null || Zapas_range.Value as string == "")
                    {
                        Material_double = Convert.ToInt64(Material_range.Value);

                       // SummOfAllMaterial_double = OstatkiMaterial_list.Sum(n => n.TotalPrice);

                        TotalPrice_double = Convert.ToDouble(TotalPrice_range.Value);

                        SummOfAllMaterialOstatkiTable_double += TotalPrice_double;//Общая сумма всей таблицы остатков

                        double alpha = Math.Abs(SummOfAllMaterial_double - TotalPrice_double);

                        var FoundMaterial = Saldomaterial_list.Find(n => n.IDMaterial == Material_double);//Проверка на существование материала в таблице сальдо


                        OstatkiMaterial_list.Add(new Material()
                        {
                            IDMaterial = Convert.ToInt64(Material_range.Value),
                            TotalPrice = Convert.ToDouble(TotalPrice_range.Value)
                        });

                        if (FoundMaterial != null)
                        {
                            if (EqualTo(SummOfAllMaterial_double, TotalPrice_double))
                            {
                                //все круто
                                SummOfAllMaterial_double = 0;
                            }
                            else
                            {
                                SummOfAllMaterial_double = 0;
                                MaterialSumErrorRichTextBox.Text += "Материал " + FoundMaterial.IDMaterial.ToString() + " имеет расхождения в таблицах" + "\n\n";
                                SumErrorRichTextBox.Text += "Разница составила " + alpha + " \n\n";
                            }
                        }
                        else
                        {
                            MaterialSumErrorRichTextBox.Text += "Материал с ID " + Material_double.ToString() + " не найден в таблице сальдо" + "\n";
                        }
                    }
                    else
                    {
                        SummOfAllMaterial_double += Convert.ToDouble(TotalPrice_range.Value);//Сложение состовляющих цен материала               
                    }
                    SumProgressBar.PerformStep();
                }

                var fruitsList3 = Saldomaterial_list.Where(f1 => OstatkiMaterial_list.All(f2 => f2.IDMaterial != f1.IDMaterial));//Проверка на существование материала в таблице остатков

                foreach (var val in fruitsList3)
                {
                    MaterialSumErrorRichTextBox.Text += "Материал с ID " + val.IDMaterial.ToString() + " не найден в таблице остатков" + "\n";
                }
                

                SumErrorRichTextBox.Text += "Итоговая сумма таблицы остатков составила: " + SummOfAllMaterialOstatkiTable_double + " \n\n";
                SumErrorRichTextBox.Text += "Итоговая сумма сальдо таблицы составила: " + SummOfAllMaterialSaldoTable_double + " \n\n";
                SumErrorRichTextBox.Text += "Разница таблиц составила: " + Math.Abs(SummOfAllMaterialOstatkiTable_double - SummOfAllMaterialSaldoTable_double) + " \n\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке контрольных сумм" + ex.ToString(),"Ошибка");
                ObjExcel.Quit();
            } 
        }

        private void CheckMultiplyQuantityByPrice()//Проверка с помощью перемножения количества на стандартную стоимость с последующей сверкой с итоговой ценой
        {
            try
            {
                double Zapas_double;
                double DefaultPrice_double;
                double TotalPrice_double;

                for (int i = 2; i <= 9251; i++)
                {
                    Zapas_range = ObjWorkSheet.Range["H" + i.ToString()];
                    DefaultPrice_range = ObjWorkSheet.Range["I" + i.ToString()];
                    TotalPrice_range = ObjWorkSheet.Range["K" + i.ToString()];

                    if (Zapas_range.Value == null)
                    {

                    }
                    else
                    {
                        Zapas_double = Convert.ToDouble(Zapas_range.Value);
                        DefaultPrice_double = Convert.ToDouble(DefaultPrice_range.Value);
                        TotalPrice_double = Convert.ToDouble(TotalPrice_range.Value);

                        double ExpectedTotalPrice_double = Zapas_double * DefaultPrice_double;
                        double alpha = ExpectedTotalPrice_double - TotalPrice_double;

                        if (EqualTo(ExpectedTotalPrice_double, TotalPrice_double))
                        {
                            //все круто
                        }
                        else
                        {
                            SumErrorRichTextBox.Text += "Перемножение неверно в строке" + i.ToString() + "\n";
                            SumErrorRichTextBox.Text += "Разница составила:" + alpha + "\n\n";
                        }
                    }
                    MultiplyProgressBar.PerformStep();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке перемножения" + ex.ToString(), "Ошибка");
                ObjExcel.Quit();
            }
        }

        private bool EqualTo(double value1, double value2)
        {
            double epsilon = 0.01;
            return Math.Abs(value1 - value2) < epsilon;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ObjExcel != null)
            { 
                ObjExcel.Quit();
            }
        }
    }
}
