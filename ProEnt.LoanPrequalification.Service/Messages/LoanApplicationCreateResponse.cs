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
    public class LoanApplicationCreateResponse
    {
        private string _loanApplicationId;
        private bool _success;
        private string _message;        

        [DataMember]
        public string LoanApplicationId
        {
            get { return _loanApplicationId; }
            set { _loanApplicationId = value; }
        }

        [DataMember]
        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }       
    }
}
