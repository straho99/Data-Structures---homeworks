namespace _03.Collection_of_products
{
    using System;
    using System.IO;

    public static class ProductFactory
    {
        private static Random rnd = new Random();

        public static void CreatePoducts(int count)
        {
            string[] suppliers = new string[] { "Apple", "Samsung", "Lenovo", "Motorola", "Huawei", "Acer", "Microsoft", "Nokia", "HTC", "Google", "Telerik" };
            string[] products = new string[] { "Phone", "Meat", "TV", "MP3 Player", "Car", "Computer", "Server", "Bread", "Juice", "Pie", "Sugar" };
            string fileName = ProjectFolder.GetCurrentProjectFolder() + "products.txt";

            using (FileStream fs = File.Open(fileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 1; i <= count; i++)
                {
                    string productName = products[rnd.Next(0, products.Length)];
                    string supplier = suppliers[rnd.Next(0, suppliers.Length)];
                    decimal price = (decimal)(rnd.NextDouble() * 1000);
                    sw.WriteLine(i + "|" + productName + "|" +  supplier + "|" + price.ToString("# ###.00"));
                }
            }
        }
    }
}
