using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengesWithTestsMark8
{
    public class ChallengesSet04
    {
        public int AddEvenSubtractOdd(int[] numbers)
        {
            var sumEven = numbers.Where(x => x % 2 == 0).Sum();
            var sumOdd = numbers.Where(x => x % 2 != 0).Sum();
            return sumEven - sumOdd;
        }

        public int GetLengthOfShortestString(string str1, string str2, string str3, string str4)
        {
            var stringArray = new string[] { str1, str2, str3, str4 };
            var stringsSorted = stringArray.OrderBy(x => x.Length).ToArray();
            return stringsSorted[0].Length;
        }

        public int GetSmallestNumber(int number1, int number2, int number3, int number4)
        {
            var numbers = new List<int>() { number1, number2, number3, number4 };
            return numbers.Min();
        }

        public void ChangeBusinessNameTo_TrueCoders(Business biz)
        {
            biz.Name = "TrueCoders";
        }

        //the sum of two side lengths of a triangle is always greater than the third side
        //a + b > c ; a + c > b ; b + c > a
        //sL = sideLength
        public bool CouldFormTriangle(int sL1, int sL2, int sL3)
        {
            if ((sL1 + sL2 > sL3) && (sL1 + sL3 > sL2) && (sL2 + sL3 > sL1))
                return true;
            else
                return false;
        }

        public bool IsStringANumber(string input)
        {
            return double.TryParse(input, out _);
        }

        public bool MajorityOfElementsInArrayAreNull(object[] objs)
        {
            var numberOfObjects = objs.Count();
            var numberOfNull = objs.Where(x => x == null).Count();
            return (numberOfNull > numberOfObjects / 2);
        }

        public double AverageEvens(int[] numbers)
        {
            if (numbers == null)
                return 0;
            else
            {
                var evenNumbers = numbers.Where(x => x % 2 == 0);
                if (evenNumbers.Count() == 0)
                    return 0;
                else
                    return evenNumbers.Average();
            }
        }

        public int Factorial(int number)
        {
            if (number > 0)
            {
                int factorial = 1;
                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }
            else if (number == 0)
                return 1;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}
