using System;

namespace Aufgabe_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int questionCount = 1;
            int credits = 0;
            mainActivity(questionCount, credits);
        }

        public static void mainActivity(int questionCount, int credits) {
            string infoline = "Was möchtest Du tun? (Aktuelle Punktzahl: " + credits + ")\n";
            string[] mainMenuValues = { "1. Quizfrage beantworten", "2. Eigene Quizfrage erstellen", "3. Beennden" };
            int choice = Int32.Parse(menuCreator(mainMenuValues, infoline));

            if (choice == 0) {
                QuestionBuilder(questionCount, credits);
            }
            else {
                Console.WriteLine("Das ist zurzeit leider noch nicht möglich!");
            }
        }

        //Methode to create a menu in which the user can choose between different values

        public static void QuestionBuilder(int questionCount, int credits) {

            switch(questionCount)
            {
                case 1:
                    Quizelement quiz1 = new Quizelement();
                    quiz1.question = "Wer war der 1. Bundeskanzler der BRD?\n";
                    quiz1.answers = new string[]{"1. Barrack Obama", "2. Helmut Kohl", "3. Konrad Adenauer", "4. Angela Merkel"};
                    quiz1.correct = 2;
                    Quizelement.createMenu(quiz1.answers, quiz1.question, quiz1.correct, questionCount, credits);
                    break;
                case 2:
                    Quizelement quiz2 = new Quizelement();
                    quiz2.question = "Wie weit ist die Sonne von der Erde entfernt?\n";
                    quiz2.answers = new string[]{"1. 500m", "2. 149.600.000km", "3. 500.000km", "4. 300.500.000km", "5. Zwei Lichtjahre", "6. Zu weit."};
                    quiz2.correct = 1;
                    Quizelement.createMenu(quiz2.answers, quiz2.question, quiz2.correct, questionCount, credits);
                    break;
                case 3:
                    Quizelement quiz3 = new Quizelement();
                    quiz3.question = "Arnold Schwarzenegger hatte in folgenden Filme eine Rolle: Versprochen ist versprochen, Terminator, Red Heat\n";
                    quiz3.answers = new string[]{"Wahr", "Falsch"};
                    quiz3.correct = 0;
                    Quizelement.createMenu(quiz3.answers, quiz3.question, quiz3.correct, questionCount, credits);
                    break;
                case 4:
                    Quizelement quiz4 = new Quizelement();
                    quiz4.question = "Mit wem stand Edmund Hillary 1953 auf dem Gipfel des Mount Everest?\n";
                    quiz4.answers = new string[]{"1. Nasreddin Hodscha", "2. Nursay Pimsorn", "3. Tenzing Norgay", "4. Abrindranath Singh"};
                    quiz4.correct = 2;
                    Quizelement.createMenu(quiz4.answers, quiz4.question, quiz4.correct, questionCount, credits);
                    break;
                case 5:
                    Quizelement quiz5 = new Quizelement();
                    quiz5.question = "Welche beiden Gibb-Brüder der Popband The Bee Gees sind Zwillinge?\n";
                    quiz5.answers = new string[]{"1. Robin und Barry", "2. Maurice und Robin", "3. Barry und Maurice", "4. Andy und Robin"};
                    quiz5.correct = 1;
                    Quizelement.createMenu(quiz5.answers, quiz5.question, quiz5.correct, questionCount, credits);
                    break;
                default:
                    break;
            }

        }
        public static string menuCreator(string[] displayedValues, string infoline) {
            //Variable to track the current choice
            short curItem = 0, c;
            ConsoleKeyInfo key;
            string[] menuItems = displayedValues;
            string topline = infoline;

            //Loop until the user presses enter
            do
            {
                Console.Clear();

                Console.WriteLine(topline);

                // Loop to go through all the menu items
                for (c = 0; c < menuItems.Length; c++)
                {
                    if (curItem == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(menuItems[c]);
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.WriteLine(menuItems[c]);
                        Console.ResetColor();
                    }
                }

                //Waits until the user presses a key
                key = Console.ReadKey(true);

                //Loops around all the menu items
                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                }

            } while (key.KeyChar != 13);

            // If user presses enter take index of selected menu item and continue
            return curItem.ToString();
        }
    }
}