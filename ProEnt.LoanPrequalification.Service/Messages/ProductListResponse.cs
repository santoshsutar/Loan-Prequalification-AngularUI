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
    public class ProductListResponse
    {
        private List<ProductView> _products;
        private bool _success;
        private string _message;

        [DataMember]
        public List<ProductView> Products
        {
            get { return _products; }
            set { _products = value; }
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
