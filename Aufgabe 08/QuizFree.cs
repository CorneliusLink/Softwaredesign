using System;

namespace Aufgabe8
{
    class QuizFree
    {
        public string question;
        public string answer;
        public static void ShowQuestionAndCheckIfFreeIsCorrect(string question, string answer, int score)
        {
            Console.Clear();
            Console.WriteLine(question + "\n");
            Console.WriteLine("Wähle die richtige Antworten (+/- 5):");

            string userAnswer = Console.ReadLine();

            if (userAnswer == answer)
            {
                Console.WriteLine("Richtig!");
                score += 10;
            }
            else
            {
                Console.WriteLine("Leider Falsch...");
            }
            Program.QuizMenu(score);
        }
    }
}