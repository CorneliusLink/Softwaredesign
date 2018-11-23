using System;

namespace Aufgabe_06
{
    public class test
    {
        public string[] menuItems;
        public string topline;

        //Loop until the user presses enter
        public static string menuCreator(string[] menuItems, string topline) {

        short curItem = 0, c;
        ConsoleKeyInfo key;

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