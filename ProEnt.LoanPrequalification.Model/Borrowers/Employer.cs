using System;
using System.Collections.Generic;
using System.Text;

namespace ProEnt.LoanPrequalification.Model.Borrowers
{
    public class Employer
    {
        private float _monthlyIncome;
        private IAddress _address;
        private string _name;

        public Employer()
        { }

        public Employer(float MonthlyIncome, IAddress EmployerAddress, string EmployerName)
        {
            _monthlyIncome = MonthlyIncome;
            _address = EmployerAddress;
            _name = EmployerName;

            if (GetBrokenRules().Count > 0)
            {
                throw new Exception(String.Format("The Employer is trying to be created with invalid data.{0}", GetBrokenRulesToString()));
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public float MonthlyIncome
        {
            get { return _monthlyIncome; }
        }

        public IAddress Address
        {
            get { return _address; }
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

            if (String.IsNullOrEmpty(Name))
                brokenRules.Add(new BrokenBusinessRule("Name", "A name must defined for an employer."));

            if (MonthlyIncome <= 0)
                brokenRules.Add(new BrokenBusinessRule("MonthlyIncome", "A Monthly Income must be greater than 0."));

            if (Address == null)
                brokenRules.Add(new BrokenBusinessRule("Address", "An address must defined for an employer."));
            else if (Address.GetBrokenRules().Count > 0)
            {
                AddToBrokenRulesList(brokenRules, Address.GetBrokenRules());
            }

            return brokenRules;
        }

        private void AddToBrokenRulesList(List<BrokenBusinessRule> currentBrokenRules, List<BrokenBusinessRule> brokenRulesToAdd)
        {
            foreach (BrokenBusinessRule brokenRule in brokenRulesToAdd)
            {
                currentBrokenRules.Add(brokenRule);
            }
        }
    }
}
