using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoteCounter
{
    /// <summary>
    /// Show list of candidates who have the same lowest number of votes
    /// Remove 1 selected candidate out of the list       
    /// </summary>
    public partial class RemoveCandidateForm : Form
    {
        #region Properties
        VoteCounter voteCounter = null; // store VoteCounter object     

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="votecounter">VoteCounter object</param>        
        public RemoveCandidateForm(VoteCounter votecounter)
        {
            InitializeComponent();
            voteCounter = votecounter;
            ShowCandidates();
        }

        #endregion

        #region Show list of candidates and remove a candidate
        /// <summary>
        /// Show the list of candidates who have the same lowest number of votes
        /// Change the related labels text     
        /// </summary>     
        private void ShowCandidates()
        {
            foreach (string candidate in voteCounter.Lowest)
            {
                RemoveCandidateLB.Items.Add(candidate);
            }            
            RoundNoLB.Text = "ROUND NUMBER : " + VoteCounterForm.Round;
            InstructionLb.Text = "There are " + RemoveCandidateLB.Items.Count + " candidates have the same lowest votes \n" +
                            " Please remove a candidate from the ballot. ";           
        }

        /// <summary>
        /// EventHandle for Remove button
        /// Remove 1 selected candidate out of the list      
        /// </summary>
        /// <param name="sender">The object that called the method</param>
        /// <param name="e">Information about the calling event</param>
        private void RemoveCandidateBtn_Click(object sender, EventArgs e)
        {
            if (RemoveCandidateLB.Items.Count > 1)
            {
                string candidate = "";
                if (RemoveCandidateLB.SelectedItem == null) // if user not choose any candidate, the first candidate will be chosen to remove
                {
                    candidate = RemoveCandidateLB.GetItemText(RemoveCandidateLB.Items[0]);
                }
                else {
                    candidate = RemoveCandidateLB.GetItemText(RemoveCandidateLB.SelectedItem);
                }
               
                DialogResult result = MessageBox.Show(this, "Would you like to remove " + candidate + " from the ballot ?",
                    "Remove", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    MessageBox.Show(this, candidate + " is removed.");
                    RemoveCandidateLB.Items.Remove(candidate);
                    voteCounter.RemoveCandidate(candidate);
                    VoteCounterForm.RoundSummaryValue.Add(candidate);
                    VoteCounterForm.RoundSummaryValue.Add("User Chosen");         
                }              
            }          
            this.Dispose();      // close the remove candidate form     
        }

        #endregion
    }
}
