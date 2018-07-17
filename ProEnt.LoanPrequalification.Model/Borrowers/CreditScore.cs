using System;
using System.Collections.Generic;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.Borrowers
{
    public class CreditScore
    {
        private int _score;
        private string _creditAgency;

        public CreditScore()
        { }

        public CreditScore(string creditAgency, int score)
        {
            _creditAgency = creditAgency;
            _score = score;

            if (GetBrokenRules().Count > 0)
            {
                throw new Exception(String.Format("The Credit score has been created with invalid data. {0}", GetBrokenRulesToString()));
            }
        }
                
        public string CreditAgency
        {
            get { return _creditAgency; }
        }
        
        public int Score
        {
            get { return _score; }
        }
        
        public override string ToString()
        {
            return string.Format("{0},  Score: {1}", CreditAgency, Score);
        }

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (string.IsNullOrEmpty(CreditAgency))
                brokenRules.Add(new BrokenBusinessRule("CreditAgency", "You must enter a valid credit agency for this credit score."));

            if (Score < 400 || Score > 900)
                brokenRules.Add(new BrokenBusinessRule("Score", "You must enter a valid credit score between 400 and 900."));

            return brokenRules;
        }

        private string GetBrokenRulesToString()
        {
            StringBuilder sbBrokenRules = new StringBuilder();

            foreach (BrokenBusinessRule br in GetBrokenRules())
            {
                sbBrokenRules.Append(br.Rule);
            }

            return sbBrokenRules.ToString();
        }
    }
}
