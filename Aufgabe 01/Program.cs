using System;

namespace Aufgabe_01
{
    class Program
    {
        public static void Main(string[] args)
        {
            getNumberFromUser();
        }

        public static void getNumberFromUser()
        {
            string userInput;
            Console.Write("Gib' eine Zahl zwischen 1 und 999 ein: ");
            userInput = Console.ReadLine();

            Console.Write("\n" + convertInputToRomanNumber(userInput) + "\n\n");
        }

        public static string convertInputToRomanNumber(string userInput)
        {
            int inputNumber;

            if (int.TryParse(userInput, out inputNumber)) {
                inputNumber = Convert.ToInt32(userInput);

                String romanNumber = "";

                String[] einer = {"","I","II","III","IV","V","VI","VII","VIII","IX"};
                String[] zehner = {"","X","XX","XXX","XL","L","LX","LXX","LXXX","XC"};
                String[] hunderter = {"","C","CC","CCC","CD","D","DC","DCC","DCCC","CM"};

                int intEiner = inputNumber%10;
                int intZehner = ((inputNumber-intEiner)%100)/10;
                int intHunderter = (inputNumber)/100;

                if( inputNumber < 0 && inputNumber > 999){
                    Console.Write("Die Zahl liegt nicht zwischen 0 und 999!");
                }
                if(inputNumber >= 100){
                    romanNumber = romanNumber + hunderter[intHunderter].ToString();
                }
                if(inputNumber >= 10){
                    romanNumber = romanNumber + zehner[intZehner].ToString();
                }
                if(inputNumber >= 1){
                    romanNumber = romanNumber + einer[intEiner].ToString();
                }
                if(inputNumber == 0){
                    romanNumber = "0";
                }

                return ("So schrieben die Römer die Zahl " + userInput + ": " + romanNumber);

            } else {
                return "Fehler! Bitte nur Zahlen eingeben.";
            }
        }
    }
}
