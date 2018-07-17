using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProEnt.LoanPrequalification.Service.Messages
{
    [DataContract]
    public class ProductGetRequest
    {
        private string _productId;

        [DataMember]
        public string ProductId
        {
            get { return _productId;  }
            set {  _productId = value;  }
        }
    }
}
