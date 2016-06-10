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
            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    var products = proxy.GetAllProducts().ToList();
                    return products; ;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        //[Route("Search")]
        [AcceptVerbs("GET")]
        public IEnumerable<Product> GetProducts(string search)
        {
            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    var products = proxy.GetAllProducts().Where(n => n.Name.ToUpper().Contains(search.ToUpper()));
                    return products;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        //[Route("api/data/cat")]
        [AcceptVerbs("GET")]
        public IEnumerable<Product> GetByCategory(string search)
        {
            IEnumerable<Product> products;

            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    products = proxy.GetByCategory(search);
                }
                return products;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
