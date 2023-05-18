using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengesWithTestsMark8
{
    public class ChallengesSet02
    {
        public bool CharacterIsALetter(char c)
        {
            return Char.IsLetter(c);
        }

        public bool CountOfElementsIsEven(string[] vals)
        {
            return vals.Length % 2 == 0 ? true : false;
        }

        public bool IsNumberEven(int number)
        {
            //if (number % 2 == 0)
            //    return true;
            //else
            //    return false;

            return number % 2 == 0 ? true : false;
        }

        public bool IsNumberOdd(int num)
        {
            //if (num % 2 != 0)
            //    return true;
            //else
            //    return false;

            return num % 2 != 0 ? true : false;
        }

        public double SumOfMinAndMax(IEnumerable<double> numbers)
        {
            if(numbers == null)
            {
                return 0;
            }
            else if(numbers.Count() < 1)
            {
                return 0;
            }
            else
            {
                double sum = 0;
                sum = numbers.Min() + numbers.Max();
                return sum;
            }
        }

        public int GetLengthOfShortestString(string str1, string str2)
        {
            return str1.Length > str2.Length ? str2.Length : str1.Length;
        }

        public int Sum(int[] numbers)
        {
            if(numbers == null)
            {
                return 0;
            }
            else
            {
                int sum = 0;
                foreach (int num in numbers)
                    sum += num;
                return sum;
            }
        }

        public int SumEvens(int[] numbers)
        {
            if(numbers == null)
            {
                return 0;
            }
            else
            {
                int sum = 0;
                foreach (int num in numbers)
                {
                    if (numbers.Length >= 1 && num % 2 == 0)
                    {
                        sum += num;
                    }
                }
                return sum;
            }
        }

        public bool IsSumOdd(List<int> numbers)
        {
            if(numbers == null)
            {
                return false;
            }
            else
            {
                int sum = 0;
                foreach (int num in numbers)
                {
                    sum += num;
                }
                return sum % 2 == 0 ? false : true;
            }
        }

        public long CountOfPositiveOddsBelowNumber(long number)
        {
            //if(number > 0)
            //{
            //    return number / 2;
            //}
            //return 0;

            return number > 0 ? number / 2 : 0;
        }
    }
}
