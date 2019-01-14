using System;

namespace Aufgabe_11
{
    delegate void ReportProgressMethod(int progress);
    class Calculator
    {
        public event ReportProgressMethod ProgressMethod;
        public Calculator()
        {
            ProgressMethod += ConsoleOutputProgressInPercent;
            ProgressMethod += ConsoleOutputProgressInfo;
        }
        public void CalculateSomething()
        {
            int i = 0;

            while (i <= 100)
            {
                if(i == 25 || i == 50 || i == 75 || i == 100)
                {
                    ProgressMethod(i);
                }
                i++;
            }
        }
        public void ConsoleOutputProgressInPercent(int _progress)
        {
            Console.WriteLine(_progress + " %");
        }
        public void ConsoleOutputProgressInfo(int _progress)
        {
            if (_progress == 100)
            {
                Console.WriteLine("Fertig!");
            }
            else
            {
                Console.WriteLine("Lädt noch...");
            }
        }
    }
}