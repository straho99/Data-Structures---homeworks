﻿namespace _02.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BiDictionaryTests
    {
        public static void Main()
        {
            var distances = new BiDictionary<string, string, int>();
            distances.Add("Sofia", "Varna", 443);
            distances.Add("Sofia", "Varna", 468);
            distances.Add("Sofia", "Varna", 490);
            distances.Add("Sofia", "Plovdiv", 145);
            distances.Add("Sofia", "Bourgas", 383);
            distances.Add("Plovdiv", "Bourgas", 253);
            distances.Add("Plovdiv", "Bourgas", 292);

            var distancesFromSofia = distances.FindByKey1("Sofia"); // [443, 468, 490, 145, 383]
            Console.WriteLine("[{0}]", string.Join(", ", distancesFromSofia));

            var distancesToBourgas = distances.FindByKey2("Bourgas"); // [383, 253, 292]
            Console.WriteLine("[{0}]", string.Join(", ", distancesToBourgas));

            var distancesPlovdivBourgas = distances.Find("Plovdiv", "Bourgas"); // [253, 292]
            Console.WriteLine("[{0}]", string.Join(", ", distancesPlovdivBourgas));

            var distancesRousseVarna = distances.Find("Rousse", "Varna"); // []
            Console.WriteLine("[{0}]", string.Join(", ", distancesRousseVarna));

            var distancesSofiaVarna = distances.Find("Sofia", "Varna"); // [443, 468, 490]
            Console.WriteLine("[{0}]", string.Join(", ", distancesSofiaVarna));

            var result = distances.Remove("Sofia", "Varna"); // true
            var distancesFromSofiaAgain = distances.FindByKey1("Sofia"); // [145, 383]
            Console.WriteLine(result);

            var distancesToVarna = distances.FindByKey2("Varna"); // []
            Console.WriteLine("[{0}]", string.Join(", ", distancesToVarna));

            var distancesSofiaVarnaAgain = distances.Find("Sofia", "Varna"); // []
            Console.WriteLine("[{0}]", string.Join(", ", distancesSofiaVarnaAgain));
        }
    }
}
