using System;

namespace Aufgabe_11
{
    delegate void ReportProgress(int progress);
    class Calculator
    {
        public event ReportProgress ProgressMethod;
        public Calculator()
        {
            ProgressMethod += OutputProgress;
            ProgressMethod += OutputProgressText;
        }
        public void CalculateSomething()
        {
            int i = 0;

            while (i <= 100)
            {
                if (i == 25 || i == 50 || i == 75 || i == 100)
                {
                    ProgressMethod(i);
                }
                i++;
            }
        }
        public void OutputProgress(int progressCount)
        {
            Console.WriteLine(progressCount + " %");
        }
        public void OutputProgressText(int progressCount)
        {
            if (progressCount == 100)
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