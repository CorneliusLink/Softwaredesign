using System;

namespace Aufgabe_08
{
    class Program
    {
        static void Main(string[] args)
        {
            string getUserInteraction;

            Console.Clear();
            Console.WriteLine("Was möchtest Du tun? Tippe: Spiel spielen, Frage hinzufügen oder Spiel beenden!");
            getUserInteraction = Console.ReadLine();

            switch (getUserInteraction)
            {
                case "Spiel spielen":
                    Console.WriteLine(1);
                    PlayTheGame();
                    break;
                case "Frage hinzufügen":
                    Console.WriteLine(2);
                    break;
                case "Spiel beenden":
                    Console.WriteLine(3);
                    break;
                default:
                    Console.WriteLine("Eingabe nicht erkannt. Programm wird beendet!");
                    break;
            }
        }

        static void PlayTheGame() {
            Console.Clear();
            Console.WriteLine("Was möchtest Du spielen: (1) Normales Quiz, (2) Multiple Choice, (3) Schätzfragen, (4) Ja/Nein Fragen, (5) Freitextantworten");

        }
    }
}
