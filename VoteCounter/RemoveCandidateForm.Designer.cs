namespace VoteCounter
{
    partial class RemoveCandidateForm
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
            this.RemoveCandidateLB = new System.Windows.Forms.ListBox();
            this.RemoveCandidateBtn = new System.Windows.Forms.Button();
            this.RoundNoLB = new System.Windows.Forms.Label();
            this.InstructionLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RemoveCandidateLB
            // 
            this.RemoveCandidateLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveCandidateLB.FormattingEnabled = true;
            this.RemoveCandidateLB.ItemHeight = 16;
            this.RemoveCandidateLB.Location = new System.Drawing.Point(44, 131);
            this.RemoveCandidateLB.Name = "RemoveCandidateLB";
            this.RemoveCandidateLB.Size = new System.Drawing.Size(247, 196);
            this.RemoveCandidateLB.TabIndex = 0;
            // 
            // RemoveCandidateBtn
            // 
            this.RemoveCandidateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveCandidateBtn.Location = new System.Drawing.Point(199, 345);
            this.RemoveCandidateBtn.Name = "RemoveCandidateBtn";
            this.RemoveCandidateBtn.Size = new System.Drawing.Size(138, 37);
            this.RemoveCandidateBtn.TabIndex = 1;
            this.RemoveCandidateBtn.Text = "Remove";
            this.RemoveCandidateBtn.UseVisualStyleBackColor = true;
            this.RemoveCandidateBtn.Click += new System.EventHandler(this.RemoveCandidateBtn_Click);
            // 
            // RoundNoLB
            // 
            this.RoundNoLB.AutoSize = true;
            this.RoundNoLB.Location = new System.Drawing.Point(22, 9);
            this.RoundNoLB.Name = "RoundNoLB";
            this.RoundNoLB.Size = new System.Drawing.Size(84, 17);
            this.RoundNoLB.TabIndex = 2;
            this.RoundNoLB.Text = "Round No : ";
            this.RoundNoLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionLb
            // 
            this.InstructionLb.AutoSize = true;
            this.InstructionLb.Location = new System.Drawing.Point(22, 41);
            this.InstructionLb.Name = "InstructionLb";
            this.InstructionLb.Size = new System.Drawing.Size(73, 17);
            this.InstructionLb.TabIndex = 3;
            this.InstructionLb.Text = "Instruction";
            // 
            // RemoveCandidateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 394);
            this.Controls.Add(this.InstructionLb);
            this.Controls.Add(this.RoundNoLB);
            this.Controls.Add(this.RemoveCandidateBtn);
            this.Controls.Add(this.RemoveCandidateLB);
            this.Name = "RemoveCandidateForm";
            this.Text = "RemoveCandidateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RemoveCandidateLB;
        private System.Windows.Forms.Button RemoveCandidateBtn;
        private System.Windows.Forms.Label RoundNoLB;
        private System.Windows.Forms.Label InstructionLb;
    }
}