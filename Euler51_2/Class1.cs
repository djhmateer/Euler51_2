using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Euler51_2
{
    [TestFixture]
    public class E51Tests
    {
        //Find the smallest prime which, by changing the same part of that number
        //can form eight different primes
        [Test]
        public void GetSmallestPrimeReplcesWhichIsIn8PrimeFaily_Given_ReturnListPrimes()
        {
            int result = E51.GetSmallestPrimeReplacedWhichIsIn8PrimeFamily();
            Assert.AreEqual(1, result);
        }
    }

    public class E51
    {
        public static int GetSmallestPrimeReplacedWhichIsIn8PrimeFamily()
        {
            //assume 6 digits will be required
            for (int a = 100001; a <= 999999; a = a + 2)
            {
                if (IsPrime(a))
                {
                    var listPrimesInFamily = new List<int>();
                    string s = a.ToString();
                    //pick a digit to use..but not last digit as this wouldn't allow 8 primes
                    //leading 0's not permitted
                    //looking through for a triplet of numbers in the first 5 digits
                    //that would be exchanged for a total of 8 primes
                    for (int i = 1; i <= 8; i++)
                    {
                        char[] digit = i.ToString().ToCharArray();
                        string numChanged = "";
                        //replace 2 of the digits with same number
                        int numChangedNum = 0;
                        for (int j = 0; j < s.Length; j++)
                        {
                            for (int k = 0; k < s.Length; k++)
                            {
                                char[] array = s.ToCharArray();
                                array[j] = digit[0];
                                array[k] = digit[0];
                                string n = new string(array);
                                numChangedNum = Convert.ToInt32(n);

                                if (IsPrime(numChangedNum))
                                {
                                    if (!listPrimesInFamily.Contains(numChangedNum))
                                    {
                                        listPrimesInFamily.Add(numChangedNum);
                                        Console.WriteLine(numChangedNum);
                                    }
                                }
                            }
                        }
                        
                        if (listPrimesInFamily.Count >= 8)
                        {
                            int smallest = listPrimesInFamily.OrderBy(x => x).FirstOrDefault();
                            return smallest;
                        }
                    }
                }
            }
            return -1;
        }

        public static bool IsPrime(long a)
        {
            if (a == 0) return false;
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
