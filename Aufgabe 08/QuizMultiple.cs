using System;

namespace Aufgabe8
{
    class QuizMultiple
    {
        public string question;
        public string[] answers;
        public string [] correct;
        public static void ShowQuestionAndCheckIfMultipleIsCorrect(string question, string[] answers, string[] correct, int score)
        {
            Console.Clear();
            Console.WriteLine(question + "\n" + answers[0] + "\n" + answers[1] + "\n" + answers[2] + "\n" + answers[3] + "\n");

            Console.WriteLine("Wähle die richtige Antworten (mit , getrennnt):");

            string multipleAnswers = Console.ReadLine();
            string[] answer = multipleAnswers.Split(',');

            if (answer[0] == correct[0] && answer[1] == correct[1] && answer[2] == correct[2])
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