using System;

namespace ChallengesWithTestsMark8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            var thing = new ChallengesSet06();

            var test = new int[] { 1, 3, 2, 3, 3, 3, 3 };

            var answer = thing.MaxConsecutiveCount(test);

            Console.WriteLine(answer);

        }
    }
}
