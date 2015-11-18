namespace _03.Collection_of_products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class ProductsCollectionFast : IProductCollection
    {
        private Dictionary<int, Product> productsById = new Dictionary<int, Product>();
        private Dictionary<string, SortedSet<Product>> productsByTitle = new Dictionary<string, SortedSet<Product>>();
        private Dictionary<string, SortedSet<Product>> productsBySupplier = new Dictionary<string, SortedSet<Product>>();
        private OrderedMultiDictionary<decimal, Product> productsByPrice = new OrderedMultiDictionary<decimal, Product>(false);

        public ProductsCollectionFast()
        {
        }

        public ProductsCollectionFast(IList<Product> products)
        {
            foreach (var product in products)
            {
                this.Add(product);
            }
        }

        public void Add(Product product)
        {
            this.productsById[product.Id] = product;

            if (this.productsByTitle.ContainsKey(product.Title))
            {
                this.productsByTitle[product.Title].Add(product);
            }
            else
            {
                this.productsByTitle[product.Title] = new SortedSet<Product>() { product };
            }

            if (this.productsBySupplier.ContainsKey(product.Supplier))
            {
                this.productsBySupplier[product.Supplier].Add(product);
            }
            else
            {
                this.productsBySupplier[product.Supplier] = new SortedSet<Product>() { product };
            }

            if (this.productsByPrice.ContainsKey(product.Price))
            {
                this.productsByPrice[product.Price].Add(product);
            }
            else
            {
                this.productsByPrice[product.Price] = new List<Product>() { product };
            }
        }

        public bool Remove(int id)
        {
            if (this.productsById.ContainsKey(id))
            {
                var product = this.productsById[id];
                this.productsById.Remove(id);
                this.productsByTitle[product.Title].Remove(product);
                this.productsBySupplier[product.Supplier].Remove(product);
                this.productsByPrice[product.Price].Remove(product);

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Product> FindProductsInRange(decimal startPrice, decimal endPrice)
        {
            var productsInRange = this.productsByPrice.Range(startPrice, true, endPrice, true);

            var result = new List<Product>();

            foreach (var pricePoint in productsInRange)
            {
                result.AddRange(pricePoint.Value);
            }

            return result;
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            if (this.productsByTitle.ContainsKey(title))
            {
                return this.productsByTitle[title];
            }
            else
            {
                return Enumerable.Empty<Product>();
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, decimal price)
        {
            var titles = Enumerable.Empty<Product>();
            var prices = Enumerable.Empty<Product>();

            if (this.productsByTitle.ContainsKey(title))
            {
                titles = this.productsByTitle[title];
            }

            if (this.productsByPrice.ContainsKey(price))
            {
                prices = this.productsByPrice[price];
            }

            return titles.Intersect<Product>(prices);
        }

        public IEnumerable<Product> FindProductsInRange(string title, decimal startPrice, decimal endPrice)
        {
            var productsInRange = this.productsByPrice.Range(startPrice, true, endPrice, true);

            var result = new List<Product>();

            foreach (var pricePoint in productsInRange)
            {
                foreach (var product in pricePoint.Value)
                {
                    if (product.Title == title)
                    {
                        result.Add(product);
                    }
                }
            }

            return result;
        }

        public IEnumerable<Product> FindProductsbySupplierAndPrice(string supplier, decimal price)
        {
            var prices = Enumerable.Empty<Product>();
            var suppliers = Enumerable.Empty<Product>();

            if (this.productsBySupplier.ContainsKey(supplier))
            {
                prices = this.productsByTitle[supplier];
            }

            if (this.productsByPrice.ContainsKey(price))
            {
                suppliers = this.productsByPrice[price];
            }

            return prices.Intersect<Product>(suppliers);
        }

        public IEnumerable<Product> FindProductsInRangeBySupplier(string supplier, decimal startPrice, decimal endPrice)
        {
            var productsInRange = this.productsByPrice.Range(startPrice, true, endPrice, true);

            var result = new List<Product>();

            foreach (var pricePoint in productsInRange)
            {
                foreach (var product in pricePoint.Value)
                {
                    if (product.Supplier == supplier)
                    {
                        result.Add(product);
                    }
                }
            }

            return result;
        }
    }
}
