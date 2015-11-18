namespace _03.Collection_of_products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsCollectionSlow : IProductCollection
    {
        private IList<Product> products;

        public ProductsCollectionSlow(IList<Product> products)
        {
            this.products = products;
        }

        public void Add(Product product)
        {
            this.products.Add(product);
        }

        public bool Remove(int id)
        {
            if (id < 0 || id > this.products.Count - 1)
            {
                return false;
            }
            else
            {
                this.products.RemoveAt(id);
                return true;
            }
        }

        public IEnumerable<Product> FindProductsInRange(decimal startPrice, decimal endPrice)
        {
            return this.products
                .Where(p => p.Price >= startPrice && p.Price <= endPrice)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            return this.products.Where(p => p.Title == title).OrderBy(p => p.Id).ToList();
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, decimal price)
        {
            return this.products
                .Where(p => p.Title == title && p.Price == price)
                .OrderBy(p => p.Id).ToList();
        }

        public IEnumerable<Product> FindProductsInRange(string title, decimal startPrice, decimal endPrice)
        {
            return this.products
                .Where(p => p.Price >= startPrice && p.Price <= endPrice && p.Title == title)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public IEnumerable<Product> FindProductsbySupplierAndPrice(string supplier, decimal price)
        {
            return this.products
                .Where(p => p.Price == price && p.Supplier == supplier)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public IEnumerable<Product> FindProductsInRangeBySupplier(string supplier, decimal startPrice, decimal endPrice)
        {
            return this.products
                .Where(p => p.Price >= startPrice && p.Price <= endPrice && p.Supplier == supplier)
                .OrderBy(p => p.Id)
                .ToList();
        }
    }
}