namespace _02.Products_Range
{
    using System;
    using System.IO;

    public static class SearchFactory
    {
        private static Random rnd = new Random();

        public static void CreateSearches(int count)
        {
            string fileName = ProjectFolder.GetCurrentProjectFolder() + "searches.txt";

            using (FileStream fs = File.Open(fileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < count; i++)
                {
                    decimal lowPrice = (decimal)(rnd.NextDouble() * 1000);
                    decimal highPrice = lowPrice + (decimal)(rnd.NextDouble() * 1000);
                    sw.WriteLine(lowPrice.ToString("# ###.00") + " | " + highPrice.ToString("0.00"));
                }
            }
        }
    }
}
