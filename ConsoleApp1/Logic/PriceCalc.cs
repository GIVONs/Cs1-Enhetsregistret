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
        public static decimal CalculateBrutto(decimal price, decimal moms) // total price inkl. moms
        {
            int convertedPrice = Convert.ToInt16(price);


            decimal vatOnPrice = convertedPrice * moms;
            decimal bruttoCost = vatOnPrice + convertedPrice;
            
            return bruttoCost;
        }
        public static decimal ShowSalePercent(decimal price, int moms)
        {
            Console.WriteLine("\nRabbatprocent från 0-100.");
            while (true)
            {
                int saleValue = ReadInteger(price);

                bool validRange = saleValue <= 100 && saleValue >= 0;
                if (!validRange)
                {
                    Console.WriteLine("\nFel inmatning, vänligen ange ett tal mellan 0-100. ");
                }
                else
                {
                    decimal decimalNumber = saleValue / 100;

                    Console.WriteLine("\nSkriv in enhetens pris.");
                    int number02 = ReadInteger(price);


                    decimal result = number02 * decimalNumber * (1 * moms);
                    return result;
                }
            }
        }
        public static void CalculateVatCost(decimal priceInput, string moms) // Beräknar momsbelopp.
        {
            // 
        }


    }
}
