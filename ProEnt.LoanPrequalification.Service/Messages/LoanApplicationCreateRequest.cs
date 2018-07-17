using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using ProEnt.LoanPrequalification.Service.Views;

namespace ProEnt.LoanPrequalification.Service.Messages
{
    [DataContract]
    public class LoanApplicationCreateRequest
    {
        private LoanApplicationCreateView _loanApplicationView;

        [DataMember]
        public LoanApplicationCreateView LoanApplicationView
        {
            get { return _loanApplicationView; }
            set { _loanApplicationView = value; }
        }
    }
}
