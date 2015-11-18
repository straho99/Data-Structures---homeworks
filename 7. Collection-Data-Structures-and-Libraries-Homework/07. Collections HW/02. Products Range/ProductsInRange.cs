namespace _02.Products_Range
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Wintellect.PowerCollections;

    public class ProductsInRange
    {
        public static void Main()
        {
            ProductFactory.CreatePoducts(10000); //Test with bigger number of products
            SearchFactory.CreateSearches(10); //Test with bigger number of searches
            string productsFileName = ProjectFolder.GetCurrentProjectFolder() + "products.txt";
            var products = GetProducts(productsFileName);
            string searchesFileName = ProjectFolder.GetCurrentProjectFolder() + "searches.txt";
            var searches = GetSearches(searchesFileName);

            int index = 1;
            foreach (var search in searches)
            {
                Console.WriteLine("Range N.{0} ({1}): {2}", index, search, string.Join(" | ", GetProductsInPriceRange(search, products)));
                index++;
            }
        }

        public static List<Product> GetProductsInPriceRange(SearchParameter priceRange, OrderedBag<Product> products)
        {
            List<Product> results = new List<Product>();
            var range = products.Range(
                new Product("low", priceRange.LowPrice), 
                true, 
                new Product("high", priceRange.HighPrice), 
                true);
            var count = 0;
            foreach (var product in range)
            {
                results.Add(product);
                count++;
                if (count >= 20)
                {
                    return results;
                }
            }

            return results;
        }

        public static OrderedBag<Product> GetProducts(string fileName)
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            using (var reader = new StreamReader(fileName))
            {
                var line = reader.ReadLine();
                while (line != null && line.Length > 2)
                {
                    string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Product product = new Product(tokens[0].Trim(), decimal.Parse(tokens[1].Trim()));
                    products.Add(product);
                    line = reader.ReadLine();
                }
            }

            return products;
        }

        public static List<SearchParameter> GetSearches(string fileName)
        {
            List<SearchParameter> searches = new List<SearchParameter>();

            using (var reader = new StreamReader(fileName))
            {
                var line = reader.ReadLine();
                while (line != null && line.Length > 2)
                {
                    string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    SearchParameter search = new SearchParameter(decimal.Parse(tokens[0].Trim()), decimal.Parse(tokens[1].Trim()));
                    searches.Add(search);
                    line = reader.ReadLine();
                }
            }

            return searches;
        }
    }
}
