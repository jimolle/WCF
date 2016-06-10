using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        string GetData(int value);
        // TODO: Add your service operations here

        [OperationContract]
        List<BusinessObjects.Product> GetAllProducts();

        [OperationContract]
        BusinessObjects.Product[] GetByCategory(string category);

        // GetBySearchString??
    }

    [DataContract]
    public class Product
    {        
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int Price { get; set; }
    }
}
