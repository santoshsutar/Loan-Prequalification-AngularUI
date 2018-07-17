using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProEnt.LoanPrequalification.Model;
using ProEnt.LoanPrequalification.Model.Products;
using ProEnt.LoanPrequalification.Service.Messages;
using ProEnt.LoanPrequalification.Service.Views;
using ProEnt.LoanPrequalification.Service.ServiceContracts;

namespace ProEnt.LoanPrequalification.Service.ServiceImplementations
{
    public class ProductService : IProductService 
    {
        private Model.Products.ProductService _productService;

        public ProductService(Model.Products.ProductService productService)
        {
            _productService = productService; 
        }

        public ProductGetResponse GetProduct(ProductGetRequest productGetRequest)
        {
            ProductGetResponse response = new ProductGetResponse();

            if (Helper.IsGuid(productGetRequest.ProductId))
            {
                Product product = _productService.FindBy(new Guid(productGetRequest.ProductId));

                if (product == null)
                {
                    response.Message = string.Format("No product can be found with the productid of '{0}'", productGetRequest.ProductId);
                    response.Success = false;
                }
                else
                {
                    ProductView productView = Mapper.BuildViewFrom(product);
                    response.Success = true;
                    response.Product = productView;
                }
            }
            else
            {
                response.Message = string.Format("'{0}' is not a valid product id", productGetRequest.ProductId);
                response.Success = false;
            }

            return response;
        }

        public ProductListResponse GetAllProducts()
        {
            List<Product> products = _productService.FindAll();
         
            ProductListResponse response = new ProductListResponse();
            List<ProductView> productViews = new List<ProductView>();

            foreach (Product product in products)
            {
                productViews.Add(Mapper.BuildViewFrom(product));
            }

            response.Products = productViews;
            response.Success = true;

            return response;
        }

        public ProductCreateResponse CreateProduct(ProductCreateRequest productCreateRequest)
        {            
            ProductCreateResponse productCreateResponse = new ProductCreateResponse();
         
            Product productEntity = Mapper.BuildEntityFrom(productCreateRequest.Product);

            if (productEntity.GetBrokenRules().Count == 0)
            {
                _productService.Save(productEntity);
                productCreateResponse.Success = true;
                productCreateResponse.Product = Mapper.BuildViewFrom(productEntity);
            }
            else 
            {
                productCreateResponse.Success = false;                
                productCreateResponse.Message = ErrorHelper.GetBrokenRulesToStringFor(productEntity.GetBrokenRules());            
            }

            return productCreateResponse;
        }        
    }
}
