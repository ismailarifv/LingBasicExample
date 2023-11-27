using LingBasicExample;

namespace LinqBasicExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int categoryTop = 1;
            Console.SetCursorPosition(0, 0);
            Console.Write("Id");
            Console.SetCursorPosition(5, 0);
            Console.Write("Name");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Status");
            Console.WriteLine("-------------------------------");
            foreach (var category in DbContext.CategoryList())
            {
                categoryTop++;
                Console.SetCursorPosition(0, categoryTop);
                Console.Write(category.Id);
                Console.SetCursorPosition(5, categoryTop);
                Console.Write(category.Name);
                Console.SetCursorPosition(20, categoryTop);
                Console.WriteLine(category.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("-------------------------------");


            int productTop = categoryTop + 4;

            Console.SetCursorPosition(0, 8);
            Console.Write("Id");
            Console.SetCursorPosition(5, 8);
            Console.Write("Name");
            Console.SetCursorPosition(30, 8);
            Console.Write("Price");
            Console.SetCursorPosition(40, 8);
            Console.Write("Stock");
            Console.SetCursorPosition(50, 8);
            Console.Write("CategoryId");
            Console.SetCursorPosition(70, 8);
            Console.WriteLine("Status");
            Console.WriteLine("------------------------------------------------------------------------------");
            foreach (var product in DbContext.ProductList())
            {
                productTop++;
                Console.SetCursorPosition(0, productTop);
                Console.Write(product.Id);
                Console.SetCursorPosition(5, productTop);
                Console.Write(product.Name);
                Console.SetCursorPosition(30, productTop);
                Console.Write(product.Price);
                Console.SetCursorPosition(40, productTop);
                Console.Write(product.Stock);
                Console.SetCursorPosition(50, productTop);
                Console.Write(product.CategoryId);
                Console.SetCursorPosition(70, productTop);
                Console.WriteLine(product.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            var newProductList = from product in DbContext.ProductList()
                                 join category in DbContext.CategoryList()
                                 on product.CategoryId equals (category.Id)
                                 select new
                                 {
                                     Id = product.Id,
                                     Name = product.Name,
                                     Price = product.Price,
                                     Stock = product.Stock,
                                     CategoryName = category.Name,
                                     IsStatus = product.IsStatus
                                 };

            int newProductTop = productTop + 4;

            Console.SetCursorPosition(0, newProductTop);
            Console.Write("Id");
            Console.SetCursorPosition(5, newProductTop);
            Console.Write("Name");
            Console.SetCursorPosition(30, newProductTop);
            Console.Write("Price");
            Console.SetCursorPosition(40, newProductTop);
            Console.Write("Stock");
            Console.SetCursorPosition(50, newProductTop);
            Console.Write("CategoryName");
            Console.SetCursorPosition(70, newProductTop);
            Console.WriteLine("Status");
            Console.WriteLine("------------------------------------------------------------------------------");
            foreach (var product in newProductList)
            {
                newProductTop++;
                Console.SetCursorPosition(0, newProductTop);
                Console.Write(product.Id);
                Console.SetCursorPosition(5, newProductTop);
                Console.Write(product.Name);
                Console.SetCursorPosition(30, newProductTop);
                Console.Write(product.Price);
                Console.SetCursorPosition(40, newProductTop);
                Console.Write(product.Stock);
                Console.SetCursorPosition(50, newProductTop);
                Console.Write(product.CategoryName);
                Console.SetCursorPosition(70, newProductTop);
                Console.WriteLine(product.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("------------------------------------------------------------------------------");

        }
    }
}