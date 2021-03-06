﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessObjects;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<BusinessObjects.Product> GetAllProducts()
        {
            return ProductList.Instance.ToList();
        }

        public BusinessObjects.Product[] GetByCategory(string category)
        {
            return ProductList.Instance.Where(n => n.Category == category).ToArray();
        }
    }
}
