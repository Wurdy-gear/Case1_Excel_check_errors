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
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SumProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.MultiplyProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.MaterialSumErrorRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SumErrorRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem1});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.открытьToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem1
            // 
            this.OpenToolStripMenuItem1.Name = "OpenToolStripMenuItem1";
            this.OpenToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem1.Text = "Open";
            this.OpenToolStripMenuItem1.Click += new System.EventHandler(this.OpenToolStripMenuItem1_Click);
            // 
            // SumProgressBar
            // 
            this.SumProgressBar.Location = new System.Drawing.Point(12, 69);
            this.SumProgressBar.Maximum = 65857;
            this.SumProgressBar.Minimum = 2;
            this.SumProgressBar.Name = "SumProgressBar";
            this.SumProgressBar.Size = new System.Drawing.Size(382, 23);
            this.SumProgressBar.Step = 1;
            this.SumProgressBar.TabIndex = 2;
            this.SumProgressBar.Value = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Прогресс проверки контрольных сумм";
            // 
            // MultiplyProgressBar
            // 
            this.MultiplyProgressBar.Location = new System.Drawing.Point(12, 149);
            this.MultiplyProgressBar.Maximum = 9251;
            this.MultiplyProgressBar.Minimum = 2;
            this.MultiplyProgressBar.Name = "MultiplyProgressBar";
            this.MultiplyProgressBar.Size = new System.Drawing.Size(382, 23);
            this.MultiplyProgressBar.Step = 1;
            this.MultiplyProgressBar.TabIndex = 4;
            this.MultiplyProgressBar.Value = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Перемножение кол-ва на стандартную стоимость и сверка с итоговой ценой";
            // 
            // MaterialSumErrorRichTextBox
            // 
            this.MaterialSumErrorRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaterialSumErrorRichTextBox.Location = new System.Drawing.Point(415, 195);
            this.MaterialSumErrorRichTextBox.Name = "MaterialSumErrorRichTextBox";
            this.MaterialSumErrorRichTextBox.ReadOnly = true;
            this.MaterialSumErrorRichTextBox.Size = new System.Drawing.Size(353, 146);
            this.MaterialSumErrorRichTextBox.TabIndex = 9;
            this.MaterialSumErrorRichTextBox.Text = "";
            // 
            // SumErrorRichTextBox
            // 
            this.SumErrorRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SumErrorRichTextBox.Location = new System.Drawing.Point(415, 27);
            this.SumErrorRichTextBox.Name = "SumErrorRichTextBox";
            this.SumErrorRichTextBox.ReadOnly = true;
            this.SumErrorRichTextBox.Size = new System.Drawing.Size(353, 145);
            this.SumErrorRichTextBox.TabIndex = 10;
            this.SumErrorRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 410);
            this.Controls.Add(this.SumErrorRichTextBox);
            this.Controls.Add(this.MaterialSumErrorRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MultiplyProgressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SumProgressBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem1;
        private System.Windows.Forms.ProgressBar SumProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar MultiplyProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox MaterialSumErrorRichTextBox;
        private System.Windows.Forms.RichTextBox SumErrorRichTextBox;
    }
}

