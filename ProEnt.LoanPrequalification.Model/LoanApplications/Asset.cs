using System;
using System.Collections.Generic;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public class Asset
    {        
        private Guid _assetID;
        private float _balance;
        private string _accountNumber;
        private string _description;
        private LoanApplication _loanApplication;

        public Guid Id
        {
            get { return _assetID; }
            set { _assetID = value; }
        }        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        
        public float Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public LoanApplication LoanApplication
        {
            get { return _loanApplication;  }
           set {  _loanApplication = value;  }
        }
               
        public List<BrokenBusinessRule> GetBrokenBusinessRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (string.IsNullOrEmpty(Description))
                brokenRules.Add(new BrokenBusinessRule("Description", "You must enter a valid description for this asset."));
           
            if (Balance <= 0)
                brokenRules.Add(new BrokenBusinessRule("Balance", "You must enter a valid amount for the balance of this asset. Do not use commas."));

            return brokenRules;
        }
    }
}
