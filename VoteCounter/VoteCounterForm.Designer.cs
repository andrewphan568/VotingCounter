namespace VoteCounter
{
    partial class VoteCounterForm
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
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.VoteButton = new System.Windows.Forms.Button();
            this.ImportFileBtn = new System.Windows.Forms.Button();
            this.RemoveFileBtn = new System.Windows.Forms.Button();
            this.AuditBtn = new System.Windows.Forms.Button();
            this.ImportedFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SequentialNoPanel = new System.Windows.Forms.Panel();
            this.AcceptNonSequentiallyNoRB = new System.Windows.Forms.RadioButton();
            this.UnacceptNonSequentialNoRB = new System.Windows.Forms.RadioButton();
            this.PreferentialPanel = new System.Windows.Forms.Panel();
            this.NonOptionalVoteRB = new System.Windows.Forms.RadioButton();
            this.OptionalVoteRB = new System.Windows.Forms.RadioButton();
            this.UserDecidesRB = new System.Windows.Forms.RadioButton();
            this.HandleSameLowestVotesPanel = new System.Windows.Forms.Panel();
            this.CoinTossRB = new System.Windows.Forms.RadioButton();
            this.SequentialNoPanel.SuspendLayout();
            this.PreferentialPanel.SuspendLayout();
            this.HandleSameLowestVotesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.Location = new System.Drawing.Point(12, 12);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(593, 222);
            this.ResultTextBox.TabIndex = 0;
            // 
            // VoteButton
            // 
            this.VoteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VoteButton.Location = new System.Drawing.Point(58, 392);
            this.VoteButton.Name = "VoteButton";
            this.VoteButton.Size = new System.Drawing.Size(473, 33);
            this.VoteButton.TabIndex = 1;
            this.VoteButton.Text = "Run Vote";
            this.VoteButton.UseVisualStyleBackColor = true;
            this.VoteButton.Click += new System.EventHandler(this.VoteButton_Click);
            // 
            // ImportFileBtn
            // 
            this.ImportFileBtn.Location = new System.Drawing.Point(639, 259);
            this.ImportFileBtn.Name = "ImportFileBtn";
            this.ImportFileBtn.Size = new System.Drawing.Size(102, 38);
            this.ImportFileBtn.TabIndex = 3;
            this.ImportFileBtn.Text = "import file";
            this.ImportFileBtn.UseVisualStyleBackColor = true;
            this.ImportFileBtn.Click += new System.EventHandler(this.ImportFileBtn_Click);
            // 
            // RemoveFileBtn
            // 
            this.RemoveFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveFileBtn.Location = new System.Drawing.Point(762, 259);
            this.RemoveFileBtn.Name = "RemoveFileBtn";
            this.RemoveFileBtn.Size = new System.Drawing.Size(97, 38);
            this.RemoveFileBtn.TabIndex = 3;
            this.RemoveFileBtn.Text = "remove file";
            this.RemoveFileBtn.UseVisualStyleBackColor = true;
            this.RemoveFileBtn.Click += new System.EventHandler(this.RemoveFileBtn_Click_1);
            // 
            // AuditBtn
            // 
            this.AuditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AuditBtn.Location = new System.Drawing.Point(654, 390);
            this.AuditBtn.Name = "AuditBtn";
            this.AuditBtn.Size = new System.Drawing.Size(190, 35);
            this.AuditBtn.TabIndex = 3;
            this.AuditBtn.Text = "Audit";
            this.AuditBtn.UseVisualStyleBackColor = true;
            this.AuditBtn.Click += new System.EventHandler(this.AuditBtn_Click);
            // 
            // ImportedFiles
            // 
            this.ImportedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportedFiles.FormattingEnabled = true;
            this.ImportedFiles.ItemHeight = 16;
            this.ImportedFiles.Location = new System.Drawing.Point(639, 12);
            this.ImportedFiles.Name = "ImportedFiles";
            this.ImportedFiles.Size = new System.Drawing.Size(220, 228);
            this.ImportedFiles.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "How would you like to hanlde multiple candidates have the same number of (low) vo" +
    "tes ?";
            // 
            // SequentialNoPanel
            // 
            this.SequentialNoPanel.Controls.Add(this.AcceptNonSequentiallyNoRB);
            this.SequentialNoPanel.Controls.Add(this.UnacceptNonSequentialNoRB);
            this.SequentialNoPanel.Location = new System.Drawing.Point(23, 240);
            this.SequentialNoPanel.Name = "SequentialNoPanel";
            this.SequentialNoPanel.Size = new System.Drawing.Size(561, 34);
            this.SequentialNoPanel.TabIndex = 7;
            // 
            // AcceptNonSequentiallyNoRB
            // 
            this.AcceptNonSequentiallyNoRB.AutoSize = true;
            this.AcceptNonSequentiallyNoRB.Checked = true;
            this.AcceptNonSequentiallyNoRB.Location = new System.Drawing.Point(15, 6);
            this.AcceptNonSequentiallyNoRB.Name = "AcceptNonSequentiallyNoRB";
            this.AcceptNonSequentiallyNoRB.Size = new System.Drawing.Size(240, 21);
            this.AcceptNonSequentiallyNoRB.TabIndex = 0;
            this.AcceptNonSequentiallyNoRB.TabStop = true;
            this.AcceptNonSequentiallyNoRB.Text = "accept non-sequential numbering";
            this.AcceptNonSequentiallyNoRB.UseVisualStyleBackColor = true;
            this.AcceptNonSequentiallyNoRB.CheckedChanged += new System.EventHandler(this.SequentialNoPanel_CheckedChanged);
            // 
            // UnacceptNonSequentialNoRB
            // 
            this.UnacceptNonSequentialNoRB.AutoSize = true;
            this.UnacceptNonSequentialNoRB.Location = new System.Drawing.Point(282, 7);
            this.UnacceptNonSequentialNoRB.Name = "UnacceptNonSequentialNoRB";
            this.UnacceptNonSequentialNoRB.Size = new System.Drawing.Size(256, 21);
            this.UnacceptNonSequentialNoRB.TabIndex = 0;
            this.UnacceptNonSequentialNoRB.Text = "unaccept non-sequential numbering";
            this.UnacceptNonSequentialNoRB.UseVisualStyleBackColor = true;
            this.UnacceptNonSequentialNoRB.CheckedChanged += new System.EventHandler(this.SequentialNoPanel_CheckedChanged);
            // 
            // PreferentialPanel
            // 
            this.PreferentialPanel.Controls.Add(this.NonOptionalVoteRB);
            this.PreferentialPanel.Controls.Add(this.OptionalVoteRB);
            this.PreferentialPanel.Location = new System.Drawing.Point(23, 280);
            this.PreferentialPanel.Name = "PreferentialPanel";
            this.PreferentialPanel.Size = new System.Drawing.Size(561, 36);
            this.PreferentialPanel.TabIndex = 8;
            // 
            // NonOptionalVoteRB
            // 
            this.NonOptionalVoteRB.AutoSize = true;
            this.NonOptionalVoteRB.Location = new System.Drawing.Point(282, 7);
            this.NonOptionalVoteRB.Name = "NonOptionalVoteRB";
            this.NonOptionalVoteRB.Size = new System.Drawing.Size(226, 21);
            this.NonOptionalVoteRB.TabIndex = 9;
            this.NonOptionalVoteRB.Text = "non-optional preferential voting";
            this.NonOptionalVoteRB.UseVisualStyleBackColor = true;
            this.NonOptionalVoteRB.CheckedChanged += new System.EventHandler(this.PreferentialPanel_CheckedChanged);
            // 
            // OptionalVoteRB
            // 
            this.OptionalVoteRB.AutoSize = true;
            this.OptionalVoteRB.Checked = true;
            this.OptionalVoteRB.Location = new System.Drawing.Point(15, 8);
            this.OptionalVoteRB.Name = "OptionalVoteRB";
            this.OptionalVoteRB.Size = new System.Drawing.Size(197, 21);
            this.OptionalVoteRB.TabIndex = 9;
            this.OptionalVoteRB.TabStop = true;
            this.OptionalVoteRB.Text = "optional preferential voting";
            this.OptionalVoteRB.UseVisualStyleBackColor = true;
            this.OptionalVoteRB.CheckedChanged += new System.EventHandler(this.PreferentialPanel_CheckedChanged);
            // 
            // UserDecidesRB
            // 
            this.UserDecidesRB.AutoSize = true;
            this.UserDecidesRB.Location = new System.Drawing.Point(282, 3);
            this.UserDecidesRB.Name = "UserDecidesRB";
            this.UserDecidesRB.Size = new System.Drawing.Size(110, 21);
            this.UserDecidesRB.TabIndex = 9;
            this.UserDecidesRB.Text = "user decides";
            this.UserDecidesRB.UseVisualStyleBackColor = true;
            this.UserDecidesRB.CheckedChanged += new System.EventHandler(this.HandleSameLowestVotesPanel_CheckedChanged);
            // 
            // HandleSameLowestVotesPanel
            // 
            this.HandleSameLowestVotesPanel.Controls.Add(this.CoinTossRB);
            this.HandleSameLowestVotesPanel.Controls.Add(this.UserDecidesRB);
            this.HandleSameLowestVotesPanel.Location = new System.Drawing.Point(23, 349);
            this.HandleSameLowestVotesPanel.Name = "HandleSameLowestVotesPanel";
            this.HandleSameLowestVotesPanel.Size = new System.Drawing.Size(561, 37);
            this.HandleSameLowestVotesPanel.TabIndex = 10;
            // 
            // CoinTossRB
            // 
            this.CoinTossRB.AutoSize = true;
            this.CoinTossRB.Checked = true;
            this.CoinTossRB.Location = new System.Drawing.Point(15, 3);
            this.CoinTossRB.Name = "CoinTossRB";
            this.CoinTossRB.Size = new System.Drawing.Size(164, 21);
            this.CoinTossRB.TabIndex = 9;
            this.CoinTossRB.TabStop = true;
            this.CoinTossRB.Text = "use random coin toss";
            this.CoinTossRB.UseVisualStyleBackColor = true;
            this.CoinTossRB.CheckedChanged += new System.EventHandler(this.HandleSameLowestVotesPanel_CheckedChanged);
            // 
            // VoteCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 437);
            this.Controls.Add(this.HandleSameLowestVotesPanel);
            this.Controls.Add(this.PreferentialPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SequentialNoPanel);
            this.Controls.Add(this.ImportedFiles);
            this.Controls.Add(this.AuditBtn);
            this.Controls.Add(this.RemoveFileBtn);
            this.Controls.Add(this.ImportFileBtn);
            this.Controls.Add(this.VoteButton);
            this.Controls.Add(this.ResultTextBox);
            this.MinimumSize = new System.Drawing.Size(897, 479);
            this.Name = "VoteCounterForm";
            this.Text = "Vote Counter";
            this.SequentialNoPanel.ResumeLayout(false);
            this.SequentialNoPanel.PerformLayout();
            this.PreferentialPanel.ResumeLayout(false);
            this.PreferentialPanel.PerformLayout();
            this.HandleSameLowestVotesPanel.ResumeLayout(false);
            this.HandleSameLowestVotesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button VoteButton;
        private System.Windows.Forms.Button ImportFileBtn;
        private System.Windows.Forms.Button RemoveFileBtn;
        private System.Windows.Forms.Button AuditBtn;
        private System.Windows.Forms.ListBox ImportedFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SequentialNoPanel;
        private System.Windows.Forms.RadioButton AcceptNonSequentiallyNoRB;
        private System.Windows.Forms.RadioButton UnacceptNonSequentialNoRB;
        private System.Windows.Forms.Panel PreferentialPanel;
        private System.Windows.Forms.RadioButton NonOptionalVoteRB;
        private System.Windows.Forms.RadioButton OptionalVoteRB;
        private System.Windows.Forms.RadioButton UserDecidesRB;
        private System.Windows.Forms.Panel HandleSameLowestVotesPanel;
        private System.Windows.Forms.RadioButton CoinTossRB;
    }
}

