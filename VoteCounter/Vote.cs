using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VoteCounter
{
    /// <summary>
    /// Vote class to validate vote, get first preference in the vote
    /// ,Remove a candidate from the ballot
    /// check if all boxes in a vote were filled, or the number in vote is sequential numbering    
    /// </summary>
    public class Vote
    {
        
        #region Properties
        public const int REMOVE_CANDIDATE = -1; // the value of removed candidate
        public const int INVALID_VOTE = -2;     // the value of invalid vote


        /// <summary>
        /// All of the preferences to each of the candidates.
        /// Candidate name is the key, preference is the value.
        /// </summary>
        public Dictionary<String, int> Votes
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Consructors don't get a lot more bring than this. 
        /// Initialises the candidates and their preferences.
        /// </summary>
        public Vote()
        {
            this.Votes = new Dictionary<String, int>();
        }

        #endregion

        #region Validation

        /// <summary>
        /// This checks to see if there is more than one first preference
        /// or, alternatively, no first preference. If either is true
        /// the vote is invalid. 
        /// </summary>
        /// <remarks>
        /// This method has been refactor to allow check to see if the preferences are in sequential
        /// order (for example, a preference of 5 when there are only 4 
        /// candidates) and allow not to use optional vote
        /// For Optional Vote Case and Accept Unseqquentially Number Case : 
        /// Votes are only declared invalid when the preferences
        /// are unable to be counted, and are valid until that situation
        /// is reached.
        /// ForNot use  Optional Vote Case and UnAccept Unseqquentially Number Case :  
        /// these invalid votes will be invalid all rounds,  means never count back
        /// </remarks>
        /// <returns>true if it is a valid vote</returns>
        public bool Validate()
        {
            // hasFirstPreference is used to record if a first preference has 
            // been found or not. 
            bool hasFirstPreference = false;

            // Assume the vote is invalid until proven otherwise (aka, it has
            // one and only one first preference)

            bool isValid = false;

            // if user not accept unsequentially number in the votes
            // and the votes is unsequentially number
            // we will mark these votes to invalid value and rerutn false
            // these invalid votes will be invalid all rounds
            if (VoteCounterForm.AcceptUnsequentiallyNo == false && IsSequentialNumbering(Votes) == false)
            {
                MarkInvalidVotes(Votes);
                return false;            
            }

            // Similarity, if user not accept optional vote
            // and there is unfilled boxes
            // we will mark these votes to invalid value and rerutn false
            // these invalid votes will be invalid all rounds
            if (VoteCounterForm.UseOptionalVote == false && HasUnFilledBoxes(Votes) == true) {
                MarkInvalidVotes(Votes);
                return false;
            }
            
            // Loop through the votes
            foreach (KeyValuePair<string, int> entry in Votes)
            {
                // If this is a first preference, and no other first preference 
                // has been found, the vote is currently valid
                if (entry.Value == 1 && !hasFirstPreference)
                {
                    hasFirstPreference = true;
                    isValid = true;
                }
                // However, if this votes is a first preference and another
                // first preference was found, we have two first preferences
                // and an invalid vote.
                else if (entry.Value == 1 && hasFirstPreference)
                {
                    isValid = false;
                }
            }

            // Note that if no first preference was found, the default - that 
            // it is invalid - remains the case.
            return isValid;
        }

        #endregion

        #region Find out who has the first preference for ths voter

        /// <summary>
        /// If the vote is valid, finds the candidate with this voter's
        /// current first preference
        /// </summary>
        /// <returns>Returns the candidate name</returns>
        /// <exception>Thrown if the vote is invalid</exception>
        public String GetFirstPreference()
        {
            String candidate = "";

            // Check that it is valid, Shouldn't be an issue, as it can be
            // checked independently, but nothing wrong with an overabundance
            // of caution
            if (this.Validate())
            {
                /// Loop through the votes ...
                foreach (KeyValuePair<string, int> vote in Votes)
                {
                    // ... looking for the one with the first preference ...
                    if (vote.Value == 1)
                    {
                        // ... and record their name!
                        candidate = vote.Key;
                    }
                }
            }
            else
            {
                // Throw an exception because it failed validation
                throw new Exception("Vote failed validation");
            }

            return candidate;
        }

        #endregion

        #region Remove a candidate from the ballot

        /// <summary>
        /// Removes the specified candidate from the vote and reasigns
        /// preferences to match.
        /// </summary>
        /// <remarks>
        /// The candidate with the lowest number of votes is removed from the ballot.
        /// In that case, all preferences for the candidate are set to -1, to 
        /// indicate preclusion, and all preferences above the candidate's 
        /// move down one postion. For example if A, B, C & D are running,
        /// and B is preculded, a ballot with preferences 2, 3, 1, 4 (respectively)
        /// becomes 2, -1, 1, 3.
        /// </remarks>
        public void RemoveCandidate(String targetCandidate)
        {
            int targetPreference = this.Votes[targetCandidate];

            // Get list of candidates
            string[] candidates = this.Votes.Keys.ToArray<string>();

            foreach (string candidate in candidates)
            {

                if (Votes[candidate] == targetPreference)
                {                  
                    Votes[candidate] = Vote.REMOVE_CANDIDATE;
                }
                else if (Votes[candidate] > targetPreference)
                {
                    Votes[candidate] -= 1;                   
                }             
            }
        }
        #endregion

        #region Change votes to be invalid
        /// <summary>
        /// Change votes to be invalid
        /// </summary>
        /// <param name="VotesCheck">Dictionary of votes need to check</param> 
        public void MarkInvalidVotes (Dictionary<String, int> VotesCheck)
        {
            string[] candidates = VotesCheck.Keys.ToArray<string>();

            foreach (string candidate in candidates)
            {

                if (VotesCheck[candidate] != Vote.REMOVE_CANDIDATE)
                {                  
                    VotesCheck[candidate] = Vote.INVALID_VOTE;
                }                
            }                       
        }

        #endregion

        #region Check to see if the votes has unfilled boxes
        /// <summary>
        /// check to see if the votes has unfilled boxes
        /// </summary>
        /// <param name="VotesCheck">Dictionary of votes need to check</param> 
        public bool HasUnFilledBoxes(Dictionary<String, int> VotesCheck)
        {           
            foreach (KeyValuePair<string, int> entry in VotesCheck)
            {
                if (entry.Value == Vote.INVALID_VOTE)
                {
                    return true;
                }
            }

            return false;           
        }
        #endregion

        #region Check to see if the preferences are in sequential order
        /// <summary> 
        /// check to see if the preferences are in sequential order
        /// </summary>
        /// <param name="VotesCheck">Dictionary of votes need to check</param> 
        public bool IsSequentialNumbering(Dictionary<String, int> VotesCheck)
        {
            int size = 0;
            foreach (KeyValuePair<string, int> entry in VotesCheck)
            {
                if (entry.Value > -1)
                {
                    size += 1;
                }
            }            

            int min = GetMin(VotesCheck);   // Get the minimum element in dictionary
            int max = GetMax(VotesCheck);   // Get the maximum element in dictionary            

            //ax - min + 1 is equal to size, then only check all elements 
            if (max - min + 1 == size)
            {
                //reate a temp array to hold visited  flag of all elements. Note that, calloc 
                // is used here so that all values are initialized as false
                bool[] visited = new bool[size];
                for (int i = 0; i < visited.Length; i++)
                {
                    visited[i] = false;
                }
                foreach (KeyValuePair<string, int> entry in VotesCheck)
                {

                    // If we see an element again, then return false
                    if (entry.Value == 0)
                    {
                        return false;
                    }
                    else if (entry.Value > 0)
                    {
                        if (visited[entry.Value - min] != false)
                        {
                            return false;
                        }
                        //If visited first time, then mark  the element as visited 
                        visited[entry.Value - min] = true;
                    }
                }
                return true; // If all elements occur once
            }
            return false; // if (max - min + 1 != size) 
        }

        /// <summary>
        /// get the minimun number in vote
        /// </summary>
        /// <param name="VotesCheck">Dictionary of votes need to check</param> 
        private int GetMin(Dictionary<String, int> VotesCheck)
        {
            int min = 1;
            foreach (KeyValuePair<string, int> entry in VotesCheck)
            {
                if (entry.Value < min && entry.Value > -1)
                {
                    min = entry.Value;
                }
            }
            return min;
        }

        /// <summary>
        /// get the maximun number in vote
        /// </summary>
        /// <param name="VotesCheck">Dictionary of votes need to check</param> 
        private int GetMax(Dictionary<String, int> VotesCheck)
        {
            int max = 0;            
            foreach (KeyValuePair<string, int> entry in VotesCheck)
            {
                if (entry.Value > max)
                {
                    max = entry.Value;
                }
            }
            return max;
        }

        #endregion
    }
}
