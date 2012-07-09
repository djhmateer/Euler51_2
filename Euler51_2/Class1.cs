using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace Euler51_2
{
    [TestFixture]
    public class E51Tests
    {
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
            for (int a = 10001; a <= 20000000; a = a + 2)
            {
                if (IsPrime(a))
                {
                    var listPrimesInFamily = new List<int>();
                    string s = a.ToString();
                    //pick a digit to use
                    for (int i = 0; i <= 9; i++)
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
