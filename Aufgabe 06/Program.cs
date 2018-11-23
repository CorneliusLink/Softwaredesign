using System;

namespace Aufgabe_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int questionCount = 1;
            int credits = 0;
            MainMenu(questionCount, credits);
        }

        public static void MainMenu(int questionCount, int credits)
        {
            string mainMenuTopLine = "Was möchtest Du tun? (Aktuelle Punktzahl: " + credits + ")\n";
            string[] mainMenuOptions = { "1. Quizfragen beantworten", "2. Eigene Quizfrage erstellen", "3. Beenden" };
            int choice = Int32.Parse(MenuCreator(mainMenuTopLine, mainMenuOptions));

            if (choice == 0) {
                QuestionBuilder(questionCount, credits);
            }
            else if (choice == 1) {
                UserQuestion(questionCount, credits);
            }
            else {
                Console.WriteLine("Das Programm wurde beendet.");
            }
        }

        //Methode to create a menu in which the user can choose between different values

        public static void QuestionBuilder(int questionCount, int credits)
        {
            //Switch between all predefined answers
            switch(questionCount)
            {
                case 1:
                    Quizelement quiz1 = new Quizelement();
                    quiz1.question = "Wer war der 1. Bundeskanzler der BRD?\n";
                    quiz1.answers = new string[]{"1. Barrack Obama", "2. Helmut Kohl", "3. Konrad Adenauer", "4. Angela Merkel"};
                    quiz1.correct = 2;
                    Quizelement.createMenu(quiz1.question, quiz1.answers, quiz1.correct, questionCount, credits);
                    break;
                case 2:
                    Quizelement quiz2 = new Quizelement();
                    quiz2.question = "Wie weit ist die Sonne von der Erde entfernt?\n";
                    quiz2.answers = new string[]{"1. 500 m", "2. 149.600.000 km", "3. 500.000 km", "4. 300.500.000 km", "5. Zwei Lichtjahre", "6. Zu weit."};
                    quiz2.correct = 1;
                    Quizelement.createMenu(quiz2.question, quiz2.answers, quiz2.correct, questionCount, credits);
                    break;
                case 3:
                    Quizelement quiz3 = new Quizelement();
                    quiz3.question = "Arnold Schwarzenegger hatte in folgenden Filme eine Rolle: Versprochen ist versprochen, Terminator, Red Heat\n";
                    quiz3.answers = new string[]{"Wahr", "Falsch"};
                    quiz3.correct = 0;
                    Quizelement.createMenu(quiz3.question, quiz3.answers, quiz3.correct, questionCount, credits);
                    break;
                case 4:
                    Quizelement quiz4 = new Quizelement();
                    quiz4.question = "Mit wem stand Edmund Hillary 1953 auf dem Gipfel des Mount Everest?\n";
                    quiz4.answers = new string[]{"1. Nasreddin Hodscha", "2. Nursay Pimsorn", "3. Tenzing Norgay", "4. Abrindranath Singh"};
                    quiz4.correct = 2;
                    Quizelement.createMenu(quiz4.question, quiz4.answers, quiz4.correct, questionCount, credits);
                    break;
                case 5:
                    Quizelement quiz5 = new Quizelement();
                    quiz5.question = "Welche beiden Gibb-Brüder der Popband The Bee Gees sind Zwillinge?\n";
                    quiz5.answers = new string[]{"1. Robin und Barry", "2. Maurice und Robin", "3. Barry und Maurice", "4. Andy und Robin"};
                    quiz5.correct = 1;
                    Quizelement.createMenu(quiz5.question, quiz5.answers, quiz5.correct, questionCount, credits);
                    break;
                default:
                    Console.WriteLine("Das war's leider schon. Du hast alle Fragen beantwortet und insgesamt " + credits + " von 50 Punkten erreicht!");
                    break;
            }

        }
        public static string MenuCreator(string topline, string[] options)
        {
            //Variable to track the current choice
            short curItem = 0, c;
            ConsoleKeyInfo key;

            //Loop until the user presses enter
            do
            {
                Console.Clear();

                Console.WriteLine(topline);

                // Loop to go through all the menu items
                for (c = 0; c < options.Length; c++)
                {
                    if (curItem == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(options[c]);
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.WriteLine(options[c]);
                        Console.ResetColor();
                    }
                }

                //Waits until the user presses a key
                key = Console.ReadKey(true);

                //Loops around all the menu items
                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > options.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(options.Length - 1);
                }

            } while (key.KeyChar != 13);

            // If user presses enter take index of selected menu item and continue
            return curItem.ToString();
        }

        public static void UserQuestion(int questionCount, int credits)
        {
            //Enable user defined questions
            ConsoleKeyInfo key;
            string userQuestion;
            string[] allUserAnswers;
            string userAnswers;
            int userCorrect;

            Console.Clear();
            Console.WriteLine("Bitte gib' eine Frage ein und drücke dann ENTER:");
            userQuestion = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Und nun gib' bitte die Antwortmöglichkeiten ein (2-6 möglich / durch \",\" getrennt) und drücke dann ENTER:");
            userAnswers = Console.ReadLine();
            allUserAnswers = userAnswers.Split(',');

            Console.WriteLine("Welche ist die richtige Antwort?");
            userCorrect = Int32.Parse(Console.ReadLine());

            if (allUserAnswers.Length > 6 || allUserAnswers.Length < 2) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bitte gib' mindestens zwei und maximal sechs Antwortmöglichkeiten (durch \",\" getrennt) ein!");
                Console.ResetColor();

                do
                {
                    key = Console.ReadKey(true);
                } while (key.KeyChar != 13);

                Program.UserQuestion(questionCount, credits);
            }

            else {
                Quizelement userQuiz = new Quizelement();
                userQuiz.question = userQuestion;
                userQuiz.answers = allUserAnswers;
                userQuiz.correct = userCorrect-1;
                questionCount = 0;
                Quizelement.createMenu(userQuiz.question, userQuiz.answers, userQuiz.correct, questionCount, credits);
            }
        }
    }
}