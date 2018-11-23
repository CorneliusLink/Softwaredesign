using System;

namespace Aufgabe_06
{
    public class Quizelement
    {
        public string question;
        public string [] answers;
        public int correct;

        public static void createMenu (string[] answers, string question, int correct, int questionCount, int credits) {
            ConsoleKeyInfo key;
            int choice = Int32.Parse(Program.menuCreator(answers, question));
            if (choice == correct) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDeine Antwort ist richtig! Weiter mit ENTER.");
                    Console.ResetColor();
                    credits = credits + 10;
            }

            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDeine Antwort war leider falsch. Wiederholen mit ENTER.");
                Console.ResetColor();
            }

            do
            {
                key = Console.ReadKey(true);
            } while (key.KeyChar != 13);

            questionCount = questionCount + 1;
            Program.mainActivity(questionCount, credits);
        }
    }
}