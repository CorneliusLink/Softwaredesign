using System;

namespace Aufgabe8
{
    class QuizBinary
    {
        public string question;
        public string answer;
        public static void ShowQuestionAndCheckIfBinaryIsCorrect(string question, string answer, int score)
        {
            Console.Clear();
            Console.WriteLine(question + "\n");
            Console.WriteLine("Wähle die richtige Antworten (Ja oder Nein):");

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