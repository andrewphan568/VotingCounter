namespace VoteCounter
{
    partial class AuditingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CsvPrinterBtn = new System.Windows.Forms.Button();
            this.SwitchToVoteFormBtn = new System.Windows.Forms.Button();
            this.RoundSummaryLV = new System.Windows.Forms.ListView();
            this.VotesSummaryLV = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PdfPrinterBtn = new System.Windows.Forms.Button();
            this.Printer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CsvPrinterBtn
            // 
            this.CsvPrinterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CsvPrinterBtn.Location = new System.Drawing.Point(668, 560);
            this.CsvPrinterBtn.Name = "CsvPrinterBtn";
            this.CsvPrinterBtn.Size = new System.Drawing.Size(118, 34);
            this.CsvPrinterBtn.TabIndex = 0;
            this.CsvPrinterBtn.Text = "Csv Printer";
            this.CsvPrinterBtn.UseVisualStyleBackColor = true;
            this.CsvPrinterBtn.Click += new System.EventHandler(this.CsvPrinterBtn_Click);
            // 
            // SwitchToVoteFormBtn
            // 
            this.SwitchToVoteFormBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SwitchToVoteFormBtn.Location = new System.Drawing.Point(266, 560);
            this.SwitchToVoteFormBtn.Name = "SwitchToVoteFormBtn";
            this.SwitchToVoteFormBtn.Size = new System.Drawing.Size(164, 34);
            this.SwitchToVoteFormBtn.TabIndex = 0;
            this.SwitchToVoteFormBtn.Text = "Switch To Vote Form";
            this.SwitchToVoteFormBtn.UseVisualStyleBackColor = true;
            this.SwitchToVoteFormBtn.Click += new System.EventHandler(this.SwitchToVoteFormBtn_Click);
            // 
            // RoundSummaryLV
            // 
            this.RoundSummaryLV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoundSummaryLV.HideSelection = false;
            this.RoundSummaryLV.Location = new System.Drawing.Point(23, 32);
            this.RoundSummaryLV.Name = "RoundSummaryLV";
            this.RoundSummaryLV.Size = new System.Drawing.Size(773, 239);
            this.RoundSummaryLV.TabIndex = 1;
            this.RoundSummaryLV.UseCompatibleStateImageBehavior = false;
            // 
            // VotesSummaryLV
            // 
            this.VotesSummaryLV.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.VotesSummaryLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VotesSummaryLV.HideSelection = false;
            this.VotesSummaryLV.Location = new System.Drawing.Point(23, 297);
            this.VotesSummaryLV.Name = "VotesSummaryLV";
            this.VotesSummaryLV.Size = new System.Drawing.Size(773, 242);
            this.VotesSummaryLV.TabIndex = 1;
            this.VotesSummaryLV.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "# Round Summary";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Votes Summary Per Each Round #";
            // 
            // PdfPrinterBtn
            // 
            this.PdfPrinterBtn.Location = new System.Drawing.Point(548, 560);
            this.PdfPrinterBtn.Name = "PdfPrinterBtn";
            this.PdfPrinterBtn.Size = new System.Drawing.Size(94, 34);
            this.PdfPrinterBtn.TabIndex = 3;
            this.PdfPrinterBtn.Text = "Pdf Printer";
            this.PdfPrinterBtn.UseVisualStyleBackColor = true;
            this.PdfPrinterBtn.Click += new System.EventHandler(this.PdfPrinterBtn_Click);
            // 
            // Printer
            // 
            this.Printer.Location = new System.Drawing.Point(436, 560);
            this.Printer.Name = "Printer";
            this.Printer.Size = new System.Drawing.Size(95, 34);
            this.Printer.TabIndex = 4;
            this.Printer.Text = "Printer";
            this.Printer.UseVisualStyleBackColor = true;
            this.Printer.Click += new System.EventHandler(this.Printer_Click);
            // 
            // AuditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 606);
            this.Controls.Add(this.Printer);
            this.Controls.Add(this.PdfPrinterBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VotesSummaryLV);
            this.Controls.Add(this.RoundSummaryLV);
            this.Controls.Add(this.SwitchToVoteFormBtn);
            this.Controls.Add(this.CsvPrinterBtn);
            this.MinimumSize = new System.Drawing.Size(850, 622);
            this.Name = "AuditingForm";
            this.Text = "Auditing Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CsvPrinterBtn;
        private System.Windows.Forms.Button SwitchToVoteFormBtn;
        private System.Windows.Forms.ListView RoundSummaryLV;
        private System.Windows.Forms.ListView VotesSummaryLV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PdfPrinterBtn;
        private System.Windows.Forms.Button Printer;
    }
}