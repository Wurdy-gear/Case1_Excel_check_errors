namespace Case1_Excel_check_errors
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OpenFileDialogForSaldo = new System.Windows.Forms.OpenFileDialog();
            this.OpenFileDialogForOstatki = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.LabelForSelectedFilenameOstatki = new System.Windows.Forms.Label();
            this.LabelForSelectedFilenameSaldo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChooseOstatkiFileButton = new System.Windows.Forms.Button();
            this.ChooseSaldoFileButton = new System.Windows.Forms.Button();
            this.SumProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.MultiplyProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.MaterialSumErrorRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SumErrorRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialogForSaldo
            // 
            this.OpenFileDialogForSaldo.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            this.OpenFileDialogForSaldo.Title = "Выберите сальдо отчёт";
            // 
            // OpenFileDialogForOstatki
            // 
            this.OpenFileDialogForOstatki.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            this.OpenFileDialogForOstatki.Title = "Выберите отчет по остаткам";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.StartButton);
            this.splitContainer1.Panel1.Controls.Add(this.LabelForSelectedFilenameOstatki);
            this.splitContainer1.Panel1.Controls.Add(this.LabelForSelectedFilenameSaldo);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.ChooseOstatkiFileButton);
            this.splitContainer1.Panel1.Controls.Add(this.ChooseSaldoFileButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SumProgressBar);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.MultiplyProgressBar);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.MaterialSumErrorRichTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.SumErrorRichTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(544, 599);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(308, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "Имя выбранного файла:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(43, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Имя выбранного файла:";
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(177, 116);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(155, 26);
            this.StartButton.TabIndex = 32;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LabelForSelectedFilenameOstatki
            // 
            this.LabelForSelectedFilenameOstatki.AutoSize = true;
            this.LabelForSelectedFilenameOstatki.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelForSelectedFilenameOstatki.Location = new System.Drawing.Point(314, 89);
            this.LabelForSelectedFilenameOstatki.Name = "LabelForSelectedFilenameOstatki";
            this.LabelForSelectedFilenameOstatki.Size = new System.Drawing.Size(0, 15);
            this.LabelForSelectedFilenameOstatki.TabIndex = 31;
            // 
            // LabelForSelectedFilenameSaldo
            // 
            this.LabelForSelectedFilenameSaldo.AutoSize = true;
            this.LabelForSelectedFilenameSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelForSelectedFilenameSaldo.Location = new System.Drawing.Point(51, 92);
            this.LabelForSelectedFilenameSaldo.Name = "LabelForSelectedFilenameSaldo";
            this.LabelForSelectedFilenameSaldo.Size = new System.Drawing.Size(0, 15);
            this.LabelForSelectedFilenameSaldo.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(284, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Выберите отчет по остаткам";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(31, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Выберите сальдо отчёт";
            // 
            // ChooseOstatkiFileButton
            // 
            this.ChooseOstatkiFileButton.Location = new System.Drawing.Point(342, 44);
            this.ChooseOstatkiFileButton.Name = "ChooseOstatkiFileButton";
            this.ChooseOstatkiFileButton.Size = new System.Drawing.Size(116, 26);
            this.ChooseOstatkiFileButton.TabIndex = 27;
            this.ChooseOstatkiFileButton.Text = "Выбрать...";
            this.ChooseOstatkiFileButton.UseVisualStyleBackColor = true;
            this.ChooseOstatkiFileButton.Click += new System.EventHandler(this.ChooseOstatkiFileButton_Click);
            // 
            // ChooseSaldoFileButton
            // 
            this.ChooseSaldoFileButton.Location = new System.Drawing.Point(62, 44);
            this.ChooseSaldoFileButton.Name = "ChooseSaldoFileButton";
            this.ChooseSaldoFileButton.Size = new System.Drawing.Size(116, 26);
            this.ChooseSaldoFileButton.TabIndex = 26;
            this.ChooseSaldoFileButton.Text = "Выбрать...";
            this.ChooseSaldoFileButton.UseVisualStyleBackColor = true;
            this.ChooseSaldoFileButton.Click += new System.EventHandler(this.ChooseSaldoFileButton_Click);
            // 
            // SumProgressBar
            // 
            this.SumProgressBar.Location = new System.Drawing.Point(47, 36);
            this.SumProgressBar.Maximum = 65857;
            this.SumProgressBar.Minimum = 2;
            this.SumProgressBar.Name = "SumProgressBar";
            this.SumProgressBar.Size = new System.Drawing.Size(469, 23);
            this.SumProgressBar.Step = 1;
            this.SumProgressBar.TabIndex = 20;
            this.SumProgressBar.Value = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(162, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Прогресс проверки контрольных сумм";
            // 
            // MultiplyProgressBar
            // 
            this.MultiplyProgressBar.Location = new System.Drawing.Point(46, 238);
            this.MultiplyProgressBar.Maximum = 9251;
            this.MultiplyProgressBar.Minimum = 2;
            this.MultiplyProgressBar.Name = "MultiplyProgressBar";
            this.MultiplyProgressBar.Size = new System.Drawing.Size(470, 23);
            this.MultiplyProgressBar.Step = 1;
            this.MultiplyProgressBar.TabIndex = 22;
            this.MultiplyProgressBar.Value = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(511, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Перемножение кол-ва на стандартную стоимость и сверка с итоговой ценой";
            // 
            // MaterialSumErrorRichTextBox
            // 
            this.MaterialSumErrorRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MaterialSumErrorRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MaterialSumErrorRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaterialSumErrorRichTextBox.Location = new System.Drawing.Point(46, 282);
            this.MaterialSumErrorRichTextBox.Name = "MaterialSumErrorRichTextBox";
            this.MaterialSumErrorRichTextBox.ReadOnly = true;
            this.MaterialSumErrorRichTextBox.Size = new System.Drawing.Size(470, 146);
            this.MaterialSumErrorRichTextBox.TabIndex = 24;
            this.MaterialSumErrorRichTextBox.Text = "";
            // 
            // SumErrorRichTextBox
            // 
            this.SumErrorRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SumErrorRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SumErrorRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumErrorRichTextBox.Location = new System.Drawing.Point(47, 65);
            this.SumErrorRichTextBox.Name = "SumErrorRichTextBox";
            this.SumErrorRichTextBox.ReadOnly = true;
            this.SumErrorRichTextBox.Size = new System.Drawing.Size(469, 145);
            this.SumErrorRichTextBox.TabIndex = 25;
            this.SumErrorRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 599);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Сверка отчётов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenFileDialogForSaldo;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogForOstatki;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label LabelForSelectedFilenameOstatki;
        private System.Windows.Forms.Label LabelForSelectedFilenameSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChooseOstatkiFileButton;
        private System.Windows.Forms.Button ChooseSaldoFileButton;
        private System.Windows.Forms.ProgressBar SumProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar MultiplyProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox MaterialSumErrorRichTextBox;
        private System.Windows.Forms.RichTextBox SumErrorRichTextBox;
    }
}

