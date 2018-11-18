using System;
using System.Text;

namespace Aufgabe_05
{
    class Program
    {
        static StringBuilder wordsbackwards = new StringBuilder("");

        static void Main(string[] args) {
            string sentence = "Hallo Welt";
            string[] words = sentence.Split(" ");
            Console.WriteLine("Sentence: " + sentence);
            Console.WriteLine("Backwards per Letter: " + backwardsPerLetter(sentence));
            Console.WriteLine("Backwards per Word: " + backwardsPerWord(words));
            Console.WriteLine("Words Backwards: " + wordsbackwards);
        }

        public static string backwardsPerLetter(string sentence)
        {
            StringBuilder letters = new StringBuilder("");

            for (int i = sentence.Length-1; i >= 0; i--)
            {
                letters.Append(sentence[i]);
            }

            return letters.ToString();
        }

        public static string backwardsPerWord(string[] words)
        {
            StringBuilder bPword = new StringBuilder("");

            for (int i = words.Length-1; i >= 0; i--)
            {
                bPword.Append(words[i]);
                wordsbackwards.Append(backwardsPerLetter(words[i] + " "));
            }

            // wordsbackwards.Length--; Required?

            return bPword.ToString();
        }
    }
}
