namespace _03.Collection_of_products
{
    using System.Collections.Generic;

    public interface IProductCollection
    {
        void Add(Product product);

        bool Remove(int id);

        IEnumerable<Product> FindProductsInRange(decimal startPrice, decimal endPrice);

        IEnumerable<Product> FindProductsByTitle(string title);

        IEnumerable<Product> FindProductsByTitleAndPrice(string title, decimal price);

        IEnumerable<Product> FindProductsInRange(string title, decimal startPrice, decimal endPrice);

        IEnumerable<Product> FindProductsbySupplierAndPrice(string supplier, decimal price);

        IEnumerable<Product> FindProductsInRangeBySupplier(string supplier, decimal startPrice, decimal endPrice);
    }
}
