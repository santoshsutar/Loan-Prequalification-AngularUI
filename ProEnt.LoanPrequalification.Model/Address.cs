using System;
using System.Collections.Generic;
using System.Text;

namespace ProEnt.LoanPrequalification.Model
{
    /// <summary>
    /// This is a value object and has no identity
    /// </summary>
    public class Address : IAddress
    {
        private string _street;
        private string _town;
        private string _city;
        private string _postCode;

        public Address()
        { }

        public Address(string street, string town, string city, string postCode)
        {
            _street = street;
            _town = town;
            _city = city;
            _postCode = postCode;

            if (GetBrokenRules().Count > 0)
            {
                throw new Exception(String.Format("The address is trying to be created with invalid data.{0}", GetBrokenRulesToString()));
            }
        }

        public string Street
        {
            get { return _street; }
        }

        public string Town
        {
            get { return _town; }
        }

        public string City
        {
            get { return _city; }
        }

        public string PostCode
        {
            get { return _postCode; }
        }

        private string GetBrokenRulesToString()
        {
            StringBuilder sbBrokenRules = new StringBuilder();

            foreach (BrokenBusinessRule br in GetBrokenRules())
            {
                sbBrokenRules.Append(br.Rule);
            }

            return sbBrokenRules.ToString();
        }

        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (String.IsNullOrEmpty(Street))
                brokenRules.Add(new BrokenBusinessRule("Street", "A Street must be defined for an address."));

            if (String.IsNullOrEmpty(Town))
                brokenRules.Add(new BrokenBusinessRule("Town", "A Town must be defined for an address."));

            if (String.IsNullOrEmpty(City))
                brokenRules.Add(new BrokenBusinessRule("City", "A City must be defined for an address."));

            if (String.IsNullOrEmpty(PostCode))
                brokenRules.Add(new BrokenBusinessRule("PostCode", "A PostCode must be defined for an address."));

            return brokenRules;
        }
    }
}
