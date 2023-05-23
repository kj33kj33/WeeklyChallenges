using System;
using System.Collections.Generic;

namespace ChallengesWithTestsMark8
{
    public class ChallengesSet03
    {
        public bool ArrayContainsAFalse(bool[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i] == false)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSumOfOddsOdd(IEnumerable<int> numbers)
        {
            if(numbers == null)
            {
                return false;
            }
            var sum = 0;
            foreach(int num in numbers)
            {
                sum += num;
            }
            return sum % 2 == 0 ? false : true;
        }

        public bool PasswordContainsUpperLowerAndNumber(string password)
        {
            char[] chars = password.ToCharArray();
            bool hasUpper = false;
            bool hasLower = false;
            bool hasNumber = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(chars[i]) == true)
                {
                    hasUpper = true;
                }
            }

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(chars[i]) == true)
                {
                    hasLower = true;
                }
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsNumber(chars[i]) == true)
                {
                    hasNumber = true;
                }
            }

            if (hasUpper == true && hasLower == true && hasNumber == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public char GetFirstLetterOfString(string val)
        {
            char[] chars = val.ToCharArray();
            return chars[0];
        }

        public char GetLastLetterOfString(string val)
        {
            char[] chars = val.ToCharArray();
            return chars[chars.Length - 1];
        }

        public decimal Divide(decimal dividend, decimal divisor)
        {
            if (divisor == 0)
                return 0;
            return Decimal.Divide(dividend, divisor);
        }

        public int LastMinusFirst(int[] nums)
        {
            return nums[nums.Length - 1] - nums[0];
        }

        public int[] GetOddsBelow100()
        {
            var oddsList = new List<int>();
            for(int i = 0; i < 100; i++)
                if(i % 2 != 0)
                {
                    oddsList.Add(i);
                }
            return oddsList.ToArray();
        }

        public void ChangeAllElementsToUppercase(string[] words)
        {
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToUpper();
            }
        }
    }
}
