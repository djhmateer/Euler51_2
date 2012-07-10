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
            array[1] = (char) (3+48);
            return 0;
        }

        public static int FindSmallestPrime()
        {
            //assume 6 digits will be required
            for (int a = 121313; a <= 999999; a = a + 2)
            {
                if (IsPrime(a))
                {
                    var listPrimesInFamily = new List<int>();
                    string s = a.ToString();
                    char[] array = s.ToCharArray();
                    //pick a digit to use..but not last digit as this wouldn't allow 8 primes
                    //leading 0's not permitted
                    //looking through for a triplet of numbers in the first 5 digits
                    //that would be exchanged for a total of 8 primes
                    //-1 means don't change the digit
                    for (int i = -1; i <= 9; i++)
                    {
                        if (i != -1 && i != 0)
                        {
                            //change first digit to i
                            array[0] = (char)(i+48);
                        }
                        for (int j = -1; j <= 9; j++)
                        {
                            if (j != -1)
                            {
                                //change second digit to j
                                array[1] = (char)(j+48);
                            }

                            for (int k = -1; k <= 9; k++)
                            {
                                if (k != -1)
                                {
                                    //change third digit to k
                                    array[2] = (char)(k + 48);
                                }
                                string n = new string(array);
                                int numChanged = Convert.ToInt32(n);
                                if (IsPrime(numChanged))
                                {
                                    if (numChanged != a)
                                    {
                                        if (!listPrimesInFamily.Contains(numChanged))
                                        {
                                            listPrimesInFamily.Add(numChanged);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine(listPrimesInFamily.Count);
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
