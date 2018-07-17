using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using ProEnt.LoanPrequalification.Service.DTOs;

namespace ProEnt.LoanPrequalification.Service.Messages
{
    [DataContract]
    public class LoanApplicationListRequest
    {
        private bool _loadBorrowers;
        private bool _loadAssets;
        private bool _loadDebts;
        private bool _loadProduct;
        
        [DataMember]
        public bool LoanBorrowers
        {
            get { return _loadBorrowers; }
            set { _loadBorrowers = value; }
        }

        [DataMember]
        public bool LoadAssets
        {
            get { return _loadAssets; }
            set { _loadAssets = value; }
        }

        [DataMember]
        public bool LoadDebts
        {
            get { return _loadDebts; }
            set { _loadDebts = value; }
        }

        [DataMember]
        public bool Borrowers
        {
            get { return _loadBorrowers; }
            set { _loadBorrowers = value; }
        }

        [DataMember]
        public bool LoadProduct
        {
            get { return _loadProduct; }
            set { _loadProduct = value; }
        }
    }
}
