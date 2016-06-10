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
        public IEnumerable<Product> GetProducts(string search)
        {
            IEnumerable<Product> products;

            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    products = proxy.GetAllProducts().Where(n => n.Name.ToUpper().Contains(search.ToUpper()));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return products;
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
            }
            catch (Exception)
            {

                throw;
            }
            return products;
        }
    }
}
