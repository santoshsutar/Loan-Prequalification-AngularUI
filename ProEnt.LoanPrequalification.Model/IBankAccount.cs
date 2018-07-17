using System;
using System.Collections.Generic;

namespace ProEnt.LoanPrequalification.Model
{
    public interface IBankAccount
    {
        string AccountNumber { get; }
        string BankName { get; }
        void Credit(float Amount);
        List<BrokenBusinessRule> GetBrokenRules();
        string Name { get; }
        string SortCode { get; }
    }
}
