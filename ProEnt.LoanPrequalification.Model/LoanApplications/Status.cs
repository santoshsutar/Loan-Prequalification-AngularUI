using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.LoanApplications
{
    public enum Status
    {
        AwaitingPrequalification = 0,        
        OfferGiven = 1,        
        Declined = 2,
        Expired = 3
    }
}
