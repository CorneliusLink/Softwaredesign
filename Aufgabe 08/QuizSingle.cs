using System;

    namespace Aufgabe8
    {
        class QuizSingle
        {
            public string question;
            public string[] answers;
            public int correct;

            public static void ShowQuestionAndCheckIfSingleIsCorrect(string question, string[] answers, int correct, int score)
            {
            Console.Clear();
            Console.WriteLine(question + "\n" + answers[0] + "\n" + answers[1] + "\n" + answers[2] + "\n" + answers[3] + "\n");
            Console.WriteLine("Bitte wähle die richtige Antwort: ");
            int answerChoice = int.Parse(Console.ReadLine());

            if (answerChoice == correct)
            {
                Console.WriteLine("Korrekt!");
                score += 10;
            }
            else
            {
                Console.WriteLine("Falsch...");
            }
            Program.QuizMenu(score);
        }
    }
}