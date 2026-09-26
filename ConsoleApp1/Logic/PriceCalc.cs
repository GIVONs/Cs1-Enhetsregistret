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

        public static void CalculateVatCost(decimal priceInput, string moms) // Beräknar momsbelopp.
        {
            // 
        }


    }
}
