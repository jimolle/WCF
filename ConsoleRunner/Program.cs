using System;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new ServiceReference.ProductServiceClient();

            Console.WriteLine(proxy.GetData(10));
            Console.WriteLine("***********");
            foreach (var product in proxy.GetAllProducts())
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine("***********");
            Console.WriteLine("END OF LIST");
            Console.ReadLine();
        }
    }
}
