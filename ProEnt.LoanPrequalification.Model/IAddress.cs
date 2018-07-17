using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProEnt.LoanPrequalification.Model
{
    public interface IAddress
    {
        string City { get; }
        List<BrokenBusinessRule> GetBrokenRules();
        string PostCode { get; }
        string Street { get; }
        string Town { get; }
    }
}
