using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompanyWebUI.ServiceReference;

namespace CompanyWebUI.Controllers
{
    //[RoutePrefix("api")]
    public class DataController : ApiController
    {
        //[Route("")]
        [AcceptVerbs("GET")]
        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products;

            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    products = proxy.GetAllProducts().ToList();
                }
                return products; ;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                // TODO kastar igen under debug...
                throw;
            }
        }

        //[Route("Search")]
        [AcceptVerbs("GET")]
        public IEnumerable<Product> GetProductsBySearch(string search)
        {
            var productsToReturn = GetProducts(search);

            return productsToReturn;
        }


        private static IEnumerable<Product> GetProducts(string searchString)
        {
            IEnumerable<Product> products;

            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    products = proxy.GetAllProducts().Where(n => n.Name.ToUpper().Contains(searchString.ToUpper()));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return products;
        }
    }
}
