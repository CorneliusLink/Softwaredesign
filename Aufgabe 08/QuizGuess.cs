using System;

namespace Aufgabe8
{
    class QuizGuess
    {
        public string question;
        public int answer;
        public static void ShowQuestionAndCheckIfGuessIsCorrect(string question, int answer, int score)
        {
            Console.Clear();
            Console.WriteLine(question + "\n");
            Console.WriteLine("Wähle die richtige Antworten (+/- 5):");

            int userAnswer = Convert.ToInt32(Console.ReadLine());

            if (userAnswer < answer-5 || userAnswer > answer+5)
            {

                Console.WriteLine("Leider Falsch...");
            }
            else
            {
                Console.WriteLine("Richtig!");
                 score += 10;
            }
            Program.QuizMenu(score);
        }
    }
}