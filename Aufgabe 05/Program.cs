using System;
using System.Text;

namespace Aufgabe_05
{
    class Program
    {
        static StringBuilder wordsBackwardsSB = new StringBuilder();

        static void Main(string[] args)
        {
            string sentence = "Die Maus frisst Käse";
            string[] words = sentence.Split(" ");
            Console.WriteLine("Sentence: " + sentence);
            Console.WriteLine("Backwards per Letter: " + backwardsPerLetter(sentence));
            Console.WriteLine("Backwards per Word: " + backwardsPerWord(words));
            Console.WriteLine("Words Backwards: " + wordsBackwardsSB);
        }

        public static string backwardsPerLetter(string sentence)
        {
            StringBuilder letters = new StringBuilder();

            for (int i = sentence.Length-1; i >= 0; i--)
            {
                letters.Append(sentence[i]);
            }

            return letters.ToString();
        }

        public static string backwardsPerWord(string[] words)
        {
            StringBuilder bPword = new StringBuilder();

            for (int i = words.Length-1; i >= 0; i--)
            {
                bPword.Append(words[i]);
                wordsBackwardsSB.Append(backwardsPerLetter(words[words.Length-1-i] + " "));
            }

            // wordsbackwards.Length--; Required?
            wordsBackwardsSB.Remove( 0, 1);
            return bPword.ToString();
        }
    }
}
