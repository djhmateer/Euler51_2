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
        public void FindSmallestPrime_Given_Return()
        {
            int result = E51.FindSmallestPrime();
            Assert.AreEqual(121313, result);
        }

        [Test]
        public void MethodUnderTest_scenario_expectedbehaviour()
        {
            var result = E51.DoSomething();

        }
    }

    public class E51
    {
        public static int DoSomething()
        {
            string s = "12345";
            char[] array = s.ToCharArray();
            array[1] = (char)(3 + 48);
            return 0;
        }

        public static int FindSmallestPrime()
        {
            //assume 6 digits will be required
            for (int a = 121313; a <= 121313; a = a + 2)
            {
                if (IsPrime(a))
                {
                    string s = a.ToString();
                    char[] array = s.ToCharArray();
                    //pick a digit to use..but not last digit as this wouldn't allow 8 primes
                    //leading 0's not permitted
                    //looking through for a triplet of numbers in the first 5 digits
                    //that would be exchanged for a total of 8 primes
                    //0 means don't change the digit
                    for (int i = 0; i <= 1; i++)
                    {
                        for (int j = 0; j <= 1; j++)
                        {
                            for (int k = 0; k <= 1; k++)
                            {
                                for (int n = 0; n <= 1; n++)
                                {
                                    for (int p = 0; p <= 1; p++)
                                    {
                                        for (int q = 0; q <= 1; q++)
                                        {
                                            var listPrimesInFamily = new List<int>();

                                            //try changing digits
                                            for (int m = 0; m <= 9; m++)
                                            {
                                                if (i == 1) array[0] = (char)(m + 48);
                                                if (j == 1) array[1] = (char)(m + 48);
                                                if (k == 1) array[2] = (char)(m + 48);
                                                if (n == 1) array[3] = (char)(m + 48);
                                                if (p == 1) array[4] = (char)(m + 48);
                                                if (q == 1) array[5] = (char)(m + 48);

                                                string num = new string(array);
                                                int numChanged = Convert.ToInt32(num);
                                                if (IsPrime(numChanged))
                                                {
                                                    if (numChanged != a)
                                                    {
                                                        if (numChanged > 100000)
                                                        {
                                                            if (!listPrimesInFamily.Contains(numChanged))
                                                            {
                                                                listPrimesInFamily.Add(numChanged);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            Console.WriteLine(listPrimesInFamily.Count);
                                            if (listPrimesInFamily.Count == 8)
                                            {
                                                Console.WriteLine("found");
                                            }
                                        }
                                    }
                                }
                            }
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
