namespace _03.Collection_of_products
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(int id, string name, string supplier, decimal price)
        {
            this.Id = id;
            this.Title = name;
            this.Supplier = supplier;
            this.Price = price;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return (this.Id.CompareTo(other.Id));
        }

        public override bool Equals(object obj)
        {
            try
            {
                Product otherProduct = (Product)obj;
                if (this.Id == otherProduct.Id)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("[{0} by {1}, price: {2}]", this.Title, this.Supplier, this.Price);
        }
    }
}
