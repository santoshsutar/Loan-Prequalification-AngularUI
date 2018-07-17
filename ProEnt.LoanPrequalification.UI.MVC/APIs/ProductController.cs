using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StructureMap;
using ProEnt.LoanPrequalification.UI.MVC.ProductService;
using WroxProf.LoanApproval.UI.MVC;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProEnt.LoanPrequalification.UI.MVC.APIs
{
     [AllowCrossSiteJson]
   
    public class ProductController : ApiController
    {
        private ProEnt.LoanPrequalification.UI.MVC.Controllers.ProductController productController;
        public ProductController()
        {
            productController = new ProEnt.LoanPrequalification.UI.MVC.Controllers.ProductController(ObjectFactory.GetInstance<IProductService>());
        }
        [HttpGet]
        public ProductView[] Index()
        {
            this.productController.Index();
            System.Web.Mvc.ViewResult viewResult = (System.Web.Mvc.ViewResult)productController.Index();
            ProductView[] productView = (ProductView[])viewResult.ViewData.Model;
            return productView;
        }

        [HttpGet]
        public ProductView Details(string id)
        {
            var viewResult = (System.Web.Mvc.ViewResult)this.productController.Details(id);

            ProductView productView = (ProductView)viewResult.ViewData.Model;

            return productView;
        }
        [HttpPost]
        public ProductService.ProductCreateResponse Create()
        {
            Task<string> content = this.Request.Content.ReadAsStringAsync();
            ProductView body = JsonConvert.DeserializeObject<ProductView>(content.Result);
            return this.productController.CreateProductForAPI(body);
        }

    }
}