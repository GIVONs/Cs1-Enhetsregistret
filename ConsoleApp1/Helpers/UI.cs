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

                [2] - Mata in ny produkt

                [3] - Visa rabatter

                [4] - Gå tillbaks

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

        public static string ShowRow(string? id, string? enhetsNamn, string? typ, string? status, string? price, string moms) // Single row
        {

            // price och moms måste konverteras till decimal
            decimal.TryParse(price, out decimal convertedPrice);
            decimal.TryParse(moms, out decimal convertedMoms);


            string row =
                $"""

                ENHET              
                ID:                 {id}
                Namn:               {enhetsNamn}
                Enhetstyp:          {char.ToUpper(typ?[0] ?? ' ') + typ?.Substring(1)}
                
                Status:             {char.ToUpper(status?[0] ?? ' ') + status?.Substring(1)}
                
                Pris:               {convertedPrice * (1 * convertedMoms)} kr.
                Pris exkl.moms:     {convertedPrice} kr.
                
                ---------------------------------------------
                """;

            return row;
        }

        // --------------------------------- INMATNINGAR OCH FELHANTERINGAR ---------------------------------------------------

        public static int ReadInteger(string input)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen skriv in ett heltal: ");
                Console.WriteLine("Skriv EXIT om du vill avbryta");
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
            Console.WriteLine("Vänligen mata in text: ");
            if (input == null || input.Trim() == "")
            {
                Console.WriteLine("\nFel inmatning.");
            }
            return input;
        }
        public static decimal? ReadDecimal(string input)
        {
            // Kontroll för att ange korrekt värde för decimal typ.
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vänligen skriv in ett decimalt värde");
                Console.WriteLine("Skriv EXIT om du vill avbryta");
                input = Console.ReadLine();

                if (input.ToUpper().Equals("EXIT"))
                {
                    return null; // Return tar oss ut ur loopen.
                }

                bool readSuccess = decimal.TryParse(input, out decimal result);
                if (!readSuccess)
                {
                    Console.WriteLine("Vänligen skriv in ett giltlig värde");
                    // Här finns ingen break eller return, så loopen fortsätter tills användaren skriver in ett giltigt värde eller EXIT.
                }
                else
                {
                    return result; // Return tar oss ut ur loopen.
                }
            }
        }

        public static decimal? ShowSalePercent(string sale, string price, int moms)
        {
            Console.WriteLine("Skriv in rabbatvärdet, från 0-100.");
            while (true)
            {
                int number01 = ReadInteger(sale);

                bool validRange = number01 <= 100 && number01 >= 0;
                if (!validRange)
                {
                    Console.WriteLine("Fel inmatning, vänligen ange ett tal mellan 0-100. ");
                } else
                {
                    decimal decimalNumber = number01 / 100;

                    Console.WriteLine("Skriv in enhetens pris.");
                    int number02 = ReadInteger(price);


                    decimal result = number02 * decimalNumber * (1 * moms);
                    return result;
                }
            }


        }


        //  ---------------------------------------- Ny Enhetsinmatning: Enhet 4 ----------------------------------------------
        // Metoder kan bara returnera ett typ-värde, så du kan inte klistra in alla olika element som Riskbedömning, price4, enhet4 etc.
        public static string InputEntity(string newEntity, string newEntityType, string entityID, string newEntityPrice)
        {
            string justExit = "exit";

            while (true)
            {

                Console.WriteLine("\nMata in information om enhet 4.\nAnge namn på enheten: ");
                var newEntityResult = ReadString(newEntity);
                if (newEntity == justExit.ToLower())
                {
                    continue;
                }


                Console.WriteLine("Ange ID: ");
                var entityIDResult = ReadString(entityID);

                if (entityID == justExit.ToLower())
                {
                    continue;
                }

                Console.WriteLine("Ange pris: ");
                
                if (newEntityPrice == justExit.ToLower())
                {
                    continue;
                }
            }

        }
/*        public static string InputEntity()
        {

        }
        public static string InputEntity()
        {

        }*/
    }
}
