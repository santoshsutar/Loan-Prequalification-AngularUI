using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Service.Views;
using ProEnt.LoanPrequalification.Service.Messages;

namespace ProEnt.LoanPrequalification.Service.ServiceContracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ProductGetResponse GetProduct(ProductGetRequest productGetRequest);
        
        [OperationContract]
        ProductListResponse GetAllProducts();

        [OperationContract]
        ProductCreateResponse CreateProduct(ProductCreateRequest productCreateRequest);
    }
      
}
