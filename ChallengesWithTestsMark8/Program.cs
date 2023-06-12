using System;

namespace ChallengesWithTestsMark8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            var strings = new string[] { "Hello,", "my", "name", "is", "James" };
            var thing = new ChallengesSet05();
            thing.TurnWordsIntoSentence(strings);

        }
    }
}
