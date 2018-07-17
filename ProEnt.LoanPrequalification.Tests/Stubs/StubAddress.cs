using System.Collections.Generic;
using ProEnt.LoanPrequalification.Model;

namespace ProEnt.LoanPrequalification.Tests.Stubs
{
    public class StubAddress : IAddress
    {
        public string City
        {
            get { return ""; }            
        }

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            return new List<BrokenBusinessRule>();
        }

        public string PostCode
        {
            get { return ""; }            
        }

        public string Street
        {
            get { return ""; }            
        }

        public string Town
        {
            get { return ""; }            
        }
    }
}
