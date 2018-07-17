using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProEnt.LoanPrequalification.Service.ServiceContracts;
using ProEnt.LoanPrequalification.Service.Messages;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Model;
using ProEnt.LoanPrequalification.Service;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ProEnt.LoanPrequalification.Service.WCF
{
    // NOTE: If you change the class name "ProductService" here, you must also update the reference to "ProductService" in Web.config.
    public class ProductService : IProductService
    {
        public ProductGetResponse GetProduct(ProductGetRequest productGetRequest)
        {
            ServiceImplementations.ProductService productService = ObjectFactory.GetInstance<ServiceImplementations.ProductService>();
            return productService.GetProduct(productGetRequest);
        }

        public ProductListResponse GetAllProducts()
        {
            ServiceImplementations.ProductService productService = ObjectFactory.GetInstance<ServiceImplementations.ProductService>();
            return productService.GetAllProducts();
        }
        
        public ProductCreateResponse CreateProduct(ProductCreateRequest productCreateRequest)
        {
            ServiceImplementations.ProductService productService = ObjectFactory.GetInstance<ServiceImplementations.ProductService>();
            return productService.CreateProduct(productCreateRequest);
        }        
    }
}
