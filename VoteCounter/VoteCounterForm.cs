using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace VoteCounter
{
    public partial class VoteCounterForm : Form
    {
        #region Assignment Justification

        /* 1) Show audit data on screen: Yes
         * round number, valid notes number, invalid vote number, 
         * which case their removal is noted, the number votes of each candidate in each round: 
         * 
         * 2) Audit report is able to print: Yes
         * allow to print report with .pdf extension and .csv extension         
         * 
         * 3)Selects the data file to load from anywhere on the hard drive: Yes
         * 
         * 4) Vote options:
         *  4.1) accept non-sequential numbering option: yes
         *  
         *  4.2) unaccept non-sequential numbering: yes
         *      these invalid votes will be invalid all rounds,  means never count back
         *  
         *  4.3) use optional preferential voting: yes
         *  
         *  4.4) use non-optional preferential voting: yes
         *      these invalid votes will be invalid all rounds,  means never count back
         *  
         * 5) The user can select between "random coin toss" and "user decides"
         * to solve the problem of removing a candidate when two or more candidates 
         * have the same number of (low) votes: yes
         * 
         * 6) More than one CSV file should be able to be loaded for one election: yes
         * 
         * 7) Commenting: yes
         * 
         * 8) Ease of use, suitability for the audience, and reliability:  
         * options, button, textbox is designed with meaningful text, so user can be easy to know how the application work.
         * many message boxes to handle unexpected actions.
         * form designed based on the context of user.
         * 
         * Creativity: user can choose anywhere to save the report.
         * user can remove the imported data files.
         */

        #endregion

        #region Variables
        public static bool UseCoin = true;                 // store option if user want to use coin to decide how to remove candidates
        public static bool AcceptUnsequentiallyNo = true;  // store option if user accept unsequential number
        public static bool UseOptionalVote = true;         // store option if user want to use optional vote

        private VoteCounter voteCounter;                   // The voteCounter does all of the real work.  
        private Random rand;                               // Random number generator
        private string openFileName;                       // store open file name
        private List<string> files;                        // store list of files have imported
        AuditingForm form2;                                // store AuditingForm to navigate  

        #endregion

        #region Constructor

        /// <summary>
        /// Just the default
        /// </summary>
        public VoteCounterForm()
        {
            InitializeComponent();
            files = new List<string>();
            voteCounter = new VoteCounter();
            rand = new Random();
        }

        #endregion

        #region Events       

        public static int Round { get; set; }

        // store summary value for each round
        public static ArrayList RoundSummaryValue { get; set; } 

        /// <summary>
        /// Does the real work of running the vote when hit. Loads the
        /// votes each time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VoteButton_Click(object sender, EventArgs e)
        {
            // Create a new vote counter. This is a bit of a cludge, but it ensures each vote count
            // is fresh. It would die horribly if the button was hit twice and this wasn't there.
            this.voteCounter = new VoteCounter();

            if (files.Count == 0)
            {
                this.ResultTextBox.Text = "No Data!!! Please import files";
                return;
            }
            // Load the votes from the CSV file. This assumes that the file is in
            // the same folder as the executable and always named "data.csv".

            foreach (String fileName in files)
            {
                this.voteCounter.LoadVotes(fileName);
            }
            // Have we finished yet? If we haven't started counting yet, the answer is no.
            bool finished = false;

            // As a matter of interest, how many rounds did this take?
                  Round =0;        

            // Keep looping until the count is done. A count that is broken would be bad, though.

            while (!finished)
            {
                RoundSummaryValue = new ArrayList();              

                // Increase how many rounds this had taken
                Round += 1;              

                // Conduct the count for this round.
                this.voteCounter.DoCount();
                RoundSummaryValue.Add(voteCounter.Valid);
                RoundSummaryValue.Add(voteCounter.Invalid);

                // Now that the count is done, there are three possibilities.

                // Possibility 1 is that one, and only one, candidate got over 50%. 
                // (First past the post)
                if (this.voteCounter.Winner != "")
                {
                    finished = true;
                    // Generate report
                    this.ResultTextBox.Text = "After round " + Round + " of counting, " + this.voteCounter.Winner +
                        " has won the vote with " + this.voteCounter.Candidates[this.voteCounter.Winner] +
                        " out of " + (this.voteCounter.Valid + this.voteCounter.Invalid) + " votes.";

                    RoundSummaryValue.Add(voteCounter.getSecondWinner());
                    RoundSummaryValue.Add("Lower Votes");
                }

                // Possibility 2 is that all remaining candidates got exactly the same number of votes
                else if (this.voteCounter.Lowest.Length == this.voteCounter.ViableCandidates.Count)
                {
                    finished = true;
                    // Generate report for a tie
                    this.ResultTextBox.Text = "After round " + Round + " of counting, there is a tie." + Environment.NewLine;

                    // Loop through all of those who tied and report name and votes. Yes, I know that the number
                    // of votes will be the same, because of the tie thing. But report it in case someone cares.
                    foreach (string name in this.voteCounter.Lowest)
                    {
                        this.ResultTextBox.Text += name + " with " + this.voteCounter.Candidates[name] + " out of " +
                            (this.voteCounter.Valid + this.voteCounter.Invalid) + " votes." + Environment.NewLine;
                    }
                    RoundSummaryValue.Add("None");
                    RoundSummaryValue.Add("Tie");
                }

                // Possibility 3 is that we have multiple candidates below 50%, and we now need 
                // to exclude the one with the lowest votes.
                else if (voteCounter.Lowest.Length > 1)
                {
                    Debug.WriteLine("same lowest : " + voteCounter.Lowest.Length + " round: " + Round);
                    // Note that if there is more than one with the lowest vote, we randomly pick 
                    // one to exclude. (Toss of a coin)               
                    if (UseCoin)
                    {
                        string removedCandidate = this.voteCounter.Lowest[rand.Next(0, this.voteCounter.Lowest.Length)];
                        RoundSummaryValue.Add(removedCandidate);
                        RoundSummaryValue.Add("Toss A Coint");
                        this.voteCounter.RemoveCandidate(removedCandidate);
                    }
                    else // user decides 
                    {
                        RemoveCandidateForm removeForm = new RemoveCandidateForm(voteCounter);     //Create form if not created   
                        removeForm.StartPosition = FormStartPosition.CenterParent;
                        removeForm.Owner = this;
                        removeForm.ShowDialog();
                    }
                }
                else
                {
                    string removedCandidate = this.voteCounter.Lowest[0];
                    RoundSummaryValue.Add(removedCandidate);
                    RoundSummaryValue.Add("Lowest Votes");
                    this.voteCounter.RemoveCandidate(removedCandidate);
                }                              
               
                voteCounter.RoundSummary.Add(Round, RoundSummaryValue); // update summary information for each round
            }
        }
              
        /// <summary>
        /// Show auditing form     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuditBtn_Click(object sender, EventArgs e)
        {
           
            if (voteCounter.Votes.Count==0)  // if run vote button has not clicked yet
            {
                 MessageBox.Show(this, "Please click Run Vote Button first ");
            }
            else {
                this.Hide();                                // Hide the current form
                form2 = new AuditingForm(voteCounter);     // Create form if not created
                form2.StartPosition = FormStartPosition.CenterParent;
                form2.FormClosed += form2_FormClosed;      // Add eventhandler to cleanup after form closes           
                form2.Owner = this;
                form2.Show(this);
            }
        }

        /// <summary>
        /// Close auditing form     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2 = null;  //If form is closed make sure reference is set to null
            Show();
        }

        /// <summary>
        /// import files event     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportFileBtn_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text = ""; // reset result text box;
           OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            openFileDialog1.DefaultExt = "csv";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            bool fileOpened = false;
            // If a file is not opened, then set the initial directory to the
            // FolderBrowserDialog.SelectedPath value.
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialog1.SelectedPath;
                openFileDialog1.FileName = null;
            }

            // Display the openFile dialog.
            DialogResult result = openFileDialog1.ShowDialog();

            // OK button was pressed.
            if (result == DialogResult.OK)
            {
                //openFileName = openFileDialog1.SafeFileName;
                openFileName = openFileDialog1.FileName;
                try
                {
                    // Output the requested file 
                    Stream s = openFileDialog1.OpenFile();
                    ImportedFiles.Items.Add(openFileDialog1.SafeFileName);
                    files.Add(openFileName);                  
                    s.Close();
                    fileOpened = true;
                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                    fileOpened = false;
                }
                Invalidate();               
            }
            // Cancel button was pressed.
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        /// <summary>
        /// Remove file from the list
        /// if user not choose any file, the first file will be chosen to remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFileBtn_Click_1(object sender, EventArgs e)
        {

            if (ImportedFiles.Items.Count > 0)
            {
                string fileName = "";
                if (ImportedFiles.SelectedItem == null) // if user not choose any file, the first file will be chosen to remove
                {
                    fileName = ImportedFiles.GetItemText(ImportedFiles.Items[0]);
                }
                else
                {
                    fileName = ImportedFiles.GetItemText(ImportedFiles.SelectedItem);
                }

                foreach (string f in files)
                {
                    if (f.Contains(fileName))
                    {
                        files.Remove(f);
                        break;
                    }
                }
                ImportedFiles.Items.Remove(fileName);
                voteCounter = new VoteCounter();
                this.ResultTextBox.Text = "";
            }
            else {
                MessageBox.Show(" There is no imported file");
            }
            
        }

        /// <summary>
        /// CheckedChanged Event for SequentialNoPanel     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SequentialNoPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (AcceptNonSequentiallyNoRB.Checked)
            {
                AcceptUnsequentiallyNo = true;
            }
            else
            {
                AcceptUnsequentiallyNo = false;
            }
        }

        /// <summary>
        /// CheckedChanged Event for PreferentialPanel     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreferentialPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (OptionalVoteRB.Checked)
            {
                UseOptionalVote = true;
            }
            else
            {
                UseOptionalVote = false;
            }
        }

        /// <summary>
        /// CheckedChanged Event for  HandleSameLowestVotesPane   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSameLowestVotesPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (CoinTossRB.Checked)
            {
                UseCoin = true;
            }
            else
            {
                UseCoin = false;
            }
        }
        #endregion

       
    }
}
