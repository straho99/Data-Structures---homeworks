namespace _03.Collection_of_products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ProductsTests
    {
        public static void Main()
        {
            //ProductFactory.CreatePoducts(2000); //Test with various number of products
            //var productsDatabase = new ProductsCollectionSlow(GetProducts(ProjectFolder.GetCurrentProjectFolder() + "products.txt"));
            var productsDatabase = new ProductsCollectionFast(GetProducts(ProjectFolder.GetCurrentProjectFolder() + "products.txt"));

            var phones = productsDatabase.FindProductsByTitle("Phone");
            Console.WriteLine("Phones: {0}", string.Join(", ", phones.ToList()));

            Console.WriteLine();

            var productsInRange = productsDatabase.FindProductsInRange(0, 100);
            Console.WriteLine("Products: {0}", string.Join(", ", productsInRange.ToList()));

            Console.WriteLine();

            var productsByTitleAndPrice = productsDatabase.FindProductsByTitleAndPrice("TV", 350.50m);
            Console.WriteLine("Products: {0}", string.Join(", ", productsByTitleAndPrice.ToList()));
        }

        public static List<Product> GetProducts(string fileName)
        {
            List<Product> products = new List<Product>();

            using (var reader = new StreamReader(fileName))
            {
                var line = reader.ReadLine();
                while (line != null && line.Length > 2)
                {
                    string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    int id = int.Parse(tokens[0]);
                    string title = tokens[1];
                    string supplier = tokens[2];
                    decimal price = decimal.Parse(tokens[3]);

                    Product product = new Product(id, title, supplier, price);
                    products.Add(product);
                    line = reader.ReadLine();
                }
            }

            return products;
        }
    }
}