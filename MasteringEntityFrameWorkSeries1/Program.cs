using System;
using System.Linq;

namespace MasteringEntityFrameWorkSeries1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindSlimEntities())
            {
                //var products = context.Products.ToList().Where(a => a.CategoryId == 1);
                var products = from p in context.Products
                               where (p.CategoryId == 1)
                               orderby p.ProductId
                               select p;
                foreach (Product product in products)
                {
                    Console.WriteLine("{0} {1} {2}", product.ProductId, product.ProductName, product.UnitPrice.GetValueOrDefault().ToString("C"));
                }
                //Update Price
                var updateProduct = context.Products.Single(a => a.ProductId == 1);
                updateProduct.UnitPrice++;
                context.SaveChanges();

                //Display Update Unit Price
                Console.WriteLine("Display Update Unit Price\n");
                foreach (Product product in products)
                {
                    Console.WriteLine("{0} {1} {2}", product.ProductId, product.ProductName, product.UnitPrice.GetValueOrDefault().ToString("C"));
                }

                Console.WriteLine("Create a New Product, Please Enter Product Name:\n");
                string name = Console.ReadLine();
                var chocolato = new Product()
                {
                    ProductName = name,
                    CategoryId = 1,
                    UnitPrice = 20
                };
                context.Products.Add(chocolato);
                context.SaveChanges();

                Console.WriteLine("New Product Added:\n");
                Console.WriteLine("{0} {1} {2:C}", chocolato.ProductId, chocolato.ProductName, chocolato.UnitPrice.GetValueOrDefault());
                Console.WriteLine("How many product Delete:\n");
                int dele = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < dele; i++)
                {
                    Console.WriteLine("Delete Product, Enter your selected ProductID:\n");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var deleteProduct = context.Products.FirstOrDefault(a => a.ProductId == id);
                    context.Products.Remove(deleteProduct);
                    context.SaveChanges();
                }
                Console.WriteLine("Display all Product for Enter");
                Console.ReadLine();
                foreach (Product product in products)
                {
                    Console.WriteLine("{0} {1} {2}", product.ProductId, product.ProductName, product.UnitPrice.GetValueOrDefault().ToString("C"));
                }
            }
            Console.ReadKey();
        }
    }
}
