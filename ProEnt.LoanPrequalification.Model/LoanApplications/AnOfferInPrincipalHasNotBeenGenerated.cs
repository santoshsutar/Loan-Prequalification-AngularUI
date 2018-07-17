using System;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public class AnOfferInPrincipalHasNotBeenGenerated : Exception
    {
        public AnOfferInPrincipalHasNotBeenGenerated() { }
        public AnOfferInPrincipalHasNotBeenGenerated(string message) : base(message) { }
    }   
}
