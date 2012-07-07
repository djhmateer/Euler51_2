using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Euler51_2
{
    [TestFixture]
    public class E51Tests
    {
        [Test]
        public void SmallestPrimeIn8PrimeFamily_Given_Return()
        {
            var result = E51.SmallestPrimeIn8PrimeFamily();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void GetAll8DigitPrimes_Given_ReturnListPrimes()
        {
            List<int> result = E51.GetAll8DigitPrimes();
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ConvertListIntToCSVString_GivenListInt_ReturnCSVString()
        {
            var list = new List<int>() { 3, 5, 7, 11 };
            var result = E51.ConvertListIntToCSVString(list);
            Assert.AreEqual("3,5,7,11", result);
        }

        [Test]
        public void ReadCSVAndConvertToList_Given_ReturnList()
        {
           List<int> result = E51.ReadCSVAndConvertToList();
           CollectionAssert.IsNotEmpty(result);
        }
    }

    public class E51
    {
        public static List<int> ReadCSVAndConvertToList()
        {
            var list = new List<int>();
            string csv = File.ReadAllText(@"e:\temp\primes.csv");
            string[] array = csv.Split(',');
            foreach (var s in array)
            {
                list.Add(Convert.ToInt32(s));
            }
            return list;
        }

        public static string ConvertListIntToCSVString(List<int> list)
        {
            string csv = String.Join(",", list.Select(x => x.ToString()).ToArray());
            return csv;
        }

        public static List<int> GetAll8DigitPrimes()
        {
            var list = new List<int>();
            //for (int i = 10000000; i <= 99999999; i++)
            for (int i = 10000001; i <= 11199999; i = i + 2)
            {
                if (IsPrime(i))
                {
                    list.Add(i);
                    //Console.WriteLine("{0:N0}",i);
                }
            }
            return list;
        }

        public static int SmallestPrimeIn8PrimeFamily()
        {
            throw new NotImplementedException();
        }

        public static bool IsPrime(long a)
        {
            if (a == 1) return false;
            if (a == 2) return true;
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
