using System;
using System.Collections.Generic;

namespace ChallengesWithTestsMark8
{
    public class ChallengesSet05
    {
        public int GetNextNumberDivisibleByN(int startNumber, int n)
        {
            var checkNumber = 0;

            do
            {
                startNumber++;
                checkNumber = startNumber % n;
            }while(checkNumber != 0);

            return startNumber;
        }

        public void ChangeNamesOfBusinessesWithNoRevenueTo_CLOSED(Business[] businesses)
        {
            foreach(Business business in businesses)
            {
                if(business.TotalRevenue == 0)
                {
                    business.Name = "CLOSED";
                }
            }
        }

        public bool IsAscendingOrder(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return false;
            }

            bool answer = true;

            for (int i = 0; i < numbers.Length -1; i++)
            {
                if (numbers[i] <= numbers[i + 1])
                {
                    answer = true;
                }
                else
                    return false;
            }

            return answer;
        }

        public int SumElementsThatFollowAnEven(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            var sum = 0;

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i + 1];
                }
            }

            return sum;
        }

        public string TurnWordsIntoSentence(string[] words)
        {
            if(words == null || words.Length == 0)
            {
                return "";
            }

            var answer = words[0].Trim();

            for(int i = 1; i < words.Length; i++)
            {
                var trimmedWord = words[i].Trim();
                if(trimmedWord.Length > 0)
                {
                    answer += " " + trimmedWord;
                }
            }

            if (answer == "")
                return answer;
                return (answer += ".");
        }

        public double[] GetEveryFourthElement(List<double> elements)
        {
            var fourthElements = new List<double>();

            if (elements == null || elements.Count == 0)
            {
                return fourthElements.ToArray();
            }

            for(int i = 0; i < elements.Count; i++)
            {
                if((i + 1) % 4 == 0)
                {
                    fourthElements.Add(elements[i]);
                }
            }

            return fourthElements.ToArray();
        }

        public bool TwoDifferentElementsInArrayCanSumToTargetNumber(int[] nums, int targetNumber)
        {
            bool answer = false;
            int num1;
            int num2;

            for (int i = 0; i < nums.Length; i++)
            {
                num1 = nums[i];
                for(int j = i + 1; j < nums.Length; j++)
                {
                    num2 = nums[j];
                    if(num1 + num2 == targetNumber)
                    {
                        answer = true;
                    }
                }
            }
            return answer;
        }
    }
}
