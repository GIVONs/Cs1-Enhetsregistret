using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.Helpers
{
    public static class UI
    {
        public static void ShowMenu()
        {
            Console.WriteLine(
                """
                Du har 3 val:

                [1] - Visa alla produkter

                [2] - Mata in ny produkt

                [3] - Stäng programmet

                """);
        }

        public static void visaMoms(int totalPrice, double bruttoPris)
        {

        }

        public static decimal? readDecimal() // detta är en kontroll för att ange korrekt värde för decimal typ.
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen skriv in ett värde");
                Console.WriteLine("Skriv EXIT om du vill avbryta");
                string input = Console.ReadLine();

                if (input.ToUpper().Equals("EXIT"))
                {
                    return null; // Return tar oss ut ur loopen.
                }

                bool readSuccess = decimal.TryParse(input, out var price);
                if (!readSuccess)
                {
                    Console.WriteLine("Vänligen skriv in ett giltlig värde");
                    // Här finns ingen break eller return, så loopen fortsätter tills användaren skriver in ett giltigt värde eller EXIT.
                }
                else
                {
                    return price; // Return tar oss ut ur loopen.
                }
            }
        }
        public static string ShowRow(string id, string enhetsNamn, string typ, string status, int price, double moms)
        {
            string row =
                    $"""

                ENHET              
                ID:                 {id}
                Namn:               {enhetsNamn}
                Enhetstyp:          {char.ToUpper(typ[0]) + typ.Substring(1)}
                
                Status:             {char.ToUpper(status[0]) + status.Substring(1)}
                
                Pris:               {price * (1 * moms)} kr.
                Pris exkl.moms:     {price} kr.
                
                ---------------------------------------------
                """;
            return row;
        }
        
    }
}
