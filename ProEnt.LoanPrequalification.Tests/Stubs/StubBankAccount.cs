using System.Collections.Generic;
using ProEnt.LoanPrequalification.Model;

namespace ProEnt.LoanPrequalification.Tests.Stubs
{
    public class StubBankAccount : IBankAccount
    {
        public string AccountNumber
        {
            get { return "AccountNumber"; }
        }

        public string BankName
        {
            get { return "BankName"; }
        }

        public void Credit(float Amount)
        {
        }

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            return new List<BrokenBusinessRule>();
        }

        public string Name
        {
            get { return "Name"; }
        }

        public string SortCode
        {
            get { return "SortCode"; }
        }
    }
}
