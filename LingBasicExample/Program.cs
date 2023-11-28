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


             newProductTop += 4;
            var filteredProductList = DbContext.ProductList().Where(x => x.Name.ToLower().StartsWith("m")).ToList();
            Console.SetCursorPosition(0, newProductTop);


            Console.SetCursorPosition(0, newProductTop);
            Console.Write("Id");
            Console.SetCursorPosition(5, newProductTop);
            Console.Write("Name");
            Console.SetCursorPosition(30, newProductTop);
            Console.Write("Price");
            Console.SetCursorPosition(40, newProductTop);
            Console.Write("Stock");
            Console.SetCursorPosition(50, newProductTop);
            Console.Write("CategoryId");
            Console.SetCursorPosition(70, newProductTop);
            Console.WriteLine("Status");
            
            foreach (var product in filteredProductList)
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
                Console.Write(product.CategoryId);
                Console.SetCursorPosition(70, newProductTop);
                Console.WriteLine(product.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            newProductTop += 4;
            var statusProductList = DbContext.ProductList().Any(x => x.Name == "Monster Gamer Mouse");
            //Any metodu bir liste içerisinde değerin varlığını kontrol eder ve true yada false değeri döndürür.
            Console.SetCursorPosition(0, newProductTop);
            Console.WriteLine(statusProductList?"Aranan ürün bulundu":"Aranan Ürün bulunamadı");
            Console.WriteLine("------------------------------------------------------------------------------");
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var kesisimNumbers = new[] { 6, 8, 10, 12 };
            var result= numbers.Except(kesisimNumbers);//kesişmeyenleri alıyor
            Console.WriteLine(string.Join(",",result));
            Console.WriteLine("------------------------------------------------------------------------------");

            newProductTop += 4;
            Console.SetCursorPosition(0, newProductTop);

            var numbers2 = new[] { 10, 20, 30, 40, 50 };
            var numbers3 = new[] { 1, 2, 3, 4, 5 };

            var kaynastir = numbers2.Zip(numbers3,(first,second)=>first+second);
            Console.WriteLine(string.Join(",",kaynastir));
            Console.WriteLine("------------------------------------------------------------------------------");


            newProductTop += 4;
            var groupByProducts = newProductList.ToLookup(x => x.CategoryName);
            
            foreach (var product in groupByProducts)
            {
                Console.WriteLine("{1}\n----------------\n{0}\n-----------------------\n",string.Join("\n",product.Select(x=> x.Name).ToArray()),product.Key);
            }

            Console.WriteLine("------------------------------------------------------------------------------");

            var numbers4 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var numbers5 = new[] { 5,6,7, 8,9,10,11,12,13,14,15 };

            var numbers4tonumber5=numbers4.Intersect(numbers5);//kesişenleri alır.

            Console.WriteLine(string.Join(",",numbers4tonumber5));

            Console.WriteLine("------------------------------------------------------------------------------");
            var numbers6 = new[] { 1, 2, 3, 4, 5 };
            var numbers7 = new[] { 3, 4, 5, 6, 7 };

            var number6tonumber7 = numbers6.Concat(numbers7);
            Console.WriteLine(string.Join(",", number6tonumber7));
            Console.WriteLine("------------------------------------------------------------------------------");

            var sumnumber5 = number6tonumber7.Sum();
            Console.WriteLine("Toplam: "+sumnumber5);
            Console.WriteLine("------------------------------------------------------------------------------");

            var number6tonumber7distinct = number6tonumber7.Distinct();
            Console.WriteLine(string.Join(",",number6tonumber7distinct));
            Console.WriteLine("------------------------------------------------------------------------------");

            var number6tonumber7MinMax=number6tonumber7distinct.Max()- number6tonumber7distinct.Min();
            Console.WriteLine(number6tonumber7MinMax);
            var minPriceProduct =DbContext.ProductList().Where(x=>x.Price == DbContext.ProductList().Min(y => y.Price))  ;
            foreach (var item in minPriceProduct)
            {
                Console.WriteLine("Name: "+item.Name+"  Price: "+item.Price);
                
            }
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Toplam: {0} adet ürün bulundu",minPriceProduct.Count());
            Console.WriteLine("------------------------------------------------------------------------------");

            var selectNumberCountProduct = DbContext.ProductList().Take(5).ToList();

            foreach (var item in selectNumberCountProduct)
            {
                Console.WriteLine("Name: " + item.Name + "  Price: " + item.Price);
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            var rangeProduct = DbContext.ProductList().Where(x => x.Price > 5000 && x.Price < 40000).ToList();

            foreach (var item in rangeProduct)
            {
                Console.WriteLine("Name: " + item.Name + "  Price: " + item.Price);
            }

            var repeat = Enumerable.Repeat("İndirim..", rangeProduct.Count());
            Console.WriteLine(string.Join(".",repeat));

            Console.WriteLine("------------------------------------------------------------------------------");

            var orderByRangeProduct = rangeProduct.OrderBy(x => x.Price);
            foreach (var item in orderByRangeProduct)
            {
                Console.WriteLine("Name: " + item.Name + "  Price: " + item.Price);
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            var orderByDescRangeProduct = rangeProduct.OrderByDescending(x => x.Price);
            foreach (var item in orderByDescRangeProduct)
            {
                Console.WriteLine("Name: " + item.Name + "  Price: " + item.Price);
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            var stringCheck = "Monster";
            var containsProduct = rangeProduct.Where(x=>stringCheck.Any(a=>x.Name.ToLower().Contains(stringCheck.ToLower()))).FirstOrDefault();

            Console.WriteLine("Name: "+containsProduct.Name+" Price: "+containsProduct.Price);

            Console.WriteLine("------------------------------------------------------------------------------");

            var firstProduct = rangeProduct.First();
            Console.WriteLine("Name: " + firstProduct.Name + "  Price: " + firstProduct.Price);

            Console.WriteLine("------------------------------------------------------------------------------");

            var lastProduct = rangeProduct.Last();
            Console.WriteLine("Name: " + lastProduct.Name + "  Price: " + lastProduct.Price);



        }
    }
}