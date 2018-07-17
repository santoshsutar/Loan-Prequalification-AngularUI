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
    public class ProductCreateRequest
    {
        private ProductView _product;

        [DataMember]
        public ProductView Product
        {
            get { return _product; }
            set { _product = value; }
        }
    }
}
