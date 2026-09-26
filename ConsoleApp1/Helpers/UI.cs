using ConsoleApp1.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Helpers
{
    // Denna klass ska hantera allt som angår utskrifter, inmatgningar och dess felhanteringar.
    // Enligt DOC: "ansvarar för kontakten med användaren"

    public static class UI
    {
        public static void ShowMenu1()
        {
            Console.Clear();
            Console.WriteLine(
                """
                ===========================================
                       Välkommen till enhetsregistret!     
                ===========================================
                                    MENY

                [1] - ENHETSHANTERAREN

                [2] - BETA TESTER (för systemutvecklare)

                [3] - Stäng programmet

                ===========================================
                """);
        }

        public static void ShowMenu2()
        {
            Console.Clear();
            Console.WriteLine(
                """
                ===========================================
                              ENHETSHANTERAREN
                ===========================================
                                   MENY

                [1] - Visa alla produkter

                [2] - Registering för ny produkt

                [3] - Visa rabatter & moms

                [4] - Gå tillbaka

                ===========================================

                """);
        }

        public static void ShowSaleMenu()
        {
            Console.Clear();
            Console.WriteLine(
                """
                ===========================================
                                NYA ENHETEN
                ===========================================
                                   MENY

                [1] - Ändra data för ny produkt
                
                [2] - Visa rabatter (inkl. moms)

                [3] - Gå tillbaka

                ===========================================

                """);
        }

        public static void ChangeEntityDataMenu()
        {
            Console.Clear();
            Console.WriteLine(
                """
                ===========================================
                              NY ENHET - DATA
                ===========================================
                                   MENY

                [1] - Ändra status
                
                [2] - Gå tillbaka

                ===========================================

                """); 

        }
        public static void ShowBetaMenu()
        {
            Console.Clear();
            Console.WriteLine(
                """
                ===========================================
                       !!     BETA VERSIONSTEST     !!
                ===========================================
                                    MENY

                [1] - 

                [2] - 

                [3] -  

                [4] -  
                
                [5] -  

                ===========================================

                """);
        }

        public static void ShowAllProducts(string row1, string row2, string row3, string? row4) // kan ändras med en list o itererar alla befintliga rows/enheter.
        {
            Console.Clear( );

            Console.WriteLine("\n=============================================");
            Console.WriteLine("                 ALLA PRODUKTER");
            Console.WriteLine("=============================================");
            if ( row4 == null || row4.Trim() == "")
            {
                Console.WriteLine(
                    $"""
                    {row1}
                    {row2}
                    {row3}
                    """); 
            } else
            {
                Console.WriteLine(
                    $"""
                    {row1}
                    {row2}
                    {row3}
                    {row4}
                    """);
            }
            Console.WriteLine("\n=============================================");


            Console.WriteLine("\nTryck på valfri knap i tangentbordet för att fortsätta.");
            Console.ReadKey();

            // men om "row4" inte finns? (kanske "?" i parametern)
            // En lösning vore ju att skapa en loop i program-loopen som du itererar flera gånger och ökar siffran (1, 2, 3...) efter namnet "row" var iteration.
        }

        public static void ShowPriceSummary(decimal totalPrice, double bruttoPrice)
        {
            // Skriver ut total prisberäkningarna beroende på antal enheter (inte iterationer)
            Console.WriteLine("\n=============================================");
            Console.WriteLine("-------- SAMMANFATTNING TOTALT -------");
            Console.WriteLine("\nRegister: [nummer] enheter registerarde\n");
            Console.WriteLine($"""
                        Total pris exkl. moms:              {totalPrice} kr.
                        Total pris inkl. moms (brutto):     {bruttoPrice} kr.            
                        """);
            Console.WriteLine("=============================================");
            Console.ReadKey();
        }

        public static void ShowVAT(decimal totalPrice, double bruttoPris)
        {

        }

        public static string ShowRow(string? id, string? enhetsNamn, string? typ, string? status, decimal price, decimal moms) // Single row
        {

            // price och moms måste konverteras till giltliga data-typ for giltliga tal för ekvation.
            decimal bruttoCost = PriceCalc.CalculateBrutto(price, moms);

            string row =
                $"""
                ---------------------------------------------
                ENHET              
                ID:                 {id}
                Namn:               {enhetsNamn}
                Enhetstyp:          {char.ToUpper(typ?[0] ?? ' ') + typ?.Substring(1)}
                
                Status:             {char.ToUpper(status?[0] ?? ' ') + status?.Substring(1)}
                
                Pris:               {price} kr.
                Pris inkl.moms:     {bruttoCost} kr.
                ---------------------------------------------
                """;

            return row;
        }

        public static string ShowReducedPrices(decimal price, decimal moms, decimal vatRate)
        {
            Console.Clear();
            string entity4PriceIndex = Console.WriteLine($"""
                ========================================================================
                NYA ENHETEN         PRICREDUCERING VS TOTALA PRISER                  

                Pris exkl. moms (netto)             -               { } kr.
                
                Rabatt                              -               { } kr.      

                Rebatterat pris inkl. moms          -               { } kr.

                Momsbelopp                          -               { } kr.

                Totalpris inkl. moms (brutto)       -               { } kr.
                """);
            return entity4PriceIndex;
        }

        // --------------------------------- INMATNINGAR OCH FELHANTERINGAR ---------------------------------------------------

        public static int ReadInteger(string input) // Skriv in string, få ut int.
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen skriv in ett heltal: ");
                input = Console.ReadLine();

                bool readSuccess = int.TryParse(input, out int result); // vi får ut en int
                if (!readSuccess)
                {
                    Console.WriteLine("Vänligen skriv in ett giltlig värde");
                    // Här finns ingen break eller return, så loopen fortsätter tills användaren skriver in ett giltigt värde eller EXIT.
                }
                else
                {
                    return result; // Return tar oss ut ur loopen med acceptabelt värde.
                }
            }
        }

        public static string ReadString(string input)
        {
            Console.Clear();
            Console.WriteLine("Vänligen mata in text: ");
            input = Console.ReadLine().ToLower();

            if (input.ToUpper().Equals("EXIT"))
            {
                return null; // Return tar oss ut ur loopen.
            }
            if (input == null || input.Trim() == "")
            {
                Console.WriteLine("\nFel inmatning.");
            }
            return input;
        }// Skriv in string, få ut string

        public static decimal ReadDecimal()
        {
            // Kontroll för att ange korrekt värde för decimal typ.
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen skriv in ett decimalt värde.");

                string input = Console.ReadLine();
                bool readSuccess = decimal.TryParse(input, out decimal result);
                if (!readSuccess)
                {
                    Console.WriteLine("Vänligen skriv in ett giltlig värde");
                }
                else
                {
                    return result;
                }
            }
        }// Skriv in string, få ut decimal


        public static decimal ParseToDecimal(string input)
        {

            bool readSuccess = decimal.TryParse(input, out decimal result);
            if (!readSuccess)
            {
                Console.WriteLine("Kunde inte konvertera inmatningen till decimal.");
                // Här finns ingen break eller return, så loopen fortsätter tills användaren skriver in ett giltigt värde eller EXIT.
            }

            return result; // Return tar oss ut ur loopen.

        }


    }
}
