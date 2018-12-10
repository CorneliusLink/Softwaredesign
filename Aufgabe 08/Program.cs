using System;

/*
Code Review:
Gut.
-Variablen alle klein geschrieben und englische Namen benutzt. Am Namen ersichtlich was für eine Funktion
-Mehoden alle goßgeschrieben, am Namen ist ersichtlich was die Methode tut
-Klassen ebenfalls
nichts zu meckern
*/

namespace Aufgabe8
{
    class Program
    {
        public int score = 0;

        static void Main(string[] args)
        {
            int score = 0;
            QuizMenu(score);
        }

        public static void QuizMenu(int score)
        {
            Console.WriteLine("Score: " + score + "\nWas möchtest Du tun? \n1. Fragen beantworten \n2. Neue Fragen hinzufügen \n3. Das Program beenden");

            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    PlayTheGame(score);
                    break;
                case 2:
                    AddNewQuestion(score);
                    break;
                default:
                    Console.WriteLine("Das Programm wird beendet!");
                    break;
            }
        }

        public static void PlayTheGame(int score)
        {
            Console.Clear();
            Console.WriteLine("Was für eine Frage möchtest Du beantworten? \n\n1. Normales Quiz \n2. Multiple Choice \n3. Ja/Nein Frage \n4. Zahlen raten \n5. Freitextantworten");
            int questionType = Convert.ToInt32(Console.ReadLine());

            switch (questionType)
            {
                case 1:
                    QuizSingle single = new QuizSingle();
                    single.question = "Wer war der erste Bundeskanzler der BRD?";
                    single.answers =  new string[]{"1. Barrack Obama", "2. Helmut Kohl", "3. Konrad Adenauer", "4. Angela Merkel"};
                    single.correct = 3;
                    QuizSingle.ShowQuestionAndCheckIfSingleIsCorrect(single.question, single.answers, single.correct, score);
                    break;
                case 2:
                    QuizMultiple multiple = new QuizMultiple();
                    multiple.question = "Was ist alles ein Säugetier?";
                    multiple.answers =  new string[]{"1. Wal", "2. Delphin", "3. Spinne", "4. Kuh"};
                    multiple.correct = new string[]{"1","2","4"};
                    QuizMultiple.ShowQuestionAndCheckIfMultipleIsCorrect(multiple.question, multiple.answers, multiple.correct, score);
                    break;
                case 3:
                    QuizBinary binary = new QuizBinary();
                    binary.question = "Ist Berlin die Hauptstadt von Deutschland?";
                    binary.answer =  "Ja";
                    QuizBinary.ShowQuestionAndCheckIfBinaryIsCorrect(binary.question, binary.answer, score);
                    break;
                case 4:
                    QuizGuess guess = new QuizGuess();
                    guess.question = "Wie viele Tage hat ein Jahr?\n";
                    guess.answer =  365;
                    QuizGuess.ShowQuestionAndCheckIfGuessIsCorrect(guess.question, guess.answer, score);
                    break;
                case 5:
                    QuizFree free = new QuizFree();
                    free.question = "Welcher Torwart wird auch Titan genannt?\n";
                    free.answer =  "Oliver Kahn";
                    QuizFree.ShowQuestionAndCheckIfFreeIsCorrect(free.question, free.answer, score);
                    break;
                default:
                    Console.WriteLine("Sorry! There are no questions left. Your score is: " + score);
                    break;
            }
        }

        public static void AddNewQuestion(int score)
        {
            Console.Clear();
            Console.WriteLine("Was für eine Frage möchtest Du erstellen? \n\n1. Normales Quiz \n2. Multiple Choice \n3. Ja/Nein Frage \n4. Zahlen raten \n5. Freitextantworten");
            int questionType = Convert.ToInt32(Console.ReadLine());

            switch (questionType)
            {
                case 1:
                    AddNewSingleQuiz(score);
                    break;
                case 2:
                    AddNewMultipleQuiz(score);
                    break;
                case 3:
                    AddNewBinaryQuiz(score);
                    break;
                case 4:
                    AddNewGuessQuiz(score);
                    break;
                case 5:
                    AddNewFreeQuiz(score);
                    break;
                default:
                    Console.WriteLine("Das Programm wird beendet!");
                    break;
            }
        }

        public static void AddNewSingleQuiz(int score)
        {
            Console.WriteLine("Wie lautet die Frage?\n");
            string userQuestion = Console.ReadLine();
            Console.WriteLine("Wie lautet die Antworten?\n");
            string userAnswers = Console.ReadLine();
            Console.WriteLine("Welche Antwort ist die richtige?\n");
            int userCorrect = int.Parse(Console.ReadLine());
            QuizSingle single = new QuizSingle();
            single.question = userQuestion;
            single.answers =  userAnswers.Split(",");
            single.correct = userCorrect;
            QuizSingle.ShowQuestionAndCheckIfSingleIsCorrect(single.question, single.answers, single.correct, score);
        }

        public static void AddNewMultipleQuiz(int score)
        {
            Console.WriteLine("Wie lautet die Frage?\n");
            string userQuestion = Console.ReadLine();
            Console.WriteLine("Wie lautet die Antworten?\n");
            string userAnswers = Console.ReadLine();
            Console.WriteLine("Welche Antworten sind die richtigen?\n");
            string userCorrect = Console.ReadLine();
            QuizMultiple multiple = new QuizMultiple();
            multiple.question = userQuestion;
            multiple.answers =  userAnswers.Split(",");
            multiple.correct = userCorrect.Split(',');
            QuizMultiple.ShowQuestionAndCheckIfMultipleIsCorrect(multiple.question, multiple.answers, multiple.correct, score);
        }

        public static void AddNewBinaryQuiz(int score)
        {
            Console.WriteLine("Wie lautet die Frage?\n");
            string userQuestion = Console.ReadLine();
            Console.WriteLine("Wie lautet die Antwort?\n");
            string userAnswer = Console.ReadLine();
            QuizBinary binary = new QuizBinary();
            binary.question = userQuestion;
            binary.answer =  userAnswer;
            QuizBinary.ShowQuestionAndCheckIfBinaryIsCorrect(binary.question, binary.answer, score);
        }

        public static void AddNewGuessQuiz(int score)
        {
            Console.WriteLine("Wie lautet die Frage?\n");
            string userQuestion = Console.ReadLine();
            Console.WriteLine("Wie lautet die Antwort?\n");
            int userAnswer = int.Parse(Console.ReadLine());
            QuizGuess guess = new QuizGuess();
            guess.question = userQuestion;
            guess.answer =  userAnswer;
            QuizGuess.ShowQuestionAndCheckIfGuessIsCorrect(guess.question, guess.answer, score);
        }

        public static void AddNewFreeQuiz(int score)
        {
            Console.WriteLine("Wie lautet die Frage?\n");
            string userQuestion = Console.ReadLine();
            Console.WriteLine("Wie lautet die Antwort?\n");
            string userAnswer = Console.ReadLine();
            QuizFree free = new QuizFree();
            free.question = userQuestion;
            free.answer = userAnswer;
            QuizFree.ShowQuestionAndCheckIfFreeIsCorrect(free.question, free.answer, score);
        }
    }
}
