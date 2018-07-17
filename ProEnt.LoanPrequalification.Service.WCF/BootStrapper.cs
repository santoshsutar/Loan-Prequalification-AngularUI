using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Model.LoanApplications; 
using ProEnt.LoanPrequalification.Repositories.NHibernate;   

namespace ProEnt.LoanPrequalification.Service.WCF
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            // Initialize the registry
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<LoanApplicationRegistry>();

            });
        }       
    }

    public class LoanApplicationRegistry  : Registry
    {
        public LoanApplicationRegistry()
        {
            // Default
            ForRequestedType<IProductRepository>().TheDefaultIsConcreteType<ProductRepository>();

            ForRequestedType<ILoanApplicationRepository>().TheDefaultIsConcreteType<LoanApplicationRepository>();
        }    
    
    }
}
