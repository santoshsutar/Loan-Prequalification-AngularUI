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
    public class OfferLetterGetByIdRequest
    {
        private string  _id;

        [DataMember]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
