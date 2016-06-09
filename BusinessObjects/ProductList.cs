using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ProductList : List<Product>
    {
        private static ProductList _instance = null;
        private ProductList()
        {
            Add(new Product { Name = "Cirkelsåg", Category = "Verktyg och maskiner", Price = 382 });
            Add(new Product { Name = "Skruvdragare", Category = "Verktyg och maskiner", Price = 1432 });
            Add(new Product { Name = "Sticksåg", Category = "Verktyg och maskiner", Price = 199 });
            Add(new Product { Name = "Svets", Category = "Verktyg och maskiner", Price = 4722 });
            Add(new Product { Name = "Kompressor", Category = "Verktyg och maskiner", Price = 1232 });

            Add(new Product { Name = "Mögeltest", Category = "Bygg och färg", Price = 312 });
            Add(new Product { Name = "Fönsterfärg", Category = "Bygg och färg", Price = 78 });
            Add(new Product { Name = "Taktvätt", Category = "Bygg och färg", Price = 100 });
            Add(new Product { Name = "Träolja", Category = "Bygg och färg", Price = 42 });
            Add(new Product { Name = "Arbetsbock", Category = "Bygg och färg", Price = 123 });

            Add(new Product { Name = "Lampskärm", Category = "El och belysning", Price = 38 });
            Add(new Product { Name = "Bordslampa", Category = "El och belysning", Price = 143 });
            Add(new Product { Name = "Vägguttag", Category = "El och belysning", Price = 99 });
            Add(new Product { Name = "Dimmer", Category = "El och belysning", Price = 222 });
            Add(new Product { Name = "Strömbrytare", Category = "El och belysning", Price = 62 });

            Add(new Product { Name = "Lövuppsamlare", Category = "Trädgård", Price = 52 });
            Add(new Product { Name = "Grästrimmer", Category = "Trädgård", Price = 412 });
            Add(new Product { Name = "Gräsklippare", Category = "Trädgård", Price = 2199 });
            Add(new Product { Name = "Stol", Category = "Trädgård", Price = 147 });
            Add(new Product { Name = "Grill", Category = "Trädgård", Price = 332 });

            Add(new Product { Name = "Wobblerset", Category = "Fritid", Price = 682 });
            Add(new Product { Name = "Stövlar", Category = "Fritid", Price = 202 });
            Add(new Product { Name = "Cykel", Category = "Fritid", Price = 1999 });
            Add(new Product { Name = "Friluftskit", Category = "Fritid", Price = 222 });
            Add(new Product { Name = "Cykelpump", Category = "Fritid", Price = 32 });

        }

        public static ProductList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductList();
                return _instance;
            }
        }
    }
}
