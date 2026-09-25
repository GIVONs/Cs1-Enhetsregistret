using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ConsoleApp1.Helpers;


namespace ConsoleApp1.Logic
{
    // DOC: Prisberakningar ansvarar för beräkningar. Metoderna tar emot de värden de behöver och returnerar resultat när det behövs. 
    public static class PriceCalc
    {
        public static void idk2()
        {
        
        }
        public static void CalculateReducedPrice(string priceInput, string saleRate) // exkl. moms
        {
            if (string.IsNullOrEmpty(priceInput) || string.IsNullOrEmpty(saleRate))
            {
                Console.WriteLine("------------ PRIS -------------");
                var price = UI.ReadDecimal(priceInput);

                Console.WriteLine("------------ RABATT -------------");
                var sale = UI.ReadDecimal(saleRate);

                Console.Clear();
                Console.WriteLine(
                    $"""
                ===========================================
                    Total kostnad efter rabatt exkl.moms:

                            {price * sale} kr.


                Tryck valfri tangent för att fortsätta: 
                """);
            } else
            {
                var price = Convert.ToDecimal(priceInput);
                var sale = Convert.ToDecimal(saleRate);

                Console.Clear();
                Console.WriteLine(
                    $"""
                ===========================================
                    Total kostnad efter rabatt exkl.moms:

                            {price * sale} kr.


                Tryck valfri tangent för att fortsätta: 
                """);

                Console.ReadKey();
            }
        }
        public static void CalculateVatCost(decimal priceInput, string moms)
        {

        }


    }
}
