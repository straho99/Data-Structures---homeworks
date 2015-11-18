namespace _02.Products_Range
{
    using System;
    using System.IO;

    public static class ProductFactory
    {
        private static Random rnd = new Random();

        public static void CreatePoducts(int count)
        {
            string[] colors = new string[] { "Red", "Green", "Blue", "White", "Black", "Yellow", "Orange", "Brown", "Grey", "Purple", "Gold" };
            string[] products = new string[] { "Phone", "Apple", "TV", "MP3 Player", "Car", "Computer", "Server", "Bread", "Juice", "Pie", "Sugar" };
            string fileName = ProjectFolder.GetCurrentProjectFolder() + "products.txt";

            using (FileStream fs = File.Open(fileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < count; i++)
                {
                    string productName = colors[rnd.Next(0, colors.Length)] + " " + products[rnd.Next(0, products.Length)];
                    decimal price = (decimal)(rnd.NextDouble() * 1000);
                    sw.WriteLine(productName + " | " + price.ToString("# ###.00"));
                }
            }
        }
    }
}
