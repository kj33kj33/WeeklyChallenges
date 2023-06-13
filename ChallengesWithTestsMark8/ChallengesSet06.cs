using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengesWithTestsMark8
{
    public class ChallengesSet06
    {
        public bool CollectionContainsWord(IEnumerable<string> words, string word, bool ignoreCase)
        {
            bool answer = false;

            if(words == null || words.Count() == 0)
            {
                return answer;
            }

            foreach(string x in words)
            {
                if(x == null)
                {
                    continue;
                }

                if (ignoreCase)
                {
                    if (x.ToLower() == word.ToLower())
                    {
                        answer = true;
                    }
                }

                if (x == word)
                {
                    answer = true;
                }
            }
            return answer;
        }

        public bool IsPrimeNumber(int num)
        {
            if(num <= 1)
            {
                return false;
            }

            for(int i = 2; i < 10000; i++)
            {
                if(num % i == 0 && num != i)
                {
                    return false;
                }
            }
            return true;
        }

        public int IndexOfLastUniqueLetter(string str)
        {
            bool isUnique = true;
            int index = -1;

            for (int i = 0; i < str.Length; i++)
            {
                isUnique = true;

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[i] == str[j] && i != j)
                    {
                        isUnique = false;
                    }
                }

                if (isUnique)
                {
                    index = i;
                }
            }
            return index;
        }

        public int MaxConsecutiveCount(int[] numbers)
        {
            int highCount = 0;

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                int count = 0;

                for(int j = i ; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                        continue;
                    }
                    break;
                }

                if (count > highCount)
                {
                    highCount = count;
                }
            }
            return highCount;
        }

        public double[] GetEveryNthElement(List<double> elements, int n)
        {
            var answerList = new List<double>();

            if (n < 1 || elements == null)
            {
                return answerList.ToArray();
            }

            for (int i = 0; i < elements.Count(); i++)
            {
                if ((i + 1) % n == 0)
                {
                    answerList.Add(elements[i]);
                }
            }
            return answerList.ToArray();
        }
    }
}
