using System;
using System.Collections.Generic;
using System.Text;

namespace ProEnt.LoanPrequalification.Model
{
    /// <summary>
    /// This is a value object and has no identity
    /// </summary>
    public class BankAccount : IBankAccount
    {
        private string _accountNumber;
        private string _name;
        private string _bankName;
        private string _sortCode;

        public BankAccount()
        { }

        public BankAccount(string accountNumber, string name, string sortCode, string bankName)
        {
            _accountNumber = accountNumber;
            _name = name;
            _sortCode = sortCode;
            _bankName = bankName;

            if (GetBrokenRules().Count > 0)
            {
                throw new Exception(String.Format("The bank account is trying to be created with invalid data.{0}", GetBrokenRulesToString()));
            }
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string SortCode
        {
            get { return _sortCode; }
        }

        public string BankName
        {
            get { return _bankName; }
        }

        public void Credit(float Amount)
        {
            if (Amount > 0)
            {
                // Code to call out side service injected into constructor             
            }
            else
                throw new Exception("You cannot credit a negative amount to a bank account.");
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

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (String.IsNullOrEmpty(SortCode))
                brokenRules.Add(new BrokenBusinessRule("SortCode", "A SortCode must be defined for an Bank Account."));

            if (String.IsNullOrEmpty(AccountNumber))
                brokenRules.Add(new BrokenBusinessRule("AccountNumber", "An AccountNumber must be defined for an Bank Account."));

            if (String.IsNullOrEmpty(BankName))
                brokenRules.Add(new BrokenBusinessRule("Bank", "Please specify the name of the bank."));

            if (String.IsNullOrEmpty(Name))
                brokenRules.Add(new BrokenBusinessRule("Name", "Please specify the name of the account holder."));

            return brokenRules;
        }
    }
}
