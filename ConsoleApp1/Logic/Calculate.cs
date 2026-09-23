using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Logic
{
    public static class Calculate
    {
        public static void dk()
        {
            //  --------------------------- Ny Enhetsinmatning ----------------------------------
            string justExit = "exit";

            Console.WriteLine("\nMata in information om enhet 4.\nAnge namn på enheten: ");
            string enhet4 = Console.ReadLine();
            if (enhet4 == justExit.ToLower() || enhet4 == null || enhet4.Trim() == "")
            {
                Console.WriteLine("\nFel inmatning.");
                break;
            }

            Console.WriteLine("Ange ID: ");
            string id4 = Console.ReadLine();
            if (id4 == justExit.ToLower() || id4 == null || id4.Trim() == "")
            {
                Console.WriteLine("\nFel inmatning.");
                break;
            }

            Console.WriteLine("Ange pris: ");
            string inputPrice4 = Console.ReadLine();
            if (inputPrice4 == justExit.ToLower())
            {
                Console.WriteLine("\nFel inmatning, vänligen skriv enbart siffror.");
                break;
            }
            int price4 = 0; // The future return value after TryParse()
            if (int.TryParse(inputPrice4, out price4))
            {/*just continue without doing anything*/}
            else
            {
                Console.WriteLine("\nFel inmatning, vänligen skriv enbart siffror.");
                break;
            }

            Console.WriteLine("Ange status (Aktiv/Inaktiv/Service): ");
            string status4 = Console.ReadLine();
            status4 = status4.ToLower();
            if (status4 == justExit.ToLower()
                || status4 == null
                || status4.Trim() == ""
                || (status4 != "aktiv"
                && status4 != "inaktiv"
                && status4 != "service"))
            {
                Console.WriteLine("\nFel inmatning.");
                break;
            }

            Console.WriteLine("Vänligen ange typen av produkt [Dator/Projektor/Skärm/Nätverksutrustning] (om du är osäker skriv 'Övrigt')\nAnge svar: ");
            string enhetsTyp4 = Console.ReadLine();
            enhetsTyp4 = enhetsTyp4.ToLower();
            if (enhetsTyp4 == justExit.ToLower()
                || enhetsTyp4 == null
                || enhetsTyp4.Trim() == ""
                || (enhetsTyp4 != "dator"
                && enhetsTyp4 != "projektor"
                && enhetsTyp4 != "skärm"
                && enhetsTyp4 != "nätverksutrustning"
                && enhetsTyp4 != "övrigt"))
            {
                Console.WriteLine("\nFel inmatning.");
                break;
            }

            Console.Clear(); // ------------------- KONTROLLFRÅGOR -------------------------------------
            Console.WriteLine("\nKontrollfrågor:");
            Console.WriteLine("Ska produkten markeras som 'kritsik'? [J/N]: ");
            string kritiskMarkör = Console.ReadLine();

            kritiskMarkör = kritiskMarkör.ToUpper();
            if (kritiskMarkör == null || kritiskMarkör.Trim() == "" || (kritiskMarkör != "J" && kritiskMarkör != "N"))
            {
                Console.WriteLine("\nFel inmatning.");
                break;
            }

            Console.WriteLine("Har enheten garanti? [J/N]: ");
            string garanti = Console.ReadLine();
            garanti = garanti.ToUpper();
            if (garanti == null || garanti.Trim() == "" || (garanti != "J" && garanti != "N"))
            {
                Console.WriteLine("\nFel inmatning.");
                break;
            }

            Console.WriteLine("Är enheten köpt på ramavtal? [J/N]: ");
            string ramAvtal = Console.ReadLine();
            ramAvtal = ramAvtal.ToUpper();
            if (ramAvtal == null || ramAvtal.Trim() == "" || (ramAvtal != "J" && ramAvtal != "N"))
            {
                Console.WriteLine("\nFel inmatning.");
                break;
            }
        }
    }
}
