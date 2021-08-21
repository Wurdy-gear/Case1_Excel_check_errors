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
using System.Diagnostics;

namespace Case1_Excel_check_errors
{
    public partial class Form1 : Form
    {
        #region variables

        WorkWithExcel SaldoFile = new WorkWithExcel();
        WorkWithExcel OstatkiFile = new WorkWithExcel();

        Microsoft.Office.Interop.Excel.Range Material_range = null;
        Microsoft.Office.Interop.Excel.Range Zapas_range = null;
        Microsoft.Office.Interop.Excel.Range DefaultPrice_range = null;
        Microsoft.Office.Interop.Excel.Range TotalPrice_range = null;
        Microsoft.Office.Interop.Excel.Range NumberDocument_range = null;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void ChooseSaldoFileButton_Click(object sender, EventArgs e) //Открытие сальдо отчёта
        {
            ChooseSaldoFileButton.Enabled = false;
            if (OpenFileDialogForSaldo.ShowDialog() == DialogResult.OK)
            {
                if(SaldoFile.GetApplication() != null)
                {
                    SaldoFile.CloseExcel();
                }
                SaldoFile = new WorkWithExcel(OpenFileDialogForSaldo);

                timer1.Enabled = true;//Запуск таймера для проверки окончания открытия файлов
                timer1.Start();
                ChooseSaldoFileButton.Enabled = false;
            }
            else
            {

            }
            LabelForSelectedFilenameSaldo.Text = OpenFileDialogForSaldo.SafeFileName;
        }

        private void ChooseOstatkiFileButton_Click(object sender, EventArgs e) //Открытие отчета по остаткам
        {
            ChooseOstatkiFileButton.Enabled = false;
            if (OpenFileDialogForOstatki.ShowDialog() == DialogResult.OK)
            {
                if (OstatkiFile.GetApplication() != null)
                {
                    OstatkiFile.CloseExcel();
                }

                OstatkiFile = new WorkWithExcel(OpenFileDialogForOstatki);

                timer1.Enabled = true;//Запуск таймера для проверки окончания открытия файлов
                timer1.Start();
                ChooseOstatkiFileButton.Enabled = false;
            }
            else
            {

            }
            LabelForSelectedFilenameOstatki.Text = OpenFileDialogForOstatki.SafeFileName;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Thread ChecksumsThread = new Thread(new ThreadStart(Checksums));
            ChecksumsThread.Priority = ThreadPriority.Highest;
            ChecksumsThread.Start();

            ChooseSaldoFileButton.Enabled = false;
            ChooseOstatkiFileButton.Enabled = false;
            StartButton.Enabled = false;

            SumErrorRichTextBox.Clear();
            MaterialSumErrorRichTextBox.Clear();
            MultiplyProgressBar.Value = MultiplyProgressBar.Minimum;
            SumProgressBar.Value = SumProgressBar.Minimum;
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

                double SummOfAllMaterialOstatkiTable_double = 0;
                double SummOfAllMaterialSaldoTable_double = 0;

                long Material_double = 0;

                int CountSaldoFile = SaldoFile.LastRowCell() - 1;
                int CountOstatkiFile = OstatkiFile.LastRowCell() - 1;

                #endregion

                for (int i = 2; i <= CountSaldoFile; i++) //проверка сумм в таблице сальдо
                {
                    TotalPrice_range = SaldoFile.GetWorksheet().Range["H" + i.ToString()];
                    NumberDocument_range = SaldoFile.GetWorksheet().Range["B" + i.ToString()];

                    if (NumberDocument_range.Value as string == "" || NumberDocument_range.Value == null)//Проверка на строку с итоговой суммой
                    {
                        Material_range = SaldoFile.GetWorksheet().Range["G" + i.ToString()];

                        TotalPrice_double = Convert.ToDouble(TotalPrice_range.Value); //Итоговая сумма материала

                        SummOfAllMaterialSaldoTable_double += TotalPrice_double;//Общая сумма всей таблицы сальдо

                        if (TotalPrice_double != 0)//Если итоговая сумма не 0 то добавляем в список для дальнейшей работы
                        {
                            Saldomaterial_list.Add(new Material()
                            {
                                IDMaterial = Convert.ToInt64(Material_range.Value),
                                TotalPrice = TotalPrice_double
                            });
                        }

                        if (EqualTo(SummOfAllMaterial_double, TotalPrice_double))//Сравнение цены из таблицы и реальной цены полученой при помощи сложения составляющих материала
                        {
                            //Все сходится
                            SummOfAllMaterial_double = 0;

                            if (TotalPrice_double < 0)
                            {
                                Material_double = Convert.ToInt64(Material_range.Value);
                                SumErrorRichTextBox.Text += "Внимание отрицательная сумма сальдо в строке: " + i.ToString() + " \n";
                                SumErrorRichTextBox.Text += "Материал: " + Material_double + " \n";
                                SumErrorRichTextBox.Text += "Сумма: " + TotalPrice_double + " \n\n";
                            }
                        }
                        else
                        {
                            double alpha = Math.Abs(SummOfAllMaterial_double - TotalPrice_double);
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
                for (int i = 2; i <= CountOstatkiFile; i++) //проверка сумм в таблице остатков
                {
                    Zapas_range = OstatkiFile.GetWorksheet().Range["H" + i.ToString()];
                    TotalPrice_range = OstatkiFile.GetWorksheet().Range["K" + i.ToString()];

                    if (Zapas_range.Value == null || Zapas_range.Value as string == "")
                    {
                        Material_range = OstatkiFile.GetWorksheet().Range["D" + i.ToString()];
                        Material_double = Convert.ToInt64(Material_range.Value);
                       
                        TotalPrice_double = Convert.ToDouble(TotalPrice_range.Value);

                        SummOfAllMaterialOstatkiTable_double += TotalPrice_double;//Общая сумма всей таблицы остатков

                        double alpha = Math.Abs(SummOfAllMaterial_double - TotalPrice_double);

                        var FoundMaterial = Saldomaterial_list.Find(n => n.IDMaterial == Material_double);//Проверка на существование материала в таблице сальдо

                        OstatkiMaterial_list.Add(new Material()
                        {
                            IDMaterial = Material_double,
                            TotalPrice = TotalPrice_double
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
                                SumErrorRichTextBox.Text += "Материал " + FoundMaterial.IDMaterial.ToString() + " имеет расхождения в таблицах" + "\n\n";
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

                MaterialSumErrorRichTextBox.Text += "\n----------------------------------------------------------------------------------------------\n";
                MaterialSumErrorRichTextBox.Text += "Итоговая сумма таблицы остатков составила: " + SummOfAllMaterialOstatkiTable_double + " \n";
                MaterialSumErrorRichTextBox.Text += "Итоговая сумма сальдо таблицы составила: " + SummOfAllMaterialSaldoTable_double + " \n";
                MaterialSumErrorRichTextBox.Text += "Разница таблиц составила: " + Math.Abs(SummOfAllMaterialOstatkiTable_double - SummOfAllMaterialSaldoTable_double) + " \n";
                MaterialSumErrorRichTextBox.Text += "----------------------------------------------------------------------------------------------\n";

                CheckMultiplyQuantityByPrice();

                ChooseSaldoFileButton.Enabled = true;
                ChooseOstatkiFileButton.Enabled = true;
                StartButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке контрольных сумм" + ex.ToString(), "Ошибка");
                SaldoFile.CloseExcel();
                OstatkiFile.CloseExcel();
            }
        }

        private void CheckMultiplyQuantityByPrice() //Проверка с помощью перемножения количества на стандартную стоимость с последующей сверкой с итоговой ценой
        { 
            try
            {
                #region variables

                int count = OstatkiFile.LastRowCell() - 1;
                double Zapas_double;
                double DefaultPrice_double;
                double TotalPrice_double;
                long Material_double = 0;

                #endregion

                for (int i = 2; i <= count; i++)
                {     
                    Zapas_range = OstatkiFile.GetWorksheet().Range["H" + i.ToString()];
                    
                    if (Zapas_range.Value == null)
                    {

                    }
                    else
                    {
                        DefaultPrice_range = OstatkiFile.GetWorksheet().Range["I" + i.ToString()];
                        TotalPrice_range = OstatkiFile.GetWorksheet().Range["K" + i.ToString()];

                        Zapas_double = Convert.ToDouble(Zapas_range.Value);
                        DefaultPrice_double = Convert.ToDouble(DefaultPrice_range.Value);
                        TotalPrice_double = Convert.ToDouble(TotalPrice_range.Value);

                        double ExpectedTotalPrice_double = Zapas_double * DefaultPrice_double;
                        
                        if (EqualTo(ExpectedTotalPrice_double, TotalPrice_double))
                        {
                            //все круто
                        }
                        else
                        {
                            Material_range = OstatkiFile.GetWorksheet().Range["D" + i.ToString()];
                            double alpha = ExpectedTotalPrice_double - TotalPrice_double;
                            Material_double = Convert.ToInt64(Material_range.Value);
                            SumErrorRichTextBox.Text += "Перемножение в таблице остатков неверно в строке: " + i.ToString() + "\n";
                            SumErrorRichTextBox.Text += "Материал: " + Material_double + "\n";
                            SumErrorRichTextBox.Text += "Разница составила: " + alpha + "\n\n";
                        }
                    }
                    MultiplyProgressBar.PerformStep();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке перемножения" + ex.ToString(), "Ошибка");
                SaldoFile.CloseExcel();
                OstatkiFile.CloseExcel();
            }
        }

        private bool EqualTo(double value1, double value2)
        {
            double epsilon = 0.01;
            return Math.Abs(value1 - value2) < epsilon;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SaldoFile.ThreadIsAlive() || OstatkiFile.ThreadIsAlive())
            {
                DialogResult dialog = MessageBox.Show("Дождитесь открытия файлов, после сможете закрыть программу", "Завершение программы", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dialog == DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                SaldoFile.CloseExcel();
                OstatkiFile.CloseExcel();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SaldoFile != null & OstatkiFile != null)
            {
                if(!SaldoFile.ThreadIsAlive())
                {
                    ChooseSaldoFileButton.Enabled = true;
                }
                if (!OstatkiFile.ThreadIsAlive())
                {
                    ChooseOstatkiFileButton.Enabled = true;
                }
                if (!SaldoFile.ThreadIsAlive() && !OstatkiFile.ThreadIsAlive() && (OpenFileDialogForOstatki.FileName != "" && OpenFileDialogForSaldo.FileName != ""))
                {
                    timer1.Stop(); 
                    StartButton.Enabled = true;
                }
            }
        }
    }
}
