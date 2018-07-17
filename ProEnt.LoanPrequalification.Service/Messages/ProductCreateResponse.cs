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
    public class ProductCreateResponse
    {
        private ProductView _product;
        private bool _success;
        private string _message;        

        [DataMember]
        public ProductView Product
        {
            get { return _product; }
            set { _product = value; }
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
